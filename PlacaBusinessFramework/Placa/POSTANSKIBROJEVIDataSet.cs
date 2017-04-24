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
    public class POSTANSKIBROJEVIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private POSTANSKIBROJEVIDataTable tablePOSTANSKIBROJEVI;

        public POSTANSKIBROJEVIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected POSTANSKIBROJEVIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["POSTANSKIBROJEVI"] != null)
                    {
                        this.Tables.Add(new POSTANSKIBROJEVIDataTable(dataSet.Tables["POSTANSKIBROJEVI"]));
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
            POSTANSKIBROJEVIDataSet set = (POSTANSKIBROJEVIDataSet) base.Clone();
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
            POSTANSKIBROJEVIDataSet set = new POSTANSKIBROJEVIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "POSTANSKIBROJEVIDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2201");
            this.ExtendedProperties.Add("DataSetName", "POSTANSKIBROJEVIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IPOSTANSKIBROJEVIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "POSTANSKIBROJEVI");
            this.ExtendedProperties.Add("ObjectDescription", "POSTANSKIBROJEVI");
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
            this.DataSetName = "POSTANSKIBROJEVIDataSet";
            this.Namespace = "http://www.tempuri.org/POSTANSKIBROJEVI";
            this.tablePOSTANSKIBROJEVI = new POSTANSKIBROJEVIDataTable();
            this.Tables.Add(this.tablePOSTANSKIBROJEVI);
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
            this.tablePOSTANSKIBROJEVI = (POSTANSKIBROJEVIDataTable) this.Tables["POSTANSKIBROJEVI"];
            if (initTable && (this.tablePOSTANSKIBROJEVI != null))
            {
                this.tablePOSTANSKIBROJEVI.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["POSTANSKIBROJEVI"] != null)
                {
                    this.Tables.Add(new POSTANSKIBROJEVIDataTable(dataSet.Tables["POSTANSKIBROJEVI"]));
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

        private bool ShouldSerializePOSTANSKIBROJEVI()
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
        public POSTANSKIBROJEVIDataTable POSTANSKIBROJEVI
        {
            get
            {
                return this.tablePOSTANSKIBROJEVI;
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
        public class POSTANSKIBROJEVIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnNAZIVPOSTE;
            private DataColumn columnPOSTANSKIBROJ;

            public event POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRowChangeEventHandler POSTANSKIBROJEVIRowChanged;

            public event POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRowChangeEventHandler POSTANSKIBROJEVIRowChanging;

            public event POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRowChangeEventHandler POSTANSKIBROJEVIRowDeleted;

            public event POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRowChangeEventHandler POSTANSKIBROJEVIRowDeleting;

            public POSTANSKIBROJEVIDataTable()
            {
                this.TableName = "POSTANSKIBROJEVI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal POSTANSKIBROJEVIDataTable(DataTable table) : base(table.TableName)
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

            protected POSTANSKIBROJEVIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPOSTANSKIBROJEVIRow(POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow row)
            {
                this.Rows.Add(row);
            }

            public POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow AddPOSTANSKIBROJEVIRow(string pOSTANSKIBROJ, string nAZIVPOSTE)
            {
                POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow row = (POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow) this.NewRow();
                row["POSTANSKIBROJ"] = pOSTANSKIBROJ;
                row["NAZIVPOSTE"] = nAZIVPOSTE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIDataTable table = (POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow FindByPOSTANSKIBROJ(string pOSTANSKIBROJ)
            {
                return (POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow) this.Rows.Find(new object[] { pOSTANSKIBROJ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                POSTANSKIBROJEVIDataSet set = new POSTANSKIBROJEVIDataSet();
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
                this.columnPOSTANSKIBROJ = new DataColumn("POSTANSKIBROJ", typeof(string), "", MappingType.Element);
                this.columnPOSTANSKIBROJ.AllowDBNull = false;
                this.columnPOSTANSKIBROJ.Caption = "POSTANSKIBROJ";
                this.columnPOSTANSKIBROJ.MaxLength = 5;
                this.columnPOSTANSKIBROJ.Unique = true;
                this.columnPOSTANSKIBROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("IsKey", "true");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Description", "Poštanski broj");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Length", "5");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOSTANSKIBROJ.ExtendedProperties.Add("Deklarit.InternalName", "POSTANSKIBROJ");
                this.Columns.Add(this.columnPOSTANSKIBROJ);
                this.columnNAZIVPOSTE = new DataColumn("NAZIVPOSTE", typeof(string), "", MappingType.Element);
                this.columnNAZIVPOSTE.AllowDBNull = false;
                this.columnNAZIVPOSTE.Caption = "NAZIVPOSTE";
                this.columnNAZIVPOSTE.MaxLength = 50;
                this.columnNAZIVPOSTE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Description", "Naziv pošte");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPOSTE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPOSTE");
                this.Columns.Add(this.columnNAZIVPOSTE);
                this.PrimaryKey = new DataColumn[] { this.columnPOSTANSKIBROJ };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "POSTANSKIBROJEVI");
                this.ExtendedProperties.Add("Description", "POSTANSKIBROJEVI");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnPOSTANSKIBROJ = this.Columns["POSTANSKIBROJ"];
                this.columnNAZIVPOSTE = this.Columns["NAZIVPOSTE"];
            }

            public POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow NewPOSTANSKIBROJEVIRow()
            {
                return (POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.POSTANSKIBROJEVIRowChanged != null)
                {
                    POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRowChangeEventHandler pOSTANSKIBROJEVIRowChangedEvent = this.POSTANSKIBROJEVIRowChanged;
                    if (pOSTANSKIBROJEVIRowChangedEvent != null)
                    {
                        pOSTANSKIBROJEVIRowChangedEvent(this, new POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRowChangeEvent((POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.POSTANSKIBROJEVIRowChanging != null)
                {
                    POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRowChangeEventHandler pOSTANSKIBROJEVIRowChangingEvent = this.POSTANSKIBROJEVIRowChanging;
                    if (pOSTANSKIBROJEVIRowChangingEvent != null)
                    {
                        pOSTANSKIBROJEVIRowChangingEvent(this, new POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRowChangeEvent((POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.POSTANSKIBROJEVIRowDeleted != null)
                {
                    POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRowChangeEventHandler pOSTANSKIBROJEVIRowDeletedEvent = this.POSTANSKIBROJEVIRowDeleted;
                    if (pOSTANSKIBROJEVIRowDeletedEvent != null)
                    {
                        pOSTANSKIBROJEVIRowDeletedEvent(this, new POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRowChangeEvent((POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.POSTANSKIBROJEVIRowDeleting != null)
                {
                    POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRowChangeEventHandler pOSTANSKIBROJEVIRowDeletingEvent = this.POSTANSKIBROJEVIRowDeleting;
                    if (pOSTANSKIBROJEVIRowDeletingEvent != null)
                    {
                        pOSTANSKIBROJEVIRowDeletingEvent(this, new POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRowChangeEvent((POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePOSTANSKIBROJEVIRow(POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow row)
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

            public POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow this[int index]
            {
                get
                {
                    return (POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVPOSTEColumn
            {
                get
                {
                    return this.columnNAZIVPOSTE;
                }
            }

            public DataColumn POSTANSKIBROJColumn
            {
                get
                {
                    return this.columnPOSTANSKIBROJ;
                }
            }
        }

        public class POSTANSKIBROJEVIRow : DataRow
        {
            private POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIDataTable tablePOSTANSKIBROJEVI;

            internal POSTANSKIBROJEVIRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePOSTANSKIBROJEVI = (POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIDataTable) this.Table;
            }

            public bool IsNAZIVPOSTENull()
            {
                return this.IsNull(this.tablePOSTANSKIBROJEVI.NAZIVPOSTEColumn);
            }

            public bool IsPOSTANSKIBROJNull()
            {
                return this.IsNull(this.tablePOSTANSKIBROJEVI.POSTANSKIBROJColumn);
            }

            public void SetNAZIVPOSTENull()
            {
                this[this.tablePOSTANSKIBROJEVI.NAZIVPOSTEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string NAZIVPOSTE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePOSTANSKIBROJEVI.NAZIVPOSTEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVPOSTE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablePOSTANSKIBROJEVI.NAZIVPOSTEColumn] = value;
                }
            }

            public string POSTANSKIBROJ
            {
                get
                {
                    return Conversions.ToString(this[this.tablePOSTANSKIBROJEVI.POSTANSKIBROJColumn]);
                }
                set
                {
                    this[this.tablePOSTANSKIBROJEVI.POSTANSKIBROJColumn] = value;
                }
            }
        }

        public class POSTANSKIBROJEVIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow eventRow;

            public POSTANSKIBROJEVIRowChangeEvent(POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow row, DataRowAction action)
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

            public POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void POSTANSKIBROJEVIRowChangeEventHandler(object sender, POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRowChangeEvent e);
    }
}

