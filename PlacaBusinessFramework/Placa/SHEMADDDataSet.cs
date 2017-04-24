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
    public class SHEMADDDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private SHEMADDDataTable tableSHEMADD;
        private SHEMADDSHEMADDDOPRINOSDataTable tableSHEMADDSHEMADDDOPRINOS;
        private SHEMADDSHEMADDSTANDARDDataTable tableSHEMADDSHEMADDSTANDARD;

        public SHEMADDDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected SHEMADDDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["SHEMADDSHEMADDSTANDARD"] != null)
                    {
                        this.Tables.Add(new SHEMADDSHEMADDSTANDARDDataTable(dataSet.Tables["SHEMADDSHEMADDSTANDARD"]));
                    }
                    if (dataSet.Tables["SHEMADDSHEMADDDOPRINOS"] != null)
                    {
                        this.Tables.Add(new SHEMADDSHEMADDDOPRINOSDataTable(dataSet.Tables["SHEMADDSHEMADDDOPRINOS"]));
                    }
                    if (dataSet.Tables["SHEMADD"] != null)
                    {
                        this.Tables.Add(new SHEMADDDataTable(dataSet.Tables["SHEMADD"]));
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
            SHEMADDDataSet set = (SHEMADDDataSet) base.Clone();
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
            SHEMADDDataSet set = new SHEMADDDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "SHEMADDDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2127");
            this.ExtendedProperties.Add("DataSetName", "SHEMADDDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ISHEMADDDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "SHEMADD");
            this.ExtendedProperties.Add("ObjectDescription", "Shema drugi dohodak");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents");
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
            this.DataSetName = "SHEMADDDataSet";
            this.Namespace = "http://www.tempuri.org/SHEMADD";
            this.tableSHEMADDSHEMADDSTANDARD = new SHEMADDSHEMADDSTANDARDDataTable();
            this.Tables.Add(this.tableSHEMADDSHEMADDSTANDARD);
            this.tableSHEMADDSHEMADDDOPRINOS = new SHEMADDSHEMADDDOPRINOSDataTable();
            this.Tables.Add(this.tableSHEMADDSHEMADDDOPRINOS);
            this.tableSHEMADD = new SHEMADDDataTable();
            this.Tables.Add(this.tableSHEMADD);
            this.Relations.Add("SHEMADD_SHEMADDSHEMADDSTANDARD", new DataColumn[] { this.Tables["SHEMADD"].Columns["IDSHEMADD"] }, new DataColumn[] { this.Tables["SHEMADDSHEMADDSTANDARD"].Columns["IDSHEMADD"] });
            this.Relations["SHEMADD_SHEMADDSHEMADDSTANDARD"].Nested = true;
            this.Relations.Add("SHEMADD_SHEMADDSHEMADDDOPRINOS", new DataColumn[] { this.Tables["SHEMADD"].Columns["IDSHEMADD"] }, new DataColumn[] { this.Tables["SHEMADDSHEMADDDOPRINOS"].Columns["IDSHEMADD"] });
            this.Relations["SHEMADD_SHEMADDSHEMADDDOPRINOS"].Nested = true;
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
            this.tableSHEMADDSHEMADDSTANDARD = (SHEMADDSHEMADDSTANDARDDataTable) this.Tables["SHEMADDSHEMADDSTANDARD"];
            this.tableSHEMADDSHEMADDDOPRINOS = (SHEMADDSHEMADDDOPRINOSDataTable) this.Tables["SHEMADDSHEMADDDOPRINOS"];
            this.tableSHEMADD = (SHEMADDDataTable) this.Tables["SHEMADD"];
            if (initTable)
            {
                if (this.tableSHEMADDSHEMADDSTANDARD != null)
                {
                    this.tableSHEMADDSHEMADDSTANDARD.InitVars();
                }
                if (this.tableSHEMADDSHEMADDDOPRINOS != null)
                {
                    this.tableSHEMADDSHEMADDDOPRINOS.InitVars();
                }
                if (this.tableSHEMADD != null)
                {
                    this.tableSHEMADD.InitVars();
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
                if (dataSet.Tables["SHEMADDSHEMADDSTANDARD"] != null)
                {
                    this.Tables.Add(new SHEMADDSHEMADDSTANDARDDataTable(dataSet.Tables["SHEMADDSHEMADDSTANDARD"]));
                }
                if (dataSet.Tables["SHEMADDSHEMADDDOPRINOS"] != null)
                {
                    this.Tables.Add(new SHEMADDSHEMADDDOPRINOSDataTable(dataSet.Tables["SHEMADDSHEMADDDOPRINOS"]));
                }
                if (dataSet.Tables["SHEMADD"] != null)
                {
                    this.Tables.Add(new SHEMADDDataTable(dataSet.Tables["SHEMADD"]));
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

        private bool ShouldSerializeSHEMADD()
        {
            return false;
        }

        private bool ShouldSerializeSHEMADDSHEMADDDOPRINOS()
        {
            return false;
        }

        private bool ShouldSerializeSHEMADDSHEMADDSTANDARD()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SHEMADDDataTable SHEMADD
        {
            get
            {
                return this.tableSHEMADD;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SHEMADDSHEMADDDOPRINOSDataTable SHEMADDSHEMADDDOPRINOS
        {
            get
            {
                return this.tableSHEMADDSHEMADDDOPRINOS;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SHEMADDSHEMADDSTANDARDDataTable SHEMADDSHEMADDSTANDARD
        {
            get
            {
                return this.tableSHEMADDSHEMADDSTANDARD;
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
        public class SHEMADDDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSHEMADD;
            private DataColumn columnNAZIVSHEMADD;
            private DataColumn columnSHEMADDOJIDORGJED;

            public event SHEMADDDataSet.SHEMADDRowChangeEventHandler SHEMADDRowChanged;

            public event SHEMADDDataSet.SHEMADDRowChangeEventHandler SHEMADDRowChanging;

            public event SHEMADDDataSet.SHEMADDRowChangeEventHandler SHEMADDRowDeleted;

            public event SHEMADDDataSet.SHEMADDRowChangeEventHandler SHEMADDRowDeleting;

            public SHEMADDDataTable()
            {
                this.TableName = "SHEMADD";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SHEMADDDataTable(DataTable table) : base(table.TableName)
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

            protected SHEMADDDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSHEMADDRow(SHEMADDDataSet.SHEMADDRow row)
            {
                this.Rows.Add(row);
            }

            public SHEMADDDataSet.SHEMADDRow AddSHEMADDRow(int iDSHEMADD, string nAZIVSHEMADD, int sHEMADDOJIDORGJED)
            {
                SHEMADDDataSet.SHEMADDRow row = (SHEMADDDataSet.SHEMADDRow) this.NewRow();
                row["IDSHEMADD"] = iDSHEMADD;
                row["NAZIVSHEMADD"] = nAZIVSHEMADD;
                row["SHEMADDOJIDORGJED"] = sHEMADDOJIDORGJED;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SHEMADDDataSet.SHEMADDDataTable table = (SHEMADDDataSet.SHEMADDDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SHEMADDDataSet.SHEMADDRow FindByIDSHEMADD(int iDSHEMADD)
            {
                return (SHEMADDDataSet.SHEMADDRow) this.Rows.Find(new object[] { iDSHEMADD });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SHEMADDDataSet.SHEMADDRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SHEMADDDataSet set = new SHEMADDDataSet();
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
                this.columnIDSHEMADD = new DataColumn("IDSHEMADD", typeof(int), "", MappingType.Element);
                this.columnIDSHEMADD.AllowDBNull = false;
                this.columnIDSHEMADD.Caption = "IDSHEMADD";
                this.columnIDSHEMADD.Unique = true;
                this.columnIDSHEMADD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSHEMADD.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSHEMADD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSHEMADD.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDSHEMADD.ExtendedProperties.Add("Length", "5");
                this.columnIDSHEMADD.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSHEMADD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSHEMADD.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.InternalName", "IDSHEMADD");
                this.Columns.Add(this.columnIDSHEMADD);
                this.columnNAZIVSHEMADD = new DataColumn("NAZIVSHEMADD", typeof(string), "", MappingType.Element);
                this.columnNAZIVSHEMADD.AllowDBNull = false;
                this.columnNAZIVSHEMADD.Caption = "NAZIVSHEMADD";
                this.columnNAZIVSHEMADD.MaxLength = 50;
                this.columnNAZIVSHEMADD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("Description", "Naziv");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVSHEMADD.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVSHEMADD");
                this.Columns.Add(this.columnNAZIVSHEMADD);
                this.columnSHEMADDOJIDORGJED = new DataColumn("SHEMADDOJIDORGJED", typeof(int), "", MappingType.Element);
                this.columnSHEMADDOJIDORGJED.AllowDBNull = false;
                this.columnSHEMADDOJIDORGJED.Caption = "Šifra OJ";
                this.columnSHEMADDOJIDORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("SuperType", "IDORGJED");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("SubtypeGroup", "SHEMADDOJ");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("IsKey", "false");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("Description", "Šifra OJ");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("Length", "8");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("IsInReader", "true");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMADDOJIDORGJED.ExtendedProperties.Add("Deklarit.InternalName", "SHEMADDOJIDORGJED");
                this.Columns.Add(this.columnSHEMADDOJIDORGJED);
                this.PrimaryKey = new DataColumn[] { this.columnIDSHEMADD };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "SHEMADD");
                this.ExtendedProperties.Add("Description", "Shema drugi dohodak");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDSHEMADD = this.Columns["IDSHEMADD"];
                this.columnNAZIVSHEMADD = this.Columns["NAZIVSHEMADD"];
                this.columnSHEMADDOJIDORGJED = this.Columns["SHEMADDOJIDORGJED"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SHEMADDDataSet.SHEMADDRow(builder);
            }

            public SHEMADDDataSet.SHEMADDRow NewSHEMADDRow()
            {
                return (SHEMADDDataSet.SHEMADDRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SHEMADDRowChanged != null)
                {
                    SHEMADDDataSet.SHEMADDRowChangeEventHandler sHEMADDRowChangedEvent = this.SHEMADDRowChanged;
                    if (sHEMADDRowChangedEvent != null)
                    {
                        sHEMADDRowChangedEvent(this, new SHEMADDDataSet.SHEMADDRowChangeEvent((SHEMADDDataSet.SHEMADDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SHEMADDRowChanging != null)
                {
                    SHEMADDDataSet.SHEMADDRowChangeEventHandler sHEMADDRowChangingEvent = this.SHEMADDRowChanging;
                    if (sHEMADDRowChangingEvent != null)
                    {
                        sHEMADDRowChangingEvent(this, new SHEMADDDataSet.SHEMADDRowChangeEvent((SHEMADDDataSet.SHEMADDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SHEMADDRowDeleted != null)
                {
                    SHEMADDDataSet.SHEMADDRowChangeEventHandler sHEMADDRowDeletedEvent = this.SHEMADDRowDeleted;
                    if (sHEMADDRowDeletedEvent != null)
                    {
                        sHEMADDRowDeletedEvent(this, new SHEMADDDataSet.SHEMADDRowChangeEvent((SHEMADDDataSet.SHEMADDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SHEMADDRowDeleting != null)
                {
                    SHEMADDDataSet.SHEMADDRowChangeEventHandler sHEMADDRowDeletingEvent = this.SHEMADDRowDeleting;
                    if (sHEMADDRowDeletingEvent != null)
                    {
                        sHEMADDRowDeletingEvent(this, new SHEMADDDataSet.SHEMADDRowChangeEvent((SHEMADDDataSet.SHEMADDRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSHEMADDRow(SHEMADDDataSet.SHEMADDRow row)
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

            public DataColumn IDSHEMADDColumn
            {
                get
                {
                    return this.columnIDSHEMADD;
                }
            }

            public SHEMADDDataSet.SHEMADDRow this[int index]
            {
                get
                {
                    return (SHEMADDDataSet.SHEMADDRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVSHEMADDColumn
            {
                get
                {
                    return this.columnNAZIVSHEMADD;
                }
            }

            public DataColumn SHEMADDOJIDORGJEDColumn
            {
                get
                {
                    return this.columnSHEMADDOJIDORGJED;
                }
            }
        }

        public class SHEMADDRow : DataRow
        {
            private SHEMADDDataSet.SHEMADDDataTable tableSHEMADD;

            internal SHEMADDRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSHEMADD = (SHEMADDDataSet.SHEMADDDataTable) this.Table;
            }

            public SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow[] GetSHEMADDSHEMADDDOPRINOSRows()
            {
                return (SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow[]) this.GetChildRows("SHEMADD_SHEMADDSHEMADDDOPRINOS");
            }

            public SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow[] GetSHEMADDSHEMADDSTANDARDRows()
            {
                return (SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow[]) this.GetChildRows("SHEMADD_SHEMADDSHEMADDSTANDARD");
            }

            public bool IsIDSHEMADDNull()
            {
                return this.IsNull(this.tableSHEMADD.IDSHEMADDColumn);
            }

            public bool IsNAZIVSHEMADDNull()
            {
                return this.IsNull(this.tableSHEMADD.NAZIVSHEMADDColumn);
            }

            public bool IsSHEMADDOJIDORGJEDNull()
            {
                return this.IsNull(this.tableSHEMADD.SHEMADDOJIDORGJEDColumn);
            }

            public void SetNAZIVSHEMADDNull()
            {
                this[this.tableSHEMADD.NAZIVSHEMADDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSHEMADDOJIDORGJEDNull()
            {
                this[this.tableSHEMADD.SHEMADDOJIDORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSHEMADD
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMADD.IDSHEMADDColumn]);
                }
                set
                {
                    this[this.tableSHEMADD.IDSHEMADDColumn] = value;
                }
            }

            public string NAZIVSHEMADD
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSHEMADD.NAZIVSHEMADDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVSHEMADD because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableSHEMADD.NAZIVSHEMADDColumn] = value;
                }
            }

            public int SHEMADDOJIDORGJED
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMADD.SHEMADDOJIDORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SHEMADDOJIDORGJED because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMADD.SHEMADDOJIDORGJEDColumn] = value;
                }
            }
        }

        public class SHEMADDRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SHEMADDDataSet.SHEMADDRow eventRow;

            public SHEMADDRowChangeEvent(SHEMADDDataSet.SHEMADDRow row, DataRowAction action)
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

            public SHEMADDDataSet.SHEMADDRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SHEMADDRowChangeEventHandler(object sender, SHEMADDDataSet.SHEMADDRowChangeEvent e);

        [Serializable]
        public class SHEMADDSHEMADDDOPRINOSDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSHEMADD;
            private DataColumn columnKONTODOPIDKONTO;
            private DataColumn columnMTDOPIDMJESTOTROSKA;
            private DataColumn columnSHEMADDDOPRINOSIDDOPRINOS;
            private DataColumn columnSHEMADDDOPRINOSNAZIVDOPRINOS;
            private DataColumn columnSTRANEDOPIDSTRANEKNJIZENJA;

            public event SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRowChangeEventHandler SHEMADDSHEMADDDOPRINOSRowChanged;

            public event SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRowChangeEventHandler SHEMADDSHEMADDDOPRINOSRowChanging;

            public event SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRowChangeEventHandler SHEMADDSHEMADDDOPRINOSRowDeleted;

            public event SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRowChangeEventHandler SHEMADDSHEMADDDOPRINOSRowDeleting;

            public SHEMADDSHEMADDDOPRINOSDataTable()
            {
                this.TableName = "SHEMADDSHEMADDDOPRINOS";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SHEMADDSHEMADDDOPRINOSDataTable(DataTable table) : base(table.TableName)
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

            protected SHEMADDSHEMADDDOPRINOSDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSHEMADDSHEMADDDOPRINOSRow(SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow row)
            {
                this.Rows.Add(row);
            }

            public SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow AddSHEMADDSHEMADDDOPRINOSRow(int iDSHEMADD, int sHEMADDDOPRINOSIDDOPRINOS, string kONTODOPIDKONTO, int mTDOPIDMJESTOTROSKA, int sTRANEDOPIDSTRANEKNJIZENJA)
            {
                SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow row = (SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow) this.NewRow();
                row["IDSHEMADD"] = iDSHEMADD;
                row["SHEMADDDOPRINOSIDDOPRINOS"] = sHEMADDDOPRINOSIDDOPRINOS;
                row["KONTODOPIDKONTO"] = kONTODOPIDKONTO;
                row["MTDOPIDMJESTOTROSKA"] = mTDOPIDMJESTOTROSKA;
                row["STRANEDOPIDSTRANEKNJIZENJA"] = sTRANEDOPIDSTRANEKNJIZENJA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSDataTable table = (SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow FindByIDSHEMADDSHEMADDDOPRINOSIDDOPRINOSKONTODOPIDKONTO(int iDSHEMADD, int sHEMADDDOPRINOSIDDOPRINOS, string kONTODOPIDKONTO)
            {
                return (SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow) this.Rows.Find(new object[] { iDSHEMADD, sHEMADDDOPRINOSIDDOPRINOS, kONTODOPIDKONTO });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SHEMADDDataSet set = new SHEMADDDataSet();
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
                this.columnIDSHEMADD = new DataColumn("IDSHEMADD", typeof(int), "", MappingType.Element);
                this.columnIDSHEMADD.AllowDBNull = false;
                this.columnIDSHEMADD.Caption = "IDSHEMADD";
                this.columnIDSHEMADD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSHEMADD.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSHEMADD.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDSHEMADD.ExtendedProperties.Add("Length", "5");
                this.columnIDSHEMADD.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSHEMADD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSHEMADD.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.InternalName", "IDSHEMADD");
                this.Columns.Add(this.columnIDSHEMADD);
                this.columnSHEMADDDOPRINOSIDDOPRINOS = new DataColumn("SHEMADDDOPRINOSIDDOPRINOS", typeof(int), "", MappingType.Element);
                this.columnSHEMADDDOPRINOSIDDOPRINOS.AllowDBNull = false;
                this.columnSHEMADDDOPRINOSIDDOPRINOS.Caption = "Šifra doprinosa";
                this.columnSHEMADDDOPRINOSIDDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("SuperType", "IDDOPRINOS");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("SubtypeGroup", "SHEMADDDOPRINOS");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("IsKey", "true");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("Description", "Šifra doprinosa");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("Length", "8");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMADDDOPRINOSIDDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "SHEMADDDOPRINOSIDDOPRINOS");
                this.Columns.Add(this.columnSHEMADDDOPRINOSIDDOPRINOS);
                this.columnKONTODOPIDKONTO = new DataColumn("KONTODOPIDKONTO", typeof(string), "", MappingType.Element);
                this.columnKONTODOPIDKONTO.AllowDBNull = false;
                this.columnKONTODOPIDKONTO.Caption = "Konto";
                this.columnKONTODOPIDKONTO.MaxLength = 14;
                this.columnKONTODOPIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("SubtypeGroup", "KONTODOP");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("IsKey", "true");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "KONTODOPIDKONTO");
                this.Columns.Add(this.columnKONTODOPIDKONTO);
                this.columnMTDOPIDMJESTOTROSKA = new DataColumn("MTDOPIDMJESTOTROSKA", typeof(int), "", MappingType.Element);
                this.columnMTDOPIDMJESTOTROSKA.AllowDBNull = false;
                this.columnMTDOPIDMJESTOTROSKA.Caption = "Šifra MT";
                this.columnMTDOPIDMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("SuperType", "IDMJESTOTROSKA");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("SubtypeGroup", "MTDOP");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Description", "Šifra MT");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Length", "8");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "MTDOPIDMJESTOTROSKA");
                this.Columns.Add(this.columnMTDOPIDMJESTOTROSKA);
                this.columnSTRANEDOPIDSTRANEKNJIZENJA = new DataColumn("STRANEDOPIDSTRANEKNJIZENJA", typeof(int), "", MappingType.Element);
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.AllowDBNull = false;
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.Caption = "Šifra strane";
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("SuperType", "IDSTRANEKNJIZENJA");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("SubtypeGroup", "STRANEDOP");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Description", "Šifra strane");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Length", "5");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.InternalName", "STRANEDOPIDSTRANEKNJIZENJA");
                this.Columns.Add(this.columnSTRANEDOPIDSTRANEKNJIZENJA);
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS = new DataColumn("SHEMADDDOPRINOSNAZIVDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.AllowDBNull = true;
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.Caption = "Naziv doprinosa";
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.MaxLength = 50;
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("SuperType", "NAZIVDOPRINOS");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("SubtypeGroup", "SHEMADDDOPRINOS");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("Description", "Naziv doprinosa");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("Length", "50");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "SHEMADDDOPRINOSNAZIVDOPRINOS");
                this.Columns.Add(this.columnSHEMADDDOPRINOSNAZIVDOPRINOS);
                this.PrimaryKey = new DataColumn[] { this.columnIDSHEMADD, this.columnSHEMADDDOPRINOSIDDOPRINOS, this.columnKONTODOPIDKONTO };
                this.ExtendedProperties.Add("ParentLvl", "SHEMADD");
                this.ExtendedProperties.Add("LevelName", "SHEMADDDOPRINOS");
                this.ExtendedProperties.Add("Description", "Doprinosi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDSHEMADD = this.Columns["IDSHEMADD"];
                this.columnSHEMADDDOPRINOSIDDOPRINOS = this.Columns["SHEMADDDOPRINOSIDDOPRINOS"];
                this.columnKONTODOPIDKONTO = this.Columns["KONTODOPIDKONTO"];
                this.columnMTDOPIDMJESTOTROSKA = this.Columns["MTDOPIDMJESTOTROSKA"];
                this.columnSTRANEDOPIDSTRANEKNJIZENJA = this.Columns["STRANEDOPIDSTRANEKNJIZENJA"];
                this.columnSHEMADDDOPRINOSNAZIVDOPRINOS = this.Columns["SHEMADDDOPRINOSNAZIVDOPRINOS"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow(builder);
            }

            public SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow NewSHEMADDSHEMADDDOPRINOSRow()
            {
                return (SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SHEMADDSHEMADDDOPRINOSRowChanged != null)
                {
                    SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRowChangeEventHandler sHEMADDSHEMADDDOPRINOSRowChangedEvent = this.SHEMADDSHEMADDDOPRINOSRowChanged;
                    if (sHEMADDSHEMADDDOPRINOSRowChangedEvent != null)
                    {
                        sHEMADDSHEMADDDOPRINOSRowChangedEvent(this, new SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRowChangeEvent((SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SHEMADDSHEMADDDOPRINOSRowChanging != null)
                {
                    SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRowChangeEventHandler sHEMADDSHEMADDDOPRINOSRowChangingEvent = this.SHEMADDSHEMADDDOPRINOSRowChanging;
                    if (sHEMADDSHEMADDDOPRINOSRowChangingEvent != null)
                    {
                        sHEMADDSHEMADDDOPRINOSRowChangingEvent(this, new SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRowChangeEvent((SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("SHEMADD_SHEMADDSHEMADDDOPRINOS", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.SHEMADDSHEMADDDOPRINOSRowDeleted != null)
                {
                    SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRowChangeEventHandler sHEMADDSHEMADDDOPRINOSRowDeletedEvent = this.SHEMADDSHEMADDDOPRINOSRowDeleted;
                    if (sHEMADDSHEMADDDOPRINOSRowDeletedEvent != null)
                    {
                        sHEMADDSHEMADDDOPRINOSRowDeletedEvent(this, new SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRowChangeEvent((SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SHEMADDSHEMADDDOPRINOSRowDeleting != null)
                {
                    SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRowChangeEventHandler sHEMADDSHEMADDDOPRINOSRowDeletingEvent = this.SHEMADDSHEMADDDOPRINOSRowDeleting;
                    if (sHEMADDSHEMADDDOPRINOSRowDeletingEvent != null)
                    {
                        sHEMADDSHEMADDDOPRINOSRowDeletingEvent(this, new SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRowChangeEvent((SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSHEMADDSHEMADDDOPRINOSRow(SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow row)
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

            public DataColumn IDSHEMADDColumn
            {
                get
                {
                    return this.columnIDSHEMADD;
                }
            }

            public SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow this[int index]
            {
                get
                {
                    return (SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow) this.Rows[index];
                }
            }

            public DataColumn KONTODOPIDKONTOColumn
            {
                get
                {
                    return this.columnKONTODOPIDKONTO;
                }
            }

            public DataColumn MTDOPIDMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnMTDOPIDMJESTOTROSKA;
                }
            }

            public DataColumn SHEMADDDOPRINOSIDDOPRINOSColumn
            {
                get
                {
                    return this.columnSHEMADDDOPRINOSIDDOPRINOS;
                }
            }

            public DataColumn SHEMADDDOPRINOSNAZIVDOPRINOSColumn
            {
                get
                {
                    return this.columnSHEMADDDOPRINOSNAZIVDOPRINOS;
                }
            }

            public DataColumn STRANEDOPIDSTRANEKNJIZENJAColumn
            {
                get
                {
                    return this.columnSTRANEDOPIDSTRANEKNJIZENJA;
                }
            }
        }

        public class SHEMADDSHEMADDDOPRINOSRow : DataRow
        {
            private SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSDataTable tableSHEMADDSHEMADDDOPRINOS;

            internal SHEMADDSHEMADDDOPRINOSRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSHEMADDSHEMADDDOPRINOS = (SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSDataTable) this.Table;
            }

            public SHEMADDDataSet.SHEMADDRow GetSHEMADDRow()
            {
                return (SHEMADDDataSet.SHEMADDRow) this.GetParentRow("SHEMADD_SHEMADDSHEMADDDOPRINOS");
            }

            public bool IsIDSHEMADDNull()
            {
                return this.IsNull(this.tableSHEMADDSHEMADDDOPRINOS.IDSHEMADDColumn);
            }

            public bool IsKONTODOPIDKONTONull()
            {
                return this.IsNull(this.tableSHEMADDSHEMADDDOPRINOS.KONTODOPIDKONTOColumn);
            }

            public bool IsMTDOPIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableSHEMADDSHEMADDDOPRINOS.MTDOPIDMJESTOTROSKAColumn);
            }

            public bool IsSHEMADDDOPRINOSIDDOPRINOSNull()
            {
                return this.IsNull(this.tableSHEMADDSHEMADDDOPRINOS.SHEMADDDOPRINOSIDDOPRINOSColumn);
            }

            public bool IsSHEMADDDOPRINOSNAZIVDOPRINOSNull()
            {
                return this.IsNull(this.tableSHEMADDSHEMADDDOPRINOS.SHEMADDDOPRINOSNAZIVDOPRINOSColumn);
            }

            public bool IsSTRANEDOPIDSTRANEKNJIZENJANull()
            {
                return this.IsNull(this.tableSHEMADDSHEMADDDOPRINOS.STRANEDOPIDSTRANEKNJIZENJAColumn);
            }

            public void SetMTDOPIDMJESTOTROSKANull()
            {
                this[this.tableSHEMADDSHEMADDDOPRINOS.MTDOPIDMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSHEMADDDOPRINOSNAZIVDOPRINOSNull()
            {
                this[this.tableSHEMADDSHEMADDDOPRINOS.SHEMADDDOPRINOSNAZIVDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTRANEDOPIDSTRANEKNJIZENJANull()
            {
                this[this.tableSHEMADDSHEMADDDOPRINOS.STRANEDOPIDSTRANEKNJIZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSHEMADD
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMADDSHEMADDDOPRINOS.IDSHEMADDColumn]);
                }
                set
                {
                    this[this.tableSHEMADDSHEMADDDOPRINOS.IDSHEMADDColumn] = value;
                }
            }

            public string KONTODOPIDKONTO
            {
                get
                {
                    return Conversions.ToString(this[this.tableSHEMADDSHEMADDDOPRINOS.KONTODOPIDKONTOColumn]);
                }
                set
                {
                    this[this.tableSHEMADDSHEMADDDOPRINOS.KONTODOPIDKONTOColumn] = value;
                }
            }

            public int MTDOPIDMJESTOTROSKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMADDSHEMADDDOPRINOS.MTDOPIDMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value MTDOPIDMJESTOTROSKA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMADDSHEMADDDOPRINOS.MTDOPIDMJESTOTROSKAColumn] = value;
                }
            }

            public int SHEMADDDOPRINOSIDDOPRINOS
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMADDSHEMADDDOPRINOS.SHEMADDDOPRINOSIDDOPRINOSColumn]);
                }
                set
                {
                    this[this.tableSHEMADDSHEMADDDOPRINOS.SHEMADDDOPRINOSIDDOPRINOSColumn] = value;
                }
            }

            public string SHEMADDDOPRINOSNAZIVDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSHEMADDSHEMADDDOPRINOS.SHEMADDDOPRINOSNAZIVDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSHEMADDSHEMADDDOPRINOS.SHEMADDDOPRINOSNAZIVDOPRINOSColumn] = value;
                }
            }

            public int STRANEDOPIDSTRANEKNJIZENJA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMADDSHEMADDDOPRINOS.STRANEDOPIDSTRANEKNJIZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMADDSHEMADDDOPRINOS.STRANEDOPIDSTRANEKNJIZENJAColumn] = value;
                }
            }
        }

        public class SHEMADDSHEMADDDOPRINOSRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow eventRow;

            public SHEMADDSHEMADDDOPRINOSRowChangeEvent(SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow row, DataRowAction action)
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

            public SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SHEMADDSHEMADDDOPRINOSRowChangeEventHandler(object sender, SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRowChangeEvent e);

        [Serializable]
        public class SHEMADDSHEMADDSTANDARDDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDDDVRSTEIZNOSA;
            private DataColumn columnIDSHEMADD;
            private DataColumn columnKONTODDVRSTAIZNOSAIDKONTO;
            private DataColumn columnMTDDVRSTAIZNOSAIDMJESTOTROSKA;
            private DataColumn columnNAZIVDDVRSTEIZNOSA;
            private DataColumn columnSHEMADDSTANDARDID;
            private DataColumn columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA;

            public event SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRowChangeEventHandler SHEMADDSHEMADDSTANDARDRowChanged;

            public event SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRowChangeEventHandler SHEMADDSHEMADDSTANDARDRowChanging;

            public event SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRowChangeEventHandler SHEMADDSHEMADDSTANDARDRowDeleted;

            public event SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRowChangeEventHandler SHEMADDSHEMADDSTANDARDRowDeleting;

            public SHEMADDSHEMADDSTANDARDDataTable()
            {
                this.TableName = "SHEMADDSHEMADDSTANDARD";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SHEMADDSHEMADDSTANDARDDataTable(DataTable table) : base(table.TableName)
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

            protected SHEMADDSHEMADDSTANDARDDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSHEMADDSHEMADDSTANDARDRow(SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow row)
            {
                this.Rows.Add(row);
            }

            public SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow AddSHEMADDSHEMADDSTANDARDRow(int iDSHEMADD, int iDDDVRSTEIZNOSA, string kONTODDVRSTAIZNOSAIDKONTO, int mTDDVRSTAIZNOSAIDMJESTOTROSKA, int sTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA)
            {
                SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow row = (SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow) this.NewRow();
                row["IDSHEMADD"] = iDSHEMADD;
                row["IDDDVRSTEIZNOSA"] = iDDDVRSTEIZNOSA;
                row["KONTODDVRSTAIZNOSAIDKONTO"] = kONTODDVRSTAIZNOSAIDKONTO;
                row["MTDDVRSTAIZNOSAIDMJESTOTROSKA"] = mTDDVRSTAIZNOSAIDMJESTOTROSKA;
                row["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"] = sTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SHEMADDDataSet.SHEMADDSHEMADDSTANDARDDataTable table = (SHEMADDDataSet.SHEMADDSHEMADDSTANDARDDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow FindByIDSHEMADDSHEMADDSTANDARDID(int iDSHEMADD, Guid sHEMADDSTANDARDID)
            {
                return (SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow) this.Rows.Find(new object[] { iDSHEMADD, sHEMADDSTANDARDID });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SHEMADDDataSet set = new SHEMADDDataSet();
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
                this.columnIDSHEMADD = new DataColumn("IDSHEMADD", typeof(int), "", MappingType.Element);
                this.columnIDSHEMADD.AllowDBNull = false;
                this.columnIDSHEMADD.Caption = "IDSHEMADD";
                this.columnIDSHEMADD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSHEMADD.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSHEMADD.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDSHEMADD.ExtendedProperties.Add("Length", "5");
                this.columnIDSHEMADD.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSHEMADD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSHEMADD.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSHEMADD.ExtendedProperties.Add("Deklarit.InternalName", "IDSHEMADD");
                this.Columns.Add(this.columnIDSHEMADD);
                this.columnSHEMADDSTANDARDID = new DataColumn("SHEMADDSTANDARDID", typeof(Guid), "", MappingType.Element);
                this.columnSHEMADDSTANDARDID.AllowDBNull = false;
                this.columnSHEMADDSTANDARDID.Caption = "SHEMADDSTANDARD";
                this.columnSHEMADDSTANDARDID.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("AutoGenerated", "true");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("IsKey", "true");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("DeklaritType", "guid");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("Description", "SHEMADDSTANDARD");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("Length", "32");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMADDSTANDARDID.ExtendedProperties.Add("Deklarit.InternalName", "SHEMADDSTANDARDID");
                this.Columns.Add(this.columnSHEMADDSTANDARDID);
                this.columnIDDDVRSTEIZNOSA = new DataColumn("IDDDVRSTEIZNOSA", typeof(int), "", MappingType.Element);
                this.columnIDDDVRSTEIZNOSA.AllowDBNull = false;
                this.columnIDDDVRSTEIZNOSA.Caption = "IDDDVRSTEIZNOSA";
                this.columnIDDDVRSTEIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Description", "Šifra iznosa");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Length", "5");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "IDDDVRSTEIZNOSA");
                this.Columns.Add(this.columnIDDDVRSTEIZNOSA);
                this.columnKONTODDVRSTAIZNOSAIDKONTO = new DataColumn("KONTODDVRSTAIZNOSAIDKONTO", typeof(string), "", MappingType.Element);
                this.columnKONTODDVRSTAIZNOSAIDKONTO.AllowDBNull = false;
                this.columnKONTODDVRSTAIZNOSAIDKONTO.Caption = "Konto";
                this.columnKONTODDVRSTAIZNOSAIDKONTO.MaxLength = 14;
                this.columnKONTODDVRSTAIZNOSAIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("SubtypeGroup", "KONTODDVRSTAIZNOSA");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKONTODDVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "KONTODDVRSTAIZNOSAIDKONTO");
                this.Columns.Add(this.columnKONTODDVRSTAIZNOSAIDKONTO);
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA = new DataColumn("MTDDVRSTAIZNOSAIDMJESTOTROSKA", typeof(int), "", MappingType.Element);
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.AllowDBNull = false;
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.Caption = "Šifra MT";
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("SuperType", "IDMJESTOTROSKA");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("SubtypeGroup", "MTDDVRSTAIZNOSA");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Description", "Šifra MT");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Length", "8");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "MTDDVRSTAIZNOSAIDMJESTOTROSKA");
                this.Columns.Add(this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA);
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA = new DataColumn("STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA", typeof(int), "", MappingType.Element);
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.AllowDBNull = false;
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Caption = "Šifra strane";
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("SuperType", "IDSTRANEKNJIZENJA");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("SubtypeGroup", "STRANEDDVRSTEIZNOSA");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Description", "Šifra strane");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Length", "5");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.InternalName", "STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA");
                this.Columns.Add(this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA);
                this.columnNAZIVDDVRSTEIZNOSA = new DataColumn("NAZIVDDVRSTEIZNOSA", typeof(string), "", MappingType.Element);
                this.columnNAZIVDDVRSTEIZNOSA.AllowDBNull = true;
                this.columnNAZIVDDVRSTEIZNOSA.Caption = "NAZIVDDVRSTEIZNOSA";
                this.columnNAZIVDDVRSTEIZNOSA.MaxLength = 50;
                this.columnNAZIVDDVRSTEIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Description", "Vrsta iznosa");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVDDVRSTEIZNOSA");
                this.Columns.Add(this.columnNAZIVDDVRSTEIZNOSA);
                this.PrimaryKey = new DataColumn[] { this.columnIDSHEMADD, this.columnSHEMADDSTANDARDID };
                this.ExtendedProperties.Add("ParentLvl", "SHEMADD");
                this.ExtendedProperties.Add("LevelName", "SHEMADDSTANDARD");
                this.ExtendedProperties.Add("Description", "SHEMADDSTANDARD");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDSHEMADD = this.Columns["IDSHEMADD"];
                this.columnSHEMADDSTANDARDID = this.Columns["SHEMADDSTANDARDID"];
                this.columnIDDDVRSTEIZNOSA = this.Columns["IDDDVRSTEIZNOSA"];
                this.columnKONTODDVRSTAIZNOSAIDKONTO = this.Columns["KONTODDVRSTAIZNOSAIDKONTO"];
                this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA = this.Columns["MTDDVRSTAIZNOSAIDMJESTOTROSKA"];
                this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA = this.Columns["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"];
                this.columnNAZIVDDVRSTEIZNOSA = this.Columns["NAZIVDDVRSTEIZNOSA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow(builder);
            }

            public SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow NewSHEMADDSHEMADDSTANDARDRow()
            {
                return (SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SHEMADDSHEMADDSTANDARDRowChanged != null)
                {
                    SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRowChangeEventHandler sHEMADDSHEMADDSTANDARDRowChangedEvent = this.SHEMADDSHEMADDSTANDARDRowChanged;
                    if (sHEMADDSHEMADDSTANDARDRowChangedEvent != null)
                    {
                        sHEMADDSHEMADDSTANDARDRowChangedEvent(this, new SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRowChangeEvent((SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SHEMADDSHEMADDSTANDARDRowChanging != null)
                {
                    SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRowChangeEventHandler sHEMADDSHEMADDSTANDARDRowChangingEvent = this.SHEMADDSHEMADDSTANDARDRowChanging;
                    if (sHEMADDSHEMADDSTANDARDRowChangingEvent != null)
                    {
                        sHEMADDSHEMADDSTANDARDRowChangingEvent(this, new SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRowChangeEvent((SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("SHEMADD_SHEMADDSHEMADDSTANDARD", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.SHEMADDSHEMADDSTANDARDRowDeleted != null)
                {
                    SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRowChangeEventHandler sHEMADDSHEMADDSTANDARDRowDeletedEvent = this.SHEMADDSHEMADDSTANDARDRowDeleted;
                    if (sHEMADDSHEMADDSTANDARDRowDeletedEvent != null)
                    {
                        sHEMADDSHEMADDSTANDARDRowDeletedEvent(this, new SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRowChangeEvent((SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SHEMADDSHEMADDSTANDARDRowDeleting != null)
                {
                    SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRowChangeEventHandler sHEMADDSHEMADDSTANDARDRowDeletingEvent = this.SHEMADDSHEMADDSTANDARDRowDeleting;
                    if (sHEMADDSHEMADDSTANDARDRowDeletingEvent != null)
                    {
                        sHEMADDSHEMADDSTANDARDRowDeletingEvent(this, new SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRowChangeEvent((SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSHEMADDSHEMADDSTANDARDRow(SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow row)
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

            public DataColumn IDDDVRSTEIZNOSAColumn
            {
                get
                {
                    return this.columnIDDDVRSTEIZNOSA;
                }
            }

            public DataColumn IDSHEMADDColumn
            {
                get
                {
                    return this.columnIDSHEMADD;
                }
            }

            public SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow this[int index]
            {
                get
                {
                    return (SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow) this.Rows[index];
                }
            }

            public DataColumn KONTODDVRSTAIZNOSAIDKONTOColumn
            {
                get
                {
                    return this.columnKONTODDVRSTAIZNOSAIDKONTO;
                }
            }

            public DataColumn MTDDVRSTAIZNOSAIDMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnMTDDVRSTAIZNOSAIDMJESTOTROSKA;
                }
            }

            public DataColumn NAZIVDDVRSTEIZNOSAColumn
            {
                get
                {
                    return this.columnNAZIVDDVRSTEIZNOSA;
                }
            }

            public DataColumn SHEMADDSTANDARDIDColumn
            {
                get
                {
                    return this.columnSHEMADDSTANDARDID;
                }
            }

            public DataColumn STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJAColumn
            {
                get
                {
                    return this.columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA;
                }
            }
        }

        public class SHEMADDSHEMADDSTANDARDRow : DataRow
        {
            private SHEMADDDataSet.SHEMADDSHEMADDSTANDARDDataTable tableSHEMADDSHEMADDSTANDARD;

            internal SHEMADDSHEMADDSTANDARDRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSHEMADDSHEMADDSTANDARD = (SHEMADDDataSet.SHEMADDSHEMADDSTANDARDDataTable) this.Table;
                this.SHEMADDSTANDARDID = Guid.NewGuid();
            }

            public SHEMADDDataSet.SHEMADDRow GetSHEMADDRow()
            {
                return (SHEMADDDataSet.SHEMADDRow) this.GetParentRow("SHEMADD_SHEMADDSHEMADDSTANDARD");
            }

            public bool IsIDDDVRSTEIZNOSANull()
            {
                return this.IsNull(this.tableSHEMADDSHEMADDSTANDARD.IDDDVRSTEIZNOSAColumn);
            }

            public bool IsIDSHEMADDNull()
            {
                return this.IsNull(this.tableSHEMADDSHEMADDSTANDARD.IDSHEMADDColumn);
            }

            public bool IsKONTODDVRSTAIZNOSAIDKONTONull()
            {
                return this.IsNull(this.tableSHEMADDSHEMADDSTANDARD.KONTODDVRSTAIZNOSAIDKONTOColumn);
            }

            public bool IsMTDDVRSTAIZNOSAIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableSHEMADDSHEMADDSTANDARD.MTDDVRSTAIZNOSAIDMJESTOTROSKAColumn);
            }

            public bool IsNAZIVDDVRSTEIZNOSANull()
            {
                return this.IsNull(this.tableSHEMADDSHEMADDSTANDARD.NAZIVDDVRSTEIZNOSAColumn);
            }

            public bool IsSHEMADDSTANDARDIDNull()
            {
                return this.IsNull(this.tableSHEMADDSHEMADDSTANDARD.SHEMADDSTANDARDIDColumn);
            }

            public bool IsSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJANull()
            {
                return this.IsNull(this.tableSHEMADDSHEMADDSTANDARD.STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJAColumn);
            }

            public void SetIDDDVRSTEIZNOSANull()
            {
                this[this.tableSHEMADDSHEMADDSTANDARD.IDDDVRSTEIZNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKONTODDVRSTAIZNOSAIDKONTONull()
            {
                this[this.tableSHEMADDSHEMADDSTANDARD.KONTODDVRSTAIZNOSAIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMTDDVRSTAIZNOSAIDMJESTOTROSKANull()
            {
                this[this.tableSHEMADDSHEMADDSTANDARD.MTDDVRSTAIZNOSAIDMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVDDVRSTEIZNOSANull()
            {
                this[this.tableSHEMADDSHEMADDSTANDARD.NAZIVDDVRSTEIZNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJANull()
            {
                this[this.tableSHEMADDSHEMADDSTANDARD.STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDDDVRSTEIZNOSA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMADDSHEMADDSTANDARD.IDDDVRSTEIZNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMADDSHEMADDSTANDARD.IDDDVRSTEIZNOSAColumn] = value;
                }
            }

            public int IDSHEMADD
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMADDSHEMADDSTANDARD.IDSHEMADDColumn]);
                }
                set
                {
                    this[this.tableSHEMADDSHEMADDSTANDARD.IDSHEMADDColumn] = value;
                }
            }

            public string KONTODDVRSTAIZNOSAIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSHEMADDSHEMADDSTANDARD.KONTODDVRSTAIZNOSAIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSHEMADDSHEMADDSTANDARD.KONTODDVRSTAIZNOSAIDKONTOColumn] = value;
                }
            }

            public int MTDDVRSTAIZNOSAIDMJESTOTROSKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMADDSHEMADDSTANDARD.MTDDVRSTAIZNOSAIDMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMADDSHEMADDSTANDARD.MTDDVRSTAIZNOSAIDMJESTOTROSKAColumn] = value;
                }
            }

            public string NAZIVDDVRSTEIZNOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSHEMADDSHEMADDSTANDARD.NAZIVDDVRSTEIZNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSHEMADDSHEMADDSTANDARD.NAZIVDDVRSTEIZNOSAColumn] = value;
                }
            }

            public Guid SHEMADDSTANDARDID
            {
                get
                {
                    object obj1 = this[this.tableSHEMADDSHEMADDSTANDARD.SHEMADDSTANDARDIDColumn];
                    if (obj1 == null)
                    {
                        Guid guid2 = new Guid();
                        return guid2;
                    }
                    return (Guid) obj1;
                }
                set
                {
                    this[this.tableSHEMADDSHEMADDSTANDARD.SHEMADDSTANDARDIDColumn] = value;
                }
            }

            public int STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMADDSHEMADDSTANDARD.STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMADDSHEMADDSTANDARD.STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJAColumn] = value;
                }
            }
        }

        public class SHEMADDSHEMADDSTANDARDRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow eventRow;

            public SHEMADDSHEMADDSTANDARDRowChangeEvent(SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow row, DataRowAction action)
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

            public SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SHEMADDSHEMADDSTANDARDRowChangeEventHandler(object sender, SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRowChangeEvent e);
    }
}

