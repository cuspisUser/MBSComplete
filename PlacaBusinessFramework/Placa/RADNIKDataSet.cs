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
    public class RADNIKDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RADNIKDataTable tableRADNIK;
        private RADNIKBrutoDataTable tableRADNIKBruto;
        private RADNIKIzuzeceOdOvrheDataTable tableRADNIKIzuzeceOdOvrhe;
        private RADNIKKreditiDataTable tableRADNIKKrediti;
        private RADNIKLevel7DataTable tableRADNIKLevel7;
        private RADNIKNetoDataTable tableRADNIKNeto;
        private RADNIKObustavaDataTable tableRADNIKObustava;
        private RADNIKOdbitakDataTable tableRADNIKOdbitak;
        private RADNIKOlaksicaDataTable tableRADNIKOlaksica;

        public RADNIKDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RADNIKDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RADNIKIzuzeceOdOvrhe"] != null)
                    {
                        this.Tables.Add(new RADNIKIzuzeceOdOvrheDataTable(dataSet.Tables["RADNIKIzuzeceOdOvrhe"]));
                    }
                    if (dataSet.Tables["RADNIKLevel7"] != null)
                    {
                        this.Tables.Add(new RADNIKLevel7DataTable(dataSet.Tables["RADNIKLevel7"]));
                    }
                    if (dataSet.Tables["RADNIKObustava"] != null)
                    {
                        this.Tables.Add(new RADNIKObustavaDataTable(dataSet.Tables["RADNIKObustava"]));
                    }
                    if (dataSet.Tables["RADNIKNeto"] != null)
                    {
                        this.Tables.Add(new RADNIKNetoDataTable(dataSet.Tables["RADNIKNeto"]));
                    }
                    if (dataSet.Tables["RADNIKBruto"] != null)
                    {
                        this.Tables.Add(new RADNIKBrutoDataTable(dataSet.Tables["RADNIKBruto"]));
                    }
                    if (dataSet.Tables["RADNIKKrediti"] != null)
                    {
                        this.Tables.Add(new RADNIKKreditiDataTable(dataSet.Tables["RADNIKKrediti"]));
                    }
                    if (dataSet.Tables["RADNIKOlaksica"] != null)
                    {
                        this.Tables.Add(new RADNIKOlaksicaDataTable(dataSet.Tables["RADNIKOlaksica"]));
                    }
                    if (dataSet.Tables["RADNIKOdbitak"] != null)
                    {
                        this.Tables.Add(new RADNIKOdbitakDataTable(dataSet.Tables["RADNIKOdbitak"]));
                    }
                    if (dataSet.Tables["RADNIK"] != null)
                    {
                        this.Tables.Add(new RADNIKDataTable(dataSet.Tables["RADNIK"]));
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
            RADNIKDataSet set = (RADNIKDataSet) base.Clone();
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
            RADNIKDataSet set = new RADNIKDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RADNIKDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1016");
            this.ExtendedProperties.Add("DataSetName", "RADNIKDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRADNIKDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RADNIK");
            this.ExtendedProperties.Add("ObjectDescription", "Zaposlenici");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "TimeToTime");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "True");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "SPOJENOPREZIME");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "RADNIKDataSet";
            this.Namespace = "http://www.tempuri.org/RADNIK";
            this.tableRADNIKIzuzeceOdOvrhe = new RADNIKIzuzeceOdOvrheDataTable();
            this.Tables.Add(this.tableRADNIKIzuzeceOdOvrhe);
            this.tableRADNIKLevel7 = new RADNIKLevel7DataTable();
            this.Tables.Add(this.tableRADNIKLevel7);
            this.tableRADNIKObustava = new RADNIKObustavaDataTable();
            this.Tables.Add(this.tableRADNIKObustava);
            this.tableRADNIKNeto = new RADNIKNetoDataTable();
            this.Tables.Add(this.tableRADNIKNeto);
            this.tableRADNIKBruto = new RADNIKBrutoDataTable();
            this.Tables.Add(this.tableRADNIKBruto);
            this.tableRADNIKKrediti = new RADNIKKreditiDataTable();
            this.Tables.Add(this.tableRADNIKKrediti);
            this.tableRADNIKOlaksica = new RADNIKOlaksicaDataTable();
            this.Tables.Add(this.tableRADNIKOlaksica);
            this.tableRADNIKOdbitak = new RADNIKOdbitakDataTable();
            this.Tables.Add(this.tableRADNIKOdbitak);
            this.tableRADNIK = new RADNIKDataTable();
            this.Tables.Add(this.tableRADNIK);
            this.Relations.Add("RADNIK_RADNIKIzuzeceOdOvrhe", new DataColumn[] { this.Tables["RADNIK"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["RADNIKIzuzeceOdOvrhe"].Columns["IDRADNIK"] });
            this.Relations["RADNIK_RADNIKIzuzeceOdOvrhe"].Nested = true;
            this.Relations.Add("RADNIK_RADNIKLevel7", new DataColumn[] { this.Tables["RADNIK"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["RADNIKLevel7"].Columns["IDRADNIK"] });
            this.Relations["RADNIK_RADNIKLevel7"].Nested = true;
            this.Relations.Add("RADNIK_RADNIKObustava", new DataColumn[] { this.Tables["RADNIK"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["RADNIKObustava"].Columns["IDRADNIK"] });
            this.Relations["RADNIK_RADNIKObustava"].Nested = true;
            this.Relations.Add("RADNIK_RADNIKNeto", new DataColumn[] { this.Tables["RADNIK"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["RADNIKNeto"].Columns["IDRADNIK"] });
            this.Relations["RADNIK_RADNIKNeto"].Nested = true;
            this.Relations.Add("RADNIK_RADNIKBruto", new DataColumn[] { this.Tables["RADNIK"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["RADNIKBruto"].Columns["IDRADNIK"] });
            this.Relations["RADNIK_RADNIKBruto"].Nested = true;
            this.Relations.Add("RADNIK_RADNIKKrediti", new DataColumn[] { this.Tables["RADNIK"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["RADNIKKrediti"].Columns["IDRADNIK"] });
            this.Relations["RADNIK_RADNIKKrediti"].Nested = true;
            this.Relations.Add("RADNIK_RADNIKOlaksica", new DataColumn[] { this.Tables["RADNIK"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["RADNIKOlaksica"].Columns["IDRADNIK"] });
            this.Relations["RADNIK_RADNIKOlaksica"].Nested = true;
            this.Relations.Add("RADNIK_RADNIKOdbitak", new DataColumn[] { this.Tables["RADNIK"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["RADNIKOdbitak"].Columns["IDRADNIK"] });
            this.Relations["RADNIK_RADNIKOdbitak"].Nested = true;
            this.tableRADNIK.SPOJENOPREZIMEColumn.Expression = "PREZIME+' '+IME";
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
            this.tableRADNIKIzuzeceOdOvrhe = (RADNIKIzuzeceOdOvrheDataTable) this.Tables["RADNIKIzuzeceOdOvrhe"];
            this.tableRADNIKLevel7 = (RADNIKLevel7DataTable) this.Tables["RADNIKLevel7"];
            this.tableRADNIKObustava = (RADNIKObustavaDataTable) this.Tables["RADNIKObustava"];
            this.tableRADNIKNeto = (RADNIKNetoDataTable) this.Tables["RADNIKNeto"];
            this.tableRADNIKBruto = (RADNIKBrutoDataTable) this.Tables["RADNIKBruto"];
            this.tableRADNIKKrediti = (RADNIKKreditiDataTable) this.Tables["RADNIKKrediti"];
            this.tableRADNIKOlaksica = (RADNIKOlaksicaDataTable) this.Tables["RADNIKOlaksica"];
            this.tableRADNIKOdbitak = (RADNIKOdbitakDataTable) this.Tables["RADNIKOdbitak"];
            this.tableRADNIK = (RADNIKDataTable) this.Tables["RADNIK"];
            if (initTable)
            {
                if (this.tableRADNIKIzuzeceOdOvrhe != null)
                {
                    this.tableRADNIKIzuzeceOdOvrhe.InitVars();
                }
                if (this.tableRADNIKLevel7 != null)
                {
                    this.tableRADNIKLevel7.InitVars();
                }
                if (this.tableRADNIKObustava != null)
                {
                    this.tableRADNIKObustava.InitVars();
                }
                if (this.tableRADNIKNeto != null)
                {
                    this.tableRADNIKNeto.InitVars();
                }
                if (this.tableRADNIKBruto != null)
                {
                    this.tableRADNIKBruto.InitVars();
                }
                if (this.tableRADNIKKrediti != null)
                {
                    this.tableRADNIKKrediti.InitVars();
                }
                if (this.tableRADNIKOlaksica != null)
                {
                    this.tableRADNIKOlaksica.InitVars();
                }
                if (this.tableRADNIKOdbitak != null)
                {
                    this.tableRADNIKOdbitak.InitVars();
                }
                if (this.tableRADNIK != null)
                {
                    this.tableRADNIK.InitVars();
                }
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RADNIKIzuzeceOdOvrhe"] != null)
                {
                    this.Tables.Add(new RADNIKIzuzeceOdOvrheDataTable(dataSet.Tables["RADNIKIzuzeceOdOvrhe"]));
                }
                if (dataSet.Tables["RADNIKLevel7"] != null)
                {
                    this.Tables.Add(new RADNIKLevel7DataTable(dataSet.Tables["RADNIKLevel7"]));
                }
                if (dataSet.Tables["RADNIKObustava"] != null)
                {
                    this.Tables.Add(new RADNIKObustavaDataTable(dataSet.Tables["RADNIKObustava"]));
                }
                if (dataSet.Tables["RADNIKNeto"] != null)
                {
                    this.Tables.Add(new RADNIKNetoDataTable(dataSet.Tables["RADNIKNeto"]));
                }
                if (dataSet.Tables["RADNIKBruto"] != null)
                {
                    this.Tables.Add(new RADNIKBrutoDataTable(dataSet.Tables["RADNIKBruto"]));
                }
                if (dataSet.Tables["RADNIKKrediti"] != null)
                {
                    this.Tables.Add(new RADNIKKreditiDataTable(dataSet.Tables["RADNIKKrediti"]));
                }
                if (dataSet.Tables["RADNIKOlaksica"] != null)
                {
                    this.Tables.Add(new RADNIKOlaksicaDataTable(dataSet.Tables["RADNIKOlaksica"]));
                }
                if (dataSet.Tables["RADNIKOdbitak"] != null)
                {
                    this.Tables.Add(new RADNIKOdbitakDataTable(dataSet.Tables["RADNIKOdbitak"]));
                }
                if (dataSet.Tables["RADNIK"] != null)
                {
                    this.Tables.Add(new RADNIKDataTable(dataSet.Tables["RADNIK"]));
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

        private bool ShouldSerializeRADNIK()
        {
            return false;
        }

        private bool ShouldSerializeRADNIKBruto()
        {
            return false;
        }

        private bool ShouldSerializeRADNIKIzuzeceOdOvrhe()
        {
            return false;
        }

        private bool ShouldSerializeRADNIKKrediti()
        {
            return false;
        }

        private bool ShouldSerializeRADNIKLevel7()
        {
            return false;
        }

        private bool ShouldSerializeRADNIKNeto()
        {
            return false;
        }

        private bool ShouldSerializeRADNIKObustava()
        {
            return false;
        }

        private bool ShouldSerializeRADNIKOdbitak()
        {
            return false;
        }

        private bool ShouldSerializeRADNIKOlaksica()
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
        public RADNIKDataTable RADNIK
        {
            get
            {
                return this.tableRADNIK;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RADNIKBrutoDataTable RADNIKBruto
        {
            get
            {
                return this.tableRADNIKBruto;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RADNIKIzuzeceOdOvrheDataTable RADNIKIzuzeceOdOvrhe
        {
            get
            {
                return this.tableRADNIKIzuzeceOdOvrhe;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RADNIKKreditiDataTable RADNIKKrediti
        {
            get
            {
                return this.tableRADNIKKrediti;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RADNIKLevel7DataTable RADNIKLevel7
        {
            get
            {
                return this.tableRADNIKLevel7;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RADNIKNetoDataTable RADNIKNeto
        {
            get
            {
                return this.tableRADNIKNeto;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RADNIKObustavaDataTable RADNIKObustava
        {
            get
            {
                return this.tableRADNIKObustava;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RADNIKOdbitakDataTable RADNIKOdbitak
        {
            get
            {
                return this.tableRADNIKOdbitak;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RADNIKOlaksicaDataTable RADNIKOlaksica
        {
            get
            {
                return this.tableRADNIKOlaksica;
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
        public class RADNIKBrutoDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBRUTOELEMENTIDELEMENT;
            private DataColumn columnBRUTOELEMENTNAZIVELEMENT;
            private DataColumn columnBRUTOELEMENTPOSTOTAK;
            private DataColumn columnBRUTOIZNOS;
            private DataColumn columnBRUTOPOSTOTAK;
            private DataColumn columnBRUTOSATI;
            private DataColumn columnBRUTOSATNICA;
            private DataColumn columnIDRADNIK;

            public event RADNIKDataSet.RADNIKBrutoRowChangeEventHandler RADNIKBrutoRowChanged;

            public event RADNIKDataSet.RADNIKBrutoRowChangeEventHandler RADNIKBrutoRowChanging;

            public event RADNIKDataSet.RADNIKBrutoRowChangeEventHandler RADNIKBrutoRowDeleted;

            public event RADNIKDataSet.RADNIKBrutoRowChangeEventHandler RADNIKBrutoRowDeleting;

            public RADNIKBrutoDataTable()
            {
                this.TableName = "RADNIKBruto";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RADNIKBrutoDataTable(DataTable table) : base(table.TableName)
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

            protected RADNIKBrutoDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRADNIKBrutoRow(RADNIKDataSet.RADNIKBrutoRow row)
            {
                this.Rows.Add(row);
            }

            public RADNIKDataSet.RADNIKBrutoRow AddRADNIKBrutoRow(int iDRADNIK, int bRUTOELEMENTIDELEMENT, decimal bRUTOSATNICA, decimal bRUTOSATI, decimal bRUTOPOSTOTAK, decimal bRUTOIZNOS)
            {
                RADNIKDataSet.RADNIKBrutoRow row = (RADNIKDataSet.RADNIKBrutoRow) this.NewRow();
                row["IDRADNIK"] = iDRADNIK;
                row["BRUTOELEMENTIDELEMENT"] = bRUTOELEMENTIDELEMENT;
                row["BRUTOSATNICA"] = bRUTOSATNICA;
                row["BRUTOSATI"] = bRUTOSATI;
                row["BRUTOPOSTOTAK"] = bRUTOPOSTOTAK;
                row["BRUTOIZNOS"] = bRUTOIZNOS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RADNIKDataSet.RADNIKBrutoDataTable table = (RADNIKDataSet.RADNIKBrutoDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RADNIKDataSet.RADNIKBrutoRow FindByIDRADNIKBRUTOELEMENTIDELEMENT(int iDRADNIK, int bRUTOELEMENTIDELEMENT)
            {
                return (RADNIKDataSet.RADNIKBrutoRow) this.Rows.Find(new object[] { iDRADNIK, bRUTOELEMENTIDELEMENT });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RADNIKDataSet.RADNIKBrutoRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RADNIKDataSet set = new RADNIKDataSet();
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
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnBRUTOELEMENTIDELEMENT = new DataColumn("BRUTOELEMENTIDELEMENT", typeof(int), "", MappingType.Element);
                this.columnBRUTOELEMENTIDELEMENT.AllowDBNull = false;
                this.columnBRUTOELEMENTIDELEMENT.Caption = "Šifra bruto elementa";
                this.columnBRUTOELEMENTIDELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("SuperType", "IDELEMENT");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("SubtypeGroup", "BRUTOELEMENT");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("Description", "Šifra");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("Length", "8");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBRUTOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "BRUTOELEMENTIDELEMENT");
                this.Columns.Add(this.columnBRUTOELEMENTIDELEMENT);
                this.columnBRUTOELEMENTNAZIVELEMENT = new DataColumn("BRUTOELEMENTNAZIVELEMENT", typeof(string), "", MappingType.Element);
                this.columnBRUTOELEMENTNAZIVELEMENT.AllowDBNull = true;
                this.columnBRUTOELEMENTNAZIVELEMENT.Caption = "Naziv bruto elementa";
                this.columnBRUTOELEMENTNAZIVELEMENT.MaxLength = 50;
                this.columnBRUTOELEMENTNAZIVELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("SuperType", "NAZIVELEMENT");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("SubtypeGroup", "BRUTOELEMENT");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Description", "Naziv");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Length", "50");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBRUTOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "BRUTOELEMENTNAZIVELEMENT");
                this.Columns.Add(this.columnBRUTOELEMENTNAZIVELEMENT);
                this.columnBRUTOSATNICA = new DataColumn("BRUTOSATNICA", typeof(decimal), "", MappingType.Element);
                this.columnBRUTOSATNICA.AllowDBNull = false;
                this.columnBRUTOSATNICA.Caption = "BRUTOSATNICA";
                this.columnBRUTOSATNICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBRUTOSATNICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("IsKey", "false");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("Description", "Satnica");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("Length", "12");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("Decimals", "8");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("DomainType", "PUNODECIMALA");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBRUTOSATNICA.ExtendedProperties.Add("Deklarit.InternalName", "BRUTOSATNICA");
                this.Columns.Add(this.columnBRUTOSATNICA);
                this.columnBRUTOSATI = new DataColumn("BRUTOSATI", typeof(decimal), "", MappingType.Element);
                this.columnBRUTOSATI.AllowDBNull = false;
                this.columnBRUTOSATI.Caption = "BRUTOSATI";
                this.columnBRUTOSATI.DefaultValue = 0;
                this.columnBRUTOSATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBRUTOSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBRUTOSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBRUTOSATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBRUTOSATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBRUTOSATI.ExtendedProperties.Add("IsKey", "false");
                this.columnBRUTOSATI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBRUTOSATI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBRUTOSATI.ExtendedProperties.Add("Description", "Sati");
                this.columnBRUTOSATI.ExtendedProperties.Add("Length", "5");
                this.columnBRUTOSATI.ExtendedProperties.Add("Decimals", "2");
                this.columnBRUTOSATI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBRUTOSATI.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnBRUTOSATI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBRUTOSATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBRUTOSATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBRUTOSATI.ExtendedProperties.Add("Deklarit.InternalName", "BRUTOSATI");
                this.Columns.Add(this.columnBRUTOSATI);
                this.columnBRUTOPOSTOTAK = new DataColumn("BRUTOPOSTOTAK", typeof(decimal), "", MappingType.Element);
                this.columnBRUTOPOSTOTAK.AllowDBNull = false;
                this.columnBRUTOPOSTOTAK.Caption = "BRUTOPOSTOTAK";
                this.columnBRUTOPOSTOTAK.DefaultValue = 0;
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("IsKey", "false");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("Description", "Postotak");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("Length", "5");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("Decimals", "2");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBRUTOPOSTOTAK.ExtendedProperties.Add("Deklarit.InternalName", "BRUTOPOSTOTAK");
                this.Columns.Add(this.columnBRUTOPOSTOTAK);
                this.columnBRUTOIZNOS = new DataColumn("BRUTOIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnBRUTOIZNOS.AllowDBNull = false;
                this.columnBRUTOIZNOS.Caption = "BRUTOIZNOS";
                this.columnBRUTOIZNOS.DefaultValue = 0;
                this.columnBRUTOIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("Description", "Iznos");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBRUTOIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "BRUTOIZNOS");
                this.Columns.Add(this.columnBRUTOIZNOS);
                this.columnBRUTOELEMENTPOSTOTAK = new DataColumn("BRUTOELEMENTPOSTOTAK", typeof(decimal), "", MappingType.Element);
                this.columnBRUTOELEMENTPOSTOTAK.AllowDBNull = true;
                this.columnBRUTOELEMENTPOSTOTAK.Caption = "";
                this.columnBRUTOELEMENTPOSTOTAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("SuperType", "POSTOTAK");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("SubtypeGroup", "BRUTOELEMENT");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("IsKey", "false");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("Description", "");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("Length", "5");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("Decimals", "2");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBRUTOELEMENTPOSTOTAK.ExtendedProperties.Add("Deklarit.InternalName", "BRUTOELEMENTPOSTOTAK");
                this.Columns.Add(this.columnBRUTOELEMENTPOSTOTAK);
                this.PrimaryKey = new DataColumn[] { this.columnIDRADNIK, this.columnBRUTOELEMENTIDELEMENT };
                this.ExtendedProperties.Add("ParentLvl", "RADNIK");
                this.ExtendedProperties.Add("LevelName", "ZaduzeniBruto");
                this.ExtendedProperties.Add("Description", "Bruto elementi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnBRUTOELEMENTIDELEMENT = this.Columns["BRUTOELEMENTIDELEMENT"];
                this.columnBRUTOELEMENTNAZIVELEMENT = this.Columns["BRUTOELEMENTNAZIVELEMENT"];
                this.columnBRUTOSATNICA = this.Columns["BRUTOSATNICA"];
                this.columnBRUTOSATI = this.Columns["BRUTOSATI"];
                this.columnBRUTOPOSTOTAK = this.Columns["BRUTOPOSTOTAK"];
                this.columnBRUTOIZNOS = this.Columns["BRUTOIZNOS"];
                this.columnBRUTOELEMENTPOSTOTAK = this.Columns["BRUTOELEMENTPOSTOTAK"];
            }

            public RADNIKDataSet.RADNIKBrutoRow NewRADNIKBrutoRow()
            {
                return (RADNIKDataSet.RADNIKBrutoRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RADNIKDataSet.RADNIKBrutoRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RADNIKBrutoRowChanged != null)
                {
                    RADNIKDataSet.RADNIKBrutoRowChangeEventHandler rADNIKBrutoRowChangedEvent = this.RADNIKBrutoRowChanged;
                    if (rADNIKBrutoRowChangedEvent != null)
                    {
                        rADNIKBrutoRowChangedEvent(this, new RADNIKDataSet.RADNIKBrutoRowChangeEvent((RADNIKDataSet.RADNIKBrutoRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RADNIKBrutoRowChanging != null)
                {
                    RADNIKDataSet.RADNIKBrutoRowChangeEventHandler rADNIKBrutoRowChangingEvent = this.RADNIKBrutoRowChanging;
                    if (rADNIKBrutoRowChangingEvent != null)
                    {
                        rADNIKBrutoRowChangingEvent(this, new RADNIKDataSet.RADNIKBrutoRowChangeEvent((RADNIKDataSet.RADNIKBrutoRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("RADNIK_RADNIKBruto", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.RADNIKBrutoRowDeleted != null)
                {
                    RADNIKDataSet.RADNIKBrutoRowChangeEventHandler rADNIKBrutoRowDeletedEvent = this.RADNIKBrutoRowDeleted;
                    if (rADNIKBrutoRowDeletedEvent != null)
                    {
                        rADNIKBrutoRowDeletedEvent(this, new RADNIKDataSet.RADNIKBrutoRowChangeEvent((RADNIKDataSet.RADNIKBrutoRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RADNIKBrutoRowDeleting != null)
                {
                    RADNIKDataSet.RADNIKBrutoRowChangeEventHandler rADNIKBrutoRowDeletingEvent = this.RADNIKBrutoRowDeleting;
                    if (rADNIKBrutoRowDeletingEvent != null)
                    {
                        rADNIKBrutoRowDeletingEvent(this, new RADNIKDataSet.RADNIKBrutoRowChangeEvent((RADNIKDataSet.RADNIKBrutoRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRADNIKBrutoRow(RADNIKDataSet.RADNIKBrutoRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BRUTOELEMENTIDELEMENTColumn
            {
                get
                {
                    return this.columnBRUTOELEMENTIDELEMENT;
                }
            }

            public DataColumn BRUTOELEMENTNAZIVELEMENTColumn
            {
                get
                {
                    return this.columnBRUTOELEMENTNAZIVELEMENT;
                }
            }

            public DataColumn BRUTOELEMENTPOSTOTAKColumn
            {
                get
                {
                    return this.columnBRUTOELEMENTPOSTOTAK;
                }
            }

            public DataColumn BRUTOIZNOSColumn
            {
                get
                {
                    return this.columnBRUTOIZNOS;
                }
            }

            public DataColumn BRUTOPOSTOTAKColumn
            {
                get
                {
                    return this.columnBRUTOPOSTOTAK;
                }
            }

            public DataColumn BRUTOSATIColumn
            {
                get
                {
                    return this.columnBRUTOSATI;
                }
            }

            public DataColumn BRUTOSATNICAColumn
            {
                get
                {
                    return this.columnBRUTOSATNICA;
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

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public RADNIKDataSet.RADNIKBrutoRow this[int index]
            {
                get
                {
                    return (RADNIKDataSet.RADNIKBrutoRow) this.Rows[index];
                }
            }
        }

        public class RADNIKBrutoRow : DataRow
        {
            private RADNIKDataSet.RADNIKBrutoDataTable tableRADNIKBruto;

            internal RADNIKBrutoRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRADNIKBruto = (RADNIKDataSet.RADNIKBrutoDataTable) this.Table;
            }

            public RADNIKDataSet.RADNIKRow GetRADNIKRow()
            {
                return (RADNIKDataSet.RADNIKRow) this.GetParentRow("RADNIK_RADNIKBruto");
            }

            public bool IsBRUTOELEMENTIDELEMENTNull()
            {
                return this.IsNull(this.tableRADNIKBruto.BRUTOELEMENTIDELEMENTColumn);
            }

            public bool IsBRUTOELEMENTNAZIVELEMENTNull()
            {
                return this.IsNull(this.tableRADNIKBruto.BRUTOELEMENTNAZIVELEMENTColumn);
            }

            public bool IsBRUTOELEMENTPOSTOTAKNull()
            {
                return this.IsNull(this.tableRADNIKBruto.BRUTOELEMENTPOSTOTAKColumn);
            }

            public bool IsBRUTOIZNOSNull()
            {
                return this.IsNull(this.tableRADNIKBruto.BRUTOIZNOSColumn);
            }

            public bool IsBRUTOPOSTOTAKNull()
            {
                return this.IsNull(this.tableRADNIKBruto.BRUTOPOSTOTAKColumn);
            }

            public bool IsBRUTOSATINull()
            {
                return this.IsNull(this.tableRADNIKBruto.BRUTOSATIColumn);
            }

            public bool IsBRUTOSATNICANull()
            {
                return this.IsNull(this.tableRADNIKBruto.BRUTOSATNICAColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableRADNIKBruto.IDRADNIKColumn);
            }

            public void SetBRUTOELEMENTNAZIVELEMENTNull()
            {
                this[this.tableRADNIKBruto.BRUTOELEMENTNAZIVELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBRUTOELEMENTPOSTOTAKNull()
            {
                this[this.tableRADNIKBruto.BRUTOELEMENTPOSTOTAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBRUTOIZNOSNull()
            {
                this[this.tableRADNIKBruto.BRUTOIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBRUTOPOSTOTAKNull()
            {
                this[this.tableRADNIKBruto.BRUTOPOSTOTAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBRUTOSATINull()
            {
                this[this.tableRADNIKBruto.BRUTOSATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBRUTOSATNICANull()
            {
                this[this.tableRADNIKBruto.BRUTOSATNICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BRUTOELEMENTIDELEMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKBruto.BRUTOELEMENTIDELEMENTColumn]);
                }
                set
                {
                    this[this.tableRADNIKBruto.BRUTOELEMENTIDELEMENTColumn] = value;
                }
            }

            public string BRUTOELEMENTNAZIVELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKBruto.BRUTOELEMENTNAZIVELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BRUTOELEMENTNAZIVELEMENT because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKBruto.BRUTOELEMENTNAZIVELEMENTColumn] = value;
                }
            }

            public decimal BRUTOELEMENTPOSTOTAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKBruto.BRUTOELEMENTPOSTOTAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BRUTOELEMENTPOSTOTAK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKBruto.BRUTOELEMENTPOSTOTAKColumn] = value;
                }
            }

            public decimal BRUTOIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKBruto.BRUTOIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKBruto.BRUTOIZNOSColumn] = value;
                }
            }

            public decimal BRUTOPOSTOTAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKBruto.BRUTOPOSTOTAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKBruto.BRUTOPOSTOTAKColumn] = value;
                }
            }

            public decimal BRUTOSATI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKBruto.BRUTOSATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKBruto.BRUTOSATIColumn] = value;
                }
            }

            public decimal BRUTOSATNICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKBruto.BRUTOSATNICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKBruto.BRUTOSATNICAColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKBruto.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableRADNIKBruto.IDRADNIKColumn] = value;
                }
            }
        }

        public class RADNIKBrutoRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RADNIKDataSet.RADNIKBrutoRow eventRow;

            public RADNIKBrutoRowChangeEvent(RADNIKDataSet.RADNIKBrutoRow row, DataRowAction action)
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

            public RADNIKDataSet.RADNIKBrutoRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RADNIKBrutoRowChangeEventHandler(object sender, RADNIKDataSet.RADNIKBrutoRowChangeEvent e);

        [Serializable]
        public class RADNIKDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAKTIVAN;
            private DataColumn columnBROJMIROVINSKOG;
            private DataColumn columnBROJPRIZNATIHMJESECI;
            private DataColumn columnBROJZDRAVSTVENOG;
            private DataColumn columnDANISTAZA;
            private DataColumn columnDANISTAZAPRO;
            private DataColumn columnDATUMPRESTANKARADNOGODNOSA;
            private DataColumn columnDATUMRODJENJA;
            private DataColumn columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI;
            private DataColumn columnGODINESTAZA;
            private DataColumn columnGODINESTAZAPRO;
            private DataColumn columnIDBANKE;
            private DataColumn columnIDBENEFICIRANI;
            private DataColumn columnIDBRACNOSTANJE;
            private DataColumn columnIDDRZAVLJANSTVO;
            private DataColumn columnIDIPIDENT;
            private DataColumn columnIDORGDIO;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIDRADNOMJESTO;
            private DataColumn columnIDRADNOVRIJEME;
            private DataColumn columnIDSPOL;
            private DataColumn columnIDSTRUKA;
            private DataColumn columnIDTITULA;
            private DataColumn columnIDUGOVORORADU;
            private DataColumn columnIME;
            private DataColumn columnJMBG;
            private DataColumn columnKOEFICIJENT;
            private DataColumn columnkucnibroj;
            private DataColumn columnMBO;
            private DataColumn columnMJESECISTAZA;
            private DataColumn columnMJESECISTAZAPRO;
            private DataColumn columnmjesto;
            private DataColumn columnMO;
            private DataColumn columnNAZIVBANKE1;
            private DataColumn columnNAZIVBANKE2;
            private DataColumn columnNAZIVBANKE3;
            private DataColumn columnNAZIVBENEFICIRANI;
            private DataColumn columnNAZIVBRACNOSTANJE;
            private DataColumn columnNAZIVDRZAVLJANSTVO;
            private DataColumn columnNAZIVIPIDENT;
            private DataColumn columnNAZIVPOSLA;
            private DataColumn columnNAZIVRADNOMJESTO;
            private DataColumn columnNAZIVSPOL;
            private DataColumn columnNAZIVSTRUKA;
            private DataColumn columnNAZIVTITULA;
            private DataColumn columnNAZIVUGOVORORADU;
            private DataColumn columnOIB;
            private DataColumn columnOPCINARADAIDOPCINE;
            private DataColumn columnOPCINARADANAZIVOPCINE;
            private DataColumn columnOPCINASTANOVANJAIDOPCINE;
            private DataColumn columnOPCINASTANOVANJANAZIVOPCINE;
            private DataColumn columnOPCINASTANOVANJAPRIREZ;
            private DataColumn columnOPCINASTANOVANJAVBDIOPCINA;
            private DataColumn columnOPCINASTANOVANJAZRNOPCINA;
            private DataColumn columnOPISPLACANJANETO;
            private DataColumn columnORGANIZACIJSKIDIO;
            private DataColumn columnPBO;
            private DataColumn columnPOCETAKRADA;
            private DataColumn columnPOSTOTAKOSLOBODJENJAODPOREZA;
            private DataColumn columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
            private DataColumn columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA;
            private DataColumn columnPREZIME;
            private DataColumn columnPRODUZENOMIROVINSKO;
            private DataColumn columnRADNADOZVOLA;
            private DataColumn columnRADNASPOSOBNOST;
            private DataColumn columnRADNIKNAPOMENA;
            private DataColumn columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
            private DataColumn columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA;
            private DataColumn columnRADUINOZEMSTVU;
            private DataColumn columnRAZLOGPRESTANKA;
            private DataColumn columnSIFRAOPISAPLACANJANETO;
            private DataColumn columnSPOJENOPREZIME;
            private DataColumn columnTEKUCI;
            private DataColumn columnTJEDNIFONDSATI;
            private DataColumn columnTJEDNIFONDSATISTAZ;
            private DataColumn columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
            private DataColumn columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA;
            private DataColumn columnUGOVOROD;
            private DataColumn columnUKUPNIFAKTOR;
            private DataColumn columnUKUPNODANASTAZA;
            private DataColumn columnUKUPNOGODINESTAZA;
            private DataColumn columnUKUPNOMJESECISTAZA;
            private DataColumn columnulica;
            private DataColumn columnUZIMAUOBZIROSNOVICEDOPRINOSA;
            private DataColumn columnVBDIBANKE;
            private DataColumn columnVRIJEMEMIROVANJARADNOGODNOSA;
            private DataColumn columnVRIJEMEPRIPRAVNICKOG;
            private DataColumn columnVRIJEMEPROBNOGRADA;
            private DataColumn columnVRIJEMESTRUCNI;
            private DataColumn columnZABRANANATJECANJA;
            private DataColumn columnZAVRSENASKOLA;
            private DataColumn columnZBIRNINETO;
            private DataColumn columnZRNBANKE;

            public event RADNIKDataSet.RADNIKRowChangeEventHandler RADNIKRowChanged;

            public event RADNIKDataSet.RADNIKRowChangeEventHandler RADNIKRowChanging;

            public event RADNIKDataSet.RADNIKRowChangeEventHandler RADNIKRowDeleted;

            public event RADNIKDataSet.RADNIKRowChangeEventHandler RADNIKRowDeleting;

            public RADNIKDataTable()
            {
                this.TableName = "RADNIK";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RADNIKDataTable(DataTable table) : base(table.TableName)
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

            protected RADNIKDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRADNIKRow(RADNIKDataSet.RADNIKRow row)
            {
                this.Rows.Add(row);
            }

            public RADNIKDataSet.RADNIKRow AddRADNIKRow(int iDRADNIK, bool aKTIVAN, string pREZIME, string iME, string oIB, string jMBG, DateTime dATUMRODJENJA, string ulica, string mjesto, string kucnibroj, string oPCINARADAIDOPCINE, string oPCINASTANOVANJAIDOPCINE, int rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, int iDBANKE, string tEKUCI, bool zBIRNINETO, string sIFRAOPISAPLACANJANETO, string oPISPLACANJANETO, decimal tJEDNIFONDSATI, decimal kOEFICIJENT, decimal pOSTOTAKOSLOBODJENJAODPOREZA, bool uZIMAUOBZIROSNOVICEDOPRINOSA, decimal tJEDNIFONDSATISTAZ, DateTime dATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, short gODINESTAZA, short mJESECISTAZA, short dANISTAZA, string iDBENEFICIRANI, DateTime dATUMPRESTANKARADNOGODNOSA, string bROJMIROVINSKOG, string bROJZDRAVSTVENOG, string mBO, int iDTITULA, int iDRADNOMJESTO, int tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, int pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA, int iDSTRUKA, int iDBRACNOSTANJE, int iDORGDIO, string mO, string pBO, short gODINESTAZAPRO, short mJESECISTAZAPRO, short dANISTAZAPRO, int iDDRZAVLJANSTVO, string rADNADOZVOLA, string zAVRSENASKOLA, DateTime uGOVOROD, DateTime pOCETAKRADA, string nAZIVPOSLA, int iDUGOVORORADU, string vRIJEMEPROBNOGRADA, string vRIJEMEPRIPRAVNICKOG, string vRIJEMESTRUCNI, string rADUINOZEMSTVU, string rADNASPOSOBNOST, string vRIJEMEMIROVANJARADNOGODNOSA, string rAZLOGPRESTANKA, string zABRANANATJECANJA, string pRODUZENOMIROVINSKO, string rADNIKNAPOMENA, int iDRADNOVRIJEME, int iDSPOL, int iDIPIDENT)
            {
                RADNIKDataSet.RADNIKRow row = (RADNIKDataSet.RADNIKRow) this.NewRow();
                row["IDRADNIK"] = iDRADNIK;
                row["AKTIVAN"] = aKTIVAN;
                row["PREZIME"] = pREZIME;
                row["IME"] = iME;
                row["OIB"] = oIB;
                row["JMBG"] = jMBG;
                row["DATUMRODJENJA"] = dATUMRODJENJA;
                row["ulica"] = ulica;
                row["mjesto"] = mjesto;
                row["kucnibroj"] = kucnibroj;
                row["OPCINARADAIDOPCINE"] = oPCINARADAIDOPCINE;
                row["OPCINASTANOVANJAIDOPCINE"] = oPCINASTANOVANJAIDOPCINE;
                row["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"] = rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
                row["IDBANKE"] = iDBANKE;
                row["TEKUCI"] = tEKUCI;
                row["ZBIRNINETO"] = zBIRNINETO;
                row["SIFRAOPISAPLACANJANETO"] = sIFRAOPISAPLACANJANETO;
                row["OPISPLACANJANETO"] = oPISPLACANJANETO;
                row["TJEDNIFONDSATI"] = tJEDNIFONDSATI;
                row["KOEFICIJENT"] = kOEFICIJENT;
                row["POSTOTAKOSLOBODJENJAODPOREZA"] = pOSTOTAKOSLOBODJENJAODPOREZA;
                row["UZIMAUOBZIROSNOVICEDOPRINOSA"] = uZIMAUOBZIROSNOVICEDOPRINOSA;
                row["TJEDNIFONDSATISTAZ"] = tJEDNIFONDSATISTAZ;
                row["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"] = dATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI;
                row["GODINESTAZA"] = gODINESTAZA;
                row["MJESECISTAZA"] = mJESECISTAZA;
                row["DANISTAZA"] = dANISTAZA;
                row["IDBENEFICIRANI"] = iDBENEFICIRANI;
                row["DATUMPRESTANKARADNOGODNOSA"] = dATUMPRESTANKARADNOGODNOSA;
                row["BROJMIROVINSKOG"] = bROJMIROVINSKOG;
                row["BROJZDRAVSTVENOG"] = bROJZDRAVSTVENOG;
                row["MBO"] = mBO;
                row["IDTITULA"] = iDTITULA;
                row["IDRADNOMJESTO"] = iDRADNOMJESTO;
                row["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"] = tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
                row["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"] = pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
                row["IDSTRUKA"] = iDSTRUKA;
                row["IDBRACNOSTANJE"] = iDBRACNOSTANJE;
                row["IDORGDIO"] = iDORGDIO;
                row["MO"] = mO;
                row["PBO"] = pBO;
                row["GODINESTAZAPRO"] = gODINESTAZAPRO;
                row["MJESECISTAZAPRO"] = mJESECISTAZAPRO;
                row["DANISTAZAPRO"] = dANISTAZAPRO;
                row["IDDRZAVLJANSTVO"] = iDDRZAVLJANSTVO;
                row["RADNADOZVOLA"] = rADNADOZVOLA;
                row["ZAVRSENASKOLA"] = zAVRSENASKOLA;
                row["UGOVOROD"] = uGOVOROD;
                row["POCETAKRADA"] = pOCETAKRADA;
                row["NAZIVPOSLA"] = nAZIVPOSLA;
                row["IDUGOVORORADU"] = iDUGOVORORADU;
                row["VRIJEMEPROBNOGRADA"] = vRIJEMEPROBNOGRADA;
                row["VRIJEMEPRIPRAVNICKOG"] = vRIJEMEPRIPRAVNICKOG;
                row["VRIJEMESTRUCNI"] = vRIJEMESTRUCNI;
                row["RADUINOZEMSTVU"] = rADUINOZEMSTVU;
                row["RADNASPOSOBNOST"] = rADNASPOSOBNOST;
                row["VRIJEMEMIROVANJARADNOGODNOSA"] = vRIJEMEMIROVANJARADNOGODNOSA;
                row["RAZLOGPRESTANKA"] = rAZLOGPRESTANKA;
                row["ZABRANANATJECANJA"] = zABRANANATJECANJA;
                row["PRODUZENOMIROVINSKO"] = pRODUZENOMIROVINSKO;
                row["RADNIKNAPOMENA"] = rADNIKNAPOMENA;
                row["IDRADNOVRIJEME"] = iDRADNOVRIJEME;
                row["IDSPOL"] = iDSPOL;
                row["IDIPIDENT"] = iDIPIDENT;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RADNIKDataSet.RADNIKDataTable table = (RADNIKDataSet.RADNIKDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RADNIKDataSet.RADNIKRow FindByIDRADNIK(int iDRADNIK)
            {
                return (RADNIKDataSet.RADNIKRow) this.Rows.Find(new object[] { iDRADNIK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RADNIKDataSet.RADNIKRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RADNIKDataSet set = new RADNIKDataSet();
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
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.Unique = true;
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnSPOJENOPREZIME = new DataColumn("SPOJENOPREZIME", typeof(string), "", MappingType.Element);
                this.columnSPOJENOPREZIME.AllowDBNull = true;
                this.columnSPOJENOPREZIME.Caption = "SPOJENOPREZIME";
                this.columnSPOJENOPREZIME.MaxLength = 100;
                this.columnSPOJENOPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Description", "SPOJENOPREZIME");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Length", "100");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "SPOJENOPREZIME");
                this.columnSPOJENOPREZIME.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnSPOJENOPREZIME);
                this.columnAKTIVAN = new DataColumn("AKTIVAN", typeof(bool), "", MappingType.Element);
                this.columnAKTIVAN.AllowDBNull = false;
                this.columnAKTIVAN.Caption = "Aktivan";
                this.columnAKTIVAN.DefaultValue = true;
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnAKTIVAN.ExtendedProperties.Add("IsKey", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnAKTIVAN.ExtendedProperties.Add("Description", "aktivan");
                this.columnAKTIVAN.ExtendedProperties.Add("Length", "1");
                this.columnAKTIVAN.ExtendedProperties.Add("Decimals", "0");
                this.columnAKTIVAN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.InternalName", "AKTIVAN");
                this.Columns.Add(this.columnAKTIVAN);
                this.columnPREZIME = new DataColumn("PREZIME", typeof(string), "", MappingType.Element);
                this.columnPREZIME.AllowDBNull = false;
                this.columnPREZIME.Caption = "Prezime";
                this.columnPREZIME.MaxLength = 50;
                this.columnPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnPREZIME.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPREZIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "PREZIME");
                this.Columns.Add(this.columnPREZIME);
                this.columnIME = new DataColumn("IME", typeof(string), "", MappingType.Element);
                this.columnIME.AllowDBNull = false;
                this.columnIME.Caption = "Ime";
                this.columnIME.MaxLength = 50;
                this.columnIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIME.ExtendedProperties.Add("IsKey", "false");
                this.columnIME.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIME.ExtendedProperties.Add("Description", "Ime");
                this.columnIME.ExtendedProperties.Add("Length", "50");
                this.columnIME.ExtendedProperties.Add("Decimals", "0");
                this.columnIME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.InternalName", "IME");
                this.Columns.Add(this.columnIME);
                this.columnOIB = new DataColumn("OIB", typeof(string), "", MappingType.Element);
                this.columnOIB.AllowDBNull = true;
                this.columnOIB.Caption = "OIB";
                this.columnOIB.MaxLength = 11;
                this.columnOIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOIB.ExtendedProperties.Add("IsKey", "false");
                this.columnOIB.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOIB.ExtendedProperties.Add("Description", "Osobni identifikacijski broj");
                this.columnOIB.ExtendedProperties.Add("Length", "11");
                this.columnOIB.ExtendedProperties.Add("Decimals", "0");
                this.columnOIB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOIB.ExtendedProperties.Add("Deklarit.InternalName", "OIB");
                this.Columns.Add(this.columnOIB);
                this.columnJMBG = new DataColumn("JMBG", typeof(string), "", MappingType.Element);
                this.columnJMBG.AllowDBNull = false;
                this.columnJMBG.Caption = "JMBG";
                this.columnJMBG.MaxLength = 13;
                this.columnJMBG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnJMBG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnJMBG.ExtendedProperties.Add("IsKey", "false");
                this.columnJMBG.ExtendedProperties.Add("ReadOnly", "false");
                this.columnJMBG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnJMBG.ExtendedProperties.Add("Description", "JMBG");
                this.columnJMBG.ExtendedProperties.Add("Length", "13");
                this.columnJMBG.ExtendedProperties.Add("Decimals", "0");
                this.columnJMBG.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnJMBG.ExtendedProperties.Add("IsInReader", "true");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.InternalName", "JMBG");
                this.Columns.Add(this.columnJMBG);
                this.columnDATUMRODJENJA = new DataColumn("DATUMRODJENJA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMRODJENJA.AllowDBNull = false;
                this.columnDATUMRODJENJA.Caption = "Datum rođenja";
                this.columnDATUMRODJENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Description", "Datum rođenja");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMRODJENJA");
                this.Columns.Add(this.columnDATUMRODJENJA);
                this.columnulica = new DataColumn("ulica", typeof(string), "", MappingType.Element);
                this.columnulica.AllowDBNull = false;
                this.columnulica.Caption = "Ulica";
                this.columnulica.MaxLength = 50;
                this.columnulica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnulica.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnulica.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnulica.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnulica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnulica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnulica.ExtendedProperties.Add("IsKey", "false");
                this.columnulica.ExtendedProperties.Add("ReadOnly", "false");
                this.columnulica.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnulica.ExtendedProperties.Add("Description", "Ulica");
                this.columnulica.ExtendedProperties.Add("Length", "50");
                this.columnulica.ExtendedProperties.Add("Decimals", "0");
                this.columnulica.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnulica.ExtendedProperties.Add("IsInReader", "true");
                this.columnulica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnulica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnulica.ExtendedProperties.Add("Deklarit.InternalName", "ulica");
                this.Columns.Add(this.columnulica);
                this.columnmjesto = new DataColumn("mjesto", typeof(string), "", MappingType.Element);
                this.columnmjesto.AllowDBNull = false;
                this.columnmjesto.Caption = "Mjesto";
                this.columnmjesto.MaxLength = 50;
                this.columnmjesto.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmjesto.ExtendedProperties.Add("IsKey", "false");
                this.columnmjesto.ExtendedProperties.Add("ReadOnly", "false");
                this.columnmjesto.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnmjesto.ExtendedProperties.Add("Description", "Mjesto");
                this.columnmjesto.ExtendedProperties.Add("Length", "50");
                this.columnmjesto.ExtendedProperties.Add("Decimals", "0");
                this.columnmjesto.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnmjesto.ExtendedProperties.Add("IsInReader", "true");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.InternalName", "mjesto");
                this.Columns.Add(this.columnmjesto);
                this.columnkucnibroj = new DataColumn("kucnibroj", typeof(string), "", MappingType.Element);
                this.columnkucnibroj.AllowDBNull = false;
                this.columnkucnibroj.Caption = "Kućni broj";
                this.columnkucnibroj.MaxLength = 10;
                this.columnkucnibroj.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnkucnibroj.ExtendedProperties.Add("IsKey", "false");
                this.columnkucnibroj.ExtendedProperties.Add("ReadOnly", "false");
                this.columnkucnibroj.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnkucnibroj.ExtendedProperties.Add("Description", "Kućni broj");
                this.columnkucnibroj.ExtendedProperties.Add("Length", "10");
                this.columnkucnibroj.ExtendedProperties.Add("Decimals", "0");
                this.columnkucnibroj.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnkucnibroj.ExtendedProperties.Add("IsInReader", "true");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.InternalName", "kucnibroj");
                this.Columns.Add(this.columnkucnibroj);
                this.columnOPCINARADAIDOPCINE = new DataColumn("OPCINARADAIDOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINARADAIDOPCINE.AllowDBNull = false;
                this.columnOPCINARADAIDOPCINE.Caption = "Šifra općine rada";
                this.columnOPCINARADAIDOPCINE.MaxLength = 4;
                this.columnOPCINARADAIDOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("SuperType", "IDOPCINE");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINARADA");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Description", "Šifra općine rada");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Length", "4");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINARADAIDOPCINE");
                this.Columns.Add(this.columnOPCINARADAIDOPCINE);
                this.columnOPCINARADANAZIVOPCINE = new DataColumn("OPCINARADANAZIVOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINARADANAZIVOPCINE.AllowDBNull = true;
                this.columnOPCINARADANAZIVOPCINE.Caption = "Naziv općine rada";
                this.columnOPCINARADANAZIVOPCINE.MaxLength = 50;
                this.columnOPCINARADANAZIVOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("SuperType", "NAZIVOPCINE");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINARADA");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Description", "Naziv općine rada");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Length", "50");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINARADANAZIVOPCINE");
                this.Columns.Add(this.columnOPCINARADANAZIVOPCINE);
                this.columnOPCINASTANOVANJAIDOPCINE = new DataColumn("OPCINASTANOVANJAIDOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJAIDOPCINE.AllowDBNull = false;
                this.columnOPCINASTANOVANJAIDOPCINE.Caption = "Šifra općine stanovanja";
                this.columnOPCINASTANOVANJAIDOPCINE.MaxLength = 4;
                this.columnOPCINASTANOVANJAIDOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("SuperType", "IDOPCINE");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Description", "Šifra općine stanovanja");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Length", "4");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAIDOPCINE");
                this.Columns.Add(this.columnOPCINASTANOVANJAIDOPCINE);
                this.columnOPCINASTANOVANJANAZIVOPCINE = new DataColumn("OPCINASTANOVANJANAZIVOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJANAZIVOPCINE.AllowDBNull = true;
                this.columnOPCINASTANOVANJANAZIVOPCINE.Caption = "Naziv općine stanovanja";
                this.columnOPCINASTANOVANJANAZIVOPCINE.MaxLength = 50;
                this.columnOPCINASTANOVANJANAZIVOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("SuperType", "NAZIVOPCINE");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Description", "Naziv općine stanovanja");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Length", "50");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJANAZIVOPCINE");
                this.Columns.Add(this.columnOPCINASTANOVANJANAZIVOPCINE);
                this.columnOPCINASTANOVANJAPRIREZ = new DataColumn("OPCINASTANOVANJAPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnOPCINASTANOVANJAPRIREZ.AllowDBNull = true;
                this.columnOPCINASTANOVANJAPRIREZ.Caption = "Prirez općine stanovanja";
                this.columnOPCINASTANOVANJAPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("SuperType", "PRIREZ");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Description", "Prirez općine stanovanja");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAPRIREZ");
                this.Columns.Add(this.columnOPCINASTANOVANJAPRIREZ);
                this.columnOPCINASTANOVANJAVBDIOPCINA = new DataColumn("OPCINASTANOVANJAVBDIOPCINA", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJAVBDIOPCINA.AllowDBNull = true;
                this.columnOPCINASTANOVANJAVBDIOPCINA.Caption = "VBDI žiro računa općine stanovanja";
                this.columnOPCINASTANOVANJAVBDIOPCINA.MaxLength = 7;
                this.columnOPCINASTANOVANJAVBDIOPCINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("SuperType", "VBDIOPCINA");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Description", "VBDI žiro računa općine stanovanja");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Length", "7");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAVBDIOPCINA");
                this.Columns.Add(this.columnOPCINASTANOVANJAVBDIOPCINA);
                this.columnOPCINASTANOVANJAZRNOPCINA = new DataColumn("OPCINASTANOVANJAZRNOPCINA", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJAZRNOPCINA.AllowDBNull = true;
                this.columnOPCINASTANOVANJAZRNOPCINA.Caption = "Broj žiro računa općine stanovanja";
                this.columnOPCINASTANOVANJAZRNOPCINA.MaxLength = 10;
                this.columnOPCINASTANOVANJAZRNOPCINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("SuperType", "ZRNOPCINA");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Description", "Broj žiro računa općine stanovanja");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Length", "10");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAZRNOPCINA");
                this.Columns.Add(this.columnOPCINASTANOVANJAZRNOPCINA);
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = new DataColumn("RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", typeof(int), "", MappingType.Element);
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.AllowDBNull = false;
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Caption = "Šifra skupine poreza i doprinosa";
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("SuperType", "IDSKUPPOREZAIDOPRINOSA");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("SubtypeGroup", "RADNIKPOREZIDOPRINOS");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Description", "Šifra skupine poreza i doprinosa");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Length", "5");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.InternalName", "RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA");
                this.Columns.Add(this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA);
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA = new DataColumn("RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA", typeof(string), "", MappingType.Element);
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.AllowDBNull = true;
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.Caption = "Naziv skupine poreza i doprinosa";
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.MaxLength = 50;
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("SuperType", "NAZIVSKUPPOREZAIDOPRINOSA");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("SubtypeGroup", "RADNIKPOREZIDOPRINOS");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Description", "Naziv skupine poreza i doprinosa");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Length", "50");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.InternalName", "RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA");
                this.Columns.Add(this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA);
                this.columnIDBANKE = new DataColumn("IDBANKE", typeof(int), "", MappingType.Element);
                this.columnIDBANKE.AllowDBNull = false;
                this.columnIDBANKE.Caption = "Šifra banke";
                this.columnIDBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDBANKE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDBANKE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDBANKE.ExtendedProperties.Add("Description", "Šifra banke");
                this.columnIDBANKE.ExtendedProperties.Add("Length", "5");
                this.columnIDBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBANKE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDBANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.InternalName", "IDBANKE");
                this.Columns.Add(this.columnIDBANKE);
                this.columnNAZIVBANKE1 = new DataColumn("NAZIVBANKE1", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE1.AllowDBNull = true;
                this.columnNAZIVBANKE1.Caption = "Naziv banke";
                this.columnNAZIVBANKE1.MaxLength = 20;
                this.columnNAZIVBANKE1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Description", "Naziv banke");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE1");
                this.Columns.Add(this.columnNAZIVBANKE1);
                this.columnNAZIVBANKE2 = new DataColumn("NAZIVBANKE2", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE2.AllowDBNull = true;
                this.columnNAZIVBANKE2.Caption = "Naziv banke (2)";
                this.columnNAZIVBANKE2.MaxLength = 20;
                this.columnNAZIVBANKE2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Description", "Naziv banke (2)");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE2");
                this.Columns.Add(this.columnNAZIVBANKE2);
                this.columnNAZIVBANKE3 = new DataColumn("NAZIVBANKE3", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE3.AllowDBNull = true;
                this.columnNAZIVBANKE3.Caption = "Naziv banke (3)";
                this.columnNAZIVBANKE3.MaxLength = 20;
                this.columnNAZIVBANKE3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Description", "Naziv banke (3)");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE3");
                this.Columns.Add(this.columnNAZIVBANKE3);
                this.columnVBDIBANKE = new DataColumn("VBDIBANKE", typeof(string), "", MappingType.Element);
                this.columnVBDIBANKE.AllowDBNull = true;
                this.columnVBDIBANKE.Caption = "VBDI žiro računa banke";
                this.columnVBDIBANKE.MaxLength = 7;
                this.columnVBDIBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIBANKE.ExtendedProperties.Add("Description", "VBDI žiro računa banke");
                this.columnVBDIBANKE.ExtendedProperties.Add("Length", "7");
                this.columnVBDIBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIBANKE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.InternalName", "VBDIBANKE");
                this.Columns.Add(this.columnVBDIBANKE);
                this.columnZRNBANKE = new DataColumn("ZRNBANKE", typeof(string), "", MappingType.Element);
                this.columnZRNBANKE.AllowDBNull = true;
                this.columnZRNBANKE.Caption = "Broj žiro računa banke";
                this.columnZRNBANKE.MaxLength = 10;
                this.columnZRNBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNBANKE.ExtendedProperties.Add("Description", "Broj žiro računa banke");
                this.columnZRNBANKE.ExtendedProperties.Add("Length", "10");
                this.columnZRNBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNBANKE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.InternalName", "ZRNBANKE");
                this.Columns.Add(this.columnZRNBANKE);
                this.columnTEKUCI = new DataColumn("TEKUCI", typeof(string), "", MappingType.Element);
                this.columnTEKUCI.AllowDBNull = false;
                this.columnTEKUCI.Caption = "Tekući račun";
                this.columnTEKUCI.MaxLength = 10;
                this.columnTEKUCI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTEKUCI.ExtendedProperties.Add("IsKey", "false");
                this.columnTEKUCI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnTEKUCI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnTEKUCI.ExtendedProperties.Add("Description", "Tekući račun");
                this.columnTEKUCI.ExtendedProperties.Add("Length", "10");
                this.columnTEKUCI.ExtendedProperties.Add("Decimals", "0");
                this.columnTEKUCI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnTEKUCI.ExtendedProperties.Add("IsInReader", "true");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.InternalName", "TEKUCI");
                this.Columns.Add(this.columnTEKUCI);
                this.columnZBIRNINETO = new DataColumn("ZBIRNINETO", typeof(bool), "", MappingType.Element);
                this.columnZBIRNINETO.AllowDBNull = false;
                this.columnZBIRNINETO.Caption = "Uključen u zbirni neto";
                this.columnZBIRNINETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZBIRNINETO.ExtendedProperties.Add("IsKey", "false");
                this.columnZBIRNINETO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZBIRNINETO.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnZBIRNINETO.ExtendedProperties.Add("Description", "Uključen u zbirni neto");
                this.columnZBIRNINETO.ExtendedProperties.Add("Length", "1");
                this.columnZBIRNINETO.ExtendedProperties.Add("Decimals", "0");
                this.columnZBIRNINETO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZBIRNINETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.InternalName", "ZBIRNINETO");
                this.Columns.Add(this.columnZBIRNINETO);
                this.columnSIFRAOPISAPLACANJANETO = new DataColumn("SIFRAOPISAPLACANJANETO", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJANETO.AllowDBNull = false;
                this.columnSIFRAOPISAPLACANJANETO.Caption = "Šifra opisa plaćanja (iznos za isplatu)";
                this.columnSIFRAOPISAPLACANJANETO.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJANETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Description", "Šifra opisa plaćanja (iznos za isplatu)");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJANETO");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJANETO);
                this.columnOPISPLACANJANETO = new DataColumn("OPISPLACANJANETO", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJANETO.AllowDBNull = false;
                this.columnOPISPLACANJANETO.Caption = "Opis plaćanja (iznos za isplatu)";
                this.columnOPISPLACANJANETO.MaxLength = 0x24;
                this.columnOPISPLACANJANETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Description", "Opis plaćanja (iznos za isplatu)");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJANETO");
                this.Columns.Add(this.columnOPISPLACANJANETO);
                this.columnTJEDNIFONDSATI = new DataColumn("TJEDNIFONDSATI", typeof(decimal), "", MappingType.Element);
                this.columnTJEDNIFONDSATI.AllowDBNull = false;
                this.columnTJEDNIFONDSATI.Caption = "Tjedni fond sati (za obračun)";
                this.columnTJEDNIFONDSATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("IsKey", "false");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Description", "Tjedni fond sati (za obračun)");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Length", "5");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Decimals", "2");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("IsInReader", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.InternalName", "TJEDNIFONDSATI");
                this.Columns.Add(this.columnTJEDNIFONDSATI);
                this.columnKOEFICIJENT = new DataColumn("KOEFICIJENT", typeof(decimal), "", MappingType.Element);
                this.columnKOEFICIJENT.AllowDBNull = false;
                this.columnKOEFICIJENT.Caption = "Koeficijent";
                this.columnKOEFICIJENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOEFICIJENT.ExtendedProperties.Add("IsKey", "false");
                this.columnKOEFICIJENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKOEFICIJENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Description", "Koeficijent");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Length", "17");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Decimals", "10");
                this.columnKOEFICIJENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKOEFICIJENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.InternalName", "KOEFICIJENT");
                this.Columns.Add(this.columnKOEFICIJENT);
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA = new DataColumn("POSTOTAKOSLOBODJENJAODPOREZA", typeof(decimal), "", MappingType.Element);
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.AllowDBNull = false;
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.Caption = "Postotak oslobođenja od poreza (HRVI, ...)";
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Description", "Postotak oslobođenja od poreza (HRVI, ...)");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Length", "5");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Decimals", "2");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.InternalName", "POSTOTAKOSLOBODJENJAODPOREZA");
                this.Columns.Add(this.columnPOSTOTAKOSLOBODJENJAODPOREZA);
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA = new DataColumn("UZIMAUOBZIROSNOVICEDOPRINOSA", typeof(bool), "", MappingType.Element);
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.AllowDBNull = false;
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.Caption = "Korištenje min. i maks. osnovice za obraeun doprinosa";
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Description", "Korištenje min. i maks. osnovice za obračun doprinosa");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Length", "1");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.InternalName", "UZIMAUOBZIROSNOVICEDOPRINOSA");
                this.Columns.Add(this.columnUZIMAUOBZIROSNOVICEDOPRINOSA);
                this.columnTJEDNIFONDSATISTAZ = new DataColumn("TJEDNIFONDSATISTAZ", typeof(decimal), "", MappingType.Element);
                this.columnTJEDNIFONDSATISTAZ.AllowDBNull = false;
                this.columnTJEDNIFONDSATISTAZ.Caption = "Tjedni fond sati (za izračun staža)";
                this.columnTJEDNIFONDSATISTAZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("IsKey", "false");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Description", "Tjedni fond sati (za izračun staža)");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Length", "5");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Decimals", "2");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.InternalName", "TJEDNIFONDSATISTAZ");
                this.Columns.Add(this.columnTJEDNIFONDSATISTAZ);
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = new DataColumn("DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.AllowDBNull = false;
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Caption = "Datum zadnjeg zaposlenja ili promjene fonda sati";
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Description", "Datum zadnjeg zaposlenja ili promjene fonda sati");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Length", "8");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.InternalName", "DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI");
                this.Columns.Add(this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI);
                this.columnGODINESTAZA = new DataColumn("GODINESTAZA", typeof(short), "", MappingType.Element);
                this.columnGODINESTAZA.AllowDBNull = false;
                this.columnGODINESTAZA.Caption = "Godine staža (do datuma)";
                this.columnGODINESTAZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINESTAZA.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINESTAZA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnGODINESTAZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnGODINESTAZA.ExtendedProperties.Add("Description", "Godine staža (do datuma)");
                this.columnGODINESTAZA.ExtendedProperties.Add("Length", "2");
                this.columnGODINESTAZA.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINESTAZA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnGODINESTAZA.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.InternalName", "GODINESTAZA");
                this.Columns.Add(this.columnGODINESTAZA);
                this.columnMJESECISTAZA = new DataColumn("MJESECISTAZA", typeof(short), "", MappingType.Element);
                this.columnMJESECISTAZA.AllowDBNull = false;
                this.columnMJESECISTAZA.Caption = "Mjeseci staža (do datuma)";
                this.columnMJESECISTAZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESECISTAZA.ExtendedProperties.Add("IsKey", "false");
                this.columnMJESECISTAZA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMJESECISTAZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Description", "Mjeseci staža (do datuma)");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Length", "2");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESECISTAZA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMJESECISTAZA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.InternalName", "MJESECISTAZA");
                this.Columns.Add(this.columnMJESECISTAZA);
                this.columnDANISTAZA = new DataColumn("DANISTAZA", typeof(short), "", MappingType.Element);
                this.columnDANISTAZA.AllowDBNull = false;
                this.columnDANISTAZA.Caption = "Dani staža (do datuma)";
                this.columnDANISTAZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDANISTAZA.ExtendedProperties.Add("IsKey", "false");
                this.columnDANISTAZA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDANISTAZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDANISTAZA.ExtendedProperties.Add("Description", "Dani staža (do datuma)");
                this.columnDANISTAZA.ExtendedProperties.Add("Length", "3");
                this.columnDANISTAZA.ExtendedProperties.Add("Decimals", "0");
                this.columnDANISTAZA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDANISTAZA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.InternalName", "DANISTAZA");
                this.Columns.Add(this.columnDANISTAZA);
                this.columnIDBENEFICIRANI = new DataColumn("IDBENEFICIRANI", typeof(string), "", MappingType.Element);
                this.columnIDBENEFICIRANI.AllowDBNull = false;
                this.columnIDBENEFICIRANI.Caption = "Šifra beneficiranog radnog staža";
                this.columnIDBENEFICIRANI.MaxLength = 1;
                this.columnIDBENEFICIRANI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("IsKey", "false");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Description", "Šifra beneficiranog radnog staža");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Length", "1");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.InternalName", "IDBENEFICIRANI");
                this.Columns.Add(this.columnIDBENEFICIRANI);
                this.columnNAZIVBENEFICIRANI = new DataColumn("NAZIVBENEFICIRANI", typeof(string), "", MappingType.Element);
                this.columnNAZIVBENEFICIRANI.AllowDBNull = true;
                this.columnNAZIVBENEFICIRANI.Caption = "Naziv beneficiranog radnog staža";
                this.columnNAZIVBENEFICIRANI.MaxLength = 50;
                this.columnNAZIVBENEFICIRANI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Description", "Naziv beneficiranog radnog staža");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBENEFICIRANI");
                this.Columns.Add(this.columnNAZIVBENEFICIRANI);
                this.columnDATUMPRESTANKARADNOGODNOSA = new DataColumn("DATUMPRESTANKARADNOGODNOSA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMPRESTANKARADNOGODNOSA.AllowDBNull = true;
                this.columnDATUMPRESTANKARADNOGODNOSA.Caption = "Datum prestanka radnog odnosa";
                this.columnDATUMPRESTANKARADNOGODNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Description", "Datum prestanka radnog odnosa");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMPRESTANKARADNOGODNOSA");
                this.Columns.Add(this.columnDATUMPRESTANKARADNOGODNOSA);
                this.columnBROJMIROVINSKOG = new DataColumn("BROJMIROVINSKOG", typeof(string), "", MappingType.Element);
                this.columnBROJMIROVINSKOG.AllowDBNull = true;
                this.columnBROJMIROVINSKOG.Caption = "Broj mirovinskog osiguranja";
                this.columnBROJMIROVINSKOG.MaxLength = 50;
                this.columnBROJMIROVINSKOG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Description", "Broj mirovinskog osiguranja");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Length", "50");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.InternalName", "BROJMIROVINSKOG");
                this.Columns.Add(this.columnBROJMIROVINSKOG);
                this.columnBROJZDRAVSTVENOG = new DataColumn("BROJZDRAVSTVENOG", typeof(string), "", MappingType.Element);
                this.columnBROJZDRAVSTVENOG.AllowDBNull = true;
                this.columnBROJZDRAVSTVENOG.Caption = "Broj zdravstvenog osiguranja";
                this.columnBROJZDRAVSTVENOG.MaxLength = 50;
                this.columnBROJZDRAVSTVENOG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Description", "Broj zdravstvenog osiguranja");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Length", "50");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.InternalName", "BROJZDRAVSTVENOG");
                this.Columns.Add(this.columnBROJZDRAVSTVENOG);
                this.columnMBO = new DataColumn("MBO", typeof(string), "", MappingType.Element);
                this.columnMBO.AllowDBNull = true;
                this.columnMBO.Caption = "Matični broj osiguranika";
                this.columnMBO.MaxLength = 50;
                this.columnMBO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMBO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMBO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMBO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMBO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMBO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMBO.ExtendedProperties.Add("IsKey", "false");
                this.columnMBO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMBO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMBO.ExtendedProperties.Add("Description", "Matični broj osiguranika");
                this.columnMBO.ExtendedProperties.Add("Length", "50");
                this.columnMBO.ExtendedProperties.Add("Decimals", "0");
                this.columnMBO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMBO.ExtendedProperties.Add("IsInReader", "true");
                this.columnMBO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMBO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMBO.ExtendedProperties.Add("Deklarit.InternalName", "MBO");
                this.Columns.Add(this.columnMBO);
                this.columnIDTITULA = new DataColumn("IDTITULA", typeof(int), "", MappingType.Element);
                this.columnIDTITULA.AllowDBNull = true;
                this.columnIDTITULA.Caption = "Šifra titule";
                this.columnIDTITULA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTITULA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDTITULA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDTITULA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTITULA.ExtendedProperties.Add("Description", "Šifra titule");
                this.columnIDTITULA.ExtendedProperties.Add("Length", "5");
                this.columnIDTITULA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTITULA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDTITULA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.InternalName", "IDTITULA");
                this.Columns.Add(this.columnIDTITULA);
                this.columnNAZIVTITULA = new DataColumn("NAZIVTITULA", typeof(string), "", MappingType.Element);
                this.columnNAZIVTITULA.AllowDBNull = true;
                this.columnNAZIVTITULA.Caption = "Naziv titule";
                this.columnNAZIVTITULA.MaxLength = 50;
                this.columnNAZIVTITULA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVTITULA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVTITULA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVTITULA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Description", "Naziv titule");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVTITULA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVTITULA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVTITULA");
                this.Columns.Add(this.columnNAZIVTITULA);
                this.columnIDRADNOMJESTO = new DataColumn("IDRADNOMJESTO", typeof(int), "", MappingType.Element);
                this.columnIDRADNOMJESTO.AllowDBNull = true;
                this.columnIDRADNOMJESTO.Caption = "Šifra radnog mjesta";
                this.columnIDRADNOMJESTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("IsKey", "false");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Description", "Šifra radnog mjesta");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Length", "5");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNOMJESTO");
                this.Columns.Add(this.columnIDRADNOMJESTO);
                this.columnNAZIVRADNOMJESTO = new DataColumn("NAZIVRADNOMJESTO", typeof(string), "", MappingType.Element);
                this.columnNAZIVRADNOMJESTO.AllowDBNull = true;
                this.columnNAZIVRADNOMJESTO.Caption = "Naziv radnog mjesta";
                this.columnNAZIVRADNOMJESTO.MaxLength = 50;
                this.columnNAZIVRADNOMJESTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
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
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = new DataColumn("TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", typeof(int), "", MappingType.Element);
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.AllowDBNull = true;
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Caption = "Šifra stručne spreme";
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("SuperType", "IDSTRUCNASPREMA");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("SubtypeGroup", "TRENUTNASTRUCNASPREMA");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("IsKey", "false");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Description", "Šifra stručne spreme");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Length", "5");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Decimals", "0");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("IsInReader", "true");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.InternalName", "TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA");
                this.Columns.Add(this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA);
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA = new DataColumn("TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA", typeof(string), "", MappingType.Element);
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.AllowDBNull = true;
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.Caption = "Naziv stručne spreme";
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.MaxLength = 50;
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("SuperType", "NAZIVSTRUCNASPREMA");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("SubtypeGroup", "TRENUTNASTRUCNASPREMA");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("IsKey", "false");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Description", "Naziv stručne spreme");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Length", "50");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Decimals", "0");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("IsInReader", "true");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.InternalName", "TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA");
                this.Columns.Add(this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA);
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA = new DataColumn("POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", typeof(int), "", MappingType.Element);
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.AllowDBNull = true;
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Caption = "Šifra potrebne stručne spreme";
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("SuperType", "IDSTRUCNASPREMA");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("SubtypeGroup", "POTREBNASTRUCNASPREMA");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Description", "Šifra potrebne stručne spreme");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Length", "5");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.InternalName", "POTREBNASTRUCNASPREMAIDSTRUCNASPREMA");
                this.Columns.Add(this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA);
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA = new DataColumn("POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA", typeof(string), "", MappingType.Element);
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.AllowDBNull = true;
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.Caption = "Naziv potrebne stručne spreme";
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.MaxLength = 50;
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("SuperType", "NAZIVSTRUCNASPREMA");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("SubtypeGroup", "POTREBNASTRUCNASPREMA");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Description", "Naziv potrebne stručne spreme");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Length", "50");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.InternalName", "POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA");
                this.Columns.Add(this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA);
                this.columnIDSTRUKA = new DataColumn("IDSTRUKA", typeof(int), "", MappingType.Element);
                this.columnIDSTRUKA.AllowDBNull = true;
                this.columnIDSTRUKA.Caption = "Šifra struke";
                this.columnIDSTRUKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSTRUKA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDSTRUKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSTRUKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSTRUKA.ExtendedProperties.Add("Description", "Šifra struke");
                this.columnIDSTRUKA.ExtendedProperties.Add("Length", "5");
                this.columnIDSTRUKA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSTRUKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDSTRUKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.InternalName", "IDSTRUKA");
                this.Columns.Add(this.columnIDSTRUKA);
                this.columnNAZIVSTRUKA = new DataColumn("NAZIVSTRUKA", typeof(string), "", MappingType.Element);
                this.columnNAZIVSTRUKA.AllowDBNull = true;
                this.columnNAZIVSTRUKA.Caption = "Naziv struke";
                this.columnNAZIVSTRUKA.MaxLength = 50;
                this.columnNAZIVSTRUKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Description", "Naziv struke");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVSTRUKA");
                this.Columns.Add(this.columnNAZIVSTRUKA);
                this.columnIDBRACNOSTANJE = new DataColumn("IDBRACNOSTANJE", typeof(int), "", MappingType.Element);
                this.columnIDBRACNOSTANJE.AllowDBNull = true;
                this.columnIDBRACNOSTANJE.Caption = "Šifra bračnog stanja";
                this.columnIDBRACNOSTANJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Description", "Šifra bračnog stanja");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Length", "5");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.InternalName", "IDBRACNOSTANJE");
                this.Columns.Add(this.columnIDBRACNOSTANJE);
                this.columnNAZIVBRACNOSTANJE = new DataColumn("NAZIVBRACNOSTANJE", typeof(string), "", MappingType.Element);
                this.columnNAZIVBRACNOSTANJE.AllowDBNull = true;
                this.columnNAZIVBRACNOSTANJE.Caption = "Naziv bračnog stanja";
                this.columnNAZIVBRACNOSTANJE.MaxLength = 50;
                this.columnNAZIVBRACNOSTANJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Description", "Naziv bračnog stanja");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBRACNOSTANJE");
                this.Columns.Add(this.columnNAZIVBRACNOSTANJE);
                this.columnIDORGDIO = new DataColumn("IDORGDIO", typeof(int), "", MappingType.Element);
                this.columnIDORGDIO.AllowDBNull = true;
                this.columnIDORGDIO.Caption = "Šifra organizacijske jedinice";
                this.columnIDORGDIO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDORGDIO.ExtendedProperties.Add("IsKey", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDORGDIO.ExtendedProperties.Add("Description", "Šifra organizacijske jedinice");
                this.columnIDORGDIO.ExtendedProperties.Add("Length", "5");
                this.columnIDORGDIO.ExtendedProperties.Add("Decimals", "0");
                this.columnIDORGDIO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.InternalName", "IDORGDIO");
                this.Columns.Add(this.columnIDORGDIO);
                this.columnORGANIZACIJSKIDIO = new DataColumn("ORGANIZACIJSKIDIO", typeof(string), "", MappingType.Element);
                this.columnORGANIZACIJSKIDIO.AllowDBNull = true;
                this.columnORGANIZACIJSKIDIO.Caption = "Naziv organizacijske jedinice";
                this.columnORGANIZACIJSKIDIO.MaxLength = 50;
                this.columnORGANIZACIJSKIDIO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("IsKey", "false");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Description", "Naziv organizacijske jedinice");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Length", "50");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Decimals", "0");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("IsInReader", "true");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.InternalName", "ORGANIZACIJSKIDIO");
                this.Columns.Add(this.columnORGANIZACIJSKIDIO);
                this.columnUKUPNOGODINESTAZA = new DataColumn("UKUPNOGODINESTAZA", typeof(short), "", MappingType.Element);
                this.columnUKUPNOGODINESTAZA.AllowDBNull = true;
                this.columnUKUPNOGODINESTAZA.Caption = "UKUPNOGODINESTAZA";
                this.columnUKUPNOGODINESTAZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("Description", "Ukupno godina staža");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("Length", "2");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("Decimals", "0");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOGODINESTAZA.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOGODINESTAZA");
                this.Columns.Add(this.columnUKUPNOGODINESTAZA);
                this.columnUKUPNOMJESECISTAZA = new DataColumn("UKUPNOMJESECISTAZA", typeof(short), "", MappingType.Element);
                this.columnUKUPNOMJESECISTAZA.AllowDBNull = true;
                this.columnUKUPNOMJESECISTAZA.Caption = "UKUPNOMJESECISTAZA";
                this.columnUKUPNOMJESECISTAZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("Description", "Ukupno mjeseci staža");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("Length", "2");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("Decimals", "0");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNOMJESECISTAZA.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNOMJESECISTAZA");
                this.Columns.Add(this.columnUKUPNOMJESECISTAZA);
                this.columnUKUPNODANASTAZA = new DataColumn("UKUPNODANASTAZA", typeof(short), "", MappingType.Element);
                this.columnUKUPNODANASTAZA.AllowDBNull = true;
                this.columnUKUPNODANASTAZA.Caption = "UKUPNODANASTAZA";
                this.columnUKUPNODANASTAZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("Description", "Ukupno dana staža");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("Length", "3");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("Decimals", "0");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNODANASTAZA.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNODANASTAZA");
                this.Columns.Add(this.columnUKUPNODANASTAZA);
                this.columnBROJPRIZNATIHMJESECI = new DataColumn("BROJPRIZNATIHMJESECI", typeof(short), "", MappingType.Element);
                this.columnBROJPRIZNATIHMJESECI.AllowDBNull = true;
                this.columnBROJPRIZNATIHMJESECI.Caption = "Broj priznatih mjeseci za 12 mjeseci rada";
                this.columnBROJPRIZNATIHMJESECI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Description", "Broj priznatih mjeseci za 12 mjeseci rada");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Length", "2");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.InternalName", "BROJPRIZNATIHMJESECI");
                this.Columns.Add(this.columnBROJPRIZNATIHMJESECI);
                this.columnMO = new DataColumn("MO", typeof(string), "", MappingType.Element);
                this.columnMO.AllowDBNull = true;
                this.columnMO.Caption = "MO";
                this.columnMO.MaxLength = 2;
                this.columnMO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMO.ExtendedProperties.Add("IsKey", "false");
                this.columnMO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMO.ExtendedProperties.Add("Description", "Model odobrenja kod pojedinačne uplate na tekući");
                this.columnMO.ExtendedProperties.Add("Length", "2");
                this.columnMO.ExtendedProperties.Add("Decimals", "0");
                this.columnMO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMO.ExtendedProperties.Add("IsInReader", "true");
                this.columnMO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMO.ExtendedProperties.Add("Deklarit.InternalName", "MO");
                this.Columns.Add(this.columnMO);
                this.columnPBO = new DataColumn("PBO", typeof(string), "", MappingType.Element);
                this.columnPBO.AllowDBNull = true;
                this.columnPBO.Caption = "PBO";
                this.columnPBO.MaxLength = 0x16;
                this.columnPBO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPBO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPBO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPBO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPBO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPBO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPBO.ExtendedProperties.Add("IsKey", "false");
                this.columnPBO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPBO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPBO.ExtendedProperties.Add("Description", "Poziv na broj odobrenja kod pojedinačne uplate na tekući");
                this.columnPBO.ExtendedProperties.Add("Length", "22");
                this.columnPBO.ExtendedProperties.Add("Decimals", "0");
                this.columnPBO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPBO.ExtendedProperties.Add("IsInReader", "true");
                this.columnPBO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPBO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPBO.ExtendedProperties.Add("Deklarit.InternalName", "PBO");
                this.Columns.Add(this.columnPBO);
                this.columnGODINESTAZAPRO = new DataColumn("GODINESTAZAPRO", typeof(short), "", MappingType.Element);
                this.columnGODINESTAZAPRO.AllowDBNull = false;
                this.columnGODINESTAZAPRO.Caption = "GODINESTAZAPRO";
                this.columnGODINESTAZAPRO.DefaultValue = 0;
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("Description", "Godine staža (do datuma)  - jubilarne");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("Length", "2");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINESTAZAPRO.ExtendedProperties.Add("Deklarit.InternalName", "GODINESTAZAPRO");
                this.Columns.Add(this.columnGODINESTAZAPRO);
                this.columnMJESECISTAZAPRO = new DataColumn("MJESECISTAZAPRO", typeof(short), "", MappingType.Element);
                this.columnMJESECISTAZAPRO.AllowDBNull = false;
                this.columnMJESECISTAZAPRO.Caption = "MJESECISTAZAPRO";
                this.columnMJESECISTAZAPRO.DefaultValue = 0;
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("IsKey", "false");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("Description", "Mjeseci staža (do datuma) - jubilarne");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("Length", "2");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESECISTAZAPRO.ExtendedProperties.Add("Deklarit.InternalName", "MJESECISTAZAPRO");
                this.Columns.Add(this.columnMJESECISTAZAPRO);
                this.columnDANISTAZAPRO = new DataColumn("DANISTAZAPRO", typeof(short), "", MappingType.Element);
                this.columnDANISTAZAPRO.AllowDBNull = false;
                this.columnDANISTAZAPRO.Caption = "DANISTAZAPRO";
                this.columnDANISTAZAPRO.DefaultValue = 0;
                this.columnDANISTAZAPRO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("IsKey", "false");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("Description", "Dani staža (do datuma) - jubilarne");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("Length", "3");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("Decimals", "0");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("IsInReader", "true");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDANISTAZAPRO.ExtendedProperties.Add("Deklarit.InternalName", "DANISTAZAPRO");
                this.Columns.Add(this.columnDANISTAZAPRO);
                this.columnUKUPNIFAKTOR = new DataColumn("UKUPNIFAKTOR", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNIFAKTOR.AllowDBNull = true;
                this.columnUKUPNIFAKTOR.Caption = "UKUPNIFAKTOR";
                this.columnUKUPNIFAKTOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Description", "Ukupni faktor osobnog odbitka");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Length", "5");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNIFAKTOR.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNIFAKTOR");
                this.Columns.Add(this.columnUKUPNIFAKTOR);
                this.columnIDDRZAVLJANSTVO = new DataColumn("IDDRZAVLJANSTVO", typeof(int), "", MappingType.Element);
                this.columnIDDRZAVLJANSTVO.AllowDBNull = true;
                this.columnIDDRZAVLJANSTVO.Caption = "IDDRZAVLJANSTVO";
                this.columnIDDRZAVLJANSTVO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("IsKey", "false");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Description", "Državljanstvo");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Length", "5");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Decimals", "0");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.InternalName", "IDDRZAVLJANSTVO");
                this.Columns.Add(this.columnIDDRZAVLJANSTVO);
                this.columnNAZIVDRZAVLJANSTVO = new DataColumn("NAZIVDRZAVLJANSTVO", typeof(string), "", MappingType.Element);
                this.columnNAZIVDRZAVLJANSTVO.AllowDBNull = true;
                this.columnNAZIVDRZAVLJANSTVO.Caption = "NAZIVDRZAVLJANSTVO";
                this.columnNAZIVDRZAVLJANSTVO.MaxLength = 50;
                this.columnNAZIVDRZAVLJANSTVO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Description", "NAZIVDRZAVLJANSTVO");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVDRZAVLJANSTVO");
                this.Columns.Add(this.columnNAZIVDRZAVLJANSTVO);
                this.columnRADNADOZVOLA = new DataColumn("RADNADOZVOLA", typeof(string), "", MappingType.Element);
                this.columnRADNADOZVOLA.AllowDBNull = true;
                this.columnRADNADOZVOLA.Caption = "RADNADOZVOLA";
                this.columnRADNADOZVOLA.MaxLength = 50;
                this.columnRADNADOZVOLA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRADNADOZVOLA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("IsKey", "false");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("Description", "Podaci o radnoj dozboli");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("Length", "50");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("Decimals", "0");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("IsInReader", "true");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRADNADOZVOLA.ExtendedProperties.Add("Deklarit.InternalName", "RADNADOZVOLA");
                this.Columns.Add(this.columnRADNADOZVOLA);
                this.columnZAVRSENASKOLA = new DataColumn("ZAVRSENASKOLA", typeof(string), "", MappingType.Element);
                this.columnZAVRSENASKOLA.AllowDBNull = true;
                this.columnZAVRSENASKOLA.Caption = "ZAVRSENASKOLA";
                this.columnZAVRSENASKOLA.MaxLength = 50;
                this.columnZAVRSENASKOLA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("IsKey", "false");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("Description", "Završena škola");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("Length", "50");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("Decimals", "0");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("IsInReader", "true");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZAVRSENASKOLA.ExtendedProperties.Add("Deklarit.InternalName", "ZAVRSENASKOLA");
                this.Columns.Add(this.columnZAVRSENASKOLA);
                this.columnUGOVOROD = new DataColumn("UGOVOROD", typeof(DateTime), "", MappingType.Element);
                this.columnUGOVOROD.AllowDBNull = true;
                this.columnUGOVOROD.Caption = "UGOVOROD";
                this.columnUGOVOROD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUGOVOROD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUGOVOROD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUGOVOROD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUGOVOROD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUGOVOROD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUGOVOROD.ExtendedProperties.Add("IsKey", "false");
                this.columnUGOVOROD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnUGOVOROD.ExtendedProperties.Add("DeklaritType", "date");
                this.columnUGOVOROD.ExtendedProperties.Add("Description", "Datum sklapanja ugovora o radu");
                this.columnUGOVOROD.ExtendedProperties.Add("Length", "8");
                this.columnUGOVOROD.ExtendedProperties.Add("Decimals", "0");
                this.columnUGOVOROD.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUGOVOROD.ExtendedProperties.Add("IsInReader", "true");
                this.columnUGOVOROD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUGOVOROD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUGOVOROD.ExtendedProperties.Add("Deklarit.InternalName", "UGOVOROD");
                this.Columns.Add(this.columnUGOVOROD);
                this.columnPOCETAKRADA = new DataColumn("POCETAKRADA", typeof(DateTime), "", MappingType.Element);
                this.columnPOCETAKRADA.AllowDBNull = true;
                this.columnPOCETAKRADA.Caption = "POCETAKRADA";
                this.columnPOCETAKRADA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOCETAKRADA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOCETAKRADA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOCETAKRADA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOCETAKRADA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOCETAKRADA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOCETAKRADA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOCETAKRADA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOCETAKRADA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnPOCETAKRADA.ExtendedProperties.Add("Description", "Datum početka rada");
                this.columnPOCETAKRADA.ExtendedProperties.Add("Length", "8");
                this.columnPOCETAKRADA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOCETAKRADA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOCETAKRADA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOCETAKRADA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOCETAKRADA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOCETAKRADA.ExtendedProperties.Add("Deklarit.InternalName", "POCETAKRADA");
                this.Columns.Add(this.columnPOCETAKRADA);
                this.columnNAZIVPOSLA = new DataColumn("NAZIVPOSLA", typeof(string), "", MappingType.Element);
                this.columnNAZIVPOSLA.AllowDBNull = true;
                this.columnNAZIVPOSLA.Caption = "NAZIVPOSLA";
                this.columnNAZIVPOSLA.MaxLength = 50;
                this.columnNAZIVPOSLA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPOSLA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("Description", "Naziv posla / narav i vrsta");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPOSLA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPOSLA");
                this.Columns.Add(this.columnNAZIVPOSLA);
                this.columnIDUGOVORORADU = new DataColumn("IDUGOVORORADU", typeof(int), "", MappingType.Element);
                this.columnIDUGOVORORADU.AllowDBNull = true;
                this.columnIDUGOVORORADU.Caption = "IDUGOVORORADU";
                this.columnIDUGOVORORADU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("IsKey", "false");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Description", "Ugovor sklopljen na");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Length", "5");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Decimals", "0");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.InternalName", "IDUGOVORORADU");
                this.Columns.Add(this.columnIDUGOVORORADU);
                this.columnNAZIVUGOVORORADU = new DataColumn("NAZIVUGOVORORADU", typeof(string), "", MappingType.Element);
                this.columnNAZIVUGOVORORADU.AllowDBNull = true;
                this.columnNAZIVUGOVORORADU.Caption = "NAZIVUGOVORORADU";
                this.columnNAZIVUGOVORORADU.MaxLength = 20;
                this.columnNAZIVUGOVORORADU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Description", "NAZIVUGOVORORADU");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVUGOVORORADU");
                this.Columns.Add(this.columnNAZIVUGOVORORADU);
                this.columnVRIJEMEPROBNOGRADA = new DataColumn("VRIJEMEPROBNOGRADA", typeof(string), "", MappingType.Element);
                this.columnVRIJEMEPROBNOGRADA.AllowDBNull = true;
                this.columnVRIJEMEPROBNOGRADA.Caption = "VRIJEMEPROBNOGRADA";
                this.columnVRIJEMEPROBNOGRADA.MaxLength = 30;
                this.columnVRIJEMEPROBNOGRADA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("IsKey", "false");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("Description", "Vrijeme trajanja probnog rada");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("Length", "30");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("Decimals", "0");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("IsInReader", "true");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVRIJEMEPROBNOGRADA.ExtendedProperties.Add("Deklarit.InternalName", "VRIJEMEPROBNOGRADA");
                this.Columns.Add(this.columnVRIJEMEPROBNOGRADA);
                this.columnVRIJEMEPRIPRAVNICKOG = new DataColumn("VRIJEMEPRIPRAVNICKOG", typeof(string), "", MappingType.Element);
                this.columnVRIJEMEPRIPRAVNICKOG.AllowDBNull = true;
                this.columnVRIJEMEPRIPRAVNICKOG.Caption = "VRIJEMEPRIPRAVNICKOG";
                this.columnVRIJEMEPRIPRAVNICKOG.MaxLength = 30;
                this.columnVRIJEMEPRIPRAVNICKOG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("IsKey", "false");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("Description", "Vrijeme trajanja pripravničkog");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("Length", "30");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("Decimals", "0");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("IsInReader", "true");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVRIJEMEPRIPRAVNICKOG.ExtendedProperties.Add("Deklarit.InternalName", "VRIJEMEPRIPRAVNICKOG");
                this.Columns.Add(this.columnVRIJEMEPRIPRAVNICKOG);
                this.columnVRIJEMESTRUCNI = new DataColumn("VRIJEMESTRUCNI", typeof(string), "", MappingType.Element);
                this.columnVRIJEMESTRUCNI.AllowDBNull = true;
                this.columnVRIJEMESTRUCNI.Caption = "VRIJEMESTRUCNI";
                this.columnVRIJEMESTRUCNI.MaxLength = 50;
                this.columnVRIJEMESTRUCNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("IsKey", "false");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("Description", "Vrijeme i rezultat polaganja stručnog");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("Length", "50");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("Decimals", "0");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("IsInReader", "true");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVRIJEMESTRUCNI.ExtendedProperties.Add("Deklarit.InternalName", "VRIJEMESTRUCNI");
                this.Columns.Add(this.columnVRIJEMESTRUCNI);
                this.columnRADUINOZEMSTVU = new DataColumn("RADUINOZEMSTVU", typeof(string), "", MappingType.Element);
                this.columnRADUINOZEMSTVU.AllowDBNull = true;
                this.columnRADUINOZEMSTVU.Caption = "RADUINOZEMSTVU";
                this.columnRADUINOZEMSTVU.MaxLength = 50;
                this.columnRADUINOZEMSTVU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("IsKey", "false");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("Description", "Rad u inozemstvu");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("Length", "50");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("Decimals", "0");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("IsInReader", "true");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRADUINOZEMSTVU.ExtendedProperties.Add("Deklarit.InternalName", "RADUINOZEMSTVU");
                this.Columns.Add(this.columnRADUINOZEMSTVU);
                this.columnRADNASPOSOBNOST = new DataColumn("RADNASPOSOBNOST", typeof(string), "", MappingType.Element);
                this.columnRADNASPOSOBNOST.AllowDBNull = true;
                this.columnRADNASPOSOBNOST.Caption = "RADNASPOSOBNOST";
                this.columnRADNASPOSOBNOST.MaxLength = 30;
                this.columnRADNASPOSOBNOST.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("IsKey", "false");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("Description", "Potrebno prethodno/redovito utvrđivanje radne sposobnosti");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("Length", "30");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("Decimals", "0");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("IsInReader", "true");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRADNASPOSOBNOST.ExtendedProperties.Add("Deklarit.InternalName", "RADNASPOSOBNOST");
                this.Columns.Add(this.columnRADNASPOSOBNOST);
                this.columnVRIJEMEMIROVANJARADNOGODNOSA = new DataColumn("VRIJEMEMIROVANJARADNOGODNOSA", typeof(string), "", MappingType.Element);
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.AllowDBNull = true;
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.Caption = "VRIJEMEMIROVANJARADNOGODNOSA";
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.MaxLength = 30;
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("Description", "Vrijeme mirovanja radnog odnosa");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("Length", "30");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVRIJEMEMIROVANJARADNOGODNOSA.ExtendedProperties.Add("Deklarit.InternalName", "VRIJEMEMIROVANJARADNOGODNOSA");
                this.Columns.Add(this.columnVRIJEMEMIROVANJARADNOGODNOSA);
                this.columnRAZLOGPRESTANKA = new DataColumn("RAZLOGPRESTANKA", typeof(string), "", MappingType.Element);
                this.columnRAZLOGPRESTANKA.AllowDBNull = true;
                this.columnRAZLOGPRESTANKA.Caption = "RAZLOGPRESTANKA";
                this.columnRAZLOGPRESTANKA.MaxLength = 30;
                this.columnRAZLOGPRESTANKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("IsKey", "false");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("Description", "Razlog prestanka radnog odnosa");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("Length", "30");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("Decimals", "0");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAZLOGPRESTANKA.ExtendedProperties.Add("Deklarit.InternalName", "RAZLOGPRESTANKA");
                this.Columns.Add(this.columnRAZLOGPRESTANKA);
                this.columnZABRANANATJECANJA = new DataColumn("ZABRANANATJECANJA", typeof(string), "", MappingType.Element);
                this.columnZABRANANATJECANJA.AllowDBNull = true;
                this.columnZABRANANATJECANJA.Caption = "ZABRANANATJECANJA";
                this.columnZABRANANATJECANJA.MaxLength = 50;
                this.columnZABRANANATJECANJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("Description", "Ugovorena zabrana natjecanja i trajanje");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("Length", "50");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZABRANANATJECANJA.ExtendedProperties.Add("Deklarit.InternalName", "ZABRANANATJECANJA");
                this.Columns.Add(this.columnZABRANANATJECANJA);
                this.columnPRODUZENOMIROVINSKO = new DataColumn("PRODUZENOMIROVINSKO", typeof(string), "", MappingType.Element);
                this.columnPRODUZENOMIROVINSKO.AllowDBNull = true;
                this.columnPRODUZENOMIROVINSKO.Caption = "PRODUZENOMIROVINSKO";
                this.columnPRODUZENOMIROVINSKO.MaxLength = 50;
                this.columnPRODUZENOMIROVINSKO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("IsKey", "false");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("Description", "Uvjeti i vrijeme za koje se uplaćuju dop.za mir.");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("Length", "50");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("Decimals", "0");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRODUZENOMIROVINSKO.ExtendedProperties.Add("Deklarit.InternalName", "PRODUZENOMIROVINSKO");
                this.Columns.Add(this.columnPRODUZENOMIROVINSKO);
                this.columnRADNIKNAPOMENA = new DataColumn("RADNIKNAPOMENA", typeof(string), "", MappingType.Element);
                this.columnRADNIKNAPOMENA.AllowDBNull = true;
                this.columnRADNIKNAPOMENA.Caption = "RADNIKNAPOMENA";
                this.columnRADNIKNAPOMENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("IsKey", "false");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("DeklaritType", "vchar");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("Description", "Napomena");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("Length", "5");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("Decimals", "0");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("IsInReader", "true");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRADNIKNAPOMENA.ExtendedProperties.Add("Deklarit.InternalName", "RADNIKNAPOMENA");
                this.Columns.Add(this.columnRADNIKNAPOMENA);
                this.columnIDRADNOVRIJEME = new DataColumn("IDRADNOVRIJEME", typeof(int), "", MappingType.Element);
                this.columnIDRADNOVRIJEME.AllowDBNull = true;
                this.columnIDRADNOVRIJEME.Caption = "IDRADNOVRIJEME";
                this.columnIDRADNOVRIJEME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("IsKey", "false");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Description", "IDRADNOVRIJEME");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Length", "5");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNOVRIJEME");
                this.Columns.Add(this.columnIDRADNOVRIJEME);
                this.columnIDSPOL = new DataColumn("IDSPOL", typeof(int), "", MappingType.Element);
                this.columnIDSPOL.AllowDBNull = false;
                this.columnIDSPOL.Caption = "IDSPOL";
                this.columnIDSPOL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSPOL.ExtendedProperties.Add("IsKey", "false");
                this.columnIDSPOL.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSPOL.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSPOL.ExtendedProperties.Add("Description", "Šifra spola");
                this.columnIDSPOL.ExtendedProperties.Add("Length", "5");
                this.columnIDSPOL.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSPOL.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSPOL.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.InternalName", "IDSPOL");
                this.Columns.Add(this.columnIDSPOL);
                this.columnNAZIVSPOL = new DataColumn("NAZIVSPOL", typeof(string), "", MappingType.Element);
                this.columnNAZIVSPOL.AllowDBNull = true;
                this.columnNAZIVSPOL.Caption = "NAZIVSPOL";
                this.columnNAZIVSPOL.MaxLength = 20;
                this.columnNAZIVSPOL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVSPOL.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVSPOL.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVSPOL.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Description", "Spol");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVSPOL.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVSPOL.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVSPOL");
                this.Columns.Add(this.columnNAZIVSPOL);
                this.columnIDIPIDENT = new DataColumn("IDIPIDENT", typeof(int), "", MappingType.Element);
                this.columnIDIPIDENT.AllowDBNull = false;
                this.columnIDIPIDENT.Caption = "IDIPIDENT";
                this.columnIDIPIDENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDIPIDENT.ExtendedProperties.Add("IsKey", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDIPIDENT.ExtendedProperties.Add("Description", "Šifra IP-a");
                this.columnIDIPIDENT.ExtendedProperties.Add("Length", "5");
                this.columnIDIPIDENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDIPIDENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.InternalName", "IDIPIDENT");
                this.Columns.Add(this.columnIDIPIDENT);
                this.columnNAZIVIPIDENT = new DataColumn("NAZIVIPIDENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVIPIDENT.AllowDBNull = true;
                this.columnNAZIVIPIDENT.Caption = "NAZIVIPIDENT";
                this.columnNAZIVIPIDENT.MaxLength = 20;
                this.columnNAZIVIPIDENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Description", "Naziv IP-a");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVIPIDENT");
                this.Columns.Add(this.columnNAZIVIPIDENT);
                this.PrimaryKey = new DataColumn[] { this.columnIDRADNIK };
                this.Constraints.Add("Unique_JMBG", new DataColumn[] { this.columnJMBG }, false);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RADNIK");
                this.ExtendedProperties.Add("Description", "Zaposlenici");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnSPOJENOPREZIME = this.Columns["SPOJENOPREZIME"];
                this.columnAKTIVAN = this.Columns["AKTIVAN"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnOIB = this.Columns["OIB"];
                this.columnJMBG = this.Columns["JMBG"];
                this.columnDATUMRODJENJA = this.Columns["DATUMRODJENJA"];
                this.columnulica = this.Columns["ulica"];
                this.columnmjesto = this.Columns["mjesto"];
                this.columnkucnibroj = this.Columns["kucnibroj"];
                this.columnOPCINARADAIDOPCINE = this.Columns["OPCINARADAIDOPCINE"];
                this.columnOPCINARADANAZIVOPCINE = this.Columns["OPCINARADANAZIVOPCINE"];
                this.columnOPCINASTANOVANJAIDOPCINE = this.Columns["OPCINASTANOVANJAIDOPCINE"];
                this.columnOPCINASTANOVANJANAZIVOPCINE = this.Columns["OPCINASTANOVANJANAZIVOPCINE"];
                this.columnOPCINASTANOVANJAPRIREZ = this.Columns["OPCINASTANOVANJAPRIREZ"];
                this.columnOPCINASTANOVANJAVBDIOPCINA = this.Columns["OPCINASTANOVANJAVBDIOPCINA"];
                this.columnOPCINASTANOVANJAZRNOPCINA = this.Columns["OPCINASTANOVANJAZRNOPCINA"];
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = this.Columns["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"];
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA = this.Columns["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"];
                this.columnIDBANKE = this.Columns["IDBANKE"];
                this.columnNAZIVBANKE1 = this.Columns["NAZIVBANKE1"];
                this.columnNAZIVBANKE2 = this.Columns["NAZIVBANKE2"];
                this.columnNAZIVBANKE3 = this.Columns["NAZIVBANKE3"];
                this.columnVBDIBANKE = this.Columns["VBDIBANKE"];
                this.columnZRNBANKE = this.Columns["ZRNBANKE"];
                this.columnTEKUCI = this.Columns["TEKUCI"];
                this.columnZBIRNINETO = this.Columns["ZBIRNINETO"];
                this.columnSIFRAOPISAPLACANJANETO = this.Columns["SIFRAOPISAPLACANJANETO"];
                this.columnOPISPLACANJANETO = this.Columns["OPISPLACANJANETO"];
                this.columnTJEDNIFONDSATI = this.Columns["TJEDNIFONDSATI"];
                this.columnKOEFICIJENT = this.Columns["KOEFICIJENT"];
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA = this.Columns["POSTOTAKOSLOBODJENJAODPOREZA"];
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA = this.Columns["UZIMAUOBZIROSNOVICEDOPRINOSA"];
                this.columnTJEDNIFONDSATISTAZ = this.Columns["TJEDNIFONDSATISTAZ"];
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = this.Columns["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"];
                this.columnGODINESTAZA = this.Columns["GODINESTAZA"];
                this.columnMJESECISTAZA = this.Columns["MJESECISTAZA"];
                this.columnDANISTAZA = this.Columns["DANISTAZA"];
                this.columnIDBENEFICIRANI = this.Columns["IDBENEFICIRANI"];
                this.columnNAZIVBENEFICIRANI = this.Columns["NAZIVBENEFICIRANI"];
                this.columnDATUMPRESTANKARADNOGODNOSA = this.Columns["DATUMPRESTANKARADNOGODNOSA"];
                this.columnBROJMIROVINSKOG = this.Columns["BROJMIROVINSKOG"];
                this.columnBROJZDRAVSTVENOG = this.Columns["BROJZDRAVSTVENOG"];
                this.columnMBO = this.Columns["MBO"];
                this.columnIDTITULA = this.Columns["IDTITULA"];
                this.columnNAZIVTITULA = this.Columns["NAZIVTITULA"];
                this.columnIDRADNOMJESTO = this.Columns["IDRADNOMJESTO"];
                this.columnNAZIVRADNOMJESTO = this.Columns["NAZIVRADNOMJESTO"];
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = this.Columns["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"];
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA = this.Columns["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"];
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA = this.Columns["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"];
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA = this.Columns["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"];
                this.columnIDSTRUKA = this.Columns["IDSTRUKA"];
                this.columnNAZIVSTRUKA = this.Columns["NAZIVSTRUKA"];
                this.columnIDBRACNOSTANJE = this.Columns["IDBRACNOSTANJE"];
                this.columnNAZIVBRACNOSTANJE = this.Columns["NAZIVBRACNOSTANJE"];
                this.columnIDORGDIO = this.Columns["IDORGDIO"];
                this.columnORGANIZACIJSKIDIO = this.Columns["ORGANIZACIJSKIDIO"];
                this.columnUKUPNOGODINESTAZA = this.Columns["UKUPNOGODINESTAZA"];
                this.columnUKUPNOMJESECISTAZA = this.Columns["UKUPNOMJESECISTAZA"];
                this.columnUKUPNODANASTAZA = this.Columns["UKUPNODANASTAZA"];
                this.columnBROJPRIZNATIHMJESECI = this.Columns["BROJPRIZNATIHMJESECI"];
                this.columnMO = this.Columns["MO"];
                this.columnPBO = this.Columns["PBO"];
                this.columnGODINESTAZAPRO = this.Columns["GODINESTAZAPRO"];
                this.columnMJESECISTAZAPRO = this.Columns["MJESECISTAZAPRO"];
                this.columnDANISTAZAPRO = this.Columns["DANISTAZAPRO"];
                this.columnUKUPNIFAKTOR = this.Columns["UKUPNIFAKTOR"];
                this.columnIDDRZAVLJANSTVO = this.Columns["IDDRZAVLJANSTVO"];
                this.columnNAZIVDRZAVLJANSTVO = this.Columns["NAZIVDRZAVLJANSTVO"];
                this.columnRADNADOZVOLA = this.Columns["RADNADOZVOLA"];
                this.columnZAVRSENASKOLA = this.Columns["ZAVRSENASKOLA"];
                this.columnUGOVOROD = this.Columns["UGOVOROD"];
                this.columnPOCETAKRADA = this.Columns["POCETAKRADA"];
                this.columnNAZIVPOSLA = this.Columns["NAZIVPOSLA"];
                this.columnIDUGOVORORADU = this.Columns["IDUGOVORORADU"];
                this.columnNAZIVUGOVORORADU = this.Columns["NAZIVUGOVORORADU"];
                this.columnVRIJEMEPROBNOGRADA = this.Columns["VRIJEMEPROBNOGRADA"];
                this.columnVRIJEMEPRIPRAVNICKOG = this.Columns["VRIJEMEPRIPRAVNICKOG"];
                this.columnVRIJEMESTRUCNI = this.Columns["VRIJEMESTRUCNI"];
                this.columnRADUINOZEMSTVU = this.Columns["RADUINOZEMSTVU"];
                this.columnRADNASPOSOBNOST = this.Columns["RADNASPOSOBNOST"];
                this.columnVRIJEMEMIROVANJARADNOGODNOSA = this.Columns["VRIJEMEMIROVANJARADNOGODNOSA"];
                this.columnRAZLOGPRESTANKA = this.Columns["RAZLOGPRESTANKA"];
                this.columnZABRANANATJECANJA = this.Columns["ZABRANANATJECANJA"];
                this.columnPRODUZENOMIROVINSKO = this.Columns["PRODUZENOMIROVINSKO"];
                this.columnRADNIKNAPOMENA = this.Columns["RADNIKNAPOMENA"];
                this.columnIDRADNOVRIJEME = this.Columns["IDRADNOVRIJEME"];
                this.columnIDSPOL = this.Columns["IDSPOL"];
                this.columnNAZIVSPOL = this.Columns["NAZIVSPOL"];
                this.columnIDIPIDENT = this.Columns["IDIPIDENT"];
                this.columnNAZIVIPIDENT = this.Columns["NAZIVIPIDENT"];
            }

            public RADNIKDataSet.RADNIKRow NewRADNIKRow()
            {
                return (RADNIKDataSet.RADNIKRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RADNIKDataSet.RADNIKRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RADNIKRowChanged != null)
                {
                    RADNIKDataSet.RADNIKRowChangeEventHandler rADNIKRowChangedEvent = this.RADNIKRowChanged;
                    if (rADNIKRowChangedEvent != null)
                    {
                        rADNIKRowChangedEvent(this, new RADNIKDataSet.RADNIKRowChangeEvent((RADNIKDataSet.RADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RADNIKRowChanging != null)
                {
                    RADNIKDataSet.RADNIKRowChangeEventHandler rADNIKRowChangingEvent = this.RADNIKRowChanging;
                    if (rADNIKRowChangingEvent != null)
                    {
                        rADNIKRowChangingEvent(this, new RADNIKDataSet.RADNIKRowChangeEvent((RADNIKDataSet.RADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RADNIKRowDeleted != null)
                {
                    RADNIKDataSet.RADNIKRowChangeEventHandler rADNIKRowDeletedEvent = this.RADNIKRowDeleted;
                    if (rADNIKRowDeletedEvent != null)
                    {
                        rADNIKRowDeletedEvent(this, new RADNIKDataSet.RADNIKRowChangeEvent((RADNIKDataSet.RADNIKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RADNIKRowDeleting != null)
                {
                    RADNIKDataSet.RADNIKRowChangeEventHandler rADNIKRowDeletingEvent = this.RADNIKRowDeleting;
                    if (rADNIKRowDeletingEvent != null)
                    {
                        rADNIKRowDeletingEvent(this, new RADNIKDataSet.RADNIKRowChangeEvent((RADNIKDataSet.RADNIKRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRADNIKRow(RADNIKDataSet.RADNIKRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn AKTIVANColumn
            {
                get
                {
                    return this.columnAKTIVAN;
                }
            }

            public DataColumn BROJMIROVINSKOGColumn
            {
                get
                {
                    return this.columnBROJMIROVINSKOG;
                }
            }

            public DataColumn BROJPRIZNATIHMJESECIColumn
            {
                get
                {
                    return this.columnBROJPRIZNATIHMJESECI;
                }
            }

            public DataColumn BROJZDRAVSTVENOGColumn
            {
                get
                {
                    return this.columnBROJZDRAVSTVENOG;
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

            public DataColumn DANISTAZAColumn
            {
                get
                {
                    return this.columnDANISTAZA;
                }
            }

            public DataColumn DANISTAZAPROColumn
            {
                get
                {
                    return this.columnDANISTAZAPRO;
                }
            }

            public DataColumn DATUMPRESTANKARADNOGODNOSAColumn
            {
                get
                {
                    return this.columnDATUMPRESTANKARADNOGODNOSA;
                }
            }

            public DataColumn DATUMRODJENJAColumn
            {
                get
                {
                    return this.columnDATUMRODJENJA;
                }
            }

            public DataColumn DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIColumn
            {
                get
                {
                    return this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI;
                }
            }

            public DataColumn GODINESTAZAColumn
            {
                get
                {
                    return this.columnGODINESTAZA;
                }
            }

            public DataColumn GODINESTAZAPROColumn
            {
                get
                {
                    return this.columnGODINESTAZAPRO;
                }
            }

            public DataColumn IDBANKEColumn
            {
                get
                {
                    return this.columnIDBANKE;
                }
            }

            public DataColumn IDBENEFICIRANIColumn
            {
                get
                {
                    return this.columnIDBENEFICIRANI;
                }
            }

            public DataColumn IDBRACNOSTANJEColumn
            {
                get
                {
                    return this.columnIDBRACNOSTANJE;
                }
            }

            public DataColumn IDDRZAVLJANSTVOColumn
            {
                get
                {
                    return this.columnIDDRZAVLJANSTVO;
                }
            }

            public DataColumn IDIPIDENTColumn
            {
                get
                {
                    return this.columnIDIPIDENT;
                }
            }

            public DataColumn IDORGDIOColumn
            {
                get
                {
                    return this.columnIDORGDIO;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public DataColumn IDRADNOMJESTOColumn
            {
                get
                {
                    return this.columnIDRADNOMJESTO;
                }
            }

            public DataColumn IDRADNOVRIJEMEColumn
            {
                get
                {
                    return this.columnIDRADNOVRIJEME;
                }
            }

            public DataColumn IDSPOLColumn
            {
                get
                {
                    return this.columnIDSPOL;
                }
            }

            public DataColumn IDSTRUKAColumn
            {
                get
                {
                    return this.columnIDSTRUKA;
                }
            }

            public DataColumn IDTITULAColumn
            {
                get
                {
                    return this.columnIDTITULA;
                }
            }

            public DataColumn IDUGOVORORADUColumn
            {
                get
                {
                    return this.columnIDUGOVORORADU;
                }
            }

            public DataColumn IMEColumn
            {
                get
                {
                    return this.columnIME;
                }
            }

            public RADNIKDataSet.RADNIKRow this[int index]
            {
                get
                {
                    return (RADNIKDataSet.RADNIKRow) this.Rows[index];
                }
            }

            public DataColumn JMBGColumn
            {
                get
                {
                    return this.columnJMBG;
                }
            }

            public DataColumn KOEFICIJENTColumn
            {
                get
                {
                    return this.columnKOEFICIJENT;
                }
            }

            public DataColumn kucnibrojColumn
            {
                get
                {
                    return this.columnkucnibroj;
                }
            }

            public DataColumn MBOColumn
            {
                get
                {
                    return this.columnMBO;
                }
            }

            public DataColumn MJESECISTAZAColumn
            {
                get
                {
                    return this.columnMJESECISTAZA;
                }
            }

            public DataColumn MJESECISTAZAPROColumn
            {
                get
                {
                    return this.columnMJESECISTAZAPRO;
                }
            }

            public DataColumn mjestoColumn
            {
                get
                {
                    return this.columnmjesto;
                }
            }

            public DataColumn MOColumn
            {
                get
                {
                    return this.columnMO;
                }
            }

            public DataColumn NAZIVBANKE1Column
            {
                get
                {
                    return this.columnNAZIVBANKE1;
                }
            }

            public DataColumn NAZIVBANKE2Column
            {
                get
                {
                    return this.columnNAZIVBANKE2;
                }
            }

            public DataColumn NAZIVBANKE3Column
            {
                get
                {
                    return this.columnNAZIVBANKE3;
                }
            }

            public DataColumn NAZIVBENEFICIRANIColumn
            {
                get
                {
                    return this.columnNAZIVBENEFICIRANI;
                }
            }

            public DataColumn NAZIVBRACNOSTANJEColumn
            {
                get
                {
                    return this.columnNAZIVBRACNOSTANJE;
                }
            }

            public DataColumn NAZIVDRZAVLJANSTVOColumn
            {
                get
                {
                    return this.columnNAZIVDRZAVLJANSTVO;
                }
            }

            public DataColumn NAZIVIPIDENTColumn
            {
                get
                {
                    return this.columnNAZIVIPIDENT;
                }
            }

            public DataColumn NAZIVPOSLAColumn
            {
                get
                {
                    return this.columnNAZIVPOSLA;
                }
            }

            public DataColumn NAZIVRADNOMJESTOColumn
            {
                get
                {
                    return this.columnNAZIVRADNOMJESTO;
                }
            }

            public DataColumn NAZIVSPOLColumn
            {
                get
                {
                    return this.columnNAZIVSPOL;
                }
            }

            public DataColumn NAZIVSTRUKAColumn
            {
                get
                {
                    return this.columnNAZIVSTRUKA;
                }
            }

            public DataColumn NAZIVTITULAColumn
            {
                get
                {
                    return this.columnNAZIVTITULA;
                }
            }

            public DataColumn NAZIVUGOVORORADUColumn
            {
                get
                {
                    return this.columnNAZIVUGOVORORADU;
                }
            }

            public DataColumn OIBColumn
            {
                get
                {
                    return this.columnOIB;
                }
            }

            public DataColumn OPCINARADAIDOPCINEColumn
            {
                get
                {
                    return this.columnOPCINARADAIDOPCINE;
                }
            }

            public DataColumn OPCINARADANAZIVOPCINEColumn
            {
                get
                {
                    return this.columnOPCINARADANAZIVOPCINE;
                }
            }

            public DataColumn OPCINASTANOVANJAIDOPCINEColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAIDOPCINE;
                }
            }

            public DataColumn OPCINASTANOVANJANAZIVOPCINEColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJANAZIVOPCINE;
                }
            }

            public DataColumn OPCINASTANOVANJAPRIREZColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAPRIREZ;
                }
            }

            public DataColumn OPCINASTANOVANJAVBDIOPCINAColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAVBDIOPCINA;
                }
            }

            public DataColumn OPCINASTANOVANJAZRNOPCINAColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAZRNOPCINA;
                }
            }

            public DataColumn OPISPLACANJANETOColumn
            {
                get
                {
                    return this.columnOPISPLACANJANETO;
                }
            }

            public DataColumn ORGANIZACIJSKIDIOColumn
            {
                get
                {
                    return this.columnORGANIZACIJSKIDIO;
                }
            }

            public DataColumn PBOColumn
            {
                get
                {
                    return this.columnPBO;
                }
            }

            public DataColumn POCETAKRADAColumn
            {
                get
                {
                    return this.columnPOCETAKRADA;
                }
            }

            public DataColumn POSTOTAKOSLOBODJENJAODPOREZAColumn
            {
                get
                {
                    return this.columnPOSTOTAKOSLOBODJENJAODPOREZA;
                }
            }

            public DataColumn POTREBNASTRUCNASPREMAIDSTRUCNASPREMAColumn
            {
                get
                {
                    return this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
                }
            }

            public DataColumn POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn
            {
                get
                {
                    return this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn PRODUZENOMIROVINSKOColumn
            {
                get
                {
                    return this.columnPRODUZENOMIROVINSKO;
                }
            }

            public DataColumn RADNADOZVOLAColumn
            {
                get
                {
                    return this.columnRADNADOZVOLA;
                }
            }

            public DataColumn RADNASPOSOBNOSTColumn
            {
                get
                {
                    return this.columnRADNASPOSOBNOST;
                }
            }

            public DataColumn RADNIKNAPOMENAColumn
            {
                get
                {
                    return this.columnRADNIKNAPOMENA;
                }
            }

            public DataColumn RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAColumn
            {
                get
                {
                    return this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
                }
            }

            public DataColumn RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAColumn
            {
                get
                {
                    return this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA;
                }
            }

            public DataColumn RADUINOZEMSTVUColumn
            {
                get
                {
                    return this.columnRADUINOZEMSTVU;
                }
            }

            public DataColumn RAZLOGPRESTANKAColumn
            {
                get
                {
                    return this.columnRAZLOGPRESTANKA;
                }
            }

            public DataColumn SIFRAOPISAPLACANJANETOColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJANETO;
                }
            }

            public DataColumn SPOJENOPREZIMEColumn
            {
                get
                {
                    return this.columnSPOJENOPREZIME;
                }
            }

            public DataColumn TEKUCIColumn
            {
                get
                {
                    return this.columnTEKUCI;
                }
            }

            public DataColumn TJEDNIFONDSATIColumn
            {
                get
                {
                    return this.columnTJEDNIFONDSATI;
                }
            }

            public DataColumn TJEDNIFONDSATISTAZColumn
            {
                get
                {
                    return this.columnTJEDNIFONDSATISTAZ;
                }
            }

            public DataColumn TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAColumn
            {
                get
                {
                    return this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
                }
            }

            public DataColumn TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn
            {
                get
                {
                    return this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA;
                }
            }

            public DataColumn UGOVORODColumn
            {
                get
                {
                    return this.columnUGOVOROD;
                }
            }

            public DataColumn UKUPNIFAKTORColumn
            {
                get
                {
                    return this.columnUKUPNIFAKTOR;
                }
            }

            public DataColumn UKUPNODANASTAZAColumn
            {
                get
                {
                    return this.columnUKUPNODANASTAZA;
                }
            }

            public DataColumn UKUPNOGODINESTAZAColumn
            {
                get
                {
                    return this.columnUKUPNOGODINESTAZA;
                }
            }

            public DataColumn UKUPNOMJESECISTAZAColumn
            {
                get
                {
                    return this.columnUKUPNOMJESECISTAZA;
                }
            }

            public DataColumn ulicaColumn
            {
                get
                {
                    return this.columnulica;
                }
            }

            public DataColumn UZIMAUOBZIROSNOVICEDOPRINOSAColumn
            {
                get
                {
                    return this.columnUZIMAUOBZIROSNOVICEDOPRINOSA;
                }
            }

            public DataColumn VBDIBANKEColumn
            {
                get
                {
                    return this.columnVBDIBANKE;
                }
            }

            public DataColumn VRIJEMEMIROVANJARADNOGODNOSAColumn
            {
                get
                {
                    return this.columnVRIJEMEMIROVANJARADNOGODNOSA;
                }
            }

            public DataColumn VRIJEMEPRIPRAVNICKOGColumn
            {
                get
                {
                    return this.columnVRIJEMEPRIPRAVNICKOG;
                }
            }

            public DataColumn VRIJEMEPROBNOGRADAColumn
            {
                get
                {
                    return this.columnVRIJEMEPROBNOGRADA;
                }
            }

            public DataColumn VRIJEMESTRUCNIColumn
            {
                get
                {
                    return this.columnVRIJEMESTRUCNI;
                }
            }

            public DataColumn ZABRANANATJECANJAColumn
            {
                get
                {
                    return this.columnZABRANANATJECANJA;
                }
            }

            public DataColumn ZAVRSENASKOLAColumn
            {
                get
                {
                    return this.columnZAVRSENASKOLA;
                }
            }

            public DataColumn ZBIRNINETOColumn
            {
                get
                {
                    return this.columnZBIRNINETO;
                }
            }

            public DataColumn ZRNBANKEColumn
            {
                get
                {
                    return this.columnZRNBANKE;
                }
            }
        }

        [Serializable]
        public class RADNIKIzuzeceOdOvrheDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBANKAZASTICENOIDBANKE;
            private DataColumn columnIDRADNIK;
            private DataColumn columnZADIZNOSIZUZECA;
            private DataColumn columnZADMOIZUZECE;
            private DataColumn columnZADMZIZUZECE;
            private DataColumn columnZADOPISPLACANJAIZUZECE;
            private DataColumn columnZADPOIZUZECE;
            private DataColumn columnZADPZIZUZECE;
            private DataColumn columnZADSIFRAOPISAPLACANJAIZUZECE;
            private DataColumn columnZADTEKUCIIZUZECE;

            public event RADNIKDataSet.RADNIKIzuzeceOdOvrheRowChangeEventHandler RADNIKIzuzeceOdOvrheRowChanged;

            public event RADNIKDataSet.RADNIKIzuzeceOdOvrheRowChangeEventHandler RADNIKIzuzeceOdOvrheRowChanging;

            public event RADNIKDataSet.RADNIKIzuzeceOdOvrheRowChangeEventHandler RADNIKIzuzeceOdOvrheRowDeleted;

            public event RADNIKDataSet.RADNIKIzuzeceOdOvrheRowChangeEventHandler RADNIKIzuzeceOdOvrheRowDeleting;

            public RADNIKIzuzeceOdOvrheDataTable()
            {
                this.TableName = "RADNIKIzuzeceOdOvrhe";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RADNIKIzuzeceOdOvrheDataTable(DataTable table) : base(table.TableName)
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

            protected RADNIKIzuzeceOdOvrheDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRADNIKIzuzeceOdOvrheRow(RADNIKDataSet.RADNIKIzuzeceOdOvrheRow row)
            {
                this.Rows.Add(row);
            }

            public RADNIKDataSet.RADNIKIzuzeceOdOvrheRow AddRADNIKIzuzeceOdOvrheRow(int iDRADNIK, int bANKAZASTICENOIDBANKE, string zADSIFRAOPISAPLACANJAIZUZECE, string zADOPISPLACANJAIZUZECE, string zADTEKUCIIZUZECE, string zADMOIZUZECE, string zADPOIZUZECE, string zADMZIZUZECE, string zADPZIZUZECE, decimal zADIZNOSIZUZECA)
            {
                RADNIKDataSet.RADNIKIzuzeceOdOvrheRow row = (RADNIKDataSet.RADNIKIzuzeceOdOvrheRow) this.NewRow();
                row["IDRADNIK"] = iDRADNIK;
                row["BANKAZASTICENOIDBANKE"] = bANKAZASTICENOIDBANKE;
                row["ZADSIFRAOPISAPLACANJAIZUZECE"] = zADSIFRAOPISAPLACANJAIZUZECE;
                row["ZADOPISPLACANJAIZUZECE"] = zADOPISPLACANJAIZUZECE;
                row["ZADTEKUCIIZUZECE"] = zADTEKUCIIZUZECE;
                row["ZADMOIZUZECE"] = zADMOIZUZECE;
                row["ZADPOIZUZECE"] = zADPOIZUZECE;
                row["ZADMZIZUZECE"] = zADMZIZUZECE;
                row["ZADPZIZUZECE"] = zADPZIZUZECE;
                row["ZADIZNOSIZUZECA"] = zADIZNOSIZUZECA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RADNIKDataSet.RADNIKIzuzeceOdOvrheDataTable table = (RADNIKDataSet.RADNIKIzuzeceOdOvrheDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RADNIKDataSet.RADNIKIzuzeceOdOvrheRow FindByIDRADNIKBANKAZASTICENOIDBANKE(int iDRADNIK, int bANKAZASTICENOIDBANKE)
            {
                return (RADNIKDataSet.RADNIKIzuzeceOdOvrheRow) this.Rows.Find(new object[] { iDRADNIK, bANKAZASTICENOIDBANKE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RADNIKDataSet.RADNIKIzuzeceOdOvrheRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RADNIKDataSet set = new RADNIKDataSet();
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
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnBANKAZASTICENOIDBANKE = new DataColumn("BANKAZASTICENOIDBANKE", typeof(int), "", MappingType.Element);
                this.columnBANKAZASTICENOIDBANKE.AllowDBNull = false;
                this.columnBANKAZASTICENOIDBANKE.Caption = "Šifra banke";
                this.columnBANKAZASTICENOIDBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("SuperType", "IDBANKE");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("SubtypeGroup", "BANKAZASTICENO");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("IsKey", "true");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("Description", "Šifra banke za poseban zaštićeni račun");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("Length", "5");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBANKAZASTICENOIDBANKE.ExtendedProperties.Add("Deklarit.InternalName", "BANKAZASTICENOIDBANKE");
                this.Columns.Add(this.columnBANKAZASTICENOIDBANKE);
                this.columnZADSIFRAOPISAPLACANJAIZUZECE = new DataColumn("ZADSIFRAOPISAPLACANJAIZUZECE", typeof(string), "", MappingType.Element);
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.AllowDBNull = false;
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.Caption = "ZADSIFRAOPISAPLACANJAIZUZECE";
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.MaxLength = 2;
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Description", "Šifra opisa plaćanja");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Length", "2");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "ZADSIFRAOPISAPLACANJAIZUZECE");
                this.Columns.Add(this.columnZADSIFRAOPISAPLACANJAIZUZECE);
                this.columnZADOPISPLACANJAIZUZECE = new DataColumn("ZADOPISPLACANJAIZUZECE", typeof(string), "", MappingType.Element);
                this.columnZADOPISPLACANJAIZUZECE.AllowDBNull = false;
                this.columnZADOPISPLACANJAIZUZECE.Caption = "ZADOPISPLACANJAIZUZECE";
                this.columnZADOPISPLACANJAIZUZECE.MaxLength = 0x24;
                this.columnZADOPISPLACANJAIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("Description", "Opis plaćanja");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("Length", "36");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "ZADOPISPLACANJAIZUZECE");
                this.Columns.Add(this.columnZADOPISPLACANJAIZUZECE);
                this.columnZADTEKUCIIZUZECE = new DataColumn("ZADTEKUCIIZUZECE", typeof(string), "", MappingType.Element);
                this.columnZADTEKUCIIZUZECE.AllowDBNull = false;
                this.columnZADTEKUCIIZUZECE.Caption = "ZADTEKUCIIZUZECE";
                this.columnZADTEKUCIIZUZECE.MaxLength = 10;
                this.columnZADTEKUCIIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("Description", "Zaštićeni tekuči račun");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("Length", "10");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "ZADTEKUCIIZUZECE");
                this.Columns.Add(this.columnZADTEKUCIIZUZECE);
                this.columnZADMOIZUZECE = new DataColumn("ZADMOIZUZECE", typeof(string), "", MappingType.Element);
                this.columnZADMOIZUZECE.AllowDBNull = false;
                this.columnZADMOIZUZECE.Caption = "ZADMOIZUZECE";
                this.columnZADMOIZUZECE.MaxLength = 2;
                this.columnZADMOIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADMOIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("Description", "Model odobrenja");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("Length", "2");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADMOIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "ZADMOIZUZECE");
                this.Columns.Add(this.columnZADMOIZUZECE);
                this.columnZADPOIZUZECE = new DataColumn("ZADPOIZUZECE", typeof(string), "", MappingType.Element);
                this.columnZADPOIZUZECE.AllowDBNull = true;
                this.columnZADPOIZUZECE.Caption = "ZADPOIZUZECE";
                this.columnZADPOIZUZECE.MaxLength = 0x16;
                this.columnZADPOIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADPOIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("Description", "Poziv na broj odobrenja");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("Length", "22");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADPOIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "ZADPOIZUZECE");
                this.Columns.Add(this.columnZADPOIZUZECE);
                this.columnZADMZIZUZECE = new DataColumn("ZADMZIZUZECE", typeof(string), "", MappingType.Element);
                this.columnZADMZIZUZECE.AllowDBNull = true;
                this.columnZADMZIZUZECE.Caption = "ZADMZIZUZECE";
                this.columnZADMZIZUZECE.MaxLength = 2;
                this.columnZADMZIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADMZIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("Description", "Model zaduženja");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("Length", "2");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADMZIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "ZADMZIZUZECE");
                this.Columns.Add(this.columnZADMZIZUZECE);
                this.columnZADPZIZUZECE = new DataColumn("ZADPZIZUZECE", typeof(string), "", MappingType.Element);
                this.columnZADPZIZUZECE.AllowDBNull = true;
                this.columnZADPZIZUZECE.Caption = "ZADPZIZUZECE";
                this.columnZADPZIZUZECE.MaxLength = 0x16;
                this.columnZADPZIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADPZIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("Description", "Poziv na broj zaduženja");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("Length", "22");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADPZIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "ZADPZIZUZECE");
                this.Columns.Add(this.columnZADPZIZUZECE);
                this.columnZADIZNOSIZUZECA = new DataColumn("ZADIZNOSIZUZECA", typeof(decimal), "", MappingType.Element);
                this.columnZADIZNOSIZUZECA.AllowDBNull = false;
                this.columnZADIZNOSIZUZECA.Caption = "ZADIZNOSIZUZECA";
                this.columnZADIZNOSIZUZECA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("Description", "Iznos izuzet od ovrhe");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("Length", "12");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("Decimals", "2");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.InternalName", "ZADIZNOSIZUZECA");
                this.Columns.Add(this.columnZADIZNOSIZUZECA);
                this.PrimaryKey = new DataColumn[] { this.columnIDRADNIK, this.columnBANKAZASTICENOIDBANKE };
                this.ExtendedProperties.Add("ParentLvl", "RADNIK");
                this.ExtendedProperties.Add("LevelName", "IzuzeceOdOvrhe");
                this.ExtendedProperties.Add("Description", "IzuzeceOdOvrhe");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnBANKAZASTICENOIDBANKE = this.Columns["BANKAZASTICENOIDBANKE"];
                this.columnZADSIFRAOPISAPLACANJAIZUZECE = this.Columns["ZADSIFRAOPISAPLACANJAIZUZECE"];
                this.columnZADOPISPLACANJAIZUZECE = this.Columns["ZADOPISPLACANJAIZUZECE"];
                this.columnZADTEKUCIIZUZECE = this.Columns["ZADTEKUCIIZUZECE"];
                this.columnZADMOIZUZECE = this.Columns["ZADMOIZUZECE"];
                this.columnZADPOIZUZECE = this.Columns["ZADPOIZUZECE"];
                this.columnZADMZIZUZECE = this.Columns["ZADMZIZUZECE"];
                this.columnZADPZIZUZECE = this.Columns["ZADPZIZUZECE"];
                this.columnZADIZNOSIZUZECA = this.Columns["ZADIZNOSIZUZECA"];
            }

            public RADNIKDataSet.RADNIKIzuzeceOdOvrheRow NewRADNIKIzuzeceOdOvrheRow()
            {
                return (RADNIKDataSet.RADNIKIzuzeceOdOvrheRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RADNIKDataSet.RADNIKIzuzeceOdOvrheRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RADNIKIzuzeceOdOvrheRowChanged != null)
                {
                    RADNIKDataSet.RADNIKIzuzeceOdOvrheRowChangeEventHandler rADNIKIzuzeceOdOvrheRowChangedEvent = this.RADNIKIzuzeceOdOvrheRowChanged;
                    if (rADNIKIzuzeceOdOvrheRowChangedEvent != null)
                    {
                        rADNIKIzuzeceOdOvrheRowChangedEvent(this, new RADNIKDataSet.RADNIKIzuzeceOdOvrheRowChangeEvent((RADNIKDataSet.RADNIKIzuzeceOdOvrheRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RADNIKIzuzeceOdOvrheRowChanging != null)
                {
                    RADNIKDataSet.RADNIKIzuzeceOdOvrheRowChangeEventHandler rADNIKIzuzeceOdOvrheRowChangingEvent = this.RADNIKIzuzeceOdOvrheRowChanging;
                    if (rADNIKIzuzeceOdOvrheRowChangingEvent != null)
                    {
                        rADNIKIzuzeceOdOvrheRowChangingEvent(this, new RADNIKDataSet.RADNIKIzuzeceOdOvrheRowChangeEvent((RADNIKDataSet.RADNIKIzuzeceOdOvrheRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("RADNIK_RADNIKIzuzeceOdOvrhe", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.RADNIKIzuzeceOdOvrheRowDeleted != null)
                {
                    RADNIKDataSet.RADNIKIzuzeceOdOvrheRowChangeEventHandler rADNIKIzuzeceOdOvrheRowDeletedEvent = this.RADNIKIzuzeceOdOvrheRowDeleted;
                    if (rADNIKIzuzeceOdOvrheRowDeletedEvent != null)
                    {
                        rADNIKIzuzeceOdOvrheRowDeletedEvent(this, new RADNIKDataSet.RADNIKIzuzeceOdOvrheRowChangeEvent((RADNIKDataSet.RADNIKIzuzeceOdOvrheRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RADNIKIzuzeceOdOvrheRowDeleting != null)
                {
                    RADNIKDataSet.RADNIKIzuzeceOdOvrheRowChangeEventHandler rADNIKIzuzeceOdOvrheRowDeletingEvent = this.RADNIKIzuzeceOdOvrheRowDeleting;
                    if (rADNIKIzuzeceOdOvrheRowDeletingEvent != null)
                    {
                        rADNIKIzuzeceOdOvrheRowDeletingEvent(this, new RADNIKDataSet.RADNIKIzuzeceOdOvrheRowChangeEvent((RADNIKDataSet.RADNIKIzuzeceOdOvrheRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRADNIKIzuzeceOdOvrheRow(RADNIKDataSet.RADNIKIzuzeceOdOvrheRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BANKAZASTICENOIDBANKEColumn
            {
                get
                {
                    return this.columnBANKAZASTICENOIDBANKE;
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

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public RADNIKDataSet.RADNIKIzuzeceOdOvrheRow this[int index]
            {
                get
                {
                    return (RADNIKDataSet.RADNIKIzuzeceOdOvrheRow) this.Rows[index];
                }
            }

            public DataColumn ZADIZNOSIZUZECAColumn
            {
                get
                {
                    return this.columnZADIZNOSIZUZECA;
                }
            }

            public DataColumn ZADMOIZUZECEColumn
            {
                get
                {
                    return this.columnZADMOIZUZECE;
                }
            }

            public DataColumn ZADMZIZUZECEColumn
            {
                get
                {
                    return this.columnZADMZIZUZECE;
                }
            }

            public DataColumn ZADOPISPLACANJAIZUZECEColumn
            {
                get
                {
                    return this.columnZADOPISPLACANJAIZUZECE;
                }
            }

            public DataColumn ZADPOIZUZECEColumn
            {
                get
                {
                    return this.columnZADPOIZUZECE;
                }
            }

            public DataColumn ZADPZIZUZECEColumn
            {
                get
                {
                    return this.columnZADPZIZUZECE;
                }
            }

            public DataColumn ZADSIFRAOPISAPLACANJAIZUZECEColumn
            {
                get
                {
                    return this.columnZADSIFRAOPISAPLACANJAIZUZECE;
                }
            }

            public DataColumn ZADTEKUCIIZUZECEColumn
            {
                get
                {
                    return this.columnZADTEKUCIIZUZECE;
                }
            }
        }

        public class RADNIKIzuzeceOdOvrheRow : DataRow
        {
            private RADNIKDataSet.RADNIKIzuzeceOdOvrheDataTable tableRADNIKIzuzeceOdOvrhe;

            internal RADNIKIzuzeceOdOvrheRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRADNIKIzuzeceOdOvrhe = (RADNIKDataSet.RADNIKIzuzeceOdOvrheDataTable) this.Table;
            }

            public RADNIKDataSet.RADNIKRow GetRADNIKRow()
            {
                return (RADNIKDataSet.RADNIKRow) this.GetParentRow("RADNIK_RADNIKIzuzeceOdOvrhe");
            }

            public bool IsBANKAZASTICENOIDBANKENull()
            {
                return this.IsNull(this.tableRADNIKIzuzeceOdOvrhe.BANKAZASTICENOIDBANKEColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableRADNIKIzuzeceOdOvrhe.IDRADNIKColumn);
            }

            public bool IsZADIZNOSIZUZECANull()
            {
                return this.IsNull(this.tableRADNIKIzuzeceOdOvrhe.ZADIZNOSIZUZECAColumn);
            }

            public bool IsZADMOIZUZECENull()
            {
                return this.IsNull(this.tableRADNIKIzuzeceOdOvrhe.ZADMOIZUZECEColumn);
            }

            public bool IsZADMZIZUZECENull()
            {
                return this.IsNull(this.tableRADNIKIzuzeceOdOvrhe.ZADMZIZUZECEColumn);
            }

            public bool IsZADOPISPLACANJAIZUZECENull()
            {
                return this.IsNull(this.tableRADNIKIzuzeceOdOvrhe.ZADOPISPLACANJAIZUZECEColumn);
            }

            public bool IsZADPOIZUZECENull()
            {
                return this.IsNull(this.tableRADNIKIzuzeceOdOvrhe.ZADPOIZUZECEColumn);
            }

            public bool IsZADPZIZUZECENull()
            {
                return this.IsNull(this.tableRADNIKIzuzeceOdOvrhe.ZADPZIZUZECEColumn);
            }

            public bool IsZADSIFRAOPISAPLACANJAIZUZECENull()
            {
                return this.IsNull(this.tableRADNIKIzuzeceOdOvrhe.ZADSIFRAOPISAPLACANJAIZUZECEColumn);
            }

            public bool IsZADTEKUCIIZUZECENull()
            {
                return this.IsNull(this.tableRADNIKIzuzeceOdOvrhe.ZADTEKUCIIZUZECEColumn);
            }

            public void SetZADIZNOSIZUZECANull()
            {
                this[this.tableRADNIKIzuzeceOdOvrhe.ZADIZNOSIZUZECAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADMOIZUZECENull()
            {
                this[this.tableRADNIKIzuzeceOdOvrhe.ZADMOIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADMZIZUZECENull()
            {
                this[this.tableRADNIKIzuzeceOdOvrhe.ZADMZIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOPISPLACANJAIZUZECENull()
            {
                this[this.tableRADNIKIzuzeceOdOvrhe.ZADOPISPLACANJAIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADPOIZUZECENull()
            {
                this[this.tableRADNIKIzuzeceOdOvrhe.ZADPOIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADPZIZUZECENull()
            {
                this[this.tableRADNIKIzuzeceOdOvrhe.ZADPZIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADSIFRAOPISAPLACANJAIZUZECENull()
            {
                this[this.tableRADNIKIzuzeceOdOvrhe.ZADSIFRAOPISAPLACANJAIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADTEKUCIIZUZECENull()
            {
                this[this.tableRADNIKIzuzeceOdOvrhe.ZADTEKUCIIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BANKAZASTICENOIDBANKE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKIzuzeceOdOvrhe.BANKAZASTICENOIDBANKEColumn]);
                }
                set
                {
                    this[this.tableRADNIKIzuzeceOdOvrhe.BANKAZASTICENOIDBANKEColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKIzuzeceOdOvrhe.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableRADNIKIzuzeceOdOvrhe.IDRADNIKColumn] = value;
                }
            }

            public decimal ZADIZNOSIZUZECA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKIzuzeceOdOvrhe.ZADIZNOSIZUZECAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKIzuzeceOdOvrhe.ZADIZNOSIZUZECAColumn] = value;
                }
            }

            public string ZADMOIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKIzuzeceOdOvrhe.ZADMOIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKIzuzeceOdOvrhe.ZADMOIZUZECEColumn] = value;
                }
            }

            public string ZADMZIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKIzuzeceOdOvrhe.ZADMZIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKIzuzeceOdOvrhe.ZADMZIZUZECEColumn] = value;
                }
            }

            public string ZADOPISPLACANJAIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKIzuzeceOdOvrhe.ZADOPISPLACANJAIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKIzuzeceOdOvrhe.ZADOPISPLACANJAIZUZECEColumn] = value;
                }
            }

            public string ZADPOIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKIzuzeceOdOvrhe.ZADPOIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKIzuzeceOdOvrhe.ZADPOIZUZECEColumn] = value;
                }
            }

            public string ZADPZIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKIzuzeceOdOvrhe.ZADPZIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKIzuzeceOdOvrhe.ZADPZIZUZECEColumn] = value;
                }
            }

            public string ZADSIFRAOPISAPLACANJAIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKIzuzeceOdOvrhe.ZADSIFRAOPISAPLACANJAIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKIzuzeceOdOvrhe.ZADSIFRAOPISAPLACANJAIZUZECEColumn] = value;
                }
            }

            public string ZADTEKUCIIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKIzuzeceOdOvrhe.ZADTEKUCIIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKIzuzeceOdOvrhe.ZADTEKUCIIZUZECEColumn] = value;
                }
            }
        }

        public class RADNIKIzuzeceOdOvrheRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RADNIKDataSet.RADNIKIzuzeceOdOvrheRow eventRow;

            public RADNIKIzuzeceOdOvrheRowChangeEvent(RADNIKDataSet.RADNIKIzuzeceOdOvrheRow row, DataRowAction action)
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

            public RADNIKDataSet.RADNIKIzuzeceOdOvrheRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RADNIKIzuzeceOdOvrheRowChangeEventHandler(object sender, RADNIKDataSet.RADNIKIzuzeceOdOvrheRowChangeEvent e);

        [Serializable]
        public class RADNIKKreditiDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDATUMUGOVORA;
            private DataColumn columnIDRADNIK;
            private DataColumn columnKREDITAKTIVAN;
            private DataColumn columnKREDITOTPLACENIIZNOS;
            private DataColumn columnKREDITOTPLACENORATA;
            private DataColumn columnMOKREDITOR;
            private DataColumn columnMZKREDITOR;
            private DataColumn columnOPISPLACANJAKREDITOR;
            private DataColumn columnPARTIJAKREDITASPECIFIKACIJA;
            private DataColumn columnPOKREDITOR;
            private DataColumn columnPZKREDITOR;
            private DataColumn columnSIFRAOPISAPLACANJAKREDITOR;
            private DataColumn columnZADBROJRATAOBUSTAVE;
            private DataColumn columnZADIZNOSRATEKREDITA;
            private DataColumn columnZADKREDITIIDKREDITOR;
            private DataColumn columnZADKREDITINAZIVKREDITOR;
            private DataColumn columnZADKREDITIPRIMATELJKREDITOR1;
            private DataColumn columnZADKREDITIPRIMATELJKREDITOR2;
            private DataColumn columnZADKREDITIPRIMATELJKREDITOR3;
            private DataColumn columnZADKREDITIVBDIKREDITOR;
            private DataColumn columnZADKREDITIZRNKREDITOR;
            private DataColumn columnZADUKUPNIZNOSKREDITA;
            private DataColumn columnZADVECOTPLACENOBROJRATA;
            private DataColumn columnZADVECOTPLACENOUKUPNIIZNOS;

            public event RADNIKDataSet.RADNIKKreditiRowChangeEventHandler RADNIKKreditiRowChanged;

            public event RADNIKDataSet.RADNIKKreditiRowChangeEventHandler RADNIKKreditiRowChanging;

            public event RADNIKDataSet.RADNIKKreditiRowChangeEventHandler RADNIKKreditiRowDeleted;

            public event RADNIKDataSet.RADNIKKreditiRowChangeEventHandler RADNIKKreditiRowDeleting;

            public RADNIKKreditiDataTable()
            {
                this.TableName = "RADNIKKrediti";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RADNIKKreditiDataTable(DataTable table) : base(table.TableName)
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

            protected RADNIKKreditiDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRADNIKKreditiRow(RADNIKDataSet.RADNIKKreditiRow row)
            {
                this.Rows.Add(row);
            }

            public RADNIKDataSet.RADNIKKreditiRow AddRADNIKKreditiRow(int iDRADNIK, int zADKREDITIIDKREDITOR, DateTime dATUMUGOVORA, bool kREDITAKTIVAN, string sIFRAOPISAPLACANJAKREDITOR, string oPISPLACANJAKREDITOR, string mOKREDITOR, string pOKREDITOR, string mZKREDITOR, string pZKREDITOR, decimal zADIZNOSRATEKREDITA, decimal zADBROJRATAOBUSTAVE, decimal zADUKUPNIZNOSKREDITA, decimal zADVECOTPLACENOBROJRATA, decimal zADVECOTPLACENOUKUPNIIZNOS, string pARTIJAKREDITASPECIFIKACIJA)
            {
                RADNIKDataSet.RADNIKKreditiRow row = (RADNIKDataSet.RADNIKKreditiRow) this.NewRow();
                row["IDRADNIK"] = iDRADNIK;
                row["ZADKREDITIIDKREDITOR"] = zADKREDITIIDKREDITOR;
                row["DATUMUGOVORA"] = dATUMUGOVORA;
                row["KREDITAKTIVAN"] = kREDITAKTIVAN;
                row["SIFRAOPISAPLACANJAKREDITOR"] = sIFRAOPISAPLACANJAKREDITOR;
                row["OPISPLACANJAKREDITOR"] = oPISPLACANJAKREDITOR;
                row["MOKREDITOR"] = mOKREDITOR;
                row["POKREDITOR"] = pOKREDITOR;
                row["MZKREDITOR"] = mZKREDITOR;
                row["PZKREDITOR"] = pZKREDITOR;
                row["ZADIZNOSRATEKREDITA"] = zADIZNOSRATEKREDITA;
                row["ZADBROJRATAOBUSTAVE"] = zADBROJRATAOBUSTAVE;
                row["ZADUKUPNIZNOSKREDITA"] = zADUKUPNIZNOSKREDITA;
                row["ZADVECOTPLACENOBROJRATA"] = zADVECOTPLACENOBROJRATA;
                row["ZADVECOTPLACENOUKUPNIIZNOS"] = zADVECOTPLACENOUKUPNIIZNOS;
                row["PARTIJAKREDITASPECIFIKACIJA"] = pARTIJAKREDITASPECIFIKACIJA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RADNIKDataSet.RADNIKKreditiDataTable table = (RADNIKDataSet.RADNIKKreditiDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RADNIKDataSet.RADNIKKreditiRow FindByIDRADNIKZADKREDITIIDKREDITORDATUMUGOVORA(int iDRADNIK, int zADKREDITIIDKREDITOR, DateTime dATUMUGOVORA)
            {
                return (RADNIKDataSet.RADNIKKreditiRow) this.Rows.Find(new object[] { iDRADNIK, zADKREDITIIDKREDITOR, dATUMUGOVORA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RADNIKDataSet.RADNIKKreditiRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RADNIKDataSet set = new RADNIKDataSet();
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
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnZADKREDITIIDKREDITOR = new DataColumn("ZADKREDITIIDKREDITOR", typeof(int), "", MappingType.Element);
                this.columnZADKREDITIIDKREDITOR.AllowDBNull = false;
                this.columnZADKREDITIIDKREDITOR.Caption = "IDKREDITOR";
                this.columnZADKREDITIIDKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "99999999");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("SuperType", "IDKREDITOR");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("SubtypeGroup", "ZADKREDITI");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("IsKey", "true");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("Description", "Šifra");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("Length", "8");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADKREDITIIDKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "ZADKREDITIIDKREDITOR");
                this.Columns.Add(this.columnZADKREDITIIDKREDITOR);
                this.columnDATUMUGOVORA = new DataColumn("DATUMUGOVORA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMUGOVORA.AllowDBNull = false;
                this.columnDATUMUGOVORA.Caption = "DATUMUGOVORA";
                this.columnDATUMUGOVORA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("IsKey", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Description", "DATUMUGOVORA");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMUGOVORA");
                this.Columns.Add(this.columnDATUMUGOVORA);
                this.columnKREDITAKTIVAN = new DataColumn("KREDITAKTIVAN", typeof(bool), "", MappingType.Element);
                this.columnKREDITAKTIVAN.AllowDBNull = false;
                this.columnKREDITAKTIVAN.Caption = "KREDITAKTIVAN";
                this.columnKREDITAKTIVAN.DefaultValue = true;
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("IsKey", "false");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("Description", "Obračunavaj kredit");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("Length", "1");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("Decimals", "0");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKREDITAKTIVAN.ExtendedProperties.Add("Deklarit.InternalName", "KREDITAKTIVAN");
                this.Columns.Add(this.columnKREDITAKTIVAN);
                this.columnZADKREDITINAZIVKREDITOR = new DataColumn("ZADKREDITINAZIVKREDITOR", typeof(string), "", MappingType.Element);
                this.columnZADKREDITINAZIVKREDITOR.AllowDBNull = true;
                this.columnZADKREDITINAZIVKREDITOR.Caption = "NAZIVKREDITOR";
                this.columnZADKREDITINAZIVKREDITOR.MaxLength = 20;
                this.columnZADKREDITINAZIVKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("SuperType", "NAZIVKREDITOR");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("SubtypeGroup", "ZADKREDITI");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("Description", "Kreditor");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("Length", "20");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADKREDITINAZIVKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "ZADKREDITINAZIVKREDITOR");
                this.Columns.Add(this.columnZADKREDITINAZIVKREDITOR);
                this.columnZADKREDITIPRIMATELJKREDITOR1 = new DataColumn("ZADKREDITIPRIMATELJKREDITOR1", typeof(string), "", MappingType.Element);
                this.columnZADKREDITIPRIMATELJKREDITOR1.AllowDBNull = true;
                this.columnZADKREDITIPRIMATELJKREDITOR1.Caption = "PRIMATELJKREDITO R1";
                this.columnZADKREDITIPRIMATELJKREDITOR1.MaxLength = 20;
                this.columnZADKREDITIPRIMATELJKREDITOR1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("SuperType", "PRIMATELJKREDITOR1");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("SubtypeGroup", "ZADKREDITI");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("IsKey", "false");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("Description", "Primatelj kredita (1)");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("Length", "20");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("Decimals", "0");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADKREDITIPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.InternalName", "ZADKREDITIPRIMATELJKREDITOR1");
                this.Columns.Add(this.columnZADKREDITIPRIMATELJKREDITOR1);
                this.columnZADKREDITIPRIMATELJKREDITOR2 = new DataColumn("ZADKREDITIPRIMATELJKREDITOR2", typeof(string), "", MappingType.Element);
                this.columnZADKREDITIPRIMATELJKREDITOR2.AllowDBNull = true;
                this.columnZADKREDITIPRIMATELJKREDITOR2.Caption = "PRIMATELJKREDITO R2";
                this.columnZADKREDITIPRIMATELJKREDITOR2.MaxLength = 20;
                this.columnZADKREDITIPRIMATELJKREDITOR2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("SuperType", "PRIMATELJKREDITOR2");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("SubtypeGroup", "ZADKREDITI");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("IsKey", "false");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("Description", "Primatelj kredita (2)");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("Length", "20");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("Decimals", "0");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADKREDITIPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.InternalName", "ZADKREDITIPRIMATELJKREDITOR2");
                this.Columns.Add(this.columnZADKREDITIPRIMATELJKREDITOR2);
                this.columnZADKREDITIPRIMATELJKREDITOR3 = new DataColumn("ZADKREDITIPRIMATELJKREDITOR3", typeof(string), "", MappingType.Element);
                this.columnZADKREDITIPRIMATELJKREDITOR3.AllowDBNull = true;
                this.columnZADKREDITIPRIMATELJKREDITOR3.Caption = "PRIMATELJKREDITO R3";
                this.columnZADKREDITIPRIMATELJKREDITOR3.MaxLength = 20;
                this.columnZADKREDITIPRIMATELJKREDITOR3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("SuperType", "PRIMATELJKREDITOR3");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("SubtypeGroup", "ZADKREDITI");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("IsKey", "false");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("Description", "Primatelj kredita (2)");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("Length", "20");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("Decimals", "0");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADKREDITIPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.InternalName", "ZADKREDITIPRIMATELJKREDITOR3");
                this.Columns.Add(this.columnZADKREDITIPRIMATELJKREDITOR3);
                this.columnSIFRAOPISAPLACANJAKREDITOR = new DataColumn("SIFRAOPISAPLACANJAKREDITOR", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAKREDITOR.AllowDBNull = false;
                this.columnSIFRAOPISAPLACANJAKREDITOR.Caption = "SIFRAOPISAPLACANJAKREDITOR";
                this.columnSIFRAOPISAPLACANJAKREDITOR.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Description", "Šifra opisa plaćanja");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAKREDITOR");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAKREDITOR);
                this.columnOPISPLACANJAKREDITOR = new DataColumn("OPISPLACANJAKREDITOR", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAKREDITOR.AllowDBNull = false;
                this.columnOPISPLACANJAKREDITOR.Caption = "OPISPLACANJAKREDITOR";
                this.columnOPISPLACANJAKREDITOR.MaxLength = 0x24;
                this.columnOPISPLACANJAKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("Description", "Opis plaćanja kredit");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAKREDITOR");
                this.Columns.Add(this.columnOPISPLACANJAKREDITOR);
                this.columnMOKREDITOR = new DataColumn("MOKREDITOR", typeof(string), "", MappingType.Element);
                this.columnMOKREDITOR.AllowDBNull = true;
                this.columnMOKREDITOR.Caption = "MOKREDITOR";
                this.columnMOKREDITOR.MaxLength = 2;
                this.columnMOKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMOKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnMOKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMOKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOKREDITOR.ExtendedProperties.Add("Description", "Model odobrenja");
                this.columnMOKREDITOR.ExtendedProperties.Add("Length", "2");
                this.columnMOKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnMOKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMOKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "MOKREDITOR");
                this.Columns.Add(this.columnMOKREDITOR);
                this.columnPOKREDITOR = new DataColumn("POKREDITOR", typeof(string), "", MappingType.Element);
                this.columnPOKREDITOR.AllowDBNull = true;
                this.columnPOKREDITOR.Caption = "POKREDITOR";
                this.columnPOKREDITOR.MaxLength = 0x16;
                this.columnPOKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnPOKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOKREDITOR.ExtendedProperties.Add("Description", "Poziv na broj odobrenja");
                this.columnPOKREDITOR.ExtendedProperties.Add("Length", "22");
                this.columnPOKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnPOKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "POKREDITOR");
                this.Columns.Add(this.columnPOKREDITOR);
                this.columnMZKREDITOR = new DataColumn("MZKREDITOR", typeof(string), "", MappingType.Element);
                this.columnMZKREDITOR.AllowDBNull = true;
                this.columnMZKREDITOR.Caption = "MZKREDITOR";
                this.columnMZKREDITOR.MaxLength = 2;
                this.columnMZKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMZKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnMZKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMZKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZKREDITOR.ExtendedProperties.Add("Description", "Model zaduženja");
                this.columnMZKREDITOR.ExtendedProperties.Add("Length", "2");
                this.columnMZKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnMZKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "MZKREDITOR");
                this.Columns.Add(this.columnMZKREDITOR);
                this.columnPZKREDITOR = new DataColumn("PZKREDITOR", typeof(string), "", MappingType.Element);
                this.columnPZKREDITOR.AllowDBNull = true;
                this.columnPZKREDITOR.Caption = "PZKREDITOR";
                this.columnPZKREDITOR.MaxLength = 0x16;
                this.columnPZKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPZKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnPZKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPZKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZKREDITOR.ExtendedProperties.Add("Description", "Poziv na broj zaduženja");
                this.columnPZKREDITOR.ExtendedProperties.Add("Length", "22");
                this.columnPZKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnPZKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "PZKREDITOR");
                this.Columns.Add(this.columnPZKREDITOR);
                this.columnZADIZNOSRATEKREDITA = new DataColumn("ZADIZNOSRATEKREDITA", typeof(decimal), "", MappingType.Element);
                this.columnZADIZNOSRATEKREDITA.AllowDBNull = false;
                this.columnZADIZNOSRATEKREDITA.Caption = "ZADITNOSRATEKREDITA";
                this.columnZADIZNOSRATEKREDITA.DefaultValue = 0;
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("Description", "Iznos rate kredita");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("Length", "12");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("Decimals", "2");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADIZNOSRATEKREDITA.ExtendedProperties.Add("Deklarit.InternalName", "ZADIZNOSRATEKREDITA");
                this.Columns.Add(this.columnZADIZNOSRATEKREDITA);
                this.columnZADBROJRATAOBUSTAVE = new DataColumn("ZADBROJRATAOBUSTAVE", typeof(decimal), "", MappingType.Element);
                this.columnZADBROJRATAOBUSTAVE.AllowDBNull = false;
                this.columnZADBROJRATAOBUSTAVE.Caption = "Broj rata kredita";
                this.columnZADBROJRATAOBUSTAVE.DefaultValue = 0;
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("Description", "Broj rata kredita");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("Length", "12");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("Decimals", "2");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADBROJRATAOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "ZADBROJRATAOBUSTAVE");
                this.Columns.Add(this.columnZADBROJRATAOBUSTAVE);
                this.columnZADUKUPNIZNOSKREDITA = new DataColumn("ZADUKUPNIZNOSKREDITA", typeof(decimal), "", MappingType.Element);
                this.columnZADUKUPNIZNOSKREDITA.AllowDBNull = false;
                this.columnZADUKUPNIZNOSKREDITA.Caption = "Ukuoni iznos kredita";
                this.columnZADUKUPNIZNOSKREDITA.DefaultValue = 0;
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("Description", "Ukupni iznos kredita");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("Length", "12");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("Decimals", "2");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.InternalName", "ZADUKUPNIZNOSKREDITA");
                this.Columns.Add(this.columnZADUKUPNIZNOSKREDITA);
                this.columnZADVECOTPLACENOBROJRATA = new DataColumn("ZADVECOTPLACENOBROJRATA", typeof(decimal), "", MappingType.Element);
                this.columnZADVECOTPLACENOBROJRATA.AllowDBNull = false;
                this.columnZADVECOTPLACENOBROJRATA.Caption = "Prijenos otplaćenih rata iz drugog programa";
                this.columnZADVECOTPLACENOBROJRATA.DefaultValue = 0;
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("Description", "Prijenos otplaćenih rata iz drugog programa");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("Length", "12");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("Decimals", "2");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.InternalName", "ZADVECOTPLACENOBROJRATA");
                this.Columns.Add(this.columnZADVECOTPLACENOBROJRATA);
                this.columnZADVECOTPLACENOUKUPNIIZNOS = new DataColumn("ZADVECOTPLACENOUKUPNIIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnZADVECOTPLACENOUKUPNIIZNOS.AllowDBNull = false;
                this.columnZADVECOTPLACENOUKUPNIIZNOS.Caption = "Prijenos otplaćenog iznosa iz drugog programa";
                this.columnZADVECOTPLACENOUKUPNIIZNOS.DefaultValue = 0;
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Description", "Prijenos otplaćenog iznosa iz drugog programa");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "ZADVECOTPLACENOUKUPNIIZNOS");
                this.Columns.Add(this.columnZADVECOTPLACENOUKUPNIIZNOS);
                this.columnKREDITOTPLACENIIZNOS = new DataColumn("KREDITOTPLACENIIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnKREDITOTPLACENIIZNOS.AllowDBNull = true;
                this.columnKREDITOTPLACENIIZNOS.Caption = "KREDITOTPLACENIIZNOS";
                this.columnKREDITOTPLACENIIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("Description", "Ukupno otplaćeno (iznos)");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKREDITOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "KREDITOTPLACENIIZNOS");
                this.Columns.Add(this.columnKREDITOTPLACENIIZNOS);
                this.columnKREDITOTPLACENORATA = new DataColumn("KREDITOTPLACENORATA", typeof(decimal), "", MappingType.Element);
                this.columnKREDITOTPLACENORATA.AllowDBNull = true;
                this.columnKREDITOTPLACENORATA.Caption = "KREDITOTPLACENORATA";
                this.columnKREDITOTPLACENORATA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("IsKey", "false");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("Description", "Ukupno otplaćeno (broj rata)");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("Length", "12");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("Decimals", "2");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKREDITOTPLACENORATA.ExtendedProperties.Add("Deklarit.InternalName", "KREDITOTPLACENORATA");
                this.Columns.Add(this.columnKREDITOTPLACENORATA);
                this.columnZADKREDITIVBDIKREDITOR = new DataColumn("ZADKREDITIVBDIKREDITOR", typeof(string), "", MappingType.Element);
                this.columnZADKREDITIVBDIKREDITOR.AllowDBNull = true;
                this.columnZADKREDITIVBDIKREDITOR.Caption = "VBDIKREDITOR";
                this.columnZADKREDITIVBDIKREDITOR.MaxLength = 7;
                this.columnZADKREDITIVBDIKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("SuperType", "VBDIKREDITOR");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("SubtypeGroup", "ZADKREDITI");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("Description", "VBDIKREDITOR");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("Length", "7");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADKREDITIVBDIKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "ZADKREDITIVBDIKREDITOR");
                this.Columns.Add(this.columnZADKREDITIVBDIKREDITOR);
                this.columnZADKREDITIZRNKREDITOR = new DataColumn("ZADKREDITIZRNKREDITOR", typeof(string), "", MappingType.Element);
                this.columnZADKREDITIZRNKREDITOR.AllowDBNull = true;
                this.columnZADKREDITIZRNKREDITOR.Caption = "ZRNKREDITOR";
                this.columnZADKREDITIZRNKREDITOR.MaxLength = 10;
                this.columnZADKREDITIZRNKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("SuperType", "ZRNKREDITOR");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("SubtypeGroup", "ZADKREDITI");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("Description", "ZRNKREDITOR");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("Length", "10");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADKREDITIZRNKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "ZADKREDITIZRNKREDITOR");
                this.Columns.Add(this.columnZADKREDITIZRNKREDITOR);
                this.columnPARTIJAKREDITASPECIFIKACIJA = new DataColumn("PARTIJAKREDITASPECIFIKACIJA", typeof(string), "", MappingType.Element);
                this.columnPARTIJAKREDITASPECIFIKACIJA.AllowDBNull = true;
                this.columnPARTIJAKREDITASPECIFIKACIJA.Caption = "PARTIJAKREDITASPECIFIKACIJA";
                this.columnPARTIJAKREDITASPECIFIKACIJA.MaxLength = 0x16;
                this.columnPARTIJAKREDITASPECIFIKACIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("Description", "Partija kredita za specifikaciju");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("Length", "22");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTIJAKREDITASPECIFIKACIJA.ExtendedProperties.Add("Deklarit.InternalName", "PARTIJAKREDITASPECIFIKACIJA");
                this.Columns.Add(this.columnPARTIJAKREDITASPECIFIKACIJA);
                this.PrimaryKey = new DataColumn[] { this.columnIDRADNIK, this.columnZADKREDITIIDKREDITOR, this.columnDATUMUGOVORA };
                this.ExtendedProperties.Add("ParentLvl", "RADNIK");
                this.ExtendedProperties.Add("LevelName", "Krediti");
                this.ExtendedProperties.Add("Description", "Krediti radnika");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnZADKREDITIIDKREDITOR = this.Columns["ZADKREDITIIDKREDITOR"];
                this.columnDATUMUGOVORA = this.Columns["DATUMUGOVORA"];
                this.columnKREDITAKTIVAN = this.Columns["KREDITAKTIVAN"];
                this.columnZADKREDITINAZIVKREDITOR = this.Columns["ZADKREDITINAZIVKREDITOR"];
                this.columnZADKREDITIPRIMATELJKREDITOR1 = this.Columns["ZADKREDITIPRIMATELJKREDITOR1"];
                this.columnZADKREDITIPRIMATELJKREDITOR2 = this.Columns["ZADKREDITIPRIMATELJKREDITOR2"];
                this.columnZADKREDITIPRIMATELJKREDITOR3 = this.Columns["ZADKREDITIPRIMATELJKREDITOR3"];
                this.columnSIFRAOPISAPLACANJAKREDITOR = this.Columns["SIFRAOPISAPLACANJAKREDITOR"];
                this.columnOPISPLACANJAKREDITOR = this.Columns["OPISPLACANJAKREDITOR"];
                this.columnMOKREDITOR = this.Columns["MOKREDITOR"];
                this.columnPOKREDITOR = this.Columns["POKREDITOR"];
                this.columnMZKREDITOR = this.Columns["MZKREDITOR"];
                this.columnPZKREDITOR = this.Columns["PZKREDITOR"];
                this.columnZADIZNOSRATEKREDITA = this.Columns["ZADIZNOSRATEKREDITA"];
                this.columnZADBROJRATAOBUSTAVE = this.Columns["ZADBROJRATAOBUSTAVE"];
                this.columnZADUKUPNIZNOSKREDITA = this.Columns["ZADUKUPNIZNOSKREDITA"];
                this.columnZADVECOTPLACENOBROJRATA = this.Columns["ZADVECOTPLACENOBROJRATA"];
                this.columnZADVECOTPLACENOUKUPNIIZNOS = this.Columns["ZADVECOTPLACENOUKUPNIIZNOS"];
                this.columnKREDITOTPLACENIIZNOS = this.Columns["KREDITOTPLACENIIZNOS"];
                this.columnKREDITOTPLACENORATA = this.Columns["KREDITOTPLACENORATA"];
                this.columnZADKREDITIVBDIKREDITOR = this.Columns["ZADKREDITIVBDIKREDITOR"];
                this.columnZADKREDITIZRNKREDITOR = this.Columns["ZADKREDITIZRNKREDITOR"];
                this.columnPARTIJAKREDITASPECIFIKACIJA = this.Columns["PARTIJAKREDITASPECIFIKACIJA"];
            }

            public RADNIKDataSet.RADNIKKreditiRow NewRADNIKKreditiRow()
            {
                return (RADNIKDataSet.RADNIKKreditiRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RADNIKDataSet.RADNIKKreditiRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RADNIKKreditiRowChanged != null)
                {
                    RADNIKDataSet.RADNIKKreditiRowChangeEventHandler rADNIKKreditiRowChangedEvent = this.RADNIKKreditiRowChanged;
                    if (rADNIKKreditiRowChangedEvent != null)
                    {
                        rADNIKKreditiRowChangedEvent(this, new RADNIKDataSet.RADNIKKreditiRowChangeEvent((RADNIKDataSet.RADNIKKreditiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RADNIKKreditiRowChanging != null)
                {
                    RADNIKDataSet.RADNIKKreditiRowChangeEventHandler rADNIKKreditiRowChangingEvent = this.RADNIKKreditiRowChanging;
                    if (rADNIKKreditiRowChangingEvent != null)
                    {
                        rADNIKKreditiRowChangingEvent(this, new RADNIKDataSet.RADNIKKreditiRowChangeEvent((RADNIKDataSet.RADNIKKreditiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("RADNIK_RADNIKKrediti", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.RADNIKKreditiRowDeleted != null)
                {
                    RADNIKDataSet.RADNIKKreditiRowChangeEventHandler rADNIKKreditiRowDeletedEvent = this.RADNIKKreditiRowDeleted;
                    if (rADNIKKreditiRowDeletedEvent != null)
                    {
                        rADNIKKreditiRowDeletedEvent(this, new RADNIKDataSet.RADNIKKreditiRowChangeEvent((RADNIKDataSet.RADNIKKreditiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RADNIKKreditiRowDeleting != null)
                {
                    RADNIKDataSet.RADNIKKreditiRowChangeEventHandler rADNIKKreditiRowDeletingEvent = this.RADNIKKreditiRowDeleting;
                    if (rADNIKKreditiRowDeletingEvent != null)
                    {
                        rADNIKKreditiRowDeletingEvent(this, new RADNIKDataSet.RADNIKKreditiRowChangeEvent((RADNIKDataSet.RADNIKKreditiRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRADNIKKreditiRow(RADNIKDataSet.RADNIKKreditiRow row)
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

            public DataColumn DATUMUGOVORAColumn
            {
                get
                {
                    return this.columnDATUMUGOVORA;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public RADNIKDataSet.RADNIKKreditiRow this[int index]
            {
                get
                {
                    return (RADNIKDataSet.RADNIKKreditiRow) this.Rows[index];
                }
            }

            public DataColumn KREDITAKTIVANColumn
            {
                get
                {
                    return this.columnKREDITAKTIVAN;
                }
            }

            public DataColumn KREDITOTPLACENIIZNOSColumn
            {
                get
                {
                    return this.columnKREDITOTPLACENIIZNOS;
                }
            }

            public DataColumn KREDITOTPLACENORATAColumn
            {
                get
                {
                    return this.columnKREDITOTPLACENORATA;
                }
            }

            public DataColumn MOKREDITORColumn
            {
                get
                {
                    return this.columnMOKREDITOR;
                }
            }

            public DataColumn MZKREDITORColumn
            {
                get
                {
                    return this.columnMZKREDITOR;
                }
            }

            public DataColumn OPISPLACANJAKREDITORColumn
            {
                get
                {
                    return this.columnOPISPLACANJAKREDITOR;
                }
            }

            public DataColumn PARTIJAKREDITASPECIFIKACIJAColumn
            {
                get
                {
                    return this.columnPARTIJAKREDITASPECIFIKACIJA;
                }
            }

            public DataColumn POKREDITORColumn
            {
                get
                {
                    return this.columnPOKREDITOR;
                }
            }

            public DataColumn PZKREDITORColumn
            {
                get
                {
                    return this.columnPZKREDITOR;
                }
            }

            public DataColumn SIFRAOPISAPLACANJAKREDITORColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJAKREDITOR;
                }
            }

            public DataColumn ZADBROJRATAOBUSTAVEColumn
            {
                get
                {
                    return this.columnZADBROJRATAOBUSTAVE;
                }
            }

            public DataColumn ZADIZNOSRATEKREDITAColumn
            {
                get
                {
                    return this.columnZADIZNOSRATEKREDITA;
                }
            }

            public DataColumn ZADKREDITIIDKREDITORColumn
            {
                get
                {
                    return this.columnZADKREDITIIDKREDITOR;
                }
            }

            public DataColumn ZADKREDITINAZIVKREDITORColumn
            {
                get
                {
                    return this.columnZADKREDITINAZIVKREDITOR;
                }
            }

            public DataColumn ZADKREDITIPRIMATELJKREDITOR1Column
            {
                get
                {
                    return this.columnZADKREDITIPRIMATELJKREDITOR1;
                }
            }

            public DataColumn ZADKREDITIPRIMATELJKREDITOR2Column
            {
                get
                {
                    return this.columnZADKREDITIPRIMATELJKREDITOR2;
                }
            }

            public DataColumn ZADKREDITIPRIMATELJKREDITOR3Column
            {
                get
                {
                    return this.columnZADKREDITIPRIMATELJKREDITOR3;
                }
            }

            public DataColumn ZADKREDITIVBDIKREDITORColumn
            {
                get
                {
                    return this.columnZADKREDITIVBDIKREDITOR;
                }
            }

            public DataColumn ZADKREDITIZRNKREDITORColumn
            {
                get
                {
                    return this.columnZADKREDITIZRNKREDITOR;
                }
            }

            public DataColumn ZADUKUPNIZNOSKREDITAColumn
            {
                get
                {
                    return this.columnZADUKUPNIZNOSKREDITA;
                }
            }

            public DataColumn ZADVECOTPLACENOBROJRATAColumn
            {
                get
                {
                    return this.columnZADVECOTPLACENOBROJRATA;
                }
            }

            public DataColumn ZADVECOTPLACENOUKUPNIIZNOSColumn
            {
                get
                {
                    return this.columnZADVECOTPLACENOUKUPNIIZNOS;
                }
            }
        }

        public class RADNIKKreditiRow : DataRow
        {
            private RADNIKDataSet.RADNIKKreditiDataTable tableRADNIKKrediti;

            internal RADNIKKreditiRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRADNIKKrediti = (RADNIKDataSet.RADNIKKreditiDataTable) this.Table;
            }

            public RADNIKDataSet.RADNIKRow GetRADNIKRow()
            {
                return (RADNIKDataSet.RADNIKRow) this.GetParentRow("RADNIK_RADNIKKrediti");
            }

            public bool IsDATUMUGOVORANull()
            {
                return this.IsNull(this.tableRADNIKKrediti.DATUMUGOVORAColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.IDRADNIKColumn);
            }

            public bool IsKREDITAKTIVANNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.KREDITAKTIVANColumn);
            }

            public bool IsKREDITOTPLACENIIZNOSNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.KREDITOTPLACENIIZNOSColumn);
            }

            public bool IsKREDITOTPLACENORATANull()
            {
                return this.IsNull(this.tableRADNIKKrediti.KREDITOTPLACENORATAColumn);
            }

            public bool IsMOKREDITORNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.MOKREDITORColumn);
            }

            public bool IsMZKREDITORNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.MZKREDITORColumn);
            }

            public bool IsOPISPLACANJAKREDITORNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.OPISPLACANJAKREDITORColumn);
            }

            public bool IsPARTIJAKREDITASPECIFIKACIJANull()
            {
                return this.IsNull(this.tableRADNIKKrediti.PARTIJAKREDITASPECIFIKACIJAColumn);
            }

            public bool IsPOKREDITORNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.POKREDITORColumn);
            }

            public bool IsPZKREDITORNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.PZKREDITORColumn);
            }

            public bool IsSIFRAOPISAPLACANJAKREDITORNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.SIFRAOPISAPLACANJAKREDITORColumn);
            }

            public bool IsZADBROJRATAOBUSTAVENull()
            {
                return this.IsNull(this.tableRADNIKKrediti.ZADBROJRATAOBUSTAVEColumn);
            }

            public bool IsZADIZNOSRATEKREDITANull()
            {
                return this.IsNull(this.tableRADNIKKrediti.ZADIZNOSRATEKREDITAColumn);
            }

            public bool IsZADKREDITIIDKREDITORNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.ZADKREDITIIDKREDITORColumn);
            }

            public bool IsZADKREDITINAZIVKREDITORNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.ZADKREDITINAZIVKREDITORColumn);
            }

            public bool IsZADKREDITIPRIMATELJKREDITOR1Null()
            {
                return this.IsNull(this.tableRADNIKKrediti.ZADKREDITIPRIMATELJKREDITOR1Column);
            }

            public bool IsZADKREDITIPRIMATELJKREDITOR2Null()
            {
                return this.IsNull(this.tableRADNIKKrediti.ZADKREDITIPRIMATELJKREDITOR2Column);
            }

            public bool IsZADKREDITIPRIMATELJKREDITOR3Null()
            {
                return this.IsNull(this.tableRADNIKKrediti.ZADKREDITIPRIMATELJKREDITOR3Column);
            }

            public bool IsZADKREDITIVBDIKREDITORNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.ZADKREDITIVBDIKREDITORColumn);
            }

            public bool IsZADKREDITIZRNKREDITORNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.ZADKREDITIZRNKREDITORColumn);
            }

            public bool IsZADUKUPNIZNOSKREDITANull()
            {
                return this.IsNull(this.tableRADNIKKrediti.ZADUKUPNIZNOSKREDITAColumn);
            }

            public bool IsZADVECOTPLACENOBROJRATANull()
            {
                return this.IsNull(this.tableRADNIKKrediti.ZADVECOTPLACENOBROJRATAColumn);
            }

            public bool IsZADVECOTPLACENOUKUPNIIZNOSNull()
            {
                return this.IsNull(this.tableRADNIKKrediti.ZADVECOTPLACENOUKUPNIIZNOSColumn);
            }

            public void SetKREDITAKTIVANNull()
            {
                this[this.tableRADNIKKrediti.KREDITAKTIVANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKREDITOTPLACENIIZNOSNull()
            {
                this[this.tableRADNIKKrediti.KREDITOTPLACENIIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKREDITOTPLACENORATANull()
            {
                this[this.tableRADNIKKrediti.KREDITOTPLACENORATAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMOKREDITORNull()
            {
                this[this.tableRADNIKKrediti.MOKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZKREDITORNull()
            {
                this[this.tableRADNIKKrediti.MZKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAKREDITORNull()
            {
                this[this.tableRADNIKKrediti.OPISPLACANJAKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTIJAKREDITASPECIFIKACIJANull()
            {
                this[this.tableRADNIKKrediti.PARTIJAKREDITASPECIFIKACIJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOKREDITORNull()
            {
                this[this.tableRADNIKKrediti.POKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZKREDITORNull()
            {
                this[this.tableRADNIKKrediti.PZKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAKREDITORNull()
            {
                this[this.tableRADNIKKrediti.SIFRAOPISAPLACANJAKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADBROJRATAOBUSTAVENull()
            {
                this[this.tableRADNIKKrediti.ZADBROJRATAOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADIZNOSRATEKREDITANull()
            {
                this[this.tableRADNIKKrediti.ZADIZNOSRATEKREDITAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADKREDITINAZIVKREDITORNull()
            {
                this[this.tableRADNIKKrediti.ZADKREDITINAZIVKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADKREDITIPRIMATELJKREDITOR1Null()
            {
                this[this.tableRADNIKKrediti.ZADKREDITIPRIMATELJKREDITOR1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADKREDITIPRIMATELJKREDITOR2Null()
            {
                this[this.tableRADNIKKrediti.ZADKREDITIPRIMATELJKREDITOR2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADKREDITIPRIMATELJKREDITOR3Null()
            {
                this[this.tableRADNIKKrediti.ZADKREDITIPRIMATELJKREDITOR3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADKREDITIVBDIKREDITORNull()
            {
                this[this.tableRADNIKKrediti.ZADKREDITIVBDIKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADKREDITIZRNKREDITORNull()
            {
                this[this.tableRADNIKKrediti.ZADKREDITIZRNKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADUKUPNIZNOSKREDITANull()
            {
                this[this.tableRADNIKKrediti.ZADUKUPNIZNOSKREDITAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADVECOTPLACENOBROJRATANull()
            {
                this[this.tableRADNIKKrediti.ZADVECOTPLACENOBROJRATAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADVECOTPLACENOUKUPNIIZNOSNull()
            {
                this[this.tableRADNIKKrediti.ZADVECOTPLACENOUKUPNIIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public DateTime DATUMUGOVORA
            {
                get
                {
                    return Conversions.ToDate(this[this.tableRADNIKKrediti.DATUMUGOVORAColumn]);
                }
                set
                {
                    this[this.tableRADNIKKrediti.DATUMUGOVORAColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKKrediti.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableRADNIKKrediti.IDRADNIKColumn] = value;
                }
            }

            public bool KREDITAKTIVAN
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableRADNIKKrediti.KREDITAKTIVANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableRADNIKKrediti.KREDITAKTIVANColumn] = value;
                }
            }

            public decimal KREDITOTPLACENIIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKKrediti.KREDITOTPLACENIIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKKrediti.KREDITOTPLACENIIZNOSColumn] = value;
                }
            }

            public decimal KREDITOTPLACENORATA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKKrediti.KREDITOTPLACENORATAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKKrediti.KREDITOTPLACENORATAColumn] = value;
                }
            }

            public string MOKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKKrediti.MOKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKKrediti.MOKREDITORColumn] = value;
                }
            }

            public string MZKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKKrediti.MZKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKKrediti.MZKREDITORColumn] = value;
                }
            }

            public string OPISPLACANJAKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKKrediti.OPISPLACANJAKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKKrediti.OPISPLACANJAKREDITORColumn] = value;
                }
            }

            public string PARTIJAKREDITASPECIFIKACIJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKKrediti.PARTIJAKREDITASPECIFIKACIJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKKrediti.PARTIJAKREDITASPECIFIKACIJAColumn] = value;
                }
            }

            public string POKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKKrediti.POKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKKrediti.POKREDITORColumn] = value;
                }
            }

            public string PZKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKKrediti.PZKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKKrediti.PZKREDITORColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKKrediti.SIFRAOPISAPLACANJAKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKKrediti.SIFRAOPISAPLACANJAKREDITORColumn] = value;
                }
            }

            public decimal ZADBROJRATAOBUSTAVE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKKrediti.ZADBROJRATAOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKKrediti.ZADBROJRATAOBUSTAVEColumn] = value;
                }
            }

            public decimal ZADIZNOSRATEKREDITA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKKrediti.ZADIZNOSRATEKREDITAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKKrediti.ZADIZNOSRATEKREDITAColumn] = value;
                }
            }

            public int ZADKREDITIIDKREDITOR
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKKrediti.ZADKREDITIIDKREDITORColumn]);
                }
                set
                {
                    this[this.tableRADNIKKrediti.ZADKREDITIIDKREDITORColumn] = value;
                }
            }

            public string ZADKREDITINAZIVKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKKrediti.ZADKREDITINAZIVKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKKrediti.ZADKREDITINAZIVKREDITORColumn] = value;
                }
            }

            public string ZADKREDITIPRIMATELJKREDITOR1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKKrediti.ZADKREDITIPRIMATELJKREDITOR1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKKrediti.ZADKREDITIPRIMATELJKREDITOR1Column] = value;
                }
            }

            public string ZADKREDITIPRIMATELJKREDITOR2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKKrediti.ZADKREDITIPRIMATELJKREDITOR2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKKrediti.ZADKREDITIPRIMATELJKREDITOR2Column] = value;
                }
            }

            public string ZADKREDITIPRIMATELJKREDITOR3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKKrediti.ZADKREDITIPRIMATELJKREDITOR3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKKrediti.ZADKREDITIPRIMATELJKREDITOR3Column] = value;
                }
            }

            public string ZADKREDITIVBDIKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKKrediti.ZADKREDITIVBDIKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKKrediti.ZADKREDITIVBDIKREDITORColumn] = value;
                }
            }

            public string ZADKREDITIZRNKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKKrediti.ZADKREDITIZRNKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKKrediti.ZADKREDITIZRNKREDITORColumn] = value;
                }
            }

            public decimal ZADUKUPNIZNOSKREDITA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKKrediti.ZADUKUPNIZNOSKREDITAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKKrediti.ZADUKUPNIZNOSKREDITAColumn] = value;
                }
            }

            public decimal ZADVECOTPLACENOBROJRATA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKKrediti.ZADVECOTPLACENOBROJRATAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKKrediti.ZADVECOTPLACENOBROJRATAColumn] = value;
                }
            }

            public decimal ZADVECOTPLACENOUKUPNIIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKKrediti.ZADVECOTPLACENOUKUPNIIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKKrediti.ZADVECOTPLACENOUKUPNIIZNOSColumn] = value;
                }
            }
        }

        public class RADNIKKreditiRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RADNIKDataSet.RADNIKKreditiRow eventRow;

            public RADNIKKreditiRowChangeEvent(RADNIKDataSet.RADNIKKreditiRow row, DataRowAction action)
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

            public RADNIKDataSet.RADNIKKreditiRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RADNIKKreditiRowChangeEventHandler(object sender, RADNIKDataSet.RADNIKKreditiRowChangeEvent e);

        [Serializable]
        public class RADNIKLevel7DataTable : DataTable, IEnumerable
        {
            private DataColumn columnDODATNIKOEFICIJENT;
            private DataColumn columnIDGRUPEKOEF;
            private DataColumn columnIDRADNIK;
            private DataColumn columnNAZIVGRUPEKOEF;

            public event RADNIKDataSet.RADNIKLevel7RowChangeEventHandler RADNIKLevel7RowChanged;

            public event RADNIKDataSet.RADNIKLevel7RowChangeEventHandler RADNIKLevel7RowChanging;

            public event RADNIKDataSet.RADNIKLevel7RowChangeEventHandler RADNIKLevel7RowDeleted;

            public event RADNIKDataSet.RADNIKLevel7RowChangeEventHandler RADNIKLevel7RowDeleting;

            public RADNIKLevel7DataTable()
            {
                this.TableName = "RADNIKLevel7";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RADNIKLevel7DataTable(DataTable table) : base(table.TableName)
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

            protected RADNIKLevel7DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRADNIKLevel7Row(RADNIKDataSet.RADNIKLevel7Row row)
            {
                this.Rows.Add(row);
            }

            public RADNIKDataSet.RADNIKLevel7Row AddRADNIKLevel7Row(int iDRADNIK, int iDGRUPEKOEF, decimal dODATNIKOEFICIJENT)
            {
                RADNIKDataSet.RADNIKLevel7Row row = (RADNIKDataSet.RADNIKLevel7Row) this.NewRow();
                row["IDRADNIK"] = iDRADNIK;
                row["IDGRUPEKOEF"] = iDGRUPEKOEF;
                row["DODATNIKOEFICIJENT"] = dODATNIKOEFICIJENT;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RADNIKDataSet.RADNIKLevel7DataTable table = (RADNIKDataSet.RADNIKLevel7DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RADNIKDataSet.RADNIKLevel7Row FindByIDRADNIKIDGRUPEKOEF(int iDRADNIK, int iDGRUPEKOEF)
            {
                return (RADNIKDataSet.RADNIKLevel7Row) this.Rows.Find(new object[] { iDRADNIK, iDGRUPEKOEF });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RADNIKDataSet.RADNIKLevel7Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RADNIKDataSet set = new RADNIKDataSet();
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
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnIDGRUPEKOEF = new DataColumn("IDGRUPEKOEF", typeof(int), "", MappingType.Element);
                this.columnIDGRUPEKOEF.AllowDBNull = false;
                this.columnIDGRUPEKOEF.Caption = "IDGRUPEKOEF";
                this.columnIDGRUPEKOEF.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("IsKey", "true");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Length", "5");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Decimals", "0");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.InternalName", "IDGRUPEKOEF");
                this.Columns.Add(this.columnIDGRUPEKOEF);
                this.columnNAZIVGRUPEKOEF = new DataColumn("NAZIVGRUPEKOEF", typeof(string), "", MappingType.Element);
                this.columnNAZIVGRUPEKOEF.AllowDBNull = true;
                this.columnNAZIVGRUPEKOEF.Caption = "NAZIVGRUPEKOEF";
                this.columnNAZIVGRUPEKOEF.MaxLength = 50;
                this.columnNAZIVGRUPEKOEF.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Description", "Naziv");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVGRUPEKOEF");
                this.Columns.Add(this.columnNAZIVGRUPEKOEF);
                this.columnDODATNIKOEFICIJENT = new DataColumn("DODATNIKOEFICIJENT", typeof(decimal), "", MappingType.Element);
                this.columnDODATNIKOEFICIJENT.AllowDBNull = false;
                this.columnDODATNIKOEFICIJENT.Caption = "DODATNIKOEFICIJENT";
                this.columnDODATNIKOEFICIJENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("IsKey", "false");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Description", "Koeficijent");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Length", "12");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Decimals", "8");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("DomainType", "PUNODECIMALA");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDODATNIKOEFICIJENT.ExtendedProperties.Add("Deklarit.InternalName", "DODATNIKOEFICIJENT");
                this.Columns.Add(this.columnDODATNIKOEFICIJENT);
                this.PrimaryKey = new DataColumn[] { this.columnIDRADNIK, this.columnIDGRUPEKOEF };
                this.ExtendedProperties.Add("ParentLvl", "RADNIK");
                this.ExtendedProperties.Add("LevelName", "Koeficijenti");
                this.ExtendedProperties.Add("Description", "Koeficijenti");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnIDGRUPEKOEF = this.Columns["IDGRUPEKOEF"];
                this.columnNAZIVGRUPEKOEF = this.Columns["NAZIVGRUPEKOEF"];
                this.columnDODATNIKOEFICIJENT = this.Columns["DODATNIKOEFICIJENT"];
            }

            public RADNIKDataSet.RADNIKLevel7Row NewRADNIKLevel7Row()
            {
                return (RADNIKDataSet.RADNIKLevel7Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RADNIKDataSet.RADNIKLevel7Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RADNIKLevel7RowChanged != null)
                {
                    RADNIKDataSet.RADNIKLevel7RowChangeEventHandler handler = this.RADNIKLevel7RowChanged;
                    if (handler != null)
                    {
                        handler(this, new RADNIKDataSet.RADNIKLevel7RowChangeEvent((RADNIKDataSet.RADNIKLevel7Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RADNIKLevel7RowChanging != null)
                {
                    RADNIKDataSet.RADNIKLevel7RowChangeEventHandler handler = this.RADNIKLevel7RowChanging;
                    if (handler != null)
                    {
                        handler(this, new RADNIKDataSet.RADNIKLevel7RowChangeEvent((RADNIKDataSet.RADNIKLevel7Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("RADNIK_RADNIKLevel7", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.RADNIKLevel7RowDeleted != null)
                {
                    RADNIKDataSet.RADNIKLevel7RowChangeEventHandler handler = this.RADNIKLevel7RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new RADNIKDataSet.RADNIKLevel7RowChangeEvent((RADNIKDataSet.RADNIKLevel7Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RADNIKLevel7RowDeleting != null)
                {
                    RADNIKDataSet.RADNIKLevel7RowChangeEventHandler handler = this.RADNIKLevel7RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new RADNIKDataSet.RADNIKLevel7RowChangeEvent((RADNIKDataSet.RADNIKLevel7Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRADNIKLevel7Row(RADNIKDataSet.RADNIKLevel7Row row)
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

            public DataColumn DODATNIKOEFICIJENTColumn
            {
                get
                {
                    return this.columnDODATNIKOEFICIJENT;
                }
            }

            public DataColumn IDGRUPEKOEFColumn
            {
                get
                {
                    return this.columnIDGRUPEKOEF;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public RADNIKDataSet.RADNIKLevel7Row this[int index]
            {
                get
                {
                    return (RADNIKDataSet.RADNIKLevel7Row) this.Rows[index];
                }
            }

            public DataColumn NAZIVGRUPEKOEFColumn
            {
                get
                {
                    return this.columnNAZIVGRUPEKOEF;
                }
            }
        }

        public class RADNIKLevel7Row : DataRow
        {
            private RADNIKDataSet.RADNIKLevel7DataTable tableRADNIKLevel7;

            internal RADNIKLevel7Row(DataRowBuilder rb) : base(rb)
            {
                this.tableRADNIKLevel7 = (RADNIKDataSet.RADNIKLevel7DataTable) this.Table;
            }

            public RADNIKDataSet.RADNIKRow GetRADNIKRow()
            {
                return (RADNIKDataSet.RADNIKRow) this.GetParentRow("RADNIK_RADNIKLevel7");
            }

            public bool IsDODATNIKOEFICIJENTNull()
            {
                return this.IsNull(this.tableRADNIKLevel7.DODATNIKOEFICIJENTColumn);
            }

            public bool IsIDGRUPEKOEFNull()
            {
                return this.IsNull(this.tableRADNIKLevel7.IDGRUPEKOEFColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableRADNIKLevel7.IDRADNIKColumn);
            }

            public bool IsNAZIVGRUPEKOEFNull()
            {
                return this.IsNull(this.tableRADNIKLevel7.NAZIVGRUPEKOEFColumn);
            }

            public void SetDODATNIKOEFICIJENTNull()
            {
                this[this.tableRADNIKLevel7.DODATNIKOEFICIJENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVGRUPEKOEFNull()
            {
                this[this.tableRADNIKLevel7.NAZIVGRUPEKOEFColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal DODATNIKOEFICIJENT
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKLevel7.DODATNIKOEFICIJENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKLevel7.DODATNIKOEFICIJENTColumn] = value;
                }
            }

            public int IDGRUPEKOEF
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKLevel7.IDGRUPEKOEFColumn]);
                }
                set
                {
                    this[this.tableRADNIKLevel7.IDGRUPEKOEFColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKLevel7.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableRADNIKLevel7.IDRADNIKColumn] = value;
                }
            }

            public string NAZIVGRUPEKOEF
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKLevel7.NAZIVGRUPEKOEFColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKLevel7.NAZIVGRUPEKOEFColumn] = value;
                }
            }
        }

        public class RADNIKLevel7RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RADNIKDataSet.RADNIKLevel7Row eventRow;

            public RADNIKLevel7RowChangeEvent(RADNIKDataSet.RADNIKLevel7Row row, DataRowAction action)
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

            public RADNIKDataSet.RADNIKLevel7Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RADNIKLevel7RowChangeEventHandler(object sender, RADNIKDataSet.RADNIKLevel7RowChangeEvent e);

        [Serializable]
        public class RADNIKNetoDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRADNIK;
            private DataColumn columnNETOELEMENTIDELEMENT;
            private DataColumn columnNETOELEMENTNAZIVELEMENT;
            private DataColumn columnNETOIZNOS;
            private DataColumn columnNETOPOSTOTAK;
            private DataColumn columnNETOSATI;
            private DataColumn columnNETOSATNICA;

            public event RADNIKDataSet.RADNIKNetoRowChangeEventHandler RADNIKNetoRowChanged;

            public event RADNIKDataSet.RADNIKNetoRowChangeEventHandler RADNIKNetoRowChanging;

            public event RADNIKDataSet.RADNIKNetoRowChangeEventHandler RADNIKNetoRowDeleted;

            public event RADNIKDataSet.RADNIKNetoRowChangeEventHandler RADNIKNetoRowDeleting;

            public RADNIKNetoDataTable()
            {
                this.TableName = "RADNIKNeto";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RADNIKNetoDataTable(DataTable table) : base(table.TableName)
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

            protected RADNIKNetoDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRADNIKNetoRow(RADNIKDataSet.RADNIKNetoRow row)
            {
                this.Rows.Add(row);
            }

            public RADNIKDataSet.RADNIKNetoRow AddRADNIKNetoRow(int iDRADNIK, int nETOELEMENTIDELEMENT, decimal nETOSATNICA, decimal nETOSATI, decimal nETOPOSTOTAK, decimal nETOIZNOS)
            {
                RADNIKDataSet.RADNIKNetoRow row = (RADNIKDataSet.RADNIKNetoRow) this.NewRow();
                row["IDRADNIK"] = iDRADNIK;
                row["NETOELEMENTIDELEMENT"] = nETOELEMENTIDELEMENT;
                row["NETOSATNICA"] = nETOSATNICA;
                row["NETOSATI"] = nETOSATI;
                row["NETOPOSTOTAK"] = nETOPOSTOTAK;
                row["NETOIZNOS"] = nETOIZNOS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RADNIKDataSet.RADNIKNetoDataTable table = (RADNIKDataSet.RADNIKNetoDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RADNIKDataSet.RADNIKNetoRow FindByIDRADNIKNETOELEMENTIDELEMENT(int iDRADNIK, int nETOELEMENTIDELEMENT)
            {
                return (RADNIKDataSet.RADNIKNetoRow) this.Rows.Find(new object[] { iDRADNIK, nETOELEMENTIDELEMENT });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RADNIKDataSet.RADNIKNetoRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RADNIKDataSet set = new RADNIKDataSet();
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
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnNETOELEMENTIDELEMENT = new DataColumn("NETOELEMENTIDELEMENT", typeof(int), "", MappingType.Element);
                this.columnNETOELEMENTIDELEMENT.AllowDBNull = false;
                this.columnNETOELEMENTIDELEMENT.Caption = "Šifra elementa";
                this.columnNETOELEMENTIDELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("SuperType", "IDELEMENT");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("SubtypeGroup", "NETOELEMENT");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("Description", "Šifra");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("Length", "8");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNETOELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "NETOELEMENTIDELEMENT");
                this.Columns.Add(this.columnNETOELEMENTIDELEMENT);
                this.columnNETOELEMENTNAZIVELEMENT = new DataColumn("NETOELEMENTNAZIVELEMENT", typeof(string), "", MappingType.Element);
                this.columnNETOELEMENTNAZIVELEMENT.AllowDBNull = true;
                this.columnNETOELEMENTNAZIVELEMENT.Caption = "Naziv elementa";
                this.columnNETOELEMENTNAZIVELEMENT.MaxLength = 50;
                this.columnNETOELEMENTNAZIVELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("SuperType", "NAZIVELEMENT");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("SubtypeGroup", "NETOELEMENT");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Description", "Naziv");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Length", "50");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNETOELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "NETOELEMENTNAZIVELEMENT");
                this.Columns.Add(this.columnNETOELEMENTNAZIVELEMENT);
                this.columnNETOSATNICA = new DataColumn("NETOSATNICA", typeof(decimal), "", MappingType.Element);
                this.columnNETOSATNICA.AllowDBNull = false;
                this.columnNETOSATNICA.Caption = "NETOSATNICA";
                this.columnNETOSATNICA.DefaultValue = 0;
                this.columnNETOSATNICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNETOSATNICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNETOSATNICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNETOSATNICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNETOSATNICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNETOSATNICA.ExtendedProperties.Add("IsKey", "false");
                this.columnNETOSATNICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNETOSATNICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNETOSATNICA.ExtendedProperties.Add("Description", "Satnica");
                this.columnNETOSATNICA.ExtendedProperties.Add("Length", "12");
                this.columnNETOSATNICA.ExtendedProperties.Add("Decimals", "8");
                this.columnNETOSATNICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNETOSATNICA.ExtendedProperties.Add("DomainType", "PUNODECIMALA");
                this.columnNETOSATNICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNETOSATNICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNETOSATNICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNETOSATNICA.ExtendedProperties.Add("Deklarit.InternalName", "NETOSATNICA");
                this.Columns.Add(this.columnNETOSATNICA);
                this.columnNETOSATI = new DataColumn("NETOSATI", typeof(decimal), "", MappingType.Element);
                this.columnNETOSATI.AllowDBNull = false;
                this.columnNETOSATI.Caption = "NETOSATI";
                this.columnNETOSATI.DefaultValue = 0;
                this.columnNETOSATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNETOSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNETOSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNETOSATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNETOSATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNETOSATI.ExtendedProperties.Add("IsKey", "false");
                this.columnNETOSATI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNETOSATI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNETOSATI.ExtendedProperties.Add("Description", "Sati");
                this.columnNETOSATI.ExtendedProperties.Add("Length", "5");
                this.columnNETOSATI.ExtendedProperties.Add("Decimals", "2");
                this.columnNETOSATI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNETOSATI.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnNETOSATI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNETOSATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNETOSATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNETOSATI.ExtendedProperties.Add("Deklarit.InternalName", "NETOSATI");
                this.Columns.Add(this.columnNETOSATI);
                this.columnNETOPOSTOTAK = new DataColumn("NETOPOSTOTAK", typeof(decimal), "", MappingType.Element);
                this.columnNETOPOSTOTAK.AllowDBNull = false;
                this.columnNETOPOSTOTAK.Caption = "NETOPOSTOTAK";
                this.columnNETOPOSTOTAK.DefaultValue = 0;
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("IsKey", "false");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("Description", "Postotak");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("Length", "5");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("Decimals", "2");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNETOPOSTOTAK.ExtendedProperties.Add("Deklarit.InternalName", "NETOPOSTOTAK");
                this.Columns.Add(this.columnNETOPOSTOTAK);
                this.columnNETOIZNOS = new DataColumn("NETOIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnNETOIZNOS.AllowDBNull = false;
                this.columnNETOIZNOS.Caption = "NETOIZNOS";
                this.columnNETOIZNOS.DefaultValue = 0;
                this.columnNETOIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNETOIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNETOIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNETOIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNETOIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNETOIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnNETOIZNOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNETOIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnNETOIZNOS.ExtendedProperties.Add("Description", "Iznos");
                this.columnNETOIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnNETOIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnNETOIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnNETOIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnNETOIZNOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNETOIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNETOIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNETOIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "NETOIZNOS");
                this.Columns.Add(this.columnNETOIZNOS);
                this.PrimaryKey = new DataColumn[] { this.columnIDRADNIK, this.columnNETOELEMENTIDELEMENT };
                this.ExtendedProperties.Add("ParentLvl", "RADNIK");
                this.ExtendedProperties.Add("LevelName", "ZaduzeniNeto");
                this.ExtendedProperties.Add("Description", "Neto elementi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnNETOELEMENTIDELEMENT = this.Columns["NETOELEMENTIDELEMENT"];
                this.columnNETOELEMENTNAZIVELEMENT = this.Columns["NETOELEMENTNAZIVELEMENT"];
                this.columnNETOSATNICA = this.Columns["NETOSATNICA"];
                this.columnNETOSATI = this.Columns["NETOSATI"];
                this.columnNETOPOSTOTAK = this.Columns["NETOPOSTOTAK"];
                this.columnNETOIZNOS = this.Columns["NETOIZNOS"];
            }

            public RADNIKDataSet.RADNIKNetoRow NewRADNIKNetoRow()
            {
                return (RADNIKDataSet.RADNIKNetoRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RADNIKDataSet.RADNIKNetoRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RADNIKNetoRowChanged != null)
                {
                    RADNIKDataSet.RADNIKNetoRowChangeEventHandler rADNIKNetoRowChangedEvent = this.RADNIKNetoRowChanged;
                    if (rADNIKNetoRowChangedEvent != null)
                    {
                        rADNIKNetoRowChangedEvent(this, new RADNIKDataSet.RADNIKNetoRowChangeEvent((RADNIKDataSet.RADNIKNetoRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RADNIKNetoRowChanging != null)
                {
                    RADNIKDataSet.RADNIKNetoRowChangeEventHandler rADNIKNetoRowChangingEvent = this.RADNIKNetoRowChanging;
                    if (rADNIKNetoRowChangingEvent != null)
                    {
                        rADNIKNetoRowChangingEvent(this, new RADNIKDataSet.RADNIKNetoRowChangeEvent((RADNIKDataSet.RADNIKNetoRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("RADNIK_RADNIKNeto", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.RADNIKNetoRowDeleted != null)
                {
                    RADNIKDataSet.RADNIKNetoRowChangeEventHandler rADNIKNetoRowDeletedEvent = this.RADNIKNetoRowDeleted;
                    if (rADNIKNetoRowDeletedEvent != null)
                    {
                        rADNIKNetoRowDeletedEvent(this, new RADNIKDataSet.RADNIKNetoRowChangeEvent((RADNIKDataSet.RADNIKNetoRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RADNIKNetoRowDeleting != null)
                {
                    RADNIKDataSet.RADNIKNetoRowChangeEventHandler rADNIKNetoRowDeletingEvent = this.RADNIKNetoRowDeleting;
                    if (rADNIKNetoRowDeletingEvent != null)
                    {
                        rADNIKNetoRowDeletingEvent(this, new RADNIKDataSet.RADNIKNetoRowChangeEvent((RADNIKDataSet.RADNIKNetoRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRADNIKNetoRow(RADNIKDataSet.RADNIKNetoRow row)
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

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public RADNIKDataSet.RADNIKNetoRow this[int index]
            {
                get
                {
                    return (RADNIKDataSet.RADNIKNetoRow) this.Rows[index];
                }
            }

            public DataColumn NETOELEMENTIDELEMENTColumn
            {
                get
                {
                    return this.columnNETOELEMENTIDELEMENT;
                }
            }

            public DataColumn NETOELEMENTNAZIVELEMENTColumn
            {
                get
                {
                    return this.columnNETOELEMENTNAZIVELEMENT;
                }
            }

            public DataColumn NETOIZNOSColumn
            {
                get
                {
                    return this.columnNETOIZNOS;
                }
            }

            public DataColumn NETOPOSTOTAKColumn
            {
                get
                {
                    return this.columnNETOPOSTOTAK;
                }
            }

            public DataColumn NETOSATIColumn
            {
                get
                {
                    return this.columnNETOSATI;
                }
            }

            public DataColumn NETOSATNICAColumn
            {
                get
                {
                    return this.columnNETOSATNICA;
                }
            }
        }

        public class RADNIKNetoRow : DataRow
        {
            private RADNIKDataSet.RADNIKNetoDataTable tableRADNIKNeto;

            internal RADNIKNetoRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRADNIKNeto = (RADNIKDataSet.RADNIKNetoDataTable) this.Table;
            }

            public RADNIKDataSet.RADNIKRow GetRADNIKRow()
            {
                return (RADNIKDataSet.RADNIKRow) this.GetParentRow("RADNIK_RADNIKNeto");
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableRADNIKNeto.IDRADNIKColumn);
            }

            public bool IsNETOELEMENTIDELEMENTNull()
            {
                return this.IsNull(this.tableRADNIKNeto.NETOELEMENTIDELEMENTColumn);
            }

            public bool IsNETOELEMENTNAZIVELEMENTNull()
            {
                return this.IsNull(this.tableRADNIKNeto.NETOELEMENTNAZIVELEMENTColumn);
            }

            public bool IsNETOIZNOSNull()
            {
                return this.IsNull(this.tableRADNIKNeto.NETOIZNOSColumn);
            }

            public bool IsNETOPOSTOTAKNull()
            {
                return this.IsNull(this.tableRADNIKNeto.NETOPOSTOTAKColumn);
            }

            public bool IsNETOSATINull()
            {
                return this.IsNull(this.tableRADNIKNeto.NETOSATIColumn);
            }

            public bool IsNETOSATNICANull()
            {
                return this.IsNull(this.tableRADNIKNeto.NETOSATNICAColumn);
            }

            public void SetNETOELEMENTNAZIVELEMENTNull()
            {
                this[this.tableRADNIKNeto.NETOELEMENTNAZIVELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNETOIZNOSNull()
            {
                this[this.tableRADNIKNeto.NETOIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNETOPOSTOTAKNull()
            {
                this[this.tableRADNIKNeto.NETOPOSTOTAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNETOSATINull()
            {
                this[this.tableRADNIKNeto.NETOSATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNETOSATNICANull()
            {
                this[this.tableRADNIKNeto.NETOSATNICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKNeto.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableRADNIKNeto.IDRADNIKColumn] = value;
                }
            }

            public int NETOELEMENTIDELEMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKNeto.NETOELEMENTIDELEMENTColumn]);
                }
                set
                {
                    this[this.tableRADNIKNeto.NETOELEMENTIDELEMENTColumn] = value;
                }
            }

            public string NETOELEMENTNAZIVELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKNeto.NETOELEMENTNAZIVELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKNeto.NETOELEMENTNAZIVELEMENTColumn] = value;
                }
            }

            public decimal NETOIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKNeto.NETOIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKNeto.NETOIZNOSColumn] = value;
                }
            }

            public decimal NETOPOSTOTAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKNeto.NETOPOSTOTAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKNeto.NETOPOSTOTAKColumn] = value;
                }
            }

            public decimal NETOSATI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKNeto.NETOSATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKNeto.NETOSATIColumn] = value;
                }
            }

            public decimal NETOSATNICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKNeto.NETOSATNICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKNeto.NETOSATNICAColumn] = value;
                }
            }
        }

        public class RADNIKNetoRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RADNIKDataSet.RADNIKNetoRow eventRow;

            public RADNIKNetoRowChangeEvent(RADNIKDataSet.RADNIKNetoRow row, DataRowAction action)
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

            public RADNIKDataSet.RADNIKNetoRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RADNIKNetoRowChangeEventHandler(object sender, RADNIKDataSet.RADNIKNetoRowChangeEvent e);

        [Serializable]
        public class RADNIKObustavaDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRADNIK;
            private DataColumn columnOBUSTAVAAKTIVNA;
            private DataColumn columnOTPLACENIBROJRATA;
            private DataColumn columnOTPLACENIIZNOS;
            private DataColumn columnZADISPLACENOKASA;
            private DataColumn columnZADIZNOSOBUSTAVE;
            private DataColumn columnZADOBUSTAVAIDOBUSTAVA;
            private DataColumn columnZADOBUSTAVANAZIVOBUSTAVA;
            private DataColumn columnZADOBUSTAVANAZIVVRSTAOBUSTAVE;
            private DataColumn columnZADOBUSTAVAVBDIOBUSTAVA;
            private DataColumn columnZADOBUSTAVAVRSTAOBUSTAVE;
            private DataColumn columnZADOBUSTAVAZRNOBUSTAVA;
            private DataColumn columnZADPOSTOTAKOBUSTAVE;
            private DataColumn columnZADPOSTOTNAODBRUTA;
            private DataColumn columnZADSALDOKASA;

            public event RADNIKDataSet.RADNIKObustavaRowChangeEventHandler RADNIKObustavaRowChanged;

            public event RADNIKDataSet.RADNIKObustavaRowChangeEventHandler RADNIKObustavaRowChanging;

            public event RADNIKDataSet.RADNIKObustavaRowChangeEventHandler RADNIKObustavaRowDeleted;

            public event RADNIKDataSet.RADNIKObustavaRowChangeEventHandler RADNIKObustavaRowDeleting;

            public RADNIKObustavaDataTable()
            {
                this.TableName = "RADNIKObustava";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RADNIKObustavaDataTable(DataTable table) : base(table.TableName)
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

            protected RADNIKObustavaDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRADNIKObustavaRow(RADNIKDataSet.RADNIKObustavaRow row)
            {
                this.Rows.Add(row);
            }

            public RADNIKDataSet.RADNIKObustavaRow AddRADNIKObustavaRow(int iDRADNIK, int zADOBUSTAVAIDOBUSTAVA, bool oBUSTAVAAKTIVNA, decimal zADIZNOSOBUSTAVE, decimal zADPOSTOTAKOBUSTAVE, bool zADPOSTOTNAODBRUTA, decimal zADISPLACENOKASA, decimal zADSALDOKASA)
            {
                RADNIKDataSet.RADNIKObustavaRow row = (RADNIKDataSet.RADNIKObustavaRow) this.NewRow();
                row["IDRADNIK"] = iDRADNIK;
                row["ZADOBUSTAVAIDOBUSTAVA"] = zADOBUSTAVAIDOBUSTAVA;
                row["OBUSTAVAAKTIVNA"] = oBUSTAVAAKTIVNA;
                row["ZADIZNOSOBUSTAVE"] = zADIZNOSOBUSTAVE;
                row["ZADPOSTOTAKOBUSTAVE"] = zADPOSTOTAKOBUSTAVE;
                row["ZADPOSTOTNAODBRUTA"] = zADPOSTOTNAODBRUTA;
                row["ZADISPLACENOKASA"] = zADISPLACENOKASA;
                row["ZADSALDOKASA"] = zADSALDOKASA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RADNIKDataSet.RADNIKObustavaDataTable table = (RADNIKDataSet.RADNIKObustavaDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RADNIKDataSet.RADNIKObustavaRow FindByIDRADNIKZADOBUSTAVAIDOBUSTAVA(int iDRADNIK, int zADOBUSTAVAIDOBUSTAVA)
            {
                return (RADNIKDataSet.RADNIKObustavaRow) this.Rows.Find(new object[] { iDRADNIK, zADOBUSTAVAIDOBUSTAVA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RADNIKDataSet.RADNIKObustavaRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RADNIKDataSet set = new RADNIKDataSet();
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
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnZADOBUSTAVAIDOBUSTAVA = new DataColumn("ZADOBUSTAVAIDOBUSTAVA", typeof(int), "", MappingType.Element);
                this.columnZADOBUSTAVAIDOBUSTAVA.AllowDBNull = false;
                this.columnZADOBUSTAVAIDOBUSTAVA.Caption = "Šifra obustave";
                this.columnZADOBUSTAVAIDOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("SuperType", "IDOBUSTAVA");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("SubtypeGroup", "ZADOBUSTAVA");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("IsKey", "true");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("Description", "Šifra");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("Length", "8");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOBUSTAVAIDOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "ZADOBUSTAVAIDOBUSTAVA");
                this.Columns.Add(this.columnZADOBUSTAVAIDOBUSTAVA);
                this.columnOBUSTAVAAKTIVNA = new DataColumn("OBUSTAVAAKTIVNA", typeof(bool), "", MappingType.Element);
                this.columnOBUSTAVAAKTIVNA.AllowDBNull = false;
                this.columnOBUSTAVAAKTIVNA.Caption = "OBUSTAVAAKTIVNA";
                this.columnOBUSTAVAAKTIVNA.DefaultValue = true;
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("IsKey", "false");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("Description", "Obračunavaj obustavu");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("Length", "1");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("Decimals", "0");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBUSTAVAAKTIVNA.ExtendedProperties.Add("Deklarit.InternalName", "OBUSTAVAAKTIVNA");
                this.Columns.Add(this.columnOBUSTAVAAKTIVNA);
                this.columnZADOBUSTAVANAZIVOBUSTAVA = new DataColumn("ZADOBUSTAVANAZIVOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnZADOBUSTAVANAZIVOBUSTAVA.AllowDBNull = true;
                this.columnZADOBUSTAVANAZIVOBUSTAVA.Caption = "Naziv obustave";
                this.columnZADOBUSTAVANAZIVOBUSTAVA.MaxLength = 100;
                this.columnZADOBUSTAVANAZIVOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("SuperType", "NAZIVOBUSTAVA");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("SubtypeGroup", "ZADOBUSTAVA");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("Description", "Obustava");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("Length", "100");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOBUSTAVANAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "ZADOBUSTAVANAZIVOBUSTAVA");
                this.Columns.Add(this.columnZADOBUSTAVANAZIVOBUSTAVA);
                this.columnZADOBUSTAVAVRSTAOBUSTAVE = new DataColumn("ZADOBUSTAVAVRSTAOBUSTAVE", typeof(short), "", MappingType.Element);
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.AllowDBNull = true;
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.Caption = "Vrsta obustave";
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("SuperType", "VRSTAOBUSTAVE");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("SubtypeGroup", "ZADOBUSTAVA");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("Description", "Vrsta");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("Length", "2");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOBUSTAVAVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "ZADOBUSTAVAVRSTAOBUSTAVE");
                this.Columns.Add(this.columnZADOBUSTAVAVRSTAOBUSTAVE);
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE = new DataColumn("ZADOBUSTAVANAZIVVRSTAOBUSTAVE", typeof(string), "", MappingType.Element);
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.AllowDBNull = true;
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.Caption = "Opis vrste obustave";
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.MaxLength = 50;
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("SuperType", "NAZIVVRSTAOBUSTAVE");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("SubtypeGroup", "ZADOBUSTAVA");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Description", "Naziv vrste obustave");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Length", "50");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "ZADOBUSTAVANAZIVVRSTAOBUSTAVE");
                this.Columns.Add(this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE);
                this.columnZADIZNOSOBUSTAVE = new DataColumn("ZADIZNOSOBUSTAVE", typeof(decimal), "", MappingType.Element);
                this.columnZADIZNOSOBUSTAVE.AllowDBNull = false;
                this.columnZADIZNOSOBUSTAVE.Caption = "ZADIZNOSOBUSTAVE";
                this.columnZADIZNOSOBUSTAVE.DefaultValue = 0;
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("Description", "Iznos obustave");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("Length", "12");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("Decimals", "2");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "ZADIZNOSOBUSTAVE");
                this.Columns.Add(this.columnZADIZNOSOBUSTAVE);
                this.columnZADPOSTOTAKOBUSTAVE = new DataColumn("ZADPOSTOTAKOBUSTAVE", typeof(decimal), "", MappingType.Element);
                this.columnZADPOSTOTAKOBUSTAVE.AllowDBNull = false;
                this.columnZADPOSTOTAKOBUSTAVE.Caption = "ZADPOSTOTAKOBUSTAVE";
                this.columnZADPOSTOTAKOBUSTAVE.DefaultValue = 0;
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Description", "Postotak obustave");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Length", "5");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Decimals", "2");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "ZADPOSTOTAKOBUSTAVE");
                this.Columns.Add(this.columnZADPOSTOTAKOBUSTAVE);
                this.columnZADPOSTOTNAODBRUTA = new DataColumn("ZADPOSTOTNAODBRUTA", typeof(bool), "", MappingType.Element);
                this.columnZADPOSTOTNAODBRUTA.AllowDBNull = false;
                this.columnZADPOSTOTNAODBRUTA.Caption = "ZADPOSTOTNAODBRUTA";
                this.columnZADPOSTOTNAODBRUTA.DefaultValue = false;
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("Description", "Postotna obs. na bruto iznos");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("Length", "1");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("Decimals", "0");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADPOSTOTNAODBRUTA.ExtendedProperties.Add("Deklarit.InternalName", "ZADPOSTOTNAODBRUTA");
                this.Columns.Add(this.columnZADPOSTOTNAODBRUTA);
                this.columnZADISPLACENOKASA = new DataColumn("ZADISPLACENOKASA", typeof(decimal), "", MappingType.Element);
                this.columnZADISPLACENOKASA.AllowDBNull = false;
                this.columnZADISPLACENOKASA.Caption = "ZADISPLACENOKASA";
                this.columnZADISPLACENOKASA.DefaultValue = 0;
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("Description", "Isplaćeni iz kase");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("Length", "12");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("Decimals", "2");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADISPLACENOKASA.ExtendedProperties.Add("Deklarit.InternalName", "ZADISPLACENOKASA");
                this.Columns.Add(this.columnZADISPLACENOKASA);
                this.columnZADSALDOKASA = new DataColumn("ZADSALDOKASA", typeof(decimal), "", MappingType.Element);
                this.columnZADSALDOKASA.AllowDBNull = false;
                this.columnZADSALDOKASA.Caption = "ZADSALDOKASA";
                this.columnZADSALDOKASA.DefaultValue = 0;
                this.columnZADSALDOKASA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADSALDOKASA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADSALDOKASA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADSALDOKASA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADSALDOKASA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADSALDOKASA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADSALDOKASA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADSALDOKASA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADSALDOKASA.ExtendedProperties.Add("Description", "Saldo kase iz drugog programa");
                this.columnZADSALDOKASA.ExtendedProperties.Add("Length", "12");
                this.columnZADSALDOKASA.ExtendedProperties.Add("Decimals", "2");
                this.columnZADSALDOKASA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZADSALDOKASA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZADSALDOKASA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADSALDOKASA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADSALDOKASA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADSALDOKASA.ExtendedProperties.Add("Deklarit.InternalName", "ZADSALDOKASA");
                this.Columns.Add(this.columnZADSALDOKASA);
                this.columnOTPLACENIIZNOS = new DataColumn("OTPLACENIIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnOTPLACENIIZNOS.AllowDBNull = true;
                this.columnOTPLACENIIZNOS.Caption = "OTPLACENIIZNOS";
                this.columnOTPLACENIIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("Description", "Ukupno otplaćeno (iznos)");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOTPLACENIIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "OTPLACENIIZNOS");
                this.Columns.Add(this.columnOTPLACENIIZNOS);
                this.columnOTPLACENIBROJRATA = new DataColumn("OTPLACENIBROJRATA", typeof(decimal), "", MappingType.Element);
                this.columnOTPLACENIBROJRATA.AllowDBNull = true;
                this.columnOTPLACENIBROJRATA.Caption = "OTPLACENIBROJRATA";
                this.columnOTPLACENIBROJRATA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("IsKey", "false");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("Description", "Ukupno otplaćeno (rata)");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("Length", "12");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("Decimals", "2");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOTPLACENIBROJRATA.ExtendedProperties.Add("Deklarit.InternalName", "OTPLACENIBROJRATA");
                this.Columns.Add(this.columnOTPLACENIBROJRATA);
                this.columnZADOBUSTAVAZRNOBUSTAVA = new DataColumn("ZADOBUSTAVAZRNOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnZADOBUSTAVAZRNOBUSTAVA.AllowDBNull = true;
                this.columnZADOBUSTAVAZRNOBUSTAVA.Caption = "Broj žiro računa obustave";
                this.columnZADOBUSTAVAZRNOBUSTAVA.MaxLength = 10;
                this.columnZADOBUSTAVAZRNOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("SuperType", "ZRNOBUSTAVA");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("SubtypeGroup", "ZADOBUSTAVA");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("Description", "Broj žiro računa obustave");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("Length", "10");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOBUSTAVAZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "ZADOBUSTAVAZRNOBUSTAVA");
                this.Columns.Add(this.columnZADOBUSTAVAZRNOBUSTAVA);
                this.columnZADOBUSTAVAVBDIOBUSTAVA = new DataColumn("ZADOBUSTAVAVBDIOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnZADOBUSTAVAVBDIOBUSTAVA.AllowDBNull = true;
                this.columnZADOBUSTAVAVBDIOBUSTAVA.Caption = "VBDI žiro računa obustave";
                this.columnZADOBUSTAVAVBDIOBUSTAVA.MaxLength = 7;
                this.columnZADOBUSTAVAVBDIOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("SuperType", "VBDIOBUSTAVA");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("SubtypeGroup", "ZADOBUSTAVA");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("Description", "VBDI žiro računa obustave");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("Length", "7");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOBUSTAVAVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "ZADOBUSTAVAVBDIOBUSTAVA");
                this.Columns.Add(this.columnZADOBUSTAVAVBDIOBUSTAVA);
                this.PrimaryKey = new DataColumn[] { this.columnIDRADNIK, this.columnZADOBUSTAVAIDOBUSTAVA };
                this.ExtendedProperties.Add("ParentLvl", "RADNIK");
                this.ExtendedProperties.Add("LevelName", "ZaduzeneObustave");
                this.ExtendedProperties.Add("Description", "Obustave");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnZADOBUSTAVAIDOBUSTAVA = this.Columns["ZADOBUSTAVAIDOBUSTAVA"];
                this.columnOBUSTAVAAKTIVNA = this.Columns["OBUSTAVAAKTIVNA"];
                this.columnZADOBUSTAVANAZIVOBUSTAVA = this.Columns["ZADOBUSTAVANAZIVOBUSTAVA"];
                this.columnZADOBUSTAVAVRSTAOBUSTAVE = this.Columns["ZADOBUSTAVAVRSTAOBUSTAVE"];
                this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE = this.Columns["ZADOBUSTAVANAZIVVRSTAOBUSTAVE"];
                this.columnZADIZNOSOBUSTAVE = this.Columns["ZADIZNOSOBUSTAVE"];
                this.columnZADPOSTOTAKOBUSTAVE = this.Columns["ZADPOSTOTAKOBUSTAVE"];
                this.columnZADPOSTOTNAODBRUTA = this.Columns["ZADPOSTOTNAODBRUTA"];
                this.columnZADISPLACENOKASA = this.Columns["ZADISPLACENOKASA"];
                this.columnZADSALDOKASA = this.Columns["ZADSALDOKASA"];
                this.columnOTPLACENIIZNOS = this.Columns["OTPLACENIIZNOS"];
                this.columnOTPLACENIBROJRATA = this.Columns["OTPLACENIBROJRATA"];
                this.columnZADOBUSTAVAZRNOBUSTAVA = this.Columns["ZADOBUSTAVAZRNOBUSTAVA"];
                this.columnZADOBUSTAVAVBDIOBUSTAVA = this.Columns["ZADOBUSTAVAVBDIOBUSTAVA"];
            }

            public RADNIKDataSet.RADNIKObustavaRow NewRADNIKObustavaRow()
            {
                return (RADNIKDataSet.RADNIKObustavaRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RADNIKDataSet.RADNIKObustavaRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RADNIKObustavaRowChanged != null)
                {
                    RADNIKDataSet.RADNIKObustavaRowChangeEventHandler rADNIKObustavaRowChangedEvent = this.RADNIKObustavaRowChanged;
                    if (rADNIKObustavaRowChangedEvent != null)
                    {
                        rADNIKObustavaRowChangedEvent(this, new RADNIKDataSet.RADNIKObustavaRowChangeEvent((RADNIKDataSet.RADNIKObustavaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RADNIKObustavaRowChanging != null)
                {
                    RADNIKDataSet.RADNIKObustavaRowChangeEventHandler rADNIKObustavaRowChangingEvent = this.RADNIKObustavaRowChanging;
                    if (rADNIKObustavaRowChangingEvent != null)
                    {
                        rADNIKObustavaRowChangingEvent(this, new RADNIKDataSet.RADNIKObustavaRowChangeEvent((RADNIKDataSet.RADNIKObustavaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("RADNIK_RADNIKObustava", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.RADNIKObustavaRowDeleted != null)
                {
                    RADNIKDataSet.RADNIKObustavaRowChangeEventHandler rADNIKObustavaRowDeletedEvent = this.RADNIKObustavaRowDeleted;
                    if (rADNIKObustavaRowDeletedEvent != null)
                    {
                        rADNIKObustavaRowDeletedEvent(this, new RADNIKDataSet.RADNIKObustavaRowChangeEvent((RADNIKDataSet.RADNIKObustavaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RADNIKObustavaRowDeleting != null)
                {
                    RADNIKDataSet.RADNIKObustavaRowChangeEventHandler rADNIKObustavaRowDeletingEvent = this.RADNIKObustavaRowDeleting;
                    if (rADNIKObustavaRowDeletingEvent != null)
                    {
                        rADNIKObustavaRowDeletingEvent(this, new RADNIKDataSet.RADNIKObustavaRowChangeEvent((RADNIKDataSet.RADNIKObustavaRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRADNIKObustavaRow(RADNIKDataSet.RADNIKObustavaRow row)
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

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public RADNIKDataSet.RADNIKObustavaRow this[int index]
            {
                get
                {
                    return (RADNIKDataSet.RADNIKObustavaRow) this.Rows[index];
                }
            }

            public DataColumn OBUSTAVAAKTIVNAColumn
            {
                get
                {
                    return this.columnOBUSTAVAAKTIVNA;
                }
            }

            public DataColumn OTPLACENIBROJRATAColumn
            {
                get
                {
                    return this.columnOTPLACENIBROJRATA;
                }
            }

            public DataColumn OTPLACENIIZNOSColumn
            {
                get
                {
                    return this.columnOTPLACENIIZNOS;
                }
            }

            public DataColumn ZADISPLACENOKASAColumn
            {
                get
                {
                    return this.columnZADISPLACENOKASA;
                }
            }

            public DataColumn ZADIZNOSOBUSTAVEColumn
            {
                get
                {
                    return this.columnZADIZNOSOBUSTAVE;
                }
            }

            public DataColumn ZADOBUSTAVAIDOBUSTAVAColumn
            {
                get
                {
                    return this.columnZADOBUSTAVAIDOBUSTAVA;
                }
            }

            public DataColumn ZADOBUSTAVANAZIVOBUSTAVAColumn
            {
                get
                {
                    return this.columnZADOBUSTAVANAZIVOBUSTAVA;
                }
            }

            public DataColumn ZADOBUSTAVANAZIVVRSTAOBUSTAVEColumn
            {
                get
                {
                    return this.columnZADOBUSTAVANAZIVVRSTAOBUSTAVE;
                }
            }

            public DataColumn ZADOBUSTAVAVBDIOBUSTAVAColumn
            {
                get
                {
                    return this.columnZADOBUSTAVAVBDIOBUSTAVA;
                }
            }

            public DataColumn ZADOBUSTAVAVRSTAOBUSTAVEColumn
            {
                get
                {
                    return this.columnZADOBUSTAVAVRSTAOBUSTAVE;
                }
            }

            public DataColumn ZADOBUSTAVAZRNOBUSTAVAColumn
            {
                get
                {
                    return this.columnZADOBUSTAVAZRNOBUSTAVA;
                }
            }

            public DataColumn ZADPOSTOTAKOBUSTAVEColumn
            {
                get
                {
                    return this.columnZADPOSTOTAKOBUSTAVE;
                }
            }

            public DataColumn ZADPOSTOTNAODBRUTAColumn
            {
                get
                {
                    return this.columnZADPOSTOTNAODBRUTA;
                }
            }

            public DataColumn ZADSALDOKASAColumn
            {
                get
                {
                    return this.columnZADSALDOKASA;
                }
            }
        }

        public class RADNIKObustavaRow : DataRow
        {
            private RADNIKDataSet.RADNIKObustavaDataTable tableRADNIKObustava;

            internal RADNIKObustavaRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRADNIKObustava = (RADNIKDataSet.RADNIKObustavaDataTable) this.Table;
            }

            public RADNIKDataSet.RADNIKRow GetRADNIKRow()
            {
                return (RADNIKDataSet.RADNIKRow) this.GetParentRow("RADNIK_RADNIKObustava");
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableRADNIKObustava.IDRADNIKColumn);
            }

            public bool IsOBUSTAVAAKTIVNANull()
            {
                return this.IsNull(this.tableRADNIKObustava.OBUSTAVAAKTIVNAColumn);
            }

            public bool IsOTPLACENIBROJRATANull()
            {
                return this.IsNull(this.tableRADNIKObustava.OTPLACENIBROJRATAColumn);
            }

            public bool IsOTPLACENIIZNOSNull()
            {
                return this.IsNull(this.tableRADNIKObustava.OTPLACENIIZNOSColumn);
            }

            public bool IsZADISPLACENOKASANull()
            {
                return this.IsNull(this.tableRADNIKObustava.ZADISPLACENOKASAColumn);
            }

            public bool IsZADIZNOSOBUSTAVENull()
            {
                return this.IsNull(this.tableRADNIKObustava.ZADIZNOSOBUSTAVEColumn);
            }

            public bool IsZADOBUSTAVAIDOBUSTAVANull()
            {
                return this.IsNull(this.tableRADNIKObustava.ZADOBUSTAVAIDOBUSTAVAColumn);
            }

            public bool IsZADOBUSTAVANAZIVOBUSTAVANull()
            {
                return this.IsNull(this.tableRADNIKObustava.ZADOBUSTAVANAZIVOBUSTAVAColumn);
            }

            public bool IsZADOBUSTAVANAZIVVRSTAOBUSTAVENull()
            {
                return this.IsNull(this.tableRADNIKObustava.ZADOBUSTAVANAZIVVRSTAOBUSTAVEColumn);
            }

            public bool IsZADOBUSTAVAVBDIOBUSTAVANull()
            {
                return this.IsNull(this.tableRADNIKObustava.ZADOBUSTAVAVBDIOBUSTAVAColumn);
            }

            public bool IsZADOBUSTAVAVRSTAOBUSTAVENull()
            {
                return this.IsNull(this.tableRADNIKObustava.ZADOBUSTAVAVRSTAOBUSTAVEColumn);
            }

            public bool IsZADOBUSTAVAZRNOBUSTAVANull()
            {
                return this.IsNull(this.tableRADNIKObustava.ZADOBUSTAVAZRNOBUSTAVAColumn);
            }

            public bool IsZADPOSTOTAKOBUSTAVENull()
            {
                return this.IsNull(this.tableRADNIKObustava.ZADPOSTOTAKOBUSTAVEColumn);
            }

            public bool IsZADPOSTOTNAODBRUTANull()
            {
                return this.IsNull(this.tableRADNIKObustava.ZADPOSTOTNAODBRUTAColumn);
            }

            public bool IsZADSALDOKASANull()
            {
                return this.IsNull(this.tableRADNIKObustava.ZADSALDOKASAColumn);
            }

            public void SetOBUSTAVAAKTIVNANull()
            {
                this[this.tableRADNIKObustava.OBUSTAVAAKTIVNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOTPLACENIBROJRATANull()
            {
                this[this.tableRADNIKObustava.OTPLACENIBROJRATAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOTPLACENIIZNOSNull()
            {
                this[this.tableRADNIKObustava.OTPLACENIIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADISPLACENOKASANull()
            {
                this[this.tableRADNIKObustava.ZADISPLACENOKASAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADIZNOSOBUSTAVENull()
            {
                this[this.tableRADNIKObustava.ZADIZNOSOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOBUSTAVANAZIVOBUSTAVANull()
            {
                this[this.tableRADNIKObustava.ZADOBUSTAVANAZIVOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOBUSTAVANAZIVVRSTAOBUSTAVENull()
            {
                this[this.tableRADNIKObustava.ZADOBUSTAVANAZIVVRSTAOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOBUSTAVAVBDIOBUSTAVANull()
            {
                this[this.tableRADNIKObustava.ZADOBUSTAVAVBDIOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOBUSTAVAVRSTAOBUSTAVENull()
            {
                this[this.tableRADNIKObustava.ZADOBUSTAVAVRSTAOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOBUSTAVAZRNOBUSTAVANull()
            {
                this[this.tableRADNIKObustava.ZADOBUSTAVAZRNOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADPOSTOTAKOBUSTAVENull()
            {
                this[this.tableRADNIKObustava.ZADPOSTOTAKOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADPOSTOTNAODBRUTANull()
            {
                this[this.tableRADNIKObustava.ZADPOSTOTNAODBRUTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADSALDOKASANull()
            {
                this[this.tableRADNIKObustava.ZADSALDOKASAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKObustava.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableRADNIKObustava.IDRADNIKColumn] = value;
                }
            }

            public bool OBUSTAVAAKTIVNA
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableRADNIKObustava.OBUSTAVAAKTIVNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableRADNIKObustava.OBUSTAVAAKTIVNAColumn] = value;
                }
            }

            public decimal OTPLACENIBROJRATA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKObustava.OTPLACENIBROJRATAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKObustava.OTPLACENIBROJRATAColumn] = value;
                }
            }

            public decimal OTPLACENIIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKObustava.OTPLACENIIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKObustava.OTPLACENIIZNOSColumn] = value;
                }
            }

            public decimal ZADISPLACENOKASA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKObustava.ZADISPLACENOKASAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKObustava.ZADISPLACENOKASAColumn] = value;
                }
            }

            public decimal ZADIZNOSOBUSTAVE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKObustava.ZADIZNOSOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKObustava.ZADIZNOSOBUSTAVEColumn] = value;
                }
            }

            public int ZADOBUSTAVAIDOBUSTAVA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKObustava.ZADOBUSTAVAIDOBUSTAVAColumn]);
                }
                set
                {
                    this[this.tableRADNIKObustava.ZADOBUSTAVAIDOBUSTAVAColumn] = value;
                }
            }

            public string ZADOBUSTAVANAZIVOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKObustava.ZADOBUSTAVANAZIVOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKObustava.ZADOBUSTAVANAZIVOBUSTAVAColumn] = value;
                }
            }

            public string ZADOBUSTAVANAZIVVRSTAOBUSTAVE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKObustava.ZADOBUSTAVANAZIVVRSTAOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKObustava.ZADOBUSTAVANAZIVVRSTAOBUSTAVEColumn] = value;
                }
            }

            public string ZADOBUSTAVAVBDIOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKObustava.ZADOBUSTAVAVBDIOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKObustava.ZADOBUSTAVAVBDIOBUSTAVAColumn] = value;
                }
            }

            public short ZADOBUSTAVAVRSTAOBUSTAVE
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableRADNIKObustava.ZADOBUSTAVAVRSTAOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKObustava.ZADOBUSTAVAVRSTAOBUSTAVEColumn] = value;
                }
            }

            public string ZADOBUSTAVAZRNOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKObustava.ZADOBUSTAVAZRNOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKObustava.ZADOBUSTAVAZRNOBUSTAVAColumn] = value;
                }
            }

            public decimal ZADPOSTOTAKOBUSTAVE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKObustava.ZADPOSTOTAKOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKObustava.ZADPOSTOTAKOBUSTAVEColumn] = value;
                }
            }

            public bool ZADPOSTOTNAODBRUTA
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableRADNIKObustava.ZADPOSTOTNAODBRUTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return flag;
                }
                set
                {
                    this[this.tableRADNIKObustava.ZADPOSTOTNAODBRUTAColumn] = value;
                }
            }

            public decimal ZADSALDOKASA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKObustava.ZADSALDOKASAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKObustava.ZADSALDOKASAColumn] = value;
                }
            }
        }

        public class RADNIKObustavaRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RADNIKDataSet.RADNIKObustavaRow eventRow;

            public RADNIKObustavaRowChangeEvent(RADNIKDataSet.RADNIKObustavaRow row, DataRowAction action)
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

            public RADNIKDataSet.RADNIKObustavaRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RADNIKObustavaRowChangeEventHandler(object sender, RADNIKDataSet.RADNIKObustavaRowChangeEvent e);

        [Serializable]
        public class RADNIKOdbitakDataTable : DataTable, IEnumerable
        {
            private DataColumn columnFAKTOROSOBNOGODBITKA;
            private DataColumn columnIDRADNIK;
            private DataColumn columnNAZIVOSOBNIODBITAK;
            private DataColumn columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK;

            public event RADNIKDataSet.RADNIKOdbitakRowChangeEventHandler RADNIKOdbitakRowChanged;

            public event RADNIKDataSet.RADNIKOdbitakRowChangeEventHandler RADNIKOdbitakRowChanging;

            public event RADNIKDataSet.RADNIKOdbitakRowChangeEventHandler RADNIKOdbitakRowDeleted;

            public event RADNIKDataSet.RADNIKOdbitakRowChangeEventHandler RADNIKOdbitakRowDeleting;

            public RADNIKOdbitakDataTable()
            {
                this.TableName = "RADNIKOdbitak";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RADNIKOdbitakDataTable(DataTable table) : base(table.TableName)
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

            protected RADNIKOdbitakDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRADNIKOdbitakRow(RADNIKDataSet.RADNIKOdbitakRow row)
            {
                this.Rows.Add(row);
            }

            public RADNIKDataSet.RADNIKOdbitakRow AddRADNIKOdbitakRow(int iDRADNIK, int oSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK)
            {
                RADNIKDataSet.RADNIKOdbitakRow row = (RADNIKDataSet.RADNIKOdbitakRow) this.NewRow();
                row["IDRADNIK"] = iDRADNIK;
                row["OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK"] = oSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RADNIKDataSet.RADNIKOdbitakDataTable table = (RADNIKDataSet.RADNIKOdbitakDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RADNIKDataSet.RADNIKOdbitakRow FindByIDRADNIKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK(int iDRADNIK, int oSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK)
            {
                return (RADNIKDataSet.RADNIKOdbitakRow) this.Rows.Find(new object[] { iDRADNIK, oSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RADNIKDataSet.RADNIKOdbitakRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RADNIKDataSet set = new RADNIKDataSet();
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
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK = new DataColumn("OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK", typeof(int), "", MappingType.Element);
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.AllowDBNull = false;
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Caption = "Šifra osobnog odbitka";
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("SuperType", "IDOSOBNIODBITAK");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("SubtypeGroup", "OSOBNIODBITAKZADUZENJE");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("IsKey", "true");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("Description", "Šifra");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("Length", "5");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("Decimals", "0");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.InternalName", "OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK");
                this.Columns.Add(this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK);
                this.columnNAZIVOSOBNIODBITAK = new DataColumn("NAZIVOSOBNIODBITAK", typeof(string), "", MappingType.Element);
                this.columnNAZIVOSOBNIODBITAK.AllowDBNull = true;
                this.columnNAZIVOSOBNIODBITAK.Caption = "Naziv osobnog odbitka";
                this.columnNAZIVOSOBNIODBITAK.MaxLength = 100;
                this.columnNAZIVOSOBNIODBITAK.DefaultValue = "";
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Description", "Naziv OD");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("TreatEmptyAsNull", "true");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOSOBNIODBITAK.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOSOBNIODBITAK");
                this.Columns.Add(this.columnNAZIVOSOBNIODBITAK);
                this.columnFAKTOROSOBNOGODBITKA = new DataColumn("FAKTOROSOBNOGODBITKA", typeof(decimal), "", MappingType.Element);
                this.columnFAKTOROSOBNOGODBITKA.AllowDBNull = true;
                this.columnFAKTOROSOBNOGODBITKA.Caption = "Faktor osobnog odbitka";
                this.columnFAKTOROSOBNOGODBITKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("IsKey", "false");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Description", "Faktor");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Length", "5");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Decimals", "2");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnFAKTOROSOBNOGODBITKA.ExtendedProperties.Add("Deklarit.InternalName", "FAKTOROSOBNOGODBITKA");
                this.Columns.Add(this.columnFAKTOROSOBNOGODBITKA);
                this.PrimaryKey = new DataColumn[] { this.columnIDRADNIK, this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK };
                this.ExtendedProperties.Add("ParentLvl", "RADNIK");
                this.ExtendedProperties.Add("LevelName", "OsobniOdbitak");
                this.ExtendedProperties.Add("Description", "Osobni odbici radnika");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK = this.Columns["OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK"];
                this.columnNAZIVOSOBNIODBITAK = this.Columns["NAZIVOSOBNIODBITAK"];
                this.columnFAKTOROSOBNOGODBITKA = this.Columns["FAKTOROSOBNOGODBITKA"];
            }

            public RADNIKDataSet.RADNIKOdbitakRow NewRADNIKOdbitakRow()
            {
                return (RADNIKDataSet.RADNIKOdbitakRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RADNIKDataSet.RADNIKOdbitakRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RADNIKOdbitakRowChanged != null)
                {
                    RADNIKDataSet.RADNIKOdbitakRowChangeEventHandler rADNIKOdbitakRowChangedEvent = this.RADNIKOdbitakRowChanged;
                    if (rADNIKOdbitakRowChangedEvent != null)
                    {
                        rADNIKOdbitakRowChangedEvent(this, new RADNIKDataSet.RADNIKOdbitakRowChangeEvent((RADNIKDataSet.RADNIKOdbitakRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RADNIKOdbitakRowChanging != null)
                {
                    RADNIKDataSet.RADNIKOdbitakRowChangeEventHandler rADNIKOdbitakRowChangingEvent = this.RADNIKOdbitakRowChanging;
                    if (rADNIKOdbitakRowChangingEvent != null)
                    {
                        rADNIKOdbitakRowChangingEvent(this, new RADNIKDataSet.RADNIKOdbitakRowChangeEvent((RADNIKDataSet.RADNIKOdbitakRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("RADNIK_RADNIKOdbitak", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.RADNIKOdbitakRowDeleted != null)
                {
                    RADNIKDataSet.RADNIKOdbitakRowChangeEventHandler rADNIKOdbitakRowDeletedEvent = this.RADNIKOdbitakRowDeleted;
                    if (rADNIKOdbitakRowDeletedEvent != null)
                    {
                        rADNIKOdbitakRowDeletedEvent(this, new RADNIKDataSet.RADNIKOdbitakRowChangeEvent((RADNIKDataSet.RADNIKOdbitakRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RADNIKOdbitakRowDeleting != null)
                {
                    RADNIKDataSet.RADNIKOdbitakRowChangeEventHandler rADNIKOdbitakRowDeletingEvent = this.RADNIKOdbitakRowDeleting;
                    if (rADNIKOdbitakRowDeletingEvent != null)
                    {
                        rADNIKOdbitakRowDeletingEvent(this, new RADNIKDataSet.RADNIKOdbitakRowChangeEvent((RADNIKDataSet.RADNIKOdbitakRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRADNIKOdbitakRow(RADNIKDataSet.RADNIKOdbitakRow row)
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

            public DataColumn FAKTOROSOBNOGODBITKAColumn
            {
                get
                {
                    return this.columnFAKTOROSOBNOGODBITKA;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public RADNIKDataSet.RADNIKOdbitakRow this[int index]
            {
                get
                {
                    return (RADNIKDataSet.RADNIKOdbitakRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVOSOBNIODBITAKColumn
            {
                get
                {
                    return this.columnNAZIVOSOBNIODBITAK;
                }
            }

            public DataColumn OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAKColumn
            {
                get
                {
                    return this.columnOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK;
                }
            }
        }

        public class RADNIKOdbitakRow : DataRow
        {
            private RADNIKDataSet.RADNIKOdbitakDataTable tableRADNIKOdbitak;

            internal RADNIKOdbitakRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRADNIKOdbitak = (RADNIKDataSet.RADNIKOdbitakDataTable) this.Table;
            }

            public RADNIKDataSet.RADNIKRow GetRADNIKRow()
            {
                return (RADNIKDataSet.RADNIKRow) this.GetParentRow("RADNIK_RADNIKOdbitak");
            }

            public bool IsFAKTOROSOBNOGODBITKANull()
            {
                return this.IsNull(this.tableRADNIKOdbitak.FAKTOROSOBNOGODBITKAColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableRADNIKOdbitak.IDRADNIKColumn);
            }

            public bool IsNAZIVOSOBNIODBITAKNull()
            {
                return this.IsNull(this.tableRADNIKOdbitak.NAZIVOSOBNIODBITAKColumn);
            }

            public bool IsOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAKNull()
            {
                return this.IsNull(this.tableRADNIKOdbitak.OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAKColumn);
            }

            public void SetFAKTOROSOBNOGODBITKANull()
            {
                this[this.tableRADNIKOdbitak.FAKTOROSOBNOGODBITKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOSOBNIODBITAKNull()
            {
                this[this.tableRADNIKOdbitak.NAZIVOSOBNIODBITAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal FAKTOROSOBNOGODBITKA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKOdbitak.FAKTOROSOBNOGODBITKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKOdbitak.FAKTOROSOBNOGODBITKAColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKOdbitak.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableRADNIKOdbitak.IDRADNIKColumn] = value;
                }
            }

            public string NAZIVOSOBNIODBITAK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOdbitak.NAZIVOSOBNIODBITAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOdbitak.NAZIVOSOBNIODBITAKColumn] = value;
                }
            }

            public int OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKOdbitak.OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAKColumn]);
                }
                set
                {
                    this[this.tableRADNIKOdbitak.OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAKColumn] = value;
                }
            }
        }

        public class RADNIKOdbitakRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RADNIKDataSet.RADNIKOdbitakRow eventRow;

            public RADNIKOdbitakRowChangeEvent(RADNIKDataSet.RADNIKOdbitakRow row, DataRowAction action)
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

            public RADNIKDataSet.RADNIKOdbitakRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RADNIKOdbitakRowChangeEventHandler(object sender, RADNIKDataSet.RADNIKOdbitakRowChangeEvent e);

        [Serializable]
        public class RADNIKOlaksicaDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRADNIK;
            private DataColumn columnZADIZNOSOLAKSICE;
            private DataColumn columnZADMOOLAKSICE;
            private DataColumn columnZADMZOLAKSICE;
            private DataColumn columnZADOLAKSICEIDGRUPEOLAKSICA;
            private DataColumn columnZADOLAKSICEIDOLAKSICE;
            private DataColumn columnZADOLAKSICEIDTIPOLAKSICE;
            private DataColumn columnZADOLAKSICEMAXIMALNIIZNOSGRUPE;
            private DataColumn columnZADOLAKSICENAZIVGRUPEOLAKSICA;
            private DataColumn columnZADOLAKSICENAZIVOLAKSICE;
            private DataColumn columnZADOLAKSICENAZIVTIPOLAKSICE;
            private DataColumn columnZADOLAKSICEPRIMATELJOLAKSICA1;
            private DataColumn columnZADOLAKSICEPRIMATELJOLAKSICA2;
            private DataColumn columnZADOLAKSICEPRIMATELJOLAKSICA3;
            private DataColumn columnZADOLAKSICEVBDIOLAKSICA;
            private DataColumn columnZADOLAKSICEZRNOLAKSICA;
            private DataColumn columnZADOPISPLACANJAOLAKSICE;
            private DataColumn columnZADPOJEDINACNIPOZIV;
            private DataColumn columnZADPOOLAKSICE;
            private DataColumn columnZADPZOLAKSICE;
            private DataColumn columnZADSIFRAOPISAPLACANJAOLAKSICE;

            public event RADNIKDataSet.RADNIKOlaksicaRowChangeEventHandler RADNIKOlaksicaRowChanged;

            public event RADNIKDataSet.RADNIKOlaksicaRowChangeEventHandler RADNIKOlaksicaRowChanging;

            public event RADNIKDataSet.RADNIKOlaksicaRowChangeEventHandler RADNIKOlaksicaRowDeleted;

            public event RADNIKDataSet.RADNIKOlaksicaRowChangeEventHandler RADNIKOlaksicaRowDeleting;

            public RADNIKOlaksicaDataTable()
            {
                this.TableName = "RADNIKOlaksica";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RADNIKOlaksicaDataTable(DataTable table) : base(table.TableName)
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

            protected RADNIKOlaksicaDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRADNIKOlaksicaRow(RADNIKDataSet.RADNIKOlaksicaRow row)
            {
                this.Rows.Add(row);
            }

            public RADNIKDataSet.RADNIKOlaksicaRow AddRADNIKOlaksicaRow(int iDRADNIK, int zADOLAKSICEIDOLAKSICE, string zADMZOLAKSICE, string zADPZOLAKSICE, string zADMOOLAKSICE, string zADPOOLAKSICE, string zADSIFRAOPISAPLACANJAOLAKSICE, string zADOPISPLACANJAOLAKSICE, decimal zADIZNOSOLAKSICE, string zADPOJEDINACNIPOZIV)
            {
                RADNIKDataSet.RADNIKOlaksicaRow row = (RADNIKDataSet.RADNIKOlaksicaRow) this.NewRow();
                row["IDRADNIK"] = iDRADNIK;
                row["ZADOLAKSICEIDOLAKSICE"] = zADOLAKSICEIDOLAKSICE;
                row["ZADMZOLAKSICE"] = zADMZOLAKSICE;
                row["ZADPZOLAKSICE"] = zADPZOLAKSICE;
                row["ZADMOOLAKSICE"] = zADMOOLAKSICE;
                row["ZADPOOLAKSICE"] = zADPOOLAKSICE;
                row["ZADSIFRAOPISAPLACANJAOLAKSICE"] = zADSIFRAOPISAPLACANJAOLAKSICE;
                row["ZADOPISPLACANJAOLAKSICE"] = zADOPISPLACANJAOLAKSICE;
                row["ZADIZNOSOLAKSICE"] = zADIZNOSOLAKSICE;
                row["ZADPOJEDINACNIPOZIV"] = zADPOJEDINACNIPOZIV;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RADNIKDataSet.RADNIKOlaksicaDataTable table = (RADNIKDataSet.RADNIKOlaksicaDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RADNIKDataSet.RADNIKOlaksicaRow FindByIDRADNIKZADOLAKSICEIDOLAKSICE(int iDRADNIK, int zADOLAKSICEIDOLAKSICE)
            {
                return (RADNIKDataSet.RADNIKOlaksicaRow) this.Rows.Find(new object[] { iDRADNIK, zADOLAKSICEIDOLAKSICE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RADNIKDataSet.RADNIKOlaksicaRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RADNIKDataSet set = new RADNIKDataSet();
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
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnZADOLAKSICEIDOLAKSICE = new DataColumn("ZADOLAKSICEIDOLAKSICE", typeof(int), "", MappingType.Element);
                this.columnZADOLAKSICEIDOLAKSICE.AllowDBNull = false;
                this.columnZADOLAKSICEIDOLAKSICE.Caption = "Šifra olakšice";
                this.columnZADOLAKSICEIDOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("SuperType", "IDOLAKSICE");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("SubtypeGroup", "ZADOLAKSICE");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("IsKey", "true");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("Description", "Šifra");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("Length", "8");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOLAKSICEIDOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "ZADOLAKSICEIDOLAKSICE");
                this.Columns.Add(this.columnZADOLAKSICEIDOLAKSICE);
                this.columnZADOLAKSICEIDGRUPEOLAKSICA = new DataColumn("ZADOLAKSICEIDGRUPEOLAKSICA", typeof(int), "", MappingType.Element);
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.AllowDBNull = true;
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.Caption = "Šifra grupe olakšica";
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("SuperType", "IDGRUPEOLAKSICA");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("SubtypeGroup", "ZADOLAKSICE");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("Description", "Grupa olakšice");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("Length", "5");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOLAKSICEIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "ZADOLAKSICEIDGRUPEOLAKSICA");
                this.Columns.Add(this.columnZADOLAKSICEIDGRUPEOLAKSICA);
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE = new DataColumn("ZADOLAKSICEMAXIMALNIIZNOSGRUPE", typeof(decimal), "", MappingType.Element);
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.AllowDBNull = true;
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.Caption = "Maks. iznos olakšica u grupi";
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("SuperType", "MAXIMALNIIZNOSGRUPE");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("SubtypeGroup", "ZADOLAKSICE");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Description", "Maks. iznos u grupi");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Length", "12");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Decimals", "2");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.InternalName", "ZADOLAKSICEMAXIMALNIIZNOSGRUPE");
                this.Columns.Add(this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE);
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA = new DataColumn("ZADOLAKSICENAZIVGRUPEOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.AllowDBNull = true;
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.Caption = "Naziv grupe olakšice";
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.MaxLength = 100;
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("SuperType", "NAZIVGRUPEOLAKSICA");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("SubtypeGroup", "ZADOLAKSICE");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Description", "Naziv grp.");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Length", "100");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "ZADOLAKSICENAZIVGRUPEOLAKSICA");
                this.Columns.Add(this.columnZADOLAKSICENAZIVGRUPEOLAKSICA);
                this.columnZADOLAKSICENAZIVOLAKSICE = new DataColumn("ZADOLAKSICENAZIVOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnZADOLAKSICENAZIVOLAKSICE.AllowDBNull = true;
                this.columnZADOLAKSICENAZIVOLAKSICE.Caption = "Naziv olakšice";
                this.columnZADOLAKSICENAZIVOLAKSICE.MaxLength = 100;
                this.columnZADOLAKSICENAZIVOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("SuperType", "NAZIVOLAKSICE");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("SubtypeGroup", "ZADOLAKSICE");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("Description", "Olakšica");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("Length", "100");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOLAKSICENAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "ZADOLAKSICENAZIVOLAKSICE");
                this.Columns.Add(this.columnZADOLAKSICENAZIVOLAKSICE);
                this.columnZADOLAKSICEIDTIPOLAKSICE = new DataColumn("ZADOLAKSICEIDTIPOLAKSICE", typeof(int), "", MappingType.Element);
                this.columnZADOLAKSICEIDTIPOLAKSICE.AllowDBNull = true;
                this.columnZADOLAKSICEIDTIPOLAKSICE.Caption = "Tip olakšice";
                this.columnZADOLAKSICEIDTIPOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("SuperType", "IDTIPOLAKSICE");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("SubtypeGroup", "ZADOLAKSICE");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("Description", "Tip");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("Length", "5");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOLAKSICEIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "ZADOLAKSICEIDTIPOLAKSICE");
                this.Columns.Add(this.columnZADOLAKSICEIDTIPOLAKSICE);
                this.columnZADOLAKSICENAZIVTIPOLAKSICE = new DataColumn("ZADOLAKSICENAZIVTIPOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.AllowDBNull = true;
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.Caption = "Naziv tipa olakšice";
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.MaxLength = 50;
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("SuperType", "NAZIVTIPOLAKSICE");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("SubtypeGroup", "ZADOLAKSICE");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("Description", "Naziv tip olakšice");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("Length", "50");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOLAKSICENAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "ZADOLAKSICENAZIVTIPOLAKSICE");
                this.Columns.Add(this.columnZADOLAKSICENAZIVTIPOLAKSICE);
                this.columnZADOLAKSICEVBDIOLAKSICA = new DataColumn("ZADOLAKSICEVBDIOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnZADOLAKSICEVBDIOLAKSICA.AllowDBNull = true;
                this.columnZADOLAKSICEVBDIOLAKSICA.Caption = "VBDI žiro računa olakšice";
                this.columnZADOLAKSICEVBDIOLAKSICA.MaxLength = 7;
                this.columnZADOLAKSICEVBDIOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("SuperType", "VBDIOLAKSICA");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("SubtypeGroup", "ZADOLAKSICE");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("Description", "VBDI žiro računa olakšice");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("Length", "7");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOLAKSICEVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "ZADOLAKSICEVBDIOLAKSICA");
                this.Columns.Add(this.columnZADOLAKSICEVBDIOLAKSICA);
                this.columnZADOLAKSICEZRNOLAKSICA = new DataColumn("ZADOLAKSICEZRNOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnZADOLAKSICEZRNOLAKSICA.AllowDBNull = true;
                this.columnZADOLAKSICEZRNOLAKSICA.Caption = "Broj žiro računa olakšice";
                this.columnZADOLAKSICEZRNOLAKSICA.MaxLength = 10;
                this.columnZADOLAKSICEZRNOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("SuperType", "ZRNOLAKSICA");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("SubtypeGroup", "ZADOLAKSICE");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("Description", "Broj žiro računa olakšice");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("Length", "10");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOLAKSICEZRNOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "ZADOLAKSICEZRNOLAKSICA");
                this.Columns.Add(this.columnZADOLAKSICEZRNOLAKSICA);
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1 = new DataColumn("ZADOLAKSICEPRIMATELJOLAKSICA1", typeof(string), "", MappingType.Element);
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.AllowDBNull = true;
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.Caption = "Primatelj olakšice (1)";
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.MaxLength = 20;
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("SuperType", "PRIMATELJOLAKSICA1");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("SubtypeGroup", "ZADOLAKSICE");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("Description", "Primatelj olakšice (1)");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("Length", "20");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.InternalName", "ZADOLAKSICEPRIMATELJOLAKSICA1");
                this.Columns.Add(this.columnZADOLAKSICEPRIMATELJOLAKSICA1);
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2 = new DataColumn("ZADOLAKSICEPRIMATELJOLAKSICA2", typeof(string), "", MappingType.Element);
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.AllowDBNull = true;
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.Caption = "Primatelj olakšice (2)";
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.MaxLength = 20;
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("SuperType", "PRIMATELJOLAKSICA2");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("SubtypeGroup", "ZADOLAKSICE");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("Description", "Primatelj olakšice (2)");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("Length", "20");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.InternalName", "ZADOLAKSICEPRIMATELJOLAKSICA2");
                this.Columns.Add(this.columnZADOLAKSICEPRIMATELJOLAKSICA2);
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3 = new DataColumn("ZADOLAKSICEPRIMATELJOLAKSICA3", typeof(string), "", MappingType.Element);
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.AllowDBNull = true;
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.Caption = "Primatelj olakšice (3)";
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.MaxLength = 20;
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("SuperType", "PRIMATELJOLAKSICA3");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("SubtypeGroup", "ZADOLAKSICE");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("Description", "Primatelj olakšice (3)");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("Length", "20");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.InternalName", "ZADOLAKSICEPRIMATELJOLAKSICA3");
                this.Columns.Add(this.columnZADOLAKSICEPRIMATELJOLAKSICA3);
                this.columnZADMZOLAKSICE = new DataColumn("ZADMZOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnZADMZOLAKSICE.AllowDBNull = true;
                this.columnZADMZOLAKSICE.Caption = "ZADMZOLAKSICE";
                this.columnZADMZOLAKSICE.MaxLength = 2;
                this.columnZADMZOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("Description", "Model zaduženja");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("Length", "2");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADMZOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "ZADMZOLAKSICE");
                this.Columns.Add(this.columnZADMZOLAKSICE);
                this.columnZADPZOLAKSICE = new DataColumn("ZADPZOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnZADPZOLAKSICE.AllowDBNull = true;
                this.columnZADPZOLAKSICE.Caption = "ZADPZOLAKSICE";
                this.columnZADPZOLAKSICE.MaxLength = 0x16;
                this.columnZADPZOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("Description", "Poziv na broj zaduženja");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("Length", "22");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADPZOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "ZADPZOLAKSICE");
                this.Columns.Add(this.columnZADPZOLAKSICE);
                this.columnZADMOOLAKSICE = new DataColumn("ZADMOOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnZADMOOLAKSICE.AllowDBNull = true;
                this.columnZADMOOLAKSICE.Caption = "ZADMOOLAKSICE";
                this.columnZADMOOLAKSICE.MaxLength = 2;
                this.columnZADMOOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("Description", "Model odobrenja");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("Length", "2");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADMOOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "ZADMOOLAKSICE");
                this.Columns.Add(this.columnZADMOOLAKSICE);
                this.columnZADPOOLAKSICE = new DataColumn("ZADPOOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnZADPOOLAKSICE.AllowDBNull = true;
                this.columnZADPOOLAKSICE.Caption = "ZADPOOLAKSICE";
                this.columnZADPOOLAKSICE.MaxLength = 0x16;
                this.columnZADPOOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("Description", "Poziv na broj odobrenja");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("Length", "22");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADPOOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "ZADPOOLAKSICE");
                this.Columns.Add(this.columnZADPOOLAKSICE);
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE = new DataColumn("ZADSIFRAOPISAPLACANJAOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.AllowDBNull = false;
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.Caption = "ZADSIFRAOPISAPLACANJAOLAKSICE";
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.MaxLength = 2;
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("Description", "Šifra opisa plaćanja");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("Length", "2");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "ZADSIFRAOPISAPLACANJAOLAKSICE");
                this.Columns.Add(this.columnZADSIFRAOPISAPLACANJAOLAKSICE);
                this.columnZADOPISPLACANJAOLAKSICE = new DataColumn("ZADOPISPLACANJAOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnZADOPISPLACANJAOLAKSICE.AllowDBNull = false;
                this.columnZADOPISPLACANJAOLAKSICE.Caption = "ZADOPISPLACANJAOLAKSICE";
                this.columnZADOPISPLACANJAOLAKSICE.MaxLength = 0x24;
                this.columnZADOPISPLACANJAOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("Description", "Opis plaćanja");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("Length", "36");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADOPISPLACANJAOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "ZADOPISPLACANJAOLAKSICE");
                this.Columns.Add(this.columnZADOPISPLACANJAOLAKSICE);
                this.columnZADIZNOSOLAKSICE = new DataColumn("ZADIZNOSOLAKSICE", typeof(decimal), "", MappingType.Element);
                this.columnZADIZNOSOLAKSICE.AllowDBNull = false;
                this.columnZADIZNOSOLAKSICE.Caption = "ZADIZNOSOLAKSICE";
                this.columnZADIZNOSOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("Description", "Iznos olakšice");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("Length", "12");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("Decimals", "2");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "ZADIZNOSOLAKSICE");
                this.Columns.Add(this.columnZADIZNOSOLAKSICE);
                this.columnZADPOJEDINACNIPOZIV = new DataColumn("ZADPOJEDINACNIPOZIV", typeof(string), "", MappingType.Element);
                this.columnZADPOJEDINACNIPOZIV.AllowDBNull = true;
                this.columnZADPOJEDINACNIPOZIV.Caption = "ZADPOJEDINACNIPOZIV";
                this.columnZADPOJEDINACNIPOZIV.MaxLength = 11;
                this.columnZADPOJEDINACNIPOZIV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("IsKey", "false");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Description", "Poziv na broj - disketa HZZO");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Length", "11");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Decimals", "0");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZADPOJEDINACNIPOZIV.ExtendedProperties.Add("Deklarit.InternalName", "ZADPOJEDINACNIPOZIV");
                this.Columns.Add(this.columnZADPOJEDINACNIPOZIV);
                this.PrimaryKey = new DataColumn[] { this.columnIDRADNIK, this.columnZADOLAKSICEIDOLAKSICE };
                this.ExtendedProperties.Add("ParentLvl", "RADNIK");
                this.ExtendedProperties.Add("LevelName", "RADNIKLevel4");
                this.ExtendedProperties.Add("Description", "Olakšice");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnZADOLAKSICEIDOLAKSICE = this.Columns["ZADOLAKSICEIDOLAKSICE"];
                this.columnZADOLAKSICEIDGRUPEOLAKSICA = this.Columns["ZADOLAKSICEIDGRUPEOLAKSICA"];
                this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE = this.Columns["ZADOLAKSICEMAXIMALNIIZNOSGRUPE"];
                this.columnZADOLAKSICENAZIVGRUPEOLAKSICA = this.Columns["ZADOLAKSICENAZIVGRUPEOLAKSICA"];
                this.columnZADOLAKSICENAZIVOLAKSICE = this.Columns["ZADOLAKSICENAZIVOLAKSICE"];
                this.columnZADOLAKSICEIDTIPOLAKSICE = this.Columns["ZADOLAKSICEIDTIPOLAKSICE"];
                this.columnZADOLAKSICENAZIVTIPOLAKSICE = this.Columns["ZADOLAKSICENAZIVTIPOLAKSICE"];
                this.columnZADOLAKSICEVBDIOLAKSICA = this.Columns["ZADOLAKSICEVBDIOLAKSICA"];
                this.columnZADOLAKSICEZRNOLAKSICA = this.Columns["ZADOLAKSICEZRNOLAKSICA"];
                this.columnZADOLAKSICEPRIMATELJOLAKSICA1 = this.Columns["ZADOLAKSICEPRIMATELJOLAKSICA1"];
                this.columnZADOLAKSICEPRIMATELJOLAKSICA2 = this.Columns["ZADOLAKSICEPRIMATELJOLAKSICA2"];
                this.columnZADOLAKSICEPRIMATELJOLAKSICA3 = this.Columns["ZADOLAKSICEPRIMATELJOLAKSICA3"];
                this.columnZADMZOLAKSICE = this.Columns["ZADMZOLAKSICE"];
                this.columnZADPZOLAKSICE = this.Columns["ZADPZOLAKSICE"];
                this.columnZADMOOLAKSICE = this.Columns["ZADMOOLAKSICE"];
                this.columnZADPOOLAKSICE = this.Columns["ZADPOOLAKSICE"];
                this.columnZADSIFRAOPISAPLACANJAOLAKSICE = this.Columns["ZADSIFRAOPISAPLACANJAOLAKSICE"];
                this.columnZADOPISPLACANJAOLAKSICE = this.Columns["ZADOPISPLACANJAOLAKSICE"];
                this.columnZADIZNOSOLAKSICE = this.Columns["ZADIZNOSOLAKSICE"];
                this.columnZADPOJEDINACNIPOZIV = this.Columns["ZADPOJEDINACNIPOZIV"];
            }

            public RADNIKDataSet.RADNIKOlaksicaRow NewRADNIKOlaksicaRow()
            {
                return (RADNIKDataSet.RADNIKOlaksicaRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RADNIKDataSet.RADNIKOlaksicaRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RADNIKOlaksicaRowChanged != null)
                {
                    RADNIKDataSet.RADNIKOlaksicaRowChangeEventHandler rADNIKOlaksicaRowChangedEvent = this.RADNIKOlaksicaRowChanged;
                    if (rADNIKOlaksicaRowChangedEvent != null)
                    {
                        rADNIKOlaksicaRowChangedEvent(this, new RADNIKDataSet.RADNIKOlaksicaRowChangeEvent((RADNIKDataSet.RADNIKOlaksicaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RADNIKOlaksicaRowChanging != null)
                {
                    RADNIKDataSet.RADNIKOlaksicaRowChangeEventHandler rADNIKOlaksicaRowChangingEvent = this.RADNIKOlaksicaRowChanging;
                    if (rADNIKOlaksicaRowChangingEvent != null)
                    {
                        rADNIKOlaksicaRowChangingEvent(this, new RADNIKDataSet.RADNIKOlaksicaRowChangeEvent((RADNIKDataSet.RADNIKOlaksicaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("RADNIK_RADNIKOlaksica", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.RADNIKOlaksicaRowDeleted != null)
                {
                    RADNIKDataSet.RADNIKOlaksicaRowChangeEventHandler rADNIKOlaksicaRowDeletedEvent = this.RADNIKOlaksicaRowDeleted;
                    if (rADNIKOlaksicaRowDeletedEvent != null)
                    {
                        rADNIKOlaksicaRowDeletedEvent(this, new RADNIKDataSet.RADNIKOlaksicaRowChangeEvent((RADNIKDataSet.RADNIKOlaksicaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RADNIKOlaksicaRowDeleting != null)
                {
                    RADNIKDataSet.RADNIKOlaksicaRowChangeEventHandler rADNIKOlaksicaRowDeletingEvent = this.RADNIKOlaksicaRowDeleting;
                    if (rADNIKOlaksicaRowDeletingEvent != null)
                    {
                        rADNIKOlaksicaRowDeletingEvent(this, new RADNIKDataSet.RADNIKOlaksicaRowChangeEvent((RADNIKDataSet.RADNIKOlaksicaRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRADNIKOlaksicaRow(RADNIKDataSet.RADNIKOlaksicaRow row)
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

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public RADNIKDataSet.RADNIKOlaksicaRow this[int index]
            {
                get
                {
                    return (RADNIKDataSet.RADNIKOlaksicaRow) this.Rows[index];
                }
            }

            public DataColumn ZADIZNOSOLAKSICEColumn
            {
                get
                {
                    return this.columnZADIZNOSOLAKSICE;
                }
            }

            public DataColumn ZADMOOLAKSICEColumn
            {
                get
                {
                    return this.columnZADMOOLAKSICE;
                }
            }

            public DataColumn ZADMZOLAKSICEColumn
            {
                get
                {
                    return this.columnZADMZOLAKSICE;
                }
            }

            public DataColumn ZADOLAKSICEIDGRUPEOLAKSICAColumn
            {
                get
                {
                    return this.columnZADOLAKSICEIDGRUPEOLAKSICA;
                }
            }

            public DataColumn ZADOLAKSICEIDOLAKSICEColumn
            {
                get
                {
                    return this.columnZADOLAKSICEIDOLAKSICE;
                }
            }

            public DataColumn ZADOLAKSICEIDTIPOLAKSICEColumn
            {
                get
                {
                    return this.columnZADOLAKSICEIDTIPOLAKSICE;
                }
            }

            public DataColumn ZADOLAKSICEMAXIMALNIIZNOSGRUPEColumn
            {
                get
                {
                    return this.columnZADOLAKSICEMAXIMALNIIZNOSGRUPE;
                }
            }

            public DataColumn ZADOLAKSICENAZIVGRUPEOLAKSICAColumn
            {
                get
                {
                    return this.columnZADOLAKSICENAZIVGRUPEOLAKSICA;
                }
            }

            public DataColumn ZADOLAKSICENAZIVOLAKSICEColumn
            {
                get
                {
                    return this.columnZADOLAKSICENAZIVOLAKSICE;
                }
            }

            public DataColumn ZADOLAKSICENAZIVTIPOLAKSICEColumn
            {
                get
                {
                    return this.columnZADOLAKSICENAZIVTIPOLAKSICE;
                }
            }

            public DataColumn ZADOLAKSICEPRIMATELJOLAKSICA1Column
            {
                get
                {
                    return this.columnZADOLAKSICEPRIMATELJOLAKSICA1;
                }
            }

            public DataColumn ZADOLAKSICEPRIMATELJOLAKSICA2Column
            {
                get
                {
                    return this.columnZADOLAKSICEPRIMATELJOLAKSICA2;
                }
            }

            public DataColumn ZADOLAKSICEPRIMATELJOLAKSICA3Column
            {
                get
                {
                    return this.columnZADOLAKSICEPRIMATELJOLAKSICA3;
                }
            }

            public DataColumn ZADOLAKSICEVBDIOLAKSICAColumn
            {
                get
                {
                    return this.columnZADOLAKSICEVBDIOLAKSICA;
                }
            }

            public DataColumn ZADOLAKSICEZRNOLAKSICAColumn
            {
                get
                {
                    return this.columnZADOLAKSICEZRNOLAKSICA;
                }
            }

            public DataColumn ZADOPISPLACANJAOLAKSICEColumn
            {
                get
                {
                    return this.columnZADOPISPLACANJAOLAKSICE;
                }
            }

            public DataColumn ZADPOJEDINACNIPOZIVColumn
            {
                get
                {
                    return this.columnZADPOJEDINACNIPOZIV;
                }
            }

            public DataColumn ZADPOOLAKSICEColumn
            {
                get
                {
                    return this.columnZADPOOLAKSICE;
                }
            }

            public DataColumn ZADPZOLAKSICEColumn
            {
                get
                {
                    return this.columnZADPZOLAKSICE;
                }
            }

            public DataColumn ZADSIFRAOPISAPLACANJAOLAKSICEColumn
            {
                get
                {
                    return this.columnZADSIFRAOPISAPLACANJAOLAKSICE;
                }
            }
        }

        public class RADNIKOlaksicaRow : DataRow
        {
            private RADNIKDataSet.RADNIKOlaksicaDataTable tableRADNIKOlaksica;

            internal RADNIKOlaksicaRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRADNIKOlaksica = (RADNIKDataSet.RADNIKOlaksicaDataTable) this.Table;
            }

            public RADNIKDataSet.RADNIKRow GetRADNIKRow()
            {
                return (RADNIKDataSet.RADNIKRow) this.GetParentRow("RADNIK_RADNIKOlaksica");
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.IDRADNIKColumn);
            }

            public bool IsZADIZNOSOLAKSICENull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADIZNOSOLAKSICEColumn);
            }

            public bool IsZADMOOLAKSICENull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADMOOLAKSICEColumn);
            }

            public bool IsZADMZOLAKSICENull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADMZOLAKSICEColumn);
            }

            public bool IsZADOLAKSICEIDGRUPEOLAKSICANull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADOLAKSICEIDGRUPEOLAKSICAColumn);
            }

            public bool IsZADOLAKSICEIDOLAKSICENull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADOLAKSICEIDOLAKSICEColumn);
            }

            public bool IsZADOLAKSICEIDTIPOLAKSICENull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADOLAKSICEIDTIPOLAKSICEColumn);
            }

            public bool IsZADOLAKSICEMAXIMALNIIZNOSGRUPENull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADOLAKSICEMAXIMALNIIZNOSGRUPEColumn);
            }

            public bool IsZADOLAKSICENAZIVGRUPEOLAKSICANull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADOLAKSICENAZIVGRUPEOLAKSICAColumn);
            }

            public bool IsZADOLAKSICENAZIVOLAKSICENull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADOLAKSICENAZIVOLAKSICEColumn);
            }

            public bool IsZADOLAKSICENAZIVTIPOLAKSICENull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADOLAKSICENAZIVTIPOLAKSICEColumn);
            }

            public bool IsZADOLAKSICEPRIMATELJOLAKSICA1Null()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADOLAKSICEPRIMATELJOLAKSICA1Column);
            }

            public bool IsZADOLAKSICEPRIMATELJOLAKSICA2Null()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADOLAKSICEPRIMATELJOLAKSICA2Column);
            }

            public bool IsZADOLAKSICEPRIMATELJOLAKSICA3Null()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADOLAKSICEPRIMATELJOLAKSICA3Column);
            }

            public bool IsZADOLAKSICEVBDIOLAKSICANull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADOLAKSICEVBDIOLAKSICAColumn);
            }

            public bool IsZADOLAKSICEZRNOLAKSICANull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADOLAKSICEZRNOLAKSICAColumn);
            }

            public bool IsZADOPISPLACANJAOLAKSICENull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADOPISPLACANJAOLAKSICEColumn);
            }

            public bool IsZADPOJEDINACNIPOZIVNull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADPOJEDINACNIPOZIVColumn);
            }

            public bool IsZADPOOLAKSICENull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADPOOLAKSICEColumn);
            }

            public bool IsZADPZOLAKSICENull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADPZOLAKSICEColumn);
            }

            public bool IsZADSIFRAOPISAPLACANJAOLAKSICENull()
            {
                return this.IsNull(this.tableRADNIKOlaksica.ZADSIFRAOPISAPLACANJAOLAKSICEColumn);
            }

            public void SetZADIZNOSOLAKSICENull()
            {
                this[this.tableRADNIKOlaksica.ZADIZNOSOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADMOOLAKSICENull()
            {
                this[this.tableRADNIKOlaksica.ZADMOOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADMZOLAKSICENull()
            {
                this[this.tableRADNIKOlaksica.ZADMZOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOLAKSICEIDGRUPEOLAKSICANull()
            {
                this[this.tableRADNIKOlaksica.ZADOLAKSICEIDGRUPEOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOLAKSICEIDTIPOLAKSICENull()
            {
                this[this.tableRADNIKOlaksica.ZADOLAKSICEIDTIPOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOLAKSICEMAXIMALNIIZNOSGRUPENull()
            {
                this[this.tableRADNIKOlaksica.ZADOLAKSICEMAXIMALNIIZNOSGRUPEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOLAKSICENAZIVGRUPEOLAKSICANull()
            {
                this[this.tableRADNIKOlaksica.ZADOLAKSICENAZIVGRUPEOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOLAKSICENAZIVOLAKSICENull()
            {
                this[this.tableRADNIKOlaksica.ZADOLAKSICENAZIVOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOLAKSICENAZIVTIPOLAKSICENull()
            {
                this[this.tableRADNIKOlaksica.ZADOLAKSICENAZIVTIPOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOLAKSICEPRIMATELJOLAKSICA1Null()
            {
                this[this.tableRADNIKOlaksica.ZADOLAKSICEPRIMATELJOLAKSICA1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOLAKSICEPRIMATELJOLAKSICA2Null()
            {
                this[this.tableRADNIKOlaksica.ZADOLAKSICEPRIMATELJOLAKSICA2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOLAKSICEPRIMATELJOLAKSICA3Null()
            {
                this[this.tableRADNIKOlaksica.ZADOLAKSICEPRIMATELJOLAKSICA3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOLAKSICEVBDIOLAKSICANull()
            {
                this[this.tableRADNIKOlaksica.ZADOLAKSICEVBDIOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOLAKSICEZRNOLAKSICANull()
            {
                this[this.tableRADNIKOlaksica.ZADOLAKSICEZRNOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADOPISPLACANJAOLAKSICENull()
            {
                this[this.tableRADNIKOlaksica.ZADOPISPLACANJAOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADPOJEDINACNIPOZIVNull()
            {
                this[this.tableRADNIKOlaksica.ZADPOJEDINACNIPOZIVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADPOOLAKSICENull()
            {
                this[this.tableRADNIKOlaksica.ZADPOOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADPZOLAKSICENull()
            {
                this[this.tableRADNIKOlaksica.ZADPZOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZADSIFRAOPISAPLACANJAOLAKSICENull()
            {
                this[this.tableRADNIKOlaksica.ZADSIFRAOPISAPLACANJAOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKOlaksica.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableRADNIKOlaksica.IDRADNIKColumn] = value;
                }
            }

            public decimal ZADIZNOSOLAKSICE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKOlaksica.ZADIZNOSOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADIZNOSOLAKSICEColumn] = value;
                }
            }

            public string ZADMOOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADMOOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADMOOLAKSICEColumn] = value;
                }
            }

            public string ZADMZOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADMZOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADMZOLAKSICEColumn] = value;
                }
            }

            public int ZADOLAKSICEIDGRUPEOLAKSICA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIKOlaksica.ZADOLAKSICEIDGRUPEOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADOLAKSICEIDGRUPEOLAKSICAColumn] = value;
                }
            }

            public int ZADOLAKSICEIDOLAKSICE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIKOlaksica.ZADOLAKSICEIDOLAKSICEColumn]);
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADOLAKSICEIDOLAKSICEColumn] = value;
                }
            }

            public int ZADOLAKSICEIDTIPOLAKSICE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIKOlaksica.ZADOLAKSICEIDTIPOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADOLAKSICEIDTIPOLAKSICEColumn] = value;
                }
            }

            public decimal ZADOLAKSICEMAXIMALNIIZNOSGRUPE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIKOlaksica.ZADOLAKSICEMAXIMALNIIZNOSGRUPEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADOLAKSICEMAXIMALNIIZNOSGRUPEColumn] = value;
                }
            }

            public string ZADOLAKSICENAZIVGRUPEOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADOLAKSICENAZIVGRUPEOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADOLAKSICENAZIVGRUPEOLAKSICAColumn] = value;
                }
            }

            public string ZADOLAKSICENAZIVOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADOLAKSICENAZIVOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADOLAKSICENAZIVOLAKSICEColumn] = value;
                }
            }

            public string ZADOLAKSICENAZIVTIPOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADOLAKSICENAZIVTIPOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADOLAKSICENAZIVTIPOLAKSICEColumn] = value;
                }
            }

            public string ZADOLAKSICEPRIMATELJOLAKSICA1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADOLAKSICEPRIMATELJOLAKSICA1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADOLAKSICEPRIMATELJOLAKSICA1Column] = value;
                }
            }

            public string ZADOLAKSICEPRIMATELJOLAKSICA2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADOLAKSICEPRIMATELJOLAKSICA2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADOLAKSICEPRIMATELJOLAKSICA2Column] = value;
                }
            }

            public string ZADOLAKSICEPRIMATELJOLAKSICA3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADOLAKSICEPRIMATELJOLAKSICA3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADOLAKSICEPRIMATELJOLAKSICA3Column] = value;
                }
            }

            public string ZADOLAKSICEVBDIOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADOLAKSICEVBDIOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADOLAKSICEVBDIOLAKSICAColumn] = value;
                }
            }

            public string ZADOLAKSICEZRNOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADOLAKSICEZRNOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADOLAKSICEZRNOLAKSICAColumn] = value;
                }
            }

            public string ZADOPISPLACANJAOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADOPISPLACANJAOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADOPISPLACANJAOLAKSICEColumn] = value;
                }
            }

            public string ZADPOJEDINACNIPOZIV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADPOJEDINACNIPOZIVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADPOJEDINACNIPOZIVColumn] = value;
                }
            }

            public string ZADPOOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADPOOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADPOOLAKSICEColumn] = value;
                }
            }

            public string ZADPZOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADPZOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADPZOLAKSICEColumn] = value;
                }
            }

            public string ZADSIFRAOPISAPLACANJAOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIKOlaksica.ZADSIFRAOPISAPLACANJAOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIKOlaksica.ZADSIFRAOPISAPLACANJAOLAKSICEColumn] = value;
                }
            }
        }

        public class RADNIKOlaksicaRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RADNIKDataSet.RADNIKOlaksicaRow eventRow;

            public RADNIKOlaksicaRowChangeEvent(RADNIKDataSet.RADNIKOlaksicaRow row, DataRowAction action)
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

            public RADNIKDataSet.RADNIKOlaksicaRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RADNIKOlaksicaRowChangeEventHandler(object sender, RADNIKDataSet.RADNIKOlaksicaRowChangeEvent e);

        public class RADNIKRow : DataRow
        {
            private RADNIKDataSet.RADNIKDataTable tableRADNIK;

            internal RADNIKRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRADNIK = (RADNIKDataSet.RADNIKDataTable) this.Table;
            }

            public RADNIKDataSet.RADNIKBrutoRow[] GetRADNIKBrutoRows()
            {
                return (RADNIKDataSet.RADNIKBrutoRow[]) this.GetChildRows("RADNIK_RADNIKBruto");
            }

            public RADNIKDataSet.RADNIKIzuzeceOdOvrheRow[] GetRADNIKIzuzeceOdOvrheRows()
            {
                return (RADNIKDataSet.RADNIKIzuzeceOdOvrheRow[]) this.GetChildRows("RADNIK_RADNIKIzuzeceOdOvrhe");
            }

            public RADNIKDataSet.RADNIKKreditiRow[] GetRADNIKKreditiRows()
            {
                return (RADNIKDataSet.RADNIKKreditiRow[]) this.GetChildRows("RADNIK_RADNIKKrediti");
            }

            public RADNIKDataSet.RADNIKLevel7Row[] GetRADNIKLevel7Rows()
            {
                return (RADNIKDataSet.RADNIKLevel7Row[]) this.GetChildRows("RADNIK_RADNIKLevel7");
            }

            public RADNIKDataSet.RADNIKNetoRow[] GetRADNIKNetoRows()
            {
                return (RADNIKDataSet.RADNIKNetoRow[]) this.GetChildRows("RADNIK_RADNIKNeto");
            }

            public RADNIKDataSet.RADNIKObustavaRow[] GetRADNIKObustavaRows()
            {
                return (RADNIKDataSet.RADNIKObustavaRow[]) this.GetChildRows("RADNIK_RADNIKObustava");
            }

            public RADNIKDataSet.RADNIKOdbitakRow[] GetRADNIKOdbitakRows()
            {
                return (RADNIKDataSet.RADNIKOdbitakRow[]) this.GetChildRows("RADNIK_RADNIKOdbitak");
            }

            public RADNIKDataSet.RADNIKOlaksicaRow[] GetRADNIKOlaksicaRows()
            {
                return (RADNIKDataSet.RADNIKOlaksicaRow[]) this.GetChildRows("RADNIK_RADNIKOlaksica");
            }

            public bool IsAKTIVANNull()
            {
                return this.IsNull(this.tableRADNIK.AKTIVANColumn);
            }

            public bool IsBROJMIROVINSKOGNull()
            {
                return this.IsNull(this.tableRADNIK.BROJMIROVINSKOGColumn);
            }

            public bool IsBROJPRIZNATIHMJESECINull()
            {
                return this.IsNull(this.tableRADNIK.BROJPRIZNATIHMJESECIColumn);
            }

            public bool IsBROJZDRAVSTVENOGNull()
            {
                return this.IsNull(this.tableRADNIK.BROJZDRAVSTVENOGColumn);
            }

            public bool IsDANISTAZANull()
            {
                return this.IsNull(this.tableRADNIK.DANISTAZAColumn);
            }

            public bool IsDANISTAZAPRONull()
            {
                return this.IsNull(this.tableRADNIK.DANISTAZAPROColumn);
            }

            public bool IsDATUMPRESTANKARADNOGODNOSANull()
            {
                return this.IsNull(this.tableRADNIK.DATUMPRESTANKARADNOGODNOSAColumn);
            }

            public bool IsDATUMRODJENJANull()
            {
                return this.IsNull(this.tableRADNIK.DATUMRODJENJAColumn);
            }

            public bool IsDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATINull()
            {
                return this.IsNull(this.tableRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIColumn);
            }

            public bool IsGODINESTAZANull()
            {
                return this.IsNull(this.tableRADNIK.GODINESTAZAColumn);
            }

            public bool IsGODINESTAZAPRONull()
            {
                return this.IsNull(this.tableRADNIK.GODINESTAZAPROColumn);
            }

            public bool IsIDBANKENull()
            {
                return this.IsNull(this.tableRADNIK.IDBANKEColumn);
            }

            public bool IsIDBENEFICIRANINull()
            {
                return this.IsNull(this.tableRADNIK.IDBENEFICIRANIColumn);
            }

            public bool IsIDBRACNOSTANJENull()
            {
                return this.IsNull(this.tableRADNIK.IDBRACNOSTANJEColumn);
            }

            public bool IsIDDRZAVLJANSTVONull()
            {
                return this.IsNull(this.tableRADNIK.IDDRZAVLJANSTVOColumn);
            }

            public bool IsIDIPIDENTNull()
            {
                return this.IsNull(this.tableRADNIK.IDIPIDENTColumn);
            }

            public bool IsIDORGDIONull()
            {
                return this.IsNull(this.tableRADNIK.IDORGDIOColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableRADNIK.IDRADNIKColumn);
            }

            public bool IsIDRADNOMJESTONull()
            {
                return this.IsNull(this.tableRADNIK.IDRADNOMJESTOColumn);
            }

            public bool IsIDRADNOVRIJEMENull()
            {
                return this.IsNull(this.tableRADNIK.IDRADNOVRIJEMEColumn);
            }

            public bool IsIDSPOLNull()
            {
                return this.IsNull(this.tableRADNIK.IDSPOLColumn);
            }

            public bool IsIDSTRUKANull()
            {
                return this.IsNull(this.tableRADNIK.IDSTRUKAColumn);
            }

            public bool IsIDTITULANull()
            {
                return this.IsNull(this.tableRADNIK.IDTITULAColumn);
            }

            public bool IsIDUGOVORORADUNull()
            {
                return this.IsNull(this.tableRADNIK.IDUGOVORORADUColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableRADNIK.IMEColumn);
            }

            public bool IsJMBGNull()
            {
                return this.IsNull(this.tableRADNIK.JMBGColumn);
            }

            public bool IsKOEFICIJENTNull()
            {
                return this.IsNull(this.tableRADNIK.KOEFICIJENTColumn);
            }

            public bool IskucnibrojNull()
            {
                return this.IsNull(this.tableRADNIK.kucnibrojColumn);
            }

            public bool IsMBONull()
            {
                return this.IsNull(this.tableRADNIK.MBOColumn);
            }

            public bool IsMJESECISTAZANull()
            {
                return this.IsNull(this.tableRADNIK.MJESECISTAZAColumn);
            }

            public bool IsMJESECISTAZAPRONull()
            {
                return this.IsNull(this.tableRADNIK.MJESECISTAZAPROColumn);
            }

            public bool IsmjestoNull()
            {
                return this.IsNull(this.tableRADNIK.mjestoColumn);
            }

            public bool IsMONull()
            {
                return this.IsNull(this.tableRADNIK.MOColumn);
            }

            public bool IsNAZIVBANKE1Null()
            {
                return this.IsNull(this.tableRADNIK.NAZIVBANKE1Column);
            }

            public bool IsNAZIVBANKE2Null()
            {
                return this.IsNull(this.tableRADNIK.NAZIVBANKE2Column);
            }

            public bool IsNAZIVBANKE3Null()
            {
                return this.IsNull(this.tableRADNIK.NAZIVBANKE3Column);
            }

            public bool IsNAZIVBENEFICIRANINull()
            {
                return this.IsNull(this.tableRADNIK.NAZIVBENEFICIRANIColumn);
            }

            public bool IsNAZIVBRACNOSTANJENull()
            {
                return this.IsNull(this.tableRADNIK.NAZIVBRACNOSTANJEColumn);
            }

            public bool IsNAZIVDRZAVLJANSTVONull()
            {
                return this.IsNull(this.tableRADNIK.NAZIVDRZAVLJANSTVOColumn);
            }

            public bool IsNAZIVIPIDENTNull()
            {
                return this.IsNull(this.tableRADNIK.NAZIVIPIDENTColumn);
            }

            public bool IsNAZIVPOSLANull()
            {
                return this.IsNull(this.tableRADNIK.NAZIVPOSLAColumn);
            }

            public bool IsNAZIVRADNOMJESTONull()
            {
                return this.IsNull(this.tableRADNIK.NAZIVRADNOMJESTOColumn);
            }

            public bool IsNAZIVSPOLNull()
            {
                return this.IsNull(this.tableRADNIK.NAZIVSPOLColumn);
            }

            public bool IsNAZIVSTRUKANull()
            {
                return this.IsNull(this.tableRADNIK.NAZIVSTRUKAColumn);
            }

            public bool IsNAZIVTITULANull()
            {
                return this.IsNull(this.tableRADNIK.NAZIVTITULAColumn);
            }

            public bool IsNAZIVUGOVORORADUNull()
            {
                return this.IsNull(this.tableRADNIK.NAZIVUGOVORORADUColumn);
            }

            public bool IsOIBNull()
            {
                return this.IsNull(this.tableRADNIK.OIBColumn);
            }

            public bool IsOPCINARADAIDOPCINENull()
            {
                return this.IsNull(this.tableRADNIK.OPCINARADAIDOPCINEColumn);
            }

            public bool IsOPCINARADANAZIVOPCINENull()
            {
                return this.IsNull(this.tableRADNIK.OPCINARADANAZIVOPCINEColumn);
            }

            public bool IsOPCINASTANOVANJAIDOPCINENull()
            {
                return this.IsNull(this.tableRADNIK.OPCINASTANOVANJAIDOPCINEColumn);
            }

            public bool IsOPCINASTANOVANJANAZIVOPCINENull()
            {
                return this.IsNull(this.tableRADNIK.OPCINASTANOVANJANAZIVOPCINEColumn);
            }

            public bool IsOPCINASTANOVANJAPRIREZNull()
            {
                return this.IsNull(this.tableRADNIK.OPCINASTANOVANJAPRIREZColumn);
            }

            public bool IsOPCINASTANOVANJAVBDIOPCINANull()
            {
                return this.IsNull(this.tableRADNIK.OPCINASTANOVANJAVBDIOPCINAColumn);
            }

            public bool IsOPCINASTANOVANJAZRNOPCINANull()
            {
                return this.IsNull(this.tableRADNIK.OPCINASTANOVANJAZRNOPCINAColumn);
            }

            public bool IsOPISPLACANJANETONull()
            {
                return this.IsNull(this.tableRADNIK.OPISPLACANJANETOColumn);
            }

            public bool IsORGANIZACIJSKIDIONull()
            {
                return this.IsNull(this.tableRADNIK.ORGANIZACIJSKIDIOColumn);
            }

            public bool IsPBONull()
            {
                return this.IsNull(this.tableRADNIK.PBOColumn);
            }

            public bool IsPOCETAKRADANull()
            {
                return this.IsNull(this.tableRADNIK.POCETAKRADAColumn);
            }

            public bool IsPOSTOTAKOSLOBODJENJAODPOREZANull()
            {
                return this.IsNull(this.tableRADNIK.POSTOTAKOSLOBODJENJAODPOREZAColumn);
            }

            public bool IsPOTREBNASTRUCNASPREMAIDSTRUCNASPREMANull()
            {
                return this.IsNull(this.tableRADNIK.POTREBNASTRUCNASPREMAIDSTRUCNASPREMAColumn);
            }

            public bool IsPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMANull()
            {
                return this.IsNull(this.tableRADNIK.POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableRADNIK.PREZIMEColumn);
            }

            public bool IsPRODUZENOMIROVINSKONull()
            {
                return this.IsNull(this.tableRADNIK.PRODUZENOMIROVINSKOColumn);
            }

            public bool IsRADNADOZVOLANull()
            {
                return this.IsNull(this.tableRADNIK.RADNADOZVOLAColumn);
            }

            public bool IsRADNASPOSOBNOSTNull()
            {
                return this.IsNull(this.tableRADNIK.RADNASPOSOBNOSTColumn);
            }

            public bool IsRADNIKNAPOMENANull()
            {
                return this.IsNull(this.tableRADNIK.RADNIKNAPOMENAColumn);
            }

            public bool IsRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSANull()
            {
                return this.IsNull(this.tableRADNIK.RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAColumn);
            }

            public bool IsRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSANull()
            {
                return this.IsNull(this.tableRADNIK.RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAColumn);
            }

            public bool IsRADUINOZEMSTVUNull()
            {
                return this.IsNull(this.tableRADNIK.RADUINOZEMSTVUColumn);
            }

            public bool IsRAZLOGPRESTANKANull()
            {
                return this.IsNull(this.tableRADNIK.RAZLOGPRESTANKAColumn);
            }

            public bool IsSIFRAOPISAPLACANJANETONull()
            {
                return this.IsNull(this.tableRADNIK.SIFRAOPISAPLACANJANETOColumn);
            }

            public bool IsSPOJENOPREZIMENull()
            {
                return this.IsNull(this.tableRADNIK.SPOJENOPREZIMEColumn);
            }

            public bool IsTEKUCINull()
            {
                return this.IsNull(this.tableRADNIK.TEKUCIColumn);
            }

            public bool IsTJEDNIFONDSATINull()
            {
                return this.IsNull(this.tableRADNIK.TJEDNIFONDSATIColumn);
            }

            public bool IsTJEDNIFONDSATISTAZNull()
            {
                return this.IsNull(this.tableRADNIK.TJEDNIFONDSATISTAZColumn);
            }

            public bool IsTRENUTNASTRUCNASPREMAIDSTRUCNASPREMANull()
            {
                return this.IsNull(this.tableRADNIK.TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAColumn);
            }

            public bool IsTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMANull()
            {
                return this.IsNull(this.tableRADNIK.TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn);
            }

            public bool IsUGOVORODNull()
            {
                return this.IsNull(this.tableRADNIK.UGOVORODColumn);
            }

            public bool IsUKUPNIFAKTORNull()
            {
                return this.IsNull(this.tableRADNIK.UKUPNIFAKTORColumn);
            }

            public bool IsUKUPNODANASTAZANull()
            {
                return this.IsNull(this.tableRADNIK.UKUPNODANASTAZAColumn);
            }

            public bool IsUKUPNOGODINESTAZANull()
            {
                return this.IsNull(this.tableRADNIK.UKUPNOGODINESTAZAColumn);
            }

            public bool IsUKUPNOMJESECISTAZANull()
            {
                return this.IsNull(this.tableRADNIK.UKUPNOMJESECISTAZAColumn);
            }

            public bool IsulicaNull()
            {
                return this.IsNull(this.tableRADNIK.ulicaColumn);
            }

            public bool IsUZIMAUOBZIROSNOVICEDOPRINOSANull()
            {
                return this.IsNull(this.tableRADNIK.UZIMAUOBZIROSNOVICEDOPRINOSAColumn);
            }

            public bool IsVBDIBANKENull()
            {
                return this.IsNull(this.tableRADNIK.VBDIBANKEColumn);
            }

            public bool IsVRIJEMEMIROVANJARADNOGODNOSANull()
            {
                return this.IsNull(this.tableRADNIK.VRIJEMEMIROVANJARADNOGODNOSAColumn);
            }

            public bool IsVRIJEMEPRIPRAVNICKOGNull()
            {
                return this.IsNull(this.tableRADNIK.VRIJEMEPRIPRAVNICKOGColumn);
            }

            public bool IsVRIJEMEPROBNOGRADANull()
            {
                return this.IsNull(this.tableRADNIK.VRIJEMEPROBNOGRADAColumn);
            }

            public bool IsVRIJEMESTRUCNINull()
            {
                return this.IsNull(this.tableRADNIK.VRIJEMESTRUCNIColumn);
            }

            public bool IsZABRANANATJECANJANull()
            {
                return this.IsNull(this.tableRADNIK.ZABRANANATJECANJAColumn);
            }

            public bool IsZAVRSENASKOLANull()
            {
                return this.IsNull(this.tableRADNIK.ZAVRSENASKOLAColumn);
            }

            public bool IsZBIRNINETONull()
            {
                return this.IsNull(this.tableRADNIK.ZBIRNINETOColumn);
            }

            public bool IsZRNBANKENull()
            {
                return this.IsNull(this.tableRADNIK.ZRNBANKEColumn);
            }

            public void SetAKTIVANNull()
            {
                this[this.tableRADNIK.AKTIVANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJMIROVINSKOGNull()
            {
                this[this.tableRADNIK.BROJMIROVINSKOGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJPRIZNATIHMJESECINull()
            {
                this[this.tableRADNIK.BROJPRIZNATIHMJESECIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJZDRAVSTVENOGNull()
            {
                this[this.tableRADNIK.BROJZDRAVSTVENOGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDANISTAZANull()
            {
                this[this.tableRADNIK.DANISTAZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDANISTAZAPRONull()
            {
                this[this.tableRADNIK.DANISTAZAPROColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMPRESTANKARADNOGODNOSANull()
            {
                this[this.tableRADNIK.DATUMPRESTANKARADNOGODNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMRODJENJANull()
            {
                this[this.tableRADNIK.DATUMRODJENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATINull()
            {
                this[this.tableRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGODINESTAZANull()
            {
                this[this.tableRADNIK.GODINESTAZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGODINESTAZAPRONull()
            {
                this[this.tableRADNIK.GODINESTAZAPROColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDBANKENull()
            {
                this[this.tableRADNIK.IDBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDBENEFICIRANINull()
            {
                this[this.tableRADNIK.IDBENEFICIRANIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDBRACNOSTANJENull()
            {
                this[this.tableRADNIK.IDBRACNOSTANJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDDRZAVLJANSTVONull()
            {
                this[this.tableRADNIK.IDDRZAVLJANSTVOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDIPIDENTNull()
            {
                this[this.tableRADNIK.IDIPIDENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDORGDIONull()
            {
                this[this.tableRADNIK.IDORGDIOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNOMJESTONull()
            {
                this[this.tableRADNIK.IDRADNOMJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNOVRIJEMENull()
            {
                this[this.tableRADNIK.IDRADNOVRIJEMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDSPOLNull()
            {
                this[this.tableRADNIK.IDSPOLColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDSTRUKANull()
            {
                this[this.tableRADNIK.IDSTRUKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDTITULANull()
            {
                this[this.tableRADNIK.IDTITULAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDUGOVORORADUNull()
            {
                this[this.tableRADNIK.IDUGOVORORADUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableRADNIK.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGNull()
            {
                this[this.tableRADNIK.JMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOEFICIJENTNull()
            {
                this[this.tableRADNIK.KOEFICIJENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetkucnibrojNull()
            {
                this[this.tableRADNIK.kucnibrojColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMBONull()
            {
                this[this.tableRADNIK.MBOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECISTAZANull()
            {
                this[this.tableRADNIK.MJESECISTAZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECISTAZAPRONull()
            {
                this[this.tableRADNIK.MJESECISTAZAPROColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetmjestoNull()
            {
                this[this.tableRADNIK.mjestoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMONull()
            {
                this[this.tableRADNIK.MOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE1Null()
            {
                this[this.tableRADNIK.NAZIVBANKE1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE2Null()
            {
                this[this.tableRADNIK.NAZIVBANKE2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE3Null()
            {
                this[this.tableRADNIK.NAZIVBANKE3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBENEFICIRANINull()
            {
                this[this.tableRADNIK.NAZIVBENEFICIRANIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBRACNOSTANJENull()
            {
                this[this.tableRADNIK.NAZIVBRACNOSTANJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVDRZAVLJANSTVONull()
            {
                this[this.tableRADNIK.NAZIVDRZAVLJANSTVOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVIPIDENTNull()
            {
                this[this.tableRADNIK.NAZIVIPIDENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPOSLANull()
            {
                this[this.tableRADNIK.NAZIVPOSLAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVRADNOMJESTONull()
            {
                this[this.tableRADNIK.NAZIVRADNOMJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVSPOLNull()
            {
                this[this.tableRADNIK.NAZIVSPOLColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVSTRUKANull()
            {
                this[this.tableRADNIK.NAZIVSTRUKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVTITULANull()
            {
                this[this.tableRADNIK.NAZIVTITULAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVUGOVORORADUNull()
            {
                this[this.tableRADNIK.NAZIVUGOVORORADUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOIBNull()
            {
                this[this.tableRADNIK.OIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINARADAIDOPCINENull()
            {
                this[this.tableRADNIK.OPCINARADAIDOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINARADANAZIVOPCINENull()
            {
                this[this.tableRADNIK.OPCINARADANAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAIDOPCINENull()
            {
                this[this.tableRADNIK.OPCINASTANOVANJAIDOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJANAZIVOPCINENull()
            {
                this[this.tableRADNIK.OPCINASTANOVANJANAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAPRIREZNull()
            {
                this[this.tableRADNIK.OPCINASTANOVANJAPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAVBDIOPCINANull()
            {
                this[this.tableRADNIK.OPCINASTANOVANJAVBDIOPCINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAZRNOPCINANull()
            {
                this[this.tableRADNIK.OPCINASTANOVANJAZRNOPCINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJANETONull()
            {
                this[this.tableRADNIK.OPISPLACANJANETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetORGANIZACIJSKIDIONull()
            {
                this[this.tableRADNIK.ORGANIZACIJSKIDIOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPBONull()
            {
                this[this.tableRADNIK.PBOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOCETAKRADANull()
            {
                this[this.tableRADNIK.POCETAKRADAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOSTOTAKOSLOBODJENJAODPOREZANull()
            {
                this[this.tableRADNIK.POSTOTAKOSLOBODJENJAODPOREZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOTREBNASTRUCNASPREMAIDSTRUCNASPREMANull()
            {
                this[this.tableRADNIK.POTREBNASTRUCNASPREMAIDSTRUCNASPREMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMANull()
            {
                this[this.tableRADNIK.POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableRADNIK.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRODUZENOMIROVINSKONull()
            {
                this[this.tableRADNIK.PRODUZENOMIROVINSKOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRADNADOZVOLANull()
            {
                this[this.tableRADNIK.RADNADOZVOLAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRADNASPOSOBNOSTNull()
            {
                this[this.tableRADNIK.RADNASPOSOBNOSTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRADNIKNAPOMENANull()
            {
                this[this.tableRADNIK.RADNIKNAPOMENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSANull()
            {
                this[this.tableRADNIK.RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSANull()
            {
                this[this.tableRADNIK.RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRADUINOZEMSTVUNull()
            {
                this[this.tableRADNIK.RADUINOZEMSTVUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRAZLOGPRESTANKANull()
            {
                this[this.tableRADNIK.RAZLOGPRESTANKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJANETONull()
            {
                this[this.tableRADNIK.SIFRAOPISAPLACANJANETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSPOJENOPREZIMENull()
            {
                this[this.tableRADNIK.SPOJENOPREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTEKUCINull()
            {
                this[this.tableRADNIK.TEKUCIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTJEDNIFONDSATINull()
            {
                this[this.tableRADNIK.TJEDNIFONDSATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTJEDNIFONDSATISTAZNull()
            {
                this[this.tableRADNIK.TJEDNIFONDSATISTAZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTRENUTNASTRUCNASPREMAIDSTRUCNASPREMANull()
            {
                this[this.tableRADNIK.TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMANull()
            {
                this[this.tableRADNIK.TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUGOVORODNull()
            {
                this[this.tableRADNIK.UGOVORODColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNIFAKTORNull()
            {
                this[this.tableRADNIK.UKUPNIFAKTORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNODANASTAZANull()
            {
                this[this.tableRADNIK.UKUPNODANASTAZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOGODINESTAZANull()
            {
                this[this.tableRADNIK.UKUPNOGODINESTAZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNOMJESECISTAZANull()
            {
                this[this.tableRADNIK.UKUPNOMJESECISTAZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetulicaNull()
            {
                this[this.tableRADNIK.ulicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUZIMAUOBZIROSNOVICEDOPRINOSANull()
            {
                this[this.tableRADNIK.UZIMAUOBZIROSNOVICEDOPRINOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIBANKENull()
            {
                this[this.tableRADNIK.VBDIBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVRIJEMEMIROVANJARADNOGODNOSANull()
            {
                this[this.tableRADNIK.VRIJEMEMIROVANJARADNOGODNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVRIJEMEPRIPRAVNICKOGNull()
            {
                this[this.tableRADNIK.VRIJEMEPRIPRAVNICKOGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVRIJEMEPROBNOGRADANull()
            {
                this[this.tableRADNIK.VRIJEMEPROBNOGRADAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVRIJEMESTRUCNINull()
            {
                this[this.tableRADNIK.VRIJEMESTRUCNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZABRANANATJECANJANull()
            {
                this[this.tableRADNIK.ZABRANANATJECANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZAVRSENASKOLANull()
            {
                this[this.tableRADNIK.ZAVRSENASKOLAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZBIRNINETONull()
            {
                this[this.tableRADNIK.ZBIRNINETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNBANKENull()
            {
                this[this.tableRADNIK.ZRNBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool AKTIVAN
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableRADNIK.AKTIVANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableRADNIK.AKTIVANColumn] = value;
                }
            }

            public string BROJMIROVINSKOG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.BROJMIROVINSKOGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.BROJMIROVINSKOGColumn] = value;
                }
            }

            public short BROJPRIZNATIHMJESECI
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableRADNIK.BROJPRIZNATIHMJESECIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.BROJPRIZNATIHMJESECIColumn] = value;
                }
            }

            public string BROJZDRAVSTVENOG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.BROJZDRAVSTVENOGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.BROJZDRAVSTVENOGColumn] = value;
                }
            }

            public short DANISTAZA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableRADNIK.DANISTAZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.DANISTAZAColumn] = value;
                }
            }

            public short DANISTAZAPRO
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableRADNIK.DANISTAZAPROColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.DANISTAZAPROColumn] = value;
                }
            }

            public DateTime DATUMPRESTANKARADNOGODNOSA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableRADNIK.DATUMPRESTANKARADNOGODNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableRADNIK.DATUMPRESTANKARADNOGODNOSAColumn] = value;
                }
            }

            public DateTime DATUMRODJENJA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableRADNIK.DATUMRODJENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableRADNIK.DATUMRODJENJAColumn] = value;
                }
            }

            public DateTime DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIColumn] = value;
                }
            }

            public short GODINESTAZA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableRADNIK.GODINESTAZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.GODINESTAZAColumn] = value;
                }
            }

            public short GODINESTAZAPRO
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableRADNIK.GODINESTAZAPROColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.GODINESTAZAPROColumn] = value;
                }
            }

            public int IDBANKE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.IDBANKEColumn] = value;
                }
            }

            public string IDBENEFICIRANI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.IDBENEFICIRANIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.IDBENEFICIRANIColumn] = value;
                }
            }

            public int IDBRACNOSTANJE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDBRACNOSTANJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.IDBRACNOSTANJEColumn] = value;
                }
            }

            public int IDDRZAVLJANSTVO
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDDRZAVLJANSTVOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.IDDRZAVLJANSTVOColumn] = value;
                }
            }

            public int IDIPIDENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDIPIDENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.IDIPIDENTColumn] = value;
                }
            }

            public int IDORGDIO
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDORGDIOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.IDORGDIOColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNIK.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableRADNIK.IDRADNIKColumn] = value;
                }
            }

            public int IDRADNOMJESTO
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDRADNOMJESTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.IDRADNOMJESTOColumn] = value;
                }
            }

            public int IDRADNOVRIJEME
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDRADNOVRIJEMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.IDRADNOVRIJEMEColumn] = value;
                }
            }

            public int IDSPOL
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDSPOLColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.IDSPOLColumn] = value;
                }
            }

            public int IDSTRUKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDSTRUKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.IDSTRUKAColumn] = value;
                }
            }

            public int IDTITULA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDTITULAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.IDTITULAColumn] = value;
                }
            }

            public int IDUGOVORORADU
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.IDUGOVORORADUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.IDUGOVORORADUColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.IMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.IMEColumn] = value;
                }
            }

            public string JMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.JMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.JMBGColumn] = value;
                }
            }

            public decimal KOEFICIJENT
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIK.KOEFICIJENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.KOEFICIJENTColumn] = value;
                }
            }

            public string kucnibroj
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.kucnibrojColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.kucnibrojColumn] = value;
                }
            }

            public string MBO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.MBOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.MBOColumn] = value;
                }
            }

            public short MJESECISTAZA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableRADNIK.MJESECISTAZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.MJESECISTAZAColumn] = value;
                }
            }

            public short MJESECISTAZAPRO
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableRADNIK.MJESECISTAZAPROColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.MJESECISTAZAPROColumn] = value;
                }
            }

            public string mjesto
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.mjestoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.mjestoColumn] = value;
                }
            }

            public string MO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.MOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.MOColumn] = value;
                }
            }

            public string NAZIVBANKE1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.NAZIVBANKE1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.NAZIVBANKE1Column] = value;
                }
            }

            public string NAZIVBANKE2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.NAZIVBANKE2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.NAZIVBANKE2Column] = value;
                }
            }

            public string NAZIVBANKE3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.NAZIVBANKE3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.NAZIVBANKE3Column] = value;
                }
            }

            public string NAZIVBENEFICIRANI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.NAZIVBENEFICIRANIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.NAZIVBENEFICIRANIColumn] = value;
                }
            }

            public string NAZIVBRACNOSTANJE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.NAZIVBRACNOSTANJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.NAZIVBRACNOSTANJEColumn] = value;
                }
            }

            public string NAZIVDRZAVLJANSTVO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.NAZIVDRZAVLJANSTVOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.NAZIVDRZAVLJANSTVOColumn] = value;
                }
            }

            public string NAZIVIPIDENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.NAZIVIPIDENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.NAZIVIPIDENTColumn] = value;
                }
            }

            public string NAZIVPOSLA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.NAZIVPOSLAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.NAZIVPOSLAColumn] = value;
                }
            }

            public string NAZIVRADNOMJESTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.NAZIVRADNOMJESTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.NAZIVRADNOMJESTOColumn] = value;
                }
            }

            public string NAZIVSPOL
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.NAZIVSPOLColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.NAZIVSPOLColumn] = value;
                }
            }

            public string NAZIVSTRUKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.NAZIVSTRUKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.NAZIVSTRUKAColumn] = value;
                }
            }

            public string NAZIVTITULA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.NAZIVTITULAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.NAZIVTITULAColumn] = value;
                }
            }

            public string NAZIVUGOVORORADU
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.NAZIVUGOVORORADUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.NAZIVUGOVORORADUColumn] = value;
                }
            }

            public string OIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.OIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.OIBColumn] = value;
                }
            }

            public string OPCINARADAIDOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.OPCINARADAIDOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.OPCINARADAIDOPCINEColumn] = value;
                }
            }

            public string OPCINARADANAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.OPCINARADANAZIVOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.OPCINARADANAZIVOPCINEColumn] = value;
                }
            }

            public string OPCINASTANOVANJAIDOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.OPCINASTANOVANJAIDOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.OPCINASTANOVANJAIDOPCINEColumn] = value;
                }
            }

            public string OPCINASTANOVANJANAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.OPCINASTANOVANJANAZIVOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.OPCINASTANOVANJANAZIVOPCINEColumn] = value;
                }
            }

            public decimal OPCINASTANOVANJAPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIK.OPCINASTANOVANJAPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.OPCINASTANOVANJAPRIREZColumn] = value;
                }
            }

            public string OPCINASTANOVANJAVBDIOPCINA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.OPCINASTANOVANJAVBDIOPCINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.OPCINASTANOVANJAVBDIOPCINAColumn] = value;
                }
            }

            public string OPCINASTANOVANJAZRNOPCINA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.OPCINASTANOVANJAZRNOPCINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.OPCINASTANOVANJAZRNOPCINAColumn] = value;
                }
            }

            public string OPISPLACANJANETO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.OPISPLACANJANETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.OPISPLACANJANETOColumn] = value;
                }
            }

            public string ORGANIZACIJSKIDIO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.ORGANIZACIJSKIDIOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.ORGANIZACIJSKIDIOColumn] = value;
                }
            }

            public string PBO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.PBOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.PBOColumn] = value;
                }
            }

            public DateTime POCETAKRADA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableRADNIK.POCETAKRADAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableRADNIK.POCETAKRADAColumn] = value;
                }
            }

            public decimal POSTOTAKOSLOBODJENJAODPOREZA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIK.POSTOTAKOSLOBODJENJAODPOREZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.POSTOTAKOSLOBODJENJAODPOREZAColumn] = value;
                }
            }

            public int POTREBNASTRUCNASPREMAIDSTRUCNASPREMA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.POTREBNASTRUCNASPREMAIDSTRUCNASPREMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.POTREBNASTRUCNASPREMAIDSTRUCNASPREMAColumn] = value;
                }
            }

            public string POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.PREZIMEColumn] = value;
                }
            }

            public string PRODUZENOMIROVINSKO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.PRODUZENOMIROVINSKOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.PRODUZENOMIROVINSKOColumn] = value;
                }
            }

            public string RADNADOZVOLA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.RADNADOZVOLAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.RADNADOZVOLAColumn] = value;
                }
            }

            public string RADNASPOSOBNOST
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.RADNASPOSOBNOSTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.RADNASPOSOBNOSTColumn] = value;
                }
            }

            public string RADNIKNAPOMENA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.RADNIKNAPOMENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.RADNIKNAPOMENAColumn] = value;
                }
            }

            public int RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAColumn] = value;
                }
            }

            public string RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAColumn] = value;
                }
            }

            public string RADUINOZEMSTVU
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.RADUINOZEMSTVUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.RADUINOZEMSTVUColumn] = value;
                }
            }

            public string RAZLOGPRESTANKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.RAZLOGPRESTANKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.RAZLOGPRESTANKAColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJANETO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.SIFRAOPISAPLACANJANETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.SIFRAOPISAPLACANJANETOColumn] = value;
                }
            }

            public string SPOJENOPREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.SPOJENOPREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.SPOJENOPREZIMEColumn] = value;
                }
            }

            public string TEKUCI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.TEKUCIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.TEKUCIColumn] = value;
                }
            }

            public decimal TJEDNIFONDSATI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIK.TJEDNIFONDSATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.TJEDNIFONDSATIColumn] = value;
                }
            }

            public decimal TJEDNIFONDSATISTAZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIK.TJEDNIFONDSATISTAZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.TJEDNIFONDSATISTAZColumn] = value;
                }
            }

            public int TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableRADNIK.TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAColumn] = value;
                }
            }

            public string TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn] = value;
                }
            }

            public DateTime UGOVOROD
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableRADNIK.UGOVORODColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableRADNIK.UGOVORODColumn] = value;
                }
            }

            public decimal UKUPNIFAKTOR
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableRADNIK.UKUPNIFAKTORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.UKUPNIFAKTORColumn] = value;
                }
            }

            public short UKUPNODANASTAZA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableRADNIK.UKUPNODANASTAZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.UKUPNODANASTAZAColumn] = value;
                }
            }

            public short UKUPNOGODINESTAZA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableRADNIK.UKUPNOGODINESTAZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.UKUPNOGODINESTAZAColumn] = value;
                }
            }

            public short UKUPNOMJESECISTAZA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableRADNIK.UKUPNOMJESECISTAZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableRADNIK.UKUPNOMJESECISTAZAColumn] = value;
                }
            }

            public string ulica
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.ulicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.ulicaColumn] = value;
                }
            }

            public bool UZIMAUOBZIROSNOVICEDOPRINOSA
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableRADNIK.UZIMAUOBZIROSNOVICEDOPRINOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableRADNIK.UZIMAUOBZIROSNOVICEDOPRINOSAColumn] = value;
                }
            }

            public string VBDIBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.VBDIBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.VBDIBANKEColumn] = value;
                }
            }

            public string VRIJEMEMIROVANJARADNOGODNOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.VRIJEMEMIROVANJARADNOGODNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.VRIJEMEMIROVANJARADNOGODNOSAColumn] = value;
                }
            }

            public string VRIJEMEPRIPRAVNICKOG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.VRIJEMEPRIPRAVNICKOGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.VRIJEMEPRIPRAVNICKOGColumn] = value;
                }
            }

            public string VRIJEMEPROBNOGRADA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.VRIJEMEPROBNOGRADAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.VRIJEMEPROBNOGRADAColumn] = value;
                }
            }

            public string VRIJEMESTRUCNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.VRIJEMESTRUCNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.VRIJEMESTRUCNIColumn] = value;
                }
            }

            public string ZABRANANATJECANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.ZABRANANATJECANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.ZABRANANATJECANJAColumn] = value;
                }
            }

            public string ZAVRSENASKOLA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.ZAVRSENASKOLAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.ZAVRSENASKOLAColumn] = value;
                }
            }

            public bool ZBIRNINETO
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableRADNIK.ZBIRNINETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableRADNIK.ZBIRNINETOColumn] = value;
                }
            }

            public string ZRNBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNIK.ZRNBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNIK.ZRNBANKEColumn] = value;
                }
            }
        }

        public class RADNIKRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RADNIKDataSet.RADNIKRow eventRow;

            public RADNIKRowChangeEvent(RADNIKDataSet.RADNIKRow row, DataRowAction action)
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

            public RADNIKDataSet.RADNIKRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RADNIKRowChangeEventHandler(object sender, RADNIKDataSet.RADNIKRowChangeEvent e);
    }
}

