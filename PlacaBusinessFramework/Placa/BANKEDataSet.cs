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
    public class BANKEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private BANKEDataTable tableBANKE;

        public BANKEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected BANKEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["BANKE"] != null)
                    {
                        this.Tables.Add(new BANKEDataTable(dataSet.Tables["BANKE"]));
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
            BANKEDataSet set = (BANKEDataSet) base.Clone();
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
            BANKEDataSet set = new BANKEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "BANKEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", "bank_save_48.ico");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1001");
            this.ExtendedProperties.Add("DataSetName", "BANKEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IBANKEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "BANKE");
            this.ExtendedProperties.Add("ObjectDescription", "Banke");
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
            this.DataSetName = "BANKEDataSet";
            this.Namespace = "http://www.tempuri.org/BANKE";
            this.tableBANKE = new BANKEDataTable();
            this.Tables.Add(this.tableBANKE);
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
            this.tableBANKE = (BANKEDataTable) this.Tables["BANKE"];
            if (initTable && (this.tableBANKE != null))
            {
                this.tableBANKE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["BANKE"] != null)
                {
                    this.Tables.Add(new BANKEDataTable(dataSet.Tables["BANKE"]));
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

        private bool ShouldSerializeBANKE()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BANKEDataTable BANKE
        {
            get
            {
                return this.tableBANKE;
            }
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

        [Serializable]
        public class BANKEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDBANKE;
            private DataColumn columnMOBANKA;
            private DataColumn columnMZBANKA;
            private DataColumn columnNAZIVBANKE1;
            private DataColumn columnNAZIVBANKE2;
            private DataColumn columnNAZIVBANKE3;
            private DataColumn columnOPISPLACANJABANKE;
            private DataColumn columnPOBANKA;
            private DataColumn columnPZBANKA;
            private DataColumn columnSIFRAOPISPLACANJABANKE;
            private DataColumn columnVBDIBANKE;
            private DataColumn columnZRNBANKE;

            public event BANKEDataSet.BANKERowChangeEventHandler BANKERowChanged;

            public event BANKEDataSet.BANKERowChangeEventHandler BANKERowChanging;

            public event BANKEDataSet.BANKERowChangeEventHandler BANKERowDeleted;

            public event BANKEDataSet.BANKERowChangeEventHandler BANKERowDeleting;

            public BANKEDataTable()
            {
                this.TableName = "BANKE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal BANKEDataTable(DataTable table) : base(table.TableName)
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

            protected BANKEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddBANKERow(BANKEDataSet.BANKERow row)
            {
                this.Rows.Add(row);
            }

            public BANKEDataSet.BANKERow AddBANKERow(int iDBANKE, string nAZIVBANKE1, string nAZIVBANKE2, string nAZIVBANKE3, string mOBANKA, string pOBANKA, string mZBANKA, string pZBANKA, string sIFRAOPISPLACANJABANKE, string oPISPLACANJABANKE, string vBDIBANKE, string zRNBANKE)
            {
                BANKEDataSet.BANKERow row = (BANKEDataSet.BANKERow) this.NewRow();
                row["IDBANKE"] = iDBANKE;
                row["NAZIVBANKE1"] = nAZIVBANKE1;
                row["NAZIVBANKE2"] = nAZIVBANKE2;
                row["NAZIVBANKE3"] = nAZIVBANKE3;
                row["MOBANKA"] = mOBANKA;
                row["POBANKA"] = pOBANKA;
                row["MZBANKA"] = mZBANKA;
                row["PZBANKA"] = pZBANKA;
                row["SIFRAOPISPLACANJABANKE"] = sIFRAOPISPLACANJABANKE;
                row["OPISPLACANJABANKE"] = oPISPLACANJABANKE;
                row["VBDIBANKE"] = vBDIBANKE;
                row["ZRNBANKE"] = zRNBANKE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                BANKEDataSet.BANKEDataTable table = (BANKEDataSet.BANKEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public BANKEDataSet.BANKERow FindByIDBANKE(int iDBANKE)
            {
                return (BANKEDataSet.BANKERow) this.Rows.Find(new object[] { iDBANKE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(BANKEDataSet.BANKERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                BANKEDataSet set = new BANKEDataSet();
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
                this.columnIDBANKE = new DataColumn("IDBANKE", typeof(int), "", MappingType.Element);
                this.columnIDBANKE.AllowDBNull = false;
                this.columnIDBANKE.Caption = "Šifra banke";
                this.columnIDBANKE.Unique = true;
                this.columnIDBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBANKE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDBANKE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDBANKE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDBANKE.ExtendedProperties.Add("Description", "Šifra banke");
                this.columnIDBANKE.ExtendedProperties.Add("Length", "5");
                this.columnIDBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBANKE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDBANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.InternalName", "IDBANKE");
                this.Columns.Add(this.columnIDBANKE);
                this.columnNAZIVBANKE1 = new DataColumn("NAZIVBANKE1", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE1.AllowDBNull = false;
                this.columnNAZIVBANKE1.Caption = "Naziv banke";
                this.columnNAZIVBANKE1.MaxLength = 20;
                this.columnNAZIVBANKE1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Description", "Naziv banke");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE1");
                this.Columns.Add(this.columnNAZIVBANKE1);
                this.columnNAZIVBANKE2 = new DataColumn("NAZIVBANKE2", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE2.AllowDBNull = true;
                this.columnNAZIVBANKE2.Caption = "Naziv banke (2)";
                this.columnNAZIVBANKE2.MaxLength = 20;
                this.columnNAZIVBANKE2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Description", "Naziv banke");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE2");
                this.Columns.Add(this.columnNAZIVBANKE2);
                this.columnNAZIVBANKE3 = new DataColumn("NAZIVBANKE3", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE3.AllowDBNull = true;
                this.columnNAZIVBANKE3.Caption = "Naziv banke (3)";
                this.columnNAZIVBANKE3.MaxLength = 20;
                this.columnNAZIVBANKE3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Description", "Naziv banke");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE3");
                this.Columns.Add(this.columnNAZIVBANKE3);
                this.columnMOBANKA = new DataColumn("MOBANKA", typeof(string), "", MappingType.Element);
                this.columnMOBANKA.AllowDBNull = true;
                this.columnMOBANKA.Caption = "Model odobrenja banke";
                this.columnMOBANKA.MaxLength = 2;
                this.columnMOBANKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMOBANKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOBANKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOBANKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOBANKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOBANKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOBANKA.ExtendedProperties.Add("IsKey", "false");
                this.columnMOBANKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMOBANKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOBANKA.ExtendedProperties.Add("Description", "Model odobrenja");
                this.columnMOBANKA.ExtendedProperties.Add("Length", "2");
                this.columnMOBANKA.ExtendedProperties.Add("Decimals", "0");
                this.columnMOBANKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMOBANKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMOBANKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOBANKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOBANKA.ExtendedProperties.Add("Deklarit.InternalName", "MOBANKA");
                this.Columns.Add(this.columnMOBANKA);
                this.columnPOBANKA = new DataColumn("POBANKA", typeof(string), "", MappingType.Element);
                this.columnPOBANKA.AllowDBNull = true;
                this.columnPOBANKA.Caption = "Poziv na broj odobrenja banke";
                this.columnPOBANKA.MaxLength = 0x16;
                this.columnPOBANKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOBANKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOBANKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOBANKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOBANKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOBANKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOBANKA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOBANKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOBANKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOBANKA.ExtendedProperties.Add("Description", "Poziv na broj odobrenja");
                this.columnPOBANKA.ExtendedProperties.Add("Length", "22");
                this.columnPOBANKA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOBANKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOBANKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOBANKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOBANKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOBANKA.ExtendedProperties.Add("Deklarit.InternalName", "POBANKA");
                this.Columns.Add(this.columnPOBANKA);
                this.columnMZBANKA = new DataColumn("MZBANKA", typeof(string), "", MappingType.Element);
                this.columnMZBANKA.AllowDBNull = true;
                this.columnMZBANKA.Caption = "Model zaduženja banke";
                this.columnMZBANKA.MaxLength = 2;
                this.columnMZBANKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMZBANKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZBANKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZBANKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZBANKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZBANKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZBANKA.ExtendedProperties.Add("IsKey", "false");
                this.columnMZBANKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMZBANKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZBANKA.ExtendedProperties.Add("Description", "Model zaduženja");
                this.columnMZBANKA.ExtendedProperties.Add("Length", "2");
                this.columnMZBANKA.ExtendedProperties.Add("Decimals", "0");
                this.columnMZBANKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZBANKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMZBANKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZBANKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZBANKA.ExtendedProperties.Add("Deklarit.InternalName", "MZBANKA");
                this.Columns.Add(this.columnMZBANKA);
                this.columnPZBANKA = new DataColumn("PZBANKA", typeof(string), "", MappingType.Element);
                this.columnPZBANKA.AllowDBNull = true;
                this.columnPZBANKA.Caption = "Poziv na broj zaduženja banke";
                this.columnPZBANKA.MaxLength = 0x16;
                this.columnPZBANKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPZBANKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZBANKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZBANKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZBANKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZBANKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZBANKA.ExtendedProperties.Add("IsKey", "false");
                this.columnPZBANKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPZBANKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZBANKA.ExtendedProperties.Add("Description", "Poziv na broj zaduženja");
                this.columnPZBANKA.ExtendedProperties.Add("Length", "22");
                this.columnPZBANKA.ExtendedProperties.Add("Decimals", "0");
                this.columnPZBANKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZBANKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPZBANKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZBANKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZBANKA.ExtendedProperties.Add("Deklarit.InternalName", "PZBANKA");
                this.Columns.Add(this.columnPZBANKA);
                this.columnSIFRAOPISPLACANJABANKE = new DataColumn("SIFRAOPISPLACANJABANKE", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISPLACANJABANKE.AllowDBNull = false;
                this.columnSIFRAOPISPLACANJABANKE.Caption = "Šifra opisa plaćanja banke";
                this.columnSIFRAOPISPLACANJABANKE.MaxLength = 2;
                this.columnSIFRAOPISPLACANJABANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("Description", "Šifra opisa plaćanja");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISPLACANJABANKE");
                this.Columns.Add(this.columnSIFRAOPISPLACANJABANKE);
                this.columnOPISPLACANJABANKE = new DataColumn("OPISPLACANJABANKE", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJABANKE.AllowDBNull = false;
                this.columnOPISPLACANJABANKE.Caption = "Opis placanja banke";
                this.columnOPISPLACANJABANKE.MaxLength = 0x24;
                this.columnOPISPLACANJABANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("Description", "Opis plaćanja");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJABANKE.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJABANKE");
                this.Columns.Add(this.columnOPISPLACANJABANKE);
                this.columnVBDIBANKE = new DataColumn("VBDIBANKE", typeof(string), "", MappingType.Element);
                this.columnVBDIBANKE.AllowDBNull = false;
                this.columnVBDIBANKE.Caption = "VBDI žiro računa banke";
                this.columnVBDIBANKE.MaxLength = 7;
                this.columnVBDIBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIBANKE.ExtendedProperties.Add("Description", "VBDI");
                this.columnVBDIBANKE.ExtendedProperties.Add("Length", "7");
                this.columnVBDIBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIBANKE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.InternalName", "VBDIBANKE");
                this.Columns.Add(this.columnVBDIBANKE);
                this.columnZRNBANKE = new DataColumn("ZRNBANKE", typeof(string), "", MappingType.Element);
                this.columnZRNBANKE.AllowDBNull = false;
                this.columnZRNBANKE.Caption = "Broj žiro računa banke";
                this.columnZRNBANKE.MaxLength = 10;
                this.columnZRNBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNBANKE.ExtendedProperties.Add("Description", "ŽRN");
                this.columnZRNBANKE.ExtendedProperties.Add("Length", "10");
                this.columnZRNBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNBANKE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.InternalName", "ZRNBANKE");
                this.Columns.Add(this.columnZRNBANKE);
                this.PrimaryKey = new DataColumn[] { this.columnIDBANKE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "BANKE");
                this.ExtendedProperties.Add("Description", "Banke");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDBANKE = this.Columns["IDBANKE"];
                this.columnNAZIVBANKE1 = this.Columns["NAZIVBANKE1"];
                this.columnNAZIVBANKE2 = this.Columns["NAZIVBANKE2"];
                this.columnNAZIVBANKE3 = this.Columns["NAZIVBANKE3"];
                this.columnMOBANKA = this.Columns["MOBANKA"];
                this.columnPOBANKA = this.Columns["POBANKA"];
                this.columnMZBANKA = this.Columns["MZBANKA"];
                this.columnPZBANKA = this.Columns["PZBANKA"];
                this.columnSIFRAOPISPLACANJABANKE = this.Columns["SIFRAOPISPLACANJABANKE"];
                this.columnOPISPLACANJABANKE = this.Columns["OPISPLACANJABANKE"];
                this.columnVBDIBANKE = this.Columns["VBDIBANKE"];
                this.columnZRNBANKE = this.Columns["ZRNBANKE"];
            }

            public BANKEDataSet.BANKERow NewBANKERow()
            {
                return (BANKEDataSet.BANKERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new BANKEDataSet.BANKERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.BANKERowChanged != null)
                {
                    BANKEDataSet.BANKERowChangeEventHandler bANKERowChangedEvent = this.BANKERowChanged;
                    if (bANKERowChangedEvent != null)
                    {
                        bANKERowChangedEvent(this, new BANKEDataSet.BANKERowChangeEvent((BANKEDataSet.BANKERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.BANKERowChanging != null)
                {
                    BANKEDataSet.BANKERowChangeEventHandler bANKERowChangingEvent = this.BANKERowChanging;
                    if (bANKERowChangingEvent != null)
                    {
                        bANKERowChangingEvent(this, new BANKEDataSet.BANKERowChangeEvent((BANKEDataSet.BANKERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.BANKERowDeleted != null)
                {
                    BANKEDataSet.BANKERowChangeEventHandler bANKERowDeletedEvent = this.BANKERowDeleted;
                    if (bANKERowDeletedEvent != null)
                    {
                        bANKERowDeletedEvent(this, new BANKEDataSet.BANKERowChangeEvent((BANKEDataSet.BANKERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.BANKERowDeleting != null)
                {
                    BANKEDataSet.BANKERowChangeEventHandler bANKERowDeletingEvent = this.BANKERowDeleting;
                    if (bANKERowDeletingEvent != null)
                    {
                        bANKERowDeletingEvent(this, new BANKEDataSet.BANKERowChangeEvent((BANKEDataSet.BANKERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveBANKERow(BANKEDataSet.BANKERow row)
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

            public DataColumn IDBANKEColumn
            {
                get
                {
                    return this.columnIDBANKE;
                }
            }

            public BANKEDataSet.BANKERow this[int index]
            {
                get
                {
                    return (BANKEDataSet.BANKERow) this.Rows[index];
                }
            }

            public DataColumn MOBANKAColumn
            {
                get
                {
                    return this.columnMOBANKA;
                }
            }

            public DataColumn MZBANKAColumn
            {
                get
                {
                    return this.columnMZBANKA;
                }
            }

            public DataColumn NAZIVBANKE1Column
            {
                get
                {
                    return this.columnNAZIVBANKE1;
                }
            }

            public DataColumn NAZIVBANKE2Column
            {
                get
                {
                    return this.columnNAZIVBANKE2;
                }
            }

            public DataColumn NAZIVBANKE3Column
            {
                get
                {
                    return this.columnNAZIVBANKE3;
                }
            }

            public DataColumn OPISPLACANJABANKEColumn
            {
                get
                {
                    return this.columnOPISPLACANJABANKE;
                }
            }

            public DataColumn POBANKAColumn
            {
                get
                {
                    return this.columnPOBANKA;
                }
            }

            public DataColumn PZBANKAColumn
            {
                get
                {
                    return this.columnPZBANKA;
                }
            }

            public DataColumn SIFRAOPISPLACANJABANKEColumn
            {
                get
                {
                    return this.columnSIFRAOPISPLACANJABANKE;
                }
            }

            public DataColumn VBDIBANKEColumn
            {
                get
                {
                    return this.columnVBDIBANKE;
                }
            }

            public DataColumn ZRNBANKEColumn
            {
                get
                {
                    return this.columnZRNBANKE;
                }
            }
        }

        public class BANKERow : DataRow
        {
            private BANKEDataSet.BANKEDataTable tableBANKE;

            internal BANKERow(DataRowBuilder rb) : base(rb)
            {
                this.tableBANKE = (BANKEDataSet.BANKEDataTable) this.Table;
            }

            public bool IsIDBANKENull()
            {
                return this.IsNull(this.tableBANKE.IDBANKEColumn);
            }

            public bool IsMOBANKANull()
            {
                return this.IsNull(this.tableBANKE.MOBANKAColumn);
            }

            public bool IsMZBANKANull()
            {
                return this.IsNull(this.tableBANKE.MZBANKAColumn);
            }

            public bool IsNAZIVBANKE1Null()
            {
                return this.IsNull(this.tableBANKE.NAZIVBANKE1Column);
            }

            public bool IsNAZIVBANKE2Null()
            {
                return this.IsNull(this.tableBANKE.NAZIVBANKE2Column);
            }

            public bool IsNAZIVBANKE3Null()
            {
                return this.IsNull(this.tableBANKE.NAZIVBANKE3Column);
            }

            public bool IsOPISPLACANJABANKENull()
            {
                return this.IsNull(this.tableBANKE.OPISPLACANJABANKEColumn);
            }

            public bool IsPOBANKANull()
            {
                return this.IsNull(this.tableBANKE.POBANKAColumn);
            }

            public bool IsPZBANKANull()
            {
                return this.IsNull(this.tableBANKE.PZBANKAColumn);
            }

            public bool IsSIFRAOPISPLACANJABANKENull()
            {
                return this.IsNull(this.tableBANKE.SIFRAOPISPLACANJABANKEColumn);
            }

            public bool IsVBDIBANKENull()
            {
                return this.IsNull(this.tableBANKE.VBDIBANKEColumn);
            }

            public bool IsZRNBANKENull()
            {
                return this.IsNull(this.tableBANKE.ZRNBANKEColumn);
            }

            public void SetMOBANKANull()
            {
                this[this.tableBANKE.MOBANKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZBANKANull()
            {
                this[this.tableBANKE.MZBANKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE1Null()
            {
                this[this.tableBANKE.NAZIVBANKE1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE2Null()
            {
                this[this.tableBANKE.NAZIVBANKE2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE3Null()
            {
                this[this.tableBANKE.NAZIVBANKE3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJABANKENull()
            {
                this[this.tableBANKE.OPISPLACANJABANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOBANKANull()
            {
                this[this.tableBANKE.POBANKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZBANKANull()
            {
                this[this.tableBANKE.PZBANKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISPLACANJABANKENull()
            {
                this[this.tableBANKE.SIFRAOPISPLACANJABANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIBANKENull()
            {
                this[this.tableBANKE.VBDIBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNBANKENull()
            {
                this[this.tableBANKE.ZRNBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDBANKE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableBANKE.IDBANKEColumn]);
                }
                set
                {
                    this[this.tableBANKE.IDBANKEColumn] = value;
                }
            }

            public string MOBANKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBANKE.MOBANKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value MOBANKA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableBANKE.MOBANKAColumn] = value;
                }
            }

            public string MZBANKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBANKE.MZBANKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value MZBANKA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableBANKE.MZBANKAColumn] = value;
                }
            }

            public string NAZIVBANKE1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBANKE.NAZIVBANKE1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVBANKE1 because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableBANKE.NAZIVBANKE1Column] = value;
                }
            }

            public string NAZIVBANKE2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBANKE.NAZIVBANKE2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVBANKE2 because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableBANKE.NAZIVBANKE2Column] = value;
                }
            }

            public string NAZIVBANKE3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBANKE.NAZIVBANKE3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableBANKE.NAZIVBANKE3Column] = value;
                }
            }

            public string OPISPLACANJABANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBANKE.OPISPLACANJABANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableBANKE.OPISPLACANJABANKEColumn] = value;
                }
            }

            public string POBANKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBANKE.POBANKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableBANKE.POBANKAColumn] = value;
                }
            }

            public string PZBANKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBANKE.PZBANKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableBANKE.PZBANKAColumn] = value;
                }
            }

            public string SIFRAOPISPLACANJABANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBANKE.SIFRAOPISPLACANJABANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableBANKE.SIFRAOPISPLACANJABANKEColumn] = value;
                }
            }

            public string VBDIBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBANKE.VBDIBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableBANKE.VBDIBANKEColumn] = value;
                }
            }

            public string ZRNBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBANKE.ZRNBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableBANKE.ZRNBANKEColumn] = value;
                }
            }
        }

        public class BANKERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private BANKEDataSet.BANKERow eventRow;

            public BANKERowChangeEvent(BANKEDataSet.BANKERow row, DataRowAction action)
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

            public BANKEDataSet.BANKERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void BANKERowChangeEventHandler(object sender, BANKEDataSet.BANKERowChangeEvent e);
    }
}

