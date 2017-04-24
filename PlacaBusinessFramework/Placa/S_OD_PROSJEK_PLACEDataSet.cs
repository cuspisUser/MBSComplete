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
    public class S_OD_PROSJEK_PLACEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_PROSJEK_PLACEDataTable tableS_OD_PROSJEK_PLACE;

        public S_OD_PROSJEK_PLACEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_PROSJEK_PLACEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_PROSJEK_PLACE"] != null)
                    {
                        this.Tables.Add(new S_OD_PROSJEK_PLACEDataTable(dataSet.Tables["S_OD_PROSJEK_PLACE"]));
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
            S_OD_PROSJEK_PLACEDataSet set = (S_OD_PROSJEK_PLACEDataSet) base.Clone();
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
            S_OD_PROSJEK_PLACEDataSet set = new S_OD_PROSJEK_PLACEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_PROSJEK_PLACEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2082");
            this.ExtendedProperties.Add("DataSetName", "S_OD_PROSJEK_PLACEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_PROSJEK_PLACEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_PROSJEK_PLACE");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_PROSJEK_PLACE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_PROSJEK_PLACE");
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
            this.DataSetName = "S_OD_PROSJEK_PLACEDataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_PROSJEK_PLACE";
            this.tableS_OD_PROSJEK_PLACE = new S_OD_PROSJEK_PLACEDataTable();
            this.Tables.Add(this.tableS_OD_PROSJEK_PLACE);
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
            this.tableS_OD_PROSJEK_PLACE = (S_OD_PROSJEK_PLACEDataTable) this.Tables["S_OD_PROSJEK_PLACE"];
            if (initTable && (this.tableS_OD_PROSJEK_PLACE != null))
            {
                this.tableS_OD_PROSJEK_PLACE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_PROSJEK_PLACE"] != null)
                {
                    this.Tables.Add(new S_OD_PROSJEK_PLACEDataTable(dataSet.Tables["S_OD_PROSJEK_PLACE"]));
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

        private bool ShouldSerializeS_OD_PROSJEK_PLACE()
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
        public S_OD_PROSJEK_PLACEDataTable S_OD_PROSJEK_PLACE
        {
            get
            {
                return this.tableS_OD_PROSJEK_PLACE;
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
        public class S_OD_PROSJEK_PLACEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnGODINAMJESEC;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnkucnibroj;
            private DataColumn columnmjesto;
            private DataColumn columnnetoplaca;
            private DataColumn columnPREZIME;
            private DataColumn columnulica;

            public event S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERowChangeEventHandler S_OD_PROSJEK_PLACERowChanged;

            public event S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERowChangeEventHandler S_OD_PROSJEK_PLACERowChanging;

            public event S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERowChangeEventHandler S_OD_PROSJEK_PLACERowDeleted;

            public event S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERowChangeEventHandler S_OD_PROSJEK_PLACERowDeleting;

            public S_OD_PROSJEK_PLACEDataTable()
            {
                this.TableName = "S_OD_PROSJEK_PLACE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_PROSJEK_PLACEDataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_PROSJEK_PLACEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_PROSJEK_PLACERow(S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow AddS_OD_PROSJEK_PLACERow(decimal netoplaca, string iME, string pREZIME, int iDRADNIK, string ulica, string kucnibroj, string mjesto, string gODINAMJESEC)
            {
                S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow row = (S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow) this.NewRow();
                row.ItemArray = new object[] { netoplaca, iME, pREZIME, iDRADNIK, ulica, kucnibroj, mjesto, gODINAMJESEC };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACEDataTable table = (S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_PROSJEK_PLACEDataSet set = new S_OD_PROSJEK_PLACEDataSet();
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
                this.columnulica = new DataColumn("ulica", typeof(string), "", MappingType.Element);
                this.columnulica.Caption = "Ulica";
                this.columnulica.MaxLength = 50;
                this.columnulica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnulica.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnulica.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnulica.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnulica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnulica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnulica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnulica.ExtendedProperties.Add("IsKey", "false");
                this.columnulica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnulica.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnulica.ExtendedProperties.Add("Description", "Ulica");
                this.columnulica.ExtendedProperties.Add("Length", "50");
                this.columnulica.ExtendedProperties.Add("Decimals", "0");
                this.columnulica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnulica.ExtendedProperties.Add("IsInReader", "true");
                this.columnulica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnulica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnulica.ExtendedProperties.Add("Deklarit.InternalName", "ulica");
                this.Columns.Add(this.columnulica);
                this.columnkucnibroj = new DataColumn("kucnibroj", typeof(string), "", MappingType.Element);
                this.columnkucnibroj.Caption = "Kućni broj";
                this.columnkucnibroj.MaxLength = 10;
                this.columnkucnibroj.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnkucnibroj.ExtendedProperties.Add("IsKey", "false");
                this.columnkucnibroj.ExtendedProperties.Add("ReadOnly", "true");
                this.columnkucnibroj.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnkucnibroj.ExtendedProperties.Add("Description", "Kućni broj");
                this.columnkucnibroj.ExtendedProperties.Add("Length", "10");
                this.columnkucnibroj.ExtendedProperties.Add("Decimals", "0");
                this.columnkucnibroj.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnkucnibroj.ExtendedProperties.Add("IsInReader", "true");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.InternalName", "kucnibroj");
                this.Columns.Add(this.columnkucnibroj);
                this.columnmjesto = new DataColumn("mjesto", typeof(string), "", MappingType.Element);
                this.columnmjesto.Caption = "Mjesto";
                this.columnmjesto.MaxLength = 50;
                this.columnmjesto.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnmjesto.ExtendedProperties.Add("IsKey", "false");
                this.columnmjesto.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmjesto.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnmjesto.ExtendedProperties.Add("Description", "Mjesto");
                this.columnmjesto.ExtendedProperties.Add("Length", "50");
                this.columnmjesto.ExtendedProperties.Add("Decimals", "0");
                this.columnmjesto.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmjesto.ExtendedProperties.Add("IsInReader", "true");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.InternalName", "mjesto");
                this.Columns.Add(this.columnmjesto);
                this.columnGODINAMJESEC = new DataColumn("GODINAMJESEC", typeof(string), "", MappingType.Element);
                this.columnGODINAMJESEC.Caption = "GODINAMJESEC";
                this.columnGODINAMJESEC.MaxLength = 7;
                this.columnGODINAMJESEC.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINAMJESEC.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINAMJESEC.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINAMJESEC.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnGODINAMJESEC.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINAMJESEC.ExtendedProperties.Add("ReadOnly", "true");
                this.columnGODINAMJESEC.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnGODINAMJESEC.ExtendedProperties.Add("Description", "GODINAMJESEC");
                this.columnGODINAMJESEC.ExtendedProperties.Add("Length", "7");
                this.columnGODINAMJESEC.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINAMJESEC.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnGODINAMJESEC.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINAMJESEC.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINAMJESEC.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINAMJESEC.ExtendedProperties.Add("Deklarit.InternalName", "GODINAMJESEC");
                this.Columns.Add(this.columnGODINAMJESEC);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_PROSJEK_PLACE");
                this.ExtendedProperties.Add("Description", "_S_OD_PROSJEK_PLACE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnnetoplaca = this.Columns["netoplaca"];
                this.columnIME = this.Columns["IME"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnulica = this.Columns["ulica"];
                this.columnkucnibroj = this.Columns["kucnibroj"];
                this.columnmjesto = this.Columns["mjesto"];
                this.columnGODINAMJESEC = this.Columns["GODINAMJESEC"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow(builder);
            }

            public S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow NewS_OD_PROSJEK_PLACERow()
            {
                return (S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_PROSJEK_PLACERowChanged != null)
                {
                    S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERowChangeEventHandler handler = this.S_OD_PROSJEK_PLACERowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERowChangeEvent((S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_PROSJEK_PLACERowChanging != null)
                {
                    S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERowChangeEventHandler handler = this.S_OD_PROSJEK_PLACERowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERowChangeEvent((S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_PROSJEK_PLACERowDeleted != null)
                {
                    S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERowChangeEventHandler handler = this.S_OD_PROSJEK_PLACERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERowChangeEvent((S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_PROSJEK_PLACERowDeleting != null)
                {
                    S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERowChangeEventHandler handler = this.S_OD_PROSJEK_PLACERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERowChangeEvent((S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_PROSJEK_PLACERow(S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow row)
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

            public DataColumn GODINAMJESECColumn
            {
                get
                {
                    return this.columnGODINAMJESEC;
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

            public S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow this[int index]
            {
                get
                {
                    return (S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow) this.Rows[index];
                }
            }

            public DataColumn kucnibrojColumn
            {
                get
                {
                    return this.columnkucnibroj;
                }
            }

            public DataColumn mjestoColumn
            {
                get
                {
                    return this.columnmjesto;
                }
            }

            public DataColumn netoplacaColumn
            {
                get
                {
                    return this.columnnetoplaca;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn ulicaColumn
            {
                get
                {
                    return this.columnulica;
                }
            }
        }

        public class S_OD_PROSJEK_PLACERow : DataRow
        {
            private S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACEDataTable tableS_OD_PROSJEK_PLACE;

            internal S_OD_PROSJEK_PLACERow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_PROSJEK_PLACE = (S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACEDataTable) this.Table;
            }

            public bool IsGODINAMJESECNull()
            {
                return this.IsNull(this.tableS_OD_PROSJEK_PLACE.GODINAMJESECColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_OD_PROSJEK_PLACE.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableS_OD_PROSJEK_PLACE.IMEColumn);
            }

            public bool IskucnibrojNull()
            {
                return this.IsNull(this.tableS_OD_PROSJEK_PLACE.kucnibrojColumn);
            }

            public bool IsmjestoNull()
            {
                return this.IsNull(this.tableS_OD_PROSJEK_PLACE.mjestoColumn);
            }

            public bool IsnetoplacaNull()
            {
                return this.IsNull(this.tableS_OD_PROSJEK_PLACE.netoplacaColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableS_OD_PROSJEK_PLACE.PREZIMEColumn);
            }

            public bool IsulicaNull()
            {
                return this.IsNull(this.tableS_OD_PROSJEK_PLACE.ulicaColumn);
            }

            public void SetGODINAMJESECNull()
            {
                this[this.tableS_OD_PROSJEK_PLACE.GODINAMJESECColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_OD_PROSJEK_PLACE.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableS_OD_PROSJEK_PLACE.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetkucnibrojNull()
            {
                this[this.tableS_OD_PROSJEK_PLACE.kucnibrojColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetmjestoNull()
            {
                this[this.tableS_OD_PROSJEK_PLACE.mjestoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoplacaNull()
            {
                this[this.tableS_OD_PROSJEK_PLACE.netoplacaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableS_OD_PROSJEK_PLACE.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetulicaNull()
            {
                this[this.tableS_OD_PROSJEK_PLACE.ulicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string GODINAMJESEC
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_PROSJEK_PLACE.GODINAMJESECColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value GODINAMJESEC because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_PROSJEK_PLACE.GODINAMJESECColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_PROSJEK_PLACE.IDRADNIKColumn]);
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
                    this[this.tableS_OD_PROSJEK_PLACE.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_PROSJEK_PLACE.IMEColumn]);
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
                    this[this.tableS_OD_PROSJEK_PLACE.IMEColumn] = value;
                }
            }

            public string kucnibroj
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_PROSJEK_PLACE.kucnibrojColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value kucnibroj because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_PROSJEK_PLACE.kucnibrojColumn] = value;
                }
            }

            public string mjesto
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_PROSJEK_PLACE.mjestoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value mjesto because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_PROSJEK_PLACE.mjestoColumn] = value;
                }
            }

            public decimal netoplaca
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_PROSJEK_PLACE.netoplacaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value netoplaca because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_PROSJEK_PLACE.netoplacaColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_PROSJEK_PLACE.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_PROSJEK_PLACE.PREZIMEColumn] = value;
                }
            }

            public string ulica
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_PROSJEK_PLACE.ulicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_PROSJEK_PLACE.ulicaColumn] = value;
                }
            }
        }

        public class S_OD_PROSJEK_PLACERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow eventRow;

            public S_OD_PROSJEK_PLACERowChangeEvent(S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow row, DataRowAction action)
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

            public S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_PROSJEK_PLACERowChangeEventHandler(object sender, S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERowChangeEvent e);
    }
}

