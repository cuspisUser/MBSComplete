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
    public class FINPOREZDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private FINPOREZDataTable tableFINPOREZ;

        public FINPOREZDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected FINPOREZDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["FINPOREZ"] != null)
                    {
                        this.Tables.Add(new FINPOREZDataTable(dataSet.Tables["FINPOREZ"]));
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
            FINPOREZDataSet set = (FINPOREZDataSet) base.Clone();
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
            FINPOREZDataSet set = new FINPOREZDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "FINPOREZDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2047");
            this.ExtendedProperties.Add("DataSetName", "FINPOREZDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IFINPOREZDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "FINPOREZ");
            this.ExtendedProperties.Add("ObjectDescription", "FINPOREZ");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "FINPOREZNAZIVPOREZ");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "FINPOREZDataSet";
            this.Namespace = "http://www.tempuri.org/FINPOREZ";
            this.tableFINPOREZ = new FINPOREZDataTable();
            this.Tables.Add(this.tableFINPOREZ);
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
            this.tableFINPOREZ = (FINPOREZDataTable) this.Tables["FINPOREZ"];
            if (initTable && (this.tableFINPOREZ != null))
            {
                this.tableFINPOREZ.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["FINPOREZ"] != null)
                {
                    this.Tables.Add(new FINPOREZDataTable(dataSet.Tables["FINPOREZ"]));
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

        private bool ShouldSerializeFINPOREZ()
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
        public FINPOREZDataTable FINPOREZ
        {
            get
            {
                return this.tableFINPOREZ;
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
        public class FINPOREZDataTable : DataTable, IEnumerable
        {
            private DataColumn columnFINPOREZIDPOREZ;
            private DataColumn columnFINPOREZNAZIVPOREZ;
            private DataColumn columnFINPOREZSTOPA;
            private DataColumn columnOSNOVICAUKNIZIIRA;

            public event FINPOREZDataSet.FINPOREZRowChangeEventHandler FINPOREZRowChanged;

            public event FINPOREZDataSet.FINPOREZRowChangeEventHandler FINPOREZRowChanging;

            public event FINPOREZDataSet.FINPOREZRowChangeEventHandler FINPOREZRowDeleted;

            public event FINPOREZDataSet.FINPOREZRowChangeEventHandler FINPOREZRowDeleting;

            public FINPOREZDataTable()
            {
                this.TableName = "FINPOREZ";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal FINPOREZDataTable(DataTable table) : base(table.TableName)
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

            protected FINPOREZDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddFINPOREZRow(FINPOREZDataSet.FINPOREZRow row)
            {
                this.Rows.Add(row);
            }

            public FINPOREZDataSet.FINPOREZRow AddFINPOREZRow(int fINPOREZIDPOREZ, string fINPOREZNAZIVPOREZ, decimal fINPOREZSTOPA, int oSNOVICAUKNIZIIRA)
            {
                FINPOREZDataSet.FINPOREZRow row = (FINPOREZDataSet.FINPOREZRow) this.NewRow();
                row["FINPOREZIDPOREZ"] = fINPOREZIDPOREZ;
                row["FINPOREZNAZIVPOREZ"] = fINPOREZNAZIVPOREZ;
                row["FINPOREZSTOPA"] = fINPOREZSTOPA;
                row["OSNOVICAUKNIZIIRA"] = oSNOVICAUKNIZIIRA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                FINPOREZDataSet.FINPOREZDataTable table = (FINPOREZDataSet.FINPOREZDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public FINPOREZDataSet.FINPOREZRow FindByFINPOREZIDPOREZ(int fINPOREZIDPOREZ)
            {
                return (FINPOREZDataSet.FINPOREZRow) this.Rows.Find(new object[] { fINPOREZIDPOREZ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(FINPOREZDataSet.FINPOREZRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                FINPOREZDataSet set = new FINPOREZDataSet();
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
                this.columnFINPOREZIDPOREZ = new DataColumn("FINPOREZIDPOREZ", typeof(int), "", MappingType.Element);
                this.columnFINPOREZIDPOREZ.AllowDBNull = false;
                this.columnFINPOREZIDPOREZ.Caption = "FINPOREZIDPOREZ";
                this.columnFINPOREZIDPOREZ.Unique = true;
                this.columnFINPOREZIDPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("IsKey", "true");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Description", "Šifra");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Length", "5");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "FINPOREZIDPOREZ");
                this.Columns.Add(this.columnFINPOREZIDPOREZ);
                this.columnFINPOREZNAZIVPOREZ = new DataColumn("FINPOREZNAZIVPOREZ", typeof(string), "", MappingType.Element);
                this.columnFINPOREZNAZIVPOREZ.AllowDBNull = false;
                this.columnFINPOREZNAZIVPOREZ.Caption = "FINPOREZNAZIVPOREZ";
                this.columnFINPOREZNAZIVPOREZ.MaxLength = 30;
                this.columnFINPOREZNAZIVPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("Description", "Naziv");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("Length", "30");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnFINPOREZNAZIVPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "FINPOREZNAZIVPOREZ");
                this.Columns.Add(this.columnFINPOREZNAZIVPOREZ);
                this.columnFINPOREZSTOPA = new DataColumn("FINPOREZSTOPA", typeof(decimal), "", MappingType.Element);
                this.columnFINPOREZSTOPA.AllowDBNull = false;
                this.columnFINPOREZSTOPA.Caption = "FINPOREZSTOPA";
                this.columnFINPOREZSTOPA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Description", "Stopa");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Length", "5");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("IsInReader", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.InternalName", "FINPOREZSTOPA");
                this.Columns.Add(this.columnFINPOREZSTOPA);
                this.columnOSNOVICAUKNIZIIRA = new DataColumn("OSNOVICAUKNIZIIRA", typeof(int), "", MappingType.Element);
                this.columnOSNOVICAUKNIZIIRA.AllowDBNull = false;
                this.columnOSNOVICAUKNIZIIRA.Caption = "OSNOVICAUKNIZIIRA";
                this.columnOSNOVICAUKNIZIIRA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Description", "Osnovica iz Knjige IRA");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Length", "5");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Decimals", "0");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAUKNIZIIRA.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAUKNIZIIRA");
                this.Columns.Add(this.columnOSNOVICAUKNIZIIRA);
                this.PrimaryKey = new DataColumn[] { this.columnFINPOREZIDPOREZ };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "FINPOREZ");
                this.ExtendedProperties.Add("Description", "FINPOREZ");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnFINPOREZIDPOREZ = this.Columns["FINPOREZIDPOREZ"];
                this.columnFINPOREZNAZIVPOREZ = this.Columns["FINPOREZNAZIVPOREZ"];
                this.columnFINPOREZSTOPA = this.Columns["FINPOREZSTOPA"];
                this.columnOSNOVICAUKNIZIIRA = this.Columns["OSNOVICAUKNIZIIRA"];
            }

            public FINPOREZDataSet.FINPOREZRow NewFINPOREZRow()
            {
                return (FINPOREZDataSet.FINPOREZRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new FINPOREZDataSet.FINPOREZRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.FINPOREZRowChanged != null)
                {
                    FINPOREZDataSet.FINPOREZRowChangeEventHandler fINPOREZRowChangedEvent = this.FINPOREZRowChanged;
                    if (fINPOREZRowChangedEvent != null)
                    {
                        fINPOREZRowChangedEvent(this, new FINPOREZDataSet.FINPOREZRowChangeEvent((FINPOREZDataSet.FINPOREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.FINPOREZRowChanging != null)
                {
                    FINPOREZDataSet.FINPOREZRowChangeEventHandler fINPOREZRowChangingEvent = this.FINPOREZRowChanging;
                    if (fINPOREZRowChangingEvent != null)
                    {
                        fINPOREZRowChangingEvent(this, new FINPOREZDataSet.FINPOREZRowChangeEvent((FINPOREZDataSet.FINPOREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.FINPOREZRowDeleted != null)
                {
                    FINPOREZDataSet.FINPOREZRowChangeEventHandler fINPOREZRowDeletedEvent = this.FINPOREZRowDeleted;
                    if (fINPOREZRowDeletedEvent != null)
                    {
                        fINPOREZRowDeletedEvent(this, new FINPOREZDataSet.FINPOREZRowChangeEvent((FINPOREZDataSet.FINPOREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.FINPOREZRowDeleting != null)
                {
                    FINPOREZDataSet.FINPOREZRowChangeEventHandler fINPOREZRowDeletingEvent = this.FINPOREZRowDeleting;
                    if (fINPOREZRowDeletingEvent != null)
                    {
                        fINPOREZRowDeletingEvent(this, new FINPOREZDataSet.FINPOREZRowChangeEvent((FINPOREZDataSet.FINPOREZRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveFINPOREZRow(FINPOREZDataSet.FINPOREZRow row)
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

            public DataColumn FINPOREZIDPOREZColumn
            {
                get
                {
                    return this.columnFINPOREZIDPOREZ;
                }
            }

            public DataColumn FINPOREZNAZIVPOREZColumn
            {
                get
                {
                    return this.columnFINPOREZNAZIVPOREZ;
                }
            }

            public DataColumn FINPOREZSTOPAColumn
            {
                get
                {
                    return this.columnFINPOREZSTOPA;
                }
            }

            public FINPOREZDataSet.FINPOREZRow this[int index]
            {
                get
                {
                    return (FINPOREZDataSet.FINPOREZRow) this.Rows[index];
                }
            }

            public DataColumn OSNOVICAUKNIZIIRAColumn
            {
                get
                {
                    return this.columnOSNOVICAUKNIZIIRA;
                }
            }
        }

        public class FINPOREZRow : DataRow
        {
            private FINPOREZDataSet.FINPOREZDataTable tableFINPOREZ;

            internal FINPOREZRow(DataRowBuilder rb) : base(rb)
            {
                this.tableFINPOREZ = (FINPOREZDataSet.FINPOREZDataTable) this.Table;
            }

            public bool IsFINPOREZIDPOREZNull()
            {
                return this.IsNull(this.tableFINPOREZ.FINPOREZIDPOREZColumn);
            }

            public bool IsFINPOREZNAZIVPOREZNull()
            {
                return this.IsNull(this.tableFINPOREZ.FINPOREZNAZIVPOREZColumn);
            }

            public bool IsFINPOREZSTOPANull()
            {
                return this.IsNull(this.tableFINPOREZ.FINPOREZSTOPAColumn);
            }

            public bool IsOSNOVICAUKNIZIIRANull()
            {
                return this.IsNull(this.tableFINPOREZ.OSNOVICAUKNIZIIRAColumn);
            }

            public void SetFINPOREZNAZIVPOREZNull()
            {
                this[this.tableFINPOREZ.FINPOREZNAZIVPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFINPOREZSTOPANull()
            {
                this[this.tableFINPOREZ.FINPOREZSTOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAUKNIZIIRANull()
            {
                this[this.tableFINPOREZ.OSNOVICAUKNIZIIRAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int FINPOREZIDPOREZ
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableFINPOREZ.FINPOREZIDPOREZColumn]);
                }
                set
                {
                    this[this.tableFINPOREZ.FINPOREZIDPOREZColumn] = value;
                }
            }

            public string FINPOREZNAZIVPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableFINPOREZ.FINPOREZNAZIVPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value FINPOREZNAZIVPOREZ because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableFINPOREZ.FINPOREZNAZIVPOREZColumn] = value;
                }
            }

            public decimal FINPOREZSTOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableFINPOREZ.FINPOREZSTOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value FINPOREZSTOPA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableFINPOREZ.FINPOREZSTOPAColumn] = value;
                }
            }

            public int OSNOVICAUKNIZIIRA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableFINPOREZ.OSNOVICAUKNIZIIRAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OSNOVICAUKNIZIIRA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableFINPOREZ.OSNOVICAUKNIZIIRAColumn] = value;
                }
            }
        }

        public class FINPOREZRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private FINPOREZDataSet.FINPOREZRow eventRow;

            public FINPOREZRowChangeEvent(FINPOREZDataSet.FINPOREZRow row, DataRowAction action)
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

            public FINPOREZDataSet.FINPOREZRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void FINPOREZRowChangeEventHandler(object sender, FINPOREZDataSet.FINPOREZRowChangeEvent e);
    }
}

