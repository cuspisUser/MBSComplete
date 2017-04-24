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
    public class OSOBNIODBITAKDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private OSOBNIODBITAKDataTable tableOSOBNIODBITAK;

        public OSOBNIODBITAKDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected OSOBNIODBITAKDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["OSOBNIODBITAK"] != null)
                    {
                        this.Tables.Add(new OSOBNIODBITAKDataTable(dataSet.Tables["OSOBNIODBITAK"]));
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
            OSOBNIODBITAKDataSet set = (OSOBNIODBITAKDataSet) base.Clone();
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
            OSOBNIODBITAKDataSet set = new OSOBNIODBITAKDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "OSOBNIODBITAKDataAdapter");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1014");
            this.ExtendedProperties.Add("DataSetName", "OSOBNIODBITAKDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IOSOBNIODBITAKDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "OSOBNIODBITAK");
            this.ExtendedProperties.Add("ObjectDescription", "Faktori osobnog odbitka");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "AlmostNever");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "OSOBNIODBITAKDataSet";
            this.Namespace = "http://www.tempuri.org/OSOBNIODBITAK";
            this.tableOSOBNIODBITAK = new OSOBNIODBITAKDataTable();
            this.Tables.Add(this.tableOSOBNIODBITAK);
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
            this.tableOSOBNIODBITAK = (OSOBNIODBITAKDataTable) this.Tables["OSOBNIODBITAK"];
            if (initTable && (this.tableOSOBNIODBITAK != null))
            {
                this.tableOSOBNIODBITAK.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["OSOBNIODBITAK"] != null)
                {
                    this.Tables.Add(new OSOBNIODBITAKDataTable(dataSet.Tables["OSOBNIODBITAK"]));
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

        private bool ShouldSerializeOSOBNIODBITAK()
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
        public OSOBNIODBITAKDataTable OSOBNIODBITAK
        {
            get
            {
                return this.tableOSOBNIODBITAK;
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
        public class OSOBNIODBITAKDataTable : DataTable, IEnumerable
        {
            private DataColumn columnFAKTOROSOBNOGODBITKA;
            private DataColumn columnIDOSOBNIODBITAK;
            private DataColumn columnNAZIVOSOBNIODBITAK;

            public event OSOBNIODBITAKDataSet.OSOBNIODBITAKRowChangeEventHandler OSOBNIODBITAKRowChanged;

            public event OSOBNIODBITAKDataSet.OSOBNIODBITAKRowChangeEventHandler OSOBNIODBITAKRowChanging;

            public event OSOBNIODBITAKDataSet.OSOBNIODBITAKRowChangeEventHandler OSOBNIODBITAKRowDeleted;

            public event OSOBNIODBITAKDataSet.OSOBNIODBITAKRowChangeEventHandler OSOBNIODBITAKRowDeleting;

            public OSOBNIODBITAKDataTable()
            {
                this.TableName = "OSOBNIODBITAK";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OSOBNIODBITAKDataTable(DataTable table) : base(table.TableName)
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

            protected OSOBNIODBITAKDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOSOBNIODBITAKRow(OSOBNIODBITAKDataSet.OSOBNIODBITAKRow row)
            {
                this.Rows.Add(row);
            }

            public OSOBNIODBITAKDataSet.OSOBNIODBITAKRow AddOSOBNIODBITAKRow(int iDOSOBNIODBITAK, string nAZIVOSOBNIODBITAK, decimal fAKTOROSOBNOGODBITKA)
            {
                OSOBNIODBITAKDataSet.OSOBNIODBITAKRow row = (OSOBNIODBITAKDataSet.OSOBNIODBITAKRow) this.NewRow();
                row["IDOSOBNIODBITAK"] = iDOSOBNIODBITAK;
                row["NAZIVOSOBNIODBITAK"] = nAZIVOSOBNIODBITAK;
                row["FAKTOROSOBNOGODBITKA"] = fAKTOROSOBNOGODBITKA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OSOBNIODBITAKDataSet.OSOBNIODBITAKDataTable table = (OSOBNIODBITAKDataSet.OSOBNIODBITAKDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OSOBNIODBITAKDataSet.OSOBNIODBITAKRow FindByIDOSOBNIODBITAK(int iDOSOBNIODBITAK)
            {
                return (OSOBNIODBITAKDataSet.OSOBNIODBITAKRow) this.Rows.Find(new object[] { iDOSOBNIODBITAK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OSOBNIODBITAKDataSet.OSOBNIODBITAKRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OSOBNIODBITAKDataSet set = new OSOBNIODBITAKDataSet();
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
                this.columnIDOSOBNIODBITAK = new DataColumn("IDOSOBNIODBITAK", typeof(int), "", MappingType.Element);
                this.columnIDOSOBNIODBITAK.AllowDBNull = false;
                this.columnIDOSOBNIODBITAK.Caption = "Šifra osobnog odbitka";
                this.columnIDOSOBNIODBITAK.Unique = true;
                this.columnIDOSOBNIODBITAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("Description", "Šifra osobnog odbitka");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("Length", "5");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.InternalName", "IDOSOBNIODBITAK");
                this.Columns.Add(this.columnIDOSOBNIODBITAK);
                this.columnNAZIVOSOBNIODBITAK = new DataColumn("NAZIVOSOBNIODBITAK", typeof(string), "", MappingType.Element);
                this.columnNAZIVOSOBNIODBITAK.AllowDBNull = false;
                this.columnNAZIVOSOBNIODBITAK.Caption = "Naziv osobnog odbitka";
                this.columnNAZIVOSOBNIODBITAK.MaxLength = 100;
                this.columnNAZIVOSOBNIODBITAK.DefaultValue = "";
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Description", "Naziv osobnog odbitka");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("TreatEmptyAsNull", "true");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOSOBNIODBITAK");
                this.Columns.Add(this.columnNAZIVOSOBNIODBITAK);
                this.columnFAKTOROSOBNOGODBITKA = new DataColumn("FAKTOROSOBNOGODBITKA", typeof(decimal), "", MappingType.Element);
                this.columnFAKTOROSOBNOGODBITKA.AllowDBNull = false;
                this.columnFAKTOROSOBNOGODBITKA.Caption = "Faktor osobnog odbitka";
                this.columnFAKTOROSOBNOGODBITKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("IsKey", "false");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Description", "Faktor osobnog odbitka");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Length", "5");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Decimals", "2");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.InternalName", "FAKTOROSOBNOGODBITKA");
                this.Columns.Add(this.columnFAKTOROSOBNOGODBITKA);
                this.PrimaryKey = new DataColumn[] { this.columnIDOSOBNIODBITAK };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "OSOBNIODBITAK");
                this.ExtendedProperties.Add("Description", "Faktori osobnog odbitka");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDOSOBNIODBITAK = this.Columns["IDOSOBNIODBITAK"];
                this.columnNAZIVOSOBNIODBITAK = this.Columns["NAZIVOSOBNIODBITAK"];
                this.columnFAKTOROSOBNOGODBITKA = this.Columns["FAKTOROSOBNOGODBITKA"];
            }

            public OSOBNIODBITAKDataSet.OSOBNIODBITAKRow NewOSOBNIODBITAKRow()
            {
                return (OSOBNIODBITAKDataSet.OSOBNIODBITAKRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OSOBNIODBITAKDataSet.OSOBNIODBITAKRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OSOBNIODBITAKRowChanged != null)
                {
                    OSOBNIODBITAKDataSet.OSOBNIODBITAKRowChangeEventHandler oSOBNIODBITAKRowChangedEvent = this.OSOBNIODBITAKRowChanged;
                    if (oSOBNIODBITAKRowChangedEvent != null)
                    {
                        oSOBNIODBITAKRowChangedEvent(this, new OSOBNIODBITAKDataSet.OSOBNIODBITAKRowChangeEvent((OSOBNIODBITAKDataSet.OSOBNIODBITAKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OSOBNIODBITAKRowChanging != null)
                {
                    OSOBNIODBITAKDataSet.OSOBNIODBITAKRowChangeEventHandler oSOBNIODBITAKRowChangingEvent = this.OSOBNIODBITAKRowChanging;
                    if (oSOBNIODBITAKRowChangingEvent != null)
                    {
                        oSOBNIODBITAKRowChangingEvent(this, new OSOBNIODBITAKDataSet.OSOBNIODBITAKRowChangeEvent((OSOBNIODBITAKDataSet.OSOBNIODBITAKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.OSOBNIODBITAKRowDeleted != null)
                {
                    OSOBNIODBITAKDataSet.OSOBNIODBITAKRowChangeEventHandler oSOBNIODBITAKRowDeletedEvent = this.OSOBNIODBITAKRowDeleted;
                    if (oSOBNIODBITAKRowDeletedEvent != null)
                    {
                        oSOBNIODBITAKRowDeletedEvent(this, new OSOBNIODBITAKDataSet.OSOBNIODBITAKRowChangeEvent((OSOBNIODBITAKDataSet.OSOBNIODBITAKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OSOBNIODBITAKRowDeleting != null)
                {
                    OSOBNIODBITAKDataSet.OSOBNIODBITAKRowChangeEventHandler oSOBNIODBITAKRowDeletingEvent = this.OSOBNIODBITAKRowDeleting;
                    if (oSOBNIODBITAKRowDeletingEvent != null)
                    {
                        oSOBNIODBITAKRowDeletingEvent(this, new OSOBNIODBITAKDataSet.OSOBNIODBITAKRowChangeEvent((OSOBNIODBITAKDataSet.OSOBNIODBITAKRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOSOBNIODBITAKRow(OSOBNIODBITAKDataSet.OSOBNIODBITAKRow row)
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

            public DataColumn FAKTOROSOBNOGODBITKAColumn
            {
                get
                {
                    return this.columnFAKTOROSOBNOGODBITKA;
                }
            }

            public DataColumn IDOSOBNIODBITAKColumn
            {
                get
                {
                    return this.columnIDOSOBNIODBITAK;
                }
            }

            public OSOBNIODBITAKDataSet.OSOBNIODBITAKRow this[int index]
            {
                get
                {
                    return (OSOBNIODBITAKDataSet.OSOBNIODBITAKRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVOSOBNIODBITAKColumn
            {
                get
                {
                    return this.columnNAZIVOSOBNIODBITAK;
                }
            }
        }

        public class OSOBNIODBITAKRow : DataRow
        {
            private OSOBNIODBITAKDataSet.OSOBNIODBITAKDataTable tableOSOBNIODBITAK;

            internal OSOBNIODBITAKRow(DataRowBuilder rb) : base(rb)
            {
                this.tableOSOBNIODBITAK = (OSOBNIODBITAKDataSet.OSOBNIODBITAKDataTable) this.Table;
            }

            public bool IsFAKTOROSOBNOGODBITKANull()
            {
                return this.IsNull(this.tableOSOBNIODBITAK.FAKTOROSOBNOGODBITKAColumn);
            }

            public bool IsIDOSOBNIODBITAKNull()
            {
                return this.IsNull(this.tableOSOBNIODBITAK.IDOSOBNIODBITAKColumn);
            }

            public bool IsNAZIVOSOBNIODBITAKNull()
            {
                return this.IsNull(this.tableOSOBNIODBITAK.NAZIVOSOBNIODBITAKColumn);
            }

            public void SetFAKTOROSOBNOGODBITKANull()
            {
                this[this.tableOSOBNIODBITAK.FAKTOROSOBNOGODBITKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOSOBNIODBITAKNull()
            {
                this[this.tableOSOBNIODBITAK.NAZIVOSOBNIODBITAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal FAKTOROSOBNOGODBITKA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOSOBNIODBITAK.FAKTOROSOBNOGODBITKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value FAKTOROSOBNOGODBITKA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableOSOBNIODBITAK.FAKTOROSOBNOGODBITKAColumn] = value;
                }
            }

            public int IDOSOBNIODBITAK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOSOBNIODBITAK.IDOSOBNIODBITAKColumn]);
                }
                set
                {
                    this[this.tableOSOBNIODBITAK.IDOSOBNIODBITAKColumn] = value;
                }
            }

            public string NAZIVOSOBNIODBITAK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOSOBNIODBITAK.NAZIVOSOBNIODBITAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVOSOBNIODBITAK because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableOSOBNIODBITAK.NAZIVOSOBNIODBITAKColumn] = value;
                }
            }
        }

        public class OSOBNIODBITAKRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OSOBNIODBITAKDataSet.OSOBNIODBITAKRow eventRow;

            public OSOBNIODBITAKRowChangeEvent(OSOBNIODBITAKDataSet.OSOBNIODBITAKRow row, DataRowAction action)
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

            public OSOBNIODBITAKDataSet.OSOBNIODBITAKRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OSOBNIODBITAKRowChangeEventHandler(object sender, OSOBNIODBITAKDataSet.OSOBNIODBITAKRowChangeEvent e);
    }
}

