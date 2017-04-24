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
    public class OSRAZMJESTAJDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private OSRAZMJESTAJDataTable tableOSRAZMJESTAJ;

        public OSRAZMJESTAJDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected OSRAZMJESTAJDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["OSRAZMJESTAJ"] != null)
                    {
                        this.Tables.Add(new OSRAZMJESTAJDataTable(dataSet.Tables["OSRAZMJESTAJ"]));
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
            OSRAZMJESTAJDataSet set = (OSRAZMJESTAJDataSet) base.Clone();
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
            OSRAZMJESTAJDataSet set = new OSRAZMJESTAJDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "OSRAZMJESTAJDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2154");
            this.ExtendedProperties.Add("DataSetName", "OSRAZMJESTAJDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IOSRAZMJESTAJDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "OSRAZMJESTAJ");
            this.ExtendedProperties.Add("ObjectDescription", "OSRAZMJESTAJ");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\OSNOVNA");
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
            this.DataSetName = "OSRAZMJESTAJDataSet";
            this.Namespace = "http://www.tempuri.org/OSRAZMJESTAJ";
            this.tableOSRAZMJESTAJ = new OSRAZMJESTAJDataTable();
            this.Tables.Add(this.tableOSRAZMJESTAJ);
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
            this.tableOSRAZMJESTAJ = (OSRAZMJESTAJDataTable) this.Tables["OSRAZMJESTAJ"];
            if (initTable && (this.tableOSRAZMJESTAJ != null))
            {
                this.tableOSRAZMJESTAJ.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["OSRAZMJESTAJ"] != null)
                {
                    this.Tables.Add(new OSRAZMJESTAJDataTable(dataSet.Tables["OSRAZMJESTAJ"]));
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

        private bool ShouldSerializeOSRAZMJESTAJ()
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
        public OSRAZMJESTAJDataTable OSRAZMJESTAJ
        {
            get
            {
                return this.tableOSRAZMJESTAJ;
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
        public class OSRAZMJESTAJDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDLOKACIJE;
            private DataColumn columnIDOSRAZMJESTAJ;
            private DataColumn columnINVBROJ;
            private DataColumn columnKOLICINARASHODA;
            private DataColumn columnKOLICINAULAZA;

            public event OSRAZMJESTAJDataSet.OSRAZMJESTAJRowChangeEventHandler OSRAZMJESTAJRowChanged;

            public event OSRAZMJESTAJDataSet.OSRAZMJESTAJRowChangeEventHandler OSRAZMJESTAJRowChanging;

            public event OSRAZMJESTAJDataSet.OSRAZMJESTAJRowChangeEventHandler OSRAZMJESTAJRowDeleted;

            public event OSRAZMJESTAJDataSet.OSRAZMJESTAJRowChangeEventHandler OSRAZMJESTAJRowDeleting;

            public OSRAZMJESTAJDataTable()
            {
                this.TableName = "OSRAZMJESTAJ";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OSRAZMJESTAJDataTable(DataTable table) : base(table.TableName)
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

            protected OSRAZMJESTAJDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOSRAZMJESTAJRow(OSRAZMJESTAJDataSet.OSRAZMJESTAJRow row)
            {
                this.Rows.Add(row);
            }

            public OSRAZMJESTAJDataSet.OSRAZMJESTAJRow AddOSRAZMJESTAJRow(int iDLOKACIJE, long iNVBROJ, decimal kOLICINAULAZA, decimal kOLICINARASHODA)
            {
                OSRAZMJESTAJDataSet.OSRAZMJESTAJRow row = (OSRAZMJESTAJDataSet.OSRAZMJESTAJRow) this.NewRow();
                row["IDLOKACIJE"] = iDLOKACIJE;
                row["INVBROJ"] = iNVBROJ;
                row["KOLICINAULAZA"] = kOLICINAULAZA;
                row["KOLICINARASHODA"] = kOLICINARASHODA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OSRAZMJESTAJDataSet.OSRAZMJESTAJDataTable table = (OSRAZMJESTAJDataSet.OSRAZMJESTAJDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OSRAZMJESTAJDataSet.OSRAZMJESTAJRow FindByIDOSRAZMJESTAJ(Guid iDOSRAZMJESTAJ)
            {
                return (OSRAZMJESTAJDataSet.OSRAZMJESTAJRow) this.Rows.Find(new object[] { iDOSRAZMJESTAJ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OSRAZMJESTAJDataSet.OSRAZMJESTAJRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OSRAZMJESTAJDataSet set = new OSRAZMJESTAJDataSet();
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
                this.columnIDOSRAZMJESTAJ = new DataColumn("IDOSRAZMJESTAJ", typeof(Guid), "", MappingType.Element);
                this.columnIDOSRAZMJESTAJ.AllowDBNull = false;
                this.columnIDOSRAZMJESTAJ.Caption = "IDOSRAZMJESTAJ";
                this.columnIDOSRAZMJESTAJ.Unique = true;
                this.columnIDOSRAZMJESTAJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("AutoGenerated", "true");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("DeklaritType", "guid");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("Description", "IDOSRAZMJESTAJ");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("Length", "32");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOSRAZMJESTAJ.ExtendedProperties.Add("Deklarit.InternalName", "IDOSRAZMJESTAJ");
                this.Columns.Add(this.columnIDOSRAZMJESTAJ);
                this.columnIDLOKACIJE = new DataColumn("IDLOKACIJE", typeof(int), "", MappingType.Element);
                this.columnIDLOKACIJE.AllowDBNull = false;
                this.columnIDLOKACIJE.Caption = "Šif.lok.";
                this.columnIDLOKACIJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDLOKACIJE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDLOKACIJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDLOKACIJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Description", "Lokacija");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Length", "5");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDLOKACIJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDLOKACIJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.InternalName", "IDLOKACIJE");
                this.Columns.Add(this.columnIDLOKACIJE);
                this.columnINVBROJ = new DataColumn("INVBROJ", typeof(long), "", MappingType.Element);
                this.columnINVBROJ.AllowDBNull = false;
                this.columnINVBROJ.Caption = "Inventarni broj";
                this.columnINVBROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnINVBROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnINVBROJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnINVBROJ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnINVBROJ.ExtendedProperties.Add("Description", "Inventarni broj");
                this.columnINVBROJ.ExtendedProperties.Add("Length", "12");
                this.columnINVBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnINVBROJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnINVBROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.InternalName", "INVBROJ");
                this.Columns.Add(this.columnINVBROJ);
                this.columnKOLICINAULAZA = new DataColumn("KOLICINAULAZA", typeof(decimal), "", MappingType.Element);
                this.columnKOLICINAULAZA.AllowDBNull = false;
                this.columnKOLICINAULAZA.Caption = "KOLICINAULAZA";
                this.columnKOLICINAULAZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOLICINAULAZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("IsKey", "false");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("Description", "Količina ulaza");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("Length", "12");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("Decimals", "2");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOLICINAULAZA.ExtendedProperties.Add("Deklarit.InternalName", "KOLICINAULAZA");
                this.Columns.Add(this.columnKOLICINAULAZA);
                this.columnKOLICINARASHODA = new DataColumn("KOLICINARASHODA", typeof(decimal), "", MappingType.Element);
                this.columnKOLICINARASHODA.AllowDBNull = false;
                this.columnKOLICINARASHODA.Caption = "KOLICINARASHODA";
                this.columnKOLICINARASHODA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOLICINARASHODA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("IsKey", "false");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("Description", "Količina rashoda");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("Length", "12");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("Decimals", "2");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOLICINARASHODA.ExtendedProperties.Add("Deklarit.InternalName", "KOLICINARASHODA");
                this.Columns.Add(this.columnKOLICINARASHODA);
                this.PrimaryKey = new DataColumn[] { this.columnIDOSRAZMJESTAJ };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "OSRAZMJESTAJ");
                this.ExtendedProperties.Add("Description", "OSRAZMJESTAJ");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDOSRAZMJESTAJ = this.Columns["IDOSRAZMJESTAJ"];
                this.columnIDLOKACIJE = this.Columns["IDLOKACIJE"];
                this.columnINVBROJ = this.Columns["INVBROJ"];
                this.columnKOLICINAULAZA = this.Columns["KOLICINAULAZA"];
                this.columnKOLICINARASHODA = this.Columns["KOLICINARASHODA"];
            }

            public OSRAZMJESTAJDataSet.OSRAZMJESTAJRow NewOSRAZMJESTAJRow()
            {
                return (OSRAZMJESTAJDataSet.OSRAZMJESTAJRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OSRAZMJESTAJDataSet.OSRAZMJESTAJRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OSRAZMJESTAJRowChanged != null)
                {
                    OSRAZMJESTAJDataSet.OSRAZMJESTAJRowChangeEventHandler oSRAZMJESTAJRowChangedEvent = this.OSRAZMJESTAJRowChanged;
                    if (oSRAZMJESTAJRowChangedEvent != null)
                    {
                        oSRAZMJESTAJRowChangedEvent(this, new OSRAZMJESTAJDataSet.OSRAZMJESTAJRowChangeEvent((OSRAZMJESTAJDataSet.OSRAZMJESTAJRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OSRAZMJESTAJRowChanging != null)
                {
                    OSRAZMJESTAJDataSet.OSRAZMJESTAJRowChangeEventHandler oSRAZMJESTAJRowChangingEvent = this.OSRAZMJESTAJRowChanging;
                    if (oSRAZMJESTAJRowChangingEvent != null)
                    {
                        oSRAZMJESTAJRowChangingEvent(this, new OSRAZMJESTAJDataSet.OSRAZMJESTAJRowChangeEvent((OSRAZMJESTAJDataSet.OSRAZMJESTAJRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.OSRAZMJESTAJRowDeleted != null)
                {
                    OSRAZMJESTAJDataSet.OSRAZMJESTAJRowChangeEventHandler oSRAZMJESTAJRowDeletedEvent = this.OSRAZMJESTAJRowDeleted;
                    if (oSRAZMJESTAJRowDeletedEvent != null)
                    {
                        oSRAZMJESTAJRowDeletedEvent(this, new OSRAZMJESTAJDataSet.OSRAZMJESTAJRowChangeEvent((OSRAZMJESTAJDataSet.OSRAZMJESTAJRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OSRAZMJESTAJRowDeleting != null)
                {
                    OSRAZMJESTAJDataSet.OSRAZMJESTAJRowChangeEventHandler oSRAZMJESTAJRowDeletingEvent = this.OSRAZMJESTAJRowDeleting;
                    if (oSRAZMJESTAJRowDeletingEvent != null)
                    {
                        oSRAZMJESTAJRowDeletingEvent(this, new OSRAZMJESTAJDataSet.OSRAZMJESTAJRowChangeEvent((OSRAZMJESTAJDataSet.OSRAZMJESTAJRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOSRAZMJESTAJRow(OSRAZMJESTAJDataSet.OSRAZMJESTAJRow row)
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

            public DataColumn IDLOKACIJEColumn
            {
                get
                {
                    return this.columnIDLOKACIJE;
                }
            }

            public DataColumn IDOSRAZMJESTAJColumn
            {
                get
                {
                    return this.columnIDOSRAZMJESTAJ;
                }
            }

            public DataColumn INVBROJColumn
            {
                get
                {
                    return this.columnINVBROJ;
                }
            }

            public OSRAZMJESTAJDataSet.OSRAZMJESTAJRow this[int index]
            {
                get
                {
                    return (OSRAZMJESTAJDataSet.OSRAZMJESTAJRow) this.Rows[index];
                }
            }

            public DataColumn KOLICINARASHODAColumn
            {
                get
                {
                    return this.columnKOLICINARASHODA;
                }
            }

            public DataColumn KOLICINAULAZAColumn
            {
                get
                {
                    return this.columnKOLICINAULAZA;
                }
            }
        }

        public class OSRAZMJESTAJRow : DataRow
        {
            private OSRAZMJESTAJDataSet.OSRAZMJESTAJDataTable tableOSRAZMJESTAJ;

            internal OSRAZMJESTAJRow(DataRowBuilder rb) : base(rb)
            {
                this.tableOSRAZMJESTAJ = (OSRAZMJESTAJDataSet.OSRAZMJESTAJDataTable) this.Table;
                this.IDOSRAZMJESTAJ = Guid.NewGuid();
            }

            public bool IsIDLOKACIJENull()
            {
                return this.IsNull(this.tableOSRAZMJESTAJ.IDLOKACIJEColumn);
            }

            public bool IsIDOSRAZMJESTAJNull()
            {
                return this.IsNull(this.tableOSRAZMJESTAJ.IDOSRAZMJESTAJColumn);
            }

            public bool IsINVBROJNull()
            {
                return this.IsNull(this.tableOSRAZMJESTAJ.INVBROJColumn);
            }

            public bool IsKOLICINARASHODANull()
            {
                return this.IsNull(this.tableOSRAZMJESTAJ.KOLICINARASHODAColumn);
            }

            public bool IsKOLICINAULAZANull()
            {
                return this.IsNull(this.tableOSRAZMJESTAJ.KOLICINAULAZAColumn);
            }

            public void SetIDLOKACIJENull()
            {
                this[this.tableOSRAZMJESTAJ.IDLOKACIJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetINVBROJNull()
            {
                this[this.tableOSRAZMJESTAJ.INVBROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOLICINARASHODANull()
            {
                this[this.tableOSRAZMJESTAJ.KOLICINARASHODAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOLICINAULAZANull()
            {
                this[this.tableOSRAZMJESTAJ.KOLICINAULAZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDLOKACIJE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableOSRAZMJESTAJ.IDLOKACIJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDLOKACIJE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableOSRAZMJESTAJ.IDLOKACIJEColumn] = value;
                }
            }

            public Guid IDOSRAZMJESTAJ
            {
                get
                {
                    object obj1 = this[this.tableOSRAZMJESTAJ.IDOSRAZMJESTAJColumn];
                    if (obj1 == null)
                    {
                        Guid guid2 = new Guid();
                        return guid2;
                    }
                    return (Guid) obj1;
                }
                set
                {
                    this[this.tableOSRAZMJESTAJ.IDOSRAZMJESTAJColumn] = value;
                }
            }

            public long INVBROJ
            {
                get
                {
                    long num;
                    try
                    {
                        num = Conversions.ToLong(this[this.tableOSRAZMJESTAJ.INVBROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value INVBROJ because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableOSRAZMJESTAJ.INVBROJColumn] = value;
                }
            }

            public decimal KOLICINARASHODA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOSRAZMJESTAJ.KOLICINARASHODAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value KOLICINARASHODA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableOSRAZMJESTAJ.KOLICINARASHODAColumn] = value;
                }
            }

            public decimal KOLICINAULAZA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOSRAZMJESTAJ.KOLICINAULAZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value KOLICINAULAZA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableOSRAZMJESTAJ.KOLICINAULAZAColumn] = value;
                }
            }
        }

        public class OSRAZMJESTAJRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OSRAZMJESTAJDataSet.OSRAZMJESTAJRow eventRow;

            public OSRAZMJESTAJRowChangeEvent(OSRAZMJESTAJDataSet.OSRAZMJESTAJRow row, DataRowAction action)
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

            public OSRAZMJESTAJDataSet.OSRAZMJESTAJRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OSRAZMJESTAJRowChangeEventHandler(object sender, OSRAZMJESTAJDataSet.OSRAZMJESTAJRowChangeEvent e);
    }
}

