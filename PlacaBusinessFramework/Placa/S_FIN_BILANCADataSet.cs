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
    public class S_FIN_BILANCADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_FIN_BILANCADataTable tableS_FIN_BILANCA;

        public S_FIN_BILANCADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_FIN_BILANCADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_FIN_BILANCA"] != null)
                    {
                        this.Tables.Add(new S_FIN_BILANCADataTable(dataSet.Tables["S_FIN_BILANCA"]));
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
            S_FIN_BILANCADataSet set = (S_FIN_BILANCADataSet) base.Clone();
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
            S_FIN_BILANCADataSet set = new S_FIN_BILANCADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_FIN_BILANCADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2162");
            this.ExtendedProperties.Add("DataSetName", "S_FIN_BILANCADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_FIN_BILANCADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_FIN_BILANCA");
            this.ExtendedProperties.Add("ObjectDescription", "S_FIN_BILANCA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_FIN_BILANCA");
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
            this.DataSetName = "S_FIN_BILANCADataSet";
            this.Namespace = "http://www.tempuri.org/S_FIN_BILANCA";
            this.tableS_FIN_BILANCA = new S_FIN_BILANCADataTable();
            this.Tables.Add(this.tableS_FIN_BILANCA);
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
            this.tableS_FIN_BILANCA = (S_FIN_BILANCADataTable) this.Tables["S_FIN_BILANCA"];
            if (initTable && (this.tableS_FIN_BILANCA != null))
            {
                this.tableS_FIN_BILANCA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_FIN_BILANCA"] != null)
                {
                    this.Tables.Add(new S_FIN_BILANCADataTable(dataSet.Tables["S_FIN_BILANCA"]));
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

        private bool ShouldSerializeS_FIN_BILANCA()
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
        public S_FIN_BILANCADataTable S_FIN_BILANCA
        {
            get
            {
                return this.tableS_FIN_BILANCA;
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
        public class S_FIN_BILANCADataTable : DataTable, IEnumerable
        {
            private DataColumn columnduguje;
            private DataColumn columnkonto;
            private DataColumn columnNAZIV;
            private DataColumn columnPOCETNODUGUJE;
            private DataColumn columnPOCETNOPOTRAZUJE;
            private DataColumn columnPOTRAZUJE;

            public event S_FIN_BILANCADataSet.S_FIN_BILANCARowChangeEventHandler S_FIN_BILANCARowChanged;

            public event S_FIN_BILANCADataSet.S_FIN_BILANCARowChangeEventHandler S_FIN_BILANCARowChanging;

            public event S_FIN_BILANCADataSet.S_FIN_BILANCARowChangeEventHandler S_FIN_BILANCARowDeleted;

            public event S_FIN_BILANCADataSet.S_FIN_BILANCARowChangeEventHandler S_FIN_BILANCARowDeleting;

            public S_FIN_BILANCADataTable()
            {
                this.TableName = "S_FIN_BILANCA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_FIN_BILANCADataTable(DataTable table) : base(table.TableName)
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

            protected S_FIN_BILANCADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_FIN_BILANCARow(S_FIN_BILANCADataSet.S_FIN_BILANCARow row)
            {
                this.Rows.Add(row);
            }

            public S_FIN_BILANCADataSet.S_FIN_BILANCARow AddS_FIN_BILANCARow(decimal duguje, decimal pOTRAZUJE, string konto, decimal pOCETNODUGUJE, decimal pOCETNOPOTRAZUJE, string nAZIV)
            {
                S_FIN_BILANCADataSet.S_FIN_BILANCARow row = (S_FIN_BILANCADataSet.S_FIN_BILANCARow) this.NewRow();
                row.ItemArray = new object[] { duguje, pOTRAZUJE, konto, pOCETNODUGUJE, pOCETNOPOTRAZUJE, nAZIV };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_FIN_BILANCADataSet.S_FIN_BILANCADataTable table = (S_FIN_BILANCADataSet.S_FIN_BILANCADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_FIN_BILANCADataSet.S_FIN_BILANCARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_FIN_BILANCADataSet set = new S_FIN_BILANCADataSet();
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
                this.columnduguje = new DataColumn("duguje", typeof(decimal), "", MappingType.Element);
                this.columnduguje.Caption = "duguje";
                this.columnduguje.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnduguje.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnduguje.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnduguje.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnduguje.ExtendedProperties.Add("Deklarit.InputMask", "0,##");
                this.columnduguje.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnduguje.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnduguje.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnduguje.ExtendedProperties.Add("IsKey", "false");
                this.columnduguje.ExtendedProperties.Add("ReadOnly", "true");
                this.columnduguje.ExtendedProperties.Add("DeklaritType", "int");
                this.columnduguje.ExtendedProperties.Add("Description", "duguje");
                this.columnduguje.ExtendedProperties.Add("Length", "12");
                this.columnduguje.ExtendedProperties.Add("Decimals", "2");
                this.columnduguje.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnduguje.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnduguje.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnduguje.ExtendedProperties.Add("IsInReader", "true");
                this.columnduguje.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnduguje.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnduguje.ExtendedProperties.Add("Deklarit.InternalName", "duguje");
                this.Columns.Add(this.columnduguje);
                this.columnPOTRAZUJE = new DataColumn("POTRAZUJE", typeof(decimal), "", MappingType.Element);
                this.columnPOTRAZUJE.Caption = "POTRAZUJE";
                this.columnPOTRAZUJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOTRAZUJE.ExtendedProperties.Add("IsKey", "false");
                this.columnPOTRAZUJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Description", "POTRAZUJE");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Length", "12");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Decimals", "2");
                this.columnPOTRAZUJE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOTRAZUJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.InternalName", "POTRAZUJE");
                this.Columns.Add(this.columnPOTRAZUJE);
                this.columnkonto = new DataColumn("konto", typeof(string), "", MappingType.Element);
                this.columnkonto.Caption = "konto";
                this.columnkonto.MaxLength = 15;
                this.columnkonto.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnkonto.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnkonto.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnkonto.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnkonto.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnkonto.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnkonto.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnkonto.ExtendedProperties.Add("IsKey", "false");
                this.columnkonto.ExtendedProperties.Add("ReadOnly", "true");
                this.columnkonto.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnkonto.ExtendedProperties.Add("Description", "konto");
                this.columnkonto.ExtendedProperties.Add("Length", "15");
                this.columnkonto.ExtendedProperties.Add("Decimals", "0");
                this.columnkonto.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnkonto.ExtendedProperties.Add("IsInReader", "true");
                this.columnkonto.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnkonto.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnkonto.ExtendedProperties.Add("Deklarit.InternalName", "konto");
                this.Columns.Add(this.columnkonto);
                this.columnPOCETNODUGUJE = new DataColumn("POCETNODUGUJE", typeof(decimal), "", MappingType.Element);
                this.columnPOCETNODUGUJE.Caption = "POCETNODUGUJE";
                this.columnPOCETNODUGUJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("IsKey", "false");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("Description", "POCETNODUGUJE");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("Length", "12");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("Decimals", "2");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOCETNODUGUJE.ExtendedProperties.Add("Deklarit.InternalName", "POCETNODUGUJE");
                this.Columns.Add(this.columnPOCETNODUGUJE);
                this.columnPOCETNOPOTRAZUJE = new DataColumn("POCETNOPOTRAZUJE", typeof(decimal), "", MappingType.Element);
                this.columnPOCETNOPOTRAZUJE.Caption = "POCETNOPOTRAZUJE";
                this.columnPOCETNOPOTRAZUJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("IsKey", "false");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("Description", "POCETNOPOTRAZUJE");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("Length", "12");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("Decimals", "2");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOCETNOPOTRAZUJE.ExtendedProperties.Add("Deklarit.InternalName", "POCETNOPOTRAZUJE");
                this.Columns.Add(this.columnPOCETNOPOTRAZUJE);
                this.columnNAZIV = new DataColumn("NAZIV", typeof(string), "", MappingType.Element);
                this.columnNAZIV.Caption = "NAZIV";
                this.columnNAZIV.MaxLength = 150;
                this.columnNAZIV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIV.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIV.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIV.ExtendedProperties.Add("Description", "NAZIV");
                this.columnNAZIV.ExtendedProperties.Add("Length", "150");
                this.columnNAZIV.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIV.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIV.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.InternalName", "NAZIV");
                this.Columns.Add(this.columnNAZIV);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_FIN_BILANCA");
                this.ExtendedProperties.Add("Description", "S_FIN_BILANCA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnduguje = this.Columns["duguje"];
                this.columnPOTRAZUJE = this.Columns["POTRAZUJE"];
                this.columnkonto = this.Columns["konto"];
                this.columnPOCETNODUGUJE = this.Columns["POCETNODUGUJE"];
                this.columnPOCETNOPOTRAZUJE = this.Columns["POCETNOPOTRAZUJE"];
                this.columnNAZIV = this.Columns["NAZIV"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_FIN_BILANCADataSet.S_FIN_BILANCARow(builder);
            }

            public S_FIN_BILANCADataSet.S_FIN_BILANCARow NewS_FIN_BILANCARow()
            {
                return (S_FIN_BILANCADataSet.S_FIN_BILANCARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_FIN_BILANCARowChanged != null)
                {
                    S_FIN_BILANCADataSet.S_FIN_BILANCARowChangeEventHandler handler = this.S_FIN_BILANCARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_BILANCADataSet.S_FIN_BILANCARowChangeEvent((S_FIN_BILANCADataSet.S_FIN_BILANCARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_FIN_BILANCARowChanging != null)
                {
                    S_FIN_BILANCADataSet.S_FIN_BILANCARowChangeEventHandler handler = this.S_FIN_BILANCARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_BILANCADataSet.S_FIN_BILANCARowChangeEvent((S_FIN_BILANCADataSet.S_FIN_BILANCARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_FIN_BILANCARowDeleted != null)
                {
                    S_FIN_BILANCADataSet.S_FIN_BILANCARowChangeEventHandler handler = this.S_FIN_BILANCARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_BILANCADataSet.S_FIN_BILANCARowChangeEvent((S_FIN_BILANCADataSet.S_FIN_BILANCARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_FIN_BILANCARowDeleting != null)
                {
                    S_FIN_BILANCADataSet.S_FIN_BILANCARowChangeEventHandler handler = this.S_FIN_BILANCARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_BILANCADataSet.S_FIN_BILANCARowChangeEvent((S_FIN_BILANCADataSet.S_FIN_BILANCARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_FIN_BILANCARow(S_FIN_BILANCADataSet.S_FIN_BILANCARow row)
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

            public DataColumn dugujeColumn
            {
                get
                {
                    return this.columnduguje;
                }
            }

            public S_FIN_BILANCADataSet.S_FIN_BILANCARow this[int index]
            {
                get
                {
                    return (S_FIN_BILANCADataSet.S_FIN_BILANCARow) this.Rows[index];
                }
            }

            public DataColumn kontoColumn
            {
                get
                {
                    return this.columnkonto;
                }
            }

            public DataColumn NAZIVColumn
            {
                get
                {
                    return this.columnNAZIV;
                }
            }

            public DataColumn POCETNODUGUJEColumn
            {
                get
                {
                    return this.columnPOCETNODUGUJE;
                }
            }

            public DataColumn POCETNOPOTRAZUJEColumn
            {
                get
                {
                    return this.columnPOCETNOPOTRAZUJE;
                }
            }

            public DataColumn POTRAZUJEColumn
            {
                get
                {
                    return this.columnPOTRAZUJE;
                }
            }
        }

        public class S_FIN_BILANCARow : DataRow
        {
            private S_FIN_BILANCADataSet.S_FIN_BILANCADataTable tableS_FIN_BILANCA;

            internal S_FIN_BILANCARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_FIN_BILANCA = (S_FIN_BILANCADataSet.S_FIN_BILANCADataTable) this.Table;
            }

            public bool IsdugujeNull()
            {
                return this.IsNull(this.tableS_FIN_BILANCA.dugujeColumn);
            }

            public bool IskontoNull()
            {
                return this.IsNull(this.tableS_FIN_BILANCA.kontoColumn);
            }

            public bool IsNAZIVNull()
            {
                return this.IsNull(this.tableS_FIN_BILANCA.NAZIVColumn);
            }

            public bool IsPOCETNODUGUJENull()
            {
                return this.IsNull(this.tableS_FIN_BILANCA.POCETNODUGUJEColumn);
            }

            public bool IsPOCETNOPOTRAZUJENull()
            {
                return this.IsNull(this.tableS_FIN_BILANCA.POCETNOPOTRAZUJEColumn);
            }

            public bool IsPOTRAZUJENull()
            {
                return this.IsNull(this.tableS_FIN_BILANCA.POTRAZUJEColumn);
            }

            public void SetdugujeNull()
            {
                this[this.tableS_FIN_BILANCA.dugujeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetkontoNull()
            {
                this[this.tableS_FIN_BILANCA.kontoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVNull()
            {
                this[this.tableS_FIN_BILANCA.NAZIVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOCETNODUGUJENull()
            {
                this[this.tableS_FIN_BILANCA.POCETNODUGUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOCETNOPOTRAZUJENull()
            {
                this[this.tableS_FIN_BILANCA.POCETNOPOTRAZUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOTRAZUJENull()
            {
                this[this.tableS_FIN_BILANCA.POTRAZUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal duguje
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_BILANCA.dugujeColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value duguje because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_BILANCA.dugujeColumn] = value;
                }
            }

            public string konto
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_BILANCA.kontoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value konto because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_BILANCA.kontoColumn] = value;
                }
            }

            public string NAZIV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_BILANCA.NAZIVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIV because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_BILANCA.NAZIVColumn] = value;
                }
            }

            public decimal POCETNODUGUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_BILANCA.POCETNODUGUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value POCETNODUGUJE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_BILANCA.POCETNODUGUJEColumn] = value;
                }
            }

            public decimal POCETNOPOTRAZUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_BILANCA.POCETNOPOTRAZUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value POCETNOPOTRAZUJE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_BILANCA.POCETNOPOTRAZUJEColumn] = value;
                }
            }

            public decimal POTRAZUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_BILANCA.POTRAZUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value POTRAZUJE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_BILANCA.POTRAZUJEColumn] = value;
                }
            }
        }

        public class S_FIN_BILANCARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_FIN_BILANCADataSet.S_FIN_BILANCARow eventRow;

            public S_FIN_BILANCARowChangeEvent(S_FIN_BILANCADataSet.S_FIN_BILANCARow row, DataRowAction action)
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

            public S_FIN_BILANCADataSet.S_FIN_BILANCARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_FIN_BILANCARowChangeEventHandler(object sender, S_FIN_BILANCADataSet.S_FIN_BILANCARowChangeEvent e);
    }
}

