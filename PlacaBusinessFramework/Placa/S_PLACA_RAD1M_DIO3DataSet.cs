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
    public class S_PLACA_RAD1M_DIO3DataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_PLACA_RAD1M_DIO3DataTable tableS_PLACA_RAD1M_DIO3;

        public S_PLACA_RAD1M_DIO3DataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_PLACA_RAD1M_DIO3DataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_PLACA_RAD1M_DIO3"] != null)
                    {
                        this.Tables.Add(new S_PLACA_RAD1M_DIO3DataTable(dataSet.Tables["S_PLACA_RAD1M_DIO3"]));
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
            S_PLACA_RAD1M_DIO3DataSet set = (S_PLACA_RAD1M_DIO3DataSet) base.Clone();
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
            S_PLACA_RAD1M_DIO3DataSet set = new S_PLACA_RAD1M_DIO3DataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_PLACA_RAD1M_DIO3DataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2182");
            this.ExtendedProperties.Add("DataSetName", "S_PLACA_RAD1M_DIO3DataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_PLACA_RAD1M_DIO3DataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_PLACA_RAD1M_DIO3");
            this.ExtendedProperties.Add("ObjectDescription", "S_PLACA_RAD1M_DIO3");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_RAD1M_DIO3");
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
            this.DataSetName = "S_PLACA_RAD1M_DIO3DataSet";
            this.Namespace = "http://www.tempuri.org/S_PLACA_RAD1M_DIO3";
            this.tableS_PLACA_RAD1M_DIO3 = new S_PLACA_RAD1M_DIO3DataTable();
            this.Tables.Add(this.tableS_PLACA_RAD1M_DIO3);
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
            this.tableS_PLACA_RAD1M_DIO3 = (S_PLACA_RAD1M_DIO3DataTable) this.Tables["S_PLACA_RAD1M_DIO3"];
            if (initTable && (this.tableS_PLACA_RAD1M_DIO3 != null))
            {
                this.tableS_PLACA_RAD1M_DIO3.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_PLACA_RAD1M_DIO3"] != null)
                {
                    this.Tables.Add(new S_PLACA_RAD1M_DIO3DataTable(dataSet.Tables["S_PLACA_RAD1M_DIO3"]));
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

        private bool ShouldSerializeS_PLACA_RAD1M_DIO3()
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
        public S_PLACA_RAD1M_DIO3DataTable S_PLACA_RAD1M_DIO3
        {
            get
            {
                return this.tableS_PLACA_RAD1M_DIO3;
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
        public class S_PLACA_RAD1M_DIO3DataTable : DataTable, IEnumerable
        {
            private DataColumn columnBLAGDANINERADNI;
            private DataColumn columnBOLOVANJEDO42DANA;
            private DataColumn columnGODISNJI;
            private DataColumn columnPLACENIANEIZVRSENI;
            private DataColumn columnprekovremeni;

            public event S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3RowChangeEventHandler S_PLACA_RAD1M_DIO3RowChanged;

            public event S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3RowChangeEventHandler S_PLACA_RAD1M_DIO3RowChanging;

            public event S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3RowChangeEventHandler S_PLACA_RAD1M_DIO3RowDeleted;

            public event S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3RowChangeEventHandler S_PLACA_RAD1M_DIO3RowDeleting;

            public S_PLACA_RAD1M_DIO3DataTable()
            {
                this.TableName = "S_PLACA_RAD1M_DIO3";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_PLACA_RAD1M_DIO3DataTable(DataTable table) : base(table.TableName)
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

            protected S_PLACA_RAD1M_DIO3DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_PLACA_RAD1M_DIO3Row(S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row row)
            {
                this.Rows.Add(row);
            }

            public S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row AddS_PLACA_RAD1M_DIO3Row(decimal prekovremeni, decimal bOLOVANJEDO42DANA, decimal gODISNJI, decimal bLAGDANINERADNI, decimal pLACENIANEIZVRSENI)
            {
                S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row row = (S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row) this.NewRow();
                row.ItemArray = new object[] { prekovremeni, bOLOVANJEDO42DANA, gODISNJI, bLAGDANINERADNI, pLACENIANEIZVRSENI };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3DataTable table = (S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_PLACA_RAD1M_DIO3DataSet set = new S_PLACA_RAD1M_DIO3DataSet();
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
                this.columnprekovremeni = new DataColumn("prekovremeni", typeof(decimal), "", MappingType.Element);
                this.columnprekovremeni.Caption = "prekovremeni";
                this.columnprekovremeni.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnprekovremeni.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnprekovremeni.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnprekovremeni.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnprekovremeni.ExtendedProperties.Add("IsKey", "false");
                this.columnprekovremeni.ExtendedProperties.Add("ReadOnly", "true");
                this.columnprekovremeni.ExtendedProperties.Add("DeklaritType", "int");
                this.columnprekovremeni.ExtendedProperties.Add("Description", "prekovremeni");
                this.columnprekovremeni.ExtendedProperties.Add("Length", "12");
                this.columnprekovremeni.ExtendedProperties.Add("Decimals", "2");
                this.columnprekovremeni.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnprekovremeni.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnprekovremeni.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnprekovremeni.ExtendedProperties.Add("IsInReader", "true");
                this.columnprekovremeni.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnprekovremeni.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnprekovremeni.ExtendedProperties.Add("Deklarit.InternalName", "prekovremeni");
                this.Columns.Add(this.columnprekovremeni);
                this.columnBOLOVANJEDO42DANA = new DataColumn("BOLOVANJEDO42DANA", typeof(decimal), "", MappingType.Element);
                this.columnBOLOVANJEDO42DANA.Caption = "BOLOVANJED O42 DANA";
                this.columnBOLOVANJEDO42DANA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("IsKey", "false");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("Description", "BOLOVANJED O42 DANA");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("Length", "12");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("Decimals", "2");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBOLOVANJEDO42DANA.ExtendedProperties.Add("Deklarit.InternalName", "BOLOVANJEDO42DANA");
                this.Columns.Add(this.columnBOLOVANJEDO42DANA);
                this.columnGODISNJI = new DataColumn("GODISNJI", typeof(decimal), "", MappingType.Element);
                this.columnGODISNJI.Caption = "GODISNJI";
                this.columnGODISNJI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODISNJI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODISNJI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODISNJI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnGODISNJI.ExtendedProperties.Add("IsKey", "false");
                this.columnGODISNJI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnGODISNJI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnGODISNJI.ExtendedProperties.Add("Description", "GODISNJI");
                this.columnGODISNJI.ExtendedProperties.Add("Length", "12");
                this.columnGODISNJI.ExtendedProperties.Add("Decimals", "2");
                this.columnGODISNJI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnGODISNJI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnGODISNJI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnGODISNJI.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODISNJI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODISNJI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODISNJI.ExtendedProperties.Add("Deklarit.InternalName", "GODISNJI");
                this.Columns.Add(this.columnGODISNJI);
                this.columnBLAGDANINERADNI = new DataColumn("BLAGDANINERADNI", typeof(decimal), "", MappingType.Element);
                this.columnBLAGDANINERADNI.Caption = "BLAGDANINERADNI";
                this.columnBLAGDANINERADNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("IsKey", "false");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("Description", "BLAGDANINERADNI");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("Length", "12");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("Decimals", "2");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLAGDANINERADNI.ExtendedProperties.Add("Deklarit.InternalName", "BLAGDANINERADNI");
                this.Columns.Add(this.columnBLAGDANINERADNI);
                this.columnPLACENIANEIZVRSENI = new DataColumn("PLACENIANEIZVRSENI", typeof(decimal), "", MappingType.Element);
                this.columnPLACENIANEIZVRSENI.Caption = "PLACENIANEIZVRSENI";
                this.columnPLACENIANEIZVRSENI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("IsKey", "false");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("Description", "PLACENIANEIZVRSENI");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("Length", "12");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("Decimals", "2");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("IsInReader", "true");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLACENIANEIZVRSENI.ExtendedProperties.Add("Deklarit.InternalName", "PLACENIANEIZVRSENI");
                this.Columns.Add(this.columnPLACENIANEIZVRSENI);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_PLACA_RAD1M_DIO3");
                this.ExtendedProperties.Add("Description", "S_PLACA_RAD1M_DIO3");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnprekovremeni = this.Columns["prekovremeni"];
                this.columnBOLOVANJEDO42DANA = this.Columns["BOLOVANJEDO42DANA"];
                this.columnGODISNJI = this.Columns["GODISNJI"];
                this.columnBLAGDANINERADNI = this.Columns["BLAGDANINERADNI"];
                this.columnPLACENIANEIZVRSENI = this.Columns["PLACENIANEIZVRSENI"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row(builder);
            }

            public S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row NewS_PLACA_RAD1M_DIO3Row()
            {
                return (S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_PLACA_RAD1M_DIO3RowChanged != null)
                {
                    S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3RowChangeEventHandler handler = this.S_PLACA_RAD1M_DIO3RowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3RowChangeEvent((S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_PLACA_RAD1M_DIO3RowChanging != null)
                {
                    S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3RowChangeEventHandler handler = this.S_PLACA_RAD1M_DIO3RowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3RowChangeEvent((S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_PLACA_RAD1M_DIO3RowDeleted != null)
                {
                    S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3RowChangeEventHandler handler = this.S_PLACA_RAD1M_DIO3RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3RowChangeEvent((S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_PLACA_RAD1M_DIO3RowDeleting != null)
                {
                    S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3RowChangeEventHandler handler = this.S_PLACA_RAD1M_DIO3RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3RowChangeEvent((S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_PLACA_RAD1M_DIO3Row(S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BLAGDANINERADNIColumn
            {
                get
                {
                    return this.columnBLAGDANINERADNI;
                }
            }

            public DataColumn BOLOVANJEDO42DANAColumn
            {
                get
                {
                    return this.columnBOLOVANJEDO42DANA;
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

            public DataColumn GODISNJIColumn
            {
                get
                {
                    return this.columnGODISNJI;
                }
            }

            public S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row this[int index]
            {
                get
                {
                    return (S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row) this.Rows[index];
                }
            }

            public DataColumn PLACENIANEIZVRSENIColumn
            {
                get
                {
                    return this.columnPLACENIANEIZVRSENI;
                }
            }

            public DataColumn prekovremeniColumn
            {
                get
                {
                    return this.columnprekovremeni;
                }
            }
        }

        public class S_PLACA_RAD1M_DIO3Row : DataRow
        {
            private S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3DataTable tableS_PLACA_RAD1M_DIO3;

            internal S_PLACA_RAD1M_DIO3Row(DataRowBuilder rb) : base(rb)
            {
                this.tableS_PLACA_RAD1M_DIO3 = (S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3DataTable) this.Table;
            }

            public bool IsBLAGDANINERADNINull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO3.BLAGDANINERADNIColumn);
            }

            public bool IsBOLOVANJEDO42DANANull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO3.BOLOVANJEDO42DANAColumn);
            }

            public bool IsGODISNJINull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO3.GODISNJIColumn);
            }

            public bool IsPLACENIANEIZVRSENINull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO3.PLACENIANEIZVRSENIColumn);
            }

            public bool IsprekovremeniNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1M_DIO3.prekovremeniColumn);
            }

            public void SetBLAGDANINERADNINull()
            {
                this[this.tableS_PLACA_RAD1M_DIO3.BLAGDANINERADNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBOLOVANJEDO42DANANull()
            {
                this[this.tableS_PLACA_RAD1M_DIO3.BOLOVANJEDO42DANAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGODISNJINull()
            {
                this[this.tableS_PLACA_RAD1M_DIO3.GODISNJIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPLACENIANEIZVRSENINull()
            {
                this[this.tableS_PLACA_RAD1M_DIO3.PLACENIANEIZVRSENIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetprekovremeniNull()
            {
                this[this.tableS_PLACA_RAD1M_DIO3.prekovremeniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal BLAGDANINERADNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1M_DIO3.BLAGDANINERADNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BLAGDANINERADNI because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO3.BLAGDANINERADNIColumn] = value;
                }
            }

            public decimal BOLOVANJEDO42DANA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1M_DIO3.BOLOVANJEDO42DANAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BOLOVANJEDO42DANA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO3.BOLOVANJEDO42DANAColumn] = value;
                }
            }

            public decimal GODISNJI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1M_DIO3.GODISNJIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value GODISNJI because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO3.GODISNJIColumn] = value;
                }
            }

            public decimal PLACENIANEIZVRSENI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1M_DIO3.PLACENIANEIZVRSENIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PLACENIANEIZVRSENI because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO3.PLACENIANEIZVRSENIColumn] = value;
                }
            }

            public decimal prekovremeni
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1M_DIO3.prekovremeniColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value prekovremeni because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1M_DIO3.prekovremeniColumn] = value;
                }
            }
        }

        public class S_PLACA_RAD1M_DIO3RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row eventRow;

            public S_PLACA_RAD1M_DIO3RowChangeEvent(S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row row, DataRowAction action)
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

            public S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_PLACA_RAD1M_DIO3RowChangeEventHandler(object sender, S_PLACA_RAD1M_DIO3DataSet.S_PLACA_RAD1M_DIO3RowChangeEvent e);
    }
}

