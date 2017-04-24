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
    public class ZAPOSLENIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private ZAPOSLENIDataTable tableZAPOSLENI;

        public ZAPOSLENIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected ZAPOSLENIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["ZAPOSLENI"] != null)
                    {
                        this.Tables.Add(new ZAPOSLENIDataTable(dataSet.Tables["ZAPOSLENI"]));
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
            ZAPOSLENIDataSet set = (ZAPOSLENIDataSet) base.Clone();
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
            ZAPOSLENIDataSet set = new ZAPOSLENIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "ZAPOSLENIDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2188");
            this.ExtendedProperties.Add("DataSetName", "ZAPOSLENIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IZAPOSLENIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "ZAPOSLENI");
            this.ExtendedProperties.Add("ObjectDescription", "ZAPOSLENI");
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
            this.DataSetName = "ZAPOSLENIDataSet";
            this.Namespace = "http://www.tempuri.org/ZAPOSLENI";
            this.tableZAPOSLENI = new ZAPOSLENIDataTable();
            this.Tables.Add(this.tableZAPOSLENI);
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
            this.tableZAPOSLENI = (ZAPOSLENIDataTable) this.Tables["ZAPOSLENI"];
            if (initTable && (this.tableZAPOSLENI != null))
            {
                this.tableZAPOSLENI.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["ZAPOSLENI"] != null)
                {
                    this.Tables.Add(new ZAPOSLENIDataTable(dataSet.Tables["ZAPOSLENI"]));
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

        private bool ShouldSerializeZAPOSLENI()
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
        public ZAPOSLENIDataTable ZAPOSLENI
        {
            get
            {
                return this.tableZAPOSLENI;
            }
        }

        [Serializable]
        public class ZAPOSLENIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDATUMZAPOSLENJA;
            private DataColumn columnIDRADNIK;

            public event ZAPOSLENIDataSet.ZAPOSLENIRowChangeEventHandler ZAPOSLENIRowChanged;

            public event ZAPOSLENIDataSet.ZAPOSLENIRowChangeEventHandler ZAPOSLENIRowChanging;

            public event ZAPOSLENIDataSet.ZAPOSLENIRowChangeEventHandler ZAPOSLENIRowDeleted;

            public event ZAPOSLENIDataSet.ZAPOSLENIRowChangeEventHandler ZAPOSLENIRowDeleting;

            public ZAPOSLENIDataTable()
            {
                this.TableName = "ZAPOSLENI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal ZAPOSLENIDataTable(DataTable table) : base(table.TableName)
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

            protected ZAPOSLENIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddZAPOSLENIRow(ZAPOSLENIDataSet.ZAPOSLENIRow row)
            {
                this.Rows.Add(row);
            }

            public ZAPOSLENIDataSet.ZAPOSLENIRow AddZAPOSLENIRow(int iDRADNIK, DateTime dATUMZAPOSLENJA)
            {
                ZAPOSLENIDataSet.ZAPOSLENIRow row = (ZAPOSLENIDataSet.ZAPOSLENIRow) this.NewRow();
                row["IDRADNIK"] = iDRADNIK;
                row["DATUMZAPOSLENJA"] = dATUMZAPOSLENJA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                ZAPOSLENIDataSet.ZAPOSLENIDataTable table = (ZAPOSLENIDataSet.ZAPOSLENIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public ZAPOSLENIDataSet.ZAPOSLENIRow FindByIDRADNIKDATUMZAPOSLENJA(int iDRADNIK, DateTime dATUMZAPOSLENJA)
            {
                return (ZAPOSLENIDataSet.ZAPOSLENIRow) this.Rows.Find(new object[] { iDRADNIK, dATUMZAPOSLENJA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(ZAPOSLENIDataSet.ZAPOSLENIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                ZAPOSLENIDataSet set = new ZAPOSLENIDataSet();
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
                this.columnDATUMZAPOSLENJA = new DataColumn("DATUMZAPOSLENJA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMZAPOSLENJA.AllowDBNull = false;
                this.columnDATUMZAPOSLENJA.Caption = "DATUMZAPOSLENJA";
                this.columnDATUMZAPOSLENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("IsKey", "true");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("Description", "Datum zasnivanja radnog odnosa");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMZAPOSLENJA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMZAPOSLENJA");
                this.Columns.Add(this.columnDATUMZAPOSLENJA);
                this.PrimaryKey = new DataColumn[] { this.columnIDRADNIK, this.columnDATUMZAPOSLENJA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "ZAPOSLENI");
                this.ExtendedProperties.Add("Description", "ZAPOSLENI");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnDATUMZAPOSLENJA = this.Columns["DATUMZAPOSLENJA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new ZAPOSLENIDataSet.ZAPOSLENIRow(builder);
            }

            public ZAPOSLENIDataSet.ZAPOSLENIRow NewZAPOSLENIRow()
            {
                return (ZAPOSLENIDataSet.ZAPOSLENIRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ZAPOSLENIRowChanged != null)
                {
                    ZAPOSLENIDataSet.ZAPOSLENIRowChangeEventHandler zAPOSLENIRowChangedEvent = this.ZAPOSLENIRowChanged;
                    if (zAPOSLENIRowChangedEvent != null)
                    {
                        zAPOSLENIRowChangedEvent(this, new ZAPOSLENIDataSet.ZAPOSLENIRowChangeEvent((ZAPOSLENIDataSet.ZAPOSLENIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ZAPOSLENIRowChanging != null)
                {
                    ZAPOSLENIDataSet.ZAPOSLENIRowChangeEventHandler zAPOSLENIRowChangingEvent = this.ZAPOSLENIRowChanging;
                    if (zAPOSLENIRowChangingEvent != null)
                    {
                        zAPOSLENIRowChangingEvent(this, new ZAPOSLENIDataSet.ZAPOSLENIRowChangeEvent((ZAPOSLENIDataSet.ZAPOSLENIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.ZAPOSLENIRowDeleted != null)
                {
                    ZAPOSLENIDataSet.ZAPOSLENIRowChangeEventHandler zAPOSLENIRowDeletedEvent = this.ZAPOSLENIRowDeleted;
                    if (zAPOSLENIRowDeletedEvent != null)
                    {
                        zAPOSLENIRowDeletedEvent(this, new ZAPOSLENIDataSet.ZAPOSLENIRowChangeEvent((ZAPOSLENIDataSet.ZAPOSLENIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ZAPOSLENIRowDeleting != null)
                {
                    ZAPOSLENIDataSet.ZAPOSLENIRowChangeEventHandler zAPOSLENIRowDeletingEvent = this.ZAPOSLENIRowDeleting;
                    if (zAPOSLENIRowDeletingEvent != null)
                    {
                        zAPOSLENIRowDeletingEvent(this, new ZAPOSLENIDataSet.ZAPOSLENIRowChangeEvent((ZAPOSLENIDataSet.ZAPOSLENIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveZAPOSLENIRow(ZAPOSLENIDataSet.ZAPOSLENIRow row)
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

            public DataColumn DATUMZAPOSLENJAColumn
            {
                get
                {
                    return this.columnDATUMZAPOSLENJA;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public ZAPOSLENIDataSet.ZAPOSLENIRow this[int index]
            {
                get
                {
                    return (ZAPOSLENIDataSet.ZAPOSLENIRow) this.Rows[index];
                }
            }
        }

        public class ZAPOSLENIRow : DataRow
        {
            private ZAPOSLENIDataSet.ZAPOSLENIDataTable tableZAPOSLENI;

            internal ZAPOSLENIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableZAPOSLENI = (ZAPOSLENIDataSet.ZAPOSLENIDataTable) this.Table;
            }

            public bool IsDATUMZAPOSLENJANull()
            {
                return this.IsNull(this.tableZAPOSLENI.DATUMZAPOSLENJAColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableZAPOSLENI.IDRADNIKColumn);
            }

            public DateTime DATUMZAPOSLENJA
            {
                get
                {
                    return Conversions.ToDate(this[this.tableZAPOSLENI.DATUMZAPOSLENJAColumn]);
                }
                set
                {
                    this[this.tableZAPOSLENI.DATUMZAPOSLENJAColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableZAPOSLENI.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableZAPOSLENI.IDRADNIKColumn] = value;
                }
            }
        }

        public class ZAPOSLENIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private ZAPOSLENIDataSet.ZAPOSLENIRow eventRow;

            public ZAPOSLENIRowChangeEvent(ZAPOSLENIDataSet.ZAPOSLENIRow row, DataRowAction action)
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

            public ZAPOSLENIDataSet.ZAPOSLENIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void ZAPOSLENIRowChangeEventHandler(object sender, ZAPOSLENIDataSet.ZAPOSLENIRowChangeEvent e);
    }
}

