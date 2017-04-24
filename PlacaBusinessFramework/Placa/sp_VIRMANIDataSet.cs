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
    public class sp_VIRMANIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private sp_VIRMANIDataTable tablesp_VIRMANI;

        public sp_VIRMANIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected sp_VIRMANIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["sp_VIRMANI"] != null)
                    {
                        this.Tables.Add(new sp_VIRMANIDataTable(dataSet.Tables["sp_VIRMANI"]));
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
            sp_VIRMANIDataSet set = (sp_VIRMANIDataSet) base.Clone();
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
            sp_VIRMANIDataSet set = new sp_VIRMANIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "sp_VIRMANIDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2021");
            this.ExtendedProperties.Add("DataSetName", "sp_VIRMANIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Isp_VIRMANIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "sp_VIRMANI");
            this.ExtendedProperties.Add("ObjectDescription", "sp_VIRMANI");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_VIRMANI");
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
            this.DataSetName = "sp_VIRMANIDataSet";
            this.Namespace = "http://www.tempuri.org/sp_VIRMANI";
            this.tablesp_VIRMANI = new sp_VIRMANIDataTable();
            this.Tables.Add(this.tablesp_VIRMANI);
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
            this.tablesp_VIRMANI = (sp_VIRMANIDataTable) this.Tables["sp_VIRMANI"];
            if (initTable && (this.tablesp_VIRMANI != null))
            {
                this.tablesp_VIRMANI.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["sp_VIRMANI"] != null)
                {
                    this.Tables.Add(new sp_VIRMANIDataTable(dataSet.Tables["sp_VIRMANI"]));
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

        private bool ShouldSerializesp_VIRMANI()
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
        public sp_VIRMANIDataTable sp_VIRMANI
        {
            get
            {
                return this.tablesp_VIRMANI;
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
        public class sp_VIRMANIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJRACUNAPLA;
            private DataColumn columnBROJRACUNAPRI;
            private DataColumn columnDATUMPODNOSENJA;
            private DataColumn columnDATUMVALUTE;
            private DataColumn columnIZNOS;
            private DataColumn columnIZVORDOKUMENTA;
            private DataColumn columnMODELODOBRENJA;
            private DataColumn columnMODELZADUZENJA;
            private DataColumn columnNAMJENA;
            private DataColumn columnOPISPLACANJAVIRMAN;
            private DataColumn columnOZNACEN;
            private DataColumn columnPLA1;
            private DataColumn columnPLA2;
            private DataColumn columnPLA3;
            private DataColumn columnPOZIVODOBRENJA;
            private DataColumn columnPOZIVZADUZENJA;
            private DataColumn columnPRI1;
            private DataColumn columnPRI2;
            private DataColumn columnPRI3;
            private DataColumn columnSIFRAOBRACUNAVIRMAN;
            private DataColumn columnSIFRAOPISAPLACANJAVIRMAN;
            private DataColumn columnIDRADNIK;

            public event sp_VIRMANIDataSet.sp_VIRMANIRowChangeEventHandler sp_VIRMANIRowChanged;

            public event sp_VIRMANIDataSet.sp_VIRMANIRowChangeEventHandler sp_VIRMANIRowChanging;

            public event sp_VIRMANIDataSet.sp_VIRMANIRowChangeEventHandler sp_VIRMANIRowDeleted;

            public event sp_VIRMANIDataSet.sp_VIRMANIRowChangeEventHandler sp_VIRMANIRowDeleting;

            public sp_VIRMANIDataTable()
            {
                this.TableName = "sp_VIRMANI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal sp_VIRMANIDataTable(DataTable table) : base(table.TableName)
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

            protected sp_VIRMANIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void Addsp_VIRMANIRow(sp_VIRMANIDataSet.sp_VIRMANIRow row)
            {
                this.Rows.Add(row);
            }

            public sp_VIRMANIDataSet.sp_VIRMANIRow Addsp_VIRMANIRow(string sIFRAOBRACUNAVIRMAN, string pLA1, string pLA2, string pLA3, string bROJRACUNAPLA, string mODELZADUZENJA, string pOZIVZADUZENJA, string pRI1, string pRI2, string pRI3, string bROJRACUNAPRI, string mODELODOBRENJA, string pOZIVODOBRENJA, string sIFRAOPISAPLACANJAVIRMAN, string oPISPLACANJAVIRMAN, DateTime dATUMVALUTE, DateTime dATUMPODNOSENJA, string iZVORDOKUMENTA, bool oZNACEN, decimal iZNOS, string nAMJENA)
            {
                sp_VIRMANIDataSet.sp_VIRMANIRow row = (sp_VIRMANIDataSet.sp_VIRMANIRow) this.NewRow();
                row.ItemArray = new object[] { 
                    sIFRAOBRACUNAVIRMAN, pLA1, pLA2, pLA3, bROJRACUNAPLA, mODELZADUZENJA, pOZIVZADUZENJA, pRI1, pRI2, pRI3, bROJRACUNAPRI, mODELODOBRENJA, pOZIVODOBRENJA, sIFRAOPISAPLACANJAVIRMAN, oPISPLACANJAVIRMAN, dATUMVALUTE, 
                    dATUMPODNOSENJA, iZVORDOKUMENTA, oZNACEN, iZNOS, nAMJENA
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                sp_VIRMANIDataSet.sp_VIRMANIDataTable table = (sp_VIRMANIDataSet.sp_VIRMANIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(sp_VIRMANIDataSet.sp_VIRMANIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                sp_VIRMANIDataSet set = new sp_VIRMANIDataSet();
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
                this.columnSIFRAOBRACUNAVIRMAN = new DataColumn("SIFRAOBRACUNAVIRMAN", typeof(string), "", MappingType.Element);
                this.columnSIFRAOBRACUNAVIRMAN.Caption = "SIFRAOBRACUNAVIRMAN";
                this.columnSIFRAOBRACUNAVIRMAN.MaxLength = 11;
                this.columnSIFRAOBRACUNAVIRMAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Description", "SIFRAOBRACUNAVIRMAN");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Length", "11");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOBRACUNAVIRMAN");
                this.Columns.Add(this.columnSIFRAOBRACUNAVIRMAN);
                this.columnPLA1 = new DataColumn("PLA1", typeof(string), "", MappingType.Element);
                this.columnPLA1.Caption = "PL A1";
                this.columnPLA1.MaxLength = 20;
                this.columnPLA1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLA1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPLA1.ExtendedProperties.Add("IsKey", "false");
                this.columnPLA1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPLA1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPLA1.ExtendedProperties.Add("Description", "PL A1");
                this.columnPLA1.ExtendedProperties.Add("Length", "20");
                this.columnPLA1.ExtendedProperties.Add("Decimals", "0");
                this.columnPLA1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPLA1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.InternalName", "PLA1");
                this.Columns.Add(this.columnPLA1);
                this.columnPLA2 = new DataColumn("PLA2", typeof(string), "", MappingType.Element);
                this.columnPLA2.Caption = "PL A2";
                this.columnPLA2.MaxLength = 20;
                this.columnPLA2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLA2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPLA2.ExtendedProperties.Add("IsKey", "false");
                this.columnPLA2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPLA2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPLA2.ExtendedProperties.Add("Description", "PL A2");
                this.columnPLA2.ExtendedProperties.Add("Length", "20");
                this.columnPLA2.ExtendedProperties.Add("Decimals", "0");
                this.columnPLA2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPLA2.ExtendedProperties.Add("IsInReader", "true");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.InternalName", "PLA2");
                this.Columns.Add(this.columnPLA2);
                this.columnPLA3 = new DataColumn("PLA3", typeof(string), "", MappingType.Element);
                this.columnPLA3.Caption = "PL A3";
                this.columnPLA3.MaxLength = 20;
                this.columnPLA3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLA3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPLA3.ExtendedProperties.Add("IsKey", "false");
                this.columnPLA3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPLA3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPLA3.ExtendedProperties.Add("Description", "PL A3");
                this.columnPLA3.ExtendedProperties.Add("Length", "20");
                this.columnPLA3.ExtendedProperties.Add("Decimals", "0");
                this.columnPLA3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPLA3.ExtendedProperties.Add("IsInReader", "true");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.InternalName", "PLA3");
                this.Columns.Add(this.columnPLA3);
                this.columnBROJRACUNAPLA = new DataColumn("BROJRACUNAPLA", typeof(string), "", MappingType.Element);
                this.columnBROJRACUNAPLA.Caption = "BROJRACUNAPLA";
                this.columnBROJRACUNAPLA.MaxLength = 0x12;
                this.columnBROJRACUNAPLA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Description", "BROJRACUNAPLA");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Length", "18");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.InternalName", "BROJRACUNAPLA");
                this.Columns.Add(this.columnBROJRACUNAPLA);
                this.columnMODELZADUZENJA = new DataColumn("MODELZADUZENJA", typeof(string), "", MappingType.Element);
                this.columnMODELZADUZENJA.Caption = "MODELZADUZENJA";
                this.columnMODELZADUZENJA.MaxLength = 2;
                this.columnMODELZADUZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Description", "MODELZADUZENJA");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Length", "2");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.InternalName", "MODELZADUZENJA");
                this.Columns.Add(this.columnMODELZADUZENJA);
                this.columnPOZIVZADUZENJA = new DataColumn("POZIVZADUZENJA", typeof(string), "", MappingType.Element);
                this.columnPOZIVZADUZENJA.Caption = "POZIVZADUZENJA";
                this.columnPOZIVZADUZENJA.MaxLength = 0x16;
                this.columnPOZIVZADUZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Description", "POZIVZADUZENJA");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Length", "22");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.InternalName", "POZIVZADUZENJA");
                this.Columns.Add(this.columnPOZIVZADUZENJA);
                this.columnPRI1 = new DataColumn("PRI1", typeof(string), "", MappingType.Element);
                this.columnPRI1.Caption = "PR I1";
                this.columnPRI1.MaxLength = 20;
                this.columnPRI1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRI1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRI1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRI1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRI1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRI1.ExtendedProperties.Add("Description", "PR I1");
                this.columnPRI1.ExtendedProperties.Add("Length", "20");
                this.columnPRI1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRI1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRI1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.InternalName", "PRI1");
                this.Columns.Add(this.columnPRI1);
                this.columnPRI2 = new DataColumn("PRI2", typeof(string), "", MappingType.Element);
                this.columnPRI2.Caption = "PR I2";
                this.columnPRI2.MaxLength = 20;
                this.columnPRI2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRI2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRI2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRI2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRI2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRI2.ExtendedProperties.Add("Description", "PR I2");
                this.columnPRI2.ExtendedProperties.Add("Length", "20");
                this.columnPRI2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRI2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRI2.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.InternalName", "PRI2");
                this.Columns.Add(this.columnPRI2);
                this.columnPRI3 = new DataColumn("PRI3", typeof(string), "", MappingType.Element);
                this.columnPRI3.Caption = "PR I3";
                this.columnPRI3.MaxLength = 20;
                this.columnPRI3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRI3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRI3.ExtendedProperties.Add("IsKey", "false");
                this.columnPRI3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRI3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRI3.ExtendedProperties.Add("Description", "PR I3");
                this.columnPRI3.ExtendedProperties.Add("Length", "20");
                this.columnPRI3.ExtendedProperties.Add("Decimals", "0");
                this.columnPRI3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRI3.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.InternalName", "PRI3");
                this.Columns.Add(this.columnPRI3);
                this.columnBROJRACUNAPRI = new DataColumn("BROJRACUNAPRI", typeof(string), "", MappingType.Element);
                this.columnBROJRACUNAPRI.Caption = "BROJRACUNAPRI";
                this.columnBROJRACUNAPRI.MaxLength = 0x12;
                this.columnBROJRACUNAPRI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Description", "BROJRACUNAPRI");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Length", "18");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.InternalName", "BROJRACUNAPRI");
                this.Columns.Add(this.columnBROJRACUNAPRI);
                this.columnMODELODOBRENJA = new DataColumn("MODELODOBRENJA", typeof(string), "", MappingType.Element);
                this.columnMODELODOBRENJA.Caption = "MODELODOBRENJA";
                this.columnMODELODOBRENJA.MaxLength = 2;
                this.columnMODELODOBRENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Description", "MODELODOBRENJA");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Length", "2");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.InternalName", "MODELODOBRENJA");
                this.Columns.Add(this.columnMODELODOBRENJA);
                this.columnPOZIVODOBRENJA = new DataColumn("POZIVODOBRENJA", typeof(string), "", MappingType.Element);
                this.columnPOZIVODOBRENJA.Caption = "POZIVODOBRENJA";
                this.columnPOZIVODOBRENJA.MaxLength = 26;
                this.columnPOZIVODOBRENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Description", "POZIVODOBRENJA");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Length", "22");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.InternalName", "POZIVODOBRENJA");
                this.Columns.Add(this.columnPOZIVODOBRENJA);
                this.columnSIFRAOPISAPLACANJAVIRMAN = new DataColumn("SIFRAOPISAPLACANJAVIRMAN", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAVIRMAN.Caption = "SIFRAOPISAPLACANJAVIRMAN";
                this.columnSIFRAOPISAPLACANJAVIRMAN.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAVIRMAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Description", "SIFRAOPISAPLACANJAVIRMAN");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAVIRMAN");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAVIRMAN);

                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.Caption = "IDRADNIK";
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
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "IDRADNIK");
                this.columnIDRADNIK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DomainType", "IDRADNIK");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);

                this.columnOPISPLACANJAVIRMAN = new DataColumn("OPISPLACANJAVIRMAN", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAVIRMAN.Caption = "OPISPLACANJAVIRMAN";
                this.columnOPISPLACANJAVIRMAN.MaxLength = 0x24;
                this.columnOPISPLACANJAVIRMAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Description", "OPISPLACANJAVIRMAN");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAVIRMAN");
                this.Columns.Add(this.columnOPISPLACANJAVIRMAN);
                this.columnDATUMVALUTE = new DataColumn("DATUMVALUTE", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMVALUTE.Caption = "DATUMVALUTE";
                this.columnDATUMVALUTE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDATUMVALUTE.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMVALUTE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMVALUTE.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Description", "DATUMVALUTE");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Length", "8");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMVALUTE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMVALUTE.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.InternalName", "DATUMVALUTE");
                this.Columns.Add(this.columnDATUMVALUTE);
                this.columnDATUMPODNOSENJA = new DataColumn("DATUMPODNOSENJA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMPODNOSENJA.Caption = "DATUMPODNOSENJA";
                this.columnDATUMPODNOSENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Description", "DATUMPODNOSENJA");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMPODNOSENJA");
                this.Columns.Add(this.columnDATUMPODNOSENJA);
                this.columnIZVORDOKUMENTA = new DataColumn("IZVORDOKUMENTA", typeof(string), "", MappingType.Element);
                this.columnIZVORDOKUMENTA.Caption = "IZVORDOKUMENTA";
                this.columnIZVORDOKUMENTA.MaxLength = 3;
                this.columnIZVORDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Description", "IZVORDOKUMENTA");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Length", "3");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "IZVORDOKUMENTA");
                this.Columns.Add(this.columnIZVORDOKUMENTA);
                this.columnOZNACEN = new DataColumn("OZNACEN", typeof(bool), "", MappingType.Element);
                this.columnOZNACEN.Caption = "OZNACEN";
                this.columnOZNACEN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOZNACEN.ExtendedProperties.Add("IsKey", "false");
                this.columnOZNACEN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOZNACEN.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnOZNACEN.ExtendedProperties.Add("Description", "OZNACEN");
                this.columnOZNACEN.ExtendedProperties.Add("Length", "1");
                this.columnOZNACEN.ExtendedProperties.Add("Decimals", "0");
                this.columnOZNACEN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOZNACEN.ExtendedProperties.Add("IsInReader", "true");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.InternalName", "OZNACEN");
                this.Columns.Add(this.columnOZNACEN);
                this.columnIZNOS = new DataColumn("IZNOS", typeof(decimal), "", MappingType.Element);
                this.columnIZNOS.Caption = "IZNOS";
                this.columnIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOS.ExtendedProperties.Add("Description", "IZNOS");
                this.columnIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "IZNOS");
                this.Columns.Add(this.columnIZNOS);
                this.columnNAMJENA = new DataColumn("NAMJENA", typeof(string), "", MappingType.Element);
                this.columnNAMJENA.Caption = "NAMJENA";
                this.columnNAMJENA.MaxLength = 20;
                this.columnNAMJENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAMJENA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAMJENA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAMJENA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAMJENA.ExtendedProperties.Add("Description", "NAMJENA");
                this.columnNAMJENA.ExtendedProperties.Add("Length", "20");
                this.columnNAMJENA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAMJENA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAMJENA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.InternalName", "NAMJENA");
                this.Columns.Add(this.columnNAMJENA);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "sp_VIRMANI");
                this.ExtendedProperties.Add("Description", "SP_VIRMANI");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnSIFRAOBRACUNAVIRMAN = this.Columns["SIFRAOBRACUNAVIRMAN"];
                this.columnPLA1 = this.Columns["PLA1"];
                this.columnPLA2 = this.Columns["PLA2"];
                this.columnPLA3 = this.Columns["PLA3"];
                this.columnBROJRACUNAPLA = this.Columns["BROJRACUNAPLA"];
                this.columnMODELZADUZENJA = this.Columns["MODELZADUZENJA"];
                this.columnPOZIVZADUZENJA = this.Columns["POZIVZADUZENJA"];
                this.columnPRI1 = this.Columns["PRI1"];
                this.columnPRI2 = this.Columns["PRI2"];
                this.columnPRI3 = this.Columns["PRI3"];
                this.columnBROJRACUNAPRI = this.Columns["BROJRACUNAPRI"];
                this.columnMODELODOBRENJA = this.Columns["MODELODOBRENJA"];
                this.columnPOZIVODOBRENJA = this.Columns["POZIVODOBRENJA"];
                this.columnSIFRAOPISAPLACANJAVIRMAN = this.Columns["SIFRAOPISAPLACANJAVIRMAN"];
                this.columnOPISPLACANJAVIRMAN = this.Columns["OPISPLACANJAVIRMAN"];
                this.columnDATUMVALUTE = this.Columns["DATUMVALUTE"];
                this.columnDATUMPODNOSENJA = this.Columns["DATUMPODNOSENJA"];
                this.columnIZVORDOKUMENTA = this.Columns["IZVORDOKUMENTA"];
                this.columnOZNACEN = this.Columns["OZNACEN"];
                this.columnIZNOS = this.Columns["IZNOS"];
                this.columnNAMJENA = this.Columns["NAMJENA"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new sp_VIRMANIDataSet.sp_VIRMANIRow(builder);
            }

            public sp_VIRMANIDataSet.sp_VIRMANIRow Newsp_VIRMANIRow()
            {
                return (sp_VIRMANIDataSet.sp_VIRMANIRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.sp_VIRMANIRowChanged != null)
                {
                    sp_VIRMANIDataSet.sp_VIRMANIRowChangeEventHandler handler = this.sp_VIRMANIRowChanged;
                    if (handler != null)
                    {
                        handler(this, new sp_VIRMANIDataSet.sp_VIRMANIRowChangeEvent((sp_VIRMANIDataSet.sp_VIRMANIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.sp_VIRMANIRowChanging != null)
                {
                    sp_VIRMANIDataSet.sp_VIRMANIRowChangeEventHandler handler = this.sp_VIRMANIRowChanging;
                    if (handler != null)
                    {
                        handler(this, new sp_VIRMANIDataSet.sp_VIRMANIRowChangeEvent((sp_VIRMANIDataSet.sp_VIRMANIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.sp_VIRMANIRowDeleted != null)
                {
                    sp_VIRMANIDataSet.sp_VIRMANIRowChangeEventHandler handler = this.sp_VIRMANIRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new sp_VIRMANIDataSet.sp_VIRMANIRowChangeEvent((sp_VIRMANIDataSet.sp_VIRMANIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.sp_VIRMANIRowDeleting != null)
                {
                    sp_VIRMANIDataSet.sp_VIRMANIRowChangeEventHandler handler = this.sp_VIRMANIRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new sp_VIRMANIDataSet.sp_VIRMANIRowChangeEvent((sp_VIRMANIDataSet.sp_VIRMANIRow) e.Row, e.Action));
                    }
                }
            }

            public void Removesp_VIRMANIRow(sp_VIRMANIDataSet.sp_VIRMANIRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJRACUNAPLAColumn
            {
                get
                {
                    return this.columnBROJRACUNAPLA;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public DataColumn BROJRACUNAPRIColumn
            {
                get
                {
                    return this.columnBROJRACUNAPRI;
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

            public DataColumn DATUMPODNOSENJAColumn
            {
                get
                {
                    return this.columnDATUMPODNOSENJA;
                }
            }

            public DataColumn DATUMVALUTEColumn
            {
                get
                {
                    return this.columnDATUMVALUTE;
                }
            }

            public sp_VIRMANIDataSet.sp_VIRMANIRow this[int index]
            {
                get
                {
                    return (sp_VIRMANIDataSet.sp_VIRMANIRow) this.Rows[index];
                }
            }

            public DataColumn IZNOSColumn
            {
                get
                {
                    return this.columnIZNOS;
                }
            }

            public DataColumn IZVORDOKUMENTAColumn
            {
                get
                {
                    return this.columnIZVORDOKUMENTA;
                }
            }

            public DataColumn MODELODOBRENJAColumn
            {
                get
                {
                    return this.columnMODELODOBRENJA;
                }
            }

            public DataColumn MODELZADUZENJAColumn
            {
                get
                {
                    return this.columnMODELZADUZENJA;
                }
            }

            public DataColumn NAMJENAColumn
            {
                get
                {
                    return this.columnNAMJENA;
                }
            }

            public DataColumn OPISPLACANJAVIRMANColumn
            {
                get
                {
                    return this.columnOPISPLACANJAVIRMAN;
                }
            }

            public DataColumn OZNACENColumn
            {
                get
                {
                    return this.columnOZNACEN;
                }
            }

            public DataColumn PLA1Column
            {
                get
                {
                    return this.columnPLA1;
                }
            }

            public DataColumn PLA2Column
            {
                get
                {
                    return this.columnPLA2;
                }
            }

            public DataColumn PLA3Column
            {
                get
                {
                    return this.columnPLA3;
                }
            }

            public DataColumn POZIVODOBRENJAColumn
            {
                get
                {
                    return this.columnPOZIVODOBRENJA;
                }
            }

            public DataColumn POZIVZADUZENJAColumn
            {
                get
                {
                    return this.columnPOZIVZADUZENJA;
                }
            }

            public DataColumn PRI1Column
            {
                get
                {
                    return this.columnPRI1;
                }
            }

            public DataColumn PRI2Column
            {
                get
                {
                    return this.columnPRI2;
                }
            }

            public DataColumn PRI3Column
            {
                get
                {
                    return this.columnPRI3;
                }
            }

            public DataColumn SIFRAOBRACUNAVIRMANColumn
            {
                get
                {
                    return this.columnSIFRAOBRACUNAVIRMAN;
                }
            }

            public DataColumn SIFRAOPISAPLACANJAVIRMANColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJAVIRMAN;
                }
            }
        }

        public class sp_VIRMANIRow : DataRow
        {
            private sp_VIRMANIDataSet.sp_VIRMANIDataTable tablesp_VIRMANI;

            internal sp_VIRMANIRow(DataRowBuilder rb) : base(rb)
            {
                this.tablesp_VIRMANI = (sp_VIRMANIDataSet.sp_VIRMANIDataTable) this.Table;
            }

            public bool IsBROJRACUNAPLANull()
            {
                return this.IsNull(this.tablesp_VIRMANI.BROJRACUNAPLAColumn);
            }

            public bool IsBROJRACUNAPRINull()
            {
                return this.IsNull(this.tablesp_VIRMANI.BROJRACUNAPRIColumn);
            }

            public bool IsDATUMPODNOSENJANull()
            {
                return this.IsNull(this.tablesp_VIRMANI.DATUMPODNOSENJAColumn);
            }

            public bool IsDATUMVALUTENull()
            {
                return this.IsNull(this.tablesp_VIRMANI.DATUMVALUTEColumn);
            }

            public bool IsIZNOSNull()
            {
                return this.IsNull(this.tablesp_VIRMANI.IZNOSColumn);
            }

            public bool IsIZVORDOKUMENTANull()
            {
                return this.IsNull(this.tablesp_VIRMANI.IZVORDOKUMENTAColumn);
            }

            public bool IsMODELODOBRENJANull()
            {
                return this.IsNull(this.tablesp_VIRMANI.MODELODOBRENJAColumn);
            }

            public bool IsMODELZADUZENJANull()
            {
                return this.IsNull(this.tablesp_VIRMANI.MODELZADUZENJAColumn);
            }

            public bool IsNAMJENANull()
            {
                return this.IsNull(this.tablesp_VIRMANI.NAMJENAColumn);
            }

            public bool IsOPISPLACANJAVIRMANNull()
            {
                return this.IsNull(this.tablesp_VIRMANI.OPISPLACANJAVIRMANColumn);
            }

            public bool IsOZNACENNull()
            {
                return this.IsNull(this.tablesp_VIRMANI.OZNACENColumn);
            }

            public bool IsPLA1Null()
            {
                return this.IsNull(this.tablesp_VIRMANI.PLA1Column);
            }

            public bool IsPLA2Null()
            {
                return this.IsNull(this.tablesp_VIRMANI.PLA2Column);
            }

            public bool IsPLA3Null()
            {
                return this.IsNull(this.tablesp_VIRMANI.PLA3Column);
            }

            public bool IsPOZIVODOBRENJANull()
            {
                return this.IsNull(this.tablesp_VIRMANI.POZIVODOBRENJAColumn);
            }

            public bool IsPOZIVZADUZENJANull()
            {
                return this.IsNull(this.tablesp_VIRMANI.POZIVZADUZENJAColumn);
            }

            public bool IsPRI1Null()
            {
                return this.IsNull(this.tablesp_VIRMANI.PRI1Column);
            }

            public bool IsPRI2Null()
            {
                return this.IsNull(this.tablesp_VIRMANI.PRI2Column);
            }

            public bool IsPRI3Null()
            {
                return this.IsNull(this.tablesp_VIRMANI.PRI3Column);
            }

            public bool IsSIFRAOBRACUNAVIRMANNull()
            {
                return this.IsNull(this.tablesp_VIRMANI.SIFRAOBRACUNAVIRMANColumn);
            }

            public bool IsSIFRAOPISAPLACANJAVIRMANNull()
            {
                return this.IsNull(this.tablesp_VIRMANI.SIFRAOPISAPLACANJAVIRMANColumn);
            }

            public void SetBROJRACUNAPLANull()
            {
                this[this.tablesp_VIRMANI.BROJRACUNAPLAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJRACUNAPRINull()
            {
                this[this.tablesp_VIRMANI.BROJRACUNAPRIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMPODNOSENJANull()
            {
                this[this.tablesp_VIRMANI.DATUMPODNOSENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMVALUTENull()
            {
                this[this.tablesp_VIRMANI.DATUMVALUTEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSNull()
            {
                this[this.tablesp_VIRMANI.IZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZVORDOKUMENTANull()
            {
                this[this.tablesp_VIRMANI.IZVORDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMODELODOBRENJANull()
            {
                this[this.tablesp_VIRMANI.MODELODOBRENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMODELZADUZENJANull()
            {
                this[this.tablesp_VIRMANI.MODELZADUZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAMJENANull()
            {
                this[this.tablesp_VIRMANI.NAMJENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAVIRMANNull()
            {
                this[this.tablesp_VIRMANI.OPISPLACANJAVIRMANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOZNACENNull()
            {
                this[this.tablesp_VIRMANI.OZNACENColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPLA1Null()
            {
                this[this.tablesp_VIRMANI.PLA1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPLA2Null()
            {
                this[this.tablesp_VIRMANI.PLA2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPLA3Null()
            {
                this[this.tablesp_VIRMANI.PLA3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOZIVODOBRENJANull()
            {
                this[this.tablesp_VIRMANI.POZIVODOBRENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOZIVZADUZENJANull()
            {
                this[this.tablesp_VIRMANI.POZIVZADUZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRI1Null()
            {
                this[this.tablesp_VIRMANI.PRI1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRI2Null()
            {
                this[this.tablesp_VIRMANI.PRI2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRI3Null()
            {
                this[this.tablesp_VIRMANI.PRI3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOBRACUNAVIRMANNull()
            {
                this[this.tablesp_VIRMANI.SIFRAOBRACUNAVIRMANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAVIRMANNull()
            {
                this[this.tablesp_VIRMANI.SIFRAOPISAPLACANJAVIRMANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string BROJRACUNAPLA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.BROJRACUNAPLAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJRACUNAPLA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.BROJRACUNAPLAColumn] = value;
                }
            }

            public string BROJRACUNAPRI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.BROJRACUNAPRIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJRACUNAPRI because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.BROJRACUNAPRIColumn] = value;
                }
            }

            public DateTime DATUMPODNOSENJA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tablesp_VIRMANI.DATUMPODNOSENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DATUMPODNOSENJA because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tablesp_VIRMANI.DATUMPODNOSENJAColumn] = value;
                }
            }

            public DateTime DATUMVALUTE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tablesp_VIRMANI.DATUMVALUTEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DATUMVALUTE because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tablesp_VIRMANI.DATUMVALUTEColumn] = value;
                }
            }

            public decimal IZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_VIRMANI.IZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IZNOS because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_VIRMANI.IZNOSColumn] = value;
                }
            }

            public string IZVORDOKUMENTA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.IZVORDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IZVORDOKUMENTA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.IZVORDOKUMENTAColumn] = value;
                }
            }

            public string MODELODOBRENJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.MODELODOBRENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.MODELODOBRENJAColumn] = value;
                }
            }

            public string MODELZADUZENJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.MODELZADUZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.MODELZADUZENJAColumn] = value;
                }
            }

            public string NAMJENA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.NAMJENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.NAMJENAColumn] = value;
                }
            }

            public string OPISPLACANJAVIRMAN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.OPISPLACANJAVIRMANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.OPISPLACANJAVIRMANColumn] = value;
                }
            }

            public bool OZNACEN
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tablesp_VIRMANI.OZNACENColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tablesp_VIRMANI.OZNACENColumn] = value;
                }
            }

            public string PLA1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.PLA1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.PLA1Column] = value;
                }
            }

            public string PLA2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.PLA2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.PLA2Column] = value;
                }
            }

            public string PLA3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.PLA3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.PLA3Column] = value;
                }
            }

            public string POZIVODOBRENJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.POZIVODOBRENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.POZIVODOBRENJAColumn] = value;
                }
            }

            public string POZIVZADUZENJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.POZIVZADUZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.POZIVZADUZENJAColumn] = value;
                }
            }

            public string PRI1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.PRI1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.PRI1Column] = value;
                }
            }

            public string PRI2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.PRI2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.PRI2Column] = value;
                }
            }

            public string PRI3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.PRI3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.PRI3Column] = value;
                }
            }

            public string SIFRAOBRACUNAVIRMAN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.SIFRAOBRACUNAVIRMANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.SIFRAOBRACUNAVIRMANColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAVIRMAN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_VIRMANI.SIFRAOPISAPLACANJAVIRMANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_VIRMANI.SIFRAOPISAPLACANJAVIRMANColumn] = value;
                }
            }
        }

        public class sp_VIRMANIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private sp_VIRMANIDataSet.sp_VIRMANIRow eventRow;

            public sp_VIRMANIRowChangeEvent(sp_VIRMANIDataSet.sp_VIRMANIRow row, DataRowAction action)
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

            public sp_VIRMANIDataSet.sp_VIRMANIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void sp_VIRMANIRowChangeEventHandler(object sender, sp_VIRMANIDataSet.sp_VIRMANIRowChangeEvent e);
    }
}

