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
    public class EVIDENCIJADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private EVIDENCIJADataTable tableEVIDENCIJA;
        private EVIDENCIJARADNICIDataTable tableEVIDENCIJARADNICI;
        private EVIDENCIJARADNICISATIDataTable tableEVIDENCIJARADNICISATI;

        public EVIDENCIJADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected EVIDENCIJADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["EVIDENCIJARADNICISATI"] != null)
                    {
                        this.Tables.Add(new EVIDENCIJARADNICISATIDataTable(dataSet.Tables["EVIDENCIJARADNICISATI"]));
                    }
                    if (dataSet.Tables["EVIDENCIJARADNICI"] != null)
                    {
                        this.Tables.Add(new EVIDENCIJARADNICIDataTable(dataSet.Tables["EVIDENCIJARADNICI"]));
                    }
                    if (dataSet.Tables["EVIDENCIJA"] != null)
                    {
                        this.Tables.Add(new EVIDENCIJADataTable(dataSet.Tables["EVIDENCIJA"]));
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
            EVIDENCIJADataSet set = (EVIDENCIJADataSet) base.Clone();
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
            EVIDENCIJADataSet set = new EVIDENCIJADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "EVIDENCIJADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2133");
            this.ExtendedProperties.Add("DataSetName", "EVIDENCIJADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IEVIDENCIJADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "EVIDENCIJA");
            this.ExtendedProperties.Add("ObjectDescription", "EVIDENCIJA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Evidencija");
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
            this.DataSetName = "EVIDENCIJADataSet";
            this.Namespace = "http://www.tempuri.org/EVIDENCIJA";
            this.tableEVIDENCIJARADNICISATI = new EVIDENCIJARADNICISATIDataTable();
            this.Tables.Add(this.tableEVIDENCIJARADNICISATI);
            this.tableEVIDENCIJARADNICI = new EVIDENCIJARADNICIDataTable();
            this.Tables.Add(this.tableEVIDENCIJARADNICI);
            this.tableEVIDENCIJA = new EVIDENCIJADataTable();
            this.Tables.Add(this.tableEVIDENCIJA);
            this.Relations.Add("EVIDENCIJARADNICI_EVIDENCIJARADNICISATI", new DataColumn[] { this.Tables["EVIDENCIJARADNICI"].Columns["MJESEC"], this.Tables["EVIDENCIJARADNICI"].Columns["IDGODINE"], this.Tables["EVIDENCIJARADNICI"].Columns["BROJEVIDENCIJE"], this.Tables["EVIDENCIJARADNICI"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["EVIDENCIJARADNICISATI"].Columns["MJESEC"], this.Tables["EVIDENCIJARADNICISATI"].Columns["IDGODINE"], this.Tables["EVIDENCIJARADNICISATI"].Columns["BROJEVIDENCIJE"], this.Tables["EVIDENCIJARADNICISATI"].Columns["IDRADNIK"] });
            this.Relations["EVIDENCIJARADNICI_EVIDENCIJARADNICISATI"].Nested = true;
            this.Relations.Add("EVIDENCIJA_EVIDENCIJARADNICI", new DataColumn[] { this.Tables["EVIDENCIJA"].Columns["MJESEC"], this.Tables["EVIDENCIJA"].Columns["IDGODINE"], this.Tables["EVIDENCIJA"].Columns["BROJEVIDENCIJE"] }, new DataColumn[] { this.Tables["EVIDENCIJARADNICI"].Columns["MJESEC"], this.Tables["EVIDENCIJARADNICI"].Columns["IDGODINE"], this.Tables["EVIDENCIJARADNICI"].Columns["BROJEVIDENCIJE"] });
            this.Relations["EVIDENCIJA_EVIDENCIJARADNICI"].Nested = true;
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
            this.tableEVIDENCIJARADNICISATI = (EVIDENCIJARADNICISATIDataTable) this.Tables["EVIDENCIJARADNICISATI"];
            this.tableEVIDENCIJARADNICI = (EVIDENCIJARADNICIDataTable) this.Tables["EVIDENCIJARADNICI"];
            this.tableEVIDENCIJA = (EVIDENCIJADataTable) this.Tables["EVIDENCIJA"];
            if (initTable)
            {
                if (this.tableEVIDENCIJARADNICISATI != null)
                {
                    this.tableEVIDENCIJARADNICISATI.InitVars();
                }
                if (this.tableEVIDENCIJARADNICI != null)
                {
                    this.tableEVIDENCIJARADNICI.InitVars();
                }
                if (this.tableEVIDENCIJA != null)
                {
                    this.tableEVIDENCIJA.InitVars();
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
                if (dataSet.Tables["EVIDENCIJARADNICISATI"] != null)
                {
                    this.Tables.Add(new EVIDENCIJARADNICISATIDataTable(dataSet.Tables["EVIDENCIJARADNICISATI"]));
                }
                if (dataSet.Tables["EVIDENCIJARADNICI"] != null)
                {
                    this.Tables.Add(new EVIDENCIJARADNICIDataTable(dataSet.Tables["EVIDENCIJARADNICI"]));
                }
                if (dataSet.Tables["EVIDENCIJA"] != null)
                {
                    this.Tables.Add(new EVIDENCIJADataTable(dataSet.Tables["EVIDENCIJA"]));
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

        private bool ShouldSerializeEVIDENCIJA()
        {
            return false;
        }

        private bool ShouldSerializeEVIDENCIJARADNICI()
        {
            return false;
        }

        private bool ShouldSerializeEVIDENCIJARADNICISATI()
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
        public EVIDENCIJADataTable EVIDENCIJA
        {
            get
            {
                return this.tableEVIDENCIJA;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public EVIDENCIJARADNICIDataTable EVIDENCIJARADNICI
        {
            get
            {
                return this.tableEVIDENCIJARADNICI;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public EVIDENCIJARADNICISATIDataTable EVIDENCIJARADNICISATI
        {
            get
            {
                return this.tableEVIDENCIJARADNICISATI;
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
        public class EVIDENCIJADataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJEVIDENCIJE;
            private DataColumn columnIDGODINE;
            private DataColumn columnMJESEC;
            private DataColumn columnOPISEVIDENCIJE;

            public event EVIDENCIJADataSet.EVIDENCIJARowChangeEventHandler EVIDENCIJARowChanged;

            public event EVIDENCIJADataSet.EVIDENCIJARowChangeEventHandler EVIDENCIJARowChanging;

            public event EVIDENCIJADataSet.EVIDENCIJARowChangeEventHandler EVIDENCIJARowDeleted;

            public event EVIDENCIJADataSet.EVIDENCIJARowChangeEventHandler EVIDENCIJARowDeleting;

            public EVIDENCIJADataTable()
            {
                this.TableName = "EVIDENCIJA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal EVIDENCIJADataTable(DataTable table) : base(table.TableName)
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

            protected EVIDENCIJADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddEVIDENCIJARow(EVIDENCIJADataSet.EVIDENCIJARow row)
            {
                this.Rows.Add(row);
            }

            public EVIDENCIJADataSet.EVIDENCIJARow AddEVIDENCIJARow(int mJESEC, short iDGODINE, int bROJEVIDENCIJE, string oPISEVIDENCIJE)
            {
                EVIDENCIJADataSet.EVIDENCIJARow row = (EVIDENCIJADataSet.EVIDENCIJARow) this.NewRow();
                row["MJESEC"] = mJESEC;
                row["IDGODINE"] = iDGODINE;
                row["BROJEVIDENCIJE"] = bROJEVIDENCIJE;
                row["OPISEVIDENCIJE"] = oPISEVIDENCIJE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                EVIDENCIJADataSet.EVIDENCIJADataTable table = (EVIDENCIJADataSet.EVIDENCIJADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public EVIDENCIJADataSet.EVIDENCIJARow FindByMJESECIDGODINEBROJEVIDENCIJE(int mJESEC, short iDGODINE, int bROJEVIDENCIJE)
            {
                return (EVIDENCIJADataSet.EVIDENCIJARow) this.Rows.Find(new object[] { mJESEC, iDGODINE, bROJEVIDENCIJE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(EVIDENCIJADataSet.EVIDENCIJARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                EVIDENCIJADataSet set = new EVIDENCIJADataSet();
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
                this.columnMJESEC = new DataColumn("MJESEC", typeof(int), "", MappingType.Element);
                this.columnMJESEC.AllowDBNull = false;
                this.columnMJESEC.Caption = "MJESEC";
                this.columnMJESEC.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESEC.ExtendedProperties.Add("IsKey", "true");
                this.columnMJESEC.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMJESEC.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMJESEC.ExtendedProperties.Add("Description", "MJESEC");
                this.columnMJESEC.ExtendedProperties.Add("Length", "5");
                this.columnMJESEC.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESEC.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMJESEC.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.InternalName", "MJESEC");
                this.Columns.Add(this.columnMJESEC);
                this.columnIDGODINE = new DataColumn("IDGODINE", typeof(short), "", MappingType.Element);
                this.columnIDGODINE.AllowDBNull = false;
                this.columnIDGODINE.Caption = "IDGODINE";
                this.columnIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDGODINE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDGODINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDGODINE.ExtendedProperties.Add("Description", "Godina");
                this.columnIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "IDGODINE");
                this.Columns.Add(this.columnIDGODINE);
                this.columnBROJEVIDENCIJE = new DataColumn("BROJEVIDENCIJE", typeof(int), "", MappingType.Element);
                this.columnBROJEVIDENCIJE.AllowDBNull = false;
                this.columnBROJEVIDENCIJE.Caption = "BROJEVIDENCIJE";
                this.columnBROJEVIDENCIJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("IsKey", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Description", "Broj evidencije");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Length", "5");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.InternalName", "BROJEVIDENCIJE");
                this.Columns.Add(this.columnBROJEVIDENCIJE);
                this.columnOPISEVIDENCIJE = new DataColumn("OPISEVIDENCIJE", typeof(string), "", MappingType.Element);
                this.columnOPISEVIDENCIJE.AllowDBNull = false;
                this.columnOPISEVIDENCIJE.Caption = "OPISEVIDENCIJE";
                this.columnOPISEVIDENCIJE.MaxLength = 40;
                this.columnOPISEVIDENCIJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("Description", "Opis");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("Length", "40");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISEVIDENCIJE.ExtendedProperties.Add("Deklarit.InternalName", "OPISEVIDENCIJE");
                this.Columns.Add(this.columnOPISEVIDENCIJE);
                this.PrimaryKey = new DataColumn[] { this.columnMJESEC, this.columnIDGODINE, this.columnBROJEVIDENCIJE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "EVIDENCIJA");
                this.ExtendedProperties.Add("Description", "EVIDENCIJA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnMJESEC = this.Columns["MJESEC"];
                this.columnIDGODINE = this.Columns["IDGODINE"];
                this.columnBROJEVIDENCIJE = this.Columns["BROJEVIDENCIJE"];
                this.columnOPISEVIDENCIJE = this.Columns["OPISEVIDENCIJE"];
            }

            public EVIDENCIJADataSet.EVIDENCIJARow NewEVIDENCIJARow()
            {
                return (EVIDENCIJADataSet.EVIDENCIJARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new EVIDENCIJADataSet.EVIDENCIJARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.EVIDENCIJARowChanged != null)
                {
                    EVIDENCIJADataSet.EVIDENCIJARowChangeEventHandler eVIDENCIJARowChangedEvent = this.EVIDENCIJARowChanged;
                    if (eVIDENCIJARowChangedEvent != null)
                    {
                        eVIDENCIJARowChangedEvent(this, new EVIDENCIJADataSet.EVIDENCIJARowChangeEvent((EVIDENCIJADataSet.EVIDENCIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.EVIDENCIJARowChanging != null)
                {
                    EVIDENCIJADataSet.EVIDENCIJARowChangeEventHandler eVIDENCIJARowChangingEvent = this.EVIDENCIJARowChanging;
                    if (eVIDENCIJARowChangingEvent != null)
                    {
                        eVIDENCIJARowChangingEvent(this, new EVIDENCIJADataSet.EVIDENCIJARowChangeEvent((EVIDENCIJADataSet.EVIDENCIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.EVIDENCIJARowDeleted != null)
                {
                    EVIDENCIJADataSet.EVIDENCIJARowChangeEventHandler eVIDENCIJARowDeletedEvent = this.EVIDENCIJARowDeleted;
                    if (eVIDENCIJARowDeletedEvent != null)
                    {
                        eVIDENCIJARowDeletedEvent(this, new EVIDENCIJADataSet.EVIDENCIJARowChangeEvent((EVIDENCIJADataSet.EVIDENCIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.EVIDENCIJARowDeleting != null)
                {
                    EVIDENCIJADataSet.EVIDENCIJARowChangeEventHandler eVIDENCIJARowDeletingEvent = this.EVIDENCIJARowDeleting;
                    if (eVIDENCIJARowDeletingEvent != null)
                    {
                        eVIDENCIJARowDeletingEvent(this, new EVIDENCIJADataSet.EVIDENCIJARowChangeEvent((EVIDENCIJADataSet.EVIDENCIJARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveEVIDENCIJARow(EVIDENCIJADataSet.EVIDENCIJARow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJEVIDENCIJEColumn
            {
                get
                {
                    return this.columnBROJEVIDENCIJE;
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

            public DataColumn IDGODINEColumn
            {
                get
                {
                    return this.columnIDGODINE;
                }
            }

            public EVIDENCIJADataSet.EVIDENCIJARow this[int index]
            {
                get
                {
                    return (EVIDENCIJADataSet.EVIDENCIJARow) this.Rows[index];
                }
            }

            public DataColumn MJESECColumn
            {
                get
                {
                    return this.columnMJESEC;
                }
            }

            public DataColumn OPISEVIDENCIJEColumn
            {
                get
                {
                    return this.columnOPISEVIDENCIJE;
                }
            }
        }

        [Serializable]
        public class EVIDENCIJARADNICIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAKTIVAN;
            private DataColumn columnBROJEVIDENCIJE;
            private DataColumn columnIDGODINE;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnMJESEC;
            private DataColumn columnPREZIME;
            private DataColumn columnTJEDNIFONDSATI;

            public event EVIDENCIJADataSet.EVIDENCIJARADNICIRowChangeEventHandler EVIDENCIJARADNICIRowChanged;

            public event EVIDENCIJADataSet.EVIDENCIJARADNICIRowChangeEventHandler EVIDENCIJARADNICIRowChanging;

            public event EVIDENCIJADataSet.EVIDENCIJARADNICIRowChangeEventHandler EVIDENCIJARADNICIRowDeleted;

            public event EVIDENCIJADataSet.EVIDENCIJARADNICIRowChangeEventHandler EVIDENCIJARADNICIRowDeleting;

            public EVIDENCIJARADNICIDataTable()
            {
                this.TableName = "EVIDENCIJARADNICI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal EVIDENCIJARADNICIDataTable(DataTable table) : base(table.TableName)
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

            protected EVIDENCIJARADNICIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddEVIDENCIJARADNICIRow(EVIDENCIJADataSet.EVIDENCIJARADNICIRow row)
            {
                this.Rows.Add(row);
            }

            public EVIDENCIJADataSet.EVIDENCIJARADNICIRow AddEVIDENCIJARADNICIRow(int mJESEC, short iDGODINE, int bROJEVIDENCIJE, int iDRADNIK)
            {
                EVIDENCIJADataSet.EVIDENCIJARADNICIRow row = (EVIDENCIJADataSet.EVIDENCIJARADNICIRow) this.NewRow();
                row["MJESEC"] = mJESEC;
                row["IDGODINE"] = iDGODINE;
                row["BROJEVIDENCIJE"] = bROJEVIDENCIJE;
                row["IDRADNIK"] = iDRADNIK;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                EVIDENCIJADataSet.EVIDENCIJARADNICIDataTable table = (EVIDENCIJADataSet.EVIDENCIJARADNICIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public EVIDENCIJADataSet.EVIDENCIJARADNICIRow FindByMJESECIDGODINEBROJEVIDENCIJEIDRADNIK(int mJESEC, short iDGODINE, int bROJEVIDENCIJE, int iDRADNIK)
            {
                return (EVIDENCIJADataSet.EVIDENCIJARADNICIRow) this.Rows.Find(new object[] { mJESEC, iDGODINE, bROJEVIDENCIJE, iDRADNIK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(EVIDENCIJADataSet.EVIDENCIJARADNICIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                EVIDENCIJADataSet set = new EVIDENCIJADataSet();
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
                this.columnMJESEC = new DataColumn("MJESEC", typeof(int), "", MappingType.Element);
                this.columnMJESEC.AllowDBNull = false;
                this.columnMJESEC.Caption = "MJESEC";
                this.columnMJESEC.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESEC.ExtendedProperties.Add("IsKey", "true");
                this.columnMJESEC.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMJESEC.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMJESEC.ExtendedProperties.Add("Description", "MJESEC");
                this.columnMJESEC.ExtendedProperties.Add("Length", "5");
                this.columnMJESEC.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESEC.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMJESEC.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.InternalName", "MJESEC");
                this.Columns.Add(this.columnMJESEC);
                this.columnIDGODINE = new DataColumn("IDGODINE", typeof(short), "", MappingType.Element);
                this.columnIDGODINE.AllowDBNull = false;
                this.columnIDGODINE.Caption = "IDGODINE";
                this.columnIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDGODINE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDGODINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDGODINE.ExtendedProperties.Add("Description", "Godina");
                this.columnIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "IDGODINE");
                this.Columns.Add(this.columnIDGODINE);
                this.columnBROJEVIDENCIJE = new DataColumn("BROJEVIDENCIJE", typeof(int), "", MappingType.Element);
                this.columnBROJEVIDENCIJE.AllowDBNull = false;
                this.columnBROJEVIDENCIJE.Caption = "BROJEVIDENCIJE";
                this.columnBROJEVIDENCIJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("IsKey", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Description", "Broj evidencije");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Length", "5");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.InternalName", "BROJEVIDENCIJE");
                this.Columns.Add(this.columnBROJEVIDENCIJE);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnPREZIME = new DataColumn("PREZIME", typeof(string), "", MappingType.Element);
                this.columnPREZIME.AllowDBNull = true;
                this.columnPREZIME.Caption = "Prezime";
                this.columnPREZIME.MaxLength = 50;
                this.columnPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "PREZIME");
                this.Columns.Add(this.columnPREZIME);
                this.columnIME = new DataColumn("IME", typeof(string), "", MappingType.Element);
                this.columnIME.AllowDBNull = true;
                this.columnIME.Caption = "Ime";
                this.columnIME.MaxLength = 50;
                this.columnIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIME.ExtendedProperties.Add("IsKey", "false");
                this.columnIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIME.ExtendedProperties.Add("Description", "Ime");
                this.columnIME.ExtendedProperties.Add("Length", "50");
                this.columnIME.ExtendedProperties.Add("Decimals", "0");
                this.columnIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.InternalName", "IME");
                this.Columns.Add(this.columnIME);
                this.columnTJEDNIFONDSATI = new DataColumn("TJEDNIFONDSATI", typeof(decimal), "", MappingType.Element);
                this.columnTJEDNIFONDSATI.AllowDBNull = true;
                this.columnTJEDNIFONDSATI.Caption = "Tjedni fond sati (za obračun)";
                this.columnTJEDNIFONDSATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("IsKey", "false");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Description", "Tjedni fond sati (za obračun)");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Length", "5");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Decimals", "2");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.InternalName", "TJEDNIFONDSATI");
                this.Columns.Add(this.columnTJEDNIFONDSATI);
                this.columnAKTIVAN = new DataColumn("AKTIVAN", typeof(bool), "", MappingType.Element);
                this.columnAKTIVAN.AllowDBNull = true;
                this.columnAKTIVAN.Caption = "Aktivan";
                this.columnAKTIVAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnAKTIVAN.ExtendedProperties.Add("IsKey", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnAKTIVAN.ExtendedProperties.Add("Description", "Aktivan");
                this.columnAKTIVAN.ExtendedProperties.Add("Length", "1");
                this.columnAKTIVAN.ExtendedProperties.Add("Decimals", "0");
                this.columnAKTIVAN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.InternalName", "AKTIVAN");
                this.Columns.Add(this.columnAKTIVAN);
                this.PrimaryKey = new DataColumn[] { this.columnMJESEC, this.columnIDGODINE, this.columnBROJEVIDENCIJE, this.columnIDRADNIK };
                this.ExtendedProperties.Add("ParentLvl", "EVIDENCIJA");
                this.ExtendedProperties.Add("LevelName", "RADNICI");
                this.ExtendedProperties.Add("Description", "RADNICI");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnMJESEC = this.Columns["MJESEC"];
                this.columnIDGODINE = this.Columns["IDGODINE"];
                this.columnBROJEVIDENCIJE = this.Columns["BROJEVIDENCIJE"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnTJEDNIFONDSATI = this.Columns["TJEDNIFONDSATI"];
                this.columnAKTIVAN = this.Columns["AKTIVAN"];
            }

            public EVIDENCIJADataSet.EVIDENCIJARADNICIRow NewEVIDENCIJARADNICIRow()
            {
                return (EVIDENCIJADataSet.EVIDENCIJARADNICIRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new EVIDENCIJADataSet.EVIDENCIJARADNICIRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.EVIDENCIJARADNICIRowChanged != null)
                {
                    EVIDENCIJADataSet.EVIDENCIJARADNICIRowChangeEventHandler eVIDENCIJARADNICIRowChangedEvent = this.EVIDENCIJARADNICIRowChanged;
                    if (eVIDENCIJARADNICIRowChangedEvent != null)
                    {
                        eVIDENCIJARADNICIRowChangedEvent(this, new EVIDENCIJADataSet.EVIDENCIJARADNICIRowChangeEvent((EVIDENCIJADataSet.EVIDENCIJARADNICIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.EVIDENCIJARADNICIRowChanging != null)
                {
                    EVIDENCIJADataSet.EVIDENCIJARADNICIRowChangeEventHandler eVIDENCIJARADNICIRowChangingEvent = this.EVIDENCIJARADNICIRowChanging;
                    if (eVIDENCIJARADNICIRowChangingEvent != null)
                    {
                        eVIDENCIJARADNICIRowChangingEvent(this, new EVIDENCIJADataSet.EVIDENCIJARADNICIRowChangeEvent((EVIDENCIJADataSet.EVIDENCIJARADNICIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("EVIDENCIJA_EVIDENCIJARADNICI", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.EVIDENCIJARADNICIRowDeleted != null)
                {
                    EVIDENCIJADataSet.EVIDENCIJARADNICIRowChangeEventHandler eVIDENCIJARADNICIRowDeletedEvent = this.EVIDENCIJARADNICIRowDeleted;
                    if (eVIDENCIJARADNICIRowDeletedEvent != null)
                    {
                        eVIDENCIJARADNICIRowDeletedEvent(this, new EVIDENCIJADataSet.EVIDENCIJARADNICIRowChangeEvent((EVIDENCIJADataSet.EVIDENCIJARADNICIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.EVIDENCIJARADNICIRowDeleting != null)
                {
                    EVIDENCIJADataSet.EVIDENCIJARADNICIRowChangeEventHandler eVIDENCIJARADNICIRowDeletingEvent = this.EVIDENCIJARADNICIRowDeleting;
                    if (eVIDENCIJARADNICIRowDeletingEvent != null)
                    {
                        eVIDENCIJARADNICIRowDeletingEvent(this, new EVIDENCIJADataSet.EVIDENCIJARADNICIRowChangeEvent((EVIDENCIJADataSet.EVIDENCIJARADNICIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveEVIDENCIJARADNICIRow(EVIDENCIJADataSet.EVIDENCIJARADNICIRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn AKTIVANColumn
            {
                get
                {
                    return this.columnAKTIVAN;
                }
            }

            public DataColumn BROJEVIDENCIJEColumn
            {
                get
                {
                    return this.columnBROJEVIDENCIJE;
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

            public DataColumn IDGODINEColumn
            {
                get
                {
                    return this.columnIDGODINE;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public DataColumn IMEColumn
            {
                get
                {
                    return this.columnIME;
                }
            }

            public EVIDENCIJADataSet.EVIDENCIJARADNICIRow this[int index]
            {
                get
                {
                    return (EVIDENCIJADataSet.EVIDENCIJARADNICIRow) this.Rows[index];
                }
            }

            public DataColumn MJESECColumn
            {
                get
                {
                    return this.columnMJESEC;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn TJEDNIFONDSATIColumn
            {
                get
                {
                    return this.columnTJEDNIFONDSATI;
                }
            }
        }

        public class EVIDENCIJARADNICIRow : DataRow
        {
            private EVIDENCIJADataSet.EVIDENCIJARADNICIDataTable tableEVIDENCIJARADNICI;

            internal EVIDENCIJARADNICIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableEVIDENCIJARADNICI = (EVIDENCIJADataSet.EVIDENCIJARADNICIDataTable) this.Table;
            }

            public EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow[] GetEVIDENCIJARADNICISATIRows()
            {
                return (EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow[]) this.GetChildRows("EVIDENCIJARADNICI_EVIDENCIJARADNICISATI");
            }

            public EVIDENCIJADataSet.EVIDENCIJARow GetEVIDENCIJARow()
            {
                return (EVIDENCIJADataSet.EVIDENCIJARow) this.GetParentRow("EVIDENCIJA_EVIDENCIJARADNICI");
            }

            public bool IsAKTIVANNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICI.AKTIVANColumn);
            }

            public bool IsBROJEVIDENCIJENull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICI.BROJEVIDENCIJEColumn);
            }

            public bool IsIDGODINENull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICI.IDGODINEColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICI.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICI.IMEColumn);
            }

            public bool IsMJESECNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICI.MJESECColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICI.PREZIMEColumn);
            }

            public bool IsTJEDNIFONDSATINull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICI.TJEDNIFONDSATIColumn);
            }

            public void SetAKTIVANNull()
            {
                this[this.tableEVIDENCIJARADNICI.AKTIVANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableEVIDENCIJARADNICI.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableEVIDENCIJARADNICI.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTJEDNIFONDSATINull()
            {
                this[this.tableEVIDENCIJARADNICI.TJEDNIFONDSATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool AKTIVAN
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableEVIDENCIJARADNICI.AKTIVANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value AKTIVAN because it is DBNull.", innerException);
                    }
                    return flag;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICI.AKTIVANColumn] = value;
                }
            }

            public int BROJEVIDENCIJE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableEVIDENCIJARADNICI.BROJEVIDENCIJEColumn]);
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICI.BROJEVIDENCIJEColumn] = value;
                }
            }

            public short IDGODINE
            {
                get
                {
                    return Conversions.ToShort(this[this.tableEVIDENCIJARADNICI.IDGODINEColumn]);
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICI.IDGODINEColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableEVIDENCIJARADNICI.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICI.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableEVIDENCIJARADNICI.IMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICI.IMEColumn] = value;
                }
            }

            public int MJESEC
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableEVIDENCIJARADNICI.MJESECColumn]);
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICI.MJESECColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableEVIDENCIJARADNICI.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PREZIME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICI.PREZIMEColumn] = value;
                }
            }

            public decimal TJEDNIFONDSATI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICI.TJEDNIFONDSATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value TJEDNIFONDSATI because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICI.TJEDNIFONDSATIColumn] = value;
                }
            }
        }

        public class EVIDENCIJARADNICIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private EVIDENCIJADataSet.EVIDENCIJARADNICIRow eventRow;

            public EVIDENCIJARADNICIRowChangeEvent(EVIDENCIJADataSet.EVIDENCIJARADNICIRow row, DataRowAction action)
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

            public EVIDENCIJADataSet.EVIDENCIJARADNICIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void EVIDENCIJARADNICIRowChangeEventHandler(object sender, EVIDENCIJADataSet.EVIDENCIJARADNICIRowChangeEvent e);

        [Serializable]
        public class EVIDENCIJARADNICISATIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBLG;
            private DataColumn columnBOF;
            private DataColumn columnBOP;
            private DataColumn columnBROJEVIDENCIJE;
            private DataColumn columnDAN;
            private DataColumn columnDRUGASMJENAIDSMJENE;
            private DataColumn columnDRUGASMJENAOPISSMJENE;
            private DataColumn columnDRUGASMJENAPOCETAK;
            private DataColumn columnDRUGASMJENAZAVRSETAK;
            private DataColumn columnGO;
            private DataColumn columnIDGODINE;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIZNADNORME;
            private DataColumn columnLOC;
            private DataColumn columnMJESEC;
            private DataColumn columnNED;
            private DataColumn columnNEN;
            private DataColumn columnNENNEODOBRENA;
            private DataColumn columnNOC;
            private DataColumn columnNPD;
            private DataColumn columnODTOGADVOKRATNI;
            private DataColumn columnODTOGAKOMBINACIJA;
            private DataColumn columnODTOGAPOSEBNI1;
            private DataColumn columnODTOGAPOSEBNI2;
            private DataColumn columnODTOGAPOSEBNI3;
            private DataColumn columnODTOGASMJENSKI;
            private DataColumn columnODTOGASPECIJALNA;
            private DataColumn columnPD;
            private DataColumn columnPR;
            private DataColumn columnPRI;
            private DataColumn columnPRV;
            private DataColumn columnPRVASMJENAIDSMJENE;
            private DataColumn columnPRVASMJENAOPISSMJENE;
            private DataColumn columnPRVASMJENAPOCETAK;
            private DataColumn columnPRVASMJENAZAVRSETAK;
            private DataColumn columnRD;
            private DataColumn columnRR;
            private DataColumn columnSP;
            private DataColumn columnSTR;
            private DataColumn columnTR;
            private DataColumn columnZAS;

            public event EVIDENCIJADataSet.EVIDENCIJARADNICISATIRowChangeEventHandler EVIDENCIJARADNICISATIRowChanged;

            public event EVIDENCIJADataSet.EVIDENCIJARADNICISATIRowChangeEventHandler EVIDENCIJARADNICISATIRowChanging;

            public event EVIDENCIJADataSet.EVIDENCIJARADNICISATIRowChangeEventHandler EVIDENCIJARADNICISATIRowDeleted;

            public event EVIDENCIJADataSet.EVIDENCIJARADNICISATIRowChangeEventHandler EVIDENCIJARADNICISATIRowDeleting;

            public EVIDENCIJARADNICISATIDataTable()
            {
                this.TableName = "EVIDENCIJARADNICISATI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal EVIDENCIJARADNICISATIDataTable(DataTable table) : base(table.TableName)
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

            protected EVIDENCIJARADNICISATIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddEVIDENCIJARADNICISATIRow(EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow row)
            {
                this.Rows.Add(row);
            }

            public EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow AddEVIDENCIJARADNICISATIRow(int mJESEC, short iDGODINE, int bROJEVIDENCIJE, int iDRADNIK, int dAN, int pRVASMJENAIDSMJENE, int dRUGASMJENAIDSMJENE, decimal rR, decimal oDTOGASMJENSKI, decimal oDTOGADVOKRATNI, decimal oDTOGAPOSEBNI1, decimal oDTOGAPOSEBNI2, decimal oDTOGAPOSEBNI3, decimal oDTOGAKOMBINACIJA, decimal oDTOGASPECIJALNA, decimal iZNADNORME, decimal pR, decimal sP, decimal gO, decimal bOP, decimal bOF, decimal rD, decimal pD, decimal nPD, decimal bLG, decimal zAS, decimal pRV, decimal tR, decimal pRI, decimal nEN, decimal nENNEODOBRENA, decimal sTR, decimal lOC, decimal nED, decimal nOC)
            {
                EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow row = (EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow) this.NewRow();
                row["MJESEC"] = mJESEC;
                row["IDGODINE"] = iDGODINE;
                row["BROJEVIDENCIJE"] = bROJEVIDENCIJE;
                row["IDRADNIK"] = iDRADNIK;
                row["DAN"] = dAN;
                row["PRVASMJENAIDSMJENE"] = pRVASMJENAIDSMJENE;
                row["DRUGASMJENAIDSMJENE"] = dRUGASMJENAIDSMJENE;
                row["RR"] = rR;
                row["ODTOGASMJENSKI"] = oDTOGASMJENSKI;
                row["ODTOGADVOKRATNI"] = oDTOGADVOKRATNI;
                row["ODTOGAPOSEBNI1"] = oDTOGAPOSEBNI1;
                row["ODTOGAPOSEBNI2"] = oDTOGAPOSEBNI2;
                row["ODTOGAPOSEBNI3"] = oDTOGAPOSEBNI3;
                row["ODTOGAKOMBINACIJA"] = oDTOGAKOMBINACIJA;
                row["ODTOGASPECIJALNA"] = oDTOGASPECIJALNA;
                row["IZNADNORME"] = iZNADNORME;
                row["PR"] = pR;
                row["SP"] = sP;
                row["GO"] = gO;
                row["BOP"] = bOP;
                row["BOF"] = bOF;
                row["RD"] = rD;
                row["PD"] = pD;
                row["NPD"] = nPD;
                row["BLG"] = bLG;
                row["ZAS"] = zAS;
                row["PRV"] = pRV;
                row["TR"] = tR;
                row["PRI"] = pRI;
                row["NEN"] = nEN;
                row["NENNEODOBRENA"] = nENNEODOBRENA;
                row["STR"] = sTR;
                row["LOC"] = lOC;
                row["NED"] = nED;
                row["NOC"] = nOC;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                EVIDENCIJADataSet.EVIDENCIJARADNICISATIDataTable table = (EVIDENCIJADataSet.EVIDENCIJARADNICISATIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow FindByMJESECIDGODINEBROJEVIDENCIJEIDRADNIKDAN(int mJESEC, short iDGODINE, int bROJEVIDENCIJE, int iDRADNIK, int dAN)
            {
                return (EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow) this.Rows.Find(new object[] { mJESEC, iDGODINE, bROJEVIDENCIJE, iDRADNIK, dAN });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                EVIDENCIJADataSet set = new EVIDENCIJADataSet();
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
                this.columnMJESEC = new DataColumn("MJESEC", typeof(int), "", MappingType.Element);
                this.columnMJESEC.AllowDBNull = false;
                this.columnMJESEC.Caption = "MJESEC";
                this.columnMJESEC.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESEC.ExtendedProperties.Add("IsKey", "true");
                this.columnMJESEC.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMJESEC.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMJESEC.ExtendedProperties.Add("Description", "MJESEC");
                this.columnMJESEC.ExtendedProperties.Add("Length", "5");
                this.columnMJESEC.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESEC.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMJESEC.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESEC.ExtendedProperties.Add("Deklarit.InternalName", "MJESEC");
                this.Columns.Add(this.columnMJESEC);
                this.columnIDGODINE = new DataColumn("IDGODINE", typeof(short), "", MappingType.Element);
                this.columnIDGODINE.AllowDBNull = false;
                this.columnIDGODINE.Caption = "IDGODINE";
                this.columnIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDGODINE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDGODINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDGODINE.ExtendedProperties.Add("Description", "Godina");
                this.columnIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "IDGODINE");
                this.Columns.Add(this.columnIDGODINE);
                this.columnBROJEVIDENCIJE = new DataColumn("BROJEVIDENCIJE", typeof(int), "", MappingType.Element);
                this.columnBROJEVIDENCIJE.AllowDBNull = false;
                this.columnBROJEVIDENCIJE.Caption = "BROJEVIDENCIJE";
                this.columnBROJEVIDENCIJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("IsKey", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Description", "Broj evidencije");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Length", "5");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJEVIDENCIJE.ExtendedProperties.Add("Deklarit.InternalName", "BROJEVIDENCIJE");
                this.Columns.Add(this.columnBROJEVIDENCIJE);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnDAN = new DataColumn("DAN", typeof(int), "", MappingType.Element);
                this.columnDAN.AllowDBNull = false;
                this.columnDAN.Caption = "DAN";
                this.columnDAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDAN.ExtendedProperties.Add("IsKey", "true");
                this.columnDAN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDAN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDAN.ExtendedProperties.Add("Description", "DAN");
                this.columnDAN.ExtendedProperties.Add("Length", "5");
                this.columnDAN.ExtendedProperties.Add("Decimals", "0");
                this.columnDAN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDAN.ExtendedProperties.Add("Deklarit.InternalName", "DAN");
                this.Columns.Add(this.columnDAN);
                this.columnPRVASMJENAIDSMJENE = new DataColumn("PRVASMJENAIDSMJENE", typeof(int), "", MappingType.Element);
                this.columnPRVASMJENAIDSMJENE.AllowDBNull = true;
                this.columnPRVASMJENAIDSMJENE.Caption = "IDSMJENE";
                this.columnPRVASMJENAIDSMJENE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("SuperType", "IDSMJENE");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("SubtypeGroup", "PRVASMJENA");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("IsKey", "false");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("Description", "IDSMJENE");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("Length", "5");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("Decimals", "0");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRVASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.InternalName", "PRVASMJENAIDSMJENE");
                this.Columns.Add(this.columnPRVASMJENAIDSMJENE);
                this.columnPRVASMJENAOPISSMJENE = new DataColumn("PRVASMJENAOPISSMJENE", typeof(string), "", MappingType.Element);
                this.columnPRVASMJENAOPISSMJENE.AllowDBNull = true;
                this.columnPRVASMJENAOPISSMJENE.Caption = "OPISSMJENE";
                this.columnPRVASMJENAOPISSMJENE.MaxLength = 50;
                this.columnPRVASMJENAOPISSMJENE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("SuperType", "OPISSMJENE");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("SubtypeGroup", "PRVASMJENA");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("IsKey", "false");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("Description", "OPISSMJENE");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("Length", "50");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("Decimals", "0");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRVASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.InternalName", "PRVASMJENAOPISSMJENE");
                this.Columns.Add(this.columnPRVASMJENAOPISSMJENE);
                this.columnPRVASMJENAPOCETAK = new DataColumn("PRVASMJENAPOCETAK", typeof(string), "", MappingType.Element);
                this.columnPRVASMJENAPOCETAK.AllowDBNull = true;
                this.columnPRVASMJENAPOCETAK.Caption = "POCETAK";
                this.columnPRVASMJENAPOCETAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("SuperType", "POCETAK");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("SubtypeGroup", "PRVASMJENA");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("IsKey", "false");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("DeklaritType", "vchar");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("Description", "POCETAK");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("Length", "5");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("Decimals", "0");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRVASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.InternalName", "PRVASMJENAPOCETAK");
                this.Columns.Add(this.columnPRVASMJENAPOCETAK);
                this.columnPRVASMJENAZAVRSETAK = new DataColumn("PRVASMJENAZAVRSETAK", typeof(string), "", MappingType.Element);
                this.columnPRVASMJENAZAVRSETAK.AllowDBNull = true;
                this.columnPRVASMJENAZAVRSETAK.Caption = "ZAVRSETAK";
                this.columnPRVASMJENAZAVRSETAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("SuperType", "ZAVRSETAK");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("SubtypeGroup", "PRVASMJENA");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("IsKey", "false");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("DeklaritType", "vchar");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("Description", "ZAVRSETAK");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("Length", "5");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("Decimals", "0");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRVASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.InternalName", "PRVASMJENAZAVRSETAK");
                this.Columns.Add(this.columnPRVASMJENAZAVRSETAK);
                this.columnDRUGASMJENAIDSMJENE = new DataColumn("DRUGASMJENAIDSMJENE", typeof(int), "", MappingType.Element);
                this.columnDRUGASMJENAIDSMJENE.AllowDBNull = true;
                this.columnDRUGASMJENAIDSMJENE.Caption = "IDSMJENE";
                this.columnDRUGASMJENAIDSMJENE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("SuperType", "IDSMJENE");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("SubtypeGroup", "DRUGASMJENA");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("IsKey", "false");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("Description", "IDSMJENE");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("Length", "5");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("Decimals", "0");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDRUGASMJENAIDSMJENE.ExtendedProperties.Add("Deklarit.InternalName", "DRUGASMJENAIDSMJENE");
                this.Columns.Add(this.columnDRUGASMJENAIDSMJENE);
                this.columnDRUGASMJENAOPISSMJENE = new DataColumn("DRUGASMJENAOPISSMJENE", typeof(string), "", MappingType.Element);
                this.columnDRUGASMJENAOPISSMJENE.AllowDBNull = true;
                this.columnDRUGASMJENAOPISSMJENE.Caption = "OPISSMJENE";
                this.columnDRUGASMJENAOPISSMJENE.MaxLength = 50;
                this.columnDRUGASMJENAOPISSMJENE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("SuperType", "OPISSMJENE");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("SubtypeGroup", "DRUGASMJENA");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("IsKey", "false");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("Description", "OPISSMJENE");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("Length", "50");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("Decimals", "0");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDRUGASMJENAOPISSMJENE.ExtendedProperties.Add("Deklarit.InternalName", "DRUGASMJENAOPISSMJENE");
                this.Columns.Add(this.columnDRUGASMJENAOPISSMJENE);
                this.columnDRUGASMJENAPOCETAK = new DataColumn("DRUGASMJENAPOCETAK", typeof(string), "", MappingType.Element);
                this.columnDRUGASMJENAPOCETAK.AllowDBNull = true;
                this.columnDRUGASMJENAPOCETAK.Caption = "POCETAK";
                this.columnDRUGASMJENAPOCETAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("SuperType", "POCETAK");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("SubtypeGroup", "DRUGASMJENA");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("IsKey", "false");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("DeklaritType", "vchar");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("Description", "POCETAK");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("Length", "5");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("Decimals", "0");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDRUGASMJENAPOCETAK.ExtendedProperties.Add("Deklarit.InternalName", "DRUGASMJENAPOCETAK");
                this.Columns.Add(this.columnDRUGASMJENAPOCETAK);
                this.columnDRUGASMJENAZAVRSETAK = new DataColumn("DRUGASMJENAZAVRSETAK", typeof(string), "", MappingType.Element);
                this.columnDRUGASMJENAZAVRSETAK.AllowDBNull = true;
                this.columnDRUGASMJENAZAVRSETAK.Caption = "ZAVRSETAK";
                this.columnDRUGASMJENAZAVRSETAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("SuperType", "ZAVRSETAK");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("SubtypeGroup", "DRUGASMJENA");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("IsKey", "false");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("DeklaritType", "vchar");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("Description", "ZAVRSETAK");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("Length", "5");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("Decimals", "0");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDRUGASMJENAZAVRSETAK.ExtendedProperties.Add("Deklarit.InternalName", "DRUGASMJENAZAVRSETAK");
                this.Columns.Add(this.columnDRUGASMJENAZAVRSETAK);
                this.columnRR = new DataColumn("RR", typeof(decimal), "", MappingType.Element);
                this.columnRR.AllowDBNull = false;
                this.columnRR.Caption = "RR";
                this.columnRR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRR.ExtendedProperties.Add("IsKey", "false");
                this.columnRR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRR.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRR.ExtendedProperties.Add("Description", "Redovan rad");
                this.columnRR.ExtendedProperties.Add("Length", "5");
                this.columnRR.ExtendedProperties.Add("Decimals", "2");
                this.columnRR.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnRR.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnRR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRR.ExtendedProperties.Add("Deklarit.InternalName", "RR");
                this.Columns.Add(this.columnRR);
                this.columnODTOGASMJENSKI = new DataColumn("ODTOGASMJENSKI", typeof(decimal), "", MappingType.Element);
                this.columnODTOGASMJENSKI.AllowDBNull = false;
                this.columnODTOGASMJENSKI.Caption = "ODTOGASMJENSKI";
                this.columnODTOGASMJENSKI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("IsKey", "false");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("Description", "Smjenski");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("Length", "5");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("Decimals", "2");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnODTOGASMJENSKI.ExtendedProperties.Add("Deklarit.InternalName", "ODTOGASMJENSKI");
                this.Columns.Add(this.columnODTOGASMJENSKI);
                this.columnODTOGADVOKRATNI = new DataColumn("ODTOGADVOKRATNI", typeof(decimal), "", MappingType.Element);
                this.columnODTOGADVOKRATNI.AllowDBNull = false;
                this.columnODTOGADVOKRATNI.Caption = "ODTOGADVOKRATNI";
                this.columnODTOGADVOKRATNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("IsKey", "false");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("Description", "Dvokratni");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("Length", "5");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("Decimals", "2");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnODTOGADVOKRATNI.ExtendedProperties.Add("Deklarit.InternalName", "ODTOGADVOKRATNI");
                this.Columns.Add(this.columnODTOGADVOKRATNI);
                this.columnODTOGAPOSEBNI1 = new DataColumn("ODTOGAPOSEBNI1", typeof(decimal), "", MappingType.Element);
                this.columnODTOGAPOSEBNI1.AllowDBNull = false;
                this.columnODTOGAPOSEBNI1.Caption = "ODTOGAPOSEBN I1";
                this.columnODTOGAPOSEBNI1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("IsKey", "false");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("ReadOnly", "false");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("DeklaritType", "int");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("Description", "Posebni 7%");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("Length", "5");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("Decimals", "2");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnODTOGAPOSEBNI1.ExtendedProperties.Add("Deklarit.InternalName", "ODTOGAPOSEBNI1");
                this.Columns.Add(this.columnODTOGAPOSEBNI1);
                this.columnODTOGAPOSEBNI2 = new DataColumn("ODTOGAPOSEBNI2", typeof(decimal), "", MappingType.Element);
                this.columnODTOGAPOSEBNI2.AllowDBNull = false;
                this.columnODTOGAPOSEBNI2.Caption = "ODTOGAPOSEBN I2";
                this.columnODTOGAPOSEBNI2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("IsKey", "false");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("ReadOnly", "false");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("Description", "Posebni 14%");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("Length", "5");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("Decimals", "2");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnODTOGAPOSEBNI2.ExtendedProperties.Add("Deklarit.InternalName", "ODTOGAPOSEBNI2");
                this.Columns.Add(this.columnODTOGAPOSEBNI2);
                this.columnODTOGAPOSEBNI3 = new DataColumn("ODTOGAPOSEBNI3", typeof(decimal), "", MappingType.Element);
                this.columnODTOGAPOSEBNI3.AllowDBNull = false;
                this.columnODTOGAPOSEBNI3.Caption = "ODTOGAPOSEBN I3";
                this.columnODTOGAPOSEBNI3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("IsKey", "false");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("ReadOnly", "false");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("DeklaritType", "int");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("Description", "Posebni 21%");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("Length", "5");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("Decimals", "2");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnODTOGAPOSEBNI3.ExtendedProperties.Add("Deklarit.InternalName", "ODTOGAPOSEBNI3");
                this.Columns.Add(this.columnODTOGAPOSEBNI3);
                this.columnODTOGAKOMBINACIJA = new DataColumn("ODTOGAKOMBINACIJA", typeof(decimal), "", MappingType.Element);
                this.columnODTOGAKOMBINACIJA.AllowDBNull = false;
                this.columnODTOGAKOMBINACIJA.Caption = "ODTOGAKOMBINACIJA";
                this.columnODTOGAKOMBINACIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("IsKey", "false");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("Description", "Kombinacija");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("Length", "5");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("Decimals", "2");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnODTOGAKOMBINACIJA.ExtendedProperties.Add("Deklarit.InternalName", "ODTOGAKOMBINACIJA");
                this.Columns.Add(this.columnODTOGAKOMBINACIJA);
                this.columnODTOGASPECIJALNA = new DataColumn("ODTOGASPECIJALNA", typeof(decimal), "", MappingType.Element);
                this.columnODTOGASPECIJALNA.AllowDBNull = false;
                this.columnODTOGASPECIJALNA.Caption = "ODTOGASPECIJALNA";
                this.columnODTOGASPECIJALNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("IsKey", "false");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("Description", "Specijalna odjeljenja");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("Length", "5");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("Decimals", "2");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnODTOGASPECIJALNA.ExtendedProperties.Add("Deklarit.InternalName", "ODTOGASPECIJALNA");
                this.Columns.Add(this.columnODTOGASPECIJALNA);
                this.columnIZNADNORME = new DataColumn("IZNADNORME", typeof(decimal), "", MappingType.Element);
                this.columnIZNADNORME.AllowDBNull = false;
                this.columnIZNADNORME.Caption = "IZNADNORME";
                this.columnIZNADNORME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNADNORME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNADNORME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNADNORME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNADNORME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNADNORME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNADNORME.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNADNORME.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIZNADNORME.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNADNORME.ExtendedProperties.Add("Description", "Rad iznad norme");
                this.columnIZNADNORME.ExtendedProperties.Add("Length", "5");
                this.columnIZNADNORME.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNADNORME.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNADNORME.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnIZNADNORME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIZNADNORME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNADNORME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNADNORME.ExtendedProperties.Add("Deklarit.InternalName", "IZNADNORME");
                this.Columns.Add(this.columnIZNADNORME);
                this.columnPR = new DataColumn("PR", typeof(decimal), "", MappingType.Element);
                this.columnPR.AllowDBNull = false;
                this.columnPR.Caption = "PR";
                this.columnPR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPR.ExtendedProperties.Add("IsKey", "false");
                this.columnPR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPR.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPR.ExtendedProperties.Add("Description", "PR");
                this.columnPR.ExtendedProperties.Add("Length", "5");
                this.columnPR.ExtendedProperties.Add("Decimals", "2");
                this.columnPR.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPR.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPR.ExtendedProperties.Add("Deklarit.InternalName", "PR");
                this.Columns.Add(this.columnPR);
                this.columnSP = new DataColumn("SP", typeof(decimal), "", MappingType.Element);
                this.columnSP.AllowDBNull = false;
                this.columnSP.Caption = "SP";
                this.columnSP.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSP.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSP.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSP.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSP.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSP.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSP.ExtendedProperties.Add("IsKey", "false");
                this.columnSP.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSP.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSP.ExtendedProperties.Add("Description", "SP");
                this.columnSP.ExtendedProperties.Add("Length", "5");
                this.columnSP.ExtendedProperties.Add("Decimals", "2");
                this.columnSP.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSP.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnSP.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSP.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSP.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSP.ExtendedProperties.Add("Deklarit.InternalName", "SP");
                this.Columns.Add(this.columnSP);
                this.columnGO = new DataColumn("GO", typeof(decimal), "", MappingType.Element);
                this.columnGO.AllowDBNull = false;
                this.columnGO.Caption = "GO";
                this.columnGO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnGO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnGO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnGO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGO.ExtendedProperties.Add("IsKey", "false");
                this.columnGO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnGO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnGO.ExtendedProperties.Add("Description", "GO");
                this.columnGO.ExtendedProperties.Add("Length", "5");
                this.columnGO.ExtendedProperties.Add("Decimals", "2");
                this.columnGO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnGO.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnGO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnGO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGO.ExtendedProperties.Add("Deklarit.InternalName", "GO");
                this.Columns.Add(this.columnGO);
                this.columnBOP = new DataColumn("BOP", typeof(decimal), "", MappingType.Element);
                this.columnBOP.AllowDBNull = false;
                this.columnBOP.Caption = "BOP";
                this.columnBOP.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBOP.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBOP.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBOP.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBOP.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBOP.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBOP.ExtendedProperties.Add("IsKey", "false");
                this.columnBOP.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBOP.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBOP.ExtendedProperties.Add("Description", "BOP");
                this.columnBOP.ExtendedProperties.Add("Length", "5");
                this.columnBOP.ExtendedProperties.Add("Decimals", "2");
                this.columnBOP.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBOP.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnBOP.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBOP.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBOP.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBOP.ExtendedProperties.Add("Deklarit.InternalName", "BOP");
                this.Columns.Add(this.columnBOP);
                this.columnBOF = new DataColumn("BOF", typeof(decimal), "", MappingType.Element);
                this.columnBOF.AllowDBNull = false;
                this.columnBOF.Caption = "BOF";
                this.columnBOF.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBOF.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBOF.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBOF.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBOF.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBOF.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBOF.ExtendedProperties.Add("IsKey", "false");
                this.columnBOF.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBOF.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBOF.ExtendedProperties.Add("Description", "BOF");
                this.columnBOF.ExtendedProperties.Add("Length", "5");
                this.columnBOF.ExtendedProperties.Add("Decimals", "2");
                this.columnBOF.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBOF.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnBOF.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBOF.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBOF.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBOF.ExtendedProperties.Add("Deklarit.InternalName", "BOF");
                this.Columns.Add(this.columnBOF);
                this.columnRD = new DataColumn("RD", typeof(decimal), "", MappingType.Element);
                this.columnRD.AllowDBNull = false;
                this.columnRD.Caption = "RD";
                this.columnRD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRD.ExtendedProperties.Add("IsKey", "false");
                this.columnRD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRD.ExtendedProperties.Add("Description", "RD");
                this.columnRD.ExtendedProperties.Add("Length", "5");
                this.columnRD.ExtendedProperties.Add("Decimals", "2");
                this.columnRD.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnRD.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnRD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRD.ExtendedProperties.Add("Deklarit.InternalName", "RD");
                this.Columns.Add(this.columnRD);
                this.columnPD = new DataColumn("PD", typeof(decimal), "", MappingType.Element);
                this.columnPD.AllowDBNull = false;
                this.columnPD.Caption = "PD";
                this.columnPD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPD.ExtendedProperties.Add("IsKey", "false");
                this.columnPD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPD.ExtendedProperties.Add("Description", "PD");
                this.columnPD.ExtendedProperties.Add("Length", "5");
                this.columnPD.ExtendedProperties.Add("Decimals", "2");
                this.columnPD.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPD.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPD.ExtendedProperties.Add("Deklarit.InternalName", "PD");
                this.Columns.Add(this.columnPD);
                this.columnNPD = new DataColumn("NPD", typeof(decimal), "", MappingType.Element);
                this.columnNPD.AllowDBNull = false;
                this.columnNPD.Caption = "NPD";
                this.columnNPD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNPD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNPD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNPD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNPD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNPD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNPD.ExtendedProperties.Add("IsKey", "false");
                this.columnNPD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNPD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNPD.ExtendedProperties.Add("Description", "NPD");
                this.columnNPD.ExtendedProperties.Add("Length", "5");
                this.columnNPD.ExtendedProperties.Add("Decimals", "2");
                this.columnNPD.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNPD.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnNPD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNPD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNPD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNPD.ExtendedProperties.Add("Deklarit.InternalName", "NPD");
                this.Columns.Add(this.columnNPD);
                this.columnBLG = new DataColumn("BLG", typeof(decimal), "", MappingType.Element);
                this.columnBLG.AllowDBNull = false;
                this.columnBLG.Caption = "BLG";
                this.columnBLG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLG.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLG.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLG.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLG.ExtendedProperties.Add("IsKey", "false");
                this.columnBLG.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBLG.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLG.ExtendedProperties.Add("Description", "BLG");
                this.columnBLG.ExtendedProperties.Add("Length", "5");
                this.columnBLG.ExtendedProperties.Add("Decimals", "2");
                this.columnBLG.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBLG.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnBLG.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBLG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLG.ExtendedProperties.Add("Deklarit.InternalName", "BLG");
                this.Columns.Add(this.columnBLG);
                this.columnZAS = new DataColumn("ZAS", typeof(decimal), "", MappingType.Element);
                this.columnZAS.AllowDBNull = false;
                this.columnZAS.Caption = "ZAS";
                this.columnZAS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZAS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZAS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZAS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZAS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZAS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZAS.ExtendedProperties.Add("IsKey", "false");
                this.columnZAS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZAS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZAS.ExtendedProperties.Add("Description", "ZAS");
                this.columnZAS.ExtendedProperties.Add("Length", "5");
                this.columnZAS.ExtendedProperties.Add("Decimals", "2");
                this.columnZAS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZAS.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnZAS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZAS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZAS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZAS.ExtendedProperties.Add("Deklarit.InternalName", "ZAS");
                this.Columns.Add(this.columnZAS);
                this.columnPRV = new DataColumn("PRV", typeof(decimal), "", MappingType.Element);
                this.columnPRV.AllowDBNull = false;
                this.columnPRV.Caption = "PRV";
                this.columnPRV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRV.ExtendedProperties.Add("IsKey", "false");
                this.columnPRV.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRV.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRV.ExtendedProperties.Add("Description", "PRV");
                this.columnPRV.ExtendedProperties.Add("Length", "5");
                this.columnPRV.ExtendedProperties.Add("Decimals", "2");
                this.columnPRV.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRV.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPRV.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRV.ExtendedProperties.Add("Deklarit.InternalName", "PRV");
                this.Columns.Add(this.columnPRV);
                this.columnTR = new DataColumn("TR", typeof(decimal), "", MappingType.Element);
                this.columnTR.AllowDBNull = false;
                this.columnTR.Caption = "TR";
                this.columnTR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTR.ExtendedProperties.Add("IsKey", "false");
                this.columnTR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnTR.ExtendedProperties.Add("DeklaritType", "int");
                this.columnTR.ExtendedProperties.Add("Description", "TR");
                this.columnTR.ExtendedProperties.Add("Length", "5");
                this.columnTR.ExtendedProperties.Add("Decimals", "2");
                this.columnTR.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnTR.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnTR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnTR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTR.ExtendedProperties.Add("Deklarit.InternalName", "TR");
                this.Columns.Add(this.columnTR);
                this.columnPRI = new DataColumn("PRI", typeof(decimal), "", MappingType.Element);
                this.columnPRI.AllowDBNull = false;
                this.columnPRI.Caption = "PRI";
                this.columnPRI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRI.ExtendedProperties.Add("IsKey", "false");
                this.columnPRI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRI.ExtendedProperties.Add("Description", "PRI");
                this.columnPRI.ExtendedProperties.Add("Length", "5");
                this.columnPRI.ExtendedProperties.Add("Decimals", "2");
                this.columnPRI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRI.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPRI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRI.ExtendedProperties.Add("Deklarit.InternalName", "PRI");
                this.Columns.Add(this.columnPRI);
                this.columnNEN = new DataColumn("NEN", typeof(decimal), "", MappingType.Element);
                this.columnNEN.AllowDBNull = false;
                this.columnNEN.Caption = "NEN";
                this.columnNEN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNEN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNEN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNEN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNEN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNEN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNEN.ExtendedProperties.Add("IsKey", "false");
                this.columnNEN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNEN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNEN.ExtendedProperties.Add("Description", "Nenazočnost odobrena");
                this.columnNEN.ExtendedProperties.Add("Length", "5");
                this.columnNEN.ExtendedProperties.Add("Decimals", "2");
                this.columnNEN.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNEN.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnNEN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNEN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNEN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNEN.ExtendedProperties.Add("Deklarit.InternalName", "NEN");
                this.Columns.Add(this.columnNEN);
                this.columnNENNEODOBRENA = new DataColumn("NENNEODOBRENA", typeof(decimal), "", MappingType.Element);
                this.columnNENNEODOBRENA.AllowDBNull = false;
                this.columnNENNEODOBRENA.Caption = "NENNEODOBRENA";
                this.columnNENNEODOBRENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNENNEODOBRENA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("IsKey", "false");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("Description", "Nenazočnost neodobrena");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("Length", "5");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("Decimals", "2");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNENNEODOBRENA.ExtendedProperties.Add("Deklarit.InternalName", "NENNEODOBRENA");
                this.Columns.Add(this.columnNENNEODOBRENA);
                this.columnSTR = new DataColumn("STR", typeof(decimal), "", MappingType.Element);
                this.columnSTR.AllowDBNull = false;
                this.columnSTR.Caption = "STR";
                this.columnSTR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTR.ExtendedProperties.Add("IsKey", "false");
                this.columnSTR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSTR.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTR.ExtendedProperties.Add("Description", "STR");
                this.columnSTR.ExtendedProperties.Add("Length", "5");
                this.columnSTR.ExtendedProperties.Add("Decimals", "2");
                this.columnSTR.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTR.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnSTR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSTR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTR.ExtendedProperties.Add("Deklarit.InternalName", "STR");
                this.Columns.Add(this.columnSTR);
                this.columnLOC = new DataColumn("LOC", typeof(decimal), "", MappingType.Element);
                this.columnLOC.AllowDBNull = false;
                this.columnLOC.Caption = "LOC";
                this.columnLOC.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnLOC.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnLOC.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnLOC.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnLOC.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnLOC.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnLOC.ExtendedProperties.Add("IsKey", "false");
                this.columnLOC.ExtendedProperties.Add("ReadOnly", "false");
                this.columnLOC.ExtendedProperties.Add("DeklaritType", "int");
                this.columnLOC.ExtendedProperties.Add("Description", "LOC");
                this.columnLOC.ExtendedProperties.Add("Length", "5");
                this.columnLOC.ExtendedProperties.Add("Decimals", "2");
                this.columnLOC.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnLOC.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnLOC.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnLOC.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnLOC.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnLOC.ExtendedProperties.Add("Deklarit.InternalName", "LOC");
                this.Columns.Add(this.columnLOC);
                this.columnNED = new DataColumn("NED", typeof(decimal), "", MappingType.Element);
                this.columnNED.AllowDBNull = false;
                this.columnNED.Caption = "NED";
                this.columnNED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNED.ExtendedProperties.Add("IsKey", "false");
                this.columnNED.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNED.ExtendedProperties.Add("Description", "NED");
                this.columnNED.ExtendedProperties.Add("Length", "5");
                this.columnNED.ExtendedProperties.Add("Decimals", "2");
                this.columnNED.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNED.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnNED.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNED.ExtendedProperties.Add("Deklarit.InternalName", "NED");
                this.Columns.Add(this.columnNED);
                this.columnNOC = new DataColumn("NOC", typeof(decimal), "", MappingType.Element);
                this.columnNOC.AllowDBNull = false;
                this.columnNOC.Caption = "NOC";
                this.columnNOC.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNOC.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNOC.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNOC.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNOC.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNOC.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNOC.ExtendedProperties.Add("IsKey", "false");
                this.columnNOC.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNOC.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNOC.ExtendedProperties.Add("Description", "NOC");
                this.columnNOC.ExtendedProperties.Add("Length", "5");
                this.columnNOC.ExtendedProperties.Add("Decimals", "2");
                this.columnNOC.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNOC.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnNOC.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNOC.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNOC.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNOC.ExtendedProperties.Add("Deklarit.InternalName", "NOC");
                this.Columns.Add(this.columnNOC);
                this.PrimaryKey = new DataColumn[] { this.columnMJESEC, this.columnIDGODINE, this.columnBROJEVIDENCIJE, this.columnIDRADNIK, this.columnDAN };
                this.ExtendedProperties.Add("ParentLvl", "EVIDENCIJARADNICI");
                this.ExtendedProperties.Add("LevelName", "SATI");
                this.ExtendedProperties.Add("Description", "SATI");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnMJESEC = this.Columns["MJESEC"];
                this.columnIDGODINE = this.Columns["IDGODINE"];
                this.columnBROJEVIDENCIJE = this.Columns["BROJEVIDENCIJE"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnDAN = this.Columns["DAN"];
                this.columnPRVASMJENAIDSMJENE = this.Columns["PRVASMJENAIDSMJENE"];
                this.columnPRVASMJENAOPISSMJENE = this.Columns["PRVASMJENAOPISSMJENE"];
                this.columnPRVASMJENAPOCETAK = this.Columns["PRVASMJENAPOCETAK"];
                this.columnPRVASMJENAZAVRSETAK = this.Columns["PRVASMJENAZAVRSETAK"];
                this.columnDRUGASMJENAIDSMJENE = this.Columns["DRUGASMJENAIDSMJENE"];
                this.columnDRUGASMJENAOPISSMJENE = this.Columns["DRUGASMJENAOPISSMJENE"];
                this.columnDRUGASMJENAPOCETAK = this.Columns["DRUGASMJENAPOCETAK"];
                this.columnDRUGASMJENAZAVRSETAK = this.Columns["DRUGASMJENAZAVRSETAK"];
                this.columnRR = this.Columns["RR"];
                this.columnODTOGASMJENSKI = this.Columns["ODTOGASMJENSKI"];
                this.columnODTOGADVOKRATNI = this.Columns["ODTOGADVOKRATNI"];
                this.columnODTOGAPOSEBNI1 = this.Columns["ODTOGAPOSEBNI1"];
                this.columnODTOGAPOSEBNI2 = this.Columns["ODTOGAPOSEBNI2"];
                this.columnODTOGAPOSEBNI3 = this.Columns["ODTOGAPOSEBNI3"];
                this.columnODTOGAKOMBINACIJA = this.Columns["ODTOGAKOMBINACIJA"];
                this.columnODTOGASPECIJALNA = this.Columns["ODTOGASPECIJALNA"];
                this.columnIZNADNORME = this.Columns["IZNADNORME"];
                this.columnPR = this.Columns["PR"];
                this.columnSP = this.Columns["SP"];
                this.columnGO = this.Columns["GO"];
                this.columnBOP = this.Columns["BOP"];
                this.columnBOF = this.Columns["BOF"];
                this.columnRD = this.Columns["RD"];
                this.columnPD = this.Columns["PD"];
                this.columnNPD = this.Columns["NPD"];
                this.columnBLG = this.Columns["BLG"];
                this.columnZAS = this.Columns["ZAS"];
                this.columnPRV = this.Columns["PRV"];
                this.columnTR = this.Columns["TR"];
                this.columnPRI = this.Columns["PRI"];
                this.columnNEN = this.Columns["NEN"];
                this.columnNENNEODOBRENA = this.Columns["NENNEODOBRENA"];
                this.columnSTR = this.Columns["STR"];
                this.columnLOC = this.Columns["LOC"];
                this.columnNED = this.Columns["NED"];
                this.columnNOC = this.Columns["NOC"];
            }

            public EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow NewEVIDENCIJARADNICISATIRow()
            {
                return (EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.EVIDENCIJARADNICISATIRowChanged != null)
                {
                    EVIDENCIJADataSet.EVIDENCIJARADNICISATIRowChangeEventHandler eVIDENCIJARADNICISATIRowChangedEvent = this.EVIDENCIJARADNICISATIRowChanged;
                    if (eVIDENCIJARADNICISATIRowChangedEvent != null)
                    {
                        eVIDENCIJARADNICISATIRowChangedEvent(this, new EVIDENCIJADataSet.EVIDENCIJARADNICISATIRowChangeEvent((EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.EVIDENCIJARADNICISATIRowChanging != null)
                {
                    EVIDENCIJADataSet.EVIDENCIJARADNICISATIRowChangeEventHandler eVIDENCIJARADNICISATIRowChangingEvent = this.EVIDENCIJARADNICISATIRowChanging;
                    if (eVIDENCIJARADNICISATIRowChangingEvent != null)
                    {
                        eVIDENCIJARADNICISATIRowChangingEvent(this, new EVIDENCIJADataSet.EVIDENCIJARADNICISATIRowChangeEvent((EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("EVIDENCIJARADNICI_EVIDENCIJARADNICISATI", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.EVIDENCIJARADNICISATIRowDeleted != null)
                {
                    EVIDENCIJADataSet.EVIDENCIJARADNICISATIRowChangeEventHandler eVIDENCIJARADNICISATIRowDeletedEvent = this.EVIDENCIJARADNICISATIRowDeleted;
                    if (eVIDENCIJARADNICISATIRowDeletedEvent != null)
                    {
                        eVIDENCIJARADNICISATIRowDeletedEvent(this, new EVIDENCIJADataSet.EVIDENCIJARADNICISATIRowChangeEvent((EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.EVIDENCIJARADNICISATIRowDeleting != null)
                {
                    EVIDENCIJADataSet.EVIDENCIJARADNICISATIRowChangeEventHandler eVIDENCIJARADNICISATIRowDeletingEvent = this.EVIDENCIJARADNICISATIRowDeleting;
                    if (eVIDENCIJARADNICISATIRowDeletingEvent != null)
                    {
                        eVIDENCIJARADNICISATIRowDeletingEvent(this, new EVIDENCIJADataSet.EVIDENCIJARADNICISATIRowChangeEvent((EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveEVIDENCIJARADNICISATIRow(EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BLGColumn
            {
                get
                {
                    return this.columnBLG;
                }
            }

            public DataColumn BOFColumn
            {
                get
                {
                    return this.columnBOF;
                }
            }

            public DataColumn BOPColumn
            {
                get
                {
                    return this.columnBOP;
                }
            }

            public DataColumn BROJEVIDENCIJEColumn
            {
                get
                {
                    return this.columnBROJEVIDENCIJE;
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

            public DataColumn DANColumn
            {
                get
                {
                    return this.columnDAN;
                }
            }

            public DataColumn DRUGASMJENAIDSMJENEColumn
            {
                get
                {
                    return this.columnDRUGASMJENAIDSMJENE;
                }
            }

            public DataColumn DRUGASMJENAOPISSMJENEColumn
            {
                get
                {
                    return this.columnDRUGASMJENAOPISSMJENE;
                }
            }

            public DataColumn DRUGASMJENAPOCETAKColumn
            {
                get
                {
                    return this.columnDRUGASMJENAPOCETAK;
                }
            }

            public DataColumn DRUGASMJENAZAVRSETAKColumn
            {
                get
                {
                    return this.columnDRUGASMJENAZAVRSETAK;
                }
            }

            public DataColumn GOColumn
            {
                get
                {
                    return this.columnGO;
                }
            }

            public DataColumn IDGODINEColumn
            {
                get
                {
                    return this.columnIDGODINE;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow this[int index]
            {
                get
                {
                    return (EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow) this.Rows[index];
                }
            }

            public DataColumn IZNADNORMEColumn
            {
                get
                {
                    return this.columnIZNADNORME;
                }
            }

            public DataColumn LOCColumn
            {
                get
                {
                    return this.columnLOC;
                }
            }

            public DataColumn MJESECColumn
            {
                get
                {
                    return this.columnMJESEC;
                }
            }

            public DataColumn NEDColumn
            {
                get
                {
                    return this.columnNED;
                }
            }

            public DataColumn NENColumn
            {
                get
                {
                    return this.columnNEN;
                }
            }

            public DataColumn NENNEODOBRENAColumn
            {
                get
                {
                    return this.columnNENNEODOBRENA;
                }
            }

            public DataColumn NOCColumn
            {
                get
                {
                    return this.columnNOC;
                }
            }

            public DataColumn NPDColumn
            {
                get
                {
                    return this.columnNPD;
                }
            }

            public DataColumn ODTOGADVOKRATNIColumn
            {
                get
                {
                    return this.columnODTOGADVOKRATNI;
                }
            }

            public DataColumn ODTOGAKOMBINACIJAColumn
            {
                get
                {
                    return this.columnODTOGAKOMBINACIJA;
                }
            }

            public DataColumn ODTOGAPOSEBNI1Column
            {
                get
                {
                    return this.columnODTOGAPOSEBNI1;
                }
            }

            public DataColumn ODTOGAPOSEBNI2Column
            {
                get
                {
                    return this.columnODTOGAPOSEBNI2;
                }
            }

            public DataColumn ODTOGAPOSEBNI3Column
            {
                get
                {
                    return this.columnODTOGAPOSEBNI3;
                }
            }

            public DataColumn ODTOGASMJENSKIColumn
            {
                get
                {
                    return this.columnODTOGASMJENSKI;
                }
            }

            public DataColumn ODTOGASPECIJALNAColumn
            {
                get
                {
                    return this.columnODTOGASPECIJALNA;
                }
            }

            public DataColumn PDColumn
            {
                get
                {
                    return this.columnPD;
                }
            }

            public DataColumn PRColumn
            {
                get
                {
                    return this.columnPR;
                }
            }

            public DataColumn PRIColumn
            {
                get
                {
                    return this.columnPRI;
                }
            }

            public DataColumn PRVASMJENAIDSMJENEColumn
            {
                get
                {
                    return this.columnPRVASMJENAIDSMJENE;
                }
            }

            public DataColumn PRVASMJENAOPISSMJENEColumn
            {
                get
                {
                    return this.columnPRVASMJENAOPISSMJENE;
                }
            }

            public DataColumn PRVASMJENAPOCETAKColumn
            {
                get
                {
                    return this.columnPRVASMJENAPOCETAK;
                }
            }

            public DataColumn PRVASMJENAZAVRSETAKColumn
            {
                get
                {
                    return this.columnPRVASMJENAZAVRSETAK;
                }
            }

            public DataColumn PRVColumn
            {
                get
                {
                    return this.columnPRV;
                }
            }

            public DataColumn RDColumn
            {
                get
                {
                    return this.columnRD;
                }
            }

            public DataColumn RRColumn
            {
                get
                {
                    return this.columnRR;
                }
            }

            public DataColumn SPColumn
            {
                get
                {
                    return this.columnSP;
                }
            }

            public DataColumn STRColumn
            {
                get
                {
                    return this.columnSTR;
                }
            }

            public DataColumn TRColumn
            {
                get
                {
                    return this.columnTR;
                }
            }

            public DataColumn ZASColumn
            {
                get
                {
                    return this.columnZAS;
                }
            }
        }

        public class EVIDENCIJARADNICISATIRow : DataRow
        {
            private EVIDENCIJADataSet.EVIDENCIJARADNICISATIDataTable tableEVIDENCIJARADNICISATI;

            internal EVIDENCIJARADNICISATIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableEVIDENCIJARADNICISATI = (EVIDENCIJADataSet.EVIDENCIJARADNICISATIDataTable) this.Table;
            }

            public EVIDENCIJADataSet.EVIDENCIJARADNICIRow GetEVIDENCIJARADNICIRow()
            {
                return (EVIDENCIJADataSet.EVIDENCIJARADNICIRow) this.GetParentRow("EVIDENCIJARADNICI_EVIDENCIJARADNICISATI");
            }

            public bool IsBLGNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.BLGColumn);
            }

            public bool IsBOFNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.BOFColumn);
            }

            public bool IsBOPNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.BOPColumn);
            }

            public bool IsBROJEVIDENCIJENull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.BROJEVIDENCIJEColumn);
            }

            public bool IsDANNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.DANColumn);
            }

            public bool IsDRUGASMJENAIDSMJENENull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.DRUGASMJENAIDSMJENEColumn);
            }

            public bool IsDRUGASMJENAOPISSMJENENull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.DRUGASMJENAOPISSMJENEColumn);
            }

            public bool IsDRUGASMJENAPOCETAKNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.DRUGASMJENAPOCETAKColumn);
            }

            public bool IsDRUGASMJENAZAVRSETAKNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.DRUGASMJENAZAVRSETAKColumn);
            }

            public bool IsGONull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.GOColumn);
            }

            public bool IsIDGODINENull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.IDGODINEColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.IDRADNIKColumn);
            }

            public bool IsIZNADNORMENull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.IZNADNORMEColumn);
            }

            public bool IsLOCNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.LOCColumn);
            }

            public bool IsMJESECNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.MJESECColumn);
            }

            public bool IsNEDNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.NEDColumn);
            }

            public bool IsNENNEODOBRENANull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.NENNEODOBRENAColumn);
            }

            public bool IsNENNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.NENColumn);
            }

            public bool IsNOCNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.NOCColumn);
            }

            public bool IsNPDNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.NPDColumn);
            }

            public bool IsODTOGADVOKRATNINull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.ODTOGADVOKRATNIColumn);
            }

            public bool IsODTOGAKOMBINACIJANull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.ODTOGAKOMBINACIJAColumn);
            }

            public bool IsODTOGAPOSEBNI1Null()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.ODTOGAPOSEBNI1Column);
            }

            public bool IsODTOGAPOSEBNI2Null()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.ODTOGAPOSEBNI2Column);
            }

            public bool IsODTOGAPOSEBNI3Null()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.ODTOGAPOSEBNI3Column);
            }

            public bool IsODTOGASMJENSKINull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.ODTOGASMJENSKIColumn);
            }

            public bool IsODTOGASPECIJALNANull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.ODTOGASPECIJALNAColumn);
            }

            public bool IsPDNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.PDColumn);
            }

            public bool IsPRINull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.PRIColumn);
            }

            public bool IsPRNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.PRColumn);
            }

            public bool IsPRVASMJENAIDSMJENENull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.PRVASMJENAIDSMJENEColumn);
            }

            public bool IsPRVASMJENAOPISSMJENENull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.PRVASMJENAOPISSMJENEColumn);
            }

            public bool IsPRVASMJENAPOCETAKNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.PRVASMJENAPOCETAKColumn);
            }

            public bool IsPRVASMJENAZAVRSETAKNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.PRVASMJENAZAVRSETAKColumn);
            }

            public bool IsPRVNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.PRVColumn);
            }

            public bool IsRDNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.RDColumn);
            }

            public bool IsRRNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.RRColumn);
            }

            public bool IsSPNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.SPColumn);
            }

            public bool IsSTRNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.STRColumn);
            }

            public bool IsTRNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.TRColumn);
            }

            public bool IsZASNull()
            {
                return this.IsNull(this.tableEVIDENCIJARADNICISATI.ZASColumn);
            }

            public void SetBLGNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.BLGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBOFNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.BOFColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBOPNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.BOPColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDRUGASMJENAIDSMJENENull()
            {
                this[this.tableEVIDENCIJARADNICISATI.DRUGASMJENAIDSMJENEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDRUGASMJENAOPISSMJENENull()
            {
                this[this.tableEVIDENCIJARADNICISATI.DRUGASMJENAOPISSMJENEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDRUGASMJENAPOCETAKNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.DRUGASMJENAPOCETAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDRUGASMJENAZAVRSETAKNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.DRUGASMJENAZAVRSETAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGONull()
            {
                this[this.tableEVIDENCIJARADNICISATI.GOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNADNORMENull()
            {
                this[this.tableEVIDENCIJARADNICISATI.IZNADNORMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetLOCNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.LOCColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNEDNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.NEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNENNEODOBRENANull()
            {
                this[this.tableEVIDENCIJARADNICISATI.NENNEODOBRENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNENNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.NENColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNOCNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.NOCColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNPDNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.NPDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODTOGADVOKRATNINull()
            {
                this[this.tableEVIDENCIJARADNICISATI.ODTOGADVOKRATNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODTOGAKOMBINACIJANull()
            {
                this[this.tableEVIDENCIJARADNICISATI.ODTOGAKOMBINACIJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODTOGAPOSEBNI1Null()
            {
                this[this.tableEVIDENCIJARADNICISATI.ODTOGAPOSEBNI1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODTOGAPOSEBNI2Null()
            {
                this[this.tableEVIDENCIJARADNICISATI.ODTOGAPOSEBNI2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODTOGAPOSEBNI3Null()
            {
                this[this.tableEVIDENCIJARADNICISATI.ODTOGAPOSEBNI3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODTOGASMJENSKINull()
            {
                this[this.tableEVIDENCIJARADNICISATI.ODTOGASMJENSKIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODTOGASPECIJALNANull()
            {
                this[this.tableEVIDENCIJARADNICISATI.ODTOGASPECIJALNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.PDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRINull()
            {
                this[this.tableEVIDENCIJARADNICISATI.PRIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.PRColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRVASMJENAIDSMJENENull()
            {
                this[this.tableEVIDENCIJARADNICISATI.PRVASMJENAIDSMJENEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRVASMJENAOPISSMJENENull()
            {
                this[this.tableEVIDENCIJARADNICISATI.PRVASMJENAOPISSMJENEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRVASMJENAPOCETAKNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.PRVASMJENAPOCETAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRVASMJENAZAVRSETAKNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.PRVASMJENAZAVRSETAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRVNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.PRVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRDNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.RDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRRNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.RRColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSPNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.SPColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTRNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.STRColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTRNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.TRColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZASNull()
            {
                this[this.tableEVIDENCIJARADNICISATI.ZASColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal BLG
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.BLGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.BLGColumn] = value;
                }
            }

            public decimal BOF
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.BOFColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.BOFColumn] = value;
                }
            }

            public decimal BOP
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.BOPColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.BOPColumn] = value;
                }
            }

            public int BROJEVIDENCIJE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableEVIDENCIJARADNICISATI.BROJEVIDENCIJEColumn]);
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.BROJEVIDENCIJEColumn] = value;
                }
            }

            public int DAN
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableEVIDENCIJARADNICISATI.DANColumn]);
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.DANColumn] = value;
                }
            }

            public int DRUGASMJENAIDSMJENE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableEVIDENCIJARADNICISATI.DRUGASMJENAIDSMJENEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.DRUGASMJENAIDSMJENEColumn] = value;
                }
            }

            public string DRUGASMJENAOPISSMJENE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableEVIDENCIJARADNICISATI.DRUGASMJENAOPISSMJENEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.DRUGASMJENAOPISSMJENEColumn] = value;
                }
            }

            public string DRUGASMJENAPOCETAK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableEVIDENCIJARADNICISATI.DRUGASMJENAPOCETAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.DRUGASMJENAPOCETAKColumn] = value;
                }
            }

            public string DRUGASMJENAZAVRSETAK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableEVIDENCIJARADNICISATI.DRUGASMJENAZAVRSETAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.DRUGASMJENAZAVRSETAKColumn] = value;
                }
            }

            public decimal GO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.GOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.GOColumn] = value;
                }
            }

            public short IDGODINE
            {
                get
                {
                    return Conversions.ToShort(this[this.tableEVIDENCIJARADNICISATI.IDGODINEColumn]);
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.IDGODINEColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableEVIDENCIJARADNICISATI.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.IDRADNIKColumn] = value;
                }
            }

            public decimal IZNADNORME
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.IZNADNORMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.IZNADNORMEColumn] = value;
                }
            }

            public decimal LOC
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.LOCColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.LOCColumn] = value;
                }
            }

            public int MJESEC
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableEVIDENCIJARADNICISATI.MJESECColumn]);
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.MJESECColumn] = value;
                }
            }

            public decimal NED
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.NEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.NEDColumn] = value;
                }
            }

            public decimal NEN
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.NENColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.NENColumn] = value;
                }
            }

            public decimal NENNEODOBRENA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.NENNEODOBRENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.NENNEODOBRENAColumn] = value;
                }
            }

            public decimal NOC
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.NOCColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.NOCColumn] = value;
                }
            }

            public decimal NPD
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.NPDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.NPDColumn] = value;
                }
            }

            public decimal ODTOGADVOKRATNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.ODTOGADVOKRATNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.ODTOGADVOKRATNIColumn] = value;
                }
            }

            public decimal ODTOGAKOMBINACIJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.ODTOGAKOMBINACIJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.ODTOGAKOMBINACIJAColumn] = value;
                }
            }

            public decimal ODTOGAPOSEBNI1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.ODTOGAPOSEBNI1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.ODTOGAPOSEBNI1Column] = value;
                }
            }

            public decimal ODTOGAPOSEBNI2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.ODTOGAPOSEBNI2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.ODTOGAPOSEBNI2Column] = value;
                }
            }

            public decimal ODTOGAPOSEBNI3
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.ODTOGAPOSEBNI3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.ODTOGAPOSEBNI3Column] = value;
                }
            }

            public decimal ODTOGASMJENSKI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.ODTOGASMJENSKIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.ODTOGASMJENSKIColumn] = value;
                }
            }

            public decimal ODTOGASPECIJALNA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.ODTOGASPECIJALNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.ODTOGASPECIJALNAColumn] = value;
                }
            }

            public decimal PD
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.PDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.PDColumn] = value;
                }
            }

            public decimal PR
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.PRColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.PRColumn] = value;
                }
            }

            public decimal PRI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.PRIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.PRIColumn] = value;
                }
            }

            public decimal PRV
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.PRVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.PRVColumn] = value;
                }
            }

            public int PRVASMJENAIDSMJENE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableEVIDENCIJARADNICISATI.PRVASMJENAIDSMJENEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.PRVASMJENAIDSMJENEColumn] = value;
                }
            }

            public string PRVASMJENAOPISSMJENE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableEVIDENCIJARADNICISATI.PRVASMJENAOPISSMJENEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.PRVASMJENAOPISSMJENEColumn] = value;
                }
            }

            public string PRVASMJENAPOCETAK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableEVIDENCIJARADNICISATI.PRVASMJENAPOCETAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.PRVASMJENAPOCETAKColumn] = value;
                }
            }

            public string PRVASMJENAZAVRSETAK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableEVIDENCIJARADNICISATI.PRVASMJENAZAVRSETAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.PRVASMJENAZAVRSETAKColumn] = value;
                }
            }

            public decimal RD
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.RDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.RDColumn] = value;
                }
            }

            public decimal RR
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.RRColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.RRColumn] = value;
                }
            }

            public decimal SP
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.SPColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.SPColumn] = value;
                }
            }

            public decimal STR
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.STRColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.STRColumn] = value;
                }
            }

            public decimal TR
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.TRColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.TRColumn] = value;
                }
            }

            public decimal ZAS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableEVIDENCIJARADNICISATI.ZASColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableEVIDENCIJARADNICISATI.ZASColumn] = value;
                }
            }
        }

        public class EVIDENCIJARADNICISATIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow eventRow;

            public EVIDENCIJARADNICISATIRowChangeEvent(EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow row, DataRowAction action)
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

            public EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void EVIDENCIJARADNICISATIRowChangeEventHandler(object sender, EVIDENCIJADataSet.EVIDENCIJARADNICISATIRowChangeEvent e);

        public class EVIDENCIJARow : DataRow
        {
            private EVIDENCIJADataSet.EVIDENCIJADataTable tableEVIDENCIJA;

            internal EVIDENCIJARow(DataRowBuilder rb) : base(rb)
            {
                this.tableEVIDENCIJA = (EVIDENCIJADataSet.EVIDENCIJADataTable) this.Table;
            }

            public EVIDENCIJADataSet.EVIDENCIJARADNICIRow[] GetEVIDENCIJARADNICIRows()
            {
                return (EVIDENCIJADataSet.EVIDENCIJARADNICIRow[]) this.GetChildRows("EVIDENCIJA_EVIDENCIJARADNICI");
            }

            public bool IsBROJEVIDENCIJENull()
            {
                return this.IsNull(this.tableEVIDENCIJA.BROJEVIDENCIJEColumn);
            }

            public bool IsIDGODINENull()
            {
                return this.IsNull(this.tableEVIDENCIJA.IDGODINEColumn);
            }

            public bool IsMJESECNull()
            {
                return this.IsNull(this.tableEVIDENCIJA.MJESECColumn);
            }

            public bool IsOPISEVIDENCIJENull()
            {
                return this.IsNull(this.tableEVIDENCIJA.OPISEVIDENCIJEColumn);
            }

            public void SetOPISEVIDENCIJENull()
            {
                this[this.tableEVIDENCIJA.OPISEVIDENCIJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BROJEVIDENCIJE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableEVIDENCIJA.BROJEVIDENCIJEColumn]);
                }
                set
                {
                    this[this.tableEVIDENCIJA.BROJEVIDENCIJEColumn] = value;
                }
            }

            public short IDGODINE
            {
                get
                {
                    return Conversions.ToShort(this[this.tableEVIDENCIJA.IDGODINEColumn]);
                }
                set
                {
                    this[this.tableEVIDENCIJA.IDGODINEColumn] = value;
                }
            }

            public int MJESEC
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableEVIDENCIJA.MJESECColumn]);
                }
                set
                {
                    this[this.tableEVIDENCIJA.MJESECColumn] = value;
                }
            }

            public string OPISEVIDENCIJE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableEVIDENCIJA.OPISEVIDENCIJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableEVIDENCIJA.OPISEVIDENCIJEColumn] = value;
                }
            }
        }

        public class EVIDENCIJARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private EVIDENCIJADataSet.EVIDENCIJARow eventRow;

            public EVIDENCIJARowChangeEvent(EVIDENCIJADataSet.EVIDENCIJARow row, DataRowAction action)
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

            public EVIDENCIJADataSet.EVIDENCIJARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void EVIDENCIJARowChangeEventHandler(object sender, EVIDENCIJADataSet.EVIDENCIJARowChangeEvent e);
    }
}

