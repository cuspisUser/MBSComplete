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
    public class DDRADNIKDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private DDRADNIKDataTable tableDDRADNIK;

        public DDRADNIKDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected DDRADNIKDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["DDRADNIK"] != null)
                    {
                        this.Tables.Add(new DDRADNIKDataTable(dataSet.Tables["DDRADNIK"]));
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
            DDRADNIKDataSet set = (DDRADNIKDataSet) base.Clone();
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
            DDRADNIKDataSet set = new DDRADNIKDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "DDRADNIKDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2084");
            this.ExtendedProperties.Add("DataSetName", "DDRADNIKDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IDDRADNIKDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "DDRADNIK");
            this.ExtendedProperties.Add("ObjectDescription", "Primatelji DD");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\DD");
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
            this.DataSetName = "DDRADNIKDataSet";
            this.Namespace = "http://www.tempuri.org/DDRADNIK";
            this.tableDDRADNIK = new DDRADNIKDataTable();
            this.Tables.Add(this.tableDDRADNIK);
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
            this.tableDDRADNIK = (DDRADNIKDataTable) this.Tables["DDRADNIK"];
            if (initTable && (this.tableDDRADNIK != null))
            {
                this.tableDDRADNIK.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["DDRADNIK"] != null)
                {
                    this.Tables.Add(new DDRADNIKDataTable(dataSet.Tables["DDRADNIK"]));
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

        private bool ShouldSerializeDDRADNIK()
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
        public DDRADNIKDataTable DDRADNIK
        {
            get
            {
                return this.tableDDRADNIK;
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
        public class DDRADNIKDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDADRESA;
            private DataColumn columnDDDRUGISTUP;
            private DataColumn columnDDIDRADNIK;
            private DataColumn columnDDIME;
            private DataColumn columnDDJMBG;
            private DataColumn columnDDKUCNIBROJ;
            private DataColumn columnDDMJESTO;
            private DataColumn columnDDMO;
            private DataColumn columnDDOIB;
            private DataColumn columnDDOPISPLACANJANETO;
            private DataColumn columnDDPBO;
            private DataColumn columnDDPDVOBVEZNIK;
            private DataColumn columnDDPREZIME;
            private DataColumn columnDDSIFRAOPISAPLACANJANETO;
            private DataColumn columnDDZBIRNINETO;
            private DataColumn columnDDZRN;
            private DataColumn columnIDBANKE;
            private DataColumn columnNAZIVBANKE1;
            private DataColumn columnNAZIVBANKE2;
            private DataColumn columnNAZIVBANKE3;
            private DataColumn columnOPCINARADAIDOPCINE;
            private DataColumn columnOPCINARADANAZIVOPCINE;
            private DataColumn columnOPCINASTANOVANJAIDOPCINE;
            private DataColumn columnOPCINASTANOVANJANAZIVOPCINE;
            private DataColumn columnOPCINASTANOVANJAPRIREZ;
            private DataColumn columnOPCINASTANOVANJAVBDIOPCINA;
            private DataColumn columnOPCINASTANOVANJAZRNOPCINA;
            private DataColumn columnVBDIBANKE;
            private DataColumn columnZRNBANKE;
            private DataColumn columnAktivan;

            public event DDRADNIKDataSet.DDRADNIKRowChangeEventHandler DDRADNIKRowChanged;

            public event DDRADNIKDataSet.DDRADNIKRowChangeEventHandler DDRADNIKRowChanging;

            public event DDRADNIKDataSet.DDRADNIKRowChangeEventHandler DDRADNIKRowDeleted;

            public event DDRADNIKDataSet.DDRADNIKRowChangeEventHandler DDRADNIKRowDeleting;

            public DDRADNIKDataTable()
            {
                this.TableName = "DDRADNIK";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDRADNIKDataTable(DataTable table) : base(table.TableName)
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

            protected DDRADNIKDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDRADNIKRow(DDRADNIKDataSet.DDRADNIKRow row)
            {
                this.Rows.Add(row);
            }

            public DDRADNIKDataSet.DDRADNIKRow AddDDRADNIKRow(int dDIDRADNIK, string dDJMBG, string dDOIB, string dDPREZIME, string dDIME, string dDADRESA, string dDKUCNIBROJ, string dDMJESTO, string dDZRN, int iDBANKE, string oPCINARADAIDOPCINE, string oPCINASTANOVANJAIDOPCINE, string dDSIFRAOPISAPLACANJANETO, string dDOPISPLACANJANETO, bool dDPDVOBVEZNIK, bool dDDRUGISTUP, bool dDZBIRNINETO, string dDMO, string dDPBO)
            {
                DDRADNIKDataSet.DDRADNIKRow row = (DDRADNIKDataSet.DDRADNIKRow) this.NewRow();
                row["DDIDRADNIK"] = dDIDRADNIK;
                row["DDJMBG"] = dDJMBG;
                row["DDOIB"] = dDOIB;
                row["DDPREZIME"] = dDPREZIME;
                row["DDIME"] = dDIME;
                row["DDADRESA"] = dDADRESA;
                row["DDKUCNIBROJ"] = dDKUCNIBROJ;
                row["DDMJESTO"] = dDMJESTO;
                row["DDZRN"] = dDZRN;
                row["IDBANKE"] = iDBANKE;
                row["OPCINARADAIDOPCINE"] = oPCINARADAIDOPCINE;
                row["OPCINASTANOVANJAIDOPCINE"] = oPCINASTANOVANJAIDOPCINE;
                row["DDSIFRAOPISAPLACANJANETO"] = dDSIFRAOPISAPLACANJANETO;
                row["DDOPISPLACANJANETO"] = dDOPISPLACANJANETO;
                row["DDPDVOBVEZNIK"] = dDPDVOBVEZNIK;
                row["DDDRUGISTUP"] = dDDRUGISTUP;
                row["DDZBIRNINETO"] = dDZBIRNINETO;
                row["DDMO"] = dDMO;
                row["DDPBO"] = dDPBO;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDRADNIKDataSet.DDRADNIKDataTable table = (DDRADNIKDataSet.DDRADNIKDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDRADNIKDataSet.DDRADNIKRow FindByDDIDRADNIK(int dDIDRADNIK)
            {
                return (DDRADNIKDataSet.DDRADNIKRow) this.Rows.Find(new object[] { dDIDRADNIK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDRADNIKDataSet.DDRADNIKRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDRADNIKDataSet set = new DDRADNIKDataSet();
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
                this.columnDDIDRADNIK = new DataColumn("DDIDRADNIK", typeof(int), "", MappingType.Element);
                this.columnDDIDRADNIK.AllowDBNull = false;
                this.columnDDIDRADNIK.Caption = "Šifra";
                this.columnDDIDRADNIK.Unique = true;
                this.columnDDIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Description", "Šifra");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Length", "5");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "DDIDRADNIK");
                this.Columns.Add(this.columnDDIDRADNIK);
                this.columnDDJMBG = new DataColumn("DDJMBG", typeof(string), "", MappingType.Element);
                this.columnDDJMBG.AllowDBNull = true;
                this.columnDDJMBG.Caption = "JMBG";
                this.columnDDJMBG.MaxLength = 13;
                this.columnDDJMBG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDJMBG.ExtendedProperties.Add("IsKey", "false");
                this.columnDDJMBG.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDJMBG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDJMBG.ExtendedProperties.Add("Description", "JMBG");
                this.columnDDJMBG.ExtendedProperties.Add("Length", "13");
                this.columnDDJMBG.ExtendedProperties.Add("Decimals", "0");
                this.columnDDJMBG.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDJMBG.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.InternalName", "DDJMBG");
                this.Columns.Add(this.columnDDJMBG);
                this.columnDDOIB = new DataColumn("DDOIB", typeof(string), "", MappingType.Element);
                this.columnDDOIB.AllowDBNull = false;
                this.columnDDOIB.Caption = "OIB";
                this.columnDDOIB.MaxLength = 11;
                this.columnDDOIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOIB.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOIB.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOIB.ExtendedProperties.Add("Description", "OIB");
                this.columnDDOIB.ExtendedProperties.Add("Length", "11");
                this.columnDDOIB.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOIB.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.InternalName", "DDOIB");
                this.Columns.Add(this.columnDDOIB);
                this.columnDDPREZIME = new DataColumn("DDPREZIME", typeof(string), "", MappingType.Element);
                this.columnDDPREZIME.AllowDBNull = false;
                this.columnDDPREZIME.Caption = "Prezime";
                this.columnDDPREZIME.MaxLength = 50;
                this.columnDDPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnDDPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnDDPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnDDPREZIME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "DDPREZIME");
                this.Columns.Add(this.columnDDPREZIME);
                this.columnDDIME = new DataColumn("DDIME", typeof(string), "", MappingType.Element);
                this.columnDDIME.AllowDBNull = false;
                this.columnDDIME.Caption = "Ime";
                this.columnDDIME.MaxLength = 50;
                this.columnDDIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIME.ExtendedProperties.Add("IsKey", "false");
                this.columnDDIME.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDIME.ExtendedProperties.Add("Description", "Ime");
                this.columnDDIME.ExtendedProperties.Add("Length", "50");
                this.columnDDIME.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.InternalName", "DDIME");
                this.Columns.Add(this.columnDDIME);
                this.columnDDADRESA = new DataColumn("DDADRESA", typeof(string), "", MappingType.Element);
                this.columnDDADRESA.AllowDBNull = false;
                this.columnDDADRESA.Caption = "DDADRESA";
                this.columnDDADRESA.MaxLength = 50;
                this.columnDDADRESA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDADRESA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDADRESA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDADRESA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDADRESA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDADRESA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDADRESA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDADRESA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDADRESA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDADRESA.ExtendedProperties.Add("Description", "Adresa");
                this.columnDDADRESA.ExtendedProperties.Add("Length", "50");
                this.columnDDADRESA.ExtendedProperties.Add("Decimals", "0");
                this.columnDDADRESA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDADRESA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDADRESA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDADRESA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDADRESA.ExtendedProperties.Add("Deklarit.InternalName", "DDADRESA");
                this.Columns.Add(this.columnDDADRESA);
                this.columnDDKUCNIBROJ = new DataColumn("DDKUCNIBROJ", typeof(string), "", MappingType.Element);
                this.columnDDKUCNIBROJ.AllowDBNull = false;
                this.columnDDKUCNIBROJ.Caption = "DDKUCNIBROJ";
                this.columnDDKUCNIBROJ.MaxLength = 10;
                this.columnDDKUCNIBROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("Description", "Kućni broj");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("Length", "10");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDKUCNIBROJ.ExtendedProperties.Add("Deklarit.InternalName", "DDKUCNIBROJ");
                this.Columns.Add(this.columnDDKUCNIBROJ);
                this.columnDDMJESTO = new DataColumn("DDMJESTO", typeof(string), "", MappingType.Element);
                this.columnDDMJESTO.AllowDBNull = false;
                this.columnDDMJESTO.Caption = "DDMJESTO";
                this.columnDDMJESTO.MaxLength = 50;
                this.columnDDMJESTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDMJESTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDMJESTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDMJESTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDMJESTO.ExtendedProperties.Add("IsKey", "false");
                this.columnDDMJESTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDMJESTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDMJESTO.ExtendedProperties.Add("Description", "Mjesto");
                this.columnDDMJESTO.ExtendedProperties.Add("Length", "50");
                this.columnDDMJESTO.ExtendedProperties.Add("Decimals", "0");
                this.columnDDMJESTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDMJESTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDMJESTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDMJESTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDMJESTO.ExtendedProperties.Add("Deklarit.InternalName", "DDMJESTO");
                this.Columns.Add(this.columnDDMJESTO);
                this.columnDDZRN = new DataColumn("DDZRN", typeof(string), "", MappingType.Element);
                this.columnDDZRN.AllowDBNull = false;
                this.columnDDZRN.Caption = "DDZRN";
                this.columnDDZRN.MaxLength = 10;
                this.columnDDZRN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDZRN.ExtendedProperties.Add("IsKey", "false");
                this.columnDDZRN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDZRN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDZRN.ExtendedProperties.Add("Description", "Žiro račun");
                this.columnDDZRN.ExtendedProperties.Add("Length", "10");
                this.columnDDZRN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDZRN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDZRN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.InternalName", "DDZRN");
                this.Columns.Add(this.columnDDZRN);
                this.columnIDBANKE = new DataColumn("IDBANKE", typeof(int), "", MappingType.Element);
                this.columnIDBANKE.AllowDBNull = false;
                this.columnIDBANKE.Caption = "Šifra banke";
                this.columnIDBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDBANKE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDBANKE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDBANKE.ExtendedProperties.Add("Description", "Otvoren u");
                this.columnIDBANKE.ExtendedProperties.Add("Length", "5");
                this.columnIDBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBANKE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDBANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.InternalName", "IDBANKE");
                this.Columns.Add(this.columnIDBANKE);
                this.columnNAZIVBANKE1 = new DataColumn("NAZIVBANKE1", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE1.AllowDBNull = true;
                this.columnNAZIVBANKE1.Caption = "Naziv banke";
                this.columnNAZIVBANKE1.MaxLength = 20;
                this.columnNAZIVBANKE1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Description", "Naziv banke");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE1");
                this.Columns.Add(this.columnNAZIVBANKE1);
                this.columnNAZIVBANKE2 = new DataColumn("NAZIVBANKE2", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE2.AllowDBNull = true;
                this.columnNAZIVBANKE2.Caption = "Naziv banke (2)";
                this.columnNAZIVBANKE2.MaxLength = 20;
                this.columnNAZIVBANKE2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Description", "Naziv banke (2)");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE2");
                this.Columns.Add(this.columnNAZIVBANKE2);
                this.columnNAZIVBANKE3 = new DataColumn("NAZIVBANKE3", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE3.AllowDBNull = true;
                this.columnNAZIVBANKE3.Caption = "Naziv banke (3)";
                this.columnNAZIVBANKE3.MaxLength = 20;
                this.columnNAZIVBANKE3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Description", "Naziv banke (3)");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE3");
                this.Columns.Add(this.columnNAZIVBANKE3);
                this.columnVBDIBANKE = new DataColumn("VBDIBANKE", typeof(string), "", MappingType.Element);
                this.columnVBDIBANKE.AllowDBNull = true;
                this.columnVBDIBANKE.Caption = "VBDI žiro računa banke";
                this.columnVBDIBANKE.MaxLength = 7;
                this.columnVBDIBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIBANKE.ExtendedProperties.Add("Description", "VBDI žiro računa banke");
                this.columnVBDIBANKE.ExtendedProperties.Add("Length", "7");
                this.columnVBDIBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIBANKE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.InternalName", "VBDIBANKE");
                this.Columns.Add(this.columnVBDIBANKE);
                this.columnZRNBANKE = new DataColumn("ZRNBANKE", typeof(string), "", MappingType.Element);
                this.columnZRNBANKE.AllowDBNull = true;
                this.columnZRNBANKE.Caption = "Broj žiro računa banke";
                this.columnZRNBANKE.MaxLength = 10;
                this.columnZRNBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNBANKE.ExtendedProperties.Add("Description", "Broj žiro računa banke");
                this.columnZRNBANKE.ExtendedProperties.Add("Length", "10");
                this.columnZRNBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNBANKE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.InternalName", "ZRNBANKE");
                this.Columns.Add(this.columnZRNBANKE);
                this.columnOPCINARADAIDOPCINE = new DataColumn("OPCINARADAIDOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINARADAIDOPCINE.AllowDBNull = false;
                this.columnOPCINARADAIDOPCINE.Caption = "Šifra općine rada";
                this.columnOPCINARADAIDOPCINE.MaxLength = 4;
                this.columnOPCINARADAIDOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("SuperType", "IDOPCINE");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINARADA");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Description", "Šifra općine rada");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Length", "4");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINARADAIDOPCINE");
                this.Columns.Add(this.columnOPCINARADAIDOPCINE);
                this.columnOPCINARADANAZIVOPCINE = new DataColumn("OPCINARADANAZIVOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINARADANAZIVOPCINE.AllowDBNull = true;
                this.columnOPCINARADANAZIVOPCINE.Caption = "Naziv općine rada";
                this.columnOPCINARADANAZIVOPCINE.MaxLength = 50;
                this.columnOPCINARADANAZIVOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("SuperType", "NAZIVOPCINE");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINARADA");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Description", "Naziv općine rada");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Length", "50");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINARADANAZIVOPCINE");
                this.Columns.Add(this.columnOPCINARADANAZIVOPCINE);
                this.columnOPCINASTANOVANJAIDOPCINE = new DataColumn("OPCINASTANOVANJAIDOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJAIDOPCINE.AllowDBNull = false;
                this.columnOPCINASTANOVANJAIDOPCINE.Caption = "Šifra općine stanovanja";
                this.columnOPCINASTANOVANJAIDOPCINE.MaxLength = 4;
                this.columnOPCINASTANOVANJAIDOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("SuperType", "IDOPCINE");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Description", "Šifra općine stanovanja");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Length", "4");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAIDOPCINE");
                this.Columns.Add(this.columnOPCINASTANOVANJAIDOPCINE);
                this.columnOPCINASTANOVANJANAZIVOPCINE = new DataColumn("OPCINASTANOVANJANAZIVOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJANAZIVOPCINE.AllowDBNull = true;
                this.columnOPCINASTANOVANJANAZIVOPCINE.Caption = "Naziv općine stanovanja";
                this.columnOPCINASTANOVANJANAZIVOPCINE.MaxLength = 50;
                this.columnOPCINASTANOVANJANAZIVOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("SuperType", "NAZIVOPCINE");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Description", "Naziv općine stanovanja");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Length", "50");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJANAZIVOPCINE");
                this.Columns.Add(this.columnOPCINASTANOVANJANAZIVOPCINE);
                this.columnOPCINASTANOVANJAPRIREZ = new DataColumn("OPCINASTANOVANJAPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnOPCINASTANOVANJAPRIREZ.AllowDBNull = true;
                this.columnOPCINASTANOVANJAPRIREZ.Caption = "Prirez općine stanovanja";
                this.columnOPCINASTANOVANJAPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("SuperType", "PRIREZ");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Description", "Prirez općine stanovanja");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAPRIREZ");
                this.Columns.Add(this.columnOPCINASTANOVANJAPRIREZ);
                this.columnOPCINASTANOVANJAVBDIOPCINA = new DataColumn("OPCINASTANOVANJAVBDIOPCINA", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJAVBDIOPCINA.AllowDBNull = true;
                this.columnOPCINASTANOVANJAVBDIOPCINA.Caption = "VBDI žiro računa općine stanovanja";
                this.columnOPCINASTANOVANJAVBDIOPCINA.MaxLength = 7;
                this.columnOPCINASTANOVANJAVBDIOPCINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("SuperType", "VBDIOPCINA");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Description", "VBDI žiro računa općine stanovanja");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Length", "7");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAVBDIOPCINA");
                this.Columns.Add(this.columnOPCINASTANOVANJAVBDIOPCINA);
                this.columnOPCINASTANOVANJAZRNOPCINA = new DataColumn("OPCINASTANOVANJAZRNOPCINA", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJAZRNOPCINA.AllowDBNull = true;
                this.columnOPCINASTANOVANJAZRNOPCINA.Caption = "Broj žiro računa općine stanovanja";
                this.columnOPCINASTANOVANJAZRNOPCINA.MaxLength = 10;
                this.columnOPCINASTANOVANJAZRNOPCINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("SuperType", "ZRNOPCINA");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Description", "Broj žiro računa općine stanovanja");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Length", "10");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAZRNOPCINA");
                this.Columns.Add(this.columnOPCINASTANOVANJAZRNOPCINA);
                this.columnDDSIFRAOPISAPLACANJANETO = new DataColumn("DDSIFRAOPISAPLACANJANETO", typeof(string), "", MappingType.Element);
                this.columnDDSIFRAOPISAPLACANJANETO.AllowDBNull = false;
                this.columnDDSIFRAOPISAPLACANJANETO.Caption = "DDSIFRAOPISAPLACANJANETO";
                this.columnDDSIFRAOPISAPLACANJANETO.MaxLength = 2;
                this.columnDDSIFRAOPISAPLACANJANETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("IsKey", "false");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Description", "Šifra opisa plaćanja");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Length", "2");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Decimals", "0");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.InternalName", "DDSIFRAOPISAPLACANJANETO");
                this.Columns.Add(this.columnDDSIFRAOPISAPLACANJANETO);
                this.columnDDOPISPLACANJANETO = new DataColumn("DDOPISPLACANJANETO", typeof(string), "", MappingType.Element);
                this.columnDDOPISPLACANJANETO.AllowDBNull = false;
                this.columnDDOPISPLACANJANETO.Caption = "DDOPISPLACANJANETO";
                this.columnDDOPISPLACANJANETO.MaxLength = 0x24;
                this.columnDDOPISPLACANJANETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("Description", "Opis plaćanja za neto");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("Length", "36");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.InternalName", "DDOPISPLACANJANETO");
                this.Columns.Add(this.columnDDOPISPLACANJANETO);
                this.columnDDPDVOBVEZNIK = new DataColumn("DDPDVOBVEZNIK", typeof(bool), "", MappingType.Element);
                this.columnDDPDVOBVEZNIK.AllowDBNull = false;
                this.columnDDPDVOBVEZNIK.Caption = "DDPDVOBVEZNIK";
                this.columnDDPDVOBVEZNIK.DefaultValue = false;
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Description", "Obveznik PDV-a");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Length", "1");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.InternalName", "DDPDVOBVEZNIK");
                this.Columns.Add(this.columnDDPDVOBVEZNIK);
                this.columnDDDRUGISTUP = new DataColumn("DDDRUGISTUP", typeof(bool), "", MappingType.Element);
                this.columnDDDRUGISTUP.AllowDBNull = false;
                this.columnDDDRUGISTUP.Caption = "DDDRUGISTUP";
                this.columnDDDRUGISTUP.DefaultValue = false;
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("IsKey", "false");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Description", "Član MIO2");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Length", "1");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Decimals", "0");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.InternalName", "DDDRUGISTUP");
                this.Columns.Add(this.columnDDDRUGISTUP);

                this.columnAktivan = new DataColumn("Aktivan", typeof(bool), "", MappingType.Element);
                this.columnAktivan.AllowDBNull = false;
                this.columnAktivan.Caption = "Aktivan";
                this.columnAktivan.DefaultValue = false;
                this.columnAktivan.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnAktivan.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnAktivan.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnAktivan.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnAktivan.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnAktivan.ExtendedProperties.Add("IsKey", "false");
                this.columnAktivan.ExtendedProperties.Add("ReadOnly", "false");
                this.columnAktivan.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnAktivan.ExtendedProperties.Add("Description", "Aktivan");
                this.columnAktivan.ExtendedProperties.Add("Length", "1");
                this.columnAktivan.ExtendedProperties.Add("Decimals", "0");
                this.columnAktivan.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnAktivan.ExtendedProperties.Add("IsInReader", "true");
                this.columnAktivan.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnAktivan.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnAktivan.ExtendedProperties.Add("Deklarit.InternalName", "Aktivan");
                this.Columns.Add(this.columnAktivan);

                this.columnDDZBIRNINETO = new DataColumn("DDZBIRNINETO", typeof(bool), "", MappingType.Element);
                this.columnDDZBIRNINETO.AllowDBNull = false;
                this.columnDDZBIRNINETO.Caption = "DDZBIRNINETO";
                this.columnDDZBIRNINETO.DefaultValue = false;
                this.columnDDZBIRNINETO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("IsKey", "false");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("Description", "Zbirni neto");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("Length", "1");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("Decimals", "0");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDZBIRNINETO.ExtendedProperties.Add("Deklarit.InternalName", "DDZBIRNINETO");
                this.Columns.Add(this.columnDDZBIRNINETO);
                this.columnDDMO = new DataColumn("DDMO", typeof(string), "", MappingType.Element);
                this.columnDDMO.AllowDBNull = true;
                this.columnDDMO.Caption = "DDMO";
                this.columnDDMO.MaxLength = 2;
                this.columnDDMO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDMO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDMO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDMO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDMO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDMO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDMO.ExtendedProperties.Add("IsKey", "false");
                this.columnDDMO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDMO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDMO.ExtendedProperties.Add("Description", "Model odobrenja kod pojedinačne uplate");
                this.columnDDMO.ExtendedProperties.Add("Length", "2");
                this.columnDDMO.ExtendedProperties.Add("Decimals", "0");
                this.columnDDMO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDMO.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDMO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDMO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDMO.ExtendedProperties.Add("Deklarit.InternalName", "DDMO");
                this.Columns.Add(this.columnDDMO);
                this.columnDDPBO = new DataColumn("DDPBO", typeof(string), "", MappingType.Element);
                this.columnDDPBO.AllowDBNull = true;
                this.columnDDPBO.Caption = "DDPBO";
                this.columnDDPBO.MaxLength = 0x16;
                this.columnDDPBO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDPBO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPBO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPBO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPBO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPBO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPBO.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPBO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDPBO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDPBO.ExtendedProperties.Add("Description", "Poziv na broj odobrenja kod pojedinačne uplate");
                this.columnDDPBO.ExtendedProperties.Add("Length", "22");
                this.columnDDPBO.ExtendedProperties.Add("Decimals", "0");
                this.columnDDPBO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDPBO.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDPBO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPBO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPBO.ExtendedProperties.Add("Deklarit.InternalName", "DDPBO");
                this.Columns.Add(this.columnDDPBO);
                this.PrimaryKey = new DataColumn[] { this.columnDDIDRADNIK };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "DDRADNIK");
                this.ExtendedProperties.Add("Description", "Primatelji DD");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnDDIDRADNIK = this.Columns["DDIDRADNIK"];
                this.columnDDJMBG = this.Columns["DDJMBG"];
                this.columnDDOIB = this.Columns["DDOIB"];
                this.columnDDPREZIME = this.Columns["DDPREZIME"];
                this.columnDDIME = this.Columns["DDIME"];
                this.columnDDADRESA = this.Columns["DDADRESA"];
                this.columnDDKUCNIBROJ = this.Columns["DDKUCNIBROJ"];
                this.columnDDMJESTO = this.Columns["DDMJESTO"];
                this.columnDDZRN = this.Columns["DDZRN"];
                this.columnIDBANKE = this.Columns["IDBANKE"];
                this.columnNAZIVBANKE1 = this.Columns["NAZIVBANKE1"];
                this.columnNAZIVBANKE2 = this.Columns["NAZIVBANKE2"];
                this.columnNAZIVBANKE3 = this.Columns["NAZIVBANKE3"];
                this.columnVBDIBANKE = this.Columns["VBDIBANKE"];
                this.columnZRNBANKE = this.Columns["ZRNBANKE"];
                this.columnOPCINARADAIDOPCINE = this.Columns["OPCINARADAIDOPCINE"];
                this.columnOPCINARADANAZIVOPCINE = this.Columns["OPCINARADANAZIVOPCINE"];
                this.columnOPCINASTANOVANJAIDOPCINE = this.Columns["OPCINASTANOVANJAIDOPCINE"];
                this.columnOPCINASTANOVANJANAZIVOPCINE = this.Columns["OPCINASTANOVANJANAZIVOPCINE"];
                this.columnOPCINASTANOVANJAPRIREZ = this.Columns["OPCINASTANOVANJAPRIREZ"];
                this.columnOPCINASTANOVANJAVBDIOPCINA = this.Columns["OPCINASTANOVANJAVBDIOPCINA"];
                this.columnOPCINASTANOVANJAZRNOPCINA = this.Columns["OPCINASTANOVANJAZRNOPCINA"];
                this.columnDDSIFRAOPISAPLACANJANETO = this.Columns["DDSIFRAOPISAPLACANJANETO"];
                this.columnDDOPISPLACANJANETO = this.Columns["DDOPISPLACANJANETO"];
                this.columnDDPDVOBVEZNIK = this.Columns["DDPDVOBVEZNIK"];
                this.columnDDDRUGISTUP = this.Columns["DDDRUGISTUP"];
                this.columnDDZBIRNINETO = this.Columns["DDZBIRNINETO"];
                this.columnDDMO = this.Columns["DDMO"];
                this.columnDDPBO = this.Columns["DDPBO"];
                this.columnAktivan = this.Columns["Aktivan"];
            }

            public DDRADNIKDataSet.DDRADNIKRow NewDDRADNIKRow()
            {
                return (DDRADNIKDataSet.DDRADNIKRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDRADNIKDataSet.DDRADNIKRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDRADNIKRowChanged != null)
                {
                    DDRADNIKDataSet.DDRADNIKRowChangeEventHandler dDRADNIKRowChangedEvent = this.DDRADNIKRowChanged;
                    if (dDRADNIKRowChangedEvent != null)
                    {
                        dDRADNIKRowChangedEvent(this, new DDRADNIKDataSet.DDRADNIKRowChangeEvent((DDRADNIKDataSet.DDRADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDRADNIKRowChanging != null)
                {
                    DDRADNIKDataSet.DDRADNIKRowChangeEventHandler dDRADNIKRowChangingEvent = this.DDRADNIKRowChanging;
                    if (dDRADNIKRowChangingEvent != null)
                    {
                        dDRADNIKRowChangingEvent(this, new DDRADNIKDataSet.DDRADNIKRowChangeEvent((DDRADNIKDataSet.DDRADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DDRADNIKRowDeleted != null)
                {
                    DDRADNIKDataSet.DDRADNIKRowChangeEventHandler dDRADNIKRowDeletedEvent = this.DDRADNIKRowDeleted;
                    if (dDRADNIKRowDeletedEvent != null)
                    {
                        dDRADNIKRowDeletedEvent(this, new DDRADNIKDataSet.DDRADNIKRowChangeEvent((DDRADNIKDataSet.DDRADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDRADNIKRowDeleting != null)
                {
                    DDRADNIKDataSet.DDRADNIKRowChangeEventHandler dDRADNIKRowDeletingEvent = this.DDRADNIKRowDeleting;
                    if (dDRADNIKRowDeletingEvent != null)
                    {
                        dDRADNIKRowDeletingEvent(this, new DDRADNIKDataSet.DDRADNIKRowChangeEvent((DDRADNIKDataSet.DDRADNIKRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDRADNIKRow(DDRADNIKDataSet.DDRADNIKRow row)
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

            public DataColumn DDADRESAColumn
            {
                get
                {
                    return this.columnDDADRESA;
                }
            }

            public DataColumn DDDRUGISTUPColumn
            {
                get
                {
                    return this.columnDDDRUGISTUP;
                }
            }

            public DataColumn DDIDRADNIKColumn
            {
                get
                {
                    return this.columnDDIDRADNIK;
                }
            }

            public DataColumn DDIMEColumn
            {
                get
                {
                    return this.columnDDIME;
                }
            }

            public DataColumn DDJMBGColumn
            {
                get
                {
                    return this.columnDDJMBG;
                }
            }

            public DataColumn DDKUCNIBROJColumn
            {
                get
                {
                    return this.columnDDKUCNIBROJ;
                }
            }

            public DataColumn DDMJESTOColumn
            {
                get
                {
                    return this.columnDDMJESTO;
                }
            }

            public DataColumn DDMOColumn
            {
                get
                {
                    return this.columnDDMO;
                }
            }

            public DataColumn DDOIBColumn
            {
                get
                {
                    return this.columnDDOIB;
                }
            }

            public DataColumn DDOPISPLACANJANETOColumn
            {
                get
                {
                    return this.columnDDOPISPLACANJANETO;
                }
            }

            public DataColumn DDPBOColumn
            {
                get
                {
                    return this.columnDDPBO;
                }
            }

            public DataColumn DDPDVOBVEZNIKColumn
            {
                get
                {
                    return this.columnDDPDVOBVEZNIK;
                }
            }

            public DataColumn DDPREZIMEColumn
            {
                get
                {
                    return this.columnDDPREZIME;
                }
            }

            public DataColumn DDSIFRAOPISAPLACANJANETOColumn
            {
                get
                {
                    return this.columnDDSIFRAOPISAPLACANJANETO;
                }
            }

            public DataColumn DDZBIRNINETOColumn
            {
                get
                {
                    return this.columnDDZBIRNINETO;
                }
            }

            public DataColumn AktivanColumn
            {
                get
                {
                    return this.columnAktivan;
                }
            }

            public DataColumn DDZRNColumn
            {
                get
                {
                    return this.columnDDZRN;
                }
            }

            public DataColumn IDBANKEColumn
            {
                get
                {
                    return this.columnIDBANKE;
                }
            }

            public DDRADNIKDataSet.DDRADNIKRow this[int index]
            {
                get
                {
                    return (DDRADNIKDataSet.DDRADNIKRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVBANKE1Column
            {
                get
                {
                    return this.columnNAZIVBANKE1;
                }
            }

            public DataColumn NAZIVBANKE2Column
            {
                get
                {
                    return this.columnNAZIVBANKE2;
                }
            }

            public DataColumn NAZIVBANKE3Column
            {
                get
                {
                    return this.columnNAZIVBANKE3;
                }
            }

            public DataColumn OPCINARADAIDOPCINEColumn
            {
                get
                {
                    return this.columnOPCINARADAIDOPCINE;
                }
            }

            public DataColumn OPCINARADANAZIVOPCINEColumn
            {
                get
                {
                    return this.columnOPCINARADANAZIVOPCINE;
                }
            }

            public DataColumn OPCINASTANOVANJAIDOPCINEColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAIDOPCINE;
                }
            }

            public DataColumn OPCINASTANOVANJANAZIVOPCINEColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJANAZIVOPCINE;
                }
            }

            public DataColumn OPCINASTANOVANJAPRIREZColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAPRIREZ;
                }
            }

            public DataColumn OPCINASTANOVANJAVBDIOPCINAColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAVBDIOPCINA;
                }
            }

            public DataColumn OPCINASTANOVANJAZRNOPCINAColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAZRNOPCINA;
                }
            }

            public DataColumn VBDIBANKEColumn
            {
                get
                {
                    return this.columnVBDIBANKE;
                }
            }

            public DataColumn ZRNBANKEColumn
            {
                get
                {
                    return this.columnZRNBANKE;
                }
            }
        }

        public class DDRADNIKRow : DataRow
        {
            private DDRADNIKDataSet.DDRADNIKDataTable tableDDRADNIK;

            internal DDRADNIKRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDRADNIK = (DDRADNIKDataSet.DDRADNIKDataTable) this.Table;
            }

            public bool IsDDADRESANull()
            {
                return this.IsNull(this.tableDDRADNIK.DDADRESAColumn);
            }

            public bool IsDDDRUGISTUPNull()
            {
                return this.IsNull(this.tableDDRADNIK.DDDRUGISTUPColumn);
            }

            public bool IsDDIDRADNIKNull()
            {
                return this.IsNull(this.tableDDRADNIK.DDIDRADNIKColumn);
            }

            public bool IsDDIMENull()
            {
                return this.IsNull(this.tableDDRADNIK.DDIMEColumn);
            }

            public bool IsDDJMBGNull()
            {
                return this.IsNull(this.tableDDRADNIK.DDJMBGColumn);
            }

            public bool IsDDKUCNIBROJNull()
            {
                return this.IsNull(this.tableDDRADNIK.DDKUCNIBROJColumn);
            }

            public bool IsDDMJESTONull()
            {
                return this.IsNull(this.tableDDRADNIK.DDMJESTOColumn);
            }

            public bool IsDDMONull()
            {
                return this.IsNull(this.tableDDRADNIK.DDMOColumn);
            }

            public bool IsDDOIBNull()
            {
                return this.IsNull(this.tableDDRADNIK.DDOIBColumn);
            }

            public bool IsDDOPISPLACANJANETONull()
            {
                return this.IsNull(this.tableDDRADNIK.DDOPISPLACANJANETOColumn);
            }

            public bool IsDDPBONull()
            {
                return this.IsNull(this.tableDDRADNIK.DDPBOColumn);
            }

            public bool IsDDPDVOBVEZNIKNull()
            {
                return this.IsNull(this.tableDDRADNIK.DDPDVOBVEZNIKColumn);
            }

            public bool IsDDPREZIMENull()
            {
                return this.IsNull(this.tableDDRADNIK.DDPREZIMEColumn);
            }

            public bool IsAktivanNull()
            {
                return this.IsNull(this.tableDDRADNIK.AktivanColumn);
            }

            public bool IsDDSIFRAOPISAPLACANJANETONull()
            {
                return this.IsNull(this.tableDDRADNIK.DDSIFRAOPISAPLACANJANETOColumn);
            }

            public bool IsDDZBIRNINETONull()
            {
                return this.IsNull(this.tableDDRADNIK.DDZBIRNINETOColumn);
            }

            public bool IsDDZRNNull()
            {
                return this.IsNull(this.tableDDRADNIK.DDZRNColumn);
            }

            public bool IsIDBANKENull()
            {
                return this.IsNull(this.tableDDRADNIK.IDBANKEColumn);
            }

            public bool IsNAZIVBANKE1Null()
            {
                return this.IsNull(this.tableDDRADNIK.NAZIVBANKE1Column);
            }

            public bool IsNAZIVBANKE2Null()
            {
                return this.IsNull(this.tableDDRADNIK.NAZIVBANKE2Column);
            }

            public bool IsNAZIVBANKE3Null()
            {
                return this.IsNull(this.tableDDRADNIK.NAZIVBANKE3Column);
            }

            public bool IsOPCINARADAIDOPCINENull()
            {
                return this.IsNull(this.tableDDRADNIK.OPCINARADAIDOPCINEColumn);
            }

            public bool IsOPCINARADANAZIVOPCINENull()
            {
                return this.IsNull(this.tableDDRADNIK.OPCINARADANAZIVOPCINEColumn);
            }

            public bool IsOPCINASTANOVANJAIDOPCINENull()
            {
                return this.IsNull(this.tableDDRADNIK.OPCINASTANOVANJAIDOPCINEColumn);
            }

            public bool IsOPCINASTANOVANJANAZIVOPCINENull()
            {
                return this.IsNull(this.tableDDRADNIK.OPCINASTANOVANJANAZIVOPCINEColumn);
            }

            public bool IsOPCINASTANOVANJAPRIREZNull()
            {
                return this.IsNull(this.tableDDRADNIK.OPCINASTANOVANJAPRIREZColumn);
            }

            public bool IsOPCINASTANOVANJAVBDIOPCINANull()
            {
                return this.IsNull(this.tableDDRADNIK.OPCINASTANOVANJAVBDIOPCINAColumn);
            }

            public bool IsOPCINASTANOVANJAZRNOPCINANull()
            {
                return this.IsNull(this.tableDDRADNIK.OPCINASTANOVANJAZRNOPCINAColumn);
            }

            public bool IsVBDIBANKENull()
            {
                return this.IsNull(this.tableDDRADNIK.VBDIBANKEColumn);
            }

            public bool IsZRNBANKENull()
            {
                return this.IsNull(this.tableDDRADNIK.ZRNBANKEColumn);
            }

            public void SetDDADRESANull()
            {
                this[this.tableDDRADNIK.DDADRESAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDDRUGISTUPNull()
            {
                this[this.tableDDRADNIK.DDDRUGISTUPColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDIMENull()
            {
                this[this.tableDDRADNIK.DDIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDJMBGNull()
            {
                this[this.tableDDRADNIK.DDJMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDKUCNIBROJNull()
            {
                this[this.tableDDRADNIK.DDKUCNIBROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDMJESTONull()
            {
                this[this.tableDDRADNIK.DDMJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetAktivanNull()
            {
                this[this.tableDDRADNIK.AktivanColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDMONull()
            {
                this[this.tableDDRADNIK.DDMOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOIBNull()
            {
                this[this.tableDDRADNIK.DDOIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOPISPLACANJANETONull()
            {
                this[this.tableDDRADNIK.DDOPISPLACANJANETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPBONull()
            {
                this[this.tableDDRADNIK.DDPBOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPDVOBVEZNIKNull()
            {
                this[this.tableDDRADNIK.DDPDVOBVEZNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPREZIMENull()
            {
                this[this.tableDDRADNIK.DDPREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDSIFRAOPISAPLACANJANETONull()
            {
                this[this.tableDDRADNIK.DDSIFRAOPISAPLACANJANETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDZBIRNINETONull()
            {
                this[this.tableDDRADNIK.DDZBIRNINETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDZRNNull()
            {
                this[this.tableDDRADNIK.DDZRNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDBANKENull()
            {
                this[this.tableDDRADNIK.IDBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE1Null()
            {
                this[this.tableDDRADNIK.NAZIVBANKE1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE2Null()
            {
                this[this.tableDDRADNIK.NAZIVBANKE2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE3Null()
            {
                this[this.tableDDRADNIK.NAZIVBANKE3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINARADAIDOPCINENull()
            {
                this[this.tableDDRADNIK.OPCINARADAIDOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINARADANAZIVOPCINENull()
            {
                this[this.tableDDRADNIK.OPCINARADANAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAIDOPCINENull()
            {
                this[this.tableDDRADNIK.OPCINASTANOVANJAIDOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJANAZIVOPCINENull()
            {
                this[this.tableDDRADNIK.OPCINASTANOVANJANAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAPRIREZNull()
            {
                this[this.tableDDRADNIK.OPCINASTANOVANJAPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAVBDIOPCINANull()
            {
                this[this.tableDDRADNIK.OPCINASTANOVANJAVBDIOPCINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAZRNOPCINANull()
            {
                this[this.tableDDRADNIK.OPCINASTANOVANJAZRNOPCINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIBANKENull()
            {
                this[this.tableDDRADNIK.VBDIBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNBANKENull()
            {
                this[this.tableDDRADNIK.ZRNBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string DDADRESA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.DDADRESAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDADRESA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.DDADRESAColumn] = value;
                }
            }

            public bool DDDRUGISTUP
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableDDRADNIK.DDDRUGISTUPColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDDRUGISTUP because it is DBNull.", innerException);
                    }
                    return flag;
                }
                set
                {
                    this[this.tableDDRADNIK.DDDRUGISTUPColumn] = value;
                }
            }

            public int DDIDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDRADNIK.DDIDRADNIKColumn]);
                }
                set
                {
                    this[this.tableDDRADNIK.DDIDRADNIKColumn] = value;
                }
            }

            public string DDIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.DDIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDIME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.DDIMEColumn] = value;
                }
            }

            public string DDJMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.DDJMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.DDJMBGColumn] = value;
                }
            }

            public string DDKUCNIBROJ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.DDKUCNIBROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.DDKUCNIBROJColumn] = value;
                }
            }

            public string DDMJESTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.DDMJESTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.DDMJESTOColumn] = value;
                }
            }

            public string DDMO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.DDMOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.DDMOColumn] = value;
                }
            }

            public string DDOIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.DDOIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.DDOIBColumn] = value;
                }
            }

            public string DDOPISPLACANJANETO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.DDOPISPLACANJANETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.DDOPISPLACANJANETOColumn] = value;
                }
            }

            public string DDPBO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.DDPBOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.DDPBOColumn] = value;
                }
            }

            public bool DDPDVOBVEZNIK
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableDDRADNIK.DDPDVOBVEZNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableDDRADNIK.DDPDVOBVEZNIKColumn] = value;
                }
            }

            public string DDPREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.DDPREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.DDPREZIMEColumn] = value;
                }
            }

            public string DDSIFRAOPISAPLACANJANETO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.DDSIFRAOPISAPLACANJANETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.DDSIFRAOPISAPLACANJANETOColumn] = value;
                }
            }

            public bool DDZBIRNINETO
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableDDRADNIK.DDZBIRNINETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableDDRADNIK.DDZBIRNINETOColumn] = value;
                }
            }

            public bool Aktivan
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableDDRADNIK.AktivanColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableDDRADNIK.AktivanColumn] = value;
                }
            }

            public string DDZRN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.DDZRNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.DDZRNColumn] = value;
                }
            }

            public int IDBANKE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableDDRADNIK.IDBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDRADNIK.IDBANKEColumn] = value;
                }
            }

            public string NAZIVBANKE1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.NAZIVBANKE1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.NAZIVBANKE1Column] = value;
                }
            }

            public string NAZIVBANKE2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.NAZIVBANKE2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.NAZIVBANKE2Column] = value;
                }
            }

            public string NAZIVBANKE3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.NAZIVBANKE3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.NAZIVBANKE3Column] = value;
                }
            }

            public string OPCINARADAIDOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.OPCINARADAIDOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.OPCINARADAIDOPCINEColumn] = value;
                }
            }

            public string OPCINARADANAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.OPCINARADANAZIVOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.OPCINARADANAZIVOPCINEColumn] = value;
                }
            }

            public string OPCINASTANOVANJAIDOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.OPCINASTANOVANJAIDOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.OPCINASTANOVANJAIDOPCINEColumn] = value;
                }
            }

            public string OPCINASTANOVANJANAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.OPCINASTANOVANJANAZIVOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.OPCINASTANOVANJANAZIVOPCINEColumn] = value;
                }
            }

            public decimal OPCINASTANOVANJAPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDRADNIK.OPCINASTANOVANJAPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDRADNIK.OPCINASTANOVANJAPRIREZColumn] = value;
                }
            }

            public string OPCINASTANOVANJAVBDIOPCINA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.OPCINASTANOVANJAVBDIOPCINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.OPCINASTANOVANJAVBDIOPCINAColumn] = value;
                }
            }

            public string OPCINASTANOVANJAZRNOPCINA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.OPCINASTANOVANJAZRNOPCINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.OPCINASTANOVANJAZRNOPCINAColumn] = value;
                }
            }

            public string VBDIBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.VBDIBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.VBDIBANKEColumn] = value;
                }
            }

            public string ZRNBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDRADNIK.ZRNBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDRADNIK.ZRNBANKEColumn] = value;
                }
            }
        }

        public class DDRADNIKRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDRADNIKDataSet.DDRADNIKRow eventRow;

            public DDRADNIKRowChangeEvent(DDRADNIKDataSet.DDRADNIKRow row, DataRowAction action)
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

            public DDRADNIKDataSet.DDRADNIKRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDRADNIKRowChangeEventHandler(object sender, DDRADNIKDataSet.DDRADNIKRowChangeEvent e);
    }
}

