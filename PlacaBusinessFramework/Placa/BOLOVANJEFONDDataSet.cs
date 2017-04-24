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
    public class BOLOVANJEFONDDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private BOLOVANJEFONDDataTable tableBOLOVANJEFOND;

        public BOLOVANJEFONDDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected BOLOVANJEFONDDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["BOLOVANJEFOND"] != null)
                    {
                        this.Tables.Add(new BOLOVANJEFONDDataTable(dataSet.Tables["BOLOVANJEFOND"]));
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
            BOLOVANJEFONDDataSet set = (BOLOVANJEFONDDataSet) base.Clone();
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
            BOLOVANJEFONDDataSet set = new BOLOVANJEFONDDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "BOLOVANJEFONDDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2074");
            this.ExtendedProperties.Add("DataSetName", "BOLOVANJEFONDDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IBOLOVANJEFONDDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "BOLOVANJEFOND");
            this.ExtendedProperties.Add("ObjectDescription", "BOLOVANJEFOND");
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
            this.DataSetName = "BOLOVANJEFONDDataSet";
            this.Namespace = "http://www.tempuri.org/BOLOVANJEFOND";
            this.tableBOLOVANJEFOND = new BOLOVANJEFONDDataTable();
            this.Tables.Add(this.tableBOLOVANJEFOND);
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
            this.tableBOLOVANJEFOND = (BOLOVANJEFONDDataTable) this.Tables["BOLOVANJEFOND"];
            if (initTable && (this.tableBOLOVANJEFOND != null))
            {
                this.tableBOLOVANJEFOND.InitVars();
            }

            this.tableBOLOVANJEFOND.Columns["KOLONA"].Caption = "Kolona ER-1 obrasca";
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["BOLOVANJEFOND"] != null)
                {
                    this.Tables.Add(new BOLOVANJEFONDDataTable(dataSet.Tables["BOLOVANJEFOND"]));
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

        private bool ShouldSerializeBOLOVANJEFOND()
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
        public BOLOVANJEFONDDataTable BOLOVANJEFOND
        {
            get
            {
                return this.tableBOLOVANJEFOND;
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
        public class BOLOVANJEFONDDataTable : DataTable, IEnumerable
        {
            private DataColumn columnELEMENTBOLOVANJEIDELEMENT;
            private DataColumn columnELEMENTBOLOVANJENAZIVELEMENT;
            private DataColumn columnKOLONA;

            public event BOLOVANJEFONDDataSet.BOLOVANJEFONDRowChangeEventHandler BOLOVANJEFONDRowChanged;

            public event BOLOVANJEFONDDataSet.BOLOVANJEFONDRowChangeEventHandler BOLOVANJEFONDRowChanging;

            public event BOLOVANJEFONDDataSet.BOLOVANJEFONDRowChangeEventHandler BOLOVANJEFONDRowDeleted;

            public event BOLOVANJEFONDDataSet.BOLOVANJEFONDRowChangeEventHandler BOLOVANJEFONDRowDeleting;

            public BOLOVANJEFONDDataTable()
            {
                this.TableName = "BOLOVANJEFOND";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal BOLOVANJEFONDDataTable(DataTable table) : base(table.TableName)
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

            protected BOLOVANJEFONDDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddBOLOVANJEFONDRow(BOLOVANJEFONDDataSet.BOLOVANJEFONDRow row)
            {
                this.Rows.Add(row);
            }

            public BOLOVANJEFONDDataSet.BOLOVANJEFONDRow AddBOLOVANJEFONDRow(int eLEMENTBOLOVANJEIDELEMENT, short kOLONA)
            {
                BOLOVANJEFONDDataSet.BOLOVANJEFONDRow row = (BOLOVANJEFONDDataSet.BOLOVANJEFONDRow) this.NewRow();
                row["ELEMENTBOLOVANJEIDELEMENT"] = eLEMENTBOLOVANJEIDELEMENT;
                row["KOLONA"] = kOLONA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                BOLOVANJEFONDDataSet.BOLOVANJEFONDDataTable table = (BOLOVANJEFONDDataSet.BOLOVANJEFONDDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public BOLOVANJEFONDDataSet.BOLOVANJEFONDRow FindByELEMENTBOLOVANJEIDELEMENT(int eLEMENTBOLOVANJEIDELEMENT)
            {
                return (BOLOVANJEFONDDataSet.BOLOVANJEFONDRow) this.Rows.Find(new object[] { eLEMENTBOLOVANJEIDELEMENT });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(BOLOVANJEFONDDataSet.BOLOVANJEFONDRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                BOLOVANJEFONDDataSet set = new BOLOVANJEFONDDataSet();
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
                this.columnELEMENTBOLOVANJEIDELEMENT = new DataColumn("ELEMENTBOLOVANJEIDELEMENT", typeof(int), "", MappingType.Element);
                this.columnELEMENTBOLOVANJEIDELEMENT.AllowDBNull = false;
                this.columnELEMENTBOLOVANJEIDELEMENT.Caption = "Šifra elementa";
                this.columnELEMENTBOLOVANJEIDELEMENT.Unique = true;
                this.columnELEMENTBOLOVANJEIDELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("SuperType", "IDELEMENT");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("SubtypeGroup", "ELEMENTBOLOVANJE");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("Description", "Šifra elementa");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("Length", "8");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnELEMENTBOLOVANJEIDELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "ELEMENTBOLOVANJEIDELEMENT");
                this.Columns.Add(this.columnELEMENTBOLOVANJEIDELEMENT);
                this.columnELEMENTBOLOVANJENAZIVELEMENT = new DataColumn("ELEMENTBOLOVANJENAZIVELEMENT", typeof(string), "", MappingType.Element);
                this.columnELEMENTBOLOVANJENAZIVELEMENT.AllowDBNull = true;
                this.columnELEMENTBOLOVANJENAZIVELEMENT.Caption = "Naziv elementa";
                this.columnELEMENTBOLOVANJENAZIVELEMENT.MaxLength = 50;
                this.columnELEMENTBOLOVANJENAZIVELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("SuperType", "NAZIVELEMENT");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("SubtypeGroup", "ELEMENTBOLOVANJE");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("Description", "Naziv elementa");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("Length", "50");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnELEMENTBOLOVANJENAZIVELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "ELEMENTBOLOVANJENAZIVELEMENT");
                this.Columns.Add(this.columnELEMENTBOLOVANJENAZIVELEMENT);
                this.columnKOLONA = new DataColumn("KOLONA", typeof(short), "", MappingType.Element);
                this.columnKOLONA.AllowDBNull = false;
                this.columnKOLONA.Caption = "KOLONA";
                this.columnKOLONA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOLONA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKOLONA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKOLONA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKOLONA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOLONA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOLONA.ExtendedProperties.Add("IsKey", "false");
                this.columnKOLONA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKOLONA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOLONA.ExtendedProperties.Add("Description", "Kolona ER-1 obrasca");
                this.columnKOLONA.ExtendedProperties.Add("Length", "1");
                this.columnKOLONA.ExtendedProperties.Add("Decimals", "0");
                this.columnKOLONA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKOLONA.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOLONA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOLONA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOLONA.ExtendedProperties.Add("Deklarit.InternalName", "KOLONA");
                this.Columns.Add(this.columnKOLONA);
                this.PrimaryKey = new DataColumn[] { this.columnELEMENTBOLOVANJEIDELEMENT };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "BOLOVANJEFOND");
                this.ExtendedProperties.Add("Description", "BOLOVANJEFOND");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnELEMENTBOLOVANJEIDELEMENT = this.Columns["ELEMENTBOLOVANJEIDELEMENT"];
                this.columnELEMENTBOLOVANJENAZIVELEMENT = this.Columns["ELEMENTBOLOVANJENAZIVELEMENT"];
                this.columnKOLONA = this.Columns["KOLONA"];
            }

            public BOLOVANJEFONDDataSet.BOLOVANJEFONDRow NewBOLOVANJEFONDRow()
            {
                return (BOLOVANJEFONDDataSet.BOLOVANJEFONDRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new BOLOVANJEFONDDataSet.BOLOVANJEFONDRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.BOLOVANJEFONDRowChanged != null)
                {
                    BOLOVANJEFONDDataSet.BOLOVANJEFONDRowChangeEventHandler bOLOVANJEFONDRowChangedEvent = this.BOLOVANJEFONDRowChanged;
                    if (bOLOVANJEFONDRowChangedEvent != null)
                    {
                        bOLOVANJEFONDRowChangedEvent(this, new BOLOVANJEFONDDataSet.BOLOVANJEFONDRowChangeEvent((BOLOVANJEFONDDataSet.BOLOVANJEFONDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.BOLOVANJEFONDRowChanging != null)
                {
                    BOLOVANJEFONDDataSet.BOLOVANJEFONDRowChangeEventHandler bOLOVANJEFONDRowChangingEvent = this.BOLOVANJEFONDRowChanging;
                    if (bOLOVANJEFONDRowChangingEvent != null)
                    {
                        bOLOVANJEFONDRowChangingEvent(this, new BOLOVANJEFONDDataSet.BOLOVANJEFONDRowChangeEvent((BOLOVANJEFONDDataSet.BOLOVANJEFONDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.BOLOVANJEFONDRowDeleted != null)
                {
                    BOLOVANJEFONDDataSet.BOLOVANJEFONDRowChangeEventHandler bOLOVANJEFONDRowDeletedEvent = this.BOLOVANJEFONDRowDeleted;
                    if (bOLOVANJEFONDRowDeletedEvent != null)
                    {
                        bOLOVANJEFONDRowDeletedEvent(this, new BOLOVANJEFONDDataSet.BOLOVANJEFONDRowChangeEvent((BOLOVANJEFONDDataSet.BOLOVANJEFONDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.BOLOVANJEFONDRowDeleting != null)
                {
                    BOLOVANJEFONDDataSet.BOLOVANJEFONDRowChangeEventHandler bOLOVANJEFONDRowDeletingEvent = this.BOLOVANJEFONDRowDeleting;
                    if (bOLOVANJEFONDRowDeletingEvent != null)
                    {
                        bOLOVANJEFONDRowDeletingEvent(this, new BOLOVANJEFONDDataSet.BOLOVANJEFONDRowChangeEvent((BOLOVANJEFONDDataSet.BOLOVANJEFONDRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveBOLOVANJEFONDRow(BOLOVANJEFONDDataSet.BOLOVANJEFONDRow row)
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

            public DataColumn ELEMENTBOLOVANJEIDELEMENTColumn
            {
                get
                {
                    return this.columnELEMENTBOLOVANJEIDELEMENT;
                }
            }

            public DataColumn ELEMENTBOLOVANJENAZIVELEMENTColumn
            {
                get
                {
                    return this.columnELEMENTBOLOVANJENAZIVELEMENT;
                }
            }

            public BOLOVANJEFONDDataSet.BOLOVANJEFONDRow this[int index]
            {
                get
                {
                    return (BOLOVANJEFONDDataSet.BOLOVANJEFONDRow) this.Rows[index];
                }
            }

            public DataColumn KOLONAColumn
            {
                get
                {
                    return this.columnKOLONA;
                }
            }
        }

        public class BOLOVANJEFONDRow : DataRow
        {
            private BOLOVANJEFONDDataSet.BOLOVANJEFONDDataTable tableBOLOVANJEFOND;

            internal BOLOVANJEFONDRow(DataRowBuilder rb) : base(rb)
            {
                this.tableBOLOVANJEFOND = (BOLOVANJEFONDDataSet.BOLOVANJEFONDDataTable) this.Table;
            }

            public bool IsELEMENTBOLOVANJEIDELEMENTNull()
            {
                return this.IsNull(this.tableBOLOVANJEFOND.ELEMENTBOLOVANJEIDELEMENTColumn);
            }

            public bool IsELEMENTBOLOVANJENAZIVELEMENTNull()
            {
                return this.IsNull(this.tableBOLOVANJEFOND.ELEMENTBOLOVANJENAZIVELEMENTColumn);
            }

            public bool IsKOLONANull()
            {
                return this.IsNull(this.tableBOLOVANJEFOND.KOLONAColumn);
            }

            public void SetELEMENTBOLOVANJENAZIVELEMENTNull()
            {
                this[this.tableBOLOVANJEFOND.ELEMENTBOLOVANJENAZIVELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOLONANull()
            {
                this[this.tableBOLOVANJEFOND.KOLONAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int ELEMENTBOLOVANJEIDELEMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableBOLOVANJEFOND.ELEMENTBOLOVANJEIDELEMENTColumn]);
                }
                set
                {
                    this[this.tableBOLOVANJEFOND.ELEMENTBOLOVANJEIDELEMENTColumn] = value;
                }
            }

            public string ELEMENTBOLOVANJENAZIVELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBOLOVANJEFOND.ELEMENTBOLOVANJENAZIVELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ELEMENTBOLOVANJENAZIVELEMENT because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableBOLOVANJEFOND.ELEMENTBOLOVANJENAZIVELEMENTColumn] = value;
                }
            }

            public short KOLONA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableBOLOVANJEFOND.KOLONAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value KOLONA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableBOLOVANJEFOND.KOLONAColumn] = value;
                }
            }
        }

        public class BOLOVANJEFONDRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private BOLOVANJEFONDDataSet.BOLOVANJEFONDRow eventRow;

            public BOLOVANJEFONDRowChangeEvent(BOLOVANJEFONDDataSet.BOLOVANJEFONDRow row, DataRowAction action)
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

            public BOLOVANJEFONDDataSet.BOLOVANJEFONDRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void BOLOVANJEFONDRowChangeEventHandler(object sender, BOLOVANJEFONDDataSet.BOLOVANJEFONDRowChangeEvent e);
    }
}

