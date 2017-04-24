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
    public class s_od_pripremaDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private s_od_pripremaDataTable tables_od_priprema;

        public s_od_pripremaDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected s_od_pripremaDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["s_od_priprema"] != null)
                    {
                        this.Tables.Add(new s_od_pripremaDataTable(dataSet.Tables["s_od_priprema"]));
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
            s_od_pripremaDataSet set = (s_od_pripremaDataSet) base.Clone();
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
            s_od_pripremaDataSet set = new s_od_pripremaDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "s_od_pripremaDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2071");
            this.ExtendedProperties.Add("DataSetName", "s_od_pripremaDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Is_od_pripremaDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "s_od_priprema");
            this.ExtendedProperties.Add("ObjectDescription", "s_od_priprema");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_PRIPREMA");
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
            this.DataSetName = "s_od_pripremaDataSet";
            this.Namespace = "http://www.tempuri.org/s_od_priprema";
            this.tables_od_priprema = new s_od_pripremaDataTable();
            this.Tables.Add(this.tables_od_priprema);
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
            this.tables_od_priprema = (s_od_pripremaDataTable) this.Tables["s_od_priprema"];
            if (initTable && (this.tables_od_priprema != null))
            {
                this.tables_od_priprema.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["s_od_priprema"] != null)
                {
                    this.Tables.Add(new s_od_pripremaDataTable(dataSet.Tables["s_od_priprema"]));
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

        private bool ShouldSerializes_od_priprema()
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
        public s_od_pripremaDataTable s_od_priprema
        {
            get
            {
                return this.tables_od_priprema;
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
        public class s_od_pripremaDataTable : DataTable, IEnumerable
        {
            private DataColumn columnblagdan;
            private DataColumn columnblagdansatnica;
            private DataColumn columnblagdanuvecani;
            private DataColumn columnDODATNIKOEFICIJENT;
            private DataColumn columndvokratni;
            private DataColumn columndvokratnisatnica;
            private DataColumn columndvokratniuvecani;
            private DataColumn columnimeprezime;
            private DataColumn columnKOMBINACIJAIZNOS;
            private DataColumn columnKOMBINACIJAIZNOS2;
            private DataColumn columnKOMBINACIJAPOSTOTAK;
            private DataColumn columnKOMBINACIJAPOSTOTAK2;
            private DataColumn columnNAZIVRADNOMJESTO;
            private DataColumn columnnedjeljom;
            private DataColumn columnnedjeljomsatnica;
            private DataColumn columnnedjeljomuvecani;
            private DataColumn columnnocni;
            private DataColumn columnnocnisatnica;
            private DataColumn columnnocniuvecani;
            private DataColumn columnosnovnaplaca;
            private DataColumn columnposebni1iznos;
            private DataColumn columnposebni1sati;
            private DataColumn columnposebni1satnica;
            private DataColumn columnposebni2iznos;
            private DataColumn columnposebni2sati;
            private DataColumn columnposebni2satnica;
            private DataColumn columnposebni3iznos;
            private DataColumn columnposebni3sati;
            private DataColumn columnposebni3satnica;
            private DataColumn columnprekovremeni;
            private DataColumn columnprekovremenisatnica;
            private DataColumn columnprekovremeniuvecani;
            private DataColumn columnsmjenskiiznos;
            private DataColumn columnsmjenskisati;
            private DataColumn columnsmjenskisatnica;
            private DataColumn columnsposebni1iznos;
            private DataColumn columnsposebni1sati;
            private DataColumn columnsposebni1satnica;
            private DataColumn columnsposebni2iznos;
            private DataColumn columnsposebni2sati;
            private DataColumn columnsposebni2satnica;
            private DataColumn columnsposebni3iznos;
            private DataColumn columnsposebni3sati;
            private DataColumn columnsposebni3satnica;
            private DataColumn columnsubotom;
            private DataColumn columnsubotomsatnica;
            private DataColumn columnsubotomuvecani;

            public event s_od_pripremaDataSet.s_od_pripremaRowChangeEventHandler s_od_pripremaRowChanged;

            public event s_od_pripremaDataSet.s_od_pripremaRowChangeEventHandler s_od_pripremaRowChanging;

            public event s_od_pripremaDataSet.s_od_pripremaRowChangeEventHandler s_od_pripremaRowDeleted;

            public event s_od_pripremaDataSet.s_od_pripremaRowChangeEventHandler s_od_pripremaRowDeleting;

            public s_od_pripremaDataTable()
            {
                this.TableName = "s_od_priprema";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal s_od_pripremaDataTable(DataTable table) : base(table.TableName)
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

            protected s_od_pripremaDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void Adds_od_pripremaRow(s_od_pripremaDataSet.s_od_pripremaRow row)
            {
                this.Rows.Add(row);
            }

            public s_od_pripremaDataSet.s_od_pripremaRow Adds_od_pripremaRow(string imeprezime, string nAZIVRADNOMJESTO, decimal osnovnaplaca, decimal smjenskiiznos, decimal smjenskisatnica, decimal smjenskisati, decimal posebni1iznos, decimal posebni1satnica, decimal posebni1sati, decimal posebni2iznos, decimal posebni2satnica, decimal posebni2sati, decimal posebni3iznos, decimal posebni3satnica, decimal posebni3sati, decimal nocnisatnica, decimal nocniuvecani, decimal nocni, decimal prekovremenisatnica, decimal prekovremeniuvecani, decimal prekovremeni, decimal subotomsatnica, decimal subotomuvecani, decimal subotom, decimal nedjeljomsatnica, decimal nedjeljomuvecani, decimal nedjeljom, decimal blagdansatnica, decimal blagdanuvecani, decimal blagdan, decimal dvokratnisatnica, decimal dvokratniuvecani, decimal dvokratni, decimal dODATNIKOEFICIJENT, decimal kOMBINACIJAIZNOS, decimal kOMBINACIJAPOSTOTAK, decimal kOMBINACIJAIZNOS2, decimal kOMBINACIJAPOSTOTAK2, decimal sposebni1iznos, decimal sposebni1satnica, decimal sposebni1sati, decimal sposebni2iznos, decimal sposebni2satnica, decimal sposebni2sati, decimal sposebni3iznos, decimal sposebni3satnica, decimal sposebni3sati)
            {
                s_od_pripremaDataSet.s_od_pripremaRow row = (s_od_pripremaDataSet.s_od_pripremaRow) this.NewRow();
                row.ItemArray = new object[] { 
                    imeprezime, nAZIVRADNOMJESTO, osnovnaplaca, smjenskiiznos, smjenskisatnica, smjenskisati, posebni1iznos, posebni1satnica, posebni1sati, posebni2iznos, posebni2satnica, posebni2sati, posebni3iznos, posebni3satnica, posebni3sati, nocnisatnica, 
                    nocniuvecani, nocni, prekovremenisatnica, prekovremeniuvecani, prekovremeni, subotomsatnica, subotomuvecani, subotom, nedjeljomsatnica, nedjeljomuvecani, nedjeljom, blagdansatnica, blagdanuvecani, blagdan, dvokratnisatnica, dvokratniuvecani, 
                    dvokratni, dODATNIKOEFICIJENT, kOMBINACIJAIZNOS, kOMBINACIJAPOSTOTAK, kOMBINACIJAIZNOS2, kOMBINACIJAPOSTOTAK2, sposebni1iznos, sposebni1satnica, sposebni1sati, sposebni2iznos, sposebni2satnica, sposebni2sati, sposebni3iznos, sposebni3satnica, sposebni3sati
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                s_od_pripremaDataSet.s_od_pripremaDataTable table = (s_od_pripremaDataSet.s_od_pripremaDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(s_od_pripremaDataSet.s_od_pripremaRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                s_od_pripremaDataSet set = new s_od_pripremaDataSet();
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
                this.columnimeprezime = new DataColumn("imeprezime", typeof(string), "", MappingType.Element);
                this.columnimeprezime.Caption = "imeprezime";
                this.columnimeprezime.MaxLength = 50;
                this.columnimeprezime.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnimeprezime.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnimeprezime.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnimeprezime.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnimeprezime.ExtendedProperties.Add("IsKey", "false");
                this.columnimeprezime.ExtendedProperties.Add("ReadOnly", "true");
                this.columnimeprezime.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnimeprezime.ExtendedProperties.Add("Description", "imeprezime");
                this.columnimeprezime.ExtendedProperties.Add("Length", "50");
                this.columnimeprezime.ExtendedProperties.Add("Decimals", "0");
                this.columnimeprezime.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnimeprezime.ExtendedProperties.Add("IsInReader", "true");
                this.columnimeprezime.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnimeprezime.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnimeprezime.ExtendedProperties.Add("Deklarit.InternalName", "imeprezime");
                this.Columns.Add(this.columnimeprezime);
                this.columnNAZIVRADNOMJESTO = new DataColumn("NAZIVRADNOMJESTO", typeof(string), "", MappingType.Element);
                this.columnNAZIVRADNOMJESTO.Caption = "Naziv radnog mjesta";
                this.columnNAZIVRADNOMJESTO.MaxLength = 50;
                this.columnNAZIVRADNOMJESTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Description", "Naziv radnog mjesta");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVRADNOMJESTO");
                this.Columns.Add(this.columnNAZIVRADNOMJESTO);
                this.columnosnovnaplaca = new DataColumn("osnovnaplaca", typeof(decimal), "", MappingType.Element);
                this.columnosnovnaplaca.Caption = "osnovnaplaca";
                this.columnosnovnaplaca.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnosnovnaplaca.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnosnovnaplaca.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnosnovnaplaca.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnosnovnaplaca.ExtendedProperties.Add("IsKey", "false");
                this.columnosnovnaplaca.ExtendedProperties.Add("ReadOnly", "true");
                this.columnosnovnaplaca.ExtendedProperties.Add("DeklaritType", "int");
                this.columnosnovnaplaca.ExtendedProperties.Add("Description", "osnovnaplaca");
                this.columnosnovnaplaca.ExtendedProperties.Add("Length", "12");
                this.columnosnovnaplaca.ExtendedProperties.Add("Decimals", "2");
                this.columnosnovnaplaca.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnosnovnaplaca.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnosnovnaplaca.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnosnovnaplaca.ExtendedProperties.Add("IsInReader", "true");
                this.columnosnovnaplaca.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnosnovnaplaca.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnosnovnaplaca.ExtendedProperties.Add("Deklarit.InternalName", "osnovnaplaca");
                this.Columns.Add(this.columnosnovnaplaca);
                this.columnsmjenskiiznos = new DataColumn("smjenskiiznos", typeof(decimal), "", MappingType.Element);
                this.columnsmjenskiiznos.Caption = "smjenskiiznos";
                this.columnsmjenskiiznos.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsmjenskiiznos.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsmjenskiiznos.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsmjenskiiznos.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsmjenskiiznos.ExtendedProperties.Add("IsKey", "false");
                this.columnsmjenskiiznos.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsmjenskiiznos.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsmjenskiiznos.ExtendedProperties.Add("Description", "smjenskiiznos");
                this.columnsmjenskiiznos.ExtendedProperties.Add("Length", "12");
                this.columnsmjenskiiznos.ExtendedProperties.Add("Decimals", "2");
                this.columnsmjenskiiznos.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsmjenskiiznos.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsmjenskiiznos.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsmjenskiiznos.ExtendedProperties.Add("IsInReader", "true");
                this.columnsmjenskiiznos.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsmjenskiiznos.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsmjenskiiznos.ExtendedProperties.Add("Deklarit.InternalName", "smjenskiiznos");
                this.Columns.Add(this.columnsmjenskiiznos);
                this.columnsmjenskisatnica = new DataColumn("smjenskisatnica", typeof(decimal), "", MappingType.Element);
                this.columnsmjenskisatnica.Caption = "smjenskisatnica";
                this.columnsmjenskisatnica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsmjenskisatnica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsmjenskisatnica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsmjenskisatnica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsmjenskisatnica.ExtendedProperties.Add("IsKey", "false");
                this.columnsmjenskisatnica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsmjenskisatnica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsmjenskisatnica.ExtendedProperties.Add("Description", "smjenskisatnica");
                this.columnsmjenskisatnica.ExtendedProperties.Add("Length", "12");
                this.columnsmjenskisatnica.ExtendedProperties.Add("Decimals", "2");
                this.columnsmjenskisatnica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsmjenskisatnica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsmjenskisatnica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsmjenskisatnica.ExtendedProperties.Add("IsInReader", "true");
                this.columnsmjenskisatnica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsmjenskisatnica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsmjenskisatnica.ExtendedProperties.Add("Deklarit.InternalName", "smjenskisatnica");
                this.Columns.Add(this.columnsmjenskisatnica);
                this.columnsmjenskisati = new DataColumn("smjenskisati", typeof(decimal), "", MappingType.Element);
                this.columnsmjenskisati.Caption = "smjenskisati";
                this.columnsmjenskisati.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsmjenskisati.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsmjenskisati.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsmjenskisati.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsmjenskisati.ExtendedProperties.Add("IsKey", "false");
                this.columnsmjenskisati.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsmjenskisati.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsmjenskisati.ExtendedProperties.Add("Description", "smjenskisati");
                this.columnsmjenskisati.ExtendedProperties.Add("Length", "12");
                this.columnsmjenskisati.ExtendedProperties.Add("Decimals", "2");
                this.columnsmjenskisati.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsmjenskisati.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsmjenskisati.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsmjenskisati.ExtendedProperties.Add("IsInReader", "true");
                this.columnsmjenskisati.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsmjenskisati.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsmjenskisati.ExtendedProperties.Add("Deklarit.InternalName", "smjenskisati");
                this.Columns.Add(this.columnsmjenskisati);
                this.columnposebni1iznos = new DataColumn("posebni1iznos", typeof(decimal), "", MappingType.Element);
                this.columnposebni1iznos.Caption = "posebni1iznos";
                this.columnposebni1iznos.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnposebni1iznos.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnposebni1iznos.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnposebni1iznos.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnposebni1iznos.ExtendedProperties.Add("IsKey", "false");
                this.columnposebni1iznos.ExtendedProperties.Add("ReadOnly", "true");
                this.columnposebni1iznos.ExtendedProperties.Add("DeklaritType", "int");
                this.columnposebni1iznos.ExtendedProperties.Add("Description", "posebni1iznos");
                this.columnposebni1iznos.ExtendedProperties.Add("Length", "12");
                this.columnposebni1iznos.ExtendedProperties.Add("Decimals", "2");
                this.columnposebni1iznos.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnposebni1iznos.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnposebni1iznos.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnposebni1iznos.ExtendedProperties.Add("IsInReader", "true");
                this.columnposebni1iznos.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnposebni1iznos.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnposebni1iznos.ExtendedProperties.Add("Deklarit.InternalName", "posebni1iznos");
                this.Columns.Add(this.columnposebni1iznos);
                this.columnposebni1satnica = new DataColumn("posebni1satnica", typeof(decimal), "", MappingType.Element);
                this.columnposebni1satnica.Caption = "posebni1satnica";
                this.columnposebni1satnica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnposebni1satnica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnposebni1satnica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnposebni1satnica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnposebni1satnica.ExtendedProperties.Add("IsKey", "false");
                this.columnposebni1satnica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnposebni1satnica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnposebni1satnica.ExtendedProperties.Add("Description", "posebni1satnica");
                this.columnposebni1satnica.ExtendedProperties.Add("Length", "12");
                this.columnposebni1satnica.ExtendedProperties.Add("Decimals", "2");
                this.columnposebni1satnica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnposebni1satnica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnposebni1satnica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnposebni1satnica.ExtendedProperties.Add("IsInReader", "true");
                this.columnposebni1satnica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnposebni1satnica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnposebni1satnica.ExtendedProperties.Add("Deklarit.InternalName", "posebni1satnica");
                this.Columns.Add(this.columnposebni1satnica);
                this.columnposebni1sati = new DataColumn("posebni1sati", typeof(decimal), "", MappingType.Element);
                this.columnposebni1sati.Caption = "posebni1sati";
                this.columnposebni1sati.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnposebni1sati.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnposebni1sati.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnposebni1sati.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnposebni1sati.ExtendedProperties.Add("IsKey", "false");
                this.columnposebni1sati.ExtendedProperties.Add("ReadOnly", "true");
                this.columnposebni1sati.ExtendedProperties.Add("DeklaritType", "int");
                this.columnposebni1sati.ExtendedProperties.Add("Description", "posebni1sati");
                this.columnposebni1sati.ExtendedProperties.Add("Length", "12");
                this.columnposebni1sati.ExtendedProperties.Add("Decimals", "2");
                this.columnposebni1sati.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnposebni1sati.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnposebni1sati.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnposebni1sati.ExtendedProperties.Add("IsInReader", "true");
                this.columnposebni1sati.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnposebni1sati.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnposebni1sati.ExtendedProperties.Add("Deklarit.InternalName", "posebni1sati");
                this.Columns.Add(this.columnposebni1sati);
                this.columnposebni2iznos = new DataColumn("posebni2iznos", typeof(decimal), "", MappingType.Element);
                this.columnposebni2iznos.Caption = "posebni2iznos";
                this.columnposebni2iznos.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnposebni2iznos.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnposebni2iznos.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnposebni2iznos.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnposebni2iznos.ExtendedProperties.Add("IsKey", "false");
                this.columnposebni2iznos.ExtendedProperties.Add("ReadOnly", "true");
                this.columnposebni2iznos.ExtendedProperties.Add("DeklaritType", "int");
                this.columnposebni2iznos.ExtendedProperties.Add("Description", "posebni2iznos");
                this.columnposebni2iznos.ExtendedProperties.Add("Length", "12");
                this.columnposebni2iznos.ExtendedProperties.Add("Decimals", "2");
                this.columnposebni2iznos.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnposebni2iznos.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnposebni2iznos.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnposebni2iznos.ExtendedProperties.Add("IsInReader", "true");
                this.columnposebni2iznos.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnposebni2iznos.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnposebni2iznos.ExtendedProperties.Add("Deklarit.InternalName", "posebni2iznos");
                this.Columns.Add(this.columnposebni2iznos);
                this.columnposebni2satnica = new DataColumn("posebni2satnica", typeof(decimal), "", MappingType.Element);
                this.columnposebni2satnica.Caption = "posebni2satnica";
                this.columnposebni2satnica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnposebni2satnica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnposebni2satnica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnposebni2satnica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnposebni2satnica.ExtendedProperties.Add("IsKey", "false");
                this.columnposebni2satnica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnposebni2satnica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnposebni2satnica.ExtendedProperties.Add("Description", "posebni2satnica");
                this.columnposebni2satnica.ExtendedProperties.Add("Length", "12");
                this.columnposebni2satnica.ExtendedProperties.Add("Decimals", "2");
                this.columnposebni2satnica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnposebni2satnica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnposebni2satnica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnposebni2satnica.ExtendedProperties.Add("IsInReader", "true");
                this.columnposebni2satnica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnposebni2satnica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnposebni2satnica.ExtendedProperties.Add("Deklarit.InternalName", "posebni2satnica");
                this.Columns.Add(this.columnposebni2satnica);
                this.columnposebni2sati = new DataColumn("posebni2sati", typeof(decimal), "", MappingType.Element);
                this.columnposebni2sati.Caption = "posebni2sati";
                this.columnposebni2sati.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnposebni2sati.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnposebni2sati.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnposebni2sati.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnposebni2sati.ExtendedProperties.Add("IsKey", "false");
                this.columnposebni2sati.ExtendedProperties.Add("ReadOnly", "true");
                this.columnposebni2sati.ExtendedProperties.Add("DeklaritType", "int");
                this.columnposebni2sati.ExtendedProperties.Add("Description", "posebni2sati");
                this.columnposebni2sati.ExtendedProperties.Add("Length", "12");
                this.columnposebni2sati.ExtendedProperties.Add("Decimals", "2");
                this.columnposebni2sati.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnposebni2sati.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnposebni2sati.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnposebni2sati.ExtendedProperties.Add("IsInReader", "true");
                this.columnposebni2sati.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnposebni2sati.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnposebni2sati.ExtendedProperties.Add("Deklarit.InternalName", "posebni2sati");
                this.Columns.Add(this.columnposebni2sati);
                this.columnposebni3iznos = new DataColumn("posebni3iznos", typeof(decimal), "", MappingType.Element);
                this.columnposebni3iznos.Caption = "posebni3iznos";
                this.columnposebni3iznos.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnposebni3iznos.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnposebni3iznos.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnposebni3iznos.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnposebni3iznos.ExtendedProperties.Add("IsKey", "false");
                this.columnposebni3iznos.ExtendedProperties.Add("ReadOnly", "true");
                this.columnposebni3iznos.ExtendedProperties.Add("DeklaritType", "int");
                this.columnposebni3iznos.ExtendedProperties.Add("Description", "posebni3iznos");
                this.columnposebni3iznos.ExtendedProperties.Add("Length", "12");
                this.columnposebni3iznos.ExtendedProperties.Add("Decimals", "2");
                this.columnposebni3iznos.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnposebni3iznos.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnposebni3iznos.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnposebni3iznos.ExtendedProperties.Add("IsInReader", "true");
                this.columnposebni3iznos.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnposebni3iznos.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnposebni3iznos.ExtendedProperties.Add("Deklarit.InternalName", "posebni3iznos");
                this.Columns.Add(this.columnposebni3iznos);
                this.columnposebni3satnica = new DataColumn("posebni3satnica", typeof(decimal), "", MappingType.Element);
                this.columnposebni3satnica.Caption = "posebni3satnica";
                this.columnposebni3satnica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnposebni3satnica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnposebni3satnica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnposebni3satnica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnposebni3satnica.ExtendedProperties.Add("IsKey", "false");
                this.columnposebni3satnica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnposebni3satnica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnposebni3satnica.ExtendedProperties.Add("Description", "posebni3satnica");
                this.columnposebni3satnica.ExtendedProperties.Add("Length", "12");
                this.columnposebni3satnica.ExtendedProperties.Add("Decimals", "2");
                this.columnposebni3satnica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnposebni3satnica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnposebni3satnica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnposebni3satnica.ExtendedProperties.Add("IsInReader", "true");
                this.columnposebni3satnica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnposebni3satnica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnposebni3satnica.ExtendedProperties.Add("Deklarit.InternalName", "posebni3satnica");
                this.Columns.Add(this.columnposebni3satnica);
                this.columnposebni3sati = new DataColumn("posebni3sati", typeof(decimal), "", MappingType.Element);
                this.columnposebni3sati.Caption = "posebni3sati";
                this.columnposebni3sati.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnposebni3sati.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnposebni3sati.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnposebni3sati.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnposebni3sati.ExtendedProperties.Add("IsKey", "false");
                this.columnposebni3sati.ExtendedProperties.Add("ReadOnly", "true");
                this.columnposebni3sati.ExtendedProperties.Add("DeklaritType", "int");
                this.columnposebni3sati.ExtendedProperties.Add("Description", "posebni3sati");
                this.columnposebni3sati.ExtendedProperties.Add("Length", "12");
                this.columnposebni3sati.ExtendedProperties.Add("Decimals", "2");
                this.columnposebni3sati.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnposebni3sati.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnposebni3sati.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnposebni3sati.ExtendedProperties.Add("IsInReader", "true");
                this.columnposebni3sati.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnposebni3sati.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnposebni3sati.ExtendedProperties.Add("Deklarit.InternalName", "posebni3sati");
                this.Columns.Add(this.columnposebni3sati);
                this.columnnocnisatnica = new DataColumn("nocnisatnica", typeof(decimal), "", MappingType.Element);
                this.columnnocnisatnica.Caption = "nocnisatnica";
                this.columnnocnisatnica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnocnisatnica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnocnisatnica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnocnisatnica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnocnisatnica.ExtendedProperties.Add("IsKey", "false");
                this.columnnocnisatnica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnocnisatnica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnnocnisatnica.ExtendedProperties.Add("Description", "nocnisatnica");
                this.columnnocnisatnica.ExtendedProperties.Add("Length", "12");
                this.columnnocnisatnica.ExtendedProperties.Add("Decimals", "2");
                this.columnnocnisatnica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnnocnisatnica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnnocnisatnica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnocnisatnica.ExtendedProperties.Add("IsInReader", "true");
                this.columnnocnisatnica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnocnisatnica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnocnisatnica.ExtendedProperties.Add("Deklarit.InternalName", "nocnisatnica");
                this.Columns.Add(this.columnnocnisatnica);
                this.columnnocniuvecani = new DataColumn("nocniuvecani", typeof(decimal), "", MappingType.Element);
                this.columnnocniuvecani.Caption = "nocniuvecani";
                this.columnnocniuvecani.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnocniuvecani.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnocniuvecani.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnocniuvecani.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnocniuvecani.ExtendedProperties.Add("IsKey", "false");
                this.columnnocniuvecani.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnocniuvecani.ExtendedProperties.Add("DeklaritType", "int");
                this.columnnocniuvecani.ExtendedProperties.Add("Description", "nocniuvecani");
                this.columnnocniuvecani.ExtendedProperties.Add("Length", "12");
                this.columnnocniuvecani.ExtendedProperties.Add("Decimals", "2");
                this.columnnocniuvecani.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnnocniuvecani.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnnocniuvecani.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnocniuvecani.ExtendedProperties.Add("IsInReader", "true");
                this.columnnocniuvecani.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnocniuvecani.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnocniuvecani.ExtendedProperties.Add("Deklarit.InternalName", "nocniuvecani");
                this.Columns.Add(this.columnnocniuvecani);
                this.columnnocni = new DataColumn("nocni", typeof(decimal), "", MappingType.Element);
                this.columnnocni.Caption = "nocni";
                this.columnnocni.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnocni.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnocni.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnocni.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnocni.ExtendedProperties.Add("IsKey", "false");
                this.columnnocni.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnocni.ExtendedProperties.Add("DeklaritType", "int");
                this.columnnocni.ExtendedProperties.Add("Description", "nocni");
                this.columnnocni.ExtendedProperties.Add("Length", "12");
                this.columnnocni.ExtendedProperties.Add("Decimals", "2");
                this.columnnocni.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnnocni.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnnocni.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnocni.ExtendedProperties.Add("IsInReader", "true");
                this.columnnocni.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnocni.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnocni.ExtendedProperties.Add("Deklarit.InternalName", "nocni");
                this.Columns.Add(this.columnnocni);
                this.columnprekovremenisatnica = new DataColumn("prekovremenisatnica", typeof(decimal), "", MappingType.Element);
                this.columnprekovremenisatnica.Caption = "prekovremenisatnica";
                this.columnprekovremenisatnica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnprekovremenisatnica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnprekovremenisatnica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnprekovremenisatnica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnprekovremenisatnica.ExtendedProperties.Add("IsKey", "false");
                this.columnprekovremenisatnica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnprekovremenisatnica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnprekovremenisatnica.ExtendedProperties.Add("Description", "prekovremenisatnica");
                this.columnprekovremenisatnica.ExtendedProperties.Add("Length", "12");
                this.columnprekovremenisatnica.ExtendedProperties.Add("Decimals", "2");
                this.columnprekovremenisatnica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnprekovremenisatnica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnprekovremenisatnica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnprekovremenisatnica.ExtendedProperties.Add("IsInReader", "true");
                this.columnprekovremenisatnica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnprekovremenisatnica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnprekovremenisatnica.ExtendedProperties.Add("Deklarit.InternalName", "prekovremenisatnica");
                this.Columns.Add(this.columnprekovremenisatnica);
                this.columnprekovremeniuvecani = new DataColumn("prekovremeniuvecani", typeof(decimal), "", MappingType.Element);
                this.columnprekovremeniuvecani.Caption = "prekovremeniuvecani";
                this.columnprekovremeniuvecani.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnprekovremeniuvecani.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("IsKey", "false");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("ReadOnly", "true");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("DeklaritType", "int");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("Description", "prekovremeniuvecani");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("Length", "12");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("Decimals", "2");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("IsInReader", "true");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnprekovremeniuvecani.ExtendedProperties.Add("Deklarit.InternalName", "prekovremeniuvecani");
                this.Columns.Add(this.columnprekovremeniuvecani);
                this.columnprekovremeni = new DataColumn("prekovremeni", typeof(decimal), "", MappingType.Element);
                this.columnprekovremeni.Caption = "prekovremeni";
                this.columnprekovremeni.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnprekovremeni.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnprekovremeni.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnprekovremeni.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnprekovremeni.ExtendedProperties.Add("IsKey", "false");
                this.columnprekovremeni.ExtendedProperties.Add("ReadOnly", "true");
                this.columnprekovremeni.ExtendedProperties.Add("DeklaritType", "int");
                this.columnprekovremeni.ExtendedProperties.Add("Description", "prekovremeni");
                this.columnprekovremeni.ExtendedProperties.Add("Length", "12");
                this.columnprekovremeni.ExtendedProperties.Add("Decimals", "2");
                this.columnprekovremeni.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnprekovremeni.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnprekovremeni.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnprekovremeni.ExtendedProperties.Add("IsInReader", "true");
                this.columnprekovremeni.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnprekovremeni.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnprekovremeni.ExtendedProperties.Add("Deklarit.InternalName", "prekovremeni");
                this.Columns.Add(this.columnprekovremeni);
                this.columnsubotomsatnica = new DataColumn("subotomsatnica", typeof(decimal), "", MappingType.Element);
                this.columnsubotomsatnica.Caption = "subotomsatnica";
                this.columnsubotomsatnica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsubotomsatnica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsubotomsatnica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsubotomsatnica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsubotomsatnica.ExtendedProperties.Add("IsKey", "false");
                this.columnsubotomsatnica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsubotomsatnica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsubotomsatnica.ExtendedProperties.Add("Description", "subotomsatnica");
                this.columnsubotomsatnica.ExtendedProperties.Add("Length", "12");
                this.columnsubotomsatnica.ExtendedProperties.Add("Decimals", "2");
                this.columnsubotomsatnica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsubotomsatnica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsubotomsatnica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsubotomsatnica.ExtendedProperties.Add("IsInReader", "true");
                this.columnsubotomsatnica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsubotomsatnica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsubotomsatnica.ExtendedProperties.Add("Deklarit.InternalName", "subotomsatnica");
                this.Columns.Add(this.columnsubotomsatnica);
                this.columnsubotomuvecani = new DataColumn("subotomuvecani", typeof(decimal), "", MappingType.Element);
                this.columnsubotomuvecani.Caption = "subotomuvecani";
                this.columnsubotomuvecani.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsubotomuvecani.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsubotomuvecani.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsubotomuvecani.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsubotomuvecani.ExtendedProperties.Add("IsKey", "false");
                this.columnsubotomuvecani.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsubotomuvecani.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsubotomuvecani.ExtendedProperties.Add("Description", "subotomuvecani");
                this.columnsubotomuvecani.ExtendedProperties.Add("Length", "12");
                this.columnsubotomuvecani.ExtendedProperties.Add("Decimals", "2");
                this.columnsubotomuvecani.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsubotomuvecani.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsubotomuvecani.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsubotomuvecani.ExtendedProperties.Add("IsInReader", "true");
                this.columnsubotomuvecani.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsubotomuvecani.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsubotomuvecani.ExtendedProperties.Add("Deklarit.InternalName", "subotomuvecani");
                this.Columns.Add(this.columnsubotomuvecani);
                this.columnsubotom = new DataColumn("subotom", typeof(decimal), "", MappingType.Element);
                this.columnsubotom.Caption = "subotom";
                this.columnsubotom.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsubotom.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsubotom.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsubotom.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsubotom.ExtendedProperties.Add("IsKey", "false");
                this.columnsubotom.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsubotom.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsubotom.ExtendedProperties.Add("Description", "subotom");
                this.columnsubotom.ExtendedProperties.Add("Length", "12");
                this.columnsubotom.ExtendedProperties.Add("Decimals", "2");
                this.columnsubotom.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsubotom.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsubotom.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsubotom.ExtendedProperties.Add("IsInReader", "true");
                this.columnsubotom.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsubotom.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsubotom.ExtendedProperties.Add("Deklarit.InternalName", "subotom");
                this.Columns.Add(this.columnsubotom);
                this.columnnedjeljomsatnica = new DataColumn("nedjeljomsatnica", typeof(decimal), "", MappingType.Element);
                this.columnnedjeljomsatnica.Caption = "nedjeljomsatnica";
                this.columnnedjeljomsatnica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnedjeljomsatnica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("IsKey", "false");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("Description", "nedjeljomsatnica");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("Length", "12");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("Decimals", "2");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("IsInReader", "true");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnedjeljomsatnica.ExtendedProperties.Add("Deklarit.InternalName", "nedjeljomsatnica");
                this.Columns.Add(this.columnnedjeljomsatnica);
                this.columnnedjeljomuvecani = new DataColumn("nedjeljomuvecani", typeof(decimal), "", MappingType.Element);
                this.columnnedjeljomuvecani.Caption = "nedjeljomuvecani";
                this.columnnedjeljomuvecani.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnedjeljomuvecani.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("IsKey", "false");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("DeklaritType", "int");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("Description", "nedjeljomuvecani");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("Length", "12");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("Decimals", "2");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("IsInReader", "true");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnedjeljomuvecani.ExtendedProperties.Add("Deklarit.InternalName", "nedjeljomuvecani");
                this.Columns.Add(this.columnnedjeljomuvecani);
                this.columnnedjeljom = new DataColumn("nedjeljom", typeof(decimal), "", MappingType.Element);
                this.columnnedjeljom.Caption = "nedjeljom";
                this.columnnedjeljom.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnedjeljom.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnedjeljom.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnedjeljom.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnnedjeljom.ExtendedProperties.Add("IsKey", "false");
                this.columnnedjeljom.ExtendedProperties.Add("ReadOnly", "true");
                this.columnnedjeljom.ExtendedProperties.Add("DeklaritType", "int");
                this.columnnedjeljom.ExtendedProperties.Add("Description", "nedjeljom");
                this.columnnedjeljom.ExtendedProperties.Add("Length", "12");
                this.columnnedjeljom.ExtendedProperties.Add("Decimals", "2");
                this.columnnedjeljom.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnnedjeljom.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnnedjeljom.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnnedjeljom.ExtendedProperties.Add("IsInReader", "true");
                this.columnnedjeljom.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnedjeljom.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnedjeljom.ExtendedProperties.Add("Deklarit.InternalName", "nedjeljom");
                this.Columns.Add(this.columnnedjeljom);
                this.columnblagdansatnica = new DataColumn("blagdansatnica", typeof(decimal), "", MappingType.Element);
                this.columnblagdansatnica.Caption = "blagdansatnica";
                this.columnblagdansatnica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnblagdansatnica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnblagdansatnica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnblagdansatnica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnblagdansatnica.ExtendedProperties.Add("IsKey", "false");
                this.columnblagdansatnica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnblagdansatnica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnblagdansatnica.ExtendedProperties.Add("Description", "blagdansatnica");
                this.columnblagdansatnica.ExtendedProperties.Add("Length", "12");
                this.columnblagdansatnica.ExtendedProperties.Add("Decimals", "2");
                this.columnblagdansatnica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnblagdansatnica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnblagdansatnica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnblagdansatnica.ExtendedProperties.Add("IsInReader", "true");
                this.columnblagdansatnica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnblagdansatnica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnblagdansatnica.ExtendedProperties.Add("Deklarit.InternalName", "blagdansatnica");
                this.Columns.Add(this.columnblagdansatnica);
                this.columnblagdanuvecani = new DataColumn("blagdanuvecani", typeof(decimal), "", MappingType.Element);
                this.columnblagdanuvecani.Caption = "blagdanuvecani";
                this.columnblagdanuvecani.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnblagdanuvecani.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnblagdanuvecani.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnblagdanuvecani.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnblagdanuvecani.ExtendedProperties.Add("IsKey", "false");
                this.columnblagdanuvecani.ExtendedProperties.Add("ReadOnly", "true");
                this.columnblagdanuvecani.ExtendedProperties.Add("DeklaritType", "int");
                this.columnblagdanuvecani.ExtendedProperties.Add("Description", "blagdanuvecani");
                this.columnblagdanuvecani.ExtendedProperties.Add("Length", "12");
                this.columnblagdanuvecani.ExtendedProperties.Add("Decimals", "2");
                this.columnblagdanuvecani.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnblagdanuvecani.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnblagdanuvecani.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnblagdanuvecani.ExtendedProperties.Add("IsInReader", "true");
                this.columnblagdanuvecani.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnblagdanuvecani.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnblagdanuvecani.ExtendedProperties.Add("Deklarit.InternalName", "blagdanuvecani");
                this.Columns.Add(this.columnblagdanuvecani);
                this.columnblagdan = new DataColumn("blagdan", typeof(decimal), "", MappingType.Element);
                this.columnblagdan.Caption = "blagdan";
                this.columnblagdan.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnblagdan.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnblagdan.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnblagdan.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnblagdan.ExtendedProperties.Add("IsKey", "false");
                this.columnblagdan.ExtendedProperties.Add("ReadOnly", "true");
                this.columnblagdan.ExtendedProperties.Add("DeklaritType", "int");
                this.columnblagdan.ExtendedProperties.Add("Description", "blagdan");
                this.columnblagdan.ExtendedProperties.Add("Length", "12");
                this.columnblagdan.ExtendedProperties.Add("Decimals", "2");
                this.columnblagdan.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnblagdan.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnblagdan.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnblagdan.ExtendedProperties.Add("IsInReader", "true");
                this.columnblagdan.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnblagdan.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnblagdan.ExtendedProperties.Add("Deklarit.InternalName", "blagdan");
                this.Columns.Add(this.columnblagdan);
                this.columndvokratnisatnica = new DataColumn("dvokratnisatnica", typeof(decimal), "", MappingType.Element);
                this.columndvokratnisatnica.Caption = "dvokratnisatnica";
                this.columndvokratnisatnica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columndvokratnisatnica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columndvokratnisatnica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columndvokratnisatnica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columndvokratnisatnica.ExtendedProperties.Add("IsKey", "false");
                this.columndvokratnisatnica.ExtendedProperties.Add("ReadOnly", "true");
                this.columndvokratnisatnica.ExtendedProperties.Add("DeklaritType", "int");
                this.columndvokratnisatnica.ExtendedProperties.Add("Description", "dvokratnisatnica");
                this.columndvokratnisatnica.ExtendedProperties.Add("Length", "12");
                this.columndvokratnisatnica.ExtendedProperties.Add("Decimals", "2");
                this.columndvokratnisatnica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columndvokratnisatnica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columndvokratnisatnica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columndvokratnisatnica.ExtendedProperties.Add("IsInReader", "true");
                this.columndvokratnisatnica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columndvokratnisatnica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columndvokratnisatnica.ExtendedProperties.Add("Deklarit.InternalName", "dvokratnisatnica");
                this.Columns.Add(this.columndvokratnisatnica);
                this.columndvokratniuvecani = new DataColumn("dvokratniuvecani", typeof(decimal), "", MappingType.Element);
                this.columndvokratniuvecani.Caption = "dvokratniuvecani";
                this.columndvokratniuvecani.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columndvokratniuvecani.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columndvokratniuvecani.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columndvokratniuvecani.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columndvokratniuvecani.ExtendedProperties.Add("IsKey", "false");
                this.columndvokratniuvecani.ExtendedProperties.Add("ReadOnly", "true");
                this.columndvokratniuvecani.ExtendedProperties.Add("DeklaritType", "int");
                this.columndvokratniuvecani.ExtendedProperties.Add("Description", "dvokratniuvecani");
                this.columndvokratniuvecani.ExtendedProperties.Add("Length", "12");
                this.columndvokratniuvecani.ExtendedProperties.Add("Decimals", "2");
                this.columndvokratniuvecani.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columndvokratniuvecani.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columndvokratniuvecani.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columndvokratniuvecani.ExtendedProperties.Add("IsInReader", "true");
                this.columndvokratniuvecani.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columndvokratniuvecani.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columndvokratniuvecani.ExtendedProperties.Add("Deklarit.InternalName", "dvokratniuvecani");
                this.Columns.Add(this.columndvokratniuvecani);
                this.columndvokratni = new DataColumn("dvokratni", typeof(decimal), "", MappingType.Element);
                this.columndvokratni.Caption = "dvokratni";
                this.columndvokratni.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columndvokratni.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columndvokratni.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columndvokratni.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columndvokratni.ExtendedProperties.Add("IsKey", "false");
                this.columndvokratni.ExtendedProperties.Add("ReadOnly", "true");
                this.columndvokratni.ExtendedProperties.Add("DeklaritType", "int");
                this.columndvokratni.ExtendedProperties.Add("Description", "dvokratni");
                this.columndvokratni.ExtendedProperties.Add("Length", "12");
                this.columndvokratni.ExtendedProperties.Add("Decimals", "2");
                this.columndvokratni.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columndvokratni.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columndvokratni.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columndvokratni.ExtendedProperties.Add("IsInReader", "true");
                this.columndvokratni.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columndvokratni.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columndvokratni.ExtendedProperties.Add("Deklarit.InternalName", "dvokratni");
                this.Columns.Add(this.columndvokratni);
                this.columnDODATNIKOEFICIJENT = new DataColumn("DODATNIKOEFICIJENT", typeof(decimal), "", MappingType.Element);
                this.columnDODATNIKOEFICIJENT.Caption = "DODATNIKOEFICIJENT";
                this.columnDODATNIKOEFICIJENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("IsKey", "false");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Description", "DODATNIKOEFICIJENT");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Length", "12");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Decimals", "8");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("DomainType", "PUNODECIMALA");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.InternalName", "DODATNIKOEFICIJENT");
                this.Columns.Add(this.columnDODATNIKOEFICIJENT);
                this.columnKOMBINACIJAIZNOS = new DataColumn("KOMBINACIJAIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnKOMBINACIJAIZNOS.Caption = "KOMBINACIJAIZNOS";
                this.columnKOMBINACIJAIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("Description", "KOMBINACIJAIZNOS");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOMBINACIJAIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "KOMBINACIJAIZNOS");
                this.Columns.Add(this.columnKOMBINACIJAIZNOS);
                this.columnKOMBINACIJAPOSTOTAK = new DataColumn("KOMBINACIJAPOSTOTAK", typeof(decimal), "", MappingType.Element);
                this.columnKOMBINACIJAPOSTOTAK.Caption = "KOMBINACIJAPOSTOTAK";
                this.columnKOMBINACIJAPOSTOTAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("IsKey", "false");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("Description", "KOMBINACIJAPOSTOTAK");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("Length", "12");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("Decimals", "2");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOMBINACIJAPOSTOTAK.ExtendedProperties.Add("Deklarit.InternalName", "KOMBINACIJAPOSTOTAK");
                this.Columns.Add(this.columnKOMBINACIJAPOSTOTAK);
                this.columnKOMBINACIJAIZNOS2 = new DataColumn("KOMBINACIJAIZNOS2", typeof(decimal), "", MappingType.Element);
                this.columnKOMBINACIJAIZNOS2.Caption = "KOMBINACIJAIZNO S2";
                this.columnKOMBINACIJAIZNOS2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("IsKey", "false");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("Description", "KOMBINACIJAIZNO S2");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("Length", "12");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("Decimals", "2");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOMBINACIJAIZNOS2.ExtendedProperties.Add("Deklarit.InternalName", "KOMBINACIJAIZNOS2");
                this.Columns.Add(this.columnKOMBINACIJAIZNOS2);
                this.columnKOMBINACIJAPOSTOTAK2 = new DataColumn("KOMBINACIJAPOSTOTAK2", typeof(decimal), "", MappingType.Element);
                this.columnKOMBINACIJAPOSTOTAK2.Caption = "KOMBINACIJAPOSTOTA K2";
                this.columnKOMBINACIJAPOSTOTAK2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("IsKey", "false");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("Description", "KOMBINACIJAPOSTOTA K2");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("Length", "12");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("Decimals", "2");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOMBINACIJAPOSTOTAK2.ExtendedProperties.Add("Deklarit.InternalName", "KOMBINACIJAPOSTOTAK2");
                this.Columns.Add(this.columnKOMBINACIJAPOSTOTAK2);
                this.columnsposebni1iznos = new DataColumn("sposebni1iznos", typeof(decimal), "", MappingType.Element);
                this.columnsposebni1iznos.Caption = "sposebni1iznos";
                this.columnsposebni1iznos.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsposebni1iznos.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsposebni1iznos.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsposebni1iznos.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsposebni1iznos.ExtendedProperties.Add("IsKey", "false");
                this.columnsposebni1iznos.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsposebni1iznos.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsposebni1iznos.ExtendedProperties.Add("Description", "sposebni1iznos");
                this.columnsposebni1iznos.ExtendedProperties.Add("Length", "12");
                this.columnsposebni1iznos.ExtendedProperties.Add("Decimals", "2");
                this.columnsposebni1iznos.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsposebni1iznos.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsposebni1iznos.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsposebni1iznos.ExtendedProperties.Add("IsInReader", "true");
                this.columnsposebni1iznos.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsposebni1iznos.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsposebni1iznos.ExtendedProperties.Add("Deklarit.InternalName", "sposebni1iznos");
                this.Columns.Add(this.columnsposebni1iznos);
                this.columnsposebni1satnica = new DataColumn("sposebni1satnica", typeof(decimal), "", MappingType.Element);
                this.columnsposebni1satnica.Caption = "sposebni1satnica";
                this.columnsposebni1satnica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsposebni1satnica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsposebni1satnica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsposebni1satnica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsposebni1satnica.ExtendedProperties.Add("IsKey", "false");
                this.columnsposebni1satnica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsposebni1satnica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsposebni1satnica.ExtendedProperties.Add("Description", "sposebni1satnica");
                this.columnsposebni1satnica.ExtendedProperties.Add("Length", "12");
                this.columnsposebni1satnica.ExtendedProperties.Add("Decimals", "2");
                this.columnsposebni1satnica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsposebni1satnica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsposebni1satnica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsposebni1satnica.ExtendedProperties.Add("IsInReader", "true");
                this.columnsposebni1satnica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsposebni1satnica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsposebni1satnica.ExtendedProperties.Add("Deklarit.InternalName", "sposebni1satnica");
                this.Columns.Add(this.columnsposebni1satnica);
                this.columnsposebni1sati = new DataColumn("sposebni1sati", typeof(decimal), "", MappingType.Element);
                this.columnsposebni1sati.Caption = "sposebni1sati";
                this.columnsposebni1sati.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsposebni1sati.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsposebni1sati.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsposebni1sati.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsposebni1sati.ExtendedProperties.Add("IsKey", "false");
                this.columnsposebni1sati.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsposebni1sati.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsposebni1sati.ExtendedProperties.Add("Description", "sposebni1sati");
                this.columnsposebni1sati.ExtendedProperties.Add("Length", "12");
                this.columnsposebni1sati.ExtendedProperties.Add("Decimals", "2");
                this.columnsposebni1sati.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsposebni1sati.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsposebni1sati.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsposebni1sati.ExtendedProperties.Add("IsInReader", "true");
                this.columnsposebni1sati.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsposebni1sati.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsposebni1sati.ExtendedProperties.Add("Deklarit.InternalName", "sposebni1sati");
                this.Columns.Add(this.columnsposebni1sati);
                this.columnsposebni2iznos = new DataColumn("sposebni2iznos", typeof(decimal), "", MappingType.Element);
                this.columnsposebni2iznos.Caption = "sposebni2iznos";
                this.columnsposebni2iznos.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsposebni2iznos.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsposebni2iznos.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsposebni2iznos.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsposebni2iznos.ExtendedProperties.Add("IsKey", "false");
                this.columnsposebni2iznos.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsposebni2iznos.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsposebni2iznos.ExtendedProperties.Add("Description", "sposebni2iznos");
                this.columnsposebni2iznos.ExtendedProperties.Add("Length", "12");
                this.columnsposebni2iznos.ExtendedProperties.Add("Decimals", "2");
                this.columnsposebni2iznos.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsposebni2iznos.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsposebni2iznos.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsposebni2iznos.ExtendedProperties.Add("IsInReader", "true");
                this.columnsposebni2iznos.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsposebni2iznos.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsposebni2iznos.ExtendedProperties.Add("Deklarit.InternalName", "sposebni2iznos");
                this.Columns.Add(this.columnsposebni2iznos);
                this.columnsposebni2satnica = new DataColumn("sposebni2satnica", typeof(decimal), "", MappingType.Element);
                this.columnsposebni2satnica.Caption = "sposebni2satnica";
                this.columnsposebni2satnica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsposebni2satnica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsposebni2satnica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsposebni2satnica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsposebni2satnica.ExtendedProperties.Add("IsKey", "false");
                this.columnsposebni2satnica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsposebni2satnica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsposebni2satnica.ExtendedProperties.Add("Description", "sposebni2satnica");
                this.columnsposebni2satnica.ExtendedProperties.Add("Length", "12");
                this.columnsposebni2satnica.ExtendedProperties.Add("Decimals", "2");
                this.columnsposebni2satnica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsposebni2satnica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsposebni2satnica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsposebni2satnica.ExtendedProperties.Add("IsInReader", "true");
                this.columnsposebni2satnica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsposebni2satnica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsposebni2satnica.ExtendedProperties.Add("Deklarit.InternalName", "sposebni2satnica");
                this.Columns.Add(this.columnsposebni2satnica);
                this.columnsposebni2sati = new DataColumn("sposebni2sati", typeof(decimal), "", MappingType.Element);
                this.columnsposebni2sati.Caption = "sposebni2sati";
                this.columnsposebni2sati.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsposebni2sati.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsposebni2sati.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsposebni2sati.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsposebni2sati.ExtendedProperties.Add("IsKey", "false");
                this.columnsposebni2sati.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsposebni2sati.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsposebni2sati.ExtendedProperties.Add("Description", "sposebni2sati");
                this.columnsposebni2sati.ExtendedProperties.Add("Length", "12");
                this.columnsposebni2sati.ExtendedProperties.Add("Decimals", "2");
                this.columnsposebni2sati.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsposebni2sati.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsposebni2sati.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsposebni2sati.ExtendedProperties.Add("IsInReader", "true");
                this.columnsposebni2sati.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsposebni2sati.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsposebni2sati.ExtendedProperties.Add("Deklarit.InternalName", "sposebni2sati");
                this.Columns.Add(this.columnsposebni2sati);
                this.columnsposebni3iznos = new DataColumn("sposebni3iznos", typeof(decimal), "", MappingType.Element);
                this.columnsposebni3iznos.Caption = "sposebni3iznos";
                this.columnsposebni3iznos.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsposebni3iznos.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsposebni3iznos.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsposebni3iznos.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsposebni3iznos.ExtendedProperties.Add("IsKey", "false");
                this.columnsposebni3iznos.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsposebni3iznos.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsposebni3iznos.ExtendedProperties.Add("Description", "sposebni3iznos");
                this.columnsposebni3iznos.ExtendedProperties.Add("Length", "12");
                this.columnsposebni3iznos.ExtendedProperties.Add("Decimals", "2");
                this.columnsposebni3iznos.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsposebni3iznos.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsposebni3iznos.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsposebni3iznos.ExtendedProperties.Add("IsInReader", "true");
                this.columnsposebni3iznos.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsposebni3iznos.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsposebni3iznos.ExtendedProperties.Add("Deklarit.InternalName", "sposebni3iznos");
                this.Columns.Add(this.columnsposebni3iznos);
                this.columnsposebni3satnica = new DataColumn("sposebni3satnica", typeof(decimal), "", MappingType.Element);
                this.columnsposebni3satnica.Caption = "sposebni3satnica";
                this.columnsposebni3satnica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsposebni3satnica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsposebni3satnica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsposebni3satnica.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsposebni3satnica.ExtendedProperties.Add("IsKey", "false");
                this.columnsposebni3satnica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsposebni3satnica.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsposebni3satnica.ExtendedProperties.Add("Description", "sposebni3satnica");
                this.columnsposebni3satnica.ExtendedProperties.Add("Length", "12");
                this.columnsposebni3satnica.ExtendedProperties.Add("Decimals", "2");
                this.columnsposebni3satnica.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsposebni3satnica.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsposebni3satnica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsposebni3satnica.ExtendedProperties.Add("IsInReader", "true");
                this.columnsposebni3satnica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsposebni3satnica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsposebni3satnica.ExtendedProperties.Add("Deklarit.InternalName", "sposebni3satnica");
                this.Columns.Add(this.columnsposebni3satnica);
                this.columnsposebni3sati = new DataColumn("sposebni3sati", typeof(decimal), "", MappingType.Element);
                this.columnsposebni3sati.Caption = "sposebni3sati";
                this.columnsposebni3sati.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnsposebni3sati.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnsposebni3sati.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnsposebni3sati.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnsposebni3sati.ExtendedProperties.Add("IsKey", "false");
                this.columnsposebni3sati.ExtendedProperties.Add("ReadOnly", "true");
                this.columnsposebni3sati.ExtendedProperties.Add("DeklaritType", "int");
                this.columnsposebni3sati.ExtendedProperties.Add("Description", "sposebni3sati");
                this.columnsposebni3sati.ExtendedProperties.Add("Length", "12");
                this.columnsposebni3sati.ExtendedProperties.Add("Decimals", "2");
                this.columnsposebni3sati.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnsposebni3sati.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnsposebni3sati.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnsposebni3sati.ExtendedProperties.Add("IsInReader", "true");
                this.columnsposebni3sati.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnsposebni3sati.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnsposebni3sati.ExtendedProperties.Add("Deklarit.InternalName", "sposebni3sati");
                this.Columns.Add(this.columnsposebni3sati);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "s_od_priprema");
                this.ExtendedProperties.Add("Description", "S_OD_PRIPREMA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnimeprezime = this.Columns["imeprezime"];
                this.columnNAZIVRADNOMJESTO = this.Columns["NAZIVRADNOMJESTO"];
                this.columnosnovnaplaca = this.Columns["osnovnaplaca"];
                this.columnsmjenskiiznos = this.Columns["smjenskiiznos"];
                this.columnsmjenskisatnica = this.Columns["smjenskisatnica"];
                this.columnsmjenskisati = this.Columns["smjenskisati"];
                this.columnposebni1iznos = this.Columns["posebni1iznos"];
                this.columnposebni1satnica = this.Columns["posebni1satnica"];
                this.columnposebni1sati = this.Columns["posebni1sati"];
                this.columnposebni2iznos = this.Columns["posebni2iznos"];
                this.columnposebni2satnica = this.Columns["posebni2satnica"];
                this.columnposebni2sati = this.Columns["posebni2sati"];
                this.columnposebni3iznos = this.Columns["posebni3iznos"];
                this.columnposebni3satnica = this.Columns["posebni3satnica"];
                this.columnposebni3sati = this.Columns["posebni3sati"];
                this.columnnocnisatnica = this.Columns["nocnisatnica"];
                this.columnnocniuvecani = this.Columns["nocniuvecani"];
                this.columnnocni = this.Columns["nocni"];
                this.columnprekovremenisatnica = this.Columns["prekovremenisatnica"];
                this.columnprekovremeniuvecani = this.Columns["prekovremeniuvecani"];
                this.columnprekovremeni = this.Columns["prekovremeni"];
                this.columnsubotomsatnica = this.Columns["subotomsatnica"];
                this.columnsubotomuvecani = this.Columns["subotomuvecani"];
                this.columnsubotom = this.Columns["subotom"];
                this.columnnedjeljomsatnica = this.Columns["nedjeljomsatnica"];
                this.columnnedjeljomuvecani = this.Columns["nedjeljomuvecani"];
                this.columnnedjeljom = this.Columns["nedjeljom"];
                this.columnblagdansatnica = this.Columns["blagdansatnica"];
                this.columnblagdanuvecani = this.Columns["blagdanuvecani"];
                this.columnblagdan = this.Columns["blagdan"];
                this.columndvokratnisatnica = this.Columns["dvokratnisatnica"];
                this.columndvokratniuvecani = this.Columns["dvokratniuvecani"];
                this.columndvokratni = this.Columns["dvokratni"];
                this.columnDODATNIKOEFICIJENT = this.Columns["DODATNIKOEFICIJENT"];
                this.columnKOMBINACIJAIZNOS = this.Columns["KOMBINACIJAIZNOS"];
                this.columnKOMBINACIJAPOSTOTAK = this.Columns["KOMBINACIJAPOSTOTAK"];
                this.columnKOMBINACIJAIZNOS2 = this.Columns["KOMBINACIJAIZNOS2"];
                this.columnKOMBINACIJAPOSTOTAK2 = this.Columns["KOMBINACIJAPOSTOTAK2"];
                this.columnsposebni1iznos = this.Columns["sposebni1iznos"];
                this.columnsposebni1satnica = this.Columns["sposebni1satnica"];
                this.columnsposebni1sati = this.Columns["sposebni1sati"];
                this.columnsposebni2iznos = this.Columns["sposebni2iznos"];
                this.columnsposebni2satnica = this.Columns["sposebni2satnica"];
                this.columnsposebni2sati = this.Columns["sposebni2sati"];
                this.columnsposebni3iznos = this.Columns["sposebni3iznos"];
                this.columnsposebni3satnica = this.Columns["sposebni3satnica"];
                this.columnsposebni3sati = this.Columns["sposebni3sati"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new s_od_pripremaDataSet.s_od_pripremaRow(builder);
            }

            public s_od_pripremaDataSet.s_od_pripremaRow News_od_pripremaRow()
            {
                return (s_od_pripremaDataSet.s_od_pripremaRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.s_od_pripremaRowChanged != null)
                {
                    s_od_pripremaDataSet.s_od_pripremaRowChangeEventHandler handler = this.s_od_pripremaRowChanged;
                    if (handler != null)
                    {
                        handler(this, new s_od_pripremaDataSet.s_od_pripremaRowChangeEvent((s_od_pripremaDataSet.s_od_pripremaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.s_od_pripremaRowChanging != null)
                {
                    s_od_pripremaDataSet.s_od_pripremaRowChangeEventHandler handler = this.s_od_pripremaRowChanging;
                    if (handler != null)
                    {
                        handler(this, new s_od_pripremaDataSet.s_od_pripremaRowChangeEvent((s_od_pripremaDataSet.s_od_pripremaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.s_od_pripremaRowDeleted != null)
                {
                    s_od_pripremaDataSet.s_od_pripremaRowChangeEventHandler handler = this.s_od_pripremaRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new s_od_pripremaDataSet.s_od_pripremaRowChangeEvent((s_od_pripremaDataSet.s_od_pripremaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.s_od_pripremaRowDeleting != null)
                {
                    s_od_pripremaDataSet.s_od_pripremaRowChangeEventHandler handler = this.s_od_pripremaRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new s_od_pripremaDataSet.s_od_pripremaRowChangeEvent((s_od_pripremaDataSet.s_od_pripremaRow) e.Row, e.Action));
                    }
                }
            }

            public void Removes_od_pripremaRow(s_od_pripremaDataSet.s_od_pripremaRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn blagdanColumn
            {
                get
                {
                    return this.columnblagdan;
                }
            }

            public DataColumn blagdansatnicaColumn
            {
                get
                {
                    return this.columnblagdansatnica;
                }
            }

            public DataColumn blagdanuvecaniColumn
            {
                get
                {
                    return this.columnblagdanuvecani;
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

            public DataColumn DODATNIKOEFICIJENTColumn
            {
                get
                {
                    return this.columnDODATNIKOEFICIJENT;
                }
            }

            public DataColumn dvokratniColumn
            {
                get
                {
                    return this.columndvokratni;
                }
            }

            public DataColumn dvokratnisatnicaColumn
            {
                get
                {
                    return this.columndvokratnisatnica;
                }
            }

            public DataColumn dvokratniuvecaniColumn
            {
                get
                {
                    return this.columndvokratniuvecani;
                }
            }

            public DataColumn imeprezimeColumn
            {
                get
                {
                    return this.columnimeprezime;
                }
            }

            public s_od_pripremaDataSet.s_od_pripremaRow this[int index]
            {
                get
                {
                    return (s_od_pripremaDataSet.s_od_pripremaRow) this.Rows[index];
                }
            }

            public DataColumn KOMBINACIJAIZNOS2Column
            {
                get
                {
                    return this.columnKOMBINACIJAIZNOS2;
                }
            }

            public DataColumn KOMBINACIJAIZNOSColumn
            {
                get
                {
                    return this.columnKOMBINACIJAIZNOS;
                }
            }

            public DataColumn KOMBINACIJAPOSTOTAK2Column
            {
                get
                {
                    return this.columnKOMBINACIJAPOSTOTAK2;
                }
            }

            public DataColumn KOMBINACIJAPOSTOTAKColumn
            {
                get
                {
                    return this.columnKOMBINACIJAPOSTOTAK;
                }
            }

            public DataColumn NAZIVRADNOMJESTOColumn
            {
                get
                {
                    return this.columnNAZIVRADNOMJESTO;
                }
            }

            public DataColumn nedjeljomColumn
            {
                get
                {
                    return this.columnnedjeljom;
                }
            }

            public DataColumn nedjeljomsatnicaColumn
            {
                get
                {
                    return this.columnnedjeljomsatnica;
                }
            }

            public DataColumn nedjeljomuvecaniColumn
            {
                get
                {
                    return this.columnnedjeljomuvecani;
                }
            }

            public DataColumn nocniColumn
            {
                get
                {
                    return this.columnnocni;
                }
            }

            public DataColumn nocnisatnicaColumn
            {
                get
                {
                    return this.columnnocnisatnica;
                }
            }

            public DataColumn nocniuvecaniColumn
            {
                get
                {
                    return this.columnnocniuvecani;
                }
            }

            public DataColumn osnovnaplacaColumn
            {
                get
                {
                    return this.columnosnovnaplaca;
                }
            }

            public DataColumn posebni1iznosColumn
            {
                get
                {
                    return this.columnposebni1iznos;
                }
            }

            public DataColumn posebni1satiColumn
            {
                get
                {
                    return this.columnposebni1sati;
                }
            }

            public DataColumn posebni1satnicaColumn
            {
                get
                {
                    return this.columnposebni1satnica;
                }
            }

            public DataColumn posebni2iznosColumn
            {
                get
                {
                    return this.columnposebni2iznos;
                }
            }

            public DataColumn posebni2satiColumn
            {
                get
                {
                    return this.columnposebni2sati;
                }
            }

            public DataColumn posebni2satnicaColumn
            {
                get
                {
                    return this.columnposebni2satnica;
                }
            }

            public DataColumn posebni3iznosColumn
            {
                get
                {
                    return this.columnposebni3iznos;
                }
            }

            public DataColumn posebni3satiColumn
            {
                get
                {
                    return this.columnposebni3sati;
                }
            }

            public DataColumn posebni3satnicaColumn
            {
                get
                {
                    return this.columnposebni3satnica;
                }
            }

            public DataColumn prekovremeniColumn
            {
                get
                {
                    return this.columnprekovremeni;
                }
            }

            public DataColumn prekovremenisatnicaColumn
            {
                get
                {
                    return this.columnprekovremenisatnica;
                }
            }

            public DataColumn prekovremeniuvecaniColumn
            {
                get
                {
                    return this.columnprekovremeniuvecani;
                }
            }

            public DataColumn smjenskiiznosColumn
            {
                get
                {
                    return this.columnsmjenskiiznos;
                }
            }

            public DataColumn smjenskisatiColumn
            {
                get
                {
                    return this.columnsmjenskisati;
                }
            }

            public DataColumn smjenskisatnicaColumn
            {
                get
                {
                    return this.columnsmjenskisatnica;
                }
            }

            public DataColumn sposebni1iznosColumn
            {
                get
                {
                    return this.columnsposebni1iznos;
                }
            }

            public DataColumn sposebni1satiColumn
            {
                get
                {
                    return this.columnsposebni1sati;
                }
            }

            public DataColumn sposebni1satnicaColumn
            {
                get
                {
                    return this.columnsposebni1satnica;
                }
            }

            public DataColumn sposebni2iznosColumn
            {
                get
                {
                    return this.columnsposebni2iznos;
                }
            }

            public DataColumn sposebni2satiColumn
            {
                get
                {
                    return this.columnsposebni2sati;
                }
            }

            public DataColumn sposebni2satnicaColumn
            {
                get
                {
                    return this.columnsposebni2satnica;
                }
            }

            public DataColumn sposebni3iznosColumn
            {
                get
                {
                    return this.columnsposebni3iznos;
                }
            }

            public DataColumn sposebni3satiColumn
            {
                get
                {
                    return this.columnsposebni3sati;
                }
            }

            public DataColumn sposebni3satnicaColumn
            {
                get
                {
                    return this.columnsposebni3satnica;
                }
            }

            public DataColumn subotomColumn
            {
                get
                {
                    return this.columnsubotom;
                }
            }

            public DataColumn subotomsatnicaColumn
            {
                get
                {
                    return this.columnsubotomsatnica;
                }
            }

            public DataColumn subotomuvecaniColumn
            {
                get
                {
                    return this.columnsubotomuvecani;
                }
            }
        }

        public class s_od_pripremaRow : DataRow
        {
            private s_od_pripremaDataSet.s_od_pripremaDataTable tables_od_priprema;

            internal s_od_pripremaRow(DataRowBuilder rb) : base(rb)
            {
                this.tables_od_priprema = (s_od_pripremaDataSet.s_od_pripremaDataTable) this.Table;
            }

            public bool IsblagdanNull()
            {
                return this.IsNull(this.tables_od_priprema.blagdanColumn);
            }

            public bool IsblagdansatnicaNull()
            {
                return this.IsNull(this.tables_od_priprema.blagdansatnicaColumn);
            }

            public bool IsblagdanuvecaniNull()
            {
                return this.IsNull(this.tables_od_priprema.blagdanuvecaniColumn);
            }

            public bool IsDODATNIKOEFICIJENTNull()
            {
                return this.IsNull(this.tables_od_priprema.DODATNIKOEFICIJENTColumn);
            }

            public bool IsdvokratniNull()
            {
                return this.IsNull(this.tables_od_priprema.dvokratniColumn);
            }

            public bool IsdvokratnisatnicaNull()
            {
                return this.IsNull(this.tables_od_priprema.dvokratnisatnicaColumn);
            }

            public bool IsdvokratniuvecaniNull()
            {
                return this.IsNull(this.tables_od_priprema.dvokratniuvecaniColumn);
            }

            public bool IsimeprezimeNull()
            {
                return this.IsNull(this.tables_od_priprema.imeprezimeColumn);
            }

            public bool IsKOMBINACIJAIZNOS2Null()
            {
                return this.IsNull(this.tables_od_priprema.KOMBINACIJAIZNOS2Column);
            }

            public bool IsKOMBINACIJAIZNOSNull()
            {
                return this.IsNull(this.tables_od_priprema.KOMBINACIJAIZNOSColumn);
            }

            public bool IsKOMBINACIJAPOSTOTAK2Null()
            {
                return this.IsNull(this.tables_od_priprema.KOMBINACIJAPOSTOTAK2Column);
            }

            public bool IsKOMBINACIJAPOSTOTAKNull()
            {
                return this.IsNull(this.tables_od_priprema.KOMBINACIJAPOSTOTAKColumn);
            }

            public bool IsNAZIVRADNOMJESTONull()
            {
                return this.IsNull(this.tables_od_priprema.NAZIVRADNOMJESTOColumn);
            }

            public bool IsnedjeljomNull()
            {
                return this.IsNull(this.tables_od_priprema.nedjeljomColumn);
            }

            public bool IsnedjeljomsatnicaNull()
            {
                return this.IsNull(this.tables_od_priprema.nedjeljomsatnicaColumn);
            }

            public bool IsnedjeljomuvecaniNull()
            {
                return this.IsNull(this.tables_od_priprema.nedjeljomuvecaniColumn);
            }

            public bool IsnocniNull()
            {
                return this.IsNull(this.tables_od_priprema.nocniColumn);
            }

            public bool IsnocnisatnicaNull()
            {
                return this.IsNull(this.tables_od_priprema.nocnisatnicaColumn);
            }

            public bool IsnocniuvecaniNull()
            {
                return this.IsNull(this.tables_od_priprema.nocniuvecaniColumn);
            }

            public bool IsosnovnaplacaNull()
            {
                return this.IsNull(this.tables_od_priprema.osnovnaplacaColumn);
            }

            public bool Isposebni1iznosNull()
            {
                return this.IsNull(this.tables_od_priprema.posebni1iznosColumn);
            }

            public bool Isposebni1satiNull()
            {
                return this.IsNull(this.tables_od_priprema.posebni1satiColumn);
            }

            public bool Isposebni1satnicaNull()
            {
                return this.IsNull(this.tables_od_priprema.posebni1satnicaColumn);
            }

            public bool Isposebni2iznosNull()
            {
                return this.IsNull(this.tables_od_priprema.posebni2iznosColumn);
            }

            public bool Isposebni2satiNull()
            {
                return this.IsNull(this.tables_od_priprema.posebni2satiColumn);
            }

            public bool Isposebni2satnicaNull()
            {
                return this.IsNull(this.tables_od_priprema.posebni2satnicaColumn);
            }

            public bool Isposebni3iznosNull()
            {
                return this.IsNull(this.tables_od_priprema.posebni3iznosColumn);
            }

            public bool Isposebni3satiNull()
            {
                return this.IsNull(this.tables_od_priprema.posebni3satiColumn);
            }

            public bool Isposebni3satnicaNull()
            {
                return this.IsNull(this.tables_od_priprema.posebni3satnicaColumn);
            }

            public bool IsprekovremeniNull()
            {
                return this.IsNull(this.tables_od_priprema.prekovremeniColumn);
            }

            public bool IsprekovremenisatnicaNull()
            {
                return this.IsNull(this.tables_od_priprema.prekovremenisatnicaColumn);
            }

            public bool IsprekovremeniuvecaniNull()
            {
                return this.IsNull(this.tables_od_priprema.prekovremeniuvecaniColumn);
            }

            public bool IssmjenskiiznosNull()
            {
                return this.IsNull(this.tables_od_priprema.smjenskiiznosColumn);
            }

            public bool IssmjenskisatiNull()
            {
                return this.IsNull(this.tables_od_priprema.smjenskisatiColumn);
            }

            public bool IssmjenskisatnicaNull()
            {
                return this.IsNull(this.tables_od_priprema.smjenskisatnicaColumn);
            }

            public bool Issposebni1iznosNull()
            {
                return this.IsNull(this.tables_od_priprema.sposebni1iznosColumn);
            }

            public bool Issposebni1satiNull()
            {
                return this.IsNull(this.tables_od_priprema.sposebni1satiColumn);
            }

            public bool Issposebni1satnicaNull()
            {
                return this.IsNull(this.tables_od_priprema.sposebni1satnicaColumn);
            }

            public bool Issposebni2iznosNull()
            {
                return this.IsNull(this.tables_od_priprema.sposebni2iznosColumn);
            }

            public bool Issposebni2satiNull()
            {
                return this.IsNull(this.tables_od_priprema.sposebni2satiColumn);
            }

            public bool Issposebni2satnicaNull()
            {
                return this.IsNull(this.tables_od_priprema.sposebni2satnicaColumn);
            }

            public bool Issposebni3iznosNull()
            {
                return this.IsNull(this.tables_od_priprema.sposebni3iznosColumn);
            }

            public bool Issposebni3satiNull()
            {
                return this.IsNull(this.tables_od_priprema.sposebni3satiColumn);
            }

            public bool Issposebni3satnicaNull()
            {
                return this.IsNull(this.tables_od_priprema.sposebni3satnicaColumn);
            }

            public bool IssubotomNull()
            {
                return this.IsNull(this.tables_od_priprema.subotomColumn);
            }

            public bool IssubotomsatnicaNull()
            {
                return this.IsNull(this.tables_od_priprema.subotomsatnicaColumn);
            }

            public bool IssubotomuvecaniNull()
            {
                return this.IsNull(this.tables_od_priprema.subotomuvecaniColumn);
            }

            public void SetblagdanNull()
            {
                this[this.tables_od_priprema.blagdanColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetblagdansatnicaNull()
            {
                this[this.tables_od_priprema.blagdansatnicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetblagdanuvecaniNull()
            {
                this[this.tables_od_priprema.blagdanuvecaniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDODATNIKOEFICIJENTNull()
            {
                this[this.tables_od_priprema.DODATNIKOEFICIJENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetdvokratniNull()
            {
                this[this.tables_od_priprema.dvokratniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetdvokratnisatnicaNull()
            {
                this[this.tables_od_priprema.dvokratnisatnicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetdvokratniuvecaniNull()
            {
                this[this.tables_od_priprema.dvokratniuvecaniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetimeprezimeNull()
            {
                this[this.tables_od_priprema.imeprezimeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOMBINACIJAIZNOS2Null()
            {
                this[this.tables_od_priprema.KOMBINACIJAIZNOS2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOMBINACIJAIZNOSNull()
            {
                this[this.tables_od_priprema.KOMBINACIJAIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOMBINACIJAPOSTOTAK2Null()
            {
                this[this.tables_od_priprema.KOMBINACIJAPOSTOTAK2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOMBINACIJAPOSTOTAKNull()
            {
                this[this.tables_od_priprema.KOMBINACIJAPOSTOTAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVRADNOMJESTONull()
            {
                this[this.tables_od_priprema.NAZIVRADNOMJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnedjeljomNull()
            {
                this[this.tables_od_priprema.nedjeljomColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnedjeljomsatnicaNull()
            {
                this[this.tables_od_priprema.nedjeljomsatnicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnedjeljomuvecaniNull()
            {
                this[this.tables_od_priprema.nedjeljomuvecaniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnocniNull()
            {
                this[this.tables_od_priprema.nocniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnocnisatnicaNull()
            {
                this[this.tables_od_priprema.nocnisatnicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnocniuvecaniNull()
            {
                this[this.tables_od_priprema.nocniuvecaniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetosnovnaplacaNull()
            {
                this[this.tables_od_priprema.osnovnaplacaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setposebni1iznosNull()
            {
                this[this.tables_od_priprema.posebni1iznosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setposebni1satiNull()
            {
                this[this.tables_od_priprema.posebni1satiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setposebni1satnicaNull()
            {
                this[this.tables_od_priprema.posebni1satnicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setposebni2iznosNull()
            {
                this[this.tables_od_priprema.posebni2iznosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setposebni2satiNull()
            {
                this[this.tables_od_priprema.posebni2satiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setposebni2satnicaNull()
            {
                this[this.tables_od_priprema.posebni2satnicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setposebni3iznosNull()
            {
                this[this.tables_od_priprema.posebni3iznosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setposebni3satiNull()
            {
                this[this.tables_od_priprema.posebni3satiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setposebni3satnicaNull()
            {
                this[this.tables_od_priprema.posebni3satnicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetprekovremeniNull()
            {
                this[this.tables_od_priprema.prekovremeniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetprekovremenisatnicaNull()
            {
                this[this.tables_od_priprema.prekovremenisatnicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetprekovremeniuvecaniNull()
            {
                this[this.tables_od_priprema.prekovremeniuvecaniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetsmjenskiiznosNull()
            {
                this[this.tables_od_priprema.smjenskiiznosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetsmjenskisatiNull()
            {
                this[this.tables_od_priprema.smjenskisatiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetsmjenskisatnicaNull()
            {
                this[this.tables_od_priprema.smjenskisatnicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsposebni1iznosNull()
            {
                this[this.tables_od_priprema.sposebni1iznosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsposebni1satiNull()
            {
                this[this.tables_od_priprema.sposebni1satiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsposebni1satnicaNull()
            {
                this[this.tables_od_priprema.sposebni1satnicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsposebni2iznosNull()
            {
                this[this.tables_od_priprema.sposebni2iznosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsposebni2satiNull()
            {
                this[this.tables_od_priprema.sposebni2satiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsposebni2satnicaNull()
            {
                this[this.tables_od_priprema.sposebni2satnicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsposebni3iznosNull()
            {
                this[this.tables_od_priprema.sposebni3iznosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsposebni3satiNull()
            {
                this[this.tables_od_priprema.sposebni3satiColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void Setsposebni3satnicaNull()
            {
                this[this.tables_od_priprema.sposebni3satnicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetsubotomNull()
            {
                this[this.tables_od_priprema.subotomColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetsubotomsatnicaNull()
            {
                this[this.tables_od_priprema.subotomsatnicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetsubotomuvecaniNull()
            {
                this[this.tables_od_priprema.subotomuvecaniColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal blagdan
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.blagdanColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.blagdanColumn] = value;
                }
            }

            public decimal blagdansatnica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.blagdansatnicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.blagdansatnicaColumn] = value;
                }
            }

            public decimal blagdanuvecani
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.blagdanuvecaniColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.blagdanuvecaniColumn] = value;
                }
            }

            public decimal DODATNIKOEFICIJENT
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.DODATNIKOEFICIJENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.DODATNIKOEFICIJENTColumn] = value;
                }
            }

            public decimal dvokratni
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.dvokratniColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.dvokratniColumn] = value;
                }
            }

            public decimal dvokratnisatnica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.dvokratnisatnicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.dvokratnisatnicaColumn] = value;
                }
            }

            public decimal dvokratniuvecani
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.dvokratniuvecaniColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.dvokratniuvecaniColumn] = value;
                }
            }

            public string imeprezime
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tables_od_priprema.imeprezimeColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tables_od_priprema.imeprezimeColumn] = value;
                }
            }

            public decimal KOMBINACIJAIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.KOMBINACIJAIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.KOMBINACIJAIZNOSColumn] = value;
                }
            }

            public decimal KOMBINACIJAIZNOS2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.KOMBINACIJAIZNOS2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.KOMBINACIJAIZNOS2Column] = value;
                }
            }

            public decimal KOMBINACIJAPOSTOTAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.KOMBINACIJAPOSTOTAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.KOMBINACIJAPOSTOTAKColumn] = value;
                }
            }

            public decimal KOMBINACIJAPOSTOTAK2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.KOMBINACIJAPOSTOTAK2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.KOMBINACIJAPOSTOTAK2Column] = value;
                }
            }

            public string NAZIVRADNOMJESTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tables_od_priprema.NAZIVRADNOMJESTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tables_od_priprema.NAZIVRADNOMJESTOColumn] = value;
                }
            }

            public decimal nedjeljom
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.nedjeljomColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.nedjeljomColumn] = value;
                }
            }

            public decimal nedjeljomsatnica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.nedjeljomsatnicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.nedjeljomsatnicaColumn] = value;
                }
            }

            public decimal nedjeljomuvecani
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.nedjeljomuvecaniColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.nedjeljomuvecaniColumn] = value;
                }
            }

            public decimal nocni
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.nocniColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.nocniColumn] = value;
                }
            }

            public decimal nocnisatnica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.nocnisatnicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.nocnisatnicaColumn] = value;
                }
            }

            public decimal nocniuvecani
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.nocniuvecaniColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.nocniuvecaniColumn] = value;
                }
            }

            public decimal osnovnaplaca
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.osnovnaplacaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.osnovnaplacaColumn] = value;
                }
            }

            public decimal posebni1iznos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.posebni1iznosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.posebni1iznosColumn] = value;
                }
            }

            public decimal posebni1sati
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.posebni1satiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.posebni1satiColumn] = value;
                }
            }

            public decimal posebni1satnica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.posebni1satnicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.posebni1satnicaColumn] = value;
                }
            }

            public decimal posebni2iznos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.posebni2iznosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.posebni2iznosColumn] = value;
                }
            }

            public decimal posebni2sati
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.posebni2satiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.posebni2satiColumn] = value;
                }
            }

            public decimal posebni2satnica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.posebni2satnicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.posebni2satnicaColumn] = value;
                }
            }

            public decimal posebni3iznos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.posebni3iznosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.posebni3iznosColumn] = value;
                }
            }

            public decimal posebni3sati
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.posebni3satiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.posebni3satiColumn] = value;
                }
            }

            public decimal posebni3satnica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.posebni3satnicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.posebni3satnicaColumn] = value;
                }
            }

            public decimal prekovremeni
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.prekovremeniColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.prekovremeniColumn] = value;
                }
            }

            public decimal prekovremenisatnica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.prekovremenisatnicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.prekovremenisatnicaColumn] = value;
                }
            }

            public decimal prekovremeniuvecani
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.prekovremeniuvecaniColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.prekovremeniuvecaniColumn] = value;
                }
            }

            public decimal smjenskiiznos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.smjenskiiznosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.smjenskiiznosColumn] = value;
                }
            }

            public decimal smjenskisati
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.smjenskisatiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.smjenskisatiColumn] = value;
                }
            }

            public decimal smjenskisatnica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.smjenskisatnicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.smjenskisatnicaColumn] = value;
                }
            }

            public decimal sposebni1iznos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.sposebni1iznosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.sposebni1iznosColumn] = value;
                }
            }

            public decimal sposebni1sati
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.sposebni1satiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.sposebni1satiColumn] = value;
                }
            }

            public decimal sposebni1satnica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.sposebni1satnicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.sposebni1satnicaColumn] = value;
                }
            }

            public decimal sposebni2iznos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.sposebni2iznosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.sposebni2iznosColumn] = value;
                }
            }

            public decimal sposebni2sati
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.sposebni2satiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.sposebni2satiColumn] = value;
                }
            }

            public decimal sposebni2satnica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.sposebni2satnicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.sposebni2satnicaColumn] = value;
                }
            }

            public decimal sposebni3iznos
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.sposebni3iznosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.sposebni3iznosColumn] = value;
                }
            }

            public decimal sposebni3sati
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.sposebni3satiColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.sposebni3satiColumn] = value;
                }
            }

            public decimal sposebni3satnica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.sposebni3satnicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.sposebni3satnicaColumn] = value;
                }
            }

            public decimal subotom
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.subotomColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.subotomColumn] = value;
                }
            }

            public decimal subotomsatnica
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.subotomsatnicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.subotomsatnicaColumn] = value;
                }
            }

            public decimal subotomuvecani
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tables_od_priprema.subotomuvecaniColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tables_od_priprema.subotomuvecaniColumn] = value;
                }
            }
        }

        public class s_od_pripremaRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private s_od_pripremaDataSet.s_od_pripremaRow eventRow;

            public s_od_pripremaRowChangeEvent(s_od_pripremaDataSet.s_od_pripremaRow row, DataRowAction action)
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

            public s_od_pripremaDataSet.s_od_pripremaRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void s_od_pripremaRowChangeEventHandler(object sender, s_od_pripremaDataSet.s_od_pripremaRowChangeEvent e);
    }
}

