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
    public class S_OD_STANJE_KREDITADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_STANJE_KREDITADataTable tableS_OD_STANJE_KREDITA;

        public S_OD_STANJE_KREDITADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_STANJE_KREDITADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_STANJE_KREDITA"] != null)
                    {
                        this.Tables.Add(new S_OD_STANJE_KREDITADataTable(dataSet.Tables["S_OD_STANJE_KREDITA"]));
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
            S_OD_STANJE_KREDITADataSet set = (S_OD_STANJE_KREDITADataSet) base.Clone();
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
            S_OD_STANJE_KREDITADataSet set = new S_OD_STANJE_KREDITADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_STANJE_KREDITADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2062");
            this.ExtendedProperties.Add("DataSetName", "S_OD_STANJE_KREDITADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_STANJE_KREDITADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_STANJE_KREDITA");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_STANJE_KREDITA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_STANJE_KREDITA");
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
            this.DataSetName = "S_OD_STANJE_KREDITADataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_STANJE_KREDITA";
            this.tableS_OD_STANJE_KREDITA = new S_OD_STANJE_KREDITADataTable();
            this.Tables.Add(this.tableS_OD_STANJE_KREDITA);
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
            this.tableS_OD_STANJE_KREDITA = (S_OD_STANJE_KREDITADataTable) this.Tables["S_OD_STANJE_KREDITA"];
            if (initTable && (this.tableS_OD_STANJE_KREDITA != null))
            {
                this.tableS_OD_STANJE_KREDITA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_STANJE_KREDITA"] != null)
                {
                    this.Tables.Add(new S_OD_STANJE_KREDITADataTable(dataSet.Tables["S_OD_STANJE_KREDITA"]));
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

        private bool ShouldSerializeS_OD_STANJE_KREDITA()
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
        public S_OD_STANJE_KREDITADataTable S_OD_STANJE_KREDITA
        {
            get
            {
                return this.tableS_OD_STANJE_KREDITA;
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
        public class S_OD_STANJE_KREDITADataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJRATA;
            private DataColumn columnDATUMUGOVORA;
            private DataColumn columnIDKREDITOR;
            private DataColumn columnIDRADNIK;
            private DataColumn columnOTPLACENO;

            public event S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARowChangeEventHandler S_OD_STANJE_KREDITARowChanged;

            public event S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARowChangeEventHandler S_OD_STANJE_KREDITARowChanging;

            public event S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARowChangeEventHandler S_OD_STANJE_KREDITARowDeleted;

            public event S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARowChangeEventHandler S_OD_STANJE_KREDITARowDeleting;

            public S_OD_STANJE_KREDITADataTable()
            {
                this.TableName = "S_OD_STANJE_KREDITA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_STANJE_KREDITADataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_STANJE_KREDITADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_STANJE_KREDITARow(S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow AddS_OD_STANJE_KREDITARow(DateTime dATUMUGOVORA, int iDKREDITOR, int iDRADNIK, decimal oTPLACENO, decimal bROJRATA)
            {
                S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow row = (S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow) this.NewRow();
                row.ItemArray = new object[] { dATUMUGOVORA, iDKREDITOR, iDRADNIK, oTPLACENO, bROJRATA };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITADataTable table = (S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_STANJE_KREDITADataSet set = new S_OD_STANJE_KREDITADataSet();
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
                this.columnOTPLACENO = new DataColumn("OTPLACENO", typeof(decimal), "", MappingType.Element);
                this.columnOTPLACENO.Caption = "OTPLACENO";
                this.columnOTPLACENO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOTPLACENO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOTPLACENO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOTPLACENO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOTPLACENO.ExtendedProperties.Add("IsKey", "false");
                this.columnOTPLACENO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOTPLACENO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOTPLACENO.ExtendedProperties.Add("Description", "OTPLACENO");
                this.columnOTPLACENO.ExtendedProperties.Add("Length", "12");
                this.columnOTPLACENO.ExtendedProperties.Add("Decimals", "2");
                this.columnOTPLACENO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOTPLACENO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOTPLACENO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOTPLACENO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOTPLACENO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOTPLACENO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOTPLACENO.ExtendedProperties.Add("Deklarit.InternalName", "OTPLACENO");
                this.Columns.Add(this.columnOTPLACENO);
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
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_STANJE_KREDITA");
                this.ExtendedProperties.Add("Description", "_S_OD_STANJE_KREDITA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnDATUMUGOVORA = this.Columns["DATUMUGOVORA"];
                this.columnIDKREDITOR = this.Columns["IDKREDITOR"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnOTPLACENO = this.Columns["OTPLACENO"];
                this.columnBROJRATA = this.Columns["BROJRATA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow(builder);
            }

            public S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow NewS_OD_STANJE_KREDITARow()
            {
                return (S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_STANJE_KREDITARowChanged != null)
                {
                    S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARowChangeEventHandler handler = this.S_OD_STANJE_KREDITARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARowChangeEvent((S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_STANJE_KREDITARowChanging != null)
                {
                    S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARowChangeEventHandler handler = this.S_OD_STANJE_KREDITARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARowChangeEvent((S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_STANJE_KREDITARowDeleted != null)
                {
                    S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARowChangeEventHandler handler = this.S_OD_STANJE_KREDITARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARowChangeEvent((S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_STANJE_KREDITARowDeleting != null)
                {
                    S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARowChangeEventHandler handler = this.S_OD_STANJE_KREDITARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARowChangeEvent((S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_STANJE_KREDITARow(S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow row)
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

            public S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow this[int index]
            {
                get
                {
                    return (S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow) this.Rows[index];
                }
            }

            public DataColumn OTPLACENOColumn
            {
                get
                {
                    return this.columnOTPLACENO;
                }
            }
        }

        public class S_OD_STANJE_KREDITARow : DataRow
        {
            private S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITADataTable tableS_OD_STANJE_KREDITA;

            internal S_OD_STANJE_KREDITARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_STANJE_KREDITA = (S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITADataTable) this.Table;
            }

            public bool IsBROJRATANull()
            {
                return this.IsNull(this.tableS_OD_STANJE_KREDITA.BROJRATAColumn);
            }

            public bool IsDATUMUGOVORANull()
            {
                return this.IsNull(this.tableS_OD_STANJE_KREDITA.DATUMUGOVORAColumn);
            }

            public bool IsIDKREDITORNull()
            {
                return this.IsNull(this.tableS_OD_STANJE_KREDITA.IDKREDITORColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_OD_STANJE_KREDITA.IDRADNIKColumn);
            }

            public bool IsOTPLACENONull()
            {
                return this.IsNull(this.tableS_OD_STANJE_KREDITA.OTPLACENOColumn);
            }

            public void SetBROJRATANull()
            {
                this[this.tableS_OD_STANJE_KREDITA.BROJRATAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMUGOVORANull()
            {
                this[this.tableS_OD_STANJE_KREDITA.DATUMUGOVORAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDKREDITORNull()
            {
                this[this.tableS_OD_STANJE_KREDITA.IDKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_OD_STANJE_KREDITA.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOTPLACENONull()
            {
                this[this.tableS_OD_STANJE_KREDITA.OTPLACENOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal BROJRATA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_STANJE_KREDITA.BROJRATAColumn]);
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
                    this[this.tableS_OD_STANJE_KREDITA.BROJRATAColumn] = value;
                }
            }

            public DateTime DATUMUGOVORA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_OD_STANJE_KREDITA.DATUMUGOVORAColumn]);
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
                    this[this.tableS_OD_STANJE_KREDITA.DATUMUGOVORAColumn] = value;
                }
            }

            public int IDKREDITOR
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_STANJE_KREDITA.IDKREDITORColumn]);
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
                    this[this.tableS_OD_STANJE_KREDITA.IDKREDITORColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_STANJE_KREDITA.IDRADNIKColumn]);
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
                    this[this.tableS_OD_STANJE_KREDITA.IDRADNIKColumn] = value;
                }
            }

            public decimal OTPLACENO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_STANJE_KREDITA.OTPLACENOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OTPLACENO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_STANJE_KREDITA.OTPLACENOColumn] = value;
                }
            }
        }

        public class S_OD_STANJE_KREDITARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow eventRow;

            public S_OD_STANJE_KREDITARowChangeEvent(S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow row, DataRowAction action)
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

            public S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_STANJE_KREDITARowChangeEventHandler(object sender, S_OD_STANJE_KREDITADataSet.S_OD_STANJE_KREDITARowChangeEvent e);
    }
}

