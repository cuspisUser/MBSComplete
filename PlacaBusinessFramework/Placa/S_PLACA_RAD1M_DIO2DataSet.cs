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
    public class S_PLACA_RAD1M_DIO2DataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_PLACA_RAD1M_DIO2DataTable tableS_PLACA_RAD1M_DIO2;

        public S_PLACA_RAD1M_DIO2DataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_PLACA_RAD1M_DIO2DataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_PLACA_RAD1M_DIO2"] != null)
                    {
                        this.Tables.Add(new S_PLACA_RAD1M_DIO2DataTable(dataSet.Tables["S_PLACA_RAD1M_DIO2"]));
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
            S_PLACA_RAD1M_DIO2DataSet set = (S_PLACA_RAD1M_DIO2DataSet) base.Clone();
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
            S_PLACA_RAD1M_DIO2DataSet set = new S_PLACA_RAD1M_DIO2DataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_PLACA_RAD1M_DIO2DataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2181");
            this.ExtendedProperties.Add("DataSetName", "S_PLACA_RAD1M_DIO2DataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_PLACA_RAD1M_DIO2DataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_PLACA_RAD1M_DIO2");
            this.ExtendedProperties.Add("ObjectDescription", "S_PLACA_RAD1M_DIO2");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_RAD1M_DIO2");
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
            this.DataSetName = "S_PLACA_RAD1M_DIO2DataSet";
            this.Namespace = "http://www.tempuri.org/S_PLACA_RAD1M_DIO2";
            this.tableS_PLACA_RAD1M_DIO2 = new S_PLACA_RAD1M_DIO2DataTable();
            this.Tables.Add(this.tableS_PLACA_RAD1M_DIO2);
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
            this.tableS_PLACA_RAD1M_DIO2 = (S_PLACA_RAD1M_DIO2DataTable) this.Tables["S_PLACA_RAD1M_DIO2"];
            if (initTable && (this.tableS_PLACA_RAD1M_DIO2 != null))
            {
                this.tableS_PLACA_RAD1M_DIO2.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_PLACA_RAD1M_DIO2"] != null)
                {
                    this.Tables.Add(new S_PLACA_RAD1M_DIO2DataTable(dataSet.Tables["S_PLACA_RAD1M_DIO2"]));
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

        private bool ShouldSerializeS_PLACA_RAD1M_DIO2()
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
        public S_PLACA_RAD1M_DIO2DataTable S_PLACA_RAD1M_DIO2
        {
            get
            {
                return this.tableS_PLACA_RAD1M_DIO2;
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
        public class S_PLACA_RAD1M_DIO2DataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJRADNIKANETO;
            private DataColumn columnBROJRADNIKANETOPOTPORE;
            private DataColumn columnBRUTO;
            private DataColumn columnDATISP;
            private DataColumn columnNBRUTO;
            private DataColumn columnNETO;
            private DataColumn columnNNETO;
            private DataColumn columnsatibruto;
            private DataColumn columnSVRHA;
            private DataColumn columnvrsta;

            public event S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2RowChangeEventHandler S_PLACA_RAD1M_DIO2RowChanged;

            public event S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2RowChangeEventHandler S_PLACA_RAD1M_DIO2RowChanging;

            public event S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2RowChangeEventHandler S_PLACA_RAD1M_DIO2RowDeleted;

            public event S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2RowChangeEventHandler S_PLACA_RAD1M_DIO2RowDeleting;

            public S_PLACA_RAD1M_DIO2DataTable()
            {
                this.TableName = "S_PLACA_RAD1M_DIO2";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_PLACA_RAD1M_DIO2DataTable(DataTable table) : base(table.TableName)
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

            protected S_PLACA_RAD1M_DIO2DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_PLACA_RAD1M_DIO2Row(S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row row)
            {
                this.Rows.Add(row);
            }

            public S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row AddS_PLACA_RAD1M_DIO2Row(int bROJRADNIKANETOPOTPORE, int bROJRADNIKANETO, decimal nETO, decimal bRUTO, decimal satibruto, decimal nNETO, decimal nBRUTO, string vrsta, string sVRHA, DateTime dATISP)
            {
                S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row row = (S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row) this.NewRow();
                row.ItemArray = new object[] { bROJRADNIKANETOPOTPORE, bROJRADNIKANETO, nETO, bRUTO, satibruto, nNETO, nBRUTO, vrsta, sVRHA, dATISP };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2DataTable table = (S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_PLACA_RAD1M_DIO2DataSet set = new S_PLACA_RAD1M_DIO2DataSet();
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
                this.columnBROJRADNIKANETOPOTPORE = new DataColumn("BROJRADNIKANETOPOTPORE", typeof(int), "", MappingType.Element);
                this.columnBROJRADNIKANETOPOTPORE.Caption = "BROJRADNIKANETOPOTPORE";
                this.columnBROJRADNIKANETOPOTPORE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("Description", "BROJRADNIKANETOPOTPORE");
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("Length", "5");
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRADNIKANETOPOTPORE.ExtendedProperties.Add("Deklarit.InternalName", "BROJRADNIKANETOPOTPORE");
                this.Columns.Add(this.columnBROJRADNIKANETOPOTPORE);
                this.columnBROJRADNIKANETO = new DataColumn("BROJRADNIKANETO", typeof(int), "", MappingType.Element);
                this.columnBROJRADNIKANETO.Caption = "BROJRADNIKANETO";
                this.columnBROJRADNIKANETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("Description", "BROJRADNIKANETO");
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("Length", "5");
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRADNIKANETO.ExtendedProperties.Add("Deklarit.InternalName", "BROJRADNIKANETO");
                this.Columns.Add(this.columnBROJRADNIKANETO);
                this.columnNETO = new DataColumn("NETO", typeof(decimal), "", MappingType.Element);
                this.columnNETO.Caption = "Neto";
                this.columnNETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNETO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNETO.ExtendedProperties.Add("IsKey", "false");
                this.columnNETO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNETO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNETO.ExtendedProperties.Add("Description", "Neto");
                this.columnNETO.ExtendedProperties.Add("Length", "12");
                this.columnNETO.ExtendedProperties.Add("Decimals", "2");
                this.columnNETO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNETO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNETO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNETO.ExtendedProperties.Add("Deklarit.InternalName", "NETO");
                this.Columns.Add(this.columnNETO);
                this.columnBRUTO = new DataColumn("BRUTO", typeof(decimal), "", MappingType.Element);
                this.columnBRUTO.Caption = "Primici";
                this.columnBRUTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBRUTO.ExtendedProperties.Add("IsKey", "false");
                this.columnBRUTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBRUTO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBRUTO.ExtendedProperties.Add("Description", "Primici");
                this.columnBRUTO.ExtendedProperties.Add("Length", "12");
                this.columnBRUTO.ExtendedProperties.Add("Decimals", "2");
                this.columnBRUTO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBRUTO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBRUTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBRUTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.InternalName", "BRUTO");
                this.Columns.Add(this.columnBRUTO);
                this.columnsatibruto = new DataColumn("satibruto", typeof(decimal), "", MappingType.Element);
                this.columnsatibruto.Caption = "satibruto";
                this.columnsatibruto.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsatibruto.ExtendedProperties.Add("IsKey", "false");
                this.columnsatibruto.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsatibruto.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsatibruto.ExtendedProperties.Add("Description", "satibruto");
                this.columnsatibruto.ExtendedProperties.Add("Length", "12");
                this.columnsatibruto.ExtendedProperties.Add("Decimals", "2");
                this.columnsatibruto.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsatibruto.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsatibruto.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsatibruto.ExtendedProperties.Add("IsInReader", "true");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.InternalName", "satibruto");
                this.Columns.Add(this.columnsatibruto);
                this.columnNNETO = new DataColumn("NNETO", typeof(decimal), "", MappingType.Element);
                this.columnNNETO.Caption = "NNETO";
                this.columnNNETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNNETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNNETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNNETO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNNETO.ExtendedProperties.Add("IsKey", "false");
                this.columnNNETO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNNETO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNNETO.ExtendedProperties.Add("Description", "NNETO");
                this.columnNNETO.ExtendedProperties.Add("Length", "12");
                this.columnNNETO.ExtendedProperties.Add("Decimals", "2");
                this.columnNNETO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNNETO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNNETO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNNETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNNETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNNETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNNETO.ExtendedProperties.Add("Deklarit.InternalName", "NNETO");
                this.Columns.Add(this.columnNNETO);
                this.columnNBRUTO = new DataColumn("NBRUTO", typeof(decimal), "", MappingType.Element);
                this.columnNBRUTO.Caption = "NBRUTO";
                this.columnNBRUTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNBRUTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNBRUTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNBRUTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNBRUTO.ExtendedProperties.Add("IsKey", "false");
                this.columnNBRUTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNBRUTO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNBRUTO.ExtendedProperties.Add("Description", "NBRUTO");
                this.columnNBRUTO.ExtendedProperties.Add("Length", "12");
                this.columnNBRUTO.ExtendedProperties.Add("Decimals", "2");
                this.columnNBRUTO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNBRUTO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNBRUTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNBRUTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNBRUTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNBRUTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNBRUTO.ExtendedProperties.Add("Deklarit.InternalName", "NBRUTO");
                this.Columns.Add(this.columnNBRUTO);
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
                this.columnSVRHA = new DataColumn("SVRHA", typeof(string), "", MappingType.Element);
                this.columnSVRHA.Caption = "SVRHA";
                this.columnSVRHA.MaxLength = 100;
                this.columnSVRHA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSVRHA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSVRHA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSVRHA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSVRHA.ExtendedProperties.Add("IsKey", "false");
                this.columnSVRHA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSVRHA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSVRHA.ExtendedProperties.Add("Description", "SVRHA");
                this.columnSVRHA.ExtendedProperties.Add("Length", "100");
                this.columnSVRHA.ExtendedProperties.Add("Decimals", "0");
                this.columnSVRHA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSVRHA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSVRHA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSVRHA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSVRHA.ExtendedProperties.Add("Deklarit.InternalName", "SVRHA");
                this.Columns.Add(this.columnSVRHA);
                this.columnDATISP = new DataColumn("DATISP", typeof(DateTime), "", MappingType.Element);
                this.columnDATISP.Caption = "DATISP";
                this.columnDATISP.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATISP.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATISP.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATISP.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDATISP.ExtendedProperties.Add("IsKey", "false");
                this.columnDATISP.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATISP.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATISP.ExtendedProperties.Add("Description", "DATISP");
                this.columnDATISP.ExtendedProperties.Add("Length", "8");
                this.columnDATISP.ExtendedProperties.Add("Decimals", "0");
                this.columnDATISP.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATISP.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATISP.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATISP.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATISP.ExtendedProperties.Add("Deklarit.InternalName", "DATISP");
                this.Columns.Add(this.columnDATISP);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_PLACA_RAD1M_DIO2");
                this.ExtendedProperties.Add("Description", "S_PLACA_RAD1M_DIO2");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnBROJRADNIKANETOPOTPORE = this.Columns["BROJRADNIKANETOPOTPORE"];
                this.columnBROJRADNIKANETO = this.Columns["BROJRADNIKANETO"];
                this.columnNETO = this.Columns["NETO"];
                this.columnBRUTO = this.Columns["BRUTO"];
                this.columnsatibruto = this.Columns["satibruto"];
                this.columnNNETO = this.Columns["NNETO"];
                this.columnNBRUTO = this.Columns["NBRUTO"];
                this.columnvrsta = this.Columns["vrsta"];
                this.columnSVRHA = this.Columns["SVRHA"];
                this.columnDATISP = this.Columns["DATISP"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row(builder);
            }

            public S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row NewS_PLACA_RAD1M_DIO2Row()
            {
                return (S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_PLACA_RAD1M_DIO2RowChanged != null)
                {
                    S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2RowChangeEventHandler handler = this.S_PLACA_RAD1M_DIO2RowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2RowChangeEvent((S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_PLACA_RAD1M_DIO2RowChanging != null)
                {
                    S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2RowChangeEventHandler handler = this.S_PLACA_RAD1M_DIO2RowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2RowChangeEvent((S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_PLACA_RAD1M_DIO2RowDeleted != null)
                {
                    S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2RowChangeEventHandler handler = this.S_PLACA_RAD1M_DIO2RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2RowChangeEvent((S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_PLACA_RAD1M_DIO2RowDeleting != null)
                {
                    S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2RowChangeEventHandler handler = this.S_PLACA_RAD1M_DIO2RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2RowChangeEvent((S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_PLACA_RAD1M_DIO2Row(S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJRADNIKANETOColumn
            {
                get
                {
                    return this.columnBROJRADNIKANETO;
                }
            }

            public DataColumn BROJRADNIKANETOPOTPOREColumn
            {
                get
                {
                    return this.columnBROJRADNIKANETOPOTPORE;
                }
            }

            public DataColumn BRUTOColumn
            {
                get
                {
                    return this.columnBRUTO;
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

            public DataColumn DATISPColumn
            {
                get
                {
                    return this.columnDATISP;
                }
            }

            public S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row this[int index]
            {
                get
                {
                    return (S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row) this.Rows[index];
                }
            }

            public DataColumn NBRUTOColumn
            {
                get
                {
                    return this.columnNBRUTO;
                }
            }

            public DataColumn NETOColumn
            {
                get
                {
                    return this.columnNETO;
                }
            }

            public DataColumn NNETOColumn
            {
                get
                {
                    return this.columnNNETO;
                }
            }

            public DataColumn satibrutoColumn
            {
                get
                {
                    return this.columnsatibruto;
                }
            }

            public DataColumn SVRHAColumn
            {
                get
                {
                    return this.columnSVRHA;
                }
            }

            public DataColumn vrstaColumn
            {
                get
                {
                    return this.columnvrsta;
                }
            }
        }

        public class S_PLACA_RAD1M_DIO2Row : DataRow
        {
            private S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2DataTable tableS_PLACA_RAD1M_DIO2;

            internal S_PLACA_RAD1M_DIO2Row(DataRowBuilder rb) : base(rb)
            {
                this.tableS_PLACA_RAD1M_DIO2 = (S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2DataTable) this.Table;
            }

            public bool IsBROJRADNIKANETONull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO2.BROJRADNIKANETOColumn);
            }

            public bool IsBROJRADNIKANETOPOTPORENull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO2.BROJRADNIKANETOPOTPOREColumn);
            }

            public bool IsBRUTONull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO2.BRUTOColumn);
            }

            public bool IsDATISPNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO2.DATISPColumn);
            }

            public bool IsNBRUTONull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO2.NBRUTOColumn);
            }

            public bool IsNETONull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO2.NETOColumn);
            }

            public bool IsNNETONull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO2.NNETOColumn);
            }

            public bool IssatibrutoNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO2.satibrutoColumn);
            }

            public bool IsSVRHANull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO2.SVRHAColumn);
            }

            public bool IsvrstaNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO2.vrstaColumn);
            }

            public void SetBROJRADNIKANETONull()
            {
                this[this.tableS_PLACA_RAD1M_DIO2.BROJRADNIKANETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJRADNIKANETOPOTPORENull()
            {
                this[this.tableS_PLACA_RAD1M_DIO2.BROJRADNIKANETOPOTPOREColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBRUTONull()
            {
                this[this.tableS_PLACA_RAD1M_DIO2.BRUTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATISPNull()
            {
                this[this.tableS_PLACA_RAD1M_DIO2.DATISPColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNBRUTONull()
            {
                this[this.tableS_PLACA_RAD1M_DIO2.NBRUTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNETONull()
            {
                this[this.tableS_PLACA_RAD1M_DIO2.NETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNNETONull()
            {
                this[this.tableS_PLACA_RAD1M_DIO2.NNETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetsatibrutoNull()
            {
                this[this.tableS_PLACA_RAD1M_DIO2.satibrutoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSVRHANull()
            {
                this[this.tableS_PLACA_RAD1M_DIO2.SVRHAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetvrstaNull()
            {
                this[this.tableS_PLACA_RAD1M_DIO2.vrstaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BROJRADNIKANETO
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_PLACA_RAD1M_DIO2.BROJRADNIKANETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJRADNIKANETO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO2.BROJRADNIKANETOColumn] = value;
                }
            }

            public int BROJRADNIKANETOPOTPORE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_PLACA_RAD1M_DIO2.BROJRADNIKANETOPOTPOREColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJRADNIKANETOPOTPORE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO2.BROJRADNIKANETOPOTPOREColumn] = value;
                }
            }

            public decimal BRUTO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1M_DIO2.BRUTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BRUTO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO2.BRUTOColumn] = value;
                }
            }

            public DateTime DATISP
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_PLACA_RAD1M_DIO2.DATISPColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO2.DATISPColumn] = value;
                }
            }

            public decimal NBRUTO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1M_DIO2.NBRUTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO2.NBRUTOColumn] = value;
                }
            }

            public decimal NETO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1M_DIO2.NETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO2.NETOColumn] = value;
                }
            }

            public decimal NNETO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1M_DIO2.NNETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO2.NNETOColumn] = value;
                }
            }

            public decimal satibruto
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1M_DIO2.satibrutoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO2.satibrutoColumn] = value;
                }
            }

            public string SVRHA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_RAD1M_DIO2.SVRHAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO2.SVRHAColumn] = value;
                }
            }

            public string vrsta
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_RAD1M_DIO2.vrstaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO2.vrstaColumn] = value;
                }
            }
        }

        public class S_PLACA_RAD1M_DIO2RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row eventRow;

            public S_PLACA_RAD1M_DIO2RowChangeEvent(S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row row, DataRowAction action)
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

            public S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_PLACA_RAD1M_DIO2RowChangeEventHandler(object sender, S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2RowChangeEvent e);
    }
}

