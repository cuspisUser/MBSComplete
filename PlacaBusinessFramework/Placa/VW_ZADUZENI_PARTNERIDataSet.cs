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
    public class VW_ZADUZENI_PARTNERIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private VW_ZADUZENI_PARTNERIDataTable tableVW_ZADUZENI_PARTNERI;

        public VW_ZADUZENI_PARTNERIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected VW_ZADUZENI_PARTNERIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["VW_ZADUZENI_PARTNERI"] != null)
                    {
                        this.Tables.Add(new VW_ZADUZENI_PARTNERIDataTable(dataSet.Tables["VW_ZADUZENI_PARTNERI"]));
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
            VW_ZADUZENI_PARTNERIDataSet set = (VW_ZADUZENI_PARTNERIDataSet) base.Clone();
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
            VW_ZADUZENI_PARTNERIDataSet set = new VW_ZADUZENI_PARTNERIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "VW_ZADUZENI_PARTNERIDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2011");
            this.ExtendedProperties.Add("DataSetName", "VW_ZADUZENI_PARTNERIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IVW_ZADUZENI_PARTNERIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "VW_ZADUZENI_PARTNERI");
            this.ExtendedProperties.Add("ObjectDescription", "VW_ZADUZENI_PARTNERI");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.GroupByAttributes", "");
            this.ExtendedProperties.Add("Deklarit.GenerateCRUDForDP", "False");
            this.ExtendedProperties.Add("Deklarit.ExtendedView", "false");
            this.ExtendedProperties.Add("Deklarit.ShowGroupByDP", "True");
            this.ExtendedProperties.Add("Deklarit.UseSuggestInFK", "False");
            this.ExtendedProperties.Add("Deklarit.BCForNewOption", "");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "VW_ZADUZENI_PARTNERIDataSet";
            this.Namespace = "http://www.tempuri.org/VW_ZADUZENI_PARTNERI";
            this.tableVW_ZADUZENI_PARTNERI = new VW_ZADUZENI_PARTNERIDataTable();
            this.Tables.Add(this.tableVW_ZADUZENI_PARTNERI);
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
            this.tableVW_ZADUZENI_PARTNERI = (VW_ZADUZENI_PARTNERIDataTable) this.Tables["VW_ZADUZENI_PARTNERI"];
            if (initTable && (this.tableVW_ZADUZENI_PARTNERI != null))
            {
                this.tableVW_ZADUZENI_PARTNERI.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["VW_ZADUZENI_PARTNERI"] != null)
                {
                    this.Tables.Add(new VW_ZADUZENI_PARTNERIDataTable(dataSet.Tables["VW_ZADUZENI_PARTNERI"]));
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

        private bool ShouldSerializeVW_ZADUZENI_PARTNERI()
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
        public VW_ZADUZENI_PARTNERIDataTable VW_ZADUZENI_PARTNERI
        {
            get
            {
                return this.tableVW_ZADUZENI_PARTNERI;
            }
        }

        [Serializable]
        public class VW_ZADUZENI_PARTNERIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDPARTNER;

            public event VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRowChangeEventHandler VW_ZADUZENI_PARTNERIRowChanged;

            public event VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRowChangeEventHandler VW_ZADUZENI_PARTNERIRowChanging;

            public event VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRowChangeEventHandler VW_ZADUZENI_PARTNERIRowDeleted;

            public event VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRowChangeEventHandler VW_ZADUZENI_PARTNERIRowDeleting;

            public VW_ZADUZENI_PARTNERIDataTable()
            {
                this.TableName = "VW_ZADUZENI_PARTNERI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal VW_ZADUZENI_PARTNERIDataTable(DataTable table) : base(table.TableName)
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

            protected VW_ZADUZENI_PARTNERIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddVW_ZADUZENI_PARTNERIRow(VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow row)
            {
                this.Rows.Add(row);
            }

            public VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow AddVW_ZADUZENI_PARTNERIRow(int iDPARTNER)
            {
                VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow row = (VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow) this.NewRow();
                row.ItemArray = new object[] { iDPARTNER };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIDataTable table = (VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                VW_ZADUZENI_PARTNERIDataSet set = new VW_ZADUZENI_PARTNERIDataSet();
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
                this.columnIDPARTNER = new DataColumn("IDPARTNER", typeof(int), "", MappingType.Element);
                this.columnIDPARTNER.Caption = "Šifra partnera";
                this.columnIDPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPARTNER.ExtendedProperties.Add("Description", "Šifra partnera");
                this.columnIDPARTNER.ExtendedProperties.Add("Length", "9");
                this.columnIDPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "IDPARTNER");
                this.Columns.Add(this.columnIDPARTNER);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "VW_ZADUZENI_PARTNERI");
                this.ExtendedProperties.Add("Description", "VW_ZADUZENI_PARTNERI");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDPARTNER = this.Columns["IDPARTNER"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow(builder);
            }

            public VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow NewVW_ZADUZENI_PARTNERIRow()
            {
                return (VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VW_ZADUZENI_PARTNERIRowChanged != null)
                {
                    VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRowChangeEventHandler handler = this.VW_ZADUZENI_PARTNERIRowChanged;
                    if (handler != null)
                    {
                        handler(this, new VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRowChangeEvent((VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VW_ZADUZENI_PARTNERIRowChanging != null)
                {
                    VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRowChangeEventHandler handler = this.VW_ZADUZENI_PARTNERIRowChanging;
                    if (handler != null)
                    {
                        handler(this, new VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRowChangeEvent((VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VW_ZADUZENI_PARTNERIRowDeleted != null)
                {
                    VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRowChangeEventHandler handler = this.VW_ZADUZENI_PARTNERIRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRowChangeEvent((VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VW_ZADUZENI_PARTNERIRowDeleting != null)
                {
                    VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRowChangeEventHandler handler = this.VW_ZADUZENI_PARTNERIRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRowChangeEvent((VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveVW_ZADUZENI_PARTNERIRow(VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow row)
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

            public DataColumn IDPARTNERColumn
            {
                get
                {
                    return this.columnIDPARTNER;
                }
            }

            public VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow this[int index]
            {
                get
                {
                    return (VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow) this.Rows[index];
                }
            }
        }

        public class VW_ZADUZENI_PARTNERIRow : DataRow
        {
            private VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIDataTable tableVW_ZADUZENI_PARTNERI;

            internal VW_ZADUZENI_PARTNERIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableVW_ZADUZENI_PARTNERI = (VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIDataTable) this.Table;
            }

            public bool IsIDPARTNERNull()
            {
                return this.IsNull(this.tableVW_ZADUZENI_PARTNERI.IDPARTNERColumn);
            }

            public void SetIDPARTNERNull()
            {
                this[this.tableVW_ZADUZENI_PARTNERI.IDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDPARTNER
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableVW_ZADUZENI_PARTNERI.IDPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDPARTNER because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableVW_ZADUZENI_PARTNERI.IDPARTNERColumn] = value;
                }
            }
        }

        public class VW_ZADUZENI_PARTNERIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow eventRow;

            public VW_ZADUZENI_PARTNERIRowChangeEvent(VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow row, DataRowAction action)
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

            public VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void VW_ZADUZENI_PARTNERIRowChangeEventHandler(object sender, VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRowChangeEvent e);
    }
}

