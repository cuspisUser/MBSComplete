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
    public class trazi_proizvodDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private PROIZVODDataTable tablePROIZVOD;

        public trazi_proizvodDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected trazi_proizvodDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["PROIZVOD"] != null)
                    {
                        this.Tables.Add(new PROIZVODDataTable(dataSet.Tables["PROIZVOD"]));
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
            trazi_proizvodDataSet set = (trazi_proizvodDataSet) base.Clone();
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
            trazi_proizvodDataSet set = new trazi_proizvodDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "trazi_proizvodDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2048");
            this.ExtendedProperties.Add("DataSetName", "trazi_proizvodDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Itrazi_proizvodDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "trazi_proizvod");
            this.ExtendedProperties.Add("ObjectDescription", "trazi_proizvod");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("DefaultBusinessComponent", "PROIZVOD");
            this.ExtendedProperties.Add("Deklarit.GroupByAttributes", "");
            this.ExtendedProperties.Add("Deklarit.GenerateCRUDForDP", "True");
            this.ExtendedProperties.Add("Deklarit.ExtendedView", "True");
            this.ExtendedProperties.Add("Deklarit.ShowGroupByDP", "True");
            this.ExtendedProperties.Add("Deklarit.UseSuggestInFK", "False");
            this.ExtendedProperties.Add("Deklarit.BCForNewOption", "");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVPROIZVOD");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "trazi_proizvodDataSet";
            this.Namespace = "http://www.tempuri.org/trazi_proizvod";
            this.tablePROIZVOD = new PROIZVODDataTable();
            this.Tables.Add(this.tablePROIZVOD);
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
            this.tablePROIZVOD = (PROIZVODDataTable) this.Tables["PROIZVOD"];
            if (initTable && (this.tablePROIZVOD != null))
            {
                this.tablePROIZVOD.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["PROIZVOD"] != null)
                {
                    this.Tables.Add(new PROIZVODDataTable(dataSet.Tables["PROIZVOD"]));
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

        private bool ShouldSerializePROIZVOD()
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
        public PROIZVODDataTable PROIZVOD
        {
            get
            {
                return this.tablePROIZVOD;
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
        public class PROIZVODDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCIJENA;
            private DataColumn columnFINPOREZIDPOREZ;
            private DataColumn columnFINPOREZSTOPA;
            private DataColumn columnIDJEDINICAMJERE;
            private DataColumn columnIDPROIZVOD;
            private DataColumn columnNAZIVJEDINICAMJERE;
            private DataColumn columnNAZIVPROIZVOD;

            public event trazi_proizvodDataSet.PROIZVODRowChangeEventHandler PROIZVODRowChanged;

            public event trazi_proizvodDataSet.PROIZVODRowChangeEventHandler PROIZVODRowChanging;

            public event trazi_proizvodDataSet.PROIZVODRowChangeEventHandler PROIZVODRowDeleted;

            public event trazi_proizvodDataSet.PROIZVODRowChangeEventHandler PROIZVODRowDeleting;

            public PROIZVODDataTable()
            {
                this.TableName = "PROIZVOD";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal PROIZVODDataTable(DataTable table) : base(table.TableName)
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

            protected PROIZVODDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPROIZVODRow(trazi_proizvodDataSet.PROIZVODRow row)
            {
                this.Rows.Add(row);
            }

            public trazi_proizvodDataSet.PROIZVODRow AddPROIZVODRow(int iDPROIZVOD, string nAZIVPROIZVOD, decimal cIJENA, int fINPOREZIDPOREZ, decimal fINPOREZSTOPA, int iDJEDINICAMJERE, string nAZIVJEDINICAMJERE)
            {
                trazi_proizvodDataSet.PROIZVODRow row = (trazi_proizvodDataSet.PROIZVODRow) this.NewRow();
                row.ItemArray = new object[] { iDPROIZVOD, nAZIVPROIZVOD, cIJENA, fINPOREZIDPOREZ, fINPOREZSTOPA, iDJEDINICAMJERE, nAZIVJEDINICAMJERE };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                trazi_proizvodDataSet.PROIZVODDataTable table = (trazi_proizvodDataSet.PROIZVODDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(trazi_proizvodDataSet.PROIZVODRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                trazi_proizvodDataSet set = new trazi_proizvodDataSet();
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
                this.columnIDPROIZVOD = new DataColumn("IDPROIZVOD", typeof(int), "", MappingType.Element);
                this.columnIDPROIZVOD.Caption = "IDPROIZVOD";
                this.columnIDPROIZVOD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("IsKey", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDPROIZVOD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Description", "IDPROIZVOD");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Length", "5");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPROIZVOD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.InternalName", "IDPROIZVOD");
                this.Columns.Add(this.columnIDPROIZVOD);
                this.columnNAZIVPROIZVOD = new DataColumn("NAZIVPROIZVOD", typeof(string), "", MappingType.Element);
                this.columnNAZIVPROIZVOD.Caption = "NAZIVPROIZVOD";
                this.columnNAZIVPROIZVOD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Description", "NAZIVPROIZVOD");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Length", "500");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPROIZVOD");
                this.Columns.Add(this.columnNAZIVPROIZVOD);
                this.columnCIJENA = new DataColumn("CIJENA", typeof(decimal), "", MappingType.Element);
                this.columnCIJENA.Caption = "CIJENA";
                this.columnCIJENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnCIJENA.ExtendedProperties.Add("IsKey", "false");
                this.columnCIJENA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnCIJENA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnCIJENA.ExtendedProperties.Add("Description", "CIJENA");
                this.columnCIJENA.ExtendedProperties.Add("Length", "9");
                this.columnCIJENA.ExtendedProperties.Add("Decimals", "4");
                this.columnCIJENA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnCIJENA.ExtendedProperties.Add("IsInReader", "true");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.InternalName", "CIJENA");
                this.Columns.Add(this.columnCIJENA);
                this.columnFINPOREZIDPOREZ = new DataColumn("FINPOREZIDPOREZ", typeof(int), "", MappingType.Element);
                this.columnFINPOREZIDPOREZ.Caption = "FINPOREZIDPOREZ";
                this.columnFINPOREZIDPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Description", "FINPOREZIDPOREZ");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Length", "5");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnFINPOREZIDPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "FINPOREZIDPOREZ");
                this.Columns.Add(this.columnFINPOREZIDPOREZ);
                this.columnFINPOREZSTOPA = new DataColumn("FINPOREZSTOPA", typeof(decimal), "", MappingType.Element);
                this.columnFINPOREZSTOPA.Caption = "FINPOREZSTOPA";
                this.columnFINPOREZSTOPA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Description", "FINPOREZSTOPA");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Length", "5");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("IsInReader", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.InternalName", "FINPOREZSTOPA");
                this.Columns.Add(this.columnFINPOREZSTOPA);
                this.columnIDJEDINICAMJERE = new DataColumn("IDJEDINICAMJERE", typeof(int), "", MappingType.Element);
                this.columnIDJEDINICAMJERE.Caption = "IDJEDINICAMJERE";
                this.columnIDJEDINICAMJERE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Description", "IDJEDINICAMJERE");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Length", "5");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.InternalName", "IDJEDINICAMJERE");
                this.Columns.Add(this.columnIDJEDINICAMJERE);
                this.columnNAZIVJEDINICAMJERE = new DataColumn("NAZIVJEDINICAMJERE", typeof(string), "", MappingType.Element);
                this.columnNAZIVJEDINICAMJERE.Caption = "NAZIVJEDINICAMJERE";
                this.columnNAZIVJEDINICAMJERE.MaxLength = 50;
                this.columnNAZIVJEDINICAMJERE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Description", "NAZIVJEDINICAMJERE");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVJEDINICAMJERE");
                this.Columns.Add(this.columnNAZIVJEDINICAMJERE);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "trazi_proizvod");
                this.ExtendedProperties.Add("Description", "PROIZVOD");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDPROIZVOD = this.Columns["IDPROIZVOD"];
                this.columnNAZIVPROIZVOD = this.Columns["NAZIVPROIZVOD"];
                this.columnCIJENA = this.Columns["CIJENA"];
                this.columnFINPOREZIDPOREZ = this.Columns["FINPOREZIDPOREZ"];
                this.columnFINPOREZSTOPA = this.Columns["FINPOREZSTOPA"];
                this.columnIDJEDINICAMJERE = this.Columns["IDJEDINICAMJERE"];
                this.columnNAZIVJEDINICAMJERE = this.Columns["NAZIVJEDINICAMJERE"];
            }

            public trazi_proizvodDataSet.PROIZVODRow NewPROIZVODRow()
            {
                return (trazi_proizvodDataSet.PROIZVODRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new trazi_proizvodDataSet.PROIZVODRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PROIZVODRowChanged != null)
                {
                    trazi_proizvodDataSet.PROIZVODRowChangeEventHandler pROIZVODRowChangedEvent = this.PROIZVODRowChanged;
                    if (pROIZVODRowChangedEvent != null)
                    {
                        pROIZVODRowChangedEvent(this, new trazi_proizvodDataSet.PROIZVODRowChangeEvent((trazi_proizvodDataSet.PROIZVODRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PROIZVODRowChanging != null)
                {
                    trazi_proizvodDataSet.PROIZVODRowChangeEventHandler pROIZVODRowChangingEvent = this.PROIZVODRowChanging;
                    if (pROIZVODRowChangingEvent != null)
                    {
                        pROIZVODRowChangingEvent(this, new trazi_proizvodDataSet.PROIZVODRowChangeEvent((trazi_proizvodDataSet.PROIZVODRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PROIZVODRowDeleted != null)
                {
                    trazi_proizvodDataSet.PROIZVODRowChangeEventHandler pROIZVODRowDeletedEvent = this.PROIZVODRowDeleted;
                    if (pROIZVODRowDeletedEvent != null)
                    {
                        pROIZVODRowDeletedEvent(this, new trazi_proizvodDataSet.PROIZVODRowChangeEvent((trazi_proizvodDataSet.PROIZVODRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PROIZVODRowDeleting != null)
                {
                    trazi_proizvodDataSet.PROIZVODRowChangeEventHandler pROIZVODRowDeletingEvent = this.PROIZVODRowDeleting;
                    if (pROIZVODRowDeletingEvent != null)
                    {
                        pROIZVODRowDeletingEvent(this, new trazi_proizvodDataSet.PROIZVODRowChangeEvent((trazi_proizvodDataSet.PROIZVODRow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePROIZVODRow(trazi_proizvodDataSet.PROIZVODRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn CIJENAColumn
            {
                get
                {
                    return this.columnCIJENA;
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

            public DataColumn FINPOREZIDPOREZColumn
            {
                get
                {
                    return this.columnFINPOREZIDPOREZ;
                }
            }

            public DataColumn FINPOREZSTOPAColumn
            {
                get
                {
                    return this.columnFINPOREZSTOPA;
                }
            }

            public DataColumn IDJEDINICAMJEREColumn
            {
                get
                {
                    return this.columnIDJEDINICAMJERE;
                }
            }

            public DataColumn IDPROIZVODColumn
            {
                get
                {
                    return this.columnIDPROIZVOD;
                }
            }

            public trazi_proizvodDataSet.PROIZVODRow this[int index]
            {
                get
                {
                    return (trazi_proizvodDataSet.PROIZVODRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVJEDINICAMJEREColumn
            {
                get
                {
                    return this.columnNAZIVJEDINICAMJERE;
                }
            }

            public DataColumn NAZIVPROIZVODColumn
            {
                get
                {
                    return this.columnNAZIVPROIZVOD;
                }
            }
        }

        public class PROIZVODRow : DataRow
        {
            private trazi_proizvodDataSet.PROIZVODDataTable tablePROIZVOD;

            internal PROIZVODRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePROIZVOD = (trazi_proizvodDataSet.PROIZVODDataTable) this.Table;
            }

            public bool IsCIJENANull()
            {
                return this.IsNull(this.tablePROIZVOD.CIJENAColumn);
            }

            public bool IsFINPOREZIDPOREZNull()
            {
                return this.IsNull(this.tablePROIZVOD.FINPOREZIDPOREZColumn);
            }

            public bool IsFINPOREZSTOPANull()
            {
                return this.IsNull(this.tablePROIZVOD.FINPOREZSTOPAColumn);
            }

            public bool IsIDJEDINICAMJERENull()
            {
                return this.IsNull(this.tablePROIZVOD.IDJEDINICAMJEREColumn);
            }

            public bool IsIDPROIZVODNull()
            {
                return this.IsNull(this.tablePROIZVOD.IDPROIZVODColumn);
            }

            public bool IsNAZIVJEDINICAMJERENull()
            {
                return this.IsNull(this.tablePROIZVOD.NAZIVJEDINICAMJEREColumn);
            }

            public bool IsNAZIVPROIZVODNull()
            {
                return this.IsNull(this.tablePROIZVOD.NAZIVPROIZVODColumn);
            }

            public void SetCIJENANull()
            {
                this[this.tablePROIZVOD.CIJENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFINPOREZIDPOREZNull()
            {
                this[this.tablePROIZVOD.FINPOREZIDPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFINPOREZSTOPANull()
            {
                this[this.tablePROIZVOD.FINPOREZSTOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDJEDINICAMJERENull()
            {
                this[this.tablePROIZVOD.IDJEDINICAMJEREColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDPROIZVODNull()
            {
                this[this.tablePROIZVOD.IDPROIZVODColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVJEDINICAMJERENull()
            {
                this[this.tablePROIZVOD.NAZIVJEDINICAMJEREColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPROIZVODNull()
            {
                this[this.tablePROIZVOD.NAZIVPROIZVODColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal CIJENA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePROIZVOD.CIJENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value CIJENA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablePROIZVOD.CIJENAColumn] = value;
                }
            }

            public int FINPOREZIDPOREZ
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablePROIZVOD.FINPOREZIDPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value FINPOREZIDPOREZ because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablePROIZVOD.FINPOREZIDPOREZColumn] = value;
                }
            }

            public decimal FINPOREZSTOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePROIZVOD.FINPOREZSTOPAColumn]);
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
                    this[this.tablePROIZVOD.FINPOREZSTOPAColumn] = value;
                }
            }

            public int IDJEDINICAMJERE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablePROIZVOD.IDJEDINICAMJEREColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDJEDINICAMJERE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablePROIZVOD.IDJEDINICAMJEREColumn] = value;
                }
            }

            public int IDPROIZVOD
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablePROIZVOD.IDPROIZVODColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDPROIZVOD because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablePROIZVOD.IDPROIZVODColumn] = value;
                }
            }

            public string NAZIVJEDINICAMJERE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePROIZVOD.NAZIVJEDINICAMJEREColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVJEDINICAMJERE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablePROIZVOD.NAZIVJEDINICAMJEREColumn] = value;
                }
            }

            public string NAZIVPROIZVOD
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePROIZVOD.NAZIVPROIZVODColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVPROIZVOD because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablePROIZVOD.NAZIVPROIZVODColumn] = value;
                }
            }
        }

        public class PROIZVODRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private trazi_proizvodDataSet.PROIZVODRow eventRow;

            public PROIZVODRowChangeEvent(trazi_proizvodDataSet.PROIZVODRow row, DataRowAction action)
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

            public trazi_proizvodDataSet.PROIZVODRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PROIZVODRowChangeEventHandler(object sender, trazi_proizvodDataSet.PROIZVODRowChangeEvent e);
    }
}

