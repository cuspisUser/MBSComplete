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
    public class DDIZDATAKDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private DDIZDATAKDataTable tableDDIZDATAK;

        public DDIZDATAKDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected DDIZDATAKDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["DDIZDATAK"] != null)
                    {
                        this.Tables.Add(new DDIZDATAKDataTable(dataSet.Tables["DDIZDATAK"]));
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
            DDIZDATAKDataSet set = (DDIZDATAKDataSet) base.Clone();
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
            DDIZDATAKDataSet set = new DDIZDATAKDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "DDIZDATAKDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2086");
            this.ExtendedProperties.Add("DataSetName", "DDIZDATAKDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IDDIZDATAKDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "DDIZDATAK");
            this.ExtendedProperties.Add("ObjectDescription", "Izdaci");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\DD");
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
            this.DataSetName = "DDIZDATAKDataSet";
            this.Namespace = "http://www.tempuri.org/DDIZDATAK";
            this.tableDDIZDATAK = new DDIZDATAKDataTable();
            this.Tables.Add(this.tableDDIZDATAK);
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
            this.tableDDIZDATAK = (DDIZDATAKDataTable) this.Tables["DDIZDATAK"];
            if (initTable && (this.tableDDIZDATAK != null))
            {
                this.tableDDIZDATAK.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["DDIZDATAK"] != null)
                {
                    this.Tables.Add(new DDIZDATAKDataTable(dataSet.Tables["DDIZDATAK"]));
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

        private bool ShouldSerializeDDIZDATAK()
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
        public DDIZDATAKDataTable DDIZDATAK
        {
            get
            {
                return this.tableDDIZDATAK;
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
        public class DDIZDATAKDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDIDIZDATAK;
            private DataColumn columnDDNAZIVIZDATKA;
            private DataColumn columnDDPOSTOTAKIZDATKA;

            public event DDIZDATAKDataSet.DDIZDATAKRowChangeEventHandler DDIZDATAKRowChanged;

            public event DDIZDATAKDataSet.DDIZDATAKRowChangeEventHandler DDIZDATAKRowChanging;

            public event DDIZDATAKDataSet.DDIZDATAKRowChangeEventHandler DDIZDATAKRowDeleted;

            public event DDIZDATAKDataSet.DDIZDATAKRowChangeEventHandler DDIZDATAKRowDeleting;

            public DDIZDATAKDataTable()
            {
                this.TableName = "DDIZDATAK";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDIZDATAKDataTable(DataTable table) : base(table.TableName)
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

            protected DDIZDATAKDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDIZDATAKRow(DDIZDATAKDataSet.DDIZDATAKRow row)
            {
                this.Rows.Add(row);
            }

            public DDIZDATAKDataSet.DDIZDATAKRow AddDDIZDATAKRow(int dDIDIZDATAK, string dDNAZIVIZDATKA, decimal dDPOSTOTAKIZDATKA)
            {
                DDIZDATAKDataSet.DDIZDATAKRow row = (DDIZDATAKDataSet.DDIZDATAKRow) this.NewRow();
                row["DDIDIZDATAK"] = dDIDIZDATAK;
                row["DDNAZIVIZDATKA"] = dDNAZIVIZDATKA;
                row["DDPOSTOTAKIZDATKA"] = dDPOSTOTAKIZDATKA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDIZDATAKDataSet.DDIZDATAKDataTable table = (DDIZDATAKDataSet.DDIZDATAKDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDIZDATAKDataSet.DDIZDATAKRow FindByDDIDIZDATAK(int dDIDIZDATAK)
            {
                return (DDIZDATAKDataSet.DDIZDATAKRow) this.Rows.Find(new object[] { dDIDIZDATAK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDIZDATAKDataSet.DDIZDATAKRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDIZDATAKDataSet set = new DDIZDATAKDataSet();
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
                this.columnDDIDIZDATAK = new DataColumn("DDIDIZDATAK", typeof(int), "", MappingType.Element);
                this.columnDDIDIZDATAK.AllowDBNull = false;
                this.columnDDIDIZDATAK.Caption = "DDIDIZDATAK";
                this.columnDDIDIZDATAK.Unique = true;
                this.columnDDIDIZDATAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("IsKey", "true");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Description", "Šifra izdatka");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Length", "5");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.InternalName", "DDIDIZDATAK");
                this.Columns.Add(this.columnDDIDIZDATAK);
                this.columnDDNAZIVIZDATKA = new DataColumn("DDNAZIVIZDATKA", typeof(string), "", MappingType.Element);
                this.columnDDNAZIVIZDATKA.AllowDBNull = false;
                this.columnDDNAZIVIZDATKA.Caption = "DDNAZIVIZDATKA";
                this.columnDDNAZIVIZDATKA.MaxLength = 50;
                this.columnDDNAZIVIZDATKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Description", "Naziv izdatka");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Length", "50");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Decimals", "0");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.InternalName", "DDNAZIVIZDATKA");
                this.Columns.Add(this.columnDDNAZIVIZDATKA);
                this.columnDDPOSTOTAKIZDATKA = new DataColumn("DDPOSTOTAKIZDATKA", typeof(decimal), "", MappingType.Element);
                this.columnDDPOSTOTAKIZDATKA.AllowDBNull = false;
                this.columnDDPOSTOTAKIZDATKA.Caption = "DDPOSTOTAKIZDATKA";
                this.columnDDPOSTOTAKIZDATKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Description", "Postotak izdatka");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Length", "5");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Decimals", "2");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.InternalName", "DDPOSTOTAKIZDATKA");
                this.Columns.Add(this.columnDDPOSTOTAKIZDATKA);
                this.PrimaryKey = new DataColumn[] { this.columnDDIDIZDATAK };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "DDIZDATAK");
                this.ExtendedProperties.Add("Description", "Izdaci");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnDDIDIZDATAK = this.Columns["DDIDIZDATAK"];
                this.columnDDNAZIVIZDATKA = this.Columns["DDNAZIVIZDATKA"];
                this.columnDDPOSTOTAKIZDATKA = this.Columns["DDPOSTOTAKIZDATKA"];
            }

            public DDIZDATAKDataSet.DDIZDATAKRow NewDDIZDATAKRow()
            {
                return (DDIZDATAKDataSet.DDIZDATAKRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDIZDATAKDataSet.DDIZDATAKRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDIZDATAKRowChanged != null)
                {
                    DDIZDATAKDataSet.DDIZDATAKRowChangeEventHandler dDIZDATAKRowChangedEvent = this.DDIZDATAKRowChanged;
                    if (dDIZDATAKRowChangedEvent != null)
                    {
                        dDIZDATAKRowChangedEvent(this, new DDIZDATAKDataSet.DDIZDATAKRowChangeEvent((DDIZDATAKDataSet.DDIZDATAKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDIZDATAKRowChanging != null)
                {
                    DDIZDATAKDataSet.DDIZDATAKRowChangeEventHandler dDIZDATAKRowChangingEvent = this.DDIZDATAKRowChanging;
                    if (dDIZDATAKRowChangingEvent != null)
                    {
                        dDIZDATAKRowChangingEvent(this, new DDIZDATAKDataSet.DDIZDATAKRowChangeEvent((DDIZDATAKDataSet.DDIZDATAKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DDIZDATAKRowDeleted != null)
                {
                    DDIZDATAKDataSet.DDIZDATAKRowChangeEventHandler dDIZDATAKRowDeletedEvent = this.DDIZDATAKRowDeleted;
                    if (dDIZDATAKRowDeletedEvent != null)
                    {
                        dDIZDATAKRowDeletedEvent(this, new DDIZDATAKDataSet.DDIZDATAKRowChangeEvent((DDIZDATAKDataSet.DDIZDATAKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDIZDATAKRowDeleting != null)
                {
                    DDIZDATAKDataSet.DDIZDATAKRowChangeEventHandler dDIZDATAKRowDeletingEvent = this.DDIZDATAKRowDeleting;
                    if (dDIZDATAKRowDeletingEvent != null)
                    {
                        dDIZDATAKRowDeletingEvent(this, new DDIZDATAKDataSet.DDIZDATAKRowChangeEvent((DDIZDATAKDataSet.DDIZDATAKRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDIZDATAKRow(DDIZDATAKDataSet.DDIZDATAKRow row)
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

            public DataColumn DDIDIZDATAKColumn
            {
                get
                {
                    return this.columnDDIDIZDATAK;
                }
            }

            public DataColumn DDNAZIVIZDATKAColumn
            {
                get
                {
                    return this.columnDDNAZIVIZDATKA;
                }
            }

            public DataColumn DDPOSTOTAKIZDATKAColumn
            {
                get
                {
                    return this.columnDDPOSTOTAKIZDATKA;
                }
            }

            public DDIZDATAKDataSet.DDIZDATAKRow this[int index]
            {
                get
                {
                    return (DDIZDATAKDataSet.DDIZDATAKRow) this.Rows[index];
                }
            }
        }

        public class DDIZDATAKRow : DataRow
        {
            private DDIZDATAKDataSet.DDIZDATAKDataTable tableDDIZDATAK;

            internal DDIZDATAKRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDIZDATAK = (DDIZDATAKDataSet.DDIZDATAKDataTable) this.Table;
            }

            public bool IsDDIDIZDATAKNull()
            {
                return this.IsNull(this.tableDDIZDATAK.DDIDIZDATAKColumn);
            }

            public bool IsDDNAZIVIZDATKANull()
            {
                return this.IsNull(this.tableDDIZDATAK.DDNAZIVIZDATKAColumn);
            }

            public bool IsDDPOSTOTAKIZDATKANull()
            {
                return this.IsNull(this.tableDDIZDATAK.DDPOSTOTAKIZDATKAColumn);
            }

            public void SetDDNAZIVIZDATKANull()
            {
                this[this.tableDDIZDATAK.DDNAZIVIZDATKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPOSTOTAKIZDATKANull()
            {
                this[this.tableDDIZDATAK.DDPOSTOTAKIZDATKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int DDIDIZDATAK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDIZDATAK.DDIDIZDATAKColumn]);
                }
                set
                {
                    this[this.tableDDIZDATAK.DDIDIZDATAKColumn] = value;
                }
            }

            public string DDNAZIVIZDATKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDIZDATAK.DDNAZIVIZDATKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDNAZIVIZDATKA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDIZDATAK.DDNAZIVIZDATKAColumn] = value;
                }
            }

            public decimal DDPOSTOTAKIZDATKA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDIZDATAK.DDPOSTOTAKIZDATKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDPOSTOTAKIZDATKA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDIZDATAK.DDPOSTOTAKIZDATKAColumn] = value;
                }
            }
        }

        public class DDIZDATAKRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDIZDATAKDataSet.DDIZDATAKRow eventRow;

            public DDIZDATAKRowChangeEvent(DDIZDATAKDataSet.DDIZDATAKRow row, DataRowAction action)
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

            public DDIZDATAKDataSet.DDIZDATAKRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDIZDATAKRowChangeEventHandler(object sender, DDIZDATAKDataSet.DDIZDATAKRowChangeEvent e);
    }
}

