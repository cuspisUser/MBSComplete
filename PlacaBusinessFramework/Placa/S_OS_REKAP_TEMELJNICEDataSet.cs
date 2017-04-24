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
    public class S_OS_REKAP_TEMELJNICEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OS_REKAP_TEMELJNICEDataTable tableS_OS_REKAP_TEMELJNICE;

        public S_OS_REKAP_TEMELJNICEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OS_REKAP_TEMELJNICEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OS_REKAP_TEMELJNICE"] != null)
                    {
                        this.Tables.Add(new S_OS_REKAP_TEMELJNICEDataTable(dataSet.Tables["S_OS_REKAP_TEMELJNICE"]));
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
            S_OS_REKAP_TEMELJNICEDataSet set = (S_OS_REKAP_TEMELJNICEDataSet) base.Clone();
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
            S_OS_REKAP_TEMELJNICEDataSet set = new S_OS_REKAP_TEMELJNICEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OS_REKAP_TEMELJNICEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2194");
            this.ExtendedProperties.Add("DataSetName", "S_OS_REKAP_TEMELJNICEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OS_REKAP_TEMELJNICEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OS_REKAP_TEMELJNICE");
            this.ExtendedProperties.Add("ObjectDescription", "S_OS_REKAP_TEMELJNICE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\OSNOVNA");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_OS_REKAP_TEMELJNICE");
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
            this.DataSetName = "S_OS_REKAP_TEMELJNICEDataSet";
            this.Namespace = "http://www.tempuri.org/S_OS_REKAP_TEMELJNICE";
            this.tableS_OS_REKAP_TEMELJNICE = new S_OS_REKAP_TEMELJNICEDataTable();
            this.Tables.Add(this.tableS_OS_REKAP_TEMELJNICE);
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
            this.tableS_OS_REKAP_TEMELJNICE = (S_OS_REKAP_TEMELJNICEDataTable) this.Tables["S_OS_REKAP_TEMELJNICE"];
            if (initTable && (this.tableS_OS_REKAP_TEMELJNICE != null))
            {
                this.tableS_OS_REKAP_TEMELJNICE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OS_REKAP_TEMELJNICE"] != null)
                {
                    this.Tables.Add(new S_OS_REKAP_TEMELJNICEDataTable(dataSet.Tables["S_OS_REKAP_TEMELJNICE"]));
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

        private bool ShouldSerializeS_OS_REKAP_TEMELJNICE()
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
        public S_OS_REKAP_TEMELJNICEDataTable S_OS_REKAP_TEMELJNICE
        {
            get
            {
                return this.tableS_OS_REKAP_TEMELJNICE;
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
        public class S_OS_REKAP_TEMELJNICEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOSDOKUMENT;
            private DataColumn columnKTOISPRAVKAIDKONTO;
            private DataColumn columnKTOIZVORAIDKONTO;
            private DataColumn columnKTONABAVKEIDKONTO;
            private DataColumn columnOSBROJDOKUMENTA;
            private DataColumn columnOSDATUMDOK;
            private DataColumn columnOSDUGUJE;
            private DataColumn columnOSOPIS;
            private DataColumn columnOSPOTRAZUJE;

            public event S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERowChangeEventHandler S_OS_REKAP_TEMELJNICERowChanged;

            public event S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERowChangeEventHandler S_OS_REKAP_TEMELJNICERowChanging;

            public event S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERowChangeEventHandler S_OS_REKAP_TEMELJNICERowDeleted;

            public event S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERowChangeEventHandler S_OS_REKAP_TEMELJNICERowDeleting;

            public S_OS_REKAP_TEMELJNICEDataTable()
            {
                this.TableName = "S_OS_REKAP_TEMELJNICE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OS_REKAP_TEMELJNICEDataTable(DataTable table) : base(table.TableName)
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

            protected S_OS_REKAP_TEMELJNICEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OS_REKAP_TEMELJNICERow(S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow row)
            {
                this.Rows.Add(row);
            }

            public S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow AddS_OS_REKAP_TEMELJNICERow(string kTONABAVKEIDKONTO, string kTOISPRAVKAIDKONTO, string kTOIZVORAIDKONTO, decimal oSDUGUJE, decimal oSPOTRAZUJE, int iDOSDOKUMENT, int oSBROJDOKUMENTA, DateTime oSDATUMDOK, string oSOPIS)
            {
                S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow row = (S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow) this.NewRow();
                row.ItemArray = new object[] { kTONABAVKEIDKONTO, kTOISPRAVKAIDKONTO, kTOIZVORAIDKONTO, oSDUGUJE, oSPOTRAZUJE, iDOSDOKUMENT, oSBROJDOKUMENTA, oSDATUMDOK, oSOPIS };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICEDataTable table = (S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OS_REKAP_TEMELJNICEDataSet set = new S_OS_REKAP_TEMELJNICEDataSet();
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
                this.columnKTONABAVKEIDKONTO = new DataColumn("KTONABAVKEIDKONTO", typeof(string), "", MappingType.Element);
                this.columnKTONABAVKEIDKONTO.Caption = "Konto";
                this.columnKTONABAVKEIDKONTO.MaxLength = 14;
                this.columnKTONABAVKEIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("SubtypeGroup", "KTONABAVKE");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "KTONABAVKEIDKONTO");
                this.Columns.Add(this.columnKTONABAVKEIDKONTO);
                this.columnKTOISPRAVKAIDKONTO = new DataColumn("KTOISPRAVKAIDKONTO", typeof(string), "", MappingType.Element);
                this.columnKTOISPRAVKAIDKONTO.Caption = "Konto";
                this.columnKTOISPRAVKAIDKONTO.MaxLength = 14;
                this.columnKTOISPRAVKAIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("SubtypeGroup", "KTOISPRAVKA");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "KTOISPRAVKAIDKONTO");
                this.Columns.Add(this.columnKTOISPRAVKAIDKONTO);
                this.columnKTOIZVORAIDKONTO = new DataColumn("KTOIZVORAIDKONTO", typeof(string), "", MappingType.Element);
                this.columnKTOIZVORAIDKONTO.Caption = "Konto";
                this.columnKTOIZVORAIDKONTO.MaxLength = 14;
                this.columnKTOIZVORAIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("SubtypeGroup", "KTOIZVORA");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "KTOIZVORAIDKONTO");
                this.Columns.Add(this.columnKTOIZVORAIDKONTO);
                this.columnOSDUGUJE = new DataColumn("OSDUGUJE", typeof(decimal), "", MappingType.Element);
                this.columnOSDUGUJE.Caption = "OSDUGUJE";
                this.columnOSDUGUJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSDUGUJE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSDUGUJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSDUGUJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSDUGUJE.ExtendedProperties.Add("Description", "OSDUGUJE");
                this.columnOSDUGUJE.ExtendedProperties.Add("Length", "12");
                this.columnOSDUGUJE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSDUGUJE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSDUGUJE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSDUGUJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSDUGUJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.InternalName", "OSDUGUJE");
                this.Columns.Add(this.columnOSDUGUJE);
                this.columnOSPOTRAZUJE = new DataColumn("OSPOTRAZUJE", typeof(decimal), "", MappingType.Element);
                this.columnOSPOTRAZUJE.Caption = "OSPOTRAZUJE";
                this.columnOSPOTRAZUJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Description", "OSPOTRAZUJE");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Length", "12");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.InternalName", "OSPOTRAZUJE");
                this.Columns.Add(this.columnOSPOTRAZUJE);
                this.columnIDOSDOKUMENT = new DataColumn("IDOSDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnIDOSDOKUMENT.Caption = "IDOSDOKUMENT";
                this.columnIDOSDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Description", "IDOSDOKUMENT");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Length", "5");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDOSDOKUMENT");
                this.Columns.Add(this.columnIDOSDOKUMENT);
                this.columnOSBROJDOKUMENTA = new DataColumn("OSBROJDOKUMENTA", typeof(int), "", MappingType.Element);
                this.columnOSBROJDOKUMENTA.Caption = "OSBROJDOKUMENTA";
                this.columnOSBROJDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Description", "OSBROJDOKUMENTA");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Length", "5");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "OSBROJDOKUMENTA");
                this.Columns.Add(this.columnOSBROJDOKUMENTA);
                this.columnOSDATUMDOK = new DataColumn("OSDATUMDOK", typeof(DateTime), "", MappingType.Element);
                this.columnOSDATUMDOK.Caption = "OSDATUMDOK";
                this.columnOSDATUMDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSDATUMDOK.ExtendedProperties.Add("IsKey", "false");
                this.columnOSDATUMDOK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSDATUMDOK.ExtendedProperties.Add("DeklaritType", "date");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Description", "OSDATUMDOK");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Length", "8");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnOSDATUMDOK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSDATUMDOK.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.InternalName", "OSDATUMDOK");
                this.Columns.Add(this.columnOSDATUMDOK);
                this.columnOSOPIS = new DataColumn("OSOPIS", typeof(string), "", MappingType.Element);
                this.columnOSOPIS.Caption = "OSOPIS";
                this.columnOSOPIS.MaxLength = 40;
                this.columnOSOPIS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSOPIS.ExtendedProperties.Add("IsKey", "false");
                this.columnOSOPIS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSOPIS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOSOPIS.ExtendedProperties.Add("Description", "OSOPIS");
                this.columnOSOPIS.ExtendedProperties.Add("Length", "40");
                this.columnOSOPIS.ExtendedProperties.Add("Decimals", "0");
                this.columnOSOPIS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSOPIS.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.InternalName", "OSOPIS");
                this.Columns.Add(this.columnOSOPIS);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OS_REKAP_TEMELJNICE");
                this.ExtendedProperties.Add("Description", "S_OS_REKAP_TEMELJNICE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnKTONABAVKEIDKONTO = this.Columns["KTONABAVKEIDKONTO"];
                this.columnKTOISPRAVKAIDKONTO = this.Columns["KTOISPRAVKAIDKONTO"];
                this.columnKTOIZVORAIDKONTO = this.Columns["KTOIZVORAIDKONTO"];
                this.columnOSDUGUJE = this.Columns["OSDUGUJE"];
                this.columnOSPOTRAZUJE = this.Columns["OSPOTRAZUJE"];
                this.columnIDOSDOKUMENT = this.Columns["IDOSDOKUMENT"];
                this.columnOSBROJDOKUMENTA = this.Columns["OSBROJDOKUMENTA"];
                this.columnOSDATUMDOK = this.Columns["OSDATUMDOK"];
                this.columnOSOPIS = this.Columns["OSOPIS"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow(builder);
            }

            public S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow NewS_OS_REKAP_TEMELJNICERow()
            {
                return (S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OS_REKAP_TEMELJNICERowChanged != null)
                {
                    S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERowChangeEventHandler handler = this.S_OS_REKAP_TEMELJNICERowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERowChangeEvent((S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OS_REKAP_TEMELJNICERowChanging != null)
                {
                    S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERowChangeEventHandler handler = this.S_OS_REKAP_TEMELJNICERowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERowChangeEvent((S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OS_REKAP_TEMELJNICERowDeleted != null)
                {
                    S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERowChangeEventHandler handler = this.S_OS_REKAP_TEMELJNICERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERowChangeEvent((S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OS_REKAP_TEMELJNICERowDeleting != null)
                {
                    S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERowChangeEventHandler handler = this.S_OS_REKAP_TEMELJNICERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERowChangeEvent((S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OS_REKAP_TEMELJNICERow(S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow row)
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

            public DataColumn IDOSDOKUMENTColumn
            {
                get
                {
                    return this.columnIDOSDOKUMENT;
                }
            }

            public S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow this[int index]
            {
                get
                {
                    return (S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow) this.Rows[index];
                }
            }

            public DataColumn KTOISPRAVKAIDKONTOColumn
            {
                get
                {
                    return this.columnKTOISPRAVKAIDKONTO;
                }
            }

            public DataColumn KTOIZVORAIDKONTOColumn
            {
                get
                {
                    return this.columnKTOIZVORAIDKONTO;
                }
            }

            public DataColumn KTONABAVKEIDKONTOColumn
            {
                get
                {
                    return this.columnKTONABAVKEIDKONTO;
                }
            }

            public DataColumn OSBROJDOKUMENTAColumn
            {
                get
                {
                    return this.columnOSBROJDOKUMENTA;
                }
            }

            public DataColumn OSDATUMDOKColumn
            {
                get
                {
                    return this.columnOSDATUMDOK;
                }
            }

            public DataColumn OSDUGUJEColumn
            {
                get
                {
                    return this.columnOSDUGUJE;
                }
            }

            public DataColumn OSOPISColumn
            {
                get
                {
                    return this.columnOSOPIS;
                }
            }

            public DataColumn OSPOTRAZUJEColumn
            {
                get
                {
                    return this.columnOSPOTRAZUJE;
                }
            }
        }

        public class S_OS_REKAP_TEMELJNICERow : DataRow
        {
            private S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICEDataTable tableS_OS_REKAP_TEMELJNICE;

            internal S_OS_REKAP_TEMELJNICERow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OS_REKAP_TEMELJNICE = (S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICEDataTable) this.Table;
            }

            public bool IsIDOSDOKUMENTNull()
            {
                return this.IsNull(this.tableS_OS_REKAP_TEMELJNICE.IDOSDOKUMENTColumn);
            }

            public bool IsKTOISPRAVKAIDKONTONull()
            {
                return this.IsNull(this.tableS_OS_REKAP_TEMELJNICE.KTOISPRAVKAIDKONTOColumn);
            }

            public bool IsKTOIZVORAIDKONTONull()
            {
                return this.IsNull(this.tableS_OS_REKAP_TEMELJNICE.KTOIZVORAIDKONTOColumn);
            }

            public bool IsKTONABAVKEIDKONTONull()
            {
                return this.IsNull(this.tableS_OS_REKAP_TEMELJNICE.KTONABAVKEIDKONTOColumn);
            }

            public bool IsOSBROJDOKUMENTANull()
            {
                return this.IsNull(this.tableS_OS_REKAP_TEMELJNICE.OSBROJDOKUMENTAColumn);
            }

            public bool IsOSDATUMDOKNull()
            {
                return this.IsNull(this.tableS_OS_REKAP_TEMELJNICE.OSDATUMDOKColumn);
            }

            public bool IsOSDUGUJENull()
            {
                return this.IsNull(this.tableS_OS_REKAP_TEMELJNICE.OSDUGUJEColumn);
            }

            public bool IsOSOPISNull()
            {
                return this.IsNull(this.tableS_OS_REKAP_TEMELJNICE.OSOPISColumn);
            }

            public bool IsOSPOTRAZUJENull()
            {
                return this.IsNull(this.tableS_OS_REKAP_TEMELJNICE.OSPOTRAZUJEColumn);
            }

            public void SetIDOSDOKUMENTNull()
            {
                this[this.tableS_OS_REKAP_TEMELJNICE.IDOSDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTOISPRAVKAIDKONTONull()
            {
                this[this.tableS_OS_REKAP_TEMELJNICE.KTOISPRAVKAIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTOIZVORAIDKONTONull()
            {
                this[this.tableS_OS_REKAP_TEMELJNICE.KTOIZVORAIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTONABAVKEIDKONTONull()
            {
                this[this.tableS_OS_REKAP_TEMELJNICE.KTONABAVKEIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSBROJDOKUMENTANull()
            {
                this[this.tableS_OS_REKAP_TEMELJNICE.OSBROJDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSDATUMDOKNull()
            {
                this[this.tableS_OS_REKAP_TEMELJNICE.OSDATUMDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSDUGUJENull()
            {
                this[this.tableS_OS_REKAP_TEMELJNICE.OSDUGUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSOPISNull()
            {
                this[this.tableS_OS_REKAP_TEMELJNICE.OSOPISColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSPOTRAZUJENull()
            {
                this[this.tableS_OS_REKAP_TEMELJNICE.OSPOTRAZUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDOSDOKUMENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OS_REKAP_TEMELJNICE.IDOSDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDOSDOKUMENT because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_REKAP_TEMELJNICE.IDOSDOKUMENTColumn] = value;
                }
            }

            public string KTOISPRAVKAIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_REKAP_TEMELJNICE.KTOISPRAVKAIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value KTOISPRAVKAIDKONTO because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OS_REKAP_TEMELJNICE.KTOISPRAVKAIDKONTOColumn] = value;
                }
            }

            public string KTOIZVORAIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_REKAP_TEMELJNICE.KTOIZVORAIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value KTOIZVORAIDKONTO because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OS_REKAP_TEMELJNICE.KTOIZVORAIDKONTOColumn] = value;
                }
            }

            public string KTONABAVKEIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_REKAP_TEMELJNICE.KTONABAVKEIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value KTONABAVKEIDKONTO because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OS_REKAP_TEMELJNICE.KTONABAVKEIDKONTOColumn] = value;
                }
            }

            public int OSBROJDOKUMENTA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OS_REKAP_TEMELJNICE.OSBROJDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_REKAP_TEMELJNICE.OSBROJDOKUMENTAColumn] = value;
                }
            }

            public DateTime OSDATUMDOK
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_OS_REKAP_TEMELJNICE.OSDATUMDOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_OS_REKAP_TEMELJNICE.OSDATUMDOKColumn] = value;
                }
            }

            public decimal OSDUGUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_REKAP_TEMELJNICE.OSDUGUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_REKAP_TEMELJNICE.OSDUGUJEColumn] = value;
                }
            }

            public string OSOPIS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_REKAP_TEMELJNICE.OSOPISColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OS_REKAP_TEMELJNICE.OSOPISColumn] = value;
                }
            }

            public decimal OSPOTRAZUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_REKAP_TEMELJNICE.OSPOTRAZUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_REKAP_TEMELJNICE.OSPOTRAZUJEColumn] = value;
                }
            }
        }

        public class S_OS_REKAP_TEMELJNICERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow eventRow;

            public S_OS_REKAP_TEMELJNICERowChangeEvent(S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow row, DataRowAction action)
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

            public S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OS_REKAP_TEMELJNICERowChangeEventHandler(object sender, S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERowChangeEvent e);
    }
}

