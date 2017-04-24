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
    public class VALUTEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private VALUTEDataTable tableVALUTE;

        public VALUTEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected VALUTEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["VALUTE"] != null)
                    {
                        this.Tables.Add(new VALUTEDataTable(dataSet.Tables["VALUTE"]));
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
            VALUTEDataSet set = (VALUTEDataSet) base.Clone();
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
            VALUTEDataSet set = new VALUTEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "VALUTEDataAdapter");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1027");
            this.ExtendedProperties.Add("DataSetName", "VALUTEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IVALUTEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "VALUTE");
            this.ExtendedProperties.Add("ObjectDescription", "Valute i teeajna lista");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
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
            this.DataSetName = "VALUTEDataSet";
            this.Namespace = "http://www.tempuri.org/VALUTE";
            this.tableVALUTE = new VALUTEDataTable();
            this.Tables.Add(this.tableVALUTE);
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
            this.tableVALUTE = (VALUTEDataTable) this.Tables["VALUTE"];
            if (initTable && (this.tableVALUTE != null))
            {
                this.tableVALUTE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["VALUTE"] != null)
                {
                    this.Tables.Add(new VALUTEDataTable(dataSet.Tables["VALUTE"]));
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

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        private bool ShouldSerializeVALUTE()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public VALUTEDataTable VALUTE
        {
            get
            {
                return this.tableVALUTE;
            }
        }

        [Serializable]
        public class VALUTEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDVALUTA;
            private DataColumn columnNAZIVVALUTA;
            private DataColumn columnTECAJ;

            public event VALUTEDataSet.VALUTERowChangeEventHandler VALUTERowChanged;

            public event VALUTEDataSet.VALUTERowChangeEventHandler VALUTERowChanging;

            public event VALUTEDataSet.VALUTERowChangeEventHandler VALUTERowDeleted;

            public event VALUTEDataSet.VALUTERowChangeEventHandler VALUTERowDeleting;

            public VALUTEDataTable()
            {
                this.TableName = "VALUTE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal VALUTEDataTable(DataTable table) : base(table.TableName)
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

            protected VALUTEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddVALUTERow(VALUTEDataSet.VALUTERow row)
            {
                this.Rows.Add(row);
            }

            public VALUTEDataSet.VALUTERow AddVALUTERow(int iDVALUTA, string nAZIVVALUTA, decimal tECAJ)
            {
                VALUTEDataSet.VALUTERow row = (VALUTEDataSet.VALUTERow) this.NewRow();
                row["IDVALUTA"] = iDVALUTA;
                row["NAZIVVALUTA"] = nAZIVVALUTA;
                row["TECAJ"] = tECAJ;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                VALUTEDataSet.VALUTEDataTable table = (VALUTEDataSet.VALUTEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public VALUTEDataSet.VALUTERow FindByIDVALUTA(int iDVALUTA)
            {
                return (VALUTEDataSet.VALUTERow) this.Rows.Find(new object[] { iDVALUTA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(VALUTEDataSet.VALUTERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                VALUTEDataSet set = new VALUTEDataSet();
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
                this.columnIDVALUTA = new DataColumn("IDVALUTA", typeof(int), "", MappingType.Element);
                this.columnIDVALUTA.AllowDBNull = false;
                this.columnIDVALUTA.Caption = "Šifra valute";
                this.columnIDVALUTA.Unique = true;
                this.columnIDVALUTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDVALUTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDVALUTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDVALUTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDVALUTA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDVALUTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDVALUTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDVALUTA.ExtendedProperties.Add("Description", "Šifra valute");
                this.columnIDVALUTA.ExtendedProperties.Add("Length", "5");
                this.columnIDVALUTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDVALUTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDVALUTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDVALUTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDVALUTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDVALUTA.ExtendedProperties.Add("Deklarit.InternalName", "IDVALUTA");
                this.Columns.Add(this.columnIDVALUTA);
                this.columnNAZIVVALUTA = new DataColumn("NAZIVVALUTA", typeof(string), "", MappingType.Element);
                this.columnNAZIVVALUTA.AllowDBNull = false;
                this.columnNAZIVVALUTA.Caption = "Naziv valute";
                this.columnNAZIVVALUTA.MaxLength = 50;
                this.columnNAZIVVALUTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVVALUTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("Description", "Naziv valute");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVALUTA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVALUTA");
                this.Columns.Add(this.columnNAZIVVALUTA);
                this.columnTECAJ = new DataColumn("TECAJ", typeof(decimal), "", MappingType.Element);
                this.columnTECAJ.AllowDBNull = false;
                this.columnTECAJ.Caption = "Tečaj";
                this.columnTECAJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTECAJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTECAJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTECAJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTECAJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTECAJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTECAJ.ExtendedProperties.Add("IsKey", "false");
                this.columnTECAJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnTECAJ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnTECAJ.ExtendedProperties.Add("Description", "Tečaj");
                this.columnTECAJ.ExtendedProperties.Add("Length", "12");
                this.columnTECAJ.ExtendedProperties.Add("Decimals", "8");
                this.columnTECAJ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnTECAJ.ExtendedProperties.Add("DomainType", "PUNODECIMALA");
                this.columnTECAJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnTECAJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnTECAJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTECAJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTECAJ.ExtendedProperties.Add("Deklarit.InternalName", "TECAJ");
                this.Columns.Add(this.columnTECAJ);
                this.PrimaryKey = new DataColumn[] { this.columnIDVALUTA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "VALUTE");
                this.ExtendedProperties.Add("Description", "Valute i teeajna lista");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDVALUTA = this.Columns["IDVALUTA"];
                this.columnNAZIVVALUTA = this.Columns["NAZIVVALUTA"];
                this.columnTECAJ = this.Columns["TECAJ"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new VALUTEDataSet.VALUTERow(builder);
            }

            public VALUTEDataSet.VALUTERow NewVALUTERow()
            {
                return (VALUTEDataSet.VALUTERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VALUTERowChanged != null)
                {
                    VALUTEDataSet.VALUTERowChangeEventHandler vALUTERowChangedEvent = this.VALUTERowChanged;
                    if (vALUTERowChangedEvent != null)
                    {
                        vALUTERowChangedEvent(this, new VALUTEDataSet.VALUTERowChangeEvent((VALUTEDataSet.VALUTERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VALUTERowChanging != null)
                {
                    VALUTEDataSet.VALUTERowChangeEventHandler vALUTERowChangingEvent = this.VALUTERowChanging;
                    if (vALUTERowChangingEvent != null)
                    {
                        vALUTERowChangingEvent(this, new VALUTEDataSet.VALUTERowChangeEvent((VALUTEDataSet.VALUTERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VALUTERowDeleted != null)
                {
                    VALUTEDataSet.VALUTERowChangeEventHandler vALUTERowDeletedEvent = this.VALUTERowDeleted;
                    if (vALUTERowDeletedEvent != null)
                    {
                        vALUTERowDeletedEvent(this, new VALUTEDataSet.VALUTERowChangeEvent((VALUTEDataSet.VALUTERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VALUTERowDeleting != null)
                {
                    VALUTEDataSet.VALUTERowChangeEventHandler vALUTERowDeletingEvent = this.VALUTERowDeleting;
                    if (vALUTERowDeletingEvent != null)
                    {
                        vALUTERowDeletingEvent(this, new VALUTEDataSet.VALUTERowChangeEvent((VALUTEDataSet.VALUTERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveVALUTERow(VALUTEDataSet.VALUTERow row)
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

            public DataColumn IDVALUTAColumn
            {
                get
                {
                    return this.columnIDVALUTA;
                }
            }

            public VALUTEDataSet.VALUTERow this[int index]
            {
                get
                {
                    return (VALUTEDataSet.VALUTERow) this.Rows[index];
                }
            }

            public DataColumn NAZIVVALUTAColumn
            {
                get
                {
                    return this.columnNAZIVVALUTA;
                }
            }

            public DataColumn TECAJColumn
            {
                get
                {
                    return this.columnTECAJ;
                }
            }
        }

        public class VALUTERow : DataRow
        {
            private VALUTEDataSet.VALUTEDataTable tableVALUTE;

            internal VALUTERow(DataRowBuilder rb) : base(rb)
            {
                this.tableVALUTE = (VALUTEDataSet.VALUTEDataTable) this.Table;
            }

            public bool IsIDVALUTANull()
            {
                return this.IsNull(this.tableVALUTE.IDVALUTAColumn);
            }

            public bool IsNAZIVVALUTANull()
            {
                return this.IsNull(this.tableVALUTE.NAZIVVALUTAColumn);
            }

            public bool IsTECAJNull()
            {
                return this.IsNull(this.tableVALUTE.TECAJColumn);
            }

            public void SetNAZIVVALUTANull()
            {
                this[this.tableVALUTE.NAZIVVALUTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTECAJNull()
            {
                this[this.tableVALUTE.TECAJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDVALUTA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableVALUTE.IDVALUTAColumn]);
                }
                set
                {
                    this[this.tableVALUTE.IDVALUTAColumn] = value;
                }
            }

            public string NAZIVVALUTA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVALUTE.NAZIVVALUTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVVALUTA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableVALUTE.NAZIVVALUTAColumn] = value;
                }
            }

            public decimal TECAJ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableVALUTE.TECAJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value TECAJ because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableVALUTE.TECAJColumn] = value;
                }
            }
        }

        public class VALUTERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private VALUTEDataSet.VALUTERow eventRow;

            public VALUTERowChangeEvent(VALUTEDataSet.VALUTERow row, DataRowAction action)
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

            public VALUTEDataSet.VALUTERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void VALUTERowChangeEventHandler(object sender, VALUTEDataSet.VALUTERowChangeEvent e);
    }
}

