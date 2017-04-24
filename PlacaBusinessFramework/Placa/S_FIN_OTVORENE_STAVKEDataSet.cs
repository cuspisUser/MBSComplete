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
    public class S_FIN_OTVORENE_STAVKEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_FIN_OTVORENE_STAVKEDataTable tableS_FIN_OTVORENE_STAVKE;

        public S_FIN_OTVORENE_STAVKEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_FIN_OTVORENE_STAVKEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_FIN_OTVORENE_STAVKE"] != null)
                    {
                        this.Tables.Add(new S_FIN_OTVORENE_STAVKEDataTable(dataSet.Tables["S_FIN_OTVORENE_STAVKE"]));
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
            S_FIN_OTVORENE_STAVKEDataSet set = (S_FIN_OTVORENE_STAVKEDataSet) base.Clone();
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
            S_FIN_OTVORENE_STAVKEDataSet set = new S_FIN_OTVORENE_STAVKEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_FIN_OTVORENE_STAVKEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2169");
            this.ExtendedProperties.Add("DataSetName", "S_FIN_OTVORENE_STAVKEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_FIN_OTVORENE_STAVKEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_FIN_OTVORENE_STAVKE");
            this.ExtendedProperties.Add("ObjectDescription", "S_FIN_OTVORENE_STAVKE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_FIN_OTVORENE_STAVKE");
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
            this.DataSetName = "S_FIN_OTVORENE_STAVKEDataSet";
            this.Namespace = "http://www.tempuri.org/S_FIN_OTVORENE_STAVKE";
            this.tableS_FIN_OTVORENE_STAVKE = new S_FIN_OTVORENE_STAVKEDataTable();
            this.Tables.Add(this.tableS_FIN_OTVORENE_STAVKE);
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
            this.tableS_FIN_OTVORENE_STAVKE = (S_FIN_OTVORENE_STAVKEDataTable) this.Tables["S_FIN_OTVORENE_STAVKE"];
            if (initTable && (this.tableS_FIN_OTVORENE_STAVKE != null))
            {
                this.tableS_FIN_OTVORENE_STAVKE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_FIN_OTVORENE_STAVKE"] != null)
                {
                    this.Tables.Add(new S_FIN_OTVORENE_STAVKEDataTable(dataSet.Tables["S_FIN_OTVORENE_STAVKE"]));
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

        private bool ShouldSerializeS_FIN_OTVORENE_STAVKE()
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
        public S_FIN_OTVORENE_STAVKEDataTable S_FIN_OTVORENE_STAVKE
        {
            get
            {
                return this.tableS_FIN_OTVORENE_STAVKE;
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
        public class S_FIN_OTVORENE_STAVKEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJDOK;
            private DataColumn columnBROJSTAVKE;
            private DataColumn columnDATUMDOK;
            private DataColumn columnDATUMDVO;
            private DataColumn columnDATUMVALUTE;
            private DataColumn columnduguje;
            private DataColumn columnIDDOKUMENT;
            private DataColumn columnIDGKSTAVKA;
            private DataColumn columnIDMJESTOTROSKA;
            private DataColumn columnIDORGJED;
            private DataColumn columnIDPARTNER;
            private DataColumn columnkonto;
            private DataColumn columnMB;
            private DataColumn columnNAZIV;
            private DataColumn columnNAZIVMT;
            private DataColumn columnNAZIVOJ;
            private DataColumn columnNAZIVPARTNER;
            private DataColumn columnPARTNEROIB;
            private DataColumn columnOPISKNJIZENJA;
            private DataColumn columnORIGINALNIDOKUMENT;
            private DataColumn columnOTVORENO;
            private DataColumn columnPARTNERMJESTO;
            private DataColumn columnPARTNERULICA;
            private DataColumn columnPOTRAZUJE;
            private DataColumn columnSKRACENI;

            public event S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERowChangeEventHandler S_FIN_OTVORENE_STAVKERowChanged;

            public event S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERowChangeEventHandler S_FIN_OTVORENE_STAVKERowChanging;

            public event S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERowChangeEventHandler S_FIN_OTVORENE_STAVKERowDeleted;

            public event S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERowChangeEventHandler S_FIN_OTVORENE_STAVKERowDeleting;

            public S_FIN_OTVORENE_STAVKEDataTable()
            {
                this.TableName = "S_FIN_OTVORENE_STAVKE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_FIN_OTVORENE_STAVKEDataTable(DataTable table) : base(table.TableName)
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

            protected S_FIN_OTVORENE_STAVKEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_FIN_OTVORENE_STAVKERow(S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow row)
            {
                this.Rows.Add(row);
            }

            public S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow AddS_FIN_OTVORENE_STAVKERow(decimal duguje, decimal pOTRAZUJE, string konto, DateTime dATUMDVO, DateTime dATUMVALUTE, DateTime dATUMDOK, string sKRACENI, int bROJDOK, int bROJSTAVKE, string oPISKNJIZENJA, int iDPARTNER, decimal oTVORENO, string nAZIV, int iDDOKUMENT, string nAZIVPARTNER, int iDORGJED, int iDMJESTOTROSKA, string mB, string pARTNERMJESTO, string pARTNERULICA, int iDGKSTAVKA, string oRIGINALNIDOKUMENT, string nAZIVOJ, string nAZIVMT)
            {
                S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow row = (S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow) this.NewRow();
                row.ItemArray = new object[] { 
                    duguje, pOTRAZUJE, konto, dATUMDVO, dATUMVALUTE, dATUMDOK, sKRACENI, bROJDOK, bROJSTAVKE, oPISKNJIZENJA, iDPARTNER, oTVORENO, nAZIV, iDDOKUMENT, nAZIVPARTNER, iDORGJED, 
                    iDMJESTOTROSKA, mB, pARTNERMJESTO, pARTNERULICA, iDGKSTAVKA, oRIGINALNIDOKUMENT, nAZIVOJ, nAZIVMT
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKEDataTable table = (S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_FIN_OTVORENE_STAVKEDataSet set = new S_FIN_OTVORENE_STAVKEDataSet();
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
                this.columnDATUMDVO = new DataColumn("DATUMDVO", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMDVO.Caption = "DATUMDVO";
                this.columnDATUMDVO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMDVO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMDVO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMDVO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMDVO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMDVO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMDVO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDATUMDVO.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMDVO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMDVO.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMDVO.ExtendedProperties.Add("Description", "DATUMDVO");
                this.columnDATUMDVO.ExtendedProperties.Add("Length", "8");
                this.columnDATUMDVO.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMDVO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMDVO.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMDVO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMDVO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMDVO.ExtendedProperties.Add("Deklarit.InternalName", "DATUMDVO");
                this.Columns.Add(this.columnDATUMDVO);
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
                this.columnIDPARTNER = new DataColumn("IDPARTNER", typeof(int), "", MappingType.Element);
                this.columnIDPARTNER.Caption = "Šifra partnera";
                this.columnIDPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPARTNER.ExtendedProperties.Add("Description", "Šifra partnera");
                this.columnIDPARTNER.ExtendedProperties.Add("Length", "9");
                this.columnIDPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "IDPARTNER");
                this.Columns.Add(this.columnIDPARTNER);
                this.columnOTVORENO = new DataColumn("OTVORENO", typeof(decimal), "", MappingType.Element);
                this.columnOTVORENO.Caption = "OTVORENO";
                this.columnOTVORENO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOTVORENO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOTVORENO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOTVORENO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOTVORENO.ExtendedProperties.Add("IsKey", "false");
                this.columnOTVORENO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOTVORENO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOTVORENO.ExtendedProperties.Add("Description", "OTVORENO");
                this.columnOTVORENO.ExtendedProperties.Add("Length", "12");
                this.columnOTVORENO.ExtendedProperties.Add("Decimals", "2");
                this.columnOTVORENO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOTVORENO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOTVORENO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOTVORENO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOTVORENO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOTVORENO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOTVORENO.ExtendedProperties.Add("Deklarit.InternalName", "OTVORENO");
                this.Columns.Add(this.columnOTVORENO);
                this.columnNAZIV = new DataColumn("NAZIV", typeof(string), "", MappingType.Element);
                this.columnNAZIV.Caption = "NAZIV";
                this.columnNAZIV.MaxLength = 150;
                this.columnNAZIV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIV.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIV.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIV.ExtendedProperties.Add("Description", "NAZIV");
                this.columnNAZIV.ExtendedProperties.Add("Length", "150");
                this.columnNAZIV.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIV.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIV.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.InternalName", "NAZIV");
                this.Columns.Add(this.columnNAZIV);
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
                this.columnPARTNEROIB.Caption = "Partner OIB";
                this.columnPARTNEROIB.MaxLength = 100;
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
                this.columnPARTNEROIB.ExtendedProperties.Add("Description", "Partner OIB");
                this.columnPARTNEROIB.ExtendedProperties.Add("Length", "100");
                this.columnPARTNEROIB.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNEROIB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("RightTrim", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.InternalName", "PARTNEROIB");
                this.Columns.Add(this.columnPARTNEROIB);


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
                this.columnPARTNERMJESTO = new DataColumn("PARTNERMJESTO", typeof(string), "", MappingType.Element);
                this.columnPARTNERMJESTO.Caption = "PARTNERMJESTO";
                this.columnPARTNERMJESTO.MaxLength = 50;
                this.columnPARTNERMJESTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Description", "PARTNERMJESTO");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Length", "50");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERMJESTO");
                this.Columns.Add(this.columnPARTNERMJESTO);
                this.columnPARTNERULICA = new DataColumn("PARTNERULICA", typeof(string), "", MappingType.Element);
                this.columnPARTNERULICA.Caption = "PARTNERULICA";
                this.columnPARTNERULICA.MaxLength = 150;
                this.columnPARTNERULICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERULICA.ExtendedProperties.Add("Description", "PARTNERULICA");
                this.columnPARTNERULICA.ExtendedProperties.Add("Length", "150");
                this.columnPARTNERULICA.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERULICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERULICA");
                this.Columns.Add(this.columnPARTNERULICA);
                this.columnIDGKSTAVKA = new DataColumn("IDGKSTAVKA", typeof(int), "", MappingType.Element);
                this.columnIDGKSTAVKA.Caption = "IDGKSTAVKA";
                this.columnIDGKSTAVKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Description", "IDGKSTAVKA");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Length", "5");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.InternalName", "IDGKSTAVKA");
                this.Columns.Add(this.columnIDGKSTAVKA);
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
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_FIN_OTVORENE_STAVKE");
                this.ExtendedProperties.Add("Description", "S_FIN_OTVORENE_STAVKE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnduguje = this.Columns["duguje"];
                this.columnPOTRAZUJE = this.Columns["POTRAZUJE"];
                this.columnkonto = this.Columns["konto"];
                this.columnDATUMDVO = this.Columns["DATUMDVO"];
                this.columnDATUMVALUTE = this.Columns["DATUMVALUTE"];
                this.columnDATUMDOK = this.Columns["DATUMDOK"];
                this.columnSKRACENI = this.Columns["SKRACENI"];
                this.columnBROJDOK = this.Columns["BROJDOK"];
                this.columnBROJSTAVKE = this.Columns["BROJSTAVKE"];
                this.columnOPISKNJIZENJA = this.Columns["OPISKNJIZENJA"];
                this.columnIDPARTNER = this.Columns["IDPARTNER"];
                this.columnOTVORENO = this.Columns["OTVORENO"];
                this.columnNAZIV = this.Columns["NAZIV"];
                this.columnIDDOKUMENT = this.Columns["IDDOKUMENT"];
                this.columnNAZIVPARTNER = this.Columns["NAZIVPARTNER"];

                this.columnPARTNEROIB = this.Columns["PARTNEROIB"];

                this.columnIDORGJED = this.Columns["IDORGJED"];
                this.columnIDMJESTOTROSKA = this.Columns["IDMJESTOTROSKA"];
                this.columnMB = this.Columns["MB"];
                this.columnPARTNERMJESTO = this.Columns["PARTNERMJESTO"];
                this.columnPARTNERULICA = this.Columns["PARTNERULICA"];
                this.columnIDGKSTAVKA = this.Columns["IDGKSTAVKA"];
                this.columnORIGINALNIDOKUMENT = this.Columns["ORIGINALNIDOKUMENT"];
                this.columnNAZIVOJ = this.Columns["NAZIVOJ"];
                this.columnNAZIVMT = this.Columns["NAZIVMT"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow(builder);
            }

            public S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow NewS_FIN_OTVORENE_STAVKERow()
            {
                return (S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_FIN_OTVORENE_STAVKERowChanged != null)
                {
                    S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERowChangeEventHandler handler = this.S_FIN_OTVORENE_STAVKERowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERowChangeEvent((S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_FIN_OTVORENE_STAVKERowChanging != null)
                {
                    S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERowChangeEventHandler handler = this.S_FIN_OTVORENE_STAVKERowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERowChangeEvent((S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_FIN_OTVORENE_STAVKERowDeleted != null)
                {
                    S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERowChangeEventHandler handler = this.S_FIN_OTVORENE_STAVKERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERowChangeEvent((S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_FIN_OTVORENE_STAVKERowDeleting != null)
                {
                    S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERowChangeEventHandler handler = this.S_FIN_OTVORENE_STAVKERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERowChangeEvent((S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_FIN_OTVORENE_STAVKERow(S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow row)
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

            public DataColumn DATUMDVOColumn
            {
                get
                {
                    return this.columnDATUMDVO;
                }
            }

            public DataColumn DATUMVALUTEColumn
            {
                get
                {
                    return this.columnDATUMVALUTE;
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

            public DataColumn IDGKSTAVKAColumn
            {
                get
                {
                    return this.columnIDGKSTAVKA;
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

            public DataColumn IDPARTNERColumn
            {
                get
                {
                    return this.columnIDPARTNER;
                }
            }

            public S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow this[int index]
            {
                get
                {
                    return (S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow) this.Rows[index];
                }
            }

            public DataColumn kontoColumn
            {
                get
                {
                    return this.columnkonto;
                }
            }

            public DataColumn MBColumn
            {
                get
                {
                    return this.columnMB;
                }
            }

            public DataColumn NAZIVColumn
            {
                get
                {
                    return this.columnNAZIV;
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

            public DataColumn NAZIVPARTNERColumn
            {
                get
                {
                    return this.columnNAZIVPARTNER;
                }
            }

            public DataColumn PARTNEROIBColumn
            {
                get
                {
                    return this.columnPARTNEROIB;
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

            public DataColumn OTVORENOColumn
            {
                get
                {
                    return this.columnOTVORENO;
                }
            }

            public DataColumn PARTNERMJESTOColumn
            {
                get
                {
                    return this.columnPARTNERMJESTO;
                }
            }

            public DataColumn PARTNERULICAColumn
            {
                get
                {
                    return this.columnPARTNERULICA;
                }
            }

            public DataColumn POTRAZUJEColumn
            {
                get
                {
                    return this.columnPOTRAZUJE;
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

        public class S_FIN_OTVORENE_STAVKERow : DataRow
        {
            private S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKEDataTable tableS_FIN_OTVORENE_STAVKE;

            internal S_FIN_OTVORENE_STAVKERow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_FIN_OTVORENE_STAVKE = (S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKEDataTable) this.Table;
            }

            public bool IsBROJDOKNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.BROJDOKColumn);
            }

            public bool IsBROJSTAVKENull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.BROJSTAVKEColumn);
            }

            public bool IsDATUMDOKNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.DATUMDOKColumn);
            }

            public bool IsDATUMDVONull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.DATUMDVOColumn);
            }

            public bool IsDATUMVALUTENull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.DATUMVALUTEColumn);
            }

            public bool IsdugujeNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.dugujeColumn);
            }

            public bool IsIDDOKUMENTNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.IDDOKUMENTColumn);
            }

            public bool IsIDGKSTAVKANull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.IDGKSTAVKAColumn);
            }

            public bool IsIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.IDMJESTOTROSKAColumn);
            }

            public bool IsIDORGJEDNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.IDORGJEDColumn);
            }

            public bool IsIDPARTNERNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.IDPARTNERColumn);
            }

            public bool IskontoNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.kontoColumn);
            }

            public bool IsMBNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.MBColumn);
            }

            public bool IsNAZIVMTNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.NAZIVMTColumn);
            }

            public bool IsNAZIVNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.NAZIVColumn);
            }

            public bool IsNAZIVOJNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.NAZIVOJColumn);
            }

            public bool IsNAZIVPARTNERNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.NAZIVPARTNERColumn);
            }

            public bool IsNPARTNEROIBNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.PARTNEROIBColumn);
            }

            public bool IsOPISKNJIZENJANull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.OPISKNJIZENJAColumn);
            }

            public bool IsORIGINALNIDOKUMENTNull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.ORIGINALNIDOKUMENTColumn);
            }

            public bool IsOTVORENONull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.OTVORENOColumn);
            }

            public bool IsPARTNERMJESTONull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.PARTNERMJESTOColumn);
            }

            public bool IsPARTNERULICANull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.PARTNERULICAColumn);
            }

            public bool IsPOTRAZUJENull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.POTRAZUJEColumn);
            }

            public bool IsSKRACENINull()
            {
                return this.IsNull(this.tableS_FIN_OTVORENE_STAVKE.SKRACENIColumn);
            }

            public void SetBROJDOKNull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.BROJDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJSTAVKENull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.BROJSTAVKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMDOKNull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.DATUMDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMDVONull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.DATUMDVOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMVALUTENull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.DATUMVALUTEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetdugujeNull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.dugujeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDDOKUMENTNull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.IDDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDGKSTAVKANull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.IDGKSTAVKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDMJESTOTROSKANull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.IDMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDORGJEDNull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.IDORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDPARTNERNull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.IDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetkontoNull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.kontoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMBNull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.MBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVMTNull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.NAZIVMTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVNull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.NAZIVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOJNull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.NAZIVOJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPARTNERNull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.NAZIVPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISKNJIZENJANull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.OPISKNJIZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetORIGINALNIDOKUMENTNull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.ORIGINALNIDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOTVORENONull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.OTVORENOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERMJESTONull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.PARTNERMJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERULICANull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.PARTNERULICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOTRAZUJENull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.POTRAZUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSKRACENINull()
            {
                this[this.tableS_FIN_OTVORENE_STAVKE.SKRACENIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BROJDOK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_OTVORENE_STAVKE.BROJDOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.BROJDOKColumn] = value;
                }
            }

            public int BROJSTAVKE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_OTVORENE_STAVKE.BROJSTAVKEColumn]);
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
                    this[this.tableS_FIN_OTVORENE_STAVKE.BROJSTAVKEColumn] = value;
                }
            }

            public DateTime DATUMDOK
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_FIN_OTVORENE_STAVKE.DATUMDOKColumn]);
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
                    this[this.tableS_FIN_OTVORENE_STAVKE.DATUMDOKColumn] = value;
                }
            }

            public DateTime DATUMDVO
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_FIN_OTVORENE_STAVKE.DATUMDVOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DATUMDVO because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.DATUMDVOColumn] = value;
                }
            }

            public DateTime DATUMVALUTE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_FIN_OTVORENE_STAVKE.DATUMVALUTEColumn]);
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
                    this[this.tableS_FIN_OTVORENE_STAVKE.DATUMVALUTEColumn] = value;
                }
            }

            public decimal duguje
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_OTVORENE_STAVKE.dugujeColumn]);
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
                    this[this.tableS_FIN_OTVORENE_STAVKE.dugujeColumn] = value;
                }
            }

            public int IDDOKUMENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_OTVORENE_STAVKE.IDDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDDOKUMENT because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.IDDOKUMENTColumn] = value;
                }
            }

            public int IDGKSTAVKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_OTVORENE_STAVKE.IDGKSTAVKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDGKSTAVKA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.IDGKSTAVKAColumn] = value;
                }
            }

            public int IDMJESTOTROSKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_OTVORENE_STAVKE.IDMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDMJESTOTROSKA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.IDMJESTOTROSKAColumn] = value;
                }
            }

            public int IDORGJED
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_OTVORENE_STAVKE.IDORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDORGJED because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.IDORGJEDColumn] = value;
                }
            }

            public int IDPARTNER
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_OTVORENE_STAVKE.IDPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDPARTNER because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.IDPARTNERColumn] = value;
                }
            }

            public string konto
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_OTVORENE_STAVKE.kontoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value konto because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.kontoColumn] = value;
                }
            }

            public string MB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_OTVORENE_STAVKE.MBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value MB because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.MBColumn] = value;
                }
            }

            public string NAZIV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_OTVORENE_STAVKE.NAZIVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.NAZIVColumn] = value;
                }
            }

            public string NAZIVMT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_OTVORENE_STAVKE.NAZIVMTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.NAZIVMTColumn] = value;
                }
            }

            public string NAZIVOJ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_OTVORENE_STAVKE.NAZIVOJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.NAZIVOJColumn] = value;
                }
            }

            public string NAZIVPARTNER
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_OTVORENE_STAVKE.NAZIVPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.NAZIVPARTNERColumn] = value;
                }
            }

            public string PARTNEROIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_OTVORENE_STAVKE.PARTNEROIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.PARTNEROIBColumn] = value;
                }
            }

            public string OPISKNJIZENJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_OTVORENE_STAVKE.OPISKNJIZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.OPISKNJIZENJAColumn] = value;
                }
            }

            public string ORIGINALNIDOKUMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_OTVORENE_STAVKE.ORIGINALNIDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.ORIGINALNIDOKUMENTColumn] = value;
                }
            }

            public decimal OTVORENO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_OTVORENE_STAVKE.OTVORENOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.OTVORENOColumn] = value;
                }
            }

            public string PARTNERMJESTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_OTVORENE_STAVKE.PARTNERMJESTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.PARTNERMJESTOColumn] = value;
                }
            }

            public string PARTNERULICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_OTVORENE_STAVKE.PARTNERULICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.PARTNERULICAColumn] = value;
                }
            }

            public decimal POTRAZUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_OTVORENE_STAVKE.POTRAZUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.POTRAZUJEColumn] = value;
                }
            }

            public string SKRACENI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_OTVORENE_STAVKE.SKRACENIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_OTVORENE_STAVKE.SKRACENIColumn] = value;
                }
            }
        }

        public class S_FIN_OTVORENE_STAVKERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow eventRow;

            public S_FIN_OTVORENE_STAVKERowChangeEvent(S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow row, DataRowAction action)
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

            public S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_FIN_OTVORENE_STAVKERowChangeEventHandler(object sender, S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERowChangeEvent e);
    }
}

