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
    public class STRANAKNJIZENJADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private STRANAKNJIZENJADataTable tableSTRANAKNJIZENJA;

        public STRANAKNJIZENJADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected STRANAKNJIZENJADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["STRANAKNJIZENJA"] != null)
                    {
                        this.Tables.Add(new STRANAKNJIZENJADataTable(dataSet.Tables["STRANAKNJIZENJA"]));
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
            STRANAKNJIZENJADataSet set = (STRANAKNJIZENJADataSet) base.Clone();
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
            STRANAKNJIZENJADataSet set = new STRANAKNJIZENJADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "STRANAKNJIZENJADataAdapter");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1073");
            this.ExtendedProperties.Add("DataSetName", "STRANAKNJIZENJADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ISTRANAKNJIZENJADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "STRANAKNJIZENJA");
            this.ExtendedProperties.Add("ObjectDescription", "Strane knjizenja");
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
            this.DataSetName = "STRANAKNJIZENJADataSet";
            this.Namespace = "http://www.tempuri.org/STRANAKNJIZENJA";
            this.tableSTRANAKNJIZENJA = new STRANAKNJIZENJADataTable();
            this.Tables.Add(this.tableSTRANAKNJIZENJA);
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
            this.tableSTRANAKNJIZENJA = (STRANAKNJIZENJADataTable) this.Tables["STRANAKNJIZENJA"];
            if (initTable && (this.tableSTRANAKNJIZENJA != null))
            {
                this.tableSTRANAKNJIZENJA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["STRANAKNJIZENJA"] != null)
                {
                    this.Tables.Add(new STRANAKNJIZENJADataTable(dataSet.Tables["STRANAKNJIZENJA"]));
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

        private bool ShouldSerializeSTRANAKNJIZENJA()
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
        public STRANAKNJIZENJADataTable STRANAKNJIZENJA
        {
            get
            {
                return this.tableSTRANAKNJIZENJA;
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
        public class STRANAKNJIZENJADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSTRANA;
            private DataColumn columnNAZIVSTRANE;

            public event STRANAKNJIZENJADataSet.STRANAKNJIZENJARowChangeEventHandler STRANAKNJIZENJARowChanged;

            public event STRANAKNJIZENJADataSet.STRANAKNJIZENJARowChangeEventHandler STRANAKNJIZENJARowChanging;

            public event STRANAKNJIZENJADataSet.STRANAKNJIZENJARowChangeEventHandler STRANAKNJIZENJARowDeleted;

            public event STRANAKNJIZENJADataSet.STRANAKNJIZENJARowChangeEventHandler STRANAKNJIZENJARowDeleting;

            public STRANAKNJIZENJADataTable()
            {
                this.TableName = "STRANAKNJIZENJA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal STRANAKNJIZENJADataTable(DataTable table) : base(table.TableName)
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

            protected STRANAKNJIZENJADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSTRANAKNJIZENJARow(STRANAKNJIZENJADataSet.STRANAKNJIZENJARow row)
            {
                this.Rows.Add(row);
            }

            public STRANAKNJIZENJADataSet.STRANAKNJIZENJARow AddSTRANAKNJIZENJARow(int iDSTRANA, string nAZIVSTRANE)
            {
                STRANAKNJIZENJADataSet.STRANAKNJIZENJARow row = (STRANAKNJIZENJADataSet.STRANAKNJIZENJARow) this.NewRow();
                row["IDSTRANA"] = iDSTRANA;
                row["NAZIVSTRANE"] = nAZIVSTRANE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                STRANAKNJIZENJADataSet.STRANAKNJIZENJADataTable table = (STRANAKNJIZENJADataSet.STRANAKNJIZENJADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public STRANAKNJIZENJADataSet.STRANAKNJIZENJARow FindByIDSTRANA(int iDSTRANA)
            {
                return (STRANAKNJIZENJADataSet.STRANAKNJIZENJARow) this.Rows.Find(new object[] { iDSTRANA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(STRANAKNJIZENJADataSet.STRANAKNJIZENJARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                STRANAKNJIZENJADataSet set = new STRANAKNJIZENJADataSet();
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
                this.columnIDSTRANA = new DataColumn("IDSTRANA", typeof(int), "", MappingType.Element);
                this.columnIDSTRANA.AllowDBNull = false;
                this.columnIDSTRANA.Caption = "Šifra strane";
                this.columnIDSTRANA.Unique = true;
                this.columnIDSTRANA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSTRANA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSTRANA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSTRANA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSTRANA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSTRANA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSTRANA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSTRANA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSTRANA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSTRANA.ExtendedProperties.Add("Description", "Šifra strane");
                this.columnIDSTRANA.ExtendedProperties.Add("Length", "5");
                this.columnIDSTRANA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSTRANA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSTRANA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSTRANA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSTRANA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSTRANA.ExtendedProperties.Add("Deklarit.InternalName", "IDSTRANA");
                this.Columns.Add(this.columnIDSTRANA);
                this.columnNAZIVSTRANE = new DataColumn("NAZIVSTRANE", typeof(string), "", MappingType.Element);
                this.columnNAZIVSTRANE.AllowDBNull = false;
                this.columnNAZIVSTRANE.Caption = "Naziv strane knjizenja";
                this.columnNAZIVSTRANE.MaxLength = 50;
                this.columnNAZIVSTRANE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVSTRANE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("Description", "Naziv strane knjizenja");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVSTRANE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVSTRANE");
                this.Columns.Add(this.columnNAZIVSTRANE);
                this.PrimaryKey = new DataColumn[] { this.columnIDSTRANA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "STRANAKNJIZENJA");
                this.ExtendedProperties.Add("Description", "Strane knjizenja");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDSTRANA = this.Columns["IDSTRANA"];
                this.columnNAZIVSTRANE = this.Columns["NAZIVSTRANE"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new STRANAKNJIZENJADataSet.STRANAKNJIZENJARow(builder);
            }

            public STRANAKNJIZENJADataSet.STRANAKNJIZENJARow NewSTRANAKNJIZENJARow()
            {
                return (STRANAKNJIZENJADataSet.STRANAKNJIZENJARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.STRANAKNJIZENJARowChanged != null)
                {
                    STRANAKNJIZENJADataSet.STRANAKNJIZENJARowChangeEventHandler sTRANAKNJIZENJARowChangedEvent = this.STRANAKNJIZENJARowChanged;
                    if (sTRANAKNJIZENJARowChangedEvent != null)
                    {
                        sTRANAKNJIZENJARowChangedEvent(this, new STRANAKNJIZENJADataSet.STRANAKNJIZENJARowChangeEvent((STRANAKNJIZENJADataSet.STRANAKNJIZENJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.STRANAKNJIZENJARowChanging != null)
                {
                    STRANAKNJIZENJADataSet.STRANAKNJIZENJARowChangeEventHandler sTRANAKNJIZENJARowChangingEvent = this.STRANAKNJIZENJARowChanging;
                    if (sTRANAKNJIZENJARowChangingEvent != null)
                    {
                        sTRANAKNJIZENJARowChangingEvent(this, new STRANAKNJIZENJADataSet.STRANAKNJIZENJARowChangeEvent((STRANAKNJIZENJADataSet.STRANAKNJIZENJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.STRANAKNJIZENJARowDeleted != null)
                {
                    STRANAKNJIZENJADataSet.STRANAKNJIZENJARowChangeEventHandler sTRANAKNJIZENJARowDeletedEvent = this.STRANAKNJIZENJARowDeleted;
                    if (sTRANAKNJIZENJARowDeletedEvent != null)
                    {
                        sTRANAKNJIZENJARowDeletedEvent(this, new STRANAKNJIZENJADataSet.STRANAKNJIZENJARowChangeEvent((STRANAKNJIZENJADataSet.STRANAKNJIZENJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.STRANAKNJIZENJARowDeleting != null)
                {
                    STRANAKNJIZENJADataSet.STRANAKNJIZENJARowChangeEventHandler sTRANAKNJIZENJARowDeletingEvent = this.STRANAKNJIZENJARowDeleting;
                    if (sTRANAKNJIZENJARowDeletingEvent != null)
                    {
                        sTRANAKNJIZENJARowDeletingEvent(this, new STRANAKNJIZENJADataSet.STRANAKNJIZENJARowChangeEvent((STRANAKNJIZENJADataSet.STRANAKNJIZENJARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSTRANAKNJIZENJARow(STRANAKNJIZENJADataSet.STRANAKNJIZENJARow row)
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

            public DataColumn IDSTRANAColumn
            {
                get
                {
                    return this.columnIDSTRANA;
                }
            }

            public STRANAKNJIZENJADataSet.STRANAKNJIZENJARow this[int index]
            {
                get
                {
                    return (STRANAKNJIZENJADataSet.STRANAKNJIZENJARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVSTRANEColumn
            {
                get
                {
                    return this.columnNAZIVSTRANE;
                }
            }
        }

        public class STRANAKNJIZENJARow : DataRow
        {
            private STRANAKNJIZENJADataSet.STRANAKNJIZENJADataTable tableSTRANAKNJIZENJA;

            internal STRANAKNJIZENJARow(DataRowBuilder rb) : base(rb)
            {
                this.tableSTRANAKNJIZENJA = (STRANAKNJIZENJADataSet.STRANAKNJIZENJADataTable) this.Table;
            }

            public bool IsIDSTRANANull()
            {
                return this.IsNull(this.tableSTRANAKNJIZENJA.IDSTRANAColumn);
            }

            public bool IsNAZIVSTRANENull()
            {
                return this.IsNull(this.tableSTRANAKNJIZENJA.NAZIVSTRANEColumn);
            }

            public void SetNAZIVSTRANENull()
            {
                this[this.tableSTRANAKNJIZENJA.NAZIVSTRANEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSTRANA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSTRANAKNJIZENJA.IDSTRANAColumn]);
                }
                set
                {
                    this[this.tableSTRANAKNJIZENJA.IDSTRANAColumn] = value;
                }
            }

            public string NAZIVSTRANE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSTRANAKNJIZENJA.NAZIVSTRANEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVSTRANE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableSTRANAKNJIZENJA.NAZIVSTRANEColumn] = value;
                }
            }
        }

        public class STRANAKNJIZENJARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private STRANAKNJIZENJADataSet.STRANAKNJIZENJARow eventRow;

            public STRANAKNJIZENJARowChangeEvent(STRANAKNJIZENJADataSet.STRANAKNJIZENJARow row, DataRowAction action)
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

            public STRANAKNJIZENJADataSet.STRANAKNJIZENJARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void STRANAKNJIZENJARowChangeEventHandler(object sender, STRANAKNJIZENJADataSet.STRANAKNJIZENJARowChangeEvent e);
    }
}

