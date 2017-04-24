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
    public class S_OD_BOLOVANJE_POSLODAVACDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_BOLOVANJE_POSLODAVACDataTable tableS_OD_BOLOVANJE_POSLODAVAC;

        public S_OD_BOLOVANJE_POSLODAVACDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_BOLOVANJE_POSLODAVACDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_BOLOVANJE_POSLODAVAC"] != null)
                    {
                        this.Tables.Add(new S_OD_BOLOVANJE_POSLODAVACDataTable(dataSet.Tables["S_OD_BOLOVANJE_POSLODAVAC"]));
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
            S_OD_BOLOVANJE_POSLODAVACDataSet set = (S_OD_BOLOVANJE_POSLODAVACDataSet) base.Clone();
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
            S_OD_BOLOVANJE_POSLODAVACDataSet set = new S_OD_BOLOVANJE_POSLODAVACDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_BOLOVANJE_POSLODAVACDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2073");
            this.ExtendedProperties.Add("DataSetName", "S_OD_BOLOVANJE_POSLODAVACDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_BOLOVANJE_POSLODAVACDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_BOLOVANJE_POSLODAVAC");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_BOLOVANJE_POSLODAVAC");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_BOLOVANJE_POSLODAVAC");
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
            this.DataSetName = "S_OD_BOLOVANJE_POSLODAVACDataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_BOLOVANJE_POSLODAVAC";
            this.tableS_OD_BOLOVANJE_POSLODAVAC = new S_OD_BOLOVANJE_POSLODAVACDataTable();
            this.Tables.Add(this.tableS_OD_BOLOVANJE_POSLODAVAC);
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
            this.tableS_OD_BOLOVANJE_POSLODAVAC = (S_OD_BOLOVANJE_POSLODAVACDataTable) this.Tables["S_OD_BOLOVANJE_POSLODAVAC"];
            if (initTable && (this.tableS_OD_BOLOVANJE_POSLODAVAC != null))
            {
                this.tableS_OD_BOLOVANJE_POSLODAVAC.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_BOLOVANJE_POSLODAVAC"] != null)
                {
                    this.Tables.Add(new S_OD_BOLOVANJE_POSLODAVACDataTable(dataSet.Tables["S_OD_BOLOVANJE_POSLODAVAC"]));
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

        private bool ShouldSerializeS_OD_BOLOVANJE_POSLODAVAC()
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
        public S_OD_BOLOVANJE_POSLODAVACDataTable S_OD_BOLOVANJE_POSLODAVAC
        {
            get
            {
                return this.tableS_OD_BOLOVANJE_POSLODAVAC;
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
        public class S_OD_BOLOVANJE_POSLODAVACDataTable : DataTable, IEnumerable
        {
            private DataColumn columnGODINAMJESEC;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnIZNOSBRUTO;
            private DataColumn columnPREZIME;
            private DataColumn columnSATIUKUPNO;
            private DataColumn columnPROSJECNASATNICA;
            private DataColumn columnPROSJECNASATNICA_85POSTO;

            public event S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRowChangeEventHandler S_OD_BOLOVANJE_POSLODAVACRowChanged;

            public event S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRowChangeEventHandler S_OD_BOLOVANJE_POSLODAVACRowChanging;

            public event S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRowChangeEventHandler S_OD_BOLOVANJE_POSLODAVACRowDeleted;

            public event S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRowChangeEventHandler S_OD_BOLOVANJE_POSLODAVACRowDeleting;

            public S_OD_BOLOVANJE_POSLODAVACDataTable()
            {
                this.TableName = "S_OD_BOLOVANJE_POSLODAVAC";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_BOLOVANJE_POSLODAVACDataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_BOLOVANJE_POSLODAVACDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_BOLOVANJE_POSLODAVACRow(S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow AddS_OD_BOLOVANJE_POSLODAVACRow(int iDRADNIK, string pREZIME, string iME, decimal iZNOSBRUTO, decimal sATIUKUPNO, string gODINAMJESEC,
                decimal pROSJECNASATNICA, decimal pROSJECNASATNICA_85POSTO)
            {
                S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow row = (S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow) this.NewRow();
                row.ItemArray = new object[] { iDRADNIK, pREZIME, iME, iZNOSBRUTO, sATIUKUPNO, gODINAMJESEC, pROSJECNASATNICA, pROSJECNASATNICA_85POSTO };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACDataTable table = (S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_BOLOVANJE_POSLODAVACDataSet set = new S_OD_BOLOVANJE_POSLODAVACDataSet();
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

                this.columnIZNOSBRUTO = new DataColumn("IZNOSBRUTO", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSBRUTO.Caption = "IZNOSBRUTO";
                this.columnIZNOSBRUTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSBRUTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("Description", "IZNOSBRUTO");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSBRUTO.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSBRUTO");
                this.Columns.Add(this.columnIZNOSBRUTO);

                this.columnSATIUKUPNO = new DataColumn("SATIUKUPNO", typeof(decimal), "", MappingType.Element);
                this.columnSATIUKUPNO.Caption = "SATIUKUPNO";
                this.columnSATIUKUPNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSATIUKUPNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSATIUKUPNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSATIUKUPNO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSATIUKUPNO.ExtendedProperties.Add("IsKey", "false");
                this.columnSATIUKUPNO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSATIUKUPNO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSATIUKUPNO.ExtendedProperties.Add("Description", "SATIUKUPNO");
                this.columnSATIUKUPNO.ExtendedProperties.Add("Length", "12");
                this.columnSATIUKUPNO.ExtendedProperties.Add("Decimals", "2");
                this.columnSATIUKUPNO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSATIUKUPNO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSATIUKUPNO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSATIUKUPNO.ExtendedProperties.Add("IsInReader", "true");
                this.columnSATIUKUPNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSATIUKUPNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSATIUKUPNO.ExtendedProperties.Add("Deklarit.InternalName", "SATIUKUPNO");
                this.Columns.Add(this.columnSATIUKUPNO);
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



                this.columnPROSJECNASATNICA = new DataColumn("PROSJECNASATNICA", typeof(decimal), "", MappingType.Element);
                this.columnPROSJECNASATNICA.Caption = "PROSJECNASATNICA";
                this.columnPROSJECNASATNICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("IsKey", "false");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("Description", "PROSJECNASATNICA");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("Length", "12");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("Decimals", "2");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPROSJECNASATNICA.ExtendedProperties.Add("Deklarit.InternalName", "PROSJECNASATNICA");
                this.Columns.Add(this.columnPROSJECNASATNICA);



                this.columnPROSJECNASATNICA_85POSTO = new DataColumn("PROSJECNASATNICA_85POSTO", typeof(decimal), "", MappingType.Element);
                this.columnPROSJECNASATNICA_85POSTO.Caption = "PROSJECNASATNICA_85POSTO";
                this.columnPROSJECNASATNICA_85POSTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("IsKey", "false");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("Description", "PROSJECNASATNICA_85POSTO");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("Length", "12");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("Decimals", "2");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPROSJECNASATNICA_85POSTO.ExtendedProperties.Add("Deklarit.InternalName", "PROSJECNASATNICA_85POSTO");
                this.Columns.Add(this.columnPROSJECNASATNICA_85POSTO);



                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_BOLOVANJE_POSLODAVAC");
                this.ExtendedProperties.Add("Description", "_S_OD_BOLOVANJE_POSLODAVAC");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnIZNOSBRUTO = this.Columns["IZNOSBRUTO"];
                this.columnSATIUKUPNO = this.Columns["SATIUKUPNO"];
                this.columnGODINAMJESEC = this.Columns["GODINAMJESEC"];
                this.columnPROSJECNASATNICA = this.Columns["PROSJECNASATNICA"];
                this.columnPROSJECNASATNICA_85POSTO = this.Columns["PROSJECNASATNICA_85POSTO"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow(builder);
            }

            public S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow NewS_OD_BOLOVANJE_POSLODAVACRow()
            {
                return (S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_BOLOVANJE_POSLODAVACRowChanged != null)
                {
                    S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRowChangeEventHandler handler = this.S_OD_BOLOVANJE_POSLODAVACRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRowChangeEvent((S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_BOLOVANJE_POSLODAVACRowChanging != null)
                {
                    S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRowChangeEventHandler handler = this.S_OD_BOLOVANJE_POSLODAVACRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRowChangeEvent((S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_BOLOVANJE_POSLODAVACRowDeleted != null)
                {
                    S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRowChangeEventHandler handler = this.S_OD_BOLOVANJE_POSLODAVACRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRowChangeEvent((S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_BOLOVANJE_POSLODAVACRowDeleting != null)
                {
                    S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRowChangeEventHandler handler = this.S_OD_BOLOVANJE_POSLODAVACRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRowChangeEvent((S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_BOLOVANJE_POSLODAVACRow(S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow row)
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

            public S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow this[int index]
            {
                get
                {
                    return (S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow) this.Rows[index];
                }
            }

            public DataColumn IZNOSBRUTOColumn
            {
                get
                {
                    return this.columnIZNOSBRUTO;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn SATIUKUPNOColumn
            {
                get
                {
                    return this.columnSATIUKUPNO;
                }
            }

            public DataColumn PROSJECNASATNICAColumn
            {
                get
                {
                    return this.columnPROSJECNASATNICA;
                }
            }

            public DataColumn PROSJECNASATNICA_85POSTOColumn
            {
                get
                {
                    return this.columnPROSJECNASATNICA_85POSTO;
                }
            }
        }

        public class S_OD_BOLOVANJE_POSLODAVACRow : DataRow
        {
            private S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACDataTable tableS_OD_BOLOVANJE_POSLODAVAC;

            internal S_OD_BOLOVANJE_POSLODAVACRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_BOLOVANJE_POSLODAVAC = (S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACDataTable) this.Table;
            }

            public bool IsGODINAMJESECNull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_POSLODAVAC.GODINAMJESECColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_POSLODAVAC.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_POSLODAVAC.IMEColumn);
            }

            public bool IsIZNOSBRUTONull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_POSLODAVAC.IZNOSBRUTOColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_POSLODAVAC.PREZIMEColumn);
            }

            public bool IsSATIUKUPNONull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_POSLODAVAC.SATIUKUPNOColumn);
            }

            public bool IsPROSJECNASATNICANull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_POSLODAVAC.PROSJECNASATNICAColumn);
            }

            public bool IsPROSJECNASATNICA_85POSTONull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_POSLODAVAC.PROSJECNASATNICA_85POSTOColumn);
            }



            public void SetGODINAMJESECNull()
            {
                this[this.tableS_OD_BOLOVANJE_POSLODAVAC.GODINAMJESECColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_OD_BOLOVANJE_POSLODAVAC.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableS_OD_BOLOVANJE_POSLODAVAC.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSBRUTONull()
            {
                this[this.tableS_OD_BOLOVANJE_POSLODAVAC.IZNOSBRUTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableS_OD_BOLOVANJE_POSLODAVAC.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSATIUKUPNONull()
            {
                this[this.tableS_OD_BOLOVANJE_POSLODAVAC.SATIUKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPROSJECNASATNICANull()
            {
                this[this.tableS_OD_BOLOVANJE_POSLODAVAC.PROSJECNASATNICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPROSJECNASATNICA_85POSTONull()
            {
                this[this.tableS_OD_BOLOVANJE_POSLODAVAC.PROSJECNASATNICA_85POSTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string GODINAMJESEC
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_BOLOVANJE_POSLODAVAC.GODINAMJESECColumn]);
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
                    this[this.tableS_OD_BOLOVANJE_POSLODAVAC.GODINAMJESECColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_BOLOVANJE_POSLODAVAC.IDRADNIKColumn]);
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
                    this[this.tableS_OD_BOLOVANJE_POSLODAVAC.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_BOLOVANJE_POSLODAVAC.IMEColumn]);
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
                    this[this.tableS_OD_BOLOVANJE_POSLODAVAC.IMEColumn] = value;
                }
            }

            public decimal IZNOSBRUTO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_BOLOVANJE_POSLODAVAC.IZNOSBRUTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IZNOSBRUTO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_POSLODAVAC.IZNOSBRUTOColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_BOLOVANJE_POSLODAVAC.PREZIMEColumn]);
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
                    this[this.tableS_OD_BOLOVANJE_POSLODAVAC.PREZIMEColumn] = value;
                }
            }

            public decimal SATIUKUPNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_BOLOVANJE_POSLODAVAC.SATIUKUPNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SATIUKUPNO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_POSLODAVAC.SATIUKUPNOColumn] = value;
                }
            }



            public decimal PROSJECNASATNICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_BOLOVANJE_POSLODAVAC.PROSJECNASATNICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_POSLODAVAC.PROSJECNASATNICAColumn] = value;
                }
            }

            public decimal PROSJECNASATNICA_85POSTO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_BOLOVANJE_POSLODAVAC.PROSJECNASATNICA_85POSTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_POSLODAVAC.PROSJECNASATNICA_85POSTOColumn] = value;
                }
            }
        }

        public class S_OD_BOLOVANJE_POSLODAVACRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow eventRow;

            public S_OD_BOLOVANJE_POSLODAVACRowChangeEvent(S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow row, DataRowAction action)
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

            public S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_BOLOVANJE_POSLODAVACRowChangeEventHandler(object sender, S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRowChangeEvent e);
    }
}

