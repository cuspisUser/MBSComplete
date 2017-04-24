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
    public class RAD1GELEMENTIVEZADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RAD1GELEMENTIVEZADataTable tableRAD1GELEMENTIVEZA;

        public RAD1GELEMENTIVEZADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RAD1GELEMENTIVEZADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RAD1GELEMENTIVEZA"] != null)
                    {
                        this.Tables.Add(new RAD1GELEMENTIVEZADataTable(dataSet.Tables["RAD1GELEMENTIVEZA"]));
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
            RAD1GELEMENTIVEZADataSet set = (RAD1GELEMENTIVEZADataSet) base.Clone();
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
            RAD1GELEMENTIVEZADataSet set = new RAD1GELEMENTIVEZADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RAD1GELEMENTIVEZADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2177");
            this.ExtendedProperties.Add("DataSetName", "RAD1GELEMENTIVEZADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRAD1GELEMENTIVEZADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RAD1GELEMENTIVEZA");
            this.ExtendedProperties.Add("ObjectDescription", "Veza elementi RAD1G i elementi");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\VezeRAD1");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "RAD1GELEMENTIID");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "RAD1GELEMENTIVEZADataSet";
            this.Namespace = "http://www.tempuri.org/RAD1GELEMENTIVEZA";
            this.tableRAD1GELEMENTIVEZA = new RAD1GELEMENTIVEZADataTable();
            this.Tables.Add(this.tableRAD1GELEMENTIVEZA);
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
            this.tableRAD1GELEMENTIVEZA = (RAD1GELEMENTIVEZADataTable) this.Tables["RAD1GELEMENTIVEZA"];
            if (initTable && (this.tableRAD1GELEMENTIVEZA != null))
            {
                this.tableRAD1GELEMENTIVEZA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RAD1GELEMENTIVEZA"] != null)
                {
                    this.Tables.Add(new RAD1GELEMENTIVEZADataTable(dataSet.Tables["RAD1GELEMENTIVEZA"]));
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

        private bool ShouldSerializeRAD1GELEMENTIVEZA()
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
        public RAD1GELEMENTIVEZADataTable RAD1GELEMENTIVEZA
        {
            get
            {
                return this.tableRAD1GELEMENTIVEZA;
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
        public class RAD1GELEMENTIVEZADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDELEMENT;
            private DataColumn columnRAD1GELEMENTIID;

            public event RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARowChangeEventHandler RAD1GELEMENTIVEZARowChanged;

            public event RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARowChangeEventHandler RAD1GELEMENTIVEZARowChanging;

            public event RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARowChangeEventHandler RAD1GELEMENTIVEZARowDeleted;

            public event RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARowChangeEventHandler RAD1GELEMENTIVEZARowDeleting;

            public RAD1GELEMENTIVEZADataTable()
            {
                this.TableName = "RAD1GELEMENTIVEZA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RAD1GELEMENTIVEZADataTable(DataTable table) : base(table.TableName)
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

            protected RAD1GELEMENTIVEZADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRAD1GELEMENTIVEZARow(RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow row)
            {
                this.Rows.Add(row);
            }

            public RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow AddRAD1GELEMENTIVEZARow(int rAD1GELEMENTIID, int iDELEMENT)
            {
                RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow row = (RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow) this.NewRow();
                row["RAD1GELEMENTIID"] = rAD1GELEMENTIID;
                row["IDELEMENT"] = iDELEMENT;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZADataTable table = (RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow FindByRAD1GELEMENTIIDIDELEMENT(int rAD1GELEMENTIID, int iDELEMENT)
            {
                return (RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow) this.Rows.Find(new object[] { rAD1GELEMENTIID, iDELEMENT });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RAD1GELEMENTIVEZADataSet set = new RAD1GELEMENTIVEZADataSet();
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
                this.columnRAD1GELEMENTIID = new DataColumn("RAD1GELEMENTIID", typeof(int), "", MappingType.Element);
                this.columnRAD1GELEMENTIID.AllowDBNull = false;
                this.columnRAD1GELEMENTIID.Caption = "RAD1 GELEMENTIID";
                this.columnRAD1GELEMENTIID.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("IsKey", "true");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Description", "Element iz RAD1-G Obrasca");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Length", "5");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Decimals", "0");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.InternalName", "RAD1GELEMENTIID");
                this.Columns.Add(this.columnRAD1GELEMENTIID);
                this.columnIDELEMENT = new DataColumn("IDELEMENT", typeof(int), "", MappingType.Element);
                this.columnIDELEMENT.AllowDBNull = false;
                this.columnIDELEMENT.Caption = "Šifra elementa";
                this.columnIDELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDELEMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDELEMENT.ExtendedProperties.Add("Description", "Element u programu plaća");
                this.columnIDELEMENT.ExtendedProperties.Add("Length", "8");
                this.columnIDELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDELEMENT");
                this.Columns.Add(this.columnIDELEMENT);
                this.PrimaryKey = new DataColumn[] { this.columnRAD1GELEMENTIID, this.columnIDELEMENT };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RAD1GELEMENTIVEZA");
                this.ExtendedProperties.Add("Description", "Veza elementi RAD1G i elementi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnRAD1GELEMENTIID = this.Columns["RAD1GELEMENTIID"];
                this.columnIDELEMENT = this.Columns["IDELEMENT"];
            }

            public RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow NewRAD1GELEMENTIVEZARow()
            {
                return (RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RAD1GELEMENTIVEZARowChanged != null)
                {
                    RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARowChangeEventHandler handler = this.RAD1GELEMENTIVEZARowChanged;
                    if (handler != null)
                    {
                        handler(this, new RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARowChangeEvent((RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RAD1GELEMENTIVEZARowChanging != null)
                {
                    RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARowChangeEventHandler handler = this.RAD1GELEMENTIVEZARowChanging;
                    if (handler != null)
                    {
                        handler(this, new RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARowChangeEvent((RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RAD1GELEMENTIVEZARowDeleted != null)
                {
                    RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARowChangeEventHandler handler = this.RAD1GELEMENTIVEZARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARowChangeEvent((RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RAD1GELEMENTIVEZARowDeleting != null)
                {
                    RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARowChangeEventHandler handler = this.RAD1GELEMENTIVEZARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARowChangeEvent((RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRAD1GELEMENTIVEZARow(RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow row)
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

            public DataColumn IDELEMENTColumn
            {
                get
                {
                    return this.columnIDELEMENT;
                }
            }

            public RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow this[int index]
            {
                get
                {
                    return (RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow) this.Rows[index];
                }
            }

            public DataColumn RAD1GELEMENTIIDColumn
            {
                get
                {
                    return this.columnRAD1GELEMENTIID;
                }
            }
        }

        public class RAD1GELEMENTIVEZARow : DataRow
        {
            private RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZADataTable tableRAD1GELEMENTIVEZA;

            internal RAD1GELEMENTIVEZARow(DataRowBuilder rb) : base(rb)
            {
                this.tableRAD1GELEMENTIVEZA = (RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZADataTable) this.Table;
            }

            public bool IsIDELEMENTNull()
            {
                return this.IsNull(this.tableRAD1GELEMENTIVEZA.IDELEMENTColumn);
            }

            public bool IsRAD1GELEMENTIIDNull()
            {
                return this.IsNull(this.tableRAD1GELEMENTIVEZA.RAD1GELEMENTIIDColumn);
            }

            public int IDELEMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRAD1GELEMENTIVEZA.IDELEMENTColumn]);
                }
                set
                {
                    this[this.tableRAD1GELEMENTIVEZA.IDELEMENTColumn] = value;
                }
            }

            public int RAD1GELEMENTIID
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRAD1GELEMENTIVEZA.RAD1GELEMENTIIDColumn]);
                }
                set
                {
                    this[this.tableRAD1GELEMENTIVEZA.RAD1GELEMENTIIDColumn] = value;
                }
            }
        }

        public class RAD1GELEMENTIVEZARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow eventRow;

            public RAD1GELEMENTIVEZARowChangeEvent(RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow row, DataRowAction action)
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

            public RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RAD1GELEMENTIVEZARowChangeEventHandler(object sender, RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARowChangeEvent e);
    }
}

