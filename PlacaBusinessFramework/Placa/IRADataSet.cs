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
    public class IRADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private IRADataTable tableIRA;

        public IRADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected IRADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["IRA"] != null)
                    {
                        this.Tables.Add(new IRADataTable(dataSet.Tables["IRA"]));
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
            IRADataSet set = (IRADataSet) base.Clone();
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
            IRADataSet set = new IRADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "IRADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2044");
            this.ExtendedProperties.Add("DataSetName", "IRADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IIRADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "IRA");
            this.ExtendedProperties.Add("ObjectDescription", "IRA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Finpos");
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
            this.DataSetName = "IRADataSet";
            this.Namespace = "http://www.tempuri.org/IRA";
            this.tableIRA = new IRADataTable();
            this.Tables.Add(this.tableIRA);
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
            this.tableIRA = (IRADataTable) this.Tables["IRA"];
            if (initTable && (this.tableIRA != null))
            {
                this.tableIRA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["IRA"] != null)
                {
                    this.Tables.Add(new IRADataTable(dataSet.Tables["IRA"]));
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

        private bool ShouldSerializeIRA()
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
        public IRADataTable IRA
        {
            get
            {
                return this.tableIRA;
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
        public class IRADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDTIPIRA;
            private DataColumn columnIRABROJ;
            private DataColumn columnIRADATUM;
            private DataColumn columnIRADOKIDDOKUMENT;
            private DataColumn columnIRAGODIDGODINE;
            private DataColumn columnIRANAPOMENA;
            private DataColumn columnIRAPARTNERIDPARTNER;
            private DataColumn columnIRAUKUPNO;
            private DataColumn columnIRAVALUTA;
            private DataColumn columnIZVOZ;
            private DataColumn columnMEDJTRANS;
            private DataColumn columnNEPODLEZE;
            private DataColumn columnNEPODLEZE_USLUGA;
            private DataColumn columnNULA;
            private DataColumn columnOSN05;            
            private DataColumn columnOSN10;
            private DataColumn columnOSN22;
            private DataColumn columnOSN23;
            private DataColumn columnOSN25;
            private DataColumn columnOSTALO;
            private DataColumn columnPDV05;
            private DataColumn columnPDV10;
            private DataColumn columnPDV22;
            private DataColumn columnPDV23;
            private DataColumn columnPDV25;
            private DataColumn columnTUZEMSTVO;

            public event IRADataSet.IRARowChangeEventHandler IRARowChanged;

            public event IRADataSet.IRARowChangeEventHandler IRARowChanging;

            public event IRADataSet.IRARowChangeEventHandler IRARowDeleted;

            public event IRADataSet.IRARowChangeEventHandler IRARowDeleting;

            public IRADataTable()
            {
                this.TableName = "IRA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal IRADataTable(DataTable table) : base(table.TableName)
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

            protected IRADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddIRARow(IRADataSet.IRARow row)
            {
                this.Rows.Add(row);
            }

            public IRADataSet.IRARow AddIRARow(short iRAGODIDGODINE, int iRADOKIDDOKUMENT, int iRABROJ, int iRAPARTNERIDPARTNER, int iDTIPIRA, DateTime iRADATUM, DateTime iRAVALUTA, string iRANAPOMENA,
                decimal iRAUKUPNO, decimal nEPODLEZE, decimal nEPODLEZE_USLUGA, decimal iZVOZ, decimal mEDJTRANS, decimal tUZEMSTVO, decimal oSTALO, decimal nULA,
                decimal oSN05, decimal oSN10, decimal oSN22, decimal oSN23, decimal oSN25, decimal pDV05, decimal pDV10, decimal pDV22, decimal pDV23, decimal pDV25)
            {
                IRADataSet.IRARow row = (IRADataSet.IRARow) this.NewRow();
                row["IRAGODIDGODINE"] = iRAGODIDGODINE;
                row["IRADOKIDDOKUMENT"] = iRADOKIDDOKUMENT;
                row["IRABROJ"] = iRABROJ;
                row["IRAPARTNERIDPARTNER"] = iRAPARTNERIDPARTNER;
                row["IDTIPIRA"] = iDTIPIRA;
                row["IRADATUM"] = iRADATUM;
                row["IRAVALUTA"] = iRAVALUTA;
                row["IRANAPOMENA"] = iRANAPOMENA;
                row["IRAUKUPNO"] = iRAUKUPNO;
                row["NEPODLEZE"] = nEPODLEZE;
                row["NEPODLEZE_USLUGA"] = nEPODLEZE_USLUGA;
                row["IZVOZ"] = iZVOZ;
                row["MEDJTRANS"] = mEDJTRANS;
                row["TUZEMSTVO"] = tUZEMSTVO;
                row["OSTALO"] = oSTALO;
                row["NULA"] = nULA;
                row["OSN05"] = oSN05;
                row["OSN10"] = oSN10;
                row["OSN22"] = oSN22;
                row["OSN23"] = oSN23;
                row["OSN25"] = oSN25;
                row["PDV05"] = pDV05;
                row["PDV10"] = pDV10;
                row["PDV22"] = pDV22;
                row["PDV23"] = pDV23;
                row["PDV25"] = pDV25;
                
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                IRADataSet.IRADataTable table = (IRADataSet.IRADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IRADataSet.IRARow FindByIRAGODIDGODINEIRADOKIDDOKUMENTIRABROJ(short iRAGODIDGODINE, int iRADOKIDDOKUMENT, int iRABROJ)
            {
                return (IRADataSet.IRARow) this.Rows.Find(new object[] { iRAGODIDGODINE, iRADOKIDDOKUMENT, iRABROJ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(IRADataSet.IRARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                IRADataSet set = new IRADataSet();
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
                this.columnIRAGODIDGODINE = new DataColumn("IRAGODIDGODINE", typeof(short), "", MappingType.Element);
                this.columnIRAGODIDGODINE.AllowDBNull = false;
                this.columnIRAGODIDGODINE.Caption = "IDGODINE";
                this.columnIRAGODIDGODINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("SuperType", "IDGODINE");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("SubtypeGroup", "IRAGOD");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("IsKey", "true");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Description", "IDGODINE");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Length", "4");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Decimals", "0");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRAGODIDGODINE.ExtendedProperties.Add("Deklarit.InternalName", "IRAGODIDGODINE");
                this.Columns.Add(this.columnIRAGODIDGODINE);
                this.columnIRADOKIDDOKUMENT = new DataColumn("IRADOKIDDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnIRADOKIDDOKUMENT.AllowDBNull = false;
                this.columnIRADOKIDDOKUMENT.Caption = "Šifra dokumenta";
                this.columnIRADOKIDDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "#######");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "#######");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("SuperType", "IDDOKUMENT");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("SubtypeGroup", "IRADOK");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Description", "Šifra dokumenta");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Length", "8");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRADOKIDDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "IRADOKIDDOKUMENT");
                this.Columns.Add(this.columnIRADOKIDDOKUMENT);
                this.columnIRABROJ = new DataColumn("IRABROJ", typeof(int), "", MappingType.Element);
                this.columnIRABROJ.AllowDBNull = false;
                this.columnIRABROJ.Caption = "IRABROJ";
                this.columnIRABROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRABROJ.ExtendedProperties.Add("IsKey", "true");
                this.columnIRABROJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIRABROJ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIRABROJ.ExtendedProperties.Add("Description", "Broj IRE");
                this.columnIRABROJ.ExtendedProperties.Add("Length", "8");
                this.columnIRABROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnIRABROJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIRABROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRABROJ.ExtendedProperties.Add("Deklarit.InternalName", "IRABROJ");
                this.Columns.Add(this.columnIRABROJ);
                this.columnIRAPARTNERIDPARTNER = new DataColumn("IRAPARTNERIDPARTNER", typeof(int), "", MappingType.Element);
                this.columnIRAPARTNERIDPARTNER.AllowDBNull = false;
                this.columnIRAPARTNERIDPARTNER.Caption = "Šifra partnera";
                this.columnIRAPARTNERIDPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("SuperType", "IDPARTNER");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("SubtypeGroup", "IRAPARTNER");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Description", "Šifra partnera");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Length", "9");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRAPARTNERIDPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "IRAPARTNERIDPARTNER");
                this.Columns.Add(this.columnIRAPARTNERIDPARTNER);
                this.columnIDTIPIRA = new DataColumn("IDTIPIRA", typeof(int), "", MappingType.Element);
                this.columnIDTIPIRA.AllowDBNull = false;
                this.columnIDTIPIRA.Caption = "IDTIPIRA";
                this.columnIDTIPIRA.DefaultValue = 1;
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPIRA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDTIPIRA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDTIPIRA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPIRA.ExtendedProperties.Add("Description", "Tip IRE");
                this.columnIDTIPIRA.ExtendedProperties.Add("Length", "5");
                this.columnIDTIPIRA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPIRA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDTIPIRA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPIRA");
                this.Columns.Add(this.columnIDTIPIRA);
                this.columnIRADATUM = new DataColumn("IRADATUM", typeof(DateTime), "", MappingType.Element);
                this.columnIRADATUM.AllowDBNull = false;
                this.columnIRADATUM.Caption = "IRADATUM";
                this.columnIRADATUM.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRADATUM.ExtendedProperties.Add("IsKey", "false");
                this.columnIRADATUM.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIRADATUM.ExtendedProperties.Add("DeklaritType", "date");
                this.columnIRADATUM.ExtendedProperties.Add("Description", "Datum");
                this.columnIRADATUM.ExtendedProperties.Add("Length", "8");
                this.columnIRADATUM.ExtendedProperties.Add("Decimals", "0");
                this.columnIRADATUM.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIRADATUM.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRADATUM.ExtendedProperties.Add("Deklarit.InternalName", "IRADATUM");
                this.Columns.Add(this.columnIRADATUM);
                this.columnIRAVALUTA = new DataColumn("IRAVALUTA", typeof(DateTime), "", MappingType.Element);
                this.columnIRAVALUTA.AllowDBNull = false;
                this.columnIRAVALUTA.Caption = "IRAVALUTA";
                this.columnIRAVALUTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRAVALUTA.ExtendedProperties.Add("IsKey", "false");
                this.columnIRAVALUTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIRAVALUTA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnIRAVALUTA.ExtendedProperties.Add("Description", "Valuta");
                this.columnIRAVALUTA.ExtendedProperties.Add("Length", "8");
                this.columnIRAVALUTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIRAVALUTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIRAVALUTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRAVALUTA.ExtendedProperties.Add("Deklarit.InternalName", "IRAVALUTA");
                this.Columns.Add(this.columnIRAVALUTA);
                this.columnIRANAPOMENA = new DataColumn("IRANAPOMENA", typeof(string), "", MappingType.Element);
                this.columnIRANAPOMENA.AllowDBNull = false;
                this.columnIRANAPOMENA.Caption = "IRANAPOMENA";
                this.columnIRANAPOMENA.MaxLength = 50;
                this.columnIRANAPOMENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRANAPOMENA.ExtendedProperties.Add("IsKey", "false");
                this.columnIRANAPOMENA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIRANAPOMENA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Description", "Napomena");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Length", "50");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Decimals", "0");
                this.columnIRANAPOMENA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIRANAPOMENA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRANAPOMENA.ExtendedProperties.Add("Deklarit.InternalName", "IRANAPOMENA");
                this.Columns.Add(this.columnIRANAPOMENA);
                this.columnIRAUKUPNO = new DataColumn("IRAUKUPNO", typeof(decimal), "", MappingType.Element);
                this.columnIRAUKUPNO.AllowDBNull = false;
                this.columnIRAUKUPNO.Caption = "IRAUKUPNO";
                this.columnIRAUKUPNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRAUKUPNO.ExtendedProperties.Add("IsKey", "false");
                this.columnIRAUKUPNO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIRAUKUPNO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Description", "Ukupno");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Length", "12");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Decimals", "2");
                this.columnIRAUKUPNO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIRAUKUPNO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIRAUKUPNO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIRAUKUPNO.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRAUKUPNO.ExtendedProperties.Add("Deklarit.InternalName", "IRAUKUPNO");
                this.Columns.Add(this.columnIRAUKUPNO);
                this.columnNEPODLEZE = new DataColumn("NEPODLEZE", typeof(decimal), "", MappingType.Element);
                this.columnNEPODLEZE.AllowDBNull = false;
                this.columnNEPODLEZE.Caption = "NEPODLEZE";
                this.columnNEPODLEZE.DefaultValue = 0;
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNEPODLEZE.ExtendedProperties.Add("IsKey", "false");
                this.columnNEPODLEZE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNEPODLEZE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNEPODLEZE.ExtendedProperties.Add("Description", "Ne podliježe oporezivanju");
                this.columnNEPODLEZE.ExtendedProperties.Add("Length", "12");
                this.columnNEPODLEZE.ExtendedProperties.Add("Decimals", "2");
                this.columnNEPODLEZE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNEPODLEZE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNEPODLEZE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNEPODLEZE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNEPODLEZE.ExtendedProperties.Add("Deklarit.InternalName", "NEPODLEZE");
                this.Columns.Add(this.columnNEPODLEZE);

                this.columnNEPODLEZE_USLUGA = new DataColumn("NEPODLEZE_USLUGA", typeof(decimal), "", MappingType.Element);
                this.columnNEPODLEZE_USLUGA.AllowDBNull = false;
                this.columnNEPODLEZE_USLUGA.Caption = "NEPODLEZE_USLUGA";
                this.columnNEPODLEZE_USLUGA.DefaultValue = 0;
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("IsKey", "false");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("Description", "Ne podliježe oporezivanju");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("Length", "12");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("Decimals", "2");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNEPODLEZE_USLUGA.ExtendedProperties.Add("Deklarit.InternalName", "NEPODLEZE_USLUGA");
                this.Columns.Add(this.columnNEPODLEZE_USLUGA);


                this.columnIZVOZ = new DataColumn("IZVOZ", typeof(decimal), "", MappingType.Element);
                this.columnIZVOZ.AllowDBNull = false;
                this.columnIZVOZ.Caption = "IZVOZ";
                this.columnIZVOZ.DefaultValue = 0;
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZVOZ.ExtendedProperties.Add("IsKey", "false");
                this.columnIZVOZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIZVOZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZVOZ.ExtendedProperties.Add("Description", "IZVOZ");
                this.columnIZVOZ.ExtendedProperties.Add("Length", "12");
                this.columnIZVOZ.ExtendedProperties.Add("Decimals", "2");
                this.columnIZVOZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZVOZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZVOZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIZVOZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZVOZ.ExtendedProperties.Add("Deklarit.InternalName", "IZVOZ");
                this.Columns.Add(this.columnIZVOZ);
                this.columnMEDJTRANS = new DataColumn("MEDJTRANS", typeof(decimal), "", MappingType.Element);
                this.columnMEDJTRANS.AllowDBNull = false;
                this.columnMEDJTRANS.Caption = "MEDJTRANS";
                this.columnMEDJTRANS.DefaultValue = 0;
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMEDJTRANS.ExtendedProperties.Add("IsKey", "false");
                this.columnMEDJTRANS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMEDJTRANS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMEDJTRANS.ExtendedProperties.Add("Description", "Međunarodni transport");
                this.columnMEDJTRANS.ExtendedProperties.Add("Length", "12");
                this.columnMEDJTRANS.ExtendedProperties.Add("Decimals", "2");
                this.columnMEDJTRANS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMEDJTRANS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMEDJTRANS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMEDJTRANS.ExtendedProperties.Add("IsInReader", "true");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMEDJTRANS.ExtendedProperties.Add("Deklarit.InternalName", "MEDJTRANS");
                this.Columns.Add(this.columnMEDJTRANS);
                this.columnTUZEMSTVO = new DataColumn("TUZEMSTVO", typeof(decimal), "", MappingType.Element);
                this.columnTUZEMSTVO.AllowDBNull = false;
                this.columnTUZEMSTVO.Caption = "TUZEMSTVO";
                this.columnTUZEMSTVO.DefaultValue = 0;
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTUZEMSTVO.ExtendedProperties.Add("IsKey", "false");
                this.columnTUZEMSTVO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnTUZEMSTVO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Description", "U tuzemstvu");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Length", "12");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Decimals", "2");
                this.columnTUZEMSTVO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnTUZEMSTVO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnTUZEMSTVO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnTUZEMSTVO.ExtendedProperties.Add("IsInReader", "true");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTUZEMSTVO.ExtendedProperties.Add("Deklarit.InternalName", "TUZEMSTVO");
                this.Columns.Add(this.columnTUZEMSTVO);
                this.columnOSTALO = new DataColumn("OSTALO", typeof(decimal), "", MappingType.Element);
                this.columnOSTALO.AllowDBNull = false;
                this.columnOSTALO.Caption = "OSTALO";
                this.columnOSTALO.DefaultValue = 0;
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSTALO.ExtendedProperties.Add("IsKey", "false");
                this.columnOSTALO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSTALO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSTALO.ExtendedProperties.Add("Description", "OSTALO");
                this.columnOSTALO.ExtendedProperties.Add("Length", "12");
                this.columnOSTALO.ExtendedProperties.Add("Decimals", "2");
                this.columnOSTALO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSTALO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSTALO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSTALO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSTALO.ExtendedProperties.Add("Deklarit.InternalName", "OSTALO");
                this.Columns.Add(this.columnOSTALO);
                this.columnNULA = new DataColumn("NULA", typeof(decimal), "", MappingType.Element);
                this.columnNULA.AllowDBNull = false;
                this.columnNULA.Caption = "NULA";
                this.columnNULA.DefaultValue = 0;
                this.columnNULA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNULA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNULA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNULA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNULA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNULA.ExtendedProperties.Add("IsKey", "false");
                this.columnNULA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNULA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNULA.ExtendedProperties.Add("Description", "0 %");
                this.columnNULA.ExtendedProperties.Add("Length", "12");
                this.columnNULA.ExtendedProperties.Add("Decimals", "2");
                this.columnNULA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNULA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNULA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNULA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNULA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNULA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNULA.ExtendedProperties.Add("Deklarit.InternalName", "NULA");
                this.Columns.Add(this.columnNULA);

                this.columnOSN05 = new DataColumn("OSN05", typeof(decimal), "", MappingType.Element);
                this.columnOSN05.AllowDBNull = false;
                this.columnOSN05.Caption = "OS N05";
                this.columnOSN05.DefaultValue = 0;
                this.columnOSN05.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSN05.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSN05.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSN05.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSN05.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSN05.ExtendedProperties.Add("IsKey", "false");
                this.columnOSN05.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSN05.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSN05.ExtendedProperties.Add("Description", "Osnovica 05");
                this.columnOSN05.ExtendedProperties.Add("Length", "12");
                this.columnOSN05.ExtendedProperties.Add("Decimals", "2");
                this.columnOSN05.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSN05.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSN05.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSN05.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSN05.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSN05.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSN05.ExtendedProperties.Add("Deklarit.InternalName", "OSN05");
                this.Columns.Add(this.columnOSN05);

                this.columnOSN10 = new DataColumn("OSN10", typeof(decimal), "", MappingType.Element);
                this.columnOSN10.AllowDBNull = false;
                this.columnOSN10.Caption = "OS N10";
                this.columnOSN10.DefaultValue = 0;
                this.columnOSN10.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSN10.ExtendedProperties.Add("IsKey", "false");
                this.columnOSN10.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSN10.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSN10.ExtendedProperties.Add("Description", "Osnovica 10");
                this.columnOSN10.ExtendedProperties.Add("Length", "12");
                this.columnOSN10.ExtendedProperties.Add("Decimals", "2");
                this.columnOSN10.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSN10.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSN10.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSN10.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSN10.ExtendedProperties.Add("Deklarit.InternalName", "OSN10");
                this.Columns.Add(this.columnOSN10);
                this.columnOSN22 = new DataColumn("OSN22", typeof(decimal), "", MappingType.Element);
                this.columnOSN22.AllowDBNull = false;
                this.columnOSN22.Caption = "OS N22";
                this.columnOSN22.DefaultValue = 0;
                this.columnOSN22.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSN22.ExtendedProperties.Add("IsKey", "false");
                this.columnOSN22.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSN22.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSN22.ExtendedProperties.Add("Description", "Osnovica 22");
                this.columnOSN22.ExtendedProperties.Add("Length", "12");
                this.columnOSN22.ExtendedProperties.Add("Decimals", "2");
                this.columnOSN22.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSN22.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSN22.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSN22.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSN22.ExtendedProperties.Add("Deklarit.InternalName", "OSN22");
                this.Columns.Add(this.columnOSN22);


                this.columnOSN23 = new DataColumn("OSN23", typeof(decimal), "", MappingType.Element);
                this.columnOSN23.AllowDBNull = false;
                this.columnOSN23.Caption = "OS N23";
                this.columnOSN23.DefaultValue = 0;
                this.columnOSN23.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSN23.ExtendedProperties.Add("IsKey", "false");
                this.columnOSN23.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSN23.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSN23.ExtendedProperties.Add("Description", "Osnovica 23");
                this.columnOSN23.ExtendedProperties.Add("Length", "12");
                this.columnOSN23.ExtendedProperties.Add("Decimals", "2");
                this.columnOSN23.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSN23.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSN23.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSN23.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSN23.ExtendedProperties.Add("Deklarit.InternalName", "OSN23");
                this.Columns.Add(this.columnOSN23);




                this.columnOSN25 = new DataColumn("OSN25", typeof(decimal), "", MappingType.Element);
                this.columnOSN25.AllowDBNull = false;
                this.columnOSN25.Caption = "OS N25";
                this.columnOSN25.DefaultValue = 0;
                this.columnOSN25.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSN25.ExtendedProperties.Add("IsKey", "false");
                this.columnOSN25.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSN25.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSN25.ExtendedProperties.Add("Description", "Osnovica 25");
                this.columnOSN25.ExtendedProperties.Add("Length", "12");
                this.columnOSN25.ExtendedProperties.Add("Decimals", "2");
                this.columnOSN25.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSN25.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSN25.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSN25.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSN25.ExtendedProperties.Add("Deklarit.InternalName", "OSN25");
                this.Columns.Add(this.columnOSN25);


                this.columnPDV05 = new DataColumn("PDV05", typeof(decimal), "", MappingType.Element);
                this.columnPDV05.AllowDBNull = false;
                this.columnPDV05.Caption = "PD V05";
                this.columnPDV05.DefaultValue = 0;
                this.columnPDV05.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV05.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV05.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV05.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV05.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV05.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV05.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV05.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV05.ExtendedProperties.Add("Description", "PDV 05");
                this.columnPDV05.ExtendedProperties.Add("Length", "12");
                this.columnPDV05.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV05.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV05.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV05.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV05.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV05.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV05.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV05.ExtendedProperties.Add("Deklarit.InternalName", "PDV05");
                this.Columns.Add(this.columnPDV05);


                this.columnPDV10 = new DataColumn("PDV10", typeof(decimal), "", MappingType.Element);
                this.columnPDV10.AllowDBNull = false;
                this.columnPDV10.Caption = "PD V10";
                this.columnPDV10.DefaultValue = 0;
                this.columnPDV10.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV10.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV10.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV10.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV10.ExtendedProperties.Add("Description", "PDV 10");
                this.columnPDV10.ExtendedProperties.Add("Length", "12");
                this.columnPDV10.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV10.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV10.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV10.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV10.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV10.ExtendedProperties.Add("Deklarit.InternalName", "PDV10");
                this.Columns.Add(this.columnPDV10);

                this.columnPDV22 = new DataColumn("PDV22", typeof(decimal), "", MappingType.Element);
                this.columnPDV22.AllowDBNull = false;
                this.columnPDV22.Caption = "PD V22";
                this.columnPDV22.DefaultValue = 0;
                this.columnPDV22.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV22.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV22.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV22.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV22.ExtendedProperties.Add("Description", "PDV 22");
                this.columnPDV22.ExtendedProperties.Add("Length", "12");
                this.columnPDV22.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV22.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV22.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV22.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV22.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV22.ExtendedProperties.Add("Deklarit.InternalName", "PDV22");
                this.Columns.Add(this.columnPDV22);


                this.columnPDV23 = new DataColumn("PDV23", typeof(decimal), "", MappingType.Element);
                this.columnPDV23.AllowDBNull = false;
                this.columnPDV23.Caption = "PD V23";
                this.columnPDV23.DefaultValue = 0;
                this.columnPDV23.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV23.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV23.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV23.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV23.ExtendedProperties.Add("Description", "PDV 23");
                this.columnPDV23.ExtendedProperties.Add("Length", "12");
                this.columnPDV23.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV23.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV23.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV23.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV23.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV23.ExtendedProperties.Add("Deklarit.InternalName", "PDV23");
                this.Columns.Add(this.columnPDV23);


                this.columnPDV25 = new DataColumn("PDV25", typeof(decimal), "", MappingType.Element);
                this.columnPDV25.AllowDBNull = false;
                this.columnPDV25.Caption = "PD V25";
                this.columnPDV25.DefaultValue = 0;
                this.columnPDV25.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPDV25.ExtendedProperties.Add("IsKey", "false");
                this.columnPDV25.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPDV25.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPDV25.ExtendedProperties.Add("Description", "PDV 25");
                this.columnPDV25.ExtendedProperties.Add("Length", "12");
                this.columnPDV25.ExtendedProperties.Add("Decimals", "2");
                this.columnPDV25.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPDV25.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPDV25.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPDV25.ExtendedProperties.Add("IsInReader", "true");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPDV25.ExtendedProperties.Add("Deklarit.InternalName", "PDV25");
                this.Columns.Add(this.columnPDV25);



                this.PrimaryKey = new DataColumn[] { this.columnIRAGODIDGODINE, this.columnIRADOKIDDOKUMENT, this.columnIRABROJ };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "IRA");
                this.ExtendedProperties.Add("Description", "IRA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIRAGODIDGODINE = this.Columns["IRAGODIDGODINE"];
                this.columnIRADOKIDDOKUMENT = this.Columns["IRADOKIDDOKUMENT"];
                this.columnIRABROJ = this.Columns["IRABROJ"];
                this.columnIRAPARTNERIDPARTNER = this.Columns["IRAPARTNERIDPARTNER"];
                this.columnIDTIPIRA = this.Columns["IDTIPIRA"];
                this.columnIRADATUM = this.Columns["IRADATUM"];
                this.columnIRAVALUTA = this.Columns["IRAVALUTA"];
                this.columnIRANAPOMENA = this.Columns["IRANAPOMENA"];
                this.columnIRAUKUPNO = this.Columns["IRAUKUPNO"];
                this.columnNEPODLEZE = this.Columns["NEPODLEZE"];
                this.columnNEPODLEZE_USLUGA = this.Columns["NEPODLEZE_USLUGA"];
                this.columnIZVOZ = this.Columns["IZVOZ"];
                this.columnMEDJTRANS = this.Columns["MEDJTRANS"];
                this.columnTUZEMSTVO = this.Columns["TUZEMSTVO"];
                this.columnOSTALO = this.Columns["OSTALO"];
                this.columnNULA = this.Columns["NULA"];
                this.columnOSN10 = this.Columns["OSN10"];
                this.columnOSN22 = this.Columns["OSN22"];
                this.columnOSN23 = this.Columns["OSN23"];
                this.columnOSN25 = this.Columns["OSN25"];
                this.columnPDV10 = this.Columns["PDV10"];
                this.columnPDV22 = this.Columns["PDV22"];
                this.columnPDV23 = this.Columns["PDV23"];
                this.columnPDV25 = this.Columns["PDV25"];
                this.columnOSN05 = this.Columns["OSN05"];
                this.columnPDV05 = this.Columns["PDV05"];
            }

            public IRADataSet.IRARow NewIRARow()
            {
                return (IRADataSet.IRARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new IRADataSet.IRARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.IRARowChanged != null)
                {
                    IRADataSet.IRARowChangeEventHandler iRARowChangedEvent = this.IRARowChanged;
                    if (iRARowChangedEvent != null)
                    {
                        iRARowChangedEvent(this, new IRADataSet.IRARowChangeEvent((IRADataSet.IRARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.IRARowChanging != null)
                {
                    IRADataSet.IRARowChangeEventHandler iRARowChangingEvent = this.IRARowChanging;
                    if (iRARowChangingEvent != null)
                    {
                        iRARowChangingEvent(this, new IRADataSet.IRARowChangeEvent((IRADataSet.IRARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.IRARowDeleted != null)
                {
                    IRADataSet.IRARowChangeEventHandler iRARowDeletedEvent = this.IRARowDeleted;
                    if (iRARowDeletedEvent != null)
                    {
                        iRARowDeletedEvent(this, new IRADataSet.IRARowChangeEvent((IRADataSet.IRARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.IRARowDeleting != null)
                {
                    IRADataSet.IRARowChangeEventHandler iRARowDeletingEvent = this.IRARowDeleting;
                    if (iRARowDeletingEvent != null)
                    {
                        iRARowDeletingEvent(this, new IRADataSet.IRARowChangeEvent((IRADataSet.IRARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveIRARow(IRADataSet.IRARow row)
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

            public DataColumn IDTIPIRAColumn
            {
                get
                {
                    return this.columnIDTIPIRA;
                }
            }

            public DataColumn IRABROJColumn
            {
                get
                {
                    return this.columnIRABROJ;
                }
            }

            public DataColumn IRADATUMColumn
            {
                get
                {
                    return this.columnIRADATUM;
                }
            }

            public DataColumn IRADOKIDDOKUMENTColumn
            {
                get
                {
                    return this.columnIRADOKIDDOKUMENT;
                }
            }

            public DataColumn IRAGODIDGODINEColumn
            {
                get
                {
                    return this.columnIRAGODIDGODINE;
                }
            }

            public DataColumn IRANAPOMENAColumn
            {
                get
                {
                    return this.columnIRANAPOMENA;
                }
            }

            public DataColumn IRAPARTNERIDPARTNERColumn
            {
                get
                {
                    return this.columnIRAPARTNERIDPARTNER;
                }
            }

            public DataColumn IRAUKUPNOColumn
            {
                get
                {
                    return this.columnIRAUKUPNO;
                }
            }

            public DataColumn IRAVALUTAColumn
            {
                get
                {
                    return this.columnIRAVALUTA;
                }
            }

            public IRADataSet.IRARow this[int index]
            {
                get
                {
                    return (IRADataSet.IRARow) this.Rows[index];
                }
            }

            public DataColumn IZVOZColumn
            {
                get
                {
                    return this.columnIZVOZ;
                }
            }

            public DataColumn MEDJTRANSColumn
            {
                get
                {
                    return this.columnMEDJTRANS;
                }
            }

            public DataColumn NEPODLEZEColumn
            {
                get
                {
                    return this.columnNEPODLEZE;
                }
            }

            public DataColumn NEPODLEZE_USLUGAColumn
            {
                get
                {
                    return this.columnNEPODLEZE_USLUGA;
                }
            }

            public DataColumn NULAColumn
            {
                get
                {
                    return this.columnNULA;
                }
            }

            public DataColumn OSN05Column
            {
                get
                {
                    return this.columnOSN05;
                }
            }

            public DataColumn OSN10Column
            {
                get
                {
                    return this.columnOSN10;
                }
            }

            public DataColumn OSN22Column
            {
                get
                {
                    return this.columnOSN22;
                }
            }

            public DataColumn OSN23Column
            {
                get
                {
                    return this.columnOSN23;
                }
            }

            public DataColumn OSN25Column
            {
                get
                {
                    return this.columnOSN25;
                }
            }

            public DataColumn OSTALOColumn
            {
                get
                {
                    return this.columnOSTALO;
                }
            }

            public DataColumn PDV05Column
            {
                get
                {
                    return this.columnPDV05;
                }
            }

            public DataColumn PDV10Column
            {
                get
                {
                    return this.columnPDV10;
                }
            }

            public DataColumn PDV22Column
            {
                get
                {
                    return this.columnPDV22;
                }
            }

            public DataColumn PDV25Column
            {
                get
                {
                    return this.columnPDV25;
                }
            }

            public DataColumn PDV23Column
            {
                get
                {
                    return this.columnPDV23;
                }
            }

            public DataColumn TUZEMSTVOColumn
            {
                get
                {
                    return this.columnTUZEMSTVO;
                }
            }
        }

        public class IRARow : DataRow
        {
            private IRADataSet.IRADataTable tableIRA;

            internal IRARow(DataRowBuilder rb) : base(rb)
            {
                this.tableIRA = (IRADataSet.IRADataTable) this.Table;
            }

            public bool IsIDTIPIRANull()
            {
                return this.IsNull(this.tableIRA.IDTIPIRAColumn);
            }

            public bool IsIRABROJNull()
            {
                return this.IsNull(this.tableIRA.IRABROJColumn);
            }

            public bool IsIRADATUMNull()
            {
                return this.IsNull(this.tableIRA.IRADATUMColumn);
            }

            public bool IsIRADOKIDDOKUMENTNull()
            {
                return this.IsNull(this.tableIRA.IRADOKIDDOKUMENTColumn);
            }

            public bool IsIRAGODIDGODINENull()
            {
                return this.IsNull(this.tableIRA.IRAGODIDGODINEColumn);
            }

            public bool IsIRANAPOMENANull()
            {
                return this.IsNull(this.tableIRA.IRANAPOMENAColumn);
            }

            public bool IsIRAPARTNERIDPARTNERNull()
            {
                return this.IsNull(this.tableIRA.IRAPARTNERIDPARTNERColumn);
            }

            public bool IsIRAUKUPNONull()
            {
                return this.IsNull(this.tableIRA.IRAUKUPNOColumn);
            }

            public bool IsIRAVALUTANull()
            {
                return this.IsNull(this.tableIRA.IRAVALUTAColumn);
            }

            public bool IsIZVOZNull()
            {
                return this.IsNull(this.tableIRA.IZVOZColumn);
            }

            public bool IsMEDJTRANSNull()
            {
                return this.IsNull(this.tableIRA.MEDJTRANSColumn);
            }

            public bool IsNEPODLEZENull()
            {
                return this.IsNull(this.tableIRA.NEPODLEZEColumn);
            }

            public bool IsNEPODLEZE_USLUGANull()
            {
                return this.IsNull(this.tableIRA.NEPODLEZE_USLUGAColumn);
            }

            public bool IsNULANull()
            {
                return this.IsNull(this.tableIRA.NULAColumn);
            }

            public bool IsOSN05Null()
            {
                return this.IsNull(this.tableIRA.OSN05Column);
            }

            public bool IsOSN10Null()
            {
                return this.IsNull(this.tableIRA.OSN10Column);
            }

            public bool IsOSN22Null()
            {
                return this.IsNull(this.tableIRA.OSN22Column);
            }

            public bool IsOSN23Null()
            {
                return this.IsNull(this.tableIRA.OSN23Column);
            }

            public bool IsOSN25Null()
            {
                return this.IsNull(this.tableIRA.OSN25Column);
            }

            public bool IsOSTALONull()
            {
                return this.IsNull(this.tableIRA.OSTALOColumn);
            }

            public bool IsPDV05Null()
            {
                return this.IsNull(this.tableIRA.PDV05Column);
            }

            public bool IsPDV10Null()
            {
                return this.IsNull(this.tableIRA.PDV10Column);
            }

            public bool IsPDV22Null()
            {
                return this.IsNull(this.tableIRA.PDV22Column);
            }

            public bool IsPDV23Null()
            {
                return this.IsNull(this.tableIRA.PDV23Column);
            }

            public bool IsPDV25Null()
            {
                return this.IsNull(this.tableIRA.PDV25Column);
            }

            public bool IsTUZEMSTVONull()
            {
                return this.IsNull(this.tableIRA.TUZEMSTVOColumn);
            }

            public void SetIDTIPIRANull()
            {
                this[this.tableIRA.IDTIPIRAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIRADATUMNull()
            {
                this[this.tableIRA.IRADATUMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIRANAPOMENANull()
            {
                this[this.tableIRA.IRANAPOMENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIRAPARTNERIDPARTNERNull()
            {
                this[this.tableIRA.IRAPARTNERIDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIRAUKUPNONull()
            {
                this[this.tableIRA.IRAUKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIRAVALUTANull()
            {
                this[this.tableIRA.IRAVALUTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZVOZNull()
            {
                this[this.tableIRA.IZVOZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMEDJTRANSNull()
            {
                this[this.tableIRA.MEDJTRANSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNEPODLEZENull()
            {
                this[this.tableIRA.NEPODLEZEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNEPODLEZE_USLUGANull()
            {
                this[this.tableIRA.NEPODLEZE_USLUGAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNULANull()
            {
                this[this.tableIRA.NULAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOS05Null()
            {
                this[this.tableIRA.OSN05Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSN10Null()
            {
                this[this.tableIRA.OSN10Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSN22Null()
            {
                this[this.tableIRA.OSN22Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSN23Null()
            {
                this[this.tableIRA.OSN23Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSN25Null()
            {
                this[this.tableIRA.OSN25Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSTALONull()
            {
                this[this.tableIRA.OSTALOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV05Null()
            {
                this[this.tableIRA.PDV05Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV10Null()
            {
                this[this.tableIRA.PDV10Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV22Null()
            {
                this[this.tableIRA.PDV22Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPDV23Null()
            {
                this[this.tableIRA.PDV23Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }



            public void SetPDV25Null()
            {
                this[this.tableIRA.PDV25Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }



            public void SetTUZEMSTVONull()
            {
                this[this.tableIRA.TUZEMSTVOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDTIPIRA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableIRA.IDTIPIRAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.IDTIPIRAColumn] = value;
                }
            }

            public int IRABROJ
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableIRA.IRABROJColumn]);
                }
                set
                {
                    this[this.tableIRA.IRABROJColumn] = value;
                }
            }

            public DateTime IRADATUM
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableIRA.IRADATUMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableIRA.IRADATUMColumn] = value;
                }
            }

            public int IRADOKIDDOKUMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableIRA.IRADOKIDDOKUMENTColumn]);
                }
                set
                {
                    this[this.tableIRA.IRADOKIDDOKUMENTColumn] = value;
                }
            }

            public short IRAGODIDGODINE
            {
                get
                {
                    return Conversions.ToShort(this[this.tableIRA.IRAGODIDGODINEColumn]);
                }
                set
                {
                    this[this.tableIRA.IRAGODIDGODINEColumn] = value;
                }
            }

            public string IRANAPOMENA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableIRA.IRANAPOMENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableIRA.IRANAPOMENAColumn] = value;
                }
            }

            public int IRAPARTNERIDPARTNER
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableIRA.IRAPARTNERIDPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.IRAPARTNERIDPARTNERColumn] = value;
                }
            }

            public decimal IRAUKUPNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.IRAUKUPNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.IRAUKUPNOColumn] = value;
                }
            }

            public DateTime IRAVALUTA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableIRA.IRAVALUTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableIRA.IRAVALUTAColumn] = value;
                }
            }

            public decimal IZVOZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.IZVOZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.IZVOZColumn] = value;
                }
            }

            public decimal MEDJTRANS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.MEDJTRANSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.MEDJTRANSColumn] = value;
                }
            }

            public decimal NEPODLEZE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.NEPODLEZEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.NEPODLEZEColumn] = value;
                }
            }

            public decimal NEPODLEZE_USLUGA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.NEPODLEZE_USLUGAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.NEPODLEZE_USLUGAColumn] = value;
                }
            }

            public decimal NULA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.NULAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.NULAColumn] = value;
                }
            }

            public decimal OSN05
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.OSN05Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.OSN05Column] = value;
                }
            }

            public decimal OSN10
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.OSN10Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.OSN10Column] = value;
                }
            }

            public decimal OSN22
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.OSN22Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.OSN22Column] = value;
                }
            }

            public decimal OSN23
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.OSN23Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.OSN23Column] = value;
                }
            }

            public decimal OSN25
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.OSN25Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.OSN25Column] = value;
                }
            }

            public decimal OSTALO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.OSTALOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.OSTALOColumn] = value;
                }
            }

            public decimal PDV05
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.PDV05Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.PDV10Column] = value;
                }
            }

            public decimal PDV10
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.PDV10Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.PDV10Column] = value;
                }
            }

            public decimal PDV22
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.PDV22Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.PDV22Column] = value;
                }
            }

            public decimal PDV23
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.PDV23Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.PDV23Column] = value;
                }
            }

            public decimal PDV25
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.PDV25Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.PDV25Column] = value;
                }
            }

            public decimal TUZEMSTVO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableIRA.TUZEMSTVOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableIRA.TUZEMSTVOColumn] = value;
                }
            }
        }

        public class IRARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private IRADataSet.IRARow eventRow;

            public IRARowChangeEvent(IRADataSet.IRARow row, DataRowAction action)
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

            public IRADataSet.IRARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void IRARowChangeEventHandler(object sender, IRADataSet.IRARowChangeEvent e);
    }
}

