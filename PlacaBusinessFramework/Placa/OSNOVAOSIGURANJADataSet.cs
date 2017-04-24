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
    public class OSNOVAOSIGURANJADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private OSNOVAOSIGURANJADataTable tableOSNOVAOSIGURANJA;

        public OSNOVAOSIGURANJADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected OSNOVAOSIGURANJADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["OSNOVAOSIGURANJA"] != null)
                    {
                        this.Tables.Add(new OSNOVAOSIGURANJADataTable(dataSet.Tables["OSNOVAOSIGURANJA"]));
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
            OSNOVAOSIGURANJADataSet set = (OSNOVAOSIGURANJADataSet) base.Clone();
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
            OSNOVAOSIGURANJADataSet set = new OSNOVAOSIGURANJADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "OSNOVAOSIGURANJADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1013");
            this.ExtendedProperties.Add("DataSetName", "OSNOVAOSIGURANJADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IOSNOVAOSIGURANJADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "OSNOVAOSIGURANJA");
            this.ExtendedProperties.Add("ObjectDescription", "R-Sm - Osnove osiguranja");
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
            this.DataSetName = "OSNOVAOSIGURANJADataSet";
            this.Namespace = "http://www.tempuri.org/OSNOVAOSIGURANJA";
            this.tableOSNOVAOSIGURANJA = new OSNOVAOSIGURANJADataTable();
            this.Tables.Add(this.tableOSNOVAOSIGURANJA);
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
            this.tableOSNOVAOSIGURANJA = (OSNOVAOSIGURANJADataTable) this.Tables["OSNOVAOSIGURANJA"];
            if (initTable && (this.tableOSNOVAOSIGURANJA != null))
            {
                this.tableOSNOVAOSIGURANJA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["OSNOVAOSIGURANJA"] != null)
                {
                    this.Tables.Add(new OSNOVAOSIGURANJADataTable(dataSet.Tables["OSNOVAOSIGURANJA"]));
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

        private bool ShouldSerializeOSNOVAOSIGURANJA()
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
        public OSNOVAOSIGURANJADataTable OSNOVAOSIGURANJA
        {
            get
            {
                return this.tableOSNOVAOSIGURANJA;
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
        public class OSNOVAOSIGURANJADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOSNOVAOSIGURANJA;
            private DataColumn columnNAZIVOSNOVAOSIGURANJA;
            private DataColumn columnRAZDOBLJESESMIJEPREKLAPATI;
            private DataColumn columnZAMOOIDOSNOVAOSIGURANJA;
            private DataColumn columnZAMOONAZIVOSNOVAOSIGURANJA;

            public event OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARowChangeEventHandler OSNOVAOSIGURANJARowChanged;

            public event OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARowChangeEventHandler OSNOVAOSIGURANJARowChanging;

            public event OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARowChangeEventHandler OSNOVAOSIGURANJARowDeleted;

            public event OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARowChangeEventHandler OSNOVAOSIGURANJARowDeleting;

            public OSNOVAOSIGURANJADataTable()
            {
                this.TableName = "OSNOVAOSIGURANJA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OSNOVAOSIGURANJADataTable(DataTable table) : base(table.TableName)
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

            protected OSNOVAOSIGURANJADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOSNOVAOSIGURANJARow(OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow row)
            {
                this.Rows.Add(row);
            }

            public OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow AddOSNOVAOSIGURANJARow(string iDOSNOVAOSIGURANJA, string nAZIVOSNOVAOSIGURANJA, bool rAZDOBLJESESMIJEPREKLAPATI, string zAMOOIDOSNOVAOSIGURANJA)
            {
                OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow row = (OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow) this.NewRow();
                row["IDOSNOVAOSIGURANJA"] = iDOSNOVAOSIGURANJA;
                row["NAZIVOSNOVAOSIGURANJA"] = nAZIVOSNOVAOSIGURANJA;
                row["RAZDOBLJESESMIJEPREKLAPATI"] = rAZDOBLJESESMIJEPREKLAPATI;
                row["ZAMOOIDOSNOVAOSIGURANJA"] = zAMOOIDOSNOVAOSIGURANJA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJADataTable table = (OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow FindByIDOSNOVAOSIGURANJA(string iDOSNOVAOSIGURANJA)
            {
                return (OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow) this.Rows.Find(new object[] { iDOSNOVAOSIGURANJA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OSNOVAOSIGURANJADataSet set = new OSNOVAOSIGURANJADataSet();
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
                this.columnIDOSNOVAOSIGURANJA = new DataColumn("IDOSNOVAOSIGURANJA", typeof(string), "", MappingType.Element);
                this.columnIDOSNOVAOSIGURANJA.AllowDBNull = false;
                this.columnIDOSNOVAOSIGURANJA.Caption = "Šifra osnove osiguranja";
                this.columnIDOSNOVAOSIGURANJA.MaxLength = 2;
                this.columnIDOSNOVAOSIGURANJA.Unique = true;
                this.columnIDOSNOVAOSIGURANJA.DefaultValue = "";
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Description", "Šifra osnove osiguranja");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Length", "2");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("TreatEmptyAsNull", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.InternalName", "IDOSNOVAOSIGURANJA");
                this.Columns.Add(this.columnIDOSNOVAOSIGURANJA);
                this.columnNAZIVOSNOVAOSIGURANJA = new DataColumn("NAZIVOSNOVAOSIGURANJA", typeof(string), "", MappingType.Element);
                this.columnNAZIVOSNOVAOSIGURANJA.AllowDBNull = false;
                this.columnNAZIVOSNOVAOSIGURANJA.Caption = "Naziv osnove osiguranja";
                this.columnNAZIVOSNOVAOSIGURANJA.MaxLength = 100;
                this.columnNAZIVOSNOVAOSIGURANJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Description", "Naziv osnove osiguranja");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOSNOVAOSIGURANJA");
                this.Columns.Add(this.columnNAZIVOSNOVAOSIGURANJA);
                this.columnRAZDOBLJESESMIJEPREKLAPATI = new DataColumn("RAZDOBLJESESMIJEPREKLAPATI", typeof(bool), "", MappingType.Element);
                this.columnRAZDOBLJESESMIJEPREKLAPATI.AllowDBNull = false;
                this.columnRAZDOBLJESESMIJEPREKLAPATI.Caption = "Razdoblje se smije preklapati";
                this.columnRAZDOBLJESESMIJEPREKLAPATI.DefaultValue = true;
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("IsKey", "false");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Description", "Razdoblje se smije preklapati");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Length", "1");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Decimals", "0");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.InternalName", "RAZDOBLJESESMIJEPREKLAPATI");
                this.Columns.Add(this.columnRAZDOBLJESESMIJEPREKLAPATI);
                this.columnZAMOOIDOSNOVAOSIGURANJA = new DataColumn("ZAMOOIDOSNOVAOSIGURANJA", typeof(string), "", MappingType.Element);
                this.columnZAMOOIDOSNOVAOSIGURANJA.AllowDBNull = true;
                this.columnZAMOOIDOSNOVAOSIGURANJA.Caption = "Zamjenska šifra osnove osiguranja (za nepuno radno vrijeme)";
                this.columnZAMOOIDOSNOVAOSIGURANJA.MaxLength = 2;
                this.columnZAMOOIDOSNOVAOSIGURANJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("SuperType", "IDOSNOVAOSIGURANJA");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("SubtypeGroup", "ZAMOO");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Description", "Zamjenska šifra osnove osiguranja (za nepuno radno vrijeme)");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Length", "2");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZAMOOIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.InternalName", "ZAMOOIDOSNOVAOSIGURANJA");
                this.Columns.Add(this.columnZAMOOIDOSNOVAOSIGURANJA);
                this.columnZAMOONAZIVOSNOVAOSIGURANJA = new DataColumn("ZAMOONAZIVOSNOVAOSIGURANJA", typeof(string), "", MappingType.Element);
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.AllowDBNull = true;
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.Caption = "Naziv zamjenske osnove osiguranja (za nepuno radno vrijeme)";
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.MaxLength = 100;
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("SuperType", "NAZIVOSNOVAOSIGURANJA");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("SubtypeGroup", "ZAMOO");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Description", "Naziv zamjenske osnove osiguranja (za nepuno radno vrijeme)");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Length", "100");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZAMOONAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.InternalName", "ZAMOONAZIVOSNOVAOSIGURANJA");
                this.Columns.Add(this.columnZAMOONAZIVOSNOVAOSIGURANJA);
                this.PrimaryKey = new DataColumn[] { this.columnIDOSNOVAOSIGURANJA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "OSNOVAOSIGURANJA");
                this.ExtendedProperties.Add("Description", "R-Sm - Osnove osiguranja");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDOSNOVAOSIGURANJA = this.Columns["IDOSNOVAOSIGURANJA"];
                this.columnNAZIVOSNOVAOSIGURANJA = this.Columns["NAZIVOSNOVAOSIGURANJA"];
                this.columnRAZDOBLJESESMIJEPREKLAPATI = this.Columns["RAZDOBLJESESMIJEPREKLAPATI"];
                this.columnZAMOOIDOSNOVAOSIGURANJA = this.Columns["ZAMOOIDOSNOVAOSIGURANJA"];
                this.columnZAMOONAZIVOSNOVAOSIGURANJA = this.Columns["ZAMOONAZIVOSNOVAOSIGURANJA"];
            }

            public OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow NewOSNOVAOSIGURANJARow()
            {
                return (OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OSNOVAOSIGURANJARowChanged != null)
                {
                    OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARowChangeEventHandler oSNOVAOSIGURANJARowChangedEvent = this.OSNOVAOSIGURANJARowChanged;
                    if (oSNOVAOSIGURANJARowChangedEvent != null)
                    {
                        oSNOVAOSIGURANJARowChangedEvent(this, new OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARowChangeEvent((OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OSNOVAOSIGURANJARowChanging != null)
                {
                    OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARowChangeEventHandler oSNOVAOSIGURANJARowChangingEvent = this.OSNOVAOSIGURANJARowChanging;
                    if (oSNOVAOSIGURANJARowChangingEvent != null)
                    {
                        oSNOVAOSIGURANJARowChangingEvent(this, new OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARowChangeEvent((OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.OSNOVAOSIGURANJARowDeleted != null)
                {
                    OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARowChangeEventHandler oSNOVAOSIGURANJARowDeletedEvent = this.OSNOVAOSIGURANJARowDeleted;
                    if (oSNOVAOSIGURANJARowDeletedEvent != null)
                    {
                        oSNOVAOSIGURANJARowDeletedEvent(this, new OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARowChangeEvent((OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OSNOVAOSIGURANJARowDeleting != null)
                {
                    OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARowChangeEventHandler oSNOVAOSIGURANJARowDeletingEvent = this.OSNOVAOSIGURANJARowDeleting;
                    if (oSNOVAOSIGURANJARowDeletingEvent != null)
                    {
                        oSNOVAOSIGURANJARowDeletingEvent(this, new OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARowChangeEvent((OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOSNOVAOSIGURANJARow(OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow row)
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

            public DataColumn IDOSNOVAOSIGURANJAColumn
            {
                get
                {
                    return this.columnIDOSNOVAOSIGURANJA;
                }
            }

            public OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow this[int index]
            {
                get
                {
                    return (OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVOSNOVAOSIGURANJAColumn
            {
                get
                {
                    return this.columnNAZIVOSNOVAOSIGURANJA;
                }
            }

            public DataColumn RAZDOBLJESESMIJEPREKLAPATIColumn
            {
                get
                {
                    return this.columnRAZDOBLJESESMIJEPREKLAPATI;
                }
            }

            public DataColumn ZAMOOIDOSNOVAOSIGURANJAColumn
            {
                get
                {
                    return this.columnZAMOOIDOSNOVAOSIGURANJA;
                }
            }

            public DataColumn ZAMOONAZIVOSNOVAOSIGURANJAColumn
            {
                get
                {
                    return this.columnZAMOONAZIVOSNOVAOSIGURANJA;
                }
            }
        }

        public class OSNOVAOSIGURANJARow : DataRow
        {
            private OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJADataTable tableOSNOVAOSIGURANJA;

            internal OSNOVAOSIGURANJARow(DataRowBuilder rb) : base(rb)
            {
                this.tableOSNOVAOSIGURANJA = (OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJADataTable) this.Table;
            }

            public bool IsIDOSNOVAOSIGURANJANull()
            {
                return this.IsNull(this.tableOSNOVAOSIGURANJA.IDOSNOVAOSIGURANJAColumn);
            }

            public bool IsNAZIVOSNOVAOSIGURANJANull()
            {
                return this.IsNull(this.tableOSNOVAOSIGURANJA.NAZIVOSNOVAOSIGURANJAColumn);
            }

            public bool IsRAZDOBLJESESMIJEPREKLAPATINull()
            {
                return this.IsNull(this.tableOSNOVAOSIGURANJA.RAZDOBLJESESMIJEPREKLAPATIColumn);
            }

            public bool IsZAMOOIDOSNOVAOSIGURANJANull()
            {
                return this.IsNull(this.tableOSNOVAOSIGURANJA.ZAMOOIDOSNOVAOSIGURANJAColumn);
            }

            public bool IsZAMOONAZIVOSNOVAOSIGURANJANull()
            {
                return this.IsNull(this.tableOSNOVAOSIGURANJA.ZAMOONAZIVOSNOVAOSIGURANJAColumn);
            }

            public void SetNAZIVOSNOVAOSIGURANJANull()
            {
                this[this.tableOSNOVAOSIGURANJA.NAZIVOSNOVAOSIGURANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRAZDOBLJESESMIJEPREKLAPATINull()
            {
                this[this.tableOSNOVAOSIGURANJA.RAZDOBLJESESMIJEPREKLAPATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZAMOOIDOSNOVAOSIGURANJANull()
            {
                this[this.tableOSNOVAOSIGURANJA.ZAMOOIDOSNOVAOSIGURANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZAMOONAZIVOSNOVAOSIGURANJANull()
            {
                this[this.tableOSNOVAOSIGURANJA.ZAMOONAZIVOSNOVAOSIGURANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string IDOSNOVAOSIGURANJA
            {
                get
                {
                    return Conversions.ToString(this[this.tableOSNOVAOSIGURANJA.IDOSNOVAOSIGURANJAColumn]);
                }
                set
                {
                    this[this.tableOSNOVAOSIGURANJA.IDOSNOVAOSIGURANJAColumn] = value;
                }
            }

            public string NAZIVOSNOVAOSIGURANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOSNOVAOSIGURANJA.NAZIVOSNOVAOSIGURANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVOSNOVAOSIGURANJA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableOSNOVAOSIGURANJA.NAZIVOSNOVAOSIGURANJAColumn] = value;
                }
            }

            public bool RAZDOBLJESESMIJEPREKLAPATI
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableOSNOVAOSIGURANJA.RAZDOBLJESESMIJEPREKLAPATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value RAZDOBLJESESMIJEPREKLAPATI because it is DBNull.", innerException);
                    }
                    return flag;
                }
                set
                {
                    this[this.tableOSNOVAOSIGURANJA.RAZDOBLJESESMIJEPREKLAPATIColumn] = value;
                }
            }

            public string ZAMOOIDOSNOVAOSIGURANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOSNOVAOSIGURANJA.ZAMOOIDOSNOVAOSIGURANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ZAMOOIDOSNOVAOSIGURANJA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableOSNOVAOSIGURANJA.ZAMOOIDOSNOVAOSIGURANJAColumn] = value;
                }
            }

            public string ZAMOONAZIVOSNOVAOSIGURANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOSNOVAOSIGURANJA.ZAMOONAZIVOSNOVAOSIGURANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ZAMOONAZIVOSNOVAOSIGURANJA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableOSNOVAOSIGURANJA.ZAMOONAZIVOSNOVAOSIGURANJAColumn] = value;
                }
            }
        }

        public class OSNOVAOSIGURANJARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow eventRow;

            public OSNOVAOSIGURANJARowChangeEvent(OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow row, DataRowAction action)
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

            public OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OSNOVAOSIGURANJARowChangeEventHandler(object sender, OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARowChangeEvent e);
    }
}

