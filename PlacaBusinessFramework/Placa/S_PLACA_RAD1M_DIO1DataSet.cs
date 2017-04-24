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
    public class S_PLACA_RAD1M_DIO1DataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_PLACA_RAD1M_DIO1DataTable tableS_PLACA_RAD1M_DIO1;

        public S_PLACA_RAD1M_DIO1DataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_PLACA_RAD1M_DIO1DataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_PLACA_RAD1M_DIO1"] != null)
                    {
                        this.Tables.Add(new S_PLACA_RAD1M_DIO1DataTable(dataSet.Tables["S_PLACA_RAD1M_DIO1"]));
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
            S_PLACA_RAD1M_DIO1DataSet set = (S_PLACA_RAD1M_DIO1DataSet) base.Clone();
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
            S_PLACA_RAD1M_DIO1DataSet set = new S_PLACA_RAD1M_DIO1DataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_PLACA_RAD1M_DIO1DataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2180");
            this.ExtendedProperties.Add("DataSetName", "S_PLACA_RAD1M_DIO1DataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_PLACA_RAD1M_DIO1DataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_PLACA_RAD1M_DIO1");
            this.ExtendedProperties.Add("ObjectDescription", "S_PLACA_RAD1M_DIO1");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_RAD1M_DIO1");
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
            this.DataSetName = "S_PLACA_RAD1M_DIO1DataSet";
            this.Namespace = "http://www.tempuri.org/S_PLACA_RAD1M_DIO1";
            this.tableS_PLACA_RAD1M_DIO1 = new S_PLACA_RAD1M_DIO1DataTable();
            this.Tables.Add(this.tableS_PLACA_RAD1M_DIO1);
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
            this.tableS_PLACA_RAD1M_DIO1 = (S_PLACA_RAD1M_DIO1DataTable) this.Tables["S_PLACA_RAD1M_DIO1"];
            if (initTable && (this.tableS_PLACA_RAD1M_DIO1 != null))
            {
                this.tableS_PLACA_RAD1M_DIO1.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_PLACA_RAD1M_DIO1"] != null)
                {
                    this.Tables.Add(new S_PLACA_RAD1M_DIO1DataTable(dataSet.Tables["S_PLACA_RAD1M_DIO1"]));
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

        private bool ShouldSerializeS_PLACA_RAD1M_DIO1()
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
        public S_PLACA_RAD1M_DIO1DataTable S_PLACA_RAD1M_DIO1
        {
            get
            {
                return this.tableS_PLACA_RAD1M_DIO1;
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
        public class S_PLACA_RAD1M_DIO1DataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJDOSLIH;
            private DataColumn columnBROJDOSLIHZENA;
            private DataColumn columnBROJOTISLIH;
            private DataColumn columnBROJOTISLIHZENA;
            private DataColumn columnBROJRADNIKAUKUPNO;
            private DataColumn columnBROJZENA;

            public event S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1RowChangeEventHandler S_PLACA_RAD1M_DIO1RowChanged;

            public event S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1RowChangeEventHandler S_PLACA_RAD1M_DIO1RowChanging;

            public event S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1RowChangeEventHandler S_PLACA_RAD1M_DIO1RowDeleted;

            public event S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1RowChangeEventHandler S_PLACA_RAD1M_DIO1RowDeleting;

            public S_PLACA_RAD1M_DIO1DataTable()
            {
                this.TableName = "S_PLACA_RAD1M_DIO1";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_PLACA_RAD1M_DIO1DataTable(DataTable table) : base(table.TableName)
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

            protected S_PLACA_RAD1M_DIO1DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_PLACA_RAD1M_DIO1Row(S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row row)
            {
                this.Rows.Add(row);
            }

            public S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row AddS_PLACA_RAD1M_DIO1Row(int bROJDOSLIH, int bROJOTISLIH, int bROJDOSLIHZENA, int bROJOTISLIHZENA, int bROJZENA, int bROJRADNIKAUKUPNO)
            {
                S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row row = (S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row) this.NewRow();
                row.ItemArray = new object[] { bROJDOSLIH, bROJOTISLIH, bROJDOSLIHZENA, bROJOTISLIHZENA, bROJZENA, bROJRADNIKAUKUPNO };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1DataTable table = (S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_PLACA_RAD1M_DIO1DataSet set = new S_PLACA_RAD1M_DIO1DataSet();
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
                this.columnBROJDOSLIH = new DataColumn("BROJDOSLIH", typeof(int), "", MappingType.Element);
                this.columnBROJDOSLIH.Caption = "BROJDOSLIH";
                this.columnBROJDOSLIH.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJDOSLIH.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJDOSLIH.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJDOSLIH.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJDOSLIH.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJDOSLIH.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJDOSLIH.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJDOSLIH.ExtendedProperties.Add("Description", "BROJDOSLIH");
                this.columnBROJDOSLIH.ExtendedProperties.Add("Length", "5");
                this.columnBROJDOSLIH.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJDOSLIH.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJDOSLIH.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJDOSLIH.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJDOSLIH.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJDOSLIH.ExtendedProperties.Add("Deklarit.InternalName", "BROJDOSLIH");
                this.Columns.Add(this.columnBROJDOSLIH);
                this.columnBROJOTISLIH = new DataColumn("BROJOTISLIH", typeof(int), "", MappingType.Element);
                this.columnBROJOTISLIH.Caption = "BROJOTISLIH";
                this.columnBROJOTISLIH.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJOTISLIH.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJOTISLIH.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJOTISLIH.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJOTISLIH.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJOTISLIH.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJOTISLIH.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJOTISLIH.ExtendedProperties.Add("Description", "BROJOTISLIH");
                this.columnBROJOTISLIH.ExtendedProperties.Add("Length", "5");
                this.columnBROJOTISLIH.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJOTISLIH.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJOTISLIH.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJOTISLIH.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJOTISLIH.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJOTISLIH.ExtendedProperties.Add("Deklarit.InternalName", "BROJOTISLIH");
                this.Columns.Add(this.columnBROJOTISLIH);
                this.columnBROJDOSLIHZENA = new DataColumn("BROJDOSLIHZENA", typeof(int), "", MappingType.Element);
                this.columnBROJDOSLIHZENA.Caption = "BROJDOSLIHZENA";
                this.columnBROJDOSLIHZENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("Description", "BROJDOSLIHZENA");
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("Length", "5");
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJDOSLIHZENA.ExtendedProperties.Add("Deklarit.InternalName", "BROJDOSLIHZENA");
                this.Columns.Add(this.columnBROJDOSLIHZENA);
                this.columnBROJOTISLIHZENA = new DataColumn("BROJOTISLIHZENA", typeof(int), "", MappingType.Element);
                this.columnBROJOTISLIHZENA.Caption = "BROJOTISLIHZENA";
                this.columnBROJOTISLIHZENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("Description", "BROJOTISLIHZENA");
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("Length", "5");
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJOTISLIHZENA.ExtendedProperties.Add("Deklarit.InternalName", "BROJOTISLIHZENA");
                this.Columns.Add(this.columnBROJOTISLIHZENA);
                this.columnBROJZENA = new DataColumn("BROJZENA", typeof(int), "", MappingType.Element);
                this.columnBROJZENA.Caption = "BROJZENA";
                this.columnBROJZENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJZENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJZENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJZENA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJZENA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJZENA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJZENA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJZENA.ExtendedProperties.Add("Description", "BROJZENA");
                this.columnBROJZENA.ExtendedProperties.Add("Length", "5");
                this.columnBROJZENA.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJZENA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJZENA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJZENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJZENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJZENA.ExtendedProperties.Add("Deklarit.InternalName", "BROJZENA");
                this.Columns.Add(this.columnBROJZENA);
                this.columnBROJRADNIKAUKUPNO = new DataColumn("BROJRADNIKAUKUPNO", typeof(int), "", MappingType.Element);
                this.columnBROJRADNIKAUKUPNO.Caption = "BROJRADNIKAUKUPNO";
                this.columnBROJRADNIKAUKUPNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("Description", "BROJRADNIKAUKUPNO");
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("Length", "5");
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRADNIKAUKUPNO.ExtendedProperties.Add("Deklarit.InternalName", "BROJRADNIKAUKUPNO");
                this.Columns.Add(this.columnBROJRADNIKAUKUPNO);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_PLACA_RAD1M_DIO1");
                this.ExtendedProperties.Add("Description", "S_PLACA_RAD1M_DIO1");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnBROJDOSLIH = this.Columns["BROJDOSLIH"];
                this.columnBROJOTISLIH = this.Columns["BROJOTISLIH"];
                this.columnBROJDOSLIHZENA = this.Columns["BROJDOSLIHZENA"];
                this.columnBROJOTISLIHZENA = this.Columns["BROJOTISLIHZENA"];
                this.columnBROJZENA = this.Columns["BROJZENA"];
                this.columnBROJRADNIKAUKUPNO = this.Columns["BROJRADNIKAUKUPNO"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row(builder);
            }

            public S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row NewS_PLACA_RAD1M_DIO1Row()
            {
                return (S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_PLACA_RAD1M_DIO1RowChanged != null)
                {
                    S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1RowChangeEventHandler handler = this.S_PLACA_RAD1M_DIO1RowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1RowChangeEvent((S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_PLACA_RAD1M_DIO1RowChanging != null)
                {
                    S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1RowChangeEventHandler handler = this.S_PLACA_RAD1M_DIO1RowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1RowChangeEvent((S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_PLACA_RAD1M_DIO1RowDeleted != null)
                {
                    S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1RowChangeEventHandler handler = this.S_PLACA_RAD1M_DIO1RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1RowChangeEvent((S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_PLACA_RAD1M_DIO1RowDeleting != null)
                {
                    S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1RowChangeEventHandler handler = this.S_PLACA_RAD1M_DIO1RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1RowChangeEvent((S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_PLACA_RAD1M_DIO1Row(S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJDOSLIHColumn
            {
                get
                {
                    return this.columnBROJDOSLIH;
                }
            }

            public DataColumn BROJDOSLIHZENAColumn
            {
                get
                {
                    return this.columnBROJDOSLIHZENA;
                }
            }

            public DataColumn BROJOTISLIHColumn
            {
                get
                {
                    return this.columnBROJOTISLIH;
                }
            }

            public DataColumn BROJOTISLIHZENAColumn
            {
                get
                {
                    return this.columnBROJOTISLIHZENA;
                }
            }

            public DataColumn BROJRADNIKAUKUPNOColumn
            {
                get
                {
                    return this.columnBROJRADNIKAUKUPNO;
                }
            }

            public DataColumn BROJZENAColumn
            {
                get
                {
                    return this.columnBROJZENA;
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

            public S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row this[int index]
            {
                get
                {
                    return (S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row) this.Rows[index];
                }
            }
        }

        public class S_PLACA_RAD1M_DIO1Row : DataRow
        {
            private S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1DataTable tableS_PLACA_RAD1M_DIO1;

            internal S_PLACA_RAD1M_DIO1Row(DataRowBuilder rb) : base(rb)
            {
                this.tableS_PLACA_RAD1M_DIO1 = (S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1DataTable) this.Table;
            }

            public bool IsBROJDOSLIHNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO1.BROJDOSLIHColumn);
            }

            public bool IsBROJDOSLIHZENANull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO1.BROJDOSLIHZENAColumn);
            }

            public bool IsBROJOTISLIHNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO1.BROJOTISLIHColumn);
            }

            public bool IsBROJOTISLIHZENANull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO1.BROJOTISLIHZENAColumn);
            }

            public bool IsBROJRADNIKAUKUPNONull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO1.BROJRADNIKAUKUPNOColumn);
            }

            public bool IsBROJZENANull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO1.BROJZENAColumn);
            }

            public void SetBROJDOSLIHNull()
            {
                this[this.tableS_PLACA_RAD1M_DIO1.BROJDOSLIHColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJDOSLIHZENANull()
            {
                this[this.tableS_PLACA_RAD1M_DIO1.BROJDOSLIHZENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJOTISLIHNull()
            {
                this[this.tableS_PLACA_RAD1M_DIO1.BROJOTISLIHColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJOTISLIHZENANull()
            {
                this[this.tableS_PLACA_RAD1M_DIO1.BROJOTISLIHZENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJRADNIKAUKUPNONull()
            {
                this[this.tableS_PLACA_RAD1M_DIO1.BROJRADNIKAUKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJZENANull()
            {
                this[this.tableS_PLACA_RAD1M_DIO1.BROJZENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BROJDOSLIH
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_PLACA_RAD1M_DIO1.BROJDOSLIHColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJDOSLIH because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO1.BROJDOSLIHColumn] = value;
                }
            }

            public int BROJDOSLIHZENA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_PLACA_RAD1M_DIO1.BROJDOSLIHZENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJDOSLIHZENA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO1.BROJDOSLIHZENAColumn] = value;
                }
            }

            public int BROJOTISLIH
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_PLACA_RAD1M_DIO1.BROJOTISLIHColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJOTISLIH because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO1.BROJOTISLIHColumn] = value;
                }
            }

            public int BROJOTISLIHZENA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_PLACA_RAD1M_DIO1.BROJOTISLIHZENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJOTISLIHZENA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO1.BROJOTISLIHZENAColumn] = value;
                }
            }

            public int BROJRADNIKAUKUPNO
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_PLACA_RAD1M_DIO1.BROJRADNIKAUKUPNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJRADNIKAUKUPNO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO1.BROJRADNIKAUKUPNOColumn] = value;
                }
            }

            public int BROJZENA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_PLACA_RAD1M_DIO1.BROJZENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJZENA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO1.BROJZENAColumn] = value;
                }
            }
        }

        public class S_PLACA_RAD1M_DIO1RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row eventRow;

            public S_PLACA_RAD1M_DIO1RowChangeEvent(S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row row, DataRowAction action)
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

            public S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_PLACA_RAD1M_DIO1RowChangeEventHandler(object sender, S_PLACA_RAD1M_DIO1DataSet.S_PLACA_RAD1M_DIO1RowChangeEvent e);
    }
}

