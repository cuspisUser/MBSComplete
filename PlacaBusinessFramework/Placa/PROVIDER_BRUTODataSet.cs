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
    public class PROVIDER_BRUTODataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private ELEMENTDataTable tableELEMENT;

        public PROVIDER_BRUTODataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected PROVIDER_BRUTODataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["ELEMENT"] != null)
                    {
                        this.Tables.Add(new ELEMENTDataTable(dataSet.Tables["ELEMENT"]));
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
            PROVIDER_BRUTODataSet set = (PROVIDER_BRUTODataSet) base.Clone();
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
            PROVIDER_BRUTODataSet set = new PROVIDER_BRUTODataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "PROVIDER_BRUTODataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2010");
            this.ExtendedProperties.Add("DataSetName", "PROVIDER_BRUTODataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IPROVIDER_BRUTODataAdapter");
            this.ExtendedProperties.Add("ObjectName", "PROVIDER_BRUTO");
            this.ExtendedProperties.Add("ObjectDescription", "PROVIDER_BRUTO");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("DefaultBusinessComponent", "ELEMENT");
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
            this.DataSetName = "PROVIDER_BRUTODataSet";
            this.Namespace = "http://www.tempuri.org/PROVIDER_BRUTO";
            this.tableELEMENT = new ELEMENTDataTable();
            this.Tables.Add(this.tableELEMENT);
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
            this.tableELEMENT = (ELEMENTDataTable) this.Tables["ELEMENT"];
            if (initTable && (this.tableELEMENT != null))
            {
                this.tableELEMENT.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["ELEMENT"] != null)
                {
                    this.Tables.Add(new ELEMENTDataTable(dataSet.Tables["ELEMENT"]));
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

        private bool ShouldSerializeELEMENT()
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
        public ELEMENTDataTable ELEMENT
        {
            get
            {
                return this.tableELEMENT;
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
        public class ELEMENTDataTable : DataTable, IEnumerable
        {
            private DataColumn columnEL;
            private DataColumn columnIDELEMENT;
            private DataColumn columnIDVRSTAELEMENTA;
            private DataColumn columnNAZIVELEMENT;
            private DataColumn columnPOSTOTAK;

            public event PROVIDER_BRUTODataSet.ELEMENTRowChangeEventHandler ELEMENTRowChanged;

            public event PROVIDER_BRUTODataSet.ELEMENTRowChangeEventHandler ELEMENTRowChanging;

            public event PROVIDER_BRUTODataSet.ELEMENTRowChangeEventHandler ELEMENTRowDeleted;

            public event PROVIDER_BRUTODataSet.ELEMENTRowChangeEventHandler ELEMENTRowDeleting;

            public ELEMENTDataTable()
            {
                this.TableName = "ELEMENT";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal ELEMENTDataTable(DataTable table) : base(table.TableName)
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

            protected ELEMENTDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddELEMENTRow(PROVIDER_BRUTODataSet.ELEMENTRow row)
            {
                this.Rows.Add(row);
            }

            public PROVIDER_BRUTODataSet.ELEMENTRow AddELEMENTRow(int iDELEMENT, string nAZIVELEMENT, short iDVRSTAELEMENTA, decimal pOSTOTAK, string eL)
            {
                PROVIDER_BRUTODataSet.ELEMENTRow row = (PROVIDER_BRUTODataSet.ELEMENTRow) this.NewRow();
                row.ItemArray = new object[] { iDELEMENT, nAZIVELEMENT, iDVRSTAELEMENTA, pOSTOTAK, eL };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                PROVIDER_BRUTODataSet.ELEMENTDataTable table = (PROVIDER_BRUTODataSet.ELEMENTDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(PROVIDER_BRUTODataSet.ELEMENTRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                PROVIDER_BRUTODataSet set = new PROVIDER_BRUTODataSet();
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
                this.columnIDELEMENT = new DataColumn("IDELEMENT", typeof(int), "", MappingType.Element);
                this.columnIDELEMENT.Caption = "Šifra elementa";
                this.columnIDELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDELEMENT.ExtendedProperties.Add("Description", "Šifra elementa");
                this.columnIDELEMENT.ExtendedProperties.Add("Length", "8");
                this.columnIDELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDELEMENT");
                this.Columns.Add(this.columnIDELEMENT);
                this.columnNAZIVELEMENT = new DataColumn("NAZIVELEMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVELEMENT.Caption = "Naziv elementa";
                this.columnNAZIVELEMENT.MaxLength = 50;
                this.columnNAZIVELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Description", "Naziv elementa");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVELEMENT");
                this.Columns.Add(this.columnNAZIVELEMENT);
                this.columnIDVRSTAELEMENTA = new DataColumn("IDVRSTAELEMENTA", typeof(short), "", MappingType.Element);
                this.columnIDVRSTAELEMENTA.Caption = "Šifra Vrste elementa";
                this.columnIDVRSTAELEMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Description", "Šifra Vrste elementa");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Length", "4");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.InternalName", "IDVRSTAELEMENTA");
                this.Columns.Add(this.columnIDVRSTAELEMENTA);
                this.columnPOSTOTAK = new DataColumn("POSTOTAK", typeof(decimal), "", MappingType.Element);
                this.columnPOSTOTAK.Caption = "Postotak";
                this.columnPOSTOTAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("IsKey", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOSTOTAK.ExtendedProperties.Add("Description", "Postotak");
                this.columnPOSTOTAK.ExtendedProperties.Add("Length", "5");
                this.columnPOSTOTAK.ExtendedProperties.Add("Decimals", "2");
                this.columnPOSTOTAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPOSTOTAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.InternalName", "POSTOTAK");
                this.Columns.Add(this.columnPOSTOTAK);
                this.columnEL = new DataColumn("EL", typeof(string), "", MappingType.Element);
                this.columnEL.Caption = "EL";
                this.columnEL.MaxLength = 150;
                this.columnEL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnEL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnEL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnEL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnEL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnEL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnEL.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnEL.ExtendedProperties.Add("IsKey", "false");
                this.columnEL.ExtendedProperties.Add("ReadOnly", "true");
                this.columnEL.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnEL.ExtendedProperties.Add("Description", "EL");
                this.columnEL.ExtendedProperties.Add("Length", "150");
                this.columnEL.ExtendedProperties.Add("Decimals", "0");
                this.columnEL.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnEL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnEL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnEL.ExtendedProperties.Add("Deklarit.InternalName", "EL");
                this.Columns.Add(this.columnEL);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "PROVIDER_BRUTO");
                this.ExtendedProperties.Add("Description", "ELEMENT");
                this.ExtendedProperties.Add("HasOrder", "true");
                this.ExtendedProperties.Add("OrderAttributes", "IDVRSTAELEMENTA");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDELEMENT = this.Columns["IDELEMENT"];
                this.columnNAZIVELEMENT = this.Columns["NAZIVELEMENT"];
                this.columnIDVRSTAELEMENTA = this.Columns["IDVRSTAELEMENTA"];
                this.columnPOSTOTAK = this.Columns["POSTOTAK"];
                this.columnEL = this.Columns["EL"];
            }

            public PROVIDER_BRUTODataSet.ELEMENTRow NewELEMENTRow()
            {
                return (PROVIDER_BRUTODataSet.ELEMENTRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PROVIDER_BRUTODataSet.ELEMENTRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ELEMENTRowChanged != null)
                {
                    PROVIDER_BRUTODataSet.ELEMENTRowChangeEventHandler eLEMENTRowChangedEvent = this.ELEMENTRowChanged;
                    if (eLEMENTRowChangedEvent != null)
                    {
                        eLEMENTRowChangedEvent(this, new PROVIDER_BRUTODataSet.ELEMENTRowChangeEvent((PROVIDER_BRUTODataSet.ELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ELEMENTRowChanging != null)
                {
                    PROVIDER_BRUTODataSet.ELEMENTRowChangeEventHandler eLEMENTRowChangingEvent = this.ELEMENTRowChanging;
                    if (eLEMENTRowChangingEvent != null)
                    {
                        eLEMENTRowChangingEvent(this, new PROVIDER_BRUTODataSet.ELEMENTRowChangeEvent((PROVIDER_BRUTODataSet.ELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.ELEMENTRowDeleted != null)
                {
                    PROVIDER_BRUTODataSet.ELEMENTRowChangeEventHandler eLEMENTRowDeletedEvent = this.ELEMENTRowDeleted;
                    if (eLEMENTRowDeletedEvent != null)
                    {
                        eLEMENTRowDeletedEvent(this, new PROVIDER_BRUTODataSet.ELEMENTRowChangeEvent((PROVIDER_BRUTODataSet.ELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ELEMENTRowDeleting != null)
                {
                    PROVIDER_BRUTODataSet.ELEMENTRowChangeEventHandler eLEMENTRowDeletingEvent = this.ELEMENTRowDeleting;
                    if (eLEMENTRowDeletingEvent != null)
                    {
                        eLEMENTRowDeletingEvent(this, new PROVIDER_BRUTODataSet.ELEMENTRowChangeEvent((PROVIDER_BRUTODataSet.ELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveELEMENTRow(PROVIDER_BRUTODataSet.ELEMENTRow row)
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

            public DataColumn ELColumn
            {
                get
                {
                    return this.columnEL;
                }
            }

            public DataColumn IDELEMENTColumn
            {
                get
                {
                    return this.columnIDELEMENT;
                }
            }

            public DataColumn IDVRSTAELEMENTAColumn
            {
                get
                {
                    return this.columnIDVRSTAELEMENTA;
                }
            }

            public PROVIDER_BRUTODataSet.ELEMENTRow this[int index]
            {
                get
                {
                    return (PROVIDER_BRUTODataSet.ELEMENTRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVELEMENTColumn
            {
                get
                {
                    return this.columnNAZIVELEMENT;
                }
            }

            public DataColumn POSTOTAKColumn
            {
                get
                {
                    return this.columnPOSTOTAK;
                }
            }
        }

        public class ELEMENTRow : DataRow
        {
            private PROVIDER_BRUTODataSet.ELEMENTDataTable tableELEMENT;

            internal ELEMENTRow(DataRowBuilder rb) : base(rb)
            {
                this.tableELEMENT = (PROVIDER_BRUTODataSet.ELEMENTDataTable) this.Table;
            }

            public bool IsELNull()
            {
                return this.IsNull(this.tableELEMENT.ELColumn);
            }

            public bool IsIDELEMENTNull()
            {
                return this.IsNull(this.tableELEMENT.IDELEMENTColumn);
            }

            public bool IsIDVRSTAELEMENTANull()
            {
                return this.IsNull(this.tableELEMENT.IDVRSTAELEMENTAColumn);
            }

            public bool IsNAZIVELEMENTNull()
            {
                return this.IsNull(this.tableELEMENT.NAZIVELEMENTColumn);
            }

            public bool IsPOSTOTAKNull()
            {
                return this.IsNull(this.tableELEMENT.POSTOTAKColumn);
            }

            public void SetELNull()
            {
                this[this.tableELEMENT.ELColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDELEMENTNull()
            {
                this[this.tableELEMENT.IDELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDVRSTAELEMENTANull()
            {
                this[this.tableELEMENT.IDVRSTAELEMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVELEMENTNull()
            {
                this[this.tableELEMENT.NAZIVELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOSTOTAKNull()
            {
                this[this.tableELEMENT.POSTOTAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string EL
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableELEMENT.ELColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value EL because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableELEMENT.ELColumn] = value;
                }
            }

            public int IDELEMENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableELEMENT.IDELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDELEMENT because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableELEMENT.IDELEMENTColumn] = value;
                }
            }

            public short IDVRSTAELEMENTA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableELEMENT.IDVRSTAELEMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDVRSTAELEMENTA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableELEMENT.IDVRSTAELEMENTAColumn] = value;
                }
            }

            public string NAZIVELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableELEMENT.NAZIVELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVELEMENT because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableELEMENT.NAZIVELEMENTColumn] = value;
                }
            }

            public decimal POSTOTAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableELEMENT.POSTOTAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value POSTOTAK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableELEMENT.POSTOTAKColumn] = value;
                }
            }
        }

        public class ELEMENTRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private PROVIDER_BRUTODataSet.ELEMENTRow eventRow;

            public ELEMENTRowChangeEvent(PROVIDER_BRUTODataSet.ELEMENTRow row, DataRowAction action)
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

            public PROVIDER_BRUTODataSet.ELEMENTRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void ELEMENTRowChangeEventHandler(object sender, PROVIDER_BRUTODataSet.ELEMENTRowChangeEvent e);
    }
}

