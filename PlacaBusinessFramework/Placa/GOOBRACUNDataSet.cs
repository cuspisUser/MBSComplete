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
    public class GOOBRACUNDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private GOOBRACUNDataTable tableGOOBRACUN;

        public GOOBRACUNDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected GOOBRACUNDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["GOOBRACUN"] != null)
                    {
                        this.Tables.Add(new GOOBRACUNDataTable(dataSet.Tables["GOOBRACUN"]));
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
            GOOBRACUNDataSet set = (GOOBRACUNDataSet) base.Clone();
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
            GOOBRACUNDataSet set = new GOOBRACUNDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "GOOBRACUNDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2146");
            this.ExtendedProperties.Add("DataSetName", "GOOBRACUNDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IGOOBRACUNDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "GOOBRACUN");
            this.ExtendedProperties.Add("ObjectDescription", "Godišnji odbici i olakšice");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "GOOBRACUNDataSet";
            this.Namespace = "http://www.tempuri.org/GOOBRACUN";
            this.tableGOOBRACUN = new GOOBRACUNDataTable();
            this.Tables.Add(this.tableGOOBRACUN);
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
            this.tableGOOBRACUN = (GOOBRACUNDataTable) this.Tables["GOOBRACUN"];
            if (initTable && (this.tableGOOBRACUN != null))
            {
                this.tableGOOBRACUN.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["GOOBRACUN"] != null)
                {
                    this.Tables.Add(new GOOBRACUNDataTable(dataSet.Tables["GOOBRACUN"]));
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

        private bool ShouldSerializeGOOBRACUN()
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
        public GOOBRACUNDataTable GOOBRACUN
        {
            get
            {
                return this.tableGOOBRACUN;
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
        public class GOOBRACUNDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAKTIVAN;
            private DataColumn columnIDGOOBRACUN;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnODBICIISKORISTIVO;
            private DataColumn columnOLAKSICEISKORISTIVO;
            private DataColumn columnPREZIME;

            public event GOOBRACUNDataSet.GOOBRACUNRowChangeEventHandler GOOBRACUNRowChanged;

            public event GOOBRACUNDataSet.GOOBRACUNRowChangeEventHandler GOOBRACUNRowChanging;

            public event GOOBRACUNDataSet.GOOBRACUNRowChangeEventHandler GOOBRACUNRowDeleted;

            public event GOOBRACUNDataSet.GOOBRACUNRowChangeEventHandler GOOBRACUNRowDeleting;

            public GOOBRACUNDataTable()
            {
                this.TableName = "GOOBRACUN";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal GOOBRACUNDataTable(DataTable table) : base(table.TableName)
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

            protected GOOBRACUNDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddGOOBRACUNRow(GOOBRACUNDataSet.GOOBRACUNRow row)
            {
                this.Rows.Add(row);
            }

            public GOOBRACUNDataSet.GOOBRACUNRow AddGOOBRACUNRow(int iDRADNIK, decimal oLAKSICEISKORISTIVO, decimal oDBICIISKORISTIVO)
            {
                GOOBRACUNDataSet.GOOBRACUNRow row = (GOOBRACUNDataSet.GOOBRACUNRow) this.NewRow();
                row["IDRADNIK"] = iDRADNIK;
                row["OLAKSICEISKORISTIVO"] = oLAKSICEISKORISTIVO;
                row["ODBICIISKORISTIVO"] = oDBICIISKORISTIVO;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                GOOBRACUNDataSet.GOOBRACUNDataTable table = (GOOBRACUNDataSet.GOOBRACUNDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public GOOBRACUNDataSet.GOOBRACUNRow FindByIDGOOBRACUN(int iDGOOBRACUN)
            {
                return (GOOBRACUNDataSet.GOOBRACUNRow) this.Rows.Find(new object[] { iDGOOBRACUN });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(GOOBRACUNDataSet.GOOBRACUNRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                GOOBRACUNDataSet set = new GOOBRACUNDataSet();
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
                this.columnIDGOOBRACUN = new DataColumn("IDGOOBRACUN", typeof(int), "", MappingType.Element);
                this.columnIDGOOBRACUN.AllowDBNull = false;
                this.columnIDGOOBRACUN.Caption = "IDGOOBRACUN";
                this.columnIDGOOBRACUN.Unique = true;
                this.columnIDGOOBRACUN.AutoIncrement = true;
                this.columnIDGOOBRACUN.AutoIncrementSeed = -1L;
                this.columnIDGOOBRACUN.AutoIncrementStep = -1L;
                this.columnIDGOOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("AutoNumber", "true");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("Description", "IDGOOBRACUN");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("Length", "5");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDGOOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDGOOBRACUN");
                this.Columns.Add(this.columnIDGOOBRACUN);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Radnik");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnPREZIME = new DataColumn("PREZIME", typeof(string), "", MappingType.Element);
                this.columnPREZIME.AllowDBNull = true;
                this.columnPREZIME.Caption = "Prezime";
                this.columnPREZIME.MaxLength = 50;
                this.columnPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
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
                this.columnIME.AllowDBNull = true;
                this.columnIME.Caption = "Ime";
                this.columnIME.MaxLength = 50;
                this.columnIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
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
                this.columnAKTIVAN = new DataColumn("AKTIVAN", typeof(bool), "", MappingType.Element);
                this.columnAKTIVAN.AllowDBNull = true;
                this.columnAKTIVAN.Caption = "Aktivan";
                this.columnAKTIVAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnAKTIVAN.ExtendedProperties.Add("IsKey", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnAKTIVAN.ExtendedProperties.Add("Description", "Aktivan");
                this.columnAKTIVAN.ExtendedProperties.Add("Length", "1");
                this.columnAKTIVAN.ExtendedProperties.Add("Decimals", "0");
                this.columnAKTIVAN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.InternalName", "AKTIVAN");
                this.Columns.Add(this.columnAKTIVAN);
                this.columnOLAKSICEISKORISTIVO = new DataColumn("OLAKSICEISKORISTIVO", typeof(decimal), "", MappingType.Element);
                this.columnOLAKSICEISKORISTIVO.AllowDBNull = false;
                this.columnOLAKSICEISKORISTIVO.Caption = "OLAKSICEISKORISTIVO";
                this.columnOLAKSICEISKORISTIVO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("IsKey", "false");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("Description", "Iskoristivo olakšica");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("Length", "12");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("Decimals", "2");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOLAKSICEISKORISTIVO.ExtendedProperties.Add("Deklarit.InternalName", "OLAKSICEISKORISTIVO");
                this.Columns.Add(this.columnOLAKSICEISKORISTIVO);
                this.columnODBICIISKORISTIVO = new DataColumn("ODBICIISKORISTIVO", typeof(decimal), "", MappingType.Element);
                this.columnODBICIISKORISTIVO.AllowDBNull = false;
                this.columnODBICIISKORISTIVO.Caption = "ODBICIISKORISTIVO";
                this.columnODBICIISKORISTIVO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("IsKey", "false");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("Description", "Iskoristivo odbitaka");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("Length", "12");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("Decimals", "2");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("IsInReader", "true");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnODBICIISKORISTIVO.ExtendedProperties.Add("Deklarit.InternalName", "ODBICIISKORISTIVO");
                this.Columns.Add(this.columnODBICIISKORISTIVO);
                this.PrimaryKey = new DataColumn[] { this.columnIDGOOBRACUN };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "GOOBRACUN");
                this.ExtendedProperties.Add("Description", "Godišnji odbici i olakšice");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDGOOBRACUN = this.Columns["IDGOOBRACUN"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnAKTIVAN = this.Columns["AKTIVAN"];
                this.columnOLAKSICEISKORISTIVO = this.Columns["OLAKSICEISKORISTIVO"];
                this.columnODBICIISKORISTIVO = this.Columns["ODBICIISKORISTIVO"];
            }

            public GOOBRACUNDataSet.GOOBRACUNRow NewGOOBRACUNRow()
            {
                return (GOOBRACUNDataSet.GOOBRACUNRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new GOOBRACUNDataSet.GOOBRACUNRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.GOOBRACUNRowChanged != null)
                {
                    GOOBRACUNDataSet.GOOBRACUNRowChangeEventHandler gOOBRACUNRowChangedEvent = this.GOOBRACUNRowChanged;
                    if (gOOBRACUNRowChangedEvent != null)
                    {
                        gOOBRACUNRowChangedEvent(this, new GOOBRACUNDataSet.GOOBRACUNRowChangeEvent((GOOBRACUNDataSet.GOOBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.GOOBRACUNRowChanging != null)
                {
                    GOOBRACUNDataSet.GOOBRACUNRowChangeEventHandler gOOBRACUNRowChangingEvent = this.GOOBRACUNRowChanging;
                    if (gOOBRACUNRowChangingEvent != null)
                    {
                        gOOBRACUNRowChangingEvent(this, new GOOBRACUNDataSet.GOOBRACUNRowChangeEvent((GOOBRACUNDataSet.GOOBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.GOOBRACUNRowDeleted != null)
                {
                    GOOBRACUNDataSet.GOOBRACUNRowChangeEventHandler gOOBRACUNRowDeletedEvent = this.GOOBRACUNRowDeleted;
                    if (gOOBRACUNRowDeletedEvent != null)
                    {
                        gOOBRACUNRowDeletedEvent(this, new GOOBRACUNDataSet.GOOBRACUNRowChangeEvent((GOOBRACUNDataSet.GOOBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.GOOBRACUNRowDeleting != null)
                {
                    GOOBRACUNDataSet.GOOBRACUNRowChangeEventHandler gOOBRACUNRowDeletingEvent = this.GOOBRACUNRowDeleting;
                    if (gOOBRACUNRowDeletingEvent != null)
                    {
                        gOOBRACUNRowDeletingEvent(this, new GOOBRACUNDataSet.GOOBRACUNRowChangeEvent((GOOBRACUNDataSet.GOOBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveGOOBRACUNRow(GOOBRACUNDataSet.GOOBRACUNRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn AKTIVANColumn
            {
                get
                {
                    return this.columnAKTIVAN;
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

            public DataColumn IDGOOBRACUNColumn
            {
                get
                {
                    return this.columnIDGOOBRACUN;
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

            public GOOBRACUNDataSet.GOOBRACUNRow this[int index]
            {
                get
                {
                    return (GOOBRACUNDataSet.GOOBRACUNRow) this.Rows[index];
                }
            }

            public DataColumn ODBICIISKORISTIVOColumn
            {
                get
                {
                    return this.columnODBICIISKORISTIVO;
                }
            }

            public DataColumn OLAKSICEISKORISTIVOColumn
            {
                get
                {
                    return this.columnOLAKSICEISKORISTIVO;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }
        }

        public class GOOBRACUNRow : DataRow
        {
            private GOOBRACUNDataSet.GOOBRACUNDataTable tableGOOBRACUN;

            internal GOOBRACUNRow(DataRowBuilder rb) : base(rb)
            {
                this.tableGOOBRACUN = (GOOBRACUNDataSet.GOOBRACUNDataTable) this.Table;
            }

            public bool IsAKTIVANNull()
            {
                return this.IsNull(this.tableGOOBRACUN.AKTIVANColumn);
            }

            public bool IsIDGOOBRACUNNull()
            {
                return this.IsNull(this.tableGOOBRACUN.IDGOOBRACUNColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableGOOBRACUN.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableGOOBRACUN.IMEColumn);
            }

            public bool IsODBICIISKORISTIVONull()
            {
                return this.IsNull(this.tableGOOBRACUN.ODBICIISKORISTIVOColumn);
            }

            public bool IsOLAKSICEISKORISTIVONull()
            {
                return this.IsNull(this.tableGOOBRACUN.OLAKSICEISKORISTIVOColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableGOOBRACUN.PREZIMEColumn);
            }

            public void SetAKTIVANNull()
            {
                this[this.tableGOOBRACUN.AKTIVANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableGOOBRACUN.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableGOOBRACUN.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODBICIISKORISTIVONull()
            {
                this[this.tableGOOBRACUN.ODBICIISKORISTIVOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOLAKSICEISKORISTIVONull()
            {
                this[this.tableGOOBRACUN.OLAKSICEISKORISTIVOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableGOOBRACUN.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool AKTIVAN
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableGOOBRACUN.AKTIVANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value AKTIVAN because it is DBNull.", innerException);
                    }
                    return flag;
                }
                set
                {
                    this[this.tableGOOBRACUN.AKTIVANColumn] = value;
                }
            }

            public int IDGOOBRACUN
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableGOOBRACUN.IDGOOBRACUNColumn]);
                }
                set
                {
                    this[this.tableGOOBRACUN.IDGOOBRACUNColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableGOOBRACUN.IDRADNIKColumn]);
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
                    this[this.tableGOOBRACUN.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGOOBRACUN.IMEColumn]);
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
                    this[this.tableGOOBRACUN.IMEColumn] = value;
                }
            }

            public decimal ODBICIISKORISTIVO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableGOOBRACUN.ODBICIISKORISTIVOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ODBICIISKORISTIVO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableGOOBRACUN.ODBICIISKORISTIVOColumn] = value;
                }
            }

            public decimal OLAKSICEISKORISTIVO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableGOOBRACUN.OLAKSICEISKORISTIVOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OLAKSICEISKORISTIVO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableGOOBRACUN.OLAKSICEISKORISTIVOColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGOOBRACUN.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableGOOBRACUN.PREZIMEColumn] = value;
                }
            }
        }

        public class GOOBRACUNRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private GOOBRACUNDataSet.GOOBRACUNRow eventRow;

            public GOOBRACUNRowChangeEvent(GOOBRACUNDataSet.GOOBRACUNRow row, DataRowAction action)
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

            public GOOBRACUNDataSet.GOOBRACUNRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void GOOBRACUNRowChangeEventHandler(object sender, GOOBRACUNDataSet.GOOBRACUNRowChangeEvent e);
    }
}

