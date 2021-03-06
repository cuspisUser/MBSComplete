﻿namespace Placa
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
    public class V_DD_GODINE_ISPLATEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private V_DD_GODINE_ISPLATEDataTable tableV_DD_GODINE_ISPLATE;

        public V_DD_GODINE_ISPLATEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected V_DD_GODINE_ISPLATEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["V_DD_GODINE_ISPLATE"] != null)
                    {
                        this.Tables.Add(new V_DD_GODINE_ISPLATEDataTable(dataSet.Tables["V_DD_GODINE_ISPLATE"]));
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
            V_DD_GODINE_ISPLATEDataSet set = (V_DD_GODINE_ISPLATEDataSet) base.Clone();
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
            V_DD_GODINE_ISPLATEDataSet set = new V_DD_GODINE_ISPLATEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "V_DD_GODINE_ISPLATEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2106");
            this.ExtendedProperties.Add("DataSetName", "V_DD_GODINE_ISPLATEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IV_DD_GODINE_ISPLATEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "V_DD_GODINE_ISPLATE");
            this.ExtendedProperties.Add("ObjectDescription", "V_DD_GODINE_ISPLATE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_DD");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
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
            this.DataSetName = "V_DD_GODINE_ISPLATEDataSet";
            this.Namespace = "http://www.tempuri.org/V_DD_GODINE_ISPLATE";
            this.tableV_DD_GODINE_ISPLATE = new V_DD_GODINE_ISPLATEDataTable();
            this.Tables.Add(this.tableV_DD_GODINE_ISPLATE);
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
            this.tableV_DD_GODINE_ISPLATE = (V_DD_GODINE_ISPLATEDataTable) this.Tables["V_DD_GODINE_ISPLATE"];
            if (initTable && (this.tableV_DD_GODINE_ISPLATE != null))
            {
                this.tableV_DD_GODINE_ISPLATE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["V_DD_GODINE_ISPLATE"] != null)
                {
                    this.Tables.Add(new V_DD_GODINE_ISPLATEDataTable(dataSet.Tables["V_DD_GODINE_ISPLATE"]));
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

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        private bool ShouldSerializeV_DD_GODINE_ISPLATE()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public V_DD_GODINE_ISPLATEDataTable V_DD_GODINE_ISPLATE
        {
            get
            {
                return this.tableV_DD_GODINE_ISPLATE;
            }
        }

        [Serializable]
        public class V_DD_GODINE_ISPLATEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnGODINAISPLATE;

            public event V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERowChangeEventHandler V_DD_GODINE_ISPLATERowChanged;

            public event V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERowChangeEventHandler V_DD_GODINE_ISPLATERowChanging;

            public event V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERowChangeEventHandler V_DD_GODINE_ISPLATERowDeleted;

            public event V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERowChangeEventHandler V_DD_GODINE_ISPLATERowDeleting;

            public V_DD_GODINE_ISPLATEDataTable()
            {
                this.TableName = "V_DD_GODINE_ISPLATE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal V_DD_GODINE_ISPLATEDataTable(DataTable table) : base(table.TableName)
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

            protected V_DD_GODINE_ISPLATEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddV_DD_GODINE_ISPLATERow(V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow row)
            {
                this.Rows.Add(row);
            }

            public V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow AddV_DD_GODINE_ISPLATERow(string gODINAISPLATE)
            {
                V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow row = (V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow) this.NewRow();
                row.ItemArray = new object[] { gODINAISPLATE };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATEDataTable table = (V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                V_DD_GODINE_ISPLATEDataSet set = new V_DD_GODINE_ISPLATEDataSet();
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
                this.columnGODINAISPLATE = new DataColumn("GODINAISPLATE", typeof(string), "", MappingType.Element);
                this.columnGODINAISPLATE.Caption = "Godina isplate";
                this.columnGODINAISPLATE.MaxLength = 4;
                this.columnGODINAISPLATE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnGODINAISPLATE.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINAISPLATE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnGODINAISPLATE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Description", "Godina isplate");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Length", "4");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINAISPLATE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnGODINAISPLATE.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.InternalName", "GODINAISPLATE");
                this.Columns.Add(this.columnGODINAISPLATE);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "V_DD_GODINE_ISPLATE");
                this.ExtendedProperties.Add("Description", "VW_DD_GODINE_ISPLATE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnGODINAISPLATE = this.Columns["GODINAISPLATE"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow(builder);
            }

            public V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow NewV_DD_GODINE_ISPLATERow()
            {
                return (V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.V_DD_GODINE_ISPLATERowChanged != null)
                {
                    V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERowChangeEventHandler handler = this.V_DD_GODINE_ISPLATERowChanged;
                    if (handler != null)
                    {
                        handler(this, new V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERowChangeEvent((V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.V_DD_GODINE_ISPLATERowChanging != null)
                {
                    V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERowChangeEventHandler handler = this.V_DD_GODINE_ISPLATERowChanging;
                    if (handler != null)
                    {
                        handler(this, new V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERowChangeEvent((V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.V_DD_GODINE_ISPLATERowDeleted != null)
                {
                    V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERowChangeEventHandler handler = this.V_DD_GODINE_ISPLATERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERowChangeEvent((V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.V_DD_GODINE_ISPLATERowDeleting != null)
                {
                    V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERowChangeEventHandler handler = this.V_DD_GODINE_ISPLATERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERowChangeEvent((V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveV_DD_GODINE_ISPLATERow(V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow row)
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

            public DataColumn GODINAISPLATEColumn
            {
                get
                {
                    return this.columnGODINAISPLATE;
                }
            }

            public V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow this[int index]
            {
                get
                {
                    return (V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow) this.Rows[index];
                }
            }
        }

        public class V_DD_GODINE_ISPLATERow : DataRow
        {
            private V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATEDataTable tableV_DD_GODINE_ISPLATE;

            internal V_DD_GODINE_ISPLATERow(DataRowBuilder rb) : base(rb)
            {
                this.tableV_DD_GODINE_ISPLATE = (V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATEDataTable) this.Table;
            }

            public bool IsGODINAISPLATENull()
            {
                return this.IsNull(this.tableV_DD_GODINE_ISPLATE.GODINAISPLATEColumn);
            }

            public void SetGODINAISPLATENull()
            {
                this[this.tableV_DD_GODINE_ISPLATE.GODINAISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string GODINAISPLATE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableV_DD_GODINE_ISPLATE.GODINAISPLATEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value GODINAISPLATE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableV_DD_GODINE_ISPLATE.GODINAISPLATEColumn] = value;
                }
            }
        }

        public class V_DD_GODINE_ISPLATERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow eventRow;

            public V_DD_GODINE_ISPLATERowChangeEvent(V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow row, DataRowAction action)
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

            public V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void V_DD_GODINE_ISPLATERowChangeEventHandler(object sender, V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERowChangeEvent e);
    }
}

