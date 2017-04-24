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
    public class S_FIN_BLAGAJNA_U_GKDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_FIN_BLAGAJNA_U_GKDataTable tableS_FIN_BLAGAJNA_U_GK;

        public S_FIN_BLAGAJNA_U_GKDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_FIN_BLAGAJNA_U_GKDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_FIN_BLAGAJNA_U_GK"] != null)
                    {
                        this.Tables.Add(new S_FIN_BLAGAJNA_U_GKDataTable(dataSet.Tables["S_FIN_BLAGAJNA_U_GK"]));
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
            S_FIN_BLAGAJNA_U_GKDataSet set = (S_FIN_BLAGAJNA_U_GKDataSet) base.Clone();
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
            S_FIN_BLAGAJNA_U_GKDataSet set = new S_FIN_BLAGAJNA_U_GKDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_FIN_BLAGAJNA_U_GKDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2115");
            this.ExtendedProperties.Add("DataSetName", "S_FIN_BLAGAJNA_U_GKDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_FIN_BLAGAJNA_U_GKDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_FIN_BLAGAJNA_U_GK");
            this.ExtendedProperties.Add("ObjectDescription", "S_FIN_BLAGAJNA_U_GK");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_FIN_BLAGAJNA_U_GK");
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
            this.DataSetName = "S_FIN_BLAGAJNA_U_GKDataSet";
            this.Namespace = "http://www.tempuri.org/S_FIN_BLAGAJNA_U_GK";
            this.tableS_FIN_BLAGAJNA_U_GK = new S_FIN_BLAGAJNA_U_GKDataTable();
            this.Tables.Add(this.tableS_FIN_BLAGAJNA_U_GK);
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
            this.tableS_FIN_BLAGAJNA_U_GK = (S_FIN_BLAGAJNA_U_GKDataTable) this.Tables["S_FIN_BLAGAJNA_U_GK"];
            if (initTable && (this.tableS_FIN_BLAGAJNA_U_GK != null))
            {
                this.tableS_FIN_BLAGAJNA_U_GK.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_FIN_BLAGAJNA_U_GK"] != null)
                {
                    this.Tables.Add(new S_FIN_BLAGAJNA_U_GKDataTable(dataSet.Tables["S_FIN_BLAGAJNA_U_GK"]));
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

        private bool ShouldSerializeS_FIN_BLAGAJNA_U_GK()
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
        public S_FIN_BLAGAJNA_U_GKDataTable S_FIN_BLAGAJNA_U_GK
        {
            get
            {
                return this.tableS_FIN_BLAGAJNA_U_GK;
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
        public class S_FIN_BLAGAJNA_U_GKDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBLGDATUMDOKUMENTA;
            private DataColumn columnBLGMTIDMJESTOTROSKA;
            private DataColumn columnBLGORGJEDIDORGJED;
            private DataColumn columnBLGSTAVKEBLAGAJNEKONTOIDKONTO;
            private DataColumn columnIDBLGVRSTEDOK;
            private DataColumn columnIZDATAK;
            private DataColumn columnNAZIVVRSTEDOK;
            private DataColumn columnOPIS;
            private DataColumn columnPRIMITAK;

            public event S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRowChangeEventHandler S_FIN_BLAGAJNA_U_GKRowChanged;

            public event S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRowChangeEventHandler S_FIN_BLAGAJNA_U_GKRowChanging;

            public event S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRowChangeEventHandler S_FIN_BLAGAJNA_U_GKRowDeleted;

            public event S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRowChangeEventHandler S_FIN_BLAGAJNA_U_GKRowDeleting;

            public S_FIN_BLAGAJNA_U_GKDataTable()
            {
                this.TableName = "S_FIN_BLAGAJNA_U_GK";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_FIN_BLAGAJNA_U_GKDataTable(DataTable table) : base(table.TableName)
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

            protected S_FIN_BLAGAJNA_U_GKDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_FIN_BLAGAJNA_U_GKRow(S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow row)
            {
                this.Rows.Add(row);
            }

            public S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow AddS_FIN_BLAGAJNA_U_GKRow(string nAZIVVRSTEDOK, DateTime bLGDATUMDOKUMENTA, int iDBLGVRSTEDOK, string oPIS, string bLGSTAVKEBLAGAJNEKONTOIDKONTO, int bLGMTIDMJESTOTROSKA, int bLGORGJEDIDORGJED, decimal iZDATAK, decimal pRIMITAK)
            {
                S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow row = (S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow) this.NewRow();
                row.ItemArray = new object[] { nAZIVVRSTEDOK, bLGDATUMDOKUMENTA, iDBLGVRSTEDOK, oPIS, bLGSTAVKEBLAGAJNEKONTOIDKONTO, bLGMTIDMJESTOTROSKA, bLGORGJEDIDORGJED, iZDATAK, pRIMITAK };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKDataTable table = (S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_FIN_BLAGAJNA_U_GKDataSet set = new S_FIN_BLAGAJNA_U_GKDataSet();
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
                this.columnNAZIVVRSTEDOK = new DataColumn("NAZIVVRSTEDOK", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTEDOK.Caption = "NAZIVVRSTEDOK";
                this.columnNAZIVVRSTEDOK.MaxLength = 30;
                this.columnNAZIVVRSTEDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Description", "NAZIVVRSTEDOK");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Length", "30");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTEDOK");
                this.Columns.Add(this.columnNAZIVVRSTEDOK);
                this.columnBLGDATUMDOKUMENTA = new DataColumn("BLGDATUMDOKUMENTA", typeof(DateTime), "", MappingType.Element);
                this.columnBLGDATUMDOKUMENTA.Caption = "BLGDATUMDOKUMENTA";
                this.columnBLGDATUMDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Description", "BLGDATUMDOKUMENTA");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Length", "8");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGDATUMDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "BLGDATUMDOKUMENTA");
                this.Columns.Add(this.columnBLGDATUMDOKUMENTA);
                this.columnIDBLGVRSTEDOK = new DataColumn("IDBLGVRSTEDOK", typeof(int), "", MappingType.Element);
                this.columnIDBLGVRSTEDOK.Caption = "IDBLGVRSTEDOK";
                this.columnIDBLGVRSTEDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("IsKey", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Description", "IDBLGVRSTEDOK");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Length", "5");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.InternalName", "IDBLGVRSTEDOK");
                this.Columns.Add(this.columnIDBLGVRSTEDOK);
                this.columnOPIS = new DataColumn("OPIS", typeof(string), "", MappingType.Element);
                this.columnOPIS.Caption = "OPIS";
                this.columnOPIS.MaxLength = 150;
                this.columnOPIS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPIS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOPIS.ExtendedProperties.Add("IsKey", "false");
                this.columnOPIS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPIS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPIS.ExtendedProperties.Add("Description", "OPIS");
                this.columnOPIS.ExtendedProperties.Add("Length", "150");
                this.columnOPIS.ExtendedProperties.Add("Decimals", "0");
                this.columnOPIS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPIS.ExtendedProperties.Add("RightTrim", "true");
                this.columnOPIS.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPIS.ExtendedProperties.Add("Deklarit.InternalName", "OPIS");
                this.Columns.Add(this.columnOPIS);
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO = new DataColumn("BLGSTAVKEBLAGAJNEKONTOIDKONTO", typeof(string), "", MappingType.Element);
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.Caption = "Konto";
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.MaxLength = 14;
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("SubtypeGroup", "BLGSTAVKEBLAGAJNEKONTO");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "BLGSTAVKEBLAGAJNEKONTOIDKONTO");
                this.Columns.Add(this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO);
                this.columnBLGMTIDMJESTOTROSKA = new DataColumn("BLGMTIDMJESTOTROSKA", typeof(int), "", MappingType.Element);
                this.columnBLGMTIDMJESTOTROSKA.Caption = "Šifra MT";
                this.columnBLGMTIDMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("SuperType", "IDMJESTOTROSKA");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("SubtypeGroup", "BLGMT");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Description", "Šifra MT");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Length", "8");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "BLGMTIDMJESTOTROSKA");
                this.Columns.Add(this.columnBLGMTIDMJESTOTROSKA);
                this.columnBLGORGJEDIDORGJED = new DataColumn("BLGORGJEDIDORGJED", typeof(int), "", MappingType.Element);
                this.columnBLGORGJEDIDORGJED.Caption = "Šifra OJ";
                this.columnBLGORGJEDIDORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("SuperType", "IDORGJED");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("SubtypeGroup", "BLGORGJED");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("IsKey", "false");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Description", "Šifra OJ");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Length", "8");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("IsInReader", "true");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBLGORGJEDIDORGJED.ExtendedProperties.Add("Deklarit.InternalName", "BLGORGJEDIDORGJED");
                this.Columns.Add(this.columnBLGORGJEDIDORGJED);
                this.columnIZDATAK = new DataColumn("IZDATAK", typeof(decimal), "", MappingType.Element);
                this.columnIZDATAK.Caption = "IZDATAK";
                this.columnIZDATAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZDATAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZDATAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZDATAK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZDATAK.ExtendedProperties.Add("IsKey", "false");
                this.columnIZDATAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZDATAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZDATAK.ExtendedProperties.Add("Description", "IZDATAK");
                this.columnIZDATAK.ExtendedProperties.Add("Length", "12");
                this.columnIZDATAK.ExtendedProperties.Add("Decimals", "2");
                this.columnIZDATAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZDATAK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZDATAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZDATAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZDATAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZDATAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZDATAK.ExtendedProperties.Add("Deklarit.InternalName", "IZDATAK");
                this.Columns.Add(this.columnIZDATAK);
                this.columnPRIMITAK = new DataColumn("PRIMITAK", typeof(decimal), "", MappingType.Element);
                this.columnPRIMITAK.Caption = "PRIMITAK";
                this.columnPRIMITAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMITAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMITAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMITAK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRIMITAK.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMITAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMITAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRIMITAK.ExtendedProperties.Add("Description", "PRIMITAK");
                this.columnPRIMITAK.ExtendedProperties.Add("Length", "12");
                this.columnPRIMITAK.ExtendedProperties.Add("Decimals", "2");
                this.columnPRIMITAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRIMITAK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPRIMITAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMITAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMITAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMITAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMITAK.ExtendedProperties.Add("Deklarit.InternalName", "PRIMITAK");
                this.Columns.Add(this.columnPRIMITAK);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_FIN_BLAGAJNA_U_GK");
                this.ExtendedProperties.Add("Description", "S_FIN_BLAGAJNA_U_GK");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnNAZIVVRSTEDOK = this.Columns["NAZIVVRSTEDOK"];
                this.columnBLGDATUMDOKUMENTA = this.Columns["BLGDATUMDOKUMENTA"];
                this.columnIDBLGVRSTEDOK = this.Columns["IDBLGVRSTEDOK"];
                this.columnOPIS = this.Columns["OPIS"];
                this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO = this.Columns["BLGSTAVKEBLAGAJNEKONTOIDKONTO"];
                this.columnBLGMTIDMJESTOTROSKA = this.Columns["BLGMTIDMJESTOTROSKA"];
                this.columnBLGORGJEDIDORGJED = this.Columns["BLGORGJEDIDORGJED"];
                this.columnIZDATAK = this.Columns["IZDATAK"];
                this.columnPRIMITAK = this.Columns["PRIMITAK"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow(builder);
            }

            public S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow NewS_FIN_BLAGAJNA_U_GKRow()
            {
                return (S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_FIN_BLAGAJNA_U_GKRowChanged != null)
                {
                    S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRowChangeEventHandler handler = this.S_FIN_BLAGAJNA_U_GKRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRowChangeEvent((S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_FIN_BLAGAJNA_U_GKRowChanging != null)
                {
                    S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRowChangeEventHandler handler = this.S_FIN_BLAGAJNA_U_GKRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRowChangeEvent((S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_FIN_BLAGAJNA_U_GKRowDeleted != null)
                {
                    S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRowChangeEventHandler handler = this.S_FIN_BLAGAJNA_U_GKRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRowChangeEvent((S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_FIN_BLAGAJNA_U_GKRowDeleting != null)
                {
                    S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRowChangeEventHandler handler = this.S_FIN_BLAGAJNA_U_GKRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRowChangeEvent((S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_FIN_BLAGAJNA_U_GKRow(S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BLGDATUMDOKUMENTAColumn
            {
                get
                {
                    return this.columnBLGDATUMDOKUMENTA;
                }
            }

            public DataColumn BLGMTIDMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnBLGMTIDMJESTOTROSKA;
                }
            }

            public DataColumn BLGORGJEDIDORGJEDColumn
            {
                get
                {
                    return this.columnBLGORGJEDIDORGJED;
                }
            }

            public DataColumn BLGSTAVKEBLAGAJNEKONTOIDKONTOColumn
            {
                get
                {
                    return this.columnBLGSTAVKEBLAGAJNEKONTOIDKONTO;
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

            public DataColumn IDBLGVRSTEDOKColumn
            {
                get
                {
                    return this.columnIDBLGVRSTEDOK;
                }
            }

            public S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow this[int index]
            {
                get
                {
                    return (S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow) this.Rows[index];
                }
            }

            public DataColumn IZDATAKColumn
            {
                get
                {
                    return this.columnIZDATAK;
                }
            }

            public DataColumn NAZIVVRSTEDOKColumn
            {
                get
                {
                    return this.columnNAZIVVRSTEDOK;
                }
            }

            public DataColumn OPISColumn
            {
                get
                {
                    return this.columnOPIS;
                }
            }

            public DataColumn PRIMITAKColumn
            {
                get
                {
                    return this.columnPRIMITAK;
                }
            }
        }

        public class S_FIN_BLAGAJNA_U_GKRow : DataRow
        {
            private S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKDataTable tableS_FIN_BLAGAJNA_U_GK;

            internal S_FIN_BLAGAJNA_U_GKRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_FIN_BLAGAJNA_U_GK = (S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKDataTable) this.Table;
            }

            public bool IsBLGDATUMDOKUMENTANull()
            {
                return this.IsNull(this.tableS_FIN_BLAGAJNA_U_GK.BLGDATUMDOKUMENTAColumn);
            }

            public bool IsBLGMTIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableS_FIN_BLAGAJNA_U_GK.BLGMTIDMJESTOTROSKAColumn);
            }

            public bool IsBLGORGJEDIDORGJEDNull()
            {
                return this.IsNull(this.tableS_FIN_BLAGAJNA_U_GK.BLGORGJEDIDORGJEDColumn);
            }

            public bool IsBLGSTAVKEBLAGAJNEKONTOIDKONTONull()
            {
                return this.IsNull(this.tableS_FIN_BLAGAJNA_U_GK.BLGSTAVKEBLAGAJNEKONTOIDKONTOColumn);
            }

            public bool IsIDBLGVRSTEDOKNull()
            {
                return this.IsNull(this.tableS_FIN_BLAGAJNA_U_GK.IDBLGVRSTEDOKColumn);
            }

            public bool IsIZDATAKNull()
            {
                return this.IsNull(this.tableS_FIN_BLAGAJNA_U_GK.IZDATAKColumn);
            }

            public bool IsNAZIVVRSTEDOKNull()
            {
                return this.IsNull(this.tableS_FIN_BLAGAJNA_U_GK.NAZIVVRSTEDOKColumn);
            }

            public bool IsOPISNull()
            {
                return this.IsNull(this.tableS_FIN_BLAGAJNA_U_GK.OPISColumn);
            }

            public bool IsPRIMITAKNull()
            {
                return this.IsNull(this.tableS_FIN_BLAGAJNA_U_GK.PRIMITAKColumn);
            }

            public void SetBLGDATUMDOKUMENTANull()
            {
                this[this.tableS_FIN_BLAGAJNA_U_GK.BLGDATUMDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBLGMTIDMJESTOTROSKANull()
            {
                this[this.tableS_FIN_BLAGAJNA_U_GK.BLGMTIDMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBLGORGJEDIDORGJEDNull()
            {
                this[this.tableS_FIN_BLAGAJNA_U_GK.BLGORGJEDIDORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBLGSTAVKEBLAGAJNEKONTOIDKONTONull()
            {
                this[this.tableS_FIN_BLAGAJNA_U_GK.BLGSTAVKEBLAGAJNEKONTOIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDBLGVRSTEDOKNull()
            {
                this[this.tableS_FIN_BLAGAJNA_U_GK.IDBLGVRSTEDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZDATAKNull()
            {
                this[this.tableS_FIN_BLAGAJNA_U_GK.IZDATAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVVRSTEDOKNull()
            {
                this[this.tableS_FIN_BLAGAJNA_U_GK.NAZIVVRSTEDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISNull()
            {
                this[this.tableS_FIN_BLAGAJNA_U_GK.OPISColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMITAKNull()
            {
                this[this.tableS_FIN_BLAGAJNA_U_GK.PRIMITAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public DateTime BLGDATUMDOKUMENTA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_FIN_BLAGAJNA_U_GK.BLGDATUMDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BLGDATUMDOKUMENTA because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_FIN_BLAGAJNA_U_GK.BLGDATUMDOKUMENTAColumn] = value;
                }
            }

            public int BLGMTIDMJESTOTROSKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_BLAGAJNA_U_GK.BLGMTIDMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BLGMTIDMJESTOTROSKA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_BLAGAJNA_U_GK.BLGMTIDMJESTOTROSKAColumn] = value;
                }
            }

            public int BLGORGJEDIDORGJED
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_BLAGAJNA_U_GK.BLGORGJEDIDORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BLGORGJEDIDORGJED because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_BLAGAJNA_U_GK.BLGORGJEDIDORGJEDColumn] = value;
                }
            }

            public string BLGSTAVKEBLAGAJNEKONTOIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_BLAGAJNA_U_GK.BLGSTAVKEBLAGAJNEKONTOIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BLGSTAVKEBLAGAJNEKONTOIDKONTO because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_BLAGAJNA_U_GK.BLGSTAVKEBLAGAJNEKONTOIDKONTOColumn] = value;
                }
            }

            public int IDBLGVRSTEDOK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_BLAGAJNA_U_GK.IDBLGVRSTEDOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDBLGVRSTEDOK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_BLAGAJNA_U_GK.IDBLGVRSTEDOKColumn] = value;
                }
            }

            public decimal IZDATAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_BLAGAJNA_U_GK.IZDATAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IZDATAK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_BLAGAJNA_U_GK.IZDATAKColumn] = value;
                }
            }

            public string NAZIVVRSTEDOK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_BLAGAJNA_U_GK.NAZIVVRSTEDOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVVRSTEDOK because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_BLAGAJNA_U_GK.NAZIVVRSTEDOKColumn] = value;
                }
            }

            public string OPIS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_BLAGAJNA_U_GK.OPISColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OPIS because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_BLAGAJNA_U_GK.OPISColumn] = value;
                }
            }

            public decimal PRIMITAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_BLAGAJNA_U_GK.PRIMITAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PRIMITAK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_BLAGAJNA_U_GK.PRIMITAKColumn] = value;
                }
            }
        }

        public class S_FIN_BLAGAJNA_U_GKRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow eventRow;

            public S_FIN_BLAGAJNA_U_GKRowChangeEvent(S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow row, DataRowAction action)
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

            public S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_FIN_BLAGAJNA_U_GKRowChangeEventHandler(object sender, S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRowChangeEvent e);
    }
}

