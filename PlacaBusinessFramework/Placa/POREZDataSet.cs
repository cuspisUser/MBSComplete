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
    public class POREZDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private POREZDataTable tablePOREZ;

        public POREZDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected POREZDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["POREZ"] != null)
                    {
                        this.Tables.Add(new POREZDataTable(dataSet.Tables["POREZ"]));
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
            POREZDataSet set = (POREZDataSet) base.Clone();
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
            POREZDataSet set = new POREZDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "POREZDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1015");
            this.ExtendedProperties.Add("DataSetName", "POREZDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IPOREZDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "POREZ");
            this.ExtendedProperties.Add("ObjectDescription", "Porezi");
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
            this.DataSetName = "POREZDataSet";
            this.Namespace = "http://www.tempuri.org/POREZ";
            this.tablePOREZ = new POREZDataTable();
            this.Tables.Add(this.tablePOREZ);
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
            this.tablePOREZ = (POREZDataTable) this.Tables["POREZ"];
            if (initTable && (this.tablePOREZ != null))
            {
                this.tablePOREZ.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["POREZ"] != null)
                {
                    this.Tables.Add(new POREZDataTable(dataSet.Tables["POREZ"]));
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

        private bool ShouldSerializePOREZ()
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
        public POREZDataTable POREZ
        {
            get
            {
                return this.tablePOREZ;
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
        public class POREZDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDPOREZ;
            private DataColumn columnMOPOREZ;
            private DataColumn columnMZPOREZ;
            private DataColumn columnNAZIVPOREZ;
            private DataColumn columnOPISPLACANJAPOREZ;
            private DataColumn columnPOPOREZ;
            private DataColumn columnPOREZMJESECNO;
            private DataColumn columnPRIMATELJPOREZ1;
            private DataColumn columnPRIMATELJPOREZ2;
            private DataColumn columnPZPOREZ;
            private DataColumn columnSIFRAOPISAPLACANJAPOREZ;
            private DataColumn columnSTOPAPOREZA;

            public event POREZDataSet.POREZRowChangeEventHandler POREZRowChanged;

            public event POREZDataSet.POREZRowChangeEventHandler POREZRowChanging;

            public event POREZDataSet.POREZRowChangeEventHandler POREZRowDeleted;

            public event POREZDataSet.POREZRowChangeEventHandler POREZRowDeleting;

            public POREZDataTable()
            {
                this.TableName = "POREZ";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal POREZDataTable(DataTable table) : base(table.TableName)
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

            protected POREZDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPOREZRow(POREZDataSet.POREZRow row)
            {
                this.Rows.Add(row);
            }

            public POREZDataSet.POREZRow AddPOREZRow(int iDPOREZ, string nAZIVPOREZ, decimal pOREZMJESECNO, decimal sTOPAPOREZA, string mOPOREZ, string pOPOREZ, string mZPOREZ, string pZPOREZ, string pRIMATELJPOREZ1, string pRIMATELJPOREZ2, string sIFRAOPISAPLACANJAPOREZ, string oPISPLACANJAPOREZ)
            {
                POREZDataSet.POREZRow row = (POREZDataSet.POREZRow) this.NewRow();
                row["IDPOREZ"] = iDPOREZ;
                row["NAZIVPOREZ"] = nAZIVPOREZ;
                row["POREZMJESECNO"] = pOREZMJESECNO;
                row["STOPAPOREZA"] = sTOPAPOREZA;
                row["MOPOREZ"] = mOPOREZ;
                row["POPOREZ"] = pOPOREZ;
                row["MZPOREZ"] = mZPOREZ;
                row["PZPOREZ"] = pZPOREZ;
                row["PRIMATELJPOREZ1"] = pRIMATELJPOREZ1;
                row["PRIMATELJPOREZ2"] = pRIMATELJPOREZ2;
                row["SIFRAOPISAPLACANJAPOREZ"] = sIFRAOPISAPLACANJAPOREZ;
                row["OPISPLACANJAPOREZ"] = oPISPLACANJAPOREZ;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                POREZDataSet.POREZDataTable table = (POREZDataSet.POREZDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public POREZDataSet.POREZRow FindByIDPOREZ(int iDPOREZ)
            {
                return (POREZDataSet.POREZRow) this.Rows.Find(new object[] { iDPOREZ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(POREZDataSet.POREZRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                POREZDataSet set = new POREZDataSet();
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
                this.columnIDPOREZ = new DataColumn("IDPOREZ", typeof(int), "", MappingType.Element);
                this.columnIDPOREZ.AllowDBNull = false;
                this.columnIDPOREZ.Caption = "Šifra poreza";
                this.columnIDPOREZ.Unique = true;
                this.columnIDPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPOREZ.ExtendedProperties.Add("IsKey", "true");
                this.columnIDPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPOREZ.ExtendedProperties.Add("Description", "Šifra poreza");
                this.columnIDPOREZ.ExtendedProperties.Add("Length", "5");
                this.columnIDPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "IDPOREZ");
                this.Columns.Add(this.columnIDPOREZ);
                this.columnNAZIVPOREZ = new DataColumn("NAZIVPOREZ", typeof(string), "", MappingType.Element);
                this.columnNAZIVPOREZ.AllowDBNull = false;
                this.columnNAZIVPOREZ.Caption = "Naziv poreza";
                this.columnNAZIVPOREZ.MaxLength = 50;
                this.columnNAZIVPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Description", "Naziv poreza");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPOREZ");
                this.Columns.Add(this.columnNAZIVPOREZ);
                this.columnPOREZMJESECNO = new DataColumn("POREZMJESECNO", typeof(decimal), "", MappingType.Element);
                this.columnPOREZMJESECNO.AllowDBNull = false;
                this.columnPOREZMJESECNO.Caption = "Maks. mjesečni iznos osnovice";
                this.columnPOREZMJESECNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Description", "Maks. mjesečni iznos osnovice");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Length", "12");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.InternalName", "POREZMJESECNO");
                this.Columns.Add(this.columnPOREZMJESECNO);
                this.columnSTOPAPOREZA = new DataColumn("STOPAPOREZA", typeof(decimal), "", MappingType.Element);
                this.columnSTOPAPOREZA.AllowDBNull = false;
                this.columnSTOPAPOREZA.Caption = "Stopa poreza";
                this.columnSTOPAPOREZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Description", "Stopa poreza");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Length", "4");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.InternalName", "STOPAPOREZA");
                this.Columns.Add(this.columnSTOPAPOREZA);
                this.columnMOPOREZ = new DataColumn("MOPOREZ", typeof(string), "", MappingType.Element);
                this.columnMOPOREZ.AllowDBNull = false;
                this.columnMOPOREZ.Caption = "Model odobrenja poreza";
                this.columnMOPOREZ.MaxLength = 2;
                this.columnMOPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnMOPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMOPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOPOREZ.ExtendedProperties.Add("Description", "Model odobrenja poreza");
                this.columnMOPOREZ.ExtendedProperties.Add("Length", "2");
                this.columnMOPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnMOPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMOPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "MOPOREZ");
                this.Columns.Add(this.columnMOPOREZ);
                this.columnPOPOREZ = new DataColumn("POPOREZ", typeof(string), "", MappingType.Element);
                this.columnPOPOREZ.AllowDBNull = false;
                this.columnPOPOREZ.Caption = "Poziv na broj odobrenja poreza";
                this.columnPOPOREZ.MaxLength = 0x16;
                this.columnPOPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPOPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOPOREZ.ExtendedProperties.Add("Description", "Poziv na broj odobrenja poreza");
                this.columnPOPOREZ.ExtendedProperties.Add("Length", "22");
                this.columnPOPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnPOPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "POPOREZ");
                this.Columns.Add(this.columnPOPOREZ);
                this.columnMZPOREZ = new DataColumn("MZPOREZ", typeof(string), "", MappingType.Element);
                this.columnMZPOREZ.AllowDBNull = true;
                this.columnMZPOREZ.Caption = "Model zaduženja poreza";
                this.columnMZPOREZ.MaxLength = 2;
                this.columnMZPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnMZPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMZPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZPOREZ.ExtendedProperties.Add("Description", "Model zaduženja poreza");
                this.columnMZPOREZ.ExtendedProperties.Add("Length", "2");
                this.columnMZPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnMZPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "MZPOREZ");
                this.Columns.Add(this.columnMZPOREZ);
                this.columnPZPOREZ = new DataColumn("PZPOREZ", typeof(string), "", MappingType.Element);
                this.columnPZPOREZ.AllowDBNull = true;
                this.columnPZPOREZ.Caption = "Poziv na broj zaduženja poreza";
                this.columnPZPOREZ.MaxLength = 0x16;
                this.columnPZPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPZPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPZPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZPOREZ.ExtendedProperties.Add("Description", "Poziv na broj zaduženja poreza");
                this.columnPZPOREZ.ExtendedProperties.Add("Length", "22");
                this.columnPZPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnPZPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "PZPOREZ");
                this.Columns.Add(this.columnPZPOREZ);
                this.columnPRIMATELJPOREZ1 = new DataColumn("PRIMATELJPOREZ1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJPOREZ1.AllowDBNull = false;
                this.columnPRIMATELJPOREZ1.Caption = "Primatelj poreza (1)";
                this.columnPRIMATELJPOREZ1.MaxLength = 20;
                this.columnPRIMATELJPOREZ1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Description", "Primatelj poreza (1)");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJPOREZ1");
                this.Columns.Add(this.columnPRIMATELJPOREZ1);
                this.columnPRIMATELJPOREZ2 = new DataColumn("PRIMATELJPOREZ2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJPOREZ2.AllowDBNull = true;
                this.columnPRIMATELJPOREZ2.Caption = "Primatelj poreza (2)";
                this.columnPRIMATELJPOREZ2.MaxLength = 20;
                this.columnPRIMATELJPOREZ2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Description", "Primatelj poreza (2)");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJPOREZ2");
                this.Columns.Add(this.columnPRIMATELJPOREZ2);
                this.columnSIFRAOPISAPLACANJAPOREZ = new DataColumn("SIFRAOPISAPLACANJAPOREZ", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAPOREZ.AllowDBNull = false;
                this.columnSIFRAOPISAPLACANJAPOREZ.Caption = "Šifra opisa plaćanja poreza";
                this.columnSIFRAOPISAPLACANJAPOREZ.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Description", "Šifra opisa plaćanja poreza");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAPOREZ");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAPOREZ);
                this.columnOPISPLACANJAPOREZ = new DataColumn("OPISPLACANJAPOREZ", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAPOREZ.AllowDBNull = false;
                this.columnOPISPLACANJAPOREZ.Caption = "Opis plaćanja poreza";
                this.columnOPISPLACANJAPOREZ.MaxLength = 0x24;
                this.columnOPISPLACANJAPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Description", "Opis plaćanja poreza");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAPOREZ");
                this.Columns.Add(this.columnOPISPLACANJAPOREZ);
                this.PrimaryKey = new DataColumn[] { this.columnIDPOREZ };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "POREZ");
                this.ExtendedProperties.Add("Description", "Porezi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDPOREZ = this.Columns["IDPOREZ"];
                this.columnNAZIVPOREZ = this.Columns["NAZIVPOREZ"];
                this.columnPOREZMJESECNO = this.Columns["POREZMJESECNO"];
                this.columnSTOPAPOREZA = this.Columns["STOPAPOREZA"];
                this.columnMOPOREZ = this.Columns["MOPOREZ"];
                this.columnPOPOREZ = this.Columns["POPOREZ"];
                this.columnMZPOREZ = this.Columns["MZPOREZ"];
                this.columnPZPOREZ = this.Columns["PZPOREZ"];
                this.columnPRIMATELJPOREZ1 = this.Columns["PRIMATELJPOREZ1"];
                this.columnPRIMATELJPOREZ2 = this.Columns["PRIMATELJPOREZ2"];
                this.columnSIFRAOPISAPLACANJAPOREZ = this.Columns["SIFRAOPISAPLACANJAPOREZ"];
                this.columnOPISPLACANJAPOREZ = this.Columns["OPISPLACANJAPOREZ"];
            }

            public POREZDataSet.POREZRow NewPOREZRow()
            {
                return (POREZDataSet.POREZRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new POREZDataSet.POREZRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.POREZRowChanged != null)
                {
                    POREZDataSet.POREZRowChangeEventHandler pOREZRowChangedEvent = this.POREZRowChanged;
                    if (pOREZRowChangedEvent != null)
                    {
                        pOREZRowChangedEvent(this, new POREZDataSet.POREZRowChangeEvent((POREZDataSet.POREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.POREZRowChanging != null)
                {
                    POREZDataSet.POREZRowChangeEventHandler pOREZRowChangingEvent = this.POREZRowChanging;
                    if (pOREZRowChangingEvent != null)
                    {
                        pOREZRowChangingEvent(this, new POREZDataSet.POREZRowChangeEvent((POREZDataSet.POREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.POREZRowDeleted != null)
                {
                    POREZDataSet.POREZRowChangeEventHandler pOREZRowDeletedEvent = this.POREZRowDeleted;
                    if (pOREZRowDeletedEvent != null)
                    {
                        pOREZRowDeletedEvent(this, new POREZDataSet.POREZRowChangeEvent((POREZDataSet.POREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.POREZRowDeleting != null)
                {
                    POREZDataSet.POREZRowChangeEventHandler pOREZRowDeletingEvent = this.POREZRowDeleting;
                    if (pOREZRowDeletingEvent != null)
                    {
                        pOREZRowDeletingEvent(this, new POREZDataSet.POREZRowChangeEvent((POREZDataSet.POREZRow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePOREZRow(POREZDataSet.POREZRow row)
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

            public DataColumn IDPOREZColumn
            {
                get
                {
                    return this.columnIDPOREZ;
                }
            }

            public POREZDataSet.POREZRow this[int index]
            {
                get
                {
                    return (POREZDataSet.POREZRow) this.Rows[index];
                }
            }

            public DataColumn MOPOREZColumn
            {
                get
                {
                    return this.columnMOPOREZ;
                }
            }

            public DataColumn MZPOREZColumn
            {
                get
                {
                    return this.columnMZPOREZ;
                }
            }

            public DataColumn NAZIVPOREZColumn
            {
                get
                {
                    return this.columnNAZIVPOREZ;
                }
            }

            public DataColumn OPISPLACANJAPOREZColumn
            {
                get
                {
                    return this.columnOPISPLACANJAPOREZ;
                }
            }

            public DataColumn POPOREZColumn
            {
                get
                {
                    return this.columnPOPOREZ;
                }
            }

            public DataColumn POREZMJESECNOColumn
            {
                get
                {
                    return this.columnPOREZMJESECNO;
                }
            }

            public DataColumn PRIMATELJPOREZ1Column
            {
                get
                {
                    return this.columnPRIMATELJPOREZ1;
                }
            }

            public DataColumn PRIMATELJPOREZ2Column
            {
                get
                {
                    return this.columnPRIMATELJPOREZ2;
                }
            }

            public DataColumn PZPOREZColumn
            {
                get
                {
                    return this.columnPZPOREZ;
                }
            }

            public DataColumn SIFRAOPISAPLACANJAPOREZColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJAPOREZ;
                }
            }

            public DataColumn STOPAPOREZAColumn
            {
                get
                {
                    return this.columnSTOPAPOREZA;
                }
            }
        }

        public class POREZRow : DataRow
        {
            private POREZDataSet.POREZDataTable tablePOREZ;

            internal POREZRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePOREZ = (POREZDataSet.POREZDataTable) this.Table;
            }

            public bool IsIDPOREZNull()
            {
                return this.IsNull(this.tablePOREZ.IDPOREZColumn);
            }

            public bool IsMOPOREZNull()
            {
                return this.IsNull(this.tablePOREZ.MOPOREZColumn);
            }

            public bool IsMZPOREZNull()
            {
                return this.IsNull(this.tablePOREZ.MZPOREZColumn);
            }

            public bool IsNAZIVPOREZNull()
            {
                return this.IsNull(this.tablePOREZ.NAZIVPOREZColumn);
            }

            public bool IsOPISPLACANJAPOREZNull()
            {
                return this.IsNull(this.tablePOREZ.OPISPLACANJAPOREZColumn);
            }

            public bool IsPOPOREZNull()
            {
                return this.IsNull(this.tablePOREZ.POPOREZColumn);
            }

            public bool IsPOREZMJESECNONull()
            {
                return this.IsNull(this.tablePOREZ.POREZMJESECNOColumn);
            }

            public bool IsPRIMATELJPOREZ1Null()
            {
                return this.IsNull(this.tablePOREZ.PRIMATELJPOREZ1Column);
            }

            public bool IsPRIMATELJPOREZ2Null()
            {
                return this.IsNull(this.tablePOREZ.PRIMATELJPOREZ2Column);
            }

            public bool IsPZPOREZNull()
            {
                return this.IsNull(this.tablePOREZ.PZPOREZColumn);
            }

            public bool IsSIFRAOPISAPLACANJAPOREZNull()
            {
                return this.IsNull(this.tablePOREZ.SIFRAOPISAPLACANJAPOREZColumn);
            }

            public bool IsSTOPAPOREZANull()
            {
                return this.IsNull(this.tablePOREZ.STOPAPOREZAColumn);
            }

            public void SetMOPOREZNull()
            {
                this[this.tablePOREZ.MOPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZPOREZNull()
            {
                this[this.tablePOREZ.MZPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPOREZNull()
            {
                this[this.tablePOREZ.NAZIVPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAPOREZNull()
            {
                this[this.tablePOREZ.OPISPLACANJAPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOPOREZNull()
            {
                this[this.tablePOREZ.POPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZMJESECNONull()
            {
                this[this.tablePOREZ.POREZMJESECNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJPOREZ1Null()
            {
                this[this.tablePOREZ.PRIMATELJPOREZ1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJPOREZ2Null()
            {
                this[this.tablePOREZ.PRIMATELJPOREZ2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZPOREZNull()
            {
                this[this.tablePOREZ.PZPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAPOREZNull()
            {
                this[this.tablePOREZ.SIFRAOPISAPLACANJAPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAPOREZANull()
            {
                this[this.tablePOREZ.STOPAPOREZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDPOREZ
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePOREZ.IDPOREZColumn]);
                }
                set
                {
                    this[this.tablePOREZ.IDPOREZColumn] = value;
                }
            }

            public string MOPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePOREZ.MOPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePOREZ.MOPOREZColumn] = value;
                }
            }

            public string MZPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePOREZ.MZPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePOREZ.MZPOREZColumn] = value;
                }
            }

            public string NAZIVPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePOREZ.NAZIVPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePOREZ.NAZIVPOREZColumn] = value;
                }
            }

            public string OPISPLACANJAPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePOREZ.OPISPLACANJAPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePOREZ.OPISPLACANJAPOREZColumn] = value;
                }
            }

            public string POPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePOREZ.POPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePOREZ.POPOREZColumn] = value;
                }
            }

            public decimal POREZMJESECNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePOREZ.POREZMJESECNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePOREZ.POREZMJESECNOColumn] = value;
                }
            }

            public string PRIMATELJPOREZ1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePOREZ.PRIMATELJPOREZ1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePOREZ.PRIMATELJPOREZ1Column] = value;
                }
            }

            public string PRIMATELJPOREZ2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePOREZ.PRIMATELJPOREZ2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePOREZ.PRIMATELJPOREZ2Column] = value;
                }
            }

            public string PZPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePOREZ.PZPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePOREZ.PZPOREZColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePOREZ.SIFRAOPISAPLACANJAPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePOREZ.SIFRAOPISAPLACANJAPOREZColumn] = value;
                }
            }

            public decimal STOPAPOREZA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePOREZ.STOPAPOREZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePOREZ.STOPAPOREZAColumn] = value;
                }
            }
        }

        public class POREZRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private POREZDataSet.POREZRow eventRow;

            public POREZRowChangeEvent(POREZDataSet.POREZRow row, DataRowAction action)
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

            public POREZDataSet.POREZRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void POREZRowChangeEventHandler(object sender, POREZDataSet.POREZRowChangeEvent e);
    }
}

