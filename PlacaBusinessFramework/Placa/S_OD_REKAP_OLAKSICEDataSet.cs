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
    public class S_OD_REKAP_OLAKSICEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_REKAP_OLAKSICEDataTable tableS_OD_REKAP_OLAKSICE;

        public S_OD_REKAP_OLAKSICEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_REKAP_OLAKSICEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_REKAP_OLAKSICE"] != null)
                    {
                        this.Tables.Add(new S_OD_REKAP_OLAKSICEDataTable(dataSet.Tables["S_OD_REKAP_OLAKSICE"]));
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
            S_OD_REKAP_OLAKSICEDataSet set = (S_OD_REKAP_OLAKSICEDataSet) base.Clone();
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
            S_OD_REKAP_OLAKSICEDataSet set = new S_OD_REKAP_OLAKSICEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_REKAP_OLAKSICEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2051");
            this.ExtendedProperties.Add("DataSetName", "S_OD_REKAP_OLAKSICEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_REKAP_OLAKSICEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_REKAP_OLAKSICE");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_REKAP_OLAKSICE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_OLAKSICE");
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
            this.DataSetName = "S_OD_REKAP_OLAKSICEDataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_REKAP_OLAKSICE";
            this.tableS_OD_REKAP_OLAKSICE = new S_OD_REKAP_OLAKSICEDataTable();
            this.Tables.Add(this.tableS_OD_REKAP_OLAKSICE);
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
            this.tableS_OD_REKAP_OLAKSICE = (S_OD_REKAP_OLAKSICEDataTable) this.Tables["S_OD_REKAP_OLAKSICE"];
            if (initTable && (this.tableS_OD_REKAP_OLAKSICE != null))
            {
                this.tableS_OD_REKAP_OLAKSICE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_REKAP_OLAKSICE"] != null)
                {
                    this.Tables.Add(new S_OD_REKAP_OLAKSICEDataTable(dataSet.Tables["S_OD_REKAP_OLAKSICE"]));
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

        private bool ShouldSerializeS_OD_REKAP_OLAKSICE()
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
        public S_OD_REKAP_OLAKSICEDataTable S_OD_REKAP_OLAKSICE
        {
            get
            {
                return this.tableS_OD_REKAP_OLAKSICE;
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
        public class S_OD_REKAP_OLAKSICEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOLAKSICE;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIDTIPOLAKSICE;
            private DataColumn columnIME;
            private DataColumn columnIZNOSOLAKSICE;
            private DataColumn columnIZNOSPOREZNOPRIZNATEOLAKSICE;
            private DataColumn columnJMBG;
            private DataColumn columnMOOLAKSICA;
            private DataColumn columnNAZIVGRUPEOLAKSICA;
            private DataColumn columnNAZIVOLAKSICE;
            private DataColumn columnNAZIVTIPOLAKSICE;
            private DataColumn columnOBRACUNATAOLAKSICA;
            private DataColumn columnPOOLAKSICA;
            private DataColumn columnPREZIME;
            private DataColumn columnPRIMATELJOLAKSICA1;
            private DataColumn columnPRIMATELJOLAKSICA2;
            private DataColumn columnZADPOJEDINACNIPOZIV;

            public event S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERowChangeEventHandler S_OD_REKAP_OLAKSICERowChanged;

            public event S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERowChangeEventHandler S_OD_REKAP_OLAKSICERowChanging;

            public event S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERowChangeEventHandler S_OD_REKAP_OLAKSICERowDeleted;

            public event S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERowChangeEventHandler S_OD_REKAP_OLAKSICERowDeleting;

            public S_OD_REKAP_OLAKSICEDataTable()
            {
                this.TableName = "S_OD_REKAP_OLAKSICE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_REKAP_OLAKSICEDataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_REKAP_OLAKSICEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_REKAP_OLAKSICERow(S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow AddS_OD_REKAP_OLAKSICERow(string mOOLAKSICA, string pOOLAKSICA, int iDRADNIK, string pREZIME, string iME, string jMBG, int iDOLAKSICE, decimal oBRACUNATAOLAKSICA, string nAZIVOLAKSICE, string nAZIVGRUPEOLAKSICA, decimal iZNOSOLAKSICE, int iDTIPOLAKSICE, string nAZIVTIPOLAKSICE, string pRIMATELJOLAKSICA1, string pRIMATELJOLAKSICA2, decimal iZNOSPOREZNOPRIZNATEOLAKSICE, string zADPOJEDINACNIPOZIV)
            {
                S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow row = (S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow) this.NewRow();
                row.ItemArray = new object[] { 
                    mOOLAKSICA, pOOLAKSICA, iDRADNIK, pREZIME, iME, jMBG, iDOLAKSICE, oBRACUNATAOLAKSICA, nAZIVOLAKSICE, nAZIVGRUPEOLAKSICA, iZNOSOLAKSICE, iDTIPOLAKSICE, nAZIVTIPOLAKSICE, pRIMATELJOLAKSICA1, pRIMATELJOLAKSICA2, iZNOSPOREZNOPRIZNATEOLAKSICE, 
                    zADPOJEDINACNIPOZIV
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICEDataTable table = (S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_REKAP_OLAKSICEDataSet set = new S_OD_REKAP_OLAKSICEDataSet();
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
                this.columnMOOLAKSICA = new DataColumn("MOOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnMOOLAKSICA.Caption = "Model odobrenja olakšice";
                this.columnMOOLAKSICA.MaxLength = 2;
                this.columnMOOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMOOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnMOOLAKSICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMOOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Description", "Model odobrenja olakšice");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Length", "2");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnMOOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMOOLAKSICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "MOOLAKSICA");
                this.Columns.Add(this.columnMOOLAKSICA);
                this.columnPOOLAKSICA = new DataColumn("POOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnPOOLAKSICA.Caption = "Poziv na broj odobrenja olakšice";
                this.columnPOOLAKSICA.MaxLength = 0x16;
                this.columnPOOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOOLAKSICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Description", "Poziv na broj odobrenja olakšice");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Length", "22");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOOLAKSICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "POOLAKSICA");
                this.Columns.Add(this.columnPOOLAKSICA);
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
                this.columnIDOLAKSICE = new DataColumn("IDOLAKSICE", typeof(int), "", MappingType.Element);
                this.columnIDOLAKSICE.Caption = "Šifra olakšice";
                this.columnIDOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Description", "Šifra olakšice");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Length", "8");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDOLAKSICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "IDOLAKSICE");
                this.Columns.Add(this.columnIDOLAKSICE);
                this.columnOBRACUNATAOLAKSICA = new DataColumn("OBRACUNATAOLAKSICA", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNATAOLAKSICA.Caption = "OBRACUNATAOLAKSICA";
                this.columnOBRACUNATAOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Description", "OBRACUNATAOLAKSICA");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNATAOLAKSICA");
                this.Columns.Add(this.columnOBRACUNATAOLAKSICA);
                this.columnNAZIVOLAKSICE = new DataColumn("NAZIVOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnNAZIVOLAKSICE.Caption = "Naziv olakšice";
                this.columnNAZIVOLAKSICE.MaxLength = 100;
                this.columnNAZIVOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Description", "Naziv olakšice");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOLAKSICE");
                this.Columns.Add(this.columnNAZIVOLAKSICE);
                this.columnNAZIVGRUPEOLAKSICA = new DataColumn("NAZIVGRUPEOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnNAZIVGRUPEOLAKSICA.Caption = "Naziv grupe olakšice";
                this.columnNAZIVGRUPEOLAKSICA.MaxLength = 100;
                this.columnNAZIVGRUPEOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Description", "Naziv grupe olakšice");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVGRUPEOLAKSICA");
                this.Columns.Add(this.columnNAZIVGRUPEOLAKSICA);
                this.columnIZNOSOLAKSICE = new DataColumn("IZNOSOLAKSICE", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSOLAKSICE.Caption = "Iznos olakšice";
                this.columnIZNOSOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Description", "Iznos olakšice");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSOLAKSICE");
                this.Columns.Add(this.columnIZNOSOLAKSICE);
                this.columnIDTIPOLAKSICE = new DataColumn("IDTIPOLAKSICE", typeof(int), "", MappingType.Element);
                this.columnIDTIPOLAKSICE.Caption = "Tip olakšice";
                this.columnIDTIPOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Description", "Tip olakšice");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Length", "5");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPOLAKSICE");
                this.Columns.Add(this.columnIDTIPOLAKSICE);
                this.columnNAZIVTIPOLAKSICE = new DataColumn("NAZIVTIPOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnNAZIVTIPOLAKSICE.Caption = "Naziv tipa olakšice";
                this.columnNAZIVTIPOLAKSICE.MaxLength = 50;
                this.columnNAZIVTIPOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Description", "Naziv tipa olakšice");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVTIPOLAKSICE");
                this.Columns.Add(this.columnNAZIVTIPOLAKSICE);
                this.columnPRIMATELJOLAKSICA1 = new DataColumn("PRIMATELJOLAKSICA1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOLAKSICA1.Caption = "Primatelj olakšice (1)";
                this.columnPRIMATELJOLAKSICA1.MaxLength = 20;
                this.columnPRIMATELJOLAKSICA1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Description", "Primatelj olakšice (1)");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOLAKSICA1");
                this.Columns.Add(this.columnPRIMATELJOLAKSICA1);
                this.columnPRIMATELJOLAKSICA2 = new DataColumn("PRIMATELJOLAKSICA2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOLAKSICA2.Caption = "Primatelj olakšice (2)";
                this.columnPRIMATELJOLAKSICA2.MaxLength = 20;
                this.columnPRIMATELJOLAKSICA2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Description", "Primatelj olakšice (2)");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOLAKSICA2");
                this.Columns.Add(this.columnPRIMATELJOLAKSICA2);
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE = new DataColumn("IZNOSPOREZNOPRIZNATEOLAKSICE", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.Caption = "IZNOSPOREZNOPRIZNATEOLAKSICE";
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("Description", "IZNOSPOREZNOPRIZNATEOLAKSICE");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSPOREZNOPRIZNATEOLAKSICE");
                this.Columns.Add(this.columnIZNOSPOREZNOPRIZNATEOLAKSICE);
                this.columnZADPOJEDINACNIPOZIV = new DataColumn("ZADPOJEDINACNIPOZIV", typeof(string), "", MappingType.Element);
                this.columnZADPOJEDINACNIPOZIV.Caption = "ZADPOJEDINACNIPOZIV";
                this.columnZADPOJEDINACNIPOZIV.MaxLength = 11;
                this.columnZADPOJEDINACNIPOZIV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("IsKey", "false");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Description", "ZADPOJEDINACNIPOZIV");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Length", "11");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Decimals", "0");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("IsInReader", "true");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.InternalName", "ZADPOJEDINACNIPOZIV");
                this.Columns.Add(this.columnZADPOJEDINACNIPOZIV);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_REKAP_OLAKSICE");
                this.ExtendedProperties.Add("Description", "S_OD_REKAP_OLAKSICE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnMOOLAKSICA = this.Columns["MOOLAKSICA"];
                this.columnPOOLAKSICA = this.Columns["POOLAKSICA"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnJMBG = this.Columns["JMBG"];
                this.columnIDOLAKSICE = this.Columns["IDOLAKSICE"];
                this.columnOBRACUNATAOLAKSICA = this.Columns["OBRACUNATAOLAKSICA"];
                this.columnNAZIVOLAKSICE = this.Columns["NAZIVOLAKSICE"];
                this.columnNAZIVGRUPEOLAKSICA = this.Columns["NAZIVGRUPEOLAKSICA"];
                this.columnIZNOSOLAKSICE = this.Columns["IZNOSOLAKSICE"];
                this.columnIDTIPOLAKSICE = this.Columns["IDTIPOLAKSICE"];
                this.columnNAZIVTIPOLAKSICE = this.Columns["NAZIVTIPOLAKSICE"];
                this.columnPRIMATELJOLAKSICA1 = this.Columns["PRIMATELJOLAKSICA1"];
                this.columnPRIMATELJOLAKSICA2 = this.Columns["PRIMATELJOLAKSICA2"];
                this.columnIZNOSPOREZNOPRIZNATEOLAKSICE = this.Columns["IZNOSPOREZNOPRIZNATEOLAKSICE"];
                this.columnZADPOJEDINACNIPOZIV = this.Columns["ZADPOJEDINACNIPOZIV"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow(builder);
            }

            public S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow NewS_OD_REKAP_OLAKSICERow()
            {
                return (S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_REKAP_OLAKSICERowChanged != null)
                {
                    S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERowChangeEventHandler handler = this.S_OD_REKAP_OLAKSICERowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERowChangeEvent((S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_REKAP_OLAKSICERowChanging != null)
                {
                    S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERowChangeEventHandler handler = this.S_OD_REKAP_OLAKSICERowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERowChangeEvent((S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_REKAP_OLAKSICERowDeleted != null)
                {
                    S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERowChangeEventHandler handler = this.S_OD_REKAP_OLAKSICERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERowChangeEvent((S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_REKAP_OLAKSICERowDeleting != null)
                {
                    S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERowChangeEventHandler handler = this.S_OD_REKAP_OLAKSICERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERowChangeEvent((S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_REKAP_OLAKSICERow(S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow row)
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

            public DataColumn IDOLAKSICEColumn
            {
                get
                {
                    return this.columnIDOLAKSICE;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public DataColumn IDTIPOLAKSICEColumn
            {
                get
                {
                    return this.columnIDTIPOLAKSICE;
                }
            }

            public DataColumn IMEColumn
            {
                get
                {
                    return this.columnIME;
                }
            }

            public S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow this[int index]
            {
                get
                {
                    return (S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow) this.Rows[index];
                }
            }

            public DataColumn IZNOSOLAKSICEColumn
            {
                get
                {
                    return this.columnIZNOSOLAKSICE;
                }
            }

            public DataColumn IZNOSPOREZNOPRIZNATEOLAKSICEColumn
            {
                get
                {
                    return this.columnIZNOSPOREZNOPRIZNATEOLAKSICE;
                }
            }

            public DataColumn JMBGColumn
            {
                get
                {
                    return this.columnJMBG;
                }
            }

            public DataColumn MOOLAKSICAColumn
            {
                get
                {
                    return this.columnMOOLAKSICA;
                }
            }

            public DataColumn NAZIVGRUPEOLAKSICAColumn
            {
                get
                {
                    return this.columnNAZIVGRUPEOLAKSICA;
                }
            }

            public DataColumn NAZIVOLAKSICEColumn
            {
                get
                {
                    return this.columnNAZIVOLAKSICE;
                }
            }

            public DataColumn NAZIVTIPOLAKSICEColumn
            {
                get
                {
                    return this.columnNAZIVTIPOLAKSICE;
                }
            }

            public DataColumn OBRACUNATAOLAKSICAColumn
            {
                get
                {
                    return this.columnOBRACUNATAOLAKSICA;
                }
            }

            public DataColumn POOLAKSICAColumn
            {
                get
                {
                    return this.columnPOOLAKSICA;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn PRIMATELJOLAKSICA1Column
            {
                get
                {
                    return this.columnPRIMATELJOLAKSICA1;
                }
            }

            public DataColumn PRIMATELJOLAKSICA2Column
            {
                get
                {
                    return this.columnPRIMATELJOLAKSICA2;
                }
            }

            public DataColumn ZADPOJEDINACNIPOZIVColumn
            {
                get
                {
                    return this.columnZADPOJEDINACNIPOZIV;
                }
            }
        }

        public class S_OD_REKAP_OLAKSICERow : DataRow
        {
            private S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICEDataTable tableS_OD_REKAP_OLAKSICE;

            internal S_OD_REKAP_OLAKSICERow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_REKAP_OLAKSICE = (S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICEDataTable) this.Table;
            }

            public bool IsIDOLAKSICENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.IDOLAKSICEColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.IDRADNIKColumn);
            }

            public bool IsIDTIPOLAKSICENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.IDTIPOLAKSICEColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.IMEColumn);
            }

            public bool IsIZNOSOLAKSICENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.IZNOSOLAKSICEColumn);
            }

            public bool IsIZNOSPOREZNOPRIZNATEOLAKSICENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.IZNOSPOREZNOPRIZNATEOLAKSICEColumn);
            }

            public bool IsJMBGNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.JMBGColumn);
            }

            public bool IsMOOLAKSICANull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.MOOLAKSICAColumn);
            }

            public bool IsNAZIVGRUPEOLAKSICANull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.NAZIVGRUPEOLAKSICAColumn);
            }

            public bool IsNAZIVOLAKSICENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.NAZIVOLAKSICEColumn);
            }

            public bool IsNAZIVTIPOLAKSICENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.NAZIVTIPOLAKSICEColumn);
            }

            public bool IsOBRACUNATAOLAKSICANull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.OBRACUNATAOLAKSICAColumn);
            }

            public bool IsPOOLAKSICANull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.POOLAKSICAColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.PREZIMEColumn);
            }

            public bool IsPRIMATELJOLAKSICA1Null()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.PRIMATELJOLAKSICA1Column);
            }

            public bool IsPRIMATELJOLAKSICA2Null()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.PRIMATELJOLAKSICA2Column);
            }

            public bool IsZADPOJEDINACNIPOZIVNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_OLAKSICE.ZADPOJEDINACNIPOZIVColumn);
            }

            public void SetIDOLAKSICENull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.IDOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDTIPOLAKSICENull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.IDTIPOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSOLAKSICENull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.IZNOSOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSPOREZNOPRIZNATEOLAKSICENull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.IZNOSPOREZNOPRIZNATEOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGNull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.JMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMOOLAKSICANull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.MOOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVGRUPEOLAKSICANull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.NAZIVGRUPEOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOLAKSICENull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.NAZIVOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVTIPOLAKSICENull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.NAZIVTIPOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATAOLAKSICANull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.OBRACUNATAOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOOLAKSICANull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.POOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOLAKSICA1Null()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.PRIMATELJOLAKSICA1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOLAKSICA2Null()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.PRIMATELJOLAKSICA2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADPOJEDINACNIPOZIVNull()
            {
                this[this.tableS_OD_REKAP_OLAKSICE.ZADPOJEDINACNIPOZIVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDOLAKSICE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_REKAP_OLAKSICE.IDOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.IDOLAKSICEColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_REKAP_OLAKSICE.IDRADNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.IDRADNIKColumn] = value;
                }
            }

            public int IDTIPOLAKSICE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_REKAP_OLAKSICE.IDTIPOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.IDTIPOLAKSICEColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_OLAKSICE.IMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.IMEColumn] = value;
                }
            }

            public decimal IZNOSOLAKSICE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_REKAP_OLAKSICE.IZNOSOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.IZNOSOLAKSICEColumn] = value;
                }
            }

            public decimal IZNOSPOREZNOPRIZNATEOLAKSICE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_REKAP_OLAKSICE.IZNOSPOREZNOPRIZNATEOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.IZNOSPOREZNOPRIZNATEOLAKSICEColumn] = value;
                }
            }

            public string JMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_OLAKSICE.JMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.JMBGColumn] = value;
                }
            }

            public string MOOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_OLAKSICE.MOOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.MOOLAKSICAColumn] = value;
                }
            }

            public string NAZIVGRUPEOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_OLAKSICE.NAZIVGRUPEOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.NAZIVGRUPEOLAKSICAColumn] = value;
                }
            }

            public string NAZIVOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_OLAKSICE.NAZIVOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.NAZIVOLAKSICEColumn] = value;
                }
            }

            public string NAZIVTIPOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_OLAKSICE.NAZIVTIPOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.NAZIVTIPOLAKSICEColumn] = value;
                }
            }

            public decimal OBRACUNATAOLAKSICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_REKAP_OLAKSICE.OBRACUNATAOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.OBRACUNATAOLAKSICAColumn] = value;
                }
            }

            public string POOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_OLAKSICE.POOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.POOLAKSICAColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_OLAKSICE.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.PREZIMEColumn] = value;
                }
            }

            public string PRIMATELJOLAKSICA1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_OLAKSICE.PRIMATELJOLAKSICA1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.PRIMATELJOLAKSICA1Column] = value;
                }
            }

            public string PRIMATELJOLAKSICA2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_OLAKSICE.PRIMATELJOLAKSICA2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.PRIMATELJOLAKSICA2Column] = value;
                }
            }

            public string ZADPOJEDINACNIPOZIV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_OLAKSICE.ZADPOJEDINACNIPOZIVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_OLAKSICE.ZADPOJEDINACNIPOZIVColumn] = value;
                }
            }
        }

        public class S_OD_REKAP_OLAKSICERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow eventRow;

            public S_OD_REKAP_OLAKSICERowChangeEvent(S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow row, DataRowAction action)
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

            public S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_REKAP_OLAKSICERowChangeEventHandler(object sender, S_OD_REKAP_OLAKSICEDataSet.S_OD_REKAP_OLAKSICERowChangeEvent e);
    }
}

