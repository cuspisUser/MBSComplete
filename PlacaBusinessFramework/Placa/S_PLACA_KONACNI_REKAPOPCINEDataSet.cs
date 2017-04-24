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
    public class S_PLACA_KONACNI_REKAPOPCINEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_PLACA_KONACNI_REKAPOPCINEDataTable tableS_PLACA_KONACNI_REKAPOPCINE;

        public S_PLACA_KONACNI_REKAPOPCINEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_PLACA_KONACNI_REKAPOPCINEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_PLACA_KONACNI_REKAPOPCINE"] != null)
                    {
                        this.Tables.Add(new S_PLACA_KONACNI_REKAPOPCINEDataTable(dataSet.Tables["S_PLACA_KONACNI_REKAPOPCINE"]));
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
            S_PLACA_KONACNI_REKAPOPCINEDataSet set = (S_PLACA_KONACNI_REKAPOPCINEDataSet) base.Clone();
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
            S_PLACA_KONACNI_REKAPOPCINEDataSet set = new S_PLACA_KONACNI_REKAPOPCINEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_PLACA_KONACNI_REKAPOPCINEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2145");
            this.ExtendedProperties.Add("DataSetName", "S_PLACA_KONACNI_REKAPOPCINEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_PLACA_KONACNI_REKAPOPCINEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_PLACA_KONACNI_REKAPOPCINE");
            this.ExtendedProperties.Add("ObjectDescription", "S_PLACA_KONACNI_REKAPOPCINE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_KONACNI_REKAPOPCINE");
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
            this.DataSetName = "S_PLACA_KONACNI_REKAPOPCINEDataSet";
            this.Namespace = "http://www.tempuri.org/S_PLACA_KONACNI_REKAPOPCINE";
            this.tableS_PLACA_KONACNI_REKAPOPCINE = new S_PLACA_KONACNI_REKAPOPCINEDataTable();
            this.Tables.Add(this.tableS_PLACA_KONACNI_REKAPOPCINE);
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
            this.tableS_PLACA_KONACNI_REKAPOPCINE = (S_PLACA_KONACNI_REKAPOPCINEDataTable) this.Tables["S_PLACA_KONACNI_REKAPOPCINE"];
            if (initTable && (this.tableS_PLACA_KONACNI_REKAPOPCINE != null))
            {
                this.tableS_PLACA_KONACNI_REKAPOPCINE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_PLACA_KONACNI_REKAPOPCINE"] != null)
                {
                    this.Tables.Add(new S_PLACA_KONACNI_REKAPOPCINEDataTable(dataSet.Tables["S_PLACA_KONACNI_REKAPOPCINE"]));
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

        private bool ShouldSerializeS_PLACA_KONACNI_REKAPOPCINE()
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
        public S_PLACA_KONACNI_REKAPOPCINEDataTable S_PLACA_KONACNI_REKAPOPCINE
        {
            get
            {
                return this.tableS_PLACA_KONACNI_REKAPOPCINE;
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
        public class S_PLACA_KONACNI_REKAPOPCINEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIME;
            private DataColumn columnkucnibroj;
            private DataColumn columnmjesto;
            private DataColumn columnNAZIVOPCINE;
            private DataColumn columnOBRACUNATIPRIREZ;
            private DataColumn columnOBRACUNATOPOREZ;
            private DataColumn columnOIB;
            private DataColumn columnPOREZPOREZNA;
            private DataColumn columnPOREZUKUPNOKOREKCIJA;
            private DataColumn columnPREZIME;
            private DataColumn columnPRIREZPOREZNA;
            private DataColumn columnPRIREZUKUPNOKOREKCIJA;
            private DataColumn columnSIFRAOPCINESTANOVANJA;
            private DataColumn columnulica;

            public event S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERowChangeEventHandler S_PLACA_KONACNI_REKAPOPCINERowChanged;

            public event S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERowChangeEventHandler S_PLACA_KONACNI_REKAPOPCINERowChanging;

            public event S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERowChangeEventHandler S_PLACA_KONACNI_REKAPOPCINERowDeleted;

            public event S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERowChangeEventHandler S_PLACA_KONACNI_REKAPOPCINERowDeleting;

            public S_PLACA_KONACNI_REKAPOPCINEDataTable()
            {
                this.TableName = "S_PLACA_KONACNI_REKAPOPCINE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_PLACA_KONACNI_REKAPOPCINEDataTable(DataTable table) : base(table.TableName)
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

            protected S_PLACA_KONACNI_REKAPOPCINEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_PLACA_KONACNI_REKAPOPCINERow(S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow row)
            {
                this.Rows.Add(row);
            }

            public S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow AddS_PLACA_KONACNI_REKAPOPCINERow(decimal pRIREZPOREZNA, decimal pOREZPOREZNA, string sIFRAOPCINESTANOVANJA, string pREZIME, string iME, string ulica, string mjesto, string kucnibroj, string oIB, string nAZIVOPCINE, decimal oBRACUNATIPRIREZ, decimal oBRACUNATOPOREZ, decimal pOREZUKUPNOKOREKCIJA, decimal pRIREZUKUPNOKOREKCIJA)
            {
                S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow row = (S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow) this.NewRow();
                row.ItemArray = new object[] { pRIREZPOREZNA, pOREZPOREZNA, sIFRAOPCINESTANOVANJA, pREZIME, iME, ulica, mjesto, kucnibroj, oIB, nAZIVOPCINE, oBRACUNATIPRIREZ, oBRACUNATOPOREZ, pOREZUKUPNOKOREKCIJA, pRIREZUKUPNOKOREKCIJA };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINEDataTable table = (S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_PLACA_KONACNI_REKAPOPCINEDataSet set = new S_PLACA_KONACNI_REKAPOPCINEDataSet();
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
                this.columnPRIREZPOREZNA = new DataColumn("PRIREZPOREZNA", typeof(decimal), "", MappingType.Element);
                this.columnPRIREZPOREZNA.Caption = "PRIREZPOREZNA";
                this.columnPRIREZPOREZNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("Description", "PRIREZPOREZNA");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("Length", "12");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("Decimals", "2");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIREZPOREZNA.ExtendedProperties.Add("Deklarit.InternalName", "PRIREZPOREZNA");
                this.Columns.Add(this.columnPRIREZPOREZNA);
                this.columnPOREZPOREZNA = new DataColumn("POREZPOREZNA", typeof(decimal), "", MappingType.Element);
                this.columnPOREZPOREZNA.Caption = "POREZPOREZNA";
                this.columnPOREZPOREZNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZPOREZNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("Description", "POREZPOREZNA");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("Length", "12");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZPOREZNA.ExtendedProperties.Add("Deklarit.InternalName", "POREZPOREZNA");
                this.Columns.Add(this.columnPOREZPOREZNA);
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
                this.columnPREZIME = new DataColumn("PREZIME", typeof(string), "", MappingType.Element);
                this.columnPREZIME.Caption = "Prezime";
                this.columnPREZIME.MaxLength = 50;
                this.columnPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPREZIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "PREZIME");
                this.Columns.Add(this.columnPREZIME);
                this.columnIME = new DataColumn("IME", typeof(string), "", MappingType.Element);
                this.columnIME.Caption = "Ime";
                this.columnIME.MaxLength = 50;
                this.columnIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIME.ExtendedProperties.Add("IsKey", "false");
                this.columnIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIME.ExtendedProperties.Add("Description", "Ime");
                this.columnIME.ExtendedProperties.Add("Length", "50");
                this.columnIME.ExtendedProperties.Add("Decimals", "0");
                this.columnIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.InternalName", "IME");
                this.Columns.Add(this.columnIME);
                this.columnulica = new DataColumn("ulica", typeof(string), "", MappingType.Element);
                this.columnulica.Caption = "Ulica";
                this.columnulica.MaxLength = 50;
                this.columnulica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnulica.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnulica.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnulica.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnulica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnulica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnulica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnulica.ExtendedProperties.Add("IsKey", "false");
                this.columnulica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnulica.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnulica.ExtendedProperties.Add("Description", "Ulica");
                this.columnulica.ExtendedProperties.Add("Length", "50");
                this.columnulica.ExtendedProperties.Add("Decimals", "0");
                this.columnulica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnulica.ExtendedProperties.Add("IsInReader", "true");
                this.columnulica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnulica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnulica.ExtendedProperties.Add("Deklarit.InternalName", "ulica");
                this.Columns.Add(this.columnulica);
                this.columnmjesto = new DataColumn("mjesto", typeof(string), "", MappingType.Element);
                this.columnmjesto.Caption = "Mjesto";
                this.columnmjesto.MaxLength = 50;
                this.columnmjesto.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmjesto.ExtendedProperties.Add("IsKey", "false");
                this.columnmjesto.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmjesto.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnmjesto.ExtendedProperties.Add("Description", "Mjesto");
                this.columnmjesto.ExtendedProperties.Add("Length", "50");
                this.columnmjesto.ExtendedProperties.Add("Decimals", "0");
                this.columnmjesto.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmjesto.ExtendedProperties.Add("IsInReader", "true");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.InternalName", "mjesto");
                this.Columns.Add(this.columnmjesto);
                this.columnkucnibroj = new DataColumn("kucnibroj", typeof(string), "", MappingType.Element);
                this.columnkucnibroj.Caption = "Kućni broj";
                this.columnkucnibroj.MaxLength = 10;
                this.columnkucnibroj.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnkucnibroj.ExtendedProperties.Add("IsKey", "false");
                this.columnkucnibroj.ExtendedProperties.Add("ReadOnly", "true");
                this.columnkucnibroj.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnkucnibroj.ExtendedProperties.Add("Description", "Kućni broj");
                this.columnkucnibroj.ExtendedProperties.Add("Length", "10");
                this.columnkucnibroj.ExtendedProperties.Add("Decimals", "0");
                this.columnkucnibroj.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnkucnibroj.ExtendedProperties.Add("IsInReader", "true");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.InternalName", "kucnibroj");
                this.Columns.Add(this.columnkucnibroj);
                this.columnOIB = new DataColumn("OIB", typeof(string), "", MappingType.Element);
                this.columnOIB.Caption = "OIB";
                this.columnOIB.MaxLength = 11;
                this.columnOIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOIB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOIB.ExtendedProperties.Add("IsKey", "false");
                this.columnOIB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOIB.ExtendedProperties.Add("Description", "OIB");
                this.columnOIB.ExtendedProperties.Add("Length", "11");
                this.columnOIB.ExtendedProperties.Add("Decimals", "0");
                this.columnOIB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOIB.ExtendedProperties.Add("Deklarit.InternalName", "OIB");
                this.Columns.Add(this.columnOIB);
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
                this.columnOBRACUNATIPRIREZ = new DataColumn("OBRACUNATIPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNATIPRIREZ.Caption = "OBRACUNATIPRIREZ";
                this.columnOBRACUNATIPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Description", "OBRACUNATIPRIREZ");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNATIPRIREZ");
                this.Columns.Add(this.columnOBRACUNATIPRIREZ);
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
                this.columnPOREZUKUPNOKOREKCIJA = new DataColumn("POREZUKUPNOKOREKCIJA", typeof(decimal), "", MappingType.Element);
                this.columnPOREZUKUPNOKOREKCIJA.Caption = "POREZUKUPNOKOREKCIJA";
                this.columnPOREZUKUPNOKOREKCIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Description", "POREZUKUPNOKOREKCIJA");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Length", "12");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Deklarit.InternalName", "POREZUKUPNOKOREKCIJA");
                this.Columns.Add(this.columnPOREZUKUPNOKOREKCIJA);
                this.columnPRIREZUKUPNOKOREKCIJA = new DataColumn("PRIREZUKUPNOKOREKCIJA", typeof(decimal), "", MappingType.Element);
                this.columnPRIREZUKUPNOKOREKCIJA.Caption = "PRIREZUKUPNOKOREKCIJA";
                this.columnPRIREZUKUPNOKOREKCIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Description", "PRIREZUKUPNOKOREKCIJA");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Length", "12");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Decimals", "2");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIREZUKUPNOKOREKCIJA.ExtendedProperties.Add("Deklarit.InternalName", "PRIREZUKUPNOKOREKCIJA");
                this.Columns.Add(this.columnPRIREZUKUPNOKOREKCIJA);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_PLACA_KONACNI_REKAPOPCINE");
                this.ExtendedProperties.Add("Description", "S_PLACA_KONACNI_REKAPOPCINE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnPRIREZPOREZNA = this.Columns["PRIREZPOREZNA"];
                this.columnPOREZPOREZNA = this.Columns["POREZPOREZNA"];
                this.columnSIFRAOPCINESTANOVANJA = this.Columns["SIFRAOPCINESTANOVANJA"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnulica = this.Columns["ulica"];
                this.columnmjesto = this.Columns["mjesto"];
                this.columnkucnibroj = this.Columns["kucnibroj"];
                this.columnOIB = this.Columns["OIB"];
                this.columnNAZIVOPCINE = this.Columns["NAZIVOPCINE"];
                this.columnOBRACUNATIPRIREZ = this.Columns["OBRACUNATIPRIREZ"];
                this.columnOBRACUNATOPOREZ = this.Columns["OBRACUNATOPOREZ"];
                this.columnPOREZUKUPNOKOREKCIJA = this.Columns["POREZUKUPNOKOREKCIJA"];
                this.columnPRIREZUKUPNOKOREKCIJA = this.Columns["PRIREZUKUPNOKOREKCIJA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow(builder);
            }

            public S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow NewS_PLACA_KONACNI_REKAPOPCINERow()
            {
                return (S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_PLACA_KONACNI_REKAPOPCINERowChanged != null)
                {
                    S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERowChangeEventHandler handler = this.S_PLACA_KONACNI_REKAPOPCINERowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERowChangeEvent((S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_PLACA_KONACNI_REKAPOPCINERowChanging != null)
                {
                    S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERowChangeEventHandler handler = this.S_PLACA_KONACNI_REKAPOPCINERowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERowChangeEvent((S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_PLACA_KONACNI_REKAPOPCINERowDeleted != null)
                {
                    S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERowChangeEventHandler handler = this.S_PLACA_KONACNI_REKAPOPCINERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERowChangeEvent((S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_PLACA_KONACNI_REKAPOPCINERowDeleting != null)
                {
                    S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERowChangeEventHandler handler = this.S_PLACA_KONACNI_REKAPOPCINERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERowChangeEvent((S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_PLACA_KONACNI_REKAPOPCINERow(S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow row)
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

            public DataColumn IMEColumn
            {
                get
                {
                    return this.columnIME;
                }
            }

            public S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow this[int index]
            {
                get
                {
                    return (S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow) this.Rows[index];
                }
            }

            public DataColumn kucnibrojColumn
            {
                get
                {
                    return this.columnkucnibroj;
                }
            }

            public DataColumn mjestoColumn
            {
                get
                {
                    return this.columnmjesto;
                }
            }

            public DataColumn NAZIVOPCINEColumn
            {
                get
                {
                    return this.columnNAZIVOPCINE;
                }
            }

            public DataColumn OBRACUNATIPRIREZColumn
            {
                get
                {
                    return this.columnOBRACUNATIPRIREZ;
                }
            }

            public DataColumn OBRACUNATOPOREZColumn
            {
                get
                {
                    return this.columnOBRACUNATOPOREZ;
                }
            }

            public DataColumn OIBColumn
            {
                get
                {
                    return this.columnOIB;
                }
            }

            public DataColumn POREZPOREZNAColumn
            {
                get
                {
                    return this.columnPOREZPOREZNA;
                }
            }

            public DataColumn POREZUKUPNOKOREKCIJAColumn
            {
                get
                {
                    return this.columnPOREZUKUPNOKOREKCIJA;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn PRIREZPOREZNAColumn
            {
                get
                {
                    return this.columnPRIREZPOREZNA;
                }
            }

            public DataColumn PRIREZUKUPNOKOREKCIJAColumn
            {
                get
                {
                    return this.columnPRIREZUKUPNOKOREKCIJA;
                }
            }

            public DataColumn SIFRAOPCINESTANOVANJAColumn
            {
                get
                {
                    return this.columnSIFRAOPCINESTANOVANJA;
                }
            }

            public DataColumn ulicaColumn
            {
                get
                {
                    return this.columnulica;
                }
            }
        }

        public class S_PLACA_KONACNI_REKAPOPCINERow : DataRow
        {
            private S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINEDataTable tableS_PLACA_KONACNI_REKAPOPCINE;

            internal S_PLACA_KONACNI_REKAPOPCINERow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_PLACA_KONACNI_REKAPOPCINE = (S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINEDataTable) this.Table;
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.IMEColumn);
            }

            public bool IskucnibrojNull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.kucnibrojColumn);
            }

            public bool IsmjestoNull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.mjestoColumn);
            }

            public bool IsNAZIVOPCINENull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.NAZIVOPCINEColumn);
            }

            public bool IsOBRACUNATIPRIREZNull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.OBRACUNATIPRIREZColumn);
            }

            public bool IsOBRACUNATOPOREZNull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.OBRACUNATOPOREZColumn);
            }

            public bool IsOIBNull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.OIBColumn);
            }

            public bool IsPOREZPOREZNANull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.POREZPOREZNAColumn);
            }

            public bool IsPOREZUKUPNOKOREKCIJANull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.POREZUKUPNOKOREKCIJAColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.PREZIMEColumn);
            }

            public bool IsPRIREZPOREZNANull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.PRIREZPOREZNAColumn);
            }

            public bool IsPRIREZUKUPNOKOREKCIJANull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.PRIREZUKUPNOKOREKCIJAColumn);
            }

            public bool IsSIFRAOPCINESTANOVANJANull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.SIFRAOPCINESTANOVANJAColumn);
            }

            public bool IsulicaNull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_REKAPOPCINE.ulicaColumn);
            }

            public void SetIMENull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetkucnibrojNull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.kucnibrojColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetmjestoNull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.mjestoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOPCINENull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.NAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATIPRIREZNull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.OBRACUNATIPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATOPOREZNull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.OBRACUNATOPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOIBNull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.OIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZPOREZNANull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.POREZPOREZNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZUKUPNOKOREKCIJANull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.POREZUKUPNOKOREKCIJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIREZPOREZNANull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.PRIREZPOREZNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIREZUKUPNOKOREKCIJANull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.PRIREZUKUPNOKOREKCIJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPCINESTANOVANJANull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.SIFRAOPCINESTANOVANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetulicaNull()
            {
                this[this.tableS_PLACA_KONACNI_REKAPOPCINE.ulicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.IMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.IMEColumn] = value;
                }
            }

            public string kucnibroj
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.kucnibrojColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.kucnibrojColumn] = value;
                }
            }

            public string mjesto
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.mjestoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.mjestoColumn] = value;
                }
            }

            public string NAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.NAZIVOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.NAZIVOPCINEColumn] = value;
                }
            }

            public decimal OBRACUNATIPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.OBRACUNATIPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.OBRACUNATIPRIREZColumn] = value;
                }
            }

            public decimal OBRACUNATOPOREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.OBRACUNATOPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.OBRACUNATOPOREZColumn] = value;
                }
            }

            public string OIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.OIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.OIBColumn] = value;
                }
            }

            public decimal POREZPOREZNA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.POREZPOREZNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.POREZPOREZNAColumn] = value;
                }
            }

            public decimal POREZUKUPNOKOREKCIJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.POREZUKUPNOKOREKCIJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.POREZUKUPNOKOREKCIJAColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.PREZIMEColumn] = value;
                }
            }

            public decimal PRIREZPOREZNA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.PRIREZPOREZNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.PRIREZPOREZNAColumn] = value;
                }
            }

            public decimal PRIREZUKUPNOKOREKCIJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.PRIREZUKUPNOKOREKCIJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.PRIREZUKUPNOKOREKCIJAColumn] = value;
                }
            }

            public string SIFRAOPCINESTANOVANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.SIFRAOPCINESTANOVANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.SIFRAOPCINESTANOVANJAColumn] = value;
                }
            }

            public string ulica
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KONACNI_REKAPOPCINE.ulicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_REKAPOPCINE.ulicaColumn] = value;
                }
            }
        }

        public class S_PLACA_KONACNI_REKAPOPCINERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow eventRow;

            public S_PLACA_KONACNI_REKAPOPCINERowChangeEvent(S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow row, DataRowAction action)
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

            public S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_PLACA_KONACNI_REKAPOPCINERowChangeEventHandler(object sender, S_PLACA_KONACNI_REKAPOPCINEDataSet.S_PLACA_KONACNI_REKAPOPCINERowChangeEvent e);
    }
}

