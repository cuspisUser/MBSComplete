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
    public class S_OS_BROJ_I_DATUMDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OS_BROJ_I_DATUMDataTable tableS_OS_BROJ_I_DATUM;

        public S_OS_BROJ_I_DATUMDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OS_BROJ_I_DATUMDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OS_BROJ_I_DATUM"] != null)
                    {
                        this.Tables.Add(new S_OS_BROJ_I_DATUMDataTable(dataSet.Tables["S_OS_BROJ_I_DATUM"]));
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
            S_OS_BROJ_I_DATUMDataSet set = (S_OS_BROJ_I_DATUMDataSet) base.Clone();
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
            S_OS_BROJ_I_DATUMDataSet set = new S_OS_BROJ_I_DATUMDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OS_BROJ_I_DATUMDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2158");
            this.ExtendedProperties.Add("DataSetName", "S_OS_BROJ_I_DATUMDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OS_BROJ_I_DATUMDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OS_BROJ_I_DATUM");
            this.ExtendedProperties.Add("ObjectDescription", "S_OS_BROJ_I_DATUM");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\OSNOVNA");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_OS_BROJ_I_DATUM");
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
            this.DataSetName = "S_OS_BROJ_I_DATUMDataSet";
            this.Namespace = "http://www.tempuri.org/S_OS_BROJ_I_DATUM";
            this.tableS_OS_BROJ_I_DATUM = new S_OS_BROJ_I_DATUMDataTable();
            this.Tables.Add(this.tableS_OS_BROJ_I_DATUM);
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
            this.tableS_OS_BROJ_I_DATUM = (S_OS_BROJ_I_DATUMDataTable) this.Tables["S_OS_BROJ_I_DATUM"];
            if (initTable && (this.tableS_OS_BROJ_I_DATUM != null))
            {
                this.tableS_OS_BROJ_I_DATUM.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OS_BROJ_I_DATUM"] != null)
                {
                    this.Tables.Add(new S_OS_BROJ_I_DATUMDataTable(dataSet.Tables["S_OS_BROJ_I_DATUM"]));
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

        private bool ShouldSerializeS_OS_BROJ_I_DATUM()
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
        public S_OS_BROJ_I_DATUMDataTable S_OS_BROJ_I_DATUM
        {
            get
            {
                return this.tableS_OS_BROJ_I_DATUM;
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
        public class S_OS_BROJ_I_DATUMDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJDOK;
            private DataColumn columnZADNJIDATUM;

            public event S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRowChangeEventHandler S_OS_BROJ_I_DATUMRowChanged;

            public event S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRowChangeEventHandler S_OS_BROJ_I_DATUMRowChanging;

            public event S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRowChangeEventHandler S_OS_BROJ_I_DATUMRowDeleted;

            public event S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRowChangeEventHandler S_OS_BROJ_I_DATUMRowDeleting;

            public S_OS_BROJ_I_DATUMDataTable()
            {
                this.TableName = "S_OS_BROJ_I_DATUM";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OS_BROJ_I_DATUMDataTable(DataTable table) : base(table.TableName)
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

            protected S_OS_BROJ_I_DATUMDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OS_BROJ_I_DATUMRow(S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow row)
            {
                this.Rows.Add(row);
            }

            public S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow AddS_OS_BROJ_I_DATUMRow(int bROJDOK, DateTime zADNJIDATUM)
            {
                S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow row = (S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow) this.NewRow();
                row.ItemArray = new object[] { bROJDOK, zADNJIDATUM };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMDataTable table = (S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OS_BROJ_I_DATUMDataSet set = new S_OS_BROJ_I_DATUMDataSet();
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
                this.columnBROJDOK = new DataColumn("BROJDOK", typeof(int), "", MappingType.Element);
                this.columnBROJDOK.Caption = "BROJDOK";
                this.columnBROJDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJDOK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJDOK.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJDOK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJDOK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJDOK.ExtendedProperties.Add("Description", "BROJDOK");
                this.columnBROJDOK.ExtendedProperties.Add("Length", "8");
                this.columnBROJDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJDOK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJDOK.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJDOK.ExtendedProperties.Add("Deklarit.InternalName", "BROJDOK");
                this.Columns.Add(this.columnBROJDOK);
                this.columnZADNJIDATUM = new DataColumn("ZADNJIDATUM", typeof(DateTime), "", MappingType.Element);
                this.columnZADNJIDATUM.Caption = "ZADNJIDATUM";
                this.columnZADNJIDATUM.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADNJIDATUM.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADNJIDATUM.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADNJIDATUM.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnZADNJIDATUM.ExtendedProperties.Add("IsKey", "false");
                this.columnZADNJIDATUM.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADNJIDATUM.ExtendedProperties.Add("DeklaritType", "date");
                this.columnZADNJIDATUM.ExtendedProperties.Add("Description", "ZADNJIDATUM");
                this.columnZADNJIDATUM.ExtendedProperties.Add("Length", "8");
                this.columnZADNJIDATUM.ExtendedProperties.Add("Decimals", "0");
                this.columnZADNJIDATUM.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADNJIDATUM.ExtendedProperties.Add("IsInReader", "true");
                this.columnZADNJIDATUM.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADNJIDATUM.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADNJIDATUM.ExtendedProperties.Add("Deklarit.InternalName", "ZADNJIDATUM");
                this.Columns.Add(this.columnZADNJIDATUM);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OS_BROJ_I_DATUM");
                this.ExtendedProperties.Add("Description", "S_OS_BROJ_I_DATUM");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnBROJDOK = this.Columns["BROJDOK"];
                this.columnZADNJIDATUM = this.Columns["ZADNJIDATUM"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow(builder);
            }

            public S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow NewS_OS_BROJ_I_DATUMRow()
            {
                return (S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OS_BROJ_I_DATUMRowChanged != null)
                {
                    S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRowChangeEventHandler handler = this.S_OS_BROJ_I_DATUMRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRowChangeEvent((S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OS_BROJ_I_DATUMRowChanging != null)
                {
                    S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRowChangeEventHandler handler = this.S_OS_BROJ_I_DATUMRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRowChangeEvent((S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OS_BROJ_I_DATUMRowDeleted != null)
                {
                    S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRowChangeEventHandler handler = this.S_OS_BROJ_I_DATUMRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRowChangeEvent((S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OS_BROJ_I_DATUMRowDeleting != null)
                {
                    S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRowChangeEventHandler handler = this.S_OS_BROJ_I_DATUMRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRowChangeEvent((S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OS_BROJ_I_DATUMRow(S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJDOKColumn
            {
                get
                {
                    return this.columnBROJDOK;
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

            public S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow this[int index]
            {
                get
                {
                    return (S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow) this.Rows[index];
                }
            }

            public DataColumn ZADNJIDATUMColumn
            {
                get
                {
                    return this.columnZADNJIDATUM;
                }
            }
        }

        public class S_OS_BROJ_I_DATUMRow : DataRow
        {
            private S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMDataTable tableS_OS_BROJ_I_DATUM;

            internal S_OS_BROJ_I_DATUMRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OS_BROJ_I_DATUM = (S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMDataTable) this.Table;
            }

            public bool IsBROJDOKNull()
            {
                return this.IsNull(this.tableS_OS_BROJ_I_DATUM.BROJDOKColumn);
            }

            public bool IsZADNJIDATUMNull()
            {
                return this.IsNull(this.tableS_OS_BROJ_I_DATUM.ZADNJIDATUMColumn);
            }

            public void SetBROJDOKNull()
            {
                this[this.tableS_OS_BROJ_I_DATUM.BROJDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADNJIDATUMNull()
            {
                this[this.tableS_OS_BROJ_I_DATUM.ZADNJIDATUMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BROJDOK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OS_BROJ_I_DATUM.BROJDOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJDOK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_BROJ_I_DATUM.BROJDOKColumn] = value;
                }
            }

            public DateTime ZADNJIDATUM
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_OS_BROJ_I_DATUM.ZADNJIDATUMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ZADNJIDATUM because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_OS_BROJ_I_DATUM.ZADNJIDATUMColumn] = value;
                }
            }
        }

        public class S_OS_BROJ_I_DATUMRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow eventRow;

            public S_OS_BROJ_I_DATUMRowChangeEvent(S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow row, DataRowAction action)
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

            public S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OS_BROJ_I_DATUMRowChangeEventHandler(object sender, S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRowChangeEvent e);
    }
}

