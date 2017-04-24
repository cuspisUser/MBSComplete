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
    public class GODINA_I_MJESEC_OBRACUNADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private GODINA_I_MJESEC_OBRACUNADataTable tableGODINA_I_MJESEC_OBRACUNA;

        public GODINA_I_MJESEC_OBRACUNADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected GODINA_I_MJESEC_OBRACUNADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["GODINA_I_MJESEC_OBRACUNA"] != null)
                    {
                        this.Tables.Add(new GODINA_I_MJESEC_OBRACUNADataTable(dataSet.Tables["GODINA_I_MJESEC_OBRACUNA"]));
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
            GODINA_I_MJESEC_OBRACUNADataSet set = (GODINA_I_MJESEC_OBRACUNADataSet) base.Clone();
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
            GODINA_I_MJESEC_OBRACUNADataSet set = new GODINA_I_MJESEC_OBRACUNADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "GODINA_I_MJESEC_OBRACUNADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2072");
            this.ExtendedProperties.Add("DataSetName", "GODINA_I_MJESEC_OBRACUNADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IGODINA_I_MJESEC_OBRACUNADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "GODINA_I_MJESEC_OBRACUNA");
            this.ExtendedProperties.Add("ObjectDescription", "GODINA_I_MJESEC_OBRACUNA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_GOD_MJE_OBR");
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
            this.DataSetName = "GODINA_I_MJESEC_OBRACUNADataSet";
            this.Namespace = "http://www.tempuri.org/GODINA_I_MJESEC_OBRACUNA";
            this.tableGODINA_I_MJESEC_OBRACUNA = new GODINA_I_MJESEC_OBRACUNADataTable();
            this.Tables.Add(this.tableGODINA_I_MJESEC_OBRACUNA);
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
            this.tableGODINA_I_MJESEC_OBRACUNA = (GODINA_I_MJESEC_OBRACUNADataTable) this.Tables["GODINA_I_MJESEC_OBRACUNA"];
            if (initTable && (this.tableGODINA_I_MJESEC_OBRACUNA != null))
            {
                this.tableGODINA_I_MJESEC_OBRACUNA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["GODINA_I_MJESEC_OBRACUNA"] != null)
                {
                    this.Tables.Add(new GODINA_I_MJESEC_OBRACUNADataTable(dataSet.Tables["GODINA_I_MJESEC_OBRACUNA"]));
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

        private bool ShouldSerializeGODINA_I_MJESEC_OBRACUNA()
        {
            return false;
        }

        protected override bool ShouldSerializeRelations()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GODINA_I_MJESEC_OBRACUNADataTable GODINA_I_MJESEC_OBRACUNA
        {
            get
            {
                return this.tableGODINA_I_MJESEC_OBRACUNA;
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
        public class GODINA_I_MJESEC_OBRACUNADataTable : DataTable, IEnumerable
        {
            private DataColumn columnGODINAIMJESECOBRACUNA;

            public event GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARowChangeEventHandler GODINA_I_MJESEC_OBRACUNARowChanged;

            public event GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARowChangeEventHandler GODINA_I_MJESEC_OBRACUNARowChanging;

            public event GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARowChangeEventHandler GODINA_I_MJESEC_OBRACUNARowDeleted;

            public event GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARowChangeEventHandler GODINA_I_MJESEC_OBRACUNARowDeleting;

            public GODINA_I_MJESEC_OBRACUNADataTable()
            {
                this.TableName = "GODINA_I_MJESEC_OBRACUNA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal GODINA_I_MJESEC_OBRACUNADataTable(DataTable table) : base(table.TableName)
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

            protected GODINA_I_MJESEC_OBRACUNADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddGODINA_I_MJESEC_OBRACUNARow(GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow row)
            {
                this.Rows.Add(row);
            }

            public GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow AddGODINA_I_MJESEC_OBRACUNARow(string gODINAIMJESECOBRACUNA)
            {
                GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow row = (GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow) this.NewRow();
                row.ItemArray = new object[] { gODINAIMJESECOBRACUNA };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNADataTable table = (GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                GODINA_I_MJESEC_OBRACUNADataSet set = new GODINA_I_MJESEC_OBRACUNADataSet();
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
                this.columnGODINAIMJESECOBRACUNA = new DataColumn("GODINAIMJESECOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnGODINAIMJESECOBRACUNA.Caption = "GODINAIMJESECOBRACUNA";
                this.columnGODINAIMJESECOBRACUNA.MaxLength = 7;
                this.columnGODINAIMJESECOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("Description", "GODINAIMJESECOBRACUNA");
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("Length", "7");
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINAIMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "GODINAIMJESECOBRACUNA");
                this.Columns.Add(this.columnGODINAIMJESECOBRACUNA);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "GODINA_I_MJESEC_OBRACUNA");
                this.ExtendedProperties.Add("Description", "GODINA_I_MJESEC_OBRACUNA");
                this.ExtendedProperties.Add("HasOrder", "true");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnGODINAIMJESECOBRACUNA = this.Columns["GODINAIMJESECOBRACUNA"];
            }

            public GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow NewGODINA_I_MJESEC_OBRACUNARow()
            {
                return (GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.GODINA_I_MJESEC_OBRACUNARowChanged != null)
                {
                    GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARowChangeEventHandler handler = this.GODINA_I_MJESEC_OBRACUNARowChanged;
                    if (handler != null)
                    {
                        handler(this, new GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARowChangeEvent((GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.GODINA_I_MJESEC_OBRACUNARowChanging != null)
                {
                    GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARowChangeEventHandler handler = this.GODINA_I_MJESEC_OBRACUNARowChanging;
                    if (handler != null)
                    {
                        handler(this, new GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARowChangeEvent((GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.GODINA_I_MJESEC_OBRACUNARowDeleted != null)
                {
                    GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARowChangeEventHandler handler = this.GODINA_I_MJESEC_OBRACUNARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARowChangeEvent((GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.GODINA_I_MJESEC_OBRACUNARowDeleting != null)
                {
                    GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARowChangeEventHandler handler = this.GODINA_I_MJESEC_OBRACUNARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARowChangeEvent((GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveGODINA_I_MJESEC_OBRACUNARow(GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow row)
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

            public DataColumn GODINAIMJESECOBRACUNAColumn
            {
                get
                {
                    return this.columnGODINAIMJESECOBRACUNA;
                }
            }

            public GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow this[int index]
            {
                get
                {
                    return (GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow) this.Rows[index];
                }
            }
        }

        public class GODINA_I_MJESEC_OBRACUNARow : DataRow
        {
            private GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNADataTable tableGODINA_I_MJESEC_OBRACUNA;

            internal GODINA_I_MJESEC_OBRACUNARow(DataRowBuilder rb) : base(rb)
            {
                this.tableGODINA_I_MJESEC_OBRACUNA = (GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNADataTable) this.Table;
            }

            public bool IsGODINAIMJESECOBRACUNANull()
            {
                return this.IsNull(this.tableGODINA_I_MJESEC_OBRACUNA.GODINAIMJESECOBRACUNAColumn);
            }

            public void SetGODINAIMJESECOBRACUNANull()
            {
                this[this.tableGODINA_I_MJESEC_OBRACUNA.GODINAIMJESECOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string GODINAIMJESECOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGODINA_I_MJESEC_OBRACUNA.GODINAIMJESECOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value GODINAIMJESECOBRACUNA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableGODINA_I_MJESEC_OBRACUNA.GODINAIMJESECOBRACUNAColumn] = value;
                }
            }
        }

        public class GODINA_I_MJESEC_OBRACUNARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow eventRow;

            public GODINA_I_MJESEC_OBRACUNARowChangeEvent(GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow row, DataRowAction action)
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

            public GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void GODINA_I_MJESEC_OBRACUNARowChangeEventHandler(object sender, GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARowChangeEvent e);
    }
}

