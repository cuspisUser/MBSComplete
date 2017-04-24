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
    public class S_OD_TABLICA01DataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_TABLICA01DataTable tableS_OD_TABLICA01;

        public S_OD_TABLICA01DataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_TABLICA01DataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_TABLICA01"] != null)
                    {
                        this.Tables.Add(new S_OD_TABLICA01DataTable(dataSet.Tables["S_OD_TABLICA01"]));
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
            S_OD_TABLICA01DataSet set = (S_OD_TABLICA01DataSet) base.Clone();
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
            S_OD_TABLICA01DataSet set = new S_OD_TABLICA01DataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_TABLICA01DataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2132");
            this.ExtendedProperties.Add("DataSetName", "S_OD_TABLICA01DataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_TABLICA01DataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_TABLICA01");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_TABLICA01");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_TABLICA01");
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
            this.DataSetName = "S_OD_TABLICA01DataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_TABLICA01";
            this.tableS_OD_TABLICA01 = new S_OD_TABLICA01DataTable();
            this.Tables.Add(this.tableS_OD_TABLICA01);
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
            this.tableS_OD_TABLICA01 = (S_OD_TABLICA01DataTable) this.Tables["S_OD_TABLICA01"];
            if (initTable && (this.tableS_OD_TABLICA01 != null))
            {
                this.tableS_OD_TABLICA01.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_TABLICA01"] != null)
                {
                    this.Tables.Add(new S_OD_TABLICA01DataTable(dataSet.Tables["S_OD_TABLICA01"]));
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

        private bool ShouldSerializeS_OD_TABLICA01()
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
        public S_OD_TABLICA01DataTable S_OD_TABLICA01
        {
            get
            {
                return this.tableS_OD_TABLICA01;
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
        public class S_OD_TABLICA01DataTable : DataTable, IEnumerable
        {
            private DataColumn columnGODINAOBRACUNA;
            private DataColumn columnIZNOS;
            private DataColumn columnMJESECOBRACUNA;
            private DataColumn columnNAKNADA;
            private DataColumn columnNARADU;

            public event S_OD_TABLICA01DataSet.S_OD_TABLICA01RowChangeEventHandler S_OD_TABLICA01RowChanged;

            public event S_OD_TABLICA01DataSet.S_OD_TABLICA01RowChangeEventHandler S_OD_TABLICA01RowChanging;

            public event S_OD_TABLICA01DataSet.S_OD_TABLICA01RowChangeEventHandler S_OD_TABLICA01RowDeleted;

            public event S_OD_TABLICA01DataSet.S_OD_TABLICA01RowChangeEventHandler S_OD_TABLICA01RowDeleting;

            public S_OD_TABLICA01DataTable()
            {
                this.TableName = "S_OD_TABLICA01";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_TABLICA01DataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_TABLICA01DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_TABLICA01Row(S_OD_TABLICA01DataSet.S_OD_TABLICA01Row row)
            {
                this.Rows.Add(row);
            }

            public S_OD_TABLICA01DataSet.S_OD_TABLICA01Row AddS_OD_TABLICA01Row(decimal iZNOS, string mJESECOBRACUNA, string gODINAOBRACUNA, int nARADU, int nAKNADA)
            {
                S_OD_TABLICA01DataSet.S_OD_TABLICA01Row row = (S_OD_TABLICA01DataSet.S_OD_TABLICA01Row) this.NewRow();
                row.ItemArray = new object[] { iZNOS, mJESECOBRACUNA, gODINAOBRACUNA, nARADU, nAKNADA };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_TABLICA01DataSet.S_OD_TABLICA01DataTable table = (S_OD_TABLICA01DataSet.S_OD_TABLICA01DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_TABLICA01DataSet.S_OD_TABLICA01Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_TABLICA01DataSet set = new S_OD_TABLICA01DataSet();
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
                this.columnMJESECOBRACUNA = new DataColumn("MJESECOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnMJESECOBRACUNA.Caption = "Mjesec obraeuna";
                this.columnMJESECOBRACUNA.MaxLength = 2;
                this.columnMJESECOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Description", "Mjesec obraeuna");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Length", "2");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "MJESECOBRACUNA");
                this.Columns.Add(this.columnMJESECOBRACUNA);
                this.columnGODINAOBRACUNA = new DataColumn("GODINAOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnGODINAOBRACUNA.Caption = "Godina obraeuna";
                this.columnGODINAOBRACUNA.MaxLength = 4;
                this.columnGODINAOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Description", "Godina obraeuna");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Length", "4");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "GODINAOBRACUNA");
                this.Columns.Add(this.columnGODINAOBRACUNA);
                this.columnNARADU = new DataColumn("NARADU", typeof(int), "", MappingType.Element);
                this.columnNARADU.Caption = "NARADU";
                this.columnNARADU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNARADU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNARADU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNARADU.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNARADU.ExtendedProperties.Add("IsKey", "false");
                this.columnNARADU.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNARADU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNARADU.ExtendedProperties.Add("Description", "NARADU");
                this.columnNARADU.ExtendedProperties.Add("Length", "5");
                this.columnNARADU.ExtendedProperties.Add("Decimals", "0");
                this.columnNARADU.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNARADU.ExtendedProperties.Add("IsInReader", "true");
                this.columnNARADU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNARADU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNARADU.ExtendedProperties.Add("Deklarit.InternalName", "NARADU");
                this.Columns.Add(this.columnNARADU);
                this.columnNAKNADA = new DataColumn("NAKNADA", typeof(int), "", MappingType.Element);
                this.columnNAKNADA.Caption = "NAKNADA";
                this.columnNAKNADA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAKNADA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAKNADA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAKNADA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAKNADA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAKNADA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAKNADA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNAKNADA.ExtendedProperties.Add("Description", "NAKNADA");
                this.columnNAKNADA.ExtendedProperties.Add("Length", "5");
                this.columnNAKNADA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAKNADA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAKNADA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAKNADA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAKNADA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAKNADA.ExtendedProperties.Add("Deklarit.InternalName", "NAKNADA");
                this.Columns.Add(this.columnNAKNADA);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_TABLICA01");
                this.ExtendedProperties.Add("Description", "_S_OD_TABLICA01");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIZNOS = this.Columns["IZNOS"];
                this.columnMJESECOBRACUNA = this.Columns["MJESECOBRACUNA"];
                this.columnGODINAOBRACUNA = this.Columns["GODINAOBRACUNA"];
                this.columnNARADU = this.Columns["NARADU"];
                this.columnNAKNADA = this.Columns["NAKNADA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_TABLICA01DataSet.S_OD_TABLICA01Row(builder);
            }

            public S_OD_TABLICA01DataSet.S_OD_TABLICA01Row NewS_OD_TABLICA01Row()
            {
                return (S_OD_TABLICA01DataSet.S_OD_TABLICA01Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_TABLICA01RowChanged != null)
                {
                    S_OD_TABLICA01DataSet.S_OD_TABLICA01RowChangeEventHandler handler = this.S_OD_TABLICA01RowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_TABLICA01DataSet.S_OD_TABLICA01RowChangeEvent((S_OD_TABLICA01DataSet.S_OD_TABLICA01Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_TABLICA01RowChanging != null)
                {
                    S_OD_TABLICA01DataSet.S_OD_TABLICA01RowChangeEventHandler handler = this.S_OD_TABLICA01RowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_TABLICA01DataSet.S_OD_TABLICA01RowChangeEvent((S_OD_TABLICA01DataSet.S_OD_TABLICA01Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_TABLICA01RowDeleted != null)
                {
                    S_OD_TABLICA01DataSet.S_OD_TABLICA01RowChangeEventHandler handler = this.S_OD_TABLICA01RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_TABLICA01DataSet.S_OD_TABLICA01RowChangeEvent((S_OD_TABLICA01DataSet.S_OD_TABLICA01Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_TABLICA01RowDeleting != null)
                {
                    S_OD_TABLICA01DataSet.S_OD_TABLICA01RowChangeEventHandler handler = this.S_OD_TABLICA01RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_TABLICA01DataSet.S_OD_TABLICA01RowChangeEvent((S_OD_TABLICA01DataSet.S_OD_TABLICA01Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_TABLICA01Row(S_OD_TABLICA01DataSet.S_OD_TABLICA01Row row)
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

            public DataColumn GODINAOBRACUNAColumn
            {
                get
                {
                    return this.columnGODINAOBRACUNA;
                }
            }

            public S_OD_TABLICA01DataSet.S_OD_TABLICA01Row this[int index]
            {
                get
                {
                    return (S_OD_TABLICA01DataSet.S_OD_TABLICA01Row) this.Rows[index];
                }
            }

            public DataColumn IZNOSColumn
            {
                get
                {
                    return this.columnIZNOS;
                }
            }

            public DataColumn MJESECOBRACUNAColumn
            {
                get
                {
                    return this.columnMJESECOBRACUNA;
                }
            }

            public DataColumn NAKNADAColumn
            {
                get
                {
                    return this.columnNAKNADA;
                }
            }

            public DataColumn NARADUColumn
            {
                get
                {
                    return this.columnNARADU;
                }
            }
        }

        public class S_OD_TABLICA01Row : DataRow
        {
            private S_OD_TABLICA01DataSet.S_OD_TABLICA01DataTable tableS_OD_TABLICA01;

            internal S_OD_TABLICA01Row(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_TABLICA01 = (S_OD_TABLICA01DataSet.S_OD_TABLICA01DataTable) this.Table;
            }

            public bool IsGODINAOBRACUNANull()
            {
                return this.IsNull(this.tableS_OD_TABLICA01.GODINAOBRACUNAColumn);
            }

            public bool IsIZNOSNull()
            {
                return this.IsNull(this.tableS_OD_TABLICA01.IZNOSColumn);
            }

            public bool IsMJESECOBRACUNANull()
            {
                return this.IsNull(this.tableS_OD_TABLICA01.MJESECOBRACUNAColumn);
            }

            public bool IsNAKNADANull()
            {
                return this.IsNull(this.tableS_OD_TABLICA01.NAKNADAColumn);
            }

            public bool IsNARADUNull()
            {
                return this.IsNull(this.tableS_OD_TABLICA01.NARADUColumn);
            }

            public void SetGODINAOBRACUNANull()
            {
                this[this.tableS_OD_TABLICA01.GODINAOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSNull()
            {
                this[this.tableS_OD_TABLICA01.IZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECOBRACUNANull()
            {
                this[this.tableS_OD_TABLICA01.MJESECOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAKNADANull()
            {
                this[this.tableS_OD_TABLICA01.NAKNADAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNARADUNull()
            {
                this[this.tableS_OD_TABLICA01.NARADUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string GODINAOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_TABLICA01.GODINAOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value GODINAOBRACUNA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_TABLICA01.GODINAOBRACUNAColumn] = value;
                }
            }

            public decimal IZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_TABLICA01.IZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        ////InvalidCastException innerException = exception1;
                        ////throw new StrongTypingException("Cannot get value IZNOS because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_TABLICA01.IZNOSColumn] = value;
                }
            }

            public string MJESECOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_TABLICA01.MJESECOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value MJESECOBRACUNA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_TABLICA01.MJESECOBRACUNAColumn] = value;
                }
            }

            public int NAKNADA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_TABLICA01.NAKNADAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAKNADA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_TABLICA01.NAKNADAColumn] = value;
                }
            }

            public int NARADU
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_TABLICA01.NARADUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NARADU because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_TABLICA01.NARADUColumn] = value;
                }
            }
        }

        public class S_OD_TABLICA01RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_TABLICA01DataSet.S_OD_TABLICA01Row eventRow;

            public S_OD_TABLICA01RowChangeEvent(S_OD_TABLICA01DataSet.S_OD_TABLICA01Row row, DataRowAction action)
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

            public S_OD_TABLICA01DataSet.S_OD_TABLICA01Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_TABLICA01RowChangeEventHandler(object sender, S_OD_TABLICA01DataSet.S_OD_TABLICA01RowChangeEvent e);
    }
}

