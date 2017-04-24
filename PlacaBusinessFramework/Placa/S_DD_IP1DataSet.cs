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
    public class S_DD_IP1DataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_DD_IP1DataTable tableS_DD_IP1;

        public S_DD_IP1DataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_DD_IP1DataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_DD_IP1"] != null)
                    {
                        this.Tables.Add(new S_DD_IP1DataTable(dataSet.Tables["S_DD_IP1"]));
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
            S_DD_IP1DataSet set = (S_DD_IP1DataSet) base.Clone();
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
            S_DD_IP1DataSet set = new S_DD_IP1DataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_DD_IP1DataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2104");
            this.ExtendedProperties.Add("DataSetName", "S_DD_IP1DataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_DD_IP1DataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_DD_IP1");
            this.ExtendedProperties.Add("ObjectDescription", "S_DD_IP1");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_DD");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_DD_IP1");
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
            this.DataSetName = "S_DD_IP1DataSet";
            this.Namespace = "http://www.tempuri.org/S_DD_IP1";
            this.tableS_DD_IP1 = new S_DD_IP1DataTable();
            this.Tables.Add(this.tableS_DD_IP1);
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
            this.tableS_DD_IP1 = (S_DD_IP1DataTable) this.Tables["S_DD_IP1"];
            if (initTable && (this.tableS_DD_IP1 != null))
            {
                this.tableS_DD_IP1.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_DD_IP1"] != null)
                {
                    this.Tables.Add(new S_DD_IP1DataTable(dataSet.Tables["S_DD_IP1"]));
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

        private bool ShouldSerializeS_DD_IP1()
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
        public S_DD_IP1DataTable S_DD_IP1
        {
            get
            {
                return this.tableS_DD_IP1;
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
        public class S_DD_IP1DataTable : DataTable, IEnumerable
        {
            private DataColumn columnBRUTO;
            private DataColumn columnDDIDRADNIK;
            private DataColumn columnDDIME;
            private DataColumn columnDDJMBG;
            private DataColumn columnDDOIB;
            private DataColumn columnDDOZNACEN;
            private DataColumn columnDDPREZIME;
            private DataColumn columnDOPRINOSIIZ;
            private DataColumn columnIZDACI;
            private DataColumn columnNETO;
            private DataColumn columnOPCINASTANOVANJAIDOPCINE;
            private DataColumn columnP1422;
            private DataColumn columnP1457;
            private DataColumn columnP1465;
            private DataColumn columnP1473;
            private DataColumn columnP1546;
            private DataColumn columnP1570;
            private DataColumn columnP1589;
            private DataColumn columnP1597;
            private DataColumn columnP1600;
            private DataColumn columnP1805;
            private DataColumn columnP1813;
            private DataColumn columnP1821;
            private DataColumn columnP1830;
            private DataColumn columnP1848;
            private DataColumn columnPOREZIPRIREZ;

            public event S_DD_IP1DataSet.S_DD_IP1RowChangeEventHandler S_DD_IP1RowChanged;

            public event S_DD_IP1DataSet.S_DD_IP1RowChangeEventHandler S_DD_IP1RowChanging;

            public event S_DD_IP1DataSet.S_DD_IP1RowChangeEventHandler S_DD_IP1RowDeleted;

            public event S_DD_IP1DataSet.S_DD_IP1RowChangeEventHandler S_DD_IP1RowDeleting;

            public S_DD_IP1DataTable()
            {
                this.TableName = "S_DD_IP1";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_DD_IP1DataTable(DataTable table) : base(table.TableName)
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

            protected S_DD_IP1DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_DD_IP1Row(S_DD_IP1DataSet.S_DD_IP1Row row)
            {
                this.Rows.Add(row);
            }

            public S_DD_IP1DataSet.S_DD_IP1Row AddS_DD_IP1Row(int dDIDRADNIK, string dDPREZIME, string dDIME, decimal bRUTO, decimal iZDACI, decimal dOPRINOSIIZ, decimal pOREZIPRIREZ, decimal nETO, string oPCINASTANOVANJAIDOPCINE, decimal p1422, decimal p1805, decimal p1457, decimal p1465, decimal p1473, decimal p1546, decimal p1570, decimal p1589, decimal p1597, decimal p1600, decimal p1813, decimal p1821, decimal p1830, decimal p1848, string dDJMBG, string dDOIB, bool dDOZNACEN)
            {
                S_DD_IP1DataSet.S_DD_IP1Row row = (S_DD_IP1DataSet.S_DD_IP1Row) this.NewRow();
                row.ItemArray = new object[] { 
                    dDIDRADNIK, dDPREZIME, dDIME, bRUTO, iZDACI, dOPRINOSIIZ, pOREZIPRIREZ, nETO, oPCINASTANOVANJAIDOPCINE, p1422, p1805, p1457, p1465, p1473, p1546, p1570, 
                    p1589, p1597, p1600, p1813, p1821, p1830, p1848, dDJMBG, dDOIB, dDOZNACEN
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_DD_IP1DataSet.S_DD_IP1DataTable table = (S_DD_IP1DataSet.S_DD_IP1DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_DD_IP1DataSet.S_DD_IP1Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_DD_IP1DataSet set = new S_DD_IP1DataSet();
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
                this.columnDDIDRADNIK = new DataColumn("DDIDRADNIK", typeof(int), "", MappingType.Element);
                this.columnDDIDRADNIK.Caption = "Šifra";
                this.columnDDIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Description", "Šifra");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Length", "5");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "DDIDRADNIK");
                this.Columns.Add(this.columnDDIDRADNIK);
                this.columnDDPREZIME = new DataColumn("DDPREZIME", typeof(string), "", MappingType.Element);
                this.columnDDPREZIME.Caption = "Prezime";
                this.columnDDPREZIME.MaxLength = 50;
                this.columnDDPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnDDPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnDDPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnDDPREZIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "DDPREZIME");
                this.Columns.Add(this.columnDDPREZIME);
                this.columnDDIME = new DataColumn("DDIME", typeof(string), "", MappingType.Element);
                this.columnDDIME.Caption = "Ime";
                this.columnDDIME.MaxLength = 50;
                this.columnDDIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDIME.ExtendedProperties.Add("IsKey", "false");
                this.columnDDIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDIME.ExtendedProperties.Add("Description", "Ime");
                this.columnDDIME.ExtendedProperties.Add("Length", "50");
                this.columnDDIME.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.InternalName", "DDIME");
                this.Columns.Add(this.columnDDIME);
                this.columnBRUTO = new DataColumn("BRUTO", typeof(decimal), "", MappingType.Element);
                this.columnBRUTO.Caption = "Primici";
                this.columnBRUTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBRUTO.ExtendedProperties.Add("IsKey", "false");
                this.columnBRUTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBRUTO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBRUTO.ExtendedProperties.Add("Description", "Primici");
                this.columnBRUTO.ExtendedProperties.Add("Length", "12");
                this.columnBRUTO.ExtendedProperties.Add("Decimals", "2");
                this.columnBRUTO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBRUTO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBRUTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBRUTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBRUTO.ExtendedProperties.Add("Deklarit.InternalName", "BRUTO");
                this.Columns.Add(this.columnBRUTO);
                this.columnIZDACI = new DataColumn("IZDACI", typeof(decimal), "", MappingType.Element);
                this.columnIZDACI.Caption = "Izdaci";
                this.columnIZDACI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZDACI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZDACI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZDACI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZDACI.ExtendedProperties.Add("IsKey", "false");
                this.columnIZDACI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZDACI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZDACI.ExtendedProperties.Add("Description", "Izdaci");
                this.columnIZDACI.ExtendedProperties.Add("Length", "12");
                this.columnIZDACI.ExtendedProperties.Add("Decimals", "2");
                this.columnIZDACI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZDACI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZDACI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZDACI.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZDACI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZDACI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZDACI.ExtendedProperties.Add("Deklarit.InternalName", "IZDACI");
                this.Columns.Add(this.columnIZDACI);
                this.columnDOPRINOSIIZ = new DataColumn("DOPRINOSIIZ", typeof(decimal), "", MappingType.Element);
                this.columnDOPRINOSIIZ.Caption = "Doprinosi iz";
                this.columnDOPRINOSIIZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("IsKey", "false");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Description", "Doprinosi iz");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Length", "12");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Decimals", "2");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOPRINOSIIZ.ExtendedProperties.Add("Deklarit.InternalName", "DOPRINOSIIZ");
                this.Columns.Add(this.columnDOPRINOSIIZ);
                this.columnPOREZIPRIREZ = new DataColumn("POREZIPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnPOREZIPRIREZ.Caption = "Porez i prirez";
                this.columnPOREZIPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Description", "Porez i prirez");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "POREZIPRIREZ");
                this.Columns.Add(this.columnPOREZIPRIREZ);
                this.columnNETO = new DataColumn("NETO", typeof(decimal), "", MappingType.Element);
                this.columnNETO.Caption = "Neto";
                this.columnNETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNETO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNETO.ExtendedProperties.Add("IsKey", "false");
                this.columnNETO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNETO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNETO.ExtendedProperties.Add("Description", "Neto");
                this.columnNETO.ExtendedProperties.Add("Length", "12");
                this.columnNETO.ExtendedProperties.Add("Decimals", "2");
                this.columnNETO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNETO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNETO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNETO.ExtendedProperties.Add("Deklarit.InternalName", "NETO");
                this.Columns.Add(this.columnNETO);
                this.columnOPCINASTANOVANJAIDOPCINE = new DataColumn("OPCINASTANOVANJAIDOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJAIDOPCINE.Caption = "Šifra općine stanovanja";
                this.columnOPCINASTANOVANJAIDOPCINE.MaxLength = 4;
                this.columnOPCINASTANOVANJAIDOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("SuperType", "IDOPCINE");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Description", "Šifra općine stanovanja");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Length", "4");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAIDOPCINE");
                this.Columns.Add(this.columnOPCINASTANOVANJAIDOPCINE);
                this.columnP1422 = new DataColumn("P1422", typeof(decimal), "", MappingType.Element);
                this.columnP1422.Caption = "P1422";
                this.columnP1422.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1422.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1422.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1422.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1422.ExtendedProperties.Add("IsKey", "false");
                this.columnP1422.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1422.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1422.ExtendedProperties.Add("Description", "P1422");
                this.columnP1422.ExtendedProperties.Add("Length", "12");
                this.columnP1422.ExtendedProperties.Add("Decimals", "2");
                this.columnP1422.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1422.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1422.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1422.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1422.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1422.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1422.ExtendedProperties.Add("Deklarit.InternalName", "P1422");
                this.Columns.Add(this.columnP1422);
                this.columnP1805 = new DataColumn("P1805", typeof(decimal), "", MappingType.Element);
                this.columnP1805.Caption = "P1805";
                this.columnP1805.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1805.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1805.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1805.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1805.ExtendedProperties.Add("IsKey", "false");
                this.columnP1805.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1805.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1805.ExtendedProperties.Add("Description", "P1805");
                this.columnP1805.ExtendedProperties.Add("Length", "12");
                this.columnP1805.ExtendedProperties.Add("Decimals", "2");
                this.columnP1805.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1805.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1805.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1805.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1805.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1805.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1805.ExtendedProperties.Add("Deklarit.InternalName", "P1805");
                this.Columns.Add(this.columnP1805);
                this.columnP1457 = new DataColumn("P1457", typeof(decimal), "", MappingType.Element);
                this.columnP1457.Caption = "P1457";
                this.columnP1457.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1457.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1457.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1457.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1457.ExtendedProperties.Add("IsKey", "false");
                this.columnP1457.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1457.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1457.ExtendedProperties.Add("Description", "P1457");
                this.columnP1457.ExtendedProperties.Add("Length", "12");
                this.columnP1457.ExtendedProperties.Add("Decimals", "2");
                this.columnP1457.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1457.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1457.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1457.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1457.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1457.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1457.ExtendedProperties.Add("Deklarit.InternalName", "P1457");
                this.Columns.Add(this.columnP1457);
                this.columnP1465 = new DataColumn("P1465", typeof(decimal), "", MappingType.Element);
                this.columnP1465.Caption = "P1465";
                this.columnP1465.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1465.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1465.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1465.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1465.ExtendedProperties.Add("IsKey", "false");
                this.columnP1465.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1465.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1465.ExtendedProperties.Add("Description", "P1465");
                this.columnP1465.ExtendedProperties.Add("Length", "12");
                this.columnP1465.ExtendedProperties.Add("Decimals", "2");
                this.columnP1465.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1465.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1465.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1465.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1465.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1465.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1465.ExtendedProperties.Add("Deklarit.InternalName", "P1465");
                this.Columns.Add(this.columnP1465);
                this.columnP1473 = new DataColumn("P1473", typeof(decimal), "", MappingType.Element);
                this.columnP1473.Caption = "P1473";
                this.columnP1473.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1473.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1473.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1473.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1473.ExtendedProperties.Add("IsKey", "false");
                this.columnP1473.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1473.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1473.ExtendedProperties.Add("Description", "P1473");
                this.columnP1473.ExtendedProperties.Add("Length", "12");
                this.columnP1473.ExtendedProperties.Add("Decimals", "2");
                this.columnP1473.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1473.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1473.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1473.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1473.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1473.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1473.ExtendedProperties.Add("Deklarit.InternalName", "P1473");
                this.Columns.Add(this.columnP1473);
                this.columnP1546 = new DataColumn("P1546", typeof(decimal), "", MappingType.Element);
                this.columnP1546.Caption = "P1546";
                this.columnP1546.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1546.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1546.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1546.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1546.ExtendedProperties.Add("IsKey", "false");
                this.columnP1546.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1546.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1546.ExtendedProperties.Add("Description", "P1546");
                this.columnP1546.ExtendedProperties.Add("Length", "12");
                this.columnP1546.ExtendedProperties.Add("Decimals", "2");
                this.columnP1546.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1546.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1546.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1546.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1546.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1546.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1546.ExtendedProperties.Add("Deklarit.InternalName", "P1546");
                this.Columns.Add(this.columnP1546);
                this.columnP1570 = new DataColumn("P1570", typeof(decimal), "", MappingType.Element);
                this.columnP1570.Caption = "P1570";
                this.columnP1570.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1570.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1570.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1570.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1570.ExtendedProperties.Add("IsKey", "false");
                this.columnP1570.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1570.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1570.ExtendedProperties.Add("Description", "P1570");
                this.columnP1570.ExtendedProperties.Add("Length", "12");
                this.columnP1570.ExtendedProperties.Add("Decimals", "2");
                this.columnP1570.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1570.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1570.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1570.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1570.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1570.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1570.ExtendedProperties.Add("Deklarit.InternalName", "P1570");
                this.Columns.Add(this.columnP1570);
                this.columnP1589 = new DataColumn("P1589", typeof(decimal), "", MappingType.Element);
                this.columnP1589.Caption = "P1589";
                this.columnP1589.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1589.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1589.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1589.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1589.ExtendedProperties.Add("IsKey", "false");
                this.columnP1589.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1589.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1589.ExtendedProperties.Add("Description", "P1589");
                this.columnP1589.ExtendedProperties.Add("Length", "12");
                this.columnP1589.ExtendedProperties.Add("Decimals", "2");
                this.columnP1589.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1589.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1589.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1589.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1589.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1589.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1589.ExtendedProperties.Add("Deklarit.InternalName", "P1589");
                this.Columns.Add(this.columnP1589);
                this.columnP1597 = new DataColumn("P1597", typeof(decimal), "", MappingType.Element);
                this.columnP1597.Caption = "P1597";
                this.columnP1597.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1597.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1597.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1597.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1597.ExtendedProperties.Add("IsKey", "false");
                this.columnP1597.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1597.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1597.ExtendedProperties.Add("Description", "P1597");
                this.columnP1597.ExtendedProperties.Add("Length", "12");
                this.columnP1597.ExtendedProperties.Add("Decimals", "2");
                this.columnP1597.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1597.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1597.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1597.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1597.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1597.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1597.ExtendedProperties.Add("Deklarit.InternalName", "P1597");
                this.Columns.Add(this.columnP1597);
                this.columnP1600 = new DataColumn("P1600", typeof(decimal), "", MappingType.Element);
                this.columnP1600.Caption = "P1600";
                this.columnP1600.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1600.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1600.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1600.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1600.ExtendedProperties.Add("IsKey", "false");
                this.columnP1600.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1600.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1600.ExtendedProperties.Add("Description", "P1600");
                this.columnP1600.ExtendedProperties.Add("Length", "12");
                this.columnP1600.ExtendedProperties.Add("Decimals", "2");
                this.columnP1600.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1600.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1600.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1600.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1600.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1600.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1600.ExtendedProperties.Add("Deklarit.InternalName", "P1600");
                this.Columns.Add(this.columnP1600);
                this.columnP1813 = new DataColumn("P1813", typeof(decimal), "", MappingType.Element);
                this.columnP1813.Caption = "P1813";
                this.columnP1813.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1813.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1813.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1813.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1813.ExtendedProperties.Add("IsKey", "false");
                this.columnP1813.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1813.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1813.ExtendedProperties.Add("Description", "P1813");
                this.columnP1813.ExtendedProperties.Add("Length", "12");
                this.columnP1813.ExtendedProperties.Add("Decimals", "2");
                this.columnP1813.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1813.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1813.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1813.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1813.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1813.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1813.ExtendedProperties.Add("Deklarit.InternalName", "P1813");
                this.Columns.Add(this.columnP1813);
                this.columnP1821 = new DataColumn("P1821", typeof(decimal), "", MappingType.Element);
                this.columnP1821.Caption = "P1821";
                this.columnP1821.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1821.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1821.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1821.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1821.ExtendedProperties.Add("IsKey", "false");
                this.columnP1821.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1821.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1821.ExtendedProperties.Add("Description", "P1821");
                this.columnP1821.ExtendedProperties.Add("Length", "12");
                this.columnP1821.ExtendedProperties.Add("Decimals", "2");
                this.columnP1821.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1821.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1821.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1821.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1821.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1821.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1821.ExtendedProperties.Add("Deklarit.InternalName", "P1821");
                this.Columns.Add(this.columnP1821);
                this.columnP1830 = new DataColumn("P1830", typeof(decimal), "", MappingType.Element);
                this.columnP1830.Caption = "P1830";
                this.columnP1830.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1830.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1830.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1830.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1830.ExtendedProperties.Add("IsKey", "false");
                this.columnP1830.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1830.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1830.ExtendedProperties.Add("Description", "P1830");
                this.columnP1830.ExtendedProperties.Add("Length", "12");
                this.columnP1830.ExtendedProperties.Add("Decimals", "2");
                this.columnP1830.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1830.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1830.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1830.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1830.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1830.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1830.ExtendedProperties.Add("Deklarit.InternalName", "P1830");
                this.Columns.Add(this.columnP1830);
                this.columnP1848 = new DataColumn("P1848", typeof(decimal), "", MappingType.Element);
                this.columnP1848.Caption = "P1848";
                this.columnP1848.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnP1848.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnP1848.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnP1848.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnP1848.ExtendedProperties.Add("IsKey", "false");
                this.columnP1848.ExtendedProperties.Add("ReadOnly", "true");
                this.columnP1848.ExtendedProperties.Add("DeklaritType", "int");
                this.columnP1848.ExtendedProperties.Add("Description", "P1848");
                this.columnP1848.ExtendedProperties.Add("Length", "12");
                this.columnP1848.ExtendedProperties.Add("Decimals", "2");
                this.columnP1848.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnP1848.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnP1848.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnP1848.ExtendedProperties.Add("IsInReader", "true");
                this.columnP1848.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnP1848.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnP1848.ExtendedProperties.Add("Deklarit.InternalName", "P1848");
                this.Columns.Add(this.columnP1848);
                this.columnDDJMBG = new DataColumn("DDJMBG", typeof(string), "", MappingType.Element);
                this.columnDDJMBG.Caption = "JMBG";
                this.columnDDJMBG.MaxLength = 13;
                this.columnDDJMBG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDJMBG.ExtendedProperties.Add("IsKey", "false");
                this.columnDDJMBG.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDJMBG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDJMBG.ExtendedProperties.Add("Description", "JMBG");
                this.columnDDJMBG.ExtendedProperties.Add("Length", "13");
                this.columnDDJMBG.ExtendedProperties.Add("Decimals", "0");
                this.columnDDJMBG.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDJMBG.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDJMBG.ExtendedProperties.Add("Deklarit.InternalName", "DDJMBG");
                this.Columns.Add(this.columnDDJMBG);
                this.columnDDOIB = new DataColumn("DDOIB", typeof(string), "", MappingType.Element);
                this.columnDDOIB.Caption = "OIB";
                this.columnDDOIB.MaxLength = 11;
                this.columnDDOIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDOIB.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOIB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDOIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOIB.ExtendedProperties.Add("Description", "OIB");
                this.columnDDOIB.ExtendedProperties.Add("Length", "11");
                this.columnDDOIB.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOIB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDOIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.InternalName", "DDOIB");
                this.Columns.Add(this.columnDDOIB);
                this.columnDDOZNACEN = new DataColumn("DDOZNACEN", typeof(bool), "", MappingType.Element);
                this.columnDDOZNACEN.Caption = "Označen";
                this.columnDDOZNACEN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOZNACEN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOZNACEN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOZNACEN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDOZNACEN.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOZNACEN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDOZNACEN.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnDDOZNACEN.ExtendedProperties.Add("Description", "Označen");
                this.columnDDOZNACEN.ExtendedProperties.Add("Length", "1");
                this.columnDDOZNACEN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOZNACEN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDOZNACEN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOZNACEN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOZNACEN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOZNACEN.ExtendedProperties.Add("Deklarit.InternalName", "DDOZNACEN");
                this.Columns.Add(this.columnDDOZNACEN);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_DD_IP1");
                this.ExtendedProperties.Add("Description", "S_DD_IP1");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnDDIDRADNIK = this.Columns["DDIDRADNIK"];
                this.columnDDPREZIME = this.Columns["DDPREZIME"];
                this.columnDDIME = this.Columns["DDIME"];
                this.columnBRUTO = this.Columns["BRUTO"];
                this.columnIZDACI = this.Columns["IZDACI"];
                this.columnDOPRINOSIIZ = this.Columns["DOPRINOSIIZ"];
                this.columnPOREZIPRIREZ = this.Columns["POREZIPRIREZ"];
                this.columnNETO = this.Columns["NETO"];
                this.columnOPCINASTANOVANJAIDOPCINE = this.Columns["OPCINASTANOVANJAIDOPCINE"];
                this.columnP1422 = this.Columns["P1422"];
                this.columnP1805 = this.Columns["P1805"];
                this.columnP1457 = this.Columns["P1457"];
                this.columnP1465 = this.Columns["P1465"];
                this.columnP1473 = this.Columns["P1473"];
                this.columnP1546 = this.Columns["P1546"];
                this.columnP1570 = this.Columns["P1570"];
                this.columnP1589 = this.Columns["P1589"];
                this.columnP1597 = this.Columns["P1597"];
                this.columnP1600 = this.Columns["P1600"];
                this.columnP1813 = this.Columns["P1813"];
                this.columnP1821 = this.Columns["P1821"];
                this.columnP1830 = this.Columns["P1830"];
                this.columnP1848 = this.Columns["P1848"];
                this.columnDDJMBG = this.Columns["DDJMBG"];
                this.columnDDOIB = this.Columns["DDOIB"];
                this.columnDDOZNACEN = this.Columns["DDOZNACEN"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_DD_IP1DataSet.S_DD_IP1Row(builder);
            }

            public S_DD_IP1DataSet.S_DD_IP1Row NewS_DD_IP1Row()
            {
                return (S_DD_IP1DataSet.S_DD_IP1Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_DD_IP1RowChanged != null)
                {
                    S_DD_IP1DataSet.S_DD_IP1RowChangeEventHandler handler = this.S_DD_IP1RowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_DD_IP1DataSet.S_DD_IP1RowChangeEvent((S_DD_IP1DataSet.S_DD_IP1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_DD_IP1RowChanging != null)
                {
                    S_DD_IP1DataSet.S_DD_IP1RowChangeEventHandler handler = this.S_DD_IP1RowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_DD_IP1DataSet.S_DD_IP1RowChangeEvent((S_DD_IP1DataSet.S_DD_IP1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_DD_IP1RowDeleted != null)
                {
                    S_DD_IP1DataSet.S_DD_IP1RowChangeEventHandler handler = this.S_DD_IP1RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_DD_IP1DataSet.S_DD_IP1RowChangeEvent((S_DD_IP1DataSet.S_DD_IP1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_DD_IP1RowDeleting != null)
                {
                    S_DD_IP1DataSet.S_DD_IP1RowChangeEventHandler handler = this.S_DD_IP1RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_DD_IP1DataSet.S_DD_IP1RowChangeEvent((S_DD_IP1DataSet.S_DD_IP1Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_DD_IP1Row(S_DD_IP1DataSet.S_DD_IP1Row row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BRUTOColumn
            {
                get
                {
                    return this.columnBRUTO;
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

            public DataColumn DDIDRADNIKColumn
            {
                get
                {
                    return this.columnDDIDRADNIK;
                }
            }

            public DataColumn DDIMEColumn
            {
                get
                {
                    return this.columnDDIME;
                }
            }

            public DataColumn DDJMBGColumn
            {
                get
                {
                    return this.columnDDJMBG;
                }
            }

            public DataColumn DDOIBColumn
            {
                get
                {
                    return this.columnDDOIB;
                }
            }

            public DataColumn DDOZNACENColumn
            {
                get
                {
                    return this.columnDDOZNACEN;
                }
            }

            public DataColumn DDPREZIMEColumn
            {
                get
                {
                    return this.columnDDPREZIME;
                }
            }

            public DataColumn DOPRINOSIIZColumn
            {
                get
                {
                    return this.columnDOPRINOSIIZ;
                }
            }

            public S_DD_IP1DataSet.S_DD_IP1Row this[int index]
            {
                get
                {
                    return (S_DD_IP1DataSet.S_DD_IP1Row) this.Rows[index];
                }
            }

            public DataColumn IZDACIColumn
            {
                get
                {
                    return this.columnIZDACI;
                }
            }

            public DataColumn NETOColumn
            {
                get
                {
                    return this.columnNETO;
                }
            }

            public DataColumn OPCINASTANOVANJAIDOPCINEColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAIDOPCINE;
                }
            }

            public DataColumn P1422Column
            {
                get
                {
                    return this.columnP1422;
                }
            }

            public DataColumn P1457Column
            {
                get
                {
                    return this.columnP1457;
                }
            }

            public DataColumn P1465Column
            {
                get
                {
                    return this.columnP1465;
                }
            }

            public DataColumn P1473Column
            {
                get
                {
                    return this.columnP1473;
                }
            }

            public DataColumn P1546Column
            {
                get
                {
                    return this.columnP1546;
                }
            }

            public DataColumn P1570Column
            {
                get
                {
                    return this.columnP1570;
                }
            }

            public DataColumn P1589Column
            {
                get
                {
                    return this.columnP1589;
                }
            }

            public DataColumn P1597Column
            {
                get
                {
                    return this.columnP1597;
                }
            }

            public DataColumn P1600Column
            {
                get
                {
                    return this.columnP1600;
                }
            }

            public DataColumn P1805Column
            {
                get
                {
                    return this.columnP1805;
                }
            }

            public DataColumn P1813Column
            {
                get
                {
                    return this.columnP1813;
                }
            }

            public DataColumn P1821Column
            {
                get
                {
                    return this.columnP1821;
                }
            }

            public DataColumn P1830Column
            {
                get
                {
                    return this.columnP1830;
                }
            }

            public DataColumn P1848Column
            {
                get
                {
                    return this.columnP1848;
                }
            }

            public DataColumn POREZIPRIREZColumn
            {
                get
                {
                    return this.columnPOREZIPRIREZ;
                }
            }
        }

        public class S_DD_IP1Row : DataRow
        {
            private S_DD_IP1DataSet.S_DD_IP1DataTable tableS_DD_IP1;

            internal S_DD_IP1Row(DataRowBuilder rb) : base(rb)
            {
                this.tableS_DD_IP1 = (S_DD_IP1DataSet.S_DD_IP1DataTable) this.Table;
            }

            public bool IsBRUTONull()
            {
                return this.IsNull(this.tableS_DD_IP1.BRUTOColumn);
            }

            public bool IsDDIDRADNIKNull()
            {
                return this.IsNull(this.tableS_DD_IP1.DDIDRADNIKColumn);
            }

            public bool IsDDIMENull()
            {
                return this.IsNull(this.tableS_DD_IP1.DDIMEColumn);
            }

            public bool IsDDJMBGNull()
            {
                return this.IsNull(this.tableS_DD_IP1.DDJMBGColumn);
            }

            public bool IsDDOIBNull()
            {
                return this.IsNull(this.tableS_DD_IP1.DDOIBColumn);
            }

            public bool IsDDOZNACENNull()
            {
                return this.IsNull(this.tableS_DD_IP1.DDOZNACENColumn);
            }

            public bool IsDDPREZIMENull()
            {
                return this.IsNull(this.tableS_DD_IP1.DDPREZIMEColumn);
            }

            public bool IsDOPRINOSIIZNull()
            {
                return this.IsNull(this.tableS_DD_IP1.DOPRINOSIIZColumn);
            }

            public bool IsIZDACINull()
            {
                return this.IsNull(this.tableS_DD_IP1.IZDACIColumn);
            }

            public bool IsNETONull()
            {
                return this.IsNull(this.tableS_DD_IP1.NETOColumn);
            }

            public bool IsOPCINASTANOVANJAIDOPCINENull()
            {
                return this.IsNull(this.tableS_DD_IP1.OPCINASTANOVANJAIDOPCINEColumn);
            }

            public bool IsP1422Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1422Column);
            }

            public bool IsP1457Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1457Column);
            }

            public bool IsP1465Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1465Column);
            }

            public bool IsP1473Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1473Column);
            }

            public bool IsP1546Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1546Column);
            }

            public bool IsP1570Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1570Column);
            }

            public bool IsP1589Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1589Column);
            }

            public bool IsP1597Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1597Column);
            }

            public bool IsP1600Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1600Column);
            }

            public bool IsP1805Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1805Column);
            }

            public bool IsP1813Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1813Column);
            }

            public bool IsP1821Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1821Column);
            }

            public bool IsP1830Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1830Column);
            }

            public bool IsP1848Null()
            {
                return this.IsNull(this.tableS_DD_IP1.P1848Column);
            }

            public bool IsPOREZIPRIREZNull()
            {
                return this.IsNull(this.tableS_DD_IP1.POREZIPRIREZColumn);
            }

            public void SetBRUTONull()
            {
                this[this.tableS_DD_IP1.BRUTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDIDRADNIKNull()
            {
                this[this.tableS_DD_IP1.DDIDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDIMENull()
            {
                this[this.tableS_DD_IP1.DDIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDJMBGNull()
            {
                this[this.tableS_DD_IP1.DDJMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOIBNull()
            {
                this[this.tableS_DD_IP1.DDOIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOZNACENNull()
            {
                this[this.tableS_DD_IP1.DDOZNACENColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPREZIMENull()
            {
                this[this.tableS_DD_IP1.DDPREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOPRINOSIIZNull()
            {
                this[this.tableS_DD_IP1.DOPRINOSIIZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZDACINull()
            {
                this[this.tableS_DD_IP1.IZDACIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNETONull()
            {
                this[this.tableS_DD_IP1.NETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAIDOPCINENull()
            {
                this[this.tableS_DD_IP1.OPCINASTANOVANJAIDOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1422Null()
            {
                this[this.tableS_DD_IP1.P1422Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1457Null()
            {
                this[this.tableS_DD_IP1.P1457Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1465Null()
            {
                this[this.tableS_DD_IP1.P1465Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1473Null()
            {
                this[this.tableS_DD_IP1.P1473Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1546Null()
            {
                this[this.tableS_DD_IP1.P1546Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1570Null()
            {
                this[this.tableS_DD_IP1.P1570Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1589Null()
            {
                this[this.tableS_DD_IP1.P1589Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1597Null()
            {
                this[this.tableS_DD_IP1.P1597Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1600Null()
            {
                this[this.tableS_DD_IP1.P1600Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1805Null()
            {
                this[this.tableS_DD_IP1.P1805Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1813Null()
            {
                this[this.tableS_DD_IP1.P1813Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1821Null()
            {
                this[this.tableS_DD_IP1.P1821Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1830Null()
            {
                this[this.tableS_DD_IP1.P1830Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetP1848Null()
            {
                this[this.tableS_DD_IP1.P1848Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZIPRIREZNull()
            {
                this[this.tableS_DD_IP1.POREZIPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal BRUTO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.BRUTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BRUTO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.BRUTOColumn] = value;
                }
            }

            public int DDIDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_DD_IP1.DDIDRADNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDIDRADNIK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.DDIDRADNIKColumn] = value;
                }
            }

            public string DDIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_IP1.DDIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDIME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_IP1.DDIMEColumn] = value;
                }
            }

            public string DDJMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_IP1.DDJMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDJMBG because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_IP1.DDJMBGColumn] = value;
                }
            }

            public string DDOIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_IP1.DDOIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDOIB because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_IP1.DDOIBColumn] = value;
                }
            }

            public bool DDOZNACEN
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableS_DD_IP1.DDOZNACENColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDOZNACEN because it is DBNull.", innerException);
                    }
                    return flag;
                }
                set
                {
                    this[this.tableS_DD_IP1.DDOZNACENColumn] = value;
                }
            }

            public string DDPREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_IP1.DDPREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDPREZIME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_IP1.DDPREZIMEColumn] = value;
                }
            }

            public decimal DOPRINOSIIZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.DOPRINOSIIZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DOPRINOSIIZ because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.DOPRINOSIIZColumn] = value;
                }
            }

            public decimal IZDACI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.IZDACIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IZDACI because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.IZDACIColumn] = value;
                }
            }

            public decimal NETO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.NETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NETO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.NETOColumn] = value;
                }
            }

            public string OPCINASTANOVANJAIDOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_IP1.OPCINASTANOVANJAIDOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OPCINASTANOVANJAIDOPCINE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_IP1.OPCINASTANOVANJAIDOPCINEColumn] = value;
                }
            }

            public decimal P1422
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1422Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value P1422 because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1422Column] = value;
                }
            }

            public decimal P1457
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1457Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1457Column] = value;
                }
            }

            public decimal P1465
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1465Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1465Column] = value;
                }
            }

            public decimal P1473
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1473Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1473Column] = value;
                }
            }

            public decimal P1546
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1546Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1546Column] = value;
                }
            }

            public decimal P1570
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1570Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1570Column] = value;
                }
            }

            public decimal P1589
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1589Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1589Column] = value;
                }
            }

            public decimal P1597
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1597Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1597Column] = value;
                }
            }

            public decimal P1600
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1600Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1600Column] = value;
                }
            }

            public decimal P1805
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1805Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1805Column] = value;
                }
            }

            public decimal P1813
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1813Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1813Column] = value;
                }
            }

            public decimal P1821
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1821Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1821Column] = value;
                }
            }

            public decimal P1830
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1830Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1830Column] = value;
                }
            }

            public decimal P1848
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.P1848Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.P1848Column] = value;
                }
            }

            public decimal POREZIPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IP1.POREZIPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IP1.POREZIPRIREZColumn] = value;
                }
            }
        }

        public class S_DD_IP1RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_DD_IP1DataSet.S_DD_IP1Row eventRow;

            public S_DD_IP1RowChangeEvent(S_DD_IP1DataSet.S_DD_IP1Row row, DataRowAction action)
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

            public S_DD_IP1DataSet.S_DD_IP1Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_DD_IP1RowChangeEventHandler(object sender, S_DD_IP1DataSet.S_DD_IP1RowChangeEvent e);
    }
}

