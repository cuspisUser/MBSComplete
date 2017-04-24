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
    public class PRPLACEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private PRPLACEDataTable tablePRPLACE;
        private PRPLACEPRPLACEELEMENTIDataTable tablePRPLACEPRPLACEELEMENTI;
        private PRPLACEPRPLACEELEMENTIRADNIKDataTable tablePRPLACEPRPLACEELEMENTIRADNIK;

        public PRPLACEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected PRPLACEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["PRPLACEPRPLACEELEMENTIRADNIK"] != null)
                    {
                        this.Tables.Add(new PRPLACEPRPLACEELEMENTIRADNIKDataTable(dataSet.Tables["PRPLACEPRPLACEELEMENTIRADNIK"]));
                    }
                    if (dataSet.Tables["PRPLACEPRPLACEELEMENTI"] != null)
                    {
                        this.Tables.Add(new PRPLACEPRPLACEELEMENTIDataTable(dataSet.Tables["PRPLACEPRPLACEELEMENTI"]));
                    }
                    if (dataSet.Tables["PRPLACE"] != null)
                    {
                        this.Tables.Add(new PRPLACEDataTable(dataSet.Tables["PRPLACE"]));
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
            PRPLACEDataSet set = (PRPLACEDataSet) base.Clone();
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
            PRPLACEDataSet set = new PRPLACEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "PRPLACEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2068");
            this.ExtendedProperties.Add("DataSetName", "PRPLACEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IPRPLACEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "PRPLACE");
            this.ExtendedProperties.Add("ObjectDescription", "Priprema plaae");
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
            this.DataSetName = "PRPLACEDataSet";
            this.Namespace = "http://www.tempuri.org/PRPLACE";
            this.tablePRPLACEPRPLACEELEMENTIRADNIK = new PRPLACEPRPLACEELEMENTIRADNIKDataTable();
            this.Tables.Add(this.tablePRPLACEPRPLACEELEMENTIRADNIK);
            this.tablePRPLACEPRPLACEELEMENTI = new PRPLACEPRPLACEELEMENTIDataTable();
            this.Tables.Add(this.tablePRPLACEPRPLACEELEMENTI);
            this.tablePRPLACE = new PRPLACEDataTable();
            this.Tables.Add(this.tablePRPLACE);
            this.Relations.Add("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK", new DataColumn[] { this.Tables["PRPLACEPRPLACEELEMENTI"].Columns["PRPLACEZAMJESEC"], this.Tables["PRPLACEPRPLACEELEMENTI"].Columns["PRPLACEID"], this.Tables["PRPLACEPRPLACEELEMENTI"].Columns["PRPLACEZAGODINU"], this.Tables["PRPLACEPRPLACEELEMENTI"].Columns["IDELEMENT"] }, new DataColumn[] { this.Tables["PRPLACEPRPLACEELEMENTIRADNIK"].Columns["PRPLACEZAMJESEC"], this.Tables["PRPLACEPRPLACEELEMENTIRADNIK"].Columns["PRPLACEID"], this.Tables["PRPLACEPRPLACEELEMENTIRADNIK"].Columns["PRPLACEZAGODINU"], this.Tables["PRPLACEPRPLACEELEMENTIRADNIK"].Columns["IDELEMENT"] });
            this.Relations["PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK"].Nested = true;
            this.Relations.Add("PRPLACE_PRPLACEPRPLACEELEMENTI", new DataColumn[] { this.Tables["PRPLACE"].Columns["PRPLACEZAMJESEC"], this.Tables["PRPLACE"].Columns["PRPLACEID"], this.Tables["PRPLACE"].Columns["PRPLACEZAGODINU"] }, new DataColumn[] { this.Tables["PRPLACEPRPLACEELEMENTI"].Columns["PRPLACEZAMJESEC"], this.Tables["PRPLACEPRPLACEELEMENTI"].Columns["PRPLACEID"], this.Tables["PRPLACEPRPLACEELEMENTI"].Columns["PRPLACEZAGODINU"] });
            this.Relations["PRPLACE_PRPLACEPRPLACEELEMENTI"].Nested = true;
            this.tablePRPLACEPRPLACEELEMENTIRADNIK.SPOJENOPREZIMEColumn.Expression = "PREZIME+' '+IME";
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
            this.tablePRPLACEPRPLACEELEMENTIRADNIK = (PRPLACEPRPLACEELEMENTIRADNIKDataTable) this.Tables["PRPLACEPRPLACEELEMENTIRADNIK"];
            this.tablePRPLACEPRPLACEELEMENTI = (PRPLACEPRPLACEELEMENTIDataTable) this.Tables["PRPLACEPRPLACEELEMENTI"];
            this.tablePRPLACE = (PRPLACEDataTable) this.Tables["PRPLACE"];
            if (initTable)
            {
                if (this.tablePRPLACEPRPLACEELEMENTIRADNIK != null)
                {
                    this.tablePRPLACEPRPLACEELEMENTIRADNIK.InitVars();
                }
                if (this.tablePRPLACEPRPLACEELEMENTI != null)
                {
                    this.tablePRPLACEPRPLACEELEMENTI.InitVars();
                }
                if (this.tablePRPLACE != null)
                {
                    this.tablePRPLACE.InitVars();
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
                if (dataSet.Tables["PRPLACEPRPLACEELEMENTIRADNIK"] != null)
                {
                    this.Tables.Add(new PRPLACEPRPLACEELEMENTIRADNIKDataTable(dataSet.Tables["PRPLACEPRPLACEELEMENTIRADNIK"]));
                }
                if (dataSet.Tables["PRPLACEPRPLACEELEMENTI"] != null)
                {
                    this.Tables.Add(new PRPLACEPRPLACEELEMENTIDataTable(dataSet.Tables["PRPLACEPRPLACEELEMENTI"]));
                }
                if (dataSet.Tables["PRPLACE"] != null)
                {
                    this.Tables.Add(new PRPLACEDataTable(dataSet.Tables["PRPLACE"]));
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

        private bool ShouldSerializePRPLACE()
        {
            return false;
        }

        private bool ShouldSerializePRPLACEPRPLACEELEMENTI()
        {
            return false;
        }

        private bool ShouldSerializePRPLACEPRPLACEELEMENTIRADNIK()
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
        public PRPLACEDataTable PRPLACE
        {
            get
            {
                return this.tablePRPLACE;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PRPLACEPRPLACEELEMENTIDataTable PRPLACEPRPLACEELEMENTI
        {
            get
            {
                return this.tablePRPLACEPRPLACEELEMENTI;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PRPLACEPRPLACEELEMENTIRADNIKDataTable PRPLACEPRPLACEELEMENTIRADNIK
        {
            get
            {
                return this.tablePRPLACEPRPLACEELEMENTIRADNIK;
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
        public class PRPLACEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnPRPLACEID;
            private DataColumn columnPRPLACEOPIS;
            private DataColumn columnPRPLACEOSNOVICA;
            private DataColumn columnPRPLACEPROSJECNISATI;
            private DataColumn columnPRPLACEZAGODINU;
            private DataColumn columnPRPLACEZAMJESEC;

            public event PRPLACEDataSet.PRPLACERowChangeEventHandler PRPLACERowChanged;

            public event PRPLACEDataSet.PRPLACERowChangeEventHandler PRPLACERowChanging;

            public event PRPLACEDataSet.PRPLACERowChangeEventHandler PRPLACERowDeleted;

            public event PRPLACEDataSet.PRPLACERowChangeEventHandler PRPLACERowDeleting;

            public PRPLACEDataTable()
            {
                this.TableName = "PRPLACE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal PRPLACEDataTable(DataTable table) : base(table.TableName)
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

            protected PRPLACEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPRPLACERow(PRPLACEDataSet.PRPLACERow row)
            {
                this.Rows.Add(row);
            }

            public PRPLACEDataSet.PRPLACERow AddPRPLACERow(short pRPLACEZAMJESEC, int pRPLACEID, short pRPLACEZAGODINU, string pRPLACEOPIS, decimal pRPLACEOSNOVICA, decimal pRPLACEPROSJECNISATI)
            {
                PRPLACEDataSet.PRPLACERow row = (PRPLACEDataSet.PRPLACERow) this.NewRow();
                row["PRPLACEZAMJESEC"] = pRPLACEZAMJESEC;
                row["PRPLACEID"] = pRPLACEID;
                row["PRPLACEZAGODINU"] = pRPLACEZAGODINU;
                row["PRPLACEOPIS"] = pRPLACEOPIS;
                row["PRPLACEOSNOVICA"] = pRPLACEOSNOVICA;
                row["PRPLACEPROSJECNISATI"] = pRPLACEPROSJECNISATI;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                PRPLACEDataSet.PRPLACEDataTable table = (PRPLACEDataSet.PRPLACEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public PRPLACEDataSet.PRPLACERow FindByPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINU(short pRPLACEZAMJESEC, int pRPLACEID, short pRPLACEZAGODINU)
            {
                return (PRPLACEDataSet.PRPLACERow) this.Rows.Find(new object[] { pRPLACEZAMJESEC, pRPLACEID, pRPLACEZAGODINU });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(PRPLACEDataSet.PRPLACERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                PRPLACEDataSet set = new PRPLACEDataSet();
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
                this.columnPRPLACEZAMJESEC = new DataColumn("PRPLACEZAMJESEC", typeof(short), "", MappingType.Element);
                this.columnPRPLACEZAMJESEC.AllowDBNull = false;
                this.columnPRPLACEZAMJESEC.Caption = "PRPLACEZAMJESEC";
                this.columnPRPLACEZAMJESEC.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("IsKey", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Description", "Za mjesec");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Length", "2");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Decimals", "0");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEZAMJESEC");
                this.Columns.Add(this.columnPRPLACEZAMJESEC);
                this.columnPRPLACEID = new DataColumn("PRPLACEID", typeof(int), "", MappingType.Element);
                this.columnPRPLACEID.AllowDBNull = false;
                this.columnPRPLACEID.Caption = "PRPLACEID";
                this.columnPRPLACEID.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEID.ExtendedProperties.Add("IsKey", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRPLACEID.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACEID.ExtendedProperties.Add("Description", "Broj pripreme unutar mjeseca");
                this.columnPRPLACEID.ExtendedProperties.Add("Length", "5");
                this.columnPRPLACEID.ExtendedProperties.Add("Decimals", "0");
                this.columnPRPLACEID.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEID.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEID");
                this.Columns.Add(this.columnPRPLACEID);
                this.columnPRPLACEZAGODINU = new DataColumn("PRPLACEZAGODINU", typeof(short), "", MappingType.Element);
                this.columnPRPLACEZAGODINU.AllowDBNull = false;
                this.columnPRPLACEZAGODINU.Caption = "PRPLACEZAGODINU";
                this.columnPRPLACEZAGODINU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("IsKey", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Description", "Za godinu");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Length", "4");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Decimals", "0");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEZAGODINU");
                this.Columns.Add(this.columnPRPLACEZAGODINU);
                this.columnPRPLACEOPIS = new DataColumn("PRPLACEOPIS", typeof(string), "", MappingType.Element);
                this.columnPRPLACEOPIS.AllowDBNull = false;
                this.columnPRPLACEOPIS.Caption = "PRPLACEOPIS";
                this.columnPRPLACEOPIS.MaxLength = 50;
                this.columnPRPLACEOPIS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRPLACEOPIS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("IsKey", "false");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("Description", "Opis");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("Length", "50");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("Decimals", "0");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEOPIS.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEOPIS");
                this.Columns.Add(this.columnPRPLACEOPIS);
                this.columnPRPLACEOSNOVICA = new DataColumn("PRPLACEOSNOVICA", typeof(decimal), "", MappingType.Element);
                this.columnPRPLACEOSNOVICA.AllowDBNull = false;
                this.columnPRPLACEOSNOVICA.Caption = "PRPLACEOSNOVICA";
                this.columnPRPLACEOSNOVICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("IsKey", "false");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("Description", "Osnovica");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("Length", "12");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("Decimals", "2");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEOSNOVICA.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEOSNOVICA");
                this.Columns.Add(this.columnPRPLACEOSNOVICA);
                this.columnPRPLACEPROSJECNISATI = new DataColumn("PRPLACEPROSJECNISATI", typeof(decimal), "", MappingType.Element);
                this.columnPRPLACEPROSJECNISATI.AllowDBNull = false;
                this.columnPRPLACEPROSJECNISATI.Caption = "PRPLACEPROSJECNISATI";
                this.columnPRPLACEPROSJECNISATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("IsKey", "false");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("Description", "Prosječan broj sati");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("Length", "12");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("Decimals", "2");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEPROSJECNISATI.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEPROSJECNISATI");
                this.Columns.Add(this.columnPRPLACEPROSJECNISATI);
                this.PrimaryKey = new DataColumn[] { this.columnPRPLACEZAMJESEC, this.columnPRPLACEID, this.columnPRPLACEZAGODINU };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "PRPLACE");
                this.ExtendedProperties.Add("Description", "Priprema plaae");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnPRPLACEZAMJESEC = this.Columns["PRPLACEZAMJESEC"];
                this.columnPRPLACEID = this.Columns["PRPLACEID"];
                this.columnPRPLACEZAGODINU = this.Columns["PRPLACEZAGODINU"];
                this.columnPRPLACEOPIS = this.Columns["PRPLACEOPIS"];
                this.columnPRPLACEOSNOVICA = this.Columns["PRPLACEOSNOVICA"];
                this.columnPRPLACEPROSJECNISATI = this.Columns["PRPLACEPROSJECNISATI"];
            }

            public PRPLACEDataSet.PRPLACERow NewPRPLACERow()
            {
                return (PRPLACEDataSet.PRPLACERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PRPLACEDataSet.PRPLACERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PRPLACERowChanged != null)
                {
                    PRPLACEDataSet.PRPLACERowChangeEventHandler pRPLACERowChangedEvent = this.PRPLACERowChanged;
                    if (pRPLACERowChangedEvent != null)
                    {
                        pRPLACERowChangedEvent(this, new PRPLACEDataSet.PRPLACERowChangeEvent((PRPLACEDataSet.PRPLACERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PRPLACERowChanging != null)
                {
                    PRPLACEDataSet.PRPLACERowChangeEventHandler pRPLACERowChangingEvent = this.PRPLACERowChanging;
                    if (pRPLACERowChangingEvent != null)
                    {
                        pRPLACERowChangingEvent(this, new PRPLACEDataSet.PRPLACERowChangeEvent((PRPLACEDataSet.PRPLACERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PRPLACERowDeleted != null)
                {
                    PRPLACEDataSet.PRPLACERowChangeEventHandler pRPLACERowDeletedEvent = this.PRPLACERowDeleted;
                    if (pRPLACERowDeletedEvent != null)
                    {
                        pRPLACERowDeletedEvent(this, new PRPLACEDataSet.PRPLACERowChangeEvent((PRPLACEDataSet.PRPLACERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PRPLACERowDeleting != null)
                {
                    PRPLACEDataSet.PRPLACERowChangeEventHandler pRPLACERowDeletingEvent = this.PRPLACERowDeleting;
                    if (pRPLACERowDeletingEvent != null)
                    {
                        pRPLACERowDeletingEvent(this, new PRPLACEDataSet.PRPLACERowChangeEvent((PRPLACEDataSet.PRPLACERow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePRPLACERow(PRPLACEDataSet.PRPLACERow row)
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

            public PRPLACEDataSet.PRPLACERow this[int index]
            {
                get
                {
                    return (PRPLACEDataSet.PRPLACERow) this.Rows[index];
                }
            }

            public DataColumn PRPLACEIDColumn
            {
                get
                {
                    return this.columnPRPLACEID;
                }
            }

            public DataColumn PRPLACEOPISColumn
            {
                get
                {
                    return this.columnPRPLACEOPIS;
                }
            }

            public DataColumn PRPLACEOSNOVICAColumn
            {
                get
                {
                    return this.columnPRPLACEOSNOVICA;
                }
            }

            public DataColumn PRPLACEPROSJECNISATIColumn
            {
                get
                {
                    return this.columnPRPLACEPROSJECNISATI;
                }
            }

            public DataColumn PRPLACEZAGODINUColumn
            {
                get
                {
                    return this.columnPRPLACEZAGODINU;
                }
            }

            public DataColumn PRPLACEZAMJESECColumn
            {
                get
                {
                    return this.columnPRPLACEZAMJESEC;
                }
            }
        }

        [Serializable]
        public class PRPLACEPRPLACEELEMENTIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDELEMENT;
            private DataColumn columnNAZIVELEMENT;
            private DataColumn columnPOSTOTAK;
            private DataColumn columnPRPLACEID;
            private DataColumn columnPRPLACEZAGODINU;
            private DataColumn columnPRPLACEZAMJESEC;

            public event PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRowChangeEventHandler PRPLACEPRPLACEELEMENTIRowChanged;

            public event PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRowChangeEventHandler PRPLACEPRPLACEELEMENTIRowChanging;

            public event PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRowChangeEventHandler PRPLACEPRPLACEELEMENTIRowDeleted;

            public event PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRowChangeEventHandler PRPLACEPRPLACEELEMENTIRowDeleting;

            public PRPLACEPRPLACEELEMENTIDataTable()
            {
                this.TableName = "PRPLACEPRPLACEELEMENTI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal PRPLACEPRPLACEELEMENTIDataTable(DataTable table) : base(table.TableName)
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

            protected PRPLACEPRPLACEELEMENTIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPRPLACEPRPLACEELEMENTIRow(PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow row)
            {
                this.Rows.Add(row);
            }

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow AddPRPLACEPRPLACEELEMENTIRow(short pRPLACEZAMJESEC, int pRPLACEID, short pRPLACEZAGODINU, int iDELEMENT)
            {
                PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow row = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) this.NewRow();
                row["PRPLACEZAMJESEC"] = pRPLACEZAMJESEC;
                row["PRPLACEID"] = pRPLACEID;
                row["PRPLACEZAGODINU"] = pRPLACEZAGODINU;
                row["IDELEMENT"] = iDELEMENT;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                PRPLACEDataSet.PRPLACEPRPLACEELEMENTIDataTable table = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow FindByPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINUIDELEMENT(short pRPLACEZAMJESEC, int pRPLACEID, short pRPLACEZAGODINU, int iDELEMENT)
            {
                return (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) this.Rows.Find(new object[] { pRPLACEZAMJESEC, pRPLACEID, pRPLACEZAGODINU, iDELEMENT });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                PRPLACEDataSet set = new PRPLACEDataSet();
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
                this.columnPRPLACEZAMJESEC = new DataColumn("PRPLACEZAMJESEC", typeof(short), "", MappingType.Element);
                this.columnPRPLACEZAMJESEC.AllowDBNull = false;
                this.columnPRPLACEZAMJESEC.Caption = "PRPLACEZAMJESEC";
                this.columnPRPLACEZAMJESEC.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("IsKey", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Description", "Za mjesec");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Length", "2");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Decimals", "0");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEZAMJESEC");
                this.Columns.Add(this.columnPRPLACEZAMJESEC);
                this.columnPRPLACEID = new DataColumn("PRPLACEID", typeof(int), "", MappingType.Element);
                this.columnPRPLACEID.AllowDBNull = false;
                this.columnPRPLACEID.Caption = "PRPLACEID";
                this.columnPRPLACEID.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEID.ExtendedProperties.Add("IsKey", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACEID.ExtendedProperties.Add("Description", "Broj pripreme unutar mjeseca");
                this.columnPRPLACEID.ExtendedProperties.Add("Length", "5");
                this.columnPRPLACEID.ExtendedProperties.Add("Decimals", "0");
                this.columnPRPLACEID.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEID.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEID");
                this.Columns.Add(this.columnPRPLACEID);
                this.columnPRPLACEZAGODINU = new DataColumn("PRPLACEZAGODINU", typeof(short), "", MappingType.Element);
                this.columnPRPLACEZAGODINU.AllowDBNull = false;
                this.columnPRPLACEZAGODINU.Caption = "PRPLACEZAGODINU";
                this.columnPRPLACEZAGODINU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("IsKey", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Description", "Za godinu");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Length", "4");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Decimals", "0");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEZAGODINU");
                this.Columns.Add(this.columnPRPLACEZAGODINU);
                this.columnIDELEMENT = new DataColumn("IDELEMENT", typeof(int), "", MappingType.Element);
                this.columnIDELEMENT.AllowDBNull = false;
                this.columnIDELEMENT.Caption = "Šifra elementa";
                this.columnIDELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDELEMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDELEMENT.ExtendedProperties.Add("Description", "Šifra elementa");
                this.columnIDELEMENT.ExtendedProperties.Add("Length", "8");
                this.columnIDELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDELEMENT");
                this.Columns.Add(this.columnIDELEMENT);
                this.columnNAZIVELEMENT = new DataColumn("NAZIVELEMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVELEMENT.AllowDBNull = false;
                this.columnNAZIVELEMENT.Caption = "Naziv elementa";
                this.columnNAZIVELEMENT.MaxLength = 50;
                this.columnNAZIVELEMENT.DefaultValue = "";
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Description", "Naziv elementa");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVELEMENT");
                this.Columns.Add(this.columnNAZIVELEMENT);
                this.columnPOSTOTAK = new DataColumn("POSTOTAK", typeof(decimal), "", MappingType.Element);
                this.columnPOSTOTAK.AllowDBNull = true;
                this.columnPOSTOTAK.Caption = "Postotak";
                this.columnPOSTOTAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOSTOTAK.ExtendedProperties.Add("IsKey", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOSTOTAK.ExtendedProperties.Add("Description", "Postotak");
                this.columnPOSTOTAK.ExtendedProperties.Add("Length", "5");
                this.columnPOSTOTAK.ExtendedProperties.Add("Decimals", "2");
                this.columnPOSTOTAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPOSTOTAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOSTOTAK.ExtendedProperties.Add("Deklarit.InternalName", "POSTOTAK");
                this.Columns.Add(this.columnPOSTOTAK);
                this.PrimaryKey = new DataColumn[] { this.columnPRPLACEZAMJESEC, this.columnPRPLACEID, this.columnPRPLACEZAGODINU, this.columnIDELEMENT };
                this.ExtendedProperties.Add("ParentLvl", "PRPLACE");
                this.ExtendedProperties.Add("LevelName", "PRPLACEELEMENTI");
                this.ExtendedProperties.Add("Description", "Elementi u pripremi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnPRPLACEZAMJESEC = this.Columns["PRPLACEZAMJESEC"];
                this.columnPRPLACEID = this.Columns["PRPLACEID"];
                this.columnPRPLACEZAGODINU = this.Columns["PRPLACEZAGODINU"];
                this.columnIDELEMENT = this.Columns["IDELEMENT"];
                this.columnNAZIVELEMENT = this.Columns["NAZIVELEMENT"];
                this.columnPOSTOTAK = this.Columns["POSTOTAK"];
            }

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow NewPRPLACEPRPLACEELEMENTIRow()
            {
                return (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PRPLACEPRPLACEELEMENTIRowChanged != null)
                {
                    PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRowChangeEventHandler pRPLACEPRPLACEELEMENTIRowChangedEvent = this.PRPLACEPRPLACEELEMENTIRowChanged;
                    if (pRPLACEPRPLACEELEMENTIRowChangedEvent != null)
                    {
                        pRPLACEPRPLACEELEMENTIRowChangedEvent(this, new PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRowChangeEvent((PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PRPLACEPRPLACEELEMENTIRowChanging != null)
                {
                    PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRowChangeEventHandler pRPLACEPRPLACEELEMENTIRowChangingEvent = this.PRPLACEPRPLACEELEMENTIRowChanging;
                    if (pRPLACEPRPLACEELEMENTIRowChangingEvent != null)
                    {
                        pRPLACEPRPLACEELEMENTIRowChangingEvent(this, new PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRowChangeEvent((PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("PRPLACE_PRPLACEPRPLACEELEMENTI", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.PRPLACEPRPLACEELEMENTIRowDeleted != null)
                {
                    PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRowChangeEventHandler pRPLACEPRPLACEELEMENTIRowDeletedEvent = this.PRPLACEPRPLACEELEMENTIRowDeleted;
                    if (pRPLACEPRPLACEELEMENTIRowDeletedEvent != null)
                    {
                        pRPLACEPRPLACEELEMENTIRowDeletedEvent(this, new PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRowChangeEvent((PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PRPLACEPRPLACEELEMENTIRowDeleting != null)
                {
                    PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRowChangeEventHandler pRPLACEPRPLACEELEMENTIRowDeletingEvent = this.PRPLACEPRPLACEELEMENTIRowDeleting;
                    if (pRPLACEPRPLACEELEMENTIRowDeletingEvent != null)
                    {
                        pRPLACEPRPLACEELEMENTIRowDeletingEvent(this, new PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRowChangeEvent((PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePRPLACEPRPLACEELEMENTIRow(PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow row)
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

            public DataColumn IDELEMENTColumn
            {
                get
                {
                    return this.columnIDELEMENT;
                }
            }

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow this[int index]
            {
                get
                {
                    return (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVELEMENTColumn
            {
                get
                {
                    return this.columnNAZIVELEMENT;
                }
            }

            public DataColumn POSTOTAKColumn
            {
                get
                {
                    return this.columnPOSTOTAK;
                }
            }

            public DataColumn PRPLACEIDColumn
            {
                get
                {
                    return this.columnPRPLACEID;
                }
            }

            public DataColumn PRPLACEZAGODINUColumn
            {
                get
                {
                    return this.columnPRPLACEZAGODINU;
                }
            }

            public DataColumn PRPLACEZAMJESECColumn
            {
                get
                {
                    return this.columnPRPLACEZAMJESEC;
                }
            }
        }

        [Serializable]
        public class PRPLACEPRPLACEELEMENTIRADNIKDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDELEMENT;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnPREZIME;
            private DataColumn columnPRPLACEID;
            private DataColumn columnPRPLACEIZNOS;
            private DataColumn columnPRPLACEPOSTOTAK;
            private DataColumn columnPRPLACESATI;
            private DataColumn columnPRPLACESATNICA;
            private DataColumn columnPRPLACEZAGODINU;
            private DataColumn columnPRPLACEZAMJESEC;
            private DataColumn columnSPOJENOPREZIME;

            public event PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRowChangeEventHandler PRPLACEPRPLACEELEMENTIRADNIKRowChanged;

            public event PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRowChangeEventHandler PRPLACEPRPLACEELEMENTIRADNIKRowChanging;

            public event PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRowChangeEventHandler PRPLACEPRPLACEELEMENTIRADNIKRowDeleted;

            public event PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRowChangeEventHandler PRPLACEPRPLACEELEMENTIRADNIKRowDeleting;

            public PRPLACEPRPLACEELEMENTIRADNIKDataTable()
            {
                this.TableName = "PRPLACEPRPLACEELEMENTIRADNIK";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal PRPLACEPRPLACEELEMENTIRADNIKDataTable(DataTable table) : base(table.TableName)
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

            protected PRPLACEPRPLACEELEMENTIRADNIKDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPRPLACEPRPLACEELEMENTIRADNIKRow(PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow row)
            {
                this.Rows.Add(row);
            }

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow AddPRPLACEPRPLACEELEMENTIRADNIKRow(short pRPLACEZAMJESEC, int pRPLACEID, short pRPLACEZAGODINU, int iDELEMENT, int iDRADNIK, decimal pRPLACESATI, decimal pRPLACESATNICA, decimal pRPLACEPOSTOTAK, decimal pRPLACEIZNOS)
            {
                PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow row = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow) this.NewRow();
                row["PRPLACEZAMJESEC"] = pRPLACEZAMJESEC;
                row["PRPLACEID"] = pRPLACEID;
                row["PRPLACEZAGODINU"] = pRPLACEZAGODINU;
                row["IDELEMENT"] = iDELEMENT;
                row["IDRADNIK"] = iDRADNIK;
                row["PRPLACESATI"] = pRPLACESATI;
                row["PRPLACESATNICA"] = pRPLACESATNICA;
                row["PRPLACEPOSTOTAK"] = pRPLACEPOSTOTAK;
                row["PRPLACEIZNOS"] = pRPLACEIZNOS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKDataTable table = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow FindByPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINUIDELEMENTIDRADNIK(short pRPLACEZAMJESEC, int pRPLACEID, short pRPLACEZAGODINU, int iDELEMENT, int iDRADNIK)
            {
                return (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow) this.Rows.Find(new object[] { pRPLACEZAMJESEC, pRPLACEID, pRPLACEZAGODINU, iDELEMENT, iDRADNIK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                PRPLACEDataSet set = new PRPLACEDataSet();
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
                this.columnPRPLACEZAMJESEC = new DataColumn("PRPLACEZAMJESEC", typeof(short), "", MappingType.Element);
                this.columnPRPLACEZAMJESEC.AllowDBNull = false;
                this.columnPRPLACEZAMJESEC.Caption = "PRPLACEZAMJESEC";
                this.columnPRPLACEZAMJESEC.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("IsKey", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Description", "Za mjesec");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Length", "2");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Decimals", "0");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEZAMJESEC.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEZAMJESEC");
                this.Columns.Add(this.columnPRPLACEZAMJESEC);
                this.columnPRPLACEID = new DataColumn("PRPLACEID", typeof(int), "", MappingType.Element);
                this.columnPRPLACEID.AllowDBNull = false;
                this.columnPRPLACEID.Caption = "PRPLACEID";
                this.columnPRPLACEID.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEID.ExtendedProperties.Add("IsKey", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACEID.ExtendedProperties.Add("Description", "Broj pripreme unutar mjeseca");
                this.columnPRPLACEID.ExtendedProperties.Add("Length", "5");
                this.columnPRPLACEID.ExtendedProperties.Add("Decimals", "0");
                this.columnPRPLACEID.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEID.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEID.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEID");
                this.Columns.Add(this.columnPRPLACEID);
                this.columnPRPLACEZAGODINU = new DataColumn("PRPLACEZAGODINU", typeof(short), "", MappingType.Element);
                this.columnPRPLACEZAGODINU.AllowDBNull = false;
                this.columnPRPLACEZAGODINU.Caption = "PRPLACEZAGODINU";
                this.columnPRPLACEZAGODINU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("IsKey", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Description", "Za godinu");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Length", "4");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Decimals", "0");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEZAGODINU.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEZAGODINU");
                this.Columns.Add(this.columnPRPLACEZAGODINU);
                this.columnIDELEMENT = new DataColumn("IDELEMENT", typeof(int), "", MappingType.Element);
                this.columnIDELEMENT.AllowDBNull = false;
                this.columnIDELEMENT.Caption = "Šifra elementa";
                this.columnIDELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDELEMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDELEMENT.ExtendedProperties.Add("Description", "Šifra elementa");
                this.columnIDELEMENT.ExtendedProperties.Add("Length", "8");
                this.columnIDELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDELEMENT");
                this.Columns.Add(this.columnIDELEMENT);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Zaposlenik");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnPREZIME = new DataColumn("PREZIME", typeof(string), "", MappingType.Element);
                this.columnPREZIME.AllowDBNull = true;
                this.columnPREZIME.Caption = "Prezime";
                this.columnPREZIME.MaxLength = 50;
                this.columnPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "PREZIME");
                this.Columns.Add(this.columnPREZIME);
                this.columnIME = new DataColumn("IME", typeof(string), "", MappingType.Element);
                this.columnIME.AllowDBNull = true;
                this.columnIME.Caption = "Ime";
                this.columnIME.MaxLength = 50;
                this.columnIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIME.ExtendedProperties.Add("IsKey", "false");
                this.columnIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIME.ExtendedProperties.Add("Description", "Ime");
                this.columnIME.ExtendedProperties.Add("Length", "50");
                this.columnIME.ExtendedProperties.Add("Decimals", "0");
                this.columnIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.InternalName", "IME");
                this.Columns.Add(this.columnIME);
                this.columnPRPLACESATI = new DataColumn("PRPLACESATI", typeof(decimal), "", MappingType.Element);
                this.columnPRPLACESATI.AllowDBNull = false;
                this.columnPRPLACESATI.Caption = "PRPLACESATI";
                this.columnPRPLACESATI.DefaultValue = 0;
                this.columnPRPLACESATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACESATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACESATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACESATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACESATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACESATI.ExtendedProperties.Add("IsKey", "false");
                this.columnPRPLACESATI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRPLACESATI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACESATI.ExtendedProperties.Add("Description", "Sati");
                this.columnPRPLACESATI.ExtendedProperties.Add("Length", "5");
                this.columnPRPLACESATI.ExtendedProperties.Add("Decimals", "2");
                this.columnPRPLACESATI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRPLACESATI.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPRPLACESATI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACESATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACESATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACESATI.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACESATI");
                this.Columns.Add(this.columnPRPLACESATI);
                this.columnPRPLACESATNICA = new DataColumn("PRPLACESATNICA", typeof(decimal), "", MappingType.Element);
                this.columnPRPLACESATNICA.AllowDBNull = false;
                this.columnPRPLACESATNICA.Caption = "PRPLACESATNICA";
                this.columnPRPLACESATNICA.DefaultValue = 0;
                this.columnPRPLACESATNICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("IsKey", "false");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("Description", "Satnica");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("Length", "5");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("Decimals", "2");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACESATNICA.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACESATNICA");
                this.Columns.Add(this.columnPRPLACESATNICA);
                this.columnPRPLACEPOSTOTAK = new DataColumn("PRPLACEPOSTOTAK", typeof(decimal), "", MappingType.Element);
                this.columnPRPLACEPOSTOTAK.AllowDBNull = false;
                this.columnPRPLACEPOSTOTAK.Caption = "PRPLACEPOSTOTAK";
                this.columnPRPLACEPOSTOTAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("IsKey", "false");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("Description", "Postotak");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("Length", "5");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("Decimals", "2");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEPOSTOTAK.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEPOSTOTAK");
                this.Columns.Add(this.columnPRPLACEPOSTOTAK);
                this.columnPRPLACEIZNOS = new DataColumn("PRPLACEIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnPRPLACEIZNOS.AllowDBNull = false;
                this.columnPRPLACEIZNOS.Caption = "PRPLACEIZNOS";
                this.columnPRPLACEIZNOS.DefaultValue = 0;
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("Description", "Iznos");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRPLACEIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "PRPLACEIZNOS");
                this.Columns.Add(this.columnPRPLACEIZNOS);
                this.columnSPOJENOPREZIME = new DataColumn("SPOJENOPREZIME", typeof(string), "", MappingType.Element);
                this.columnSPOJENOPREZIME.AllowDBNull = true;
                this.columnSPOJENOPREZIME.Caption = "SPOJENOPREZIME";
                this.columnSPOJENOPREZIME.MaxLength = 100;
                this.columnSPOJENOPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Description", "SPOJENOPREZIME");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Length", "100");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "SPOJENOPREZIME");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnSPOJENOPREZIME);
                this.PrimaryKey = new DataColumn[] { this.columnPRPLACEZAMJESEC, this.columnPRPLACEID, this.columnPRPLACEZAGODINU, this.columnIDELEMENT, this.columnIDRADNIK };
                this.ExtendedProperties.Add("ParentLvl", "PRPLACEPRPLACEELEMENTI");
                this.ExtendedProperties.Add("LevelName", "RADNIK");
                this.ExtendedProperties.Add("Description", "Radnici u pripremi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnPRPLACEZAMJESEC = this.Columns["PRPLACEZAMJESEC"];
                this.columnPRPLACEID = this.Columns["PRPLACEID"];
                this.columnPRPLACEZAGODINU = this.Columns["PRPLACEZAGODINU"];
                this.columnIDELEMENT = this.Columns["IDELEMENT"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnPRPLACESATI = this.Columns["PRPLACESATI"];
                this.columnPRPLACESATNICA = this.Columns["PRPLACESATNICA"];
                this.columnPRPLACEPOSTOTAK = this.Columns["PRPLACEPOSTOTAK"];
                this.columnPRPLACEIZNOS = this.Columns["PRPLACEIZNOS"];
                this.columnSPOJENOPREZIME = this.Columns["SPOJENOPREZIME"];
            }

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow NewPRPLACEPRPLACEELEMENTIRADNIKRow()
            {
                return (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PRPLACEPRPLACEELEMENTIRADNIKRowChanged != null)
                {
                    PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRowChangeEventHandler pRPLACEPRPLACEELEMENTIRADNIKRowChangedEvent = this.PRPLACEPRPLACEELEMENTIRADNIKRowChanged;
                    if (pRPLACEPRPLACEELEMENTIRADNIKRowChangedEvent != null)
                    {
                        pRPLACEPRPLACEELEMENTIRADNIKRowChangedEvent(this, new PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRowChangeEvent((PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PRPLACEPRPLACEELEMENTIRADNIKRowChanging != null)
                {
                    PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRowChangeEventHandler pRPLACEPRPLACEELEMENTIRADNIKRowChangingEvent = this.PRPLACEPRPLACEELEMENTIRADNIKRowChanging;
                    if (pRPLACEPRPLACEELEMENTIRADNIKRowChangingEvent != null)
                    {
                        pRPLACEPRPLACEELEMENTIRADNIKRowChangingEvent(this, new PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRowChangeEvent((PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.PRPLACEPRPLACEELEMENTIRADNIKRowDeleted != null)
                {
                    PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRowChangeEventHandler pRPLACEPRPLACEELEMENTIRADNIKRowDeletedEvent = this.PRPLACEPRPLACEELEMENTIRADNIKRowDeleted;
                    if (pRPLACEPRPLACEELEMENTIRADNIKRowDeletedEvent != null)
                    {
                        pRPLACEPRPLACEELEMENTIRADNIKRowDeletedEvent(this, new PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRowChangeEvent((PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PRPLACEPRPLACEELEMENTIRADNIKRowDeleting != null)
                {
                    PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRowChangeEventHandler pRPLACEPRPLACEELEMENTIRADNIKRowDeletingEvent = this.PRPLACEPRPLACEELEMENTIRADNIKRowDeleting;
                    if (pRPLACEPRPLACEELEMENTIRADNIKRowDeletingEvent != null)
                    {
                        pRPLACEPRPLACEELEMENTIRADNIKRowDeletingEvent(this, new PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRowChangeEvent((PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePRPLACEPRPLACEELEMENTIRADNIKRow(PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow row)
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

            public DataColumn IDELEMENTColumn
            {
                get
                {
                    return this.columnIDELEMENT;
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

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow this[int index]
            {
                get
                {
                    return (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow) this.Rows[index];
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn PRPLACEIDColumn
            {
                get
                {
                    return this.columnPRPLACEID;
                }
            }

            public DataColumn PRPLACEIZNOSColumn
            {
                get
                {
                    return this.columnPRPLACEIZNOS;
                }
            }

            public DataColumn PRPLACEPOSTOTAKColumn
            {
                get
                {
                    return this.columnPRPLACEPOSTOTAK;
                }
            }

            public DataColumn PRPLACESATIColumn
            {
                get
                {
                    return this.columnPRPLACESATI;
                }
            }

            public DataColumn PRPLACESATNICAColumn
            {
                get
                {
                    return this.columnPRPLACESATNICA;
                }
            }

            public DataColumn PRPLACEZAGODINUColumn
            {
                get
                {
                    return this.columnPRPLACEZAGODINU;
                }
            }

            public DataColumn PRPLACEZAMJESECColumn
            {
                get
                {
                    return this.columnPRPLACEZAMJESEC;
                }
            }

            public DataColumn SPOJENOPREZIMEColumn
            {
                get
                {
                    return this.columnSPOJENOPREZIME;
                }
            }
        }

        public class PRPLACEPRPLACEELEMENTIRADNIKRow : DataRow
        {
            private PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKDataTable tablePRPLACEPRPLACEELEMENTIRADNIK;

            internal PRPLACEPRPLACEELEMENTIRADNIKRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePRPLACEPRPLACEELEMENTIRADNIK = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKDataTable) this.Table;
            }

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow GetPRPLACEPRPLACEELEMENTIRow()
            {
                return (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) this.GetParentRow("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK");
            }

            public bool IsIDELEMENTNull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTIRADNIK.IDELEMENTColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTIRADNIK.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTIRADNIK.IMEColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTIRADNIK.PREZIMEColumn);
            }

            public bool IsPRPLACEIDNull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEIDColumn);
            }

            public bool IsPRPLACEIZNOSNull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEIZNOSColumn);
            }

            public bool IsPRPLACEPOSTOTAKNull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEPOSTOTAKColumn);
            }

            public bool IsPRPLACESATINull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACESATIColumn);
            }

            public bool IsPRPLACESATNICANull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACESATNICAColumn);
            }

            public bool IsPRPLACEZAGODINUNull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEZAGODINUColumn);
            }

            public bool IsPRPLACEZAMJESECNull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEZAMJESECColumn);
            }

            public bool IsSPOJENOPREZIMENull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTIRADNIK.SPOJENOPREZIMEColumn);
            }

            public void SetIMENull()
            {
                this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRPLACEIZNOSNull()
            {
                this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRPLACEPOSTOTAKNull()
            {
                this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEPOSTOTAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRPLACESATINull()
            {
                this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACESATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRPLACESATNICANull()
            {
                this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACESATNICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSPOJENOPREZIMENull()
            {
                this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.SPOJENOPREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDELEMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.IDELEMENTColumn]);
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.IDELEMENTColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.IMEColumn]);
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
                    this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.IMEColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PREZIMEColumn]);
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
                    this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PREZIMEColumn] = value;
                }
            }

            public int PRPLACEID
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEIDColumn]);
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEIDColumn] = value;
                }
            }

            public decimal PRPLACEIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PRPLACEIZNOS because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEIZNOSColumn] = value;
                }
            }

            public decimal PRPLACEPOSTOTAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEPOSTOTAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PRPLACEPOSTOTAK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEPOSTOTAKColumn] = value;
                }
            }

            public decimal PRPLACESATI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACESATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PRPLACESATI because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACESATIColumn] = value;
                }
            }

            public decimal PRPLACESATNICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACESATNICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PRPLACESATNICA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACESATNICAColumn] = value;
                }
            }

            public short PRPLACEZAGODINU
            {
                get
                {
                    return Conversions.ToShort(this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEZAGODINUColumn]);
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEZAGODINUColumn] = value;
                }
            }

            public short PRPLACEZAMJESEC
            {
                get
                {
                    return Conversions.ToShort(this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEZAMJESECColumn]);
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.PRPLACEZAMJESECColumn] = value;
                }
            }

            public string SPOJENOPREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.SPOJENOPREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SPOJENOPREZIME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTIRADNIK.SPOJENOPREZIMEColumn] = value;
                }
            }
        }

        public class PRPLACEPRPLACEELEMENTIRADNIKRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow eventRow;

            public PRPLACEPRPLACEELEMENTIRADNIKRowChangeEvent(PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow row, DataRowAction action)
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

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PRPLACEPRPLACEELEMENTIRADNIKRowChangeEventHandler(object sender, PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRowChangeEvent e);

        public class PRPLACEPRPLACEELEMENTIRow : DataRow
        {
            private PRPLACEDataSet.PRPLACEPRPLACEELEMENTIDataTable tablePRPLACEPRPLACEELEMENTI;

            internal PRPLACEPRPLACEELEMENTIRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePRPLACEPRPLACEELEMENTI = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIDataTable) this.Table;
            }

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow[] GetPRPLACEPRPLACEELEMENTIRADNIKRows()
            {
                return (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow[]) this.GetChildRows("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK");
            }

            public PRPLACEDataSet.PRPLACERow GetPRPLACERow()
            {
                return (PRPLACEDataSet.PRPLACERow) this.GetParentRow("PRPLACE_PRPLACEPRPLACEELEMENTI");
            }

            public bool IsIDELEMENTNull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTI.IDELEMENTColumn);
            }

            public bool IsNAZIVELEMENTNull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTI.NAZIVELEMENTColumn);
            }

            public bool IsPOSTOTAKNull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTI.POSTOTAKColumn);
            }

            public bool IsPRPLACEIDNull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTI.PRPLACEIDColumn);
            }

            public bool IsPRPLACEZAGODINUNull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTI.PRPLACEZAGODINUColumn);
            }

            public bool IsPRPLACEZAMJESECNull()
            {
                return this.IsNull(this.tablePRPLACEPRPLACEELEMENTI.PRPLACEZAMJESECColumn);
            }

            public void SetNAZIVELEMENTNull()
            {
                this[this.tablePRPLACEPRPLACEELEMENTI.NAZIVELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOSTOTAKNull()
            {
                this[this.tablePRPLACEPRPLACEELEMENTI.POSTOTAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDELEMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePRPLACEPRPLACEELEMENTI.IDELEMENTColumn]);
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTI.IDELEMENTColumn] = value;
                }
            }

            public string NAZIVELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePRPLACEPRPLACEELEMENTI.NAZIVELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTI.NAZIVELEMENTColumn] = value;
                }
            }

            public decimal POSTOTAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePRPLACEPRPLACEELEMENTI.POSTOTAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTI.POSTOTAKColumn] = value;
                }
            }

            public int PRPLACEID
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePRPLACEPRPLACEELEMENTI.PRPLACEIDColumn]);
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTI.PRPLACEIDColumn] = value;
                }
            }

            public short PRPLACEZAGODINU
            {
                get
                {
                    return Conversions.ToShort(this[this.tablePRPLACEPRPLACEELEMENTI.PRPLACEZAGODINUColumn]);
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTI.PRPLACEZAGODINUColumn] = value;
                }
            }

            public short PRPLACEZAMJESEC
            {
                get
                {
                    return Conversions.ToShort(this[this.tablePRPLACEPRPLACEELEMENTI.PRPLACEZAMJESECColumn]);
                }
                set
                {
                    this[this.tablePRPLACEPRPLACEELEMENTI.PRPLACEZAMJESECColumn] = value;
                }
            }
        }

        public class PRPLACEPRPLACEELEMENTIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow eventRow;

            public PRPLACEPRPLACEELEMENTIRowChangeEvent(PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow row, DataRowAction action)
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

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PRPLACEPRPLACEELEMENTIRowChangeEventHandler(object sender, PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRowChangeEvent e);

        public class PRPLACERow : DataRow
        {
            private PRPLACEDataSet.PRPLACEDataTable tablePRPLACE;

            internal PRPLACERow(DataRowBuilder rb) : base(rb)
            {
                this.tablePRPLACE = (PRPLACEDataSet.PRPLACEDataTable) this.Table;
            }

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow[] GetPRPLACEPRPLACEELEMENTIRows()
            {
                return (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow[]) this.GetChildRows("PRPLACE_PRPLACEPRPLACEELEMENTI");
            }

            public bool IsPRPLACEIDNull()
            {
                return this.IsNull(this.tablePRPLACE.PRPLACEIDColumn);
            }

            public bool IsPRPLACEOPISNull()
            {
                return this.IsNull(this.tablePRPLACE.PRPLACEOPISColumn);
            }

            public bool IsPRPLACEOSNOVICANull()
            {
                return this.IsNull(this.tablePRPLACE.PRPLACEOSNOVICAColumn);
            }

            public bool IsPRPLACEPROSJECNISATINull()
            {
                return this.IsNull(this.tablePRPLACE.PRPLACEPROSJECNISATIColumn);
            }

            public bool IsPRPLACEZAGODINUNull()
            {
                return this.IsNull(this.tablePRPLACE.PRPLACEZAGODINUColumn);
            }

            public bool IsPRPLACEZAMJESECNull()
            {
                return this.IsNull(this.tablePRPLACE.PRPLACEZAMJESECColumn);
            }

            public void SetPRPLACEOPISNull()
            {
                this[this.tablePRPLACE.PRPLACEOPISColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRPLACEOSNOVICANull()
            {
                this[this.tablePRPLACE.PRPLACEOSNOVICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRPLACEPROSJECNISATINull()
            {
                this[this.tablePRPLACE.PRPLACEPROSJECNISATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int PRPLACEID
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePRPLACE.PRPLACEIDColumn]);
                }
                set
                {
                    this[this.tablePRPLACE.PRPLACEIDColumn] = value;
                }
            }

            public string PRPLACEOPIS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePRPLACE.PRPLACEOPISColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePRPLACE.PRPLACEOPISColumn] = value;
                }
            }

            public decimal PRPLACEOSNOVICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePRPLACE.PRPLACEOSNOVICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePRPLACE.PRPLACEOSNOVICAColumn] = value;
                }
            }

            public decimal PRPLACEPROSJECNISATI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePRPLACE.PRPLACEPROSJECNISATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePRPLACE.PRPLACEPROSJECNISATIColumn] = value;
                }
            }

            public short PRPLACEZAGODINU
            {
                get
                {
                    return Conversions.ToShort(this[this.tablePRPLACE.PRPLACEZAGODINUColumn]);
                }
                set
                {
                    this[this.tablePRPLACE.PRPLACEZAGODINUColumn] = value;
                }
            }

            public short PRPLACEZAMJESEC
            {
                get
                {
                    return Conversions.ToShort(this[this.tablePRPLACE.PRPLACEZAMJESECColumn]);
                }
                set
                {
                    this[this.tablePRPLACE.PRPLACEZAMJESECColumn] = value;
                }
            }
        }

        public class PRPLACERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private PRPLACEDataSet.PRPLACERow eventRow;

            public PRPLACERowChangeEvent(PRPLACEDataSet.PRPLACERow row, DataRowAction action)
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

            public PRPLACEDataSet.PRPLACERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PRPLACERowChangeEventHandler(object sender, PRPLACEDataSet.PRPLACERowChangeEvent e);
    }
}

