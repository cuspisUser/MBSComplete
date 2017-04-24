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
    public class S_OD_REKAP_POREZDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_REKAP_POREZDataTable tableS_OD_REKAP_POREZ;

        public S_OD_REKAP_POREZDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_REKAP_POREZDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_REKAP_POREZ"] != null)
                    {
                        this.Tables.Add(new S_OD_REKAP_POREZDataTable(dataSet.Tables["S_OD_REKAP_POREZ"]));
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
            S_OD_REKAP_POREZDataSet set = (S_OD_REKAP_POREZDataSet) base.Clone();
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
            S_OD_REKAP_POREZDataSet set = new S_OD_REKAP_POREZDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_REKAP_POREZDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2052");
            this.ExtendedProperties.Add("DataSetName", "S_OD_REKAP_POREZDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_REKAP_POREZDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_REKAP_POREZ");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_REKAP_POREZ");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_POREZ");
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
            this.DataSetName = "S_OD_REKAP_POREZDataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_REKAP_POREZ";
            this.tableS_OD_REKAP_POREZ = new S_OD_REKAP_POREZDataTable();
            this.Tables.Add(this.tableS_OD_REKAP_POREZ);
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
            this.tableS_OD_REKAP_POREZ = (S_OD_REKAP_POREZDataTable) this.Tables["S_OD_REKAP_POREZ"];
            if (initTable && (this.tableS_OD_REKAP_POREZ != null))
            {
                this.tableS_OD_REKAP_POREZ.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_REKAP_POREZ"] != null)
                {
                    this.Tables.Add(new S_OD_REKAP_POREZDataTable(dataSet.Tables["S_OD_REKAP_POREZ"]));
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

        private bool ShouldSerializeS_OD_REKAP_POREZ()
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
        public S_OD_REKAP_POREZDataTable S_OD_REKAP_POREZ
        {
            get
            {
                return this.tableS_OD_REKAP_POREZ;
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
        public class S_OD_REKAP_POREZDataTable : DataTable, IEnumerable
        {
            private DataColumn columnNAZIVOPCINE;
            private DataColumn columnOBRACUNATO;
            private DataColumn columnOSNOVICa;
            private DataColumn columnPOREZOPIS;
            private DataColumn columnSIFRA;
            private DataColumn columnSIFRAOPCINESTANOVANJA;
            private DataColumn columnSTOPA;

            public event S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRowChangeEventHandler S_OD_REKAP_POREZRowChanged;

            public event S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRowChangeEventHandler S_OD_REKAP_POREZRowChanging;

            public event S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRowChangeEventHandler S_OD_REKAP_POREZRowDeleted;

            public event S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRowChangeEventHandler S_OD_REKAP_POREZRowDeleting;

            public S_OD_REKAP_POREZDataTable()
            {
                this.TableName = "S_OD_REKAP_POREZ";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_REKAP_POREZDataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_REKAP_POREZDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_REKAP_POREZRow(S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow AddS_OD_REKAP_POREZRow(int sIFRA, string sIFRAOPCINESTANOVANJA, string nAZIVOPCINE, decimal oBRACUNATO, decimal sTOPA, decimal oSNOVICa, string pOREZOPIS)
            {
                S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow row = (S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow) this.NewRow();
                row.ItemArray = new object[] { sIFRA, sIFRAOPCINESTANOVANJA, nAZIVOPCINE, oBRACUNATO, sTOPA, oSNOVICa, pOREZOPIS };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZDataTable table = (S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_REKAP_POREZDataSet set = new S_OD_REKAP_POREZDataSet();
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
                this.columnSIFRA = new DataColumn("SIFRA", typeof(int), "", MappingType.Element);
                this.columnSIFRA.Caption = "SIFRA";
                this.columnSIFRA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSIFRA.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSIFRA.ExtendedProperties.Add("Description", "SIFRA");
                this.columnSIFRA.ExtendedProperties.Add("Length", "5");
                this.columnSIFRA.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRA.ExtendedProperties.Add("Deklarit.InternalName", "SIFRA");
                this.Columns.Add(this.columnSIFRA);
                this.columnSIFRAOPCINESTANOVANJA = new DataColumn("SIFRAOPCINESTANOVANJA", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPCINESTANOVANJA.Caption = "Šifra općine";
                this.columnSIFRAOPCINESTANOVANJA.MaxLength = 4;
                this.columnSIFRAOPCINESTANOVANJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Description", "Šifra općine");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Length", "4");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPCINESTANOVANJA");
                this.Columns.Add(this.columnSIFRAOPCINESTANOVANJA);
                this.columnNAZIVOPCINE = new DataColumn("NAZIVOPCINE", typeof(string), "", MappingType.Element);
                this.columnNAZIVOPCINE.Caption = "Naziv općine";
                this.columnNAZIVOPCINE.MaxLength = 50;
                this.columnNAZIVOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Description", "Naziv općine");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOPCINE");
                this.Columns.Add(this.columnNAZIVOPCINE);
                this.columnOBRACUNATO = new DataColumn("OBRACUNATO", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNATO.Caption = "Obračunato";
                this.columnOBRACUNATO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOBRACUNATO.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNATO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBRACUNATO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNATO.ExtendedProperties.Add("Description", "Obračunato");
                this.columnOBRACUNATO.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNATO.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNATO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNATO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNATO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRACUNATO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNATO");
                this.Columns.Add(this.columnOBRACUNATO);
                this.columnSTOPA = new DataColumn("STOPA", typeof(decimal), "", MappingType.Element);
                this.columnSTOPA.Caption = "STOPA";
                this.columnSTOPA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPA.ExtendedProperties.Add("Description", "STOPA");
                this.columnSTOPA.ExtendedProperties.Add("Length", "5");
                this.columnSTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnSTOPA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.InternalName", "STOPA");
                this.Columns.Add(this.columnSTOPA);
                this.columnOSNOVICa = new DataColumn("OSNOVICa", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICa.Caption = "OSNOVICAMOZE";
                this.columnOSNOVICa.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICa.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICa.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICa.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICa.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICa.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICa.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICa.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICa.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICa.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICa.ExtendedProperties.Add("Description", "OSNOVICAMOZE");
                this.columnOSNOVICa.ExtendedProperties.Add("Length", "8");
                this.columnOSNOVICa.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICa.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICa.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICa.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICa.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICa.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICa");
                this.Columns.Add(this.columnOSNOVICa);
                this.columnPOREZOPIS = new DataColumn("POREZOPIS", typeof(string), "", MappingType.Element);
                this.columnPOREZOPIS.Caption = "POREZOPIS";
                this.columnPOREZOPIS.MaxLength = 50;
                this.columnPOREZOPIS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZOPIS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZOPIS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZOPIS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOREZOPIS.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZOPIS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZOPIS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOREZOPIS.ExtendedProperties.Add("Description", "POREZOPIS");
                this.columnPOREZOPIS.ExtendedProperties.Add("Length", "50");
                this.columnPOREZOPIS.ExtendedProperties.Add("Decimals", "0");
                this.columnPOREZOPIS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZOPIS.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZOPIS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZOPIS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZOPIS.ExtendedProperties.Add("Deklarit.InternalName", "POREZOPIS");
                this.Columns.Add(this.columnPOREZOPIS);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_REKAP_POREZ");
                this.ExtendedProperties.Add("Description", "S_OD_REKAP_POREZ");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnSIFRA = this.Columns["SIFRA"];
                this.columnSIFRAOPCINESTANOVANJA = this.Columns["SIFRAOPCINESTANOVANJA"];
                this.columnNAZIVOPCINE = this.Columns["NAZIVOPCINE"];
                this.columnOBRACUNATO = this.Columns["OBRACUNATO"];
                this.columnSTOPA = this.Columns["STOPA"];
                this.columnOSNOVICa = this.Columns["OSNOVICa"];
                this.columnPOREZOPIS = this.Columns["POREZOPIS"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow(builder);
            }

            public S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow NewS_OD_REKAP_POREZRow()
            {
                return (S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_REKAP_POREZRowChanged != null)
                {
                    S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRowChangeEventHandler handler = this.S_OD_REKAP_POREZRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRowChangeEvent((S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_REKAP_POREZRowChanging != null)
                {
                    S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRowChangeEventHandler handler = this.S_OD_REKAP_POREZRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRowChangeEvent((S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_REKAP_POREZRowDeleted != null)
                {
                    S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRowChangeEventHandler handler = this.S_OD_REKAP_POREZRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRowChangeEvent((S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_REKAP_POREZRowDeleting != null)
                {
                    S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRowChangeEventHandler handler = this.S_OD_REKAP_POREZRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRowChangeEvent((S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_REKAP_POREZRow(S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow row)
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

            public S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow this[int index]
            {
                get
                {
                    return (S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVOPCINEColumn
            {
                get
                {
                    return this.columnNAZIVOPCINE;
                }
            }

            public DataColumn OBRACUNATOColumn
            {
                get
                {
                    return this.columnOBRACUNATO;
                }
            }

            public DataColumn OSNOVICaColumn
            {
                get
                {
                    return this.columnOSNOVICa;
                }
            }

            public DataColumn POREZOPISColumn
            {
                get
                {
                    return this.columnPOREZOPIS;
                }
            }

            public DataColumn SIFRAColumn
            {
                get
                {
                    return this.columnSIFRA;
                }
            }

            public DataColumn SIFRAOPCINESTANOVANJAColumn
            {
                get
                {
                    return this.columnSIFRAOPCINESTANOVANJA;
                }
            }

            public DataColumn STOPAColumn
            {
                get
                {
                    return this.columnSTOPA;
                }
            }
        }

        public class S_OD_REKAP_POREZRow : DataRow
        {
            private S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZDataTable tableS_OD_REKAP_POREZ;

            internal S_OD_REKAP_POREZRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_REKAP_POREZ = (S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZDataTable) this.Table;
            }

            public bool IsNAZIVOPCINENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POREZ.NAZIVOPCINEColumn);
            }

            public bool IsOBRACUNATONull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POREZ.OBRACUNATOColumn);
            }

            public bool IsOSNOVICaNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POREZ.OSNOVICaColumn);
            }

            public bool IsPOREZOPISNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POREZ.POREZOPISColumn);
            }

            public bool IsSIFRANull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POREZ.SIFRAColumn);
            }

            public bool IsSIFRAOPCINESTANOVANJANull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POREZ.SIFRAOPCINESTANOVANJAColumn);
            }

            public bool IsSTOPANull()
            {
                return this.IsNull(this.tableS_OD_REKAP_POREZ.STOPAColumn);
            }

            public void SetNAZIVOPCINENull()
            {
                this[this.tableS_OD_REKAP_POREZ.NAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATONull()
            {
                this[this.tableS_OD_REKAP_POREZ.OBRACUNATOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICaNull()
            {
                this[this.tableS_OD_REKAP_POREZ.OSNOVICaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZOPISNull()
            {
                this[this.tableS_OD_REKAP_POREZ.POREZOPISColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRANull()
            {
                this[this.tableS_OD_REKAP_POREZ.SIFRAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPCINESTANOVANJANull()
            {
                this[this.tableS_OD_REKAP_POREZ.SIFRAOPCINESTANOVANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPANull()
            {
                this[this.tableS_OD_REKAP_POREZ.STOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string NAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_POREZ.NAZIVOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVOPCINE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POREZ.NAZIVOPCINEColumn] = value;
                }
            }

            public decimal OBRACUNATO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_REKAP_POREZ.OBRACUNATOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OBRACUNATO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POREZ.OBRACUNATOColumn] = value;
                }
            }

            public decimal OSNOVICa
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_REKAP_POREZ.OSNOVICaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OSNOVICa because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POREZ.OSNOVICaColumn] = value;
                }
            }

            public string POREZOPIS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_POREZ.POREZOPISColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value POREZOPIS because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POREZ.POREZOPISColumn] = value;
                }
            }

            public int SIFRA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_REKAP_POREZ.SIFRAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SIFRA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POREZ.SIFRAColumn] = value;
                }
            }

            public string SIFRAOPCINESTANOVANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_POREZ.SIFRAOPCINESTANOVANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SIFRAOPCINESTANOVANJA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POREZ.SIFRAOPCINESTANOVANJAColumn] = value;
                }
            }

            public decimal STOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_REKAP_POREZ.STOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value STOPA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_POREZ.STOPAColumn] = value;
                }
            }
        }

        public class S_OD_REKAP_POREZRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow eventRow;

            public S_OD_REKAP_POREZRowChangeEvent(S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow row, DataRowAction action)
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

            public S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_REKAP_POREZRowChangeEventHandler(object sender, S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRowChangeEvent e);
    }
}

