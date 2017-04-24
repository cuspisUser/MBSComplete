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
    public class VIRMANIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private VIRMANIDataTable tableVIRMANI;

        public VIRMANIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected VIRMANIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["VIRMANI"] != null)
                    {
                        this.Tables.Add(new VIRMANIDataTable(dataSet.Tables["VIRMANI"]));
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
            VIRMANIDataSet set = (VIRMANIDataSet) base.Clone();
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
            VIRMANIDataSet set = new VIRMANIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "VIRMANIDataAdapter");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1029");
            this.ExtendedProperties.Add("DataSetName", "VIRMANIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IVIRMANIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "VIRMANI");
            this.ExtendedProperties.Add("ObjectDescription", "VIRMANI");
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
            this.DataSetName = "VIRMANIDataSet";
            this.Namespace = "http://www.tempuri.org/VIRMANI";
            this.tableVIRMANI = new VIRMANIDataTable();
            this.Tables.Add(this.tableVIRMANI);
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
            this.tableVIRMANI = (VIRMANIDataTable) this.Tables["VIRMANI"];
            if (initTable && (this.tableVIRMANI != null))
            {
                this.tableVIRMANI.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["VIRMANI"] != null)
                {
                    this.Tables.Add(new VIRMANIDataTable(dataSet.Tables["VIRMANI"]));
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

        private bool ShouldSerializeVIRMANI()
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
        public VIRMANIDataTable VIRMANI
        {
            get
            {
                return this.tableVIRMANI;
            }
        }

        [Serializable]
        public class VIRMANIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJRACUNAPLA;
            private DataColumn columnBROJRACUNAPRI;
            private DataColumn columnDATUMPODNOSENJA;
            private DataColumn columnDATUMVALUTE;
            private DataColumn columnIDVIRMAN;
            private DataColumn columnIZNOS;
            private DataColumn columnIZVORDOKUMENTA;
            private DataColumn columnMODELODOBRENJA;
            private DataColumn columnMODELZADUZENJA;
            private DataColumn columnNAMJENA;
            private DataColumn columnOPISPLACANJAVIRMAN;
            private DataColumn columnOZNACEN;
            private DataColumn columnPLA1;
            private DataColumn columnPLA2;
            private DataColumn columnPLA3;
            private DataColumn columnPOZIVODOBRENJA;
            private DataColumn columnPOZIVZADUZENJA;
            private DataColumn columnPRI1;
            private DataColumn columnPRI2;
            private DataColumn columnPRI3;
            private DataColumn columnSIFRAOBRACUNAVIRMAN;
            private DataColumn columnSIFRAOPISAPLACANJAVIRMAN;
            private DataColumn columnHUB3_SIFRANAMJENE;
            private DataColumn columnHUB3_HITNO;

            private DataColumn columnOpisPlacanja;
            private DataColumn columnRoditelj;
            private DataColumn columnRoditeljAdresa;
            private DataColumn columnOpisProizvoda;
            private DataColumn columnCijena;
            private DataColumn columnKolicina;

            public event VIRMANIDataSet.VIRMANIRowChangeEventHandler VIRMANIRowChanged;

            public event VIRMANIDataSet.VIRMANIRowChangeEventHandler VIRMANIRowChanging;

            public event VIRMANIDataSet.VIRMANIRowChangeEventHandler VIRMANIRowDeleted;

            public event VIRMANIDataSet.VIRMANIRowChangeEventHandler VIRMANIRowDeleting;

            public VIRMANIDataTable()
            {
                this.TableName = "VIRMANI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal VIRMANIDataTable(DataTable table) : base(table.TableName)
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

            protected VIRMANIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddVIRMANIRow(VIRMANIDataSet.VIRMANIRow row)
            {
                this.Rows.Add(row);
            }

            public VIRMANIDataSet.VIRMANIRow AddVIRMANIRow(string sIFRAOBRACUNAVIRMAN, string pLA1, string pLA2, string pLA3, string bROJRACUNAPLA, string mODELZADUZENJA, string pOZIVZADUZENJA, 
                                                           string pRI1, string pRI2, string pRI3, string bROJRACUNAPRI, string mODELODOBRENJA, string pOZIVODOBRENJA, string sIFRAOPISAPLACANJAVIRMAN, 
                                                           string oPISPLACANJAVIRMAN, DateTime dATUMVALUTE, DateTime dATUMPODNOSENJA, string iZVORDOKUMENTA, bool oZNACEN, decimal iZNOS, 
                                                           string nAMJENA, string hUB3_SIFRANAMJENE, string hUB3_HITNO, string opisPlacanja, string roditelj, string roditeljAdresa,
                                                           string opisProizvoda, decimal cijena, decimal kolicina)
            {
                VIRMANIDataSet.VIRMANIRow row = (VIRMANIDataSet.VIRMANIRow) this.NewRow();
                row["SIFRAOBRACUNAVIRMAN"] = sIFRAOBRACUNAVIRMAN;
                row["PLA1"] = pLA1;
                row["PLA2"] = pLA2;
                row["PLA3"] = pLA3;
                row["BROJRACUNAPLA"] = bROJRACUNAPLA;
                row["MODELZADUZENJA"] = mODELZADUZENJA;
                row["POZIVZADUZENJA"] = pOZIVZADUZENJA;
                row["PRI1"] = pRI1;
                row["PRI2"] = pRI2;
                row["PRI3"] = pRI3;
                row["BROJRACUNAPRI"] = bROJRACUNAPRI;
                row["MODELODOBRENJA"] = mODELODOBRENJA;
                row["POZIVODOBRENJA"] = pOZIVODOBRENJA;
                row["SIFRAOPISAPLACANJAVIRMAN"] = sIFRAOPISAPLACANJAVIRMAN;
                row["OPISPLACANJAVIRMAN"] = oPISPLACANJAVIRMAN;
                row["DATUMVALUTE"] = dATUMVALUTE;
                row["DATUMPODNOSENJA"] = dATUMPODNOSENJA;
                row["IZVORDOKUMENTA"] = iZVORDOKUMENTA;
                row["OZNACEN"] = oZNACEN;
                row["IZNOS"] = iZNOS;
                row["NAMJENA"] = nAMJENA;
                row["HUB3_SIFRANAMJENE"] = hUB3_SIFRANAMJENE;
                row["HUB3_HITNO"] = hUB3_HITNO;

                row["OpisPlacanja"] = opisPlacanja;
                row["Roditelj"] = roditelj;
                row["RoditeljAdresa"] = roditeljAdresa;
                row["OpisProizvoda"] = opisProizvoda;
                row["Cijena"] = cijena;
                row["Kolicina"] = kolicina;

                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                VIRMANIDataSet.VIRMANIDataTable table = (VIRMANIDataSet.VIRMANIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public VIRMANIDataSet.VIRMANIRow FindByIDVIRMAN(int iDVIRMAN)
            {
                return (VIRMANIDataSet.VIRMANIRow) this.Rows.Find(new object[] { iDVIRMAN });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(VIRMANIDataSet.VIRMANIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                VIRMANIDataSet set = new VIRMANIDataSet();
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
                this.columnIDVIRMAN = new DataColumn("IDVIRMAN", typeof(int), "", MappingType.Element);
                this.columnIDVIRMAN.AllowDBNull = false;
                this.columnIDVIRMAN.Caption = "IDVIRMAN";
                this.columnIDVIRMAN.Unique = true;
                this.columnIDVIRMAN.AutoIncrement = true;
                this.columnIDVIRMAN.AutoIncrementSeed = -1L;
                this.columnIDVIRMAN.AutoIncrementStep = -1L;
                this.columnIDVIRMAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDVIRMAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDVIRMAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDVIRMAN.ExtendedProperties.Add("AutoNumber", "true");
                this.columnIDVIRMAN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDVIRMAN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDVIRMAN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDVIRMAN.ExtendedProperties.Add("Description", "IDVIRMAN");
                this.columnIDVIRMAN.ExtendedProperties.Add("Length", "5");
                this.columnIDVIRMAN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDVIRMAN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDVIRMAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDVIRMAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDVIRMAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDVIRMAN.ExtendedProperties.Add("Deklarit.InternalName", "IDVIRMAN");
                this.Columns.Add(this.columnIDVIRMAN);
                this.columnSIFRAOBRACUNAVIRMAN = new DataColumn("SIFRAOBRACUNAVIRMAN", typeof(string), "", MappingType.Element);
                this.columnSIFRAOBRACUNAVIRMAN.AllowDBNull = false;
                this.columnSIFRAOBRACUNAVIRMAN.Caption = "SIFRAOBRACUNAVIRMAN";
                this.columnSIFRAOBRACUNAVIRMAN.MaxLength = 11;
                this.columnSIFRAOBRACUNAVIRMAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Description", "SIFRAOBRACUNAVIRMAN");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Length", "11");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOBRACUNAVIRMAN.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOBRACUNAVIRMAN");
                this.Columns.Add(this.columnSIFRAOBRACUNAVIRMAN);
                this.columnPLA1 = new DataColumn("PLA1", typeof(string), "", MappingType.Element);
                this.columnPLA1.AllowDBNull = true;
                this.columnPLA1.Caption = "PL A1";
                this.columnPLA1.MaxLength = 30;
                this.columnPLA1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLA1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLA1.ExtendedProperties.Add("IsKey", "false");
                this.columnPLA1.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPLA1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPLA1.ExtendedProperties.Add("Description", "PL A1");
                this.columnPLA1.ExtendedProperties.Add("Length", "30");
                this.columnPLA1.ExtendedProperties.Add("Decimals", "0");
                this.columnPLA1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPLA1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLA1.ExtendedProperties.Add("Deklarit.InternalName", "PLA1");
                this.Columns.Add(this.columnPLA1);
                this.columnPLA2 = new DataColumn("PLA2", typeof(string), "", MappingType.Element);
                this.columnPLA2.AllowDBNull = true;
                this.columnPLA2.Caption = "PL A2";
                this.columnPLA2.MaxLength = 30;
                this.columnPLA2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLA2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLA2.ExtendedProperties.Add("IsKey", "false");
                this.columnPLA2.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPLA2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPLA2.ExtendedProperties.Add("Description", "PL A2");
                this.columnPLA2.ExtendedProperties.Add("Length", "30");
                this.columnPLA2.ExtendedProperties.Add("Decimals", "0");
                this.columnPLA2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPLA2.ExtendedProperties.Add("IsInReader", "true");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLA2.ExtendedProperties.Add("Deklarit.InternalName", "PLA2");
                this.Columns.Add(this.columnPLA2);
                this.columnPLA3 = new DataColumn("PLA3", typeof(string), "", MappingType.Element);
                this.columnPLA3.AllowDBNull = true;
                this.columnPLA3.Caption = "PL A3";
                this.columnPLA3.MaxLength = 30;
                this.columnPLA3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLA3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLA3.ExtendedProperties.Add("IsKey", "false");
                this.columnPLA3.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPLA3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPLA3.ExtendedProperties.Add("Description", "PL A3");
                this.columnPLA3.ExtendedProperties.Add("Length", "30");
                this.columnPLA3.ExtendedProperties.Add("Decimals", "0");
                this.columnPLA3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPLA3.ExtendedProperties.Add("IsInReader", "true");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLA3.ExtendedProperties.Add("Deklarit.InternalName", "PLA3");
                this.Columns.Add(this.columnPLA3);
                this.columnBROJRACUNAPLA = new DataColumn("BROJRACUNAPLA", typeof(string), "", MappingType.Element);
                this.columnBROJRACUNAPLA.AllowDBNull = true;
                this.columnBROJRACUNAPLA.Caption = "BROJRACUNAPLA";
                this.columnBROJRACUNAPLA.MaxLength = 30;
                this.columnBROJRACUNAPLA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Description", "BROJRACUNAPLA");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Length", "30");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRACUNAPLA.ExtendedProperties.Add("Deklarit.InternalName", "BROJRACUNAPLA");
                this.Columns.Add(this.columnBROJRACUNAPLA);
                this.columnMODELZADUZENJA = new DataColumn("MODELZADUZENJA", typeof(string), "", MappingType.Element);
                this.columnMODELZADUZENJA.AllowDBNull = true;
                this.columnMODELZADUZENJA.Caption = "MODELZADUZENJA";
                this.columnMODELZADUZENJA.MaxLength = 2;
                this.columnMODELZADUZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Description", "MODELZADUZENJA");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Length", "2");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMODELZADUZENJA.ExtendedProperties.Add("Deklarit.InternalName", "MODELZADUZENJA");
                this.Columns.Add(this.columnMODELZADUZENJA);
                this.columnPOZIVZADUZENJA = new DataColumn("POZIVZADUZENJA", typeof(string), "", MappingType.Element);
                this.columnPOZIVZADUZENJA.AllowDBNull = true;
                this.columnPOZIVZADUZENJA.Caption = "POZIVZADUZENJA";
                this.columnPOZIVZADUZENJA.MaxLength = 0x16;
                this.columnPOZIVZADUZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Description", "POZIVZADUZENJA");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Length", "22");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOZIVZADUZENJA.ExtendedProperties.Add("Deklarit.InternalName", "POZIVZADUZENJA");
                this.Columns.Add(this.columnPOZIVZADUZENJA);
                this.columnPRI1 = new DataColumn("PRI1", typeof(string), "", MappingType.Element);
                this.columnPRI1.AllowDBNull = true;
                this.columnPRI1.Caption = "PR I1";
                this.columnPRI1.MaxLength = 30;
                this.columnPRI1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRI1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRI1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRI1.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRI1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRI1.ExtendedProperties.Add("Description", "PR I1");
                this.columnPRI1.ExtendedProperties.Add("Length", "30");
                this.columnPRI1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRI1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRI1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRI1.ExtendedProperties.Add("Deklarit.InternalName", "PRI1");
                this.Columns.Add(this.columnPRI1);
                this.columnPRI2 = new DataColumn("PRI2", typeof(string), "", MappingType.Element);
                this.columnPRI2.AllowDBNull = true;
                this.columnPRI2.Caption = "PR I2";
                this.columnPRI2.MaxLength = 30;
                this.columnPRI2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRI2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRI2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRI2.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRI2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRI2.ExtendedProperties.Add("Description", "PR I2");
                this.columnPRI2.ExtendedProperties.Add("Length", "30");
                this.columnPRI2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRI2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRI2.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRI2.ExtendedProperties.Add("Deklarit.InternalName", "PRI2");
                this.Columns.Add(this.columnPRI2);
                this.columnPRI3 = new DataColumn("PRI3", typeof(string), "", MappingType.Element);
                this.columnPRI3.AllowDBNull = true;
                this.columnPRI3.Caption = "PR I3";
                this.columnPRI3.MaxLength = 30;
                this.columnPRI3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRI3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRI3.ExtendedProperties.Add("IsKey", "false");
                this.columnPRI3.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRI3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRI3.ExtendedProperties.Add("Description", "PR I3");
                this.columnPRI3.ExtendedProperties.Add("Length", "30");
                this.columnPRI3.ExtendedProperties.Add("Decimals", "0");
                this.columnPRI3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRI3.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRI3.ExtendedProperties.Add("Deklarit.InternalName", "PRI3");
                this.Columns.Add(this.columnPRI3);
                this.columnBROJRACUNAPRI = new DataColumn("BROJRACUNAPRI", typeof(string), "", MappingType.Element);
                this.columnBROJRACUNAPRI.AllowDBNull = true;
                this.columnBROJRACUNAPRI.Caption = "BROJRACUNAPRI";
                this.columnBROJRACUNAPRI.MaxLength = 30;
                this.columnBROJRACUNAPRI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Description", "BROJRACUNAPRI");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Length", "30");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRACUNAPRI.ExtendedProperties.Add("Deklarit.InternalName", "BROJRACUNAPRI");
                this.Columns.Add(this.columnBROJRACUNAPRI);
                this.columnMODELODOBRENJA = new DataColumn("MODELODOBRENJA", typeof(string), "", MappingType.Element);
                this.columnMODELODOBRENJA.AllowDBNull = true;
                this.columnMODELODOBRENJA.Caption = "MODELODOBRENJA";
                this.columnMODELODOBRENJA.MaxLength = 2;
                this.columnMODELODOBRENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Description", "MODELODOBRENJA");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Length", "2");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMODELODOBRENJA.ExtendedProperties.Add("Deklarit.InternalName", "MODELODOBRENJA");
                this.Columns.Add(this.columnMODELODOBRENJA);
                this.columnPOZIVODOBRENJA = new DataColumn("POZIVODOBRENJA", typeof(string), "", MappingType.Element);
                this.columnPOZIVODOBRENJA.AllowDBNull = true;
                this.columnPOZIVODOBRENJA.Caption = "POZIVODOBRENJA";
                this.columnPOZIVODOBRENJA.MaxLength = 26;
                this.columnPOZIVODOBRENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Description", "POZIVODOBRENJA");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Length", "22");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOZIVODOBRENJA.ExtendedProperties.Add("Deklarit.InternalName", "POZIVODOBRENJA");
                this.Columns.Add(this.columnPOZIVODOBRENJA);
                this.columnSIFRAOPISAPLACANJAVIRMAN = new DataColumn("SIFRAOPISAPLACANJAVIRMAN", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAVIRMAN.AllowDBNull = true;
                this.columnSIFRAOPISAPLACANJAVIRMAN.Caption = "SIFRAOPISAPLACANJAVIRMAN";
                this.columnSIFRAOPISAPLACANJAVIRMAN.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAVIRMAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Description", "SIFRAOPISAPLACANJAVIRMAN");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAVIRMAN");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAVIRMAN);
                this.columnOPISPLACANJAVIRMAN = new DataColumn("OPISPLACANJAVIRMAN", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAVIRMAN.AllowDBNull = true;
                this.columnOPISPLACANJAVIRMAN.Caption = "OPISPLACANJAVIRMAN";
                this.columnOPISPLACANJAVIRMAN.MaxLength = 130;
                this.columnOPISPLACANJAVIRMAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Description", "OPISPLACANJAVIRMAN");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Length", "130");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAVIRMAN.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAVIRMAN");
                this.Columns.Add(this.columnOPISPLACANJAVIRMAN);
                this.columnDATUMVALUTE = new DataColumn("DATUMVALUTE", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMVALUTE.AllowDBNull = true;
                this.columnDATUMVALUTE.Caption = "DATUMVALUTE";
                this.columnDATUMVALUTE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMVALUTE.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMVALUTE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMVALUTE.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Description", "DATUMVALUTE");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Length", "8");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMVALUTE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMVALUTE.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMVALUTE.ExtendedProperties.Add("Deklarit.InternalName", "DATUMVALUTE");
                this.Columns.Add(this.columnDATUMVALUTE);
                this.columnDATUMPODNOSENJA = new DataColumn("DATUMPODNOSENJA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMPODNOSENJA.AllowDBNull = true;
                this.columnDATUMPODNOSENJA.Caption = "DATUMPODNOSENJA";
                this.columnDATUMPODNOSENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Description", "DATUMPODNOSENJA");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMPODNOSENJA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMPODNOSENJA");
                this.Columns.Add(this.columnDATUMPODNOSENJA);
                this.columnIZVORDOKUMENTA = new DataColumn("IZVORDOKUMENTA", typeof(string), "", MappingType.Element);
                this.columnIZVORDOKUMENTA.AllowDBNull = true;
                this.columnIZVORDOKUMENTA.Caption = "IZVORDOKUMENTA";
                this.columnIZVORDOKUMENTA.MaxLength = 3;
                this.columnIZVORDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Description", "IZVORDOKUMENTA");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Length", "3");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZVORDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "IZVORDOKUMENTA");
                this.Columns.Add(this.columnIZVORDOKUMENTA);
                this.columnOZNACEN = new DataColumn("OZNACEN", typeof(bool), "", MappingType.Element);
                this.columnOZNACEN.AllowDBNull = true;
                this.columnOZNACEN.Caption = "OZNACEN";
                this.columnOZNACEN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOZNACEN.ExtendedProperties.Add("IsKey", "false");
                this.columnOZNACEN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOZNACEN.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnOZNACEN.ExtendedProperties.Add("Description", "OZNACEN");
                this.columnOZNACEN.ExtendedProperties.Add("Length", "1");
                this.columnOZNACEN.ExtendedProperties.Add("Decimals", "0");
                this.columnOZNACEN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOZNACEN.ExtendedProperties.Add("IsInReader", "true");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.InternalName", "OZNACEN");
                this.Columns.Add(this.columnOZNACEN);
                this.columnIZNOS = new DataColumn("IZNOS", typeof(decimal), "", MappingType.Element);
                this.columnIZNOS.AllowDBNull = true;
                this.columnIZNOS.Caption = "IZNOS";
                this.columnIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOS.ExtendedProperties.Add("Description", "IZNOS");
                this.columnIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "IZNOS");
                this.Columns.Add(this.columnIZNOS);

                this.columnNAMJENA = new DataColumn("NAMJENA", typeof(string), "", MappingType.Element);
                this.columnNAMJENA.AllowDBNull = false;
                this.columnNAMJENA.Caption = "NAMJENA";
                this.columnNAMJENA.MaxLength = 20;
                this.columnNAMJENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAMJENA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAMJENA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAMJENA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAMJENA.ExtendedProperties.Add("Description", "NAMJENA");
                this.columnNAMJENA.ExtendedProperties.Add("Length", "20");
                this.columnNAMJENA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAMJENA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAMJENA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAMJENA.ExtendedProperties.Add("Deklarit.InternalName", "NAMJENA");
                this.Columns.Add(this.columnNAMJENA);

                this.columnHUB3_SIFRANAMJENE = new DataColumn("HUB3_SIFRANAMJENE", typeof(string), "", MappingType.Element);
                this.columnHUB3_SIFRANAMJENE.AllowDBNull = true;
                this.columnHUB3_SIFRANAMJENE.Caption = "HUB3_SIFRANAMJENE";
                this.columnHUB3_SIFRANAMJENE.MaxLength = 4;
                this.columnHUB3_SIFRANAMJENE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("IsKey", "false");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("Description", "HUB3_SIFRANAMJENE");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("Length", "4");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("Decimals", "0");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("IsInReader", "true");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnHUB3_SIFRANAMJENE.ExtendedProperties.Add("Deklarit.InternalName", "HUB3_SIFRANAMJENE");
                this.Columns.Add(this.columnHUB3_SIFRANAMJENE);

                this.columnHUB3_HITNO = new DataColumn("HUB3_HITNO", typeof(bool), "", MappingType.Element);
                this.columnHUB3_HITNO.AllowDBNull = true;
                this.columnHUB3_HITNO.Caption = "HUB3_HITNO";
                this.columnHUB3_HITNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnHUB3_HITNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnHUB3_HITNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnHUB3_HITNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnHUB3_HITNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnHUB3_HITNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnHUB3_HITNO.ExtendedProperties.Add("IsKey", "false");
                this.columnHUB3_HITNO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnHUB3_HITNO.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnHUB3_HITNO.ExtendedProperties.Add("Description", "HUB3_HITNO");
                this.columnHUB3_HITNO.ExtendedProperties.Add("Length", "1");
                this.columnHUB3_HITNO.ExtendedProperties.Add("Decimals", "0");
                this.columnHUB3_HITNO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnHUB3_HITNO.ExtendedProperties.Add("IsInReader", "true");
                this.columnHUB3_HITNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnHUB3_HITNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnHUB3_HITNO.ExtendedProperties.Add("Deklarit.InternalName", "HUB3_HITNO");
                this.Columns.Add(this.columnHUB3_HITNO);

                this.columnOpisPlacanja = new DataColumn("OpisPlacanja", typeof(string), "", MappingType.Element);
                this.columnOpisPlacanja.AllowDBNull = true;
                this.columnOpisPlacanja.Caption = "OpisPlacanja";
                this.columnOpisPlacanja.MaxLength = 150;
                this.columnOpisPlacanja.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOpisPlacanja.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOpisPlacanja.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOpisPlacanja.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOpisPlacanja.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOpisPlacanja.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOpisPlacanja.ExtendedProperties.Add("IsKey", "false");
                this.columnOpisPlacanja.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOpisPlacanja.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOpisPlacanja.ExtendedProperties.Add("Description", "OpisPlacanja");
                this.columnOpisPlacanja.ExtendedProperties.Add("Length", "150");
                this.columnOpisPlacanja.ExtendedProperties.Add("Decimals", "0");
                this.columnOpisPlacanja.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOpisPlacanja.ExtendedProperties.Add("IsInReader", "true");
                this.columnOpisPlacanja.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOpisPlacanja.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOpisPlacanja.ExtendedProperties.Add("Deklarit.InternalName", "OpisPlacanja");
                this.Columns.Add(this.columnOpisPlacanja);

                this.columnRoditelj = new DataColumn("Roditelj", typeof(string), "", MappingType.Element);
                this.columnRoditelj.AllowDBNull = true;
                this.columnRoditelj.Caption = "Roditelj";
                this.columnRoditelj.MaxLength = 40;
                this.columnRoditelj.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRoditelj.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRoditelj.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRoditelj.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRoditelj.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRoditelj.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRoditelj.ExtendedProperties.Add("IsKey", "false");
                this.columnRoditelj.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRoditelj.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRoditelj.ExtendedProperties.Add("Description", "Roditelj");
                this.columnRoditelj.ExtendedProperties.Add("Length", "40");
                this.columnRoditelj.ExtendedProperties.Add("Decimals", "0");
                this.columnRoditelj.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRoditelj.ExtendedProperties.Add("IsInReader", "true");
                this.columnRoditelj.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRoditelj.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRoditelj.ExtendedProperties.Add("Deklarit.InternalName", "Roditelj");
                this.Columns.Add(this.columnRoditelj);

                this.columnRoditeljAdresa = new DataColumn("RoditeljAdresa", typeof(string), "", MappingType.Element);
                this.columnRoditeljAdresa.AllowDBNull = true;
                this.columnRoditeljAdresa.Caption = "RoditeljAdresa";
                this.columnRoditeljAdresa.MaxLength = 80;
                this.columnRoditeljAdresa.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRoditeljAdresa.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRoditeljAdresa.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRoditeljAdresa.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRoditeljAdresa.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRoditeljAdresa.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRoditeljAdresa.ExtendedProperties.Add("IsKey", "false");
                this.columnRoditeljAdresa.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRoditeljAdresa.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRoditeljAdresa.ExtendedProperties.Add("Description", "RoditeljAdresa");
                this.columnRoditeljAdresa.ExtendedProperties.Add("Length", "80");
                this.columnRoditeljAdresa.ExtendedProperties.Add("Decimals", "0");
                this.columnRoditeljAdresa.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRoditeljAdresa.ExtendedProperties.Add("IsInReader", "true");
                this.columnRoditeljAdresa.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRoditeljAdresa.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRoditeljAdresa.ExtendedProperties.Add("Deklarit.InternalName", "Roditelj");
                this.Columns.Add(this.columnRoditeljAdresa);

                this.columnOpisProizvoda = new DataColumn("OpisProizvoda", typeof(string), "", MappingType.Element);
                this.columnOpisProizvoda.AllowDBNull = true;
                this.columnOpisProizvoda.Caption = "OpisProizvoda";
                this.columnOpisProizvoda.MaxLength = 100;
                this.columnOpisProizvoda.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOpisProizvoda.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOpisProizvoda.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOpisProizvoda.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOpisProizvoda.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOpisProizvoda.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOpisProizvoda.ExtendedProperties.Add("IsKey", "false");
                this.columnOpisProizvoda.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOpisProizvoda.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOpisProizvoda.ExtendedProperties.Add("Description", "OpisProizvoda");
                this.columnOpisProizvoda.ExtendedProperties.Add("Length", "100");
                this.columnOpisProizvoda.ExtendedProperties.Add("Decimals", "0");
                this.columnOpisProizvoda.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOpisProizvoda.ExtendedProperties.Add("IsInReader", "true");
                this.columnOpisProizvoda.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOpisProizvoda.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOpisProizvoda.ExtendedProperties.Add("Deklarit.InternalName", "Roditelj");
                this.Columns.Add(this.columnOpisProizvoda);

                this.columnCijena = new DataColumn("Cijena", typeof(decimal), "", MappingType.Element);
                this.columnCijena.AllowDBNull = true;
                this.columnCijena.Caption = "Cijena";
                this.columnCijena.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnCijena.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnCijena.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnCijena.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnCijena.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnCijena.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnCijena.ExtendedProperties.Add("IsKey", "false");
                this.columnCijena.ExtendedProperties.Add("ReadOnly", "false");
                this.columnCijena.ExtendedProperties.Add("DeklaritType", "int");
                this.columnCijena.ExtendedProperties.Add("Description", "Cijena");
                this.columnCijena.ExtendedProperties.Add("Length", "18");
                this.columnCijena.ExtendedProperties.Add("Decimals", "2");
                this.columnCijena.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnCijena.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnCijena.ExtendedProperties.Add("IsInReader", "true");
                this.columnCijena.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnCijena.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnCijena.ExtendedProperties.Add("Deklarit.InternalName", "Cijena");
                this.Columns.Add(this.columnCijena);

                this.columnKolicina = new DataColumn("Kolicina", typeof(decimal), "", MappingType.Element);
                this.columnKolicina.AllowDBNull = true;
                this.columnKolicina.Caption = "Kolicina";
                this.columnKolicina.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKolicina.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKolicina.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKolicina.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKolicina.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKolicina.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKolicina.ExtendedProperties.Add("IsKey", "false");
                this.columnKolicina.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKolicina.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKolicina.ExtendedProperties.Add("Description", "Kolicina");
                this.columnKolicina.ExtendedProperties.Add("Length", "9");
                this.columnKolicina.ExtendedProperties.Add("Decimals", "2");
                this.columnKolicina.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKolicina.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKolicina.ExtendedProperties.Add("IsInReader", "true");
                this.columnKolicina.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKolicina.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKolicina.ExtendedProperties.Add("Deklarit.InternalName", "Kolicina");
                this.Columns.Add(this.columnKolicina);


                this.PrimaryKey = new DataColumn[] { this.columnIDVIRMAN };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "VIRMANI");
                this.ExtendedProperties.Add("Description", "VIRMANI");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDVIRMAN = this.Columns["IDVIRMAN"];
                this.columnSIFRAOBRACUNAVIRMAN = this.Columns["SIFRAOBRACUNAVIRMAN"];
                this.columnPLA1 = this.Columns["PLA1"];
                this.columnPLA2 = this.Columns["PLA2"];
                this.columnPLA3 = this.Columns["PLA3"];
                this.columnBROJRACUNAPLA = this.Columns["BROJRACUNAPLA"];
                this.columnMODELZADUZENJA = this.Columns["MODELZADUZENJA"];
                this.columnPOZIVZADUZENJA = this.Columns["POZIVZADUZENJA"];
                this.columnPRI1 = this.Columns["PRI1"];
                this.columnPRI2 = this.Columns["PRI2"];
                this.columnPRI3 = this.Columns["PRI3"];
                this.columnBROJRACUNAPRI = this.Columns["BROJRACUNAPRI"];
                this.columnMODELODOBRENJA = this.Columns["MODELODOBRENJA"];
                this.columnPOZIVODOBRENJA = this.Columns["POZIVODOBRENJA"];
                this.columnSIFRAOPISAPLACANJAVIRMAN = this.Columns["SIFRAOPISAPLACANJAVIRMAN"];
                this.columnOPISPLACANJAVIRMAN = this.Columns["OPISPLACANJAVIRMAN"];
                this.columnDATUMVALUTE = this.Columns["DATUMVALUTE"];
                this.columnDATUMPODNOSENJA = this.Columns["DATUMPODNOSENJA"];
                this.columnIZVORDOKUMENTA = this.Columns["IZVORDOKUMENTA"];
                this.columnOZNACEN = this.Columns["OZNACEN"];
                this.columnIZNOS = this.Columns["IZNOS"];
                this.columnNAMJENA = this.Columns["NAMJENA"];
                this.columnHUB3_SIFRANAMJENE = this.Columns["HUB3_SIFRANAMJENE"];
                this.columnHUB3_HITNO = this.Columns["HUB3_HITNO"];

                this.columnOpisPlacanja = this.Columns["OpisPlacanja"];
                this.columnRoditelj = this.Columns["Roditelj"];
                this.columnRoditeljAdresa = this.Columns["RoditeljAdresa"];
                this.columnOpisProizvoda = this.Columns["OpisProizvoda"];
                this.columnCijena = this.Columns["Cijena"];
                this.columnKolicina = this.Columns["Kolicina"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new VIRMANIDataSet.VIRMANIRow(builder);
            }

            public VIRMANIDataSet.VIRMANIRow NewVIRMANIRow()
            {
                return (VIRMANIDataSet.VIRMANIRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VIRMANIRowChanged != null)
                {
                    VIRMANIDataSet.VIRMANIRowChangeEventHandler vIRMANIRowChangedEvent = this.VIRMANIRowChanged;
                    if (vIRMANIRowChangedEvent != null)
                    {
                        vIRMANIRowChangedEvent(this, new VIRMANIDataSet.VIRMANIRowChangeEvent((VIRMANIDataSet.VIRMANIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VIRMANIRowChanging != null)
                {
                    VIRMANIDataSet.VIRMANIRowChangeEventHandler vIRMANIRowChangingEvent = this.VIRMANIRowChanging;
                    if (vIRMANIRowChangingEvent != null)
                    {
                        vIRMANIRowChangingEvent(this, new VIRMANIDataSet.VIRMANIRowChangeEvent((VIRMANIDataSet.VIRMANIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VIRMANIRowDeleted != null)
                {
                    VIRMANIDataSet.VIRMANIRowChangeEventHandler vIRMANIRowDeletedEvent = this.VIRMANIRowDeleted;
                    if (vIRMANIRowDeletedEvent != null)
                    {
                        vIRMANIRowDeletedEvent(this, new VIRMANIDataSet.VIRMANIRowChangeEvent((VIRMANIDataSet.VIRMANIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VIRMANIRowDeleting != null)
                {
                    VIRMANIDataSet.VIRMANIRowChangeEventHandler vIRMANIRowDeletingEvent = this.VIRMANIRowDeleting;
                    if (vIRMANIRowDeletingEvent != null)
                    {
                        vIRMANIRowDeletingEvent(this, new VIRMANIDataSet.VIRMANIRowChangeEvent((VIRMANIDataSet.VIRMANIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveVIRMANIRow(VIRMANIDataSet.VIRMANIRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJRACUNAPLAColumn
            {
                get
                {
                    return this.columnBROJRACUNAPLA;
                }
            }

            public DataColumn BROJRACUNAPRIColumn
            {
                get
                {
                    return this.columnBROJRACUNAPRI;
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

            public DataColumn DATUMPODNOSENJAColumn
            {
                get
                {
                    return this.columnDATUMPODNOSENJA;
                }
            }

            public DataColumn DATUMVALUTEColumn
            {
                get
                {
                    return this.columnDATUMVALUTE;
                }
            }

            public DataColumn IDVIRMANColumn
            {
                get
                {
                    return this.columnIDVIRMAN;
                }
            }

            public VIRMANIDataSet.VIRMANIRow this[int index]
            {
                get
                {
                    return (VIRMANIDataSet.VIRMANIRow) this.Rows[index];
                }
            }

            public DataColumn IZNOSColumn
            {
                get
                {
                    return this.columnIZNOS;
                }
            }

            public DataColumn IZVORDOKUMENTAColumn
            {
                get
                {
                    return this.columnIZVORDOKUMENTA;
                }
            }

            public DataColumn MODELODOBRENJAColumn
            {
                get
                {
                    return this.columnMODELODOBRENJA;
                }
            }

            public DataColumn MODELZADUZENJAColumn
            {
                get
                {
                    return this.columnMODELZADUZENJA;
                }
            }

            public DataColumn NAMJENAColumn
            {
                get
                {
                    return this.columnNAMJENA;
                }
            }

            public DataColumn OPISPLACANJAVIRMANColumn
            {
                get
                {
                    return this.columnOPISPLACANJAVIRMAN;
                }
            }

            public DataColumn OZNACENColumn
            {
                get
                {
                    return this.columnOZNACEN;
                }
            }

            public DataColumn PLA1Column
            {
                get
                {
                    return this.columnPLA1;
                }
            }

            public DataColumn PLA2Column
            {
                get
                {
                    return this.columnPLA2;
                }
            }

            public DataColumn PLA3Column
            {
                get
                {
                    return this.columnPLA3;
                }
            }

            public DataColumn POZIVODOBRENJAColumn
            {
                get
                {
                    return this.columnPOZIVODOBRENJA;
                }
            }

            public DataColumn POZIVZADUZENJAColumn
            {
                get
                {
                    return this.columnPOZIVZADUZENJA;
                }
            }

            public DataColumn PRI1Column
            {
                get
                {
                    return this.columnPRI1;
                }
            }

            public DataColumn PRI2Column
            {
                get
                {
                    return this.columnPRI2;
                }
            }

            public DataColumn PRI3Column
            {
                get
                {
                    return this.columnPRI3;
                }
            }

            public DataColumn SIFRAOBRACUNAVIRMANColumn
            {
                get
                {
                    return this.columnSIFRAOBRACUNAVIRMAN;
                }
            }

            public DataColumn SIFRAOPISAPLACANJAVIRMANColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJAVIRMAN;
                }
            }

            public DataColumn HUB3_SIFRANAMJENEColumn
            {
                get
                {
                    return this.columnHUB3_SIFRANAMJENE;
                }
            }

            public DataColumn HUB3_HITNOColumn
            {
                get
                {
                    return this.columnHUB3_HITNO;
                }
            }

            public DataColumn OpisPlacanjaColumn
            {
                get
                {
                    return this.columnOpisPlacanja;
                }
            }

            public DataColumn RoditeljColumn
            {
                get
                {
                    return this.columnRoditelj;
                }
            }

            public DataColumn RoditeljAdresaColumn
            {
                get
                {
                    return this.columnRoditeljAdresa;
                }
            }

            public DataColumn OpisProizvodaColumn
            {
                get
                {
                    return this.columnOpisProizvoda;
                }
            }

            public DataColumn CijenaColumn
            {
                get
                {
                    return this.columnCijena;
                }
            }

            public DataColumn KolicinaColumn
            {
                get
                {
                    return this.columnKolicina;
                }
            }
        }

        public class VIRMANIRow : DataRow
        {
            private VIRMANIDataSet.VIRMANIDataTable tableVIRMANI;

            internal VIRMANIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableVIRMANI = (VIRMANIDataSet.VIRMANIDataTable) this.Table;
            }

            public bool IsBROJRACUNAPLANull()
            {
                return this.IsNull(this.tableVIRMANI.BROJRACUNAPLAColumn);
            }

            public bool IsBROJRACUNAPRINull()
            {
                return this.IsNull(this.tableVIRMANI.BROJRACUNAPRIColumn);
            }

            public bool IsDATUMPODNOSENJANull()
            {
                return this.IsNull(this.tableVIRMANI.DATUMPODNOSENJAColumn);
            }

            public bool IsDATUMVALUTENull()
            {
                return this.IsNull(this.tableVIRMANI.DATUMVALUTEColumn);
            }

            public bool IsIDVIRMANNull()
            {
                return this.IsNull(this.tableVIRMANI.IDVIRMANColumn);
            }

            public bool IsIZNOSNull()
            {
                return this.IsNull(this.tableVIRMANI.IZNOSColumn);
            }

            public bool IsIZVORDOKUMENTANull()
            {
                return this.IsNull(this.tableVIRMANI.IZVORDOKUMENTAColumn);
            }

            public bool IsMODELODOBRENJANull()
            {
                return this.IsNull(this.tableVIRMANI.MODELODOBRENJAColumn);
            }

            public bool IsMODELZADUZENJANull()
            {
                return this.IsNull(this.tableVIRMANI.MODELZADUZENJAColumn);
            }

            public bool IsNAMJENANull()
            {
                return this.IsNull(this.tableVIRMANI.NAMJENAColumn);
            }

            public bool IsOPISPLACANJAVIRMANNull()
            {
                return this.IsNull(this.tableVIRMANI.OPISPLACANJAVIRMANColumn);
            }

            public bool IsOZNACENNull()
            {
                return this.IsNull(this.tableVIRMANI.OZNACENColumn);
            }

            public bool IsPLA1Null()
            {
                return this.IsNull(this.tableVIRMANI.PLA1Column);
            }

            public bool IsPLA2Null()
            {
                return this.IsNull(this.tableVIRMANI.PLA2Column);
            }

            public bool IsPLA3Null()
            {
                return this.IsNull(this.tableVIRMANI.PLA3Column);
            }

            public bool IsPOZIVODOBRENJANull()
            {
                return this.IsNull(this.tableVIRMANI.POZIVODOBRENJAColumn);
            }

            public bool IsPOZIVZADUZENJANull()
            {
                return this.IsNull(this.tableVIRMANI.POZIVZADUZENJAColumn);
            }

            public bool IsPRI1Null()
            {
                return this.IsNull(this.tableVIRMANI.PRI1Column);
            }

            public bool IsPRI2Null()
            {
                return this.IsNull(this.tableVIRMANI.PRI2Column);
            }

            public bool IsPRI3Null()
            {
                return this.IsNull(this.tableVIRMANI.PRI3Column);
            }

            public bool IsSIFRAOBRACUNAVIRMANNull()
            {
                return this.IsNull(this.tableVIRMANI.SIFRAOBRACUNAVIRMANColumn);
            }

            public bool IsSIFRAOPISAPLACANJAVIRMANNull()
            {
                return this.IsNull(this.tableVIRMANI.SIFRAOPISAPLACANJAVIRMANColumn);
            }

            public bool IsHUB3_SIFRANAMJENENull()
            {
                return this.IsNull(this.tableVIRMANI.HUB3_SIFRANAMJENEColumn);
            }

            public bool IsHUB3_HITNONull()
            {
                return this.IsNull(this.tableVIRMANI.HUB3_HITNOColumn);
            }

            public bool IsOpisPlacanjaNull()
            {
                return this.IsNull(this.tableVIRMANI.OpisPlacanjaColumn);
            }

            public bool IsRoditeljNull()
            {
                return this.IsNull(this.tableVIRMANI.RoditeljColumn);
            }

            public bool IsRoditeljAdresaNull()
            {
                return this.IsNull(this.tableVIRMANI.RoditeljAdresaColumn);
            }

            public bool IsOpisProizvodaNull()
            {
                return this.IsNull(this.tableVIRMANI.OpisProizvodaColumn);
            }

            public bool IsCijenaNull()
            {
                return this.IsNull(this.tableVIRMANI.CijenaColumn);
            }

            public bool IsKolicinaNull()
            {
                return this.IsNull(this.tableVIRMANI.KolicinaColumn);
            }

            public void SetBROJRACUNAPLANull()
            {
                this[this.tableVIRMANI.BROJRACUNAPLAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJRACUNAPRINull()
            {
                this[this.tableVIRMANI.BROJRACUNAPRIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMPODNOSENJANull()
            {
                this[this.tableVIRMANI.DATUMPODNOSENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMVALUTENull()
            {
                this[this.tableVIRMANI.DATUMVALUTEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSNull()
            {
                this[this.tableVIRMANI.IZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZVORDOKUMENTANull()
            {
                this[this.tableVIRMANI.IZVORDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMODELODOBRENJANull()
            {
                this[this.tableVIRMANI.MODELODOBRENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMODELZADUZENJANull()
            {
                this[this.tableVIRMANI.MODELZADUZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAMJENANull()
            {
                this[this.tableVIRMANI.NAMJENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAVIRMANNull()
            {
                this[this.tableVIRMANI.OPISPLACANJAVIRMANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOZNACENNull()
            {
                this[this.tableVIRMANI.OZNACENColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPLA1Null()
            {
                this[this.tableVIRMANI.PLA1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPLA2Null()
            {
                this[this.tableVIRMANI.PLA2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPLA3Null()
            {
                this[this.tableVIRMANI.PLA3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOZIVODOBRENJANull()
            {
                this[this.tableVIRMANI.POZIVODOBRENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOZIVZADUZENJANull()
            {
                this[this.tableVIRMANI.POZIVZADUZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRI1Null()
            {
                this[this.tableVIRMANI.PRI1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRI2Null()
            {
                this[this.tableVIRMANI.PRI2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRI3Null()
            {
                this[this.tableVIRMANI.PRI3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOBRACUNAVIRMANNull()
            {
                this[this.tableVIRMANI.SIFRAOBRACUNAVIRMANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAVIRMANNull()
            {
                this[this.tableVIRMANI.SIFRAOPISAPLACANJAVIRMANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetHUB3_SIFRANAMJENENull()
            {
                this[this.tableVIRMANI.HUB3_SIFRANAMJENEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetHUB3_HITNONull()
            {
                this[this.tableVIRMANI.HUB3_HITNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpisPlacanjaNull()
            {
                this[this.tableVIRMANI.OpisPlacanjaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRoditeljNull()
            {
                this[this.tableVIRMANI.RoditeljColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRoditeljAdresaNull()
            {
                this[this.tableVIRMANI.RoditeljAdresaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpisProizvodaNull()
            {
                this[this.tableVIRMANI.OpisProizvodaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetCijenaNull()
            {
                this[this.tableVIRMANI.CijenaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKolicinaNull()
            {
                this[this.tableVIRMANI.KolicinaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string BROJRACUNAPLA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.BROJRACUNAPLAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.BROJRACUNAPLAColumn] = value;
                }
            }

            public string BROJRACUNAPRI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.BROJRACUNAPRIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.BROJRACUNAPRIColumn] = value;
                }
            }

            public DateTime DATUMPODNOSENJA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableVIRMANI.DATUMPODNOSENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableVIRMANI.DATUMPODNOSENJAColumn] = value;
                }
            }

            public DateTime DATUMVALUTE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableVIRMANI.DATUMVALUTEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableVIRMANI.DATUMVALUTEColumn] = value;
                }
            }

            public int IDVIRMAN
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableVIRMANI.IDVIRMANColumn]);
                }
                set
                {
                    this[this.tableVIRMANI.IDVIRMANColumn] = value;
                }
            }

            public decimal IZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableVIRMANI.IZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableVIRMANI.IZNOSColumn] = value;
                }
            }

            public string IZVORDOKUMENTA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.IZVORDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.IZVORDOKUMENTAColumn] = value;
                }
            }

            public string MODELODOBRENJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.MODELODOBRENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.MODELODOBRENJAColumn] = value;
                }
            }

            public string MODELZADUZENJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.MODELZADUZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.MODELZADUZENJAColumn] = value;
                }
            }

            public string NAMJENA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.NAMJENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.NAMJENAColumn] = value;
                }
            }

            public string OPISPLACANJAVIRMAN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.OPISPLACANJAVIRMANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.OPISPLACANJAVIRMANColumn] = value;
                }
            }

            public bool OZNACEN
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableVIRMANI.OZNACENColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableVIRMANI.OZNACENColumn] = value;
                }
            }

            public string PLA1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.PLA1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.PLA1Column] = value;
                }
            }

            public string PLA2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.PLA2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.PLA2Column] = value;
                }
            }

            public string PLA3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.PLA3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.PLA3Column] = value;
                }
            }

            public string POZIVODOBRENJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.POZIVODOBRENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.POZIVODOBRENJAColumn] = value;
                }
            }

            public string POZIVZADUZENJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.POZIVZADUZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.POZIVZADUZENJAColumn] = value;
                }
            }

            public string PRI1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.PRI1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.PRI1Column] = value;
                }
            }

            public string PRI2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.PRI2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.PRI2Column] = value;
                }
            }

            public string PRI3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.PRI3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.PRI3Column] = value;
                }
            }

            public string SIFRAOBRACUNAVIRMAN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.SIFRAOBRACUNAVIRMANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.SIFRAOBRACUNAVIRMANColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAVIRMAN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.SIFRAOPISAPLACANJAVIRMANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.SIFRAOPISAPLACANJAVIRMANColumn] = value;
                }
            }

            public string HUB3_SIFRANAMJENE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVIRMANI.HUB3_SIFRANAMJENEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableVIRMANI.HUB3_SIFRANAMJENEColumn] = value;
                }
            }

            public bool HUB3_HITNO
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableVIRMANI.HUB3_HITNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableVIRMANI.HUB3_HITNOColumn] = value;
                }
            }

            public string OpisPlacanja
            {
                get
                {
                    string flag = string.Empty;
                    try
                    {
                        flag = Conversions.ToString(this[this.tableVIRMANI.OpisPlacanjaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableVIRMANI.OpisPlacanjaColumn] = value;
                }
            }

            public string Roditelj
            {
                get
                {
                    string flag = string.Empty;
                    try
                    {
                        flag = Conversions.ToString(this[this.tableVIRMANI.RoditeljColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableVIRMANI.RoditeljColumn] = value;
                }
            }

            public string RoditeljAdresa
            {
                get
                {
                    string flag = string.Empty;
                    try
                    {
                        flag = Conversions.ToString(this[this.tableVIRMANI.RoditeljAdresaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableVIRMANI.RoditeljAdresaColumn] = value;
                }
            }

            public string OpisProizvoda
            {
                get
                {
                    string flag = string.Empty;
                    try
                    {
                        flag = Conversions.ToString(this[this.tableVIRMANI.OpisProizvodaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableVIRMANI.OpisProizvodaColumn] = value;
                }
            }

            public decimal Cijena
            {
                get
                {
                    decimal flag = 0;
                    try
                    {
                        flag = Conversions.ToDecimal(this[this.tableVIRMANI.CijenaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableVIRMANI.CijenaColumn] = value;
                }
            }

            public decimal Kolicina
            {
                get
                {
                    decimal flag = 0;
                    try
                    {
                        flag = Conversions.ToDecimal(this[this.tableVIRMANI.KolicinaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableVIRMANI.KolicinaColumn] = value;
                }
            }
        }

        public class VIRMANIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private VIRMANIDataSet.VIRMANIRow eventRow;

            public VIRMANIRowChangeEvent(VIRMANIDataSet.VIRMANIRow row, DataRowAction action)
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

            public VIRMANIDataSet.VIRMANIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void VIRMANIRowChangeEventHandler(object sender, VIRMANIDataSet.VIRMANIRowChangeEvent e);
    }
}

