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
    public class S_OD_REKAP_POSTOTNEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_REKAP_POSTOTNEDataTable tableS_OD_REKAP_POSTOTNE;

        public S_OD_REKAP_POSTOTNEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_REKAP_POSTOTNEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_REKAP_POSTOTNE"] != null)
                    {
                        this.Tables.Add(new S_OD_REKAP_POSTOTNEDataTable(dataSet.Tables["S_OD_REKAP_POSTOTNE"]));
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
            S_OD_REKAP_POSTOTNEDataSet set = (S_OD_REKAP_POSTOTNEDataSet) base.Clone();
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
            S_OD_REKAP_POSTOTNEDataSet set = new S_OD_REKAP_POSTOTNEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_REKAP_POSTOTNEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2047");
            this.ExtendedProperties.Add("DataSetName", "S_OD_REKAP_POSTOTNEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_REKAP_POSTOTNEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_REKAP_POSTOTNE");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_REKAP_POSTOTNE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_OBUSTAVE_POSTOTNE");
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
            this.DataSetName = "S_OD_REKAP_POSTOTNEDataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_REKAP_POSTOTNE";
            this.tableS_OD_REKAP_POSTOTNE = new S_OD_REKAP_POSTOTNEDataTable();
            this.Tables.Add(this.tableS_OD_REKAP_POSTOTNE);
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
            this.tableS_OD_REKAP_POSTOTNE = (S_OD_REKAP_POSTOTNEDataTable) this.Tables["S_OD_REKAP_POSTOTNE"];
            if (initTable && (this.tableS_OD_REKAP_POSTOTNE != null))
            {
                this.tableS_OD_REKAP_POSTOTNE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_REKAP_POSTOTNE"] != null)
                {
                    this.Tables.Add(new S_OD_REKAP_POSTOTNEDataTable(dataSet.Tables["S_OD_REKAP_POSTOTNE"]));
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

        private bool ShouldSerializeS_OD_REKAP_POSTOTNE()
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
        public S_OD_REKAP_POSTOTNEDataTable S_OD_REKAP_POSTOTNE
        {
            get
            {
                return this.tableS_OD_REKAP_POSTOTNE;
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
        public class S_OD_REKAP_POSTOTNEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOBUSTAVA;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnJMBG;
            private DataColumn columnNAZIVOBUSTAVA;
            private DataColumn columnOBRACUNATO;
            private DataColumn columnPOSTOTAK;
            private DataColumn columnPREZIME;
            private DataColumn columnPRIMATELJOBUSTAVA1;
            private DataColumn columnPRIMATELJOBUSTAVA2;

            public event S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERowChangeEventHandler S_OD_REKAP_POSTOTNERowChanged;

            public event S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERowChangeEventHandler S_OD_REKAP_POSTOTNERowChanging;

            public event S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERowChangeEventHandler S_OD_REKAP_POSTOTNERowDeleted;

            public event S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERowChangeEventHandler S_OD_REKAP_POSTOTNERowDeleting;

            public S_OD_REKAP_POSTOTNEDataTable()
            {
                this.TableName = "S_OD_REKAP_POSTOTNE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_REKAP_POSTOTNEDataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_REKAP_POSTOTNEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_REKAP_POSTOTNERow(S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow AddS_OD_REKAP_POSTOTNERow(decimal oBRACUNATO, string nAZIVOBUSTAVA, int iDOBUSTAVA, string pRIMATELJOBUSTAVA1, string pRIMATELJOBUSTAVA2, string pREZIME, string iME, string jMBG, int iDRADNIK, decimal pOSTOTAK)
            {
                S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow row = (S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow) this.NewRow();
                row.ItemArray = new object[] { oBRACUNATO, nAZIVOBUSTAVA, iDOBUSTAVA, pRIMATELJOBUSTAVA1, pRIMATELJOBUSTAVA2, pREZIME, iME, jMBG, iDRADNIK, pOSTOTAK };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNEDataTable table = (S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_REKAP_POSTOTNEDataSet set = new S_OD_REKAP_POSTOTNEDataSet();
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
                this.columnOBRACUNATO = new DataColumn("OBRACUNATO", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNATO.Caption = "Obračunato";
                this.columnOBRACUNATO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOBRACUNATO.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNATO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBRACUNATO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNATO.ExtendedProperties.Add("Description", "Obračunato");
                this.columnOBRACUNATO.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNATO.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNATO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNATO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNATO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRACUNATO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNATO");
                this.Columns.Add(this.columnOBRACUNATO);
                this.columnNAZIVOBUSTAVA = new DataColumn("NAZIVOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnNAZIVOBUSTAVA.Caption = "Naziv obustave";
                this.columnNAZIVOBUSTAVA.MaxLength = 100;
                this.columnNAZIVOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Description", "Naziv obustave");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOBUSTAVA");
                this.Columns.Add(this.columnNAZIVOBUSTAVA);
                this.columnIDOBUSTAVA = new DataColumn("IDOBUSTAVA", typeof(int), "", MappingType.Element);
                this.columnIDOBUSTAVA.Caption = "Šifra obustave";
                this.columnIDOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Description", "Šifra obustave");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Length", "8");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "IDOBUSTAVA");
                this.Columns.Add(this.columnIDOBUSTAVA);
                this.columnPRIMATELJOBUSTAVA1 = new DataColumn("PRIMATELJOBUSTAVA1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOBUSTAVA1.Caption = "Primatelj (1)";
                this.columnPRIMATELJOBUSTAVA1.MaxLength = 20;
                this.columnPRIMATELJOBUSTAVA1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Description", "Primatelj (1)");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOBUSTAVA1");
                this.Columns.Add(this.columnPRIMATELJOBUSTAVA1);
                this.columnPRIMATELJOBUSTAVA2 = new DataColumn("PRIMATELJOBUSTAVA2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOBUSTAVA2.Caption = "Primatelj (2)";
                this.columnPRIMATELJOBUSTAVA2.MaxLength = 20;
                this.columnPRIMATELJOBUSTAVA2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Description", "Primatelj (2)");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOBUSTAVA2");
                this.Columns.Add(this.columnPRIMATELJOBUSTAVA2);
                this.columnPREZIME = new DataColumn("PREZIME", typeof(string), "", MappingType.Element);
                this.columnPREZIME.Caption = "Prezime";
                this.columnPREZIME.MaxLength = 50;
                this.columnPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPREZIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "PREZIME");
                this.Columns.Add(this.columnPREZIME);
                this.columnIME = new DataColumn("IME", typeof(string), "", MappingType.Element);
                this.columnIME.Caption = "Ime";
                this.columnIME.MaxLength = 50;
                this.columnIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIME.ExtendedProperties.Add("IsKey", "false");
                this.columnIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIME.ExtendedProperties.Add("Description", "Ime");
                this.columnIME.ExtendedProperties.Add("Length", "50");
                this.columnIME.ExtendedProperties.Add("Decimals", "0");
                this.columnIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.InternalName", "IME");
                this.Columns.Add(this.columnIME);
                this.columnJMBG = new DataColumn("JMBG", typeof(string), "", MappingType.Element);
                this.columnJMBG.Caption = "JMBG";
                this.columnJMBG.MaxLength = 13;
                this.columnJMBG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnJMBG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnJMBG.ExtendedProperties.Add("IsKey", "false");
                this.columnJMBG.ExtendedProperties.Add("ReadOnly", "true");
                this.columnJMBG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnJMBG.ExtendedProperties.Add("Description", "JMBG");
                this.columnJMBG.ExtendedProperties.Add("Length", "13");
                this.columnJMBG.ExtendedProperties.Add("Decimals", "0");
                this.columnJMBG.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnJMBG.ExtendedProperties.Add("IsInReader", "true");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.InternalName", "JMBG");
                this.Columns.Add(this.columnJMBG);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnPOSTOTAK = new DataColumn("POSTOTAK", typeof(decimal), "", MappingType.Element);
                this.columnPOSTOTAK.Caption = "Postotak";
                this.columnPOSTOTAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("IsKey", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOSTOTAK.ExtendedProperties.Add("Description", "Postotak");
                this.columnPOSTOTAK.ExtendedProperties.Add("Length", "5");
                this.columnPOSTOTAK.ExtendedProperties.Add("Decimals", "2");
                this.columnPOSTOTAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPOSTOTAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.InternalName", "POSTOTAK");
                this.Columns.Add(this.columnPOSTOTAK);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_REKAP_POSTOTNE");
                this.ExtendedProperties.Add("Description", "_S_OD_REKAP_POSTOTNE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnOBRACUNATO = this.Columns["OBRACUNATO"];
                this.columnNAZIVOBUSTAVA = this.Columns["NAZIVOBUSTAVA"];
                this.columnIDOBUSTAVA = this.Columns["IDOBUSTAVA"];
                this.columnPRIMATELJOBUSTAVA1 = this.Columns["PRIMATELJOBUSTAVA1"];
                this.columnPRIMATELJOBUSTAVA2 = this.Columns["PRIMATELJOBUSTAVA2"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnJMBG = this.Columns["JMBG"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnPOSTOTAK = this.Columns["POSTOTAK"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow(builder);
            }

            public S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow NewS_OD_REKAP_POSTOTNERow()
            {
                return (S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_REKAP_POSTOTNERowChanged != null)
                {
                    S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERowChangeEventHandler handler = this.S_OD_REKAP_POSTOTNERowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERowChangeEvent((S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_REKAP_POSTOTNERowChanging != null)
                {
                    S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERowChangeEventHandler handler = this.S_OD_REKAP_POSTOTNERowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERowChangeEvent((S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_REKAP_POSTOTNERowDeleted != null)
                {
                    S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERowChangeEventHandler handler = this.S_OD_REKAP_POSTOTNERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERowChangeEvent((S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_REKAP_POSTOTNERowDeleting != null)
                {
                    S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERowChangeEventHandler handler = this.S_OD_REKAP_POSTOTNERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERowChangeEvent((S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_REKAP_POSTOTNERow(S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow row)
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

            public DataColumn IDOBUSTAVAColumn
            {
                get
                {
                    return this.columnIDOBUSTAVA;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public DataColumn IMEColumn
            {
                get
                {
                    return this.columnIME;
                }
            }

            public S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow this[int index]
            {
                get
                {
                    return (S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow) this.Rows[index];
                }
            }

            public DataColumn JMBGColumn
            {
                get
                {
                    return this.columnJMBG;
                }
            }

            public DataColumn NAZIVOBUSTAVAColumn
            {
                get
                {
                    return this.columnNAZIVOBUSTAVA;
                }
            }

            public DataColumn OBRACUNATOColumn
            {
                get
                {
                    return this.columnOBRACUNATO;
                }
            }

            public DataColumn POSTOTAKColumn
            {
                get
                {
                    return this.columnPOSTOTAK;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn PRIMATELJOBUSTAVA1Column
            {
                get
                {
                    return this.columnPRIMATELJOBUSTAVA1;
                }
            }

            public DataColumn PRIMATELJOBUSTAVA2Column
            {
                get
                {
                    return this.columnPRIMATELJOBUSTAVA2;
                }
            }
        }

        public class S_OD_REKAP_POSTOTNERow : DataRow
        {
            private S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNEDataTable tableS_OD_REKAP_POSTOTNE;

            internal S_OD_REKAP_POSTOTNERow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_REKAP_POSTOTNE = (S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNEDataTable) this.Table;
            }

            public bool IsIDOBUSTAVANull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POSTOTNE.IDOBUSTAVAColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POSTOTNE.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POSTOTNE.IMEColumn);
            }

            public bool IsJMBGNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POSTOTNE.JMBGColumn);
            }

            public bool IsNAZIVOBUSTAVANull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POSTOTNE.NAZIVOBUSTAVAColumn);
            }

            public bool IsOBRACUNATONull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POSTOTNE.OBRACUNATOColumn);
            }

            public bool IsPOSTOTAKNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POSTOTNE.POSTOTAKColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POSTOTNE.PREZIMEColumn);
            }

            public bool IsPRIMATELJOBUSTAVA1Null()
            {
                return this.IsNull(this.tableS_OD_REKAP_POSTOTNE.PRIMATELJOBUSTAVA1Column);
            }

            public bool IsPRIMATELJOBUSTAVA2Null()
            {
                return this.IsNull(this.tableS_OD_REKAP_POSTOTNE.PRIMATELJOBUSTAVA2Column);
            }

            public void SetIDOBUSTAVANull()
            {
                this[this.tableS_OD_REKAP_POSTOTNE.IDOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_OD_REKAP_POSTOTNE.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableS_OD_REKAP_POSTOTNE.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGNull()
            {
                this[this.tableS_OD_REKAP_POSTOTNE.JMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOBUSTAVANull()
            {
                this[this.tableS_OD_REKAP_POSTOTNE.NAZIVOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATONull()
            {
                this[this.tableS_OD_REKAP_POSTOTNE.OBRACUNATOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOSTOTAKNull()
            {
                this[this.tableS_OD_REKAP_POSTOTNE.POSTOTAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableS_OD_REKAP_POSTOTNE.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOBUSTAVA1Null()
            {
                this[this.tableS_OD_REKAP_POSTOTNE.PRIMATELJOBUSTAVA1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOBUSTAVA2Null()
            {
                this[this.tableS_OD_REKAP_POSTOTNE.PRIMATELJOBUSTAVA2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDOBUSTAVA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_REKAP_POSTOTNE.IDOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDOBUSTAVA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POSTOTNE.IDOBUSTAVAColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_REKAP_POSTOTNE.IDRADNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POSTOTNE.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_POSTOTNE.IMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POSTOTNE.IMEColumn] = value;
                }
            }

            public string JMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_POSTOTNE.JMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POSTOTNE.JMBGColumn] = value;
                }
            }

            public string NAZIVOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_POSTOTNE.NAZIVOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POSTOTNE.NAZIVOBUSTAVAColumn] = value;
                }
            }

            public decimal OBRACUNATO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_REKAP_POSTOTNE.OBRACUNATOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POSTOTNE.OBRACUNATOColumn] = value;
                }
            }

            public decimal POSTOTAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_REKAP_POSTOTNE.POSTOTAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POSTOTNE.POSTOTAKColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_POSTOTNE.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POSTOTNE.PREZIMEColumn] = value;
                }
            }

            public string PRIMATELJOBUSTAVA1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_POSTOTNE.PRIMATELJOBUSTAVA1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POSTOTNE.PRIMATELJOBUSTAVA1Column] = value;
                }
            }

            public string PRIMATELJOBUSTAVA2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_POSTOTNE.PRIMATELJOBUSTAVA2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POSTOTNE.PRIMATELJOBUSTAVA2Column] = value;
                }
            }
        }

        public class S_OD_REKAP_POSTOTNERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow eventRow;

            public S_OD_REKAP_POSTOTNERowChangeEvent(S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow row, DataRowAction action)
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

            public S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_REKAP_POSTOTNERowChangeEventHandler(object sender, S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERowChangeEvent e);
    }
}

