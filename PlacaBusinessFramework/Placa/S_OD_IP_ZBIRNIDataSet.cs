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
    public class S_OD_IP_ZBIRNIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_OD_IP_ZBIRNIDataTable tableS_OD_IP_ZBIRNI;

        public S_OD_IP_ZBIRNIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_OD_IP_ZBIRNIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_OD_IP_ZBIRNI"] != null)
                    {
                        this.Tables.Add(new S_OD_IP_ZBIRNIDataTable(dataSet.Tables["S_OD_IP_ZBIRNI"]));
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
            S_OD_IP_ZBIRNIDataSet set = (S_OD_IP_ZBIRNIDataSet) base.Clone();
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
            S_OD_IP_ZBIRNIDataSet set = new S_OD_IP_ZBIRNIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_OD_IP_ZBIRNIDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2108");
            this.ExtendedProperties.Add("DataSetName", "S_OD_IP_ZBIRNIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_OD_IP_ZBIRNIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_OD_IP_ZBIRNI");
            this.ExtendedProperties.Add("ObjectDescription", "S_OD_IP_ZBIRNI");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_IP_ZBIRNI");
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
            this.DataSetName = "S_OD_IP_ZBIRNIDataSet";
            this.Namespace = "http://www.tempuri.org/S_OD_IP_ZBIRNI";
            this.tableS_OD_IP_ZBIRNI = new S_OD_IP_ZBIRNIDataTable();
            this.Tables.Add(this.tableS_OD_IP_ZBIRNI);
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
            this.tableS_OD_IP_ZBIRNI = (S_OD_IP_ZBIRNIDataTable) this.Tables["S_OD_IP_ZBIRNI"];
            if (initTable && (this.tableS_OD_IP_ZBIRNI != null))
            {
                this.tableS_OD_IP_ZBIRNI.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_OD_IP_ZBIRNI"] != null)
                {
                    this.Tables.Add(new S_OD_IP_ZBIRNIDataTable(dataSet.Tables["S_OD_IP_ZBIRNI"]));
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

        private bool ShouldSerializeS_OD_IP_ZBIRNI()
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
        public S_OD_IP_ZBIRNIDataTable S_OD_IP_ZBIRNI
        {
            get
            {
                return this.tableS_OD_IP_ZBIRNI;
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
        public class S_OD_IP_ZBIRNIDataTable : DataTable, IEnumerable
        {
            private DataColumn columndohodak;
            private DataColumn columnIME;
            private DataColumn columnnetoisplata;
            private DataColumn columnnetoplaca;
            private DataColumn columnOIB;
            private DataColumn columnPOREZKRIZNI;
            private DataColumn columnporeznaosnovica;
            private DataColumn columnPOREZPRIREZ;
            private DataColumn columnPREZIME;
            private DataColumn columnukupnobruto;
            private DataColumn columnukupnodoprinosi;
            private DataColumn columnukupnoolaksice;
            private DataColumn columnUKUPNOOO;

            public event S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRowChangeEventHandler S_OD_IP_ZBIRNIRowChanged;

            public event S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRowChangeEventHandler S_OD_IP_ZBIRNIRowChanging;

            public event S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRowChangeEventHandler S_OD_IP_ZBIRNIRowDeleted;

            public event S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRowChangeEventHandler S_OD_IP_ZBIRNIRowDeleting;

            public S_OD_IP_ZBIRNIDataTable()
            {
                this.TableName = "S_OD_IP_ZBIRNI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_OD_IP_ZBIRNIDataTable(DataTable table) : base(table.TableName)
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

            protected S_OD_IP_ZBIRNIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_OD_IP_ZBIRNIRow(S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow row)
            {
                this.Rows.Add(row);
            }

            public S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow AddS_OD_IP_ZBIRNIRow(decimal ukupnobruto, decimal ukupnodoprinosi, decimal ukupnoolaksice, decimal dohodak, decimal uKUPNOOO, decimal poreznaosnovica, decimal pOREZPRIREZ, decimal netoisplata, decimal netoplaca, decimal pOREZKRIZNI, string pREZIME, string iME, string oIB)
            {
                S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow row = (S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow) this.NewRow();
                row.ItemArray = new object[] { ukupnobruto, ukupnodoprinosi, ukupnoolaksice, dohodak, uKUPNOOO, poreznaosnovica, pOREZPRIREZ, netoisplata, netoplaca, pOREZKRIZNI, pREZIME, iME, oIB };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIDataTable table = (S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_OD_IP_ZBIRNIDataSet set = new S_OD_IP_ZBIRNIDataSet();
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
                this.columnukupnobruto = new DataColumn("ukupnobruto", typeof(decimal), "", MappingType.Element);
                this.columnukupnobruto.Caption = "ukupnobruto";
                this.columnukupnobruto.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnobruto.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnobruto.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnobruto.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnobruto.ExtendedProperties.Add("Description", "ukupnobruto");
                this.columnukupnobruto.ExtendedProperties.Add("Length", "12");
                this.columnukupnobruto.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnobruto.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnobruto.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnobruto.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnobruto.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnobruto.ExtendedProperties.Add("Deklarit.InternalName", "ukupnobruto");
                this.Columns.Add(this.columnukupnobruto);
                this.columnukupnodoprinosi = new DataColumn("ukupnodoprinosi", typeof(decimal), "", MappingType.Element);
                this.columnukupnodoprinosi.Caption = "ukupnodoprinosi";
                this.columnukupnodoprinosi.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnodoprinosi.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnodoprinosi.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnodoprinosi.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Description", "ukupnodoprinosi");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Length", "12");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnodoprinosi.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnodoprinosi.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnodoprinosi.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnodoprinosi.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnodoprinosi.ExtendedProperties.Add("Deklarit.InternalName", "ukupnodoprinosi");
                this.Columns.Add(this.columnukupnodoprinosi);
                this.columnukupnoolaksice = new DataColumn("ukupnoolaksice", typeof(decimal), "", MappingType.Element);
                this.columnukupnoolaksice.Caption = "ukupnoolaksice";
                this.columnukupnoolaksice.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnukupnoolaksice.ExtendedProperties.Add("IsKey", "false");
                this.columnukupnoolaksice.ExtendedProperties.Add("ReadOnly", "true");
                this.columnukupnoolaksice.ExtendedProperties.Add("DeklaritType", "int");
                this.columnukupnoolaksice.ExtendedProperties.Add("Description", "ukupnoolaksice");
                this.columnukupnoolaksice.ExtendedProperties.Add("Length", "12");
                this.columnukupnoolaksice.ExtendedProperties.Add("Decimals", "2");
                this.columnukupnoolaksice.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnukupnoolaksice.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnukupnoolaksice.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnukupnoolaksice.ExtendedProperties.Add("IsInReader", "true");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnukupnoolaksice.ExtendedProperties.Add("Deklarit.InternalName", "ukupnoolaksice");
                this.Columns.Add(this.columnukupnoolaksice);
                this.columndohodak = new DataColumn("dohodak", typeof(decimal), "", MappingType.Element);
                this.columndohodak.Caption = "dohodak";
                this.columndohodak.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columndohodak.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columndohodak.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columndohodak.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columndohodak.ExtendedProperties.Add("IsKey", "false");
                this.columndohodak.ExtendedProperties.Add("ReadOnly", "true");
                this.columndohodak.ExtendedProperties.Add("DeklaritType", "int");
                this.columndohodak.ExtendedProperties.Add("Description", "dohodak");
                this.columndohodak.ExtendedProperties.Add("Length", "12");
                this.columndohodak.ExtendedProperties.Add("Decimals", "2");
                this.columndohodak.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columndohodak.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columndohodak.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columndohodak.ExtendedProperties.Add("IsInReader", "true");
                this.columndohodak.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columndohodak.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columndohodak.ExtendedProperties.Add("Deklarit.InternalName", "dohodak");
                this.Columns.Add(this.columndohodak);
                this.columnUKUPNOOO = new DataColumn("UKUPNOOO", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNOOO.Caption = "UKUPNOOO";
                this.columnUKUPNOOO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOOO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOOO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOOO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUPNOOO.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOOO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOOO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOOO.ExtendedProperties.Add("Description", "UKUPNOOO");
                this.columnUKUPNOOO.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNOOO.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNOOO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNOOO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNOOO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOOO.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUPNOOO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOOO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOOO.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOOO");
                this.Columns.Add(this.columnUKUPNOOO);
                this.columnporeznaosnovica = new DataColumn("poreznaosnovica", typeof(decimal), "", MappingType.Element);
                this.columnporeznaosnovica.Caption = "poreznaosnovica";
                this.columnporeznaosnovica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnporeznaosnovica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnporeznaosnovica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnporeznaosnovica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnporeznaosnovica.ExtendedProperties.Add("IsKey", "false");
                this.columnporeznaosnovica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnporeznaosnovica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnporeznaosnovica.ExtendedProperties.Add("Description", "poreznaosnovica");
                this.columnporeznaosnovica.ExtendedProperties.Add("Length", "12");
                this.columnporeznaosnovica.ExtendedProperties.Add("Decimals", "2");
                this.columnporeznaosnovica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnporeznaosnovica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnporeznaosnovica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnporeznaosnovica.ExtendedProperties.Add("IsInReader", "true");
                this.columnporeznaosnovica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnporeznaosnovica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnporeznaosnovica.ExtendedProperties.Add("Deklarit.InternalName", "poreznaosnovica");
                this.Columns.Add(this.columnporeznaosnovica);
                this.columnPOREZPRIREZ = new DataColumn("POREZPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnPOREZPRIREZ.Caption = "POREZPRIREZ";
                this.columnPOREZPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("Description", "POREZPRIREZ");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "POREZPRIREZ");
                this.Columns.Add(this.columnPOREZPRIREZ);
                this.columnnetoisplata = new DataColumn("netoisplata", typeof(decimal), "", MappingType.Element);
                this.columnnetoisplata.Caption = "netoisplata";
                this.columnnetoisplata.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnetoisplata.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnetoisplata.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnetoisplata.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnetoisplata.ExtendedProperties.Add("IsKey", "false");
                this.columnnetoisplata.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnetoisplata.ExtendedProperties.Add("DeklaritType", "int");
                this.columnnetoisplata.ExtendedProperties.Add("Description", "netoisplata");
                this.columnnetoisplata.ExtendedProperties.Add("Length", "12");
                this.columnnetoisplata.ExtendedProperties.Add("Decimals", "2");
                this.columnnetoisplata.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnnetoisplata.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnnetoisplata.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnetoisplata.ExtendedProperties.Add("IsInReader", "true");
                this.columnnetoisplata.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnetoisplata.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnetoisplata.ExtendedProperties.Add("Deklarit.InternalName", "netoisplata");
                this.Columns.Add(this.columnnetoisplata);
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
                this.columnPOREZKRIZNI = new DataColumn("POREZKRIZNI", typeof(decimal), "", MappingType.Element);
                this.columnPOREZKRIZNI.Caption = "POREZKRIZNI";
                this.columnPOREZKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Description", "POREZKRIZNI");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Length", "12");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "POREZKRIZNI");
                this.Columns.Add(this.columnPOREZKRIZNI);
                this.columnPREZIME = new DataColumn("PREZIME", typeof(string), "", MappingType.Element);
                this.columnPREZIME.Caption = "Prezime";
                this.columnPREZIME.MaxLength = 50;
                this.columnPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPREZIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "PREZIME");
                this.Columns.Add(this.columnPREZIME);
                this.columnIME = new DataColumn("IME", typeof(string), "", MappingType.Element);
                this.columnIME.Caption = "Ime";
                this.columnIME.MaxLength = 50;
                this.columnIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIME.ExtendedProperties.Add("IsKey", "false");
                this.columnIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIME.ExtendedProperties.Add("Description", "Ime");
                this.columnIME.ExtendedProperties.Add("Length", "50");
                this.columnIME.ExtendedProperties.Add("Decimals", "0");
                this.columnIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.InternalName", "IME");
                this.Columns.Add(this.columnIME);
                this.columnOIB = new DataColumn("OIB", typeof(string), "", MappingType.Element);
                this.columnOIB.Caption = "OIB";
                this.columnOIB.MaxLength = 11;
                this.columnOIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOIB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOIB.ExtendedProperties.Add("IsKey", "false");
                this.columnOIB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOIB.ExtendedProperties.Add("Description", "OIB");
                this.columnOIB.ExtendedProperties.Add("Length", "11");
                this.columnOIB.ExtendedProperties.Add("Decimals", "0");
                this.columnOIB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOIB.ExtendedProperties.Add("Deklarit.InternalName", "OIB");
                this.Columns.Add(this.columnOIB);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_OD_IP_ZBIRNI");
                this.ExtendedProperties.Add("Description", "S_OD_IP_ZBIRNI");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnukupnobruto = this.Columns["ukupnobruto"];
                this.columnukupnodoprinosi = this.Columns["ukupnodoprinosi"];
                this.columnukupnoolaksice = this.Columns["ukupnoolaksice"];
                this.columndohodak = this.Columns["dohodak"];
                this.columnUKUPNOOO = this.Columns["UKUPNOOO"];
                this.columnporeznaosnovica = this.Columns["poreznaosnovica"];
                this.columnPOREZPRIREZ = this.Columns["POREZPRIREZ"];
                this.columnnetoisplata = this.Columns["netoisplata"];
                this.columnnetoplaca = this.Columns["netoplaca"];
                this.columnPOREZKRIZNI = this.Columns["POREZKRIZNI"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnOIB = this.Columns["OIB"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow(builder);
            }

            public S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow NewS_OD_IP_ZBIRNIRow()
            {
                return (S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_OD_IP_ZBIRNIRowChanged != null)
                {
                    S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRowChangeEventHandler handler = this.S_OD_IP_ZBIRNIRowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRowChangeEvent((S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_OD_IP_ZBIRNIRowChanging != null)
                {
                    S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRowChangeEventHandler handler = this.S_OD_IP_ZBIRNIRowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRowChangeEvent((S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_OD_IP_ZBIRNIRowDeleted != null)
                {
                    S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRowChangeEventHandler handler = this.S_OD_IP_ZBIRNIRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRowChangeEvent((S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_OD_IP_ZBIRNIRowDeleting != null)
                {
                    S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRowChangeEventHandler handler = this.S_OD_IP_ZBIRNIRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRowChangeEvent((S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_OD_IP_ZBIRNIRow(S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow row)
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

            public DataColumn dohodakColumn
            {
                get
                {
                    return this.columndohodak;
                }
            }

            public DataColumn IMEColumn
            {
                get
                {
                    return this.columnIME;
                }
            }

            public S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow this[int index]
            {
                get
                {
                    return (S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow) this.Rows[index];
                }
            }

            public DataColumn netoisplataColumn
            {
                get
                {
                    return this.columnnetoisplata;
                }
            }

            public DataColumn netoplacaColumn
            {
                get
                {
                    return this.columnnetoplaca;
                }
            }

            public DataColumn OIBColumn
            {
                get
                {
                    return this.columnOIB;
                }
            }

            public DataColumn POREZKRIZNIColumn
            {
                get
                {
                    return this.columnPOREZKRIZNI;
                }
            }

            public DataColumn poreznaosnovicaColumn
            {
                get
                {
                    return this.columnporeznaosnovica;
                }
            }

            public DataColumn POREZPRIREZColumn
            {
                get
                {
                    return this.columnPOREZPRIREZ;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn ukupnobrutoColumn
            {
                get
                {
                    return this.columnukupnobruto;
                }
            }

            public DataColumn ukupnodoprinosiColumn
            {
                get
                {
                    return this.columnukupnodoprinosi;
                }
            }

            public DataColumn ukupnoolaksiceColumn
            {
                get
                {
                    return this.columnukupnoolaksice;
                }
            }

            public DataColumn UKUPNOOOColumn
            {
                get
                {
                    return this.columnUKUPNOOO;
                }
            }
        }

        public class S_OD_IP_ZBIRNIRow : DataRow
        {
            private S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIDataTable tableS_OD_IP_ZBIRNI;

            internal S_OD_IP_ZBIRNIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_OD_IP_ZBIRNI = (S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIDataTable) this.Table;
            }

            public bool IsdohodakNull()
            {
                return this.IsNull(this.tableS_OD_IP_ZBIRNI.dohodakColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableS_OD_IP_ZBIRNI.IMEColumn);
            }

            public bool IsnetoisplataNull()
            {
                return this.IsNull(this.tableS_OD_IP_ZBIRNI.netoisplataColumn);
            }

            public bool IsnetoplacaNull()
            {
                return this.IsNull(this.tableS_OD_IP_ZBIRNI.netoplacaColumn);
            }

            public bool IsOIBNull()
            {
                return this.IsNull(this.tableS_OD_IP_ZBIRNI.OIBColumn);
            }

            public bool IsPOREZKRIZNINull()
            {
                return this.IsNull(this.tableS_OD_IP_ZBIRNI.POREZKRIZNIColumn);
            }

            public bool IsporeznaosnovicaNull()
            {
                return this.IsNull(this.tableS_OD_IP_ZBIRNI.poreznaosnovicaColumn);
            }

            public bool IsPOREZPRIREZNull()
            {
                return this.IsNull(this.tableS_OD_IP_ZBIRNI.POREZPRIREZColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableS_OD_IP_ZBIRNI.PREZIMEColumn);
            }

            public bool IsukupnobrutoNull()
            {
                return this.IsNull(this.tableS_OD_IP_ZBIRNI.ukupnobrutoColumn);
            }

            public bool IsukupnodoprinosiNull()
            {
                return this.IsNull(this.tableS_OD_IP_ZBIRNI.ukupnodoprinosiColumn);
            }

            public bool IsukupnoolaksiceNull()
            {
                return this.IsNull(this.tableS_OD_IP_ZBIRNI.ukupnoolaksiceColumn);
            }

            public bool IsUKUPNOOONull()
            {
                return this.IsNull(this.tableS_OD_IP_ZBIRNI.UKUPNOOOColumn);
            }

            public void SetdohodakNull()
            {
                this[this.tableS_OD_IP_ZBIRNI.dohodakColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableS_OD_IP_ZBIRNI.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoisplataNull()
            {
                this[this.tableS_OD_IP_ZBIRNI.netoisplataColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnetoplacaNull()
            {
                this[this.tableS_OD_IP_ZBIRNI.netoplacaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOIBNull()
            {
                this[this.tableS_OD_IP_ZBIRNI.OIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZKRIZNINull()
            {
                this[this.tableS_OD_IP_ZBIRNI.POREZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetporeznaosnovicaNull()
            {
                this[this.tableS_OD_IP_ZBIRNI.poreznaosnovicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZPRIREZNull()
            {
                this[this.tableS_OD_IP_ZBIRNI.POREZPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableS_OD_IP_ZBIRNI.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnobrutoNull()
            {
                this[this.tableS_OD_IP_ZBIRNI.ukupnobrutoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnodoprinosiNull()
            {
                this[this.tableS_OD_IP_ZBIRNI.ukupnodoprinosiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetukupnoolaksiceNull()
            {
                this[this.tableS_OD_IP_ZBIRNI.ukupnoolaksiceColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOOONull()
            {
                this[this.tableS_OD_IP_ZBIRNI.UKUPNOOOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal dohodak
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_IP_ZBIRNI.dohodakColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_IP_ZBIRNI.dohodakColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_IP_ZBIRNI.IMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_IP_ZBIRNI.IMEColumn] = value;
                }
            }

            public decimal netoisplata
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_IP_ZBIRNI.netoisplataColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_IP_ZBIRNI.netoisplataColumn] = value;
                }
            }

            public decimal netoplaca
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_IP_ZBIRNI.netoplacaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_IP_ZBIRNI.netoplacaColumn] = value;
                }
            }

            public string OIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_IP_ZBIRNI.OIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_IP_ZBIRNI.OIBColumn] = value;
                }
            }

            public decimal POREZKRIZNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_IP_ZBIRNI.POREZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_IP_ZBIRNI.POREZKRIZNIColumn] = value;
                }
            }

            public decimal poreznaosnovica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_IP_ZBIRNI.poreznaosnovicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_IP_ZBIRNI.poreznaosnovicaColumn] = value;
                }
            }

            public decimal POREZPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_IP_ZBIRNI.POREZPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_IP_ZBIRNI.POREZPRIREZColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_OD_IP_ZBIRNI.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_OD_IP_ZBIRNI.PREZIMEColumn] = value;
                }
            }

            public decimal ukupnobruto
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_IP_ZBIRNI.ukupnobrutoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_IP_ZBIRNI.ukupnobrutoColumn] = value;
                }
            }

            public decimal ukupnodoprinosi
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_IP_ZBIRNI.ukupnodoprinosiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_IP_ZBIRNI.ukupnodoprinosiColumn] = value;
                }
            }

            public decimal ukupnoolaksice
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_IP_ZBIRNI.ukupnoolaksiceColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_IP_ZBIRNI.ukupnoolaksiceColumn] = value;
                }
            }

            public decimal UKUPNOOO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_OD_IP_ZBIRNI.UKUPNOOOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_OD_IP_ZBIRNI.UKUPNOOOColumn] = value;
                }
            }
        }

        public class S_OD_IP_ZBIRNIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow eventRow;

            public S_OD_IP_ZBIRNIRowChangeEvent(S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow row, DataRowAction action)
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

            public S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_OD_IP_ZBIRNIRowChangeEventHandler(object sender, S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRowChangeEvent e);
    }
}

