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
    public class OBUSTAVADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private OBUSTAVADataTable tableOBUSTAVA;

        public OBUSTAVADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected OBUSTAVADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["OBUSTAVA"] != null)
                    {
                        this.Tables.Add(new OBUSTAVADataTable(dataSet.Tables["OBUSTAVA"]));
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
            OBUSTAVADataSet set = (OBUSTAVADataSet) base.Clone();
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
            OBUSTAVADataSet set = new OBUSTAVADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "OBUSTAVADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1009");
            this.ExtendedProperties.Add("DataSetName", "OBUSTAVADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IOBUSTAVADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "OBUSTAVA");
            this.ExtendedProperties.Add("ObjectDescription", "Obustave");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "HardlyEver");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "OBUSTAVADataSet";
            this.Namespace = "http://www.tempuri.org/OBUSTAVA";
            this.tableOBUSTAVA = new OBUSTAVADataTable();
            this.Tables.Add(this.tableOBUSTAVA);
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
            this.tableOBUSTAVA = (OBUSTAVADataTable) this.Tables["OBUSTAVA"];
            if (initTable && (this.tableOBUSTAVA != null))
            {
                this.tableOBUSTAVA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["OBUSTAVA"] != null)
                {
                    this.Tables.Add(new OBUSTAVADataTable(dataSet.Tables["OBUSTAVA"]));
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

        private bool ShouldSerializeOBUSTAVA()
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
        public OBUSTAVADataTable OBUSTAVA
        {
            get
            {
                return this.tableOBUSTAVA;
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
        public class OBUSTAVADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOBUSTAVA;
            private DataColumn columnMOOBUSTAVA;
            private DataColumn columnMZOBUSTAVA;
            private DataColumn columnNAZIVOBUSTAVA;
            private DataColumn columnNAZIVVRSTAOBUSTAVE;
            private DataColumn columnOPISPLACANJAOBUSTAVA;
            private DataColumn columnPOOBUSTAVA;
            private DataColumn columnPRIMATELJOBUSTAVA1;
            private DataColumn columnPRIMATELJOBUSTAVA2;
            private DataColumn columnPRIMATELJOBUSTAVA3;
            private DataColumn columnPZOBUSTAVA;
            private DataColumn columnSIFRAOPISAPLACANJAOBUSTAVA;
            private DataColumn columnVBDIOBUSTAVA;
            private DataColumn columnVRSTAOBUSTAVE;
            private DataColumn columnZRNOBUSTAVA;

            public event OBUSTAVADataSet.OBUSTAVARowChangeEventHandler OBUSTAVARowChanged;

            public event OBUSTAVADataSet.OBUSTAVARowChangeEventHandler OBUSTAVARowChanging;

            public event OBUSTAVADataSet.OBUSTAVARowChangeEventHandler OBUSTAVARowDeleted;

            public event OBUSTAVADataSet.OBUSTAVARowChangeEventHandler OBUSTAVARowDeleting;

            public OBUSTAVADataTable()
            {
                this.TableName = "OBUSTAVA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OBUSTAVADataTable(DataTable table) : base(table.TableName)
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

            protected OBUSTAVADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOBUSTAVARow(OBUSTAVADataSet.OBUSTAVARow row)
            {
                this.Rows.Add(row);
            }

            public OBUSTAVADataSet.OBUSTAVARow AddOBUSTAVARow(int iDOBUSTAVA, string nAZIVOBUSTAVA, string mOOBUSTAVA, string pOOBUSTAVA, string mZOBUSTAVA, string pZOBUSTAVA, string vBDIOBUSTAVA, string zRNOBUSTAVA, string pRIMATELJOBUSTAVA1, string pRIMATELJOBUSTAVA2, string pRIMATELJOBUSTAVA3, string sIFRAOPISAPLACANJAOBUSTAVA, string oPISPLACANJAOBUSTAVA, short vRSTAOBUSTAVE)
            {
                OBUSTAVADataSet.OBUSTAVARow row = (OBUSTAVADataSet.OBUSTAVARow) this.NewRow();
                row["IDOBUSTAVA"] = iDOBUSTAVA;
                row["NAZIVOBUSTAVA"] = nAZIVOBUSTAVA;
                row["MOOBUSTAVA"] = mOOBUSTAVA;
                row["POOBUSTAVA"] = pOOBUSTAVA;
                row["MZOBUSTAVA"] = mZOBUSTAVA;
                row["PZOBUSTAVA"] = pZOBUSTAVA;
                row["VBDIOBUSTAVA"] = vBDIOBUSTAVA;
                row["ZRNOBUSTAVA"] = zRNOBUSTAVA;
                row["PRIMATELJOBUSTAVA1"] = pRIMATELJOBUSTAVA1;
                row["PRIMATELJOBUSTAVA2"] = pRIMATELJOBUSTAVA2;
                row["PRIMATELJOBUSTAVA3"] = pRIMATELJOBUSTAVA3;
                row["SIFRAOPISAPLACANJAOBUSTAVA"] = sIFRAOPISAPLACANJAOBUSTAVA;
                row["OPISPLACANJAOBUSTAVA"] = oPISPLACANJAOBUSTAVA;
                row["VRSTAOBUSTAVE"] = vRSTAOBUSTAVE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OBUSTAVADataSet.OBUSTAVADataTable table = (OBUSTAVADataSet.OBUSTAVADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OBUSTAVADataSet.OBUSTAVARow FindByIDOBUSTAVA(int iDOBUSTAVA)
            {
                return (OBUSTAVADataSet.OBUSTAVARow) this.Rows.Find(new object[] { iDOBUSTAVA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OBUSTAVADataSet.OBUSTAVARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OBUSTAVADataSet set = new OBUSTAVADataSet();
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
                this.columnIDOBUSTAVA = new DataColumn("IDOBUSTAVA", typeof(int), "", MappingType.Element);
                this.columnIDOBUSTAVA.AllowDBNull = false;
                this.columnIDOBUSTAVA.Caption = "Šifra obustave";
                this.columnIDOBUSTAVA.Unique = true;
                this.columnIDOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Description", "Šifra obustave");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Length", "8");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "IDOBUSTAVA");
                this.Columns.Add(this.columnIDOBUSTAVA);
                this.columnNAZIVOBUSTAVA = new DataColumn("NAZIVOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnNAZIVOBUSTAVA.AllowDBNull = false;
                this.columnNAZIVOBUSTAVA.Caption = "Naziv obustave";
                this.columnNAZIVOBUSTAVA.MaxLength = 100;
                this.columnNAZIVOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Description", "Naziv obustave");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOBUSTAVA");
                this.Columns.Add(this.columnNAZIVOBUSTAVA);
                this.columnMOOBUSTAVA = new DataColumn("MOOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnMOOBUSTAVA.AllowDBNull = true;
                this.columnMOOBUSTAVA.Caption = "Model odobrenja";
                this.columnMOOBUSTAVA.MaxLength = 2;
                this.columnMOOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Description", "Model odobrenja");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Length", "2");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "MOOBUSTAVA");
                this.Columns.Add(this.columnMOOBUSTAVA);
                this.columnPOOBUSTAVA = new DataColumn("POOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnPOOBUSTAVA.AllowDBNull = true;
                this.columnPOOBUSTAVA.Caption = "Poziv na broj odobrenja obustave";
                this.columnPOOBUSTAVA.MaxLength = 0x16;
                this.columnPOOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Description", "Poziv na broj odobrenja obustave");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Length", "22");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "POOBUSTAVA");
                this.Columns.Add(this.columnPOOBUSTAVA);
                this.columnMZOBUSTAVA = new DataColumn("MZOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnMZOBUSTAVA.AllowDBNull = true;
                this.columnMZOBUSTAVA.Caption = "Model zaduženja obustave";
                this.columnMZOBUSTAVA.MaxLength = 2;
                this.columnMZOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Description", "Model zaduženja obustave");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Length", "2");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "MZOBUSTAVA");
                this.Columns.Add(this.columnMZOBUSTAVA);
                this.columnPZOBUSTAVA = new DataColumn("PZOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnPZOBUSTAVA.AllowDBNull = true;
                this.columnPZOBUSTAVA.Caption = "Poziv na broj zaduženja obustave";
                this.columnPZOBUSTAVA.MaxLength = 0x16;
                this.columnPZOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Description", "Poziv na broj zaduženja obustave");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Length", "22");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "PZOBUSTAVA");
                this.Columns.Add(this.columnPZOBUSTAVA);
                this.columnVBDIOBUSTAVA = new DataColumn("VBDIOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnVBDIOBUSTAVA.AllowDBNull = false;
                this.columnVBDIOBUSTAVA.Caption = "VBDI žiro računa obustave";
                this.columnVBDIOBUSTAVA.MaxLength = 7;
                this.columnVBDIOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Description", "VBDI žiro računa obustave");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Length", "7");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "VBDIOBUSTAVA");
                this.Columns.Add(this.columnVBDIOBUSTAVA);
                this.columnZRNOBUSTAVA = new DataColumn("ZRNOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnZRNOBUSTAVA.AllowDBNull = false;
                this.columnZRNOBUSTAVA.Caption = "Broj žiro računa obustave";
                this.columnZRNOBUSTAVA.MaxLength = 10;
                this.columnZRNOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Description", "Broj žiro računa obustave");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Length", "10");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "ZRNOBUSTAVA");
                this.Columns.Add(this.columnZRNOBUSTAVA);
                this.columnPRIMATELJOBUSTAVA1 = new DataColumn("PRIMATELJOBUSTAVA1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOBUSTAVA1.AllowDBNull = false;
                this.columnPRIMATELJOBUSTAVA1.Caption = "Primatelj (1)";
                this.columnPRIMATELJOBUSTAVA1.MaxLength = 20;
                this.columnPRIMATELJOBUSTAVA1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Description", "Primatelj (1)");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOBUSTAVA1");
                this.Columns.Add(this.columnPRIMATELJOBUSTAVA1);
                this.columnPRIMATELJOBUSTAVA2 = new DataColumn("PRIMATELJOBUSTAVA2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOBUSTAVA2.AllowDBNull = true;
                this.columnPRIMATELJOBUSTAVA2.Caption = "Primatelj (2)";
                this.columnPRIMATELJOBUSTAVA2.MaxLength = 20;
                this.columnPRIMATELJOBUSTAVA2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("ReadOnly", "false");
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
                this.columnPRIMATELJOBUSTAVA3 = new DataColumn("PRIMATELJOBUSTAVA3", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOBUSTAVA3.AllowDBNull = true;
                this.columnPRIMATELJOBUSTAVA3.Caption = "Primatelj (3)";
                this.columnPRIMATELJOBUSTAVA3.MaxLength = 20;
                this.columnPRIMATELJOBUSTAVA3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Description", "Primatelj (3)");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOBUSTAVA3");
                this.Columns.Add(this.columnPRIMATELJOBUSTAVA3);
                this.columnSIFRAOPISAPLACANJAOBUSTAVA = new DataColumn("SIFRAOPISAPLACANJAOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.AllowDBNull = false;
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.Caption = "Šifra opisa plaćanja";
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Description", "Šifra opisa plaćanja");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAOBUSTAVA");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAOBUSTAVA);
                this.columnOPISPLACANJAOBUSTAVA = new DataColumn("OPISPLACANJAOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAOBUSTAVA.AllowDBNull = false;
                this.columnOPISPLACANJAOBUSTAVA.Caption = "Opis plaćanja";
                this.columnOPISPLACANJAOBUSTAVA.MaxLength = 0x24;
                this.columnOPISPLACANJAOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Description", "Opis plaćanja");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAOBUSTAVA");
                this.Columns.Add(this.columnOPISPLACANJAOBUSTAVA);
                this.columnVRSTAOBUSTAVE = new DataColumn("VRSTAOBUSTAVE", typeof(short), "", MappingType.Element);
                this.columnVRSTAOBUSTAVE.AllowDBNull = false;
                this.columnVRSTAOBUSTAVE.Caption = "Vrsta obustave";
                this.columnVRSTAOBUSTAVE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Description", "Vrsta obustave");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Length", "2");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Decimals", "0");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("IsInReader", "true");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "VRSTAOBUSTAVE");
                this.Columns.Add(this.columnVRSTAOBUSTAVE);
                this.columnNAZIVVRSTAOBUSTAVE = new DataColumn("NAZIVVRSTAOBUSTAVE", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTAOBUSTAVE.AllowDBNull = true;
                this.columnNAZIVVRSTAOBUSTAVE.Caption = "Opis vrste obustave";
                this.columnNAZIVVRSTAOBUSTAVE.MaxLength = 50;
                this.columnNAZIVVRSTAOBUSTAVE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Description", "Opis vrste obustave");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTAOBUSTAVE");
                this.Columns.Add(this.columnNAZIVVRSTAOBUSTAVE);
                this.PrimaryKey = new DataColumn[] { this.columnIDOBUSTAVA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "OBUSTAVA");
                this.ExtendedProperties.Add("Description", "Obustave");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDOBUSTAVA = this.Columns["IDOBUSTAVA"];
                this.columnNAZIVOBUSTAVA = this.Columns["NAZIVOBUSTAVA"];
                this.columnMOOBUSTAVA = this.Columns["MOOBUSTAVA"];
                this.columnPOOBUSTAVA = this.Columns["POOBUSTAVA"];
                this.columnMZOBUSTAVA = this.Columns["MZOBUSTAVA"];
                this.columnPZOBUSTAVA = this.Columns["PZOBUSTAVA"];
                this.columnVBDIOBUSTAVA = this.Columns["VBDIOBUSTAVA"];
                this.columnZRNOBUSTAVA = this.Columns["ZRNOBUSTAVA"];
                this.columnPRIMATELJOBUSTAVA1 = this.Columns["PRIMATELJOBUSTAVA1"];
                this.columnPRIMATELJOBUSTAVA2 = this.Columns["PRIMATELJOBUSTAVA2"];
                this.columnPRIMATELJOBUSTAVA3 = this.Columns["PRIMATELJOBUSTAVA3"];
                this.columnSIFRAOPISAPLACANJAOBUSTAVA = this.Columns["SIFRAOPISAPLACANJAOBUSTAVA"];
                this.columnOPISPLACANJAOBUSTAVA = this.Columns["OPISPLACANJAOBUSTAVA"];
                this.columnVRSTAOBUSTAVE = this.Columns["VRSTAOBUSTAVE"];
                this.columnNAZIVVRSTAOBUSTAVE = this.Columns["NAZIVVRSTAOBUSTAVE"];
            }

            public OBUSTAVADataSet.OBUSTAVARow NewOBUSTAVARow()
            {
                return (OBUSTAVADataSet.OBUSTAVARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OBUSTAVADataSet.OBUSTAVARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OBUSTAVARowChanged != null)
                {
                    OBUSTAVADataSet.OBUSTAVARowChangeEventHandler oBUSTAVARowChangedEvent = this.OBUSTAVARowChanged;
                    if (oBUSTAVARowChangedEvent != null)
                    {
                        oBUSTAVARowChangedEvent(this, new OBUSTAVADataSet.OBUSTAVARowChangeEvent((OBUSTAVADataSet.OBUSTAVARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OBUSTAVARowChanging != null)
                {
                    OBUSTAVADataSet.OBUSTAVARowChangeEventHandler oBUSTAVARowChangingEvent = this.OBUSTAVARowChanging;
                    if (oBUSTAVARowChangingEvent != null)
                    {
                        oBUSTAVARowChangingEvent(this, new OBUSTAVADataSet.OBUSTAVARowChangeEvent((OBUSTAVADataSet.OBUSTAVARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.OBUSTAVARowDeleted != null)
                {
                    OBUSTAVADataSet.OBUSTAVARowChangeEventHandler oBUSTAVARowDeletedEvent = this.OBUSTAVARowDeleted;
                    if (oBUSTAVARowDeletedEvent != null)
                    {
                        oBUSTAVARowDeletedEvent(this, new OBUSTAVADataSet.OBUSTAVARowChangeEvent((OBUSTAVADataSet.OBUSTAVARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OBUSTAVARowDeleting != null)
                {
                    OBUSTAVADataSet.OBUSTAVARowChangeEventHandler oBUSTAVARowDeletingEvent = this.OBUSTAVARowDeleting;
                    if (oBUSTAVARowDeletingEvent != null)
                    {
                        oBUSTAVARowDeletingEvent(this, new OBUSTAVADataSet.OBUSTAVARowChangeEvent((OBUSTAVADataSet.OBUSTAVARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOBUSTAVARow(OBUSTAVADataSet.OBUSTAVARow row)
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

            public OBUSTAVADataSet.OBUSTAVARow this[int index]
            {
                get
                {
                    return (OBUSTAVADataSet.OBUSTAVARow) this.Rows[index];
                }
            }

            public DataColumn MOOBUSTAVAColumn
            {
                get
                {
                    return this.columnMOOBUSTAVA;
                }
            }

            public DataColumn MZOBUSTAVAColumn
            {
                get
                {
                    return this.columnMZOBUSTAVA;
                }
            }

            public DataColumn NAZIVOBUSTAVAColumn
            {
                get
                {
                    return this.columnNAZIVOBUSTAVA;
                }
            }

            public DataColumn NAZIVVRSTAOBUSTAVEColumn
            {
                get
                {
                    return this.columnNAZIVVRSTAOBUSTAVE;
                }
            }

            public DataColumn OPISPLACANJAOBUSTAVAColumn
            {
                get
                {
                    return this.columnOPISPLACANJAOBUSTAVA;
                }
            }

            public DataColumn POOBUSTAVAColumn
            {
                get
                {
                    return this.columnPOOBUSTAVA;
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

            public DataColumn PRIMATELJOBUSTAVA3Column
            {
                get
                {
                    return this.columnPRIMATELJOBUSTAVA3;
                }
            }

            public DataColumn PZOBUSTAVAColumn
            {
                get
                {
                    return this.columnPZOBUSTAVA;
                }
            }

            public DataColumn SIFRAOPISAPLACANJAOBUSTAVAColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJAOBUSTAVA;
                }
            }

            public DataColumn VBDIOBUSTAVAColumn
            {
                get
                {
                    return this.columnVBDIOBUSTAVA;
                }
            }

            public DataColumn VRSTAOBUSTAVEColumn
            {
                get
                {
                    return this.columnVRSTAOBUSTAVE;
                }
            }

            public DataColumn ZRNOBUSTAVAColumn
            {
                get
                {
                    return this.columnZRNOBUSTAVA;
                }
            }
        }

        public class OBUSTAVARow : DataRow
        {
            private OBUSTAVADataSet.OBUSTAVADataTable tableOBUSTAVA;

            internal OBUSTAVARow(DataRowBuilder rb) : base(rb)
            {
                this.tableOBUSTAVA = (OBUSTAVADataSet.OBUSTAVADataTable) this.Table;
            }

            public bool IsIDOBUSTAVANull()
            {
                return this.IsNull(this.tableOBUSTAVA.IDOBUSTAVAColumn);
            }

            public bool IsMOOBUSTAVANull()
            {
                return this.IsNull(this.tableOBUSTAVA.MOOBUSTAVAColumn);
            }

            public bool IsMZOBUSTAVANull()
            {
                return this.IsNull(this.tableOBUSTAVA.MZOBUSTAVAColumn);
            }

            public bool IsNAZIVOBUSTAVANull()
            {
                return this.IsNull(this.tableOBUSTAVA.NAZIVOBUSTAVAColumn);
            }

            public bool IsNAZIVVRSTAOBUSTAVENull()
            {
                return this.IsNull(this.tableOBUSTAVA.NAZIVVRSTAOBUSTAVEColumn);
            }

            public bool IsOPISPLACANJAOBUSTAVANull()
            {
                return this.IsNull(this.tableOBUSTAVA.OPISPLACANJAOBUSTAVAColumn);
            }

            public bool IsPOOBUSTAVANull()
            {
                return this.IsNull(this.tableOBUSTAVA.POOBUSTAVAColumn);
            }

            public bool IsPRIMATELJOBUSTAVA1Null()
            {
                return this.IsNull(this.tableOBUSTAVA.PRIMATELJOBUSTAVA1Column);
            }

            public bool IsPRIMATELJOBUSTAVA2Null()
            {
                return this.IsNull(this.tableOBUSTAVA.PRIMATELJOBUSTAVA2Column);
            }

            public bool IsPRIMATELJOBUSTAVA3Null()
            {
                return this.IsNull(this.tableOBUSTAVA.PRIMATELJOBUSTAVA3Column);
            }

            public bool IsPZOBUSTAVANull()
            {
                return this.IsNull(this.tableOBUSTAVA.PZOBUSTAVAColumn);
            }

            public bool IsSIFRAOPISAPLACANJAOBUSTAVANull()
            {
                return this.IsNull(this.tableOBUSTAVA.SIFRAOPISAPLACANJAOBUSTAVAColumn);
            }

            public bool IsVBDIOBUSTAVANull()
            {
                return this.IsNull(this.tableOBUSTAVA.VBDIOBUSTAVAColumn);
            }

            public bool IsVRSTAOBUSTAVENull()
            {
                return this.IsNull(this.tableOBUSTAVA.VRSTAOBUSTAVEColumn);
            }

            public bool IsZRNOBUSTAVANull()
            {
                return this.IsNull(this.tableOBUSTAVA.ZRNOBUSTAVAColumn);
            }

            public void SetMOOBUSTAVANull()
            {
                this[this.tableOBUSTAVA.MOOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZOBUSTAVANull()
            {
                this[this.tableOBUSTAVA.MZOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOBUSTAVANull()
            {
                this[this.tableOBUSTAVA.NAZIVOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVVRSTAOBUSTAVENull()
            {
                this[this.tableOBUSTAVA.NAZIVVRSTAOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAOBUSTAVANull()
            {
                this[this.tableOBUSTAVA.OPISPLACANJAOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOOBUSTAVANull()
            {
                this[this.tableOBUSTAVA.POOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOBUSTAVA1Null()
            {
                this[this.tableOBUSTAVA.PRIMATELJOBUSTAVA1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOBUSTAVA2Null()
            {
                this[this.tableOBUSTAVA.PRIMATELJOBUSTAVA2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOBUSTAVA3Null()
            {
                this[this.tableOBUSTAVA.PRIMATELJOBUSTAVA3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZOBUSTAVANull()
            {
                this[this.tableOBUSTAVA.PZOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAOBUSTAVANull()
            {
                this[this.tableOBUSTAVA.SIFRAOPISAPLACANJAOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIOBUSTAVANull()
            {
                this[this.tableOBUSTAVA.VBDIOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVRSTAOBUSTAVENull()
            {
                this[this.tableOBUSTAVA.VRSTAOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNOBUSTAVANull()
            {
                this[this.tableOBUSTAVA.ZRNOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDOBUSTAVA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOBUSTAVA.IDOBUSTAVAColumn]);
                }
                set
                {
                    this[this.tableOBUSTAVA.IDOBUSTAVAColumn] = value;
                }
            }

            public string MOOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBUSTAVA.MOOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBUSTAVA.MOOBUSTAVAColumn] = value;
                }
            }

            public string MZOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBUSTAVA.MZOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBUSTAVA.MZOBUSTAVAColumn] = value;
                }
            }

            public string NAZIVOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBUSTAVA.NAZIVOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBUSTAVA.NAZIVOBUSTAVAColumn] = value;
                }
            }

            public string NAZIVVRSTAOBUSTAVE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBUSTAVA.NAZIVVRSTAOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBUSTAVA.NAZIVVRSTAOBUSTAVEColumn] = value;
                }
            }

            public string OPISPLACANJAOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBUSTAVA.OPISPLACANJAOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBUSTAVA.OPISPLACANJAOBUSTAVAColumn] = value;
                }
            }

            public string POOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBUSTAVA.POOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBUSTAVA.POOBUSTAVAColumn] = value;
                }
            }

            public string PRIMATELJOBUSTAVA1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBUSTAVA.PRIMATELJOBUSTAVA1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBUSTAVA.PRIMATELJOBUSTAVA1Column] = value;
                }
            }

            public string PRIMATELJOBUSTAVA2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBUSTAVA.PRIMATELJOBUSTAVA2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBUSTAVA.PRIMATELJOBUSTAVA2Column] = value;
                }
            }

            public string PRIMATELJOBUSTAVA3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBUSTAVA.PRIMATELJOBUSTAVA3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBUSTAVA.PRIMATELJOBUSTAVA3Column] = value;
                }
            }

            public string PZOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBUSTAVA.PZOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBUSTAVA.PZOBUSTAVAColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBUSTAVA.SIFRAOPISAPLACANJAOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBUSTAVA.SIFRAOPISAPLACANJAOBUSTAVAColumn] = value;
                }
            }

            public string VBDIOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBUSTAVA.VBDIOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBUSTAVA.VBDIOBUSTAVAColumn] = value;
                }
            }

            public short VRSTAOBUSTAVE
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableOBUSTAVA.VRSTAOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBUSTAVA.VRSTAOBUSTAVEColumn] = value;
                }
            }

            public string ZRNOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBUSTAVA.ZRNOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBUSTAVA.ZRNOBUSTAVAColumn] = value;
                }
            }
        }

        public class OBUSTAVARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OBUSTAVADataSet.OBUSTAVARow eventRow;

            public OBUSTAVARowChangeEvent(OBUSTAVADataSet.OBUSTAVARow row, DataRowAction action)
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

            public OBUSTAVADataSet.OBUSTAVARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OBUSTAVARowChangeEventHandler(object sender, OBUSTAVADataSet.OBUSTAVARowChangeEvent e);
    }
}

