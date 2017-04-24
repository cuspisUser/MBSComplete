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
    public class STRANEKNJIZENJADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private STRANEKNJIZENJADataTable tableSTRANEKNJIZENJA;

        public STRANEKNJIZENJADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected STRANEKNJIZENJADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["STRANEKNJIZENJA"] != null)
                    {
                        this.Tables.Add(new STRANEKNJIZENJADataTable(dataSet.Tables["STRANEKNJIZENJA"]));
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
            STRANEKNJIZENJADataSet set = (STRANEKNJIZENJADataSet) base.Clone();
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
            STRANEKNJIZENJADataSet set = new STRANEKNJIZENJADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "STRANEKNJIZENJADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2110");
            this.ExtendedProperties.Add("DataSetName", "STRANEKNJIZENJADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ISTRANEKNJIZENJADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "STRANEKNJIZENJA");
            this.ExtendedProperties.Add("ObjectDescription", "Strane knjiženja");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Common");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVSTRANEKNJIZENJA");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "STRANEKNJIZENJADataSet";
            this.Namespace = "http://www.tempuri.org/STRANEKNJIZENJA";
            this.tableSTRANEKNJIZENJA = new STRANEKNJIZENJADataTable();
            this.Tables.Add(this.tableSTRANEKNJIZENJA);
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
            this.tableSTRANEKNJIZENJA = (STRANEKNJIZENJADataTable) this.Tables["STRANEKNJIZENJA"];
            if (initTable && (this.tableSTRANEKNJIZENJA != null))
            {
                this.tableSTRANEKNJIZENJA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["STRANEKNJIZENJA"] != null)
                {
                    this.Tables.Add(new STRANEKNJIZENJADataTable(dataSet.Tables["STRANEKNJIZENJA"]));
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

        private bool ShouldSerializeSTRANEKNJIZENJA()
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
        public STRANEKNJIZENJADataTable STRANEKNJIZENJA
        {
            get
            {
                return this.tableSTRANEKNJIZENJA;
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
        public class STRANEKNJIZENJADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSTRANEKNJIZENJA;
            private DataColumn columnNAZIVSTRANEKNJIZENJA;

            public event STRANEKNJIZENJADataSet.STRANEKNJIZENJARowChangeEventHandler STRANEKNJIZENJARowChanged;

            public event STRANEKNJIZENJADataSet.STRANEKNJIZENJARowChangeEventHandler STRANEKNJIZENJARowChanging;

            public event STRANEKNJIZENJADataSet.STRANEKNJIZENJARowChangeEventHandler STRANEKNJIZENJARowDeleted;

            public event STRANEKNJIZENJADataSet.STRANEKNJIZENJARowChangeEventHandler STRANEKNJIZENJARowDeleting;

            public STRANEKNJIZENJADataTable()
            {
                this.TableName = "STRANEKNJIZENJA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal STRANEKNJIZENJADataTable(DataTable table) : base(table.TableName)
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

            protected STRANEKNJIZENJADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSTRANEKNJIZENJARow(STRANEKNJIZENJADataSet.STRANEKNJIZENJARow row)
            {
                this.Rows.Add(row);
            }

            public STRANEKNJIZENJADataSet.STRANEKNJIZENJARow AddSTRANEKNJIZENJARow(int iDSTRANEKNJIZENJA, string nAZIVSTRANEKNJIZENJA)
            {
                STRANEKNJIZENJADataSet.STRANEKNJIZENJARow row = (STRANEKNJIZENJADataSet.STRANEKNJIZENJARow) this.NewRow();
                row["IDSTRANEKNJIZENJA"] = iDSTRANEKNJIZENJA;
                row["NAZIVSTRANEKNJIZENJA"] = nAZIVSTRANEKNJIZENJA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                STRANEKNJIZENJADataSet.STRANEKNJIZENJADataTable table = (STRANEKNJIZENJADataSet.STRANEKNJIZENJADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public STRANEKNJIZENJADataSet.STRANEKNJIZENJARow FindByIDSTRANEKNJIZENJA(int iDSTRANEKNJIZENJA)
            {
                return (STRANEKNJIZENJADataSet.STRANEKNJIZENJARow) this.Rows.Find(new object[] { iDSTRANEKNJIZENJA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(STRANEKNJIZENJADataSet.STRANEKNJIZENJARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                STRANEKNJIZENJADataSet set = new STRANEKNJIZENJADataSet();
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
                this.columnIDSTRANEKNJIZENJA = new DataColumn("IDSTRANEKNJIZENJA", typeof(int), "", MappingType.Element);
                this.columnIDSTRANEKNJIZENJA.AllowDBNull = false;
                this.columnIDSTRANEKNJIZENJA.Caption = "Šifra strane";
                this.columnIDSTRANEKNJIZENJA.Unique = true;
                this.columnIDSTRANEKNJIZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("Description", "Šifra strane");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("Length", "5");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.InternalName", "IDSTRANEKNJIZENJA");
                this.Columns.Add(this.columnIDSTRANEKNJIZENJA);
                this.columnNAZIVSTRANEKNJIZENJA = new DataColumn("NAZIVSTRANEKNJIZENJA", typeof(string), "", MappingType.Element);
                this.columnNAZIVSTRANEKNJIZENJA.AllowDBNull = false;
                this.columnNAZIVSTRANEKNJIZENJA.Caption = "Naziv strane";
                this.columnNAZIVSTRANEKNJIZENJA.MaxLength = 30;
                this.columnNAZIVSTRANEKNJIZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("Description", "Naziv strane");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("Length", "30");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVSTRANEKNJIZENJA");
                this.Columns.Add(this.columnNAZIVSTRANEKNJIZENJA);
                this.PrimaryKey = new DataColumn[] { this.columnIDSTRANEKNJIZENJA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "STRANEKNJIZENJA");
                this.ExtendedProperties.Add("Description", "Strane knjiženja");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDSTRANEKNJIZENJA = this.Columns["IDSTRANEKNJIZENJA"];
                this.columnNAZIVSTRANEKNJIZENJA = this.Columns["NAZIVSTRANEKNJIZENJA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new STRANEKNJIZENJADataSet.STRANEKNJIZENJARow(builder);
            }

            public STRANEKNJIZENJADataSet.STRANEKNJIZENJARow NewSTRANEKNJIZENJARow()
            {
                return (STRANEKNJIZENJADataSet.STRANEKNJIZENJARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.STRANEKNJIZENJARowChanged != null)
                {
                    STRANEKNJIZENJADataSet.STRANEKNJIZENJARowChangeEventHandler sTRANEKNJIZENJARowChangedEvent = this.STRANEKNJIZENJARowChanged;
                    if (sTRANEKNJIZENJARowChangedEvent != null)
                    {
                        sTRANEKNJIZENJARowChangedEvent(this, new STRANEKNJIZENJADataSet.STRANEKNJIZENJARowChangeEvent((STRANEKNJIZENJADataSet.STRANEKNJIZENJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.STRANEKNJIZENJARowChanging != null)
                {
                    STRANEKNJIZENJADataSet.STRANEKNJIZENJARowChangeEventHandler sTRANEKNJIZENJARowChangingEvent = this.STRANEKNJIZENJARowChanging;
                    if (sTRANEKNJIZENJARowChangingEvent != null)
                    {
                        sTRANEKNJIZENJARowChangingEvent(this, new STRANEKNJIZENJADataSet.STRANEKNJIZENJARowChangeEvent((STRANEKNJIZENJADataSet.STRANEKNJIZENJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.STRANEKNJIZENJARowDeleted != null)
                {
                    STRANEKNJIZENJADataSet.STRANEKNJIZENJARowChangeEventHandler sTRANEKNJIZENJARowDeletedEvent = this.STRANEKNJIZENJARowDeleted;
                    if (sTRANEKNJIZENJARowDeletedEvent != null)
                    {
                        sTRANEKNJIZENJARowDeletedEvent(this, new STRANEKNJIZENJADataSet.STRANEKNJIZENJARowChangeEvent((STRANEKNJIZENJADataSet.STRANEKNJIZENJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.STRANEKNJIZENJARowDeleting != null)
                {
                    STRANEKNJIZENJADataSet.STRANEKNJIZENJARowChangeEventHandler sTRANEKNJIZENJARowDeletingEvent = this.STRANEKNJIZENJARowDeleting;
                    if (sTRANEKNJIZENJARowDeletingEvent != null)
                    {
                        sTRANEKNJIZENJARowDeletingEvent(this, new STRANEKNJIZENJADataSet.STRANEKNJIZENJARowChangeEvent((STRANEKNJIZENJADataSet.STRANEKNJIZENJARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSTRANEKNJIZENJARow(STRANEKNJIZENJADataSet.STRANEKNJIZENJARow row)
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

            public DataColumn IDSTRANEKNJIZENJAColumn
            {
                get
                {
                    return this.columnIDSTRANEKNJIZENJA;
                }
            }

            public STRANEKNJIZENJADataSet.STRANEKNJIZENJARow this[int index]
            {
                get
                {
                    return (STRANEKNJIZENJADataSet.STRANEKNJIZENJARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVSTRANEKNJIZENJAColumn
            {
                get
                {
                    return this.columnNAZIVSTRANEKNJIZENJA;
                }
            }
        }

        public class STRANEKNJIZENJARow : DataRow
        {
            private STRANEKNJIZENJADataSet.STRANEKNJIZENJADataTable tableSTRANEKNJIZENJA;

            internal STRANEKNJIZENJARow(DataRowBuilder rb) : base(rb)
            {
                this.tableSTRANEKNJIZENJA = (STRANEKNJIZENJADataSet.STRANEKNJIZENJADataTable) this.Table;
            }

            public bool IsIDSTRANEKNJIZENJANull()
            {
                return this.IsNull(this.tableSTRANEKNJIZENJA.IDSTRANEKNJIZENJAColumn);
            }

            public bool IsNAZIVSTRANEKNJIZENJANull()
            {
                return this.IsNull(this.tableSTRANEKNJIZENJA.NAZIVSTRANEKNJIZENJAColumn);
            }

            public void SetNAZIVSTRANEKNJIZENJANull()
            {
                this[this.tableSTRANEKNJIZENJA.NAZIVSTRANEKNJIZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSTRANEKNJIZENJA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSTRANEKNJIZENJA.IDSTRANEKNJIZENJAColumn]);
                }
                set
                {
                    this[this.tableSTRANEKNJIZENJA.IDSTRANEKNJIZENJAColumn] = value;
                }
            }

            public string NAZIVSTRANEKNJIZENJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSTRANEKNJIZENJA.NAZIVSTRANEKNJIZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVSTRANEKNJIZENJA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableSTRANEKNJIZENJA.NAZIVSTRANEKNJIZENJAColumn] = value;
                }
            }
        }

        public class STRANEKNJIZENJARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private STRANEKNJIZENJADataSet.STRANEKNJIZENJARow eventRow;

            public STRANEKNJIZENJARowChangeEvent(STRANEKNJIZENJADataSet.STRANEKNJIZENJARow row, DataRowAction action)
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

            public STRANEKNJIZENJADataSet.STRANEKNJIZENJARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void STRANEKNJIZENJARowChangeEventHandler(object sender, STRANEKNJIZENJADataSet.STRANEKNJIZENJARowChangeEvent e);
    }
}

