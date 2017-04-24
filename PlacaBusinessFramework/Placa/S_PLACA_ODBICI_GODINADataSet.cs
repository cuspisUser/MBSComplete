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
    public class S_PLACA_ODBICI_GODINADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_PLACA_ODBICI_GODINADataTable tableS_PLACA_ODBICI_GODINA;

        public S_PLACA_ODBICI_GODINADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_PLACA_ODBICI_GODINADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_PLACA_ODBICI_GODINA"] != null)
                    {
                        this.Tables.Add(new S_PLACA_ODBICI_GODINADataTable(dataSet.Tables["S_PLACA_ODBICI_GODINA"]));
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
            S_PLACA_ODBICI_GODINADataSet set = (S_PLACA_ODBICI_GODINADataSet) base.Clone();
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
            S_PLACA_ODBICI_GODINADataSet set = new S_PLACA_ODBICI_GODINADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_PLACA_ODBICI_GODINADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2148");
            this.ExtendedProperties.Add("DataSetName", "S_PLACA_ODBICI_GODINADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_PLACA_ODBICI_GODINADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_PLACA_ODBICI_GODINA");
            this.ExtendedProperties.Add("ObjectDescription", "S_PLACA_ODBICI_GODINA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_ODBICI_GODINA");
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
            this.DataSetName = "S_PLACA_ODBICI_GODINADataSet";
            this.Namespace = "http://www.tempuri.org/S_PLACA_ODBICI_GODINA";
            this.tableS_PLACA_ODBICI_GODINA = new S_PLACA_ODBICI_GODINADataTable();
            this.Tables.Add(this.tableS_PLACA_ODBICI_GODINA);
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
            this.tableS_PLACA_ODBICI_GODINA = (S_PLACA_ODBICI_GODINADataTable) this.Tables["S_PLACA_ODBICI_GODINA"];
            if (initTable && (this.tableS_PLACA_ODBICI_GODINA != null))
            {
                this.tableS_PLACA_ODBICI_GODINA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_PLACA_ODBICI_GODINA"] != null)
                {
                    this.Tables.Add(new S_PLACA_ODBICI_GODINADataTable(dataSet.Tables["S_PLACA_ODBICI_GODINA"]));
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

        private bool ShouldSerializeS_PLACA_ODBICI_GODINA()
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
        public S_PLACA_ODBICI_GODINADataTable S_PLACA_ODBICI_GODINA
        {
            get
            {
                return this.tableS_PLACA_ODBICI_GODINA;
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
        public class S_PLACA_ODBICI_GODINADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRADNIK;
            private DataColumn columnODBITAK;
            private DataColumn columnOLAKSICE;

            public event S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARowChangeEventHandler S_PLACA_ODBICI_GODINARowChanged;

            public event S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARowChangeEventHandler S_PLACA_ODBICI_GODINARowChanging;

            public event S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARowChangeEventHandler S_PLACA_ODBICI_GODINARowDeleted;

            public event S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARowChangeEventHandler S_PLACA_ODBICI_GODINARowDeleting;

            public S_PLACA_ODBICI_GODINADataTable()
            {
                this.TableName = "S_PLACA_ODBICI_GODINA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_PLACA_ODBICI_GODINADataTable(DataTable table) : base(table.TableName)
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

            protected S_PLACA_ODBICI_GODINADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_PLACA_ODBICI_GODINARow(S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow row)
            {
                this.Rows.Add(row);
            }

            public S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow AddS_PLACA_ODBICI_GODINARow(decimal oLAKSICE, decimal oDBITAK, int iDRADNIK)
            {
                S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow row = (S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow) this.NewRow();
                row.ItemArray = new object[] { oLAKSICE, oDBITAK, iDRADNIK };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINADataTable table = (S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_PLACA_ODBICI_GODINADataSet set = new S_PLACA_ODBICI_GODINADataSet();
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
                this.columnOLAKSICE = new DataColumn("OLAKSICE", typeof(decimal), "", MappingType.Element);
                this.columnOLAKSICE.Caption = "OLAKSICE";
                this.columnOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOLAKSICE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOLAKSICE.ExtendedProperties.Add("Description", "OLAKSICE");
                this.columnOLAKSICE.ExtendedProperties.Add("Length", "12");
                this.columnOLAKSICE.ExtendedProperties.Add("Decimals", "2");
                this.columnOLAKSICE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOLAKSICE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOLAKSICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "OLAKSICE");
                this.Columns.Add(this.columnOLAKSICE);
                this.columnODBITAK = new DataColumn("ODBITAK", typeof(decimal), "", MappingType.Element);
                this.columnODBITAK.Caption = "ODBITAK";
                this.columnODBITAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnODBITAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnODBITAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnODBITAK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnODBITAK.ExtendedProperties.Add("IsKey", "false");
                this.columnODBITAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnODBITAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnODBITAK.ExtendedProperties.Add("Description", "ODBITAK");
                this.columnODBITAK.ExtendedProperties.Add("Length", "12");
                this.columnODBITAK.ExtendedProperties.Add("Decimals", "2");
                this.columnODBITAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnODBITAK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnODBITAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnODBITAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnODBITAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnODBITAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnODBITAK.ExtendedProperties.Add("Deklarit.InternalName", "ODBITAK");
                this.Columns.Add(this.columnODBITAK);
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
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_PLACA_ODBICI_GODINA");
                this.ExtendedProperties.Add("Description", "_S_PLACA_ODBICI_GODINA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnOLAKSICE = this.Columns["OLAKSICE"];
                this.columnODBITAK = this.Columns["ODBITAK"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow(builder);
            }

            public S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow NewS_PLACA_ODBICI_GODINARow()
            {
                return (S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_PLACA_ODBICI_GODINARowChanged != null)
                {
                    S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARowChangeEventHandler handler = this.S_PLACA_ODBICI_GODINARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARowChangeEvent((S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_PLACA_ODBICI_GODINARowChanging != null)
                {
                    S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARowChangeEventHandler handler = this.S_PLACA_ODBICI_GODINARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARowChangeEvent((S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_PLACA_ODBICI_GODINARowDeleted != null)
                {
                    S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARowChangeEventHandler handler = this.S_PLACA_ODBICI_GODINARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARowChangeEvent((S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_PLACA_ODBICI_GODINARowDeleting != null)
                {
                    S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARowChangeEventHandler handler = this.S_PLACA_ODBICI_GODINARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARowChangeEvent((S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_PLACA_ODBICI_GODINARow(S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow row)
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

            public S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow this[int index]
            {
                get
                {
                    return (S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow) this.Rows[index];
                }
            }

            public DataColumn ODBITAKColumn
            {
                get
                {
                    return this.columnODBITAK;
                }
            }

            public DataColumn OLAKSICEColumn
            {
                get
                {
                    return this.columnOLAKSICE;
                }
            }
        }

        public class S_PLACA_ODBICI_GODINARow : DataRow
        {
            private S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINADataTable tableS_PLACA_ODBICI_GODINA;

            internal S_PLACA_ODBICI_GODINARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_PLACA_ODBICI_GODINA = (S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINADataTable) this.Table;
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_PLACA_ODBICI_GODINA.IDRADNIKColumn);
            }

            public bool IsODBITAKNull()
            {
                return this.IsNull(this.tableS_PLACA_ODBICI_GODINA.ODBITAKColumn);
            }

            public bool IsOLAKSICENull()
            {
                return this.IsNull(this.tableS_PLACA_ODBICI_GODINA.OLAKSICEColumn);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_PLACA_ODBICI_GODINA.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODBITAKNull()
            {
                this[this.tableS_PLACA_ODBICI_GODINA.ODBITAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOLAKSICENull()
            {
                this[this.tableS_PLACA_ODBICI_GODINA.OLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_PLACA_ODBICI_GODINA.IDRADNIKColumn]);
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
                    this[this.tableS_PLACA_ODBICI_GODINA.IDRADNIKColumn] = value;
                }
            }

            public decimal ODBITAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_ODBICI_GODINA.ODBITAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ODBITAK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_ODBICI_GODINA.ODBITAKColumn] = value;
                }
            }

            public decimal OLAKSICE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_ODBICI_GODINA.OLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OLAKSICE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_ODBICI_GODINA.OLAKSICEColumn] = value;
                }
            }
        }

        public class S_PLACA_ODBICI_GODINARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow eventRow;

            public S_PLACA_ODBICI_GODINARowChangeEvent(S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow row, DataRowAction action)
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

            public S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_PLACA_ODBICI_GODINARowChangeEventHandler(object sender, S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARowChangeEvent e);
    }
}

