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
    public class PregledRadnikaSvihDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RADNIKDataTable tableRADNIK;

        public PregledRadnikaSvihDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected PregledRadnikaSvihDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RADNIK"] != null)
                    {
                        this.Tables.Add(new RADNIKDataTable(dataSet.Tables["RADNIK"]));
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
            PregledRadnikaSvihDataSet set = (PregledRadnikaSvihDataSet) base.Clone();
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
            PregledRadnikaSvihDataSet set = new PregledRadnikaSvihDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "PregledRadnikaSvihDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2102");
            this.ExtendedProperties.Add("DataSetName", "PregledRadnikaSvihDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IPregledRadnikaSvihDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "PregledRadnikaSvih");
            this.ExtendedProperties.Add("ObjectDescription", "PregledRadnikaSvih");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("DefaultBusinessComponent", "RADNIK");
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
            this.DataSetName = "PregledRadnikaSvihDataSet";
            this.Namespace = "http://www.tempuri.org/PregledRadnikaSvih";
            this.tableRADNIK = new RADNIKDataTable();
            this.Tables.Add(this.tableRADNIK);
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
            this.tableRADNIK = (RADNIKDataTable) this.Tables["RADNIK"];
            if (initTable && (this.tableRADNIK != null))
            {
                this.tableRADNIK.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RADNIK"] != null)
                {
                    this.Tables.Add(new RADNIKDataTable(dataSet.Tables["RADNIK"]));
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

        private bool ShouldSerializeRADNIK()
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
        public RADNIKDataTable RADNIK
        {
            get
            {
                return this.tableRADNIK;
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
        public class RADNIKDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAKTIVAN;
            private DataColumn columnIDORGDIO;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnJMBG;
            private DataColumn columnOIB;
            private DataColumn columnOPCINASTANOVANJAIDOPCINE;
            private DataColumn columnPREZIME;
            private DataColumn columnUKUPNIFAKTOR;

            public event PregledRadnikaSvihDataSet.RADNIKRowChangeEventHandler RADNIKRowChanged;

            public event PregledRadnikaSvihDataSet.RADNIKRowChangeEventHandler RADNIKRowChanging;

            public event PregledRadnikaSvihDataSet.RADNIKRowChangeEventHandler RADNIKRowDeleted;

            public event PregledRadnikaSvihDataSet.RADNIKRowChangeEventHandler RADNIKRowDeleting;

            public RADNIKDataTable()
            {
                this.TableName = "RADNIK";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RADNIKDataTable(DataTable table) : base(table.TableName)
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

            protected RADNIKDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRADNIKRow(PregledRadnikaSvihDataSet.RADNIKRow row)
            {
                this.Rows.Add(row);
            }

            public PregledRadnikaSvihDataSet.RADNIKRow AddRADNIKRow(int iDRADNIK, string jMBG, string pREZIME, string iME, bool aKTIVAN, string oPCINASTANOVANJAIDOPCINE, int iDORGDIO, string oIB, decimal uKUPNIFAKTOR)
            {
                PregledRadnikaSvihDataSet.RADNIKRow row = (PregledRadnikaSvihDataSet.RADNIKRow) this.NewRow();
                row.ItemArray = new object[] { iDRADNIK, jMBG, pREZIME, iME, aKTIVAN, oPCINASTANOVANJAIDOPCINE, iDORGDIO, oIB, uKUPNIFAKTOR };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                PregledRadnikaSvihDataSet.RADNIKDataTable table = (PregledRadnikaSvihDataSet.RADNIKDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(PregledRadnikaSvihDataSet.RADNIKRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                PregledRadnikaSvihDataSet set = new PregledRadnikaSvihDataSet();
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
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnJMBG = new DataColumn("JMBG", typeof(string), "", MappingType.Element);
                this.columnJMBG.Caption = "JMBG";
                this.columnJMBG.MaxLength = 13;
                this.columnJMBG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnJMBG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnJMBG.ExtendedProperties.Add("IsKey", "false");
                this.columnJMBG.ExtendedProperties.Add("ReadOnly", "true");
                this.columnJMBG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnJMBG.ExtendedProperties.Add("Description", "JMBG");
                this.columnJMBG.ExtendedProperties.Add("Length", "13");
                this.columnJMBG.ExtendedProperties.Add("Decimals", "0");
                this.columnJMBG.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnJMBG.ExtendedProperties.Add("IsInReader", "true");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.InternalName", "JMBG");
                this.Columns.Add(this.columnJMBG);
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
                this.columnPREZIME.ExtendedProperties.Add("AllowDBNulls", "false");
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
                this.columnIME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.InternalName", "IME");
                this.Columns.Add(this.columnIME);
                this.columnAKTIVAN = new DataColumn("AKTIVAN", typeof(bool), "", MappingType.Element);
                this.columnAKTIVAN.Caption = "Aktivan";
                this.columnAKTIVAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("IsKey", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnAKTIVAN.ExtendedProperties.Add("Description", "Aktivan");
                this.columnAKTIVAN.ExtendedProperties.Add("Length", "1");
                this.columnAKTIVAN.ExtendedProperties.Add("Decimals", "0");
                this.columnAKTIVAN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.InternalName", "AKTIVAN");
                this.Columns.Add(this.columnAKTIVAN);
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
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAIDOPCINE");
                this.Columns.Add(this.columnOPCINASTANOVANJAIDOPCINE);
                this.columnIDORGDIO = new DataColumn("IDORGDIO", typeof(int), "", MappingType.Element);
                this.columnIDORGDIO.Caption = "Šifra organizacijske jedinice";
                this.columnIDORGDIO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("IsKey", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDORGDIO.ExtendedProperties.Add("Description", "Šifra organizacijske jedinice");
                this.columnIDORGDIO.ExtendedProperties.Add("Length", "5");
                this.columnIDORGDIO.ExtendedProperties.Add("Decimals", "0");
                this.columnIDORGDIO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.InternalName", "IDORGDIO");
                this.Columns.Add(this.columnIDORGDIO);
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
                this.columnUKUPNIFAKTOR = new DataColumn("UKUPNIFAKTOR", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNIFAKTOR.Caption = "UKUPNIFAKTOR";
                this.columnUKUPNIFAKTOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Description", "UKUPNIFAKTOR");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Length", "5");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNIFAKTOR");
                this.Columns.Add(this.columnUKUPNIFAKTOR);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "PregledRadnikaSvih");
                this.ExtendedProperties.Add("Description", "RADNIK");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnJMBG = this.Columns["JMBG"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnAKTIVAN = this.Columns["AKTIVAN"];
                this.columnOPCINASTANOVANJAIDOPCINE = this.Columns["OPCINASTANOVANJAIDOPCINE"];
                this.columnIDORGDIO = this.Columns["IDORGDIO"];
                this.columnOIB = this.Columns["OIB"];
                this.columnUKUPNIFAKTOR = this.Columns["UKUPNIFAKTOR"];
            }

            public PregledRadnikaSvihDataSet.RADNIKRow NewRADNIKRow()
            {
                return (PregledRadnikaSvihDataSet.RADNIKRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PregledRadnikaSvihDataSet.RADNIKRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RADNIKRowChanged != null)
                {
                    PregledRadnikaSvihDataSet.RADNIKRowChangeEventHandler rADNIKRowChangedEvent = this.RADNIKRowChanged;
                    if (rADNIKRowChangedEvent != null)
                    {
                        rADNIKRowChangedEvent(this, new PregledRadnikaSvihDataSet.RADNIKRowChangeEvent((PregledRadnikaSvihDataSet.RADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RADNIKRowChanging != null)
                {
                    PregledRadnikaSvihDataSet.RADNIKRowChangeEventHandler rADNIKRowChangingEvent = this.RADNIKRowChanging;
                    if (rADNIKRowChangingEvent != null)
                    {
                        rADNIKRowChangingEvent(this, new PregledRadnikaSvihDataSet.RADNIKRowChangeEvent((PregledRadnikaSvihDataSet.RADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RADNIKRowDeleted != null)
                {
                    PregledRadnikaSvihDataSet.RADNIKRowChangeEventHandler rADNIKRowDeletedEvent = this.RADNIKRowDeleted;
                    if (rADNIKRowDeletedEvent != null)
                    {
                        rADNIKRowDeletedEvent(this, new PregledRadnikaSvihDataSet.RADNIKRowChangeEvent((PregledRadnikaSvihDataSet.RADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RADNIKRowDeleting != null)
                {
                    PregledRadnikaSvihDataSet.RADNIKRowChangeEventHandler rADNIKRowDeletingEvent = this.RADNIKRowDeleting;
                    if (rADNIKRowDeletingEvent != null)
                    {
                        rADNIKRowDeletingEvent(this, new PregledRadnikaSvihDataSet.RADNIKRowChangeEvent((PregledRadnikaSvihDataSet.RADNIKRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRADNIKRow(PregledRadnikaSvihDataSet.RADNIKRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn AKTIVANColumn
            {
                get
                {
                    return this.columnAKTIVAN;
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

            public DataColumn IDORGDIOColumn
            {
                get
                {
                    return this.columnIDORGDIO;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public DataColumn IMEColumn
            {
                get
                {
                    return this.columnIME;
                }
            }

            public PregledRadnikaSvihDataSet.RADNIKRow this[int index]
            {
                get
                {
                    return (PregledRadnikaSvihDataSet.RADNIKRow) this.Rows[index];
                }
            }

            public DataColumn JMBGColumn
            {
                get
                {
                    return this.columnJMBG;
                }
            }

            public DataColumn OIBColumn
            {
                get
                {
                    return this.columnOIB;
                }
            }

            public DataColumn OPCINASTANOVANJAIDOPCINEColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAIDOPCINE;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn UKUPNIFAKTORColumn
            {
                get
                {
                    return this.columnUKUPNIFAKTOR;
                }
            }
        }

        public class RADNIKRow : DataRow
        {
            private PregledRadnikaSvihDataSet.RADNIKDataTable tableRADNIK;

            internal RADNIKRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRADNIK = (PregledRadnikaSvihDataSet.RADNIKDataTable) this.Table;
            }

            public bool IsAKTIVANNull()
            {
                return this.IsNull(this.tableRADNIK.AKTIVANColumn);
            }

            public bool IsIDORGDIONull()
            {
                return this.IsNull(this.tableRADNIK.IDORGDIOColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableRADNIK.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableRADNIK.IMEColumn);
            }

            public bool IsJMBGNull()
            {
                return this.IsNull(this.tableRADNIK.JMBGColumn);
            }

            public bool IsOIBNull()
            {
                return this.IsNull(this.tableRADNIK.OIBColumn);
            }

            public bool IsOPCINASTANOVANJAIDOPCINENull()
            {
                return this.IsNull(this.tableRADNIK.OPCINASTANOVANJAIDOPCINEColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableRADNIK.PREZIMEColumn);
            }

            public bool IsUKUPNIFAKTORNull()
            {
                return this.IsNull(this.tableRADNIK.UKUPNIFAKTORColumn);
            }

            public void SetAKTIVANNull()
            {
                this[this.tableRADNIK.AKTIVANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDORGDIONull()
            {
                this[this.tableRADNIK.IDORGDIOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableRADNIK.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableRADNIK.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGNull()
            {
                this[this.tableRADNIK.JMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOIBNull()
            {
                this[this.tableRADNIK.OIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAIDOPCINENull()
            {
                this[this.tableRADNIK.OPCINASTANOVANJAIDOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableRADNIK.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNIFAKTORNull()
            {
                this[this.tableRADNIK.UKUPNIFAKTORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool AKTIVAN
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableRADNIK.AKTIVANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value AKTIVAN because it is DBNull.", innerException);
                    }
                    return flag;
                }
                set
                {
                    this[this.tableRADNIK.AKTIVANColumn] = value;
                }
            }

            public int IDORGDIO
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDORGDIOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDORGDIO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.IDORGDIOColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDRADNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDRADNIK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.IMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.IMEColumn] = value;
                }
            }

            public string JMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.JMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.JMBGColumn] = value;
                }
            }

            public string OIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.OIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.OIBColumn] = value;
                }
            }

            public string OPCINASTANOVANJAIDOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.OPCINASTANOVANJAIDOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.OPCINASTANOVANJAIDOPCINEColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.PREZIMEColumn] = value;
                }
            }

            public decimal UKUPNIFAKTOR
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIK.UKUPNIFAKTORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.UKUPNIFAKTORColumn] = value;
                }
            }
        }

        public class RADNIKRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private PregledRadnikaSvihDataSet.RADNIKRow eventRow;

            public RADNIKRowChangeEvent(PregledRadnikaSvihDataSet.RADNIKRow row, DataRowAction action)
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

            public PregledRadnikaSvihDataSet.RADNIKRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RADNIKRowChangeEventHandler(object sender, PregledRadnikaSvihDataSet.RADNIKRowChangeEvent e);
    }
}

