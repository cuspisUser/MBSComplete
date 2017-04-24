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
    public class SP_FIN_URAPLACANJEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private SP_FIN_URAPLACANJEDataTable tableSP_FIN_URAPLACANJE;

        public SP_FIN_URAPLACANJEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected SP_FIN_URAPLACANJEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["SP_FIN_URAPLACANJE"] != null)
                    {
                        this.Tables.Add(new SP_FIN_URAPLACANJEDataTable(dataSet.Tables["SP_FIN_URAPLACANJE"]));
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
            SP_FIN_URAPLACANJEDataSet set = (SP_FIN_URAPLACANJEDataSet) base.Clone();
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
            SP_FIN_URAPLACANJEDataSet set = new SP_FIN_URAPLACANJEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "SP_FIN_URAPLACANJEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2040");
            this.ExtendedProperties.Add("DataSetName", "SP_FIN_URAPLACANJEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ISP_FIN_URAPLACANJEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "SP_FIN_URAPLACANJE");
            this.ExtendedProperties.Add("ObjectDescription", "SP_FIN_URAPLACANJE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_FIN_URA_PLACANJE");
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
            this.DataSetName = "SP_FIN_URAPLACANJEDataSet";
            this.Namespace = "http://www.tempuri.org/SP_FIN_URAPLACANJE";
            this.tableSP_FIN_URAPLACANJE = new SP_FIN_URAPLACANJEDataTable();
            this.Tables.Add(this.tableSP_FIN_URAPLACANJE);
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
            this.tableSP_FIN_URAPLACANJE = (SP_FIN_URAPLACANJEDataTable) this.Tables["SP_FIN_URAPLACANJE"];
            if (initTable && (this.tableSP_FIN_URAPLACANJE != null))
            {
                this.tableSP_FIN_URAPLACANJE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["SP_FIN_URAPLACANJE"] != null)
                {
                    this.Tables.Add(new SP_FIN_URAPLACANJEDataTable(dataSet.Tables["SP_FIN_URAPLACANJE"]));
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

        private bool ShouldSerializeSP_FIN_URAPLACANJE()
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
        public SP_FIN_URAPLACANJEDataTable SP_FIN_URAPLACANJE
        {
            get
            {
                return this.tableSP_FIN_URAPLACANJE;
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
        public class SP_FIN_URAPLACANJEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDTIPURA;
            private DataColumn columnMB;
            private DataColumn columnNAZIVPARTNER;

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

            private DataColumn columnPARTNEROIB;

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
            private DataColumn columnStatus;
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
            private DataColumn columnZATVARANJE_DATUM;
            private DataColumn columnZATVARANJE_IZNOS;

            public event SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERowChangeEventHandler SP_FIN_URAPLACANJERowChanged;

            public event SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERowChangeEventHandler SP_FIN_URAPLACANJERowChanging;

            public event SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERowChangeEventHandler SP_FIN_URAPLACANJERowDeleted;

            public event SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERowChangeEventHandler SP_FIN_URAPLACANJERowDeleting;

            public SP_FIN_URAPLACANJEDataTable()
            {
                this.TableName = "SP_FIN_URAPLACANJE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SP_FIN_URAPLACANJEDataTable(DataTable table) : base(table.TableName)
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

            protected SP_FIN_URAPLACANJEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSP_FIN_URAPLACANJERow(SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow row)
            {
                this.Rows.Add(row);
            }

            public SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow AddSP_FIN_URAPLACANJERow(decimal zATVARANJE_IZNOS, DateTime zATVARANJE_DATUM, int uRABROJ, int iDTIPURA, 
                string uRABROJRACUNADOBAVLJACA, int urapartnerIDPARTNER, string uRANAPOMENA, DateTime uRAVALUTA, decimal uRAUKUPNO, DateTime uRADATUM, short uRAGODIDGODINE, string nAZIVPARTNER, 
                string mB, int uRADOKIDDOKUMENT, string pARTNEROIB, string status, string uRAMODEL, string uRAPOZIVNABROJ, 
                decimal oSNOVICA0, decimal oSNOVICA5, decimal oSNOVICA10, decimal oSNOVICA22, decimal oSNOVICA23, decimal oSNOVICA25,
                decimal pDV5DA, decimal pDV5NE, decimal pDV10DA, decimal pDV10NE, decimal pDV22DA, decimal pDV22NE, decimal pDV23DA, decimal pDV23NE, decimal pDV25DA, decimal pDV25NE,
                decimal oSNOVICA5NE, decimal oSNOVICA10NE, decimal oSNOVICA23NE, decimal oSNOVICA22NE, decimal oSNOVICA25NE, bool r2)
            {
                SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow row = (SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow) this.NewRow();
                row.ItemArray = new object[] { 
                    zATVARANJE_IZNOS, zATVARANJE_DATUM, uRABROJ, iDTIPURA, uRABROJRACUNADOBAVLJACA, urapartnerIDPARTNER, uRANAPOMENA, uRAVALUTA, uRAUKUPNO, uRADATUM, uRAGODIDGODINE, nAZIVPARTNER, mB, uRADOKIDDOKUMENT, pARTNEROIB, status, 
                    uRAMODEL, uRAPOZIVNABROJ, oSNOVICA0, oSNOVICA5, oSNOVICA10, oSNOVICA22, oSNOVICA23, oSNOVICA25, pDV5DA, pDV10NE, pDV10DA, pDV10NE, pDV22DA, pDV22NE, pDV23DA, pDV23NE, pDV25DA, pDV25NE, oSNOVICA5NE, oSNOVICA10NE, oSNOVICA23NE, 
                    oSNOVICA22NE, oSNOVICA25NE, r2
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJEDataTable table = (SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SP_FIN_URAPLACANJEDataSet set = new SP_FIN_URAPLACANJEDataSet();
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
                this.columnZATVARANJE_IZNOS = new DataColumn("ZATVARANJE_IZNOS", typeof(decimal), "", MappingType.Element);
                this.columnZATVARANJE_IZNOS.Caption = "ZATVARANJE  IZNOS";
                this.columnZATVARANJE_IZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("Description", "ZATVARANJE  IZNOS");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("Length", "12");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZATVARANJE_IZNOS.ExtendedProperties.Add("Deklarit.InternalName", "ZATVARANJE_IZNOS");
                this.Columns.Add(this.columnZATVARANJE_IZNOS);
                this.columnZATVARANJE_DATUM = new DataColumn("ZATVARANJE_DATUM", typeof(DateTime), "", MappingType.Element);
                this.columnZATVARANJE_DATUM.Caption = "ZATVARANJE  DATUM";
                this.columnZATVARANJE_DATUM.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("IsKey", "false");
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("DeklaritType", "date");
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("Description", "ZATVARANJE  DATUM");
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("Length", "8");
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("Decimals", "0");
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("IsInReader", "true");
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZATVARANJE_DATUM.ExtendedProperties.Add("Deklarit.InternalName", "ZATVARANJE_DATUM");
                this.Columns.Add(this.columnZATVARANJE_DATUM);
                this.columnURABROJ = new DataColumn("URABROJ", typeof(int), "", MappingType.Element);
                this.columnURABROJ.Caption = "URABROJ";
                this.columnURABROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnURABROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnURABROJ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnURABROJ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnURABROJ.ExtendedProperties.Add("Description", "URABROJ");
                this.columnURABROJ.ExtendedProperties.Add("Length", "5");
                this.columnURABROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnURABROJ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnURABROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURABROJ.ExtendedProperties.Add("Deklarit.InternalName", "URABROJ");
                this.Columns.Add(this.columnURABROJ);
                this.columnIDTIPURA = new DataColumn("IDTIPURA", typeof(int), "", MappingType.Element);
                this.columnIDTIPURA.Caption = "IDTIPURA";
                this.columnIDTIPURA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDTIPURA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDTIPURA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDTIPURA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPURA.ExtendedProperties.Add("Description", "IDTIPURA");
                this.columnIDTIPURA.ExtendedProperties.Add("Length", "5");
                this.columnIDTIPURA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPURA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDTIPURA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPURA");
                this.Columns.Add(this.columnIDTIPURA);
                this.columnURABROJRACUNADOBAVLJACA = new DataColumn("URABROJRACUNADOBAVLJACA", typeof(string), "", MappingType.Element);
                this.columnURABROJRACUNADOBAVLJACA.Caption = "URABROJRACUNADOBAVLJACA";
                this.columnURABROJRACUNADOBAVLJACA.MaxLength = 100;
                this.columnURABROJRACUNADOBAVLJACA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("IsKey", "false");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Description", "URABROJRACUNADOBAVLJACA");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Length", "100");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Decimals", "0");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("IsInReader", "true");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURABROJRACUNADOBAVLJACA.ExtendedProperties.Add("Deklarit.InternalName", "URABROJRACUNADOBAVLJACA");
                this.Columns.Add(this.columnURABROJRACUNADOBAVLJACA);
                this.columnurapartnerIDPARTNER = new DataColumn("urapartnerIDPARTNER", typeof(int), "", MappingType.Element);
                this.columnurapartnerIDPARTNER.Caption = "IDPARTNER";
                this.columnurapartnerIDPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("SuperType", "IDPARTNER");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("SubtypeGroup", "URAPARTNER");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("ReadOnly", "true");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("DeklaritType", "int");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Description", "IDPARTNER");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Length", "9");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnurapartnerIDPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "urapartnerIDPARTNER");
                this.Columns.Add(this.columnurapartnerIDPARTNER);
                this.columnURANAPOMENA = new DataColumn("URANAPOMENA", typeof(string), "", MappingType.Element);
                this.columnURANAPOMENA.Caption = "URANAPOMENA";
                this.columnURANAPOMENA.MaxLength = 50;
                this.columnURANAPOMENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnURANAPOMENA.ExtendedProperties.Add("IsKey", "false");
                this.columnURANAPOMENA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnURANAPOMENA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnURANAPOMENA.ExtendedProperties.Add("Description", "URANAPOMENA");
                this.columnURANAPOMENA.ExtendedProperties.Add("Length", "50");
                this.columnURANAPOMENA.ExtendedProperties.Add("Decimals", "0");
                this.columnURANAPOMENA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnURANAPOMENA.ExtendedProperties.Add("IsInReader", "true");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURANAPOMENA.ExtendedProperties.Add("Deklarit.InternalName", "URANAPOMENA");
                this.Columns.Add(this.columnURANAPOMENA);
                this.columnURAVALUTA = new DataColumn("URAVALUTA", typeof(DateTime), "", MappingType.Element);
                this.columnURAVALUTA.Caption = "URAVALUTA";
                this.columnURAVALUTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnURAVALUTA.ExtendedProperties.Add("IsKey", "false");
                this.columnURAVALUTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnURAVALUTA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnURAVALUTA.ExtendedProperties.Add("Description", "URAVALUTA");
                this.columnURAVALUTA.ExtendedProperties.Add("Length", "8");
                this.columnURAVALUTA.ExtendedProperties.Add("Decimals", "0");
                this.columnURAVALUTA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnURAVALUTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURAVALUTA.ExtendedProperties.Add("Deklarit.InternalName", "URAVALUTA");
                this.Columns.Add(this.columnURAVALUTA);
                this.columnURAUKUPNO = new DataColumn("URAUKUPNO", typeof(decimal), "", MappingType.Element);
                this.columnURAUKUPNO.Caption = "URAUKUPNO";
                this.columnURAUKUPNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnURAUKUPNO.ExtendedProperties.Add("IsKey", "false");
                this.columnURAUKUPNO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnURAUKUPNO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnURAUKUPNO.ExtendedProperties.Add("Description", "URAUKUPNO");
                this.columnURAUKUPNO.ExtendedProperties.Add("Length", "12");
                this.columnURAUKUPNO.ExtendedProperties.Add("Decimals", "2");
                this.columnURAUKUPNO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnURAUKUPNO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnURAUKUPNO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnURAUKUPNO.ExtendedProperties.Add("IsInReader", "true");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURAUKUPNO.ExtendedProperties.Add("Deklarit.InternalName", "URAUKUPNO");
                this.Columns.Add(this.columnURAUKUPNO);
                this.columnURADATUM = new DataColumn("URADATUM", typeof(DateTime), "", MappingType.Element);
                this.columnURADATUM.Caption = "URADATUM";
                this.columnURADATUM.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnURADATUM.ExtendedProperties.Add("IsKey", "false");
                this.columnURADATUM.ExtendedProperties.Add("ReadOnly", "true");
                this.columnURADATUM.ExtendedProperties.Add("DeklaritType", "date");
                this.columnURADATUM.ExtendedProperties.Add("Description", "URADATUM");
                this.columnURADATUM.ExtendedProperties.Add("Length", "8");
                this.columnURADATUM.ExtendedProperties.Add("Decimals", "0");
                this.columnURADATUM.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnURADATUM.ExtendedProperties.Add("IsInReader", "true");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURADATUM.ExtendedProperties.Add("Deklarit.InternalName", "URADATUM");
                this.Columns.Add(this.columnURADATUM);
                this.columnURAGODIDGODINE = new DataColumn("URAGODIDGODINE", typeof(short), "", MappingType.Element);
                this.columnURAGODIDGODINE.Caption = "IDGODINE";
                this.columnURAGODIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("SuperType", "IDGODINE");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("SubtypeGroup", "URAGOD");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("IsKey", "false");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Description", "IDGODINE");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURAGODIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "URAGODIDGODINE");
                this.Columns.Add(this.columnURAGODIDGODINE);
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
                this.columnURADOKIDDOKUMENT = new DataColumn("URADOKIDDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnURADOKIDDOKUMENT.Caption = "IDDOKUMENT";
                this.columnURADOKIDDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("SuperType", "IDDOKUMENT");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("SubtypeGroup", "URADOK");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Description", "IDDOKUMENT");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Length", "8");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "URADOKIDDOKUMENT");
                this.Columns.Add(this.columnURADOKIDDOKUMENT);
                this.columnPARTNEROIB = new DataColumn("PARTNEROIB", typeof(string), "", MappingType.Element);
                this.columnPARTNEROIB.Caption = "PARTNEROIB";
                this.columnPARTNEROIB.MaxLength = 25;
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
                this.columnPARTNEROIB.ExtendedProperties.Add("Length", "25");
                this.columnPARTNEROIB.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNEROIB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.InternalName", "PARTNEROIB");
                this.Columns.Add(this.columnPARTNEROIB);
                this.columnStatus = new DataColumn("Status", typeof(string), "", MappingType.Element);
                this.columnStatus.Caption = "";
                this.columnStatus.MaxLength = 15;
                this.columnStatus.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnStatus.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnStatus.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnStatus.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnStatus.ExtendedProperties.Add("IsKey", "false");
                this.columnStatus.ExtendedProperties.Add("ReadOnly", "true");
                this.columnStatus.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnStatus.ExtendedProperties.Add("Description", "");
                this.columnStatus.ExtendedProperties.Add("Length", "15");
                this.columnStatus.ExtendedProperties.Add("Decimals", "0");
                this.columnStatus.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnStatus.ExtendedProperties.Add("IsInReader", "true");
                this.columnStatus.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnStatus.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnStatus.ExtendedProperties.Add("Deklarit.InternalName", "Status");
                this.Columns.Add(this.columnStatus);
                this.columnURAMODEL = new DataColumn("URAMODEL", typeof(string), "", MappingType.Element);
                this.columnURAMODEL.Caption = "URAMODEL";
                this.columnURAMODEL.MaxLength = 2;
                this.columnURAMODEL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnURAMODEL.ExtendedProperties.Add("IsKey", "false");
                this.columnURAMODEL.ExtendedProperties.Add("ReadOnly", "true");
                this.columnURAMODEL.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnURAMODEL.ExtendedProperties.Add("Description", "URAMODEL");
                this.columnURAMODEL.ExtendedProperties.Add("Length", "2");
                this.columnURAMODEL.ExtendedProperties.Add("Decimals", "0");
                this.columnURAMODEL.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnURAMODEL.ExtendedProperties.Add("IsInReader", "true");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURAMODEL.ExtendedProperties.Add("Deklarit.InternalName", "URAMODEL");
                this.Columns.Add(this.columnURAMODEL);
                this.columnURAPOZIVNABROJ = new DataColumn("URAPOZIVNABROJ", typeof(string), "", MappingType.Element);
                this.columnURAPOZIVNABROJ.Caption = "";
                this.columnURAPOZIVNABROJ.MaxLength = 0x16;
                this.columnURAPOZIVNABROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Description", "");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Length", "22");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURAPOZIVNABROJ.ExtendedProperties.Add("Deklarit.InternalName", "URAPOZIVNABROJ");
                this.Columns.Add(this.columnURAPOZIVNABROJ);
                this.columnOSNOVICA0 = new DataColumn("OSNOVICA0", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA0.Caption = "Osnovica 0%";
                this.columnOSNOVICA0.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICA0.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA0.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICA0.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA0.ExtendedProperties.Add("Description", "Osnovica 0%");
                this.columnOSNOVICA0.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA0.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA0.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA0.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA0.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICA0.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA0.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA0");
                this.Columns.Add(this.columnOSNOVICA0);


                this.columnOSNOVICA5 = new DataColumn("OSNOVICA5", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA5.Caption = "Osnovica 5%";
                this.columnOSNOVICA5.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICA5.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA5.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICA5.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA5.ExtendedProperties.Add("Description", "Osnovica 5%");
                this.columnOSNOVICA5.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA5.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA5.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA5.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA5.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICA5.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA5.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA5");
                this.Columns.Add(this.columnOSNOVICA5);

                this.columnOSNOVICA10 = new DataColumn("OSNOVICA10", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA10.Caption = "Osnovica 10%";
                this.columnOSNOVICA10.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICA10.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA10.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICA10.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA10.ExtendedProperties.Add("Description", "Osnovica 10%");
                this.columnOSNOVICA10.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA10.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA10.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA10.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA10.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICA10.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA10.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA10");
                this.Columns.Add(this.columnOSNOVICA10);
                
                
                this.columnOSNOVICA22 = new DataColumn("OSNOVICA22", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA22.Caption = "OSNOVIC A22";
                this.columnOSNOVICA22.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICA22.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA22.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICA22.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA22.ExtendedProperties.Add("Description", "OSNOVIC A22");
                this.columnOSNOVICA22.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA22.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA22.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA22.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA22.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICA22.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA22.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA22");
                this.Columns.Add(this.columnOSNOVICA22);


                this.columnOSNOVICA23 = new DataColumn("OSNOVICA23", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA23.Caption = "OSNOVIC A23";
                this.columnOSNOVICA23.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICA23.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA23.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICA23.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA23.ExtendedProperties.Add("Description", "OSNOVIC A23");
                this.columnOSNOVICA23.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA23.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA23.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA23.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA23.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICA23.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA23.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA23");
                this.Columns.Add(this.columnOSNOVICA23);





                this.columnOSNOVICA25 = new DataColumn("OSNOVICA25", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA25.Caption = "OSNOVIC A25";
                this.columnOSNOVICA25.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICA25.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA25.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICA25.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA25.ExtendedProperties.Add("Description", "OSNOVIC A25");
                this.columnOSNOVICA25.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA25.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA25.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA25.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA25.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICA25.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA25.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA25");
                this.Columns.Add(this.columnOSNOVICA25);


                this.columnPDV5DA = new DataColumn("PDV5DA", typeof(decimal), "", MappingType.Element);
                this.columnPDV5DA.Caption = "PD V5 DA";
                this.columnPDV5DA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV5DA.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV5DA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV5DA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV5DA.ExtendedProperties.Add("Description", "PD V5 DA");
                this.columnPDV5DA.ExtendedProperties.Add("Length", "12");
                this.columnPDV5DA.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV5DA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV5DA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV5DA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV5DA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV5DA.ExtendedProperties.Add("Deklarit.InternalName", "PDV5DA");
                this.Columns.Add(this.columnPDV5DA);
                this.columnPDV5NE = new DataColumn("PDV5NE", typeof(decimal), "", MappingType.Element);
                this.columnPDV5NE.Caption = "PD V5 NE";
                this.columnPDV5NE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV5NE.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV5NE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV5NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV5NE.ExtendedProperties.Add("Description", "PD V5 NE");
                this.columnPDV5NE.ExtendedProperties.Add("Length", "12");
                this.columnPDV5NE.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV5NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV5NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV5NE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV5NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV5NE.ExtendedProperties.Add("Deklarit.InternalName", "PDV5NE");
                this.Columns.Add(this.columnPDV5NE);


                this.columnPDV10DA = new DataColumn("PDV10DA", typeof(decimal), "", MappingType.Element);
                this.columnPDV10DA.Caption = "PD V10 DA";
                this.columnPDV10DA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV10DA.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV10DA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV10DA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV10DA.ExtendedProperties.Add("Description", "PD V10 DA");
                this.columnPDV10DA.ExtendedProperties.Add("Length", "12");
                this.columnPDV10DA.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV10DA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV10DA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV10DA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV10DA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV10DA.ExtendedProperties.Add("Deklarit.InternalName", "PDV10DA");
                this.Columns.Add(this.columnPDV10DA);
                this.columnPDV10NE = new DataColumn("PDV10NE", typeof(decimal), "", MappingType.Element);
                this.columnPDV10NE.Caption = "PD V10 NE";
                this.columnPDV10NE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV10NE.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV10NE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV10NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV10NE.ExtendedProperties.Add("Description", "PD V10 NE");
                this.columnPDV10NE.ExtendedProperties.Add("Length", "12");
                this.columnPDV10NE.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV10NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV10NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV10NE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV10NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV10NE.ExtendedProperties.Add("Deklarit.InternalName", "PDV10NE");
                this.Columns.Add(this.columnPDV10NE);


                this.columnPDV22DA = new DataColumn("PDV22DA", typeof(decimal), "", MappingType.Element);
                this.columnPDV22DA.Caption = "PD V22 DA";
                this.columnPDV22DA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV22DA.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV22DA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV22DA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV22DA.ExtendedProperties.Add("Description", "PD V22 DA");
                this.columnPDV22DA.ExtendedProperties.Add("Length", "12");
                this.columnPDV22DA.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV22DA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV22DA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV22DA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV22DA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV22DA.ExtendedProperties.Add("Deklarit.InternalName", "PDV22DA");
                this.Columns.Add(this.columnPDV22DA);
                this.columnPDV22NE = new DataColumn("PDV22NE", typeof(decimal), "", MappingType.Element);
                this.columnPDV22NE.Caption = "PD V22 NE";
                this.columnPDV22NE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV22NE.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV22NE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV22NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV22NE.ExtendedProperties.Add("Description", "PD V22 NE");
                this.columnPDV22NE.ExtendedProperties.Add("Length", "12");
                this.columnPDV22NE.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV22NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV22NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV22NE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV22NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV22NE.ExtendedProperties.Add("Deklarit.InternalName", "PDV22NE");
                this.Columns.Add(this.columnPDV22NE);


                this.columnPDV23DA = new DataColumn("PDV23DA", typeof(decimal), "", MappingType.Element);
                this.columnPDV23DA.Caption = "PD V23 DA";
                this.columnPDV23DA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV23DA.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV23DA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV23DA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV23DA.ExtendedProperties.Add("Description", "PD V23 DA");
                this.columnPDV23DA.ExtendedProperties.Add("Length", "12");
                this.columnPDV23DA.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV23DA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV23DA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV23DA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV23DA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV23DA.ExtendedProperties.Add("Deklarit.InternalName", "PDV23DA");
                this.Columns.Add(this.columnPDV23DA);
                this.columnPDV23NE = new DataColumn("PDV23NE", typeof(decimal), "", MappingType.Element);
                this.columnPDV23NE.Caption = "PD V23 NE";
                this.columnPDV23NE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV23NE.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV23NE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV23NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV23NE.ExtendedProperties.Add("Description", "PD V23 NE");
                this.columnPDV23NE.ExtendedProperties.Add("Length", "12");
                this.columnPDV23NE.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV23NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV23NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV23NE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV23NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV23NE.ExtendedProperties.Add("Deklarit.InternalName", "PDV23NE");
                this.Columns.Add(this.columnPDV23NE);




                this.columnPDV25DA = new DataColumn("PDV25DA", typeof(decimal), "", MappingType.Element);
                this.columnPDV25DA.Caption = "PD V25 DA";
                this.columnPDV25DA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV25DA.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV25DA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV25DA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV25DA.ExtendedProperties.Add("Description", "PD V25 DA");
                this.columnPDV25DA.ExtendedProperties.Add("Length", "12");
                this.columnPDV25DA.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV25DA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV25DA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV25DA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV25DA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV25DA.ExtendedProperties.Add("Deklarit.InternalName", "PDV25DA");
                this.Columns.Add(this.columnPDV25DA);
                this.columnPDV25NE = new DataColumn("PDV25NE", typeof(decimal), "", MappingType.Element);
                this.columnPDV25NE.Caption = "PD V25 NE";
                this.columnPDV25NE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV25NE.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV25NE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV25NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV25NE.ExtendedProperties.Add("Description", "PD V25 NE");
                this.columnPDV25NE.ExtendedProperties.Add("Length", "12");
                this.columnPDV25NE.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV25NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV25NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV25NE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV25NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV25NE.ExtendedProperties.Add("Deklarit.InternalName", "PDV25NE");
                this.Columns.Add(this.columnPDV25NE);



                this.columnOSNOVICA5NE = new DataColumn("OSNOVICA5NE", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA5NE.Caption = "OSNOVIC A5 NE";
                this.columnOSNOVICA5NE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Description", "OSNOVIC A5 NE");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA5NE.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA5NE");
                this.Columns.Add(this.columnOSNOVICA5NE);



                this.columnOSNOVICA10NE = new DataColumn("OSNOVICA10NE", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA10NE.Caption = "OSNOVIC A10 NE";
                this.columnOSNOVICA10NE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Description", "OSNOVIC A10 NE");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA10NE.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA10NE");
                this.Columns.Add(this.columnOSNOVICA10NE);

                this.columnOSNOVICA23NE = new DataColumn("OSNOVICA23NE", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA23NE.Caption = "OSNOVIC A23 NE";
                this.columnOSNOVICA23NE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Description", "OSNOVIC A23 NE");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA23NE.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA23NE");
                this.Columns.Add(this.columnOSNOVICA23NE);

                this.columnOSNOVICA22NE = new DataColumn("OSNOVICA22NE", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA22NE.Caption = "OSNOVIC A22 NE";
                this.columnOSNOVICA22NE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Description", "OSNOVIC A22 NE");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA22NE.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA22NE");
                this.Columns.Add(this.columnOSNOVICA22NE);




                this.columnOSNOVICA25NE = new DataColumn("OSNOVICA25NE", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICA25NE.Caption = "OSNOVIC A25 NE";
                this.columnOSNOVICA25NE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Description", "OSNOVIC A25 NE");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICA25NE.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICA25NE");
                this.Columns.Add(this.columnOSNOVICA25NE);



                this.columnR2 = new DataColumn("R2", typeof(bool), "", MappingType.Element);
                this.columnR2.Caption = "R2";
                this.columnR2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnR2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnR2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnR2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnR2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnR2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnR2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnR2.ExtendedProperties.Add("IsKey", "false");
                this.columnR2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnR2.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnR2.ExtendedProperties.Add("Description", "R2");
                this.columnR2.ExtendedProperties.Add("Length", "1");
                this.columnR2.ExtendedProperties.Add("Decimals", "0");
                this.columnR2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnR2.ExtendedProperties.Add("IsInReader", "true");
                this.columnR2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnR2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnR2.ExtendedProperties.Add("Deklarit.InternalName", "R2");
                this.Columns.Add(this.columnR2);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "SP_FIN_URAPLACANJE");
                this.ExtendedProperties.Add("Description", "S_FIN_URA_PLACANJE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnZATVARANJE_IZNOS = this.Columns["ZATVARANJE_IZNOS"];
                this.columnZATVARANJE_DATUM = this.Columns["ZATVARANJE_DATUM"];
                this.columnURABROJ = this.Columns["URABROJ"];
                this.columnIDTIPURA = this.Columns["IDTIPURA"];
                this.columnURABROJRACUNADOBAVLJACA = this.Columns["URABROJRACUNADOBAVLJACA"];
                this.columnurapartnerIDPARTNER = this.Columns["urapartnerIDPARTNER"];
                this.columnURANAPOMENA = this.Columns["URANAPOMENA"];
                this.columnURAVALUTA = this.Columns["URAVALUTA"];
                this.columnURAUKUPNO = this.Columns["URAUKUPNO"];
                this.columnURADATUM = this.Columns["URADATUM"];
                this.columnURAGODIDGODINE = this.Columns["URAGODIDGODINE"];
                this.columnNAZIVPARTNER = this.Columns["NAZIVPARTNER"];
                this.columnMB = this.Columns["MB"];
                this.columnURADOKIDDOKUMENT = this.Columns["URADOKIDDOKUMENT"];
                this.columnPARTNEROIB = this.Columns["PARTNEROIB"];
                this.columnStatus = this.Columns["Status"];
                this.columnURAMODEL = this.Columns["URAMODEL"];
                this.columnURAPOZIVNABROJ = this.Columns["URAPOZIVNABROJ"];
                this.columnOSNOVICA0 = this.Columns["OSNOVICA0"];
                this.columnOSNOVICA5 = this.Columns["OSNOVICA5"];
                this.columnOSNOVICA10 = this.Columns["OSNOVICA10"];
                this.columnOSNOVICA22 = this.Columns["OSNOVICA22"];
                this.columnOSNOVICA23 = this.Columns["OSNOVICA23"];
                this.columnOSNOVICA25 = this.Columns["OSNOVICA25"];
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

                this.columnOSNOVICA5NE = this.Columns["OSNOVICA5NE"];
                this.columnOSNOVICA10NE = this.Columns["OSNOVICA10NE"];
                this.columnOSNOVICA23NE = this.Columns["OSNOVICA23NE"];
                this.columnOSNOVICA22NE = this.Columns["OSNOVICA22NE"];
                this.columnOSNOVICA25NE = this.Columns["OSNOVICA25NE"];
                this.columnR2 = this.Columns["R2"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow(builder);
            }

            public SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow NewSP_FIN_URAPLACANJERow()
            {
                return (SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SP_FIN_URAPLACANJERowChanged != null)
                {
                    SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERowChangeEventHandler handler = this.SP_FIN_URAPLACANJERowChanged;
                    if (handler != null)
                    {
                        handler(this, new SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERowChangeEvent((SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SP_FIN_URAPLACANJERowChanging != null)
                {
                    SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERowChangeEventHandler handler = this.SP_FIN_URAPLACANJERowChanging;
                    if (handler != null)
                    {
                        handler(this, new SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERowChangeEvent((SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SP_FIN_URAPLACANJERowDeleted != null)
                {
                    SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERowChangeEventHandler handler = this.SP_FIN_URAPLACANJERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERowChangeEvent((SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SP_FIN_URAPLACANJERowDeleting != null)
                {
                    SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERowChangeEventHandler handler = this.SP_FIN_URAPLACANJERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERowChangeEvent((SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSP_FIN_URAPLACANJERow(SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow row)
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

            public SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow this[int index]
            {
                get
                {
                    return (SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow) this.Rows[index];
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

            public DataColumn OSNOVICA0Column
            {
                get
                {
                    return this.columnOSNOVICA0;
                }
            }

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



            public DataColumn PARTNEROIBColumn
            {
                get
                {
                    return this.columnPARTNEROIB;
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

            public DataColumn StatusColumn
            {
                get
                {
                    return this.columnStatus;
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

            public DataColumn ZATVARANJE_DATUMColumn
            {
                get
                {
                    return this.columnZATVARANJE_DATUM;
                }
            }

            public DataColumn ZATVARANJE_IZNOSColumn
            {
                get
                {
                    return this.columnZATVARANJE_IZNOS;
                }
            }
        }

        public class SP_FIN_URAPLACANJERow : DataRow
        {
            private SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJEDataTable tableSP_FIN_URAPLACANJE;

            internal SP_FIN_URAPLACANJERow(DataRowBuilder rb) : base(rb)
            {
                this.tableSP_FIN_URAPLACANJE = (SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJEDataTable) this.Table;
            }

            public bool IsIDTIPURANull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.IDTIPURAColumn);
            }

            public bool IsMBNull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.MBColumn);
            }

            public bool IsNAZIVPARTNERNull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.NAZIVPARTNERColumn);
            }

            public bool IsOSNOVICA0Null()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.OSNOVICA0Column);
            }

            public bool IsOSNOVICA5NENull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.OSNOVICA5NEColumn);
            }

            public bool IsOSNOVICA5Null()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.OSNOVICA5Column);
            }

            public bool IsOSNOVICA10NENull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.OSNOVICA10NEColumn);
            }

            public bool IsOSNOVICA10Null()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.OSNOVICA10Column);
            }

            public bool IsOSNOVICA22NENull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.OSNOVICA22NEColumn);
            }

            public bool IsOSNOVICA22Null()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.OSNOVICA22Column);
            }

            public bool IsOSNOVICA23NENull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.OSNOVICA23NEColumn);
            }

            public bool IsOSNOVICA23Null()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.OSNOVICA23Column);
            }



            public bool IsOSNOVICA25NENull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.OSNOVICA25NEColumn);
            }

            public bool IsOSNOVICA25Null()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.OSNOVICA25Column);
            }



            public bool IsPARTNEROIBNull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.PARTNEROIBColumn);
            }

            public bool IsPDV5DANull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.PDV5DAColumn);
            }

            public bool IsPDV5NENull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.PDV5NEColumn);
            }

            public bool IsPDV10DANull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.PDV10DAColumn);
            }

            public bool IsPDV10NENull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.PDV10NEColumn);
            }

            public bool IsPDV22DANull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.PDV22DAColumn);
            }

            public bool IsPDV22NENull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.PDV22NEColumn);
            }

            public bool IsPDV23DANull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.PDV23DAColumn);
            }

            public bool IsPDV23NENull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.PDV23NEColumn);
            }



            public bool IsPDV25DANull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.PDV25DAColumn);
            }

            public bool IsPDV25NENull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.PDV25NEColumn);
            }



            public bool IsR2Null()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.R2Column);
            }

            public bool IsStatusNull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.StatusColumn);
            }

            public bool IsURABROJNull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.URABROJColumn);
            }

            public bool IsURABROJRACUNADOBAVLJACANull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.URABROJRACUNADOBAVLJACAColumn);
            }

            public bool IsURADATUMNull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.URADATUMColumn);
            }

            public bool IsURADOKIDDOKUMENTNull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.URADOKIDDOKUMENTColumn);
            }

            public bool IsURAGODIDGODINENull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.URAGODIDGODINEColumn);
            }

            public bool IsURAMODELNull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.URAMODELColumn);
            }

            public bool IsURANAPOMENANull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.URANAPOMENAColumn);
            }

            public bool IsurapartnerIDPARTNERNull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.urapartnerIDPARTNERColumn);
            }

            public bool IsURAPOZIVNABROJNull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.URAPOZIVNABROJColumn);
            }

            public bool IsURAUKUPNONull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.URAUKUPNOColumn);
            }

            public bool IsURAVALUTANull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.URAVALUTAColumn);
            }

            public bool IsZATVARANJE_DATUMNull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.ZATVARANJE_DATUMColumn);
            }

            public bool IsZATVARANJE_IZNOSNull()
            {
                return this.IsNull(this.tableSP_FIN_URAPLACANJE.ZATVARANJE_IZNOSColumn);
            }

            public void SetIDTIPURANull()
            {
                this[this.tableSP_FIN_URAPLACANJE.IDTIPURAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMBNull()
            {
                this[this.tableSP_FIN_URAPLACANJE.MBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPARTNERNull()
            {
                this[this.tableSP_FIN_URAPLACANJE.NAZIVPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA0Null()
            {
                this[this.tableSP_FIN_URAPLACANJE.OSNOVICA0Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA5NENull()
            {
                this[this.tableSP_FIN_URAPLACANJE.OSNOVICA5NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA5Null()
            {
                this[this.tableSP_FIN_URAPLACANJE.OSNOVICA5Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA10NENull()
            {
                this[this.tableSP_FIN_URAPLACANJE.OSNOVICA10NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA10Null()
            {
                this[this.tableSP_FIN_URAPLACANJE.OSNOVICA10Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA22NENull()
            {
                this[this.tableSP_FIN_URAPLACANJE.OSNOVICA22NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA22Null()
            {
                this[this.tableSP_FIN_URAPLACANJE.OSNOVICA22Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA23NENull()
            {
                this[this.tableSP_FIN_URAPLACANJE.OSNOVICA23NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA23Null()
            {
                this[this.tableSP_FIN_URAPLACANJE.OSNOVICA23Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }



            public void SetOSNOVICA25NENull()
            {
                this[this.tableSP_FIN_URAPLACANJE.OSNOVICA25NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICA25Null()
            {
                this[this.tableSP_FIN_URAPLACANJE.OSNOVICA25Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }



            public void SetPARTNEROIBNull()
            {
                this[this.tableSP_FIN_URAPLACANJE.PARTNEROIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV5DANull()
            {
                this[this.tableSP_FIN_URAPLACANJE.PDV5DAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV5NENull()
            {
                this[this.tableSP_FIN_URAPLACANJE.PDV5NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV10DANull()
            {
                this[this.tableSP_FIN_URAPLACANJE.PDV10DAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV10NENull()
            {
                this[this.tableSP_FIN_URAPLACANJE.PDV10NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV22DANull()
            {
                this[this.tableSP_FIN_URAPLACANJE.PDV22DAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV22NENull()
            {
                this[this.tableSP_FIN_URAPLACANJE.PDV22NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV23DANull()
            {
                this[this.tableSP_FIN_URAPLACANJE.PDV23DAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV23NENull()
            {
                this[this.tableSP_FIN_URAPLACANJE.PDV23NEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetR2Null()
            {
                this[this.tableSP_FIN_URAPLACANJE.R2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetStatusNull()
            {
                this[this.tableSP_FIN_URAPLACANJE.StatusColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURABROJNull()
            {
                this[this.tableSP_FIN_URAPLACANJE.URABROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURABROJRACUNADOBAVLJACANull()
            {
                this[this.tableSP_FIN_URAPLACANJE.URABROJRACUNADOBAVLJACAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURADATUMNull()
            {
                this[this.tableSP_FIN_URAPLACANJE.URADATUMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURADOKIDDOKUMENTNull()
            {
                this[this.tableSP_FIN_URAPLACANJE.URADOKIDDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURAGODIDGODINENull()
            {
                this[this.tableSP_FIN_URAPLACANJE.URAGODIDGODINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURAMODELNull()
            {
                this[this.tableSP_FIN_URAPLACANJE.URAMODELColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURANAPOMENANull()
            {
                this[this.tableSP_FIN_URAPLACANJE.URANAPOMENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SeturapartnerIDPARTNERNull()
            {
                this[this.tableSP_FIN_URAPLACANJE.urapartnerIDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURAPOZIVNABROJNull()
            {
                this[this.tableSP_FIN_URAPLACANJE.URAPOZIVNABROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURAUKUPNONull()
            {
                this[this.tableSP_FIN_URAPLACANJE.URAUKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetURAVALUTANull()
            {
                this[this.tableSP_FIN_URAPLACANJE.URAVALUTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZATVARANJE_DATUMNull()
            {
                this[this.tableSP_FIN_URAPLACANJE.ZATVARANJE_DATUMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZATVARANJE_IZNOSNull()
            {
                this[this.tableSP_FIN_URAPLACANJE.ZATVARANJE_IZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDTIPURA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSP_FIN_URAPLACANJE.IDTIPURAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.IDTIPURAColumn] = value;
                }
            }

            public string MB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSP_FIN_URAPLACANJE.MBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.MBColumn] = value;
                }
            }

            public string NAZIVPARTNER
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSP_FIN_URAPLACANJE.NAZIVPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.NAZIVPARTNERColumn] = value;
                }
            }

            public decimal OSNOVICA0
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.OSNOVICA0Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.OSNOVICA0Column] = value;
                }
            }

            public decimal OSNOVICA5
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.OSNOVICA5Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.OSNOVICA5Column] = value;
                }
            }

            public decimal OSNOVICA5NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.OSNOVICA5NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.OSNOVICA5NEColumn] = value;
                }
            }

            public decimal OSNOVICA10
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.OSNOVICA10Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.OSNOVICA10Column] = value;
                }
            }

            public decimal OSNOVICA10NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.OSNOVICA10NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.OSNOVICA10NEColumn] = value;
                }
            }

            public decimal OSNOVICA22
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.OSNOVICA22Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.OSNOVICA22Column] = value;
                }
            }

            public decimal OSNOVICA22NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.OSNOVICA22NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.OSNOVICA22NEColumn] = value;
                }
            }

            public decimal OSNOVICA23
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.OSNOVICA23Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.OSNOVICA23Column] = value;
                }
            }

            public decimal OSNOVICA23NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.OSNOVICA23NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.OSNOVICA23NEColumn] = value;
                }
            }




            public decimal OSNOVICA25
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.OSNOVICA25Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.OSNOVICA25Column] = value;
                }
            }

            public decimal OSNOVICA25NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.OSNOVICA25NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.OSNOVICA25NEColumn] = value;
                }
            }




            public string PARTNEROIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSP_FIN_URAPLACANJE.PARTNEROIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.PARTNEROIBColumn] = value;
                }
            }

            public decimal PDV5DA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.PDV5DAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.PDV5DAColumn] = value;
                }
            }

            public decimal PDV5NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.PDV5NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.PDV5NEColumn] = value;
                }
            }

            public decimal PDV10DA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.PDV10DAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.PDV10DAColumn] = value;
                }
            }

            public decimal PDV10NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.PDV10NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.PDV10NEColumn] = value;
                }
            }

            public decimal PDV22DA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.PDV22DAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.PDV22DAColumn] = value;
                }
            }

            public decimal PDV22NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.PDV22NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.PDV22NEColumn] = value;
                }
            }

            public decimal PDV23DA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.PDV23DAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.PDV23DAColumn] = value;
                }
            }

            public decimal PDV23NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.PDV23NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.PDV23NEColumn] = value;
                }
            }

            public decimal PDV25DA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.PDV25DAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.PDV25DAColumn] = value;
                }
            }

            public decimal PDV25NE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.PDV25NEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.PDV25NEColumn] = value;
                }
            }

            public bool R2
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableSP_FIN_URAPLACANJE.R2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.R2Column] = value;
                }
            }

            public string Status
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSP_FIN_URAPLACANJE.StatusColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.StatusColumn] = value;
                }
            }

            public int URABROJ
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSP_FIN_URAPLACANJE.URABROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.URABROJColumn] = value;
                }
            }

            public string URABROJRACUNADOBAVLJACA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSP_FIN_URAPLACANJE.URABROJRACUNADOBAVLJACAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.URABROJRACUNADOBAVLJACAColumn] = value;
                }
            }

            public DateTime URADATUM
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableSP_FIN_URAPLACANJE.URADATUMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.URADATUMColumn] = value;
                }
            }

            public int URADOKIDDOKUMENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSP_FIN_URAPLACANJE.URADOKIDDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.URADOKIDDOKUMENTColumn] = value;
                }
            }

            public short URAGODIDGODINE
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableSP_FIN_URAPLACANJE.URAGODIDGODINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.URAGODIDGODINEColumn] = value;
                }
            }

            public string URAMODEL
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSP_FIN_URAPLACANJE.URAMODELColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.URAMODELColumn] = value;
                }
            }

            public string URANAPOMENA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSP_FIN_URAPLACANJE.URANAPOMENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.URANAPOMENAColumn] = value;
                }
            }

            public int urapartnerIDPARTNER
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSP_FIN_URAPLACANJE.urapartnerIDPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.urapartnerIDPARTNERColumn] = value;
                }
            }

            public string URAPOZIVNABROJ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSP_FIN_URAPLACANJE.URAPOZIVNABROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.URAPOZIVNABROJColumn] = value;
                }
            }

            public decimal URAUKUPNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.URAUKUPNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.URAUKUPNOColumn] = value;
                }
            }

            public DateTime URAVALUTA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableSP_FIN_URAPLACANJE.URAVALUTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.URAVALUTAColumn] = value;
                }
            }

            public DateTime ZATVARANJE_DATUM
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableSP_FIN_URAPLACANJE.ZATVARANJE_DATUMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.ZATVARANJE_DATUMColumn] = value;
                }
            }

            public decimal ZATVARANJE_IZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_FIN_URAPLACANJE.ZATVARANJE_IZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_FIN_URAPLACANJE.ZATVARANJE_IZNOSColumn] = value;
                }
            }
        }

        public class SP_FIN_URAPLACANJERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow eventRow;

            public SP_FIN_URAPLACANJERowChangeEvent(SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow row, DataRowAction action)
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

            public SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SP_FIN_URAPLACANJERowChangeEventHandler(object sender, SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERowChangeEvent e);
    }
}

