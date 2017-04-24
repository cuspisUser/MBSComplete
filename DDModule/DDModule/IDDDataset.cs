namespace DDModule
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

    [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlRoot("IDDDataset"), XmlSchemaProvider("GetTypedDataSetSchema"), ToolboxItem(true), DesignerCategory("code"), HelpKeyword("vs.data.DataSet")]
    public class IDDDataset : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private kolona3DataTable tablekolona3;
        private kolona4DataTable tablekolona4;
        private kolona5DataTable tablekolona5;
        private kolona6DataTable tablekolona6;
        private kolona7DataTable tablekolona7;
        private testDataTable tabletest;

        [DebuggerNonUserCode]
        public IDDDataset()
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
        protected IDDDataset(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["kolona3"] != null)
                    {
                        base.Tables.Add(new kolona3DataTable(dataSet.Tables["kolona3"]));
                    }
                    if (dataSet.Tables["kolona4"] != null)
                    {
                        base.Tables.Add(new kolona4DataTable(dataSet.Tables["kolona4"]));
                    }
                    if (dataSet.Tables["kolona5"] != null)
                    {
                        base.Tables.Add(new kolona5DataTable(dataSet.Tables["kolona5"]));
                    }
                    if (dataSet.Tables["kolona6"] != null)
                    {
                        base.Tables.Add(new kolona6DataTable(dataSet.Tables["kolona6"]));
                    }
                    if (dataSet.Tables["kolona7"] != null)
                    {
                        base.Tables.Add(new kolona7DataTable(dataSet.Tables["kolona7"]));
                    }
                    if (dataSet.Tables["test"] != null)
                    {
                        base.Tables.Add(new testDataTable(dataSet.Tables["test"]));
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
            IDDDataset dataset = (IDDDataset) base.Clone();
            dataset.InitVars();
            dataset.SchemaSerializationMode = this.SchemaSerializationMode;
            return dataset;
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
            IDDDataset dataset = new IDDDataset();
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = dataset.Namespace
            };
            sequence.Items.Add(item);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = dataset.GetSchemaSerializable();
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
            this.DataSetName = "IDDDataset";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/IDDDataset.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tablekolona3 = new kolona3DataTable();
            base.Tables.Add(this.tablekolona3);
            this.tablekolona4 = new kolona4DataTable();
            base.Tables.Add(this.tablekolona4);
            this.tablekolona5 = new kolona5DataTable();
            base.Tables.Add(this.tablekolona5);
            this.tablekolona6 = new kolona6DataTable();
            base.Tables.Add(this.tablekolona6);
            this.tablekolona7 = new kolona7DataTable();
            base.Tables.Add(this.tablekolona7);
            this.tabletest = new testDataTable();
            base.Tables.Add(this.tabletest);
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
            this.tablekolona3 = (kolona3DataTable) base.Tables["kolona3"];
            if (initTable && (this.tablekolona3 != null))
            {
                this.tablekolona3.InitVars();
            }
            this.tablekolona4 = (kolona4DataTable) base.Tables["kolona4"];
            if (initTable && (this.tablekolona4 != null))
            {
                this.tablekolona4.InitVars();
            }
            this.tablekolona5 = (kolona5DataTable) base.Tables["kolona5"];
            if (initTable && (this.tablekolona5 != null))
            {
                this.tablekolona5.InitVars();
            }
            this.tablekolona6 = (kolona6DataTable) base.Tables["kolona6"];
            if (initTable && (this.tablekolona6 != null))
            {
                this.tablekolona6.InitVars();
            }
            this.tablekolona7 = (kolona7DataTable) base.Tables["kolona7"];
            if (initTable && (this.tablekolona7 != null))
            {
                this.tablekolona7.InitVars();
            }
            this.tabletest = (testDataTable) base.Tables["test"];
            if (initTable && (this.tabletest != null))
            {
                this.tabletest.InitVars();
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
                if (dataSet.Tables["kolona3"] != null)
                {
                    base.Tables.Add(new kolona3DataTable(dataSet.Tables["kolona3"]));
                }
                if (dataSet.Tables["kolona4"] != null)
                {
                    base.Tables.Add(new kolona4DataTable(dataSet.Tables["kolona4"]));
                }
                if (dataSet.Tables["kolona5"] != null)
                {
                    base.Tables.Add(new kolona5DataTable(dataSet.Tables["kolona5"]));
                }
                if (dataSet.Tables["kolona6"] != null)
                {
                    base.Tables.Add(new kolona6DataTable(dataSet.Tables["kolona6"]));
                }
                if (dataSet.Tables["kolona7"] != null)
                {
                    base.Tables.Add(new kolona7DataTable(dataSet.Tables["kolona7"]));
                }
                if (dataSet.Tables["test"] != null)
                {
                    base.Tables.Add(new testDataTable(dataSet.Tables["test"]));
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
        private bool ShouldSerializekolona3()
        {
            return false;
        }

        [DebuggerNonUserCode]
        private bool ShouldSerializekolona4()
        {
            return false;
        }

        [DebuggerNonUserCode]
        private bool ShouldSerializekolona5()
        {
            return false;
        }

        [DebuggerNonUserCode]
        private bool ShouldSerializekolona6()
        {
            return false;
        }

        [DebuggerNonUserCode]
        private bool ShouldSerializekolona7()
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

        [DebuggerNonUserCode]
        private bool ShouldSerializetest()
        {
            return false;
        }

        [DebuggerNonUserCode, Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public kolona3DataTable kolona3
        {
            get
            {
                return this.tablekolona3;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), DebuggerNonUserCode]
        public kolona4DataTable kolona4
        {
            get
            {
                return this.tablekolona4;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), DebuggerNonUserCode]
        public kolona5DataTable kolona5
        {
            get
            {
                return this.tablekolona5;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public kolona6DataTable kolona6
        {
            get
            {
                return this.tablekolona6;
            }
        }

        [Browsable(false), DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public kolona7DataTable kolona7
        {
            get
            {
                return this.tablekolona7;
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

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public testDataTable test
        {
            get
            {
                return this.tabletest;
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona3DataTable : TypedTableBase<IDDDataset.kolona3Row>
        {
            private DataColumn columnbrojprimatelja;
            private DataColumn columnidtest;
            private DataColumn columninoz;
            private DataColumn columnizdatak;
            private DataColumn columnmio1;
            private DataColumn columnmio2;
            private DataColumn columnmioukupno;
            private DataColumn columnosnovicadoprinos;
            private DataColumn columnosnovicaporez;
            private DataColumn columnpdv;
            private DataColumn columnporez;
            private DataColumn columnprimici;
            private DataColumn columnprirez;
            private DataColumn columnzast;
            private DataColumn columnzdr;

            public event IDDDataset.kolona3RowChangeEventHandler kolona3RowChanged;

            public event IDDDataset.kolona3RowChangeEventHandler kolona3RowChanging;

            public event IDDDataset.kolona3RowChangeEventHandler kolona3RowDeleted;

            public event IDDDataset.kolona3RowChangeEventHandler kolona3RowDeleting;

            [DebuggerNonUserCode]
            public kolona3DataTable()
            {
                this.TableName = "kolona3";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal kolona3DataTable(DataTable table)
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
            protected kolona3DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void Addkolona3Row(IDDDataset.kolona3Row row)
            {
                this.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona3Row Addkolona3Row(short brojprimatelja, decimal mio1, decimal mio2, decimal mioukupno, decimal osnovicadoprinos, decimal primici, decimal izdatak, decimal osnovicaporez, decimal porez, decimal prirez, decimal pdv, decimal zdr, decimal zast, decimal inoz, string idtest)
            {
                IDDDataset.kolona3Row row = (IDDDataset.kolona3Row) this.NewRow();
                row.ItemArray = new object[] { brojprimatelja, mio1, mio2, mioukupno, osnovicadoprinos, primici, izdatak, osnovicaporez, porez, prirez, pdv, zdr, zast, inoz, idtest };
                this.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                IDDDataset.kolona3DataTable table = (IDDDataset.kolona3DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new IDDDataset.kolona3DataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(IDDDataset.kolona3Row);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                IDDDataset dataset = new IDDDataset();
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
                    FixedValue = dataset.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "kolona3DataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                XmlSchema schemaSerializable = dataset.GetSchemaSerializable();
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
                this.columnbrojprimatelja = new DataColumn("brojprimatelja", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnbrojprimatelja);
                this.columnmio1 = new DataColumn("mio1", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmio1);
                this.columnmio2 = new DataColumn("mio2", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmio2);
                this.columnmioukupno = new DataColumn("mioukupno", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmioukupno);
                this.columnosnovicadoprinos = new DataColumn("osnovicadoprinos", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnosnovicadoprinos);
                this.columnprimici = new DataColumn("primici", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnprimici);
                this.columnizdatak = new DataColumn("izdatak", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnizdatak);
                this.columnosnovicaporez = new DataColumn("osnovicaporez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnosnovicaporez);
                this.columnporez = new DataColumn("porez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnporez);
                this.columnprirez = new DataColumn("prirez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnprirez);
                this.columnpdv = new DataColumn("pdv", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnpdv);
                this.columnzdr = new DataColumn("zdr", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnzdr);
                this.columnzast = new DataColumn("zast", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnzast);
                this.columninoz = new DataColumn("inoz", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columninoz);
                this.columnidtest = new DataColumn("idtest", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnidtest);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnbrojprimatelja = base.Columns["brojprimatelja"];
                this.columnmio1 = base.Columns["mio1"];
                this.columnmio2 = base.Columns["mio2"];
                this.columnmioukupno = base.Columns["mioukupno"];
                this.columnosnovicadoprinos = base.Columns["osnovicadoprinos"];
                this.columnprimici = base.Columns["primici"];
                this.columnizdatak = base.Columns["izdatak"];
                this.columnosnovicaporez = base.Columns["osnovicaporez"];
                this.columnporez = base.Columns["porez"];
                this.columnprirez = base.Columns["prirez"];
                this.columnpdv = base.Columns["pdv"];
                this.columnzdr = base.Columns["zdr"];
                this.columnzast = base.Columns["zast"];
                this.columninoz = base.Columns["inoz"];
                this.columnidtest = base.Columns["idtest"];
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona3Row Newkolona3Row()
            {
                return (IDDDataset.kolona3Row) this.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new IDDDataset.kolona3Row(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.kolona3RowChanged != null)
                {
                    IDDDataset.kolona3RowChangeEventHandler handler = this.kolona3RowChanged;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona3RowChangeEvent((IDDDataset.kolona3Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.kolona3RowChanging != null)
                {
                    IDDDataset.kolona3RowChangeEventHandler handler = this.kolona3RowChanging;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona3RowChangeEvent((IDDDataset.kolona3Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.kolona3RowDeleted != null)
                {
                    IDDDataset.kolona3RowChangeEventHandler handler = this.kolona3RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona3RowChangeEvent((IDDDataset.kolona3Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.kolona3RowDeleting != null)
                {
                    IDDDataset.kolona3RowChangeEventHandler handler = this.kolona3RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona3RowChangeEvent((IDDDataset.kolona3Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            public void Removekolona3Row(IDDDataset.kolona3Row row)
            {
                this.Rows.Remove(row);
            }

            [DebuggerNonUserCode]
            public DataColumn brojprimateljaColumn
            {
                get
                {
                    return this.columnbrojprimatelja;
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
            public DataColumn idtestColumn
            {
                get
                {
                    return this.columnidtest;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn inozColumn
            {
                get
                {
                    return this.columninoz;
                }
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona3Row this[int index]
            {
                get
                {
                    return (IDDDataset.kolona3Row) this.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn izdatakColumn
            {
                get
                {
                    return this.columnizdatak;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mio1Column
            {
                get
                {
                    return this.columnmio1;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mio2Column
            {
                get
                {
                    return this.columnmio2;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mioukupnoColumn
            {
                get
                {
                    return this.columnmioukupno;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn osnovicadoprinosColumn
            {
                get
                {
                    return this.columnosnovicadoprinos;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn osnovicaporezColumn
            {
                get
                {
                    return this.columnosnovicaporez;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn pdvColumn
            {
                get
                {
                    return this.columnpdv;
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
            public DataColumn primiciColumn
            {
                get
                {
                    return this.columnprimici;
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
            public DataColumn zastColumn
            {
                get
                {
                    return this.columnzast;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn zdrColumn
            {
                get
                {
                    return this.columnzdr;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona3Row : DataRow
        {
            private IDDDataset.kolona3DataTable tablekolona3;

            [DebuggerNonUserCode]
            internal kolona3Row(DataRowBuilder rb) : base(rb)
            {
                this.tablekolona3 = (IDDDataset.kolona3DataTable) this.Table;
            }

            [DebuggerNonUserCode]
            public bool IsbrojprimateljaNull()
            {
                return this.IsNull(this.tablekolona3.brojprimateljaColumn);
            }

            [DebuggerNonUserCode]
            public bool IsidtestNull()
            {
                return this.IsNull(this.tablekolona3.idtestColumn);
            }

            [DebuggerNonUserCode]
            public bool IsinozNull()
            {
                return this.IsNull(this.tablekolona3.inozColumn);
            }

            [DebuggerNonUserCode]
            public bool IsizdatakNull()
            {
                return this.IsNull(this.tablekolona3.izdatakColumn);
            }

            [DebuggerNonUserCode]
            public bool Ismio1Null()
            {
                return this.IsNull(this.tablekolona3.mio1Column);
            }

            [DebuggerNonUserCode]
            public bool Ismio2Null()
            {
                return this.IsNull(this.tablekolona3.mio2Column);
            }

            [DebuggerNonUserCode]
            public bool IsmioukupnoNull()
            {
                return this.IsNull(this.tablekolona3.mioukupnoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsosnovicadoprinosNull()
            {
                return this.IsNull(this.tablekolona3.osnovicadoprinosColumn);
            }

            [DebuggerNonUserCode]
            public bool IsosnovicaporezNull()
            {
                return this.IsNull(this.tablekolona3.osnovicaporezColumn);
            }

            [DebuggerNonUserCode]
            public bool IspdvNull()
            {
                return this.IsNull(this.tablekolona3.pdvColumn);
            }

            [DebuggerNonUserCode]
            public bool IsporezNull()
            {
                return this.IsNull(this.tablekolona3.porezColumn);
            }

            [DebuggerNonUserCode]
            public bool IsprimiciNull()
            {
                return this.IsNull(this.tablekolona3.primiciColumn);
            }

            [DebuggerNonUserCode]
            public bool IsprirezNull()
            {
                return this.IsNull(this.tablekolona3.prirezColumn);
            }

            [DebuggerNonUserCode]
            public bool IszastNull()
            {
                return this.IsNull(this.tablekolona3.zastColumn);
            }

            [DebuggerNonUserCode]
            public bool IszdrNull()
            {
                return this.IsNull(this.tablekolona3.zdrColumn);
            }

            [DebuggerNonUserCode]
            public void SetbrojprimateljaNull()
            {
                this[this.tablekolona3.brojprimateljaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetidtestNull()
            {
                this[this.tablekolona3.idtestColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetinozNull()
            {
                this[this.tablekolona3.inozColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetizdatakNull()
            {
                this[this.tablekolona3.izdatakColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void Setmio1Null()
            {
                this[this.tablekolona3.mio1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void Setmio2Null()
            {
                this[this.tablekolona3.mio2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetmioukupnoNull()
            {
                this[this.tablekolona3.mioukupnoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetosnovicadoprinosNull()
            {
                this[this.tablekolona3.osnovicadoprinosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetosnovicaporezNull()
            {
                this[this.tablekolona3.osnovicaporezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetpdvNull()
            {
                this[this.tablekolona3.pdvColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetporezNull()
            {
                this[this.tablekolona3.porezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetprimiciNull()
            {
                this[this.tablekolona3.primiciColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetprirezNull()
            {
                this[this.tablekolona3.prirezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetzastNull()
            {
                this[this.tablekolona3.zastColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetzdrNull()
            {
                this[this.tablekolona3.zdrColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public short brojprimatelja
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tablekolona3.brojprimateljaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.brojprimateljaColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string idtest
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablekolona3.idtestColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablekolona3.idtestColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal inoz
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona3.inozColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.inozColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal izdatak
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona3.izdatakColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.izdatakColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mio1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona3.mio1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.mio1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mio2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona3.mio2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.mio2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mioukupno
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona3.mioukupnoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.mioukupnoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal osnovicadoprinos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona3.osnovicadoprinosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.osnovicadoprinosColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal osnovicaporez
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona3.osnovicaporezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.osnovicaporezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal pdv
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona3.pdvColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.pdvColumn] = value;
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
                        num = Conversions.ToDecimal(this[this.tablekolona3.porezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.porezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal primici
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona3.primiciColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.primiciColumn] = value;
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
                        num = Conversions.ToDecimal(this[this.tablekolona3.prirezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.prirezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal zast
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona3.zastColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.zastColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal zdr
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona3.zdrColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona3.zdrColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona3RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private IDDDataset.kolona3Row eventRow;

            [DebuggerNonUserCode]
            public kolona3RowChangeEvent(IDDDataset.kolona3Row row, DataRowAction action)
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
            public IDDDataset.kolona3Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void kolona3RowChangeEventHandler(object sender, IDDDataset.kolona3RowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona4DataTable : TypedTableBase<IDDDataset.kolona4Row>
        {
            private DataColumn columnbrojprimatelja;
            private DataColumn columnidtest;
            private DataColumn columninoz;
            private DataColumn columnizdatak;
            private DataColumn columnmio1;
            private DataColumn columnmio2;
            private DataColumn columnmioukupno;
            private DataColumn columnosnovicadoprinos;
            private DataColumn columnosnovicaporez;
            private DataColumn columnpdv;
            private DataColumn columnporez;
            private DataColumn columnprimici;
            private DataColumn columnprirez;
            private DataColumn columnzast;
            private DataColumn columnzdr;

            public event IDDDataset.kolona4RowChangeEventHandler kolona4RowChanged;

            public event IDDDataset.kolona4RowChangeEventHandler kolona4RowChanging;

            public event IDDDataset.kolona4RowChangeEventHandler kolona4RowDeleted;

            public event IDDDataset.kolona4RowChangeEventHandler kolona4RowDeleting;

            [DebuggerNonUserCode]
            public kolona4DataTable()
            {
                this.TableName = "kolona4";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal kolona4DataTable(DataTable table)
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
            protected kolona4DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void Addkolona4Row(IDDDataset.kolona4Row row)
            {
                this.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona4Row Addkolona4Row(short brojprimatelja, decimal mio1, decimal mio2, decimal mioukupno, decimal osnovicadoprinos, decimal primici, decimal izdatak, decimal osnovicaporez, decimal porez, decimal prirez, decimal pdv, decimal zdr, decimal zast, decimal inoz, string idtest)
            {
                IDDDataset.kolona4Row row = (IDDDataset.kolona4Row) this.NewRow();
                row.ItemArray = new object[] { brojprimatelja, mio1, mio2, mioukupno, osnovicadoprinos, primici, izdatak, osnovicaporez, porez, prirez, pdv, zdr, zast, inoz, idtest };
                this.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                IDDDataset.kolona4DataTable table = (IDDDataset.kolona4DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new IDDDataset.kolona4DataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(IDDDataset.kolona4Row);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                IDDDataset dataset = new IDDDataset();
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
                    FixedValue = dataset.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "kolona4DataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                XmlSchema schemaSerializable = dataset.GetSchemaSerializable();
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
                this.columnbrojprimatelja = new DataColumn("brojprimatelja", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnbrojprimatelja);
                this.columnmio1 = new DataColumn("mio1", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmio1);
                this.columnmio2 = new DataColumn("mio2", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmio2);
                this.columnmioukupno = new DataColumn("mioukupno", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmioukupno);
                this.columnosnovicadoprinos = new DataColumn("osnovicadoprinos", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnosnovicadoprinos);
                this.columnprimici = new DataColumn("primici", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnprimici);
                this.columnizdatak = new DataColumn("izdatak", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnizdatak);
                this.columnosnovicaporez = new DataColumn("osnovicaporez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnosnovicaporez);
                this.columnporez = new DataColumn("porez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnporez);
                this.columnprirez = new DataColumn("prirez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnprirez);
                this.columnpdv = new DataColumn("pdv", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnpdv);
                this.columnzdr = new DataColumn("zdr", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnzdr);
                this.columnzast = new DataColumn("zast", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnzast);
                this.columninoz = new DataColumn("inoz", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columninoz);
                this.columnidtest = new DataColumn("idtest", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnidtest);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnbrojprimatelja = base.Columns["brojprimatelja"];
                this.columnmio1 = base.Columns["mio1"];
                this.columnmio2 = base.Columns["mio2"];
                this.columnmioukupno = base.Columns["mioukupno"];
                this.columnosnovicadoprinos = base.Columns["osnovicadoprinos"];
                this.columnprimici = base.Columns["primici"];
                this.columnizdatak = base.Columns["izdatak"];
                this.columnosnovicaporez = base.Columns["osnovicaporez"];
                this.columnporez = base.Columns["porez"];
                this.columnprirez = base.Columns["prirez"];
                this.columnpdv = base.Columns["pdv"];
                this.columnzdr = base.Columns["zdr"];
                this.columnzast = base.Columns["zast"];
                this.columninoz = base.Columns["inoz"];
                this.columnidtest = base.Columns["idtest"];
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona4Row Newkolona4Row()
            {
                return (IDDDataset.kolona4Row) this.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new IDDDataset.kolona4Row(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.kolona4RowChanged != null)
                {
                    IDDDataset.kolona4RowChangeEventHandler handler = this.kolona4RowChanged;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona4RowChangeEvent((IDDDataset.kolona4Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.kolona4RowChanging != null)
                {
                    IDDDataset.kolona4RowChangeEventHandler handler = this.kolona4RowChanging;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona4RowChangeEvent((IDDDataset.kolona4Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.kolona4RowDeleted != null)
                {
                    IDDDataset.kolona4RowChangeEventHandler handler = this.kolona4RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona4RowChangeEvent((IDDDataset.kolona4Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.kolona4RowDeleting != null)
                {
                    IDDDataset.kolona4RowChangeEventHandler handler = this.kolona4RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona4RowChangeEvent((IDDDataset.kolona4Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            public void Removekolona4Row(IDDDataset.kolona4Row row)
            {
                this.Rows.Remove(row);
            }

            [DebuggerNonUserCode]
            public DataColumn brojprimateljaColumn
            {
                get
                {
                    return this.columnbrojprimatelja;
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
            public DataColumn idtestColumn
            {
                get
                {
                    return this.columnidtest;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn inozColumn
            {
                get
                {
                    return this.columninoz;
                }
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona4Row this[int index]
            {
                get
                {
                    return (IDDDataset.kolona4Row) this.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn izdatakColumn
            {
                get
                {
                    return this.columnizdatak;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mio1Column
            {
                get
                {
                    return this.columnmio1;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mio2Column
            {
                get
                {
                    return this.columnmio2;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mioukupnoColumn
            {
                get
                {
                    return this.columnmioukupno;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn osnovicadoprinosColumn
            {
                get
                {
                    return this.columnosnovicadoprinos;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn osnovicaporezColumn
            {
                get
                {
                    return this.columnosnovicaporez;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn pdvColumn
            {
                get
                {
                    return this.columnpdv;
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
            public DataColumn primiciColumn
            {
                get
                {
                    return this.columnprimici;
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
            public DataColumn zastColumn
            {
                get
                {
                    return this.columnzast;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn zdrColumn
            {
                get
                {
                    return this.columnzdr;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona4Row : DataRow
        {
            private IDDDataset.kolona4DataTable tablekolona4;

            [DebuggerNonUserCode]
            internal kolona4Row(DataRowBuilder rb) : base(rb)
            {
                this.tablekolona4 = (IDDDataset.kolona4DataTable) this.Table;
            }

            [DebuggerNonUserCode]
            public bool IsbrojprimateljaNull()
            {
                return this.IsNull(this.tablekolona4.brojprimateljaColumn);
            }

            [DebuggerNonUserCode]
            public bool IsidtestNull()
            {
                return this.IsNull(this.tablekolona4.idtestColumn);
            }

            [DebuggerNonUserCode]
            public bool IsinozNull()
            {
                return this.IsNull(this.tablekolona4.inozColumn);
            }

            [DebuggerNonUserCode]
            public bool IsizdatakNull()
            {
                return this.IsNull(this.tablekolona4.izdatakColumn);
            }

            [DebuggerNonUserCode]
            public bool Ismio1Null()
            {
                return this.IsNull(this.tablekolona4.mio1Column);
            }

            [DebuggerNonUserCode]
            public bool Ismio2Null()
            {
                return this.IsNull(this.tablekolona4.mio2Column);
            }

            [DebuggerNonUserCode]
            public bool IsmioukupnoNull()
            {
                return this.IsNull(this.tablekolona4.mioukupnoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsosnovicadoprinosNull()
            {
                return this.IsNull(this.tablekolona4.osnovicadoprinosColumn);
            }

            [DebuggerNonUserCode]
            public bool IsosnovicaporezNull()
            {
                return this.IsNull(this.tablekolona4.osnovicaporezColumn);
            }

            [DebuggerNonUserCode]
            public bool IspdvNull()
            {
                return this.IsNull(this.tablekolona4.pdvColumn);
            }

            [DebuggerNonUserCode]
            public bool IsporezNull()
            {
                return this.IsNull(this.tablekolona4.porezColumn);
            }

            [DebuggerNonUserCode]
            public bool IsprimiciNull()
            {
                return this.IsNull(this.tablekolona4.primiciColumn);
            }

            [DebuggerNonUserCode]
            public bool IsprirezNull()
            {
                return this.IsNull(this.tablekolona4.prirezColumn);
            }

            [DebuggerNonUserCode]
            public bool IszastNull()
            {
                return this.IsNull(this.tablekolona4.zastColumn);
            }

            [DebuggerNonUserCode]
            public bool IszdrNull()
            {
                return this.IsNull(this.tablekolona4.zdrColumn);
            }

            [DebuggerNonUserCode]
            public void SetbrojprimateljaNull()
            {
                this[this.tablekolona4.brojprimateljaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetidtestNull()
            {
                this[this.tablekolona4.idtestColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetinozNull()
            {
                this[this.tablekolona4.inozColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetizdatakNull()
            {
                this[this.tablekolona4.izdatakColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void Setmio1Null()
            {
                this[this.tablekolona4.mio1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void Setmio2Null()
            {
                this[this.tablekolona4.mio2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetmioukupnoNull()
            {
                this[this.tablekolona4.mioukupnoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetosnovicadoprinosNull()
            {
                this[this.tablekolona4.osnovicadoprinosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetosnovicaporezNull()
            {
                this[this.tablekolona4.osnovicaporezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetpdvNull()
            {
                this[this.tablekolona4.pdvColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetporezNull()
            {
                this[this.tablekolona4.porezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetprimiciNull()
            {
                this[this.tablekolona4.primiciColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetprirezNull()
            {
                this[this.tablekolona4.prirezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetzastNull()
            {
                this[this.tablekolona4.zastColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetzdrNull()
            {
                this[this.tablekolona4.zdrColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public short brojprimatelja
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tablekolona4.brojprimateljaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.brojprimateljaColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string idtest
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablekolona4.idtestColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablekolona4.idtestColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal inoz
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona4.inozColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.inozColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal izdatak
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona4.izdatakColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.izdatakColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mio1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona4.mio1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.mio1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mio2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona4.mio2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.mio2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mioukupno
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona4.mioukupnoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.mioukupnoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal osnovicadoprinos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona4.osnovicadoprinosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.osnovicadoprinosColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal osnovicaporez
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona4.osnovicaporezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'osnovicaporez' in table 'kolona4' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.osnovicaporezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal pdv
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona4.pdvColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.pdvColumn] = value;
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
                        num = Conversions.ToDecimal(this[this.tablekolona4.porezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.porezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal primici
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona4.primiciColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.primiciColumn] = value;
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
                        num = Conversions.ToDecimal(this[this.tablekolona4.prirezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.prirezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal zast
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona4.zastColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.zastColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal zdr
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona4.zdrColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona4.zdrColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona4RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private IDDDataset.kolona4Row eventRow;

            [DebuggerNonUserCode]
            public kolona4RowChangeEvent(IDDDataset.kolona4Row row, DataRowAction action)
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
            public IDDDataset.kolona4Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void kolona4RowChangeEventHandler(object sender, IDDDataset.kolona4RowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona5DataTable : TypedTableBase<IDDDataset.kolona5Row>
        {
            private DataColumn columnbrojprimatelja;
            private DataColumn columnidtest;
            private DataColumn columninoz;
            private DataColumn columnizdatak;
            private DataColumn columnmio1;
            private DataColumn columnmio2;
            private DataColumn columnmioukupno;
            private DataColumn columnosnovicadoprinos;
            private DataColumn columnosnovicaporez;
            private DataColumn columnpdv;
            private DataColumn columnporez;
            private DataColumn columnprimici;
            private DataColumn columnprirez;
            private DataColumn columnzast;
            private DataColumn columnzdr;

            public event IDDDataset.kolona5RowChangeEventHandler kolona5RowChanged;

            public event IDDDataset.kolona5RowChangeEventHandler kolona5RowChanging;

            public event IDDDataset.kolona5RowChangeEventHandler kolona5RowDeleted;

            public event IDDDataset.kolona5RowChangeEventHandler kolona5RowDeleting;

            [DebuggerNonUserCode]
            public kolona5DataTable()
            {
                this.TableName = "kolona5";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal kolona5DataTable(DataTable table)
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
            protected kolona5DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void Addkolona5Row(IDDDataset.kolona5Row row)
            {
                this.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona5Row Addkolona5Row(short brojprimatelja, decimal mio1, decimal mio2, decimal mioukupno, decimal osnovicadoprinos, decimal primici, decimal izdatak, decimal osnovicaporez, decimal porez, decimal prirez, decimal pdv, decimal zdr, decimal zast, decimal inoz, string idtest)
            {
                IDDDataset.kolona5Row row = (IDDDataset.kolona5Row) this.NewRow();
                row.ItemArray = new object[] { brojprimatelja, mio1, mio2, mioukupno, osnovicadoprinos, primici, izdatak, osnovicaporez, porez, prirez, pdv, zdr, zast, inoz, idtest };
                this.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                IDDDataset.kolona5DataTable table = (IDDDataset.kolona5DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new IDDDataset.kolona5DataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(IDDDataset.kolona5Row);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                IDDDataset dataset = new IDDDataset();
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
                    FixedValue = dataset.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "kolona5DataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                XmlSchema schemaSerializable = dataset.GetSchemaSerializable();
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
                this.columnbrojprimatelja = new DataColumn("brojprimatelja", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnbrojprimatelja);
                this.columnmio1 = new DataColumn("mio1", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmio1);
                this.columnmio2 = new DataColumn("mio2", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmio2);
                this.columnmioukupno = new DataColumn("mioukupno", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmioukupno);
                this.columnosnovicadoprinos = new DataColumn("osnovicadoprinos", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnosnovicadoprinos);
                this.columnprimici = new DataColumn("primici", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnprimici);
                this.columnizdatak = new DataColumn("izdatak", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnizdatak);
                this.columnosnovicaporez = new DataColumn("osnovicaporez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnosnovicaporez);
                this.columnporez = new DataColumn("porez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnporez);
                this.columnprirez = new DataColumn("prirez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnprirez);
                this.columnpdv = new DataColumn("pdv", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnpdv);
                this.columnzdr = new DataColumn("zdr", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnzdr);
                this.columnzast = new DataColumn("zast", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnzast);
                this.columninoz = new DataColumn("inoz", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columninoz);
                this.columnidtest = new DataColumn("idtest", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnidtest);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnbrojprimatelja = base.Columns["brojprimatelja"];
                this.columnmio1 = base.Columns["mio1"];
                this.columnmio2 = base.Columns["mio2"];
                this.columnmioukupno = base.Columns["mioukupno"];
                this.columnosnovicadoprinos = base.Columns["osnovicadoprinos"];
                this.columnprimici = base.Columns["primici"];
                this.columnizdatak = base.Columns["izdatak"];
                this.columnosnovicaporez = base.Columns["osnovicaporez"];
                this.columnporez = base.Columns["porez"];
                this.columnprirez = base.Columns["prirez"];
                this.columnpdv = base.Columns["pdv"];
                this.columnzdr = base.Columns["zdr"];
                this.columnzast = base.Columns["zast"];
                this.columninoz = base.Columns["inoz"];
                this.columnidtest = base.Columns["idtest"];
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona5Row Newkolona5Row()
            {
                return (IDDDataset.kolona5Row) this.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new IDDDataset.kolona5Row(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.kolona5RowChanged != null)
                {
                    IDDDataset.kolona5RowChangeEventHandler handler = this.kolona5RowChanged;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona5RowChangeEvent((IDDDataset.kolona5Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.kolona5RowChanging != null)
                {
                    IDDDataset.kolona5RowChangeEventHandler handler = this.kolona5RowChanging;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona5RowChangeEvent((IDDDataset.kolona5Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.kolona5RowDeleted != null)
                {
                    IDDDataset.kolona5RowChangeEventHandler handler = this.kolona5RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona5RowChangeEvent((IDDDataset.kolona5Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.kolona5RowDeleting != null)
                {
                    IDDDataset.kolona5RowChangeEventHandler handler = this.kolona5RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona5RowChangeEvent((IDDDataset.kolona5Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            public void Removekolona5Row(IDDDataset.kolona5Row row)
            {
                this.Rows.Remove(row);
            }

            [DebuggerNonUserCode]
            public DataColumn brojprimateljaColumn
            {
                get
                {
                    return this.columnbrojprimatelja;
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
            public DataColumn idtestColumn
            {
                get
                {
                    return this.columnidtest;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn inozColumn
            {
                get
                {
                    return this.columninoz;
                }
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona5Row this[int index]
            {
                get
                {
                    return (IDDDataset.kolona5Row) this.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn izdatakColumn
            {
                get
                {
                    return this.columnizdatak;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mio1Column
            {
                get
                {
                    return this.columnmio1;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mio2Column
            {
                get
                {
                    return this.columnmio2;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mioukupnoColumn
            {
                get
                {
                    return this.columnmioukupno;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn osnovicadoprinosColumn
            {
                get
                {
                    return this.columnosnovicadoprinos;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn osnovicaporezColumn
            {
                get
                {
                    return this.columnosnovicaporez;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn pdvColumn
            {
                get
                {
                    return this.columnpdv;
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
            public DataColumn primiciColumn
            {
                get
                {
                    return this.columnprimici;
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
            public DataColumn zastColumn
            {
                get
                {
                    return this.columnzast;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn zdrColumn
            {
                get
                {
                    return this.columnzdr;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona5Row : DataRow
        {
            private IDDDataset.kolona5DataTable tablekolona5;

            [DebuggerNonUserCode]
            internal kolona5Row(DataRowBuilder rb) : base(rb)
            {
                this.tablekolona5 = (IDDDataset.kolona5DataTable) this.Table;
            }

            [DebuggerNonUserCode]
            public bool IsbrojprimateljaNull()
            {
                return this.IsNull(this.tablekolona5.brojprimateljaColumn);
            }

            [DebuggerNonUserCode]
            public bool IsidtestNull()
            {
                return this.IsNull(this.tablekolona5.idtestColumn);
            }

            [DebuggerNonUserCode]
            public bool IsinozNull()
            {
                return this.IsNull(this.tablekolona5.inozColumn);
            }

            [DebuggerNonUserCode]
            public bool IsizdatakNull()
            {
                return this.IsNull(this.tablekolona5.izdatakColumn);
            }

            [DebuggerNonUserCode]
            public bool Ismio1Null()
            {
                return this.IsNull(this.tablekolona5.mio1Column);
            }

            [DebuggerNonUserCode]
            public bool Ismio2Null()
            {
                return this.IsNull(this.tablekolona5.mio2Column);
            }

            [DebuggerNonUserCode]
            public bool IsmioukupnoNull()
            {
                return this.IsNull(this.tablekolona5.mioukupnoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsosnovicadoprinosNull()
            {
                return this.IsNull(this.tablekolona5.osnovicadoprinosColumn);
            }

            [DebuggerNonUserCode]
            public bool IsosnovicaporezNull()
            {
                return this.IsNull(this.tablekolona5.osnovicaporezColumn);
            }

            [DebuggerNonUserCode]
            public bool IspdvNull()
            {
                return this.IsNull(this.tablekolona5.pdvColumn);
            }

            [DebuggerNonUserCode]
            public bool IsporezNull()
            {
                return this.IsNull(this.tablekolona5.porezColumn);
            }

            [DebuggerNonUserCode]
            public bool IsprimiciNull()
            {
                return this.IsNull(this.tablekolona5.primiciColumn);
            }

            [DebuggerNonUserCode]
            public bool IsprirezNull()
            {
                return this.IsNull(this.tablekolona5.prirezColumn);
            }

            [DebuggerNonUserCode]
            public bool IszastNull()
            {
                return this.IsNull(this.tablekolona5.zastColumn);
            }

            [DebuggerNonUserCode]
            public bool IszdrNull()
            {
                return this.IsNull(this.tablekolona5.zdrColumn);
            }

            [DebuggerNonUserCode]
            public void SetbrojprimateljaNull()
            {
                this[this.tablekolona5.brojprimateljaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetidtestNull()
            {
                this[this.tablekolona5.idtestColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetinozNull()
            {
                this[this.tablekolona5.inozColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetizdatakNull()
            {
                this[this.tablekolona5.izdatakColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void Setmio1Null()
            {
                this[this.tablekolona5.mio1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void Setmio2Null()
            {
                this[this.tablekolona5.mio2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetmioukupnoNull()
            {
                this[this.tablekolona5.mioukupnoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetosnovicadoprinosNull()
            {
                this[this.tablekolona5.osnovicadoprinosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetosnovicaporezNull()
            {
                this[this.tablekolona5.osnovicaporezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetpdvNull()
            {
                this[this.tablekolona5.pdvColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetporezNull()
            {
                this[this.tablekolona5.porezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetprimiciNull()
            {
                this[this.tablekolona5.primiciColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetprirezNull()
            {
                this[this.tablekolona5.prirezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetzastNull()
            {
                this[this.tablekolona5.zastColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetzdrNull()
            {
                this[this.tablekolona5.zdrColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public short brojprimatelja
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tablekolona5.brojprimateljaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.brojprimateljaColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string idtest
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablekolona5.idtestColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablekolona5.idtestColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal inoz
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona5.inozColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.inozColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal izdatak
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona5.izdatakColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.izdatakColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mio1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona5.mio1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.mio1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mio2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona5.mio2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.mio2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mioukupno
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona5.mioukupnoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.mioukupnoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal osnovicadoprinos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona5.osnovicadoprinosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.osnovicadoprinosColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal osnovicaporez
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona5.osnovicaporezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.osnovicaporezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal pdv
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona5.pdvColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.pdvColumn] = value;
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
                        num = Conversions.ToDecimal(this[this.tablekolona5.porezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.porezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal primici
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona5.primiciColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.primiciColumn] = value;
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
                        num = Conversions.ToDecimal(this[this.tablekolona5.prirezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.prirezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal zast
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona5.zastColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.zastColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal zdr
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona5.zdrColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona5.zdrColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona5RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private IDDDataset.kolona5Row eventRow;

            [DebuggerNonUserCode]
            public kolona5RowChangeEvent(IDDDataset.kolona5Row row, DataRowAction action)
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
            public IDDDataset.kolona5Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void kolona5RowChangeEventHandler(object sender, IDDDataset.kolona5RowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona6DataTable : TypedTableBase<IDDDataset.kolona6Row>
        {
            private DataColumn columnbrojprimatelja;
            private DataColumn columnidtest;
            private DataColumn columninoz;
            private DataColumn columnizdatak;
            private DataColumn columnmio1;
            private DataColumn columnmio2;
            private DataColumn columnmioukupno;
            private DataColumn columnosnovicadoprinos;
            private DataColumn columnosnovicaporez;
            private DataColumn columnpdv;
            private DataColumn columnporez;
            private DataColumn columnprimici;
            private DataColumn columnprirez;
            private DataColumn columnzast;
            private DataColumn columnzdr;

            public event IDDDataset.kolona6RowChangeEventHandler kolona6RowChanged;

            public event IDDDataset.kolona6RowChangeEventHandler kolona6RowChanging;

            public event IDDDataset.kolona6RowChangeEventHandler kolona6RowDeleted;

            public event IDDDataset.kolona6RowChangeEventHandler kolona6RowDeleting;

            [DebuggerNonUserCode]
            public kolona6DataTable()
            {
                this.TableName = "kolona6";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal kolona6DataTable(DataTable table)
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
            protected kolona6DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void Addkolona6Row(IDDDataset.kolona6Row row)
            {
                this.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona6Row Addkolona6Row(short brojprimatelja, decimal mio1, decimal mio2, decimal mioukupno, decimal osnovicadoprinos, decimal primici, decimal izdatak, decimal osnovicaporez, decimal porez, decimal prirez, decimal pdv, decimal zdr, decimal zast, decimal inoz, string idtest)
            {
                IDDDataset.kolona6Row row = (IDDDataset.kolona6Row) this.NewRow();
                row.ItemArray = new object[] { brojprimatelja, mio1, mio2, mioukupno, osnovicadoprinos, primici, izdatak, osnovicaporez, porez, prirez, pdv, zdr, zast, inoz, idtest };
                this.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                IDDDataset.kolona6DataTable table = (IDDDataset.kolona6DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new IDDDataset.kolona6DataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(IDDDataset.kolona6Row);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                IDDDataset dataset = new IDDDataset();
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
                    FixedValue = dataset.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "kolona6DataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                XmlSchema schemaSerializable = dataset.GetSchemaSerializable();
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
                this.columnbrojprimatelja = new DataColumn("brojprimatelja", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnbrojprimatelja);
                this.columnmio1 = new DataColumn("mio1", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmio1);
                this.columnmio2 = new DataColumn("mio2", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmio2);
                this.columnmioukupno = new DataColumn("mioukupno", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmioukupno);
                this.columnosnovicadoprinos = new DataColumn("osnovicadoprinos", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnosnovicadoprinos);
                this.columnprimici = new DataColumn("primici", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnprimici);
                this.columnizdatak = new DataColumn("izdatak", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnizdatak);
                this.columnosnovicaporez = new DataColumn("osnovicaporez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnosnovicaporez);
                this.columnporez = new DataColumn("porez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnporez);
                this.columnprirez = new DataColumn("prirez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnprirez);
                this.columnpdv = new DataColumn("pdv", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnpdv);
                this.columnzdr = new DataColumn("zdr", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnzdr);
                this.columnzast = new DataColumn("zast", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnzast);
                this.columninoz = new DataColumn("inoz", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columninoz);
                this.columnidtest = new DataColumn("idtest", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnidtest);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnbrojprimatelja = base.Columns["brojprimatelja"];
                this.columnmio1 = base.Columns["mio1"];
                this.columnmio2 = base.Columns["mio2"];
                this.columnmioukupno = base.Columns["mioukupno"];
                this.columnosnovicadoprinos = base.Columns["osnovicadoprinos"];
                this.columnprimici = base.Columns["primici"];
                this.columnizdatak = base.Columns["izdatak"];
                this.columnosnovicaporez = base.Columns["osnovicaporez"];
                this.columnporez = base.Columns["porez"];
                this.columnprirez = base.Columns["prirez"];
                this.columnpdv = base.Columns["pdv"];
                this.columnzdr = base.Columns["zdr"];
                this.columnzast = base.Columns["zast"];
                this.columninoz = base.Columns["inoz"];
                this.columnidtest = base.Columns["idtest"];
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona6Row Newkolona6Row()
            {
                return (IDDDataset.kolona6Row) this.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new IDDDataset.kolona6Row(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.kolona6RowChanged != null)
                {
                    IDDDataset.kolona6RowChangeEventHandler handler = this.kolona6RowChanged;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona6RowChangeEvent((IDDDataset.kolona6Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.kolona6RowChanging != null)
                {
                    IDDDataset.kolona6RowChangeEventHandler handler = this.kolona6RowChanging;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona6RowChangeEvent((IDDDataset.kolona6Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.kolona6RowDeleted != null)
                {
                    IDDDataset.kolona6RowChangeEventHandler handler = this.kolona6RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona6RowChangeEvent((IDDDataset.kolona6Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.kolona6RowDeleting != null)
                {
                    IDDDataset.kolona6RowChangeEventHandler handler = this.kolona6RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona6RowChangeEvent((IDDDataset.kolona6Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            public void Removekolona6Row(IDDDataset.kolona6Row row)
            {
                this.Rows.Remove(row);
            }

            [DebuggerNonUserCode]
            public DataColumn brojprimateljaColumn
            {
                get
                {
                    return this.columnbrojprimatelja;
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
            public DataColumn idtestColumn
            {
                get
                {
                    return this.columnidtest;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn inozColumn
            {
                get
                {
                    return this.columninoz;
                }
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona6Row this[int index]
            {
                get
                {
                    return (IDDDataset.kolona6Row) this.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn izdatakColumn
            {
                get
                {
                    return this.columnizdatak;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mio1Column
            {
                get
                {
                    return this.columnmio1;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mio2Column
            {
                get
                {
                    return this.columnmio2;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mioukupnoColumn
            {
                get
                {
                    return this.columnmioukupno;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn osnovicadoprinosColumn
            {
                get
                {
                    return this.columnosnovicadoprinos;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn osnovicaporezColumn
            {
                get
                {
                    return this.columnosnovicaporez;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn pdvColumn
            {
                get
                {
                    return this.columnpdv;
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
            public DataColumn primiciColumn
            {
                get
                {
                    return this.columnprimici;
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
            public DataColumn zastColumn
            {
                get
                {
                    return this.columnzast;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn zdrColumn
            {
                get
                {
                    return this.columnzdr;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona6Row : DataRow
        {
            private IDDDataset.kolona6DataTable tablekolona6;

            [DebuggerNonUserCode]
            internal kolona6Row(DataRowBuilder rb) : base(rb)
            {
                this.tablekolona6 = (IDDDataset.kolona6DataTable) this.Table;
            }

            [DebuggerNonUserCode]
            public bool IsbrojprimateljaNull()
            {
                return this.IsNull(this.tablekolona6.brojprimateljaColumn);
            }

            [DebuggerNonUserCode]
            public bool IsidtestNull()
            {
                return this.IsNull(this.tablekolona6.idtestColumn);
            }

            [DebuggerNonUserCode]
            public bool IsinozNull()
            {
                return this.IsNull(this.tablekolona6.inozColumn);
            }

            [DebuggerNonUserCode]
            public bool IsizdatakNull()
            {
                return this.IsNull(this.tablekolona6.izdatakColumn);
            }

            [DebuggerNonUserCode]
            public bool Ismio1Null()
            {
                return this.IsNull(this.tablekolona6.mio1Column);
            }

            [DebuggerNonUserCode]
            public bool Ismio2Null()
            {
                return this.IsNull(this.tablekolona6.mio2Column);
            }

            [DebuggerNonUserCode]
            public bool IsmioukupnoNull()
            {
                return this.IsNull(this.tablekolona6.mioukupnoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsosnovicadoprinosNull()
            {
                return this.IsNull(this.tablekolona6.osnovicadoprinosColumn);
            }

            [DebuggerNonUserCode]
            public bool IsosnovicaporezNull()
            {
                return this.IsNull(this.tablekolona6.osnovicaporezColumn);
            }

            [DebuggerNonUserCode]
            public bool IspdvNull()
            {
                return this.IsNull(this.tablekolona6.pdvColumn);
            }

            [DebuggerNonUserCode]
            public bool IsporezNull()
            {
                return this.IsNull(this.tablekolona6.porezColumn);
            }

            [DebuggerNonUserCode]
            public bool IsprimiciNull()
            {
                return this.IsNull(this.tablekolona6.primiciColumn);
            }

            [DebuggerNonUserCode]
            public bool IsprirezNull()
            {
                return this.IsNull(this.tablekolona6.prirezColumn);
            }

            [DebuggerNonUserCode]
            public bool IszastNull()
            {
                return this.IsNull(this.tablekolona6.zastColumn);
            }

            [DebuggerNonUserCode]
            public bool IszdrNull()
            {
                return this.IsNull(this.tablekolona6.zdrColumn);
            }

            [DebuggerNonUserCode]
            public void SetbrojprimateljaNull()
            {
                this[this.tablekolona6.brojprimateljaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetidtestNull()
            {
                this[this.tablekolona6.idtestColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetinozNull()
            {
                this[this.tablekolona6.inozColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetizdatakNull()
            {
                this[this.tablekolona6.izdatakColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void Setmio1Null()
            {
                this[this.tablekolona6.mio1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void Setmio2Null()
            {
                this[this.tablekolona6.mio2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetmioukupnoNull()
            {
                this[this.tablekolona6.mioukupnoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetosnovicadoprinosNull()
            {
                this[this.tablekolona6.osnovicadoprinosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetosnovicaporezNull()
            {
                this[this.tablekolona6.osnovicaporezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetpdvNull()
            {
                this[this.tablekolona6.pdvColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetporezNull()
            {
                this[this.tablekolona6.porezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetprimiciNull()
            {
                this[this.tablekolona6.primiciColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetprirezNull()
            {
                this[this.tablekolona6.prirezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetzastNull()
            {
                this[this.tablekolona6.zastColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetzdrNull()
            {
                this[this.tablekolona6.zdrColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public short brojprimatelja
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tablekolona6.brojprimateljaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.brojprimateljaColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string idtest
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablekolona6.idtestColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablekolona6.idtestColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal inoz
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona6.inozColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'inoz' in table 'kolona6' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.inozColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal izdatak
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona6.izdatakColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.izdatakColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mio1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona6.mio1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.mio1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mio2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona6.mio2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.mio2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mioukupno
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona6.mioukupnoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.mioukupnoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal osnovicadoprinos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona6.osnovicadoprinosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'osnovicadoprinos' in table 'kolona6' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.osnovicadoprinosColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal osnovicaporez
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona6.osnovicaporezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.osnovicaporezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal pdv
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona6.pdvColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.pdvColumn] = value;
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
                        num = Conversions.ToDecimal(this[this.tablekolona6.porezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.porezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal primici
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona6.primiciColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'primici' in table 'kolona6' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.primiciColumn] = value;
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
                        num = Conversions.ToDecimal(this[this.tablekolona6.prirezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.prirezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal zast
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona6.zastColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.zastColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal zdr
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona6.zdrColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona6.zdrColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona6RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private IDDDataset.kolona6Row eventRow;

            [DebuggerNonUserCode]
            public kolona6RowChangeEvent(IDDDataset.kolona6Row row, DataRowAction action)
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
            public IDDDataset.kolona6Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void kolona6RowChangeEventHandler(object sender, IDDDataset.kolona6RowChangeEvent e);

        [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedTableSchema")]
        public class kolona7DataTable : TypedTableBase<IDDDataset.kolona7Row>
        {
            private DataColumn columnbrojprimatelja;
            private DataColumn columnidtest;
            private DataColumn columninoz;
            private DataColumn columnizdatak;
            private DataColumn columnmio1;
            private DataColumn columnmio2;
            private DataColumn columnmioukupno;
            private DataColumn columnosnovicadoprinos;
            private DataColumn columnosnovicaporez;
            private DataColumn columnpdv;
            private DataColumn columnporez;
            private DataColumn columnprimici;
            private DataColumn columnprirez;
            private DataColumn columnzast;
            private DataColumn columnzdr;

            public event IDDDataset.kolona7RowChangeEventHandler kolona7RowChanged;

            public event IDDDataset.kolona7RowChangeEventHandler kolona7RowChanging;

            public event IDDDataset.kolona7RowChangeEventHandler kolona7RowDeleted;

            public event IDDDataset.kolona7RowChangeEventHandler kolona7RowDeleting;

            [DebuggerNonUserCode]
            public kolona7DataTable()
            {
                this.TableName = "kolona7";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal kolona7DataTable(DataTable table)
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
            protected kolona7DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void Addkolona7Row(IDDDataset.kolona7Row row)
            {
                this.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona7Row Addkolona7Row(short brojprimatelja, decimal mio1, decimal mio2, decimal mioukupno, decimal osnovicadoprinos, decimal primici, decimal izdatak, decimal osnovicaporez, decimal porez, decimal prirez, decimal pdv, decimal zdr, decimal zast, decimal inoz, string idtest)
            {
                IDDDataset.kolona7Row row = (IDDDataset.kolona7Row) this.NewRow();
                row.ItemArray = new object[] { brojprimatelja, mio1, mio2, mioukupno, osnovicadoprinos, primici, izdatak, osnovicaporez, porez, prirez, pdv, zdr, zast, inoz, idtest };
                this.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                IDDDataset.kolona7DataTable table = (IDDDataset.kolona7DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new IDDDataset.kolona7DataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(IDDDataset.kolona7Row);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                IDDDataset dataset = new IDDDataset();
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
                    FixedValue = dataset.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "kolona7DataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                XmlSchema schemaSerializable = dataset.GetSchemaSerializable();
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
                this.columnbrojprimatelja = new DataColumn("brojprimatelja", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnbrojprimatelja);
                this.columnmio1 = new DataColumn("mio1", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmio1);
                this.columnmio2 = new DataColumn("mio2", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmio2);
                this.columnmioukupno = new DataColumn("mioukupno", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnmioukupno);
                this.columnosnovicadoprinos = new DataColumn("osnovicadoprinos", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnosnovicadoprinos);
                this.columnprimici = new DataColumn("primici", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnprimici);
                this.columnizdatak = new DataColumn("izdatak", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnizdatak);
                this.columnosnovicaporez = new DataColumn("osnovicaporez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnosnovicaporez);
                this.columnporez = new DataColumn("porez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnporez);
                this.columnprirez = new DataColumn("prirez", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnprirez);
                this.columnpdv = new DataColumn("pdv", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnpdv);
                this.columnzdr = new DataColumn("zdr", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnzdr);
                this.columnzast = new DataColumn("zast", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnzast);
                this.columninoz = new DataColumn("inoz", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columninoz);
                this.columnidtest = new DataColumn("idtest", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnidtest);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnbrojprimatelja = base.Columns["brojprimatelja"];
                this.columnmio1 = base.Columns["mio1"];
                this.columnmio2 = base.Columns["mio2"];
                this.columnmioukupno = base.Columns["mioukupno"];
                this.columnosnovicadoprinos = base.Columns["osnovicadoprinos"];
                this.columnprimici = base.Columns["primici"];
                this.columnizdatak = base.Columns["izdatak"];
                this.columnosnovicaporez = base.Columns["osnovicaporez"];
                this.columnporez = base.Columns["porez"];
                this.columnprirez = base.Columns["prirez"];
                this.columnpdv = base.Columns["pdv"];
                this.columnzdr = base.Columns["zdr"];
                this.columnzast = base.Columns["zast"];
                this.columninoz = base.Columns["inoz"];
                this.columnidtest = base.Columns["idtest"];
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona7Row Newkolona7Row()
            {
                return (IDDDataset.kolona7Row) this.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new IDDDataset.kolona7Row(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.kolona7RowChanged != null)
                {
                    IDDDataset.kolona7RowChangeEventHandler handler = this.kolona7RowChanged;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona7RowChangeEvent((IDDDataset.kolona7Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.kolona7RowChanging != null)
                {
                    IDDDataset.kolona7RowChangeEventHandler handler = this.kolona7RowChanging;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona7RowChangeEvent((IDDDataset.kolona7Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.kolona7RowDeleted != null)
                {
                    IDDDataset.kolona7RowChangeEventHandler handler = this.kolona7RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona7RowChangeEvent((IDDDataset.kolona7Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.kolona7RowDeleting != null)
                {
                    IDDDataset.kolona7RowChangeEventHandler handler = this.kolona7RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new IDDDataset.kolona7RowChangeEvent((IDDDataset.kolona7Row) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            public void Removekolona7Row(IDDDataset.kolona7Row row)
            {
                this.Rows.Remove(row);
            }

            [DebuggerNonUserCode]
            public DataColumn brojprimateljaColumn
            {
                get
                {
                    return this.columnbrojprimatelja;
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
            public DataColumn idtestColumn
            {
                get
                {
                    return this.columnidtest;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn inozColumn
            {
                get
                {
                    return this.columninoz;
                }
            }

            [DebuggerNonUserCode]
            public IDDDataset.kolona7Row this[int index]
            {
                get
                {
                    return (IDDDataset.kolona7Row) this.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn izdatakColumn
            {
                get
                {
                    return this.columnizdatak;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mio1Column
            {
                get
                {
                    return this.columnmio1;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mio2Column
            {
                get
                {
                    return this.columnmio2;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mioukupnoColumn
            {
                get
                {
                    return this.columnmioukupno;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn osnovicadoprinosColumn
            {
                get
                {
                    return this.columnosnovicadoprinos;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn osnovicaporezColumn
            {
                get
                {
                    return this.columnosnovicaporez;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn pdvColumn
            {
                get
                {
                    return this.columnpdv;
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
            public DataColumn primiciColumn
            {
                get
                {
                    return this.columnprimici;
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
            public DataColumn zastColumn
            {
                get
                {
                    return this.columnzast;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn zdrColumn
            {
                get
                {
                    return this.columnzdr;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona7Row : DataRow
        {
            private IDDDataset.kolona7DataTable tablekolona7;

            [DebuggerNonUserCode]
            internal kolona7Row(DataRowBuilder rb) : base(rb)
            {
                this.tablekolona7 = (IDDDataset.kolona7DataTable) this.Table;
            }

            [DebuggerNonUserCode]
            public bool IsbrojprimateljaNull()
            {
                return this.IsNull(this.tablekolona7.brojprimateljaColumn);
            }

            [DebuggerNonUserCode]
            public bool IsidtestNull()
            {
                return this.IsNull(this.tablekolona7.idtestColumn);
            }

            [DebuggerNonUserCode]
            public bool IsinozNull()
            {
                return this.IsNull(this.tablekolona7.inozColumn);
            }

            [DebuggerNonUserCode]
            public bool IsizdatakNull()
            {
                return this.IsNull(this.tablekolona7.izdatakColumn);
            }

            [DebuggerNonUserCode]
            public bool Ismio1Null()
            {
                return this.IsNull(this.tablekolona7.mio1Column);
            }

            [DebuggerNonUserCode]
            public bool Ismio2Null()
            {
                return this.IsNull(this.tablekolona7.mio2Column);
            }

            [DebuggerNonUserCode]
            public bool IsmioukupnoNull()
            {
                return this.IsNull(this.tablekolona7.mioukupnoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsosnovicadoprinosNull()
            {
                return this.IsNull(this.tablekolona7.osnovicadoprinosColumn);
            }

            [DebuggerNonUserCode]
            public bool IsosnovicaporezNull()
            {
                return this.IsNull(this.tablekolona7.osnovicaporezColumn);
            }

            [DebuggerNonUserCode]
            public bool IspdvNull()
            {
                return this.IsNull(this.tablekolona7.pdvColumn);
            }

            [DebuggerNonUserCode]
            public bool IsporezNull()
            {
                return this.IsNull(this.tablekolona7.porezColumn);
            }

            [DebuggerNonUserCode]
            public bool IsprimiciNull()
            {
                return this.IsNull(this.tablekolona7.primiciColumn);
            }

            [DebuggerNonUserCode]
            public bool IsprirezNull()
            {
                return this.IsNull(this.tablekolona7.prirezColumn);
            }

            [DebuggerNonUserCode]
            public bool IszastNull()
            {
                return this.IsNull(this.tablekolona7.zastColumn);
            }

            [DebuggerNonUserCode]
            public bool IszdrNull()
            {
                return this.IsNull(this.tablekolona7.zdrColumn);
            }

            [DebuggerNonUserCode]
            public void SetbrojprimateljaNull()
            {
                this[this.tablekolona7.brojprimateljaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetidtestNull()
            {
                this[this.tablekolona7.idtestColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetinozNull()
            {
                this[this.tablekolona7.inozColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetizdatakNull()
            {
                this[this.tablekolona7.izdatakColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void Setmio1Null()
            {
                this[this.tablekolona7.mio1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void Setmio2Null()
            {
                this[this.tablekolona7.mio2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetmioukupnoNull()
            {
                this[this.tablekolona7.mioukupnoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetosnovicadoprinosNull()
            {
                this[this.tablekolona7.osnovicadoprinosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetosnovicaporezNull()
            {
                this[this.tablekolona7.osnovicaporezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetpdvNull()
            {
                this[this.tablekolona7.pdvColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetporezNull()
            {
                this[this.tablekolona7.porezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetprimiciNull()
            {
                this[this.tablekolona7.primiciColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetprirezNull()
            {
                this[this.tablekolona7.prirezColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetzastNull()
            {
                this[this.tablekolona7.zastColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetzdrNull()
            {
                this[this.tablekolona7.zdrColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public short brojprimatelja
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tablekolona7.brojprimateljaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'brojprimatelja' in table 'kolona7' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.brojprimateljaColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string idtest
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablekolona7.idtestColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablekolona7.idtestColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal inoz
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona7.inozColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'inoz' in table 'kolona7' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.inozColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal izdatak
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona7.izdatakColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.izdatakColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mio1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona7.mio1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.mio1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mio2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona7.mio2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.mio2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal mioukupno
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona7.mioukupnoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'mioukupno' in table 'kolona7' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.mioukupnoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal osnovicadoprinos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona7.osnovicadoprinosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.osnovicadoprinosColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal osnovicaporez
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona7.osnovicaporezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'osnovicaporez' in table 'kolona7' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.osnovicaporezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal pdv
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona7.pdvColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'pdv' in table 'kolona7' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.pdvColumn] = value;
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
                        num = Conversions.ToDecimal(this[this.tablekolona7.porezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'porez' in table 'kolona7' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.porezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal primici
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona7.primiciColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'primici' in table 'kolona7' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.primiciColumn] = value;
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
                        num = Conversions.ToDecimal(this[this.tablekolona7.prirezColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'prirez' in table 'kolona7' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.prirezColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal zast
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona7.zastColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'zast' in table 'kolona7' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.zastColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal zdr
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablekolona7.zdrColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'zdr' in table 'kolona7' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tablekolona7.zdrColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class kolona7RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private IDDDataset.kolona7Row eventRow;

            [DebuggerNonUserCode]
            public kolona7RowChangeEvent(IDDDataset.kolona7Row row, DataRowAction action)
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
            public IDDDataset.kolona7Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void kolona7RowChangeEventHandler(object sender, IDDDataset.kolona7RowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class testDataTable : TypedTableBase<IDDDataset.testRow>
        {
            private DataColumn columnidtest;

            public event IDDDataset.testRowChangeEventHandler testRowChanged;

            public event IDDDataset.testRowChangeEventHandler testRowChanging;

            public event IDDDataset.testRowChangeEventHandler testRowDeleted;

            public event IDDDataset.testRowChangeEventHandler testRowDeleting;

            [DebuggerNonUserCode]
            public testDataTable()
            {
                this.TableName = "test";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal testDataTable(DataTable table)
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
            protected testDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddtestRow(IDDDataset.testRow row)
            {
                this.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public IDDDataset.testRow AddtestRow(string idtest)
            {
                IDDDataset.testRow row = (IDDDataset.testRow) this.NewRow();
                row.ItemArray = new object[] { idtest };
                this.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                IDDDataset.testDataTable table = (IDDDataset.testDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new IDDDataset.testDataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(IDDDataset.testRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                IDDDataset dataset = new IDDDataset();
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
                    FixedValue = dataset.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "testDataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                XmlSchema schemaSerializable = dataset.GetSchemaSerializable();
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
                this.columnidtest = new DataColumn("idtest", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnidtest);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnidtest = base.Columns["idtest"];
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new IDDDataset.testRow(builder);
            }

            [DebuggerNonUserCode]
            public IDDDataset.testRow NewtestRow()
            {
                return (IDDDataset.testRow) this.NewRow();
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.testRowChanged != null)
                {
                    IDDDataset.testRowChangeEventHandler testRowChangedEvent = this.testRowChanged;
                    if (testRowChangedEvent != null)
                    {
                        testRowChangedEvent(this, new IDDDataset.testRowChangeEvent((IDDDataset.testRow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.testRowChanging != null)
                {
                    IDDDataset.testRowChangeEventHandler testRowChangingEvent = this.testRowChanging;
                    if (testRowChangingEvent != null)
                    {
                        testRowChangingEvent(this, new IDDDataset.testRowChangeEvent((IDDDataset.testRow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.testRowDeleted != null)
                {
                    IDDDataset.testRowChangeEventHandler testRowDeletedEvent = this.testRowDeleted;
                    if (testRowDeletedEvent != null)
                    {
                        testRowDeletedEvent(this, new IDDDataset.testRowChangeEvent((IDDDataset.testRow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.testRowDeleting != null)
                {
                    IDDDataset.testRowChangeEventHandler testRowDeletingEvent = this.testRowDeleting;
                    if (testRowDeletingEvent != null)
                    {
                        testRowDeletingEvent(this, new IDDDataset.testRowChangeEvent((IDDDataset.testRow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            public void RemovetestRow(IDDDataset.testRow row)
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
            public DataColumn idtestColumn
            {
                get
                {
                    return this.columnidtest;
                }
            }

            [DebuggerNonUserCode]
            public IDDDataset.testRow this[int index]
            {
                get
                {
                    return (IDDDataset.testRow) this.Rows[index];
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class testRow : DataRow
        {
            private IDDDataset.testDataTable tabletest;

            [DebuggerNonUserCode]
            internal testRow(DataRowBuilder rb) : base(rb)
            {
                this.tabletest = (IDDDataset.testDataTable) this.Table;
            }

            [DebuggerNonUserCode]
            public bool IsidtestNull()
            {
                return this.IsNull(this.tabletest.idtestColumn);
            }

            [DebuggerNonUserCode]
            public void SetidtestNull()
            {
                this[this.tabletest.idtestColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public string idtest
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tabletest.idtestColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'idtest' in table 'test' is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tabletest.idtestColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class testRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private IDDDataset.testRow eventRow;

            [DebuggerNonUserCode]
            public testRowChangeEvent(IDDDataset.testRow row, DataRowAction action)
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
            public IDDDataset.testRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void testRowChangeEventHandler(object sender, IDDDataset.testRowChangeEvent e);
    }
}

