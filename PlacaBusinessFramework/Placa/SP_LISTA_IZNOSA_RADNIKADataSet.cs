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
    public class SP_LISTA_IZNOSA_RADNIKADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private SP_LISTA_IZNOSA_RADNIKADataTable tableSP_LISTA_IZNOSA_RADNIKA;

        public SP_LISTA_IZNOSA_RADNIKADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected SP_LISTA_IZNOSA_RADNIKADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["SP_LISTA_IZNOSA_RADNIKA"] != null)
                    {
                        this.Tables.Add(new SP_LISTA_IZNOSA_RADNIKADataTable(dataSet.Tables["SP_LISTA_IZNOSA_RADNIKA"]));
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
            SP_LISTA_IZNOSA_RADNIKADataSet set = (SP_LISTA_IZNOSA_RADNIKADataSet) base.Clone();
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
            SP_LISTA_IZNOSA_RADNIKADataSet set = new SP_LISTA_IZNOSA_RADNIKADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "SP_LISTA_IZNOSA_RADNIKADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2033");
            this.ExtendedProperties.Add("DataSetName", "SP_LISTA_IZNOSA_RADNIKADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ISP_LISTA_IZNOSA_RADNIKADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "SP_LISTA_IZNOSA_RADNIKA");
            this.ExtendedProperties.Add("ObjectDescription", "SP_LISTA_IZNOSA_RADNIKA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_IZNOSI_PO_ZAPOSLENIKU");
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
            this.DataSetName = "SP_LISTA_IZNOSA_RADNIKADataSet";
            this.Namespace = "http://www.tempuri.org/SP_LISTA_IZNOSA_RADNIKA";
            this.tableSP_LISTA_IZNOSA_RADNIKA = new SP_LISTA_IZNOSA_RADNIKADataTable();
            this.Tables.Add(this.tableSP_LISTA_IZNOSA_RADNIKA);
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
            this.tableSP_LISTA_IZNOSA_RADNIKA = (SP_LISTA_IZNOSA_RADNIKADataTable) this.Tables["SP_LISTA_IZNOSA_RADNIKA"];
            if (initTable && (this.tableSP_LISTA_IZNOSA_RADNIKA != null))
            {
                this.tableSP_LISTA_IZNOSA_RADNIKA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["SP_LISTA_IZNOSA_RADNIKA"] != null)
                {
                    this.Tables.Add(new SP_LISTA_IZNOSA_RADNIKADataTable(dataSet.Tables["SP_LISTA_IZNOSA_RADNIKA"]));
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

        private bool ShouldSerializeSP_LISTA_IZNOSA_RADNIKA()
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
        public SP_LISTA_IZNOSA_RADNIKADataTable SP_LISTA_IZNOSA_RADNIKA
        {
            get
            {
                return this.tableSP_LISTA_IZNOSA_RADNIKA;
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
        public class SP_LISTA_IZNOSA_RADNIKADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnKOEFICIJENT;
            private DataColumn columnnetoplaca;
            private DataColumn columnnetoplacamanjekrizni;
            private DataColumn columnnetoprimanja;
            private DataColumn columnPOREZKRIZNI;
            private DataColumn columnPREZIME;
            private DataColumn columnsatibruto;
            private DataColumn columnukupnobruto;
            private DataColumn columnukupnodoprinosi;
            private DataColumn columnUKUPNODOPRINOSINA;
            private DataColumn columnukupnonetonaknade;
            private DataColumn columnukupnoobustave;
            private DataColumn columnukupnoolaksice;
            private DataColumn columnukupnoporeziprirez;
            private DataColumn columnUKUPNOZAISPLATU;

            public event SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARowChangeEventHandler SP_LISTA_IZNOSA_RADNIKARowChanged;

            public event SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARowChangeEventHandler SP_LISTA_IZNOSA_RADNIKARowChanging;

            public event SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARowChangeEventHandler SP_LISTA_IZNOSA_RADNIKARowDeleted;

            public event SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARowChangeEventHandler SP_LISTA_IZNOSA_RADNIKARowDeleting;

            public SP_LISTA_IZNOSA_RADNIKADataTable()
            {
                this.TableName = "SP_LISTA_IZNOSA_RADNIKA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SP_LISTA_IZNOSA_RADNIKADataTable(DataTable table) : base(table.TableName)
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

            protected SP_LISTA_IZNOSA_RADNIKADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSP_LISTA_IZNOSA_RADNIKARow(SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow row)
            {
                this.Rows.Add(row);
            }

            public SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow AddSP_LISTA_IZNOSA_RADNIKARow(int iDRADNIK, string pREZIME, string iME, decimal satibruto, decimal ukupnobruto, decimal kOEFICIJENT, decimal ukupnodoprinosi, decimal ukupnoporeziprirez, decimal netoplaca, decimal ukupnonetonaknade, decimal netoprimanja, decimal ukupnoobustave, decimal uKUPNOZAISPLATU, decimal ukupnoolaksice, decimal uKUPNODOPRINOSINA, decimal pOREZKRIZNI, decimal netoplacamanjekrizni)
            {
                SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow row = (SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow) this.NewRow();
                row.ItemArray = new object[] { 
                    iDRADNIK, pREZIME, iME, satibruto, ukupnobruto, kOEFICIJENT, ukupnodoprinosi, ukupnoporeziprirez, netoplaca, ukupnonetonaknade, netoprimanja, ukupnoobustave, uKUPNOZAISPLATU, ukupnoolaksice, uKUPNODOPRINOSINA, pOREZKRIZNI, 
                    netoplacamanjekrizni
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKADataTable table = (SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SP_LISTA_IZNOSA_RADNIKADataSet set = new SP_LISTA_IZNOSA_RADNIKADataSet();
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
                this.columnsatibruto = new DataColumn("satibruto", typeof(decimal), "", MappingType.Element);
                this.columnsatibruto.Caption = "satibruto";
                this.columnsatibruto.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsatibruto.ExtendedProperties.Add("IsKey", "false");
                this.columnsatibruto.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsatibruto.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsatibruto.ExtendedProperties.Add("Description", "satibruto");
                this.columnsatibruto.ExtendedProperties.Add("Length", "12");
                this.columnsatibruto.ExtendedProperties.Add("Decimals", "2");
                this.columnsatibruto.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsatibruto.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsatibruto.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsatibruto.ExtendedProperties.Add("IsInReader", "true");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.InternalName", "satibruto");
                this.Columns.Add(this.columnsatibruto);
                this.columnukupnobruto = new DataColumn("ukupnobruto", typeof(decimal), "", MappingType.Element);
                this.columnukupnobruto.Caption = "ukupnobruto";
                this.columnukupnobruto.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnobruto.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnobruto.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnobruto.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnobruto.ExtendedProperties.Add("Description", "ukupnobruto");
                this.columnukupnobruto.ExtendedProperties.Add("Length", "12");
                this.columnukupnobruto.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnobruto.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnobruto.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnobruto.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnobruto.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.InternalName", "ukupnobruto");
                this.Columns.Add(this.columnukupnobruto);
                this.columnKOEFICIJENT = new DataColumn("KOEFICIJENT", typeof(decimal), "", MappingType.Element);
                this.columnKOEFICIJENT.Caption = "Koeficijent";
                this.columnKOEFICIJENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOEFICIJENT.ExtendedProperties.Add("IsKey", "false");
                this.columnKOEFICIJENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOEFICIJENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Description", "Koeficijent");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Length", "17");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Decimals", "10");
                this.columnKOEFICIJENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKOEFICIJENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.InternalName", "KOEFICIJENT");
                this.Columns.Add(this.columnKOEFICIJENT);
                this.columnukupnodoprinosi = new DataColumn("ukupnodoprinosi", typeof(decimal), "", MappingType.Element);
                this.columnukupnodoprinosi.Caption = "ukupnodoprinosi";
                this.columnukupnodoprinosi.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnodoprinosi.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnodoprinosi.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnodoprinosi.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Description", "ukupnodoprinosi");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Length", "12");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnodoprinosi.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnodoprinosi.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnodoprinosi.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnodoprinosi.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.InternalName", "ukupnodoprinosi");
                this.Columns.Add(this.columnukupnodoprinosi);
                this.columnukupnoporeziprirez = new DataColumn("ukupnoporeziprirez", typeof(decimal), "", MappingType.Element);
                this.columnukupnoporeziprirez.Caption = "ukupnoporeziprirez";
                this.columnukupnoporeziprirez.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Description", "ukupnoporeziprirez");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Length", "12");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnoporeziprirez.ExtendedProperties.Add("Deklarit.InternalName", "ukupnoporeziprirez");
                this.Columns.Add(this.columnukupnoporeziprirez);
                this.columnnetoplaca = new DataColumn("netoplaca", typeof(decimal), "", MappingType.Element);
                this.columnnetoplaca.Caption = "netoplaca";
                this.columnnetoplaca.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnetoplaca.ExtendedProperties.Add("IsKey", "false");
                this.columnnetoplaca.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnetoplaca.ExtendedProperties.Add("DeklaritType", "int");
                this.columnnetoplaca.ExtendedProperties.Add("Description", "netoplaca");
                this.columnnetoplaca.ExtendedProperties.Add("Length", "12");
                this.columnnetoplaca.ExtendedProperties.Add("Decimals", "2");
                this.columnnetoplaca.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnnetoplaca.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnnetoplaca.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnetoplaca.ExtendedProperties.Add("IsInReader", "true");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.InternalName", "netoplaca");
                this.Columns.Add(this.columnnetoplaca);
                this.columnukupnonetonaknade = new DataColumn("ukupnonetonaknade", typeof(decimal), "", MappingType.Element);
                this.columnukupnonetonaknade.Caption = "ukupnonetonaknade";
                this.columnukupnonetonaknade.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnonetonaknade.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnonetonaknade.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnonetonaknade.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnonetonaknade.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnonetonaknade.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnonetonaknade.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnonetonaknade.ExtendedProperties.Add("Description", "ukupnonetonaknade");
                this.columnukupnonetonaknade.ExtendedProperties.Add("Length", "12");
                this.columnukupnonetonaknade.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnonetonaknade.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnonetonaknade.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnonetonaknade.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnonetonaknade.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnonetonaknade.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnonetonaknade.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnonetonaknade.ExtendedProperties.Add("Deklarit.InternalName", "ukupnonetonaknade");
                this.Columns.Add(this.columnukupnonetonaknade);
                this.columnnetoprimanja = new DataColumn("netoprimanja", typeof(decimal), "", MappingType.Element);
                this.columnnetoprimanja.Caption = "netoprimanja";
                this.columnnetoprimanja.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnetoprimanja.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnetoprimanja.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnetoprimanja.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnetoprimanja.ExtendedProperties.Add("IsKey", "false");
                this.columnnetoprimanja.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnetoprimanja.ExtendedProperties.Add("DeklaritType", "int");
                this.columnnetoprimanja.ExtendedProperties.Add("Description", "netoprimanja");
                this.columnnetoprimanja.ExtendedProperties.Add("Length", "12");
                this.columnnetoprimanja.ExtendedProperties.Add("Decimals", "2");
                this.columnnetoprimanja.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnnetoprimanja.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnnetoprimanja.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnetoprimanja.ExtendedProperties.Add("IsInReader", "true");
                this.columnnetoprimanja.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnetoprimanja.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnetoprimanja.ExtendedProperties.Add("Deklarit.InternalName", "netoprimanja");
                this.Columns.Add(this.columnnetoprimanja);
                this.columnukupnoobustave = new DataColumn("ukupnoobustave", typeof(decimal), "", MappingType.Element);
                this.columnukupnoobustave.Caption = "ukupnoobustave";
                this.columnukupnoobustave.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnoobustave.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnoobustave.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnoobustave.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnoobustave.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnoobustave.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnoobustave.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnoobustave.ExtendedProperties.Add("Description", "ukupnoobustave");
                this.columnukupnoobustave.ExtendedProperties.Add("Length", "12");
                this.columnukupnoobustave.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnoobustave.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnoobustave.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnoobustave.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnoobustave.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnoobustave.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnoobustave.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnoobustave.ExtendedProperties.Add("Deklarit.InternalName", "ukupnoobustave");
                this.Columns.Add(this.columnukupnoobustave);
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
                this.columnukupnoolaksice = new DataColumn("ukupnoolaksice", typeof(decimal), "", MappingType.Element);
                this.columnukupnoolaksice.Caption = "ukupnoolaksice";
                this.columnukupnoolaksice.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnoolaksice.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnoolaksice.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnoolaksice.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnoolaksice.ExtendedProperties.Add("Description", "ukupnoolaksice");
                this.columnukupnoolaksice.ExtendedProperties.Add("Length", "12");
                this.columnukupnoolaksice.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnoolaksice.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnoolaksice.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnoolaksice.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnoolaksice.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.InternalName", "ukupnoolaksice");
                this.Columns.Add(this.columnukupnoolaksice);
                this.columnUKUPNODOPRINOSINA = new DataColumn("UKUPNODOPRINOSINA", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNODOPRINOSINA.Caption = "UKUPNODOPRINOSINA";
                this.columnUKUPNODOPRINOSINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Description", "UKUPNODOPRINOSINA");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNODOPRINOSINA.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNODOPRINOSINA");
                this.Columns.Add(this.columnUKUPNODOPRINOSINA);
                this.columnPOREZKRIZNI = new DataColumn("POREZKRIZNI", typeof(decimal), "", MappingType.Element);
                this.columnPOREZKRIZNI.Caption = "POREZKRIZNI";
                this.columnPOREZKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Description", "POREZKRIZNI");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Length", "12");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "POREZKRIZNI");
                this.Columns.Add(this.columnPOREZKRIZNI);
                this.columnnetoplacamanjekrizni = new DataColumn("netoplacamanjekrizni", typeof(decimal), "", MappingType.Element);
                this.columnnetoplacamanjekrizni.Caption = "netoplacamanjekrizni";
                this.columnnetoplacamanjekrizni.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("IsKey", "false");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("DeklaritType", "int");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("Description", "netoplacamanjekrizni");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("Length", "12");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("Decimals", "2");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("IsInReader", "true");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnetoplacamanjekrizni.ExtendedProperties.Add("Deklarit.InternalName", "netoplacamanjekrizni");
                this.Columns.Add(this.columnnetoplacamanjekrizni);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "SP_LISTA_IZNOSA_RADNIKA");
                this.ExtendedProperties.Add("Description", "SP_LISTA_IZNOSA_RADNIKA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnsatibruto = this.Columns["satibruto"];
                this.columnukupnobruto = this.Columns["ukupnobruto"];
                this.columnKOEFICIJENT = this.Columns["KOEFICIJENT"];
                this.columnukupnodoprinosi = this.Columns["ukupnodoprinosi"];
                this.columnukupnoporeziprirez = this.Columns["ukupnoporeziprirez"];
                this.columnnetoplaca = this.Columns["netoplaca"];
                this.columnukupnonetonaknade = this.Columns["ukupnonetonaknade"];
                this.columnnetoprimanja = this.Columns["netoprimanja"];
                this.columnukupnoobustave = this.Columns["ukupnoobustave"];
                this.columnUKUPNOZAISPLATU = this.Columns["UKUPNOZAISPLATU"];
                this.columnukupnoolaksice = this.Columns["ukupnoolaksice"];
                this.columnUKUPNODOPRINOSINA = this.Columns["UKUPNODOPRINOSINA"];
                this.columnPOREZKRIZNI = this.Columns["POREZKRIZNI"];
                this.columnnetoplacamanjekrizni = this.Columns["netoplacamanjekrizni"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow(builder);
            }

            public SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow NewSP_LISTA_IZNOSA_RADNIKARow()
            {
                return (SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SP_LISTA_IZNOSA_RADNIKARowChanged != null)
                {
                    SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARowChangeEventHandler handler = this.SP_LISTA_IZNOSA_RADNIKARowChanged;
                    if (handler != null)
                    {
                        handler(this, new SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARowChangeEvent((SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SP_LISTA_IZNOSA_RADNIKARowChanging != null)
                {
                    SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARowChangeEventHandler handler = this.SP_LISTA_IZNOSA_RADNIKARowChanging;
                    if (handler != null)
                    {
                        handler(this, new SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARowChangeEvent((SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SP_LISTA_IZNOSA_RADNIKARowDeleted != null)
                {
                    SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARowChangeEventHandler handler = this.SP_LISTA_IZNOSA_RADNIKARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARowChangeEvent((SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SP_LISTA_IZNOSA_RADNIKARowDeleting != null)
                {
                    SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARowChangeEventHandler handler = this.SP_LISTA_IZNOSA_RADNIKARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARowChangeEvent((SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSP_LISTA_IZNOSA_RADNIKARow(SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow row)
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

            public SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow this[int index]
            {
                get
                {
                    return (SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow) this.Rows[index];
                }
            }

            public DataColumn KOEFICIJENTColumn
            {
                get
                {
                    return this.columnKOEFICIJENT;
                }
            }

            public DataColumn netoplacaColumn
            {
                get
                {
                    return this.columnnetoplaca;
                }
            }

            public DataColumn netoplacamanjekrizniColumn
            {
                get
                {
                    return this.columnnetoplacamanjekrizni;
                }
            }

            public DataColumn netoprimanjaColumn
            {
                get
                {
                    return this.columnnetoprimanja;
                }
            }

            public DataColumn POREZKRIZNIColumn
            {
                get
                {
                    return this.columnPOREZKRIZNI;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn satibrutoColumn
            {
                get
                {
                    return this.columnsatibruto;
                }
            }

            public DataColumn ukupnobrutoColumn
            {
                get
                {
                    return this.columnukupnobruto;
                }
            }

            public DataColumn ukupnodoprinosiColumn
            {
                get
                {
                    return this.columnukupnodoprinosi;
                }
            }

            public DataColumn UKUPNODOPRINOSINAColumn
            {
                get
                {
                    return this.columnUKUPNODOPRINOSINA;
                }
            }

            public DataColumn ukupnonetonaknadeColumn
            {
                get
                {
                    return this.columnukupnonetonaknade;
                }
            }

            public DataColumn ukupnoobustaveColumn
            {
                get
                {
                    return this.columnukupnoobustave;
                }
            }

            public DataColumn ukupnoolaksiceColumn
            {
                get
                {
                    return this.columnukupnoolaksice;
                }
            }

            public DataColumn ukupnoporeziprirezColumn
            {
                get
                {
                    return this.columnukupnoporeziprirez;
                }
            }

            public DataColumn UKUPNOZAISPLATUColumn
            {
                get
                {
                    return this.columnUKUPNOZAISPLATU;
                }
            }
        }

        public class SP_LISTA_IZNOSA_RADNIKARow : DataRow
        {
            private SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKADataTable tableSP_LISTA_IZNOSA_RADNIKA;

            internal SP_LISTA_IZNOSA_RADNIKARow(DataRowBuilder rb) : base(rb)
            {
                this.tableSP_LISTA_IZNOSA_RADNIKA = (SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKADataTable) this.Table;
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.IMEColumn);
            }

            public bool IsKOEFICIJENTNull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.KOEFICIJENTColumn);
            }

            public bool IsnetoplacamanjekrizniNull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.netoplacamanjekrizniColumn);
            }

            public bool IsnetoplacaNull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.netoplacaColumn);
            }

            public bool IsnetoprimanjaNull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.netoprimanjaColumn);
            }

            public bool IsPOREZKRIZNINull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.POREZKRIZNIColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.PREZIMEColumn);
            }

            public bool IssatibrutoNull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.satibrutoColumn);
            }

            public bool IsukupnobrutoNull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnobrutoColumn);
            }

            public bool IsUKUPNODOPRINOSINANull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.UKUPNODOPRINOSINAColumn);
            }

            public bool IsukupnodoprinosiNull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnodoprinosiColumn);
            }

            public bool IsukupnonetonaknadeNull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnonetonaknadeColumn);
            }

            public bool IsukupnoobustaveNull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnoobustaveColumn);
            }

            public bool IsukupnoolaksiceNull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnoolaksiceColumn);
            }

            public bool IsukupnoporeziprirezNull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnoporeziprirezColumn);
            }

            public bool IsUKUPNOZAISPLATUNull()
            {
                return this.IsNull(this.tableSP_LISTA_IZNOSA_RADNIKA.UKUPNOZAISPLATUColumn);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOEFICIJENTNull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.KOEFICIJENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoplacamanjekrizniNull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.netoplacamanjekrizniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoplacaNull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.netoplacaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoprimanjaNull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.netoprimanjaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZKRIZNINull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.POREZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetsatibrutoNull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.satibrutoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnobrutoNull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnobrutoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNODOPRINOSINANull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.UKUPNODOPRINOSINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnodoprinosiNull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnodoprinosiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnonetonaknadeNull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnonetonaknadeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnoobustaveNull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnoobustaveColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnoolaksiceNull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnoolaksiceColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnoporeziprirezNull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnoporeziprirezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOZAISPLATUNull()
            {
                this[this.tableSP_LISTA_IZNOSA_RADNIKA.UKUPNOZAISPLATUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSP_LISTA_IZNOSA_RADNIKA.IDRADNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSP_LISTA_IZNOSA_RADNIKA.IMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.IMEColumn] = value;
                }
            }

            public decimal KOEFICIJENT
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.KOEFICIJENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.KOEFICIJENTColumn] = value;
                }
            }

            public decimal netoplaca
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.netoplacaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.netoplacaColumn] = value;
                }
            }

            public decimal netoplacamanjekrizni
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.netoplacamanjekrizniColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.netoplacamanjekrizniColumn] = value;
                }
            }

            public decimal netoprimanja
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.netoprimanjaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.netoprimanjaColumn] = value;
                }
            }

            public decimal POREZKRIZNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.POREZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.POREZKRIZNIColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSP_LISTA_IZNOSA_RADNIKA.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.PREZIMEColumn] = value;
                }
            }

            public decimal satibruto
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.satibrutoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.satibrutoColumn] = value;
                }
            }

            public decimal ukupnobruto
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnobrutoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnobrutoColumn] = value;
                }
            }

            public decimal ukupnodoprinosi
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnodoprinosiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnodoprinosiColumn] = value;
                }
            }

            public decimal UKUPNODOPRINOSINA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.UKUPNODOPRINOSINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.UKUPNODOPRINOSINAColumn] = value;
                }
            }

            public decimal ukupnonetonaknade
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnonetonaknadeColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnonetonaknadeColumn] = value;
                }
            }

            public decimal ukupnoobustave
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnoobustaveColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnoobustaveColumn] = value;
                }
            }

            public decimal ukupnoolaksice
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnoolaksiceColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnoolaksiceColumn] = value;
                }
            }

            public decimal ukupnoporeziprirez
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnoporeziprirezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.ukupnoporeziprirezColumn] = value;
                }
            }

            public decimal UKUPNOZAISPLATU
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSP_LISTA_IZNOSA_RADNIKA.UKUPNOZAISPLATUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSP_LISTA_IZNOSA_RADNIKA.UKUPNOZAISPLATUColumn] = value;
                }
            }
        }

        public class SP_LISTA_IZNOSA_RADNIKARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow eventRow;

            public SP_LISTA_IZNOSA_RADNIKARowChangeEvent(SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow row, DataRowAction action)
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

            public SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SP_LISTA_IZNOSA_RADNIKARowChangeEventHandler(object sender, SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARowChangeEvent e);
    }
}

