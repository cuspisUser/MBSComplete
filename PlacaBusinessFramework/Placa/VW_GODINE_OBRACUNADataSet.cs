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
    public class VW_GODINE_OBRACUNADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private VW_GODINE_OBRACUNADataTable tableVW_GODINE_OBRACUNA;

        public VW_GODINE_OBRACUNADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected VW_GODINE_OBRACUNADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["VW_GODINE_OBRACUNA"] != null)
                    {
                        this.Tables.Add(new VW_GODINE_OBRACUNADataTable(dataSet.Tables["VW_GODINE_OBRACUNA"]));
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
            VW_GODINE_OBRACUNADataSet set = (VW_GODINE_OBRACUNADataSet) base.Clone();
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
            VW_GODINE_OBRACUNADataSet set = new VW_GODINE_OBRACUNADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "VW_GODINE_OBRACUNADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2053");
            this.ExtendedProperties.Add("DataSetName", "VW_GODINE_OBRACUNADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IVW_GODINE_OBRACUNADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "VW_GODINE_OBRACUNA");
            this.ExtendedProperties.Add("ObjectDescription", "VW_GODINE_OBRACUNA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.GroupByAttributes", "");
            this.ExtendedProperties.Add("Deklarit.GenerateCRUDForDP", "false");
            this.ExtendedProperties.Add("Deklarit.ExtendedView", "false");
            this.ExtendedProperties.Add("Deklarit.ShowGroupByDP", "True");
            this.ExtendedProperties.Add("Deklarit.UseSuggestInFK", "False");
            this.ExtendedProperties.Add("Deklarit.BCForNewOption", "");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "VW_GODINE_OBRACUNADataSet";
            this.Namespace = "http://www.tempuri.org/VW_GODINE_OBRACUNA";
            this.tableVW_GODINE_OBRACUNA = new VW_GODINE_OBRACUNADataTable();
            this.Tables.Add(this.tableVW_GODINE_OBRACUNA);
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
            this.tableVW_GODINE_OBRACUNA = (VW_GODINE_OBRACUNADataTable) this.Tables["VW_GODINE_OBRACUNA"];
            if (initTable && (this.tableVW_GODINE_OBRACUNA != null))
            {
                this.tableVW_GODINE_OBRACUNA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["VW_GODINE_OBRACUNA"] != null)
                {
                    this.Tables.Add(new VW_GODINE_OBRACUNADataTable(dataSet.Tables["VW_GODINE_OBRACUNA"]));
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

        private bool ShouldSerializeVW_GODINE_OBRACUNA()
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
        public VW_GODINE_OBRACUNADataTable VW_GODINE_OBRACUNA
        {
            get
            {
                return this.tableVW_GODINE_OBRACUNA;
            }
        }

        [Serializable]
        public class VW_GODINE_OBRACUNADataTable : DataTable, IEnumerable
        {
            private DataColumn columnGODINAOBRACUNA;

            public event VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARowChangeEventHandler VW_GODINE_OBRACUNARowChanged;

            public event VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARowChangeEventHandler VW_GODINE_OBRACUNARowChanging;

            public event VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARowChangeEventHandler VW_GODINE_OBRACUNARowDeleted;

            public event VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARowChangeEventHandler VW_GODINE_OBRACUNARowDeleting;

            public VW_GODINE_OBRACUNADataTable()
            {
                this.TableName = "VW_GODINE_OBRACUNA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal VW_GODINE_OBRACUNADataTable(DataTable table) : base(table.TableName)
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

            protected VW_GODINE_OBRACUNADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddVW_GODINE_OBRACUNARow(VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow row)
            {
                this.Rows.Add(row);
            }

            public VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow AddVW_GODINE_OBRACUNARow(string gODINAOBRACUNA)
            {
                VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow row = (VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow) this.NewRow();
                row.ItemArray = new object[] { gODINAOBRACUNA };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNADataTable table = (VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                VW_GODINE_OBRACUNADataSet set = new VW_GODINE_OBRACUNADataSet();
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
                this.columnGODINAOBRACUNA = new DataColumn("GODINAOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnGODINAOBRACUNA.Caption = "Godina obraeuna";
                this.columnGODINAOBRACUNA.MaxLength = 4;
                this.columnGODINAOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Description", "Godina obraeuna");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Length", "4");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "GODINAOBRACUNA");
                this.Columns.Add(this.columnGODINAOBRACUNA);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "VW_GODINE_OBRACUNA");
                this.ExtendedProperties.Add("Description", "VW_PLACA_GODINE_OBRACUNA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnGODINAOBRACUNA = this.Columns["GODINAOBRACUNA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow(builder);
            }

            public VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow NewVW_GODINE_OBRACUNARow()
            {
                return (VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VW_GODINE_OBRACUNARowChanged != null)
                {
                    VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARowChangeEventHandler handler = this.VW_GODINE_OBRACUNARowChanged;
                    if (handler != null)
                    {
                        handler(this, new VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARowChangeEvent((VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VW_GODINE_OBRACUNARowChanging != null)
                {
                    VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARowChangeEventHandler handler = this.VW_GODINE_OBRACUNARowChanging;
                    if (handler != null)
                    {
                        handler(this, new VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARowChangeEvent((VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VW_GODINE_OBRACUNARowDeleted != null)
                {
                    VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARowChangeEventHandler handler = this.VW_GODINE_OBRACUNARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARowChangeEvent((VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VW_GODINE_OBRACUNARowDeleting != null)
                {
                    VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARowChangeEventHandler handler = this.VW_GODINE_OBRACUNARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARowChangeEvent((VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveVW_GODINE_OBRACUNARow(VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow row)
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

            public DataColumn GODINAOBRACUNAColumn
            {
                get
                {
                    return this.columnGODINAOBRACUNA;
                }
            }

            public VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow this[int index]
            {
                get
                {
                    return (VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow) this.Rows[index];
                }
            }
        }

        public class VW_GODINE_OBRACUNARow : DataRow
        {
            private VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNADataTable tableVW_GODINE_OBRACUNA;

            internal VW_GODINE_OBRACUNARow(DataRowBuilder rb) : base(rb)
            {
                this.tableVW_GODINE_OBRACUNA = (VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNADataTable) this.Table;
            }

            public bool IsGODINAOBRACUNANull()
            {
                return this.IsNull(this.tableVW_GODINE_OBRACUNA.GODINAOBRACUNAColumn);
            }

            public void SetGODINAOBRACUNANull()
            {
                this[this.tableVW_GODINE_OBRACUNA.GODINAOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string GODINAOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVW_GODINE_OBRACUNA.GODINAOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value GODINAOBRACUNA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableVW_GODINE_OBRACUNA.GODINAOBRACUNAColumn] = value;
                }
            }
        }

        public class VW_GODINE_OBRACUNARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow eventRow;

            public VW_GODINE_OBRACUNARowChangeEvent(VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow row, DataRowAction action)
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

            public VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void VW_GODINE_OBRACUNARowChangeEventHandler(object sender, VW_GODINE_OBRACUNADataSet.VW_GODINE_OBRACUNARowChangeEvent e);
    }
}

