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
    public class sp_maticni_kartonDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private sp_maticni_kartonDataTable tablesp_maticni_karton;

        public sp_maticni_kartonDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected sp_maticni_kartonDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["sp_maticni_karton"] != null)
                    {
                        this.Tables.Add(new sp_maticni_kartonDataTable(dataSet.Tables["sp_maticni_karton"]));
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
            sp_maticni_kartonDataSet set = (sp_maticni_kartonDataSet) base.Clone();
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
            sp_maticni_kartonDataSet set = new sp_maticni_kartonDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "sp_maticni_kartonDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2038");
            this.ExtendedProperties.Add("DataSetName", "sp_maticni_kartonDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Isp_maticni_kartonDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "sp_maticni_karton");
            this.ExtendedProperties.Add("ObjectDescription", "sp_maticni_karton");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_MATICNI_KARTON_ZAPOSLENIKA_ILI_USTANOVE");
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
            this.DataSetName = "sp_maticni_kartonDataSet";
            this.Namespace = "http://www.tempuri.org/sp_maticni_karton";
            this.tablesp_maticni_karton = new sp_maticni_kartonDataTable();
            this.Tables.Add(this.tablesp_maticni_karton);
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
            this.tablesp_maticni_karton = (sp_maticni_kartonDataTable) this.Tables["sp_maticni_karton"];
            if (initTable && (this.tablesp_maticni_karton != null))
            {
                this.tablesp_maticni_karton.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["sp_maticni_karton"] != null)
                {
                    this.Tables.Add(new sp_maticni_kartonDataTable(dataSet.Tables["sp_maticni_karton"]));
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

        private bool ShouldSerializesp_maticni_karton()
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
        public sp_maticni_kartonDataTable sp_maticni_karton
        {
            get
            {
                return this.tablesp_maticni_karton;
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
        public class sp_maticni_kartonDataTable : DataTable, IEnumerable
        {
            private DataColumn columnidpodatka;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnJMBG;
            private DataColumn columnmj01;
            private DataColumn columnmj02;
            private DataColumn columnmj03;
            private DataColumn columnmj04;
            private DataColumn columnmj05;
            private DataColumn columnmj06;
            private DataColumn columnmj07;
            private DataColumn columnmj08;
            private DataColumn columnmj09;
            private DataColumn columnmj10;
            private DataColumn columnmj11;
            private DataColumn columnmj12;
            private DataColumn columnnazivpodatka;
            private DataColumn columnopistip;
            private DataColumn columnPREZIME;
            private DataColumn columnsati01;
            private DataColumn columnsati02;
            private DataColumn columnsati03;
            private DataColumn columnsati04;
            private DataColumn columnsati05;
            private DataColumn columnsati06;
            private DataColumn columnsati07;
            private DataColumn columnsati08;
            private DataColumn columnsati09;
            private DataColumn columnsati10;
            private DataColumn columnsati11;
            private DataColumn columnsati12;
            private DataColumn columntip;
            private DataColumn columnUKUPNO;
            private DataColumn columnukupnosati;
            private DataColumn columnvrstavrij;

            public event sp_maticni_kartonDataSet.sp_maticni_kartonRowChangeEventHandler sp_maticni_kartonRowChanged;

            public event sp_maticni_kartonDataSet.sp_maticni_kartonRowChangeEventHandler sp_maticni_kartonRowChanging;

            public event sp_maticni_kartonDataSet.sp_maticni_kartonRowChangeEventHandler sp_maticni_kartonRowDeleted;

            public event sp_maticni_kartonDataSet.sp_maticni_kartonRowChangeEventHandler sp_maticni_kartonRowDeleting;

            public sp_maticni_kartonDataTable()
            {
                this.TableName = "sp_maticni_karton";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal sp_maticni_kartonDataTable(DataTable table) : base(table.TableName)
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

            protected sp_maticni_kartonDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void Addsp_maticni_kartonRow(sp_maticni_kartonDataSet.sp_maticni_kartonRow row)
            {
                this.Rows.Add(row);
            }

            public sp_maticni_kartonDataSet.sp_maticni_kartonRow Addsp_maticni_kartonRow(int tip, string opistip, int vrstavrij, int iDRADNIK, string pREZIME, string iME, string jMBG, int idpodatka, string nazivpodatka, decimal mj01, decimal mj02, decimal mj03, decimal mj04, decimal mj05, decimal mj06, decimal mj07, decimal mj08, decimal mj09, decimal mj10, decimal mj11, decimal mj12, decimal uKUPNO, decimal sati01, decimal sati02, decimal sati03, decimal sati04, decimal sati05, decimal sati06, decimal sati07, decimal sati08, decimal sati09, decimal sati10, decimal sati11, decimal sati12, decimal ukupnosati)
            {
                sp_maticni_kartonDataSet.sp_maticni_kartonRow row = (sp_maticni_kartonDataSet.sp_maticni_kartonRow) this.NewRow();
                row.ItemArray = new object[] { 
                    tip, opistip, vrstavrij, iDRADNIK, pREZIME, iME, jMBG, idpodatka, nazivpodatka, mj01, mj02, mj03, mj04, mj05, mj06, mj07, 
                    mj08, mj09, mj10, mj11, mj12, uKUPNO, sati01, sati02, sati03, sati04, sati05, sati06, sati07, sati08, sati09, sati10, 
                    sati11, sati12, ukupnosati
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                sp_maticni_kartonDataSet.sp_maticni_kartonDataTable table = (sp_maticni_kartonDataSet.sp_maticni_kartonDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(sp_maticni_kartonDataSet.sp_maticni_kartonRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                sp_maticni_kartonDataSet set = new sp_maticni_kartonDataSet();
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
                this.columntip = new DataColumn("tip", typeof(int), "", MappingType.Element);
                this.columntip.Caption = "tip";
                this.columntip.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columntip.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columntip.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columntip.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columntip.ExtendedProperties.Add("IsKey", "false");
                this.columntip.ExtendedProperties.Add("ReadOnly", "true");
                this.columntip.ExtendedProperties.Add("DeklaritType", "int");
                this.columntip.ExtendedProperties.Add("Description", "tip");
                this.columntip.ExtendedProperties.Add("Length", "5");
                this.columntip.ExtendedProperties.Add("Decimals", "0");
                this.columntip.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columntip.ExtendedProperties.Add("IsInReader", "true");
                this.columntip.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columntip.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columntip.ExtendedProperties.Add("Deklarit.InternalName", "tip");
                this.Columns.Add(this.columntip);
                this.columnopistip = new DataColumn("opistip", typeof(string), "", MappingType.Element);
                this.columnopistip.Caption = "opistip";
                this.columnopistip.MaxLength = 50;
                this.columnopistip.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnopistip.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnopistip.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnopistip.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnopistip.ExtendedProperties.Add("IsKey", "false");
                this.columnopistip.ExtendedProperties.Add("ReadOnly", "true");
                this.columnopistip.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnopistip.ExtendedProperties.Add("Description", "opistip");
                this.columnopistip.ExtendedProperties.Add("Length", "50");
                this.columnopistip.ExtendedProperties.Add("Decimals", "0");
                this.columnopistip.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnopistip.ExtendedProperties.Add("IsInReader", "true");
                this.columnopistip.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnopistip.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnopistip.ExtendedProperties.Add("Deklarit.InternalName", "opistip");
                this.Columns.Add(this.columnopistip);
                this.columnvrstavrij = new DataColumn("vrstavrij", typeof(int), "", MappingType.Element);
                this.columnvrstavrij.Caption = "vrstavrij";
                this.columnvrstavrij.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnvrstavrij.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnvrstavrij.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnvrstavrij.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnvrstavrij.ExtendedProperties.Add("IsKey", "false");
                this.columnvrstavrij.ExtendedProperties.Add("ReadOnly", "true");
                this.columnvrstavrij.ExtendedProperties.Add("DeklaritType", "int");
                this.columnvrstavrij.ExtendedProperties.Add("Description", "vrstavrij");
                this.columnvrstavrij.ExtendedProperties.Add("Length", "5");
                this.columnvrstavrij.ExtendedProperties.Add("Decimals", "0");
                this.columnvrstavrij.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnvrstavrij.ExtendedProperties.Add("IsInReader", "true");
                this.columnvrstavrij.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnvrstavrij.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnvrstavrij.ExtendedProperties.Add("Deklarit.InternalName", "vrstavrij");
                this.Columns.Add(this.columnvrstavrij);
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
                this.columnidpodatka = new DataColumn("idpodatka", typeof(int), "", MappingType.Element);
                this.columnidpodatka.Caption = "idpodatka";
                this.columnidpodatka.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnidpodatka.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnidpodatka.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnidpodatka.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnidpodatka.ExtendedProperties.Add("IsKey", "false");
                this.columnidpodatka.ExtendedProperties.Add("ReadOnly", "true");
                this.columnidpodatka.ExtendedProperties.Add("DeklaritType", "int");
                this.columnidpodatka.ExtendedProperties.Add("Description", "idpodatka");
                this.columnidpodatka.ExtendedProperties.Add("Length", "5");
                this.columnidpodatka.ExtendedProperties.Add("Decimals", "0");
                this.columnidpodatka.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnidpodatka.ExtendedProperties.Add("IsInReader", "true");
                this.columnidpodatka.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnidpodatka.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnidpodatka.ExtendedProperties.Add("Deklarit.InternalName", "idpodatka");
                this.Columns.Add(this.columnidpodatka);
                this.columnnazivpodatka = new DataColumn("nazivpodatka", typeof(string), "", MappingType.Element);
                this.columnnazivpodatka.Caption = "nazivpodatka";
                this.columnnazivpodatka.MaxLength = 50;
                this.columnnazivpodatka.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnazivpodatka.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnazivpodatka.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnazivpodatka.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnazivpodatka.ExtendedProperties.Add("IsKey", "false");
                this.columnnazivpodatka.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnazivpodatka.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnnazivpodatka.ExtendedProperties.Add("Description", "nazivpodatka");
                this.columnnazivpodatka.ExtendedProperties.Add("Length", "50");
                this.columnnazivpodatka.ExtendedProperties.Add("Decimals", "0");
                this.columnnazivpodatka.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnazivpodatka.ExtendedProperties.Add("IsInReader", "true");
                this.columnnazivpodatka.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnazivpodatka.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnazivpodatka.ExtendedProperties.Add("Deklarit.InternalName", "nazivpodatka");
                this.Columns.Add(this.columnnazivpodatka);
                this.columnmj01 = new DataColumn("mj01", typeof(decimal), "", MappingType.Element);
                this.columnmj01.Caption = "mj01";
                this.columnmj01.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmj01.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmj01.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmj01.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmj01.ExtendedProperties.Add("IsKey", "false");
                this.columnmj01.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmj01.ExtendedProperties.Add("DeklaritType", "int");
                this.columnmj01.ExtendedProperties.Add("Description", "mj01");
                this.columnmj01.ExtendedProperties.Add("Length", "12");
                this.columnmj01.ExtendedProperties.Add("Decimals", "2");
                this.columnmj01.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnmj01.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnmj01.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmj01.ExtendedProperties.Add("IsInReader", "true");
                this.columnmj01.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmj01.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmj01.ExtendedProperties.Add("Deklarit.InternalName", "mj01");
                this.Columns.Add(this.columnmj01);
                this.columnmj02 = new DataColumn("mj02", typeof(decimal), "", MappingType.Element);
                this.columnmj02.Caption = "mj02";
                this.columnmj02.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmj02.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmj02.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmj02.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmj02.ExtendedProperties.Add("IsKey", "false");
                this.columnmj02.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmj02.ExtendedProperties.Add("DeklaritType", "int");
                this.columnmj02.ExtendedProperties.Add("Description", "mj02");
                this.columnmj02.ExtendedProperties.Add("Length", "12");
                this.columnmj02.ExtendedProperties.Add("Decimals", "2");
                this.columnmj02.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnmj02.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnmj02.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmj02.ExtendedProperties.Add("IsInReader", "true");
                this.columnmj02.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmj02.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmj02.ExtendedProperties.Add("Deklarit.InternalName", "mj02");
                this.Columns.Add(this.columnmj02);
                this.columnmj03 = new DataColumn("mj03", typeof(decimal), "", MappingType.Element);
                this.columnmj03.Caption = "mj03";
                this.columnmj03.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmj03.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmj03.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmj03.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmj03.ExtendedProperties.Add("IsKey", "false");
                this.columnmj03.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmj03.ExtendedProperties.Add("DeklaritType", "int");
                this.columnmj03.ExtendedProperties.Add("Description", "mj03");
                this.columnmj03.ExtendedProperties.Add("Length", "12");
                this.columnmj03.ExtendedProperties.Add("Decimals", "2");
                this.columnmj03.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnmj03.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnmj03.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmj03.ExtendedProperties.Add("IsInReader", "true");
                this.columnmj03.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmj03.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmj03.ExtendedProperties.Add("Deklarit.InternalName", "mj03");
                this.Columns.Add(this.columnmj03);
                this.columnmj04 = new DataColumn("mj04", typeof(decimal), "", MappingType.Element);
                this.columnmj04.Caption = "mj04";
                this.columnmj04.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmj04.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmj04.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmj04.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmj04.ExtendedProperties.Add("IsKey", "false");
                this.columnmj04.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmj04.ExtendedProperties.Add("DeklaritType", "int");
                this.columnmj04.ExtendedProperties.Add("Description", "mj04");
                this.columnmj04.ExtendedProperties.Add("Length", "12");
                this.columnmj04.ExtendedProperties.Add("Decimals", "2");
                this.columnmj04.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnmj04.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnmj04.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmj04.ExtendedProperties.Add("IsInReader", "true");
                this.columnmj04.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmj04.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmj04.ExtendedProperties.Add("Deklarit.InternalName", "mj04");
                this.Columns.Add(this.columnmj04);
                this.columnmj05 = new DataColumn("mj05", typeof(decimal), "", MappingType.Element);
                this.columnmj05.Caption = "mj05";
                this.columnmj05.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmj05.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmj05.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmj05.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmj05.ExtendedProperties.Add("IsKey", "false");
                this.columnmj05.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmj05.ExtendedProperties.Add("DeklaritType", "int");
                this.columnmj05.ExtendedProperties.Add("Description", "mj05");
                this.columnmj05.ExtendedProperties.Add("Length", "12");
                this.columnmj05.ExtendedProperties.Add("Decimals", "2");
                this.columnmj05.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnmj05.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnmj05.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmj05.ExtendedProperties.Add("IsInReader", "true");
                this.columnmj05.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmj05.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmj05.ExtendedProperties.Add("Deklarit.InternalName", "mj05");
                this.Columns.Add(this.columnmj05);
                this.columnmj06 = new DataColumn("mj06", typeof(decimal), "", MappingType.Element);
                this.columnmj06.Caption = "mj06";
                this.columnmj06.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmj06.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmj06.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmj06.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmj06.ExtendedProperties.Add("IsKey", "false");
                this.columnmj06.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmj06.ExtendedProperties.Add("DeklaritType", "int");
                this.columnmj06.ExtendedProperties.Add("Description", "mj06");
                this.columnmj06.ExtendedProperties.Add("Length", "12");
                this.columnmj06.ExtendedProperties.Add("Decimals", "2");
                this.columnmj06.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnmj06.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnmj06.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmj06.ExtendedProperties.Add("IsInReader", "true");
                this.columnmj06.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmj06.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmj06.ExtendedProperties.Add("Deklarit.InternalName", "mj06");
                this.Columns.Add(this.columnmj06);
                this.columnmj07 = new DataColumn("mj07", typeof(decimal), "", MappingType.Element);
                this.columnmj07.Caption = "mj07";
                this.columnmj07.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmj07.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmj07.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmj07.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmj07.ExtendedProperties.Add("IsKey", "false");
                this.columnmj07.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmj07.ExtendedProperties.Add("DeklaritType", "int");
                this.columnmj07.ExtendedProperties.Add("Description", "mj07");
                this.columnmj07.ExtendedProperties.Add("Length", "12");
                this.columnmj07.ExtendedProperties.Add("Decimals", "2");
                this.columnmj07.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnmj07.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnmj07.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmj07.ExtendedProperties.Add("IsInReader", "true");
                this.columnmj07.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmj07.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmj07.ExtendedProperties.Add("Deklarit.InternalName", "mj07");
                this.Columns.Add(this.columnmj07);
                this.columnmj08 = new DataColumn("mj08", typeof(decimal), "", MappingType.Element);
                this.columnmj08.Caption = "mj08";
                this.columnmj08.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmj08.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmj08.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmj08.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmj08.ExtendedProperties.Add("IsKey", "false");
                this.columnmj08.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmj08.ExtendedProperties.Add("DeklaritType", "int");
                this.columnmj08.ExtendedProperties.Add("Description", "mj08");
                this.columnmj08.ExtendedProperties.Add("Length", "12");
                this.columnmj08.ExtendedProperties.Add("Decimals", "2");
                this.columnmj08.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnmj08.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnmj08.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmj08.ExtendedProperties.Add("IsInReader", "true");
                this.columnmj08.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmj08.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmj08.ExtendedProperties.Add("Deklarit.InternalName", "mj08");
                this.Columns.Add(this.columnmj08);
                this.columnmj09 = new DataColumn("mj09", typeof(decimal), "", MappingType.Element);
                this.columnmj09.Caption = "mj09";
                this.columnmj09.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmj09.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmj09.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmj09.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmj09.ExtendedProperties.Add("IsKey", "false");
                this.columnmj09.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmj09.ExtendedProperties.Add("DeklaritType", "int");
                this.columnmj09.ExtendedProperties.Add("Description", "mj09");
                this.columnmj09.ExtendedProperties.Add("Length", "12");
                this.columnmj09.ExtendedProperties.Add("Decimals", "2");
                this.columnmj09.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnmj09.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnmj09.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmj09.ExtendedProperties.Add("IsInReader", "true");
                this.columnmj09.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmj09.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmj09.ExtendedProperties.Add("Deklarit.InternalName", "mj09");
                this.Columns.Add(this.columnmj09);
                this.columnmj10 = new DataColumn("mj10", typeof(decimal), "", MappingType.Element);
                this.columnmj10.Caption = "mj10";
                this.columnmj10.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmj10.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmj10.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmj10.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmj10.ExtendedProperties.Add("IsKey", "false");
                this.columnmj10.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmj10.ExtendedProperties.Add("DeklaritType", "int");
                this.columnmj10.ExtendedProperties.Add("Description", "mj10");
                this.columnmj10.ExtendedProperties.Add("Length", "12");
                this.columnmj10.ExtendedProperties.Add("Decimals", "2");
                this.columnmj10.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnmj10.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnmj10.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmj10.ExtendedProperties.Add("IsInReader", "true");
                this.columnmj10.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmj10.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmj10.ExtendedProperties.Add("Deklarit.InternalName", "mj10");
                this.Columns.Add(this.columnmj10);
                this.columnmj11 = new DataColumn("mj11", typeof(decimal), "", MappingType.Element);
                this.columnmj11.Caption = "mj11";
                this.columnmj11.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmj11.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmj11.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmj11.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmj11.ExtendedProperties.Add("IsKey", "false");
                this.columnmj11.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmj11.ExtendedProperties.Add("DeklaritType", "int");
                this.columnmj11.ExtendedProperties.Add("Description", "mj11");
                this.columnmj11.ExtendedProperties.Add("Length", "12");
                this.columnmj11.ExtendedProperties.Add("Decimals", "2");
                this.columnmj11.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnmj11.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnmj11.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmj11.ExtendedProperties.Add("IsInReader", "true");
                this.columnmj11.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmj11.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmj11.ExtendedProperties.Add("Deklarit.InternalName", "mj11");
                this.Columns.Add(this.columnmj11);
                this.columnmj12 = new DataColumn("mj12", typeof(decimal), "", MappingType.Element);
                this.columnmj12.Caption = "mj12";
                this.columnmj12.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmj12.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmj12.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmj12.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmj12.ExtendedProperties.Add("IsKey", "false");
                this.columnmj12.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmj12.ExtendedProperties.Add("DeklaritType", "int");
                this.columnmj12.ExtendedProperties.Add("Description", "mj12");
                this.columnmj12.ExtendedProperties.Add("Length", "12");
                this.columnmj12.ExtendedProperties.Add("Decimals", "2");
                this.columnmj12.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnmj12.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnmj12.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmj12.ExtendedProperties.Add("IsInReader", "true");
                this.columnmj12.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmj12.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmj12.ExtendedProperties.Add("Deklarit.InternalName", "mj12");
                this.Columns.Add(this.columnmj12);
                this.columnUKUPNO = new DataColumn("UKUPNO", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNO.Caption = "UKUPNO";
                this.columnUKUPNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUKUPNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNO.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNO.ExtendedProperties.Add("Description", "UKUPNO");
                this.columnUKUPNO.ExtendedProperties.Add("Length", "8");
                this.columnUKUPNO.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNO.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNO.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNO");
                this.Columns.Add(this.columnUKUPNO);
                this.columnsati01 = new DataColumn("sati01", typeof(decimal), "", MappingType.Element);
                this.columnsati01.Caption = "sati01";
                this.columnsati01.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsati01.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsati01.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsati01.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsati01.ExtendedProperties.Add("IsKey", "false");
                this.columnsati01.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsati01.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsati01.ExtendedProperties.Add("Description", "sati01");
                this.columnsati01.ExtendedProperties.Add("Length", "12");
                this.columnsati01.ExtendedProperties.Add("Decimals", "2");
                this.columnsati01.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsati01.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsati01.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsati01.ExtendedProperties.Add("IsInReader", "true");
                this.columnsati01.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsati01.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsati01.ExtendedProperties.Add("Deklarit.InternalName", "sati01");
                this.Columns.Add(this.columnsati01);
                this.columnsati02 = new DataColumn("sati02", typeof(decimal), "", MappingType.Element);
                this.columnsati02.Caption = "sati02";
                this.columnsati02.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsati02.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsati02.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsati02.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsati02.ExtendedProperties.Add("IsKey", "false");
                this.columnsati02.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsati02.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsati02.ExtendedProperties.Add("Description", "sati02");
                this.columnsati02.ExtendedProperties.Add("Length", "12");
                this.columnsati02.ExtendedProperties.Add("Decimals", "2");
                this.columnsati02.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsati02.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsati02.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsati02.ExtendedProperties.Add("IsInReader", "true");
                this.columnsati02.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsati02.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsati02.ExtendedProperties.Add("Deklarit.InternalName", "sati02");
                this.Columns.Add(this.columnsati02);
                this.columnsati03 = new DataColumn("sati03", typeof(decimal), "", MappingType.Element);
                this.columnsati03.Caption = "sati03";
                this.columnsati03.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsati03.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsati03.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsati03.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsati03.ExtendedProperties.Add("IsKey", "false");
                this.columnsati03.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsati03.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsati03.ExtendedProperties.Add("Description", "sati03");
                this.columnsati03.ExtendedProperties.Add("Length", "12");
                this.columnsati03.ExtendedProperties.Add("Decimals", "2");
                this.columnsati03.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsati03.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsati03.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsati03.ExtendedProperties.Add("IsInReader", "true");
                this.columnsati03.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsati03.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsati03.ExtendedProperties.Add("Deklarit.InternalName", "sati03");
                this.Columns.Add(this.columnsati03);
                this.columnsati04 = new DataColumn("sati04", typeof(decimal), "", MappingType.Element);
                this.columnsati04.Caption = "sati04";
                this.columnsati04.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsati04.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsati04.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsati04.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsati04.ExtendedProperties.Add("IsKey", "false");
                this.columnsati04.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsati04.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsati04.ExtendedProperties.Add("Description", "sati04");
                this.columnsati04.ExtendedProperties.Add("Length", "12");
                this.columnsati04.ExtendedProperties.Add("Decimals", "2");
                this.columnsati04.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsati04.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsati04.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsati04.ExtendedProperties.Add("IsInReader", "true");
                this.columnsati04.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsati04.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsati04.ExtendedProperties.Add("Deklarit.InternalName", "sati04");
                this.Columns.Add(this.columnsati04);
                this.columnsati05 = new DataColumn("sati05", typeof(decimal), "", MappingType.Element);
                this.columnsati05.Caption = "sati05";
                this.columnsati05.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsati05.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsati05.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsati05.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsati05.ExtendedProperties.Add("IsKey", "false");
                this.columnsati05.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsati05.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsati05.ExtendedProperties.Add("Description", "sati05");
                this.columnsati05.ExtendedProperties.Add("Length", "12");
                this.columnsati05.ExtendedProperties.Add("Decimals", "2");
                this.columnsati05.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsati05.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsati05.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsati05.ExtendedProperties.Add("IsInReader", "true");
                this.columnsati05.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsati05.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsati05.ExtendedProperties.Add("Deklarit.InternalName", "sati05");
                this.Columns.Add(this.columnsati05);
                this.columnsati06 = new DataColumn("sati06", typeof(decimal), "", MappingType.Element);
                this.columnsati06.Caption = "sati06";
                this.columnsati06.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsati06.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsati06.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsati06.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsati06.ExtendedProperties.Add("IsKey", "false");
                this.columnsati06.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsati06.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsati06.ExtendedProperties.Add("Description", "sati06");
                this.columnsati06.ExtendedProperties.Add("Length", "12");
                this.columnsati06.ExtendedProperties.Add("Decimals", "2");
                this.columnsati06.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsati06.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsati06.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsati06.ExtendedProperties.Add("IsInReader", "true");
                this.columnsati06.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsati06.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsati06.ExtendedProperties.Add("Deklarit.InternalName", "sati06");
                this.Columns.Add(this.columnsati06);
                this.columnsati07 = new DataColumn("sati07", typeof(decimal), "", MappingType.Element);
                this.columnsati07.Caption = "sati07";
                this.columnsati07.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsati07.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsati07.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsati07.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsati07.ExtendedProperties.Add("IsKey", "false");
                this.columnsati07.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsati07.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsati07.ExtendedProperties.Add("Description", "sati07");
                this.columnsati07.ExtendedProperties.Add("Length", "12");
                this.columnsati07.ExtendedProperties.Add("Decimals", "2");
                this.columnsati07.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsati07.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsati07.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsati07.ExtendedProperties.Add("IsInReader", "true");
                this.columnsati07.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsati07.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsati07.ExtendedProperties.Add("Deklarit.InternalName", "sati07");
                this.Columns.Add(this.columnsati07);
                this.columnsati08 = new DataColumn("sati08", typeof(decimal), "", MappingType.Element);
                this.columnsati08.Caption = "sati08";
                this.columnsati08.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsati08.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsati08.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsati08.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsati08.ExtendedProperties.Add("IsKey", "false");
                this.columnsati08.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsati08.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsati08.ExtendedProperties.Add("Description", "sati08");
                this.columnsati08.ExtendedProperties.Add("Length", "12");
                this.columnsati08.ExtendedProperties.Add("Decimals", "2");
                this.columnsati08.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsati08.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsati08.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsati08.ExtendedProperties.Add("IsInReader", "true");
                this.columnsati08.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsati08.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsati08.ExtendedProperties.Add("Deklarit.InternalName", "sati08");
                this.Columns.Add(this.columnsati08);
                this.columnsati09 = new DataColumn("sati09", typeof(decimal), "", MappingType.Element);
                this.columnsati09.Caption = "sati09";
                this.columnsati09.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsati09.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsati09.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsati09.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsati09.ExtendedProperties.Add("IsKey", "false");
                this.columnsati09.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsati09.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsati09.ExtendedProperties.Add("Description", "sati09");
                this.columnsati09.ExtendedProperties.Add("Length", "12");
                this.columnsati09.ExtendedProperties.Add("Decimals", "2");
                this.columnsati09.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsati09.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsati09.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsati09.ExtendedProperties.Add("IsInReader", "true");
                this.columnsati09.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsati09.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsati09.ExtendedProperties.Add("Deklarit.InternalName", "sati09");
                this.Columns.Add(this.columnsati09);
                this.columnsati10 = new DataColumn("sati10", typeof(decimal), "", MappingType.Element);
                this.columnsati10.Caption = "sati10";
                this.columnsati10.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsati10.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsati10.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsati10.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsati10.ExtendedProperties.Add("IsKey", "false");
                this.columnsati10.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsati10.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsati10.ExtendedProperties.Add("Description", "sati10");
                this.columnsati10.ExtendedProperties.Add("Length", "12");
                this.columnsati10.ExtendedProperties.Add("Decimals", "2");
                this.columnsati10.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsati10.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsati10.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsati10.ExtendedProperties.Add("IsInReader", "true");
                this.columnsati10.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsati10.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsati10.ExtendedProperties.Add("Deklarit.InternalName", "sati10");
                this.Columns.Add(this.columnsati10);
                this.columnsati11 = new DataColumn("sati11", typeof(decimal), "", MappingType.Element);
                this.columnsati11.Caption = "sati11";
                this.columnsati11.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsati11.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsati11.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsati11.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsati11.ExtendedProperties.Add("IsKey", "false");
                this.columnsati11.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsati11.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsati11.ExtendedProperties.Add("Description", "sati11");
                this.columnsati11.ExtendedProperties.Add("Length", "12");
                this.columnsati11.ExtendedProperties.Add("Decimals", "2");
                this.columnsati11.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsati11.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsati11.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsati11.ExtendedProperties.Add("IsInReader", "true");
                this.columnsati11.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsati11.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsati11.ExtendedProperties.Add("Deklarit.InternalName", "sati11");
                this.Columns.Add(this.columnsati11);
                this.columnsati12 = new DataColumn("sati12", typeof(decimal), "", MappingType.Element);
                this.columnsati12.Caption = "sati12";
                this.columnsati12.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsati12.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsati12.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsati12.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsati12.ExtendedProperties.Add("IsKey", "false");
                this.columnsati12.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsati12.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsati12.ExtendedProperties.Add("Description", "sati12");
                this.columnsati12.ExtendedProperties.Add("Length", "12");
                this.columnsati12.ExtendedProperties.Add("Decimals", "2");
                this.columnsati12.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsati12.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsati12.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsati12.ExtendedProperties.Add("IsInReader", "true");
                this.columnsati12.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsati12.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsati12.ExtendedProperties.Add("Deklarit.InternalName", "sati12");
                this.Columns.Add(this.columnsati12);
                this.columnukupnosati = new DataColumn("ukupnosati", typeof(decimal), "", MappingType.Element);
                this.columnukupnosati.Caption = "ukupnosati";
                this.columnukupnosati.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnosati.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnosati.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnosati.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnosati.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnosati.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnosati.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnosati.ExtendedProperties.Add("Description", "ukupnosati");
                this.columnukupnosati.ExtendedProperties.Add("Length", "12");
                this.columnukupnosati.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnosati.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnosati.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnosati.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnosati.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnosati.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnosati.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnosati.ExtendedProperties.Add("Deklarit.InternalName", "ukupnosati");
                this.Columns.Add(this.columnukupnosati);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "sp_maticni_karton");
                this.ExtendedProperties.Add("Description", "_SP_MATICNI_KARTON");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columntip = this.Columns["tip"];
                this.columnopistip = this.Columns["opistip"];
                this.columnvrstavrij = this.Columns["vrstavrij"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnJMBG = this.Columns["JMBG"];
                this.columnidpodatka = this.Columns["idpodatka"];
                this.columnnazivpodatka = this.Columns["nazivpodatka"];
                this.columnmj01 = this.Columns["mj01"];
                this.columnmj02 = this.Columns["mj02"];
                this.columnmj03 = this.Columns["mj03"];
                this.columnmj04 = this.Columns["mj04"];
                this.columnmj05 = this.Columns["mj05"];
                this.columnmj06 = this.Columns["mj06"];
                this.columnmj07 = this.Columns["mj07"];
                this.columnmj08 = this.Columns["mj08"];
                this.columnmj09 = this.Columns["mj09"];
                this.columnmj10 = this.Columns["mj10"];
                this.columnmj11 = this.Columns["mj11"];
                this.columnmj12 = this.Columns["mj12"];
                this.columnUKUPNO = this.Columns["UKUPNO"];
                this.columnsati01 = this.Columns["sati01"];
                this.columnsati02 = this.Columns["sati02"];
                this.columnsati03 = this.Columns["sati03"];
                this.columnsati04 = this.Columns["sati04"];
                this.columnsati05 = this.Columns["sati05"];
                this.columnsati06 = this.Columns["sati06"];
                this.columnsati07 = this.Columns["sati07"];
                this.columnsati08 = this.Columns["sati08"];
                this.columnsati09 = this.Columns["sati09"];
                this.columnsati10 = this.Columns["sati10"];
                this.columnsati11 = this.Columns["sati11"];
                this.columnsati12 = this.Columns["sati12"];
                this.columnukupnosati = this.Columns["ukupnosati"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new sp_maticni_kartonDataSet.sp_maticni_kartonRow(builder);
            }

            public sp_maticni_kartonDataSet.sp_maticni_kartonRow Newsp_maticni_kartonRow()
            {
                return (sp_maticni_kartonDataSet.sp_maticni_kartonRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.sp_maticni_kartonRowChanged != null)
                {
                    sp_maticni_kartonDataSet.sp_maticni_kartonRowChangeEventHandler handler = this.sp_maticni_kartonRowChanged;
                    if (handler != null)
                    {
                        handler(this, new sp_maticni_kartonDataSet.sp_maticni_kartonRowChangeEvent((sp_maticni_kartonDataSet.sp_maticni_kartonRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.sp_maticni_kartonRowChanging != null)
                {
                    sp_maticni_kartonDataSet.sp_maticni_kartonRowChangeEventHandler handler = this.sp_maticni_kartonRowChanging;
                    if (handler != null)
                    {
                        handler(this, new sp_maticni_kartonDataSet.sp_maticni_kartonRowChangeEvent((sp_maticni_kartonDataSet.sp_maticni_kartonRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.sp_maticni_kartonRowDeleted != null)
                {
                    sp_maticni_kartonDataSet.sp_maticni_kartonRowChangeEventHandler handler = this.sp_maticni_kartonRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new sp_maticni_kartonDataSet.sp_maticni_kartonRowChangeEvent((sp_maticni_kartonDataSet.sp_maticni_kartonRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.sp_maticni_kartonRowDeleting != null)
                {
                    sp_maticni_kartonDataSet.sp_maticni_kartonRowChangeEventHandler handler = this.sp_maticni_kartonRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new sp_maticni_kartonDataSet.sp_maticni_kartonRowChangeEvent((sp_maticni_kartonDataSet.sp_maticni_kartonRow) e.Row, e.Action));
                    }
                }
            }

            public void Removesp_maticni_kartonRow(sp_maticni_kartonDataSet.sp_maticni_kartonRow row)
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

            public DataColumn idpodatkaColumn
            {
                get
                {
                    return this.columnidpodatka;
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

            public sp_maticni_kartonDataSet.sp_maticni_kartonRow this[int index]
            {
                get
                {
                    return (sp_maticni_kartonDataSet.sp_maticni_kartonRow) this.Rows[index];
                }
            }

            public DataColumn JMBGColumn
            {
                get
                {
                    return this.columnJMBG;
                }
            }

            public DataColumn mj01Column
            {
                get
                {
                    return this.columnmj01;
                }
            }

            public DataColumn mj02Column
            {
                get
                {
                    return this.columnmj02;
                }
            }

            public DataColumn mj03Column
            {
                get
                {
                    return this.columnmj03;
                }
            }

            public DataColumn mj04Column
            {
                get
                {
                    return this.columnmj04;
                }
            }

            public DataColumn mj05Column
            {
                get
                {
                    return this.columnmj05;
                }
            }

            public DataColumn mj06Column
            {
                get
                {
                    return this.columnmj06;
                }
            }

            public DataColumn mj07Column
            {
                get
                {
                    return this.columnmj07;
                }
            }

            public DataColumn mj08Column
            {
                get
                {
                    return this.columnmj08;
                }
            }

            public DataColumn mj09Column
            {
                get
                {
                    return this.columnmj09;
                }
            }

            public DataColumn mj10Column
            {
                get
                {
                    return this.columnmj10;
                }
            }

            public DataColumn mj11Column
            {
                get
                {
                    return this.columnmj11;
                }
            }

            public DataColumn mj12Column
            {
                get
                {
                    return this.columnmj12;
                }
            }

            public DataColumn nazivpodatkaColumn
            {
                get
                {
                    return this.columnnazivpodatka;
                }
            }

            public DataColumn opistipColumn
            {
                get
                {
                    return this.columnopistip;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn sati01Column
            {
                get
                {
                    return this.columnsati01;
                }
            }

            public DataColumn sati02Column
            {
                get
                {
                    return this.columnsati02;
                }
            }

            public DataColumn sati03Column
            {
                get
                {
                    return this.columnsati03;
                }
            }

            public DataColumn sati04Column
            {
                get
                {
                    return this.columnsati04;
                }
            }

            public DataColumn sati05Column
            {
                get
                {
                    return this.columnsati05;
                }
            }

            public DataColumn sati06Column
            {
                get
                {
                    return this.columnsati06;
                }
            }

            public DataColumn sati07Column
            {
                get
                {
                    return this.columnsati07;
                }
            }

            public DataColumn sati08Column
            {
                get
                {
                    return this.columnsati08;
                }
            }

            public DataColumn sati09Column
            {
                get
                {
                    return this.columnsati09;
                }
            }

            public DataColumn sati10Column
            {
                get
                {
                    return this.columnsati10;
                }
            }

            public DataColumn sati11Column
            {
                get
                {
                    return this.columnsati11;
                }
            }

            public DataColumn sati12Column
            {
                get
                {
                    return this.columnsati12;
                }
            }

            public DataColumn tipColumn
            {
                get
                {
                    return this.columntip;
                }
            }

            public DataColumn UKUPNOColumn
            {
                get
                {
                    return this.columnUKUPNO;
                }
            }

            public DataColumn ukupnosatiColumn
            {
                get
                {
                    return this.columnukupnosati;
                }
            }

            public DataColumn vrstavrijColumn
            {
                get
                {
                    return this.columnvrstavrij;
                }
            }
        }

        public class sp_maticni_kartonRow : DataRow
        {
            private sp_maticni_kartonDataSet.sp_maticni_kartonDataTable tablesp_maticni_karton;

            internal sp_maticni_kartonRow(DataRowBuilder rb) : base(rb)
            {
                this.tablesp_maticni_karton = (sp_maticni_kartonDataSet.sp_maticni_kartonDataTable) this.Table;
            }

            public bool IsidpodatkaNull()
            {
                return this.IsNull(this.tablesp_maticni_karton.idpodatkaColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tablesp_maticni_karton.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tablesp_maticni_karton.IMEColumn);
            }

            public bool IsJMBGNull()
            {
                return this.IsNull(this.tablesp_maticni_karton.JMBGColumn);
            }

            public bool Ismj01Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.mj01Column);
            }

            public bool Ismj02Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.mj02Column);
            }

            public bool Ismj03Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.mj03Column);
            }

            public bool Ismj04Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.mj04Column);
            }

            public bool Ismj05Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.mj05Column);
            }

            public bool Ismj06Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.mj06Column);
            }

            public bool Ismj07Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.mj07Column);
            }

            public bool Ismj08Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.mj08Column);
            }

            public bool Ismj09Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.mj09Column);
            }

            public bool Ismj10Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.mj10Column);
            }

            public bool Ismj11Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.mj11Column);
            }

            public bool Ismj12Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.mj12Column);
            }

            public bool IsnazivpodatkaNull()
            {
                return this.IsNull(this.tablesp_maticni_karton.nazivpodatkaColumn);
            }

            public bool IsopistipNull()
            {
                return this.IsNull(this.tablesp_maticni_karton.opistipColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tablesp_maticni_karton.PREZIMEColumn);
            }

            public bool Issati01Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.sati01Column);
            }

            public bool Issati02Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.sati02Column);
            }

            public bool Issati03Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.sati03Column);
            }

            public bool Issati04Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.sati04Column);
            }

            public bool Issati05Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.sati05Column);
            }

            public bool Issati06Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.sati06Column);
            }

            public bool Issati07Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.sati07Column);
            }

            public bool Issati08Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.sati08Column);
            }

            public bool Issati09Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.sati09Column);
            }

            public bool Issati10Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.sati10Column);
            }

            public bool Issati11Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.sati11Column);
            }

            public bool Issati12Null()
            {
                return this.IsNull(this.tablesp_maticni_karton.sati12Column);
            }

            public bool IstipNull()
            {
                return this.IsNull(this.tablesp_maticni_karton.tipColumn);
            }

            public bool IsUKUPNONull()
            {
                return this.IsNull(this.tablesp_maticni_karton.UKUPNOColumn);
            }

            public bool IsukupnosatiNull()
            {
                return this.IsNull(this.tablesp_maticni_karton.ukupnosatiColumn);
            }

            public bool IsvrstavrijNull()
            {
                return this.IsNull(this.tablesp_maticni_karton.vrstavrijColumn);
            }

            public void SetidpodatkaNull()
            {
                this[this.tablesp_maticni_karton.idpodatkaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tablesp_maticni_karton.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tablesp_maticni_karton.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGNull()
            {
                this[this.tablesp_maticni_karton.JMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setmj01Null()
            {
                this[this.tablesp_maticni_karton.mj01Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setmj02Null()
            {
                this[this.tablesp_maticni_karton.mj02Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setmj03Null()
            {
                this[this.tablesp_maticni_karton.mj03Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setmj04Null()
            {
                this[this.tablesp_maticni_karton.mj04Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setmj05Null()
            {
                this[this.tablesp_maticni_karton.mj05Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setmj06Null()
            {
                this[this.tablesp_maticni_karton.mj06Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setmj07Null()
            {
                this[this.tablesp_maticni_karton.mj07Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setmj08Null()
            {
                this[this.tablesp_maticni_karton.mj08Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setmj09Null()
            {
                this[this.tablesp_maticni_karton.mj09Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setmj10Null()
            {
                this[this.tablesp_maticni_karton.mj10Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setmj11Null()
            {
                this[this.tablesp_maticni_karton.mj11Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setmj12Null()
            {
                this[this.tablesp_maticni_karton.mj12Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnazivpodatkaNull()
            {
                this[this.tablesp_maticni_karton.nazivpodatkaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetopistipNull()
            {
                this[this.tablesp_maticni_karton.opistipColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tablesp_maticni_karton.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsati01Null()
            {
                this[this.tablesp_maticni_karton.sati01Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsati02Null()
            {
                this[this.tablesp_maticni_karton.sati02Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsati03Null()
            {
                this[this.tablesp_maticni_karton.sati03Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsati04Null()
            {
                this[this.tablesp_maticni_karton.sati04Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsati05Null()
            {
                this[this.tablesp_maticni_karton.sati05Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsati06Null()
            {
                this[this.tablesp_maticni_karton.sati06Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsati07Null()
            {
                this[this.tablesp_maticni_karton.sati07Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsati08Null()
            {
                this[this.tablesp_maticni_karton.sati08Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsati09Null()
            {
                this[this.tablesp_maticni_karton.sati09Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsati10Null()
            {
                this[this.tablesp_maticni_karton.sati10Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsati11Null()
            {
                this[this.tablesp_maticni_karton.sati11Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsati12Null()
            {
                this[this.tablesp_maticni_karton.sati12Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SettipNull()
            {
                this[this.tablesp_maticni_karton.tipColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNONull()
            {
                this[this.tablesp_maticni_karton.UKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnosatiNull()
            {
                this[this.tablesp_maticni_karton.ukupnosatiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetvrstavrijNull()
            {
                this[this.tablesp_maticni_karton.vrstavrijColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int idpodatka
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablesp_maticni_karton.idpodatkaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.idpodatkaColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablesp_maticni_karton.IDRADNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_maticni_karton.IMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_maticni_karton.IMEColumn] = value;
                }
            }

            public string JMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_maticni_karton.JMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_maticni_karton.JMBGColumn] = value;
                }
            }

            public decimal mj01
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.mj01Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.mj01Column] = value;
                }
            }

            public decimal mj02
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.mj02Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.mj02Column] = value;
                }
            }

            public decimal mj03
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.mj03Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.mj03Column] = value;
                }
            }

            public decimal mj04
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.mj04Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.mj04Column] = value;
                }
            }

            public decimal mj05
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.mj05Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.mj05Column] = value;
                }
            }

            public decimal mj06
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.mj06Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.mj06Column] = value;
                }
            }

            public decimal mj07
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.mj07Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.mj07Column] = value;
                }
            }

            public decimal mj08
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.mj08Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.mj08Column] = value;
                }
            }

            public decimal mj09
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.mj09Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.mj09Column] = value;
                }
            }

            public decimal mj10
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.mj10Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.mj10Column] = value;
                }
            }

            public decimal mj11
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.mj11Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.mj11Column] = value;
                }
            }

            public decimal mj12
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.mj12Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.mj12Column] = value;
                }
            }

            public string nazivpodatka
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_maticni_karton.nazivpodatkaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_maticni_karton.nazivpodatkaColumn] = value;
                }
            }

            public string opistip
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_maticni_karton.opistipColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_maticni_karton.opistipColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_maticni_karton.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_maticni_karton.PREZIMEColumn] = value;
                }
            }

            public decimal sati01
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.sati01Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.sati01Column] = value;
                }
            }

            public decimal sati02
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.sati02Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.sati02Column] = value;
                }
            }

            public decimal sati03
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.sati03Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.sati03Column] = value;
                }
            }

            public decimal sati04
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.sati04Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.sati04Column] = value;
                }
            }

            public decimal sati05
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.sati05Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.sati05Column] = value;
                }
            }

            public decimal sati06
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.sati06Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.sati06Column] = value;
                }
            }

            public decimal sati07
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.sati07Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.sati07Column] = value;
                }
            }

            public decimal sati08
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.sati08Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.sati08Column] = value;
                }
            }

            public decimal sati09
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.sati09Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.sati09Column] = value;
                }
            }

            public decimal sati10
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.sati10Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.sati10Column] = value;
                }
            }

            public decimal sati11
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.sati11Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.sati11Column] = value;
                }
            }

            public decimal sati12
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.sati12Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.sati12Column] = value;
                }
            }

            public int tip
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablesp_maticni_karton.tipColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.tipColumn] = value;
                }
            }

            public decimal UKUPNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.UKUPNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.UKUPNOColumn] = value;
                }
            }

            public decimal ukupnosati
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_maticni_karton.ukupnosatiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.ukupnosatiColumn] = value;
                }
            }

            public int vrstavrij
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablesp_maticni_karton.vrstavrijColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_maticni_karton.vrstavrijColumn] = value;
                }
            }
        }

        public class sp_maticni_kartonRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private sp_maticni_kartonDataSet.sp_maticni_kartonRow eventRow;

            public sp_maticni_kartonRowChangeEvent(sp_maticni_kartonDataSet.sp_maticni_kartonRow row, DataRowAction action)
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

            public sp_maticni_kartonDataSet.sp_maticni_kartonRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void sp_maticni_kartonRowChangeEventHandler(object sender, sp_maticni_kartonDataSet.sp_maticni_kartonRowChangeEvent e);
    }
}

