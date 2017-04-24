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
    public class S_DD_LISTA_IZNOSA_RADNIKADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_DD_LISTA_IZNOSA_RADNIKADataTable tableS_DD_LISTA_IZNOSA_RADNIKA;

        public S_DD_LISTA_IZNOSA_RADNIKADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_DD_LISTA_IZNOSA_RADNIKADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_DD_LISTA_IZNOSA_RADNIKA"] != null)
                    {
                        this.Tables.Add(new S_DD_LISTA_IZNOSA_RADNIKADataTable(dataSet.Tables["S_DD_LISTA_IZNOSA_RADNIKA"]));
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
            S_DD_LISTA_IZNOSA_RADNIKADataSet set = (S_DD_LISTA_IZNOSA_RADNIKADataSet) base.Clone();
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
            S_DD_LISTA_IZNOSA_RADNIKADataSet set = new S_DD_LISTA_IZNOSA_RADNIKADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_DD_LISTA_IZNOSA_RADNIKADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2092");
            this.ExtendedProperties.Add("DataSetName", "S_DD_LISTA_IZNOSA_RADNIKADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_DD_LISTA_IZNOSA_RADNIKADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_DD_LISTA_IZNOSA_RADNIKA");
            this.ExtendedProperties.Add("ObjectDescription", "S_DD_LISTA_IZNOSA_RADNIKA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_DD");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_DD_LISTA_IZNOSA_RADNIKA");
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
            this.DataSetName = "S_DD_LISTA_IZNOSA_RADNIKADataSet";
            this.Namespace = "http://www.tempuri.org/S_DD_LISTA_IZNOSA_RADNIKA";
            this.tableS_DD_LISTA_IZNOSA_RADNIKA = new S_DD_LISTA_IZNOSA_RADNIKADataTable();
            this.Tables.Add(this.tableS_DD_LISTA_IZNOSA_RADNIKA);
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
            this.tableS_DD_LISTA_IZNOSA_RADNIKA = (S_DD_LISTA_IZNOSA_RADNIKADataTable) this.Tables["S_DD_LISTA_IZNOSA_RADNIKA"];
            if (initTable && (this.tableS_DD_LISTA_IZNOSA_RADNIKA != null))
            {
                this.tableS_DD_LISTA_IZNOSA_RADNIKA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_DD_LISTA_IZNOSA_RADNIKA"] != null)
                {
                    this.Tables.Add(new S_DD_LISTA_IZNOSA_RADNIKADataTable(dataSet.Tables["S_DD_LISTA_IZNOSA_RADNIKA"]));
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

        private bool ShouldSerializeS_DD_LISTA_IZNOSA_RADNIKA()
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
        public S_DD_LISTA_IZNOSA_RADNIKADataTable S_DD_LISTA_IZNOSA_RADNIKA
        {
            get
            {
                return this.tableS_DD_LISTA_IZNOSA_RADNIKA;
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
        public class S_DD_LISTA_IZNOSA_RADNIKADataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDIDRADNIK;
            private DataColumn columnDDIME;
            private DataColumn columnDDPREZIME;
            private DataColumn columnNAZIVKATEGORIJA;
            private DataColumn columnnetoplaca;
            private DataColumn columnnetoplacamanjekrizni;
            private DataColumn columnPDVDRUGIDOHODAK;
            private DataColumn columnPOREZKRIZNI;
            private DataColumn columnukupnobruto;
            private DataColumn columnukupnodoprinosi;
            private DataColumn columnUKUPNODOPRINOSINA;
            private DataColumn columnUKUPNOIZDACI;
            private DataColumn columnUKUPNOPOREZ;
            private DataColumn columnukupnoporeziprirez;
            private DataColumn columnUKUPNOPRIREZ;
            private DataColumn columnZAISPLATU;

            public event S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARowChangeEventHandler S_DD_LISTA_IZNOSA_RADNIKARowChanged;

            public event S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARowChangeEventHandler S_DD_LISTA_IZNOSA_RADNIKARowChanging;

            public event S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARowChangeEventHandler S_DD_LISTA_IZNOSA_RADNIKARowDeleted;

            public event S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARowChangeEventHandler S_DD_LISTA_IZNOSA_RADNIKARowDeleting;

            public S_DD_LISTA_IZNOSA_RADNIKADataTable()
            {
                this.TableName = "S_DD_LISTA_IZNOSA_RADNIKA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_DD_LISTA_IZNOSA_RADNIKADataTable(DataTable table) : base(table.TableName)
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

            protected S_DD_LISTA_IZNOSA_RADNIKADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_DD_LISTA_IZNOSA_RADNIKARow(S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow row)
            {
                this.Rows.Add(row);
            }

            public S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow AddS_DD_LISTA_IZNOSA_RADNIKARow(int dDIDRADNIK, string dDPREZIME, string dDIME, decimal ukupnobruto, decimal ukupnodoprinosi, decimal uKUPNOPOREZ, decimal uKUPNOPRIREZ, decimal ukupnoporeziprirez, decimal netoplaca, decimal uKUPNODOPRINOSINA, decimal pOREZKRIZNI, decimal netoplacamanjekrizni, string nAZIVKATEGORIJA, decimal pDVDRUGIDOHODAK, decimal zAISPLATU, decimal uKUPNOIZDACI)
            {
                S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow row = (S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow) this.NewRow();
                row.ItemArray = new object[] { dDIDRADNIK, dDPREZIME, dDIME, ukupnobruto, ukupnodoprinosi, uKUPNOPOREZ, uKUPNOPRIREZ, ukupnoporeziprirez, netoplaca, uKUPNODOPRINOSINA, pOREZKRIZNI, netoplacamanjekrizni, nAZIVKATEGORIJA, pDVDRUGIDOHODAK, zAISPLATU, uKUPNOIZDACI };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKADataTable table = (S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_DD_LISTA_IZNOSA_RADNIKADataSet set = new S_DD_LISTA_IZNOSA_RADNIKADataSet();
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
                this.columnDDIDRADNIK = new DataColumn("DDIDRADNIK", typeof(int), "", MappingType.Element);
                this.columnDDIDRADNIK.Caption = "Šifra";
                this.columnDDIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Description", "Šifra");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Length", "5");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "DDIDRADNIK");
                this.Columns.Add(this.columnDDIDRADNIK);
                this.columnDDPREZIME = new DataColumn("DDPREZIME", typeof(string), "", MappingType.Element);
                this.columnDDPREZIME.Caption = "Prezime";
                this.columnDDPREZIME.MaxLength = 50;
                this.columnDDPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnDDPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnDDPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnDDPREZIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "DDPREZIME");
                this.Columns.Add(this.columnDDPREZIME);
                this.columnDDIME = new DataColumn("DDIME", typeof(string), "", MappingType.Element);
                this.columnDDIME.Caption = "Ime";
                this.columnDDIME.MaxLength = 50;
                this.columnDDIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDDIME.ExtendedProperties.Add("IsKey", "false");
                this.columnDDIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDIME.ExtendedProperties.Add("Description", "Ime");
                this.columnDDIME.ExtendedProperties.Add("Length", "50");
                this.columnDDIME.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.InternalName", "DDIME");
                this.Columns.Add(this.columnDDIME);
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
                this.columnUKUPNOPOREZ = new DataColumn("UKUPNOPOREZ", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOPOREZ.Caption = "UKUPNOPOREZ";
                this.columnUKUPNOPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Description", "UKUPNOPOREZ");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOPOREZ");
                this.Columns.Add(this.columnUKUPNOPOREZ);
                this.columnUKUPNOPRIREZ = new DataColumn("UKUPNOPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOPRIREZ.Caption = "UKUPNOPRIREZ";
                this.columnUKUPNOPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Description", "UKUPNOPRIREZ");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOPRIREZ");
                this.Columns.Add(this.columnUKUPNOPRIREZ);
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
                this.columnNAZIVKATEGORIJA = new DataColumn("NAZIVKATEGORIJA", typeof(string), "", MappingType.Element);
                this.columnNAZIVKATEGORIJA.Caption = "Kategorija";
                this.columnNAZIVKATEGORIJA.MaxLength = 50;
                this.columnNAZIVKATEGORIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Description", "Kategorija");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKATEGORIJA");
                this.Columns.Add(this.columnNAZIVKATEGORIJA);
                this.columnPDVDRUGIDOHODAK = new DataColumn("PDVDRUGIDOHODAK", typeof(decimal), "", MappingType.Element);
                this.columnPDVDRUGIDOHODAK.Caption = "PDVDRUGIDOHODAK";
                this.columnPDVDRUGIDOHODAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("IsKey", "false");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("Description", "PDVDRUGIDOHODAK");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("Length", "12");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("Decimals", "2");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDVDRUGIDOHODAK.ExtendedProperties.Add("Deklarit.InternalName", "PDVDRUGIDOHODAK");
                this.Columns.Add(this.columnPDVDRUGIDOHODAK);
                this.columnZAISPLATU = new DataColumn("ZAISPLATU", typeof(decimal), "", MappingType.Element);
                this.columnZAISPLATU.Caption = "ZAISPLATU";
                this.columnZAISPLATU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZAISPLATU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZAISPLATU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZAISPLATU.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnZAISPLATU.ExtendedProperties.Add("IsKey", "false");
                this.columnZAISPLATU.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZAISPLATU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZAISPLATU.ExtendedProperties.Add("Description", "ZAISPLATU");
                this.columnZAISPLATU.ExtendedProperties.Add("Length", "12");
                this.columnZAISPLATU.ExtendedProperties.Add("Decimals", "2");
                this.columnZAISPLATU.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZAISPLATU.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZAISPLATU.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZAISPLATU.ExtendedProperties.Add("IsInReader", "true");
                this.columnZAISPLATU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZAISPLATU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZAISPLATU.ExtendedProperties.Add("Deklarit.InternalName", "ZAISPLATU");
                this.Columns.Add(this.columnZAISPLATU);
                this.columnUKUPNOIZDACI = new DataColumn("UKUPNOIZDACI", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOIZDACI.Caption = "UKUPNOIZDACI";
                this.columnUKUPNOIZDACI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("Description", "UKUPNOIZDACI");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOIZDACI.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOIZDACI");
                this.Columns.Add(this.columnUKUPNOIZDACI);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_DD_LISTA_IZNOSA_RADNIKA");
                this.ExtendedProperties.Add("Description", "S_DD_LISTA_IZNOSA_RADNIKA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnDDIDRADNIK = this.Columns["DDIDRADNIK"];
                this.columnDDPREZIME = this.Columns["DDPREZIME"];
                this.columnDDIME = this.Columns["DDIME"];
                this.columnukupnobruto = this.Columns["ukupnobruto"];
                this.columnukupnodoprinosi = this.Columns["ukupnodoprinosi"];
                this.columnUKUPNOPOREZ = this.Columns["UKUPNOPOREZ"];
                this.columnUKUPNOPRIREZ = this.Columns["UKUPNOPRIREZ"];
                this.columnukupnoporeziprirez = this.Columns["ukupnoporeziprirez"];
                this.columnnetoplaca = this.Columns["netoplaca"];
                this.columnUKUPNODOPRINOSINA = this.Columns["UKUPNODOPRINOSINA"];
                this.columnPOREZKRIZNI = this.Columns["POREZKRIZNI"];
                this.columnnetoplacamanjekrizni = this.Columns["netoplacamanjekrizni"];
                this.columnNAZIVKATEGORIJA = this.Columns["NAZIVKATEGORIJA"];
                this.columnPDVDRUGIDOHODAK = this.Columns["PDVDRUGIDOHODAK"];
                this.columnZAISPLATU = this.Columns["ZAISPLATU"];
                this.columnUKUPNOIZDACI = this.Columns["UKUPNOIZDACI"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow(builder);
            }

            public S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow NewS_DD_LISTA_IZNOSA_RADNIKARow()
            {
                return (S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_DD_LISTA_IZNOSA_RADNIKARowChanged != null)
                {
                    S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARowChangeEventHandler handler = this.S_DD_LISTA_IZNOSA_RADNIKARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARowChangeEvent((S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_DD_LISTA_IZNOSA_RADNIKARowChanging != null)
                {
                    S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARowChangeEventHandler handler = this.S_DD_LISTA_IZNOSA_RADNIKARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARowChangeEvent((S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_DD_LISTA_IZNOSA_RADNIKARowDeleted != null)
                {
                    S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARowChangeEventHandler handler = this.S_DD_LISTA_IZNOSA_RADNIKARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARowChangeEvent((S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_DD_LISTA_IZNOSA_RADNIKARowDeleting != null)
                {
                    S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARowChangeEventHandler handler = this.S_DD_LISTA_IZNOSA_RADNIKARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARowChangeEvent((S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_DD_LISTA_IZNOSA_RADNIKARow(S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow row)
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

            public DataColumn DDIDRADNIKColumn
            {
                get
                {
                    return this.columnDDIDRADNIK;
                }
            }

            public DataColumn DDIMEColumn
            {
                get
                {
                    return this.columnDDIME;
                }
            }

            public DataColumn DDPREZIMEColumn
            {
                get
                {
                    return this.columnDDPREZIME;
                }
            }

            public S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow this[int index]
            {
                get
                {
                    return (S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVKATEGORIJAColumn
            {
                get
                {
                    return this.columnNAZIVKATEGORIJA;
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

            public DataColumn PDVDRUGIDOHODAKColumn
            {
                get
                {
                    return this.columnPDVDRUGIDOHODAK;
                }
            }

            public DataColumn POREZKRIZNIColumn
            {
                get
                {
                    return this.columnPOREZKRIZNI;
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

            public DataColumn UKUPNOIZDACIColumn
            {
                get
                {
                    return this.columnUKUPNOIZDACI;
                }
            }

            public DataColumn UKUPNOPOREZColumn
            {
                get
                {
                    return this.columnUKUPNOPOREZ;
                }
            }

            public DataColumn ukupnoporeziprirezColumn
            {
                get
                {
                    return this.columnukupnoporeziprirez;
                }
            }

            public DataColumn UKUPNOPRIREZColumn
            {
                get
                {
                    return this.columnUKUPNOPRIREZ;
                }
            }

            public DataColumn ZAISPLATUColumn
            {
                get
                {
                    return this.columnZAISPLATU;
                }
            }
        }

        public class S_DD_LISTA_IZNOSA_RADNIKARow : DataRow
        {
            private S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKADataTable tableS_DD_LISTA_IZNOSA_RADNIKA;

            internal S_DD_LISTA_IZNOSA_RADNIKARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_DD_LISTA_IZNOSA_RADNIKA = (S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKADataTable) this.Table;
            }

            public bool IsDDIDRADNIKNull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.DDIDRADNIKColumn);
            }

            public bool IsDDIMENull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.DDIMEColumn);
            }

            public bool IsDDPREZIMENull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.DDPREZIMEColumn);
            }

            public bool IsNAZIVKATEGORIJANull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.NAZIVKATEGORIJAColumn);
            }

            public bool IsnetoplacamanjekrizniNull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.netoplacamanjekrizniColumn);
            }

            public bool IsnetoplacaNull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.netoplacaColumn);
            }

            public bool IsPDVDRUGIDOHODAKNull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.PDVDRUGIDOHODAKColumn);
            }

            public bool IsPOREZKRIZNINull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.POREZKRIZNIColumn);
            }

            public bool IsukupnobrutoNull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.ukupnobrutoColumn);
            }

            public bool IsUKUPNODOPRINOSINANull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNODOPRINOSINAColumn);
            }

            public bool IsukupnodoprinosiNull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.ukupnodoprinosiColumn);
            }

            public bool IsUKUPNOIZDACINull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNOIZDACIColumn);
            }

            public bool IsukupnoporeziprirezNull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.ukupnoporeziprirezColumn);
            }

            public bool IsUKUPNOPOREZNull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNOPOREZColumn);
            }

            public bool IsUKUPNOPRIREZNull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNOPRIREZColumn);
            }

            public bool IsZAISPLATUNull()
            {
                return this.IsNull(this.tableS_DD_LISTA_IZNOSA_RADNIKA.ZAISPLATUColumn);
            }

            public void SetDDIDRADNIKNull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.DDIDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDIMENull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.DDIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPREZIMENull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.DDPREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKATEGORIJANull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.NAZIVKATEGORIJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoplacamanjekrizniNull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.netoplacamanjekrizniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoplacaNull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.netoplacaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDVDRUGIDOHODAKNull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.PDVDRUGIDOHODAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZKRIZNINull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.POREZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnobrutoNull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.ukupnobrutoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNODOPRINOSINANull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNODOPRINOSINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnodoprinosiNull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.ukupnodoprinosiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOIZDACINull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNOIZDACIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnoporeziprirezNull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.ukupnoporeziprirezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOPOREZNull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNOPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOPRIREZNull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNOPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZAISPLATUNull()
            {
                this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.ZAISPLATUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int DDIDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.DDIDRADNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.DDIDRADNIKColumn] = value;
                }
            }

            public string DDIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.DDIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDIME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.DDIMEColumn] = value;
                }
            }

            public string DDPREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.DDPREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDPREZIME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.DDPREZIMEColumn] = value;
                }
            }

            public string NAZIVKATEGORIJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.NAZIVKATEGORIJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVKATEGORIJA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.NAZIVKATEGORIJAColumn] = value;
                }
            }

            public decimal netoplaca
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.netoplacaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.netoplacaColumn] = value;
                }
            }

            public decimal netoplacamanjekrizni
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.netoplacamanjekrizniColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.netoplacamanjekrizniColumn] = value;
                }
            }

            public decimal PDVDRUGIDOHODAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.PDVDRUGIDOHODAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.PDVDRUGIDOHODAKColumn] = value;
                }
            }

            public decimal POREZKRIZNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.POREZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.POREZKRIZNIColumn] = value;
                }
            }

            public decimal ukupnobruto
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.ukupnobrutoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.ukupnobrutoColumn] = value;
                }
            }

            public decimal ukupnodoprinosi
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.ukupnodoprinosiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.ukupnodoprinosiColumn] = value;
                }
            }

            public decimal UKUPNODOPRINOSINA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNODOPRINOSINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNODOPRINOSINAColumn] = value;
                }
            }

            public decimal UKUPNOIZDACI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNOIZDACIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNOIZDACIColumn] = value;
                }
            }

            public decimal UKUPNOPOREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNOPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNOPOREZColumn] = value;
                }
            }

            public decimal ukupnoporeziprirez
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.ukupnoporeziprirezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.ukupnoporeziprirezColumn] = value;
                }
            }

            public decimal UKUPNOPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNOPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.UKUPNOPRIREZColumn] = value;
                }
            }

            public decimal ZAISPLATU
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.ZAISPLATUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_LISTA_IZNOSA_RADNIKA.ZAISPLATUColumn] = value;
                }
            }
        }

        public class S_DD_LISTA_IZNOSA_RADNIKARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow eventRow;

            public S_DD_LISTA_IZNOSA_RADNIKARowChangeEvent(S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow row, DataRowAction action)
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

            public S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_DD_LISTA_IZNOSA_RADNIKARowChangeEventHandler(object sender, S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARowChangeEvent e);
    }
}

