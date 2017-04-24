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
    public class sp_ip_detaljiDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private sp_ip_detaljiDataTable tablesp_ip_detalji;

        public sp_ip_detaljiDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected sp_ip_detaljiDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["sp_ip_detalji"] != null)
                    {
                        this.Tables.Add(new sp_ip_detaljiDataTable(dataSet.Tables["sp_ip_detalji"]));
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
            sp_ip_detaljiDataSet set = (sp_ip_detaljiDataSet) base.Clone();
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
            sp_ip_detaljiDataSet set = new sp_ip_detaljiDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "sp_ip_detaljiDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2035");
            this.ExtendedProperties.Add("DataSetName", "sp_ip_detaljiDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Isp_ip_detaljiDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "sp_ip_detalji");
            this.ExtendedProperties.Add("ObjectDescription", "sp_ip_detalji");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_IP_REDOVI");
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
            this.DataSetName = "sp_ip_detaljiDataSet";
            this.Namespace = "http://www.tempuri.org/sp_ip_detalji";
            this.tablesp_ip_detalji = new sp_ip_detaljiDataTable();
            this.Tables.Add(this.tablesp_ip_detalji);
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
            this.tablesp_ip_detalji = (sp_ip_detaljiDataTable) this.Tables["sp_ip_detalji"];
            if (initTable && (this.tablesp_ip_detalji != null))
            {
                this.tablesp_ip_detalji.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["sp_ip_detalji"] != null)
                {
                    this.Tables.Add(new sp_ip_detaljiDataTable(dataSet.Tables["sp_ip_detalji"]));
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

        private bool ShouldSerializesp_ip_detalji()
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
        public sp_ip_detaljiDataTable sp_ip_detalji
        {
            get
            {
                return this.tablesp_ip_detalji;
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
        public class sp_ip_detaljiDataTable : DataTable, IEnumerable
        {
            private DataColumn columndohodak;
            private DataColumn columnIDIPIDENT;
            private DataColumn columnidopcinestanovanja;
            private DataColumn columnJMBG;
            private DataColumn columnMJESECISPLATE;
            private DataColumn columnnetoisplata;
            private DataColumn columnnetoplaca;
            private DataColumn columnOIB;
            private DataColumn columnPOREZKRIZNI;
            private DataColumn columnporeznaosnovica;
            private DataColumn columnukupnobruto;
            private DataColumn columnukupnodoprinosi;
            private DataColumn columnUKUPNOOO;
            private DataColumn columnukupnoporeziprirez;
            private DataColumn columnukupnoporeznopriznateolaksice;

            public event sp_ip_detaljiDataSet.sp_ip_detaljiRowChangeEventHandler sp_ip_detaljiRowChanged;

            public event sp_ip_detaljiDataSet.sp_ip_detaljiRowChangeEventHandler sp_ip_detaljiRowChanging;

            public event sp_ip_detaljiDataSet.sp_ip_detaljiRowChangeEventHandler sp_ip_detaljiRowDeleted;

            public event sp_ip_detaljiDataSet.sp_ip_detaljiRowChangeEventHandler sp_ip_detaljiRowDeleting;

            public sp_ip_detaljiDataTable()
            {
                this.TableName = "sp_ip_detalji";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal sp_ip_detaljiDataTable(DataTable table) : base(table.TableName)
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

            protected sp_ip_detaljiDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void Addsp_ip_detaljiRow(sp_ip_detaljiDataSet.sp_ip_detaljiRow row)
            {
                this.Rows.Add(row);
            }

            public sp_ip_detaljiDataSet.sp_ip_detaljiRow Addsp_ip_detaljiRow(string jMBG, int iDIPIDENT, string mJESECISPLATE, string idopcinestanovanja, decimal ukupnobruto, decimal ukupnodoprinosi, decimal ukupnoporeznopriznateolaksice, decimal dohodak, decimal uKUPNOOO, decimal poreznaosnovica, decimal ukupnoporeziprirez, decimal netoisplata, decimal netoplaca, decimal pOREZKRIZNI, string oIB)
            {
                sp_ip_detaljiDataSet.sp_ip_detaljiRow row = (sp_ip_detaljiDataSet.sp_ip_detaljiRow) this.NewRow();
                row.ItemArray = new object[] { jMBG, iDIPIDENT, mJESECISPLATE, idopcinestanovanja, ukupnobruto, ukupnodoprinosi, ukupnoporeznopriznateolaksice, dohodak, uKUPNOOO, poreznaosnovica, ukupnoporeziprirez, netoisplata, netoplaca, pOREZKRIZNI, oIB };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                sp_ip_detaljiDataSet.sp_ip_detaljiDataTable table = (sp_ip_detaljiDataSet.sp_ip_detaljiDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(sp_ip_detaljiDataSet.sp_ip_detaljiRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                sp_ip_detaljiDataSet set = new sp_ip_detaljiDataSet();
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
                this.columnJMBG = new DataColumn("JMBG", typeof(string), "", MappingType.Element);
                this.columnJMBG.Caption = "JMBG";
                this.columnJMBG.MaxLength = 13;
                this.columnJMBG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnJMBG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnJMBG.ExtendedProperties.Add("IsKey", "false");
                this.columnJMBG.ExtendedProperties.Add("ReadOnly", "true");
                this.columnJMBG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnJMBG.ExtendedProperties.Add("Description", "JMBG");
                this.columnJMBG.ExtendedProperties.Add("Length", "13");
                this.columnJMBG.ExtendedProperties.Add("Decimals", "0");
                this.columnJMBG.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnJMBG.ExtendedProperties.Add("IsInReader", "true");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.InternalName", "JMBG");
                this.Columns.Add(this.columnJMBG);
                this.columnIDIPIDENT = new DataColumn("IDIPIDENT", typeof(int), "", MappingType.Element);
                this.columnIDIPIDENT.Caption = "IDIPIDENT";
                this.columnIDIPIDENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("IsKey", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDIPIDENT.ExtendedProperties.Add("Description", "IDIPIDENT");
                this.columnIDIPIDENT.ExtendedProperties.Add("Length", "5");
                this.columnIDIPIDENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDIPIDENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.InternalName", "IDIPIDENT");
                this.Columns.Add(this.columnIDIPIDENT);
                this.columnMJESECISPLATE = new DataColumn("MJESECISPLATE", typeof(string), "", MappingType.Element);
                this.columnMJESECISPLATE.Caption = "Mjesec isplate";
                this.columnMJESECISPLATE.MaxLength = 2;
                this.columnMJESECISPLATE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("IsKey", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Description", "Mjesec isplate");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Length", "2");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESECISPLATE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.InternalName", "MJESECISPLATE");
                this.Columns.Add(this.columnMJESECISPLATE);
                this.columnidopcinestanovanja = new DataColumn("idopcinestanovanja", typeof(string), "", MappingType.Element);
                this.columnidopcinestanovanja.Caption = "idopcinestanovanja";
                this.columnidopcinestanovanja.MaxLength = 4;
                this.columnidopcinestanovanja.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnidopcinestanovanja.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnidopcinestanovanja.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnidopcinestanovanja.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnidopcinestanovanja.ExtendedProperties.Add("IsKey", "false");
                this.columnidopcinestanovanja.ExtendedProperties.Add("ReadOnly", "true");
                this.columnidopcinestanovanja.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnidopcinestanovanja.ExtendedProperties.Add("Description", "idopcinestanovanja");
                this.columnidopcinestanovanja.ExtendedProperties.Add("Length", "4");
                this.columnidopcinestanovanja.ExtendedProperties.Add("Decimals", "0");
                this.columnidopcinestanovanja.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnidopcinestanovanja.ExtendedProperties.Add("IsInReader", "true");
                this.columnidopcinestanovanja.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnidopcinestanovanja.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnidopcinestanovanja.ExtendedProperties.Add("Deklarit.InternalName", "idopcinestanovanja");
                this.Columns.Add(this.columnidopcinestanovanja);
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
                this.columnukupnodoprinosi = new DataColumn("ukupnodoprinosi", typeof(decimal), "", MappingType.Element);
                this.columnukupnodoprinosi.Caption = "ukupnodoprinosi";
                this.columnukupnodoprinosi.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnodoprinosi.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnodoprinosi.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnodoprinosi.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Description", "ukupnodoprinosi");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Length", "12");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnodoprinosi.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnodoprinosi.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnodoprinosi.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnodoprinosi.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.InternalName", "ukupnodoprinosi");
                this.Columns.Add(this.columnukupnodoprinosi);
                this.columnukupnoporeznopriznateolaksice = new DataColumn("ukupnoporeznopriznateolaksice", typeof(decimal), "", MappingType.Element);
                this.columnukupnoporeznopriznateolaksice.Caption = "ukupnoporeznopriznateolaksice";
                this.columnukupnoporeznopriznateolaksice.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("Description", "ukupnoporeznopriznateolaksice");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("Length", "12");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnoporeznopriznateolaksice.ExtendedProperties.Add("Deklarit.InternalName", "ukupnoporeznopriznateolaksice");
                this.Columns.Add(this.columnukupnoporeznopriznateolaksice);
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
                this.columnukupnoporeziprirez = new DataColumn("ukupnoporeziprirez", typeof(decimal), "", MappingType.Element);
                this.columnukupnoporeziprirez.Caption = "ukupnoporeziprirez";
                this.columnukupnoporeziprirez.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Description", "ukupnoporeziprirez");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Length", "12");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Deklarit.InternalName", "ukupnoporeziprirez");
                this.Columns.Add(this.columnukupnoporeziprirez);
                this.columnnetoisplata = new DataColumn("netoisplata", typeof(decimal), "", MappingType.Element);
                this.columnnetoisplata.Caption = "netoisplata";
                this.columnnetoisplata.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnetoisplata.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnetoisplata.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnetoisplata.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnetoisplata.ExtendedProperties.Add("IsKey", "false");
                this.columnnetoisplata.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnetoisplata.ExtendedProperties.Add("DeklaritType", "int");
                this.columnnetoisplata.ExtendedProperties.Add("Description", "netoisplata");
                this.columnnetoisplata.ExtendedProperties.Add("Length", "12");
                this.columnnetoisplata.ExtendedProperties.Add("Decimals", "2");
                this.columnnetoisplata.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnnetoisplata.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnnetoisplata.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnetoisplata.ExtendedProperties.Add("IsInReader", "true");
                this.columnnetoisplata.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnetoisplata.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnetoisplata.ExtendedProperties.Add("Deklarit.InternalName", "netoisplata");
                this.Columns.Add(this.columnnetoisplata);
                this.columnnetoplaca = new DataColumn("netoplaca", typeof(decimal), "", MappingType.Element);
                this.columnnetoplaca.Caption = "netoplaca";
                this.columnnetoplaca.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnetoplaca.ExtendedProperties.Add("IsKey", "false");
                this.columnnetoplaca.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnetoplaca.ExtendedProperties.Add("DeklaritType", "int");
                this.columnnetoplaca.ExtendedProperties.Add("Description", "netoplaca");
                this.columnnetoplaca.ExtendedProperties.Add("Length", "12");
                this.columnnetoplaca.ExtendedProperties.Add("Decimals", "2");
                this.columnnetoplaca.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnnetoplaca.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnnetoplaca.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnetoplaca.ExtendedProperties.Add("IsInReader", "true");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.InternalName", "netoplaca");
                this.Columns.Add(this.columnnetoplaca);
                this.columnPOREZKRIZNI = new DataColumn("POREZKRIZNI", typeof(decimal), "", MappingType.Element);
                this.columnPOREZKRIZNI.Caption = "POREZKRIZNI";
                this.columnPOREZKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Description", "POREZKRIZNI");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Length", "12");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "POREZKRIZNI");
                this.Columns.Add(this.columnPOREZKRIZNI);
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
                this.ExtendedProperties.Add("LevelName", "sp_ip_detalji");
                this.ExtendedProperties.Add("Description", "SP_IP_DETALJI");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnJMBG = this.Columns["JMBG"];
                this.columnIDIPIDENT = this.Columns["IDIPIDENT"];
                this.columnMJESECISPLATE = this.Columns["MJESECISPLATE"];
                this.columnidopcinestanovanja = this.Columns["idopcinestanovanja"];
                this.columnukupnobruto = this.Columns["ukupnobruto"];
                this.columnukupnodoprinosi = this.Columns["ukupnodoprinosi"];
                this.columnukupnoporeznopriznateolaksice = this.Columns["ukupnoporeznopriznateolaksice"];
                this.columndohodak = this.Columns["dohodak"];
                this.columnUKUPNOOO = this.Columns["UKUPNOOO"];
                this.columnporeznaosnovica = this.Columns["poreznaosnovica"];
                this.columnukupnoporeziprirez = this.Columns["ukupnoporeziprirez"];
                this.columnnetoisplata = this.Columns["netoisplata"];
                this.columnnetoplaca = this.Columns["netoplaca"];
                this.columnPOREZKRIZNI = this.Columns["POREZKRIZNI"];
                this.columnOIB = this.Columns["OIB"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new sp_ip_detaljiDataSet.sp_ip_detaljiRow(builder);
            }

            public sp_ip_detaljiDataSet.sp_ip_detaljiRow Newsp_ip_detaljiRow()
            {
                return (sp_ip_detaljiDataSet.sp_ip_detaljiRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.sp_ip_detaljiRowChanged != null)
                {
                    sp_ip_detaljiDataSet.sp_ip_detaljiRowChangeEventHandler handler = this.sp_ip_detaljiRowChanged;
                    if (handler != null)
                    {
                        handler(this, new sp_ip_detaljiDataSet.sp_ip_detaljiRowChangeEvent((sp_ip_detaljiDataSet.sp_ip_detaljiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.sp_ip_detaljiRowChanging != null)
                {
                    sp_ip_detaljiDataSet.sp_ip_detaljiRowChangeEventHandler handler = this.sp_ip_detaljiRowChanging;
                    if (handler != null)
                    {
                        handler(this, new sp_ip_detaljiDataSet.sp_ip_detaljiRowChangeEvent((sp_ip_detaljiDataSet.sp_ip_detaljiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.sp_ip_detaljiRowDeleted != null)
                {
                    sp_ip_detaljiDataSet.sp_ip_detaljiRowChangeEventHandler handler = this.sp_ip_detaljiRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new sp_ip_detaljiDataSet.sp_ip_detaljiRowChangeEvent((sp_ip_detaljiDataSet.sp_ip_detaljiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.sp_ip_detaljiRowDeleting != null)
                {
                    sp_ip_detaljiDataSet.sp_ip_detaljiRowChangeEventHandler handler = this.sp_ip_detaljiRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new sp_ip_detaljiDataSet.sp_ip_detaljiRowChangeEvent((sp_ip_detaljiDataSet.sp_ip_detaljiRow) e.Row, e.Action));
                    }
                }
            }

            public void Removesp_ip_detaljiRow(sp_ip_detaljiDataSet.sp_ip_detaljiRow row)
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

            public DataColumn dohodakColumn
            {
                get
                {
                    return this.columndohodak;
                }
            }

            public DataColumn IDIPIDENTColumn
            {
                get
                {
                    return this.columnIDIPIDENT;
                }
            }

            public DataColumn idopcinestanovanjaColumn
            {
                get
                {
                    return this.columnidopcinestanovanja;
                }
            }

            public sp_ip_detaljiDataSet.sp_ip_detaljiRow this[int index]
            {
                get
                {
                    return (sp_ip_detaljiDataSet.sp_ip_detaljiRow) this.Rows[index];
                }
            }

            public DataColumn JMBGColumn
            {
                get
                {
                    return this.columnJMBG;
                }
            }

            public DataColumn MJESECISPLATEColumn
            {
                get
                {
                    return this.columnMJESECISPLATE;
                }
            }

            public DataColumn netoisplataColumn
            {
                get
                {
                    return this.columnnetoisplata;
                }
            }

            public DataColumn netoplacaColumn
            {
                get
                {
                    return this.columnnetoplaca;
                }
            }

            public DataColumn OIBColumn
            {
                get
                {
                    return this.columnOIB;
                }
            }

            public DataColumn POREZKRIZNIColumn
            {
                get
                {
                    return this.columnPOREZKRIZNI;
                }
            }

            public DataColumn poreznaosnovicaColumn
            {
                get
                {
                    return this.columnporeznaosnovica;
                }
            }

            public DataColumn ukupnobrutoColumn
            {
                get
                {
                    return this.columnukupnobruto;
                }
            }

            public DataColumn ukupnodoprinosiColumn
            {
                get
                {
                    return this.columnukupnodoprinosi;
                }
            }

            public DataColumn UKUPNOOOColumn
            {
                get
                {
                    return this.columnUKUPNOOO;
                }
            }

            public DataColumn ukupnoporeziprirezColumn
            {
                get
                {
                    return this.columnukupnoporeziprirez;
                }
            }

            public DataColumn ukupnoporeznopriznateolaksiceColumn
            {
                get
                {
                    return this.columnukupnoporeznopriznateolaksice;
                }
            }
        }

        public class sp_ip_detaljiRow : DataRow
        {
            private sp_ip_detaljiDataSet.sp_ip_detaljiDataTable tablesp_ip_detalji;

            internal sp_ip_detaljiRow(DataRowBuilder rb) : base(rb)
            {
                this.tablesp_ip_detalji = (sp_ip_detaljiDataSet.sp_ip_detaljiDataTable) this.Table;
            }

            public bool IsdohodakNull()
            {
                return this.IsNull(this.tablesp_ip_detalji.dohodakColumn);
            }

            public bool IsIDIPIDENTNull()
            {
                return this.IsNull(this.tablesp_ip_detalji.IDIPIDENTColumn);
            }

            public bool IsidopcinestanovanjaNull()
            {
                return this.IsNull(this.tablesp_ip_detalji.idopcinestanovanjaColumn);
            }

            public bool IsJMBGNull()
            {
                return this.IsNull(this.tablesp_ip_detalji.JMBGColumn);
            }

            public bool IsMJESECISPLATENull()
            {
                return this.IsNull(this.tablesp_ip_detalji.MJESECISPLATEColumn);
            }

            public bool IsnetoisplataNull()
            {
                return this.IsNull(this.tablesp_ip_detalji.netoisplataColumn);
            }

            public bool IsnetoplacaNull()
            {
                return this.IsNull(this.tablesp_ip_detalji.netoplacaColumn);
            }

            public bool IsOIBNull()
            {
                return this.IsNull(this.tablesp_ip_detalji.OIBColumn);
            }

            public bool IsPOREZKRIZNINull()
            {
                return this.IsNull(this.tablesp_ip_detalji.POREZKRIZNIColumn);
            }

            public bool IsporeznaosnovicaNull()
            {
                return this.IsNull(this.tablesp_ip_detalji.poreznaosnovicaColumn);
            }

            public bool IsukupnobrutoNull()
            {
                return this.IsNull(this.tablesp_ip_detalji.ukupnobrutoColumn);
            }

            public bool IsukupnodoprinosiNull()
            {
                return this.IsNull(this.tablesp_ip_detalji.ukupnodoprinosiColumn);
            }

            public bool IsUKUPNOOONull()
            {
                return this.IsNull(this.tablesp_ip_detalji.UKUPNOOOColumn);
            }

            public bool IsukupnoporeziprirezNull()
            {
                return this.IsNull(this.tablesp_ip_detalji.ukupnoporeziprirezColumn);
            }

            public bool IsukupnoporeznopriznateolaksiceNull()
            {
                return this.IsNull(this.tablesp_ip_detalji.ukupnoporeznopriznateolaksiceColumn);
            }

            public void SetdohodakNull()
            {
                this[this.tablesp_ip_detalji.dohodakColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDIPIDENTNull()
            {
                this[this.tablesp_ip_detalji.IDIPIDENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetidopcinestanovanjaNull()
            {
                this[this.tablesp_ip_detalji.idopcinestanovanjaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGNull()
            {
                this[this.tablesp_ip_detalji.JMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECISPLATENull()
            {
                this[this.tablesp_ip_detalji.MJESECISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoisplataNull()
            {
                this[this.tablesp_ip_detalji.netoisplataColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoplacaNull()
            {
                this[this.tablesp_ip_detalji.netoplacaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOIBNull()
            {
                this[this.tablesp_ip_detalji.OIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZKRIZNINull()
            {
                this[this.tablesp_ip_detalji.POREZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetporeznaosnovicaNull()
            {
                this[this.tablesp_ip_detalji.poreznaosnovicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnobrutoNull()
            {
                this[this.tablesp_ip_detalji.ukupnobrutoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnodoprinosiNull()
            {
                this[this.tablesp_ip_detalji.ukupnodoprinosiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOOONull()
            {
                this[this.tablesp_ip_detalji.UKUPNOOOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnoporeziprirezNull()
            {
                this[this.tablesp_ip_detalji.ukupnoporeziprirezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnoporeznopriznateolaksiceNull()
            {
                this[this.tablesp_ip_detalji.ukupnoporeznopriznateolaksiceColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal dohodak
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_ip_detalji.dohodakColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_ip_detalji.dohodakColumn] = value;
                }
            }

            public int IDIPIDENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablesp_ip_detalji.IDIPIDENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_ip_detalji.IDIPIDENTColumn] = value;
                }
            }

            public string idopcinestanovanja
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_ip_detalji.idopcinestanovanjaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_ip_detalji.idopcinestanovanjaColumn] = value;
                }
            }

            public string JMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_ip_detalji.JMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_ip_detalji.JMBGColumn] = value;
                }
            }

            public string MJESECISPLATE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_ip_detalji.MJESECISPLATEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_ip_detalji.MJESECISPLATEColumn] = value;
                }
            }

            public decimal netoisplata
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_ip_detalji.netoisplataColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_ip_detalji.netoisplataColumn] = value;
                }
            }

            public decimal netoplaca
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_ip_detalji.netoplacaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_ip_detalji.netoplacaColumn] = value;
                }
            }

            public string OIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_ip_detalji.OIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_ip_detalji.OIBColumn] = value;
                }
            }

            public decimal POREZKRIZNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_ip_detalji.POREZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_ip_detalji.POREZKRIZNIColumn] = value;
                }
            }

            public decimal poreznaosnovica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_ip_detalji.poreznaosnovicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_ip_detalji.poreznaosnovicaColumn] = value;
                }
            }

            public decimal ukupnobruto
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_ip_detalji.ukupnobrutoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_ip_detalji.ukupnobrutoColumn] = value;
                }
            }

            public decimal ukupnodoprinosi
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_ip_detalji.ukupnodoprinosiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_ip_detalji.ukupnodoprinosiColumn] = value;
                }
            }

            public decimal UKUPNOOO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_ip_detalji.UKUPNOOOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_ip_detalji.UKUPNOOOColumn] = value;
                }
            }

            public decimal ukupnoporeziprirez
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_ip_detalji.ukupnoporeziprirezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_ip_detalji.ukupnoporeziprirezColumn] = value;
                }
            }

            public decimal ukupnoporeznopriznateolaksice
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_ip_detalji.ukupnoporeznopriznateolaksiceColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_ip_detalji.ukupnoporeznopriznateolaksiceColumn] = value;
                }
            }
        }

        public class sp_ip_detaljiRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private sp_ip_detaljiDataSet.sp_ip_detaljiRow eventRow;

            public sp_ip_detaljiRowChangeEvent(sp_ip_detaljiDataSet.sp_ip_detaljiRow row, DataRowAction action)
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

            public sp_ip_detaljiDataSet.sp_ip_detaljiRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void sp_ip_detaljiRowChangeEventHandler(object sender, sp_ip_detaljiDataSet.sp_ip_detaljiRowChangeEvent e);
    }
}

