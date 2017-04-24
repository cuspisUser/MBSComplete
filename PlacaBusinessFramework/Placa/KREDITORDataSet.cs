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
    public class KREDITORDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private KREDITORDataTable tableKREDITOR;

        public KREDITORDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected KREDITORDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["KREDITOR"] != null)
                    {
                        this.Tables.Add(new KREDITORDataTable(dataSet.Tables["KREDITOR"]));
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
            KREDITORDataSet set = (KREDITORDataSet) base.Clone();
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
            KREDITORDataSet set = new KREDITORDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "KREDITORDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2001");
            this.ExtendedProperties.Add("DataSetName", "KREDITORDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IKREDITORDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "KREDITOR");
            this.ExtendedProperties.Add("ObjectDescription", "Kreditori");
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
            this.DataSetName = "KREDITORDataSet";
            this.Namespace = "http://www.tempuri.org/KREDITOR";
            this.tableKREDITOR = new KREDITORDataTable();
            this.Tables.Add(this.tableKREDITOR);
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
            this.tableKREDITOR = (KREDITORDataTable) this.Tables["KREDITOR"];
            if (initTable && (this.tableKREDITOR != null))
            {
                this.tableKREDITOR.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["KREDITOR"] != null)
                {
                    this.Tables.Add(new KREDITORDataTable(dataSet.Tables["KREDITOR"]));
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

        private bool ShouldSerializeKREDITOR()
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
        public KREDITORDataTable KREDITOR
        {
            get
            {
                return this.tableKREDITOR;
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
        public class KREDITORDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDKREDITOR;
            private DataColumn columnNAZIVKREDITOR;
            private DataColumn columnPRIMATELJKREDITOR1;
            private DataColumn columnPRIMATELJKREDITOR2;
            private DataColumn columnPRIMATELJKREDITOR3;
            private DataColumn columnVBDIKREDITOR;
            private DataColumn columnZRNKREDITOR;

            public event KREDITORDataSet.KREDITORRowChangeEventHandler KREDITORRowChanged;

            public event KREDITORDataSet.KREDITORRowChangeEventHandler KREDITORRowChanging;

            public event KREDITORDataSet.KREDITORRowChangeEventHandler KREDITORRowDeleted;

            public event KREDITORDataSet.KREDITORRowChangeEventHandler KREDITORRowDeleting;

            public KREDITORDataTable()
            {
                this.TableName = "KREDITOR";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal KREDITORDataTable(DataTable table) : base(table.TableName)
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

            protected KREDITORDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddKREDITORRow(KREDITORDataSet.KREDITORRow row)
            {
                this.Rows.Add(row);
            }

            public KREDITORDataSet.KREDITORRow AddKREDITORRow(int iDKREDITOR, string nAZIVKREDITOR, string vBDIKREDITOR, string zRNKREDITOR, string pRIMATELJKREDITOR1, string pRIMATELJKREDITOR2, string pRIMATELJKREDITOR3)
            {
                KREDITORDataSet.KREDITORRow row = (KREDITORDataSet.KREDITORRow) this.NewRow();
                row["IDKREDITOR"] = iDKREDITOR;
                row["NAZIVKREDITOR"] = nAZIVKREDITOR;
                row["VBDIKREDITOR"] = vBDIKREDITOR;
                row["ZRNKREDITOR"] = zRNKREDITOR;
                row["PRIMATELJKREDITOR1"] = pRIMATELJKREDITOR1;
                row["PRIMATELJKREDITOR2"] = pRIMATELJKREDITOR2;
                row["PRIMATELJKREDITOR3"] = pRIMATELJKREDITOR3;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                KREDITORDataSet.KREDITORDataTable table = (KREDITORDataSet.KREDITORDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public KREDITORDataSet.KREDITORRow FindByIDKREDITOR(int iDKREDITOR)
            {
                return (KREDITORDataSet.KREDITORRow) this.Rows.Find(new object[] { iDKREDITOR });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(KREDITORDataSet.KREDITORRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                KREDITORDataSet set = new KREDITORDataSet();
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
                this.columnIDKREDITOR = new DataColumn("IDKREDITOR", typeof(int), "", MappingType.Element);
                this.columnIDKREDITOR.AllowDBNull = false;
                this.columnIDKREDITOR.Caption = "IDKREDITOR";
                this.columnIDKREDITOR.Unique = true;
                this.columnIDKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "99999999");
                this.columnIDKREDITOR.ExtendedProperties.Add("IsKey", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKREDITOR.ExtendedProperties.Add("Description", "Šifra kreditora");
                this.columnIDKREDITOR.ExtendedProperties.Add("Length", "8");
                this.columnIDKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "IDKREDITOR");
                this.Columns.Add(this.columnIDKREDITOR);
                this.columnNAZIVKREDITOR = new DataColumn("NAZIVKREDITOR", typeof(string), "", MappingType.Element);
                this.columnNAZIVKREDITOR.AllowDBNull = false;
                this.columnNAZIVKREDITOR.Caption = "NAZIVKREDITOR";
                this.columnNAZIVKREDITOR.MaxLength = 20;
                this.columnNAZIVKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Description", "Naziv kreditora");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKREDITOR");
                this.Columns.Add(this.columnNAZIVKREDITOR);
                this.columnVBDIKREDITOR = new DataColumn("VBDIKREDITOR", typeof(string), "", MappingType.Element);
                this.columnVBDIKREDITOR.AllowDBNull = false;
                this.columnVBDIKREDITOR.Caption = "VBDIKREDITOR";
                this.columnVBDIKREDITOR.MaxLength = 7;
                this.columnVBDIKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Description", "VBDI kreditora");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Length", "7");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("IsInReader", "true");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "VBDIKREDITOR");
                this.Columns.Add(this.columnVBDIKREDITOR);
                this.columnZRNKREDITOR = new DataColumn("ZRNKREDITOR", typeof(string), "", MappingType.Element);
                this.columnZRNKREDITOR.AllowDBNull = false;
                this.columnZRNKREDITOR.Caption = "ZRNKREDITOR";
                this.columnZRNKREDITOR.MaxLength = 10;
                this.columnZRNKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZRNKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Description", "ŽRN kreditora");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Length", "10");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZRNKREDITOR.ExtendedProperties.Add("IsInReader", "true");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "ZRNKREDITOR");
                this.Columns.Add(this.columnZRNKREDITOR);
                this.columnPRIMATELJKREDITOR1 = new DataColumn("PRIMATELJKREDITOR1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKREDITOR1.AllowDBNull = false;
                this.columnPRIMATELJKREDITOR1.Caption = "PRIMATELJKREDITO R1";
                this.columnPRIMATELJKREDITOR1.MaxLength = 20;
                this.columnPRIMATELJKREDITOR1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Description", "Primatelj kreditor (1)");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKREDITOR1");
                this.Columns.Add(this.columnPRIMATELJKREDITOR1);
                this.columnPRIMATELJKREDITOR2 = new DataColumn("PRIMATELJKREDITOR2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKREDITOR2.AllowDBNull = true;
                this.columnPRIMATELJKREDITOR2.Caption = "PRIMATELJKREDITO R2";
                this.columnPRIMATELJKREDITOR2.MaxLength = 20;
                this.columnPRIMATELJKREDITOR2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Description", "Primatelj kreditor (2)");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKREDITOR2");
                this.Columns.Add(this.columnPRIMATELJKREDITOR2);
                this.columnPRIMATELJKREDITOR3 = new DataColumn("PRIMATELJKREDITOR3", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKREDITOR3.AllowDBNull = true;
                this.columnPRIMATELJKREDITOR3.Caption = "PRIMATELJKREDITO R3";
                this.columnPRIMATELJKREDITOR3.MaxLength = 20;
                this.columnPRIMATELJKREDITOR3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Description", "Primatelj kreditor (3)");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKREDITOR3");
                this.Columns.Add(this.columnPRIMATELJKREDITOR3);
                this.PrimaryKey = new DataColumn[] { this.columnIDKREDITOR };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "KREDITOR");
                this.ExtendedProperties.Add("Description", "Kreditori");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDKREDITOR = this.Columns["IDKREDITOR"];
                this.columnNAZIVKREDITOR = this.Columns["NAZIVKREDITOR"];
                this.columnVBDIKREDITOR = this.Columns["VBDIKREDITOR"];
                this.columnZRNKREDITOR = this.Columns["ZRNKREDITOR"];
                this.columnPRIMATELJKREDITOR1 = this.Columns["PRIMATELJKREDITOR1"];
                this.columnPRIMATELJKREDITOR2 = this.Columns["PRIMATELJKREDITOR2"];
                this.columnPRIMATELJKREDITOR3 = this.Columns["PRIMATELJKREDITOR3"];
            }

            public KREDITORDataSet.KREDITORRow NewKREDITORRow()
            {
                return (KREDITORDataSet.KREDITORRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new KREDITORDataSet.KREDITORRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.KREDITORRowChanged != null)
                {
                    KREDITORDataSet.KREDITORRowChangeEventHandler kREDITORRowChangedEvent = this.KREDITORRowChanged;
                    if (kREDITORRowChangedEvent != null)
                    {
                        kREDITORRowChangedEvent(this, new KREDITORDataSet.KREDITORRowChangeEvent((KREDITORDataSet.KREDITORRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.KREDITORRowChanging != null)
                {
                    KREDITORDataSet.KREDITORRowChangeEventHandler kREDITORRowChangingEvent = this.KREDITORRowChanging;
                    if (kREDITORRowChangingEvent != null)
                    {
                        kREDITORRowChangingEvent(this, new KREDITORDataSet.KREDITORRowChangeEvent((KREDITORDataSet.KREDITORRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.KREDITORRowDeleted != null)
                {
                    KREDITORDataSet.KREDITORRowChangeEventHandler kREDITORRowDeletedEvent = this.KREDITORRowDeleted;
                    if (kREDITORRowDeletedEvent != null)
                    {
                        kREDITORRowDeletedEvent(this, new KREDITORDataSet.KREDITORRowChangeEvent((KREDITORDataSet.KREDITORRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.KREDITORRowDeleting != null)
                {
                    KREDITORDataSet.KREDITORRowChangeEventHandler kREDITORRowDeletingEvent = this.KREDITORRowDeleting;
                    if (kREDITORRowDeletingEvent != null)
                    {
                        kREDITORRowDeletingEvent(this, new KREDITORDataSet.KREDITORRowChangeEvent((KREDITORDataSet.KREDITORRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveKREDITORRow(KREDITORDataSet.KREDITORRow row)
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

            public DataColumn IDKREDITORColumn
            {
                get
                {
                    return this.columnIDKREDITOR;
                }
            }

            public KREDITORDataSet.KREDITORRow this[int index]
            {
                get
                {
                    return (KREDITORDataSet.KREDITORRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVKREDITORColumn
            {
                get
                {
                    return this.columnNAZIVKREDITOR;
                }
            }

            public DataColumn PRIMATELJKREDITOR1Column
            {
                get
                {
                    return this.columnPRIMATELJKREDITOR1;
                }
            }

            public DataColumn PRIMATELJKREDITOR2Column
            {
                get
                {
                    return this.columnPRIMATELJKREDITOR2;
                }
            }

            public DataColumn PRIMATELJKREDITOR3Column
            {
                get
                {
                    return this.columnPRIMATELJKREDITOR3;
                }
            }

            public DataColumn VBDIKREDITORColumn
            {
                get
                {
                    return this.columnVBDIKREDITOR;
                }
            }

            public DataColumn ZRNKREDITORColumn
            {
                get
                {
                    return this.columnZRNKREDITOR;
                }
            }
        }

        public class KREDITORRow : DataRow
        {
            private KREDITORDataSet.KREDITORDataTable tableKREDITOR;

            internal KREDITORRow(DataRowBuilder rb) : base(rb)
            {
                this.tableKREDITOR = (KREDITORDataSet.KREDITORDataTable) this.Table;
            }

            public bool IsIDKREDITORNull()
            {
                return this.IsNull(this.tableKREDITOR.IDKREDITORColumn);
            }

            public bool IsNAZIVKREDITORNull()
            {
                return this.IsNull(this.tableKREDITOR.NAZIVKREDITORColumn);
            }

            public bool IsPRIMATELJKREDITOR1Null()
            {
                return this.IsNull(this.tableKREDITOR.PRIMATELJKREDITOR1Column);
            }

            public bool IsPRIMATELJKREDITOR2Null()
            {
                return this.IsNull(this.tableKREDITOR.PRIMATELJKREDITOR2Column);
            }

            public bool IsPRIMATELJKREDITOR3Null()
            {
                return this.IsNull(this.tableKREDITOR.PRIMATELJKREDITOR3Column);
            }

            public bool IsVBDIKREDITORNull()
            {
                return this.IsNull(this.tableKREDITOR.VBDIKREDITORColumn);
            }

            public bool IsZRNKREDITORNull()
            {
                return this.IsNull(this.tableKREDITOR.ZRNKREDITORColumn);
            }

            public void SetNAZIVKREDITORNull()
            {
                this[this.tableKREDITOR.NAZIVKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKREDITOR1Null()
            {
                this[this.tableKREDITOR.PRIMATELJKREDITOR1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKREDITOR2Null()
            {
                this[this.tableKREDITOR.PRIMATELJKREDITOR2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKREDITOR3Null()
            {
                this[this.tableKREDITOR.PRIMATELJKREDITOR3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIKREDITORNull()
            {
                this[this.tableKREDITOR.VBDIKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNKREDITORNull()
            {
                this[this.tableKREDITOR.ZRNKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDKREDITOR
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableKREDITOR.IDKREDITORColumn]);
                }
                set
                {
                    this[this.tableKREDITOR.IDKREDITORColumn] = value;
                }
            }

            public string NAZIVKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKREDITOR.NAZIVKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVKREDITOR because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableKREDITOR.NAZIVKREDITORColumn] = value;
                }
            }

            public string PRIMATELJKREDITOR1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKREDITOR.PRIMATELJKREDITOR1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PRIMATELJKREDITOR1 because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableKREDITOR.PRIMATELJKREDITOR1Column] = value;
                }
            }

            public string PRIMATELJKREDITOR2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKREDITOR.PRIMATELJKREDITOR2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PRIMATELJKREDITOR2 because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableKREDITOR.PRIMATELJKREDITOR2Column] = value;
                }
            }

            public string PRIMATELJKREDITOR3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKREDITOR.PRIMATELJKREDITOR3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PRIMATELJKREDITOR3 because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableKREDITOR.PRIMATELJKREDITOR3Column] = value;
                }
            }

            public string VBDIKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKREDITOR.VBDIKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value VBDIKREDITOR because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableKREDITOR.VBDIKREDITORColumn] = value;
                }
            }

            public string ZRNKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableKREDITOR.ZRNKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableKREDITOR.ZRNKREDITORColumn] = value;
                }
            }
        }

        public class KREDITORRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private KREDITORDataSet.KREDITORRow eventRow;

            public KREDITORRowChangeEvent(KREDITORDataSet.KREDITORRow row, DataRowAction action)
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

            public KREDITORDataSet.KREDITORRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void KREDITORRowChangeEventHandler(object sender, KREDITORDataSet.KREDITORRowChangeEvent e);
    }
}

