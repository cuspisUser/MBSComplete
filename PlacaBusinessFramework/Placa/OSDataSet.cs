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
    public class OSDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private OSDataTable tableOS;
        private OSTEMELJNICADataTable tableOSTEMELJNICA;

        public OSDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected OSDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["OSTEMELJNICA"] != null)
                    {
                        this.Tables.Add(new OSTEMELJNICADataTable(dataSet.Tables["OSTEMELJNICA"]));
                    }
                    if (dataSet.Tables["OS"] != null)
                    {
                        this.Tables.Add(new OSDataTable(dataSet.Tables["OS"]));
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
            OSDataSet set = (OSDataSet) base.Clone();
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
            OSDataSet set = new OSDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "OSDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2149");
            this.ExtendedProperties.Add("DataSetName", "OSDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IOSDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "OS");
            this.ExtendedProperties.Add("ObjectDescription", "OS");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\OSNOVNA");
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
            this.DataSetName = "OSDataSet";
            this.Namespace = "http://www.tempuri.org/OS";
            this.tableOSTEMELJNICA = new OSTEMELJNICADataTable();
            this.Tables.Add(this.tableOSTEMELJNICA);
            this.tableOS = new OSDataTable();
            this.Tables.Add(this.tableOS);
            this.Relations.Add("OS_OSTEMELJNICA", new DataColumn[] { this.Tables["OS"].Columns["INVBROJ"] }, new DataColumn[] { this.Tables["OSTEMELJNICA"].Columns["INVBROJ"] });
            this.Relations["OS_OSTEMELJNICA"].Nested = true;
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
            this.tableOSTEMELJNICA = (OSTEMELJNICADataTable) this.Tables["OSTEMELJNICA"];
            this.tableOS = (OSDataTable) this.Tables["OS"];
            if (initTable)
            {
                if (this.tableOSTEMELJNICA != null)
                {
                    this.tableOSTEMELJNICA.InitVars();
                }
                if (this.tableOS != null)
                {
                    this.tableOS.InitVars();
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
                if (dataSet.Tables["OSTEMELJNICA"] != null)
                {
                    this.Tables.Add(new OSTEMELJNICADataTable(dataSet.Tables["OSTEMELJNICA"]));
                }
                if (dataSet.Tables["OS"] != null)
                {
                    this.Tables.Add(new OSDataTable(dataSet.Tables["OS"]));
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

        private bool ShouldSerializeOS()
        {
            return false;
        }

        private bool ShouldSerializeOSTEMELJNICA()
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
        public OSDataTable OS
        {
            get
            {
                return this.tableOS;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OSTEMELJNICADataTable OSTEMELJNICA
        {
            get
            {
                return this.tableOSTEMELJNICA;
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
        public class OSDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAMSKUPINASTOPA;
            private DataColumn columnDATUMNABAVKE;
            private DataColumn columnDATUMUPORABE;
            private DataColumn columnIDAMSKUPINE;
            private DataColumn columnIDOSVRSTA;
            private DataColumn columnINVBROJ;
            private DataColumn columnKTOISPRAVKAIDKONTO;
            private DataColumn columnKTOIZVORAIDKONTO;
            private DataColumn columnKTONABAVKEIDKONTO;
            private DataColumn columnNAPOMENAOS;
            private DataColumn columnNAZIVOS;
            private DataColumn columnOPISAMSKUPINE;

            public event OSDataSet.OSRowChangeEventHandler OSRowChanged;

            public event OSDataSet.OSRowChangeEventHandler OSRowChanging;

            public event OSDataSet.OSRowChangeEventHandler OSRowDeleted;

            public event OSDataSet.OSRowChangeEventHandler OSRowDeleting;

            public OSDataTable()
            {
                this.TableName = "OS";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OSDataTable(DataTable table) : base(table.TableName)
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

            protected OSDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOSRow(OSDataSet.OSRow row)
            {
                this.Rows.Add(row);
            }

            public OSDataSet.OSRow AddOSRow(long iNVBROJ, int iDOSVRSTA, string nAZIVOS, int iDAMSKUPINE, DateTime dATUMNABAVKE, DateTime dATUMUPORABE, string nAPOMENAOS)
            {
                OSDataSet.OSRow row = (OSDataSet.OSRow) this.NewRow();
                row["INVBROJ"] = iNVBROJ;
                row["IDOSVRSTA"] = iDOSVRSTA;
                row["NAZIVOS"] = nAZIVOS;
                row["IDAMSKUPINE"] = iDAMSKUPINE;
                row["DATUMNABAVKE"] = dATUMNABAVKE;
                row["DATUMUPORABE"] = dATUMUPORABE;
                row["NAPOMENAOS"] = nAPOMENAOS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OSDataSet.OSDataTable table = (OSDataSet.OSDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OSDataSet.OSRow FindByINVBROJ(long iNVBROJ)
            {
                return (OSDataSet.OSRow) this.Rows.Find(new object[] { iNVBROJ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OSDataSet.OSRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OSDataSet set = new OSDataSet();
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
                this.columnINVBROJ = new DataColumn("INVBROJ", typeof(long), "", MappingType.Element);
                this.columnINVBROJ.AllowDBNull = false;
                this.columnINVBROJ.Caption = "Inventarni broj";
                this.columnINVBROJ.Unique = true;
                this.columnINVBROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnINVBROJ.ExtendedProperties.Add("IsKey", "true");
                this.columnINVBROJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnINVBROJ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnINVBROJ.ExtendedProperties.Add("Description", "Inventarni broj");
                this.columnINVBROJ.ExtendedProperties.Add("Length", "12");
                this.columnINVBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnINVBROJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnINVBROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.InternalName", "INVBROJ");
                this.Columns.Add(this.columnINVBROJ);
                this.columnIDOSVRSTA = new DataColumn("IDOSVRSTA", typeof(int), "", MappingType.Element);
                this.columnIDOSVRSTA.AllowDBNull = false;
                this.columnIDOSVRSTA.Caption = "IDOSVRSTA";
                this.columnIDOSVRSTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOSVRSTA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDOSVRSTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOSVRSTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Description", "OS ili Sitan Inventar");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Length", "5");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOSVRSTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOSVRSTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.InternalName", "IDOSVRSTA");
                this.Columns.Add(this.columnIDOSVRSTA);
                this.columnNAZIVOS = new DataColumn("NAZIVOS", typeof(string), "", MappingType.Element);
                this.columnNAZIVOS.AllowDBNull = false;
                this.columnNAZIVOS.Caption = "NAZIVOS";
                this.columnNAZIVOS.MaxLength = 50;
                this.columnNAZIVOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOS.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOS.ExtendedProperties.Add("Description", "Naziv osnovnog sredstva");
                this.columnNAZIVOS.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVOS.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOS");
                this.Columns.Add(this.columnNAZIVOS);
                this.columnIDAMSKUPINE = new DataColumn("IDAMSKUPINE", typeof(int), "", MappingType.Element);
                this.columnIDAMSKUPINE.AllowDBNull = false;
                this.columnIDAMSKUPINE.Caption = "IDAMSKUPINE";
                this.columnIDAMSKUPINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Description", "Amortizacijska skupina");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Length", "5");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.InternalName", "IDAMSKUPINE");
                this.Columns.Add(this.columnIDAMSKUPINE);
                this.columnKTONABAVKEIDKONTO = new DataColumn("KTONABAVKEIDKONTO", typeof(string), "", MappingType.Element);
                this.columnKTONABAVKEIDKONTO.AllowDBNull = true;
                this.columnKTONABAVKEIDKONTO.Caption = "Konto";
                this.columnKTONABAVKEIDKONTO.MaxLength = 14;
                this.columnKTONABAVKEIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("SubtypeGroup", "KTONABAVKE");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Description", "Konto nabavne vr.");
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
                this.columnKTOISPRAVKAIDKONTO.AllowDBNull = true;
                this.columnKTOISPRAVKAIDKONTO.Caption = "Konto";
                this.columnKTOISPRAVKAIDKONTO.MaxLength = 14;
                this.columnKTOISPRAVKAIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("SubtypeGroup", "KTOISPRAVKA");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Description", "Konto ispravka vr.");
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
                this.columnKTOIZVORAIDKONTO.AllowDBNull = true;
                this.columnKTOIZVORAIDKONTO.Caption = "Konto";
                this.columnKTOIZVORAIDKONTO.MaxLength = 14;
                this.columnKTOIZVORAIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("SubtypeGroup", "KTOIZVORA");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Description", "Konto izvora vlasništva");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "KTOIZVORAIDKONTO");
                this.Columns.Add(this.columnKTOIZVORAIDKONTO);
                this.columnDATUMNABAVKE = new DataColumn("DATUMNABAVKE", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMNABAVKE.AllowDBNull = false;
                this.columnDATUMNABAVKE.Caption = "DATUMNABAVKE";
                this.columnDATUMNABAVKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMNABAVKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("Description", "Datum nabavke");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("Length", "8");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMNABAVKE.ExtendedProperties.Add("Deklarit.InternalName", "DATUMNABAVKE");
                this.Columns.Add(this.columnDATUMNABAVKE);
                this.columnDATUMUPORABE = new DataColumn("DATUMUPORABE", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMUPORABE.AllowDBNull = false;
                this.columnDATUMUPORABE.Caption = "DATUMUPORABE";
                this.columnDATUMUPORABE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMUPORABE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMUPORABE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMUPORABE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMUPORABE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMUPORABE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMUPORABE.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMUPORABE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMUPORABE.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMUPORABE.ExtendedProperties.Add("Description", "Datum uporabe");
                this.columnDATUMUPORABE.ExtendedProperties.Add("Length", "8");
                this.columnDATUMUPORABE.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMUPORABE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUMUPORABE.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMUPORABE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMUPORABE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMUPORABE.ExtendedProperties.Add("Deklarit.InternalName", "DATUMUPORABE");
                this.Columns.Add(this.columnDATUMUPORABE);
                this.columnNAPOMENAOS = new DataColumn("NAPOMENAOS", typeof(string), "", MappingType.Element);
                this.columnNAPOMENAOS.AllowDBNull = true;
                this.columnNAPOMENAOS.Caption = "NAPOMENAOS";
                this.columnNAPOMENAOS.MaxLength = 50;
                this.columnNAPOMENAOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAPOMENAOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAPOMENAOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAPOMENAOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAPOMENAOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAPOMENAOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAPOMENAOS.ExtendedProperties.Add("IsKey", "false");
                this.columnNAPOMENAOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAPOMENAOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAPOMENAOS.ExtendedProperties.Add("Description", "Napomena o sredstvu");
                this.columnNAPOMENAOS.ExtendedProperties.Add("Length", "50");
                this.columnNAPOMENAOS.ExtendedProperties.Add("Decimals", "0");
                this.columnNAPOMENAOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAPOMENAOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAPOMENAOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAPOMENAOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAPOMENAOS.ExtendedProperties.Add("Deklarit.InternalName", "NAPOMENAOS");
                this.Columns.Add(this.columnNAPOMENAOS);
                this.columnOPISAMSKUPINE = new DataColumn("OPISAMSKUPINE", typeof(string), "", MappingType.Element);
                this.columnOPISAMSKUPINE.AllowDBNull = true;
                this.columnOPISAMSKUPINE.Caption = "OPISAMSKUPINE";
                this.columnOPISAMSKUPINE.MaxLength = 100;
                this.columnOPISAMSKUPINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Description", "OPISAMSKUPINE");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Length", "100");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.InternalName", "OPISAMSKUPINE");
                this.Columns.Add(this.columnOPISAMSKUPINE);
                this.columnAMSKUPINASTOPA = new DataColumn("AMSKUPINASTOPA", typeof(decimal), "", MappingType.Element);
                this.columnAMSKUPINASTOPA.AllowDBNull = true;
                this.columnAMSKUPINASTOPA.Caption = "AMSKUPINASTOPA";
                this.columnAMSKUPINASTOPA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Description", "AMSKUPINASTOPA");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Length", "5");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("IsInReader", "true");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.InternalName", "AMSKUPINASTOPA");
                this.Columns.Add(this.columnAMSKUPINASTOPA);
                this.PrimaryKey = new DataColumn[] { this.columnINVBROJ };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "OS");
                this.ExtendedProperties.Add("Description", "OS");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnINVBROJ = this.Columns["INVBROJ"];
                this.columnIDOSVRSTA = this.Columns["IDOSVRSTA"];
                this.columnNAZIVOS = this.Columns["NAZIVOS"];
                this.columnIDAMSKUPINE = this.Columns["IDAMSKUPINE"];
                this.columnKTONABAVKEIDKONTO = this.Columns["KTONABAVKEIDKONTO"];
                this.columnKTOISPRAVKAIDKONTO = this.Columns["KTOISPRAVKAIDKONTO"];
                this.columnKTOIZVORAIDKONTO = this.Columns["KTOIZVORAIDKONTO"];
                this.columnDATUMNABAVKE = this.Columns["DATUMNABAVKE"];
                this.columnDATUMUPORABE = this.Columns["DATUMUPORABE"];
                this.columnNAPOMENAOS = this.Columns["NAPOMENAOS"];
                this.columnOPISAMSKUPINE = this.Columns["OPISAMSKUPINE"];
                this.columnAMSKUPINASTOPA = this.Columns["AMSKUPINASTOPA"];
            }

            public OSDataSet.OSRow NewOSRow()
            {
                return (OSDataSet.OSRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OSDataSet.OSRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OSRowChanged != null)
                {
                    OSDataSet.OSRowChangeEventHandler oSRowChangedEvent = this.OSRowChanged;
                    if (oSRowChangedEvent != null)
                    {
                        oSRowChangedEvent(this, new OSDataSet.OSRowChangeEvent((OSDataSet.OSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OSRowChanging != null)
                {
                    OSDataSet.OSRowChangeEventHandler oSRowChangingEvent = this.OSRowChanging;
                    if (oSRowChangingEvent != null)
                    {
                        oSRowChangingEvent(this, new OSDataSet.OSRowChangeEvent((OSDataSet.OSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.OSRowDeleted != null)
                {
                    OSDataSet.OSRowChangeEventHandler oSRowDeletedEvent = this.OSRowDeleted;
                    if (oSRowDeletedEvent != null)
                    {
                        oSRowDeletedEvent(this, new OSDataSet.OSRowChangeEvent((OSDataSet.OSRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OSRowDeleting != null)
                {
                    OSDataSet.OSRowChangeEventHandler oSRowDeletingEvent = this.OSRowDeleting;
                    if (oSRowDeletingEvent != null)
                    {
                        oSRowDeletingEvent(this, new OSDataSet.OSRowChangeEvent((OSDataSet.OSRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOSRow(OSDataSet.OSRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn AMSKUPINASTOPAColumn
            {
                get
                {
                    return this.columnAMSKUPINASTOPA;
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

            public DataColumn DATUMNABAVKEColumn
            {
                get
                {
                    return this.columnDATUMNABAVKE;
                }
            }

            public DataColumn DATUMUPORABEColumn
            {
                get
                {
                    return this.columnDATUMUPORABE;
                }
            }

            public DataColumn IDAMSKUPINEColumn
            {
                get
                {
                    return this.columnIDAMSKUPINE;
                }
            }

            public DataColumn IDOSVRSTAColumn
            {
                get
                {
                    return this.columnIDOSVRSTA;
                }
            }

            public DataColumn INVBROJColumn
            {
                get
                {
                    return this.columnINVBROJ;
                }
            }

            public OSDataSet.OSRow this[int index]
            {
                get
                {
                    return (OSDataSet.OSRow) this.Rows[index];
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

            public DataColumn NAPOMENAOSColumn
            {
                get
                {
                    return this.columnNAPOMENAOS;
                }
            }

            public DataColumn NAZIVOSColumn
            {
                get
                {
                    return this.columnNAZIVOS;
                }
            }

            public DataColumn OPISAMSKUPINEColumn
            {
                get
                {
                    return this.columnOPISAMSKUPINE;
                }
            }
        }

        public class OSRow : DataRow
        {
            private OSDataSet.OSDataTable tableOS;

            internal OSRow(DataRowBuilder rb) : base(rb)
            {
                this.tableOS = (OSDataSet.OSDataTable) this.Table;
            }

            public OSDataSet.OSTEMELJNICARow[] GetOSTEMELJNICARows()
            {
                return (OSDataSet.OSTEMELJNICARow[]) this.GetChildRows("OS_OSTEMELJNICA");
            }

            public bool IsAMSKUPINASTOPANull()
            {
                return this.IsNull(this.tableOS.AMSKUPINASTOPAColumn);
            }

            public bool IsDATUMNABAVKENull()
            {
                return this.IsNull(this.tableOS.DATUMNABAVKEColumn);
            }

            public bool IsDATUMUPORABENull()
            {
                return this.IsNull(this.tableOS.DATUMUPORABEColumn);
            }

            public bool IsIDAMSKUPINENull()
            {
                return this.IsNull(this.tableOS.IDAMSKUPINEColumn);
            }

            public bool IsIDOSVRSTANull()
            {
                return this.IsNull(this.tableOS.IDOSVRSTAColumn);
            }

            public bool IsINVBROJNull()
            {
                return this.IsNull(this.tableOS.INVBROJColumn);
            }

            public bool IsKTOISPRAVKAIDKONTONull()
            {
                return this.IsNull(this.tableOS.KTOISPRAVKAIDKONTOColumn);
            }

            public bool IsKTOIZVORAIDKONTONull()
            {
                return this.IsNull(this.tableOS.KTOIZVORAIDKONTOColumn);
            }

            public bool IsKTONABAVKEIDKONTONull()
            {
                return this.IsNull(this.tableOS.KTONABAVKEIDKONTOColumn);
            }

            public bool IsNAPOMENAOSNull()
            {
                return this.IsNull(this.tableOS.NAPOMENAOSColumn);
            }

            public bool IsNAZIVOSNull()
            {
                return this.IsNull(this.tableOS.NAZIVOSColumn);
            }

            public bool IsOPISAMSKUPINENull()
            {
                return this.IsNull(this.tableOS.OPISAMSKUPINEColumn);
            }

            public void SetAMSKUPINASTOPANull()
            {
                this[this.tableOS.AMSKUPINASTOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMNABAVKENull()
            {
                this[this.tableOS.DATUMNABAVKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMUPORABENull()
            {
                this[this.tableOS.DATUMUPORABEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDAMSKUPINENull()
            {
                this[this.tableOS.IDAMSKUPINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDOSVRSTANull()
            {
                this[this.tableOS.IDOSVRSTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTOISPRAVKAIDKONTONull()
            {
                this[this.tableOS.KTOISPRAVKAIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTOIZVORAIDKONTONull()
            {
                this[this.tableOS.KTOIZVORAIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTONABAVKEIDKONTONull()
            {
                this[this.tableOS.KTONABAVKEIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAPOMENAOSNull()
            {
                this[this.tableOS.NAPOMENAOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOSNull()
            {
                this[this.tableOS.NAZIVOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISAMSKUPINENull()
            {
                this[this.tableOS.OPISAMSKUPINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal AMSKUPINASTOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOS.AMSKUPINASTOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOS.AMSKUPINASTOPAColumn] = value;
                }
            }

            public DateTime DATUMNABAVKE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableOS.DATUMNABAVKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableOS.DATUMNABAVKEColumn] = value;
                }
            }

            public DateTime DATUMUPORABE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableOS.DATUMUPORABEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableOS.DATUMUPORABEColumn] = value;
                }
            }

            public int IDAMSKUPINE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableOS.IDAMSKUPINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOS.IDAMSKUPINEColumn] = value;
                }
            }

            public int IDOSVRSTA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableOS.IDOSVRSTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOS.IDOSVRSTAColumn] = value;
                }
            }

            public long INVBROJ
            {
                get
                {
                    return Conversions.ToLong(this[this.tableOS.INVBROJColumn]);
                }
                set
                {
                    this[this.tableOS.INVBROJColumn] = value;
                }
            }

            public string KTOISPRAVKAIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOS.KTOISPRAVKAIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOS.KTOISPRAVKAIDKONTOColumn] = value;
                }
            }

            public string KTOIZVORAIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOS.KTOIZVORAIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOS.KTOIZVORAIDKONTOColumn] = value;
                }
            }

            public string KTONABAVKEIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOS.KTONABAVKEIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOS.KTONABAVKEIDKONTOColumn] = value;
                }
            }

            public string NAPOMENAOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOS.NAPOMENAOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOS.NAPOMENAOSColumn] = value;
                }
            }

            public string NAZIVOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOS.NAZIVOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOS.NAZIVOSColumn] = value;
                }
            }

            public string OPISAMSKUPINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOS.OPISAMSKUPINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOS.OPISAMSKUPINEColumn] = value;
                }
            }
        }

        public class OSRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OSDataSet.OSRow eventRow;

            public OSRowChangeEvent(OSDataSet.OSRow row, DataRowAction action)
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

            public OSDataSet.OSRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OSRowChangeEventHandler(object sender, OSDataSet.OSRowChangeEvent e);

        [Serializable]
        public class OSTEMELJNICADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOSDOKUMENT;
            private DataColumn columnINVBROJ;
            private DataColumn columnNAZIVOSDOKUMENT;
            private DataColumn columnOSBROJDOKUMENTA;
            private DataColumn columnOSDATUMDOK;
            private DataColumn columnOSDUGUJE;
            private DataColumn columnOSKOLICINA;
            private DataColumn columnOSOPIS;
            private DataColumn columnOSOSNOVICA;
            private DataColumn columnOSPOTRAZUJE;
            private DataColumn columnOSSTOPA;
            private DataColumn columnRASHODLOKACIJEIDLOKACIJE;

            public event OSDataSet.OSTEMELJNICARowChangeEventHandler OSTEMELJNICARowChanged;

            public event OSDataSet.OSTEMELJNICARowChangeEventHandler OSTEMELJNICARowChanging;

            public event OSDataSet.OSTEMELJNICARowChangeEventHandler OSTEMELJNICARowDeleted;

            public event OSDataSet.OSTEMELJNICARowChangeEventHandler OSTEMELJNICARowDeleting;

            public OSTEMELJNICADataTable()
            {
                this.TableName = "OSTEMELJNICA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OSTEMELJNICADataTable(DataTable table) : base(table.TableName)
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

            protected OSTEMELJNICADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOSTEMELJNICARow(OSDataSet.OSTEMELJNICARow row)
            {
                this.Rows.Add(row);
            }

            public OSDataSet.OSTEMELJNICARow AddOSTEMELJNICARow(long iNVBROJ, int iDOSDOKUMENT, int oSBROJDOKUMENTA, DateTime oSDATUMDOK, decimal oSKOLICINA, decimal oSSTOPA, decimal oSOSNOVICA, decimal oSDUGUJE, decimal oSPOTRAZUJE, int rASHODLOKACIJEIDLOKACIJE, string oSOPIS)
            {
                OSDataSet.OSTEMELJNICARow row = (OSDataSet.OSTEMELJNICARow) this.NewRow();
                row["INVBROJ"] = iNVBROJ;
                row["IDOSDOKUMENT"] = iDOSDOKUMENT;
                row["OSBROJDOKUMENTA"] = oSBROJDOKUMENTA;
                row["OSDATUMDOK"] = oSDATUMDOK;
                row["OSKOLICINA"] = oSKOLICINA;
                row["OSSTOPA"] = oSSTOPA;
                row["OSOSNOVICA"] = oSOSNOVICA;
                row["OSDUGUJE"] = oSDUGUJE;
                row["OSPOTRAZUJE"] = oSPOTRAZUJE;
                row["RASHODLOKACIJEIDLOKACIJE"] = rASHODLOKACIJEIDLOKACIJE;
                row["OSOPIS"] = oSOPIS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OSDataSet.OSTEMELJNICADataTable table = (OSDataSet.OSTEMELJNICADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OSDataSet.OSTEMELJNICARow FindByINVBROJIDOSDOKUMENTOSBROJDOKUMENTA(long iNVBROJ, int iDOSDOKUMENT, int oSBROJDOKUMENTA)
            {
                return (OSDataSet.OSTEMELJNICARow) this.Rows.Find(new object[] { iNVBROJ, iDOSDOKUMENT, oSBROJDOKUMENTA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OSDataSet.OSTEMELJNICARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OSDataSet set = new OSDataSet();
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
                this.columnINVBROJ = new DataColumn("INVBROJ", typeof(long), "", MappingType.Element);
                this.columnINVBROJ.AllowDBNull = false;
                this.columnINVBROJ.Caption = "Inventarni broj";
                this.columnINVBROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnINVBROJ.ExtendedProperties.Add("IsKey", "true");
                this.columnINVBROJ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnINVBROJ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnINVBROJ.ExtendedProperties.Add("Description", "Inventarni broj");
                this.columnINVBROJ.ExtendedProperties.Add("Length", "12");
                this.columnINVBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnINVBROJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnINVBROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.InternalName", "INVBROJ");
                this.Columns.Add(this.columnINVBROJ);
                this.columnIDOSDOKUMENT = new DataColumn("IDOSDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnIDOSDOKUMENT.AllowDBNull = false;
                this.columnIDOSDOKUMENT.Caption = "IDOSDOKUMENT";
                this.columnIDOSDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Description", "Dokument");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Length", "5");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDOSDOKUMENT");
                this.Columns.Add(this.columnIDOSDOKUMENT);
                this.columnOSBROJDOKUMENTA = new DataColumn("OSBROJDOKUMENTA", typeof(int), "", MappingType.Element);
                this.columnOSBROJDOKUMENTA.AllowDBNull = false;
                this.columnOSBROJDOKUMENTA.Caption = "OSBROJDOKUMENTA";
                this.columnOSBROJDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("IsKey", "true");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Description", "Broj");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Length", "5");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "OSBROJDOKUMENTA");
                this.Columns.Add(this.columnOSBROJDOKUMENTA);
                this.columnOSDATUMDOK = new DataColumn("OSDATUMDOK", typeof(DateTime), "", MappingType.Element);
                this.columnOSDATUMDOK.AllowDBNull = false;
                this.columnOSDATUMDOK.Caption = "OSDATUMDOK";
                this.columnOSDATUMDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSDATUMDOK.ExtendedProperties.Add("IsKey", "false");
                this.columnOSDATUMDOK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSDATUMDOK.ExtendedProperties.Add("DeklaritType", "date");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Description", "Datum");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Length", "8");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnOSDATUMDOK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.InternalName", "OSDATUMDOK");
                this.Columns.Add(this.columnOSDATUMDOK);
                this.columnOSKOLICINA = new DataColumn("OSKOLICINA", typeof(decimal), "", MappingType.Element);
                this.columnOSKOLICINA.AllowDBNull = false;
                this.columnOSKOLICINA.Caption = "OSKOLICINA";
                this.columnOSKOLICINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSKOLICINA.ExtendedProperties.Add("IsKey", "false");
                this.columnOSKOLICINA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSKOLICINA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSKOLICINA.ExtendedProperties.Add("Description", "Količina");
                this.columnOSKOLICINA.ExtendedProperties.Add("Length", "12");
                this.columnOSKOLICINA.ExtendedProperties.Add("Decimals", "2");
                this.columnOSKOLICINA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSKOLICINA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSKOLICINA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSKOLICINA.ExtendedProperties.Add("Deklarit.InternalName", "OSKOLICINA");
                this.Columns.Add(this.columnOSKOLICINA);
                this.columnOSSTOPA = new DataColumn("OSSTOPA", typeof(decimal), "", MappingType.Element);
                this.columnOSSTOPA.AllowDBNull = false;
                this.columnOSSTOPA.Caption = "OSSTOPA";
                this.columnOSSTOPA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSSTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnOSSTOPA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSSTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSSTOPA.ExtendedProperties.Add("Description", "Stopa");
                this.columnOSSTOPA.ExtendedProperties.Add("Length", "5");
                this.columnOSSTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnOSSTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSSTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnOSSTOPA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSSTOPA.ExtendedProperties.Add("Deklarit.InternalName", "OSSTOPA");
                this.Columns.Add(this.columnOSSTOPA);
                this.columnOSOSNOVICA = new DataColumn("OSOSNOVICA", typeof(decimal), "", MappingType.Element);
                this.columnOSOSNOVICA.AllowDBNull = false;
                this.columnOSOSNOVICA.Caption = "OSOSNOVICA";
                this.columnOSOSNOVICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSOSNOVICA.ExtendedProperties.Add("IsKey", "false");
                this.columnOSOSNOVICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSOSNOVICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Description", "Osnovica");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Length", "12");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Decimals", "2");
                this.columnOSOSNOVICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSOSNOVICA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSOSNOVICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSOSNOVICA.ExtendedProperties.Add("Deklarit.InternalName", "OSOSNOVICA");
                this.Columns.Add(this.columnOSOSNOVICA);
                this.columnOSDUGUJE = new DataColumn("OSDUGUJE", typeof(decimal), "", MappingType.Element);
                this.columnOSDUGUJE.AllowDBNull = false;
                this.columnOSDUGUJE.Caption = "OSDUGUJE";
                this.columnOSDUGUJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSDUGUJE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSDUGUJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSDUGUJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSDUGUJE.ExtendedProperties.Add("Description", "Duguje");
                this.columnOSDUGUJE.ExtendedProperties.Add("Length", "12");
                this.columnOSDUGUJE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSDUGUJE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSDUGUJE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSDUGUJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSDUGUJE.ExtendedProperties.Add("Deklarit.InternalName", "OSDUGUJE");
                this.Columns.Add(this.columnOSDUGUJE);
                this.columnOSPOTRAZUJE = new DataColumn("OSPOTRAZUJE", typeof(decimal), "", MappingType.Element);
                this.columnOSPOTRAZUJE.AllowDBNull = false;
                this.columnOSPOTRAZUJE.Caption = "OSPOTRAZUJE";
                this.columnOSPOTRAZUJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("IsKey", "false");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Description", "Potražuje");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Length", "12");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Decimals", "2");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSPOTRAZUJE.ExtendedProperties.Add("Deklarit.InternalName", "OSPOTRAZUJE");
                this.Columns.Add(this.columnOSPOTRAZUJE);
                this.columnRASHODLOKACIJEIDLOKACIJE = new DataColumn("RASHODLOKACIJEIDLOKACIJE", typeof(int), "", MappingType.Element);
                this.columnRASHODLOKACIJEIDLOKACIJE.AllowDBNull = true;
                this.columnRASHODLOKACIJEIDLOKACIJE.Caption = "IDLOKACIJE";
                this.columnRASHODLOKACIJEIDLOKACIJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("SuperType", "IDLOKACIJE");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("SubtypeGroup", "RASHODLOKACIJE");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("IsKey", "false");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("Description", "Lokacija");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("Length", "5");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("Decimals", "0");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRASHODLOKACIJEIDLOKACIJE.ExtendedProperties.Add("Deklarit.InternalName", "RASHODLOKACIJEIDLOKACIJE");
                this.Columns.Add(this.columnRASHODLOKACIJEIDLOKACIJE);
                this.columnOSOPIS = new DataColumn("OSOPIS", typeof(string), "", MappingType.Element);
                this.columnOSOPIS.AllowDBNull = false;
                this.columnOSOPIS.Caption = "OSOPIS";
                this.columnOSOPIS.MaxLength = 40;
                this.columnOSOPIS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSOPIS.ExtendedProperties.Add("IsKey", "false");
                this.columnOSOPIS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSOPIS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOSOPIS.ExtendedProperties.Add("Description", "Opis");
                this.columnOSOPIS.ExtendedProperties.Add("Length", "40");
                this.columnOSOPIS.ExtendedProperties.Add("Decimals", "0");
                this.columnOSOPIS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.InternalName", "OSOPIS");
                this.Columns.Add(this.columnOSOPIS);
                this.columnNAZIVOSDOKUMENT = new DataColumn("NAZIVOSDOKUMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVOSDOKUMENT.AllowDBNull = true;
                this.columnNAZIVOSDOKUMENT.Caption = "NAZIVOSDOKUMENT";
                this.columnNAZIVOSDOKUMENT.MaxLength = 30;
                this.columnNAZIVOSDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Description", "NAZIVOSDOKUMENT");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Length", "30");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOSDOKUMENT");
                this.Columns.Add(this.columnNAZIVOSDOKUMENT);
                this.PrimaryKey = new DataColumn[] { this.columnINVBROJ, this.columnIDOSDOKUMENT, this.columnOSBROJDOKUMENTA };
                this.ExtendedProperties.Add("ParentLvl", "OS");
                this.ExtendedProperties.Add("LevelName", "TEMELJNICA");
                this.ExtendedProperties.Add("Description", "TEMELJNICA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnINVBROJ = this.Columns["INVBROJ"];
                this.columnIDOSDOKUMENT = this.Columns["IDOSDOKUMENT"];
                this.columnOSBROJDOKUMENTA = this.Columns["OSBROJDOKUMENTA"];
                this.columnOSDATUMDOK = this.Columns["OSDATUMDOK"];
                this.columnOSKOLICINA = this.Columns["OSKOLICINA"];
                this.columnOSSTOPA = this.Columns["OSSTOPA"];
                this.columnOSOSNOVICA = this.Columns["OSOSNOVICA"];
                this.columnOSDUGUJE = this.Columns["OSDUGUJE"];
                this.columnOSPOTRAZUJE = this.Columns["OSPOTRAZUJE"];
                this.columnRASHODLOKACIJEIDLOKACIJE = this.Columns["RASHODLOKACIJEIDLOKACIJE"];
                this.columnOSOPIS = this.Columns["OSOPIS"];
                this.columnNAZIVOSDOKUMENT = this.Columns["NAZIVOSDOKUMENT"];
            }

            public OSDataSet.OSTEMELJNICARow NewOSTEMELJNICARow()
            {
                return (OSDataSet.OSTEMELJNICARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OSDataSet.OSTEMELJNICARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OSTEMELJNICARowChanged != null)
                {
                    OSDataSet.OSTEMELJNICARowChangeEventHandler oSTEMELJNICARowChangedEvent = this.OSTEMELJNICARowChanged;
                    if (oSTEMELJNICARowChangedEvent != null)
                    {
                        oSTEMELJNICARowChangedEvent(this, new OSDataSet.OSTEMELJNICARowChangeEvent((OSDataSet.OSTEMELJNICARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OSTEMELJNICARowChanging != null)
                {
                    OSDataSet.OSTEMELJNICARowChangeEventHandler oSTEMELJNICARowChangingEvent = this.OSTEMELJNICARowChanging;
                    if (oSTEMELJNICARowChangingEvent != null)
                    {
                        oSTEMELJNICARowChangingEvent(this, new OSDataSet.OSTEMELJNICARowChangeEvent((OSDataSet.OSTEMELJNICARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("OS_OSTEMELJNICA", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.OSTEMELJNICARowDeleted != null)
                {
                    OSDataSet.OSTEMELJNICARowChangeEventHandler oSTEMELJNICARowDeletedEvent = this.OSTEMELJNICARowDeleted;
                    if (oSTEMELJNICARowDeletedEvent != null)
                    {
                        oSTEMELJNICARowDeletedEvent(this, new OSDataSet.OSTEMELJNICARowChangeEvent((OSDataSet.OSTEMELJNICARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OSTEMELJNICARowDeleting != null)
                {
                    OSDataSet.OSTEMELJNICARowChangeEventHandler oSTEMELJNICARowDeletingEvent = this.OSTEMELJNICARowDeleting;
                    if (oSTEMELJNICARowDeletingEvent != null)
                    {
                        oSTEMELJNICARowDeletingEvent(this, new OSDataSet.OSTEMELJNICARowChangeEvent((OSDataSet.OSTEMELJNICARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOSTEMELJNICARow(OSDataSet.OSTEMELJNICARow row)
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

            public DataColumn INVBROJColumn
            {
                get
                {
                    return this.columnINVBROJ;
                }
            }

            public OSDataSet.OSTEMELJNICARow this[int index]
            {
                get
                {
                    return (OSDataSet.OSTEMELJNICARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVOSDOKUMENTColumn
            {
                get
                {
                    return this.columnNAZIVOSDOKUMENT;
                }
            }

            public DataColumn OSBROJDOKUMENTAColumn
            {
                get
                {
                    return this.columnOSBROJDOKUMENTA;
                }
            }

            public DataColumn OSDATUMDOKColumn
            {
                get
                {
                    return this.columnOSDATUMDOK;
                }
            }

            public DataColumn OSDUGUJEColumn
            {
                get
                {
                    return this.columnOSDUGUJE;
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

            public DataColumn OSPOTRAZUJEColumn
            {
                get
                {
                    return this.columnOSPOTRAZUJE;
                }
            }

            public DataColumn OSSTOPAColumn
            {
                get
                {
                    return this.columnOSSTOPA;
                }
            }

            public DataColumn RASHODLOKACIJEIDLOKACIJEColumn
            {
                get
                {
                    return this.columnRASHODLOKACIJEIDLOKACIJE;
                }
            }
        }

        public class OSTEMELJNICARow : DataRow
        {
            private OSDataSet.OSTEMELJNICADataTable tableOSTEMELJNICA;

            internal OSTEMELJNICARow(DataRowBuilder rb) : base(rb)
            {
                this.tableOSTEMELJNICA = (OSDataSet.OSTEMELJNICADataTable) this.Table;
            }

            public OSDataSet.OSRow GetOSRow()
            {
                return (OSDataSet.OSRow) this.GetParentRow("OS_OSTEMELJNICA");
            }

            public bool IsIDOSDOKUMENTNull()
            {
                return this.IsNull(this.tableOSTEMELJNICA.IDOSDOKUMENTColumn);
            }

            public bool IsINVBROJNull()
            {
                return this.IsNull(this.tableOSTEMELJNICA.INVBROJColumn);
            }

            public bool IsNAZIVOSDOKUMENTNull()
            {
                return this.IsNull(this.tableOSTEMELJNICA.NAZIVOSDOKUMENTColumn);
            }

            public bool IsOSBROJDOKUMENTANull()
            {
                return this.IsNull(this.tableOSTEMELJNICA.OSBROJDOKUMENTAColumn);
            }

            public bool IsOSDATUMDOKNull()
            {
                return this.IsNull(this.tableOSTEMELJNICA.OSDATUMDOKColumn);
            }

            public bool IsOSDUGUJENull()
            {
                return this.IsNull(this.tableOSTEMELJNICA.OSDUGUJEColumn);
            }

            public bool IsOSKOLICINANull()
            {
                return this.IsNull(this.tableOSTEMELJNICA.OSKOLICINAColumn);
            }

            public bool IsOSOPISNull()
            {
                return this.IsNull(this.tableOSTEMELJNICA.OSOPISColumn);
            }

            public bool IsOSOSNOVICANull()
            {
                return this.IsNull(this.tableOSTEMELJNICA.OSOSNOVICAColumn);
            }

            public bool IsOSPOTRAZUJENull()
            {
                return this.IsNull(this.tableOSTEMELJNICA.OSPOTRAZUJEColumn);
            }

            public bool IsOSSTOPANull()
            {
                return this.IsNull(this.tableOSTEMELJNICA.OSSTOPAColumn);
            }

            public bool IsRASHODLOKACIJEIDLOKACIJENull()
            {
                return this.IsNull(this.tableOSTEMELJNICA.RASHODLOKACIJEIDLOKACIJEColumn);
            }

            public void SetNAZIVOSDOKUMENTNull()
            {
                this[this.tableOSTEMELJNICA.NAZIVOSDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSDATUMDOKNull()
            {
                this[this.tableOSTEMELJNICA.OSDATUMDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSDUGUJENull()
            {
                this[this.tableOSTEMELJNICA.OSDUGUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSKOLICINANull()
            {
                this[this.tableOSTEMELJNICA.OSKOLICINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSOPISNull()
            {
                this[this.tableOSTEMELJNICA.OSOPISColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSOSNOVICANull()
            {
                this[this.tableOSTEMELJNICA.OSOSNOVICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSPOTRAZUJENull()
            {
                this[this.tableOSTEMELJNICA.OSPOTRAZUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSSTOPANull()
            {
                this[this.tableOSTEMELJNICA.OSSTOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRASHODLOKACIJEIDLOKACIJENull()
            {
                this[this.tableOSTEMELJNICA.RASHODLOKACIJEIDLOKACIJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDOSDOKUMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOSTEMELJNICA.IDOSDOKUMENTColumn]);
                }
                set
                {
                    this[this.tableOSTEMELJNICA.IDOSDOKUMENTColumn] = value;
                }
            }

            public long INVBROJ
            {
                get
                {
                    return Conversions.ToLong(this[this.tableOSTEMELJNICA.INVBROJColumn]);
                }
                set
                {
                    this[this.tableOSTEMELJNICA.INVBROJColumn] = value;
                }
            }

            public string NAZIVOSDOKUMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOSTEMELJNICA.NAZIVOSDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOSTEMELJNICA.NAZIVOSDOKUMENTColumn] = value;
                }
            }

            public int OSBROJDOKUMENTA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOSTEMELJNICA.OSBROJDOKUMENTAColumn]);
                }
                set
                {
                    this[this.tableOSTEMELJNICA.OSBROJDOKUMENTAColumn] = value;
                }
            }

            public DateTime OSDATUMDOK
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableOSTEMELJNICA.OSDATUMDOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableOSTEMELJNICA.OSDATUMDOKColumn] = value;
                }
            }

            public decimal OSDUGUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOSTEMELJNICA.OSDUGUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOSTEMELJNICA.OSDUGUJEColumn] = value;
                }
            }

            public decimal OSKOLICINA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOSTEMELJNICA.OSKOLICINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOSTEMELJNICA.OSKOLICINAColumn] = value;
                }
            }

            public string OSOPIS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOSTEMELJNICA.OSOPISColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOSTEMELJNICA.OSOPISColumn] = value;
                }
            }

            public decimal OSOSNOVICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOSTEMELJNICA.OSOSNOVICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOSTEMELJNICA.OSOSNOVICAColumn] = value;
                }
            }

            public decimal OSPOTRAZUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOSTEMELJNICA.OSPOTRAZUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOSTEMELJNICA.OSPOTRAZUJEColumn] = value;
                }
            }

            public decimal OSSTOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOSTEMELJNICA.OSSTOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOSTEMELJNICA.OSSTOPAColumn] = value;
                }
            }

            public int RASHODLOKACIJEIDLOKACIJE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableOSTEMELJNICA.RASHODLOKACIJEIDLOKACIJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOSTEMELJNICA.RASHODLOKACIJEIDLOKACIJEColumn] = value;
                }
            }
        }

        public class OSTEMELJNICARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OSDataSet.OSTEMELJNICARow eventRow;

            public OSTEMELJNICARowChangeEvent(OSDataSet.OSTEMELJNICARow row, DataRowAction action)
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

            public OSDataSet.OSTEMELJNICARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OSTEMELJNICARowChangeEventHandler(object sender, OSDataSet.OSTEMELJNICARowChangeEvent e);
    }
}

