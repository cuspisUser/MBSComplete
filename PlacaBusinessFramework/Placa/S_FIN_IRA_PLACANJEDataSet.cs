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
    public class S_FIN_IRA_PLACANJEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_FIN_IRA_PLACANJEDataTable tableS_FIN_IRA_PLACANJE;

        public S_FIN_IRA_PLACANJEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_FIN_IRA_PLACANJEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_FIN_IRA_PLACANJE"] != null)
                    {
                        this.Tables.Add(new S_FIN_IRA_PLACANJEDataTable(dataSet.Tables["S_FIN_IRA_PLACANJE"]));
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
            S_FIN_IRA_PLACANJEDataSet set = (S_FIN_IRA_PLACANJEDataSet) base.Clone();
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
            S_FIN_IRA_PLACANJEDataSet set = new S_FIN_IRA_PLACANJEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_FIN_IRA_PLACANJEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2045");
            this.ExtendedProperties.Add("DataSetName", "S_FIN_IRA_PLACANJEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_FIN_IRA_PLACANJEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_FIN_IRA_PLACANJE");
            this.ExtendedProperties.Add("ObjectDescription", "S_FIN_IRA_PLACANJE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_FIN_IRA_PLACANJE");
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
            this.DataSetName = "S_FIN_IRA_PLACANJEDataSet";
            this.Namespace = "http://www.tempuri.org/S_FIN_IRA_PLACANJE";
            this.tableS_FIN_IRA_PLACANJE = new S_FIN_IRA_PLACANJEDataTable();
            this.Tables.Add(this.tableS_FIN_IRA_PLACANJE);
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
            this.tableS_FIN_IRA_PLACANJE = (S_FIN_IRA_PLACANJEDataTable) this.Tables["S_FIN_IRA_PLACANJE"];
            if (initTable && (this.tableS_FIN_IRA_PLACANJE != null))
            {
                this.tableS_FIN_IRA_PLACANJE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_FIN_IRA_PLACANJE"] != null)
                {
                    this.Tables.Add(new S_FIN_IRA_PLACANJEDataTable(dataSet.Tables["S_FIN_IRA_PLACANJE"]));
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

        private bool ShouldSerializeS_FIN_IRA_PLACANJE()
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
        public S_FIN_IRA_PLACANJEDataTable S_FIN_IRA_PLACANJE
        {
            get
            {
                return this.tableS_FIN_IRA_PLACANJE;
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
        public class S_FIN_IRA_PLACANJEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDTIPIRA;
            private DataColumn columnIRABROJ;
            private DataColumn columnIRADATUM;
            private DataColumn columnIRADOKIDDOKUMENT;
            private DataColumn columnIRAGODIDGODINE;
            private DataColumn columnIRANAPOMENA;
            private DataColumn columnIRAPARTNERIDPARTNER;
            private DataColumn columnIRAUKUPNO;
            private DataColumn columnIRAVALUTA;
            private DataColumn columnIZVOZ;
            private DataColumn columnMEDJTRANS;
            private DataColumn columnNAZIVPARTNER;
            private DataColumn columnNEPODLEZE;
            private DataColumn columnNULA;
            private DataColumn columnOSN10;
            private DataColumn columnOSN22;
            private DataColumn columnOSN23;
            private DataColumn columnOSN25;
            private DataColumn columnOSTALO;
            private DataColumn columnPARTNEROIB;
            private DataColumn columnPDV10;
            private DataColumn columnPDV22;
            private DataColumn columnPDV23;
            private DataColumn columnPDV25;
            private DataColumn columnStatus;
            private DataColumn columnTUZEMSTVO;
            private DataColumn columnZATVARANJE_DATUM;
            private DataColumn columnZATVARANJE_IZNOS;

            public event S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERowChangeEventHandler S_FIN_IRA_PLACANJERowChanged;

            public event S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERowChangeEventHandler S_FIN_IRA_PLACANJERowChanging;

            public event S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERowChangeEventHandler S_FIN_IRA_PLACANJERowDeleted;

            public event S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERowChangeEventHandler S_FIN_IRA_PLACANJERowDeleting;

            public S_FIN_IRA_PLACANJEDataTable()
            {
                this.TableName = "S_FIN_IRA_PLACANJE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_FIN_IRA_PLACANJEDataTable(DataTable table) : base(table.TableName)
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

            protected S_FIN_IRA_PLACANJEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_FIN_IRA_PLACANJERow(S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow row)
            {
                this.Rows.Add(row);
            }

            public S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow AddS_FIN_IRA_PLACANJERow(decimal zATVARANJE_IZNOS, DateTime zATVARANJE_DATUM, int iRABROJ, int iDTIPIRA, int iRAPARTNERIDPARTNER, 
                decimal iRAUKUPNO, DateTime iRAVALUTA, string iRANAPOMENA, DateTime iRADATUM, short iRAGODIDGODINE, int iRADOKIDDOKUMENT, string nAZIVPARTNER, string pARTNEROIB, string status,
                decimal nEPODLEZE, decimal iZVOZ, decimal mEDJTRANS, decimal tUZEMSTVO, decimal oSTALO, decimal nULA, decimal oSN10, decimal oSN22, decimal oSN23, decimal oSN25,
                decimal pDV10, decimal pDV22, decimal pDV23, decimal pDV25)
            {
                S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow row = (S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow) this.NewRow();
                row.ItemArray = new object[] { 
                    zATVARANJE_IZNOS, zATVARANJE_DATUM, iRABROJ, iDTIPIRA, iRAPARTNERIDPARTNER, iRAUKUPNO, iRAVALUTA, iRANAPOMENA, iRADATUM, iRAGODIDGODINE, iRADOKIDDOKUMENT, nAZIVPARTNER, pARTNEROIB, status, nEPODLEZE, iZVOZ, 
                    mEDJTRANS, tUZEMSTVO, oSTALO, nULA, oSN10, oSN22, oSN23, oSN25, pDV10, pDV22, pDV23, pDV25
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJEDataTable table = (S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_FIN_IRA_PLACANJEDataSet set = new S_FIN_IRA_PLACANJEDataSet();
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
                this.columnIRABROJ = new DataColumn("IRABROJ", typeof(int), "", MappingType.Element);
                this.columnIRABROJ.Caption = "IRABROJ";
                this.columnIRABROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIRABROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnIRABROJ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIRABROJ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIRABROJ.ExtendedProperties.Add("Description", "IRABROJ");
                this.columnIRABROJ.ExtendedProperties.Add("Length", "8");
                this.columnIRABROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnIRABROJ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIRABROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.InternalName", "IRABROJ");
                this.Columns.Add(this.columnIRABROJ);
                this.columnIDTIPIRA = new DataColumn("IDTIPIRA", typeof(int), "", MappingType.Element);
                this.columnIDTIPIRA.Caption = "IDTIPIRA";
                this.columnIDTIPIRA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDTIPIRA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDTIPIRA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDTIPIRA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPIRA.ExtendedProperties.Add("Description", "IDTIPIRA");
                this.columnIDTIPIRA.ExtendedProperties.Add("Length", "5");
                this.columnIDTIPIRA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPIRA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDTIPIRA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPIRA");
                this.Columns.Add(this.columnIDTIPIRA);
                this.columnIRAPARTNERIDPARTNER = new DataColumn("IRAPARTNERIDPARTNER", typeof(int), "", MappingType.Element);
                this.columnIRAPARTNERIDPARTNER.Caption = "Šifra partnera";
                this.columnIRAPARTNERIDPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("SuperType", "IDPARTNER");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("SubtypeGroup", "IRAPARTNER");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Description", "Šifra partnera");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Length", "9");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "IRAPARTNERIDPARTNER");
                this.Columns.Add(this.columnIRAPARTNERIDPARTNER);
                this.columnIRAUKUPNO = new DataColumn("IRAUKUPNO", typeof(decimal), "", MappingType.Element);
                this.columnIRAUKUPNO.Caption = "IRAUKUPNO";
                this.columnIRAUKUPNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIRAUKUPNO.ExtendedProperties.Add("IsKey", "false");
                this.columnIRAUKUPNO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIRAUKUPNO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Description", "IRAUKUPNO");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Length", "12");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Decimals", "2");
                this.columnIRAUKUPNO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIRAUKUPNO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIRAUKUPNO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIRAUKUPNO.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.InternalName", "IRAUKUPNO");
                this.Columns.Add(this.columnIRAUKUPNO);
                this.columnIRAVALUTA = new DataColumn("IRAVALUTA", typeof(DateTime), "", MappingType.Element);
                this.columnIRAVALUTA.Caption = "IRAVALUTA";
                this.columnIRAVALUTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIRAVALUTA.ExtendedProperties.Add("IsKey", "false");
                this.columnIRAVALUTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIRAVALUTA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnIRAVALUTA.ExtendedProperties.Add("Description", "IRAVALUTA");
                this.columnIRAVALUTA.ExtendedProperties.Add("Length", "8");
                this.columnIRAVALUTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIRAVALUTA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIRAVALUTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.InternalName", "IRAVALUTA");
                this.Columns.Add(this.columnIRAVALUTA);
                this.columnIRANAPOMENA = new DataColumn("IRANAPOMENA", typeof(string), "", MappingType.Element);
                this.columnIRANAPOMENA.Caption = "IRANAPOMENA";
                this.columnIRANAPOMENA.MaxLength = 50;
                this.columnIRANAPOMENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIRANAPOMENA.ExtendedProperties.Add("IsKey", "false");
                this.columnIRANAPOMENA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIRANAPOMENA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Description", "IRANAPOMENA");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Length", "50");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Decimals", "0");
                this.columnIRANAPOMENA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIRANAPOMENA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.InternalName", "IRANAPOMENA");
                this.Columns.Add(this.columnIRANAPOMENA);
                this.columnIRADATUM = new DataColumn("IRADATUM", typeof(DateTime), "", MappingType.Element);
                this.columnIRADATUM.Caption = "IRADATUM";
                this.columnIRADATUM.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIRADATUM.ExtendedProperties.Add("IsKey", "false");
                this.columnIRADATUM.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIRADATUM.ExtendedProperties.Add("DeklaritType", "date");
                this.columnIRADATUM.ExtendedProperties.Add("Description", "IRADATUM");
                this.columnIRADATUM.ExtendedProperties.Add("Length", "8");
                this.columnIRADATUM.ExtendedProperties.Add("Decimals", "0");
                this.columnIRADATUM.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIRADATUM.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.InternalName", "IRADATUM");
                this.Columns.Add(this.columnIRADATUM);
                this.columnIRAGODIDGODINE = new DataColumn("IRAGODIDGODINE", typeof(short), "", MappingType.Element);
                this.columnIRAGODIDGODINE.Caption = "IDGODINE";
                this.columnIRAGODIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("SuperType", "IDGODINE");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("SubtypeGroup", "IRAGOD");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("IsKey", "false");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Description", "IDGODINE");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "IRAGODIDGODINE");
                this.Columns.Add(this.columnIRAGODIDGODINE);
                this.columnIRADOKIDDOKUMENT = new DataColumn("IRADOKIDDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnIRADOKIDDOKUMENT.Caption = "Šifra dokumenta";
                this.columnIRADOKIDDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "#######");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "#######");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("SuperType", "IDDOKUMENT");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("SubtypeGroup", "IRADOK");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Description", "Šifra dokumenta");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Length", "8");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "IRADOKIDDOKUMENT");
                this.Columns.Add(this.columnIRADOKIDDOKUMENT);
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
                this.columnNEPODLEZE = new DataColumn("NEPODLEZE", typeof(decimal), "", MappingType.Element);
                this.columnNEPODLEZE.Caption = "NEPODLEZE";
                this.columnNEPODLEZE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNEPODLEZE.ExtendedProperties.Add("IsKey", "false");
                this.columnNEPODLEZE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNEPODLEZE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNEPODLEZE.ExtendedProperties.Add("Description", "NEPODLEZE");
                this.columnNEPODLEZE.ExtendedProperties.Add("Length", "12");
                this.columnNEPODLEZE.ExtendedProperties.Add("Decimals", "2");
                this.columnNEPODLEZE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNEPODLEZE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNEPODLEZE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNEPODLEZE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.InternalName", "NEPODLEZE");
                this.Columns.Add(this.columnNEPODLEZE);
                this.columnIZVOZ = new DataColumn("IZVOZ", typeof(decimal), "", MappingType.Element);
                this.columnIZVOZ.Caption = "IZVOZ";
                this.columnIZVOZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZVOZ.ExtendedProperties.Add("IsKey", "false");
                this.columnIZVOZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZVOZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZVOZ.ExtendedProperties.Add("Description", "IZVOZ");
                this.columnIZVOZ.ExtendedProperties.Add("Length", "12");
                this.columnIZVOZ.ExtendedProperties.Add("Decimals", "2");
                this.columnIZVOZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZVOZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZVOZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZVOZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.InternalName", "IZVOZ");
                this.Columns.Add(this.columnIZVOZ);
                this.columnMEDJTRANS = new DataColumn("MEDJTRANS", typeof(decimal), "", MappingType.Element);
                this.columnMEDJTRANS.Caption = "MEDJTRANS";
                this.columnMEDJTRANS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMEDJTRANS.ExtendedProperties.Add("IsKey", "false");
                this.columnMEDJTRANS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMEDJTRANS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMEDJTRANS.ExtendedProperties.Add("Description", "MEDJTRANS");
                this.columnMEDJTRANS.ExtendedProperties.Add("Length", "12");
                this.columnMEDJTRANS.ExtendedProperties.Add("Decimals", "2");
                this.columnMEDJTRANS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMEDJTRANS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMEDJTRANS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMEDJTRANS.ExtendedProperties.Add("IsInReader", "true");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.InternalName", "MEDJTRANS");
                this.Columns.Add(this.columnMEDJTRANS);
                this.columnTUZEMSTVO = new DataColumn("TUZEMSTVO", typeof(decimal), "", MappingType.Element);
                this.columnTUZEMSTVO.Caption = "TUZEMSTVO";
                this.columnTUZEMSTVO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnTUZEMSTVO.ExtendedProperties.Add("IsKey", "false");
                this.columnTUZEMSTVO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnTUZEMSTVO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Description", "TUZEMSTVO");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Length", "12");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Decimals", "2");
                this.columnTUZEMSTVO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnTUZEMSTVO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnTUZEMSTVO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnTUZEMSTVO.ExtendedProperties.Add("IsInReader", "true");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.InternalName", "TUZEMSTVO");
                this.Columns.Add(this.columnTUZEMSTVO);
                this.columnOSTALO = new DataColumn("OSTALO", typeof(decimal), "", MappingType.Element);
                this.columnOSTALO.Caption = "OSTALO";
                this.columnOSTALO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSTALO.ExtendedProperties.Add("IsKey", "false");
                this.columnOSTALO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSTALO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSTALO.ExtendedProperties.Add("Description", "OSTALO");
                this.columnOSTALO.ExtendedProperties.Add("Length", "12");
                this.columnOSTALO.ExtendedProperties.Add("Decimals", "2");
                this.columnOSTALO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSTALO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSTALO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSTALO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.InternalName", "OSTALO");
                this.Columns.Add(this.columnOSTALO);
                this.columnNULA = new DataColumn("NULA", typeof(decimal), "", MappingType.Element);
                this.columnNULA.Caption = "NULA";
                this.columnNULA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNULA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNULA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNULA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNULA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNULA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNULA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNULA.ExtendedProperties.Add("IsKey", "false");
                this.columnNULA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNULA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNULA.ExtendedProperties.Add("Description", "NULA");
                this.columnNULA.ExtendedProperties.Add("Length", "12");
                this.columnNULA.ExtendedProperties.Add("Decimals", "2");
                this.columnNULA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNULA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNULA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNULA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNULA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNULA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNULA.ExtendedProperties.Add("Deklarit.InternalName", "NULA");
                this.Columns.Add(this.columnNULA);
                this.columnOSN10 = new DataColumn("OSN10", typeof(decimal), "", MappingType.Element);
                this.columnOSN10.Caption = "OS N10";
                this.columnOSN10.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSN10.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSN10.ExtendedProperties.Add("IsKey", "false");
                this.columnOSN10.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSN10.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSN10.ExtendedProperties.Add("Description", "OS N10");
                this.columnOSN10.ExtendedProperties.Add("Length", "12");
                this.columnOSN10.ExtendedProperties.Add("Decimals", "2");
                this.columnOSN10.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSN10.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSN10.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSN10.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.InternalName", "OSN10");
                this.Columns.Add(this.columnOSN10);
                this.columnOSN22 = new DataColumn("OSN22", typeof(decimal), "", MappingType.Element);
                this.columnOSN22.Caption = "OS N22";
                this.columnOSN22.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSN22.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSN22.ExtendedProperties.Add("IsKey", "false");
                this.columnOSN22.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSN22.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSN22.ExtendedProperties.Add("Description", "OS N22");
                this.columnOSN22.ExtendedProperties.Add("Length", "12");
                this.columnOSN22.ExtendedProperties.Add("Decimals", "2");
                this.columnOSN22.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSN22.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSN22.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSN22.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.InternalName", "OSN22");
                this.Columns.Add(this.columnOSN22);


                this.columnOSN23 = new DataColumn("OSN23", typeof(decimal), "", MappingType.Element);
                this.columnOSN23.Caption = "OS N23";
                this.columnOSN23.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSN23.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSN23.ExtendedProperties.Add("IsKey", "false");
                this.columnOSN23.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSN23.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSN23.ExtendedProperties.Add("Description", "OS N23");
                this.columnOSN23.ExtendedProperties.Add("Length", "12");
                this.columnOSN23.ExtendedProperties.Add("Decimals", "2");
                this.columnOSN23.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSN23.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSN23.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSN23.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.InternalName", "OSN23");
                this.Columns.Add(this.columnOSN23);




                this.columnOSN25 = new DataColumn("OSN25", typeof(decimal), "", MappingType.Element);
                this.columnOSN25.Caption = "OS N25";
                this.columnOSN25.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSN25.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSN25.ExtendedProperties.Add("IsKey", "false");
                this.columnOSN25.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSN25.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSN25.ExtendedProperties.Add("Description", "OS N25");
                this.columnOSN25.ExtendedProperties.Add("Length", "12");
                this.columnOSN25.ExtendedProperties.Add("Decimals", "2");
                this.columnOSN25.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSN25.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSN25.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSN25.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.InternalName", "OSN25");
                this.Columns.Add(this.columnOSN25);




                this.columnPDV10 = new DataColumn("PDV10", typeof(decimal), "", MappingType.Element);
                this.columnPDV10.Caption = "PD V10";
                this.columnPDV10.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV10.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV10.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV10.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV10.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV10.ExtendedProperties.Add("Description", "PD V10");
                this.columnPDV10.ExtendedProperties.Add("Length", "12");
                this.columnPDV10.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV10.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV10.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV10.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV10.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.InternalName", "PDV10");
                this.Columns.Add(this.columnPDV10);
                this.columnPDV22 = new DataColumn("PDV22", typeof(decimal), "", MappingType.Element);
                this.columnPDV22.Caption = "PD V22";
                this.columnPDV22.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV22.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV22.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV22.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV22.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV22.ExtendedProperties.Add("Description", "PD V22");
                this.columnPDV22.ExtendedProperties.Add("Length", "12");
                this.columnPDV22.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV22.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV22.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV22.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV22.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.InternalName", "PDV22");
                this.Columns.Add(this.columnPDV22);


                this.columnPDV23 = new DataColumn("PDV23", typeof(decimal), "", MappingType.Element);
                this.columnPDV23.Caption = "PD V23";
                this.columnPDV23.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV23.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV23.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV23.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV23.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV23.ExtendedProperties.Add("Description", "PD V23");
                this.columnPDV23.ExtendedProperties.Add("Length", "12");
                this.columnPDV23.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV23.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV23.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV23.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV23.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.InternalName", "PDV23");
                this.Columns.Add(this.columnPDV23);





                this.columnPDV25 = new DataColumn("PDV25", typeof(decimal), "", MappingType.Element);
                this.columnPDV25.Caption = "PD V25";
                this.columnPDV25.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV25.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDV25.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV25.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV25.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV25.ExtendedProperties.Add("Description", "PD V25");
                this.columnPDV25.ExtendedProperties.Add("Length", "12");
                this.columnPDV25.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV25.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV25.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV25.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV25.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.InternalName", "PDV25");
                this.Columns.Add(this.columnPDV25);



                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_FIN_IRA_PLACANJE");
                this.ExtendedProperties.Add("Description", "S_FIN_IRA_PLACANJE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnZATVARANJE_IZNOS = this.Columns["ZATVARANJE_IZNOS"];
                this.columnZATVARANJE_DATUM = this.Columns["ZATVARANJE_DATUM"];
                this.columnIRABROJ = this.Columns["IRABROJ"];
                this.columnIDTIPIRA = this.Columns["IDTIPIRA"];
                this.columnIRAPARTNERIDPARTNER = this.Columns["IRAPARTNERIDPARTNER"];
                this.columnIRAUKUPNO = this.Columns["IRAUKUPNO"];
                this.columnIRAVALUTA = this.Columns["IRAVALUTA"];
                this.columnIRANAPOMENA = this.Columns["IRANAPOMENA"];
                this.columnIRADATUM = this.Columns["IRADATUM"];
                this.columnIRAGODIDGODINE = this.Columns["IRAGODIDGODINE"];
                this.columnIRADOKIDDOKUMENT = this.Columns["IRADOKIDDOKUMENT"];
                this.columnNAZIVPARTNER = this.Columns["NAZIVPARTNER"];
                this.columnPARTNEROIB = this.Columns["PARTNEROIB"];
                this.columnStatus = this.Columns["Status"];
                this.columnNEPODLEZE = this.Columns["NEPODLEZE"];
                this.columnIZVOZ = this.Columns["IZVOZ"];
                this.columnMEDJTRANS = this.Columns["MEDJTRANS"];
                this.columnTUZEMSTVO = this.Columns["TUZEMSTVO"];
                this.columnOSTALO = this.Columns["OSTALO"];
                this.columnNULA = this.Columns["NULA"];
                this.columnOSN10 = this.Columns["OSN10"];
                this.columnOSN22 = this.Columns["OSN22"];
                this.columnOSN23 = this.Columns["OSN23"];
                this.columnOSN25 = this.Columns["OSN25"];
                this.columnPDV10 = this.Columns["PDV10"];
                this.columnPDV22 = this.Columns["PDV22"];
                this.columnPDV23 = this.Columns["PDV23"];
                this.columnPDV25 = this.Columns["PDV25"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow(builder);
            }

            public S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow NewS_FIN_IRA_PLACANJERow()
            {
                return (S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_FIN_IRA_PLACANJERowChanged != null)
                {
                    S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERowChangeEventHandler handler = this.S_FIN_IRA_PLACANJERowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERowChangeEvent((S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_FIN_IRA_PLACANJERowChanging != null)
                {
                    S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERowChangeEventHandler handler = this.S_FIN_IRA_PLACANJERowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERowChangeEvent((S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_FIN_IRA_PLACANJERowDeleted != null)
                {
                    S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERowChangeEventHandler handler = this.S_FIN_IRA_PLACANJERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERowChangeEvent((S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_FIN_IRA_PLACANJERowDeleting != null)
                {
                    S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERowChangeEventHandler handler = this.S_FIN_IRA_PLACANJERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERowChangeEvent((S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_FIN_IRA_PLACANJERow(S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow row)
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

            public DataColumn IDTIPIRAColumn
            {
                get
                {
                    return this.columnIDTIPIRA;
                }
            }

            public DataColumn IRABROJColumn
            {
                get
                {
                    return this.columnIRABROJ;
                }
            }

            public DataColumn IRADATUMColumn
            {
                get
                {
                    return this.columnIRADATUM;
                }
            }

            public DataColumn IRADOKIDDOKUMENTColumn
            {
                get
                {
                    return this.columnIRADOKIDDOKUMENT;
                }
            }

            public DataColumn IRAGODIDGODINEColumn
            {
                get
                {
                    return this.columnIRAGODIDGODINE;
                }
            }

            public DataColumn IRANAPOMENAColumn
            {
                get
                {
                    return this.columnIRANAPOMENA;
                }
            }

            public DataColumn IRAPARTNERIDPARTNERColumn
            {
                get
                {
                    return this.columnIRAPARTNERIDPARTNER;
                }
            }

            public DataColumn IRAUKUPNOColumn
            {
                get
                {
                    return this.columnIRAUKUPNO;
                }
            }

            public DataColumn IRAVALUTAColumn
            {
                get
                {
                    return this.columnIRAVALUTA;
                }
            }

            public S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow this[int index]
            {
                get
                {
                    return (S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow) this.Rows[index];
                }
            }

            public DataColumn IZVOZColumn
            {
                get
                {
                    return this.columnIZVOZ;
                }
            }

            public DataColumn MEDJTRANSColumn
            {
                get
                {
                    return this.columnMEDJTRANS;
                }
            }

            public DataColumn NAZIVPARTNERColumn
            {
                get
                {
                    return this.columnNAZIVPARTNER;
                }
            }

            public DataColumn NEPODLEZEColumn
            {
                get
                {
                    return this.columnNEPODLEZE;
                }
            }

            public DataColumn NULAColumn
            {
                get
                {
                    return this.columnNULA;
                }
            }

            public DataColumn OSN10Column
            {
                get
                {
                    return this.columnOSN10;
                }
            }

            public DataColumn OSN22Column
            {
                get
                {
                    return this.columnOSN22;
                }
            }

            public DataColumn OSN23Column
            {
                get
                {
                    return this.columnOSN23;
                }
            }

            public DataColumn OSN25Column
            {
                get
                {
                    return this.columnOSN25;
                }
            }

            public DataColumn OSTALOColumn
            {
                get
                {
                    return this.columnOSTALO;
                }
            }

            public DataColumn PARTNEROIBColumn
            {
                get
                {
                    return this.columnPARTNEROIB;
                }
            }

            public DataColumn PDV10Column
            {
                get
                {
                    return this.columnPDV10;
                }
            }

            public DataColumn PDV22Column
            {
                get
                {
                    return this.columnPDV22;
                }
            }

            public DataColumn PDV23Column
            {
                get
                {
                    return this.columnPDV23;
                }
            }

            public DataColumn PDV25Column
            {
                get
                {
                    return this.columnPDV25;
                }
            }

            public DataColumn StatusColumn
            {
                get
                {
                    return this.columnStatus;
                }
            }

            public DataColumn TUZEMSTVOColumn
            {
                get
                {
                    return this.columnTUZEMSTVO;
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

        public class S_FIN_IRA_PLACANJERow : DataRow
        {
            private S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJEDataTable tableS_FIN_IRA_PLACANJE;

            internal S_FIN_IRA_PLACANJERow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_FIN_IRA_PLACANJE = (S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJEDataTable) this.Table;
            }

            public bool IsIDTIPIRANull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.IDTIPIRAColumn);
            }

            public bool IsIRABROJNull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.IRABROJColumn);
            }

            public bool IsIRADATUMNull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.IRADATUMColumn);
            }

            public bool IsIRADOKIDDOKUMENTNull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.IRADOKIDDOKUMENTColumn);
            }

            public bool IsIRAGODIDGODINENull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.IRAGODIDGODINEColumn);
            }

            public bool IsIRANAPOMENANull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.IRANAPOMENAColumn);
            }

            public bool IsIRAPARTNERIDPARTNERNull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.IRAPARTNERIDPARTNERColumn);
            }

            public bool IsIRAUKUPNONull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.IRAUKUPNOColumn);
            }

            public bool IsIRAVALUTANull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.IRAVALUTAColumn);
            }

            public bool IsIZVOZNull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.IZVOZColumn);
            }

            public bool IsMEDJTRANSNull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.MEDJTRANSColumn);
            }

            public bool IsNAZIVPARTNERNull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.NAZIVPARTNERColumn);
            }

            public bool IsNEPODLEZENull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.NEPODLEZEColumn);
            }

            public bool IsNULANull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.NULAColumn);
            }

            public bool IsOSN10Null()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.OSN10Column);
            }

            public bool IsOSN22Null()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.OSN22Column);
            }

            public bool IsOSN23Null()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.OSN23Column);
            }

            public bool IsOSN25Null()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.OSN25Column);
            }

            public bool IsOSTALONull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.OSTALOColumn);
            }

            public bool IsPARTNEROIBNull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.PARTNEROIBColumn);
            }

            public bool IsPDV10Null()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.PDV10Column);
            }

            public bool IsPDV22Null()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.PDV22Column);
            }

            public bool IsPDV23Null()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.PDV23Column);
            }

            public bool IsPDV25Null()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.PDV25Column);
            }

            public bool IsStatusNull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.StatusColumn);
            }

            public bool IsTUZEMSTVONull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.TUZEMSTVOColumn);
            }

            public bool IsZATVARANJE_DATUMNull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.ZATVARANJE_DATUMColumn);
            }

            public bool IsZATVARANJE_IZNOSNull()
            {
                return this.IsNull(this.tableS_FIN_IRA_PLACANJE.ZATVARANJE_IZNOSColumn);
            }

            public void SetIDTIPIRANull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.IDTIPIRAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIRABROJNull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.IRABROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIRADATUMNull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.IRADATUMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIRADOKIDDOKUMENTNull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.IRADOKIDDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIRAGODIDGODINENull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.IRAGODIDGODINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIRANAPOMENANull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.IRANAPOMENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIRAPARTNERIDPARTNERNull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.IRAPARTNERIDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIRAUKUPNONull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.IRAUKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIRAVALUTANull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.IRAVALUTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZVOZNull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.IZVOZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMEDJTRANSNull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.MEDJTRANSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPARTNERNull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.NAZIVPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNEPODLEZENull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.NEPODLEZEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNULANull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.NULAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSN10Null()
            {
                this[this.tableS_FIN_IRA_PLACANJE.OSN10Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSN22Null()
            {
                this[this.tableS_FIN_IRA_PLACANJE.OSN22Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSN23Null()
            {
                this[this.tableS_FIN_IRA_PLACANJE.OSN23Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSN25Null()
            {
                this[this.tableS_FIN_IRA_PLACANJE.OSN25Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSTALONull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.OSTALOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNEROIBNull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.PARTNEROIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV10Null()
            {
                this[this.tableS_FIN_IRA_PLACANJE.PDV10Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV22Null()
            {
                this[this.tableS_FIN_IRA_PLACANJE.PDV22Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV23Null()
            {
                this[this.tableS_FIN_IRA_PLACANJE.PDV23Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV25Null()
            {
                this[this.tableS_FIN_IRA_PLACANJE.PDV25Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetStatusNull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.StatusColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTUZEMSTVONull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.TUZEMSTVOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZATVARANJE_DATUMNull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.ZATVARANJE_DATUMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZATVARANJE_IZNOSNull()
            {
                this[this.tableS_FIN_IRA_PLACANJE.ZATVARANJE_IZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDTIPIRA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_IRA_PLACANJE.IDTIPIRAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.IDTIPIRAColumn] = value;
                }
            }

            public int IRABROJ
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_IRA_PLACANJE.IRABROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.IRABROJColumn] = value;
                }
            }

            public DateTime IRADATUM
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_FIN_IRA_PLACANJE.IRADATUMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.IRADATUMColumn] = value;
                }
            }

            public int IRADOKIDDOKUMENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_IRA_PLACANJE.IRADOKIDDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.IRADOKIDDOKUMENTColumn] = value;
                }
            }

            public short IRAGODIDGODINE
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableS_FIN_IRA_PLACANJE.IRAGODIDGODINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.IRAGODIDGODINEColumn] = value;
                }
            }

            public string IRANAPOMENA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_IRA_PLACANJE.IRANAPOMENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.IRANAPOMENAColumn] = value;
                }
            }

            public int IRAPARTNERIDPARTNER
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_IRA_PLACANJE.IRAPARTNERIDPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.IRAPARTNERIDPARTNERColumn] = value;
                }
            }

            public decimal IRAUKUPNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.IRAUKUPNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.IRAUKUPNOColumn] = value;
                }
            }

            public DateTime IRAVALUTA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_FIN_IRA_PLACANJE.IRAVALUTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.IRAVALUTAColumn] = value;
                }
            }

            public decimal IZVOZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.IZVOZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.IZVOZColumn] = value;
                }
            }

            public decimal MEDJTRANS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.MEDJTRANSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.MEDJTRANSColumn] = value;
                }
            }

            public string NAZIVPARTNER
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_IRA_PLACANJE.NAZIVPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.NAZIVPARTNERColumn] = value;
                }
            }

            public decimal NEPODLEZE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.NEPODLEZEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.NEPODLEZEColumn] = value;
                }
            }

            public decimal NULA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.NULAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.NULAColumn] = value;
                }
            }

            public decimal OSN10
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.OSN10Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.OSN10Column] = value;
                }
            }

            public decimal OSN22
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.OSN22Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.OSN22Column] = value;
                }
            }

            public decimal OSN23
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.OSN23Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.OSN23Column] = value;
                }
            }

            public decimal OSN25
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.OSN25Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.OSN25Column] = value;
                }
            }

            public decimal OSTALO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.OSTALOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.OSTALOColumn] = value;
                }
            }

            public string PARTNEROIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_IRA_PLACANJE.PARTNEROIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.PARTNEROIBColumn] = value;
                }
            }

            public decimal PDV10
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.PDV10Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.PDV10Column] = value;
                }
            }

            public decimal PDV22
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.PDV22Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.PDV22Column] = value;
                }
            }

            public decimal PDV23
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.PDV23Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.PDV23Column] = value;
                }
            }

            public decimal PDV25
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.PDV25Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.PDV25Column] = value;
                }
            }

            public string Status
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_IRA_PLACANJE.StatusColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.StatusColumn] = value;
                }
            }

            public decimal TUZEMSTVO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.TUZEMSTVOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.TUZEMSTVOColumn] = value;
                }
            }

            public DateTime ZATVARANJE_DATUM
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_FIN_IRA_PLACANJE.ZATVARANJE_DATUMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.ZATVARANJE_DATUMColumn] = value;
                }
            }

            public decimal ZATVARANJE_IZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IRA_PLACANJE.ZATVARANJE_IZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IRA_PLACANJE.ZATVARANJE_IZNOSColumn] = value;
                }
            }
        }

        public class S_FIN_IRA_PLACANJERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow eventRow;

            public S_FIN_IRA_PLACANJERowChangeEvent(S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow row, DataRowAction action)
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

            public S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_FIN_IRA_PLACANJERowChangeEventHandler(object sender, S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERowChangeEvent e);
    }
}

