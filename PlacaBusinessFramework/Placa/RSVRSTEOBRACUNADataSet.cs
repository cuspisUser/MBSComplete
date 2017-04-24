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
    public class RSVRSTEOBRACUNADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RSVRSTEOBRACUNADataTable tableRSVRSTEOBRACUNA;

        public RSVRSTEOBRACUNADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RSVRSTEOBRACUNADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RSVRSTEOBRACUNA"] != null)
                    {
                        this.Tables.Add(new RSVRSTEOBRACUNADataTable(dataSet.Tables["RSVRSTEOBRACUNA"]));
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
            RSVRSTEOBRACUNADataSet set = (RSVRSTEOBRACUNADataSet) base.Clone();
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
            RSVRSTEOBRACUNADataSet set = new RSVRSTEOBRACUNADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RSVRSTEOBRACUNADataAdapter");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1019");
            this.ExtendedProperties.Add("DataSetName", "RSVRSTEOBRACUNADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRSVRSTEOBRACUNADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RSVRSTEOBRACUNA");
            this.ExtendedProperties.Add("ObjectDescription", "R-Sm - Vrste obraeuna");
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
            this.DataSetName = "RSVRSTEOBRACUNADataSet";
            this.Namespace = "http://www.tempuri.org/RSVRSTEOBRACUNA";
            this.tableRSVRSTEOBRACUNA = new RSVRSTEOBRACUNADataTable();
            this.Tables.Add(this.tableRSVRSTEOBRACUNA);
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
            this.tableRSVRSTEOBRACUNA = (RSVRSTEOBRACUNADataTable) this.Tables["RSVRSTEOBRACUNA"];
            if (initTable && (this.tableRSVRSTEOBRACUNA != null))
            {
                this.tableRSVRSTEOBRACUNA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RSVRSTEOBRACUNA"] != null)
                {
                    this.Tables.Add(new RSVRSTEOBRACUNADataTable(dataSet.Tables["RSVRSTEOBRACUNA"]));
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

        private bool ShouldSerializeRSVRSTEOBRACUNA()
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
        public RSVRSTEOBRACUNADataTable RSVRSTEOBRACUNA
        {
            get
            {
                return this.tableRSVRSTEOBRACUNA;
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
        public class RSVRSTEOBRACUNADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRSVRSTEOBRACUNA;
            private DataColumn columnNAZIVRSVRSTEOBRACUNA;

            public event RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARowChangeEventHandler RSVRSTEOBRACUNARowChanged;

            public event RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARowChangeEventHandler RSVRSTEOBRACUNARowChanging;

            public event RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARowChangeEventHandler RSVRSTEOBRACUNARowDeleted;

            public event RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARowChangeEventHandler RSVRSTEOBRACUNARowDeleting;

            public RSVRSTEOBRACUNADataTable()
            {
                this.TableName = "RSVRSTEOBRACUNA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RSVRSTEOBRACUNADataTable(DataTable table) : base(table.TableName)
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

            protected RSVRSTEOBRACUNADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRSVRSTEOBRACUNARow(RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow row)
            {
                this.Rows.Add(row);
            }

            public RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow AddRSVRSTEOBRACUNARow(string iDRSVRSTEOBRACUNA, string nAZIVRSVRSTEOBRACUNA)
            {
                RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow row = (RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow) this.NewRow();
                row["IDRSVRSTEOBRACUNA"] = iDRSVRSTEOBRACUNA;
                row["NAZIVRSVRSTEOBRACUNA"] = nAZIVRSVRSTEOBRACUNA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNADataTable table = (RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow FindByIDRSVRSTEOBRACUNA(string iDRSVRSTEOBRACUNA)
            {
                return (RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow) this.Rows.Find(new object[] { iDRSVRSTEOBRACUNA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RSVRSTEOBRACUNADataSet set = new RSVRSTEOBRACUNADataSet();
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
                this.columnIDRSVRSTEOBRACUNA = new DataColumn("IDRSVRSTEOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnIDRSVRSTEOBRACUNA.AllowDBNull = false;
                this.columnIDRSVRSTEOBRACUNA.Caption = "Šifra vrste obraeuna";
                this.columnIDRSVRSTEOBRACUNA.MaxLength = 2;
                this.columnIDRSVRSTEOBRACUNA.Unique = true;
                this.columnIDRSVRSTEOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Description", "Šifra vrste obračuna");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Length", "2");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "IDRSVRSTEOBRACUNA");
                this.Columns.Add(this.columnIDRSVRSTEOBRACUNA);
                this.columnNAZIVRSVRSTEOBRACUNA = new DataColumn("NAZIVRSVRSTEOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnNAZIVRSVRSTEOBRACUNA.AllowDBNull = false;
                this.columnNAZIVRSVRSTEOBRACUNA.Caption = "Naziv vrste obraeuna";
                this.columnNAZIVRSVRSTEOBRACUNA.MaxLength = 100;
                this.columnNAZIVRSVRSTEOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Description", "Naziv vrste obračuna");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVRSVRSTEOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVRSVRSTEOBRACUNA");
                this.Columns.Add(this.columnNAZIVRSVRSTEOBRACUNA);
                this.PrimaryKey = new DataColumn[] { this.columnIDRSVRSTEOBRACUNA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RSVRSTEOBRACUNA");
                this.ExtendedProperties.Add("Description", "R-Sm - Vrste obraeuna");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDRSVRSTEOBRACUNA = this.Columns["IDRSVRSTEOBRACUNA"];
                this.columnNAZIVRSVRSTEOBRACUNA = this.Columns["NAZIVRSVRSTEOBRACUNA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow(builder);
            }

            public RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow NewRSVRSTEOBRACUNARow()
            {
                return (RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RSVRSTEOBRACUNARowChanged != null)
                {
                    RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARowChangeEventHandler rSVRSTEOBRACUNARowChangedEvent = this.RSVRSTEOBRACUNARowChanged;
                    if (rSVRSTEOBRACUNARowChangedEvent != null)
                    {
                        rSVRSTEOBRACUNARowChangedEvent(this, new RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARowChangeEvent((RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RSVRSTEOBRACUNARowChanging != null)
                {
                    RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARowChangeEventHandler rSVRSTEOBRACUNARowChangingEvent = this.RSVRSTEOBRACUNARowChanging;
                    if (rSVRSTEOBRACUNARowChangingEvent != null)
                    {
                        rSVRSTEOBRACUNARowChangingEvent(this, new RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARowChangeEvent((RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RSVRSTEOBRACUNARowDeleted != null)
                {
                    RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARowChangeEventHandler rSVRSTEOBRACUNARowDeletedEvent = this.RSVRSTEOBRACUNARowDeleted;
                    if (rSVRSTEOBRACUNARowDeletedEvent != null)
                    {
                        rSVRSTEOBRACUNARowDeletedEvent(this, new RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARowChangeEvent((RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RSVRSTEOBRACUNARowDeleting != null)
                {
                    RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARowChangeEventHandler rSVRSTEOBRACUNARowDeletingEvent = this.RSVRSTEOBRACUNARowDeleting;
                    if (rSVRSTEOBRACUNARowDeletingEvent != null)
                    {
                        rSVRSTEOBRACUNARowDeletingEvent(this, new RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARowChangeEvent((RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRSVRSTEOBRACUNARow(RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow row)
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

            public DataColumn IDRSVRSTEOBRACUNAColumn
            {
                get
                {
                    return this.columnIDRSVRSTEOBRACUNA;
                }
            }

            public RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow this[int index]
            {
                get
                {
                    return (RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVRSVRSTEOBRACUNAColumn
            {
                get
                {
                    return this.columnNAZIVRSVRSTEOBRACUNA;
                }
            }
        }

        public class RSVRSTEOBRACUNARow : DataRow
        {
            private RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNADataTable tableRSVRSTEOBRACUNA;

            internal RSVRSTEOBRACUNARow(DataRowBuilder rb) : base(rb)
            {
                this.tableRSVRSTEOBRACUNA = (RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNADataTable) this.Table;
            }

            public bool IsIDRSVRSTEOBRACUNANull()
            {
                return this.IsNull(this.tableRSVRSTEOBRACUNA.IDRSVRSTEOBRACUNAColumn);
            }

            public bool IsNAZIVRSVRSTEOBRACUNANull()
            {
                return this.IsNull(this.tableRSVRSTEOBRACUNA.NAZIVRSVRSTEOBRACUNAColumn);
            }

            public void SetNAZIVRSVRSTEOBRACUNANull()
            {
                this[this.tableRSVRSTEOBRACUNA.NAZIVRSVRSTEOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string IDRSVRSTEOBRACUNA
            {
                get
                {
                    return Conversions.ToString(this[this.tableRSVRSTEOBRACUNA.IDRSVRSTEOBRACUNAColumn]);
                }
                set
                {
                    this[this.tableRSVRSTEOBRACUNA.IDRSVRSTEOBRACUNAColumn] = value;
                }
            }

            public string NAZIVRSVRSTEOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSVRSTEOBRACUNA.NAZIVRSVRSTEOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVRSVRSTEOBRACUNA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSVRSTEOBRACUNA.NAZIVRSVRSTEOBRACUNAColumn] = value;
                }
            }
        }

        public class RSVRSTEOBRACUNARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow eventRow;

            public RSVRSTEOBRACUNARowChangeEvent(RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow row, DataRowAction action)
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

            public RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RSVRSTEOBRACUNARowChangeEventHandler(object sender, RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARowChangeEvent e);
    }
}

