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
    public class VRSTAELEMENTDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private VRSTAELEMENTDataTable tableVRSTAELEMENT;

        public VRSTAELEMENTDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected VRSTAELEMENTDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["VRSTAELEMENT"] != null)
                    {
                        this.Tables.Add(new VRSTAELEMENTDataTable(dataSet.Tables["VRSTAELEMENT"]));
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
            VRSTAELEMENTDataSet set = (VRSTAELEMENTDataSet) base.Clone();
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
            VRSTAELEMENTDataSet set = new VRSTAELEMENTDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "VRSTAELEMENTDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2009");
            this.ExtendedProperties.Add("DataSetName", "VRSTAELEMENTDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IVRSTAELEMENTDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "VRSTAELEMENT");
            this.ExtendedProperties.Add("ObjectDescription", "Vrste elementa");
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
            this.DataSetName = "VRSTAELEMENTDataSet";
            this.Namespace = "http://www.tempuri.org/VRSTAELEMENT";
            this.tableVRSTAELEMENT = new VRSTAELEMENTDataTable();
            this.Tables.Add(this.tableVRSTAELEMENT);
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
            this.tableVRSTAELEMENT = (VRSTAELEMENTDataTable) this.Tables["VRSTAELEMENT"];
            if (initTable && (this.tableVRSTAELEMENT != null))
            {
                this.tableVRSTAELEMENT.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["VRSTAELEMENT"] != null)
                {
                    this.Tables.Add(new VRSTAELEMENTDataTable(dataSet.Tables["VRSTAELEMENT"]));
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

        private bool ShouldSerializeVRSTAELEMENT()
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
        public VRSTAELEMENTDataTable VRSTAELEMENT
        {
            get
            {
                return this.tableVRSTAELEMENT;
            }
        }

        [Serializable]
        public class VRSTAELEMENTDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDVRSTAELEMENTA;
            private DataColumn columnNAZIVVRSTAELEMENT;

            public event VRSTAELEMENTDataSet.VRSTAELEMENTRowChangeEventHandler VRSTAELEMENTRowChanged;

            public event VRSTAELEMENTDataSet.VRSTAELEMENTRowChangeEventHandler VRSTAELEMENTRowChanging;

            public event VRSTAELEMENTDataSet.VRSTAELEMENTRowChangeEventHandler VRSTAELEMENTRowDeleted;

            public event VRSTAELEMENTDataSet.VRSTAELEMENTRowChangeEventHandler VRSTAELEMENTRowDeleting;

            public VRSTAELEMENTDataTable()
            {
                this.TableName = "VRSTAELEMENT";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal VRSTAELEMENTDataTable(DataTable table) : base(table.TableName)
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

            protected VRSTAELEMENTDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddVRSTAELEMENTRow(VRSTAELEMENTDataSet.VRSTAELEMENTRow row)
            {
                this.Rows.Add(row);
            }

            public VRSTAELEMENTDataSet.VRSTAELEMENTRow AddVRSTAELEMENTRow(short iDVRSTAELEMENTA, string nAZIVVRSTAELEMENT)
            {
                VRSTAELEMENTDataSet.VRSTAELEMENTRow row = (VRSTAELEMENTDataSet.VRSTAELEMENTRow) this.NewRow();
                row["IDVRSTAELEMENTA"] = iDVRSTAELEMENTA;
                row["NAZIVVRSTAELEMENT"] = nAZIVVRSTAELEMENT;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                VRSTAELEMENTDataSet.VRSTAELEMENTDataTable table = (VRSTAELEMENTDataSet.VRSTAELEMENTDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public VRSTAELEMENTDataSet.VRSTAELEMENTRow FindByIDVRSTAELEMENTA(short iDVRSTAELEMENTA)
            {
                return (VRSTAELEMENTDataSet.VRSTAELEMENTRow) this.Rows.Find(new object[] { iDVRSTAELEMENTA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(VRSTAELEMENTDataSet.VRSTAELEMENTRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                VRSTAELEMENTDataSet set = new VRSTAELEMENTDataSet();
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
                this.columnIDVRSTAELEMENTA = new DataColumn("IDVRSTAELEMENTA", typeof(short), "", MappingType.Element);
                this.columnIDVRSTAELEMENTA.AllowDBNull = false;
                this.columnIDVRSTAELEMENTA.Caption = "Šifra Vrste elementa";
                this.columnIDVRSTAELEMENTA.Unique = true;
                this.columnIDVRSTAELEMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Description", "Šifra Vrste elementa");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Length", "4");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.InternalName", "IDVRSTAELEMENTA");
                this.Columns.Add(this.columnIDVRSTAELEMENTA);
                this.columnNAZIVVRSTAELEMENT = new DataColumn("NAZIVVRSTAELEMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTAELEMENT.AllowDBNull = false;
                this.columnNAZIVVRSTAELEMENT.Caption = "Naziv vrste elementa";
                this.columnNAZIVVRSTAELEMENT.MaxLength = 0x19;
                this.columnNAZIVVRSTAELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Description", "Naziv vrste elementa");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Length", "25");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTAELEMENT");
                this.Columns.Add(this.columnNAZIVVRSTAELEMENT);
                this.PrimaryKey = new DataColumn[] { this.columnIDVRSTAELEMENTA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "VRSTAELEMENT");
                this.ExtendedProperties.Add("Description", "Vrste elementa");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDVRSTAELEMENTA = this.Columns["IDVRSTAELEMENTA"];
                this.columnNAZIVVRSTAELEMENT = this.Columns["NAZIVVRSTAELEMENT"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new VRSTAELEMENTDataSet.VRSTAELEMENTRow(builder);
            }

            public VRSTAELEMENTDataSet.VRSTAELEMENTRow NewVRSTAELEMENTRow()
            {
                return (VRSTAELEMENTDataSet.VRSTAELEMENTRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VRSTAELEMENTRowChanged != null)
                {
                    VRSTAELEMENTDataSet.VRSTAELEMENTRowChangeEventHandler vRSTAELEMENTRowChangedEvent = this.VRSTAELEMENTRowChanged;
                    if (vRSTAELEMENTRowChangedEvent != null)
                    {
                        vRSTAELEMENTRowChangedEvent(this, new VRSTAELEMENTDataSet.VRSTAELEMENTRowChangeEvent((VRSTAELEMENTDataSet.VRSTAELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VRSTAELEMENTRowChanging != null)
                {
                    VRSTAELEMENTDataSet.VRSTAELEMENTRowChangeEventHandler vRSTAELEMENTRowChangingEvent = this.VRSTAELEMENTRowChanging;
                    if (vRSTAELEMENTRowChangingEvent != null)
                    {
                        vRSTAELEMENTRowChangingEvent(this, new VRSTAELEMENTDataSet.VRSTAELEMENTRowChangeEvent((VRSTAELEMENTDataSet.VRSTAELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VRSTAELEMENTRowDeleted != null)
                {
                    VRSTAELEMENTDataSet.VRSTAELEMENTRowChangeEventHandler vRSTAELEMENTRowDeletedEvent = this.VRSTAELEMENTRowDeleted;
                    if (vRSTAELEMENTRowDeletedEvent != null)
                    {
                        vRSTAELEMENTRowDeletedEvent(this, new VRSTAELEMENTDataSet.VRSTAELEMENTRowChangeEvent((VRSTAELEMENTDataSet.VRSTAELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VRSTAELEMENTRowDeleting != null)
                {
                    VRSTAELEMENTDataSet.VRSTAELEMENTRowChangeEventHandler vRSTAELEMENTRowDeletingEvent = this.VRSTAELEMENTRowDeleting;
                    if (vRSTAELEMENTRowDeletingEvent != null)
                    {
                        vRSTAELEMENTRowDeletingEvent(this, new VRSTAELEMENTDataSet.VRSTAELEMENTRowChangeEvent((VRSTAELEMENTDataSet.VRSTAELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveVRSTAELEMENTRow(VRSTAELEMENTDataSet.VRSTAELEMENTRow row)
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

            public DataColumn IDVRSTAELEMENTAColumn
            {
                get
                {
                    return this.columnIDVRSTAELEMENTA;
                }
            }

            public VRSTAELEMENTDataSet.VRSTAELEMENTRow this[int index]
            {
                get
                {
                    return (VRSTAELEMENTDataSet.VRSTAELEMENTRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVVRSTAELEMENTColumn
            {
                get
                {
                    return this.columnNAZIVVRSTAELEMENT;
                }
            }
        }

        public class VRSTAELEMENTRow : DataRow
        {
            private VRSTAELEMENTDataSet.VRSTAELEMENTDataTable tableVRSTAELEMENT;

            internal VRSTAELEMENTRow(DataRowBuilder rb) : base(rb)
            {
                this.tableVRSTAELEMENT = (VRSTAELEMENTDataSet.VRSTAELEMENTDataTable) this.Table;
            }

            public bool IsIDVRSTAELEMENTANull()
            {
                return this.IsNull(this.tableVRSTAELEMENT.IDVRSTAELEMENTAColumn);
            }

            public bool IsNAZIVVRSTAELEMENTNull()
            {
                return this.IsNull(this.tableVRSTAELEMENT.NAZIVVRSTAELEMENTColumn);
            }

            public void SetNAZIVVRSTAELEMENTNull()
            {
                this[this.tableVRSTAELEMENT.NAZIVVRSTAELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public short IDVRSTAELEMENTA
            {
                get
                {
                    return Conversions.ToShort(this[this.tableVRSTAELEMENT.IDVRSTAELEMENTAColumn]);
                }
                set
                {
                    this[this.tableVRSTAELEMENT.IDVRSTAELEMENTAColumn] = value;
                }
            }

            public string NAZIVVRSTAELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVRSTAELEMENT.NAZIVVRSTAELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVVRSTAELEMENT because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableVRSTAELEMENT.NAZIVVRSTAELEMENTColumn] = value;
                }
            }
        }

        public class VRSTAELEMENTRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private VRSTAELEMENTDataSet.VRSTAELEMENTRow eventRow;

            public VRSTAELEMENTRowChangeEvent(VRSTAELEMENTDataSet.VRSTAELEMENTRow row, DataRowAction action)
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

            public VRSTAELEMENTDataSet.VRSTAELEMENTRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void VRSTAELEMENTRowChangeEventHandler(object sender, VRSTAELEMENTDataSet.VRSTAELEMENTRowChangeEvent e);
    }
}

