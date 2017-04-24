using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

[Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlRoot("dsIspisRadnik"), XmlSchemaProvider("GetTypedDataSetSchema"), HelpKeyword("vs.data.DataSet"), DesignerCategory("code"), ToolboxItem(true)]
public class dsIspisRadnik : DataSet
{
    private System.Data.SchemaSerializationMode _schemaSerializationMode;
    private V_OD_MATICNI_PODACI_RADNIKADataTable tableV_OD_MATICNI_PODACI_RADNIKA;

    [DebuggerNonUserCode]
    public dsIspisRadnik()
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
    protected dsIspisRadnik(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["V_OD_MATICNI_PODACI_RADNIKA"] != null)
                {
                    base.Tables.Add(new V_OD_MATICNI_PODACI_RADNIKADataTable(dataSet.Tables["V_OD_MATICNI_PODACI_RADNIKA"]));
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
        dsIspisRadnik radnik = (dsIspisRadnik) base.Clone();
        radnik.InitVars();
        radnik.SchemaSerializationMode = this.SchemaSerializationMode;
        return radnik;
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
        dsIspisRadnik radnik = new dsIspisRadnik();
        XmlSchemaComplexType type2 = new XmlSchemaComplexType();
        XmlSchemaSequence sequence = new XmlSchemaSequence();
        XmlSchemaAny item = new XmlSchemaAny {
            Namespace = radnik.Namespace
        };
        sequence.Items.Add(item);
        type2.Particle = sequence;
        XmlSchema schemaSerializable = radnik.GetSchemaSerializable();
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
        this.DataSetName = "dsIspisRadnik";
        this.Prefix = "";
        this.Namespace = "http://www.tempuri.org/dsIspisRadnik.xsd";
        this.Locale = new CultureInfo("hr-HR");
        this.EnforceConstraints = true;
        this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        this.tableV_OD_MATICNI_PODACI_RADNIKA = new V_OD_MATICNI_PODACI_RADNIKADataTable();
        base.Tables.Add(this.tableV_OD_MATICNI_PODACI_RADNIKA);
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
        this.tableV_OD_MATICNI_PODACI_RADNIKA = (V_OD_MATICNI_PODACI_RADNIKADataTable) base.Tables["V_OD_MATICNI_PODACI_RADNIKA"];
        if (initTable && (this.tableV_OD_MATICNI_PODACI_RADNIKA != null))
        {
            this.tableV_OD_MATICNI_PODACI_RADNIKA.InitVars();
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
            if (dataSet.Tables["V_OD_MATICNI_PODACI_RADNIKA"] != null)
            {
                base.Tables.Add(new V_OD_MATICNI_PODACI_RADNIKADataTable(dataSet.Tables["V_OD_MATICNI_PODACI_RADNIKA"]));
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
    protected override bool ShouldSerializeRelations()
    {
        return false;
    }

    [DebuggerNonUserCode]
    protected override bool ShouldSerializeTables()
    {
        return false;
    }

    [DebuggerNonUserCode]
    private bool ShouldSerializeV_OD_MATICNI_PODACI_RADNIKA()
    {
        return false;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode]
    public new DataRelationCollection Relations
    {
        get
        {
            return base.Relations;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true), DebuggerNonUserCode]
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

    [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
    public V_OD_MATICNI_PODACI_RADNIKADataTable V_OD_MATICNI_PODACI_RADNIKA
    {
        get
        {
            return this.tableV_OD_MATICNI_PODACI_RADNIKA;
        }
    }

    [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedTableSchema")]
    public class V_OD_MATICNI_PODACI_RADNIKADataTable : TypedTableBase<dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow>
    {
        private DataColumn columnAKTIVAN;
        private DataColumn columnBROJPRIZNATIHMJESECI;
        private DataColumn columnDANIJUBILARNA;
        private DataColumn columnDANISTAZA;
        private DataColumn columnDANISTAZAPRO;
        private DataColumn columnDANISTAZAUKUPNO;
        private DataColumn columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI;
        private DataColumn columnFAKTOROSOBNOGODBITKASUMARNO;
        private DataColumn columnGODINEJUBILARNA;
        private DataColumn columnGODINESTAZA;
        private DataColumn columnGODINESTAZAPRO;
        private DataColumn columnGODINESTAZAUKUPNO;
        private DataColumn columnIDRADNIK;
        private DataColumn columnIME;
        private DataColumn columnJMBG;
        private DataColumn columnKOEFICIJENT;
        private DataColumn columnMJESECIJUBILARNA;
        private DataColumn columnMJESECISTAZA;
        private DataColumn columnMJESECISTAZAPRO;
        private DataColumn columnMJESECISTAZAUKUPNO;
        private DataColumn columnNAZIVBANKE1;
        private DataColumn columnNAZIVSKUPPOREZAIDOPRINOSA;
        private DataColumn columnNAZIVSPOL;
        private DataColumn columnOIB;
        private DataColumn columnOPCINARADAIDOPCINE;
        private DataColumn columnOPCINASTANOVANJAIDOPCINE;
        private DataColumn columnPOSTOTAKOSLOBODJENJAODPOREZA;
        private DataColumn columnPREZIME;
        private DataColumn columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
        private DataColumn columnTEKUCI;
        private DataColumn columnTJEDNIFONDSATI;
        private DataColumn columnTJEDNIFONDSATISTAZ;
        private DataColumn columnZBIRNINETO;

        public event dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARowChangeEventHandler V_OD_MATICNI_PODACI_RADNIKARowChanged;

        public event dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARowChangeEventHandler V_OD_MATICNI_PODACI_RADNIKARowChanging;

        public event dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARowChangeEventHandler V_OD_MATICNI_PODACI_RADNIKARowDeleted;

        public event dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARowChangeEventHandler V_OD_MATICNI_PODACI_RADNIKARowDeleting;

        [DebuggerNonUserCode]
        public V_OD_MATICNI_PODACI_RADNIKADataTable()
        {
            this.TableName = "V_OD_MATICNI_PODACI_RADNIKA";
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        [DebuggerNonUserCode]
        internal V_OD_MATICNI_PODACI_RADNIKADataTable(DataTable table)
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
        protected V_OD_MATICNI_PODACI_RADNIKADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.InitVars();
        }

        [DebuggerNonUserCode]
        public void AddV_OD_MATICNI_PODACI_RADNIKARow(dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow row)
        {
            this.Rows.Add(row);
        }

        [DebuggerNonUserCode]
        public dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow AddV_OD_MATICNI_PODACI_RADNIKARow(int IDRADNIK, string PREZIME, string IME, string OPCINARADAIDOPCINE, string OPCINASTANOVANJAIDOPCINE, string NAZIVBANKE1, string TEKUCI, decimal FAKTOROSOBNOGODBITKASUMARNO, decimal TJEDNIFONDSATI, decimal KOEFICIJENT, int GODINESTAZA, int MJESECISTAZA, int DANISTAZA, DateTime DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, int RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, string NAZIVSKUPPOREZAIDOPRINOSA, string JMBG, decimal POSTOTAKOSLOBODJENJAODPOREZA, decimal TJEDNIFONDSATISTAZ, short BROJPRIZNATIHMJESECI, bool AKTIVAN, bool ZBIRNINETO, int GODINESTAZAUKUPNO, int MJESECISTAZAUKUPNO, int DANISTAZAUKUPNO, string OIB, string NAZIVSPOL, string GODINESTAZAPRO, string MJESECISTAZAPRO, string DANISTAZAPRO, string GODINEJUBILARNA, string MJESECIJUBILARNA, string DANIJUBILARNA)
        {
            dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow row = (dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow) this.NewRow();
            row.ItemArray = new object[] { 
                IDRADNIK, PREZIME, IME, OPCINARADAIDOPCINE, OPCINASTANOVANJAIDOPCINE, NAZIVBANKE1, TEKUCI, FAKTOROSOBNOGODBITKASUMARNO, TJEDNIFONDSATI, KOEFICIJENT, GODINESTAZA, MJESECISTAZA, DANISTAZA, DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, NAZIVSKUPPOREZAIDOPRINOSA, 
                JMBG, POSTOTAKOSLOBODJENJAODPOREZA, TJEDNIFONDSATISTAZ, BROJPRIZNATIHMJESECI, AKTIVAN, ZBIRNINETO, GODINESTAZAUKUPNO, MJESECISTAZAUKUPNO, DANISTAZAUKUPNO, OIB, NAZIVSPOL, GODINESTAZAPRO, MJESECISTAZAPRO, DANISTAZAPRO, GODINEJUBILARNA, MJESECIJUBILARNA, 
                DANIJUBILARNA
             };
            this.Rows.Add(row);
            return row;
        }

        [DebuggerNonUserCode]
        public override DataTable Clone()
        {
            dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKADataTable table = (dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKADataTable) base.Clone();
            table.InitVars();
            return table;
        }

        [DebuggerNonUserCode]
        protected override DataTable CreateInstance()
        {
            return new dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKADataTable();
        }

        [DebuggerNonUserCode]
        protected override Type GetRowType()
        {
            return typeof(dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow);
        }

        [DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
        {
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            dsIspisRadnik radnik = new dsIspisRadnik();
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
                FixedValue = radnik.Namespace
            };
            type2.Attributes.Add(attribute);
            XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                Name = "tableTypeName",
                FixedValue = "V_OD_MATICNI_PODACI_RADNIKADataTable"
            };
            type2.Attributes.Add(attribute2);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = radnik.GetSchemaSerializable();
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
            this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnIDRADNIK);
            this.columnPREZIME = new DataColumn("PREZIME", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnPREZIME);
            this.columnIME = new DataColumn("IME", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnIME);
            this.columnOPCINARADAIDOPCINE = new DataColumn("OPCINARADAIDOPCINE", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnOPCINARADAIDOPCINE);
            this.columnOPCINASTANOVANJAIDOPCINE = new DataColumn("OPCINASTANOVANJAIDOPCINE", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnOPCINASTANOVANJAIDOPCINE);
            this.columnNAZIVBANKE1 = new DataColumn("NAZIVBANKE1", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnNAZIVBANKE1);
            this.columnTEKUCI = new DataColumn("TEKUCI", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnTEKUCI);
            this.columnFAKTOROSOBNOGODBITKASUMARNO = new DataColumn("FAKTOROSOBNOGODBITKASUMARNO", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnFAKTOROSOBNOGODBITKASUMARNO);
            this.columnTJEDNIFONDSATI = new DataColumn("TJEDNIFONDSATI", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnTJEDNIFONDSATI);
            this.columnKOEFICIJENT = new DataColumn("KOEFICIJENT", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnKOEFICIJENT);
            this.columnGODINESTAZA = new DataColumn("GODINESTAZA", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnGODINESTAZA);
            this.columnMJESECISTAZA = new DataColumn("MJESECISTAZA", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnMJESECISTAZA);
            this.columnDANISTAZA = new DataColumn("DANISTAZA", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnDANISTAZA);
            this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = new DataColumn("DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI", typeof(DateTime), null, MappingType.Element);
            base.Columns.Add(this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI);
            this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = new DataColumn("RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA);
            this.columnNAZIVSKUPPOREZAIDOPRINOSA = new DataColumn("NAZIVSKUPPOREZAIDOPRINOSA", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnNAZIVSKUPPOREZAIDOPRINOSA);
            this.columnJMBG = new DataColumn("JMBG", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnJMBG);
            this.columnPOSTOTAKOSLOBODJENJAODPOREZA = new DataColumn("POSTOTAKOSLOBODJENJAODPOREZA", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnPOSTOTAKOSLOBODJENJAODPOREZA);
            this.columnTJEDNIFONDSATISTAZ = new DataColumn("TJEDNIFONDSATISTAZ", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnTJEDNIFONDSATISTAZ);
            this.columnBROJPRIZNATIHMJESECI = new DataColumn("BROJPRIZNATIHMJESECI", typeof(short), null, MappingType.Element);
            base.Columns.Add(this.columnBROJPRIZNATIHMJESECI);
            this.columnAKTIVAN = new DataColumn("AKTIVAN", typeof(bool), null, MappingType.Element);
            base.Columns.Add(this.columnAKTIVAN);
            this.columnZBIRNINETO = new DataColumn("ZBIRNINETO", typeof(bool), null, MappingType.Element);
            base.Columns.Add(this.columnZBIRNINETO);
            this.columnGODINESTAZAUKUPNO = new DataColumn("GODINESTAZAUKUPNO", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnGODINESTAZAUKUPNO);
            this.columnMJESECISTAZAUKUPNO = new DataColumn("MJESECISTAZAUKUPNO", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnMJESECISTAZAUKUPNO);
            this.columnDANISTAZAUKUPNO = new DataColumn("DANISTAZAUKUPNO", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnDANISTAZAUKUPNO);
            this.columnOIB = new DataColumn("OIB", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnOIB);
            this.columnNAZIVSPOL = new DataColumn("NAZIVSPOL", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnNAZIVSPOL);
            this.columnGODINESTAZAPRO = new DataColumn("GODINESTAZAPRO", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnGODINESTAZAPRO);
            this.columnMJESECISTAZAPRO = new DataColumn("MJESECISTAZAPRO", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnMJESECISTAZAPRO);
            this.columnDANISTAZAPRO = new DataColumn("DANISTAZAPRO", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnDANISTAZAPRO);
            this.columnGODINEJUBILARNA = new DataColumn("GODINEJUBILARNA", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnGODINEJUBILARNA);
            this.columnMJESECIJUBILARNA = new DataColumn("MJESECIJUBILARNA", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnMJESECIJUBILARNA);
            this.columnDANIJUBILARNA = new DataColumn("DANIJUBILARNA", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnDANIJUBILARNA);
            this.columnIDRADNIK.AllowDBNull = false;
            this.columnPREZIME.AllowDBNull = false;
            this.columnIME.AllowDBNull = false;
            this.columnOPCINARADAIDOPCINE.AllowDBNull = false;
            this.columnOPCINASTANOVANJAIDOPCINE.AllowDBNull = false;
            this.columnNAZIVBANKE1.AllowDBNull = false;
            this.columnTEKUCI.AllowDBNull = false;
            this.columnTJEDNIFONDSATI.AllowDBNull = false;
            this.columnKOEFICIJENT.AllowDBNull = false;
            this.columnGODINESTAZA.AllowDBNull = false;
            this.columnMJESECISTAZA.AllowDBNull = false;
            this.columnDANISTAZA.AllowDBNull = false;
            this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.AllowDBNull = false;
            this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.AllowDBNull = false;
            this.columnNAZIVSKUPPOREZAIDOPRINOSA.AllowDBNull = false;
            this.columnJMBG.AllowDBNull = false;
            this.columnPOSTOTAKOSLOBODJENJAODPOREZA.AllowDBNull = false;
            this.columnTJEDNIFONDSATISTAZ.AllowDBNull = false;
            this.columnAKTIVAN.AllowDBNull = false;
            this.columnZBIRNINETO.AllowDBNull = false;
        }

        [DebuggerNonUserCode]
        internal void InitVars()
        {
            this.columnIDRADNIK = base.Columns["IDRADNIK"];
            this.columnPREZIME = base.Columns["PREZIME"];
            this.columnIME = base.Columns["IME"];
            this.columnOPCINARADAIDOPCINE = base.Columns["OPCINARADAIDOPCINE"];
            this.columnOPCINASTANOVANJAIDOPCINE = base.Columns["OPCINASTANOVANJAIDOPCINE"];
            this.columnNAZIVBANKE1 = base.Columns["NAZIVBANKE1"];
            this.columnTEKUCI = base.Columns["TEKUCI"];
            this.columnFAKTOROSOBNOGODBITKASUMARNO = base.Columns["FAKTOROSOBNOGODBITKASUMARNO"];
            this.columnTJEDNIFONDSATI = base.Columns["TJEDNIFONDSATI"];
            this.columnKOEFICIJENT = base.Columns["KOEFICIJENT"];
            this.columnGODINESTAZA = base.Columns["GODINESTAZA"];
            this.columnMJESECISTAZA = base.Columns["MJESECISTAZA"];
            this.columnDANISTAZA = base.Columns["DANISTAZA"];
            this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = base.Columns["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"];
            this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = base.Columns["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"];
            this.columnNAZIVSKUPPOREZAIDOPRINOSA = base.Columns["NAZIVSKUPPOREZAIDOPRINOSA"];
            this.columnJMBG = base.Columns["JMBG"];
            this.columnPOSTOTAKOSLOBODJENJAODPOREZA = base.Columns["POSTOTAKOSLOBODJENJAODPOREZA"];
            this.columnTJEDNIFONDSATISTAZ = base.Columns["TJEDNIFONDSATISTAZ"];
            this.columnBROJPRIZNATIHMJESECI = base.Columns["BROJPRIZNATIHMJESECI"];
            this.columnAKTIVAN = base.Columns["AKTIVAN"];
            this.columnZBIRNINETO = base.Columns["ZBIRNINETO"];
            this.columnGODINESTAZAUKUPNO = base.Columns["GODINESTAZAUKUPNO"];
            this.columnMJESECISTAZAUKUPNO = base.Columns["MJESECISTAZAUKUPNO"];
            this.columnDANISTAZAUKUPNO = base.Columns["DANISTAZAUKUPNO"];
            this.columnOIB = base.Columns["OIB"];
            this.columnNAZIVSPOL = base.Columns["NAZIVSPOL"];
            this.columnGODINESTAZAPRO = base.Columns["GODINESTAZAPRO"];
            this.columnMJESECISTAZAPRO = base.Columns["MJESECISTAZAPRO"];
            this.columnDANISTAZAPRO = base.Columns["DANISTAZAPRO"];
            this.columnGODINEJUBILARNA = base.Columns["GODINEJUBILARNA"];
            this.columnMJESECIJUBILARNA = base.Columns["MJESECIJUBILARNA"];
            this.columnDANIJUBILARNA = base.Columns["DANIJUBILARNA"];
        }

        [DebuggerNonUserCode]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow(builder);
        }

        [DebuggerNonUserCode]
        public dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow NewV_OD_MATICNI_PODACI_RADNIKARow()
        {
            return (dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow) this.NewRow();
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            if (this.V_OD_MATICNI_PODACI_RADNIKARowChanged != null)
            {
                dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARowChangeEventHandler handler = this.V_OD_MATICNI_PODACI_RADNIKARowChanged;
                if (handler != null)
                {
                    handler(this, new dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARowChangeEvent((dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
            if (this.V_OD_MATICNI_PODACI_RADNIKARowChanging != null)
            {
                dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARowChangeEventHandler handler = this.V_OD_MATICNI_PODACI_RADNIKARowChanging;
                if (handler != null)
                {
                    handler(this, new dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARowChangeEvent((dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);
            if (this.V_OD_MATICNI_PODACI_RADNIKARowDeleted != null)
            {
                dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARowChangeEventHandler handler = this.V_OD_MATICNI_PODACI_RADNIKARowDeleted;
                if (handler != null)
                {
                    handler(this, new dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARowChangeEvent((dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {
            base.OnRowDeleting(e);
            if (this.V_OD_MATICNI_PODACI_RADNIKARowDeleting != null)
            {
                dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARowChangeEventHandler handler = this.V_OD_MATICNI_PODACI_RADNIKARowDeleted;
                if (handler != null)
                {
                    handler(this, new dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARowChangeEvent((dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        public void RemoveV_OD_MATICNI_PODACI_RADNIKARow(dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow row)
        {
            this.Rows.Remove(row);
        }

        [DebuggerNonUserCode]
        public DataColumn AKTIVANColumn
        {
            get
            {
                return this.columnAKTIVAN;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn BROJPRIZNATIHMJESECIColumn
        {
            get
            {
                return this.columnBROJPRIZNATIHMJESECI;
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

        [DebuggerNonUserCode]
        public DataColumn DANIJUBILARNAColumn
        {
            get
            {
                return this.columnDANIJUBILARNA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn DANISTAZAColumn
        {
            get
            {
                return this.columnDANISTAZA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn DANISTAZAPROColumn
        {
            get
            {
                return this.columnDANISTAZAPRO;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn DANISTAZAUKUPNOColumn
        {
            get
            {
                return this.columnDANISTAZAUKUPNO;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIColumn
        {
            get
            {
                return this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn FAKTOROSOBNOGODBITKASUMARNOColumn
        {
            get
            {
                return this.columnFAKTOROSOBNOGODBITKASUMARNO;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn GODINEJUBILARNAColumn
        {
            get
            {
                return this.columnGODINEJUBILARNA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn GODINESTAZAColumn
        {
            get
            {
                return this.columnGODINESTAZA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn GODINESTAZAPROColumn
        {
            get
            {
                return this.columnGODINESTAZAPRO;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn GODINESTAZAUKUPNOColumn
        {
            get
            {
                return this.columnGODINESTAZAUKUPNO;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn IDRADNIKColumn
        {
            get
            {
                return this.columnIDRADNIK;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn IMEColumn
        {
            get
            {
                return this.columnIME;
            }
        }

        [DebuggerNonUserCode]
        public dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow this[int index]
        {
            get
            {
                return (dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow) this.Rows[index];
            }
        }

        [DebuggerNonUserCode]
        public DataColumn JMBGColumn
        {
            get
            {
                return this.columnJMBG;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn KOEFICIJENTColumn
        {
            get
            {
                return this.columnKOEFICIJENT;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn MJESECIJUBILARNAColumn
        {
            get
            {
                return this.columnMJESECIJUBILARNA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn MJESECISTAZAColumn
        {
            get
            {
                return this.columnMJESECISTAZA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn MJESECISTAZAPROColumn
        {
            get
            {
                return this.columnMJESECISTAZAPRO;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn MJESECISTAZAUKUPNOColumn
        {
            get
            {
                return this.columnMJESECISTAZAUKUPNO;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn NAZIVBANKE1Column
        {
            get
            {
                return this.columnNAZIVBANKE1;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn NAZIVSKUPPOREZAIDOPRINOSAColumn
        {
            get
            {
                return this.columnNAZIVSKUPPOREZAIDOPRINOSA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn NAZIVSPOLColumn
        {
            get
            {
                return this.columnNAZIVSPOL;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn OIBColumn
        {
            get
            {
                return this.columnOIB;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn OPCINARADAIDOPCINEColumn
        {
            get
            {
                return this.columnOPCINARADAIDOPCINE;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn OPCINASTANOVANJAIDOPCINEColumn
        {
            get
            {
                return this.columnOPCINASTANOVANJAIDOPCINE;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn POSTOTAKOSLOBODJENJAODPOREZAColumn
        {
            get
            {
                return this.columnPOSTOTAKOSLOBODJENJAODPOREZA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn PREZIMEColumn
        {
            get
            {
                return this.columnPREZIME;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAColumn
        {
            get
            {
                return this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn TEKUCIColumn
        {
            get
            {
                return this.columnTEKUCI;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn TJEDNIFONDSATIColumn
        {
            get
            {
                return this.columnTJEDNIFONDSATI;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn TJEDNIFONDSATISTAZColumn
        {
            get
            {
                return this.columnTJEDNIFONDSATISTAZ;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn ZBIRNINETOColumn
        {
            get
            {
                return this.columnZBIRNINETO;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class V_OD_MATICNI_PODACI_RADNIKARow : DataRow
    {
        private dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKADataTable tableV_OD_MATICNI_PODACI_RADNIKA;

        [DebuggerNonUserCode]
        internal V_OD_MATICNI_PODACI_RADNIKARow(DataRowBuilder rb) : base(rb)
        {
            this.tableV_OD_MATICNI_PODACI_RADNIKA = (dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKADataTable) this.Table;
        }

        [DebuggerNonUserCode]
        public bool IsBROJPRIZNATIHMJESECINull()
        {
            return this.IsNull(this.tableV_OD_MATICNI_PODACI_RADNIKA.BROJPRIZNATIHMJESECIColumn);
        }

        [DebuggerNonUserCode]
        public bool IsDANIJUBILARNANull()
        {
            return this.IsNull(this.tableV_OD_MATICNI_PODACI_RADNIKA.DANIJUBILARNAColumn);
        }

        [DebuggerNonUserCode]
        public bool IsDANISTAZAPRONull()
        {
            return this.IsNull(this.tableV_OD_MATICNI_PODACI_RADNIKA.DANISTAZAPROColumn);
        }

        [DebuggerNonUserCode]
        public bool IsDANISTAZAUKUPNONull()
        {
            return this.IsNull(this.tableV_OD_MATICNI_PODACI_RADNIKA.DANISTAZAUKUPNOColumn);
        }

        [DebuggerNonUserCode]
        public bool IsFAKTOROSOBNOGODBITKASUMARNONull()
        {
            return this.IsNull(this.tableV_OD_MATICNI_PODACI_RADNIKA.FAKTOROSOBNOGODBITKASUMARNOColumn);
        }

        [DebuggerNonUserCode]
        public bool IsGODINEJUBILARNANull()
        {
            return this.IsNull(this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINEJUBILARNAColumn);
        }

        [DebuggerNonUserCode]
        public bool IsGODINESTAZAPRONull()
        {
            return this.IsNull(this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINESTAZAPROColumn);
        }

        [DebuggerNonUserCode]
        public bool IsGODINESTAZAUKUPNONull()
        {
            return this.IsNull(this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINESTAZAUKUPNOColumn);
        }

        [DebuggerNonUserCode]
        public bool IsMJESECIJUBILARNANull()
        {
            return this.IsNull(this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECIJUBILARNAColumn);
        }

        [DebuggerNonUserCode]
        public bool IsMJESECISTAZAPRONull()
        {
            return this.IsNull(this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECISTAZAPROColumn);
        }

        [DebuggerNonUserCode]
        public bool IsMJESECISTAZAUKUPNONull()
        {
            return this.IsNull(this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECISTAZAUKUPNOColumn);
        }

        [DebuggerNonUserCode]
        public bool IsNAZIVSPOLNull()
        {
            return this.IsNull(this.tableV_OD_MATICNI_PODACI_RADNIKA.NAZIVSPOLColumn);
        }

        [DebuggerNonUserCode]
        public bool IsOIBNull()
        {
            return this.IsNull(this.tableV_OD_MATICNI_PODACI_RADNIKA.OIBColumn);
        }

        [DebuggerNonUserCode]
        public void SetBROJPRIZNATIHMJESECINull()
        {
            this[this.tableV_OD_MATICNI_PODACI_RADNIKA.BROJPRIZNATIHMJESECIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetDANIJUBILARNANull()
        {
            this[this.tableV_OD_MATICNI_PODACI_RADNIKA.DANIJUBILARNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetDANISTAZAPRONull()
        {
            this[this.tableV_OD_MATICNI_PODACI_RADNIKA.DANISTAZAPROColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetDANISTAZAUKUPNONull()
        {
            this[this.tableV_OD_MATICNI_PODACI_RADNIKA.DANISTAZAUKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetFAKTOROSOBNOGODBITKASUMARNONull()
        {
            this[this.tableV_OD_MATICNI_PODACI_RADNIKA.FAKTOROSOBNOGODBITKASUMARNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetGODINEJUBILARNANull()
        {
            this[this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINEJUBILARNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetGODINESTAZAPRONull()
        {
            this[this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINESTAZAPROColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetGODINESTAZAUKUPNONull()
        {
            this[this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINESTAZAUKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetMJESECIJUBILARNANull()
        {
            this[this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECIJUBILARNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetMJESECISTAZAPRONull()
        {
            this[this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECISTAZAPROColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetMJESECISTAZAUKUPNONull()
        {
            this[this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECISTAZAUKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetNAZIVSPOLNull()
        {
            this[this.tableV_OD_MATICNI_PODACI_RADNIKA.NAZIVSPOLColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetOIBNull()
        {
            this[this.tableV_OD_MATICNI_PODACI_RADNIKA.OIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public bool AKTIVAN
        {
            get
            {
                return Conversions.ToBoolean(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.AKTIVANColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.AKTIVANColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public short BROJPRIZNATIHMJESECI
        {
            get
            {
                short num = 0;
                try
                {
                    num = Conversions.ToShort(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.BROJPRIZNATIHMJESECIColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'BROJPRIZNATIHMJESECI' in table 'V_OD_MATICNI_PODACI_RADNIKA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.BROJPRIZNATIHMJESECIColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string DANIJUBILARNA
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.DANIJUBILARNAColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'DANIJUBILARNA' in table 'V_OD_MATICNI_PODACI_RADNIKA' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.DANIJUBILARNAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public int DANISTAZA
        {
            get
            {
                return Conversions.ToInteger(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.DANISTAZAColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.DANISTAZAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string DANISTAZAPRO
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.DANISTAZAPROColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'DANISTAZAPRO' in table 'V_OD_MATICNI_PODACI_RADNIKA' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.DANISTAZAPROColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public int DANISTAZAUKUPNO
        {
            get
            {
                int num = 0;
                try
                {
                    num = Conversions.ToInteger(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.DANISTAZAUKUPNOColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'DANISTAZAUKUPNO' in table 'V_OD_MATICNI_PODACI_RADNIKA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.DANISTAZAUKUPNOColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public DateTime DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI
        {
            get
            {
                return Conversions.ToDate(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal FAKTOROSOBNOGODBITKASUMARNO
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.FAKTOROSOBNOGODBITKASUMARNOColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'FAKTOROSOBNOGODBITKASUMARNO' in table 'V_OD_MATICNI_PODACI_RADNIKA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.FAKTOROSOBNOGODBITKASUMARNOColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string GODINEJUBILARNA
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINEJUBILARNAColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'GODINEJUBILARNA' in table 'V_OD_MATICNI_PODACI_RADNIKA' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINEJUBILARNAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public int GODINESTAZA
        {
            get
            {
                return Conversions.ToInteger(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINESTAZAColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINESTAZAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string GODINESTAZAPRO
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINESTAZAPROColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'GODINESTAZAPRO' in table 'V_OD_MATICNI_PODACI_RADNIKA' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINESTAZAPROColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public int GODINESTAZAUKUPNO
        {
            get
            {
                int num = 0;
                try
                {
                    num = Conversions.ToInteger(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINESTAZAUKUPNOColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'GODINESTAZAUKUPNO' in table 'V_OD_MATICNI_PODACI_RADNIKA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.GODINESTAZAUKUPNOColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public int IDRADNIK
        {
            get
            {
                return Conversions.ToInteger(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.IDRADNIKColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.IDRADNIKColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string IME
        {
            get
            {
                return Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.IMEColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.IMEColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string JMBG
        {
            get
            {
                return Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.JMBGColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.JMBGColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal KOEFICIJENT
        {
            get
            {
                return Conversions.ToDecimal(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.KOEFICIJENTColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.KOEFICIJENTColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string MJESECIJUBILARNA
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECIJUBILARNAColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'MJESECIJUBILARNA' in table 'V_OD_MATICNI_PODACI_RADNIKA' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECIJUBILARNAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public int MJESECISTAZA
        {
            get
            {
                return Conversions.ToInteger(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECISTAZAColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECISTAZAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string MJESECISTAZAPRO
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECISTAZAPROColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'MJESECISTAZAPRO' in table 'V_OD_MATICNI_PODACI_RADNIKA' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECISTAZAPROColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public int MJESECISTAZAUKUPNO
        {
            get
            {
                int num = 0;
                try
                {
                    num = Conversions.ToInteger(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECISTAZAUKUPNOColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'MJESECISTAZAUKUPNO' in table 'V_OD_MATICNI_PODACI_RADNIKA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.MJESECISTAZAUKUPNOColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string NAZIVBANKE1
        {
            get
            {
                return Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.NAZIVBANKE1Column]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.NAZIVBANKE1Column] = value;
            }
        }

        [DebuggerNonUserCode]
        public string NAZIVSKUPPOREZAIDOPRINOSA
        {
            get
            {
                return Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.NAZIVSKUPPOREZAIDOPRINOSAColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.NAZIVSKUPPOREZAIDOPRINOSAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string NAZIVSPOL
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.NAZIVSPOLColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'NAZIVSPOL' in table 'V_OD_MATICNI_PODACI_RADNIKA' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.NAZIVSPOLColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string OIB
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.OIBColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'OIB' in table 'V_OD_MATICNI_PODACI_RADNIKA' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.OIBColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string OPCINARADAIDOPCINE
        {
            get
            {
                return Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.OPCINARADAIDOPCINEColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.OPCINARADAIDOPCINEColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string OPCINASTANOVANJAIDOPCINE
        {
            get
            {
                return Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.OPCINASTANOVANJAIDOPCINEColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.OPCINASTANOVANJAIDOPCINEColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal POSTOTAKOSLOBODJENJAODPOREZA
        {
            get
            {
                return Conversions.ToDecimal(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.POSTOTAKOSLOBODJENJAODPOREZAColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.POSTOTAKOSLOBODJENJAODPOREZAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string PREZIME
        {
            get
            {
                return Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.PREZIMEColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.PREZIMEColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public int RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA
        {
            get
            {
                return Conversions.ToInteger(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string TEKUCI
        {
            get
            {
                return Conversions.ToString(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.TEKUCIColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.TEKUCIColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal TJEDNIFONDSATI
        {
            get
            {
                return Conversions.ToDecimal(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.TJEDNIFONDSATIColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.TJEDNIFONDSATIColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal TJEDNIFONDSATISTAZ
        {
            get
            {
                return Conversions.ToDecimal(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.TJEDNIFONDSATISTAZColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.TJEDNIFONDSATISTAZColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public bool ZBIRNINETO
        {
            get
            {
                return Conversions.ToBoolean(this[this.tableV_OD_MATICNI_PODACI_RADNIKA.ZBIRNINETOColumn]);
            }
            set
            {
                this[this.tableV_OD_MATICNI_PODACI_RADNIKA.ZBIRNINETOColumn] = value;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class V_OD_MATICNI_PODACI_RADNIKARowChangeEvent : EventArgs
    {
        private DataRowAction eventAction;
        private dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow eventRow;

        [DebuggerNonUserCode]
        public V_OD_MATICNI_PODACI_RADNIKARowChangeEvent(dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow row, DataRowAction action)
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
        public dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARow Row
        {
            get
            {
                return this.eventRow;
            }
        }
    }

    public delegate void V_OD_MATICNI_PODACI_RADNIKARowChangeEventHandler(object sender, dsIspisRadnik.V_OD_MATICNI_PODACI_RADNIKARowChangeEvent e);
}

