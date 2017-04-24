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
    public class S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA;

        public S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA"] != null)
                    {
                        this.Tables.Add(new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable(dataSet.Tables["S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA"]));
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
            S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet set = (S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet) base.Clone();
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
            S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet set = new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2195");
            this.ExtendedProperties.Add("DataSetName", "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA");
            this.ExtendedProperties.Add("ObjectDescription", "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\OSNOVNA");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA");
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
            this.DataSetName = "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet";
            this.Namespace = "http://www.tempuri.org/S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA";
            this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA = new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable();
            this.Tables.Add(this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA);
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
            this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA = (S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable) this.Tables["S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA"];
            if (initTable && (this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA != null))
            {
                this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA"] != null)
                {
                    this.Tables.Add(new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable(dataSet.Tables["S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA"]));
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

        private bool ShouldSerializeS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA()
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
        public S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA
        {
            get
            {
                return this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA;
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
        public class S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOSDOKUMENT;
            private DataColumn columnISPRAVAK;
            private DataColumn columnISPRAVAKPRETHODNIH;
            private DataColumn columnKTOISPRAVKAIDKONTO;
            private DataColumn columnKTOIZVORAIDKONTO;
            private DataColumn columnKTONABAVKEIDKONTO;
            private DataColumn columnNAZIVKONTO;
            private DataColumn columnOSBROJDOKUMENTA;
            private DataColumn columnOSKOLICINA;
            private DataColumn columnOSOPIS;
            private DataColumn columnOSOSNOVICA;
            private DataColumn columnOSSTOPA;

            public event S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEventHandler S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChanged;

            public event S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEventHandler S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChanging;

            public event S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEventHandler S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowDeleted;

            public event S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEventHandler S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowDeleting;

            public S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable()
            {
                this.TableName = "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable(DataTable table) : base(table.TableName)
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

            protected S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow(S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow row)
            {
                this.Rows.Add(row);
            }

            public S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow AddS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow(string oSOPIS, int iDOSDOKUMENT, int oSBROJDOKUMENTA, decimal oSKOLICINA, decimal oSSTOPA, decimal oSOSNOVICA, decimal iSPRAVAK, decimal iSPRAVAKPRETHODNIH, string kTONABAVKEIDKONTO, string kTOISPRAVKAIDKONTO, string kTOIZVORAIDKONTO, string nAZIVKONTO)
            {
                S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow row = (S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow) this.NewRow();
                row.ItemArray = new object[] { oSOPIS, iDOSDOKUMENT, oSBROJDOKUMENTA, oSKOLICINA, oSSTOPA, oSOSNOVICA, iSPRAVAK, iSPRAVAKPRETHODNIH, kTONABAVKEIDKONTO, kTOISPRAVKAIDKONTO, kTOIZVORAIDKONTO, nAZIVKONTO };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable table = (S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet set = new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet();
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
                this.columnOSKOLICINA = new DataColumn("OSKOLICINA", typeof(decimal), "", MappingType.Element);
                this.columnOSKOLICINA.Caption = "OSKOLICINA";
                this.columnOSKOLICINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSKOLICINA.ExtendedProperties.Add("IsKey", "false");
                this.columnOSKOLICINA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSKOLICINA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSKOLICINA.ExtendedProperties.Add("Description", "OSKOLICINA");
                this.columnOSKOLICINA.ExtendedProperties.Add("Length", "12");
                this.columnOSKOLICINA.ExtendedProperties.Add("Decimals", "2");
                this.columnOSKOLICINA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSKOLICINA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSKOLICINA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSKOLICINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.InternalName", "OSKOLICINA");
                this.Columns.Add(this.columnOSKOLICINA);
                this.columnOSSTOPA = new DataColumn("OSSTOPA", typeof(decimal), "", MappingType.Element);
                this.columnOSSTOPA.Caption = "OSSTOPA";
                this.columnOSSTOPA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSSTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnOSSTOPA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSSTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSSTOPA.ExtendedProperties.Add("Description", "OSSTOPA");
                this.columnOSSTOPA.ExtendedProperties.Add("Length", "5");
                this.columnOSSTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnOSSTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSSTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnOSSTOPA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSSTOPA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.InternalName", "OSSTOPA");
                this.Columns.Add(this.columnOSSTOPA);
                this.columnOSOSNOVICA = new DataColumn("OSOSNOVICA", typeof(decimal), "", MappingType.Element);
                this.columnOSOSNOVICA.Caption = "OSOSNOVICA";
                this.columnOSOSNOVICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSOSNOVICA.ExtendedProperties.Add("IsKey", "false");
                this.columnOSOSNOVICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSOSNOVICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Description", "OSOSNOVICA");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Length", "12");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Decimals", "2");
                this.columnOSOSNOVICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSOSNOVICA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSOSNOVICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSOSNOVICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.InternalName", "OSOSNOVICA");
                this.Columns.Add(this.columnOSOSNOVICA);
                this.columnISPRAVAK = new DataColumn("ISPRAVAK", typeof(decimal), "", MappingType.Element);
                this.columnISPRAVAK.Caption = "Ispravak";
                this.columnISPRAVAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnISPRAVAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnISPRAVAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnISPRAVAK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnISPRAVAK.ExtendedProperties.Add("IsKey", "false");
                this.columnISPRAVAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnISPRAVAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnISPRAVAK.ExtendedProperties.Add("Description", "Ispravak");
                this.columnISPRAVAK.ExtendedProperties.Add("Length", "12");
                this.columnISPRAVAK.ExtendedProperties.Add("Decimals", "2");
                this.columnISPRAVAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnISPRAVAK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnISPRAVAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnISPRAVAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnISPRAVAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnISPRAVAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnISPRAVAK.ExtendedProperties.Add("Deklarit.InternalName", "ISPRAVAK");
                this.Columns.Add(this.columnISPRAVAK);
                this.columnISPRAVAKPRETHODNIH = new DataColumn("ISPRAVAKPRETHODNIH", typeof(decimal), "", MappingType.Element);
                this.columnISPRAVAKPRETHODNIH.Caption = "ISPRAVAKPRETHODNIH";
                this.columnISPRAVAKPRETHODNIH.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("IsKey", "false");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("ReadOnly", "true");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("DeklaritType", "int");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("Description", "ISPRAVAKPRETHODNIH");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("Length", "12");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("Decimals", "2");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("IsInReader", "true");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnISPRAVAKPRETHODNIH.ExtendedProperties.Add("Deklarit.InternalName", "ISPRAVAKPRETHODNIH");
                this.Columns.Add(this.columnISPRAVAKPRETHODNIH);
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
                this.columnNAZIVKONTO = new DataColumn("NAZIVKONTO", typeof(string), "", MappingType.Element);
                this.columnNAZIVKONTO.Caption = "Naziv konta";
                this.columnNAZIVKONTO.MaxLength = 150;
                this.columnNAZIVKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Description", "Naziv konta");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Length", "150");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKONTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKONTO");
                this.Columns.Add(this.columnNAZIVKONTO);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA");
                this.ExtendedProperties.Add("Description", "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnOSOPIS = this.Columns["OSOPIS"];
                this.columnIDOSDOKUMENT = this.Columns["IDOSDOKUMENT"];
                this.columnOSBROJDOKUMENTA = this.Columns["OSBROJDOKUMENTA"];
                this.columnOSKOLICINA = this.Columns["OSKOLICINA"];
                this.columnOSSTOPA = this.Columns["OSSTOPA"];
                this.columnOSOSNOVICA = this.Columns["OSOSNOVICA"];
                this.columnISPRAVAK = this.Columns["ISPRAVAK"];
                this.columnISPRAVAKPRETHODNIH = this.Columns["ISPRAVAKPRETHODNIH"];
                this.columnKTONABAVKEIDKONTO = this.Columns["KTONABAVKEIDKONTO"];
                this.columnKTOISPRAVKAIDKONTO = this.Columns["KTOISPRAVKAIDKONTO"];
                this.columnKTOIZVORAIDKONTO = this.Columns["KTOIZVORAIDKONTO"];
                this.columnNAZIVKONTO = this.Columns["NAZIVKONTO"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow(builder);
            }

            public S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow NewS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow()
            {
                return (S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChanged != null)
                {
                    S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEventHandler handler = this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEvent((S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChanging != null)
                {
                    S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEventHandler handler = this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEvent((S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowDeleted != null)
                {
                    S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEventHandler handler = this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEvent((S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowDeleting != null)
                {
                    S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEventHandler handler = this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEvent((S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow(S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow row)
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

            public DataColumn ISPRAVAKColumn
            {
                get
                {
                    return this.columnISPRAVAK;
                }
            }

            public DataColumn ISPRAVAKPRETHODNIHColumn
            {
                get
                {
                    return this.columnISPRAVAKPRETHODNIH;
                }
            }

            public S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow this[int index]
            {
                get
                {
                    return (S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow) this.Rows[index];
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

            public DataColumn NAZIVKONTOColumn
            {
                get
                {
                    return this.columnNAZIVKONTO;
                }
            }

            public DataColumn OSBROJDOKUMENTAColumn
            {
                get
                {
                    return this.columnOSBROJDOKUMENTA;
                }
            }

            public DataColumn OSKOLICINAColumn
            {
                get
                {
                    return this.columnOSKOLICINA;
                }
            }

            public DataColumn OSOPISColumn
            {
                get
                {
                    return this.columnOSOPIS;
                }
            }

            public DataColumn OSOSNOVICAColumn
            {
                get
                {
                    return this.columnOSOSNOVICA;
                }
            }

            public DataColumn OSSTOPAColumn
            {
                get
                {
                    return this.columnOSSTOPA;
                }
            }
        }

        public class S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow : DataRow
        {
            private S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA;

            internal S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA = (S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataTable) this.Table;
            }

            public bool IsIDOSDOKUMENTNull()
            {
                return this.IsNull(this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.IDOSDOKUMENTColumn);
            }

            public bool IsISPRAVAKNull()
            {
                return this.IsNull(this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.ISPRAVAKColumn);
            }

            public bool IsISPRAVAKPRETHODNIHNull()
            {
                return this.IsNull(this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.ISPRAVAKPRETHODNIHColumn);
            }

            public bool IsKTOISPRAVKAIDKONTONull()
            {
                return this.IsNull(this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.KTOISPRAVKAIDKONTOColumn);
            }

            public bool IsKTOIZVORAIDKONTONull()
            {
                return this.IsNull(this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.KTOIZVORAIDKONTOColumn);
            }

            public bool IsKTONABAVKEIDKONTONull()
            {
                return this.IsNull(this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.KTONABAVKEIDKONTOColumn);
            }

            public bool IsNAZIVKONTONull()
            {
                return this.IsNull(this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.NAZIVKONTOColumn);
            }

            public bool IsOSBROJDOKUMENTANull()
            {
                return this.IsNull(this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSBROJDOKUMENTAColumn);
            }

            public bool IsOSKOLICINANull()
            {
                return this.IsNull(this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSKOLICINAColumn);
            }

            public bool IsOSOPISNull()
            {
                return this.IsNull(this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSOPISColumn);
            }

            public bool IsOSOSNOVICANull()
            {
                return this.IsNull(this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSOSNOVICAColumn);
            }

            public bool IsOSSTOPANull()
            {
                return this.IsNull(this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSSTOPAColumn);
            }

            public void SetIDOSDOKUMENTNull()
            {
                this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.IDOSDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetISPRAVAKNull()
            {
                this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.ISPRAVAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetISPRAVAKPRETHODNIHNull()
            {
                this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.ISPRAVAKPRETHODNIHColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTOISPRAVKAIDKONTONull()
            {
                this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.KTOISPRAVKAIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTOIZVORAIDKONTONull()
            {
                this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.KTOIZVORAIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTONABAVKEIDKONTONull()
            {
                this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.KTONABAVKEIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKONTONull()
            {
                this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.NAZIVKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSBROJDOKUMENTANull()
            {
                this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSBROJDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSKOLICINANull()
            {
                this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSKOLICINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSOPISNull()
            {
                this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSOPISColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSOSNOVICANull()
            {
                this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSOSNOVICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSSTOPANull()
            {
                this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSSTOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDOSDOKUMENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.IDOSDOKUMENTColumn]);
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
                    this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.IDOSDOKUMENTColumn] = value;
                }
            }

            public decimal ISPRAVAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.ISPRAVAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ISPRAVAK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.ISPRAVAKColumn] = value;
                }
            }

            public decimal ISPRAVAKPRETHODNIH
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.ISPRAVAKPRETHODNIHColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ISPRAVAKPRETHODNIH because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.ISPRAVAKPRETHODNIHColumn] = value;
                }
            }

            public string KTOISPRAVKAIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.KTOISPRAVKAIDKONTOColumn]);
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
                    this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.KTOISPRAVKAIDKONTOColumn] = value;
                }
            }

            public string KTOIZVORAIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.KTOIZVORAIDKONTOColumn]);
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
                    this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.KTOIZVORAIDKONTOColumn] = value;
                }
            }

            public string KTONABAVKEIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.KTONABAVKEIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.KTONABAVKEIDKONTOColumn] = value;
                }
            }

            public string NAZIVKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.NAZIVKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.NAZIVKONTOColumn] = value;
                }
            }

            public int OSBROJDOKUMENTA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSBROJDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSBROJDOKUMENTAColumn] = value;
                }
            }

            public decimal OSKOLICINA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSKOLICINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSKOLICINAColumn] = value;
                }
            }

            public string OSOPIS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSOPISColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSOPISColumn] = value;
                }
            }

            public decimal OSOSNOVICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSOSNOVICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSOSNOVICAColumn] = value;
                }
            }

            public decimal OSSTOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSSTOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.OSSTOPAColumn] = value;
                }
            }
        }

        public class S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow eventRow;

            public S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEvent(S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow row, DataRowAction action)
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

            public S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEventHandler(object sender, S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARowChangeEvent e);
    }
}

