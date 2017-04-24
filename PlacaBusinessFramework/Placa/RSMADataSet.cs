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
    public class RSMADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RSMADataTable tableRSMA;
        private RSMA1DataTable tableRSMA1;

        public RSMADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RSMADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RSMA1"] != null)
                    {
                        this.Tables.Add(new RSMA1DataTable(dataSet.Tables["RSMA1"]));
                    }
                    if (dataSet.Tables["RSMA"] != null)
                    {
                        this.Tables.Add(new RSMADataTable(dataSet.Tables["RSMA"]));
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
            RSMADataSet set = (RSMADataSet) base.Clone();
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
            RSMADataSet set = new RSMADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RSMADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1018");
            this.ExtendedProperties.Add("DataSetName", "RSMADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRSMADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RSMA");
            this.ExtendedProperties.Add("ObjectDescription", "RSMA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "HardlyEver");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "RSMADataSet";
            this.Namespace = "http://www.tempuri.org/RSMA";
            this.tableRSMA1 = new RSMA1DataTable();
            this.Tables.Add(this.tableRSMA1);
            this.tableRSMA = new RSMADataTable();
            this.Tables.Add(this.tableRSMA);
            this.Relations.Add("RSMA_RSMA1", new DataColumn[] { this.Tables["RSMA"].Columns["IDENTIFIKATOROBRASCA"] }, new DataColumn[] { this.Tables["RSMA1"].Columns["IDENTIFIKATOROBRASCA"] });
            this.Relations["RSMA_RSMA1"].Nested = true;
            this.tableRSMA.IZNOSOBRACUNANEPLACEColumn.Expression = "IIF(Count(Child(RSMA_RSMA1).IZNOSOBRACUNANEPLACERSMB)=0,0,SUM(Child(RSMA_RSMA1).IZNOSOBRACUNANEPLACERSMB))";
            this.tableRSMA.IZNOSOSNOVICEZADOPRINOSEColumn.Expression = "IIF(Count(Child(RSMA_RSMA1).IZNOSOSNOVICEZADOPRINOSERSMB)=0,0,SUM(Child(RSMA_RSMA1).IZNOSOSNOVICEZADOPRINOSERSMB))";
            this.tableRSMA.MIO1Column.Expression = "IIF(Count(Child(RSMA_RSMA1).MIO1RSMB)=0,0,SUM(Child(RSMA_RSMA1).MIO1RSMB))";
            this.tableRSMA.MIO2Column.Expression = "IIF(Count(Child(RSMA_RSMA1).MIO2RSMB)=0,0,SUM(Child(RSMA_RSMA1).MIO2RSMB))";
            this.tableRSMA.IZNOSISPLACENEPLACEColumn.Expression = "IIF(Count(Child(RSMA_RSMA1).IZNOSISPLACENEPLACERSMB)=0,0,SUM(Child(RSMA_RSMA1).IZNOSISPLACENEPLACERSMB))";
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
            this.tableRSMA1 = (RSMA1DataTable) this.Tables["RSMA1"];
            this.tableRSMA = (RSMADataTable) this.Tables["RSMA"];
            if (initTable)
            {
                if (this.tableRSMA1 != null)
                {
                    this.tableRSMA1.InitVars();
                }
                if (this.tableRSMA != null)
                {
                    this.tableRSMA.InitVars();
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
                if (dataSet.Tables["RSMA1"] != null)
                {
                    this.Tables.Add(new RSMA1DataTable(dataSet.Tables["RSMA1"]));
                }
                if (dataSet.Tables["RSMA"] != null)
                {
                    this.Tables.Add(new RSMADataTable(dataSet.Tables["RSMA"]));
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

        private bool ShouldSerializeRSMA()
        {
            return false;
        }

        private bool ShouldSerializeRSMA1()
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
        public RSMADataTable RSMA
        {
            get
            {
                return this.tableRSMA;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RSMA1DataTable RSMA1
        {
            get
            {
                return this.tableRSMA1;
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
        public class RSMA1DataTable : DataTable, IEnumerable
        {
            private DataColumn columnB;
            private DataColumn columnDOO;
            private DataColumn columnID;
            private DataColumn columnIDENTIFIKATOROBRASCA;
            private DataColumn columnIZNOSISPLACENEPLACERSMB;
            private DataColumn columnIZNOSOBRACUNANEPLACERSMB;
            private DataColumn columnIZNOSOSNOVICEZADOPRINOSERSMB;
            private DataColumn columnMBGOSIGURANIKA;
            private DataColumn columnMIO1RSMB;
            private DataColumn columnMIO2RSMB;
            private DataColumn columnOD;
            private DataColumn columnOO;
            private DataColumn columnPREZIMEIIME;
            private DataColumn columnREDNIBROJ;
            private DataColumn columnSIFRAGRADARADA;

            public event RSMADataSet.RSMA1RowChangeEventHandler RSMA1RowChanged;

            public event RSMADataSet.RSMA1RowChangeEventHandler RSMA1RowChanging;

            public event RSMADataSet.RSMA1RowChangeEventHandler RSMA1RowDeleted;

            public event RSMADataSet.RSMA1RowChangeEventHandler RSMA1RowDeleting;

            public RSMA1DataTable()
            {
                this.TableName = "RSMA1";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RSMA1DataTable(DataTable table) : base(table.TableName)
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

            protected RSMA1DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRSMA1Row(RSMADataSet.RSMA1Row row)
            {
                this.Rows.Add(row);
            }

            public RSMADataSet.RSMA1Row AddRSMA1Row(string iDENTIFIKATOROBRASCA, int iD, string rEDNIBROJ, string pREZIMEIIME, string mBGOSIGURANIKA, string sIFRAGRADARADA, string oO, string b, string oD, string dOO, decimal iZNOSOBRACUNANEPLACERSMB, decimal iZNOSOSNOVICEZADOPRINOSERSMB, decimal mIO1RSMB, decimal mIO2RSMB, decimal iZNOSISPLACENEPLACERSMB)
            {
                RSMADataSet.RSMA1Row row = (RSMADataSet.RSMA1Row) this.NewRow();
                row["IDENTIFIKATOROBRASCA"] = iDENTIFIKATOROBRASCA;
                row["ID"] = iD;
                row["REDNIBROJ"] = rEDNIBROJ;
                row["PREZIMEIIME"] = pREZIMEIIME;
                row["MBGOSIGURANIKA"] = mBGOSIGURANIKA;
                row["SIFRAGRADARADA"] = sIFRAGRADARADA;
                row["OO"] = oO;
                row["B"] = b;
                row["OD"] = oD;
                row["DOO"] = dOO;
                row["IZNOSOBRACUNANEPLACERSMB"] = iZNOSOBRACUNANEPLACERSMB;
                row["IZNOSOSNOVICEZADOPRINOSERSMB"] = iZNOSOSNOVICEZADOPRINOSERSMB;
                row["MIO1RSMB"] = mIO1RSMB;
                row["MIO2RSMB"] = mIO2RSMB;
                row["IZNOSISPLACENEPLACERSMB"] = iZNOSISPLACENEPLACERSMB;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RSMADataSet.RSMA1DataTable table = (RSMADataSet.RSMA1DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RSMADataSet.RSMA1Row FindByIDENTIFIKATOROBRASCAID(string iDENTIFIKATOROBRASCA, int iD)
            {
                return (RSMADataSet.RSMA1Row) this.Rows.Find(new object[] { iDENTIFIKATOROBRASCA, iD });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RSMADataSet.RSMA1Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RSMADataSet set = new RSMADataSet();
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
                this.columnIDENTIFIKATOROBRASCA = new DataColumn("IDENTIFIKATOROBRASCA", typeof(string), "", MappingType.Element);
                this.columnIDENTIFIKATOROBRASCA.AllowDBNull = false;
                this.columnIDENTIFIKATOROBRASCA.Caption = "IDENTIFIKATOROBRASCA";
                this.columnIDENTIFIKATOROBRASCA.MaxLength = 4;
                this.columnIDENTIFIKATOROBRASCA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Description", "IDENTIFIKATOROBRASCA");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Length", "4");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.InternalName", "IDENTIFIKATOROBRASCA");
                this.Columns.Add(this.columnIDENTIFIKATOROBRASCA);
                this.columnID = new DataColumn("ID", typeof(int), "", MappingType.Element);
                this.columnID.AllowDBNull = false;
                this.columnID.Caption = "ID";
                this.columnID.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnID.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnID.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnID.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnID.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnID.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnID.ExtendedProperties.Add("IsKey", "true");
                this.columnID.ExtendedProperties.Add("ReadOnly", "false");
                this.columnID.ExtendedProperties.Add("DeklaritType", "int");
                this.columnID.ExtendedProperties.Add("Description", "ID");
                this.columnID.ExtendedProperties.Add("Length", "5");
                this.columnID.ExtendedProperties.Add("Decimals", "0");
                this.columnID.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnID.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnID.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnID.ExtendedProperties.Add("Deklarit.InternalName", "ID");
                this.Columns.Add(this.columnID);
                this.columnREDNIBROJ = new DataColumn("REDNIBROJ", typeof(string), "", MappingType.Element);
                this.columnREDNIBROJ.AllowDBNull = false;
                this.columnREDNIBROJ.Caption = "REDNIBROJ";
                this.columnREDNIBROJ.MaxLength = 5;
                this.columnREDNIBROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDNIBROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnREDNIBROJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnREDNIBROJ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnREDNIBROJ.ExtendedProperties.Add("Description", "REDNIBROJ");
                this.columnREDNIBROJ.ExtendedProperties.Add("Length", "5");
                this.columnREDNIBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnREDNIBROJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.InternalName", "REDNIBROJ");
                this.Columns.Add(this.columnREDNIBROJ);
                this.columnPREZIMEIIME = new DataColumn("PREZIMEIIME", typeof(string), "", MappingType.Element);
                this.columnPREZIMEIIME.AllowDBNull = false;
                this.columnPREZIMEIIME.Caption = "PREZIMEIIME";
                this.columnPREZIMEIIME.MaxLength = 100;
                this.columnPREZIMEIIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIMEIIME.ExtendedProperties.Add("IsKey", "false");
                this.columnPREZIMEIIME.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPREZIMEIIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Description", "PREZIMEIIME");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Length", "100");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIMEIIME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.InternalName", "PREZIMEIIME");
                this.Columns.Add(this.columnPREZIMEIIME);
                this.columnMBGOSIGURANIKA = new DataColumn("MBGOSIGURANIKA", typeof(string), "", MappingType.Element);
                this.columnMBGOSIGURANIKA.AllowDBNull = false;
                this.columnMBGOSIGURANIKA.Caption = "MBGOSIGURANIKA";
                this.columnMBGOSIGURANIKA.MaxLength = 13;
                this.columnMBGOSIGURANIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Description", "MBGOSIGURANIKA");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Length", "13");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Deklarit.InternalName", "MBGOSIGURANIKA");
                this.Columns.Add(this.columnMBGOSIGURANIKA);
                this.columnSIFRAGRADARADA = new DataColumn("SIFRAGRADARADA", typeof(string), "", MappingType.Element);
                this.columnSIFRAGRADARADA.AllowDBNull = false;
                this.columnSIFRAGRADARADA.Caption = "SIFRAGRADARADA";
                this.columnSIFRAGRADARADA.MaxLength = 4;
                this.columnSIFRAGRADARADA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Description", "SIFRAGRADARADA");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Length", "4");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAGRADARADA");
                this.Columns.Add(this.columnSIFRAGRADARADA);
                this.columnOO = new DataColumn("OO", typeof(string), "", MappingType.Element);
                this.columnOO.AllowDBNull = false;
                this.columnOO.Caption = "OO";
                this.columnOO.MaxLength = 2;
                this.columnOO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOO.ExtendedProperties.Add("IsKey", "false");
                this.columnOO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOO.ExtendedProperties.Add("Description", "OO");
                this.columnOO.ExtendedProperties.Add("Length", "2");
                this.columnOO.ExtendedProperties.Add("Decimals", "0");
                this.columnOO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOO.ExtendedProperties.Add("Deklarit.InternalName", "OO");
                this.Columns.Add(this.columnOO);
                this.columnB = new DataColumn("B", typeof(string), "", MappingType.Element);
                this.columnB.AllowDBNull = false;
                this.columnB.Caption = "B";
                this.columnB.MaxLength = 1;
                this.columnB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnB.ExtendedProperties.Add("IsKey", "false");
                this.columnB.ExtendedProperties.Add("ReadOnly", "false");
                this.columnB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnB.ExtendedProperties.Add("Description", "B");
                this.columnB.ExtendedProperties.Add("Length", "1");
                this.columnB.ExtendedProperties.Add("Decimals", "0");
                this.columnB.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnB.ExtendedProperties.Add("Deklarit.InternalName", "B");
                this.Columns.Add(this.columnB);
                this.columnOD = new DataColumn("OD", typeof(string), "", MappingType.Element);
                this.columnOD.AllowDBNull = false;
                this.columnOD.Caption = "OD";
                this.columnOD.MaxLength = 2;
                this.columnOD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOD.ExtendedProperties.Add("IsKey", "false");
                this.columnOD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOD.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOD.ExtendedProperties.Add("Description", "OD");
                this.columnOD.ExtendedProperties.Add("Length", "2");
                this.columnOD.ExtendedProperties.Add("Decimals", "0");
                this.columnOD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOD.ExtendedProperties.Add("Deklarit.InternalName", "OD");
                this.Columns.Add(this.columnOD);
                this.columnDOO = new DataColumn("DOO", typeof(string), "", MappingType.Element);
                this.columnDOO.AllowDBNull = false;
                this.columnDOO.Caption = "DOO";
                this.columnDOO.MaxLength = 2;
                this.columnDOO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOO.ExtendedProperties.Add("IsKey", "false");
                this.columnDOO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDOO.ExtendedProperties.Add("Description", "DOO");
                this.columnDOO.ExtendedProperties.Add("Length", "2");
                this.columnDOO.ExtendedProperties.Add("Decimals", "0");
                this.columnDOO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOO.ExtendedProperties.Add("Deklarit.InternalName", "DOO");
                this.Columns.Add(this.columnDOO);
                this.columnIZNOSOBRACUNANEPLACERSMB = new DataColumn("IZNOSOBRACUNANEPLACERSMB", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSOBRACUNANEPLACERSMB.AllowDBNull = false;
                this.columnIZNOSOBRACUNANEPLACERSMB.Caption = "IZNOSOBRACUNANEPLACERSMB";
                this.columnIZNOSOBRACUNANEPLACERSMB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Description", "IZNOSOBRACUNANEPLACERSMB");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSOBRACUNANEPLACERSMB");
                this.Columns.Add(this.columnIZNOSOBRACUNANEPLACERSMB);
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB = new DataColumn("IZNOSOSNOVICEZADOPRINOSERSMB", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.AllowDBNull = false;
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.Caption = "IZNOSOSNOVICEZADOPRINOSERSMB";
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Description", "IZNOSOSNOVICEZADOPRINOSERSMB");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSOSNOVICEZADOPRINOSERSMB");
                this.Columns.Add(this.columnIZNOSOSNOVICEZADOPRINOSERSMB);
                this.columnMIO1RSMB = new DataColumn("MIO1RSMB", typeof(decimal), "", MappingType.Element);
                this.columnMIO1RSMB.AllowDBNull = false;
                this.columnMIO1RSMB.Caption = "MIO1 RSMB";
                this.columnMIO1RSMB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMIO1RSMB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMIO1RSMB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMIO1RSMB.ExtendedProperties.Add("IsKey", "false");
                this.columnMIO1RSMB.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMIO1RSMB.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMIO1RSMB.ExtendedProperties.Add("Description", "MIO1 RSMB");
                this.columnMIO1RSMB.ExtendedProperties.Add("Length", "12");
                this.columnMIO1RSMB.ExtendedProperties.Add("Decimals", "2");
                this.columnMIO1RSMB.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMIO1RSMB.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMIO1RSMB.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMIO1RSMB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMIO1RSMB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMIO1RSMB.ExtendedProperties.Add("Deklarit.InternalName", "MIO1RSMB");
                this.Columns.Add(this.columnMIO1RSMB);
                this.columnMIO2RSMB = new DataColumn("MIO2RSMB", typeof(decimal), "", MappingType.Element);
                this.columnMIO2RSMB.AllowDBNull = false;
                this.columnMIO2RSMB.Caption = "MIO2 RSMB";
                this.columnMIO2RSMB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMIO2RSMB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMIO2RSMB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMIO2RSMB.ExtendedProperties.Add("IsKey", "false");
                this.columnMIO2RSMB.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMIO2RSMB.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMIO2RSMB.ExtendedProperties.Add("Description", "MIO2 RSMB");
                this.columnMIO2RSMB.ExtendedProperties.Add("Length", "12");
                this.columnMIO2RSMB.ExtendedProperties.Add("Decimals", "2");
                this.columnMIO2RSMB.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMIO2RSMB.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMIO2RSMB.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMIO2RSMB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMIO2RSMB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMIO2RSMB.ExtendedProperties.Add("Deklarit.InternalName", "MIO2RSMB");
                this.Columns.Add(this.columnMIO2RSMB);
                this.columnIZNOSISPLACENEPLACERSMB = new DataColumn("IZNOSISPLACENEPLACERSMB", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSISPLACENEPLACERSMB.AllowDBNull = false;
                this.columnIZNOSISPLACENEPLACERSMB.Caption = "IZNOSISPLACENEPLACERSMB";
                this.columnIZNOSISPLACENEPLACERSMB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Description", "IZNOSISPLACENEPLACERSMB");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSISPLACENEPLACERSMB");
                this.Columns.Add(this.columnIZNOSISPLACENEPLACERSMB);
                this.PrimaryKey = new DataColumn[] { this.columnIDENTIFIKATOROBRASCA, this.columnID };
                this.ExtendedProperties.Add("ParentLvl", "RSMA");
                this.ExtendedProperties.Add("LevelName", "RSMALevel1");
                this.ExtendedProperties.Add("Description", "RSMALevel1");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDENTIFIKATOROBRASCA = this.Columns["IDENTIFIKATOROBRASCA"];
                this.columnID = this.Columns["ID"];
                this.columnREDNIBROJ = this.Columns["REDNIBROJ"];
                this.columnPREZIMEIIME = this.Columns["PREZIMEIIME"];
                this.columnMBGOSIGURANIKA = this.Columns["MBGOSIGURANIKA"];
                this.columnSIFRAGRADARADA = this.Columns["SIFRAGRADARADA"];
                this.columnOO = this.Columns["OO"];
                this.columnB = this.Columns["B"];
                this.columnOD = this.Columns["OD"];
                this.columnDOO = this.Columns["DOO"];
                this.columnIZNOSOBRACUNANEPLACERSMB = this.Columns["IZNOSOBRACUNANEPLACERSMB"];
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB = this.Columns["IZNOSOSNOVICEZADOPRINOSERSMB"];
                this.columnMIO1RSMB = this.Columns["MIO1RSMB"];
                this.columnMIO2RSMB = this.Columns["MIO2RSMB"];
                this.columnIZNOSISPLACENEPLACERSMB = this.Columns["IZNOSISPLACENEPLACERSMB"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RSMADataSet.RSMA1Row(builder);
            }

            public RSMADataSet.RSMA1Row NewRSMA1Row()
            {
                return (RSMADataSet.RSMA1Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RSMA1RowChanged != null)
                {
                    RSMADataSet.RSMA1RowChangeEventHandler handler = this.RSMA1RowChanged;
                    if (handler != null)
                    {
                        handler(this, new RSMADataSet.RSMA1RowChangeEvent((RSMADataSet.RSMA1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RSMA1RowChanging != null)
                {
                    RSMADataSet.RSMA1RowChangeEventHandler handler = this.RSMA1RowChanging;
                    if (handler != null)
                    {
                        handler(this, new RSMADataSet.RSMA1RowChangeEvent((RSMADataSet.RSMA1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("RSMA_RSMA1", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.RSMA1RowDeleted != null)
                {
                    RSMADataSet.RSMA1RowChangeEventHandler handler = this.RSMA1RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new RSMADataSet.RSMA1RowChangeEvent((RSMADataSet.RSMA1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RSMA1RowDeleting != null)
                {
                    RSMADataSet.RSMA1RowChangeEventHandler handler = this.RSMA1RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new RSMADataSet.RSMA1RowChangeEvent((RSMADataSet.RSMA1Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRSMA1Row(RSMADataSet.RSMA1Row row)
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

            public DataColumn IDColumn
            {
                get
                {
                    return this.columnID;
                }
            }

            public DataColumn IDENTIFIKATOROBRASCAColumn
            {
                get
                {
                    return this.columnIDENTIFIKATOROBRASCA;
                }
            }

            public RSMADataSet.RSMA1Row this[int index]
            {
                get
                {
                    return (RSMADataSet.RSMA1Row) this.Rows[index];
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

            public DataColumn OOColumn
            {
                get
                {
                    return this.columnOO;
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
        }

        public class RSMA1Row : DataRow
        {
            private RSMADataSet.RSMA1DataTable tableRSMA1;

            internal RSMA1Row(DataRowBuilder rb) : base(rb)
            {
                this.tableRSMA1 = (RSMADataSet.RSMA1DataTable) this.Table;
            }

            public RSMADataSet.RSMARow GetRSMARow()
            {
                return (RSMADataSet.RSMARow) this.GetParentRow("RSMA_RSMA1");
            }

            public bool IsBNull()
            {
                return this.IsNull(this.tableRSMA1.BColumn);
            }

            public bool IsDOONull()
            {
                return this.IsNull(this.tableRSMA1.DOOColumn);
            }

            public bool IsIDENTIFIKATOROBRASCANull()
            {
                return this.IsNull(this.tableRSMA1.IDENTIFIKATOROBRASCAColumn);
            }

            public bool IsIDNull()
            {
                return this.IsNull(this.tableRSMA1.IDColumn);
            }

            public bool IsIZNOSISPLACENEPLACERSMBNull()
            {
                return this.IsNull(this.tableRSMA1.IZNOSISPLACENEPLACERSMBColumn);
            }

            public bool IsIZNOSOBRACUNANEPLACERSMBNull()
            {
                return this.IsNull(this.tableRSMA1.IZNOSOBRACUNANEPLACERSMBColumn);
            }

            public bool IsIZNOSOSNOVICEZADOPRINOSERSMBNull()
            {
                return this.IsNull(this.tableRSMA1.IZNOSOSNOVICEZADOPRINOSERSMBColumn);
            }

            public bool IsMBGOSIGURANIKANull()
            {
                return this.IsNull(this.tableRSMA1.MBGOSIGURANIKAColumn);
            }

            public bool IsMIO1RSMBNull()
            {
                return this.IsNull(this.tableRSMA1.MIO1RSMBColumn);
            }

            public bool IsMIO2RSMBNull()
            {
                return this.IsNull(this.tableRSMA1.MIO2RSMBColumn);
            }

            public bool IsODNull()
            {
                return this.IsNull(this.tableRSMA1.ODColumn);
            }

            public bool IsOONull()
            {
                return this.IsNull(this.tableRSMA1.OOColumn);
            }

            public bool IsPREZIMEIIMENull()
            {
                return this.IsNull(this.tableRSMA1.PREZIMEIIMEColumn);
            }

            public bool IsREDNIBROJNull()
            {
                return this.IsNull(this.tableRSMA1.REDNIBROJColumn);
            }

            public bool IsSIFRAGRADARADANull()
            {
                return this.IsNull(this.tableRSMA1.SIFRAGRADARADAColumn);
            }

            public void SetBNull()
            {
                this[this.tableRSMA1.BColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOONull()
            {
                this[this.tableRSMA1.DOOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSISPLACENEPLACERSMBNull()
            {
                this[this.tableRSMA1.IZNOSISPLACENEPLACERSMBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSOBRACUNANEPLACERSMBNull()
            {
                this[this.tableRSMA1.IZNOSOBRACUNANEPLACERSMBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSOSNOVICEZADOPRINOSERSMBNull()
            {
                this[this.tableRSMA1.IZNOSOSNOVICEZADOPRINOSERSMBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMBGOSIGURANIKANull()
            {
                this[this.tableRSMA1.MBGOSIGURANIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMIO1RSMBNull()
            {
                this[this.tableRSMA1.MIO1RSMBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMIO2RSMBNull()
            {
                this[this.tableRSMA1.MIO2RSMBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODNull()
            {
                this[this.tableRSMA1.ODColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOONull()
            {
                this[this.tableRSMA1.OOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMEIIMENull()
            {
                this[this.tableRSMA1.PREZIMEIIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDNIBROJNull()
            {
                this[this.tableRSMA1.REDNIBROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAGRADARADANull()
            {
                this[this.tableRSMA1.SIFRAGRADARADAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string B
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA1.BColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA1.BColumn] = value;
                }
            }

            public string DOO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA1.DOOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA1.DOOColumn] = value;
                }
            }

            public int ID
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRSMA1.IDColumn]);
                }
                set
                {
                    this[this.tableRSMA1.IDColumn] = value;
                }
            }

            public string IDENTIFIKATOROBRASCA
            {
                get
                {
                    return Conversions.ToString(this[this.tableRSMA1.IDENTIFIKATOROBRASCAColumn]);
                }
                set
                {
                    this[this.tableRSMA1.IDENTIFIKATOROBRASCAColumn] = value;
                }
            }

            public decimal IZNOSISPLACENEPLACERSMB
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRSMA1.IZNOSISPLACENEPLACERSMBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRSMA1.IZNOSISPLACENEPLACERSMBColumn] = value;
                }
            }

            public decimal IZNOSOBRACUNANEPLACERSMB
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRSMA1.IZNOSOBRACUNANEPLACERSMBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRSMA1.IZNOSOBRACUNANEPLACERSMBColumn] = value;
                }
            }

            public decimal IZNOSOSNOVICEZADOPRINOSERSMB
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRSMA1.IZNOSOSNOVICEZADOPRINOSERSMBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRSMA1.IZNOSOSNOVICEZADOPRINOSERSMBColumn] = value;
                }
            }

            public string MBGOSIGURANIKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA1.MBGOSIGURANIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA1.MBGOSIGURANIKAColumn] = value;
                }
            }

            public decimal MIO1RSMB
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRSMA1.MIO1RSMBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRSMA1.MIO1RSMBColumn] = value;
                }
            }

            public decimal MIO2RSMB
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRSMA1.MIO2RSMBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRSMA1.MIO2RSMBColumn] = value;
                }
            }

            public string OD
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA1.ODColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA1.ODColumn] = value;
                }
            }

            public string OO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA1.OOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA1.OOColumn] = value;
                }
            }

            public string PREZIMEIIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA1.PREZIMEIIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA1.PREZIMEIIMEColumn] = value;
                }
            }

            public string REDNIBROJ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA1.REDNIBROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA1.REDNIBROJColumn] = value;
                }
            }

            public string SIFRAGRADARADA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA1.SIFRAGRADARADAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA1.SIFRAGRADARADAColumn] = value;
                }
            }
        }

        public class RSMA1RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RSMADataSet.RSMA1Row eventRow;

            public RSMA1RowChangeEvent(RSMADataSet.RSMA1Row row, DataRowAction action)
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

            public RSMADataSet.RSMA1Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RSMA1RowChangeEventHandler(object sender, RSMADataSet.RSMA1RowChangeEvent e);

        [Serializable]
        public class RSMADataTable : DataTable, IEnumerable
        {
            private DataColumn columnADRESA;
            private DataColumn columnBROJOSIGURANIKA;
            private DataColumn columngodinaisplatersm;
            private DataColumn columngodinaobracunarsm;
            private DataColumn columnIDENTIFIKATOROBRASCA;
            private DataColumn columnIDOBRACUN;
            private DataColumn columnIDRSVRSTEOBRACUNA;
            private DataColumn columnIDRSVRSTEOBVEZNIKA;
            private DataColumn columnIZNOSISPLACENEPLACE;
            private DataColumn columnIZNOSOBRACUNANEPLACE;
            private DataColumn columnIZNOSOSNOVICEZADOPRINOSE;
            private DataColumn columnMBGOBVEZNIKA;
            private DataColumn columnMBOBVEZNIKA;
            private DataColumn columnMIO1;
            private DataColumn columnMIO2;
            private DataColumn columnmjesecisplatersm;
            private DataColumn columnmjesecoBRACUNArsm;
            private DataColumn columnNAZIVOBVEZNIKA;
            private DataColumn columnNAZIVRSVRSTEOBRACUNA;
            private DataColumn columnNAZIVRSVRSTEOBVEZNIKA;

            public event RSMADataSet.RSMARowChangeEventHandler RSMARowChanged;

            public event RSMADataSet.RSMARowChangeEventHandler RSMARowChanging;

            public event RSMADataSet.RSMARowChangeEventHandler RSMARowDeleted;

            public event RSMADataSet.RSMARowChangeEventHandler RSMARowDeleting;

            public RSMADataTable()
            {
                this.TableName = "RSMA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RSMADataTable(DataTable table) : base(table.TableName)
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

            protected RSMADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRSMARow(RSMADataSet.RSMARow row)
            {
                this.Rows.Add(row);
            }

            public RSMADataSet.RSMARow AddRSMARow(string iDENTIFIKATOROBRASCA, string iDOBRACUN, string mBOBVEZNIKA, string mBGOBVEZNIKA, string nAZIVOBVEZNIKA, string aDRESA, string iDRSVRSTEOBVEZNIKA, string iDRSVRSTEOBRACUNA, string mjesecoBRACUNArsm, string godinaobracunarsm, string bROJOSIGURANIKA, string mjesecisplatersm, string godinaisplatersm)
            {
                RSMADataSet.RSMARow row = (RSMADataSet.RSMARow) this.NewRow();
                row["IDENTIFIKATOROBRASCA"] = iDENTIFIKATOROBRASCA;
                row["IDOBRACUN"] = iDOBRACUN;
                row["MBOBVEZNIKA"] = mBOBVEZNIKA;
                row["MBGOBVEZNIKA"] = mBGOBVEZNIKA;
                row["NAZIVOBVEZNIKA"] = nAZIVOBVEZNIKA;
                row["ADRESA"] = aDRESA;
                row["IDRSVRSTEOBVEZNIKA"] = iDRSVRSTEOBVEZNIKA;
                row["IDRSVRSTEOBRACUNA"] = iDRSVRSTEOBRACUNA;
                row["mjesecoBRACUNArsm"] = mjesecoBRACUNArsm;
                row["godinaobracunarsm"] = godinaobracunarsm;
                row["BROJOSIGURANIKA"] = bROJOSIGURANIKA;
                row["mjesecisplatersm"] = mjesecisplatersm;
                row["godinaisplatersm"] = godinaisplatersm;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RSMADataSet.RSMADataTable table = (RSMADataSet.RSMADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RSMADataSet.RSMARow FindByIDENTIFIKATOROBRASCA(string iDENTIFIKATOROBRASCA)
            {
                return (RSMADataSet.RSMARow) this.Rows.Find(new object[] { iDENTIFIKATOROBRASCA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RSMADataSet.RSMARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RSMADataSet set = new RSMADataSet();
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
                this.columnIDENTIFIKATOROBRASCA = new DataColumn("IDENTIFIKATOROBRASCA", typeof(string), "", MappingType.Element);
                this.columnIDENTIFIKATOROBRASCA.AllowDBNull = false;
                this.columnIDENTIFIKATOROBRASCA.Caption = "IDENTIFIKATOROBRASCA";
                this.columnIDENTIFIKATOROBRASCA.MaxLength = 4;
                this.columnIDENTIFIKATOROBRASCA.Unique = true;
                this.columnIDENTIFIKATOROBRASCA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Description", "IDENTIFIKATOROBRASCA");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Length", "4");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.InternalName", "IDENTIFIKATOROBRASCA");
                this.Columns.Add(this.columnIDENTIFIKATOROBRASCA);
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.AllowDBNull = true;
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "false");
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
                this.columnMBOBVEZNIKA = new DataColumn("MBOBVEZNIKA", typeof(string), "", MappingType.Element);
                this.columnMBOBVEZNIKA.AllowDBNull = false;
                this.columnMBOBVEZNIKA.Caption = "MBOBVEZNIKA";
                this.columnMBOBVEZNIKA.MaxLength = 13;
                this.columnMBOBVEZNIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("Description", "MBOBVEZNIKA");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("Length", "13");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMBOBVEZNIKA.ExtendedProperties.Add("Deklarit.InternalName", "MBOBVEZNIKA");
                this.Columns.Add(this.columnMBOBVEZNIKA);
                this.columnMBGOBVEZNIKA = new DataColumn("MBGOBVEZNIKA", typeof(string), "", MappingType.Element);
                this.columnMBGOBVEZNIKA.AllowDBNull = false;
                this.columnMBGOBVEZNIKA.Caption = "MBGOBVEZNIKA";
                this.columnMBGOBVEZNIKA.MaxLength = 13;
                this.columnMBGOBVEZNIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("Description", "MBGOBVEZNIKA");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("Length", "13");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMBGOBVEZNIKA.ExtendedProperties.Add("Deklarit.InternalName", "MBGOBVEZNIKA");
                this.Columns.Add(this.columnMBGOBVEZNIKA);
                this.columnNAZIVOBVEZNIKA = new DataColumn("NAZIVOBVEZNIKA", typeof(string), "", MappingType.Element);
                this.columnNAZIVOBVEZNIKA.AllowDBNull = false;
                this.columnNAZIVOBVEZNIKA.Caption = "NAZIVOBVEZNIKA";
                this.columnNAZIVOBVEZNIKA.MaxLength = 50;
                this.columnNAZIVOBVEZNIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("Description", "NAZIVOBVEZNIKA");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOBVEZNIKA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOBVEZNIKA");
                this.Columns.Add(this.columnNAZIVOBVEZNIKA);
                this.columnADRESA = new DataColumn("ADRESA", typeof(string), "", MappingType.Element);
                this.columnADRESA.AllowDBNull = false;
                this.columnADRESA.Caption = "Adresa";
                this.columnADRESA.MaxLength = 150;
                this.columnADRESA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnADRESA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnADRESA.ExtendedProperties.Add("IsKey", "false");
                this.columnADRESA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnADRESA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnADRESA.ExtendedProperties.Add("Description", "Adresa");
                this.columnADRESA.ExtendedProperties.Add("Length", "150");
                this.columnADRESA.ExtendedProperties.Add("Decimals", "0");
                this.columnADRESA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnADRESA.ExtendedProperties.Add("IsInReader", "true");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.InternalName", "ADRESA");
                this.Columns.Add(this.columnADRESA);
                this.columnIDRSVRSTEOBVEZNIKA = new DataColumn("IDRSVRSTEOBVEZNIKA", typeof(string), "", MappingType.Element);
                this.columnIDRSVRSTEOBVEZNIKA.AllowDBNull = false;
                this.columnIDRSVRSTEOBVEZNIKA.Caption = "Šifra vrste obveznika";
                this.columnIDRSVRSTEOBVEZNIKA.MaxLength = 2;
                this.columnIDRSVRSTEOBVEZNIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Description", "Šifra vrste obveznika");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Length", "2");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.InternalName", "IDRSVRSTEOBVEZNIKA");
                this.Columns.Add(this.columnIDRSVRSTEOBVEZNIKA);
                this.columnNAZIVRSVRSTEOBVEZNIKA = new DataColumn("NAZIVRSVRSTEOBVEZNIKA", typeof(string), "", MappingType.Element);
                this.columnNAZIVRSVRSTEOBVEZNIKA.AllowDBNull = true;
                this.columnNAZIVRSVRSTEOBVEZNIKA.Caption = "Naziv vrste obveznika";
                this.columnNAZIVRSVRSTEOBVEZNIKA.MaxLength = 100;
                this.columnNAZIVRSVRSTEOBVEZNIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Description", "Naziv vrste obveznika");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVRSVRSTEOBVEZNIKA");
                this.Columns.Add(this.columnNAZIVRSVRSTEOBVEZNIKA);
                this.columnIDRSVRSTEOBRACUNA = new DataColumn("IDRSVRSTEOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnIDRSVRSTEOBRACUNA.AllowDBNull = false;
                this.columnIDRSVRSTEOBRACUNA.Caption = "Šifra vrste obraeuna";
                this.columnIDRSVRSTEOBRACUNA.MaxLength = 2;
                this.columnIDRSVRSTEOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Description", "Šifra vrste obraeuna");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Length", "2");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "IDRSVRSTEOBRACUNA");
                this.Columns.Add(this.columnIDRSVRSTEOBRACUNA);
                this.columnNAZIVRSVRSTEOBRACUNA = new DataColumn("NAZIVRSVRSTEOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnNAZIVRSVRSTEOBRACUNA.AllowDBNull = true;
                this.columnNAZIVRSVRSTEOBRACUNA.Caption = "Naziv vrste obraeuna";
                this.columnNAZIVRSVRSTEOBRACUNA.MaxLength = 100;
                this.columnNAZIVRSVRSTEOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Description", "Naziv vrste obraeuna");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVRSVRSTEOBRACUNA");
                this.Columns.Add(this.columnNAZIVRSVRSTEOBRACUNA);
                this.columnmjesecoBRACUNArsm = new DataColumn("mjesecoBRACUNArsm", typeof(string), "", MappingType.Element);
                this.columnmjesecoBRACUNArsm.AllowDBNull = false;
                this.columnmjesecoBRACUNArsm.Caption = "mjeseco BRACUN Arsm";
                this.columnmjesecoBRACUNArsm.MaxLength = 2;
                this.columnmjesecoBRACUNArsm.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("IsKey", "false");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("ReadOnly", "false");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("Description", "mjeseco BRACUN Arsm");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("Length", "2");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("Decimals", "0");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("IsInReader", "true");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmjesecoBRACUNArsm.ExtendedProperties.Add("Deklarit.InternalName", "mjesecoBRACUNArsm");
                this.Columns.Add(this.columnmjesecoBRACUNArsm);
                this.columngodinaobracunarsm = new DataColumn("godinaobracunarsm", typeof(string), "", MappingType.Element);
                this.columngodinaobracunarsm.AllowDBNull = false;
                this.columngodinaobracunarsm.Caption = "godinaobracunarsm";
                this.columngodinaobracunarsm.MaxLength = 5;
                this.columngodinaobracunarsm.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columngodinaobracunarsm.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columngodinaobracunarsm.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columngodinaobracunarsm.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columngodinaobracunarsm.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columngodinaobracunarsm.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columngodinaobracunarsm.ExtendedProperties.Add("IsKey", "false");
                this.columngodinaobracunarsm.ExtendedProperties.Add("ReadOnly", "false");
                this.columngodinaobracunarsm.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columngodinaobracunarsm.ExtendedProperties.Add("Description", "godinaobracunarsm");
                this.columngodinaobracunarsm.ExtendedProperties.Add("Length", "5");
                this.columngodinaobracunarsm.ExtendedProperties.Add("Decimals", "0");
                this.columngodinaobracunarsm.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columngodinaobracunarsm.ExtendedProperties.Add("IsInReader", "true");
                this.columngodinaobracunarsm.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columngodinaobracunarsm.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columngodinaobracunarsm.ExtendedProperties.Add("Deklarit.InternalName", "godinaobracunarsm");
                this.Columns.Add(this.columngodinaobracunarsm);
                this.columnBROJOSIGURANIKA = new DataColumn("BROJOSIGURANIKA", typeof(string), "", MappingType.Element);
                this.columnBROJOSIGURANIKA.AllowDBNull = false;
                this.columnBROJOSIGURANIKA.Caption = "BROJOSIGURANIKA";
                this.columnBROJOSIGURANIKA.MaxLength = 5;
                this.columnBROJOSIGURANIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("Description", "BROJOSIGURANIKA");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("Length", "5");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJOSIGURANIKA.ExtendedProperties.Add("Deklarit.InternalName", "BROJOSIGURANIKA");
                this.Columns.Add(this.columnBROJOSIGURANIKA);
                this.columnIZNOSOBRACUNANEPLACE = new DataColumn("IZNOSOBRACUNANEPLACE", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSOBRACUNANEPLACE.AllowDBNull = true;
                this.columnIZNOSOBRACUNANEPLACE.Caption = "IZNOSOBRACUNANEPLACE";
                this.columnIZNOSOBRACUNANEPLACE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("Description", "IZNOSOBRACUNANEPLACE");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSOBRACUNANEPLACE");
                this.columnIZNOSOBRACUNANEPLACE.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnIZNOSOBRACUNANEPLACE);
                this.columnIZNOSOSNOVICEZADOPRINOSE = new DataColumn("IZNOSOSNOVICEZADOPRINOSE", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSOSNOVICEZADOPRINOSE.AllowDBNull = true;
                this.columnIZNOSOSNOVICEZADOPRINOSE.Caption = "IZNOSOSNOVICEZADOPRINOSE";
                this.columnIZNOSOSNOVICEZADOPRINOSE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("Description", "IZNOSOSNOVICEZADOPRINOSE");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSOSNOVICEZADOPRINOSE");
                this.columnIZNOSOSNOVICEZADOPRINOSE.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnIZNOSOSNOVICEZADOPRINOSE);
                this.columnMIO1 = new DataColumn("MIO1", typeof(decimal), "", MappingType.Element);
                this.columnMIO1.AllowDBNull = true;
                this.columnMIO1.Caption = "MI O1";
                this.columnMIO1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMIO1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMIO1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMIO1.ExtendedProperties.Add("IsKey", "false");
                this.columnMIO1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMIO1.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMIO1.ExtendedProperties.Add("Description", "MI O1");
                this.columnMIO1.ExtendedProperties.Add("Length", "12");
                this.columnMIO1.ExtendedProperties.Add("Decimals", "2");
                this.columnMIO1.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMIO1.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMIO1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMIO1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMIO1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMIO1.ExtendedProperties.Add("Deklarit.InternalName", "MIO1");
                this.columnMIO1.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnMIO1);
                this.columnMIO2 = new DataColumn("MIO2", typeof(decimal), "", MappingType.Element);
                this.columnMIO2.AllowDBNull = true;
                this.columnMIO2.Caption = "MI O2";
                this.columnMIO2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMIO2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMIO2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMIO2.ExtendedProperties.Add("IsKey", "false");
                this.columnMIO2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMIO2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMIO2.ExtendedProperties.Add("Description", "MI O2");
                this.columnMIO2.ExtendedProperties.Add("Length", "12");
                this.columnMIO2.ExtendedProperties.Add("Decimals", "2");
                this.columnMIO2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMIO2.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMIO2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMIO2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMIO2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMIO2.ExtendedProperties.Add("Deklarit.InternalName", "MIO2");
                this.columnMIO2.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnMIO2);
                this.columnIZNOSISPLACENEPLACE = new DataColumn("IZNOSISPLACENEPLACE", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSISPLACENEPLACE.AllowDBNull = true;
                this.columnIZNOSISPLACENEPLACE.Caption = "IZNOSISPLACENEPLACE";
                this.columnIZNOSISPLACENEPLACE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("Description", "IZNOSISPLACENEPLACE");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSISPLACENEPLACE");
                this.columnIZNOSISPLACENEPLACE.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnIZNOSISPLACENEPLACE);
                this.columnmjesecisplatersm = new DataColumn("mjesecisplatersm", typeof(string), "", MappingType.Element);
                this.columnmjesecisplatersm.AllowDBNull = false;
                this.columnmjesecisplatersm.Caption = "mjesecisplatersm";
                this.columnmjesecisplatersm.MaxLength = 2;
                this.columnmjesecisplatersm.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmjesecisplatersm.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmjesecisplatersm.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmjesecisplatersm.ExtendedProperties.Add("IsKey", "false");
                this.columnmjesecisplatersm.ExtendedProperties.Add("ReadOnly", "false");
                this.columnmjesecisplatersm.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnmjesecisplatersm.ExtendedProperties.Add("Description", "mjesecisplatersm");
                this.columnmjesecisplatersm.ExtendedProperties.Add("Length", "2");
                this.columnmjesecisplatersm.ExtendedProperties.Add("Decimals", "0");
                this.columnmjesecisplatersm.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnmjesecisplatersm.ExtendedProperties.Add("IsInReader", "true");
                this.columnmjesecisplatersm.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmjesecisplatersm.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmjesecisplatersm.ExtendedProperties.Add("Deklarit.InternalName", "mjesecisplatersm");
                this.Columns.Add(this.columnmjesecisplatersm);
                this.columngodinaisplatersm = new DataColumn("godinaisplatersm", typeof(string), "", MappingType.Element);
                this.columngodinaisplatersm.AllowDBNull = false;
                this.columngodinaisplatersm.Caption = "godinaisplatersm";
                this.columngodinaisplatersm.MaxLength = 5;
                this.columngodinaisplatersm.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columngodinaisplatersm.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columngodinaisplatersm.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columngodinaisplatersm.ExtendedProperties.Add("IsKey", "false");
                this.columngodinaisplatersm.ExtendedProperties.Add("ReadOnly", "false");
                this.columngodinaisplatersm.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columngodinaisplatersm.ExtendedProperties.Add("Description", "godinaisplatersm");
                this.columngodinaisplatersm.ExtendedProperties.Add("Length", "5");
                this.columngodinaisplatersm.ExtendedProperties.Add("Decimals", "0");
                this.columngodinaisplatersm.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columngodinaisplatersm.ExtendedProperties.Add("IsInReader", "true");
                this.columngodinaisplatersm.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columngodinaisplatersm.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columngodinaisplatersm.ExtendedProperties.Add("Deklarit.InternalName", "godinaisplatersm");
                this.Columns.Add(this.columngodinaisplatersm);
                this.PrimaryKey = new DataColumn[] { this.columnIDENTIFIKATOROBRASCA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RSMA");
                this.ExtendedProperties.Add("Description", "RSMA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDENTIFIKATOROBRASCA = this.Columns["IDENTIFIKATOROBRASCA"];
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
                this.columnMBOBVEZNIKA = this.Columns["MBOBVEZNIKA"];
                this.columnMBGOBVEZNIKA = this.Columns["MBGOBVEZNIKA"];
                this.columnNAZIVOBVEZNIKA = this.Columns["NAZIVOBVEZNIKA"];
                this.columnADRESA = this.Columns["ADRESA"];
                this.columnIDRSVRSTEOBVEZNIKA = this.Columns["IDRSVRSTEOBVEZNIKA"];
                this.columnNAZIVRSVRSTEOBVEZNIKA = this.Columns["NAZIVRSVRSTEOBVEZNIKA"];
                this.columnIDRSVRSTEOBRACUNA = this.Columns["IDRSVRSTEOBRACUNA"];
                this.columnNAZIVRSVRSTEOBRACUNA = this.Columns["NAZIVRSVRSTEOBRACUNA"];
                this.columnmjesecoBRACUNArsm = this.Columns["mjesecoBRACUNArsm"];
                this.columngodinaobracunarsm = this.Columns["godinaobracunarsm"];
                this.columnBROJOSIGURANIKA = this.Columns["BROJOSIGURANIKA"];
                this.columnIZNOSOBRACUNANEPLACE = this.Columns["IZNOSOBRACUNANEPLACE"];
                this.columnIZNOSOSNOVICEZADOPRINOSE = this.Columns["IZNOSOSNOVICEZADOPRINOSE"];
                this.columnMIO1 = this.Columns["MIO1"];
                this.columnMIO2 = this.Columns["MIO2"];
                this.columnIZNOSISPLACENEPLACE = this.Columns["IZNOSISPLACENEPLACE"];
                this.columnmjesecisplatersm = this.Columns["mjesecisplatersm"];
                this.columngodinaisplatersm = this.Columns["godinaisplatersm"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RSMADataSet.RSMARow(builder);
            }

            public RSMADataSet.RSMARow NewRSMARow()
            {
                return (RSMADataSet.RSMARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RSMARowChanged != null)
                {
                    RSMADataSet.RSMARowChangeEventHandler rSMARowChangedEvent = this.RSMARowChanged;
                    if (rSMARowChangedEvent != null)
                    {
                        rSMARowChangedEvent(this, new RSMADataSet.RSMARowChangeEvent((RSMADataSet.RSMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RSMARowChanging != null)
                {
                    RSMADataSet.RSMARowChangeEventHandler rSMARowChangingEvent = this.RSMARowChanging;
                    if (rSMARowChangingEvent != null)
                    {
                        rSMARowChangingEvent(this, new RSMADataSet.RSMARowChangeEvent((RSMADataSet.RSMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RSMARowDeleted != null)
                {
                    RSMADataSet.RSMARowChangeEventHandler rSMARowDeletedEvent = this.RSMARowDeleted;
                    if (rSMARowDeletedEvent != null)
                    {
                        rSMARowDeletedEvent(this, new RSMADataSet.RSMARowChangeEvent((RSMADataSet.RSMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RSMARowDeleting != null)
                {
                    RSMADataSet.RSMARowChangeEventHandler rSMARowDeletingEvent = this.RSMARowDeleting;
                    if (rSMARowDeletingEvent != null)
                    {
                        rSMARowDeletingEvent(this, new RSMADataSet.RSMARowChangeEvent((RSMADataSet.RSMARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRSMARow(RSMADataSet.RSMARow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn ADRESAColumn
            {
                get
                {
                    return this.columnADRESA;
                }
            }

            public DataColumn BROJOSIGURANIKAColumn
            {
                get
                {
                    return this.columnBROJOSIGURANIKA;
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

            public DataColumn godinaisplatersmColumn
            {
                get
                {
                    return this.columngodinaisplatersm;
                }
            }

            public DataColumn godinaobracunarsmColumn
            {
                get
                {
                    return this.columngodinaobracunarsm;
                }
            }

            public DataColumn IDENTIFIKATOROBRASCAColumn
            {
                get
                {
                    return this.columnIDENTIFIKATOROBRASCA;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public DataColumn IDRSVRSTEOBRACUNAColumn
            {
                get
                {
                    return this.columnIDRSVRSTEOBRACUNA;
                }
            }

            public DataColumn IDRSVRSTEOBVEZNIKAColumn
            {
                get
                {
                    return this.columnIDRSVRSTEOBVEZNIKA;
                }
            }

            public RSMADataSet.RSMARow this[int index]
            {
                get
                {
                    return (RSMADataSet.RSMARow) this.Rows[index];
                }
            }

            public DataColumn IZNOSISPLACENEPLACEColumn
            {
                get
                {
                    return this.columnIZNOSISPLACENEPLACE;
                }
            }

            public DataColumn IZNOSOBRACUNANEPLACEColumn
            {
                get
                {
                    return this.columnIZNOSOBRACUNANEPLACE;
                }
            }

            public DataColumn IZNOSOSNOVICEZADOPRINOSEColumn
            {
                get
                {
                    return this.columnIZNOSOSNOVICEZADOPRINOSE;
                }
            }

            public DataColumn MBGOBVEZNIKAColumn
            {
                get
                {
                    return this.columnMBGOBVEZNIKA;
                }
            }

            public DataColumn MBOBVEZNIKAColumn
            {
                get
                {
                    return this.columnMBOBVEZNIKA;
                }
            }

            public DataColumn MIO1Column
            {
                get
                {
                    return this.columnMIO1;
                }
            }

            public DataColumn MIO2Column
            {
                get
                {
                    return this.columnMIO2;
                }
            }

            public DataColumn mjesecisplatersmColumn
            {
                get
                {
                    return this.columnmjesecisplatersm;
                }
            }

            public DataColumn mjesecoBRACUNArsmColumn
            {
                get
                {
                    return this.columnmjesecoBRACUNArsm;
                }
            }

            public DataColumn NAZIVOBVEZNIKAColumn
            {
                get
                {
                    return this.columnNAZIVOBVEZNIKA;
                }
            }

            public DataColumn NAZIVRSVRSTEOBRACUNAColumn
            {
                get
                {
                    return this.columnNAZIVRSVRSTEOBRACUNA;
                }
            }

            public DataColumn NAZIVRSVRSTEOBVEZNIKAColumn
            {
                get
                {
                    return this.columnNAZIVRSVRSTEOBVEZNIKA;
                }
            }
        }

        public class RSMARow : DataRow
        {
            private RSMADataSet.RSMADataTable tableRSMA;

            internal RSMARow(DataRowBuilder rb) : base(rb)
            {
                this.tableRSMA = (RSMADataSet.RSMADataTable) this.Table;
            }

            public RSMADataSet.RSMA1Row[] GetRSMA1Rows()
            {
                return (RSMADataSet.RSMA1Row[]) this.GetChildRows("RSMA_RSMA1");
            }

            public bool IsADRESANull()
            {
                return this.IsNull(this.tableRSMA.ADRESAColumn);
            }

            public bool IsBROJOSIGURANIKANull()
            {
                return this.IsNull(this.tableRSMA.BROJOSIGURANIKAColumn);
            }

            public bool IsgodinaisplatersmNull()
            {
                return this.IsNull(this.tableRSMA.godinaisplatersmColumn);
            }

            public bool IsgodinaobracunarsmNull()
            {
                return this.IsNull(this.tableRSMA.godinaobracunarsmColumn);
            }

            public bool IsIDENTIFIKATOROBRASCANull()
            {
                return this.IsNull(this.tableRSMA.IDENTIFIKATOROBRASCAColumn);
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tableRSMA.IDOBRACUNColumn);
            }

            public bool IsIDRSVRSTEOBRACUNANull()
            {
                return this.IsNull(this.tableRSMA.IDRSVRSTEOBRACUNAColumn);
            }

            public bool IsIDRSVRSTEOBVEZNIKANull()
            {
                return this.IsNull(this.tableRSMA.IDRSVRSTEOBVEZNIKAColumn);
            }

            public bool IsIZNOSISPLACENEPLACENull()
            {
                return this.IsNull(this.tableRSMA.IZNOSISPLACENEPLACEColumn);
            }

            public bool IsIZNOSOBRACUNANEPLACENull()
            {
                return this.IsNull(this.tableRSMA.IZNOSOBRACUNANEPLACEColumn);
            }

            public bool IsIZNOSOSNOVICEZADOPRINOSENull()
            {
                return this.IsNull(this.tableRSMA.IZNOSOSNOVICEZADOPRINOSEColumn);
            }

            public bool IsMBGOBVEZNIKANull()
            {
                return this.IsNull(this.tableRSMA.MBGOBVEZNIKAColumn);
            }

            public bool IsMBOBVEZNIKANull()
            {
                return this.IsNull(this.tableRSMA.MBOBVEZNIKAColumn);
            }

            public bool IsMIO1Null()
            {
                return this.IsNull(this.tableRSMA.MIO1Column);
            }

            public bool IsMIO2Null()
            {
                return this.IsNull(this.tableRSMA.MIO2Column);
            }

            public bool IsmjesecisplatersmNull()
            {
                return this.IsNull(this.tableRSMA.mjesecisplatersmColumn);
            }

            public bool IsmjesecoBRACUNArsmNull()
            {
                return this.IsNull(this.tableRSMA.mjesecoBRACUNArsmColumn);
            }

            public bool IsNAZIVOBVEZNIKANull()
            {
                return this.IsNull(this.tableRSMA.NAZIVOBVEZNIKAColumn);
            }

            public bool IsNAZIVRSVRSTEOBRACUNANull()
            {
                return this.IsNull(this.tableRSMA.NAZIVRSVRSTEOBRACUNAColumn);
            }

            public bool IsNAZIVRSVRSTEOBVEZNIKANull()
            {
                return this.IsNull(this.tableRSMA.NAZIVRSVRSTEOBVEZNIKAColumn);
            }

            public void SetADRESANull()
            {
                this[this.tableRSMA.ADRESAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJOSIGURANIKANull()
            {
                this[this.tableRSMA.BROJOSIGURANIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetgodinaisplatersmNull()
            {
                this[this.tableRSMA.godinaisplatersmColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetgodinaobracunarsmNull()
            {
                this[this.tableRSMA.godinaobracunarsmColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDOBRACUNNull()
            {
                this[this.tableRSMA.IDOBRACUNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRSVRSTEOBRACUNANull()
            {
                this[this.tableRSMA.IDRSVRSTEOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRSVRSTEOBVEZNIKANull()
            {
                this[this.tableRSMA.IDRSVRSTEOBVEZNIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSISPLACENEPLACENull()
            {
                this[this.tableRSMA.IZNOSISPLACENEPLACEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSOBRACUNANEPLACENull()
            {
                this[this.tableRSMA.IZNOSOBRACUNANEPLACEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSOSNOVICEZADOPRINOSENull()
            {
                this[this.tableRSMA.IZNOSOSNOVICEZADOPRINOSEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMBGOBVEZNIKANull()
            {
                this[this.tableRSMA.MBGOBVEZNIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMBOBVEZNIKANull()
            {
                this[this.tableRSMA.MBOBVEZNIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMIO1Null()
            {
                this[this.tableRSMA.MIO1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMIO2Null()
            {
                this[this.tableRSMA.MIO2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetmjesecisplatersmNull()
            {
                this[this.tableRSMA.mjesecisplatersmColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetmjesecoBRACUNArsmNull()
            {
                this[this.tableRSMA.mjesecoBRACUNArsmColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOBVEZNIKANull()
            {
                this[this.tableRSMA.NAZIVOBVEZNIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVRSVRSTEOBRACUNANull()
            {
                this[this.tableRSMA.NAZIVRSVRSTEOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVRSVRSTEOBVEZNIKANull()
            {
                this[this.tableRSMA.NAZIVRSVRSTEOBVEZNIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string ADRESA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.ADRESAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.ADRESAColumn] = value;
                }
            }

            public string BROJOSIGURANIKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.BROJOSIGURANIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.BROJOSIGURANIKAColumn] = value;
                }
            }

            public string godinaisplatersm
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.godinaisplatersmColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.godinaisplatersmColumn] = value;
                }
            }

            public string godinaobracunarsm
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.godinaobracunarsmColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.godinaobracunarsmColumn] = value;
                }
            }

            public string IDENTIFIKATOROBRASCA
            {
                get
                {
                    return Conversions.ToString(this[this.tableRSMA.IDENTIFIKATOROBRASCAColumn]);
                }
                set
                {
                    this[this.tableRSMA.IDENTIFIKATOROBRASCAColumn] = value;
                }
            }

            public string IDOBRACUN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.IDOBRACUNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.IDOBRACUNColumn] = value;
                }
            }

            public string IDRSVRSTEOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.IDRSVRSTEOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.IDRSVRSTEOBRACUNAColumn] = value;
                }
            }

            public string IDRSVRSTEOBVEZNIKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.IDRSVRSTEOBVEZNIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.IDRSVRSTEOBVEZNIKAColumn] = value;
                }
            }

            public decimal IZNOSISPLACENEPLACE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRSMA.IZNOSISPLACENEPLACEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRSMA.IZNOSISPLACENEPLACEColumn] = value;
                }
            }

            public decimal IZNOSOBRACUNANEPLACE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRSMA.IZNOSOBRACUNANEPLACEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRSMA.IZNOSOBRACUNANEPLACEColumn] = value;
                }
            }

            public decimal IZNOSOSNOVICEZADOPRINOSE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRSMA.IZNOSOSNOVICEZADOPRINOSEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRSMA.IZNOSOSNOVICEZADOPRINOSEColumn] = value;
                }
            }

            public string MBGOBVEZNIKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.MBGOBVEZNIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.MBGOBVEZNIKAColumn] = value;
                }
            }

            public string MBOBVEZNIKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.MBOBVEZNIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.MBOBVEZNIKAColumn] = value;
                }
            }

            public decimal MIO1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRSMA.MIO1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRSMA.MIO1Column] = value;
                }
            }

            public decimal MIO2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRSMA.MIO2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRSMA.MIO2Column] = value;
                }
            }

            public string mjesecisplatersm
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.mjesecisplatersmColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.mjesecisplatersmColumn] = value;
                }
            }

            public string mjesecoBRACUNArsm
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.mjesecoBRACUNArsmColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.mjesecoBRACUNArsmColumn] = value;
                }
            }

            public string NAZIVOBVEZNIKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.NAZIVOBVEZNIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.NAZIVOBVEZNIKAColumn] = value;
                }
            }

            public string NAZIVRSVRSTEOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.NAZIVRSVRSTEOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.NAZIVRSVRSTEOBRACUNAColumn] = value;
                }
            }

            public string NAZIVRSVRSTEOBVEZNIKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSMA.NAZIVRSVRSTEOBVEZNIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSMA.NAZIVRSVRSTEOBVEZNIKAColumn] = value;
                }
            }
        }

        public class RSMARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RSMADataSet.RSMARow eventRow;

            public RSMARowChangeEvent(RSMADataSet.RSMARow row, DataRowAction action)
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

            public RSMADataSet.RSMARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RSMARowChangeEventHandler(object sender, RSMADataSet.RSMARowChangeEvent e);
    }
}

