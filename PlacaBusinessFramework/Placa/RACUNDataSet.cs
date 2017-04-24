namespace Placa
{
    using Microsoft.VisualBasic.CompilerServices;
    using mipsed.application.framework;

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
    public class RACUNDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RACUNDataTable tableRACUN;
        private RACUNRacunStavkeDataTable tableRACUNRacunStavke;

        public RACUNDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RACUNDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RACUNRacunStavke"] != null)
                    {
                        this.Tables.Add(new RACUNRacunStavkeDataTable(dataSet.Tables["RACUNRacunStavke"]));
                    }
                    if (dataSet.Tables["RACUN"] != null)
                    {
                        this.Tables.Add(new RACUNDataTable(dataSet.Tables["RACUN"]));
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
            RACUNDataSet set = (RACUNDataSet) base.Clone();
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
            RACUNDataSet set = new RACUNDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RACUNDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2001");
            this.ExtendedProperties.Add("DataSetName", "RACUNDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRACUNDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RACUN");
            this.ExtendedProperties.Add("ObjectDescription", "Izlazni računi");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents");
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
            this.DataSetName = "RACUNDataSet";
            this.Namespace = "http://www.tempuri.org/RACUN";
            this.tableRACUNRacunStavke = new RACUNRacunStavkeDataTable();
            this.Tables.Add(this.tableRACUNRacunStavke);
            this.tableRACUN = new RACUNDataTable();
            this.Tables.Add(this.tableRACUN);
            this.Relations.Add("RACUN_RACUNRacunStavke", new DataColumn[] { this.Tables["RACUN"].Columns["IDRACUN"], this.Tables["RACUN"].Columns["RACUNGODINAIDGODINE"] }, new DataColumn[] { this.Tables["RACUNRacunStavke"].Columns["IDRACUN"], this.Tables["RACUNRacunStavke"].Columns["RACUNGODINAIDGODINE"] });
            this.Relations["RACUN_RACUNRacunStavke"].Nested = true;
            this.tableRACUNRacunStavke.IZNOSMINUSRABATColumn.Expression = "IZNOSRACUN-IZNOSRABATA";
            this.tableRACUNRacunStavke.IZNOSPLUSPDVColumn.Expression = "IZNOSMINUSRABAT+PDV";
            this.tableRACUN.UKUPNOOSNOVICAColumn.Expression = "IIF(Count(Child(RACUN_RACUNRacunStavke).IZNOSMINUSRABAT)=0,0,SUM(Child(RACUN_RACUNRacunStavke).IZNOSMINUSRABAT))";
            this.tableRACUN.UKUPNOPDVColumn.Expression = "IIF(Count(Child(RACUN_RACUNRacunStavke).PDV)=0,0,SUM(Child(RACUN_RACUNRacunStavke).PDV))";
            //this.tableRACUN.SVEUKUPNOColumn.Expression = "IIF(Min(Child(RACUN_RACUNRacunStavke).KOLICINA)<0, SUM(Child(RACUN_RACUNRacunStavke).CijenaPDV) * -1, SUM(Child(RACUN_RACUNRacunStavke).CijenaPDV))"; 
            //this.tableRACUN.SVEUKUPNOColumn.Expression = "UKUPNOOSNOVICA+UKUPNOPDV";
            this.tableRACUN.SVEUKUPNOColumn.Expression = "UkupanIznos";
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
            this.tableRACUNRacunStavke = (RACUNRacunStavkeDataTable) this.Tables["RACUNRacunStavke"];
            this.tableRACUN = (RACUNDataTable) this.Tables["RACUN"];
            if (initTable)
            {
                if (this.tableRACUNRacunStavke != null)
                {
                    this.tableRACUNRacunStavke.InitVars();
                }
                if (this.tableRACUN != null)
                {
                    this.tableRACUN.InitVars();
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
                if (dataSet.Tables["RACUNRacunStavke"] != null)
                {
                    this.Tables.Add(new RACUNRacunStavkeDataTable(dataSet.Tables["RACUNRacunStavke"]));
                }
                if (dataSet.Tables["RACUN"] != null)
                {
                    this.Tables.Add(new RACUNDataTable(dataSet.Tables["RACUN"]));
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

        private bool ShouldSerializeRACUN()
        {
            return false;
        }

        private bool ShouldSerializeRACUNRacunStavke()
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
        public RACUNDataTable RACUN
        {
            get
            {
                return this.tableRACUN;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RACUNRacunStavkeDataTable RACUNRacunStavke
        {
            get
            {
                return this.tableRACUNRacunStavke;
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
        public class RACUNDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJRACUNA;
            private DataColumn columnDATUM;
            private DataColumn columnIDPARTNER;
            private DataColumn columnIDRACUN;
            private DataColumn columnMB;
            private DataColumn columnMODEL;
            private DataColumn columnNAPOMENA;
            private DataColumn columnNAZIVPARTNER;
            private DataColumn columnPARTNEREMAIL;
            private DataColumn columnPARTNERMJESTO;
            private DataColumn columnPARTNEROIB;
            private DataColumn columnPARTNERULICA;
            private DataColumn columnPOZIV;
            private DataColumn columnRACUNGODINAIDGODINE;
            private DataColumn columnRAZDOBLJEDO;
            private DataColumn columnRAZDOBLJEOD;
            private DataColumn columnSLOVIMA;
            private DataColumn columnSVEUKUPNO;
            private DataColumn columnUKUPNOOSNOVICA;
            private DataColumn columnUKUPNOPDV;
            private DataColumn columnVALUTA;
            private DataColumn columnZAPREDUJAM;
            private DataColumn columnVrsta;
            private DataColumn columnUkupanIznos;

            public event RACUNDataSet.RACUNRowChangeEventHandler RACUNRowChanged;

            public event RACUNDataSet.RACUNRowChangeEventHandler RACUNRowChanging;

            public event RACUNDataSet.RACUNRowChangeEventHandler RACUNRowDeleted;

            public event RACUNDataSet.RACUNRowChangeEventHandler RACUNRowDeleting;

            public RACUNDataTable()
            {
                this.TableName = "RACUN";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RACUNDataTable(DataTable table) : base(table.TableName)
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

            protected RACUNDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRACUNRow(RACUNDataSet.RACUNRow row)
            {
                this.Rows.Add(row);
            }

            public RACUNDataSet.RACUNRow AddRACUNRow(int iDRACUN, short rACUNGODINAIDGODINE, int iDPARTNER, DateTime dATUM, DateTime vALUTA, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string mODEL, string pOZIV, string nAPOMENA, bool zAPREDUJAM)
            {
                RACUNDataSet.RACUNRow row = (RACUNDataSet.RACUNRow) this.NewRow();
                row["IDRACUN"] = iDRACUN;
                row["RACUNGODINAIDGODINE"] = rACUNGODINAIDGODINE;
                row["IDPARTNER"] = iDPARTNER;
                row["DATUM"] = dATUM;
                row["VALUTA"] = vALUTA;
                row["RAZDOBLJEOD"] = rAZDOBLJEOD;
                row["RAZDOBLJEDO"] = rAZDOBLJEDO;
                row["MODEL"] = mODEL;
                row["POZIV"] = pOZIV;
                row["NAPOMENA"] = nAPOMENA;
                row["ZAPREDUJAM"] = zAPREDUJAM;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RACUNDataSet.RACUNDataTable table = (RACUNDataSet.RACUNDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RACUNDataSet.RACUNRow FindByIDRACUNRACUNGODINAIDGODINE(int iDRACUN, short rACUNGODINAIDGODINE)
            {
                return (RACUNDataSet.RACUNRow) this.Rows.Find(new object[] { iDRACUN, rACUNGODINAIDGODINE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RACUNDataSet.RACUNRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RACUNDataSet set = new RACUNDataSet();
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
                this.columnIDRACUN = new DataColumn("IDRACUN", typeof(int), "", MappingType.Element);
                this.columnIDRACUN.AllowDBNull = false;
                this.columnIDRACUN.Caption = "IDRACUN";
                this.columnIDRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRACUN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRACUN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRACUN.ExtendedProperties.Add("Description", "Račun");
                this.columnIDRACUN.ExtendedProperties.Add("Length", "6");
                this.columnIDRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDRACUN");
                this.Columns.Add(this.columnIDRACUN);
                this.columnRACUNGODINAIDGODINE = new DataColumn("RACUNGODINAIDGODINE", typeof(short), "", MappingType.Element);
                this.columnRACUNGODINAIDGODINE.AllowDBNull = false;
                this.columnRACUNGODINAIDGODINE.Caption = "IDGODINE";
                this.columnRACUNGODINAIDGODINE.DefaultValue = mipsed.application.framework.Application.ActiveYear;
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("SuperType", "IDGODINE");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("SubtypeGroup", "RACUNGODINA");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("IsKey", "true");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Description", "IDGODINE");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "RACUNGODINAIDGODINE");
                this.Columns.Add(this.columnRACUNGODINAIDGODINE);
                this.columnIDPARTNER = new DataColumn("IDPARTNER", typeof(int), "", MappingType.Element);
                this.columnIDPARTNER.AllowDBNull = false;
                this.columnIDPARTNER.Caption = "Šifra partnera";
                this.columnIDPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPARTNER.ExtendedProperties.Add("Description", "Šif. partnera");
                this.columnIDPARTNER.ExtendedProperties.Add("Length", "9");
                this.columnIDPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "IDPARTNER");
                this.Columns.Add(this.columnIDPARTNER);
                this.columnNAZIVPARTNER = new DataColumn("NAZIVPARTNER", typeof(string), "", MappingType.Element);
                this.columnNAZIVPARTNER.AllowDBNull = true;
                this.columnNAZIVPARTNER.Caption = "Naziv partnera";
                this.columnNAZIVPARTNER.MaxLength = 100;
                this.columnNAZIVPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Description", "Partner");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPARTNER");
                this.Columns.Add(this.columnNAZIVPARTNER);
                this.columnMB = new DataColumn("MB", typeof(string), "", MappingType.Element);
                this.columnMB.AllowDBNull = true;
                this.columnMB.Caption = "MB";
                this.columnMB.MaxLength = 13;
                this.columnMB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMB.ExtendedProperties.Add("IsKey", "false");
                this.columnMB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMB.ExtendedProperties.Add("Description", "MB");
                this.columnMB.ExtendedProperties.Add("Length", "13");
                this.columnMB.ExtendedProperties.Add("Decimals", "0");
                this.columnMB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMB.ExtendedProperties.Add("IsInReader", "true");
                this.columnMB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMB.ExtendedProperties.Add("Deklarit.InternalName", "MB");
                this.Columns.Add(this.columnMB);
                this.columnPARTNERMJESTO = new DataColumn("PARTNERMJESTO", typeof(string), "", MappingType.Element);
                this.columnPARTNERMJESTO.AllowDBNull = true;
                this.columnPARTNERMJESTO.Caption = "PARTNERMJESTO";
                this.columnPARTNERMJESTO.MaxLength = 50;
                this.columnPARTNERMJESTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Description", "Mjesto");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Length", "50");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERMJESTO");
                this.Columns.Add(this.columnPARTNERMJESTO);
                this.columnPARTNERULICA = new DataColumn("PARTNERULICA", typeof(string), "", MappingType.Element);
                this.columnPARTNERULICA.AllowDBNull = true;
                this.columnPARTNERULICA.Caption = "PARTNERULICA";
                this.columnPARTNERULICA.MaxLength = 150;
                this.columnPARTNERULICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERULICA.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERULICA.ExtendedProperties.Add("Description", "Ulica i broj");
                this.columnPARTNERULICA.ExtendedProperties.Add("Length", "150");
                this.columnPARTNERULICA.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERULICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERULICA");
                this.Columns.Add(this.columnPARTNERULICA);
                this.columnPARTNEREMAIL = new DataColumn("PARTNEREMAIL", typeof(string), "", MappingType.Element);
                this.columnPARTNEREMAIL.AllowDBNull = true;
                this.columnPARTNEREMAIL.Caption = "PARTNEREMAIL";
                this.columnPARTNEREMAIL.MaxLength = 100;
                this.columnPARTNEREMAIL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Description", "PARTNEREMAIL");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Length", "100");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.InternalName", "PARTNEREMAIL");
                this.Columns.Add(this.columnPARTNEREMAIL);
                this.columnDATUM = new DataColumn("DATUM", typeof(DateTime), "", MappingType.Element);
                this.columnDATUM.AllowDBNull = false;
                this.columnDATUM.Caption = "Datum";
                this.columnDATUM.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUM.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUM.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUM.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUM.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUM.ExtendedProperties.Add("Description", "Datum");
                this.columnDATUM.ExtendedProperties.Add("Length", "8");
                this.columnDATUM.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUM.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUM.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.InternalName", "DATUM");
                this.Columns.Add(this.columnDATUM);
                this.columnVALUTA = new DataColumn("VALUTA", typeof(DateTime), "", MappingType.Element);
                this.columnVALUTA.AllowDBNull = false;
                this.columnVALUTA.Caption = "Valuta";
                this.columnVALUTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVALUTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVALUTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVALUTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVALUTA.ExtendedProperties.Add("IsKey", "false");
                this.columnVALUTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVALUTA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnVALUTA.ExtendedProperties.Add("Description", "Valuta");
                this.columnVALUTA.ExtendedProperties.Add("Length", "8");
                this.columnVALUTA.ExtendedProperties.Add("Decimals", "0");
                this.columnVALUTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVALUTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnVALUTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVALUTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVALUTA.ExtendedProperties.Add("Deklarit.InternalName", "VALUTA");
                this.Columns.Add(this.columnVALUTA);
                this.columnRAZDOBLJEOD = new DataColumn("RAZDOBLJEOD", typeof(DateTime), "", MappingType.Element);
                this.columnRAZDOBLJEOD.AllowDBNull = true;
                this.columnRAZDOBLJEOD.Caption = "RAZDOBLJEOD";
                this.columnRAZDOBLJEOD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("IsKey", "false");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("DeklaritType", "date");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("Description", "Od");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("Length", "8");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("Decimals", "0");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.InternalName", "RAZDOBLJEOD");
                this.Columns.Add(this.columnRAZDOBLJEOD);
                this.columnRAZDOBLJEDO = new DataColumn("RAZDOBLJEDO", typeof(DateTime), "", MappingType.Element);
                this.columnRAZDOBLJEDO.AllowDBNull = true;
                this.columnRAZDOBLJEDO.Caption = "RAZDOBLJEDO";
                this.columnRAZDOBLJEDO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("IsKey", "false");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("DeklaritType", "date");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("Description", "Do");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("Length", "8");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("Decimals", "0");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.InternalName", "RAZDOBLJEDO");
                this.Columns.Add(this.columnRAZDOBLJEDO);
                this.columnMODEL = new DataColumn("MODEL", typeof(string), "", MappingType.Element);
                this.columnMODEL.AllowDBNull = false;
                this.columnMODEL.Caption = "MODEL";
                this.columnMODEL.MaxLength = 2;
                this.columnMODEL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMODEL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMODEL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMODEL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMODEL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMODEL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMODEL.ExtendedProperties.Add("IsKey", "false");
                this.columnMODEL.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMODEL.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMODEL.ExtendedProperties.Add("Description", "MODEL");
                this.columnMODEL.ExtendedProperties.Add("Length", "2");
                this.columnMODEL.ExtendedProperties.Add("Decimals", "0");
                this.columnMODEL.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMODEL.ExtendedProperties.Add("IsInReader", "true");
                this.columnMODEL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMODEL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMODEL.ExtendedProperties.Add("Deklarit.InternalName", "MODEL");
                this.Columns.Add(this.columnMODEL);
                this.columnPOZIV = new DataColumn("POZIV", typeof(string), "", MappingType.Element);
                this.columnPOZIV.AllowDBNull = false;
                this.columnPOZIV.Caption = "POZIV";
                this.columnPOZIV.MaxLength = 22;
                this.columnPOZIV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOZIV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOZIV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOZIV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOZIV.ExtendedProperties.Add("IsKey", "false");
                this.columnPOZIV.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOZIV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOZIV.ExtendedProperties.Add("Description", "Poziv na broj");
                this.columnPOZIV.ExtendedProperties.Add("Length", "21");
                this.columnPOZIV.ExtendedProperties.Add("Decimals", "0");
                this.columnPOZIV.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOZIV.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOZIV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOZIV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOZIV.ExtendedProperties.Add("Deklarit.InternalName", "POZIV");
                this.Columns.Add(this.columnPOZIV);
                this.columnSLOVIMA = new DataColumn("SLOVIMA", typeof(string), "", MappingType.Element);
                this.columnSLOVIMA.AllowDBNull = true;
                this.columnSLOVIMA.Caption = "SLOVIMA";
                this.columnSLOVIMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSLOVIMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSLOVIMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSLOVIMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSLOVIMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSLOVIMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSLOVIMA.ExtendedProperties.Add("IsKey", "false");
                this.columnSLOVIMA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSLOVIMA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSLOVIMA.ExtendedProperties.Add("Description", "SLOVIMA");
                this.columnSLOVIMA.ExtendedProperties.Add("Length", "400");
                this.columnSLOVIMA.ExtendedProperties.Add("Decimals", "0");
                this.columnSLOVIMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSLOVIMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSLOVIMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSLOVIMA.ExtendedProperties.Add("Deklarit.InternalName", "SLOVIMA");
                this.Columns.Add(this.columnSLOVIMA);

                this.columnNAPOMENA = new DataColumn("NAPOMENA", typeof(string), "", MappingType.Element);
                this.columnNAPOMENA.AllowDBNull = true;
                this.columnNAPOMENA.Caption = "NAPOMENA";
                this.columnNAPOMENA.MaxLength = 200;
                this.columnNAPOMENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAPOMENA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAPOMENA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAPOMENA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAPOMENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAPOMENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAPOMENA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAPOMENA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAPOMENA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAPOMENA.ExtendedProperties.Add("Description", "NAPOMENA");
                this.columnNAPOMENA.ExtendedProperties.Add("Length", "200");
                this.columnNAPOMENA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAPOMENA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAPOMENA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAPOMENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAPOMENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAPOMENA.ExtendedProperties.Add("Deklarit.InternalName", "NAPOMENA");
                this.Columns.Add(this.columnNAPOMENA);


                this.columnVrsta = new DataColumn("Vrsta", typeof(string), "", MappingType.Element);
                this.columnVrsta.AllowDBNull = true;
                this.columnVrsta.Caption = "Vrsta";
                this.columnVrsta.MaxLength = 3;
                this.columnVrsta.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVrsta.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVrsta.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "false");
                this.columnVrsta.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVrsta.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVrsta.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVrsta.ExtendedProperties.Add("IsKey", "false");
                this.columnVrsta.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVrsta.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVrsta.ExtendedProperties.Add("Description", "Vrsta");
                this.columnVrsta.ExtendedProperties.Add("Length", "3");
                this.columnVrsta.ExtendedProperties.Add("Decimals", "0");
                this.columnVrsta.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVrsta.ExtendedProperties.Add("IsInReader", "true");
                this.columnVrsta.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVrsta.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVrsta.ExtendedProperties.Add("Deklarit.InternalName", "Vrsta");
                this.Columns.Add(this.columnVrsta);

                this.columnUkupanIznos = new DataColumn("UkupanIznos", typeof(decimal), "", MappingType.Element);
                this.columnUkupanIznos.AllowDBNull = true;
                this.columnUkupanIznos.Caption = "UkupanIznos";
                this.columnUkupanIznos.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUkupanIznos.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUkupanIznos.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "false");
                this.columnUkupanIznos.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUkupanIznos.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUkupanIznos.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUkupanIznos.ExtendedProperties.Add("IsKey", "false");
                this.columnUkupanIznos.ExtendedProperties.Add("ReadOnly", "false");
                this.columnUkupanIznos.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUkupanIznos.ExtendedProperties.Add("Description", "UkupanIznos");
                this.columnUkupanIznos.ExtendedProperties.Add("Length", "12");
                this.columnUkupanIznos.ExtendedProperties.Add("Decimals", "2");
                this.columnUkupanIznos.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUkupanIznos.ExtendedProperties.Add("DomainType", "UkupanIznos");
                this.columnUkupanIznos.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUkupanIznos.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUkupanIznos.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUkupanIznos.ExtendedProperties.Add("Deklarit.InternalName", "UkupanIznos");
                this.columnUkupanIznos.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnUkupanIznos);


                this.columnUKUPNOOSNOVICA = new DataColumn("UKUPNOOSNOVICA", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOOSNOVICA.AllowDBNull = true;
                this.columnUKUPNOOSNOVICA.Caption = "UKUPNOOSNOVICA";
                this.columnUKUPNOOSNOVICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("Description", "Osnovica");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOOSNOVICA");
                this.columnUKUPNOOSNOVICA.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnUKUPNOOSNOVICA);

                this.columnUKUPNOPDV = new DataColumn("UKUPNOPDV", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOPDV.AllowDBNull = true;
                this.columnUKUPNOPDV.Caption = "UKUPNOPDV";
                this.columnUKUPNOPDV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOPDV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUKUPNOPDV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUKUPNOPDV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUKUPNOPDV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOPDV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOPDV.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOPDV.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOPDV.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOPDV.ExtendedProperties.Add("Description", "Pdv");
                this.columnUKUPNOPDV.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOPDV.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOPDV.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOPDV.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOPDV.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOPDV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOPDV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOPDV.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOPDV");
                this.columnUKUPNOPDV.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnUKUPNOPDV);
                this.columnSVEUKUPNO = new DataColumn("SVEUKUPNO", typeof(decimal), "", MappingType.Element);
                this.columnSVEUKUPNO.AllowDBNull = true;
                this.columnSVEUKUPNO.Caption = "SVEUKUPNO";
                this.columnSVEUKUPNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSVEUKUPNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSVEUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSVEUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSVEUKUPNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSVEUKUPNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSVEUKUPNO.ExtendedProperties.Add("IsKey", "false");
                this.columnSVEUKUPNO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSVEUKUPNO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSVEUKUPNO.ExtendedProperties.Add("Description", "SVEUKUPNO");
                this.columnSVEUKUPNO.ExtendedProperties.Add("Length", "12");
                this.columnSVEUKUPNO.ExtendedProperties.Add("Decimals", "2");
                this.columnSVEUKUPNO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSVEUKUPNO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSVEUKUPNO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSVEUKUPNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSVEUKUPNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSVEUKUPNO.ExtendedProperties.Add("Deklarit.InternalName", "SVEUKUPNO");
                this.columnSVEUKUPNO.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnSVEUKUPNO);
                this.columnBROJRACUNA = new DataColumn("BROJRACUNA", typeof(string), "", MappingType.Element);
                this.columnBROJRACUNA.AllowDBNull = true;
                this.columnBROJRACUNA.Caption = "BROJRACUNA";
                this.columnBROJRACUNA.MaxLength = 10;
                this.columnBROJRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRACUNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBROJRACUNA.ExtendedProperties.Add("Description", "BROJRACUNA");
                this.columnBROJRACUNA.ExtendedProperties.Add("Length", "10");
                this.columnBROJRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJRACUNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "BROJRACUNA");
                this.Columns.Add(this.columnBROJRACUNA);
                this.columnPARTNEROIB = new DataColumn("PARTNEROIB", typeof(string), "", MappingType.Element);
                this.columnPARTNEROIB.AllowDBNull = true;
                this.columnPARTNEROIB.Caption = "PARTNEROIB";
                this.columnPARTNEROIB.MaxLength = 25;
                this.columnPARTNEROIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNEROIB.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNEROIB.ExtendedProperties.Add("Description", "PARTNEROIB");
                this.columnPARTNEROIB.ExtendedProperties.Add("Length", "25");
                this.columnPARTNEROIB.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNEROIB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.InternalName", "PARTNEROIB");
                this.Columns.Add(this.columnPARTNEROIB);
                this.columnZAPREDUJAM = new DataColumn("ZAPREDUJAM", typeof(bool), "", MappingType.Element);
                this.columnZAPREDUJAM.AllowDBNull = false;
                this.columnZAPREDUJAM.Caption = "ZAPREDUJAM";
                this.columnZAPREDUJAM.DefaultValue = false;
                this.columnZAPREDUJAM.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZAPREDUJAM.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZAPREDUJAM.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZAPREDUJAM.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZAPREDUJAM.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZAPREDUJAM.ExtendedProperties.Add("IsKey", "false");
                this.columnZAPREDUJAM.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZAPREDUJAM.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnZAPREDUJAM.ExtendedProperties.Add("Description", "Rn.za predujam");
                this.columnZAPREDUJAM.ExtendedProperties.Add("Length", "1");
                this.columnZAPREDUJAM.ExtendedProperties.Add("Decimals", "0");
                this.columnZAPREDUJAM.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZAPREDUJAM.ExtendedProperties.Add("IsInReader", "true");
                this.columnZAPREDUJAM.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZAPREDUJAM.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZAPREDUJAM.ExtendedProperties.Add("Deklarit.InternalName", "ZAPREDUJAM");
                this.Columns.Add(this.columnZAPREDUJAM);
                this.PrimaryKey = new DataColumn[] { this.columnIDRACUN, this.columnRACUNGODINAIDGODINE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RACUN");
                this.ExtendedProperties.Add("Description", "Izlazni računi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDRACUN = this.Columns["IDRACUN"];
                this.columnRACUNGODINAIDGODINE = this.Columns["RACUNGODINAIDGODINE"];
                this.columnIDPARTNER = this.Columns["IDPARTNER"];
                this.columnNAZIVPARTNER = this.Columns["NAZIVPARTNER"];
                this.columnMB = this.Columns["MB"];
                this.columnPARTNERMJESTO = this.Columns["PARTNERMJESTO"];
                this.columnPARTNERULICA = this.Columns["PARTNERULICA"];
                this.columnPARTNEREMAIL = this.Columns["PARTNEREMAIL"];
                this.columnDATUM = this.Columns["DATUM"];
                this.columnVALUTA = this.Columns["VALUTA"];
                this.columnRAZDOBLJEOD = this.Columns["RAZDOBLJEOD"];
                this.columnRAZDOBLJEDO = this.Columns["RAZDOBLJEDO"];
                this.columnMODEL = this.Columns["MODEL"];
                this.columnPOZIV = this.Columns["POZIV"];
                this.columnSLOVIMA = this.Columns["SLOVIMA"];
                this.columnNAPOMENA = this.Columns["NAPOMENA"];
                this.columnUKUPNOOSNOVICA = this.Columns["UKUPNOOSNOVICA"];
                this.columnUKUPNOPDV = this.Columns["UKUPNOPDV"];
                this.columnSVEUKUPNO = this.Columns["SVEUKUPNO"];
                this.columnBROJRACUNA = this.Columns["BROJRACUNA"];
                this.columnPARTNEROIB = this.Columns["PARTNEROIB"];
                this.columnZAPREDUJAM = this.Columns["ZAPREDUJAM"];
            }

            public RACUNDataSet.RACUNRow NewRACUNRow()
            {
                return (RACUNDataSet.RACUNRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RACUNDataSet.RACUNRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RACUNRowChanged != null)
                {
                    RACUNDataSet.RACUNRowChangeEventHandler rACUNRowChangedEvent = this.RACUNRowChanged;
                    if (rACUNRowChangedEvent != null)
                    {
                        rACUNRowChangedEvent(this, new RACUNDataSet.RACUNRowChangeEvent((RACUNDataSet.RACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RACUNRowChanging != null)
                {
                    RACUNDataSet.RACUNRowChangeEventHandler rACUNRowChangingEvent = this.RACUNRowChanging;
                    if (rACUNRowChangingEvent != null)
                    {
                        rACUNRowChangingEvent(this, new RACUNDataSet.RACUNRowChangeEvent((RACUNDataSet.RACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RACUNRowDeleted != null)
                {
                    RACUNDataSet.RACUNRowChangeEventHandler rACUNRowDeletedEvent = this.RACUNRowDeleted;
                    if (rACUNRowDeletedEvent != null)
                    {
                        rACUNRowDeletedEvent(this, new RACUNDataSet.RACUNRowChangeEvent((RACUNDataSet.RACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RACUNRowDeleting != null)
                {
                    RACUNDataSet.RACUNRowChangeEventHandler rACUNRowDeletingEvent = this.RACUNRowDeleting;
                    if (rACUNRowDeletingEvent != null)
                    {
                        rACUNRowDeletingEvent(this, new RACUNDataSet.RACUNRowChangeEvent((RACUNDataSet.RACUNRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRACUNRow(RACUNDataSet.RACUNRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJRACUNAColumn
            {
                get
                {
                    return this.columnBROJRACUNA;
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

            public DataColumn DATUMColumn
            {
                get
                {
                    return this.columnDATUM;
                }
            }

            public DataColumn IDPARTNERColumn
            {
                get
                {
                    return this.columnIDPARTNER;
                }
            }

            public DataColumn IDRACUNColumn
            {
                get
                {
                    return this.columnIDRACUN;
                }
            }

            public RACUNDataSet.RACUNRow this[int index]
            {
                get
                {
                    return (RACUNDataSet.RACUNRow) this.Rows[index];
                }
            }

            public DataColumn MBColumn
            {
                get
                {
                    return this.columnMB;
                }
            }

            public DataColumn MODELColumn
            {
                get
                {
                    return this.columnMODEL;
                }
            }

            public DataColumn NAPOMENAColumn
            {
                get
                {
                    return this.columnNAPOMENA;
                }
            }

            public DataColumn NAZIVPARTNERColumn
            {
                get
                {
                    return this.columnNAZIVPARTNER;
                }
            }

            public DataColumn PARTNEREMAILColumn
            {
                get
                {
                    return this.columnPARTNEREMAIL;
                }
            }

            public DataColumn PARTNERMJESTOColumn
            {
                get
                {
                    return this.columnPARTNERMJESTO;
                }
            }

            public DataColumn PARTNEROIBColumn
            {
                get
                {
                    return this.columnPARTNEROIB;
                }
            }

            public DataColumn PARTNERULICAColumn
            {
                get
                {
                    return this.columnPARTNERULICA;
                }
            }

            public DataColumn POZIVColumn
            {
                get
                {
                    return this.columnPOZIV;
                }
            }

            public DataColumn RACUNGODINAIDGODINEColumn
            {
                get
                {
                    return this.columnRACUNGODINAIDGODINE;
                }
            }

            public DataColumn RAZDOBLJEDOColumn
            {
                get
                {
                    return this.columnRAZDOBLJEDO;
                }
            }

            public DataColumn RAZDOBLJEODColumn
            {
                get
                {
                    return this.columnRAZDOBLJEOD;
                }
            }

            public DataColumn SLOVIMAColumn
            {
                get
                {
                    return this.columnSLOVIMA;
                }
            }

            public DataColumn SVEUKUPNOColumn
            {
                get
                {
                    return this.columnSVEUKUPNO;
                }
            }

            public DataColumn UKUPNOOSNOVICAColumn
            {
                get
                {
                    return this.columnUKUPNOOSNOVICA;
                }
            }

            public DataColumn UKUPNOPDVColumn
            {
                get
                {
                    return this.columnUKUPNOPDV;
                }
            }

            public DataColumn VALUTAColumn
            {
                get
                {
                    return this.columnVALUTA;
                }
            }

            public DataColumn ZAPREDUJAMColumn
            {
                get
                {
                    return this.columnZAPREDUJAM;
                }
            }

            public DataColumn VrstaColumn
            {
                get
                {
                    return this.columnVrsta;
                }
            }

            public DataColumn UkupanznosColumn
            {
                get
                {
                    return this.columnUkupanIznos;
                }
            }
        }

        [Serializable]
        public class RACUNRacunStavkeDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJSTAVKE;
            private DataColumn columnCIJENA;
            private DataColumn columnCIJENARACUN;
            private DataColumn columnFINPOREZSTOPA;
            private DataColumn columnFINPOREZSTOPARACUN;
            private DataColumn columnIDJEDINICAMJERE;
            private DataColumn columnIDPROIZVOD;
            private DataColumn columnIDRACUN;
            private DataColumn columnIZNOSMINUSRABAT;
            private DataColumn columnIZNOSPLUSPDV;
            private DataColumn columnIZNOSRABATA;
            private DataColumn columnIZNOSRACUN;
            private DataColumn columnKOLICINA;
            private DataColumn columnNAZIVJEDINICAMJERE;
            private DataColumn columnNAZIVPROIZVOD;
            private DataColumn columnNAZIVPROIZVODRACUN;
            private DataColumn columnOSNOVICAUKNIZIIRA;
            private DataColumn columnPDV;
            private DataColumn columnRABAT;
            private DataColumn columnCijenaPDV;
            private DataColumn columnRACUNGODINAIDGODINE;

            public event RACUNDataSet.RACUNRacunStavkeRowChangeEventHandler RACUNRacunStavkeRowChanged;

            public event RACUNDataSet.RACUNRacunStavkeRowChangeEventHandler RACUNRacunStavkeRowChanging;

            public event RACUNDataSet.RACUNRacunStavkeRowChangeEventHandler RACUNRacunStavkeRowDeleted;

            public event RACUNDataSet.RACUNRacunStavkeRowChangeEventHandler RACUNRacunStavkeRowDeleting;

            public RACUNRacunStavkeDataTable()
            {
                this.TableName = "RACUNRacunStavke";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RACUNRacunStavkeDataTable(DataTable table) : base(table.TableName)
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

            protected RACUNRacunStavkeDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRACUNRacunStavkeRow(RACUNDataSet.RACUNRacunStavkeRow row)
            {
                this.Rows.Add(row);
            }

            public RACUNDataSet.RACUNRacunStavkeRow AddRACUNRacunStavkeRow(int iDRACUN, short rACUNGODINAIDGODINE, int bROJSTAVKE, int iDPROIZVOD, string nAZIVPROIZVODRACUN, decimal cIJENARACUN, decimal rABAT, decimal kOLICINA, decimal fINPOREZSTOPARACUN)
            {
                RACUNDataSet.RACUNRacunStavkeRow row = (RACUNDataSet.RACUNRacunStavkeRow) this.NewRow();
                row["IDRACUN"] = iDRACUN;
                row["RACUNGODINAIDGODINE"] = rACUNGODINAIDGODINE;
                row["BROJSTAVKE"] = bROJSTAVKE;
                row["IDPROIZVOD"] = iDPROIZVOD;
                row["NAZIVPROIZVODRACUN"] = nAZIVPROIZVODRACUN;
                row["CIJENARACUN"] = cIJENARACUN;
                row["RABAT"] = rABAT;
                row["KOLICINA"] = kOLICINA;
                row["FINPOREZSTOPARACUN"] = fINPOREZSTOPARACUN;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RACUNDataSet.RACUNRacunStavkeDataTable table = (RACUNDataSet.RACUNRacunStavkeDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RACUNDataSet.RACUNRacunStavkeRow FindByIDRACUNRACUNGODINAIDGODINEBROJSTAVKE(int iDRACUN, short rACUNGODINAIDGODINE, int bROJSTAVKE)
            {
                return (RACUNDataSet.RACUNRacunStavkeRow) this.Rows.Find(new object[] { iDRACUN, rACUNGODINAIDGODINE, bROJSTAVKE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RACUNDataSet.RACUNRacunStavkeRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RACUNDataSet set = new RACUNDataSet();
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
                this.columnIDRACUN = new DataColumn("IDRACUN", typeof(int), "", MappingType.Element);
                this.columnIDRACUN.AllowDBNull = false;
                this.columnIDRACUN.Caption = "IDRACUN";
                this.columnIDRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRACUN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRACUN.ExtendedProperties.Add("Description", "Račun");
                this.columnIDRACUN.ExtendedProperties.Add("Length", "6");
                this.columnIDRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDRACUN");
                this.Columns.Add(this.columnIDRACUN);
                this.columnRACUNGODINAIDGODINE = new DataColumn("RACUNGODINAIDGODINE", typeof(short), "", MappingType.Element);
                this.columnRACUNGODINAIDGODINE.AllowDBNull = false;
                this.columnRACUNGODINAIDGODINE.Caption = "IDGODINE";
                this.columnRACUNGODINAIDGODINE.DefaultValue = mipsed.application.framework.Application.ActiveYear;
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("SuperType", "IDGODINE");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("SubtypeGroup", "RACUNGODINA");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("IsKey", "true");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Description", "IDGODINE");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRACUNGODINAIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "RACUNGODINAIDGODINE");
                this.Columns.Add(this.columnRACUNGODINAIDGODINE);
                this.columnBROJSTAVKE = new DataColumn("BROJSTAVKE", typeof(int), "", MappingType.Element);
                this.columnBROJSTAVKE.AllowDBNull = false;
                this.columnBROJSTAVKE.Caption = "BROJSTAVKE";
                this.columnBROJSTAVKE.AutoIncrement = true;
                this.columnBROJSTAVKE.AutoIncrementSeed = -1L;
                this.columnBROJSTAVKE.AutoIncrementStep = -1L;
                this.columnBROJSTAVKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJSTAVKE.ExtendedProperties.Add("AutoNumber", "true");
                this.columnBROJSTAVKE.ExtendedProperties.Add("IsKey", "true");
                this.columnBROJSTAVKE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBROJSTAVKE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Description", "Stavka");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Length", "6");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJSTAVKE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.InternalName", "BROJSTAVKE");
                this.Columns.Add(this.columnBROJSTAVKE);
                this.columnIDPROIZVOD = new DataColumn("IDPROIZVOD", typeof(int), "", MappingType.Element);
                this.columnIDPROIZVOD.AllowDBNull = false;
                this.columnIDPROIZVOD.Caption = "IDPROIZVOD";
                this.columnIDPROIZVOD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPROIZVOD.ExtendedProperties.Add("IsKey", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Description", "Šif. pro");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Length", "5");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPROIZVOD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.InternalName", "IDPROIZVOD");
                this.Columns.Add(this.columnIDPROIZVOD);
                this.columnNAZIVPROIZVOD = new DataColumn("NAZIVPROIZVOD", typeof(string), "", MappingType.Element);
                this.columnNAZIVPROIZVOD.AllowDBNull = true;
                this.columnNAZIVPROIZVOD.Caption = "NAZIVPROIZVOD";
                this.columnNAZIVPROIZVOD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Description", "Proizvod");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Length", "500");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPROIZVOD");
                this.Columns.Add(this.columnNAZIVPROIZVOD);
                this.columnNAZIVPROIZVODRACUN = new DataColumn("NAZIVPROIZVODRACUN", typeof(string), "", MappingType.Element);
                this.columnNAZIVPROIZVODRACUN.AllowDBNull = false;
                this.columnNAZIVPROIZVODRACUN.Caption = "NAZIVPROIZVODRACUN";
                this.columnNAZIVPROIZVODRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("Description", "Proizvod");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("Length", "500");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPROIZVODRACUN.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPROIZVODRACUN");
                this.Columns.Add(this.columnNAZIVPROIZVODRACUN);
                this.columnCIJENA = new DataColumn("CIJENA", typeof(decimal), "", MappingType.Element);
                this.columnCIJENA.AllowDBNull = true;
                this.columnCIJENA.Caption = "CIJENA";
                this.columnCIJENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnCIJENA.ExtendedProperties.Add("IsKey", "false");
                this.columnCIJENA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnCIJENA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnCIJENA.ExtendedProperties.Add("Description", "CIJENA");
                this.columnCIJENA.ExtendedProperties.Add("Length", "9");
                this.columnCIJENA.ExtendedProperties.Add("Decimals", "4");
                this.columnCIJENA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.InternalName", "CIJENA");
                this.Columns.Add(this.columnCIJENA);
                this.columnCIJENARACUN = new DataColumn("CIJENARACUN", typeof(decimal), "", MappingType.Element);
                this.columnCIJENARACUN.AllowDBNull = false;
                this.columnCIJENARACUN.Caption = "CIJENARACUN";
                this.columnCIJENARACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnCIJENARACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnCIJENARACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnCIJENARACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnCIJENARACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnCIJENARACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnCIJENARACUN.ExtendedProperties.Add("IsKey", "false");
                this.columnCIJENARACUN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnCIJENARACUN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnCIJENARACUN.ExtendedProperties.Add("Description", "Cijena");
                this.columnCIJENARACUN.ExtendedProperties.Add("Length", "9");
                this.columnCIJENARACUN.ExtendedProperties.Add("Decimals", "4");
                this.columnCIJENARACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnCIJENARACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnCIJENARACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnCIJENARACUN.ExtendedProperties.Add("Deklarit.InternalName", "CIJENARACUN");
                this.Columns.Add(this.columnCIJENARACUN);

                this.columnCijenaPDV = new DataColumn("CIjenaPDV", typeof(decimal), "", MappingType.Element);
                this.columnCijenaPDV.AllowDBNull = true;
                this.columnCijenaPDV.Caption = "CijenaPDV";
                this.columnCijenaPDV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnCijenaPDV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnCijenaPDV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnCijenaPDV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnCijenaPDV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnCijenaPDV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnCijenaPDV.ExtendedProperties.Add("IsKey", "false");
                this.columnCijenaPDV.ExtendedProperties.Add("ReadOnly", "false");
                this.columnCijenaPDV.ExtendedProperties.Add("DeklaritType", "int");
                this.columnCijenaPDV.ExtendedProperties.Add("Description", "CijenaPDV");
                this.columnCijenaPDV.ExtendedProperties.Add("Length", "9");
                this.columnCijenaPDV.ExtendedProperties.Add("Decimals", "4");
                this.columnCijenaPDV.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnCijenaPDV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnCijenaPDV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnCijenaPDV.ExtendedProperties.Add("Deklarit.InternalName", "CijenaPDV");
                this.Columns.Add(this.columnCijenaPDV);


                this.columnRABAT = new DataColumn("RABAT", typeof(decimal), "", MappingType.Element);
                this.columnRABAT.AllowDBNull = false;
                this.columnRABAT.Caption = "RABAT";
                this.columnRABAT.DefaultValue = 0;
                this.columnRABAT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRABAT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRABAT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRABAT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRABAT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRABAT.ExtendedProperties.Add("IsKey", "false");
                this.columnRABAT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRABAT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRABAT.ExtendedProperties.Add("Description", "% Rabat");
                this.columnRABAT.ExtendedProperties.Add("Length", "5");
                this.columnRABAT.ExtendedProperties.Add("Decimals", "2");
                this.columnRABAT.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnRABAT.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnRABAT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRABAT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRABAT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRABAT.ExtendedProperties.Add("Deklarit.InternalName", "RABAT");
                this.Columns.Add(this.columnRABAT);
                this.columnKOLICINA = new DataColumn("KOLICINA", typeof(decimal), "", MappingType.Element);
                this.columnKOLICINA.AllowDBNull = false;
                this.columnKOLICINA.Caption = "Količina";
                this.columnKOLICINA.DefaultValue = 1;
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOLICINA.ExtendedProperties.Add("IsKey", "false");
                this.columnKOLICINA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKOLICINA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOLICINA.ExtendedProperties.Add("Description", "Količina");
                this.columnKOLICINA.ExtendedProperties.Add("Length", "12");
                this.columnKOLICINA.ExtendedProperties.Add("Decimals", "2");
                this.columnKOLICINA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOLICINA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOLICINA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.InternalName", "KOLICINA");
                this.Columns.Add(this.columnKOLICINA);
                this.columnFINPOREZSTOPARACUN = new DataColumn("FINPOREZSTOPARACUN", typeof(decimal), "", MappingType.Element);
                this.columnFINPOREZSTOPARACUN.AllowDBNull = false;
                this.columnFINPOREZSTOPARACUN.Caption = "FINPOREZSTOPARACUN";
                this.columnFINPOREZSTOPARACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("IsKey", "false");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("Description", "FINPOREZSTOPARACUN");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("Length", "5");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("Decimals", "2");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnFINPOREZSTOPARACUN.ExtendedProperties.Add("Deklarit.InternalName", "FINPOREZSTOPARACUN");
                this.Columns.Add(this.columnFINPOREZSTOPARACUN);
                this.columnFINPOREZSTOPA = new DataColumn("FINPOREZSTOPA", typeof(decimal), "", MappingType.Element);
                this.columnFINPOREZSTOPA.AllowDBNull = true;
                this.columnFINPOREZSTOPA.Caption = "FINPOREZSTOPA";
                this.columnFINPOREZSTOPA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Description", "FINPOREZSTOPA");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Length", "5");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.InternalName", "FINPOREZSTOPA");
                this.Columns.Add(this.columnFINPOREZSTOPA);
                this.columnIZNOSRACUN = new DataColumn("IZNOSRACUN", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSRACUN.AllowDBNull = true;
                this.columnIZNOSRACUN.Caption = "IZNOSRACUN";
                this.columnIZNOSRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSRACUN.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSRACUN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSRACUN.ExtendedProperties.Add("Description", "Izsno računa");
                this.columnIZNOSRACUN.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSRACUN.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSRACUN.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSRACUN.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSRACUN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSRACUN");
                this.Columns.Add(this.columnIZNOSRACUN);
                this.columnIZNOSRABATA = new DataColumn("IZNOSRABATA", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSRABATA.AllowDBNull = true;
                this.columnIZNOSRABATA.Caption = "IZNOSRABATA";
                this.columnIZNOSRABATA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSRABATA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSRABATA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSRABATA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSRABATA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSRABATA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSRABATA.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSRABATA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSRABATA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSRABATA.ExtendedProperties.Add("Description", "Iznos rabata");
                this.columnIZNOSRABATA.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSRABATA.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSRABATA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSRABATA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSRABATA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSRABATA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSRABATA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSRABATA.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSRABATA");
                this.Columns.Add(this.columnIZNOSRABATA);
                this.columnIZNOSMINUSRABAT = new DataColumn("IZNOSMINUSRABAT", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSMINUSRABAT.AllowDBNull = true;
                this.columnIZNOSMINUSRABAT.Caption = "IZNOSMINUSRABAT";
                this.columnIZNOSMINUSRABAT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("Description", "Iznos sa rabatom");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSMINUSRABAT");
                this.columnIZNOSMINUSRABAT.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnIZNOSMINUSRABAT);
                this.columnPDV = new DataColumn("PDV", typeof(decimal), "", MappingType.Element);
                this.columnPDV.AllowDBNull = true;
                this.columnPDV.Caption = "PDV";
                this.columnPDV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDV.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV.ExtendedProperties.Add("Description", "PDV");
                this.columnPDV.ExtendedProperties.Add("Length", "12");
                this.columnPDV.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV.ExtendedProperties.Add("Deklarit.InternalName", "PDV");
                this.Columns.Add(this.columnPDV);
                this.columnIZNOSPLUSPDV = new DataColumn("IZNOSPLUSPDV", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSPLUSPDV.AllowDBNull = true;
                this.columnIZNOSPLUSPDV.Caption = "IZNOSPLUSPDV";
                this.columnIZNOSPLUSPDV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("Description", "Iznos sa Pdv-om");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSPLUSPDV");
                this.columnIZNOSPLUSPDV.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnIZNOSPLUSPDV);
                this.columnIDJEDINICAMJERE = new DataColumn("IDJEDINICAMJERE", typeof(int), "", MappingType.Element);
                this.columnIDJEDINICAMJERE.AllowDBNull = true;
                this.columnIDJEDINICAMJERE.Caption = "IDJEDINICAMJERE";
                this.columnIDJEDINICAMJERE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Description", "Šif. jed.mje.");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Length", "5");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.InternalName", "IDJEDINICAMJERE");
                this.Columns.Add(this.columnIDJEDINICAMJERE);
                this.columnNAZIVJEDINICAMJERE = new DataColumn("NAZIVJEDINICAMJERE", typeof(string), "", MappingType.Element);
                this.columnNAZIVJEDINICAMJERE.AllowDBNull = true;
                this.columnNAZIVJEDINICAMJERE.Caption = "NAZIVJEDINICAMJERE";
                this.columnNAZIVJEDINICAMJERE.MaxLength = 50;
                this.columnNAZIVJEDINICAMJERE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Description", "Jed mjere");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVJEDINICAMJERE");
                this.Columns.Add(this.columnNAZIVJEDINICAMJERE);
                this.columnOSNOVICAUKNIZIIRA = new DataColumn("OSNOVICAUKNIZIIRA", typeof(int), "", MappingType.Element);
                this.columnOSNOVICAUKNIZIIRA.AllowDBNull = true;
                this.columnOSNOVICAUKNIZIIRA.Caption = "OSNOVICAUKNIZIIRA";
                this.columnOSNOVICAUKNIZIIRA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Description", "OSNOVICAUKNIZIIRA");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Length", "5");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Decimals", "0");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAUKNIZIIRA");
                this.Columns.Add(this.columnOSNOVICAUKNIZIIRA);
                this.PrimaryKey = new DataColumn[] { this.columnIDRACUN, this.columnRACUNGODINAIDGODINE, this.columnBROJSTAVKE };
                this.ExtendedProperties.Add("ParentLvl", "RACUN");
                this.ExtendedProperties.Add("LevelName", "RacunStavke");
                this.ExtendedProperties.Add("Description", "Stavke racuna");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDRACUN = this.Columns["IDRACUN"];
                this.columnRACUNGODINAIDGODINE = this.Columns["RACUNGODINAIDGODINE"];
                this.columnBROJSTAVKE = this.Columns["BROJSTAVKE"];
                this.columnIDPROIZVOD = this.Columns["IDPROIZVOD"];
                this.columnNAZIVPROIZVOD = this.Columns["NAZIVPROIZVOD"];
                this.columnNAZIVPROIZVODRACUN = this.Columns["NAZIVPROIZVODRACUN"];
                this.columnCIJENA = this.Columns["CIJENA"];
                this.columnCIJENARACUN = this.Columns["CIJENARACUN"];
                this.columnCijenaPDV = this.Columns["CijenaPDV"];
                this.columnRABAT = this.Columns["RABAT"];
                this.columnKOLICINA = this.Columns["KOLICINA"];
                this.columnFINPOREZSTOPARACUN = this.Columns["FINPOREZSTOPARACUN"];
                this.columnFINPOREZSTOPA = this.Columns["FINPOREZSTOPA"];
                this.columnIZNOSRACUN = this.Columns["IZNOSRACUN"];
                this.columnIZNOSRABATA = this.Columns["IZNOSRABATA"];
                this.columnIZNOSMINUSRABAT = this.Columns["IZNOSMINUSRABAT"];
                this.columnPDV = this.Columns["PDV"];
                this.columnIZNOSPLUSPDV = this.Columns["IZNOSPLUSPDV"];
                this.columnIDJEDINICAMJERE = this.Columns["IDJEDINICAMJERE"];
                this.columnNAZIVJEDINICAMJERE = this.Columns["NAZIVJEDINICAMJERE"];
                this.columnOSNOVICAUKNIZIIRA = this.Columns["OSNOVICAUKNIZIIRA"];
            }

            public RACUNDataSet.RACUNRacunStavkeRow NewRACUNRacunStavkeRow()
            {
                return (RACUNDataSet.RACUNRacunStavkeRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RACUNDataSet.RACUNRacunStavkeRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RACUNRacunStavkeRowChanged != null)
                {
                    RACUNDataSet.RACUNRacunStavkeRowChangeEventHandler rACUNRacunStavkeRowChangedEvent = this.RACUNRacunStavkeRowChanged;
                    if (rACUNRacunStavkeRowChangedEvent != null)
                    {
                        rACUNRacunStavkeRowChangedEvent(this, new RACUNDataSet.RACUNRacunStavkeRowChangeEvent((RACUNDataSet.RACUNRacunStavkeRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RACUNRacunStavkeRowChanging != null)
                {
                    RACUNDataSet.RACUNRacunStavkeRowChangeEventHandler rACUNRacunStavkeRowChangingEvent = this.RACUNRacunStavkeRowChanging;
                    if (rACUNRacunStavkeRowChangingEvent != null)
                    {
                        rACUNRacunStavkeRowChangingEvent(this, new RACUNDataSet.RACUNRacunStavkeRowChangeEvent((RACUNDataSet.RACUNRacunStavkeRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("RACUN_RACUNRacunStavke", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.RACUNRacunStavkeRowDeleted != null)
                {
                    RACUNDataSet.RACUNRacunStavkeRowChangeEventHandler rACUNRacunStavkeRowDeletedEvent = this.RACUNRacunStavkeRowDeleted;
                    if (rACUNRacunStavkeRowDeletedEvent != null)
                    {
                        rACUNRacunStavkeRowDeletedEvent(this, new RACUNDataSet.RACUNRacunStavkeRowChangeEvent((RACUNDataSet.RACUNRacunStavkeRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RACUNRacunStavkeRowDeleting != null)
                {
                    RACUNDataSet.RACUNRacunStavkeRowChangeEventHandler rACUNRacunStavkeRowDeletingEvent = this.RACUNRacunStavkeRowDeleting;
                    if (rACUNRacunStavkeRowDeletingEvent != null)
                    {
                        rACUNRacunStavkeRowDeletingEvent(this, new RACUNDataSet.RACUNRacunStavkeRowChangeEvent((RACUNDataSet.RACUNRacunStavkeRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRACUNRacunStavkeRow(RACUNDataSet.RACUNRacunStavkeRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJSTAVKEColumn
            {
                get
                {
                    return this.columnBROJSTAVKE;
                }
            }

            public DataColumn CIJENAColumn
            {
                get
                {
                    return this.columnCIJENA;
                }
            }

            public DataColumn CIJENARACUNColumn
            {
                get
                {
                    return this.columnCIJENARACUN;
                }
            }


            public DataColumn CijenaPDVColumn
            {
                get
                {
                    return this.columnCijenaPDV;
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

            public DataColumn FINPOREZSTOPAColumn
            {
                get
                {
                    return this.columnFINPOREZSTOPA;
                }
            }

            public DataColumn FINPOREZSTOPARACUNColumn
            {
                get
                {
                    return this.columnFINPOREZSTOPARACUN;
                }
            }

            public DataColumn IDJEDINICAMJEREColumn
            {
                get
                {
                    return this.columnIDJEDINICAMJERE;
                }
            }

            public DataColumn IDPROIZVODColumn
            {
                get
                {
                    return this.columnIDPROIZVOD;
                }
            }

            public DataColumn IDRACUNColumn
            {
                get
                {
                    return this.columnIDRACUN;
                }
            }

            public RACUNDataSet.RACUNRacunStavkeRow this[int index]
            {
                get
                {
                    return (RACUNDataSet.RACUNRacunStavkeRow) this.Rows[index];
                }
            }

            public DataColumn IZNOSMINUSRABATColumn
            {
                get
                {
                    return this.columnIZNOSMINUSRABAT;
                }
            }

            public DataColumn IZNOSPLUSPDVColumn
            {
                get
                {
                    return this.columnIZNOSPLUSPDV;
                }
            }

            public DataColumn IZNOSRABATAColumn
            {
                get
                {
                    return this.columnIZNOSRABATA;
                }
            }

            public DataColumn IZNOSRACUNColumn
            {
                get
                {
                    return this.columnIZNOSRACUN;
                }
            }

            public DataColumn KOLICINAColumn
            {
                get
                {
                    return this.columnKOLICINA;
                }
            }

            public DataColumn NAZIVJEDINICAMJEREColumn
            {
                get
                {
                    return this.columnNAZIVJEDINICAMJERE;
                }
            }

            public DataColumn NAZIVPROIZVODColumn
            {
                get
                {
                    return this.columnNAZIVPROIZVOD;
                }
            }

            public DataColumn NAZIVPROIZVODRACUNColumn
            {
                get
                {
                    return this.columnNAZIVPROIZVODRACUN;
                }
            }

            public DataColumn OSNOVICAUKNIZIIRAColumn
            {
                get
                {
                    return this.columnOSNOVICAUKNIZIIRA;
                }
            }

            public DataColumn PDVColumn
            {
                get
                {
                    return this.columnPDV;
                }
            }

            public DataColumn RABATColumn
            {
                get
                {
                    return this.columnRABAT;
                }
            }

            public DataColumn RACUNGODINAIDGODINEColumn
            {
                get
                {
                    return this.columnRACUNGODINAIDGODINE;
                }
            }
        }

        public class RACUNRacunStavkeRow : DataRow
        {
            private RACUNDataSet.RACUNRacunStavkeDataTable tableRACUNRacunStavke;

            internal RACUNRacunStavkeRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRACUNRacunStavke = (RACUNDataSet.RACUNRacunStavkeDataTable) this.Table;
                this.RACUNGODINAIDGODINE = mipsed.application.framework.Application.ActiveYear;
            }

            public RACUNDataSet.RACUNRow GetRACUNRow()
            {
                return (RACUNDataSet.RACUNRow) this.GetParentRow("RACUN_RACUNRacunStavke");
            }

            public bool IsBROJSTAVKENull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.BROJSTAVKEColumn);
            }

            public bool IsCIJENANull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.CIJENAColumn);
            }

            public bool IsCIJENARACUNNull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.CIJENARACUNColumn);
            }

            public bool IsFINPOREZSTOPANull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.FINPOREZSTOPAColumn);
            }

            public bool IsFINPOREZSTOPARACUNNull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.FINPOREZSTOPARACUNColumn);
            }

            public bool IsIDJEDINICAMJERENull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.IDJEDINICAMJEREColumn);
            }

            public bool IsIDPROIZVODNull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.IDPROIZVODColumn);
            }

            public bool IsIDRACUNNull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.IDRACUNColumn);
            }

            public bool IsIZNOSMINUSRABATNull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.IZNOSMINUSRABATColumn);
            }

            public bool IsIZNOSPLUSPDVNull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.IZNOSPLUSPDVColumn);
            }

            public bool IsIZNOSRABATANull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.IZNOSRABATAColumn);
            }

            public bool IsIZNOSRACUNNull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.IZNOSRACUNColumn);
            }

            public bool IsKOLICINANull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.KOLICINAColumn);
            }

            public bool IsNAZIVJEDINICAMJERENull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.NAZIVJEDINICAMJEREColumn);
            }

            public bool IsNAZIVPROIZVODNull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.NAZIVPROIZVODColumn);
            }

            public bool IsNAZIVPROIZVODRACUNNull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.NAZIVPROIZVODRACUNColumn);
            }

            public bool IsOSNOVICAUKNIZIIRANull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.OSNOVICAUKNIZIIRAColumn);
            }

            public bool IsPDVNull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.PDVColumn);
            }

            public bool IsRABATNull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.RABATColumn);
            }

            public bool IsRACUNGODINAIDGODINENull()
            {
                return this.IsNull(this.tableRACUNRacunStavke.RACUNGODINAIDGODINEColumn);
            }

            public void SetCIJENANull()
            {
                this[this.tableRACUNRacunStavke.CIJENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetCIJENARACUNNull()
            {
                this[this.tableRACUNRacunStavke.CIJENARACUNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFINPOREZSTOPANull()
            {
                this[this.tableRACUNRacunStavke.FINPOREZSTOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFINPOREZSTOPARACUNNull()
            {
                this[this.tableRACUNRacunStavke.FINPOREZSTOPARACUNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDJEDINICAMJERENull()
            {
                this[this.tableRACUNRacunStavke.IDJEDINICAMJEREColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDPROIZVODNull()
            {
                this[this.tableRACUNRacunStavke.IDPROIZVODColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSMINUSRABATNull()
            {
                this[this.tableRACUNRacunStavke.IZNOSMINUSRABATColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSPLUSPDVNull()
            {
                this[this.tableRACUNRacunStavke.IZNOSPLUSPDVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSRABATANull()
            {
                this[this.tableRACUNRacunStavke.IZNOSRABATAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSRACUNNull()
            {
                this[this.tableRACUNRacunStavke.IZNOSRACUNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOLICINANull()
            {
                this[this.tableRACUNRacunStavke.KOLICINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVJEDINICAMJERENull()
            {
                this[this.tableRACUNRacunStavke.NAZIVJEDINICAMJEREColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPROIZVODNull()
            {
                this[this.tableRACUNRacunStavke.NAZIVPROIZVODColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPROIZVODRACUNNull()
            {
                this[this.tableRACUNRacunStavke.NAZIVPROIZVODRACUNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAUKNIZIIRANull()
            {
                this[this.tableRACUNRacunStavke.OSNOVICAUKNIZIIRAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDVNull()
            {
                this[this.tableRACUNRacunStavke.PDVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRABATNull()
            {
                this[this.tableRACUNRacunStavke.RABATColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BROJSTAVKE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRACUNRacunStavke.BROJSTAVKEColumn]);
                }
                set
                {
                    this[this.tableRACUNRacunStavke.BROJSTAVKEColumn] = value;
                }
            }

            public decimal CIJENA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUNRacunStavke.CIJENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.CIJENAColumn] = value;
                }
            }

            public decimal CIJENARACUN
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUNRacunStavke.CIJENARACUNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.CIJENARACUNColumn] = value;
                }
            }

            public decimal CijenaPDV
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUNRacunStavke.CijenaPDVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.CijenaPDVColumn] = value;
                }
            }

            public decimal FINPOREZSTOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUNRacunStavke.FINPOREZSTOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.FINPOREZSTOPAColumn] = value;
                }
            }

            public decimal FINPOREZSTOPARACUN
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUNRacunStavke.FINPOREZSTOPARACUNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.FINPOREZSTOPARACUNColumn] = value;
                }
            }

            public int IDJEDINICAMJERE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRACUNRacunStavke.IDJEDINICAMJEREColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.IDJEDINICAMJEREColumn] = value;
                }
            }

            public int IDPROIZVOD
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRACUNRacunStavke.IDPROIZVODColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.IDPROIZVODColumn] = value;
                }
            }

            public int IDRACUN
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRACUNRacunStavke.IDRACUNColumn]);
                }
                set
                {
                    this[this.tableRACUNRacunStavke.IDRACUNColumn] = value;
                }
            }

            public decimal IZNOSMINUSRABAT
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUNRacunStavke.IZNOSMINUSRABATColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.IZNOSMINUSRABATColumn] = value;
                }
            }

            public decimal IZNOSPLUSPDV
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUNRacunStavke.IZNOSPLUSPDVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.IZNOSPLUSPDVColumn] = value;
                }
            }

            public decimal IZNOSRABATA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUNRacunStavke.IZNOSRABATAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.IZNOSRABATAColumn] = value;
                }
            }

            public decimal IZNOSRACUN
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUNRacunStavke.IZNOSRACUNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.IZNOSRACUNColumn] = value;
                }
            }

            public decimal KOLICINA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUNRacunStavke.KOLICINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.KOLICINAColumn] = value;
                }
            }

            public string NAZIVJEDINICAMJERE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUNRacunStavke.NAZIVJEDINICAMJEREColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.NAZIVJEDINICAMJEREColumn] = value;
                }
            }

            public string NAZIVPROIZVOD
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUNRacunStavke.NAZIVPROIZVODColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.NAZIVPROIZVODColumn] = value;
                }
            }

            public string NAZIVPROIZVODRACUN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUNRacunStavke.NAZIVPROIZVODRACUNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.NAZIVPROIZVODRACUNColumn] = value;
                }
            }

            public int OSNOVICAUKNIZIIRA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRACUNRacunStavke.OSNOVICAUKNIZIIRAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.OSNOVICAUKNIZIIRAColumn] = value;
                }
            }

            public decimal PDV
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUNRacunStavke.PDVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.PDVColumn] = value;
                }
            }

            public decimal RABAT
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUNRacunStavke.RABATColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUNRacunStavke.RABATColumn] = value;
                }
            }

            public short RACUNGODINAIDGODINE
            {
                get
                {
                    return Conversions.ToShort(this[this.tableRACUNRacunStavke.RACUNGODINAIDGODINEColumn]);
                }
                set
                {
                    this[this.tableRACUNRacunStavke.RACUNGODINAIDGODINEColumn] = value;
                }
            }
        }

        public class RACUNRacunStavkeRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RACUNDataSet.RACUNRacunStavkeRow eventRow;

            public RACUNRacunStavkeRowChangeEvent(RACUNDataSet.RACUNRacunStavkeRow row, DataRowAction action)
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

            public RACUNDataSet.RACUNRacunStavkeRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RACUNRacunStavkeRowChangeEventHandler(object sender, RACUNDataSet.RACUNRacunStavkeRowChangeEvent e);

        public class RACUNRow : DataRow
        {
            private RACUNDataSet.RACUNDataTable tableRACUN;

            internal RACUNRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRACUN = (RACUNDataSet.RACUNDataTable) this.Table;
                this.RACUNGODINAIDGODINE = mipsed.application.framework.Application.ActiveYear;
            }

            public RACUNDataSet.RACUNRacunStavkeRow[] GetRACUNRacunStavkeRows()
            {
                return (RACUNDataSet.RACUNRacunStavkeRow[]) this.GetChildRows("RACUN_RACUNRacunStavke");
            }

            public bool IsBROJRACUNANull()
            {
                return this.IsNull(this.tableRACUN.BROJRACUNAColumn);
            }

            public bool IsDATUMNull()
            {
                return this.IsNull(this.tableRACUN.DATUMColumn);
            }

            public bool IsIDPARTNERNull()
            {
                return this.IsNull(this.tableRACUN.IDPARTNERColumn);
            }

            public bool IsIDRACUNNull()
            {
                return this.IsNull(this.tableRACUN.IDRACUNColumn);
            }

            public bool IsMBNull()
            {
                return this.IsNull(this.tableRACUN.MBColumn);
            }

            public bool IsMODELNull()
            {
                return this.IsNull(this.tableRACUN.MODELColumn);
            }

            public bool IsNAPOMENANull()
            {
                return this.IsNull(this.tableRACUN.NAPOMENAColumn);
            }

            public bool IsNAZIVPARTNERNull()
            {
                return this.IsNull(this.tableRACUN.NAZIVPARTNERColumn);
            }

            public bool IsPARTNEREMAILNull()
            {
                return this.IsNull(this.tableRACUN.PARTNEREMAILColumn);
            }

            public bool IsPARTNERMJESTONull()
            {
                return this.IsNull(this.tableRACUN.PARTNERMJESTOColumn);
            }

            public bool IsPARTNEROIBNull()
            {
                return this.IsNull(this.tableRACUN.PARTNEROIBColumn);
            }

            public bool IsPARTNERULICANull()
            {
                return this.IsNull(this.tableRACUN.PARTNERULICAColumn);
            }

            public bool IsPOZIVNull()
            {
                return this.IsNull(this.tableRACUN.POZIVColumn);
            }

            public bool IsRACUNGODINAIDGODINENull()
            {
                return this.IsNull(this.tableRACUN.RACUNGODINAIDGODINEColumn);
            }

            public bool IsRAZDOBLJEDONull()
            {
                return this.IsNull(this.tableRACUN.RAZDOBLJEDOColumn);
            }

            public bool IsRAZDOBLJEODNull()
            {
                return this.IsNull(this.tableRACUN.RAZDOBLJEODColumn);
            }

            public bool IsSLOVIMANull()
            {
                return this.IsNull(this.tableRACUN.SLOVIMAColumn);
            }

            public bool IsSVEUKUPNONull()
            {
                return this.IsNull(this.tableRACUN.SVEUKUPNOColumn);
            }

            public bool IsUKUPNOOSNOVICANull()
            {
                return this.IsNull(this.tableRACUN.UKUPNOOSNOVICAColumn);
            }

            public bool IsUKUPNOPDVNull()
            {
                return this.IsNull(this.tableRACUN.UKUPNOPDVColumn);
            }

            public bool IsVALUTANull()
            {
                return this.IsNull(this.tableRACUN.VALUTAColumn);
            }

            public bool IsZAPREDUJAMNull()
            {
                return this.IsNull(this.tableRACUN.ZAPREDUJAMColumn);
            }


          
            public void SetBROJRACUNANull()
            {
                this[this.tableRACUN.BROJRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMNull()
            {
                this[this.tableRACUN.DATUMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDPARTNERNull()
            {
                this[this.tableRACUN.IDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMBNull()
            {
                this[this.tableRACUN.MBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMODELNull()
            {
                this[this.tableRACUN.MODELColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAPOMENANull()
            {
                this[this.tableRACUN.NAPOMENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }


            public void SetVrstaNull()
            {
                this[this.tableRACUN.VrstaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPARTNERNull()
            {
                this[this.tableRACUN.NAZIVPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNEREMAILNull()
            {
                this[this.tableRACUN.PARTNEREMAILColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERMJESTONull()
            {
                this[this.tableRACUN.PARTNERMJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNEROIBNull()
            {
                this[this.tableRACUN.PARTNEROIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERULICANull()
            {
                this[this.tableRACUN.PARTNERULICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOZIVNull()
            {
                this[this.tableRACUN.POZIVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRAZDOBLJEDONull()
            {
                this[this.tableRACUN.RAZDOBLJEDOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRAZDOBLJEODNull()
            {
                this[this.tableRACUN.RAZDOBLJEODColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSLOVIMANull()
            {
                this[this.tableRACUN.SLOVIMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSVEUKUPNONull()
            {
                this[this.tableRACUN.SVEUKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }


            public void SetUkupanIznosNull()
            {
                this[this.tableRACUN.UkupanznosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOOSNOVICANull()
            {
                this[this.tableRACUN.UKUPNOOSNOVICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOPDVNull()
            {
                this[this.tableRACUN.UKUPNOPDVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVALUTANull()
            {
                this[this.tableRACUN.VALUTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZAPREDUJAMNull()
            {
                this[this.tableRACUN.ZAPREDUJAMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string BROJRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUN.BROJRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUN.BROJRACUNAColumn] = value;
                }
            }

            public DateTime DATUM
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableRACUN.DATUMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableRACUN.DATUMColumn] = value;
                }
            }

            public int IDPARTNER
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRACUN.IDPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUN.IDPARTNERColumn] = value;
                }
            }

            public int IDRACUN
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRACUN.IDRACUNColumn]);
                }
                set
                {
                    this[this.tableRACUN.IDRACUNColumn] = value;
                }
            }

            public string MB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUN.MBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUN.MBColumn] = value;
                }
            }

            public string MODEL
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUN.MODELColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUN.MODELColumn] = value;
                }
            }

            public string NAPOMENA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUN.NAPOMENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUN.NAPOMENAColumn] = value;
                }
            }


            public string Vrsta
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUN.VrstaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUN.VrstaColumn] = value;
                }
            }

            public string NAZIVPARTNER
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUN.NAZIVPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUN.NAZIVPARTNERColumn] = value;
                }
            }

            public string PARTNEREMAIL
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUN.PARTNEREMAILColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                     }
                    return str;
                }
                set
                {
                    this[this.tableRACUN.PARTNEREMAILColumn] = value;
                }
            }

            public string PARTNERMJESTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUN.PARTNERMJESTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUN.PARTNERMJESTOColumn] = value;
                }
            }

            public string PARTNEROIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUN.PARTNEROIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUN.PARTNEROIBColumn] = value;
                }
            }

            public string PARTNERULICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUN.PARTNERULICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUN.PARTNERULICAColumn] = value;
                }
            }

            public string POZIV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUN.POZIVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUN.POZIVColumn] = value;
                }
            }

            public short RACUNGODINAIDGODINE
            {
                get
                {
                    return Conversions.ToShort(this[this.tableRACUN.RACUNGODINAIDGODINEColumn]);
                }
                set
                {
                    this[this.tableRACUN.RACUNGODINAIDGODINEColumn] = value;
                }
            }

            public DateTime RAZDOBLJEDO
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableRACUN.RAZDOBLJEDOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableRACUN.RAZDOBLJEDOColumn] = value;
                }
            }

            public DateTime RAZDOBLJEOD
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableRACUN.RAZDOBLJEODColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableRACUN.RAZDOBLJEODColumn] = value;
                }
            }

            public string SLOVIMA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRACUN.SLOVIMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRACUN.SLOVIMAColumn] = value;
                }
            }

            public decimal SVEUKUPNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUN.SVEUKUPNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUN.SVEUKUPNOColumn] = value;
                }
            }


            public decimal UkupanIznos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUN.UkupanznosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUN.UkupanznosColumn] = value;
                }
            }

            public decimal UKUPNOOSNOVICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUN.UKUPNOOSNOVICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUN.UKUPNOOSNOVICAColumn] = value;
                }
            }

            public decimal UKUPNOPDV
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRACUN.UKUPNOPDVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRACUN.UKUPNOPDVColumn] = value;
                }
            }

            public DateTime VALUTA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableRACUN.VALUTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableRACUN.VALUTAColumn] = value;
                }
            }

            public bool ZAPREDUJAM
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableRACUN.ZAPREDUJAMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableRACUN.ZAPREDUJAMColumn] = value;
                }
            }
        }

        public class RACUNRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RACUNDataSet.RACUNRow eventRow;

            public RACUNRowChangeEvent(RACUNDataSet.RACUNRow row, DataRowAction action)
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

            public RACUNDataSet.RACUNRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RACUNRowChangeEventHandler(object sender, RACUNDataSet.RACUNRowChangeEvent e);
    }
}

