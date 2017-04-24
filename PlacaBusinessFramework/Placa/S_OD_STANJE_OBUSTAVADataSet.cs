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
    public class S_OD_STANJE_OBUSTAVADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_STANJE_OBUSTAVADataTable tableS_OD_STANJE_OBUSTAVA;

        public S_OD_STANJE_OBUSTAVADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_STANJE_OBUSTAVADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_STANJE_OBUSTAVA"] != null)
                    {
                        this.Tables.Add(new S_OD_STANJE_OBUSTAVADataTable(dataSet.Tables["S_OD_STANJE_OBUSTAVA"]));
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
            S_OD_STANJE_OBUSTAVADataSet set = (S_OD_STANJE_OBUSTAVADataSet) base.Clone();
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
            S_OD_STANJE_OBUSTAVADataSet set = new S_OD_STANJE_OBUSTAVADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_STANJE_OBUSTAVADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2063");
            this.ExtendedProperties.Add("DataSetName", "S_OD_STANJE_OBUSTAVADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_STANJE_OBUSTAVADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_STANJE_OBUSTAVA");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_STANJE_OBUSTAVA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_STANJE_OBUSTAVA");
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
            this.DataSetName = "S_OD_STANJE_OBUSTAVADataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_STANJE_OBUSTAVA";
            this.tableS_OD_STANJE_OBUSTAVA = new S_OD_STANJE_OBUSTAVADataTable();
            this.Tables.Add(this.tableS_OD_STANJE_OBUSTAVA);
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
            this.tableS_OD_STANJE_OBUSTAVA = (S_OD_STANJE_OBUSTAVADataTable) this.Tables["S_OD_STANJE_OBUSTAVA"];
            if (initTable && (this.tableS_OD_STANJE_OBUSTAVA != null))
            {
                this.tableS_OD_STANJE_OBUSTAVA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_STANJE_OBUSTAVA"] != null)
                {
                    this.Tables.Add(new S_OD_STANJE_OBUSTAVADataTable(dataSet.Tables["S_OD_STANJE_OBUSTAVA"]));
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

        private bool ShouldSerializeS_OD_STANJE_OBUSTAVA()
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
        public S_OD_STANJE_OBUSTAVADataTable S_OD_STANJE_OBUSTAVA
        {
            get
            {
                return this.tableS_OD_STANJE_OBUSTAVA;
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
        public class S_OD_STANJE_OBUSTAVADataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJRATA;
            private DataColumn columnIDOBUSTAVA;
            private DataColumn columnIDRADNIK;
            private DataColumn columnOTPLACENO;

            public event S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARowChangeEventHandler S_OD_STANJE_OBUSTAVARowChanged;

            public event S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARowChangeEventHandler S_OD_STANJE_OBUSTAVARowChanging;

            public event S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARowChangeEventHandler S_OD_STANJE_OBUSTAVARowDeleted;

            public event S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARowChangeEventHandler S_OD_STANJE_OBUSTAVARowDeleting;

            public S_OD_STANJE_OBUSTAVADataTable()
            {
                this.TableName = "S_OD_STANJE_OBUSTAVA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_STANJE_OBUSTAVADataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_STANJE_OBUSTAVADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_STANJE_OBUSTAVARow(S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow AddS_OD_STANJE_OBUSTAVARow(int iDOBUSTAVA, int iDRADNIK, decimal oTPLACENO, decimal bROJRATA)
            {
                S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow row = (S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow) this.NewRow();
                row.ItemArray = new object[] { iDOBUSTAVA, iDRADNIK, oTPLACENO, bROJRATA };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVADataTable table = (S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_STANJE_OBUSTAVADataSet set = new S_OD_STANJE_OBUSTAVADataSet();
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
                this.columnIDOBUSTAVA = new DataColumn("IDOBUSTAVA", typeof(int), "", MappingType.Element);
                this.columnIDOBUSTAVA.Caption = "Šifra obustave";
                this.columnIDOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Description", "Šifra obustave");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Length", "8");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "IDOBUSTAVA");
                this.Columns.Add(this.columnIDOBUSTAVA);
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
                this.ExtendedProperties.Add("LevelName", "S_OD_STANJE_OBUSTAVA");
                this.ExtendedProperties.Add("Description", "S_OD_STANJE_OBUSTAVA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDOBUSTAVA = this.Columns["IDOBUSTAVA"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnOTPLACENO = this.Columns["OTPLACENO"];
                this.columnBROJRATA = this.Columns["BROJRATA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow(builder);
            }

            public S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow NewS_OD_STANJE_OBUSTAVARow()
            {
                return (S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_STANJE_OBUSTAVARowChanged != null)
                {
                    S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARowChangeEventHandler handler = this.S_OD_STANJE_OBUSTAVARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARowChangeEvent((S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_STANJE_OBUSTAVARowChanging != null)
                {
                    S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARowChangeEventHandler handler = this.S_OD_STANJE_OBUSTAVARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARowChangeEvent((S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_STANJE_OBUSTAVARowDeleted != null)
                {
                    S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARowChangeEventHandler handler = this.S_OD_STANJE_OBUSTAVARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARowChangeEvent((S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_STANJE_OBUSTAVARowDeleting != null)
                {
                    S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARowChangeEventHandler handler = this.S_OD_STANJE_OBUSTAVARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARowChangeEvent((S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_STANJE_OBUSTAVARow(S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow row)
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

            public DataColumn IDOBUSTAVAColumn
            {
                get
                {
                    return this.columnIDOBUSTAVA;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow this[int index]
            {
                get
                {
                    return (S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow) this.Rows[index];
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

        public class S_OD_STANJE_OBUSTAVARow : DataRow
        {
            private S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVADataTable tableS_OD_STANJE_OBUSTAVA;

            internal S_OD_STANJE_OBUSTAVARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_STANJE_OBUSTAVA = (S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVADataTable) this.Table;
            }

            public bool IsBROJRATANull()
            {
                return this.IsNull(this.tableS_OD_STANJE_OBUSTAVA.BROJRATAColumn);
            }

            public bool IsIDOBUSTAVANull()
            {
                return this.IsNull(this.tableS_OD_STANJE_OBUSTAVA.IDOBUSTAVAColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_OD_STANJE_OBUSTAVA.IDRADNIKColumn);
            }

            public bool IsOTPLACENONull()
            {
                return this.IsNull(this.tableS_OD_STANJE_OBUSTAVA.OTPLACENOColumn);
            }

            public void SetBROJRATANull()
            {
                this[this.tableS_OD_STANJE_OBUSTAVA.BROJRATAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDOBUSTAVANull()
            {
                this[this.tableS_OD_STANJE_OBUSTAVA.IDOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_OD_STANJE_OBUSTAVA.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOTPLACENONull()
            {
                this[this.tableS_OD_STANJE_OBUSTAVA.OTPLACENOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal BROJRATA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_STANJE_OBUSTAVA.BROJRATAColumn]);
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
                    this[this.tableS_OD_STANJE_OBUSTAVA.BROJRATAColumn] = value;
                }
            }

            public int IDOBUSTAVA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_STANJE_OBUSTAVA.IDOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDOBUSTAVA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_STANJE_OBUSTAVA.IDOBUSTAVAColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_STANJE_OBUSTAVA.IDRADNIKColumn]);
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
                    this[this.tableS_OD_STANJE_OBUSTAVA.IDRADNIKColumn] = value;
                }
            }

            public decimal OTPLACENO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_STANJE_OBUSTAVA.OTPLACENOColumn]);
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
                    this[this.tableS_OD_STANJE_OBUSTAVA.OTPLACENOColumn] = value;
                }
            }
        }

        public class S_OD_STANJE_OBUSTAVARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow eventRow;

            public S_OD_STANJE_OBUSTAVARowChangeEvent(S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow row, DataRowAction action)
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

            public S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_STANJE_OBUSTAVARowChangeEventHandler(object sender, S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARowChangeEvent e);
    }
}

