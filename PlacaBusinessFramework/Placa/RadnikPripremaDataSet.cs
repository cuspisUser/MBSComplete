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
    public class RadnikPripremaDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RADNIKDataTable tableRADNIK;

        public RadnikPripremaDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RadnikPripremaDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RADNIK"] != null)
                    {
                        this.Tables.Add(new RADNIKDataTable(dataSet.Tables["RADNIK"]));
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
            RadnikPripremaDataSet set = (RadnikPripremaDataSet) base.Clone();
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
            RadnikPripremaDataSet set = new RadnikPripremaDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RadnikPripremaDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2123");
            this.ExtendedProperties.Add("DataSetName", "RadnikPripremaDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRadnikPripremaDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RadnikPriprema");
            this.ExtendedProperties.Add("ObjectDescription", "RadnikPriprema");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("DefaultBusinessComponent", "RADNIK");
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
            this.DataSetName = "RadnikPripremaDataSet";
            this.Namespace = "http://www.tempuri.org/RadnikPriprema";
            this.tableRADNIK = new RADNIKDataTable();
            this.Tables.Add(this.tableRADNIK);
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
            this.tableRADNIK = (RADNIKDataTable) this.Tables["RADNIK"];
            if (initTable && (this.tableRADNIK != null))
            {
                this.tableRADNIK.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RADNIK"] != null)
                {
                    this.Tables.Add(new RADNIKDataTable(dataSet.Tables["RADNIK"]));
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

        private bool ShouldSerializeRADNIK()
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
        public RADNIKDataTable RADNIK
        {
            get
            {
                return this.tableRADNIK;
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
        public class RADNIKDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRADNIK;
            private DataColumn columnIME;
            private DataColumn columnPREZIME;
            private DataColumn columnSPOJENOPREZIME;

            public event RadnikPripremaDataSet.RADNIKRowChangeEventHandler RADNIKRowChanged;

            public event RadnikPripremaDataSet.RADNIKRowChangeEventHandler RADNIKRowChanging;

            public event RadnikPripremaDataSet.RADNIKRowChangeEventHandler RADNIKRowDeleted;

            public event RadnikPripremaDataSet.RADNIKRowChangeEventHandler RADNIKRowDeleting;

            public RADNIKDataTable()
            {
                this.TableName = "RADNIK";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RADNIKDataTable(DataTable table) : base(table.TableName)
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

            protected RADNIKDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRADNIKRow(RadnikPripremaDataSet.RADNIKRow row)
            {
                this.Rows.Add(row);
            }

            public RadnikPripremaDataSet.RADNIKRow AddRADNIKRow(int iDRADNIK, string sPOJENOPREZIME, string pREZIME, string iME)
            {
                RadnikPripremaDataSet.RADNIKRow row = (RadnikPripremaDataSet.RADNIKRow) this.NewRow();
                row.ItemArray = new object[] { iDRADNIK, sPOJENOPREZIME, pREZIME, iME };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RadnikPripremaDataSet.RADNIKDataTable table = (RadnikPripremaDataSet.RADNIKDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RadnikPripremaDataSet.RADNIKRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RadnikPripremaDataSet set = new RadnikPripremaDataSet();
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
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnSPOJENOPREZIME = new DataColumn("SPOJENOPREZIME", typeof(string), "", MappingType.Element);
                this.columnSPOJENOPREZIME.Caption = "SPOJENOPREZIME";
                this.columnSPOJENOPREZIME.MaxLength = 100;
                this.columnSPOJENOPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
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
                this.columnPREZIME = new DataColumn("PREZIME", typeof(string), "", MappingType.Element);
                this.columnPREZIME.Caption = "Prezime";
                this.columnPREZIME.MaxLength = 50;
                this.columnPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPREZIME.ExtendedProperties.Add("IsKey", "true");
                this.columnPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPREZIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "PREZIME");
                this.Columns.Add(this.columnPREZIME);
                this.columnIME = new DataColumn("IME", typeof(string), "", MappingType.Element);
                this.columnIME.Caption = "Ime";
                this.columnIME.MaxLength = 50;
                this.columnIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIME.ExtendedProperties.Add("IsKey", "false");
                this.columnIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIME.ExtendedProperties.Add("Description", "Ime");
                this.columnIME.ExtendedProperties.Add("Length", "50");
                this.columnIME.ExtendedProperties.Add("Decimals", "0");
                this.columnIME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.InternalName", "IME");
                this.Columns.Add(this.columnIME);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RadnikPriprema");
                this.ExtendedProperties.Add("Description", "RADNIK");
                this.ExtendedProperties.Add("HasOrder", "true");
                this.ExtendedProperties.Add("OrderAttributes", "PREZIME");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnSPOJENOPREZIME = this.Columns["SPOJENOPREZIME"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
            }

            public RadnikPripremaDataSet.RADNIKRow NewRADNIKRow()
            {
                return (RadnikPripremaDataSet.RADNIKRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RadnikPripremaDataSet.RADNIKRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RADNIKRowChanged != null)
                {
                    RadnikPripremaDataSet.RADNIKRowChangeEventHandler rADNIKRowChangedEvent = this.RADNIKRowChanged;
                    if (rADNIKRowChangedEvent != null)
                    {
                        rADNIKRowChangedEvent(this, new RadnikPripremaDataSet.RADNIKRowChangeEvent((RadnikPripremaDataSet.RADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RADNIKRowChanging != null)
                {
                    RadnikPripremaDataSet.RADNIKRowChangeEventHandler rADNIKRowChangingEvent = this.RADNIKRowChanging;
                    if (rADNIKRowChangingEvent != null)
                    {
                        rADNIKRowChangingEvent(this, new RadnikPripremaDataSet.RADNIKRowChangeEvent((RadnikPripremaDataSet.RADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RADNIKRowDeleted != null)
                {
                    RadnikPripremaDataSet.RADNIKRowChangeEventHandler rADNIKRowDeletedEvent = this.RADNIKRowDeleted;
                    if (rADNIKRowDeletedEvent != null)
                    {
                        rADNIKRowDeletedEvent(this, new RadnikPripremaDataSet.RADNIKRowChangeEvent((RadnikPripremaDataSet.RADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RADNIKRowDeleting != null)
                {
                    RadnikPripremaDataSet.RADNIKRowChangeEventHandler rADNIKRowDeletingEvent = this.RADNIKRowDeleting;
                    if (rADNIKRowDeletingEvent != null)
                    {
                        rADNIKRowDeletingEvent(this, new RadnikPripremaDataSet.RADNIKRowChangeEvent((RadnikPripremaDataSet.RADNIKRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRADNIKRow(RadnikPripremaDataSet.RADNIKRow row)
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

            public DataColumn IMEColumn
            {
                get
                {
                    return this.columnIME;
                }
            }

            public RadnikPripremaDataSet.RADNIKRow this[int index]
            {
                get
                {
                    return (RadnikPripremaDataSet.RADNIKRow) this.Rows[index];
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
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

        public class RADNIKRow : DataRow
        {
            private RadnikPripremaDataSet.RADNIKDataTable tableRADNIK;

            internal RADNIKRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRADNIK = (RadnikPripremaDataSet.RADNIKDataTable) this.Table;
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableRADNIK.IDRADNIKColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableRADNIK.IMEColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableRADNIK.PREZIMEColumn);
            }

            public bool IsSPOJENOPREZIMENull()
            {
                return this.IsNull(this.tableRADNIK.SPOJENOPREZIMEColumn);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableRADNIK.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableRADNIK.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableRADNIK.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSPOJENOPREZIMENull()
            {
                this[this.tableRADNIK.SPOJENOPREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDRADNIKColumn]);
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
                    this[this.tableRADNIK.IDRADNIKColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.IMEColumn]);
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
                    this[this.tableRADNIK.IMEColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.PREZIMEColumn]);
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
                    this[this.tableRADNIK.PREZIMEColumn] = value;
                }
            }

            public string SPOJENOPREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.SPOJENOPREZIMEColumn]);
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
                    this[this.tableRADNIK.SPOJENOPREZIMEColumn] = value;
                }
            }
        }

        public class RADNIKRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RadnikPripremaDataSet.RADNIKRow eventRow;

            public RADNIKRowChangeEvent(RadnikPripremaDataSet.RADNIKRow row, DataRowAction action)
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

            public RadnikPripremaDataSet.RADNIKRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RADNIKRowChangeEventHandler(object sender, RadnikPripremaDataSet.RADNIKRowChangeEvent e);
    }
}

