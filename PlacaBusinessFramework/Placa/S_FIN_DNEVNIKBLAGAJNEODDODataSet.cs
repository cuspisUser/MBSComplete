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
    public class S_FIN_DNEVNIKBLAGAJNEODDODataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_FIN_DNEVNIKBLAGAJNEODDODataTable tableS_FIN_DNEVNIKBLAGAJNEODDO;

        public S_FIN_DNEVNIKBLAGAJNEODDODataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_FIN_DNEVNIKBLAGAJNEODDODataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_FIN_DNEVNIKBLAGAJNEODDO"] != null)
                    {
                        this.Tables.Add(new S_FIN_DNEVNIKBLAGAJNEODDODataTable(dataSet.Tables["S_FIN_DNEVNIKBLAGAJNEODDO"]));
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
            S_FIN_DNEVNIKBLAGAJNEODDODataSet set = (S_FIN_DNEVNIKBLAGAJNEODDODataSet) base.Clone();
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
            S_FIN_DNEVNIKBLAGAJNEODDODataSet set = new S_FIN_DNEVNIKBLAGAJNEODDODataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_FIN_DNEVNIKBLAGAJNEODDODataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2042");
            this.ExtendedProperties.Add("DataSetName", "S_FIN_DNEVNIKBLAGAJNEODDODataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_FIN_DNEVNIKBLAGAJNEODDODataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_FIN_DNEVNIKBLAGAJNEODDO");
            this.ExtendedProperties.Add("ObjectDescription", "S_FIN_DNEVNIKBLAGAJNEODDO");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_FIN_DNEVNIKBLAGAJNEOdDo");
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
            this.DataSetName = "S_FIN_DNEVNIKBLAGAJNEODDODataSet";
            this.Namespace = "http://www.tempuri.org/S_FIN_DNEVNIKBLAGAJNEODDO";
            this.tableS_FIN_DNEVNIKBLAGAJNEODDO = new S_FIN_DNEVNIKBLAGAJNEODDODataTable();
            this.Tables.Add(this.tableS_FIN_DNEVNIKBLAGAJNEODDO);
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
            this.tableS_FIN_DNEVNIKBLAGAJNEODDO = (S_FIN_DNEVNIKBLAGAJNEODDODataTable) this.Tables["S_FIN_DNEVNIKBLAGAJNEODDO"];
            if (initTable && (this.tableS_FIN_DNEVNIKBLAGAJNEODDO != null))
            {
                this.tableS_FIN_DNEVNIKBLAGAJNEODDO.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_FIN_DNEVNIKBLAGAJNEODDO"] != null)
                {
                    this.Tables.Add(new S_FIN_DNEVNIKBLAGAJNEODDODataTable(dataSet.Tables["S_FIN_DNEVNIKBLAGAJNEODDO"]));
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

        private bool ShouldSerializeS_FIN_DNEVNIKBLAGAJNEODDO()
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
        public S_FIN_DNEVNIKBLAGAJNEODDODataTable S_FIN_DNEVNIKBLAGAJNEODDO
        {
            get
            {
                return this.tableS_FIN_DNEVNIKBLAGAJNEODDO;
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
        public class S_FIN_DNEVNIKBLAGAJNEODDODataTable : DataTable, IEnumerable
        {
            private DataColumn columnBLGBROJDOKUMENTA;
            private DataColumn columnBLGDATUMDOKUMENTA;
            private DataColumn columnBLGSLOVIMA;
            private DataColumn columnBLGSVRHA;
            private DataColumn columnIDBLGVRSTEDOK;
            private DataColumn columnIZDATAK;
            private DataColumn columnKONTA;
            private DataColumn columnNAZIVVRSTEDOK;
            private DataColumn columnPRIMITAK;

            public event S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORowChangeEventHandler S_FIN_DNEVNIKBLAGAJNEODDORowChanged;

            public event S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORowChangeEventHandler S_FIN_DNEVNIKBLAGAJNEODDORowChanging;

            public event S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORowChangeEventHandler S_FIN_DNEVNIKBLAGAJNEODDORowDeleted;

            public event S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORowChangeEventHandler S_FIN_DNEVNIKBLAGAJNEODDORowDeleting;

            public S_FIN_DNEVNIKBLAGAJNEODDODataTable()
            {
                this.TableName = "S_FIN_DNEVNIKBLAGAJNEODDO";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_FIN_DNEVNIKBLAGAJNEODDODataTable(DataTable table) : base(table.TableName)
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

            protected S_FIN_DNEVNIKBLAGAJNEODDODataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_FIN_DNEVNIKBLAGAJNEODDORow(S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow row)
            {
                this.Rows.Add(row);
            }

            public S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow AddS_FIN_DNEVNIKBLAGAJNEODDORow(string nAZIVVRSTEDOK, DateTime bLGDATUMDOKUMENTA, int bLGBROJDOKUMENTA, int iDBLGVRSTEDOK, string bLGSVRHA, decimal pRIMITAK, decimal iZDATAK, string bLGSLOVIMA, string kONTA)
            {
                S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow row = (S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow) this.NewRow();
                row.ItemArray = new object[] { nAZIVVRSTEDOK, bLGDATUMDOKUMENTA, bLGBROJDOKUMENTA, iDBLGVRSTEDOK, bLGSVRHA, pRIMITAK, iZDATAK, bLGSLOVIMA, kONTA };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDODataTable table = (S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDODataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_FIN_DNEVNIKBLAGAJNEODDODataSet set = new S_FIN_DNEVNIKBLAGAJNEODDODataSet();
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
                this.columnNAZIVVRSTEDOK = new DataColumn("NAZIVVRSTEDOK", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTEDOK.Caption = "NAZIVVRSTEDOK";
                this.columnNAZIVVRSTEDOK.MaxLength = 30;
                this.columnNAZIVVRSTEDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Description", "NAZIVVRSTEDOK");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Length", "30");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTEDOK");
                this.Columns.Add(this.columnNAZIVVRSTEDOK);
                this.columnBLGDATUMDOKUMENTA = new DataColumn("BLGDATUMDOKUMENTA", typeof(DateTime), "", MappingType.Element);
                this.columnBLGDATUMDOKUMENTA.Caption = "BLGDATUMDOKUMENTA";
                this.columnBLGDATUMDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Description", "BLGDATUMDOKUMENTA");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Length", "8");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "BLGDATUMDOKUMENTA");
                this.Columns.Add(this.columnBLGDATUMDOKUMENTA);
                this.columnBLGBROJDOKUMENTA = new DataColumn("BLGBROJDOKUMENTA", typeof(int), "", MappingType.Element);
                this.columnBLGBROJDOKUMENTA.Caption = "BLGBROJDOKUMENTA";
                this.columnBLGBROJDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Description", "BLGBROJDOKUMENTA");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Length", "8");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "BLGBROJDOKUMENTA");
                this.Columns.Add(this.columnBLGBROJDOKUMENTA);
                this.columnIDBLGVRSTEDOK = new DataColumn("IDBLGVRSTEDOK", typeof(int), "", MappingType.Element);
                this.columnIDBLGVRSTEDOK.Caption = "IDBLGVRSTEDOK";
                this.columnIDBLGVRSTEDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("IsKey", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Description", "IDBLGVRSTEDOK");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Length", "5");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.InternalName", "IDBLGVRSTEDOK");
                this.Columns.Add(this.columnIDBLGVRSTEDOK);
                this.columnBLGSVRHA = new DataColumn("BLGSVRHA", typeof(string), "", MappingType.Element);
                this.columnBLGSVRHA.Caption = "BLGSVRHA";
                this.columnBLGSVRHA.MaxLength = 100;
                this.columnBLGSVRHA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBLGSVRHA.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGSVRHA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGSVRHA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBLGSVRHA.ExtendedProperties.Add("Description", "BLGSVRHA");
                this.columnBLGSVRHA.ExtendedProperties.Add("Length", "100");
                this.columnBLGSVRHA.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGSVRHA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBLGSVRHA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGSVRHA.ExtendedProperties.Add("Deklarit.InternalName", "BLGSVRHA");
                this.Columns.Add(this.columnBLGSVRHA);
                this.columnPRIMITAK = new DataColumn("PRIMITAK", typeof(decimal), "", MappingType.Element);
                this.columnPRIMITAK.Caption = "PRIMITAK";
                this.columnPRIMITAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMITAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMITAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMITAK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRIMITAK.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMITAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMITAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRIMITAK.ExtendedProperties.Add("Description", "PRIMITAK");
                this.columnPRIMITAK.ExtendedProperties.Add("Length", "12");
                this.columnPRIMITAK.ExtendedProperties.Add("Decimals", "2");
                this.columnPRIMITAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRIMITAK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPRIMITAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMITAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMITAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMITAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMITAK.ExtendedProperties.Add("Deklarit.InternalName", "PRIMITAK");
                this.Columns.Add(this.columnPRIMITAK);
                this.columnIZDATAK = new DataColumn("IZDATAK", typeof(decimal), "", MappingType.Element);
                this.columnIZDATAK.Caption = "IZDATAK";
                this.columnIZDATAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZDATAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZDATAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZDATAK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZDATAK.ExtendedProperties.Add("IsKey", "false");
                this.columnIZDATAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZDATAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZDATAK.ExtendedProperties.Add("Description", "IZDATAK");
                this.columnIZDATAK.ExtendedProperties.Add("Length", "12");
                this.columnIZDATAK.ExtendedProperties.Add("Decimals", "2");
                this.columnIZDATAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZDATAK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZDATAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZDATAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZDATAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZDATAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZDATAK.ExtendedProperties.Add("Deklarit.InternalName", "IZDATAK");
                this.Columns.Add(this.columnIZDATAK);
                this.columnBLGSLOVIMA = new DataColumn("BLGSLOVIMA", typeof(string), "", MappingType.Element);
                this.columnBLGSLOVIMA.Caption = "BLGSLOVIMA";
                this.columnBLGSLOVIMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGSLOVIMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGSLOVIMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGSLOVIMA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBLGSLOVIMA.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGSLOVIMA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGSLOVIMA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBLGSLOVIMA.ExtendedProperties.Add("Description", "BLGSLOVIMA");
                this.columnBLGSLOVIMA.ExtendedProperties.Add("Length", "400");
                this.columnBLGSLOVIMA.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGSLOVIMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBLGSLOVIMA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBLGSLOVIMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGSLOVIMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGSLOVIMA.ExtendedProperties.Add("Deklarit.InternalName", "BLGSLOVIMA");
                this.Columns.Add(this.columnBLGSLOVIMA);
                this.columnKONTA = new DataColumn("KONTA", typeof(string), "", MappingType.Element);
                this.columnKONTA.Caption = "KONTA";
                this.columnKONTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKONTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKONTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKONTA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKONTA.ExtendedProperties.Add("IsKey", "false");
                this.columnKONTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKONTA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKONTA.ExtendedProperties.Add("Description", "KONTA");
                this.columnKONTA.ExtendedProperties.Add("Length", "1000");
                this.columnKONTA.ExtendedProperties.Add("Decimals", "0");
                this.columnKONTA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKONTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnKONTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKONTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKONTA.ExtendedProperties.Add("Deklarit.InternalName", "KONTA");
                this.Columns.Add(this.columnKONTA);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_FIN_DNEVNIKBLAGAJNEODDO");
                this.ExtendedProperties.Add("Description", "S_FIN_DNEVNIKBLAGAJNEODDO");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnNAZIVVRSTEDOK = this.Columns["NAZIVVRSTEDOK"];
                this.columnBLGDATUMDOKUMENTA = this.Columns["BLGDATUMDOKUMENTA"];
                this.columnBLGBROJDOKUMENTA = this.Columns["BLGBROJDOKUMENTA"];
                this.columnIDBLGVRSTEDOK = this.Columns["IDBLGVRSTEDOK"];
                this.columnBLGSVRHA = this.Columns["BLGSVRHA"];
                this.columnPRIMITAK = this.Columns["PRIMITAK"];
                this.columnIZDATAK = this.Columns["IZDATAK"];
                this.columnBLGSLOVIMA = this.Columns["BLGSLOVIMA"];
                this.columnKONTA = this.Columns["KONTA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow(builder);
            }

            public S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow NewS_FIN_DNEVNIKBLAGAJNEODDORow()
            {
                return (S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_FIN_DNEVNIKBLAGAJNEODDORowChanged != null)
                {
                    S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORowChangeEventHandler handler = this.S_FIN_DNEVNIKBLAGAJNEODDORowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORowChangeEvent((S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_FIN_DNEVNIKBLAGAJNEODDORowChanging != null)
                {
                    S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORowChangeEventHandler handler = this.S_FIN_DNEVNIKBLAGAJNEODDORowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORowChangeEvent((S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_FIN_DNEVNIKBLAGAJNEODDORowDeleted != null)
                {
                    S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORowChangeEventHandler handler = this.S_FIN_DNEVNIKBLAGAJNEODDORowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORowChangeEvent((S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_FIN_DNEVNIKBLAGAJNEODDORowDeleting != null)
                {
                    S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORowChangeEventHandler handler = this.S_FIN_DNEVNIKBLAGAJNEODDORowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORowChangeEvent((S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_FIN_DNEVNIKBLAGAJNEODDORow(S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BLGBROJDOKUMENTAColumn
            {
                get
                {
                    return this.columnBLGBROJDOKUMENTA;
                }
            }

            public DataColumn BLGDATUMDOKUMENTAColumn
            {
                get
                {
                    return this.columnBLGDATUMDOKUMENTA;
                }
            }

            public DataColumn BLGSLOVIMAColumn
            {
                get
                {
                    return this.columnBLGSLOVIMA;
                }
            }

            public DataColumn BLGSVRHAColumn
            {
                get
                {
                    return this.columnBLGSVRHA;
                }
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn IDBLGVRSTEDOKColumn
            {
                get
                {
                    return this.columnIDBLGVRSTEDOK;
                }
            }

            public S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow this[int index]
            {
                get
                {
                    return (S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow) this.Rows[index];
                }
            }

            public DataColumn IZDATAKColumn
            {
                get
                {
                    return this.columnIZDATAK;
                }
            }

            public DataColumn KONTAColumn
            {
                get
                {
                    return this.columnKONTA;
                }
            }

            public DataColumn NAZIVVRSTEDOKColumn
            {
                get
                {
                    return this.columnNAZIVVRSTEDOK;
                }
            }

            public DataColumn PRIMITAKColumn
            {
                get
                {
                    return this.columnPRIMITAK;
                }
            }
        }

        public class S_FIN_DNEVNIKBLAGAJNEODDORow : DataRow
        {
            private S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDODataTable tableS_FIN_DNEVNIKBLAGAJNEODDO;

            internal S_FIN_DNEVNIKBLAGAJNEODDORow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_FIN_DNEVNIKBLAGAJNEODDO = (S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDODataTable) this.Table;
            }

            public bool IsBLGBROJDOKUMENTANull()
            {
                return this.IsNull(this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGBROJDOKUMENTAColumn);
            }

            public bool IsBLGDATUMDOKUMENTANull()
            {
                return this.IsNull(this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGDATUMDOKUMENTAColumn);
            }

            public bool IsBLGSLOVIMANull()
            {
                return this.IsNull(this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGSLOVIMAColumn);
            }

            public bool IsBLGSVRHANull()
            {
                return this.IsNull(this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGSVRHAColumn);
            }

            public bool IsIDBLGVRSTEDOKNull()
            {
                return this.IsNull(this.tableS_FIN_DNEVNIKBLAGAJNEODDO.IDBLGVRSTEDOKColumn);
            }

            public bool IsIZDATAKNull()
            {
                return this.IsNull(this.tableS_FIN_DNEVNIKBLAGAJNEODDO.IZDATAKColumn);
            }

            public bool IsKONTANull()
            {
                return this.IsNull(this.tableS_FIN_DNEVNIKBLAGAJNEODDO.KONTAColumn);
            }

            public bool IsNAZIVVRSTEDOKNull()
            {
                return this.IsNull(this.tableS_FIN_DNEVNIKBLAGAJNEODDO.NAZIVVRSTEDOKColumn);
            }

            public bool IsPRIMITAKNull()
            {
                return this.IsNull(this.tableS_FIN_DNEVNIKBLAGAJNEODDO.PRIMITAKColumn);
            }

            public void SetBLGBROJDOKUMENTANull()
            {
                this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGBROJDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBLGDATUMDOKUMENTANull()
            {
                this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGDATUMDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBLGSLOVIMANull()
            {
                this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGSLOVIMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBLGSVRHANull()
            {
                this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGSVRHAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDBLGVRSTEDOKNull()
            {
                this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.IDBLGVRSTEDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZDATAKNull()
            {
                this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.IZDATAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKONTANull()
            {
                this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.KONTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVVRSTEDOKNull()
            {
                this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.NAZIVVRSTEDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMITAKNull()
            {
                this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.PRIMITAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BLGBROJDOKUMENTA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGBROJDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BLGBROJDOKUMENTA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGBROJDOKUMENTAColumn] = value;
                }
            }

            public DateTime BLGDATUMDOKUMENTA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGDATUMDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BLGDATUMDOKUMENTA because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGDATUMDOKUMENTAColumn] = value;
                }
            }

            public string BLGSLOVIMA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGSLOVIMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BLGSLOVIMA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGSLOVIMAColumn] = value;
                }
            }

            public string BLGSVRHA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGSVRHAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.BLGSVRHAColumn] = value;
                }
            }

            public int IDBLGVRSTEDOK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.IDBLGVRSTEDOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.IDBLGVRSTEDOKColumn] = value;
                }
            }

            public decimal IZDATAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.IZDATAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.IZDATAKColumn] = value;
                }
            }

            public string KONTA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.KONTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.KONTAColumn] = value;
                }
            }

            public string NAZIVVRSTEDOK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.NAZIVVRSTEDOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.NAZIVVRSTEDOKColumn] = value;
                }
            }

            public decimal PRIMITAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.PRIMITAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_DNEVNIKBLAGAJNEODDO.PRIMITAKColumn] = value;
                }
            }
        }

        public class S_FIN_DNEVNIKBLAGAJNEODDORowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow eventRow;

            public S_FIN_DNEVNIKBLAGAJNEODDORowChangeEvent(S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow row, DataRowAction action)
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

            public S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_FIN_DNEVNIKBLAGAJNEODDORowChangeEventHandler(object sender, S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORowChangeEvent e);
    }
}

