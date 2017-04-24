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

    [Serializable, ToolboxItem(true), XmlRoot("dsDokumenti"), XmlSchemaProvider("GetTypedDataSetSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), HelpKeyword("vs.data.DataSet"), DesignerCategory("code")]
    public class dsDokumenti : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private TableDataTable tableTable;

        [DebuggerNonUserCode]
        public dsDokumenti()
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
        protected dsDokumenti(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["Table"] != null)
                    {
                        base.Tables.Add(new TableDataTable(dataSet.Tables["Table"]));
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
            dsDokumenti dokumenti = (dsDokumenti) base.Clone();
            dokumenti.InitVars();
            dokumenti.SchemaSerializationMode = this.SchemaSerializationMode;
            return dokumenti;
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
            dsDokumenti dokumenti = new dsDokumenti();
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = dokumenti.Namespace
            };
            sequence.Items.Add(item);
            type2.Particle = sequence;
            XmlSchema schemaSerializable = dokumenti.GetSchemaSerializable();
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
            this.DataSetName = "dsDokumenti";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/dsDokumenti.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableTable = new TableDataTable();
            base.Tables.Add(this.tableTable);
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
            this.tableTable = (TableDataTable) base.Tables["Table"];
            if (initTable && (this.tableTable != null))
            {
                this.tableTable.InitVars();
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
                if (dataSet.Tables["Table"] != null)
                {
                    base.Tables.Add(new TableDataTable(dataSet.Tables["Table"]));
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
        private bool ShouldSerializeTable()
        {
            return false;
        }

        [DebuggerNonUserCode]
        protected override bool ShouldSerializeTables()
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode]
        public TableDataTable Table
        {
            get
            {
                return this.tableTable;
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
        public class TableDataTable : TypedTableBase<dsDokumenti.TableRow>
        {
            private DataColumn columnBROJDOKUMENTA;
            private DataColumn columnBROJSTAVAKA;
            private DataColumn columnDATUMDOKUMENTA;
            private DataColumn columnDUGUJE;
            private DataColumn columnIDDOKUMENT;
            private DataColumn columnPOTRAZUJE;
            private DataColumn columnSKRACENIDOKUMENT;
            private DataColumn columnstatusgk;

            public event dsDokumenti.TableRowChangeEventHandler TableRowChanged;

            public event dsDokumenti.TableRowChangeEventHandler TableRowChanging;

            public event dsDokumenti.TableRowChangeEventHandler TableRowDeleted;

            public event dsDokumenti.TableRowChangeEventHandler TableRowDeleting;

            [DebuggerNonUserCode]
            public TableDataTable()
            {
                this.TableName = "Table";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal TableDataTable(DataTable table)
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
            protected TableDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddTableRow(dsDokumenti.TableRow row)
            {
                this.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public dsDokumenti.TableRow AddTableRow(int BROJDOKUMENTA, decimal DUGUJE, decimal POTRAZUJE, string SKRACENIDOKUMENT, int BROJSTAVAKA, int IDDOKUMENT, bool statusgk, DateTime DATUMDOKUMENTA)
            {
                dsDokumenti.TableRow row = (dsDokumenti.TableRow) this.NewRow();
                row.ItemArray = new object[] { BROJDOKUMENTA, DUGUJE, POTRAZUJE, SKRACENIDOKUMENT, BROJSTAVAKA, IDDOKUMENT, statusgk, DATUMDOKUMENTA };
                this.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsDokumenti.TableDataTable table = (dsDokumenti.TableDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsDokumenti.TableDataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsDokumenti.TableRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsDokumenti dokumenti = new dsDokumenti();
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
                    FixedValue = dokumenti.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "TableDataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                XmlSchema schemaSerializable = dokumenti.GetSchemaSerializable();
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
                this.columnBROJDOKUMENTA = new DataColumn("BROJDOKUMENTA", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnBROJDOKUMENTA);
                this.columnDUGUJE = new DataColumn("DUGUJE", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnDUGUJE);
                this.columnPOTRAZUJE = new DataColumn("POTRAZUJE", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnPOTRAZUJE);
                this.columnSKRACENIDOKUMENT = new DataColumn("SKRACENIDOKUMENT", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKRACENIDOKUMENT);
                this.columnBROJSTAVAKA = new DataColumn("BROJSTAVAKA", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnBROJSTAVAKA);
                this.columnIDDOKUMENT = new DataColumn("IDDOKUMENT", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnIDDOKUMENT);
                this.columnstatusgk = new DataColumn("STATUSGK", typeof(bool), null, MappingType.Element);
                this.columnstatusgk.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "statusgk");
                this.columnstatusgk.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "statusgkColumn");
                this.columnstatusgk.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnstatusgk");
                this.columnstatusgk.ExtendedProperties.Add("Generator_UserColumnName", "STATUSGK");
                base.Columns.Add(this.columnstatusgk);
                this.columnDATUMDOKUMENTA = new DataColumn("DATUMDOKUMENTA", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnDATUMDOKUMENTA);
                this.columnBROJDOKUMENTA.AllowDBNull = false;
                this.columnDUGUJE.ReadOnly = true;
                this.columnPOTRAZUJE.ReadOnly = true;
                this.columnSKRACENIDOKUMENT.AllowDBNull = false;
                this.columnSKRACENIDOKUMENT.MaxLength = 50;
                this.columnBROJSTAVAKA.ReadOnly = true;
                this.columnIDDOKUMENT.AllowDBNull = false;
                this.columnstatusgk.AllowDBNull = false;
                this.columnDATUMDOKUMENTA.AllowDBNull = false;
                this.ExtendedProperties.Add("Generator_RowClassName", "TableRow");
                this.ExtendedProperties.Add("Generator_RowEvArgName", "TableRowChangeEvent");
                this.ExtendedProperties.Add("Generator_RowEvHandlerName", "TableRowChangeEventHandler");
                this.ExtendedProperties.Add("Generator_TableClassName", "TableDataTable");
                this.ExtendedProperties.Add("Generator_TablePropName", "Table");
                this.ExtendedProperties.Add("Generator_TableVarName", "tableTable");
                this.ExtendedProperties.Add("Generator_UserTableName", "Table");
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnBROJDOKUMENTA = base.Columns["BROJDOKUMENTA"];
                this.columnDUGUJE = base.Columns["DUGUJE"];
                this.columnPOTRAZUJE = base.Columns["POTRAZUJE"];
                this.columnSKRACENIDOKUMENT = base.Columns["SKRACENIDOKUMENT"];
                this.columnBROJSTAVAKA = base.Columns["BROJSTAVAKA"];
                this.columnIDDOKUMENT = base.Columns["IDDOKUMENT"];
                this.columnstatusgk = base.Columns["STATUSGK"];
                this.columnDATUMDOKUMENTA = base.Columns["DATUMDOKUMENTA"];
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsDokumenti.TableRow(builder);
            }

            [DebuggerNonUserCode]
            public dsDokumenti.TableRow NewTableRow()
            {
                return (dsDokumenti.TableRow) this.NewRow();
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.TableRowChanged != null)
                {
                    dsDokumenti.TableRowChangeEventHandler tableRowChangedEvent = this.TableRowChanged;
                    if (tableRowChangedEvent != null)
                    {
                        tableRowChangedEvent(this, new dsDokumenti.TableRowChangeEvent((dsDokumenti.TableRow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.TableRowChanging != null)
                {
                    dsDokumenti.TableRowChangeEventHandler tableRowChangingEvent = this.TableRowChanging;
                    if (tableRowChangingEvent != null)
                    {
                        tableRowChangingEvent(this, new dsDokumenti.TableRowChangeEvent((dsDokumenti.TableRow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.TableRowDeleted != null)
                {
                    dsDokumenti.TableRowChangeEventHandler tableRowDeletedEvent = this.TableRowDeleted;
                    if (tableRowDeletedEvent != null)
                    {
                        tableRowDeletedEvent(this, new dsDokumenti.TableRowChangeEvent((dsDokumenti.TableRow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.TableRowDeleting != null)
                {
                    dsDokumenti.TableRowChangeEventHandler tableRowDeletingEvent = this.TableRowDeleting;
                    if (tableRowDeletingEvent != null)
                    {
                        tableRowDeletingEvent(this, new dsDokumenti.TableRowChangeEvent((dsDokumenti.TableRow) e.Row, e.Action));
                    }
                }
            }

            [DebuggerNonUserCode]
            public void RemoveTableRow(dsDokumenti.TableRow row)
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
            public DataColumn BROJSTAVAKAColumn
            {
                get
                {
                    return this.columnBROJSTAVAKA;
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
            public DataColumn DUGUJEColumn
            {
                get
                {
                    return this.columnDUGUJE;
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
            public dsDokumenti.TableRow this[int index]
            {
                get
                {
                    return (dsDokumenti.TableRow) this.Rows[index];
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
            public DataColumn statusgkColumn
            {
                get
                {
                    return this.columnstatusgk;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class TableRow : DataRow
        {
            private dsDokumenti.TableDataTable tableTable;

            [DebuggerNonUserCode]
            internal TableRow(DataRowBuilder rb) : base(rb)
            {
                this.tableTable = (dsDokumenti.TableDataTable) this.Table;
            }

            [DebuggerNonUserCode]
            public bool IsBROJSTAVAKANull()
            {
                return this.IsNull(this.tableTable.BROJSTAVAKAColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDUGUJENull()
            {
                return this.IsNull(this.tableTable.DUGUJEColumn);
            }

            [DebuggerNonUserCode]
            public bool IsPOTRAZUJENull()
            {
                return this.IsNull(this.tableTable.POTRAZUJEColumn);
            }

            [DebuggerNonUserCode]
            public void SetBROJSTAVAKANull()
            {
                this[this.tableTable.BROJSTAVAKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetDUGUJENull()
            {
                this[this.tableTable.DUGUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public void SetPOTRAZUJENull()
            {
                this[this.tableTable.POTRAZUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            [DebuggerNonUserCode]
            public int BROJDOKUMENTA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableTable.BROJDOKUMENTAColumn]);
                }
                set
                {
                    this[this.tableTable.BROJDOKUMENTAColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public int BROJSTAVAKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableTable.BROJSTAVAKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'BROJSTAVAKA' in table 'Table' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableTable.BROJSTAVAKAColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public DateTime DATUMDOKUMENTA
            {
                get
                {
                    return Conversions.ToDate(this[this.tableTable.DATUMDOKUMENTAColumn]);
                }
                set
                {
                    this[this.tableTable.DATUMDOKUMENTAColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal DUGUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableTable.DUGUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'DUGUJE' in table 'Table' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableTable.DUGUJEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public int IDDOKUMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableTable.IDDOKUMENTColumn]);
                }
                set
                {
                    this[this.tableTable.IDDOKUMENTColumn] = value;
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
                        num = Conversions.ToDecimal(this[this.tableTable.POTRAZUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("The value for column 'POTRAZUJE' in table 'Table' is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableTable.POTRAZUJEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string SKRACENIDOKUMENT
            {
                get
                {
                    return Conversions.ToString(this[this.tableTable.SKRACENIDOKUMENTColumn]);
                }
                set
                {
                    this[this.tableTable.SKRACENIDOKUMENTColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public bool statusgk
            {
                get
                {
                    return Conversions.ToBoolean(this[this.tableTable.statusgkColumn]);
                }
                set
                {
                    this[this.tableTable.statusgkColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class TableRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsDokumenti.TableRow eventRow;

            [DebuggerNonUserCode]
            public TableRowChangeEvent(dsDokumenti.TableRow row, DataRowAction action)
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
            public dsDokumenti.TableRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void TableRowChangeEventHandler(object sender, dsDokumenti.TableRowChangeEvent e);
    }
}

