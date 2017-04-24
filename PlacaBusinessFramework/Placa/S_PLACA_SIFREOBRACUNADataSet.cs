namespace Placa
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;

    [Serializable]
    public class S_PLACA_SIFREOBRACUNADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_PLACA_SIFREOBRACUNADataTable tableS_PLACA_SIFREOBRACUNA;

        public S_PLACA_SIFREOBRACUNADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_PLACA_SIFREOBRACUNADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_PLACA_SIFREOBRACUNA"] != null)
                    {
                        this.Tables.Add(new S_PLACA_SIFREOBRACUNADataTable(dataSet.Tables["S_PLACA_SIFREOBRACUNA"]));
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
            S_PLACA_SIFREOBRACUNADataSet set = (S_PLACA_SIFREOBRACUNADataSet) base.Clone();
            set.InitVars();
            return set;
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
            S_PLACA_SIFREOBRACUNADataSet set = new S_PLACA_SIFREOBRACUNADataSet();
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            xs.Add(set.GetSchemaSerializable());
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = set.Namespace
            };
            sequence.Items.Add(item);
            type2.Particle = sequence;
            return type2;
        }

        private void InitClass()
        {
            this.InitClassBase();
            this.ExtendedProperties.Add("DataAdapterName", "S_PLACA_SIFREOBRACUNADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2196");
            this.ExtendedProperties.Add("DataSetName", "S_PLACA_SIFREOBRACUNADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_PLACA_SIFREOBRACUNADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_PLACA_SIFREOBRACUNA");
            this.ExtendedProperties.Add("ObjectDescription", "S_PLACA_SIFREOBRACUNA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_SIFREOBRACUNA");
            this.ExtendedProperties.Add("Deklarit.GroupByAttributes", "");
            this.ExtendedProperties.Add("Deklarit.GenerateCRUDForDP", "false");
            this.ExtendedProperties.Add("Deklarit.ExtendedView", "false");
            this.ExtendedProperties.Add("Deklarit.ShowGroupByDP", "True");
            this.ExtendedProperties.Add("Deklarit.UseSuggestInFK", "False");
            this.ExtendedProperties.Add("Deklarit.BCForNewOption", "");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "S_PLACA_SIFREOBRACUNADataSet";
            this.Namespace = "http://www.tempuri.org/S_PLACA_SIFREOBRACUNA";
            this.tableS_PLACA_SIFREOBRACUNA = new S_PLACA_SIFREOBRACUNADataTable();
            this.Tables.Add(this.tableS_PLACA_SIFREOBRACUNA);
        }

        protected override void InitializeDerivedDataSet()
        {
            this.BeginInit();
            this.InitClassBase();
            this.EndInit();
        }

        internal void InitVars()
        {
            this.InitVars(true);
        }

        internal void InitVars(bool initTable)
        {
            this.tableS_PLACA_SIFREOBRACUNA = (S_PLACA_SIFREOBRACUNADataTable) this.Tables["S_PLACA_SIFREOBRACUNA"];
            if (initTable && (this.tableS_PLACA_SIFREOBRACUNA != null))
            {
                this.tableS_PLACA_SIFREOBRACUNA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_PLACA_SIFREOBRACUNA"] != null)
                {
                    this.Tables.Add(new S_PLACA_SIFREOBRACUNADataTable(dataSet.Tables["S_PLACA_SIFREOBRACUNA"]));
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
                this.ExtendedProperties.Clear();
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

        private bool ShouldSerializeS_PLACA_SIFREOBRACUNA()
        {
            return false;
        }

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DefaultValue(true)]
        public new bool EnforceConstraints
        {
            get
            {
                return base.EnforceConstraints;
            }
            set
            {
                base.EnforceConstraints = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public S_PLACA_SIFREOBRACUNADataTable S_PLACA_SIFREOBRACUNA
        {
            get
            {
                return this.tableS_PLACA_SIFREOBRACUNA;
            }
        }

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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Serializable]
        public class S_PLACA_SIFREOBRACUNADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOBRACUN;

            public event S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARowChangeEventHandler S_PLACA_SIFREOBRACUNARowChanged;

            public event S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARowChangeEventHandler S_PLACA_SIFREOBRACUNARowChanging;

            public event S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARowChangeEventHandler S_PLACA_SIFREOBRACUNARowDeleted;

            public event S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARowChangeEventHandler S_PLACA_SIFREOBRACUNARowDeleting;

            public S_PLACA_SIFREOBRACUNADataTable()
            {
                this.TableName = "S_PLACA_SIFREOBRACUNA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_PLACA_SIFREOBRACUNADataTable(DataTable table) : base(table.TableName)
            {
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
                this.DisplayExpression = table.DisplayExpression;
            }

            protected S_PLACA_SIFREOBRACUNADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_PLACA_SIFREOBRACUNARow(S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow row)
            {
                this.Rows.Add(row);
            }

            public S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow AddS_PLACA_SIFREOBRACUNARow(string iDOBRACUN)
            {
                S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow row = (S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow) this.NewRow();
                row.ItemArray = new object[] { iDOBRACUN };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNADataTable table = (S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_PLACA_SIFREOBRACUNADataSet set = new S_PLACA_SIFREOBRACUNADataSet();
                xs.Add(set.GetSchemaSerializable());
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
                    FixedValue = set.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "InvoiceDataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                return type2;
            }

            public void InitClass()
            {
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOBRACUN.ExtendedProperties.Add("Description", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUN");
                this.Columns.Add(this.columnIDOBRACUN);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_PLACA_SIFREOBRACUNA");
                this.ExtendedProperties.Add("Description", "_S_PLACA_SIFREOBRACUNA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow(builder);
            }

            public S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow NewS_PLACA_SIFREOBRACUNARow()
            {
                return (S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_PLACA_SIFREOBRACUNARowChanged != null)
                {
                    S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARowChangeEventHandler handler = this.S_PLACA_SIFREOBRACUNARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARowChangeEvent((S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_PLACA_SIFREOBRACUNARowChanging != null)
                {
                    S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARowChangeEventHandler handler = this.S_PLACA_SIFREOBRACUNARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARowChangeEvent((S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_PLACA_SIFREOBRACUNARowDeleted != null)
                {
                    S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARowChangeEventHandler handler = this.S_PLACA_SIFREOBRACUNARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARowChangeEvent((S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_PLACA_SIFREOBRACUNARowDeleting != null)
                {
                    S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARowChangeEventHandler handler = this.S_PLACA_SIFREOBRACUNARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARowChangeEvent((S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_PLACA_SIFREOBRACUNARow(S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow row)
            {
                this.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow this[int index]
            {
                get
                {
                    return (S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow) this.Rows[index];
                }
            }
        }

        public class S_PLACA_SIFREOBRACUNARow : DataRow
        {
            private S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNADataTable tableS_PLACA_SIFREOBRACUNA;

            internal S_PLACA_SIFREOBRACUNARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_PLACA_SIFREOBRACUNA = (S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNADataTable) this.Table;
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tableS_PLACA_SIFREOBRACUNA.IDOBRACUNColumn);
            }

            public void SetIDOBRACUNNull()
            {
                this[this.tableS_PLACA_SIFREOBRACUNA.IDOBRACUNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string IDOBRACUN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_SIFREOBRACUNA.IDOBRACUNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDOBRACUN because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_SIFREOBRACUNA.IDOBRACUNColumn] = value;
                }
            }
        }

        public class S_PLACA_SIFREOBRACUNARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow eventRow;

            public S_PLACA_SIFREOBRACUNARowChangeEvent(S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow row, DataRowAction action)
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

            public S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_PLACA_SIFREOBRACUNARowChangeEventHandler(object sender, S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARowChangeEvent e);
    }
}

