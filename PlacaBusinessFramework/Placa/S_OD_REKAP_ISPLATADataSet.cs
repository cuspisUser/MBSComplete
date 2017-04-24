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
    public class S_OD_REKAP_ISPLATADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_REKAP_ISPLATADataTable tableS_OD_REKAP_ISPLATA;

        public S_OD_REKAP_ISPLATADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_REKAP_ISPLATADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_REKAP_ISPLATA"] != null)
                    {
                        this.Tables.Add(new S_OD_REKAP_ISPLATADataTable(dataSet.Tables["S_OD_REKAP_ISPLATA"]));
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
            S_OD_REKAP_ISPLATADataSet set = (S_OD_REKAP_ISPLATADataSet) base.Clone();
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
            S_OD_REKAP_ISPLATADataSet set = new S_OD_REKAP_ISPLATADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_REKAP_ISPLATADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2048");
            this.ExtendedProperties.Add("DataSetName", "S_OD_REKAP_ISPLATADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_REKAP_ISPLATADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_REKAP_ISPLATA");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_REKAP_ISPLATA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_NA_RUKE_ISPLATA");
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
            this.DataSetName = "S_OD_REKAP_ISPLATADataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_REKAP_ISPLATA";
            this.tableS_OD_REKAP_ISPLATA = new S_OD_REKAP_ISPLATADataTable();
            this.Tables.Add(this.tableS_OD_REKAP_ISPLATA);
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
            this.tableS_OD_REKAP_ISPLATA = (S_OD_REKAP_ISPLATADataTable) this.Tables["S_OD_REKAP_ISPLATA"];
            if (initTable && (this.tableS_OD_REKAP_ISPLATA != null))
            {
                this.tableS_OD_REKAP_ISPLATA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_REKAP_ISPLATA"] != null)
                {
                    this.Tables.Add(new S_OD_REKAP_ISPLATADataTable(dataSet.Tables["S_OD_REKAP_ISPLATA"]));
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

        private bool ShouldSerializeS_OD_REKAP_ISPLATA()
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
        public S_OD_REKAP_ISPLATADataTable S_OD_REKAP_ISPLATA
        {
            get
            {
                return this.tableS_OD_REKAP_ISPLATA;
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
        public class S_OD_REKAP_ISPLATADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDBANKE;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnJMBG;
            private DataColumn columnNAZIVBANKE1;
            private DataColumn columnNAZIVBANKE2;
            private DataColumn columnPREZIME;
            private DataColumn columnTEKUCI;
            private DataColumn columnUKUPNOZAISPLATU;
            private DataColumn columnVBDIBANKE;
            private DataColumn columnZBIRNINETO;
            private DataColumn columnZRNBANKE;

            public event S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARowChangeEventHandler S_OD_REKAP_ISPLATARowChanged;

            public event S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARowChangeEventHandler S_OD_REKAP_ISPLATARowChanging;

            public event S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARowChangeEventHandler S_OD_REKAP_ISPLATARowDeleted;

            public event S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARowChangeEventHandler S_OD_REKAP_ISPLATARowDeleting;

            public S_OD_REKAP_ISPLATADataTable()
            {
                this.TableName = "S_OD_REKAP_ISPLATA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_REKAP_ISPLATADataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_REKAP_ISPLATADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_REKAP_ISPLATARow(S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow AddS_OD_REKAP_ISPLATARow(int iDRADNIK, string pREZIME, string iME, string jMBG, string tEKUCI, bool zBIRNINETO, string vBDIBANKE, string zRNBANKE, int iDBANKE, string nAZIVBANKE1, string nAZIVBANKE2, decimal uKUPNOZAISPLATU)
            {
                S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow row = (S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow) this.NewRow();
                row.ItemArray = new object[] { iDRADNIK, pREZIME, iME, jMBG, tEKUCI, zBIRNINETO, vBDIBANKE, zRNBANKE, iDBANKE, nAZIVBANKE1, nAZIVBANKE2, uKUPNOZAISPLATU };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATADataTable table = (S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_REKAP_ISPLATADataSet set = new S_OD_REKAP_ISPLATADataSet();
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
                this.columnZBIRNINETO = new DataColumn("ZBIRNINETO", typeof(bool), "", MappingType.Element);
                this.columnZBIRNINETO.Caption = "Uključen u zbirni neto";
                this.columnZBIRNINETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnZBIRNINETO.ExtendedProperties.Add("IsKey", "false");
                this.columnZBIRNINETO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZBIRNINETO.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnZBIRNINETO.ExtendedProperties.Add("Description", "Uključen u zbirni neto");
                this.columnZBIRNINETO.ExtendedProperties.Add("Length", "1");
                this.columnZBIRNINETO.ExtendedProperties.Add("Decimals", "0");
                this.columnZBIRNINETO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZBIRNINETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.InternalName", "ZBIRNINETO");
                this.Columns.Add(this.columnZBIRNINETO);
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
                this.columnIDBANKE = new DataColumn("IDBANKE", typeof(int), "", MappingType.Element);
                this.columnIDBANKE.Caption = "Šifra banke";
                this.columnIDBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDBANKE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDBANKE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDBANKE.ExtendedProperties.Add("Description", "Šifra banke");
                this.columnIDBANKE.ExtendedProperties.Add("Length", "5");
                this.columnIDBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBANKE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDBANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.InternalName", "IDBANKE");
                this.Columns.Add(this.columnIDBANKE);
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
                this.columnNAZIVBANKE2 = new DataColumn("NAZIVBANKE2", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE2.Caption = "Naziv banke (2)";
                this.columnNAZIVBANKE2.MaxLength = 20;
                this.columnNAZIVBANKE2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Description", "Naziv banke (2)");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE2");
                this.Columns.Add(this.columnNAZIVBANKE2);
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
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_REKAP_ISPLATA");
                this.ExtendedProperties.Add("Description", "_S_OD_REKAP_ISPLATA");
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
                this.columnZBIRNINETO = this.Columns["ZBIRNINETO"];
                this.columnVBDIBANKE = this.Columns["VBDIBANKE"];
                this.columnZRNBANKE = this.Columns["ZRNBANKE"];
                this.columnIDBANKE = this.Columns["IDBANKE"];
                this.columnNAZIVBANKE1 = this.Columns["NAZIVBANKE1"];
                this.columnNAZIVBANKE2 = this.Columns["NAZIVBANKE2"];
                this.columnUKUPNOZAISPLATU = this.Columns["UKUPNOZAISPLATU"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow(builder);
            }

            public S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow NewS_OD_REKAP_ISPLATARow()
            {
                return (S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_REKAP_ISPLATARowChanged != null)
                {
                    S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARowChangeEventHandler handler = this.S_OD_REKAP_ISPLATARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARowChangeEvent((S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_REKAP_ISPLATARowChanging != null)
                {
                    S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARowChangeEventHandler handler = this.S_OD_REKAP_ISPLATARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARowChangeEvent((S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_REKAP_ISPLATARowDeleted != null)
                {
                    S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARowChangeEventHandler handler = this.S_OD_REKAP_ISPLATARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARowChangeEvent((S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_REKAP_ISPLATARowDeleting != null)
                {
                    S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARowChangeEventHandler handler = this.S_OD_REKAP_ISPLATARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARowChangeEvent((S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_REKAP_ISPLATARow(S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow row)
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

            public DataColumn IDBANKEColumn
            {
                get
                {
                    return this.columnIDBANKE;
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

            public S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow this[int index]
            {
                get
                {
                    return (S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow) this.Rows[index];
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

            public DataColumn NAZIVBANKE2Column
            {
                get
                {
                    return this.columnNAZIVBANKE2;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
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

            public DataColumn ZBIRNINETOColumn
            {
                get
                {
                    return this.columnZBIRNINETO;
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

        public class S_OD_REKAP_ISPLATARow : DataRow
        {
            private S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATADataTable tableS_OD_REKAP_ISPLATA;

            internal S_OD_REKAP_ISPLATARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_REKAP_ISPLATA = (S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATADataTable) this.Table;
            }

            public bool IsIDBANKENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_ISPLATA.IDBANKEColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_ISPLATA.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_ISPLATA.IMEColumn);
            }

            public bool IsJMBGNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_ISPLATA.JMBGColumn);
            }

            public bool IsNAZIVBANKE1Null()
            {
                return this.IsNull(this.tableS_OD_REKAP_ISPLATA.NAZIVBANKE1Column);
            }

            public bool IsNAZIVBANKE2Null()
            {
                return this.IsNull(this.tableS_OD_REKAP_ISPLATA.NAZIVBANKE2Column);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_ISPLATA.PREZIMEColumn);
            }

            public bool IsTEKUCINull()
            {
                return this.IsNull(this.tableS_OD_REKAP_ISPLATA.TEKUCIColumn);
            }

            public bool IsUKUPNOZAISPLATUNull()
            {
                return this.IsNull(this.tableS_OD_REKAP_ISPLATA.UKUPNOZAISPLATUColumn);
            }

            public bool IsVBDIBANKENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_ISPLATA.VBDIBANKEColumn);
            }

            public bool IsZBIRNINETONull()
            {
                return this.IsNull(this.tableS_OD_REKAP_ISPLATA.ZBIRNINETOColumn);
            }

            public bool IsZRNBANKENull()
            {
                return this.IsNull(this.tableS_OD_REKAP_ISPLATA.ZRNBANKEColumn);
            }

            public void SetIDBANKENull()
            {
                this[this.tableS_OD_REKAP_ISPLATA.IDBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_OD_REKAP_ISPLATA.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableS_OD_REKAP_ISPLATA.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGNull()
            {
                this[this.tableS_OD_REKAP_ISPLATA.JMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE1Null()
            {
                this[this.tableS_OD_REKAP_ISPLATA.NAZIVBANKE1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE2Null()
            {
                this[this.tableS_OD_REKAP_ISPLATA.NAZIVBANKE2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableS_OD_REKAP_ISPLATA.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTEKUCINull()
            {
                this[this.tableS_OD_REKAP_ISPLATA.TEKUCIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOZAISPLATUNull()
            {
                this[this.tableS_OD_REKAP_ISPLATA.UKUPNOZAISPLATUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIBANKENull()
            {
                this[this.tableS_OD_REKAP_ISPLATA.VBDIBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZBIRNINETONull()
            {
                this[this.tableS_OD_REKAP_ISPLATA.ZBIRNINETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNBANKENull()
            {
                this[this.tableS_OD_REKAP_ISPLATA.ZRNBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDBANKE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_REKAP_ISPLATA.IDBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDBANKE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_ISPLATA.IDBANKEColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_REKAP_ISPLATA.IDRADNIKColumn]);
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
                    this[this.tableS_OD_REKAP_ISPLATA.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_ISPLATA.IMEColumn]);
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
                    this[this.tableS_OD_REKAP_ISPLATA.IMEColumn] = value;
                }
            }

            public string JMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_ISPLATA.JMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value JMBG because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_ISPLATA.JMBGColumn] = value;
                }
            }

            public string NAZIVBANKE1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_ISPLATA.NAZIVBANKE1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVBANKE1 because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_ISPLATA.NAZIVBANKE1Column] = value;
                }
            }

            public string NAZIVBANKE2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_ISPLATA.NAZIVBANKE2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVBANKE2 because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_ISPLATA.NAZIVBANKE2Column] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_ISPLATA.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_ISPLATA.PREZIMEColumn] = value;
                }
            }

            public string TEKUCI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_ISPLATA.TEKUCIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_ISPLATA.TEKUCIColumn] = value;
                }
            }

            public decimal UKUPNOZAISPLATU
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_REKAP_ISPLATA.UKUPNOZAISPLATUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_REKAP_ISPLATA.UKUPNOZAISPLATUColumn] = value;
                }
            }

            public string VBDIBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_ISPLATA.VBDIBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_ISPLATA.VBDIBANKEColumn] = value;
                }
            }

            public bool ZBIRNINETO
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableS_OD_REKAP_ISPLATA.ZBIRNINETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableS_OD_REKAP_ISPLATA.ZBIRNINETOColumn] = value;
                }
            }

            public string ZRNBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_REKAP_ISPLATA.ZRNBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_REKAP_ISPLATA.ZRNBANKEColumn] = value;
                }
            }
        }

        public class S_OD_REKAP_ISPLATARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow eventRow;

            public S_OD_REKAP_ISPLATARowChangeEvent(S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow row, DataRowAction action)
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

            public S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_REKAP_ISPLATARowChangeEventHandler(object sender, S_OD_REKAP_ISPLATADataSet.S_OD_REKAP_ISPLATARowChangeEvent e);
    }
}

