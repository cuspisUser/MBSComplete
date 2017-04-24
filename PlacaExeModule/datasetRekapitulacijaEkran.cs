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

[Serializable, XmlSchemaProvider("GetTypedDataSetSchema"), DesignerCategory("code"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlRoot("datasetRekapitulacijaEkran"), ToolboxItem(true), HelpKeyword("vs.data.DataSet")]
public class datasetRekapitulacijaEkran : DataSet
{
    private System.Data.SchemaSerializationMode _schemaSerializationMode;
    private dtRekapDataTable tabledtRekap;

    [DebuggerNonUserCode]
    public datasetRekapitulacijaEkran()
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
    protected datasetRekapitulacijaEkran(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["dtRekap"] != null)
                {
                    base.Tables.Add(new dtRekapDataTable(dataSet.Tables["dtRekap"]));
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
        datasetRekapitulacijaEkran ekran = (datasetRekapitulacijaEkran) base.Clone();
        ekran.InitVars();
        ekran.SchemaSerializationMode = this.SchemaSerializationMode;
        return ekran;
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
        datasetRekapitulacijaEkran ekran = new datasetRekapitulacijaEkran();
        XmlSchemaComplexType type2 = new XmlSchemaComplexType();
        XmlSchemaSequence sequence = new XmlSchemaSequence();
        XmlSchemaAny item = new XmlSchemaAny {
            Namespace = ekran.Namespace
        };
        sequence.Items.Add(item);
        type2.Particle = sequence;
        XmlSchema schemaSerializable = ekran.GetSchemaSerializable();
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
        this.DataSetName = "datasetRekapitulacijaEkran";
        this.Prefix = "";
        this.Namespace = "http://tempuri.org/datasetRekapitulacijaEkran.xsd";
        this.EnforceConstraints = true;
        this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        this.tabledtRekap = new dtRekapDataTable();
        base.Tables.Add(this.tabledtRekap);
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
        this.tabledtRekap = (dtRekapDataTable) base.Tables["dtRekap"];
        if (initTable && (this.tabledtRekap != null))
        {
            this.tabledtRekap.InitVars();
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
            if (dataSet.Tables["dtRekap"] != null)
            {
                base.Tables.Add(new dtRekapDataTable(dataSet.Tables["dtRekap"]));
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
    private bool ShouldSerializedtRekap()
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

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode]
    public dtRekapDataTable dtRekap
    {
        get
        {
            return this.tabledtRekap;
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

    [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true)]
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
    public class dtRekapDataTable : TypedTableBase<datasetRekapitulacijaEkran.dtRekapRow>
    {
        private DataColumn columnBROJSATI;
        private DataColumn columndo;
        private DataColumn columnIznos;
        private DataColumn columnod;
        private DataColumn columnOpis;
        private DataColumn columnSIFRAELEMENTA;
        private DataColumn columnvrstaelementa;

        public event datasetRekapitulacijaEkran.dtRekapRowChangeEventHandler dtRekapRowChanged;

        public event datasetRekapitulacijaEkran.dtRekapRowChangeEventHandler dtRekapRowChanging;

        public event datasetRekapitulacijaEkran.dtRekapRowChangeEventHandler dtRekapRowDeleted;

        public event datasetRekapitulacijaEkran.dtRekapRowChangeEventHandler dtRekapRowDeleting;

        [DebuggerNonUserCode]
        public dtRekapDataTable()
        {
            this.TableName = "dtRekap";
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        [DebuggerNonUserCode]
        internal dtRekapDataTable(DataTable table)
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
        protected dtRekapDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.InitVars();
        }

        [DebuggerNonUserCode]
        public void AdddtRekapRow(datasetRekapitulacijaEkran.dtRekapRow row)
        {
            this.Rows.Add(row);
        }

        [DebuggerNonUserCode]
        public datasetRekapitulacijaEkran.dtRekapRow AdddtRekapRow(string Opis, string Iznos, short SIFRAELEMENTA, string vrstaelementa, decimal BROJSATI, DateTime od, DateTime _do)
        {
            datasetRekapitulacijaEkran.dtRekapRow row = (datasetRekapitulacijaEkran.dtRekapRow) this.NewRow();
            row.ItemArray = new object[] { Opis, Iznos, SIFRAELEMENTA, vrstaelementa, BROJSATI, od, _do };
            this.Rows.Add(row);
            return row;
        }

        [DebuggerNonUserCode]
        public override DataTable Clone()
        {
            datasetRekapitulacijaEkran.dtRekapDataTable table = (datasetRekapitulacijaEkran.dtRekapDataTable) base.Clone();
            table.InitVars();
            return table;
        }

        [DebuggerNonUserCode]
        protected override DataTable CreateInstance()
        {
            return new datasetRekapitulacijaEkran.dtRekapDataTable();
        }

        [DebuggerNonUserCode]
        protected override Type GetRowType()
        {
            return typeof(datasetRekapitulacijaEkran.dtRekapRow);
        }

        [DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
        {
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            datasetRekapitulacijaEkran ekran = new datasetRekapitulacijaEkran();
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
                FixedValue = ekran.Namespace
            };
            type2.Attributes.Add(attribute);
            XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                Name = "tableTypeName",
                FixedValue = "dtRekapDataTable"
            };
            type2.Attributes.Add(attribute2);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = ekran.GetSchemaSerializable();
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
            this.columnOpis = new DataColumn("Opis", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnOpis);
            this.columnIznos = new DataColumn("Iznos", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnIznos);
            this.columnSIFRAELEMENTA = new DataColumn("SIFRAELEMENTA", typeof(short), null, MappingType.Element);
            base.Columns.Add(this.columnSIFRAELEMENTA);
            this.columnvrstaelementa = new DataColumn("vrstaelementa", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnvrstaelementa);
            this.columnBROJSATI = new DataColumn("BROJSATI", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnBROJSATI);
            this.columnod = new DataColumn("od", typeof(DateTime), null, MappingType.Element);
            base.Columns.Add(this.columnod);
            this.columndo = new DataColumn("do", typeof(DateTime), null, MappingType.Element);
            this.columndo.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "doColumn");
            this.columndo.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columndo");
            this.columndo.ExtendedProperties.Add("Generator_UserColumnName", "do");
            base.Columns.Add(this.columndo);
        }

        [DebuggerNonUserCode]
        internal void InitVars()
        {
            this.columnOpis = base.Columns["Opis"];
            this.columnIznos = base.Columns["Iznos"];
            this.columnSIFRAELEMENTA = base.Columns["SIFRAELEMENTA"];
            this.columnvrstaelementa = base.Columns["vrstaelementa"];
            this.columnBROJSATI = base.Columns["BROJSATI"];
            this.columnod = base.Columns["od"];
            this.columndo = base.Columns["do"];
        }

        [DebuggerNonUserCode]
        public datasetRekapitulacijaEkran.dtRekapRow NewdtRekapRow()
        {
            return (datasetRekapitulacijaEkran.dtRekapRow) this.NewRow();
        }

        [DebuggerNonUserCode]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new datasetRekapitulacijaEkran.dtRekapRow(builder);
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            if (this.dtRekapRowChanged != null)
            {
                datasetRekapitulacijaEkran.dtRekapRowChangeEventHandler dtRekapRowChangedEvent = this.dtRekapRowChanged;
                if (dtRekapRowChangedEvent != null)
                {
                    dtRekapRowChangedEvent(this, new datasetRekapitulacijaEkran.dtRekapRowChangeEvent((datasetRekapitulacijaEkran.dtRekapRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
            if (this.dtRekapRowChanging != null)
            {
                datasetRekapitulacijaEkran.dtRekapRowChangeEventHandler dtRekapRowChangingEvent = this.dtRekapRowChanging;
                if (dtRekapRowChangingEvent != null)
                {
                    dtRekapRowChangingEvent(this, new datasetRekapitulacijaEkran.dtRekapRowChangeEvent((datasetRekapitulacijaEkran.dtRekapRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);
            if (this.dtRekapRowDeleted != null)
            {
                datasetRekapitulacijaEkran.dtRekapRowChangeEventHandler dtRekapRowDeletedEvent = this.dtRekapRowDeleted;
                if (dtRekapRowDeletedEvent != null)
                {
                    dtRekapRowDeletedEvent(this, new datasetRekapitulacijaEkran.dtRekapRowChangeEvent((datasetRekapitulacijaEkran.dtRekapRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {
            base.OnRowDeleting(e);
            if (this.dtRekapRowDeleting != null)
            {
                datasetRekapitulacijaEkran.dtRekapRowChangeEventHandler dtRekapRowDeletingEvent = this.dtRekapRowDeleting;
                if (dtRekapRowDeletingEvent != null)
                {
                    dtRekapRowDeletingEvent(this, new datasetRekapitulacijaEkran.dtRekapRowChangeEvent((datasetRekapitulacijaEkran.dtRekapRow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        public void RemovedtRekapRow(datasetRekapitulacijaEkran.dtRekapRow row)
        {
            this.Rows.Remove(row);
        }

        [DebuggerNonUserCode]
        public DataColumn BROJSATIColumn
        {
            get
            {
                return this.columnBROJSATI;
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
        public DataColumn doColumn
        {
            get
            {
                return this.columndo;
            }
        }

        [DebuggerNonUserCode]
        public datasetRekapitulacijaEkran.dtRekapRow this[int index]
        {
            get
            {
                return (datasetRekapitulacijaEkran.dtRekapRow) this.Rows[index];
            }
        }

        [DebuggerNonUserCode]
        public DataColumn IznosColumn
        {
            get
            {
                return this.columnIznos;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn odColumn
        {
            get
            {
                return this.columnod;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn OpisColumn
        {
            get
            {
                return this.columnOpis;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn SIFRAELEMENTAColumn
        {
            get
            {
                return this.columnSIFRAELEMENTA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn vrstaelementaColumn
        {
            get
            {
                return this.columnvrstaelementa;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class dtRekapRow : DataRow
    {
        private datasetRekapitulacijaEkran.dtRekapDataTable tabledtRekap;

        [DebuggerNonUserCode]
        internal dtRekapRow(DataRowBuilder rb) : base(rb)
        {
            this.tabledtRekap = (datasetRekapitulacijaEkran.dtRekapDataTable) this.Table;
        }

        [DebuggerNonUserCode]
        public bool Is_doNull()
        {
            return this.IsNull(this.tabledtRekap.doColumn);
        }

        [DebuggerNonUserCode]
        public bool IsBROJSATINull()
        {
            return this.IsNull(this.tabledtRekap.BROJSATIColumn);
        }

        [DebuggerNonUserCode]
        public bool IsIznosNull()
        {
            return this.IsNull(this.tabledtRekap.IznosColumn);
        }

        [DebuggerNonUserCode]
        public bool IsodNull()
        {
            return this.IsNull(this.tabledtRekap.odColumn);
        }

        [DebuggerNonUserCode]
        public bool IsOpisNull()
        {
            return this.IsNull(this.tabledtRekap.OpisColumn);
        }

        [DebuggerNonUserCode]
        public bool IsSIFRAELEMENTANull()
        {
            return this.IsNull(this.tabledtRekap.SIFRAELEMENTAColumn);
        }

        [DebuggerNonUserCode]
        public bool IsvrstaelementaNull()
        {
            return this.IsNull(this.tabledtRekap.vrstaelementaColumn);
        }

        [DebuggerNonUserCode]
        public void Set_doNull()
        {
            this[this.tabledtRekap.doColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetBROJSATINull()
        {
            this[this.tabledtRekap.BROJSATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetIznosNull()
        {
            this[this.tabledtRekap.IznosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetodNull()
        {
            this[this.tabledtRekap.odColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetOpisNull()
        {
            this[this.tabledtRekap.OpisColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetSIFRAELEMENTANull()
        {
            this[this.tabledtRekap.SIFRAELEMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetvrstaelementaNull()
        {
            this[this.tabledtRekap.vrstaelementaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public DateTime _do
        {
            get
            {
                DateTime time;
                try
                {
                    time = Conversions.ToDate(this[this.tabledtRekap.doColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'do' in table 'dtRekap' is DBNull.", innerException);
                }
                return time;
            }
            set
            {
                this[this.tabledtRekap.doColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal BROJSATI
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tabledtRekap.BROJSATIColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'BROJSATI' in table 'dtRekap' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tabledtRekap.BROJSATIColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string Iznos
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tabledtRekap.IznosColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'Iznos' in table 'dtRekap' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tabledtRekap.IznosColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public DateTime od
        {
            get
            {
                DateTime time;
                try
                {
                    time = Conversions.ToDate(this[this.tabledtRekap.odColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'od' in table 'dtRekap' is DBNull.", innerException);
                }
                return time;
            }
            set
            {
                this[this.tabledtRekap.odColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string Opis
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tabledtRekap.OpisColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'Opis' in table 'dtRekap' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tabledtRekap.OpisColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public short SIFRAELEMENTA
        {
            get
            {
                short num = 0;
                try
                {
                    num = Conversions.ToShort(this[this.tabledtRekap.SIFRAELEMENTAColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'SIFRAELEMENTA' in table 'dtRekap' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tabledtRekap.SIFRAELEMENTAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string vrstaelementa
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tabledtRekap.vrstaelementaColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'vrstaelementa' in table 'dtRekap' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tabledtRekap.vrstaelementaColumn] = value;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class dtRekapRowChangeEvent : EventArgs
    {
        private DataRowAction eventAction;
        private datasetRekapitulacijaEkran.dtRekapRow eventRow;

        [DebuggerNonUserCode]
        public dtRekapRowChangeEvent(datasetRekapitulacijaEkran.dtRekapRow row, DataRowAction action)
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
        public datasetRekapitulacijaEkran.dtRekapRow Row
        {
            get
            {
                return this.eventRow;
            }
        }
    }

    public delegate void dtRekapRowChangeEventHandler(object sender, datasetRekapitulacijaEkran.dtRekapRowChangeEvent e);
}

