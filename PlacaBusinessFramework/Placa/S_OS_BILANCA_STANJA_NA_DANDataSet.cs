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
    public class S_OS_BILANCA_STANJA_NA_DANDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OS_BILANCA_STANJA_NA_DANDataTable tableS_OS_BILANCA_STANJA_NA_DAN;

        public S_OS_BILANCA_STANJA_NA_DANDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OS_BILANCA_STANJA_NA_DANDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OS_BILANCA_STANJA_NA_DAN"] != null)
                    {
                        this.Tables.Add(new S_OS_BILANCA_STANJA_NA_DANDataTable(dataSet.Tables["S_OS_BILANCA_STANJA_NA_DAN"]));
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
            S_OS_BILANCA_STANJA_NA_DANDataSet set = (S_OS_BILANCA_STANJA_NA_DANDataSet) base.Clone();
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
            S_OS_BILANCA_STANJA_NA_DANDataSet set = new S_OS_BILANCA_STANJA_NA_DANDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OS_BILANCA_STANJA_NA_DANDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2161");
            this.ExtendedProperties.Add("DataSetName", "S_OS_BILANCA_STANJA_NA_DANDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OS_BILANCA_STANJA_NA_DANDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OS_BILANCA_STANJA_NA_DAN");
            this.ExtendedProperties.Add("ObjectDescription", "S_OS_BILANCA_STANJA_NA_DAN");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\OSNOVNA");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_OS_BILANCA_STANJA_NA_DAN");
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
            this.DataSetName = "S_OS_BILANCA_STANJA_NA_DANDataSet";
            this.Namespace = "http://www.tempuri.org/S_OS_BILANCA_STANJA_NA_DAN";
            this.tableS_OS_BILANCA_STANJA_NA_DAN = new S_OS_BILANCA_STANJA_NA_DANDataTable();
            this.Tables.Add(this.tableS_OS_BILANCA_STANJA_NA_DAN);
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
            this.tableS_OS_BILANCA_STANJA_NA_DAN = (S_OS_BILANCA_STANJA_NA_DANDataTable) this.Tables["S_OS_BILANCA_STANJA_NA_DAN"];
            if (initTable && (this.tableS_OS_BILANCA_STANJA_NA_DAN != null))
            {
                this.tableS_OS_BILANCA_STANJA_NA_DAN.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OS_BILANCA_STANJA_NA_DAN"] != null)
                {
                    this.Tables.Add(new S_OS_BILANCA_STANJA_NA_DANDataTable(dataSet.Tables["S_OS_BILANCA_STANJA_NA_DAN"]));
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

        private bool ShouldSerializeS_OS_BILANCA_STANJA_NA_DAN()
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
        public S_OS_BILANCA_STANJA_NA_DANDataTable S_OS_BILANCA_STANJA_NA_DAN
        {
            get
            {
                return this.tableS_OS_BILANCA_STANJA_NA_DAN;
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
        public class S_OS_BILANCA_STANJA_NA_DANDataTable : DataTable, IEnumerable
        {
            private DataColumn columnINVBROJ;
            private DataColumn columnISPRAVAK;
            private DataColumn columnKOLICINA;
            private DataColumn columnKTOISPRAVKAIDKONTO;
            private DataColumn columnKTOIZVORAIDKONTO;
            private DataColumn columnKTONABAVKEIDKONTO;
            private DataColumn columnNABAVNA;
            private DataColumn columnNAZIVOS;
            private DataColumn columnSADASNJA;

            public event S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRowChangeEventHandler S_OS_BILANCA_STANJA_NA_DANRowChanged;

            public event S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRowChangeEventHandler S_OS_BILANCA_STANJA_NA_DANRowChanging;

            public event S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRowChangeEventHandler S_OS_BILANCA_STANJA_NA_DANRowDeleted;

            public event S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRowChangeEventHandler S_OS_BILANCA_STANJA_NA_DANRowDeleting;

            public S_OS_BILANCA_STANJA_NA_DANDataTable()
            {
                this.TableName = "S_OS_BILANCA_STANJA_NA_DAN";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OS_BILANCA_STANJA_NA_DANDataTable(DataTable table) : base(table.TableName)
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

            protected S_OS_BILANCA_STANJA_NA_DANDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OS_BILANCA_STANJA_NA_DANRow(S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow row)
            {
                this.Rows.Add(row);
            }

            public S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow AddS_OS_BILANCA_STANJA_NA_DANRow(string nAZIVOS, long iNVBROJ, decimal kOLICINA, decimal nABAVNA, decimal iSPRAVAK, decimal sADASNJA, string kTOISPRAVKAIDKONTO, string kTONABAVKEIDKONTO, string kTOIZVORAIDKONTO)
            {
                S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow row = (S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow) this.NewRow();
                row.ItemArray = new object[] { nAZIVOS, iNVBROJ, kOLICINA, nABAVNA, iSPRAVAK, sADASNJA, kTOISPRAVKAIDKONTO, kTONABAVKEIDKONTO, kTOIZVORAIDKONTO };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANDataTable table = (S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OS_BILANCA_STANJA_NA_DANDataSet set = new S_OS_BILANCA_STANJA_NA_DANDataSet();
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
                this.columnNAZIVOS = new DataColumn("NAZIVOS", typeof(string), "", MappingType.Element);
                this.columnNAZIVOS.Caption = "NAZIVOS";
                this.columnNAZIVOS.MaxLength = 50;
                this.columnNAZIVOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVOS.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOS.ExtendedProperties.Add("Description", "NAZIVOS");
                this.columnNAZIVOS.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVOS.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOS.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOS");
                this.Columns.Add(this.columnNAZIVOS);
                this.columnINVBROJ = new DataColumn("INVBROJ", typeof(long), "", MappingType.Element);
                this.columnINVBROJ.Caption = "Inventarni broj";
                this.columnINVBROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnINVBROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnINVBROJ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnINVBROJ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnINVBROJ.ExtendedProperties.Add("Description", "Inventarni broj");
                this.columnINVBROJ.ExtendedProperties.Add("Length", "12");
                this.columnINVBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnINVBROJ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnINVBROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnINVBROJ.ExtendedProperties.Add("Deklarit.InternalName", "INVBROJ");
                this.Columns.Add(this.columnINVBROJ);
                this.columnKOLICINA = new DataColumn("KOLICINA", typeof(decimal), "", MappingType.Element);
                this.columnKOLICINA.Caption = "Količina";
                this.columnKOLICINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOLICINA.ExtendedProperties.Add("IsKey", "false");
                this.columnKOLICINA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOLICINA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOLICINA.ExtendedProperties.Add("Description", "Količina");
                this.columnKOLICINA.ExtendedProperties.Add("Length", "12");
                this.columnKOLICINA.ExtendedProperties.Add("Decimals", "2");
                this.columnKOLICINA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOLICINA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOLICINA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKOLICINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOLICINA.ExtendedProperties.Add("Deklarit.InternalName", "KOLICINA");
                this.Columns.Add(this.columnKOLICINA);
                this.columnNABAVNA = new DataColumn("NABAVNA", typeof(decimal), "", MappingType.Element);
                this.columnNABAVNA.Caption = "Nabavna";
                this.columnNABAVNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNABAVNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNABAVNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNABAVNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNABAVNA.ExtendedProperties.Add("IsKey", "false");
                this.columnNABAVNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNABAVNA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNABAVNA.ExtendedProperties.Add("Description", "Nabavna");
                this.columnNABAVNA.ExtendedProperties.Add("Length", "12");
                this.columnNABAVNA.ExtendedProperties.Add("Decimals", "2");
                this.columnNABAVNA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNABAVNA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNABAVNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNABAVNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNABAVNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNABAVNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNABAVNA.ExtendedProperties.Add("Deklarit.InternalName", "NABAVNA");
                this.Columns.Add(this.columnNABAVNA);
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
                this.columnSADASNJA = new DataColumn("SADASNJA", typeof(decimal), "", MappingType.Element);
                this.columnSADASNJA.Caption = "Sadašnja";
                this.columnSADASNJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSADASNJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSADASNJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSADASNJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSADASNJA.ExtendedProperties.Add("IsKey", "false");
                this.columnSADASNJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSADASNJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSADASNJA.ExtendedProperties.Add("Description", "Sadašnja");
                this.columnSADASNJA.ExtendedProperties.Add("Length", "12");
                this.columnSADASNJA.ExtendedProperties.Add("Decimals", "2");
                this.columnSADASNJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSADASNJA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSADASNJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSADASNJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSADASNJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSADASNJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSADASNJA.ExtendedProperties.Add("Deklarit.InternalName", "SADASNJA");
                this.Columns.Add(this.columnSADASNJA);
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
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OS_BILANCA_STANJA_NA_DAN");
                this.ExtendedProperties.Add("Description", "S_OS_BILANCA_STANJA_NA_DAN");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnNAZIVOS = this.Columns["NAZIVOS"];
                this.columnINVBROJ = this.Columns["INVBROJ"];
                this.columnKOLICINA = this.Columns["KOLICINA"];
                this.columnNABAVNA = this.Columns["NABAVNA"];
                this.columnISPRAVAK = this.Columns["ISPRAVAK"];
                this.columnSADASNJA = this.Columns["SADASNJA"];
                this.columnKTOISPRAVKAIDKONTO = this.Columns["KTOISPRAVKAIDKONTO"];
                this.columnKTONABAVKEIDKONTO = this.Columns["KTONABAVKEIDKONTO"];
                this.columnKTOIZVORAIDKONTO = this.Columns["KTOIZVORAIDKONTO"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow(builder);
            }

            public S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow NewS_OS_BILANCA_STANJA_NA_DANRow()
            {
                return (S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OS_BILANCA_STANJA_NA_DANRowChanged != null)
                {
                    S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRowChangeEventHandler handler = this.S_OS_BILANCA_STANJA_NA_DANRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRowChangeEvent((S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OS_BILANCA_STANJA_NA_DANRowChanging != null)
                {
                    S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRowChangeEventHandler handler = this.S_OS_BILANCA_STANJA_NA_DANRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRowChangeEvent((S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OS_BILANCA_STANJA_NA_DANRowDeleted != null)
                {
                    S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRowChangeEventHandler handler = this.S_OS_BILANCA_STANJA_NA_DANRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRowChangeEvent((S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OS_BILANCA_STANJA_NA_DANRowDeleting != null)
                {
                    S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRowChangeEventHandler handler = this.S_OS_BILANCA_STANJA_NA_DANRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRowChangeEvent((S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OS_BILANCA_STANJA_NA_DANRow(S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow row)
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

            public DataColumn INVBROJColumn
            {
                get
                {
                    return this.columnINVBROJ;
                }
            }

            public DataColumn ISPRAVAKColumn
            {
                get
                {
                    return this.columnISPRAVAK;
                }
            }

            public S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow this[int index]
            {
                get
                {
                    return (S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow) this.Rows[index];
                }
            }

            public DataColumn KOLICINAColumn
            {
                get
                {
                    return this.columnKOLICINA;
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

            public DataColumn NABAVNAColumn
            {
                get
                {
                    return this.columnNABAVNA;
                }
            }

            public DataColumn NAZIVOSColumn
            {
                get
                {
                    return this.columnNAZIVOS;
                }
            }

            public DataColumn SADASNJAColumn
            {
                get
                {
                    return this.columnSADASNJA;
                }
            }
        }

        public class S_OS_BILANCA_STANJA_NA_DANRow : DataRow
        {
            private S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANDataTable tableS_OS_BILANCA_STANJA_NA_DAN;

            internal S_OS_BILANCA_STANJA_NA_DANRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OS_BILANCA_STANJA_NA_DAN = (S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANDataTable) this.Table;
            }

            public bool IsINVBROJNull()
            {
                return this.IsNull(this.tableS_OS_BILANCA_STANJA_NA_DAN.INVBROJColumn);
            }

            public bool IsISPRAVAKNull()
            {
                return this.IsNull(this.tableS_OS_BILANCA_STANJA_NA_DAN.ISPRAVAKColumn);
            }

            public bool IsKOLICINANull()
            {
                return this.IsNull(this.tableS_OS_BILANCA_STANJA_NA_DAN.KOLICINAColumn);
            }

            public bool IsKTOISPRAVKAIDKONTONull()
            {
                return this.IsNull(this.tableS_OS_BILANCA_STANJA_NA_DAN.KTOISPRAVKAIDKONTOColumn);
            }

            public bool IsKTOIZVORAIDKONTONull()
            {
                return this.IsNull(this.tableS_OS_BILANCA_STANJA_NA_DAN.KTOIZVORAIDKONTOColumn);
            }

            public bool IsKTONABAVKEIDKONTONull()
            {
                return this.IsNull(this.tableS_OS_BILANCA_STANJA_NA_DAN.KTONABAVKEIDKONTOColumn);
            }

            public bool IsNABAVNANull()
            {
                return this.IsNull(this.tableS_OS_BILANCA_STANJA_NA_DAN.NABAVNAColumn);
            }

            public bool IsNAZIVOSNull()
            {
                return this.IsNull(this.tableS_OS_BILANCA_STANJA_NA_DAN.NAZIVOSColumn);
            }

            public bool IsSADASNJANull()
            {
                return this.IsNull(this.tableS_OS_BILANCA_STANJA_NA_DAN.SADASNJAColumn);
            }

            public void SetINVBROJNull()
            {
                this[this.tableS_OS_BILANCA_STANJA_NA_DAN.INVBROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetISPRAVAKNull()
            {
                this[this.tableS_OS_BILANCA_STANJA_NA_DAN.ISPRAVAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOLICINANull()
            {
                this[this.tableS_OS_BILANCA_STANJA_NA_DAN.KOLICINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTOISPRAVKAIDKONTONull()
            {
                this[this.tableS_OS_BILANCA_STANJA_NA_DAN.KTOISPRAVKAIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTOIZVORAIDKONTONull()
            {
                this[this.tableS_OS_BILANCA_STANJA_NA_DAN.KTOIZVORAIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKTONABAVKEIDKONTONull()
            {
                this[this.tableS_OS_BILANCA_STANJA_NA_DAN.KTONABAVKEIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNABAVNANull()
            {
                this[this.tableS_OS_BILANCA_STANJA_NA_DAN.NABAVNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOSNull()
            {
                this[this.tableS_OS_BILANCA_STANJA_NA_DAN.NAZIVOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSADASNJANull()
            {
                this[this.tableS_OS_BILANCA_STANJA_NA_DAN.SADASNJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public long INVBROJ
            {
                get
                {
                    long num;
                    try
                    {
                        num = Conversions.ToLong(this[this.tableS_OS_BILANCA_STANJA_NA_DAN.INVBROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value INVBROJ because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_BILANCA_STANJA_NA_DAN.INVBROJColumn] = value;
                }
            }

            public decimal ISPRAVAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_BILANCA_STANJA_NA_DAN.ISPRAVAKColumn]);
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
                    this[this.tableS_OS_BILANCA_STANJA_NA_DAN.ISPRAVAKColumn] = value;
                }
            }

            public decimal KOLICINA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_BILANCA_STANJA_NA_DAN.KOLICINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value KOLICINA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_BILANCA_STANJA_NA_DAN.KOLICINAColumn] = value;
                }
            }

            public string KTOISPRAVKAIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_BILANCA_STANJA_NA_DAN.KTOISPRAVKAIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OS_BILANCA_STANJA_NA_DAN.KTOISPRAVKAIDKONTOColumn] = value;
                }
            }

            public string KTOIZVORAIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_BILANCA_STANJA_NA_DAN.KTOIZVORAIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OS_BILANCA_STANJA_NA_DAN.KTOIZVORAIDKONTOColumn] = value;
                }
            }

            public string KTONABAVKEIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_BILANCA_STANJA_NA_DAN.KTONABAVKEIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OS_BILANCA_STANJA_NA_DAN.KTONABAVKEIDKONTOColumn] = value;
                }
            }

            public decimal NABAVNA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_BILANCA_STANJA_NA_DAN.NABAVNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_BILANCA_STANJA_NA_DAN.NABAVNAColumn] = value;
                }
            }

            public string NAZIVOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_BILANCA_STANJA_NA_DAN.NAZIVOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OS_BILANCA_STANJA_NA_DAN.NAZIVOSColumn] = value;
                }
            }

            public decimal SADASNJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OS_BILANCA_STANJA_NA_DAN.SADASNJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_BILANCA_STANJA_NA_DAN.SADASNJAColumn] = value;
                }
            }
        }

        public class S_OS_BILANCA_STANJA_NA_DANRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow eventRow;

            public S_OS_BILANCA_STANJA_NA_DANRowChangeEvent(S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow row, DataRowAction action)
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

            public S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OS_BILANCA_STANJA_NA_DANRowChangeEventHandler(object sender, S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRowChangeEvent e);
    }
}

