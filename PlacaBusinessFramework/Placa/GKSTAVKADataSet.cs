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
    public class GKSTAVKADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private GKSTAVKADataTable tableGKSTAVKA;

        public GKSTAVKADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected GKSTAVKADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["GKSTAVKA"] != null)
                    {
                        this.Tables.Add(new GKSTAVKADataTable(dataSet.Tables["GKSTAVKA"]));
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
            GKSTAVKADataSet set = (GKSTAVKADataSet) base.Clone();
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
            GKSTAVKADataSet set = new GKSTAVKADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "GKSTAVKADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1005");
            this.ExtendedProperties.Add("DataSetName", "GKSTAVKADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IGKSTAVKADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "GKSTAVKA");
            this.ExtendedProperties.Add("ObjectDescription", "GKSTAVKA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Finpos");
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
            this.DataSetName = "GKSTAVKADataSet";
            this.Namespace = "http://www.tempuri.org/GKSTAVKA";
            this.tableGKSTAVKA = new GKSTAVKADataTable();
            this.Tables.Add(this.tableGKSTAVKA);
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
            this.tableGKSTAVKA = (GKSTAVKADataTable) this.Tables["GKSTAVKA"];
            if (initTable && (this.tableGKSTAVKA != null))
            {
                this.tableGKSTAVKA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["GKSTAVKA"] != null)
                {
                    this.Tables.Add(new GKSTAVKADataTable(dataSet.Tables["GKSTAVKA"]));
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

        private bool ShouldSerializeGKSTAVKA()
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
        public GKSTAVKADataTable GKSTAVKA
        {
            get
            {
                return this.tableGKSTAVKA;
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
        public class GKSTAVKADataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJDOKUMENTA;
            private DataColumn columnBROJSTAVKE;
            private DataColumn columnDATUMDOKUMENTA;
            private DataColumn columnDATUMPRIJAVE;
            private DataColumn columnduguje;
            private DataColumn columnGKDATUMVALUTE;
            private DataColumn columnGKGODIDGODINE;
            private DataColumn columnIDAKTIVNOST;
            private DataColumn columnIDDOKUMENT;
            private DataColumn columnIDGKSTAVKA;
            private DataColumn columnIDKONTO;
            private DataColumn columnIDMJESTOTROSKA;
            private DataColumn columnIDORGJED;
            private DataColumn columnIDPARTNER;
            private DataColumn columnNAZIVAKTIVNOST;
            private DataColumn columnNAZIVDOKUMENT;
            private DataColumn columnNAZIVKONTO;
            private DataColumn columnNAZIVMJESTOTROSKA;
            private DataColumn columnNAZIVORGJED;
            private DataColumn columnNAZIVPARTNER;
            private DataColumn columnOPIS;
            private DataColumn columnORIGINALNIDOKUMENT;
            private DataColumn columnPOTRAZUJE;
            private DataColumn columnstatusgk;
            private DataColumn columnZATVORENIIZNOS;

            public event GKSTAVKADataSet.GKSTAVKARowChangeEventHandler GKSTAVKARowChanged;

            public event GKSTAVKADataSet.GKSTAVKARowChangeEventHandler GKSTAVKARowChanging;

            public event GKSTAVKADataSet.GKSTAVKARowChangeEventHandler GKSTAVKARowDeleted;

            public event GKSTAVKADataSet.GKSTAVKARowChangeEventHandler GKSTAVKARowDeleting;

            public GKSTAVKADataTable()
            {
                this.TableName = "GKSTAVKA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal GKSTAVKADataTable(DataTable table) : base(table.TableName)
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

            protected GKSTAVKADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddGKSTAVKARow(GKSTAVKADataSet.GKSTAVKARow row)
            {
                this.Rows.Add(row);
            }

            public GKSTAVKADataSet.GKSTAVKARow AddGKSTAVKARow(DateTime dATUMDOKUMENTA, int bROJDOKUMENTA, int bROJSTAVKE, int iDDOKUMENT, int iDMJESTOTROSKA, int iDORGJED, string iDKONTO, string oPIS, decimal duguje, decimal pOTRAZUJE, DateTime dATUMPRIJAVE, int iDPARTNER, decimal zATVORENIIZNOS, DateTime gKDATUMVALUTE, bool statusgk, string oRIGINALNIDOKUMENT, short gKGODIDGODINE)
            {
                GKSTAVKADataSet.GKSTAVKARow row = (GKSTAVKADataSet.GKSTAVKARow) this.NewRow();
                row["DATUMDOKUMENTA"] = dATUMDOKUMENTA;
                row["BROJDOKUMENTA"] = bROJDOKUMENTA;
                row["BROJSTAVKE"] = bROJSTAVKE;
                row["IDDOKUMENT"] = iDDOKUMENT;
                row["IDMJESTOTROSKA"] = iDMJESTOTROSKA;
                row["IDORGJED"] = iDORGJED;
                row["IDKONTO"] = iDKONTO;
                row["OPIS"] = oPIS;
                row["duguje"] = duguje;
                row["POTRAZUJE"] = pOTRAZUJE;
                row["DATUMPRIJAVE"] = dATUMPRIJAVE;
                row["IDPARTNER"] = iDPARTNER;
                row["ZATVORENIIZNOS"] = zATVORENIIZNOS;
                row["GKDATUMVALUTE"] = gKDATUMVALUTE;
                row["statusgk"] = statusgk;
                row["ORIGINALNIDOKUMENT"] = oRIGINALNIDOKUMENT;
                row["GKGODIDGODINE"] = gKGODIDGODINE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                GKSTAVKADataSet.GKSTAVKADataTable table = (GKSTAVKADataSet.GKSTAVKADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public GKSTAVKADataSet.GKSTAVKARow FindByIDGKSTAVKA(int iDGKSTAVKA)
            {
                return (GKSTAVKADataSet.GKSTAVKARow) this.Rows.Find(new object[] { iDGKSTAVKA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(GKSTAVKADataSet.GKSTAVKARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                GKSTAVKADataSet set = new GKSTAVKADataSet();
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
                this.columnIDGKSTAVKA = new DataColumn("IDGKSTAVKA", typeof(int), "", MappingType.Element);
                this.columnIDGKSTAVKA.AllowDBNull = false;
                this.columnIDGKSTAVKA.Caption = "IDGKSTAVKA";
                this.columnIDGKSTAVKA.Unique = true;
                this.columnIDGKSTAVKA.AutoIncrement = true;
                this.columnIDGKSTAVKA.AutoIncrementSeed = -1L;
                this.columnIDGKSTAVKA.AutoIncrementStep = -1L;
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("AutoNumber", "true");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Description", "IDGKSTAVKA");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Length", "5");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDGKSTAVKA.ExtendedProperties.Add("Deklarit.InternalName", "IDGKSTAVKA");
                this.Columns.Add(this.columnIDGKSTAVKA);
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
                this.columnIDAKTIVNOST.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Description", "Šifra aktivnosti");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Length", "6");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Decimals", "0");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.InternalName", "IDAKTIVNOST");
                this.Columns.Add(this.columnIDAKTIVNOST);
                this.columnDATUMDOKUMENTA = new DataColumn("DATUMDOKUMENTA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMDOKUMENTA.AllowDBNull = false;
                this.columnDATUMDOKUMENTA.Caption = "DATUMDOKUMENTA";
                this.columnDATUMDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("Description", "Datum");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMDOKUMENTA");
                this.Columns.Add(this.columnDATUMDOKUMENTA);
                this.columnBROJDOKUMENTA = new DataColumn("BROJDOKUMENTA", typeof(int), "", MappingType.Element);
                this.columnBROJDOKUMENTA.AllowDBNull = false;
                this.columnBROJDOKUMENTA.Caption = "BROJDOKUMENTA";
                this.columnBROJDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("Description", "Broj dok.");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("Length", "6");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "BROJDOKUMENTA");
                this.Columns.Add(this.columnBROJDOKUMENTA);
                this.columnBROJSTAVKE = new DataColumn("BROJSTAVKE", typeof(int), "", MappingType.Element);
                this.columnBROJSTAVKE.AllowDBNull = false;
                this.columnBROJSTAVKE.Caption = "BROJSTAVKE";
                this.columnBROJSTAVKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJSTAVKE.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJSTAVKE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBROJSTAVKE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Description", "Stavka");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Length", "6");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJSTAVKE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBROJSTAVKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.InternalName", "BROJSTAVKE");
                this.Columns.Add(this.columnBROJSTAVKE);
                this.columnIDDOKUMENT = new DataColumn("IDDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnIDDOKUMENT.AllowDBNull = false;
                this.columnIDDOKUMENT.Caption = "Šifra dokumenta";
                this.columnIDDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDDOKUMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnIDDOKUMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Description", "Šifra dokumenta");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Length", "8");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDDOKUMENT");
                this.Columns.Add(this.columnIDDOKUMENT);
                this.columnNAZIVDOKUMENT = new DataColumn("NAZIVDOKUMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVDOKUMENT.AllowDBNull = true;
                this.columnNAZIVDOKUMENT.Caption = "Naziv dokumenta";
                this.columnNAZIVDOKUMENT.MaxLength = 50;
                this.columnNAZIVDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Description", "Naziv dokumenta");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVDOKUMENT");
                this.Columns.Add(this.columnNAZIVDOKUMENT);
                this.columnIDMJESTOTROSKA = new DataColumn("IDMJESTOTROSKA", typeof(int), "", MappingType.Element);
                this.columnIDMJESTOTROSKA.AllowDBNull = false;
                this.columnIDMJESTOTROSKA.Caption = "Šifra MT";
                this.columnIDMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Description", "Šifra MT");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Length", "8");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "IDMJESTOTROSKA");
                this.Columns.Add(this.columnIDMJESTOTROSKA);
                this.columnNAZIVMJESTOTROSKA = new DataColumn("NAZIVMJESTOTROSKA", typeof(string), "", MappingType.Element);
                this.columnNAZIVMJESTOTROSKA.AllowDBNull = true;
                this.columnNAZIVMJESTOTROSKA.Caption = "Naziv MT";
                this.columnNAZIVMJESTOTROSKA.MaxLength = 120;
                this.columnNAZIVMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Description", "Naziv MT");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Length", "120");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVMJESTOTROSKA");
                this.Columns.Add(this.columnNAZIVMJESTOTROSKA);
                this.columnIDORGJED = new DataColumn("IDORGJED", typeof(int), "", MappingType.Element);
                this.columnIDORGJED.AllowDBNull = false;
                this.columnIDORGJED.Caption = "Šifra OJ";
                this.columnIDORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDORGJED.ExtendedProperties.Add("IsKey", "false");
                this.columnIDORGJED.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDORGJED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDORGJED.ExtendedProperties.Add("Description", "Šifra OJ");
                this.columnIDORGJED.ExtendedProperties.Add("Length", "8");
                this.columnIDORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnIDORGJED.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDORGJED.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.InternalName", "IDORGJED");
                this.Columns.Add(this.columnIDORGJED);
                this.columnNAZIVORGJED = new DataColumn("NAZIVORGJED", typeof(string), "", MappingType.Element);
                this.columnNAZIVORGJED.AllowDBNull = true;
                this.columnNAZIVORGJED.Caption = "Naziv OJ";
                this.columnNAZIVORGJED.MaxLength = 100;
                this.columnNAZIVORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVORGJED.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVORGJED.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVORGJED.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Description", "Naziv OJ");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVORGJED.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVORGJED.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVORGJED.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVORGJED");
                this.Columns.Add(this.columnNAZIVORGJED);
                this.columnIDKONTO = new DataColumn("IDKONTO", typeof(string), "", MappingType.Element);
                this.columnIDKONTO.AllowDBNull = false;
                this.columnIDKONTO.Caption = "Konto";
                this.columnIDKONTO.MaxLength = 14;
                this.columnIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKONTO.ExtendedProperties.Add("IsKey", "false");
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
                this.columnNAZIVKONTO.MaxLength = 150;
                this.columnNAZIVKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Description", "Naziv konta");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Length", "150");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKONTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKONTO");
                this.Columns.Add(this.columnNAZIVKONTO);
                this.columnNAZIVAKTIVNOST = new DataColumn("NAZIVAKTIVNOST", typeof(string), "", MappingType.Element);
                this.columnNAZIVAKTIVNOST.AllowDBNull = true;
                this.columnNAZIVAKTIVNOST.Caption = "Naziv aktivnosti";
                this.columnNAZIVAKTIVNOST.MaxLength = 50;
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
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVAKTIVNOST");
                this.Columns.Add(this.columnNAZIVAKTIVNOST);
                this.columnOPIS = new DataColumn("OPIS", typeof(string), "", MappingType.Element);
                this.columnOPIS.AllowDBNull = true;
                this.columnOPIS.Caption = "OPIS";
                this.columnOPIS.MaxLength = 150;
                this.columnOPIS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPIS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPIS.ExtendedProperties.Add("IsKey", "false");
                this.columnOPIS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPIS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPIS.ExtendedProperties.Add("Description", "OPIS");
                this.columnOPIS.ExtendedProperties.Add("Length", "150");
                this.columnOPIS.ExtendedProperties.Add("Decimals", "0");
                this.columnOPIS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPIS.ExtendedProperties.Add("RightTrim", "true");
                this.columnOPIS.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.InternalName", "OPIS");
                this.Columns.Add(this.columnOPIS);
                this.columnduguje = new DataColumn("duguje", typeof(decimal), "", MappingType.Element);
                this.columnduguje.AllowDBNull = true;
                this.columnduguje.Caption = "duguje";
                this.columnduguje.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnduguje.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnduguje.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnduguje.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnduguje.ExtendedProperties.Add("Deklarit.InputMask", "0,##");
                this.columnduguje.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnduguje.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnduguje.ExtendedProperties.Add("IsKey", "false");
                this.columnduguje.ExtendedProperties.Add("ReadOnly", "false");
                this.columnduguje.ExtendedProperties.Add("DeklaritType", "int");
                this.columnduguje.ExtendedProperties.Add("Description", "duguje");
                this.columnduguje.ExtendedProperties.Add("Length", "16");
                this.columnduguje.ExtendedProperties.Add("Decimals", "2");
                this.columnduguje.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnduguje.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnduguje.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnduguje.ExtendedProperties.Add("IsInReader", "true");
                this.columnduguje.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnduguje.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnduguje.ExtendedProperties.Add("Deklarit.InternalName", "duguje");
                this.Columns.Add(this.columnduguje);
                this.columnPOTRAZUJE = new DataColumn("POTRAZUJE", typeof(decimal), "", MappingType.Element);
                this.columnPOTRAZUJE.AllowDBNull = true;
                this.columnPOTRAZUJE.Caption = "POTRAZUJE";
                this.columnPOTRAZUJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOTRAZUJE.ExtendedProperties.Add("IsKey", "false");
                this.columnPOTRAZUJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOTRAZUJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Description", "Potražuje");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Length", "16");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Decimals", "2");
                this.columnPOTRAZUJE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOTRAZUJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.InternalName", "POTRAZUJE");
                this.Columns.Add(this.columnPOTRAZUJE);
                this.columnDATUMPRIJAVE = new DataColumn("DATUMPRIJAVE", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMPRIJAVE.AllowDBNull = true;
                this.columnDATUMPRIJAVE.Caption = "DATUMPRIJAVE";
                this.columnDATUMPRIJAVE.DefaultValue = DateTime.Now;
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Description", "DATUMPRIJAVE");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Length", "8");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.InternalName", "DATUMPRIJAVE");
                this.Columns.Add(this.columnDATUMPRIJAVE);
                this.columnIDPARTNER = new DataColumn("IDPARTNER", typeof(int), "", MappingType.Element);
                this.columnIDPARTNER.AllowDBNull = true;
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
                this.columnIDPARTNER.ExtendedProperties.Add("Description", "Šifra partnera");
                this.columnIDPARTNER.ExtendedProperties.Add("Length", "9");
                this.columnIDPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "true");
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
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Description", "Naziv partnera");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPARTNER");
                this.Columns.Add(this.columnNAZIVPARTNER);
                this.columnZATVORENIIZNOS = new DataColumn("ZATVORENIIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnZATVORENIIZNOS.AllowDBNull = true;
                this.columnZATVORENIIZNOS.Caption = "ZATVORENIIZNOS";
                this.columnZATVORENIIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("Description", "Zatvoreni iznos");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("Length", "16");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZATVORENIIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "ZATVORENIIZNOS");
                this.Columns.Add(this.columnZATVORENIIZNOS);
                this.columnGKDATUMVALUTE = new DataColumn("GKDATUMVALUTE", typeof(DateTime), "", MappingType.Element);
                this.columnGKDATUMVALUTE.AllowDBNull = true;
                this.columnGKDATUMVALUTE.Caption = "GKDATUMVALUTE";
                this.columnGKDATUMVALUTE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("IsKey", "false");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("DeklaritType", "date");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("Description", "Valuta");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("Length", "8");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("Decimals", "0");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("IsInReader", "true");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGKDATUMVALUTE.ExtendedProperties.Add("Deklarit.InternalName", "GKDATUMVALUTE");
                this.Columns.Add(this.columnGKDATUMVALUTE);
                this.columnstatusgk = new DataColumn("statusgk", typeof(bool), "", MappingType.Element);
                this.columnstatusgk.AllowDBNull = false;
                this.columnstatusgk.Caption = "statusgk";
                this.columnstatusgk.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnstatusgk.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnstatusgk.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnstatusgk.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnstatusgk.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnstatusgk.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnstatusgk.ExtendedProperties.Add("IsKey", "false");
                this.columnstatusgk.ExtendedProperties.Add("ReadOnly", "false");
                this.columnstatusgk.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnstatusgk.ExtendedProperties.Add("Description", "statusgk");
                this.columnstatusgk.ExtendedProperties.Add("Length", "1");
                this.columnstatusgk.ExtendedProperties.Add("Decimals", "0");
                this.columnstatusgk.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnstatusgk.ExtendedProperties.Add("IsInReader", "true");
                this.columnstatusgk.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnstatusgk.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnstatusgk.ExtendedProperties.Add("Deklarit.InternalName", "statusgk");
                this.Columns.Add(this.columnstatusgk);
                this.columnORIGINALNIDOKUMENT = new DataColumn("ORIGINALNIDOKUMENT", typeof(string), "", MappingType.Element);
                this.columnORIGINALNIDOKUMENT.AllowDBNull = true;
                this.columnORIGINALNIDOKUMENT.Caption = "ORIGINALNIDOKUMENT";
                this.columnORIGINALNIDOKUMENT.MaxLength = 50;
                this.columnORIGINALNIDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Description", "Originalni dokument");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Length", "50");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "ORIGINALNIDOKUMENT");
                this.Columns.Add(this.columnORIGINALNIDOKUMENT);
                this.columnGKGODIDGODINE = new DataColumn("GKGODIDGODINE", typeof(short), "", MappingType.Element);
                this.columnGKGODIDGODINE.AllowDBNull = false;
                this.columnGKGODIDGODINE.Caption = "IDGODINE";
                this.columnGKGODIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGKGODIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("SuperType", "IDGODINE");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("SubtypeGroup", "GKGOD");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("IsKey", "false");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("Description", "Godina");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGKGODIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "GKGODIDGODINE");
                this.Columns.Add(this.columnGKGODIDGODINE);
                this.PrimaryKey = new DataColumn[] { this.columnIDGKSTAVKA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "GKSTAVKA");
                this.ExtendedProperties.Add("Description", "GKSTAVKA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDGKSTAVKA = this.Columns["IDGKSTAVKA"];
                this.columnIDAKTIVNOST = this.Columns["IDAKTIVNOST"];
                this.columnDATUMDOKUMENTA = this.Columns["DATUMDOKUMENTA"];
                this.columnBROJDOKUMENTA = this.Columns["BROJDOKUMENTA"];
                this.columnBROJSTAVKE = this.Columns["BROJSTAVKE"];
                this.columnIDDOKUMENT = this.Columns["IDDOKUMENT"];
                this.columnNAZIVDOKUMENT = this.Columns["NAZIVDOKUMENT"];
                this.columnIDMJESTOTROSKA = this.Columns["IDMJESTOTROSKA"];
                this.columnNAZIVMJESTOTROSKA = this.Columns["NAZIVMJESTOTROSKA"];
                this.columnIDORGJED = this.Columns["IDORGJED"];
                this.columnNAZIVORGJED = this.Columns["NAZIVORGJED"];
                this.columnIDKONTO = this.Columns["IDKONTO"];
                this.columnNAZIVKONTO = this.Columns["NAZIVKONTO"];
                this.columnNAZIVAKTIVNOST = this.Columns["NAZIVAKTIVNOST"];
                this.columnOPIS = this.Columns["OPIS"];
                this.columnduguje = this.Columns["duguje"];
                this.columnPOTRAZUJE = this.Columns["POTRAZUJE"];
                this.columnDATUMPRIJAVE = this.Columns["DATUMPRIJAVE"];
                this.columnIDPARTNER = this.Columns["IDPARTNER"];
                this.columnNAZIVPARTNER = this.Columns["NAZIVPARTNER"];
                this.columnZATVORENIIZNOS = this.Columns["ZATVORENIIZNOS"];
                this.columnGKDATUMVALUTE = this.Columns["GKDATUMVALUTE"];
                this.columnstatusgk = this.Columns["statusgk"];
                this.columnORIGINALNIDOKUMENT = this.Columns["ORIGINALNIDOKUMENT"];
                this.columnGKGODIDGODINE = this.Columns["GKGODIDGODINE"];
            }

            public GKSTAVKADataSet.GKSTAVKARow NewGKSTAVKARow()
            {
                return (GKSTAVKADataSet.GKSTAVKARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new GKSTAVKADataSet.GKSTAVKARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.GKSTAVKARowChanged != null)
                {
                    GKSTAVKADataSet.GKSTAVKARowChangeEventHandler gKSTAVKARowChangedEvent = this.GKSTAVKARowChanged;
                    if (gKSTAVKARowChangedEvent != null)
                    {
                        gKSTAVKARowChangedEvent(this, new GKSTAVKADataSet.GKSTAVKARowChangeEvent((GKSTAVKADataSet.GKSTAVKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.GKSTAVKARowChanging != null)
                {
                    GKSTAVKADataSet.GKSTAVKARowChangeEventHandler gKSTAVKARowChangingEvent = this.GKSTAVKARowChanging;
                    if (gKSTAVKARowChangingEvent != null)
                    {
                        gKSTAVKARowChangingEvent(this, new GKSTAVKADataSet.GKSTAVKARowChangeEvent((GKSTAVKADataSet.GKSTAVKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.GKSTAVKARowDeleted != null)
                {
                    GKSTAVKADataSet.GKSTAVKARowChangeEventHandler gKSTAVKARowDeletedEvent = this.GKSTAVKARowDeleted;
                    if (gKSTAVKARowDeletedEvent != null)
                    {
                        gKSTAVKARowDeletedEvent(this, new GKSTAVKADataSet.GKSTAVKARowChangeEvent((GKSTAVKADataSet.GKSTAVKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.GKSTAVKARowDeleting != null)
                {
                    GKSTAVKADataSet.GKSTAVKARowChangeEventHandler gKSTAVKARowDeletingEvent = this.GKSTAVKARowDeleting;
                    if (gKSTAVKARowDeletingEvent != null)
                    {
                        gKSTAVKARowDeletingEvent(this, new GKSTAVKADataSet.GKSTAVKARowChangeEvent((GKSTAVKADataSet.GKSTAVKARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveGKSTAVKARow(GKSTAVKADataSet.GKSTAVKARow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJDOKUMENTAColumn
            {
                get
                {
                    return this.columnBROJDOKUMENTA;
                }
            }

            public DataColumn BROJSTAVKEColumn
            {
                get
                {
                    return this.columnBROJSTAVKE;
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

            public DataColumn DATUMDOKUMENTAColumn
            {
                get
                {
                    return this.columnDATUMDOKUMENTA;
                }
            }

            public DataColumn DATUMPRIJAVEColumn
            {
                get
                {
                    return this.columnDATUMPRIJAVE;
                }
            }

            public DataColumn dugujeColumn
            {
                get
                {
                    return this.columnduguje;
                }
            }

            public DataColumn GKDATUMVALUTEColumn
            {
                get
                {
                    return this.columnGKDATUMVALUTE;
                }
            }

            public DataColumn GKGODIDGODINEColumn
            {
                get
                {
                    return this.columnGKGODIDGODINE;
                }
            }

            public DataColumn IDAKTIVNOSTColumn
            {
                get
                {
                    return this.columnIDAKTIVNOST;
                }
            }

            public DataColumn IDDOKUMENTColumn
            {
                get
                {
                    return this.columnIDDOKUMENT;
                }
            }

            public DataColumn IDGKSTAVKAColumn
            {
                get
                {
                    return this.columnIDGKSTAVKA;
                }
            }

            public DataColumn IDKONTOColumn
            {
                get
                {
                    return this.columnIDKONTO;
                }
            }

            public DataColumn IDMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnIDMJESTOTROSKA;
                }
            }

            public DataColumn IDORGJEDColumn
            {
                get
                {
                    return this.columnIDORGJED;
                }
            }

            public DataColumn IDPARTNERColumn
            {
                get
                {
                    return this.columnIDPARTNER;
                }
            }

            public GKSTAVKADataSet.GKSTAVKARow this[int index]
            {
                get
                {
                    return (GKSTAVKADataSet.GKSTAVKARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVAKTIVNOSTColumn
            {
                get
                {
                    return this.columnNAZIVAKTIVNOST;
                }
            }

            public DataColumn NAZIVDOKUMENTColumn
            {
                get
                {
                    return this.columnNAZIVDOKUMENT;
                }
            }

            public DataColumn NAZIVKONTOColumn
            {
                get
                {
                    return this.columnNAZIVKONTO;
                }
            }

            public DataColumn NAZIVMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnNAZIVMJESTOTROSKA;
                }
            }

            public DataColumn NAZIVORGJEDColumn
            {
                get
                {
                    return this.columnNAZIVORGJED;
                }
            }

            public DataColumn NAZIVPARTNERColumn
            {
                get
                {
                    return this.columnNAZIVPARTNER;
                }
            }

            public DataColumn OPISColumn
            {
                get
                {
                    return this.columnOPIS;
                }
            }

            public DataColumn ORIGINALNIDOKUMENTColumn
            {
                get
                {
                    return this.columnORIGINALNIDOKUMENT;
                }
            }

            public DataColumn POTRAZUJEColumn
            {
                get
                {
                    return this.columnPOTRAZUJE;
                }
            }

            public DataColumn statusgkColumn
            {
                get
                {
                    return this.columnstatusgk;
                }
            }

            public DataColumn ZATVORENIIZNOSColumn
            {
                get
                {
                    return this.columnZATVORENIIZNOS;
                }
            }
        }

        public class GKSTAVKARow : DataRow
        {
            private GKSTAVKADataSet.GKSTAVKADataTable tableGKSTAVKA;

            internal GKSTAVKARow(DataRowBuilder rb) : base(rb)
            {
                this.tableGKSTAVKA = (GKSTAVKADataSet.GKSTAVKADataTable) this.Table;
                this.DATUMPRIJAVE = DateTime.Now;
            }

            public bool IsBROJDOKUMENTANull()
            {
                return this.IsNull(this.tableGKSTAVKA.BROJDOKUMENTAColumn);
            }

            public bool IsBROJSTAVKENull()
            {
                return this.IsNull(this.tableGKSTAVKA.BROJSTAVKEColumn);
            }

            public bool IsDATUMDOKUMENTANull()
            {
                return this.IsNull(this.tableGKSTAVKA.DATUMDOKUMENTAColumn);
            }

            public bool IsDATUMPRIJAVENull()
            {
                return this.IsNull(this.tableGKSTAVKA.DATUMPRIJAVEColumn);
            }

            public bool IsdugujeNull()
            {
                return this.IsNull(this.tableGKSTAVKA.dugujeColumn);
            }

            public bool IsGKDATUMVALUTENull()
            {
                return this.IsNull(this.tableGKSTAVKA.GKDATUMVALUTEColumn);
            }

            public bool IsGKGODIDGODINENull()
            {
                return this.IsNull(this.tableGKSTAVKA.GKGODIDGODINEColumn);
            }

            public bool IsIDAKTIVNOSTNull()
            {
                return this.IsNull(this.tableGKSTAVKA.IDAKTIVNOSTColumn);
            }

            public bool IsIDDOKUMENTNull()
            {
                return this.IsNull(this.tableGKSTAVKA.IDDOKUMENTColumn);
            }

            public bool IsIDGKSTAVKANull()
            {
                return this.IsNull(this.tableGKSTAVKA.IDGKSTAVKAColumn);
            }

            public bool IsIDKONTONull()
            {
                return this.IsNull(this.tableGKSTAVKA.IDKONTOColumn);
            }

            public bool IsIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableGKSTAVKA.IDMJESTOTROSKAColumn);
            }

            public bool IsIDORGJEDNull()
            {
                return this.IsNull(this.tableGKSTAVKA.IDORGJEDColumn);
            }

            public bool IsIDPARTNERNull()
            {
                return this.IsNull(this.tableGKSTAVKA.IDPARTNERColumn);
            }

            public bool IsNAZIVAKTIVNOSTNull()
            {
                return this.IsNull(this.tableGKSTAVKA.NAZIVAKTIVNOSTColumn);
            }

            public bool IsNAZIVDOKUMENTNull()
            {
                return this.IsNull(this.tableGKSTAVKA.NAZIVDOKUMENTColumn);
            }

            public bool IsNAZIVKONTONull()
            {
                return this.IsNull(this.tableGKSTAVKA.NAZIVKONTOColumn);
            }

            public bool IsNAZIVMJESTOTROSKANull()
            {
                return this.IsNull(this.tableGKSTAVKA.NAZIVMJESTOTROSKAColumn);
            }

            public bool IsNAZIVORGJEDNull()
            {
                return this.IsNull(this.tableGKSTAVKA.NAZIVORGJEDColumn);
            }

            public bool IsNAZIVPARTNERNull()
            {
                return this.IsNull(this.tableGKSTAVKA.NAZIVPARTNERColumn);
            }

            public bool IsOPISNull()
            {
                return this.IsNull(this.tableGKSTAVKA.OPISColumn);
            }

            public bool IsORIGINALNIDOKUMENTNull()
            {
                return this.IsNull(this.tableGKSTAVKA.ORIGINALNIDOKUMENTColumn);
            }

            public bool IsPOTRAZUJENull()
            {
                return this.IsNull(this.tableGKSTAVKA.POTRAZUJEColumn);
            }

            public bool IsstatusgkNull()
            {
                return this.IsNull(this.tableGKSTAVKA.statusgkColumn);
            }

            public bool IsZATVORENIIZNOSNull()
            {
                return this.IsNull(this.tableGKSTAVKA.ZATVORENIIZNOSColumn);
            }

            public void SetBROJDOKUMENTANull()
            {
                this[this.tableGKSTAVKA.BROJDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJSTAVKENull()
            {
                this[this.tableGKSTAVKA.BROJSTAVKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMDOKUMENTANull()
            {
                this[this.tableGKSTAVKA.DATUMDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMPRIJAVENull()
            {
                this[this.tableGKSTAVKA.DATUMPRIJAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetdugujeNull()
            {
                this[this.tableGKSTAVKA.dugujeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGKDATUMVALUTENull()
            {
                this[this.tableGKSTAVKA.GKDATUMVALUTEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGKGODIDGODINENull()
            {
                this[this.tableGKSTAVKA.GKGODIDGODINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDAKTIVNOSTNull()
            {
                this[this.tableGKSTAVKA.IDAKTIVNOSTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDDOKUMENTNull()
            {
                this[this.tableGKSTAVKA.IDDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDKONTONull()
            {
                this[this.tableGKSTAVKA.IDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDMJESTOTROSKANull()
            {
                this[this.tableGKSTAVKA.IDMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDORGJEDNull()
            {
                this[this.tableGKSTAVKA.IDORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDPARTNERNull()
            {
                this[this.tableGKSTAVKA.IDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVAKTIVNOSTNull()
            {
                this[this.tableGKSTAVKA.NAZIVAKTIVNOSTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVDOKUMENTNull()
            {
                this[this.tableGKSTAVKA.NAZIVDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKONTONull()
            {
                this[this.tableGKSTAVKA.NAZIVKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVMJESTOTROSKANull()
            {
                this[this.tableGKSTAVKA.NAZIVMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVORGJEDNull()
            {
                this[this.tableGKSTAVKA.NAZIVORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPARTNERNull()
            {
                this[this.tableGKSTAVKA.NAZIVPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISNull()
            {
                this[this.tableGKSTAVKA.OPISColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetORIGINALNIDOKUMENTNull()
            {
                this[this.tableGKSTAVKA.ORIGINALNIDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOTRAZUJENull()
            {
                this[this.tableGKSTAVKA.POTRAZUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetstatusgkNull()
            {
                this[this.tableGKSTAVKA.statusgkColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZATVORENIIZNOSNull()
            {
                this[this.tableGKSTAVKA.ZATVORENIIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BROJDOKUMENTA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableGKSTAVKA.BROJDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJDOKUMENTA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableGKSTAVKA.BROJDOKUMENTAColumn] = value;
                }
            }

            public int BROJSTAVKE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableGKSTAVKA.BROJSTAVKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJSTAVKE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableGKSTAVKA.BROJSTAVKEColumn] = value;
                }
            }

            public DateTime DATUMDOKUMENTA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableGKSTAVKA.DATUMDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DATUMDOKUMENTA because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableGKSTAVKA.DATUMDOKUMENTAColumn] = value;
                }
            }

            public DateTime DATUMPRIJAVE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableGKSTAVKA.DATUMPRIJAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DATUMPRIJAVE because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableGKSTAVKA.DATUMPRIJAVEColumn] = value;
                }
            }

            public decimal duguje
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableGKSTAVKA.dugujeColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value duguje because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableGKSTAVKA.dugujeColumn] = value;
                }
            }

            public DateTime GKDATUMVALUTE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableGKSTAVKA.GKDATUMVALUTEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value GKDATUMVALUTE because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableGKSTAVKA.GKDATUMVALUTEColumn] = value;
                }
            }

            public short GKGODIDGODINE
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableGKSTAVKA.GKGODIDGODINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value GKGODIDGODINE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableGKSTAVKA.GKGODIDGODINEColumn] = value;
                }
            }

            public int IDAKTIVNOST
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableGKSTAVKA.IDAKTIVNOSTColumn]);
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
                    this[this.tableGKSTAVKA.IDAKTIVNOSTColumn] = value;
                }
            }

            public int IDDOKUMENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableGKSTAVKA.IDDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDDOKUMENT because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableGKSTAVKA.IDDOKUMENTColumn] = value;
                }
            }

            public int IDGKSTAVKA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableGKSTAVKA.IDGKSTAVKAColumn]);
                }
                set
                {
                    this[this.tableGKSTAVKA.IDGKSTAVKAColumn] = value;
                }
            }

            public string IDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGKSTAVKA.IDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDKONTO because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableGKSTAVKA.IDKONTOColumn] = value;
                }
            }

            public int IDMJESTOTROSKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableGKSTAVKA.IDMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableGKSTAVKA.IDMJESTOTROSKAColumn] = value;
                }
            }

            public int IDORGJED
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableGKSTAVKA.IDORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableGKSTAVKA.IDORGJEDColumn] = value;
                }
            }

            public int IDPARTNER
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableGKSTAVKA.IDPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableGKSTAVKA.IDPARTNERColumn] = value;
                }
            }

            public string NAZIVAKTIVNOST
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGKSTAVKA.NAZIVAKTIVNOSTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableGKSTAVKA.NAZIVAKTIVNOSTColumn] = value;
                }
            }

            public string NAZIVDOKUMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGKSTAVKA.NAZIVDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableGKSTAVKA.NAZIVDOKUMENTColumn] = value;
                }
            }

            public string NAZIVKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGKSTAVKA.NAZIVKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableGKSTAVKA.NAZIVKONTOColumn] = value;
                }
            }

            public string NAZIVMJESTOTROSKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGKSTAVKA.NAZIVMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableGKSTAVKA.NAZIVMJESTOTROSKAColumn] = value;
                }
            }

            public string NAZIVORGJED
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGKSTAVKA.NAZIVORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableGKSTAVKA.NAZIVORGJEDColumn] = value;
                }
            }

            public string NAZIVPARTNER
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGKSTAVKA.NAZIVPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableGKSTAVKA.NAZIVPARTNERColumn] = value;
                }
            }

            public string OPIS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGKSTAVKA.OPISColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableGKSTAVKA.OPISColumn] = value;
                }
            }

            public string ORIGINALNIDOKUMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGKSTAVKA.ORIGINALNIDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableGKSTAVKA.ORIGINALNIDOKUMENTColumn] = value;
                }
            }

            public decimal POTRAZUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableGKSTAVKA.POTRAZUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableGKSTAVKA.POTRAZUJEColumn] = value;
                }
            }

            public bool statusgk
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableGKSTAVKA.statusgkColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableGKSTAVKA.statusgkColumn] = value;
                }
            }

            public decimal ZATVORENIIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableGKSTAVKA.ZATVORENIIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableGKSTAVKA.ZATVORENIIZNOSColumn] = value;
                }
            }
        }

        public class GKSTAVKARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private GKSTAVKADataSet.GKSTAVKARow eventRow;

            public GKSTAVKARowChangeEvent(GKSTAVKADataSet.GKSTAVKARow row, DataRowAction action)
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

            public GKSTAVKADataSet.GKSTAVKARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void GKSTAVKARowChangeEventHandler(object sender, GKSTAVKADataSet.GKSTAVKARowChangeEvent e);
    }
}

