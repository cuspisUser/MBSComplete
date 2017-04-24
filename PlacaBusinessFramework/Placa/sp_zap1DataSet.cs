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
    public class sp_zap1DataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private sp_zap1DataTable tablesp_zap1;

        public sp_zap1DataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected sp_zap1DataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["sp_zap1"] != null)
                    {
                        this.Tables.Add(new sp_zap1DataTable(dataSet.Tables["sp_zap1"]));
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
            sp_zap1DataSet set = (sp_zap1DataSet) base.Clone();
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
            sp_zap1DataSet set = new sp_zap1DataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "sp_zap1DataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2031");
            this.ExtendedProperties.Add("DataSetName", "sp_zap1DataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Isp_zap1DataAdapter");
            this.ExtendedProperties.Add("ObjectName", "sp_zap1");
            this.ExtendedProperties.Add("ObjectDescription", "sp_zap1");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_ZAP1_OBRAZAC");
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
            this.DataSetName = "sp_zap1DataSet";
            this.Namespace = "http://www.tempuri.org/sp_zap1";
            this.tablesp_zap1 = new sp_zap1DataTable();
            this.Tables.Add(this.tablesp_zap1);
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
            this.tablesp_zap1 = (sp_zap1DataTable) this.Tables["sp_zap1"];
            if (initTable && (this.tablesp_zap1 != null))
            {
                this.tablesp_zap1.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["sp_zap1"] != null)
                {
                    this.Tables.Add(new sp_zap1DataTable(dataSet.Tables["sp_zap1"]));
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

        private bool ShouldSerializesp_zap1()
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
        public sp_zap1DataTable sp_zap1
        {
            get
            {
                return this.tablesp_zap1;
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
        public class sp_zap1DataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJRACUNAZAP1;
            private DataColumn columnBROJRADNIKA;
            private DataColumn columnIZNOSPLACEIZNALOGAZAISPLATU;
            private DataColumn columnOSNOVICAMIOI;
            private DataColumn columnOSNOVICAMIOII;
            private DataColumn columnOSNOVICAPOREZ;
            private DataColumn columnOSNOVICAZAP;
            private DataColumn columnOSNOVICAZAPI;
            private DataColumn columnOSNOVICAZDRO;
            private DataColumn columnOSNOVICAZDRP;
            private DataColumn columnSTOPAMIOI;
            private DataColumn columnSTOPAMIOII;
            private DataColumn columnSTOPAZAP;
            private DataColumn columnSTOPAZAPI;
            private DataColumn columnSTOPAZDRO;
            private DataColumn columnSTOPAZDRP;
            private DataColumn columnukupnobruto;
            private DataColumn columnUKUPNODOHODAK;
            private DataColumn columnUKUPNODOPRINOSIIZ;
            private DataColumn columnUKUPNODOPRINOSINA;
            private DataColumn columnUKUPNOMIOI;
            private DataColumn columnUKUPNOMIOII;
            private DataColumn columnukupnoolaksice;
            private DataColumn columnUKUPNOOO;
            private DataColumn columnUKUPNOPOREZ;
            private DataColumn columnUKUPNOPOREZDOFAKTOO2;
            private DataColumn columnUKUPNOPOREZODFAKTOO2DO5;
            private DataColumn columnUKUPNOPOREZODFAKTOO5;
            private DataColumn columnUKUPNOPRIREZ;
            private DataColumn columnUKUPNOZAP;
            private DataColumn columnUKUPNOZAPI;
            private DataColumn columnUKUPNOZDRO;
            private DataColumn columnUKUPNOZDRP;

            public event sp_zap1DataSet.sp_zap1RowChangeEventHandler sp_zap1RowChanged;

            public event sp_zap1DataSet.sp_zap1RowChangeEventHandler sp_zap1RowChanging;

            public event sp_zap1DataSet.sp_zap1RowChangeEventHandler sp_zap1RowDeleted;

            public event sp_zap1DataSet.sp_zap1RowChangeEventHandler sp_zap1RowDeleting;

            public sp_zap1DataTable()
            {
                this.TableName = "sp_zap1";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal sp_zap1DataTable(DataTable table) : base(table.TableName)
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

            protected sp_zap1DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void Addsp_zap1Row(sp_zap1DataSet.sp_zap1Row row)
            {
                this.Rows.Add(row);
            }

            public sp_zap1DataSet.sp_zap1Row Addsp_zap1Row(decimal ukupnobruto, decimal uKUPNODOPRINOSIIZ, decimal sTOPAMIOI, decimal oSNOVICAMIOI, decimal uKUPNOMIOI, decimal sTOPAMIOII, decimal oSNOVICAMIOII, decimal uKUPNOMIOII, decimal uKUPNODOHODAK, decimal uKUPNOOO, decimal ukupnoolaksice, decimal oSNOVICAPOREZ, int uKUPNOPOREZDOFAKTOO2, decimal uKUPNOPOREZODFAKTOO2DO5, decimal uKUPNOPOREZODFAKTOO5, decimal uKUPNOPOREZ, decimal uKUPNOPRIREZ, decimal iZNOSPLACEIZNALOGAZAISPLATU, decimal uKUPNODOPRINOSINA, decimal bROJRADNIKA, decimal sTOPAZDRO, decimal oSNOVICAZDRO, decimal uKUPNOZDRO, decimal sTOPAZDRP, decimal oSNOVICAZDRP, decimal uKUPNOZDRP, decimal sTOPAZAP, decimal oSNOVICAZAP, decimal uKUPNOZAP, decimal sTOPAZAPI, decimal oSNOVICAZAPI, decimal uKUPNOZAPI, string bROJRACUNAZAP1)
            {
                sp_zap1DataSet.sp_zap1Row row = (sp_zap1DataSet.sp_zap1Row) this.NewRow();
                row.ItemArray = new object[] { 
                    ukupnobruto, uKUPNODOPRINOSIIZ, sTOPAMIOI, oSNOVICAMIOI, uKUPNOMIOI, sTOPAMIOII, oSNOVICAMIOII, uKUPNOMIOII, uKUPNODOHODAK, uKUPNOOO, ukupnoolaksice, oSNOVICAPOREZ, uKUPNOPOREZDOFAKTOO2, uKUPNOPOREZODFAKTOO2DO5, uKUPNOPOREZODFAKTOO5, uKUPNOPOREZ, 
                    uKUPNOPRIREZ, iZNOSPLACEIZNALOGAZAISPLATU, uKUPNODOPRINOSINA, bROJRADNIKA, sTOPAZDRO, oSNOVICAZDRO, uKUPNOZDRO, sTOPAZDRP, oSNOVICAZDRP, uKUPNOZDRP, sTOPAZAP, oSNOVICAZAP, uKUPNOZAP, sTOPAZAPI, oSNOVICAZAPI, uKUPNOZAPI, 
                    bROJRACUNAZAP1
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                sp_zap1DataSet.sp_zap1DataTable table = (sp_zap1DataSet.sp_zap1DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(sp_zap1DataSet.sp_zap1Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                sp_zap1DataSet set = new sp_zap1DataSet();
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
                this.columnukupnobruto = new DataColumn("ukupnobruto", typeof(decimal), "", MappingType.Element);
                this.columnukupnobruto.Caption = "ukupnobruto";
                this.columnukupnobruto.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnobruto.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnobruto.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnobruto.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnobruto.ExtendedProperties.Add("Description", "ukupnobruto");
                this.columnukupnobruto.ExtendedProperties.Add("Length", "12");
                this.columnukupnobruto.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnobruto.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnobruto.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnobruto.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnobruto.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.InternalName", "ukupnobruto");
                this.Columns.Add(this.columnukupnobruto);
                this.columnUKUPNODOPRINOSIIZ = new DataColumn("UKUPNODOPRINOSIIZ", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNODOPRINOSIIZ.Caption = "UKUPNODOPRINOSIIZ";
                this.columnUKUPNODOPRINOSIIZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("Description", "UKUPNODOPRINOSIIZ");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNODOPRINOSIIZ.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNODOPRINOSIIZ");
                this.Columns.Add(this.columnUKUPNODOPRINOSIIZ);
                this.columnSTOPAMIOI = new DataColumn("STOPAMIOI", typeof(decimal), "", MappingType.Element);
                this.columnSTOPAMIOI.Caption = "STOPAMIOI";
                this.columnSTOPAMIOI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPAMIOI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPAMIOI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPAMIOI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTOPAMIOI.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPAMIOI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPAMIOI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPAMIOI.ExtendedProperties.Add("Description", "STOPAMIOI");
                this.columnSTOPAMIOI.ExtendedProperties.Add("Length", "12");
                this.columnSTOPAMIOI.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPAMIOI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTOPAMIOI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSTOPAMIOI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPAMIOI.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTOPAMIOI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPAMIOI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPAMIOI.ExtendedProperties.Add("Deklarit.InternalName", "STOPAMIOI");
                this.Columns.Add(this.columnSTOPAMIOI);
                this.columnOSNOVICAMIOI = new DataColumn("OSNOVICAMIOI", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICAMIOI.Caption = "OSNOVICAMIOI";
                this.columnOSNOVICAMIOI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("Description", "OSNOVICAMIOI");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAMIOI.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAMIOI");
                this.Columns.Add(this.columnOSNOVICAMIOI);
                this.columnUKUPNOMIOI = new DataColumn("UKUPNOMIOI", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOMIOI.Caption = "UKUPNOMIOI";
                this.columnUKUPNOMIOI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOMIOI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("Description", "UKUPNOMIOI");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOMIOI.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOMIOI");
                this.Columns.Add(this.columnUKUPNOMIOI);
                this.columnSTOPAMIOII = new DataColumn("STOPAMIOII", typeof(decimal), "", MappingType.Element);
                this.columnSTOPAMIOII.Caption = "STOPAMIOII";
                this.columnSTOPAMIOII.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPAMIOII.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPAMIOII.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPAMIOII.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTOPAMIOII.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPAMIOII.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPAMIOII.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPAMIOII.ExtendedProperties.Add("Description", "STOPAMIOII");
                this.columnSTOPAMIOII.ExtendedProperties.Add("Length", "12");
                this.columnSTOPAMIOII.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPAMIOII.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTOPAMIOII.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSTOPAMIOII.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPAMIOII.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTOPAMIOII.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPAMIOII.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPAMIOII.ExtendedProperties.Add("Deklarit.InternalName", "STOPAMIOII");
                this.Columns.Add(this.columnSTOPAMIOII);
                this.columnOSNOVICAMIOII = new DataColumn("OSNOVICAMIOII", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICAMIOII.Caption = "OSNOVICAMIOII";
                this.columnOSNOVICAMIOII.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("Description", "OSNOVICAMIOII");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAMIOII.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAMIOII");
                this.Columns.Add(this.columnOSNOVICAMIOII);
                this.columnUKUPNOMIOII = new DataColumn("UKUPNOMIOII", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOMIOII.Caption = "UKUPNOMIOII";
                this.columnUKUPNOMIOII.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOMIOII.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("Description", "UKUPNOMIOII");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOMIOII.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOMIOII");
                this.Columns.Add(this.columnUKUPNOMIOII);
                this.columnUKUPNODOHODAK = new DataColumn("UKUPNODOHODAK", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNODOHODAK.Caption = "UKUPNODOHODAK";
                this.columnUKUPNODOHODAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("Description", "UKUPNODOHODAK");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNODOHODAK.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNODOHODAK");
                this.Columns.Add(this.columnUKUPNODOHODAK);
                this.columnUKUPNOOO = new DataColumn("UKUPNOOO", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOOO.Caption = "UKUPNOOO";
                this.columnUKUPNOOO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOOO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOOO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOOO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOOO.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOOO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOOO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOOO.ExtendedProperties.Add("Description", "UKUPNOOO");
                this.columnUKUPNOOO.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOOO.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOOO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOOO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOOO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOOO.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOOO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOOO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOOO.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOOO");
                this.Columns.Add(this.columnUKUPNOOO);
                this.columnukupnoolaksice = new DataColumn("ukupnoolaksice", typeof(decimal), "", MappingType.Element);
                this.columnukupnoolaksice.Caption = "ukupnoolaksice";
                this.columnukupnoolaksice.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnoolaksice.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnoolaksice.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnoolaksice.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnoolaksice.ExtendedProperties.Add("Description", "ukupnoolaksice");
                this.columnukupnoolaksice.ExtendedProperties.Add("Length", "12");
                this.columnukupnoolaksice.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnoolaksice.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnoolaksice.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnoolaksice.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnoolaksice.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.InternalName", "ukupnoolaksice");
                this.Columns.Add(this.columnukupnoolaksice);
                this.columnOSNOVICAPOREZ = new DataColumn("OSNOVICAPOREZ", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICAPOREZ.Caption = "OSNOVICAPOREZ";
                this.columnOSNOVICAPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Description", "OSNOVICAPOREZ");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAPOREZ");
                this.Columns.Add(this.columnOSNOVICAPOREZ);
                this.columnUKUPNOPOREZDOFAKTOO2 = new DataColumn("UKUPNOPOREZDOFAKTOO2", typeof(int), "", MappingType.Element);
                this.columnUKUPNOPOREZDOFAKTOO2.Caption = "UKUPNOPOREZDOFAKTO O2";
                this.columnUKUPNOPOREZDOFAKTOO2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("Description", "UKUPNOPOREZDOFAKTO O2");
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("Length", "5");
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("Decimals", "0");
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOPOREZDOFAKTOO2.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOPOREZDOFAKTOO2");
                this.Columns.Add(this.columnUKUPNOPOREZDOFAKTOO2);
                this.columnUKUPNOPOREZODFAKTOO2DO5 = new DataColumn("UKUPNOPOREZODFAKTOO2DO5", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOPOREZODFAKTOO2DO5.Caption = "UKUPNOPOREZODFAKTOO2 D O5";
                this.columnUKUPNOPOREZODFAKTOO2DO5.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("Description", "UKUPNOPOREZODFAKTOO2 D O5");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOPOREZODFAKTOO2DO5.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOPOREZODFAKTOO2DO5");
                this.Columns.Add(this.columnUKUPNOPOREZODFAKTOO2DO5);
                this.columnUKUPNOPOREZODFAKTOO5 = new DataColumn("UKUPNOPOREZODFAKTOO5", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOPOREZODFAKTOO5.Caption = "UKUPNOPOREZODFAKTO O5";
                this.columnUKUPNOPOREZODFAKTOO5.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("Description", "UKUPNOPOREZODFAKTO O5");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOPOREZODFAKTOO5.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOPOREZODFAKTOO5");
                this.Columns.Add(this.columnUKUPNOPOREZODFAKTOO5);
                this.columnUKUPNOPOREZ = new DataColumn("UKUPNOPOREZ", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOPOREZ.Caption = "UKUPNOPOREZ";
                this.columnUKUPNOPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Description", "UKUPNOPOREZ");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOPOREZ");
                this.Columns.Add(this.columnUKUPNOPOREZ);
                this.columnUKUPNOPRIREZ = new DataColumn("UKUPNOPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOPRIREZ.Caption = "UKUPNOPRIREZ";
                this.columnUKUPNOPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Description", "UKUPNOPRIREZ");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOPRIREZ");
                this.Columns.Add(this.columnUKUPNOPRIREZ);
                this.columnIZNOSPLACEIZNALOGAZAISPLATU = new DataColumn("IZNOSPLACEIZNALOGAZAISPLATU", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.Caption = "IZNOSPLACEIZNALOGAZAISPLATU";
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("Description", "IZNOSPLACEIZNALOGAZAISPLATU");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSPLACEIZNALOGAZAISPLATU.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSPLACEIZNALOGAZAISPLATU");
                this.Columns.Add(this.columnIZNOSPLACEIZNALOGAZAISPLATU);
                this.columnUKUPNODOPRINOSINA = new DataColumn("UKUPNODOPRINOSINA", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNODOPRINOSINA.Caption = "UKUPNODOPRINOSINA";
                this.columnUKUPNODOPRINOSINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Description", "UKUPNODOPRINOSINA");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNODOPRINOSINA");
                this.Columns.Add(this.columnUKUPNODOPRINOSINA);
                this.columnBROJRADNIKA = new DataColumn("BROJRADNIKA", typeof(decimal), "", MappingType.Element);
                this.columnBROJRADNIKA.Caption = "Broj stjecatelja";
                this.columnBROJRADNIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJRADNIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRADNIKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJRADNIKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Description", "Broj stjecatelja");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Length", "12");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Decimals", "2");
                this.columnBROJRADNIKA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBROJRADNIKA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBROJRADNIKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRADNIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.InternalName", "BROJRADNIKA");
                this.Columns.Add(this.columnBROJRADNIKA);
                this.columnSTOPAZDRO = new DataColumn("STOPAZDRO", typeof(decimal), "", MappingType.Element);
                this.columnSTOPAZDRO.Caption = "STOPAZDRO";
                this.columnSTOPAZDRO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPAZDRO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPAZDRO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPAZDRO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTOPAZDRO.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPAZDRO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPAZDRO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPAZDRO.ExtendedProperties.Add("Description", "STOPAZDRO");
                this.columnSTOPAZDRO.ExtendedProperties.Add("Length", "12");
                this.columnSTOPAZDRO.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPAZDRO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTOPAZDRO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSTOPAZDRO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPAZDRO.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTOPAZDRO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPAZDRO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPAZDRO.ExtendedProperties.Add("Deklarit.InternalName", "STOPAZDRO");
                this.Columns.Add(this.columnSTOPAZDRO);
                this.columnOSNOVICAZDRO = new DataColumn("OSNOVICAZDRO", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICAZDRO.Caption = "OSNOVICAZDRO";
                this.columnOSNOVICAZDRO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("Description", "OSNOVICAZDRO");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAZDRO.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAZDRO");
                this.Columns.Add(this.columnOSNOVICAZDRO);
                this.columnUKUPNOZDRO = new DataColumn("UKUPNOZDRO", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOZDRO.Caption = "UKUPNOZDRO";
                this.columnUKUPNOZDRO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOZDRO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("Description", "UKUPNOZDRO");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOZDRO.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOZDRO");
                this.Columns.Add(this.columnUKUPNOZDRO);
                this.columnSTOPAZDRP = new DataColumn("STOPAZDRP", typeof(decimal), "", MappingType.Element);
                this.columnSTOPAZDRP.Caption = "STOPAZDRP";
                this.columnSTOPAZDRP.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPAZDRP.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPAZDRP.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPAZDRP.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTOPAZDRP.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPAZDRP.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPAZDRP.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPAZDRP.ExtendedProperties.Add("Description", "STOPAZDRP");
                this.columnSTOPAZDRP.ExtendedProperties.Add("Length", "12");
                this.columnSTOPAZDRP.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPAZDRP.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTOPAZDRP.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSTOPAZDRP.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPAZDRP.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTOPAZDRP.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPAZDRP.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPAZDRP.ExtendedProperties.Add("Deklarit.InternalName", "STOPAZDRP");
                this.Columns.Add(this.columnSTOPAZDRP);
                this.columnOSNOVICAZDRP = new DataColumn("OSNOVICAZDRP", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICAZDRP.Caption = "OSNOVICAZDRP";
                this.columnOSNOVICAZDRP.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("Description", "OSNOVICAZDRP");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAZDRP.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAZDRP");
                this.Columns.Add(this.columnOSNOVICAZDRP);
                this.columnUKUPNOZDRP = new DataColumn("UKUPNOZDRP", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOZDRP.Caption = "UKUPNOZDRP";
                this.columnUKUPNOZDRP.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOZDRP.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("Description", "UKUPNOZDRP");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOZDRP.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOZDRP");
                this.Columns.Add(this.columnUKUPNOZDRP);
                this.columnSTOPAZAP = new DataColumn("STOPAZAP", typeof(decimal), "", MappingType.Element);
                this.columnSTOPAZAP.Caption = "STOPAZAP";
                this.columnSTOPAZAP.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPAZAP.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPAZAP.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPAZAP.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTOPAZAP.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPAZAP.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPAZAP.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPAZAP.ExtendedProperties.Add("Description", "STOPAZAP");
                this.columnSTOPAZAP.ExtendedProperties.Add("Length", "12");
                this.columnSTOPAZAP.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPAZAP.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTOPAZAP.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSTOPAZAP.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPAZAP.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTOPAZAP.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPAZAP.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPAZAP.ExtendedProperties.Add("Deklarit.InternalName", "STOPAZAP");
                this.Columns.Add(this.columnSTOPAZAP);
                this.columnOSNOVICAZAP = new DataColumn("OSNOVICAZAP", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICAZAP.Caption = "OSNOVICAZAP";
                this.columnOSNOVICAZAP.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAZAP.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("Description", "OSNOVICAZAP");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAZAP.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAZAP");
                this.Columns.Add(this.columnOSNOVICAZAP);
                this.columnUKUPNOZAP = new DataColumn("UKUPNOZAP", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOZAP.Caption = "UKUPNOZAP";
                this.columnUKUPNOZAP.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOZAP.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOZAP.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOZAP.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOZAP.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOZAP.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOZAP.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOZAP.ExtendedProperties.Add("Description", "UKUPNOZAP");
                this.columnUKUPNOZAP.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOZAP.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOZAP.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOZAP.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOZAP.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOZAP.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOZAP.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOZAP.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOZAP.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOZAP");
                this.Columns.Add(this.columnUKUPNOZAP);
                this.columnSTOPAZAPI = new DataColumn("STOPAZAPI", typeof(decimal), "", MappingType.Element);
                this.columnSTOPAZAPI.Caption = "STOPAZAPI";
                this.columnSTOPAZAPI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPAZAPI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPAZAPI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPAZAPI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTOPAZAPI.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPAZAPI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPAZAPI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPAZAPI.ExtendedProperties.Add("Description", "STOPAZAPI");
                this.columnSTOPAZAPI.ExtendedProperties.Add("Length", "12");
                this.columnSTOPAZAPI.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPAZAPI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTOPAZAPI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSTOPAZAPI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPAZAPI.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTOPAZAPI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPAZAPI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPAZAPI.ExtendedProperties.Add("Deklarit.InternalName", "STOPAZAPI");
                this.Columns.Add(this.columnSTOPAZAPI);
                this.columnOSNOVICAZAPI = new DataColumn("OSNOVICAZAPI", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICAZAPI.Caption = "OSNOVICAZAPI";
                this.columnOSNOVICAZAPI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("Description", "OSNOVICAZAPI");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAZAPI.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAZAPI");
                this.Columns.Add(this.columnOSNOVICAZAPI);
                this.columnUKUPNOZAPI = new DataColumn("UKUPNOZAPI", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOZAPI.Caption = "UKUPNOZAPI";
                this.columnUKUPNOZAPI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOZAPI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("Description", "UKUPNOZAPI");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOZAPI.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOZAPI");
                this.Columns.Add(this.columnUKUPNOZAPI);
                this.columnBROJRACUNAZAP1 = new DataColumn("BROJRACUNAZAP1", typeof(string), "", MappingType.Element);
                this.columnBROJRACUNAZAP1.Caption = "BROJRACUNAZA P1";
                this.columnBROJRACUNAZAP1.MaxLength = 20;
                this.columnBROJRACUNAZAP1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("Description", "BROJRACUNAZA P1");
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("Length", "20");
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRACUNAZAP1.ExtendedProperties.Add("Deklarit.InternalName", "BROJRACUNAZAP1");
                this.Columns.Add(this.columnBROJRACUNAZAP1);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "sp_zap1");
                this.ExtendedProperties.Add("Description", "_SP_ZAP1");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnukupnobruto = this.Columns["ukupnobruto"];
                this.columnUKUPNODOPRINOSIIZ = this.Columns["UKUPNODOPRINOSIIZ"];
                this.columnSTOPAMIOI = this.Columns["STOPAMIOI"];
                this.columnOSNOVICAMIOI = this.Columns["OSNOVICAMIOI"];
                this.columnUKUPNOMIOI = this.Columns["UKUPNOMIOI"];
                this.columnSTOPAMIOII = this.Columns["STOPAMIOII"];
                this.columnOSNOVICAMIOII = this.Columns["OSNOVICAMIOII"];
                this.columnUKUPNOMIOII = this.Columns["UKUPNOMIOII"];
                this.columnUKUPNODOHODAK = this.Columns["UKUPNODOHODAK"];
                this.columnUKUPNOOO = this.Columns["UKUPNOOO"];
                this.columnukupnoolaksice = this.Columns["ukupnoolaksice"];
                this.columnOSNOVICAPOREZ = this.Columns["OSNOVICAPOREZ"];
                this.columnUKUPNOPOREZDOFAKTOO2 = this.Columns["UKUPNOPOREZDOFAKTOO2"];
                this.columnUKUPNOPOREZODFAKTOO2DO5 = this.Columns["UKUPNOPOREZODFAKTOO2DO5"];
                this.columnUKUPNOPOREZODFAKTOO5 = this.Columns["UKUPNOPOREZODFAKTOO5"];
                this.columnUKUPNOPOREZ = this.Columns["UKUPNOPOREZ"];
                this.columnUKUPNOPRIREZ = this.Columns["UKUPNOPRIREZ"];
                this.columnIZNOSPLACEIZNALOGAZAISPLATU = this.Columns["IZNOSPLACEIZNALOGAZAISPLATU"];
                this.columnUKUPNODOPRINOSINA = this.Columns["UKUPNODOPRINOSINA"];
                this.columnBROJRADNIKA = this.Columns["BROJRADNIKA"];
                this.columnSTOPAZDRO = this.Columns["STOPAZDRO"];
                this.columnOSNOVICAZDRO = this.Columns["OSNOVICAZDRO"];
                this.columnUKUPNOZDRO = this.Columns["UKUPNOZDRO"];
                this.columnSTOPAZDRP = this.Columns["STOPAZDRP"];
                this.columnOSNOVICAZDRP = this.Columns["OSNOVICAZDRP"];
                this.columnUKUPNOZDRP = this.Columns["UKUPNOZDRP"];
                this.columnSTOPAZAP = this.Columns["STOPAZAP"];
                this.columnOSNOVICAZAP = this.Columns["OSNOVICAZAP"];
                this.columnUKUPNOZAP = this.Columns["UKUPNOZAP"];
                this.columnSTOPAZAPI = this.Columns["STOPAZAPI"];
                this.columnOSNOVICAZAPI = this.Columns["OSNOVICAZAPI"];
                this.columnUKUPNOZAPI = this.Columns["UKUPNOZAPI"];
                this.columnBROJRACUNAZAP1 = this.Columns["BROJRACUNAZAP1"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new sp_zap1DataSet.sp_zap1Row(builder);
            }

            public sp_zap1DataSet.sp_zap1Row Newsp_zap1Row()
            {
                return (sp_zap1DataSet.sp_zap1Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.sp_zap1RowChanged != null)
                {
                    sp_zap1DataSet.sp_zap1RowChangeEventHandler handler = this.sp_zap1RowChanged;
                    if (handler != null)
                    {
                        handler(this, new sp_zap1DataSet.sp_zap1RowChangeEvent((sp_zap1DataSet.sp_zap1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.sp_zap1RowChanging != null)
                {
                    sp_zap1DataSet.sp_zap1RowChangeEventHandler handler = this.sp_zap1RowChanging;
                    if (handler != null)
                    {
                        handler(this, new sp_zap1DataSet.sp_zap1RowChangeEvent((sp_zap1DataSet.sp_zap1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.sp_zap1RowDeleted != null)
                {
                    sp_zap1DataSet.sp_zap1RowChangeEventHandler handler = this.sp_zap1RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new sp_zap1DataSet.sp_zap1RowChangeEvent((sp_zap1DataSet.sp_zap1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.sp_zap1RowDeleting != null)
                {
                    sp_zap1DataSet.sp_zap1RowChangeEventHandler handler = this.sp_zap1RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new sp_zap1DataSet.sp_zap1RowChangeEvent((sp_zap1DataSet.sp_zap1Row) e.Row, e.Action));
                    }
                }
            }

            public void Removesp_zap1Row(sp_zap1DataSet.sp_zap1Row row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJRACUNAZAP1Column
            {
                get
                {
                    return this.columnBROJRACUNAZAP1;
                }
            }

            public DataColumn BROJRADNIKAColumn
            {
                get
                {
                    return this.columnBROJRADNIKA;
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

            public sp_zap1DataSet.sp_zap1Row this[int index]
            {
                get
                {
                    return (sp_zap1DataSet.sp_zap1Row) this.Rows[index];
                }
            }

            public DataColumn IZNOSPLACEIZNALOGAZAISPLATUColumn
            {
                get
                {
                    return this.columnIZNOSPLACEIZNALOGAZAISPLATU;
                }
            }

            public DataColumn OSNOVICAMIOIColumn
            {
                get
                {
                    return this.columnOSNOVICAMIOI;
                }
            }

            public DataColumn OSNOVICAMIOIIColumn
            {
                get
                {
                    return this.columnOSNOVICAMIOII;
                }
            }

            public DataColumn OSNOVICAPOREZColumn
            {
                get
                {
                    return this.columnOSNOVICAPOREZ;
                }
            }

            public DataColumn OSNOVICAZAPColumn
            {
                get
                {
                    return this.columnOSNOVICAZAP;
                }
            }

            public DataColumn OSNOVICAZAPIColumn
            {
                get
                {
                    return this.columnOSNOVICAZAPI;
                }
            }

            public DataColumn OSNOVICAZDROColumn
            {
                get
                {
                    return this.columnOSNOVICAZDRO;
                }
            }

            public DataColumn OSNOVICAZDRPColumn
            {
                get
                {
                    return this.columnOSNOVICAZDRP;
                }
            }

            public DataColumn STOPAMIOIColumn
            {
                get
                {
                    return this.columnSTOPAMIOI;
                }
            }

            public DataColumn STOPAMIOIIColumn
            {
                get
                {
                    return this.columnSTOPAMIOII;
                }
            }

            public DataColumn STOPAZAPColumn
            {
                get
                {
                    return this.columnSTOPAZAP;
                }
            }

            public DataColumn STOPAZAPIColumn
            {
                get
                {
                    return this.columnSTOPAZAPI;
                }
            }

            public DataColumn STOPAZDROColumn
            {
                get
                {
                    return this.columnSTOPAZDRO;
                }
            }

            public DataColumn STOPAZDRPColumn
            {
                get
                {
                    return this.columnSTOPAZDRP;
                }
            }

            public DataColumn ukupnobrutoColumn
            {
                get
                {
                    return this.columnukupnobruto;
                }
            }

            public DataColumn UKUPNODOHODAKColumn
            {
                get
                {
                    return this.columnUKUPNODOHODAK;
                }
            }

            public DataColumn UKUPNODOPRINOSIIZColumn
            {
                get
                {
                    return this.columnUKUPNODOPRINOSIIZ;
                }
            }

            public DataColumn UKUPNODOPRINOSINAColumn
            {
                get
                {
                    return this.columnUKUPNODOPRINOSINA;
                }
            }

            public DataColumn UKUPNOMIOIColumn
            {
                get
                {
                    return this.columnUKUPNOMIOI;
                }
            }

            public DataColumn UKUPNOMIOIIColumn
            {
                get
                {
                    return this.columnUKUPNOMIOII;
                }
            }

            public DataColumn ukupnoolaksiceColumn
            {
                get
                {
                    return this.columnukupnoolaksice;
                }
            }

            public DataColumn UKUPNOOOColumn
            {
                get
                {
                    return this.columnUKUPNOOO;
                }
            }

            public DataColumn UKUPNOPOREZColumn
            {
                get
                {
                    return this.columnUKUPNOPOREZ;
                }
            }

            public DataColumn UKUPNOPOREZDOFAKTOO2Column
            {
                get
                {
                    return this.columnUKUPNOPOREZDOFAKTOO2;
                }
            }

            public DataColumn UKUPNOPOREZODFAKTOO2DO5Column
            {
                get
                {
                    return this.columnUKUPNOPOREZODFAKTOO2DO5;
                }
            }

            public DataColumn UKUPNOPOREZODFAKTOO5Column
            {
                get
                {
                    return this.columnUKUPNOPOREZODFAKTOO5;
                }
            }

            public DataColumn UKUPNOPRIREZColumn
            {
                get
                {
                    return this.columnUKUPNOPRIREZ;
                }
            }

            public DataColumn UKUPNOZAPColumn
            {
                get
                {
                    return this.columnUKUPNOZAP;
                }
            }

            public DataColumn UKUPNOZAPIColumn
            {
                get
                {
                    return this.columnUKUPNOZAPI;
                }
            }

            public DataColumn UKUPNOZDROColumn
            {
                get
                {
                    return this.columnUKUPNOZDRO;
                }
            }

            public DataColumn UKUPNOZDRPColumn
            {
                get
                {
                    return this.columnUKUPNOZDRP;
                }
            }
        }

        public class sp_zap1Row : DataRow
        {
            private sp_zap1DataSet.sp_zap1DataTable tablesp_zap1;

            internal sp_zap1Row(DataRowBuilder rb) : base(rb)
            {
                this.tablesp_zap1 = (sp_zap1DataSet.sp_zap1DataTable) this.Table;
            }

            public bool IsBROJRACUNAZAP1Null()
            {
                return this.IsNull(this.tablesp_zap1.BROJRACUNAZAP1Column);
            }

            public bool IsBROJRADNIKANull()
            {
                return this.IsNull(this.tablesp_zap1.BROJRADNIKAColumn);
            }

            public bool IsIZNOSPLACEIZNALOGAZAISPLATUNull()
            {
                return this.IsNull(this.tablesp_zap1.IZNOSPLACEIZNALOGAZAISPLATUColumn);
            }

            public bool IsOSNOVICAMIOIINull()
            {
                return this.IsNull(this.tablesp_zap1.OSNOVICAMIOIIColumn);
            }

            public bool IsOSNOVICAMIOINull()
            {
                return this.IsNull(this.tablesp_zap1.OSNOVICAMIOIColumn);
            }

            public bool IsOSNOVICAPOREZNull()
            {
                return this.IsNull(this.tablesp_zap1.OSNOVICAPOREZColumn);
            }

            public bool IsOSNOVICAZAPINull()
            {
                return this.IsNull(this.tablesp_zap1.OSNOVICAZAPIColumn);
            }

            public bool IsOSNOVICAZAPNull()
            {
                return this.IsNull(this.tablesp_zap1.OSNOVICAZAPColumn);
            }

            public bool IsOSNOVICAZDRONull()
            {
                return this.IsNull(this.tablesp_zap1.OSNOVICAZDROColumn);
            }

            public bool IsOSNOVICAZDRPNull()
            {
                return this.IsNull(this.tablesp_zap1.OSNOVICAZDRPColumn);
            }

            public bool IsSTOPAMIOIINull()
            {
                return this.IsNull(this.tablesp_zap1.STOPAMIOIIColumn);
            }

            public bool IsSTOPAMIOINull()
            {
                return this.IsNull(this.tablesp_zap1.STOPAMIOIColumn);
            }

            public bool IsSTOPAZAPINull()
            {
                return this.IsNull(this.tablesp_zap1.STOPAZAPIColumn);
            }

            public bool IsSTOPAZAPNull()
            {
                return this.IsNull(this.tablesp_zap1.STOPAZAPColumn);
            }

            public bool IsSTOPAZDRONull()
            {
                return this.IsNull(this.tablesp_zap1.STOPAZDROColumn);
            }

            public bool IsSTOPAZDRPNull()
            {
                return this.IsNull(this.tablesp_zap1.STOPAZDRPColumn);
            }

            public bool IsukupnobrutoNull()
            {
                return this.IsNull(this.tablesp_zap1.ukupnobrutoColumn);
            }

            public bool IsUKUPNODOHODAKNull()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNODOHODAKColumn);
            }

            public bool IsUKUPNODOPRINOSIIZNull()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNODOPRINOSIIZColumn);
            }

            public bool IsUKUPNODOPRINOSINANull()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNODOPRINOSINAColumn);
            }

            public bool IsUKUPNOMIOIINull()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNOMIOIIColumn);
            }

            public bool IsUKUPNOMIOINull()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNOMIOIColumn);
            }

            public bool IsukupnoolaksiceNull()
            {
                return this.IsNull(this.tablesp_zap1.ukupnoolaksiceColumn);
            }

            public bool IsUKUPNOOONull()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNOOOColumn);
            }

            public bool IsUKUPNOPOREZDOFAKTOO2Null()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNOPOREZDOFAKTOO2Column);
            }

            public bool IsUKUPNOPOREZNull()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNOPOREZColumn);
            }

            public bool IsUKUPNOPOREZODFAKTOO2DO5Null()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNOPOREZODFAKTOO2DO5Column);
            }

            public bool IsUKUPNOPOREZODFAKTOO5Null()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNOPOREZODFAKTOO5Column);
            }

            public bool IsUKUPNOPRIREZNull()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNOPRIREZColumn);
            }

            public bool IsUKUPNOZAPINull()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNOZAPIColumn);
            }

            public bool IsUKUPNOZAPNull()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNOZAPColumn);
            }

            public bool IsUKUPNOZDRONull()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNOZDROColumn);
            }

            public bool IsUKUPNOZDRPNull()
            {
                return this.IsNull(this.tablesp_zap1.UKUPNOZDRPColumn);
            }

            public void SetBROJRACUNAZAP1Null()
            {
                this[this.tablesp_zap1.BROJRACUNAZAP1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJRADNIKANull()
            {
                this[this.tablesp_zap1.BROJRADNIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSPLACEIZNALOGAZAISPLATUNull()
            {
                this[this.tablesp_zap1.IZNOSPLACEIZNALOGAZAISPLATUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAMIOIINull()
            {
                this[this.tablesp_zap1.OSNOVICAMIOIIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAMIOINull()
            {
                this[this.tablesp_zap1.OSNOVICAMIOIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAPOREZNull()
            {
                this[this.tablesp_zap1.OSNOVICAPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAZAPINull()
            {
                this[this.tablesp_zap1.OSNOVICAZAPIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAZAPNull()
            {
                this[this.tablesp_zap1.OSNOVICAZAPColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAZDRONull()
            {
                this[this.tablesp_zap1.OSNOVICAZDROColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAZDRPNull()
            {
                this[this.tablesp_zap1.OSNOVICAZDRPColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAMIOIINull()
            {
                this[this.tablesp_zap1.STOPAMIOIIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAMIOINull()
            {
                this[this.tablesp_zap1.STOPAMIOIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAZAPINull()
            {
                this[this.tablesp_zap1.STOPAZAPIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAZAPNull()
            {
                this[this.tablesp_zap1.STOPAZAPColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAZDRONull()
            {
                this[this.tablesp_zap1.STOPAZDROColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAZDRPNull()
            {
                this[this.tablesp_zap1.STOPAZDRPColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnobrutoNull()
            {
                this[this.tablesp_zap1.ukupnobrutoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNODOHODAKNull()
            {
                this[this.tablesp_zap1.UKUPNODOHODAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNODOPRINOSIIZNull()
            {
                this[this.tablesp_zap1.UKUPNODOPRINOSIIZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNODOPRINOSINANull()
            {
                this[this.tablesp_zap1.UKUPNODOPRINOSINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOMIOIINull()
            {
                this[this.tablesp_zap1.UKUPNOMIOIIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOMIOINull()
            {
                this[this.tablesp_zap1.UKUPNOMIOIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnoolaksiceNull()
            {
                this[this.tablesp_zap1.ukupnoolaksiceColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOOONull()
            {
                this[this.tablesp_zap1.UKUPNOOOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOPOREZDOFAKTOO2Null()
            {
                this[this.tablesp_zap1.UKUPNOPOREZDOFAKTOO2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOPOREZNull()
            {
                this[this.tablesp_zap1.UKUPNOPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOPOREZODFAKTOO2DO5Null()
            {
                this[this.tablesp_zap1.UKUPNOPOREZODFAKTOO2DO5Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOPOREZODFAKTOO5Null()
            {
                this[this.tablesp_zap1.UKUPNOPOREZODFAKTOO5Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOPRIREZNull()
            {
                this[this.tablesp_zap1.UKUPNOPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOZAPINull()
            {
                this[this.tablesp_zap1.UKUPNOZAPIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOZAPNull()
            {
                this[this.tablesp_zap1.UKUPNOZAPColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOZDRONull()
            {
                this[this.tablesp_zap1.UKUPNOZDROColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOZDRPNull()
            {
                this[this.tablesp_zap1.UKUPNOZDRPColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string BROJRACUNAZAP1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_zap1.BROJRACUNAZAP1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_zap1.BROJRACUNAZAP1Column] = value;
                }
            }

            public decimal BROJRADNIKA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.BROJRADNIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.BROJRADNIKAColumn] = value;
                }
            }

            public decimal IZNOSPLACEIZNALOGAZAISPLATU
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.IZNOSPLACEIZNALOGAZAISPLATUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.IZNOSPLACEIZNALOGAZAISPLATUColumn] = value;
                }
            }

            public decimal OSNOVICAMIOI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.OSNOVICAMIOIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.OSNOVICAMIOIColumn] = value;
                }
            }

            public decimal OSNOVICAMIOII
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.OSNOVICAMIOIIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.OSNOVICAMIOIIColumn] = value;
                }
            }

            public decimal OSNOVICAPOREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.OSNOVICAPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.OSNOVICAPOREZColumn] = value;
                }
            }

            public decimal OSNOVICAZAP
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.OSNOVICAZAPColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.OSNOVICAZAPColumn] = value;
                }
            }

            public decimal OSNOVICAZAPI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.OSNOVICAZAPIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.OSNOVICAZAPIColumn] = value;
                }
            }

            public decimal OSNOVICAZDRO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.OSNOVICAZDROColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.OSNOVICAZDROColumn] = value;
                }
            }

            public decimal OSNOVICAZDRP
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.OSNOVICAZDRPColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.OSNOVICAZDRPColumn] = value;
                }
            }

            public decimal STOPAMIOI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.STOPAMIOIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.STOPAMIOIColumn] = value;
                }
            }

            public decimal STOPAMIOII
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.STOPAMIOIIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.STOPAMIOIIColumn] = value;
                }
            }

            public decimal STOPAZAP
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.STOPAZAPColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.STOPAZAPColumn] = value;
                }
            }

            public decimal STOPAZAPI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.STOPAZAPIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.STOPAZAPIColumn] = value;
                }
            }

            public decimal STOPAZDRO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.STOPAZDROColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.STOPAZDROColumn] = value;
                }
            }

            public decimal STOPAZDRP
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.STOPAZDRPColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.STOPAZDRPColumn] = value;
                }
            }

            public decimal ukupnobruto
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.ukupnobrutoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.ukupnobrutoColumn] = value;
                }
            }

            public decimal UKUPNODOHODAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNODOHODAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNODOHODAKColumn] = value;
                }
            }

            public decimal UKUPNODOPRINOSIIZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNODOPRINOSIIZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNODOPRINOSIIZColumn] = value;
                }
            }

            public decimal UKUPNODOPRINOSINA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNODOPRINOSINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNODOPRINOSINAColumn] = value;
                }
            }

            public decimal UKUPNOMIOI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNOMIOIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNOMIOIColumn] = value;
                }
            }

            public decimal UKUPNOMIOII
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNOMIOIIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNOMIOIIColumn] = value;
                }
            }

            public decimal ukupnoolaksice
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.ukupnoolaksiceColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.ukupnoolaksiceColumn] = value;
                }
            }

            public decimal UKUPNOOO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNOOOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNOOOColumn] = value;
                }
            }

            public decimal UKUPNOPOREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNOPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNOPOREZColumn] = value;
                }
            }

            public int UKUPNOPOREZDOFAKTOO2
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablesp_zap1.UKUPNOPOREZDOFAKTOO2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNOPOREZDOFAKTOO2Column] = value;
                }
            }

            public decimal UKUPNOPOREZODFAKTOO2DO5
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNOPOREZODFAKTOO2DO5Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNOPOREZODFAKTOO2DO5Column] = value;
                }
            }

            public decimal UKUPNOPOREZODFAKTOO5
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNOPOREZODFAKTOO5Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNOPOREZODFAKTOO5Column] = value;
                }
            }

            public decimal UKUPNOPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNOPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNOPRIREZColumn] = value;
                }
            }

            public decimal UKUPNOZAP
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNOZAPColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNOZAPColumn] = value;
                }
            }

            public decimal UKUPNOZAPI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNOZAPIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNOZAPIColumn] = value;
                }
            }

            public decimal UKUPNOZDRO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNOZDROColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNOZDROColumn] = value;
                }
            }

            public decimal UKUPNOZDRP
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_zap1.UKUPNOZDRPColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_zap1.UKUPNOZDRPColumn] = value;
                }
            }
        }

        public class sp_zap1RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private sp_zap1DataSet.sp_zap1Row eventRow;

            public sp_zap1RowChangeEvent(sp_zap1DataSet.sp_zap1Row row, DataRowAction action)
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

            public sp_zap1DataSet.sp_zap1Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void sp_zap1RowChangeEventHandler(object sender, sp_zap1DataSet.sp_zap1RowChangeEvent e);
    }
}

