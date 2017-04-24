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
    public class UCENIKOBRACUNDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private UCENIKOBRACUNDataTable tableUCENIKOBRACUN;
        private UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable tableUCENIKOBRACUNUCENIKOBRACUNDETAIL;

        public UCENIKOBRACUNDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected UCENIKOBRACUNDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["UCENIKOBRACUNUCENIKOBRACUNDETAIL"] != null)
                    {
                        this.Tables.Add(new UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable(dataSet.Tables["UCENIKOBRACUNUCENIKOBRACUNDETAIL"]));
                    }
                    if (dataSet.Tables["UCENIKOBRACUN"] != null)
                    {
                        this.Tables.Add(new UCENIKOBRACUNDataTable(dataSet.Tables["UCENIKOBRACUN"]));
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
            UCENIKOBRACUNDataSet set = (UCENIKOBRACUNDataSet) base.Clone();
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
            UCENIKOBRACUNDataSet set = new UCENIKOBRACUNDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "UCENIKOBRACUNDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2200");
            this.ExtendedProperties.Add("DataSetName", "UCENIKOBRACUNDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IUCENIKOBRACUNDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "UCENIKOBRACUN");
            this.ExtendedProperties.Add("ObjectDescription", "UCENIKOBRACUN");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\UcenickaPraksa");
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
            this.DataSetName = "UCENIKOBRACUNDataSet";
            this.Namespace = "http://www.tempuri.org/UCENIKOBRACUN";
            this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL = new UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable();
            this.Tables.Add(this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL);
            this.tableUCENIKOBRACUN = new UCENIKOBRACUNDataTable();
            this.Tables.Add(this.tableUCENIKOBRACUN);
            this.Relations.Add("UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL", new DataColumn[] { this.Tables["UCENIKOBRACUN"].Columns["UCOBRMJESEC"], this.Tables["UCENIKOBRACUN"].Columns["UCOBRGODINA"] }, new DataColumn[] { this.Tables["UCENIKOBRACUNUCENIKOBRACUNDETAIL"].Columns["UCOBRMJESEC"], this.Tables["UCENIKOBRACUNUCENIKOBRACUNDETAIL"].Columns["UCOBRGODINA"] });
            this.Relations["UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL"].Nested = true;
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
            this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL = (UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable) this.Tables["UCENIKOBRACUNUCENIKOBRACUNDETAIL"];
            this.tableUCENIKOBRACUN = (UCENIKOBRACUNDataTable) this.Tables["UCENIKOBRACUN"];
            if (initTable)
            {
                if (this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL != null)
                {
                    this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.InitVars();
                }
                if (this.tableUCENIKOBRACUN != null)
                {
                    this.tableUCENIKOBRACUN.InitVars();
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
                if (dataSet.Tables["UCENIKOBRACUNUCENIKOBRACUNDETAIL"] != null)
                {
                    this.Tables.Add(new UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable(dataSet.Tables["UCENIKOBRACUNUCENIKOBRACUNDETAIL"]));
                }
                if (dataSet.Tables["UCENIKOBRACUN"] != null)
                {
                    this.Tables.Add(new UCENIKOBRACUNDataTable(dataSet.Tables["UCENIKOBRACUN"]));
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

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        private bool ShouldSerializeUCENIKOBRACUN()
        {
            return false;
        }

        private bool ShouldSerializeUCENIKOBRACUNUCENIKOBRACUNDETAIL()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public UCENIKOBRACUNDataTable UCENIKOBRACUN
        {
            get
            {
                return this.tableUCENIKOBRACUN;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable UCENIKOBRACUNUCENIKOBRACUNDETAIL
        {
            get
            {
                return this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL;
            }
        }

        [Serializable]
        public class UCENIKOBRACUNDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAKTIVANZARSM;
            private DataColumn columnOSNOVICAPODANU;
            private DataColumn columnUCOBRGODINA;
            private DataColumn columnUCOBRMJESEC;
            private DataColumn columnUCOBROPIS;

            public event UCENIKOBRACUNDataSet.UCENIKOBRACUNRowChangeEventHandler UCENIKOBRACUNRowChanged;

            public event UCENIKOBRACUNDataSet.UCENIKOBRACUNRowChangeEventHandler UCENIKOBRACUNRowChanging;

            public event UCENIKOBRACUNDataSet.UCENIKOBRACUNRowChangeEventHandler UCENIKOBRACUNRowDeleted;

            public event UCENIKOBRACUNDataSet.UCENIKOBRACUNRowChangeEventHandler UCENIKOBRACUNRowDeleting;

            public UCENIKOBRACUNDataTable()
            {
                this.TableName = "UCENIKOBRACUN";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal UCENIKOBRACUNDataTable(DataTable table) : base(table.TableName)
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

            protected UCENIKOBRACUNDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddUCENIKOBRACUNRow(UCENIKOBRACUNDataSet.UCENIKOBRACUNRow row)
            {
                this.Rows.Add(row);
            }

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNRow AddUCENIKOBRACUNRow(int uCOBRMJESEC, int uCOBRGODINA, string uCOBROPIS, decimal oSNOVICAPODANU, bool aKTIVANZARSM)
            {
                UCENIKOBRACUNDataSet.UCENIKOBRACUNRow row = (UCENIKOBRACUNDataSet.UCENIKOBRACUNRow) this.NewRow();
                row["UCOBRMJESEC"] = uCOBRMJESEC;
                row["UCOBRGODINA"] = uCOBRGODINA;
                row["UCOBROPIS"] = uCOBROPIS;
                row["OSNOVICAPODANU"] = oSNOVICAPODANU;
                row["AKTIVANZARSM"] = aKTIVANZARSM;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                UCENIKOBRACUNDataSet.UCENIKOBRACUNDataTable table = (UCENIKOBRACUNDataSet.UCENIKOBRACUNDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNRow FindByUCOBRMJESECUCOBRGODINA(int uCOBRMJESEC, int uCOBRGODINA)
            {
                return (UCENIKOBRACUNDataSet.UCENIKOBRACUNRow) this.Rows.Find(new object[] { uCOBRMJESEC, uCOBRGODINA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(UCENIKOBRACUNDataSet.UCENIKOBRACUNRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                UCENIKOBRACUNDataSet set = new UCENIKOBRACUNDataSet();
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
                this.columnUCOBRMJESEC = new DataColumn("UCOBRMJESEC", typeof(int), "", MappingType.Element);
                this.columnUCOBRMJESEC.AllowDBNull = false;
                this.columnUCOBRMJESEC.Caption = "UCOBRMJESEC";
                this.columnUCOBRMJESEC.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("IsKey", "true");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("ReadOnly", "false");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Description", "Mjesec");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Length", "5");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Decimals", "0");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("IsInReader", "true");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.InternalName", "UCOBRMJESEC");
                this.Columns.Add(this.columnUCOBRMJESEC);
                this.columnUCOBRGODINA = new DataColumn("UCOBRGODINA", typeof(int), "", MappingType.Element);
                this.columnUCOBRGODINA.AllowDBNull = false;
                this.columnUCOBRGODINA.Caption = "UCOBRGODINA";
                this.columnUCOBRGODINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUCOBRGODINA.ExtendedProperties.Add("IsKey", "true");
                this.columnUCOBRGODINA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnUCOBRGODINA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Description", "Godina");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Length", "5");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Decimals", "0");
                this.columnUCOBRGODINA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnUCOBRGODINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.InternalName", "UCOBRGODINA");
                this.Columns.Add(this.columnUCOBRGODINA);
                this.columnUCOBROPIS = new DataColumn("UCOBROPIS", typeof(string), "", MappingType.Element);
                this.columnUCOBROPIS.AllowDBNull = false;
                this.columnUCOBROPIS.Caption = "UCOBROPIS";
                this.columnUCOBROPIS.MaxLength = 50;
                this.columnUCOBROPIS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUCOBROPIS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUCOBROPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUCOBROPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUCOBROPIS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUCOBROPIS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUCOBROPIS.ExtendedProperties.Add("IsKey", "false");
                this.columnUCOBROPIS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnUCOBROPIS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnUCOBROPIS.ExtendedProperties.Add("Description", "Opis obračuna");
                this.columnUCOBROPIS.ExtendedProperties.Add("Length", "50");
                this.columnUCOBROPIS.ExtendedProperties.Add("Decimals", "0");
                this.columnUCOBROPIS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnUCOBROPIS.ExtendedProperties.Add("IsInReader", "true");
                this.columnUCOBROPIS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUCOBROPIS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUCOBROPIS.ExtendedProperties.Add("Deklarit.InternalName", "UCOBROPIS");
                this.Columns.Add(this.columnUCOBROPIS);
                this.columnOSNOVICAPODANU = new DataColumn("OSNOVICAPODANU", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICAPODANU.AllowDBNull = false;
                this.columnOSNOVICAPODANU.Caption = "OSNOVICAPODANU";
                this.columnOSNOVICAPODANU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("Description", "Osnovica po danu za mjesec");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAPODANU.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAPODANU");
                this.Columns.Add(this.columnOSNOVICAPODANU);
                this.columnAKTIVANZARSM = new DataColumn("AKTIVANZARSM", typeof(bool), "", MappingType.Element);
                this.columnAKTIVANZARSM.AllowDBNull = false;
                this.columnAKTIVANZARSM.Caption = "AKTIVANZARSM";
                this.columnAKTIVANZARSM.DefaultValue = false;
                this.columnAKTIVANZARSM.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("IsKey", "false");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("ReadOnly", "false");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("Description", "AKTIVANZARSM");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("Length", "1");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("Decimals", "0");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("IsInReader", "true");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnAKTIVANZARSM.ExtendedProperties.Add("Deklarit.InternalName", "AKTIVANZARSM");
                this.Columns.Add(this.columnAKTIVANZARSM);
                this.PrimaryKey = new DataColumn[] { this.columnUCOBRMJESEC, this.columnUCOBRGODINA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "UCENIKOBRACUN");
                this.ExtendedProperties.Add("Description", "UCENIKOBRACUN");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnUCOBRMJESEC = this.Columns["UCOBRMJESEC"];
                this.columnUCOBRGODINA = this.Columns["UCOBRGODINA"];
                this.columnUCOBROPIS = this.Columns["UCOBROPIS"];
                this.columnOSNOVICAPODANU = this.Columns["OSNOVICAPODANU"];
                this.columnAKTIVANZARSM = this.Columns["AKTIVANZARSM"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new UCENIKOBRACUNDataSet.UCENIKOBRACUNRow(builder);
            }

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNRow NewUCENIKOBRACUNRow()
            {
                return (UCENIKOBRACUNDataSet.UCENIKOBRACUNRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.UCENIKOBRACUNRowChanged != null)
                {
                    UCENIKOBRACUNDataSet.UCENIKOBRACUNRowChangeEventHandler uCENIKOBRACUNRowChangedEvent = this.UCENIKOBRACUNRowChanged;
                    if (uCENIKOBRACUNRowChangedEvent != null)
                    {
                        uCENIKOBRACUNRowChangedEvent(this, new UCENIKOBRACUNDataSet.UCENIKOBRACUNRowChangeEvent((UCENIKOBRACUNDataSet.UCENIKOBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.UCENIKOBRACUNRowChanging != null)
                {
                    UCENIKOBRACUNDataSet.UCENIKOBRACUNRowChangeEventHandler uCENIKOBRACUNRowChangingEvent = this.UCENIKOBRACUNRowChanging;
                    if (uCENIKOBRACUNRowChangingEvent != null)
                    {
                        uCENIKOBRACUNRowChangingEvent(this, new UCENIKOBRACUNDataSet.UCENIKOBRACUNRowChangeEvent((UCENIKOBRACUNDataSet.UCENIKOBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.UCENIKOBRACUNRowDeleted != null)
                {
                    UCENIKOBRACUNDataSet.UCENIKOBRACUNRowChangeEventHandler uCENIKOBRACUNRowDeletedEvent = this.UCENIKOBRACUNRowDeleted;
                    if (uCENIKOBRACUNRowDeletedEvent != null)
                    {
                        uCENIKOBRACUNRowDeletedEvent(this, new UCENIKOBRACUNDataSet.UCENIKOBRACUNRowChangeEvent((UCENIKOBRACUNDataSet.UCENIKOBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.UCENIKOBRACUNRowDeleting != null)
                {
                    UCENIKOBRACUNDataSet.UCENIKOBRACUNRowChangeEventHandler uCENIKOBRACUNRowDeletingEvent = this.UCENIKOBRACUNRowDeleting;
                    if (uCENIKOBRACUNRowDeletingEvent != null)
                    {
                        uCENIKOBRACUNRowDeletingEvent(this, new UCENIKOBRACUNDataSet.UCENIKOBRACUNRowChangeEvent((UCENIKOBRACUNDataSet.UCENIKOBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveUCENIKOBRACUNRow(UCENIKOBRACUNDataSet.UCENIKOBRACUNRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn AKTIVANZARSMColumn
            {
                get
                {
                    return this.columnAKTIVANZARSM;
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

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNRow this[int index]
            {
                get
                {
                    return (UCENIKOBRACUNDataSet.UCENIKOBRACUNRow) this.Rows[index];
                }
            }

            public DataColumn OSNOVICAPODANUColumn
            {
                get
                {
                    return this.columnOSNOVICAPODANU;
                }
            }

            public DataColumn UCOBRGODINAColumn
            {
                get
                {
                    return this.columnUCOBRGODINA;
                }
            }

            public DataColumn UCOBRMJESECColumn
            {
                get
                {
                    return this.columnUCOBRMJESEC;
                }
            }

            public DataColumn UCOBROPISColumn
            {
                get
                {
                    return this.columnUCOBROPIS;
                }
            }
        }

        public class UCENIKOBRACUNRow : DataRow
        {
            private UCENIKOBRACUNDataSet.UCENIKOBRACUNDataTable tableUCENIKOBRACUN;

            internal UCENIKOBRACUNRow(DataRowBuilder rb) : base(rb)
            {
                this.tableUCENIKOBRACUN = (UCENIKOBRACUNDataSet.UCENIKOBRACUNDataTable) this.Table;
            }

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow[] GetUCENIKOBRACUNUCENIKOBRACUNDETAILRows()
            {
                return (UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow[]) this.GetChildRows("UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL");
            }

            public bool IsAKTIVANZARSMNull()
            {
                return this.IsNull(this.tableUCENIKOBRACUN.AKTIVANZARSMColumn);
            }

            public bool IsOSNOVICAPODANUNull()
            {
                return this.IsNull(this.tableUCENIKOBRACUN.OSNOVICAPODANUColumn);
            }

            public bool IsUCOBRGODINANull()
            {
                return this.IsNull(this.tableUCENIKOBRACUN.UCOBRGODINAColumn);
            }

            public bool IsUCOBRMJESECNull()
            {
                return this.IsNull(this.tableUCENIKOBRACUN.UCOBRMJESECColumn);
            }

            public bool IsUCOBROPISNull()
            {
                return this.IsNull(this.tableUCENIKOBRACUN.UCOBROPISColumn);
            }

            public void SetAKTIVANZARSMNull()
            {
                this[this.tableUCENIKOBRACUN.AKTIVANZARSMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAPODANUNull()
            {
                this[this.tableUCENIKOBRACUN.OSNOVICAPODANUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUCOBROPISNull()
            {
                this[this.tableUCENIKOBRACUN.UCOBROPISColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool AKTIVANZARSM
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableUCENIKOBRACUN.AKTIVANZARSMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value AKTIVANZARSM because it is DBNull.", innerException);
                    }
                    return flag;
                }
                set
                {
                    this[this.tableUCENIKOBRACUN.AKTIVANZARSMColumn] = value;
                }
            }

            public decimal OSNOVICAPODANU
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableUCENIKOBRACUN.OSNOVICAPODANUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OSNOVICAPODANU because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableUCENIKOBRACUN.OSNOVICAPODANUColumn] = value;
                }
            }

            public int UCOBRGODINA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableUCENIKOBRACUN.UCOBRGODINAColumn]);
                }
                set
                {
                    this[this.tableUCENIKOBRACUN.UCOBRGODINAColumn] = value;
                }
            }

            public int UCOBRMJESEC
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableUCENIKOBRACUN.UCOBRMJESECColumn]);
                }
                set
                {
                    this[this.tableUCENIKOBRACUN.UCOBRMJESECColumn] = value;
                }
            }

            public string UCOBROPIS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIKOBRACUN.UCOBROPISColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value UCOBROPIS because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIKOBRACUN.UCOBROPISColumn] = value;
                }
            }
        }

        public class UCENIKOBRACUNRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private UCENIKOBRACUNDataSet.UCENIKOBRACUNRow eventRow;

            public UCENIKOBRACUNRowChangeEvent(UCENIKOBRACUNDataSet.UCENIKOBRACUNRow row, DataRowAction action)
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

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void UCENIKOBRACUNRowChangeEventHandler(object sender, UCENIKOBRACUNDataSet.UCENIKOBRACUNRowChangeEvent e);

        [Serializable]
        public class UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJDANAPRAKSE;
            private DataColumn columnIDUCENIK;
            private DataColumn columnIMEUCENIK;
            private DataColumn columnOBRACUNOSNOVICEPRAKSA;
            private DataColumn columnODJELJENJE;
            private DataColumn columnPREZIMEUCENIK;
            private DataColumn columnRAZRED;
            private DataColumn columnUCOBRGODINA;
            private DataColumn columnUCOBRMJESEC;

            public event UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEventHandler UCENIKOBRACUNUCENIKOBRACUNDETAILRowChanged;

            public event UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEventHandler UCENIKOBRACUNUCENIKOBRACUNDETAILRowChanging;

            public event UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEventHandler UCENIKOBRACUNUCENIKOBRACUNDETAILRowDeleted;

            public event UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEventHandler UCENIKOBRACUNUCENIKOBRACUNDETAILRowDeleting;

            public UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable()
            {
                this.TableName = "UCENIKOBRACUNUCENIKOBRACUNDETAIL";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable(DataTable table) : base(table.TableName)
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

            protected UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddUCENIKOBRACUNUCENIKOBRACUNDETAILRow(UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow row)
            {
                this.Rows.Add(row);
            }

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow AddUCENIKOBRACUNUCENIKOBRACUNDETAILRow(int uCOBRMJESEC, int uCOBRGODINA, int iDUCENIK, int bROJDANAPRAKSE, decimal oBRACUNOSNOVICEPRAKSA)
            {
                UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow row = (UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow) this.NewRow();
                row["UCOBRMJESEC"] = uCOBRMJESEC;
                row["UCOBRGODINA"] = uCOBRGODINA;
                row["IDUCENIK"] = iDUCENIK;
                row["BROJDANAPRAKSE"] = bROJDANAPRAKSE;
                row["OBRACUNOSNOVICEPRAKSA"] = oBRACUNOSNOVICEPRAKSA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable table = (UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow FindByUCOBRMJESECUCOBRGODINAIDUCENIK(int uCOBRMJESEC, int uCOBRGODINA, int iDUCENIK)
            {
                return (UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow) this.Rows.Find(new object[] { uCOBRMJESEC, uCOBRGODINA, iDUCENIK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                UCENIKOBRACUNDataSet set = new UCENIKOBRACUNDataSet();
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
                this.columnUCOBRMJESEC = new DataColumn("UCOBRMJESEC", typeof(int), "", MappingType.Element);
                this.columnUCOBRMJESEC.AllowDBNull = false;
                this.columnUCOBRMJESEC.Caption = "UCOBRMJESEC";
                this.columnUCOBRMJESEC.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("IsKey", "true");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Description", "Mjesec");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Length", "5");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Decimals", "0");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("IsInReader", "true");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUCOBRMJESEC.ExtendedProperties.Add("Deklarit.InternalName", "UCOBRMJESEC");
                this.Columns.Add(this.columnUCOBRMJESEC);
                this.columnUCOBRGODINA = new DataColumn("UCOBRGODINA", typeof(int), "", MappingType.Element);
                this.columnUCOBRGODINA.AllowDBNull = false;
                this.columnUCOBRGODINA.Caption = "UCOBRGODINA";
                this.columnUCOBRGODINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUCOBRGODINA.ExtendedProperties.Add("IsKey", "true");
                this.columnUCOBRGODINA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUCOBRGODINA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Description", "Godina");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Length", "5");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Decimals", "0");
                this.columnUCOBRGODINA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnUCOBRGODINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUCOBRGODINA.ExtendedProperties.Add("Deklarit.InternalName", "UCOBRGODINA");
                this.Columns.Add(this.columnUCOBRGODINA);
                this.columnIDUCENIK = new DataColumn("IDUCENIK", typeof(int), "", MappingType.Element);
                this.columnIDUCENIK.AllowDBNull = false;
                this.columnIDUCENIK.Caption = "IDUCENIK";
                this.columnIDUCENIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDUCENIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDUCENIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDUCENIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDUCENIK.ExtendedProperties.Add("Description", "Šif.uč.");
                this.columnIDUCENIK.ExtendedProperties.Add("Length", "5");
                this.columnIDUCENIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDUCENIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDUCENIK.ExtendedProperties.Add("Deklarit.InternalName", "IDUCENIK");
                this.Columns.Add(this.columnIDUCENIK);
                this.columnPREZIMEUCENIK = new DataColumn("PREZIMEUCENIK", typeof(string), "", MappingType.Element);
                this.columnPREZIMEUCENIK.AllowDBNull = true;
                this.columnPREZIMEUCENIK.Caption = "PREZIMEUCENIK";
                this.columnPREZIMEUCENIK.MaxLength = 50;
                this.columnPREZIMEUCENIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("IsKey", "false");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Description", "Prezime");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Length", "50");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIMEUCENIK.ExtendedProperties.Add("Deklarit.InternalName", "PREZIMEUCENIK");
                this.Columns.Add(this.columnPREZIMEUCENIK);
                this.columnIMEUCENIK = new DataColumn("IMEUCENIK", typeof(string), "", MappingType.Element);
                this.columnIMEUCENIK.AllowDBNull = true;
                this.columnIMEUCENIK.Caption = "IMEUCENIK";
                this.columnIMEUCENIK.MaxLength = 50;
                this.columnIMEUCENIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIMEUCENIK.ExtendedProperties.Add("IsKey", "false");
                this.columnIMEUCENIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIMEUCENIK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIMEUCENIK.ExtendedProperties.Add("Description", "Ime");
                this.columnIMEUCENIK.ExtendedProperties.Add("Length", "50");
                this.columnIMEUCENIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIMEUCENIK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIMEUCENIK.ExtendedProperties.Add("Deklarit.InternalName", "IMEUCENIK");
                this.Columns.Add(this.columnIMEUCENIK);
                this.columnBROJDANAPRAKSE = new DataColumn("BROJDANAPRAKSE", typeof(int), "", MappingType.Element);
                this.columnBROJDANAPRAKSE.AllowDBNull = false;
                this.columnBROJDANAPRAKSE.Caption = "BROJDANAPRAKSE";
                this.columnBROJDANAPRAKSE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("Description", "Broj dana prakse");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("Length", "5");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJDANAPRAKSE.ExtendedProperties.Add("Deklarit.InternalName", "BROJDANAPRAKSE");
                this.Columns.Add(this.columnBROJDANAPRAKSE);
                this.columnOBRACUNOSNOVICEPRAKSA = new DataColumn("OBRACUNOSNOVICEPRAKSA", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNOSNOVICEPRAKSA.AllowDBNull = false;
                this.columnOBRACUNOSNOVICEPRAKSA.Caption = "OBRACUNOSNOVICEPRAKSA";
                this.columnOBRACUNOSNOVICEPRAKSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("Description", "Osnovica ukupna (brojdana * osnovicapodanu)");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNOSNOVICEPRAKSA.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNOSNOVICEPRAKSA");
                this.Columns.Add(this.columnOBRACUNOSNOVICEPRAKSA);
                this.columnRAZRED = new DataColumn("RAZRED", typeof(int), "", MappingType.Element);
                this.columnRAZRED.AllowDBNull = true;
                this.columnRAZRED.Caption = "RAZRED";
                this.columnRAZRED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAZRED.ExtendedProperties.Add("IsKey", "false");
                this.columnRAZRED.ExtendedProperties.Add("ReadOnly", "true");
                this.columnRAZRED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRAZRED.ExtendedProperties.Add("Description", "RAZRED");
                this.columnRAZRED.ExtendedProperties.Add("Length", "5");
                this.columnRAZRED.ExtendedProperties.Add("Decimals", "0");
                this.columnRAZRED.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAZRED.ExtendedProperties.Add("Deklarit.InternalName", "RAZRED");
                this.Columns.Add(this.columnRAZRED);
                this.columnODJELJENJE = new DataColumn("ODJELJENJE", typeof(string), "", MappingType.Element);
                this.columnODJELJENJE.AllowDBNull = true;
                this.columnODJELJENJE.Caption = "ODJELJENJE";
                this.columnODJELJENJE.MaxLength = 5;
                this.columnODJELJENJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnODJELJENJE.ExtendedProperties.Add("IsKey", "false");
                this.columnODJELJENJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnODJELJENJE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnODJELJENJE.ExtendedProperties.Add("Description", "ODJELJENJE");
                this.columnODJELJENJE.ExtendedProperties.Add("Length", "5");
                this.columnODJELJENJE.ExtendedProperties.Add("Decimals", "0");
                this.columnODJELJENJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnODJELJENJE.ExtendedProperties.Add("Deklarit.InternalName", "ODJELJENJE");
                this.Columns.Add(this.columnODJELJENJE);
                this.PrimaryKey = new DataColumn[] { this.columnUCOBRMJESEC, this.columnUCOBRGODINA, this.columnIDUCENIK };
                this.ExtendedProperties.Add("ParentLvl", "UCENIKOBRACUN");
                this.ExtendedProperties.Add("LevelName", "UCENIKOBRACUNDETAIL");
                this.ExtendedProperties.Add("Description", "Učenici u obračunu");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnUCOBRMJESEC = this.Columns["UCOBRMJESEC"];
                this.columnUCOBRGODINA = this.Columns["UCOBRGODINA"];
                this.columnIDUCENIK = this.Columns["IDUCENIK"];
                this.columnPREZIMEUCENIK = this.Columns["PREZIMEUCENIK"];
                this.columnIMEUCENIK = this.Columns["IMEUCENIK"];
                this.columnBROJDANAPRAKSE = this.Columns["BROJDANAPRAKSE"];
                this.columnOBRACUNOSNOVICEPRAKSA = this.Columns["OBRACUNOSNOVICEPRAKSA"];
                this.columnRAZRED = this.Columns["RAZRED"];
                this.columnODJELJENJE = this.Columns["ODJELJENJE"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow(builder);
            }

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow NewUCENIKOBRACUNUCENIKOBRACUNDETAILRow()
            {
                return (UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChanged != null)
                {
                    UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEventHandler uCENIKOBRACUNUCENIKOBRACUNDETAILRowChangedEvent = this.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChanged;
                    if (uCENIKOBRACUNUCENIKOBRACUNDETAILRowChangedEvent != null)
                    {
                        uCENIKOBRACUNUCENIKOBRACUNDETAILRowChangedEvent(this, new UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEvent((UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChanging != null)
                {
                    UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEventHandler uCENIKOBRACUNUCENIKOBRACUNDETAILRowChangingEvent = this.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChanging;
                    if (uCENIKOBRACUNUCENIKOBRACUNDETAILRowChangingEvent != null)
                    {
                        uCENIKOBRACUNUCENIKOBRACUNDETAILRowChangingEvent(this, new UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEvent((UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.UCENIKOBRACUNUCENIKOBRACUNDETAILRowDeleted != null)
                {
                    UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEventHandler uCENIKOBRACUNUCENIKOBRACUNDETAILRowDeletedEvent = this.UCENIKOBRACUNUCENIKOBRACUNDETAILRowDeleted;
                    if (uCENIKOBRACUNUCENIKOBRACUNDETAILRowDeletedEvent != null)
                    {
                        uCENIKOBRACUNUCENIKOBRACUNDETAILRowDeletedEvent(this, new UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEvent((UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.UCENIKOBRACUNUCENIKOBRACUNDETAILRowDeleting != null)
                {
                    UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEventHandler uCENIKOBRACUNUCENIKOBRACUNDETAILRowDeletingEvent = this.UCENIKOBRACUNUCENIKOBRACUNDETAILRowDeleting;
                    if (uCENIKOBRACUNUCENIKOBRACUNDETAILRowDeletingEvent != null)
                    {
                        uCENIKOBRACUNUCENIKOBRACUNDETAILRowDeletingEvent(this, new UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEvent((UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveUCENIKOBRACUNUCENIKOBRACUNDETAILRow(UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJDANAPRAKSEColumn
            {
                get
                {
                    return this.columnBROJDANAPRAKSE;
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

            public DataColumn IDUCENIKColumn
            {
                get
                {
                    return this.columnIDUCENIK;
                }
            }

            public DataColumn IMEUCENIKColumn
            {
                get
                {
                    return this.columnIMEUCENIK;
                }
            }

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow this[int index]
            {
                get
                {
                    return (UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow) this.Rows[index];
                }
            }

            public DataColumn OBRACUNOSNOVICEPRAKSAColumn
            {
                get
                {
                    return this.columnOBRACUNOSNOVICEPRAKSA;
                }
            }

            public DataColumn ODJELJENJEColumn
            {
                get
                {
                    return this.columnODJELJENJE;
                }
            }

            public DataColumn PREZIMEUCENIKColumn
            {
                get
                {
                    return this.columnPREZIMEUCENIK;
                }
            }

            public DataColumn RAZREDColumn
            {
                get
                {
                    return this.columnRAZRED;
                }
            }

            public DataColumn UCOBRGODINAColumn
            {
                get
                {
                    return this.columnUCOBRGODINA;
                }
            }

            public DataColumn UCOBRMJESECColumn
            {
                get
                {
                    return this.columnUCOBRMJESEC;
                }
            }
        }

        public class UCENIKOBRACUNUCENIKOBRACUNDETAILRow : DataRow
        {
            private UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable tableUCENIKOBRACUNUCENIKOBRACUNDETAIL;

            internal UCENIKOBRACUNUCENIKOBRACUNDETAILRow(DataRowBuilder rb) : base(rb)
            {
                this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL = (UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILDataTable) this.Table;
            }

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNRow GetUCENIKOBRACUNRow()
            {
                return (UCENIKOBRACUNDataSet.UCENIKOBRACUNRow) this.GetParentRow("UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL");
            }

            public bool IsBROJDANAPRAKSENull()
            {
                return this.IsNull(this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.BROJDANAPRAKSEColumn);
            }

            public bool IsIDUCENIKNull()
            {
                return this.IsNull(this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.IDUCENIKColumn);
            }

            public bool IsIMEUCENIKNull()
            {
                return this.IsNull(this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.IMEUCENIKColumn);
            }

            public bool IsOBRACUNOSNOVICEPRAKSANull()
            {
                return this.IsNull(this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.OBRACUNOSNOVICEPRAKSAColumn);
            }

            public bool IsODJELJENJENull()
            {
                return this.IsNull(this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.ODJELJENJEColumn);
            }

            public bool IsPREZIMEUCENIKNull()
            {
                return this.IsNull(this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.PREZIMEUCENIKColumn);
            }

            public bool IsRAZREDNull()
            {
                return this.IsNull(this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.RAZREDColumn);
            }

            public bool IsUCOBRGODINANull()
            {
                return this.IsNull(this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.UCOBRGODINAColumn);
            }

            public bool IsUCOBRMJESECNull()
            {
                return this.IsNull(this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.UCOBRMJESECColumn);
            }

            public void SetBROJDANAPRAKSENull()
            {
                this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.BROJDANAPRAKSEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMEUCENIKNull()
            {
                this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.IMEUCENIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNOSNOVICEPRAKSANull()
            {
                this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.OBRACUNOSNOVICEPRAKSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODJELJENJENull()
            {
                this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.ODJELJENJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMEUCENIKNull()
            {
                this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.PREZIMEUCENIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRAZREDNull()
            {
                this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.RAZREDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BROJDANAPRAKSE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.BROJDANAPRAKSEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJDANAPRAKSE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.BROJDANAPRAKSEColumn] = value;
                }
            }

            public int IDUCENIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.IDUCENIKColumn]);
                }
                set
                {
                    this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.IDUCENIKColumn] = value;
                }
            }

            public string IMEUCENIK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.IMEUCENIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IMEUCENIK because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.IMEUCENIKColumn] = value;
                }
            }

            public decimal OBRACUNOSNOVICEPRAKSA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.OBRACUNOSNOVICEPRAKSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.OBRACUNOSNOVICEPRAKSAColumn] = value;
                }
            }

            public string ODJELJENJE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.ODJELJENJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.ODJELJENJEColumn] = value;
                }
            }

            public string PREZIMEUCENIK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.PREZIMEUCENIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.PREZIMEUCENIKColumn] = value;
                }
            }

            public int RAZRED
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.RAZREDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.RAZREDColumn] = value;
                }
            }

            public int UCOBRGODINA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.UCOBRGODINAColumn]);
                }
                set
                {
                    this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.UCOBRGODINAColumn] = value;
                }
            }

            public int UCOBRMJESEC
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.UCOBRMJESECColumn]);
                }
                set
                {
                    this[this.tableUCENIKOBRACUNUCENIKOBRACUNDETAIL.UCOBRMJESECColumn] = value;
                }
            }
        }

        public class UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow eventRow;

            public UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEvent(UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow row, DataRowAction action)
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

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEventHandler(object sender, UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRowChangeEvent e);
    }
}

