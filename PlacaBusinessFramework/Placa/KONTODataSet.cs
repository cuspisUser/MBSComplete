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
    public class KONTODataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private KONTODataTable tableKONTO;

        public KONTODataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected KONTODataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["KONTO"] != null)
                    {
                        this.Tables.Add(new KONTODataTable(dataSet.Tables["KONTO"]));
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
            KONTODataSet set = (KONTODataSet) base.Clone();
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
            KONTODataSet set = new KONTODataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "KONTODataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1009");
            this.ExtendedProperties.Add("DataSetName", "KONTODataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IKONTODataAdapter");
            this.ExtendedProperties.Add("ObjectName", "KONTO");
            this.ExtendedProperties.Add("ObjectDescription", "Kontni plan");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Finpos");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "HardlyEver");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "KONT");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "KONTODataSet";
            this.Namespace = "http://www.tempuri.org/KONTO";
            this.tableKONTO = new KONTODataTable();
            this.Tables.Add(this.tableKONTO);
            this.tableKONTO.KONTColumn.Expression = "IDKONTO+' | '+NAZIVKONTO";
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
            this.tableKONTO = (KONTODataTable) this.Tables["KONTO"];
            if (initTable && (this.tableKONTO != null))
            {
                this.tableKONTO.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["KONTO"] != null)
                {
                    this.Tables.Add(new KONTODataTable(dataSet.Tables["KONTO"]));
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

        private bool ShouldSerializeKONTO()
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
        public KONTODataTable KONTO
        {
            get
            {
                return this.tableKONTO;
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
        public class KONTODataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDAKTIVNOST;
            private DataColumn columnIDKONTO;
            private DataColumn columnKONT;
            private DataColumn columnNAZIVAKTIVNOST;
            private DataColumn columnNAZIVKONTO;

            public event KONTODataSet.KONTORowChangeEventHandler KONTORowChanged;

            public event KONTODataSet.KONTORowChangeEventHandler KONTORowChanging;

            public event KONTODataSet.KONTORowChangeEventHandler KONTORowDeleted;

            public event KONTODataSet.KONTORowChangeEventHandler KONTORowDeleting;

            public KONTODataTable()
            {
                this.TableName = "KONTO";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal KONTODataTable(DataTable table) : base(table.TableName)
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

            protected KONTODataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddKONTORow(KONTODataSet.KONTORow row)
            {
                this.Rows.Add(row);
            }

            public KONTODataSet.KONTORow AddKONTORow(string iDKONTO, string nAZIVKONTO, int iDAKTIVNOST)
            {
                KONTODataSet.KONTORow row = (KONTODataSet.KONTORow) this.NewRow();
                row["IDKONTO"] = iDKONTO;
                row["NAZIVKONTO"] = nAZIVKONTO;
                row["IDAKTIVNOST"] = iDAKTIVNOST;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                KONTODataSet.KONTODataTable table = (KONTODataSet.KONTODataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public KONTODataSet.KONTORow FindByIDKONTO(string iDKONTO)
            {
                return (KONTODataSet.KONTORow) this.Rows.Find(new object[] { iDKONTO });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(KONTODataSet.KONTORow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                KONTODataSet set = new KONTODataSet();
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

            //db - 10.1.2017 - povećan MaxLenght za kolone, te postavljeno AllowDBNull = true, jer je dolazilo do pucanja zbog nepoklapanja sa postavkama kolona u bazi. 
            public void InitClass()
            {
                this.columnIDKONTO = new DataColumn("IDKONTO", typeof(string), "", MappingType.Element);
                this.columnIDKONTO.AllowDBNull = true;
                this.columnIDKONTO.Caption = "Konto";
                this.columnIDKONTO.MaxLength = 14;
                this.columnIDKONTO.Unique = true;
                this.columnIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKONTO.ExtendedProperties.Add("IsKey", "true");
                this.columnIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnIDKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "IDKONTO");
                this.Columns.Add(this.columnIDKONTO);

                this.columnNAZIVKONTO = new DataColumn("NAZIVKONTO", typeof(string), "", MappingType.Element);
                this.columnNAZIVKONTO.AllowDBNull = true;
                this.columnNAZIVKONTO.Caption = "Naziv konta";
                this.columnNAZIVKONTO.MaxLength = 250;
                this.columnNAZIVKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Description", "Naziv konta");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Length", "250");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKONTO");
                this.Columns.Add(this.columnNAZIVKONTO);

                this.columnIDAKTIVNOST = new DataColumn("IDAKTIVNOST", typeof(int), "", MappingType.Element);
                this.columnIDAKTIVNOST.AllowDBNull = true;
                this.columnIDAKTIVNOST.Caption = "Šifra aktivnosti";
                this.columnIDAKTIVNOST.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("IsKey", "false");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Description", "Šifra aktivnosti");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Length", "6");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Decimals", "0");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.InternalName", "IDAKTIVNOST");
                this.Columns.Add(this.columnIDAKTIVNOST);

                this.columnNAZIVAKTIVNOST = new DataColumn("NAZIVAKTIVNOST", typeof(string), "", MappingType.Element);
                this.columnNAZIVAKTIVNOST.AllowDBNull = true;
                this.columnNAZIVAKTIVNOST.Caption = "Naziv aktivnosti";
                this.columnNAZIVAKTIVNOST.MaxLength = 100;
                this.columnNAZIVAKTIVNOST.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Description", "Naziv aktivnosti");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVAKTIVNOST");
                this.Columns.Add(this.columnNAZIVAKTIVNOST);

                this.columnKONT = new DataColumn("KONT", typeof(string), "", MappingType.Element);
                this.columnKONT.AllowDBNull = true;
                this.columnKONT.Caption = "KONT";
                //this.columnKONT.MaxLength = 0xa7;
                this.columnKONT.MaxLength = 200;
                this.columnKONT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKONT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKONT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKONT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKONT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKONT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKONT.ExtendedProperties.Add("IsKey", "false");
                this.columnKONT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKONT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKONT.ExtendedProperties.Add("Description", "KONT");
                this.columnKONT.ExtendedProperties.Add("Length", "200");
                this.columnKONT.ExtendedProperties.Add("Decimals", "0");
                this.columnKONT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKONT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKONT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKONT.ExtendedProperties.Add("Deklarit.InternalName", "KONT");
                this.columnKONT.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnKONT);

                this.PrimaryKey = new DataColumn[] { this.columnIDKONTO };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "KONTO");
                this.ExtendedProperties.Add("Description", "Kontni plan");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDKONTO = this.Columns["IDKONTO"];
                this.columnNAZIVKONTO = this.Columns["NAZIVKONTO"];
                this.columnIDAKTIVNOST = this.Columns["IDAKTIVNOST"];
                this.columnNAZIVAKTIVNOST = this.Columns["NAZIVAKTIVNOST"];
                this.columnKONT = this.Columns["KONT"];
            }

            public KONTODataSet.KONTORow NewKONTORow()
            {
                return (KONTODataSet.KONTORow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new KONTODataSet.KONTORow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.KONTORowChanged != null)
                {
                    KONTODataSet.KONTORowChangeEventHandler kONTORowChangedEvent = this.KONTORowChanged;
                    if (kONTORowChangedEvent != null)
                    {
                        kONTORowChangedEvent(this, new KONTODataSet.KONTORowChangeEvent((KONTODataSet.KONTORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.KONTORowChanging != null)
                {
                    KONTODataSet.KONTORowChangeEventHandler kONTORowChangingEvent = this.KONTORowChanging;
                    if (kONTORowChangingEvent != null)
                    {
                        kONTORowChangingEvent(this, new KONTODataSet.KONTORowChangeEvent((KONTODataSet.KONTORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.KONTORowDeleted != null)
                {
                    KONTODataSet.KONTORowChangeEventHandler kONTORowDeletedEvent = this.KONTORowDeleted;
                    if (kONTORowDeletedEvent != null)
                    {
                        kONTORowDeletedEvent(this, new KONTODataSet.KONTORowChangeEvent((KONTODataSet.KONTORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.KONTORowDeleting != null)
                {
                    KONTODataSet.KONTORowChangeEventHandler kONTORowDeletingEvent = this.KONTORowDeleting;
                    if (kONTORowDeletingEvent != null)
                    {
                        kONTORowDeletingEvent(this, new KONTODataSet.KONTORowChangeEvent((KONTODataSet.KONTORow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveKONTORow(KONTODataSet.KONTORow row)
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

            public DataColumn IDAKTIVNOSTColumn
            {
                get
                {
                    return this.columnIDAKTIVNOST;
                }
            }

            public DataColumn IDKONTOColumn
            {
                get
                {
                    return this.columnIDKONTO;
                }
            }

            public KONTODataSet.KONTORow this[int index]
            {
                get
                {
                    return (KONTODataSet.KONTORow) this.Rows[index];
                }
            }

            public DataColumn KONTColumn
            {
                get
                {
                    return this.columnKONT;
                }
            }

            public DataColumn NAZIVAKTIVNOSTColumn
            {
                get
                {
                    return this.columnNAZIVAKTIVNOST;
                }
            }

            public DataColumn NAZIVKONTOColumn
            {
                get
                {
                    return this.columnNAZIVKONTO;
                }
            }
        }

        public class KONTORow : DataRow
        {
            private KONTODataSet.KONTODataTable tableKONTO;

            internal KONTORow(DataRowBuilder rb) : base(rb)
            {
                this.tableKONTO = (KONTODataSet.KONTODataTable) this.Table;
            }

            public bool IsIDAKTIVNOSTNull()
            {
                return this.IsNull(this.tableKONTO.IDAKTIVNOSTColumn);
            }

            public bool IsIDKONTONull()
            {
                return this.IsNull(this.tableKONTO.IDKONTOColumn);
            }

            public bool IsKONTNull()
            {
                return this.IsNull(this.tableKONTO.KONTColumn);
            }

            public bool IsNAZIVAKTIVNOSTNull()
            {
                return this.IsNull(this.tableKONTO.NAZIVAKTIVNOSTColumn);
            }

            public bool IsNAZIVKONTONull()
            {
                return this.IsNull(this.tableKONTO.NAZIVKONTOColumn);
            }

            public void SetIDAKTIVNOSTNull()
            {
                this[this.tableKONTO.IDAKTIVNOSTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKONTNull()
            {
                this[this.tableKONTO.KONTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVAKTIVNOSTNull()
            {
                this[this.tableKONTO.NAZIVAKTIVNOSTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKONTONull()
            {
                this[this.tableKONTO.NAZIVKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDAKTIVNOST
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableKONTO.IDAKTIVNOSTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDAKTIVNOST because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableKONTO.IDAKTIVNOSTColumn] = value;
                }
            }

            public string IDKONTO
            {
                get
                {
                    return Conversions.ToString(this[this.tableKONTO.IDKONTOColumn]);
                }
                set
                {
                    this[this.tableKONTO.IDKONTOColumn] = value;
                }
            }

            public string KONT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKONTO.KONTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value KONT because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableKONTO.KONTColumn] = value;
                }
            }

            public string NAZIVAKTIVNOST
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKONTO.NAZIVAKTIVNOSTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVAKTIVNOST because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableKONTO.NAZIVAKTIVNOSTColumn] = value;
                }
            }

            public string NAZIVKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKONTO.NAZIVKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVKONTO because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableKONTO.NAZIVKONTOColumn] = value;
                }
            }
        }

        public class KONTORowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private KONTODataSet.KONTORow eventRow;

            public KONTORowChangeEvent(KONTODataSet.KONTORow row, DataRowAction action)
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

            public KONTODataSet.KONTORow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void KONTORowChangeEventHandler(object sender, KONTODataSet.KONTORowChangeEvent e);
    }
}

