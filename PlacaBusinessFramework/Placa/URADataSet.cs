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
    public class URADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private URADataTable tableURA;

        public URADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected URADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["URA"] != null)
                    {
                        this.Tables.Add(new URADataTable(dataSet.Tables["URA"]));
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
            URADataSet set = (URADataSet) base.Clone();
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
            URADataSet set = new URADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "URADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2036");
            this.ExtendedProperties.Add("DataSetName", "URADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IURADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "URA");
            this.ExtendedProperties.Add("ObjectDescription", "URA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Finpos");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "URADataSet";
            this.Namespace = "http://www.tempuri.org/URA";
            this.tableURA = new URADataTable();
            this.Tables.Add(this.tableURA);
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
            this.tableURA = (URADataTable) this.Tables["URA"];
            if (initTable && (this.tableURA != null))
            {
                this.tableURA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["URA"] != null)
                {
                    this.Tables.Add(new URADataTable(dataSet.Tables["URA"]));
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

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        private bool ShouldSerializeURA()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public URADataTable URA
        {
            get
            {
                return this.tableURA;
            }
        }

        [Serializable]
        public class URADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDTIPURA;
            private DataColumn columnOSNOVICA0;
            private DataColumn columnOSNOVICA5;
            private DataColumn columnOSNOVICA5NE;
            private DataColumn columnOSNOVICA10;
            private DataColumn columnOSNOVICA10NE;
            private DataColumn columnOSNOVICA22;
            private DataColumn columnOSNOVICA22NE;
            private DataColumn columnOSNOVICA23;
            private DataColumn columnOSNOVICA23NE;
            private DataColumn columnOSNOVICA25;
            private DataColumn columnOSNOVICA25NE;
            private DataColumn columnPDV5DA;
            private DataColumn columnPDV5NE;
            private DataColumn columnPDV10DA;
            private DataColumn columnPDV10NE;
            private DataColumn columnPDV22DA;
            private DataColumn columnPDV22NE;
            private DataColumn columnPDV23DA;
            private DataColumn columnPDV23NE;
            private DataColumn columnPDV25DA;
            private DataColumn columnPDV25NE;
            private DataColumn columnR2;
            private DataColumn columnURABROJ;
            private DataColumn columnURABROJRACUNADOBAVLJACA;
            private DataColumn columnURADATUM;
            private DataColumn columnURADOKIDDOKUMENT;
            private DataColumn columnURAGODIDGODINE;
            private DataColumn columnURAMODEL;
            private DataColumn columnURANAPOMENA;
            private DataColumn columnurapartnerIDPARTNER;
            private DataColumn columnURAPOZIVNABROJ;
            private DataColumn columnURAUKUPNO;
            private DataColumn columnURAVALUTA;

            #region MBS.Complete 26.04.2016
            private DataColumn columnOsnovicaPPO;
            private DataColumn columnMozePPO;
            private DataColumn columnNeMozePPO;
            #endregion

            public event URADataSet.URARowChangeEventHandler URARowChanged;

            public event URADataSet.URARowChangeEventHandler URARowChanging;

            public event URADataSet.URARowChangeEventHandler URARowDeleted;

            public event URADataSet.URARowChangeEventHandler URARowDeleting;

            public URADataTable()
            {
                this.TableName = "URA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal URADataTable(DataTable table) : base(table.TableName)
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

            protected URADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddURARow(URADataSet.URARow row)
            {
                this.Rows.Add(row);
            }

            public URADataSet.URARow AddURARow(short uRAGODIDGODINE, int uRADOKIDDOKUMENT, int uRABROJ, int urapartnerIDPARTNER, int iDTIPURA, string uRABROJRACUNADOBAVLJACA, 
                DateTime uRADATUM, DateTime uRAVALUTA, string uRANAPOMENA, string uRAMODEL, string uRAPOZIVNABROJ, decimal uRAUKUPNO,
                decimal oSNOVICA0, decimal oSNOVICA5, decimal oSNOVICA10, decimal oSNOVICA22, decimal oSNOVICA23, decimal oSNOVICA25, decimal oSNOVICA5NE, decimal oSNOVICA10NE, decimal oSNOVICA22NE, decimal oSNOVICA23NE, decimal oSNOVICA25NE,
                decimal pDV5DA, decimal pDV5NE, decimal pDV10DA, decimal pDV10NE, decimal pDV22DA, decimal pDV22NE, decimal pDV23DA, decimal pDV23NE, decimal pDV25DA, decimal pDV25NE, bool r2,
                decimal OsnovicaPPO, decimal MozePPO, decimal NeMozePPO)
            {
                URADataSet.URARow row = (URADataSet.URARow) this.NewRow();
                row["URAGODIDGODINE"] = uRAGODIDGODINE;
                row["URADOKIDDOKUMENT"] = uRADOKIDDOKUMENT;
                row["URABROJ"] = uRABROJ;
                row["urapartnerIDPARTNER"] = urapartnerIDPARTNER;
                row["IDTIPURA"] = iDTIPURA;
                row["URABROJRACUNADOBAVLJACA"] = uRABROJRACUNADOBAVLJACA;
                row["URADATUM"] = uRADATUM;
                row["URAVALUTA"] = uRAVALUTA;
                row["URANAPOMENA"] = uRANAPOMENA;
                row["URAMODEL"] = uRAMODEL;
                row["URAPOZIVNABROJ"] = uRAPOZIVNABROJ;
                row["URAUKUPNO"] = uRAUKUPNO;
                row["OSNOVICA0"] = oSNOVICA0;
                row["OSNOVICA5"] = oSNOVICA5;
                row["OSNOVICA10"] = oSNOVICA10;
                row["OSNOVICA22"] = oSNOVICA22;
                row["OSNOVICA23"] = oSNOVICA23;
                row["OSNOVICA25"] = oSNOVICA25;
                row["OSNOVICA5NE"] = oSNOVICA5NE;
                row["OSNOVICA10NE"] = oSNOVICA10NE;
                row["OSNOVICA22NE"] = oSNOVICA22NE;
                row["OSNOVICA23NE"] = oSNOVICA23NE;
                row["OSNOVICA25NE"] = oSNOVICA25NE;
                row["PDV5DA"] = pDV5DA;
                row["PDV5NE"] = pDV5NE;
                row["PDV10DA"] = pDV10DA;
                row["PDV10NE"] = pDV10NE;
                row["PDV22DA"] = pDV22DA;
                row["PDV22NE"] = pDV22NE;
                row["PDV23DA"] = pDV23DA;
                row["PDV23NE"] = pDV23NE;
                row["PDV25DA"] = pDV25DA;
                row["PDV25NE"] = pDV25NE;
                row["R2"] = r2;

                #region MBS.Complete 26.04.2016
                row["OsnovicaPPO"] = OsnovicaPPO;
                row["MozePPO"] = MozePPO;
                row["NeMozePPO"] = NeMozePPO;
                #endregion

                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                URADataSet.URADataTable table = (URADataSet.URADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public URADataSet.URARow FindByURAGODIDGODINEURADOKIDDOKUMENTURABROJ(short uRAGODIDGODINE, int uRADOKIDDOKUMENT, int uRABROJ)
            {
                return (URADataSet.URARow) this.Rows.Find(new object[] { uRAGODIDGODINE, uRADOKIDDOKUMENT, uRABROJ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(URADataSet.URARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                URADataSet set = new URADataSet();
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
                this.columnURAGODIDGODINE = new DataColumn("URAGODIDGODINE", typeof(short), "", MappingType.Element);
                this.columnURAGODIDGODINE.AllowDBNull = false;
                this.columnURAGODIDGODINE.Caption = "IDGODINE";
                this.columnURAGODIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("SuperType", "IDGODINE");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("SubtypeGroup", "URAGOD");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("IsKey", "true");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Description", "Godina");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "URAGODIDGODINE");
                this.Columns.Add(this.columnURAGODIDGODINE);
                this.columnURADOKIDDOKUMENT = new DataColumn("URADOKIDDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnURADOKIDDOKUMENT.AllowDBNull = false;
                this.columnURADOKIDDOKUMENT.Caption = "IDDOKUMENT";
                this.columnURADOKIDDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("SuperType", "IDDOKUMENT");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("SubtypeGroup", "URADOK");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Description", "Dokument");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Length", "8");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "URADOKIDDOKUMENT");
                this.Columns.Add(this.columnURADOKIDDOKUMENT);
                this.columnURABROJ = new DataColumn("URABROJ", typeof(int), "", MappingType.Element);
                this.columnURABROJ.AllowDBNull = false;
                this.columnURABROJ.Caption = "URABROJ";
                this.columnURABROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURABROJ.ExtendedProperties.Add("IsKey", "true");
                this.columnURABROJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnURABROJ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnURABROJ.ExtendedProperties.Add("Description", "Broj ure");
                this.columnURABROJ.ExtendedProperties.Add("Length", "5");
                this.columnURABROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnURABROJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnURABROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.InternalName", "URABROJ");
                this.Columns.Add(this.columnURABROJ);
                this.columnurapartnerIDPARTNER = new DataColumn("urapartnerIDPARTNER", typeof(int), "", MappingType.Element);
                this.columnurapartnerIDPARTNER.AllowDBNull = false;
                this.columnurapartnerIDPARTNER.Caption = "IDPARTNER";
                this.columnurapartnerIDPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("SuperType", "IDPARTNER");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("SubtypeGroup", "URAPARTNER");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("ReadOnly", "false");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("DeklaritType", "int");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Description", "Partner");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Length", "9");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "urapartnerIDPARTNER");
                this.Columns.Add(this.columnurapartnerIDPARTNER);
                this.columnIDTIPURA = new DataColumn("IDTIPURA", typeof(int), "", MappingType.Element);
                this.columnIDTIPURA.AllowDBNull = false;
                this.columnIDTIPURA.Caption = "IDTIPURA";
                this.columnIDTIPURA.DefaultValue = 1;
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPURA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDTIPURA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDTIPURA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPURA.ExtendedProperties.Add("Description", "Tip ure");
                this.columnIDTIPURA.ExtendedProperties.Add("Length", "5");
                this.columnIDTIPURA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPURA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDTIPURA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPURA");
                this.Columns.Add(this.columnIDTIPURA);
                this.columnURABROJRACUNADOBAVLJACA = new DataColumn("URABROJRACUNADOBAVLJACA", typeof(string), "", MappingType.Element);
                this.columnURABROJRACUNADOBAVLJACA.AllowDBNull = false;
                this.columnURABROJRACUNADOBAVLJACA.Caption = "URABROJRACUNADOBAVLJACA";
                this.columnURABROJRACUNADOBAVLJACA.MaxLength = 100;
                this.columnURABROJRACUNADOBAVLJACA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("IsKey", "false");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Description", "Broj računa dobavljača");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Length", "100");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Decimals", "0");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("IsInReader", "true");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.InternalName", "URABROJRACUNADOBAVLJACA");
                this.Columns.Add(this.columnURABROJRACUNADOBAVLJACA);
                this.columnURADATUM = new DataColumn("URADATUM", typeof(DateTime), "", MappingType.Element);
                this.columnURADATUM.AllowDBNull = false;
                this.columnURADATUM.Caption = "URADATUM";
                this.columnURADATUM.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURADATUM.ExtendedProperties.Add("IsKey", "false");
                this.columnURADATUM.ExtendedProperties.Add("ReadOnly", "false");
                this.columnURADATUM.ExtendedProperties.Add("DeklaritType", "date");
                this.columnURADATUM.ExtendedProperties.Add("Description", "Datum");
                this.columnURADATUM.ExtendedProperties.Add("Length", "8");
                this.columnURADATUM.ExtendedProperties.Add("Decimals", "0");
                this.columnURADATUM.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnURADATUM.ExtendedProperties.Add("IsInReader", "true");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.InternalName", "URADATUM");
                this.Columns.Add(this.columnURADATUM);
                this.columnURAVALUTA = new DataColumn("URAVALUTA", typeof(DateTime), "", MappingType.Element);
                this.columnURAVALUTA.AllowDBNull = false;
                this.columnURAVALUTA.Caption = "URAVALUTA";
                this.columnURAVALUTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURAVALUTA.ExtendedProperties.Add("IsKey", "false");
                this.columnURAVALUTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnURAVALUTA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnURAVALUTA.ExtendedProperties.Add("Description", "Valuta");
                this.columnURAVALUTA.ExtendedProperties.Add("Length", "8");
                this.columnURAVALUTA.ExtendedProperties.Add("Decimals", "0");
                this.columnURAVALUTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnURAVALUTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.InternalName", "URAVALUTA");
                this.Columns.Add(this.columnURAVALUTA);
                this.columnURANAPOMENA = new DataColumn("URANAPOMENA", typeof(string), "", MappingType.Element);
                this.columnURANAPOMENA.AllowDBNull = false;
                this.columnURANAPOMENA.Caption = "URANAPOMENA";
                this.columnURANAPOMENA.MaxLength = 50;
                this.columnURANAPOMENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURANAPOMENA.ExtendedProperties.Add("IsKey", "false");
                this.columnURANAPOMENA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnURANAPOMENA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnURANAPOMENA.ExtendedProperties.Add("Description", "Napomena");
                this.columnURANAPOMENA.ExtendedProperties.Add("Length", "50");
                this.columnURANAPOMENA.ExtendedProperties.Add("Decimals", "0");
                this.columnURANAPOMENA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnURANAPOMENA.ExtendedProperties.Add("IsInReader", "true");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.InternalName", "URANAPOMENA");
                this.Columns.Add(this.columnURANAPOMENA);
                this.columnURAMODEL = new DataColumn("URAMODEL", typeof(string), "", MappingType.Element);
                this.columnURAMODEL.AllowDBNull = true;
                this.columnURAMODEL.Caption = "URAMODEL";
                this.columnURAMODEL.MaxLength = 2;
                this.columnURAMODEL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURAMODEL.ExtendedProperties.Add("IsKey", "false");
                this.columnURAMODEL.ExtendedProperties.Add("ReadOnly", "false");
                this.columnURAMODEL.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnURAMODEL.ExtendedProperties.Add("Description", "Model odobrenja");
                this.columnURAMODEL.ExtendedProperties.Add("Length", "2");
                this.columnURAMODEL.ExtendedProperties.Add("Decimals", "0");
                this.columnURAMODEL.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnURAMODEL.ExtendedProperties.Add("IsInReader", "true");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.InternalName", "URAMODEL");
                this.Columns.Add(this.columnURAMODEL);
                this.columnURAPOZIVNABROJ = new DataColumn("URAPOZIVNABROJ", typeof(string), "", MappingType.Element);
                this.columnURAPOZIVNABROJ.AllowDBNull = true;
                this.columnURAPOZIVNABROJ.Caption = "";
                this.columnURAPOZIVNABROJ.MaxLength = 0x16;
                this.columnURAPOZIVNABROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Description", "Poziv na broj odobrenja");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Length", "22");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.InternalName", "URAPOZIVNABROJ");
                this.Columns.Add(this.columnURAPOZIVNABROJ);
                this.columnURAUKUPNO = new DataColumn("URAUKUPNO", typeof(decimal), "", MappingType.Element);
                this.columnURAUKUPNO.AllowDBNull = false;
                this.columnURAUKUPNO.Caption = "URAUKUPNO";
                this.columnURAUKUPNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURAUKUPNO.ExtendedProperties.Add("IsKey", "false");
                this.columnURAUKUPNO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnURAUKUPNO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnURAUKUPNO.ExtendedProperties.Add("Description", "Ukupan iznos računa");
                this.columnURAUKUPNO.ExtendedProperties.Add("Length", "12");
                this.columnURAUKUPNO.ExtendedProperties.Add("Decimals", "2");
                this.columnURAUKUPNO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnURAUKUPNO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnURAUKUPNO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnURAUKUPNO.ExtendedProperties.Add("IsInReader", "true");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.InternalName", "URAUKUPNO");
                this.Columns.Add(this.columnURAUKUPNO);
                this.columnOSNOVICA0 = new DataColumn("OSNOVICA0", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA0.AllowDBNull = false;
                this.columnOSNOVICA0.Caption = "Osnovica 0%";
                this.columnOSNOVICA0.DefaultValue = 0;
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA0.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA0.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICA0.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA0.ExtendedProperties.Add("Description", "Osnovica 0%");
                this.columnOSNOVICA0.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA0.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA0.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA0.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA0.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICA0.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA0");
                this.Columns.Add(this.columnOSNOVICA0);


                this.columnOSNOVICA5 = new DataColumn("OSNOVICA5", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA5.AllowDBNull = false;
                this.columnOSNOVICA5.Caption = "Osnovica 5%";
                this.columnOSNOVICA5.DefaultValue = 0;
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA5.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA5.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICA5.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA5.ExtendedProperties.Add("Description", "Osnovica 5%");
                this.columnOSNOVICA5.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA5.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA5.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA5.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA5.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICA5.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA5");
                this.Columns.Add(this.columnOSNOVICA5);

                this.columnOSNOVICA10 = new DataColumn("OSNOVICA10", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA10.AllowDBNull = false;
                this.columnOSNOVICA10.Caption = "Osnovica 10%";
                this.columnOSNOVICA10.DefaultValue = 0;
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA10.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA10.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICA10.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA10.ExtendedProperties.Add("Description", "Osnovica 10%");
                this.columnOSNOVICA10.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA10.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA10.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA10.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA10.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICA10.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA10");
                this.Columns.Add(this.columnOSNOVICA10);

                #region MBS.Complete 26.04.2016
                this.columnOsnovicaPPO = new DataColumn("OsnovicaPPO", typeof(decimal), "", MappingType.Element);
                this.columnOsnovicaPPO.AllowDBNull = false;
                this.columnOsnovicaPPO.Caption = "Osnovica PPO";
                this.columnOsnovicaPPO.DefaultValue = 0;
                this.columnOsnovicaPPO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOsnovicaPPO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOsnovicaPPO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOsnovicaPPO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOsnovicaPPO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOsnovicaPPO.ExtendedProperties.Add("IsKey", "false");
                this.columnOsnovicaPPO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOsnovicaPPO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOsnovicaPPO.ExtendedProperties.Add("Description", "Osnovica PPO");
                this.columnOsnovicaPPO.ExtendedProperties.Add("Length", "12");
                this.columnOsnovicaPPO.ExtendedProperties.Add("Decimals", "2");
                this.columnOsnovicaPPO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOsnovicaPPO.ExtendedProperties.Add("DomainType", "Osnovica");
                this.columnOsnovicaPPO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOsnovicaPPO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOsnovicaPPO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOsnovicaPPO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOsnovicaPPO.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAPPO");
                this.Columns.Add(this.columnOsnovicaPPO);
                this.columnMozePPO = new DataColumn("MozePPO", typeof(decimal), "", MappingType.Element);
                this.columnMozePPO.AllowDBNull = false;
                this.columnMozePPO.Caption = "Moze PPO";
                this.columnMozePPO.DefaultValue = 0;
                this.columnMozePPO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMozePPO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMozePPO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMozePPO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMozePPO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMozePPO.ExtendedProperties.Add("IsKey", "false");
                this.columnMozePPO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMozePPO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMozePPO.ExtendedProperties.Add("Description", "Moze PPO");
                this.columnMozePPO.ExtendedProperties.Add("Length", "12");
                this.columnMozePPO.ExtendedProperties.Add("Decimals", "2");
                this.columnMozePPO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMozePPO.ExtendedProperties.Add("DomainType", "Moze");
                this.columnMozePPO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMozePPO.ExtendedProperties.Add("IsInReader", "true");
                this.columnMozePPO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMozePPO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMozePPO.ExtendedProperties.Add("Deklarit.InternalName", "MOZEPPO");
                this.Columns.Add(this.columnMozePPO);
                this.columnNeMozePPO = new DataColumn("NeMozePPO", typeof(decimal), "", MappingType.Element);
                this.columnNeMozePPO.AllowDBNull = false;
                this.columnNeMozePPO.Caption = "Moze PPO";
                this.columnNeMozePPO.DefaultValue = 0;
                this.columnNeMozePPO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNeMozePPO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNeMozePPO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNeMozePPO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNeMozePPO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNeMozePPO.ExtendedProperties.Add("IsKey", "false");
                this.columnNeMozePPO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNeMozePPO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNeMozePPO.ExtendedProperties.Add("Description", "NeMoze PPO");
                this.columnNeMozePPO.ExtendedProperties.Add("Length", "12");
                this.columnNeMozePPO.ExtendedProperties.Add("Decimals", "2");
                this.columnNeMozePPO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNeMozePPO.ExtendedProperties.Add("DomainType", "Moze");
                this.columnNeMozePPO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNeMozePPO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNeMozePPO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNeMozePPO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNeMozePPO.ExtendedProperties.Add("Deklarit.InternalName", "NEMOZEPPO");
                this.Columns.Add(this.columnNeMozePPO);
                #endregion


                this.columnOSNOVICA22 = new DataColumn("OSNOVICA22", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA22.AllowDBNull = false;
                this.columnOSNOVICA22.Caption = "OSNOVIC A22";
                this.columnOSNOVICA22.DefaultValue = 0;
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA22.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA22.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICA22.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA22.ExtendedProperties.Add("Description", "Osnovica 22%");
                this.columnOSNOVICA22.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA22.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA22.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA22.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA22.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICA22.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA22");
                this.Columns.Add(this.columnOSNOVICA22);
                this.columnOSNOVICA23 = new DataColumn("OSNOVICA23", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA23.AllowDBNull = false;
                this.columnOSNOVICA23.Caption = "OSNOVIC A23";
                this.columnOSNOVICA23.DefaultValue = 0;
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA23.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA23.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICA23.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA23.ExtendedProperties.Add("Description", "Osnovica 23%");
                this.columnOSNOVICA23.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA23.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA23.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA23.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA23.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICA23.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA23");
                this.Columns.Add(this.columnOSNOVICA23);

                this.columnOSNOVICA25 = new DataColumn("OSNOVICA25", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA25.AllowDBNull = false;
                this.columnOSNOVICA25.Caption = "OSNOVIC A25";
                this.columnOSNOVICA25.DefaultValue = 0;
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA25.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA25.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICA25.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA25.ExtendedProperties.Add("Description", "Osnovica 25%");
                this.columnOSNOVICA25.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA25.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA25.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA25.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA25.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICA25.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA25");
                this.Columns.Add(this.columnOSNOVICA25);


                this.columnOSNOVICA5NE = new DataColumn("OSNOVICA5NE", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA5NE.AllowDBNull = false;
                this.columnOSNOVICA5NE.Caption = "OSNOVIC A5 NE";
                this.columnOSNOVICA5NE.DefaultValue = 0;
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Description", "Osnovica 5% porezno nepriznata");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA5NE");
                this.Columns.Add(this.columnOSNOVICA5NE);



                this.columnOSNOVICA10NE = new DataColumn("OSNOVICA10NE", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA10NE.AllowDBNull = false;
                this.columnOSNOVICA10NE.Caption = "OSNOVIC A10 NE";
                this.columnOSNOVICA10NE.DefaultValue = 0;
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Description", "Osnovica 10% porezno nepriznata");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA10NE");
                this.Columns.Add(this.columnOSNOVICA10NE);


                this.columnOSNOVICA22NE = new DataColumn("OSNOVICA22NE", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA22NE.AllowDBNull = false;
                this.columnOSNOVICA22NE.Caption = "OSNOVIC A22 NE";
                this.columnOSNOVICA22NE.DefaultValue = 0;
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Description", "Osnovica 22% porezno nepriznata");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA22NE");
                this.Columns.Add(this.columnOSNOVICA22NE);


                this.columnOSNOVICA23NE = new DataColumn("OSNOVICA23NE", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA23NE.AllowDBNull = false;
                this.columnOSNOVICA23NE.Caption = "OSNOVIC A23 NE";
                this.columnOSNOVICA23NE.DefaultValue = 0;
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Description", "Osnovica 23% porezno nepriznata");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA23NE");
                this.Columns.Add(this.columnOSNOVICA23NE);


                this.columnOSNOVICA25NE = new DataColumn("OSNOVICA25NE", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA25NE.AllowDBNull = false;
                this.columnOSNOVICA25NE.Caption = "OSNOVIC A25 NE";
                this.columnOSNOVICA25NE.DefaultValue = 0;
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Description", "Osnovica 25% porezno nepriznata");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA25NE");
                this.Columns.Add(this.columnOSNOVICA25NE);



                this.columnPDV5DA = new DataColumn("PDV5DA", typeof(decimal), "", MappingType.Element);
                this.columnPDV5DA.AllowDBNull = false;
                this.columnPDV5DA.Caption = "PD V5 DA";
                this.columnPDV5DA.DefaultValue = 0;
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV5DA.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV5DA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV5DA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV5DA.ExtendedProperties.Add("Description", "PDV 5 % Može se odbiti");
                this.columnPDV5DA.ExtendedProperties.Add("Length", "12");
                this.columnPDV5DA.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV5DA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV5DA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV5DA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV5DA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.InternalName", "PDV5DA");
                this.Columns.Add(this.columnPDV5DA);
                this.columnPDV5NE = new DataColumn("PDV5NE", typeof(decimal), "", MappingType.Element);
                this.columnPDV5NE.AllowDBNull = false;
                this.columnPDV5NE.Caption = "PD V5 NE";
                this.columnPDV5NE.DefaultValue = 0;
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV5NE.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV5NE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV5NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV5NE.ExtendedProperties.Add("Description", "PDV 5% Ne može se odbiti");
                this.columnPDV5NE.ExtendedProperties.Add("Length", "12");
                this.columnPDV5NE.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV5NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV5NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV5NE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV5NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.InternalName", "PDV5NE");
                this.Columns.Add(this.columnPDV5NE);



                this.columnPDV10DA = new DataColumn("PDV10DA", typeof(decimal), "", MappingType.Element);
                this.columnPDV10DA.AllowDBNull = false;
                this.columnPDV10DA.Caption = "PD V10 DA";
                this.columnPDV10DA.DefaultValue = 0;
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV10DA.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV10DA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV10DA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV10DA.ExtendedProperties.Add("Description", "PDV 10 % Može se odbiti");
                this.columnPDV10DA.ExtendedProperties.Add("Length", "12");
                this.columnPDV10DA.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV10DA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV10DA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV10DA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV10DA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.InternalName", "PDV10DA");
                this.Columns.Add(this.columnPDV10DA);
                this.columnPDV10NE = new DataColumn("PDV10NE", typeof(decimal), "", MappingType.Element);
                this.columnPDV10NE.AllowDBNull = false;
                this.columnPDV10NE.Caption = "PD V10 NE";
                this.columnPDV10NE.DefaultValue = 0;
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV10NE.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV10NE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV10NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV10NE.ExtendedProperties.Add("Description", "PDV 10% Ne može se odbiti");
                this.columnPDV10NE.ExtendedProperties.Add("Length", "12");
                this.columnPDV10NE.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV10NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV10NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV10NE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV10NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.InternalName", "PDV10NE");
                this.Columns.Add(this.columnPDV10NE);


                this.columnPDV22DA = new DataColumn("PDV22DA", typeof(decimal), "", MappingType.Element);
                this.columnPDV22DA.AllowDBNull = false;
                this.columnPDV22DA.Caption = "PD V22 DA";
                this.columnPDV22DA.DefaultValue = 0;
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV22DA.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV22DA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV22DA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV22DA.ExtendedProperties.Add("Description", "PDV 22 % Može se odbiti");
                this.columnPDV22DA.ExtendedProperties.Add("Length", "12");
                this.columnPDV22DA.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV22DA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV22DA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV22DA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV22DA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.InternalName", "PDV22DA");
                this.Columns.Add(this.columnPDV22DA);
                this.columnPDV22NE = new DataColumn("PDV22NE", typeof(decimal), "", MappingType.Element);
                this.columnPDV22NE.AllowDBNull = false;
                this.columnPDV22NE.Caption = "PD V22 NE";
                this.columnPDV22NE.DefaultValue = 0;
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV22NE.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV22NE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV22NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV22NE.ExtendedProperties.Add("Description", "PDV 22 % Ne može se odbiti");
                this.columnPDV22NE.ExtendedProperties.Add("Length", "12");
                this.columnPDV22NE.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV22NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV22NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV22NE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV22NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.InternalName", "PDV22NE");
                this.Columns.Add(this.columnPDV22NE);



                this.columnPDV23DA = new DataColumn("PDV23DA", typeof(decimal), "", MappingType.Element);
                this.columnPDV23DA.AllowDBNull = false;
                this.columnPDV23DA.Caption = "PD V23 DA";
                this.columnPDV23DA.DefaultValue = 0;
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV23DA.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV23DA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV23DA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV23DA.ExtendedProperties.Add("Description", "PDV 23 % Može se odbiti");
                this.columnPDV23DA.ExtendedProperties.Add("Length", "12");
                this.columnPDV23DA.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV23DA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV23DA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV23DA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV23DA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.InternalName", "PDV23DA");
                this.Columns.Add(this.columnPDV23DA);

                this.columnPDV23NE = new DataColumn("PDV23NE", typeof(decimal), "", MappingType.Element);
                this.columnPDV23NE.AllowDBNull = false;
                this.columnPDV23NE.Caption = "PD V23 NE";
                this.columnPDV23NE.DefaultValue = 0;
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV23NE.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV23NE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV23NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV23NE.ExtendedProperties.Add("Description", "PDV 23 % Ne može se odbiti");
                this.columnPDV23NE.ExtendedProperties.Add("Length", "12");
                this.columnPDV23NE.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV23NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV23NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV23NE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV23NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.InternalName", "PDV23NE");
                this.Columns.Add(this.columnPDV23NE);







                this.columnPDV25DA = new DataColumn("PDV25DA", typeof(decimal), "", MappingType.Element);
                this.columnPDV25DA.AllowDBNull = false;
                this.columnPDV25DA.Caption = "PD V25 DA";
                this.columnPDV25DA.DefaultValue = 0;
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV25DA.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV25DA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV25DA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV25DA.ExtendedProperties.Add("Description", "PDV 25 % Može se odbiti");
                this.columnPDV25DA.ExtendedProperties.Add("Length", "12");
                this.columnPDV25DA.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV25DA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV25DA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV25DA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV25DA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.InternalName", "PDV25DA");
                this.Columns.Add(this.columnPDV25DA);

                this.columnPDV25NE = new DataColumn("PDV25NE", typeof(decimal), "", MappingType.Element);
                this.columnPDV25NE.AllowDBNull = false;
                this.columnPDV25NE.Caption = "PD V25 NE";
                this.columnPDV25NE.DefaultValue = 0;
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV25NE.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV25NE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV25NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV25NE.ExtendedProperties.Add("Description", "PDV 25 % Ne može se odbiti");
                this.columnPDV25NE.ExtendedProperties.Add("Length", "12");
                this.columnPDV25NE.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV25NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV25NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV25NE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV25NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.InternalName", "PDV25NE");
                this.Columns.Add(this.columnPDV25NE);






                this.columnR2 = new DataColumn("R2", typeof(bool), "", MappingType.Element);
                this.columnR2.AllowDBNull = false;
                this.columnR2.Caption = "R2";
                this.columnR2.DefaultValue = false;
                this.columnR2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnR2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnR2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnR2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnR2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnR2.ExtendedProperties.Add("IsKey", "false");
                this.columnR2.ExtendedProperties.Add("ReadOnly", "false");
                this.columnR2.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnR2.ExtendedProperties.Add("Description", "R2");
                this.columnR2.ExtendedProperties.Add("Length", "1");
                this.columnR2.ExtendedProperties.Add("Decimals", "0");
                this.columnR2.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnR2.ExtendedProperties.Add("IsInReader", "true");
                this.columnR2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnR2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnR2.ExtendedProperties.Add("Deklarit.InternalName", "R2");
                this.Columns.Add(this.columnR2);
                this.PrimaryKey = new DataColumn[] { this.columnURAGODIDGODINE, this.columnURADOKIDDOKUMENT, this.columnURABROJ };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "URA");
                this.ExtendedProperties.Add("Description", "URA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnURAGODIDGODINE = this.Columns["URAGODIDGODINE"];
                this.columnURADOKIDDOKUMENT = this.Columns["URADOKIDDOKUMENT"];
                this.columnURABROJ = this.Columns["URABROJ"];
                this.columnurapartnerIDPARTNER = this.Columns["urapartnerIDPARTNER"];
                this.columnIDTIPURA = this.Columns["IDTIPURA"];
                this.columnURABROJRACUNADOBAVLJACA = this.Columns["URABROJRACUNADOBAVLJACA"];
                this.columnURADATUM = this.Columns["URADATUM"];
                this.columnURAVALUTA = this.Columns["URAVALUTA"];
                this.columnURANAPOMENA = this.Columns["URANAPOMENA"];
                this.columnURAMODEL = this.Columns["URAMODEL"];
                this.columnURAPOZIVNABROJ = this.Columns["URAPOZIVNABROJ"];
                this.columnURAUKUPNO = this.Columns["URAUKUPNO"];
                this.columnOSNOVICA0 = this.Columns["OSNOVICA0"];
                this.columnOSNOVICA5 = this.Columns["OSNOVICA5"];
                this.columnOSNOVICA10 = this.Columns["OSNOVICA10"];
                this.columnOSNOVICA22 = this.Columns["OSNOVICA22"];
                this.columnOSNOVICA23 = this.Columns["OSNOVICA23"];
                this.columnOSNOVICA25 = this.Columns["OSNOVICA25"];
                this.columnOSNOVICA5NE = this.Columns["OSNOVICA5NE"];
                this.columnOSNOVICA10NE = this.Columns["OSNOVICA10NE"];
                this.columnOSNOVICA22NE = this.Columns["OSNOVICA22NE"];
                this.columnOSNOVICA23NE = this.Columns["OSNOVICA23NE"];
                this.columnOSNOVICA25NE = this.Columns["OSNOVICA25NE"];
                this.columnPDV5DA = this.Columns["PDV5DA"];
                this.columnPDV5NE = this.Columns["PDV5NE"];
                this.columnPDV10DA = this.Columns["PDV10DA"];
                this.columnPDV10NE = this.Columns["PDV10NE"];
                this.columnPDV22DA = this.Columns["PDV22DA"];
                this.columnPDV22NE = this.Columns["PDV22NE"];
                this.columnPDV23DA = this.Columns["PDV23DA"];
                this.columnPDV23NE = this.Columns["PDV23NE"];
                this.columnPDV25DA = this.Columns["PDV25DA"];
                this.columnPDV25NE = this.Columns["PDV25NE"];
                this.columnR2 = this.Columns["R2"];

                #region MBS.Complete 26.04.2016
                this.columnOsnovicaPPO = this.Columns["OsnovicaPPO"];
                this.columnMozePPO = this.Columns["MozePPO"];
                this.columnNeMozePPO = this.Columns["NeMozePPO"];
                #endregion
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new URADataSet.URARow(builder);
            }

            public URADataSet.URARow NewURARow()
            {
                return (URADataSet.URARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.URARowChanged != null)
                {
                    URADataSet.URARowChangeEventHandler uRARowChangedEvent = this.URARowChanged;
                    if (uRARowChangedEvent != null)
                    {
                        uRARowChangedEvent(this, new URADataSet.URARowChangeEvent((URADataSet.URARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.URARowChanging != null)
                {
                    URADataSet.URARowChangeEventHandler uRARowChangingEvent = this.URARowChanging;
                    if (uRARowChangingEvent != null)
                    {
                        uRARowChangingEvent(this, new URADataSet.URARowChangeEvent((URADataSet.URARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.URARowDeleted != null)
                {
                    URADataSet.URARowChangeEventHandler uRARowDeletedEvent = this.URARowDeleted;
                    if (uRARowDeletedEvent != null)
                    {
                        uRARowDeletedEvent(this, new URADataSet.URARowChangeEvent((URADataSet.URARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.URARowDeleting != null)
                {
                    URADataSet.URARowChangeEventHandler uRARowDeletingEvent = this.URARowDeleting;
                    if (uRARowDeletingEvent != null)
                    {
                        uRARowDeletingEvent(this, new URADataSet.URARowChangeEvent((URADataSet.URARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveURARow(URADataSet.URARow row)
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

            public DataColumn IDTIPURAColumn
            {
                get
                {
                    return this.columnIDTIPURA;
                }
            }

            public URADataSet.URARow this[int index]
            {
                get
                {
                    return (URADataSet.URARow) this.Rows[index];
                }
            }

            public DataColumn OSNOVICA0Column
            {
                get
                {
                    return this.columnOSNOVICA0;
                }
            }


            #region MBS.Complete 26.04.2016
            public DataColumn OsnovicaPPOColumn
            {
                get
                {
                    return this.columnOsnovicaPPO;
                }
            }
            public DataColumn MozePPOColumn
            {
                get
                {
                    return this.columnMozePPO;
                }
            }
            public DataColumn NeMozePPOColumn
            {
                get
                {
                    return this.columnNeMozePPO;
                }
            }
            #endregion


            public DataColumn OSNOVICA5Column
            {
                get
                {
                    return this.columnOSNOVICA5;
                }
            }

            public DataColumn OSNOVICA5NEColumn
            {
                get
                {
                    return this.columnOSNOVICA5NE;
                }
            }

            public DataColumn OSNOVICA10Column
            {
                get
                {
                    return this.columnOSNOVICA10;
                }
            }

            public DataColumn OSNOVICA10NEColumn
            {
                get
                {
                    return this.columnOSNOVICA10NE;
                }
            }

            public DataColumn OSNOVICA22Column
            {
                get
                {
                    return this.columnOSNOVICA22;
                }
            }

            public DataColumn OSNOVICA22NEColumn
            {
                get
                {
                    return this.columnOSNOVICA22NE;
                }
            }

            public DataColumn OSNOVICA23Column
            {
                get
                {
                    return this.columnOSNOVICA23;
                }
            }

            public DataColumn OSNOVICA23NEColumn
            {
                get
                {
                    return this.columnOSNOVICA23NE;
                }
            }


            public DataColumn OSNOVICA25Column
            {
                get
                {
                    return this.columnOSNOVICA25;
                }
            }

            public DataColumn OSNOVICA25NEColumn
            {
                get
                {
                    return this.columnOSNOVICA25NE;
                }
            }


            public DataColumn PDV5DAColumn
            {
                get
                {
                    return this.columnPDV5DA;
                }
            }

            public DataColumn PDV5NEColumn
            {
                get
                {
                    return this.columnPDV5NE;
                }
            }

            public DataColumn PDV10DAColumn
            {
                get
                {
                    return this.columnPDV10DA;
                }
            }

            public DataColumn PDV10NEColumn
            {
                get
                {
                    return this.columnPDV10NE;
                }
            }

            public DataColumn PDV22DAColumn
            {
                get
                {
                    return this.columnPDV22DA;
                }
            }

            public DataColumn PDV22NEColumn
            {
                get
                {
                    return this.columnPDV22NE;
                }
            }



            public DataColumn PDV23DAColumn
            {
                get
                {
                    return this.columnPDV23DA;
                }
            }

            public DataColumn PDV23NEColumn
            {
                get
                {
                    return this.columnPDV23NE;
                }
            }


            public DataColumn PDV25DAColumn
            {
                get
                {
                    return this.columnPDV25DA;
                }
            }

            public DataColumn PDV25NEColumn
            {
                get
                {
                    return this.columnPDV25NE;
                }
            }



            public DataColumn R2Column
            {
                get
                {
                    return this.columnR2;
                }
            }

            public DataColumn URABROJColumn
            {
                get
                {
                    return this.columnURABROJ;
                }
            }

            public DataColumn URABROJRACUNADOBAVLJACAColumn
            {
                get
                {
                    return this.columnURABROJRACUNADOBAVLJACA;
                }
            }

            public DataColumn URADATUMColumn
            {
                get
                {
                    return this.columnURADATUM;
                }
            }

            public DataColumn URADOKIDDOKUMENTColumn
            {
                get
                {
                    return this.columnURADOKIDDOKUMENT;
                }
            }

            public DataColumn URAGODIDGODINEColumn
            {
                get
                {
                    return this.columnURAGODIDGODINE;
                }
            }

            public DataColumn URAMODELColumn
            {
                get
                {
                    return this.columnURAMODEL;
                }
            }

            public DataColumn URANAPOMENAColumn
            {
                get
                {
                    return this.columnURANAPOMENA;
                }
            }

            public DataColumn urapartnerIDPARTNERColumn
            {
                get
                {
                    return this.columnurapartnerIDPARTNER;
                }
            }

            public DataColumn URAPOZIVNABROJColumn
            {
                get
                {
                    return this.columnURAPOZIVNABROJ;
                }
            }

            public DataColumn URAUKUPNOColumn
            {
                get
                {
                    return this.columnURAUKUPNO;
                }
            }

            public DataColumn URAVALUTAColumn
            {
                get
                {
                    return this.columnURAVALUTA;
                }
            }
        }

        public class URARow : DataRow
        {
            private URADataSet.URADataTable tableURA;

            internal URARow(DataRowBuilder rb) : base(rb)
            {
                this.tableURA = (URADataSet.URADataTable) this.Table;
            }

            public bool IsIDTIPURANull()
            {
                return this.IsNull(this.tableURA.IDTIPURAColumn);
            }

            public bool IsOSNOVICA0Null()
            {
                return this.IsNull(this.tableURA.OSNOVICA0Column);
            }

            #region MBS.Complete 26.04.2016
            public bool IsOsnovicaPPONull()
            {
                return this.IsNull(this.tableURA.OsnovicaPPOColumn);
            }
            public bool IsMozePPONull()
            {
                return this.IsNull(this.tableURA.MozePPOColumn);
            }
            public bool IsNeMozePPONull()
            {
                return this.IsNull(this.tableURA.NeMozePPOColumn);
            }
            #endregion

            public bool IsOSNOVICA5NENull()
            {
                return this.IsNull(this.tableURA.OSNOVICA5NEColumn);
            }

            public bool IsOSNOVICA5Null()
            {
                return this.IsNull(this.tableURA.OSNOVICA5Column);
            }

            public bool IsOSNOVICA10NENull()
            {
                return this.IsNull(this.tableURA.OSNOVICA10NEColumn);
            }

            public bool IsOSNOVICA10Null()
            {
                return this.IsNull(this.tableURA.OSNOVICA10Column);
            }

            public bool IsOSNOVICA22NENull()
            {
                return this.IsNull(this.tableURA.OSNOVICA22NEColumn);
            }

            public bool IsOSNOVICA22Null()
            {
                return this.IsNull(this.tableURA.OSNOVICA22Column);
            }

            public bool IsOSNOVICA23NENull()
            {
                return this.IsNull(this.tableURA.OSNOVICA23NEColumn);
            }

            public bool IsOSNOVICA23Null()
            {
                return this.IsNull(this.tableURA.OSNOVICA23Column);
            }


            public bool IsOSNOVICA25NENull()
            {
                return this.IsNull(this.tableURA.OSNOVICA25NEColumn);
            }

            public bool IsOSNOVICA25Null()
            {
                return this.IsNull(this.tableURA.OSNOVICA25Column);
            }



            public bool IsPDV5DANull()
            {
                return this.IsNull(this.tableURA.PDV5DAColumn);
            }

            public bool IsPDV5NENull()
            {
                return this.IsNull(this.tableURA.PDV5NEColumn);
            }


            public bool IsPDV10DANull()
            {
                return this.IsNull(this.tableURA.PDV10DAColumn);
            }

            public bool IsPDV10NENull()
            {
                return this.IsNull(this.tableURA.PDV10NEColumn);
            }

            public bool IsPDV22DANull()
            {
                return this.IsNull(this.tableURA.PDV22DAColumn);
            }

            public bool IsPDV22NENull()
            {
                return this.IsNull(this.tableURA.PDV22NEColumn);
            }

            public bool IsPDV23DANull()
            {
                return this.IsNull(this.tableURA.PDV23DAColumn);
            }

            public bool IsPDV23NENull()
            {
                return this.IsNull(this.tableURA.PDV23NEColumn);
            }


            public bool IsPDV25DANull()
            {
                return this.IsNull(this.tableURA.PDV25DAColumn);
            }

            public bool IsPDV25NENull()
            {
                return this.IsNull(this.tableURA.PDV25NEColumn);
            }


            public bool IsR2Null()
            {
                return this.IsNull(this.tableURA.R2Column);
            }

            public bool IsURABROJNull()
            {
                return this.IsNull(this.tableURA.URABROJColumn);
            }

            public bool IsURABROJRACUNADOBAVLJACANull()
            {
                return this.IsNull(this.tableURA.URABROJRACUNADOBAVLJACAColumn);
            }

            public bool IsURADATUMNull()
            {
                return this.IsNull(this.tableURA.URADATUMColumn);
            }

            public bool IsURADOKIDDOKUMENTNull()
            {
                return this.IsNull(this.tableURA.URADOKIDDOKUMENTColumn);
            }

            public bool IsURAGODIDGODINENull()
            {
                return this.IsNull(this.tableURA.URAGODIDGODINEColumn);
            }

            public bool IsURAMODELNull()
            {
                return this.IsNull(this.tableURA.URAMODELColumn);
            }

            public bool IsURANAPOMENANull()
            {
                return this.IsNull(this.tableURA.URANAPOMENAColumn);
            }

            public bool IsurapartnerIDPARTNERNull()
            {
                return this.IsNull(this.tableURA.urapartnerIDPARTNERColumn);
            }

            public bool IsURAPOZIVNABROJNull()
            {
                return this.IsNull(this.tableURA.URAPOZIVNABROJColumn);
            }

            public bool IsURAUKUPNONull()
            {
                return this.IsNull(this.tableURA.URAUKUPNOColumn);
            }

            public bool IsURAVALUTANull()
            {
                return this.IsNull(this.tableURA.URAVALUTAColumn);
            }

            public void SetIDTIPURANull()
            {
                this[this.tableURA.IDTIPURAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA0Null()
            {
                this[this.tableURA.OSNOVICA0Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA5NENull()
            {
                this[this.tableURA.OSNOVICA5NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA5Null()
            {
                this[this.tableURA.OSNOVICA5Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            #region MBS.Complete 26.04.2016
            public void SetOsnovicaPPONull()
            {
                this[this.tableURA.OsnovicaPPOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            public void SetMozePPONull()
            {
                this[this.tableURA.MozePPOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            public void SetNeMozePPONull()
            {
                this[this.tableURA.NeMozePPOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            #endregion

            public void SetOSNOVICA10NENull()
            {
                this[this.tableURA.OSNOVICA10NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA10Null()
            {
                this[this.tableURA.OSNOVICA10Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA22NENull()
            {
                this[this.tableURA.OSNOVICA22NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA22Null()
            {
                this[this.tableURA.OSNOVICA22Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA23NENull()
            {
                this[this.tableURA.OSNOVICA23NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA23Null()
            {
                this[this.tableURA.OSNOVICA23Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }



            public void SetOSNOVICA25NENull()
            {
                this[this.tableURA.OSNOVICA25NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA25Null()
            {
                this[this.tableURA.OSNOVICA25Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }


            public void SetPDV5DANull()
            {
                this[this.tableURA.PDV5DAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV5NENull()
            {
                this[this.tableURA.PDV5NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }


            public void SetPDV10DANull()
            {
                this[this.tableURA.PDV10DAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV10NENull()
            {
                this[this.tableURA.PDV10NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV22DANull()
            {
                this[this.tableURA.PDV22DAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV22NENull()
            {
                this[this.tableURA.PDV22NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV23DANull()
            {
                this[this.tableURA.PDV23DAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV23NENull()
            {
                this[this.tableURA.PDV23NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }



            public void SetPDV25DANull()
            {
                this[this.tableURA.PDV25DAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV25NENull()
            {
                this[this.tableURA.PDV25NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }



            public void SetR2Null()
            {
                this[this.tableURA.R2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURABROJRACUNADOBAVLJACANull()
            {
                this[this.tableURA.URABROJRACUNADOBAVLJACAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURADATUMNull()
            {
                this[this.tableURA.URADATUMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURAMODELNull()
            {
                this[this.tableURA.URAMODELColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURANAPOMENANull()
            {
                this[this.tableURA.URANAPOMENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SeturapartnerIDPARTNERNull()
            {
                this[this.tableURA.urapartnerIDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURAPOZIVNABROJNull()
            {
                this[this.tableURA.URAPOZIVNABROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURAUKUPNONull()
            {
                this[this.tableURA.URAUKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURAVALUTANull()
            {
                this[this.tableURA.URAVALUTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDTIPURA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableURA.IDTIPURAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.IDTIPURAColumn] = value;
                }
            }

            public decimal OSNOVICA0
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.OSNOVICA0Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.OSNOVICA0Column] = value;
                }
            }

            #region MBS.Complete 26.04.2016
            public decimal OsnovicaPPO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.OsnovicaPPOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.OsnovicaPPOColumn] = value;
                }
            }
            public decimal MozePPO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.MozePPOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.MozePPOColumn] = value;
                }
            }
            public decimal NeMozePPO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.NeMozePPOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.NeMozePPOColumn] = value;
                }
            }
            #endregion

            public decimal OSNOVICA5
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.OSNOVICA5Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.OSNOVICA5Column] = value;
                }
            }

            public decimal OSNOVICA5NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.OSNOVICA5NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.OSNOVICA5NEColumn] = value;
                }
            }


            public decimal OSNOVICA10
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.OSNOVICA10Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.OSNOVICA10Column] = value;
                }
            }

            public decimal OSNOVICA10NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.OSNOVICA10NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.OSNOVICA10NEColumn] = value;
                }
            }

            public decimal OSNOVICA22
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.OSNOVICA22Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.OSNOVICA22Column] = value;
                }
            }

            public decimal OSNOVICA22NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.OSNOVICA22NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.OSNOVICA22NEColumn] = value;
                }
            }

            public decimal OSNOVICA23
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.OSNOVICA23Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.OSNOVICA23Column] = value;
                }
            }

            public decimal OSNOVICA23NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.OSNOVICA23NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.OSNOVICA23NEColumn] = value;
                }
            }



            public decimal OSNOVICA25
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.OSNOVICA25Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.OSNOVICA25Column] = value;
                }
            }

            public decimal OSNOVICA25NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.OSNOVICA25NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.OSNOVICA25NEColumn] = value;
                }
            }



            public decimal PDV5DA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.PDV5DAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.PDV5DAColumn] = value;
                }
            }

            public decimal PDV5NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.PDV5NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.PDV5NEColumn] = value;
                }
            }

            public decimal PDV10DA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.PDV10DAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.PDV10DAColumn] = value;
                }
            }

            public decimal PDV10NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.PDV10NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.PDV10NEColumn] = value;
                }
            }

            public decimal PDV22DA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.PDV22DAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.PDV22DAColumn] = value;
                }
            }

            public decimal PDV22NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.PDV22NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.PDV22NEColumn] = value;
                }
            }

            public decimal PDV23DA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.PDV23DAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.PDV23DAColumn] = value;
                }
            }

            public decimal PDV23NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.PDV23NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.PDV23NEColumn] = value;
                }
            }



            public decimal PDV25DA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.PDV25DAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.PDV25DAColumn] = value;
                }
            }

            public decimal PDV25NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.PDV25NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.PDV25NEColumn] = value;
                }
            }



            public bool R2
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableURA.R2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableURA.R2Column] = value;
                }
            }

            public int URABROJ
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableURA.URABROJColumn]);
                }
                set
                {
                    this[this.tableURA.URABROJColumn] = value;
                }
            }

            public string URABROJRACUNADOBAVLJACA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableURA.URABROJRACUNADOBAVLJACAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableURA.URABROJRACUNADOBAVLJACAColumn] = value;
                }
            }

            public DateTime URADATUM
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableURA.URADATUMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableURA.URADATUMColumn] = value;
                }
            }

            public int URADOKIDDOKUMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableURA.URADOKIDDOKUMENTColumn]);
                }
                set
                {
                    this[this.tableURA.URADOKIDDOKUMENTColumn] = value;
                }
            }

            public short URAGODIDGODINE
            {
                get
                {
                    return Conversions.ToShort(this[this.tableURA.URAGODIDGODINEColumn]);
                }
                set
                {
                    this[this.tableURA.URAGODIDGODINEColumn] = value;
                }
            }

            public string URAMODEL
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableURA.URAMODELColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableURA.URAMODELColumn] = value;
                }
            }

            public string URANAPOMENA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableURA.URANAPOMENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableURA.URANAPOMENAColumn] = value;
                }
            }

            public int urapartnerIDPARTNER
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableURA.urapartnerIDPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.urapartnerIDPARTNERColumn] = value;
                }
            }

            public string URAPOZIVNABROJ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableURA.URAPOZIVNABROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableURA.URAPOZIVNABROJColumn] = value;
                }
            }

            public decimal URAUKUPNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableURA.URAUKUPNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableURA.URAUKUPNOColumn] = value;
                }
            }

            public DateTime URAVALUTA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableURA.URAVALUTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableURA.URAVALUTAColumn] = value;
                }
            }
        }

        public class URARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private URADataSet.URARow eventRow;

            public URARowChangeEvent(URADataSet.URARow row, DataRowAction action)
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

            public URADataSet.URARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void URARowChangeEventHandler(object sender, URADataSet.URARowChangeEvent e);
    }
}

