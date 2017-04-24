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
    public class V_DD_PREGLED_OBRACUNADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private V_DD_PREGLED_OBRACUNADataTable tableV_DD_PREGLED_OBRACUNA;

        public V_DD_PREGLED_OBRACUNADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected V_DD_PREGLED_OBRACUNADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["V_DD_PREGLED_OBRACUNA"] != null)
                    {
                        this.Tables.Add(new V_DD_PREGLED_OBRACUNADataTable(dataSet.Tables["V_DD_PREGLED_OBRACUNA"]));
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
            V_DD_PREGLED_OBRACUNADataSet set = (V_DD_PREGLED_OBRACUNADataSet) base.Clone();
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
            V_DD_PREGLED_OBRACUNADataSet set = new V_DD_PREGLED_OBRACUNADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "V_DD_PREGLED_OBRACUNADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2090");
            this.ExtendedProperties.Add("DataSetName", "V_DD_PREGLED_OBRACUNADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IV_DD_PREGLED_OBRACUNADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "V_DD_PREGLED_OBRACUNA");
            this.ExtendedProperties.Add("ObjectDescription", "V_DD_PREGLED_OBRACUNA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_DD");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
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
            this.DataSetName = "V_DD_PREGLED_OBRACUNADataSet";
            this.Namespace = "http://www.tempuri.org/V_DD_PREGLED_OBRACUNA";
            this.tableV_DD_PREGLED_OBRACUNA = new V_DD_PREGLED_OBRACUNADataTable();
            this.Tables.Add(this.tableV_DD_PREGLED_OBRACUNA);
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
            this.tableV_DD_PREGLED_OBRACUNA = (V_DD_PREGLED_OBRACUNADataTable) this.Tables["V_DD_PREGLED_OBRACUNA"];
            if (initTable && (this.tableV_DD_PREGLED_OBRACUNA != null))
            {
                this.tableV_DD_PREGLED_OBRACUNA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["V_DD_PREGLED_OBRACUNA"] != null)
                {
                    this.Tables.Add(new V_DD_PREGLED_OBRACUNADataTable(dataSet.Tables["V_DD_PREGLED_OBRACUNA"]));
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

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        private bool ShouldSerializeV_DD_PREGLED_OBRACUNA()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public V_DD_PREGLED_OBRACUNADataTable V_DD_PREGLED_OBRACUNA
        {
            get
            {
                return this.tableV_DD_PREGLED_OBRACUNA;
            }
        }

        [Serializable]
        public class V_DD_PREGLED_OBRACUNADataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDDATUMOBRACUNA;
            private DataColumn columnDDOBRACUNIDOBRACUN;
            private DataColumn columnDDOPISOBRACUN;
            private DataColumn columnDDRSM;
            private DataColumn columnDDZAKLJUCAN;

            public event V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARowChangeEventHandler V_DD_PREGLED_OBRACUNARowChanged;

            public event V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARowChangeEventHandler V_DD_PREGLED_OBRACUNARowChanging;

            public event V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARowChangeEventHandler V_DD_PREGLED_OBRACUNARowDeleted;

            public event V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARowChangeEventHandler V_DD_PREGLED_OBRACUNARowDeleting;

            public V_DD_PREGLED_OBRACUNADataTable()
            {
                this.TableName = "V_DD_PREGLED_OBRACUNA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal V_DD_PREGLED_OBRACUNADataTable(DataTable table) : base(table.TableName)
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

            protected V_DD_PREGLED_OBRACUNADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddV_DD_PREGLED_OBRACUNARow(V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow row)
            {
                this.Rows.Add(row);
            }

            public V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow AddV_DD_PREGLED_OBRACUNARow(string dDOBRACUNIDOBRACUN, string dDOPISOBRACUN, DateTime dDDATUMOBRACUNA, bool dDZAKLJUCAN, string dDRSM)
            {
                V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow row = (V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow) this.NewRow();
                row.ItemArray = new object[] { dDOBRACUNIDOBRACUN, dDOPISOBRACUN, dDDATUMOBRACUNA, dDZAKLJUCAN, dDRSM };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNADataTable table = (V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                V_DD_PREGLED_OBRACUNADataSet set = new V_DD_PREGLED_OBRACUNADataSet();
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
                this.columnDDOBRACUNIDOBRACUN = new DataColumn("DDOBRACUNIDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnDDOBRACUNIDOBRACUN.Caption = "Šifra obračuna";
                this.columnDDOBRACUNIDOBRACUN.MaxLength = 11;
                this.columnDDOBRACUNIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Description", "Šifra obračuna");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "DDOBRACUNIDOBRACUN");
                this.Columns.Add(this.columnDDOBRACUNIDOBRACUN);
                this.columnDDOPISOBRACUN = new DataColumn("DDOPISOBRACUN", typeof(string), "", MappingType.Element);
                this.columnDDOPISOBRACUN.Caption = "Opis";
                this.columnDDOPISOBRACUN.MaxLength = 50;
                this.columnDDOPISOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Description", "Opis");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Length", "50");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "DDOPISOBRACUN");
                this.Columns.Add(this.columnDDOPISOBRACUN);
                this.columnDDDATUMOBRACUNA = new DataColumn("DDDATUMOBRACUNA", typeof(DateTime), "", MappingType.Element);
                this.columnDDDATUMOBRACUNA.Caption = "Datum obračuna";
                this.columnDDDATUMOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Description", "Datum obračuna");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Length", "8");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "DDDATUMOBRACUNA");
                this.Columns.Add(this.columnDDDATUMOBRACUNA);
                this.columnDDZAKLJUCAN = new DataColumn("DDZAKLJUCAN", typeof(bool), "", MappingType.Element);
                this.columnDDZAKLJUCAN.Caption = "DDZAKLJUCAN";
                this.columnDDZAKLJUCAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("IsKey", "false");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Description", "DDZAKLJUCAN");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Length", "1");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.InternalName", "DDZAKLJUCAN");
                this.Columns.Add(this.columnDDZAKLJUCAN);
                this.columnDDRSM = new DataColumn("DDRSM", typeof(string), "", MappingType.Element);
                this.columnDDRSM.Caption = "DDRSM";
                this.columnDDRSM.MaxLength = 5;
                this.columnDDRSM.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDRSM.ExtendedProperties.Add("IsKey", "false");
                this.columnDDRSM.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDRSM.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDRSM.ExtendedProperties.Add("Description", "DDRSM");
                this.columnDDRSM.ExtendedProperties.Add("Length", "4");
                this.columnDDRSM.ExtendedProperties.Add("Decimals", "0");
                this.columnDDRSM.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDRSM.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.InternalName", "DDRSM");
                this.Columns.Add(this.columnDDRSM);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "V_DD_PREGLED_OBRACUNA");
                this.ExtendedProperties.Add("Description", "VW_DD_PREGLED_OBRACUNA");
                this.ExtendedProperties.Add("HasOrder", "true");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnDDOBRACUNIDOBRACUN = this.Columns["DDOBRACUNIDOBRACUN"];
                this.columnDDOPISOBRACUN = this.Columns["DDOPISOBRACUN"];
                this.columnDDDATUMOBRACUNA = this.Columns["DDDATUMOBRACUNA"];
                this.columnDDZAKLJUCAN = this.Columns["DDZAKLJUCAN"];
                this.columnDDRSM = this.Columns["DDRSM"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow(builder);
            }

            public V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow NewV_DD_PREGLED_OBRACUNARow()
            {
                return (V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.V_DD_PREGLED_OBRACUNARowChanged != null)
                {
                    V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARowChangeEventHandler handler = this.V_DD_PREGLED_OBRACUNARowChanged;
                    if (handler != null)
                    {
                        handler(this, new V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARowChangeEvent((V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.V_DD_PREGLED_OBRACUNARowChanging != null)
                {
                    V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARowChangeEventHandler handler = this.V_DD_PREGLED_OBRACUNARowChanging;
                    if (handler != null)
                    {
                        handler(this, new V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARowChangeEvent((V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.V_DD_PREGLED_OBRACUNARowDeleted != null)
                {
                    V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARowChangeEventHandler handler = this.V_DD_PREGLED_OBRACUNARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARowChangeEvent((V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.V_DD_PREGLED_OBRACUNARowDeleting != null)
                {
                    V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARowChangeEventHandler handler = this.V_DD_PREGLED_OBRACUNARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARowChangeEvent((V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveV_DD_PREGLED_OBRACUNARow(V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow row)
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

            public DataColumn DDDATUMOBRACUNAColumn
            {
                get
                {
                    return this.columnDDDATUMOBRACUNA;
                }
            }

            public DataColumn DDOBRACUNIDOBRACUNColumn
            {
                get
                {
                    return this.columnDDOBRACUNIDOBRACUN;
                }
            }

            public DataColumn DDOPISOBRACUNColumn
            {
                get
                {
                    return this.columnDDOPISOBRACUN;
                }
            }

            public DataColumn DDRSMColumn
            {
                get
                {
                    return this.columnDDRSM;
                }
            }

            public DataColumn DDZAKLJUCANColumn
            {
                get
                {
                    return this.columnDDZAKLJUCAN;
                }
            }

            public V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow this[int index]
            {
                get
                {
                    return (V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow) this.Rows[index];
                }
            }
        }

        public class V_DD_PREGLED_OBRACUNARow : DataRow
        {
            private V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNADataTable tableV_DD_PREGLED_OBRACUNA;

            internal V_DD_PREGLED_OBRACUNARow(DataRowBuilder rb) : base(rb)
            {
                this.tableV_DD_PREGLED_OBRACUNA = (V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNADataTable) this.Table;
            }

            public bool IsDDDATUMOBRACUNANull()
            {
                return this.IsNull(this.tableV_DD_PREGLED_OBRACUNA.DDDATUMOBRACUNAColumn);
            }

            public bool IsDDOBRACUNIDOBRACUNNull()
            {
                return this.IsNull(this.tableV_DD_PREGLED_OBRACUNA.DDOBRACUNIDOBRACUNColumn);
            }

            public bool IsDDOPISOBRACUNNull()
            {
                return this.IsNull(this.tableV_DD_PREGLED_OBRACUNA.DDOPISOBRACUNColumn);
            }

            public bool IsDDRSMNull()
            {
                return this.IsNull(this.tableV_DD_PREGLED_OBRACUNA.DDRSMColumn);
            }

            public bool IsDDZAKLJUCANNull()
            {
                return this.IsNull(this.tableV_DD_PREGLED_OBRACUNA.DDZAKLJUCANColumn);
            }

            public void SetDDDATUMOBRACUNANull()
            {
                this[this.tableV_DD_PREGLED_OBRACUNA.DDDATUMOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOBRACUNIDOBRACUNNull()
            {
                this[this.tableV_DD_PREGLED_OBRACUNA.DDOBRACUNIDOBRACUNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOPISOBRACUNNull()
            {
                this[this.tableV_DD_PREGLED_OBRACUNA.DDOPISOBRACUNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDRSMNull()
            {
                this[this.tableV_DD_PREGLED_OBRACUNA.DDRSMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDZAKLJUCANNull()
            {
                this[this.tableV_DD_PREGLED_OBRACUNA.DDZAKLJUCANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public DateTime DDDATUMOBRACUNA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableV_DD_PREGLED_OBRACUNA.DDDATUMOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDDATUMOBRACUNA because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableV_DD_PREGLED_OBRACUNA.DDDATUMOBRACUNAColumn] = value;
                }
            }

            public string DDOBRACUNIDOBRACUN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableV_DD_PREGLED_OBRACUNA.DDOBRACUNIDOBRACUNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDOBRACUNIDOBRACUN because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableV_DD_PREGLED_OBRACUNA.DDOBRACUNIDOBRACUNColumn] = value;
                }
            }

            public string DDOPISOBRACUN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableV_DD_PREGLED_OBRACUNA.DDOPISOBRACUNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDOPISOBRACUN because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableV_DD_PREGLED_OBRACUNA.DDOPISOBRACUNColumn] = value;
                }
            }

            public string DDRSM
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableV_DD_PREGLED_OBRACUNA.DDRSMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDRSM because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableV_DD_PREGLED_OBRACUNA.DDRSMColumn] = value;
                }
            }

            public bool DDZAKLJUCAN
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableV_DD_PREGLED_OBRACUNA.DDZAKLJUCANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDZAKLJUCAN because it is DBNull.", innerException);
                    }
                    return flag;
                }
                set
                {
                    this[this.tableV_DD_PREGLED_OBRACUNA.DDZAKLJUCANColumn] = value;
                }
            }
        }

        public class V_DD_PREGLED_OBRACUNARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow eventRow;

            public V_DD_PREGLED_OBRACUNARowChangeEvent(V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow row, DataRowAction action)
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

            public V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void V_DD_PREGLED_OBRACUNARowChangeEventHandler(object sender, V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARowChangeEvent e);
    }
}

