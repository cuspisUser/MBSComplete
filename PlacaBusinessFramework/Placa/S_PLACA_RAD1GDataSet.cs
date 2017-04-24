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
    public class S_PLACA_RAD1GDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_PLACA_RAD1GDataTable tableS_PLACA_RAD1G;

        public S_PLACA_RAD1GDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_PLACA_RAD1GDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_PLACA_RAD1G"] != null)
                    {
                        this.Tables.Add(new S_PLACA_RAD1GDataTable(dataSet.Tables["S_PLACA_RAD1G"]));
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
            S_PLACA_RAD1GDataSet set = (S_PLACA_RAD1GDataSet) base.Clone();
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
            S_PLACA_RAD1GDataSet set = new S_PLACA_RAD1GDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_PLACA_RAD1GDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2184");
            this.ExtendedProperties.Add("DataSetName", "S_PLACA_RAD1GDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_PLACA_RAD1GDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_PLACA_RAD1G");
            this.ExtendedProperties.Add("ObjectDescription", "S_PLACA_RAD1G");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_RAD1G");
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
            this.DataSetName = "S_PLACA_RAD1GDataSet";
            this.Namespace = "http://www.tempuri.org/S_PLACA_RAD1G";
            this.tableS_PLACA_RAD1G = new S_PLACA_RAD1GDataTable();
            this.Tables.Add(this.tableS_PLACA_RAD1G);
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
            this.tableS_PLACA_RAD1G = (S_PLACA_RAD1GDataTable) this.Tables["S_PLACA_RAD1G"];
            if (initTable && (this.tableS_PLACA_RAD1G != null))
            {
                this.tableS_PLACA_RAD1G.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_PLACA_RAD1G"] != null)
                {
                    this.Tables.Add(new S_PLACA_RAD1GDataTable(dataSet.Tables["S_PLACA_RAD1G"]));
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

        private bool ShouldSerializeS_PLACA_RAD1G()
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
        public S_PLACA_RAD1GDataTable S_PLACA_RAD1G
        {
            get
            {
                return this.tableS_PLACA_RAD1G;
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
        public class S_PLACA_RAD1GDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJRADNIKA;
            private DataColumn columnBROJRADNIKAZENA;
            private DataColumn columnGODINASTAROSTI;
            private DataColumn columnRADNOVRIJEME;
            private DataColumn columnSPREMA;
            private DataColumn columnVRSTARADNOGODNOSA;

            public event S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRowChangeEventHandler S_PLACA_RAD1GRowChanged;

            public event S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRowChangeEventHandler S_PLACA_RAD1GRowChanging;

            public event S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRowChangeEventHandler S_PLACA_RAD1GRowDeleted;

            public event S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRowChangeEventHandler S_PLACA_RAD1GRowDeleting;

            public S_PLACA_RAD1GDataTable()
            {
                this.TableName = "S_PLACA_RAD1G";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_PLACA_RAD1GDataTable(DataTable table) : base(table.TableName)
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

            protected S_PLACA_RAD1GDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_PLACA_RAD1GRow(S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow row)
            {
                this.Rows.Add(row);
            }

            public S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow AddS_PLACA_RAD1GRow(decimal bROJRADNIKA, decimal bROJRADNIKAZENA, decimal gODINASTAROSTI, string rADNOVRIJEME, string vRSTARADNOGODNOSA, string sPREMA)
            {
                S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow row = (S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow) this.NewRow();
                row.ItemArray = new object[] { bROJRADNIKA, bROJRADNIKAZENA, gODINASTAROSTI, rADNOVRIJEME, vRSTARADNOGODNOSA, sPREMA };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_PLACA_RAD1GDataSet.S_PLACA_RAD1GDataTable table = (S_PLACA_RAD1GDataSet.S_PLACA_RAD1GDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_PLACA_RAD1GDataSet set = new S_PLACA_RAD1GDataSet();
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
                this.columnBROJRADNIKA = new DataColumn("BROJRADNIKA", typeof(decimal), "", MappingType.Element);
                this.columnBROJRADNIKA.Caption = "Broj stjecatelja";
                this.columnBROJRADNIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJRADNIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRADNIKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJRADNIKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Description", "Broj stjecatelja");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Length", "12");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Decimals", "2");
                this.columnBROJRADNIKA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBROJRADNIKA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBROJRADNIKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRADNIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.InternalName", "BROJRADNIKA");
                this.Columns.Add(this.columnBROJRADNIKA);
                this.columnBROJRADNIKAZENA = new DataColumn("BROJRADNIKAZENA", typeof(decimal), "", MappingType.Element);
                this.columnBROJRADNIKAZENA.Caption = "BROJRADNIKAZENA";
                this.columnBROJRADNIKAZENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("Description", "BROJRADNIKAZENA");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("Length", "12");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("Decimals", "2");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRADNIKAZENA.ExtendedProperties.Add("Deklarit.InternalName", "BROJRADNIKAZENA");
                this.Columns.Add(this.columnBROJRADNIKAZENA);
                this.columnGODINASTAROSTI = new DataColumn("GODINASTAROSTI", typeof(decimal), "", MappingType.Element);
                this.columnGODINASTAROSTI.Caption = "GODINASTAROSTI";
                this.columnGODINASTAROSTI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINASTAROSTI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("Description", "GODINASTAROSTI");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("Length", "12");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("Decimals", "2");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINASTAROSTI.ExtendedProperties.Add("Deklarit.InternalName", "GODINASTAROSTI");
                this.Columns.Add(this.columnGODINASTAROSTI);
                this.columnRADNOVRIJEME = new DataColumn("RADNOVRIJEME", typeof(string), "", MappingType.Element);
                this.columnRADNOVRIJEME.Caption = "RADNOVRIJEME";
                this.columnRADNOVRIJEME.MaxLength = 3;
                this.columnRADNOVRIJEME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRADNOVRIJEME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRADNOVRIJEME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRADNOVRIJEME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnRADNOVRIJEME.ExtendedProperties.Add("IsKey", "false");
                this.columnRADNOVRIJEME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnRADNOVRIJEME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRADNOVRIJEME.ExtendedProperties.Add("Description", "RADNOVRIJEME");
                this.columnRADNOVRIJEME.ExtendedProperties.Add("Length", "3");
                this.columnRADNOVRIJEME.ExtendedProperties.Add("Decimals", "0");
                this.columnRADNOVRIJEME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRADNOVRIJEME.ExtendedProperties.Add("IsInReader", "true");
                this.columnRADNOVRIJEME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRADNOVRIJEME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRADNOVRIJEME.ExtendedProperties.Add("Deklarit.InternalName", "RADNOVRIJEME");
                this.Columns.Add(this.columnRADNOVRIJEME);
                this.columnVRSTARADNOGODNOSA = new DataColumn("VRSTARADNOGODNOSA", typeof(string), "", MappingType.Element);
                this.columnVRSTARADNOGODNOSA.Caption = "VRSTARADNOGODNOSA";
                this.columnVRSTARADNOGODNOSA.MaxLength = 3;
                this.columnVRSTARADNOGODNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("Description", "VRSTARADNOGODNOSA");
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("Length", "3");
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVRSTARADNOGODNOSA.ExtendedProperties.Add("Deklarit.InternalName", "VRSTARADNOGODNOSA");
                this.Columns.Add(this.columnVRSTARADNOGODNOSA);
                this.columnSPREMA = new DataColumn("SPREMA", typeof(string), "", MappingType.Element);
                this.columnSPREMA.Caption = "SPREMA";
                this.columnSPREMA.MaxLength = 6;
                this.columnSPREMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSPREMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSPREMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSPREMA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSPREMA.ExtendedProperties.Add("IsKey", "false");
                this.columnSPREMA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSPREMA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSPREMA.ExtendedProperties.Add("Description", "SPREMA");
                this.columnSPREMA.ExtendedProperties.Add("Length", "6");
                this.columnSPREMA.ExtendedProperties.Add("Decimals", "0");
                this.columnSPREMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSPREMA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSPREMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSPREMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSPREMA.ExtendedProperties.Add("Deklarit.InternalName", "SPREMA");
                this.Columns.Add(this.columnSPREMA);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_PLACA_RAD1G");
                this.ExtendedProperties.Add("Description", "S_PLACA_RAD1G");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnBROJRADNIKA = this.Columns["BROJRADNIKA"];
                this.columnBROJRADNIKAZENA = this.Columns["BROJRADNIKAZENA"];
                this.columnGODINASTAROSTI = this.Columns["GODINASTAROSTI"];
                this.columnRADNOVRIJEME = this.Columns["RADNOVRIJEME"];
                this.columnVRSTARADNOGODNOSA = this.Columns["VRSTARADNOGODNOSA"];
                this.columnSPREMA = this.Columns["SPREMA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow(builder);
            }

            public S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow NewS_PLACA_RAD1GRow()
            {
                return (S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_PLACA_RAD1GRowChanged != null)
                {
                    S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRowChangeEventHandler handler = this.S_PLACA_RAD1GRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRowChangeEvent((S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_PLACA_RAD1GRowChanging != null)
                {
                    S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRowChangeEventHandler handler = this.S_PLACA_RAD1GRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRowChangeEvent((S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_PLACA_RAD1GRowDeleted != null)
                {
                    S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRowChangeEventHandler handler = this.S_PLACA_RAD1GRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRowChangeEvent((S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_PLACA_RAD1GRowDeleting != null)
                {
                    S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRowChangeEventHandler handler = this.S_PLACA_RAD1GRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRowChangeEvent((S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_PLACA_RAD1GRow(S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJRADNIKAColumn
            {
                get
                {
                    return this.columnBROJRADNIKA;
                }
            }

            public DataColumn BROJRADNIKAZENAColumn
            {
                get
                {
                    return this.columnBROJRADNIKAZENA;
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

            public DataColumn GODINASTAROSTIColumn
            {
                get
                {
                    return this.columnGODINASTAROSTI;
                }
            }

            public S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow this[int index]
            {
                get
                {
                    return (S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow) this.Rows[index];
                }
            }

            public DataColumn RADNOVRIJEMEColumn
            {
                get
                {
                    return this.columnRADNOVRIJEME;
                }
            }

            public DataColumn SPREMAColumn
            {
                get
                {
                    return this.columnSPREMA;
                }
            }

            public DataColumn VRSTARADNOGODNOSAColumn
            {
                get
                {
                    return this.columnVRSTARADNOGODNOSA;
                }
            }
        }

        public class S_PLACA_RAD1GRow : DataRow
        {
            private S_PLACA_RAD1GDataSet.S_PLACA_RAD1GDataTable tableS_PLACA_RAD1G;

            internal S_PLACA_RAD1GRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_PLACA_RAD1G = (S_PLACA_RAD1GDataSet.S_PLACA_RAD1GDataTable) this.Table;
            }

            public bool IsBROJRADNIKANull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G.BROJRADNIKAColumn);
            }

            public bool IsBROJRADNIKAZENANull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G.BROJRADNIKAZENAColumn);
            }

            public bool IsGODINASTAROSTINull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G.GODINASTAROSTIColumn);
            }

            public bool IsRADNOVRIJEMENull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G.RADNOVRIJEMEColumn);
            }

            public bool IsSPREMANull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G.SPREMAColumn);
            }

            public bool IsVRSTARADNOGODNOSANull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G.VRSTARADNOGODNOSAColumn);
            }

            public void SetBROJRADNIKANull()
            {
                this[this.tableS_PLACA_RAD1G.BROJRADNIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJRADNIKAZENANull()
            {
                this[this.tableS_PLACA_RAD1G.BROJRADNIKAZENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGODINASTAROSTINull()
            {
                this[this.tableS_PLACA_RAD1G.GODINASTAROSTIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRADNOVRIJEMENull()
            {
                this[this.tableS_PLACA_RAD1G.RADNOVRIJEMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSPREMANull()
            {
                this[this.tableS_PLACA_RAD1G.SPREMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVRSTARADNOGODNOSANull()
            {
                this[this.tableS_PLACA_RAD1G.VRSTARADNOGODNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal BROJRADNIKA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1G.BROJRADNIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJRADNIKA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G.BROJRADNIKAColumn] = value;
                }
            }

            public decimal BROJRADNIKAZENA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1G.BROJRADNIKAZENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJRADNIKAZENA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G.BROJRADNIKAZENAColumn] = value;
                }
            }

            public decimal GODINASTAROSTI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1G.GODINASTAROSTIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value GODINASTAROSTI because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G.GODINASTAROSTIColumn] = value;
                }
            }

            public string RADNOVRIJEME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_RAD1G.RADNOVRIJEMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value RADNOVRIJEME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G.RADNOVRIJEMEColumn] = value;
                }
            }

            public string SPREMA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_RAD1G.SPREMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SPREMA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G.SPREMAColumn] = value;
                }
            }

            public string VRSTARADNOGODNOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_RAD1G.VRSTARADNOGODNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value VRSTARADNOGODNOSA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G.VRSTARADNOGODNOSAColumn] = value;
                }
            }
        }

        public class S_PLACA_RAD1GRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow eventRow;

            public S_PLACA_RAD1GRowChangeEvent(S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow row, DataRowAction action)
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

            public S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_PLACA_RAD1GRowChangeEventHandler(object sender, S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRowChangeEvent e);
    }
}

