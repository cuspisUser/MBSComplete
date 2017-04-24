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
    public class S_OD_KONACNI_POREZ_PO_OPCINAMADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_KONACNI_POREZ_PO_OPCINAMADataTable tableS_OD_KONACNI_POREZ_PO_OPCINAMA;

        public S_OD_KONACNI_POREZ_PO_OPCINAMADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_KONACNI_POREZ_PO_OPCINAMADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_KONACNI_POREZ_PO_OPCINAMA"] != null)
                    {
                        this.Tables.Add(new S_OD_KONACNI_POREZ_PO_OPCINAMADataTable(dataSet.Tables["S_OD_KONACNI_POREZ_PO_OPCINAMA"]));
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
            S_OD_KONACNI_POREZ_PO_OPCINAMADataSet set = (S_OD_KONACNI_POREZ_PO_OPCINAMADataSet) base.Clone();
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
            S_OD_KONACNI_POREZ_PO_OPCINAMADataSet set = new S_OD_KONACNI_POREZ_PO_OPCINAMADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_KONACNI_POREZ_PO_OPCINAMADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2137");
            this.ExtendedProperties.Add("DataSetName", "S_OD_KONACNI_POREZ_PO_OPCINAMADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_KONACNI_POREZ_PO_OPCINAMADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_KONACNI_POREZ_PO_OPCINAMA");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_KONACNI_POREZ_PO_OPCINAMA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_KONACNI_POREZ_PO_OPCINAMA");
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
            this.DataSetName = "S_OD_KONACNI_POREZ_PO_OPCINAMADataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_KONACNI_POREZ_PO_OPCINAMA";
            this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA = new S_OD_KONACNI_POREZ_PO_OPCINAMADataTable();
            this.Tables.Add(this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA);
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
            this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA = (S_OD_KONACNI_POREZ_PO_OPCINAMADataTable) this.Tables["S_OD_KONACNI_POREZ_PO_OPCINAMA"];
            if (initTable && (this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA != null))
            {
                this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_KONACNI_POREZ_PO_OPCINAMA"] != null)
                {
                    this.Tables.Add(new S_OD_KONACNI_POREZ_PO_OPCINAMADataTable(dataSet.Tables["S_OD_KONACNI_POREZ_PO_OPCINAMA"]));
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

        private bool ShouldSerializeS_OD_KONACNI_POREZ_PO_OPCINAMA()
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
        public S_OD_KONACNI_POREZ_PO_OPCINAMADataTable S_OD_KONACNI_POREZ_PO_OPCINAMA
        {
            get
            {
                return this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA;
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
        public class S_OD_KONACNI_POREZ_PO_OPCINAMADataTable : DataTable, IEnumerable
        {
            private DataColumn columnNAZIVOPCINE;
            private DataColumn columnOBRACUNATOPOREZ;
            private DataColumn columnOBRACUNATOPRIREZ;
            private DataColumn columnSIFRAOPCINESTANOVANJA;

            public event S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEventHandler S_OD_KONACNI_POREZ_PO_OPCINAMARowChanged;

            public event S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEventHandler S_OD_KONACNI_POREZ_PO_OPCINAMARowChanging;

            public event S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEventHandler S_OD_KONACNI_POREZ_PO_OPCINAMARowDeleted;

            public event S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEventHandler S_OD_KONACNI_POREZ_PO_OPCINAMARowDeleting;

            public S_OD_KONACNI_POREZ_PO_OPCINAMADataTable()
            {
                this.TableName = "S_OD_KONACNI_POREZ_PO_OPCINAMA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_KONACNI_POREZ_PO_OPCINAMADataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_KONACNI_POREZ_PO_OPCINAMADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_KONACNI_POREZ_PO_OPCINAMARow(S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow AddS_OD_KONACNI_POREZ_PO_OPCINAMARow(string sIFRAOPCINESTANOVANJA, string nAZIVOPCINE, decimal oBRACUNATOPOREZ, decimal oBRACUNATOPRIREZ)
            {
                S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow row = (S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow) this.NewRow();
                row.ItemArray = new object[] { sIFRAOPCINESTANOVANJA, nAZIVOPCINE, oBRACUNATOPOREZ, oBRACUNATOPRIREZ };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMADataTable table = (S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_KONACNI_POREZ_PO_OPCINAMADataSet set = new S_OD_KONACNI_POREZ_PO_OPCINAMADataSet();
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
                this.columnSIFRAOPCINESTANOVANJA = new DataColumn("SIFRAOPCINESTANOVANJA", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPCINESTANOVANJA.Caption = "Šifra općine";
                this.columnSIFRAOPCINESTANOVANJA.MaxLength = 4;
                this.columnSIFRAOPCINESTANOVANJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Description", "Šifra općine");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Length", "4");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPCINESTANOVANJA");
                this.Columns.Add(this.columnSIFRAOPCINESTANOVANJA);
                this.columnNAZIVOPCINE = new DataColumn("NAZIVOPCINE", typeof(string), "", MappingType.Element);
                this.columnNAZIVOPCINE.Caption = "Naziv općine";
                this.columnNAZIVOPCINE.MaxLength = 50;
                this.columnNAZIVOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Description", "Naziv općine");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOPCINE");
                this.Columns.Add(this.columnNAZIVOPCINE);
                this.columnOBRACUNATOPOREZ = new DataColumn("OBRACUNATOPOREZ", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNATOPOREZ.Caption = "OBRACUNATOPOREZ";
                this.columnOBRACUNATOPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("Description", "OBRACUNATOPOREZ");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNATOPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNATOPOREZ");
                this.Columns.Add(this.columnOBRACUNATOPOREZ);
                this.columnOBRACUNATOPRIREZ = new DataColumn("OBRACUNATOPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNATOPRIREZ.Caption = "OBRACUNATOPRIREZ";
                this.columnOBRACUNATOPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("Description", "OBRACUNATOPRIREZ");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNATOPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNATOPRIREZ");
                this.Columns.Add(this.columnOBRACUNATOPRIREZ);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_KONACNI_POREZ_PO_OPCINAMA");
                this.ExtendedProperties.Add("Description", "S_OD_KONACNI_POREZ_PO_OPCINAMA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnSIFRAOPCINESTANOVANJA = this.Columns["SIFRAOPCINESTANOVANJA"];
                this.columnNAZIVOPCINE = this.Columns["NAZIVOPCINE"];
                this.columnOBRACUNATOPOREZ = this.Columns["OBRACUNATOPOREZ"];
                this.columnOBRACUNATOPRIREZ = this.Columns["OBRACUNATOPRIREZ"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow(builder);
            }

            public S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow NewS_OD_KONACNI_POREZ_PO_OPCINAMARow()
            {
                return (S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_KONACNI_POREZ_PO_OPCINAMARowChanged != null)
                {
                    S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEventHandler handler = this.S_OD_KONACNI_POREZ_PO_OPCINAMARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEvent((S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_KONACNI_POREZ_PO_OPCINAMARowChanging != null)
                {
                    S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEventHandler handler = this.S_OD_KONACNI_POREZ_PO_OPCINAMARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEvent((S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_KONACNI_POREZ_PO_OPCINAMARowDeleted != null)
                {
                    S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEventHandler handler = this.S_OD_KONACNI_POREZ_PO_OPCINAMARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEvent((S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_KONACNI_POREZ_PO_OPCINAMARowDeleting != null)
                {
                    S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEventHandler handler = this.S_OD_KONACNI_POREZ_PO_OPCINAMARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEvent((S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_KONACNI_POREZ_PO_OPCINAMARow(S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow row)
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

            public S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow this[int index]
            {
                get
                {
                    return (S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVOPCINEColumn
            {
                get
                {
                    return this.columnNAZIVOPCINE;
                }
            }

            public DataColumn OBRACUNATOPOREZColumn
            {
                get
                {
                    return this.columnOBRACUNATOPOREZ;
                }
            }

            public DataColumn OBRACUNATOPRIREZColumn
            {
                get
                {
                    return this.columnOBRACUNATOPRIREZ;
                }
            }

            public DataColumn SIFRAOPCINESTANOVANJAColumn
            {
                get
                {
                    return this.columnSIFRAOPCINESTANOVANJA;
                }
            }
        }

        public class S_OD_KONACNI_POREZ_PO_OPCINAMARow : DataRow
        {
            private S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMADataTable tableS_OD_KONACNI_POREZ_PO_OPCINAMA;

            internal S_OD_KONACNI_POREZ_PO_OPCINAMARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA = (S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMADataTable) this.Table;
            }

            public bool IsNAZIVOPCINENull()
            {
                return this.IsNull(this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.NAZIVOPCINEColumn);
            }

            public bool IsOBRACUNATOPOREZNull()
            {
                return this.IsNull(this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.OBRACUNATOPOREZColumn);
            }

            public bool IsOBRACUNATOPRIREZNull()
            {
                return this.IsNull(this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.OBRACUNATOPRIREZColumn);
            }

            public bool IsSIFRAOPCINESTANOVANJANull()
            {
                return this.IsNull(this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.SIFRAOPCINESTANOVANJAColumn);
            }

            public void SetNAZIVOPCINENull()
            {
                this[this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.NAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATOPOREZNull()
            {
                this[this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.OBRACUNATOPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATOPRIREZNull()
            {
                this[this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.OBRACUNATOPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPCINESTANOVANJANull()
            {
                this[this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.SIFRAOPCINESTANOVANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string NAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.NAZIVOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVOPCINE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.NAZIVOPCINEColumn] = value;
                }
            }

            public decimal OBRACUNATOPOREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.OBRACUNATOPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OBRACUNATOPOREZ because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.OBRACUNATOPOREZColumn] = value;
                }
            }

            public decimal OBRACUNATOPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.OBRACUNATOPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OBRACUNATOPRIREZ because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.OBRACUNATOPRIREZColumn] = value;
                }
            }

            public string SIFRAOPCINESTANOVANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.SIFRAOPCINESTANOVANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SIFRAOPCINESTANOVANJA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_KONACNI_POREZ_PO_OPCINAMA.SIFRAOPCINESTANOVANJAColumn] = value;
                }
            }
        }

        public class S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow eventRow;

            public S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEvent(S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow row, DataRowAction action)
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

            public S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEventHandler(object sender, S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARowChangeEvent e);
    }
}

