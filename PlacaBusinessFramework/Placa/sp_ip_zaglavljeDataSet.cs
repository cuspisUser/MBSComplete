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
    public class sp_ip_zaglavljeDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private sp_ip_zaglavljeDataTable tablesp_ip_zaglavlje;

        public sp_ip_zaglavljeDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected sp_ip_zaglavljeDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["sp_ip_zaglavlje"] != null)
                    {
                        this.Tables.Add(new sp_ip_zaglavljeDataTable(dataSet.Tables["sp_ip_zaglavlje"]));
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
            sp_ip_zaglavljeDataSet set = (sp_ip_zaglavljeDataSet) base.Clone();
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
            sp_ip_zaglavljeDataSet set = new sp_ip_zaglavljeDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "sp_ip_zaglavljeDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2036");
            this.ExtendedProperties.Add("DataSetName", "sp_ip_zaglavljeDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Isp_ip_zaglavljeDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "sp_ip_zaglavlje");
            this.ExtendedProperties.Add("ObjectDescription", "sp_ip_zaglavlje");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_IP");
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
            this.DataSetName = "sp_ip_zaglavljeDataSet";
            this.Namespace = "http://www.tempuri.org/sp_ip_zaglavlje";
            this.tablesp_ip_zaglavlje = new sp_ip_zaglavljeDataTable();
            this.Tables.Add(this.tablesp_ip_zaglavlje);
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
            this.tablesp_ip_zaglavlje = (sp_ip_zaglavljeDataTable) this.Tables["sp_ip_zaglavlje"];
            if (initTable && (this.tablesp_ip_zaglavlje != null))
            {
                this.tablesp_ip_zaglavlje.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["sp_ip_zaglavlje"] != null)
                {
                    this.Tables.Add(new sp_ip_zaglavljeDataTable(dataSet.Tables["sp_ip_zaglavlje"]));
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

        private bool ShouldSerializesp_ip_zaglavlje()
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
        public sp_ip_zaglavljeDataTable sp_ip_zaglavlje
        {
            get
            {
                return this.tablesp_ip_zaglavlje;
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
        public class sp_ip_zaglavljeDataTable : DataTable, IEnumerable
        {
            private DataColumn columnADRESA;
            private DataColumn columnIDIPIDENT;
            private DataColumn columnIME;
            private DataColumn columnisplataugodini;
            private DataColumn columnisplatazagodinu;
            private DataColumn columnJMBG;
            private DataColumn columnOIB;
            private DataColumn columnOZNACEN;
            private DataColumn columnPREZIME;

            public event sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRowChangeEventHandler sp_ip_zaglavljeRowChanged;

            public event sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRowChangeEventHandler sp_ip_zaglavljeRowChanging;

            public event sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRowChangeEventHandler sp_ip_zaglavljeRowDeleted;

            public event sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRowChangeEventHandler sp_ip_zaglavljeRowDeleting;

            public sp_ip_zaglavljeDataTable()
            {
                this.TableName = "sp_ip_zaglavlje";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal sp_ip_zaglavljeDataTable(DataTable table) : base(table.TableName)
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

            protected sp_ip_zaglavljeDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void Addsp_ip_zaglavljeRow(sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow row)
            {
                this.Rows.Add(row);
            }

            public sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow Addsp_ip_zaglavljeRow(bool oZNACEN, int iDIPIDENT, string jMBG, string pREZIME, string iME, string aDRESA, string isplataugodini, string isplatazagodinu, string oIB)
            {
                sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow row = (sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow) this.NewRow();
                row.ItemArray = new object[] { oZNACEN, iDIPIDENT, jMBG, pREZIME, iME, aDRESA, isplataugodini, isplatazagodinu, oIB };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                sp_ip_zaglavljeDataSet.sp_ip_zaglavljeDataTable table = (sp_ip_zaglavljeDataSet.sp_ip_zaglavljeDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                sp_ip_zaglavljeDataSet set = new sp_ip_zaglavljeDataSet();
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
                this.columnOZNACEN = new DataColumn("OZNACEN", typeof(bool), "", MappingType.Element);
                this.columnOZNACEN.Caption = "OZNACEN";
                this.columnOZNACEN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOZNACEN.ExtendedProperties.Add("IsKey", "false");
                this.columnOZNACEN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOZNACEN.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnOZNACEN.ExtendedProperties.Add("Description", "OZNACEN");
                this.columnOZNACEN.ExtendedProperties.Add("Length", "1");
                this.columnOZNACEN.ExtendedProperties.Add("Decimals", "0");
                this.columnOZNACEN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOZNACEN.ExtendedProperties.Add("IsInReader", "true");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOZNACEN.ExtendedProperties.Add("Deklarit.InternalName", "OZNACEN");
                this.Columns.Add(this.columnOZNACEN);
                this.columnIDIPIDENT = new DataColumn("IDIPIDENT", typeof(int), "", MappingType.Element);
                this.columnIDIPIDENT.Caption = "IDIPIDENT";
                this.columnIDIPIDENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("IsKey", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDIPIDENT.ExtendedProperties.Add("Description", "IDIPIDENT");
                this.columnIDIPIDENT.ExtendedProperties.Add("Length", "5");
                this.columnIDIPIDENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDIPIDENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.InternalName", "IDIPIDENT");
                this.Columns.Add(this.columnIDIPIDENT);
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
                this.columnADRESA = new DataColumn("ADRESA", typeof(string), "", MappingType.Element);
                this.columnADRESA.Caption = "Adresa";
                this.columnADRESA.MaxLength = 150;
                this.columnADRESA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnADRESA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnADRESA.ExtendedProperties.Add("IsKey", "false");
                this.columnADRESA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnADRESA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnADRESA.ExtendedProperties.Add("Description", "Adresa");
                this.columnADRESA.ExtendedProperties.Add("Length", "150");
                this.columnADRESA.ExtendedProperties.Add("Decimals", "0");
                this.columnADRESA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnADRESA.ExtendedProperties.Add("IsInReader", "true");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnADRESA.ExtendedProperties.Add("Deklarit.InternalName", "ADRESA");
                this.Columns.Add(this.columnADRESA);
                this.columnisplataugodini = new DataColumn("isplataugodini", typeof(string), "", MappingType.Element);
                this.columnisplataugodini.Caption = "isplataugodini";
                this.columnisplataugodini.MaxLength = 4;
                this.columnisplataugodini.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnisplataugodini.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnisplataugodini.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnisplataugodini.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnisplataugodini.ExtendedProperties.Add("IsKey", "false");
                this.columnisplataugodini.ExtendedProperties.Add("ReadOnly", "true");
                this.columnisplataugodini.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnisplataugodini.ExtendedProperties.Add("Description", "isplataugodini");
                this.columnisplataugodini.ExtendedProperties.Add("Length", "4");
                this.columnisplataugodini.ExtendedProperties.Add("Decimals", "0");
                this.columnisplataugodini.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnisplataugodini.ExtendedProperties.Add("IsInReader", "true");
                this.columnisplataugodini.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnisplataugodini.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnisplataugodini.ExtendedProperties.Add("Deklarit.InternalName", "isplataugodini");
                this.Columns.Add(this.columnisplataugodini);
                this.columnisplatazagodinu = new DataColumn("isplatazagodinu", typeof(string), "", MappingType.Element);
                this.columnisplatazagodinu.Caption = "isplatazagodinu";
                this.columnisplatazagodinu.MaxLength = 4;
                this.columnisplatazagodinu.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnisplatazagodinu.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnisplatazagodinu.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnisplatazagodinu.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnisplatazagodinu.ExtendedProperties.Add("IsKey", "false");
                this.columnisplatazagodinu.ExtendedProperties.Add("ReadOnly", "true");
                this.columnisplatazagodinu.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnisplatazagodinu.ExtendedProperties.Add("Description", "isplatazagodinu");
                this.columnisplatazagodinu.ExtendedProperties.Add("Length", "4");
                this.columnisplatazagodinu.ExtendedProperties.Add("Decimals", "0");
                this.columnisplatazagodinu.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnisplatazagodinu.ExtendedProperties.Add("IsInReader", "true");
                this.columnisplatazagodinu.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnisplatazagodinu.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnisplatazagodinu.ExtendedProperties.Add("Deklarit.InternalName", "isplatazagodinu");
                this.Columns.Add(this.columnisplatazagodinu);
                this.columnOIB = new DataColumn("OIB", typeof(string), "", MappingType.Element);
                this.columnOIB.Caption = "OIB";
                this.columnOIB.MaxLength = 11;
                this.columnOIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOIB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOIB.ExtendedProperties.Add("IsKey", "false");
                this.columnOIB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOIB.ExtendedProperties.Add("Description", "OIB");
                this.columnOIB.ExtendedProperties.Add("Length", "11");
                this.columnOIB.ExtendedProperties.Add("Decimals", "0");
                this.columnOIB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOIB.ExtendedProperties.Add("Deklarit.InternalName", "OIB");
                this.Columns.Add(this.columnOIB);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "sp_ip_zaglavlje");
                this.ExtendedProperties.Add("Description", "SP_IP_ZAGLAVLJE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnOZNACEN = this.Columns["OZNACEN"];
                this.columnIDIPIDENT = this.Columns["IDIPIDENT"];
                this.columnJMBG = this.Columns["JMBG"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnADRESA = this.Columns["ADRESA"];
                this.columnisplataugodini = this.Columns["isplataugodini"];
                this.columnisplatazagodinu = this.Columns["isplatazagodinu"];
                this.columnOIB = this.Columns["OIB"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow(builder);
            }

            public sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow Newsp_ip_zaglavljeRow()
            {
                return (sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.sp_ip_zaglavljeRowChanged != null)
                {
                    sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRowChangeEventHandler handler = this.sp_ip_zaglavljeRowChanged;
                    if (handler != null)
                    {
                        handler(this, new sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRowChangeEvent((sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.sp_ip_zaglavljeRowChanging != null)
                {
                    sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRowChangeEventHandler handler = this.sp_ip_zaglavljeRowChanging;
                    if (handler != null)
                    {
                        handler(this, new sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRowChangeEvent((sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.sp_ip_zaglavljeRowDeleted != null)
                {
                    sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRowChangeEventHandler handler = this.sp_ip_zaglavljeRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRowChangeEvent((sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.sp_ip_zaglavljeRowDeleting != null)
                {
                    sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRowChangeEventHandler handler = this.sp_ip_zaglavljeRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRowChangeEvent((sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow) e.Row, e.Action));
                    }
                }
            }

            public void Removesp_ip_zaglavljeRow(sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn ADRESAColumn
            {
                get
                {
                    return this.columnADRESA;
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

            public DataColumn IDIPIDENTColumn
            {
                get
                {
                    return this.columnIDIPIDENT;
                }
            }

            public DataColumn IMEColumn
            {
                get
                {
                    return this.columnIME;
                }
            }

            public DataColumn isplataugodiniColumn
            {
                get
                {
                    return this.columnisplataugodini;
                }
            }

            public DataColumn isplatazagodinuColumn
            {
                get
                {
                    return this.columnisplatazagodinu;
                }
            }

            public sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow this[int index]
            {
                get
                {
                    return (sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow) this.Rows[index];
                }
            }

            public DataColumn JMBGColumn
            {
                get
                {
                    return this.columnJMBG;
                }
            }

            public DataColumn OIBColumn
            {
                get
                {
                    return this.columnOIB;
                }
            }

            public DataColumn OZNACENColumn
            {
                get
                {
                    return this.columnOZNACEN;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }
        }

        public class sp_ip_zaglavljeRow : DataRow
        {
            private sp_ip_zaglavljeDataSet.sp_ip_zaglavljeDataTable tablesp_ip_zaglavlje;

            internal sp_ip_zaglavljeRow(DataRowBuilder rb) : base(rb)
            {
                this.tablesp_ip_zaglavlje = (sp_ip_zaglavljeDataSet.sp_ip_zaglavljeDataTable) this.Table;
            }

            public bool IsADRESANull()
            {
                return this.IsNull(this.tablesp_ip_zaglavlje.ADRESAColumn);
            }

            public bool IsIDIPIDENTNull()
            {
                return this.IsNull(this.tablesp_ip_zaglavlje.IDIPIDENTColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tablesp_ip_zaglavlje.IMEColumn);
            }

            public bool IsisplataugodiniNull()
            {
                return this.IsNull(this.tablesp_ip_zaglavlje.isplataugodiniColumn);
            }

            public bool IsisplatazagodinuNull()
            {
                return this.IsNull(this.tablesp_ip_zaglavlje.isplatazagodinuColumn);
            }

            public bool IsJMBGNull()
            {
                return this.IsNull(this.tablesp_ip_zaglavlje.JMBGColumn);
            }

            public bool IsOIBNull()
            {
                return this.IsNull(this.tablesp_ip_zaglavlje.OIBColumn);
            }

            public bool IsOZNACENNull()
            {
                return this.IsNull(this.tablesp_ip_zaglavlje.OZNACENColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tablesp_ip_zaglavlje.PREZIMEColumn);
            }

            public void SetADRESANull()
            {
                this[this.tablesp_ip_zaglavlje.ADRESAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDIPIDENTNull()
            {
                this[this.tablesp_ip_zaglavlje.IDIPIDENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tablesp_ip_zaglavlje.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetisplataugodiniNull()
            {
                this[this.tablesp_ip_zaglavlje.isplataugodiniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetisplatazagodinuNull()
            {
                this[this.tablesp_ip_zaglavlje.isplatazagodinuColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGNull()
            {
                this[this.tablesp_ip_zaglavlje.JMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOIBNull()
            {
                this[this.tablesp_ip_zaglavlje.OIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOZNACENNull()
            {
                this[this.tablesp_ip_zaglavlje.OZNACENColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tablesp_ip_zaglavlje.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string ADRESA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_ip_zaglavlje.ADRESAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ADRESA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_ip_zaglavlje.ADRESAColumn] = value;
                }
            }

            public int IDIPIDENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablesp_ip_zaglavlje.IDIPIDENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDIPIDENT because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_ip_zaglavlje.IDIPIDENTColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_ip_zaglavlje.IMEColumn]);
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
                    this[this.tablesp_ip_zaglavlje.IMEColumn] = value;
                }
            }

            public string isplataugodini
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_ip_zaglavlje.isplataugodiniColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value isplataugodini because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_ip_zaglavlje.isplataugodiniColumn] = value;
                }
            }

            public string isplatazagodinu
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_ip_zaglavlje.isplatazagodinuColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value isplatazagodinu because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_ip_zaglavlje.isplatazagodinuColumn] = value;
                }
            }

            public string JMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_ip_zaglavlje.JMBGColumn]);
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
                    this[this.tablesp_ip_zaglavlje.JMBGColumn] = value;
                }
            }

            public string OIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_ip_zaglavlje.OIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OIB because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_ip_zaglavlje.OIBColumn] = value;
                }
            }

            public bool OZNACEN
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tablesp_ip_zaglavlje.OZNACENColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OZNACEN because it is DBNull.", innerException);
                    }
                    return flag;
                }
                set
                {
                    this[this.tablesp_ip_zaglavlje.OZNACENColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_ip_zaglavlje.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PREZIME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_ip_zaglavlje.PREZIMEColumn] = value;
                }
            }
        }

        public class sp_ip_zaglavljeRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow eventRow;

            public sp_ip_zaglavljeRowChangeEvent(sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow row, DataRowAction action)
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

            public sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void sp_ip_zaglavljeRowChangeEventHandler(object sender, sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRowChangeEvent e);
    }
}

