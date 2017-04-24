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
    public class PLVRSTEIZNOSADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private PLVRSTEIZNOSADataTable tablePLVRSTEIZNOSA;

        public PLVRSTEIZNOSADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected PLVRSTEIZNOSADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["PLVRSTEIZNOSA"] != null)
                    {
                        this.Tables.Add(new PLVRSTEIZNOSADataTable(dataSet.Tables["PLVRSTEIZNOSA"]));
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
            PLVRSTEIZNOSADataSet set = (PLVRSTEIZNOSADataSet) base.Clone();
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
            PLVRSTEIZNOSADataSet set = new PLVRSTEIZNOSADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "PLVRSTEIZNOSADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2118");
            this.ExtendedProperties.Add("DataSetName", "PLVRSTEIZNOSADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IPLVRSTEIZNOSADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "PLVRSTEIZNOSA");
            this.ExtendedProperties.Add("ObjectDescription", "PLVRSTEIZNOSA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVPLVRSTEIZNOSA");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "PLVRSTEIZNOSADataSet";
            this.Namespace = "http://www.tempuri.org/PLVRSTEIZNOSA";
            this.tablePLVRSTEIZNOSA = new PLVRSTEIZNOSADataTable();
            this.Tables.Add(this.tablePLVRSTEIZNOSA);
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
            this.tablePLVRSTEIZNOSA = (PLVRSTEIZNOSADataTable) this.Tables["PLVRSTEIZNOSA"];
            if (initTable && (this.tablePLVRSTEIZNOSA != null))
            {
                this.tablePLVRSTEIZNOSA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["PLVRSTEIZNOSA"] != null)
                {
                    this.Tables.Add(new PLVRSTEIZNOSADataTable(dataSet.Tables["PLVRSTEIZNOSA"]));
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

        private bool ShouldSerializePLVRSTEIZNOSA()
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
        public PLVRSTEIZNOSADataTable PLVRSTEIZNOSA
        {
            get
            {
                return this.tablePLVRSTEIZNOSA;
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
        public class PLVRSTEIZNOSADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDPLVRSTEIZNOSA;
            private DataColumn columnNAZIVPLVRSTEIZNOSA;

            public event PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARowChangeEventHandler PLVRSTEIZNOSARowChanged;

            public event PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARowChangeEventHandler PLVRSTEIZNOSARowChanging;

            public event PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARowChangeEventHandler PLVRSTEIZNOSARowDeleted;

            public event PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARowChangeEventHandler PLVRSTEIZNOSARowDeleting;

            public PLVRSTEIZNOSADataTable()
            {
                this.TableName = "PLVRSTEIZNOSA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal PLVRSTEIZNOSADataTable(DataTable table) : base(table.TableName)
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

            protected PLVRSTEIZNOSADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPLVRSTEIZNOSARow(PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow row)
            {
                this.Rows.Add(row);
            }

            public PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow AddPLVRSTEIZNOSARow(int iDPLVRSTEIZNOSA, string nAZIVPLVRSTEIZNOSA)
            {
                PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow row = (PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow) this.NewRow();
                row["IDPLVRSTEIZNOSA"] = iDPLVRSTEIZNOSA;
                row["NAZIVPLVRSTEIZNOSA"] = nAZIVPLVRSTEIZNOSA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                PLVRSTEIZNOSADataSet.PLVRSTEIZNOSADataTable table = (PLVRSTEIZNOSADataSet.PLVRSTEIZNOSADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow FindByIDPLVRSTEIZNOSA(int iDPLVRSTEIZNOSA)
            {
                return (PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow) this.Rows.Find(new object[] { iDPLVRSTEIZNOSA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                PLVRSTEIZNOSADataSet set = new PLVRSTEIZNOSADataSet();
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
                this.columnIDPLVRSTEIZNOSA = new DataColumn("IDPLVRSTEIZNOSA", typeof(int), "", MappingType.Element);
                this.columnIDPLVRSTEIZNOSA.AllowDBNull = false;
                this.columnIDPLVRSTEIZNOSA.Caption = "IDPLVRSTEIZNOSA";
                this.columnIDPLVRSTEIZNOSA.Unique = true;
                this.columnIDPLVRSTEIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Length", "5");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "IDPLVRSTEIZNOSA");
                this.Columns.Add(this.columnIDPLVRSTEIZNOSA);
                this.columnNAZIVPLVRSTEIZNOSA = new DataColumn("NAZIVPLVRSTEIZNOSA", typeof(string), "", MappingType.Element);
                this.columnNAZIVPLVRSTEIZNOSA.AllowDBNull = false;
                this.columnNAZIVPLVRSTEIZNOSA.Caption = "NAZIVPLVRSTEIZNOSA";
                this.columnNAZIVPLVRSTEIZNOSA.MaxLength = 50;
                this.columnNAZIVPLVRSTEIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Description", "Vrsta iznosa");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPLVRSTEIZNOSA");
                this.Columns.Add(this.columnNAZIVPLVRSTEIZNOSA);
                this.PrimaryKey = new DataColumn[] { this.columnIDPLVRSTEIZNOSA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "PLVRSTEIZNOSA");
                this.ExtendedProperties.Add("Description", "PLVRSTEIZNOSA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDPLVRSTEIZNOSA = this.Columns["IDPLVRSTEIZNOSA"];
                this.columnNAZIVPLVRSTEIZNOSA = this.Columns["NAZIVPLVRSTEIZNOSA"];
            }

            public PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow NewPLVRSTEIZNOSARow()
            {
                return (PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PLVRSTEIZNOSARowChanged != null)
                {
                    PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARowChangeEventHandler pLVRSTEIZNOSARowChangedEvent = this.PLVRSTEIZNOSARowChanged;
                    if (pLVRSTEIZNOSARowChangedEvent != null)
                    {
                        pLVRSTEIZNOSARowChangedEvent(this, new PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARowChangeEvent((PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PLVRSTEIZNOSARowChanging != null)
                {
                    PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARowChangeEventHandler pLVRSTEIZNOSARowChangingEvent = this.PLVRSTEIZNOSARowChanging;
                    if (pLVRSTEIZNOSARowChangingEvent != null)
                    {
                        pLVRSTEIZNOSARowChangingEvent(this, new PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARowChangeEvent((PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PLVRSTEIZNOSARowDeleted != null)
                {
                    PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARowChangeEventHandler pLVRSTEIZNOSARowDeletedEvent = this.PLVRSTEIZNOSARowDeleted;
                    if (pLVRSTEIZNOSARowDeletedEvent != null)
                    {
                        pLVRSTEIZNOSARowDeletedEvent(this, new PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARowChangeEvent((PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PLVRSTEIZNOSARowDeleting != null)
                {
                    PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARowChangeEventHandler pLVRSTEIZNOSARowDeletingEvent = this.PLVRSTEIZNOSARowDeleting;
                    if (pLVRSTEIZNOSARowDeletingEvent != null)
                    {
                        pLVRSTEIZNOSARowDeletingEvent(this, new PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARowChangeEvent((PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePLVRSTEIZNOSARow(PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow row)
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

            public DataColumn IDPLVRSTEIZNOSAColumn
            {
                get
                {
                    return this.columnIDPLVRSTEIZNOSA;
                }
            }

            public PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow this[int index]
            {
                get
                {
                    return (PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVPLVRSTEIZNOSAColumn
            {
                get
                {
                    return this.columnNAZIVPLVRSTEIZNOSA;
                }
            }
        }

        public class PLVRSTEIZNOSARow : DataRow
        {
            private PLVRSTEIZNOSADataSet.PLVRSTEIZNOSADataTable tablePLVRSTEIZNOSA;

            internal PLVRSTEIZNOSARow(DataRowBuilder rb) : base(rb)
            {
                this.tablePLVRSTEIZNOSA = (PLVRSTEIZNOSADataSet.PLVRSTEIZNOSADataTable) this.Table;
            }

            public bool IsIDPLVRSTEIZNOSANull()
            {
                return this.IsNull(this.tablePLVRSTEIZNOSA.IDPLVRSTEIZNOSAColumn);
            }

            public bool IsNAZIVPLVRSTEIZNOSANull()
            {
                return this.IsNull(this.tablePLVRSTEIZNOSA.NAZIVPLVRSTEIZNOSAColumn);
            }

            public void SetNAZIVPLVRSTEIZNOSANull()
            {
                this[this.tablePLVRSTEIZNOSA.NAZIVPLVRSTEIZNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDPLVRSTEIZNOSA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePLVRSTEIZNOSA.IDPLVRSTEIZNOSAColumn]);
                }
                set
                {
                    this[this.tablePLVRSTEIZNOSA.IDPLVRSTEIZNOSAColumn] = value;
                }
            }

            public string NAZIVPLVRSTEIZNOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePLVRSTEIZNOSA.NAZIVPLVRSTEIZNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVPLVRSTEIZNOSA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablePLVRSTEIZNOSA.NAZIVPLVRSTEIZNOSAColumn] = value;
                }
            }
        }

        public class PLVRSTEIZNOSARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow eventRow;

            public PLVRSTEIZNOSARowChangeEvent(PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow row, DataRowAction action)
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

            public PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PLVRSTEIZNOSARowChangeEventHandler(object sender, PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARowChangeEvent e);
    }
}

