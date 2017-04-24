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

[Serializable, XmlSchemaProvider("GetTypedDataSetSchema"), HelpKeyword("vs.data.DataSet"), DesignerCategory("code"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlRoot("POPISPROMJENAKOEFICIJENATA"), ToolboxItem(true)]
public class POPISPROMJENAKOEFICIJENATA : DataSet
{
    private System.Data.SchemaSerializationMode _schemaSerializationMode;
    private DataTable1DataTable tableDataTable1;

    [DebuggerNonUserCode]
    public POPISPROMJENAKOEFICIJENATA()
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
    protected POPISPROMJENAKOEFICIJENATA(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["DataTable1"] != null)
                {
                    base.Tables.Add(new DataTable1DataTable(dataSet.Tables["DataTable1"]));
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
        POPISPROMJENAKOEFICIJENATA popispromjenakoeficijenata = (POPISPROMJENAKOEFICIJENATA) base.Clone();
        popispromjenakoeficijenata.InitVars();
        popispromjenakoeficijenata.SchemaSerializationMode = this.SchemaSerializationMode;
        return popispromjenakoeficijenata;
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
        POPISPROMJENAKOEFICIJENATA popispromjenakoeficijenata = new POPISPROMJENAKOEFICIJENATA();
        XmlSchemaComplexType type2 = new XmlSchemaComplexType();
        XmlSchemaSequence sequence = new XmlSchemaSequence();
        XmlSchemaAny item = new XmlSchemaAny {
            Namespace = popispromjenakoeficijenata.Namespace
        };
        sequence.Items.Add(item);
        type2.Particle = sequence;
        XmlSchema schemaSerializable = popispromjenakoeficijenata.GetSchemaSerializable();
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
        this.DataSetName = "POPISPROMJENAKOEFICIJENATA";
        this.Prefix = "";
        this.Namespace = "http://tempuri.org/POPISPROMJENAKOEFICIJENATA.xsd";
        this.EnforceConstraints = true;
        this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        this.tableDataTable1 = new DataTable1DataTable();
        base.Tables.Add(this.tableDataTable1);
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
        this.tableDataTable1 = (DataTable1DataTable) base.Tables["DataTable1"];
        if (initTable && (this.tableDataTable1 != null))
        {
            this.tableDataTable1.InitVars();
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
            if (dataSet.Tables["DataTable1"] != null)
            {
                base.Tables.Add(new DataTable1DataTable(dataSet.Tables["DataTable1"]));
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
    private bool ShouldSerializeDataTable1()
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
    public DataTable1DataTable DataTable1
    {
        get
        {
            return this.tableDataTable1;
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

    [Browsable(true), DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
    public class DataTable1DataTable : TypedTableBase<POPISPROMJENAKOEFICIJENATA.DataTable1Row>
    {
        private DataColumn columnoOBR;
        private DataColumn columnoURE;
        private DataColumn columnpOBR;
        private DataColumn columnPREZIMEIME;
        private DataColumn columnpURE;

        public event POPISPROMJENAKOEFICIJENATA.DataTable1RowChangeEventHandler DataTable1RowChanged;

        public event POPISPROMJENAKOEFICIJENATA.DataTable1RowChangeEventHandler DataTable1RowChanging;

        public event POPISPROMJENAKOEFICIJENATA.DataTable1RowChangeEventHandler DataTable1RowDeleted;

        public event POPISPROMJENAKOEFICIJENATA.DataTable1RowChangeEventHandler DataTable1RowDeleting;

        [DebuggerNonUserCode]
        public DataTable1DataTable()
        {
            this.TableName = "DataTable1";
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        [DebuggerNonUserCode]
        internal DataTable1DataTable(DataTable table)
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
        protected DataTable1DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.InitVars();
        }

        [DebuggerNonUserCode]
        public void AddDataTable1Row(POPISPROMJENAKOEFICIJENATA.DataTable1Row row)
        {
            this.Rows.Add(row);
        }

        [DebuggerNonUserCode]
        public POPISPROMJENAKOEFICIJENATA.DataTable1Row AddDataTable1Row(string PREZIMEIME, decimal pOBR, decimal pURE, decimal oOBR, decimal oURE)
        {
            POPISPROMJENAKOEFICIJENATA.DataTable1Row row = (POPISPROMJENAKOEFICIJENATA.DataTable1Row) this.NewRow();
            row.ItemArray = new object[] { PREZIMEIME, pOBR, pURE, oOBR, oURE };
            this.Rows.Add(row);
            return row;
        }

        [DebuggerNonUserCode]
        public override DataTable Clone()
        {
            POPISPROMJENAKOEFICIJENATA.DataTable1DataTable table = (POPISPROMJENAKOEFICIJENATA.DataTable1DataTable) base.Clone();
            table.InitVars();
            return table;
        }

        [DebuggerNonUserCode]
        protected override DataTable CreateInstance()
        {
            return new POPISPROMJENAKOEFICIJENATA.DataTable1DataTable();
        }

        [DebuggerNonUserCode]
        protected override Type GetRowType()
        {
            return typeof(POPISPROMJENAKOEFICIJENATA.DataTable1Row);
        }

        [DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
        {
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            POPISPROMJENAKOEFICIJENATA popispromjenakoeficijenata = new POPISPROMJENAKOEFICIJENATA();
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
                FixedValue = popispromjenakoeficijenata.Namespace
            };
            type2.Attributes.Add(attribute);
            XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                Name = "tableTypeName",
                FixedValue = "DataTable1DataTable"
            };
            type2.Attributes.Add(attribute2);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = popispromjenakoeficijenata.GetSchemaSerializable();
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
            this.columnPREZIMEIME = new DataColumn("PREZIMEIME", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnPREZIMEIME);
            this.columnpOBR = new DataColumn("pOBR", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnpOBR);
            this.columnpURE = new DataColumn("pURE", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnpURE);
            this.columnoOBR = new DataColumn("oOBR", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnoOBR);
            this.columnoURE = new DataColumn("oURE", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnoURE);
        }

        [DebuggerNonUserCode]
        internal void InitVars()
        {
            this.columnPREZIMEIME = base.Columns["PREZIMEIME"];
            this.columnpOBR = base.Columns["pOBR"];
            this.columnpURE = base.Columns["pURE"];
            this.columnoOBR = base.Columns["oOBR"];
            this.columnoURE = base.Columns["oURE"];
        }

        [DebuggerNonUserCode]
        public POPISPROMJENAKOEFICIJENATA.DataTable1Row NewDataTable1Row()
        {
            return (POPISPROMJENAKOEFICIJENATA.DataTable1Row) this.NewRow();
        }

        [DebuggerNonUserCode]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new POPISPROMJENAKOEFICIJENATA.DataTable1Row(builder);
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            if (this.DataTable1RowChanged != null)
            {
                POPISPROMJENAKOEFICIJENATA.DataTable1RowChangeEventHandler handler = this.DataTable1RowChanged;
                if (handler != null)
                {
                    handler(this, new POPISPROMJENAKOEFICIJENATA.DataTable1RowChangeEvent((POPISPROMJENAKOEFICIJENATA.DataTable1Row) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
            if (this.DataTable1RowChanging != null)
            {
                POPISPROMJENAKOEFICIJENATA.DataTable1RowChangeEventHandler handler = this.DataTable1RowChanging;
                if (handler != null)
                {
                    handler(this, new POPISPROMJENAKOEFICIJENATA.DataTable1RowChangeEvent((POPISPROMJENAKOEFICIJENATA.DataTable1Row) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);
            if (this.DataTable1RowDeleted != null)
            {
                POPISPROMJENAKOEFICIJENATA.DataTable1RowChangeEventHandler handler = this.DataTable1RowDeleted;
                if (handler != null)
                {
                    handler(this, new POPISPROMJENAKOEFICIJENATA.DataTable1RowChangeEvent((POPISPROMJENAKOEFICIJENATA.DataTable1Row) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {
            base.OnRowDeleting(e);
            if (this.DataTable1RowDeleting != null)
            {
                POPISPROMJENAKOEFICIJENATA.DataTable1RowChangeEventHandler handler = this.DataTable1RowDeleting;
                if (handler != null)
                {
                    handler(this, new POPISPROMJENAKOEFICIJENATA.DataTable1RowChangeEvent((POPISPROMJENAKOEFICIJENATA.DataTable1Row) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        public void RemoveDataTable1Row(POPISPROMJENAKOEFICIJENATA.DataTable1Row row)
        {
            this.Rows.Remove(row);
        }

        [Browsable(false), DebuggerNonUserCode]
        public int Count
        {
            get
            {
                return this.Rows.Count;
            }
        }

        [DebuggerNonUserCode]
        public POPISPROMJENAKOEFICIJENATA.DataTable1Row this[int index]
        {
            get
            {
                return (POPISPROMJENAKOEFICIJENATA.DataTable1Row) this.Rows[index];
            }
        }

        [DebuggerNonUserCode]
        public DataColumn oOBRColumn
        {
            get
            {
                return this.columnoOBR;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn oUREColumn
        {
            get
            {
                return this.columnoURE;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn pOBRColumn
        {
            get
            {
                return this.columnpOBR;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn PREZIMEIMEColumn
        {
            get
            {
                return this.columnPREZIMEIME;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn pUREColumn
        {
            get
            {
                return this.columnpURE;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class DataTable1Row : DataRow
    {
        private POPISPROMJENAKOEFICIJENATA.DataTable1DataTable tableDataTable1;

        [DebuggerNonUserCode]
        internal DataTable1Row(DataRowBuilder rb) : base(rb)
        {
            this.tableDataTable1 = (POPISPROMJENAKOEFICIJENATA.DataTable1DataTable) this.Table;
        }

        [DebuggerNonUserCode]
        public bool IsoOBRNull()
        {
            return this.IsNull(this.tableDataTable1.oOBRColumn);
        }

        [DebuggerNonUserCode]
        public bool IsoURENull()
        {
            return this.IsNull(this.tableDataTable1.oUREColumn);
        }

        [DebuggerNonUserCode]
        public bool IspOBRNull()
        {
            return this.IsNull(this.tableDataTable1.pOBRColumn);
        }

        [DebuggerNonUserCode]
        public bool IsPREZIMEIMENull()
        {
            return this.IsNull(this.tableDataTable1.PREZIMEIMEColumn);
        }

        [DebuggerNonUserCode]
        public bool IspURENull()
        {
            return this.IsNull(this.tableDataTable1.pUREColumn);
        }

        [DebuggerNonUserCode]
        public void SetoOBRNull()
        {
            this[this.tableDataTable1.oOBRColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetoURENull()
        {
            this[this.tableDataTable1.oUREColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetpOBRNull()
        {
            this[this.tableDataTable1.pOBRColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetPREZIMEIMENull()
        {
            this[this.tableDataTable1.PREZIMEIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetpURENull()
        {
            this[this.tableDataTable1.pUREColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public decimal oOBR
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableDataTable1.oOBRColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'oOBR' in table 'DataTable1' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableDataTable1.oOBRColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal oURE
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableDataTable1.oUREColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'oURE' in table 'DataTable1' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableDataTable1.oUREColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal pOBR
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableDataTable1.pOBRColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'pOBR' in table 'DataTable1' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableDataTable1.pOBRColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string PREZIMEIME
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tableDataTable1.PREZIMEIMEColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'PREZIMEIME' in table 'DataTable1' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tableDataTable1.PREZIMEIMEColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal pURE
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableDataTable1.pUREColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'pURE' in table 'DataTable1' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableDataTable1.pUREColumn] = value;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class DataTable1RowChangeEvent : EventArgs
    {
        private DataRowAction eventAction;
        private POPISPROMJENAKOEFICIJENATA.DataTable1Row eventRow;

        [DebuggerNonUserCode]
        public DataTable1RowChangeEvent(POPISPROMJENAKOEFICIJENATA.DataTable1Row row, DataRowAction action)
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
        public POPISPROMJENAKOEFICIJENATA.DataTable1Row Row
        {
            get
            {
                return this.eventRow;
            }
        }
    }

    public delegate void DataTable1RowChangeEventHandler(object sender, POPISPROMJENAKOEFICIJENATA.DataTable1RowChangeEvent e);
}

