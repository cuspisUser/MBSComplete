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
    public class UCENIKDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private UCENIKDataTable tableUCENIK;

        public UCENIKDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected UCENIKDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["UCENIK"] != null)
                    {
                        this.Tables.Add(new UCENIKDataTable(dataSet.Tables["UCENIK"]));
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
            UCENIKDataSet set = (UCENIKDataSet) base.Clone();
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
            UCENIKDataSet set = new UCENIKDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "UCENIKDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2197");
            this.ExtendedProperties.Add("DataSetName", "UCENIKDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IUCENIKDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "UCENIK");
            this.ExtendedProperties.Add("ObjectDescription", "UCENIK");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\UcenickaPraksa");
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
            this.DataSetName = "UCENIKDataSet";
            this.Namespace = "http://www.tempuri.org/UCENIK";
            this.tableUCENIK = new UCENIKDataTable();
            this.Tables.Add(this.tableUCENIK);
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
            this.tableUCENIK = (UCENIKDataTable) this.Tables["UCENIK"];
            if (initTable && (this.tableUCENIK != null))
            {
                this.tableUCENIK.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["UCENIK"] != null)
                {
                    this.Tables.Add(new UCENIKDataTable(dataSet.Tables["UCENIK"]));
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

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        private bool ShouldSerializeUCENIK()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public UCENIKDataTable UCENIK
        {
            get
            {
                return this.tableUCENIK;
            }
        }

        [Serializable]
        public class UCENIKDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDATUMRODJENJAUCENIKA;
            private DataColumn columnIDUCENIK;
            private DataColumn columnIMERODITELJA;
            private DataColumn columnIMEUCENIK;
            private DataColumn columnJMBGUCENIKA;
            private DataColumn columnNASELJE;
            private DataColumn columnNAZIVPOSTE;
            private DataColumn columnODJELJENJE;
            private DataColumn columnOIBUCENIK;
            private DataColumn columnPOSTANSKIBROJ;
            private DataColumn columnPREZIMEUCENIK;
            private DataColumn columnRAZRED;
            private DataColumn columnSPOLUCENIKA;
            private DataColumn columnULICAIBROJ;
            private DataColumn columnID_Opcina;
            private DataColumn columnPrezimeRoditelj;
            private DataColumn columnOIBRoditelj;
            private DataColumn columnIBANROditelj;


            public event UCENIKDataSet.UCENIKRowChangeEventHandler UCENIKRowChanged;

            public event UCENIKDataSet.UCENIKRowChangeEventHandler UCENIKRowChanging;

            public event UCENIKDataSet.UCENIKRowChangeEventHandler UCENIKRowDeleted;

            public event UCENIKDataSet.UCENIKRowChangeEventHandler UCENIKRowDeleting;

            public UCENIKDataTable()
            {
                this.TableName = "UCENIK";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal UCENIKDataTable(DataTable table) : base(table.TableName)
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

            protected UCENIKDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddUCENIKRow(UCENIKDataSet.UCENIKRow row)
            {
                this.Rows.Add(row);
            }

            public UCENIKDataSet.UCENIKRow AddUCENIKRow(int iDUCENIK, string pREZIMEUCENIK, string iMEUCENIK, string oIBUCENIK, int rAZRED, string oDJELJENJE, string sPOLUCENIKA, string uLICAIBROJ, string nASELJE, string jMBGUCENIKA, DateTime dATUMRODJENJAUCENIKA, string iMERODITELJA, string pOSTANSKIBROJ, string ID_Opcine, string prezimeRoditelj, string oibRoditelj, string ibanRoditelj)
            {
                UCENIKDataSet.UCENIKRow row = (UCENIKDataSet.UCENIKRow) this.NewRow();
                row["IDUCENIK"] = iDUCENIK;
                row["PREZIMEUCENIK"] = pREZIMEUCENIK;
                row["IMEUCENIK"] = iMEUCENIK;
                row["OIBUCENIK"] = oIBUCENIK;
                row["RAZRED"] = rAZRED;
                row["ODJELJENJE"] = oDJELJENJE;
                row["SPOLUCENIKA"] = sPOLUCENIKA;
                row["ULICAIBROJ"] = uLICAIBROJ;
                row["NASELJE"] = nASELJE;
                row["JMBGUCENIKA"] = jMBGUCENIKA;
                row["DATUMRODJENJAUCENIKA"] = dATUMRODJENJAUCENIKA;
                row["IMERODITELJA"] = iMERODITELJA;
                row["POSTANSKIBROJ"] = pOSTANSKIBROJ;
                row["ID_Opcina"] = ID_Opcine;
                row["PrezimeRoditelj"] = prezimeRoditelj;
                row["OIBRoditelj"] = oibRoditelj;
                row["IBANRoditelj"] = ibanRoditelj;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                UCENIKDataSet.UCENIKDataTable table = (UCENIKDataSet.UCENIKDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public UCENIKDataSet.UCENIKRow FindByIDUCENIK(int iDUCENIK)
            {
                return (UCENIKDataSet.UCENIKRow) this.Rows.Find(new object[] { iDUCENIK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(UCENIKDataSet.UCENIKRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                UCENIKDataSet set = new UCENIKDataSet();
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
                this.columnIDUCENIK = new DataColumn("IDUCENIK", typeof(int), "", MappingType.Element);
                this.columnIDUCENIK.AllowDBNull = false;
                this.columnIDUCENIK.Caption = "IDUCENIK";
                this.columnIDUCENIK.Unique = true;
                this.columnIDUCENIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDUCENIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDUCENIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDUCENIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDUCENIK.ExtendedProperties.Add("Description", "Šif.uč.");
                this.columnIDUCENIK.ExtendedProperties.Add("Length", "5");
                this.columnIDUCENIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDUCENIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDUCENIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.InternalName", "IDUCENIK");
                this.Columns.Add(this.columnIDUCENIK);
                this.columnPREZIMEUCENIK = new DataColumn("PREZIMEUCENIK", typeof(string), "", MappingType.Element);
                this.columnPREZIMEUCENIK.AllowDBNull = false;
                this.columnPREZIMEUCENIK.Caption = "PREZIMEUCENIK";
                this.columnPREZIMEUCENIK.MaxLength = 50;
                this.columnPREZIMEUCENIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("IsKey", "false");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Description", "Prezime");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Length", "50");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.InternalName", "PREZIMEUCENIK");
                this.Columns.Add(this.columnPREZIMEUCENIK);
                this.columnIMEUCENIK = new DataColumn("IMEUCENIK", typeof(string), "", MappingType.Element);
                this.columnIMEUCENIK.AllowDBNull = false;
                this.columnIMEUCENIK.Caption = "IMEUCENIK";
                this.columnIMEUCENIK.MaxLength = 50;
                this.columnIMEUCENIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIMEUCENIK.ExtendedProperties.Add("IsKey", "false");
                this.columnIMEUCENIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIMEUCENIK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIMEUCENIK.ExtendedProperties.Add("Description", "Ime");
                this.columnIMEUCENIK.ExtendedProperties.Add("Length", "50");
                this.columnIMEUCENIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIMEUCENIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIMEUCENIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.InternalName", "IMEUCENIK");
                this.Columns.Add(this.columnIMEUCENIK);
                this.columnOIBUCENIK = new DataColumn("OIBUCENIK", typeof(string), "", MappingType.Element);
                this.columnOIBUCENIK.AllowDBNull = false;
                this.columnOIBUCENIK.Caption = "OIBUCENIK";
                this.columnOIBUCENIK.MaxLength = 11;
                this.columnOIBUCENIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOIBUCENIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOIBUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOIBUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOIBUCENIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOIBUCENIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOIBUCENIK.ExtendedProperties.Add("IsKey", "false");
                this.columnOIBUCENIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOIBUCENIK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOIBUCENIK.ExtendedProperties.Add("Description", "OIB");
                this.columnOIBUCENIK.ExtendedProperties.Add("Length", "11");
                this.columnOIBUCENIK.ExtendedProperties.Add("Decimals", "0");
                this.columnOIBUCENIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOIBUCENIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnOIBUCENIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOIBUCENIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOIBUCENIK.ExtendedProperties.Add("Deklarit.InternalName", "OIBUCENIK");
                this.Columns.Add(this.columnOIBUCENIK);
                this.columnRAZRED = new DataColumn("RAZRED", typeof(int), "", MappingType.Element);
                this.columnRAZRED.AllowDBNull = false;
                this.columnRAZRED.Caption = "RAZRED";
                this.columnRAZRED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAZRED.ExtendedProperties.Add("IsKey", "false");
                this.columnRAZRED.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAZRED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRAZRED.ExtendedProperties.Add("Description", "RAZRED");
                this.columnRAZRED.ExtendedProperties.Add("Length", "5");
                this.columnRAZRED.ExtendedProperties.Add("Decimals", "0");
                this.columnRAZRED.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAZRED.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.InternalName", "RAZRED");
                this.Columns.Add(this.columnRAZRED);
                this.columnODJELJENJE = new DataColumn("ODJELJENJE", typeof(string), "", MappingType.Element);
                this.columnODJELJENJE.AllowDBNull = false;
                this.columnODJELJENJE.Caption = "ODJELJENJE";
                this.columnODJELJENJE.MaxLength = 5;
                this.columnODJELJENJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnODJELJENJE.ExtendedProperties.Add("IsKey", "false");
                this.columnODJELJENJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnODJELJENJE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnODJELJENJE.ExtendedProperties.Add("Description", "ODJELJENJE");
                this.columnODJELJENJE.ExtendedProperties.Add("Length", "5");
                this.columnODJELJENJE.ExtendedProperties.Add("Decimals", "0");
                this.columnODJELJENJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnODJELJENJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.InternalName", "ODJELJENJE");
                this.Columns.Add(this.columnODJELJENJE);
                this.columnSPOLUCENIKA = new DataColumn("SPOLUCENIKA", typeof(string), "", MappingType.Element);
                this.columnSPOLUCENIKA.AllowDBNull = false;
                this.columnSPOLUCENIKA.Caption = "SPOLUCENIKA";
                this.columnSPOLUCENIKA.MaxLength = 1;
                this.columnSPOLUCENIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSPOLUCENIKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("Description", "Spol");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("Length", "1");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSPOLUCENIKA.ExtendedProperties.Add("Deklarit.InternalName", "SPOLUCENIKA");
                this.Columns.Add(this.columnSPOLUCENIKA);
                this.columnULICAIBROJ = new DataColumn("ULICAIBROJ", typeof(string), "", MappingType.Element);
                this.columnULICAIBROJ.AllowDBNull = false;
                this.columnULICAIBROJ.Caption = "ULICAIBROJ";
                this.columnULICAIBROJ.MaxLength = 50;
                this.columnULICAIBROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnULICAIBROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnULICAIBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnULICAIBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnULICAIBROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnULICAIBROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnULICAIBROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnULICAIBROJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnULICAIBROJ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnULICAIBROJ.ExtendedProperties.Add("Description", "Ulica i broj");
                this.columnULICAIBROJ.ExtendedProperties.Add("Length", "50");
                this.columnULICAIBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnULICAIBROJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnULICAIBROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnULICAIBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnULICAIBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnULICAIBROJ.ExtendedProperties.Add("Deklarit.InternalName", "ULICAIBROJ");
                this.Columns.Add(this.columnULICAIBROJ);
                this.columnNASELJE = new DataColumn("NASELJE", typeof(string), "", MappingType.Element);
                this.columnNASELJE.AllowDBNull = false;
                this.columnNASELJE.Caption = "NASELJE";
                this.columnNASELJE.MaxLength = 50;
                this.columnNASELJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNASELJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNASELJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNASELJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNASELJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNASELJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNASELJE.ExtendedProperties.Add("IsKey", "false");
                this.columnNASELJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNASELJE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNASELJE.ExtendedProperties.Add("Description", "NASELJE");
                this.columnNASELJE.ExtendedProperties.Add("Length", "50");
                this.columnNASELJE.ExtendedProperties.Add("Decimals", "0");
                this.columnNASELJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNASELJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNASELJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNASELJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNASELJE.ExtendedProperties.Add("Deklarit.InternalName", "NASELJE");
                this.Columns.Add(this.columnNASELJE);
                this.columnJMBGUCENIKA = new DataColumn("JMBGUCENIKA", typeof(string), "", MappingType.Element);
                this.columnJMBGUCENIKA.AllowDBNull = false;
                this.columnJMBGUCENIKA.Caption = "JMBGUCENIKA";
                this.columnJMBGUCENIKA.MaxLength = 13;
                this.columnJMBGUCENIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnJMBGUCENIKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("Description", "JMBG");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("Length", "13");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnJMBGUCENIKA.ExtendedProperties.Add("Deklarit.InternalName", "JMBGUCENIKA");
                this.Columns.Add(this.columnJMBGUCENIKA);
                this.columnDATUMRODJENJAUCENIKA = new DataColumn("DATUMRODJENJAUCENIKA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMRODJENJAUCENIKA.AllowDBNull = false;
                this.columnDATUMRODJENJAUCENIKA.Caption = "DATUMRODJENJAUCENIKA";
                this.columnDATUMRODJENJAUCENIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("Description", "Datum rođenja");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMRODJENJAUCENIKA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMRODJENJAUCENIKA");
                this.Columns.Add(this.columnDATUMRODJENJAUCENIKA);
                this.columnIMERODITELJA = new DataColumn("IMERODITELJA", typeof(string), "", MappingType.Element);
                this.columnIMERODITELJA.AllowDBNull = false;
                this.columnIMERODITELJA.Caption = "IMERODITELJA";
                this.columnIMERODITELJA.MaxLength = 50;
                this.columnIMERODITELJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIMERODITELJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIMERODITELJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIMERODITELJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIMERODITELJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIMERODITELJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIMERODITELJA.ExtendedProperties.Add("IsKey", "false");
                this.columnIMERODITELJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIMERODITELJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIMERODITELJA.ExtendedProperties.Add("Description", "Ime roditelja");
                this.columnIMERODITELJA.ExtendedProperties.Add("Length", "50");
                this.columnIMERODITELJA.ExtendedProperties.Add("Decimals", "0");
                this.columnIMERODITELJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIMERODITELJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIMERODITELJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIMERODITELJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIMERODITELJA.ExtendedProperties.Add("Deklarit.InternalName", "IMERODITELJA");
                this.Columns.Add(this.columnIMERODITELJA);
                this.columnPOSTANSKIBROJ = new DataColumn("POSTANSKIBROJ", typeof(string), "", MappingType.Element);
                this.columnPOSTANSKIBROJ.AllowDBNull = false;
                this.columnPOSTANSKIBROJ.Caption = "POSTANSKIBROJ";
                this.columnPOSTANSKIBROJ.MaxLength = 5;
                this.columnPOSTANSKIBROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Description", "Poštanski broj");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Length", "5");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.InternalName", "POSTANSKIBROJ");
                this.Columns.Add(this.columnPOSTANSKIBROJ);
                this.columnNAZIVPOSTE = new DataColumn("NAZIVPOSTE", typeof(string), "", MappingType.Element);
                this.columnNAZIVPOSTE.AllowDBNull = true;
                this.columnNAZIVPOSTE.Caption = "NAZIVPOSTE";
                this.columnNAZIVPOSTE.MaxLength = 50;
                this.columnNAZIVPOSTE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Description", "Naziv pošte");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPOSTE");
                this.Columns.Add(this.columnNAZIVPOSTE);

                this.columnID_Opcina = new DataColumn("ID_Opcina", typeof(string), "", MappingType.Element);
                this.columnID_Opcina.AllowDBNull = true;
                this.columnID_Opcina.Caption = "ID Općina";
                this.columnID_Opcina.MaxLength = 4;
                this.columnID_Opcina.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnID_Opcina.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnID_Opcina.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnID_Opcina.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnID_Opcina.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnID_Opcina.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnID_Opcina.ExtendedProperties.Add("IsKey", "false");
                this.columnID_Opcina.ExtendedProperties.Add("ReadOnly", "true");
                this.columnID_Opcina.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnID_Opcina.ExtendedProperties.Add("Description", "ID Općina");
                this.columnID_Opcina.ExtendedProperties.Add("Length", "4");
                this.columnID_Opcina.ExtendedProperties.Add("Decimals", "0");
                this.columnID_Opcina.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnID_Opcina.ExtendedProperties.Add("IsInReader", "true");
                this.columnID_Opcina.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnID_Opcina.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnID_Opcina.ExtendedProperties.Add("Deklarit.InternalName", "ID_Opcina");
                this.Columns.Add(this.columnID_Opcina);

                this.columnPrezimeRoditelj = new DataColumn("PrezimeRoditelj", typeof(string), "", MappingType.Element);
                this.columnPrezimeRoditelj.AllowDBNull = true;
                this.columnPrezimeRoditelj.Caption = "PrezimeRoditelj";
                this.columnPrezimeRoditelj.MaxLength = 50;
                this.columnPrezimeRoditelj.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPrezimeRoditelj.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("IsKey", "false");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("Description", "PrezimeRoditelj");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("Length", "50");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("Decimals", "0");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("IsInReader", "true");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPrezimeRoditelj.ExtendedProperties.Add("Deklarit.InternalName", "PrezimeRoditelj");
                this.Columns.Add(this.columnPrezimeRoditelj);

                this.columnOIBRoditelj = new DataColumn("OIBRoditelj", typeof(string), "", MappingType.Element);
                this.columnOIBRoditelj.AllowDBNull = true;
                this.columnOIBRoditelj.Caption = "OIBRoditelj";
                this.columnOIBRoditelj.MaxLength = 11;
                this.columnOIBRoditelj.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOIBRoditelj.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOIBRoditelj.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOIBRoditelj.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOIBRoditelj.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOIBRoditelj.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOIBRoditelj.ExtendedProperties.Add("IsKey", "false");
                this.columnOIBRoditelj.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOIBRoditelj.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOIBRoditelj.ExtendedProperties.Add("Description", "OIBRoditelj");
                this.columnOIBRoditelj.ExtendedProperties.Add("Length", "11");
                this.columnOIBRoditelj.ExtendedProperties.Add("Decimals", "0");
                this.columnOIBRoditelj.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOIBRoditelj.ExtendedProperties.Add("IsInReader", "true");
                this.columnOIBRoditelj.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOIBRoditelj.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOIBRoditelj.ExtendedProperties.Add("Deklarit.InternalName", "OIBRoditelj");
                this.Columns.Add(this.columnOIBRoditelj);

                this.columnIBANROditelj = new DataColumn("IBANRoditelj", typeof(string), "", MappingType.Element);
                this.columnIBANROditelj.AllowDBNull = true;
                this.columnIBANROditelj.Caption = "IBANRoditelj";
                this.columnIBANROditelj.MaxLength = 30;
                this.columnIBANROditelj.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIBANROditelj.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIBANROditelj.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIBANROditelj.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIBANROditelj.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIBANROditelj.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIBANROditelj.ExtendedProperties.Add("IsKey", "false");
                this.columnIBANROditelj.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIBANROditelj.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIBANROditelj.ExtendedProperties.Add("Description", "IBANRoditelj");
                this.columnIBANROditelj.ExtendedProperties.Add("Length", "30");
                this.columnIBANROditelj.ExtendedProperties.Add("Decimals", "0");
                this.columnIBANROditelj.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIBANROditelj.ExtendedProperties.Add("IsInReader", "true");
                this.columnIBANROditelj.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIBANROditelj.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIBANROditelj.ExtendedProperties.Add("Deklarit.InternalName", "IBANRoditelj");
                this.Columns.Add(this.columnIBANROditelj);

                this.PrimaryKey = new DataColumn[] { this.columnIDUCENIK };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "UCENIK");
                this.ExtendedProperties.Add("Description", "UCENIK");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDUCENIK = this.Columns["IDUCENIK"];
                this.columnPREZIMEUCENIK = this.Columns["PREZIMEUCENIK"];
                this.columnIMEUCENIK = this.Columns["IMEUCENIK"];
                this.columnOIBUCENIK = this.Columns["OIBUCENIK"];
                this.columnRAZRED = this.Columns["RAZRED"];
                this.columnODJELJENJE = this.Columns["ODJELJENJE"];
                this.columnSPOLUCENIKA = this.Columns["SPOLUCENIKA"];
                this.columnULICAIBROJ = this.Columns["ULICAIBROJ"];
                this.columnNASELJE = this.Columns["NASELJE"];
                this.columnJMBGUCENIKA = this.Columns["JMBGUCENIKA"];
                this.columnDATUMRODJENJAUCENIKA = this.Columns["DATUMRODJENJAUCENIKA"];
                this.columnIMERODITELJA = this.Columns["IMERODITELJA"];
                this.columnPOSTANSKIBROJ = this.Columns["POSTANSKIBROJ"];
                this.columnNAZIVPOSTE = this.Columns["NAZIVPOSTE"];
                this.columnID_Opcina = this.Columns["ID_Opcina"];
                this.columnPrezimeRoditelj = this.Columns["PrezimeRoditelj"];
                this.columnOIBRoditelj = this.Columns["OIBRoditelj"];
                this.columnIBANROditelj = this.Columns["IBANRoditelj"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new UCENIKDataSet.UCENIKRow(builder);
            }

            public UCENIKDataSet.UCENIKRow NewUCENIKRow()
            {
                return (UCENIKDataSet.UCENIKRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.UCENIKRowChanged != null)
                {
                    UCENIKDataSet.UCENIKRowChangeEventHandler uCENIKRowChangedEvent = this.UCENIKRowChanged;
                    if (uCENIKRowChangedEvent != null)
                    {
                        uCENIKRowChangedEvent(this, new UCENIKDataSet.UCENIKRowChangeEvent((UCENIKDataSet.UCENIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.UCENIKRowChanging != null)
                {
                    UCENIKDataSet.UCENIKRowChangeEventHandler uCENIKRowChangingEvent = this.UCENIKRowChanging;
                    if (uCENIKRowChangingEvent != null)
                    {
                        uCENIKRowChangingEvent(this, new UCENIKDataSet.UCENIKRowChangeEvent((UCENIKDataSet.UCENIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.UCENIKRowDeleted != null)
                {
                    UCENIKDataSet.UCENIKRowChangeEventHandler uCENIKRowDeletedEvent = this.UCENIKRowDeleted;
                    if (uCENIKRowDeletedEvent != null)
                    {
                        uCENIKRowDeletedEvent(this, new UCENIKDataSet.UCENIKRowChangeEvent((UCENIKDataSet.UCENIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.UCENIKRowDeleting != null)
                {
                    UCENIKDataSet.UCENIKRowChangeEventHandler uCENIKRowDeletingEvent = this.UCENIKRowDeleting;
                    if (uCENIKRowDeletingEvent != null)
                    {
                        uCENIKRowDeletingEvent(this, new UCENIKDataSet.UCENIKRowChangeEvent((UCENIKDataSet.UCENIKRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveUCENIKRow(UCENIKDataSet.UCENIKRow row)
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

            public DataColumn DATUMRODJENJAUCENIKAColumn
            {
                get
                {
                    return this.columnDATUMRODJENJAUCENIKA;
                }
            }

            public DataColumn IDUCENIKColumn
            {
                get
                {
                    return this.columnIDUCENIK;
                }
            }

            public DataColumn IMERODITELJAColumn
            {
                get
                {
                    return this.columnIMERODITELJA;
                }
            }

            public DataColumn IMEUCENIKColumn
            {
                get
                {
                    return this.columnIMEUCENIK;
                }
            }

            public UCENIKDataSet.UCENIKRow this[int index]
            {
                get
                {
                    return (UCENIKDataSet.UCENIKRow) this.Rows[index];
                }
            }

            public DataColumn JMBGUCENIKAColumn
            {
                get
                {
                    return this.columnJMBGUCENIKA;
                }
            }

            public DataColumn NASELJEColumn
            {
                get
                {
                    return this.columnNASELJE;
                }
            }

            public DataColumn NAZIVPOSTEColumn
            {
                get
                {
                    return this.columnNAZIVPOSTE;
                }
            }

            public DataColumn ODJELJENJEColumn
            {
                get
                {
                    return this.columnODJELJENJE;
                }
            }

            public DataColumn OIBUCENIKColumn
            {
                get
                {
                    return this.columnOIBUCENIK;
                }
            }

            public DataColumn POSTANSKIBROJColumn
            {
                get
                {
                    return this.columnPOSTANSKIBROJ;
                }
            }

            public DataColumn PREZIMEUCENIKColumn
            {
                get
                {
                    return this.columnPREZIMEUCENIK;
                }
            }

            public DataColumn RAZREDColumn
            {
                get
                {
                    return this.columnRAZRED;
                }
            }

            public DataColumn SPOLUCENIKAColumn
            {
                get
                {
                    return this.columnSPOLUCENIKA;
                }
            }

            public DataColumn ULICAIBROJColumn
            {
                get
                {
                    return this.columnULICAIBROJ;
                }
            }
        }

        public class UCENIKRow : DataRow
        {
            private UCENIKDataSet.UCENIKDataTable tableUCENIK;

            internal UCENIKRow(DataRowBuilder rb) : base(rb)
            {
                this.tableUCENIK = (UCENIKDataSet.UCENIKDataTable) this.Table;
            }

            public bool IsDATUMRODJENJAUCENIKANull()
            {
                return this.IsNull(this.tableUCENIK.DATUMRODJENJAUCENIKAColumn);
            }

            public bool IsIDUCENIKNull()
            {
                return this.IsNull(this.tableUCENIK.IDUCENIKColumn);
            }

            public bool IsIMERODITELJANull()
            {
                return this.IsNull(this.tableUCENIK.IMERODITELJAColumn);
            }

            public bool IsIMEUCENIKNull()
            {
                return this.IsNull(this.tableUCENIK.IMEUCENIKColumn);
            }

            public bool IsJMBGUCENIKANull()
            {
                return this.IsNull(this.tableUCENIK.JMBGUCENIKAColumn);
            }

            public bool IsNASELJENull()
            {
                return this.IsNull(this.tableUCENIK.NASELJEColumn);
            }

            public bool IsNAZIVPOSTENull()
            {
                return this.IsNull(this.tableUCENIK.NAZIVPOSTEColumn);
            }

            public bool IsODJELJENJENull()
            {
                return this.IsNull(this.tableUCENIK.ODJELJENJEColumn);
            }

            public bool IsOIBUCENIKNull()
            {
                return this.IsNull(this.tableUCENIK.OIBUCENIKColumn);
            }

            public bool IsPOSTANSKIBROJNull()
            {
                return this.IsNull(this.tableUCENIK.POSTANSKIBROJColumn);
            }

            public bool IsPREZIMEUCENIKNull()
            {
                return this.IsNull(this.tableUCENIK.PREZIMEUCENIKColumn);
            }

            public bool IsRAZREDNull()
            {
                return this.IsNull(this.tableUCENIK.RAZREDColumn);
            }

            public bool IsSPOLUCENIKANull()
            {
                return this.IsNull(this.tableUCENIK.SPOLUCENIKAColumn);
            }

            public bool IsULICAIBROJNull()
            {
                return this.IsNull(this.tableUCENIK.ULICAIBROJColumn);
            }

            public void SetDATUMRODJENJAUCENIKANull()
            {
                this[this.tableUCENIK.DATUMRODJENJAUCENIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMERODITELJANull()
            {
                this[this.tableUCENIK.IMERODITELJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMEUCENIKNull()
            {
                this[this.tableUCENIK.IMEUCENIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGUCENIKANull()
            {
                this[this.tableUCENIK.JMBGUCENIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNASELJENull()
            {
                this[this.tableUCENIK.NASELJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPOSTENull()
            {
                this[this.tableUCENIK.NAZIVPOSTEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODJELJENJENull()
            {
                this[this.tableUCENIK.ODJELJENJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOIBUCENIKNull()
            {
                this[this.tableUCENIK.OIBUCENIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOSTANSKIBROJNull()
            {
                this[this.tableUCENIK.POSTANSKIBROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMEUCENIKNull()
            {
                this[this.tableUCENIK.PREZIMEUCENIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRAZREDNull()
            {
                this[this.tableUCENIK.RAZREDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSPOLUCENIKANull()
            {
                this[this.tableUCENIK.SPOLUCENIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetULICAIBROJNull()
            {
                this[this.tableUCENIK.ULICAIBROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public DateTime DATUMRODJENJAUCENIKA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableUCENIK.DATUMRODJENJAUCENIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableUCENIK.DATUMRODJENJAUCENIKAColumn] = value;
                }
            }

            public int IDUCENIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableUCENIK.IDUCENIKColumn]);
                }
                set
                {
                    this[this.tableUCENIK.IDUCENIKColumn] = value;
                }
            }

            public string IMERODITELJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIK.IMERODITELJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIK.IMERODITELJAColumn] = value;
                }
            }

            public string IMEUCENIK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIK.IMEUCENIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIK.IMEUCENIKColumn] = value;
                }
            }

            public string JMBGUCENIKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIK.JMBGUCENIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIK.JMBGUCENIKAColumn] = value;
                }
            }

            public string NASELJE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIK.NASELJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIK.NASELJEColumn] = value;
                }
            }

            public string NAZIVPOSTE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIK.NAZIVPOSTEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIK.NAZIVPOSTEColumn] = value;
                }
            }

            public string ODJELJENJE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIK.ODJELJENJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIK.ODJELJENJEColumn] = value;
                }
            }

            public string OIBUCENIK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIK.OIBUCENIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIK.OIBUCENIKColumn] = value;
                }
            }

            public string POSTANSKIBROJ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIK.POSTANSKIBROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIK.POSTANSKIBROJColumn] = value;
                }
            }

            public string PREZIMEUCENIK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIK.PREZIMEUCENIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIK.PREZIMEUCENIKColumn] = value;
                }
            }

            public int RAZRED
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableUCENIK.RAZREDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableUCENIK.RAZREDColumn] = value;
                }
            }

            public string SPOLUCENIKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIK.SPOLUCENIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIK.SPOLUCENIKAColumn] = value;
                }
            }

            public string ULICAIBROJ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIK.ULICAIBROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIK.ULICAIBROJColumn] = value;
                }
            }
        }

        public class UCENIKRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private UCENIKDataSet.UCENIKRow eventRow;

            public UCENIKRowChangeEvent(UCENIKDataSet.UCENIKRow row, DataRowAction action)
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

            public UCENIKDataSet.UCENIKRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void UCENIKRowChangeEventHandler(object sender, UCENIKDataSet.UCENIKRowChangeEvent e);
    }
}

