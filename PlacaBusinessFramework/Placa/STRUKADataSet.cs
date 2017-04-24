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
    public class STRUKADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private STRUKADataTable tableSTRUKA;

        public STRUKADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected STRUKADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["STRUKA"] != null)
                    {
                        this.Tables.Add(new STRUKADataTable(dataSet.Tables["STRUKA"]));
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
            STRUKADataSet set = (STRUKADataSet) base.Clone();
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
            STRUKADataSet set = new STRUKADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "STRUKADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1024");
            this.ExtendedProperties.Add("DataSetName", "STRUKADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ISTRUKADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "STRUKA");
            this.ExtendedProperties.Add("ObjectDescription", "Struke");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVSTRUKA");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "STRUKADataSet";
            this.Namespace = "http://www.tempuri.org/STRUKA";
            this.tableSTRUKA = new STRUKADataTable();
            this.Tables.Add(this.tableSTRUKA);
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
            this.tableSTRUKA = (STRUKADataTable) this.Tables["STRUKA"];
            if (initTable && (this.tableSTRUKA != null))
            {
                this.tableSTRUKA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["STRUKA"] != null)
                {
                    this.Tables.Add(new STRUKADataTable(dataSet.Tables["STRUKA"]));
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

        private bool ShouldSerializeSTRUKA()
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
        public STRUKADataTable STRUKA
        {
            get
            {
                return this.tableSTRUKA;
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
        public class STRUKADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSTRUKA;
            private DataColumn columnNAZIVSTRUKA;

            public event STRUKADataSet.STRUKARowChangeEventHandler STRUKARowChanged;

            public event STRUKADataSet.STRUKARowChangeEventHandler STRUKARowChanging;

            public event STRUKADataSet.STRUKARowChangeEventHandler STRUKARowDeleted;

            public event STRUKADataSet.STRUKARowChangeEventHandler STRUKARowDeleting;

            public STRUKADataTable()
            {
                this.TableName = "STRUKA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal STRUKADataTable(DataTable table) : base(table.TableName)
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

            protected STRUKADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSTRUKARow(STRUKADataSet.STRUKARow row)
            {
                this.Rows.Add(row);
            }

            public STRUKADataSet.STRUKARow AddSTRUKARow(int iDSTRUKA, string nAZIVSTRUKA)
            {
                STRUKADataSet.STRUKARow row = (STRUKADataSet.STRUKARow) this.NewRow();
                row["IDSTRUKA"] = iDSTRUKA;
                row["NAZIVSTRUKA"] = nAZIVSTRUKA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                STRUKADataSet.STRUKADataTable table = (STRUKADataSet.STRUKADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public STRUKADataSet.STRUKARow FindByIDSTRUKA(int iDSTRUKA)
            {
                return (STRUKADataSet.STRUKARow) this.Rows.Find(new object[] { iDSTRUKA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(STRUKADataSet.STRUKARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                STRUKADataSet set = new STRUKADataSet();
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
                this.columnIDSTRUKA = new DataColumn("IDSTRUKA", typeof(int), "", MappingType.Element);
                this.columnIDSTRUKA.AllowDBNull = false;
                this.columnIDSTRUKA.Caption = "Šifra struke";
                this.columnIDSTRUKA.Unique = true;
                this.columnIDSTRUKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSTRUKA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSTRUKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSTRUKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSTRUKA.ExtendedProperties.Add("Description", "Šifra struke");
                this.columnIDSTRUKA.ExtendedProperties.Add("Length", "5");
                this.columnIDSTRUKA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSTRUKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSTRUKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.InternalName", "IDSTRUKA");
                this.Columns.Add(this.columnIDSTRUKA);
                this.columnNAZIVSTRUKA = new DataColumn("NAZIVSTRUKA", typeof(string), "", MappingType.Element);
                this.columnNAZIVSTRUKA.AllowDBNull = false;
                this.columnNAZIVSTRUKA.Caption = "Naziv struke";
                this.columnNAZIVSTRUKA.MaxLength = 50;
                this.columnNAZIVSTRUKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Description", "Naziv struke");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVSTRUKA");
                this.Columns.Add(this.columnNAZIVSTRUKA);
                this.PrimaryKey = new DataColumn[] { this.columnIDSTRUKA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "STRUKA");
                this.ExtendedProperties.Add("Description", "Struke");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDSTRUKA = this.Columns["IDSTRUKA"];
                this.columnNAZIVSTRUKA = this.Columns["NAZIVSTRUKA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new STRUKADataSet.STRUKARow(builder);
            }

            public STRUKADataSet.STRUKARow NewSTRUKARow()
            {
                return (STRUKADataSet.STRUKARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.STRUKARowChanged != null)
                {
                    STRUKADataSet.STRUKARowChangeEventHandler sTRUKARowChangedEvent = this.STRUKARowChanged;
                    if (sTRUKARowChangedEvent != null)
                    {
                        sTRUKARowChangedEvent(this, new STRUKADataSet.STRUKARowChangeEvent((STRUKADataSet.STRUKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.STRUKARowChanging != null)
                {
                    STRUKADataSet.STRUKARowChangeEventHandler sTRUKARowChangingEvent = this.STRUKARowChanging;
                    if (sTRUKARowChangingEvent != null)
                    {
                        sTRUKARowChangingEvent(this, new STRUKADataSet.STRUKARowChangeEvent((STRUKADataSet.STRUKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.STRUKARowDeleted != null)
                {
                    STRUKADataSet.STRUKARowChangeEventHandler sTRUKARowDeletedEvent = this.STRUKARowDeleted;
                    if (sTRUKARowDeletedEvent != null)
                    {
                        sTRUKARowDeletedEvent(this, new STRUKADataSet.STRUKARowChangeEvent((STRUKADataSet.STRUKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.STRUKARowDeleting != null)
                {
                    STRUKADataSet.STRUKARowChangeEventHandler sTRUKARowDeletingEvent = this.STRUKARowDeleting;
                    if (sTRUKARowDeletingEvent != null)
                    {
                        sTRUKARowDeletingEvent(this, new STRUKADataSet.STRUKARowChangeEvent((STRUKADataSet.STRUKARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSTRUKARow(STRUKADataSet.STRUKARow row)
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

            public DataColumn IDSTRUKAColumn
            {
                get
                {
                    return this.columnIDSTRUKA;
                }
            }

            public STRUKADataSet.STRUKARow this[int index]
            {
                get
                {
                    return (STRUKADataSet.STRUKARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVSTRUKAColumn
            {
                get
                {
                    return this.columnNAZIVSTRUKA;
                }
            }
        }

        public class STRUKARow : DataRow
        {
            private STRUKADataSet.STRUKADataTable tableSTRUKA;

            internal STRUKARow(DataRowBuilder rb) : base(rb)
            {
                this.tableSTRUKA = (STRUKADataSet.STRUKADataTable) this.Table;
            }

            public bool IsIDSTRUKANull()
            {
                return this.IsNull(this.tableSTRUKA.IDSTRUKAColumn);
            }

            public bool IsNAZIVSTRUKANull()
            {
                return this.IsNull(this.tableSTRUKA.NAZIVSTRUKAColumn);
            }

            public void SetNAZIVSTRUKANull()
            {
                this[this.tableSTRUKA.NAZIVSTRUKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSTRUKA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSTRUKA.IDSTRUKAColumn]);
                }
                set
                {
                    this[this.tableSTRUKA.IDSTRUKAColumn] = value;
                }
            }

            public string NAZIVSTRUKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSTRUKA.NAZIVSTRUKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVSTRUKA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableSTRUKA.NAZIVSTRUKAColumn] = value;
                }
            }
        }

        public class STRUKARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private STRUKADataSet.STRUKARow eventRow;

            public STRUKARowChangeEvent(STRUKADataSet.STRUKARow row, DataRowAction action)
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

            public STRUKADataSet.STRUKARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void STRUKARowChangeEventHandler(object sender, STRUKADataSet.STRUKARowChangeEvent e);
    }
}

