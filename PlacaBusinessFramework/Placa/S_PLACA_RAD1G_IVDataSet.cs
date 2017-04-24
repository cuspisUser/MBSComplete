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
    public class S_PLACA_RAD1G_IVDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_PLACA_RAD1G_IVDataTable tableS_PLACA_RAD1G_IV;

        public S_PLACA_RAD1G_IVDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_PLACA_RAD1G_IVDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_PLACA_RAD1G_IV"] != null)
                    {
                        this.Tables.Add(new S_PLACA_RAD1G_IVDataTable(dataSet.Tables["S_PLACA_RAD1G_IV"]));
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
            S_PLACA_RAD1G_IVDataSet set = (S_PLACA_RAD1G_IVDataSet) base.Clone();
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
            S_PLACA_RAD1G_IVDataSet set = new S_PLACA_RAD1G_IVDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_PLACA_RAD1G_IVDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2186");
            this.ExtendedProperties.Add("DataSetName", "S_PLACA_RAD1G_IVDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_PLACA_RAD1G_IVDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_PLACA_RAD1G_IV");
            this.ExtendedProperties.Add("ObjectDescription", "S_PLACA_RAD1G_IV");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_RAD1G_IV");
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
            this.DataSetName = "S_PLACA_RAD1G_IVDataSet";
            this.Namespace = "http://www.tempuri.org/S_PLACA_RAD1G_IV";
            this.tableS_PLACA_RAD1G_IV = new S_PLACA_RAD1G_IVDataTable();
            this.Tables.Add(this.tableS_PLACA_RAD1G_IV);
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
            this.tableS_PLACA_RAD1G_IV = (S_PLACA_RAD1G_IVDataTable) this.Tables["S_PLACA_RAD1G_IV"];
            if (initTable && (this.tableS_PLACA_RAD1G_IV != null))
            {
                this.tableS_PLACA_RAD1G_IV.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_PLACA_RAD1G_IV"] != null)
                {
                    this.Tables.Add(new S_PLACA_RAD1G_IVDataTable(dataSet.Tables["S_PLACA_RAD1G_IV"]));
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

        private bool ShouldSerializeS_PLACA_RAD1G_IV()
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
        public S_PLACA_RAD1G_IVDataTable S_PLACA_RAD1G_IV
        {
            get
            {
                return this.tableS_PLACA_RAD1G_IV;
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
        public class S_PLACA_RAD1G_IVDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBRUTOPLACA;
            private DataColumn columnnetoplaca;
            private DataColumn columnSPOL;
            private DataColumn columnSPREMA;

            public event S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRowChangeEventHandler S_PLACA_RAD1G_IVRowChanged;

            public event S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRowChangeEventHandler S_PLACA_RAD1G_IVRowChanging;

            public event S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRowChangeEventHandler S_PLACA_RAD1G_IVRowDeleted;

            public event S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRowChangeEventHandler S_PLACA_RAD1G_IVRowDeleting;

            public S_PLACA_RAD1G_IVDataTable()
            {
                this.TableName = "S_PLACA_RAD1G_IV";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_PLACA_RAD1G_IVDataTable(DataTable table) : base(table.TableName)
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

            protected S_PLACA_RAD1G_IVDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_PLACA_RAD1G_IVRow(S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow row)
            {
                this.Rows.Add(row);
            }

            public S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow AddS_PLACA_RAD1G_IVRow(decimal bRUTOPLACA, decimal netoplaca, string sPREMA, string sPOL)
            {
                S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow row = (S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow) this.NewRow();
                row.ItemArray = new object[] { bRUTOPLACA, netoplaca, sPREMA, sPOL };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVDataTable table = (S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_PLACA_RAD1G_IVDataSet set = new S_PLACA_RAD1G_IVDataSet();
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
                this.columnBRUTOPLACA = new DataColumn("BRUTOPLACA", typeof(decimal), "", MappingType.Element);
                this.columnBRUTOPLACA.Caption = "BRUTOPLACA";
                this.columnBRUTOPLACA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBRUTOPLACA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBRUTOPLACA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBRUTOPLACA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBRUTOPLACA.ExtendedProperties.Add("IsKey", "false");
                this.columnBRUTOPLACA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBRUTOPLACA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBRUTOPLACA.ExtendedProperties.Add("Description", "BRUTOPLACA");
                this.columnBRUTOPLACA.ExtendedProperties.Add("Length", "12");
                this.columnBRUTOPLACA.ExtendedProperties.Add("Decimals", "2");
                this.columnBRUTOPLACA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBRUTOPLACA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBRUTOPLACA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBRUTOPLACA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBRUTOPLACA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBRUTOPLACA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBRUTOPLACA.ExtendedProperties.Add("Deklarit.InternalName", "BRUTOPLACA");
                this.Columns.Add(this.columnBRUTOPLACA);
                this.columnnetoplaca = new DataColumn("netoplaca", typeof(decimal), "", MappingType.Element);
                this.columnnetoplaca.Caption = "netoplaca";
                this.columnnetoplaca.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnetoplaca.ExtendedProperties.Add("IsKey", "false");
                this.columnnetoplaca.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnetoplaca.ExtendedProperties.Add("DeklaritType", "int");
                this.columnnetoplaca.ExtendedProperties.Add("Description", "netoplaca");
                this.columnnetoplaca.ExtendedProperties.Add("Length", "12");
                this.columnnetoplaca.ExtendedProperties.Add("Decimals", "2");
                this.columnnetoplaca.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnnetoplaca.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnnetoplaca.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnetoplaca.ExtendedProperties.Add("IsInReader", "true");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnetoplaca.ExtendedProperties.Add("Deklarit.InternalName", "netoplaca");
                this.Columns.Add(this.columnnetoplaca);
                this.columnSPREMA = new DataColumn("SPREMA", typeof(string), "", MappingType.Element);
                this.columnSPREMA.Caption = "SPREMA";
                this.columnSPREMA.MaxLength = 6;
                this.columnSPREMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSPREMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSPREMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSPREMA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSPREMA.ExtendedProperties.Add("IsKey", "false");
                this.columnSPREMA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSPREMA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSPREMA.ExtendedProperties.Add("Description", "SPREMA");
                this.columnSPREMA.ExtendedProperties.Add("Length", "6");
                this.columnSPREMA.ExtendedProperties.Add("Decimals", "0");
                this.columnSPREMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSPREMA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSPREMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSPREMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSPREMA.ExtendedProperties.Add("Deklarit.InternalName", "SPREMA");
                this.Columns.Add(this.columnSPREMA);
                this.columnSPOL = new DataColumn("SPOL", typeof(string), "", MappingType.Element);
                this.columnSPOL.Caption = "Spol";
                this.columnSPOL.MaxLength = 1;
                this.columnSPOL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSPOL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSPOL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSPOL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSPOL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSPOL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSPOL.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSPOL.ExtendedProperties.Add("IsKey", "false");
                this.columnSPOL.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSPOL.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSPOL.ExtendedProperties.Add("Description", "Spol");
                this.columnSPOL.ExtendedProperties.Add("Length", "1");
                this.columnSPOL.ExtendedProperties.Add("Decimals", "0");
                this.columnSPOL.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSPOL.ExtendedProperties.Add("IsInReader", "true");
                this.columnSPOL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSPOL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSPOL.ExtendedProperties.Add("Deklarit.InternalName", "SPOL");
                this.Columns.Add(this.columnSPOL);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_PLACA_RAD1G_IV");
                this.ExtendedProperties.Add("Description", "S_PLACA_RAD1G_IV");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnBRUTOPLACA = this.Columns["BRUTOPLACA"];
                this.columnnetoplaca = this.Columns["netoplaca"];
                this.columnSPREMA = this.Columns["SPREMA"];
                this.columnSPOL = this.Columns["SPOL"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow(builder);
            }

            public S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow NewS_PLACA_RAD1G_IVRow()
            {
                return (S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_PLACA_RAD1G_IVRowChanged != null)
                {
                    S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRowChangeEventHandler handler = this.S_PLACA_RAD1G_IVRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRowChangeEvent((S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_PLACA_RAD1G_IVRowChanging != null)
                {
                    S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRowChangeEventHandler handler = this.S_PLACA_RAD1G_IVRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRowChangeEvent((S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_PLACA_RAD1G_IVRowDeleted != null)
                {
                    S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRowChangeEventHandler handler = this.S_PLACA_RAD1G_IVRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRowChangeEvent((S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_PLACA_RAD1G_IVRowDeleting != null)
                {
                    S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRowChangeEventHandler handler = this.S_PLACA_RAD1G_IVRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRowChangeEvent((S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_PLACA_RAD1G_IVRow(S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BRUTOPLACAColumn
            {
                get
                {
                    return this.columnBRUTOPLACA;
                }
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow this[int index]
            {
                get
                {
                    return (S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow) this.Rows[index];
                }
            }

            public DataColumn netoplacaColumn
            {
                get
                {
                    return this.columnnetoplaca;
                }
            }

            public DataColumn SPOLColumn
            {
                get
                {
                    return this.columnSPOL;
                }
            }

            public DataColumn SPREMAColumn
            {
                get
                {
                    return this.columnSPREMA;
                }
            }
        }

        public class S_PLACA_RAD1G_IVRow : DataRow
        {
            private S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVDataTable tableS_PLACA_RAD1G_IV;

            internal S_PLACA_RAD1G_IVRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_PLACA_RAD1G_IV = (S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVDataTable) this.Table;
            }

            public bool IsBRUTOPLACANull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G_IV.BRUTOPLACAColumn);
            }

            public bool IsnetoplacaNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G_IV.netoplacaColumn);
            }

            public bool IsSPOLNull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G_IV.SPOLColumn);
            }

            public bool IsSPREMANull()
            {
                return this.IsNull(this.tableS_PLACA_RAD1G_IV.SPREMAColumn);
            }

            public void SetBRUTOPLACANull()
            {
                this[this.tableS_PLACA_RAD1G_IV.BRUTOPLACAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoplacaNull()
            {
                this[this.tableS_PLACA_RAD1G_IV.netoplacaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSPOLNull()
            {
                this[this.tableS_PLACA_RAD1G_IV.SPOLColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSPREMANull()
            {
                this[this.tableS_PLACA_RAD1G_IV.SPREMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal BRUTOPLACA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1G_IV.BRUTOPLACAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BRUTOPLACA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G_IV.BRUTOPLACAColumn] = value;
                }
            }

            public decimal netoplaca
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_RAD1G_IV.netoplacaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value netoplaca because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G_IV.netoplacaColumn] = value;
                }
            }

            public string SPOL
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_RAD1G_IV.SPOLColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SPOL because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G_IV.SPOLColumn] = value;
                }
            }

            public string SPREMA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_RAD1G_IV.SPREMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SPREMA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_RAD1G_IV.SPREMAColumn] = value;
                }
            }
        }

        public class S_PLACA_RAD1G_IVRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow eventRow;

            public S_PLACA_RAD1G_IVRowChangeEvent(S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow row, DataRowAction action)
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

            public S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_PLACA_RAD1G_IVRowChangeEventHandler(object sender, S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRowChangeEvent e);
    }
}

