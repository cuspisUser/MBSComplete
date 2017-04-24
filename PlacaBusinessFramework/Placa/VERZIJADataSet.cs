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
    public class VERZIJADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private VERZIJADataTable tableVERZIJA;

        public VERZIJADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected VERZIJADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["VERZIJA"] != null)
                    {
                        this.Tables.Add(new VERZIJADataTable(dataSet.Tables["VERZIJA"]));
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
            VERZIJADataSet set = (VERZIJADataSet) base.Clone();
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
            VERZIJADataSet set = new VERZIJADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "VERZIJADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2055");
            this.ExtendedProperties.Add("DataSetName", "VERZIJADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IVERZIJADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "VERZIJA");
            this.ExtendedProperties.Add("ObjectDescription", "VERZIJA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Common");
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
            this.DataSetName = "VERZIJADataSet";
            this.Namespace = "http://www.tempuri.org/VERZIJA";
            this.tableVERZIJA = new VERZIJADataTable();
            this.Tables.Add(this.tableVERZIJA);
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
            this.tableVERZIJA = (VERZIJADataTable) this.Tables["VERZIJA"];
            if (initTable && (this.tableVERZIJA != null))
            {
                this.tableVERZIJA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["VERZIJA"] != null)
                {
                    this.Tables.Add(new VERZIJADataTable(dataSet.Tables["VERZIJA"]));
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

        private bool ShouldSerializeVERZIJA()
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
        public VERZIJADataTable VERZIJA
        {
            get
            {
                return this.tableVERZIJA;
            }
        }

        [Serializable]
        public class VERZIJADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDVERZIJA;
            private DataColumn columnVERZIJA;

            public event VERZIJADataSet.VERZIJARowChangeEventHandler VERZIJARowChanged;

            public event VERZIJADataSet.VERZIJARowChangeEventHandler VERZIJARowChanging;

            public event VERZIJADataSet.VERZIJARowChangeEventHandler VERZIJARowDeleted;

            public event VERZIJADataSet.VERZIJARowChangeEventHandler VERZIJARowDeleting;

            public VERZIJADataTable()
            {
                this.TableName = "VERZIJA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal VERZIJADataTable(DataTable table) : base(table.TableName)
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

            protected VERZIJADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddVERZIJARow(VERZIJADataSet.VERZIJARow row)
            {
                this.Rows.Add(row);
            }

            public VERZIJADataSet.VERZIJARow AddVERZIJARow(short iDVERZIJA, string vERZIJA)
            {
                VERZIJADataSet.VERZIJARow row = (VERZIJADataSet.VERZIJARow) this.NewRow();
                row["IDVERZIJA"] = iDVERZIJA;
                row["VERZIJA"] = vERZIJA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                VERZIJADataSet.VERZIJADataTable table = (VERZIJADataSet.VERZIJADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public VERZIJADataSet.VERZIJARow FindByIDVERZIJA(short iDVERZIJA)
            {
                return (VERZIJADataSet.VERZIJARow) this.Rows.Find(new object[] { iDVERZIJA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(VERZIJADataSet.VERZIJARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                VERZIJADataSet set = new VERZIJADataSet();
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
                this.columnIDVERZIJA = new DataColumn("IDVERZIJA", typeof(short), "", MappingType.Element);
                this.columnIDVERZIJA.AllowDBNull = false;
                this.columnIDVERZIJA.Caption = "IDVERZIJA";
                this.columnIDVERZIJA.Unique = true;
                this.columnIDVERZIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDVERZIJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDVERZIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDVERZIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDVERZIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDVERZIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDVERZIJA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDVERZIJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDVERZIJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDVERZIJA.ExtendedProperties.Add("Description", "IDVERZIJA");
                this.columnIDVERZIJA.ExtendedProperties.Add("Length", "2");
                this.columnIDVERZIJA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDVERZIJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDVERZIJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDVERZIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDVERZIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDVERZIJA.ExtendedProperties.Add("Deklarit.InternalName", "IDVERZIJA");
                this.Columns.Add(this.columnIDVERZIJA);
                this.columnVERZIJA = new DataColumn("VERZIJA", typeof(string), "", MappingType.Element);
                this.columnVERZIJA.AllowDBNull = false;
                this.columnVERZIJA.Caption = "VERZIJA";
                this.columnVERZIJA.MaxLength = 20;
                this.columnVERZIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVERZIJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVERZIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVERZIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVERZIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVERZIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVERZIJA.ExtendedProperties.Add("IsKey", "false");
                this.columnVERZIJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVERZIJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVERZIJA.ExtendedProperties.Add("Description", "VERZIJA");
                this.columnVERZIJA.ExtendedProperties.Add("Length", "20");
                this.columnVERZIJA.ExtendedProperties.Add("Decimals", "0");
                this.columnVERZIJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVERZIJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnVERZIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVERZIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVERZIJA.ExtendedProperties.Add("Deklarit.InternalName", "VERZIJA");
                this.Columns.Add(this.columnVERZIJA);
                this.PrimaryKey = new DataColumn[] { this.columnIDVERZIJA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "VERZIJA");
                this.ExtendedProperties.Add("Description", "VERZIJA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDVERZIJA = this.Columns["IDVERZIJA"];
                this.columnVERZIJA = this.Columns["VERZIJA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new VERZIJADataSet.VERZIJARow(builder);
            }

            public VERZIJADataSet.VERZIJARow NewVERZIJARow()
            {
                return (VERZIJADataSet.VERZIJARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VERZIJARowChanged != null)
                {
                    VERZIJADataSet.VERZIJARowChangeEventHandler vERZIJARowChangedEvent = this.VERZIJARowChanged;
                    if (vERZIJARowChangedEvent != null)
                    {
                        vERZIJARowChangedEvent(this, new VERZIJADataSet.VERZIJARowChangeEvent((VERZIJADataSet.VERZIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VERZIJARowChanging != null)
                {
                    VERZIJADataSet.VERZIJARowChangeEventHandler vERZIJARowChangingEvent = this.VERZIJARowChanging;
                    if (vERZIJARowChangingEvent != null)
                    {
                        vERZIJARowChangingEvent(this, new VERZIJADataSet.VERZIJARowChangeEvent((VERZIJADataSet.VERZIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VERZIJARowDeleted != null)
                {
                    VERZIJADataSet.VERZIJARowChangeEventHandler vERZIJARowDeletedEvent = this.VERZIJARowDeleted;
                    if (vERZIJARowDeletedEvent != null)
                    {
                        vERZIJARowDeletedEvent(this, new VERZIJADataSet.VERZIJARowChangeEvent((VERZIJADataSet.VERZIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VERZIJARowDeleting != null)
                {
                    VERZIJADataSet.VERZIJARowChangeEventHandler vERZIJARowDeletingEvent = this.VERZIJARowDeleting;
                    if (vERZIJARowDeletingEvent != null)
                    {
                        vERZIJARowDeletingEvent(this, new VERZIJADataSet.VERZIJARowChangeEvent((VERZIJADataSet.VERZIJARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveVERZIJARow(VERZIJADataSet.VERZIJARow row)
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

            public DataColumn IDVERZIJAColumn
            {
                get
                {
                    return this.columnIDVERZIJA;
                }
            }

            public VERZIJADataSet.VERZIJARow this[int index]
            {
                get
                {
                    return (VERZIJADataSet.VERZIJARow) this.Rows[index];
                }
            }

            public DataColumn VERZIJAColumn
            {
                get
                {
                    return this.columnVERZIJA;
                }
            }
        }

        public class VERZIJARow : DataRow
        {
            private VERZIJADataSet.VERZIJADataTable tableVERZIJA;

            internal VERZIJARow(DataRowBuilder rb) : base(rb)
            {
                this.tableVERZIJA = (VERZIJADataSet.VERZIJADataTable) this.Table;
            }

            public bool IsIDVERZIJANull()
            {
                return this.IsNull(this.tableVERZIJA.IDVERZIJAColumn);
            }

            public bool IsVERZIJANull()
            {
                return this.IsNull(this.tableVERZIJA.VERZIJAColumn);
            }

            public void SetVERZIJANull()
            {
                this[this.tableVERZIJA.VERZIJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public short IDVERZIJA
            {
                get
                {
                    return Conversions.ToShort(this[this.tableVERZIJA.IDVERZIJAColumn]);
                }
                set
                {
                    this[this.tableVERZIJA.IDVERZIJAColumn] = value;
                }
            }

            public string VERZIJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVERZIJA.VERZIJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value VERZIJA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableVERZIJA.VERZIJAColumn] = value;
                }
            }
        }

        public class VERZIJARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private VERZIJADataSet.VERZIJARow eventRow;

            public VERZIJARowChangeEvent(VERZIJADataSet.VERZIJARow row, DataRowAction action)
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

            public VERZIJADataSet.VERZIJARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void VERZIJARowChangeEventHandler(object sender, VERZIJADataSet.VERZIJARowChangeEvent e);
    }
}

