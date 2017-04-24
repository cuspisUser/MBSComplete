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

[Serializable, XmlRoot("dsTotaliUstanove"), ToolboxItem(true), HelpKeyword("vs.data.DataSet"), DesignerCategory("code"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedDataSetSchema")]
public class dsTotaliUstanove : DataSet
{
    private System.Data.SchemaSerializationMode _schemaSerializationMode;
    private S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA;

    [DebuggerNonUserCode]
    public dsTotaliUstanove()
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
    protected dsTotaliUstanove(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA"] != null)
                {
                    base.Tables.Add(new S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable(dataSet.Tables["S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA"]));
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
        dsTotaliUstanove ustanove = (dsTotaliUstanove) base.Clone();
        ustanove.InitVars();
        ustanove.SchemaSerializationMode = this.SchemaSerializationMode;
        return ustanove;
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
        dsTotaliUstanove ustanove = new dsTotaliUstanove();
        XmlSchemaComplexType type2 = new XmlSchemaComplexType();
        XmlSchemaSequence sequence = new XmlSchemaSequence();
        XmlSchemaAny item = new XmlSchemaAny {
            Namespace = ustanove.Namespace
        };
        sequence.Items.Add(item);
        type2.Particle = sequence;
        XmlSchema schemaSerializable = ustanove.GetSchemaSerializable();
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
        this.DataSetName = "dsTotaliUstanove";
        this.Prefix = "";
        this.Namespace = "http://tempuri.org/dsTotaliUstanove.xsd";
        this.EnforceConstraints = true;
        this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA = new S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable();
        base.Tables.Add(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA);
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
        this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA = (S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable) base.Tables["S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA"];
        if (initTable && (this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA != null))
        {
            this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.InitVars();
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
            if (dataSet.Tables["S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA"] != null)
            {
                base.Tables.Add(new S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable(dataSet.Tables["S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA"]));
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
    private bool ShouldSerializeS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA()
    {
        return false;
    }

    [DebuggerNonUserCode]
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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, Browsable(false)]
    public S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA
    {
        get
        {
            return this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA;
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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode]
    public new DataTableCollection Tables
    {
        get
        {
            return base.Tables;
        }
    }

    [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedTableSchema")]
    public class S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable : TypedTableBase<dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow>
    {
        private DataColumn columnGODINAOBRACUNA;
        private DataColumn columnIDOBRACUN;
        private DataColumn columnMJESECOBRACUNA;
        private DataColumn columnNETOPLACA;
        private DataColumn columnNETOPRIMANJA;
        private DataColumn columnPOREZNAOSNOVICA;
        private DataColumn columnUKUPNOBRUTO;
        private DataColumn columnUKUPNODOPRINOSI;
        private DataColumn columnUKUPNODOPRINOSINA;
        private DataColumn columnUKUPNONETONAKNADE;
        private DataColumn columnUKUPNOOBUSTAVE;
        private DataColumn columnUKUPNOOLAKSICE;
        private DataColumn columnUKUPNOOO;
        private DataColumn columnUKUPNOOSNOVICAZADOPRINOS;
        private DataColumn columnUKUPNOPOREZ;
        private DataColumn columnUKUPNOPOREZIPRIREZ;
        private DataColumn columnUKUPNOPOREZNOPRIZNATEOLAKSICE;
        private DataColumn columnUKUPNOPRIREZ;
        private DataColumn columnUKUPNOZAISPLATU;

        public event dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEventHandler S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChanged;

        public event dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEventHandler S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChanging;

        public event dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEventHandler S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowDeleted;

        public event dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEventHandler S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowDeleting;

        [DebuggerNonUserCode]
        public S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable()
        {
            this.TableName = "S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA";
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        [DebuggerNonUserCode]
        internal S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable(DataTable table)
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
        protected S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.InitVars();
        }

        [DebuggerNonUserCode]
        public void AddS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow(dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow row)
        {
            this.Rows.Add(row);
        }

        [DebuggerNonUserCode]
        public dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow AddS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow(string IDOBRACUN, decimal UKUPNOBRUTO, decimal UKUPNOOSNOVICAZADOPRINOS, decimal UKUPNODOPRINOSI, decimal UKUPNOOO, decimal UKUPNOOLAKSICE, decimal UKUPNOPOREZNOPRIZNATEOLAKSICE, decimal POREZNAOSNOVICA, decimal UKUPNOPOREZ, decimal UKUPNOPRIREZ, decimal UKUPNOPOREZIPRIREZ, decimal NETOPLACA, decimal UKUPNONETONAKNADE, decimal NETOPRIMANJA, decimal UKUPNOOBUSTAVE, decimal UKUPNOZAISPLATU, decimal UKUPNODOPRINOSINA, string MJESECOBRACUNA, string GODINAOBRACUNA)
        {
            dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow row = (dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow) this.NewRow();
            row.ItemArray = new object[] { 
                IDOBRACUN, UKUPNOBRUTO, UKUPNOOSNOVICAZADOPRINOS, UKUPNODOPRINOSI, UKUPNOOO, UKUPNOOLAKSICE, UKUPNOPOREZNOPRIZNATEOLAKSICE, POREZNAOSNOVICA, UKUPNOPOREZ, UKUPNOPRIREZ, UKUPNOPOREZIPRIREZ, NETOPLACA, UKUPNONETONAKNADE, NETOPRIMANJA, UKUPNOOBUSTAVE, UKUPNOZAISPLATU, 
                UKUPNODOPRINOSINA, MJESECOBRACUNA, GODINAOBRACUNA
             };
            this.Rows.Add(row);
            return row;
        }

        [DebuggerNonUserCode]
        public override DataTable Clone()
        {
            dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable table = (dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable) base.Clone();
            table.InitVars();
            return table;
        }

        [DebuggerNonUserCode]
        protected override DataTable CreateInstance()
        {
            return new dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable();
        }

        [DebuggerNonUserCode]
        public dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow FindByIDOBRACUN(string IDOBRACUN)
        {
            return (dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow) this.Rows.Find(new object[] { IDOBRACUN });
        }

        [DebuggerNonUserCode]
        protected override Type GetRowType()
        {
            return typeof(dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow);
        }

        [DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
        {
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            dsTotaliUstanove ustanove = new dsTotaliUstanove();
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
                FixedValue = ustanove.Namespace
            };
            type2.Attributes.Add(attribute);
            XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                Name = "tableTypeName",
                FixedValue = "S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable"
            };
            type2.Attributes.Add(attribute2);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = ustanove.GetSchemaSerializable();
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
            this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnIDOBRACUN);
            this.columnUKUPNOBRUTO = new DataColumn("UKUPNOBRUTO", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNOBRUTO);
            this.columnUKUPNOOSNOVICAZADOPRINOS = new DataColumn("UKUPNOOSNOVICAZADOPRINOS", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNOOSNOVICAZADOPRINOS);
            this.columnUKUPNODOPRINOSI = new DataColumn("UKUPNODOPRINOSI", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNODOPRINOSI);
            this.columnUKUPNOOO = new DataColumn("UKUPNOOO", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNOOO);
            this.columnUKUPNOOLAKSICE = new DataColumn("UKUPNOOLAKSICE", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNOOLAKSICE);
            this.columnUKUPNOPOREZNOPRIZNATEOLAKSICE = new DataColumn("UKUPNOPOREZNOPRIZNATEOLAKSICE", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNOPOREZNOPRIZNATEOLAKSICE);
            this.columnPOREZNAOSNOVICA = new DataColumn("POREZNAOSNOVICA", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnPOREZNAOSNOVICA);
            this.columnUKUPNOPOREZ = new DataColumn("UKUPNOPOREZ", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNOPOREZ);
            this.columnUKUPNOPRIREZ = new DataColumn("UKUPNOPRIREZ", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNOPRIREZ);
            this.columnUKUPNOPOREZIPRIREZ = new DataColumn("UKUPNOPOREZIPRIREZ", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNOPOREZIPRIREZ);
            this.columnNETOPLACA = new DataColumn("NETOPLACA", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnNETOPLACA);
            this.columnUKUPNONETONAKNADE = new DataColumn("UKUPNONETONAKNADE", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNONETONAKNADE);
            this.columnNETOPRIMANJA = new DataColumn("NETOPRIMANJA", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnNETOPRIMANJA);
            this.columnUKUPNOOBUSTAVE = new DataColumn("UKUPNOOBUSTAVE", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNOOBUSTAVE);
            this.columnUKUPNOZAISPLATU = new DataColumn("UKUPNOZAISPLATU", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNOZAISPLATU);
            this.columnUKUPNODOPRINOSINA = new DataColumn("UKUPNODOPRINOSINA", typeof(decimal), null, MappingType.Element);
            base.Columns.Add(this.columnUKUPNODOPRINOSINA);
            this.columnMJESECOBRACUNA = new DataColumn("MJESECOBRACUNA", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnMJESECOBRACUNA);
            this.columnGODINAOBRACUNA = new DataColumn("GODINAOBRACUNA", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnGODINAOBRACUNA);
            this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnIDOBRACUN }, true));
            this.columnIDOBRACUN.AllowDBNull = false;
            this.columnIDOBRACUN.Unique = true;
            this.columnIDOBRACUN.MaxLength = 11;
            this.columnUKUPNOBRUTO.ReadOnly = true;
            this.columnUKUPNOOSNOVICAZADOPRINOS.ReadOnly = true;
            this.columnUKUPNODOPRINOSI.ReadOnly = true;
            this.columnUKUPNOOO.ReadOnly = true;
            this.columnUKUPNOOLAKSICE.ReadOnly = true;
            this.columnUKUPNOPOREZNOPRIZNATEOLAKSICE.ReadOnly = true;
            this.columnPOREZNAOSNOVICA.ReadOnly = true;
            this.columnUKUPNOPOREZ.ReadOnly = true;
            this.columnUKUPNOPRIREZ.ReadOnly = true;
            this.columnUKUPNOPOREZIPRIREZ.ReadOnly = true;
            this.columnNETOPLACA.ReadOnly = true;
            this.columnUKUPNONETONAKNADE.ReadOnly = true;
            this.columnNETOPRIMANJA.ReadOnly = true;
            this.columnUKUPNOOBUSTAVE.ReadOnly = true;
            this.columnUKUPNOZAISPLATU.ReadOnly = true;
            this.columnUKUPNODOPRINOSINA.ReadOnly = true;
        }

        [DebuggerNonUserCode]
        internal void InitVars()
        {
            this.columnIDOBRACUN = base.Columns["IDOBRACUN"];
            this.columnUKUPNOBRUTO = base.Columns["UKUPNOBRUTO"];
            this.columnUKUPNOOSNOVICAZADOPRINOS = base.Columns["UKUPNOOSNOVICAZADOPRINOS"];
            this.columnUKUPNODOPRINOSI = base.Columns["UKUPNODOPRINOSI"];
            this.columnUKUPNOOO = base.Columns["UKUPNOOO"];
            this.columnUKUPNOOLAKSICE = base.Columns["UKUPNOOLAKSICE"];
            this.columnUKUPNOPOREZNOPRIZNATEOLAKSICE = base.Columns["UKUPNOPOREZNOPRIZNATEOLAKSICE"];
            this.columnPOREZNAOSNOVICA = base.Columns["POREZNAOSNOVICA"];
            this.columnUKUPNOPOREZ = base.Columns["UKUPNOPOREZ"];
            this.columnUKUPNOPRIREZ = base.Columns["UKUPNOPRIREZ"];
            this.columnUKUPNOPOREZIPRIREZ = base.Columns["UKUPNOPOREZIPRIREZ"];
            this.columnNETOPLACA = base.Columns["NETOPLACA"];
            this.columnUKUPNONETONAKNADE = base.Columns["UKUPNONETONAKNADE"];
            this.columnNETOPRIMANJA = base.Columns["NETOPRIMANJA"];
            this.columnUKUPNOOBUSTAVE = base.Columns["UKUPNOOBUSTAVE"];
            this.columnUKUPNOZAISPLATU = base.Columns["UKUPNOZAISPLATU"];
            this.columnUKUPNODOPRINOSINA = base.Columns["UKUPNODOPRINOSINA"];
            this.columnMJESECOBRACUNA = base.Columns["MJESECOBRACUNA"];
            this.columnGODINAOBRACUNA = base.Columns["GODINAOBRACUNA"];
        }

        [DebuggerNonUserCode]
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow(builder);
        }

        [DebuggerNonUserCode]
        public dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow NewS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow()
        {
            return (dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow) this.NewRow();
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            if (this.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChanged != null)
            {
                dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEventHandler handler = this.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChanged;
                if (handler != null)
                {
                    handler(this, new dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEvent((dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
            if (this.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChanging != null)
            {
                dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEventHandler handler = this.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChanging;
                if (handler != null)
                {
                    handler(this, new dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEvent((dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);
            if (this.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowDeleted != null)
            {
                dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEventHandler handler = this.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowDeleted;
                if (handler != null)
                {
                    handler(this, new dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEvent((dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {
            base.OnRowDeleting(e);
            if (this.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowDeleting != null)
            {
                dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEventHandler handler = this.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowDeleting;
                if (handler != null)
                {
                    handler(this, new dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEvent((dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow) e.Row, e.Action));
                }
            }
        }

        [DebuggerNonUserCode]
        public void RemoveS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow(dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow row)
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
        public DataColumn GODINAOBRACUNAColumn
        {
            get
            {
                return this.columnGODINAOBRACUNA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn IDOBRACUNColumn
        {
            get
            {
                return this.columnIDOBRACUN;
            }
        }

        [DebuggerNonUserCode]
        public dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow this[int index]
        {
            get
            {
                return (dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow) this.Rows[index];
            }
        }

        [DebuggerNonUserCode]
        public DataColumn MJESECOBRACUNAColumn
        {
            get
            {
                return this.columnMJESECOBRACUNA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn NETOPLACAColumn
        {
            get
            {
                return this.columnNETOPLACA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn NETOPRIMANJAColumn
        {
            get
            {
                return this.columnNETOPRIMANJA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn POREZNAOSNOVICAColumn
        {
            get
            {
                return this.columnPOREZNAOSNOVICA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn UKUPNOBRUTOColumn
        {
            get
            {
                return this.columnUKUPNOBRUTO;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn UKUPNODOPRINOSIColumn
        {
            get
            {
                return this.columnUKUPNODOPRINOSI;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn UKUPNODOPRINOSINAColumn
        {
            get
            {
                return this.columnUKUPNODOPRINOSINA;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn UKUPNONETONAKNADEColumn
        {
            get
            {
                return this.columnUKUPNONETONAKNADE;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn UKUPNOOBUSTAVEColumn
        {
            get
            {
                return this.columnUKUPNOOBUSTAVE;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn UKUPNOOLAKSICEColumn
        {
            get
            {
                return this.columnUKUPNOOLAKSICE;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn UKUPNOOOColumn
        {
            get
            {
                return this.columnUKUPNOOO;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn UKUPNOOSNOVICAZADOPRINOSColumn
        {
            get
            {
                return this.columnUKUPNOOSNOVICAZADOPRINOS;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn UKUPNOPOREZColumn
        {
            get
            {
                return this.columnUKUPNOPOREZ;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn UKUPNOPOREZIPRIREZColumn
        {
            get
            {
                return this.columnUKUPNOPOREZIPRIREZ;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn UKUPNOPOREZNOPRIZNATEOLAKSICEColumn
        {
            get
            {
                return this.columnUKUPNOPOREZNOPRIZNATEOLAKSICE;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn UKUPNOPRIREZColumn
        {
            get
            {
                return this.columnUKUPNOPRIREZ;
            }
        }

        [DebuggerNonUserCode]
        public DataColumn UKUPNOZAISPLATUColumn
        {
            get
            {
                return this.columnUKUPNOZAISPLATU;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow : DataRow
    {
        private dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA;

        [DebuggerNonUserCode]
        internal S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow(DataRowBuilder rb) : base(rb)
        {
            this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA = (dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJADataTable) this.Table;
        }

        [DebuggerNonUserCode]
        public bool IsGODINAOBRACUNANull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.GODINAOBRACUNAColumn);
        }

        [DebuggerNonUserCode]
        public bool IsMJESECOBRACUNANull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.MJESECOBRACUNAColumn);
        }

        [DebuggerNonUserCode]
        public bool IsNETOPLACANull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.NETOPLACAColumn);
        }

        [DebuggerNonUserCode]
        public bool IsNETOPRIMANJANull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.NETOPRIMANJAColumn);
        }

        [DebuggerNonUserCode]
        public bool IsPOREZNAOSNOVICANull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.POREZNAOSNOVICAColumn);
        }

        [DebuggerNonUserCode]
        public bool IsUKUPNOBRUTONull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOBRUTOColumn);
        }

        [DebuggerNonUserCode]
        public bool IsUKUPNODOPRINOSINANull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNODOPRINOSINAColumn);
        }

        [DebuggerNonUserCode]
        public bool IsUKUPNODOPRINOSINull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNODOPRINOSIColumn);
        }

        [DebuggerNonUserCode]
        public bool IsUKUPNONETONAKNADENull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNONETONAKNADEColumn);
        }

        [DebuggerNonUserCode]
        public bool IsUKUPNOOBUSTAVENull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOBUSTAVEColumn);
        }

        [DebuggerNonUserCode]
        public bool IsUKUPNOOLAKSICENull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOLAKSICEColumn);
        }

        [DebuggerNonUserCode]
        public bool IsUKUPNOOONull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOOColumn);
        }

        [DebuggerNonUserCode]
        public bool IsUKUPNOOSNOVICAZADOPRINOSNull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOSNOVICAZADOPRINOSColumn);
        }

        [DebuggerNonUserCode]
        public bool IsUKUPNOPOREZIPRIREZNull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPOREZIPRIREZColumn);
        }

        [DebuggerNonUserCode]
        public bool IsUKUPNOPOREZNOPRIZNATEOLAKSICENull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPOREZNOPRIZNATEOLAKSICEColumn);
        }

        [DebuggerNonUserCode]
        public bool IsUKUPNOPOREZNull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPOREZColumn);
        }

        [DebuggerNonUserCode]
        public bool IsUKUPNOPRIREZNull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPRIREZColumn);
        }

        [DebuggerNonUserCode]
        public bool IsUKUPNOZAISPLATUNull()
        {
            return this.IsNull(this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOZAISPLATUColumn);
        }

        [DebuggerNonUserCode]
        public void SetGODINAOBRACUNANull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.GODINAOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetMJESECOBRACUNANull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.MJESECOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetNETOPLACANull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.NETOPLACAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetNETOPRIMANJANull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.NETOPRIMANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetPOREZNAOSNOVICANull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.POREZNAOSNOVICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetUKUPNOBRUTONull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOBRUTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetUKUPNODOPRINOSINANull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNODOPRINOSINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetUKUPNODOPRINOSINull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNODOPRINOSIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetUKUPNONETONAKNADENull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNONETONAKNADEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetUKUPNOOBUSTAVENull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetUKUPNOOLAKSICENull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetUKUPNOOONull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetUKUPNOOSNOVICAZADOPRINOSNull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOSNOVICAZADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetUKUPNOPOREZIPRIREZNull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPOREZIPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetUKUPNOPOREZNOPRIZNATEOLAKSICENull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPOREZNOPRIZNATEOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetUKUPNOPOREZNull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetUKUPNOPRIREZNull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public void SetUKUPNOZAISPLATUNull()
        {
            this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOZAISPLATUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
        }

        [DebuggerNonUserCode]
        public string GODINAOBRACUNA
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.GODINAOBRACUNAColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'GODINAOBRACUNA' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.GODINAOBRACUNAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string IDOBRACUN
        {
            get
            {
                return Conversions.ToString(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.IDOBRACUNColumn]);
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.IDOBRACUNColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public string MJESECOBRACUNA
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = Conversions.ToString(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.MJESECOBRACUNAColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'MJESECOBRACUNA' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return str;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.MJESECOBRACUNAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal NETOPLACA
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.NETOPLACAColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'NETOPLACA' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.NETOPLACAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal NETOPRIMANJA
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.NETOPRIMANJAColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'NETOPRIMANJA' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.NETOPRIMANJAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal POREZNAOSNOVICA
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.POREZNAOSNOVICAColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'POREZNAOSNOVICA' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.POREZNAOSNOVICAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal UKUPNOBRUTO
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOBRUTOColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'UKUPNOBRUTO' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOBRUTOColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal UKUPNODOPRINOSI
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNODOPRINOSIColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'UKUPNODOPRINOSI' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNODOPRINOSIColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal UKUPNODOPRINOSINA
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNODOPRINOSINAColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'UKUPNODOPRINOSINA' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNODOPRINOSINAColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal UKUPNONETONAKNADE
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNONETONAKNADEColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'UKUPNONETONAKNADE' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNONETONAKNADEColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal UKUPNOOBUSTAVE
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOBUSTAVEColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'UKUPNOOBUSTAVE' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOBUSTAVEColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal UKUPNOOLAKSICE
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOLAKSICEColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'UKUPNOOLAKSICE' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOLAKSICEColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal UKUPNOOO
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOOColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'UKUPNOOO' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOOColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal UKUPNOOSNOVICAZADOPRINOS
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOSNOVICAZADOPRINOSColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'UKUPNOOSNOVICAZADOPRINOS' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOOSNOVICAZADOPRINOSColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal UKUPNOPOREZ
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPOREZColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'UKUPNOPOREZ' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPOREZColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal UKUPNOPOREZIPRIREZ
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPOREZIPRIREZColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'UKUPNOPOREZIPRIREZ' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPOREZIPRIREZColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal UKUPNOPOREZNOPRIZNATEOLAKSICE
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPOREZNOPRIZNATEOLAKSICEColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'UKUPNOPOREZNOPRIZNATEOLAKSICE' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPOREZNOPRIZNATEOLAKSICEColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal UKUPNOPRIREZ
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPRIREZColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'UKUPNOPRIREZ' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOPRIREZColumn] = value;
            }
        }

        [DebuggerNonUserCode]
        public decimal UKUPNOZAISPLATU
        {
            get
            {
                decimal num = 0;
                try
                {
                    num = Conversions.ToDecimal(this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOZAISPLATUColumn]);
                }
                catch (InvalidCastException exception1)
                {
                    throw exception1;
                    //InvalidCastException innerException = exception1;
                    //throw new StrongTypingException("The value for column 'UKUPNOZAISPLATU' in table 'S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA' is DBNull.", innerException);
                }
                return num;
            }
            set
            {
                this[this.tableS_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.UKUPNOZAISPLATUColumn] = value;
            }
        }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEvent : EventArgs
    {
        private DataRowAction eventAction;
        private dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow eventRow;

        [DebuggerNonUserCode]
        public S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEvent(dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow row, DataRowAction action)
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
        public dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARow Row
        {
            get
            {
                return this.eventRow;
            }
        }
    }

    public delegate void S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEventHandler(object sender, dsTotaliUstanove.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJARowChangeEvent e);
}

