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
    public class S_OD_KONACNIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_KONACNIDataTable tableS_OD_KONACNI;

        public S_OD_KONACNIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_KONACNIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_KONACNI"] != null)
                    {
                        this.Tables.Add(new S_OD_KONACNIDataTable(dataSet.Tables["S_OD_KONACNI"]));
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
            S_OD_KONACNIDataSet set = (S_OD_KONACNIDataSet) base.Clone();
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
            S_OD_KONACNIDataSet set = new S_OD_KONACNIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_KONACNIDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2135");
            this.ExtendedProperties.Add("DataSetName", "S_OD_KONACNIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_KONACNIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_KONACNI");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_KONACNI");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_KONACNI");
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
            this.DataSetName = "S_OD_KONACNIDataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_KONACNI";
            this.tableS_OD_KONACNI = new S_OD_KONACNIDataTable();
            this.Tables.Add(this.tableS_OD_KONACNI);
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
            this.tableS_OD_KONACNI = (S_OD_KONACNIDataTable) this.Tables["S_OD_KONACNI"];
            if (initTable && (this.tableS_OD_KONACNI != null))
            {
                this.tableS_OD_KONACNI.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_KONACNI"] != null)
                {
                    this.Tables.Add(new S_OD_KONACNIDataTable(dataSet.Tables["S_OD_KONACNI"]));
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

        private bool ShouldSerializeS_OD_KONACNI()
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
        public S_OD_KONACNIDataTable S_OD_KONACNI
        {
            get
            {
                return this.tableS_OD_KONACNI;
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
        public class S_OD_KONACNIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJMJESECISAISPLATAMA;
            private DataColumn columnBRUTO;
            private DataColumn columndohodak;
            private DataColumn columnDOPRINOSI;
            private DataColumn columnFAKTOR;
            private DataColumn columnIP;
            private DataColumn columnKRIZNIPOREZ;
            private DataColumn columnODBITAK;
            private DataColumn columnOIB;
            private DataColumn columnOLAKSICE;
            private DataColumn columnOPCINA;
            private DataColumn columnPOREZ;
            private DataColumn columnPOREZIPRIREZ;
            private DataColumn columnporeznaosnovica;
            private DataColumn columnPRIREZ;
            private DataColumn columnSTOPAPRIREZA;

            public event S_OD_KONACNIDataSet.S_OD_KONACNIRowChangeEventHandler S_OD_KONACNIRowChanged;

            public event S_OD_KONACNIDataSet.S_OD_KONACNIRowChangeEventHandler S_OD_KONACNIRowChanging;

            public event S_OD_KONACNIDataSet.S_OD_KONACNIRowChangeEventHandler S_OD_KONACNIRowDeleted;

            public event S_OD_KONACNIDataSet.S_OD_KONACNIRowChangeEventHandler S_OD_KONACNIRowDeleting;

            public S_OD_KONACNIDataTable()
            {
                this.TableName = "S_OD_KONACNI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_KONACNIDataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_KONACNIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_KONACNIRow(S_OD_KONACNIDataSet.S_OD_KONACNIRow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_KONACNIDataSet.S_OD_KONACNIRow AddS_OD_KONACNIRow(decimal poreznaosnovica, decimal pOREZIPRIREZ, string oPCINA, string oIB, string iP, int bROJMJESECISAISPLATAMA, decimal sTOPAPRIREZA, decimal oDBITAK, decimal dohodak, decimal oLAKSICE, decimal bRUTO, decimal dOPRINOSI, decimal fAKTOR, decimal pOREZ, decimal pRIREZ, decimal kRIZNIPOREZ)
            {
                S_OD_KONACNIDataSet.S_OD_KONACNIRow row = (S_OD_KONACNIDataSet.S_OD_KONACNIRow) this.NewRow();
                row.ItemArray = new object[] { poreznaosnovica, pOREZIPRIREZ, oPCINA, oIB, iP, bROJMJESECISAISPLATAMA, sTOPAPRIREZA, oDBITAK, dohodak, oLAKSICE, bRUTO, dOPRINOSI, fAKTOR, pOREZ, pRIREZ, kRIZNIPOREZ };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_KONACNIDataSet.S_OD_KONACNIDataTable table = (S_OD_KONACNIDataSet.S_OD_KONACNIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_KONACNIDataSet.S_OD_KONACNIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_KONACNIDataSet set = new S_OD_KONACNIDataSet();
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
                this.columnporeznaosnovica = new DataColumn("poreznaosnovica", typeof(decimal), "", MappingType.Element);
                this.columnporeznaosnovica.Caption = "poreznaosnovica";
                this.columnporeznaosnovica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnporeznaosnovica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnporeznaosnovica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnporeznaosnovica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnporeznaosnovica.ExtendedProperties.Add("IsKey", "false");
                this.columnporeznaosnovica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnporeznaosnovica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnporeznaosnovica.ExtendedProperties.Add("Description", "poreznaosnovica");
                this.columnporeznaosnovica.ExtendedProperties.Add("Length", "12");
                this.columnporeznaosnovica.ExtendedProperties.Add("Decimals", "2");
                this.columnporeznaosnovica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnporeznaosnovica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnporeznaosnovica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnporeznaosnovica.ExtendedProperties.Add("IsInReader", "true");
                this.columnporeznaosnovica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnporeznaosnovica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnporeznaosnovica.ExtendedProperties.Add("Deklarit.InternalName", "poreznaosnovica");
                this.Columns.Add(this.columnporeznaosnovica);
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
                this.columnOPCINA = new DataColumn("OPCINA", typeof(string), "", MappingType.Element);
                this.columnOPCINA.Caption = "OPCINA";
                this.columnOPCINA.MaxLength = 3;
                this.columnOPCINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOPCINA.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINA.ExtendedProperties.Add("Description", "OPCINA");
                this.columnOPCINA.ExtendedProperties.Add("Length", "3");
                this.columnOPCINA.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINA.ExtendedProperties.Add("Deklarit.InternalName", "OPCINA");
                this.Columns.Add(this.columnOPCINA);
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
                this.columnIP = new DataColumn("IP", typeof(string), "", MappingType.Element);
                this.columnIP.Caption = "IP";
                this.columnIP.MaxLength = 2;
                this.columnIP.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIP.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIP.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIP.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIP.ExtendedProperties.Add("IsKey", "false");
                this.columnIP.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIP.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIP.ExtendedProperties.Add("Description", "IP");
                this.columnIP.ExtendedProperties.Add("Length", "2");
                this.columnIP.ExtendedProperties.Add("Decimals", "0");
                this.columnIP.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIP.ExtendedProperties.Add("IsInReader", "true");
                this.columnIP.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIP.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIP.ExtendedProperties.Add("Deklarit.InternalName", "IP");
                this.Columns.Add(this.columnIP);
                this.columnBROJMJESECISAISPLATAMA = new DataColumn("BROJMJESECISAISPLATAMA", typeof(int), "", MappingType.Element);
                this.columnBROJMJESECISAISPLATAMA.Caption = "BROJMJESECISAISPLATAMA";
                this.columnBROJMJESECISAISPLATAMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("Description", "BROJMJESECISAISPLATAMA");
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("Length", "5");
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJMJESECISAISPLATAMA.ExtendedProperties.Add("Deklarit.InternalName", "BROJMJESECISAISPLATAMA");
                this.Columns.Add(this.columnBROJMJESECISAISPLATAMA);
                this.columnSTOPAPRIREZA = new DataColumn("STOPAPRIREZA", typeof(decimal), "", MappingType.Element);
                this.columnSTOPAPRIREZA.Caption = "STOPAPRIREZA";
                this.columnSTOPAPRIREZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("Description", "STOPAPRIREZA");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("Length", "5");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPAPRIREZA.ExtendedProperties.Add("Deklarit.InternalName", "STOPAPRIREZA");
                this.Columns.Add(this.columnSTOPAPRIREZA);
                this.columnODBITAK = new DataColumn("ODBITAK", typeof(decimal), "", MappingType.Element);
                this.columnODBITAK.Caption = "ODBITAK";
                this.columnODBITAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnODBITAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnODBITAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnODBITAK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnODBITAK.ExtendedProperties.Add("IsKey", "false");
                this.columnODBITAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnODBITAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnODBITAK.ExtendedProperties.Add("Description", "ODBITAK");
                this.columnODBITAK.ExtendedProperties.Add("Length", "12");
                this.columnODBITAK.ExtendedProperties.Add("Decimals", "2");
                this.columnODBITAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnODBITAK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnODBITAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnODBITAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnODBITAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnODBITAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnODBITAK.ExtendedProperties.Add("Deklarit.InternalName", "ODBITAK");
                this.Columns.Add(this.columnODBITAK);
                this.columndohodak = new DataColumn("dohodak", typeof(decimal), "", MappingType.Element);
                this.columndohodak.Caption = "dohodak";
                this.columndohodak.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columndohodak.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columndohodak.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columndohodak.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columndohodak.ExtendedProperties.Add("IsKey", "false");
                this.columndohodak.ExtendedProperties.Add("ReadOnly", "true");
                this.columndohodak.ExtendedProperties.Add("DeklaritType", "int");
                this.columndohodak.ExtendedProperties.Add("Description", "dohodak");
                this.columndohodak.ExtendedProperties.Add("Length", "12");
                this.columndohodak.ExtendedProperties.Add("Decimals", "2");
                this.columndohodak.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columndohodak.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columndohodak.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columndohodak.ExtendedProperties.Add("IsInReader", "true");
                this.columndohodak.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columndohodak.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columndohodak.ExtendedProperties.Add("Deklarit.InternalName", "dohodak");
                this.Columns.Add(this.columndohodak);
                this.columnOLAKSICE = new DataColumn("OLAKSICE", typeof(decimal), "", MappingType.Element);
                this.columnOLAKSICE.Caption = "OLAKSICE";
                this.columnOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOLAKSICE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOLAKSICE.ExtendedProperties.Add("Description", "OLAKSICE");
                this.columnOLAKSICE.ExtendedProperties.Add("Length", "12");
                this.columnOLAKSICE.ExtendedProperties.Add("Decimals", "2");
                this.columnOLAKSICE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOLAKSICE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOLAKSICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "OLAKSICE");
                this.Columns.Add(this.columnOLAKSICE);
                this.columnBRUTO = new DataColumn("BRUTO", typeof(decimal), "", MappingType.Element);
                this.columnBRUTO.Caption = "Primici";
                this.columnBRUTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBRUTO.ExtendedProperties.Add("IsKey", "false");
                this.columnBRUTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBRUTO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBRUTO.ExtendedProperties.Add("Description", "Primici");
                this.columnBRUTO.ExtendedProperties.Add("Length", "12");
                this.columnBRUTO.ExtendedProperties.Add("Decimals", "2");
                this.columnBRUTO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBRUTO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBRUTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBRUTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.InternalName", "BRUTO");
                this.Columns.Add(this.columnBRUTO);
                this.columnDOPRINOSI = new DataColumn("DOPRINOSI", typeof(decimal), "", MappingType.Element);
                this.columnDOPRINOSI.Caption = "DOPRINOSI";
                this.columnDOPRINOSI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOPRINOSI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOPRINOSI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOPRINOSI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDOPRINOSI.ExtendedProperties.Add("IsKey", "false");
                this.columnDOPRINOSI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDOPRINOSI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDOPRINOSI.ExtendedProperties.Add("Description", "DOPRINOSI");
                this.columnDOPRINOSI.ExtendedProperties.Add("Length", "12");
                this.columnDOPRINOSI.ExtendedProperties.Add("Decimals", "2");
                this.columnDOPRINOSI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDOPRINOSI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDOPRINOSI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDOPRINOSI.ExtendedProperties.Add("IsInReader", "true");
                this.columnDOPRINOSI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOPRINOSI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOPRINOSI.ExtendedProperties.Add("Deklarit.InternalName", "DOPRINOSI");
                this.Columns.Add(this.columnDOPRINOSI);
                this.columnFAKTOR = new DataColumn("FAKTOR", typeof(decimal), "", MappingType.Element);
                this.columnFAKTOR.Caption = "FAKTOR";
                this.columnFAKTOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnFAKTOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnFAKTOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnFAKTOR.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnFAKTOR.ExtendedProperties.Add("IsKey", "false");
                this.columnFAKTOR.ExtendedProperties.Add("ReadOnly", "true");
                this.columnFAKTOR.ExtendedProperties.Add("DeklaritType", "int");
                this.columnFAKTOR.ExtendedProperties.Add("Description", "FAKTOR");
                this.columnFAKTOR.ExtendedProperties.Add("Length", "5");
                this.columnFAKTOR.ExtendedProperties.Add("Decimals", "2");
                this.columnFAKTOR.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnFAKTOR.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnFAKTOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnFAKTOR.ExtendedProperties.Add("IsInReader", "true");
                this.columnFAKTOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnFAKTOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnFAKTOR.ExtendedProperties.Add("Deklarit.InternalName", "FAKTOR");
                this.Columns.Add(this.columnFAKTOR);
                this.columnPOREZ = new DataColumn("POREZ", typeof(decimal), "", MappingType.Element);
                this.columnPOREZ.Caption = "POREZ";
                this.columnPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZ.ExtendedProperties.Add("Description", "POREZ");
                this.columnPOREZ.ExtendedProperties.Add("Length", "12");
                this.columnPOREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "POREZ");
                this.Columns.Add(this.columnPOREZ);
                this.columnPRIREZ = new DataColumn("PRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnPRIREZ.Caption = "Prirez općine";
                this.columnPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRIREZ.ExtendedProperties.Add("Description", "Prirez općine");
                this.columnPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "PRIREZ");
                this.Columns.Add(this.columnPRIREZ);
                this.columnKRIZNIPOREZ = new DataColumn("KRIZNIPOREZ", typeof(decimal), "", MappingType.Element);
                this.columnKRIZNIPOREZ.Caption = "Iznos posebnoh poreza";
                this.columnKRIZNIPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Description", "Iznos posebnoh poreza");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Length", "12");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "KRIZNIPOREZ");
                this.Columns.Add(this.columnKRIZNIPOREZ);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_KONACNI");
                this.ExtendedProperties.Add("Description", "S_OD_KONACNI");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnporeznaosnovica = this.Columns["poreznaosnovica"];
                this.columnPOREZIPRIREZ = this.Columns["POREZIPRIREZ"];
                this.columnOPCINA = this.Columns["OPCINA"];
                this.columnOIB = this.Columns["OIB"];
                this.columnIP = this.Columns["IP"];
                this.columnBROJMJESECISAISPLATAMA = this.Columns["BROJMJESECISAISPLATAMA"];
                this.columnSTOPAPRIREZA = this.Columns["STOPAPRIREZA"];
                this.columnODBITAK = this.Columns["ODBITAK"];
                this.columndohodak = this.Columns["dohodak"];
                this.columnOLAKSICE = this.Columns["OLAKSICE"];
                this.columnBRUTO = this.Columns["BRUTO"];
                this.columnDOPRINOSI = this.Columns["DOPRINOSI"];
                this.columnFAKTOR = this.Columns["FAKTOR"];
                this.columnPOREZ = this.Columns["POREZ"];
                this.columnPRIREZ = this.Columns["PRIREZ"];
                this.columnKRIZNIPOREZ = this.Columns["KRIZNIPOREZ"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_KONACNIDataSet.S_OD_KONACNIRow(builder);
            }

            public S_OD_KONACNIDataSet.S_OD_KONACNIRow NewS_OD_KONACNIRow()
            {
                return (S_OD_KONACNIDataSet.S_OD_KONACNIRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_KONACNIRowChanged != null)
                {
                    S_OD_KONACNIDataSet.S_OD_KONACNIRowChangeEventHandler handler = this.S_OD_KONACNIRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_KONACNIDataSet.S_OD_KONACNIRowChangeEvent((S_OD_KONACNIDataSet.S_OD_KONACNIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_KONACNIRowChanging != null)
                {
                    S_OD_KONACNIDataSet.S_OD_KONACNIRowChangeEventHandler handler = this.S_OD_KONACNIRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_KONACNIDataSet.S_OD_KONACNIRowChangeEvent((S_OD_KONACNIDataSet.S_OD_KONACNIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_KONACNIRowDeleted != null)
                {
                    S_OD_KONACNIDataSet.S_OD_KONACNIRowChangeEventHandler handler = this.S_OD_KONACNIRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_KONACNIDataSet.S_OD_KONACNIRowChangeEvent((S_OD_KONACNIDataSet.S_OD_KONACNIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_KONACNIRowDeleting != null)
                {
                    S_OD_KONACNIDataSet.S_OD_KONACNIRowChangeEventHandler handler = this.S_OD_KONACNIRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_KONACNIDataSet.S_OD_KONACNIRowChangeEvent((S_OD_KONACNIDataSet.S_OD_KONACNIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_KONACNIRow(S_OD_KONACNIDataSet.S_OD_KONACNIRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJMJESECISAISPLATAMAColumn
            {
                get
                {
                    return this.columnBROJMJESECISAISPLATAMA;
                }
            }

            public DataColumn BRUTOColumn
            {
                get
                {
                    return this.columnBRUTO;
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

            public DataColumn dohodakColumn
            {
                get
                {
                    return this.columndohodak;
                }
            }

            public DataColumn DOPRINOSIColumn
            {
                get
                {
                    return this.columnDOPRINOSI;
                }
            }

            public DataColumn FAKTORColumn
            {
                get
                {
                    return this.columnFAKTOR;
                }
            }

            public DataColumn IPColumn
            {
                get
                {
                    return this.columnIP;
                }
            }

            public S_OD_KONACNIDataSet.S_OD_KONACNIRow this[int index]
            {
                get
                {
                    return (S_OD_KONACNIDataSet.S_OD_KONACNIRow) this.Rows[index];
                }
            }

            public DataColumn KRIZNIPOREZColumn
            {
                get
                {
                    return this.columnKRIZNIPOREZ;
                }
            }

            public DataColumn ODBITAKColumn
            {
                get
                {
                    return this.columnODBITAK;
                }
            }

            public DataColumn OIBColumn
            {
                get
                {
                    return this.columnOIB;
                }
            }

            public DataColumn OLAKSICEColumn
            {
                get
                {
                    return this.columnOLAKSICE;
                }
            }

            public DataColumn OPCINAColumn
            {
                get
                {
                    return this.columnOPCINA;
                }
            }

            public DataColumn POREZColumn
            {
                get
                {
                    return this.columnPOREZ;
                }
            }

            public DataColumn POREZIPRIREZColumn
            {
                get
                {
                    return this.columnPOREZIPRIREZ;
                }
            }

            public DataColumn poreznaosnovicaColumn
            {
                get
                {
                    return this.columnporeznaosnovica;
                }
            }

            public DataColumn PRIREZColumn
            {
                get
                {
                    return this.columnPRIREZ;
                }
            }

            public DataColumn STOPAPRIREZAColumn
            {
                get
                {
                    return this.columnSTOPAPRIREZA;
                }
            }
        }

        public class S_OD_KONACNIRow : DataRow
        {
            private S_OD_KONACNIDataSet.S_OD_KONACNIDataTable tableS_OD_KONACNI;

            internal S_OD_KONACNIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_KONACNI = (S_OD_KONACNIDataSet.S_OD_KONACNIDataTable) this.Table;
            }

            public bool IsBROJMJESECISAISPLATAMANull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.BROJMJESECISAISPLATAMAColumn);
            }

            public bool IsBRUTONull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.BRUTOColumn);
            }

            public bool IsdohodakNull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.dohodakColumn);
            }

            public bool IsDOPRINOSINull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.DOPRINOSIColumn);
            }

            public bool IsFAKTORNull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.FAKTORColumn);
            }

            public bool IsIPNull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.IPColumn);
            }

            public bool IsKRIZNIPOREZNull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.KRIZNIPOREZColumn);
            }

            public bool IsODBITAKNull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.ODBITAKColumn);
            }

            public bool IsOIBNull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.OIBColumn);
            }

            public bool IsOLAKSICENull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.OLAKSICEColumn);
            }

            public bool IsOPCINANull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.OPCINAColumn);
            }

            public bool IsPOREZIPRIREZNull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.POREZIPRIREZColumn);
            }

            public bool IsporeznaosnovicaNull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.poreznaosnovicaColumn);
            }

            public bool IsPOREZNull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.POREZColumn);
            }

            public bool IsPRIREZNull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.PRIREZColumn);
            }

            public bool IsSTOPAPRIREZANull()
            {
                return this.IsNull(this.tableS_OD_KONACNI.STOPAPRIREZAColumn);
            }

            public void SetBROJMJESECISAISPLATAMANull()
            {
                this[this.tableS_OD_KONACNI.BROJMJESECISAISPLATAMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBRUTONull()
            {
                this[this.tableS_OD_KONACNI.BRUTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetdohodakNull()
            {
                this[this.tableS_OD_KONACNI.dohodakColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOPRINOSINull()
            {
                this[this.tableS_OD_KONACNI.DOPRINOSIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFAKTORNull()
            {
                this[this.tableS_OD_KONACNI.FAKTORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIPNull()
            {
                this[this.tableS_OD_KONACNI.IPColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKRIZNIPOREZNull()
            {
                this[this.tableS_OD_KONACNI.KRIZNIPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODBITAKNull()
            {
                this[this.tableS_OD_KONACNI.ODBITAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOIBNull()
            {
                this[this.tableS_OD_KONACNI.OIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOLAKSICENull()
            {
                this[this.tableS_OD_KONACNI.OLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINANull()
            {
                this[this.tableS_OD_KONACNI.OPCINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZIPRIREZNull()
            {
                this[this.tableS_OD_KONACNI.POREZIPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetporeznaosnovicaNull()
            {
                this[this.tableS_OD_KONACNI.poreznaosnovicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZNull()
            {
                this[this.tableS_OD_KONACNI.POREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIREZNull()
            {
                this[this.tableS_OD_KONACNI.PRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAPRIREZANull()
            {
                this[this.tableS_OD_KONACNI.STOPAPRIREZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BROJMJESECISAISPLATAMA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_KONACNI.BROJMJESECISAISPLATAMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJMJESECISAISPLATAMA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.BROJMJESECISAISPLATAMAColumn] = value;
                }
            }

            public decimal BRUTO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI.BRUTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.BRUTOColumn] = value;
                }
            }

            public decimal dohodak
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI.dohodakColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.dohodakColumn] = value;
                }
            }

            public decimal DOPRINOSI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI.DOPRINOSIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.DOPRINOSIColumn] = value;
                }
            }

            public decimal FAKTOR
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI.FAKTORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.FAKTORColumn] = value;
                }
            }

            public string IP
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_KONACNI.IPColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.IPColumn] = value;
                }
            }

            public decimal KRIZNIPOREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI.KRIZNIPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.KRIZNIPOREZColumn] = value;
                }
            }

            public decimal ODBITAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI.ODBITAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.ODBITAKColumn] = value;
                }
            }

            public string OIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_KONACNI.OIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.OIBColumn] = value;
                }
            }

            public decimal OLAKSICE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI.OLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.OLAKSICEColumn] = value;
                }
            }

            public string OPCINA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_KONACNI.OPCINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.OPCINAColumn] = value;
                }
            }

            public decimal POREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI.POREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.POREZColumn] = value;
                }
            }

            public decimal POREZIPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI.POREZIPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.POREZIPRIREZColumn] = value;
                }
            }

            public decimal poreznaosnovica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI.poreznaosnovicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.poreznaosnovicaColumn] = value;
                }
            }

            public decimal PRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI.PRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.PRIREZColumn] = value;
                }
            }

            public decimal STOPAPRIREZA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI.STOPAPRIREZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI.STOPAPRIREZAColumn] = value;
                }
            }
        }

        public class S_OD_KONACNIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_KONACNIDataSet.S_OD_KONACNIRow eventRow;

            public S_OD_KONACNIRowChangeEvent(S_OD_KONACNIDataSet.S_OD_KONACNIRow row, DataRowAction action)
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

            public S_OD_KONACNIDataSet.S_OD_KONACNIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_KONACNIRowChangeEventHandler(object sender, S_OD_KONACNIDataSet.S_OD_KONACNIRowChangeEvent e);
    }
}

