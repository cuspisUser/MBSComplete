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
    public class S_OD_REKAP_NETODataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_REKAP_NETODataTable tableS_OD_REKAP_NETO;

        public S_OD_REKAP_NETODataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_REKAP_NETODataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_REKAP_NETO"] != null)
                    {
                        this.Tables.Add(new S_OD_REKAP_NETODataTable(dataSet.Tables["S_OD_REKAP_NETO"]));
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
            S_OD_REKAP_NETODataSet set = (S_OD_REKAP_NETODataSet) base.Clone();
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
            S_OD_REKAP_NETODataSet set = new S_OD_REKAP_NETODataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_REKAP_NETODataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2050");
            this.ExtendedProperties.Add("DataSetName", "S_OD_REKAP_NETODataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_REKAP_NETODataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_REKAP_NETO");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_REKAP_NETO");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_NETO");
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
            this.DataSetName = "S_OD_REKAP_NETODataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_REKAP_NETO";
            this.tableS_OD_REKAP_NETO = new S_OD_REKAP_NETODataTable();
            this.Tables.Add(this.tableS_OD_REKAP_NETO);
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
            this.tableS_OD_REKAP_NETO = (S_OD_REKAP_NETODataTable) this.Tables["S_OD_REKAP_NETO"];
            if (initTable && (this.tableS_OD_REKAP_NETO != null))
            {
                this.tableS_OD_REKAP_NETO.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_REKAP_NETO"] != null)
                {
                    this.Tables.Add(new S_OD_REKAP_NETODataTable(dataSet.Tables["S_OD_REKAP_NETO"]));
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

        private bool ShouldSerializeS_OD_REKAP_NETO()
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
        public S_OD_REKAP_NETODataTable S_OD_REKAP_NETO
        {
            get
            {
                return this.tableS_OD_REKAP_NETO;
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
        public class S_OD_REKAP_NETODataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRADNIK;
            private DataColumn columnIDVRSTAELEMENTA;
            private DataColumn columnIME;
            private DataColumn columnIZNOS;
            private DataColumn columnJMBG;
            private DataColumn columnNAZIVELEMENT;
            private DataColumn columnNAZIVVRSTAELEMENT;
            private DataColumn columnPREZIME;
            private DataColumn columnsati;

            public event S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORowChangeEventHandler S_OD_REKAP_NETORowChanged;

            public event S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORowChangeEventHandler S_OD_REKAP_NETORowChanging;

            public event S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORowChangeEventHandler S_OD_REKAP_NETORowDeleted;

            public event S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORowChangeEventHandler S_OD_REKAP_NETORowDeleting;

            public S_OD_REKAP_NETODataTable()
            {
                this.TableName = "S_OD_REKAP_NETO";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_REKAP_NETODataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_REKAP_NETODataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_REKAP_NETORow(S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow AddS_OD_REKAP_NETORow(decimal sati, decimal iZNOS, string pREZIME, string iME, string jMBG, int iDRADNIK, short iDVRSTAELEMENTA, string nAZIVELEMENT, string nAZIVVRSTAELEMENT)
            {
                S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow row = (S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow) this.NewRow();
                row.ItemArray = new object[] { sati, iZNOS, pREZIME, iME, jMBG, iDRADNIK, iDVRSTAELEMENTA, nAZIVELEMENT, nAZIVVRSTAELEMENT };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_REKAP_NETODataSet.S_OD_REKAP_NETODataTable table = (S_OD_REKAP_NETODataSet.S_OD_REKAP_NETODataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_REKAP_NETODataSet set = new S_OD_REKAP_NETODataSet();
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
                this.columnsati = new DataColumn("sati", typeof(decimal), "", MappingType.Element);
                this.columnsati.Caption = "sati";
                this.columnsati.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsati.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsati.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsati.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsati.ExtendedProperties.Add("IsKey", "false");
                this.columnsati.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsati.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsati.ExtendedProperties.Add("Description", "sati");
                this.columnsati.ExtendedProperties.Add("Length", "12");
                this.columnsati.ExtendedProperties.Add("Decimals", "2");
                this.columnsati.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsati.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsati.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsati.ExtendedProperties.Add("IsInReader", "true");
                this.columnsati.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsati.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsati.ExtendedProperties.Add("Deklarit.InternalName", "sati");
                this.Columns.Add(this.columnsati);
                this.columnIZNOS = new DataColumn("IZNOS", typeof(decimal), "", MappingType.Element);
                this.columnIZNOS.Caption = "IZNOS";
                this.columnIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOS.ExtendedProperties.Add("Description", "IZNOS");
                this.columnIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "IZNOS");
                this.Columns.Add(this.columnIZNOS);
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
                this.columnIDVRSTAELEMENTA = new DataColumn("IDVRSTAELEMENTA", typeof(short), "", MappingType.Element);
                this.columnIDVRSTAELEMENTA.Caption = "Šifra Vrste elementa";
                this.columnIDVRSTAELEMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Description", "Šifra Vrste elementa");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Length", "4");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.InternalName", "IDVRSTAELEMENTA");
                this.Columns.Add(this.columnIDVRSTAELEMENTA);
                this.columnNAZIVELEMENT = new DataColumn("NAZIVELEMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVELEMENT.Caption = "Naziv elementa";
                this.columnNAZIVELEMENT.MaxLength = 50;
                this.columnNAZIVELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Description", "Naziv elementa");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVELEMENT");
                this.Columns.Add(this.columnNAZIVELEMENT);
                this.columnNAZIVVRSTAELEMENT = new DataColumn("NAZIVVRSTAELEMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTAELEMENT.Caption = "Naziv vrste elementa";
                this.columnNAZIVVRSTAELEMENT.MaxLength = 0x19;
                this.columnNAZIVVRSTAELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Description", "Naziv vrste elementa");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Length", "25");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTAELEMENT");
                this.Columns.Add(this.columnNAZIVVRSTAELEMENT);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_REKAP_NETO");
                this.ExtendedProperties.Add("Description", "_S_OD_REKAP_NETO");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnsati = this.Columns["sati"];
                this.columnIZNOS = this.Columns["IZNOS"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnJMBG = this.Columns["JMBG"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnIDVRSTAELEMENTA = this.Columns["IDVRSTAELEMENTA"];
                this.columnNAZIVELEMENT = this.Columns["NAZIVELEMENT"];
                this.columnNAZIVVRSTAELEMENT = this.Columns["NAZIVVRSTAELEMENT"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow(builder);
            }

            public S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow NewS_OD_REKAP_NETORow()
            {
                return (S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_REKAP_NETORowChanged != null)
                {
                    S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORowChangeEventHandler handler = this.S_OD_REKAP_NETORowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORowChangeEvent((S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_REKAP_NETORowChanging != null)
                {
                    S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORowChangeEventHandler handler = this.S_OD_REKAP_NETORowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORowChangeEvent((S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_REKAP_NETORowDeleted != null)
                {
                    S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORowChangeEventHandler handler = this.S_OD_REKAP_NETORowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORowChangeEvent((S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_REKAP_NETORowDeleting != null)
                {
                    S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORowChangeEventHandler handler = this.S_OD_REKAP_NETORowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORowChangeEvent((S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_REKAP_NETORow(S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow row)
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

            public DataColumn IDVRSTAELEMENTAColumn
            {
                get
                {
                    return this.columnIDVRSTAELEMENTA;
                }
            }

            public DataColumn IMEColumn
            {
                get
                {
                    return this.columnIME;
                }
            }

            public S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow this[int index]
            {
                get
                {
                    return (S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow) this.Rows[index];
                }
            }

            public DataColumn IZNOSColumn
            {
                get
                {
                    return this.columnIZNOS;
                }
            }

            public DataColumn JMBGColumn
            {
                get
                {
                    return this.columnJMBG;
                }
            }

            public DataColumn NAZIVELEMENTColumn
            {
                get
                {
                    return this.columnNAZIVELEMENT;
                }
            }

            public DataColumn NAZIVVRSTAELEMENTColumn
            {
                get
                {
                    return this.columnNAZIVVRSTAELEMENT;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn satiColumn
            {
                get
                {
                    return this.columnsati;
                }
            }
        }

        public class S_OD_REKAP_NETORow : DataRow
        {
            private S_OD_REKAP_NETODataSet.S_OD_REKAP_NETODataTable tableS_OD_REKAP_NETO;

            internal S_OD_REKAP_NETORow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_REKAP_NETO = (S_OD_REKAP_NETODataSet.S_OD_REKAP_NETODataTable) this.Table;
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_NETO.IDRADNIKColumn);
            }

            public bool IsIDVRSTAELEMENTANull()
            {
                return this.IsNull(this.tableS_OD_REKAP_NETO.IDVRSTAELEMENTAColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_NETO.IMEColumn);
            }

            public bool IsIZNOSNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_NETO.IZNOSColumn);
            }

            public bool IsJMBGNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_NETO.JMBGColumn);
            }

            public bool IsNAZIVELEMENTNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_NETO.NAZIVELEMENTColumn);
            }

            public bool IsNAZIVVRSTAELEMENTNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_NETO.NAZIVVRSTAELEMENTColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_NETO.PREZIMEColumn);
            }

            public bool IssatiNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_NETO.satiColumn);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_OD_REKAP_NETO.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDVRSTAELEMENTANull()
            {
                this[this.tableS_OD_REKAP_NETO.IDVRSTAELEMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableS_OD_REKAP_NETO.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSNull()
            {
                this[this.tableS_OD_REKAP_NETO.IZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGNull()
            {
                this[this.tableS_OD_REKAP_NETO.JMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVELEMENTNull()
            {
                this[this.tableS_OD_REKAP_NETO.NAZIVELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVVRSTAELEMENTNull()
            {
                this[this.tableS_OD_REKAP_NETO.NAZIVVRSTAELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableS_OD_REKAP_NETO.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetsatiNull()
            {
                this[this.tableS_OD_REKAP_NETO.satiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_REKAP_NETO.IDRADNIKColumn]);
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
                    this[this.tableS_OD_REKAP_NETO.IDRADNIKColumn] = value;
                }
            }

            public short IDVRSTAELEMENTA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableS_OD_REKAP_NETO.IDVRSTAELEMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDVRSTAELEMENTA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_NETO.IDVRSTAELEMENTAColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_NETO.IMEColumn]);
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
                    this[this.tableS_OD_REKAP_NETO.IMEColumn] = value;
                }
            }

            public decimal IZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_REKAP_NETO.IZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IZNOS because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_NETO.IZNOSColumn] = value;
                }
            }

            public string JMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_NETO.JMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_NETO.JMBGColumn] = value;
                }
            }

            public string NAZIVELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_NETO.NAZIVELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_NETO.NAZIVELEMENTColumn] = value;
                }
            }

            public string NAZIVVRSTAELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_NETO.NAZIVVRSTAELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_NETO.NAZIVVRSTAELEMENTColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_NETO.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_NETO.PREZIMEColumn] = value;
                }
            }

            public decimal sati
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_REKAP_NETO.satiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_NETO.satiColumn] = value;
                }
            }
        }

        public class S_OD_REKAP_NETORowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow eventRow;

            public S_OD_REKAP_NETORowChangeEvent(S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow row, DataRowAction action)
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

            public S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_REKAP_NETORowChangeEventHandler(object sender, S_OD_REKAP_NETODataSet.S_OD_REKAP_NETORowChangeEvent e);
    }
}

