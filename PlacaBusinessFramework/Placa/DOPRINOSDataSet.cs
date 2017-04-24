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
    public class DOPRINOSDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private DOPRINOSDataTable tableDOPRINOS;

        public DOPRINOSDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected DOPRINOSDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["DOPRINOS"] != null)
                    {
                        this.Tables.Add(new DOPRINOSDataTable(dataSet.Tables["DOPRINOS"]));
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
            DOPRINOSDataSet set = (DOPRINOSDataSet) base.Clone();
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
            DOPRINOSDataSet set = new DOPRINOSDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "DOPRINOSDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1004");
            this.ExtendedProperties.Add("DataSetName", "DOPRINOSDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IDOPRINOSDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "DOPRINOS");
            this.ExtendedProperties.Add("ObjectDescription", "Doprinosi");
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
            this.DataSetName = "DOPRINOSDataSet";
            this.Namespace = "http://www.tempuri.org/DOPRINOS";
            this.tableDOPRINOS = new DOPRINOSDataTable();
            this.Tables.Add(this.tableDOPRINOS);
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
            this.tableDOPRINOS = (DOPRINOSDataTable) this.Tables["DOPRINOS"];
            if (initTable && (this.tableDOPRINOS != null))
            {
                this.tableDOPRINOS.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["DOPRINOS"] != null)
                {
                    this.Tables.Add(new DOPRINOSDataTable(dataSet.Tables["DOPRINOS"]));
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

        private bool ShouldSerializeDOPRINOS()
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
        public DOPRINOSDataTable DOPRINOS
        {
            get
            {
                return this.tableDOPRINOS;
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
        public class DOPRINOSDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDDOPRINOS;
            private DataColumn columnIDVRSTADOPRINOS;
            private DataColumn columnMAXDOPRINOS;
            private DataColumn columnMINDOPRINOS;
            private DataColumn columnMODOPRINOS;
            private DataColumn columnMZDOPRINOS;
            private DataColumn columnNAZIVDOPRINOS;
            private DataColumn columnNAZIVVRSTADOPRINOS;
            private DataColumn columnOPISPLACANJADOPRINOS;
            private DataColumn columnPODOPRINOS;
            private DataColumn columnPRIMATELJDOPRINOS1;
            private DataColumn columnPRIMATELJDOPRINOS2;
            private DataColumn columnPZDOPRINOS;
            private DataColumn columnSIFRAOPISAPLACANJADOPRINOS;
            private DataColumn columnSTOPA;
            private DataColumn columnVBDIDOPRINOS;
            private DataColumn columnZRNDOPRINOS;

            public event DOPRINOSDataSet.DOPRINOSRowChangeEventHandler DOPRINOSRowChanged;

            public event DOPRINOSDataSet.DOPRINOSRowChangeEventHandler DOPRINOSRowChanging;

            public event DOPRINOSDataSet.DOPRINOSRowChangeEventHandler DOPRINOSRowDeleted;

            public event DOPRINOSDataSet.DOPRINOSRowChangeEventHandler DOPRINOSRowDeleting;

            public DOPRINOSDataTable()
            {
                this.TableName = "DOPRINOS";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DOPRINOSDataTable(DataTable table) : base(table.TableName)
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

            protected DOPRINOSDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDOPRINOSRow(DOPRINOSDataSet.DOPRINOSRow row)
            {
                this.Rows.Add(row);
            }

            public DOPRINOSDataSet.DOPRINOSRow AddDOPRINOSRow(int iDDOPRINOS, string nAZIVDOPRINOS, int iDVRSTADOPRINOS, decimal sTOPA, string mODOPRINOS, string pODOPRINOS, string mZDOPRINOS, string pZDOPRINOS, string pRIMATELJDOPRINOS1, string pRIMATELJDOPRINOS2, string sIFRAOPISAPLACANJADOPRINOS, string oPISPLACANJADOPRINOS, string vBDIDOPRINOS, string zRNDOPRINOS, decimal mINDOPRINOS, decimal mAXDOPRINOS)
            {
                DOPRINOSDataSet.DOPRINOSRow row = (DOPRINOSDataSet.DOPRINOSRow) this.NewRow();
                row["IDDOPRINOS"] = iDDOPRINOS;
                row["NAZIVDOPRINOS"] = nAZIVDOPRINOS;
                row["IDVRSTADOPRINOS"] = iDVRSTADOPRINOS;
                row["STOPA"] = sTOPA;
                row["MODOPRINOS"] = mODOPRINOS;
                row["PODOPRINOS"] = pODOPRINOS;
                row["MZDOPRINOS"] = mZDOPRINOS;
                row["PZDOPRINOS"] = pZDOPRINOS;
                row["PRIMATELJDOPRINOS1"] = pRIMATELJDOPRINOS1;
                row["PRIMATELJDOPRINOS2"] = pRIMATELJDOPRINOS2;
                row["SIFRAOPISAPLACANJADOPRINOS"] = sIFRAOPISAPLACANJADOPRINOS;
                row["OPISPLACANJADOPRINOS"] = oPISPLACANJADOPRINOS;
                row["VBDIDOPRINOS"] = vBDIDOPRINOS;
                row["ZRNDOPRINOS"] = zRNDOPRINOS;
                row["MINDOPRINOS"] = mINDOPRINOS;
                row["MAXDOPRINOS"] = mAXDOPRINOS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DOPRINOSDataSet.DOPRINOSDataTable table = (DOPRINOSDataSet.DOPRINOSDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DOPRINOSDataSet.DOPRINOSRow FindByIDDOPRINOS(int iDDOPRINOS)
            {
                return (DOPRINOSDataSet.DOPRINOSRow) this.Rows.Find(new object[] { iDDOPRINOS });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DOPRINOSDataSet.DOPRINOSRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DOPRINOSDataSet set = new DOPRINOSDataSet();
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
                this.columnIDDOPRINOS = new DataColumn("IDDOPRINOS", typeof(int), "", MappingType.Element);
                this.columnIDDOPRINOS.AllowDBNull = false;
                this.columnIDDOPRINOS.Caption = "Šifra doprinosa";
                this.columnIDDOPRINOS.Unique = true;
                this.columnIDDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDDOPRINOS.ExtendedProperties.Add("IsKey", "true");
                this.columnIDDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Description", "Šifra doprinosa");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Length", "8");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnIDDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "IDDOPRINOS");
                this.Columns.Add(this.columnIDDOPRINOS);
                this.columnNAZIVDOPRINOS = new DataColumn("NAZIVDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnNAZIVDOPRINOS.AllowDBNull = false;
                this.columnNAZIVDOPRINOS.Caption = "Naziv doprinosa";
                this.columnNAZIVDOPRINOS.MaxLength = 50;
                this.columnNAZIVDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Description", "Naziv doprinosa");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVDOPRINOS");
                this.Columns.Add(this.columnNAZIVDOPRINOS);
                this.columnIDVRSTADOPRINOS = new DataColumn("IDVRSTADOPRINOS", typeof(int), "", MappingType.Element);
                this.columnIDVRSTADOPRINOS.AllowDBNull = false;
                this.columnIDVRSTADOPRINOS.Caption = "Šifra vrste doprinosa";
                this.columnIDVRSTADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Description", "Šifra vrste doprinosa");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Length", "5");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "IDVRSTADOPRINOS");
                this.Columns.Add(this.columnIDVRSTADOPRINOS);
                this.columnNAZIVVRSTADOPRINOS = new DataColumn("NAZIVVRSTADOPRINOS", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTADOPRINOS.AllowDBNull = true;
                this.columnNAZIVVRSTADOPRINOS.Caption = "Naziv vrste doprinosa";
                this.columnNAZIVVRSTADOPRINOS.MaxLength = 50;
                this.columnNAZIVVRSTADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Description", "Naziv vrste doprinosa");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTADOPRINOS");
                this.Columns.Add(this.columnNAZIVVRSTADOPRINOS);
                this.columnSTOPA = new DataColumn("STOPA", typeof(decimal), "", MappingType.Element);
                this.columnSTOPA.AllowDBNull = false;
                this.columnSTOPA.Caption = "STOPA";
                this.columnSTOPA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPA.ExtendedProperties.Add("Description", "STOPA");
                this.columnSTOPA.ExtendedProperties.Add("Length", "5");
                this.columnSTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnSTOPA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSTOPA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.InternalName", "STOPA");
                this.Columns.Add(this.columnSTOPA);
                this.columnMODOPRINOS = new DataColumn("MODOPRINOS", typeof(string), "", MappingType.Element);
                this.columnMODOPRINOS.AllowDBNull = false;
                this.columnMODOPRINOS.Caption = "Model odobrenja doprinosa";
                this.columnMODOPRINOS.MaxLength = 2;
                this.columnMODOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMODOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnMODOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMODOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMODOPRINOS.ExtendedProperties.Add("Description", "Model odobrenja doprinosa");
                this.columnMODOPRINOS.ExtendedProperties.Add("Length", "2");
                this.columnMODOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnMODOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMODOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "MODOPRINOS");
                this.Columns.Add(this.columnMODOPRINOS);
                this.columnPODOPRINOS = new DataColumn("PODOPRINOS", typeof(string), "", MappingType.Element);
                this.columnPODOPRINOS.AllowDBNull = false;
                this.columnPODOPRINOS.Caption = "Poziv odobrenja doprinosa";
                this.columnPODOPRINOS.MaxLength = 0x16;
                this.columnPODOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPODOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnPODOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPODOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPODOPRINOS.ExtendedProperties.Add("Description", "Poziv odobrenja doprinosa");
                this.columnPODOPRINOS.ExtendedProperties.Add("Length", "22");
                this.columnPODOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnPODOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPODOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "PODOPRINOS");
                this.Columns.Add(this.columnPODOPRINOS);
                this.columnMZDOPRINOS = new DataColumn("MZDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnMZDOPRINOS.AllowDBNull = true;
                this.columnMZDOPRINOS.Caption = "Model zaduženja doprinosa";
                this.columnMZDOPRINOS.MaxLength = 2;
                this.columnMZDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnMZDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMZDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Description", "Model zaduženja doprinosa");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Length", "2");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnMZDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZDOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "MZDOPRINOS");
                this.Columns.Add(this.columnMZDOPRINOS);
                this.columnPZDOPRINOS = new DataColumn("PZDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnPZDOPRINOS.AllowDBNull = true;
                this.columnPZDOPRINOS.Caption = "Poziv zaduženja doprinosa";
                this.columnPZDOPRINOS.MaxLength = 0x16;
                this.columnPZDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnPZDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPZDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Description", "Poziv zaduženja doprinosa");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Length", "22");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnPZDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZDOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "PZDOPRINOS");
                this.Columns.Add(this.columnPZDOPRINOS);
                this.columnPRIMATELJDOPRINOS1 = new DataColumn("PRIMATELJDOPRINOS1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJDOPRINOS1.AllowDBNull = false;
                this.columnPRIMATELJDOPRINOS1.Caption = "Primatelj doprinosa";
                this.columnPRIMATELJDOPRINOS1.MaxLength = 20;
                this.columnPRIMATELJDOPRINOS1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Description", "Primatelj doprinosa");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJDOPRINOS1");
                this.Columns.Add(this.columnPRIMATELJDOPRINOS1);
                this.columnPRIMATELJDOPRINOS2 = new DataColumn("PRIMATELJDOPRINOS2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJDOPRINOS2.AllowDBNull = true;
                this.columnPRIMATELJDOPRINOS2.Caption = "Primatelj doprinosa (2)";
                this.columnPRIMATELJDOPRINOS2.MaxLength = 20;
                this.columnPRIMATELJDOPRINOS2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Description", "Primatelj doprinosa (2)");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJDOPRINOS2");
                this.Columns.Add(this.columnPRIMATELJDOPRINOS2);
                this.columnSIFRAOPISAPLACANJADOPRINOS = new DataColumn("SIFRAOPISAPLACANJADOPRINOS", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJADOPRINOS.AllowDBNull = false;
                this.columnSIFRAOPISAPLACANJADOPRINOS.Caption = "Šifra opisa plaćanja doprinosa";
                this.columnSIFRAOPISAPLACANJADOPRINOS.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Description", "Šifra opisa plaćanja doprinosa");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJADOPRINOS");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJADOPRINOS);
                this.columnOPISPLACANJADOPRINOS = new DataColumn("OPISPLACANJADOPRINOS", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJADOPRINOS.AllowDBNull = false;
                this.columnOPISPLACANJADOPRINOS.Caption = "Opis plaćanja doprinosa";
                this.columnOPISPLACANJADOPRINOS.MaxLength = 0x24;
                this.columnOPISPLACANJADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Description", "Opis plaćanja doprinosa");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJADOPRINOS");
                this.Columns.Add(this.columnOPISPLACANJADOPRINOS);
                this.columnVBDIDOPRINOS = new DataColumn("VBDIDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnVBDIDOPRINOS.AllowDBNull = false;
                this.columnVBDIDOPRINOS.Caption = "VBDI za doprinos";
                this.columnVBDIDOPRINOS.MaxLength = 7;
                this.columnVBDIDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Description", "VBDI");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Length", "7");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "VBDIDOPRINOS");
                this.Columns.Add(this.columnVBDIDOPRINOS);
                this.columnZRNDOPRINOS = new DataColumn("ZRNDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnZRNDOPRINOS.AllowDBNull = false;
                this.columnZRNDOPRINOS.Caption = "Žiro račun za doprinos";
                this.columnZRNDOPRINOS.MaxLength = 10;
                this.columnZRNDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Description", "Žiro račun");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Length", "10");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "ZRNDOPRINOS");
                this.Columns.Add(this.columnZRNDOPRINOS);
                this.columnMINDOPRINOS = new DataColumn("MINDOPRINOS", typeof(decimal), "", MappingType.Element);
                this.columnMINDOPRINOS.AllowDBNull = false;
                this.columnMINDOPRINOS.Caption = "Minimalna osnovica za obračun doprinosa";
                this.columnMINDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMINDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnMINDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMINDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Description", "Min. osnovica za obračun doprinosa");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Length", "12");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Decimals", "2");
                this.columnMINDOPRINOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMINDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMINDOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "MINDOPRINOS");
                this.Columns.Add(this.columnMINDOPRINOS);
                this.columnMAXDOPRINOS = new DataColumn("MAXDOPRINOS", typeof(decimal), "", MappingType.Element);
                this.columnMAXDOPRINOS.AllowDBNull = false;
                this.columnMAXDOPRINOS.Caption = "Maksimalna osnovica za obračun doprinosa";
                this.columnMAXDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Description", "Maks. osnovica za obračun doprinosa");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Length", "12");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Decimals", "2");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "MAXDOPRINOS");
                this.Columns.Add(this.columnMAXDOPRINOS);
                this.PrimaryKey = new DataColumn[] { this.columnIDDOPRINOS };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "DOPRINOS");
                this.ExtendedProperties.Add("Description", "Doprinosi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDDOPRINOS = this.Columns["IDDOPRINOS"];
                this.columnNAZIVDOPRINOS = this.Columns["NAZIVDOPRINOS"];
                this.columnIDVRSTADOPRINOS = this.Columns["IDVRSTADOPRINOS"];
                this.columnNAZIVVRSTADOPRINOS = this.Columns["NAZIVVRSTADOPRINOS"];
                this.columnSTOPA = this.Columns["STOPA"];
                this.columnMODOPRINOS = this.Columns["MODOPRINOS"];
                this.columnPODOPRINOS = this.Columns["PODOPRINOS"];
                this.columnMZDOPRINOS = this.Columns["MZDOPRINOS"];
                this.columnPZDOPRINOS = this.Columns["PZDOPRINOS"];
                this.columnPRIMATELJDOPRINOS1 = this.Columns["PRIMATELJDOPRINOS1"];
                this.columnPRIMATELJDOPRINOS2 = this.Columns["PRIMATELJDOPRINOS2"];
                this.columnSIFRAOPISAPLACANJADOPRINOS = this.Columns["SIFRAOPISAPLACANJADOPRINOS"];
                this.columnOPISPLACANJADOPRINOS = this.Columns["OPISPLACANJADOPRINOS"];
                this.columnVBDIDOPRINOS = this.Columns["VBDIDOPRINOS"];
                this.columnZRNDOPRINOS = this.Columns["ZRNDOPRINOS"];
                this.columnMINDOPRINOS = this.Columns["MINDOPRINOS"];
                this.columnMAXDOPRINOS = this.Columns["MAXDOPRINOS"];
            }

            public DOPRINOSDataSet.DOPRINOSRow NewDOPRINOSRow()
            {
                return (DOPRINOSDataSet.DOPRINOSRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DOPRINOSDataSet.DOPRINOSRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DOPRINOSRowChanged != null)
                {
                    DOPRINOSDataSet.DOPRINOSRowChangeEventHandler dOPRINOSRowChangedEvent = this.DOPRINOSRowChanged;
                    if (dOPRINOSRowChangedEvent != null)
                    {
                        dOPRINOSRowChangedEvent(this, new DOPRINOSDataSet.DOPRINOSRowChangeEvent((DOPRINOSDataSet.DOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DOPRINOSRowChanging != null)
                {
                    DOPRINOSDataSet.DOPRINOSRowChangeEventHandler dOPRINOSRowChangingEvent = this.DOPRINOSRowChanging;
                    if (dOPRINOSRowChangingEvent != null)
                    {
                        dOPRINOSRowChangingEvent(this, new DOPRINOSDataSet.DOPRINOSRowChangeEvent((DOPRINOSDataSet.DOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DOPRINOSRowDeleted != null)
                {
                    DOPRINOSDataSet.DOPRINOSRowChangeEventHandler dOPRINOSRowDeletedEvent = this.DOPRINOSRowDeleted;
                    if (dOPRINOSRowDeletedEvent != null)
                    {
                        dOPRINOSRowDeletedEvent(this, new DOPRINOSDataSet.DOPRINOSRowChangeEvent((DOPRINOSDataSet.DOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DOPRINOSRowDeleting != null)
                {
                    DOPRINOSDataSet.DOPRINOSRowChangeEventHandler dOPRINOSRowDeletingEvent = this.DOPRINOSRowDeleting;
                    if (dOPRINOSRowDeletingEvent != null)
                    {
                        dOPRINOSRowDeletingEvent(this, new DOPRINOSDataSet.DOPRINOSRowChangeEvent((DOPRINOSDataSet.DOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDOPRINOSRow(DOPRINOSDataSet.DOPRINOSRow row)
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

            public DataColumn IDDOPRINOSColumn
            {
                get
                {
                    return this.columnIDDOPRINOS;
                }
            }

            public DataColumn IDVRSTADOPRINOSColumn
            {
                get
                {
                    return this.columnIDVRSTADOPRINOS;
                }
            }

            public DOPRINOSDataSet.DOPRINOSRow this[int index]
            {
                get
                {
                    return (DOPRINOSDataSet.DOPRINOSRow) this.Rows[index];
                }
            }

            public DataColumn MAXDOPRINOSColumn
            {
                get
                {
                    return this.columnMAXDOPRINOS;
                }
            }

            public DataColumn MINDOPRINOSColumn
            {
                get
                {
                    return this.columnMINDOPRINOS;
                }
            }

            public DataColumn MODOPRINOSColumn
            {
                get
                {
                    return this.columnMODOPRINOS;
                }
            }

            public DataColumn MZDOPRINOSColumn
            {
                get
                {
                    return this.columnMZDOPRINOS;
                }
            }

            public DataColumn NAZIVDOPRINOSColumn
            {
                get
                {
                    return this.columnNAZIVDOPRINOS;
                }
            }

            public DataColumn NAZIVVRSTADOPRINOSColumn
            {
                get
                {
                    return this.columnNAZIVVRSTADOPRINOS;
                }
            }

            public DataColumn OPISPLACANJADOPRINOSColumn
            {
                get
                {
                    return this.columnOPISPLACANJADOPRINOS;
                }
            }

            public DataColumn PODOPRINOSColumn
            {
                get
                {
                    return this.columnPODOPRINOS;
                }
            }

            public DataColumn PRIMATELJDOPRINOS1Column
            {
                get
                {
                    return this.columnPRIMATELJDOPRINOS1;
                }
            }

            public DataColumn PRIMATELJDOPRINOS2Column
            {
                get
                {
                    return this.columnPRIMATELJDOPRINOS2;
                }
            }

            public DataColumn PZDOPRINOSColumn
            {
                get
                {
                    return this.columnPZDOPRINOS;
                }
            }

            public DataColumn SIFRAOPISAPLACANJADOPRINOSColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJADOPRINOS;
                }
            }

            public DataColumn STOPAColumn
            {
                get
                {
                    return this.columnSTOPA;
                }
            }

            public DataColumn VBDIDOPRINOSColumn
            {
                get
                {
                    return this.columnVBDIDOPRINOS;
                }
            }

            public DataColumn ZRNDOPRINOSColumn
            {
                get
                {
                    return this.columnZRNDOPRINOS;
                }
            }
        }

        public class DOPRINOSRow : DataRow
        {
            private DOPRINOSDataSet.DOPRINOSDataTable tableDOPRINOS;

            internal DOPRINOSRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDOPRINOS = (DOPRINOSDataSet.DOPRINOSDataTable) this.Table;
            }

            public bool IsIDDOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.IDDOPRINOSColumn);
            }

            public bool IsIDVRSTADOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.IDVRSTADOPRINOSColumn);
            }

            public bool IsMAXDOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.MAXDOPRINOSColumn);
            }

            public bool IsMINDOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.MINDOPRINOSColumn);
            }

            public bool IsMODOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.MODOPRINOSColumn);
            }

            public bool IsMZDOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.MZDOPRINOSColumn);
            }

            public bool IsNAZIVDOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.NAZIVDOPRINOSColumn);
            }

            public bool IsNAZIVVRSTADOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.NAZIVVRSTADOPRINOSColumn);
            }

            public bool IsOPISPLACANJADOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.OPISPLACANJADOPRINOSColumn);
            }

            public bool IsPODOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.PODOPRINOSColumn);
            }

            public bool IsPRIMATELJDOPRINOS1Null()
            {
                return this.IsNull(this.tableDOPRINOS.PRIMATELJDOPRINOS1Column);
            }

            public bool IsPRIMATELJDOPRINOS2Null()
            {
                return this.IsNull(this.tableDOPRINOS.PRIMATELJDOPRINOS2Column);
            }

            public bool IsPZDOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.PZDOPRINOSColumn);
            }

            public bool IsSIFRAOPISAPLACANJADOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.SIFRAOPISAPLACANJADOPRINOSColumn);
            }

            public bool IsSTOPANull()
            {
                return this.IsNull(this.tableDOPRINOS.STOPAColumn);
            }

            public bool IsVBDIDOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.VBDIDOPRINOSColumn);
            }

            public bool IsZRNDOPRINOSNull()
            {
                return this.IsNull(this.tableDOPRINOS.ZRNDOPRINOSColumn);
            }

            public void SetIDVRSTADOPRINOSNull()
            {
                this[this.tableDOPRINOS.IDVRSTADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMAXDOPRINOSNull()
            {
                this[this.tableDOPRINOS.MAXDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMINDOPRINOSNull()
            {
                this[this.tableDOPRINOS.MINDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMODOPRINOSNull()
            {
                this[this.tableDOPRINOS.MODOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZDOPRINOSNull()
            {
                this[this.tableDOPRINOS.MZDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVDOPRINOSNull()
            {
                this[this.tableDOPRINOS.NAZIVDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVVRSTADOPRINOSNull()
            {
                this[this.tableDOPRINOS.NAZIVVRSTADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJADOPRINOSNull()
            {
                this[this.tableDOPRINOS.OPISPLACANJADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPODOPRINOSNull()
            {
                this[this.tableDOPRINOS.PODOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJDOPRINOS1Null()
            {
                this[this.tableDOPRINOS.PRIMATELJDOPRINOS1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJDOPRINOS2Null()
            {
                this[this.tableDOPRINOS.PRIMATELJDOPRINOS2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZDOPRINOSNull()
            {
                this[this.tableDOPRINOS.PZDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJADOPRINOSNull()
            {
                this[this.tableDOPRINOS.SIFRAOPISAPLACANJADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPANull()
            {
                this[this.tableDOPRINOS.STOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIDOPRINOSNull()
            {
                this[this.tableDOPRINOS.VBDIDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNDOPRINOSNull()
            {
                this[this.tableDOPRINOS.ZRNDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDDOPRINOS
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDOPRINOS.IDDOPRINOSColumn]);
                }
                set
                {
                    this[this.tableDOPRINOS.IDDOPRINOSColumn] = value;
                }
            }

            public int IDVRSTADOPRINOS
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableDOPRINOS.IDVRSTADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDVRSTADOPRINOS because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOPRINOS.IDVRSTADOPRINOSColumn] = value;
                }
            }

            public decimal MAXDOPRINOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDOPRINOS.MAXDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOPRINOS.MAXDOPRINOSColumn] = value;
                }
            }

            public decimal MINDOPRINOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDOPRINOS.MINDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOPRINOS.MINDOPRINOSColumn] = value;
                }
            }

            public string MODOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOPRINOS.MODOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOPRINOS.MODOPRINOSColumn] = value;
                }
            }

            public string MZDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOPRINOS.MZDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOPRINOS.MZDOPRINOSColumn] = value;
                }
            }

            public string NAZIVDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOPRINOS.NAZIVDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOPRINOS.NAZIVDOPRINOSColumn] = value;
                }
            }

            public string NAZIVVRSTADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOPRINOS.NAZIVVRSTADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOPRINOS.NAZIVVRSTADOPRINOSColumn] = value;
                }
            }

            public string OPISPLACANJADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOPRINOS.OPISPLACANJADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOPRINOS.OPISPLACANJADOPRINOSColumn] = value;
                }
            }

            public string PODOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOPRINOS.PODOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOPRINOS.PODOPRINOSColumn] = value;
                }
            }

            public string PRIMATELJDOPRINOS1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOPRINOS.PRIMATELJDOPRINOS1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOPRINOS.PRIMATELJDOPRINOS1Column] = value;
                }
            }

            public string PRIMATELJDOPRINOS2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOPRINOS.PRIMATELJDOPRINOS2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOPRINOS.PRIMATELJDOPRINOS2Column] = value;
                }
            }

            public string PZDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOPRINOS.PZDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOPRINOS.PZDOPRINOSColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOPRINOS.SIFRAOPISAPLACANJADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOPRINOS.SIFRAOPISAPLACANJADOPRINOSColumn] = value;
                }
            }

            public decimal STOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDOPRINOS.STOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOPRINOS.STOPAColumn] = value;
                }
            }

            public string VBDIDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOPRINOS.VBDIDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOPRINOS.VBDIDOPRINOSColumn] = value;
                }
            }

            public string ZRNDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOPRINOS.ZRNDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOPRINOS.ZRNDOPRINOSColumn] = value;
                }
            }
        }

        public class DOPRINOSRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DOPRINOSDataSet.DOPRINOSRow eventRow;

            public DOPRINOSRowChangeEvent(DOPRINOSDataSet.DOPRINOSRow row, DataRowAction action)
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

            public DOPRINOSDataSet.DOPRINOSRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DOPRINOSRowChangeEventHandler(object sender, DOPRINOSDataSet.DOPRINOSRowChangeEvent e);
    }
}

