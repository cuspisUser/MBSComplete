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
    public class S_FIN_PROMET_PO_KONTIMADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_FIN_PROMET_PO_KONTIMADataTable tableS_FIN_PROMET_PO_KONTIMA;

        public S_FIN_PROMET_PO_KONTIMADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_FIN_PROMET_PO_KONTIMADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_FIN_PROMET_PO_KONTIMA"] != null)
                    {
                        this.Tables.Add(new S_FIN_PROMET_PO_KONTIMADataTable(dataSet.Tables["S_FIN_PROMET_PO_KONTIMA"]));
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
            S_FIN_PROMET_PO_KONTIMADataSet set = (S_FIN_PROMET_PO_KONTIMADataSet) base.Clone();
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
            S_FIN_PROMET_PO_KONTIMADataSet set = new S_FIN_PROMET_PO_KONTIMADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_FIN_PROMET_PO_KONTIMADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2167");
            this.ExtendedProperties.Add("DataSetName", "S_FIN_PROMET_PO_KONTIMADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_FIN_PROMET_PO_KONTIMADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_FIN_PROMET_PO_KONTIMA");
            this.ExtendedProperties.Add("ObjectDescription", "S_FIN_PROMET_PO_KONTIMA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_FIN_PROMET_PO_KONTIMA");
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
            this.DataSetName = "S_FIN_PROMET_PO_KONTIMADataSet";
            this.Namespace = "http://www.tempuri.org/S_FIN_PROMET_PO_KONTIMA";
            this.tableS_FIN_PROMET_PO_KONTIMA = new S_FIN_PROMET_PO_KONTIMADataTable();
            this.Tables.Add(this.tableS_FIN_PROMET_PO_KONTIMA);
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
            this.tableS_FIN_PROMET_PO_KONTIMA = (S_FIN_PROMET_PO_KONTIMADataTable) this.Tables["S_FIN_PROMET_PO_KONTIMA"];
            if (initTable && (this.tableS_FIN_PROMET_PO_KONTIMA != null))
            {
                this.tableS_FIN_PROMET_PO_KONTIMA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_FIN_PROMET_PO_KONTIMA"] != null)
                {
                    this.Tables.Add(new S_FIN_PROMET_PO_KONTIMADataTable(dataSet.Tables["S_FIN_PROMET_PO_KONTIMA"]));
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

        private bool ShouldSerializeS_FIN_PROMET_PO_KONTIMA()
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
        public S_FIN_PROMET_PO_KONTIMADataTable S_FIN_PROMET_PO_KONTIMA
        {
            get
            {
                return this.tableS_FIN_PROMET_PO_KONTIMA;
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
        public class S_FIN_PROMET_PO_KONTIMADataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJSTAVAKA;
            private DataColumn columnduguje;
            private DataColumn columnkonto;
            private DataColumn columnNAZIVKONTO;
            private DataColumn columnPOTRAZUJE;

            public event S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARowChangeEventHandler S_FIN_PROMET_PO_KONTIMARowChanged;

            public event S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARowChangeEventHandler S_FIN_PROMET_PO_KONTIMARowChanging;

            public event S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARowChangeEventHandler S_FIN_PROMET_PO_KONTIMARowDeleted;

            public event S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARowChangeEventHandler S_FIN_PROMET_PO_KONTIMARowDeleting;

            public S_FIN_PROMET_PO_KONTIMADataTable()
            {
                this.TableName = "S_FIN_PROMET_PO_KONTIMA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_FIN_PROMET_PO_KONTIMADataTable(DataTable table) : base(table.TableName)
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

            protected S_FIN_PROMET_PO_KONTIMADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_FIN_PROMET_PO_KONTIMARow(S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow row)
            {
                this.Rows.Add(row);
            }

            public S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow AddS_FIN_PROMET_PO_KONTIMARow(string konto, string nAZIVKONTO, decimal duguje, decimal pOTRAZUJE, int bROJSTAVAKA)
            {
                S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow row = (S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow) this.NewRow();
                row.ItemArray = new object[] { konto, nAZIVKONTO, duguje, pOTRAZUJE, bROJSTAVAKA };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMADataTable table = (S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_FIN_PROMET_PO_KONTIMADataSet set = new S_FIN_PROMET_PO_KONTIMADataSet();
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
                this.columnNAZIVKONTO = new DataColumn("NAZIVKONTO", typeof(string), "", MappingType.Element);
                this.columnNAZIVKONTO.Caption = "Naziv konta";
                this.columnNAZIVKONTO.MaxLength = 150;
                this.columnNAZIVKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Description", "Naziv konta");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Length", "150");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKONTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKONTO");
                this.Columns.Add(this.columnNAZIVKONTO);
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
                this.columnBROJSTAVAKA = new DataColumn("BROJSTAVAKA", typeof(int), "", MappingType.Element);
                this.columnBROJSTAVAKA.Caption = "BROJSTAVAKA";
                this.columnBROJSTAVAKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJSTAVAKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJSTAVAKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJSTAVAKA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJSTAVAKA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJSTAVAKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJSTAVAKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJSTAVAKA.ExtendedProperties.Add("Description", "BROJSTAVAKA");
                this.columnBROJSTAVAKA.ExtendedProperties.Add("Length", "5");
                this.columnBROJSTAVAKA.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJSTAVAKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJSTAVAKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJSTAVAKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJSTAVAKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJSTAVAKA.ExtendedProperties.Add("Deklarit.InternalName", "BROJSTAVAKA");
                this.Columns.Add(this.columnBROJSTAVAKA);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_FIN_PROMET_PO_KONTIMA");
                this.ExtendedProperties.Add("Description", "S_FIN_PROMET_PO_KONTIMA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnkonto = this.Columns["konto"];
                this.columnNAZIVKONTO = this.Columns["NAZIVKONTO"];
                this.columnduguje = this.Columns["duguje"];
                this.columnPOTRAZUJE = this.Columns["POTRAZUJE"];
                this.columnBROJSTAVAKA = this.Columns["BROJSTAVAKA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow(builder);
            }

            public S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow NewS_FIN_PROMET_PO_KONTIMARow()
            {
                return (S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_FIN_PROMET_PO_KONTIMARowChanged != null)
                {
                    S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARowChangeEventHandler handler = this.S_FIN_PROMET_PO_KONTIMARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARowChangeEvent((S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_FIN_PROMET_PO_KONTIMARowChanging != null)
                {
                    S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARowChangeEventHandler handler = this.S_FIN_PROMET_PO_KONTIMARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARowChangeEvent((S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_FIN_PROMET_PO_KONTIMARowDeleted != null)
                {
                    S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARowChangeEventHandler handler = this.S_FIN_PROMET_PO_KONTIMARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARowChangeEvent((S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_FIN_PROMET_PO_KONTIMARowDeleting != null)
                {
                    S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARowChangeEventHandler handler = this.S_FIN_PROMET_PO_KONTIMARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARowChangeEvent((S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_FIN_PROMET_PO_KONTIMARow(S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJSTAVAKAColumn
            {
                get
                {
                    return this.columnBROJSTAVAKA;
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

            public DataColumn dugujeColumn
            {
                get
                {
                    return this.columnduguje;
                }
            }

            public S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow this[int index]
            {
                get
                {
                    return (S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow) this.Rows[index];
                }
            }

            public DataColumn kontoColumn
            {
                get
                {
                    return this.columnkonto;
                }
            }

            public DataColumn NAZIVKONTOColumn
            {
                get
                {
                    return this.columnNAZIVKONTO;
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

        public class S_FIN_PROMET_PO_KONTIMARow : DataRow
        {
            private S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMADataTable tableS_FIN_PROMET_PO_KONTIMA;

            internal S_FIN_PROMET_PO_KONTIMARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_FIN_PROMET_PO_KONTIMA = (S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMADataTable) this.Table;
            }

            public bool IsBROJSTAVAKANull()
            {
                return this.IsNull(this.tableS_FIN_PROMET_PO_KONTIMA.BROJSTAVAKAColumn);
            }

            public bool IsdugujeNull()
            {
                return this.IsNull(this.tableS_FIN_PROMET_PO_KONTIMA.dugujeColumn);
            }

            public bool IskontoNull()
            {
                return this.IsNull(this.tableS_FIN_PROMET_PO_KONTIMA.kontoColumn);
            }

            public bool IsNAZIVKONTONull()
            {
                return this.IsNull(this.tableS_FIN_PROMET_PO_KONTIMA.NAZIVKONTOColumn);
            }

            public bool IsPOTRAZUJENull()
            {
                return this.IsNull(this.tableS_FIN_PROMET_PO_KONTIMA.POTRAZUJEColumn);
            }

            public void SetBROJSTAVAKANull()
            {
                this[this.tableS_FIN_PROMET_PO_KONTIMA.BROJSTAVAKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetdugujeNull()
            {
                this[this.tableS_FIN_PROMET_PO_KONTIMA.dugujeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetkontoNull()
            {
                this[this.tableS_FIN_PROMET_PO_KONTIMA.kontoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKONTONull()
            {
                this[this.tableS_FIN_PROMET_PO_KONTIMA.NAZIVKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOTRAZUJENull()
            {
                this[this.tableS_FIN_PROMET_PO_KONTIMA.POTRAZUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BROJSTAVAKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_PROMET_PO_KONTIMA.BROJSTAVAKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJSTAVAKA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_PROMET_PO_KONTIMA.BROJSTAVAKAColumn] = value;
                }
            }

            public decimal duguje
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_PROMET_PO_KONTIMA.dugujeColumn]);
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
                    this[this.tableS_FIN_PROMET_PO_KONTIMA.dugujeColumn] = value;
                }
            }

            public string konto
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_PROMET_PO_KONTIMA.kontoColumn]);
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
                    this[this.tableS_FIN_PROMET_PO_KONTIMA.kontoColumn] = value;
                }
            }

            public string NAZIVKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_PROMET_PO_KONTIMA.NAZIVKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVKONTO because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_PROMET_PO_KONTIMA.NAZIVKONTOColumn] = value;
                }
            }

            public decimal POTRAZUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_PROMET_PO_KONTIMA.POTRAZUJEColumn]);
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
                    this[this.tableS_FIN_PROMET_PO_KONTIMA.POTRAZUJEColumn] = value;
                }
            }
        }

        public class S_FIN_PROMET_PO_KONTIMARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow eventRow;

            public S_FIN_PROMET_PO_KONTIMARowChangeEvent(S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow row, DataRowAction action)
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

            public S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_FIN_PROMET_PO_KONTIMARowChangeEventHandler(object sender, S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARowChangeEvent e);
    }
}

