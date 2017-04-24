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
    public class KRIZNIPOREZDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private KRIZNIPOREZDataTable tableKRIZNIPOREZ;

        public KRIZNIPOREZDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected KRIZNIPOREZDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["KRIZNIPOREZ"] != null)
                    {
                        this.Tables.Add(new KRIZNIPOREZDataTable(dataSet.Tables["KRIZNIPOREZ"]));
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
            KRIZNIPOREZDataSet set = (KRIZNIPOREZDataSet) base.Clone();
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
            KRIZNIPOREZDataSet set = new KRIZNIPOREZDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "KRIZNIPOREZDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2076");
            this.ExtendedProperties.Add("DataSetName", "KRIZNIPOREZDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IKRIZNIPOREZDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "KRIZNIPOREZ");
            this.ExtendedProperties.Add("ObjectDescription", "KRIZNIPOREZ");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
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
            this.DataSetName = "KRIZNIPOREZDataSet";
            this.Namespace = "http://www.tempuri.org/KRIZNIPOREZ";
            this.tableKRIZNIPOREZ = new KRIZNIPOREZDataTable();
            this.Tables.Add(this.tableKRIZNIPOREZ);
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
            this.tableKRIZNIPOREZ = (KRIZNIPOREZDataTable) this.Tables["KRIZNIPOREZ"];
            if (initTable && (this.tableKRIZNIPOREZ != null))
            {
                this.tableKRIZNIPOREZ.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["KRIZNIPOREZ"] != null)
                {
                    this.Tables.Add(new KRIZNIPOREZDataTable(dataSet.Tables["KRIZNIPOREZ"]));
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

        private bool ShouldSerializeKRIZNIPOREZ()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KRIZNIPOREZDataTable KRIZNIPOREZ
        {
            get
            {
                return this.tableKRIZNIPOREZ;
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
        public class KRIZNIPOREZDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDKRIZNIPOREZ;
            private DataColumn columnKRIZNIDO;
            private DataColumn columnKRIZNIOD;
            private DataColumn columnKRIZNISTOPA;
            private DataColumn columnMOKRIZNI;
            private DataColumn columnMZKRIZNI;
            private DataColumn columnNAZIVKRIZNIPOREZ;
            private DataColumn columnOPISPLACANJAKRIZNI;
            private DataColumn columnPOKRIZNI;
            private DataColumn columnPRIMATELJKRIZNI1;
            private DataColumn columnPRIMATELJKRIZNI2;
            private DataColumn columnPRIMATELJKRIZNI3;
            private DataColumn columnPZKRIZNI;
            private DataColumn columnSIFRAOPISAPLACANJAKRIZNI;
            private DataColumn columnVBDIKRIZNI;
            private DataColumn columnZRNKRIZNI;

            public event KRIZNIPOREZDataSet.KRIZNIPOREZRowChangeEventHandler KRIZNIPOREZRowChanged;

            public event KRIZNIPOREZDataSet.KRIZNIPOREZRowChangeEventHandler KRIZNIPOREZRowChanging;

            public event KRIZNIPOREZDataSet.KRIZNIPOREZRowChangeEventHandler KRIZNIPOREZRowDeleted;

            public event KRIZNIPOREZDataSet.KRIZNIPOREZRowChangeEventHandler KRIZNIPOREZRowDeleting;

            public KRIZNIPOREZDataTable()
            {
                this.TableName = "KRIZNIPOREZ";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal KRIZNIPOREZDataTable(DataTable table) : base(table.TableName)
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

            protected KRIZNIPOREZDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddKRIZNIPOREZRow(KRIZNIPOREZDataSet.KRIZNIPOREZRow row)
            {
                this.Rows.Add(row);
            }

            public KRIZNIPOREZDataSet.KRIZNIPOREZRow AddKRIZNIPOREZRow(int iDKRIZNIPOREZ, string nAZIVKRIZNIPOREZ, decimal kRIZNISTOPA, decimal kRIZNIOD, decimal kRIZNIDO, string mOKRIZNI, string pOKRIZNI, string mZKRIZNI, string pZKRIZNI, string pRIMATELJKRIZNI1, string pRIMATELJKRIZNI2, string pRIMATELJKRIZNI3, string sIFRAOPISAPLACANJAKRIZNI, string oPISPLACANJAKRIZNI, string vBDIKRIZNI, string zRNKRIZNI)
            {
                KRIZNIPOREZDataSet.KRIZNIPOREZRow row = (KRIZNIPOREZDataSet.KRIZNIPOREZRow) this.NewRow();
                row["IDKRIZNIPOREZ"] = iDKRIZNIPOREZ;
                row["NAZIVKRIZNIPOREZ"] = nAZIVKRIZNIPOREZ;
                row["KRIZNISTOPA"] = kRIZNISTOPA;
                row["KRIZNIOD"] = kRIZNIOD;
                row["KRIZNIDO"] = kRIZNIDO;
                row["MOKRIZNI"] = mOKRIZNI;
                row["POKRIZNI"] = pOKRIZNI;
                row["MZKRIZNI"] = mZKRIZNI;
                row["PZKRIZNI"] = pZKRIZNI;
                row["PRIMATELJKRIZNI1"] = pRIMATELJKRIZNI1;
                row["PRIMATELJKRIZNI2"] = pRIMATELJKRIZNI2;
                row["PRIMATELJKRIZNI3"] = pRIMATELJKRIZNI3;
                row["SIFRAOPISAPLACANJAKRIZNI"] = sIFRAOPISAPLACANJAKRIZNI;
                row["OPISPLACANJAKRIZNI"] = oPISPLACANJAKRIZNI;
                row["VBDIKRIZNI"] = vBDIKRIZNI;
                row["ZRNKRIZNI"] = zRNKRIZNI;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                KRIZNIPOREZDataSet.KRIZNIPOREZDataTable table = (KRIZNIPOREZDataSet.KRIZNIPOREZDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public KRIZNIPOREZDataSet.KRIZNIPOREZRow FindByIDKRIZNIPOREZ(int iDKRIZNIPOREZ)
            {
                return (KRIZNIPOREZDataSet.KRIZNIPOREZRow) this.Rows.Find(new object[] { iDKRIZNIPOREZ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(KRIZNIPOREZDataSet.KRIZNIPOREZRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                KRIZNIPOREZDataSet set = new KRIZNIPOREZDataSet();
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
                this.columnIDKRIZNIPOREZ = new DataColumn("IDKRIZNIPOREZ", typeof(int), "", MappingType.Element);
                this.columnIDKRIZNIPOREZ.AllowDBNull = false;
                this.columnIDKRIZNIPOREZ.Caption = "IDKRIZNIPOREZ";
                this.columnIDKRIZNIPOREZ.Unique = true;
                this.columnIDKRIZNIPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("IsKey", "true");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Description", "IDKRIZNIPOREZ");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Length", "5");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "IDKRIZNIPOREZ");
                this.Columns.Add(this.columnIDKRIZNIPOREZ);
                this.columnNAZIVKRIZNIPOREZ = new DataColumn("NAZIVKRIZNIPOREZ", typeof(string), "", MappingType.Element);
                this.columnNAZIVKRIZNIPOREZ.AllowDBNull = false;
                this.columnNAZIVKRIZNIPOREZ.Caption = "NAZIVKRIZNIPOREZ";
                this.columnNAZIVKRIZNIPOREZ.MaxLength = 50;
                this.columnNAZIVKRIZNIPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Description", "Naziv");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKRIZNIPOREZ");
                this.Columns.Add(this.columnNAZIVKRIZNIPOREZ);
                this.columnKRIZNISTOPA = new DataColumn("KRIZNISTOPA", typeof(decimal), "", MappingType.Element);
                this.columnKRIZNISTOPA.AllowDBNull = false;
                this.columnKRIZNISTOPA.Caption = "KRIZNISTOPA";
                this.columnKRIZNISTOPA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Description", "Stopa");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Length", "5");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("IsInReader", "true");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.InternalName", "KRIZNISTOPA");
                this.Columns.Add(this.columnKRIZNISTOPA);
                this.columnKRIZNIOD = new DataColumn("KRIZNIOD", typeof(decimal), "", MappingType.Element);
                this.columnKRIZNIOD.AllowDBNull = false;
                this.columnKRIZNIOD.Caption = "KRIZNIOD";
                this.columnKRIZNIOD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKRIZNIOD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKRIZNIOD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKRIZNIOD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKRIZNIOD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKRIZNIOD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKRIZNIOD.ExtendedProperties.Add("IsKey", "false");
                this.columnKRIZNIOD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKRIZNIOD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKRIZNIOD.ExtendedProperties.Add("Description", "Od iznosa");
                this.columnKRIZNIOD.ExtendedProperties.Add("Length", "12");
                this.columnKRIZNIOD.ExtendedProperties.Add("Decimals", "2");
                this.columnKRIZNIOD.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKRIZNIOD.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKRIZNIOD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKRIZNIOD.ExtendedProperties.Add("IsInReader", "true");
                this.columnKRIZNIOD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKRIZNIOD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKRIZNIOD.ExtendedProperties.Add("Deklarit.InternalName", "KRIZNIOD");
                this.Columns.Add(this.columnKRIZNIOD);
                this.columnKRIZNIDO = new DataColumn("KRIZNIDO", typeof(decimal), "", MappingType.Element);
                this.columnKRIZNIDO.AllowDBNull = false;
                this.columnKRIZNIDO.Caption = "KRIZNIDO";
                this.columnKRIZNIDO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKRIZNIDO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKRIZNIDO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKRIZNIDO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKRIZNIDO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKRIZNIDO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKRIZNIDO.ExtendedProperties.Add("IsKey", "false");
                this.columnKRIZNIDO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKRIZNIDO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKRIZNIDO.ExtendedProperties.Add("Description", "Do iznosa");
                this.columnKRIZNIDO.ExtendedProperties.Add("Length", "12");
                this.columnKRIZNIDO.ExtendedProperties.Add("Decimals", "2");
                this.columnKRIZNIDO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKRIZNIDO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKRIZNIDO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKRIZNIDO.ExtendedProperties.Add("IsInReader", "true");
                this.columnKRIZNIDO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKRIZNIDO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKRIZNIDO.ExtendedProperties.Add("Deklarit.InternalName", "KRIZNIDO");
                this.Columns.Add(this.columnKRIZNIDO);
                this.columnMOKRIZNI = new DataColumn("MOKRIZNI", typeof(string), "", MappingType.Element);
                this.columnMOKRIZNI.AllowDBNull = false;
                this.columnMOKRIZNI.Caption = "MOKRIZNI";
                this.columnMOKRIZNI.MaxLength = 2;
                this.columnMOKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnMOKRIZNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMOKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOKRIZNI.ExtendedProperties.Add("Description", "Model odobrenja");
                this.columnMOKRIZNI.ExtendedProperties.Add("Length", "2");
                this.columnMOKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnMOKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMOKRIZNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "MOKRIZNI");
                this.Columns.Add(this.columnMOKRIZNI);
                this.columnPOKRIZNI = new DataColumn("POKRIZNI", typeof(string), "", MappingType.Element);
                this.columnPOKRIZNI.AllowDBNull = false;
                this.columnPOKRIZNI.Caption = "POKRIZNI";
                this.columnPOKRIZNI.MaxLength = 0x16;
                this.columnPOKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnPOKRIZNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOKRIZNI.ExtendedProperties.Add("Description", "Poziv na broj odobrenja");
                this.columnPOKRIZNI.ExtendedProperties.Add("Length", "22");
                this.columnPOKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnPOKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOKRIZNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "POKRIZNI");
                this.Columns.Add(this.columnPOKRIZNI);
                this.columnMZKRIZNI = new DataColumn("MZKRIZNI", typeof(string), "", MappingType.Element);
                this.columnMZKRIZNI.AllowDBNull = true;
                this.columnMZKRIZNI.Caption = "MZKRIZNI";
                this.columnMZKRIZNI.MaxLength = 2;
                this.columnMZKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnMZKRIZNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMZKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZKRIZNI.ExtendedProperties.Add("Description", "Model zaduženja");
                this.columnMZKRIZNI.ExtendedProperties.Add("Length", "2");
                this.columnMZKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnMZKRIZNI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZKRIZNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "MZKRIZNI");
                this.Columns.Add(this.columnMZKRIZNI);
                this.columnPZKRIZNI = new DataColumn("PZKRIZNI", typeof(string), "", MappingType.Element);
                this.columnPZKRIZNI.AllowDBNull = true;
                this.columnPZKRIZNI.Caption = "PZKRIZNI";
                this.columnPZKRIZNI.MaxLength = 0x16;
                this.columnPZKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnPZKRIZNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPZKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZKRIZNI.ExtendedProperties.Add("Description", "Poziv na broj zaduženja");
                this.columnPZKRIZNI.ExtendedProperties.Add("Length", "22");
                this.columnPZKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnPZKRIZNI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZKRIZNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "PZKRIZNI");
                this.Columns.Add(this.columnPZKRIZNI);
                this.columnPRIMATELJKRIZNI1 = new DataColumn("PRIMATELJKRIZNI1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKRIZNI1.AllowDBNull = false;
                this.columnPRIMATELJKRIZNI1.Caption = "PRIMATELJKRIZNI";
                this.columnPRIMATELJKRIZNI1.MaxLength = 20;
                this.columnPRIMATELJKRIZNI1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Description", "Primatelj (1)");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKRIZNI1");
                this.Columns.Add(this.columnPRIMATELJKRIZNI1);
                this.columnPRIMATELJKRIZNI2 = new DataColumn("PRIMATELJKRIZNI2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKRIZNI2.AllowDBNull = false;
                this.columnPRIMATELJKRIZNI2.Caption = "PRIMATELJKRIZN I2";
                this.columnPRIMATELJKRIZNI2.MaxLength = 20;
                this.columnPRIMATELJKRIZNI2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Description", "Primatelj (2)");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKRIZNI2");
                this.Columns.Add(this.columnPRIMATELJKRIZNI2);
                this.columnPRIMATELJKRIZNI3 = new DataColumn("PRIMATELJKRIZNI3", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKRIZNI3.AllowDBNull = false;
                this.columnPRIMATELJKRIZNI3.Caption = "PRIMATELJKRIZN I3";
                this.columnPRIMATELJKRIZNI3.MaxLength = 20;
                this.columnPRIMATELJKRIZNI3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Description", "Primatelj (3)");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKRIZNI3");
                this.Columns.Add(this.columnPRIMATELJKRIZNI3);
                this.columnSIFRAOPISAPLACANJAKRIZNI = new DataColumn("SIFRAOPISAPLACANJAKRIZNI", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAKRIZNI.AllowDBNull = false;
                this.columnSIFRAOPISAPLACANJAKRIZNI.Caption = "SIFRAOPISAPLACANJAKRIZNI";
                this.columnSIFRAOPISAPLACANJAKRIZNI.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Description", "Šifra opisa plaćanja");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAKRIZNI");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAKRIZNI);
                this.columnOPISPLACANJAKRIZNI = new DataColumn("OPISPLACANJAKRIZNI", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAKRIZNI.AllowDBNull = false;
                this.columnOPISPLACANJAKRIZNI.Caption = "OPISPLACANJAKRIZNI";
                this.columnOPISPLACANJAKRIZNI.MaxLength = 0x24;
                this.columnOPISPLACANJAKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Description", "Opis plaćanja krizni");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAKRIZNI");
                this.Columns.Add(this.columnOPISPLACANJAKRIZNI);
                this.columnVBDIKRIZNI = new DataColumn("VBDIKRIZNI", typeof(string), "", MappingType.Element);
                this.columnVBDIKRIZNI.AllowDBNull = false;
                this.columnVBDIKRIZNI.Caption = "VBDIKRIZNI";
                this.columnVBDIKRIZNI.MaxLength = 7;
                this.columnVBDIKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Description", "VBDI");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Length", "7");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "VBDIKRIZNI");
                this.Columns.Add(this.columnVBDIKRIZNI);
                this.columnZRNKRIZNI = new DataColumn("ZRNKRIZNI", typeof(string), "", MappingType.Element);
                this.columnZRNKRIZNI.AllowDBNull = false;
                this.columnZRNKRIZNI.Caption = "ZRNKRIZNI";
                this.columnZRNKRIZNI.MaxLength = 10;
                this.columnZRNKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNKRIZNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZRNKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Description", "Žiro račun");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Length", "10");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZRNKRIZNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "ZRNKRIZNI");
                this.Columns.Add(this.columnZRNKRIZNI);
                this.PrimaryKey = new DataColumn[] { this.columnIDKRIZNIPOREZ };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "KRIZNIPOREZ");
                this.ExtendedProperties.Add("Description", "KRIZNIPOREZ");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDKRIZNIPOREZ = this.Columns["IDKRIZNIPOREZ"];
                this.columnNAZIVKRIZNIPOREZ = this.Columns["NAZIVKRIZNIPOREZ"];
                this.columnKRIZNISTOPA = this.Columns["KRIZNISTOPA"];
                this.columnKRIZNIOD = this.Columns["KRIZNIOD"];
                this.columnKRIZNIDO = this.Columns["KRIZNIDO"];
                this.columnMOKRIZNI = this.Columns["MOKRIZNI"];
                this.columnPOKRIZNI = this.Columns["POKRIZNI"];
                this.columnMZKRIZNI = this.Columns["MZKRIZNI"];
                this.columnPZKRIZNI = this.Columns["PZKRIZNI"];
                this.columnPRIMATELJKRIZNI1 = this.Columns["PRIMATELJKRIZNI1"];
                this.columnPRIMATELJKRIZNI2 = this.Columns["PRIMATELJKRIZNI2"];
                this.columnPRIMATELJKRIZNI3 = this.Columns["PRIMATELJKRIZNI3"];
                this.columnSIFRAOPISAPLACANJAKRIZNI = this.Columns["SIFRAOPISAPLACANJAKRIZNI"];
                this.columnOPISPLACANJAKRIZNI = this.Columns["OPISPLACANJAKRIZNI"];
                this.columnVBDIKRIZNI = this.Columns["VBDIKRIZNI"];
                this.columnZRNKRIZNI = this.Columns["ZRNKRIZNI"];
            }

            public KRIZNIPOREZDataSet.KRIZNIPOREZRow NewKRIZNIPOREZRow()
            {
                return (KRIZNIPOREZDataSet.KRIZNIPOREZRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new KRIZNIPOREZDataSet.KRIZNIPOREZRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.KRIZNIPOREZRowChanged != null)
                {
                    KRIZNIPOREZDataSet.KRIZNIPOREZRowChangeEventHandler kRIZNIPOREZRowChangedEvent = this.KRIZNIPOREZRowChanged;
                    if (kRIZNIPOREZRowChangedEvent != null)
                    {
                        kRIZNIPOREZRowChangedEvent(this, new KRIZNIPOREZDataSet.KRIZNIPOREZRowChangeEvent((KRIZNIPOREZDataSet.KRIZNIPOREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.KRIZNIPOREZRowChanging != null)
                {
                    KRIZNIPOREZDataSet.KRIZNIPOREZRowChangeEventHandler kRIZNIPOREZRowChangingEvent = this.KRIZNIPOREZRowChanging;
                    if (kRIZNIPOREZRowChangingEvent != null)
                    {
                        kRIZNIPOREZRowChangingEvent(this, new KRIZNIPOREZDataSet.KRIZNIPOREZRowChangeEvent((KRIZNIPOREZDataSet.KRIZNIPOREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.KRIZNIPOREZRowDeleted != null)
                {
                    KRIZNIPOREZDataSet.KRIZNIPOREZRowChangeEventHandler kRIZNIPOREZRowDeletedEvent = this.KRIZNIPOREZRowDeleted;
                    if (kRIZNIPOREZRowDeletedEvent != null)
                    {
                        kRIZNIPOREZRowDeletedEvent(this, new KRIZNIPOREZDataSet.KRIZNIPOREZRowChangeEvent((KRIZNIPOREZDataSet.KRIZNIPOREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.KRIZNIPOREZRowDeleting != null)
                {
                    KRIZNIPOREZDataSet.KRIZNIPOREZRowChangeEventHandler kRIZNIPOREZRowDeletingEvent = this.KRIZNIPOREZRowDeleting;
                    if (kRIZNIPOREZRowDeletingEvent != null)
                    {
                        kRIZNIPOREZRowDeletingEvent(this, new KRIZNIPOREZDataSet.KRIZNIPOREZRowChangeEvent((KRIZNIPOREZDataSet.KRIZNIPOREZRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveKRIZNIPOREZRow(KRIZNIPOREZDataSet.KRIZNIPOREZRow row)
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

            public DataColumn IDKRIZNIPOREZColumn
            {
                get
                {
                    return this.columnIDKRIZNIPOREZ;
                }
            }

            public KRIZNIPOREZDataSet.KRIZNIPOREZRow this[int index]
            {
                get
                {
                    return (KRIZNIPOREZDataSet.KRIZNIPOREZRow) this.Rows[index];
                }
            }

            public DataColumn KRIZNIDOColumn
            {
                get
                {
                    return this.columnKRIZNIDO;
                }
            }

            public DataColumn KRIZNIODColumn
            {
                get
                {
                    return this.columnKRIZNIOD;
                }
            }

            public DataColumn KRIZNISTOPAColumn
            {
                get
                {
                    return this.columnKRIZNISTOPA;
                }
            }

            public DataColumn MOKRIZNIColumn
            {
                get
                {
                    return this.columnMOKRIZNI;
                }
            }

            public DataColumn MZKRIZNIColumn
            {
                get
                {
                    return this.columnMZKRIZNI;
                }
            }

            public DataColumn NAZIVKRIZNIPOREZColumn
            {
                get
                {
                    return this.columnNAZIVKRIZNIPOREZ;
                }
            }

            public DataColumn OPISPLACANJAKRIZNIColumn
            {
                get
                {
                    return this.columnOPISPLACANJAKRIZNI;
                }
            }

            public DataColumn POKRIZNIColumn
            {
                get
                {
                    return this.columnPOKRIZNI;
                }
            }

            public DataColumn PRIMATELJKRIZNI1Column
            {
                get
                {
                    return this.columnPRIMATELJKRIZNI1;
                }
            }

            public DataColumn PRIMATELJKRIZNI2Column
            {
                get
                {
                    return this.columnPRIMATELJKRIZNI2;
                }
            }

            public DataColumn PRIMATELJKRIZNI3Column
            {
                get
                {
                    return this.columnPRIMATELJKRIZNI3;
                }
            }

            public DataColumn PZKRIZNIColumn
            {
                get
                {
                    return this.columnPZKRIZNI;
                }
            }

            public DataColumn SIFRAOPISAPLACANJAKRIZNIColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJAKRIZNI;
                }
            }

            public DataColumn VBDIKRIZNIColumn
            {
                get
                {
                    return this.columnVBDIKRIZNI;
                }
            }

            public DataColumn ZRNKRIZNIColumn
            {
                get
                {
                    return this.columnZRNKRIZNI;
                }
            }
        }

        public class KRIZNIPOREZRow : DataRow
        {
            private KRIZNIPOREZDataSet.KRIZNIPOREZDataTable tableKRIZNIPOREZ;

            internal KRIZNIPOREZRow(DataRowBuilder rb) : base(rb)
            {
                this.tableKRIZNIPOREZ = (KRIZNIPOREZDataSet.KRIZNIPOREZDataTable) this.Table;
            }

            public bool IsIDKRIZNIPOREZNull()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.IDKRIZNIPOREZColumn);
            }

            public bool IsKRIZNIDONull()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.KRIZNIDOColumn);
            }

            public bool IsKRIZNIODNull()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.KRIZNIODColumn);
            }

            public bool IsKRIZNISTOPANull()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.KRIZNISTOPAColumn);
            }

            public bool IsMOKRIZNINull()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.MOKRIZNIColumn);
            }

            public bool IsMZKRIZNINull()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.MZKRIZNIColumn);
            }

            public bool IsNAZIVKRIZNIPOREZNull()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.NAZIVKRIZNIPOREZColumn);
            }

            public bool IsOPISPLACANJAKRIZNINull()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.OPISPLACANJAKRIZNIColumn);
            }

            public bool IsPOKRIZNINull()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.POKRIZNIColumn);
            }

            public bool IsPRIMATELJKRIZNI1Null()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.PRIMATELJKRIZNI1Column);
            }

            public bool IsPRIMATELJKRIZNI2Null()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.PRIMATELJKRIZNI2Column);
            }

            public bool IsPRIMATELJKRIZNI3Null()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.PRIMATELJKRIZNI3Column);
            }

            public bool IsPZKRIZNINull()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.PZKRIZNIColumn);
            }

            public bool IsSIFRAOPISAPLACANJAKRIZNINull()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.SIFRAOPISAPLACANJAKRIZNIColumn);
            }

            public bool IsVBDIKRIZNINull()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.VBDIKRIZNIColumn);
            }

            public bool IsZRNKRIZNINull()
            {
                return this.IsNull(this.tableKRIZNIPOREZ.ZRNKRIZNIColumn);
            }

            public void SetKRIZNIDONull()
            {
                this[this.tableKRIZNIPOREZ.KRIZNIDOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKRIZNIODNull()
            {
                this[this.tableKRIZNIPOREZ.KRIZNIODColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKRIZNISTOPANull()
            {
                this[this.tableKRIZNIPOREZ.KRIZNISTOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMOKRIZNINull()
            {
                this[this.tableKRIZNIPOREZ.MOKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZKRIZNINull()
            {
                this[this.tableKRIZNIPOREZ.MZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKRIZNIPOREZNull()
            {
                this[this.tableKRIZNIPOREZ.NAZIVKRIZNIPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAKRIZNINull()
            {
                this[this.tableKRIZNIPOREZ.OPISPLACANJAKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOKRIZNINull()
            {
                this[this.tableKRIZNIPOREZ.POKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKRIZNI1Null()
            {
                this[this.tableKRIZNIPOREZ.PRIMATELJKRIZNI1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKRIZNI2Null()
            {
                this[this.tableKRIZNIPOREZ.PRIMATELJKRIZNI2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKRIZNI3Null()
            {
                this[this.tableKRIZNIPOREZ.PRIMATELJKRIZNI3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZKRIZNINull()
            {
                this[this.tableKRIZNIPOREZ.PZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAKRIZNINull()
            {
                this[this.tableKRIZNIPOREZ.SIFRAOPISAPLACANJAKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIKRIZNINull()
            {
                this[this.tableKRIZNIPOREZ.VBDIKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNKRIZNINull()
            {
                this[this.tableKRIZNIPOREZ.ZRNKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDKRIZNIPOREZ
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableKRIZNIPOREZ.IDKRIZNIPOREZColumn]);
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.IDKRIZNIPOREZColumn] = value;
                }
            }

            public decimal KRIZNIDO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableKRIZNIPOREZ.KRIZNIDOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.KRIZNIDOColumn] = value;
                }
            }

            public decimal KRIZNIOD
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableKRIZNIPOREZ.KRIZNIODColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.KRIZNIODColumn] = value;
                }
            }

            public decimal KRIZNISTOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableKRIZNIPOREZ.KRIZNISTOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.KRIZNISTOPAColumn] = value;
                }
            }

            public string MOKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKRIZNIPOREZ.MOKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.MOKRIZNIColumn] = value;
                }
            }

            public string MZKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKRIZNIPOREZ.MZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.MZKRIZNIColumn] = value;
                }
            }

            public string NAZIVKRIZNIPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKRIZNIPOREZ.NAZIVKRIZNIPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.NAZIVKRIZNIPOREZColumn] = value;
                }
            }

            public string OPISPLACANJAKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKRIZNIPOREZ.OPISPLACANJAKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.OPISPLACANJAKRIZNIColumn] = value;
                }
            }

            public string POKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKRIZNIPOREZ.POKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.POKRIZNIColumn] = value;
                }
            }

            public string PRIMATELJKRIZNI1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKRIZNIPOREZ.PRIMATELJKRIZNI1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.PRIMATELJKRIZNI1Column] = value;
                }
            }

            public string PRIMATELJKRIZNI2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKRIZNIPOREZ.PRIMATELJKRIZNI2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.PRIMATELJKRIZNI2Column] = value;
                }
            }

            public string PRIMATELJKRIZNI3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKRIZNIPOREZ.PRIMATELJKRIZNI3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.PRIMATELJKRIZNI3Column] = value;
                }
            }

            public string PZKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKRIZNIPOREZ.PZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.PZKRIZNIColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKRIZNIPOREZ.SIFRAOPISAPLACANJAKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.SIFRAOPISAPLACANJAKRIZNIColumn] = value;
                }
            }

            public string VBDIKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKRIZNIPOREZ.VBDIKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.VBDIKRIZNIColumn] = value;
                }
            }

            public string ZRNKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKRIZNIPOREZ.ZRNKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKRIZNIPOREZ.ZRNKRIZNIColumn] = value;
                }
            }
        }

        public class KRIZNIPOREZRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private KRIZNIPOREZDataSet.KRIZNIPOREZRow eventRow;

            public KRIZNIPOREZRowChangeEvent(KRIZNIPOREZDataSet.KRIZNIPOREZRow row, DataRowAction action)
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

            public KRIZNIPOREZDataSet.KRIZNIPOREZRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void KRIZNIPOREZRowChangeEventHandler(object sender, KRIZNIPOREZDataSet.KRIZNIPOREZRowChangeEvent e);
    }
}

