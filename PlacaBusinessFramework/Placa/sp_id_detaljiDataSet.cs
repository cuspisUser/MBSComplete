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
    public class sp_id_detaljiDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private sp_id_detaljiDataTable tablesp_id_detalji;

        public sp_id_detaljiDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected sp_id_detaljiDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["sp_id_detalji"] != null)
                    {
                        this.Tables.Add(new sp_id_detaljiDataTable(dataSet.Tables["sp_id_detalji"]));
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
            sp_id_detaljiDataSet set = (sp_id_detaljiDataSet) base.Clone();
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
            sp_id_detaljiDataSet set = new sp_id_detaljiDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "sp_id_detaljiDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2026");
            this.ExtendedProperties.Add("DataSetName", "sp_id_detaljiDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Isp_id_detaljiDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "sp_id_detalji");
            this.ExtendedProperties.Add("ObjectDescription", "sp_id_detalji");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_ID_REDOVI");
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
            this.DataSetName = "sp_id_detaljiDataSet";
            this.Namespace = "http://www.tempuri.org/sp_id_detalji";
            this.tablesp_id_detalji = new sp_id_detaljiDataTable();
            this.Tables.Add(this.tablesp_id_detalji);
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
            this.tablesp_id_detalji = (sp_id_detaljiDataTable) this.Tables["sp_id_detalji"];
            if (initTable && (this.tablesp_id_detalji != null))
            {
                this.tablesp_id_detalji.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["sp_id_detalji"] != null)
                {
                    this.Tables.Add(new sp_id_detaljiDataTable(dataSet.Tables["sp_id_detalji"]));
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

        private bool ShouldSerializesp_id_detalji()
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
        public sp_id_detaljiDataTable sp_id_detalji
        {
            get
            {
                return this.tablesp_id_detalji;
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
        public class sp_id_detaljiDataTable : DataTable, IEnumerable
        {
            private DataColumn columnididobrasca;
            private DataColumn columnIDOPCINE;
            private DataColumn columnNAZIVOPCINE;
            private DataColumn columnobracunaniporez;
            private DataColumn columnobracunaniprirez;
            private DataColumn columnobracunanoukupno;
            private DataColumn columnREDNIBROJ;

            public event sp_id_detaljiDataSet.sp_id_detaljiRowChangeEventHandler sp_id_detaljiRowChanged;

            public event sp_id_detaljiDataSet.sp_id_detaljiRowChangeEventHandler sp_id_detaljiRowChanging;

            public event sp_id_detaljiDataSet.sp_id_detaljiRowChangeEventHandler sp_id_detaljiRowDeleted;

            public event sp_id_detaljiDataSet.sp_id_detaljiRowChangeEventHandler sp_id_detaljiRowDeleting;

            public sp_id_detaljiDataTable()
            {
                this.TableName = "sp_id_detalji";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal sp_id_detaljiDataTable(DataTable table) : base(table.TableName)
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

            protected sp_id_detaljiDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void Addsp_id_detaljiRow(sp_id_detaljiDataSet.sp_id_detaljiRow row)
            {
                this.Rows.Add(row);
            }

            public sp_id_detaljiDataSet.sp_id_detaljiRow Addsp_id_detaljiRow(int ididobrasca, string rEDNIBROJ, string iDOPCINE, string nAZIVOPCINE, decimal obracunaniporez, decimal obracunaniprirez, decimal obracunanoukupno)
            {
                sp_id_detaljiDataSet.sp_id_detaljiRow row = (sp_id_detaljiDataSet.sp_id_detaljiRow) this.NewRow();
                row.ItemArray = new object[] { ididobrasca, rEDNIBROJ, iDOPCINE, nAZIVOPCINE, obracunaniporez, obracunaniprirez, obracunanoukupno };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                sp_id_detaljiDataSet.sp_id_detaljiDataTable table = (sp_id_detaljiDataSet.sp_id_detaljiDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(sp_id_detaljiDataSet.sp_id_detaljiRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                sp_id_detaljiDataSet set = new sp_id_detaljiDataSet();
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
                this.columnididobrasca = new DataColumn("ididobrasca", typeof(int), "", MappingType.Element);
                this.columnididobrasca.Caption = "ididobrasca";
                this.columnididobrasca.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnididobrasca.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnididobrasca.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnididobrasca.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnididobrasca.ExtendedProperties.Add("IsKey", "false");
                this.columnididobrasca.ExtendedProperties.Add("ReadOnly", "true");
                this.columnididobrasca.ExtendedProperties.Add("DeklaritType", "int");
                this.columnididobrasca.ExtendedProperties.Add("Description", "ididobrasca");
                this.columnididobrasca.ExtendedProperties.Add("Length", "5");
                this.columnididobrasca.ExtendedProperties.Add("Decimals", "0");
                this.columnididobrasca.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnididobrasca.ExtendedProperties.Add("IsInReader", "true");
                this.columnididobrasca.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnididobrasca.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnididobrasca.ExtendedProperties.Add("Deklarit.InternalName", "ididobrasca");
                this.Columns.Add(this.columnididobrasca);
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
                this.columnIDOPCINE = new DataColumn("IDOPCINE", typeof(string), "", MappingType.Element);
                this.columnIDOPCINE.Caption = "Šifra općine";
                this.columnIDOPCINE.MaxLength = 4;
                this.columnIDOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOPCINE.ExtendedProperties.Add("Description", "Šifra općine");
                this.columnIDOPCINE.ExtendedProperties.Add("Length", "4");
                this.columnIDOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "IDOPCINE");
                this.Columns.Add(this.columnIDOPCINE);
                this.columnNAZIVOPCINE = new DataColumn("NAZIVOPCINE", typeof(string), "", MappingType.Element);
                this.columnNAZIVOPCINE.Caption = "Naziv općine";
                this.columnNAZIVOPCINE.MaxLength = 50;
                this.columnNAZIVOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Description", "Naziv općine");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOPCINE");
                this.Columns.Add(this.columnNAZIVOPCINE);
                this.columnobracunaniporez = new DataColumn("obracunaniporez", typeof(decimal), "", MappingType.Element);
                this.columnobracunaniporez.Caption = "obracunaniporez";
                this.columnobracunaniporez.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnobracunaniporez.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnobracunaniporez.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnobracunaniporez.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnobracunaniporez.ExtendedProperties.Add("IsKey", "false");
                this.columnobracunaniporez.ExtendedProperties.Add("ReadOnly", "true");
                this.columnobracunaniporez.ExtendedProperties.Add("DeklaritType", "int");
                this.columnobracunaniporez.ExtendedProperties.Add("Description", "obracunaniporez");
                this.columnobracunaniporez.ExtendedProperties.Add("Length", "12");
                this.columnobracunaniporez.ExtendedProperties.Add("Decimals", "2");
                this.columnobracunaniporez.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnobracunaniporez.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnobracunaniporez.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnobracunaniporez.ExtendedProperties.Add("IsInReader", "true");
                this.columnobracunaniporez.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnobracunaniporez.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnobracunaniporez.ExtendedProperties.Add("Deklarit.InternalName", "obracunaniporez");
                this.Columns.Add(this.columnobracunaniporez);
                this.columnobracunaniprirez = new DataColumn("obracunaniprirez", typeof(decimal), "", MappingType.Element);
                this.columnobracunaniprirez.Caption = "obracunaniprirez";
                this.columnobracunaniprirez.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnobracunaniprirez.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnobracunaniprirez.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnobracunaniprirez.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnobracunaniprirez.ExtendedProperties.Add("IsKey", "false");
                this.columnobracunaniprirez.ExtendedProperties.Add("ReadOnly", "true");
                this.columnobracunaniprirez.ExtendedProperties.Add("DeklaritType", "int");
                this.columnobracunaniprirez.ExtendedProperties.Add("Description", "obracunaniprirez");
                this.columnobracunaniprirez.ExtendedProperties.Add("Length", "12");
                this.columnobracunaniprirez.ExtendedProperties.Add("Decimals", "2");
                this.columnobracunaniprirez.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnobracunaniprirez.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnobracunaniprirez.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnobracunaniprirez.ExtendedProperties.Add("IsInReader", "true");
                this.columnobracunaniprirez.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnobracunaniprirez.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnobracunaniprirez.ExtendedProperties.Add("Deklarit.InternalName", "obracunaniprirez");
                this.Columns.Add(this.columnobracunaniprirez);
                this.columnobracunanoukupno = new DataColumn("obracunanoukupno", typeof(decimal), "", MappingType.Element);
                this.columnobracunanoukupno.Caption = "obracunanoukupno";
                this.columnobracunanoukupno.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnobracunanoukupno.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnobracunanoukupno.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnobracunanoukupno.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnobracunanoukupno.ExtendedProperties.Add("IsKey", "false");
                this.columnobracunanoukupno.ExtendedProperties.Add("ReadOnly", "true");
                this.columnobracunanoukupno.ExtendedProperties.Add("DeklaritType", "int");
                this.columnobracunanoukupno.ExtendedProperties.Add("Description", "obracunanoukupno");
                this.columnobracunanoukupno.ExtendedProperties.Add("Length", "12");
                this.columnobracunanoukupno.ExtendedProperties.Add("Decimals", "2");
                this.columnobracunanoukupno.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnobracunanoukupno.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnobracunanoukupno.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnobracunanoukupno.ExtendedProperties.Add("IsInReader", "true");
                this.columnobracunanoukupno.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnobracunanoukupno.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnobracunanoukupno.ExtendedProperties.Add("Deklarit.InternalName", "obracunanoukupno");
                this.Columns.Add(this.columnobracunanoukupno);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "sp_id_detalji");
                this.ExtendedProperties.Add("Description", "SP_ID_DETALJI");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnididobrasca = this.Columns["ididobrasca"];
                this.columnREDNIBROJ = this.Columns["REDNIBROJ"];
                this.columnIDOPCINE = this.Columns["IDOPCINE"];
                this.columnNAZIVOPCINE = this.Columns["NAZIVOPCINE"];
                this.columnobracunaniporez = this.Columns["obracunaniporez"];
                this.columnobracunaniprirez = this.Columns["obracunaniprirez"];
                this.columnobracunanoukupno = this.Columns["obracunanoukupno"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new sp_id_detaljiDataSet.sp_id_detaljiRow(builder);
            }

            public sp_id_detaljiDataSet.sp_id_detaljiRow Newsp_id_detaljiRow()
            {
                return (sp_id_detaljiDataSet.sp_id_detaljiRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.sp_id_detaljiRowChanged != null)
                {
                    sp_id_detaljiDataSet.sp_id_detaljiRowChangeEventHandler handler = this.sp_id_detaljiRowChanged;
                    if (handler != null)
                    {
                        handler(this, new sp_id_detaljiDataSet.sp_id_detaljiRowChangeEvent((sp_id_detaljiDataSet.sp_id_detaljiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.sp_id_detaljiRowChanging != null)
                {
                    sp_id_detaljiDataSet.sp_id_detaljiRowChangeEventHandler handler = this.sp_id_detaljiRowChanging;
                    if (handler != null)
                    {
                        handler(this, new sp_id_detaljiDataSet.sp_id_detaljiRowChangeEvent((sp_id_detaljiDataSet.sp_id_detaljiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.sp_id_detaljiRowDeleted != null)
                {
                    sp_id_detaljiDataSet.sp_id_detaljiRowChangeEventHandler handler = this.sp_id_detaljiRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new sp_id_detaljiDataSet.sp_id_detaljiRowChangeEvent((sp_id_detaljiDataSet.sp_id_detaljiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.sp_id_detaljiRowDeleting != null)
                {
                    sp_id_detaljiDataSet.sp_id_detaljiRowChangeEventHandler handler = this.sp_id_detaljiRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new sp_id_detaljiDataSet.sp_id_detaljiRowChangeEvent((sp_id_detaljiDataSet.sp_id_detaljiRow) e.Row, e.Action));
                    }
                }
            }

            public void Removesp_id_detaljiRow(sp_id_detaljiDataSet.sp_id_detaljiRow row)
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

            public DataColumn ididobrascaColumn
            {
                get
                {
                    return this.columnididobrasca;
                }
            }

            public DataColumn IDOPCINEColumn
            {
                get
                {
                    return this.columnIDOPCINE;
                }
            }

            public sp_id_detaljiDataSet.sp_id_detaljiRow this[int index]
            {
                get
                {
                    return (sp_id_detaljiDataSet.sp_id_detaljiRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVOPCINEColumn
            {
                get
                {
                    return this.columnNAZIVOPCINE;
                }
            }

            public DataColumn obracunaniporezColumn
            {
                get
                {
                    return this.columnobracunaniporez;
                }
            }

            public DataColumn obracunaniprirezColumn
            {
                get
                {
                    return this.columnobracunaniprirez;
                }
            }

            public DataColumn obracunanoukupnoColumn
            {
                get
                {
                    return this.columnobracunanoukupno;
                }
            }

            public DataColumn REDNIBROJColumn
            {
                get
                {
                    return this.columnREDNIBROJ;
                }
            }
        }

        public class sp_id_detaljiRow : DataRow
        {
            private sp_id_detaljiDataSet.sp_id_detaljiDataTable tablesp_id_detalji;

            internal sp_id_detaljiRow(DataRowBuilder rb) : base(rb)
            {
                this.tablesp_id_detalji = (sp_id_detaljiDataSet.sp_id_detaljiDataTable) this.Table;
            }

            public bool IsididobrascaNull()
            {
                return this.IsNull(this.tablesp_id_detalji.ididobrascaColumn);
            }

            public bool IsIDOPCINENull()
            {
                return this.IsNull(this.tablesp_id_detalji.IDOPCINEColumn);
            }

            public bool IsNAZIVOPCINENull()
            {
                return this.IsNull(this.tablesp_id_detalji.NAZIVOPCINEColumn);
            }

            public bool IsobracunaniporezNull()
            {
                return this.IsNull(this.tablesp_id_detalji.obracunaniporezColumn);
            }

            public bool IsobracunaniprirezNull()
            {
                return this.IsNull(this.tablesp_id_detalji.obracunaniprirezColumn);
            }

            public bool IsobracunanoukupnoNull()
            {
                return this.IsNull(this.tablesp_id_detalji.obracunanoukupnoColumn);
            }

            public bool IsREDNIBROJNull()
            {
                return this.IsNull(this.tablesp_id_detalji.REDNIBROJColumn);
            }

            public void SetididobrascaNull()
            {
                this[this.tablesp_id_detalji.ididobrascaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDOPCINENull()
            {
                this[this.tablesp_id_detalji.IDOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOPCINENull()
            {
                this[this.tablesp_id_detalji.NAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetobracunaniporezNull()
            {
                this[this.tablesp_id_detalji.obracunaniporezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetobracunaniprirezNull()
            {
                this[this.tablesp_id_detalji.obracunaniprirezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetobracunanoukupnoNull()
            {
                this[this.tablesp_id_detalji.obracunanoukupnoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDNIBROJNull()
            {
                this[this.tablesp_id_detalji.REDNIBROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int ididobrasca
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablesp_id_detalji.ididobrascaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ididobrasca because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_detalji.ididobrascaColumn] = value;
                }
            }

            public string IDOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_id_detalji.IDOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDOPCINE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_id_detalji.IDOPCINEColumn] = value;
                }
            }

            public string NAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_id_detalji.NAZIVOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVOPCINE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_id_detalji.NAZIVOPCINEColumn] = value;
                }
            }

            public decimal obracunaniporez
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_detalji.obracunaniporezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value obracunaniporez because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_detalji.obracunaniporezColumn] = value;
                }
            }

            public decimal obracunaniprirez
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_detalji.obracunaniprirezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value obracunaniprirez because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_detalji.obracunaniprirezColumn] = value;
                }
            }

            public decimal obracunanoukupno
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_detalji.obracunanoukupnoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value obracunanoukupno because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_detalji.obracunanoukupnoColumn] = value;
                }
            }

            public string REDNIBROJ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_id_detalji.REDNIBROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value REDNIBROJ because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_id_detalji.REDNIBROJColumn] = value;
                }
            }
        }

        public class sp_id_detaljiRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private sp_id_detaljiDataSet.sp_id_detaljiRow eventRow;

            public sp_id_detaljiRowChangeEvent(sp_id_detaljiDataSet.sp_id_detaljiRow row, DataRowAction action)
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

            public sp_id_detaljiDataSet.sp_id_detaljiRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void sp_id_detaljiRowChangeEventHandler(object sender, sp_id_detaljiDataSet.sp_id_detaljiRowChangeEvent e);
    }
}

