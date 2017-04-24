namespace FinPosModule
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable, ToolboxItem(true), XmlRoot("dsKonto"), XmlSchemaProvider("GetTypedDataSetSchema"), HelpKeyword("vs.data.DataSet"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), DesignerCategory("code")]
    public class dsKonto : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private KONTODataTable tableKONTO;

        [DebuggerNonUserCode]
        public dsKonto()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        [DebuggerNonUserCode]
        protected dsKonto(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["KONTO"] != null)
                    {
                        base.Tables.Add(new KONTODataTable(dataSet.Tables["KONTO"]));
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

        [DebuggerNonUserCode]
        public override DataSet Clone()
        {
            dsKonto konto = (dsKonto) base.Clone();
            konto.InitVars();
            konto.SchemaSerializationMode = this.SchemaSerializationMode;
            return konto;
        }

        [DebuggerNonUserCode]
        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream w = new MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(w, null));
            w.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(w), null);
        }

        [DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            dsKonto konto = new dsKonto();
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = konto.Namespace
            };
            sequence.Items.Add(item);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = konto.GetSchemaSerializable();
            if (xs.Contains(schemaSerializable.TargetNamespace))
            {
                MemoryStream stream = new MemoryStream();
                MemoryStream stream2 = new MemoryStream();
                try
                {
                    XmlSchema current = null;
                    schemaSerializable.Write(stream);
                    IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (XmlSchema) enumerator.Current;
                        stream2.SetLength(0L);
                        current.Write(stream2);
                        if (stream.Length == stream2.Length)
                        {
                            stream.Position = 0L;
                            stream2.Position = 0L;
                            while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                            {
                            }
                            if (stream.Position == stream.Length)
                            {
                                return type2;
                            }
                        }
                    }
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    if (stream2 != null)
                    {
                        stream2.Close();
                    }
                }
            }
            xs.Add(schemaSerializable);
            return type2;
        }

        [DebuggerNonUserCode]
        private void InitClass()
        {
            this.DataSetName = "dsKonto";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/dsKonto.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableKONTO = new KONTODataTable();
            base.Tables.Add(this.tableKONTO);
        }

        [DebuggerNonUserCode]
        protected override void InitializeDerivedDataSet()
        {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        [DebuggerNonUserCode]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        [DebuggerNonUserCode]
        internal void InitVars(bool initTable)
        {
            this.tableKONTO = (KONTODataTable) base.Tables["KONTO"];
            if (initTable && (this.tableKONTO != null))
            {
                this.tableKONTO.InitVars();
            }
        }

        [DebuggerNonUserCode]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["KONTO"] != null)
                {
                    base.Tables.Add(new KONTODataTable(dataSet.Tables["KONTO"]));
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
                this.ReadXml(reader);
                this.InitVars();
            }
        }

        [DebuggerNonUserCode]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        [DebuggerNonUserCode]
        private bool ShouldSerializeKONTO()
        {
            return false;
        }

        [DebuggerNonUserCode]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [DebuggerNonUserCode]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DebuggerNonUserCode, Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KONTODataTable KONTO
        {
            get
            {
                return this.tableKONTO;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode]
        public new DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DebuggerNonUserCode, Browsable(true)]
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

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedTableSchema")]
        public class KONTODataTable : TypedTableBase<dsKonto.KONTORow>
        {
            private DataColumn columnKONTO;

            public event dsKonto.KONTORowChangeEventHandler KONTORowChanged;

            public event dsKonto.KONTORowChangeEventHandler KONTORowChanging;

            public event dsKonto.KONTORowChangeEventHandler KONTORowDeleted;

            public event dsKonto.KONTORowChangeEventHandler KONTORowDeleting;

            [DebuggerNonUserCode]
            public KONTODataTable()
            {
                this.TableName = "KONTO";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal KONTODataTable(DataTable table)
            {
                this.TableName = table.TableName;
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
            }

            [DebuggerNonUserCode]
            protected KONTODataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddKONTORow(dsKonto.KONTORow row)
            {
                this.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public dsKonto.KONTORow AddKONTORow(string KONTO)
            {
                dsKonto.KONTORow row = (dsKonto.KONTORow) this.NewRow();
                row.ItemArray = new object[] { KONTO };
                this.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsKonto.KONTODataTable table = (dsKonto.KONTODataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsKonto.KONTODataTable();
            }

            [DebuggerNonUserCode]
            public dsKonto.KONTORow FindByKONTO(string KONTO)
            {
                return (dsKonto.KONTORow) this.Rows.Find(new object[] { KONTO });
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsKonto.KONTORow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsKonto konto = new dsKonto();
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
                    FixedValue = konto.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "KONTODataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                XmlSchema schemaSerializable = konto.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type2;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type2;
            }

            [DebuggerNonUserCode]
            private void InitClass()
            {
                this.columnKONTO = new DataColumn("KONTO", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnKONTO);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnKONTO }, true));
                this.columnKONTO.AllowDBNull = false;
                this.columnKONTO.Unique = true;
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnKONTO = base.Columns["KONTO"];
            }

            [DebuggerNonUserCode]
            public dsKonto.KONTORow NewKONTORow()
            {
                return (dsKonto.KONTORow) this.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsKonto.KONTORow(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.KONTORowChanged != null)
                {
                    dsKonto.KONTORowChangeEventHandler kONTORowChangedEvent = this.KONTORowChanged;
                    if (kONTORowChangedEvent != null)
                    {
                        kONTORowChangedEvent(this, new dsKonto.KONTORowChangeEvent((dsKonto.KONTORow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.KONTORowChanging != null)
                {
                    dsKonto.KONTORowChangeEventHandler kONTORowChangingEvent = this.KONTORowChanging;
                    if (kONTORowChangingEvent != null)
                    {
                        kONTORowChangingEvent(this, new dsKonto.KONTORowChangeEvent((dsKonto.KONTORow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.KONTORowDeleted != null)
                {
                    dsKonto.KONTORowChangeEventHandler kONTORowDeletedEvent = this.KONTORowDeleted;
                    if (kONTORowDeletedEvent != null)
                    {
                        kONTORowDeletedEvent(this, new dsKonto.KONTORowChangeEvent((dsKonto.KONTORow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.KONTORowDeleting != null)
                {
                    dsKonto.KONTORowChangeEventHandler kONTORowDeletingEvent = this.KONTORowDeleting;
                    if (kONTORowDeletingEvent != null)
                    {
                        kONTORowDeletingEvent(this, new dsKonto.KONTORowChangeEvent((dsKonto.KONTORow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            public void RemoveKONTORow(dsKonto.KONTORow row)
            {
                this.Rows.Remove(row);
            }

            [DebuggerNonUserCode, Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            [DebuggerNonUserCode]
            public dsKonto.KONTORow this[int index]
            {
                get
                {
                    return (dsKonto.KONTORow) this.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn KONTOColumn
            {
                get
                {
                    return this.columnKONTO;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class KONTORow : DataRow
        {
            private dsKonto.KONTODataTable tableKONTO;

            [DebuggerNonUserCode]
            internal KONTORow(DataRowBuilder rb) : base(rb)
            {
                this.tableKONTO = (dsKonto.KONTODataTable) this.Table;
            }

            [DebuggerNonUserCode]
            public string KONTO
            {
                get
                {
                    return Conversions.ToString(this[this.tableKONTO.KONTOColumn]);
                }
                set
                {
                    this[this.tableKONTO.KONTOColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class KONTORowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsKonto.KONTORow eventRow;

            [DebuggerNonUserCode]
            public KONTORowChangeEvent(dsKonto.KONTORow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode]
            public dsKonto.KONTORow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void KONTORowChangeEventHandler(object sender, dsKonto.KONTORowChangeEvent e);
    }
}

