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
    public class OTISLIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private OTISLIDataTable tableOTISLI;

        public OTISLIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected OTISLIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["OTISLI"] != null)
                    {
                        this.Tables.Add(new OTISLIDataTable(dataSet.Tables["OTISLI"]));
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
            OTISLIDataSet set = (OTISLIDataSet) base.Clone();
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
            OTISLIDataSet set = new OTISLIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "OTISLIDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2189");
            this.ExtendedProperties.Add("DataSetName", "OTISLIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IOTISLIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "OTISLI");
            this.ExtendedProperties.Add("ObjectDescription", "OTISLI");
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
            this.DataSetName = "OTISLIDataSet";
            this.Namespace = "http://www.tempuri.org/OTISLI";
            this.tableOTISLI = new OTISLIDataTable();
            this.Tables.Add(this.tableOTISLI);
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
            this.tableOTISLI = (OTISLIDataTable) this.Tables["OTISLI"];
            if (initTable && (this.tableOTISLI != null))
            {
                this.tableOTISLI.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["OTISLI"] != null)
                {
                    this.Tables.Add(new OTISLIDataTable(dataSet.Tables["OTISLI"]));
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

        private bool ShouldSerializeOTISLI()
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
        public OTISLIDataTable OTISLI
        {
            get
            {
                return this.tableOTISLI;
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
        public class OTISLIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDATUMODLASKA;
            private DataColumn columnIDRADNIK;

            public event OTISLIDataSet.OTISLIRowChangeEventHandler OTISLIRowChanged;

            public event OTISLIDataSet.OTISLIRowChangeEventHandler OTISLIRowChanging;

            public event OTISLIDataSet.OTISLIRowChangeEventHandler OTISLIRowDeleted;

            public event OTISLIDataSet.OTISLIRowChangeEventHandler OTISLIRowDeleting;

            public OTISLIDataTable()
            {
                this.TableName = "OTISLI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OTISLIDataTable(DataTable table) : base(table.TableName)
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

            protected OTISLIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOTISLIRow(OTISLIDataSet.OTISLIRow row)
            {
                this.Rows.Add(row);
            }

            public OTISLIDataSet.OTISLIRow AddOTISLIRow(int iDRADNIK, DateTime dATUMODLASKA)
            {
                OTISLIDataSet.OTISLIRow row = (OTISLIDataSet.OTISLIRow) this.NewRow();
                row["IDRADNIK"] = iDRADNIK;
                row["DATUMODLASKA"] = dATUMODLASKA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OTISLIDataSet.OTISLIDataTable table = (OTISLIDataSet.OTISLIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OTISLIDataSet.OTISLIRow FindByIDRADNIKDATUMODLASKA(int iDRADNIK, DateTime dATUMODLASKA)
            {
                return (OTISLIDataSet.OTISLIRow) this.Rows.Find(new object[] { iDRADNIK, dATUMODLASKA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OTISLIDataSet.OTISLIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OTISLIDataSet set = new OTISLIDataSet();
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
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnDATUMODLASKA = new DataColumn("DATUMODLASKA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMODLASKA.AllowDBNull = false;
                this.columnDATUMODLASKA.Caption = "DATUMODLASKA";
                this.columnDATUMODLASKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMODLASKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMODLASKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMODLASKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMODLASKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMODLASKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMODLASKA.ExtendedProperties.Add("IsKey", "true");
                this.columnDATUMODLASKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMODLASKA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMODLASKA.ExtendedProperties.Add("Description", "Datum prekida radnog odnosa");
                this.columnDATUMODLASKA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMODLASKA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMODLASKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUMODLASKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMODLASKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMODLASKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMODLASKA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMODLASKA");
                this.Columns.Add(this.columnDATUMODLASKA);
                this.PrimaryKey = new DataColumn[] { this.columnIDRADNIK, this.columnDATUMODLASKA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "OTISLI");
                this.ExtendedProperties.Add("Description", "OTISLI");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnDATUMODLASKA = this.Columns["DATUMODLASKA"];
            }

            public OTISLIDataSet.OTISLIRow NewOTISLIRow()
            {
                return (OTISLIDataSet.OTISLIRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OTISLIDataSet.OTISLIRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OTISLIRowChanged != null)
                {
                    OTISLIDataSet.OTISLIRowChangeEventHandler oTISLIRowChangedEvent = this.OTISLIRowChanged;
                    if (oTISLIRowChangedEvent != null)
                    {
                        oTISLIRowChangedEvent(this, new OTISLIDataSet.OTISLIRowChangeEvent((OTISLIDataSet.OTISLIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OTISLIRowChanging != null)
                {
                    OTISLIDataSet.OTISLIRowChangeEventHandler oTISLIRowChangingEvent = this.OTISLIRowChanging;
                    if (oTISLIRowChangingEvent != null)
                    {
                        oTISLIRowChangingEvent(this, new OTISLIDataSet.OTISLIRowChangeEvent((OTISLIDataSet.OTISLIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.OTISLIRowDeleted != null)
                {
                    OTISLIDataSet.OTISLIRowChangeEventHandler oTISLIRowDeletedEvent = this.OTISLIRowDeleted;
                    if (oTISLIRowDeletedEvent != null)
                    {
                        oTISLIRowDeletedEvent(this, new OTISLIDataSet.OTISLIRowChangeEvent((OTISLIDataSet.OTISLIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OTISLIRowDeleting != null)
                {
                    OTISLIDataSet.OTISLIRowChangeEventHandler oTISLIRowDeletingEvent = this.OTISLIRowDeleting;
                    if (oTISLIRowDeletingEvent != null)
                    {
                        oTISLIRowDeletingEvent(this, new OTISLIDataSet.OTISLIRowChangeEvent((OTISLIDataSet.OTISLIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOTISLIRow(OTISLIDataSet.OTISLIRow row)
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

            public DataColumn DATUMODLASKAColumn
            {
                get
                {
                    return this.columnDATUMODLASKA;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public OTISLIDataSet.OTISLIRow this[int index]
            {
                get
                {
                    return (OTISLIDataSet.OTISLIRow) this.Rows[index];
                }
            }
        }

        public class OTISLIRow : DataRow
        {
            private OTISLIDataSet.OTISLIDataTable tableOTISLI;

            internal OTISLIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableOTISLI = (OTISLIDataSet.OTISLIDataTable) this.Table;
            }

            public bool IsDATUMODLASKANull()
            {
                return this.IsNull(this.tableOTISLI.DATUMODLASKAColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableOTISLI.IDRADNIKColumn);
            }

            public DateTime DATUMODLASKA
            {
                get
                {
                    return Conversions.ToDate(this[this.tableOTISLI.DATUMODLASKAColumn]);
                }
                set
                {
                    this[this.tableOTISLI.DATUMODLASKAColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOTISLI.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableOTISLI.IDRADNIKColumn] = value;
                }
            }
        }

        public class OTISLIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OTISLIDataSet.OTISLIRow eventRow;

            public OTISLIRowChangeEvent(OTISLIDataSet.OTISLIRow row, DataRowAction action)
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

            public OTISLIDataSet.OTISLIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OTISLIRowChangeEventHandler(object sender, OTISLIDataSet.OTISLIRowChangeEvent e);
    }
}

