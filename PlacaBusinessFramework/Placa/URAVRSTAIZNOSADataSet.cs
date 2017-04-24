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
    public class URAVRSTAIZNOSADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private URAVRSTAIZNOSADataTable tableURAVRSTAIZNOSA;

        public URAVRSTAIZNOSADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected URAVRSTAIZNOSADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["URAVRSTAIZNOSA"] != null)
                    {
                        this.Tables.Add(new URAVRSTAIZNOSADataTable(dataSet.Tables["URAVRSTAIZNOSA"]));
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
            URAVRSTAIZNOSADataSet set = (URAVRSTAIZNOSADataSet) base.Clone();
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
            URAVRSTAIZNOSADataSet set = new URAVRSTAIZNOSADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "URAVRSTAIZNOSADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2111");
            this.ExtendedProperties.Add("DataSetName", "URAVRSTAIZNOSADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IURAVRSTAIZNOSADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "URAVRSTAIZNOSA");
            this.ExtendedProperties.Add("ObjectDescription", "Vrste iznosa URA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "URAVRSTAIZNOSANAZIV");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "URAVRSTAIZNOSADataSet";
            this.Namespace = "http://www.tempuri.org/URAVRSTAIZNOSA";
            this.tableURAVRSTAIZNOSA = new URAVRSTAIZNOSADataTable();
            this.Tables.Add(this.tableURAVRSTAIZNOSA);
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
            this.tableURAVRSTAIZNOSA = (URAVRSTAIZNOSADataTable) this.Tables["URAVRSTAIZNOSA"];
            if (initTable && (this.tableURAVRSTAIZNOSA != null))
            {
                this.tableURAVRSTAIZNOSA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["URAVRSTAIZNOSA"] != null)
                {
                    this.Tables.Add(new URAVRSTAIZNOSADataTable(dataSet.Tables["URAVRSTAIZNOSA"]));
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

        private bool ShouldSerializeURAVRSTAIZNOSA()
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
        public URAVRSTAIZNOSADataTable URAVRSTAIZNOSA
        {
            get
            {
                return this.tableURAVRSTAIZNOSA;
            }
        }

        [Serializable]
        public class URAVRSTAIZNOSADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDURAVRSTAIZNOSA;
            private DataColumn columnURAVRSTAIZNOSANAZIV;

            public event URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARowChangeEventHandler URAVRSTAIZNOSARowChanged;

            public event URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARowChangeEventHandler URAVRSTAIZNOSARowChanging;

            public event URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARowChangeEventHandler URAVRSTAIZNOSARowDeleted;

            public event URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARowChangeEventHandler URAVRSTAIZNOSARowDeleting;

            public URAVRSTAIZNOSADataTable()
            {
                this.TableName = "URAVRSTAIZNOSA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal URAVRSTAIZNOSADataTable(DataTable table) : base(table.TableName)
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

            protected URAVRSTAIZNOSADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddURAVRSTAIZNOSARow(URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow row)
            {
                this.Rows.Add(row);
            }

            public URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow AddURAVRSTAIZNOSARow(int iDURAVRSTAIZNOSA, string uRAVRSTAIZNOSANAZIV)
            {
                URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow row = (URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow) this.NewRow();
                row["IDURAVRSTAIZNOSA"] = iDURAVRSTAIZNOSA;
                row["URAVRSTAIZNOSANAZIV"] = uRAVRSTAIZNOSANAZIV;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                URAVRSTAIZNOSADataSet.URAVRSTAIZNOSADataTable table = (URAVRSTAIZNOSADataSet.URAVRSTAIZNOSADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow FindByIDURAVRSTAIZNOSA(int iDURAVRSTAIZNOSA)
            {
                return (URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow) this.Rows.Find(new object[] { iDURAVRSTAIZNOSA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                URAVRSTAIZNOSADataSet set = new URAVRSTAIZNOSADataSet();
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
                this.columnIDURAVRSTAIZNOSA = new DataColumn("IDURAVRSTAIZNOSA", typeof(int), "", MappingType.Element);
                this.columnIDURAVRSTAIZNOSA.AllowDBNull = false;
                this.columnIDURAVRSTAIZNOSA.Caption = "IDURAVRSTAIZNOSA";
                this.columnIDURAVRSTAIZNOSA.Unique = true;
                this.columnIDURAVRSTAIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Length", "5");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "IDURAVRSTAIZNOSA");
                this.Columns.Add(this.columnIDURAVRSTAIZNOSA);
                this.columnURAVRSTAIZNOSANAZIV = new DataColumn("URAVRSTAIZNOSANAZIV", typeof(string), "", MappingType.Element);
                this.columnURAVRSTAIZNOSANAZIV.AllowDBNull = false;
                this.columnURAVRSTAIZNOSANAZIV.Caption = "URAVRSTAIZNOSANAZIV";
                this.columnURAVRSTAIZNOSANAZIV.MaxLength = 30;
                this.columnURAVRSTAIZNOSANAZIV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("IsKey", "false");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("ReadOnly", "false");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Description", "Naziv");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Length", "30");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Decimals", "0");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("IsInReader", "true");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnURAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.InternalName", "URAVRSTAIZNOSANAZIV");
                this.Columns.Add(this.columnURAVRSTAIZNOSANAZIV);
                this.PrimaryKey = new DataColumn[] { this.columnIDURAVRSTAIZNOSA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "URAVRSTAIZNOSA");
                this.ExtendedProperties.Add("Description", "Vrste iznosa URA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDURAVRSTAIZNOSA = this.Columns["IDURAVRSTAIZNOSA"];
                this.columnURAVRSTAIZNOSANAZIV = this.Columns["URAVRSTAIZNOSANAZIV"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow(builder);
            }

            public URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow NewURAVRSTAIZNOSARow()
            {
                return (URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.URAVRSTAIZNOSARowChanged != null)
                {
                    URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARowChangeEventHandler uRAVRSTAIZNOSARowChangedEvent = this.URAVRSTAIZNOSARowChanged;
                    if (uRAVRSTAIZNOSARowChangedEvent != null)
                    {
                        uRAVRSTAIZNOSARowChangedEvent(this, new URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARowChangeEvent((URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.URAVRSTAIZNOSARowChanging != null)
                {
                    URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARowChangeEventHandler uRAVRSTAIZNOSARowChangingEvent = this.URAVRSTAIZNOSARowChanging;
                    if (uRAVRSTAIZNOSARowChangingEvent != null)
                    {
                        uRAVRSTAIZNOSARowChangingEvent(this, new URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARowChangeEvent((URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.URAVRSTAIZNOSARowDeleted != null)
                {
                    URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARowChangeEventHandler uRAVRSTAIZNOSARowDeletedEvent = this.URAVRSTAIZNOSARowDeleted;
                    if (uRAVRSTAIZNOSARowDeletedEvent != null)
                    {
                        uRAVRSTAIZNOSARowDeletedEvent(this, new URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARowChangeEvent((URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.URAVRSTAIZNOSARowDeleting != null)
                {

                    URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARowChangeEventHandler uRAVRSTAIZNOSARowDeletingEvent = this.URAVRSTAIZNOSARowDeleting;
                    if (uRAVRSTAIZNOSARowDeletingEvent != null)
                    {
                        uRAVRSTAIZNOSARowDeletingEvent(this, new URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARowChangeEvent((URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveURAVRSTAIZNOSARow(URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow row)
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

            public DataColumn IDURAVRSTAIZNOSAColumn
            {
                get
                {
                    return this.columnIDURAVRSTAIZNOSA;
                }
            }

            public URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow this[int index]
            {
                get
                {
                    return (URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow) this.Rows[index];
                }
            }

            public DataColumn URAVRSTAIZNOSANAZIVColumn
            {
                get
                {
                    return this.columnURAVRSTAIZNOSANAZIV;
                }
            }
        }

        public class URAVRSTAIZNOSARow : DataRow
        {
            private URAVRSTAIZNOSADataSet.URAVRSTAIZNOSADataTable tableURAVRSTAIZNOSA;

            internal URAVRSTAIZNOSARow(DataRowBuilder rb) : base(rb)
            {
                this.tableURAVRSTAIZNOSA = (URAVRSTAIZNOSADataSet.URAVRSTAIZNOSADataTable) this.Table;
            }

            public bool IsIDURAVRSTAIZNOSANull()
            {
                return this.IsNull(this.tableURAVRSTAIZNOSA.IDURAVRSTAIZNOSAColumn);
            }

            public bool IsURAVRSTAIZNOSANAZIVNull()
            {
                return this.IsNull(this.tableURAVRSTAIZNOSA.URAVRSTAIZNOSANAZIVColumn);
            }

            public void SetURAVRSTAIZNOSANAZIVNull()
            {
                this[this.tableURAVRSTAIZNOSA.URAVRSTAIZNOSANAZIVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDURAVRSTAIZNOSA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableURAVRSTAIZNOSA.IDURAVRSTAIZNOSAColumn]);
                }
                set
                {
                    this[this.tableURAVRSTAIZNOSA.IDURAVRSTAIZNOSAColumn] = value;
                }
            }

            public string URAVRSTAIZNOSANAZIV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableURAVRSTAIZNOSA.URAVRSTAIZNOSANAZIVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value URAVRSTAIZNOSANAZIV because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableURAVRSTAIZNOSA.URAVRSTAIZNOSANAZIVColumn] = value;
                }
            }
        }

        public class URAVRSTAIZNOSARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow eventRow;

            public URAVRSTAIZNOSARowChangeEvent(URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow row, DataRowAction action)
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

            public URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void URAVRSTAIZNOSARowChangeEventHandler(object sender, URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARowChangeEvent e);
    }
}

