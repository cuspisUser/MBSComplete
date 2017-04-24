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
    public class sp_diskete_za_bankuDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private sp_diskete_za_bankuDataTable tablesp_diskete_za_banku;

        public sp_diskete_za_bankuDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected sp_diskete_za_bankuDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["sp_diskete_za_banku"] != null)
                    {
                        this.Tables.Add(new sp_diskete_za_bankuDataTable(dataSet.Tables["sp_diskete_za_banku"]));
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
            sp_diskete_za_bankuDataSet set = (sp_diskete_za_bankuDataSet) base.Clone();
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
            sp_diskete_za_bankuDataSet set = new sp_diskete_za_bankuDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "sp_diskete_za_bankuDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2025");
            this.ExtendedProperties.Add("DataSetName", "sp_diskete_za_bankuDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Isp_diskete_za_bankuDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "sp_diskete_za_banku");
            this.ExtendedProperties.Add("ObjectDescription", "sp_diskete_za_banku");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_ISPLATE_ZA_BANKU");
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
            this.DataSetName = "sp_diskete_za_bankuDataSet";
            this.Namespace = "http://www.tempuri.org/sp_diskete_za_banku";
            this.tablesp_diskete_za_banku = new sp_diskete_za_bankuDataTable();
            this.Tables.Add(this.tablesp_diskete_za_banku);
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
            this.tablesp_diskete_za_banku = (sp_diskete_za_bankuDataTable) this.Tables["sp_diskete_za_banku"];
            if (initTable && (this.tablesp_diskete_za_banku != null))
            {
                this.tablesp_diskete_za_banku.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["sp_diskete_za_banku"] != null)
                {
                    this.Tables.Add(new sp_diskete_za_bankuDataTable(dataSet.Tables["sp_diskete_za_banku"]));
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

        private bool ShouldSerializesp_diskete_za_banku()
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
        public sp_diskete_za_bankuDataTable sp_diskete_za_banku
        {
            get
            {
                return this.tablesp_diskete_za_banku;
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
        public class sp_diskete_za_bankuDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnJMBG;
            private DataColumn columnNAZIVBANKE1;
            private DataColumn columnOPISPLACANJANETO;
            private DataColumn columnPREZIME;
            private DataColumn columnSIFRAOPISAPLACANJANETO;
            private DataColumn columnTEKUCI;
            private DataColumn columnUKUPNOZAISPLATU;
            private DataColumn columnVBDIBANKE;
            private DataColumn columnZRNBANKE;

            public event sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRowChangeEventHandler sp_diskete_za_bankuRowChanged;

            public event sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRowChangeEventHandler sp_diskete_za_bankuRowChanging;

            public event sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRowChangeEventHandler sp_diskete_za_bankuRowDeleted;

            public event sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRowChangeEventHandler sp_diskete_za_bankuRowDeleting;

            public sp_diskete_za_bankuDataTable()
            {
                this.TableName = "sp_diskete_za_banku";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal sp_diskete_za_bankuDataTable(DataTable table) : base(table.TableName)
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

            protected sp_diskete_za_bankuDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void Addsp_diskete_za_bankuRow(sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow row)
            {
                this.Rows.Add(row);
            }

            public sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow Addsp_diskete_za_bankuRow(int iDRADNIK, string pREZIME, string iME, string jMBG, string tEKUCI, string sIFRAOPISAPLACANJANETO, string oPISPLACANJANETO, string vBDIBANKE, string zRNBANKE, decimal uKUPNOZAISPLATU, string nAZIVBANKE1)
            {
                sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow row = (sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow) this.NewRow();
                row.ItemArray = new object[] { iDRADNIK, pREZIME, iME, jMBG, tEKUCI, sIFRAOPISAPLACANJANETO, oPISPLACANJANETO, vBDIBANKE, zRNBANKE, uKUPNOZAISPLATU, nAZIVBANKE1 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                sp_diskete_za_bankuDataSet.sp_diskete_za_bankuDataTable table = (sp_diskete_za_bankuDataSet.sp_diskete_za_bankuDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                sp_diskete_za_bankuDataSet set = new sp_diskete_za_bankuDataSet();
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
                this.columnJMBG = new DataColumn("JMBG", typeof(string), "", MappingType.Element);
                this.columnJMBG.Caption = "JMBG";
                this.columnJMBG.MaxLength = 13;
                this.columnJMBG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnJMBG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnJMBG.ExtendedProperties.Add("IsKey", "false");
                this.columnJMBG.ExtendedProperties.Add("ReadOnly", "true");
                this.columnJMBG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnJMBG.ExtendedProperties.Add("Description", "JMBG");
                this.columnJMBG.ExtendedProperties.Add("Length", "13");
                this.columnJMBG.ExtendedProperties.Add("Decimals", "0");
                this.columnJMBG.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnJMBG.ExtendedProperties.Add("IsInReader", "true");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.InternalName", "JMBG");
                this.Columns.Add(this.columnJMBG);
                this.columnTEKUCI = new DataColumn("TEKUCI", typeof(string), "", MappingType.Element);
                this.columnTEKUCI.Caption = "Tekući račun";
                this.columnTEKUCI.MaxLength = 10;
                this.columnTEKUCI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnTEKUCI.ExtendedProperties.Add("IsKey", "false");
                this.columnTEKUCI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnTEKUCI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnTEKUCI.ExtendedProperties.Add("Description", "Tekući račun");
                this.columnTEKUCI.ExtendedProperties.Add("Length", "10");
                this.columnTEKUCI.ExtendedProperties.Add("Decimals", "0");
                this.columnTEKUCI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnTEKUCI.ExtendedProperties.Add("IsInReader", "true");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.InternalName", "TEKUCI");
                this.Columns.Add(this.columnTEKUCI);
                this.columnSIFRAOPISAPLACANJANETO = new DataColumn("SIFRAOPISAPLACANJANETO", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJANETO.Caption = "Šifra opisa plaćanja (iznos za isplatu)";
                this.columnSIFRAOPISAPLACANJANETO.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJANETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Description", "Šifra opisa plaćanja (iznos za isplatu)");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJANETO");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJANETO);
                this.columnOPISPLACANJANETO = new DataColumn("OPISPLACANJANETO", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJANETO.Caption = "Opis plaćanja (iznos za isplatu)";
                this.columnOPISPLACANJANETO.MaxLength = 0x24;
                this.columnOPISPLACANJANETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Description", "Opis plaćanja (iznos za isplatu)");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJANETO");
                this.Columns.Add(this.columnOPISPLACANJANETO);
                this.columnVBDIBANKE = new DataColumn("VBDIBANKE", typeof(string), "", MappingType.Element);
                this.columnVBDIBANKE.Caption = "VBDI žiro računa banke";
                this.columnVBDIBANKE.MaxLength = 7;
                this.columnVBDIBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIBANKE.ExtendedProperties.Add("Description", "VBDI žiro računa banke");
                this.columnVBDIBANKE.ExtendedProperties.Add("Length", "7");
                this.columnVBDIBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIBANKE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.InternalName", "VBDIBANKE");
                this.Columns.Add(this.columnVBDIBANKE);
                this.columnZRNBANKE = new DataColumn("ZRNBANKE", typeof(string), "", MappingType.Element);
                this.columnZRNBANKE.Caption = "Broj žiro računa banke";
                this.columnZRNBANKE.MaxLength = 10;
                this.columnZRNBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNBANKE.ExtendedProperties.Add("Description", "Broj žiro računa banke");
                this.columnZRNBANKE.ExtendedProperties.Add("Length", "10");
                this.columnZRNBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNBANKE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.InternalName", "ZRNBANKE");
                this.Columns.Add(this.columnZRNBANKE);
                this.columnUKUPNOZAISPLATU = new DataColumn("UKUPNOZAISPLATU", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOZAISPLATU.Caption = "UKUPNOZAISPLATU";
                this.columnUKUPNOZAISPLATU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("Description", "UKUPNOZAISPLATU");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOZAISPLATU.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOZAISPLATU");
                this.Columns.Add(this.columnUKUPNOZAISPLATU);
                this.columnNAZIVBANKE1 = new DataColumn("NAZIVBANKE1", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE1.Caption = "Naziv banke";
                this.columnNAZIVBANKE1.MaxLength = 20;
                this.columnNAZIVBANKE1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Description", "Naziv banke");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE1");
                this.Columns.Add(this.columnNAZIVBANKE1);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "sp_diskete_za_banku");
                this.ExtendedProperties.Add("Description", "_SP_DISKETE_ZA_BANKU");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnJMBG = this.Columns["JMBG"];
                this.columnTEKUCI = this.Columns["TEKUCI"];
                this.columnSIFRAOPISAPLACANJANETO = this.Columns["SIFRAOPISAPLACANJANETO"];
                this.columnOPISPLACANJANETO = this.Columns["OPISPLACANJANETO"];
                this.columnVBDIBANKE = this.Columns["VBDIBANKE"];
                this.columnZRNBANKE = this.Columns["ZRNBANKE"];
                this.columnUKUPNOZAISPLATU = this.Columns["UKUPNOZAISPLATU"];
                this.columnNAZIVBANKE1 = this.Columns["NAZIVBANKE1"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow(builder);
            }

            public sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow Newsp_diskete_za_bankuRow()
            {
                return (sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.sp_diskete_za_bankuRowChanged != null)
                {
                    sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRowChangeEventHandler handler = this.sp_diskete_za_bankuRowChanged;
                    if (handler != null)
                    {
                        handler(this, new sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRowChangeEvent((sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.sp_diskete_za_bankuRowChanging != null)
                {
                    sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRowChangeEventHandler handler = this.sp_diskete_za_bankuRowChanging;
                    if (handler != null)
                    {
                        handler(this, new sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRowChangeEvent((sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.sp_diskete_za_bankuRowDeleted != null)
                {
                    sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRowChangeEventHandler handler = this.sp_diskete_za_bankuRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRowChangeEvent((sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.sp_diskete_za_bankuRowDeleting != null)
                {
                    sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRowChangeEventHandler handler = this.sp_diskete_za_bankuRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRowChangeEvent((sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow) e.Row, e.Action));
                    }
                }
            }

            public void Removesp_diskete_za_bankuRow(sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow row)
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

            public sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow this[int index]
            {
                get
                {
                    return (sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow) this.Rows[index];
                }
            }

            public DataColumn JMBGColumn
            {
                get
                {
                    return this.columnJMBG;
                }
            }

            public DataColumn NAZIVBANKE1Column
            {
                get
                {
                    return this.columnNAZIVBANKE1;
                }
            }

            public DataColumn OPISPLACANJANETOColumn
            {
                get
                {
                    return this.columnOPISPLACANJANETO;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn SIFRAOPISAPLACANJANETOColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJANETO;
                }
            }

            public DataColumn TEKUCIColumn
            {
                get
                {
                    return this.columnTEKUCI;
                }
            }

            public DataColumn UKUPNOZAISPLATUColumn
            {
                get
                {
                    return this.columnUKUPNOZAISPLATU;
                }
            }

            public DataColumn VBDIBANKEColumn
            {
                get
                {
                    return this.columnVBDIBANKE;
                }
            }

            public DataColumn ZRNBANKEColumn
            {
                get
                {
                    return this.columnZRNBANKE;
                }
            }
        }

        public class sp_diskete_za_bankuRow : DataRow
        {
            private sp_diskete_za_bankuDataSet.sp_diskete_za_bankuDataTable tablesp_diskete_za_banku;

            internal sp_diskete_za_bankuRow(DataRowBuilder rb) : base(rb)
            {
                this.tablesp_diskete_za_banku = (sp_diskete_za_bankuDataSet.sp_diskete_za_bankuDataTable) this.Table;
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tablesp_diskete_za_banku.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tablesp_diskete_za_banku.IMEColumn);
            }

            public bool IsJMBGNull()
            {
                return this.IsNull(this.tablesp_diskete_za_banku.JMBGColumn);
            }

            public bool IsNAZIVBANKE1Null()
            {
                return this.IsNull(this.tablesp_diskete_za_banku.NAZIVBANKE1Column);
            }

            public bool IsOPISPLACANJANETONull()
            {
                return this.IsNull(this.tablesp_diskete_za_banku.OPISPLACANJANETOColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tablesp_diskete_za_banku.PREZIMEColumn);
            }

            public bool IsSIFRAOPISAPLACANJANETONull()
            {
                return this.IsNull(this.tablesp_diskete_za_banku.SIFRAOPISAPLACANJANETOColumn);
            }

            public bool IsTEKUCINull()
            {
                return this.IsNull(this.tablesp_diskete_za_banku.TEKUCIColumn);
            }

            public bool IsUKUPNOZAISPLATUNull()
            {
                return this.IsNull(this.tablesp_diskete_za_banku.UKUPNOZAISPLATUColumn);
            }

            public bool IsVBDIBANKENull()
            {
                return this.IsNull(this.tablesp_diskete_za_banku.VBDIBANKEColumn);
            }

            public bool IsZRNBANKENull()
            {
                return this.IsNull(this.tablesp_diskete_za_banku.ZRNBANKEColumn);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tablesp_diskete_za_banku.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tablesp_diskete_za_banku.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGNull()
            {
                this[this.tablesp_diskete_za_banku.JMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE1Null()
            {
                this[this.tablesp_diskete_za_banku.NAZIVBANKE1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJANETONull()
            {
                this[this.tablesp_diskete_za_banku.OPISPLACANJANETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tablesp_diskete_za_banku.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJANETONull()
            {
                this[this.tablesp_diskete_za_banku.SIFRAOPISAPLACANJANETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTEKUCINull()
            {
                this[this.tablesp_diskete_za_banku.TEKUCIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOZAISPLATUNull()
            {
                this[this.tablesp_diskete_za_banku.UKUPNOZAISPLATUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIBANKENull()
            {
                this[this.tablesp_diskete_za_banku.VBDIBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNBANKENull()
            {
                this[this.tablesp_diskete_za_banku.ZRNBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablesp_diskete_za_banku.IDRADNIKColumn]);
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
                    this[this.tablesp_diskete_za_banku.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_diskete_za_banku.IMEColumn]);
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
                    this[this.tablesp_diskete_za_banku.IMEColumn] = value;
                }
            }

            public string JMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_diskete_za_banku.JMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_diskete_za_banku.JMBGColumn] = value;
                }
            }

            public string NAZIVBANKE1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_diskete_za_banku.NAZIVBANKE1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_diskete_za_banku.NAZIVBANKE1Column] = value;
                }
            }

            public string OPISPLACANJANETO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_diskete_za_banku.OPISPLACANJANETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_diskete_za_banku.OPISPLACANJANETOColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_diskete_za_banku.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_diskete_za_banku.PREZIMEColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJANETO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_diskete_za_banku.SIFRAOPISAPLACANJANETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_diskete_za_banku.SIFRAOPISAPLACANJANETOColumn] = value;
                }
            }

            public string TEKUCI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_diskete_za_banku.TEKUCIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_diskete_za_banku.TEKUCIColumn] = value;
                }
            }

            public decimal UKUPNOZAISPLATU
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_diskete_za_banku.UKUPNOZAISPLATUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_diskete_za_banku.UKUPNOZAISPLATUColumn] = value;
                }
            }

            public string VBDIBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_diskete_za_banku.VBDIBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_diskete_za_banku.VBDIBANKEColumn] = value;
                }
            }

            public string ZRNBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_diskete_za_banku.ZRNBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_diskete_za_banku.ZRNBANKEColumn] = value;
                }
            }
        }

        public class sp_diskete_za_bankuRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow eventRow;

            public sp_diskete_za_bankuRowChangeEvent(sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow row, DataRowAction action)
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

            public sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void sp_diskete_za_bankuRowChangeEventHandler(object sender, sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRowChangeEvent e);
    }
}

