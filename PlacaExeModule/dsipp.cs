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

[Serializable, HelpKeyword("vs.data.DataSet"), DesignerCategory("code"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlRoot("dsipp"), XmlSchemaProvider("GetTypedDataSetSchema"), ToolboxItem(true)]
public class dsipp : DataSet
{
    private System.Data.SchemaSerializationMode _schemaSerializationMode;
    private porezDataTable tableporez;

    [DebuggerNonUserCode]
    public dsipp()
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
    protected dsipp(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["porez"] != null)
                {
                    base.Tables.Add(new porezDataTable(dataSet.Tables["porez"]));
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
        dsipp dsipp = (dsipp) base.Clone();
        dsipp.InitVars();
        dsipp.SchemaSerializationMode = this.SchemaSerializationMode;
        return dsipp;
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
        dsipp dsipp = new dsipp();
        XmlSchemaComplexType type2 = new XmlSchemaComplexType();
        XmlSchemaSequence sequence = new XmlSchemaSequence();
        XmlSchemaAny item = new XmlSchemaAny {
            Namespace = dsipp.Namespace
        };
        sequence.Items.Add(item);
        type2.Particle = sequence;
        XmlSchema schemaSerializable = dsipp.GetSchemaSerializable();
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
        this.DataSetName = "dsipp";
        this.Prefix = "";
        this.Namespace = "http://tempuri.org/dsipp.xsd";
        this.EnforceConstraints = true;
        this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        this.tableporez = new porezDataTable();
        base.Tables.Add(this.tableporez);
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
        this.tableporez = (porezDataTable) base.Tables["porez"];
        if (initTable && (this.tableporez != null))
        {
            this.tableporez.InitVars();
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
            if (dataSet.Tables["porez"] != null)
            {
                base.Tables.Add(new porezDataTable(dataSet.Tables["porez"]));
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
    private bool ShouldSerializeporez()
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

    [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
    public porezDataTable porez
    {
        get
        {
            return this.tableporez;
        }
    }

    [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataRelationCollection Relations
    {
        get
        {
            return base.Relations;
        }
    }

    [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DebuggerNonUserCode]
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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode]
    public new DataTableCollection Tables
    {
        get
        {
            return base.Tables;
        }
    }

    [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedTableSchema")]
    public class porezDataTable : TypedTableBase<dsipp.porezRow>
    {
        private DataColumn columnbroj;
        private DataColumn columnosnovica;
        private DataColumn columnporez;
        private DataColumn columnrbr;
        private DataColumn columnvrsta;

        public event dsipp.porezRowChangeEventHandler porezRowChanged;

        public event dsipp.porezRowChangeEventHandler porezRowChanging;

        public event dsipp.porezRowChangeEventHandler porezRowDeleted;

        public event dsipp.porezRowChangeEventHandler porezRowDeleting;

        [DebuggerNonUserCode]
        public porezDataTable()
        {
            this.TableName = "porez";
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        [DebuggerNonUserCode]
        internal porezDataTable(DataTable table)
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
        protected porezDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.InitVars();
        }

        [DebuggerNonUserCode]
        public void AddporezRow(dsipp.porezRow row)
        {
            this.Rows.Add(row);
        }

        [DebuggerNonUserCode]
        public dsipp.porezRow AddporezRow(short rbr, string vrsta, short broj, decimal osnovica, decimal porez)
        {
            dsipp.porezRow row = (dsipp.porezRow) this.NewRow();
            row.ItemArray = new object[] { rbr, vrsta, broj, osnovica, porez };
            this.Rows.Add(row);
            return row;
        }

        [DebuggerNonUserCode]
        public override DataTable Clone()
        {
            dsipp.porezDataTable table = (dsipp.porezDataTable) base.Clone();
            table.InitVars();
            return table;
        }

        [DebuggerNonUserCode]
        protected override DataTable CreateInstance()
        {
            return new dsipp.porezDataTable();
        }

        [DebuggerNonUserCode]
        public dsipp.porezRow FindByrbr(short rbr)
        {
            return (dsipp.porezRow) this.Rows.Find(new object[] { rbr });
        }

        [DebuggerNonUserCode]
        protected override Type GetRowType()
        {
            return typeof(dsipp.porezRow);
        }

        [DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
        {
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            dsipp dsipp = new dsipp();
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
                FixedValue = dsipp.Namespace
            };
            type2.Attributes.Add(attribute);
            XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                Name = "tableTypeName",
                FixedValue = "porezDataTable"
            };
            type2.Attributes.Add(attribute2);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = dsipp.GetSchemaSerializable();
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
            this.columnrbr = new DataColumn("rbr", typeof(short), null, MappingType.Element);
            base.Columns.Add(this.columnrbr);
            this.columnvrsta = new DataColumn("vrsta", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnvrsta);
            this.columnbroj = new DataColumn("broj", typeof(short), null, MappingType.Element);
            base.Columns.Add(this.columnbroj);
            this.columnosnovica = new DataColumn("osnovica", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnosnovica);
            this.columnporez = new DataColumn("porez", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnporez);
            this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnrbr }, true));
            this.columnrbr.AllowDBNull = false;
            this.columnrbr.Unique = true;
        }

        [DebuggerNonUserCode]
        internal void InitVars()
        {
            this.columnrbr = base.Columns["rbr"];
            this.columnvrsta = base.Columns["vrsta"];
            this.columnbroj = base.Columns["broj"];
            this.columnosnovica = base.Columns["osnovica"];
            this.columnporez = base.Columns["porez"];
        }

        [DebuggerNonUserCode]
        public dsipp.porezRow NewporezRow()
        {
            return (dsipp.porezRow) this.NewRow();
        }

        [DebuggerNonUserCode]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new dsipp.porezRow(builder);
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            if (this.porezRowChanged != null)
            {
                dsipp.porezRowChangeEventHandler porezRowChangedEvent = this.porezRowChanged;
                if (porezRowChangedEvent != null)
                {
                    porezRowChangedEvent(this, new dsipp.porezRowChangeEvent((dsipp.porezRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
            if (this.porezRowChanging != null)
            {
                dsipp.porezRowChangeEventHandler porezRowChangingEvent = this.porezRowChanging;
                if (porezRowChangingEvent != null)
                {
                    porezRowChangingEvent(this, new dsipp.porezRowChangeEvent((dsipp.porezRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);
            if (this.porezRowDeleted != null)
            {
                dsipp.porezRowChangeEventHandler porezRowDeletedEvent = this.porezRowDeleted;
                if (porezRowDeletedEvent != null)
                {
                    porezRowDeletedEvent(this, new dsipp.porezRowChangeEvent((dsipp.porezRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {
            base.OnRowDeleting(e);
            if (this.porezRowDeleting != null)
            {
                dsipp.porezRowChangeEventHandler porezRowDeletingEvent = this.porezRowDeleting;
                if (porezRowDeletingEvent != null)
                {
                    porezRowDeletingEvent(this, new dsipp.porezRowChangeEvent((dsipp.porezRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        public void RemoveporezRow(dsipp.porezRow row)
        {
            this.Rows.Remove(row);
        }

        [DebuggerNonUserCode]
        public DataColumn brojColumn
        {
            get
            {
                return this.columnbroj;
            }
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
        public dsipp.porezRow this[int index]
        {
            get
            {
                return (dsipp.porezRow) this.Rows[index];
            }
        }

        [DebuggerNonUserCode]
        public DataColumn osnovicaColumn
        {
            get
            {
                return this.columnosnovica;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn porezColumn
        {
            get
            {
                return this.columnporez;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn rbrColumn
        {
            get
            {
                return this.columnrbr;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn vrstaColumn
        {
            get
            {
                return this.columnvrsta;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class porezRow : DataRow
    {
        private dsipp.porezDataTable tableporez;

        [DebuggerNonUserCode]
        internal porezRow(DataRowBuilder rb) : base(rb)
        {
            this.tableporez = (dsipp.porezDataTable) this.Table;
        }

        [DebuggerNonUserCode]
        public bool IsbrojNull()
        {
            return this.IsNull(this.tableporez.brojColumn);
        }

        [DebuggerNonUserCode]
        public bool IsosnovicaNull()
        {
            return this.IsNull(this.tableporez.osnovicaColumn);
        }

        [DebuggerNonUserCode]
        public bool IsporezNull()
        {
            return this.IsNull(this.tableporez.porezColumn);
        }

        [DebuggerNonUserCode]
        public bool IsvrstaNull()
        {
            return this.IsNull(this.tableporez.vrstaColumn);
        }

        [DebuggerNonUserCode]
        public void SetbrojNull()
        {
            this[this.tableporez.brojColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetosnovicaNull()
        {
            this[this.tableporez.osnovicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetporezNull()
        {
            this[this.tableporez.porezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetvrstaNull()
        {
            this[this.tableporez.vrstaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public short broj
        {
            get
            {
                short num = 0;
                try
                {
                    num = Conversions.ToShort(this[this.tableporez.brojColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'broj' in table 'porez' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableporez.brojColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal osnovica
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableporez.osnovicaColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'osnovica' in table 'porez' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableporez.osnovicaColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal porez
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableporez.porezColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'porez' in table 'porez' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableporez.porezColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public short rbr
        {
            get
            {
                return Conversions.ToShort(this[this.tableporez.rbrColumn]);
            }
            set
            {
                this[this.tableporez.rbrColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string vrsta
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tableporez.vrstaColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'vrsta' in table 'porez' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tableporez.vrstaColumn] = value;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class porezRowChangeEvent : EventArgs
    {
        private DataRowAction eventAction;
        private dsipp.porezRow eventRow;

        [DebuggerNonUserCode]
        public porezRowChangeEvent(dsipp.porezRow row, DataRowAction action)
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
        public dsipp.porezRow Row
        {
            get
            {
                return this.eventRow;
            }
        }
    }

    public delegate void porezRowChangeEventHandler(object sender, dsipp.porezRowChangeEvent e);
}

