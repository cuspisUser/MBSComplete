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
    public class VRSTADOPRINOSDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private VRSTADOPRINOSDataTable tableVRSTADOPRINOS;

        public VRSTADOPRINOSDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected VRSTADOPRINOSDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["VRSTADOPRINOS"] != null)
                    {
                        this.Tables.Add(new VRSTADOPRINOSDataTable(dataSet.Tables["VRSTADOPRINOS"]));
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
            VRSTADOPRINOSDataSet set = (VRSTADOPRINOSDataSet) base.Clone();
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
            VRSTADOPRINOSDataSet set = new VRSTADOPRINOSDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "VRSTADOPRINOSDataAdapter");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1030");
            this.ExtendedProperties.Add("DataSetName", "VRSTADOPRINOSDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IVRSTADOPRINOSDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "VRSTADOPRINOS");
            this.ExtendedProperties.Add("ObjectDescription", "Vrste doprinosa");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
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
            this.DataSetName = "VRSTADOPRINOSDataSet";
            this.Namespace = "http://www.tempuri.org/VRSTADOPRINOS";
            this.tableVRSTADOPRINOS = new VRSTADOPRINOSDataTable();
            this.Tables.Add(this.tableVRSTADOPRINOS);
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
            this.tableVRSTADOPRINOS = (VRSTADOPRINOSDataTable) this.Tables["VRSTADOPRINOS"];
            if (initTable && (this.tableVRSTADOPRINOS != null))
            {
                this.tableVRSTADOPRINOS.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["VRSTADOPRINOS"] != null)
                {
                    this.Tables.Add(new VRSTADOPRINOSDataTable(dataSet.Tables["VRSTADOPRINOS"]));
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

        private bool ShouldSerializeVRSTADOPRINOS()
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
        public VRSTADOPRINOSDataTable VRSTADOPRINOS
        {
            get
            {
                return this.tableVRSTADOPRINOS;
            }
        }

        [Serializable]
        public class VRSTADOPRINOSDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDVRSTADOPRINOS;
            private DataColumn columnNAZIVVRSTADOPRINOS;

            public event VRSTADOPRINOSDataSet.VRSTADOPRINOSRowChangeEventHandler VRSTADOPRINOSRowChanged;

            public event VRSTADOPRINOSDataSet.VRSTADOPRINOSRowChangeEventHandler VRSTADOPRINOSRowChanging;

            public event VRSTADOPRINOSDataSet.VRSTADOPRINOSRowChangeEventHandler VRSTADOPRINOSRowDeleted;

            public event VRSTADOPRINOSDataSet.VRSTADOPRINOSRowChangeEventHandler VRSTADOPRINOSRowDeleting;

            public VRSTADOPRINOSDataTable()
            {
                this.TableName = "VRSTADOPRINOS";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal VRSTADOPRINOSDataTable(DataTable table) : base(table.TableName)
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

            protected VRSTADOPRINOSDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddVRSTADOPRINOSRow(VRSTADOPRINOSDataSet.VRSTADOPRINOSRow row)
            {
                this.Rows.Add(row);
            }

            public VRSTADOPRINOSDataSet.VRSTADOPRINOSRow AddVRSTADOPRINOSRow(int iDVRSTADOPRINOS, string nAZIVVRSTADOPRINOS)
            {
                VRSTADOPRINOSDataSet.VRSTADOPRINOSRow row = (VRSTADOPRINOSDataSet.VRSTADOPRINOSRow) this.NewRow();
                row["IDVRSTADOPRINOS"] = iDVRSTADOPRINOS;
                row["NAZIVVRSTADOPRINOS"] = nAZIVVRSTADOPRINOS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                VRSTADOPRINOSDataSet.VRSTADOPRINOSDataTable table = (VRSTADOPRINOSDataSet.VRSTADOPRINOSDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public VRSTADOPRINOSDataSet.VRSTADOPRINOSRow FindByIDVRSTADOPRINOS(int iDVRSTADOPRINOS)
            {
                return (VRSTADOPRINOSDataSet.VRSTADOPRINOSRow) this.Rows.Find(new object[] { iDVRSTADOPRINOS });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(VRSTADOPRINOSDataSet.VRSTADOPRINOSRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                VRSTADOPRINOSDataSet set = new VRSTADOPRINOSDataSet();
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
                this.columnIDVRSTADOPRINOS = new DataColumn("IDVRSTADOPRINOS", typeof(int), "", MappingType.Element);
                this.columnIDVRSTADOPRINOS.AllowDBNull = false;
                this.columnIDVRSTADOPRINOS.Caption = "Šifra vrste doprinosa";
                this.columnIDVRSTADOPRINOS.Unique = true;
                this.columnIDVRSTADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("IsKey", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Description", "Šifra vrste doprinosa");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Length", "5");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "IDVRSTADOPRINOS");
                this.Columns.Add(this.columnIDVRSTADOPRINOS);
                this.columnNAZIVVRSTADOPRINOS = new DataColumn("NAZIVVRSTADOPRINOS", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTADOPRINOS.AllowDBNull = false;
                this.columnNAZIVVRSTADOPRINOS.Caption = "Naziv vrste doprinosa";
                this.columnNAZIVVRSTADOPRINOS.MaxLength = 50;
                this.columnNAZIVVRSTADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Description", "Naziv vrste doprinosa");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTADOPRINOS");
                this.Columns.Add(this.columnNAZIVVRSTADOPRINOS);
                this.PrimaryKey = new DataColumn[] { this.columnIDVRSTADOPRINOS };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "VRSTADOPRINOS");
                this.ExtendedProperties.Add("Description", "Vrste doprinosa");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDVRSTADOPRINOS = this.Columns["IDVRSTADOPRINOS"];
                this.columnNAZIVVRSTADOPRINOS = this.Columns["NAZIVVRSTADOPRINOS"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new VRSTADOPRINOSDataSet.VRSTADOPRINOSRow(builder);
            }

            public VRSTADOPRINOSDataSet.VRSTADOPRINOSRow NewVRSTADOPRINOSRow()
            {
                return (VRSTADOPRINOSDataSet.VRSTADOPRINOSRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VRSTADOPRINOSRowChanged != null)
                {
                    VRSTADOPRINOSDataSet.VRSTADOPRINOSRowChangeEventHandler vRSTADOPRINOSRowChangedEvent = this.VRSTADOPRINOSRowChanged;
                    if (vRSTADOPRINOSRowChangedEvent != null)
                    {
                        vRSTADOPRINOSRowChangedEvent(this, new VRSTADOPRINOSDataSet.VRSTADOPRINOSRowChangeEvent((VRSTADOPRINOSDataSet.VRSTADOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VRSTADOPRINOSRowChanging != null)
                {
                    VRSTADOPRINOSDataSet.VRSTADOPRINOSRowChangeEventHandler vRSTADOPRINOSRowChangingEvent = this.VRSTADOPRINOSRowChanging;
                    if (vRSTADOPRINOSRowChangingEvent != null)
                    {
                        vRSTADOPRINOSRowChangingEvent(this, new VRSTADOPRINOSDataSet.VRSTADOPRINOSRowChangeEvent((VRSTADOPRINOSDataSet.VRSTADOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VRSTADOPRINOSRowDeleted != null)
                {
                    VRSTADOPRINOSDataSet.VRSTADOPRINOSRowChangeEventHandler vRSTADOPRINOSRowDeletedEvent = this.VRSTADOPRINOSRowDeleted;
                    if (vRSTADOPRINOSRowDeletedEvent != null)
                    {
                        vRSTADOPRINOSRowDeletedEvent(this, new VRSTADOPRINOSDataSet.VRSTADOPRINOSRowChangeEvent((VRSTADOPRINOSDataSet.VRSTADOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VRSTADOPRINOSRowDeleting != null)
                {
                    VRSTADOPRINOSDataSet.VRSTADOPRINOSRowChangeEventHandler vRSTADOPRINOSRowDeletingEvent = this.VRSTADOPRINOSRowDeleting;
                    if (vRSTADOPRINOSRowDeletingEvent != null)
                    {
                        vRSTADOPRINOSRowDeletingEvent(this, new VRSTADOPRINOSDataSet.VRSTADOPRINOSRowChangeEvent((VRSTADOPRINOSDataSet.VRSTADOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveVRSTADOPRINOSRow(VRSTADOPRINOSDataSet.VRSTADOPRINOSRow row)
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

            public DataColumn IDVRSTADOPRINOSColumn
            {
                get
                {
                    return this.columnIDVRSTADOPRINOS;
                }
            }

            public VRSTADOPRINOSDataSet.VRSTADOPRINOSRow this[int index]
            {
                get
                {
                    return (VRSTADOPRINOSDataSet.VRSTADOPRINOSRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVVRSTADOPRINOSColumn
            {
                get
                {
                    return this.columnNAZIVVRSTADOPRINOS;
                }
            }
        }

        public class VRSTADOPRINOSRow : DataRow
        {
            private VRSTADOPRINOSDataSet.VRSTADOPRINOSDataTable tableVRSTADOPRINOS;

            internal VRSTADOPRINOSRow(DataRowBuilder rb) : base(rb)
            {
                this.tableVRSTADOPRINOS = (VRSTADOPRINOSDataSet.VRSTADOPRINOSDataTable) this.Table;
            }

            public bool IsIDVRSTADOPRINOSNull()
            {
                return this.IsNull(this.tableVRSTADOPRINOS.IDVRSTADOPRINOSColumn);
            }

            public bool IsNAZIVVRSTADOPRINOSNull()
            {
                return this.IsNull(this.tableVRSTADOPRINOS.NAZIVVRSTADOPRINOSColumn);
            }

            public void SetNAZIVVRSTADOPRINOSNull()
            {
                this[this.tableVRSTADOPRINOS.NAZIVVRSTADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDVRSTADOPRINOS
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableVRSTADOPRINOS.IDVRSTADOPRINOSColumn]);
                }
                set
                {
                    this[this.tableVRSTADOPRINOS.IDVRSTADOPRINOSColumn] = value;
                }
            }

            public string NAZIVVRSTADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVRSTADOPRINOS.NAZIVVRSTADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVVRSTADOPRINOS because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableVRSTADOPRINOS.NAZIVVRSTADOPRINOSColumn] = value;
                }
            }
        }

        public class VRSTADOPRINOSRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private VRSTADOPRINOSDataSet.VRSTADOPRINOSRow eventRow;

            public VRSTADOPRINOSRowChangeEvent(VRSTADOPRINOSDataSet.VRSTADOPRINOSRow row, DataRowAction action)
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

            public VRSTADOPRINOSDataSet.VRSTADOPRINOSRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void VRSTADOPRINOSRowChangeEventHandler(object sender, VRSTADOPRINOSDataSet.VRSTADOPRINOSRowChangeEvent e);
    }
}

