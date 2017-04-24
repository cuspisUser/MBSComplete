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
    public class BLAGAJNADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private BLAGAJNADataTable tableBLAGAJNA;
        private BLAGAJNAStavkeBlagajneDataTable tableBLAGAJNAStavkeBlagajne;
        private BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje;

        public BLAGAJNADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected BLAGAJNADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"] != null)
                    {
                        this.Tables.Add(new BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable(dataSet.Tables["BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"]));
                    }
                    if (dataSet.Tables["BLAGAJNAStavkeBlagajne"] != null)
                    {
                        this.Tables.Add(new BLAGAJNAStavkeBlagajneDataTable(dataSet.Tables["BLAGAJNAStavkeBlagajne"]));
                    }
                    if (dataSet.Tables["BLAGAJNA"] != null)
                    {
                        this.Tables.Add(new BLAGAJNADataTable(dataSet.Tables["BLAGAJNA"]));
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
            BLAGAJNADataSet set = (BLAGAJNADataSet) base.Clone();
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
            BLAGAJNADataSet set = new BLAGAJNADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "BLAGAJNADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2033");
            this.ExtendedProperties.Add("DataSetName", "BLAGAJNADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IBLAGAJNADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "BLAGAJNA");
            this.ExtendedProperties.Add("ObjectDescription", "BLAGAJNA");
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
            this.DataSetName = "BLAGAJNADataSet";
            this.Namespace = "http://www.tempuri.org/BLAGAJNA";
            this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje = new BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable();
            this.Tables.Add(this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje);
            this.tableBLAGAJNAStavkeBlagajne = new BLAGAJNAStavkeBlagajneDataTable();
            this.Tables.Add(this.tableBLAGAJNAStavkeBlagajne);
            this.tableBLAGAJNA = new BLAGAJNADataTable();
            this.Tables.Add(this.tableBLAGAJNA);
            this.Relations.Add("BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje", new DataColumn[] { this.Tables["BLAGAJNAStavkeBlagajne"].Columns["BLGDOKIDDOKUMENT"], this.Tables["BLAGAJNAStavkeBlagajne"].Columns["IDBLGVRSTEDOK"], this.Tables["BLAGAJNAStavkeBlagajne"].Columns["blggodineIDGODINE"], this.Tables["BLAGAJNAStavkeBlagajne"].Columns["BLGBROJDOKUMENTA"] }, new DataColumn[] { this.Tables["BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].Columns["BLGDOKIDDOKUMENT"], this.Tables["BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].Columns["IDBLGVRSTEDOK"], this.Tables["BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].Columns["blggodineIDGODINE"], this.Tables["BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].Columns["BLGBROJDOKUMENTA"] });
            this.Relations["BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].Nested = true;
            this.Relations.Add("BLAGAJNA_BLAGAJNAStavkeBlagajne", new DataColumn[] { this.Tables["BLAGAJNA"].Columns["BLGDOKIDDOKUMENT"] }, new DataColumn[] { this.Tables["BLAGAJNAStavkeBlagajne"].Columns["BLGDOKIDDOKUMENT"] });
            this.Relations["BLAGAJNA_BLAGAJNAStavkeBlagajne"].Nested = true;
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
            this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje = (BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable) this.Tables["BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"];
            this.tableBLAGAJNAStavkeBlagajne = (BLAGAJNAStavkeBlagajneDataTable) this.Tables["BLAGAJNAStavkeBlagajne"];
            this.tableBLAGAJNA = (BLAGAJNADataTable) this.Tables["BLAGAJNA"];
            if (initTable)
            {
                if (this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje != null)
                {
                    this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.InitVars();
                }
                if (this.tableBLAGAJNAStavkeBlagajne != null)
                {
                    this.tableBLAGAJNAStavkeBlagajne.InitVars();
                }
                if (this.tableBLAGAJNA != null)
                {
                    this.tableBLAGAJNA.InitVars();
                }
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"] != null)
                {
                    this.Tables.Add(new BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable(dataSet.Tables["BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"]));
                }
                if (dataSet.Tables["BLAGAJNAStavkeBlagajne"] != null)
                {
                    this.Tables.Add(new BLAGAJNAStavkeBlagajneDataTable(dataSet.Tables["BLAGAJNAStavkeBlagajne"]));
                }
                if (dataSet.Tables["BLAGAJNA"] != null)
                {
                    this.Tables.Add(new BLAGAJNADataTable(dataSet.Tables["BLAGAJNA"]));
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

        private bool ShouldSerializeBLAGAJNA()
        {
            return false;
        }

        private bool ShouldSerializeBLAGAJNAStavkeBlagajne()
        {
            return false;
        }

        private bool ShouldSerializeBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje()
        {
            return false;
        }

        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BLAGAJNADataTable BLAGAJNA
        {
            get
            {
                return this.tableBLAGAJNA;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BLAGAJNAStavkeBlagajneDataTable BLAGAJNAStavkeBlagajne
        {
            get
            {
                return this.tableBLAGAJNAStavkeBlagajne;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje
        {
            get
            {
                return this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje;
            }
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

        [Serializable]
        public class BLAGAJNADataTable : DataTable, IEnumerable
        {
            private DataColumn columnBLGDOKIDDOKUMENT;
            private DataColumn columnBLGKONTOIDKONTO;
            private DataColumn columnNAZIVBLAGAJNA;

            public event BLAGAJNADataSet.BLAGAJNARowChangeEventHandler BLAGAJNARowChanged;

            public event BLAGAJNADataSet.BLAGAJNARowChangeEventHandler BLAGAJNARowChanging;

            public event BLAGAJNADataSet.BLAGAJNARowChangeEventHandler BLAGAJNARowDeleted;

            public event BLAGAJNADataSet.BLAGAJNARowChangeEventHandler BLAGAJNARowDeleting;

            public BLAGAJNADataTable()
            {
                this.TableName = "BLAGAJNA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal BLAGAJNADataTable(DataTable table) : base(table.TableName)
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

            protected BLAGAJNADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddBLAGAJNARow(BLAGAJNADataSet.BLAGAJNARow row)
            {
                this.Rows.Add(row);
            }

            public BLAGAJNADataSet.BLAGAJNARow AddBLAGAJNARow(int bLGDOKIDDOKUMENT, string nAZIVBLAGAJNA, string bLGKONTOIDKONTO)
            {
                BLAGAJNADataSet.BLAGAJNARow row = (BLAGAJNADataSet.BLAGAJNARow) this.NewRow();
                row["BLGDOKIDDOKUMENT"] = bLGDOKIDDOKUMENT;
                row["NAZIVBLAGAJNA"] = nAZIVBLAGAJNA;
                row["BLGKONTOIDKONTO"] = bLGKONTOIDKONTO;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                BLAGAJNADataSet.BLAGAJNADataTable table = (BLAGAJNADataSet.BLAGAJNADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public BLAGAJNADataSet.BLAGAJNARow FindByBLGDOKIDDOKUMENT(int bLGDOKIDDOKUMENT)
            {
                return (BLAGAJNADataSet.BLAGAJNARow) this.Rows.Find(new object[] { bLGDOKIDDOKUMENT });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(BLAGAJNADataSet.BLAGAJNARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                BLAGAJNADataSet set = new BLAGAJNADataSet();
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
                this.columnBLGDOKIDDOKUMENT = new DataColumn("BLGDOKIDDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnBLGDOKIDDOKUMENT.AllowDBNull = false;
                this.columnBLGDOKIDDOKUMENT.Caption = "IDDOKUMENT";
                this.columnBLGDOKIDDOKUMENT.Unique = true;
                this.columnBLGDOKIDDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("SuperType", "IDDOKUMENT");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("SubtypeGroup", "BLGDOK");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Description", "Šifra dok. blagajne");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Length", "8");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "BLGDOKIDDOKUMENT");
                this.Columns.Add(this.columnBLGDOKIDDOKUMENT);
                this.columnNAZIVBLAGAJNA = new DataColumn("NAZIVBLAGAJNA", typeof(string), "", MappingType.Element);
                this.columnNAZIVBLAGAJNA.AllowDBNull = false;
                this.columnNAZIVBLAGAJNA.Caption = "NAZIVBLAGAJNA";
                this.columnNAZIVBLAGAJNA.MaxLength = 30;
                this.columnNAZIVBLAGAJNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("Description", "Naziv");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("Length", "30");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBLAGAJNA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBLAGAJNA");
                this.Columns.Add(this.columnNAZIVBLAGAJNA);
                this.columnBLGKONTOIDKONTO = new DataColumn("BLGKONTOIDKONTO", typeof(string), "", MappingType.Element);
                this.columnBLGKONTOIDKONTO.AllowDBNull = false;
                this.columnBLGKONTOIDKONTO.Caption = "IDKONTO";
                this.columnBLGKONTOIDKONTO.MaxLength = 14;
                this.columnBLGKONTOIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("SubtypeGroup", "BLGKONTO");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("Description", "Konto blagajne");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGKONTOIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "BLGKONTOIDKONTO");
                this.Columns.Add(this.columnBLGKONTOIDKONTO);
                this.PrimaryKey = new DataColumn[] { this.columnBLGDOKIDDOKUMENT };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "BLAGAJNA");
                this.ExtendedProperties.Add("Description", "BLAGAJNA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnBLGDOKIDDOKUMENT = this.Columns["BLGDOKIDDOKUMENT"];
                this.columnNAZIVBLAGAJNA = this.Columns["NAZIVBLAGAJNA"];
                this.columnBLGKONTOIDKONTO = this.Columns["BLGKONTOIDKONTO"];
            }

            public BLAGAJNADataSet.BLAGAJNARow NewBLAGAJNARow()
            {
                return (BLAGAJNADataSet.BLAGAJNARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new BLAGAJNADataSet.BLAGAJNARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.BLAGAJNARowChanged != null)
                {
                    BLAGAJNADataSet.BLAGAJNARowChangeEventHandler bLAGAJNARowChangedEvent = this.BLAGAJNARowChanged;
                    if (bLAGAJNARowChangedEvent != null)
                    {
                        bLAGAJNARowChangedEvent(this, new BLAGAJNADataSet.BLAGAJNARowChangeEvent((BLAGAJNADataSet.BLAGAJNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.BLAGAJNARowChanging != null)
                {
                    BLAGAJNADataSet.BLAGAJNARowChangeEventHandler bLAGAJNARowChangingEvent = this.BLAGAJNARowChanging;
                    if (bLAGAJNARowChangingEvent != null)
                    {
                        bLAGAJNARowChangingEvent(this, new BLAGAJNADataSet.BLAGAJNARowChangeEvent((BLAGAJNADataSet.BLAGAJNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.BLAGAJNARowDeleted != null)
                {
                    BLAGAJNADataSet.BLAGAJNARowChangeEventHandler bLAGAJNARowDeletedEvent = this.BLAGAJNARowDeleted;
                    if (bLAGAJNARowDeletedEvent != null)
                    {
                        bLAGAJNARowDeletedEvent(this, new BLAGAJNADataSet.BLAGAJNARowChangeEvent((BLAGAJNADataSet.BLAGAJNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.BLAGAJNARowDeleting != null)
                {
                    BLAGAJNADataSet.BLAGAJNARowChangeEventHandler bLAGAJNARowDeletingEvent = this.BLAGAJNARowDeleting;
                    if (bLAGAJNARowDeletingEvent != null)
                    {
                        bLAGAJNARowDeletingEvent(this, new BLAGAJNADataSet.BLAGAJNARowChangeEvent((BLAGAJNADataSet.BLAGAJNARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveBLAGAJNARow(BLAGAJNADataSet.BLAGAJNARow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BLGDOKIDDOKUMENTColumn
            {
                get
                {
                    return this.columnBLGDOKIDDOKUMENT;
                }
            }

            public DataColumn BLGKONTOIDKONTOColumn
            {
                get
                {
                    return this.columnBLGKONTOIDKONTO;
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

            public BLAGAJNADataSet.BLAGAJNARow this[int index]
            {
                get
                {
                    return (BLAGAJNADataSet.BLAGAJNARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVBLAGAJNAColumn
            {
                get
                {
                    return this.columnNAZIVBLAGAJNA;
                }
            }
        }

        public class BLAGAJNARow : DataRow
        {
            private BLAGAJNADataSet.BLAGAJNADataTable tableBLAGAJNA;

            internal BLAGAJNARow(DataRowBuilder rb) : base(rb)
            {
                this.tableBLAGAJNA = (BLAGAJNADataSet.BLAGAJNADataTable) this.Table;
            }

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow[] GetBLAGAJNAStavkeBlagajneRows()
            {
                return (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow[]) this.GetChildRows("BLAGAJNA_BLAGAJNAStavkeBlagajne");
            }

            public bool IsBLGDOKIDDOKUMENTNull()
            {
                return this.IsNull(this.tableBLAGAJNA.BLGDOKIDDOKUMENTColumn);
            }

            public bool IsBLGKONTOIDKONTONull()
            {
                return this.IsNull(this.tableBLAGAJNA.BLGKONTOIDKONTOColumn);
            }

            public bool IsNAZIVBLAGAJNANull()
            {
                return this.IsNull(this.tableBLAGAJNA.NAZIVBLAGAJNAColumn);
            }

            public void SetBLGKONTOIDKONTONull()
            {
                this[this.tableBLAGAJNA.BLGKONTOIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBLAGAJNANull()
            {
                this[this.tableBLAGAJNA.NAZIVBLAGAJNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BLGDOKIDDOKUMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableBLAGAJNA.BLGDOKIDDOKUMENTColumn]);
                }
                set
                {
                    this[this.tableBLAGAJNA.BLGDOKIDDOKUMENTColumn] = value;
                }
            }

            public string BLGKONTOIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBLAGAJNA.BLGKONTOIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BLGKONTOIDKONTO because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableBLAGAJNA.BLGKONTOIDKONTOColumn] = value;
                }
            }

            public string NAZIVBLAGAJNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBLAGAJNA.NAZIVBLAGAJNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVBLAGAJNA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableBLAGAJNA.NAZIVBLAGAJNAColumn] = value;
                }
            }
        }

        public class BLAGAJNARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private BLAGAJNADataSet.BLAGAJNARow eventRow;

            public BLAGAJNARowChangeEvent(BLAGAJNADataSet.BLAGAJNARow row, DataRowAction action)
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

            public BLAGAJNADataSet.BLAGAJNARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void BLAGAJNARowChangeEventHandler(object sender, BLAGAJNADataSet.BLAGAJNARowChangeEvent e);

        [Serializable]
        public class BLAGAJNAStavkeBlagajneDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBLGBROJDOKUMENTA;
            private DataColumn columnBLGDATUMDOKUMENTA;
            private DataColumn columnBLGDOKIDDOKUMENT;
            private DataColumn columnblggodineIDGODINE;
            private DataColumn columnBLGIZNOS;
            private DataColumn columnBLGSVRHA;
            private DataColumn columnIDBLGVRSTEDOK;
            private DataColumn columnNAZIVVRSTEDOK;

            public event BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRowChangeEventHandler BLAGAJNAStavkeBlagajneRowChanged;

            public event BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRowChangeEventHandler BLAGAJNAStavkeBlagajneRowChanging;

            public event BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRowChangeEventHandler BLAGAJNAStavkeBlagajneRowDeleted;

            public event BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRowChangeEventHandler BLAGAJNAStavkeBlagajneRowDeleting;

            public BLAGAJNAStavkeBlagajneDataTable()
            {
                this.TableName = "BLAGAJNAStavkeBlagajne";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal BLAGAJNAStavkeBlagajneDataTable(DataTable table) : base(table.TableName)
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

            protected BLAGAJNAStavkeBlagajneDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddBLAGAJNAStavkeBlagajneRow(BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow row)
            {
                this.Rows.Add(row);
            }

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow AddBLAGAJNAStavkeBlagajneRow(int bLGDOKIDDOKUMENT, int iDBLGVRSTEDOK, short blggodineIDGODINE, int bLGBROJDOKUMENTA, DateTime bLGDATUMDOKUMENTA, string bLGSVRHA, decimal bLGIZNOS)
            {
                BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow row = (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) this.NewRow();
                row["BLGDOKIDDOKUMENT"] = bLGDOKIDDOKUMENT;
                row["IDBLGVRSTEDOK"] = iDBLGVRSTEDOK;
                row["blggodineIDGODINE"] = blggodineIDGODINE;
                row["BLGBROJDOKUMENTA"] = bLGBROJDOKUMENTA;
                row["BLGDATUMDOKUMENTA"] = bLGDATUMDOKUMENTA;
                row["BLGSVRHA"] = bLGSVRHA;
                row["BLGIZNOS"] = bLGIZNOS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                BLAGAJNADataSet.BLAGAJNAStavkeBlagajneDataTable table = (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow FindByBLGDOKIDDOKUMENTIDBLGVRSTEDOKblggodineIDGODINEBLGBROJDOKUMENTA(int bLGDOKIDDOKUMENT, int iDBLGVRSTEDOK, short blggodineIDGODINE, int bLGBROJDOKUMENTA)
            {
                return (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) this.Rows.Find(new object[] { bLGDOKIDDOKUMENT, iDBLGVRSTEDOK, blggodineIDGODINE, bLGBROJDOKUMENTA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                BLAGAJNADataSet set = new BLAGAJNADataSet();
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
                this.columnBLGDOKIDDOKUMENT = new DataColumn("BLGDOKIDDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnBLGDOKIDDOKUMENT.AllowDBNull = false;
                this.columnBLGDOKIDDOKUMENT.Caption = "IDDOKUMENT";
                this.columnBLGDOKIDDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("SuperType", "IDDOKUMENT");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("SubtypeGroup", "BLGDOK");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Description", "Šifra dok. blagajne");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Length", "8");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "BLGDOKIDDOKUMENT");
                this.Columns.Add(this.columnBLGDOKIDDOKUMENT);
                this.columnIDBLGVRSTEDOK = new DataColumn("IDBLGVRSTEDOK", typeof(int), "", MappingType.Element);
                this.columnIDBLGVRSTEDOK.AllowDBNull = false;
                this.columnIDBLGVRSTEDOK.Caption = "IDBLGVRSTEDOK";
                this.columnIDBLGVRSTEDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Description", "Šifra vrste dok.");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Length", "5");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.InternalName", "IDBLGVRSTEDOK");
                this.Columns.Add(this.columnIDBLGVRSTEDOK);
                this.columnblggodineIDGODINE = new DataColumn("blggodineIDGODINE", typeof(short), "", MappingType.Element);
                this.columnblggodineIDGODINE.AllowDBNull = false;
                this.columnblggodineIDGODINE.Caption = "IDGODINE";
                this.columnblggodineIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("SuperType", "IDGODINE");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("SubtypeGroup", "blggodine");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("IsKey", "true");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Description", "Godina");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "blggodineIDGODINE");
                this.Columns.Add(this.columnblggodineIDGODINE);
                this.columnNAZIVVRSTEDOK = new DataColumn("NAZIVVRSTEDOK", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTEDOK.AllowDBNull = true;
                this.columnNAZIVVRSTEDOK.Caption = "NAZIVVRSTEDOK";
                this.columnNAZIVVRSTEDOK.MaxLength = 30;
                this.columnNAZIVVRSTEDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Description", "Naziv");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Length", "30");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTEDOK");
                this.Columns.Add(this.columnNAZIVVRSTEDOK);
                this.columnBLGBROJDOKUMENTA = new DataColumn("BLGBROJDOKUMENTA", typeof(int), "", MappingType.Element);
                this.columnBLGBROJDOKUMENTA.AllowDBNull = false;
                this.columnBLGBROJDOKUMENTA.Caption = "BLGBROJDOKUMENTA";
                this.columnBLGBROJDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("IsKey", "true");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Description", "Broj dokumenta");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Length", "8");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "BLGBROJDOKUMENTA");
                this.Columns.Add(this.columnBLGBROJDOKUMENTA);
                this.columnBLGDATUMDOKUMENTA = new DataColumn("BLGDATUMDOKUMENTA", typeof(DateTime), "", MappingType.Element);
                this.columnBLGDATUMDOKUMENTA.AllowDBNull = false;
                this.columnBLGDATUMDOKUMENTA.Caption = "BLGDATUMDOKUMENTA";
                this.columnBLGDATUMDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Description", "Datum");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Length", "8");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "BLGDATUMDOKUMENTA");
                this.Columns.Add(this.columnBLGDATUMDOKUMENTA);
                this.columnBLGSVRHA = new DataColumn("BLGSVRHA", typeof(string), "", MappingType.Element);
                this.columnBLGSVRHA.AllowDBNull = false;
                this.columnBLGSVRHA.Caption = "BLGSVRHA";
                this.columnBLGSVRHA.MaxLength = 100;
                this.columnBLGSVRHA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGSVRHA.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGSVRHA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBLGSVRHA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBLGSVRHA.ExtendedProperties.Add("Description", "Svrha");
                this.columnBLGSVRHA.ExtendedProperties.Add("Length", "100");
                this.columnBLGSVRHA.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGSVRHA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.InternalName", "BLGSVRHA");
                this.Columns.Add(this.columnBLGSVRHA);
                this.columnBLGIZNOS = new DataColumn("BLGIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnBLGIZNOS.AllowDBNull = false;
                this.columnBLGIZNOS.Caption = "BLGIZNOS";
                this.columnBLGIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGIZNOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBLGIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLGIZNOS.ExtendedProperties.Add("Description", "Iznos");
                this.columnBLGIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnBLGIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnBLGIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBLGIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBLGIZNOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLGIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "BLGIZNOS");
                this.Columns.Add(this.columnBLGIZNOS);
                this.PrimaryKey = new DataColumn[] { this.columnBLGDOKIDDOKUMENT, this.columnIDBLGVRSTEDOK, this.columnblggodineIDGODINE, this.columnBLGBROJDOKUMENTA };
                this.ExtendedProperties.Add("ParentLvl", "BLAGAJNA");
                this.ExtendedProperties.Add("LevelName", "StavkeBlagajne");
                this.ExtendedProperties.Add("Description", "StavkeBlagajne");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnBLGDOKIDDOKUMENT = this.Columns["BLGDOKIDDOKUMENT"];
                this.columnIDBLGVRSTEDOK = this.Columns["IDBLGVRSTEDOK"];
                this.columnblggodineIDGODINE = this.Columns["blggodineIDGODINE"];
                this.columnNAZIVVRSTEDOK = this.Columns["NAZIVVRSTEDOK"];
                this.columnBLGBROJDOKUMENTA = this.Columns["BLGBROJDOKUMENTA"];
                this.columnBLGDATUMDOKUMENTA = this.Columns["BLGDATUMDOKUMENTA"];
                this.columnBLGSVRHA = this.Columns["BLGSVRHA"];
                this.columnBLGIZNOS = this.Columns["BLGIZNOS"];
            }

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow NewBLAGAJNAStavkeBlagajneRow()
            {
                return (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.BLAGAJNAStavkeBlagajneRowChanged != null)
                {
                    BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRowChangeEventHandler bLAGAJNAStavkeBlagajneRowChangedEvent = this.BLAGAJNAStavkeBlagajneRowChanged;
                    if (bLAGAJNAStavkeBlagajneRowChangedEvent != null)
                    {
                        bLAGAJNAStavkeBlagajneRowChangedEvent(this, new BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRowChangeEvent((BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.BLAGAJNAStavkeBlagajneRowChanging != null)
                {
                    BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRowChangeEventHandler bLAGAJNAStavkeBlagajneRowChangingEvent = this.BLAGAJNAStavkeBlagajneRowChanging;
                    if (bLAGAJNAStavkeBlagajneRowChangingEvent != null)
                    {
                        bLAGAJNAStavkeBlagajneRowChangingEvent(this, new BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRowChangeEvent((BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("BLAGAJNA_BLAGAJNAStavkeBlagajne", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.BLAGAJNAStavkeBlagajneRowDeleted != null)
                {
                    BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRowChangeEventHandler bLAGAJNAStavkeBlagajneRowDeletedEvent = this.BLAGAJNAStavkeBlagajneRowDeleted;
                    if (bLAGAJNAStavkeBlagajneRowDeletedEvent != null)
                    {
                        bLAGAJNAStavkeBlagajneRowDeletedEvent(this, new BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRowChangeEvent((BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.BLAGAJNAStavkeBlagajneRowDeleting != null)
                {
                    BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRowChangeEventHandler bLAGAJNAStavkeBlagajneRowDeletingEvent = this.BLAGAJNAStavkeBlagajneRowDeleting;
                    if (bLAGAJNAStavkeBlagajneRowDeletingEvent != null)
                    {
                        bLAGAJNAStavkeBlagajneRowDeletingEvent(this, new BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRowChangeEvent((BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveBLAGAJNAStavkeBlagajneRow(BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BLGBROJDOKUMENTAColumn
            {
                get
                {
                    return this.columnBLGBROJDOKUMENTA;
                }
            }

            public DataColumn BLGDATUMDOKUMENTAColumn
            {
                get
                {
                    return this.columnBLGDATUMDOKUMENTA;
                }
            }

            public DataColumn BLGDOKIDDOKUMENTColumn
            {
                get
                {
                    return this.columnBLGDOKIDDOKUMENT;
                }
            }

            public DataColumn blggodineIDGODINEColumn
            {
                get
                {
                    return this.columnblggodineIDGODINE;
                }
            }

            public DataColumn BLGIZNOSColumn
            {
                get
                {
                    return this.columnBLGIZNOS;
                }
            }

            public DataColumn BLGSVRHAColumn
            {
                get
                {
                    return this.columnBLGSVRHA;
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

            public DataColumn IDBLGVRSTEDOKColumn
            {
                get
                {
                    return this.columnIDBLGVRSTEDOK;
                }
            }

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow this[int index]
            {
                get
                {
                    return (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVVRSTEDOKColumn
            {
                get
                {
                    return this.columnNAZIVVRSTEDOK;
                }
            }
        }

        public class BLAGAJNAStavkeBlagajneRow : DataRow
        {
            private BLAGAJNADataSet.BLAGAJNAStavkeBlagajneDataTable tableBLAGAJNAStavkeBlagajne;

            internal BLAGAJNAStavkeBlagajneRow(DataRowBuilder rb) : base(rb)
            {
                this.tableBLAGAJNAStavkeBlagajne = (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneDataTable) this.Table;
            }

            public BLAGAJNADataSet.BLAGAJNARow GetBLAGAJNARow()
            {
                return (BLAGAJNADataSet.BLAGAJNARow) this.GetParentRow("BLAGAJNA_BLAGAJNAStavkeBlagajne");
            }

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow[] GetBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRows()
            {
                return (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow[]) this.GetChildRows("BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje");
            }

            public bool IsBLGBROJDOKUMENTANull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajne.BLGBROJDOKUMENTAColumn);
            }

            public bool IsBLGDATUMDOKUMENTANull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajne.BLGDATUMDOKUMENTAColumn);
            }

            public bool IsBLGDOKIDDOKUMENTNull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajne.BLGDOKIDDOKUMENTColumn);
            }

            public bool IsblggodineIDGODINENull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajne.blggodineIDGODINEColumn);
            }

            public bool IsBLGIZNOSNull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajne.BLGIZNOSColumn);
            }

            public bool IsBLGSVRHANull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajne.BLGSVRHAColumn);
            }

            public bool IsIDBLGVRSTEDOKNull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajne.IDBLGVRSTEDOKColumn);
            }

            public bool IsNAZIVVRSTEDOKNull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajne.NAZIVVRSTEDOKColumn);
            }

            public void SetBLGDATUMDOKUMENTANull()
            {
                this[this.tableBLAGAJNAStavkeBlagajne.BLGDATUMDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBLGIZNOSNull()
            {
                this[this.tableBLAGAJNAStavkeBlagajne.BLGIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBLGSVRHANull()
            {
                this[this.tableBLAGAJNAStavkeBlagajne.BLGSVRHAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVVRSTEDOKNull()
            {
                this[this.tableBLAGAJNAStavkeBlagajne.NAZIVVRSTEDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BLGBROJDOKUMENTA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableBLAGAJNAStavkeBlagajne.BLGBROJDOKUMENTAColumn]);
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajne.BLGBROJDOKUMENTAColumn] = value;
                }
            }

            public DateTime BLGDATUMDOKUMENTA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableBLAGAJNAStavkeBlagajne.BLGDATUMDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BLGDATUMDOKUMENTA because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajne.BLGDATUMDOKUMENTAColumn] = value;
                }
            }

            public int BLGDOKIDDOKUMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableBLAGAJNAStavkeBlagajne.BLGDOKIDDOKUMENTColumn]);
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajne.BLGDOKIDDOKUMENTColumn] = value;
                }
            }

            public short blggodineIDGODINE
            {
                get
                {
                    return Conversions.ToShort(this[this.tableBLAGAJNAStavkeBlagajne.blggodineIDGODINEColumn]);
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajne.blggodineIDGODINEColumn] = value;
                }
            }

            public decimal BLGIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableBLAGAJNAStavkeBlagajne.BLGIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BLGIZNOS because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajne.BLGIZNOSColumn] = value;
                }
            }

            public string BLGSVRHA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBLAGAJNAStavkeBlagajne.BLGSVRHAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BLGSVRHA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajne.BLGSVRHAColumn] = value;
                }
            }

            public int IDBLGVRSTEDOK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableBLAGAJNAStavkeBlagajne.IDBLGVRSTEDOKColumn]);
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajne.IDBLGVRSTEDOKColumn] = value;
                }
            }

            public string NAZIVVRSTEDOK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBLAGAJNAStavkeBlagajne.NAZIVVRSTEDOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVVRSTEDOK because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajne.NAZIVVRSTEDOKColumn] = value;
                }
            }
        }

        public class BLAGAJNAStavkeBlagajneRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow eventRow;

            public BLAGAJNAStavkeBlagajneRowChangeEvent(BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow row, DataRowAction action)
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

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void BLAGAJNAStavkeBlagajneRowChangeEventHandler(object sender, BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRowChangeEvent e);

        [Serializable]
        public class BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBLGBROJDOKUMENTA;
            private DataColumn columnBLGDOKIDDOKUMENT;
            private DataColumn columnblggodineIDGODINE;
            private DataColumn columnBLGIZNOSKONTIRANJA;
            private DataColumn columnBLGMTIDMJESTOTROSKA;
            private DataColumn columnBLGMTNAZIVMJESTOTROSKA;
            private DataColumn columnBLGORGJEDIDORGJED;
            private DataColumn columnBLGORGJEDNAZIVORGJED;
            private DataColumn columnBLGSTAVKEBLAGAJNEKONTOIDKONTO;
            private DataColumn columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO;
            private DataColumn columnIDBLGVRSTEDOK;

            public event BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEventHandler BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChanged;

            public event BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEventHandler BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChanging;

            public event BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEventHandler BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowDeleted;

            public event BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEventHandler BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowDeleting;

            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable()
            {
                this.TableName = "BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable(DataTable table) : base(table.TableName)
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

            protected BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow(BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow row)
            {
                this.Rows.Add(row);
            }

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow AddBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow(int bLGDOKIDDOKUMENT, int iDBLGVRSTEDOK, short blggodineIDGODINE, int bLGBROJDOKUMENTA, string bLGSTAVKEBLAGAJNEKONTOIDKONTO, int bLGMTIDMJESTOTROSKA, int bLGORGJEDIDORGJED, decimal bLGIZNOSKONTIRANJA)
            {
                BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow row = (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow) this.NewRow();
                row["BLGDOKIDDOKUMENT"] = bLGDOKIDDOKUMENT;
                row["IDBLGVRSTEDOK"] = iDBLGVRSTEDOK;
                row["blggodineIDGODINE"] = blggodineIDGODINE;
                row["BLGBROJDOKUMENTA"] = bLGBROJDOKUMENTA;
                row["BLGSTAVKEBLAGAJNEKONTOIDKONTO"] = bLGSTAVKEBLAGAJNEKONTOIDKONTO;
                row["BLGMTIDMJESTOTROSKA"] = bLGMTIDMJESTOTROSKA;
                row["BLGORGJEDIDORGJED"] = bLGORGJEDIDORGJED;
                row["BLGIZNOSKONTIRANJA"] = bLGIZNOSKONTIRANJA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable table = (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow FindByBLGDOKIDDOKUMENTIDBLGVRSTEDOKblggodineIDGODINEBLGBROJDOKUMENTABLGSTAVKEBLAGAJNEKONTOIDKONTO(int bLGDOKIDDOKUMENT, int iDBLGVRSTEDOK, short blggodineIDGODINE, int bLGBROJDOKUMENTA, string bLGSTAVKEBLAGAJNEKONTOIDKONTO)
            {
                return (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow) this.Rows.Find(new object[] { bLGDOKIDDOKUMENT, iDBLGVRSTEDOK, blggodineIDGODINE, bLGBROJDOKUMENTA, bLGSTAVKEBLAGAJNEKONTOIDKONTO });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                BLAGAJNADataSet set = new BLAGAJNADataSet();
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
                this.columnBLGDOKIDDOKUMENT = new DataColumn("BLGDOKIDDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnBLGDOKIDDOKUMENT.AllowDBNull = false;
                this.columnBLGDOKIDDOKUMENT.Caption = "IDDOKUMENT";
                this.columnBLGDOKIDDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("SuperType", "IDDOKUMENT");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("SubtypeGroup", "BLGDOK");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Description", "Šifra dok. blagajne");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Length", "8");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGDOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "BLGDOKIDDOKUMENT");
                this.Columns.Add(this.columnBLGDOKIDDOKUMENT);
                this.columnIDBLGVRSTEDOK = new DataColumn("IDBLGVRSTEDOK", typeof(int), "", MappingType.Element);
                this.columnIDBLGVRSTEDOK.AllowDBNull = false;
                this.columnIDBLGVRSTEDOK.Caption = "IDBLGVRSTEDOK";
                this.columnIDBLGVRSTEDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Description", "Šifra vrste dok.");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Length", "5");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.InternalName", "IDBLGVRSTEDOK");
                this.Columns.Add(this.columnIDBLGVRSTEDOK);
                this.columnblggodineIDGODINE = new DataColumn("blggodineIDGODINE", typeof(short), "", MappingType.Element);
                this.columnblggodineIDGODINE.AllowDBNull = false;
                this.columnblggodineIDGODINE.Caption = "IDGODINE";
                this.columnblggodineIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("SuperType", "IDGODINE");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("SubtypeGroup", "blggodine");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("IsKey", "true");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Description", "Godina");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnblggodineIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "blggodineIDGODINE");
                this.Columns.Add(this.columnblggodineIDGODINE);
                this.columnBLGBROJDOKUMENTA = new DataColumn("BLGBROJDOKUMENTA", typeof(int), "", MappingType.Element);
                this.columnBLGBROJDOKUMENTA.AllowDBNull = false;
                this.columnBLGBROJDOKUMENTA.Caption = "BLGBROJDOKUMENTA";
                this.columnBLGBROJDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("IsKey", "true");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Description", "Broj dokumenta");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Length", "8");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "BLGBROJDOKUMENTA");
                this.Columns.Add(this.columnBLGBROJDOKUMENTA);
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO = new DataColumn("BLGSTAVKEBLAGAJNEKONTOIDKONTO", typeof(string), "", MappingType.Element);
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.AllowDBNull = false;
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.Caption = "Konto";
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.MaxLength = 14;
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("SubtypeGroup", "BLGSTAVKEBLAGAJNEKONTO");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("IsKey", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "BLGSTAVKEBLAGAJNEKONTOIDKONTO");
                this.Columns.Add(this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO);
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO = new DataColumn("BLGSTAVKEBLAGAJNEKONTONAZIVKONTO", typeof(string), "", MappingType.Element);
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.AllowDBNull = true;
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.Caption = "Naziv konta";
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.MaxLength = 150;
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("SuperType", "NAZIVKONTO");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("SubtypeGroup", "BLGSTAVKEBLAGAJNEKONTO");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("Description", "Naziv konta");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("Length", "150");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO.ExtendedProperties.Add("Deklarit.InternalName", "BLGSTAVKEBLAGAJNEKONTONAZIVKONTO");
                this.Columns.Add(this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO);
                this.columnBLGMTIDMJESTOTROSKA = new DataColumn("BLGMTIDMJESTOTROSKA", typeof(int), "", MappingType.Element);
                this.columnBLGMTIDMJESTOTROSKA.AllowDBNull = false;
                this.columnBLGMTIDMJESTOTROSKA.Caption = "Šifra MT";
                this.columnBLGMTIDMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("SuperType", "IDMJESTOTROSKA");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("SubtypeGroup", "BLGMT");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Description", "Šifra MT");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Length", "8");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "BLGMTIDMJESTOTROSKA");
                this.Columns.Add(this.columnBLGMTIDMJESTOTROSKA);
                this.columnBLGMTNAZIVMJESTOTROSKA = new DataColumn("BLGMTNAZIVMJESTOTROSKA", typeof(string), "", MappingType.Element);
                this.columnBLGMTNAZIVMJESTOTROSKA.AllowDBNull = true;
                this.columnBLGMTNAZIVMJESTOTROSKA.Caption = "Naziv MT";
                this.columnBLGMTNAZIVMJESTOTROSKA.MaxLength = 120;
                this.columnBLGMTNAZIVMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("SuperType", "NAZIVMJESTOTROSKA");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("SubtypeGroup", "BLGMT");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("Description", "Naziv MT");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("Length", "120");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("RightTrim", "true");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGMTNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "BLGMTNAZIVMJESTOTROSKA");
                this.Columns.Add(this.columnBLGMTNAZIVMJESTOTROSKA);
                this.columnBLGORGJEDIDORGJED = new DataColumn("BLGORGJEDIDORGJED", typeof(int), "", MappingType.Element);
                this.columnBLGORGJEDIDORGJED.AllowDBNull = false;
                this.columnBLGORGJEDIDORGJED.Caption = "Šifra OJ";
                this.columnBLGORGJEDIDORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("SuperType", "IDORGJED");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("SubtypeGroup", "BLGORGJED");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Description", "Šifra OJ");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Length", "8");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.InternalName", "BLGORGJEDIDORGJED");
                this.Columns.Add(this.columnBLGORGJEDIDORGJED);
                this.columnBLGORGJEDNAZIVORGJED = new DataColumn("BLGORGJEDNAZIVORGJED", typeof(string), "", MappingType.Element);
                this.columnBLGORGJEDNAZIVORGJED.AllowDBNull = true;
                this.columnBLGORGJEDNAZIVORGJED.Caption = "Naziv OJ";
                this.columnBLGORGJEDNAZIVORGJED.MaxLength = 100;
                this.columnBLGORGJEDNAZIVORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("SuperType", "NAZIVORGJED");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("SubtypeGroup", "BLGORGJED");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("Description", "Naziv OJ");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("Length", "100");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("RightTrim", "true");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGORGJEDNAZIVORGJED.ExtendedProperties.Add("Deklarit.InternalName", "BLGORGJEDNAZIVORGJED");
                this.Columns.Add(this.columnBLGORGJEDNAZIVORGJED);
                this.columnBLGIZNOSKONTIRANJA = new DataColumn("BLGIZNOSKONTIRANJA", typeof(decimal), "", MappingType.Element);
                this.columnBLGIZNOSKONTIRANJA.AllowDBNull = false;
                this.columnBLGIZNOSKONTIRANJA.Caption = "BLGIZNOSKONTIRANJA";
                this.columnBLGIZNOSKONTIRANJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("Description", "Iznos kontiranja");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("Length", "12");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("Decimals", "2");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGIZNOSKONTIRANJA.ExtendedProperties.Add("Deklarit.InternalName", "BLGIZNOSKONTIRANJA");
                this.Columns.Add(this.columnBLGIZNOSKONTIRANJA);
                this.PrimaryKey = new DataColumn[] { this.columnBLGDOKIDDOKUMENT, this.columnIDBLGVRSTEDOK, this.columnblggodineIDGODINE, this.columnBLGBROJDOKUMENTA, this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO };
                this.ExtendedProperties.Add("ParentLvl", "BLAGAJNAStavkeBlagajne");
                this.ExtendedProperties.Add("LevelName", "StavkeBlagajneKontiranje");
                this.ExtendedProperties.Add("Description", "StavkeBlagajneKontiranje");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnBLGDOKIDDOKUMENT = this.Columns["BLGDOKIDDOKUMENT"];
                this.columnIDBLGVRSTEDOK = this.Columns["IDBLGVRSTEDOK"];
                this.columnblggodineIDGODINE = this.Columns["blggodineIDGODINE"];
                this.columnBLGBROJDOKUMENTA = this.Columns["BLGBROJDOKUMENTA"];
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO = this.Columns["BLGSTAVKEBLAGAJNEKONTOIDKONTO"];
                this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO = this.Columns["BLGSTAVKEBLAGAJNEKONTONAZIVKONTO"];
                this.columnBLGMTIDMJESTOTROSKA = this.Columns["BLGMTIDMJESTOTROSKA"];
                this.columnBLGMTNAZIVMJESTOTROSKA = this.Columns["BLGMTNAZIVMJESTOTROSKA"];
                this.columnBLGORGJEDIDORGJED = this.Columns["BLGORGJEDIDORGJED"];
                this.columnBLGORGJEDNAZIVORGJED = this.Columns["BLGORGJEDNAZIVORGJED"];
                this.columnBLGIZNOSKONTIRANJA = this.Columns["BLGIZNOSKONTIRANJA"];
            }

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow NewBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow()
            {
                return (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChanged != null)
                {
                    BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEventHandler bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangedEvent = this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChanged;
                    if (bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangedEvent != null)
                    {
                        bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangedEvent(this, new BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEvent((BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChanging != null)
                {
                    BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEventHandler bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangingEvent = this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChanging;
                    if (bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangingEvent != null)
                    {
                        bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangingEvent(this, new BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEvent((BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowDeleted != null)
                {
                    BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEventHandler bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowDeletedEvent = this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowDeleted;
                    if (bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowDeletedEvent != null)
                    {
                        bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowDeletedEvent(this, new BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEvent((BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowDeleting != null)
                {
                    BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEventHandler bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowDeletingEvent = this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowDeleting;
                    if (bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowDeletingEvent != null)
                    {
                        bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowDeletingEvent(this, new BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEvent((BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow(BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BLGBROJDOKUMENTAColumn
            {
                get
                {
                    return this.columnBLGBROJDOKUMENTA;
                }
            }

            public DataColumn BLGDOKIDDOKUMENTColumn
            {
                get
                {
                    return this.columnBLGDOKIDDOKUMENT;
                }
            }

            public DataColumn blggodineIDGODINEColumn
            {
                get
                {
                    return this.columnblggodineIDGODINE;
                }
            }

            public DataColumn BLGIZNOSKONTIRANJAColumn
            {
                get
                {
                    return this.columnBLGIZNOSKONTIRANJA;
                }
            }

            public DataColumn BLGMTIDMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnBLGMTIDMJESTOTROSKA;
                }
            }

            public DataColumn BLGMTNAZIVMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnBLGMTNAZIVMJESTOTROSKA;
                }
            }

            public DataColumn BLGORGJEDIDORGJEDColumn
            {
                get
                {
                    return this.columnBLGORGJEDIDORGJED;
                }
            }

            public DataColumn BLGORGJEDNAZIVORGJEDColumn
            {
                get
                {
                    return this.columnBLGORGJEDNAZIVORGJED;
                }
            }

            public DataColumn BLGSTAVKEBLAGAJNEKONTOIDKONTOColumn
            {
                get
                {
                    return this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO;
                }
            }

            public DataColumn BLGSTAVKEBLAGAJNEKONTONAZIVKONTOColumn
            {
                get
                {
                    return this.columnBLGSTAVKEBLAGAJNEKONTONAZIVKONTO;
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

            public DataColumn IDBLGVRSTEDOKColumn
            {
                get
                {
                    return this.columnIDBLGVRSTEDOK;
                }
            }

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow this[int index]
            {
                get
                {
                    return (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow) this.Rows[index];
                }
            }
        }

        public class BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow : DataRow
        {
            private BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje;

            internal BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow(DataRowBuilder rb) : base(rb)
            {
                this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje = (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataTable) this.Table;
            }

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow GetBLAGAJNAStavkeBlagajneRow()
            {
                return (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) this.GetParentRow("BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje");
            }

            public bool IsBLGBROJDOKUMENTANull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGBROJDOKUMENTAColumn);
            }

            public bool IsBLGDOKIDDOKUMENTNull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGDOKIDDOKUMENTColumn);
            }

            public bool IsblggodineIDGODINENull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.blggodineIDGODINEColumn);
            }

            public bool IsBLGIZNOSKONTIRANJANull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGIZNOSKONTIRANJAColumn);
            }

            public bool IsBLGMTIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGMTIDMJESTOTROSKAColumn);
            }

            public bool IsBLGMTNAZIVMJESTOTROSKANull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGMTNAZIVMJESTOTROSKAColumn);
            }

            public bool IsBLGORGJEDIDORGJEDNull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGORGJEDIDORGJEDColumn);
            }

            public bool IsBLGORGJEDNAZIVORGJEDNull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGORGJEDNAZIVORGJEDColumn);
            }

            public bool IsBLGSTAVKEBLAGAJNEKONTOIDKONTONull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGSTAVKEBLAGAJNEKONTOIDKONTOColumn);
            }

            public bool IsBLGSTAVKEBLAGAJNEKONTONAZIVKONTONull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGSTAVKEBLAGAJNEKONTONAZIVKONTOColumn);
            }

            public bool IsIDBLGVRSTEDOKNull()
            {
                return this.IsNull(this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.IDBLGVRSTEDOKColumn);
            }

            public void SetBLGIZNOSKONTIRANJANull()
            {
                this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGIZNOSKONTIRANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBLGMTIDMJESTOTROSKANull()
            {
                this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGMTIDMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBLGMTNAZIVMJESTOTROSKANull()
            {
                this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGMTNAZIVMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBLGORGJEDIDORGJEDNull()
            {
                this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGORGJEDIDORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBLGORGJEDNAZIVORGJEDNull()
            {
                this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGORGJEDNAZIVORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBLGSTAVKEBLAGAJNEKONTONAZIVKONTONull()
            {
                this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGSTAVKEBLAGAJNEKONTONAZIVKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BLGBROJDOKUMENTA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGBROJDOKUMENTAColumn]);
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGBROJDOKUMENTAColumn] = value;
                }
            }

            public int BLGDOKIDDOKUMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGDOKIDDOKUMENTColumn]);
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGDOKIDDOKUMENTColumn] = value;
                }
            }

            public short blggodineIDGODINE
            {
                get
                {
                    return Conversions.ToShort(this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.blggodineIDGODINEColumn]);
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.blggodineIDGODINEColumn] = value;
                }
            }

            public decimal BLGIZNOSKONTIRANJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGIZNOSKONTIRANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGIZNOSKONTIRANJAColumn] = value;
                }
            }

            public int BLGMTIDMJESTOTROSKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGMTIDMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGMTIDMJESTOTROSKAColumn] = value;
                }
            }

            public string BLGMTNAZIVMJESTOTROSKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGMTNAZIVMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGMTNAZIVMJESTOTROSKAColumn] = value;
                }
            }

            public int BLGORGJEDIDORGJED
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGORGJEDIDORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGORGJEDIDORGJEDColumn] = value;
                }
            }

            public string BLGORGJEDNAZIVORGJED
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGORGJEDNAZIVORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGORGJEDNAZIVORGJEDColumn] = value;
                }
            }

            public string BLGSTAVKEBLAGAJNEKONTOIDKONTO
            {
                get
                {
                    return Conversions.ToString(this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGSTAVKEBLAGAJNEKONTOIDKONTOColumn]);
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGSTAVKEBLAGAJNEKONTOIDKONTOColumn] = value;
                }
            }

            public string BLGSTAVKEBLAGAJNEKONTONAZIVKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGSTAVKEBLAGAJNEKONTONAZIVKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGSTAVKEBLAGAJNEKONTONAZIVKONTOColumn] = value;
                }
            }

            public int IDBLGVRSTEDOK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.IDBLGVRSTEDOKColumn]);
                }
                set
                {
                    this[this.tableBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.IDBLGVRSTEDOKColumn] = value;
                }
            }
        }

        public class BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow eventRow;

            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEvent(BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow row, DataRowAction action)
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

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEventHandler(object sender, BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRowChangeEvent e);
    }
}

