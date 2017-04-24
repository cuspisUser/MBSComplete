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
    public class S_OS_STANJE_LOKACIJADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OS_STANJE_LOKACIJADataTable tableS_OS_STANJE_LOKACIJA;

        public S_OS_STANJE_LOKACIJADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OS_STANJE_LOKACIJADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OS_STANJE_LOKACIJA"] != null)
                    {
                        this.Tables.Add(new S_OS_STANJE_LOKACIJADataTable(dataSet.Tables["S_OS_STANJE_LOKACIJA"]));
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
            S_OS_STANJE_LOKACIJADataSet set = (S_OS_STANJE_LOKACIJADataSet) base.Clone();
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
            S_OS_STANJE_LOKACIJADataSet set = new S_OS_STANJE_LOKACIJADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OS_STANJE_LOKACIJADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2155");
            this.ExtendedProperties.Add("DataSetName", "S_OS_STANJE_LOKACIJADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OS_STANJE_LOKACIJADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OS_STANJE_LOKACIJA");
            this.ExtendedProperties.Add("ObjectDescription", "S_OS_STANJE_LOKACIJA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\OSNOVNA");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_OS_STANJE_LOKACIJA");
            this.ExtendedProperties.Add("Deklarit.GroupByAttributes", "");
            this.ExtendedProperties.Add("Deklarit.GenerateCRUDForDP", "false");
            this.ExtendedProperties.Add("Deklarit.ExtendedView", "false");
            this.ExtendedProperties.Add("Deklarit.ShowGroupByDP", "True");
            this.ExtendedProperties.Add("Deklarit.UseSuggestInFK", "False");
            this.ExtendedProperties.Add("Deklarit.BCForNewOption", "");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "S_OS_STANJE_LOKACIJADataSet";
            this.Namespace = "http://www.tempuri.org/S_OS_STANJE_LOKACIJA";
            this.tableS_OS_STANJE_LOKACIJA = new S_OS_STANJE_LOKACIJADataTable();
            this.Tables.Add(this.tableS_OS_STANJE_LOKACIJA);
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
            this.tableS_OS_STANJE_LOKACIJA = (S_OS_STANJE_LOKACIJADataTable) this.Tables["S_OS_STANJE_LOKACIJA"];
            if (initTable && (this.tableS_OS_STANJE_LOKACIJA != null))
            {
                this.tableS_OS_STANJE_LOKACIJA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OS_STANJE_LOKACIJA"] != null)
                {
                    this.Tables.Add(new S_OS_STANJE_LOKACIJADataTable(dataSet.Tables["S_OS_STANJE_LOKACIJA"]));
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

        private bool ShouldSerializeS_OS_STANJE_LOKACIJA()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public S_OS_STANJE_LOKACIJADataTable S_OS_STANJE_LOKACIJA
        {
            get
            {
                return this.tableS_OS_STANJE_LOKACIJA;
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
        public class S_OS_STANJE_LOKACIJADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDLOKACIJE;
            private DataColumn columnINVBROJ;
            private DataColumn columnIZLAZ;
            private DataColumn columnOPISLOKACIJE;
            private DataColumn columnSTANJE;
            private DataColumn columnULAZ;

            public event S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARowChangeEventHandler S_OS_STANJE_LOKACIJARowChanged;

            public event S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARowChangeEventHandler S_OS_STANJE_LOKACIJARowChanging;

            public event S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARowChangeEventHandler S_OS_STANJE_LOKACIJARowDeleted;

            public event S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARowChangeEventHandler S_OS_STANJE_LOKACIJARowDeleting;

            public S_OS_STANJE_LOKACIJADataTable()
            {
                this.TableName = "S_OS_STANJE_LOKACIJA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OS_STANJE_LOKACIJADataTable(DataTable table) : base(table.TableName)
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

            protected S_OS_STANJE_LOKACIJADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OS_STANJE_LOKACIJARow(S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow row)
            {
                this.Rows.Add(row);
            }

            public S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow AddS_OS_STANJE_LOKACIJARow(int iDLOKACIJE, long iNVBROJ, decimal uLAZ, decimal iZLAZ, decimal sTANJE, string oPISLOKACIJE)
            {
                S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow row = (S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow) this.NewRow();
                row.ItemArray = new object[] { iDLOKACIJE, iNVBROJ, uLAZ, iZLAZ, sTANJE, oPISLOKACIJE };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJADataTable table = (S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OS_STANJE_LOKACIJADataSet set = new S_OS_STANJE_LOKACIJADataSet();
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
                this.columnIDLOKACIJE = new DataColumn("IDLOKACIJE", typeof(int), "", MappingType.Element);
                this.columnIDLOKACIJE.Caption = "Šif.lok.";
                this.columnIDLOKACIJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDLOKACIJE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDLOKACIJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDLOKACIJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Description", "Šif.lok.");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Length", "5");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDLOKACIJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDLOKACIJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.InternalName", "IDLOKACIJE");
                this.Columns.Add(this.columnIDLOKACIJE);
                this.columnINVBROJ = new DataColumn("INVBROJ", typeof(long), "", MappingType.Element);
                this.columnINVBROJ.Caption = "Inventarni broj";
                this.columnINVBROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnINVBROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnINVBROJ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnINVBROJ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnINVBROJ.ExtendedProperties.Add("Description", "Inventarni");
                this.columnINVBROJ.ExtendedProperties.Add("Length", "12");
                this.columnINVBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnINVBROJ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnINVBROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.InternalName", "INVBROJ");
                this.Columns.Add(this.columnINVBROJ);
                this.columnULAZ = new DataColumn("ULAZ", typeof(decimal), "", MappingType.Element);
                this.columnULAZ.Caption = "Ulaz";
                this.columnULAZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnULAZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnULAZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnULAZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnULAZ.ExtendedProperties.Add("IsKey", "false");
                this.columnULAZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnULAZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnULAZ.ExtendedProperties.Add("Description", "Ulaz");
                this.columnULAZ.ExtendedProperties.Add("Length", "12");
                this.columnULAZ.ExtendedProperties.Add("Decimals", "2");
                this.columnULAZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnULAZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnULAZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnULAZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnULAZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnULAZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnULAZ.ExtendedProperties.Add("Deklarit.InternalName", "ULAZ");
                this.Columns.Add(this.columnULAZ);
                this.columnIZLAZ = new DataColumn("IZLAZ", typeof(decimal), "", MappingType.Element);
                this.columnIZLAZ.Caption = "Izlaz";
                this.columnIZLAZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZLAZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZLAZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZLAZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZLAZ.ExtendedProperties.Add("IsKey", "false");
                this.columnIZLAZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZLAZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZLAZ.ExtendedProperties.Add("Description", "Izlaz");
                this.columnIZLAZ.ExtendedProperties.Add("Length", "12");
                this.columnIZLAZ.ExtendedProperties.Add("Decimals", "2");
                this.columnIZLAZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZLAZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZLAZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZLAZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZLAZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZLAZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZLAZ.ExtendedProperties.Add("Deklarit.InternalName", "IZLAZ");
                this.Columns.Add(this.columnIZLAZ);
                this.columnSTANJE = new DataColumn("STANJE", typeof(decimal), "", MappingType.Element);
                this.columnSTANJE.Caption = "Stanje";
                this.columnSTANJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTANJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTANJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTANJE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTANJE.ExtendedProperties.Add("IsKey", "false");
                this.columnSTANJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTANJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTANJE.ExtendedProperties.Add("Description", "Stanje");
                this.columnSTANJE.ExtendedProperties.Add("Length", "12");
                this.columnSTANJE.ExtendedProperties.Add("Decimals", "2");
                this.columnSTANJE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTANJE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSTANJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTANJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTANJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTANJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTANJE.ExtendedProperties.Add("Deklarit.InternalName", "STANJE");
                this.Columns.Add(this.columnSTANJE);
                this.columnOPISLOKACIJE = new DataColumn("OPISLOKACIJE", typeof(string), "", MappingType.Element);
                this.columnOPISLOKACIJE.Caption = "Naz. lok.";
                this.columnOPISLOKACIJE.MaxLength = 50;
                this.columnOPISLOKACIJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Description", "Naz. lok.");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Length", "50");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.InternalName", "OPISLOKACIJE");
                this.Columns.Add(this.columnOPISLOKACIJE);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OS_STANJE_LOKACIJA");
                this.ExtendedProperties.Add("Description", "S_OS_STANJE_LOKACIJA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDLOKACIJE = this.Columns["IDLOKACIJE"];
                this.columnINVBROJ = this.Columns["INVBROJ"];
                this.columnULAZ = this.Columns["ULAZ"];
                this.columnIZLAZ = this.Columns["IZLAZ"];
                this.columnSTANJE = this.Columns["STANJE"];
                this.columnOPISLOKACIJE = this.Columns["OPISLOKACIJE"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow(builder);
            }

            public S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow NewS_OS_STANJE_LOKACIJARow()
            {
                return (S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OS_STANJE_LOKACIJARowChanged != null)
                {
                    S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARowChangeEventHandler handler = this.S_OS_STANJE_LOKACIJARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARowChangeEvent((S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OS_STANJE_LOKACIJARowChanging != null)
                {
                    S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARowChangeEventHandler handler = this.S_OS_STANJE_LOKACIJARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARowChangeEvent((S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OS_STANJE_LOKACIJARowDeleted != null)
                {
                    S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARowChangeEventHandler handler = this.S_OS_STANJE_LOKACIJARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARowChangeEvent((S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OS_STANJE_LOKACIJARowDeleting != null)
                {
                    S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARowChangeEventHandler handler = this.S_OS_STANJE_LOKACIJARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARowChangeEvent((S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OS_STANJE_LOKACIJARow(S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow row)
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

            public DataColumn INVBROJColumn
            {
                get
                {
                    return this.columnINVBROJ;
                }
            }

            public S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow this[int index]
            {
                get
                {
                    return (S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow) this.Rows[index];
                }
            }

            public DataColumn IZLAZColumn
            {
                get
                {
                    return this.columnIZLAZ;
                }
            }

            public DataColumn OPISLOKACIJEColumn
            {
                get
                {
                    return this.columnOPISLOKACIJE;
                }
            }

            public DataColumn STANJEColumn
            {
                get
                {
                    return this.columnSTANJE;
                }
            }

            public DataColumn ULAZColumn
            {
                get
                {
                    return this.columnULAZ;
                }
            }
        }

        public class S_OS_STANJE_LOKACIJARow : DataRow
        {
            private S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJADataTable tableS_OS_STANJE_LOKACIJA;

            internal S_OS_STANJE_LOKACIJARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OS_STANJE_LOKACIJA = (S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJADataTable) this.Table;
            }

            public bool IsIDLOKACIJENull()
            {
                return this.IsNull(this.tableS_OS_STANJE_LOKACIJA.IDLOKACIJEColumn);
            }

            public bool IsINVBROJNull()
            {
                return this.IsNull(this.tableS_OS_STANJE_LOKACIJA.INVBROJColumn);
            }

            public bool IsIZLAZNull()
            {
                return this.IsNull(this.tableS_OS_STANJE_LOKACIJA.IZLAZColumn);
            }

            public bool IsOPISLOKACIJENull()
            {
                return this.IsNull(this.tableS_OS_STANJE_LOKACIJA.OPISLOKACIJEColumn);
            }

            public bool IsSTANJENull()
            {
                return this.IsNull(this.tableS_OS_STANJE_LOKACIJA.STANJEColumn);
            }

            public bool IsULAZNull()
            {
                return this.IsNull(this.tableS_OS_STANJE_LOKACIJA.ULAZColumn);
            }

            public void SetIDLOKACIJENull()
            {
                this[this.tableS_OS_STANJE_LOKACIJA.IDLOKACIJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetINVBROJNull()
            {
                this[this.tableS_OS_STANJE_LOKACIJA.INVBROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZLAZNull()
            {
                this[this.tableS_OS_STANJE_LOKACIJA.IZLAZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISLOKACIJENull()
            {
                this[this.tableS_OS_STANJE_LOKACIJA.OPISLOKACIJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTANJENull()
            {
                this[this.tableS_OS_STANJE_LOKACIJA.STANJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetULAZNull()
            {
                this[this.tableS_OS_STANJE_LOKACIJA.ULAZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDLOKACIJE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OS_STANJE_LOKACIJA.IDLOKACIJEColumn]);
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
                    this[this.tableS_OS_STANJE_LOKACIJA.IDLOKACIJEColumn] = value;
                }
            }

            public long INVBROJ
            {
                get
                {
                    long num;
                    try
                    {
                        num = Conversions.ToLong(this[this.tableS_OS_STANJE_LOKACIJA.INVBROJColumn]);
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
                    this[this.tableS_OS_STANJE_LOKACIJA.INVBROJColumn] = value;
                }
            }

            public decimal IZLAZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_STANJE_LOKACIJA.IZLAZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IZLAZ because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_STANJE_LOKACIJA.IZLAZColumn] = value;
                }
            }

            public string OPISLOKACIJE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_STANJE_LOKACIJA.OPISLOKACIJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OPISLOKACIJE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OS_STANJE_LOKACIJA.OPISLOKACIJEColumn] = value;
                }
            }

            public decimal STANJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_STANJE_LOKACIJA.STANJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value STANJE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_STANJE_LOKACIJA.STANJEColumn] = value;
                }
            }

            public decimal ULAZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_STANJE_LOKACIJA.ULAZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ULAZ because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_STANJE_LOKACIJA.ULAZColumn] = value;
                }
            }
        }

        public class S_OS_STANJE_LOKACIJARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow eventRow;

            public S_OS_STANJE_LOKACIJARowChangeEvent(S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow row, DataRowAction action)
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

            public S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OS_STANJE_LOKACIJARowChangeEventHandler(object sender, S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARowChangeEvent e);
    }
}

