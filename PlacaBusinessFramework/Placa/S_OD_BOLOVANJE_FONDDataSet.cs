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
    public class S_OD_BOLOVANJE_FONDDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_BOLOVANJE_FONDDataTable tableS_OD_BOLOVANJE_FOND;

        public S_OD_BOLOVANJE_FONDDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_BOLOVANJE_FONDDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_BOLOVANJE_FOND"] != null)
                    {
                        this.Tables.Add(new S_OD_BOLOVANJE_FONDDataTable(dataSet.Tables["S_OD_BOLOVANJE_FOND"]));
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
            S_OD_BOLOVANJE_FONDDataSet set = (S_OD_BOLOVANJE_FONDDataSet) base.Clone();
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
            S_OD_BOLOVANJE_FONDDataSet set = new S_OD_BOLOVANJE_FONDDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_BOLOVANJE_FONDDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2075");
            this.ExtendedProperties.Add("DataSetName", "S_OD_BOLOVANJE_FONDDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_BOLOVANJE_FONDDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_BOLOVANJE_FOND");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_BOLOVANJE_FOND");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_BOLOVANJE_FOND");
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
            this.DataSetName = "S_OD_BOLOVANJE_FONDDataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_BOLOVANJE_FOND";
            this.tableS_OD_BOLOVANJE_FOND = new S_OD_BOLOVANJE_FONDDataTable();
            this.Tables.Add(this.tableS_OD_BOLOVANJE_FOND);
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
            this.tableS_OD_BOLOVANJE_FOND = (S_OD_BOLOVANJE_FONDDataTable) this.Tables["S_OD_BOLOVANJE_FOND"];
            if (initTable && (this.tableS_OD_BOLOVANJE_FOND != null))
            {
                this.tableS_OD_BOLOVANJE_FOND.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_BOLOVANJE_FOND"] != null)
                {
                    this.Tables.Add(new S_OD_BOLOVANJE_FONDDataTable(dataSet.Tables["S_OD_BOLOVANJE_FOND"]));
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

        private bool ShouldSerializeS_OD_BOLOVANJE_FOND()
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
        public S_OD_BOLOVANJE_FONDDataTable S_OD_BOLOVANJE_FOND
        {
            get
            {
                return this.tableS_OD_BOLOVANJE_FOND;
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
        public class S_OD_BOLOVANJE_FONDDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJZDRAVSTVENOG;
            private DataColumn columnFONDMJESECA;
            private DataColumn columnGODINAOBRACUNA;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnJMBG;
            private DataColumn columnKOLONA4;
            private DataColumn columnKOLONA5;
            private DataColumn columnKOLONA6;
            private DataColumn columnKOLONA8;
            private DataColumn columnMJESECOBRACUNA;
            private DataColumn columnnetoplaca;
            private DataColumn columnOIB;
            private DataColumn columnPREZIME;
            private DataColumn columnSATIUKUPNO;
            private DataColumn columnukupnobruto;

            public event S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRowChangeEventHandler S_OD_BOLOVANJE_FONDRowChanged;

            public event S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRowChangeEventHandler S_OD_BOLOVANJE_FONDRowChanging;

            public event S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRowChangeEventHandler S_OD_BOLOVANJE_FONDRowDeleted;

            public event S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRowChangeEventHandler S_OD_BOLOVANJE_FONDRowDeleting;

            public S_OD_BOLOVANJE_FONDDataTable()
            {
                this.TableName = "S_OD_BOLOVANJE_FOND";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_BOLOVANJE_FONDDataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_BOLOVANJE_FONDDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_BOLOVANJE_FONDRow(S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow AddS_OD_BOLOVANJE_FONDRow(int iDRADNIK, string pREZIME, string iME, string jMBG, string mJESECOBRACUNA, string gODINAOBRACUNA, decimal kOLONA4, decimal kOLONA5, decimal kOLONA6, decimal kOLONA8, decimal sATIUKUPNO, decimal ukupnobruto, decimal netoplaca, short fONDMJESECA, string oIB, string bROJZDRAVSTVENOG)
            {
                S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow row = (S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow) this.NewRow();
                row.ItemArray = new object[] { iDRADNIK, pREZIME, iME, jMBG, mJESECOBRACUNA, gODINAOBRACUNA, kOLONA4, kOLONA5, kOLONA6, kOLONA8, sATIUKUPNO, ukupnobruto, netoplaca, fONDMJESECA, oIB, bROJZDRAVSTVENOG };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDDataTable table = (S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_BOLOVANJE_FONDDataSet set = new S_OD_BOLOVANJE_FONDDataSet();
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
                this.columnMJESECOBRACUNA = new DataColumn("MJESECOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnMJESECOBRACUNA.Caption = "Mjesec obraeuna";
                this.columnMJESECOBRACUNA.MaxLength = 2;
                this.columnMJESECOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Description", "Mjesec obraeuna");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Length", "2");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "MJESECOBRACUNA");
                this.Columns.Add(this.columnMJESECOBRACUNA);
                this.columnGODINAOBRACUNA = new DataColumn("GODINAOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnGODINAOBRACUNA.Caption = "Godina obraeuna";
                this.columnGODINAOBRACUNA.MaxLength = 4;
                this.columnGODINAOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Description", "Godina obraeuna");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Length", "4");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "GODINAOBRACUNA");
                this.Columns.Add(this.columnGODINAOBRACUNA);
                this.columnKOLONA4 = new DataColumn("KOLONA4", typeof(decimal), "", MappingType.Element);
                this.columnKOLONA4.Caption = "KOLON A4";
                this.columnKOLONA4.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOLONA4.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOLONA4.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOLONA4.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOLONA4.ExtendedProperties.Add("IsKey", "false");
                this.columnKOLONA4.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOLONA4.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOLONA4.ExtendedProperties.Add("Description", "KOLON A4");
                this.columnKOLONA4.ExtendedProperties.Add("Length", "12");
                this.columnKOLONA4.ExtendedProperties.Add("Decimals", "2");
                this.columnKOLONA4.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOLONA4.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOLONA4.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKOLONA4.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOLONA4.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOLONA4.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOLONA4.ExtendedProperties.Add("Deklarit.InternalName", "KOLONA4");
                this.Columns.Add(this.columnKOLONA4);
                this.columnKOLONA5 = new DataColumn("KOLONA5", typeof(decimal), "", MappingType.Element);
                this.columnKOLONA5.Caption = "KOLON A5";
                this.columnKOLONA5.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOLONA5.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOLONA5.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOLONA5.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOLONA5.ExtendedProperties.Add("IsKey", "false");
                this.columnKOLONA5.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOLONA5.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOLONA5.ExtendedProperties.Add("Description", "KOLON A5");
                this.columnKOLONA5.ExtendedProperties.Add("Length", "12");
                this.columnKOLONA5.ExtendedProperties.Add("Decimals", "2");
                this.columnKOLONA5.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOLONA5.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOLONA5.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKOLONA5.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOLONA5.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOLONA5.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOLONA5.ExtendedProperties.Add("Deklarit.InternalName", "KOLONA5");
                this.Columns.Add(this.columnKOLONA5);
                this.columnKOLONA6 = new DataColumn("KOLONA6", typeof(decimal), "", MappingType.Element);
                this.columnKOLONA6.Caption = "KOLON A6";
                this.columnKOLONA6.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOLONA6.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOLONA6.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOLONA6.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOLONA6.ExtendedProperties.Add("IsKey", "false");
                this.columnKOLONA6.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOLONA6.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOLONA6.ExtendedProperties.Add("Description", "KOLON A6");
                this.columnKOLONA6.ExtendedProperties.Add("Length", "12");
                this.columnKOLONA6.ExtendedProperties.Add("Decimals", "2");
                this.columnKOLONA6.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOLONA6.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOLONA6.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKOLONA6.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOLONA6.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOLONA6.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOLONA6.ExtendedProperties.Add("Deklarit.InternalName", "KOLONA6");
                this.Columns.Add(this.columnKOLONA6);
                this.columnKOLONA8 = new DataColumn("KOLONA8", typeof(decimal), "", MappingType.Element);
                this.columnKOLONA8.Caption = "KOLON A8";
                this.columnKOLONA8.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOLONA8.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOLONA8.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOLONA8.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOLONA8.ExtendedProperties.Add("IsKey", "false");
                this.columnKOLONA8.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOLONA8.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOLONA8.ExtendedProperties.Add("Description", "KOLON A8");
                this.columnKOLONA8.ExtendedProperties.Add("Length", "12");
                this.columnKOLONA8.ExtendedProperties.Add("Decimals", "2");
                this.columnKOLONA8.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOLONA8.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOLONA8.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKOLONA8.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOLONA8.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOLONA8.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOLONA8.ExtendedProperties.Add("Deklarit.InternalName", "KOLONA8");
                this.Columns.Add(this.columnKOLONA8);
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
                this.columnFONDMJESECA = new DataColumn("FONDMJESECA", typeof(short), "", MappingType.Element);
                this.columnFONDMJESECA.Caption = "Fond sati mjeseca";
                this.columnFONDMJESECA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnFONDMJESECA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnFONDMJESECA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnFONDMJESECA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnFONDMJESECA.ExtendedProperties.Add("IsKey", "false");
                this.columnFONDMJESECA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnFONDMJESECA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnFONDMJESECA.ExtendedProperties.Add("Description", "Fond sati mjeseca");
                this.columnFONDMJESECA.ExtendedProperties.Add("Length", "3");
                this.columnFONDMJESECA.ExtendedProperties.Add("Decimals", "0");
                this.columnFONDMJESECA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnFONDMJESECA.ExtendedProperties.Add("IsInReader", "true");
                this.columnFONDMJESECA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnFONDMJESECA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnFONDMJESECA.ExtendedProperties.Add("Deklarit.InternalName", "FONDMJESECA");
                this.Columns.Add(this.columnFONDMJESECA);
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
                this.columnBROJZDRAVSTVENOG = new DataColumn("BROJZDRAVSTVENOG", typeof(string), "", MappingType.Element);
                this.columnBROJZDRAVSTVENOG.Caption = "Broj zdravstvenog osiguranja";
                this.columnBROJZDRAVSTVENOG.MaxLength = 50;
                this.columnBROJZDRAVSTVENOG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Description", "Broj zdravstvenog osiguranja");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Length", "50");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.InternalName", "BROJZDRAVSTVENOG");
                this.Columns.Add(this.columnBROJZDRAVSTVENOG);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_BOLOVANJE_FOND");
                this.ExtendedProperties.Add("Description", "S_OD_BOLOVANJE_FOND");
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
                this.columnMJESECOBRACUNA = this.Columns["MJESECOBRACUNA"];
                this.columnGODINAOBRACUNA = this.Columns["GODINAOBRACUNA"];
                this.columnKOLONA4 = this.Columns["KOLONA4"];
                this.columnKOLONA5 = this.Columns["KOLONA5"];
                this.columnKOLONA6 = this.Columns["KOLONA6"];
                this.columnKOLONA8 = this.Columns["KOLONA8"];
                this.columnSATIUKUPNO = this.Columns["SATIUKUPNO"];
                this.columnukupnobruto = this.Columns["ukupnobruto"];
                this.columnnetoplaca = this.Columns["netoplaca"];
                this.columnFONDMJESECA = this.Columns["FONDMJESECA"];
                this.columnOIB = this.Columns["OIB"];
                this.columnBROJZDRAVSTVENOG = this.Columns["BROJZDRAVSTVENOG"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow(builder);
            }

            public S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow NewS_OD_BOLOVANJE_FONDRow()
            {
                return (S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_BOLOVANJE_FONDRowChanged != null)
                {
                    S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRowChangeEventHandler handler = this.S_OD_BOLOVANJE_FONDRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRowChangeEvent((S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_BOLOVANJE_FONDRowChanging != null)
                {
                    S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRowChangeEventHandler handler = this.S_OD_BOLOVANJE_FONDRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRowChangeEvent((S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_BOLOVANJE_FONDRowDeleted != null)
                {
                    S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRowChangeEventHandler handler = this.S_OD_BOLOVANJE_FONDRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRowChangeEvent((S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_BOLOVANJE_FONDRowDeleting != null)
                {
                    S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRowChangeEventHandler handler = this.S_OD_BOLOVANJE_FONDRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRowChangeEvent((S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_BOLOVANJE_FONDRow(S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJZDRAVSTVENOGColumn
            {
                get
                {
                    return this.columnBROJZDRAVSTVENOG;
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

            public DataColumn FONDMJESECAColumn
            {
                get
                {
                    return this.columnFONDMJESECA;
                }
            }

            public DataColumn GODINAOBRACUNAColumn
            {
                get
                {
                    return this.columnGODINAOBRACUNA;
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

            public S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow this[int index]
            {
                get
                {
                    return (S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow) this.Rows[index];
                }
            }

            public DataColumn JMBGColumn
            {
                get
                {
                    return this.columnJMBG;
                }
            }

            public DataColumn KOLONA4Column
            {
                get
                {
                    return this.columnKOLONA4;
                }
            }

            public DataColumn KOLONA5Column
            {
                get
                {
                    return this.columnKOLONA5;
                }
            }

            public DataColumn KOLONA6Column
            {
                get
                {
                    return this.columnKOLONA6;
                }
            }

            public DataColumn KOLONA8Column
            {
                get
                {
                    return this.columnKOLONA8;
                }
            }

            public DataColumn MJESECOBRACUNAColumn
            {
                get
                {
                    return this.columnMJESECOBRACUNA;
                }
            }

            public DataColumn netoplacaColumn
            {
                get
                {
                    return this.columnnetoplaca;
                }
            }

            public DataColumn OIBColumn
            {
                get
                {
                    return this.columnOIB;
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

            public DataColumn ukupnobrutoColumn
            {
                get
                {
                    return this.columnukupnobruto;
                }
            }
        }

        public class S_OD_BOLOVANJE_FONDRow : DataRow
        {
            private S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDDataTable tableS_OD_BOLOVANJE_FOND;

            internal S_OD_BOLOVANJE_FONDRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_BOLOVANJE_FOND = (S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDDataTable) this.Table;
            }

            public bool IsBROJZDRAVSTVENOGNull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.BROJZDRAVSTVENOGColumn);
            }

            public bool IsFONDMJESECANull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.FONDMJESECAColumn);
            }

            public bool IsGODINAOBRACUNANull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.GODINAOBRACUNAColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.IMEColumn);
            }

            public bool IsJMBGNull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.JMBGColumn);
            }

            public bool IsKOLONA4Null()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.KOLONA4Column);
            }

            public bool IsKOLONA5Null()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.KOLONA5Column);
            }

            public bool IsKOLONA6Null()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.KOLONA6Column);
            }

            public bool IsKOLONA8Null()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.KOLONA8Column);
            }

            public bool IsMJESECOBRACUNANull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.MJESECOBRACUNAColumn);
            }

            public bool IsnetoplacaNull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.netoplacaColumn);
            }

            public bool IsOIBNull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.OIBColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.PREZIMEColumn);
            }

            public bool IsSATIUKUPNONull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.SATIUKUPNOColumn);
            }

            public bool IsukupnobrutoNull()
            {
                return this.IsNull(this.tableS_OD_BOLOVANJE_FOND.ukupnobrutoColumn);
            }

            public void SetBROJZDRAVSTVENOGNull()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.BROJZDRAVSTVENOGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFONDMJESECANull()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.FONDMJESECAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGODINAOBRACUNANull()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.GODINAOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGNull()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.JMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOLONA4Null()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.KOLONA4Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOLONA5Null()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.KOLONA5Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOLONA6Null()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.KOLONA6Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOLONA8Null()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.KOLONA8Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECOBRACUNANull()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.MJESECOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoplacaNull()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.netoplacaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOIBNull()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.OIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSATIUKUPNONull()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.SATIUKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnobrutoNull()
            {
                this[this.tableS_OD_BOLOVANJE_FOND.ukupnobrutoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string BROJZDRAVSTVENOG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_BOLOVANJE_FOND.BROJZDRAVSTVENOGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.BROJZDRAVSTVENOGColumn] = value;
                }
            }

            public short FONDMJESECA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableS_OD_BOLOVANJE_FOND.FONDMJESECAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.FONDMJESECAColumn] = value;
                }
            }

            public string GODINAOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_BOLOVANJE_FOND.GODINAOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.GODINAOBRACUNAColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_BOLOVANJE_FOND.IDRADNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_BOLOVANJE_FOND.IMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.IMEColumn] = value;
                }
            }

            public string JMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_BOLOVANJE_FOND.JMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.JMBGColumn] = value;
                }
            }

            public decimal KOLONA4
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_BOLOVANJE_FOND.KOLONA4Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.KOLONA4Column] = value;
                }
            }

            public decimal KOLONA5
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_BOLOVANJE_FOND.KOLONA5Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.KOLONA5Column] = value;
                }
            }

            public decimal KOLONA6
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_BOLOVANJE_FOND.KOLONA6Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.KOLONA6Column] = value;
                }
            }

            public decimal KOLONA8
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_BOLOVANJE_FOND.KOLONA8Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.KOLONA8Column] = value;
                }
            }

            public string MJESECOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_BOLOVANJE_FOND.MJESECOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.MJESECOBRACUNAColumn] = value;
                }
            }

            public decimal netoplaca
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_BOLOVANJE_FOND.netoplacaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.netoplacaColumn] = value;
                }
            }

            public string OIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_BOLOVANJE_FOND.OIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.OIBColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_BOLOVANJE_FOND.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.PREZIMEColumn] = value;
                }
            }

            public decimal SATIUKUPNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_BOLOVANJE_FOND.SATIUKUPNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.SATIUKUPNOColumn] = value;
                }
            }

            public decimal ukupnobruto
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_BOLOVANJE_FOND.ukupnobrutoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_BOLOVANJE_FOND.ukupnobrutoColumn] = value;
                }
            }
        }

        public class S_OD_BOLOVANJE_FONDRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow eventRow;

            public S_OD_BOLOVANJE_FONDRowChangeEvent(S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow row, DataRowAction action)
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

            public S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_BOLOVANJE_FONDRowChangeEventHandler(object sender, S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRowChangeEvent e);
    }
}

