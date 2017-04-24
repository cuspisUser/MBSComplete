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
    public class S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable tableS_FIN_FINANCIJSKO_UPRAVLJANJE;

        public S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_FIN_FINANCIJSKO_UPRAVLJANJE"] != null)
                    {
                        this.Tables.Add(new S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable(dataSet.Tables["S_FIN_FINANCIJSKO_UPRAVLJANJE"]));
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
            S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet set = (S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet) base.Clone();
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
            S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet set = new S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_FIN_FINANCIJSKO_UPRAVLJANJEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2193");
            this.ExtendedProperties.Add("DataSetName", "S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_FIN_FINANCIJSKO_UPRAVLJANJEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_FIN_FINANCIJSKO_UPRAVLJANJE");
            this.ExtendedProperties.Add("ObjectDescription", "S_FIN_FINANCIJSKO_UPRAVLJANJE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_FIN_FINANCIJSKO_UPRAVLJANJE");
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
            this.DataSetName = "S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet";
            this.Namespace = "http://www.tempuri.org/S_FIN_FINANCIJSKO_UPRAVLJANJE";
            this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE = new S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable();
            this.Tables.Add(this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE);
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
            this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE = (S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable) this.Tables["S_FIN_FINANCIJSKO_UPRAVLJANJE"];
            if (initTable && (this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE != null))
            {
                this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_FIN_FINANCIJSKO_UPRAVLJANJE"] != null)
                {
                    this.Tables.Add(new S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable(dataSet.Tables["S_FIN_FINANCIJSKO_UPRAVLJANJE"]));
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

        private bool ShouldSerializeS_FIN_FINANCIJSKO_UPRAVLJANJE()
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
        public S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable S_FIN_FINANCIJSKO_UPRAVLJANJE
        {
            get
            {
                return this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE;
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
        public class S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDMJESTOTROSKA;
            private DataColumn columnIDORGJED;
            private DataColumn columnNAZIVMJESTOTROSKA;
            private DataColumn columnNAZIVORGJED;
            private DataColumn columnNENAPLACENO;
            private DataColumn columnPRIHODI;
            private DataColumn columnRASHODI;
            private DataColumn columnVISAK_ILI_MANJAK_PRETHODNIH;
            private DataColumn columnVISAK_ILI_MANJAK_TEKUCE;
            private DataColumn columnVISAK_ILI_MANJAK_UKUPNI;

            public event S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEventHandler S_FIN_FINANCIJSKO_UPRAVLJANJERowChanged;

            public event S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEventHandler S_FIN_FINANCIJSKO_UPRAVLJANJERowChanging;

            public event S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEventHandler S_FIN_FINANCIJSKO_UPRAVLJANJERowDeleted;

            public event S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEventHandler S_FIN_FINANCIJSKO_UPRAVLJANJERowDeleting;

            public S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable()
            {
                this.TableName = "S_FIN_FINANCIJSKO_UPRAVLJANJE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable(DataTable table) : base(table.TableName)
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

            protected S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_FIN_FINANCIJSKO_UPRAVLJANJERow(S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow row)
            {
                this.Rows.Add(row);
            }

            public S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow AddS_FIN_FINANCIJSKO_UPRAVLJANJERow(int iDORGJED, string nAZIVORGJED, decimal vISAK_ILI_MANJAK_PRETHODNIH, decimal pRIHODI, decimal rASHODI, decimal vISAK_ILI_MANJAK_TEKUCE, decimal vISAK_ILI_MANJAK_UKUPNI, decimal nENAPLACENO, int iDMJESTOTROSKA, string nAZIVMJESTOTROSKA)
            {
                S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow row = (S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow) this.NewRow();
                row.ItemArray = new object[] { iDORGJED, nAZIVORGJED, vISAK_ILI_MANJAK_PRETHODNIH, pRIHODI, rASHODI, vISAK_ILI_MANJAK_TEKUCE, vISAK_ILI_MANJAK_UKUPNI, nENAPLACENO, iDMJESTOTROSKA, nAZIVMJESTOTROSKA };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable table = (S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet set = new S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet();
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
                this.columnIDORGJED = new DataColumn("IDORGJED", typeof(int), "", MappingType.Element);
                this.columnIDORGJED.Caption = "Šifra OJ";
                this.columnIDORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDORGJED.ExtendedProperties.Add("IsKey", "false");
                this.columnIDORGJED.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDORGJED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDORGJED.ExtendedProperties.Add("Description", "Šifra OJ");
                this.columnIDORGJED.ExtendedProperties.Add("Length", "8");
                this.columnIDORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnIDORGJED.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDORGJED.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.InternalName", "IDORGJED");
                this.Columns.Add(this.columnIDORGJED);
                this.columnNAZIVORGJED = new DataColumn("NAZIVORGJED", typeof(string), "", MappingType.Element);
                this.columnNAZIVORGJED.Caption = "Naziv OJ";
                this.columnNAZIVORGJED.MaxLength = 100;
                this.columnNAZIVORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.RelevantData", "false");
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
                this.columnVISAK_ILI_MANJAK_PRETHODNIH = new DataColumn("VISAK_ILI_MANJAK_PRETHODNIH", typeof(decimal), "", MappingType.Element);
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.Caption = "VISAK  ILI  MANJAK  PRETHODNIH";
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("IsKey", "false");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("DeklaritType", "int");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("Description", "VISAK  ILI  MANJAK  PRETHODNIH");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("Length", "12");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("Decimals", "2");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("IsInReader", "true");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVISAK_ILI_MANJAK_PRETHODNIH.ExtendedProperties.Add("Deklarit.InternalName", "VISAK_ILI_MANJAK_PRETHODNIH");
                this.Columns.Add(this.columnVISAK_ILI_MANJAK_PRETHODNIH);
                this.columnPRIHODI = new DataColumn("PRIHODI", typeof(decimal), "", MappingType.Element);
                this.columnPRIHODI.Caption = "PRIHODI";
                this.columnPRIHODI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIHODI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIHODI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIHODI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRIHODI.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIHODI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIHODI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRIHODI.ExtendedProperties.Add("Description", "PRIHODI");
                this.columnPRIHODI.ExtendedProperties.Add("Length", "12");
                this.columnPRIHODI.ExtendedProperties.Add("Decimals", "2");
                this.columnPRIHODI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRIHODI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPRIHODI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIHODI.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIHODI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIHODI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIHODI.ExtendedProperties.Add("Deklarit.InternalName", "PRIHODI");
                this.Columns.Add(this.columnPRIHODI);
                this.columnRASHODI = new DataColumn("RASHODI", typeof(decimal), "", MappingType.Element);
                this.columnRASHODI.Caption = "RASHODI";
                this.columnRASHODI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRASHODI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRASHODI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRASHODI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnRASHODI.ExtendedProperties.Add("IsKey", "false");
                this.columnRASHODI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnRASHODI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRASHODI.ExtendedProperties.Add("Description", "RASHODI");
                this.columnRASHODI.ExtendedProperties.Add("Length", "12");
                this.columnRASHODI.ExtendedProperties.Add("Decimals", "2");
                this.columnRASHODI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnRASHODI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnRASHODI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRASHODI.ExtendedProperties.Add("IsInReader", "true");
                this.columnRASHODI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRASHODI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRASHODI.ExtendedProperties.Add("Deklarit.InternalName", "RASHODI");
                this.Columns.Add(this.columnRASHODI);
                this.columnVISAK_ILI_MANJAK_TEKUCE = new DataColumn("VISAK_ILI_MANJAK_TEKUCE", typeof(decimal), "", MappingType.Element);
                this.columnVISAK_ILI_MANJAK_TEKUCE.Caption = "VISAK  ILI  MANJAK  TEKUCE";
                this.columnVISAK_ILI_MANJAK_TEKUCE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("IsKey", "false");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("Description", "VISAK  ILI  MANJAK  TEKUCE");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("Length", "12");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("Decimals", "2");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("IsInReader", "true");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVISAK_ILI_MANJAK_TEKUCE.ExtendedProperties.Add("Deklarit.InternalName", "VISAK_ILI_MANJAK_TEKUCE");
                this.Columns.Add(this.columnVISAK_ILI_MANJAK_TEKUCE);
                this.columnVISAK_ILI_MANJAK_UKUPNI = new DataColumn("VISAK_ILI_MANJAK_UKUPNI", typeof(decimal), "", MappingType.Element);
                this.columnVISAK_ILI_MANJAK_UKUPNI.Caption = "VISAK  ILI  MANJAK  UKUPNI";
                this.columnVISAK_ILI_MANJAK_UKUPNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("IsKey", "false");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("Description", "VISAK  ILI  MANJAK  UKUPNI");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("Length", "12");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("Decimals", "2");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVISAK_ILI_MANJAK_UKUPNI.ExtendedProperties.Add("Deklarit.InternalName", "VISAK_ILI_MANJAK_UKUPNI");
                this.Columns.Add(this.columnVISAK_ILI_MANJAK_UKUPNI);
                this.columnNENAPLACENO = new DataColumn("NENAPLACENO", typeof(decimal), "", MappingType.Element);
                this.columnNENAPLACENO.Caption = "NENAPLACENO";
                this.columnNENAPLACENO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNENAPLACENO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNENAPLACENO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNENAPLACENO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNENAPLACENO.ExtendedProperties.Add("IsKey", "false");
                this.columnNENAPLACENO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNENAPLACENO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNENAPLACENO.ExtendedProperties.Add("Description", "NENAPLACENO");
                this.columnNENAPLACENO.ExtendedProperties.Add("Length", "12");
                this.columnNENAPLACENO.ExtendedProperties.Add("Decimals", "2");
                this.columnNENAPLACENO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNENAPLACENO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNENAPLACENO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNENAPLACENO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNENAPLACENO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNENAPLACENO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNENAPLACENO.ExtendedProperties.Add("Deklarit.InternalName", "NENAPLACENO");
                this.Columns.Add(this.columnNENAPLACENO);
                this.columnIDMJESTOTROSKA = new DataColumn("IDMJESTOTROSKA", typeof(int), "", MappingType.Element);
                this.columnIDMJESTOTROSKA.Caption = "Šifra MT";
                this.columnIDMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Description", "Šifra MT");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Length", "8");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "IDMJESTOTROSKA");
                this.Columns.Add(this.columnIDMJESTOTROSKA);
                this.columnNAZIVMJESTOTROSKA = new DataColumn("NAZIVMJESTOTROSKA", typeof(string), "", MappingType.Element);
                this.columnNAZIVMJESTOTROSKA.Caption = "Naziv MT";
                this.columnNAZIVMJESTOTROSKA.MaxLength = 120;
                this.columnNAZIVMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
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
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_FIN_FINANCIJSKO_UPRAVLJANJE");
                this.ExtendedProperties.Add("Description", "S_FIN_FINANCIJSKO_UPRAVLJANJE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDORGJED = this.Columns["IDORGJED"];
                this.columnNAZIVORGJED = this.Columns["NAZIVORGJED"];
                this.columnVISAK_ILI_MANJAK_PRETHODNIH = this.Columns["VISAK_ILI_MANJAK_PRETHODNIH"];
                this.columnPRIHODI = this.Columns["PRIHODI"];
                this.columnRASHODI = this.Columns["RASHODI"];
                this.columnVISAK_ILI_MANJAK_TEKUCE = this.Columns["VISAK_ILI_MANJAK_TEKUCE"];
                this.columnVISAK_ILI_MANJAK_UKUPNI = this.Columns["VISAK_ILI_MANJAK_UKUPNI"];
                this.columnNENAPLACENO = this.Columns["NENAPLACENO"];
                this.columnIDMJESTOTROSKA = this.Columns["IDMJESTOTROSKA"];
                this.columnNAZIVMJESTOTROSKA = this.Columns["NAZIVMJESTOTROSKA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow(builder);
            }

            public S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow NewS_FIN_FINANCIJSKO_UPRAVLJANJERow()
            {
                return (S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_FIN_FINANCIJSKO_UPRAVLJANJERowChanged != null)
                {
                    S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEventHandler handler = this.S_FIN_FINANCIJSKO_UPRAVLJANJERowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEvent((S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_FIN_FINANCIJSKO_UPRAVLJANJERowChanging != null)
                {
                    S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEventHandler handler = this.S_FIN_FINANCIJSKO_UPRAVLJANJERowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEvent((S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_FIN_FINANCIJSKO_UPRAVLJANJERowDeleted != null)
                {
                    S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEventHandler handler = this.S_FIN_FINANCIJSKO_UPRAVLJANJERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEvent((S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_FIN_FINANCIJSKO_UPRAVLJANJERowDeleting != null)
                {
                    S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEventHandler handler = this.S_FIN_FINANCIJSKO_UPRAVLJANJERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEvent((S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_FIN_FINANCIJSKO_UPRAVLJANJERow(S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow row)
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

            public S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow this[int index]
            {
                get
                {
                    return (S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow) this.Rows[index];
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

            public DataColumn NENAPLACENOColumn
            {
                get
                {
                    return this.columnNENAPLACENO;
                }
            }

            public DataColumn PRIHODIColumn
            {
                get
                {
                    return this.columnPRIHODI;
                }
            }

            public DataColumn RASHODIColumn
            {
                get
                {
                    return this.columnRASHODI;
                }
            }

            public DataColumn VISAK_ILI_MANJAK_PRETHODNIHColumn
            {
                get
                {
                    return this.columnVISAK_ILI_MANJAK_PRETHODNIH;
                }
            }

            public DataColumn VISAK_ILI_MANJAK_TEKUCEColumn
            {
                get
                {
                    return this.columnVISAK_ILI_MANJAK_TEKUCE;
                }
            }

            public DataColumn VISAK_ILI_MANJAK_UKUPNIColumn
            {
                get
                {
                    return this.columnVISAK_ILI_MANJAK_UKUPNI;
                }
            }
        }

        public class S_FIN_FINANCIJSKO_UPRAVLJANJERow : DataRow
        {
            private S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable tableS_FIN_FINANCIJSKO_UPRAVLJANJE;

            internal S_FIN_FINANCIJSKO_UPRAVLJANJERow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE = (S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJEDataTable) this.Table;
            }

            public bool IsIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.IDMJESTOTROSKAColumn);
            }

            public bool IsIDORGJEDNull()
            {
                return this.IsNull(this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.IDORGJEDColumn);
            }

            public bool IsNAZIVMJESTOTROSKANull()
            {
                return this.IsNull(this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.NAZIVMJESTOTROSKAColumn);
            }

            public bool IsNAZIVORGJEDNull()
            {
                return this.IsNull(this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.NAZIVORGJEDColumn);
            }

            public bool IsNENAPLACENONull()
            {
                return this.IsNull(this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.NENAPLACENOColumn);
            }

            public bool IsPRIHODINull()
            {
                return this.IsNull(this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.PRIHODIColumn);
            }

            public bool IsRASHODINull()
            {
                return this.IsNull(this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.RASHODIColumn);
            }

            public bool IsVISAK_ILI_MANJAK_PRETHODNIHNull()
            {
                return this.IsNull(this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.VISAK_ILI_MANJAK_PRETHODNIHColumn);
            }

            public bool IsVISAK_ILI_MANJAK_TEKUCENull()
            {
                return this.IsNull(this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.VISAK_ILI_MANJAK_TEKUCEColumn);
            }

            public bool IsVISAK_ILI_MANJAK_UKUPNINull()
            {
                return this.IsNull(this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.VISAK_ILI_MANJAK_UKUPNIColumn);
            }

            public void SetIDMJESTOTROSKANull()
            {
                this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.IDMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDORGJEDNull()
            {
                this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.IDORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVMJESTOTROSKANull()
            {
                this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.NAZIVMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVORGJEDNull()
            {
                this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.NAZIVORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNENAPLACENONull()
            {
                this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.NENAPLACENOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIHODINull()
            {
                this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.PRIHODIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRASHODINull()
            {
                this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.RASHODIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVISAK_ILI_MANJAK_PRETHODNIHNull()
            {
                this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.VISAK_ILI_MANJAK_PRETHODNIHColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVISAK_ILI_MANJAK_TEKUCENull()
            {
                this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.VISAK_ILI_MANJAK_TEKUCEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVISAK_ILI_MANJAK_UKUPNINull()
            {
                this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.VISAK_ILI_MANJAK_UKUPNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDMJESTOTROSKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.IDMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDMJESTOTROSKA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.IDMJESTOTROSKAColumn] = value;
                }
            }

            public int IDORGJED
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.IDORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDORGJED because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.IDORGJEDColumn] = value;
                }
            }

            public string NAZIVMJESTOTROSKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.NAZIVMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVMJESTOTROSKA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.NAZIVMJESTOTROSKAColumn] = value;
                }
            }

            public string NAZIVORGJED
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.NAZIVORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.NAZIVORGJEDColumn] = value;
                }
            }

            public decimal NENAPLACENO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.NENAPLACENOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.NENAPLACENOColumn] = value;
                }
            }

            public decimal PRIHODI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.PRIHODIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.PRIHODIColumn] = value;
                }
            }

            public decimal RASHODI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.RASHODIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.RASHODIColumn] = value;
                }
            }

            public decimal VISAK_ILI_MANJAK_PRETHODNIH
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.VISAK_ILI_MANJAK_PRETHODNIHColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.VISAK_ILI_MANJAK_PRETHODNIHColumn] = value;
                }
            }

            public decimal VISAK_ILI_MANJAK_TEKUCE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.VISAK_ILI_MANJAK_TEKUCEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.VISAK_ILI_MANJAK_TEKUCEColumn] = value;
                }
            }

            public decimal VISAK_ILI_MANJAK_UKUPNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.VISAK_ILI_MANJAK_UKUPNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_FINANCIJSKO_UPRAVLJANJE.VISAK_ILI_MANJAK_UKUPNIColumn] = value;
                }
            }
        }

        public class S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow eventRow;

            public S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEvent(S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow row, DataRowAction action)
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

            public S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEventHandler(object sender, S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERowChangeEvent e);
    }
}

