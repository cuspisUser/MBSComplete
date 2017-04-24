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
    public class OLAKSICEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private OLAKSICEDataTable tableOLAKSICE;

        public OLAKSICEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected OLAKSICEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["OLAKSICE"] != null)
                    {
                        this.Tables.Add(new OLAKSICEDataTable(dataSet.Tables["OLAKSICE"]));
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
            OLAKSICEDataSet set = (OLAKSICEDataSet) base.Clone();
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
            OLAKSICEDataSet set = new OLAKSICEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "OLAKSICEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1010");
            this.ExtendedProperties.Add("DataSetName", "OLAKSICEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IOLAKSICEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "OLAKSICE");
            this.ExtendedProperties.Add("ObjectDescription", "Osiguranja-Olakšice");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "AlmostNever");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "OLAKSICEDataSet";
            this.Namespace = "http://www.tempuri.org/OLAKSICE";
            this.tableOLAKSICE = new OLAKSICEDataTable();
            this.Tables.Add(this.tableOLAKSICE);
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
            this.tableOLAKSICE = (OLAKSICEDataTable) this.Tables["OLAKSICE"];
            if (initTable && (this.tableOLAKSICE != null))
            {
                this.tableOLAKSICE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["OLAKSICE"] != null)
                {
                    this.Tables.Add(new OLAKSICEDataTable(dataSet.Tables["OLAKSICE"]));
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

        private bool ShouldSerializeOLAKSICE()
        {
            return false;
        }

        protected override bool ShouldSerializeRelations()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OLAKSICEDataTable OLAKSICE
        {
            get
            {
                return this.tableOLAKSICE;
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

        [Serializable]
        public class OLAKSICEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDGRUPEOLAKSICA;
            private DataColumn columnIDOLAKSICE;
            private DataColumn columnIDTIPOLAKSICE;
            private DataColumn columnMAXIMALNIIZNOSGRUPE;
            private DataColumn columnNAZIVGRUPEOLAKSICA;
            private DataColumn columnNAZIVOLAKSICE;
            private DataColumn columnNAZIVTIPOLAKSICE;
            private DataColumn columnPRIMATELJOLAKSICA1;
            private DataColumn columnPRIMATELJOLAKSICA2;
            private DataColumn columnPRIMATELJOLAKSICA3;
            private DataColumn columnVBDIOLAKSICA;
            private DataColumn columnZRNOLAKSICA;

            public event OLAKSICEDataSet.OLAKSICERowChangeEventHandler OLAKSICERowChanged;

            public event OLAKSICEDataSet.OLAKSICERowChangeEventHandler OLAKSICERowChanging;

            public event OLAKSICEDataSet.OLAKSICERowChangeEventHandler OLAKSICERowDeleted;

            public event OLAKSICEDataSet.OLAKSICERowChangeEventHandler OLAKSICERowDeleting;

            public OLAKSICEDataTable()
            {
                this.TableName = "OLAKSICE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OLAKSICEDataTable(DataTable table) : base(table.TableName)
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

            protected OLAKSICEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOLAKSICERow(OLAKSICEDataSet.OLAKSICERow row)
            {
                this.Rows.Add(row);
            }

            public OLAKSICEDataSet.OLAKSICERow AddOLAKSICERow(int iDOLAKSICE, string nAZIVOLAKSICE, int iDGRUPEOLAKSICA, int iDTIPOLAKSICE, string vBDIOLAKSICA, string zRNOLAKSICA, string pRIMATELJOLAKSICA1, string pRIMATELJOLAKSICA2, string pRIMATELJOLAKSICA3)
            {
                OLAKSICEDataSet.OLAKSICERow row = (OLAKSICEDataSet.OLAKSICERow) this.NewRow();
                row["IDOLAKSICE"] = iDOLAKSICE;
                row["NAZIVOLAKSICE"] = nAZIVOLAKSICE;
                row["IDGRUPEOLAKSICA"] = iDGRUPEOLAKSICA;
                row["IDTIPOLAKSICE"] = iDTIPOLAKSICE;
                row["VBDIOLAKSICA"] = vBDIOLAKSICA;
                row["ZRNOLAKSICA"] = zRNOLAKSICA;
                row["PRIMATELJOLAKSICA1"] = pRIMATELJOLAKSICA1;
                row["PRIMATELJOLAKSICA2"] = pRIMATELJOLAKSICA2;
                row["PRIMATELJOLAKSICA3"] = pRIMATELJOLAKSICA3;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OLAKSICEDataSet.OLAKSICEDataTable table = (OLAKSICEDataSet.OLAKSICEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OLAKSICEDataSet.OLAKSICERow FindByIDOLAKSICE(int iDOLAKSICE)
            {
                return (OLAKSICEDataSet.OLAKSICERow) this.Rows.Find(new object[] { iDOLAKSICE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OLAKSICEDataSet.OLAKSICERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OLAKSICEDataSet set = new OLAKSICEDataSet();
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
                this.columnIDOLAKSICE = new DataColumn("IDOLAKSICE", typeof(int), "", MappingType.Element);
                this.columnIDOLAKSICE.AllowDBNull = false;
                this.columnIDOLAKSICE.Caption = "Šifra olakšice";
                this.columnIDOLAKSICE.Unique = true;
                this.columnIDOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOLAKSICE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Description", "Šifra olakšice");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Length", "8");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOLAKSICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "IDOLAKSICE");
                this.Columns.Add(this.columnIDOLAKSICE);
                this.columnNAZIVOLAKSICE = new DataColumn("NAZIVOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnNAZIVOLAKSICE.AllowDBNull = false;
                this.columnNAZIVOLAKSICE.Caption = "Naziv olakšice";
                this.columnNAZIVOLAKSICE.MaxLength = 100;
                this.columnNAZIVOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Description", "Naziv olakšice");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOLAKSICE");
                this.Columns.Add(this.columnNAZIVOLAKSICE);
                this.columnIDGRUPEOLAKSICA = new DataColumn("IDGRUPEOLAKSICA", typeof(int), "", MappingType.Element);
                this.columnIDGRUPEOLAKSICA.AllowDBNull = false;
                this.columnIDGRUPEOLAKSICA.Caption = "Šifra grupe olakšica";
                this.columnIDGRUPEOLAKSICA.DefaultValue = 1;
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Description", "Šifra grupe olakšica");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Length", "5");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "IDGRUPEOLAKSICA");
                this.Columns.Add(this.columnIDGRUPEOLAKSICA);
                this.columnNAZIVGRUPEOLAKSICA = new DataColumn("NAZIVGRUPEOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnNAZIVGRUPEOLAKSICA.AllowDBNull = true;
                this.columnNAZIVGRUPEOLAKSICA.Caption = "Naziv grupe olakšice";
                this.columnNAZIVGRUPEOLAKSICA.MaxLength = 100;
                this.columnNAZIVGRUPEOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
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
                this.columnMAXIMALNIIZNOSGRUPE = new DataColumn("MAXIMALNIIZNOSGRUPE", typeof(decimal), "", MappingType.Element);
                this.columnMAXIMALNIIZNOSGRUPE.AllowDBNull = true;
                this.columnMAXIMALNIIZNOSGRUPE.Caption = "Maks. iznos olakšica u grupi";
                this.columnMAXIMALNIIZNOSGRUPE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("IsKey", "false");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Description", "Maks. iznos olakšica u grupi");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Length", "12");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Decimals", "2");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("IsInReader", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.InternalName", "MAXIMALNIIZNOSGRUPE");
                this.Columns.Add(this.columnMAXIMALNIIZNOSGRUPE);
                this.columnIDTIPOLAKSICE = new DataColumn("IDTIPOLAKSICE", typeof(int), "", MappingType.Element);
                this.columnIDTIPOLAKSICE.AllowDBNull = false;
                this.columnIDTIPOLAKSICE.Caption = "Tip olakšice";
                this.columnIDTIPOLAKSICE.DefaultValue = 1;
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Description", "Tip olakšice");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Length", "5");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPOLAKSICE");
                this.Columns.Add(this.columnIDTIPOLAKSICE);
                this.columnNAZIVTIPOLAKSICE = new DataColumn("NAZIVTIPOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnNAZIVTIPOLAKSICE.AllowDBNull = true;
                this.columnNAZIVTIPOLAKSICE.Caption = "Naziv tipa olakšice";
                this.columnNAZIVTIPOLAKSICE.MaxLength = 50;
                this.columnNAZIVTIPOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
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
                this.columnVBDIOLAKSICA = new DataColumn("VBDIOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnVBDIOLAKSICA.AllowDBNull = false;
                this.columnVBDIOLAKSICA.Caption = "VBDI žiro računa olakšice";
                this.columnVBDIOLAKSICA.MaxLength = 7;
                this.columnVBDIOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Description", "VBDI žiro računa olakšice");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Length", "7");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "VBDIOLAKSICA");
                this.Columns.Add(this.columnVBDIOLAKSICA);
                this.columnZRNOLAKSICA = new DataColumn("ZRNOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnZRNOLAKSICA.AllowDBNull = false;
                this.columnZRNOLAKSICA.Caption = "Broj žiro računa olakšice";
                this.columnZRNOLAKSICA.MaxLength = 10;
                this.columnZRNOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Description", "Broj žiro računa olakšice");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Length", "10");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "ZRNOLAKSICA");
                this.Columns.Add(this.columnZRNOLAKSICA);
                this.columnPRIMATELJOLAKSICA1 = new DataColumn("PRIMATELJOLAKSICA1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOLAKSICA1.AllowDBNull = false;
                this.columnPRIMATELJOLAKSICA1.Caption = "Primatelj olakšice (1)";
                this.columnPRIMATELJOLAKSICA1.MaxLength = 20;
                this.columnPRIMATELJOLAKSICA1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Description", "Primatelj olakšice (1)");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOLAKSICA1");
                this.Columns.Add(this.columnPRIMATELJOLAKSICA1);
                this.columnPRIMATELJOLAKSICA2 = new DataColumn("PRIMATELJOLAKSICA2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOLAKSICA2.AllowDBNull = true;
                this.columnPRIMATELJOLAKSICA2.Caption = "Primatelj olakšice (2)";
                this.columnPRIMATELJOLAKSICA2.MaxLength = 20;
                this.columnPRIMATELJOLAKSICA2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("ReadOnly", "false");
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
                this.columnPRIMATELJOLAKSICA3 = new DataColumn("PRIMATELJOLAKSICA3", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOLAKSICA3.AllowDBNull = true;
                this.columnPRIMATELJOLAKSICA3.Caption = "Primatelj olakšice (3)";
                this.columnPRIMATELJOLAKSICA3.MaxLength = 20;
                this.columnPRIMATELJOLAKSICA3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Description", "Primatelj olakšice (3)");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOLAKSICA3");
                this.Columns.Add(this.columnPRIMATELJOLAKSICA3);
                this.PrimaryKey = new DataColumn[] { this.columnIDOLAKSICE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "OLAKSICE");
                this.ExtendedProperties.Add("Description", "Osiguranja-Olakšice");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDOLAKSICE = this.Columns["IDOLAKSICE"];
                this.columnNAZIVOLAKSICE = this.Columns["NAZIVOLAKSICE"];
                this.columnIDGRUPEOLAKSICA = this.Columns["IDGRUPEOLAKSICA"];
                this.columnNAZIVGRUPEOLAKSICA = this.Columns["NAZIVGRUPEOLAKSICA"];
                this.columnMAXIMALNIIZNOSGRUPE = this.Columns["MAXIMALNIIZNOSGRUPE"];
                this.columnIDTIPOLAKSICE = this.Columns["IDTIPOLAKSICE"];
                this.columnNAZIVTIPOLAKSICE = this.Columns["NAZIVTIPOLAKSICE"];
                this.columnVBDIOLAKSICA = this.Columns["VBDIOLAKSICA"];
                this.columnZRNOLAKSICA = this.Columns["ZRNOLAKSICA"];
                this.columnPRIMATELJOLAKSICA1 = this.Columns["PRIMATELJOLAKSICA1"];
                this.columnPRIMATELJOLAKSICA2 = this.Columns["PRIMATELJOLAKSICA2"];
                this.columnPRIMATELJOLAKSICA3 = this.Columns["PRIMATELJOLAKSICA3"];
            }

            public OLAKSICEDataSet.OLAKSICERow NewOLAKSICERow()
            {
                return (OLAKSICEDataSet.OLAKSICERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OLAKSICEDataSet.OLAKSICERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OLAKSICERowChanged != null)
                {
                    OLAKSICEDataSet.OLAKSICERowChangeEventHandler oLAKSICERowChangedEvent = this.OLAKSICERowChanged;
                    if (oLAKSICERowChangedEvent != null)
                    {
                        oLAKSICERowChangedEvent(this, new OLAKSICEDataSet.OLAKSICERowChangeEvent((OLAKSICEDataSet.OLAKSICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OLAKSICERowChanging != null)
                {
                    OLAKSICEDataSet.OLAKSICERowChangeEventHandler oLAKSICERowChangingEvent = this.OLAKSICERowChanging;
                    if (oLAKSICERowChangingEvent != null)
                    {
                        oLAKSICERowChangingEvent(this, new OLAKSICEDataSet.OLAKSICERowChangeEvent((OLAKSICEDataSet.OLAKSICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.OLAKSICERowDeleted != null)
                {
                    OLAKSICEDataSet.OLAKSICERowChangeEventHandler oLAKSICERowDeletedEvent = this.OLAKSICERowDeleted;
                    if (oLAKSICERowDeletedEvent != null)
                    {
                        oLAKSICERowDeletedEvent(this, new OLAKSICEDataSet.OLAKSICERowChangeEvent((OLAKSICEDataSet.OLAKSICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OLAKSICERowDeleting != null)
                {
                    OLAKSICEDataSet.OLAKSICERowChangeEventHandler oLAKSICERowDeletingEvent = this.OLAKSICERowDeleting;
                    if (oLAKSICERowDeletingEvent != null)
                    {
                        oLAKSICERowDeletingEvent(this, new OLAKSICEDataSet.OLAKSICERowChangeEvent((OLAKSICEDataSet.OLAKSICERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOLAKSICERow(OLAKSICEDataSet.OLAKSICERow row)
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

            public DataColumn IDGRUPEOLAKSICAColumn
            {
                get
                {
                    return this.columnIDGRUPEOLAKSICA;
                }
            }

            public DataColumn IDOLAKSICEColumn
            {
                get
                {
                    return this.columnIDOLAKSICE;
                }
            }

            public DataColumn IDTIPOLAKSICEColumn
            {
                get
                {
                    return this.columnIDTIPOLAKSICE;
                }
            }

            public OLAKSICEDataSet.OLAKSICERow this[int index]
            {
                get
                {
                    return (OLAKSICEDataSet.OLAKSICERow) this.Rows[index];
                }
            }

            public DataColumn MAXIMALNIIZNOSGRUPEColumn
            {
                get
                {
                    return this.columnMAXIMALNIIZNOSGRUPE;
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

            public DataColumn PRIMATELJOLAKSICA3Column
            {
                get
                {
                    return this.columnPRIMATELJOLAKSICA3;
                }
            }

            public DataColumn VBDIOLAKSICAColumn
            {
                get
                {
                    return this.columnVBDIOLAKSICA;
                }
            }

            public DataColumn ZRNOLAKSICAColumn
            {
                get
                {
                    return this.columnZRNOLAKSICA;
                }
            }
        }

        public class OLAKSICERow : DataRow
        {
            private OLAKSICEDataSet.OLAKSICEDataTable tableOLAKSICE;

            internal OLAKSICERow(DataRowBuilder rb) : base(rb)
            {
                this.tableOLAKSICE = (OLAKSICEDataSet.OLAKSICEDataTable) this.Table;
            }

            public bool IsIDGRUPEOLAKSICANull()
            {
                return this.IsNull(this.tableOLAKSICE.IDGRUPEOLAKSICAColumn);
            }

            public bool IsIDOLAKSICENull()
            {
                return this.IsNull(this.tableOLAKSICE.IDOLAKSICEColumn);
            }

            public bool IsIDTIPOLAKSICENull()
            {
                return this.IsNull(this.tableOLAKSICE.IDTIPOLAKSICEColumn);
            }

            public bool IsMAXIMALNIIZNOSGRUPENull()
            {
                return this.IsNull(this.tableOLAKSICE.MAXIMALNIIZNOSGRUPEColumn);
            }

            public bool IsNAZIVGRUPEOLAKSICANull()
            {
                return this.IsNull(this.tableOLAKSICE.NAZIVGRUPEOLAKSICAColumn);
            }

            public bool IsNAZIVOLAKSICENull()
            {
                return this.IsNull(this.tableOLAKSICE.NAZIVOLAKSICEColumn);
            }

            public bool IsNAZIVTIPOLAKSICENull()
            {
                return this.IsNull(this.tableOLAKSICE.NAZIVTIPOLAKSICEColumn);
            }

            public bool IsPRIMATELJOLAKSICA1Null()
            {
                return this.IsNull(this.tableOLAKSICE.PRIMATELJOLAKSICA1Column);
            }

            public bool IsPRIMATELJOLAKSICA2Null()
            {
                return this.IsNull(this.tableOLAKSICE.PRIMATELJOLAKSICA2Column);
            }

            public bool IsPRIMATELJOLAKSICA3Null()
            {
                return this.IsNull(this.tableOLAKSICE.PRIMATELJOLAKSICA3Column);
            }

            public bool IsVBDIOLAKSICANull()
            {
                return this.IsNull(this.tableOLAKSICE.VBDIOLAKSICAColumn);
            }

            public bool IsZRNOLAKSICANull()
            {
                return this.IsNull(this.tableOLAKSICE.ZRNOLAKSICAColumn);
            }

            public void SetIDGRUPEOLAKSICANull()
            {
                this[this.tableOLAKSICE.IDGRUPEOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDTIPOLAKSICENull()
            {
                this[this.tableOLAKSICE.IDTIPOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMAXIMALNIIZNOSGRUPENull()
            {
                this[this.tableOLAKSICE.MAXIMALNIIZNOSGRUPEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVGRUPEOLAKSICANull()
            {
                this[this.tableOLAKSICE.NAZIVGRUPEOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOLAKSICENull()
            {
                this[this.tableOLAKSICE.NAZIVOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVTIPOLAKSICENull()
            {
                this[this.tableOLAKSICE.NAZIVTIPOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOLAKSICA1Null()
            {
                this[this.tableOLAKSICE.PRIMATELJOLAKSICA1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOLAKSICA2Null()
            {
                this[this.tableOLAKSICE.PRIMATELJOLAKSICA2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOLAKSICA3Null()
            {
                this[this.tableOLAKSICE.PRIMATELJOLAKSICA3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIOLAKSICANull()
            {
                this[this.tableOLAKSICE.VBDIOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNOLAKSICANull()
            {
                this[this.tableOLAKSICE.ZRNOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDGRUPEOLAKSICA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableOLAKSICE.IDGRUPEOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDGRUPEOLAKSICA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableOLAKSICE.IDGRUPEOLAKSICAColumn] = value;
                }
            }

            public int IDOLAKSICE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOLAKSICE.IDOLAKSICEColumn]);
                }
                set
                {
                    this[this.tableOLAKSICE.IDOLAKSICEColumn] = value;
                }
            }

            public int IDTIPOLAKSICE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableOLAKSICE.IDTIPOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOLAKSICE.IDTIPOLAKSICEColumn] = value;
                }
            }

            public decimal MAXIMALNIIZNOSGRUPE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOLAKSICE.MAXIMALNIIZNOSGRUPEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value MAXIMALNIIZNOSGRUPE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableOLAKSICE.MAXIMALNIIZNOSGRUPEColumn] = value;
                }
            }

            public string NAZIVGRUPEOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOLAKSICE.NAZIVGRUPEOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVGRUPEOLAKSICA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableOLAKSICE.NAZIVGRUPEOLAKSICAColumn] = value;
                }
            }

            public string NAZIVOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOLAKSICE.NAZIVOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVOLAKSICE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableOLAKSICE.NAZIVOLAKSICEColumn] = value;
                }
            }

            public string NAZIVTIPOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOLAKSICE.NAZIVTIPOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOLAKSICE.NAZIVTIPOLAKSICEColumn] = value;
                }
            }

            public string PRIMATELJOLAKSICA1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOLAKSICE.PRIMATELJOLAKSICA1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOLAKSICE.PRIMATELJOLAKSICA1Column] = value;
                }
            }

            public string PRIMATELJOLAKSICA2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOLAKSICE.PRIMATELJOLAKSICA2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOLAKSICE.PRIMATELJOLAKSICA2Column] = value;
                }
            }

            public string PRIMATELJOLAKSICA3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOLAKSICE.PRIMATELJOLAKSICA3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOLAKSICE.PRIMATELJOLAKSICA3Column] = value;
                }
            }

            public string VBDIOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOLAKSICE.VBDIOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOLAKSICE.VBDIOLAKSICAColumn] = value;
                }
            }

            public string ZRNOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOLAKSICE.ZRNOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOLAKSICE.ZRNOLAKSICAColumn] = value;
                }
            }
        }

        public class OLAKSICERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OLAKSICEDataSet.OLAKSICERow eventRow;

            public OLAKSICERowChangeEvent(OLAKSICEDataSet.OLAKSICERow row, DataRowAction action)
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

            public OLAKSICEDataSet.OLAKSICERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OLAKSICERowChangeEventHandler(object sender, OLAKSICEDataSet.OLAKSICERowChangeEvent e);
    }
}

