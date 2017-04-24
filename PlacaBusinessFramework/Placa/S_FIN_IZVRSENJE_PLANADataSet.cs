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
    public class S_FIN_IZVRSENJE_PLANADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_FIN_IZVRSENJE_PLANADataTable tableS_FIN_IZVRSENJE_PLANA;

        public S_FIN_IZVRSENJE_PLANADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_FIN_IZVRSENJE_PLANADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_FIN_IZVRSENJE_PLANA"] != null)
                    {
                        this.Tables.Add(new S_FIN_IZVRSENJE_PLANADataTable(dataSet.Tables["S_FIN_IZVRSENJE_PLANA"]));
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
            S_FIN_IZVRSENJE_PLANADataSet set = (S_FIN_IZVRSENJE_PLANADataSet) base.Clone();
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
            S_FIN_IZVRSENJE_PLANADataSet set = new S_FIN_IZVRSENJE_PLANADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_FIN_IZVRSENJE_PLANADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2126");
            this.ExtendedProperties.Add("DataSetName", "S_FIN_IZVRSENJE_PLANADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_FIN_IZVRSENJE_PLANADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_FIN_IZVRSENJE_PLANA");
            this.ExtendedProperties.Add("ObjectDescription", "S_FIN_IZVRSENJE_PLANA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_FIN_IZVRSENJE_PLANA");
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
            this.DataSetName = "S_FIN_IZVRSENJE_PLANADataSet";
            this.Namespace = "http://www.tempuri.org/S_FIN_IZVRSENJE_PLANA";
            this.tableS_FIN_IZVRSENJE_PLANA = new S_FIN_IZVRSENJE_PLANADataTable();
            this.Tables.Add(this.tableS_FIN_IZVRSENJE_PLANA);
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
            this.tableS_FIN_IZVRSENJE_PLANA = (S_FIN_IZVRSENJE_PLANADataTable) this.Tables["S_FIN_IZVRSENJE_PLANA"];
            if (initTable && (this.tableS_FIN_IZVRSENJE_PLANA != null))
            {
                this.tableS_FIN_IZVRSENJE_PLANA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_FIN_IZVRSENJE_PLANA"] != null)
                {
                    this.Tables.Add(new S_FIN_IZVRSENJE_PLANADataTable(dataSet.Tables["S_FIN_IZVRSENJE_PLANA"]));
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

        private bool ShouldSerializeS_FIN_IZVRSENJE_PLANA()
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
        public S_FIN_IZVRSENJE_PLANADataTable S_FIN_IZVRSENJE_PLANA
        {
            get
            {
                return this.tableS_FIN_IZVRSENJE_PLANA;
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
        public class S_FIN_IZVRSENJE_PLANADataTable : DataTable, IEnumerable
        {
            private DataColumn columnINDEKS;
            private DataColumn columnIZVRSENO;
            private DataColumn columnkonto;
            private DataColumn columnPLANIRANO;

            public event S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARowChangeEventHandler S_FIN_IZVRSENJE_PLANARowChanged;

            public event S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARowChangeEventHandler S_FIN_IZVRSENJE_PLANARowChanging;

            public event S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARowChangeEventHandler S_FIN_IZVRSENJE_PLANARowDeleted;

            public event S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARowChangeEventHandler S_FIN_IZVRSENJE_PLANARowDeleting;

            public S_FIN_IZVRSENJE_PLANADataTable()
            {
                this.TableName = "S_FIN_IZVRSENJE_PLANA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_FIN_IZVRSENJE_PLANADataTable(DataTable table) : base(table.TableName)
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

            protected S_FIN_IZVRSENJE_PLANADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_FIN_IZVRSENJE_PLANARow(S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow row)
            {
                this.Rows.Add(row);
            }

            public S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow AddS_FIN_IZVRSENJE_PLANARow(string konto, decimal pLANIRANO, decimal iZVRSENO, decimal iNDEKS)
            {
                S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow row = (S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow) this.NewRow();
                row.ItemArray = new object[] { konto, pLANIRANO, iZVRSENO, iNDEKS };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANADataTable table = (S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_FIN_IZVRSENJE_PLANADataSet set = new S_FIN_IZVRSENJE_PLANADataSet();
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
                this.columnkonto = new DataColumn("konto", typeof(string), "", MappingType.Element);
                this.columnkonto.Caption = "konto";
                this.columnkonto.MaxLength = 15;
                this.columnkonto.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnkonto.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnkonto.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnkonto.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnkonto.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnkonto.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnkonto.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnkonto.ExtendedProperties.Add("IsKey", "false");
                this.columnkonto.ExtendedProperties.Add("ReadOnly", "true");
                this.columnkonto.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnkonto.ExtendedProperties.Add("Description", "konto");
                this.columnkonto.ExtendedProperties.Add("Length", "15");
                this.columnkonto.ExtendedProperties.Add("Decimals", "0");
                this.columnkonto.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnkonto.ExtendedProperties.Add("IsInReader", "true");
                this.columnkonto.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnkonto.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnkonto.ExtendedProperties.Add("Deklarit.InternalName", "konto");
                this.Columns.Add(this.columnkonto);
                this.columnPLANIRANO = new DataColumn("PLANIRANO", typeof(decimal), "", MappingType.Element);
                this.columnPLANIRANO.Caption = "PLANIRANO";
                this.columnPLANIRANO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPLANIRANO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPLANIRANO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPLANIRANO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPLANIRANO.ExtendedProperties.Add("IsKey", "false");
                this.columnPLANIRANO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPLANIRANO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPLANIRANO.ExtendedProperties.Add("Description", "PLANIRANO");
                this.columnPLANIRANO.ExtendedProperties.Add("Length", "12");
                this.columnPLANIRANO.ExtendedProperties.Add("Decimals", "2");
                this.columnPLANIRANO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPLANIRANO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPLANIRANO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPLANIRANO.ExtendedProperties.Add("IsInReader", "true");
                this.columnPLANIRANO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPLANIRANO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPLANIRANO.ExtendedProperties.Add("Deklarit.InternalName", "PLANIRANO");
                this.Columns.Add(this.columnPLANIRANO);
                this.columnIZVRSENO = new DataColumn("IZVRSENO", typeof(decimal), "", MappingType.Element);
                this.columnIZVRSENO.Caption = "IZVRSENO";
                this.columnIZVRSENO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZVRSENO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZVRSENO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZVRSENO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZVRSENO.ExtendedProperties.Add("IsKey", "false");
                this.columnIZVRSENO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZVRSENO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZVRSENO.ExtendedProperties.Add("Description", "IZVRSENO");
                this.columnIZVRSENO.ExtendedProperties.Add("Length", "12");
                this.columnIZVRSENO.ExtendedProperties.Add("Decimals", "2");
                this.columnIZVRSENO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZVRSENO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZVRSENO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZVRSENO.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZVRSENO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZVRSENO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZVRSENO.ExtendedProperties.Add("Deklarit.InternalName", "IZVRSENO");
                this.Columns.Add(this.columnIZVRSENO);
                this.columnINDEKS = new DataColumn("INDEKS", typeof(decimal), "", MappingType.Element);
                this.columnINDEKS.Caption = "INDEKS";
                this.columnINDEKS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnINDEKS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnINDEKS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnINDEKS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnINDEKS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnINDEKS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnINDEKS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnINDEKS.ExtendedProperties.Add("IsKey", "false");
                this.columnINDEKS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnINDEKS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnINDEKS.ExtendedProperties.Add("Description", "INDEKS");
                this.columnINDEKS.ExtendedProperties.Add("Length", "5");
                this.columnINDEKS.ExtendedProperties.Add("Decimals", "2");
                this.columnINDEKS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnINDEKS.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnINDEKS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnINDEKS.ExtendedProperties.Add("IsInReader", "true");
                this.columnINDEKS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnINDEKS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnINDEKS.ExtendedProperties.Add("Deklarit.InternalName", "INDEKS");
                this.Columns.Add(this.columnINDEKS);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_FIN_IZVRSENJE_PLANA");
                this.ExtendedProperties.Add("Description", "S_FIN_IZVRSENJE_PLANA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnkonto = this.Columns["konto"];
                this.columnPLANIRANO = this.Columns["PLANIRANO"];
                this.columnIZVRSENO = this.Columns["IZVRSENO"];
                this.columnINDEKS = this.Columns["INDEKS"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow(builder);
            }

            public S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow NewS_FIN_IZVRSENJE_PLANARow()
            {
                return (S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_FIN_IZVRSENJE_PLANARowChanged != null)
                {
                    S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARowChangeEventHandler handler = this.S_FIN_IZVRSENJE_PLANARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARowChangeEvent((S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_FIN_IZVRSENJE_PLANARowChanging != null)
                {
                    S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARowChangeEventHandler handler = this.S_FIN_IZVRSENJE_PLANARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARowChangeEvent((S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_FIN_IZVRSENJE_PLANARowDeleted != null)
                {
                    S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARowChangeEventHandler handler = this.S_FIN_IZVRSENJE_PLANARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARowChangeEvent((S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_FIN_IZVRSENJE_PLANARowDeleting != null)
                {
                    S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARowChangeEventHandler handler = this.S_FIN_IZVRSENJE_PLANARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARowChangeEvent((S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_FIN_IZVRSENJE_PLANARow(S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow row)
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

            public DataColumn INDEKSColumn
            {
                get
                {
                    return this.columnINDEKS;
                }
            }

            public S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow this[int index]
            {
                get
                {
                    return (S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow) this.Rows[index];
                }
            }

            public DataColumn IZVRSENOColumn
            {
                get
                {
                    return this.columnIZVRSENO;
                }
            }

            public DataColumn kontoColumn
            {
                get
                {
                    return this.columnkonto;
                }
            }

            public DataColumn PLANIRANOColumn
            {
                get
                {
                    return this.columnPLANIRANO;
                }
            }
        }

        public class S_FIN_IZVRSENJE_PLANARow : DataRow
        {
            private S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANADataTable tableS_FIN_IZVRSENJE_PLANA;

            internal S_FIN_IZVRSENJE_PLANARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_FIN_IZVRSENJE_PLANA = (S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANADataTable) this.Table;
            }

            public bool IsINDEKSNull()
            {
                return this.IsNull(this.tableS_FIN_IZVRSENJE_PLANA.INDEKSColumn);
            }

            public bool IsIZVRSENONull()
            {
                return this.IsNull(this.tableS_FIN_IZVRSENJE_PLANA.IZVRSENOColumn);
            }

            public bool IskontoNull()
            {
                return this.IsNull(this.tableS_FIN_IZVRSENJE_PLANA.kontoColumn);
            }

            public bool IsPLANIRANONull()
            {
                return this.IsNull(this.tableS_FIN_IZVRSENJE_PLANA.PLANIRANOColumn);
            }

            public void SetINDEKSNull()
            {
                this[this.tableS_FIN_IZVRSENJE_PLANA.INDEKSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZVRSENONull()
            {
                this[this.tableS_FIN_IZVRSENJE_PLANA.IZVRSENOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetkontoNull()
            {
                this[this.tableS_FIN_IZVRSENJE_PLANA.kontoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPLANIRANONull()
            {
                this[this.tableS_FIN_IZVRSENJE_PLANA.PLANIRANOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal INDEKS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IZVRSENJE_PLANA.INDEKSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value INDEKS because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IZVRSENJE_PLANA.INDEKSColumn] = value;
                }
            }

            public decimal IZVRSENO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IZVRSENJE_PLANA.IZVRSENOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IZVRSENO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IZVRSENJE_PLANA.IZVRSENOColumn] = value;
                }
            }

            public string konto
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_IZVRSENJE_PLANA.kontoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value konto because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_IZVRSENJE_PLANA.kontoColumn] = value;
                }
            }

            public decimal PLANIRANO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_IZVRSENJE_PLANA.PLANIRANOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PLANIRANO because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_IZVRSENJE_PLANA.PLANIRANOColumn] = value;
                }
            }
        }

        public class S_FIN_IZVRSENJE_PLANARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow eventRow;

            public S_FIN_IZVRSENJE_PLANARowChangeEvent(S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow row, DataRowAction action)
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

            public S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_FIN_IZVRSENJE_PLANARowChangeEventHandler(object sender, S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARowChangeEvent e);
    }
}

