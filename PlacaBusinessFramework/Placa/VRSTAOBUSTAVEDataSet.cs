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
    public class VRSTAOBUSTAVEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private VRSTEOBUSTAVADataTable tableVRSTEOBUSTAVA;

        public VRSTAOBUSTAVEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected VRSTAOBUSTAVEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["VRSTEOBUSTAVA"] != null)
                    {
                        this.Tables.Add(new VRSTEOBUSTAVADataTable(dataSet.Tables["VRSTEOBUSTAVA"]));
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
            VRSTAOBUSTAVEDataSet set = (VRSTAOBUSTAVEDataSet) base.Clone();
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
            VRSTAOBUSTAVEDataSet set = new VRSTAOBUSTAVEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "VRSTAOBUSTAVEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2001");
            this.ExtendedProperties.Add("DataSetName", "VRSTAOBUSTAVEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IVRSTAOBUSTAVEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "VRSTAOBUSTAVE");
            this.ExtendedProperties.Add("ObjectDescription", "Vrste obustava");
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
            this.DataSetName = "VRSTAOBUSTAVEDataSet";
            this.Namespace = "http://www.tempuri.org/VRSTAOBUSTAVE";
            this.tableVRSTEOBUSTAVA = new VRSTEOBUSTAVADataTable();
            this.Tables.Add(this.tableVRSTEOBUSTAVA);
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
            this.tableVRSTEOBUSTAVA = (VRSTEOBUSTAVADataTable) this.Tables["VRSTEOBUSTAVA"];
            if (initTable && (this.tableVRSTEOBUSTAVA != null))
            {
                this.tableVRSTEOBUSTAVA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["VRSTEOBUSTAVA"] != null)
                {
                    this.Tables.Add(new VRSTEOBUSTAVADataTable(dataSet.Tables["VRSTEOBUSTAVA"]));
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

        private bool ShouldSerializeVRSTEOBUSTAVA()
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
        public VRSTEOBUSTAVADataTable VRSTEOBUSTAVA
        {
            get
            {
                return this.tableVRSTEOBUSTAVA;
            }
        }

        [Serializable]
        public class VRSTEOBUSTAVADataTable : DataTable, IEnumerable
        {
            private DataColumn columnNAZIVVRSTAOBUSTAVE;
            private DataColumn columnVRSTAOBUSTAVE;

            public event VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARowChangeEventHandler VRSTEOBUSTAVARowChanged;

            public event VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARowChangeEventHandler VRSTEOBUSTAVARowChanging;

            public event VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARowChangeEventHandler VRSTEOBUSTAVARowDeleted;

            public event VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARowChangeEventHandler VRSTEOBUSTAVARowDeleting;

            public VRSTEOBUSTAVADataTable()
            {
                this.TableName = "VRSTEOBUSTAVA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal VRSTEOBUSTAVADataTable(DataTable table) : base(table.TableName)
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

            protected VRSTEOBUSTAVADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddVRSTEOBUSTAVARow(VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow row)
            {
                this.Rows.Add(row);
            }

            public VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow AddVRSTEOBUSTAVARow(short vRSTAOBUSTAVE, string nAZIVVRSTAOBUSTAVE)
            {
                VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow row = (VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow) this.NewRow();
                row["VRSTAOBUSTAVE"] = vRSTAOBUSTAVE;
                row["NAZIVVRSTAOBUSTAVE"] = nAZIVVRSTAOBUSTAVE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVADataTable table = (VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow FindByVRSTAOBUSTAVE(short vRSTAOBUSTAVE)
            {
                return (VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow) this.Rows.Find(new object[] { vRSTAOBUSTAVE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                VRSTAOBUSTAVEDataSet set = new VRSTAOBUSTAVEDataSet();
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
                this.columnVRSTAOBUSTAVE = new DataColumn("VRSTAOBUSTAVE", typeof(short), "", MappingType.Element);
                this.columnVRSTAOBUSTAVE.AllowDBNull = false;
                this.columnVRSTAOBUSTAVE.Caption = "Vrsta obustave";
                this.columnVRSTAOBUSTAVE.Unique = true;
                this.columnVRSTAOBUSTAVE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("IsKey", "true");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Description", "Šifra");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Length", "2");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Decimals", "0");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("IsInReader", "true");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "VRSTAOBUSTAVE");
                this.Columns.Add(this.columnVRSTAOBUSTAVE);
                this.columnNAZIVVRSTAOBUSTAVE = new DataColumn("NAZIVVRSTAOBUSTAVE", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTAOBUSTAVE.AllowDBNull = false;
                this.columnNAZIVVRSTAOBUSTAVE.Caption = "Opis vrste obustave";
                this.columnNAZIVVRSTAOBUSTAVE.MaxLength = 50;
                this.columnNAZIVVRSTAOBUSTAVE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Description", "Vrsta obustave");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTAOBUSTAVE");
                this.Columns.Add(this.columnNAZIVVRSTAOBUSTAVE);
                this.PrimaryKey = new DataColumn[] { this.columnVRSTAOBUSTAVE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "VRSTAOBUSTAVE");
                this.ExtendedProperties.Add("Description", "Vrste obustava");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnVRSTAOBUSTAVE = this.Columns["VRSTAOBUSTAVE"];
                this.columnNAZIVVRSTAOBUSTAVE = this.Columns["NAZIVVRSTAOBUSTAVE"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow(builder);
            }

            public VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow NewVRSTEOBUSTAVARow()
            {
                return (VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VRSTEOBUSTAVARowChanged != null)
                {
                    VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARowChangeEventHandler vRSTEOBUSTAVARowChangedEvent = this.VRSTEOBUSTAVARowChanged;
                    if (vRSTEOBUSTAVARowChangedEvent != null)
                    {
                        vRSTEOBUSTAVARowChangedEvent(this, new VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARowChangeEvent((VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VRSTEOBUSTAVARowChanging != null)
                {
                    VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARowChangeEventHandler vRSTEOBUSTAVARowChangingEvent = this.VRSTEOBUSTAVARowChanging;
                    if (vRSTEOBUSTAVARowChangingEvent != null)
                    {
                        vRSTEOBUSTAVARowChangingEvent(this, new VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARowChangeEvent((VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VRSTEOBUSTAVARowDeleted != null)
                {
                    VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARowChangeEventHandler vRSTEOBUSTAVARowDeletedEvent = this.VRSTEOBUSTAVARowDeleted;
                    if (vRSTEOBUSTAVARowDeletedEvent != null)
                    {
                        vRSTEOBUSTAVARowDeletedEvent(this, new VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARowChangeEvent((VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VRSTEOBUSTAVARowDeleting != null)
                {
                    VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARowChangeEventHandler vRSTEOBUSTAVARowDeletingEvent = this.VRSTEOBUSTAVARowDeleting;
                    if (vRSTEOBUSTAVARowDeletingEvent != null)
                    {
                        vRSTEOBUSTAVARowDeletingEvent(this, new VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARowChangeEvent((VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveVRSTEOBUSTAVARow(VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow row)
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

            public VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow this[int index]
            {
                get
                {
                    return (VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVVRSTAOBUSTAVEColumn
            {
                get
                {
                    return this.columnNAZIVVRSTAOBUSTAVE;
                }
            }

            public DataColumn VRSTAOBUSTAVEColumn
            {
                get
                {
                    return this.columnVRSTAOBUSTAVE;
                }
            }
        }

        public class VRSTEOBUSTAVARow : DataRow
        {
            private VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVADataTable tableVRSTEOBUSTAVA;

            internal VRSTEOBUSTAVARow(DataRowBuilder rb) : base(rb)
            {
                this.tableVRSTEOBUSTAVA = (VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVADataTable) this.Table;
            }

            public bool IsNAZIVVRSTAOBUSTAVENull()
            {
                return this.IsNull(this.tableVRSTEOBUSTAVA.NAZIVVRSTAOBUSTAVEColumn);
            }

            public bool IsVRSTAOBUSTAVENull()
            {
                return this.IsNull(this.tableVRSTEOBUSTAVA.VRSTAOBUSTAVEColumn);
            }

            public void SetNAZIVVRSTAOBUSTAVENull()
            {
                this[this.tableVRSTEOBUSTAVA.NAZIVVRSTAOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string NAZIVVRSTAOBUSTAVE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVRSTEOBUSTAVA.NAZIVVRSTAOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVVRSTAOBUSTAVE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableVRSTEOBUSTAVA.NAZIVVRSTAOBUSTAVEColumn] = value;
                }
            }

            public short VRSTAOBUSTAVE
            {
                get
                {
                    return Conversions.ToShort(this[this.tableVRSTEOBUSTAVA.VRSTAOBUSTAVEColumn]);
                }
                set
                {
                    this[this.tableVRSTEOBUSTAVA.VRSTAOBUSTAVEColumn] = value;
                }
            }
        }

        public class VRSTEOBUSTAVARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow eventRow;

            public VRSTEOBUSTAVARowChangeEvent(VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow row, DataRowAction action)
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

            public VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void VRSTEOBUSTAVARowChangeEventHandler(object sender, VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARowChangeEvent e);
    }
}

