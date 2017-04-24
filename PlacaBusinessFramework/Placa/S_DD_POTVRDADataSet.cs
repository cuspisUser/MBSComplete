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
    public class S_DD_POTVRDADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_DD_POTVRDADataTable tableS_DD_POTVRDA;

        public S_DD_POTVRDADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_DD_POTVRDADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_DD_POTVRDA"] != null)
                    {
                        this.Tables.Add(new S_DD_POTVRDADataTable(dataSet.Tables["S_DD_POTVRDA"]));
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
            S_DD_POTVRDADataSet set = (S_DD_POTVRDADataSet) base.Clone();
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
            S_DD_POTVRDADataSet set = new S_DD_POTVRDADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_DD_POTVRDADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2105");
            this.ExtendedProperties.Add("DataSetName", "S_DD_POTVRDADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_DD_POTVRDADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_DD_POTVRDA");
            this.ExtendedProperties.Add("ObjectDescription", "S_DD_POTVRDA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_DD");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_DD_POTVRDA");
            this.ExtendedProperties.Add("Deklarit.GroupByAttributes", "");
            this.ExtendedProperties.Add("Deklarit.GenerateCRUDForDP", "false");
            this.ExtendedProperties.Add("Deklarit.ExtendedView", "false");
            this.ExtendedProperties.Add("Deklarit.ShowGroupByDP", "True");
            this.ExtendedProperties.Add("Deklarit.UseSuggestInFK", "False");
            this.ExtendedProperties.Add("Deklarit.BCForNewOption", "");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "S_DD_POTVRDADataSet";
            this.Namespace = "http://www.tempuri.org/S_DD_POTVRDA";
            this.tableS_DD_POTVRDA = new S_DD_POTVRDADataTable();
            this.Tables.Add(this.tableS_DD_POTVRDA);
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
            this.tableS_DD_POTVRDA = (S_DD_POTVRDADataTable) this.Tables["S_DD_POTVRDA"];
            if (initTable && (this.tableS_DD_POTVRDA != null))
            {
                this.tableS_DD_POTVRDA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_DD_POTVRDA"] != null)
                {
                    this.Tables.Add(new S_DD_POTVRDADataTable(dataSet.Tables["S_DD_POTVRDA"]));
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

        private bool ShouldSerializeS_DD_POTVRDA()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public S_DD_POTVRDADataTable S_DD_POTVRDA
        {
            get
            {
                return this.tableS_DD_POTVRDA;
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
        public class S_DD_POTVRDADataTable : DataTable, IEnumerable
        {
            private DataColumn columnADRESA;
            private DataColumn columnBRUTO;
            private DataColumn columnDDDATUMOBRACUNA;
            private DataColumn columnDDIDRADNIK;
            private DataColumn columnDDIME;
            private DataColumn columnDDJMBG;
            private DataColumn columnDDOIB;
            private DataColumn columnDDPREZIME;
            private DataColumn columnDOPRINOSIIZ;
            private DataColumn columnIZDACI;
            private DataColumn columnNAZIVKATEGORIJA;
            private DataColumn columnNETO;
            private DataColumn columnOPCINASTANOVANJAIDOPCINE;
            private DataColumn columnPOREZIPRIREZ;
            private DataColumn columnPOREZKRIZNI;
            private DataColumn columnPOSTOTAKIZDATKA;

            public event S_DD_POTVRDADataSet.S_DD_POTVRDARowChangeEventHandler S_DD_POTVRDARowChanged;

            public event S_DD_POTVRDADataSet.S_DD_POTVRDARowChangeEventHandler S_DD_POTVRDARowChanging;

            public event S_DD_POTVRDADataSet.S_DD_POTVRDARowChangeEventHandler S_DD_POTVRDARowDeleted;

            public event S_DD_POTVRDADataSet.S_DD_POTVRDARowChangeEventHandler S_DD_POTVRDARowDeleting;

            public S_DD_POTVRDADataTable()
            {
                this.TableName = "S_DD_POTVRDA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_DD_POTVRDADataTable(DataTable table) : base(table.TableName)
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

            protected S_DD_POTVRDADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_DD_POTVRDARow(S_DD_POTVRDADataSet.S_DD_POTVRDARow row)
            {
                this.Rows.Add(row);
            }

            public S_DD_POTVRDADataSet.S_DD_POTVRDARow AddS_DD_POTVRDARow(int dDIDRADNIK, string dDPREZIME, string dDIME, decimal bRUTO, decimal iZDACI, decimal dOPRINOSIIZ, decimal pOREZIPRIREZ, decimal nETO, string oPCINASTANOVANJAIDOPCINE, DateTime dDDATUMOBRACUNA, string nAZIVKATEGORIJA, decimal pOSTOTAKIZDATKA, string aDRESA, string dDOIB, string dDJMBG, decimal pOREZKRIZNI)
            {
                S_DD_POTVRDADataSet.S_DD_POTVRDARow row = (S_DD_POTVRDADataSet.S_DD_POTVRDARow) this.NewRow();
                row.ItemArray = new object[] { dDIDRADNIK, dDPREZIME, dDIME, bRUTO, iZDACI, dOPRINOSIIZ, pOREZIPRIREZ, nETO, oPCINASTANOVANJAIDOPCINE, dDDATUMOBRACUNA, nAZIVKATEGORIJA, pOSTOTAKIZDATKA, aDRESA, dDOIB, dDJMBG, pOREZKRIZNI };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_DD_POTVRDADataSet.S_DD_POTVRDADataTable table = (S_DD_POTVRDADataSet.S_DD_POTVRDADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_DD_POTVRDADataSet.S_DD_POTVRDARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_DD_POTVRDADataSet set = new S_DD_POTVRDADataSet();
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
                this.columnDDIDRADNIK.Caption = "Šifra";
                this.columnDDIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Description", "Šifra");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Length", "5");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "DDIDRADNIK");
                this.Columns.Add(this.columnDDIDRADNIK);
                this.columnDDPREZIME = new DataColumn("DDPREZIME", typeof(string), "", MappingType.Element);
                this.columnDDPREZIME.Caption = "Prezime";
                this.columnDDPREZIME.MaxLength = 50;
                this.columnDDPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnDDPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnDDPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnDDPREZIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "DDPREZIME");
                this.Columns.Add(this.columnDDPREZIME);
                this.columnDDIME = new DataColumn("DDIME", typeof(string), "", MappingType.Element);
                this.columnDDIME.Caption = "Ime";
                this.columnDDIME.MaxLength = 50;
                this.columnDDIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDIME.ExtendedProperties.Add("IsKey", "false");
                this.columnDDIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDIME.ExtendedProperties.Add("Description", "Ime");
                this.columnDDIME.ExtendedProperties.Add("Length", "50");
                this.columnDDIME.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.InternalName", "DDIME");
                this.Columns.Add(this.columnDDIME);
                this.columnBRUTO = new DataColumn("BRUTO", typeof(decimal), "", MappingType.Element);
                this.columnBRUTO.Caption = "Primici";
                this.columnBRUTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBRUTO.ExtendedProperties.Add("IsKey", "false");
                this.columnBRUTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBRUTO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBRUTO.ExtendedProperties.Add("Description", "Primici");
                this.columnBRUTO.ExtendedProperties.Add("Length", "12");
                this.columnBRUTO.ExtendedProperties.Add("Decimals", "2");
                this.columnBRUTO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBRUTO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBRUTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBRUTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.InternalName", "BRUTO");
                this.Columns.Add(this.columnBRUTO);
                this.columnIZDACI = new DataColumn("IZDACI", typeof(decimal), "", MappingType.Element);
                this.columnIZDACI.Caption = "Izdaci";
                this.columnIZDACI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZDACI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZDACI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZDACI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZDACI.ExtendedProperties.Add("IsKey", "false");
                this.columnIZDACI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZDACI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZDACI.ExtendedProperties.Add("Description", "Izdaci");
                this.columnIZDACI.ExtendedProperties.Add("Length", "12");
                this.columnIZDACI.ExtendedProperties.Add("Decimals", "2");
                this.columnIZDACI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZDACI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZDACI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZDACI.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZDACI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZDACI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZDACI.ExtendedProperties.Add("Deklarit.InternalName", "IZDACI");
                this.Columns.Add(this.columnIZDACI);
                this.columnDOPRINOSIIZ = new DataColumn("DOPRINOSIIZ", typeof(decimal), "", MappingType.Element);
                this.columnDOPRINOSIIZ.Caption = "Doprinosi iz";
                this.columnDOPRINOSIIZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("IsKey", "false");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Description", "Doprinosi iz");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Length", "12");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Decimals", "2");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Deklarit.InternalName", "DOPRINOSIIZ");
                this.Columns.Add(this.columnDOPRINOSIIZ);
                this.columnPOREZIPRIREZ = new DataColumn("POREZIPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnPOREZIPRIREZ.Caption = "Porez i prirez";
                this.columnPOREZIPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Description", "Porez i prirez");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "POREZIPRIREZ");
                this.Columns.Add(this.columnPOREZIPRIREZ);
                this.columnNETO = new DataColumn("NETO", typeof(decimal), "", MappingType.Element);
                this.columnNETO.Caption = "Neto";
                this.columnNETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNETO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNETO.ExtendedProperties.Add("IsKey", "false");
                this.columnNETO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNETO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNETO.ExtendedProperties.Add("Description", "Neto");
                this.columnNETO.ExtendedProperties.Add("Length", "12");
                this.columnNETO.ExtendedProperties.Add("Decimals", "2");
                this.columnNETO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNETO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNETO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNETO.ExtendedProperties.Add("Deklarit.InternalName", "NETO");
                this.Columns.Add(this.columnNETO);
                this.columnOPCINASTANOVANJAIDOPCINE = new DataColumn("OPCINASTANOVANJAIDOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJAIDOPCINE.Caption = "Šifra općine stanovanja";
                this.columnOPCINASTANOVANJAIDOPCINE.MaxLength = 4;
                this.columnOPCINASTANOVANJAIDOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("SuperType", "IDOPCINE");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Description", "Šifra općine stanovanja");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Length", "4");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAIDOPCINE");
                this.Columns.Add(this.columnOPCINASTANOVANJAIDOPCINE);
                this.columnDDDATUMOBRACUNA = new DataColumn("DDDATUMOBRACUNA", typeof(DateTime), "", MappingType.Element);
                this.columnDDDATUMOBRACUNA.Caption = "Datum obračuna";
                this.columnDDDATUMOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Description", "Datum obračuna");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Length", "8");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "DDDATUMOBRACUNA");
                this.Columns.Add(this.columnDDDATUMOBRACUNA);
                this.columnNAZIVKATEGORIJA = new DataColumn("NAZIVKATEGORIJA", typeof(string), "", MappingType.Element);
                this.columnNAZIVKATEGORIJA.Caption = "Kategorija";
                this.columnNAZIVKATEGORIJA.MaxLength = 50;
                this.columnNAZIVKATEGORIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Description", "Kategorija");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKATEGORIJA");
                this.Columns.Add(this.columnNAZIVKATEGORIJA);
                this.columnPOSTOTAKIZDATKA = new DataColumn("POSTOTAKIZDATKA", typeof(decimal), "", MappingType.Element);
                this.columnPOSTOTAKIZDATKA.Caption = "Postotak izdatka";
                this.columnPOSTOTAKIZDATKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("Description", "Postotak izdatka");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("Length", "5");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("Decimals", "2");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.InternalName", "POSTOTAKIZDATKA");
                this.Columns.Add(this.columnPOSTOTAKIZDATKA);
                this.columnADRESA = new DataColumn("ADRESA", typeof(string), "", MappingType.Element);
                this.columnADRESA.Caption = "Adresa";
                this.columnADRESA.MaxLength = 150;
                this.columnADRESA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnADRESA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnADRESA.ExtendedProperties.Add("IsKey", "false");
                this.columnADRESA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnADRESA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnADRESA.ExtendedProperties.Add("Description", "Adresa");
                this.columnADRESA.ExtendedProperties.Add("Length", "150");
                this.columnADRESA.ExtendedProperties.Add("Decimals", "0");
                this.columnADRESA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnADRESA.ExtendedProperties.Add("IsInReader", "true");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.InternalName", "ADRESA");
                this.Columns.Add(this.columnADRESA);
                this.columnDDOIB = new DataColumn("DDOIB", typeof(string), "", MappingType.Element);
                this.columnDDOIB.Caption = "OIB";
                this.columnDDOIB.MaxLength = 11;
                this.columnDDOIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDOIB.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOIB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDOIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOIB.ExtendedProperties.Add("Description", "OIB");
                this.columnDDOIB.ExtendedProperties.Add("Length", "11");
                this.columnDDOIB.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOIB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDOIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.InternalName", "DDOIB");
                this.Columns.Add(this.columnDDOIB);
                this.columnDDJMBG = new DataColumn("DDJMBG", typeof(string), "", MappingType.Element);
                this.columnDDJMBG.Caption = "JMBG";
                this.columnDDJMBG.MaxLength = 13;
                this.columnDDJMBG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDJMBG.ExtendedProperties.Add("IsKey", "false");
                this.columnDDJMBG.ExtendedProperties.Add("ReadOnly", "true");
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
                this.columnPOREZKRIZNI = new DataColumn("POREZKRIZNI", typeof(decimal), "", MappingType.Element);
                this.columnPOREZKRIZNI.Caption = "POREZKRIZNI";
                this.columnPOREZKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Description", "POREZKRIZNI");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Length", "12");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "POREZKRIZNI");
                this.Columns.Add(this.columnPOREZKRIZNI);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_DD_POTVRDA");
                this.ExtendedProperties.Add("Description", "S_DD_POTVRDA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnDDIDRADNIK = this.Columns["DDIDRADNIK"];
                this.columnDDPREZIME = this.Columns["DDPREZIME"];
                this.columnDDIME = this.Columns["DDIME"];
                this.columnBRUTO = this.Columns["BRUTO"];
                this.columnIZDACI = this.Columns["IZDACI"];
                this.columnDOPRINOSIIZ = this.Columns["DOPRINOSIIZ"];
                this.columnPOREZIPRIREZ = this.Columns["POREZIPRIREZ"];
                this.columnNETO = this.Columns["NETO"];
                this.columnOPCINASTANOVANJAIDOPCINE = this.Columns["OPCINASTANOVANJAIDOPCINE"];
                this.columnDDDATUMOBRACUNA = this.Columns["DDDATUMOBRACUNA"];
                this.columnNAZIVKATEGORIJA = this.Columns["NAZIVKATEGORIJA"];
                this.columnPOSTOTAKIZDATKA = this.Columns["POSTOTAKIZDATKA"];
                this.columnADRESA = this.Columns["ADRESA"];
                this.columnDDOIB = this.Columns["DDOIB"];
                this.columnDDJMBG = this.Columns["DDJMBG"];
                this.columnPOREZKRIZNI = this.Columns["POREZKRIZNI"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_DD_POTVRDADataSet.S_DD_POTVRDARow(builder);
            }

            public S_DD_POTVRDADataSet.S_DD_POTVRDARow NewS_DD_POTVRDARow()
            {
                return (S_DD_POTVRDADataSet.S_DD_POTVRDARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_DD_POTVRDARowChanged != null)
                {
                    S_DD_POTVRDADataSet.S_DD_POTVRDARowChangeEventHandler handler = this.S_DD_POTVRDARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_DD_POTVRDADataSet.S_DD_POTVRDARowChangeEvent((S_DD_POTVRDADataSet.S_DD_POTVRDARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_DD_POTVRDARowChanging != null)
                {
                    S_DD_POTVRDADataSet.S_DD_POTVRDARowChangeEventHandler handler = this.S_DD_POTVRDARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_DD_POTVRDADataSet.S_DD_POTVRDARowChangeEvent((S_DD_POTVRDADataSet.S_DD_POTVRDARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_DD_POTVRDARowDeleted != null)
                {
                    S_DD_POTVRDADataSet.S_DD_POTVRDARowChangeEventHandler handler = this.S_DD_POTVRDARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_DD_POTVRDADataSet.S_DD_POTVRDARowChangeEvent((S_DD_POTVRDADataSet.S_DD_POTVRDARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_DD_POTVRDARowDeleting != null)
                {
                    S_DD_POTVRDADataSet.S_DD_POTVRDARowChangeEventHandler handler = this.S_DD_POTVRDARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_DD_POTVRDADataSet.S_DD_POTVRDARowChangeEvent((S_DD_POTVRDADataSet.S_DD_POTVRDARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_DD_POTVRDARow(S_DD_POTVRDADataSet.S_DD_POTVRDARow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn ADRESAColumn
            {
                get
                {
                    return this.columnADRESA;
                }
            }

            public DataColumn BRUTOColumn
            {
                get
                {
                    return this.columnBRUTO;
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

            public DataColumn DDDATUMOBRACUNAColumn
            {
                get
                {
                    return this.columnDDDATUMOBRACUNA;
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

            public DataColumn DDOIBColumn
            {
                get
                {
                    return this.columnDDOIB;
                }
            }

            public DataColumn DDPREZIMEColumn
            {
                get
                {
                    return this.columnDDPREZIME;
                }
            }

            public DataColumn DOPRINOSIIZColumn
            {
                get
                {
                    return this.columnDOPRINOSIIZ;
                }
            }

            public S_DD_POTVRDADataSet.S_DD_POTVRDARow this[int index]
            {
                get
                {
                    return (S_DD_POTVRDADataSet.S_DD_POTVRDARow) this.Rows[index];
                }
            }

            public DataColumn IZDACIColumn
            {
                get
                {
                    return this.columnIZDACI;
                }
            }

            public DataColumn NAZIVKATEGORIJAColumn
            {
                get
                {
                    return this.columnNAZIVKATEGORIJA;
                }
            }

            public DataColumn NETOColumn
            {
                get
                {
                    return this.columnNETO;
                }
            }

            public DataColumn OPCINASTANOVANJAIDOPCINEColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAIDOPCINE;
                }
            }

            public DataColumn POREZIPRIREZColumn
            {
                get
                {
                    return this.columnPOREZIPRIREZ;
                }
            }

            public DataColumn POREZKRIZNIColumn
            {
                get
                {
                    return this.columnPOREZKRIZNI;
                }
            }

            public DataColumn POSTOTAKIZDATKAColumn
            {
                get
                {
                    return this.columnPOSTOTAKIZDATKA;
                }
            }
        }

        public class S_DD_POTVRDARow : DataRow
        {
            private S_DD_POTVRDADataSet.S_DD_POTVRDADataTable tableS_DD_POTVRDA;

            internal S_DD_POTVRDARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_DD_POTVRDA = (S_DD_POTVRDADataSet.S_DD_POTVRDADataTable) this.Table;
            }

            public bool IsADRESANull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.ADRESAColumn);
            }

            public bool IsBRUTONull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.BRUTOColumn);
            }

            public bool IsDDDATUMOBRACUNANull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.DDDATUMOBRACUNAColumn);
            }

            public bool IsDDIDRADNIKNull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.DDIDRADNIKColumn);
            }

            public bool IsDDIMENull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.DDIMEColumn);
            }

            public bool IsDDJMBGNull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.DDJMBGColumn);
            }

            public bool IsDDOIBNull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.DDOIBColumn);
            }

            public bool IsDDPREZIMENull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.DDPREZIMEColumn);
            }

            public bool IsDOPRINOSIIZNull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.DOPRINOSIIZColumn);
            }

            public bool IsIZDACINull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.IZDACIColumn);
            }

            public bool IsNAZIVKATEGORIJANull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.NAZIVKATEGORIJAColumn);
            }

            public bool IsNETONull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.NETOColumn);
            }

            public bool IsOPCINASTANOVANJAIDOPCINENull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.OPCINASTANOVANJAIDOPCINEColumn);
            }

            public bool IsPOREZIPRIREZNull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.POREZIPRIREZColumn);
            }

            public bool IsPOREZKRIZNINull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.POREZKRIZNIColumn);
            }

            public bool IsPOSTOTAKIZDATKANull()
            {
                return this.IsNull(this.tableS_DD_POTVRDA.POSTOTAKIZDATKAColumn);
            }

            public void SetADRESANull()
            {
                this[this.tableS_DD_POTVRDA.ADRESAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBRUTONull()
            {
                this[this.tableS_DD_POTVRDA.BRUTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDDATUMOBRACUNANull()
            {
                this[this.tableS_DD_POTVRDA.DDDATUMOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDIDRADNIKNull()
            {
                this[this.tableS_DD_POTVRDA.DDIDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDIMENull()
            {
                this[this.tableS_DD_POTVRDA.DDIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDJMBGNull()
            {
                this[this.tableS_DD_POTVRDA.DDJMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOIBNull()
            {
                this[this.tableS_DD_POTVRDA.DDOIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPREZIMENull()
            {
                this[this.tableS_DD_POTVRDA.DDPREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOPRINOSIIZNull()
            {
                this[this.tableS_DD_POTVRDA.DOPRINOSIIZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZDACINull()
            {
                this[this.tableS_DD_POTVRDA.IZDACIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKATEGORIJANull()
            {
                this[this.tableS_DD_POTVRDA.NAZIVKATEGORIJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNETONull()
            {
                this[this.tableS_DD_POTVRDA.NETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAIDOPCINENull()
            {
                this[this.tableS_DD_POTVRDA.OPCINASTANOVANJAIDOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZIPRIREZNull()
            {
                this[this.tableS_DD_POTVRDA.POREZIPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZKRIZNINull()
            {
                this[this.tableS_DD_POTVRDA.POREZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOSTOTAKIZDATKANull()
            {
                this[this.tableS_DD_POTVRDA.POSTOTAKIZDATKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string ADRESA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_POTVRDA.ADRESAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ADRESA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.ADRESAColumn] = value;
                }
            }

            public decimal BRUTO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_POTVRDA.BRUTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BRUTO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.BRUTOColumn] = value;
                }
            }

            public DateTime DDDATUMOBRACUNA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_DD_POTVRDA.DDDATUMOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDDATUMOBRACUNA because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.DDDATUMOBRACUNAColumn] = value;
                }
            }

            public int DDIDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_DD_POTVRDA.DDIDRADNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDIDRADNIK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.DDIDRADNIKColumn] = value;
                }
            }

            public string DDIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_POTVRDA.DDIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.DDIMEColumn] = value;
                }
            }

            public string DDJMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_POTVRDA.DDJMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.DDJMBGColumn] = value;
                }
            }

            public string DDOIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_POTVRDA.DDOIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.DDOIBColumn] = value;
                }
            }

            public string DDPREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_POTVRDA.DDPREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.DDPREZIMEColumn] = value;
                }
            }

            public decimal DOPRINOSIIZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_POTVRDA.DOPRINOSIIZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.DOPRINOSIIZColumn] = value;
                }
            }

            public decimal IZDACI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_POTVRDA.IZDACIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.IZDACIColumn] = value;
                }
            }

            public string NAZIVKATEGORIJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_POTVRDA.NAZIVKATEGORIJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.NAZIVKATEGORIJAColumn] = value;
                }
            }

            public decimal NETO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_POTVRDA.NETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.NETOColumn] = value;
                }
            }

            public string OPCINASTANOVANJAIDOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_POTVRDA.OPCINASTANOVANJAIDOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.OPCINASTANOVANJAIDOPCINEColumn] = value;
                }
            }

            public decimal POREZIPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_POTVRDA.POREZIPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.POREZIPRIREZColumn] = value;
                }
            }

            public decimal POREZKRIZNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_POTVRDA.POREZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.POREZKRIZNIColumn] = value;
                }
            }

            public decimal POSTOTAKIZDATKA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_POTVRDA.POSTOTAKIZDATKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_POTVRDA.POSTOTAKIZDATKAColumn] = value;
                }
            }
        }

        public class S_DD_POTVRDARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_DD_POTVRDADataSet.S_DD_POTVRDARow eventRow;

            public S_DD_POTVRDARowChangeEvent(S_DD_POTVRDADataSet.S_DD_POTVRDARow row, DataRowAction action)
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

            public S_DD_POTVRDADataSet.S_DD_POTVRDARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_DD_POTVRDARowChangeEventHandler(object sender, S_DD_POTVRDADataSet.S_DD_POTVRDARowChangeEvent e);
    }
}

