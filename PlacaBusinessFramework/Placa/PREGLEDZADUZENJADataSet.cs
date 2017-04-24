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
    public class PREGLEDZADUZENJADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private PARTNERZADUZENJEDataTable tablePARTNERZADUZENJE;

        public PREGLEDZADUZENJADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected PREGLEDZADUZENJADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["PARTNERZADUZENJE"] != null)
                    {
                        this.Tables.Add(new PARTNERZADUZENJEDataTable(dataSet.Tables["PARTNERZADUZENJE"]));
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
            PREGLEDZADUZENJADataSet set = (PREGLEDZADUZENJADataSet) base.Clone();
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
            PREGLEDZADUZENJADataSet set = new PREGLEDZADUZENJADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "PREGLEDZADUZENJADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2009");
            this.ExtendedProperties.Add("DataSetName", "PREGLEDZADUZENJADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IPREGLEDZADUZENJADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "PREGLEDZADUZENJA");
            this.ExtendedProperties.Add("ObjectDescription", "PREGLEDZADUZENJA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
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
            this.DataSetName = "PREGLEDZADUZENJADataSet";
            this.Namespace = "http://www.tempuri.org/PREGLEDZADUZENJA";
            this.tablePARTNERZADUZENJE = new PARTNERZADUZENJEDataTable();
            this.Tables.Add(this.tablePARTNERZADUZENJE);
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
            this.tablePARTNERZADUZENJE = (PARTNERZADUZENJEDataTable) this.Tables["PARTNERZADUZENJE"];
            if (initTable && (this.tablePARTNERZADUZENJE != null))
            {
                this.tablePARTNERZADUZENJE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["PARTNERZADUZENJE"] != null)
                {
                    this.Tables.Add(new PARTNERZADUZENJEDataTable(dataSet.Tables["PARTNERZADUZENJE"]));
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

        private bool ShouldSerializePARTNERZADUZENJE()
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
        public PARTNERZADUZENJEDataTable PARTNERZADUZENJE
        {
            get
            {
                return this.tablePARTNERZADUZENJE;
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
        public class PARTNERZADUZENJEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAKTIVNO;
            private DataColumn columnCIJENAZADUZENJA;
            private DataColumn columnCIJENAZAFAKTURU;
            private DataColumn columnDATUMUGOVORA;
            private DataColumn columnFINPOREZSTOPA;
            private DataColumn columnIDPARTNER;
            private DataColumn columnIDPROIZVOD;
            private DataColumn columnIDZADUZENJE;
            private DataColumn columnIZNOSRABATAZADUZENJE;
            private DataColumn columnIZNOSZADUZENJA;
            private DataColumn columnKOLICINAZADUZENJA;
            private DataColumn columnNAZIVPARTNER;
            private DataColumn columnNAZIVPROIZVOD;
            private DataColumn columnPARTNEROIB;
            private DataColumn columnRABATZADUZENJA;
            private DataColumn columnUGOVORBROJ;

            public event PREGLEDZADUZENJADataSet.PARTNERZADUZENJERowChangeEventHandler PARTNERZADUZENJERowChanged;

            public event PREGLEDZADUZENJADataSet.PARTNERZADUZENJERowChangeEventHandler PARTNERZADUZENJERowChanging;

            public event PREGLEDZADUZENJADataSet.PARTNERZADUZENJERowChangeEventHandler PARTNERZADUZENJERowDeleted;

            public event PREGLEDZADUZENJADataSet.PARTNERZADUZENJERowChangeEventHandler PARTNERZADUZENJERowDeleting;

            public PARTNERZADUZENJEDataTable()
            {
                this.TableName = "PARTNERZADUZENJE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal PARTNERZADUZENJEDataTable(DataTable table) : base(table.TableName)
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

            protected PARTNERZADUZENJEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPARTNERZADUZENJERow(PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow row)
            {
                this.Rows.Add(row);
            }

            public PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow AddPARTNERZADUZENJERow(int iDPARTNER, string nAZIVPARTNER, string pARTNEROIB, string nAZIVPROIZVOD, int iDPROIZVOD, int iDZADUZENJE, decimal kOLICINAZADUZENJA, decimal cIJENAZADUZENJA, decimal fINPOREZSTOPA, decimal iZNOSZADUZENJA, decimal rABATZADUZENJA, decimal iZNOSRABATAZADUZENJE, decimal cIJENAZAFAKTURU, string uGOVORBROJ, DateTime dATUMUGOVORA, bool aKTIVNO)
            {
                PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow row = (PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow) this.NewRow();
                row.ItemArray = new object[] { iDPARTNER, nAZIVPARTNER, pARTNEROIB, nAZIVPROIZVOD, iDPROIZVOD, iDZADUZENJE, kOLICINAZADUZENJA, cIJENAZADUZENJA, fINPOREZSTOPA, iZNOSZADUZENJA, rABATZADUZENJA, iZNOSRABATAZADUZENJE, cIJENAZAFAKTURU, uGOVORBROJ, dATUMUGOVORA, aKTIVNO };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                PREGLEDZADUZENJADataSet.PARTNERZADUZENJEDataTable table = (PREGLEDZADUZENJADataSet.PARTNERZADUZENJEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                PREGLEDZADUZENJADataSet set = new PREGLEDZADUZENJADataSet();
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
                this.columnIDPARTNER = new DataColumn("IDPARTNER", typeof(int), "", MappingType.Element);
                this.columnIDPARTNER.Caption = "Šifra partnera";
                this.columnIDPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPARTNER.ExtendedProperties.Add("Description", "Šifra partnera");
                this.columnIDPARTNER.ExtendedProperties.Add("Length", "9");
                this.columnIDPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "IDPARTNER");
                this.Columns.Add(this.columnIDPARTNER);
                this.columnNAZIVPARTNER = new DataColumn("NAZIVPARTNER", typeof(string), "", MappingType.Element);
                this.columnNAZIVPARTNER.Caption = "Naziv partnera";
                this.columnNAZIVPARTNER.MaxLength = 100;
                this.columnNAZIVPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Description", "Naziv partnera");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPARTNER");
                this.Columns.Add(this.columnNAZIVPARTNER);
                this.columnPARTNEROIB = new DataColumn("PARTNEROIB", typeof(string), "", MappingType.Element);
                this.columnPARTNEROIB.Caption = "PARTNEROIB";
                this.columnPARTNEROIB.MaxLength = 11;
                this.columnPARTNEROIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNEROIB.ExtendedProperties.Add("Description", "PARTNEROIB");
                this.columnPARTNEROIB.ExtendedProperties.Add("Length", "11");
                this.columnPARTNEROIB.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNEROIB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.InternalName", "PARTNEROIB");
                this.Columns.Add(this.columnPARTNEROIB);
                this.columnNAZIVPROIZVOD = new DataColumn("NAZIVPROIZVOD", typeof(string), "", MappingType.Element);
                this.columnNAZIVPROIZVOD.Caption = "NAZIVPROIZVOD";
                this.columnNAZIVPROIZVOD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Description", "NAZIVPROIZVOD");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Length", "500");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPROIZVOD");
                this.Columns.Add(this.columnNAZIVPROIZVOD);
                this.columnIDPROIZVOD = new DataColumn("IDPROIZVOD", typeof(int), "", MappingType.Element);
                this.columnIDPROIZVOD.Caption = "IDPROIZVOD";
                this.columnIDPROIZVOD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("IsKey", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDPROIZVOD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Description", "IDPROIZVOD");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Length", "5");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPROIZVOD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.InternalName", "IDPROIZVOD");
                this.Columns.Add(this.columnIDPROIZVOD);
                this.columnIDZADUZENJE = new DataColumn("IDZADUZENJE", typeof(int), "", MappingType.Element);
                this.columnIDZADUZENJE.Caption = "Zaduženje";
                this.columnIDZADUZENJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDZADUZENJE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDZADUZENJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDZADUZENJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Description", "Zaduženje");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Length", "5");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDZADUZENJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDZADUZENJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.InternalName", "IDZADUZENJE");
                this.Columns.Add(this.columnIDZADUZENJE);
                this.columnKOLICINAZADUZENJA = new DataColumn("KOLICINAZADUZENJA", typeof(decimal), "", MappingType.Element);
                this.columnKOLICINAZADUZENJA.Caption = "KOLICINAZADUZENJA";
                this.columnKOLICINAZADUZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Description", "KOLICINAZADUZENJA");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Length", "5");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Decimals", "2");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.InternalName", "KOLICINAZADUZENJA");
                this.Columns.Add(this.columnKOLICINAZADUZENJA);
                this.columnCIJENAZADUZENJA = new DataColumn("CIJENAZADUZENJA", typeof(decimal), "", MappingType.Element);
                this.columnCIJENAZADUZENJA.Caption = "CIJENAZADUZENJA";
                this.columnCIJENAZADUZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Description", "CIJENAZADUZENJA");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Length", "12");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Decimals", "2");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.InternalName", "CIJENAZADUZENJA");
                this.Columns.Add(this.columnCIJENAZADUZENJA);
                this.columnFINPOREZSTOPA = new DataColumn("FINPOREZSTOPA", typeof(decimal), "", MappingType.Element);
                this.columnFINPOREZSTOPA.Caption = "FINPOREZSTOPA";
                this.columnFINPOREZSTOPA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Description", "FINPOREZSTOPA");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Length", "5");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("IsInReader", "true");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnFINPOREZSTOPA.ExtendedProperties.Add("Deklarit.InternalName", "FINPOREZSTOPA");
                this.Columns.Add(this.columnFINPOREZSTOPA);
                this.columnIZNOSZADUZENJA = new DataColumn("IZNOSZADUZENJA", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSZADUZENJA.Caption = "IZNOSZADUZENJA";
                this.columnIZNOSZADUZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Description", "IZNOSZADUZENJA");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSZADUZENJA");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnIZNOSZADUZENJA);
                this.columnRABATZADUZENJA = new DataColumn("RABATZADUZENJA", typeof(decimal), "", MappingType.Element);
                this.columnRABATZADUZENJA.Caption = "RABATZADUZENJA";
                this.columnRABATZADUZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Description", "RABATZADUZENJA");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Length", "5");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Decimals", "2");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.InternalName", "RABATZADUZENJA");
                this.Columns.Add(this.columnRABATZADUZENJA);
                this.columnIZNOSRABATAZADUZENJE = new DataColumn("IZNOSRABATAZADUZENJE", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSRABATAZADUZENJE.Caption = "IZNOSRABATAZADUZENJE";
                this.columnIZNOSRABATAZADUZENJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Description", "IZNOSRABATAZADUZENJE");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSRABATAZADUZENJE");
                this.Columns.Add(this.columnIZNOSRABATAZADUZENJE);
                this.columnCIJENAZAFAKTURU = new DataColumn("CIJENAZAFAKTURU", typeof(decimal), "", MappingType.Element);
                this.columnCIJENAZAFAKTURU.Caption = "CIJENAZAFAKTURU";
                this.columnCIJENAZAFAKTURU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("IsKey", "false");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("ReadOnly", "true");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Description", "CIJENAZAFAKTURU");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Length", "12");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Decimals", "2");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.InternalName", "CIJENAZAFAKTURU");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnCIJENAZAFAKTURU);
                this.columnUGOVORBROJ = new DataColumn("UGOVORBROJ", typeof(string), "", MappingType.Element);
                this.columnUGOVORBROJ.Caption = "UGOVORBROJ";
                this.columnUGOVORBROJ.MaxLength = 200;
                this.columnUGOVORBROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUGOVORBROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnUGOVORBROJ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUGOVORBROJ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Description", "UGOVORBROJ");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Length", "200");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnUGOVORBROJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnUGOVORBROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.InternalName", "UGOVORBROJ");
                this.Columns.Add(this.columnUGOVORBROJ);
                this.columnDATUMUGOVORA = new DataColumn("DATUMUGOVORA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMUGOVORA.Caption = "DATUMUGOVORA";
                this.columnDATUMUGOVORA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Description", "DATUMUGOVORA");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMUGOVORA");
                this.Columns.Add(this.columnDATUMUGOVORA);
                this.columnAKTIVNO = new DataColumn("AKTIVNO", typeof(bool), "", MappingType.Element);
                this.columnAKTIVNO.Caption = "AKTIVNO";
                this.columnAKTIVNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnAKTIVNO.ExtendedProperties.Add("IsKey", "false");
                this.columnAKTIVNO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnAKTIVNO.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnAKTIVNO.ExtendedProperties.Add("Description", "AKTIVNO");
                this.columnAKTIVNO.ExtendedProperties.Add("Length", "1");
                this.columnAKTIVNO.ExtendedProperties.Add("Decimals", "0");
                this.columnAKTIVNO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnAKTIVNO.ExtendedProperties.Add("IsInReader", "true");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.InternalName", "AKTIVNO");
                this.Columns.Add(this.columnAKTIVNO);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "PREGLEDZADUZENJA");
                this.ExtendedProperties.Add("Description", "Zaduzenja partnera");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDPARTNER = this.Columns["IDPARTNER"];
                this.columnNAZIVPARTNER = this.Columns["NAZIVPARTNER"];
                this.columnPARTNEROIB = this.Columns["PARTNEROIB"];
                this.columnNAZIVPROIZVOD = this.Columns["NAZIVPROIZVOD"];
                this.columnIDPROIZVOD = this.Columns["IDPROIZVOD"];
                this.columnIDZADUZENJE = this.Columns["IDZADUZENJE"];
                this.columnKOLICINAZADUZENJA = this.Columns["KOLICINAZADUZENJA"];
                this.columnCIJENAZADUZENJA = this.Columns["CIJENAZADUZENJA"];
                this.columnFINPOREZSTOPA = this.Columns["FINPOREZSTOPA"];
                this.columnIZNOSZADUZENJA = this.Columns["IZNOSZADUZENJA"];
                this.columnRABATZADUZENJA = this.Columns["RABATZADUZENJA"];
                this.columnIZNOSRABATAZADUZENJE = this.Columns["IZNOSRABATAZADUZENJE"];
                this.columnCIJENAZAFAKTURU = this.Columns["CIJENAZAFAKTURU"];
                this.columnUGOVORBROJ = this.Columns["UGOVORBROJ"];
                this.columnDATUMUGOVORA = this.Columns["DATUMUGOVORA"];
                this.columnAKTIVNO = this.Columns["AKTIVNO"];
            }

            public PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow NewPARTNERZADUZENJERow()
            {
                return (PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PARTNERZADUZENJERowChanged != null)
                {
                    PREGLEDZADUZENJADataSet.PARTNERZADUZENJERowChangeEventHandler pARTNERZADUZENJERowChangedEvent = this.PARTNERZADUZENJERowChanged;
                    if (pARTNERZADUZENJERowChangedEvent != null)
                    {
                        pARTNERZADUZENJERowChangedEvent(this, new PREGLEDZADUZENJADataSet.PARTNERZADUZENJERowChangeEvent((PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PARTNERZADUZENJERowChanging != null)
                {
                    PREGLEDZADUZENJADataSet.PARTNERZADUZENJERowChangeEventHandler pARTNERZADUZENJERowChangingEvent = this.PARTNERZADUZENJERowChanging;
                    if (pARTNERZADUZENJERowChangingEvent != null)
                    {
                        pARTNERZADUZENJERowChangingEvent(this, new PREGLEDZADUZENJADataSet.PARTNERZADUZENJERowChangeEvent((PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PARTNERZADUZENJERowDeleted != null)
                {
                    PREGLEDZADUZENJADataSet.PARTNERZADUZENJERowChangeEventHandler pARTNERZADUZENJERowDeletedEvent = this.PARTNERZADUZENJERowDeleted;
                    if (pARTNERZADUZENJERowDeletedEvent != null)
                    {
                        pARTNERZADUZENJERowDeletedEvent(this, new PREGLEDZADUZENJADataSet.PARTNERZADUZENJERowChangeEvent((PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PARTNERZADUZENJERowDeleting != null)
                {
                    PREGLEDZADUZENJADataSet.PARTNERZADUZENJERowChangeEventHandler pARTNERZADUZENJERowDeletingEvent = this.PARTNERZADUZENJERowDeleting;
                    if (pARTNERZADUZENJERowDeletingEvent != null)
                    {
                        pARTNERZADUZENJERowDeletingEvent(this, new PREGLEDZADUZENJADataSet.PARTNERZADUZENJERowChangeEvent((PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePARTNERZADUZENJERow(PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn AKTIVNOColumn
            {
                get
                {
                    return this.columnAKTIVNO;
                }
            }

            public DataColumn CIJENAZADUZENJAColumn
            {
                get
                {
                    return this.columnCIJENAZADUZENJA;
                }
            }

            public DataColumn CIJENAZAFAKTURUColumn
            {
                get
                {
                    return this.columnCIJENAZAFAKTURU;
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

            public DataColumn DATUMUGOVORAColumn
            {
                get
                {
                    return this.columnDATUMUGOVORA;
                }
            }

            public DataColumn FINPOREZSTOPAColumn
            {
                get
                {
                    return this.columnFINPOREZSTOPA;
                }
            }

            public DataColumn IDPARTNERColumn
            {
                get
                {
                    return this.columnIDPARTNER;
                }
            }

            public DataColumn IDPROIZVODColumn
            {
                get
                {
                    return this.columnIDPROIZVOD;
                }
            }

            public DataColumn IDZADUZENJEColumn
            {
                get
                {
                    return this.columnIDZADUZENJE;
                }
            }

            public PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow this[int index]
            {
                get
                {
                    return (PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow) this.Rows[index];
                }
            }

            public DataColumn IZNOSRABATAZADUZENJEColumn
            {
                get
                {
                    return this.columnIZNOSRABATAZADUZENJE;
                }
            }

            public DataColumn IZNOSZADUZENJAColumn
            {
                get
                {
                    return this.columnIZNOSZADUZENJA;
                }
            }

            public DataColumn KOLICINAZADUZENJAColumn
            {
                get
                {
                    return this.columnKOLICINAZADUZENJA;
                }
            }

            public DataColumn NAZIVPARTNERColumn
            {
                get
                {
                    return this.columnNAZIVPARTNER;
                }
            }

            public DataColumn NAZIVPROIZVODColumn
            {
                get
                {
                    return this.columnNAZIVPROIZVOD;
                }
            }

            public DataColumn PARTNEROIBColumn
            {
                get
                {
                    return this.columnPARTNEROIB;
                }
            }

            public DataColumn RABATZADUZENJAColumn
            {
                get
                {
                    return this.columnRABATZADUZENJA;
                }
            }

            public DataColumn UGOVORBROJColumn
            {
                get
                {
                    return this.columnUGOVORBROJ;
                }
            }
        }

        public class PARTNERZADUZENJERow : DataRow
        {
            private PREGLEDZADUZENJADataSet.PARTNERZADUZENJEDataTable tablePARTNERZADUZENJE;

            internal PARTNERZADUZENJERow(DataRowBuilder rb) : base(rb)
            {
                this.tablePARTNERZADUZENJE = (PREGLEDZADUZENJADataSet.PARTNERZADUZENJEDataTable) this.Table;
            }

            public bool IsAKTIVNONull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.AKTIVNOColumn);
            }

            public bool IsCIJENAZADUZENJANull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.CIJENAZADUZENJAColumn);
            }

            public bool IsCIJENAZAFAKTURUNull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.CIJENAZAFAKTURUColumn);
            }

            public bool IsDATUMUGOVORANull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.DATUMUGOVORAColumn);
            }

            public bool IsFINPOREZSTOPANull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.FINPOREZSTOPAColumn);
            }

            public bool IsIDPARTNERNull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.IDPARTNERColumn);
            }

            public bool IsIDPROIZVODNull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.IDPROIZVODColumn);
            }

            public bool IsIDZADUZENJENull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.IDZADUZENJEColumn);
            }

            public bool IsIZNOSRABATAZADUZENJENull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.IZNOSRABATAZADUZENJEColumn);
            }

            public bool IsIZNOSZADUZENJANull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.IZNOSZADUZENJAColumn);
            }

            public bool IsKOLICINAZADUZENJANull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.KOLICINAZADUZENJAColumn);
            }

            public bool IsNAZIVPARTNERNull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.NAZIVPARTNERColumn);
            }

            public bool IsNAZIVPROIZVODNull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.NAZIVPROIZVODColumn);
            }

            public bool IsPARTNEROIBNull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.PARTNEROIBColumn);
            }

            public bool IsRABATZADUZENJANull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.RABATZADUZENJAColumn);
            }

            public bool IsUGOVORBROJNull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.UGOVORBROJColumn);
            }

            public void SetAKTIVNONull()
            {
                this[this.tablePARTNERZADUZENJE.AKTIVNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetCIJENAZADUZENJANull()
            {
                this[this.tablePARTNERZADUZENJE.CIJENAZADUZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetCIJENAZAFAKTURUNull()
            {
                this[this.tablePARTNERZADUZENJE.CIJENAZAFAKTURUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMUGOVORANull()
            {
                this[this.tablePARTNERZADUZENJE.DATUMUGOVORAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFINPOREZSTOPANull()
            {
                this[this.tablePARTNERZADUZENJE.FINPOREZSTOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDPARTNERNull()
            {
                this[this.tablePARTNERZADUZENJE.IDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDPROIZVODNull()
            {
                this[this.tablePARTNERZADUZENJE.IDPROIZVODColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDZADUZENJENull()
            {
                this[this.tablePARTNERZADUZENJE.IDZADUZENJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSRABATAZADUZENJENull()
            {
                this[this.tablePARTNERZADUZENJE.IZNOSRABATAZADUZENJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSZADUZENJANull()
            {
                this[this.tablePARTNERZADUZENJE.IZNOSZADUZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOLICINAZADUZENJANull()
            {
                this[this.tablePARTNERZADUZENJE.KOLICINAZADUZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPARTNERNull()
            {
                this[this.tablePARTNERZADUZENJE.NAZIVPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPROIZVODNull()
            {
                this[this.tablePARTNERZADUZENJE.NAZIVPROIZVODColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNEROIBNull()
            {
                this[this.tablePARTNERZADUZENJE.PARTNEROIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRABATZADUZENJANull()
            {
                this[this.tablePARTNERZADUZENJE.RABATZADUZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUGOVORBROJNull()
            {
                this[this.tablePARTNERZADUZENJE.UGOVORBROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool AKTIVNO
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tablePARTNERZADUZENJE.AKTIVNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value AKTIVNO because it is DBNull.", innerException);
                    }
                    return flag;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.AKTIVNOColumn] = value;
                }
            }

            public decimal CIJENAZADUZENJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.CIJENAZADUZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value CIJENAZADUZENJA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.CIJENAZADUZENJAColumn] = value;
                }
            }

            public decimal CIJENAZAFAKTURU
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.CIJENAZAFAKTURUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value CIJENAZAFAKTURU because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.CIJENAZAFAKTURUColumn] = value;
                }
            }

            public DateTime DATUMUGOVORA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tablePARTNERZADUZENJE.DATUMUGOVORAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.DATUMUGOVORAColumn] = value;
                }
            }

            public decimal FINPOREZSTOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.FINPOREZSTOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.FINPOREZSTOPAColumn] = value;
                }
            }

            public int IDPARTNER
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablePARTNERZADUZENJE.IDPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.IDPARTNERColumn] = value;
                }
            }

            public int IDPROIZVOD
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablePARTNERZADUZENJE.IDPROIZVODColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.IDPROIZVODColumn] = value;
                }
            }

            public int IDZADUZENJE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablePARTNERZADUZENJE.IDZADUZENJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.IDZADUZENJEColumn] = value;
                }
            }

            public decimal IZNOSRABATAZADUZENJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.IZNOSRABATAZADUZENJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.IZNOSRABATAZADUZENJEColumn] = value;
                }
            }

            public decimal IZNOSZADUZENJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.IZNOSZADUZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.IZNOSZADUZENJAColumn] = value;
                }
            }

            public decimal KOLICINAZADUZENJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.KOLICINAZADUZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.KOLICINAZADUZENJAColumn] = value;
                }
            }

            public string NAZIVPARTNER
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNERZADUZENJE.NAZIVPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.NAZIVPARTNERColumn] = value;
                }
            }

            public string NAZIVPROIZVOD
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNERZADUZENJE.NAZIVPROIZVODColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.NAZIVPROIZVODColumn] = value;
                }
            }

            public string PARTNEROIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNERZADUZENJE.PARTNEROIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.PARTNEROIBColumn] = value;
                }
            }

            public decimal RABATZADUZENJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.RABATZADUZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.RABATZADUZENJAColumn] = value;
                }
            }

            public string UGOVORBROJ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNERZADUZENJE.UGOVORBROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.UGOVORBROJColumn] = value;
                }
            }
        }

        public class PARTNERZADUZENJERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow eventRow;

            public PARTNERZADUZENJERowChangeEvent(PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow row, DataRowAction action)
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

            public PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PARTNERZADUZENJERowChangeEventHandler(object sender, PREGLEDZADUZENJADataSet.PARTNERZADUZENJERowChangeEvent e);
    }
}

