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
    public class AMSKUPINEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private AMSKUPINEDataTable tableAMSKUPINE;

        public AMSKUPINEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected AMSKUPINEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["AMSKUPINE"] != null)
                    {
                        this.Tables.Add(new AMSKUPINEDataTable(dataSet.Tables["AMSKUPINE"]));
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
            AMSKUPINEDataSet set = (AMSKUPINEDataSet) base.Clone();
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
            AMSKUPINEDataSet set = new AMSKUPINEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "AMSKUPINEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2141");
            this.ExtendedProperties.Add("DataSetName", "AMSKUPINEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IAMSKUPINEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "AMSKUPINE");
            this.ExtendedProperties.Add("ObjectDescription", "Amortizacijske skupine");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\OSNOVNA");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "AM");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "AMSKUPINEDataSet";
            this.Namespace = "http://www.tempuri.org/AMSKUPINE";
            this.tableAMSKUPINE = new AMSKUPINEDataTable();
            this.Tables.Add(this.tableAMSKUPINE);
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
            this.tableAMSKUPINE = (AMSKUPINEDataTable) this.Tables["AMSKUPINE"];
            if (initTable && (this.tableAMSKUPINE != null))
            {
                this.tableAMSKUPINE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["AMSKUPINE"] != null)
                {
                    this.Tables.Add(new AMSKUPINEDataTable(dataSet.Tables["AMSKUPINE"]));
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

        private bool ShouldSerializeAMSKUPINE()
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
        public AMSKUPINEDataTable AMSKUPINE
        {
            get
            {
                return this.tableAMSKUPINE;
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
        public class AMSKUPINEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAM;
            private DataColumn columnAMSKUPINASTOPA;
            private DataColumn columnIDAMSKUPINE;
            private DataColumn columnKRATKASIFRA;
            private DataColumn columnKTOISPRAVKAIDKONTO;
            private DataColumn columnKTOIZVORAIDKONTO;
            private DataColumn columnKTONABAVKEIDKONTO;
            private DataColumn columnOPISAMSKUPINE;

            public event AMSKUPINEDataSet.AMSKUPINERowChangeEventHandler AMSKUPINERowChanged;

            public event AMSKUPINEDataSet.AMSKUPINERowChangeEventHandler AMSKUPINERowChanging;

            public event AMSKUPINEDataSet.AMSKUPINERowChangeEventHandler AMSKUPINERowDeleted;

            public event AMSKUPINEDataSet.AMSKUPINERowChangeEventHandler AMSKUPINERowDeleting;

            public AMSKUPINEDataTable()
            {
                this.TableName = "AMSKUPINE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal AMSKUPINEDataTable(DataTable table) : base(table.TableName)
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

            protected AMSKUPINEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddAMSKUPINERow(AMSKUPINEDataSet.AMSKUPINERow row)
            {
                this.Rows.Add(row);
            }

            public AMSKUPINEDataSet.AMSKUPINERow AddAMSKUPINERow(int iDAMSKUPINE, string kRATKASIFRA, string oPISAMSKUPINE, decimal aMSKUPINASTOPA, string kTONABAVKEIDKONTO, string kTOISPRAVKAIDKONTO, string kTOIZVORAIDKONTO)
            {
                AMSKUPINEDataSet.AMSKUPINERow row = (AMSKUPINEDataSet.AMSKUPINERow) this.NewRow();
                row["IDAMSKUPINE"] = iDAMSKUPINE;
                row["KRATKASIFRA"] = kRATKASIFRA;
                row["OPISAMSKUPINE"] = oPISAMSKUPINE;
                row["AMSKUPINASTOPA"] = aMSKUPINASTOPA;
                row["KTONABAVKEIDKONTO"] = kTONABAVKEIDKONTO;
                row["KTOISPRAVKAIDKONTO"] = kTOISPRAVKAIDKONTO;
                row["KTOIZVORAIDKONTO"] = kTOIZVORAIDKONTO;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                AMSKUPINEDataSet.AMSKUPINEDataTable table = (AMSKUPINEDataSet.AMSKUPINEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public AMSKUPINEDataSet.AMSKUPINERow FindByIDAMSKUPINE(int iDAMSKUPINE)
            {
                return (AMSKUPINEDataSet.AMSKUPINERow) this.Rows.Find(new object[] { iDAMSKUPINE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(AMSKUPINEDataSet.AMSKUPINERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                AMSKUPINEDataSet set = new AMSKUPINEDataSet();
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
                this.columnIDAMSKUPINE = new DataColumn("IDAMSKUPINE", typeof(int), "", MappingType.Element);
                this.columnIDAMSKUPINE.AllowDBNull = false;
                this.columnIDAMSKUPINE.Caption = "IDAMSKUPINE";
                this.columnIDAMSKUPINE.Unique = true;
                this.columnIDAMSKUPINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Description", "Šfr.");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Length", "5");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDAMSKUPINE.ExtendedProperties.Add("Deklarit.InternalName", "IDAMSKUPINE");
                this.Columns.Add(this.columnIDAMSKUPINE);
                this.columnKRATKASIFRA = new DataColumn("KRATKASIFRA", typeof(string), "", MappingType.Element);
                this.columnKRATKASIFRA.AllowDBNull = true;
                this.columnKRATKASIFRA.Caption = "KRATKASIFRA";
                this.columnKRATKASIFRA.MaxLength = 15;
                this.columnKRATKASIFRA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKRATKASIFRA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKRATKASIFRA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKRATKASIFRA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKRATKASIFRA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKRATKASIFRA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKRATKASIFRA.ExtendedProperties.Add("IsKey", "false");
                this.columnKRATKASIFRA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKRATKASIFRA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKRATKASIFRA.ExtendedProperties.Add("Description", "Kratka šifra");
                this.columnKRATKASIFRA.ExtendedProperties.Add("Length", "15");
                this.columnKRATKASIFRA.ExtendedProperties.Add("Decimals", "0");
                this.columnKRATKASIFRA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKRATKASIFRA.ExtendedProperties.Add("IsInReader", "true");
                this.columnKRATKASIFRA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKRATKASIFRA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKRATKASIFRA.ExtendedProperties.Add("Deklarit.InternalName", "KRATKASIFRA");
                this.Columns.Add(this.columnKRATKASIFRA);
                this.columnOPISAMSKUPINE = new DataColumn("OPISAMSKUPINE", typeof(string), "", MappingType.Element);
                this.columnOPISAMSKUPINE.AllowDBNull = false;
                this.columnOPISAMSKUPINE.Caption = "OPISAMSKUPINE";
                this.columnOPISAMSKUPINE.MaxLength = 100;
                this.columnOPISAMSKUPINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Description", "Opis skupine");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Length", "100");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISAMSKUPINE.ExtendedProperties.Add("Deklarit.InternalName", "OPISAMSKUPINE");
                this.Columns.Add(this.columnOPISAMSKUPINE);
                this.columnAMSKUPINASTOPA = new DataColumn("AMSKUPINASTOPA", typeof(decimal), "", MappingType.Element);
                this.columnAMSKUPINASTOPA.AllowDBNull = false;
                this.columnAMSKUPINASTOPA.Caption = "AMSKUPINASTOPA";
                this.columnAMSKUPINASTOPA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Description", "Amortizacijska stopa");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Length", "5");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("IsInReader", "true");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnAMSKUPINASTOPA.ExtendedProperties.Add("Deklarit.InternalName", "AMSKUPINASTOPA");
                this.Columns.Add(this.columnAMSKUPINASTOPA);
                this.columnKTONABAVKEIDKONTO = new DataColumn("KTONABAVKEIDKONTO", typeof(string), "", MappingType.Element);
                this.columnKTONABAVKEIDKONTO.AllowDBNull = false;
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
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKTONABAVKEIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "KTONABAVKEIDKONTO");
                this.Columns.Add(this.columnKTONABAVKEIDKONTO);
                this.columnKTOISPRAVKAIDKONTO = new DataColumn("KTOISPRAVKAIDKONTO", typeof(string), "", MappingType.Element);
                this.columnKTOISPRAVKAIDKONTO.AllowDBNull = false;
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
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKTOISPRAVKAIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "KTOISPRAVKAIDKONTO");
                this.Columns.Add(this.columnKTOISPRAVKAIDKONTO);
                this.columnKTOIZVORAIDKONTO = new DataColumn("KTOIZVORAIDKONTO", typeof(string), "", MappingType.Element);
                this.columnKTOIZVORAIDKONTO.AllowDBNull = false;
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
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKTOIZVORAIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "KTOIZVORAIDKONTO");
                this.Columns.Add(this.columnKTOIZVORAIDKONTO);
                this.columnAM = new DataColumn("AM", typeof(string), "", MappingType.Element);
                this.columnAM.AllowDBNull = true;
                this.columnAM.Caption = "AM";
                this.columnAM.MaxLength = 110;
                this.columnAM.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnAM.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnAM.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnAM.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnAM.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnAM.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnAM.ExtendedProperties.Add("IsKey", "false");
                this.columnAM.ExtendedProperties.Add("ReadOnly", "true");
                this.columnAM.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnAM.ExtendedProperties.Add("Description", "AM");
                this.columnAM.ExtendedProperties.Add("Length", "110");
                this.columnAM.ExtendedProperties.Add("Decimals", "0");
                this.columnAM.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnAM.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnAM.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnAM.ExtendedProperties.Add("Deklarit.InternalName", "AM");
                this.Columns.Add(this.columnAM);
                this.PrimaryKey = new DataColumn[] { this.columnIDAMSKUPINE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "AMSKUPINE");
                this.ExtendedProperties.Add("Description", "Amortizacijske skupine");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDAMSKUPINE = this.Columns["IDAMSKUPINE"];
                this.columnKRATKASIFRA = this.Columns["KRATKASIFRA"];
                this.columnOPISAMSKUPINE = this.Columns["OPISAMSKUPINE"];
                this.columnAMSKUPINASTOPA = this.Columns["AMSKUPINASTOPA"];
                this.columnKTONABAVKEIDKONTO = this.Columns["KTONABAVKEIDKONTO"];
                this.columnKTOISPRAVKAIDKONTO = this.Columns["KTOISPRAVKAIDKONTO"];
                this.columnKTOIZVORAIDKONTO = this.Columns["KTOIZVORAIDKONTO"];
                this.columnAM = this.Columns["AM"];
            }

            public AMSKUPINEDataSet.AMSKUPINERow NewAMSKUPINERow()
            {
                return (AMSKUPINEDataSet.AMSKUPINERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new AMSKUPINEDataSet.AMSKUPINERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.AMSKUPINERowChanged != null)
                {
                    AMSKUPINEDataSet.AMSKUPINERowChangeEventHandler aMSKUPINERowChangedEvent = this.AMSKUPINERowChanged;
                    if (aMSKUPINERowChangedEvent != null)
                    {
                        aMSKUPINERowChangedEvent(this, new AMSKUPINEDataSet.AMSKUPINERowChangeEvent((AMSKUPINEDataSet.AMSKUPINERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.AMSKUPINERowChanging != null)
                {
                    AMSKUPINEDataSet.AMSKUPINERowChangeEventHandler aMSKUPINERowChangingEvent = this.AMSKUPINERowChanging;
                    if (aMSKUPINERowChangingEvent != null)
                    {
                        aMSKUPINERowChangingEvent(this, new AMSKUPINEDataSet.AMSKUPINERowChangeEvent((AMSKUPINEDataSet.AMSKUPINERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.AMSKUPINERowDeleted != null)
                {
                    AMSKUPINEDataSet.AMSKUPINERowChangeEventHandler aMSKUPINERowDeletedEvent = this.AMSKUPINERowDeleted;
                    if (aMSKUPINERowDeletedEvent != null)
                    {
                        aMSKUPINERowDeletedEvent(this, new AMSKUPINEDataSet.AMSKUPINERowChangeEvent((AMSKUPINEDataSet.AMSKUPINERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.AMSKUPINERowDeleting != null)
                {
                    AMSKUPINEDataSet.AMSKUPINERowChangeEventHandler aMSKUPINERowDeletingEvent = this.AMSKUPINERowDeleting;
                    if (aMSKUPINERowDeletingEvent != null)
                    {
                        aMSKUPINERowDeletingEvent(this, new AMSKUPINEDataSet.AMSKUPINERowChangeEvent((AMSKUPINEDataSet.AMSKUPINERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveAMSKUPINERow(AMSKUPINEDataSet.AMSKUPINERow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn AMColumn
            {
                get
                {
                    return this.columnAM;
                }
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

            public DataColumn IDAMSKUPINEColumn
            {
                get
                {
                    return this.columnIDAMSKUPINE;
                }
            }

            public AMSKUPINEDataSet.AMSKUPINERow this[int index]
            {
                get
                {
                    return (AMSKUPINEDataSet.AMSKUPINERow) this.Rows[index];
                }
            }

            public DataColumn KRATKASIFRAColumn
            {
                get
                {
                    return this.columnKRATKASIFRA;
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

            public DataColumn OPISAMSKUPINEColumn
            {
                get
                {
                    return this.columnOPISAMSKUPINE;
                }
            }
        }

        public class AMSKUPINERow : DataRow
        {
            private AMSKUPINEDataSet.AMSKUPINEDataTable tableAMSKUPINE;

            internal AMSKUPINERow(DataRowBuilder rb) : base(rb)
            {
                this.tableAMSKUPINE = (AMSKUPINEDataSet.AMSKUPINEDataTable) this.Table;
            }

            public bool IsAMNull()
            {
                return this.IsNull(this.tableAMSKUPINE.AMColumn);
            }

            public bool IsAMSKUPINASTOPANull()
            {
                return this.IsNull(this.tableAMSKUPINE.AMSKUPINASTOPAColumn);
            }

            public bool IsIDAMSKUPINENull()
            {
                return this.IsNull(this.tableAMSKUPINE.IDAMSKUPINEColumn);
            }

            public bool IsKRATKASIFRANull()
            {
                return this.IsNull(this.tableAMSKUPINE.KRATKASIFRAColumn);
            }

            public bool IsKTOISPRAVKAIDKONTONull()
            {
                return this.IsNull(this.tableAMSKUPINE.KTOISPRAVKAIDKONTOColumn);
            }

            public bool IsKTOIZVORAIDKONTONull()
            {
                return this.IsNull(this.tableAMSKUPINE.KTOIZVORAIDKONTOColumn);
            }

            public bool IsKTONABAVKEIDKONTONull()
            {
                return this.IsNull(this.tableAMSKUPINE.KTONABAVKEIDKONTOColumn);
            }

            public bool IsOPISAMSKUPINENull()
            {
                return this.IsNull(this.tableAMSKUPINE.OPISAMSKUPINEColumn);
            }

            public void SetAMNull()
            {
                this[this.tableAMSKUPINE.AMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetAMSKUPINASTOPANull()
            {
                this[this.tableAMSKUPINE.AMSKUPINASTOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKRATKASIFRANull()
            {
                this[this.tableAMSKUPINE.KRATKASIFRAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTOISPRAVKAIDKONTONull()
            {
                this[this.tableAMSKUPINE.KTOISPRAVKAIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTOIZVORAIDKONTONull()
            {
                this[this.tableAMSKUPINE.KTOIZVORAIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTONABAVKEIDKONTONull()
            {
                this[this.tableAMSKUPINE.KTONABAVKEIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISAMSKUPINENull()
            {
                this[this.tableAMSKUPINE.OPISAMSKUPINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string AM
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableAMSKUPINE.AMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value AM because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableAMSKUPINE.AMColumn] = value;
                }
            }

            public decimal AMSKUPINASTOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableAMSKUPINE.AMSKUPINASTOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value AMSKUPINASTOPA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableAMSKUPINE.AMSKUPINASTOPAColumn] = value;
                }
            }

            public int IDAMSKUPINE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableAMSKUPINE.IDAMSKUPINEColumn]);
                }
                set
                {
                    this[this.tableAMSKUPINE.IDAMSKUPINEColumn] = value;
                }
            }

            public string KRATKASIFRA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableAMSKUPINE.KRATKASIFRAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value KRATKASIFRA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableAMSKUPINE.KRATKASIFRAColumn] = value;
                }
            }

            public string KTOISPRAVKAIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableAMSKUPINE.KTOISPRAVKAIDKONTOColumn]);
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
                    this[this.tableAMSKUPINE.KTOISPRAVKAIDKONTOColumn] = value;
                }
            }

            public string KTOIZVORAIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableAMSKUPINE.KTOIZVORAIDKONTOColumn]);
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
                    this[this.tableAMSKUPINE.KTOIZVORAIDKONTOColumn] = value;
                }
            }

            public string KTONABAVKEIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableAMSKUPINE.KTONABAVKEIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableAMSKUPINE.KTONABAVKEIDKONTOColumn] = value;
                }
            }

            public string OPISAMSKUPINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableAMSKUPINE.OPISAMSKUPINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableAMSKUPINE.OPISAMSKUPINEColumn] = value;
                }
            }
        }

        public class AMSKUPINERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private AMSKUPINEDataSet.AMSKUPINERow eventRow;

            public AMSKUPINERowChangeEvent(AMSKUPINEDataSet.AMSKUPINERow row, DataRowAction action)
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

            public AMSKUPINEDataSet.AMSKUPINERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void AMSKUPINERowChangeEventHandler(object sender, AMSKUPINEDataSet.AMSKUPINERowChangeEvent e);
    }
}

