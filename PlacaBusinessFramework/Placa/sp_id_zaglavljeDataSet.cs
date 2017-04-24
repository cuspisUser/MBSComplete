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
    public class sp_id_zaglavljeDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private sp_id_zaglavljeDataTable tablesp_id_zaglavlje;

        public sp_id_zaglavljeDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected sp_id_zaglavljeDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["sp_id_zaglavlje"] != null)
                    {
                        this.Tables.Add(new sp_id_zaglavljeDataTable(dataSet.Tables["sp_id_zaglavlje"]));
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
            sp_id_zaglavljeDataSet set = (sp_id_zaglavljeDataSet) base.Clone();
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
            sp_id_zaglavljeDataSet set = new sp_id_zaglavljeDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "sp_id_zaglavljeDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2027");
            this.ExtendedProperties.Add("DataSetName", "sp_id_zaglavljeDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Isp_id_zaglavljeDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "sp_id_zaglavlje");
            this.ExtendedProperties.Add("ObjectDescription", "sp_id_zaglavlje");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_ID");
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
            this.DataSetName = "sp_id_zaglavljeDataSet";
            this.Namespace = "http://www.tempuri.org/sp_id_zaglavlje";
            this.tablesp_id_zaglavlje = new sp_id_zaglavljeDataTable();
            this.Tables.Add(this.tablesp_id_zaglavlje);
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
            this.tablesp_id_zaglavlje = (sp_id_zaglavljeDataTable) this.Tables["sp_id_zaglavlje"];
            if (initTable && (this.tablesp_id_zaglavlje != null))
            {
                this.tablesp_id_zaglavlje.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["sp_id_zaglavlje"] != null)
                {
                    this.Tables.Add(new sp_id_zaglavljeDataTable(dataSet.Tables["sp_id_zaglavlje"]));
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

        private bool ShouldSerializesp_id_zaglavlje()
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
        public sp_id_zaglavljeDataTable sp_id_zaglavlje
        {
            get
            {
                return this.tablesp_id_zaglavlje;
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
        public class sp_id_zaglavljeDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDATUMSASTAVLJANJA;
            private DataColumn columnidenTIFIKATOR;
            private DataColumn columnididobrasca;
            private DataColumn columnmaticnibroj;
            private DataColumn columnnazivfirme;
            private DataColumn columnpunaadresa;
            private DataColumn columnREDAK_II_1;
            private DataColumn columnREDAK_II_2;
            private DataColumn columnREDAK_II_2_1;
            private DataColumn columnREDAK_II_2_1_1;
            private DataColumn columnREDAK_II_2_1_2;
            private DataColumn columnREDAK_II_2_1_3;
            private DataColumn columnREDAK_II_2_2;
            private DataColumn columnREDAK_II_2_2_1;
            private DataColumn columnREDAK_II_2_2_2;
            private DataColumn columnREDAK_II_2_2_3;
            private DataColumn columnREDAK_II_3;
            private DataColumn columnREDAK_II_4;
            private DataColumn columnREDAK_II_5;
            private DataColumn columnREDAK_II_6;
            private DataColumn columnREDAK_II_6_1;
            private DataColumn columnREDAK_II_6_2;
            private DataColumn columnREDAK_II_7;
            private DataColumn columnREDAK_II_8;
            private DataColumn columnREDAK_III_1_1;
            private DataColumn columnREDAK_III_1_2;
            private DataColumn columnREDAK_III_2_1;
            private DataColumn columnREDAK_III_2_2;
            private DataColumn columnREDAK_III_3_1;
            private DataColumn columnREDAK_III_3_2;
            private DataColumn columnREDAK_III_3_3;
            private DataColumn columnREDAK_III_4_1;
            private DataColumn columnREDAK_III_4_2;
            private DataColumn columnREDAK_III_5;

            public event sp_id_zaglavljeDataSet.sp_id_zaglavljeRowChangeEventHandler sp_id_zaglavljeRowChanged;

            public event sp_id_zaglavljeDataSet.sp_id_zaglavljeRowChangeEventHandler sp_id_zaglavljeRowChanging;

            public event sp_id_zaglavljeDataSet.sp_id_zaglavljeRowChangeEventHandler sp_id_zaglavljeRowDeleted;

            public event sp_id_zaglavljeDataSet.sp_id_zaglavljeRowChangeEventHandler sp_id_zaglavljeRowDeleting;

            public sp_id_zaglavljeDataTable()
            {
                this.TableName = "sp_id_zaglavlje";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal sp_id_zaglavljeDataTable(DataTable table) : base(table.TableName)
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

            protected sp_id_zaglavljeDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void Addsp_id_zaglavljeRow(sp_id_zaglavljeDataSet.sp_id_zaglavljeRow row)
            {
                this.Rows.Add(row);
            }

            public sp_id_zaglavljeDataSet.sp_id_zaglavljeRow Addsp_id_zaglavljeRow(int ididobrasca, string nazivfirme, string punaadresa, string maticnibroj, string idenTIFIKATOR, decimal rEDAK_II_1, decimal rEDAK_II_2, decimal rEDAK_II_2_1, decimal rEDAK_II_2_1_1, decimal rEDAK_II_2_1_2, decimal rEDAK_II_2_1_3, decimal rEDAK_II_2_2, decimal rEDAK_II_2_2_1, decimal rEDAK_II_2_2_2, decimal rEDAK_II_2_2_3, decimal rEDAK_II_3, decimal rEDAK_II_4, decimal rEDAK_II_5, decimal rEDAK_II_6, decimal rEDAK_II_6_1, decimal rEDAK_II_6_2, decimal rEDAK_II_7, decimal rEDAK_II_8, decimal rEDAK_III_1_1, decimal rEDAK_III_1_2, decimal rEDAK_III_2_1, decimal rEDAK_III_2_2, decimal rEDAK_III_3_1, decimal rEDAK_III_3_2, decimal rEDAK_III_3_3, decimal rEDAK_III_4_1, decimal rEDAK_III_4_2, decimal rEDAK_III_5, DateTime dATUMSASTAVLJANJA)
            {
                sp_id_zaglavljeDataSet.sp_id_zaglavljeRow row = (sp_id_zaglavljeDataSet.sp_id_zaglavljeRow) this.NewRow();
                row.ItemArray = new object[] { 
                    ididobrasca, nazivfirme, punaadresa, maticnibroj, idenTIFIKATOR, rEDAK_II_1, rEDAK_II_2, rEDAK_II_2_1, rEDAK_II_2_1_1, rEDAK_II_2_1_2, rEDAK_II_2_1_3, rEDAK_II_2_2, rEDAK_II_2_2_1, rEDAK_II_2_2_2, rEDAK_II_2_2_3, rEDAK_II_3, 
                    rEDAK_II_4, rEDAK_II_5, rEDAK_II_6, rEDAK_II_6_1, rEDAK_II_6_2, rEDAK_II_7, rEDAK_II_8, rEDAK_III_1_1, rEDAK_III_1_2, rEDAK_III_2_1, rEDAK_III_2_2, rEDAK_III_3_1, rEDAK_III_3_2, rEDAK_III_3_3, rEDAK_III_4_1, rEDAK_III_4_2, 
                    rEDAK_III_5, dATUMSASTAVLJANJA
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                sp_id_zaglavljeDataSet.sp_id_zaglavljeDataTable table = (sp_id_zaglavljeDataSet.sp_id_zaglavljeDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(sp_id_zaglavljeDataSet.sp_id_zaglavljeRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                sp_id_zaglavljeDataSet set = new sp_id_zaglavljeDataSet();
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
                this.columnnazivfirme = new DataColumn("nazivfirme", typeof(string), "", MappingType.Element);
                this.columnnazivfirme.Caption = "nazivfirme";
                this.columnnazivfirme.MaxLength = 150;
                this.columnnazivfirme.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnazivfirme.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnazivfirme.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnazivfirme.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnazivfirme.ExtendedProperties.Add("IsKey", "false");
                this.columnnazivfirme.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnazivfirme.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnnazivfirme.ExtendedProperties.Add("Description", "nazivfirme");
                this.columnnazivfirme.ExtendedProperties.Add("Length", "150");
                this.columnnazivfirme.ExtendedProperties.Add("Decimals", "0");
                this.columnnazivfirme.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnazivfirme.ExtendedProperties.Add("IsInReader", "true");
                this.columnnazivfirme.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnazivfirme.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnazivfirme.ExtendedProperties.Add("Deklarit.InternalName", "nazivfirme");
                this.Columns.Add(this.columnnazivfirme);
                this.columnpunaadresa = new DataColumn("punaadresa", typeof(string), "", MappingType.Element);
                this.columnpunaadresa.Caption = "punaadresa";
                this.columnpunaadresa.MaxLength = 150;
                this.columnpunaadresa.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnpunaadresa.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnpunaadresa.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnpunaadresa.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnpunaadresa.ExtendedProperties.Add("IsKey", "false");
                this.columnpunaadresa.ExtendedProperties.Add("ReadOnly", "true");
                this.columnpunaadresa.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnpunaadresa.ExtendedProperties.Add("Description", "punaadresa");
                this.columnpunaadresa.ExtendedProperties.Add("Length", "150");
                this.columnpunaadresa.ExtendedProperties.Add("Decimals", "0");
                this.columnpunaadresa.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnpunaadresa.ExtendedProperties.Add("IsInReader", "true");
                this.columnpunaadresa.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnpunaadresa.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnpunaadresa.ExtendedProperties.Add("Deklarit.InternalName", "punaadresa");
                this.Columns.Add(this.columnpunaadresa);
                this.columnmaticnibroj = new DataColumn("maticnibroj", typeof(string), "", MappingType.Element);
                this.columnmaticnibroj.Caption = "maticnibroj";
                this.columnmaticnibroj.MaxLength = 13;
                this.columnmaticnibroj.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmaticnibroj.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmaticnibroj.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmaticnibroj.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmaticnibroj.ExtendedProperties.Add("IsKey", "false");
                this.columnmaticnibroj.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmaticnibroj.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnmaticnibroj.ExtendedProperties.Add("Description", "maticnibroj");
                this.columnmaticnibroj.ExtendedProperties.Add("Length", "13");
                this.columnmaticnibroj.ExtendedProperties.Add("Decimals", "0");
                this.columnmaticnibroj.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmaticnibroj.ExtendedProperties.Add("IsInReader", "true");
                this.columnmaticnibroj.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmaticnibroj.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmaticnibroj.ExtendedProperties.Add("Deklarit.InternalName", "maticnibroj");
                this.Columns.Add(this.columnmaticnibroj);
                this.columnidenTIFIKATOR = new DataColumn("idenTIFIKATOR", typeof(string), "", MappingType.Element);
                this.columnidenTIFIKATOR.Caption = "iden TIFIKATOR";
                this.columnidenTIFIKATOR.MaxLength = 2;
                this.columnidenTIFIKATOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnidenTIFIKATOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnidenTIFIKATOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnidenTIFIKATOR.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnidenTIFIKATOR.ExtendedProperties.Add("IsKey", "false");
                this.columnidenTIFIKATOR.ExtendedProperties.Add("ReadOnly", "true");
                this.columnidenTIFIKATOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnidenTIFIKATOR.ExtendedProperties.Add("Description", "iden TIFIKATOR");
                this.columnidenTIFIKATOR.ExtendedProperties.Add("Length", "2");
                this.columnidenTIFIKATOR.ExtendedProperties.Add("Decimals", "0");
                this.columnidenTIFIKATOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnidenTIFIKATOR.ExtendedProperties.Add("IsInReader", "true");
                this.columnidenTIFIKATOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnidenTIFIKATOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnidenTIFIKATOR.ExtendedProperties.Add("Deklarit.InternalName", "idenTIFIKATOR");
                this.Columns.Add(this.columnidenTIFIKATOR);
                this.columnREDAK_II_1 = new DataColumn("REDAK_II_1", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_1.Caption = "REDAK  I I 1";
                this.columnREDAK_II_1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_1.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_1.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_1.ExtendedProperties.Add("Description", "REDAK  I I 1");
                this.columnREDAK_II_1.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_1.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_1.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_1.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_1.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_1.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_1");
                this.Columns.Add(this.columnREDAK_II_1);
                this.columnREDAK_II_2 = new DataColumn("REDAK_II_2", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_2.Caption = "REDAK  I I 2";
                this.columnREDAK_II_2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_2.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_2.ExtendedProperties.Add("Description", "REDAK  I I 2");
                this.columnREDAK_II_2.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_2.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_2.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_2.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_2.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_2");
                this.Columns.Add(this.columnREDAK_II_2);
                this.columnREDAK_II_2_1 = new DataColumn("REDAK_II_2_1", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_2_1.Caption = "REDAK  I I 2 1";
                this.columnREDAK_II_2_1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_2_1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("Description", "REDAK  I I 2 1");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_2_1.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_2_1");
                this.Columns.Add(this.columnREDAK_II_2_1);
                this.columnREDAK_II_2_1_1 = new DataColumn("REDAK_II_2_1_1", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_2_1_1.Caption = "REDAK  I I 2 1 1";
                this.columnREDAK_II_2_1_1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("Description", "REDAK  I I 2 1 1");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_2_1_1.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_2_1_1");
                this.Columns.Add(this.columnREDAK_II_2_1_1);
                this.columnREDAK_II_2_1_2 = new DataColumn("REDAK_II_2_1_2", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_2_1_2.Caption = "REDAK  I I 2 1 2";
                this.columnREDAK_II_2_1_2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("Description", "REDAK  I I 2 1 2");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_2_1_2.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_2_1_2");
                this.Columns.Add(this.columnREDAK_II_2_1_2);
                this.columnREDAK_II_2_1_3 = new DataColumn("REDAK_II_2_1_3", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_2_1_3.Caption = "REDAK  I I 2 1 3";
                this.columnREDAK_II_2_1_3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("Description", "REDAK  I I 2 1 3");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_2_1_3.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_2_1_3");
                this.Columns.Add(this.columnREDAK_II_2_1_3);
                this.columnREDAK_II_2_2 = new DataColumn("REDAK_II_2_2", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_2_2.Caption = "REDAK  I I 2 2";
                this.columnREDAK_II_2_2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_2_2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("Description", "REDAK  I I 2 2");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_2_2.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_2_2");
                this.Columns.Add(this.columnREDAK_II_2_2);
                this.columnREDAK_II_2_2_1 = new DataColumn("REDAK_II_2_2_1", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_2_2_1.Caption = "REDAK  I I 2 2 1";
                this.columnREDAK_II_2_2_1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("Description", "REDAK  I I 2 2 1");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_2_2_1.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_2_2_1");
                this.Columns.Add(this.columnREDAK_II_2_2_1);
                this.columnREDAK_II_2_2_2 = new DataColumn("REDAK_II_2_2_2", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_2_2_2.Caption = "REDAK  I I 2 2 2";
                this.columnREDAK_II_2_2_2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("Description", "REDAK  I I 2 2 2");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_2_2_2.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_2_2_2");
                this.Columns.Add(this.columnREDAK_II_2_2_2);
                this.columnREDAK_II_2_2_3 = new DataColumn("REDAK_II_2_2_3", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_2_2_3.Caption = "REDAK  I I 2 2 3";
                this.columnREDAK_II_2_2_3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("Description", "REDAK  I I 2 2 3");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_2_2_3.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_2_2_3");
                this.Columns.Add(this.columnREDAK_II_2_2_3);
                this.columnREDAK_II_3 = new DataColumn("REDAK_II_3", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_3.Caption = "REDAK  I I 3";
                this.columnREDAK_II_3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_3.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_3.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_3.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_3.ExtendedProperties.Add("Description", "REDAK  I I 3");
                this.columnREDAK_II_3.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_3.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_3.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_3.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_3.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_3.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_3");
                this.Columns.Add(this.columnREDAK_II_3);
                this.columnREDAK_II_4 = new DataColumn("REDAK_II_4", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_4.Caption = "REDAK  I I 4";
                this.columnREDAK_II_4.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_4.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_4.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_4.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_4.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_4.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_4.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_4.ExtendedProperties.Add("Description", "REDAK  I I 4");
                this.columnREDAK_II_4.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_4.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_4.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_4.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_4.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_4.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_4.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_4.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_4.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_4");
                this.Columns.Add(this.columnREDAK_II_4);
                this.columnREDAK_II_5 = new DataColumn("REDAK_II_5", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_5.Caption = "REDAK  I I 5";
                this.columnREDAK_II_5.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_5.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_5.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_5.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_5.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_5.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_5.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_5.ExtendedProperties.Add("Description", "REDAK  I I 5");
                this.columnREDAK_II_5.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_5.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_5.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_5.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_5.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_5.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_5.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_5.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_5.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_5");
                this.Columns.Add(this.columnREDAK_II_5);
                this.columnREDAK_II_6 = new DataColumn("REDAK_II_6", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_6.Caption = "REDAK  I I 6";
                this.columnREDAK_II_6.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_6.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_6.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_6.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_6.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_6.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_6.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_6.ExtendedProperties.Add("Description", "REDAK  I I 6");
                this.columnREDAK_II_6.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_6.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_6.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_6.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_6.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_6.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_6.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_6.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_6.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_6");
                this.Columns.Add(this.columnREDAK_II_6);
                this.columnREDAK_II_6_1 = new DataColumn("REDAK_II_6_1", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_6_1.Caption = "REDAK  I I 6 1";
                this.columnREDAK_II_6_1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_6_1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("Description", "REDAK  I I 6 1");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_6_1.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_6_1");
                this.Columns.Add(this.columnREDAK_II_6_1);
                this.columnREDAK_II_6_2 = new DataColumn("REDAK_II_6_2", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_6_2.Caption = "REDAK  I I 6 2";
                this.columnREDAK_II_6_2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_6_2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("Description", "REDAK  I I 6 2");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_6_2.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_6_2");
                this.Columns.Add(this.columnREDAK_II_6_2);
                this.columnREDAK_II_7 = new DataColumn("REDAK_II_7", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_7.Caption = "REDAK  I I 7";
                this.columnREDAK_II_7.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_7.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_7.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_7.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_7.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_7.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_7.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_7.ExtendedProperties.Add("Description", "REDAK  I I 7");
                this.columnREDAK_II_7.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_7.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_7.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_7.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_7.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_7.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_7.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_7.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_7.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_7");
                this.Columns.Add(this.columnREDAK_II_7);
                this.columnREDAK_II_8 = new DataColumn("REDAK_II_8", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_II_8.Caption = "REDAK  I I 8";
                this.columnREDAK_II_8.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_II_8.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_II_8.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_II_8.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_II_8.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_II_8.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_II_8.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_II_8.ExtendedProperties.Add("Description", "REDAK  I I 8");
                this.columnREDAK_II_8.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_II_8.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_II_8.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_II_8.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_II_8.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_II_8.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_II_8.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_II_8.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_II_8.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_II_8");
                this.Columns.Add(this.columnREDAK_II_8);
                this.columnREDAK_III_1_1 = new DataColumn("REDAK_III_1_1", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_III_1_1.Caption = "REDAK  II I 1 1";
                this.columnREDAK_III_1_1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_III_1_1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("Description", "REDAK  II I 1 1");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_III_1_1.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_III_1_1");
                this.Columns.Add(this.columnREDAK_III_1_1);
                this.columnREDAK_III_1_2 = new DataColumn("REDAK_III_1_2", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_III_1_2.Caption = "REDAK  II I 1 2";
                this.columnREDAK_III_1_2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_III_1_2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("Description", "REDAK  II I 1 2");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_III_1_2.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_III_1_2");
                this.Columns.Add(this.columnREDAK_III_1_2);
                this.columnREDAK_III_2_1 = new DataColumn("REDAK_III_2_1", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_III_2_1.Caption = "REDAK  II I 2 1";
                this.columnREDAK_III_2_1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_III_2_1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("Description", "REDAK  II I 2 1");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_III_2_1.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_III_2_1");
                this.Columns.Add(this.columnREDAK_III_2_1);
                this.columnREDAK_III_2_2 = new DataColumn("REDAK_III_2_2", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_III_2_2.Caption = "REDAK  II I 2 2";
                this.columnREDAK_III_2_2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_III_2_2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("Description", "REDAK  II I 2 2");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_III_2_2.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_III_2_2");
                this.Columns.Add(this.columnREDAK_III_2_2);
                this.columnREDAK_III_3_1 = new DataColumn("REDAK_III_3_1", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_III_3_1.Caption = "REDAK  II I 3 1";
                this.columnREDAK_III_3_1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_III_3_1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("Description", "REDAK  II I 3 1");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_III_3_1.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_III_3_1");
                this.Columns.Add(this.columnREDAK_III_3_1);
                this.columnREDAK_III_3_2 = new DataColumn("REDAK_III_3_2", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_III_3_2.Caption = "REDAK  II I 3 2";
                this.columnREDAK_III_3_2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_III_3_2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("Description", "REDAK  II I 3 2");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_III_3_2.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_III_3_2");
                this.Columns.Add(this.columnREDAK_III_3_2);
                this.columnREDAK_III_3_3 = new DataColumn("REDAK_III_3_3", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_III_3_3.Caption = "REDAK  II I 3 3";
                this.columnREDAK_III_3_3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_III_3_3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("Description", "REDAK  II I 3 3");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_III_3_3.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_III_3_3");
                this.Columns.Add(this.columnREDAK_III_3_3);
                this.columnREDAK_III_4_1 = new DataColumn("REDAK_III_4_1", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_III_4_1.Caption = "REDAK  II I 4 1";
                this.columnREDAK_III_4_1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_III_4_1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("Description", "REDAK  II I 4 1");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_III_4_1.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_III_4_1");
                this.Columns.Add(this.columnREDAK_III_4_1);
                this.columnREDAK_III_4_2 = new DataColumn("REDAK_III_4_2", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_III_4_2.Caption = "REDAK  II I 4 2";
                this.columnREDAK_III_4_2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_III_4_2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("Description", "REDAK  II I 4 2");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_III_4_2.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_III_4_2");
                this.Columns.Add(this.columnREDAK_III_4_2);
                this.columnREDAK_III_5 = new DataColumn("REDAK_III_5", typeof(decimal), "", MappingType.Element);
                this.columnREDAK_III_5.Caption = "REDAK  II I 5";
                this.columnREDAK_III_5.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDAK_III_5.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDAK_III_5.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDAK_III_5.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDAK_III_5.ExtendedProperties.Add("IsKey", "false");
                this.columnREDAK_III_5.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDAK_III_5.ExtendedProperties.Add("DeklaritType", "int");
                this.columnREDAK_III_5.ExtendedProperties.Add("Description", "REDAK  II I 5");
                this.columnREDAK_III_5.ExtendedProperties.Add("Length", "12");
                this.columnREDAK_III_5.ExtendedProperties.Add("Decimals", "2");
                this.columnREDAK_III_5.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnREDAK_III_5.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnREDAK_III_5.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDAK_III_5.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDAK_III_5.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDAK_III_5.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDAK_III_5.ExtendedProperties.Add("Deklarit.InternalName", "REDAK_III_5");
                this.Columns.Add(this.columnREDAK_III_5);
                this.columnDATUMSASTAVLJANJA = new DataColumn("DATUMSASTAVLJANJA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMSASTAVLJANJA.Caption = "DATUMSASTAVLJANJA";
                this.columnDATUMSASTAVLJANJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("Description", "DATUMSASTAVLJANJA");
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMSASTAVLJANJA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMSASTAVLJANJA");
                this.Columns.Add(this.columnDATUMSASTAVLJANJA);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "sp_id_zaglavlje");
                this.ExtendedProperties.Add("Description", "SP_ID_ZAGLAVLJE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnididobrasca = this.Columns["ididobrasca"];
                this.columnnazivfirme = this.Columns["nazivfirme"];
                this.columnpunaadresa = this.Columns["punaadresa"];
                this.columnmaticnibroj = this.Columns["maticnibroj"];
                this.columnidenTIFIKATOR = this.Columns["idenTIFIKATOR"];
                this.columnREDAK_II_1 = this.Columns["REDAK_II_1"];
                this.columnREDAK_II_2 = this.Columns["REDAK_II_2"];
                this.columnREDAK_II_2_1 = this.Columns["REDAK_II_2_1"];
                this.columnREDAK_II_2_1_1 = this.Columns["REDAK_II_2_1_1"];
                this.columnREDAK_II_2_1_2 = this.Columns["REDAK_II_2_1_2"];
                this.columnREDAK_II_2_1_3 = this.Columns["REDAK_II_2_1_3"];
                this.columnREDAK_II_2_2 = this.Columns["REDAK_II_2_2"];
                this.columnREDAK_II_2_2_1 = this.Columns["REDAK_II_2_2_1"];
                this.columnREDAK_II_2_2_2 = this.Columns["REDAK_II_2_2_2"];
                this.columnREDAK_II_2_2_3 = this.Columns["REDAK_II_2_2_3"];
                this.columnREDAK_II_3 = this.Columns["REDAK_II_3"];
                this.columnREDAK_II_4 = this.Columns["REDAK_II_4"];
                this.columnREDAK_II_5 = this.Columns["REDAK_II_5"];
                this.columnREDAK_II_6 = this.Columns["REDAK_II_6"];
                this.columnREDAK_II_6_1 = this.Columns["REDAK_II_6_1"];
                this.columnREDAK_II_6_2 = this.Columns["REDAK_II_6_2"];
                this.columnREDAK_II_7 = this.Columns["REDAK_II_7"];
                this.columnREDAK_II_8 = this.Columns["REDAK_II_8"];
                this.columnREDAK_III_1_1 = this.Columns["REDAK_III_1_1"];
                this.columnREDAK_III_1_2 = this.Columns["REDAK_III_1_2"];
                this.columnREDAK_III_2_1 = this.Columns["REDAK_III_2_1"];
                this.columnREDAK_III_2_2 = this.Columns["REDAK_III_2_2"];
                this.columnREDAK_III_3_1 = this.Columns["REDAK_III_3_1"];
                this.columnREDAK_III_3_2 = this.Columns["REDAK_III_3_2"];
                this.columnREDAK_III_3_3 = this.Columns["REDAK_III_3_3"];
                this.columnREDAK_III_4_1 = this.Columns["REDAK_III_4_1"];
                this.columnREDAK_III_4_2 = this.Columns["REDAK_III_4_2"];
                this.columnREDAK_III_5 = this.Columns["REDAK_III_5"];
                this.columnDATUMSASTAVLJANJA = this.Columns["DATUMSASTAVLJANJA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new sp_id_zaglavljeDataSet.sp_id_zaglavljeRow(builder);
            }

            public sp_id_zaglavljeDataSet.sp_id_zaglavljeRow Newsp_id_zaglavljeRow()
            {
                return (sp_id_zaglavljeDataSet.sp_id_zaglavljeRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.sp_id_zaglavljeRowChanged != null)
                {
                    sp_id_zaglavljeDataSet.sp_id_zaglavljeRowChangeEventHandler handler = this.sp_id_zaglavljeRowChanged;
                    if (handler != null)
                    {
                        handler(this, new sp_id_zaglavljeDataSet.sp_id_zaglavljeRowChangeEvent((sp_id_zaglavljeDataSet.sp_id_zaglavljeRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.sp_id_zaglavljeRowChanging != null)
                {
                    sp_id_zaglavljeDataSet.sp_id_zaglavljeRowChangeEventHandler handler = this.sp_id_zaglavljeRowChanging;
                    if (handler != null)
                    {
                        handler(this, new sp_id_zaglavljeDataSet.sp_id_zaglavljeRowChangeEvent((sp_id_zaglavljeDataSet.sp_id_zaglavljeRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.sp_id_zaglavljeRowDeleted != null)
                {
                    sp_id_zaglavljeDataSet.sp_id_zaglavljeRowChangeEventHandler handler = this.sp_id_zaglavljeRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new sp_id_zaglavljeDataSet.sp_id_zaglavljeRowChangeEvent((sp_id_zaglavljeDataSet.sp_id_zaglavljeRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.sp_id_zaglavljeRowDeleting != null)
                {
                    sp_id_zaglavljeDataSet.sp_id_zaglavljeRowChangeEventHandler handler = this.sp_id_zaglavljeRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new sp_id_zaglavljeDataSet.sp_id_zaglavljeRowChangeEvent((sp_id_zaglavljeDataSet.sp_id_zaglavljeRow) e.Row, e.Action));
                    }
                }
            }

            public void Removesp_id_zaglavljeRow(sp_id_zaglavljeDataSet.sp_id_zaglavljeRow row)
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

            public DataColumn DATUMSASTAVLJANJAColumn
            {
                get
                {
                    return this.columnDATUMSASTAVLJANJA;
                }
            }

            public DataColumn idenTIFIKATORColumn
            {
                get
                {
                    return this.columnidenTIFIKATOR;
                }
            }

            public DataColumn ididobrascaColumn
            {
                get
                {
                    return this.columnididobrasca;
                }
            }

            public sp_id_zaglavljeDataSet.sp_id_zaglavljeRow this[int index]
            {
                get
                {
                    return (sp_id_zaglavljeDataSet.sp_id_zaglavljeRow) this.Rows[index];
                }
            }

            public DataColumn maticnibrojColumn
            {
                get
                {
                    return this.columnmaticnibroj;
                }
            }

            public DataColumn nazivfirmeColumn
            {
                get
                {
                    return this.columnnazivfirme;
                }
            }

            public DataColumn punaadresaColumn
            {
                get
                {
                    return this.columnpunaadresa;
                }
            }

            public DataColumn REDAK_II_1Column
            {
                get
                {
                    return this.columnREDAK_II_1;
                }
            }

            public DataColumn REDAK_II_2_1_1Column
            {
                get
                {
                    return this.columnREDAK_II_2_1_1;
                }
            }

            public DataColumn REDAK_II_2_1_2Column
            {
                get
                {
                    return this.columnREDAK_II_2_1_2;
                }
            }

            public DataColumn REDAK_II_2_1_3Column
            {
                get
                {
                    return this.columnREDAK_II_2_1_3;
                }
            }

            public DataColumn REDAK_II_2_1Column
            {
                get
                {
                    return this.columnREDAK_II_2_1;
                }
            }

            public DataColumn REDAK_II_2_2_1Column
            {
                get
                {
                    return this.columnREDAK_II_2_2_1;
                }
            }

            public DataColumn REDAK_II_2_2_2Column
            {
                get
                {
                    return this.columnREDAK_II_2_2_2;
                }
            }

            public DataColumn REDAK_II_2_2_3Column
            {
                get
                {
                    return this.columnREDAK_II_2_2_3;
                }
            }

            public DataColumn REDAK_II_2_2Column
            {
                get
                {
                    return this.columnREDAK_II_2_2;
                }
            }

            public DataColumn REDAK_II_2Column
            {
                get
                {
                    return this.columnREDAK_II_2;
                }
            }

            public DataColumn REDAK_II_3Column
            {
                get
                {
                    return this.columnREDAK_II_3;
                }
            }

            public DataColumn REDAK_II_4Column
            {
                get
                {
                    return this.columnREDAK_II_4;
                }
            }

            public DataColumn REDAK_II_5Column
            {
                get
                {
                    return this.columnREDAK_II_5;
                }
            }

            public DataColumn REDAK_II_6_1Column
            {
                get
                {
                    return this.columnREDAK_II_6_1;
                }
            }

            public DataColumn REDAK_II_6_2Column
            {
                get
                {
                    return this.columnREDAK_II_6_2;
                }
            }

            public DataColumn REDAK_II_6Column
            {
                get
                {
                    return this.columnREDAK_II_6;
                }
            }

            public DataColumn REDAK_II_7Column
            {
                get
                {
                    return this.columnREDAK_II_7;
                }
            }

            public DataColumn REDAK_II_8Column
            {
                get
                {
                    return this.columnREDAK_II_8;
                }
            }

            public DataColumn REDAK_III_1_1Column
            {
                get
                {
                    return this.columnREDAK_III_1_1;
                }
            }

            public DataColumn REDAK_III_1_2Column
            {
                get
                {
                    return this.columnREDAK_III_1_2;
                }
            }

            public DataColumn REDAK_III_2_1Column
            {
                get
                {
                    return this.columnREDAK_III_2_1;
                }
            }

            public DataColumn REDAK_III_2_2Column
            {
                get
                {
                    return this.columnREDAK_III_2_2;
                }
            }

            public DataColumn REDAK_III_3_1Column
            {
                get
                {
                    return this.columnREDAK_III_3_1;
                }
            }

            public DataColumn REDAK_III_3_2Column
            {
                get
                {
                    return this.columnREDAK_III_3_2;
                }
            }

            public DataColumn REDAK_III_3_3Column
            {
                get
                {
                    return this.columnREDAK_III_3_3;
                }
            }

            public DataColumn REDAK_III_4_1Column
            {
                get
                {
                    return this.columnREDAK_III_4_1;
                }
            }

            public DataColumn REDAK_III_4_2Column
            {
                get
                {
                    return this.columnREDAK_III_4_2;
                }
            }

            public DataColumn REDAK_III_5Column
            {
                get
                {
                    return this.columnREDAK_III_5;
                }
            }
        }

        public class sp_id_zaglavljeRow : DataRow
        {
            private sp_id_zaglavljeDataSet.sp_id_zaglavljeDataTable tablesp_id_zaglavlje;

            internal sp_id_zaglavljeRow(DataRowBuilder rb) : base(rb)
            {
                this.tablesp_id_zaglavlje = (sp_id_zaglavljeDataSet.sp_id_zaglavljeDataTable) this.Table;
            }

            public bool IsDATUMSASTAVLJANJANull()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.DATUMSASTAVLJANJAColumn);
            }

            public bool IsidenTIFIKATORNull()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.idenTIFIKATORColumn);
            }

            public bool IsididobrascaNull()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.ididobrascaColumn);
            }

            public bool IsmaticnibrojNull()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.maticnibrojColumn);
            }

            public bool IsnazivfirmeNull()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.nazivfirmeColumn);
            }

            public bool IspunaadresaNull()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.punaadresaColumn);
            }

            public bool IsREDAK_II_1Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_1Column);
            }

            public bool IsREDAK_II_2_1_1Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_2_1_1Column);
            }

            public bool IsREDAK_II_2_1_2Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_2_1_2Column);
            }

            public bool IsREDAK_II_2_1_3Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_2_1_3Column);
            }

            public bool IsREDAK_II_2_1Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_2_1Column);
            }

            public bool IsREDAK_II_2_2_1Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_2_2_1Column);
            }

            public bool IsREDAK_II_2_2_2Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_2_2_2Column);
            }

            public bool IsREDAK_II_2_2_3Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_2_2_3Column);
            }

            public bool IsREDAK_II_2_2Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_2_2Column);
            }

            public bool IsREDAK_II_2Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_2Column);
            }

            public bool IsREDAK_II_3Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_3Column);
            }

            public bool IsREDAK_II_4Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_4Column);
            }

            public bool IsREDAK_II_5Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_5Column);
            }

            public bool IsREDAK_II_6_1Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_6_1Column);
            }

            public bool IsREDAK_II_6_2Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_6_2Column);
            }

            public bool IsREDAK_II_6Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_6Column);
            }

            public bool IsREDAK_II_7Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_7Column);
            }

            public bool IsREDAK_II_8Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_II_8Column);
            }

            public bool IsREDAK_III_1_1Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_III_1_1Column);
            }

            public bool IsREDAK_III_1_2Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_III_1_2Column);
            }

            public bool IsREDAK_III_2_1Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_III_2_1Column);
            }

            public bool IsREDAK_III_2_2Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_III_2_2Column);
            }

            public bool IsREDAK_III_3_1Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_III_3_1Column);
            }

            public bool IsREDAK_III_3_2Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_III_3_2Column);
            }

            public bool IsREDAK_III_3_3Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_III_3_3Column);
            }

            public bool IsREDAK_III_4_1Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_III_4_1Column);
            }

            public bool IsREDAK_III_4_2Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_III_4_2Column);
            }

            public bool IsREDAK_III_5Null()
            {
                return this.IsNull(this.tablesp_id_zaglavlje.REDAK_III_5Column);
            }

            public void SetDATUMSASTAVLJANJANull()
            {
                this[this.tablesp_id_zaglavlje.DATUMSASTAVLJANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetidenTIFIKATORNull()
            {
                this[this.tablesp_id_zaglavlje.idenTIFIKATORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetididobrascaNull()
            {
                this[this.tablesp_id_zaglavlje.ididobrascaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetmaticnibrojNull()
            {
                this[this.tablesp_id_zaglavlje.maticnibrojColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnazivfirmeNull()
            {
                this[this.tablesp_id_zaglavlje.nazivfirmeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetpunaadresaNull()
            {
                this[this.tablesp_id_zaglavlje.punaadresaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_1Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_2_1_1Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_1_1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_2_1_2Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_1_2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_2_1_3Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_1_3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_2_1Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_2_2_1Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_2_1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_2_2_2Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_2_2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_2_2_3Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_2_3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_2_2Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_2Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_3Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_4Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_4Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_5Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_5Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_6_1Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_6_1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_6_2Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_6_2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_6Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_6Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_7Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_7Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_II_8Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_8Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_III_1_1Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_1_1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_III_1_2Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_1_2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_III_2_1Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_2_1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_III_2_2Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_2_2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_III_3_1Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_3_1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_III_3_2Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_3_2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_III_3_3Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_3_3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_III_4_1Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_4_1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_III_4_2Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_4_2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDAK_III_5Null()
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_5Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public DateTime DATUMSASTAVLJANJA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tablesp_id_zaglavlje.DATUMSASTAVLJANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.DATUMSASTAVLJANJAColumn] = value;
                }
            }

            public string idenTIFIKATOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_id_zaglavlje.idenTIFIKATORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.idenTIFIKATORColumn] = value;
                }
            }

            public int ididobrasca
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablesp_id_zaglavlje.ididobrascaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.ididobrascaColumn] = value;
                }
            }

            public string maticnibroj
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_id_zaglavlje.maticnibrojColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.maticnibrojColumn] = value;
                }
            }

            public string nazivfirme
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_id_zaglavlje.nazivfirmeColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.nazivfirmeColumn] = value;
                }
            }

            public string punaadresa
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_id_zaglavlje.punaadresaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.punaadresaColumn] = value;
                }
            }

            public decimal REDAK_II_1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_1Column] = value;
                }
            }

            public decimal REDAK_II_2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_2Column] = value;
                }
            }

            public decimal REDAK_II_2_1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_2_1Column] = value;
                }
            }

            public decimal REDAK_II_2_1_1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_1_1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_2_1_1Column] = value;
                }
            }

            public decimal REDAK_II_2_1_2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_1_2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_2_1_2Column] = value;
                }
            }

            public decimal REDAK_II_2_1_3
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_1_3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_2_1_3Column] = value;
                }
            }

            public decimal REDAK_II_2_2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_2_2Column] = value;
                }
            }

            public decimal REDAK_II_2_2_1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_2_1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_2_2_1Column] = value;
                }
            }

            public decimal REDAK_II_2_2_2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_2_2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_2_2_2Column] = value;
                }
            }

            public decimal REDAK_II_2_2_3
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_2_3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_2_2_3Column] = value;
                }
            }

            public decimal REDAK_II_3
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_3Column] = value;
                }
            }

            public decimal REDAK_II_4
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_4Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_4Column] = value;
                }
            }

            public decimal REDAK_II_5
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_5Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_5Column] = value;
                }
            }

            public decimal REDAK_II_6
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_6Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_6Column] = value;
                }
            }

            public decimal REDAK_II_6_1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_6_1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_6_1Column] = value;
                }
            }

            public decimal REDAK_II_6_2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_6_2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_6_2Column] = value;
                }
            }

            public decimal REDAK_II_7
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_7Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_7Column] = value;
                }
            }

            public decimal REDAK_II_8
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_8Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_II_8Column] = value;
                }
            }

            public decimal REDAK_III_1_1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_1_1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_III_1_1Column] = value;
                }
            }

            public decimal REDAK_III_1_2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_1_2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_III_1_2Column] = value;
                }
            }

            public decimal REDAK_III_2_1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_2_1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_III_2_1Column] = value;
                }
            }

            public decimal REDAK_III_2_2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_2_2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_III_2_2Column] = value;
                }
            }

            public decimal REDAK_III_3_1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_3_1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_III_3_1Column] = value;
                }
            }

            public decimal REDAK_III_3_2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_3_2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_III_3_2Column] = value;
                }
            }

            public decimal REDAK_III_3_3
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_3_3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_III_3_3Column] = value;
                }
            }

            public decimal REDAK_III_4_1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_4_1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_III_4_1Column] = value;
                }
            }

            public decimal REDAK_III_4_2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_4_2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_III_4_2Column] = value;
                }
            }

            public decimal REDAK_III_5
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_5Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_id_zaglavlje.REDAK_III_5Column] = value;
                }
            }
        }

        public class sp_id_zaglavljeRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private sp_id_zaglavljeDataSet.sp_id_zaglavljeRow eventRow;

            public sp_id_zaglavljeRowChangeEvent(sp_id_zaglavljeDataSet.sp_id_zaglavljeRow row, DataRowAction action)
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

            public sp_id_zaglavljeDataSet.sp_id_zaglavljeRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void sp_id_zaglavljeRowChangeEventHandler(object sender, sp_id_zaglavljeDataSet.sp_id_zaglavljeRowChangeEvent e);
    }
}

