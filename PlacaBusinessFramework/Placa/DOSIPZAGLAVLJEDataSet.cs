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
    public class DOSIPZAGLAVLJEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private DOSIPZAGLAVLJEDataTable tableDOSIPZAGLAVLJE;
        private DOSIPZAGLAVLJELevel1DataTable tableDOSIPZAGLAVLJELevel1;

        public DOSIPZAGLAVLJEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected DOSIPZAGLAVLJEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["DOSIPZAGLAVLJELevel1"] != null)
                    {
                        this.Tables.Add(new DOSIPZAGLAVLJELevel1DataTable(dataSet.Tables["DOSIPZAGLAVLJELevel1"]));
                    }
                    if (dataSet.Tables["DOSIPZAGLAVLJE"] != null)
                    {
                        this.Tables.Add(new DOSIPZAGLAVLJEDataTable(dataSet.Tables["DOSIPZAGLAVLJE"]));
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
            DOSIPZAGLAVLJEDataSet set = (DOSIPZAGLAVLJEDataSet) base.Clone();
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
            DOSIPZAGLAVLJEDataSet set = new DOSIPZAGLAVLJEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "DOSIPZAGLAVLJEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2067");
            this.ExtendedProperties.Add("DataSetName", "DOSIPZAGLAVLJEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IDOSIPZAGLAVLJEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "DOSIPZAGLAVLJE");
            this.ExtendedProperties.Add("ObjectDescription", "DOSIPZAGLAVLJE");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "DOSIPZAGLAVLJEDataSet";
            this.Namespace = "http://www.tempuri.org/DOSIPZAGLAVLJE";
            this.tableDOSIPZAGLAVLJELevel1 = new DOSIPZAGLAVLJELevel1DataTable();
            this.Tables.Add(this.tableDOSIPZAGLAVLJELevel1);
            this.tableDOSIPZAGLAVLJE = new DOSIPZAGLAVLJEDataTable();
            this.Tables.Add(this.tableDOSIPZAGLAVLJE);
            this.Relations.Add("DOSIPZAGLAVLJE_DOSIPZAGLAVLJELevel1", new DataColumn[] { this.Tables["DOSIPZAGLAVLJE"].Columns["DOSIPIDENT"], this.Tables["DOSIPZAGLAVLJE"].Columns["DOSJMBG"] }, new DataColumn[] { this.Tables["DOSIPZAGLAVLJELevel1"].Columns["DOSIPIDENT"], this.Tables["DOSIPZAGLAVLJELevel1"].Columns["DOSJMBG"] });
            this.Relations["DOSIPZAGLAVLJE_DOSIPZAGLAVLJELevel1"].Nested = true;
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
            this.tableDOSIPZAGLAVLJELevel1 = (DOSIPZAGLAVLJELevel1DataTable) this.Tables["DOSIPZAGLAVLJELevel1"];
            this.tableDOSIPZAGLAVLJE = (DOSIPZAGLAVLJEDataTable) this.Tables["DOSIPZAGLAVLJE"];
            if (initTable)
            {
                if (this.tableDOSIPZAGLAVLJELevel1 != null)
                {
                    this.tableDOSIPZAGLAVLJELevel1.InitVars();
                }
                if (this.tableDOSIPZAGLAVLJE != null)
                {
                    this.tableDOSIPZAGLAVLJE.InitVars();
                }
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["DOSIPZAGLAVLJELevel1"] != null)
                {
                    this.Tables.Add(new DOSIPZAGLAVLJELevel1DataTable(dataSet.Tables["DOSIPZAGLAVLJELevel1"]));
                }
                if (dataSet.Tables["DOSIPZAGLAVLJE"] != null)
                {
                    this.Tables.Add(new DOSIPZAGLAVLJEDataTable(dataSet.Tables["DOSIPZAGLAVLJE"]));
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

        private bool ShouldSerializeDOSIPZAGLAVLJE()
        {
            return false;
        }

        private bool ShouldSerializeDOSIPZAGLAVLJELevel1()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DOSIPZAGLAVLJEDataTable DOSIPZAGLAVLJE
        {
            get
            {
                return this.tableDOSIPZAGLAVLJE;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DOSIPZAGLAVLJELevel1DataTable DOSIPZAGLAVLJELevel1
        {
            get
            {
                return this.tableDOSIPZAGLAVLJELevel1;
            }
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Serializable]
        public class DOSIPZAGLAVLJEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDOSIPIDENT;
            private DataColumn columnDOSISPLATAUGODINI;
            private DataColumn columnDOSISPLATAZAGODINU;
            private DataColumn columnDOSJMBG;
            private DataColumn columnDOSOZNACEN;

            public event DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERowChangeEventHandler DOSIPZAGLAVLJERowChanged;

            public event DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERowChangeEventHandler DOSIPZAGLAVLJERowChanging;

            public event DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERowChangeEventHandler DOSIPZAGLAVLJERowDeleted;

            public event DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERowChangeEventHandler DOSIPZAGLAVLJERowDeleting;

            public DOSIPZAGLAVLJEDataTable()
            {
                this.TableName = "DOSIPZAGLAVLJE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DOSIPZAGLAVLJEDataTable(DataTable table) : base(table.TableName)
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

            protected DOSIPZAGLAVLJEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDOSIPZAGLAVLJERow(DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow row)
            {
                this.Rows.Add(row);
            }

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow AddDOSIPZAGLAVLJERow(string dOSIPIDENT, string dOSJMBG, string dOSISPLATAUGODINI, string dOSISPLATAZAGODINU, bool dOSOZNACEN)
            {
                DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow row = (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow) this.NewRow();
                row["DOSIPIDENT"] = dOSIPIDENT;
                row["DOSJMBG"] = dOSJMBG;
                row["DOSISPLATAUGODINI"] = dOSISPLATAUGODINI;
                row["DOSISPLATAZAGODINU"] = dOSISPLATAZAGODINU;
                row["DOSOZNACEN"] = dOSOZNACEN;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJEDataTable table = (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow FindByDOSIPIDENTDOSJMBG(string dOSIPIDENT, string dOSJMBG)
            {
                return (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow) this.Rows.Find(new object[] { dOSIPIDENT, dOSJMBG });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DOSIPZAGLAVLJEDataSet set = new DOSIPZAGLAVLJEDataSet();
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
                this.columnDOSIPIDENT = new DataColumn("DOSIPIDENT", typeof(string), "", MappingType.Element);
                this.columnDOSIPIDENT.AllowDBNull = false;
                this.columnDOSIPIDENT.Caption = "DOSIPIDENT";
                this.columnDOSIPIDENT.MaxLength = 2;
                this.columnDOSIPIDENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSIPIDENT.ExtendedProperties.Add("IsKey", "true");
                this.columnDOSIPIDENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSIPIDENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Description", "DOSIPIDENT");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Length", "2");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Decimals", "0");
                this.columnDOSIPIDENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSIPIDENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.InternalName", "DOSIPIDENT");
                this.Columns.Add(this.columnDOSIPIDENT);
                this.columnDOSJMBG = new DataColumn("DOSJMBG", typeof(string), "", MappingType.Element);
                this.columnDOSJMBG.AllowDBNull = false;
                this.columnDOSJMBG.Caption = "DOSJMBG";
                this.columnDOSJMBG.MaxLength = 13;
                this.columnDOSJMBG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSJMBG.ExtendedProperties.Add("IsKey", "true");
                this.columnDOSJMBG.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSJMBG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDOSJMBG.ExtendedProperties.Add("Description", "DOSJMBG");
                this.columnDOSJMBG.ExtendedProperties.Add("Length", "13");
                this.columnDOSJMBG.ExtendedProperties.Add("Decimals", "0");
                this.columnDOSJMBG.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSJMBG.ExtendedProperties.Add("IsInReader", "true");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.InternalName", "DOSJMBG");
                this.Columns.Add(this.columnDOSJMBG);
                this.columnDOSISPLATAUGODINI = new DataColumn("DOSISPLATAUGODINI", typeof(string), "", MappingType.Element);
                this.columnDOSISPLATAUGODINI.AllowDBNull = false;
                this.columnDOSISPLATAUGODINI.Caption = "DOSISPLATAUGODINI";
                this.columnDOSISPLATAUGODINI.MaxLength = 4;
                this.columnDOSISPLATAUGODINI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("Description", "DOSISPLATAUGODINI");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("Length", "4");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("Decimals", "0");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("IsInReader", "true");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSISPLATAUGODINI.ExtendedProperties.Add("Deklarit.InternalName", "DOSISPLATAUGODINI");
                this.Columns.Add(this.columnDOSISPLATAUGODINI);
                this.columnDOSISPLATAZAGODINU = new DataColumn("DOSISPLATAZAGODINU", typeof(string), "", MappingType.Element);
                this.columnDOSISPLATAZAGODINU.AllowDBNull = false;
                this.columnDOSISPLATAZAGODINU.Caption = "DOSISPLATAZAGODINU";
                this.columnDOSISPLATAZAGODINU.MaxLength = 4;
                this.columnDOSISPLATAZAGODINU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("Description", "DOSISPLATAZAGODINU");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("Length", "4");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("Decimals", "0");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("IsInReader", "true");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSISPLATAZAGODINU.ExtendedProperties.Add("Deklarit.InternalName", "DOSISPLATAZAGODINU");
                this.Columns.Add(this.columnDOSISPLATAZAGODINU);
                this.columnDOSOZNACEN = new DataColumn("DOSOZNACEN", typeof(bool), "", MappingType.Element);
                this.columnDOSOZNACEN.AllowDBNull = false;
                this.columnDOSOZNACEN.Caption = "DOSOZNACEN";
                this.columnDOSOZNACEN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSOZNACEN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSOZNACEN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSOZNACEN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSOZNACEN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSOZNACEN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSOZNACEN.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSOZNACEN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSOZNACEN.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnDOSOZNACEN.ExtendedProperties.Add("Description", "DOSOZNACEN");
                this.columnDOSOZNACEN.ExtendedProperties.Add("Length", "1");
                this.columnDOSOZNACEN.ExtendedProperties.Add("Decimals", "0");
                this.columnDOSOZNACEN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSOZNACEN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDOSOZNACEN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSOZNACEN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSOZNACEN.ExtendedProperties.Add("Deklarit.InternalName", "DOSOZNACEN");
                this.Columns.Add(this.columnDOSOZNACEN);
                this.PrimaryKey = new DataColumn[] { this.columnDOSIPIDENT, this.columnDOSJMBG };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "DOSIPZAGLAVLJE");
                this.ExtendedProperties.Add("Description", "DOSIPZAGLAVLJE");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnDOSIPIDENT = this.Columns["DOSIPIDENT"];
                this.columnDOSJMBG = this.Columns["DOSJMBG"];
                this.columnDOSISPLATAUGODINI = this.Columns["DOSISPLATAUGODINI"];
                this.columnDOSISPLATAZAGODINU = this.Columns["DOSISPLATAZAGODINU"];
                this.columnDOSOZNACEN = this.Columns["DOSOZNACEN"];
            }

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow NewDOSIPZAGLAVLJERow()
            {
                return (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DOSIPZAGLAVLJERowChanged != null)
                {
                    DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERowChangeEventHandler dOSIPZAGLAVLJERowChangedEvent = this.DOSIPZAGLAVLJERowChanged;
                    if (dOSIPZAGLAVLJERowChangedEvent != null)
                    {
                        dOSIPZAGLAVLJERowChangedEvent(this, new DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERowChangeEvent((DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DOSIPZAGLAVLJERowChanging != null)
                {
                    DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERowChangeEventHandler dOSIPZAGLAVLJERowChangingEvent = this.DOSIPZAGLAVLJERowChanging;
                    if (dOSIPZAGLAVLJERowChangingEvent != null)
                    {
                        dOSIPZAGLAVLJERowChangingEvent(this, new DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERowChangeEvent((DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DOSIPZAGLAVLJERowDeleted != null)
                {
                    DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERowChangeEventHandler dOSIPZAGLAVLJERowDeletedEvent = this.DOSIPZAGLAVLJERowDeleted;
                    if (dOSIPZAGLAVLJERowDeletedEvent != null)
                    {
                        dOSIPZAGLAVLJERowDeletedEvent(this, new DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERowChangeEvent((DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DOSIPZAGLAVLJERowDeleting != null)
                {
                    DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERowChangeEventHandler dOSIPZAGLAVLJERowDeletingEvent = this.DOSIPZAGLAVLJERowDeleting;
                    if (dOSIPZAGLAVLJERowDeletingEvent != null)
                    {
                        dOSIPZAGLAVLJERowDeletingEvent(this, new DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERowChangeEvent((DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDOSIPZAGLAVLJERow(DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow row)
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

            public DataColumn DOSIPIDENTColumn
            {
                get
                {
                    return this.columnDOSIPIDENT;
                }
            }

            public DataColumn DOSISPLATAUGODINIColumn
            {
                get
                {
                    return this.columnDOSISPLATAUGODINI;
                }
            }

            public DataColumn DOSISPLATAZAGODINUColumn
            {
                get
                {
                    return this.columnDOSISPLATAZAGODINU;
                }
            }

            public DataColumn DOSJMBGColumn
            {
                get
                {
                    return this.columnDOSJMBG;
                }
            }

            public DataColumn DOSOZNACENColumn
            {
                get
                {
                    return this.columnDOSOZNACEN;
                }
            }

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow this[int index]
            {
                get
                {
                    return (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow) this.Rows[index];
                }
            }
        }

        [Serializable]
        public class DOSIPZAGLAVLJELevel1DataTable : DataTable, IEnumerable
        {
            private DataColumn columnDOSDOHODAK;
            private DataColumn columnDOSIDOPCINESTANOVANJA;
            private DataColumn columnDOSIPIDENT;
            private DataColumn columnDOSJMBG;
            private DataColumn columnDOSMJESECISPLATE;
            private DataColumn columnDOSPOREZNAOSNOVICA;
            private DataColumn columnDOSPOSEBANPOREZ;
            private DataColumn columnDOSUKUPNOBRUTO;
            private DataColumn columnDOSUKUPNODOPRINOSI;
            private DataColumn columnDOSUKUPNONETOISPLATA;
            private DataColumn columnDOSUKUPNOOLAKSICE;
            private DataColumn columnDOSUKUPNOOO;
            private DataColumn columnDOSUKUPNOPOREZIPRIREZ;

            public event DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1RowChangeEventHandler DOSIPZAGLAVLJELevel1RowChanged;

            public event DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1RowChangeEventHandler DOSIPZAGLAVLJELevel1RowChanging;

            public event DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1RowChangeEventHandler DOSIPZAGLAVLJELevel1RowDeleted;

            public event DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1RowChangeEventHandler DOSIPZAGLAVLJELevel1RowDeleting;

            public DOSIPZAGLAVLJELevel1DataTable()
            {
                this.TableName = "DOSIPZAGLAVLJELevel1";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DOSIPZAGLAVLJELevel1DataTable(DataTable table) : base(table.TableName)
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

            protected DOSIPZAGLAVLJELevel1DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDOSIPZAGLAVLJELevel1Row(DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row row)
            {
                this.Rows.Add(row);
            }

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row AddDOSIPZAGLAVLJELevel1Row(string dOSIPIDENT, string dOSJMBG, string dOSMJESECISPLATE, string dOSIDOPCINESTANOVANJA, decimal dOSUKUPNOBRUTO, decimal dOSUKUPNODOPRINOSI, decimal dOSUKUPNOOLAKSICE, decimal dOSDOHODAK, decimal dOSUKUPNOOO, decimal dOSPOREZNAOSNOVICA, decimal dOSUKUPNOPOREZIPRIREZ, decimal dOSUKUPNONETOISPLATA, decimal dOSPOSEBANPOREZ)
            {
                DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row row = (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row) this.NewRow();
                row["DOSIPIDENT"] = dOSIPIDENT;
                row["DOSJMBG"] = dOSJMBG;
                row["DOSMJESECISPLATE"] = dOSMJESECISPLATE;
                row["DOSIDOPCINESTANOVANJA"] = dOSIDOPCINESTANOVANJA;
                row["DOSUKUPNOBRUTO"] = dOSUKUPNOBRUTO;
                row["DOSUKUPNODOPRINOSI"] = dOSUKUPNODOPRINOSI;
                row["DOSUKUPNOOLAKSICE"] = dOSUKUPNOOLAKSICE;
                row["DOSDOHODAK"] = dOSDOHODAK;
                row["DOSUKUPNOOO"] = dOSUKUPNOOO;
                row["DOSPOREZNAOSNOVICA"] = dOSPOREZNAOSNOVICA;
                row["DOSUKUPNOPOREZIPRIREZ"] = dOSUKUPNOPOREZIPRIREZ;
                row["DOSUKUPNONETOISPLATA"] = dOSUKUPNONETOISPLATA;
                row["DOSPOSEBANPOREZ"] = dOSPOSEBANPOREZ;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1DataTable table = (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row FindByDOSIPIDENTDOSJMBGDOSMJESECISPLATE(string dOSIPIDENT, string dOSJMBG, string dOSMJESECISPLATE)
            {
                return (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row) this.Rows.Find(new object[] { dOSIPIDENT, dOSJMBG, dOSMJESECISPLATE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DOSIPZAGLAVLJEDataSet set = new DOSIPZAGLAVLJEDataSet();
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
                this.columnDOSIPIDENT = new DataColumn("DOSIPIDENT", typeof(string), "", MappingType.Element);
                this.columnDOSIPIDENT.AllowDBNull = false;
                this.columnDOSIPIDENT.Caption = "DOSIPIDENT";
                this.columnDOSIPIDENT.MaxLength = 2;
                this.columnDOSIPIDENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSIPIDENT.ExtendedProperties.Add("IsKey", "true");
                this.columnDOSIPIDENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDOSIPIDENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Description", "DOSIPIDENT");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Length", "2");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Decimals", "0");
                this.columnDOSIPIDENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSIPIDENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSIPIDENT.ExtendedProperties.Add("Deklarit.InternalName", "DOSIPIDENT");
                this.Columns.Add(this.columnDOSIPIDENT);
                this.columnDOSJMBG = new DataColumn("DOSJMBG", typeof(string), "", MappingType.Element);
                this.columnDOSJMBG.AllowDBNull = false;
                this.columnDOSJMBG.Caption = "DOSJMBG";
                this.columnDOSJMBG.MaxLength = 13;
                this.columnDOSJMBG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSJMBG.ExtendedProperties.Add("IsKey", "true");
                this.columnDOSJMBG.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDOSJMBG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDOSJMBG.ExtendedProperties.Add("Description", "DOSJMBG");
                this.columnDOSJMBG.ExtendedProperties.Add("Length", "13");
                this.columnDOSJMBG.ExtendedProperties.Add("Decimals", "0");
                this.columnDOSJMBG.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSJMBG.ExtendedProperties.Add("IsInReader", "true");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSJMBG.ExtendedProperties.Add("Deklarit.InternalName", "DOSJMBG");
                this.Columns.Add(this.columnDOSJMBG);
                this.columnDOSMJESECISPLATE = new DataColumn("DOSMJESECISPLATE", typeof(string), "", MappingType.Element);
                this.columnDOSMJESECISPLATE.AllowDBNull = false;
                this.columnDOSMJESECISPLATE.Caption = "DOSMJESECISPLATE";
                this.columnDOSMJESECISPLATE.MaxLength = 2;
                this.columnDOSMJESECISPLATE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("IsKey", "true");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("Description", "DOSMJESECISPLATE");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("Length", "2");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("Decimals", "0");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSMJESECISPLATE.ExtendedProperties.Add("Deklarit.InternalName", "DOSMJESECISPLATE");
                this.Columns.Add(this.columnDOSMJESECISPLATE);
                this.columnDOSIDOPCINESTANOVANJA = new DataColumn("DOSIDOPCINESTANOVANJA", typeof(string), "", MappingType.Element);
                this.columnDOSIDOPCINESTANOVANJA.AllowDBNull = false;
                this.columnDOSIDOPCINESTANOVANJA.Caption = "DOSIDOPCINESTANOVANJA";
                this.columnDOSIDOPCINESTANOVANJA.MaxLength = 4;
                this.columnDOSIDOPCINESTANOVANJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("Description", "DOSIDOPCINESTANOVANJA");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("Length", "4");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSIDOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.InternalName", "DOSIDOPCINESTANOVANJA");
                this.Columns.Add(this.columnDOSIDOPCINESTANOVANJA);
                this.columnDOSUKUPNOBRUTO = new DataColumn("DOSUKUPNOBRUTO", typeof(decimal), "", MappingType.Element);
                this.columnDOSUKUPNOBRUTO.AllowDBNull = false;
                this.columnDOSUKUPNOBRUTO.Caption = "DOSUKUPNOBRUTO";
                this.columnDOSUKUPNOBRUTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("Description", "DOSUKUPNOBRUTO");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("Length", "12");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("Decimals", "2");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSUKUPNOBRUTO.ExtendedProperties.Add("Deklarit.InternalName", "DOSUKUPNOBRUTO");
                this.Columns.Add(this.columnDOSUKUPNOBRUTO);
                this.columnDOSUKUPNODOPRINOSI = new DataColumn("DOSUKUPNODOPRINOSI", typeof(decimal), "", MappingType.Element);
                this.columnDOSUKUPNODOPRINOSI.AllowDBNull = false;
                this.columnDOSUKUPNODOPRINOSI.Caption = "DOSUKUPNODOPRINOSI";
                this.columnDOSUKUPNODOPRINOSI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("Description", "DOSUKUPNODOPRINOSI");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("Length", "12");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("Decimals", "2");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSUKUPNODOPRINOSI.ExtendedProperties.Add("Deklarit.InternalName", "DOSUKUPNODOPRINOSI");
                this.Columns.Add(this.columnDOSUKUPNODOPRINOSI);
                this.columnDOSUKUPNOOLAKSICE = new DataColumn("DOSUKUPNOOLAKSICE", typeof(decimal), "", MappingType.Element);
                this.columnDOSUKUPNOOLAKSICE.AllowDBNull = false;
                this.columnDOSUKUPNOOLAKSICE.Caption = "DOSUKUPNOOLAKSICE";
                this.columnDOSUKUPNOOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("Description", "DOSUKUPNOOLAKSICE");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("Length", "12");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("Decimals", "2");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSUKUPNOOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "DOSUKUPNOOLAKSICE");
                this.Columns.Add(this.columnDOSUKUPNOOLAKSICE);
                this.columnDOSDOHODAK = new DataColumn("DOSDOHODAK", typeof(decimal), "", MappingType.Element);
                this.columnDOSDOHODAK.AllowDBNull = false;
                this.columnDOSDOHODAK.Caption = "DOSDOHODAK";
                this.columnDOSDOHODAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSDOHODAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSDOHODAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSDOHODAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSDOHODAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSDOHODAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSDOHODAK.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSDOHODAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSDOHODAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDOSDOHODAK.ExtendedProperties.Add("Description", "DOSDOHODAK");
                this.columnDOSDOHODAK.ExtendedProperties.Add("Length", "12");
                this.columnDOSDOHODAK.ExtendedProperties.Add("Decimals", "2");
                this.columnDOSDOHODAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDOSDOHODAK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDOSDOHODAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSDOHODAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSDOHODAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSDOHODAK.ExtendedProperties.Add("Deklarit.InternalName", "DOSDOHODAK");
                this.Columns.Add(this.columnDOSDOHODAK);
                this.columnDOSUKUPNOOO = new DataColumn("DOSUKUPNOOO", typeof(decimal), "", MappingType.Element);
                this.columnDOSUKUPNOOO.AllowDBNull = false;
                this.columnDOSUKUPNOOO.Caption = "DOSUKUPNOOO";
                this.columnDOSUKUPNOOO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("Description", "DOSUKUPNOOO");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("Length", "12");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("Decimals", "2");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSUKUPNOOO.ExtendedProperties.Add("Deklarit.InternalName", "DOSUKUPNOOO");
                this.Columns.Add(this.columnDOSUKUPNOOO);
                this.columnDOSPOREZNAOSNOVICA = new DataColumn("DOSPOREZNAOSNOVICA", typeof(decimal), "", MappingType.Element);
                this.columnDOSPOREZNAOSNOVICA.AllowDBNull = false;
                this.columnDOSPOREZNAOSNOVICA.Caption = "DOSPOREZNAOSNOVICA";
                this.columnDOSPOREZNAOSNOVICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("Description", "DOSPOREZNAOSNOVICA");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("Length", "12");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("Decimals", "2");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSPOREZNAOSNOVICA.ExtendedProperties.Add("Deklarit.InternalName", "DOSPOREZNAOSNOVICA");
                this.Columns.Add(this.columnDOSPOREZNAOSNOVICA);
                this.columnDOSUKUPNOPOREZIPRIREZ = new DataColumn("DOSUKUPNOPOREZIPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnDOSUKUPNOPOREZIPRIREZ.AllowDBNull = false;
                this.columnDOSUKUPNOPOREZIPRIREZ.Caption = "DOSUKUPNOPOREZIPRIREZ";
                this.columnDOSUKUPNOPOREZIPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("Description", "DOSUKUPNOPOREZIPRIREZ");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSUKUPNOPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "DOSUKUPNOPOREZIPRIREZ");
                this.Columns.Add(this.columnDOSUKUPNOPOREZIPRIREZ);
                this.columnDOSUKUPNONETOISPLATA = new DataColumn("DOSUKUPNONETOISPLATA", typeof(decimal), "", MappingType.Element);
                this.columnDOSUKUPNONETOISPLATA.AllowDBNull = false;
                this.columnDOSUKUPNONETOISPLATA.Caption = "DOSUKUPNONETOISPLATA";
                this.columnDOSUKUPNONETOISPLATA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("Description", "DOSUKUPNONETOISPLATA");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("Length", "12");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("Decimals", "2");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSUKUPNONETOISPLATA.ExtendedProperties.Add("Deklarit.InternalName", "DOSUKUPNONETOISPLATA");
                this.Columns.Add(this.columnDOSUKUPNONETOISPLATA);
                this.columnDOSPOSEBANPOREZ = new DataColumn("DOSPOSEBANPOREZ", typeof(decimal), "", MappingType.Element);
                this.columnDOSPOSEBANPOREZ.AllowDBNull = false;
                this.columnDOSPOSEBANPOREZ.Caption = "DOSPOSEBANPOREZ";
                this.columnDOSPOSEBANPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("Description", "DOSPOSEBANPOREZ");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("Length", "12");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSPOSEBANPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "DOSPOSEBANPOREZ");
                this.Columns.Add(this.columnDOSPOSEBANPOREZ);
                this.PrimaryKey = new DataColumn[] { this.columnDOSIPIDENT, this.columnDOSJMBG, this.columnDOSMJESECISPLATE };
                this.ExtendedProperties.Add("ParentLvl", "DOSIPZAGLAVLJE");
                this.ExtendedProperties.Add("LevelName", "Level1");
                this.ExtendedProperties.Add("Description", "Level1");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnDOSIPIDENT = this.Columns["DOSIPIDENT"];
                this.columnDOSJMBG = this.Columns["DOSJMBG"];
                this.columnDOSMJESECISPLATE = this.Columns["DOSMJESECISPLATE"];
                this.columnDOSIDOPCINESTANOVANJA = this.Columns["DOSIDOPCINESTANOVANJA"];
                this.columnDOSUKUPNOBRUTO = this.Columns["DOSUKUPNOBRUTO"];
                this.columnDOSUKUPNODOPRINOSI = this.Columns["DOSUKUPNODOPRINOSI"];
                this.columnDOSUKUPNOOLAKSICE = this.Columns["DOSUKUPNOOLAKSICE"];
                this.columnDOSDOHODAK = this.Columns["DOSDOHODAK"];
                this.columnDOSUKUPNOOO = this.Columns["DOSUKUPNOOO"];
                this.columnDOSPOREZNAOSNOVICA = this.Columns["DOSPOREZNAOSNOVICA"];
                this.columnDOSUKUPNOPOREZIPRIREZ = this.Columns["DOSUKUPNOPOREZIPRIREZ"];
                this.columnDOSUKUPNONETOISPLATA = this.Columns["DOSUKUPNONETOISPLATA"];
                this.columnDOSPOSEBANPOREZ = this.Columns["DOSPOSEBANPOREZ"];
            }

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row NewDOSIPZAGLAVLJELevel1Row()
            {
                return (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DOSIPZAGLAVLJELevel1RowChanged != null)
                {
                    DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1RowChangeEventHandler handler = this.DOSIPZAGLAVLJELevel1RowChanged;
                    if (handler != null)
                    {
                        handler(this, new DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1RowChangeEvent((DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DOSIPZAGLAVLJELevel1RowChanging != null)
                {
                    DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1RowChangeEventHandler handler = this.DOSIPZAGLAVLJELevel1RowChanging;
                    if (handler != null)
                    {
                        handler(this, new DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1RowChangeEvent((DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("DOSIPZAGLAVLJE_DOSIPZAGLAVLJELevel1", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.DOSIPZAGLAVLJELevel1RowDeleted != null)
                {
                    DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1RowChangeEventHandler handler = this.DOSIPZAGLAVLJELevel1RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1RowChangeEvent((DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DOSIPZAGLAVLJELevel1RowDeleting != null)
                {
                    DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1RowChangeEventHandler handler = this.DOSIPZAGLAVLJELevel1RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1RowChangeEvent((DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDOSIPZAGLAVLJELevel1Row(DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row row)
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

            public DataColumn DOSDOHODAKColumn
            {
                get
                {
                    return this.columnDOSDOHODAK;
                }
            }

            public DataColumn DOSIDOPCINESTANOVANJAColumn
            {
                get
                {
                    return this.columnDOSIDOPCINESTANOVANJA;
                }
            }

            public DataColumn DOSIPIDENTColumn
            {
                get
                {
                    return this.columnDOSIPIDENT;
                }
            }

            public DataColumn DOSJMBGColumn
            {
                get
                {
                    return this.columnDOSJMBG;
                }
            }

            public DataColumn DOSMJESECISPLATEColumn
            {
                get
                {
                    return this.columnDOSMJESECISPLATE;
                }
            }

            public DataColumn DOSPOREZNAOSNOVICAColumn
            {
                get
                {
                    return this.columnDOSPOREZNAOSNOVICA;
                }
            }

            public DataColumn DOSPOSEBANPOREZColumn
            {
                get
                {
                    return this.columnDOSPOSEBANPOREZ;
                }
            }

            public DataColumn DOSUKUPNOBRUTOColumn
            {
                get
                {
                    return this.columnDOSUKUPNOBRUTO;
                }
            }

            public DataColumn DOSUKUPNODOPRINOSIColumn
            {
                get
                {
                    return this.columnDOSUKUPNODOPRINOSI;
                }
            }

            public DataColumn DOSUKUPNONETOISPLATAColumn
            {
                get
                {
                    return this.columnDOSUKUPNONETOISPLATA;
                }
            }

            public DataColumn DOSUKUPNOOLAKSICEColumn
            {
                get
                {
                    return this.columnDOSUKUPNOOLAKSICE;
                }
            }

            public DataColumn DOSUKUPNOOOColumn
            {
                get
                {
                    return this.columnDOSUKUPNOOO;
                }
            }

            public DataColumn DOSUKUPNOPOREZIPRIREZColumn
            {
                get
                {
                    return this.columnDOSUKUPNOPOREZIPRIREZ;
                }
            }

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row this[int index]
            {
                get
                {
                    return (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row) this.Rows[index];
                }
            }
        }

        public class DOSIPZAGLAVLJELevel1Row : DataRow
        {
            private DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1DataTable tableDOSIPZAGLAVLJELevel1;

            internal DOSIPZAGLAVLJELevel1Row(DataRowBuilder rb) : base(rb)
            {
                this.tableDOSIPZAGLAVLJELevel1 = (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1DataTable) this.Table;
            }

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow GetDOSIPZAGLAVLJERow()
            {
                return (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow) this.GetParentRow("DOSIPZAGLAVLJE_DOSIPZAGLAVLJELevel1");
            }

            public bool IsDOSDOHODAKNull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJELevel1.DOSDOHODAKColumn);
            }

            public bool IsDOSIDOPCINESTANOVANJANull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJELevel1.DOSIDOPCINESTANOVANJAColumn);
            }

            public bool IsDOSIPIDENTNull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJELevel1.DOSIPIDENTColumn);
            }

            public bool IsDOSJMBGNull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJELevel1.DOSJMBGColumn);
            }

            public bool IsDOSMJESECISPLATENull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJELevel1.DOSMJESECISPLATEColumn);
            }

            public bool IsDOSPOREZNAOSNOVICANull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJELevel1.DOSPOREZNAOSNOVICAColumn);
            }

            public bool IsDOSPOSEBANPOREZNull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJELevel1.DOSPOSEBANPOREZColumn);
            }

            public bool IsDOSUKUPNOBRUTONull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOBRUTOColumn);
            }

            public bool IsDOSUKUPNODOPRINOSINull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNODOPRINOSIColumn);
            }

            public bool IsDOSUKUPNONETOISPLATANull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNONETOISPLATAColumn);
            }

            public bool IsDOSUKUPNOOLAKSICENull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOOLAKSICEColumn);
            }

            public bool IsDOSUKUPNOOONull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOOOColumn);
            }

            public bool IsDOSUKUPNOPOREZIPRIREZNull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOPOREZIPRIREZColumn);
            }

            public void SetDOSDOHODAKNull()
            {
                this[this.tableDOSIPZAGLAVLJELevel1.DOSDOHODAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOSIDOPCINESTANOVANJANull()
            {
                this[this.tableDOSIPZAGLAVLJELevel1.DOSIDOPCINESTANOVANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOSPOREZNAOSNOVICANull()
            {
                this[this.tableDOSIPZAGLAVLJELevel1.DOSPOREZNAOSNOVICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOSPOSEBANPOREZNull()
            {
                this[this.tableDOSIPZAGLAVLJELevel1.DOSPOSEBANPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOSUKUPNOBRUTONull()
            {
                this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOBRUTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOSUKUPNODOPRINOSINull()
            {
                this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNODOPRINOSIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOSUKUPNONETOISPLATANull()
            {
                this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNONETOISPLATAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOSUKUPNOOLAKSICENull()
            {
                this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOSUKUPNOOONull()
            {
                this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOOOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOSUKUPNOPOREZIPRIREZNull()
            {
                this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOPOREZIPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal DOSDOHODAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDOSIPZAGLAVLJELevel1.DOSDOHODAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DOSDOHODAK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJELevel1.DOSDOHODAKColumn] = value;
                }
            }

            public string DOSIDOPCINESTANOVANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOSIPZAGLAVLJELevel1.DOSIDOPCINESTANOVANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DOSIDOPCINESTANOVANJA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJELevel1.DOSIDOPCINESTANOVANJAColumn] = value;
                }
            }

            public string DOSIPIDENT
            {
                get
                {
                    return Conversions.ToString(this[this.tableDOSIPZAGLAVLJELevel1.DOSIPIDENTColumn]);
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJELevel1.DOSIPIDENTColumn] = value;
                }
            }

            public string DOSJMBG
            {
                get
                {
                    return Conversions.ToString(this[this.tableDOSIPZAGLAVLJELevel1.DOSJMBGColumn]);
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJELevel1.DOSJMBGColumn] = value;
                }
            }

            public string DOSMJESECISPLATE
            {
                get
                {
                    return Conversions.ToString(this[this.tableDOSIPZAGLAVLJELevel1.DOSMJESECISPLATEColumn]);
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJELevel1.DOSMJESECISPLATEColumn] = value;
                }
            }

            public decimal DOSPOREZNAOSNOVICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDOSIPZAGLAVLJELevel1.DOSPOREZNAOSNOVICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJELevel1.DOSPOREZNAOSNOVICAColumn] = value;
                }
            }

            public decimal DOSPOSEBANPOREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDOSIPZAGLAVLJELevel1.DOSPOSEBANPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJELevel1.DOSPOSEBANPOREZColumn] = value;
                }
            }

            public decimal DOSUKUPNOBRUTO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOBRUTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOBRUTOColumn] = value;
                }
            }

            public decimal DOSUKUPNODOPRINOSI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNODOPRINOSIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNODOPRINOSIColumn] = value;
                }
            }

            public decimal DOSUKUPNONETOISPLATA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNONETOISPLATAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNONETOISPLATAColumn] = value;
                }
            }

            public decimal DOSUKUPNOOLAKSICE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOOLAKSICEColumn] = value;
                }
            }

            public decimal DOSUKUPNOOO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOOOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOOOColumn] = value;
                }
            }

            public decimal DOSUKUPNOPOREZIPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOPOREZIPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJELevel1.DOSUKUPNOPOREZIPRIREZColumn] = value;
                }
            }
        }

        public class DOSIPZAGLAVLJELevel1RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row eventRow;

            public DOSIPZAGLAVLJELevel1RowChangeEvent(DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row row, DataRowAction action)
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

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DOSIPZAGLAVLJELevel1RowChangeEventHandler(object sender, DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1RowChangeEvent e);

        public class DOSIPZAGLAVLJERow : DataRow
        {
            private DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJEDataTable tableDOSIPZAGLAVLJE;

            internal DOSIPZAGLAVLJERow(DataRowBuilder rb) : base(rb)
            {
                this.tableDOSIPZAGLAVLJE = (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJEDataTable) this.Table;
            }

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row[] GetDOSIPZAGLAVLJELevel1Rows()
            {
                return (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row[]) this.GetChildRows("DOSIPZAGLAVLJE_DOSIPZAGLAVLJELevel1");
            }

            public bool IsDOSIPIDENTNull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJE.DOSIPIDENTColumn);
            }

            public bool IsDOSISPLATAUGODININull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJE.DOSISPLATAUGODINIColumn);
            }

            public bool IsDOSISPLATAZAGODINUNull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJE.DOSISPLATAZAGODINUColumn);
            }

            public bool IsDOSJMBGNull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJE.DOSJMBGColumn);
            }

            public bool IsDOSOZNACENNull()
            {
                return this.IsNull(this.tableDOSIPZAGLAVLJE.DOSOZNACENColumn);
            }

            public void SetDOSISPLATAUGODININull()
            {
                this[this.tableDOSIPZAGLAVLJE.DOSISPLATAUGODINIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOSISPLATAZAGODINUNull()
            {
                this[this.tableDOSIPZAGLAVLJE.DOSISPLATAZAGODINUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOSOZNACENNull()
            {
                this[this.tableDOSIPZAGLAVLJE.DOSOZNACENColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string DOSIPIDENT
            {
                get
                {
                    return Conversions.ToString(this[this.tableDOSIPZAGLAVLJE.DOSIPIDENTColumn]);
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJE.DOSIPIDENTColumn] = value;
                }
            }

            public string DOSISPLATAUGODINI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOSIPZAGLAVLJE.DOSISPLATAUGODINIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJE.DOSISPLATAUGODINIColumn] = value;
                }
            }

            public string DOSISPLATAZAGODINU
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOSIPZAGLAVLJE.DOSISPLATAZAGODINUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJE.DOSISPLATAZAGODINUColumn] = value;
                }
            }

            public string DOSJMBG
            {
                get
                {
                    return Conversions.ToString(this[this.tableDOSIPZAGLAVLJE.DOSJMBGColumn]);
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJE.DOSJMBGColumn] = value;
                }
            }

            public bool DOSOZNACEN
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableDOSIPZAGLAVLJE.DOSOZNACENColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableDOSIPZAGLAVLJE.DOSOZNACENColumn] = value;
                }
            }
        }

        public class DOSIPZAGLAVLJERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow eventRow;

            public DOSIPZAGLAVLJERowChangeEvent(DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow row, DataRowAction action)
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

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DOSIPZAGLAVLJERowChangeEventHandler(object sender, DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERowChangeEvent e);
    }
}

