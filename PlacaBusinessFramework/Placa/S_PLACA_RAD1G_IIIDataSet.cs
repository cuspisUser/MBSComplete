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
    public class S_PLACA_RAD1G_IIIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_PLACA_RAD1G_IIIDataTable tableS_PLACA_RAD1G_III;

        public S_PLACA_RAD1G_IIIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_PLACA_RAD1G_IIIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_PLACA_RAD1G_III"] != null)
                    {
                        this.Tables.Add(new S_PLACA_RAD1G_IIIDataTable(dataSet.Tables["S_PLACA_RAD1G_III"]));
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
            S_PLACA_RAD1G_IIIDataSet set = (S_PLACA_RAD1G_IIIDataSet) base.Clone();
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
            S_PLACA_RAD1G_IIIDataSet set = new S_PLACA_RAD1G_IIIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_PLACA_RAD1G_IIIDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2185");
            this.ExtendedProperties.Add("DataSetName", "S_PLACA_RAD1G_IIIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_PLACA_RAD1G_IIIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_PLACA_RAD1G_III");
            this.ExtendedProperties.Add("ObjectDescription", "S_PLACA_RAD1G_III");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_RAD1G_III");
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
            this.DataSetName = "S_PLACA_RAD1G_IIIDataSet";
            this.Namespace = "http://www.tempuri.org/S_PLACA_RAD1G_III";
            this.tableS_PLACA_RAD1G_III = new S_PLACA_RAD1G_IIIDataTable();
            this.Tables.Add(this.tableS_PLACA_RAD1G_III);
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
            this.tableS_PLACA_RAD1G_III = (S_PLACA_RAD1G_IIIDataTable) this.Tables["S_PLACA_RAD1G_III"];
            if (initTable && (this.tableS_PLACA_RAD1G_III != null))
            {
                this.tableS_PLACA_RAD1G_III.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_PLACA_RAD1G_III"] != null)
                {
                    this.Tables.Add(new S_PLACA_RAD1G_IIIDataTable(dataSet.Tables["S_PLACA_RAD1G_III"]));
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

        private bool ShouldSerializeS_PLACA_RAD1G_III()
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
        public S_PLACA_RAD1G_IIIDataTable S_PLACA_RAD1G_III
        {
            get
            {
                return this.tableS_PLACA_RAD1G_III;
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
        public class S_PLACA_RAD1G_IIIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRADNIK;
            private DataColumn columnnetoplaca;
            private DataColumn columnsatibruto;

            public event S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRowChangeEventHandler S_PLACA_RAD1G_IIIRowChanged;

            public event S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRowChangeEventHandler S_PLACA_RAD1G_IIIRowChanging;

            public event S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRowChangeEventHandler S_PLACA_RAD1G_IIIRowDeleted;

            public event S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRowChangeEventHandler S_PLACA_RAD1G_IIIRowDeleting;

            public S_PLACA_RAD1G_IIIDataTable()
            {
                this.TableName = "S_PLACA_RAD1G_III";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_PLACA_RAD1G_IIIDataTable(DataTable table) : base(table.TableName)
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

            protected S_PLACA_RAD1G_IIIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_PLACA_RAD1G_IIIRow(S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow row)
            {
                this.Rows.Add(row);
            }

            public S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow AddS_PLACA_RAD1G_IIIRow(int iDRADNIK, decimal netoplaca, decimal satibruto)
            {
                S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow row = (S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow) this.NewRow();
                row.ItemArray = new object[] { iDRADNIK, netoplaca, satibruto };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIDataTable table = (S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_PLACA_RAD1G_IIIDataSet set = new S_PLACA_RAD1G_IIIDataSet();
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
                this.columnsatibruto = new DataColumn("satibruto", typeof(decimal), "", MappingType.Element);
                this.columnsatibruto.Caption = "satibruto";
                this.columnsatibruto.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsatibruto.ExtendedProperties.Add("IsKey", "false");
                this.columnsatibruto.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsatibruto.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsatibruto.ExtendedProperties.Add("Description", "satibruto");
                this.columnsatibruto.ExtendedProperties.Add("Length", "12");
                this.columnsatibruto.ExtendedProperties.Add("Decimals", "2");
                this.columnsatibruto.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsatibruto.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsatibruto.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsatibruto.ExtendedProperties.Add("IsInReader", "true");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsatibruto.ExtendedProperties.Add("Deklarit.InternalName", "satibruto");
                this.Columns.Add(this.columnsatibruto);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_PLACA_RAD1G_III");
                this.ExtendedProperties.Add("Description", "_S_PLACA_RAD1G_III");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnnetoplaca = this.Columns["netoplaca"];
                this.columnsatibruto = this.Columns["satibruto"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow(builder);
            }

            public S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow NewS_PLACA_RAD1G_IIIRow()
            {
                return (S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_PLACA_RAD1G_IIIRowChanged != null)
                {
                    S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRowChangeEventHandler handler = this.S_PLACA_RAD1G_IIIRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRowChangeEvent((S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_PLACA_RAD1G_IIIRowChanging != null)
                {
                    S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRowChangeEventHandler handler = this.S_PLACA_RAD1G_IIIRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRowChangeEvent((S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_PLACA_RAD1G_IIIRowDeleted != null)
                {
                    S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRowChangeEventHandler handler = this.S_PLACA_RAD1G_IIIRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRowChangeEvent((S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_PLACA_RAD1G_IIIRowDeleting != null)
                {
                    S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRowChangeEventHandler handler = this.S_PLACA_RAD1G_IIIRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRowChangeEvent((S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_PLACA_RAD1G_IIIRow(S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow row)
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

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow this[int index]
            {
                get
                {
                    return (S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow) this.Rows[index];
                }
            }

            public DataColumn netoplacaColumn
            {
                get
                {
                    return this.columnnetoplaca;
                }
            }

            public DataColumn satibrutoColumn
            {
                get
                {
                    return this.columnsatibruto;
                }
            }
        }

        public class S_PLACA_RAD1G_IIIRow : DataRow
        {
            private S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIDataTable tableS_PLACA_RAD1G_III;

            internal S_PLACA_RAD1G_IIIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_PLACA_RAD1G_III = (S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIDataTable) this.Table;
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G_III.IDRADNIKColumn);
            }

            public bool IsnetoplacaNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G_III.netoplacaColumn);
            }

            public bool IssatibrutoNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G_III.satibrutoColumn);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_PLACA_RAD1G_III.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoplacaNull()
            {
                this[this.tableS_PLACA_RAD1G_III.netoplacaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetsatibrutoNull()
            {
                this[this.tableS_PLACA_RAD1G_III.satibrutoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_PLACA_RAD1G_III.IDRADNIKColumn]);
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
                    this[this.tableS_PLACA_RAD1G_III.IDRADNIKColumn] = value;
                }
            }

            public decimal netoplaca
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1G_III.netoplacaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value netoplaca because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G_III.netoplacaColumn] = value;
                }
            }

            public decimal satibruto
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1G_III.satibrutoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value satibruto because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G_III.satibrutoColumn] = value;
                }
            }
        }

        public class S_PLACA_RAD1G_IIIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow eventRow;

            public S_PLACA_RAD1G_IIIRowChangeEvent(S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow row, DataRowAction action)
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

            public S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_PLACA_RAD1G_IIIRowChangeEventHandler(object sender, S_PLACA_RAD1G_IIIDataSet.S_PLACA_RAD1G_IIIRowChangeEvent e);
    }
}

