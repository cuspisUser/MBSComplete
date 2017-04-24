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

    [Serializable, HelpKeyword("vs.data.DataSet"), DesignerCategory("code"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedDataSetSchema"), XmlRoot("dsTotali"), ToolboxItem(true)]
    public class dsTotali : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private REKAPITULACIJADataTable tableREKAPITULACIJA;
        private SATIREKAPITULACIJADataTable tableSATIREKAPITULACIJA;

        [DebuggerNonUserCode]
        public dsTotali()
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
        protected dsTotali(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["SATIREKAPITULACIJA"] != null)
                    {
                        base.Tables.Add(new SATIREKAPITULACIJADataTable(dataSet.Tables["SATIREKAPITULACIJA"]));
                    }
                    if (dataSet.Tables["REKAPITULACIJA"] != null)
                    {
                        base.Tables.Add(new REKAPITULACIJADataTable(dataSet.Tables["REKAPITULACIJA"]));
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
            dsTotali totali = (dsTotali) base.Clone();
            totali.InitVars();
            totali.SchemaSerializationMode = this.SchemaSerializationMode;
            return totali;
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
            dsTotali totali = new dsTotali();
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = totali.Namespace
            };
            sequence.Items.Add(item);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = totali.GetSchemaSerializable();
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
            this.DataSetName = "dsTotali";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/dsTotali.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableSATIREKAPITULACIJA = new SATIREKAPITULACIJADataTable();
            base.Tables.Add(this.tableSATIREKAPITULACIJA);
            this.tableREKAPITULACIJA = new REKAPITULACIJADataTable();
            base.Tables.Add(this.tableREKAPITULACIJA);
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
            this.tableSATIREKAPITULACIJA = (SATIREKAPITULACIJADataTable) base.Tables["SATIREKAPITULACIJA"];
            if (initTable && (this.tableSATIREKAPITULACIJA != null))
            {
                this.tableSATIREKAPITULACIJA.InitVars();
            }
            this.tableREKAPITULACIJA = (REKAPITULACIJADataTable) base.Tables["REKAPITULACIJA"];
            if (initTable && (this.tableREKAPITULACIJA != null))
            {
                this.tableREKAPITULACIJA.InitVars();
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
                if (dataSet.Tables["SATIREKAPITULACIJA"] != null)
                {
                    base.Tables.Add(new SATIREKAPITULACIJADataTable(dataSet.Tables["SATIREKAPITULACIJA"]));
                }
                if (dataSet.Tables["REKAPITULACIJA"] != null)
                {
                    base.Tables.Add(new REKAPITULACIJADataTable(dataSet.Tables["REKAPITULACIJA"]));
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
        private bool ShouldSerializeREKAPITULACIJA()
        {
            return false;
        }

        [DebuggerNonUserCode]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [DebuggerNonUserCode]
        private bool ShouldSerializeSATIREKAPITULACIJA()
        {
            return false;
        }

        [DebuggerNonUserCode]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), DebuggerNonUserCode]
        public REKAPITULACIJADataTable REKAPITULACIJA
        {
            get
            {
                return this.tableREKAPITULACIJA;
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

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public SATIREKAPITULACIJADataTable SATIREKAPITULACIJA
        {
            get
            {
                return this.tableSATIREKAPITULACIJA;
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

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class REKAPITULACIJADataTable : TypedTableBase<dsTotali.REKAPITULACIJARow>
        {
            private DataColumn columniznos;
            private DataColumn columnopis;
            private DataColumn columnsati;

            public event dsTotali.REKAPITULACIJARowChangeEventHandler REKAPITULACIJARowChanged;

            public event dsTotali.REKAPITULACIJARowChangeEventHandler REKAPITULACIJARowChanging;

            public event dsTotali.REKAPITULACIJARowChangeEventHandler REKAPITULACIJARowDeleted;

            public event dsTotali.REKAPITULACIJARowChangeEventHandler REKAPITULACIJARowDeleting;

            [DebuggerNonUserCode]
            public REKAPITULACIJADataTable()
            {
                this.TableName = "REKAPITULACIJA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal REKAPITULACIJADataTable(DataTable table)
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
            protected REKAPITULACIJADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddREKAPITULACIJARow(dsTotali.REKAPITULACIJARow row)
            {
                this.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public dsTotali.REKAPITULACIJARow AddREKAPITULACIJARow(string opis, decimal iznos, decimal sati)
            {
                dsTotali.REKAPITULACIJARow row = (dsTotali.REKAPITULACIJARow) this.NewRow();
                row.ItemArray = new object[] { opis, iznos, sati };
                this.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsTotali.REKAPITULACIJADataTable table = (dsTotali.REKAPITULACIJADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsTotali.REKAPITULACIJADataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsTotali.REKAPITULACIJARow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsTotali totali = new dsTotali();
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
                    FixedValue = totali.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "REKAPITULACIJADataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                XmlSchema schemaSerializable = totali.GetSchemaSerializable();
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
                this.columnopis = new DataColumn("OPIS", typeof(string), null, MappingType.Element);
                this.columnopis.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "opis");
                this.columnopis.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "opisColumn");
                this.columnopis.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnopis");
                this.columnopis.ExtendedProperties.Add("Generator_UserColumnName", "OPIS");
                base.Columns.Add(this.columnopis);
                this.columniznos = new DataColumn("IZNOS", typeof(decimal), null, MappingType.Element);
                this.columniznos.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "iznos");
                this.columniznos.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "iznosColumn");
                this.columniznos.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columniznos");
                this.columniznos.ExtendedProperties.Add("Generator_UserColumnName", "IZNOS");
                base.Columns.Add(this.columniznos);
                this.columnsati = new DataColumn("SATI", typeof(decimal), null, MappingType.Element);
                this.columnsati.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "sati");
                this.columnsati.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "satiColumn");
                this.columnsati.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnsati");
                this.columnsati.ExtendedProperties.Add("Generator_UserColumnName", "SATI");
                base.Columns.Add(this.columnsati);
                this.columnopis.AllowDBNull = false;
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnopis = base.Columns["OPIS"];
                this.columniznos = base.Columns["IZNOS"];
                this.columnsati = base.Columns["SATI"];
            }

            [DebuggerNonUserCode]
            public dsTotali.REKAPITULACIJARow NewREKAPITULACIJARow()
            {
                return (dsTotali.REKAPITULACIJARow) this.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsTotali.REKAPITULACIJARow(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.REKAPITULACIJARowChanged != null)
                {
                    dsTotali.REKAPITULACIJARowChangeEventHandler rEKAPITULACIJARowChangedEvent = this.REKAPITULACIJARowChanged;
                    if (rEKAPITULACIJARowChangedEvent != null)
                    {
                        rEKAPITULACIJARowChangedEvent(this, new dsTotali.REKAPITULACIJARowChangeEvent((dsTotali.REKAPITULACIJARow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.REKAPITULACIJARowChanging != null)
                {
                    dsTotali.REKAPITULACIJARowChangeEventHandler rEKAPITULACIJARowChangingEvent = this.REKAPITULACIJARowChanging;
                    if (rEKAPITULACIJARowChangingEvent != null)
                    {
                        rEKAPITULACIJARowChangingEvent(this, new dsTotali.REKAPITULACIJARowChangeEvent((dsTotali.REKAPITULACIJARow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.REKAPITULACIJARowDeleted != null)
                {
                    dsTotali.REKAPITULACIJARowChangeEventHandler rEKAPITULACIJARowDeletedEvent = this.REKAPITULACIJARowDeleted;
                    if (rEKAPITULACIJARowDeletedEvent != null)
                    {
                        rEKAPITULACIJARowDeletedEvent(this, new dsTotali.REKAPITULACIJARowChangeEvent((dsTotali.REKAPITULACIJARow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.REKAPITULACIJARowDeleting != null)
                {
                    dsTotali.REKAPITULACIJARowChangeEventHandler rEKAPITULACIJARowDeletingEvent = this.REKAPITULACIJARowDeleting;
                    if (rEKAPITULACIJARowDeletingEvent != null)
                    {
                        rEKAPITULACIJARowDeletingEvent(this, new dsTotali.REKAPITULACIJARowChangeEvent((dsTotali.REKAPITULACIJARow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            public void RemoveREKAPITULACIJARow(dsTotali.REKAPITULACIJARow row)
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
            public dsTotali.REKAPITULACIJARow this[int index]
            {
                get
                {
                    return (dsTotali.REKAPITULACIJARow) this.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn iznosColumn
            {
                get
                {
                    return this.columniznos;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn opisColumn
            {
                get
                {
                    return this.columnopis;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn satiColumn
            {
                get
                {
                    return this.columnsati;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class REKAPITULACIJARow : DataRow
        {
            private dsTotali.REKAPITULACIJADataTable tableREKAPITULACIJA;

            [DebuggerNonUserCode]
            internal REKAPITULACIJARow(DataRowBuilder rb) : base(rb)
            {
                this.tableREKAPITULACIJA = (dsTotali.REKAPITULACIJADataTable) this.Table;
            }

            [DebuggerNonUserCode]
            public bool IsiznosNull()
            {
                return this.IsNull(this.tableREKAPITULACIJA.iznosColumn);
            }

            [DebuggerNonUserCode]
            public bool IssatiNull()
            {
                return this.IsNull(this.tableREKAPITULACIJA.satiColumn);
            }

            [DebuggerNonUserCode]
            public void SetiznosNull()
            {
                this[this.tableREKAPITULACIJA.iznosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetsatiNull()
            {
                this[this.tableREKAPITULACIJA.satiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public decimal iznos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableREKAPITULACIJA.iznosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableREKAPITULACIJA.iznosColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string opis
            {
                get
                {
                    return Conversions.ToString(this[this.tableREKAPITULACIJA.opisColumn]);
                }
                set
                {
                    this[this.tableREKAPITULACIJA.opisColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal sati
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableREKAPITULACIJA.satiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableREKAPITULACIJA.satiColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class REKAPITULACIJARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsTotali.REKAPITULACIJARow eventRow;

            [DebuggerNonUserCode]
            public REKAPITULACIJARowChangeEvent(dsTotali.REKAPITULACIJARow row, DataRowAction action)
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
            public dsTotali.REKAPITULACIJARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void REKAPITULACIJARowChangeEventHandler(object sender, dsTotali.REKAPITULACIJARowChangeEvent e);

        [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedTableSchema")]
        public class SATIREKAPITULACIJADataTable : TypedTableBase<dsTotali.SATIREKAPITULACIJARow>
        {
            private DataColumn columnGODINAISPLATE;
            private DataColumn columnGODINAOBRACUNA;
            private DataColumn columnidelement;
            private DataColumn columnidobracun;
            private DataColumn columnidvrstaelementa;
            private DataColumn columniznos;
            private DataColumn columnMJESECISPLATE;
            private DataColumn columnMJESECOBRACUNA;
            private DataColumn columnnazivelement;
            private DataColumn columnnazivvrstaelement;
            private DataColumn columnsati;

            public event dsTotali.SATIREKAPITULACIJARowChangeEventHandler SATIREKAPITULACIJARowChanged;

            public event dsTotali.SATIREKAPITULACIJARowChangeEventHandler SATIREKAPITULACIJARowChanging;

            public event dsTotali.SATIREKAPITULACIJARowChangeEventHandler SATIREKAPITULACIJARowDeleted;

            public event dsTotali.SATIREKAPITULACIJARowChangeEventHandler SATIREKAPITULACIJARowDeleting;

            [DebuggerNonUserCode]
            public SATIREKAPITULACIJADataTable()
            {
                this.TableName = "SATIREKAPITULACIJA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal SATIREKAPITULACIJADataTable(DataTable table)
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
            protected SATIREKAPITULACIJADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddSATIREKAPITULACIJARow(dsTotali.SATIREKAPITULACIJARow row)
            {
                this.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public dsTotali.SATIREKAPITULACIJARow AddSATIREKAPITULACIJARow(decimal sati, decimal iznos, string nazivelement, string nazivvrstaelement, string idvrstaelementa, string idelement, string idobracun, string MJESECISPLATE, string GODINAISPLATE, string MJESECOBRACUNA, string GODINAOBRACUNA)
            {
                dsTotali.SATIREKAPITULACIJARow row = (dsTotali.SATIREKAPITULACIJARow) this.NewRow();
                row.ItemArray = new object[] { sati, iznos, nazivelement, nazivvrstaelement, idvrstaelementa, idelement, idobracun, MJESECISPLATE, GODINAISPLATE, MJESECOBRACUNA, GODINAOBRACUNA };
                this.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsTotali.SATIREKAPITULACIJADataTable table = (dsTotali.SATIREKAPITULACIJADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsTotali.SATIREKAPITULACIJADataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsTotali.SATIREKAPITULACIJARow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsTotali totali = new dsTotali();
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
                    FixedValue = totali.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "SATIREKAPITULACIJADataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                XmlSchema schemaSerializable = totali.GetSchemaSerializable();
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
                this.columnsati = new DataColumn("SATI", typeof(decimal), null, MappingType.Element);
                this.columnsati.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "sati");
                this.columnsati.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "satiColumn");
                this.columnsati.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnsati");
                this.columnsati.ExtendedProperties.Add("Generator_UserColumnName", "SATI");
                base.Columns.Add(this.columnsati);
                this.columniznos = new DataColumn("IZNOS", typeof(decimal), null, MappingType.Element);
                this.columniznos.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "iznos");
                this.columniznos.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "iznosColumn");
                this.columniznos.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columniznos");
                this.columniznos.ExtendedProperties.Add("Generator_UserColumnName", "IZNOS");
                base.Columns.Add(this.columniznos);
                this.columnnazivelement = new DataColumn("NAZIVELEMENT", typeof(string), null, MappingType.Element);
                this.columnnazivelement.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "nazivelement");
                this.columnnazivelement.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "nazivelementColumn");
                this.columnnazivelement.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnnazivelement");
                this.columnnazivelement.ExtendedProperties.Add("Generator_UserColumnName", "NAZIVELEMENT");
                base.Columns.Add(this.columnnazivelement);
                this.columnnazivvrstaelement = new DataColumn("NAZIVVRSTAELEMENT", typeof(string), null, MappingType.Element);
                this.columnnazivvrstaelement.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "nazivvrstaelement");
                this.columnnazivvrstaelement.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "nazivvrstaelementColumn");
                this.columnnazivvrstaelement.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnnazivvrstaelement");
                this.columnnazivvrstaelement.ExtendedProperties.Add("Generator_UserColumnName", "NAZIVVRSTAELEMENT");
                base.Columns.Add(this.columnnazivvrstaelement);
                this.columnidvrstaelementa = new DataColumn("IDVRSTAELEMENTA", typeof(string), null, MappingType.Element);
                this.columnidvrstaelementa.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "idvrstaelementa");
                this.columnidvrstaelementa.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "idvrstaelementaColumn");
                this.columnidvrstaelementa.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnidvrstaelementa");
                this.columnidvrstaelementa.ExtendedProperties.Add("Generator_UserColumnName", "IDVRSTAELEMENTA");
                base.Columns.Add(this.columnidvrstaelementa);
                this.columnidelement = new DataColumn("IDELEMENT", typeof(string), null, MappingType.Element);
                this.columnidelement.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "idelement");
                this.columnidelement.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "idelementColumn");
                this.columnidelement.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnidelement");
                this.columnidelement.ExtendedProperties.Add("Generator_UserColumnName", "IDELEMENT");
                base.Columns.Add(this.columnidelement);
                this.columnidobracun = new DataColumn("idobracun", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnidobracun);
                this.columnMJESECISPLATE = new DataColumn("MJESECISPLATE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMJESECISPLATE);
                this.columnGODINAISPLATE = new DataColumn("GODINAISPLATE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGODINAISPLATE);
                this.columnMJESECOBRACUNA = new DataColumn("MJESECOBRACUNA", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMJESECOBRACUNA);
                this.columnGODINAOBRACUNA = new DataColumn("GODINAOBRACUNA", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGODINAOBRACUNA);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnsati = base.Columns["SATI"];
                this.columniznos = base.Columns["IZNOS"];
                this.columnnazivelement = base.Columns["NAZIVELEMENT"];
                this.columnnazivvrstaelement = base.Columns["NAZIVVRSTAELEMENT"];
                this.columnidvrstaelementa = base.Columns["IDVRSTAELEMENTA"];
                this.columnidelement = base.Columns["IDELEMENT"];
                this.columnidobracun = base.Columns["idobracun"];
                this.columnMJESECISPLATE = base.Columns["MJESECISPLATE"];
                this.columnGODINAISPLATE = base.Columns["GODINAISPLATE"];
                this.columnMJESECOBRACUNA = base.Columns["MJESECOBRACUNA"];
                this.columnGODINAOBRACUNA = base.Columns["GODINAOBRACUNA"];
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsTotali.SATIREKAPITULACIJARow(builder);
            }

            [DebuggerNonUserCode]
            public dsTotali.SATIREKAPITULACIJARow NewSATIREKAPITULACIJARow()
            {
                return (dsTotali.SATIREKAPITULACIJARow) this.NewRow();
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SATIREKAPITULACIJARowChanged != null)
                {
                    dsTotali.SATIREKAPITULACIJARowChangeEventHandler sATIREKAPITULACIJARowChangedEvent = this.SATIREKAPITULACIJARowChanged;
                    if (sATIREKAPITULACIJARowChangedEvent != null)
                    {
                        sATIREKAPITULACIJARowChangedEvent(this, new dsTotali.SATIREKAPITULACIJARowChangeEvent((dsTotali.SATIREKAPITULACIJARow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SATIREKAPITULACIJARowChanging != null)
                {
                    dsTotali.SATIREKAPITULACIJARowChangeEventHandler sATIREKAPITULACIJARowChangingEvent = this.SATIREKAPITULACIJARowChanging;
                    if (sATIREKAPITULACIJARowChangingEvent != null)
                    {
                        sATIREKAPITULACIJARowChangingEvent(this, new dsTotali.SATIREKAPITULACIJARowChangeEvent((dsTotali.SATIREKAPITULACIJARow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SATIREKAPITULACIJARowDeleted != null)
                {
                    dsTotali.SATIREKAPITULACIJARowChangeEventHandler sATIREKAPITULACIJARowDeletedEvent = this.SATIREKAPITULACIJARowDeleted;
                    if (sATIREKAPITULACIJARowDeletedEvent != null)
                    {
                        sATIREKAPITULACIJARowDeletedEvent(this, new dsTotali.SATIREKAPITULACIJARowChangeEvent((dsTotali.SATIREKAPITULACIJARow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SATIREKAPITULACIJARowDeleting != null)
                {
                    dsTotali.SATIREKAPITULACIJARowChangeEventHandler sATIREKAPITULACIJARowDeletingEvent = this.SATIREKAPITULACIJARowDeleting;
                    if (sATIREKAPITULACIJARowDeletingEvent != null)
                    {
                        sATIREKAPITULACIJARowDeletingEvent(this, new dsTotali.SATIREKAPITULACIJARowChangeEvent((dsTotali.SATIREKAPITULACIJARow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            public void RemoveSATIREKAPITULACIJARow(dsTotali.SATIREKAPITULACIJARow row)
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
            public DataColumn GODINAISPLATEColumn
            {
                get
                {
                    return this.columnGODINAISPLATE;
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
            public DataColumn idelementColumn
            {
                get
                {
                    return this.columnidelement;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn idobracunColumn
            {
                get
                {
                    return this.columnidobracun;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn idvrstaelementaColumn
            {
                get
                {
                    return this.columnidvrstaelementa;
                }
            }

            [DebuggerNonUserCode]
            public dsTotali.SATIREKAPITULACIJARow this[int index]
            {
                get
                {
                    return (dsTotali.SATIREKAPITULACIJARow) this.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn iznosColumn
            {
                get
                {
                    return this.columniznos;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn MJESECISPLATEColumn
            {
                get
                {
                    return this.columnMJESECISPLATE;
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
            public DataColumn nazivelementColumn
            {
                get
                {
                    return this.columnnazivelement;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn nazivvrstaelementColumn
            {
                get
                {
                    return this.columnnazivvrstaelement;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn satiColumn
            {
                get
                {
                    return this.columnsati;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class SATIREKAPITULACIJARow : DataRow
        {
            private dsTotali.SATIREKAPITULACIJADataTable tableSATIREKAPITULACIJA;

            [DebuggerNonUserCode]
            internal SATIREKAPITULACIJARow(DataRowBuilder rb) : base(rb)
            {
                this.tableSATIREKAPITULACIJA = (dsTotali.SATIREKAPITULACIJADataTable) this.Table;
            }

            [DebuggerNonUserCode]
            public bool IsGODINAISPLATENull()
            {
                return this.IsNull(this.tableSATIREKAPITULACIJA.GODINAISPLATEColumn);
            }

            [DebuggerNonUserCode]
            public bool IsGODINAOBRACUNANull()
            {
                return this.IsNull(this.tableSATIREKAPITULACIJA.GODINAOBRACUNAColumn);
            }

            [DebuggerNonUserCode]
            public bool IsidelementNull()
            {
                return this.IsNull(this.tableSATIREKAPITULACIJA.idelementColumn);
            }

            [DebuggerNonUserCode]
            public bool IsidobracunNull()
            {
                return this.IsNull(this.tableSATIREKAPITULACIJA.idobracunColumn);
            }

            [DebuggerNonUserCode]
            public bool IsidvrstaelementaNull()
            {
                return this.IsNull(this.tableSATIREKAPITULACIJA.idvrstaelementaColumn);
            }

            [DebuggerNonUserCode]
            public bool IsiznosNull()
            {
                return this.IsNull(this.tableSATIREKAPITULACIJA.iznosColumn);
            }

            [DebuggerNonUserCode]
            public bool IsMJESECISPLATENull()
            {
                return this.IsNull(this.tableSATIREKAPITULACIJA.MJESECISPLATEColumn);
            }

            [DebuggerNonUserCode]
            public bool IsMJESECOBRACUNANull()
            {
                return this.IsNull(this.tableSATIREKAPITULACIJA.MJESECOBRACUNAColumn);
            }

            [DebuggerNonUserCode]
            public bool IsnazivelementNull()
            {
                return this.IsNull(this.tableSATIREKAPITULACIJA.nazivelementColumn);
            }

            [DebuggerNonUserCode]
            public bool IsnazivvrstaelementNull()
            {
                return this.IsNull(this.tableSATIREKAPITULACIJA.nazivvrstaelementColumn);
            }

            [DebuggerNonUserCode]
            public bool IssatiNull()
            {
                return this.IsNull(this.tableSATIREKAPITULACIJA.satiColumn);
            }

            [DebuggerNonUserCode]
            public void SetGODINAISPLATENull()
            {
                this[this.tableSATIREKAPITULACIJA.GODINAISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetGODINAOBRACUNANull()
            {
                this[this.tableSATIREKAPITULACIJA.GODINAOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetidelementNull()
            {
                this[this.tableSATIREKAPITULACIJA.idelementColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetidobracunNull()
            {
                this[this.tableSATIREKAPITULACIJA.idobracunColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetidvrstaelementaNull()
            {
                this[this.tableSATIREKAPITULACIJA.idvrstaelementaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetiznosNull()
            {
                this[this.tableSATIREKAPITULACIJA.iznosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetMJESECISPLATENull()
            {
                this[this.tableSATIREKAPITULACIJA.MJESECISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetMJESECOBRACUNANull()
            {
                this[this.tableSATIREKAPITULACIJA.MJESECOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetnazivelementNull()
            {
                this[this.tableSATIREKAPITULACIJA.nazivelementColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetnazivvrstaelementNull()
            {
                this[this.tableSATIREKAPITULACIJA.nazivvrstaelementColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetsatiNull()
            {
                this[this.tableSATIREKAPITULACIJA.satiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public string GODINAISPLATE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSATIREKAPITULACIJA.GODINAISPLATEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSATIREKAPITULACIJA.GODINAISPLATEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string GODINAOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSATIREKAPITULACIJA.GODINAOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSATIREKAPITULACIJA.GODINAOBRACUNAColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string idelement
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSATIREKAPITULACIJA.idelementColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSATIREKAPITULACIJA.idelementColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string idobracun
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSATIREKAPITULACIJA.idobracunColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSATIREKAPITULACIJA.idobracunColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string idvrstaelementa
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSATIREKAPITULACIJA.idvrstaelementaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSATIREKAPITULACIJA.idvrstaelementaColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal iznos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSATIREKAPITULACIJA.iznosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSATIREKAPITULACIJA.iznosColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string MJESECISPLATE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSATIREKAPITULACIJA.MJESECISPLATEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSATIREKAPITULACIJA.MJESECISPLATEColumn] = value;
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
                        str = Conversions.ToString(this[this.tableSATIREKAPITULACIJA.MJESECOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSATIREKAPITULACIJA.MJESECOBRACUNAColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string nazivelement
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSATIREKAPITULACIJA.nazivelementColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSATIREKAPITULACIJA.nazivelementColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string nazivvrstaelement
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSATIREKAPITULACIJA.nazivvrstaelementColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSATIREKAPITULACIJA.nazivvrstaelementColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal sati
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableSATIREKAPITULACIJA.satiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSATIREKAPITULACIJA.satiColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class SATIREKAPITULACIJARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsTotali.SATIREKAPITULACIJARow eventRow;

            [DebuggerNonUserCode]
            public SATIREKAPITULACIJARowChangeEvent(dsTotali.SATIREKAPITULACIJARow row, DataRowAction action)
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
            public dsTotali.SATIREKAPITULACIJARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SATIREKAPITULACIJARowChangeEventHandler(object sender, dsTotali.SATIREKAPITULACIJARowChangeEvent e);
    }
}

