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

[Serializable, ToolboxItem(true), DesignerCategory("code"), HelpKeyword("vs.data.DataSet"), XmlSchemaProvider("GetTypedDataSetSchema"), XmlRoot("dsIdObrazac")]
public class dsIdObrazac : DataSet
{
    private System.Data.SchemaSerializationMode _schemaSerializationMode;
    private DataRelation relationsp_id_zaglavlje_sp_id_detalji;
    private sp_id_detaljiDataTable tablesp_id_detalji;
    private sp_id_zaglavljeDataTable tablesp_id_zaglavlje;

    public dsIdObrazac()
    {
        this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        this.BeginInit();
        this.InitClass();
        CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
        base.Tables.CollectionChanged += handler;
        base.Relations.CollectionChanged += handler;
        this.EndInit();
    }


    protected dsIdObrazac(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["sp_id_detalji"] != null)
                {
                    base.Tables.Add(new sp_id_detaljiDataTable(dataSet.Tables["sp_id_detalji"]));
                }
                if (dataSet.Tables["sp_id_zaglavlje"] != null)
                {
                    base.Tables.Add(new sp_id_zaglavljeDataTable(dataSet.Tables["sp_id_zaglavlje"]));
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
        dsIdObrazac obrazac = (dsIdObrazac) base.Clone();
        obrazac.InitVars();
        obrazac.SchemaSerializationMode = this.SchemaSerializationMode;
        return obrazac;
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
        dsIdObrazac obrazac = new dsIdObrazac();
        XmlSchemaComplexType type2 = new XmlSchemaComplexType();
        XmlSchemaSequence sequence = new XmlSchemaSequence();
        XmlSchemaAny item = new XmlSchemaAny {
            Namespace = obrazac.Namespace
        };
        sequence.Items.Add(item);
        type2.Particle = sequence;
        XmlSchema schemaSerializable = obrazac.GetSchemaSerializable();
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

    
    private void InitClass()
    {
        this.DataSetName = "dsIdObrazac";
        this.Prefix = "";
        this.Namespace = "http://tempuri.org/dsIdObrazac.xsd";
        this.EnforceConstraints = true;
        this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        this.tablesp_id_detalji = new sp_id_detaljiDataTable();
        base.Tables.Add(this.tablesp_id_detalji);
        this.tablesp_id_zaglavlje = new sp_id_zaglavljeDataTable();
        base.Tables.Add(this.tablesp_id_zaglavlje);
        this.relationsp_id_zaglavlje_sp_id_detalji = new DataRelation("sp_id_zaglavlje_sp_id_detalji", new DataColumn[] { this.tablesp_id_zaglavlje.ididobrascaColumn }, new DataColumn[] { this.tablesp_id_detalji.ididobrascaColumn }, false);
        this.Relations.Add(this.relationsp_id_zaglavlje_sp_id_detalji);
    }

    
    protected override void InitializeDerivedDataSet()
    {
        this.BeginInit();
        this.InitClass();
        this.EndInit();
    }

    
    internal void InitVars()
    {
        this.InitVars(true);
    }

    
    internal void InitVars(bool initTable)
    {
        this.tablesp_id_detalji = (sp_id_detaljiDataTable) base.Tables["sp_id_detalji"];
        if (initTable && (this.tablesp_id_detalji != null))
        {
            this.tablesp_id_detalji.InitVars();
        }
        this.tablesp_id_zaglavlje = (sp_id_zaglavljeDataTable) base.Tables["sp_id_zaglavlje"];
        if (initTable && (this.tablesp_id_zaglavlje != null))
        {
            this.tablesp_id_zaglavlje.InitVars();
        }
        this.relationsp_id_zaglavlje_sp_id_detalji = this.Relations["sp_id_zaglavlje_sp_id_detalji"];
    }

    
    protected override void ReadXmlSerializable(XmlReader reader)
    {
        if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["sp_id_detalji"] != null)
            {
                base.Tables.Add(new sp_id_detaljiDataTable(dataSet.Tables["sp_id_detalji"]));
            }
            if (dataSet.Tables["sp_id_zaglavlje"] != null)
            {
                base.Tables.Add(new sp_id_zaglavljeDataTable(dataSet.Tables["sp_id_zaglavlje"]));
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

    
    private bool ShouldSerializesp_id_detalji()
    {
        return false;
    }

    
    private bool ShouldSerializesp_id_zaglavlje()
    {
        return false;
    }

    
    protected override bool ShouldSerializeTables()
    {
        return false;
    }

    [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataRelationCollection Relations
    {
        get
        {
            return base.Relations;
        }
    }

    [DebuggerNonUserCode, Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

    [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
    public sp_id_detaljiDataTable sp_id_detalji
    {
        get
        {
            return this.tablesp_id_detalji;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), DebuggerNonUserCode]
    public sp_id_zaglavljeDataTable sp_id_zaglavlje
    {
        get
        {
            return this.tablesp_id_zaglavlje;
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

    [Serializable, XmlSchemaProvider("GetTypedTableSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class sp_id_detaljiDataTable : TypedTableBase<dsIdObrazac.sp_id_detaljiRow>
    {
        private DataColumn columnididobrasca;
        private DataColumn columnIDOPCINE;
        private DataColumn columnNAZIVOPCINE;
        private DataColumn columnobracunaniporez;
        private DataColumn columnobracunaniprirez;
        private DataColumn columnobracunanoukupno;
        private DataColumn columnREDNIBROJ;

        public event dsIdObrazac.sp_id_detaljiRowChangeEventHandler sp_id_detaljiRowChanged;

        public event dsIdObrazac.sp_id_detaljiRowChangeEventHandler sp_id_detaljiRowChanging;

        public event dsIdObrazac.sp_id_detaljiRowChangeEventHandler sp_id_detaljiRowDeleted;

        public event dsIdObrazac.sp_id_detaljiRowChangeEventHandler sp_id_detaljiRowDeleting;

        
        public sp_id_detaljiDataTable()
        {
            this.TableName = "sp_id_detalji";
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        
        internal sp_id_detaljiDataTable(DataTable table)
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

        
        protected sp_id_detaljiDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.InitVars();
        }

        
        public void Addsp_id_detaljiRow(dsIdObrazac.sp_id_detaljiRow row)
        {
            this.Rows.Add(row);
        }

        
        public dsIdObrazac.sp_id_detaljiRow Addsp_id_detaljiRow(dsIdObrazac.sp_id_zaglavljeRow parentsp_id_zaglavljeRowBysp_id_zaglavlje_sp_id_detalji, string REDNIBROJ, string IDOPCINE, string NAZIVOPCINE, decimal obracunaniporez, decimal obracunaniprirez, decimal obracunanoukupno)
        {
            dsIdObrazac.sp_id_detaljiRow row = (dsIdObrazac.sp_id_detaljiRow) this.NewRow();
            object[] objArray = new object[] { null, REDNIBROJ, IDOPCINE, NAZIVOPCINE, obracunaniporez, obracunaniprirez, obracunanoukupno };
            if (parentsp_id_zaglavljeRowBysp_id_zaglavlje_sp_id_detalji != null)
            {
                objArray[0] = RuntimeHelpers.GetObjectValue(parentsp_id_zaglavljeRowBysp_id_zaglavlje_sp_id_detalji[0]);
            }
            row.ItemArray = objArray;
            this.Rows.Add(row);
            return row;
        }

        
        public override DataTable Clone()
        {
            dsIdObrazac.sp_id_detaljiDataTable table = (dsIdObrazac.sp_id_detaljiDataTable) base.Clone();
            table.InitVars();
            return table;
        }

        
        protected override DataTable CreateInstance()
        {
            return new dsIdObrazac.sp_id_detaljiDataTable();
        }

        
        protected override Type GetRowType()
        {
            return typeof(dsIdObrazac.sp_id_detaljiRow);
        }

        
        public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
        {
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            dsIdObrazac obrazac = new dsIdObrazac();
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
                FixedValue = obrazac.Namespace
            };
            type2.Attributes.Add(attribute);
            XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                Name = "tableTypeName",
                FixedValue = "sp_id_detaljiDataTable"
            };
            type2.Attributes.Add(attribute2);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = obrazac.GetSchemaSerializable();
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

        
        private void InitClass()
        {
            this.columnididobrasca = new DataColumn("ididobrasca", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnididobrasca);
            this.columnREDNIBROJ = new DataColumn("REDNIBROJ", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnREDNIBROJ);
            this.columnIDOPCINE = new DataColumn("IDOPCINE", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnIDOPCINE);
            this.columnNAZIVOPCINE = new DataColumn("NAZIVOPCINE", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnNAZIVOPCINE);
            this.columnobracunaniporez = new DataColumn("obracunaniporez", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnobracunaniporez);
            this.columnobracunaniprirez = new DataColumn("obracunaniprirez", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnobracunaniprirez);
            this.columnobracunanoukupno = new DataColumn("obracunanoukupno", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnobracunanoukupno);
            this.columnididobrasca.AllowDBNull = false;
            this.columnididobrasca.DefaultValue = 0;
            this.columnREDNIBROJ.AllowDBNull = false;
            this.columnREDNIBROJ.DefaultValue = "";
            this.columnIDOPCINE.AllowDBNull = false;
            this.columnIDOPCINE.DefaultValue = "";
            this.columnNAZIVOPCINE.AllowDBNull = false;
            this.columnNAZIVOPCINE.DefaultValue = "";
            this.columnobracunaniporez.AllowDBNull = false;
            this.columnobracunaniporez.DefaultValue = decimal.Zero;
            this.columnobracunaniprirez.AllowDBNull = false;
            this.columnobracunaniprirez.DefaultValue = decimal.Zero;
            this.columnobracunanoukupno.AllowDBNull = false;
            this.columnobracunanoukupno.DefaultValue = decimal.Zero;
        }

        
        internal void InitVars()
        {
            this.columnididobrasca = base.Columns["ididobrasca"];
            this.columnREDNIBROJ = base.Columns["REDNIBROJ"];
            this.columnIDOPCINE = base.Columns["IDOPCINE"];
            this.columnNAZIVOPCINE = base.Columns["NAZIVOPCINE"];
            this.columnobracunaniporez = base.Columns["obracunaniporez"];
            this.columnobracunaniprirez = base.Columns["obracunaniprirez"];
            this.columnobracunanoukupno = base.Columns["obracunanoukupno"];
        }

        
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new dsIdObrazac.sp_id_detaljiRow(builder);
        }

        
        public dsIdObrazac.sp_id_detaljiRow Newsp_id_detaljiRow()
        {
            return (dsIdObrazac.sp_id_detaljiRow) this.NewRow();
        }

        
        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            if (this.sp_id_detaljiRowChanged != null)
            {
                dsIdObrazac.sp_id_detaljiRowChangeEventHandler handler = this.sp_id_detaljiRowChanged;
                if (handler != null)

                {
                    handler(this, new dsIdObrazac.sp_id_detaljiRowChangeEvent((dsIdObrazac.sp_id_detaljiRow) e.Row, e.Action));
                }
            }
        }

        
        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
            if (this.sp_id_detaljiRowChanging != null)
            {
                dsIdObrazac.sp_id_detaljiRowChangeEventHandler handler = this.sp_id_detaljiRowChanging;
                if (handler != null)
                {
                    handler(this, new dsIdObrazac.sp_id_detaljiRowChangeEvent((dsIdObrazac.sp_id_detaljiRow) e.Row, e.Action));
                }
            }
        }

        
        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);
            if (this.sp_id_detaljiRowDeleted != null)
            {
                dsIdObrazac.sp_id_detaljiRowChangeEventHandler handler = this.sp_id_detaljiRowDeleted;
                if (handler != null)
                {
                    handler(this, new dsIdObrazac.sp_id_detaljiRowChangeEvent((dsIdObrazac.sp_id_detaljiRow) e.Row, e.Action));
                }
            }
        }

        
        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {
            base.OnRowDeleting(e);
            if (this.sp_id_detaljiRowDeleting != null)
            {
                dsIdObrazac.sp_id_detaljiRowChangeEventHandler handler = this.sp_id_detaljiRowDeleting;
                if (handler != null)
                {
                    handler(this, new dsIdObrazac.sp_id_detaljiRowChangeEvent((dsIdObrazac.sp_id_detaljiRow) e.Row, e.Action));
                }
            }
        }

        
        public void Removesp_id_detaljiRow(dsIdObrazac.sp_id_detaljiRow row)
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

        
        public DataColumn ididobrascaColumn
        {
            get
            {
                return this.columnididobrasca;
            }
        }

        
        public DataColumn IDOPCINEColumn
        {
            get
            {
                return this.columnIDOPCINE;
            }
        }

        
        public dsIdObrazac.sp_id_detaljiRow this[int index]
        {
            get
            {
                return (dsIdObrazac.sp_id_detaljiRow) this.Rows[index];
            }
        }

        
        public DataColumn NAZIVOPCINEColumn
        {
            get
            {
                return this.columnNAZIVOPCINE;
            }
        }

        
        public DataColumn obracunaniporezColumn
        {
            get
            {
                return this.columnobracunaniporez;
            }
        }

        
        public DataColumn obracunaniprirezColumn
        {
            get
            {
                return this.columnobracunaniprirez;
            }
        }

        
        public DataColumn obracunanoukupnoColumn
        {
            get
            {
                return this.columnobracunanoukupno;
            }
        }

        
        public DataColumn REDNIBROJColumn
        {
            get
            {
                return this.columnREDNIBROJ;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class sp_id_detaljiRow : DataRow
    {
        private dsIdObrazac.sp_id_detaljiDataTable tablesp_id_detalji;

        
        internal sp_id_detaljiRow(DataRowBuilder rb) : base(rb)
        {
            this.tablesp_id_detalji = (dsIdObrazac.sp_id_detaljiDataTable) this.Table;
        }

        
        public int ididobrasca
        {
            get
            {
                return Conversions.ToInteger(this[this.tablesp_id_detalji.ididobrascaColumn]);
            }
            set
            {
                this[this.tablesp_id_detalji.ididobrascaColumn] = value;
            }
        }

        
        public string IDOPCINE
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_id_detalji.IDOPCINEColumn]);
            }
            set
            {
                this[this.tablesp_id_detalji.IDOPCINEColumn] = value;
            }
        }

        
        public string NAZIVOPCINE
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_id_detalji.NAZIVOPCINEColumn]);
            }
            set
            {
                this[this.tablesp_id_detalji.NAZIVOPCINEColumn] = value;
            }
        }

        
        public decimal obracunaniporez
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_detalji.obracunaniporezColumn]);
            }
            set
            {
                this[this.tablesp_id_detalji.obracunaniporezColumn] = value;
            }
        }

        
        public decimal obracunaniprirez
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_detalji.obracunaniprirezColumn]);
            }
            set
            {
                this[this.tablesp_id_detalji.obracunaniprirezColumn] = value;
            }
        }

        
        public decimal obracunanoukupno
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_detalji.obracunanoukupnoColumn]);
            }
            set
            {
                this[this.tablesp_id_detalji.obracunanoukupnoColumn] = value;
            }
        }

        
        public string REDNIBROJ
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_id_detalji.REDNIBROJColumn]);
            }
            set
            {
                this[this.tablesp_id_detalji.REDNIBROJColumn] = value;
            }
        }

        
        public dsIdObrazac.sp_id_zaglavljeRow sp_id_zaglavljeRow
        {
            get
            {
                return (dsIdObrazac.sp_id_zaglavljeRow) this.GetParentRow(this.Table.ParentRelations["sp_id_zaglavlje_sp_id_detalji"]);
            }
            set
            {
                this.SetParentRow(value, this.Table.ParentRelations["sp_id_zaglavlje_sp_id_detalji"]);
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class sp_id_detaljiRowChangeEvent : EventArgs
    {
        private DataRowAction eventAction;
        private dsIdObrazac.sp_id_detaljiRow eventRow;

        
        public sp_id_detaljiRowChangeEvent(dsIdObrazac.sp_id_detaljiRow row, DataRowAction action)
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

        
        public dsIdObrazac.sp_id_detaljiRow Row
        {
            get
            {
                return this.eventRow;
            }
        }
    }

    public delegate void sp_id_detaljiRowChangeEventHandler(object sender, dsIdObrazac.sp_id_detaljiRowChangeEvent e);

    [Serializable, XmlSchemaProvider("GetTypedTableSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class sp_id_zaglavljeDataTable : TypedTableBase<dsIdObrazac.sp_id_zaglavljeRow>
    {
        private DataColumn columnDATUMSASTAVLJANJA;
        private DataColumn columnidenTIFIKATOR;
        private DataColumn columnididobrasca;
        private DataColumn columnmaticnibroj;
        private DataColumn columnnazivfirme;
        private DataColumn columnpunaadresa;
        private DataColumn columnREDAK_II_1;
        private DataColumn columnREDAK_II_2;
        private DataColumn columnREDAK_II_2_1;
        private DataColumn columnREDAK_II_2_1_1;
        private DataColumn columnREDAK_II_2_1_2;
        private DataColumn columnREDAK_II_2_1_3;
        private DataColumn columnREDAK_II_2_2;
        private DataColumn columnREDAK_II_2_2_1;
        private DataColumn columnREDAK_II_2_2_2;
        private DataColumn columnREDAK_II_2_2_3;
        private DataColumn columnREDAK_II_3;
        private DataColumn columnREDAK_II_4;
        private DataColumn columnREDAK_II_5;
        private DataColumn columnREDAK_II_6;
        private DataColumn columnREDAK_II_6_1;
        private DataColumn columnREDAK_II_6_2;
        private DataColumn columnREDAK_II_7;
        private DataColumn columnREDAK_II_8;
        private DataColumn columnREDAK_III_1_1;
        private DataColumn columnREDAK_III_1_2;
        private DataColumn columnREDAK_III_2_1;
        private DataColumn columnREDAK_III_2_2;
        private DataColumn columnREDAK_III_3_1;
        private DataColumn columnREDAK_III_3_2;
        private DataColumn columnREDAK_III_3_3;
        private DataColumn columnREDAK_III_4_1;
        private DataColumn columnREDAK_III_4_2;
        private DataColumn columnREDAK_III_5;

        public event dsIdObrazac.sp_id_zaglavljeRowChangeEventHandler sp_id_zaglavljeRowChanged;

        public event dsIdObrazac.sp_id_zaglavljeRowChangeEventHandler sp_id_zaglavljeRowChanging;

        public event dsIdObrazac.sp_id_zaglavljeRowChangeEventHandler sp_id_zaglavljeRowDeleted;

        public event dsIdObrazac.sp_id_zaglavljeRowChangeEventHandler sp_id_zaglavljeRowDeleting;

        
        public sp_id_zaglavljeDataTable()
        {
            this.TableName = "sp_id_zaglavlje";
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        
        internal sp_id_zaglavljeDataTable(DataTable table)
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

        
        protected sp_id_zaglavljeDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.InitVars();
        }

        
        public void Addsp_id_zaglavljeRow(dsIdObrazac.sp_id_zaglavljeRow row)
        {
            this.Rows.Add(row);
        }

        
        public dsIdObrazac.sp_id_zaglavljeRow Addsp_id_zaglavljeRow(int ididobrasca, string nazivfirme, string punaadresa, string maticnibroj, string idenTIFIKATOR, decimal REDAK_II_1, decimal REDAK_II_2, decimal REDAK_II_2_1, decimal REDAK_II_2_1_1, decimal REDAK_II_2_1_2, decimal REDAK_II_2_1_3, decimal REDAK_II_2_2, decimal REDAK_II_2_2_1, decimal REDAK_II_2_2_2, decimal REDAK_II_2_2_3, decimal REDAK_II_3, decimal REDAK_II_4, decimal REDAK_II_5, decimal REDAK_II_6, decimal REDAK_II_6_1, decimal REDAK_II_6_2, decimal REDAK_II_7, decimal REDAK_II_8, decimal REDAK_III_1_1, decimal REDAK_III_1_2, decimal REDAK_III_2_1, decimal REDAK_III_2_2, decimal REDAK_III_3_1, decimal REDAK_III_3_2, decimal REDAK_III_3_3, decimal REDAK_III_4_1, decimal REDAK_III_4_2, decimal REDAK_III_5, DateTime DATUMSASTAVLJANJA)
        {
            dsIdObrazac.sp_id_zaglavljeRow row = (dsIdObrazac.sp_id_zaglavljeRow) this.NewRow();
            row.ItemArray = new object[] { 
                ididobrasca, nazivfirme, punaadresa, maticnibroj, idenTIFIKATOR, REDAK_II_1, REDAK_II_2, REDAK_II_2_1, REDAK_II_2_1_1, REDAK_II_2_1_2, REDAK_II_2_1_3, REDAK_II_2_2, REDAK_II_2_2_1, REDAK_II_2_2_2, REDAK_II_2_2_3, REDAK_II_3, 
                REDAK_II_4, REDAK_II_5, REDAK_II_6, REDAK_II_6_1, REDAK_II_6_2, REDAK_II_7, REDAK_II_8, REDAK_III_1_1, REDAK_III_1_2, REDAK_III_2_1, REDAK_III_2_2, REDAK_III_3_1, REDAK_III_3_2, REDAK_III_3_3, REDAK_III_4_1, REDAK_III_4_2, 
                REDAK_III_5, DATUMSASTAVLJANJA
             };
            this.Rows.Add(row);
            return row;
        }

        
        public override DataTable Clone()
        {
            dsIdObrazac.sp_id_zaglavljeDataTable table = (dsIdObrazac.sp_id_zaglavljeDataTable) base.Clone();
            table.InitVars();
            return table;
        }

        
        protected override DataTable CreateInstance()
        {
            return new dsIdObrazac.sp_id_zaglavljeDataTable();
        }

        
        protected override Type GetRowType()
        {
            return typeof(dsIdObrazac.sp_id_zaglavljeRow);
        }

        
        public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
        {
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            dsIdObrazac obrazac = new dsIdObrazac();
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
                FixedValue = obrazac.Namespace
            };
            type2.Attributes.Add(attribute);
            XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                Name = "tableTypeName",
                FixedValue = "sp_id_zaglavljeDataTable"
            };
            type2.Attributes.Add(attribute2);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = obrazac.GetSchemaSerializable();
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

        
        private void InitClass()
        {
            this.columnididobrasca = new DataColumn("ididobrasca", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnididobrasca);
            this.columnnazivfirme = new DataColumn("nazivfirme", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnnazivfirme);
            this.columnpunaadresa = new DataColumn("punaadresa", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnpunaadresa);
            this.columnmaticnibroj = new DataColumn("maticnibroj", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnmaticnibroj);
            this.columnidenTIFIKATOR = new DataColumn("idenTIFIKATOR", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnidenTIFIKATOR);
            this.columnREDAK_II_1 = new DataColumn("REDAK_II_1", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_1);
            this.columnREDAK_II_2 = new DataColumn("REDAK_II_2", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_2);
            this.columnREDAK_II_2_1 = new DataColumn("REDAK_II_2_1", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_2_1);
            this.columnREDAK_II_2_1_1 = new DataColumn("REDAK_II_2_1_1", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_2_1_1);
            this.columnREDAK_II_2_1_2 = new DataColumn("REDAK_II_2_1_2", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_2_1_2);
            this.columnREDAK_II_2_1_3 = new DataColumn("REDAK_II_2_1_3", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_2_1_3);
            this.columnREDAK_II_2_2 = new DataColumn("REDAK_II_2_2", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_2_2);
            this.columnREDAK_II_2_2_1 = new DataColumn("REDAK_II_2_2_1", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_2_2_1);
            this.columnREDAK_II_2_2_2 = new DataColumn("REDAK_II_2_2_2", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_2_2_2);
            this.columnREDAK_II_2_2_3 = new DataColumn("REDAK_II_2_2_3", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_2_2_3);
            this.columnREDAK_II_3 = new DataColumn("REDAK_II_3", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_3);
            this.columnREDAK_II_4 = new DataColumn("REDAK_II_4", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_4);
            this.columnREDAK_II_5 = new DataColumn("REDAK_II_5", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_5);
            this.columnREDAK_II_6 = new DataColumn("REDAK_II_6", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_6);
            this.columnREDAK_II_6_1 = new DataColumn("REDAK_II_6_1", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_6_1);
            this.columnREDAK_II_6_2 = new DataColumn("REDAK_II_6_2", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_6_2);
            this.columnREDAK_II_7 = new DataColumn("REDAK_II_7", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_7);
            this.columnREDAK_II_8 = new DataColumn("REDAK_II_8", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_II_8);
            this.columnREDAK_III_1_1 = new DataColumn("REDAK_III_1_1", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_III_1_1);
            this.columnREDAK_III_1_2 = new DataColumn("REDAK_III_1_2", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_III_1_2);
            this.columnREDAK_III_2_1 = new DataColumn("REDAK_III_2_1", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_III_2_1);
            this.columnREDAK_III_2_2 = new DataColumn("REDAK_III_2_2", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_III_2_2);
            this.columnREDAK_III_3_1 = new DataColumn("REDAK_III_3_1", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_III_3_1);
            this.columnREDAK_III_3_2 = new DataColumn("REDAK_III_3_2", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_III_3_2);
            this.columnREDAK_III_3_3 = new DataColumn("REDAK_III_3_3", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_III_3_3);
            this.columnREDAK_III_4_1 = new DataColumn("REDAK_III_4_1", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_III_4_1);
            this.columnREDAK_III_4_2 = new DataColumn("REDAK_III_4_2", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_III_4_2);
            this.columnREDAK_III_5 = new DataColumn("REDAK_III_5", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnREDAK_III_5);
            this.columnDATUMSASTAVLJANJA = new DataColumn("DATUMSASTAVLJANJA", typeof(DateTime), null, MappingType.Element);
            base.Columns.Add(this.columnDATUMSASTAVLJANJA);
            this.columnididobrasca.AllowDBNull = false;
            this.columnididobrasca.DefaultValue = 0;
            this.columnnazivfirme.AllowDBNull = false;
            this.columnnazivfirme.DefaultValue = "";
            this.columnpunaadresa.AllowDBNull = false;
            this.columnpunaadresa.DefaultValue = "";
            this.columnmaticnibroj.AllowDBNull = false;
            this.columnmaticnibroj.DefaultValue = "";
            this.columnidenTIFIKATOR.AllowDBNull = false;
            this.columnidenTIFIKATOR.DefaultValue = "";
            this.columnREDAK_II_1.AllowDBNull = false;
            this.columnREDAK_II_1.DefaultValue = decimal.Zero;
            this.columnREDAK_II_2.AllowDBNull = false;
            this.columnREDAK_II_2.DefaultValue = decimal.Zero;
            this.columnREDAK_II_2_1.AllowDBNull = false;
            this.columnREDAK_II_2_1.DefaultValue = decimal.Zero;
            this.columnREDAK_II_2_1_1.AllowDBNull = false;
            this.columnREDAK_II_2_1_1.DefaultValue = decimal.Zero;
            this.columnREDAK_II_2_1_2.AllowDBNull = false;
            this.columnREDAK_II_2_1_2.DefaultValue = decimal.Zero;
            this.columnREDAK_II_2_1_3.AllowDBNull = false;
            this.columnREDAK_II_2_1_3.DefaultValue = decimal.Zero;
            this.columnREDAK_II_2_2.AllowDBNull = false;
            this.columnREDAK_II_2_2.DefaultValue = decimal.Zero;
            this.columnREDAK_II_2_2_1.AllowDBNull = false;
            this.columnREDAK_II_2_2_1.DefaultValue = decimal.Zero;
            this.columnREDAK_II_2_2_2.AllowDBNull = false;
            this.columnREDAK_II_2_2_2.DefaultValue = decimal.Zero;
            this.columnREDAK_II_2_2_3.AllowDBNull = false;
            this.columnREDAK_II_2_2_3.DefaultValue = decimal.Zero;
            this.columnREDAK_II_3.AllowDBNull = false;
            this.columnREDAK_II_3.DefaultValue = decimal.Zero;
            this.columnREDAK_II_4.AllowDBNull = false;
            this.columnREDAK_II_4.DefaultValue = decimal.Zero;
            this.columnREDAK_II_5.AllowDBNull = false;
            this.columnREDAK_II_5.DefaultValue = decimal.Zero;
            this.columnREDAK_II_6.AllowDBNull = false;
            this.columnREDAK_II_6.DefaultValue = decimal.Zero;
            this.columnREDAK_II_6_1.AllowDBNull = false;
            this.columnREDAK_II_6_1.DefaultValue = decimal.Zero;
            this.columnREDAK_II_6_2.AllowDBNull = false;
            this.columnREDAK_II_6_2.DefaultValue = decimal.Zero;
            this.columnREDAK_II_7.AllowDBNull = false;
            this.columnREDAK_II_7.DefaultValue = decimal.Zero;
            this.columnREDAK_II_8.AllowDBNull = false;
            this.columnREDAK_II_8.DefaultValue = decimal.Zero;
            this.columnREDAK_III_1_1.AllowDBNull = false;
            this.columnREDAK_III_1_1.DefaultValue = decimal.Zero;
            this.columnREDAK_III_1_2.AllowDBNull = false;
            this.columnREDAK_III_1_2.DefaultValue = decimal.Zero;
            this.columnREDAK_III_2_1.AllowDBNull = false;
            this.columnREDAK_III_2_1.DefaultValue = decimal.Zero;
            this.columnREDAK_III_2_2.AllowDBNull = false;
            this.columnREDAK_III_2_2.DefaultValue = decimal.Zero;
            this.columnREDAK_III_3_1.AllowDBNull = false;
            this.columnREDAK_III_3_1.DefaultValue = decimal.Zero;
            this.columnREDAK_III_3_2.AllowDBNull = false;
            this.columnREDAK_III_3_2.DefaultValue = decimal.Zero;
            this.columnREDAK_III_3_3.AllowDBNull = false;
            this.columnREDAK_III_3_3.DefaultValue = decimal.Zero;
            this.columnREDAK_III_4_1.AllowDBNull = false;
            this.columnREDAK_III_4_1.DefaultValue = decimal.Zero;
            this.columnREDAK_III_4_2.AllowDBNull = false;
            this.columnREDAK_III_4_2.DefaultValue = decimal.Zero;
            this.columnREDAK_III_5.AllowDBNull = false;
            this.columnREDAK_III_5.DefaultValue = decimal.Zero;
            this.columnDATUMSASTAVLJANJA.AllowDBNull = false;
        }

        
        internal void InitVars()
        {
            this.columnididobrasca = base.Columns["ididobrasca"];
            this.columnnazivfirme = base.Columns["nazivfirme"];
            this.columnpunaadresa = base.Columns["punaadresa"];
            this.columnmaticnibroj = base.Columns["maticnibroj"];
            this.columnidenTIFIKATOR = base.Columns["idenTIFIKATOR"];
            this.columnREDAK_II_1 = base.Columns["REDAK_II_1"];
            this.columnREDAK_II_2 = base.Columns["REDAK_II_2"];
            this.columnREDAK_II_2_1 = base.Columns["REDAK_II_2_1"];
            this.columnREDAK_II_2_1_1 = base.Columns["REDAK_II_2_1_1"];
            this.columnREDAK_II_2_1_2 = base.Columns["REDAK_II_2_1_2"];
            this.columnREDAK_II_2_1_3 = base.Columns["REDAK_II_2_1_3"];
            this.columnREDAK_II_2_2 = base.Columns["REDAK_II_2_2"];
            this.columnREDAK_II_2_2_1 = base.Columns["REDAK_II_2_2_1"];
            this.columnREDAK_II_2_2_2 = base.Columns["REDAK_II_2_2_2"];
            this.columnREDAK_II_2_2_3 = base.Columns["REDAK_II_2_2_3"];
            this.columnREDAK_II_3 = base.Columns["REDAK_II_3"];
            this.columnREDAK_II_4 = base.Columns["REDAK_II_4"];
            this.columnREDAK_II_5 = base.Columns["REDAK_II_5"];
            this.columnREDAK_II_6 = base.Columns["REDAK_II_6"];
            this.columnREDAK_II_6_1 = base.Columns["REDAK_II_6_1"];
            this.columnREDAK_II_6_2 = base.Columns["REDAK_II_6_2"];
            this.columnREDAK_II_7 = base.Columns["REDAK_II_7"];
            this.columnREDAK_II_8 = base.Columns["REDAK_II_8"];
            this.columnREDAK_III_1_1 = base.Columns["REDAK_III_1_1"];
            this.columnREDAK_III_1_2 = base.Columns["REDAK_III_1_2"];
            this.columnREDAK_III_2_1 = base.Columns["REDAK_III_2_1"];
            this.columnREDAK_III_2_2 = base.Columns["REDAK_III_2_2"];
            this.columnREDAK_III_3_1 = base.Columns["REDAK_III_3_1"];
            this.columnREDAK_III_3_2 = base.Columns["REDAK_III_3_2"];
            this.columnREDAK_III_3_3 = base.Columns["REDAK_III_3_3"];
            this.columnREDAK_III_4_1 = base.Columns["REDAK_III_4_1"];
            this.columnREDAK_III_4_2 = base.Columns["REDAK_III_4_2"];
            this.columnREDAK_III_5 = base.Columns["REDAK_III_5"];
            this.columnDATUMSASTAVLJANJA = base.Columns["DATUMSASTAVLJANJA"];
        }

        
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new dsIdObrazac.sp_id_zaglavljeRow(builder);
        }

        
        public dsIdObrazac.sp_id_zaglavljeRow Newsp_id_zaglavljeRow()
        {
            return (dsIdObrazac.sp_id_zaglavljeRow) this.NewRow();
        }

        
        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            if (this.sp_id_zaglavljeRowChanged != null)
            {
                dsIdObrazac.sp_id_zaglavljeRowChangeEventHandler handler = this.sp_id_zaglavljeRowChanged;
                if (handler != null)
                {
                    handler(this, new dsIdObrazac.sp_id_zaglavljeRowChangeEvent((dsIdObrazac.sp_id_zaglavljeRow) e.Row, e.Action));
                }
            }
        }

        
        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
            if (this.sp_id_zaglavljeRowChanging != null)
            {
                dsIdObrazac.sp_id_zaglavljeRowChangeEventHandler handler = this.sp_id_zaglavljeRowChanging;
                if (handler != null)
                {
                    handler(this, new dsIdObrazac.sp_id_zaglavljeRowChangeEvent((dsIdObrazac.sp_id_zaglavljeRow) e.Row, e.Action));
                }
            }
        }

        
        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);
            if (this.sp_id_zaglavljeRowDeleted != null)
            {
                dsIdObrazac.sp_id_zaglavljeRowChangeEventHandler handler = this.sp_id_zaglavljeRowDeleted;
                if (handler != null)
                {
                    handler(this, new dsIdObrazac.sp_id_zaglavljeRowChangeEvent((dsIdObrazac.sp_id_zaglavljeRow) e.Row, e.Action));
                }
            }
        }

        
        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {
            base.OnRowDeleting(e);
            if (this.sp_id_zaglavljeRowDeleting != null)
            {
                dsIdObrazac.sp_id_zaglavljeRowChangeEventHandler handler = this.sp_id_zaglavljeRowDeleting;
                if (handler != null)
                {
                    handler(this, new dsIdObrazac.sp_id_zaglavljeRowChangeEvent((dsIdObrazac.sp_id_zaglavljeRow) e.Row, e.Action));
                }
            }
        }

        
        public void Removesp_id_zaglavljeRow(dsIdObrazac.sp_id_zaglavljeRow row)
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

        
        public DataColumn DATUMSASTAVLJANJAColumn
        {
            get
            {
                return this.columnDATUMSASTAVLJANJA;
            }
        }

        
        public DataColumn idenTIFIKATORColumn
        {
            get
            {
                return this.columnidenTIFIKATOR;
            }
        }

        
        public DataColumn ididobrascaColumn
        {
            get
            {
                return this.columnididobrasca;
            }
        }

        
        public dsIdObrazac.sp_id_zaglavljeRow this[int index]
        {
            get
            {
                return (dsIdObrazac.sp_id_zaglavljeRow) this.Rows[index];
            }
        }

        
        public DataColumn maticnibrojColumn
        {
            get
            {
                return this.columnmaticnibroj;
            }
        }

        
        public DataColumn nazivfirmeColumn
        {
            get
            {
                return this.columnnazivfirme;
            }
        }

        
        public DataColumn punaadresaColumn
        {
            get
            {
                return this.columnpunaadresa;
            }
        }

        
        public DataColumn REDAK_II_1Column
        {
            get
            {
                return this.columnREDAK_II_1;
            }
        }

        
        public DataColumn REDAK_II_2_1_1Column
        {
            get
            {
                return this.columnREDAK_II_2_1_1;
            }
        }

        
        public DataColumn REDAK_II_2_1_2Column
        {
            get
            {
                return this.columnREDAK_II_2_1_2;
            }
        }

        
        public DataColumn REDAK_II_2_1_3Column
        {
            get
            {
                return this.columnREDAK_II_2_1_3;
            }
        }

        
        public DataColumn REDAK_II_2_1Column
        {
            get
            {
                return this.columnREDAK_II_2_1;
            }
        }

        
        public DataColumn REDAK_II_2_2_1Column
        {
            get
            {
                return this.columnREDAK_II_2_2_1;
            }
        }

        
        public DataColumn REDAK_II_2_2_2Column
        {
            get
            {
                return this.columnREDAK_II_2_2_2;
            }
        }

        
        public DataColumn REDAK_II_2_2_3Column
        {
            get
            {
                return this.columnREDAK_II_2_2_3;
            }
        }

        
        public DataColumn REDAK_II_2_2Column
        {
            get
            {
                return this.columnREDAK_II_2_2;
            }
        }

        
        public DataColumn REDAK_II_2Column
        {
            get
            {
                return this.columnREDAK_II_2;
            }
        }

        
        public DataColumn REDAK_II_3Column
        {
            get
            {
                return this.columnREDAK_II_3;
            }
        }

        
        public DataColumn REDAK_II_4Column
        {
            get
            {
                return this.columnREDAK_II_4;
            }
        }

        
        public DataColumn REDAK_II_5Column
        {
            get
            {
                return this.columnREDAK_II_5;
            }
        }

        
        public DataColumn REDAK_II_6_1Column
        {
            get
            {
                return this.columnREDAK_II_6_1;
            }
        }

        
        public DataColumn REDAK_II_6_2Column
        {
            get
            {
                return this.columnREDAK_II_6_2;
            }
        }

        
        public DataColumn REDAK_II_6Column
        {
            get
            {
                return this.columnREDAK_II_6;
            }
        }

        
        public DataColumn REDAK_II_7Column
        {
            get
            {
                return this.columnREDAK_II_7;
            }
        }

        
        public DataColumn REDAK_II_8Column
        {
            get
            {
                return this.columnREDAK_II_8;
            }
        }

        
        public DataColumn REDAK_III_1_1Column
        {
            get
            {
                return this.columnREDAK_III_1_1;
            }
        }

        
        public DataColumn REDAK_III_1_2Column
        {
            get
            {
                return this.columnREDAK_III_1_2;
            }
        }

        
        public DataColumn REDAK_III_2_1Column
        {
            get
            {
                return this.columnREDAK_III_2_1;
            }
        }

        
        public DataColumn REDAK_III_2_2Column
        {
            get
            {
                return this.columnREDAK_III_2_2;
            }
        }

        
        public DataColumn REDAK_III_3_1Column
        {
            get
            {
                return this.columnREDAK_III_3_1;
            }
        }

        
        public DataColumn REDAK_III_3_2Column
        {
            get
            {
                return this.columnREDAK_III_3_2;
            }
        }

        
        public DataColumn REDAK_III_3_3Column
        {
            get
            {
                return this.columnREDAK_III_3_3;
            }
        }

        
        public DataColumn REDAK_III_4_1Column
        {
            get
            {
                return this.columnREDAK_III_4_1;
            }
        }

        
        public DataColumn REDAK_III_4_2Column
        {
            get
            {
                return this.columnREDAK_III_4_2;
            }
        }

        
        public DataColumn REDAK_III_5Column
        {
            get
            {
                return this.columnREDAK_III_5;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class sp_id_zaglavljeRow : DataRow
    {
        private dsIdObrazac.sp_id_zaglavljeDataTable tablesp_id_zaglavlje;

        
        internal sp_id_zaglavljeRow(DataRowBuilder rb) : base(rb)
        {
            this.tablesp_id_zaglavlje = (dsIdObrazac.sp_id_zaglavljeDataTable) this.Table;
        }

        
        public dsIdObrazac.sp_id_detaljiRow[] Getsp_id_detaljiRows()
        {
            if (this.Table.ChildRelations["sp_id_zaglavlje_sp_id_detalji"] == null)
            {
                return new dsIdObrazac.sp_id_detaljiRow[0];
            }
            return (dsIdObrazac.sp_id_detaljiRow[]) base.GetChildRows(this.Table.ChildRelations["sp_id_zaglavlje_sp_id_detalji"]);
        }

        
        public DateTime DATUMSASTAVLJANJA
        {
            get
            {
                return Conversions.ToDate(this[this.tablesp_id_zaglavlje.DATUMSASTAVLJANJAColumn]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.DATUMSASTAVLJANJAColumn] = value;
            }
        }

        
        public string idenTIFIKATOR
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_id_zaglavlje.idenTIFIKATORColumn]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.idenTIFIKATORColumn] = value;
            }
        }

        
        public int ididobrasca
        {
            get
            {
                return Conversions.ToInteger(this[this.tablesp_id_zaglavlje.ididobrascaColumn]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.ididobrascaColumn] = value;
            }
        }

        
        public string maticnibroj
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_id_zaglavlje.maticnibrojColumn]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.maticnibrojColumn] = value;
            }
        }

        
        public string nazivfirme
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_id_zaglavlje.nazivfirmeColumn]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.nazivfirmeColumn] = value;
            }
        }

        
        public string punaadresa
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_id_zaglavlje.punaadresaColumn]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.punaadresaColumn] = value;
            }
        }

        
        public decimal REDAK_II_1
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_1Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_1Column] = value;
            }
        }

        
        public decimal REDAK_II_2
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2Column] = value;
            }
        }

        
        public decimal REDAK_II_2_1
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_1Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_1Column] = value;
            }
        }

        
        public decimal REDAK_II_2_1_1
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_1_1Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_1_1Column] = value;
            }
        }

        
        public decimal REDAK_II_2_1_2
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_1_2Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_1_2Column] = value;
            }
        }

        
        public decimal REDAK_II_2_1_3
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_1_3Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_1_3Column] = value;
            }
        }

        
        public decimal REDAK_II_2_2
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_2Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_2Column] = value;
            }
        }

        
        public decimal REDAK_II_2_2_1
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_2_1Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_2_1Column] = value;
            }
        }

        
        public decimal REDAK_II_2_2_2
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_2_2Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_2_2Column] = value;
            }
        }

        
        public decimal REDAK_II_2_2_3
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_2_2_3Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_2_2_3Column] = value;
            }
        }

        
        public decimal REDAK_II_3
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_3Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_3Column] = value;
            }
        }

        
        public decimal REDAK_II_4
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_4Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_4Column] = value;
            }
        }

        
        public decimal REDAK_II_5
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_5Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_5Column] = value;
            }
        }

        
        public decimal REDAK_II_6
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_6Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_6Column] = value;
            }
        }

        
        public decimal REDAK_II_6_1
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_6_1Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_6_1Column] = value;
            }
        }

        
        public decimal REDAK_II_6_2
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_6_2Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_6_2Column] = value;
            }
        }

        
        public decimal REDAK_II_7
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_7Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_7Column] = value;
            }
        }

        
        public decimal REDAK_II_8
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_II_8Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_II_8Column] = value;
            }
        }

        
        public decimal REDAK_III_1_1
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_1_1Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_1_1Column] = value;
            }
        }

        
        public decimal REDAK_III_1_2
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_1_2Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_1_2Column] = value;
            }
        }

        
        public decimal REDAK_III_2_1
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_2_1Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_2_1Column] = value;
            }
        }

        
        public decimal REDAK_III_2_2
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_2_2Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_2_2Column] = value;
            }
        }

        
        public decimal REDAK_III_3_1
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_3_1Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_3_1Column] = value;
            }
        }

        
        public decimal REDAK_III_3_2
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_3_2Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_3_2Column] = value;
            }
        }

        
        public decimal REDAK_III_3_3
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_3_3Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_3_3Column] = value;
            }
        }

        
        public decimal REDAK_III_4_1
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_4_1Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_4_1Column] = value;
            }
        }

        
        public decimal REDAK_III_4_2
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_4_2Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_4_2Column] = value;
            }
        }

        
        public decimal REDAK_III_5
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_id_zaglavlje.REDAK_III_5Column]);
            }
            set
            {
                this[this.tablesp_id_zaglavlje.REDAK_III_5Column] = value;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class sp_id_zaglavljeRowChangeEvent : EventArgs
    {
        private DataRowAction eventAction;
        private dsIdObrazac.sp_id_zaglavljeRow eventRow;

        
        public sp_id_zaglavljeRowChangeEvent(dsIdObrazac.sp_id_zaglavljeRow row, DataRowAction action)
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

        
        public dsIdObrazac.sp_id_zaglavljeRow Row
        {
            get
            {
                return this.eventRow;
            }
        }
    }

    public delegate void sp_id_zaglavljeRowChangeEventHandler(object sender, dsIdObrazac.sp_id_zaglavljeRowChangeEvent e);
}

