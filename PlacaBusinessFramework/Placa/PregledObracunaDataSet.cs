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
    public class PregledObracunaDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private PregledObracunaDataTable tablePregledObracuna;

        public PregledObracunaDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected PregledObracunaDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["PregledObracuna"] != null)
                    {
                        this.Tables.Add(new PregledObracunaDataTable(dataSet.Tables["PregledObracuna"]));
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
            PregledObracunaDataSet set = (PregledObracunaDataSet) base.Clone();
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
            PregledObracunaDataSet set = new PregledObracunaDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "PregledObracunaDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2018");
            this.ExtendedProperties.Add("DataSetName", "PregledObracunaDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IPregledObracunaDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "PregledObracuna");
            this.ExtendedProperties.Add("ObjectDescription", "PregledObracuna");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
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
            this.DataSetName = "PregledObracunaDataSet";
            this.Namespace = "http://www.tempuri.org/PregledObracuna";
            this.tablePregledObracuna = new PregledObracunaDataTable();
            this.Tables.Add(this.tablePregledObracuna);
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
            this.tablePregledObracuna = (PregledObracunaDataTable) this.Tables["PregledObracuna"];
            if (initTable && (this.tablePregledObracuna != null))
            {
                this.tablePregledObracuna.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["PregledObracuna"] != null)
                {
                    this.Tables.Add(new PregledObracunaDataTable(dataSet.Tables["PregledObracuna"]));
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

        private bool ShouldSerializePregledObracuna()
        {
            return false;
        }

        protected override bool ShouldSerializeRelations()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PregledObracunaDataTable PregledObracuna
        {
            get
            {
                return this.tablePregledObracuna;
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Serializable]
        public class PregledObracunaDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDATUMISPLATE;
            private DataColumn columnDATUMOBRACUNASTAZA;
            private DataColumn columnGODINAISPLATE;
            private DataColumn columnGODINAOBRACUNA;
            private DataColumn columnIDENTIFIKATOROBRASCA;
            private DataColumn columnIDOBRACUN;
            private DataColumn columnMJESECISPLATE;
            private DataColumn columnMJESECNIFONDSATIOBRACUN;
            private DataColumn columnMJESECOBRACUNA;
            private DataColumn columnOBRACUNSKAOSNOVICA;
            private DataColumn columnOBRFIKSNIH;
            private DataColumn columnOBRKREDITNIH;
            private DataColumn columnOBRPOSTOTNIH;
            private DataColumn columnOSNOVNIOO;
            private DataColumn columnSVRHAOBRACUNA;
            private DataColumn columntjednifondsatiobracun;
            private DataColumn columnVRSTAOBRACUNA;
            private DataColumn columnZAKLJ;

            public event PregledObracunaDataSet.PregledObracunaRowChangeEventHandler PregledObracunaRowChanged;

            public event PregledObracunaDataSet.PregledObracunaRowChangeEventHandler PregledObracunaRowChanging;

            public event PregledObracunaDataSet.PregledObracunaRowChangeEventHandler PregledObracunaRowDeleted;

            public event PregledObracunaDataSet.PregledObracunaRowChangeEventHandler PregledObracunaRowDeleting;

            public PregledObracunaDataTable()
            {
                this.TableName = "PregledObracuna";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal PregledObracunaDataTable(DataTable table) : base(table.TableName)
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

            protected PregledObracunaDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPregledObracunaRow(PregledObracunaDataSet.PregledObracunaRow row)
            {
                this.Rows.Add(row);
            }

            public PregledObracunaDataSet.PregledObracunaRow AddPregledObracunaRow(string iDOBRACUN, string vRSTAOBRACUNA, string mJESECOBRACUNA, string gODINAOBRACUNA, string mJESECISPLATE, string gODINAISPLATE, DateTime dATUMISPLATE, short tjednifondsatiobracun, short mJESECNIFONDSATIOBRACUN, decimal oSNOVNIOO, decimal oBRACUNSKAOSNOVICA, DateTime dATUMOBRACUNASTAZA, bool oBRPOSTOTNIH, bool oBRFIKSNIH, bool oBRKREDITNIH, bool zAKLJ, string sVRHAOBRACUNA, string iDENTIFIKATOROBRASCA)
            {
                PregledObracunaDataSet.PregledObracunaRow row = (PregledObracunaDataSet.PregledObracunaRow) this.NewRow();
                row.ItemArray = new object[] { 
                    iDOBRACUN, vRSTAOBRACUNA, mJESECOBRACUNA, gODINAOBRACUNA, mJESECISPLATE, gODINAISPLATE, dATUMISPLATE, tjednifondsatiobracun, mJESECNIFONDSATIOBRACUN, oSNOVNIOO, oBRACUNSKAOSNOVICA, dATUMOBRACUNASTAZA, oBRPOSTOTNIH, oBRFIKSNIH, oBRKREDITNIH, zAKLJ, 
                    sVRHAOBRACUNA, iDENTIFIKATOROBRASCA
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                PregledObracunaDataSet.PregledObracunaDataTable table = (PregledObracunaDataSet.PregledObracunaDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(PregledObracunaDataSet.PregledObracunaRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                PregledObracunaDataSet set = new PregledObracunaDataSet();
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
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOBRACUN.ExtendedProperties.Add("Description", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUN");
                this.Columns.Add(this.columnIDOBRACUN);
                this.columnVRSTAOBRACUNA = new DataColumn("VRSTAOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnVRSTAOBRACUNA.Caption = "VRSTAOBRACUNA";
                this.columnVRSTAOBRACUNA.MaxLength = 2;
                this.columnVRSTAOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Description", "VRSTAOBRACUNA");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Length", "2");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "VRSTAOBRACUNA");
                this.Columns.Add(this.columnVRSTAOBRACUNA);
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
                this.columnMJESECISPLATE = new DataColumn("MJESECISPLATE", typeof(string), "", MappingType.Element);
                this.columnMJESECISPLATE.Caption = "Mjesec isplate";
                this.columnMJESECISPLATE.MaxLength = 2;
                this.columnMJESECISPLATE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("IsKey", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Description", "Mjesec isplate");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Length", "2");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESECISPLATE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.InternalName", "MJESECISPLATE");
                this.Columns.Add(this.columnMJESECISPLATE);
                this.columnGODINAISPLATE = new DataColumn("GODINAISPLATE", typeof(string), "", MappingType.Element);
                this.columnGODINAISPLATE.Caption = "Godina isplate";
                this.columnGODINAISPLATE.MaxLength = 4;
                this.columnGODINAISPLATE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnGODINAISPLATE.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINAISPLATE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnGODINAISPLATE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Description", "Godina isplate");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Length", "4");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINAISPLATE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnGODINAISPLATE.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.InternalName", "GODINAISPLATE");
                this.Columns.Add(this.columnGODINAISPLATE);
                this.columnDATUMISPLATE = new DataColumn("DATUMISPLATE", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMISPLATE.Caption = "Datum isplate";
                this.columnDATUMISPLATE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDATUMISPLATE.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMISPLATE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Description", "Datum isplate");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Length", "8");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMISPLATE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.InternalName", "DATUMISPLATE");
                this.Columns.Add(this.columnDATUMISPLATE);
                this.columntjednifondsatiobracun = new DataColumn("tjednifondsatiobracun", typeof(short), "", MappingType.Element);
                this.columntjednifondsatiobracun.Caption = "Tjedni fond sati";
                this.columntjednifondsatiobracun.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("IsKey", "false");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("ReadOnly", "true");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("DeklaritType", "int");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Description", "Tjedni fond sati");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Length", "3");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Decimals", "0");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("IsInReader", "true");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Deklarit.InternalName", "tjednifondsatiobracun");
                this.Columns.Add(this.columntjednifondsatiobracun);
                this.columnMJESECNIFONDSATIOBRACUN = new DataColumn("MJESECNIFONDSATIOBRACUN", typeof(short), "", MappingType.Element);
                this.columnMJESECNIFONDSATIOBRACUN.Caption = "Mjeseeni fond sati";
                this.columnMJESECNIFONDSATIOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("IsKey", "false");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Description", "Mjeseeni fond sati");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Length", "3");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "MJESECNIFONDSATIOBRACUN");
                this.Columns.Add(this.columnMJESECNIFONDSATIOBRACUN);
                this.columnOSNOVNIOO = new DataColumn("OSNOVNIOO", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVNIOO.Caption = "Osnovni osobni odbitak";
                this.columnOSNOVNIOO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVNIOO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVNIOO.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVNIOO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVNIOO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Description", "Osnovni osobni odbitak");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVNIOO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVNIOO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVNIOO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVNIOO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVNIOO");
                this.Columns.Add(this.columnOSNOVNIOO);
                this.columnOBRACUNSKAOSNOVICA = new DataColumn("OBRACUNSKAOSNOVICA", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNSKAOSNOVICA.Caption = "Obraeunska osnovica";
                this.columnOBRACUNSKAOSNOVICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Description", "Obraeunska osnovica");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNSKAOSNOVICA");
                this.Columns.Add(this.columnOBRACUNSKAOSNOVICA);
                this.columnDATUMOBRACUNASTAZA = new DataColumn("DATUMOBRACUNASTAZA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMOBRACUNASTAZA.Caption = "DATUMOBRACUNASTAZA";
                this.columnDATUMOBRACUNASTAZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Description", "DATUMOBRACUNASTAZA");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMOBRACUNASTAZA");
                this.Columns.Add(this.columnDATUMOBRACUNASTAZA);
                this.columnOBRPOSTOTNIH = new DataColumn("OBRPOSTOTNIH", typeof(bool), "", MappingType.Element);
                this.columnOBRPOSTOTNIH.Caption = "OBRPOSTOTNIH";
                this.columnOBRPOSTOTNIH.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Description", "OBRPOSTOTNIH");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Length", "1");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Decimals", "0");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.InternalName", "OBRPOSTOTNIH");
                this.Columns.Add(this.columnOBRPOSTOTNIH);
                this.columnOBRFIKSNIH = new DataColumn("OBRFIKSNIH", typeof(bool), "", MappingType.Element);
                this.columnOBRFIKSNIH.Caption = "OBRFIKSNIH";
                this.columnOBRFIKSNIH.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Description", "OBRFIKSNIH");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Length", "1");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Decimals", "0");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.InternalName", "OBRFIKSNIH");
                this.Columns.Add(this.columnOBRFIKSNIH);
                this.columnOBRKREDITNIH = new DataColumn("OBRKREDITNIH", typeof(bool), "", MappingType.Element);
                this.columnOBRKREDITNIH.Caption = "OBRKREDITNIH";
                this.columnOBRKREDITNIH.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Description", "OBRKREDITNIH");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Length", "1");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Decimals", "0");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.InternalName", "OBRKREDITNIH");
                this.Columns.Add(this.columnOBRKREDITNIH);
                this.columnZAKLJ = new DataColumn("ZAKLJ", typeof(bool), "", MappingType.Element);
                this.columnZAKLJ.Caption = "ZAKLJ";
                this.columnZAKLJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnZAKLJ.ExtendedProperties.Add("IsKey", "false");
                this.columnZAKLJ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZAKLJ.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnZAKLJ.ExtendedProperties.Add("Description", "ZAKLJ");
                this.columnZAKLJ.ExtendedProperties.Add("Length", "1");
                this.columnZAKLJ.ExtendedProperties.Add("Decimals", "0");
                this.columnZAKLJ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZAKLJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.InternalName", "ZAKLJ");
                this.Columns.Add(this.columnZAKLJ);
                this.columnSVRHAOBRACUNA = new DataColumn("SVRHAOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnSVRHAOBRACUNA.Caption = "SVRHAOBRACUNA";
                this.columnSVRHAOBRACUNA.MaxLength = 100;
                this.columnSVRHAOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Description", "SVRHAOBRACUNA");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Length", "100");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "SVRHAOBRACUNA");
                this.Columns.Add(this.columnSVRHAOBRACUNA);
                this.columnIDENTIFIKATOROBRASCA = new DataColumn("IDENTIFIKATOROBRASCA", typeof(string), "", MappingType.Element);
                this.columnIDENTIFIKATOROBRASCA.Caption = "IDENTIFIKATOROBRASCA";
                this.columnIDENTIFIKATOROBRASCA.MaxLength = 5;
                this.columnIDENTIFIKATOROBRASCA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Description", "IDENTIFIKATOROBRASCA");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Length", "5");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDENTIFIKATOROBRASCA.ExtendedProperties.Add("Deklarit.InternalName", "IDENTIFIKATOROBRASCA");
                this.Columns.Add(this.columnIDENTIFIKATOROBRASCA);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "PregledObracuna");
                this.ExtendedProperties.Add("Description", "VWPREGLEDOBRACUNA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
                this.columnVRSTAOBRACUNA = this.Columns["VRSTAOBRACUNA"];
                this.columnMJESECOBRACUNA = this.Columns["MJESECOBRACUNA"];
                this.columnGODINAOBRACUNA = this.Columns["GODINAOBRACUNA"];
                this.columnMJESECISPLATE = this.Columns["MJESECISPLATE"];
                this.columnGODINAISPLATE = this.Columns["GODINAISPLATE"];
                this.columnDATUMISPLATE = this.Columns["DATUMISPLATE"];
                this.columntjednifondsatiobracun = this.Columns["tjednifondsatiobracun"];
                this.columnMJESECNIFONDSATIOBRACUN = this.Columns["MJESECNIFONDSATIOBRACUN"];
                this.columnOSNOVNIOO = this.Columns["OSNOVNIOO"];
                this.columnOBRACUNSKAOSNOVICA = this.Columns["OBRACUNSKAOSNOVICA"];
                this.columnDATUMOBRACUNASTAZA = this.Columns["DATUMOBRACUNASTAZA"];
                this.columnOBRPOSTOTNIH = this.Columns["OBRPOSTOTNIH"];
                this.columnOBRFIKSNIH = this.Columns["OBRFIKSNIH"];
                this.columnOBRKREDITNIH = this.Columns["OBRKREDITNIH"];
                this.columnZAKLJ = this.Columns["ZAKLJ"];
                this.columnSVRHAOBRACUNA = this.Columns["SVRHAOBRACUNA"];
                this.columnIDENTIFIKATOROBRASCA = this.Columns["IDENTIFIKATOROBRASCA"];
            }

            public PregledObracunaDataSet.PregledObracunaRow NewPregledObracunaRow()
            {
                return (PregledObracunaDataSet.PregledObracunaRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PregledObracunaDataSet.PregledObracunaRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PregledObracunaRowChanged != null)
                {
                    PregledObracunaDataSet.PregledObracunaRowChangeEventHandler pregledObracunaRowChangedEvent = this.PregledObracunaRowChanged;
                    if (pregledObracunaRowChangedEvent != null)
                    {
                        pregledObracunaRowChangedEvent(this, new PregledObracunaDataSet.PregledObracunaRowChangeEvent((PregledObracunaDataSet.PregledObracunaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PregledObracunaRowChanging != null)
                {
                    PregledObracunaDataSet.PregledObracunaRowChangeEventHandler pregledObracunaRowChangingEvent = this.PregledObracunaRowChanging;
                    if (pregledObracunaRowChangingEvent != null)
                    {
                        pregledObracunaRowChangingEvent(this, new PregledObracunaDataSet.PregledObracunaRowChangeEvent((PregledObracunaDataSet.PregledObracunaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PregledObracunaRowDeleted != null)
                {
                    PregledObracunaDataSet.PregledObracunaRowChangeEventHandler pregledObracunaRowDeletedEvent = this.PregledObracunaRowDeleted;
                    if (pregledObracunaRowDeletedEvent != null)
                    {
                        pregledObracunaRowDeletedEvent(this, new PregledObracunaDataSet.PregledObracunaRowChangeEvent((PregledObracunaDataSet.PregledObracunaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PregledObracunaRowDeleting != null)
                {
                    PregledObracunaDataSet.PregledObracunaRowChangeEventHandler pregledObracunaRowDeletingEvent = this.PregledObracunaRowDeleting;
                    if (pregledObracunaRowDeletingEvent != null)
                    {
                        pregledObracunaRowDeletingEvent(this, new PregledObracunaDataSet.PregledObracunaRowChangeEvent((PregledObracunaDataSet.PregledObracunaRow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePregledObracunaRow(PregledObracunaDataSet.PregledObracunaRow row)
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

            public DataColumn DATUMISPLATEColumn
            {
                get
                {
                    return this.columnDATUMISPLATE;
                }
            }

            public DataColumn DATUMOBRACUNASTAZAColumn
            {
                get
                {
                    return this.columnDATUMOBRACUNASTAZA;
                }
            }

            public DataColumn GODINAISPLATEColumn
            {
                get
                {
                    return this.columnGODINAISPLATE;
                }
            }

            public DataColumn GODINAOBRACUNAColumn
            {
                get
                {
                    return this.columnGODINAOBRACUNA;
                }
            }

            public DataColumn IDENTIFIKATOROBRASCAColumn
            {
                get
                {
                    return this.columnIDENTIFIKATOROBRASCA;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public PregledObracunaDataSet.PregledObracunaRow this[int index]
            {
                get
                {
                    return (PregledObracunaDataSet.PregledObracunaRow) this.Rows[index];
                }
            }

            public DataColumn MJESECISPLATEColumn
            {
                get
                {
                    return this.columnMJESECISPLATE;
                }
            }

            public DataColumn MJESECNIFONDSATIOBRACUNColumn
            {
                get
                {
                    return this.columnMJESECNIFONDSATIOBRACUN;
                }
            }

            public DataColumn MJESECOBRACUNAColumn
            {
                get
                {
                    return this.columnMJESECOBRACUNA;
                }
            }

            public DataColumn OBRACUNSKAOSNOVICAColumn
            {
                get
                {
                    return this.columnOBRACUNSKAOSNOVICA;
                }
            }

            public DataColumn OBRFIKSNIHColumn
            {
                get
                {
                    return this.columnOBRFIKSNIH;
                }
            }

            public DataColumn OBRKREDITNIHColumn
            {
                get
                {
                    return this.columnOBRKREDITNIH;
                }
            }

            public DataColumn OBRPOSTOTNIHColumn
            {
                get
                {
                    return this.columnOBRPOSTOTNIH;
                }
            }

            public DataColumn OSNOVNIOOColumn
            {
                get
                {
                    return this.columnOSNOVNIOO;
                }
            }

            public DataColumn SVRHAOBRACUNAColumn
            {
                get
                {
                    return this.columnSVRHAOBRACUNA;
                }
            }

            public DataColumn tjednifondsatiobracunColumn
            {
                get
                {
                    return this.columntjednifondsatiobracun;
                }
            }

            public DataColumn VRSTAOBRACUNAColumn
            {
                get
                {
                    return this.columnVRSTAOBRACUNA;
                }
            }

            public DataColumn ZAKLJColumn
            {
                get
                {
                    return this.columnZAKLJ;
                }
            }
        }

        public class PregledObracunaRow : DataRow
        {
            private PregledObracunaDataSet.PregledObracunaDataTable tablePregledObracuna;

            internal PregledObracunaRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePregledObracuna = (PregledObracunaDataSet.PregledObracunaDataTable) this.Table;
            }

            public bool IsDATUMISPLATENull()
            {
                return this.IsNull(this.tablePregledObracuna.DATUMISPLATEColumn);
            }

            public bool IsDATUMOBRACUNASTAZANull()
            {
                return this.IsNull(this.tablePregledObracuna.DATUMOBRACUNASTAZAColumn);
            }

            public bool IsGODINAISPLATENull()
            {
                return this.IsNull(this.tablePregledObracuna.GODINAISPLATEColumn);
            }

            public bool IsGODINAOBRACUNANull()
            {
                return this.IsNull(this.tablePregledObracuna.GODINAOBRACUNAColumn);
            }

            public bool IsIDENTIFIKATOROBRASCANull()
            {
                return this.IsNull(this.tablePregledObracuna.IDENTIFIKATOROBRASCAColumn);
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tablePregledObracuna.IDOBRACUNColumn);
            }

            public bool IsMJESECISPLATENull()
            {
                return this.IsNull(this.tablePregledObracuna.MJESECISPLATEColumn);
            }

            public bool IsMJESECNIFONDSATIOBRACUNNull()
            {
                return this.IsNull(this.tablePregledObracuna.MJESECNIFONDSATIOBRACUNColumn);
            }

            public bool IsMJESECOBRACUNANull()
            {
                return this.IsNull(this.tablePregledObracuna.MJESECOBRACUNAColumn);
            }

            public bool IsOBRACUNSKAOSNOVICANull()
            {
                return this.IsNull(this.tablePregledObracuna.OBRACUNSKAOSNOVICAColumn);
            }

            public bool IsOBRFIKSNIHNull()
            {
                return this.IsNull(this.tablePregledObracuna.OBRFIKSNIHColumn);
            }

            public bool IsOBRKREDITNIHNull()
            {
                return this.IsNull(this.tablePregledObracuna.OBRKREDITNIHColumn);
            }

            public bool IsOBRPOSTOTNIHNull()
            {
                return this.IsNull(this.tablePregledObracuna.OBRPOSTOTNIHColumn);
            }

            public bool IsOSNOVNIOONull()
            {
                return this.IsNull(this.tablePregledObracuna.OSNOVNIOOColumn);
            }

            public bool IsSVRHAOBRACUNANull()
            {
                return this.IsNull(this.tablePregledObracuna.SVRHAOBRACUNAColumn);
            }

            public bool IstjednifondsatiobracunNull()
            {
                return this.IsNull(this.tablePregledObracuna.tjednifondsatiobracunColumn);
            }

            public bool IsVRSTAOBRACUNANull()
            {
                return this.IsNull(this.tablePregledObracuna.VRSTAOBRACUNAColumn);
            }

            public bool IsZAKLJNull()
            {
                return this.IsNull(this.tablePregledObracuna.ZAKLJColumn);
            }

            public void SetDATUMISPLATENull()
            {
                this[this.tablePregledObracuna.DATUMISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMOBRACUNASTAZANull()
            {
                this[this.tablePregledObracuna.DATUMOBRACUNASTAZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGODINAISPLATENull()
            {
                this[this.tablePregledObracuna.GODINAISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGODINAOBRACUNANull()
            {
                this[this.tablePregledObracuna.GODINAOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDENTIFIKATOROBRASCANull()
            {
                this[this.tablePregledObracuna.IDENTIFIKATOROBRASCAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDOBRACUNNull()
            {
                this[this.tablePregledObracuna.IDOBRACUNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECISPLATENull()
            {
                this[this.tablePregledObracuna.MJESECISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECNIFONDSATIOBRACUNNull()
            {
                this[this.tablePregledObracuna.MJESECNIFONDSATIOBRACUNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECOBRACUNANull()
            {
                this[this.tablePregledObracuna.MJESECOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNSKAOSNOVICANull()
            {
                this[this.tablePregledObracuna.OBRACUNSKAOSNOVICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRFIKSNIHNull()
            {
                this[this.tablePregledObracuna.OBRFIKSNIHColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRKREDITNIHNull()
            {
                this[this.tablePregledObracuna.OBRKREDITNIHColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRPOSTOTNIHNull()
            {
                this[this.tablePregledObracuna.OBRPOSTOTNIHColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVNIOONull()
            {
                this[this.tablePregledObracuna.OSNOVNIOOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSVRHAOBRACUNANull()
            {
                this[this.tablePregledObracuna.SVRHAOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SettjednifondsatiobracunNull()
            {
                this[this.tablePregledObracuna.tjednifondsatiobracunColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVRSTAOBRACUNANull()
            {
                this[this.tablePregledObracuna.VRSTAOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZAKLJNull()
            {
                this[this.tablePregledObracuna.ZAKLJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public DateTime DATUMISPLATE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tablePregledObracuna.DATUMISPLATEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DATUMISPLATE because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tablePregledObracuna.DATUMISPLATEColumn] = value;
                }
            }

            public DateTime DATUMOBRACUNASTAZA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tablePregledObracuna.DATUMOBRACUNASTAZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tablePregledObracuna.DATUMOBRACUNASTAZAColumn] = value;
                }
            }

            public string GODINAISPLATE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePregledObracuna.GODINAISPLATEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePregledObracuna.GODINAISPLATEColumn] = value;
                }
            }

            public string GODINAOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePregledObracuna.GODINAOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePregledObracuna.GODINAOBRACUNAColumn] = value;
                }
            }

            public string IDENTIFIKATOROBRASCA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePregledObracuna.IDENTIFIKATOROBRASCAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePregledObracuna.IDENTIFIKATOROBRASCAColumn] = value;
                }
            }

            public string IDOBRACUN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePregledObracuna.IDOBRACUNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePregledObracuna.IDOBRACUNColumn] = value;
                }
            }

            public string MJESECISPLATE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePregledObracuna.MJESECISPLATEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePregledObracuna.MJESECISPLATEColumn] = value;
                }
            }

            public short MJESECNIFONDSATIOBRACUN
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tablePregledObracuna.MJESECNIFONDSATIOBRACUNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePregledObracuna.MJESECNIFONDSATIOBRACUNColumn] = value;
                }
            }

            public string MJESECOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePregledObracuna.MJESECOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePregledObracuna.MJESECOBRACUNAColumn] = value;
                }
            }

            public decimal OBRACUNSKAOSNOVICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePregledObracuna.OBRACUNSKAOSNOVICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePregledObracuna.OBRACUNSKAOSNOVICAColumn] = value;
                }
            }

            public bool OBRFIKSNIH
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tablePregledObracuna.OBRFIKSNIHColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tablePregledObracuna.OBRFIKSNIHColumn] = value;
                }
            }

            public bool OBRKREDITNIH
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tablePregledObracuna.OBRKREDITNIHColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tablePregledObracuna.OBRKREDITNIHColumn] = value;
                }
            }

            public bool OBRPOSTOTNIH
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tablePregledObracuna.OBRPOSTOTNIHColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tablePregledObracuna.OBRPOSTOTNIHColumn] = value;
                }
            }

            public decimal OSNOVNIOO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePregledObracuna.OSNOVNIOOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePregledObracuna.OSNOVNIOOColumn] = value;
                }
            }

            public string SVRHAOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePregledObracuna.SVRHAOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePregledObracuna.SVRHAOBRACUNAColumn] = value;
                }
            }

            public short tjednifondsatiobracun
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tablePregledObracuna.tjednifondsatiobracunColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePregledObracuna.tjednifondsatiobracunColumn] = value;
                }
            }

            public string VRSTAOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePregledObracuna.VRSTAOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePregledObracuna.VRSTAOBRACUNAColumn] = value;
                }
            }

            public bool ZAKLJ
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tablePregledObracuna.ZAKLJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tablePregledObracuna.ZAKLJColumn] = value;
                }
            }
        }

        public class PregledObracunaRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private PregledObracunaDataSet.PregledObracunaRow eventRow;

            public PregledObracunaRowChangeEvent(PregledObracunaDataSet.PregledObracunaRow row, DataRowAction action)
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

            public PregledObracunaDataSet.PregledObracunaRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PregledObracunaRowChangeEventHandler(object sender, PregledObracunaDataSet.PregledObracunaRowChangeEvent e);
    }
}

