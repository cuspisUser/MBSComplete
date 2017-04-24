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
    public class PLANDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private PLANDataTable tablePLAN;
        private PLANORGDataTable tablePLANORG;
        private PLANORGKONDataTable tablePLANORGKON;

        public PLANDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected PLANDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["PLANORGKON"] != null)
                    {
                        this.Tables.Add(new PLANORGKONDataTable(dataSet.Tables["PLANORGKON"]));
                    }
                    if (dataSet.Tables["PLANORG"] != null)
                    {
                        this.Tables.Add(new PLANORGDataTable(dataSet.Tables["PLANORG"]));
                    }
                    if (dataSet.Tables["PLAN"] != null)
                    {
                        this.Tables.Add(new PLANDataTable(dataSet.Tables["PLAN"]));
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
            PLANDataSet set = (PLANDataSet) base.Clone();
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
            PLANDataSet set = new PLANDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "PLANDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2125");
            this.ExtendedProperties.Add("DataSetName", "PLANDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IPLANDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "PLAN");
            this.ExtendedProperties.Add("ObjectDescription", "PLAN");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Finpos");
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
            this.DataSetName = "PLANDataSet";
            this.Namespace = "http://www.tempuri.org/PLAN";
            this.tablePLANORGKON = new PLANORGKONDataTable();
            this.Tables.Add(this.tablePLANORGKON);
            this.tablePLANORG = new PLANORGDataTable();
            this.Tables.Add(this.tablePLANORG);
            this.tablePLAN = new PLANDataTable();
            this.Tables.Add(this.tablePLAN);
            this.Relations.Add("PLANORG_PLANORGKON", new DataColumn[] { this.Tables["PLANORG"].Columns["IDPLAN"], this.Tables["PLANORG"].Columns["PLANGODINAIDGODINE"], this.Tables["PLANORG"].Columns["PLANOJIDORGJED"] }, new DataColumn[] { this.Tables["PLANORGKON"].Columns["IDPLAN"], this.Tables["PLANORGKON"].Columns["PLANGODINAIDGODINE"], this.Tables["PLANORGKON"].Columns["PLANOJIDORGJED"] });
            this.Relations["PLANORG_PLANORGKON"].Nested = true;
            this.Relations.Add("PLAN_PLANORG", new DataColumn[] { this.Tables["PLAN"].Columns["IDPLAN"], this.Tables["PLAN"].Columns["PLANGODINAIDGODINE"] }, new DataColumn[] { this.Tables["PLANORG"].Columns["IDPLAN"], this.Tables["PLANORG"].Columns["PLANGODINAIDGODINE"] });
            this.Relations["PLAN_PLANORG"].Nested = true;
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
            this.tablePLANORGKON = (PLANORGKONDataTable) this.Tables["PLANORGKON"];
            this.tablePLANORG = (PLANORGDataTable) this.Tables["PLANORG"];
            this.tablePLAN = (PLANDataTable) this.Tables["PLAN"];
            if (initTable)
            {
                if (this.tablePLANORGKON != null)
                {
                    this.tablePLANORGKON.InitVars();
                }
                if (this.tablePLANORG != null)
                {
                    this.tablePLANORG.InitVars();
                }
                if (this.tablePLAN != null)
                {
                    this.tablePLAN.InitVars();
                }
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["PLANORGKON"] != null)
                {
                    this.Tables.Add(new PLANORGKONDataTable(dataSet.Tables["PLANORGKON"]));
                }
                if (dataSet.Tables["PLANORG"] != null)
                {
                    this.Tables.Add(new PLANORGDataTable(dataSet.Tables["PLANORG"]));
                }
                if (dataSet.Tables["PLAN"] != null)
                {
                    this.Tables.Add(new PLANDataTable(dataSet.Tables["PLAN"]));
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

        private bool ShouldSerializePLAN()
        {
            return false;
        }

        private bool ShouldSerializePLANORG()
        {
            return false;
        }

        private bool ShouldSerializePLANORGKON()
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
        public PLANDataTable PLAN
        {
            get
            {
                return this.tablePLAN;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PLANORGDataTable PLANORG
        {
            get
            {
                return this.tablePLANORG;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PLANORGKONDataTable PLANORGKON
        {
            get
            {
                return this.tablePLANORGKON;
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
        public class PLANDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDPLAN;
            private DataColumn columnPLANGODINAIDGODINE;
            private DataColumn columnRADNINAZIVPLANA;

            public event PLANDataSet.PLANRowChangeEventHandler PLANRowChanged;

            public event PLANDataSet.PLANRowChangeEventHandler PLANRowChanging;

            public event PLANDataSet.PLANRowChangeEventHandler PLANRowDeleted;

            public event PLANDataSet.PLANRowChangeEventHandler PLANRowDeleting;

            public PLANDataTable()
            {
                this.TableName = "PLAN";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal PLANDataTable(DataTable table) : base(table.TableName)
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

            protected PLANDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPLANRow(PLANDataSet.PLANRow row)
            {
                this.Rows.Add(row);
            }

            public PLANDataSet.PLANRow AddPLANRow(int iDPLAN, short pLANGODINAIDGODINE, string rADNINAZIVPLANA)
            {
                PLANDataSet.PLANRow row = (PLANDataSet.PLANRow) this.NewRow();
                row["IDPLAN"] = iDPLAN;
                row["PLANGODINAIDGODINE"] = pLANGODINAIDGODINE;
                row["RADNINAZIVPLANA"] = rADNINAZIVPLANA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                PLANDataSet.PLANDataTable table = (PLANDataSet.PLANDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public PLANDataSet.PLANRow FindByIDPLANPLANGODINAIDGODINE(int iDPLAN, short pLANGODINAIDGODINE)
            {
                return (PLANDataSet.PLANRow) this.Rows.Find(new object[] { iDPLAN, pLANGODINAIDGODINE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(PLANDataSet.PLANRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                PLANDataSet set = new PLANDataSet();
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
                this.columnIDPLAN = new DataColumn("IDPLAN", typeof(int), "", MappingType.Element);
                this.columnIDPLAN.AllowDBNull = false;
                this.columnIDPLAN.Caption = "IDPLAN";
                this.columnIDPLAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPLAN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDPLAN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDPLAN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPLAN.ExtendedProperties.Add("Description", "IDPLAN");
                this.columnIDPLAN.ExtendedProperties.Add("Length", "5");
                this.columnIDPLAN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPLAN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPLAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.InternalName", "IDPLAN");
                this.Columns.Add(this.columnIDPLAN);
                this.columnPLANGODINAIDGODINE = new DataColumn("PLANGODINAIDGODINE", typeof(short), "", MappingType.Element);
                this.columnPLANGODINAIDGODINE.AllowDBNull = false;
                this.columnPLANGODINAIDGODINE.Caption = "IDGODINE";
                this.columnPLANGODINAIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("SuperType", "IDGODINE");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("SubtypeGroup", "PLANGODINA");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("IsKey", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Description", "IDGODINE");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "PLANGODINAIDGODINE");
                this.Columns.Add(this.columnPLANGODINAIDGODINE);
                this.columnRADNINAZIVPLANA = new DataColumn("RADNINAZIVPLANA", typeof(string), "", MappingType.Element);
                this.columnRADNINAZIVPLANA.AllowDBNull = false;
                this.columnRADNINAZIVPLANA.Caption = "RADNINAZIVPLANA";
                this.columnRADNINAZIVPLANA.MaxLength = 50;
                this.columnRADNINAZIVPLANA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("IsKey", "false");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("Description", "RADNINAZIVPLANA");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("Length", "50");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("Decimals", "0");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("IsInReader", "true");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRADNINAZIVPLANA.ExtendedProperties.Add("Deklarit.InternalName", "RADNINAZIVPLANA");
                this.Columns.Add(this.columnRADNINAZIVPLANA);
                this.PrimaryKey = new DataColumn[] { this.columnIDPLAN, this.columnPLANGODINAIDGODINE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "PLAN");
                this.ExtendedProperties.Add("Description", "PLAN");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDPLAN = this.Columns["IDPLAN"];
                this.columnPLANGODINAIDGODINE = this.Columns["PLANGODINAIDGODINE"];
                this.columnRADNINAZIVPLANA = this.Columns["RADNINAZIVPLANA"];
            }

            public PLANDataSet.PLANRow NewPLANRow()
            {
                return (PLANDataSet.PLANRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PLANDataSet.PLANRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PLANRowChanged != null)
                {
                    PLANDataSet.PLANRowChangeEventHandler pLANRowChangedEvent = this.PLANRowChanged;
                    if (pLANRowChangedEvent != null)
                    {
                        pLANRowChangedEvent(this, new PLANDataSet.PLANRowChangeEvent((PLANDataSet.PLANRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PLANRowChanging != null)
                {
                    PLANDataSet.PLANRowChangeEventHandler pLANRowChangingEvent = this.PLANRowChanging;
                    if (pLANRowChangingEvent != null)
                    {
                        pLANRowChangingEvent(this, new PLANDataSet.PLANRowChangeEvent((PLANDataSet.PLANRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PLANRowDeleted != null)
                {
                    PLANDataSet.PLANRowChangeEventHandler pLANRowDeletedEvent = this.PLANRowDeleted;
                    if (pLANRowDeletedEvent != null)
                    {
                        pLANRowDeletedEvent(this, new PLANDataSet.PLANRowChangeEvent((PLANDataSet.PLANRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PLANRowDeleting != null)
                {
                    PLANDataSet.PLANRowChangeEventHandler pLANRowDeletingEvent = this.PLANRowDeleting;
                    if (pLANRowDeletingEvent != null)
                    {
                        pLANRowDeletingEvent(this, new PLANDataSet.PLANRowChangeEvent((PLANDataSet.PLANRow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePLANRow(PLANDataSet.PLANRow row)
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

            public DataColumn IDPLANColumn
            {
                get
                {
                    return this.columnIDPLAN;
                }
            }

            public PLANDataSet.PLANRow this[int index]
            {
                get
                {
                    return (PLANDataSet.PLANRow) this.Rows[index];
                }
            }

            public DataColumn PLANGODINAIDGODINEColumn
            {
                get
                {
                    return this.columnPLANGODINAIDGODINE;
                }
            }

            public DataColumn RADNINAZIVPLANAColumn
            {
                get
                {
                    return this.columnRADNINAZIVPLANA;
                }
            }
        }

        [Serializable]
        public class PLANORGDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDPLAN;
            private DataColumn columnPLANGODINAIDGODINE;
            private DataColumn columnPLANOJIDORGJED;
            private DataColumn columnPLANOJNAZIVORGJED;

            public event PLANDataSet.PLANORGRowChangeEventHandler PLANORGRowChanged;

            public event PLANDataSet.PLANORGRowChangeEventHandler PLANORGRowChanging;

            public event PLANDataSet.PLANORGRowChangeEventHandler PLANORGRowDeleted;

            public event PLANDataSet.PLANORGRowChangeEventHandler PLANORGRowDeleting;

            public PLANORGDataTable()
            {
                this.TableName = "PLANORG";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal PLANORGDataTable(DataTable table) : base(table.TableName)
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

            protected PLANORGDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPLANORGRow(PLANDataSet.PLANORGRow row)
            {
                this.Rows.Add(row);
            }

            public PLANDataSet.PLANORGRow AddPLANORGRow(int iDPLAN, short pLANGODINAIDGODINE, int pLANOJIDORGJED)
            {
                PLANDataSet.PLANORGRow row = (PLANDataSet.PLANORGRow) this.NewRow();
                row["IDPLAN"] = iDPLAN;
                row["PLANGODINAIDGODINE"] = pLANGODINAIDGODINE;
                row["PLANOJIDORGJED"] = pLANOJIDORGJED;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                PLANDataSet.PLANORGDataTable table = (PLANDataSet.PLANORGDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public PLANDataSet.PLANORGRow FindByIDPLANPLANGODINAIDGODINEPLANOJIDORGJED(int iDPLAN, short pLANGODINAIDGODINE, int pLANOJIDORGJED)
            {
                return (PLANDataSet.PLANORGRow) this.Rows.Find(new object[] { iDPLAN, pLANGODINAIDGODINE, pLANOJIDORGJED });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(PLANDataSet.PLANORGRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                PLANDataSet set = new PLANDataSet();
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
                this.columnIDPLAN = new DataColumn("IDPLAN", typeof(int), "", MappingType.Element);
                this.columnIDPLAN.AllowDBNull = false;
                this.columnIDPLAN.Caption = "IDPLAN";
                this.columnIDPLAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPLAN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDPLAN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDPLAN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPLAN.ExtendedProperties.Add("Description", "IDPLAN");
                this.columnIDPLAN.ExtendedProperties.Add("Length", "5");
                this.columnIDPLAN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPLAN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPLAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.InternalName", "IDPLAN");
                this.Columns.Add(this.columnIDPLAN);
                this.columnPLANGODINAIDGODINE = new DataColumn("PLANGODINAIDGODINE", typeof(short), "", MappingType.Element);
                this.columnPLANGODINAIDGODINE.AllowDBNull = false;
                this.columnPLANGODINAIDGODINE.Caption = "IDGODINE";
                this.columnPLANGODINAIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("SuperType", "IDGODINE");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("SubtypeGroup", "PLANGODINA");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("IsKey", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Description", "IDGODINE");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "PLANGODINAIDGODINE");
                this.Columns.Add(this.columnPLANGODINAIDGODINE);
                this.columnPLANOJIDORGJED = new DataColumn("PLANOJIDORGJED", typeof(int), "", MappingType.Element);
                this.columnPLANOJIDORGJED.AllowDBNull = false;
                this.columnPLANOJIDORGJED.Caption = "Šifra OJ";
                this.columnPLANOJIDORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("SuperType", "IDORGJED");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("SubtypeGroup", "PLANOJ");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("IsKey", "true");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Description", "Šifra OJ");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Length", "8");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.InternalName", "PLANOJIDORGJED");
                this.Columns.Add(this.columnPLANOJIDORGJED);
                this.columnPLANOJNAZIVORGJED = new DataColumn("PLANOJNAZIVORGJED", typeof(string), "", MappingType.Element);
                this.columnPLANOJNAZIVORGJED.AllowDBNull = true;
                this.columnPLANOJNAZIVORGJED.Caption = "Naziv OJ";
                this.columnPLANOJNAZIVORGJED.MaxLength = 100;
                this.columnPLANOJNAZIVORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("SuperType", "NAZIVORGJED");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("SubtypeGroup", "PLANOJ");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("IsKey", "false");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("Description", "Naziv OJ");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("Length", "100");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("RightTrim", "true");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLANOJNAZIVORGJED.ExtendedProperties.Add("Deklarit.InternalName", "PLANOJNAZIVORGJED");
                this.Columns.Add(this.columnPLANOJNAZIVORGJED);
                this.PrimaryKey = new DataColumn[] { this.columnIDPLAN, this.columnPLANGODINAIDGODINE, this.columnPLANOJIDORGJED };
                this.ExtendedProperties.Add("ParentLvl", "PLAN");
                this.ExtendedProperties.Add("LevelName", "ORG");
                this.ExtendedProperties.Add("Description", "ORG");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDPLAN = this.Columns["IDPLAN"];
                this.columnPLANGODINAIDGODINE = this.Columns["PLANGODINAIDGODINE"];
                this.columnPLANOJIDORGJED = this.Columns["PLANOJIDORGJED"];
                this.columnPLANOJNAZIVORGJED = this.Columns["PLANOJNAZIVORGJED"];
            }

            public PLANDataSet.PLANORGRow NewPLANORGRow()
            {
                return (PLANDataSet.PLANORGRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PLANDataSet.PLANORGRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PLANORGRowChanged != null)
                {
                    PLANDataSet.PLANORGRowChangeEventHandler pLANORGRowChangedEvent = this.PLANORGRowChanged;
                    if (pLANORGRowChangedEvent != null)
                    {
                        pLANORGRowChangedEvent(this, new PLANDataSet.PLANORGRowChangeEvent((PLANDataSet.PLANORGRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PLANORGRowChanging != null)
                {
                    PLANDataSet.PLANORGRowChangeEventHandler pLANORGRowChangingEvent = this.PLANORGRowChanging;
                    if (pLANORGRowChangingEvent != null)
                    {
                        pLANORGRowChangingEvent(this, new PLANDataSet.PLANORGRowChangeEvent((PLANDataSet.PLANORGRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("PLAN_PLANORG", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.PLANORGRowDeleted != null)
                {
                    PLANDataSet.PLANORGRowChangeEventHandler pLANORGRowDeletedEvent = this.PLANORGRowDeleted;
                    if (pLANORGRowDeletedEvent != null)
                    {
                        pLANORGRowDeletedEvent(this, new PLANDataSet.PLANORGRowChangeEvent((PLANDataSet.PLANORGRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PLANORGRowDeleting != null)
                {
                    PLANDataSet.PLANORGRowChangeEventHandler pLANORGRowDeletingEvent = this.PLANORGRowDeleting;
                    if (pLANORGRowDeletingEvent != null)
                    {
                        pLANORGRowDeletingEvent(this, new PLANDataSet.PLANORGRowChangeEvent((PLANDataSet.PLANORGRow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePLANORGRow(PLANDataSet.PLANORGRow row)
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

            public DataColumn IDPLANColumn
            {
                get
                {
                    return this.columnIDPLAN;
                }
            }

            public PLANDataSet.PLANORGRow this[int index]
            {
                get
                {
                    return (PLANDataSet.PLANORGRow) this.Rows[index];
                }
            }

            public DataColumn PLANGODINAIDGODINEColumn
            {
                get
                {
                    return this.columnPLANGODINAIDGODINE;
                }
            }

            public DataColumn PLANOJIDORGJEDColumn
            {
                get
                {
                    return this.columnPLANOJIDORGJED;
                }
            }

            public DataColumn PLANOJNAZIVORGJEDColumn
            {
                get
                {
                    return this.columnPLANOJNAZIVORGJED;
                }
            }
        }

        [Serializable]
        public class PLANORGKONDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDPLAN;
            private DataColumn columnPLANGODINAIDGODINE;
            private DataColumn columnPLANIRANIIZNOS;
            private DataColumn columnPLANKONTOIDKONTO;
            private DataColumn columnPLANOJIDORGJED;

            public event PLANDataSet.PLANORGKONRowChangeEventHandler PLANORGKONRowChanged;

            public event PLANDataSet.PLANORGKONRowChangeEventHandler PLANORGKONRowChanging;

            public event PLANDataSet.PLANORGKONRowChangeEventHandler PLANORGKONRowDeleted;

            public event PLANDataSet.PLANORGKONRowChangeEventHandler PLANORGKONRowDeleting;

            public PLANORGKONDataTable()
            {
                this.TableName = "PLANORGKON";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal PLANORGKONDataTable(DataTable table) : base(table.TableName)
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

            protected PLANORGKONDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPLANORGKONRow(PLANDataSet.PLANORGKONRow row)
            {
                this.Rows.Add(row);
            }

            public PLANDataSet.PLANORGKONRow AddPLANORGKONRow(int iDPLAN, short pLANGODINAIDGODINE, int pLANOJIDORGJED, string pLANKONTOIDKONTO, decimal pLANIRANIIZNOS)
            {
                PLANDataSet.PLANORGKONRow row = (PLANDataSet.PLANORGKONRow) this.NewRow();
                row["IDPLAN"] = iDPLAN;
                row["PLANGODINAIDGODINE"] = pLANGODINAIDGODINE;
                row["PLANOJIDORGJED"] = pLANOJIDORGJED;
                row["PLANKONTOIDKONTO"] = pLANKONTOIDKONTO;
                row["PLANIRANIIZNOS"] = pLANIRANIIZNOS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                PLANDataSet.PLANORGKONDataTable table = (PLANDataSet.PLANORGKONDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public PLANDataSet.PLANORGKONRow FindByIDPLANPLANGODINAIDGODINEPLANOJIDORGJEDPLANKONTOIDKONTO(int iDPLAN, short pLANGODINAIDGODINE, int pLANOJIDORGJED, string pLANKONTOIDKONTO)
            {
                return (PLANDataSet.PLANORGKONRow) this.Rows.Find(new object[] { iDPLAN, pLANGODINAIDGODINE, pLANOJIDORGJED, pLANKONTOIDKONTO });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(PLANDataSet.PLANORGKONRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                PLANDataSet set = new PLANDataSet();
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
                this.columnIDPLAN = new DataColumn("IDPLAN", typeof(int), "", MappingType.Element);
                this.columnIDPLAN.AllowDBNull = false;
                this.columnIDPLAN.Caption = "IDPLAN";
                this.columnIDPLAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPLAN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDPLAN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDPLAN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPLAN.ExtendedProperties.Add("Description", "IDPLAN");
                this.columnIDPLAN.ExtendedProperties.Add("Length", "5");
                this.columnIDPLAN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPLAN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPLAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPLAN.ExtendedProperties.Add("Deklarit.InternalName", "IDPLAN");
                this.Columns.Add(this.columnIDPLAN);
                this.columnPLANGODINAIDGODINE = new DataColumn("PLANGODINAIDGODINE", typeof(short), "", MappingType.Element);
                this.columnPLANGODINAIDGODINE.AllowDBNull = false;
                this.columnPLANGODINAIDGODINE.Caption = "IDGODINE";
                this.columnPLANGODINAIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("SuperType", "IDGODINE");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("SubtypeGroup", "PLANGODINA");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("IsKey", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Description", "IDGODINE");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLANGODINAIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "PLANGODINAIDGODINE");
                this.Columns.Add(this.columnPLANGODINAIDGODINE);
                this.columnPLANOJIDORGJED = new DataColumn("PLANOJIDORGJED", typeof(int), "", MappingType.Element);
                this.columnPLANOJIDORGJED.AllowDBNull = false;
                this.columnPLANOJIDORGJED.Caption = "Šifra OJ";
                this.columnPLANOJIDORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("SuperType", "IDORGJED");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("SubtypeGroup", "PLANOJ");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("IsKey", "true");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Description", "Šifra OJ");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Length", "8");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLANOJIDORGJED.ExtendedProperties.Add("Deklarit.InternalName", "PLANOJIDORGJED");
                this.Columns.Add(this.columnPLANOJIDORGJED);
                this.columnPLANKONTOIDKONTO = new DataColumn("PLANKONTOIDKONTO", typeof(string), "", MappingType.Element);
                this.columnPLANKONTOIDKONTO.AllowDBNull = false;
                this.columnPLANKONTOIDKONTO.Caption = "Konto";
                this.columnPLANKONTOIDKONTO.MaxLength = 14;
                this.columnPLANKONTOIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("SubtypeGroup", "PLANKONTO");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("IsKey", "true");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLANKONTOIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "PLANKONTOIDKONTO");
                this.Columns.Add(this.columnPLANKONTOIDKONTO);
                this.columnPLANIRANIIZNOS = new DataColumn("PLANIRANIIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnPLANIRANIIZNOS.AllowDBNull = false;
                this.columnPLANIRANIIZNOS.Caption = "PLANIRANIIZNOS";
                this.columnPLANIRANIIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("Description", "PLANIRANIIZNOS");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLANIRANIIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "PLANIRANIIZNOS");
                this.Columns.Add(this.columnPLANIRANIIZNOS);
                this.PrimaryKey = new DataColumn[] { this.columnIDPLAN, this.columnPLANGODINAIDGODINE, this.columnPLANOJIDORGJED, this.columnPLANKONTOIDKONTO };
                this.ExtendedProperties.Add("ParentLvl", "PLANORG");
                this.ExtendedProperties.Add("LevelName", "KON");
                this.ExtendedProperties.Add("Description", "KON");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDPLAN = this.Columns["IDPLAN"];
                this.columnPLANGODINAIDGODINE = this.Columns["PLANGODINAIDGODINE"];
                this.columnPLANOJIDORGJED = this.Columns["PLANOJIDORGJED"];
                this.columnPLANKONTOIDKONTO = this.Columns["PLANKONTOIDKONTO"];
                this.columnPLANIRANIIZNOS = this.Columns["PLANIRANIIZNOS"];
            }

            public PLANDataSet.PLANORGKONRow NewPLANORGKONRow()
            {
                return (PLANDataSet.PLANORGKONRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PLANDataSet.PLANORGKONRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PLANORGKONRowChanged != null)
                {
                    PLANDataSet.PLANORGKONRowChangeEventHandler pLANORGKONRowChangedEvent = this.PLANORGKONRowChanged;
                    if (pLANORGKONRowChangedEvent != null)
                    {
                        pLANORGKONRowChangedEvent(this, new PLANDataSet.PLANORGKONRowChangeEvent((PLANDataSet.PLANORGKONRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PLANORGKONRowChanging != null)
                {
                    PLANDataSet.PLANORGKONRowChangeEventHandler pLANORGKONRowChangingEvent = this.PLANORGKONRowChanging;
                    if (pLANORGKONRowChangingEvent != null)
                    {
                        pLANORGKONRowChangingEvent(this, new PLANDataSet.PLANORGKONRowChangeEvent((PLANDataSet.PLANORGKONRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("PLANORG_PLANORGKON", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.PLANORGKONRowDeleted != null)
                {
                    PLANDataSet.PLANORGKONRowChangeEventHandler pLANORGKONRowDeletedEvent = this.PLANORGKONRowDeleted;
                    if (pLANORGKONRowDeletedEvent != null)
                    {
                        pLANORGKONRowDeletedEvent(this, new PLANDataSet.PLANORGKONRowChangeEvent((PLANDataSet.PLANORGKONRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PLANORGKONRowDeleting != null)
                {
                    PLANDataSet.PLANORGKONRowChangeEventHandler pLANORGKONRowDeletingEvent = this.PLANORGKONRowDeleting;
                    if (pLANORGKONRowDeletingEvent != null)
                    {
                        pLANORGKONRowDeletingEvent(this, new PLANDataSet.PLANORGKONRowChangeEvent((PLANDataSet.PLANORGKONRow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePLANORGKONRow(PLANDataSet.PLANORGKONRow row)
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

            public DataColumn IDPLANColumn
            {
                get
                {
                    return this.columnIDPLAN;
                }
            }

            public PLANDataSet.PLANORGKONRow this[int index]
            {
                get
                {
                    return (PLANDataSet.PLANORGKONRow) this.Rows[index];
                }
            }

            public DataColumn PLANGODINAIDGODINEColumn
            {
                get
                {
                    return this.columnPLANGODINAIDGODINE;
                }
            }

            public DataColumn PLANIRANIIZNOSColumn
            {
                get
                {
                    return this.columnPLANIRANIIZNOS;
                }
            }

            public DataColumn PLANKONTOIDKONTOColumn
            {
                get
                {
                    return this.columnPLANKONTOIDKONTO;
                }
            }

            public DataColumn PLANOJIDORGJEDColumn
            {
                get
                {
                    return this.columnPLANOJIDORGJED;
                }
            }
        }

        public class PLANORGKONRow : DataRow
        {
            private PLANDataSet.PLANORGKONDataTable tablePLANORGKON;

            internal PLANORGKONRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePLANORGKON = (PLANDataSet.PLANORGKONDataTable) this.Table;
            }

            public PLANDataSet.PLANORGRow GetPLANORGRow()
            {
                return (PLANDataSet.PLANORGRow) this.GetParentRow("PLANORG_PLANORGKON");
            }

            public bool IsIDPLANNull()
            {
                return this.IsNull(this.tablePLANORGKON.IDPLANColumn);
            }

            public bool IsPLANGODINAIDGODINENull()
            {
                return this.IsNull(this.tablePLANORGKON.PLANGODINAIDGODINEColumn);
            }

            public bool IsPLANIRANIIZNOSNull()
            {
                return this.IsNull(this.tablePLANORGKON.PLANIRANIIZNOSColumn);
            }

            public bool IsPLANKONTOIDKONTONull()
            {
                return this.IsNull(this.tablePLANORGKON.PLANKONTOIDKONTOColumn);
            }

            public bool IsPLANOJIDORGJEDNull()
            {
                return this.IsNull(this.tablePLANORGKON.PLANOJIDORGJEDColumn);
            }

            public void SetPLANIRANIIZNOSNull()
            {
                this[this.tablePLANORGKON.PLANIRANIIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDPLAN
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePLANORGKON.IDPLANColumn]);
                }
                set
                {
                    this[this.tablePLANORGKON.IDPLANColumn] = value;
                }
            }

            public short PLANGODINAIDGODINE
            {
                get
                {
                    return Conversions.ToShort(this[this.tablePLANORGKON.PLANGODINAIDGODINEColumn]);
                }
                set
                {
                    this[this.tablePLANORGKON.PLANGODINAIDGODINEColumn] = value;
                }
            }

            public decimal PLANIRANIIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePLANORGKON.PLANIRANIIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePLANORGKON.PLANIRANIIZNOSColumn] = value;
                }
            }

            public string PLANKONTOIDKONTO
            {
                get
                {
                    return Conversions.ToString(this[this.tablePLANORGKON.PLANKONTOIDKONTOColumn]);
                }
                set
                {
                    this[this.tablePLANORGKON.PLANKONTOIDKONTOColumn] = value;
                }
            }

            public int PLANOJIDORGJED
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePLANORGKON.PLANOJIDORGJEDColumn]);
                }
                set
                {
                    this[this.tablePLANORGKON.PLANOJIDORGJEDColumn] = value;
                }
            }
        }

        public class PLANORGKONRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private PLANDataSet.PLANORGKONRow eventRow;

            public PLANORGKONRowChangeEvent(PLANDataSet.PLANORGKONRow row, DataRowAction action)
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

            public PLANDataSet.PLANORGKONRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PLANORGKONRowChangeEventHandler(object sender, PLANDataSet.PLANORGKONRowChangeEvent e);

        public class PLANORGRow : DataRow
        {
            private PLANDataSet.PLANORGDataTable tablePLANORG;

            internal PLANORGRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePLANORG = (PLANDataSet.PLANORGDataTable) this.Table;
            }

            public PLANDataSet.PLANORGKONRow[] GetPLANORGKONRows()
            {
                return (PLANDataSet.PLANORGKONRow[]) this.GetChildRows("PLANORG_PLANORGKON");
            }

            public PLANDataSet.PLANRow GetPLANRow()
            {
                return (PLANDataSet.PLANRow) this.GetParentRow("PLAN_PLANORG");
            }

            public bool IsIDPLANNull()
            {
                return this.IsNull(this.tablePLANORG.IDPLANColumn);
            }

            public bool IsPLANGODINAIDGODINENull()
            {
                return this.IsNull(this.tablePLANORG.PLANGODINAIDGODINEColumn);
            }

            public bool IsPLANOJIDORGJEDNull()
            {
                return this.IsNull(this.tablePLANORG.PLANOJIDORGJEDColumn);
            }

            public bool IsPLANOJNAZIVORGJEDNull()
            {
                return this.IsNull(this.tablePLANORG.PLANOJNAZIVORGJEDColumn);
            }

            public void SetPLANOJNAZIVORGJEDNull()
            {
                this[this.tablePLANORG.PLANOJNAZIVORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDPLAN
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePLANORG.IDPLANColumn]);
                }
                set
                {
                    this[this.tablePLANORG.IDPLANColumn] = value;
                }
            }

            public short PLANGODINAIDGODINE
            {
                get
                {
                    return Conversions.ToShort(this[this.tablePLANORG.PLANGODINAIDGODINEColumn]);
                }
                set
                {
                    this[this.tablePLANORG.PLANGODINAIDGODINEColumn] = value;
                }
            }

            public int PLANOJIDORGJED
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePLANORG.PLANOJIDORGJEDColumn]);
                }
                set
                {
                    this[this.tablePLANORG.PLANOJIDORGJEDColumn] = value;
                }
            }

            public string PLANOJNAZIVORGJED
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePLANORG.PLANOJNAZIVORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePLANORG.PLANOJNAZIVORGJEDColumn] = value;
                }
            }
        }

        public class PLANORGRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private PLANDataSet.PLANORGRow eventRow;

            public PLANORGRowChangeEvent(PLANDataSet.PLANORGRow row, DataRowAction action)
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

            public PLANDataSet.PLANORGRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PLANORGRowChangeEventHandler(object sender, PLANDataSet.PLANORGRowChangeEvent e);

        public class PLANRow : DataRow
        {
            private PLANDataSet.PLANDataTable tablePLAN;

            internal PLANRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePLAN = (PLANDataSet.PLANDataTable) this.Table;
            }

            public PLANDataSet.PLANORGRow[] GetPLANORGRows()
            {
                return (PLANDataSet.PLANORGRow[]) this.GetChildRows("PLAN_PLANORG");
            }

            public bool IsIDPLANNull()
            {
                return this.IsNull(this.tablePLAN.IDPLANColumn);
            }

            public bool IsPLANGODINAIDGODINENull()
            {
                return this.IsNull(this.tablePLAN.PLANGODINAIDGODINEColumn);
            }

            public bool IsRADNINAZIVPLANANull()
            {
                return this.IsNull(this.tablePLAN.RADNINAZIVPLANAColumn);
            }

            public void SetRADNINAZIVPLANANull()
            {
                this[this.tablePLAN.RADNINAZIVPLANAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDPLAN
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePLAN.IDPLANColumn]);
                }
                set
                {
                    this[this.tablePLAN.IDPLANColumn] = value;
                }
            }

            public short PLANGODINAIDGODINE
            {
                get
                {
                    return Conversions.ToShort(this[this.tablePLAN.PLANGODINAIDGODINEColumn]);
                }
                set
                {
                    this[this.tablePLAN.PLANGODINAIDGODINEColumn] = value;
                }
            }

            public string RADNINAZIVPLANA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePLAN.RADNINAZIVPLANAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePLAN.RADNINAZIVPLANAColumn] = value;
                }
            }
        }

        public class PLANRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private PLANDataSet.PLANRow eventRow;

            public PLANRowChangeEvent(PLANDataSet.PLANRow row, DataRowAction action)
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

            public PLANDataSet.PLANRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PLANRowChangeEventHandler(object sender, PLANDataSet.PLANRowChangeEvent e);
    }
}

