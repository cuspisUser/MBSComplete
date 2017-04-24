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
    public class GODINEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private GODINEDataTable tableGODINE;

        public GODINEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected GODINEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["GODINE"] != null)
                    {
                        this.Tables.Add(new GODINEDataTable(dataSet.Tables["GODINE"]));
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
            GODINEDataSet set = (GODINEDataSet) base.Clone();
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
            GODINEDataSet set = new GODINEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "GODINEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2032");
            this.ExtendedProperties.Add("DataSetName", "GODINEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IGODINEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "GODINE");
            this.ExtendedProperties.Add("ObjectDescription", "GODINE");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Finpos");
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
            this.DataSetName = "GODINEDataSet";
            this.Namespace = "http://www.tempuri.org/GODINE";
            this.tableGODINE = new GODINEDataTable();
            this.Tables.Add(this.tableGODINE);
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
            this.tableGODINE = (GODINEDataTable) this.Tables["GODINE"];
            if (initTable && (this.tableGODINE != null))
            {
                this.tableGODINE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["GODINE"] != null)
                {
                    this.Tables.Add(new GODINEDataTable(dataSet.Tables["GODINE"]));
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

        private bool ShouldSerializeGODINE()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GODINEDataTable GODINE
        {
            get
            {
                return this.tableGODINE;
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
        public class GODINEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnGODINEAKTIVNA;
            private DataColumn columnIDGODINE;

            public event GODINEDataSet.GODINERowChangeEventHandler GODINERowChanged;

            public event GODINEDataSet.GODINERowChangeEventHandler GODINERowChanging;

            public event GODINEDataSet.GODINERowChangeEventHandler GODINERowDeleted;

            public event GODINEDataSet.GODINERowChangeEventHandler GODINERowDeleting;

            public GODINEDataTable()
            {
                this.TableName = "GODINE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal GODINEDataTable(DataTable table) : base(table.TableName)
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

            protected GODINEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddGODINERow(GODINEDataSet.GODINERow row)
            {
                this.Rows.Add(row);
            }

            public GODINEDataSet.GODINERow AddGODINERow(short iDGODINE, bool gODINEAKTIVNA)
            {
                GODINEDataSet.GODINERow row = (GODINEDataSet.GODINERow) this.NewRow();
                row["IDGODINE"] = iDGODINE;
                row["GODINEAKTIVNA"] = gODINEAKTIVNA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                GODINEDataSet.GODINEDataTable table = (GODINEDataSet.GODINEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public GODINEDataSet.GODINERow FindByIDGODINE(short iDGODINE)
            {
                return (GODINEDataSet.GODINERow) this.Rows.Find(new object[] { iDGODINE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(GODINEDataSet.GODINERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                GODINEDataSet set = new GODINEDataSet();
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
                this.columnIDGODINE = new DataColumn("IDGODINE", typeof(short), "", MappingType.Element);
                this.columnIDGODINE.AllowDBNull = false;
                this.columnIDGODINE.Caption = "IDGODINE";
                this.columnIDGODINE.Unique = true;
                this.columnIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDGODINE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDGODINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDGODINE.ExtendedProperties.Add("Description", "Godina");
                this.columnIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "IDGODINE");
                this.Columns.Add(this.columnIDGODINE);
                this.columnGODINEAKTIVNA = new DataColumn("GODINEAKTIVNA", typeof(bool), "", MappingType.Element);
                this.columnGODINEAKTIVNA.AllowDBNull = false;
                this.columnGODINEAKTIVNA.Caption = "GODINEAKTIVNA";
                this.columnGODINEAKTIVNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("Description", "Aktivna");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("Length", "1");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINEAKTIVNA.ExtendedProperties.Add("Deklarit.InternalName", "GODINEAKTIVNA");
                this.Columns.Add(this.columnGODINEAKTIVNA);
                this.PrimaryKey = new DataColumn[] { this.columnIDGODINE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "GODINE");
                this.ExtendedProperties.Add("Description", "GODINE");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDGODINE = this.Columns["IDGODINE"];
                this.columnGODINEAKTIVNA = this.Columns["GODINEAKTIVNA"];
            }

            public GODINEDataSet.GODINERow NewGODINERow()
            {
                return (GODINEDataSet.GODINERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new GODINEDataSet.GODINERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.GODINERowChanged != null)
                {
                    GODINEDataSet.GODINERowChangeEventHandler gODINERowChangedEvent = this.GODINERowChanged;
                    if (gODINERowChangedEvent != null)
                    {
                        gODINERowChangedEvent(this, new GODINEDataSet.GODINERowChangeEvent((GODINEDataSet.GODINERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.GODINERowChanging != null)
                {
                    GODINEDataSet.GODINERowChangeEventHandler gODINERowChangingEvent = this.GODINERowChanging;
                    if (gODINERowChangingEvent != null)
                    {
                        gODINERowChangingEvent(this, new GODINEDataSet.GODINERowChangeEvent((GODINEDataSet.GODINERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.GODINERowDeleted != null)
                {
                    GODINEDataSet.GODINERowChangeEventHandler gODINERowDeletedEvent = this.GODINERowDeleted;
                    if (gODINERowDeletedEvent != null)
                    {
                        gODINERowDeletedEvent(this, new GODINEDataSet.GODINERowChangeEvent((GODINEDataSet.GODINERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.GODINERowDeleting != null)
                {
                    GODINEDataSet.GODINERowChangeEventHandler gODINERowDeletingEvent = this.GODINERowDeleting;
                    if (gODINERowDeletingEvent != null)
                    {
                        gODINERowDeletingEvent(this, new GODINEDataSet.GODINERowChangeEvent((GODINEDataSet.GODINERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveGODINERow(GODINEDataSet.GODINERow row)
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

            public DataColumn GODINEAKTIVNAColumn
            {
                get
                {
                    return this.columnGODINEAKTIVNA;
                }
            }

            public DataColumn IDGODINEColumn
            {
                get
                {
                    return this.columnIDGODINE;
                }
            }

            public GODINEDataSet.GODINERow this[int index]
            {
                get
                {
                    return (GODINEDataSet.GODINERow) this.Rows[index];
                }
            }
        }

        public class GODINERow : DataRow
        {
            private GODINEDataSet.GODINEDataTable tableGODINE;

            internal GODINERow(DataRowBuilder rb) : base(rb)
            {
                this.tableGODINE = (GODINEDataSet.GODINEDataTable) this.Table;
            }

            public bool IsGODINEAKTIVNANull()
            {
                return this.IsNull(this.tableGODINE.GODINEAKTIVNAColumn);
            }

            public bool IsIDGODINENull()
            {
                return this.IsNull(this.tableGODINE.IDGODINEColumn);
            }

            public void SetGODINEAKTIVNANull()
            {
                this[this.tableGODINE.GODINEAKTIVNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool GODINEAKTIVNA
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableGODINE.GODINEAKTIVNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value GODINEAKTIVNA because it is DBNull.", innerException);
                    }
                    return flag;
                }
                set
                {
                    this[this.tableGODINE.GODINEAKTIVNAColumn] = value;
                }
            }

            public short IDGODINE
            {
                get
                {
                    return Conversions.ToShort(this[this.tableGODINE.IDGODINEColumn]);
                }
                set
                {
                    this[this.tableGODINE.IDGODINEColumn] = value;
                }
            }
        }

        public class GODINERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private GODINEDataSet.GODINERow eventRow;

            public GODINERowChangeEvent(GODINEDataSet.GODINERow row, DataRowAction action)
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

            public GODINEDataSet.GODINERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void GODINERowChangeEventHandler(object sender, GODINEDataSet.GODINERowChangeEvent e);
    }
}

