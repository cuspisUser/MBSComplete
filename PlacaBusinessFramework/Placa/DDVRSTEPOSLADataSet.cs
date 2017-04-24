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
    public class DDVRSTEPOSLADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private DDVRSTEPOSLADataTable tableDDVRSTEPOSLA;

        public DDVRSTEPOSLADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected DDVRSTEPOSLADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["DDVRSTEPOSLA"] != null)
                    {
                        this.Tables.Add(new DDVRSTEPOSLADataTable(dataSet.Tables["DDVRSTEPOSLA"]));
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
            DDVRSTEPOSLADataSet set = (DDVRSTEPOSLADataSet) base.Clone();
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
            DDVRSTEPOSLADataSet set = new DDVRSTEPOSLADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "DDVRSTEPOSLADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2089");
            this.ExtendedProperties.Add("DataSetName", "DDVRSTEPOSLADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IDDVRSTEPOSLADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "DDVRSTEPOSLA");
            this.ExtendedProperties.Add("ObjectDescription", "Vrste posla");
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
            this.DataSetName = "DDVRSTEPOSLADataSet";
            this.Namespace = "http://www.tempuri.org/DDVRSTEPOSLA";
            this.tableDDVRSTEPOSLA = new DDVRSTEPOSLADataTable();
            this.Tables.Add(this.tableDDVRSTEPOSLA);
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
            this.tableDDVRSTEPOSLA = (DDVRSTEPOSLADataTable) this.Tables["DDVRSTEPOSLA"];
            if (initTable && (this.tableDDVRSTEPOSLA != null))
            {
                this.tableDDVRSTEPOSLA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["DDVRSTEPOSLA"] != null)
                {
                    this.Tables.Add(new DDVRSTEPOSLADataTable(dataSet.Tables["DDVRSTEPOSLA"]));
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

        private bool ShouldSerializeDDVRSTEPOSLA()
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
        public DDVRSTEPOSLADataTable DDVRSTEPOSLA
        {
            get
            {
                return this.tableDDVRSTEPOSLA;
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
        public class DDVRSTEPOSLADataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDIDVRSTAPOSLA;
            private DataColumn columnDDNAZIVVRSTAPOSLA;

            public event DDVRSTEPOSLADataSet.DDVRSTEPOSLARowChangeEventHandler DDVRSTEPOSLARowChanged;

            public event DDVRSTEPOSLADataSet.DDVRSTEPOSLARowChangeEventHandler DDVRSTEPOSLARowChanging;

            public event DDVRSTEPOSLADataSet.DDVRSTEPOSLARowChangeEventHandler DDVRSTEPOSLARowDeleted;

            public event DDVRSTEPOSLADataSet.DDVRSTEPOSLARowChangeEventHandler DDVRSTEPOSLARowDeleting;

            public DDVRSTEPOSLADataTable()
            {
                this.TableName = "DDVRSTEPOSLA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDVRSTEPOSLADataTable(DataTable table) : base(table.TableName)
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

            protected DDVRSTEPOSLADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDVRSTEPOSLARow(DDVRSTEPOSLADataSet.DDVRSTEPOSLARow row)
            {
                this.Rows.Add(row);
            }

            public DDVRSTEPOSLADataSet.DDVRSTEPOSLARow AddDDVRSTEPOSLARow(int dDIDVRSTAPOSLA, string dDNAZIVVRSTAPOSLA)
            {
                DDVRSTEPOSLADataSet.DDVRSTEPOSLARow row = (DDVRSTEPOSLADataSet.DDVRSTEPOSLARow) this.NewRow();
                row["DDIDVRSTAPOSLA"] = dDIDVRSTAPOSLA;
                row["DDNAZIVVRSTAPOSLA"] = dDNAZIVVRSTAPOSLA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDVRSTEPOSLADataSet.DDVRSTEPOSLADataTable table = (DDVRSTEPOSLADataSet.DDVRSTEPOSLADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDVRSTEPOSLADataSet.DDVRSTEPOSLARow FindByDDIDVRSTAPOSLA(int dDIDVRSTAPOSLA)
            {
                return (DDVRSTEPOSLADataSet.DDVRSTEPOSLARow) this.Rows.Find(new object[] { dDIDVRSTAPOSLA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDVRSTEPOSLADataSet.DDVRSTEPOSLARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDVRSTEPOSLADataSet set = new DDVRSTEPOSLADataSet();
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
                this.columnDDIDVRSTAPOSLA = new DataColumn("DDIDVRSTAPOSLA", typeof(int), "", MappingType.Element);
                this.columnDDIDVRSTAPOSLA.AllowDBNull = false;
                this.columnDDIDVRSTAPOSLA.Caption = "Šifra";
                this.columnDDIDVRSTAPOSLA.Unique = true;
                this.columnDDIDVRSTAPOSLA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("IsKey", "true");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Description", "Šifra");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Length", "5");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.InternalName", "DDIDVRSTAPOSLA");
                this.Columns.Add(this.columnDDIDVRSTAPOSLA);
                this.columnDDNAZIVVRSTAPOSLA = new DataColumn("DDNAZIVVRSTAPOSLA", typeof(string), "", MappingType.Element);
                this.columnDDNAZIVVRSTAPOSLA.AllowDBNull = false;
                this.columnDDNAZIVVRSTAPOSLA.Caption = "DDNAZIVVRSTAPOSLA";
                this.columnDDNAZIVVRSTAPOSLA.MaxLength = 50;
                this.columnDDNAZIVVRSTAPOSLA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Description", "Naziv");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Length", "50");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Decimals", "0");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.InternalName", "DDNAZIVVRSTAPOSLA");
                this.Columns.Add(this.columnDDNAZIVVRSTAPOSLA);
                this.PrimaryKey = new DataColumn[] { this.columnDDIDVRSTAPOSLA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "DDVRSTEPOSLA");
                this.ExtendedProperties.Add("Description", "Vrste posla");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnDDIDVRSTAPOSLA = this.Columns["DDIDVRSTAPOSLA"];
                this.columnDDNAZIVVRSTAPOSLA = this.Columns["DDNAZIVVRSTAPOSLA"];
            }

            public DDVRSTEPOSLADataSet.DDVRSTEPOSLARow NewDDVRSTEPOSLARow()
            {
                return (DDVRSTEPOSLADataSet.DDVRSTEPOSLARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDVRSTEPOSLADataSet.DDVRSTEPOSLARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDVRSTEPOSLARowChanged != null)
                {
                    DDVRSTEPOSLADataSet.DDVRSTEPOSLARowChangeEventHandler dDVRSTEPOSLARowChangedEvent = this.DDVRSTEPOSLARowChanged;
                    if (dDVRSTEPOSLARowChangedEvent != null)
                    {
                        dDVRSTEPOSLARowChangedEvent(this, new DDVRSTEPOSLADataSet.DDVRSTEPOSLARowChangeEvent((DDVRSTEPOSLADataSet.DDVRSTEPOSLARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDVRSTEPOSLARowChanging != null)
                {
                    DDVRSTEPOSLADataSet.DDVRSTEPOSLARowChangeEventHandler dDVRSTEPOSLARowChangingEvent = this.DDVRSTEPOSLARowChanging;
                    if (dDVRSTEPOSLARowChangingEvent != null)
                    {
                        dDVRSTEPOSLARowChangingEvent(this, new DDVRSTEPOSLADataSet.DDVRSTEPOSLARowChangeEvent((DDVRSTEPOSLADataSet.DDVRSTEPOSLARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DDVRSTEPOSLARowDeleted != null)
                {
                    DDVRSTEPOSLADataSet.DDVRSTEPOSLARowChangeEventHandler dDVRSTEPOSLARowDeletedEvent = this.DDVRSTEPOSLARowDeleted;
                    if (dDVRSTEPOSLARowDeletedEvent != null)
                    {
                        dDVRSTEPOSLARowDeletedEvent(this, new DDVRSTEPOSLADataSet.DDVRSTEPOSLARowChangeEvent((DDVRSTEPOSLADataSet.DDVRSTEPOSLARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDVRSTEPOSLARowDeleting != null)
                {
                    DDVRSTEPOSLADataSet.DDVRSTEPOSLARowChangeEventHandler dDVRSTEPOSLARowDeletingEvent = this.DDVRSTEPOSLARowDeleting;
                    if (dDVRSTEPOSLARowDeletingEvent != null)
                    {
                        dDVRSTEPOSLARowDeletingEvent(this, new DDVRSTEPOSLADataSet.DDVRSTEPOSLARowChangeEvent((DDVRSTEPOSLADataSet.DDVRSTEPOSLARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDVRSTEPOSLARow(DDVRSTEPOSLADataSet.DDVRSTEPOSLARow row)
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

            public DataColumn DDIDVRSTAPOSLAColumn
            {
                get
                {
                    return this.columnDDIDVRSTAPOSLA;
                }
            }

            public DataColumn DDNAZIVVRSTAPOSLAColumn
            {
                get
                {
                    return this.columnDDNAZIVVRSTAPOSLA;
                }
            }

            public DDVRSTEPOSLADataSet.DDVRSTEPOSLARow this[int index]
            {
                get
                {
                    return (DDVRSTEPOSLADataSet.DDVRSTEPOSLARow) this.Rows[index];
                }
            }
        }

        public class DDVRSTEPOSLARow : DataRow
        {
            private DDVRSTEPOSLADataSet.DDVRSTEPOSLADataTable tableDDVRSTEPOSLA;

            internal DDVRSTEPOSLARow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDVRSTEPOSLA = (DDVRSTEPOSLADataSet.DDVRSTEPOSLADataTable) this.Table;
            }

            public bool IsDDIDVRSTAPOSLANull()
            {
                return this.IsNull(this.tableDDVRSTEPOSLA.DDIDVRSTAPOSLAColumn);
            }

            public bool IsDDNAZIVVRSTAPOSLANull()
            {
                return this.IsNull(this.tableDDVRSTEPOSLA.DDNAZIVVRSTAPOSLAColumn);
            }

            public void SetDDNAZIVVRSTAPOSLANull()
            {
                this[this.tableDDVRSTEPOSLA.DDNAZIVVRSTAPOSLAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int DDIDVRSTAPOSLA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDVRSTEPOSLA.DDIDVRSTAPOSLAColumn]);
                }
                set
                {
                    this[this.tableDDVRSTEPOSLA.DDIDVRSTAPOSLAColumn] = value;
                }
            }

            public string DDNAZIVVRSTAPOSLA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDVRSTEPOSLA.DDNAZIVVRSTAPOSLAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDNAZIVVRSTAPOSLA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDVRSTEPOSLA.DDNAZIVVRSTAPOSLAColumn] = value;
                }
            }
        }

        public class DDVRSTEPOSLARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDVRSTEPOSLADataSet.DDVRSTEPOSLARow eventRow;

            public DDVRSTEPOSLARowChangeEvent(DDVRSTEPOSLADataSet.DDVRSTEPOSLARow row, DataRowAction action)
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

            public DDVRSTEPOSLADataSet.DDVRSTEPOSLARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDVRSTEPOSLARowChangeEventHandler(object sender, DDVRSTEPOSLADataSet.DDVRSTEPOSLARowChangeEvent e);
    }
}

