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
    public class S_OD_STAT_KREDITDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_STAT_KREDITDataTable tableS_OD_STAT_KREDIT;

        public S_OD_STAT_KREDITDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_STAT_KREDITDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_STAT_KREDIT"] != null)
                    {
                        this.Tables.Add(new S_OD_STAT_KREDITDataTable(dataSet.Tables["S_OD_STAT_KREDIT"]));
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
            S_OD_STAT_KREDITDataSet set = (S_OD_STAT_KREDITDataSet) base.Clone();
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
            S_OD_STAT_KREDITDataSet set = new S_OD_STAT_KREDITDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_STAT_KREDITDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2043");
            this.ExtendedProperties.Add("DataSetName", "S_OD_STAT_KREDITDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_STAT_KREDITDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_STAT_KREDIT");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_STAT_KREDIT");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_STAT_KREDIT");
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
            this.DataSetName = "S_OD_STAT_KREDITDataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_STAT_KREDIT";
            this.tableS_OD_STAT_KREDIT = new S_OD_STAT_KREDITDataTable();
            this.Tables.Add(this.tableS_OD_STAT_KREDIT);
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
            this.tableS_OD_STAT_KREDIT = (S_OD_STAT_KREDITDataTable) this.Tables["S_OD_STAT_KREDIT"];
            if (initTable && (this.tableS_OD_STAT_KREDIT != null))
            {
                this.tableS_OD_STAT_KREDIT.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_STAT_KREDIT"] != null)
                {
                    this.Tables.Add(new S_OD_STAT_KREDITDataTable(dataSet.Tables["S_OD_STAT_KREDIT"]));
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

        private bool ShouldSerializeS_OD_STAT_KREDIT()
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
        public S_OD_STAT_KREDITDataTable S_OD_STAT_KREDIT
        {
            get
            {
                return this.tableS_OD_STAT_KREDIT;
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
        public class S_OD_STAT_KREDITDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJRATA;
            private DataColumn columnDATUMUGOVORA;
            private DataColumn columnIDKREDITOR;
            private DataColumn columnIDRADNIK;
            private DataColumn columnOBRACUNATO;

            public event S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRowChangeEventHandler S_OD_STAT_KREDITRowChanged;

            public event S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRowChangeEventHandler S_OD_STAT_KREDITRowChanging;

            public event S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRowChangeEventHandler S_OD_STAT_KREDITRowDeleted;

            public event S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRowChangeEventHandler S_OD_STAT_KREDITRowDeleting;

            public S_OD_STAT_KREDITDataTable()
            {
                this.TableName = "S_OD_STAT_KREDIT";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_STAT_KREDITDataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_STAT_KREDITDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_STAT_KREDITRow(S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow AddS_OD_STAT_KREDITRow(int iDKREDITOR, DateTime dATUMUGOVORA, int iDRADNIK, decimal bROJRATA, decimal oBRACUNATO)
            {
                S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow row = (S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow) this.NewRow();
                row.ItemArray = new object[] { iDKREDITOR, dATUMUGOVORA, iDRADNIK, bROJRATA, oBRACUNATO };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITDataTable table = (S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_STAT_KREDITDataSet set = new S_OD_STAT_KREDITDataSet();
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
                this.columnIDKREDITOR = new DataColumn("IDKREDITOR", typeof(int), "", MappingType.Element);
                this.columnIDKREDITOR.Caption = "IDKREDITOR";
                this.columnIDKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "99999999");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKREDITOR.ExtendedProperties.Add("Description", "IDKREDITOR");
                this.columnIDKREDITOR.ExtendedProperties.Add("Length", "8");
                this.columnIDKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "IDKREDITOR");
                this.Columns.Add(this.columnIDKREDITOR);
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
                this.columnDATUMUGOVORA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMUGOVORA");
                this.Columns.Add(this.columnDATUMUGOVORA);
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
                this.columnBROJRATA = new DataColumn("BROJRATA", typeof(decimal), "", MappingType.Element);
                this.columnBROJRATA.Caption = "BROJRATA";
                this.columnBROJRATA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRATA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRATA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRATA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJRATA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRATA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJRATA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJRATA.ExtendedProperties.Add("Description", "BROJRATA");
                this.columnBROJRATA.ExtendedProperties.Add("Length", "5");
                this.columnBROJRATA.ExtendedProperties.Add("Decimals", "2");
                this.columnBROJRATA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBROJRATA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnBROJRATA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRATA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJRATA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRATA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRATA.ExtendedProperties.Add("Deklarit.InternalName", "BROJRATA");
                this.Columns.Add(this.columnBROJRATA);
                this.columnOBRACUNATO = new DataColumn("OBRACUNATO", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNATO.Caption = "Obračunato";
                this.columnOBRACUNATO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOBRACUNATO.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNATO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBRACUNATO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNATO.ExtendedProperties.Add("Description", "Obračunato");
                this.columnOBRACUNATO.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNATO.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNATO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNATO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNATO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRACUNATO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNATO.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNATO");
                this.Columns.Add(this.columnOBRACUNATO);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_STAT_KREDIT");
                this.ExtendedProperties.Add("Description", "_S_OD_STAT_KREDIT");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDKREDITOR = this.Columns["IDKREDITOR"];
                this.columnDATUMUGOVORA = this.Columns["DATUMUGOVORA"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnBROJRATA = this.Columns["BROJRATA"];
                this.columnOBRACUNATO = this.Columns["OBRACUNATO"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow(builder);
            }

            public S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow NewS_OD_STAT_KREDITRow()
            {
                return (S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_STAT_KREDITRowChanged != null)
                {
                    S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRowChangeEventHandler handler = this.S_OD_STAT_KREDITRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRowChangeEvent((S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_STAT_KREDITRowChanging != null)
                {
                    S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRowChangeEventHandler handler = this.S_OD_STAT_KREDITRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRowChangeEvent((S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_STAT_KREDITRowDeleted != null)
                {
                    S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRowChangeEventHandler handler = this.S_OD_STAT_KREDITRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRowChangeEvent((S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_STAT_KREDITRowDeleting != null)
                {
                    S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRowChangeEventHandler handler = this.S_OD_STAT_KREDITRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRowChangeEvent((S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_STAT_KREDITRow(S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJRATAColumn
            {
                get
                {
                    return this.columnBROJRATA;
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

            public DataColumn IDKREDITORColumn
            {
                get
                {
                    return this.columnIDKREDITOR;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow this[int index]
            {
                get
                {
                    return (S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow) this.Rows[index];
                }
            }

            public DataColumn OBRACUNATOColumn
            {
                get
                {
                    return this.columnOBRACUNATO;
                }
            }
        }

        public class S_OD_STAT_KREDITRow : DataRow
        {
            private S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITDataTable tableS_OD_STAT_KREDIT;

            internal S_OD_STAT_KREDITRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_STAT_KREDIT = (S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITDataTable) this.Table;
            }

            public bool IsBROJRATANull()
            {
                return this.IsNull(this.tableS_OD_STAT_KREDIT.BROJRATAColumn);
            }

            public bool IsDATUMUGOVORANull()
            {
                return this.IsNull(this.tableS_OD_STAT_KREDIT.DATUMUGOVORAColumn);
            }

            public bool IsIDKREDITORNull()
            {
                return this.IsNull(this.tableS_OD_STAT_KREDIT.IDKREDITORColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_OD_STAT_KREDIT.IDRADNIKColumn);
            }

            public bool IsOBRACUNATONull()
            {
                return this.IsNull(this.tableS_OD_STAT_KREDIT.OBRACUNATOColumn);
            }

            public void SetBROJRATANull()
            {
                this[this.tableS_OD_STAT_KREDIT.BROJRATAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMUGOVORANull()
            {
                this[this.tableS_OD_STAT_KREDIT.DATUMUGOVORAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDKREDITORNull()
            {
                this[this.tableS_OD_STAT_KREDIT.IDKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_OD_STAT_KREDIT.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATONull()
            {
                this[this.tableS_OD_STAT_KREDIT.OBRACUNATOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal BROJRATA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_STAT_KREDIT.BROJRATAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJRATA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_STAT_KREDIT.BROJRATAColumn] = value;
                }
            }

            public DateTime DATUMUGOVORA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_OD_STAT_KREDIT.DATUMUGOVORAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DATUMUGOVORA because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_OD_STAT_KREDIT.DATUMUGOVORAColumn] = value;
                }
            }

            public int IDKREDITOR
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_STAT_KREDIT.IDKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDKREDITOR because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_STAT_KREDIT.IDKREDITORColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_STAT_KREDIT.IDRADNIKColumn]);
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
                    this[this.tableS_OD_STAT_KREDIT.IDRADNIKColumn] = value;
                }
            }

            public decimal OBRACUNATO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_STAT_KREDIT.OBRACUNATOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_STAT_KREDIT.OBRACUNATOColumn] = value;
                }
            }
        }

        public class S_OD_STAT_KREDITRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow eventRow;

            public S_OD_STAT_KREDITRowChangeEvent(S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow row, DataRowAction action)
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

            public S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_STAT_KREDITRowChangeEventHandler(object sender, S_OD_STAT_KREDITDataSet.S_OD_STAT_KREDITRowChangeEvent e);
    }
}

