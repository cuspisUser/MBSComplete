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
    public class S_OS_POSTOJECI_DOKUMENTIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OS_POSTOJECI_DOKUMENTIDataTable tableS_OS_POSTOJECI_DOKUMENTI;

        public S_OS_POSTOJECI_DOKUMENTIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OS_POSTOJECI_DOKUMENTIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OS_POSTOJECI_DOKUMENTI"] != null)
                    {
                        this.Tables.Add(new S_OS_POSTOJECI_DOKUMENTIDataTable(dataSet.Tables["S_OS_POSTOJECI_DOKUMENTI"]));
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
            S_OS_POSTOJECI_DOKUMENTIDataSet set = (S_OS_POSTOJECI_DOKUMENTIDataSet) base.Clone();
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
            S_OS_POSTOJECI_DOKUMENTIDataSet set = new S_OS_POSTOJECI_DOKUMENTIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OS_POSTOJECI_DOKUMENTIDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2160");
            this.ExtendedProperties.Add("DataSetName", "S_OS_POSTOJECI_DOKUMENTIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OS_POSTOJECI_DOKUMENTIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OS_POSTOJECI_DOKUMENTI");
            this.ExtendedProperties.Add("ObjectDescription", "S_OS_POSTOJECI_DOKUMENTI");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\OSNOVNA");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_OS_POSTOJECI_DOKUMENTI");
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
            this.DataSetName = "S_OS_POSTOJECI_DOKUMENTIDataSet";
            this.Namespace = "http://www.tempuri.org/S_OS_POSTOJECI_DOKUMENTI";
            this.tableS_OS_POSTOJECI_DOKUMENTI = new S_OS_POSTOJECI_DOKUMENTIDataTable();
            this.Tables.Add(this.tableS_OS_POSTOJECI_DOKUMENTI);
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
            this.tableS_OS_POSTOJECI_DOKUMENTI = (S_OS_POSTOJECI_DOKUMENTIDataTable) this.Tables["S_OS_POSTOJECI_DOKUMENTI"];
            if (initTable && (this.tableS_OS_POSTOJECI_DOKUMENTI != null))
            {
                this.tableS_OS_POSTOJECI_DOKUMENTI.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OS_POSTOJECI_DOKUMENTI"] != null)
                {
                    this.Tables.Add(new S_OS_POSTOJECI_DOKUMENTIDataTable(dataSet.Tables["S_OS_POSTOJECI_DOKUMENTI"]));
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

        private bool ShouldSerializeS_OS_POSTOJECI_DOKUMENTI()
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
        public S_OS_POSTOJECI_DOKUMENTIDataTable S_OS_POSTOJECI_DOKUMENTI
        {
            get
            {
                return this.tableS_OS_POSTOJECI_DOKUMENTI;
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
        public class S_OS_POSTOJECI_DOKUMENTIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOSDOKUMENT;
            private DataColumn columnOSBROJDOKUMENTA;
            private DataColumn columnOSDATUMDOK;
            private DataColumn columnOSOPIS;

            public event S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRowChangeEventHandler S_OS_POSTOJECI_DOKUMENTIRowChanged;

            public event S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRowChangeEventHandler S_OS_POSTOJECI_DOKUMENTIRowChanging;

            public event S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRowChangeEventHandler S_OS_POSTOJECI_DOKUMENTIRowDeleted;

            public event S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRowChangeEventHandler S_OS_POSTOJECI_DOKUMENTIRowDeleting;

            public S_OS_POSTOJECI_DOKUMENTIDataTable()
            {
                this.TableName = "S_OS_POSTOJECI_DOKUMENTI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OS_POSTOJECI_DOKUMENTIDataTable(DataTable table) : base(table.TableName)
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

            protected S_OS_POSTOJECI_DOKUMENTIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OS_POSTOJECI_DOKUMENTIRow(S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow row)
            {
                this.Rows.Add(row);
            }

            public S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow AddS_OS_POSTOJECI_DOKUMENTIRow(int iDOSDOKUMENT, DateTime oSDATUMDOK, int oSBROJDOKUMENTA, string oSOPIS)
            {
                S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow row = (S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow) this.NewRow();
                row.ItemArray = new object[] { iDOSDOKUMENT, oSDATUMDOK, oSBROJDOKUMENTA, oSOPIS };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIDataTable table = (S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OS_POSTOJECI_DOKUMENTIDataSet set = new S_OS_POSTOJECI_DOKUMENTIDataSet();
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
                this.columnIDOSDOKUMENT = new DataColumn("IDOSDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnIDOSDOKUMENT.Caption = "IDOSDOKUMENT";
                this.columnIDOSDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Description", "IDOSDOKUMENT");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Length", "5");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDOSDOKUMENT");
                this.Columns.Add(this.columnIDOSDOKUMENT);
                this.columnOSDATUMDOK = new DataColumn("OSDATUMDOK", typeof(DateTime), "", MappingType.Element);
                this.columnOSDATUMDOK.Caption = "OSDATUMDOK";
                this.columnOSDATUMDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSDATUMDOK.ExtendedProperties.Add("IsKey", "false");
                this.columnOSDATUMDOK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSDATUMDOK.ExtendedProperties.Add("DeklaritType", "date");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Description", "OSDATUMDOK");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Length", "8");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnOSDATUMDOK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSDATUMDOK.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSDATUMDOK.ExtendedProperties.Add("Deklarit.InternalName", "OSDATUMDOK");
                this.Columns.Add(this.columnOSDATUMDOK);
                this.columnOSBROJDOKUMENTA = new DataColumn("OSBROJDOKUMENTA", typeof(int), "", MappingType.Element);
                this.columnOSBROJDOKUMENTA.Caption = "OSBROJDOKUMENTA";
                this.columnOSBROJDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Description", "OSBROJDOKUMENTA");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Length", "5");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSBROJDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "OSBROJDOKUMENTA");
                this.Columns.Add(this.columnOSBROJDOKUMENTA);
                this.columnOSOPIS = new DataColumn("OSOPIS", typeof(string), "", MappingType.Element);
                this.columnOSOPIS.Caption = "OSOPIS";
                this.columnOSOPIS.MaxLength = 40;
                this.columnOSOPIS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOSOPIS.ExtendedProperties.Add("IsKey", "false");
                this.columnOSOPIS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSOPIS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOSOPIS.ExtendedProperties.Add("Description", "OSOPIS");
                this.columnOSOPIS.ExtendedProperties.Add("Length", "40");
                this.columnOSOPIS.ExtendedProperties.Add("Decimals", "0");
                this.columnOSOPIS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSOPIS.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSOPIS.ExtendedProperties.Add("Deklarit.InternalName", "OSOPIS");
                this.Columns.Add(this.columnOSOPIS);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OS_POSTOJECI_DOKUMENTI");
                this.ExtendedProperties.Add("Description", "_S_OS_POSTOJECI_DOKUMENTI");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDOSDOKUMENT = this.Columns["IDOSDOKUMENT"];
                this.columnOSDATUMDOK = this.Columns["OSDATUMDOK"];
                this.columnOSBROJDOKUMENTA = this.Columns["OSBROJDOKUMENTA"];
                this.columnOSOPIS = this.Columns["OSOPIS"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow(builder);
            }

            public S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow NewS_OS_POSTOJECI_DOKUMENTIRow()
            {
                return (S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OS_POSTOJECI_DOKUMENTIRowChanged != null)
                {
                    S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRowChangeEventHandler handler = this.S_OS_POSTOJECI_DOKUMENTIRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRowChangeEvent((S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OS_POSTOJECI_DOKUMENTIRowChanging != null)
                {
                    S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRowChangeEventHandler handler = this.S_OS_POSTOJECI_DOKUMENTIRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRowChangeEvent((S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OS_POSTOJECI_DOKUMENTIRowDeleted != null)
                {
                    S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRowChangeEventHandler handler = this.S_OS_POSTOJECI_DOKUMENTIRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRowChangeEvent((S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OS_POSTOJECI_DOKUMENTIRowDeleting != null)
                {
                    S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRowChangeEventHandler handler = this.S_OS_POSTOJECI_DOKUMENTIRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRowChangeEvent((S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OS_POSTOJECI_DOKUMENTIRow(S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow row)
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

            public DataColumn IDOSDOKUMENTColumn
            {
                get
                {
                    return this.columnIDOSDOKUMENT;
                }
            }

            public S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow this[int index]
            {
                get
                {
                    return (S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow) this.Rows[index];
                }
            }

            public DataColumn OSBROJDOKUMENTAColumn
            {
                get
                {
                    return this.columnOSBROJDOKUMENTA;
                }
            }

            public DataColumn OSDATUMDOKColumn
            {
                get
                {
                    return this.columnOSDATUMDOK;
                }
            }

            public DataColumn OSOPISColumn
            {
                get
                {
                    return this.columnOSOPIS;
                }
            }
        }

        public class S_OS_POSTOJECI_DOKUMENTIRow : DataRow
        {
            private S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIDataTable tableS_OS_POSTOJECI_DOKUMENTI;

            internal S_OS_POSTOJECI_DOKUMENTIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OS_POSTOJECI_DOKUMENTI = (S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIDataTable) this.Table;
            }

            public bool IsIDOSDOKUMENTNull()
            {
                return this.IsNull(this.tableS_OS_POSTOJECI_DOKUMENTI.IDOSDOKUMENTColumn);
            }

            public bool IsOSBROJDOKUMENTANull()
            {
                return this.IsNull(this.tableS_OS_POSTOJECI_DOKUMENTI.OSBROJDOKUMENTAColumn);
            }

            public bool IsOSDATUMDOKNull()
            {
                return this.IsNull(this.tableS_OS_POSTOJECI_DOKUMENTI.OSDATUMDOKColumn);
            }

            public bool IsOSOPISNull()
            {
                return this.IsNull(this.tableS_OS_POSTOJECI_DOKUMENTI.OSOPISColumn);
            }

            public void SetIDOSDOKUMENTNull()
            {
                this[this.tableS_OS_POSTOJECI_DOKUMENTI.IDOSDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSBROJDOKUMENTANull()
            {
                this[this.tableS_OS_POSTOJECI_DOKUMENTI.OSBROJDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSDATUMDOKNull()
            {
                this[this.tableS_OS_POSTOJECI_DOKUMENTI.OSDATUMDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSOPISNull()
            {
                this[this.tableS_OS_POSTOJECI_DOKUMENTI.OSOPISColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDOSDOKUMENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OS_POSTOJECI_DOKUMENTI.IDOSDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDOSDOKUMENT because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_POSTOJECI_DOKUMENTI.IDOSDOKUMENTColumn] = value;
                }
            }

            public int OSBROJDOKUMENTA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_OS_POSTOJECI_DOKUMENTI.OSBROJDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OSBROJDOKUMENTA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OS_POSTOJECI_DOKUMENTI.OSBROJDOKUMENTAColumn] = value;
                }
            }

            public DateTime OSDATUMDOK
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_OS_POSTOJECI_DOKUMENTI.OSDATUMDOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OSDATUMDOK because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_OS_POSTOJECI_DOKUMENTI.OSDATUMDOKColumn] = value;
                }
            }

            public string OSOPIS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OS_POSTOJECI_DOKUMENTI.OSOPISColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OSOPIS because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OS_POSTOJECI_DOKUMENTI.OSOPISColumn] = value;
                }
            }
        }

        public class S_OS_POSTOJECI_DOKUMENTIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow eventRow;

            public S_OS_POSTOJECI_DOKUMENTIRowChangeEvent(S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow row, DataRowAction action)
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

            public S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OS_POSTOJECI_DOKUMENTIRowChangeEventHandler(object sender, S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRowChangeEvent e);
    }
}

