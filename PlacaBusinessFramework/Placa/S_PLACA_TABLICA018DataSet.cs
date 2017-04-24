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
    public class S_PLACA_TABLICA018DataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_PLACA_TABLICA018DataTable tableS_PLACA_TABLICA018;

        public S_PLACA_TABLICA018DataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_PLACA_TABLICA018DataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_PLACA_TABLICA018"] != null)
                    {
                        this.Tables.Add(new S_PLACA_TABLICA018DataTable(dataSet.Tables["S_PLACA_TABLICA018"]));
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
            S_PLACA_TABLICA018DataSet set = (S_PLACA_TABLICA018DataSet) base.Clone();
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
            S_PLACA_TABLICA018DataSet set = new S_PLACA_TABLICA018DataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_PLACA_TABLICA018DataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2202");
            this.ExtendedProperties.Add("DataSetName", "S_PLACA_TABLICA018DataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_PLACA_TABLICA018DataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_PLACA_TABLICA018");
            this.ExtendedProperties.Add("ObjectDescription", "S_PLACA_TABLICA018");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_TABLICA018");
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
            this.DataSetName = "S_PLACA_TABLICA018DataSet";
            this.Namespace = "http://www.tempuri.org/S_PLACA_TABLICA018";
            this.tableS_PLACA_TABLICA018 = new S_PLACA_TABLICA018DataTable();
            this.Tables.Add(this.tableS_PLACA_TABLICA018);
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
            this.tableS_PLACA_TABLICA018 = (S_PLACA_TABLICA018DataTable) this.Tables["S_PLACA_TABLICA018"];
            if (initTable && (this.tableS_PLACA_TABLICA018 != null))
            {
                this.tableS_PLACA_TABLICA018.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_PLACA_TABLICA018"] != null)
                {
                    this.Tables.Add(new S_PLACA_TABLICA018DataTable(dataSet.Tables["S_PLACA_TABLICA018"]));
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

        private bool ShouldSerializeS_PLACA_TABLICA018()
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
        public S_PLACA_TABLICA018DataTable S_PLACA_TABLICA018
        {
            get
            {
                return this.tableS_PLACA_TABLICA018;
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
        public class S_PLACA_TABLICA018DataTable : DataTable, IEnumerable
        {
            private DataColumn columnDATUMISPLATE;
            private DataColumn columnGODINAOBRACUNA;
            private DataColumn columnMJESECOBRACUNA;
            private DataColumn columnSAMOPRVISTUPOBRACUNATI;
            private DataColumn columnSAMOPRVISTUPOSNOVICA;
            private DataColumn columnSTUPOBRACUNATI;
            private DataColumn columnSTUPOSNOVICA;

            public event S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018RowChangeEventHandler S_PLACA_TABLICA018RowChanged;

            public event S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018RowChangeEventHandler S_PLACA_TABLICA018RowChanging;

            public event S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018RowChangeEventHandler S_PLACA_TABLICA018RowDeleted;

            public event S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018RowChangeEventHandler S_PLACA_TABLICA018RowDeleting;

            public S_PLACA_TABLICA018DataTable()
            {
                this.TableName = "S_PLACA_TABLICA018";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_PLACA_TABLICA018DataTable(DataTable table) : base(table.TableName)
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

            protected S_PLACA_TABLICA018DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_PLACA_TABLICA018Row(S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row row)
            {
                this.Rows.Add(row);
            }

            public S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row AddS_PLACA_TABLICA018Row(DateTime dATUMISPLATE, string gODINAOBRACUNA, string mJESECOBRACUNA, decimal sAMOPRVISTUPOSNOVICA, decimal sAMOPRVISTUPOBRACUNATI, decimal sTUPOSNOVICA, decimal sTUPOBRACUNATI)
            {
                S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row row = (S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row) this.NewRow();
                row.ItemArray = new object[] { dATUMISPLATE, gODINAOBRACUNA, mJESECOBRACUNA, sAMOPRVISTUPOSNOVICA, sAMOPRVISTUPOBRACUNATI, sTUPOSNOVICA, sTUPOBRACUNATI };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018DataTable table = (S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_PLACA_TABLICA018DataSet set = new S_PLACA_TABLICA018DataSet();
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
                this.columnDATUMISPLATE = new DataColumn("DATUMISPLATE", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMISPLATE.Caption = "Datum isplate";
                this.columnDATUMISPLATE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDATUMISPLATE.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMISPLATE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Description", "Datum isplate");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Length", "8");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMISPLATE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.InternalName", "DATUMISPLATE");
                this.Columns.Add(this.columnDATUMISPLATE);
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
                this.columnSAMOPRVISTUPOSNOVICA = new DataColumn("SAMOPRVISTUPOSNOVICA", typeof(decimal), "", MappingType.Element);
                this.columnSAMOPRVISTUPOSNOVICA.Caption = "SAMOPRVISTUPOSNOVICA";
                this.columnSAMOPRVISTUPOSNOVICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("IsKey", "false");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("Description", "SAMOPRVISTUPOSNOVICA");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("Length", "12");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("Decimals", "2");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSAMOPRVISTUPOSNOVICA.ExtendedProperties.Add("Deklarit.InternalName", "SAMOPRVISTUPOSNOVICA");
                this.Columns.Add(this.columnSAMOPRVISTUPOSNOVICA);
                this.columnSAMOPRVISTUPOBRACUNATI = new DataColumn("SAMOPRVISTUPOBRACUNATI", typeof(decimal), "", MappingType.Element);
                this.columnSAMOPRVISTUPOBRACUNATI.Caption = "SAMOPRVISTUPOBRACUNATI";
                this.columnSAMOPRVISTUPOBRACUNATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("IsKey", "false");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("Description", "SAMOPRVISTUPOBRACUNATI");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("Length", "12");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("Decimals", "2");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("IsInReader", "true");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSAMOPRVISTUPOBRACUNATI.ExtendedProperties.Add("Deklarit.InternalName", "SAMOPRVISTUPOBRACUNATI");
                this.Columns.Add(this.columnSAMOPRVISTUPOBRACUNATI);
                this.columnSTUPOSNOVICA = new DataColumn("STUPOSNOVICA", typeof(decimal), "", MappingType.Element);
                this.columnSTUPOSNOVICA.Caption = "STUPOSNOVICA";
                this.columnSTUPOSNOVICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("IsKey", "false");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("Description", "STUPOSNOVICA");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("Length", "12");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("Decimals", "2");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTUPOSNOVICA.ExtendedProperties.Add("Deklarit.InternalName", "STUPOSNOVICA");
                this.Columns.Add(this.columnSTUPOSNOVICA);
                this.columnSTUPOBRACUNATI = new DataColumn("STUPOBRACUNATI", typeof(decimal), "", MappingType.Element);
                this.columnSTUPOBRACUNATI.Caption = "STUPOBRACUNATI";
                this.columnSTUPOBRACUNATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("IsKey", "false");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("Description", "STUPOBRACUNATI");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("Length", "12");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("Decimals", "2");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTUPOBRACUNATI.ExtendedProperties.Add("Deklarit.InternalName", "STUPOBRACUNATI");
                this.Columns.Add(this.columnSTUPOBRACUNATI);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_PLACA_TABLICA018");
                this.ExtendedProperties.Add("Description", "S_PLACA_TABLICA018");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnDATUMISPLATE = this.Columns["DATUMISPLATE"];
                this.columnGODINAOBRACUNA = this.Columns["GODINAOBRACUNA"];
                this.columnMJESECOBRACUNA = this.Columns["MJESECOBRACUNA"];
                this.columnSAMOPRVISTUPOSNOVICA = this.Columns["SAMOPRVISTUPOSNOVICA"];
                this.columnSAMOPRVISTUPOBRACUNATI = this.Columns["SAMOPRVISTUPOBRACUNATI"];
                this.columnSTUPOSNOVICA = this.Columns["STUPOSNOVICA"];
                this.columnSTUPOBRACUNATI = this.Columns["STUPOBRACUNATI"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row(builder);
            }

            public S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row NewS_PLACA_TABLICA018Row()
            {
                return (S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_PLACA_TABLICA018RowChanged != null)
                {
                    S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018RowChangeEventHandler handler = this.S_PLACA_TABLICA018RowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018RowChangeEvent((S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_PLACA_TABLICA018RowChanging != null)
                {
                    S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018RowChangeEventHandler handler = this.S_PLACA_TABLICA018RowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018RowChangeEvent((S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_PLACA_TABLICA018RowDeleted != null)
                {
                    S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018RowChangeEventHandler handler = this.S_PLACA_TABLICA018RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018RowChangeEvent((S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_PLACA_TABLICA018RowDeleting != null)
                {
                    S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018RowChangeEventHandler handler = this.S_PLACA_TABLICA018RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018RowChangeEvent((S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_PLACA_TABLICA018Row(S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row row)
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

            public DataColumn DATUMISPLATEColumn
            {
                get
                {
                    return this.columnDATUMISPLATE;
                }
            }

            public DataColumn GODINAOBRACUNAColumn
            {
                get
                {
                    return this.columnGODINAOBRACUNA;
                }
            }

            public S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row this[int index]
            {
                get
                {
                    return (S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row) this.Rows[index];
                }
            }

            public DataColumn MJESECOBRACUNAColumn
            {
                get
                {
                    return this.columnMJESECOBRACUNA;
                }
            }

            public DataColumn SAMOPRVISTUPOBRACUNATIColumn
            {
                get
                {
                    return this.columnSAMOPRVISTUPOBRACUNATI;
                }
            }

            public DataColumn SAMOPRVISTUPOSNOVICAColumn
            {
                get
                {
                    return this.columnSAMOPRVISTUPOSNOVICA;
                }
            }

            public DataColumn STUPOBRACUNATIColumn
            {
                get
                {
                    return this.columnSTUPOBRACUNATI;
                }
            }

            public DataColumn STUPOSNOVICAColumn
            {
                get
                {
                    return this.columnSTUPOSNOVICA;
                }
            }
        }

        public class S_PLACA_TABLICA018Row : DataRow
        {
            private S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018DataTable tableS_PLACA_TABLICA018;

            internal S_PLACA_TABLICA018Row(DataRowBuilder rb) : base(rb)
            {
                this.tableS_PLACA_TABLICA018 = (S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018DataTable) this.Table;
            }

            public bool IsDATUMISPLATENull()
            {
                return this.IsNull(this.tableS_PLACA_TABLICA018.DATUMISPLATEColumn);
            }

            public bool IsGODINAOBRACUNANull()
            {
                return this.IsNull(this.tableS_PLACA_TABLICA018.GODINAOBRACUNAColumn);
            }

            public bool IsMJESECOBRACUNANull()
            {
                return this.IsNull(this.tableS_PLACA_TABLICA018.MJESECOBRACUNAColumn);
            }

            public bool IsSAMOPRVISTUPOBRACUNATINull()
            {
                return this.IsNull(this.tableS_PLACA_TABLICA018.SAMOPRVISTUPOBRACUNATIColumn);
            }

            public bool IsSAMOPRVISTUPOSNOVICANull()
            {
                return this.IsNull(this.tableS_PLACA_TABLICA018.SAMOPRVISTUPOSNOVICAColumn);
            }

            public bool IsSTUPOBRACUNATINull()
            {
                return this.IsNull(this.tableS_PLACA_TABLICA018.STUPOBRACUNATIColumn);
            }

            public bool IsSTUPOSNOVICANull()
            {
                return this.IsNull(this.tableS_PLACA_TABLICA018.STUPOSNOVICAColumn);
            }

            public void SetDATUMISPLATENull()
            {
                this[this.tableS_PLACA_TABLICA018.DATUMISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGODINAOBRACUNANull()
            {
                this[this.tableS_PLACA_TABLICA018.GODINAOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECOBRACUNANull()
            {
                this[this.tableS_PLACA_TABLICA018.MJESECOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSAMOPRVISTUPOBRACUNATINull()
            {
                this[this.tableS_PLACA_TABLICA018.SAMOPRVISTUPOBRACUNATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSAMOPRVISTUPOSNOVICANull()
            {
                this[this.tableS_PLACA_TABLICA018.SAMOPRVISTUPOSNOVICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTUPOBRACUNATINull()
            {
                this[this.tableS_PLACA_TABLICA018.STUPOBRACUNATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTUPOSNOVICANull()
            {
                this[this.tableS_PLACA_TABLICA018.STUPOSNOVICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public DateTime DATUMISPLATE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_PLACA_TABLICA018.DATUMISPLATEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DATUMISPLATE because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_PLACA_TABLICA018.DATUMISPLATEColumn] = value;
                }
            }

            public string GODINAOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_TABLICA018.GODINAOBRACUNAColumn]);
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
                    this[this.tableS_PLACA_TABLICA018.GODINAOBRACUNAColumn] = value;
                }
            }

            public string MJESECOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_TABLICA018.MJESECOBRACUNAColumn]);
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
                    this[this.tableS_PLACA_TABLICA018.MJESECOBRACUNAColumn] = value;
                }
            }

            public decimal SAMOPRVISTUPOBRACUNATI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_TABLICA018.SAMOPRVISTUPOBRACUNATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SAMOPRVISTUPOBRACUNATI because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_TABLICA018.SAMOPRVISTUPOBRACUNATIColumn] = value;
                }
            }

            public decimal SAMOPRVISTUPOSNOVICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_TABLICA018.SAMOPRVISTUPOSNOVICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SAMOPRVISTUPOSNOVICA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_TABLICA018.SAMOPRVISTUPOSNOVICAColumn] = value;
                }
            }

            public decimal STUPOBRACUNATI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_TABLICA018.STUPOBRACUNATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value STUPOBRACUNATI because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_TABLICA018.STUPOBRACUNATIColumn] = value;
                }
            }

            public decimal STUPOSNOVICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_TABLICA018.STUPOSNOVICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value STUPOSNOVICA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_TABLICA018.STUPOSNOVICAColumn] = value;
                }
            }
        }

        public class S_PLACA_TABLICA018RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row eventRow;

            public S_PLACA_TABLICA018RowChangeEvent(S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row row, DataRowAction action)
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

            public S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_PLACA_TABLICA018RowChangeEventHandler(object sender, S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018RowChangeEvent e);
    }
}

