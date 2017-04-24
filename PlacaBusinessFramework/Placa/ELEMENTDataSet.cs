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
    public class ELEMENTDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private ELEMENTDataTable tableELEMENT;

        public ELEMENTDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected ELEMENTDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["ELEMENT"] != null)
                    {
                        this.Tables.Add(new ELEMENTDataTable(dataSet.Tables["ELEMENT"]));
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
            ELEMENTDataSet set = (ELEMENTDataSet) base.Clone();
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
            ELEMENTDataSet set = new ELEMENTDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "ELEMENTDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2008");
            this.ExtendedProperties.Add("DataSetName", "ELEMENTDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IELEMENTDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "ELEMENT");
            this.ExtendedProperties.Add("ObjectDescription", "Elementi");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "EL");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "ELEMENTDataSet";
            this.Namespace = "http://www.tempuri.org/ELEMENT";
            this.tableELEMENT = new ELEMENTDataTable();
            this.Tables.Add(this.tableELEMENT);
            this.tableELEMENT.ELColumn.Expression = "TRIM(NAZIVELEMENT)+' | '+TRIM(NAZIVVRSTAELEMENT)";
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
            this.tableELEMENT = (ELEMENTDataTable) this.Tables["ELEMENT"];
            if (initTable && (this.tableELEMENT != null))
            {
                this.tableELEMENT.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["ELEMENT"] != null)
                {
                    this.Tables.Add(new ELEMENTDataTable(dataSet.Tables["ELEMENT"]));
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

        private bool ShouldSerializeELEMENT()
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
        public ELEMENTDataTable ELEMENT
        {
            get
            {
                return this.tableELEMENT;
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
        public class ELEMENTDataTable : DataTable, IEnumerable
        {
            private DataColumn columnEL;
            private DataColumn columnIDELEMENT;
            private DataColumn columnIDOSNOVAOSIGURANJA;
            private DataColumn columnIDVRSTAELEMENTA;
            private DataColumn columnMOELEMENT;
            private DataColumn columnMZELEMENT;
            private DataColumn columnNAZIVELEMENT;
            private DataColumn columnNAZIVOSNOVAOSIGURANJA;
            private DataColumn columnNAZIVVRSTAELEMENT;
            private DataColumn columnOPISPLACANJAELEMENT;
            private DataColumn columnPOELEMENT;
            private DataColumn columnPOSTAVLJAMZPZSVIMVIRMANIMA;
            private DataColumn columnPOSTOTAK;
            private DataColumn columnPZELEMENT;
            private DataColumn columnRAZDOBLJESESMIJEPREKLAPATI;
            private DataColumn columnSIFRAOPISAPLACANJAELEMENT;
            private DataColumn columnZBRAJASATEUFONDSATI;

            public event ELEMENTDataSet.ELEMENTRowChangeEventHandler ELEMENTRowChanged;

            public event ELEMENTDataSet.ELEMENTRowChangeEventHandler ELEMENTRowChanging;

            public event ELEMENTDataSet.ELEMENTRowChangeEventHandler ELEMENTRowDeleted;

            public event ELEMENTDataSet.ELEMENTRowChangeEventHandler ELEMENTRowDeleting;

            public ELEMENTDataTable()
            {
                this.TableName = "ELEMENT";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal ELEMENTDataTable(DataTable table) : base(table.TableName)
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

            protected ELEMENTDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddELEMENTRow(ELEMENTDataSet.ELEMENTRow row)
            {
                this.Rows.Add(row);
            }

            public ELEMENTDataSet.ELEMENTRow AddELEMENTRow(int iDELEMENT, string nAZIVELEMENT, short iDVRSTAELEMENTA, string iDOSNOVAOSIGURANJA, decimal pOSTOTAK, bool zBRAJASATEUFONDSATI, string mOELEMENT, string pOELEMENT, string mZELEMENT, string pZELEMENT, string sIFRAOPISAPLACANJAELEMENT, string oPISPLACANJAELEMENT, bool pOSTAVLJAMZPZSVIMVIRMANIMA)
            {
                ELEMENTDataSet.ELEMENTRow row = (ELEMENTDataSet.ELEMENTRow) this.NewRow();
                row["IDELEMENT"] = iDELEMENT;
                row["NAZIVELEMENT"] = nAZIVELEMENT;
                row["IDVRSTAELEMENTA"] = iDVRSTAELEMENTA;
                row["IDOSNOVAOSIGURANJA"] = iDOSNOVAOSIGURANJA;
                row["POSTOTAK"] = pOSTOTAK;
                row["ZBRAJASATEUFONDSATI"] = zBRAJASATEUFONDSATI;
                row["MOELEMENT"] = mOELEMENT;
                row["POELEMENT"] = pOELEMENT;
                row["MZELEMENT"] = mZELEMENT;
                row["PZELEMENT"] = pZELEMENT;
                row["SIFRAOPISAPLACANJAELEMENT"] = sIFRAOPISAPLACANJAELEMENT;
                row["OPISPLACANJAELEMENT"] = oPISPLACANJAELEMENT;
                row["POSTAVLJAMZPZSVIMVIRMANIMA"] = pOSTAVLJAMZPZSVIMVIRMANIMA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                ELEMENTDataSet.ELEMENTDataTable table = (ELEMENTDataSet.ELEMENTDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public ELEMENTDataSet.ELEMENTRow FindByIDELEMENT(int iDELEMENT)
            {
                return (ELEMENTDataSet.ELEMENTRow) this.Rows.Find(new object[] { iDELEMENT });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(ELEMENTDataSet.ELEMENTRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                ELEMENTDataSet set = new ELEMENTDataSet();
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
                this.columnIDELEMENT = new DataColumn("IDELEMENT", typeof(int), "", MappingType.Element);
                this.columnIDELEMENT.AllowDBNull = false;
                this.columnIDELEMENT.Caption = "Šifra elementa";
                this.columnIDELEMENT.Unique = true;
                this.columnIDELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDELEMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDELEMENT.ExtendedProperties.Add("Description", "Šifra elementa");
                this.columnIDELEMENT.ExtendedProperties.Add("Length", "8");
                this.columnIDELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDELEMENT");
                this.Columns.Add(this.columnIDELEMENT);
                this.columnNAZIVELEMENT = new DataColumn("NAZIVELEMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVELEMENT.AllowDBNull = false;
                this.columnNAZIVELEMENT.Caption = "Naziv elementa";
                this.columnNAZIVELEMENT.MaxLength = 50;
                this.columnNAZIVELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Description", "Naziv elementa");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVELEMENT");
                this.Columns.Add(this.columnNAZIVELEMENT);
                this.columnIDVRSTAELEMENTA = new DataColumn("IDVRSTAELEMENTA", typeof(short), "", MappingType.Element);
                this.columnIDVRSTAELEMENTA.AllowDBNull = false;
                this.columnIDVRSTAELEMENTA.Caption = "Šifra Vrste elementa";
                this.columnIDVRSTAELEMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Description", "Šifra Vrste elementa");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Length", "4");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.InternalName", "IDVRSTAELEMENTA");
                this.Columns.Add(this.columnIDVRSTAELEMENTA);
                this.columnNAZIVVRSTAELEMENT = new DataColumn("NAZIVVRSTAELEMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTAELEMENT.AllowDBNull = true;
                this.columnNAZIVVRSTAELEMENT.Caption = "Naziv vrste elementa";
                this.columnNAZIVVRSTAELEMENT.MaxLength = 0x19;
                this.columnNAZIVVRSTAELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Description", "Naziv vrste elementa");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Length", "25");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTAELEMENT");
                this.Columns.Add(this.columnNAZIVVRSTAELEMENT);
                this.columnIDOSNOVAOSIGURANJA = new DataColumn("IDOSNOVAOSIGURANJA", typeof(string), "", MappingType.Element);
                this.columnIDOSNOVAOSIGURANJA.AllowDBNull = true;
                this.columnIDOSNOVAOSIGURANJA.Caption = "Šifra osnove osiguranja";
                this.columnIDOSNOVAOSIGURANJA.MaxLength = 2;
                this.columnIDOSNOVAOSIGURANJA.DefaultValue = "";
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Description", "Šifra osnove osiguranja");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Length", "2");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("TreatEmptyAsNull", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.InternalName", "IDOSNOVAOSIGURANJA");
                this.Columns.Add(this.columnIDOSNOVAOSIGURANJA);
                this.columnNAZIVOSNOVAOSIGURANJA = new DataColumn("NAZIVOSNOVAOSIGURANJA", typeof(string), "", MappingType.Element);
                this.columnNAZIVOSNOVAOSIGURANJA.AllowDBNull = true;
                this.columnNAZIVOSNOVAOSIGURANJA.Caption = "Naziv osnove osiguranja";
                this.columnNAZIVOSNOVAOSIGURANJA.MaxLength = 100;
                this.columnNAZIVOSNOVAOSIGURANJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Description", "Naziv osnove osiguranja");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOSNOVAOSIGURANJA");
                this.Columns.Add(this.columnNAZIVOSNOVAOSIGURANJA);
                this.columnRAZDOBLJESESMIJEPREKLAPATI = new DataColumn("RAZDOBLJESESMIJEPREKLAPATI", typeof(bool), "", MappingType.Element);
                this.columnRAZDOBLJESESMIJEPREKLAPATI.AllowDBNull = true;
                this.columnRAZDOBLJESESMIJEPREKLAPATI.Caption = "Razdoblje se smije preklapati";
                this.columnRAZDOBLJESESMIJEPREKLAPATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("IsKey", "false");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Description", "Razdoblje se smije preklapati");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Length", "1");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Decimals", "0");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.InternalName", "RAZDOBLJESESMIJEPREKLAPATI");
                this.Columns.Add(this.columnRAZDOBLJESESMIJEPREKLAPATI);
                this.columnPOSTOTAK = new DataColumn("POSTOTAK", typeof(decimal), "", MappingType.Element);
                this.columnPOSTOTAK.AllowDBNull = false;
                this.columnPOSTOTAK.Caption = "Postotak";
                this.columnPOSTOTAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOSTOTAK.ExtendedProperties.Add("IsKey", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOSTOTAK.ExtendedProperties.Add("Description", "Postotak");
                this.columnPOSTOTAK.ExtendedProperties.Add("Length", "5");
                this.columnPOSTOTAK.ExtendedProperties.Add("Decimals", "2");
                this.columnPOSTOTAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPOSTOTAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.InternalName", "POSTOTAK");
                this.Columns.Add(this.columnPOSTOTAK);
                this.columnZBRAJASATEUFONDSATI = new DataColumn("ZBRAJASATEUFONDSATI", typeof(bool), "", MappingType.Element);
                this.columnZBRAJASATEUFONDSATI.AllowDBNull = false;
                this.columnZBRAJASATEUFONDSATI.Caption = "Sati ulaze u fond sati";
                this.columnZBRAJASATEUFONDSATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("IsKey", "false");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Description", "Sati ulaze u fond sati");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Length", "1");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Decimals", "0");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("IsInReader", "true");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.InternalName", "ZBRAJASATEUFONDSATI");
                this.Columns.Add(this.columnZBRAJASATEUFONDSATI);
                this.columnMOELEMENT = new DataColumn("MOELEMENT", typeof(string), "", MappingType.Element);
                this.columnMOELEMENT.AllowDBNull = true;
                this.columnMOELEMENT.Caption = "Model odobrenja";
                this.columnMOELEMENT.MaxLength = 2;
                this.columnMOELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMOELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnMOELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMOELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOELEMENT.ExtendedProperties.Add("Description", "Model odobrenja");
                this.columnMOELEMENT.ExtendedProperties.Add("Length", "2");
                this.columnMOELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnMOELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMOELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnMOELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "MOELEMENT");
                this.Columns.Add(this.columnMOELEMENT);
                this.columnPOELEMENT = new DataColumn("POELEMENT", typeof(string), "", MappingType.Element);
                this.columnPOELEMENT.AllowDBNull = true;
                this.columnPOELEMENT.Caption = "Poziv na broj odobrenja";
                this.columnPOELEMENT.MaxLength = 0x16;
                this.columnPOELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnPOELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOELEMENT.ExtendedProperties.Add("Description", "Poziv na broj odobrenja");
                this.columnPOELEMENT.ExtendedProperties.Add("Length", "22");
                this.columnPOELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnPOELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "POELEMENT");
                this.Columns.Add(this.columnPOELEMENT);
                this.columnMZELEMENT = new DataColumn("MZELEMENT", typeof(string), "", MappingType.Element);
                this.columnMZELEMENT.AllowDBNull = true;
                this.columnMZELEMENT.Caption = "Model zaduženja";
                this.columnMZELEMENT.MaxLength = 2;
                this.columnMZELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMZELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnMZELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMZELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZELEMENT.ExtendedProperties.Add("Description", "Model zaduženja");
                this.columnMZELEMENT.ExtendedProperties.Add("Length", "2");
                this.columnMZELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnMZELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnMZELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "MZELEMENT");
                this.Columns.Add(this.columnMZELEMENT);
                this.columnPZELEMENT = new DataColumn("PZELEMENT", typeof(string), "", MappingType.Element);
                this.columnPZELEMENT.AllowDBNull = true;
                this.columnPZELEMENT.Caption = "Poziv na broj zaduženja";
                this.columnPZELEMENT.MaxLength = 0x16;
                this.columnPZELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPZELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnPZELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPZELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZELEMENT.ExtendedProperties.Add("Description", "Poziv na broj zaduženja");
                this.columnPZELEMENT.ExtendedProperties.Add("Length", "22");
                this.columnPZELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnPZELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnPZELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "PZELEMENT");
                this.Columns.Add(this.columnPZELEMENT);
                this.columnSIFRAOPISAPLACANJAELEMENT = new DataColumn("SIFRAOPISAPLACANJAELEMENT", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAELEMENT.AllowDBNull = true;
                this.columnSIFRAOPISAPLACANJAELEMENT.Caption = "Šifra opisa plaćanja";
                this.columnSIFRAOPISAPLACANJAELEMENT.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("Description", "Šifra opisa plaćanja");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAELEMENT");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAELEMENT);
                this.columnOPISPLACANJAELEMENT = new DataColumn("OPISPLACANJAELEMENT", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAELEMENT.AllowDBNull = true;
                this.columnOPISPLACANJAELEMENT.Caption = "Opis plaćanja";
                this.columnOPISPLACANJAELEMENT.MaxLength = 0x24;
                this.columnOPISPLACANJAELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("Description", "Opis plaćanja");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAELEMENT");
                this.Columns.Add(this.columnOPISPLACANJAELEMENT);
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA = new DataColumn("POSTAVLJAMZPZSVIMVIRMANIMA", typeof(bool), "", MappingType.Element);
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.AllowDBNull = false;
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.Caption = "MZ i PZ svim virmanima obračuna";
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("Description", "MZ i PZ svim virmanima obračuna");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("Length", "1");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA.ExtendedProperties.Add("Deklarit.InternalName", "POSTAVLJAMZPZSVIMVIRMANIMA");
                this.Columns.Add(this.columnPOSTAVLJAMZPZSVIMVIRMANIMA);
                this.columnEL = new DataColumn("EL", typeof(string), "", MappingType.Element);
                this.columnEL.AllowDBNull = true;
                this.columnEL.Caption = "EL";
                this.columnEL.MaxLength = 150;
                this.columnEL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnEL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnEL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnEL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnEL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnEL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnEL.ExtendedProperties.Add("IsKey", "false");
                this.columnEL.ExtendedProperties.Add("ReadOnly", "true");
                this.columnEL.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnEL.ExtendedProperties.Add("Description", "EL");
                this.columnEL.ExtendedProperties.Add("Length", "150");
                this.columnEL.ExtendedProperties.Add("Decimals", "0");
                this.columnEL.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnEL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnEL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnEL.ExtendedProperties.Add("Deklarit.InternalName", "EL");
                this.columnEL.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnEL);
                this.PrimaryKey = new DataColumn[] { this.columnIDELEMENT };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "ELEMENT");
                this.ExtendedProperties.Add("Description", "Elementi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDELEMENT = this.Columns["IDELEMENT"];
                this.columnNAZIVELEMENT = this.Columns["NAZIVELEMENT"];
                this.columnIDVRSTAELEMENTA = this.Columns["IDVRSTAELEMENTA"];
                this.columnNAZIVVRSTAELEMENT = this.Columns["NAZIVVRSTAELEMENT"];
                this.columnIDOSNOVAOSIGURANJA = this.Columns["IDOSNOVAOSIGURANJA"];
                this.columnNAZIVOSNOVAOSIGURANJA = this.Columns["NAZIVOSNOVAOSIGURANJA"];
                this.columnRAZDOBLJESESMIJEPREKLAPATI = this.Columns["RAZDOBLJESESMIJEPREKLAPATI"];
                this.columnPOSTOTAK = this.Columns["POSTOTAK"];
                this.columnZBRAJASATEUFONDSATI = this.Columns["ZBRAJASATEUFONDSATI"];
                this.columnMOELEMENT = this.Columns["MOELEMENT"];
                this.columnPOELEMENT = this.Columns["POELEMENT"];
                this.columnMZELEMENT = this.Columns["MZELEMENT"];
                this.columnPZELEMENT = this.Columns["PZELEMENT"];
                this.columnSIFRAOPISAPLACANJAELEMENT = this.Columns["SIFRAOPISAPLACANJAELEMENT"];
                this.columnOPISPLACANJAELEMENT = this.Columns["OPISPLACANJAELEMENT"];
                this.columnPOSTAVLJAMZPZSVIMVIRMANIMA = this.Columns["POSTAVLJAMZPZSVIMVIRMANIMA"];
                this.columnEL = this.Columns["EL"];
            }

            public ELEMENTDataSet.ELEMENTRow NewELEMENTRow()
            {
                return (ELEMENTDataSet.ELEMENTRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new ELEMENTDataSet.ELEMENTRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ELEMENTRowChanged != null)
                {
                    ELEMENTDataSet.ELEMENTRowChangeEventHandler eLEMENTRowChangedEvent = this.ELEMENTRowChanged;
                    if (eLEMENTRowChangedEvent != null)
                    {
                        eLEMENTRowChangedEvent(this, new ELEMENTDataSet.ELEMENTRowChangeEvent((ELEMENTDataSet.ELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ELEMENTRowChanging != null)
                {
                    ELEMENTDataSet.ELEMENTRowChangeEventHandler eLEMENTRowChangingEvent = this.ELEMENTRowChanging;
                    if (eLEMENTRowChangingEvent != null)
                    {
                        eLEMENTRowChangingEvent(this, new ELEMENTDataSet.ELEMENTRowChangeEvent((ELEMENTDataSet.ELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.ELEMENTRowDeleted != null)
                {
                    ELEMENTDataSet.ELEMENTRowChangeEventHandler eLEMENTRowDeletedEvent = this.ELEMENTRowDeleted;
                    if (eLEMENTRowDeletedEvent != null)
                    {
                        eLEMENTRowDeletedEvent(this, new ELEMENTDataSet.ELEMENTRowChangeEvent((ELEMENTDataSet.ELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ELEMENTRowDeleting != null)
                {
                    ELEMENTDataSet.ELEMENTRowChangeEventHandler eLEMENTRowDeletingEvent = this.ELEMENTRowDeleting;
                    if (eLEMENTRowDeletingEvent != null)
                    {
                        eLEMENTRowDeletingEvent(this, new ELEMENTDataSet.ELEMENTRowChangeEvent((ELEMENTDataSet.ELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveELEMENTRow(ELEMENTDataSet.ELEMENTRow row)
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

            public DataColumn ELColumn
            {
                get
                {
                    return this.columnEL;
                }
            }

            public DataColumn IDELEMENTColumn
            {
                get
                {
                    return this.columnIDELEMENT;
                }
            }

            public DataColumn IDOSNOVAOSIGURANJAColumn
            {
                get
                {
                    return this.columnIDOSNOVAOSIGURANJA;
                }
            }

            public DataColumn IDVRSTAELEMENTAColumn
            {
                get
                {
                    return this.columnIDVRSTAELEMENTA;
                }
            }

            public ELEMENTDataSet.ELEMENTRow this[int index]
            {
                get
                {
                    return (ELEMENTDataSet.ELEMENTRow) this.Rows[index];
                }
            }

            public DataColumn MOELEMENTColumn
            {
                get
                {
                    return this.columnMOELEMENT;
                }
            }

            public DataColumn MZELEMENTColumn
            {
                get
                {
                    return this.columnMZELEMENT;
                }
            }

            public DataColumn NAZIVELEMENTColumn
            {
                get
                {
                    return this.columnNAZIVELEMENT;
                }
            }

            public DataColumn NAZIVOSNOVAOSIGURANJAColumn
            {
                get
                {
                    return this.columnNAZIVOSNOVAOSIGURANJA;
                }
            }

            public DataColumn NAZIVVRSTAELEMENTColumn
            {
                get
                {
                    return this.columnNAZIVVRSTAELEMENT;
                }
            }

            public DataColumn OPISPLACANJAELEMENTColumn
            {
                get
                {
                    return this.columnOPISPLACANJAELEMENT;
                }
            }

            public DataColumn POELEMENTColumn
            {
                get
                {
                    return this.columnPOELEMENT;
                }
            }

            public DataColumn POSTAVLJAMZPZSVIMVIRMANIMAColumn
            {
                get
                {
                    return this.columnPOSTAVLJAMZPZSVIMVIRMANIMA;
                }
            }

            public DataColumn POSTOTAKColumn
            {
                get
                {
                    return this.columnPOSTOTAK;
                }
            }

            public DataColumn PZELEMENTColumn
            {
                get
                {
                    return this.columnPZELEMENT;
                }
            }

            public DataColumn RAZDOBLJESESMIJEPREKLAPATIColumn
            {
                get
                {
                    return this.columnRAZDOBLJESESMIJEPREKLAPATI;
                }
            }

            public DataColumn SIFRAOPISAPLACANJAELEMENTColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJAELEMENT;
                }
            }

            public DataColumn ZBRAJASATEUFONDSATIColumn
            {
                get
                {
                    return this.columnZBRAJASATEUFONDSATI;
                }
            }
        }

        public class ELEMENTRow : DataRow
        {
            private ELEMENTDataSet.ELEMENTDataTable tableELEMENT;

            internal ELEMENTRow(DataRowBuilder rb) : base(rb)
            {
                this.tableELEMENT = (ELEMENTDataSet.ELEMENTDataTable) this.Table;
            }

            public bool IsELNull()
            {
                return this.IsNull(this.tableELEMENT.ELColumn);
            }

            public bool IsIDELEMENTNull()
            {
                return this.IsNull(this.tableELEMENT.IDELEMENTColumn);
            }

            public bool IsIDOSNOVAOSIGURANJANull()
            {
                return this.IsNull(this.tableELEMENT.IDOSNOVAOSIGURANJAColumn);
            }

            public bool IsIDVRSTAELEMENTANull()
            {
                return this.IsNull(this.tableELEMENT.IDVRSTAELEMENTAColumn);
            }

            public bool IsMOELEMENTNull()
            {
                return this.IsNull(this.tableELEMENT.MOELEMENTColumn);
            }

            public bool IsMZELEMENTNull()
            {
                return this.IsNull(this.tableELEMENT.MZELEMENTColumn);
            }

            public bool IsNAZIVELEMENTNull()
            {
                return this.IsNull(this.tableELEMENT.NAZIVELEMENTColumn);
            }

            public bool IsNAZIVOSNOVAOSIGURANJANull()
            {
                return this.IsNull(this.tableELEMENT.NAZIVOSNOVAOSIGURANJAColumn);
            }

            public bool IsNAZIVVRSTAELEMENTNull()
            {
                return this.IsNull(this.tableELEMENT.NAZIVVRSTAELEMENTColumn);
            }

            public bool IsOPISPLACANJAELEMENTNull()
            {
                return this.IsNull(this.tableELEMENT.OPISPLACANJAELEMENTColumn);
            }

            public bool IsPOELEMENTNull()
            {
                return this.IsNull(this.tableELEMENT.POELEMENTColumn);
            }

            public bool IsPOSTAVLJAMZPZSVIMVIRMANIMANull()
            {
                return this.IsNull(this.tableELEMENT.POSTAVLJAMZPZSVIMVIRMANIMAColumn);
            }

            public bool IsPOSTOTAKNull()
            {
                return this.IsNull(this.tableELEMENT.POSTOTAKColumn);
            }

            public bool IsPZELEMENTNull()
            {
                return this.IsNull(this.tableELEMENT.PZELEMENTColumn);
            }

            public bool IsRAZDOBLJESESMIJEPREKLAPATINull()
            {
                return this.IsNull(this.tableELEMENT.RAZDOBLJESESMIJEPREKLAPATIColumn);
            }

            public bool IsSIFRAOPISAPLACANJAELEMENTNull()
            {
                return this.IsNull(this.tableELEMENT.SIFRAOPISAPLACANJAELEMENTColumn);
            }

            public bool IsZBRAJASATEUFONDSATINull()
            {
                return this.IsNull(this.tableELEMENT.ZBRAJASATEUFONDSATIColumn);
            }

            public void SetELNull()
            {
                this[this.tableELEMENT.ELColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDOSNOVAOSIGURANJANull()
            {
                this[this.tableELEMENT.IDOSNOVAOSIGURANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDVRSTAELEMENTANull()
            {
                this[this.tableELEMENT.IDVRSTAELEMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMOELEMENTNull()
            {
                this[this.tableELEMENT.MOELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZELEMENTNull()
            {
                this[this.tableELEMENT.MZELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVELEMENTNull()
            {
                this[this.tableELEMENT.NAZIVELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOSNOVAOSIGURANJANull()
            {
                this[this.tableELEMENT.NAZIVOSNOVAOSIGURANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVVRSTAELEMENTNull()
            {
                this[this.tableELEMENT.NAZIVVRSTAELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAELEMENTNull()
            {
                this[this.tableELEMENT.OPISPLACANJAELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOELEMENTNull()
            {
                this[this.tableELEMENT.POELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOSTAVLJAMZPZSVIMVIRMANIMANull()
            {
                this[this.tableELEMENT.POSTAVLJAMZPZSVIMVIRMANIMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOSTOTAKNull()
            {
                this[this.tableELEMENT.POSTOTAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZELEMENTNull()
            {
                this[this.tableELEMENT.PZELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRAZDOBLJESESMIJEPREKLAPATINull()
            {
                this[this.tableELEMENT.RAZDOBLJESESMIJEPREKLAPATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAELEMENTNull()
            {
                this[this.tableELEMENT.SIFRAOPISAPLACANJAELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZBRAJASATEUFONDSATINull()
            {
                this[this.tableELEMENT.ZBRAJASATEUFONDSATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string EL
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableELEMENT.ELColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value EL because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableELEMENT.ELColumn] = value;
                }
            }

            public int IDELEMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableELEMENT.IDELEMENTColumn]);
                }
                set
                {
                    this[this.tableELEMENT.IDELEMENTColumn] = value;
                }
            }

            public string IDOSNOVAOSIGURANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableELEMENT.IDOSNOVAOSIGURANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableELEMENT.IDOSNOVAOSIGURANJAColumn] = value;
                }
            }

            public short IDVRSTAELEMENTA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableELEMENT.IDVRSTAELEMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableELEMENT.IDVRSTAELEMENTAColumn] = value;
                }
            }

            public string MOELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableELEMENT.MOELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableELEMENT.MOELEMENTColumn] = value;
                }
            }

            public string MZELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableELEMENT.MZELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableELEMENT.MZELEMENTColumn] = value;
                }
            }

            public string NAZIVELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableELEMENT.NAZIVELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableELEMENT.NAZIVELEMENTColumn] = value;
                }
            }

            public string NAZIVOSNOVAOSIGURANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableELEMENT.NAZIVOSNOVAOSIGURANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableELEMENT.NAZIVOSNOVAOSIGURANJAColumn] = value;
                }
            }

            public string NAZIVVRSTAELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableELEMENT.NAZIVVRSTAELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableELEMENT.NAZIVVRSTAELEMENTColumn] = value;
                }
            }

            public string OPISPLACANJAELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableELEMENT.OPISPLACANJAELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableELEMENT.OPISPLACANJAELEMENTColumn] = value;
                }
            }

            public string POELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableELEMENT.POELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableELEMENT.POELEMENTColumn] = value;
                }
            }

            public bool POSTAVLJAMZPZSVIMVIRMANIMA
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableELEMENT.POSTAVLJAMZPZSVIMVIRMANIMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableELEMENT.POSTAVLJAMZPZSVIMVIRMANIMAColumn] = value;
                }
            }

            public decimal POSTOTAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableELEMENT.POSTOTAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableELEMENT.POSTOTAKColumn] = value;
                }
            }

            public string PZELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableELEMENT.PZELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableELEMENT.PZELEMENTColumn] = value;
                }
            }

            public bool RAZDOBLJESESMIJEPREKLAPATI
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableELEMENT.RAZDOBLJESESMIJEPREKLAPATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableELEMENT.RAZDOBLJESESMIJEPREKLAPATIColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableELEMENT.SIFRAOPISAPLACANJAELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableELEMENT.SIFRAOPISAPLACANJAELEMENTColumn] = value;
                }
            }

            public bool ZBRAJASATEUFONDSATI
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableELEMENT.ZBRAJASATEUFONDSATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableELEMENT.ZBRAJASATEUFONDSATIColumn] = value;
                }
            }
        }

        public class ELEMENTRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private ELEMENTDataSet.ELEMENTRow eventRow;

            public ELEMENTRowChangeEvent(ELEMENTDataSet.ELEMENTRow row, DataRowAction action)
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

            public ELEMENTDataSet.ELEMENTRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void ELEMENTRowChangeEventHandler(object sender, ELEMENTDataSet.ELEMENTRowChangeEvent e);
    }
}

