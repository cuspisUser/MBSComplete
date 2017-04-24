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
    public class S_OD_KRIZNI_POREZDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_KRIZNI_POREZDataTable tableS_OD_KRIZNI_POREZ;

        public S_OD_KRIZNI_POREZDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_KRIZNI_POREZDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_KRIZNI_POREZ"] != null)
                    {
                        this.Tables.Add(new S_OD_KRIZNI_POREZDataTable(dataSet.Tables["S_OD_KRIZNI_POREZ"]));
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
            S_OD_KRIZNI_POREZDataSet set = (S_OD_KRIZNI_POREZDataSet) base.Clone();
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
            S_OD_KRIZNI_POREZDataSet set = new S_OD_KRIZNI_POREZDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_KRIZNI_POREZDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2078");
            this.ExtendedProperties.Add("DataSetName", "S_OD_KRIZNI_POREZDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_KRIZNI_POREZDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_KRIZNI_POREZ");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_KRIZNI_POREZ");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_KRIZNI_POREZ");
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
            this.DataSetName = "S_OD_KRIZNI_POREZDataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_KRIZNI_POREZ";
            this.tableS_OD_KRIZNI_POREZ = new S_OD_KRIZNI_POREZDataTable();
            this.Tables.Add(this.tableS_OD_KRIZNI_POREZ);
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
            this.tableS_OD_KRIZNI_POREZ = (S_OD_KRIZNI_POREZDataTable) this.Tables["S_OD_KRIZNI_POREZ"];
            if (initTable && (this.tableS_OD_KRIZNI_POREZ != null))
            {
                this.tableS_OD_KRIZNI_POREZ.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_KRIZNI_POREZ"] != null)
                {
                    this.Tables.Add(new S_OD_KRIZNI_POREZDataTable(dataSet.Tables["S_OD_KRIZNI_POREZ"]));
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

        private bool ShouldSerializeS_OD_KRIZNI_POREZ()
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
        public S_OD_KRIZNI_POREZDataTable S_OD_KRIZNI_POREZ
        {
            get
            {
                return this.tableS_OD_KRIZNI_POREZ;
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
        public class S_OD_KRIZNI_POREZDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRADNIK;
            private DataColumn columnnetoplaca;
            private DataColumn columnPOREZKRIZNI;

            public event S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRowChangeEventHandler S_OD_KRIZNI_POREZRowChanged;

            public event S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRowChangeEventHandler S_OD_KRIZNI_POREZRowChanging;

            public event S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRowChangeEventHandler S_OD_KRIZNI_POREZRowDeleted;

            public event S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRowChangeEventHandler S_OD_KRIZNI_POREZRowDeleting;

            public S_OD_KRIZNI_POREZDataTable()
            {
                this.TableName = "S_OD_KRIZNI_POREZ";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_KRIZNI_POREZDataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_KRIZNI_POREZDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_KRIZNI_POREZRow(S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow AddS_OD_KRIZNI_POREZRow(int iDRADNIK, decimal pOREZKRIZNI, decimal netoplaca)
            {
                S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow row = (S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow) this.NewRow();
                row.ItemArray = new object[] { iDRADNIK, pOREZKRIZNI, netoplaca };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZDataTable table = (S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_KRIZNI_POREZDataSet set = new S_OD_KRIZNI_POREZDataSet();
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
                this.columnPOREZKRIZNI = new DataColumn("POREZKRIZNI", typeof(decimal), "", MappingType.Element);
                this.columnPOREZKRIZNI.Caption = "POREZKRIZNI";
                this.columnPOREZKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Description", "POREZKRIZNI");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Length", "12");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "POREZKRIZNI");
                this.Columns.Add(this.columnPOREZKRIZNI);
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
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_KRIZNI_POREZ");
                this.ExtendedProperties.Add("Description", "_S_OD_KRIZNI_POREZ");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnPOREZKRIZNI = this.Columns["POREZKRIZNI"];
                this.columnnetoplaca = this.Columns["netoplaca"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow(builder);
            }

            public S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow NewS_OD_KRIZNI_POREZRow()
            {
                return (S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_KRIZNI_POREZRowChanged != null)
                {
                    S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRowChangeEventHandler handler = this.S_OD_KRIZNI_POREZRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRowChangeEvent((S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_KRIZNI_POREZRowChanging != null)
                {
                    S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRowChangeEventHandler handler = this.S_OD_KRIZNI_POREZRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRowChangeEvent((S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_KRIZNI_POREZRowDeleted != null)
                {
                    S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRowChangeEventHandler handler = this.S_OD_KRIZNI_POREZRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRowChangeEvent((S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_KRIZNI_POREZRowDeleting != null)
                {
                    S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRowChangeEventHandler handler = this.S_OD_KRIZNI_POREZRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRowChangeEvent((S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_KRIZNI_POREZRow(S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow row)
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

            public S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow this[int index]
            {
                get
                {
                    return (S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow) this.Rows[index];
                }
            }

            public DataColumn netoplacaColumn
            {
                get
                {
                    return this.columnnetoplaca;
                }
            }

            public DataColumn POREZKRIZNIColumn
            {
                get
                {
                    return this.columnPOREZKRIZNI;
                }
            }
        }

        public class S_OD_KRIZNI_POREZRow : DataRow
        {
            private S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZDataTable tableS_OD_KRIZNI_POREZ;

            internal S_OD_KRIZNI_POREZRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_KRIZNI_POREZ = (S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZDataTable) this.Table;
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_OD_KRIZNI_POREZ.IDRADNIKColumn);
            }

            public bool IsnetoplacaNull()
            {
                return this.IsNull(this.tableS_OD_KRIZNI_POREZ.netoplacaColumn);
            }

            public bool IsPOREZKRIZNINull()
            {
                return this.IsNull(this.tableS_OD_KRIZNI_POREZ.POREZKRIZNIColumn);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_OD_KRIZNI_POREZ.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoplacaNull()
            {
                this[this.tableS_OD_KRIZNI_POREZ.netoplacaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZKRIZNINull()
            {
                this[this.tableS_OD_KRIZNI_POREZ.POREZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OD_KRIZNI_POREZ.IDRADNIKColumn]);
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
                    this[this.tableS_OD_KRIZNI_POREZ.IDRADNIKColumn] = value;
                }
            }

            public decimal netoplaca
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KRIZNI_POREZ.netoplacaColumn]);
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
                    this[this.tableS_OD_KRIZNI_POREZ.netoplacaColumn] = value;
                }
            }

            public decimal POREZKRIZNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_KRIZNI_POREZ.POREZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value POREZKRIZNI because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_KRIZNI_POREZ.POREZKRIZNIColumn] = value;
                }
            }
        }

        public class S_OD_KRIZNI_POREZRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow eventRow;

            public S_OD_KRIZNI_POREZRowChangeEvent(S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow row, DataRowAction action)
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

            public S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_KRIZNI_POREZRowChangeEventHandler(object sender, S_OD_KRIZNI_POREZDataSet.S_OD_KRIZNI_POREZRowChangeEvent e);
    }
}

