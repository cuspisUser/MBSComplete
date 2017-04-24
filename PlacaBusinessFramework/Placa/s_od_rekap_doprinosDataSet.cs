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
    public class s_od_rekap_doprinosDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private s_od_rekap_doprinosDataTable tables_od_rekap_doprinos;

        public s_od_rekap_doprinosDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected s_od_rekap_doprinosDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["s_od_rekap_doprinos"] != null)
                    {
                        this.Tables.Add(new s_od_rekap_doprinosDataTable(dataSet.Tables["s_od_rekap_doprinos"]));
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
            s_od_rekap_doprinosDataSet set = (s_od_rekap_doprinosDataSet) base.Clone();
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
            s_od_rekap_doprinosDataSet set = new s_od_rekap_doprinosDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "s_od_rekap_doprinosDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2044");
            this.ExtendedProperties.Add("DataSetName", "s_od_rekap_doprinosDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Is_od_rekap_doprinosDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "s_od_rekap_doprinos");
            this.ExtendedProperties.Add("ObjectDescription", "s_od_rekap_doprinos");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_DOPRINOS");
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
            this.DataSetName = "s_od_rekap_doprinosDataSet";
            this.Namespace = "http://www.tempuri.org/s_od_rekap_doprinos";
            this.tables_od_rekap_doprinos = new s_od_rekap_doprinosDataTable();
            this.Tables.Add(this.tables_od_rekap_doprinos);
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
            this.tables_od_rekap_doprinos = (s_od_rekap_doprinosDataTable) this.Tables["s_od_rekap_doprinos"];
            if (initTable && (this.tables_od_rekap_doprinos != null))
            {
                this.tables_od_rekap_doprinos.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["s_od_rekap_doprinos"] != null)
                {
                    this.Tables.Add(new s_od_rekap_doprinosDataTable(dataSet.Tables["s_od_rekap_doprinos"]));
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

        private bool ShouldSerializes_od_rekap_doprinos()
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
        public s_od_rekap_doprinosDataTable s_od_rekap_doprinos
        {
            get
            {
                return this.tables_od_rekap_doprinos;
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
        public class s_od_rekap_doprinosDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIZNOS;
            private DataColumn columnNAZIVDOPRINOS;
            private DataColumn columnSIFRA;
            private DataColumn columnvrsta;
            private DataColumn columnvrstasifra;

            public event s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRowChangeEventHandler s_od_rekap_doprinosRowChanged;

            public event s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRowChangeEventHandler s_od_rekap_doprinosRowChanging;

            public event s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRowChangeEventHandler s_od_rekap_doprinosRowDeleted;

            public event s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRowChangeEventHandler s_od_rekap_doprinosRowDeleting;

            public s_od_rekap_doprinosDataTable()
            {
                this.TableName = "s_od_rekap_doprinos";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal s_od_rekap_doprinosDataTable(DataTable table) : base(table.TableName)
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

            protected s_od_rekap_doprinosDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void Adds_od_rekap_doprinosRow(s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow row)
            {
                this.Rows.Add(row);
            }

            public s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow Adds_od_rekap_doprinosRow(decimal iZNOS, int sIFRA, string vrsta, string nAZIVDOPRINOS, int vrstasifra)
            {
                s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow row = (s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow) this.NewRow();
                row.ItemArray = new object[] { iZNOS, sIFRA, vrsta, nAZIVDOPRINOS, vrstasifra };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                s_od_rekap_doprinosDataSet.s_od_rekap_doprinosDataTable table = (s_od_rekap_doprinosDataSet.s_od_rekap_doprinosDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                s_od_rekap_doprinosDataSet set = new s_od_rekap_doprinosDataSet();
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
                this.ExtendedProperties.Add("LevelName", "s_od_rekap_doprinos");
                this.ExtendedProperties.Add("Description", "S_OD_REKAP_DOPRINOS");
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
                return new s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow(builder);
            }

            public s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow News_od_rekap_doprinosRow()
            {
                return (s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.s_od_rekap_doprinosRowChanged != null)
                {
                    s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRowChangeEventHandler handler = this.s_od_rekap_doprinosRowChanged;
                    if (handler != null)
                    {
                        handler(this, new s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRowChangeEvent((s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.s_od_rekap_doprinosRowChanging != null)
                {
                    s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRowChangeEventHandler handler = this.s_od_rekap_doprinosRowChanging;
                    if (handler != null)
                    {
                        handler(this, new s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRowChangeEvent((s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.s_od_rekap_doprinosRowDeleted != null)
                {
                    s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRowChangeEventHandler handler = this.s_od_rekap_doprinosRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRowChangeEvent((s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.s_od_rekap_doprinosRowDeleting != null)
                {
                    s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRowChangeEventHandler handler = this.s_od_rekap_doprinosRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRowChangeEvent((s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow) e.Row, e.Action));
                    }
                }
            }

            public void Removes_od_rekap_doprinosRow(s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow row)
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

            public s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow this[int index]
            {
                get
                {
                    return (s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow) this.Rows[index];
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

        public class s_od_rekap_doprinosRow : DataRow
        {
            private s_od_rekap_doprinosDataSet.s_od_rekap_doprinosDataTable tables_od_rekap_doprinos;

            internal s_od_rekap_doprinosRow(DataRowBuilder rb) : base(rb)
            {
                this.tables_od_rekap_doprinos = (s_od_rekap_doprinosDataSet.s_od_rekap_doprinosDataTable) this.Table;
            }

            public bool IsIZNOSNull()
            {
                return this.IsNull(this.tables_od_rekap_doprinos.IZNOSColumn);
            }

            public bool IsNAZIVDOPRINOSNull()
            {
                return this.IsNull(this.tables_od_rekap_doprinos.NAZIVDOPRINOSColumn);
            }

            public bool IsSIFRANull()
            {
                return this.IsNull(this.tables_od_rekap_doprinos.SIFRAColumn);
            }

            public bool IsvrstaNull()
            {
                return this.IsNull(this.tables_od_rekap_doprinos.vrstaColumn);
            }

            public bool IsvrstasifraNull()
            {
                return this.IsNull(this.tables_od_rekap_doprinos.vrstasifraColumn);
            }

            public void SetIZNOSNull()
            {
                this[this.tables_od_rekap_doprinos.IZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVDOPRINOSNull()
            {
                this[this.tables_od_rekap_doprinos.NAZIVDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRANull()
            {
                this[this.tables_od_rekap_doprinos.SIFRAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetvrstaNull()
            {
                this[this.tables_od_rekap_doprinos.vrstaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetvrstasifraNull()
            {
                this[this.tables_od_rekap_doprinos.vrstasifraColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal IZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_rekap_doprinos.IZNOSColumn]);
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
                    this[this.tables_od_rekap_doprinos.IZNOSColumn] = value;
                }
            }

            public string NAZIVDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tables_od_rekap_doprinos.NAZIVDOPRINOSColumn]);
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
                    this[this.tables_od_rekap_doprinos.NAZIVDOPRINOSColumn] = value;
                }
            }

            public int SIFRA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tables_od_rekap_doprinos.SIFRAColumn]);
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
                    this[this.tables_od_rekap_doprinos.SIFRAColumn] = value;
                }
            }

            public string vrsta
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tables_od_rekap_doprinos.vrstaColumn]);
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
                    this[this.tables_od_rekap_doprinos.vrstaColumn] = value;
                }
            }

            public int vrstasifra
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tables_od_rekap_doprinos.vrstasifraColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value vrstasifra because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_rekap_doprinos.vrstasifraColumn] = value;
                }
            }
        }

        public class s_od_rekap_doprinosRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow eventRow;

            public s_od_rekap_doprinosRowChangeEvent(s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow row, DataRowAction action)
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

            public s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void s_od_rekap_doprinosRowChangeEventHandler(object sender, s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRowChangeEvent e);
    }
}

