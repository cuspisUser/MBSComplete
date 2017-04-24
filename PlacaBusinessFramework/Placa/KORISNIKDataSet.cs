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
    public class KORISNIKDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private KORISNIKDataTable tableKORISNIK;
        private KORISNIKLevel1DataTable tableKORISNIKLevel1;

        public KORISNIKDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected KORISNIKDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["KORISNIKLevel1"] != null)
                    {
                        this.Tables.Add(new KORISNIKLevel1DataTable(dataSet.Tables["KORISNIKLevel1"]));
                    }
                    if (dataSet.Tables["KORISNIK"] != null)
                    {
                        this.Tables.Add(new KORISNIKDataTable(dataSet.Tables["KORISNIK"]));
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
            KORISNIKDataSet set = (KORISNIKDataSet) base.Clone();
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
            KORISNIKDataSet set = new KORISNIKDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "KORISNIKDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1007");
            this.ExtendedProperties.Add("DataSetName", "KORISNIKDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IKORISNIKDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "KORISNIK");
            this.ExtendedProperties.Add("ObjectDescription", "Korisnik aplikacije");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Common");
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
            this.DataSetName = "KORISNIKDataSet";
            this.Namespace = "http://www.tempuri.org/KORISNIK";
            this.tableKORISNIKLevel1 = new KORISNIKLevel1DataTable();
            this.Tables.Add(this.tableKORISNIKLevel1);
            this.tableKORISNIK = new KORISNIKDataTable();
            this.Tables.Add(this.tableKORISNIK);
            this.Relations.Add("KORISNIK_KORISNIKLevel1", new DataColumn[] { this.Tables["KORISNIK"].Columns["IDKORISNIK"] }, new DataColumn[] { this.Tables["KORISNIKLevel1"].Columns["IDKORISNIK"] });
            this.Relations["KORISNIK_KORISNIKLevel1"].Nested = true;
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
            this.tableKORISNIKLevel1 = (KORISNIKLevel1DataTable) this.Tables["KORISNIKLevel1"];
            this.tableKORISNIK = (KORISNIKDataTable) this.Tables["KORISNIK"];
            if (initTable)
            {
                if (this.tableKORISNIKLevel1 != null)
                {
                    this.tableKORISNIKLevel1.InitVars();
                }
                if (this.tableKORISNIK != null)
                {
                    this.tableKORISNIK.InitVars();
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
                if (dataSet.Tables["KORISNIKLevel1"] != null)
                {
                    this.Tables.Add(new KORISNIKLevel1DataTable(dataSet.Tables["KORISNIKLevel1"]));
                }
                if (dataSet.Tables["KORISNIK"] != null)
                {
                    this.Tables.Add(new KORISNIKDataTable(dataSet.Tables["KORISNIK"]));
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

        private bool ShouldSerializeKORISNIK()
        {
            return false;
        }

        private bool ShouldSerializeKORISNIKLevel1()
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
        public KORISNIKDataTable KORISNIK
        {
            get
            {
                return this.tableKORISNIK;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KORISNIKLevel1DataTable KORISNIKLevel1
        {
            get
            {
                return this.tableKORISNIKLevel1;
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
        public class KORISNIKDataTable : DataTable, IEnumerable
        {
            private DataColumn columnADRESAOVLASTENEOSOBE;
            private DataColumn columnANALITIKA;
            private DataColumn columnBROJCANAOZNAKAPU;
            private DataColumn columnEMAIL;
            private DataColumn columnEMAILPOSILJAOCA;
            private DataColumn columnIDKORISNIK;
            private DataColumn columnJMBGKORISNIK;
            private DataColumn columnKONTAKTFAX;
            private DataColumn columnKONTAKTOSOBA;
            private DataColumn columnKONTAKTTELEFON;
            private DataColumn columnKORISNIK1ADRESA;
            private DataColumn columnKORISNIK1HZZO;
            private DataColumn columnKORISNIK1MJESTO;
            private DataColumn columnKORISNIK1NAZIV;
            private DataColumn columnKORISNIK1NAZIVZANALJEPNICE;
            private DataColumn columnKORISNIKOIB;
            private DataColumn columnMBKORISNIK;
            private DataColumn columnMBKORISNIKJEDINICA;
            private DataColumn columnNADLEZNAPU;
            private DataColumn columnNAZIVPOSILJAOCA;
            private DataColumn columnOIBOVLASTENEOSOBE;
            private DataColumn columnPREZIMEIMEOVLASTENEOSOBE;
            private DataColumn columnRKP;
            private DataColumn columnSMTPSERVER;
            private DataColumn columnSTAZUKOEFICIJENTU;
            private DataColumn columnOBVEZNIKPDVA;
            private DataColumn columnJOPPDPodnositeljIzvjescaID;
            private DataColumn columnNeprofitni;

            //1.1.15
            private DataColumn columnStopaZaInvalide;
            private DataColumn columnBrojOsoba;
            private DataColumn columnPDVPoNaplacenom;
            private DataColumn columnPassword;
            private DataColumn columnPort;

            #region MBS.Complete
            private DataColumn columnPredporez;
            #endregion

            public event KORISNIKDataSet.KORISNIKRowChangeEventHandler KORISNIKRowChanged;

            public event KORISNIKDataSet.KORISNIKRowChangeEventHandler KORISNIKRowChanging;

            public event KORISNIKDataSet.KORISNIKRowChangeEventHandler KORISNIKRowDeleted;

            public event KORISNIKDataSet.KORISNIKRowChangeEventHandler KORISNIKRowDeleting;

            public KORISNIKDataTable()
            {
                this.TableName = "KORISNIK";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal KORISNIKDataTable(DataTable table) : base(table.TableName)
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

            protected KORISNIKDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddKORISNIKRow(KORISNIKDataSet.KORISNIKRow row)
            {
                this.Rows.Add(row);
            }

            public KORISNIKDataSet.KORISNIKRow AddKORISNIKRow(int iDKORISNIK, string kORISNIK1NAZIV, string kORISNIK1ADRESA, string kORISNIK1MJESTO, string kORISNIKOIB, string mBKORISNIK, string mBKORISNIKJEDINICA, 
                string jMBGKORISNIK, string kONTAKTOSOBA, string kONTAKTTELEFON, string kONTAKTFAX, string eMAIL, string nADLEZNAPU, int bROJCANAOZNAKAPU, bool sTAZUKOEFICIJENTU, int rKP, string pREZIMEIMEOVLASTENEOSOBE, 
                string aDRESAOVLASTENEOSOBE, string oIBOVLASTENEOSOBE, int aNALITIKA, string kORISNIK1HZZO, string kORISNIK1NAZIVZANALJEPNICE, string eMAILPOSILJAOCA, string nAZIVPOSILJAOCA, string sMTPSERVER, bool oBVEZNIKPDVA, bool Neprofitni, double StopaZaInvalide, double BrojOsoba, bool PDVPoNaplacenom, string EmailPassword, string EmailPort)
            {
                KORISNIKDataSet.KORISNIKRow row = (KORISNIKDataSet.KORISNIKRow) this.NewRow();
                row["IDKORISNIK"] = iDKORISNIK;
                row["KORISNIK1NAZIV"] = kORISNIK1NAZIV;
                row["KORISNIK1ADRESA"] = kORISNIK1ADRESA;
                row["KORISNIK1MJESTO"] = kORISNIK1MJESTO;
                row["KORISNIKOIB"] = kORISNIKOIB;
                row["MBKORISNIK"] = mBKORISNIK;
                row["MBKORISNIKJEDINICA"] = mBKORISNIKJEDINICA;
                row["JMBGKORISNIK"] = jMBGKORISNIK;
                row["KONTAKTOSOBA"] = kONTAKTOSOBA;
                row["KONTAKTTELEFON"] = kONTAKTTELEFON;
                row["KONTAKTFAX"] = kONTAKTFAX;
                row["EMAIL"] = eMAIL;
                row["NADLEZNAPU"] = nADLEZNAPU;
                row["BROJCANAOZNAKAPU"] = bROJCANAOZNAKAPU;
                row["STAZUKOEFICIJENTU"] = sTAZUKOEFICIJENTU;
                row["RKP"] = rKP;
                row["PREZIMEIMEOVLASTENEOSOBE"] = pREZIMEIMEOVLASTENEOSOBE;
                row["ADRESAOVLASTENEOSOBE"] = aDRESAOVLASTENEOSOBE;
                row["OIBOVLASTENEOSOBE"] = oIBOVLASTENEOSOBE;
                row["ANALITIKA"] = aNALITIKA;
                row["KORISNIK1HZZO"] = kORISNIK1HZZO;
                row["KORISNIK1NAZIVZANALJEPNICE"] = kORISNIK1NAZIVZANALJEPNICE;
                row["EMAILPOSILJAOCA"] = eMAILPOSILJAOCA;
                row["NAZIVPOSILJAOCA"] = nAZIVPOSILJAOCA;
                row["SMTPSERVER"] = sMTPSERVER;
                row["OBVEZNIKPDVA"] = oBVEZNIKPDVA;
                row["Neprofitni"] = Neprofitni;
                row["StopaZaInvalide"] = StopaZaInvalide;
                row["BrojOsoba"] = BrojOsoba;
                row["PDVPoNaplacenom"] = PDVPoNaplacenom;
                row["EmailPassword"] = EmailPassword;
                row["EmailPort"] = EmailPort;

                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                KORISNIKDataSet.KORISNIKDataTable table = (KORISNIKDataSet.KORISNIKDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public KORISNIKDataSet.KORISNIKRow FindByIDKORISNIK(int iDKORISNIK)
            {
                return (KORISNIKDataSet.KORISNIKRow) this.Rows.Find(new object[] { iDKORISNIK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(KORISNIKDataSet.KORISNIKRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                KORISNIKDataSet set = new KORISNIKDataSet();
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
                this.columnIDKORISNIK = new DataColumn("IDKORISNIK", typeof(int), "", MappingType.Element);
                this.columnIDKORISNIK.AllowDBNull = false;
                this.columnIDKORISNIK.Caption = "Šifra korisnika";
                this.columnIDKORISNIK.Unique = true;
                this.columnIDKORISNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKORISNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDKORISNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDKORISNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKORISNIK.ExtendedProperties.Add("Description", "Šifra korisnika");
                this.columnIDKORISNIK.ExtendedProperties.Add("Length", "5");
                this.columnIDKORISNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKORISNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKORISNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDKORISNIK");
                this.Columns.Add(this.columnIDKORISNIK);
                this.columnKORISNIK1NAZIV = new DataColumn("KORISNIK1NAZIV", typeof(string), "", MappingType.Element);
                this.columnKORISNIK1NAZIV.AllowDBNull = false;
                this.columnKORISNIK1NAZIV.Caption = "Naziv (korisnik)";
                this.columnKORISNIK1NAZIV.MaxLength = 50;
                this.columnKORISNIK1NAZIV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("IsKey", "false");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("Description", "Naziv (korisnik)");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("Length", "50");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("Decimals", "0");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("IsInReader", "true");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKORISNIK1NAZIV.ExtendedProperties.Add("Deklarit.InternalName", "KORISNIK1NAZIV");
                this.Columns.Add(this.columnKORISNIK1NAZIV);
                this.columnKORISNIK1ADRESA = new DataColumn("KORISNIK1ADRESA", typeof(string), "", MappingType.Element);
                this.columnKORISNIK1ADRESA.AllowDBNull = false;
                this.columnKORISNIK1ADRESA.Caption = "Ulica i broj (korisnik)";
                this.columnKORISNIK1ADRESA.MaxLength = 50;
                this.columnKORISNIK1ADRESA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("IsKey", "false");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("Description", "Ulica i broj (korisnik)");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("Length", "50");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("Decimals", "0");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("IsInReader", "true");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKORISNIK1ADRESA.ExtendedProperties.Add("Deklarit.InternalName", "KORISNIK1ADRESA");
                this.Columns.Add(this.columnKORISNIK1ADRESA);
                this.columnKORISNIK1MJESTO = new DataColumn("KORISNIK1MJESTO", typeof(string), "", MappingType.Element);
                this.columnKORISNIK1MJESTO.AllowDBNull = false;
                this.columnKORISNIK1MJESTO.Caption = "Mjesto (korisnik)";
                this.columnKORISNIK1MJESTO.MaxLength = 50;
                this.columnKORISNIK1MJESTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("IsKey", "false");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("Description", "Mjesto (korisnik)");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("Length", "50");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("Decimals", "0");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKORISNIK1MJESTO.ExtendedProperties.Add("Deklarit.InternalName", "KORISNIK1MJESTO");
                this.Columns.Add(this.columnKORISNIK1MJESTO);
                this.columnKORISNIKOIB = new DataColumn("KORISNIKOIB", typeof(string), "", MappingType.Element);
                this.columnKORISNIKOIB.AllowDBNull = false;
                this.columnKORISNIKOIB.Caption = "KORISNIKOIB";
                this.columnKORISNIKOIB.MaxLength = 11;
                this.columnKORISNIKOIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKORISNIKOIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKORISNIKOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKORISNIKOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKORISNIKOIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKORISNIKOIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKORISNIKOIB.ExtendedProperties.Add("IsKey", "false");
                this.columnKORISNIKOIB.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKORISNIKOIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKORISNIKOIB.ExtendedProperties.Add("Description", "Osobni identifikacijski broj");
                this.columnKORISNIKOIB.ExtendedProperties.Add("Length", "11");
                this.columnKORISNIKOIB.ExtendedProperties.Add("Decimals", "0");
                this.columnKORISNIKOIB.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKORISNIKOIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnKORISNIKOIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKORISNIKOIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKORISNIKOIB.ExtendedProperties.Add("Deklarit.InternalName", "KORISNIKOIB");
                this.Columns.Add(this.columnKORISNIKOIB);
                this.columnMBKORISNIK = new DataColumn("MBKORISNIK", typeof(string), "", MappingType.Element);
                this.columnMBKORISNIK.AllowDBNull = true;
                this.columnMBKORISNIK.Caption = "Matični broj korisnika";
                this.columnMBKORISNIK.MaxLength = 8;
                this.columnMBKORISNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMBKORISNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMBKORISNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMBKORISNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMBKORISNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMBKORISNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMBKORISNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnMBKORISNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMBKORISNIK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMBKORISNIK.ExtendedProperties.Add("Description", "Matični broj korisnika");
                this.columnMBKORISNIK.ExtendedProperties.Add("Length", "8");
                this.columnMBKORISNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnMBKORISNIK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMBKORISNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnMBKORISNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMBKORISNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMBKORISNIK.ExtendedProperties.Add("Deklarit.InternalName", "MBKORISNIK");
                this.Columns.Add(this.columnMBKORISNIK);
                this.columnMBKORISNIKJEDINICA = new DataColumn("MBKORISNIKJEDINICA", typeof(string), "", MappingType.Element);
                this.columnMBKORISNIKJEDINICA.AllowDBNull = true;
                this.columnMBKORISNIKJEDINICA.Caption = "Jedinica korisnika";
                this.columnMBKORISNIKJEDINICA.MaxLength = 4;
                this.columnMBKORISNIKJEDINICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("IsKey", "false");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("Description", "Jedinica korisnika");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("Length", "4");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("Decimals", "0");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMBKORISNIKJEDINICA.ExtendedProperties.Add("Deklarit.InternalName", "MBKORISNIKJEDINICA");
                this.Columns.Add(this.columnMBKORISNIKJEDINICA);
                this.columnJMBGKORISNIK = new DataColumn("JMBGKORISNIK", typeof(string), "", MappingType.Element);
                this.columnJMBGKORISNIK.AllowDBNull = true;
                this.columnJMBGKORISNIK.Caption = "JMBG korisnika";
                this.columnJMBGKORISNIK.MaxLength = 13;
                this.columnJMBGKORISNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnJMBGKORISNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("Description", "JMBG korisnika");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("Length", "13");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnJMBGKORISNIK.ExtendedProperties.Add("Deklarit.InternalName", "JMBGKORISNIK");
                this.Columns.Add(this.columnJMBGKORISNIK);
                this.columnKONTAKTOSOBA = new DataColumn("KONTAKTOSOBA", typeof(string), "", MappingType.Element);
                this.columnKONTAKTOSOBA.AllowDBNull = false;
                this.columnKONTAKTOSOBA.Caption = "Kontakt osoba";
                this.columnKONTAKTOSOBA.MaxLength = 50;
                this.columnKONTAKTOSOBA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("IsKey", "false");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("Description", "Kontakt osoba");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("Length", "50");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("Decimals", "0");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("IsInReader", "true");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKONTAKTOSOBA.ExtendedProperties.Add("Deklarit.InternalName", "KONTAKTOSOBA");
                this.Columns.Add(this.columnKONTAKTOSOBA);
                this.columnKONTAKTTELEFON = new DataColumn("KONTAKTTELEFON", typeof(string), "", MappingType.Element);
                this.columnKONTAKTTELEFON.AllowDBNull = false;
                this.columnKONTAKTTELEFON.Caption = "Kontakt telefon";
                this.columnKONTAKTTELEFON.MaxLength = 30;
                this.columnKONTAKTTELEFON.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("IsKey", "false");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("Description", "Kontakt telefon");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("Length", "30");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("Decimals", "0");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("IsInReader", "true");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKONTAKTTELEFON.ExtendedProperties.Add("Deklarit.InternalName", "KONTAKTTELEFON");
                this.Columns.Add(this.columnKONTAKTTELEFON);
                this.columnKONTAKTFAX = new DataColumn("KONTAKTFAX", typeof(string), "", MappingType.Element);
                this.columnKONTAKTFAX.AllowDBNull = false;
                this.columnKONTAKTFAX.Caption = "Kontakt fax";
                this.columnKONTAKTFAX.MaxLength = 30;
                this.columnKONTAKTFAX.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKONTAKTFAX.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKONTAKTFAX.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKONTAKTFAX.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKONTAKTFAX.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKONTAKTFAX.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKONTAKTFAX.ExtendedProperties.Add("IsKey", "false");
                this.columnKONTAKTFAX.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKONTAKTFAX.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKONTAKTFAX.ExtendedProperties.Add("Description", "Kontakt fax");
                this.columnKONTAKTFAX.ExtendedProperties.Add("Length", "30");
                this.columnKONTAKTFAX.ExtendedProperties.Add("Decimals", "0");
                this.columnKONTAKTFAX.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKONTAKTFAX.ExtendedProperties.Add("IsInReader", "true");
                this.columnKONTAKTFAX.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKONTAKTFAX.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKONTAKTFAX.ExtendedProperties.Add("Deklarit.InternalName", "KONTAKTFAX");
                this.Columns.Add(this.columnKONTAKTFAX);
                this.columnEMAIL = new DataColumn("EMAIL", typeof(string), "", MappingType.Element);
                this.columnEMAIL.AllowDBNull = false;
                this.columnEMAIL.Caption = "E-mail";
                this.columnEMAIL.MaxLength = 100;
                this.columnEMAIL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnEMAIL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnEMAIL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnEMAIL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnEMAIL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnEMAIL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnEMAIL.ExtendedProperties.Add("IsKey", "false");
                this.columnEMAIL.ExtendedProperties.Add("ReadOnly", "false");
                this.columnEMAIL.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnEMAIL.ExtendedProperties.Add("Description", "E-mail");
                this.columnEMAIL.ExtendedProperties.Add("Length", "100");
                this.columnEMAIL.ExtendedProperties.Add("Decimals", "0");
                this.columnEMAIL.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnEMAIL.ExtendedProperties.Add("RegularExpression", @"[a-zA-Z0-9]([a-zA-Z0-9_\-\.]*)@[a-zA-Z0-9]([a-zA-Z0-9_\-\.]*)(\.[a-zA-Z]{2,3}(\.[a-zA-Z]{2}){0,2})");
                this.columnEMAIL.ExtendedProperties.Add("IsInReader", "true");
                this.columnEMAIL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnEMAIL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnEMAIL.ExtendedProperties.Add("Deklarit.InternalName", "EMAIL");
                this.Columns.Add(this.columnEMAIL);
                this.columnNADLEZNAPU = new DataColumn("NADLEZNAPU", typeof(string), "", MappingType.Element);
                this.columnNADLEZNAPU.AllowDBNull = false;
                this.columnNADLEZNAPU.Caption = "Nadležna ispostava porezne uprave";
                this.columnNADLEZNAPU.MaxLength = 50;
                this.columnNADLEZNAPU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNADLEZNAPU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNADLEZNAPU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNADLEZNAPU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNADLEZNAPU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNADLEZNAPU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNADLEZNAPU.ExtendedProperties.Add("IsKey", "false");
                this.columnNADLEZNAPU.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNADLEZNAPU.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNADLEZNAPU.ExtendedProperties.Add("Description", "Nadležna ispostava porezne uprave");
                this.columnNADLEZNAPU.ExtendedProperties.Add("Length", "50");
                this.columnNADLEZNAPU.ExtendedProperties.Add("Decimals", "0");
                this.columnNADLEZNAPU.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNADLEZNAPU.ExtendedProperties.Add("IsInReader", "true");
                this.columnNADLEZNAPU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNADLEZNAPU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNADLEZNAPU.ExtendedProperties.Add("Deklarit.InternalName", "NADLEZNAPU");
                this.Columns.Add(this.columnNADLEZNAPU);
                this.columnBROJCANAOZNAKAPU = new DataColumn("BROJCANAOZNAKAPU", typeof(int), "", MappingType.Element);
                this.columnBROJCANAOZNAKAPU.AllowDBNull = false;
                this.columnBROJCANAOZNAKAPU.Caption = "BROJCANAOZNAKAPU";
                this.columnBROJCANAOZNAKAPU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("Description", "Brojčana oznaka ispostave porezne uprave");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("Length", "5");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJCANAOZNAKAPU.ExtendedProperties.Add("Deklarit.InternalName", "BROJCANAOZNAKAPU");
                this.Columns.Add(this.columnBROJCANAOZNAKAPU);
                this.columnSTAZUKOEFICIJENTU = new DataColumn("STAZUKOEFICIJENTU", typeof(bool), "", MappingType.Element);
                this.columnSTAZUKOEFICIJENTU.AllowDBNull = false;
                this.columnSTAZUKOEFICIJENTU.Caption = "Staž sadržan u koeficijentu";
                this.columnSTAZUKOEFICIJENTU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("IsKey", "false");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("Description", "Staž sadržan u koeficijentu");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("Length", "1");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("Decimals", "0");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTAZUKOEFICIJENTU.ExtendedProperties.Add("Deklarit.InternalName", "STAZUKOEFICIJENTU");
                this.Columns.Add(this.columnSTAZUKOEFICIJENTU);
                this.columnRKP = new DataColumn("RKP", typeof(int), "", MappingType.Element);
                this.columnRKP.AllowDBNull = true;
                this.columnRKP.Caption = "RKP";
                this.columnRKP.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRKP.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRKP.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRKP.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRKP.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRKP.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRKP.ExtendedProperties.Add("IsKey", "false");
                this.columnRKP.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRKP.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRKP.ExtendedProperties.Add("Description", "Šifra u registru korisnika DP");
                this.columnRKP.ExtendedProperties.Add("Length", "5");
                this.columnRKP.ExtendedProperties.Add("Decimals", "0");
                this.columnRKP.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRKP.ExtendedProperties.Add("IsInReader", "true");
                this.columnRKP.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRKP.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRKP.ExtendedProperties.Add("Deklarit.InternalName", "RKP");
                this.Columns.Add(this.columnRKP);
                this.columnPREZIMEIMEOVLASTENEOSOBE = new DataColumn("PREZIMEIMEOVLASTENEOSOBE", typeof(string), "", MappingType.Element);
                this.columnPREZIMEIMEOVLASTENEOSOBE.AllowDBNull = false;
                this.columnPREZIMEIMEOVLASTENEOSOBE.Caption = "PREZIMEIMEOVLASTENEOSOBE";
                this.columnPREZIMEIMEOVLASTENEOSOBE.MaxLength = 50;
                this.columnPREZIMEIMEOVLASTENEOSOBE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("IsKey", "false");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("Description", "Prezime i ime ovlaštene osobe");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("Length", "50");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIMEIMEOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.InternalName", "PREZIMEIMEOVLASTENEOSOBE");
                this.Columns.Add(this.columnPREZIMEIMEOVLASTENEOSOBE);
                this.columnADRESAOVLASTENEOSOBE = new DataColumn("ADRESAOVLASTENEOSOBE", typeof(string), "", MappingType.Element);
                this.columnADRESAOVLASTENEOSOBE.AllowDBNull = false;
                this.columnADRESAOVLASTENEOSOBE.Caption = "ADRESAOVLASTENEOSOBE";
                this.columnADRESAOVLASTENEOSOBE.MaxLength = 50;
                this.columnADRESAOVLASTENEOSOBE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("IsKey", "false");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("Description", "Adresa ovlaštene osobe");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("Length", "50");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("Decimals", "0");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("IsInReader", "true");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnADRESAOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.InternalName", "ADRESAOVLASTENEOSOBE");
                this.Columns.Add(this.columnADRESAOVLASTENEOSOBE);
                this.columnOIBOVLASTENEOSOBE = new DataColumn("OIBOVLASTENEOSOBE", typeof(string), "", MappingType.Element);
                this.columnOIBOVLASTENEOSOBE.AllowDBNull = false;
                this.columnOIBOVLASTENEOSOBE.Caption = "OIBOVLASTENEOSOBE";
                this.columnOIBOVLASTENEOSOBE.MaxLength = 11;
                this.columnOIBOVLASTENEOSOBE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("IsKey", "false");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("Description", "OIB ovlaštene osobe");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("Length", "11");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("Decimals", "0");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOIBOVLASTENEOSOBE.ExtendedProperties.Add("Deklarit.InternalName", "OIBOVLASTENEOSOBE");
                this.Columns.Add(this.columnOIBOVLASTENEOSOBE);
                this.columnANALITIKA = new DataColumn("ANALITIKA", typeof(int), "", MappingType.Element);
                this.columnANALITIKA.AllowDBNull = false;
                this.columnANALITIKA.Caption = "ANALITIKA";
                this.columnANALITIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnANALITIKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnANALITIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnANALITIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnANALITIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnANALITIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnANALITIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnANALITIKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnANALITIKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnANALITIKA.ExtendedProperties.Add("Description", "Analitika u računskom planu");
                this.columnANALITIKA.ExtendedProperties.Add("Length", "5");
                this.columnANALITIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnANALITIKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnANALITIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnANALITIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnANALITIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnANALITIKA.ExtendedProperties.Add("Deklarit.InternalName", "ANALITIKA");
                this.Columns.Add(this.columnANALITIKA);
                this.columnKORISNIK1HZZO = new DataColumn("KORISNIK1HZZO", typeof(string), "", MappingType.Element);
                this.columnKORISNIK1HZZO.AllowDBNull = false;
                this.columnKORISNIK1HZZO.Caption = "KORISNIK1 HZZO";
                this.columnKORISNIK1HZZO.MaxLength = 11;
                this.columnKORISNIK1HZZO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("IsKey", "false");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("Description", "Broj obveze (HZZO) za R1");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("Length", "11");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("Decimals", "0");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("IsInReader", "true");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKORISNIK1HZZO.ExtendedProperties.Add("Deklarit.InternalName", "KORISNIK1HZZO");
                this.Columns.Add(this.columnKORISNIK1HZZO);
                this.columnKORISNIK1NAZIVZANALJEPNICE = new DataColumn("KORISNIK1NAZIVZANALJEPNICE", typeof(string), "", MappingType.Element);
                this.columnKORISNIK1NAZIVZANALJEPNICE.AllowDBNull = false;
                this.columnKORISNIK1NAZIVZANALJEPNICE.Caption = "KORISNIK1 NAZIVZANALJEPNICE";
                this.columnKORISNIK1NAZIVZANALJEPNICE.MaxLength = 0x1a;
                this.columnKORISNIK1NAZIVZANALJEPNICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("IsKey", "false");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("Description", "Naziv ustanove na BARCODE naljepnicama");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("Length", "26");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("Decimals", "0");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKORISNIK1NAZIVZANALJEPNICE.ExtendedProperties.Add("Deklarit.InternalName", "KORISNIK1NAZIVZANALJEPNICE");
                this.Columns.Add(this.columnKORISNIK1NAZIVZANALJEPNICE);
                this.columnEMAILPOSILJAOCA = new DataColumn("EMAILPOSILJAOCA", typeof(string), "", MappingType.Element);
                this.columnEMAILPOSILJAOCA.AllowDBNull = false;
                this.columnEMAILPOSILJAOCA.Caption = "EMAILPOSILJAOCA";
                this.columnEMAILPOSILJAOCA.MaxLength = 150;
                this.columnEMAILPOSILJAOCA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("IsKey", "false");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("Description", "Mail pošiljaoca (za slanje računa emailom)");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("Length", "150");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("Decimals", "0");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("IsInReader", "true");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnEMAILPOSILJAOCA.ExtendedProperties.Add("Deklarit.InternalName", "EMAILPOSILJAOCA");
                this.Columns.Add(this.columnEMAILPOSILJAOCA);
                this.columnNAZIVPOSILJAOCA = new DataColumn("NAZIVPOSILJAOCA", typeof(string), "", MappingType.Element);
                this.columnNAZIVPOSILJAOCA.AllowDBNull = false;
                this.columnNAZIVPOSILJAOCA.Caption = "NAZIVPOSILJAOCA";
                this.columnNAZIVPOSILJAOCA.MaxLength = 150;
                this.columnNAZIVPOSILJAOCA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("Description", "Naziv pošiljaoca (za slanje računa emailom)");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("Length", "150");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPOSILJAOCA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPOSILJAOCA");
                this.Columns.Add(this.columnNAZIVPOSILJAOCA);
                this.columnSMTPSERVER = new DataColumn("SMTPSERVER", typeof(string), "", MappingType.Element);
                this.columnSMTPSERVER.AllowDBNull = false;
                this.columnSMTPSERVER.Caption = "SMTPSERVER";
                this.columnSMTPSERVER.MaxLength = 150;
                this.columnSMTPSERVER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSMTPSERVER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSMTPSERVER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSMTPSERVER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSMTPSERVER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSMTPSERVER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSMTPSERVER.ExtendedProperties.Add("IsKey", "false");
                this.columnSMTPSERVER.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSMTPSERVER.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSMTPSERVER.ExtendedProperties.Add("Description", "Server odlazne email pošte");
                this.columnSMTPSERVER.ExtendedProperties.Add("Length", "150");
                this.columnSMTPSERVER.ExtendedProperties.Add("Decimals", "0");
                this.columnSMTPSERVER.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSMTPSERVER.ExtendedProperties.Add("IsInReader", "true");
                this.columnSMTPSERVER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSMTPSERVER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSMTPSERVER.ExtendedProperties.Add("Deklarit.InternalName", "SMTPSERVER");
                this.Columns.Add(this.columnSMTPSERVER);

                this.columnJOPPDPodnositeljIzvjescaID = new DataColumn("JOPPDPodnositeljIzvjescaID", typeof(int), "", MappingType.Element);
                this.columnJOPPDPodnositeljIzvjescaID.AllowDBNull = true;
                this.columnJOPPDPodnositeljIzvjescaID.Caption = "JOPPDPodnositeljIzvjescaID";
                this.columnJOPPDPodnositeljIzvjescaID.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("IsKey", "false");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("ReadOnly", "false");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("DeklaritType", "int");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("Description", "JOPPDPodnositeljIzvjescaID");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("Length", "8");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("Decimals", "0");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("IsInReader", "true");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnJOPPDPodnositeljIzvjescaID.ExtendedProperties.Add("Deklarit.InternalName", "JOPPDPodnositeljIzvjescaID");
                this.Columns.Add(this.columnJOPPDPodnositeljIzvjescaID);

                this.columnOBVEZNIKPDVA = new DataColumn("OBVEZNIKPDVA", typeof(bool), "", MappingType.Element);
                this.columnOBVEZNIKPDVA.AllowDBNull = false;
                this.columnOBVEZNIKPDVA.Caption = "Obveznik PDV-a";
                this.columnOBVEZNIKPDVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("IsKey", "false");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("Description", "Obveznik PDV-a");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("Length", "1");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("Decimals", "0");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBVEZNIKPDVA.ExtendedProperties.Add("Deklarit.InternalName", "OBVEZNIKPDVA");
                this.Columns.Add(this.columnOBVEZNIKPDVA);

                this.columnNeprofitni = new DataColumn("Neprofitni", typeof(bool), "", MappingType.Element);
                this.columnNeprofitni.AllowDBNull = true;
                this.columnNeprofitni.Caption = "Neprofitni";
                this.columnNeprofitni.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNeprofitni.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNeprofitni.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNeprofitni.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNeprofitni.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNeprofitni.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNeprofitni.ExtendedProperties.Add("IsKey", "false");
                this.columnNeprofitni.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNeprofitni.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnNeprofitni.ExtendedProperties.Add("Description", "Neprofitni");
                this.columnNeprofitni.ExtendedProperties.Add("Length", "1");
                this.columnNeprofitni.ExtendedProperties.Add("Decimals", "0");
                this.columnNeprofitni.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNeprofitni.ExtendedProperties.Add("IsInReader", "true");
                this.columnNeprofitni.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNeprofitni.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNeprofitni.ExtendedProperties.Add("Deklarit.InternalName", "Neprofitni");
                this.Columns.Add(this.columnNeprofitni);

                #region MBS.Complete
                this.columnPredporez = new DataColumn("PredPorez", typeof(double), "", MappingType.Element);
                this.columnPredporez.AllowDBNull = true;
                this.columnPredporez.Caption = "PredPorez";
                this.columnPredporez.Unique = false;
                this.columnPredporez.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPredporez.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPredporez.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPredporez.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPredporez.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPredporez.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPredporez.ExtendedProperties.Add("IsKey", "true");
                this.columnPredporez.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPredporez.ExtendedProperties.Add("DeklaritType", "double");
                this.columnPredporez.ExtendedProperties.Add("Description", "PredPorez");
                this.columnPredporez.ExtendedProperties.Add("Length", "5");
                this.columnPredporez.ExtendedProperties.Add("Decimals", "2");
                this.columnPredporez.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPredporez.ExtendedProperties.Add("IsInReader", "true");
                this.columnPredporez.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPredporez.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPredporez.ExtendedProperties.Add("Deklarit.InternalName", "PredPorez");
                this.Columns.Add(this.columnPredporez);
                #endregion

                //1.1.15
                this.columnStopaZaInvalide = new DataColumn("StopaZaInvalide", typeof(double), "", MappingType.Element);
                this.columnStopaZaInvalide.AllowDBNull = true;
                this.columnStopaZaInvalide.Caption = "Stopa za invalide";
                this.columnStopaZaInvalide.Unique = false;
                this.columnStopaZaInvalide.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnStopaZaInvalide.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnStopaZaInvalide.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnStopaZaInvalide.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnStopaZaInvalide.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnStopaZaInvalide.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnStopaZaInvalide.ExtendedProperties.Add("IsKey", "true");
                this.columnStopaZaInvalide.ExtendedProperties.Add("ReadOnly", "false");
                this.columnStopaZaInvalide.ExtendedProperties.Add("DeklaritType", "double");
                this.columnStopaZaInvalide.ExtendedProperties.Add("Description", "Stopa za invalide");
                this.columnStopaZaInvalide.ExtendedProperties.Add("Length", "10");
                this.columnStopaZaInvalide.ExtendedProperties.Add("Decimals", "0");
                this.columnStopaZaInvalide.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnStopaZaInvalide.ExtendedProperties.Add("IsInReader", "true");
                this.columnStopaZaInvalide.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnStopaZaInvalide.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnStopaZaInvalide.ExtendedProperties.Add("Deklarit.InternalName", "StopaZaInvalide");
                this.Columns.Add(this.columnStopaZaInvalide);
                this.columnBrojOsoba = new DataColumn("BrojOsoba", typeof(double), "", MappingType.Element);
                this.columnBrojOsoba.AllowDBNull = true;
                this.columnBrojOsoba.Caption = "Broj osoba";
                this.columnBrojOsoba.Unique = false;
                this.columnBrojOsoba.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBrojOsoba.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBrojOsoba.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBrojOsoba.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBrojOsoba.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBrojOsoba.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBrojOsoba.ExtendedProperties.Add("IsKey", "true");
                this.columnBrojOsoba.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBrojOsoba.ExtendedProperties.Add("DeklaritType", "double");
                this.columnBrojOsoba.ExtendedProperties.Add("Description", "Broj osoba");
                this.columnBrojOsoba.ExtendedProperties.Add("Length", "10");
                this.columnBrojOsoba.ExtendedProperties.Add("Decimals", "0");
                this.columnBrojOsoba.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBrojOsoba.ExtendedProperties.Add("IsInReader", "true");
                this.columnBrojOsoba.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBrojOsoba.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBrojOsoba.ExtendedProperties.Add("Deklarit.InternalName", "BrojOsoba");
                this.Columns.Add(this.columnBrojOsoba);

                this.columnPDVPoNaplacenom = new DataColumn("PDVPoNaplacenom", typeof(bool), "", MappingType.Element);
                this.columnPDVPoNaplacenom.AllowDBNull = true;
                this.columnPDVPoNaplacenom.Caption = "PDV Po Naplaćenom računu";
                this.columnPDVPoNaplacenom.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("IsKey", "false");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("Description", "PDVPoNaplacenom");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("Length", "1");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("Decimals", "0");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDVPoNaplacenom.ExtendedProperties.Add("Deklarit.InternalName", "PDVPoNaplacenom");
                this.Columns.Add(this.columnPDVPoNaplacenom);

                this.columnPassword = new DataColumn("EmailPassword", typeof(string), "", MappingType.Element);
                this.columnPassword.AllowDBNull = true;
                this.columnPassword.Caption = "Email Password";
                this.columnPassword.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPassword.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPassword.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPassword.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPassword.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPassword.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPassword.ExtendedProperties.Add("IsKey", "false");
                this.columnPassword.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPassword.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPassword.ExtendedProperties.Add("Description", "Email Password");
                this.columnPassword.ExtendedProperties.Add("Length", "150");
                this.columnPassword.ExtendedProperties.Add("Decimals", "0");
                this.columnPassword.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPassword.ExtendedProperties.Add("IsInReader", "true");
                this.columnPassword.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPassword.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPassword.ExtendedProperties.Add("Deklarit.InternalName", "EmailPassword");
                this.Columns.Add(this.columnPassword);

                this.columnPort = new DataColumn("EmailPort", typeof(string), "", MappingType.Element);
                this.columnPort.AllowDBNull = true;
                this.columnPort.Caption = "Email Port";
                this.columnPort.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPort.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPort.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPort.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPort.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPort.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPort.ExtendedProperties.Add("IsKey", "false");
                this.columnPort.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPort.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPort.ExtendedProperties.Add("Description", "Email Port");
                this.columnPort.ExtendedProperties.Add("Length", "150");
                this.columnPort.ExtendedProperties.Add("Decimals", "0");
                this.columnPort.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPort.ExtendedProperties.Add("IsInReader", "true");
                this.columnPort.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPort.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPort.ExtendedProperties.Add("Deklarit.InternalName", "EmailPort");
                this.Columns.Add(this.columnPort);


                this.PrimaryKey = new DataColumn[] { this.columnIDKORISNIK };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "KORISNIK");
                this.ExtendedProperties.Add("Description", "Korisnik aplikacije");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDKORISNIK = this.Columns["IDKORISNIK"];
                this.columnKORISNIK1NAZIV = this.Columns["KORISNIK1NAZIV"];
                this.columnKORISNIK1ADRESA = this.Columns["KORISNIK1ADRESA"];
                this.columnKORISNIK1MJESTO = this.Columns["KORISNIK1MJESTO"];
                this.columnKORISNIKOIB = this.Columns["KORISNIKOIB"];
                this.columnMBKORISNIK = this.Columns["MBKORISNIK"];
                this.columnMBKORISNIKJEDINICA = this.Columns["MBKORISNIKJEDINICA"];
                this.columnJMBGKORISNIK = this.Columns["JMBGKORISNIK"];
                this.columnKONTAKTOSOBA = this.Columns["KONTAKTOSOBA"];
                this.columnKONTAKTTELEFON = this.Columns["KONTAKTTELEFON"];
                this.columnKONTAKTFAX = this.Columns["KONTAKTFAX"];
                this.columnEMAIL = this.Columns["EMAIL"];
                this.columnNADLEZNAPU = this.Columns["NADLEZNAPU"];
                this.columnBROJCANAOZNAKAPU = this.Columns["BROJCANAOZNAKAPU"];
                this.columnSTAZUKOEFICIJENTU = this.Columns["STAZUKOEFICIJENTU"];
                this.columnRKP = this.Columns["RKP"];
                this.columnPREZIMEIMEOVLASTENEOSOBE = this.Columns["PREZIMEIMEOVLASTENEOSOBE"];
                this.columnADRESAOVLASTENEOSOBE = this.Columns["ADRESAOVLASTENEOSOBE"];
                this.columnOIBOVLASTENEOSOBE = this.Columns["OIBOVLASTENEOSOBE"];
                this.columnANALITIKA = this.Columns["ANALITIKA"];
                this.columnKORISNIK1HZZO = this.Columns["KORISNIK1HZZO"];
                this.columnKORISNIK1NAZIVZANALJEPNICE = this.Columns["KORISNIK1NAZIVZANALJEPNICE"];
                this.columnEMAILPOSILJAOCA = this.Columns["EMAILPOSILJAOCA"];
                this.columnNAZIVPOSILJAOCA = this.Columns["NAZIVPOSILJAOCA"];
                this.columnSMTPSERVER = this.Columns["SMTPSERVER"];
                this.columnOBVEZNIKPDVA = this.Columns["OBVEZNIKPDVA"];
                this.columnNeprofitni = this.Columns["Neprofitni"];
                
                //1.1.15
                this.columnStopaZaInvalide = this.Columns["StopaZaInvalide"];
                this.columnBrojOsoba = this.Columns["BrojOsoba"];
                this.columnPDVPoNaplacenom = this.Columns["PDVPoNaplacenom"];
                this.columnPassword = this.Columns["EmailPassword"];
                this.columnPort = this.Columns["EmailPort"];

                #region MBS.Complete
                this.columnPredporez = this.Columns["PredPorez"];
                #endregion

            }

            public KORISNIKDataSet.KORISNIKRow NewKORISNIKRow()
            {
                return (KORISNIKDataSet.KORISNIKRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new KORISNIKDataSet.KORISNIKRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.KORISNIKRowChanged != null)
                {
                    KORISNIKDataSet.KORISNIKRowChangeEventHandler kORISNIKRowChangedEvent = this.KORISNIKRowChanged;
                    if (kORISNIKRowChangedEvent != null)
                    {
                        kORISNIKRowChangedEvent(this, new KORISNIKDataSet.KORISNIKRowChangeEvent((KORISNIKDataSet.KORISNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.KORISNIKRowChanging != null)
                {
                    KORISNIKDataSet.KORISNIKRowChangeEventHandler kORISNIKRowChangingEvent = this.KORISNIKRowChanging;
                    if (kORISNIKRowChangingEvent != null)
                    {
                        kORISNIKRowChangingEvent(this, new KORISNIKDataSet.KORISNIKRowChangeEvent((KORISNIKDataSet.KORISNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.KORISNIKRowDeleted != null)
                {
                    KORISNIKDataSet.KORISNIKRowChangeEventHandler kORISNIKRowDeletedEvent = this.KORISNIKRowDeleted;
                    if (kORISNIKRowDeletedEvent != null)
                    {
                        kORISNIKRowDeletedEvent(this, new KORISNIKDataSet.KORISNIKRowChangeEvent((KORISNIKDataSet.KORISNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.KORISNIKRowDeleting != null)
                {
                    KORISNIKDataSet.KORISNIKRowChangeEventHandler kORISNIKRowDeletingEvent = this.KORISNIKRowDeleting;
                    if (kORISNIKRowDeletingEvent != null)
                    {
                        kORISNIKRowDeletingEvent(this, new KORISNIKDataSet.KORISNIKRowChangeEvent((KORISNIKDataSet.KORISNIKRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveKORISNIKRow(KORISNIKDataSet.KORISNIKRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn ADRESAOVLASTENEOSOBEColumn
            {
                get
                {
                    return this.columnADRESAOVLASTENEOSOBE;
                }
            }

            public DataColumn ANALITIKAColumn
            {
                get
                {
                    return this.columnANALITIKA;
                }
            }

            public DataColumn BROJCANAOZNAKAPUColumn
            {
                get
                {
                    return this.columnBROJCANAOZNAKAPU;
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

            public DataColumn EMAILColumn
            {
                get
                {
                    return this.columnEMAIL;
                }
            }

            public DataColumn EMAILPOSILJAOCAColumn
            {
                get
                {
                    return this.columnEMAILPOSILJAOCA;
                }
            }

            public DataColumn IDKORISNIKColumn
            {
                get
                {
                    return this.columnIDKORISNIK;
                }
            }

            public KORISNIKDataSet.KORISNIKRow this[int index]
            {
                get
                {
                    return (KORISNIKDataSet.KORISNIKRow) this.Rows[index];
                }
            }

            public DataColumn JMBGKORISNIKColumn
            {
                get
                {
                    return this.columnJMBGKORISNIK;
                }
            }

            public DataColumn KONTAKTFAXColumn
            {
                get
                {
                    return this.columnKONTAKTFAX;
                }
            }

            public DataColumn KONTAKTOSOBAColumn
            {
                get
                {
                    return this.columnKONTAKTOSOBA;
                }
            }

            public DataColumn KONTAKTTELEFONColumn
            {
                get
                {
                    return this.columnKONTAKTTELEFON;
                }
            }

            public DataColumn KORISNIK1ADRESAColumn
            {
                get
                {
                    return this.columnKORISNIK1ADRESA;
                }
            }

            public DataColumn KORISNIK1HZZOColumn
            {
                get
                {
                    return this.columnKORISNIK1HZZO;
                }
            }

            public DataColumn KORISNIK1MJESTOColumn
            {
                get
                {
                    return this.columnKORISNIK1MJESTO;
                }
            }

            public DataColumn KORISNIK1NAZIVColumn
            {
                get
                {
                    return this.columnKORISNIK1NAZIV;
                }
            }

            public DataColumn KORISNIK1NAZIVZANALJEPNICEColumn
            {
                get
                {
                    return this.columnKORISNIK1NAZIVZANALJEPNICE;
                }
            }

            public DataColumn KORISNIKOIBColumn
            {
                get
                {
                    return this.columnKORISNIKOIB;
                }
            }

            public DataColumn MBKORISNIKColumn
            {
                get
                {
                    return this.columnMBKORISNIK;
                }
            }

            public DataColumn MBKORISNIKJEDINICAColumn
            {
                get
                {
                    return this.columnMBKORISNIKJEDINICA;
                }
            }

            public DataColumn NADLEZNAPUColumn
            {
                get
                {
                    return this.columnNADLEZNAPU;
                }
            }

            public DataColumn NAZIVPOSILJAOCAColumn
            {
                get
                {
                    return this.columnNAZIVPOSILJAOCA;
                }
            }

            public DataColumn OIBOVLASTENEOSOBEColumn
            {
                get
                {
                    return this.columnOIBOVLASTENEOSOBE;
                }
            }

            public DataColumn PREZIMEIMEOVLASTENEOSOBEColumn
            {
                get
                {
                    return this.columnPREZIMEIMEOVLASTENEOSOBE;
                }
            }

            public DataColumn RKPColumn
            {
                get
                {
                    return this.columnRKP;
                }
            }

            public DataColumn SMTPSERVERColumn
            {
                get
                {
                    return this.columnSMTPSERVER;
                }
            }

            public DataColumn STAZUKOEFICIJENTUColumn
            {
                get
                {
                    return this.columnSTAZUKOEFICIJENTU;
                }
            }

            public DataColumn OBVEZNIKPDVAColumn
            {
                get
                {
                    return this.columnOBVEZNIKPDVA;
                }
            }

            public DataColumn JOPPDPodnositeljIzvjescaIDColumn
            {
                get
                {
                    return this.columnJOPPDPodnositeljIzvjescaID;
                }
            }

            public DataColumn NeprofitniColumn
            {
                get
                {
                    return this.columnNeprofitni;
                }
            }

            //1.1.15
            public DataColumn StopaZaInvalideColumn
            {
                get
                {
                    return this.columnStopaZaInvalide;
                }
            }

            #region MBS.Coomplete
            public DataColumn PredPorezColumn
            {
                get
                {
                    return this.columnPredporez;
                }
            }
            #endregion

            public DataColumn BrojOsobaColumn
            {
                get
                {
                    return this.columnBrojOsoba;
                }
            }
            public DataColumn PDVPoNaplacenomColumn
            {
                get
                {
                    return this.columnPDVPoNaplacenom;
                }
            }

            public DataColumn EmailPasswordColumn
            {
                get
                {
                    return this.columnPassword;
                }
            }

            public DataColumn EmailPortColumn
            {
                get
                {
                    return this.columnPort;
                }
            }
        }

        [Serializable]
        public class KORISNIKLevel1DataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDKORISNIK;
            private DataColumn columnIDZIRO;
            private DataColumn columnMJESTOZIRO;
            private DataColumn columnNAZIVIZVORA;
            private DataColumn columnNAZIVZIRO;
            private DataColumn columnPOREZIPRIREZZAJEDNICKI;
            private DataColumn columnPOZIVIZADUZENJA;
            private DataColumn columnSIFRAIZVORA;
            private DataColumn columnULICAZIRO;
            private DataColumn columnVBDIKORISNIK;
            private DataColumn columnZIROKORISNIK;

            public event KORISNIKDataSet.KORISNIKLevel1RowChangeEventHandler KORISNIKLevel1RowChanged;

            public event KORISNIKDataSet.KORISNIKLevel1RowChangeEventHandler KORISNIKLevel1RowChanging;

            public event KORISNIKDataSet.KORISNIKLevel1RowChangeEventHandler KORISNIKLevel1RowDeleted;

            public event KORISNIKDataSet.KORISNIKLevel1RowChangeEventHandler KORISNIKLevel1RowDeleting;

            public KORISNIKLevel1DataTable()
            {
                this.TableName = "KORISNIKLevel1";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal KORISNIKLevel1DataTable(DataTable table) : base(table.TableName)
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

            protected KORISNIKLevel1DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddKORISNIKLevel1Row(KORISNIKDataSet.KORISNIKLevel1Row row)
            {
                this.Rows.Add(row);
            }

            public KORISNIKDataSet.KORISNIKLevel1Row AddKORISNIKLevel1Row(int iDKORISNIK, int iDZIRO, string nAZIVZIRO, string uLICAZIRO, string mJESTOZIRO, string vBDIKORISNIK, string zIROKORISNIK, string sIFRAIZVORA, bool pOREZIPRIREZZAJEDNICKI, bool pOZIVIZADUZENJA)
            {
                KORISNIKDataSet.KORISNIKLevel1Row row = (KORISNIKDataSet.KORISNIKLevel1Row) this.NewRow();
                row["IDKORISNIK"] = iDKORISNIK;
                row["IDZIRO"] = iDZIRO;
                row["NAZIVZIRO"] = nAZIVZIRO;
                row["ULICAZIRO"] = uLICAZIRO;
                row["MJESTOZIRO"] = mJESTOZIRO;
                row["VBDIKORISNIK"] = vBDIKORISNIK;
                row["ZIROKORISNIK"] = zIROKORISNIK;
                row["SIFRAIZVORA"] = sIFRAIZVORA;
                row["POREZIPRIREZZAJEDNICKI"] = pOREZIPRIREZZAJEDNICKI;
                row["POZIVIZADUZENJA"] = pOZIVIZADUZENJA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                KORISNIKDataSet.KORISNIKLevel1DataTable table = (KORISNIKDataSet.KORISNIKLevel1DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public KORISNIKDataSet.KORISNIKLevel1Row FindByIDKORISNIKIDZIRO(int iDKORISNIK, int iDZIRO)
            {
                return (KORISNIKDataSet.KORISNIKLevel1Row) this.Rows.Find(new object[] { iDKORISNIK, iDZIRO });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(KORISNIKDataSet.KORISNIKLevel1Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                KORISNIKDataSet set = new KORISNIKDataSet();
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
                this.columnIDKORISNIK = new DataColumn("IDKORISNIK", typeof(int), "", MappingType.Element);
                this.columnIDKORISNIK.AllowDBNull = false;
                this.columnIDKORISNIK.Caption = "Šifra korisnika";
                this.columnIDKORISNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKORISNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDKORISNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDKORISNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKORISNIK.ExtendedProperties.Add("Description", "Šifra korisnika");
                this.columnIDKORISNIK.ExtendedProperties.Add("Length", "5");
                this.columnIDKORISNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKORISNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKORISNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKORISNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDKORISNIK");
                this.Columns.Add(this.columnIDKORISNIK);
                this.columnIDZIRO = new DataColumn("IDZIRO", typeof(int), "", MappingType.Element);
                this.columnIDZIRO.AllowDBNull = false;
                this.columnIDZIRO.Caption = "IDZIRO";
                this.columnIDZIRO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDZIRO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDZIRO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDZIRO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDZIRO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDZIRO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDZIRO.ExtendedProperties.Add("IsKey", "true");
                this.columnIDZIRO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDZIRO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDZIRO.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDZIRO.ExtendedProperties.Add("Length", "5");
                this.columnIDZIRO.ExtendedProperties.Add("Decimals", "0");
                this.columnIDZIRO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDZIRO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDZIRO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDZIRO.ExtendedProperties.Add("Deklarit.InternalName", "IDZIRO");
                this.Columns.Add(this.columnIDZIRO);
                this.columnNAZIVZIRO = new DataColumn("NAZIVZIRO", typeof(string), "", MappingType.Element);
                this.columnNAZIVZIRO.AllowDBNull = false;
                this.columnNAZIVZIRO.Caption = "NAZIVZIRO";
                this.columnNAZIVZIRO.MaxLength = 20;
                this.columnNAZIVZIRO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVZIRO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVZIRO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVZIRO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVZIRO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVZIRO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVZIRO.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVZIRO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVZIRO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVZIRO.ExtendedProperties.Add("Description", "Platitelj (1) na virmanu");
                this.columnNAZIVZIRO.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVZIRO.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVZIRO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVZIRO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVZIRO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVZIRO.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVZIRO");
                this.Columns.Add(this.columnNAZIVZIRO);
                this.columnULICAZIRO = new DataColumn("ULICAZIRO", typeof(string), "", MappingType.Element);
                this.columnULICAZIRO.AllowDBNull = false;
                this.columnULICAZIRO.Caption = "ULICAZIRO";
                this.columnULICAZIRO.MaxLength = 20;
                this.columnULICAZIRO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnULICAZIRO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnULICAZIRO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnULICAZIRO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnULICAZIRO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnULICAZIRO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnULICAZIRO.ExtendedProperties.Add("IsKey", "false");
                this.columnULICAZIRO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnULICAZIRO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnULICAZIRO.ExtendedProperties.Add("Description", "Platitelj (2) na virmanu");
                this.columnULICAZIRO.ExtendedProperties.Add("Length", "20");
                this.columnULICAZIRO.ExtendedProperties.Add("Decimals", "0");
                this.columnULICAZIRO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnULICAZIRO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnULICAZIRO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnULICAZIRO.ExtendedProperties.Add("Deklarit.InternalName", "ULICAZIRO");
                this.Columns.Add(this.columnULICAZIRO);
                this.columnMJESTOZIRO = new DataColumn("MJESTOZIRO", typeof(string), "", MappingType.Element);
                this.columnMJESTOZIRO.AllowDBNull = false;
                this.columnMJESTOZIRO.Caption = "MJESTOZIRO";
                this.columnMJESTOZIRO.MaxLength = 20;
                this.columnMJESTOZIRO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESTOZIRO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESTOZIRO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESTOZIRO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESTOZIRO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESTOZIRO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESTOZIRO.ExtendedProperties.Add("IsKey", "false");
                this.columnMJESTOZIRO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMJESTOZIRO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMJESTOZIRO.ExtendedProperties.Add("Description", "Platitelj (3) na virmanu");
                this.columnMJESTOZIRO.ExtendedProperties.Add("Length", "20");
                this.columnMJESTOZIRO.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESTOZIRO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMJESTOZIRO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESTOZIRO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESTOZIRO.ExtendedProperties.Add("Deklarit.InternalName", "MJESTOZIRO");
                this.Columns.Add(this.columnMJESTOZIRO);
                this.columnVBDIKORISNIK = new DataColumn("VBDIKORISNIK", typeof(string), "", MappingType.Element);
                this.columnVBDIKORISNIK.AllowDBNull = false;
                this.columnVBDIKORISNIK.Caption = "VBDIKORISNIK";
                this.columnVBDIKORISNIK.MaxLength = 7;
                this.columnVBDIKORISNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIKORISNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("Description", "VBDI Žrn-a");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("Length", "7");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIKORISNIK.ExtendedProperties.Add("Deklarit.InternalName", "VBDIKORISNIK");
                this.Columns.Add(this.columnVBDIKORISNIK);
                this.columnZIROKORISNIK = new DataColumn("ZIROKORISNIK", typeof(string), "", MappingType.Element);
                this.columnZIROKORISNIK.AllowDBNull = false;
                this.columnZIROKORISNIK.Caption = "ZIROKORISNIK";
                this.columnZIROKORISNIK.MaxLength = 10;
                this.columnZIROKORISNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZIROKORISNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZIROKORISNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZIROKORISNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZIROKORISNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZIROKORISNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZIROKORISNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnZIROKORISNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZIROKORISNIK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZIROKORISNIK.ExtendedProperties.Add("Description", "Žrn");
                this.columnZIROKORISNIK.ExtendedProperties.Add("Length", "10");
                this.columnZIROKORISNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnZIROKORISNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZIROKORISNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZIROKORISNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZIROKORISNIK.ExtendedProperties.Add("Deklarit.InternalName", "ZIROKORISNIK");
                this.Columns.Add(this.columnZIROKORISNIK);
                this.columnSIFRAIZVORA = new DataColumn("SIFRAIZVORA", typeof(string), "", MappingType.Element);
                this.columnSIFRAIZVORA.AllowDBNull = false;
                this.columnSIFRAIZVORA.Caption = "SIFRAIZVORA";
                this.columnSIFRAIZVORA.MaxLength = 3;
                this.columnSIFRAIZVORA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Description", "Izvor dok");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Length", "3");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAIZVORA");
                this.Columns.Add(this.columnSIFRAIZVORA);
                this.columnNAZIVIZVORA = new DataColumn("NAZIVIZVORA", typeof(string), "", MappingType.Element);
                this.columnNAZIVIZVORA.AllowDBNull = true;
                this.columnNAZIVIZVORA.Caption = "NAZIVIZVORA";
                this.columnNAZIVIZVORA.MaxLength = 20;
                this.columnNAZIVIZVORA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Description", "NAZIVIZVORA");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVIZVORA");
                this.Columns.Add(this.columnNAZIVIZVORA);
                this.columnPOREZIPRIREZZAJEDNICKI = new DataColumn("POREZIPRIREZZAJEDNICKI", typeof(bool), "", MappingType.Element);
                this.columnPOREZIPRIREZZAJEDNICKI.AllowDBNull = false;
                this.columnPOREZIPRIREZZAJEDNICKI.Caption = "POREZIPRIREZZAJEDNICKI";
                this.columnPOREZIPRIREZZAJEDNICKI.DefaultValue = true;
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("Description", "Zajednički virman poreza i prireza");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("Length", "1");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("Decimals", "0");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZIPRIREZZAJEDNICKI.ExtendedProperties.Add("Deklarit.InternalName", "POREZIPRIREZZAJEDNICKI");
                this.Columns.Add(this.columnPOREZIPRIREZZAJEDNICKI);
                this.columnPOZIVIZADUZENJA = new DataColumn("POZIVIZADUZENJA", typeof(bool), "", MappingType.Element);
                this.columnPOZIVIZADUZENJA.AllowDBNull = false;
                this.columnPOZIVIZADUZENJA.Caption = "POZIVIZADUZENJA";
                this.columnPOZIVIZADUZENJA.DefaultValue = false;
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("Description", "Pozivi na broj zaduženja na virmanima");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("Length", "1");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOZIVIZADUZENJA.ExtendedProperties.Add("Deklarit.InternalName", "POZIVIZADUZENJA");
                this.Columns.Add(this.columnPOZIVIZADUZENJA);
                this.PrimaryKey = new DataColumn[] { this.columnIDKORISNIK, this.columnIDZIRO };
                this.ExtendedProperties.Add("ParentLvl", "KORISNIK");
                this.ExtendedProperties.Add("LevelName", "Level1");
                this.ExtendedProperties.Add("Description", "Podaci o isplatnim Žrn-ima korisnika");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDKORISNIK = this.Columns["IDKORISNIK"];
                this.columnIDZIRO = this.Columns["IDZIRO"];
                this.columnNAZIVZIRO = this.Columns["NAZIVZIRO"];
                this.columnULICAZIRO = this.Columns["ULICAZIRO"];
                this.columnMJESTOZIRO = this.Columns["MJESTOZIRO"];
                this.columnVBDIKORISNIK = this.Columns["VBDIKORISNIK"];
                this.columnZIROKORISNIK = this.Columns["ZIROKORISNIK"];
                this.columnSIFRAIZVORA = this.Columns["SIFRAIZVORA"];
                this.columnNAZIVIZVORA = this.Columns["NAZIVIZVORA"];
                this.columnPOREZIPRIREZZAJEDNICKI = this.Columns["POREZIPRIREZZAJEDNICKI"];
                this.columnPOZIVIZADUZENJA = this.Columns["POZIVIZADUZENJA"];
            }

            public KORISNIKDataSet.KORISNIKLevel1Row NewKORISNIKLevel1Row()
            {
                return (KORISNIKDataSet.KORISNIKLevel1Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new KORISNIKDataSet.KORISNIKLevel1Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.KORISNIKLevel1RowChanged != null)
                {
                    KORISNIKDataSet.KORISNIKLevel1RowChangeEventHandler handler = this.KORISNIKLevel1RowChanged;
                    if (handler != null)
                    {
                        handler(this, new KORISNIKDataSet.KORISNIKLevel1RowChangeEvent((KORISNIKDataSet.KORISNIKLevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.KORISNIKLevel1RowChanging != null)
                {
                    KORISNIKDataSet.KORISNIKLevel1RowChangeEventHandler handler = this.KORISNIKLevel1RowChanging;
                    if (handler != null)
                    {
                        handler(this, new KORISNIKDataSet.KORISNIKLevel1RowChangeEvent((KORISNIKDataSet.KORISNIKLevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("KORISNIK_KORISNIKLevel1", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.KORISNIKLevel1RowDeleted != null)
                {
                    KORISNIKDataSet.KORISNIKLevel1RowChangeEventHandler handler = this.KORISNIKLevel1RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new KORISNIKDataSet.KORISNIKLevel1RowChangeEvent((KORISNIKDataSet.KORISNIKLevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.KORISNIKLevel1RowDeleting != null)
                {
                    KORISNIKDataSet.KORISNIKLevel1RowChangeEventHandler handler = this.KORISNIKLevel1RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new KORISNIKDataSet.KORISNIKLevel1RowChangeEvent((KORISNIKDataSet.KORISNIKLevel1Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveKORISNIKLevel1Row(KORISNIKDataSet.KORISNIKLevel1Row row)
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

            public DataColumn IDKORISNIKColumn
            {
                get
                {
                    return this.columnIDKORISNIK;
                }
            }

            public DataColumn IDZIROColumn
            {
                get
                {
                    return this.columnIDZIRO;
                }
            }

            public KORISNIKDataSet.KORISNIKLevel1Row this[int index]
            {
                get
                {
                    return (KORISNIKDataSet.KORISNIKLevel1Row) this.Rows[index];
                }
            }

            public DataColumn MJESTOZIROColumn
            {
                get
                {
                    return this.columnMJESTOZIRO;
                }
            }

            public DataColumn NAZIVIZVORAColumn
            {
                get
                {
                    return this.columnNAZIVIZVORA;
                }
            }

            public DataColumn NAZIVZIROColumn
            {
                get
                {
                    return this.columnNAZIVZIRO;
                }
            }

            public DataColumn POREZIPRIREZZAJEDNICKIColumn
            {
                get
                {
                    return this.columnPOREZIPRIREZZAJEDNICKI;
                }
            }

            public DataColumn POZIVIZADUZENJAColumn
            {
                get
                {
                    return this.columnPOZIVIZADUZENJA;
                }
            }

            public DataColumn SIFRAIZVORAColumn
            {
                get
                {
                    return this.columnSIFRAIZVORA;
                }
            }

            public DataColumn ULICAZIROColumn
            {
                get
                {
                    return this.columnULICAZIRO;
                }
            }

            public DataColumn VBDIKORISNIKColumn
            {
                get
                {
                    return this.columnVBDIKORISNIK;
                }
            }

            public DataColumn ZIROKORISNIKColumn
            {
                get
                {
                    return this.columnZIROKORISNIK;
                }
            }
        }

        public class KORISNIKLevel1Row : DataRow
        {
            private KORISNIKDataSet.KORISNIKLevel1DataTable tableKORISNIKLevel1;

            internal KORISNIKLevel1Row(DataRowBuilder rb) : base(rb)
            {
                this.tableKORISNIKLevel1 = (KORISNIKDataSet.KORISNIKLevel1DataTable) this.Table;
            }

            public KORISNIKDataSet.KORISNIKRow GetKORISNIKRow()
            {
                return (KORISNIKDataSet.KORISNIKRow) this.GetParentRow("KORISNIK_KORISNIKLevel1");
            }

            public bool IsIDKORISNIKNull()
            {
                return this.IsNull(this.tableKORISNIKLevel1.IDKORISNIKColumn);
            }

            public bool IsIDZIRONull()
            {
                return this.IsNull(this.tableKORISNIKLevel1.IDZIROColumn);
            }

            public bool IsMJESTOZIRONull()
            {
                return this.IsNull(this.tableKORISNIKLevel1.MJESTOZIROColumn);
            }

            public bool IsNAZIVIZVORANull()
            {
                return this.IsNull(this.tableKORISNIKLevel1.NAZIVIZVORAColumn);
            }

            public bool IsNAZIVZIRONull()
            {
                return this.IsNull(this.tableKORISNIKLevel1.NAZIVZIROColumn);
            }

            public bool IsPOREZIPRIREZZAJEDNICKINull()
            {
                return this.IsNull(this.tableKORISNIKLevel1.POREZIPRIREZZAJEDNICKIColumn);
            }

            public bool IsPOZIVIZADUZENJANull()
            {
                return this.IsNull(this.tableKORISNIKLevel1.POZIVIZADUZENJAColumn);
            }

            public bool IsSIFRAIZVORANull()
            {
                return this.IsNull(this.tableKORISNIKLevel1.SIFRAIZVORAColumn);
            }

            public bool IsULICAZIRONull()
            {
                return this.IsNull(this.tableKORISNIKLevel1.ULICAZIROColumn);
            }

            public bool IsVBDIKORISNIKNull()
            {
                return this.IsNull(this.tableKORISNIKLevel1.VBDIKORISNIKColumn);
            }

            public bool IsZIROKORISNIKNull()
            {
                return this.IsNull(this.tableKORISNIKLevel1.ZIROKORISNIKColumn);
            }

            public void SetMJESTOZIRONull()
            {
                this[this.tableKORISNIKLevel1.MJESTOZIROColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVIZVORANull()
            {
                this[this.tableKORISNIKLevel1.NAZIVIZVORAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVZIRONull()
            {
                this[this.tableKORISNIKLevel1.NAZIVZIROColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZIPRIREZZAJEDNICKINull()
            {
                this[this.tableKORISNIKLevel1.POREZIPRIREZZAJEDNICKIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOZIVIZADUZENJANull()
            {
                this[this.tableKORISNIKLevel1.POZIVIZADUZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAIZVORANull()
            {
                this[this.tableKORISNIKLevel1.SIFRAIZVORAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetULICAZIRONull()
            {
                this[this.tableKORISNIKLevel1.ULICAZIROColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIKORISNIKNull()
            {
                this[this.tableKORISNIKLevel1.VBDIKORISNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZIROKORISNIKNull()
            {
                this[this.tableKORISNIKLevel1.ZIROKORISNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDKORISNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableKORISNIKLevel1.IDKORISNIKColumn]);
                }
                set
                {
                    this[this.tableKORISNIKLevel1.IDKORISNIKColumn] = value;
                }
            }

            public int IDZIRO
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableKORISNIKLevel1.IDZIROColumn]);
                }
                set
                {
                    this[this.tableKORISNIKLevel1.IDZIROColumn] = value;
                }
            }

            public string MJESTOZIRO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIKLevel1.MJESTOZIROColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value MJESTOZIRO because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIKLevel1.MJESTOZIROColumn] = value;
                }
            }

            public string NAZIVIZVORA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIKLevel1.NAZIVIZVORAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIKLevel1.NAZIVIZVORAColumn] = value;
                }
            }

            public string NAZIVZIRO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIKLevel1.NAZIVZIROColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIKLevel1.NAZIVZIROColumn] = value;
                }
            }

            public bool POREZIPRIREZZAJEDNICKI
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableKORISNIKLevel1.POREZIPRIREZZAJEDNICKIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableKORISNIKLevel1.POREZIPRIREZZAJEDNICKIColumn] = value;
                }
            }

            public bool POZIVIZADUZENJA
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableKORISNIKLevel1.POZIVIZADUZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableKORISNIKLevel1.POZIVIZADUZENJAColumn] = value;
                }
            }

            public string SIFRAIZVORA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIKLevel1.SIFRAIZVORAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIKLevel1.SIFRAIZVORAColumn] = value;
                }
            }

            public string ULICAZIRO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIKLevel1.ULICAZIROColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIKLevel1.ULICAZIROColumn] = value;
                }
            }

            public string VBDIKORISNIK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIKLevel1.VBDIKORISNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIKLevel1.VBDIKORISNIKColumn] = value;
                }
            }

            public string ZIROKORISNIK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIKLevel1.ZIROKORISNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIKLevel1.ZIROKORISNIKColumn] = value;
                }
            }
        }

        public class KORISNIKLevel1RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private KORISNIKDataSet.KORISNIKLevel1Row eventRow;

            public KORISNIKLevel1RowChangeEvent(KORISNIKDataSet.KORISNIKLevel1Row row, DataRowAction action)
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

            public KORISNIKDataSet.KORISNIKLevel1Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void KORISNIKLevel1RowChangeEventHandler(object sender, KORISNIKDataSet.KORISNIKLevel1RowChangeEvent e);

        public class KORISNIKRow : DataRow
        {
            private KORISNIKDataSet.KORISNIKDataTable tableKORISNIK;

            internal KORISNIKRow(DataRowBuilder rb) : base(rb)
            {
                this.tableKORISNIK = (KORISNIKDataSet.KORISNIKDataTable) this.Table;
            }

            public KORISNIKDataSet.KORISNIKLevel1Row[] GetKORISNIKLevel1Rows()
            {
                return (KORISNIKDataSet.KORISNIKLevel1Row[]) this.GetChildRows("KORISNIK_KORISNIKLevel1");
            }

            public bool IsADRESAOVLASTENEOSOBENull()
            {
                return this.IsNull(this.tableKORISNIK.ADRESAOVLASTENEOSOBEColumn);
            }

            public bool IsANALITIKANull()
            {
                return this.IsNull(this.tableKORISNIK.ANALITIKAColumn);
            }

            public bool IsBROJCANAOZNAKAPUNull()
            {
                return this.IsNull(this.tableKORISNIK.BROJCANAOZNAKAPUColumn);
            }

            public bool IsEMAILNull()
            {
                return this.IsNull(this.tableKORISNIK.EMAILColumn);
            }

            public bool IsEMAILPOSILJAOCANull()
            {
                return this.IsNull(this.tableKORISNIK.EMAILPOSILJAOCAColumn);
            }

            public bool IsIDKORISNIKNull()
            {
                return this.IsNull(this.tableKORISNIK.IDKORISNIKColumn);
            }

            public bool IsJMBGKORISNIKNull()
            {
                return this.IsNull(this.tableKORISNIK.JMBGKORISNIKColumn);
            }

            public bool IsKONTAKTFAXNull()
            {
                return this.IsNull(this.tableKORISNIK.KONTAKTFAXColumn);
            }

            public bool IsKONTAKTOSOBANull()
            {
                return this.IsNull(this.tableKORISNIK.KONTAKTOSOBAColumn);
            }

            public bool IsKONTAKTTELEFONNull()
            {
                return this.IsNull(this.tableKORISNIK.KONTAKTTELEFONColumn);
            }

            public bool IsKORISNIK1ADRESANull()
            {
                return this.IsNull(this.tableKORISNIK.KORISNIK1ADRESAColumn);
            }

            public bool IsKORISNIK1HZZONull()
            {
                return this.IsNull(this.tableKORISNIK.KORISNIK1HZZOColumn);
            }

            public bool IsKORISNIK1MJESTONull()
            {
                return this.IsNull(this.tableKORISNIK.KORISNIK1MJESTOColumn);
            }

            public bool IsKORISNIK1NAZIVNull()
            {
                return this.IsNull(this.tableKORISNIK.KORISNIK1NAZIVColumn);
            }

            public bool IsKORISNIK1NAZIVZANALJEPNICENull()
            {
                return this.IsNull(this.tableKORISNIK.KORISNIK1NAZIVZANALJEPNICEColumn);
            }

            public bool IsKORISNIKOIBNull()
            {
                return this.IsNull(this.tableKORISNIK.KORISNIKOIBColumn);
            }

            public bool IsMBKORISNIKJEDINICANull()
            {
                return this.IsNull(this.tableKORISNIK.MBKORISNIKJEDINICAColumn);
            }

            public bool IsMBKORISNIKNull()
            {
                return this.IsNull(this.tableKORISNIK.MBKORISNIKColumn);
            }

            public bool IsNADLEZNAPUNull()
            {
                return this.IsNull(this.tableKORISNIK.NADLEZNAPUColumn);
            }

            public bool IsNAZIVPOSILJAOCANull()
            {
                return this.IsNull(this.tableKORISNIK.NAZIVPOSILJAOCAColumn);
            }

            public bool IsOIBOVLASTENEOSOBENull()
            {
                return this.IsNull(this.tableKORISNIK.OIBOVLASTENEOSOBEColumn);
            }

            public bool IsPREZIMEIMEOVLASTENEOSOBENull()
            {
                return this.IsNull(this.tableKORISNIK.PREZIMEIMEOVLASTENEOSOBEColumn);
            }

            public bool IsRKPNull()
            {
                return this.IsNull(this.tableKORISNIK.RKPColumn);
            }

            public bool IsSMTPSERVERNull()
            {
                return this.IsNull(this.tableKORISNIK.SMTPSERVERColumn);
            }

            public bool IsSTAZUKOEFICIJENTUNull()
            {
                return this.IsNull(this.tableKORISNIK.STAZUKOEFICIJENTUColumn);
            }

            public bool IsOBVEZNIKPDVANull()
            {
                return this.IsNull(this.tableKORISNIK.OBVEZNIKPDVAColumn);
            }

            public void SetADRESAOVLASTENEOSOBENull()
            {
                this[this.tableKORISNIK.ADRESAOVLASTENEOSOBEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetANALITIKANull()
            {
                this[this.tableKORISNIK.ANALITIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJCANAOZNAKAPUNull()
            {
                this[this.tableKORISNIK.BROJCANAOZNAKAPUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetEMAILNull()
            {
                this[this.tableKORISNIK.EMAILColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetEMAILPOSILJAOCANull()
            {
                this[this.tableKORISNIK.EMAILPOSILJAOCAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGKORISNIKNull()
            {
                this[this.tableKORISNIK.JMBGKORISNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKONTAKTFAXNull()
            {
                this[this.tableKORISNIK.KONTAKTFAXColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKONTAKTOSOBANull()
            {
                this[this.tableKORISNIK.KONTAKTOSOBAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKONTAKTTELEFONNull()
            {
                this[this.tableKORISNIK.KONTAKTTELEFONColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKORISNIK1ADRESANull()
            {
                this[this.tableKORISNIK.KORISNIK1ADRESAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKORISNIK1HZZONull()
            {
                this[this.tableKORISNIK.KORISNIK1HZZOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKORISNIK1MJESTONull()
            {
                this[this.tableKORISNIK.KORISNIK1MJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKORISNIK1NAZIVNull()
            {
                this[this.tableKORISNIK.KORISNIK1NAZIVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKORISNIK1NAZIVZANALJEPNICENull()
            {
                this[this.tableKORISNIK.KORISNIK1NAZIVZANALJEPNICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKORISNIKOIBNull()
            {
                this[this.tableKORISNIK.KORISNIKOIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool IsJOPPDPodnositeljIzvjescaIDNull()
            {
                return this.IsNull(this.tableKORISNIK.JOPPDPodnositeljIzvjescaIDColumn);
            }

            public void SetMBKORISNIKJEDINICANull()
            {
                this[this.tableKORISNIK.MBKORISNIKJEDINICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMBKORISNIKNull()
            {
                this[this.tableKORISNIK.MBKORISNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNADLEZNAPUNull()
            {
                this[this.tableKORISNIK.NADLEZNAPUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPOSILJAOCANull()
            {
                this[this.tableKORISNIK.NAZIVPOSILJAOCAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOIBOVLASTENEOSOBENull()
            {
                this[this.tableKORISNIK.OIBOVLASTENEOSOBEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMEIMEOVLASTENEOSOBENull()
            {
                this[this.tableKORISNIK.PREZIMEIMEOVLASTENEOSOBEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRKPNull()
            {
                this[this.tableKORISNIK.RKPColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSMTPSERVERNull()
            {
                this[this.tableKORISNIK.SMTPSERVERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTAZUKOEFICIJENTUNull()
            {
                this[this.tableKORISNIK.STAZUKOEFICIJENTUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBVEZNIKPDVANull()
            {
                this[this.tableKORISNIK.OBVEZNIKPDVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNeprofitniNull()
            {
                this[this.tableKORISNIK.NeprofitniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            //1.1.15
            public void SetStopaZaInvalideNull()
            {
                this[this.tableKORISNIK.StopaZaInvalideColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            #region MBS.Complete
            public void SetPredPorezNull()
            {
                this[this.tableKORISNIK.PredPorezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            #endregion

            public void SetBrojOsobaNull()
            {
                this[this.tableKORISNIK.BrojOsobaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            public void SetPDVPoNaplacenomNull()
            {
                this[this.tableKORISNIK.PDVPoNaplacenomColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJOPPDPodnositeljIzvjescaIDNull()
            {
                this[this.tableKORISNIK.JOPPDPodnositeljIzvjescaIDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string ADRESAOVLASTENEOSOBE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.ADRESAOVLASTENEOSOBEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.ADRESAOVLASTENEOSOBEColumn] = value;
                }
            }

            public int ANALITIKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableKORISNIK.ANALITIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableKORISNIK.ANALITIKAColumn] = value;
                }
            }

            public int BROJCANAOZNAKAPU
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableKORISNIK.BROJCANAOZNAKAPUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableKORISNIK.BROJCANAOZNAKAPUColumn] = value;
                }
            }

            public string EMAIL
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.EMAILColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.EMAILColumn] = value;
                }
            }

            public string EMAILPOSILJAOCA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.EMAILPOSILJAOCAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.EMAILPOSILJAOCAColumn] = value;
                }
            }

            public int IDKORISNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableKORISNIK.IDKORISNIKColumn]);
                }
                set
                {
                    this[this.tableKORISNIK.IDKORISNIKColumn] = value;
                }
            }

            public string JMBGKORISNIK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.JMBGKORISNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.JMBGKORISNIKColumn] = value;
                }
            }

            public string KONTAKTFAX
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.KONTAKTFAXColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.KONTAKTFAXColumn] = value;
                }
            }

            public string KONTAKTOSOBA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.KONTAKTOSOBAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.KONTAKTOSOBAColumn] = value;
                }
            }

            public string KONTAKTTELEFON
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.KONTAKTTELEFONColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.KONTAKTTELEFONColumn] = value;
                }
            }

            public string KORISNIK1ADRESA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.KORISNIK1ADRESAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.KORISNIK1ADRESAColumn] = value;
                }
            }

            public string KORISNIK1HZZO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.KORISNIK1HZZOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.KORISNIK1HZZOColumn] = value;
                }
            }

            public string KORISNIK1MJESTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.KORISNIK1MJESTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.KORISNIK1MJESTOColumn] = value;
                }
            }

            public string KORISNIK1NAZIV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.KORISNIK1NAZIVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.KORISNIK1NAZIVColumn] = value;
                }
            }

            public string KORISNIK1NAZIVZANALJEPNICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.KORISNIK1NAZIVZANALJEPNICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.KORISNIK1NAZIVZANALJEPNICEColumn] = value;
                }
            }

            public string KORISNIKOIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.KORISNIKOIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.KORISNIKOIBColumn] = value;
                }
            }

            public string MBKORISNIK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.MBKORISNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.MBKORISNIKColumn] = value;
                }
            }

            public string MBKORISNIKJEDINICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.MBKORISNIKJEDINICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.MBKORISNIKJEDINICAColumn] = value;
                }
            }

            public string NADLEZNAPU
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.NADLEZNAPUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.NADLEZNAPUColumn] = value;
                }
            }

            public string NAZIVPOSILJAOCA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.NAZIVPOSILJAOCAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.NAZIVPOSILJAOCAColumn] = value;
                }
            }

            public string OIBOVLASTENEOSOBE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.OIBOVLASTENEOSOBEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.OIBOVLASTENEOSOBEColumn] = value;
                }
            }

            public string PREZIMEIMEOVLASTENEOSOBE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.PREZIMEIMEOVLASTENEOSOBEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.PREZIMEIMEOVLASTENEOSOBEColumn] = value;
                }
            }

            public int RKP
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableKORISNIK.RKPColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableKORISNIK.RKPColumn] = value;
                }
            }

            public string SMTPSERVER
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKORISNIK.SMTPSERVERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKORISNIK.SMTPSERVERColumn] = value;
                }
            }

            public bool STAZUKOEFICIJENTU
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableKORISNIK.STAZUKOEFICIJENTUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableKORISNIK.STAZUKOEFICIJENTUColumn] = value;
                }
            }

            public int JOPPDPodnositeljIzvjescaID
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableKORISNIK.JOPPDPodnositeljIzvjescaIDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableKORISNIK.JOPPDPodnositeljIzvjescaIDColumn] = value;
                }
            }

            public bool OBVEZNIKPDVA
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableKORISNIK.OBVEZNIKPDVAColumn]);
                    }
                    catch(InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableKORISNIK.OBVEZNIKPDVAColumn] = value;
                }
            }

            #region MBS.Complete
            public double PredPorez
            {
                get
                {
                    double num = 0;
                    try
                    {
                        num = Conversions.ToDouble(this[this.tableKORISNIK.PredPorezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableKORISNIK.PredPorezColumn] = value;
                }
            }
            #endregion


            //1.1.15
            public double StopaZaInvalide
            {
                get
                {
                    double num = 0;
                    try
                    {
                        num = Conversions.ToDouble(this[this.tableKORISNIK.StopaZaInvalideColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableKORISNIK.StopaZaInvalideColumn] = value;
                }
            }
            public double BrojOsoba
            {
                get
                {
                    double num = 0;
                    try
                    {
                        num = Conversions.ToDouble(this[this.tableKORISNIK.BrojOsobaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableKORISNIK.BrojOsobaColumn] = value;
                }
            }
            public bool PDVPoNaplacenom
            {
                get
                {
                    bool num = false;
                    try
                    {
                        num = Conversions.ToBoolean(this[this.tableKORISNIK.PDVPoNaplacenomColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableKORISNIK.PDVPoNaplacenomColumn] = value;
                }
            }
        }

        public class KORISNIKRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private KORISNIKDataSet.KORISNIKRow eventRow;

            public KORISNIKRowChangeEvent(KORISNIKDataSet.KORISNIKRow row, DataRowAction action)
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

            public KORISNIKDataSet.KORISNIKRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void KORISNIKRowChangeEventHandler(object sender, KORISNIKDataSet.KORISNIKRowChangeEvent e);
    }
}

