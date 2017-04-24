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
    public class S_PLACA_RAD1G_SATIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_PLACA_RAD1G_SATIDataTable tableS_PLACA_RAD1G_SATI;

        public S_PLACA_RAD1G_SATIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_PLACA_RAD1G_SATIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_PLACA_RAD1G_SATI"] != null)
                    {
                        this.Tables.Add(new S_PLACA_RAD1G_SATIDataTable(dataSet.Tables["S_PLACA_RAD1G_SATI"]));
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
            S_PLACA_RAD1G_SATIDataSet set = (S_PLACA_RAD1G_SATIDataSet) base.Clone();
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
            S_PLACA_RAD1G_SATIDataSet set = new S_PLACA_RAD1G_SATIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_PLACA_RAD1G_SATIDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2187");
            this.ExtendedProperties.Add("DataSetName", "S_PLACA_RAD1G_SATIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_PLACA_RAD1G_SATIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_PLACA_RAD1G_SATI");
            this.ExtendedProperties.Add("ObjectDescription", "S_PLACA_RAD1G_SATI");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_RAD1G_SATI");
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
            this.DataSetName = "S_PLACA_RAD1G_SATIDataSet";
            this.Namespace = "http://www.tempuri.org/S_PLACA_RAD1G_SATI";
            this.tableS_PLACA_RAD1G_SATI = new S_PLACA_RAD1G_SATIDataTable();
            this.Tables.Add(this.tableS_PLACA_RAD1G_SATI);
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
            this.tableS_PLACA_RAD1G_SATI = (S_PLACA_RAD1G_SATIDataTable) this.Tables["S_PLACA_RAD1G_SATI"];
            if (initTable && (this.tableS_PLACA_RAD1G_SATI != null))
            {
                this.tableS_PLACA_RAD1G_SATI.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_PLACA_RAD1G_SATI"] != null)
                {
                    this.Tables.Add(new S_PLACA_RAD1G_SATIDataTable(dataSet.Tables["S_PLACA_RAD1G_SATI"]));
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

        private bool ShouldSerializeS_PLACA_RAD1G_SATI()
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
        public S_PLACA_RAD1G_SATIDataTable S_PLACA_RAD1G_SATI
        {
            get
            {
                return this.tableS_PLACA_RAD1G_SATI;
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
        public class S_PLACA_RAD1G_SATIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIZV;
            private DataColumn columnNEIZV;
            private DataColumn columnNEIZVIZVAN;
            private DataColumn columnNEPLACENI;
            private DataColumn columnprekovremeni;
            private DataColumn columnSTRAJK;

            public event S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRowChangeEventHandler S_PLACA_RAD1G_SATIRowChanged;

            public event S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRowChangeEventHandler S_PLACA_RAD1G_SATIRowChanging;

            public event S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRowChangeEventHandler S_PLACA_RAD1G_SATIRowDeleted;

            public event S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRowChangeEventHandler S_PLACA_RAD1G_SATIRowDeleting;

            public S_PLACA_RAD1G_SATIDataTable()
            {
                this.TableName = "S_PLACA_RAD1G_SATI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_PLACA_RAD1G_SATIDataTable(DataTable table) : base(table.TableName)
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

            protected S_PLACA_RAD1G_SATIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_PLACA_RAD1G_SATIRow(S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow row)
            {
                this.Rows.Add(row);
            }

            public S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow AddS_PLACA_RAD1G_SATIRow(decimal iZV, decimal nEIZV, decimal nEIZVIZVAN, decimal nEPLACENI, decimal prekovremeni, decimal sTRAJK)
            {
                S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow row = (S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow) this.NewRow();
                row.ItemArray = new object[] { iZV, nEIZV, nEIZVIZVAN, nEPLACENI, prekovremeni, sTRAJK };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIDataTable table = (S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_PLACA_RAD1G_SATIDataSet set = new S_PLACA_RAD1G_SATIDataSet();
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
                this.columnIZV = new DataColumn("IZV", typeof(decimal), "", MappingType.Element);
                this.columnIZV.Caption = "IZV";
                this.columnIZV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZV.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZV.ExtendedProperties.Add("IsKey", "false");
                this.columnIZV.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZV.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZV.ExtendedProperties.Add("Description", "IZV");
                this.columnIZV.ExtendedProperties.Add("Length", "12");
                this.columnIZV.ExtendedProperties.Add("Decimals", "2");
                this.columnIZV.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZV.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZV.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZV.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZV.ExtendedProperties.Add("Deklarit.InternalName", "IZV");
                this.Columns.Add(this.columnIZV);
                this.columnNEIZV = new DataColumn("NEIZV", typeof(decimal), "", MappingType.Element);
                this.columnNEIZV.Caption = "NEIZV";
                this.columnNEIZV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNEIZV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNEIZV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNEIZV.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNEIZV.ExtendedProperties.Add("IsKey", "false");
                this.columnNEIZV.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNEIZV.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNEIZV.ExtendedProperties.Add("Description", "NEIZV");
                this.columnNEIZV.ExtendedProperties.Add("Length", "12");
                this.columnNEIZV.ExtendedProperties.Add("Decimals", "2");
                this.columnNEIZV.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNEIZV.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNEIZV.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNEIZV.ExtendedProperties.Add("IsInReader", "true");
                this.columnNEIZV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNEIZV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNEIZV.ExtendedProperties.Add("Deklarit.InternalName", "NEIZV");
                this.Columns.Add(this.columnNEIZV);
                this.columnNEIZVIZVAN = new DataColumn("NEIZVIZVAN", typeof(decimal), "", MappingType.Element);
                this.columnNEIZVIZVAN.Caption = "NEIZVIZVAN";
                this.columnNEIZVIZVAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNEIZVIZVAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("IsKey", "false");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("Description", "NEIZVIZVAN");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("Length", "12");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("Decimals", "2");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNEIZVIZVAN.ExtendedProperties.Add("Deklarit.InternalName", "NEIZVIZVAN");
                this.Columns.Add(this.columnNEIZVIZVAN);
                this.columnNEPLACENI = new DataColumn("NEPLACENI", typeof(decimal), "", MappingType.Element);
                this.columnNEPLACENI.Caption = "NEPLACENI";
                this.columnNEPLACENI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNEPLACENI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNEPLACENI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNEPLACENI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNEPLACENI.ExtendedProperties.Add("IsKey", "false");
                this.columnNEPLACENI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNEPLACENI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNEPLACENI.ExtendedProperties.Add("Description", "NEPLACENI");
                this.columnNEPLACENI.ExtendedProperties.Add("Length", "12");
                this.columnNEPLACENI.ExtendedProperties.Add("Decimals", "2");
                this.columnNEPLACENI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNEPLACENI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNEPLACENI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNEPLACENI.ExtendedProperties.Add("IsInReader", "true");
                this.columnNEPLACENI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNEPLACENI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNEPLACENI.ExtendedProperties.Add("Deklarit.InternalName", "NEPLACENI");
                this.Columns.Add(this.columnNEPLACENI);
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
                this.columnSTRAJK = new DataColumn("STRAJK", typeof(decimal), "", MappingType.Element);
                this.columnSTRAJK.Caption = "STRAJK";
                this.columnSTRAJK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTRAJK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTRAJK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTRAJK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTRAJK.ExtendedProperties.Add("IsKey", "false");
                this.columnSTRAJK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTRAJK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTRAJK.ExtendedProperties.Add("Description", "STRAJK");
                this.columnSTRAJK.ExtendedProperties.Add("Length", "12");
                this.columnSTRAJK.ExtendedProperties.Add("Decimals", "2");
                this.columnSTRAJK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTRAJK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSTRAJK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTRAJK.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTRAJK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTRAJK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTRAJK.ExtendedProperties.Add("Deklarit.InternalName", "STRAJK");
                this.Columns.Add(this.columnSTRAJK);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_PLACA_RAD1G_SATI");
                this.ExtendedProperties.Add("Description", "_S_PLACA_RAD1G_SATI");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIZV = this.Columns["IZV"];
                this.columnNEIZV = this.Columns["NEIZV"];
                this.columnNEIZVIZVAN = this.Columns["NEIZVIZVAN"];
                this.columnNEPLACENI = this.Columns["NEPLACENI"];
                this.columnprekovremeni = this.Columns["prekovremeni"];
                this.columnSTRAJK = this.Columns["STRAJK"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow(builder);
            }

            public S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow NewS_PLACA_RAD1G_SATIRow()
            {
                return (S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_PLACA_RAD1G_SATIRowChanged != null)
                {
                    S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRowChangeEventHandler handler = this.S_PLACA_RAD1G_SATIRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRowChangeEvent((S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_PLACA_RAD1G_SATIRowChanging != null)
                {
                    S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRowChangeEventHandler handler = this.S_PLACA_RAD1G_SATIRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRowChangeEvent((S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_PLACA_RAD1G_SATIRowDeleted != null)
                {
                    S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRowChangeEventHandler handler = this.S_PLACA_RAD1G_SATIRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRowChangeEvent((S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_PLACA_RAD1G_SATIRowDeleting != null)
                {
                    S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRowChangeEventHandler handler = this.S_PLACA_RAD1G_SATIRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRowChangeEvent((S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_PLACA_RAD1G_SATIRow(S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow row)
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

            public S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow this[int index]
            {
                get
                {
                    return (S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow) this.Rows[index];
                }
            }

            public DataColumn IZVColumn
            {
                get
                {
                    return this.columnIZV;
                }
            }

            public DataColumn NEIZVColumn
            {
                get
                {
                    return this.columnNEIZV;
                }
            }

            public DataColumn NEIZVIZVANColumn
            {
                get
                {
                    return this.columnNEIZVIZVAN;
                }
            }

            public DataColumn NEPLACENIColumn
            {
                get
                {
                    return this.columnNEPLACENI;
                }
            }

            public DataColumn prekovremeniColumn
            {
                get
                {
                    return this.columnprekovremeni;
                }
            }

            public DataColumn STRAJKColumn
            {
                get
                {
                    return this.columnSTRAJK;
                }
            }
        }

        public class S_PLACA_RAD1G_SATIRow : DataRow
        {
            private S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIDataTable tableS_PLACA_RAD1G_SATI;

            internal S_PLACA_RAD1G_SATIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_PLACA_RAD1G_SATI = (S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIDataTable) this.Table;
            }

            public bool IsIZVNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G_SATI.IZVColumn);
            }

            public bool IsNEIZVIZVANNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G_SATI.NEIZVIZVANColumn);
            }

            public bool IsNEIZVNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G_SATI.NEIZVColumn);
            }

            public bool IsNEPLACENINull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G_SATI.NEPLACENIColumn);
            }

            public bool IsprekovremeniNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G_SATI.prekovremeniColumn);
            }

            public bool IsSTRAJKNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G_SATI.STRAJKColumn);
            }

            public void SetIZVNull()
            {
                this[this.tableS_PLACA_RAD1G_SATI.IZVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNEIZVIZVANNull()
            {
                this[this.tableS_PLACA_RAD1G_SATI.NEIZVIZVANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNEIZVNull()
            {
                this[this.tableS_PLACA_RAD1G_SATI.NEIZVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNEPLACENINull()
            {
                this[this.tableS_PLACA_RAD1G_SATI.NEPLACENIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetprekovremeniNull()
            {
                this[this.tableS_PLACA_RAD1G_SATI.prekovremeniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTRAJKNull()
            {
                this[this.tableS_PLACA_RAD1G_SATI.STRAJKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal IZV
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1G_SATI.IZVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IZV because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G_SATI.IZVColumn] = value;
                }
            }

            public decimal NEIZV
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1G_SATI.NEIZVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NEIZV because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G_SATI.NEIZVColumn] = value;
                }
            }

            public decimal NEIZVIZVAN
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1G_SATI.NEIZVIZVANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NEIZVIZVAN because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G_SATI.NEIZVIZVANColumn] = value;
                }
            }

            public decimal NEPLACENI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1G_SATI.NEPLACENIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NEPLACENI because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G_SATI.NEPLACENIColumn] = value;
                }
            }

            public decimal prekovremeni
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1G_SATI.prekovremeniColumn]);
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
                    this[this.tableS_PLACA_RAD1G_SATI.prekovremeniColumn] = value;
                }
            }

            public decimal STRAJK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1G_SATI.STRAJKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value STRAJK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G_SATI.STRAJKColumn] = value;
                }
            }
        }

        public class S_PLACA_RAD1G_SATIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow eventRow;

            public S_PLACA_RAD1G_SATIRowChangeEvent(S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow row, DataRowAction action)
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

            public S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_PLACA_RAD1G_SATIRowChangeEventHandler(object sender, S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRowChangeEvent e);
    }
}

