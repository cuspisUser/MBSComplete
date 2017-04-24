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

[Serializable, DesignerCategory("code"), HelpKeyword("vs.data.DataSet"), XmlRoot("dsIPObrazac"), XmlSchemaProvider("GetTypedDataSetSchema"), ToolboxItem(true)]
public class dsIPObrazac : DataSet
{
    private System.Data.SchemaSerializationMode _schemaSerializationMode;
    private DataRelation relationsp_ip_zaglavlje_sp_ip_detalji;
    private sp_ip_detaljiDataTable tablesp_ip_detalji;
    private sp_ip_zaglavljeDataTable tablesp_ip_zaglavlje;

    
    public dsIPObrazac()
    {
        this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        this.BeginInit();
        this.InitClass();
        CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
        base.Tables.CollectionChanged += handler;
        base.Relations.CollectionChanged += handler;
        this.EndInit();
    }

    
    protected dsIPObrazac(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["sp_ip_detalji"] != null)
                {
                    base.Tables.Add(new sp_ip_detaljiDataTable(dataSet.Tables["sp_ip_detalji"]));
                }
                if (dataSet.Tables["sp_ip_zaglavlje"] != null)
                {
                    base.Tables.Add(new sp_ip_zaglavljeDataTable(dataSet.Tables["sp_ip_zaglavlje"]));
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
        dsIPObrazac obrazac = (dsIPObrazac) base.Clone();
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
        dsIPObrazac obrazac = new dsIPObrazac();
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
        this.DataSetName = "dsIPObrazac";
        this.Prefix = "";
        this.Namespace = "http://tempuri.org/dsIPObrazac.xsd";
        this.EnforceConstraints = true;
        this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        this.tablesp_ip_detalji = new sp_ip_detaljiDataTable();
        base.Tables.Add(this.tablesp_ip_detalji);
        this.tablesp_ip_zaglavlje = new sp_ip_zaglavljeDataTable();
        base.Tables.Add(this.tablesp_ip_zaglavlje);
        this.relationsp_ip_zaglavlje_sp_ip_detalji = new DataRelation("sp_ip_zaglavlje_sp_ip_detalji", new DataColumn[] { this.tablesp_ip_zaglavlje.JMBGColumn, this.tablesp_ip_zaglavlje.IDIPIDENTColumn }, new DataColumn[] { this.tablesp_ip_detalji.JMBGColumn, this.tablesp_ip_detalji.IDIPIDENTColumn }, false);
        this.Relations.Add(this.relationsp_ip_zaglavlje_sp_ip_detalji);
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
        this.tablesp_ip_detalji = (sp_ip_detaljiDataTable) base.Tables["sp_ip_detalji"];
        if (initTable && (this.tablesp_ip_detalji != null))
        {
            this.tablesp_ip_detalji.InitVars();
        }
        this.tablesp_ip_zaglavlje = (sp_ip_zaglavljeDataTable) base.Tables["sp_ip_zaglavlje"];
        if (initTable && (this.tablesp_ip_zaglavlje != null))
        {
            this.tablesp_ip_zaglavlje.InitVars();
        }
        this.relationsp_ip_zaglavlje_sp_ip_detalji = this.Relations["sp_ip_zaglavlje_sp_ip_detalji"];
    }

    
    protected override void ReadXmlSerializable(XmlReader reader)
    {
        if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["sp_ip_detalji"] != null)
            {
                base.Tables.Add(new sp_ip_detaljiDataTable(dataSet.Tables["sp_ip_detalji"]));
            }
            if (dataSet.Tables["sp_ip_zaglavlje"] != null)
            {
                base.Tables.Add(new sp_ip_zaglavljeDataTable(dataSet.Tables["sp_ip_zaglavlje"]));
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

    
    private bool ShouldSerializesp_ip_detalji()
    {
        return false;
    }

    
    private bool ShouldSerializesp_ip_zaglavlje()
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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), DebuggerNonUserCode]
    public sp_ip_detaljiDataTable sp_ip_detalji
    {
        get
        {
            return this.tablesp_ip_detalji;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), DebuggerNonUserCode]
    public sp_ip_zaglavljeDataTable sp_ip_zaglavlje
    {
        get
        {
            return this.tablesp_ip_zaglavlje;
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
    public class sp_ip_detaljiDataTable : TypedTableBase<dsIPObrazac.sp_ip_detaljiRow>
    {
        private DataColumn columndohodak;
        private DataColumn columnIDIPIDENT;
        private DataColumn columnidopcinestanovanja;
        private DataColumn columnIDRADNIK;
        private DataColumn columnJMBG;
        private DataColumn columnMJESECISPLATE;
        private DataColumn columnnetoisplata;
        private DataColumn columnNETOPLACA;
        private DataColumn columnOIB;
        private DataColumn columnPOREZKRIZNI;
        private DataColumn columnporeznaosnovica;
        private DataColumn columnukupnobruto;
        private DataColumn columnukupnodoprinosi;
        private DataColumn columnUKUPNOOO;
        private DataColumn columnukupnoporeziprirez;
        private DataColumn columnukupnoporeznopriznateolaksice;

        public event dsIPObrazac.sp_ip_detaljiRowChangeEventHandler sp_ip_detaljiRowChanged;

        public event dsIPObrazac.sp_ip_detaljiRowChangeEventHandler sp_ip_detaljiRowChanging;

        public event dsIPObrazac.sp_ip_detaljiRowChangeEventHandler sp_ip_detaljiRowDeleted;

        public event dsIPObrazac.sp_ip_detaljiRowChangeEventHandler sp_ip_detaljiRowDeleting;

        
        public sp_ip_detaljiDataTable()
        {
            base.ColumnChanging += new DataColumnChangeEventHandler(this.sp_ip_detaljiDataTable_ColumnChanging);
            this.TableName = "sp_ip_detalji";
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        
        internal sp_ip_detaljiDataTable(DataTable table)
        {
            base.ColumnChanging += new DataColumnChangeEventHandler(this.sp_ip_detaljiDataTable_ColumnChanging);
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

        
        protected sp_ip_detaljiDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            base.ColumnChanging += new DataColumnChangeEventHandler(this.sp_ip_detaljiDataTable_ColumnChanging);
            this.InitVars();
        }

        
        public void Addsp_ip_detaljiRow(dsIPObrazac.sp_ip_detaljiRow row)
        {
            this.Rows.Add(row);
        }

        
        public dsIPObrazac.sp_ip_detaljiRow Addsp_ip_detaljiRow(int IDRADNIK, string JMBG, int IDIPIDENT, string MJESECISPLATE, string idopcinestanovanja, decimal ukupnobruto, decimal ukupnodoprinosi, decimal ukupnoporeznopriznateolaksice, decimal dohodak, decimal UKUPNOOO, decimal poreznaosnovica, decimal ukupnoporeziprirez, decimal netoisplata, string OIB, decimal POREZKRIZNI, decimal NETOPLACA)
        {
            dsIPObrazac.sp_ip_detaljiRow row = (dsIPObrazac.sp_ip_detaljiRow) this.NewRow();
            row.ItemArray = new object[] { IDRADNIK, JMBG, IDIPIDENT, MJESECISPLATE, idopcinestanovanja, ukupnobruto, ukupnodoprinosi, ukupnoporeznopriznateolaksice, dohodak, UKUPNOOO, poreznaosnovica, ukupnoporeziprirez, netoisplata, OIB, POREZKRIZNI, NETOPLACA };
            this.Rows.Add(row);
            return row;
        }

        
        public override DataTable Clone()
        {
            dsIPObrazac.sp_ip_detaljiDataTable table = (dsIPObrazac.sp_ip_detaljiDataTable) base.Clone();
            table.InitVars();
            return table;
        }

        
        protected override DataTable CreateInstance()
        {
            return new dsIPObrazac.sp_ip_detaljiDataTable();
        }

        
        protected override Type GetRowType()
        {
            return typeof(dsIPObrazac.sp_ip_detaljiRow);
        }

        
        public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
        {
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            dsIPObrazac obrazac = new dsIPObrazac();
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
                FixedValue = "sp_ip_detaljiDataTable"
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
            this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnIDRADNIK);
            this.columnJMBG = new DataColumn("JMBG", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnJMBG);
            this.columnIDIPIDENT = new DataColumn("IDIPIDENT", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnIDIPIDENT);
            this.columnMJESECISPLATE = new DataColumn("MJESECISPLATE", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnMJESECISPLATE);
            this.columnidopcinestanovanja = new DataColumn("idopcinestanovanja", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnidopcinestanovanja);
            this.columnukupnobruto = new DataColumn("ukupnobruto", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnukupnobruto);
            this.columnukupnodoprinosi = new DataColumn("ukupnodoprinosi", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnukupnodoprinosi);
            this.columnukupnoporeznopriznateolaksice = new DataColumn("ukupnoporeznopriznateolaksice", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnukupnoporeznopriznateolaksice);
            this.columndohodak = new DataColumn("dohodak", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columndohodak);
            this.columnUKUPNOOO = new DataColumn("UKUPNOOO", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNOOO);
            this.columnporeznaosnovica = new DataColumn("poreznaosnovica", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnporeznaosnovica);
            this.columnukupnoporeziprirez = new DataColumn("ukupnoporeziprirez", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnukupnoporeziprirez);
            this.columnnetoisplata = new DataColumn("netoisplata", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnnetoisplata);
            this.columnOIB = new DataColumn("OIB", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnOIB);
            this.columnPOREZKRIZNI = new DataColumn("POREZKRIZNI", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnPOREZKRIZNI);
            this.columnNETOPLACA = new DataColumn("NETOPLACA", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnNETOPLACA);
            this.columnIDRADNIK.AllowDBNull = false;
            this.columnIDRADNIK.DefaultValue = 0;
            this.columnJMBG.AllowDBNull = false;
            this.columnJMBG.DefaultValue = "";
            this.columnIDIPIDENT.AllowDBNull = false;
            this.columnIDIPIDENT.DefaultValue = 0;
            this.columnMJESECISPLATE.AllowDBNull = false;
            this.columnMJESECISPLATE.DefaultValue = "";
            this.columnidopcinestanovanja.AllowDBNull = false;
            this.columnidopcinestanovanja.DefaultValue = "";
            this.columnukupnobruto.AllowDBNull = false;
            this.columnukupnobruto.DefaultValue = decimal.Zero;
            this.columnukupnodoprinosi.AllowDBNull = false;
            this.columnukupnodoprinosi.DefaultValue = decimal.Zero;
            this.columnukupnoporeznopriznateolaksice.AllowDBNull = false;
            this.columnukupnoporeznopriznateolaksice.DefaultValue = decimal.Zero;
            this.columndohodak.AllowDBNull = false;
            this.columndohodak.DefaultValue = decimal.Zero;
            this.columnUKUPNOOO.AllowDBNull = false;
            this.columnUKUPNOOO.DefaultValue = decimal.Zero;
            this.columnporeznaosnovica.AllowDBNull = false;
            this.columnporeznaosnovica.DefaultValue = decimal.Zero;
            this.columnukupnoporeziprirez.AllowDBNull = false;
            this.columnukupnoporeziprirez.DefaultValue = decimal.Zero;
            this.columnnetoisplata.AllowDBNull = false;
            this.columnnetoisplata.DefaultValue = decimal.Zero;
        }

        
        internal void InitVars()
        {
            this.columnIDRADNIK = base.Columns["IDRADNIK"];
            this.columnJMBG = base.Columns["JMBG"];
            this.columnIDIPIDENT = base.Columns["IDIPIDENT"];
            this.columnMJESECISPLATE = base.Columns["MJESECISPLATE"];
            this.columnidopcinestanovanja = base.Columns["idopcinestanovanja"];
            this.columnukupnobruto = base.Columns["ukupnobruto"];
            this.columnukupnodoprinosi = base.Columns["ukupnodoprinosi"];
            this.columnukupnoporeznopriznateolaksice = base.Columns["ukupnoporeznopriznateolaksice"];
            this.columndohodak = base.Columns["dohodak"];
            this.columnUKUPNOOO = base.Columns["UKUPNOOO"];
            this.columnporeznaosnovica = base.Columns["poreznaosnovica"];
            this.columnukupnoporeziprirez = base.Columns["ukupnoporeziprirez"];
            this.columnnetoisplata = base.Columns["netoisplata"];
            this.columnOIB = base.Columns["OIB"];
            this.columnPOREZKRIZNI = base.Columns["POREZKRIZNI"];
            this.columnNETOPLACA = base.Columns["NETOPLACA"];
        }

        
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new dsIPObrazac.sp_ip_detaljiRow(builder);
        }

        
        public dsIPObrazac.sp_ip_detaljiRow Newsp_ip_detaljiRow()
        {
            return (dsIPObrazac.sp_ip_detaljiRow) this.NewRow();
        }

        
        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            if (this.sp_ip_detaljiRowChanged != null)
            {
                dsIPObrazac.sp_ip_detaljiRowChangeEventHandler handler = this.sp_ip_detaljiRowChanged;
                if (handler != null)
                {
                    handler(this, new dsIPObrazac.sp_ip_detaljiRowChangeEvent((dsIPObrazac.sp_ip_detaljiRow) e.Row, e.Action));
                }
            }
        }

        
        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
            if (this.sp_ip_detaljiRowChanging != null)
            {
                dsIPObrazac.sp_ip_detaljiRowChangeEventHandler handler = this.sp_ip_detaljiRowChanging;
                if (handler != null)
                {
                    handler(this, new dsIPObrazac.sp_ip_detaljiRowChangeEvent((dsIPObrazac.sp_ip_detaljiRow) e.Row, e.Action));
                }
            }
        }

        
        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);
            if (this.sp_ip_detaljiRowDeleted != null)
            {
                dsIPObrazac.sp_ip_detaljiRowChangeEventHandler handler = this.sp_ip_detaljiRowDeleted;
                if (handler != null)
                {
                    handler(this, new dsIPObrazac.sp_ip_detaljiRowChangeEvent((dsIPObrazac.sp_ip_detaljiRow) e.Row, e.Action));
                }
            }
        }

        
        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {
            base.OnRowDeleting(e);
            if (this.sp_ip_detaljiRowDeleting != null)
            {
                dsIPObrazac.sp_ip_detaljiRowChangeEventHandler handler = this.sp_ip_detaljiRowDeleting;
                if (handler != null)
                {
                    handler(this, new dsIPObrazac.sp_ip_detaljiRowChangeEvent((dsIPObrazac.sp_ip_detaljiRow) e.Row, e.Action));
                }
            }
        }

        
        public void Removesp_ip_detaljiRow(dsIPObrazac.sp_ip_detaljiRow row)
        {
            this.Rows.Remove(row);
        }

        private void sp_ip_detaljiDataTable_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == this.netoisplataColumn.ColumnName)
            {
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

        
        public DataColumn dohodakColumn
        {
            get
            {
                return this.columndohodak;
            }
        }

        
        public DataColumn IDIPIDENTColumn
        {
            get
            {
                return this.columnIDIPIDENT;
            }
        }

        
        public DataColumn idopcinestanovanjaColumn
        {
            get
            {
                return this.columnidopcinestanovanja;
            }
        }

        
        public DataColumn IDRADNIKColumn
        {
            get
            {
                return this.columnIDRADNIK;
            }
        }

        
        public dsIPObrazac.sp_ip_detaljiRow this[int index]
        {
            get
            {
                return (dsIPObrazac.sp_ip_detaljiRow) this.Rows[index];
            }
        }

        
        public DataColumn JMBGColumn
        {
            get
            {
                return this.columnJMBG;
            }
        }

        
        public DataColumn MJESECISPLATEColumn
        {
            get
            {
                return this.columnMJESECISPLATE;
            }
        }

        
        public DataColumn netoisplataColumn
        {
            get
            {
                return this.columnnetoisplata;
            }
        }

        
        public DataColumn NETOPLACAColumn
        {
            get
            {
                return this.columnNETOPLACA;
            }
        }

        
        public DataColumn OIBColumn
        {
            get
            {
                return this.columnOIB;
            }
        }

        
        public DataColumn POREZKRIZNIColumn
        {
            get
            {
                return this.columnPOREZKRIZNI;
            }
        }

        
        public DataColumn poreznaosnovicaColumn
        {
            get
            {
                return this.columnporeznaosnovica;
            }
        }

        
        public DataColumn ukupnobrutoColumn
        {
            get
            {
                return this.columnukupnobruto;
            }
        }

        
        public DataColumn ukupnodoprinosiColumn
        {
            get
            {
                return this.columnukupnodoprinosi;
            }
        }

        
        public DataColumn UKUPNOOOColumn
        {
            get
            {
                return this.columnUKUPNOOO;
            }
        }

        
        public DataColumn ukupnoporeziprirezColumn
        {
            get
            {
                return this.columnukupnoporeziprirez;
            }
        }

        
        public DataColumn ukupnoporeznopriznateolaksiceColumn
        {
            get
            {
                return this.columnukupnoporeznopriznateolaksice;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class sp_ip_detaljiRow : DataRow
    {
        private dsIPObrazac.sp_ip_detaljiDataTable tablesp_ip_detalji;

        
        internal sp_ip_detaljiRow(DataRowBuilder rb) : base(rb)
        {
            this.tablesp_ip_detalji = (dsIPObrazac.sp_ip_detaljiDataTable) this.Table;
        }

        
        public bool IsNETOPLACANull()
        {
            return this.IsNull(this.tablesp_ip_detalji.NETOPLACAColumn);
        }

        
        public bool IsOIBNull()
        {
            return this.IsNull(this.tablesp_ip_detalji.OIBColumn);
        }

        
        public bool IsPOREZKRIZNINull()
        {
            return this.IsNull(this.tablesp_ip_detalji.POREZKRIZNIColumn);
        }

        
        public void SetNETOPLACANull()
        {
            this[this.tablesp_ip_detalji.NETOPLACAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        
        public void SetOIBNull()
        {
            this[this.tablesp_ip_detalji.OIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        
        public void SetPOREZKRIZNINull()
        {
            this[this.tablesp_ip_detalji.POREZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        
        public decimal dohodak
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_ip_detalji.dohodakColumn]);
            }
            set
            {
                this[this.tablesp_ip_detalji.dohodakColumn] = value;
            }
        }

        
        public int IDIPIDENT
        {
            get
            {
                return Conversions.ToInteger(this[this.tablesp_ip_detalji.IDIPIDENTColumn]);
            }
            set
            {
                this[this.tablesp_ip_detalji.IDIPIDENTColumn] = value;
            }
        }

        
        public string idopcinestanovanja
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_ip_detalji.idopcinestanovanjaColumn]);
            }
            set
            {
                this[this.tablesp_ip_detalji.idopcinestanovanjaColumn] = value;
            }
        }

        
        public int IDRADNIK
        {
            get
            {
                return Conversions.ToInteger(this[this.tablesp_ip_detalji.IDRADNIKColumn]);
            }
            set
            {
                this[this.tablesp_ip_detalji.IDRADNIKColumn] = value;
            }
        }

        
        public string JMBG
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_ip_detalji.JMBGColumn]);
            }
            set
            {
                this[this.tablesp_ip_detalji.JMBGColumn] = value;
            }
        }

        
        public string MJESECISPLATE
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_ip_detalji.MJESECISPLATEColumn]);
            }
            set
            {
                this[this.tablesp_ip_detalji.MJESECISPLATEColumn] = value;
            }
        }

        
        public decimal netoisplata
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_ip_detalji.netoisplataColumn]);
            }
            set
            {
                this[this.tablesp_ip_detalji.netoisplataColumn] = value;
            }
        }

        
        public decimal NETOPLACA
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tablesp_ip_detalji.NETOPLACAColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'NETOPLACA' in table 'sp_ip_detalji' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tablesp_ip_detalji.NETOPLACAColumn] = value;
            }
        }

        
        public string OIB
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tablesp_ip_detalji.OIBColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'OIB' in table 'sp_ip_detalji' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tablesp_ip_detalji.OIBColumn] = value;
            }
        }

        
        public decimal POREZKRIZNI
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tablesp_ip_detalji.POREZKRIZNIColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'POREZKRIZNI' in table 'sp_ip_detalji' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tablesp_ip_detalji.POREZKRIZNIColumn] = value;
            }
        }

        
        public decimal poreznaosnovica
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_ip_detalji.poreznaosnovicaColumn]);
            }
            set
            {
                this[this.tablesp_ip_detalji.poreznaosnovicaColumn] = value;
            }
        }

        
        public dsIPObrazac.sp_ip_zaglavljeRow sp_ip_zaglavljeRowParent
        {
            get
            {
                return (dsIPObrazac.sp_ip_zaglavljeRow) this.GetParentRow(this.Table.ParentRelations["sp_ip_zaglavlje_sp_ip_detalji"]);
            }
            set
            {
                this.SetParentRow(value, this.Table.ParentRelations["sp_ip_zaglavlje_sp_ip_detalji"]);
            }
        }

        
        public decimal ukupnobruto
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_ip_detalji.ukupnobrutoColumn]);
            }
            set
            {
                this[this.tablesp_ip_detalji.ukupnobrutoColumn] = value;
            }
        }

        
        public decimal ukupnodoprinosi
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_ip_detalji.ukupnodoprinosiColumn]);
            }
            set
            {
                this[this.tablesp_ip_detalji.ukupnodoprinosiColumn] = value;
            }
        }

        
        public decimal UKUPNOOO
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_ip_detalji.UKUPNOOOColumn]);
            }
            set
            {
                this[this.tablesp_ip_detalji.UKUPNOOOColumn] = value;
            }
        }

        
        public decimal ukupnoporeziprirez
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_ip_detalji.ukupnoporeziprirezColumn]);
            }
            set
            {
                this[this.tablesp_ip_detalji.ukupnoporeziprirezColumn] = value;
            }
        }

        
        public decimal ukupnoporeznopriznateolaksice
        {
            get
            {
                return Conversions.ToDecimal(this[this.tablesp_ip_detalji.ukupnoporeznopriznateolaksiceColumn]);
            }
            set
            {
                this[this.tablesp_ip_detalji.ukupnoporeznopriznateolaksiceColumn] = value;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class sp_ip_detaljiRowChangeEvent : EventArgs
    {
        private DataRowAction eventAction;
        private dsIPObrazac.sp_ip_detaljiRow eventRow;

        
        public sp_ip_detaljiRowChangeEvent(dsIPObrazac.sp_ip_detaljiRow row, DataRowAction action)
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

        
        public dsIPObrazac.sp_ip_detaljiRow Row
        {
            get
            {
                return this.eventRow;
            }
        }
    }

    public delegate void sp_ip_detaljiRowChangeEventHandler(object sender, dsIPObrazac.sp_ip_detaljiRowChangeEvent e);

    [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedTableSchema")]
    public class sp_ip_zaglavljeDataTable : TypedTableBase<dsIPObrazac.sp_ip_zaglavljeRow>
    {
        private DataColumn columnADRESA;
        private DataColumn columnIDIPIDENT;
        private DataColumn columnIDRADNIK;
        private DataColumn columnIME;
        private DataColumn columnisplataugodini;
        private DataColumn columnisplatazagodinu;
        private DataColumn columnJMBG;
        private DataColumn columnOIB;
        private DataColumn columnOZNACEN;
        private DataColumn columnPREZIME;

        public event dsIPObrazac.sp_ip_zaglavljeRowChangeEventHandler sp_ip_zaglavljeRowChanged;

        public event dsIPObrazac.sp_ip_zaglavljeRowChangeEventHandler sp_ip_zaglavljeRowChanging;

        public event dsIPObrazac.sp_ip_zaglavljeRowChangeEventHandler sp_ip_zaglavljeRowDeleted;

        public event dsIPObrazac.sp_ip_zaglavljeRowChangeEventHandler sp_ip_zaglavljeRowDeleting;

        
        public sp_ip_zaglavljeDataTable()
        {
            this.sp_ip_zaglavljeRowChanging += new dsIPObrazac.sp_ip_zaglavljeRowChangeEventHandler(this.sp_ip_zaglavljeDataTable_sp_ip_zaglavljeRowChanging);
            this.TableName = "sp_ip_zaglavlje";
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        
        internal sp_ip_zaglavljeDataTable(DataTable table)
        {
            this.sp_ip_zaglavljeRowChanging += new dsIPObrazac.sp_ip_zaglavljeRowChangeEventHandler(this.sp_ip_zaglavljeDataTable_sp_ip_zaglavljeRowChanging);
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

        
        protected sp_ip_zaglavljeDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.sp_ip_zaglavljeRowChanging += new dsIPObrazac.sp_ip_zaglavljeRowChangeEventHandler(this.sp_ip_zaglavljeDataTable_sp_ip_zaglavljeRowChanging);
            this.InitVars();
        }

        
        public void Addsp_ip_zaglavljeRow(dsIPObrazac.sp_ip_zaglavljeRow row)
        {
            this.Rows.Add(row);
        }

        
        public dsIPObrazac.sp_ip_zaglavljeRow Addsp_ip_zaglavljeRow(bool OZNACEN, int IDIPIDENT, int IDRADNIK, string JMBG, string PREZIME, string IME, string ADRESA, string isplataugodini, string isplatazagodinu, string OIB)
        {
            dsIPObrazac.sp_ip_zaglavljeRow row = (dsIPObrazac.sp_ip_zaglavljeRow) this.NewRow();
            row.ItemArray = new object[] { OZNACEN, IDIPIDENT, IDRADNIK, JMBG, PREZIME, IME, ADRESA, isplataugodini, isplatazagodinu, OIB };
            this.Rows.Add(row);
            return row;
        }

        
        public override DataTable Clone()
        {
            dsIPObrazac.sp_ip_zaglavljeDataTable table = (dsIPObrazac.sp_ip_zaglavljeDataTable) base.Clone();
            table.InitVars();
            return table;
        }

        
        protected override DataTable CreateInstance()
        {
            return new dsIPObrazac.sp_ip_zaglavljeDataTable();
        }

        
        protected override Type GetRowType()
        {
            return typeof(dsIPObrazac.sp_ip_zaglavljeRow);
        }

        
        public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
        {
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            dsIPObrazac obrazac = new dsIPObrazac();
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
                FixedValue = "sp_ip_zaglavljeDataTable"
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
            this.columnOZNACEN = new DataColumn("OZNACEN", typeof(bool), null, MappingType.Element);
            base.Columns.Add(this.columnOZNACEN);
            this.columnIDIPIDENT = new DataColumn("IDIPIDENT", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnIDIPIDENT);
            this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnIDRADNIK);
            this.columnJMBG = new DataColumn("JMBG", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnJMBG);
            this.columnPREZIME = new DataColumn("PREZIME", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnPREZIME);
            this.columnIME = new DataColumn("IME", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnIME);
            this.columnADRESA = new DataColumn("ADRESA", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnADRESA);
            this.columnisplataugodini = new DataColumn("isplataugodini", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnisplataugodini);
            this.columnisplatazagodinu = new DataColumn("isplatazagodinu", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnisplatazagodinu);
            this.columnOIB = new DataColumn("OIB", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnOIB);
            this.columnOZNACEN.AllowDBNull = false;
            this.columnIDIPIDENT.AllowDBNull = false;
            this.columnIDIPIDENT.DefaultValue = 0;
            this.columnIDRADNIK.AllowDBNull = false;
            this.columnIDRADNIK.DefaultValue = 0;
            this.columnJMBG.AllowDBNull = false;
            this.columnJMBG.DefaultValue = "";
            this.columnPREZIME.AllowDBNull = false;
            this.columnPREZIME.DefaultValue = "";
            this.columnIME.AllowDBNull = false;
            this.columnIME.DefaultValue = "";
            this.columnADRESA.AllowDBNull = false;
            this.columnADRESA.DefaultValue = "";
            this.columnisplataugodini.AllowDBNull = false;
            this.columnisplataugodini.DefaultValue = "";
            this.columnisplatazagodinu.AllowDBNull = false;
            this.columnisplatazagodinu.DefaultValue = "";
        }

        
        internal void InitVars()
        {
            this.columnOZNACEN = base.Columns["OZNACEN"];
            this.columnIDIPIDENT = base.Columns["IDIPIDENT"];
            this.columnIDRADNIK = base.Columns["IDRADNIK"];
            this.columnJMBG = base.Columns["JMBG"];
            this.columnPREZIME = base.Columns["PREZIME"];
            this.columnIME = base.Columns["IME"];
            this.columnADRESA = base.Columns["ADRESA"];
            this.columnisplataugodini = base.Columns["isplataugodini"];
            this.columnisplatazagodinu = base.Columns["isplatazagodinu"];
            this.columnOIB = base.Columns["OIB"];
        }

        
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new dsIPObrazac.sp_ip_zaglavljeRow(builder);
        }

        
        public dsIPObrazac.sp_ip_zaglavljeRow Newsp_ip_zaglavljeRow()
        {
            return (dsIPObrazac.sp_ip_zaglavljeRow) this.NewRow();
        }

        
        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            if (this.sp_ip_zaglavljeRowChanged != null)
            {
                dsIPObrazac.sp_ip_zaglavljeRowChangeEventHandler handler = this.sp_ip_zaglavljeRowChanged;
                if (handler != null)
                {
                    handler(this, new dsIPObrazac.sp_ip_zaglavljeRowChangeEvent((dsIPObrazac.sp_ip_zaglavljeRow) e.Row, e.Action));
                }
            }
        }

        
        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
            if (this.sp_ip_zaglavljeRowChanging != null)
            {
                dsIPObrazac.sp_ip_zaglavljeRowChangeEventHandler handler = this.sp_ip_zaglavljeRowChanging;
                if (handler != null)
                {
                    handler(this, new dsIPObrazac.sp_ip_zaglavljeRowChangeEvent((dsIPObrazac.sp_ip_zaglavljeRow) e.Row, e.Action));
                }
            }
        }

        
        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);
            if (this.sp_ip_zaglavljeRowDeleted != null)
            {
                dsIPObrazac.sp_ip_zaglavljeRowChangeEventHandler handler = this.sp_ip_zaglavljeRowDeleted;
                if (handler != null)
                {
                    handler(this, new dsIPObrazac.sp_ip_zaglavljeRowChangeEvent((dsIPObrazac.sp_ip_zaglavljeRow) e.Row, e.Action));
                }
            }
        }

        
        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {
            base.OnRowDeleting(e);
            if (this.sp_ip_zaglavljeRowDeleting != null)
            {
                dsIPObrazac.sp_ip_zaglavljeRowChangeEventHandler handler = this.sp_ip_zaglavljeRowDeleting;
                if (handler != null)
                {
                    handler(this, new dsIPObrazac.sp_ip_zaglavljeRowChangeEvent((dsIPObrazac.sp_ip_zaglavljeRow) e.Row, e.Action));
                }
            }
        }

        
        public void Removesp_ip_zaglavljeRow(dsIPObrazac.sp_ip_zaglavljeRow row)
        {
            this.Rows.Remove(row);
        }

        private void sp_ip_zaglavljeDataTable_sp_ip_zaglavljeRowChanging(object sender, dsIPObrazac.sp_ip_zaglavljeRowChangeEvent e)
        {
        }

        
        public DataColumn ADRESAColumn
        {
            get
            {
                return this.columnADRESA;
            }
        }

        [Browsable(false), DebuggerNonUserCode]
        public int Count
        {
            get
            {
                return this.Rows.Count;
            }
        }

        
        public DataColumn IDIPIDENTColumn
        {
            get
            {
                return this.columnIDIPIDENT;
            }
        }

        
        public DataColumn IDRADNIKColumn
        {
            get
            {
                return this.columnIDRADNIK;
            }
        }

        
        public DataColumn IMEColumn
        {
            get
            {
                return this.columnIME;
            }
        }

        
        public DataColumn isplataugodiniColumn
        {
            get
            {
                return this.columnisplataugodini;
            }
        }

        
        public DataColumn isplatazagodinuColumn
        {
            get
            {
                return this.columnisplatazagodinu;
            }
        }

        
        public dsIPObrazac.sp_ip_zaglavljeRow this[int index]
        {
            get
            {
                return (dsIPObrazac.sp_ip_zaglavljeRow) this.Rows[index];
            }
        }

        
        public DataColumn JMBGColumn
        {
            get
            {
                return this.columnJMBG;
            }
        }

        
        public DataColumn OIBColumn
        {
            get
            {
                return this.columnOIB;
            }
        }

        
        public DataColumn OZNACENColumn
        {
            get
            {
                return this.columnOZNACEN;
            }
        }

        
        public DataColumn PREZIMEColumn
        {
            get
            {
                return this.columnPREZIME;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class sp_ip_zaglavljeRow : DataRow
    {
        private dsIPObrazac.sp_ip_zaglavljeDataTable tablesp_ip_zaglavlje;

        
        internal sp_ip_zaglavljeRow(DataRowBuilder rb) : base(rb)
        {
            this.tablesp_ip_zaglavlje = (dsIPObrazac.sp_ip_zaglavljeDataTable) this.Table;
        }

        
        public dsIPObrazac.sp_ip_detaljiRow[] Getsp_ip_detaljiRows()
        {
            if (this.Table.ChildRelations["sp_ip_zaglavlje_sp_ip_detalji"] == null)
            {
                return new dsIPObrazac.sp_ip_detaljiRow[0];
            }
            return (dsIPObrazac.sp_ip_detaljiRow[]) base.GetChildRows(this.Table.ChildRelations["sp_ip_zaglavlje_sp_ip_detalji"]);
        }

        
        public bool IsOIBNull()
        {
            return this.IsNull(this.tablesp_ip_zaglavlje.OIBColumn);
        }

        
        public void SetOIBNull()
        {
            this[this.tablesp_ip_zaglavlje.OIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        
        public string ADRESA
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_ip_zaglavlje.ADRESAColumn]);
            }
            set
            {
                this[this.tablesp_ip_zaglavlje.ADRESAColumn] = value;
            }
        }

        
        public int IDIPIDENT
        {
            get
            {
                return Conversions.ToInteger(this[this.tablesp_ip_zaglavlje.IDIPIDENTColumn]);
            }
            set
            {
                this[this.tablesp_ip_zaglavlje.IDIPIDENTColumn] = value;
            }
        }

        
        public int IDRADNIK
        {
            get
            {
                return Conversions.ToInteger(this[this.tablesp_ip_zaglavlje.IDRADNIKColumn]);
            }
            set
            {
                this[this.tablesp_ip_zaglavlje.IDRADNIKColumn] = value;
            }
        }

        
        public string IME
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_ip_zaglavlje.IMEColumn]);
            }
            set
            {
                this[this.tablesp_ip_zaglavlje.IMEColumn] = value;
            }
        }

        
        public string isplataugodini
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_ip_zaglavlje.isplataugodiniColumn]);
            }
            set
            {
                this[this.tablesp_ip_zaglavlje.isplataugodiniColumn] = value;
            }
        }

        
        public string isplatazagodinu
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_ip_zaglavlje.isplatazagodinuColumn]);
            }
            set
            {
                this[this.tablesp_ip_zaglavlje.isplatazagodinuColumn] = value;
            }
        }

        
        public string JMBG
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_ip_zaglavlje.JMBGColumn]);
            }
            set
            {
                this[this.tablesp_ip_zaglavlje.JMBGColumn] = value;
            }
        }

        
        public string OIB
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tablesp_ip_zaglavlje.OIBColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'OIB' in table 'sp_ip_zaglavlje' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tablesp_ip_zaglavlje.OIBColumn] = value;
            }
        }

        
        public bool OZNACEN
        {
            get
            {
                return Conversions.ToBoolean(this[this.tablesp_ip_zaglavlje.OZNACENColumn]);
            }
            set
            {
                this[this.tablesp_ip_zaglavlje.OZNACENColumn] = value;
            }
        }

        
        public string PREZIME
        {
            get
            {
                return Conversions.ToString(this[this.tablesp_ip_zaglavlje.PREZIMEColumn]);
            }
            set
            {
                this[this.tablesp_ip_zaglavlje.PREZIMEColumn] = value;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class sp_ip_zaglavljeRowChangeEvent : EventArgs
    {
        private DataRowAction eventAction;
        private dsIPObrazac.sp_ip_zaglavljeRow eventRow;

        
        public sp_ip_zaglavljeRowChangeEvent(dsIPObrazac.sp_ip_zaglavljeRow row, DataRowAction action)
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

        
        public dsIPObrazac.sp_ip_zaglavljeRow Row
        {
            get
            {
                return this.eventRow;
            }
        }
    }

    public delegate void sp_ip_zaglavljeRowChangeEventHandler(object sender, dsIPObrazac.sp_ip_zaglavljeRowChangeEvent e);
}

