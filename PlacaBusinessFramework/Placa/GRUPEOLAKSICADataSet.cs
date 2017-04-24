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
    public class GRUPEOLAKSICADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private GRUPEOLAKSICADataTable tableGRUPEOLAKSICA;

        public GRUPEOLAKSICADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected GRUPEOLAKSICADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["GRUPEOLAKSICA"] != null)
                    {
                        this.Tables.Add(new GRUPEOLAKSICADataTable(dataSet.Tables["GRUPEOLAKSICA"]));
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
            GRUPEOLAKSICADataSet set = (GRUPEOLAKSICADataSet) base.Clone();
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
            GRUPEOLAKSICADataSet set = new GRUPEOLAKSICADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "GRUPEOLAKSICADataAdapter");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1006");
            this.ExtendedProperties.Add("DataSetName", "GRUPEOLAKSICADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IGRUPEOLAKSICADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "GRUPEOLAKSICA");
            this.ExtendedProperties.Add("ObjectDescription", "Grupe olakšica");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "HardlyEver");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "GRUPEOLAKSICADataSet";
            this.Namespace = "http://www.tempuri.org/GRUPEOLAKSICA";
            this.tableGRUPEOLAKSICA = new GRUPEOLAKSICADataTable();
            this.Tables.Add(this.tableGRUPEOLAKSICA);
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
            this.tableGRUPEOLAKSICA = (GRUPEOLAKSICADataTable) this.Tables["GRUPEOLAKSICA"];
            if (initTable && (this.tableGRUPEOLAKSICA != null))
            {
                this.tableGRUPEOLAKSICA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["GRUPEOLAKSICA"] != null)
                {
                    this.Tables.Add(new GRUPEOLAKSICADataTable(dataSet.Tables["GRUPEOLAKSICA"]));
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

        private bool ShouldSerializeGRUPEOLAKSICA()
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
        public GRUPEOLAKSICADataTable GRUPEOLAKSICA
        {
            get
            {
                return this.tableGRUPEOLAKSICA;
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
        public class GRUPEOLAKSICADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDGRUPEOLAKSICA;
            private DataColumn columnMAXIMALNIIZNOSGRUPE;
            private DataColumn columnNAZIVGRUPEOLAKSICA;

            public event GRUPEOLAKSICADataSet.GRUPEOLAKSICARowChangeEventHandler GRUPEOLAKSICARowChanged;

            public event GRUPEOLAKSICADataSet.GRUPEOLAKSICARowChangeEventHandler GRUPEOLAKSICARowChanging;

            public event GRUPEOLAKSICADataSet.GRUPEOLAKSICARowChangeEventHandler GRUPEOLAKSICARowDeleted;

            public event GRUPEOLAKSICADataSet.GRUPEOLAKSICARowChangeEventHandler GRUPEOLAKSICARowDeleting;

            public GRUPEOLAKSICADataTable()
            {
                this.TableName = "GRUPEOLAKSICA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal GRUPEOLAKSICADataTable(DataTable table) : base(table.TableName)
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

            protected GRUPEOLAKSICADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddGRUPEOLAKSICARow(GRUPEOLAKSICADataSet.GRUPEOLAKSICARow row)
            {
                this.Rows.Add(row);
            }

            public GRUPEOLAKSICADataSet.GRUPEOLAKSICARow AddGRUPEOLAKSICARow(int iDGRUPEOLAKSICA, string nAZIVGRUPEOLAKSICA, decimal mAXIMALNIIZNOSGRUPE)
            {
                GRUPEOLAKSICADataSet.GRUPEOLAKSICARow row = (GRUPEOLAKSICADataSet.GRUPEOLAKSICARow) this.NewRow();
                row["IDGRUPEOLAKSICA"] = iDGRUPEOLAKSICA;
                row["NAZIVGRUPEOLAKSICA"] = nAZIVGRUPEOLAKSICA;
                row["MAXIMALNIIZNOSGRUPE"] = mAXIMALNIIZNOSGRUPE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                GRUPEOLAKSICADataSet.GRUPEOLAKSICADataTable table = (GRUPEOLAKSICADataSet.GRUPEOLAKSICADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public GRUPEOLAKSICADataSet.GRUPEOLAKSICARow FindByIDGRUPEOLAKSICA(int iDGRUPEOLAKSICA)
            {
                return (GRUPEOLAKSICADataSet.GRUPEOLAKSICARow) this.Rows.Find(new object[] { iDGRUPEOLAKSICA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(GRUPEOLAKSICADataSet.GRUPEOLAKSICARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                GRUPEOLAKSICADataSet set = new GRUPEOLAKSICADataSet();
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
                this.columnIDGRUPEOLAKSICA = new DataColumn("IDGRUPEOLAKSICA", typeof(int), "", MappingType.Element);
                this.columnIDGRUPEOLAKSICA.AllowDBNull = false;
                this.columnIDGRUPEOLAKSICA.Caption = "Šifra grupe olakšica";
                this.columnIDGRUPEOLAKSICA.Unique = true;
                this.columnIDGRUPEOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Description", "Šifra grupe olakšica");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Length", "5");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "IDGRUPEOLAKSICA");
                this.Columns.Add(this.columnIDGRUPEOLAKSICA);
                this.columnNAZIVGRUPEOLAKSICA = new DataColumn("NAZIVGRUPEOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnNAZIVGRUPEOLAKSICA.AllowDBNull = false;
                this.columnNAZIVGRUPEOLAKSICA.Caption = "Naziv grupe olakšice";
                this.columnNAZIVGRUPEOLAKSICA.MaxLength = 100;
                this.columnNAZIVGRUPEOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Description", "Naziv grupe olakšice");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVGRUPEOLAKSICA");
                this.Columns.Add(this.columnNAZIVGRUPEOLAKSICA);
                this.columnMAXIMALNIIZNOSGRUPE = new DataColumn("MAXIMALNIIZNOSGRUPE", typeof(decimal), "", MappingType.Element);
                this.columnMAXIMALNIIZNOSGRUPE.AllowDBNull = false;
                this.columnMAXIMALNIIZNOSGRUPE.Caption = "Maks. iznos olakšica u grupi";
                this.columnMAXIMALNIIZNOSGRUPE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("IsKey", "false");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Description", "Maks. iznos olakšica u grupi");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Length", "12");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Decimals", "2");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("IsInReader", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.InternalName", "MAXIMALNIIZNOSGRUPE");
                this.Columns.Add(this.columnMAXIMALNIIZNOSGRUPE);
                this.PrimaryKey = new DataColumn[] { this.columnIDGRUPEOLAKSICA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "GRUPEOLAKSICA");
                this.ExtendedProperties.Add("Description", "Grupe olakšica");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDGRUPEOLAKSICA = this.Columns["IDGRUPEOLAKSICA"];
                this.columnNAZIVGRUPEOLAKSICA = this.Columns["NAZIVGRUPEOLAKSICA"];
                this.columnMAXIMALNIIZNOSGRUPE = this.Columns["MAXIMALNIIZNOSGRUPE"];
            }

            public GRUPEOLAKSICADataSet.GRUPEOLAKSICARow NewGRUPEOLAKSICARow()
            {
                return (GRUPEOLAKSICADataSet.GRUPEOLAKSICARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new GRUPEOLAKSICADataSet.GRUPEOLAKSICARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.GRUPEOLAKSICARowChanged != null)
                {
                    GRUPEOLAKSICADataSet.GRUPEOLAKSICARowChangeEventHandler gRUPEOLAKSICARowChangedEvent = this.GRUPEOLAKSICARowChanged;
                    if (gRUPEOLAKSICARowChangedEvent != null)
                    {
                        gRUPEOLAKSICARowChangedEvent(this, new GRUPEOLAKSICADataSet.GRUPEOLAKSICARowChangeEvent((GRUPEOLAKSICADataSet.GRUPEOLAKSICARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.GRUPEOLAKSICARowChanging != null)
                {
                    GRUPEOLAKSICADataSet.GRUPEOLAKSICARowChangeEventHandler gRUPEOLAKSICARowChangingEvent = this.GRUPEOLAKSICARowChanging;
                    if (gRUPEOLAKSICARowChangingEvent != null)
                    {
                        gRUPEOLAKSICARowChangingEvent(this, new GRUPEOLAKSICADataSet.GRUPEOLAKSICARowChangeEvent((GRUPEOLAKSICADataSet.GRUPEOLAKSICARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.GRUPEOLAKSICARowDeleted != null)
                {
                    GRUPEOLAKSICADataSet.GRUPEOLAKSICARowChangeEventHandler gRUPEOLAKSICARowDeletedEvent = this.GRUPEOLAKSICARowDeleted;
                    if (gRUPEOLAKSICARowDeletedEvent != null)
                    {
                        gRUPEOLAKSICARowDeletedEvent(this, new GRUPEOLAKSICADataSet.GRUPEOLAKSICARowChangeEvent((GRUPEOLAKSICADataSet.GRUPEOLAKSICARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.GRUPEOLAKSICARowDeleting != null)
                {
                    GRUPEOLAKSICADataSet.GRUPEOLAKSICARowChangeEventHandler gRUPEOLAKSICARowDeletingEvent = this.GRUPEOLAKSICARowDeleting;
                    if (gRUPEOLAKSICARowDeletingEvent != null)
                    {
                        gRUPEOLAKSICARowDeletingEvent(this, new GRUPEOLAKSICADataSet.GRUPEOLAKSICARowChangeEvent((GRUPEOLAKSICADataSet.GRUPEOLAKSICARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveGRUPEOLAKSICARow(GRUPEOLAKSICADataSet.GRUPEOLAKSICARow row)
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

            public DataColumn IDGRUPEOLAKSICAColumn
            {
                get
                {
                    return this.columnIDGRUPEOLAKSICA;
                }
            }

            public GRUPEOLAKSICADataSet.GRUPEOLAKSICARow this[int index]
            {
                get
                {
                    return (GRUPEOLAKSICADataSet.GRUPEOLAKSICARow) this.Rows[index];
                }
            }

            public DataColumn MAXIMALNIIZNOSGRUPEColumn
            {
                get
                {
                    return this.columnMAXIMALNIIZNOSGRUPE;
                }
            }

            public DataColumn NAZIVGRUPEOLAKSICAColumn
            {
                get
                {
                    return this.columnNAZIVGRUPEOLAKSICA;
                }
            }
        }

        public class GRUPEOLAKSICARow : DataRow
        {
            private GRUPEOLAKSICADataSet.GRUPEOLAKSICADataTable tableGRUPEOLAKSICA;

            internal GRUPEOLAKSICARow(DataRowBuilder rb) : base(rb)
            {
                this.tableGRUPEOLAKSICA = (GRUPEOLAKSICADataSet.GRUPEOLAKSICADataTable) this.Table;
            }

            public bool IsIDGRUPEOLAKSICANull()
            {
                return this.IsNull(this.tableGRUPEOLAKSICA.IDGRUPEOLAKSICAColumn);
            }

            public bool IsMAXIMALNIIZNOSGRUPENull()
            {
                return this.IsNull(this.tableGRUPEOLAKSICA.MAXIMALNIIZNOSGRUPEColumn);
            }

            public bool IsNAZIVGRUPEOLAKSICANull()
            {
                return this.IsNull(this.tableGRUPEOLAKSICA.NAZIVGRUPEOLAKSICAColumn);
            }

            public void SetMAXIMALNIIZNOSGRUPENull()
            {
                this[this.tableGRUPEOLAKSICA.MAXIMALNIIZNOSGRUPEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVGRUPEOLAKSICANull()
            {
                this[this.tableGRUPEOLAKSICA.NAZIVGRUPEOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDGRUPEOLAKSICA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableGRUPEOLAKSICA.IDGRUPEOLAKSICAColumn]);
                }
                set
                {
                    this[this.tableGRUPEOLAKSICA.IDGRUPEOLAKSICAColumn] = value;
                }
            }

            public decimal MAXIMALNIIZNOSGRUPE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableGRUPEOLAKSICA.MAXIMALNIIZNOSGRUPEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value MAXIMALNIIZNOSGRUPE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableGRUPEOLAKSICA.MAXIMALNIIZNOSGRUPEColumn] = value;
                }
            }

            public string NAZIVGRUPEOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGRUPEOLAKSICA.NAZIVGRUPEOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVGRUPEOLAKSICA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableGRUPEOLAKSICA.NAZIVGRUPEOLAKSICAColumn] = value;
                }
            }
        }

        public class GRUPEOLAKSICARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private GRUPEOLAKSICADataSet.GRUPEOLAKSICARow eventRow;

            public GRUPEOLAKSICARowChangeEvent(GRUPEOLAKSICADataSet.GRUPEOLAKSICARow row, DataRowAction action)
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

            public GRUPEOLAKSICADataSet.GRUPEOLAKSICARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void GRUPEOLAKSICARowChangeEventHandler(object sender, GRUPEOLAKSICADataSet.GRUPEOLAKSICARowChangeEvent e);
    }
}

