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
    public class S_OS_STANJE_FINANCIJSKODataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OS_STANJE_FINANCIJSKODataTable tableS_OS_STANJE_FINANCIJSKO;

        public S_OS_STANJE_FINANCIJSKODataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OS_STANJE_FINANCIJSKODataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OS_STANJE_FINANCIJSKO"] != null)
                    {
                        this.Tables.Add(new S_OS_STANJE_FINANCIJSKODataTable(dataSet.Tables["S_OS_STANJE_FINANCIJSKO"]));
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
            S_OS_STANJE_FINANCIJSKODataSet set = (S_OS_STANJE_FINANCIJSKODataSet) base.Clone();
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
            S_OS_STANJE_FINANCIJSKODataSet set = new S_OS_STANJE_FINANCIJSKODataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OS_STANJE_FINANCIJSKODataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2157");
            this.ExtendedProperties.Add("DataSetName", "S_OS_STANJE_FINANCIJSKODataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OS_STANJE_FINANCIJSKODataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OS_STANJE_FINANCIJSKO");
            this.ExtendedProperties.Add("ObjectDescription", "S_OS_STANJE_FINANCIJSKO");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\OSNOVNA");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_OS_STANJE_FINANCIJSKO");
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
            this.DataSetName = "S_OS_STANJE_FINANCIJSKODataSet";
            this.Namespace = "http://www.tempuri.org/S_OS_STANJE_FINANCIJSKO";
            this.tableS_OS_STANJE_FINANCIJSKO = new S_OS_STANJE_FINANCIJSKODataTable();
            this.Tables.Add(this.tableS_OS_STANJE_FINANCIJSKO);
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
            this.tableS_OS_STANJE_FINANCIJSKO = (S_OS_STANJE_FINANCIJSKODataTable) this.Tables["S_OS_STANJE_FINANCIJSKO"];
            if (initTable && (this.tableS_OS_STANJE_FINANCIJSKO != null))
            {
                this.tableS_OS_STANJE_FINANCIJSKO.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OS_STANJE_FINANCIJSKO"] != null)
                {
                    this.Tables.Add(new S_OS_STANJE_FINANCIJSKODataTable(dataSet.Tables["S_OS_STANJE_FINANCIJSKO"]));
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

        private bool ShouldSerializeS_OS_STANJE_FINANCIJSKO()
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
        public S_OS_STANJE_FINANCIJSKODataTable S_OS_STANJE_FINANCIJSKO
        {
            get
            {
                return this.tableS_OS_STANJE_FINANCIJSKO;
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
        public class S_OS_STANJE_FINANCIJSKODataTable : DataTable, IEnumerable
        {
            private DataColumn columnINVBROJ;
            private DataColumn columnISPRAVAK;
            private DataColumn columnKOLICINA;
            private DataColumn columnNABAVNA;
            private DataColumn columnSADASNJA;

            public event S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORowChangeEventHandler S_OS_STANJE_FINANCIJSKORowChanged;

            public event S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORowChangeEventHandler S_OS_STANJE_FINANCIJSKORowChanging;

            public event S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORowChangeEventHandler S_OS_STANJE_FINANCIJSKORowDeleted;

            public event S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORowChangeEventHandler S_OS_STANJE_FINANCIJSKORowDeleting;

            public S_OS_STANJE_FINANCIJSKODataTable()
            {
                this.TableName = "S_OS_STANJE_FINANCIJSKO";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OS_STANJE_FINANCIJSKODataTable(DataTable table) : base(table.TableName)
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

            protected S_OS_STANJE_FINANCIJSKODataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OS_STANJE_FINANCIJSKORow(S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow row)
            {
                this.Rows.Add(row);
            }

            public S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow AddS_OS_STANJE_FINANCIJSKORow(long iNVBROJ, decimal nABAVNA, decimal iSPRAVAK, decimal sADASNJA, decimal kOLICINA)
            {
                S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow row = (S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow) this.NewRow();
                row.ItemArray = new object[] { iNVBROJ, nABAVNA, iSPRAVAK, sADASNJA, kOLICINA };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKODataTable table = (S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKODataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OS_STANJE_FINANCIJSKODataSet set = new S_OS_STANJE_FINANCIJSKODataSet();
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
                this.columnINVBROJ.ExtendedProperties.Add("Description", "Inventarni broj");
                this.columnINVBROJ.ExtendedProperties.Add("Length", "12");
                this.columnINVBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnINVBROJ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnINVBROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.InternalName", "INVBROJ");
                this.Columns.Add(this.columnINVBROJ);
                this.columnNABAVNA = new DataColumn("NABAVNA", typeof(decimal), "", MappingType.Element);
                this.columnNABAVNA.Caption = "Nabavna";
                this.columnNABAVNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNABAVNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNABAVNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNABAVNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNABAVNA.ExtendedProperties.Add("IsKey", "false");
                this.columnNABAVNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNABAVNA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNABAVNA.ExtendedProperties.Add("Description", "Nabavna");
                this.columnNABAVNA.ExtendedProperties.Add("Length", "12");
                this.columnNABAVNA.ExtendedProperties.Add("Decimals", "2");
                this.columnNABAVNA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNABAVNA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNABAVNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNABAVNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNABAVNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNABAVNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNABAVNA.ExtendedProperties.Add("Deklarit.InternalName", "NABAVNA");
                this.Columns.Add(this.columnNABAVNA);
                this.columnISPRAVAK = new DataColumn("ISPRAVAK", typeof(decimal), "", MappingType.Element);
                this.columnISPRAVAK.Caption = "Ispravak";
                this.columnISPRAVAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnISPRAVAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnISPRAVAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnISPRAVAK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnISPRAVAK.ExtendedProperties.Add("IsKey", "false");
                this.columnISPRAVAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnISPRAVAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnISPRAVAK.ExtendedProperties.Add("Description", "Ispravak");
                this.columnISPRAVAK.ExtendedProperties.Add("Length", "12");
                this.columnISPRAVAK.ExtendedProperties.Add("Decimals", "2");
                this.columnISPRAVAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnISPRAVAK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnISPRAVAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnISPRAVAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnISPRAVAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnISPRAVAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnISPRAVAK.ExtendedProperties.Add("Deklarit.InternalName", "ISPRAVAK");
                this.Columns.Add(this.columnISPRAVAK);
                this.columnSADASNJA = new DataColumn("SADASNJA", typeof(decimal), "", MappingType.Element);
                this.columnSADASNJA.Caption = "Sadašnja";
                this.columnSADASNJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSADASNJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSADASNJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSADASNJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSADASNJA.ExtendedProperties.Add("IsKey", "false");
                this.columnSADASNJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSADASNJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSADASNJA.ExtendedProperties.Add("Description", "Sadašnja");
                this.columnSADASNJA.ExtendedProperties.Add("Length", "12");
                this.columnSADASNJA.ExtendedProperties.Add("Decimals", "2");
                this.columnSADASNJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSADASNJA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSADASNJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSADASNJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSADASNJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSADASNJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSADASNJA.ExtendedProperties.Add("Deklarit.InternalName", "SADASNJA");
                this.Columns.Add(this.columnSADASNJA);
                this.columnKOLICINA = new DataColumn("KOLICINA", typeof(decimal), "", MappingType.Element);
                this.columnKOLICINA.Caption = "Količina";
                this.columnKOLICINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOLICINA.ExtendedProperties.Add("IsKey", "false");
                this.columnKOLICINA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOLICINA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOLICINA.ExtendedProperties.Add("Description", "Količina");
                this.columnKOLICINA.ExtendedProperties.Add("Length", "12");
                this.columnKOLICINA.ExtendedProperties.Add("Decimals", "2");
                this.columnKOLICINA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOLICINA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOLICINA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKOLICINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.InternalName", "KOLICINA");
                this.Columns.Add(this.columnKOLICINA);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OS_STANJE_FINANCIJSKO");
                this.ExtendedProperties.Add("Description", "S_OS_STANJE_FINANCIJSKO");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnINVBROJ = this.Columns["INVBROJ"];
                this.columnNABAVNA = this.Columns["NABAVNA"];
                this.columnISPRAVAK = this.Columns["ISPRAVAK"];
                this.columnSADASNJA = this.Columns["SADASNJA"];
                this.columnKOLICINA = this.Columns["KOLICINA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow(builder);
            }

            public S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow NewS_OS_STANJE_FINANCIJSKORow()
            {
                return (S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OS_STANJE_FINANCIJSKORowChanged != null)
                {
                    S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORowChangeEventHandler handler = this.S_OS_STANJE_FINANCIJSKORowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORowChangeEvent((S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OS_STANJE_FINANCIJSKORowChanging != null)
                {
                    S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORowChangeEventHandler handler = this.S_OS_STANJE_FINANCIJSKORowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORowChangeEvent((S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OS_STANJE_FINANCIJSKORowDeleted != null)
                {
                    S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORowChangeEventHandler handler = this.S_OS_STANJE_FINANCIJSKORowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORowChangeEvent((S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OS_STANJE_FINANCIJSKORowDeleting != null)
                {
                    S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORowChangeEventHandler handler = this.S_OS_STANJE_FINANCIJSKORowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORowChangeEvent((S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OS_STANJE_FINANCIJSKORow(S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow row)
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

            public DataColumn INVBROJColumn
            {
                get
                {
                    return this.columnINVBROJ;
                }
            }

            public DataColumn ISPRAVAKColumn
            {
                get
                {
                    return this.columnISPRAVAK;
                }
            }

            public S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow this[int index]
            {
                get
                {
                    return (S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow) this.Rows[index];
                }
            }

            public DataColumn KOLICINAColumn
            {
                get
                {
                    return this.columnKOLICINA;
                }
            }

            public DataColumn NABAVNAColumn
            {
                get
                {
                    return this.columnNABAVNA;
                }
            }

            public DataColumn SADASNJAColumn
            {
                get
                {
                    return this.columnSADASNJA;
                }
            }
        }

        public class S_OS_STANJE_FINANCIJSKORow : DataRow
        {
            private S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKODataTable tableS_OS_STANJE_FINANCIJSKO;

            internal S_OS_STANJE_FINANCIJSKORow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OS_STANJE_FINANCIJSKO = (S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKODataTable) this.Table;
            }

            public bool IsINVBROJNull()
            {
                return this.IsNull(this.tableS_OS_STANJE_FINANCIJSKO.INVBROJColumn);
            }

            public bool IsISPRAVAKNull()
            {
                return this.IsNull(this.tableS_OS_STANJE_FINANCIJSKO.ISPRAVAKColumn);
            }

            public bool IsKOLICINANull()
            {
                return this.IsNull(this.tableS_OS_STANJE_FINANCIJSKO.KOLICINAColumn);
            }

            public bool IsNABAVNANull()
            {
                return this.IsNull(this.tableS_OS_STANJE_FINANCIJSKO.NABAVNAColumn);
            }

            public bool IsSADASNJANull()
            {
                return this.IsNull(this.tableS_OS_STANJE_FINANCIJSKO.SADASNJAColumn);
            }

            public void SetINVBROJNull()
            {
                this[this.tableS_OS_STANJE_FINANCIJSKO.INVBROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetISPRAVAKNull()
            {
                this[this.tableS_OS_STANJE_FINANCIJSKO.ISPRAVAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOLICINANull()
            {
                this[this.tableS_OS_STANJE_FINANCIJSKO.KOLICINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNABAVNANull()
            {
                this[this.tableS_OS_STANJE_FINANCIJSKO.NABAVNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSADASNJANull()
            {
                this[this.tableS_OS_STANJE_FINANCIJSKO.SADASNJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public long INVBROJ
            {
                get
                {
                    long num;
                    try
                    {
                        num = Conversions.ToLong(this[this.tableS_OS_STANJE_FINANCIJSKO.INVBROJColumn]);
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
                    this[this.tableS_OS_STANJE_FINANCIJSKO.INVBROJColumn] = value;
                }
            }

            public decimal ISPRAVAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_STANJE_FINANCIJSKO.ISPRAVAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ISPRAVAK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_STANJE_FINANCIJSKO.ISPRAVAKColumn] = value;
                }
            }

            public decimal KOLICINA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_STANJE_FINANCIJSKO.KOLICINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value KOLICINA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_STANJE_FINANCIJSKO.KOLICINAColumn] = value;
                }
            }

            public decimal NABAVNA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_STANJE_FINANCIJSKO.NABAVNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NABAVNA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_STANJE_FINANCIJSKO.NABAVNAColumn] = value;
                }
            }

            public decimal SADASNJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_STANJE_FINANCIJSKO.SADASNJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SADASNJA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_STANJE_FINANCIJSKO.SADASNJAColumn] = value;
                }
            }
        }

        public class S_OS_STANJE_FINANCIJSKORowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow eventRow;

            public S_OS_STANJE_FINANCIJSKORowChangeEvent(S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow row, DataRowAction action)
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

            public S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OS_STANJE_FINANCIJSKORowChangeEventHandler(object sender, S_OS_STANJE_FINANCIJSKODataSet.S_OS_STANJE_FINANCIJSKORowChangeEvent e);
    }
}

