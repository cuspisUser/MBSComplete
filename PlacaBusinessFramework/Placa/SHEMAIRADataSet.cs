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
    public class SHEMAIRADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private SHEMAIRADataTable tableSHEMAIRA;
        private SHEMAIRASHEMAIRAKONTIRANJEDataTable tableSHEMAIRASHEMAIRAKONTIRANJE;

        public SHEMAIRADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected SHEMAIRADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["SHEMAIRASHEMAIRAKONTIRANJE"] != null)
                    {
                        this.Tables.Add(new SHEMAIRASHEMAIRAKONTIRANJEDataTable(dataSet.Tables["SHEMAIRASHEMAIRAKONTIRANJE"]));
                    }
                    if (dataSet.Tables["SHEMAIRA"] != null)
                    {
                        this.Tables.Add(new SHEMAIRADataTable(dataSet.Tables["SHEMAIRA"]));
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
            SHEMAIRADataSet set = (SHEMAIRADataSet) base.Clone();
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
            SHEMAIRADataSet set = new SHEMAIRADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "SHEMAIRADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2114");
            this.ExtendedProperties.Add("DataSetName", "SHEMAIRADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ISHEMAIRADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "SHEMAIRA");
            this.ExtendedProperties.Add("ObjectDescription", "Shema kontiranja IRA");
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
            this.DataSetName = "SHEMAIRADataSet";
            this.Namespace = "http://www.tempuri.org/SHEMAIRA";
            this.tableSHEMAIRASHEMAIRAKONTIRANJE = new SHEMAIRASHEMAIRAKONTIRANJEDataTable();
            this.Tables.Add(this.tableSHEMAIRASHEMAIRAKONTIRANJE);
            this.tableSHEMAIRA = new SHEMAIRADataTable();
            this.Tables.Add(this.tableSHEMAIRA);
            this.Relations.Add("SHEMAIRA_SHEMAIRASHEMAIRAKONTIRANJE", new DataColumn[] { this.Tables["SHEMAIRA"].Columns["IDSHEMAIRA"] }, new DataColumn[] { this.Tables["SHEMAIRASHEMAIRAKONTIRANJE"].Columns["IDSHEMAIRA"] });
            this.Relations["SHEMAIRA_SHEMAIRASHEMAIRAKONTIRANJE"].Nested = true;
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
            this.tableSHEMAIRASHEMAIRAKONTIRANJE = (SHEMAIRASHEMAIRAKONTIRANJEDataTable) this.Tables["SHEMAIRASHEMAIRAKONTIRANJE"];
            this.tableSHEMAIRA = (SHEMAIRADataTable) this.Tables["SHEMAIRA"];
            if (initTable)
            {
                if (this.tableSHEMAIRASHEMAIRAKONTIRANJE != null)
                {
                    this.tableSHEMAIRASHEMAIRAKONTIRANJE.InitVars();
                }
                if (this.tableSHEMAIRA != null)
                {
                    this.tableSHEMAIRA.InitVars();
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
                if (dataSet.Tables["SHEMAIRASHEMAIRAKONTIRANJE"] != null)
                {
                    this.Tables.Add(new SHEMAIRASHEMAIRAKONTIRANJEDataTable(dataSet.Tables["SHEMAIRASHEMAIRAKONTIRANJE"]));
                }
                if (dataSet.Tables["SHEMAIRA"] != null)
                {
                    this.Tables.Add(new SHEMAIRADataTable(dataSet.Tables["SHEMAIRA"]));
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

        private bool ShouldSerializeSHEMAIRA()
        {
            return false;
        }

        private bool ShouldSerializeSHEMAIRASHEMAIRAKONTIRANJE()
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
        public SHEMAIRADataTable SHEMAIRA
        {
            get
            {
                return this.tableSHEMAIRA;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SHEMAIRASHEMAIRAKONTIRANJEDataTable SHEMAIRASHEMAIRAKONTIRANJE
        {
            get
            {
                return this.tableSHEMAIRASHEMAIRAKONTIRANJE;
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
        public class SHEMAIRADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSHEMAIRA;
            private DataColumn columnNAZIVSHEMAIRA;
            private DataColumn columnSHEMAIRADOKIDDOKUMENT;

            public event SHEMAIRADataSet.SHEMAIRARowChangeEventHandler SHEMAIRARowChanged;

            public event SHEMAIRADataSet.SHEMAIRARowChangeEventHandler SHEMAIRARowChanging;

            public event SHEMAIRADataSet.SHEMAIRARowChangeEventHandler SHEMAIRARowDeleted;

            public event SHEMAIRADataSet.SHEMAIRARowChangeEventHandler SHEMAIRARowDeleting;

            public SHEMAIRADataTable()
            {
                this.TableName = "SHEMAIRA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SHEMAIRADataTable(DataTable table) : base(table.TableName)
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

            protected SHEMAIRADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSHEMAIRARow(SHEMAIRADataSet.SHEMAIRARow row)
            {
                this.Rows.Add(row);
            }

            public SHEMAIRADataSet.SHEMAIRARow AddSHEMAIRARow(int iDSHEMAIRA, string nAZIVSHEMAIRA, int sHEMAIRADOKIDDOKUMENT)
            {
                SHEMAIRADataSet.SHEMAIRARow row = (SHEMAIRADataSet.SHEMAIRARow) this.NewRow();
                row["IDSHEMAIRA"] = iDSHEMAIRA;
                row["NAZIVSHEMAIRA"] = nAZIVSHEMAIRA;
                row["SHEMAIRADOKIDDOKUMENT"] = sHEMAIRADOKIDDOKUMENT;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SHEMAIRADataSet.SHEMAIRADataTable table = (SHEMAIRADataSet.SHEMAIRADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SHEMAIRADataSet.SHEMAIRARow FindByIDSHEMAIRA(int iDSHEMAIRA)
            {
                return (SHEMAIRADataSet.SHEMAIRARow) this.Rows.Find(new object[] { iDSHEMAIRA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SHEMAIRADataSet.SHEMAIRARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SHEMAIRADataSet set = new SHEMAIRADataSet();
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
                this.columnIDSHEMAIRA = new DataColumn("IDSHEMAIRA", typeof(int), "", MappingType.Element);
                this.columnIDSHEMAIRA.AllowDBNull = false;
                this.columnIDSHEMAIRA.Caption = "IDSHEMAIRA";
                this.columnIDSHEMAIRA.Unique = true;
                this.columnIDSHEMAIRA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Length", "5");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.InternalName", "IDSHEMAIRA");
                this.Columns.Add(this.columnIDSHEMAIRA);
                this.columnNAZIVSHEMAIRA = new DataColumn("NAZIVSHEMAIRA", typeof(string), "", MappingType.Element);
                this.columnNAZIVSHEMAIRA.AllowDBNull = false;
                this.columnNAZIVSHEMAIRA.Caption = "NAZIVSHEMAIRA";
                this.columnNAZIVSHEMAIRA.MaxLength = 50;
                this.columnNAZIVSHEMAIRA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("Description", "Naziv");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVSHEMAIRA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVSHEMAIRA");
                this.Columns.Add(this.columnNAZIVSHEMAIRA);
                this.columnSHEMAIRADOKIDDOKUMENT = new DataColumn("SHEMAIRADOKIDDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnSHEMAIRADOKIDDOKUMENT.AllowDBNull = false;
                this.columnSHEMAIRADOKIDDOKUMENT.Caption = "Šifra dokumenta";
                this.columnSHEMAIRADOKIDDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "#######");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "#######");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("SuperType", "IDDOKUMENT");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("SubtypeGroup", "SHEMAIRADOK");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("Description", "Dokument");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("Length", "8");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAIRADOKIDDOKUMENT");
                this.Columns.Add(this.columnSHEMAIRADOKIDDOKUMENT);
                this.PrimaryKey = new DataColumn[] { this.columnIDSHEMAIRA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "SHEMAIRA");
                this.ExtendedProperties.Add("Description", "Shema kontiranja IRA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDSHEMAIRA = this.Columns["IDSHEMAIRA"];
                this.columnNAZIVSHEMAIRA = this.Columns["NAZIVSHEMAIRA"];
                this.columnSHEMAIRADOKIDDOKUMENT = this.Columns["SHEMAIRADOKIDDOKUMENT"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SHEMAIRADataSet.SHEMAIRARow(builder);
            }

            public SHEMAIRADataSet.SHEMAIRARow NewSHEMAIRARow()
            {
                return (SHEMAIRADataSet.SHEMAIRARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SHEMAIRARowChanged != null)
                {
                    SHEMAIRADataSet.SHEMAIRARowChangeEventHandler sHEMAIRARowChangedEvent = this.SHEMAIRARowChanged;
                    if (sHEMAIRARowChangedEvent != null)
                    {
                        sHEMAIRARowChangedEvent(this, new SHEMAIRADataSet.SHEMAIRARowChangeEvent((SHEMAIRADataSet.SHEMAIRARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SHEMAIRARowChanging != null)
                {
                    SHEMAIRADataSet.SHEMAIRARowChangeEventHandler sHEMAIRARowChangingEvent = this.SHEMAIRARowChanging;
                    if (sHEMAIRARowChangingEvent != null)
                    {
                        sHEMAIRARowChangingEvent(this, new SHEMAIRADataSet.SHEMAIRARowChangeEvent((SHEMAIRADataSet.SHEMAIRARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SHEMAIRARowDeleted != null)
                {
                    SHEMAIRADataSet.SHEMAIRARowChangeEventHandler sHEMAIRARowDeletedEvent = this.SHEMAIRARowDeleted;
                    if (sHEMAIRARowDeletedEvent != null)
                    {
                        sHEMAIRARowDeletedEvent(this, new SHEMAIRADataSet.SHEMAIRARowChangeEvent((SHEMAIRADataSet.SHEMAIRARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SHEMAIRARowDeleting != null)
                {
                    SHEMAIRADataSet.SHEMAIRARowChangeEventHandler sHEMAIRARowDeletingEvent = this.SHEMAIRARowDeleting;
                    if (sHEMAIRARowDeletingEvent != null)
                    {
                        sHEMAIRARowDeletingEvent(this, new SHEMAIRADataSet.SHEMAIRARowChangeEvent((SHEMAIRADataSet.SHEMAIRARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSHEMAIRARow(SHEMAIRADataSet.SHEMAIRARow row)
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

            public DataColumn IDSHEMAIRAColumn
            {
                get
                {
                    return this.columnIDSHEMAIRA;
                }
            }

            public SHEMAIRADataSet.SHEMAIRARow this[int index]
            {
                get
                {
                    return (SHEMAIRADataSet.SHEMAIRARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVSHEMAIRAColumn
            {
                get
                {
                    return this.columnNAZIVSHEMAIRA;
                }
            }

            public DataColumn SHEMAIRADOKIDDOKUMENTColumn
            {
                get
                {
                    return this.columnSHEMAIRADOKIDDOKUMENT;
                }
            }
        }

        public class SHEMAIRARow : DataRow
        {
            private SHEMAIRADataSet.SHEMAIRADataTable tableSHEMAIRA;

            internal SHEMAIRARow(DataRowBuilder rb) : base(rb)
            {
                this.tableSHEMAIRA = (SHEMAIRADataSet.SHEMAIRADataTable) this.Table;
            }

            public SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow[] GetSHEMAIRASHEMAIRAKONTIRANJERows()
            {
                return (SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow[]) this.GetChildRows("SHEMAIRA_SHEMAIRASHEMAIRAKONTIRANJE");
            }

            public bool IsIDSHEMAIRANull()
            {
                return this.IsNull(this.tableSHEMAIRA.IDSHEMAIRAColumn);
            }

            public bool IsNAZIVSHEMAIRANull()
            {
                return this.IsNull(this.tableSHEMAIRA.NAZIVSHEMAIRAColumn);
            }

            public bool IsSHEMAIRADOKIDDOKUMENTNull()
            {
                return this.IsNull(this.tableSHEMAIRA.SHEMAIRADOKIDDOKUMENTColumn);
            }

            public void SetNAZIVSHEMAIRANull()
            {
                this[this.tableSHEMAIRA.NAZIVSHEMAIRAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSHEMAIRADOKIDDOKUMENTNull()
            {
                this[this.tableSHEMAIRA.SHEMAIRADOKIDDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSHEMAIRA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAIRA.IDSHEMAIRAColumn]);
                }
                set
                {
                    this[this.tableSHEMAIRA.IDSHEMAIRAColumn] = value;
                }
            }

            public string NAZIVSHEMAIRA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSHEMAIRA.NAZIVSHEMAIRAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVSHEMAIRA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableSHEMAIRA.NAZIVSHEMAIRAColumn] = value;
                }
            }

            public int SHEMAIRADOKIDDOKUMENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAIRA.SHEMAIRADOKIDDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SHEMAIRADOKIDDOKUMENT because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAIRA.SHEMAIRADOKIDDOKUMENTColumn] = value;
                }
            }
        }

        public class SHEMAIRARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SHEMAIRADataSet.SHEMAIRARow eventRow;

            public SHEMAIRARowChangeEvent(SHEMAIRADataSet.SHEMAIRARow row, DataRowAction action)
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

            public SHEMAIRADataSet.SHEMAIRARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SHEMAIRARowChangeEventHandler(object sender, SHEMAIRADataSet.SHEMAIRARowChangeEvent e);

        [Serializable]
        public class SHEMAIRASHEMAIRAKONTIRANJEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDIRAVRSTAIZNOSA;
            private DataColumn columnIDSHEMAIRA;
            private DataColumn columnSHEMAIRAKONTOIDKONTO;
            private DataColumn columnSHEMAIRAMTIDMJESTOTROSKA;
            private DataColumn columnSHEMAIRAOJIDORGJED;
            private DataColumn columnSHEMAIRASTRANEIDSTRANEKNJIZENJA;

            public event SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERowChangeEventHandler SHEMAIRASHEMAIRAKONTIRANJERowChanged;

            public event SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERowChangeEventHandler SHEMAIRASHEMAIRAKONTIRANJERowChanging;

            public event SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERowChangeEventHandler SHEMAIRASHEMAIRAKONTIRANJERowDeleted;

            public event SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERowChangeEventHandler SHEMAIRASHEMAIRAKONTIRANJERowDeleting;

            public SHEMAIRASHEMAIRAKONTIRANJEDataTable()
            {
                this.TableName = "SHEMAIRASHEMAIRAKONTIRANJE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SHEMAIRASHEMAIRAKONTIRANJEDataTable(DataTable table) : base(table.TableName)
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

            protected SHEMAIRASHEMAIRAKONTIRANJEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSHEMAIRASHEMAIRAKONTIRANJERow(SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow row)
            {
                this.Rows.Add(row);
            }

            public SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow AddSHEMAIRASHEMAIRAKONTIRANJERow(int iDSHEMAIRA, string sHEMAIRAKONTOIDKONTO, int sHEMAIRASTRANEIDSTRANEKNJIZENJA, int iDIRAVRSTAIZNOSA, int sHEMAIRAMTIDMJESTOTROSKA, int sHEMAIRAOJIDORGJED)
            {
                SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow row = (SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow) this.NewRow();
                row["IDSHEMAIRA"] = iDSHEMAIRA;
                row["SHEMAIRAKONTOIDKONTO"] = sHEMAIRAKONTOIDKONTO;
                row["SHEMAIRASTRANEIDSTRANEKNJIZENJA"] = sHEMAIRASTRANEIDSTRANEKNJIZENJA;
                row["IDIRAVRSTAIZNOSA"] = iDIRAVRSTAIZNOSA;
                row["SHEMAIRAMTIDMJESTOTROSKA"] = sHEMAIRAMTIDMJESTOTROSKA;
                row["SHEMAIRAOJIDORGJED"] = sHEMAIRAOJIDORGJED;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJEDataTable table = (SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow FindByIDSHEMAIRASHEMAIRAKONTOIDKONTOSHEMAIRASTRANEIDSTRANEKNJIZENJA(int iDSHEMAIRA, string sHEMAIRAKONTOIDKONTO, int sHEMAIRASTRANEIDSTRANEKNJIZENJA)
            {
                return (SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow) this.Rows.Find(new object[] { iDSHEMAIRA, sHEMAIRAKONTOIDKONTO, sHEMAIRASTRANEIDSTRANEKNJIZENJA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SHEMAIRADataSet set = new SHEMAIRADataSet();
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
                this.columnIDSHEMAIRA = new DataColumn("IDSHEMAIRA", typeof(int), "", MappingType.Element);
                this.columnIDSHEMAIRA.AllowDBNull = false;
                this.columnIDSHEMAIRA.Caption = "IDSHEMAIRA";
                this.columnIDSHEMAIRA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Length", "5");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSHEMAIRA.ExtendedProperties.Add("Deklarit.InternalName", "IDSHEMAIRA");
                this.Columns.Add(this.columnIDSHEMAIRA);
                this.columnSHEMAIRAKONTOIDKONTO = new DataColumn("SHEMAIRAKONTOIDKONTO", typeof(string), "", MappingType.Element);
                this.columnSHEMAIRAKONTOIDKONTO.AllowDBNull = false;
                this.columnSHEMAIRAKONTOIDKONTO.Caption = "Konto";
                this.columnSHEMAIRAKONTOIDKONTO.MaxLength = 14;
                this.columnSHEMAIRAKONTOIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("SubtypeGroup", "SHEMAIRAKONTO");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("IsKey", "true");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAIRAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAIRAKONTOIDKONTO");
                this.Columns.Add(this.columnSHEMAIRAKONTOIDKONTO);
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA = new DataColumn("SHEMAIRASTRANEIDSTRANEKNJIZENJA", typeof(int), "", MappingType.Element);
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.AllowDBNull = false;
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.Caption = "IDSTRANEKNJIZENJA";
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("SuperType", "IDSTRANEKNJIZENJA");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("SubtypeGroup", "SHEMAIRASTRANE");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("IsKey", "true");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Description", "Strana knjiženja");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Length", "5");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAIRASTRANEIDSTRANEKNJIZENJA");
                this.Columns.Add(this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA);
                this.columnIDIRAVRSTAIZNOSA = new DataColumn("IDIRAVRSTAIZNOSA", typeof(int), "", MappingType.Element);
                this.columnIDIRAVRSTAIZNOSA.AllowDBNull = false;
                this.columnIDIRAVRSTAIZNOSA.Caption = "IDIRAVRSTAIZNOSA";
                this.columnIDIRAVRSTAIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Description", "Vrsta iznosa");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Length", "5");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "IDIRAVRSTAIZNOSA");
                this.Columns.Add(this.columnIDIRAVRSTAIZNOSA);
                this.columnSHEMAIRAMTIDMJESTOTROSKA = new DataColumn("SHEMAIRAMTIDMJESTOTROSKA", typeof(int), "", MappingType.Element);
                this.columnSHEMAIRAMTIDMJESTOTROSKA.AllowDBNull = false;
                this.columnSHEMAIRAMTIDMJESTOTROSKA.Caption = "Šifra MT";
                this.columnSHEMAIRAMTIDMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("SuperType", "IDMJESTOTROSKA");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("SubtypeGroup", "SHEMAIRAMT");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("Description", "Šifra MT");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("Length", "8");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAIRAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAIRAMTIDMJESTOTROSKA");
                this.Columns.Add(this.columnSHEMAIRAMTIDMJESTOTROSKA);
                this.columnSHEMAIRAOJIDORGJED = new DataColumn("SHEMAIRAOJIDORGJED", typeof(int), "", MappingType.Element);
                this.columnSHEMAIRAOJIDORGJED.AllowDBNull = false;
                this.columnSHEMAIRAOJIDORGJED.Caption = "Šifra OJ";
                this.columnSHEMAIRAOJIDORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("SuperType", "IDORGJED");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("SubtypeGroup", "SHEMAIRAOJ");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("IsKey", "false");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("Description", "Šifra OJ");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("Length", "8");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAIRAOJIDORGJED.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAIRAOJIDORGJED");
                this.Columns.Add(this.columnSHEMAIRAOJIDORGJED);
                this.PrimaryKey = new DataColumn[] { this.columnIDSHEMAIRA, this.columnSHEMAIRAKONTOIDKONTO, this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA, this.columnIDIRAVRSTAIZNOSA };
                this.ExtendedProperties.Add("ParentLvl", "SHEMAIRA");
                this.ExtendedProperties.Add("LevelName", "SHEMAIRAKONTIRANJE");
                this.ExtendedProperties.Add("Description", "SHEMAIRAKONTIRANJE");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDSHEMAIRA = this.Columns["IDSHEMAIRA"];
                this.columnSHEMAIRAKONTOIDKONTO = this.Columns["SHEMAIRAKONTOIDKONTO"];
                this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA = this.Columns["SHEMAIRASTRANEIDSTRANEKNJIZENJA"];
                this.columnIDIRAVRSTAIZNOSA = this.Columns["IDIRAVRSTAIZNOSA"];
                this.columnSHEMAIRAMTIDMJESTOTROSKA = this.Columns["SHEMAIRAMTIDMJESTOTROSKA"];
                this.columnSHEMAIRAOJIDORGJED = this.Columns["SHEMAIRAOJIDORGJED"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow(builder);
            }

            public SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow NewSHEMAIRASHEMAIRAKONTIRANJERow()
            {
                return (SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SHEMAIRASHEMAIRAKONTIRANJERowChanged != null)
                {
                    SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERowChangeEventHandler sHEMAIRASHEMAIRAKONTIRANJERowChangedEvent = this.SHEMAIRASHEMAIRAKONTIRANJERowChanged;
                    if (sHEMAIRASHEMAIRAKONTIRANJERowChangedEvent != null)
                    {
                        sHEMAIRASHEMAIRAKONTIRANJERowChangedEvent(this, new SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERowChangeEvent((SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SHEMAIRASHEMAIRAKONTIRANJERowChanging != null)
                {
                    SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERowChangeEventHandler sHEMAIRASHEMAIRAKONTIRANJERowChangingEvent = this.SHEMAIRASHEMAIRAKONTIRANJERowChanging;
                    if (sHEMAIRASHEMAIRAKONTIRANJERowChangingEvent != null)
                    {
                        sHEMAIRASHEMAIRAKONTIRANJERowChangingEvent(this, new SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERowChangeEvent((SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("SHEMAIRA_SHEMAIRASHEMAIRAKONTIRANJE", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.SHEMAIRASHEMAIRAKONTIRANJERowDeleted != null)
                {
                    SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERowChangeEventHandler sHEMAIRASHEMAIRAKONTIRANJERowDeletedEvent = this.SHEMAIRASHEMAIRAKONTIRANJERowDeleted;
                    if (sHEMAIRASHEMAIRAKONTIRANJERowDeletedEvent != null)
                    {
                        sHEMAIRASHEMAIRAKONTIRANJERowDeletedEvent(this, new SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERowChangeEvent((SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SHEMAIRASHEMAIRAKONTIRANJERowDeleting != null)
                {
                    SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERowChangeEventHandler sHEMAIRASHEMAIRAKONTIRANJERowDeletingEvent = this.SHEMAIRASHEMAIRAKONTIRANJERowDeleting;
                    if (sHEMAIRASHEMAIRAKONTIRANJERowDeletingEvent != null)
                    {
                        sHEMAIRASHEMAIRAKONTIRANJERowDeletingEvent(this, new SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERowChangeEvent((SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSHEMAIRASHEMAIRAKONTIRANJERow(SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow row)
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

            public DataColumn IDIRAVRSTAIZNOSAColumn
            {
                get
                {
                    return this.columnIDIRAVRSTAIZNOSA;
                }
            }

            public DataColumn IDSHEMAIRAColumn
            {
                get
                {
                    return this.columnIDSHEMAIRA;
                }
            }

            public SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow this[int index]
            {
                get
                {
                    return (SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow) this.Rows[index];
                }
            }

            public DataColumn SHEMAIRAKONTOIDKONTOColumn
            {
                get
                {
                    return this.columnSHEMAIRAKONTOIDKONTO;
                }
            }

            public DataColumn SHEMAIRAMTIDMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnSHEMAIRAMTIDMJESTOTROSKA;
                }
            }

            public DataColumn SHEMAIRAOJIDORGJEDColumn
            {
                get
                {
                    return this.columnSHEMAIRAOJIDORGJED;
                }
            }

            public DataColumn SHEMAIRASTRANEIDSTRANEKNJIZENJAColumn
            {
                get
                {
                    return this.columnSHEMAIRASTRANEIDSTRANEKNJIZENJA;
                }
            }
        }

        public class SHEMAIRASHEMAIRAKONTIRANJERow : DataRow
        {
            private SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJEDataTable tableSHEMAIRASHEMAIRAKONTIRANJE;

            internal SHEMAIRASHEMAIRAKONTIRANJERow(DataRowBuilder rb) : base(rb)
            {
                this.tableSHEMAIRASHEMAIRAKONTIRANJE = (SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJEDataTable) this.Table;
            }

            public SHEMAIRADataSet.SHEMAIRARow GetSHEMAIRARow()
            {
                return (SHEMAIRADataSet.SHEMAIRARow) this.GetParentRow("SHEMAIRA_SHEMAIRASHEMAIRAKONTIRANJE");
            }

            public bool IsIDIRAVRSTAIZNOSANull()
            {
                return this.IsNull(this.tableSHEMAIRASHEMAIRAKONTIRANJE.IDIRAVRSTAIZNOSAColumn);
            }

            public bool IsIDSHEMAIRANull()
            {
                return this.IsNull(this.tableSHEMAIRASHEMAIRAKONTIRANJE.IDSHEMAIRAColumn);
            }

            public bool IsSHEMAIRAKONTOIDKONTONull()
            {
                return this.IsNull(this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAKONTOIDKONTOColumn);
            }

            public bool IsSHEMAIRAMTIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAMTIDMJESTOTROSKAColumn);
            }

            public bool IsSHEMAIRAOJIDORGJEDNull()
            {
                return this.IsNull(this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAOJIDORGJEDColumn);
            }

            public bool IsSHEMAIRASTRANEIDSTRANEKNJIZENJANull()
            {
                return this.IsNull(this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRASTRANEIDSTRANEKNJIZENJAColumn);
            }

            public void SetIDIRAVRSTAIZNOSANull()
            {
                this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.IDIRAVRSTAIZNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSHEMAIRAMTIDMJESTOTROSKANull()
            {
                this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAMTIDMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSHEMAIRAOJIDORGJEDNull()
            {
                this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAOJIDORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDIRAVRSTAIZNOSA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.IDIRAVRSTAIZNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.IDIRAVRSTAIZNOSAColumn] = value;
                }
            }

            public int IDSHEMAIRA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.IDSHEMAIRAColumn]);
                }
                set
                {
                    this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.IDSHEMAIRAColumn] = value;
                }
            }

            public string SHEMAIRAKONTOIDKONTO
            {
                get
                {
                    return Conversions.ToString(this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAKONTOIDKONTOColumn]);
                }
                set
                {
                    this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAKONTOIDKONTOColumn] = value;
                }
            }

            public int SHEMAIRAMTIDMJESTOTROSKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAMTIDMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAMTIDMJESTOTROSKAColumn] = value;
                }
            }

            public int SHEMAIRAOJIDORGJED
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAOJIDORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAOJIDORGJEDColumn] = value;
                }
            }

            public int SHEMAIRASTRANEIDSTRANEKNJIZENJA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRASTRANEIDSTRANEKNJIZENJAColumn]);
                }
                set
                {
                    this[this.tableSHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRASTRANEIDSTRANEKNJIZENJAColumn] = value;
                }
            }
        }

        public class SHEMAIRASHEMAIRAKONTIRANJERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow eventRow;

            public SHEMAIRASHEMAIRAKONTIRANJERowChangeEvent(SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow row, DataRowAction action)
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

            public SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SHEMAIRASHEMAIRAKONTIRANJERowChangeEventHandler(object sender, SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERowChangeEvent e);
    }
}

