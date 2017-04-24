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

    [Serializable, ToolboxItem(true), HelpKeyword("vs.data.DataSet"), XmlRoot("dsZatvaranja"), XmlSchemaProvider("GetTypedDataSetSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), DesignerCategory("code")]
    public class dsZatvaranja : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private ZATVARANJADataTable tableZATVARANJA;

        [DebuggerNonUserCode]
        public dsZatvaranja()
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
        protected dsZatvaranja(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["ZATVARANJA"] != null)
                    {
                        base.Tables.Add(new ZATVARANJADataTable(dataSet.Tables["ZATVARANJA"]));
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
            dsZatvaranja zatvaranja = (dsZatvaranja) base.Clone();
            zatvaranja.InitVars();
            zatvaranja.SchemaSerializationMode = this.SchemaSerializationMode;
            return zatvaranja;
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
            dsZatvaranja zatvaranja = new dsZatvaranja();
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = zatvaranja.Namespace
            };
            sequence.Items.Add(item);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = zatvaranja.GetSchemaSerializable();
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
            this.DataSetName = "dsZatvaranja";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/dsZatvaranja.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableZATVARANJA = new ZATVARANJADataTable();
            base.Tables.Add(this.tableZATVARANJA);
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
            this.tableZATVARANJA = (ZATVARANJADataTable) base.Tables["ZATVARANJA"];
            if (initTable && (this.tableZATVARANJA != null))
            {
                this.tableZATVARANJA.InitVars();
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
                if (dataSet.Tables["ZATVARANJA"] != null)
                {
                    base.Tables.Add(new ZATVARANJADataTable(dataSet.Tables["ZATVARANJA"]));
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
        private bool ShouldSerializeZATVARANJA()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public ZATVARANJADataTable ZATVARANJA
        {
            get
            {
                return this.tableZATVARANJA;
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class ZATVARANJADataTable : TypedTableBase<dsZatvaranja.ZATVARANJARow>
        {
            private DataColumn columnBROJDOKUMENTA;
            private DataColumn columnBROJSTAVKE;
            private DataColumn columnDATUMDOKUMENTA;
            private DataColumn columnDATUMDVO;
            private DataColumn columnDATUMPRIJAVE;
            private DataColumn columnDATUMVALUTE;
            private DataColumn columnduguje;
            private DataColumn columnGK1IDGKSTAVKA;
            private DataColumn columnGK2IDGKSTAVKA;
            private DataColumn columnIDDOKUMENT;
            private DataColumn columnIDGKSTAVKA;
            private DataColumn columnIDKONTO;
            private DataColumn columnIDMJESTOTROSKA;
            private DataColumn columnIDORGJED;
            private DataColumn columnIDPARTNER;
            private DataColumn columnNAZIVDOKUMENT;
            private DataColumn columnNAZIVKONTO;
            private DataColumn columnNAZIVMJESTOTROSKA;
            private DataColumn columnNAZIVORGJED;
            private DataColumn columnNAZIVPARTNER;
            private DataColumn columnOPIS;
            private DataColumn columnPOTRAZUJE;
            private DataColumn columnSKRACENIDOKUMENT;
            private DataColumn columnZATVARANJAIZNOS;
            private DataColumn columnZATVORENIIZNOS;

            public event dsZatvaranja.ZATVARANJARowChangeEventHandler ZATVARANJARowChanged;

            public event dsZatvaranja.ZATVARANJARowChangeEventHandler ZATVARANJARowChanging;

            public event dsZatvaranja.ZATVARANJARowChangeEventHandler ZATVARANJARowDeleted;

            public event dsZatvaranja.ZATVARANJARowChangeEventHandler ZATVARANJARowDeleting;

            [DebuggerNonUserCode]
            public ZATVARANJADataTable()
            {
                this.TableName = "ZATVARANJA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal ZATVARANJADataTable(DataTable table)
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
            protected ZATVARANJADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddZATVARANJARow(dsZatvaranja.ZATVARANJARow row)
            {
                this.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public dsZatvaranja.ZATVARANJARow AddZATVARANJARow(long GK1IDGKSTAVKA, long GK2IDGKSTAVKA, decimal ZATVARANJAIZNOS, DateTime DATUMDOKUMENTA, string BROJDOKUMENTA, string BROJSTAVKE, string IDDOKUMENT, string IDMJESTOTROSKA, string IDORGJED, string IDKONTO, string OPIS, decimal duguje, decimal POTRAZUJE, DateTime DATUMPRIJAVE, string IDPARTNER, decimal ZATVORENIIZNOS, DateTime DATUMDVO, DateTime DATUMVALUTE, string NAZIVPARTNER, string NAZIVMJESTOTROSKA, string NAZIVORGJED, string SKRACENIDOKUMENT, string NAZIVDOKUMENT, string NAZIVKONTO)
            {
                dsZatvaranja.ZATVARANJARow row = (dsZatvaranja.ZATVARANJARow) this.NewRow();
                row.ItemArray = new object[] { 
                    GK1IDGKSTAVKA, GK2IDGKSTAVKA, ZATVARANJAIZNOS, null, DATUMDOKUMENTA, BROJDOKUMENTA, BROJSTAVKE, IDDOKUMENT, IDMJESTOTROSKA, IDORGJED, IDKONTO, OPIS, duguje, POTRAZUJE, DATUMPRIJAVE, IDPARTNER, 
                    ZATVORENIIZNOS, DATUMDVO, DATUMVALUTE, NAZIVPARTNER, NAZIVMJESTOTROSKA, NAZIVORGJED, SKRACENIDOKUMENT, NAZIVDOKUMENT, NAZIVKONTO
                 };
                this.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsZatvaranja.ZATVARANJADataTable table = (dsZatvaranja.ZATVARANJADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsZatvaranja.ZATVARANJADataTable();
            }

            [DebuggerNonUserCode]
            public dsZatvaranja.ZATVARANJARow FindByIDGKSTAVKA(int IDGKSTAVKA)
            {
                return (dsZatvaranja.ZATVARANJARow) this.Rows.Find(new object[] { IDGKSTAVKA });
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsZatvaranja.ZATVARANJARow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsZatvaranja zatvaranja = new dsZatvaranja();
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
                    FixedValue = zatvaranja.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "ZATVARANJADataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                XmlSchema schemaSerializable = zatvaranja.GetSchemaSerializable();
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
                this.columnGK1IDGKSTAVKA = new DataColumn("GK1IDGKSTAVKA", typeof(long), null, MappingType.Element);
                base.Columns.Add(this.columnGK1IDGKSTAVKA);
                this.columnGK2IDGKSTAVKA = new DataColumn("GK2IDGKSTAVKA", typeof(long), null, MappingType.Element);
                base.Columns.Add(this.columnGK2IDGKSTAVKA);
                this.columnZATVARANJAIZNOS = new DataColumn("ZATVARANJAIZNOS", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnZATVARANJAIZNOS);
                this.columnIDGKSTAVKA = new DataColumn("IDGKSTAVKA", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnIDGKSTAVKA);
                this.columnDATUMDOKUMENTA = new DataColumn("DATUMDOKUMENTA", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnDATUMDOKUMENTA);
                this.columnBROJDOKUMENTA = new DataColumn("BROJDOKUMENTA", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBROJDOKUMENTA);
                this.columnBROJSTAVKE = new DataColumn("BROJSTAVKE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBROJSTAVKE);
                this.columnIDDOKUMENT = new DataColumn("IDDOKUMENT", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnIDDOKUMENT);
                this.columnIDMJESTOTROSKA = new DataColumn("IDMJESTOTROSKA", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnIDMJESTOTROSKA);
                this.columnIDORGJED = new DataColumn("IDORGJED", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnIDORGJED);
                this.columnIDKONTO = new DataColumn("IDKONTO", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnIDKONTO);
                this.columnOPIS = new DataColumn("OPIS", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOPIS);
                this.columnduguje = new DataColumn("DUGUJE", typeof(decimal), null, MappingType.Element);
                this.columnduguje.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "duguje");
                this.columnduguje.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "dugujeColumn");
                this.columnduguje.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnduguje");
                this.columnduguje.ExtendedProperties.Add("Generator_UserColumnName", "DUGUJE");
                base.Columns.Add(this.columnduguje);
                this.columnPOTRAZUJE = new DataColumn("POTRAZUJE", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnPOTRAZUJE);
                this.columnDATUMPRIJAVE = new DataColumn("DATUMPRIJAVE", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnDATUMPRIJAVE);
                this.columnIDPARTNER = new DataColumn("IDPARTNER", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnIDPARTNER);
                this.columnZATVORENIIZNOS = new DataColumn("ZATVORENIIZNOS", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnZATVORENIIZNOS);
                this.columnDATUMDVO = new DataColumn("DATUMDVO", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnDATUMDVO);
                this.columnDATUMVALUTE = new DataColumn("DATUMVALUTE", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnDATUMVALUTE);
                this.columnNAZIVPARTNER = new DataColumn("NAZIVPARTNER", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnNAZIVPARTNER);
                this.columnNAZIVMJESTOTROSKA = new DataColumn("NAZIVMJESTOTROSKA", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnNAZIVMJESTOTROSKA);
                this.columnNAZIVORGJED = new DataColumn("NAZIVORGJED", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnNAZIVORGJED);
                this.columnSKRACENIDOKUMENT = new DataColumn("SKRACENIDOKUMENT", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKRACENIDOKUMENT);
                this.columnNAZIVDOKUMENT = new DataColumn("NAZIVDOKUMENT", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnNAZIVDOKUMENT);
                this.columnNAZIVKONTO = new DataColumn("NAZIVKONTO", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnNAZIVKONTO);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnIDGKSTAVKA }, true));
                this.columnGK1IDGKSTAVKA.AllowDBNull = false;
                this.columnGK2IDGKSTAVKA.AllowDBNull = false;
                this.columnIDGKSTAVKA.AutoIncrement = true;
                this.columnIDGKSTAVKA.AllowDBNull = false;
                this.columnIDGKSTAVKA.ReadOnly = true;
                this.columnIDGKSTAVKA.Unique = true;
                this.columnDATUMDOKUMENTA.AllowDBNull = false;
                this.columnBROJDOKUMENTA.AllowDBNull = false;
                this.columnBROJSTAVKE.AllowDBNull = false;
                this.columnIDDOKUMENT.AllowDBNull = false;
                this.columnIDMJESTOTROSKA.AllowDBNull = false;
                this.columnIDORGJED.AllowDBNull = false;
                this.columnIDKONTO.AllowDBNull = false;
                this.columnNAZIVPARTNER.AllowDBNull = false;
                this.columnNAZIVMJESTOTROSKA.AllowDBNull = false;
                this.columnNAZIVORGJED.AllowDBNull = false;
                this.columnSKRACENIDOKUMENT.AllowDBNull = false;
                this.columnNAZIVDOKUMENT.AllowDBNull = false;
                this.columnNAZIVKONTO.AllowDBNull = false;
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnGK1IDGKSTAVKA = base.Columns["GK1IDGKSTAVKA"];
                this.columnGK2IDGKSTAVKA = base.Columns["GK2IDGKSTAVKA"];
                this.columnZATVARANJAIZNOS = base.Columns["ZATVARANJAIZNOS"];
                this.columnIDGKSTAVKA = base.Columns["IDGKSTAVKA"];
                this.columnDATUMDOKUMENTA = base.Columns["DATUMDOKUMENTA"];
                this.columnBROJDOKUMENTA = base.Columns["BROJDOKUMENTA"];
                this.columnBROJSTAVKE = base.Columns["BROJSTAVKE"];
                this.columnIDDOKUMENT = base.Columns["IDDOKUMENT"];
                this.columnIDMJESTOTROSKA = base.Columns["IDMJESTOTROSKA"];
                this.columnIDORGJED = base.Columns["IDORGJED"];
                this.columnIDKONTO = base.Columns["IDKONTO"];
                this.columnOPIS = base.Columns["OPIS"];
                this.columnduguje = base.Columns["DUGUJE"];
                this.columnPOTRAZUJE = base.Columns["POTRAZUJE"];
                this.columnDATUMPRIJAVE = base.Columns["DATUMPRIJAVE"];
                this.columnIDPARTNER = base.Columns["IDPARTNER"];
                this.columnZATVORENIIZNOS = base.Columns["ZATVORENIIZNOS"];
                this.columnDATUMDVO = base.Columns["DATUMDVO"];
                this.columnDATUMVALUTE = base.Columns["DATUMVALUTE"];
                this.columnNAZIVPARTNER = base.Columns["NAZIVPARTNER"];
                this.columnNAZIVMJESTOTROSKA = base.Columns["NAZIVMJESTOTROSKA"];
                this.columnNAZIVORGJED = base.Columns["NAZIVORGJED"];
                this.columnSKRACENIDOKUMENT = base.Columns["SKRACENIDOKUMENT"];
                this.columnNAZIVDOKUMENT = base.Columns["NAZIVDOKUMENT"];
                this.columnNAZIVKONTO = base.Columns["NAZIVKONTO"];
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsZatvaranja.ZATVARANJARow(builder);
            }

            [DebuggerNonUserCode]
            public dsZatvaranja.ZATVARANJARow NewZATVARANJARow()
            {
                return (dsZatvaranja.ZATVARANJARow) this.NewRow();
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ZATVARANJARowChanged != null)
                {
                    dsZatvaranja.ZATVARANJARowChangeEventHandler zATVARANJARowChangedEvent = this.ZATVARANJARowChanged;
                    if (zATVARANJARowChangedEvent != null)
                    {
                        zATVARANJARowChangedEvent(this, new dsZatvaranja.ZATVARANJARowChangeEvent((dsZatvaranja.ZATVARANJARow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ZATVARANJARowChanging != null)
                {
                    dsZatvaranja.ZATVARANJARowChangeEventHandler zATVARANJARowChangingEvent = this.ZATVARANJARowChanging;
                    if (zATVARANJARowChangingEvent != null)
                    {
                        zATVARANJARowChangingEvent(this, new dsZatvaranja.ZATVARANJARowChangeEvent((dsZatvaranja.ZATVARANJARow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.ZATVARANJARowDeleted != null)
                {
                    dsZatvaranja.ZATVARANJARowChangeEventHandler zATVARANJARowDeletedEvent = this.ZATVARANJARowDeleted;
                    if (zATVARANJARowDeletedEvent != null)
                    {
                        zATVARANJARowDeletedEvent(this, new dsZatvaranja.ZATVARANJARowChangeEvent((dsZatvaranja.ZATVARANJARow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ZATVARANJARowDeleting != null)
                {
                    dsZatvaranja.ZATVARANJARowChangeEventHandler zATVARANJARowDeletingEvent = this.ZATVARANJARowDeleting;
                    if (zATVARANJARowDeletingEvent != null)
                    {
                        zATVARANJARowDeletingEvent(this, new dsZatvaranja.ZATVARANJARowChangeEvent((dsZatvaranja.ZATVARANJARow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            public void RemoveZATVARANJARow(dsZatvaranja.ZATVARANJARow row)
            {
                this.Rows.Remove(row);
            }

            [DebuggerNonUserCode]
            public DataColumn BROJDOKUMENTAColumn
            {
                get
                {
                    return this.columnBROJDOKUMENTA;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn BROJSTAVKEColumn
            {
                get
                {
                    return this.columnBROJSTAVKE;
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
            public DataColumn DATUMDOKUMENTAColumn
            {
                get
                {
                    return this.columnDATUMDOKUMENTA;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn DATUMDVOColumn
            {
                get
                {
                    return this.columnDATUMDVO;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn DATUMPRIJAVEColumn
            {
                get
                {
                    return this.columnDATUMPRIJAVE;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn DATUMVALUTEColumn
            {
                get
                {
                    return this.columnDATUMVALUTE;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn dugujeColumn
            {
                get
                {
                    return this.columnduguje;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn GK1IDGKSTAVKAColumn
            {
                get
                {
                    return this.columnGK1IDGKSTAVKA;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn GK2IDGKSTAVKAColumn
            {
                get
                {
                    return this.columnGK2IDGKSTAVKA;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IDDOKUMENTColumn
            {
                get
                {
                    return this.columnIDDOKUMENT;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IDGKSTAVKAColumn
            {
                get
                {
                    return this.columnIDGKSTAVKA;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IDKONTOColumn
            {
                get
                {
                    return this.columnIDKONTO;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IDMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnIDMJESTOTROSKA;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IDORGJEDColumn
            {
                get
                {
                    return this.columnIDORGJED;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IDPARTNERColumn
            {
                get
                {
                    return this.columnIDPARTNER;
                }
            }

            [DebuggerNonUserCode]
            public dsZatvaranja.ZATVARANJARow this[int index]
            {
                get
                {
                    return (dsZatvaranja.ZATVARANJARow) this.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn NAZIVDOKUMENTColumn
            {
                get
                {
                    return this.columnNAZIVDOKUMENT;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn NAZIVKONTOColumn
            {
                get
                {
                    return this.columnNAZIVKONTO;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn NAZIVMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnNAZIVMJESTOTROSKA;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn NAZIVORGJEDColumn
            {
                get
                {
                    return this.columnNAZIVORGJED;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn NAZIVPARTNERColumn
            {
                get
                {
                    return this.columnNAZIVPARTNER;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn OPISColumn
            {
                get
                {
                    return this.columnOPIS;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn POTRAZUJEColumn
            {
                get
                {
                    return this.columnPOTRAZUJE;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn SKRACENIDOKUMENTColumn
            {
                get
                {
                    return this.columnSKRACENIDOKUMENT;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn ZATVARANJAIZNOSColumn
            {
                get
                {
                    return this.columnZATVARANJAIZNOS;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn ZATVORENIIZNOSColumn
            {
                get
                {
                    return this.columnZATVORENIIZNOS;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class ZATVARANJARow : DataRow
        {
            private dsZatvaranja.ZATVARANJADataTable tableZATVARANJA;

            [DebuggerNonUserCode]
            internal ZATVARANJARow(DataRowBuilder rb) : base(rb)
            {
                this.tableZATVARANJA = (dsZatvaranja.ZATVARANJADataTable) this.Table;
            }

            [DebuggerNonUserCode]
            public bool IsDATUMDVONull()
            {
                return this.IsNull(this.tableZATVARANJA.DATUMDVOColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDATUMPRIJAVENull()
            {
                return this.IsNull(this.tableZATVARANJA.DATUMPRIJAVEColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDATUMVALUTENull()
            {
                return this.IsNull(this.tableZATVARANJA.DATUMVALUTEColumn);
            }

            [DebuggerNonUserCode]
            public bool IsdugujeNull()
            {
                return this.IsNull(this.tableZATVARANJA.dugujeColumn);
            }

            [DebuggerNonUserCode]
            public bool IsIDPARTNERNull()
            {
                return this.IsNull(this.tableZATVARANJA.IDPARTNERColumn);
            }

            [DebuggerNonUserCode]
            public bool IsOPISNull()
            {
                return this.IsNull(this.tableZATVARANJA.OPISColumn);
            }

            [DebuggerNonUserCode]
            public bool IsPOTRAZUJENull()
            {
                return this.IsNull(this.tableZATVARANJA.POTRAZUJEColumn);
            }

            [DebuggerNonUserCode]
            public bool IsZATVARANJAIZNOSNull()
            {
                return this.IsNull(this.tableZATVARANJA.ZATVARANJAIZNOSColumn);
            }

            [DebuggerNonUserCode]
            public bool IsZATVORENIIZNOSNull()
            {
                return this.IsNull(this.tableZATVARANJA.ZATVORENIIZNOSColumn);
            }

            [DebuggerNonUserCode]
            public void SetDATUMDVONull()
            {
                this[this.tableZATVARANJA.DATUMDVOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetDATUMPRIJAVENull()
            {
                this[this.tableZATVARANJA.DATUMPRIJAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetDATUMVALUTENull()
            {
                this[this.tableZATVARANJA.DATUMVALUTEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetdugujeNull()
            {
                this[this.tableZATVARANJA.dugujeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetIDPARTNERNull()
            {
                this[this.tableZATVARANJA.IDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetOPISNull()
            {
                this[this.tableZATVARANJA.OPISColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetPOTRAZUJENull()
            {
                this[this.tableZATVARANJA.POTRAZUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetZATVARANJAIZNOSNull()
            {
                this[this.tableZATVARANJA.ZATVARANJAIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetZATVORENIIZNOSNull()
            {
                this[this.tableZATVARANJA.ZATVORENIIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public string BROJDOKUMENTA
            {
                get
                {
                    return Conversions.ToString(this[this.tableZATVARANJA.BROJDOKUMENTAColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.BROJDOKUMENTAColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string BROJSTAVKE
            {
                get
                {
                    return Conversions.ToString(this[this.tableZATVARANJA.BROJSTAVKEColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.BROJSTAVKEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public DateTime DATUMDOKUMENTA
            {
                get
                {
                    return Conversions.ToDate(this[this.tableZATVARANJA.DATUMDOKUMENTAColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.DATUMDOKUMENTAColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public DateTime DATUMDVO
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableZATVARANJA.DATUMDVOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'DATUMDVO' in table 'ZATVARANJA' is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableZATVARANJA.DATUMDVOColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public DateTime DATUMPRIJAVE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableZATVARANJA.DATUMPRIJAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'DATUMPRIJAVE' in table 'ZATVARANJA' is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableZATVARANJA.DATUMPRIJAVEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public DateTime DATUMVALUTE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableZATVARANJA.DATUMVALUTEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'DATUMVALUTE' in table 'ZATVARANJA' is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableZATVARANJA.DATUMVALUTEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal duguje
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableZATVARANJA.dugujeColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'DUGUJE' in table 'ZATVARANJA' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableZATVARANJA.dugujeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public long GK1IDGKSTAVKA
            {
                get
                {
                    return Conversions.ToLong(this[this.tableZATVARANJA.GK1IDGKSTAVKAColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.GK1IDGKSTAVKAColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public long GK2IDGKSTAVKA
            {
                get
                {
                    return Conversions.ToLong(this[this.tableZATVARANJA.GK2IDGKSTAVKAColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.GK2IDGKSTAVKAColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string IDDOKUMENT
            {
                get
                {
                    return Conversions.ToString(this[this.tableZATVARANJA.IDDOKUMENTColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.IDDOKUMENTColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public int IDGKSTAVKA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableZATVARANJA.IDGKSTAVKAColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.IDGKSTAVKAColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string IDKONTO
            {
                get
                {
                    return Conversions.ToString(this[this.tableZATVARANJA.IDKONTOColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.IDKONTOColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string IDMJESTOTROSKA
            {
                get
                {
                    return Conversions.ToString(this[this.tableZATVARANJA.IDMJESTOTROSKAColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.IDMJESTOTROSKAColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string IDORGJED
            {
                get
                {
                    return Conversions.ToString(this[this.tableZATVARANJA.IDORGJEDColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.IDORGJEDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string IDPARTNER
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableZATVARANJA.IDPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'IDPARTNER' in table 'ZATVARANJA' is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableZATVARANJA.IDPARTNERColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string NAZIVDOKUMENT
            {
                get
                {
                    return Conversions.ToString(this[this.tableZATVARANJA.NAZIVDOKUMENTColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.NAZIVDOKUMENTColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string NAZIVKONTO
            {
                get
                {
                    return Conversions.ToString(this[this.tableZATVARANJA.NAZIVKONTOColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.NAZIVKONTOColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string NAZIVMJESTOTROSKA
            {
                get
                {
                    return Conversions.ToString(this[this.tableZATVARANJA.NAZIVMJESTOTROSKAColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.NAZIVMJESTOTROSKAColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string NAZIVORGJED
            {
                get
                {
                    return Conversions.ToString(this[this.tableZATVARANJA.NAZIVORGJEDColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.NAZIVORGJEDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string NAZIVPARTNER
            {
                get
                {
                    return Conversions.ToString(this[this.tableZATVARANJA.NAZIVPARTNERColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.NAZIVPARTNERColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string OPIS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableZATVARANJA.OPISColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'OPIS' in table 'ZATVARANJA' is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableZATVARANJA.OPISColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal POTRAZUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableZATVARANJA.POTRAZUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'POTRAZUJE' in table 'ZATVARANJA' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableZATVARANJA.POTRAZUJEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string SKRACENIDOKUMENT
            {
                get
                {
                    return Conversions.ToString(this[this.tableZATVARANJA.SKRACENIDOKUMENTColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.SKRACENIDOKUMENTColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal ZATVARANJAIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableZATVARANJA.ZATVARANJAIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'ZATVARANJAIZNOS' in table 'ZATVARANJA' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableZATVARANJA.ZATVARANJAIZNOSColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal ZATVORENIIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableZATVARANJA.ZATVORENIIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'ZATVORENIIZNOS' in table 'ZATVARANJA' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableZATVARANJA.ZATVORENIIZNOSColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class ZATVARANJARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsZatvaranja.ZATVARANJARow eventRow;

            [DebuggerNonUserCode]
            public ZATVARANJARowChangeEvent(dsZatvaranja.ZATVARANJARow row, DataRowAction action)
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
            public dsZatvaranja.ZATVARANJARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void ZATVARANJARowChangeEventHandler(object sender, dsZatvaranja.ZATVARANJARowChangeEvent e);
    }
}

