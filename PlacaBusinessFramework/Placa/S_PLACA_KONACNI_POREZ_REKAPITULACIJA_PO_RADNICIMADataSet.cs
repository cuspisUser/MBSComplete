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
    public class S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA;

        public S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA"] != null)
                    {
                        this.Tables.Add(new S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable(dataSet.Tables["S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA"]));
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
            S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet set = (S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet) base.Clone();
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
            S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet set = new S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2143");
            this.ExtendedProperties.Add("DataSetName", "S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA");
            this.ExtendedProperties.Add("ObjectDescription", "S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA");
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
            this.DataSetName = "S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet";
            this.Namespace = "http://www.tempuri.org/S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA";
            this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA = new S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable();
            this.Tables.Add(this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA);
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
            this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA = (S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable) this.Tables["S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA"];
            if (initTable && (this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA != null))
            {
                this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA"] != null)
                {
                    this.Tables.Add(new S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable(dataSet.Tables["S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA"]));
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

        private bool ShouldSerializeS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA()
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
        public S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA
        {
            get
            {
                return this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA;
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
        public class S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnKOREKCIJAPOREZA;
            private DataColumn columnKOREKCIJAPRIREZ;
            private DataColumn columnNAZIVOPCINE;
            private DataColumn columnORIGINALPOREZ;
            private DataColumn columnORIGINALPRIREZ;
            private DataColumn columnPREZIME;
            private DataColumn columnSIFRAOPCINESTANOVANJA;

            public event S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEventHandler S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChanged;

            public event S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEventHandler S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChanging;

            public event S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEventHandler S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowDeleted;

            public event S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEventHandler S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowDeleting;

            public S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable()
            {
                this.TableName = "S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable(DataTable table) : base(table.TableName)
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

            protected S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow(S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow row)
            {
                this.Rows.Add(row);
            }

            public S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow AddS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow(string pREZIME, string iME, string sIFRAOPCINESTANOVANJA, string nAZIVOPCINE, decimal kOREKCIJAPOREZA, decimal kOREKCIJAPRIREZ, decimal oRIGINALPOREZ, decimal oRIGINALPRIREZ, int iDRADNIK)
            {
                S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow row = (S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow) this.NewRow();
                row.ItemArray = new object[] { pREZIME, iME, sIFRAOPCINESTANOVANJA, nAZIVOPCINE, kOREKCIJAPOREZA, kOREKCIJAPRIREZ, oRIGINALPOREZ, oRIGINALPRIREZ, iDRADNIK };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable table = (S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet set = new S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet();
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
                this.columnPREZIME = new DataColumn("PREZIME", typeof(string), "", MappingType.Element);
                this.columnPREZIME.Caption = "Prezime";
                this.columnPREZIME.MaxLength = 50;
                this.columnPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPREZIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "PREZIME");
                this.Columns.Add(this.columnPREZIME);
                this.columnIME = new DataColumn("IME", typeof(string), "", MappingType.Element);
                this.columnIME.Caption = "Ime";
                this.columnIME.MaxLength = 50;
                this.columnIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIME.ExtendedProperties.Add("IsKey", "false");
                this.columnIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIME.ExtendedProperties.Add("Description", "Ime");
                this.columnIME.ExtendedProperties.Add("Length", "50");
                this.columnIME.ExtendedProperties.Add("Decimals", "0");
                this.columnIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.InternalName", "IME");
                this.Columns.Add(this.columnIME);
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
                this.columnKOREKCIJAPOREZA = new DataColumn("KOREKCIJAPOREZA", typeof(decimal), "", MappingType.Element);
                this.columnKOREKCIJAPOREZA.Caption = "KOREKCIJAPOREZA";
                this.columnKOREKCIJAPOREZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("IsKey", "false");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("Description", "KOREKCIJAPOREZA");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("Length", "12");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("Decimals", "2");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOREKCIJAPOREZA.ExtendedProperties.Add("Deklarit.InternalName", "KOREKCIJAPOREZA");
                this.Columns.Add(this.columnKOREKCIJAPOREZA);
                this.columnKOREKCIJAPRIREZ = new DataColumn("KOREKCIJAPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnKOREKCIJAPRIREZ.Caption = "KOREKCIJAPRIREZ";
                this.columnKOREKCIJAPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("Description", "KOREKCIJAPRIREZ");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOREKCIJAPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "KOREKCIJAPRIREZ");
                this.Columns.Add(this.columnKOREKCIJAPRIREZ);
                this.columnORIGINALPOREZ = new DataColumn("ORIGINALPOREZ", typeof(decimal), "", MappingType.Element);
                this.columnORIGINALPOREZ.Caption = "ORIGINALPOREZ";
                this.columnORIGINALPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnORIGINALPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("Description", "ORIGINALPOREZ");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("Length", "12");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnORIGINALPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "ORIGINALPOREZ");
                this.Columns.Add(this.columnORIGINALPOREZ);
                this.columnORIGINALPRIREZ = new DataColumn("ORIGINALPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnORIGINALPRIREZ.Caption = "ORIGINALPRIREZ";
                this.columnORIGINALPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("Description", "ORIGINALPRIREZ");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnORIGINALPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "ORIGINALPRIREZ");
                this.Columns.Add(this.columnORIGINALPRIREZ);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA");
                this.ExtendedProperties.Add("Description", "_S_PLACA_KONACNI_POREZ_REKAPIT");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnSIFRAOPCINESTANOVANJA = this.Columns["SIFRAOPCINESTANOVANJA"];
                this.columnNAZIVOPCINE = this.Columns["NAZIVOPCINE"];
                this.columnKOREKCIJAPOREZA = this.Columns["KOREKCIJAPOREZA"];
                this.columnKOREKCIJAPRIREZ = this.Columns["KOREKCIJAPRIREZ"];
                this.columnORIGINALPOREZ = this.Columns["ORIGINALPOREZ"];
                this.columnORIGINALPRIREZ = this.Columns["ORIGINALPRIREZ"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow(builder);
            }

            public S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow NewS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow()
            {
                return (S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChanged != null)
                {
                    S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEventHandler handler = this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEvent((S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChanging != null)
                {
                    S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEventHandler handler = this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEvent((S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowDeleted != null)
                {
                    S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEventHandler handler = this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEvent((S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowDeleting != null)
                {
                    S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEventHandler handler = this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEvent((S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow(S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow row)
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

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public DataColumn IMEColumn
            {
                get
                {
                    return this.columnIME;
                }
            }

            public S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow this[int index]
            {
                get
                {
                    return (S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow) this.Rows[index];
                }
            }

            public DataColumn KOREKCIJAPOREZAColumn
            {
                get
                {
                    return this.columnKOREKCIJAPOREZA;
                }
            }

            public DataColumn KOREKCIJAPRIREZColumn
            {
                get
                {
                    return this.columnKOREKCIJAPRIREZ;
                }
            }

            public DataColumn NAZIVOPCINEColumn
            {
                get
                {
                    return this.columnNAZIVOPCINE;
                }
            }

            public DataColumn ORIGINALPOREZColumn
            {
                get
                {
                    return this.columnORIGINALPOREZ;
                }
            }

            public DataColumn ORIGINALPRIREZColumn
            {
                get
                {
                    return this.columnORIGINALPRIREZ;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn SIFRAOPCINESTANOVANJAColumn
            {
                get
                {
                    return this.columnSIFRAOPCINESTANOVANJA;
                }
            }
        }

        public class S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow : DataRow
        {
            private S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA;

            internal S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA = (S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataTable) this.Table;
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.IMEColumn);
            }

            public bool IsKOREKCIJAPOREZANull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.KOREKCIJAPOREZAColumn);
            }

            public bool IsKOREKCIJAPRIREZNull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.KOREKCIJAPRIREZColumn);
            }

            public bool IsNAZIVOPCINENull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.NAZIVOPCINEColumn);
            }

            public bool IsORIGINALPOREZNull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.ORIGINALPOREZColumn);
            }

            public bool IsORIGINALPRIREZNull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.ORIGINALPRIREZColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.PREZIMEColumn);
            }

            public bool IsSIFRAOPCINESTANOVANJANull()
            {
                return this.IsNull(this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.SIFRAOPCINESTANOVANJAColumn);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOREKCIJAPOREZANull()
            {
                this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.KOREKCIJAPOREZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOREKCIJAPRIREZNull()
            {
                this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.KOREKCIJAPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOPCINENull()
            {
                this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.NAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetORIGINALPOREZNull()
            {
                this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.ORIGINALPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetORIGINALPRIREZNull()
            {
                this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.ORIGINALPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPCINESTANOVANJANull()
            {
                this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.SIFRAOPCINESTANOVANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.IDRADNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDRADNIK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.IMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.IMEColumn] = value;
                }
            }

            public decimal KOREKCIJAPOREZA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.KOREKCIJAPOREZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value KOREKCIJAPOREZA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.KOREKCIJAPOREZAColumn] = value;
                }
            }

            public decimal KOREKCIJAPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.KOREKCIJAPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value KOREKCIJAPRIREZ because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.KOREKCIJAPRIREZColumn] = value;
                }
            }

            public string NAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.NAZIVOPCINEColumn]);
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
                    this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.NAZIVOPCINEColumn] = value;
                }
            }

            public decimal ORIGINALPOREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.ORIGINALPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.ORIGINALPOREZColumn] = value;
                }
            }

            public decimal ORIGINALPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.ORIGINALPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.ORIGINALPRIREZColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.PREZIMEColumn] = value;
                }
            }

            public string SIFRAOPCINESTANOVANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.SIFRAOPCINESTANOVANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.SIFRAOPCINESTANOVANJAColumn] = value;
                }
            }
        }

        public class S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow eventRow;

            public S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEvent(S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow row, DataRowAction action)
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

            public S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEventHandler(object sender, S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARowChangeEvent e);
    }
}

