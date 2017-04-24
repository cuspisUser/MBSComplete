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

[Serializable, DesignerCategory("code"), ToolboxItem(true), XmlSchemaProvider("GetTypedDataSetSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), HelpKeyword("vs.data.DataSet"), XmlRoot("Baze")]
public class Baze : DataSet
{
    private System.Data.SchemaSerializationMode _schemaSerializationMode;
    private BazeDataTable tableBaze;
    private PodaciDataTable tablePodaci;

    [DebuggerNonUserCode]
    public Baze()
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
    protected Baze(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["Podaci"] != null)
                {
                    base.Tables.Add(new PodaciDataTable(dataSet.Tables["Podaci"]));
                }
                if (dataSet.Tables["Baze"] != null)
                {
                    base.Tables.Add(new BazeDataTable(dataSet.Tables["Baze"]));
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
        Baze baze = (Baze) base.Clone();
        baze.InitVars();
        baze.SchemaSerializationMode = this.SchemaSerializationMode;
        return baze;
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
        Baze baze = new Baze();
        XmlSchemaComplexType type2 = new XmlSchemaComplexType();
        XmlSchemaSequence sequence = new XmlSchemaSequence();
        XmlSchemaAny item = new XmlSchemaAny {
            Namespace = baze.Namespace
        };
        sequence.Items.Add(item);
        type2.Particle = sequence;
        XmlSchema schemaSerializable = baze.GetSchemaSerializable();
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
        this.DataSetName = "Baze";
        this.Prefix = "";
        this.Namespace = "http://tempuri.org/Baze.xsd";
        this.EnforceConstraints = true;
        this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        this.tablePodaci = new PodaciDataTable();
        base.Tables.Add(this.tablePodaci);
        this.tableBaze = new BazeDataTable();
        base.Tables.Add(this.tableBaze);
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
        this.tablePodaci = (PodaciDataTable) base.Tables["Podaci"];
        if (initTable && (this.tablePodaci != null))
        {
            this.tablePodaci.InitVars();
        }
        this.tableBaze = (BazeDataTable) base.Tables["Baze"];
        if (initTable && (this.tableBaze != null))
        {
            this.tableBaze.InitVars();
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
            if (dataSet.Tables["Podaci"] != null)
            {
                base.Tables.Add(new PodaciDataTable(dataSet.Tables["Podaci"]));
            }
            if (dataSet.Tables["Baze"] != null)
            {
                base.Tables.Add(new BazeDataTable(dataSet.Tables["Baze"]));
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
    private bool ShouldSerialize_Baze()
    {
        return false;
    }

    [DebuggerNonUserCode]
    private bool ShouldSerializePodaci()
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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), DebuggerNonUserCode]
    public BazeDataTable _Baze
    {
        get
        {
            return this.tableBaze;
        }
    }

    [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
    public PodaciDataTable Podaci
    {
        get
        {
            return this.tablePodaci;
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

    [Serializable, XmlSchemaProvider("GetTypedTableSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class BazeDataTable : TypedTableBase<Baze.BazeRow>
    {
        private DataColumn columnnazivbaze;

        public event Baze.BazeRowChangeEventHandler BazeRowChanged;

        public event Baze.BazeRowChangeEventHandler BazeRowChanging;

        public event Baze.BazeRowChangeEventHandler BazeRowDeleted;

        public event Baze.BazeRowChangeEventHandler BazeRowDeleting;

        [DebuggerNonUserCode]
        public BazeDataTable()
        {
            this.TableName = "Baze";
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        [DebuggerNonUserCode]
        internal BazeDataTable(DataTable table)
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
        protected BazeDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.InitVars();
        }

        [DebuggerNonUserCode]
        public void AddBazeRow(Baze.BazeRow row)
        {
            this.Rows.Add(row);
        }

        [DebuggerNonUserCode]
        public Baze.BazeRow AddBazeRow(string nazivbaze)
        {
            Baze.BazeRow row = (Baze.BazeRow) this.NewRow();
            row.ItemArray = new object[] { nazivbaze };
            this.Rows.Add(row);
            return row;
        }

        [DebuggerNonUserCode]
        public override DataTable Clone()
        {
            Baze.BazeDataTable table = (Baze.BazeDataTable) base.Clone();
            table.InitVars();
            return table;
        }

        [DebuggerNonUserCode]
        protected override DataTable CreateInstance()
        {
            return new Baze.BazeDataTable();
        }

        [DebuggerNonUserCode]
        public Baze.BazeRow FindBynazivbaze(string nazivbaze)
        {
            return (Baze.BazeRow) this.Rows.Find(new object[] { nazivbaze });
        }

        [DebuggerNonUserCode]
        protected override Type GetRowType()
        {
            return typeof(Baze.BazeRow);
        }

        [DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
        {
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            Baze baze = new Baze();
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
                FixedValue = baze.Namespace
            };
            type2.Attributes.Add(attribute);
            XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                Name = "tableTypeName",
                FixedValue = "BazeDataTable"
            };
            type2.Attributes.Add(attribute2);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = baze.GetSchemaSerializable();
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
            this.columnnazivbaze = new DataColumn("nazivbaze", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnnazivbaze);
            this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnnazivbaze }, true));
            this.columnnazivbaze.AllowDBNull = false;
            this.columnnazivbaze.Unique = true;
            this.ExtendedProperties.Add("Generator_TablePropName", "_Baze");
            this.ExtendedProperties.Add("Generator_UserTableName", "Baze");
        }

        [DebuggerNonUserCode]
        internal void InitVars()
        {
            this.columnnazivbaze = base.Columns["nazivbaze"];
        }

        [DebuggerNonUserCode]
        public Baze.BazeRow NewBazeRow()
        {
            return (Baze.BazeRow) this.NewRow();
        }

        [DebuggerNonUserCode]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new Baze.BazeRow(builder);
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            if (this.BazeRowChanged != null)
            {
                Baze.BazeRowChangeEventHandler bazeRowChangedEvent = this.BazeRowChanged;
                if (bazeRowChangedEvent != null)
                {
                    bazeRowChangedEvent(this, new Baze.BazeRowChangeEvent((Baze.BazeRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
            if (this.BazeRowChanging != null)
            {
                Baze.BazeRowChangeEventHandler bazeRowChangingEvent = this.BazeRowChanging;
                if (bazeRowChangingEvent != null)
                {
                    bazeRowChangingEvent(this, new Baze.BazeRowChangeEvent((Baze.BazeRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);
            if (this.BazeRowDeleted != null)
            {
                Baze.BazeRowChangeEventHandler bazeRowDeletedEvent = this.BazeRowDeleted;
                if (bazeRowDeletedEvent != null)
                {
                    bazeRowDeletedEvent(this, new Baze.BazeRowChangeEvent((Baze.BazeRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {
            base.OnRowDeleting(e);
            if (this.BazeRowDeleting != null)
            {
                Baze.BazeRowChangeEventHandler bazeRowDeletingEvent = this.BazeRowDeleting;
                if (bazeRowDeletingEvent != null)
                {
                    bazeRowDeletingEvent(this, new Baze.BazeRowChangeEvent((Baze.BazeRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        public void RemoveBazeRow(Baze.BazeRow row)
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
        public Baze.BazeRow this[int index]
        {
            get
            {
                return (Baze.BazeRow) this.Rows[index];
            }
        }

        [DebuggerNonUserCode]
        public DataColumn nazivbazeColumn
        {
            get
            {
                return this.columnnazivbaze;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class BazeRow : DataRow
    {
        private Baze.BazeDataTable tableBaze;

        [DebuggerNonUserCode]
        internal BazeRow(DataRowBuilder rb) : base(rb)
        {
            this.tableBaze = (Baze.BazeDataTable) this.Table;
        }

        [DebuggerNonUserCode]
        public string nazivbaze
        {
            get
            {
                return Conversions.ToString(this[this.tableBaze.nazivbazeColumn]);
            }
            set
            {
                this[this.tableBaze.nazivbazeColumn] = value;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class BazeRowChangeEvent : EventArgs
    {
        private DataRowAction eventAction;
        private Baze.BazeRow eventRow;

        [DebuggerNonUserCode]
        public BazeRowChangeEvent(Baze.BazeRow row, DataRowAction action)
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
        public Baze.BazeRow Row
        {
            get
            {
                return this.eventRow;
            }
        }
    }

    public delegate void BazeRowChangeEventHandler(object sender, Baze.BazeRowChangeEvent e);

    [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedTableSchema")]
    public class PodaciDataTable : TypedTableBase<Baze.PodaciRow>
    {
        private DataColumn columnizracunatibruto;
        private DataColumn columnnazivbaze;
        private DataColumn columnoo;
        private DataColumn columnpb;
        private DataColumn columnpn;
        private DataColumn columnPREZIMEIIME;
        private DataColumn columnprirez;
        private DataColumn columntrazenineto;

        public event Baze.PodaciRowChangeEventHandler PodaciRowChanged;

        public event Baze.PodaciRowChangeEventHandler PodaciRowChanging;

        public event Baze.PodaciRowChangeEventHandler PodaciRowDeleted;

        public event Baze.PodaciRowChangeEventHandler PodaciRowDeleting;

        [DebuggerNonUserCode]
        public PodaciDataTable()
        {
            this.TableName = "Podaci";
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        [DebuggerNonUserCode]
        internal PodaciDataTable(DataTable table)
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
        protected PodaciDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.InitVars();
        }

        [DebuggerNonUserCode]
        public void AddPodaciRow(Baze.PodaciRow row)
        {
            this.Rows.Add(row);
        }

        [DebuggerNonUserCode]
        public Baze.PodaciRow AddPodaciRow(decimal pb, decimal pn, decimal oo, decimal prirez, decimal trazenineto, decimal izracunatibruto, string PREZIMEIIME, string nazivbaze)
        {
            Baze.PodaciRow row = (Baze.PodaciRow) this.NewRow();
            row.ItemArray = new object[] { pb, pn, oo, prirez, trazenineto, izracunatibruto, PREZIMEIIME, nazivbaze };
            this.Rows.Add(row);
            return row;
        }

        [DebuggerNonUserCode]
        public override DataTable Clone()
        {
            Baze.PodaciDataTable table = (Baze.PodaciDataTable) base.Clone();
            table.InitVars();
            return table;
        }

        [DebuggerNonUserCode]
        protected override DataTable CreateInstance()
        {
            return new Baze.PodaciDataTable();
        }

        [DebuggerNonUserCode]
        public Baze.PodaciRow FindBynazivbaze(string nazivbaze)
        {
            return (Baze.PodaciRow) this.Rows.Find(new object[] { nazivbaze });
        }

        [DebuggerNonUserCode]
        protected override Type GetRowType()
        {
            return typeof(Baze.PodaciRow);
        }

        [DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
        {
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            Baze baze = new Baze();
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
                FixedValue = baze.Namespace
            };
            type2.Attributes.Add(attribute);
            XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                Name = "tableTypeName",
                FixedValue = "PodaciDataTable"
            };
            type2.Attributes.Add(attribute2);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = baze.GetSchemaSerializable();
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
            this.columnpb = new DataColumn("pb", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnpb);
            this.columnpn = new DataColumn("pn", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnpn);
            this.columnoo = new DataColumn("oo", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnoo);
            this.columnprirez = new DataColumn("prirez", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnprirez);
            this.columntrazenineto = new DataColumn("trazenineto", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columntrazenineto);
            this.columnizracunatibruto = new DataColumn("izracunatibruto", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnizracunatibruto);
            this.columnPREZIMEIIME = new DataColumn("PREZIMEIIME", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnPREZIMEIIME);
            this.columnnazivbaze = new DataColumn("nazivbaze", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnnazivbaze);
            this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnnazivbaze }, true));
            this.columnnazivbaze.AllowDBNull = false;
            this.columnnazivbaze.Unique = true;
        }

        [DebuggerNonUserCode]
        internal void InitVars()
        {
            this.columnpb = base.Columns["pb"];
            this.columnpn = base.Columns["pn"];
            this.columnoo = base.Columns["oo"];
            this.columnprirez = base.Columns["prirez"];
            this.columntrazenineto = base.Columns["trazenineto"];
            this.columnizracunatibruto = base.Columns["izracunatibruto"];
            this.columnPREZIMEIIME = base.Columns["PREZIMEIIME"];
            this.columnnazivbaze = base.Columns["nazivbaze"];
        }

        [DebuggerNonUserCode]
        public Baze.PodaciRow NewPodaciRow()
        {
            return (Baze.PodaciRow) this.NewRow();
        }

        [DebuggerNonUserCode]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new Baze.PodaciRow(builder);
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            if (this.PodaciRowChanged != null)
            {
                Baze.PodaciRowChangeEventHandler podaciRowChangedEvent = this.PodaciRowChanged;
                if (podaciRowChangedEvent != null)
                {
                    podaciRowChangedEvent(this, new Baze.PodaciRowChangeEvent((Baze.PodaciRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
            if (this.PodaciRowChanging != null)
            {
                Baze.PodaciRowChangeEventHandler podaciRowChangingEvent = this.PodaciRowChanging;
                if (podaciRowChangingEvent != null)
                {
                    podaciRowChangingEvent(this, new Baze.PodaciRowChangeEvent((Baze.PodaciRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);
            if (this.PodaciRowDeleted != null)
            {
                Baze.PodaciRowChangeEventHandler podaciRowDeletedEvent = this.PodaciRowDeleted;
                if (podaciRowDeletedEvent != null)
                {
                    podaciRowDeletedEvent(this, new Baze.PodaciRowChangeEvent((Baze.PodaciRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {
            base.OnRowDeleting(e);
            if (this.PodaciRowDeleting != null)
            {
                Baze.PodaciRowChangeEventHandler podaciRowDeletingEvent = this.PodaciRowDeleting;
                if (podaciRowDeletingEvent != null)
                {
                    podaciRowDeletingEvent(this, new Baze.PodaciRowChangeEvent((Baze.PodaciRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        public void RemovePodaciRow(Baze.PodaciRow row)
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
        public Baze.PodaciRow this[int index]
        {
            get
            {
                return (Baze.PodaciRow) this.Rows[index];
            }
        }

        [DebuggerNonUserCode]
        public DataColumn izracunatibrutoColumn
        {
            get
            {
                return this.columnizracunatibruto;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn nazivbazeColumn
        {
            get
            {
                return this.columnnazivbaze;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn ooColumn
        {
            get
            {
                return this.columnoo;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn pbColumn
        {
            get
            {
                return this.columnpb;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn pnColumn
        {
            get
            {
                return this.columnpn;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn PREZIMEIIMEColumn
        {
            get
            {
                return this.columnPREZIMEIIME;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn prirezColumn
        {
            get
            {
                return this.columnprirez;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn trazeninetoColumn
        {
            get
            {
                return this.columntrazenineto;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class PodaciRow : DataRow
    {
        private Baze.PodaciDataTable tablePodaci;

        [DebuggerNonUserCode]
        internal PodaciRow(DataRowBuilder rb) : base(rb)
        {
            this.tablePodaci = (Baze.PodaciDataTable) this.Table;
        }

        [DebuggerNonUserCode]
        public bool IsizracunatibrutoNull()
        {
            return this.IsNull(this.tablePodaci.izracunatibrutoColumn);
        }

        [DebuggerNonUserCode]
        public bool IsooNull()
        {
            return this.IsNull(this.tablePodaci.ooColumn);
        }

        [DebuggerNonUserCode]
        public bool IspbNull()
        {
            return this.IsNull(this.tablePodaci.pbColumn);
        }

        [DebuggerNonUserCode]
        public bool IspnNull()
        {
            return this.IsNull(this.tablePodaci.pnColumn);
        }

        [DebuggerNonUserCode]
        public bool IsPREZIMEIIMENull()
        {
            return this.IsNull(this.tablePodaci.PREZIMEIIMEColumn);
        }

        [DebuggerNonUserCode]
        public bool IsprirezNull()
        {
            return this.IsNull(this.tablePodaci.prirezColumn);
        }

        [DebuggerNonUserCode]
        public bool IstrazeninetoNull()
        {
            return this.IsNull(this.tablePodaci.trazeninetoColumn);
        }

        [DebuggerNonUserCode]
        public void SetizracunatibrutoNull()
        {
            this[this.tablePodaci.izracunatibrutoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetooNull()
        {
            this[this.tablePodaci.ooColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetpbNull()
        {
            this[this.tablePodaci.pbColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetpnNull()
        {
            this[this.tablePodaci.pnColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetPREZIMEIIMENull()
        {
            this[this.tablePodaci.PREZIMEIIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetprirezNull()
        {
            this[this.tablePodaci.prirezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SettrazeninetoNull()
        {
            this[this.tablePodaci.trazeninetoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public decimal izracunatibruto
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tablePodaci.izracunatibrutoColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'izracunatibruto' in table 'Podaci' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tablePodaci.izracunatibrutoColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string nazivbaze
        {
            get
            {
                return Conversions.ToString(this[this.tablePodaci.nazivbazeColumn]);
            }
            set
            {
                this[this.tablePodaci.nazivbazeColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal oo
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tablePodaci.ooColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'oo' in table 'Podaci' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tablePodaci.ooColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal pb
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tablePodaci.pbColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'pb' in table 'Podaci' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tablePodaci.pbColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal pn
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tablePodaci.pnColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'pn' in table 'Podaci' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tablePodaci.pnColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string PREZIMEIIME
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tablePodaci.PREZIMEIIMEColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'PREZIMEIIME' in table 'Podaci' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tablePodaci.PREZIMEIIMEColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal prirez
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tablePodaci.prirezColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'prirez' in table 'Podaci' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tablePodaci.prirezColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal trazenineto
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tablePodaci.trazeninetoColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'trazenineto' in table 'Podaci' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tablePodaci.trazeninetoColumn] = value;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class PodaciRowChangeEvent : EventArgs
    {
        private DataRowAction eventAction;
        private Baze.PodaciRow eventRow;

        [DebuggerNonUserCode]
        public PodaciRowChangeEvent(Baze.PodaciRow row, DataRowAction action)
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
        public Baze.PodaciRow Row
        {
            get
            {
                return this.eventRow;
            }
        }
    }

    public delegate void PodaciRowChangeEventHandler(object sender, Baze.PodaciRowChangeEvent e);
}

