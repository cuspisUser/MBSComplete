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
    public class S_DD_IPPDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_DD_IPPDataTable tableS_DD_IPP;

        public S_DD_IPPDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_DD_IPPDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_DD_IPP"] != null)
                    {
                        this.Tables.Add(new S_DD_IPPDataTable(dataSet.Tables["S_DD_IPP"]));
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
            S_DD_IPPDataSet set = (S_DD_IPPDataSet) base.Clone();
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
            S_DD_IPPDataSet set = new S_DD_IPPDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_DD_IPPDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2107");
            this.ExtendedProperties.Add("DataSetName", "S_DD_IPPDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_DD_IPPDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_DD_IPP");
            this.ExtendedProperties.Add("ObjectDescription", "S_DD_IPP");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_DD");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_DD_IPP");
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
            this.DataSetName = "S_DD_IPPDataSet";
            this.Namespace = "http://www.tempuri.org/S_DD_IPP";
            this.tableS_DD_IPP = new S_DD_IPPDataTable();
            this.Tables.Add(this.tableS_DD_IPP);
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
            this.tableS_DD_IPP = (S_DD_IPPDataTable) this.Tables["S_DD_IPP"];
            if (initTable && (this.tableS_DD_IPP != null))
            {
                this.tableS_DD_IPP.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_DD_IPP"] != null)
                {
                    this.Tables.Add(new S_DD_IPPDataTable(dataSet.Tables["S_DD_IPP"]));
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

        private bool ShouldSerializeS_DD_IPP()
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
        public S_DD_IPPDataTable S_DD_IPP
        {
            get
            {
                return this.tableS_DD_IPP;
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
        public class S_DD_IPPDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJRADNIKA;
            private DataColumn columnKRIZNIPOREZ;
            private DataColumn columnOSNOVICAKRIZNOGPOREZA;

            public event S_DD_IPPDataSet.S_DD_IPPRowChangeEventHandler S_DD_IPPRowChanged;

            public event S_DD_IPPDataSet.S_DD_IPPRowChangeEventHandler S_DD_IPPRowChanging;

            public event S_DD_IPPDataSet.S_DD_IPPRowChangeEventHandler S_DD_IPPRowDeleted;

            public event S_DD_IPPDataSet.S_DD_IPPRowChangeEventHandler S_DD_IPPRowDeleting;

            public S_DD_IPPDataTable()
            {
                this.TableName = "S_DD_IPP";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_DD_IPPDataTable(DataTable table) : base(table.TableName)
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

            protected S_DD_IPPDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_DD_IPPRow(S_DD_IPPDataSet.S_DD_IPPRow row)
            {
                this.Rows.Add(row);
            }

            public S_DD_IPPDataSet.S_DD_IPPRow AddS_DD_IPPRow(decimal oSNOVICAKRIZNOGPOREZA, decimal kRIZNIPOREZ, decimal bROJRADNIKA)
            {
                S_DD_IPPDataSet.S_DD_IPPRow row = (S_DD_IPPDataSet.S_DD_IPPRow) this.NewRow();
                row.ItemArray = new object[] { oSNOVICAKRIZNOGPOREZA, kRIZNIPOREZ, bROJRADNIKA };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_DD_IPPDataSet.S_DD_IPPDataTable table = (S_DD_IPPDataSet.S_DD_IPPDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_DD_IPPDataSet.S_DD_IPPRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_DD_IPPDataSet set = new S_DD_IPPDataSet();
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
                this.columnOSNOVICAKRIZNOGPOREZA = new DataColumn("OSNOVICAKRIZNOGPOREZA", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICAKRIZNOGPOREZA.Caption = "Porezna osnovica";
                this.columnOSNOVICAKRIZNOGPOREZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("Description", "Porezna osnovica");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAKRIZNOGPOREZA.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAKRIZNOGPOREZA");
                this.Columns.Add(this.columnOSNOVICAKRIZNOGPOREZA);
                this.columnKRIZNIPOREZ = new DataColumn("KRIZNIPOREZ", typeof(decimal), "", MappingType.Element);
                this.columnKRIZNIPOREZ.Caption = "Iznos posebnoh poreza";
                this.columnKRIZNIPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Description", "Iznos posebnoh poreza");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Length", "12");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "KRIZNIPOREZ");
                this.Columns.Add(this.columnKRIZNIPOREZ);
                this.columnBROJRADNIKA = new DataColumn("BROJRADNIKA", typeof(decimal), "", MappingType.Element);
                this.columnBROJRADNIKA.Caption = "Broj stjecatelja";
                this.columnBROJRADNIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJRADNIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJRADNIKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJRADNIKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Description", "Broj stjecatelja");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Length", "12");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Decimals", "2");
                this.columnBROJRADNIKA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBROJRADNIKA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBROJRADNIKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJRADNIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJRADNIKA.ExtendedProperties.Add("Deklarit.InternalName", "BROJRADNIKA");
                this.Columns.Add(this.columnBROJRADNIKA);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_DD_IPP");
                this.ExtendedProperties.Add("Description", "S_DD_IPP");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnOSNOVICAKRIZNOGPOREZA = this.Columns["OSNOVICAKRIZNOGPOREZA"];
                this.columnKRIZNIPOREZ = this.Columns["KRIZNIPOREZ"];
                this.columnBROJRADNIKA = this.Columns["BROJRADNIKA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_DD_IPPDataSet.S_DD_IPPRow(builder);
            }

            public S_DD_IPPDataSet.S_DD_IPPRow NewS_DD_IPPRow()
            {
                return (S_DD_IPPDataSet.S_DD_IPPRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_DD_IPPRowChanged != null)
                {
                    S_DD_IPPDataSet.S_DD_IPPRowChangeEventHandler handler = this.S_DD_IPPRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_DD_IPPDataSet.S_DD_IPPRowChangeEvent((S_DD_IPPDataSet.S_DD_IPPRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_DD_IPPRowChanging != null)
                {
                    S_DD_IPPDataSet.S_DD_IPPRowChangeEventHandler handler = this.S_DD_IPPRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_DD_IPPDataSet.S_DD_IPPRowChangeEvent((S_DD_IPPDataSet.S_DD_IPPRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_DD_IPPRowDeleted != null)
                {
                    S_DD_IPPDataSet.S_DD_IPPRowChangeEventHandler handler = this.S_DD_IPPRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_DD_IPPDataSet.S_DD_IPPRowChangeEvent((S_DD_IPPDataSet.S_DD_IPPRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_DD_IPPRowDeleting != null)
                {
                    S_DD_IPPDataSet.S_DD_IPPRowChangeEventHandler handler = this.S_DD_IPPRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_DD_IPPDataSet.S_DD_IPPRowChangeEvent((S_DD_IPPDataSet.S_DD_IPPRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_DD_IPPRow(S_DD_IPPDataSet.S_DD_IPPRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJRADNIKAColumn
            {
                get
                {
                    return this.columnBROJRADNIKA;
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

            public S_DD_IPPDataSet.S_DD_IPPRow this[int index]
            {
                get
                {
                    return (S_DD_IPPDataSet.S_DD_IPPRow) this.Rows[index];
                }
            }

            public DataColumn KRIZNIPOREZColumn
            {
                get
                {
                    return this.columnKRIZNIPOREZ;
                }
            }

            public DataColumn OSNOVICAKRIZNOGPOREZAColumn
            {
                get
                {
                    return this.columnOSNOVICAKRIZNOGPOREZA;
                }
            }
        }

        public class S_DD_IPPRow : DataRow
        {
            private S_DD_IPPDataSet.S_DD_IPPDataTable tableS_DD_IPP;

            internal S_DD_IPPRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_DD_IPP = (S_DD_IPPDataSet.S_DD_IPPDataTable) this.Table;
            }

            public bool IsBROJRADNIKANull()
            {
                return this.IsNull(this.tableS_DD_IPP.BROJRADNIKAColumn);
            }

            public bool IsKRIZNIPOREZNull()
            {
                return this.IsNull(this.tableS_DD_IPP.KRIZNIPOREZColumn);
            }

            public bool IsOSNOVICAKRIZNOGPOREZANull()
            {
                return this.IsNull(this.tableS_DD_IPP.OSNOVICAKRIZNOGPOREZAColumn);
            }

            public void SetBROJRADNIKANull()
            {
                this[this.tableS_DD_IPP.BROJRADNIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKRIZNIPOREZNull()
            {
                this[this.tableS_DD_IPP.KRIZNIPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAKRIZNOGPOREZANull()
            {
                this[this.tableS_DD_IPP.OSNOVICAKRIZNOGPOREZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal BROJRADNIKA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IPP.BROJRADNIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJRADNIKA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IPP.BROJRADNIKAColumn] = value;
                }
            }

            public decimal KRIZNIPOREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IPP.KRIZNIPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value KRIZNIPOREZ because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IPP.KRIZNIPOREZColumn] = value;
                }
            }

            public decimal OSNOVICAKRIZNOGPOREZA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_DD_IPP.OSNOVICAKRIZNOGPOREZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OSNOVICAKRIZNOGPOREZA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_DD_IPP.OSNOVICAKRIZNOGPOREZAColumn] = value;
                }
            }
        }

        public class S_DD_IPPRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_DD_IPPDataSet.S_DD_IPPRow eventRow;

            public S_DD_IPPRowChangeEvent(S_DD_IPPDataSet.S_DD_IPPRow row, DataRowAction action)
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

            public S_DD_IPPDataSet.S_DD_IPPRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_DD_IPPRowChangeEventHandler(object sender, S_DD_IPPDataSet.S_DD_IPPRowChangeEvent e);
    }
}

