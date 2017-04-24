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
    public class RSVRSTEOBVEZNIKADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RSVRSTEOBVEZNIKADataTable tableRSVRSTEOBVEZNIKA;

        public RSVRSTEOBVEZNIKADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RSVRSTEOBVEZNIKADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RSVRSTEOBVEZNIKA"] != null)
                    {
                        this.Tables.Add(new RSVRSTEOBVEZNIKADataTable(dataSet.Tables["RSVRSTEOBVEZNIKA"]));
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
            RSVRSTEOBVEZNIKADataSet set = (RSVRSTEOBVEZNIKADataSet) base.Clone();
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
            RSVRSTEOBVEZNIKADataSet set = new RSVRSTEOBVEZNIKADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RSVRSTEOBVEZNIKADataAdapter");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1021");
            this.ExtendedProperties.Add("DataSetName", "RSVRSTEOBVEZNIKADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRSVRSTEOBVEZNIKADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RSVRSTEOBVEZNIKA");
            this.ExtendedProperties.Add("ObjectDescription", "R-Sm - Vrste obveznika");
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
            this.DataSetName = "RSVRSTEOBVEZNIKADataSet";
            this.Namespace = "http://www.tempuri.org/RSVRSTEOBVEZNIKA";
            this.tableRSVRSTEOBVEZNIKA = new RSVRSTEOBVEZNIKADataTable();
            this.Tables.Add(this.tableRSVRSTEOBVEZNIKA);
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
            this.tableRSVRSTEOBVEZNIKA = (RSVRSTEOBVEZNIKADataTable) this.Tables["RSVRSTEOBVEZNIKA"];
            if (initTable && (this.tableRSVRSTEOBVEZNIKA != null))
            {
                this.tableRSVRSTEOBVEZNIKA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RSVRSTEOBVEZNIKA"] != null)
                {
                    this.Tables.Add(new RSVRSTEOBVEZNIKADataTable(dataSet.Tables["RSVRSTEOBVEZNIKA"]));
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

        private bool ShouldSerializeRSVRSTEOBVEZNIKA()
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
        public RSVRSTEOBVEZNIKADataTable RSVRSTEOBVEZNIKA
        {
            get
            {
                return this.tableRSVRSTEOBVEZNIKA;
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
        public class RSVRSTEOBVEZNIKADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRSVRSTEOBVEZNIKA;
            private DataColumn columnNAZIVRSVRSTEOBVEZNIKA;

            public event RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARowChangeEventHandler RSVRSTEOBVEZNIKARowChanged;

            public event RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARowChangeEventHandler RSVRSTEOBVEZNIKARowChanging;

            public event RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARowChangeEventHandler RSVRSTEOBVEZNIKARowDeleted;

            public event RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARowChangeEventHandler RSVRSTEOBVEZNIKARowDeleting;

            public RSVRSTEOBVEZNIKADataTable()
            {
                this.TableName = "RSVRSTEOBVEZNIKA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RSVRSTEOBVEZNIKADataTable(DataTable table) : base(table.TableName)
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

            protected RSVRSTEOBVEZNIKADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRSVRSTEOBVEZNIKARow(RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow row)
            {
                this.Rows.Add(row);
            }

            public RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow AddRSVRSTEOBVEZNIKARow(string iDRSVRSTEOBVEZNIKA, string nAZIVRSVRSTEOBVEZNIKA)
            {
                RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow row = (RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow) this.NewRow();
                row["IDRSVRSTEOBVEZNIKA"] = iDRSVRSTEOBVEZNIKA;
                row["NAZIVRSVRSTEOBVEZNIKA"] = nAZIVRSVRSTEOBVEZNIKA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKADataTable table = (RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow FindByIDRSVRSTEOBVEZNIKA(string iDRSVRSTEOBVEZNIKA)
            {
                return (RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow) this.Rows.Find(new object[] { iDRSVRSTEOBVEZNIKA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RSVRSTEOBVEZNIKADataSet set = new RSVRSTEOBVEZNIKADataSet();
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
                this.columnIDRSVRSTEOBVEZNIKA = new DataColumn("IDRSVRSTEOBVEZNIKA", typeof(string), "", MappingType.Element);
                this.columnIDRSVRSTEOBVEZNIKA.AllowDBNull = false;
                this.columnIDRSVRSTEOBVEZNIKA.Caption = "Šifra vrste obveznika";
                this.columnIDRSVRSTEOBVEZNIKA.MaxLength = 2;
                this.columnIDRSVRSTEOBVEZNIKA.Unique = true;
                this.columnIDRSVRSTEOBVEZNIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Description", "Šifra vrste obveznika");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Length", "2");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.InternalName", "IDRSVRSTEOBVEZNIKA");
                this.Columns.Add(this.columnIDRSVRSTEOBVEZNIKA);
                this.columnNAZIVRSVRSTEOBVEZNIKA = new DataColumn("NAZIVRSVRSTEOBVEZNIKA", typeof(string), "", MappingType.Element);
                this.columnNAZIVRSVRSTEOBVEZNIKA.AllowDBNull = false;
                this.columnNAZIVRSVRSTEOBVEZNIKA.Caption = "Naziv vrste obveznika";
                this.columnNAZIVRSVRSTEOBVEZNIKA.MaxLength = 100;
                this.columnNAZIVRSVRSTEOBVEZNIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Description", "Naziv vrste obveznika");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVRSVRSTEOBVEZNIKA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVRSVRSTEOBVEZNIKA");
                this.Columns.Add(this.columnNAZIVRSVRSTEOBVEZNIKA);
                this.PrimaryKey = new DataColumn[] { this.columnIDRSVRSTEOBVEZNIKA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RSVRSTEOBVEZNIKA");
                this.ExtendedProperties.Add("Description", "R-Sm - Vrste obveznika");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDRSVRSTEOBVEZNIKA = this.Columns["IDRSVRSTEOBVEZNIKA"];
                this.columnNAZIVRSVRSTEOBVEZNIKA = this.Columns["NAZIVRSVRSTEOBVEZNIKA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow(builder);
            }

            public RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow NewRSVRSTEOBVEZNIKARow()
            {
                return (RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RSVRSTEOBVEZNIKARowChanged != null)
                {
                    RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARowChangeEventHandler rSVRSTEOBVEZNIKARowChangedEvent = this.RSVRSTEOBVEZNIKARowChanged;
                    if (rSVRSTEOBVEZNIKARowChangedEvent != null)
                    {
                        rSVRSTEOBVEZNIKARowChangedEvent(this, new RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARowChangeEvent((RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RSVRSTEOBVEZNIKARowChanging != null)
                {
                    RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARowChangeEventHandler rSVRSTEOBVEZNIKARowChangingEvent = this.RSVRSTEOBVEZNIKARowChanging;
                    if (rSVRSTEOBVEZNIKARowChangingEvent != null)
                    {
                        rSVRSTEOBVEZNIKARowChangingEvent(this, new RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARowChangeEvent((RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RSVRSTEOBVEZNIKARowDeleted != null)
                {
                    RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARowChangeEventHandler rSVRSTEOBVEZNIKARowDeletedEvent = this.RSVRSTEOBVEZNIKARowDeleted;
                    if (rSVRSTEOBVEZNIKARowDeletedEvent != null)
                    {
                        rSVRSTEOBVEZNIKARowDeletedEvent(this, new RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARowChangeEvent((RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RSVRSTEOBVEZNIKARowDeleting != null)
                {
                    RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARowChangeEventHandler rSVRSTEOBVEZNIKARowDeletingEvent = this.RSVRSTEOBVEZNIKARowDeleting;
                    if (rSVRSTEOBVEZNIKARowDeletingEvent != null)
                    {
                        rSVRSTEOBVEZNIKARowDeletingEvent(this, new RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARowChangeEvent((RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRSVRSTEOBVEZNIKARow(RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow row)
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

            public DataColumn IDRSVRSTEOBVEZNIKAColumn
            {
                get
                {
                    return this.columnIDRSVRSTEOBVEZNIKA;
                }
            }

            public RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow this[int index]
            {
                get
                {
                    return (RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVRSVRSTEOBVEZNIKAColumn
            {
                get
                {
                    return this.columnNAZIVRSVRSTEOBVEZNIKA;
                }
            }
        }

        public class RSVRSTEOBVEZNIKARow : DataRow
        {
            private RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKADataTable tableRSVRSTEOBVEZNIKA;

            internal RSVRSTEOBVEZNIKARow(DataRowBuilder rb) : base(rb)
            {
                this.tableRSVRSTEOBVEZNIKA = (RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKADataTable) this.Table;
            }

            public bool IsIDRSVRSTEOBVEZNIKANull()
            {
                return this.IsNull(this.tableRSVRSTEOBVEZNIKA.IDRSVRSTEOBVEZNIKAColumn);
            }

            public bool IsNAZIVRSVRSTEOBVEZNIKANull()
            {
                return this.IsNull(this.tableRSVRSTEOBVEZNIKA.NAZIVRSVRSTEOBVEZNIKAColumn);
            }

            public void SetNAZIVRSVRSTEOBVEZNIKANull()
            {
                this[this.tableRSVRSTEOBVEZNIKA.NAZIVRSVRSTEOBVEZNIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string IDRSVRSTEOBVEZNIKA
            {
                get
                {
                    return Conversions.ToString(this[this.tableRSVRSTEOBVEZNIKA.IDRSVRSTEOBVEZNIKAColumn]);
                }
                set
                {
                    this[this.tableRSVRSTEOBVEZNIKA.IDRSVRSTEOBVEZNIKAColumn] = value;
                }
            }

            public string NAZIVRSVRSTEOBVEZNIKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRSVRSTEOBVEZNIKA.NAZIVRSVRSTEOBVEZNIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVRSVRSTEOBVEZNIKA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableRSVRSTEOBVEZNIKA.NAZIVRSVRSTEOBVEZNIKAColumn] = value;
                }
            }
        }

        public class RSVRSTEOBVEZNIKARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow eventRow;

            public RSVRSTEOBVEZNIKARowChangeEvent(RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow row, DataRowAction action)
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

            public RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RSVRSTEOBVEZNIKARowChangeEventHandler(object sender, RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARowChangeEvent e);
    }
}

