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
    public class TIPIZNOSADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private TIPIZNOSADataTable tableTIPIZNOSA;

        public TIPIZNOSADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected TIPIZNOSADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["TIPIZNOSA"] != null)
                    {
                        this.Tables.Add(new TIPIZNOSADataTable(dataSet.Tables["TIPIZNOSA"]));
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
            TIPIZNOSADataSet set = (TIPIZNOSADataSet) base.Clone();
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
            TIPIZNOSADataSet set = new TIPIZNOSADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "TIPIZNOSADataAdapter");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1024");
            this.ExtendedProperties.Add("DataSetName", "TIPIZNOSADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ITIPIZNOSADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "TIPIZNOSA");
            this.ExtendedProperties.Add("ObjectDescription", "Pregled uplatnih raeuna doprinosa");
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
            this.DataSetName = "TIPIZNOSADataSet";
            this.Namespace = "http://www.tempuri.org/TIPIZNOSA";
            this.tableTIPIZNOSA = new TIPIZNOSADataTable();
            this.Tables.Add(this.tableTIPIZNOSA);
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
            this.tableTIPIZNOSA = (TIPIZNOSADataTable) this.Tables["TIPIZNOSA"];
            if (initTable && (this.tableTIPIZNOSA != null))
            {
                this.tableTIPIZNOSA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["TIPIZNOSA"] != null)
                {
                    this.Tables.Add(new TIPIZNOSADataTable(dataSet.Tables["TIPIZNOSA"]));
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

        private bool ShouldSerializeTIPIZNOSA()
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
        public TIPIZNOSADataTable TIPIZNOSA
        {
            get
            {
                return this.tableTIPIZNOSA;
            }
        }

        [Serializable]
        public class TIPIZNOSADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDTIPAIZNOSA;
            private DataColumn columnMOTIPAIZNOSA;
            private DataColumn columnOPISTIPAIZNOSA;
            private DataColumn columnOZNAKATIPAIZNOSA;
            private DataColumn columnPOTIPAIZNOSA;
            private DataColumn columnVBDITIPAIZNOSA;
            private DataColumn columnZIROTIPAIZNOSA;

            public event TIPIZNOSADataSet.TIPIZNOSARowChangeEventHandler TIPIZNOSARowChanged;

            public event TIPIZNOSADataSet.TIPIZNOSARowChangeEventHandler TIPIZNOSARowChanging;

            public event TIPIZNOSADataSet.TIPIZNOSARowChangeEventHandler TIPIZNOSARowDeleted;

            public event TIPIZNOSADataSet.TIPIZNOSARowChangeEventHandler TIPIZNOSARowDeleting;

            public TIPIZNOSADataTable()
            {
                this.TableName = "TIPIZNOSA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal TIPIZNOSADataTable(DataTable table) : base(table.TableName)
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

            protected TIPIZNOSADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddTIPIZNOSARow(TIPIZNOSADataSet.TIPIZNOSARow row)
            {
                this.Rows.Add(row);
            }

            public TIPIZNOSADataSet.TIPIZNOSARow AddTIPIZNOSARow(int iDTIPAIZNOSA, string oPISTIPAIZNOSA, string oZNAKATIPAIZNOSA, string vBDITIPAIZNOSA, string zIROTIPAIZNOSA, string mOTIPAIZNOSA, string pOTIPAIZNOSA)
            {
                TIPIZNOSADataSet.TIPIZNOSARow row = (TIPIZNOSADataSet.TIPIZNOSARow) this.NewRow();
                row["IDTIPAIZNOSA"] = iDTIPAIZNOSA;
                row["OPISTIPAIZNOSA"] = oPISTIPAIZNOSA;
                row["OZNAKATIPAIZNOSA"] = oZNAKATIPAIZNOSA;
                row["VBDITIPAIZNOSA"] = vBDITIPAIZNOSA;
                row["ZIROTIPAIZNOSA"] = zIROTIPAIZNOSA;
                row["MOTIPAIZNOSA"] = mOTIPAIZNOSA;
                row["POTIPAIZNOSA"] = pOTIPAIZNOSA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                TIPIZNOSADataSet.TIPIZNOSADataTable table = (TIPIZNOSADataSet.TIPIZNOSADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public TIPIZNOSADataSet.TIPIZNOSARow FindByIDTIPAIZNOSA(int iDTIPAIZNOSA)
            {
                return (TIPIZNOSADataSet.TIPIZNOSARow) this.Rows.Find(new object[] { iDTIPAIZNOSA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(TIPIZNOSADataSet.TIPIZNOSARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                TIPIZNOSADataSet set = new TIPIZNOSADataSet();
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
                this.columnIDTIPAIZNOSA = new DataColumn("IDTIPAIZNOSA", typeof(int), "", MappingType.Element);
                this.columnIDTIPAIZNOSA.AllowDBNull = false;
                this.columnIDTIPAIZNOSA.Caption = "Šifra";
                this.columnIDTIPAIZNOSA.Unique = true;
                this.columnIDTIPAIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("Length", "5");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPAIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPAIZNOSA");
                this.Columns.Add(this.columnIDTIPAIZNOSA);
                this.columnOPISTIPAIZNOSA = new DataColumn("OPISTIPAIZNOSA", typeof(string), "", MappingType.Element);
                this.columnOPISTIPAIZNOSA.AllowDBNull = false;
                this.columnOPISTIPAIZNOSA.Caption = "Opis";
                this.columnOPISTIPAIZNOSA.MaxLength = 100;
                this.columnOPISTIPAIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("Description", "Opis");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("Length", "100");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISTIPAIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "OPISTIPAIZNOSA");
                this.Columns.Add(this.columnOPISTIPAIZNOSA);
                this.columnOZNAKATIPAIZNOSA = new DataColumn("OZNAKATIPAIZNOSA", typeof(string), "", MappingType.Element);
                this.columnOZNAKATIPAIZNOSA.AllowDBNull = false;
                this.columnOZNAKATIPAIZNOSA.Caption = "Oznaka";
                this.columnOZNAKATIPAIZNOSA.MaxLength = 10;
                this.columnOZNAKATIPAIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("Description", "Oznaka");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("Length", "10");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOZNAKATIPAIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "OZNAKATIPAIZNOSA");
                this.Columns.Add(this.columnOZNAKATIPAIZNOSA);
                this.columnVBDITIPAIZNOSA = new DataColumn("VBDITIPAIZNOSA", typeof(string), "", MappingType.Element);
                this.columnVBDITIPAIZNOSA.AllowDBNull = false;
                this.columnVBDITIPAIZNOSA.Caption = "VBDI";
                this.columnVBDITIPAIZNOSA.MaxLength = 7;
                this.columnVBDITIPAIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("Description", "VBDI");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("Length", "7");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDITIPAIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "VBDITIPAIZNOSA");
                this.Columns.Add(this.columnVBDITIPAIZNOSA);
                this.columnZIROTIPAIZNOSA = new DataColumn("ZIROTIPAIZNOSA", typeof(string), "", MappingType.Element);
                this.columnZIROTIPAIZNOSA.AllowDBNull = false;
                this.columnZIROTIPAIZNOSA.Caption = "Broj žiro raeuna";
                this.columnZIROTIPAIZNOSA.MaxLength = 10;
                this.columnZIROTIPAIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("Description", "Broj žiro računa");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("Length", "10");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZIROTIPAIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "ZIROTIPAIZNOSA");
                this.Columns.Add(this.columnZIROTIPAIZNOSA);
                this.columnMOTIPAIZNOSA = new DataColumn("MOTIPAIZNOSA", typeof(string), "", MappingType.Element);
                this.columnMOTIPAIZNOSA.AllowDBNull = false;
                this.columnMOTIPAIZNOSA.Caption = "Model odobrenja";
                this.columnMOTIPAIZNOSA.MaxLength = 2;
                this.columnMOTIPAIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("Description", "Model odobrenja");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("Length", "2");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "MOTIPAIZNOSA");
                this.Columns.Add(this.columnMOTIPAIZNOSA);
                this.columnPOTIPAIZNOSA = new DataColumn("POTIPAIZNOSA", typeof(string), "", MappingType.Element);
                this.columnPOTIPAIZNOSA.AllowDBNull = false;
                this.columnPOTIPAIZNOSA.Caption = "Poziv na broj odobrenja";
                this.columnPOTIPAIZNOSA.MaxLength = 0x16;
                this.columnPOTIPAIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("Description", "Poziv na broj odobrenja");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("Length", "22");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOTIPAIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "POTIPAIZNOSA");
                this.Columns.Add(this.columnPOTIPAIZNOSA);
                this.PrimaryKey = new DataColumn[] { this.columnIDTIPAIZNOSA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "TIPIZNOSA");
                this.ExtendedProperties.Add("Description", "Pregled uplatnih raeuna doprinosa");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDTIPAIZNOSA = this.Columns["IDTIPAIZNOSA"];
                this.columnOPISTIPAIZNOSA = this.Columns["OPISTIPAIZNOSA"];
                this.columnOZNAKATIPAIZNOSA = this.Columns["OZNAKATIPAIZNOSA"];
                this.columnVBDITIPAIZNOSA = this.Columns["VBDITIPAIZNOSA"];
                this.columnZIROTIPAIZNOSA = this.Columns["ZIROTIPAIZNOSA"];
                this.columnMOTIPAIZNOSA = this.Columns["MOTIPAIZNOSA"];
                this.columnPOTIPAIZNOSA = this.Columns["POTIPAIZNOSA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new TIPIZNOSADataSet.TIPIZNOSARow(builder);
            }

            public TIPIZNOSADataSet.TIPIZNOSARow NewTIPIZNOSARow()
            {
                return (TIPIZNOSADataSet.TIPIZNOSARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.TIPIZNOSARowChanged != null)
                {
                    TIPIZNOSADataSet.TIPIZNOSARowChangeEventHandler tIPIZNOSARowChangedEvent = this.TIPIZNOSARowChanged;
                    if (tIPIZNOSARowChangedEvent != null)
                    {
                        tIPIZNOSARowChangedEvent(this, new TIPIZNOSADataSet.TIPIZNOSARowChangeEvent((TIPIZNOSADataSet.TIPIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.TIPIZNOSARowChanging != null)
                {
                    TIPIZNOSADataSet.TIPIZNOSARowChangeEventHandler tIPIZNOSARowChangingEvent = this.TIPIZNOSARowChanging;
                    if (tIPIZNOSARowChangingEvent != null)
                    {
                        tIPIZNOSARowChangingEvent(this, new TIPIZNOSADataSet.TIPIZNOSARowChangeEvent((TIPIZNOSADataSet.TIPIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.TIPIZNOSARowDeleted != null)
                {
                    TIPIZNOSADataSet.TIPIZNOSARowChangeEventHandler tIPIZNOSARowDeletedEvent = this.TIPIZNOSARowDeleted;
                    if (tIPIZNOSARowDeletedEvent != null)
                    {
                        tIPIZNOSARowDeletedEvent(this, new TIPIZNOSADataSet.TIPIZNOSARowChangeEvent((TIPIZNOSADataSet.TIPIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.TIPIZNOSARowDeleting != null)
                {
                    TIPIZNOSADataSet.TIPIZNOSARowChangeEventHandler tIPIZNOSARowDeletingEvent = this.TIPIZNOSARowDeleting;
                    if (tIPIZNOSARowDeletingEvent != null)
                    {
                        tIPIZNOSARowDeletingEvent(this, new TIPIZNOSADataSet.TIPIZNOSARowChangeEvent((TIPIZNOSADataSet.TIPIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveTIPIZNOSARow(TIPIZNOSADataSet.TIPIZNOSARow row)
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

            public DataColumn IDTIPAIZNOSAColumn
            {
                get
                {
                    return this.columnIDTIPAIZNOSA;
                }
            }

            public TIPIZNOSADataSet.TIPIZNOSARow this[int index]
            {
                get
                {
                    return (TIPIZNOSADataSet.TIPIZNOSARow) this.Rows[index];
                }
            }

            public DataColumn MOTIPAIZNOSAColumn
            {
                get
                {
                    return this.columnMOTIPAIZNOSA;
                }
            }

            public DataColumn OPISTIPAIZNOSAColumn
            {
                get
                {
                    return this.columnOPISTIPAIZNOSA;
                }
            }

            public DataColumn OZNAKATIPAIZNOSAColumn
            {
                get
                {
                    return this.columnOZNAKATIPAIZNOSA;
                }
            }

            public DataColumn POTIPAIZNOSAColumn
            {
                get
                {
                    return this.columnPOTIPAIZNOSA;
                }
            }

            public DataColumn VBDITIPAIZNOSAColumn
            {
                get
                {
                    return this.columnVBDITIPAIZNOSA;
                }
            }

            public DataColumn ZIROTIPAIZNOSAColumn
            {
                get
                {
                    return this.columnZIROTIPAIZNOSA;
                }
            }
        }

        public class TIPIZNOSARow : DataRow
        {
            private TIPIZNOSADataSet.TIPIZNOSADataTable tableTIPIZNOSA;

            internal TIPIZNOSARow(DataRowBuilder rb) : base(rb)
            {
                this.tableTIPIZNOSA = (TIPIZNOSADataSet.TIPIZNOSADataTable) this.Table;
            }

            public bool IsIDTIPAIZNOSANull()
            {
                return this.IsNull(this.tableTIPIZNOSA.IDTIPAIZNOSAColumn);
            }

            public bool IsMOTIPAIZNOSANull()
            {
                return this.IsNull(this.tableTIPIZNOSA.MOTIPAIZNOSAColumn);
            }

            public bool IsOPISTIPAIZNOSANull()
            {
                return this.IsNull(this.tableTIPIZNOSA.OPISTIPAIZNOSAColumn);
            }

            public bool IsOZNAKATIPAIZNOSANull()
            {
                return this.IsNull(this.tableTIPIZNOSA.OZNAKATIPAIZNOSAColumn);
            }

            public bool IsPOTIPAIZNOSANull()
            {
                return this.IsNull(this.tableTIPIZNOSA.POTIPAIZNOSAColumn);
            }

            public bool IsVBDITIPAIZNOSANull()
            {
                return this.IsNull(this.tableTIPIZNOSA.VBDITIPAIZNOSAColumn);
            }

            public bool IsZIROTIPAIZNOSANull()
            {
                return this.IsNull(this.tableTIPIZNOSA.ZIROTIPAIZNOSAColumn);
            }

            public void SetMOTIPAIZNOSANull()
            {
                this[this.tableTIPIZNOSA.MOTIPAIZNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISTIPAIZNOSANull()
            {
                this[this.tableTIPIZNOSA.OPISTIPAIZNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOZNAKATIPAIZNOSANull()
            {
                this[this.tableTIPIZNOSA.OZNAKATIPAIZNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOTIPAIZNOSANull()
            {
                this[this.tableTIPIZNOSA.POTIPAIZNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDITIPAIZNOSANull()
            {
                this[this.tableTIPIZNOSA.VBDITIPAIZNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZIROTIPAIZNOSANull()
            {
                this[this.tableTIPIZNOSA.ZIROTIPAIZNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDTIPAIZNOSA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableTIPIZNOSA.IDTIPAIZNOSAColumn]);
                }
                set
                {
                    this[this.tableTIPIZNOSA.IDTIPAIZNOSAColumn] = value;
                }
            }

            public string MOTIPAIZNOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableTIPIZNOSA.MOTIPAIZNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value MOTIPAIZNOSA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableTIPIZNOSA.MOTIPAIZNOSAColumn] = value;
                }
            }

            public string OPISTIPAIZNOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableTIPIZNOSA.OPISTIPAIZNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OPISTIPAIZNOSA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableTIPIZNOSA.OPISTIPAIZNOSAColumn] = value;
                }
            }

            public string OZNAKATIPAIZNOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableTIPIZNOSA.OZNAKATIPAIZNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OZNAKATIPAIZNOSA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableTIPIZNOSA.OZNAKATIPAIZNOSAColumn] = value;
                }
            }

            public string POTIPAIZNOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableTIPIZNOSA.POTIPAIZNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value POTIPAIZNOSA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableTIPIZNOSA.POTIPAIZNOSAColumn] = value;
                }
            }

            public string VBDITIPAIZNOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableTIPIZNOSA.VBDITIPAIZNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value VBDITIPAIZNOSA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableTIPIZNOSA.VBDITIPAIZNOSAColumn] = value;
                }
            }

            public string ZIROTIPAIZNOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableTIPIZNOSA.ZIROTIPAIZNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ZIROTIPAIZNOSA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableTIPIZNOSA.ZIROTIPAIZNOSAColumn] = value;
                }
            }
        }

        public class TIPIZNOSARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private TIPIZNOSADataSet.TIPIZNOSARow eventRow;

            public TIPIZNOSARowChangeEvent(TIPIZNOSADataSet.TIPIZNOSARow row, DataRowAction action)
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

            public TIPIZNOSADataSet.TIPIZNOSARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void TIPIZNOSARowChangeEventHandler(object sender, TIPIZNOSADataSet.TIPIZNOSARowChangeEvent e);
    }
}

