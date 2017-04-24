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
    public class S_DD_REKAP_DOPRINOSDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_DD_REKAP_DOPRINOSDataTable tableS_DD_REKAP_DOPRINOS;

        public S_DD_REKAP_DOPRINOSDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_DD_REKAP_DOPRINOSDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_DD_REKAP_DOPRINOS"] != null)
                    {
                        this.Tables.Add(new S_DD_REKAP_DOPRINOSDataTable(dataSet.Tables["S_DD_REKAP_DOPRINOS"]));
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
            S_DD_REKAP_DOPRINOSDataSet set = (S_DD_REKAP_DOPRINOSDataSet) base.Clone();
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
            S_DD_REKAP_DOPRINOSDataSet set = new S_DD_REKAP_DOPRINOSDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_DD_REKAP_DOPRINOSDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2129");
            this.ExtendedProperties.Add("DataSetName", "S_DD_REKAP_DOPRINOSDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_DD_REKAP_DOPRINOSDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_DD_REKAP_DOPRINOS");
            this.ExtendedProperties.Add("ObjectDescription", "S_DD_REKAP_DOPRINOS");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_DD");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_DD_REKAP_DOPRINOS");
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
            this.DataSetName = "S_DD_REKAP_DOPRINOSDataSet";
            this.Namespace = "http://www.tempuri.org/S_DD_REKAP_DOPRINOS";
            this.tableS_DD_REKAP_DOPRINOS = new S_DD_REKAP_DOPRINOSDataTable();
            this.Tables.Add(this.tableS_DD_REKAP_DOPRINOS);
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
            this.tableS_DD_REKAP_DOPRINOS = (S_DD_REKAP_DOPRINOSDataTable) this.Tables["S_DD_REKAP_DOPRINOS"];
            if (initTable && (this.tableS_DD_REKAP_DOPRINOS != null))
            {
                this.tableS_DD_REKAP_DOPRINOS.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_DD_REKAP_DOPRINOS"] != null)
                {
                    this.Tables.Add(new S_DD_REKAP_DOPRINOSDataTable(dataSet.Tables["S_DD_REKAP_DOPRINOS"]));
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

        private bool ShouldSerializeS_DD_REKAP_DOPRINOS()
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
        public S_DD_REKAP_DOPRINOSDataTable S_DD_REKAP_DOPRINOS
        {
            get
            {
                return this.tableS_DD_REKAP_DOPRINOS;
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
        public class S_DD_REKAP_DOPRINOSDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIZNOS;
            private DataColumn columnNAZIVDOPRINOS;
            private DataColumn columnSIFRA;
            private DataColumn columnvrsta;
            private DataColumn columnvrstasifra;

            public event S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRowChangeEventHandler S_DD_REKAP_DOPRINOSRowChanged;

            public event S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRowChangeEventHandler S_DD_REKAP_DOPRINOSRowChanging;

            public event S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRowChangeEventHandler S_DD_REKAP_DOPRINOSRowDeleted;

            public event S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRowChangeEventHandler S_DD_REKAP_DOPRINOSRowDeleting;

            public S_DD_REKAP_DOPRINOSDataTable()
            {
                this.TableName = "S_DD_REKAP_DOPRINOS";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_DD_REKAP_DOPRINOSDataTable(DataTable table) : base(table.TableName)
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

            protected S_DD_REKAP_DOPRINOSDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_DD_REKAP_DOPRINOSRow(S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow row)
            {
                this.Rows.Add(row);
            }

            public S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow AddS_DD_REKAP_DOPRINOSRow(decimal iZNOS, int sIFRA, string vrsta, string nAZIVDOPRINOS, int vrstasifra)
            {
                S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow row = (S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow) this.NewRow();
                row.ItemArray = new object[] { iZNOS, sIFRA, vrsta, nAZIVDOPRINOS, vrstasifra };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSDataTable table = (S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_DD_REKAP_DOPRINOSDataSet set = new S_DD_REKAP_DOPRINOSDataSet();
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
                this.columnIZNOS = new DataColumn("IZNOS", typeof(decimal), "", MappingType.Element);
                this.columnIZNOS.Caption = "IZNOS";
                this.columnIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOS.ExtendedProperties.Add("Description", "IZNOS");
                this.columnIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "IZNOS");
                this.Columns.Add(this.columnIZNOS);
                this.columnSIFRA = new DataColumn("SIFRA", typeof(int), "", MappingType.Element);
                this.columnSIFRA.Caption = "SIFRA";
                this.columnSIFRA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSIFRA.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSIFRA.ExtendedProperties.Add("Description", "SIFRA");
                this.columnSIFRA.ExtendedProperties.Add("Length", "5");
                this.columnSIFRA.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.InternalName", "SIFRA");
                this.Columns.Add(this.columnSIFRA);
                this.columnvrsta = new DataColumn("vrsta", typeof(string), "", MappingType.Element);
                this.columnvrsta.Caption = "vrsta";
                this.columnvrsta.MaxLength = 50;
                this.columnvrsta.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnvrsta.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnvrsta.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnvrsta.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnvrsta.ExtendedProperties.Add("IsKey", "false");
                this.columnvrsta.ExtendedProperties.Add("ReadOnly", "true");
                this.columnvrsta.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnvrsta.ExtendedProperties.Add("Description", "vrsta");
                this.columnvrsta.ExtendedProperties.Add("Length", "50");
                this.columnvrsta.ExtendedProperties.Add("Decimals", "0");
                this.columnvrsta.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnvrsta.ExtendedProperties.Add("IsInReader", "true");
                this.columnvrsta.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnvrsta.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnvrsta.ExtendedProperties.Add("Deklarit.InternalName", "vrsta");
                this.Columns.Add(this.columnvrsta);
                this.columnNAZIVDOPRINOS = new DataColumn("NAZIVDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnNAZIVDOPRINOS.Caption = "Naziv doprinosa";
                this.columnNAZIVDOPRINOS.MaxLength = 50;
                this.columnNAZIVDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Description", "Naziv doprinosa");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVDOPRINOS");
                this.Columns.Add(this.columnNAZIVDOPRINOS);
                this.columnvrstasifra = new DataColumn("vrstasifra", typeof(int), "", MappingType.Element);
                this.columnvrstasifra.Caption = "vrstasifra";
                this.columnvrstasifra.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnvrstasifra.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnvrstasifra.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnvrstasifra.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnvrstasifra.ExtendedProperties.Add("IsKey", "false");
                this.columnvrstasifra.ExtendedProperties.Add("ReadOnly", "true");
                this.columnvrstasifra.ExtendedProperties.Add("DeklaritType", "int");
                this.columnvrstasifra.ExtendedProperties.Add("Description", "vrstasifra");
                this.columnvrstasifra.ExtendedProperties.Add("Length", "5");
                this.columnvrstasifra.ExtendedProperties.Add("Decimals", "0");
                this.columnvrstasifra.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnvrstasifra.ExtendedProperties.Add("IsInReader", "true");
                this.columnvrstasifra.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnvrstasifra.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnvrstasifra.ExtendedProperties.Add("Deklarit.InternalName", "vrstasifra");
                this.Columns.Add(this.columnvrstasifra);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_DD_REKAP_DOPRINOS");
                this.ExtendedProperties.Add("Description", "S_DD_REKAP_DOPRINOS");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIZNOS = this.Columns["IZNOS"];
                this.columnSIFRA = this.Columns["SIFRA"];
                this.columnvrsta = this.Columns["vrsta"];
                this.columnNAZIVDOPRINOS = this.Columns["NAZIVDOPRINOS"];
                this.columnvrstasifra = this.Columns["vrstasifra"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow(builder);
            }

            public S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow NewS_DD_REKAP_DOPRINOSRow()
            {
                return (S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_DD_REKAP_DOPRINOSRowChanged != null)
                {
                    S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRowChangeEventHandler handler = this.S_DD_REKAP_DOPRINOSRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRowChangeEvent((S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_DD_REKAP_DOPRINOSRowChanging != null)
                {
                    S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRowChangeEventHandler handler = this.S_DD_REKAP_DOPRINOSRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRowChangeEvent((S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_DD_REKAP_DOPRINOSRowDeleted != null)
                {
                    S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRowChangeEventHandler handler = this.S_DD_REKAP_DOPRINOSRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRowChangeEvent((S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_DD_REKAP_DOPRINOSRowDeleting != null)
                {
                    S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRowChangeEventHandler handler = this.S_DD_REKAP_DOPRINOSRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRowChangeEvent((S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_DD_REKAP_DOPRINOSRow(S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow row)
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

            public S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow this[int index]
            {
                get
                {
                    return (S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow) this.Rows[index];
                }
            }

            public DataColumn IZNOSColumn
            {
                get
                {
                    return this.columnIZNOS;
                }
            }

            public DataColumn NAZIVDOPRINOSColumn
            {
                get
                {
                    return this.columnNAZIVDOPRINOS;
                }
            }

            public DataColumn SIFRAColumn
            {
                get
                {
                    return this.columnSIFRA;
                }
            }

            public DataColumn vrstaColumn
            {
                get
                {
                    return this.columnvrsta;
                }
            }

            public DataColumn vrstasifraColumn
            {
                get
                {
                    return this.columnvrstasifra;
                }
            }
        }

        public class S_DD_REKAP_DOPRINOSRow : DataRow
        {
            private S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSDataTable tableS_DD_REKAP_DOPRINOS;

            internal S_DD_REKAP_DOPRINOSRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_DD_REKAP_DOPRINOS = (S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSDataTable) this.Table;
            }

            public bool IsIZNOSNull()
            {
                return this.IsNull(this.tableS_DD_REKAP_DOPRINOS.IZNOSColumn);
            }

            public bool IsNAZIVDOPRINOSNull()
            {
                return this.IsNull(this.tableS_DD_REKAP_DOPRINOS.NAZIVDOPRINOSColumn);
            }

            public bool IsSIFRANull()
            {
                return this.IsNull(this.tableS_DD_REKAP_DOPRINOS.SIFRAColumn);
            }

            public bool IsvrstaNull()
            {
                return this.IsNull(this.tableS_DD_REKAP_DOPRINOS.vrstaColumn);
            }

            public bool IsvrstasifraNull()
            {
                return this.IsNull(this.tableS_DD_REKAP_DOPRINOS.vrstasifraColumn);
            }

            public void SetIZNOSNull()
            {
                this[this.tableS_DD_REKAP_DOPRINOS.IZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVDOPRINOSNull()
            {
                this[this.tableS_DD_REKAP_DOPRINOS.NAZIVDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRANull()
            {
                this[this.tableS_DD_REKAP_DOPRINOS.SIFRAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetvrstaNull()
            {
                this[this.tableS_DD_REKAP_DOPRINOS.vrstaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetvrstasifraNull()
            {
                this[this.tableS_DD_REKAP_DOPRINOS.vrstasifraColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal IZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_REKAP_DOPRINOS.IZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IZNOS because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_REKAP_DOPRINOS.IZNOSColumn] = value;
                }
            }

            public string NAZIVDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_REKAP_DOPRINOS.NAZIVDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVDOPRINOS because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_REKAP_DOPRINOS.NAZIVDOPRINOSColumn] = value;
                }
            }

            public int SIFRA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_DD_REKAP_DOPRINOS.SIFRAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SIFRA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_REKAP_DOPRINOS.SIFRAColumn] = value;
                }
            }

            public string vrsta
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_REKAP_DOPRINOS.vrstaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value vrsta because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_REKAP_DOPRINOS.vrstaColumn] = value;
                }
            }

            public int vrstasifra
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_DD_REKAP_DOPRINOS.vrstasifraColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        ////InvalidCastException innerException = exception1;
                        ////throw new StrongTypingException("Cannot get value vrstasifra because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_REKAP_DOPRINOS.vrstasifraColumn] = value;
                }
            }
        }

        public class S_DD_REKAP_DOPRINOSRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow eventRow;

            public S_DD_REKAP_DOPRINOSRowChangeEvent(S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow row, DataRowAction action)
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

            public S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_DD_REKAP_DOPRINOSRowChangeEventHandler(object sender, S_DD_REKAP_DOPRINOSDataSet.S_DD_REKAP_DOPRINOSRowChangeEvent e);
    }
}

