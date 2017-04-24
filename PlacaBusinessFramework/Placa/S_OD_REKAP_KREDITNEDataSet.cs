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
    public class S_OD_REKAP_KREDITNEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_REKAP_KREDITNEDataTable tableS_OD_REKAP_KREDITNE;

        public S_OD_REKAP_KREDITNEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_REKAP_KREDITNEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_REKAP_KREDITNE"] != null)
                    {
                        this.Tables.Add(new S_OD_REKAP_KREDITNEDataTable(dataSet.Tables["S_OD_REKAP_KREDITNE"]));
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
            S_OD_REKAP_KREDITNEDataSet set = (S_OD_REKAP_KREDITNEDataSet) base.Clone();
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
            S_OD_REKAP_KREDITNEDataSet set = new S_OD_REKAP_KREDITNEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_REKAP_KREDITNEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2049");
            this.ExtendedProperties.Add("DataSetName", "S_OD_REKAP_KREDITNEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_REKAP_KREDITNEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_REKAP_KREDITNE");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_REKAP_KREDITNE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_OBUSTAVE_KREDITNE");
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
            this.DataSetName = "S_OD_REKAP_KREDITNEDataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_REKAP_KREDITNE";
            this.tableS_OD_REKAP_KREDITNE = new S_OD_REKAP_KREDITNEDataTable();
            this.Tables.Add(this.tableS_OD_REKAP_KREDITNE);
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
            this.tableS_OD_REKAP_KREDITNE = (S_OD_REKAP_KREDITNEDataTable) this.Tables["S_OD_REKAP_KREDITNE"];
            if (initTable && (this.tableS_OD_REKAP_KREDITNE != null))
            {
                this.tableS_OD_REKAP_KREDITNE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_REKAP_KREDITNE"] != null)
                {
                    this.Tables.Add(new S_OD_REKAP_KREDITNEDataTable(dataSet.Tables["S_OD_REKAP_KREDITNE"]));
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

        private bool ShouldSerializeS_OD_REKAP_KREDITNE()
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
        public S_OD_REKAP_KREDITNEDataTable S_OD_REKAP_KREDITNE
        {
            get
            {
                return this.tableS_OD_REKAP_KREDITNE;
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
        public class S_OD_REKAP_KREDITNEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDKREDITOR;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnJMBG;
            private DataColumn columnMODELPOZIV;
            private DataColumn columnNAZIVKREDITOR;
            private DataColumn columnOBRACUNATO;
            private DataColumn columnPREZIME;
            private DataColumn columnPRIMATELJKREDITOR1;
            private DataColumn columnPRIMATELJKREDITOR2;

            public event S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERowChangeEventHandler S_OD_REKAP_KREDITNERowChanged;

            public event S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERowChangeEventHandler S_OD_REKAP_KREDITNERowChanging;

            public event S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERowChangeEventHandler S_OD_REKAP_KREDITNERowDeleted;

            public event S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERowChangeEventHandler S_OD_REKAP_KREDITNERowDeleting;

            public S_OD_REKAP_KREDITNEDataTable()
            {
                this.TableName = "S_OD_REKAP_KREDITNE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_REKAP_KREDITNEDataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_REKAP_KREDITNEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_REKAP_KREDITNERow(S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow AddS_OD_REKAP_KREDITNERow(decimal oBRACUNATO, string nAZIVKREDITOR, int iDKREDITOR, string pRIMATELJKREDITOR1, string pRIMATELJKREDITOR2, string pREZIME, string iME, string jMBG, int iDRADNIK, string mODELPOZIV)
            {
                S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow row = (S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow) this.NewRow();
                row.ItemArray = new object[] { oBRACUNATO, nAZIVKREDITOR, iDKREDITOR, pRIMATELJKREDITOR1, pRIMATELJKREDITOR2, pREZIME, iME, jMBG, iDRADNIK, mODELPOZIV };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNEDataTable table = (S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_REKAP_KREDITNEDataSet set = new S_OD_REKAP_KREDITNEDataSet();
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
                this.columnNAZIVKREDITOR = new DataColumn("NAZIVKREDITOR", typeof(string), "", MappingType.Element);
                this.columnNAZIVKREDITOR.Caption = "NAZIVKREDITOR";
                this.columnNAZIVKREDITOR.MaxLength = 20;
                this.columnNAZIVKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Description", "NAZIVKREDITOR");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKREDITOR");
                this.Columns.Add(this.columnNAZIVKREDITOR);
                this.columnIDKREDITOR = new DataColumn("IDKREDITOR", typeof(int), "", MappingType.Element);
                this.columnIDKREDITOR.Caption = "IDKREDITOR";
                this.columnIDKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "99999999");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKREDITOR.ExtendedProperties.Add("Description", "IDKREDITOR");
                this.columnIDKREDITOR.ExtendedProperties.Add("Length", "8");
                this.columnIDKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "IDKREDITOR");
                this.Columns.Add(this.columnIDKREDITOR);
                this.columnPRIMATELJKREDITOR1 = new DataColumn("PRIMATELJKREDITOR1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKREDITOR1.Caption = "PRIMATELJKREDITO R1";
                this.columnPRIMATELJKREDITOR1.MaxLength = 20;
                this.columnPRIMATELJKREDITOR1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Description", "PRIMATELJKREDITO R1");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKREDITOR1");
                this.Columns.Add(this.columnPRIMATELJKREDITOR1);
                this.columnPRIMATELJKREDITOR2 = new DataColumn("PRIMATELJKREDITOR2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKREDITOR2.Caption = "PRIMATELJKREDITO R2";
                this.columnPRIMATELJKREDITOR2.MaxLength = 20;
                this.columnPRIMATELJKREDITOR2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Description", "PRIMATELJKREDITO R2");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKREDITOR2");
                this.Columns.Add(this.columnPRIMATELJKREDITOR2);
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
                this.columnMODELPOZIV = new DataColumn("MODELPOZIV", typeof(string), "", MappingType.Element);
                this.columnMODELPOZIV.Caption = "MODELPOZIV";
                this.columnMODELPOZIV.MaxLength = 0x19;
                this.columnMODELPOZIV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMODELPOZIV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMODELPOZIV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMODELPOZIV.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMODELPOZIV.ExtendedProperties.Add("IsKey", "false");
                this.columnMODELPOZIV.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMODELPOZIV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMODELPOZIV.ExtendedProperties.Add("Description", "MODELPOZIV");
                this.columnMODELPOZIV.ExtendedProperties.Add("Length", "25");
                this.columnMODELPOZIV.ExtendedProperties.Add("Decimals", "0");
                this.columnMODELPOZIV.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMODELPOZIV.ExtendedProperties.Add("IsInReader", "true");
                this.columnMODELPOZIV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMODELPOZIV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMODELPOZIV.ExtendedProperties.Add("Deklarit.InternalName", "MODELPOZIV");
                this.Columns.Add(this.columnMODELPOZIV);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_REKAP_KREDITNE");
                this.ExtendedProperties.Add("Description", "_S_OD_REKAP_KREDITNE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnOBRACUNATO = this.Columns["OBRACUNATO"];
                this.columnNAZIVKREDITOR = this.Columns["NAZIVKREDITOR"];
                this.columnIDKREDITOR = this.Columns["IDKREDITOR"];
                this.columnPRIMATELJKREDITOR1 = this.Columns["PRIMATELJKREDITOR1"];
                this.columnPRIMATELJKREDITOR2 = this.Columns["PRIMATELJKREDITOR2"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnJMBG = this.Columns["JMBG"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnMODELPOZIV = this.Columns["MODELPOZIV"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow(builder);
            }

            public S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow NewS_OD_REKAP_KREDITNERow()
            {
                return (S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_REKAP_KREDITNERowChanged != null)
                {
                    S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERowChangeEventHandler handler = this.S_OD_REKAP_KREDITNERowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERowChangeEvent((S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_REKAP_KREDITNERowChanging != null)
                {
                    S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERowChangeEventHandler handler = this.S_OD_REKAP_KREDITNERowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERowChangeEvent((S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_REKAP_KREDITNERowDeleted != null)
                {
                    S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERowChangeEventHandler handler = this.S_OD_REKAP_KREDITNERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERowChangeEvent((S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_REKAP_KREDITNERowDeleting != null)
                {
                    S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERowChangeEventHandler handler = this.S_OD_REKAP_KREDITNERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERowChangeEvent((S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_REKAP_KREDITNERow(S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow row)
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

            public DataColumn IDKREDITORColumn
            {
                get
                {
                    return this.columnIDKREDITOR;
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

            public S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow this[int index]
            {
                get
                {
                    return (S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow) this.Rows[index];
                }
            }

            public DataColumn JMBGColumn
            {
                get
                {
                    return this.columnJMBG;
                }
            }

            public DataColumn MODELPOZIVColumn
            {
                get
                {
                    return this.columnMODELPOZIV;
                }
            }

            public DataColumn NAZIVKREDITORColumn
            {
                get
                {
                    return this.columnNAZIVKREDITOR;
                }
            }

            public DataColumn OBRACUNATOColumn
            {
                get
                {
                    return this.columnOBRACUNATO;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn PRIMATELJKREDITOR1Column
            {
                get
                {
                    return this.columnPRIMATELJKREDITOR1;
                }
            }

            public DataColumn PRIMATELJKREDITOR2Column
            {
                get
                {
                    return this.columnPRIMATELJKREDITOR2;
                }
            }
        }

        public class S_OD_REKAP_KREDITNERow : DataRow
        {
            private S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNEDataTable tableS_OD_REKAP_KREDITNE;

            internal S_OD_REKAP_KREDITNERow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_REKAP_KREDITNE = (S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNEDataTable) this.Table;
            }

            public bool IsIDKREDITORNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_KREDITNE.IDKREDITORColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_KREDITNE.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_KREDITNE.IMEColumn);
            }

            public bool IsJMBGNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_KREDITNE.JMBGColumn);
            }

            public bool IsMODELPOZIVNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_KREDITNE.MODELPOZIVColumn);
            }

            public bool IsNAZIVKREDITORNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_KREDITNE.NAZIVKREDITORColumn);
            }

            public bool IsOBRACUNATONull()
            {
                return this.IsNull(this.tableS_OD_REKAP_KREDITNE.OBRACUNATOColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_KREDITNE.PREZIMEColumn);
            }

            public bool IsPRIMATELJKREDITOR1Null()
            {
                return this.IsNull(this.tableS_OD_REKAP_KREDITNE.PRIMATELJKREDITOR1Column);
            }

            public bool IsPRIMATELJKREDITOR2Null()
            {
                return this.IsNull(this.tableS_OD_REKAP_KREDITNE.PRIMATELJKREDITOR2Column);
            }

            public void SetIDKREDITORNull()
            {
                this[this.tableS_OD_REKAP_KREDITNE.IDKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_OD_REKAP_KREDITNE.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableS_OD_REKAP_KREDITNE.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGNull()
            {
                this[this.tableS_OD_REKAP_KREDITNE.JMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMODELPOZIVNull()
            {
                this[this.tableS_OD_REKAP_KREDITNE.MODELPOZIVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKREDITORNull()
            {
                this[this.tableS_OD_REKAP_KREDITNE.NAZIVKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATONull()
            {
                this[this.tableS_OD_REKAP_KREDITNE.OBRACUNATOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableS_OD_REKAP_KREDITNE.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKREDITOR1Null()
            {
                this[this.tableS_OD_REKAP_KREDITNE.PRIMATELJKREDITOR1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKREDITOR2Null()
            {
                this[this.tableS_OD_REKAP_KREDITNE.PRIMATELJKREDITOR2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDKREDITOR
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_REKAP_KREDITNE.IDKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDKREDITOR because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_KREDITNE.IDKREDITORColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_REKAP_KREDITNE.IDRADNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDRADNIK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_KREDITNE.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_KREDITNE.IMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_KREDITNE.IMEColumn] = value;
                }
            }

            public string JMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_KREDITNE.JMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_KREDITNE.JMBGColumn] = value;
                }
            }

            public string MODELPOZIV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_KREDITNE.MODELPOZIVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_KREDITNE.MODELPOZIVColumn] = value;
                }
            }

            public string NAZIVKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_KREDITNE.NAZIVKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_KREDITNE.NAZIVKREDITORColumn] = value;
                }
            }

            public decimal OBRACUNATO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_REKAP_KREDITNE.OBRACUNATOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_KREDITNE.OBRACUNATOColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_KREDITNE.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_KREDITNE.PREZIMEColumn] = value;
                }
            }

            public string PRIMATELJKREDITOR1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_KREDITNE.PRIMATELJKREDITOR1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_KREDITNE.PRIMATELJKREDITOR1Column] = value;
                }
            }

            public string PRIMATELJKREDITOR2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_KREDITNE.PRIMATELJKREDITOR2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_KREDITNE.PRIMATELJKREDITOR2Column] = value;
                }
            }
        }

        public class S_OD_REKAP_KREDITNERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow eventRow;

            public S_OD_REKAP_KREDITNERowChangeEvent(S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow row, DataRowAction action)
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

            public S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_REKAP_KREDITNERowChangeEventHandler(object sender, S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERowChangeEvent e);
    }
}

