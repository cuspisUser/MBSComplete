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
    public class DDVRSTEIZNOSADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private DDVRSTEIZNOSADataTable tableDDVRSTEIZNOSA;

        public DDVRSTEIZNOSADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected DDVRSTEIZNOSADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["DDVRSTEIZNOSA"] != null)
                    {
                        this.Tables.Add(new DDVRSTEIZNOSADataTable(dataSet.Tables["DDVRSTEIZNOSA"]));
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
            DDVRSTEIZNOSADataSet set = (DDVRSTEIZNOSADataSet) base.Clone();
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
            DDVRSTEIZNOSADataSet set = new DDVRSTEIZNOSADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "DDVRSTEIZNOSADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2128");
            this.ExtendedProperties.Add("DataSetName", "DDVRSTEIZNOSADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IDDVRSTEIZNOSADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "DDVRSTEIZNOSA");
            this.ExtendedProperties.Add("ObjectDescription", "DD-Vrste iznosa");
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
            this.DataSetName = "DDVRSTEIZNOSADataSet";
            this.Namespace = "http://www.tempuri.org/DDVRSTEIZNOSA";
            this.tableDDVRSTEIZNOSA = new DDVRSTEIZNOSADataTable();
            this.Tables.Add(this.tableDDVRSTEIZNOSA);
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
            this.tableDDVRSTEIZNOSA = (DDVRSTEIZNOSADataTable) this.Tables["DDVRSTEIZNOSA"];
            if (initTable && (this.tableDDVRSTEIZNOSA != null))
            {
                this.tableDDVRSTEIZNOSA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["DDVRSTEIZNOSA"] != null)
                {
                    this.Tables.Add(new DDVRSTEIZNOSADataTable(dataSet.Tables["DDVRSTEIZNOSA"]));
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

        private bool ShouldSerializeDDVRSTEIZNOSA()
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
        public DDVRSTEIZNOSADataTable DDVRSTEIZNOSA
        {
            get
            {
                return this.tableDDVRSTEIZNOSA;
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
        public class DDVRSTEIZNOSADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDDDVRSTEIZNOSA;
            private DataColumn columnNAZIVDDVRSTEIZNOSA;

            public event DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARowChangeEventHandler DDVRSTEIZNOSARowChanged;

            public event DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARowChangeEventHandler DDVRSTEIZNOSARowChanging;

            public event DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARowChangeEventHandler DDVRSTEIZNOSARowDeleted;

            public event DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARowChangeEventHandler DDVRSTEIZNOSARowDeleting;

            public DDVRSTEIZNOSADataTable()
            {
                this.TableName = "DDVRSTEIZNOSA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDVRSTEIZNOSADataTable(DataTable table) : base(table.TableName)
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

            protected DDVRSTEIZNOSADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDVRSTEIZNOSARow(DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow row)
            {
                this.Rows.Add(row);
            }

            public DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow AddDDVRSTEIZNOSARow(int iDDDVRSTEIZNOSA, string nAZIVDDVRSTEIZNOSA)
            {
                DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow row = (DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow) this.NewRow();
                row["IDDDVRSTEIZNOSA"] = iDDDVRSTEIZNOSA;
                row["NAZIVDDVRSTEIZNOSA"] = nAZIVDDVRSTEIZNOSA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDVRSTEIZNOSADataSet.DDVRSTEIZNOSADataTable table = (DDVRSTEIZNOSADataSet.DDVRSTEIZNOSADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow FindByIDDDVRSTEIZNOSA(int iDDDVRSTEIZNOSA)
            {
                return (DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow) this.Rows.Find(new object[] { iDDDVRSTEIZNOSA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDVRSTEIZNOSADataSet set = new DDVRSTEIZNOSADataSet();
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
                this.columnIDDDVRSTEIZNOSA = new DataColumn("IDDDVRSTEIZNOSA", typeof(int), "", MappingType.Element);
                this.columnIDDDVRSTEIZNOSA.AllowDBNull = false;
                this.columnIDDDVRSTEIZNOSA.Caption = "IDDDVRSTEIZNOSA";
                this.columnIDDDVRSTEIZNOSA.Unique = true;
                this.columnIDDDVRSTEIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Length", "5");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "IDDDVRSTEIZNOSA");
                this.Columns.Add(this.columnIDDDVRSTEIZNOSA);
                this.columnNAZIVDDVRSTEIZNOSA = new DataColumn("NAZIVDDVRSTEIZNOSA", typeof(string), "", MappingType.Element);
                this.columnNAZIVDDVRSTEIZNOSA.AllowDBNull = false;
                this.columnNAZIVDDVRSTEIZNOSA.Caption = "NAZIVDDVRSTEIZNOSA";
                this.columnNAZIVDDVRSTEIZNOSA.MaxLength = 50;
                this.columnNAZIVDDVRSTEIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Description", "Vrsta iznosa - DD");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVDDVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVDDVRSTEIZNOSA");
                this.Columns.Add(this.columnNAZIVDDVRSTEIZNOSA);
                this.PrimaryKey = new DataColumn[] { this.columnIDDDVRSTEIZNOSA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "DDVRSTEIZNOSA");
                this.ExtendedProperties.Add("Description", "DD-Vrste iznosa");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDDDVRSTEIZNOSA = this.Columns["IDDDVRSTEIZNOSA"];
                this.columnNAZIVDDVRSTEIZNOSA = this.Columns["NAZIVDDVRSTEIZNOSA"];
            }

            public DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow NewDDVRSTEIZNOSARow()
            {
                return (DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDVRSTEIZNOSARowChanged != null)
                {
                    DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARowChangeEventHandler dDVRSTEIZNOSARowChangedEvent = this.DDVRSTEIZNOSARowChanged;
                    if (dDVRSTEIZNOSARowChangedEvent != null)
                    {
                        dDVRSTEIZNOSARowChangedEvent(this, new DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARowChangeEvent((DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDVRSTEIZNOSARowChanging != null)
                {
                    DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARowChangeEventHandler dDVRSTEIZNOSARowChangingEvent = this.DDVRSTEIZNOSARowChanging;
                    if (dDVRSTEIZNOSARowChangingEvent != null)
                    {
                        dDVRSTEIZNOSARowChangingEvent(this, new DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARowChangeEvent((DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DDVRSTEIZNOSARowDeleted != null)
                {
                    DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARowChangeEventHandler dDVRSTEIZNOSARowDeletedEvent = this.DDVRSTEIZNOSARowDeleted;
                    if (dDVRSTEIZNOSARowDeletedEvent != null)
                    {
                        dDVRSTEIZNOSARowDeletedEvent(this, new DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARowChangeEvent((DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDVRSTEIZNOSARowDeleting != null)
                {
                    DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARowChangeEventHandler dDVRSTEIZNOSARowDeletingEvent = this.DDVRSTEIZNOSARowDeleting;
                    if (dDVRSTEIZNOSARowDeletingEvent != null)
                    {
                        dDVRSTEIZNOSARowDeletingEvent(this, new DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARowChangeEvent((DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDVRSTEIZNOSARow(DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow row)
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

            public DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow this[int index]
            {
                get
                {
                    return (DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVDDVRSTEIZNOSAColumn
            {
                get
                {
                    return this.columnNAZIVDDVRSTEIZNOSA;
                }
            }
        }

        public class DDVRSTEIZNOSARow : DataRow
        {
            private DDVRSTEIZNOSADataSet.DDVRSTEIZNOSADataTable tableDDVRSTEIZNOSA;

            internal DDVRSTEIZNOSARow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDVRSTEIZNOSA = (DDVRSTEIZNOSADataSet.DDVRSTEIZNOSADataTable) this.Table;
            }

            public bool IsIDDDVRSTEIZNOSANull()
            {
                return this.IsNull(this.tableDDVRSTEIZNOSA.IDDDVRSTEIZNOSAColumn);
            }

            public bool IsNAZIVDDVRSTEIZNOSANull()
            {
                return this.IsNull(this.tableDDVRSTEIZNOSA.NAZIVDDVRSTEIZNOSAColumn);
            }

            public void SetNAZIVDDVRSTEIZNOSANull()
            {
                this[this.tableDDVRSTEIZNOSA.NAZIVDDVRSTEIZNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDDDVRSTEIZNOSA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDVRSTEIZNOSA.IDDDVRSTEIZNOSAColumn]);
                }
                set
                {
                    this[this.tableDDVRSTEIZNOSA.IDDDVRSTEIZNOSAColumn] = value;
                }
            }

            public string NAZIVDDVRSTEIZNOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDVRSTEIZNOSA.NAZIVDDVRSTEIZNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVDDVRSTEIZNOSA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDVRSTEIZNOSA.NAZIVDDVRSTEIZNOSAColumn] = value;
                }
            }
        }

        public class DDVRSTEIZNOSARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow eventRow;

            public DDVRSTEIZNOSARowChangeEvent(DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow row, DataRowAction action)
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

            public DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDVRSTEIZNOSARowChangeEventHandler(object sender, DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARowChangeEvent e);
    }
}

