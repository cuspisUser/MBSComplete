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
    public class SKUPPOREZAIDOPRINOSADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private SKUPPOREZAIDOPRINOSADataTable tableSKUPPOREZAIDOPRINOSA;
        private SKUPPOREZAIDOPRINOSA1DataTable tableSKUPPOREZAIDOPRINOSA1;
        private SKUPPOREZAIDOPRINOSA2DataTable tableSKUPPOREZAIDOPRINOSA2;

        public SKUPPOREZAIDOPRINOSADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected SKUPPOREZAIDOPRINOSADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["SKUPPOREZAIDOPRINOSA2"] != null)
                    {
                        this.Tables.Add(new SKUPPOREZAIDOPRINOSA2DataTable(dataSet.Tables["SKUPPOREZAIDOPRINOSA2"]));
                    }
                    if (dataSet.Tables["SKUPPOREZAIDOPRINOSA1"] != null)
                    {
                        this.Tables.Add(new SKUPPOREZAIDOPRINOSA1DataTable(dataSet.Tables["SKUPPOREZAIDOPRINOSA1"]));
                    }
                    if (dataSet.Tables["SKUPPOREZAIDOPRINOSA"] != null)
                    {
                        this.Tables.Add(new SKUPPOREZAIDOPRINOSADataTable(dataSet.Tables["SKUPPOREZAIDOPRINOSA"]));
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
            SKUPPOREZAIDOPRINOSADataSet set = (SKUPPOREZAIDOPRINOSADataSet) base.Clone();
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
            SKUPPOREZAIDOPRINOSADataSet set = new SKUPPOREZAIDOPRINOSADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "SKUPPOREZAIDOPRINOSADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1021");
            this.ExtendedProperties.Add("DataSetName", "SKUPPOREZAIDOPRINOSADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ISKUPPOREZAIDOPRINOSADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "SKUPPOREZAIDOPRINOSA");
            this.ExtendedProperties.Add("ObjectDescription", "Skupine poreza i doprinosa");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVSKUPPOREZAIDOPRINOSA");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "SKUPPOREZAIDOPRINOSADataSet";
            this.Namespace = "http://www.tempuri.org/SKUPPOREZAIDOPRINOSA";
            this.tableSKUPPOREZAIDOPRINOSA2 = new SKUPPOREZAIDOPRINOSA2DataTable();
            this.Tables.Add(this.tableSKUPPOREZAIDOPRINOSA2);
            this.tableSKUPPOREZAIDOPRINOSA1 = new SKUPPOREZAIDOPRINOSA1DataTable();
            this.Tables.Add(this.tableSKUPPOREZAIDOPRINOSA1);
            this.tableSKUPPOREZAIDOPRINOSA = new SKUPPOREZAIDOPRINOSADataTable();
            this.Tables.Add(this.tableSKUPPOREZAIDOPRINOSA);
            this.Relations.Add("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA2", new DataColumn[] { this.Tables["SKUPPOREZAIDOPRINOSA"].Columns["IDSKUPPOREZAIDOPRINOSA"] }, new DataColumn[] { this.Tables["SKUPPOREZAIDOPRINOSA2"].Columns["IDSKUPPOREZAIDOPRINOSA"] });
            this.Relations["SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA2"].Nested = true;
            this.Relations.Add("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA1", new DataColumn[] { this.Tables["SKUPPOREZAIDOPRINOSA"].Columns["IDSKUPPOREZAIDOPRINOSA"] }, new DataColumn[] { this.Tables["SKUPPOREZAIDOPRINOSA1"].Columns["IDSKUPPOREZAIDOPRINOSA"] });
            this.Relations["SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA1"].Nested = true;
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
            this.tableSKUPPOREZAIDOPRINOSA2 = (SKUPPOREZAIDOPRINOSA2DataTable) this.Tables["SKUPPOREZAIDOPRINOSA2"];
            this.tableSKUPPOREZAIDOPRINOSA1 = (SKUPPOREZAIDOPRINOSA1DataTable) this.Tables["SKUPPOREZAIDOPRINOSA1"];
            this.tableSKUPPOREZAIDOPRINOSA = (SKUPPOREZAIDOPRINOSADataTable) this.Tables["SKUPPOREZAIDOPRINOSA"];
            if (initTable)
            {
                if (this.tableSKUPPOREZAIDOPRINOSA2 != null)
                {
                    this.tableSKUPPOREZAIDOPRINOSA2.InitVars();
                }
                if (this.tableSKUPPOREZAIDOPRINOSA1 != null)
                {
                    this.tableSKUPPOREZAIDOPRINOSA1.InitVars();
                }
                if (this.tableSKUPPOREZAIDOPRINOSA != null)
                {
                    this.tableSKUPPOREZAIDOPRINOSA.InitVars();
                }
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["SKUPPOREZAIDOPRINOSA2"] != null)
                {
                    this.Tables.Add(new SKUPPOREZAIDOPRINOSA2DataTable(dataSet.Tables["SKUPPOREZAIDOPRINOSA2"]));
                }
                if (dataSet.Tables["SKUPPOREZAIDOPRINOSA1"] != null)
                {
                    this.Tables.Add(new SKUPPOREZAIDOPRINOSA1DataTable(dataSet.Tables["SKUPPOREZAIDOPRINOSA1"]));
                }
                if (dataSet.Tables["SKUPPOREZAIDOPRINOSA"] != null)
                {
                    this.Tables.Add(new SKUPPOREZAIDOPRINOSADataTable(dataSet.Tables["SKUPPOREZAIDOPRINOSA"]));
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

        private bool ShouldSerializeSKUPPOREZAIDOPRINOSA()
        {
            return false;
        }

        private bool ShouldSerializeSKUPPOREZAIDOPRINOSA1()
        {
            return false;
        }

        private bool ShouldSerializeSKUPPOREZAIDOPRINOSA2()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SKUPPOREZAIDOPRINOSADataTable SKUPPOREZAIDOPRINOSA
        {
            get
            {
                return this.tableSKUPPOREZAIDOPRINOSA;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SKUPPOREZAIDOPRINOSA1DataTable SKUPPOREZAIDOPRINOSA1
        {
            get
            {
                return this.tableSKUPPOREZAIDOPRINOSA1;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SKUPPOREZAIDOPRINOSA2DataTable SKUPPOREZAIDOPRINOSA2
        {
            get
            {
                return this.tableSKUPPOREZAIDOPRINOSA2;
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
        public class SKUPPOREZAIDOPRINOSA1DataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDPOREZ;
            private DataColumn columnIDSKUPPOREZAIDOPRINOSA;
            private DataColumn columnMOPOREZ;
            private DataColumn columnMZPOREZ;
            private DataColumn columnNAZIVPOREZ;
            private DataColumn columnOPISPLACANJAPOREZ;
            private DataColumn columnPOPOREZ;
            private DataColumn columnPOREZMJESECNO;
            private DataColumn columnPRIMATELJPOREZ1;
            private DataColumn columnPRIMATELJPOREZ2;
            private DataColumn columnPZPOREZ;
            private DataColumn columnSIFRAOPISAPLACANJAPOREZ;
            private DataColumn columnSTOPAPOREZA;

            public event SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1RowChangeEventHandler SKUPPOREZAIDOPRINOSA1RowChanged;

            public event SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1RowChangeEventHandler SKUPPOREZAIDOPRINOSA1RowChanging;

            public event SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1RowChangeEventHandler SKUPPOREZAIDOPRINOSA1RowDeleted;

            public event SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1RowChangeEventHandler SKUPPOREZAIDOPRINOSA1RowDeleting;

            public SKUPPOREZAIDOPRINOSA1DataTable()
            {
                this.TableName = "SKUPPOREZAIDOPRINOSA1";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SKUPPOREZAIDOPRINOSA1DataTable(DataTable table) : base(table.TableName)
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

            protected SKUPPOREZAIDOPRINOSA1DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSKUPPOREZAIDOPRINOSA1Row(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row row)
            {
                this.Rows.Add(row);
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row AddSKUPPOREZAIDOPRINOSA1Row(int iDSKUPPOREZAIDOPRINOSA, int iDPOREZ)
            {
                SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row row = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row) this.NewRow();
                row["IDSKUPPOREZAIDOPRINOSA"] = iDSKUPPOREZAIDOPRINOSA;
                row["IDPOREZ"] = iDPOREZ;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1DataTable table = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row FindByIDSKUPPOREZAIDOPRINOSAIDPOREZ(int iDSKUPPOREZAIDOPRINOSA, int iDPOREZ)
            {
                return (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row) this.Rows.Find(new object[] { iDSKUPPOREZAIDOPRINOSA, iDPOREZ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SKUPPOREZAIDOPRINOSADataSet set = new SKUPPOREZAIDOPRINOSADataSet();
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
                this.columnIDSKUPPOREZAIDOPRINOSA = new DataColumn("IDSKUPPOREZAIDOPRINOSA", typeof(int), "", MappingType.Element);
                this.columnIDSKUPPOREZAIDOPRINOSA.AllowDBNull = false;
                this.columnIDSKUPPOREZAIDOPRINOSA.Caption = "Šifra skupine poreza i doprinosa";
                this.columnIDSKUPPOREZAIDOPRINOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Description", "Šifra skupine poreza i doprinosa");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Length", "5");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.InternalName", "IDSKUPPOREZAIDOPRINOSA");
                this.Columns.Add(this.columnIDSKUPPOREZAIDOPRINOSA);
                this.columnIDPOREZ = new DataColumn("IDPOREZ", typeof(int), "", MappingType.Element);
                this.columnIDPOREZ.AllowDBNull = false;
                this.columnIDPOREZ.Caption = "Šifra poreza";
                this.columnIDPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPOREZ.ExtendedProperties.Add("IsKey", "true");
                this.columnIDPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPOREZ.ExtendedProperties.Add("Description", "Šifra poreza");
                this.columnIDPOREZ.ExtendedProperties.Add("Length", "5");
                this.columnIDPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "IDPOREZ");
                this.Columns.Add(this.columnIDPOREZ);
                this.columnNAZIVPOREZ = new DataColumn("NAZIVPOREZ", typeof(string), "", MappingType.Element);
                this.columnNAZIVPOREZ.AllowDBNull = true;
                this.columnNAZIVPOREZ.Caption = "Naziv poreza";
                this.columnNAZIVPOREZ.MaxLength = 50;
                this.columnNAZIVPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Description", "Naziv poreza");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPOREZ");
                this.Columns.Add(this.columnNAZIVPOREZ);
                this.columnPOREZMJESECNO = new DataColumn("POREZMJESECNO", typeof(decimal), "", MappingType.Element);
                this.columnPOREZMJESECNO.AllowDBNull = true;
                this.columnPOREZMJESECNO.Caption = "Maks. mjesečni iznos osnovice";
                this.columnPOREZMJESECNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Description", "Maks. mjesečni iznos osnovice");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Length", "12");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.InternalName", "POREZMJESECNO");
                this.Columns.Add(this.columnPOREZMJESECNO);
                this.columnSTOPAPOREZA = new DataColumn("STOPAPOREZA", typeof(decimal), "", MappingType.Element);
                this.columnSTOPAPOREZA.AllowDBNull = true;
                this.columnSTOPAPOREZA.Caption = "Stopa poreza";
                this.columnSTOPAPOREZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Description", "Stopa poreza");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Length", "4");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.InternalName", "STOPAPOREZA");
                this.Columns.Add(this.columnSTOPAPOREZA);
                this.columnMOPOREZ = new DataColumn("MOPOREZ", typeof(string), "", MappingType.Element);
                this.columnMOPOREZ.AllowDBNull = true;
                this.columnMOPOREZ.Caption = "Model odobrenja poreza";
                this.columnMOPOREZ.MaxLength = 2;
                this.columnMOPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnMOPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMOPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOPOREZ.ExtendedProperties.Add("Description", "Model odobrenja poreza");
                this.columnMOPOREZ.ExtendedProperties.Add("Length", "2");
                this.columnMOPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnMOPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "MOPOREZ");
                this.Columns.Add(this.columnMOPOREZ);
                this.columnPOPOREZ = new DataColumn("POPOREZ", typeof(string), "", MappingType.Element);
                this.columnPOPOREZ.AllowDBNull = true;
                this.columnPOPOREZ.Caption = "Poziv na broj odobrenja poreza";
                this.columnPOPOREZ.MaxLength = 0x16;
                this.columnPOPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPOPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOPOREZ.ExtendedProperties.Add("Description", "Poziv na broj odobrenja poreza");
                this.columnPOPOREZ.ExtendedProperties.Add("Length", "22");
                this.columnPOPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnPOPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "POPOREZ");
                this.Columns.Add(this.columnPOPOREZ);
                this.columnMZPOREZ = new DataColumn("MZPOREZ", typeof(string), "", MappingType.Element);
                this.columnMZPOREZ.AllowDBNull = true;
                this.columnMZPOREZ.Caption = "Model zaduženja poreza";
                this.columnMZPOREZ.MaxLength = 2;
                this.columnMZPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnMZPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMZPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZPOREZ.ExtendedProperties.Add("Description", "Model zaduženja poreza");
                this.columnMZPOREZ.ExtendedProperties.Add("Length", "2");
                this.columnMZPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnMZPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "MZPOREZ");
                this.Columns.Add(this.columnMZPOREZ);
                this.columnPZPOREZ = new DataColumn("PZPOREZ", typeof(string), "", MappingType.Element);
                this.columnPZPOREZ.AllowDBNull = true;
                this.columnPZPOREZ.Caption = "Poziv na broj zaduženja poreza";
                this.columnPZPOREZ.MaxLength = 0x16;
                this.columnPZPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPZPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPZPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZPOREZ.ExtendedProperties.Add("Description", "Poziv na broj zaduženja poreza");
                this.columnPZPOREZ.ExtendedProperties.Add("Length", "22");
                this.columnPZPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnPZPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "PZPOREZ");
                this.Columns.Add(this.columnPZPOREZ);
                this.columnPRIMATELJPOREZ1 = new DataColumn("PRIMATELJPOREZ1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJPOREZ1.AllowDBNull = true;
                this.columnPRIMATELJPOREZ1.Caption = "Primatelj poreza (1)";
                this.columnPRIMATELJPOREZ1.MaxLength = 20;
                this.columnPRIMATELJPOREZ1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Description", "Primatelj poreza (1)");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJPOREZ1");
                this.Columns.Add(this.columnPRIMATELJPOREZ1);
                this.columnPRIMATELJPOREZ2 = new DataColumn("PRIMATELJPOREZ2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJPOREZ2.AllowDBNull = true;
                this.columnPRIMATELJPOREZ2.Caption = "Primatelj poreza (2)";
                this.columnPRIMATELJPOREZ2.MaxLength = 20;
                this.columnPRIMATELJPOREZ2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Description", "Primatelj poreza (2)");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJPOREZ2");
                this.Columns.Add(this.columnPRIMATELJPOREZ2);
                this.columnSIFRAOPISAPLACANJAPOREZ = new DataColumn("SIFRAOPISAPLACANJAPOREZ", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAPOREZ.AllowDBNull = true;
                this.columnSIFRAOPISAPLACANJAPOREZ.Caption = "Šifra opisa plaćanja poreza";
                this.columnSIFRAOPISAPLACANJAPOREZ.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Description", "Šifra opisa plaćanja poreza");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAPOREZ");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAPOREZ);
                this.columnOPISPLACANJAPOREZ = new DataColumn("OPISPLACANJAPOREZ", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAPOREZ.AllowDBNull = true;
                this.columnOPISPLACANJAPOREZ.Caption = "Opis plaćanja poreza";
                this.columnOPISPLACANJAPOREZ.MaxLength = 0x24;
                this.columnOPISPLACANJAPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Description", "Opis plaćanja poreza");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAPOREZ");
                this.Columns.Add(this.columnOPISPLACANJAPOREZ);
                this.PrimaryKey = new DataColumn[] { this.columnIDSKUPPOREZAIDOPRINOSA, this.columnIDPOREZ };
                this.ExtendedProperties.Add("ParentLvl", "SKUPPOREZAIDOPRINOSA");
                this.ExtendedProperties.Add("LevelName", "SKUPPOREZAIDOPRINOSALevel1");
                this.ExtendedProperties.Add("Description", "Porezi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDSKUPPOREZAIDOPRINOSA = this.Columns["IDSKUPPOREZAIDOPRINOSA"];
                this.columnIDPOREZ = this.Columns["IDPOREZ"];
                this.columnNAZIVPOREZ = this.Columns["NAZIVPOREZ"];
                this.columnPOREZMJESECNO = this.Columns["POREZMJESECNO"];
                this.columnSTOPAPOREZA = this.Columns["STOPAPOREZA"];
                this.columnMOPOREZ = this.Columns["MOPOREZ"];
                this.columnPOPOREZ = this.Columns["POPOREZ"];
                this.columnMZPOREZ = this.Columns["MZPOREZ"];
                this.columnPZPOREZ = this.Columns["PZPOREZ"];
                this.columnPRIMATELJPOREZ1 = this.Columns["PRIMATELJPOREZ1"];
                this.columnPRIMATELJPOREZ2 = this.Columns["PRIMATELJPOREZ2"];
                this.columnSIFRAOPISAPLACANJAPOREZ = this.Columns["SIFRAOPISAPLACANJAPOREZ"];
                this.columnOPISPLACANJAPOREZ = this.Columns["OPISPLACANJAPOREZ"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row(builder);
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row NewSKUPPOREZAIDOPRINOSA1Row()
            {
                return (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SKUPPOREZAIDOPRINOSA1RowChanged != null)
                {
                    SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1RowChangeEventHandler handler = this.SKUPPOREZAIDOPRINOSA1RowChanged;
                    if (handler != null)
                    {
                        handler(this, new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1RowChangeEvent((SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SKUPPOREZAIDOPRINOSA1RowChanging != null)
                {
                    SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1RowChangeEventHandler handler = this.SKUPPOREZAIDOPRINOSA1RowChanging;
                    if (handler != null)
                    {
                        handler(this, new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1RowChangeEvent((SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA1", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.SKUPPOREZAIDOPRINOSA1RowDeleted != null)
                {
                    SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1RowChangeEventHandler handler = this.SKUPPOREZAIDOPRINOSA1RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1RowChangeEvent((SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SKUPPOREZAIDOPRINOSA1RowDeleting != null)
                {
                    SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1RowChangeEventHandler handler = this.SKUPPOREZAIDOPRINOSA1RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1RowChangeEvent((SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSKUPPOREZAIDOPRINOSA1Row(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row row)
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

            public DataColumn IDPOREZColumn
            {
                get
                {
                    return this.columnIDPOREZ;
                }
            }

            public DataColumn IDSKUPPOREZAIDOPRINOSAColumn
            {
                get
                {
                    return this.columnIDSKUPPOREZAIDOPRINOSA;
                }
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row this[int index]
            {
                get
                {
                    return (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row) this.Rows[index];
                }
            }

            public DataColumn MOPOREZColumn
            {
                get
                {
                    return this.columnMOPOREZ;
                }
            }

            public DataColumn MZPOREZColumn
            {
                get
                {
                    return this.columnMZPOREZ;
                }
            }

            public DataColumn NAZIVPOREZColumn
            {
                get
                {
                    return this.columnNAZIVPOREZ;
                }
            }

            public DataColumn OPISPLACANJAPOREZColumn
            {
                get
                {
                    return this.columnOPISPLACANJAPOREZ;
                }
            }

            public DataColumn POPOREZColumn
            {
                get
                {
                    return this.columnPOPOREZ;
                }
            }

            public DataColumn POREZMJESECNOColumn
            {
                get
                {
                    return this.columnPOREZMJESECNO;
                }
            }

            public DataColumn PRIMATELJPOREZ1Column
            {
                get
                {
                    return this.columnPRIMATELJPOREZ1;
                }
            }

            public DataColumn PRIMATELJPOREZ2Column
            {
                get
                {
                    return this.columnPRIMATELJPOREZ2;
                }
            }

            public DataColumn PZPOREZColumn
            {
                get
                {
                    return this.columnPZPOREZ;
                }
            }

            public DataColumn SIFRAOPISAPLACANJAPOREZColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJAPOREZ;
                }
            }

            public DataColumn STOPAPOREZAColumn
            {
                get
                {
                    return this.columnSTOPAPOREZA;
                }
            }
        }

        public class SKUPPOREZAIDOPRINOSA1Row : DataRow
        {
            private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1DataTable tableSKUPPOREZAIDOPRINOSA1;

            internal SKUPPOREZAIDOPRINOSA1Row(DataRowBuilder rb) : base(rb)
            {
                this.tableSKUPPOREZAIDOPRINOSA1 = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1DataTable) this.Table;
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow GetSKUPPOREZAIDOPRINOSARow()
            {
                return (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow) this.GetParentRow("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA1");
            }

            public bool IsIDPOREZNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA1.IDPOREZColumn);
            }

            public bool IsIDSKUPPOREZAIDOPRINOSANull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA1.IDSKUPPOREZAIDOPRINOSAColumn);
            }

            public bool IsMOPOREZNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA1.MOPOREZColumn);
            }

            public bool IsMZPOREZNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA1.MZPOREZColumn);
            }

            public bool IsNAZIVPOREZNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA1.NAZIVPOREZColumn);
            }

            public bool IsOPISPLACANJAPOREZNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA1.OPISPLACANJAPOREZColumn);
            }

            public bool IsPOPOREZNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA1.POPOREZColumn);
            }

            public bool IsPOREZMJESECNONull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA1.POREZMJESECNOColumn);
            }

            public bool IsPRIMATELJPOREZ1Null()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA1.PRIMATELJPOREZ1Column);
            }

            public bool IsPRIMATELJPOREZ2Null()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA1.PRIMATELJPOREZ2Column);
            }

            public bool IsPZPOREZNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA1.PZPOREZColumn);
            }

            public bool IsSIFRAOPISAPLACANJAPOREZNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA1.SIFRAOPISAPLACANJAPOREZColumn);
            }

            public bool IsSTOPAPOREZANull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA1.STOPAPOREZAColumn);
            }

            public void SetMOPOREZNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA1.MOPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZPOREZNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA1.MZPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPOREZNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA1.NAZIVPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAPOREZNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA1.OPISPLACANJAPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOPOREZNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA1.POPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZMJESECNONull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA1.POREZMJESECNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJPOREZ1Null()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA1.PRIMATELJPOREZ1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJPOREZ2Null()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA1.PRIMATELJPOREZ2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZPOREZNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA1.PZPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAPOREZNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA1.SIFRAOPISAPLACANJAPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAPOREZANull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA1.STOPAPOREZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDPOREZ
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSKUPPOREZAIDOPRINOSA1.IDPOREZColumn]);
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA1.IDPOREZColumn] = value;
                }
            }

            public int IDSKUPPOREZAIDOPRINOSA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSKUPPOREZAIDOPRINOSA1.IDSKUPPOREZAIDOPRINOSAColumn]);
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA1.IDSKUPPOREZAIDOPRINOSAColumn] = value;
                }
            }

            public string MOPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA1.MOPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA1.MOPOREZColumn] = value;
                }
            }

            public string MZPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA1.MZPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA1.MZPOREZColumn] = value;
                }
            }

            public string NAZIVPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA1.NAZIVPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA1.NAZIVPOREZColumn] = value;
                }
            }

            public string OPISPLACANJAPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA1.OPISPLACANJAPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA1.OPISPLACANJAPOREZColumn] = value;
                }
            }

            public string POPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA1.POPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA1.POPOREZColumn] = value;
                }
            }

            public decimal POREZMJESECNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSKUPPOREZAIDOPRINOSA1.POREZMJESECNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA1.POREZMJESECNOColumn] = value;
                }
            }

            public string PRIMATELJPOREZ1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA1.PRIMATELJPOREZ1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA1.PRIMATELJPOREZ1Column] = value;
                }
            }

            public string PRIMATELJPOREZ2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA1.PRIMATELJPOREZ2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA1.PRIMATELJPOREZ2Column] = value;
                }
            }

            public string PZPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA1.PZPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA1.PZPOREZColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA1.SIFRAOPISAPLACANJAPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA1.SIFRAOPISAPLACANJAPOREZColumn] = value;
                }
            }

            public decimal STOPAPOREZA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSKUPPOREZAIDOPRINOSA1.STOPAPOREZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA1.STOPAPOREZAColumn] = value;
                }
            }
        }

        public class SKUPPOREZAIDOPRINOSA1RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row eventRow;

            public SKUPPOREZAIDOPRINOSA1RowChangeEvent(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row row, DataRowAction action)
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

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SKUPPOREZAIDOPRINOSA1RowChangeEventHandler(object sender, SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1RowChangeEvent e);

        [Serializable]
        public class SKUPPOREZAIDOPRINOSA2DataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDDOPRINOS;
            private DataColumn columnIDSKUPPOREZAIDOPRINOSA;
            private DataColumn columnIDVRSTADOPRINOS;
            private DataColumn columnMAXDOPRINOS;
            private DataColumn columnMINDOPRINOS;
            private DataColumn columnMODOPRINOS;
            private DataColumn columnMZDOPRINOS;
            private DataColumn columnNAZIVDOPRINOS;
            private DataColumn columnNAZIVVRSTADOPRINOS;
            private DataColumn columnOPISPLACANJADOPRINOS;
            private DataColumn columnPODOPRINOS;
            private DataColumn columnPRIMATELJDOPRINOS1;
            private DataColumn columnPRIMATELJDOPRINOS2;
            private DataColumn columnPZDOPRINOS;
            private DataColumn columnSIFRAOPISAPLACANJADOPRINOS;
            private DataColumn columnSTOPA;
            private DataColumn columnVBDIDOPRINOS;
            private DataColumn columnZRNDOPRINOS;

            public event SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2RowChangeEventHandler SKUPPOREZAIDOPRINOSA2RowChanged;

            public event SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2RowChangeEventHandler SKUPPOREZAIDOPRINOSA2RowChanging;

            public event SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2RowChangeEventHandler SKUPPOREZAIDOPRINOSA2RowDeleted;

            public event SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2RowChangeEventHandler SKUPPOREZAIDOPRINOSA2RowDeleting;

            public SKUPPOREZAIDOPRINOSA2DataTable()
            {
                this.TableName = "SKUPPOREZAIDOPRINOSA2";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SKUPPOREZAIDOPRINOSA2DataTable(DataTable table) : base(table.TableName)
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

            protected SKUPPOREZAIDOPRINOSA2DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSKUPPOREZAIDOPRINOSA2Row(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row row)
            {
                this.Rows.Add(row);
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row AddSKUPPOREZAIDOPRINOSA2Row(int iDSKUPPOREZAIDOPRINOSA, int iDDOPRINOS)
            {
                SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row row = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row) this.NewRow();
                row["IDSKUPPOREZAIDOPRINOSA"] = iDSKUPPOREZAIDOPRINOSA;
                row["IDDOPRINOS"] = iDDOPRINOS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2DataTable table = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row FindByIDSKUPPOREZAIDOPRINOSAIDDOPRINOS(int iDSKUPPOREZAIDOPRINOSA, int iDDOPRINOS)
            {
                return (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row) this.Rows.Find(new object[] { iDSKUPPOREZAIDOPRINOSA, iDDOPRINOS });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SKUPPOREZAIDOPRINOSADataSet set = new SKUPPOREZAIDOPRINOSADataSet();
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
                this.columnIDSKUPPOREZAIDOPRINOSA = new DataColumn("IDSKUPPOREZAIDOPRINOSA", typeof(int), "", MappingType.Element);
                this.columnIDSKUPPOREZAIDOPRINOSA.AllowDBNull = false;
                this.columnIDSKUPPOREZAIDOPRINOSA.Caption = "Šifra skupine poreza i doprinosa";
                this.columnIDSKUPPOREZAIDOPRINOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Description", "Šifra skupine poreza i doprinosa");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Length", "5");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.InternalName", "IDSKUPPOREZAIDOPRINOSA");
                this.Columns.Add(this.columnIDSKUPPOREZAIDOPRINOSA);
                this.columnIDDOPRINOS = new DataColumn("IDDOPRINOS", typeof(int), "", MappingType.Element);
                this.columnIDDOPRINOS.AllowDBNull = false;
                this.columnIDDOPRINOS.Caption = "Šifra doprinosa";
                this.columnIDDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDDOPRINOS.ExtendedProperties.Add("IsKey", "true");
                this.columnIDDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Description", "Šifra doprinosa");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Length", "8");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnIDDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "IDDOPRINOS");
                this.Columns.Add(this.columnIDDOPRINOS);
                this.columnNAZIVDOPRINOS = new DataColumn("NAZIVDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnNAZIVDOPRINOS.AllowDBNull = true;
                this.columnNAZIVDOPRINOS.Caption = "Naziv doprinosa";
                this.columnNAZIVDOPRINOS.MaxLength = 50;
                this.columnNAZIVDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Description", "Naziv doprinosa");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVDOPRINOS");
                this.Columns.Add(this.columnNAZIVDOPRINOS);
                this.columnIDVRSTADOPRINOS = new DataColumn("IDVRSTADOPRINOS", typeof(int), "", MappingType.Element);
                this.columnIDVRSTADOPRINOS.AllowDBNull = true;
                this.columnIDVRSTADOPRINOS.Caption = "Šifra vrste doprinosa";
                this.columnIDVRSTADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Description", "Šifra vrste doprinosa");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Length", "5");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "IDVRSTADOPRINOS");
                this.Columns.Add(this.columnIDVRSTADOPRINOS);
                this.columnNAZIVVRSTADOPRINOS = new DataColumn("NAZIVVRSTADOPRINOS", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTADOPRINOS.AllowDBNull = true;
                this.columnNAZIVVRSTADOPRINOS.Caption = "Naziv vrste doprinosa";
                this.columnNAZIVVRSTADOPRINOS.MaxLength = 50;
                this.columnNAZIVVRSTADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Description", "Naziv vrste doprinosa");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTADOPRINOS");
                this.Columns.Add(this.columnNAZIVVRSTADOPRINOS);
                this.columnMODOPRINOS = new DataColumn("MODOPRINOS", typeof(string), "", MappingType.Element);
                this.columnMODOPRINOS.AllowDBNull = true;
                this.columnMODOPRINOS.Caption = "Model odobrenja doprinosa";
                this.columnMODOPRINOS.MaxLength = 2;
                this.columnMODOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMODOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnMODOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMODOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMODOPRINOS.ExtendedProperties.Add("Description", "Model odobrenja doprinosa");
                this.columnMODOPRINOS.ExtendedProperties.Add("Length", "2");
                this.columnMODOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnMODOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "MODOPRINOS");
                this.Columns.Add(this.columnMODOPRINOS);
                this.columnPODOPRINOS = new DataColumn("PODOPRINOS", typeof(string), "", MappingType.Element);
                this.columnPODOPRINOS.AllowDBNull = true;
                this.columnPODOPRINOS.Caption = "Poziv odobrenja doprinosa";
                this.columnPODOPRINOS.MaxLength = 0x16;
                this.columnPODOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPODOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnPODOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPODOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPODOPRINOS.ExtendedProperties.Add("Description", "Poziv odobrenja doprinosa");
                this.columnPODOPRINOS.ExtendedProperties.Add("Length", "22");
                this.columnPODOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnPODOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "PODOPRINOS");
                this.Columns.Add(this.columnPODOPRINOS);
                this.columnMZDOPRINOS = new DataColumn("MZDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnMZDOPRINOS.AllowDBNull = true;
                this.columnMZDOPRINOS.Caption = "Model zaduženja doprinosa";
                this.columnMZDOPRINOS.MaxLength = 2;
                this.columnMZDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnMZDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMZDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Description", "Model zaduženja doprinosa");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Length", "2");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnMZDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "MZDOPRINOS");
                this.Columns.Add(this.columnMZDOPRINOS);
                this.columnPZDOPRINOS = new DataColumn("PZDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnPZDOPRINOS.AllowDBNull = true;
                this.columnPZDOPRINOS.Caption = "Poziv zaduženja doprinosa";
                this.columnPZDOPRINOS.MaxLength = 0x16;
                this.columnPZDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnPZDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPZDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Description", "Poziv zaduženja doprinosa");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Length", "22");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnPZDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "PZDOPRINOS");
                this.Columns.Add(this.columnPZDOPRINOS);
                this.columnPRIMATELJDOPRINOS1 = new DataColumn("PRIMATELJDOPRINOS1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJDOPRINOS1.AllowDBNull = true;
                this.columnPRIMATELJDOPRINOS1.Caption = "Primatelj doprinosa";
                this.columnPRIMATELJDOPRINOS1.MaxLength = 20;
                this.columnPRIMATELJDOPRINOS1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Description", "Primatelj doprinosa");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJDOPRINOS1");
                this.Columns.Add(this.columnPRIMATELJDOPRINOS1);
                this.columnPRIMATELJDOPRINOS2 = new DataColumn("PRIMATELJDOPRINOS2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJDOPRINOS2.AllowDBNull = true;
                this.columnPRIMATELJDOPRINOS2.Caption = "Primatelj doprinosa (2)";
                this.columnPRIMATELJDOPRINOS2.MaxLength = 20;
                this.columnPRIMATELJDOPRINOS2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Description", "Primatelj doprinosa (2)");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJDOPRINOS2");
                this.Columns.Add(this.columnPRIMATELJDOPRINOS2);
                this.columnSIFRAOPISAPLACANJADOPRINOS = new DataColumn("SIFRAOPISAPLACANJADOPRINOS", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJADOPRINOS.AllowDBNull = true;
                this.columnSIFRAOPISAPLACANJADOPRINOS.Caption = "Šifra opisa plaćanja doprinosa";
                this.columnSIFRAOPISAPLACANJADOPRINOS.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Description", "Šifra opisa plaćanja doprinosa");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJADOPRINOS");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJADOPRINOS);
                this.columnOPISPLACANJADOPRINOS = new DataColumn("OPISPLACANJADOPRINOS", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJADOPRINOS.AllowDBNull = true;
                this.columnOPISPLACANJADOPRINOS.Caption = "Opis plaćanja doprinosa";
                this.columnOPISPLACANJADOPRINOS.MaxLength = 0x24;
                this.columnOPISPLACANJADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Description", "Opis plaćanja doprinosa");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJADOPRINOS");
                this.Columns.Add(this.columnOPISPLACANJADOPRINOS);
                this.columnVBDIDOPRINOS = new DataColumn("VBDIDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnVBDIDOPRINOS.AllowDBNull = true;
                this.columnVBDIDOPRINOS.Caption = "VBDI za doprinos";
                this.columnVBDIDOPRINOS.MaxLength = 7;
                this.columnVBDIDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Description", "VBDI za doprinos");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Length", "7");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "VBDIDOPRINOS");
                this.Columns.Add(this.columnVBDIDOPRINOS);
                this.columnZRNDOPRINOS = new DataColumn("ZRNDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnZRNDOPRINOS.AllowDBNull = true;
                this.columnZRNDOPRINOS.Caption = "Žiro račun za doprinos";
                this.columnZRNDOPRINOS.MaxLength = 10;
                this.columnZRNDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Description", "Žiro račun za doprinos");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Length", "10");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "ZRNDOPRINOS");
                this.Columns.Add(this.columnZRNDOPRINOS);
                this.columnMINDOPRINOS = new DataColumn("MINDOPRINOS", typeof(decimal), "", MappingType.Element);
                this.columnMINDOPRINOS.AllowDBNull = true;
                this.columnMINDOPRINOS.Caption = "Minimalna osnovica za obračun doprinosa";
                this.columnMINDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMINDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnMINDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Description", "Minimalna osnovica za obračun doprinosa");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Length", "12");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Decimals", "2");
                this.columnMINDOPRINOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMINDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "MINDOPRINOS");
                this.Columns.Add(this.columnMINDOPRINOS);
                this.columnMAXDOPRINOS = new DataColumn("MAXDOPRINOS", typeof(decimal), "", MappingType.Element);
                this.columnMAXDOPRINOS.AllowDBNull = true;
                this.columnMAXDOPRINOS.Caption = "Maksimalna osnovica za obračun doprinosa";
                this.columnMAXDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Description", "Maksimalna osnovica za obračun doprinosa");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Length", "12");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Decimals", "2");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "MAXDOPRINOS");
                this.Columns.Add(this.columnMAXDOPRINOS);
                this.columnSTOPA = new DataColumn("STOPA", typeof(decimal), "", MappingType.Element);
                this.columnSTOPA.AllowDBNull = true;
                this.columnSTOPA.Caption = "STOPA";
                this.columnSTOPA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPA.ExtendedProperties.Add("Description", "STOPA");
                this.columnSTOPA.ExtendedProperties.Add("Length", "5");
                this.columnSTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnSTOPA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.InternalName", "STOPA");
                this.Columns.Add(this.columnSTOPA);
                this.PrimaryKey = new DataColumn[] { this.columnIDSKUPPOREZAIDOPRINOSA, this.columnIDDOPRINOS };
                this.ExtendedProperties.Add("ParentLvl", "SKUPPOREZAIDOPRINOSA");
                this.ExtendedProperties.Add("LevelName", "SKUPPOREZAIDOPRINOSALevel2");
                this.ExtendedProperties.Add("Description", "Doprinosi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDSKUPPOREZAIDOPRINOSA = this.Columns["IDSKUPPOREZAIDOPRINOSA"];
                this.columnIDDOPRINOS = this.Columns["IDDOPRINOS"];
                this.columnNAZIVDOPRINOS = this.Columns["NAZIVDOPRINOS"];
                this.columnIDVRSTADOPRINOS = this.Columns["IDVRSTADOPRINOS"];
                this.columnNAZIVVRSTADOPRINOS = this.Columns["NAZIVVRSTADOPRINOS"];
                this.columnMODOPRINOS = this.Columns["MODOPRINOS"];
                this.columnPODOPRINOS = this.Columns["PODOPRINOS"];
                this.columnMZDOPRINOS = this.Columns["MZDOPRINOS"];
                this.columnPZDOPRINOS = this.Columns["PZDOPRINOS"];
                this.columnPRIMATELJDOPRINOS1 = this.Columns["PRIMATELJDOPRINOS1"];
                this.columnPRIMATELJDOPRINOS2 = this.Columns["PRIMATELJDOPRINOS2"];
                this.columnSIFRAOPISAPLACANJADOPRINOS = this.Columns["SIFRAOPISAPLACANJADOPRINOS"];
                this.columnOPISPLACANJADOPRINOS = this.Columns["OPISPLACANJADOPRINOS"];
                this.columnVBDIDOPRINOS = this.Columns["VBDIDOPRINOS"];
                this.columnZRNDOPRINOS = this.Columns["ZRNDOPRINOS"];
                this.columnMINDOPRINOS = this.Columns["MINDOPRINOS"];
                this.columnMAXDOPRINOS = this.Columns["MAXDOPRINOS"];
                this.columnSTOPA = this.Columns["STOPA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row(builder);
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row NewSKUPPOREZAIDOPRINOSA2Row()
            {
                return (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SKUPPOREZAIDOPRINOSA2RowChanged != null)
                {
                    SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2RowChangeEventHandler handler = this.SKUPPOREZAIDOPRINOSA2RowChanged;
                    if (handler != null)
                    {
                        handler(this, new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2RowChangeEvent((SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SKUPPOREZAIDOPRINOSA2RowChanging != null)
                {
                    SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2RowChangeEventHandler handler = this.SKUPPOREZAIDOPRINOSA2RowChanging;
                    if (handler != null)
                    {
                        handler(this, new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2RowChangeEvent((SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA2", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.SKUPPOREZAIDOPRINOSA2RowDeleted != null)
                {
                    SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2RowChangeEventHandler handler = this.SKUPPOREZAIDOPRINOSA2RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2RowChangeEvent((SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SKUPPOREZAIDOPRINOSA2RowDeleting != null)
                {
                    SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2RowChangeEventHandler handler = this.SKUPPOREZAIDOPRINOSA2RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2RowChangeEvent((SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSKUPPOREZAIDOPRINOSA2Row(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row row)
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

            public DataColumn IDDOPRINOSColumn
            {
                get
                {
                    return this.columnIDDOPRINOS;
                }
            }

            public DataColumn IDSKUPPOREZAIDOPRINOSAColumn
            {
                get
                {
                    return this.columnIDSKUPPOREZAIDOPRINOSA;
                }
            }

            public DataColumn IDVRSTADOPRINOSColumn
            {
                get
                {
                    return this.columnIDVRSTADOPRINOS;
                }
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row this[int index]
            {
                get
                {
                    return (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row) this.Rows[index];
                }
            }

            public DataColumn MAXDOPRINOSColumn
            {
                get
                {
                    return this.columnMAXDOPRINOS;
                }
            }

            public DataColumn MINDOPRINOSColumn
            {
                get
                {
                    return this.columnMINDOPRINOS;
                }
            }

            public DataColumn MODOPRINOSColumn
            {
                get
                {
                    return this.columnMODOPRINOS;
                }
            }

            public DataColumn MZDOPRINOSColumn
            {
                get
                {
                    return this.columnMZDOPRINOS;
                }
            }

            public DataColumn NAZIVDOPRINOSColumn
            {
                get
                {
                    return this.columnNAZIVDOPRINOS;
                }
            }

            public DataColumn NAZIVVRSTADOPRINOSColumn
            {
                get
                {
                    return this.columnNAZIVVRSTADOPRINOS;
                }
            }

            public DataColumn OPISPLACANJADOPRINOSColumn
            {
                get
                {
                    return this.columnOPISPLACANJADOPRINOS;
                }
            }

            public DataColumn PODOPRINOSColumn
            {
                get
                {
                    return this.columnPODOPRINOS;
                }
            }

            public DataColumn PRIMATELJDOPRINOS1Column
            {
                get
                {
                    return this.columnPRIMATELJDOPRINOS1;
                }
            }

            public DataColumn PRIMATELJDOPRINOS2Column
            {
                get
                {
                    return this.columnPRIMATELJDOPRINOS2;
                }
            }

            public DataColumn PZDOPRINOSColumn
            {
                get
                {
                    return this.columnPZDOPRINOS;
                }
            }

            public DataColumn SIFRAOPISAPLACANJADOPRINOSColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJADOPRINOS;
                }
            }

            public DataColumn STOPAColumn
            {
                get
                {
                    return this.columnSTOPA;
                }
            }

            public DataColumn VBDIDOPRINOSColumn
            {
                get
                {
                    return this.columnVBDIDOPRINOS;
                }
            }

            public DataColumn ZRNDOPRINOSColumn
            {
                get
                {
                    return this.columnZRNDOPRINOS;
                }
            }
        }

        public class SKUPPOREZAIDOPRINOSA2Row : DataRow
        {
            private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2DataTable tableSKUPPOREZAIDOPRINOSA2;

            internal SKUPPOREZAIDOPRINOSA2Row(DataRowBuilder rb) : base(rb)
            {
                this.tableSKUPPOREZAIDOPRINOSA2 = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2DataTable) this.Table;
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow GetSKUPPOREZAIDOPRINOSARow()
            {
                return (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow) this.GetParentRow("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA2");
            }

            public bool IsIDDOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.IDDOPRINOSColumn);
            }

            public bool IsIDSKUPPOREZAIDOPRINOSANull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.IDSKUPPOREZAIDOPRINOSAColumn);
            }

            public bool IsIDVRSTADOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.IDVRSTADOPRINOSColumn);
            }

            public bool IsMAXDOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.MAXDOPRINOSColumn);
            }

            public bool IsMINDOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.MINDOPRINOSColumn);
            }

            public bool IsMODOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.MODOPRINOSColumn);
            }

            public bool IsMZDOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.MZDOPRINOSColumn);
            }

            public bool IsNAZIVDOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.NAZIVDOPRINOSColumn);
            }

            public bool IsNAZIVVRSTADOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.NAZIVVRSTADOPRINOSColumn);
            }

            public bool IsOPISPLACANJADOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.OPISPLACANJADOPRINOSColumn);
            }

            public bool IsPODOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.PODOPRINOSColumn);
            }

            public bool IsPRIMATELJDOPRINOS1Null()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.PRIMATELJDOPRINOS1Column);
            }

            public bool IsPRIMATELJDOPRINOS2Null()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.PRIMATELJDOPRINOS2Column);
            }

            public bool IsPZDOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.PZDOPRINOSColumn);
            }

            public bool IsSIFRAOPISAPLACANJADOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.SIFRAOPISAPLACANJADOPRINOSColumn);
            }

            public bool IsSTOPANull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.STOPAColumn);
            }

            public bool IsVBDIDOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.VBDIDOPRINOSColumn);
            }

            public bool IsZRNDOPRINOSNull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA2.ZRNDOPRINOSColumn);
            }

            public void SetIDVRSTADOPRINOSNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.IDVRSTADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMAXDOPRINOSNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.MAXDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMINDOPRINOSNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.MINDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMODOPRINOSNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.MODOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZDOPRINOSNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.MZDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVDOPRINOSNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.NAZIVDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVVRSTADOPRINOSNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.NAZIVVRSTADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJADOPRINOSNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.OPISPLACANJADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPODOPRINOSNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.PODOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJDOPRINOS1Null()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.PRIMATELJDOPRINOS1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJDOPRINOS2Null()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.PRIMATELJDOPRINOS2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZDOPRINOSNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.PZDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJADOPRINOSNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.SIFRAOPISAPLACANJADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPANull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.STOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIDOPRINOSNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.VBDIDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNDOPRINOSNull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA2.ZRNDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDDOPRINOS
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSKUPPOREZAIDOPRINOSA2.IDDOPRINOSColumn]);
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.IDDOPRINOSColumn] = value;
                }
            }

            public int IDSKUPPOREZAIDOPRINOSA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSKUPPOREZAIDOPRINOSA2.IDSKUPPOREZAIDOPRINOSAColumn]);
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.IDSKUPPOREZAIDOPRINOSAColumn] = value;
                }
            }

            public int IDVRSTADOPRINOS
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSKUPPOREZAIDOPRINOSA2.IDVRSTADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.IDVRSTADOPRINOSColumn] = value;
                }
            }

            public decimal MAXDOPRINOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSKUPPOREZAIDOPRINOSA2.MAXDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.MAXDOPRINOSColumn] = value;
                }
            }

            public decimal MINDOPRINOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSKUPPOREZAIDOPRINOSA2.MINDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.MINDOPRINOSColumn] = value;
                }
            }

            public string MODOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA2.MODOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.MODOPRINOSColumn] = value;
                }
            }

            public string MZDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA2.MZDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.MZDOPRINOSColumn] = value;
                }
            }

            public string NAZIVDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA2.NAZIVDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.NAZIVDOPRINOSColumn] = value;
                }
            }

            public string NAZIVVRSTADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA2.NAZIVVRSTADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.NAZIVVRSTADOPRINOSColumn] = value;
                }
            }

            public string OPISPLACANJADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA2.OPISPLACANJADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.OPISPLACANJADOPRINOSColumn] = value;
                }
            }

            public string PODOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA2.PODOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.PODOPRINOSColumn] = value;
                }
            }

            public string PRIMATELJDOPRINOS1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA2.PRIMATELJDOPRINOS1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.PRIMATELJDOPRINOS1Column] = value;
                }
            }

            public string PRIMATELJDOPRINOS2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA2.PRIMATELJDOPRINOS2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.PRIMATELJDOPRINOS2Column] = value;
                }
            }

            public string PZDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA2.PZDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.PZDOPRINOSColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA2.SIFRAOPISAPLACANJADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.SIFRAOPISAPLACANJADOPRINOSColumn] = value;
                }
            }

            public decimal STOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSKUPPOREZAIDOPRINOSA2.STOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.STOPAColumn] = value;
                }
            }

            public string VBDIDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA2.VBDIDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.VBDIDOPRINOSColumn] = value;
                }
            }

            public string ZRNDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA2.ZRNDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA2.ZRNDOPRINOSColumn] = value;
                }
            }
        }

        public class SKUPPOREZAIDOPRINOSA2RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row eventRow;

            public SKUPPOREZAIDOPRINOSA2RowChangeEvent(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row row, DataRowAction action)
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

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SKUPPOREZAIDOPRINOSA2RowChangeEventHandler(object sender, SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2RowChangeEvent e);

        [Serializable]
        public class SKUPPOREZAIDOPRINOSADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSKUPPOREZAIDOPRINOSA;
            private DataColumn columnNAZIVSKUPPOREZAIDOPRINOSA;

            public event SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARowChangeEventHandler SKUPPOREZAIDOPRINOSARowChanged;

            public event SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARowChangeEventHandler SKUPPOREZAIDOPRINOSARowChanging;

            public event SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARowChangeEventHandler SKUPPOREZAIDOPRINOSARowDeleted;

            public event SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARowChangeEventHandler SKUPPOREZAIDOPRINOSARowDeleting;

            public SKUPPOREZAIDOPRINOSADataTable()
            {
                this.TableName = "SKUPPOREZAIDOPRINOSA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SKUPPOREZAIDOPRINOSADataTable(DataTable table) : base(table.TableName)
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

            protected SKUPPOREZAIDOPRINOSADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSKUPPOREZAIDOPRINOSARow(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow row)
            {
                this.Rows.Add(row);
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow AddSKUPPOREZAIDOPRINOSARow(int iDSKUPPOREZAIDOPRINOSA, string nAZIVSKUPPOREZAIDOPRINOSA)
            {
                SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow row = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow) this.NewRow();
                row["IDSKUPPOREZAIDOPRINOSA"] = iDSKUPPOREZAIDOPRINOSA;
                row["NAZIVSKUPPOREZAIDOPRINOSA"] = nAZIVSKUPPOREZAIDOPRINOSA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSADataTable table = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow FindByIDSKUPPOREZAIDOPRINOSA(int iDSKUPPOREZAIDOPRINOSA)
            {
                return (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow) this.Rows.Find(new object[] { iDSKUPPOREZAIDOPRINOSA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SKUPPOREZAIDOPRINOSADataSet set = new SKUPPOREZAIDOPRINOSADataSet();
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
                this.columnIDSKUPPOREZAIDOPRINOSA = new DataColumn("IDSKUPPOREZAIDOPRINOSA", typeof(int), "", MappingType.Element);
                this.columnIDSKUPPOREZAIDOPRINOSA.AllowDBNull = false;
                this.columnIDSKUPPOREZAIDOPRINOSA.Caption = "Šifra skupine poreza i doprinosa";
                this.columnIDSKUPPOREZAIDOPRINOSA.Unique = true;
                this.columnIDSKUPPOREZAIDOPRINOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Description", "Šifra skupine poreza i doprinosa");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Length", "5");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.InternalName", "IDSKUPPOREZAIDOPRINOSA");
                this.Columns.Add(this.columnIDSKUPPOREZAIDOPRINOSA);
                this.columnNAZIVSKUPPOREZAIDOPRINOSA = new DataColumn("NAZIVSKUPPOREZAIDOPRINOSA", typeof(string), "", MappingType.Element);
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.AllowDBNull = false;
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.Caption = "Naziv skupine poreza i doprinosa";
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.MaxLength = 50;
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Description", "Naziv skupine poreza i doprinosa");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVSKUPPOREZAIDOPRINOSA");
                this.Columns.Add(this.columnNAZIVSKUPPOREZAIDOPRINOSA);
                this.PrimaryKey = new DataColumn[] { this.columnIDSKUPPOREZAIDOPRINOSA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "SKUPPOREZAIDOPRINOSA");
                this.ExtendedProperties.Add("Description", "Skupine poreza i doprinosa");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDSKUPPOREZAIDOPRINOSA = this.Columns["IDSKUPPOREZAIDOPRINOSA"];
                this.columnNAZIVSKUPPOREZAIDOPRINOSA = this.Columns["NAZIVSKUPPOREZAIDOPRINOSA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow(builder);
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow NewSKUPPOREZAIDOPRINOSARow()
            {
                return (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SKUPPOREZAIDOPRINOSARowChanged != null)
                {
                    SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARowChangeEventHandler sKUPPOREZAIDOPRINOSARowChangedEvent = this.SKUPPOREZAIDOPRINOSARowChanged;
                    if (sKUPPOREZAIDOPRINOSARowChangedEvent != null)
                    {
                        sKUPPOREZAIDOPRINOSARowChangedEvent(this, new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARowChangeEvent((SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SKUPPOREZAIDOPRINOSARowChanging != null)
                {
                    SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARowChangeEventHandler sKUPPOREZAIDOPRINOSARowChangingEvent = this.SKUPPOREZAIDOPRINOSARowChanging;
                    if (sKUPPOREZAIDOPRINOSARowChangingEvent != null)
                    {
                        sKUPPOREZAIDOPRINOSARowChangingEvent(this, new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARowChangeEvent((SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SKUPPOREZAIDOPRINOSARowDeleted != null)
                {
                    SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARowChangeEventHandler sKUPPOREZAIDOPRINOSARowDeletedEvent = this.SKUPPOREZAIDOPRINOSARowDeleted;
                    if (sKUPPOREZAIDOPRINOSARowDeletedEvent != null)
                    {
                        sKUPPOREZAIDOPRINOSARowDeletedEvent(this, new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARowChangeEvent((SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SKUPPOREZAIDOPRINOSARowDeleting != null)
                {
                    SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARowChangeEventHandler sKUPPOREZAIDOPRINOSARowDeletingEvent = this.SKUPPOREZAIDOPRINOSARowDeleting;
                    if (sKUPPOREZAIDOPRINOSARowDeletingEvent != null)
                    {
                        sKUPPOREZAIDOPRINOSARowDeletingEvent(this, new SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARowChangeEvent((SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSKUPPOREZAIDOPRINOSARow(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow row)
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

            public DataColumn IDSKUPPOREZAIDOPRINOSAColumn
            {
                get
                {
                    return this.columnIDSKUPPOREZAIDOPRINOSA;
                }
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow this[int index]
            {
                get
                {
                    return (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVSKUPPOREZAIDOPRINOSAColumn
            {
                get
                {
                    return this.columnNAZIVSKUPPOREZAIDOPRINOSA;
                }
            }
        }

        public class SKUPPOREZAIDOPRINOSARow : DataRow
        {
            private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSADataTable tableSKUPPOREZAIDOPRINOSA;

            internal SKUPPOREZAIDOPRINOSARow(DataRowBuilder rb) : base(rb)
            {
                this.tableSKUPPOREZAIDOPRINOSA = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSADataTable) this.Table;
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row[] GetSKUPPOREZAIDOPRINOSA1Rows()
            {
                return (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row[]) this.GetChildRows("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA1");
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row[] GetSKUPPOREZAIDOPRINOSA2Rows()
            {
                return (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row[]) this.GetChildRows("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA2");
            }

            public bool IsIDSKUPPOREZAIDOPRINOSANull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA.IDSKUPPOREZAIDOPRINOSAColumn);
            }

            public bool IsNAZIVSKUPPOREZAIDOPRINOSANull()
            {
                return this.IsNull(this.tableSKUPPOREZAIDOPRINOSA.NAZIVSKUPPOREZAIDOPRINOSAColumn);
            }

            public void SetNAZIVSKUPPOREZAIDOPRINOSANull()
            {
                this[this.tableSKUPPOREZAIDOPRINOSA.NAZIVSKUPPOREZAIDOPRINOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSKUPPOREZAIDOPRINOSA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSKUPPOREZAIDOPRINOSA.IDSKUPPOREZAIDOPRINOSAColumn]);
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA.IDSKUPPOREZAIDOPRINOSAColumn] = value;
                }
            }

            public string NAZIVSKUPPOREZAIDOPRINOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSKUPPOREZAIDOPRINOSA.NAZIVSKUPPOREZAIDOPRINOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSKUPPOREZAIDOPRINOSA.NAZIVSKUPPOREZAIDOPRINOSAColumn] = value;
                }
            }
        }

        public class SKUPPOREZAIDOPRINOSARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow eventRow;

            public SKUPPOREZAIDOPRINOSARowChangeEvent(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow row, DataRowAction action)
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

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SKUPPOREZAIDOPRINOSARowChangeEventHandler(object sender, SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARowChangeEvent e);
    }
}

