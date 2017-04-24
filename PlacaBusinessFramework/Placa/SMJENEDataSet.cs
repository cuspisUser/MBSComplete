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
    public class SMJENEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private SMJENEDataTable tableSMJENE;

        public SMJENEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected SMJENEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["SMJENE"] != null)
                    {
                        this.Tables.Add(new SMJENEDataTable(dataSet.Tables["SMJENE"]));
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
            SMJENEDataSet set = (SMJENEDataSet) base.Clone();
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
            SMJENEDataSet set = new SMJENEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "SMJENEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2134");
            this.ExtendedProperties.Add("DataSetName", "SMJENEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ISMJENEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "SMJENE");
            this.ExtendedProperties.Add("ObjectDescription", "SMJENE");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Evidencija");
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
            this.DataSetName = "SMJENEDataSet";
            this.Namespace = "http://www.tempuri.org/SMJENE";
            this.tableSMJENE = new SMJENEDataTable();
            this.Tables.Add(this.tableSMJENE);
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
            this.tableSMJENE = (SMJENEDataTable) this.Tables["SMJENE"];
            if (initTable && (this.tableSMJENE != null))
            {
                this.tableSMJENE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["SMJENE"] != null)
                {
                    this.Tables.Add(new SMJENEDataTable(dataSet.Tables["SMJENE"]));
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

        private bool ShouldSerializeSMJENE()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SMJENEDataTable SMJENE
        {
            get
            {
                return this.tableSMJENE;
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
        public class SMJENEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSMJENE;
            private DataColumn columnOPISSMJENE;
            private DataColumn columnPOCETAK;
            private DataColumn columnZAVRSETAK;

            public event SMJENEDataSet.SMJENERowChangeEventHandler SMJENERowChanged;

            public event SMJENEDataSet.SMJENERowChangeEventHandler SMJENERowChanging;

            public event SMJENEDataSet.SMJENERowChangeEventHandler SMJENERowDeleted;

            public event SMJENEDataSet.SMJENERowChangeEventHandler SMJENERowDeleting;

            public SMJENEDataTable()
            {
                this.TableName = "SMJENE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SMJENEDataTable(DataTable table) : base(table.TableName)
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

            protected SMJENEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSMJENERow(SMJENEDataSet.SMJENERow row)
            {
                this.Rows.Add(row);
            }

            public SMJENEDataSet.SMJENERow AddSMJENERow(int iDSMJENE, string oPISSMJENE, string pOCETAK, string zAVRSETAK)
            {
                SMJENEDataSet.SMJENERow row = (SMJENEDataSet.SMJENERow) this.NewRow();
                row["IDSMJENE"] = iDSMJENE;
                row["OPISSMJENE"] = oPISSMJENE;
                row["POCETAK"] = pOCETAK;
                row["ZAVRSETAK"] = zAVRSETAK;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SMJENEDataSet.SMJENEDataTable table = (SMJENEDataSet.SMJENEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SMJENEDataSet.SMJENERow FindByIDSMJENE(int iDSMJENE)
            {
                return (SMJENEDataSet.SMJENERow) this.Rows.Find(new object[] { iDSMJENE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SMJENEDataSet.SMJENERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SMJENEDataSet set = new SMJENEDataSet();
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
                this.columnIDSMJENE = new DataColumn("IDSMJENE", typeof(int), "", MappingType.Element);
                this.columnIDSMJENE.AllowDBNull = false;
                this.columnIDSMJENE.Caption = "IDSMJENE";
                this.columnIDSMJENE.Unique = true;
                this.columnIDSMJENE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSMJENE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSMJENE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSMJENE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSMJENE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSMJENE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSMJENE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSMJENE.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDSMJENE.ExtendedProperties.Add("Length", "5");
                this.columnIDSMJENE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSMJENE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSMJENE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSMJENE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSMJENE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSMJENE.ExtendedProperties.Add("Deklarit.InternalName", "IDSMJENE");
                this.Columns.Add(this.columnIDSMJENE);
                this.columnOPISSMJENE = new DataColumn("OPISSMJENE", typeof(string), "", MappingType.Element);
                this.columnOPISSMJENE.AllowDBNull = false;
                this.columnOPISSMJENE.Caption = "OPISSMJENE";
                this.columnOPISSMJENE.MaxLength = 50;
                this.columnOPISSMJENE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISSMJENE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISSMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISSMJENE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISSMJENE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISSMJENE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISSMJENE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISSMJENE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISSMJENE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISSMJENE.ExtendedProperties.Add("Description", "Opis");
                this.columnOPISSMJENE.ExtendedProperties.Add("Length", "50");
                this.columnOPISSMJENE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISSMJENE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISSMJENE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISSMJENE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISSMJENE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISSMJENE.ExtendedProperties.Add("Deklarit.InternalName", "OPISSMJENE");
                this.Columns.Add(this.columnOPISSMJENE);
                this.columnPOCETAK = new DataColumn("POCETAK", typeof(string), "", MappingType.Element);
                this.columnPOCETAK.AllowDBNull = false;
                this.columnPOCETAK.Caption = "POCETAK";
                this.columnPOCETAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOCETAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOCETAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOCETAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOCETAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOCETAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOCETAK.ExtendedProperties.Add("IsKey", "false");
                this.columnPOCETAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOCETAK.ExtendedProperties.Add("DeklaritType", "vchar");
                this.columnPOCETAK.ExtendedProperties.Add("Description", "Početak rada");
                this.columnPOCETAK.ExtendedProperties.Add("Length", "5");
                this.columnPOCETAK.ExtendedProperties.Add("Decimals", "0");
                this.columnPOCETAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOCETAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOCETAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOCETAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOCETAK.ExtendedProperties.Add("Deklarit.InternalName", "POCETAK");
                this.Columns.Add(this.columnPOCETAK);
                this.columnZAVRSETAK = new DataColumn("ZAVRSETAK", typeof(string), "", MappingType.Element);
                this.columnZAVRSETAK.AllowDBNull = false;
                this.columnZAVRSETAK.Caption = "ZAVRSETAK";
                this.columnZAVRSETAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZAVRSETAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZAVRSETAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZAVRSETAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZAVRSETAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZAVRSETAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZAVRSETAK.ExtendedProperties.Add("IsKey", "false");
                this.columnZAVRSETAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZAVRSETAK.ExtendedProperties.Add("DeklaritType", "vchar");
                this.columnZAVRSETAK.ExtendedProperties.Add("Description", "Završetak rada");
                this.columnZAVRSETAK.ExtendedProperties.Add("Length", "5");
                this.columnZAVRSETAK.ExtendedProperties.Add("Decimals", "0");
                this.columnZAVRSETAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZAVRSETAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnZAVRSETAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZAVRSETAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZAVRSETAK.ExtendedProperties.Add("Deklarit.InternalName", "ZAVRSETAK");
                this.Columns.Add(this.columnZAVRSETAK);
                this.PrimaryKey = new DataColumn[] { this.columnIDSMJENE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "SMJENE");
                this.ExtendedProperties.Add("Description", "SMJENE");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDSMJENE = this.Columns["IDSMJENE"];
                this.columnOPISSMJENE = this.Columns["OPISSMJENE"];
                this.columnPOCETAK = this.Columns["POCETAK"];
                this.columnZAVRSETAK = this.Columns["ZAVRSETAK"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SMJENEDataSet.SMJENERow(builder);
            }

            public SMJENEDataSet.SMJENERow NewSMJENERow()
            {
                return (SMJENEDataSet.SMJENERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SMJENERowChanged != null)
                {
                    SMJENEDataSet.SMJENERowChangeEventHandler sMJENERowChangedEvent = this.SMJENERowChanged;
                    if (sMJENERowChangedEvent != null)
                    {
                        sMJENERowChangedEvent(this, new SMJENEDataSet.SMJENERowChangeEvent((SMJENEDataSet.SMJENERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SMJENERowChanging != null)
                {
                    SMJENEDataSet.SMJENERowChangeEventHandler sMJENERowChangingEvent = this.SMJENERowChanging;
                    if (sMJENERowChangingEvent != null)
                    {
                        sMJENERowChangingEvent(this, new SMJENEDataSet.SMJENERowChangeEvent((SMJENEDataSet.SMJENERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SMJENERowDeleted != null)
                {
                    SMJENEDataSet.SMJENERowChangeEventHandler sMJENERowDeletedEvent = this.SMJENERowDeleted;
                    if (sMJENERowDeletedEvent != null)
                    {
                        sMJENERowDeletedEvent(this, new SMJENEDataSet.SMJENERowChangeEvent((SMJENEDataSet.SMJENERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SMJENERowDeleting != null)
                {
                    SMJENEDataSet.SMJENERowChangeEventHandler sMJENERowDeletingEvent = this.SMJENERowDeleting;
                    if (sMJENERowDeletingEvent != null)
                    {
                        sMJENERowDeletingEvent(this, new SMJENEDataSet.SMJENERowChangeEvent((SMJENEDataSet.SMJENERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSMJENERow(SMJENEDataSet.SMJENERow row)
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

            public DataColumn IDSMJENEColumn
            {
                get
                {
                    return this.columnIDSMJENE;
                }
            }

            public SMJENEDataSet.SMJENERow this[int index]
            {
                get
                {
                    return (SMJENEDataSet.SMJENERow) this.Rows[index];
                }
            }

            public DataColumn OPISSMJENEColumn
            {
                get
                {
                    return this.columnOPISSMJENE;
                }
            }

            public DataColumn POCETAKColumn
            {
                get
                {
                    return this.columnPOCETAK;
                }
            }

            public DataColumn ZAVRSETAKColumn
            {
                get
                {
                    return this.columnZAVRSETAK;
                }
            }
        }

        public class SMJENERow : DataRow
        {
            private SMJENEDataSet.SMJENEDataTable tableSMJENE;

            internal SMJENERow(DataRowBuilder rb) : base(rb)
            {
                this.tableSMJENE = (SMJENEDataSet.SMJENEDataTable) this.Table;
            }

            public bool IsIDSMJENENull()
            {
                return this.IsNull(this.tableSMJENE.IDSMJENEColumn);
            }

            public bool IsOPISSMJENENull()
            {
                return this.IsNull(this.tableSMJENE.OPISSMJENEColumn);
            }

            public bool IsPOCETAKNull()
            {
                return this.IsNull(this.tableSMJENE.POCETAKColumn);
            }

            public bool IsZAVRSETAKNull()
            {
                return this.IsNull(this.tableSMJENE.ZAVRSETAKColumn);
            }

            public void SetOPISSMJENENull()
            {
                this[this.tableSMJENE.OPISSMJENEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOCETAKNull()
            {
                this[this.tableSMJENE.POCETAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZAVRSETAKNull()
            {
                this[this.tableSMJENE.ZAVRSETAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSMJENE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSMJENE.IDSMJENEColumn]);
                }
                set
                {
                    this[this.tableSMJENE.IDSMJENEColumn] = value;
                }
            }

            public string OPISSMJENE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSMJENE.OPISSMJENEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OPISSMJENE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableSMJENE.OPISSMJENEColumn] = value;
                }
            }

            public string POCETAK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSMJENE.POCETAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value POCETAK because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableSMJENE.POCETAKColumn] = value;
                }
            }

            public string ZAVRSETAK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSMJENE.ZAVRSETAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ZAVRSETAK because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableSMJENE.ZAVRSETAKColumn] = value;
                }
            }
        }

        public class SMJENERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SMJENEDataSet.SMJENERow eventRow;

            public SMJENERowChangeEvent(SMJENEDataSet.SMJENERow row, DataRowAction action)
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

            public SMJENEDataSet.SMJENERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SMJENERowChangeEventHandler(object sender, SMJENEDataSet.SMJENERowChangeEvent e);
    }
}

