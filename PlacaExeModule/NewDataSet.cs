using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

[Serializable, DesignerCategory("code"), XmlSchemaProvider("GetTypedDataSetSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), ToolboxItem(true), HelpKeyword("vs.data.DataSet"), XmlRoot("NewDataSet")]
public class NewDataSet : DataSet
{
    private System.Data.SchemaSerializationMode _schemaSerializationMode;

    [DebuggerNonUserCode]
    public NewDataSet()
    {
        this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        this.BeginInit();
        this.InitClass();
        CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
        base.Tables.CollectionChanged += handler;
        base.Relations.CollectionChanged += handler;
        this.EndInit();
    }

    [DebuggerNonUserCode]
    protected NewDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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

    [DebuggerNonUserCode]
    public override DataSet Clone()
    {
        NewDataSet set = (NewDataSet) base.Clone();
        set.InitVars();
        set.SchemaSerializationMode = this.SchemaSerializationMode;
        return set;
    }

    [DebuggerNonUserCode]
    protected override XmlSchema GetSchemaSerializable()
    {
        MemoryStream w = new MemoryStream();
        this.WriteXmlSchema(new XmlTextWriter(w, null));
        w.Position = 0L;
        return XmlSchema.Read(new XmlTextReader(w), null);
    }

    [DebuggerNonUserCode]
    public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
    {
        NewDataSet set = new NewDataSet();
        XmlSchemaComplexType type2 = new XmlSchemaComplexType();
        XmlSchemaSequence sequence = new XmlSchemaSequence();
        XmlSchemaAny item = new XmlSchemaAny {
            Namespace = set.Namespace
        };
        sequence.Items.Add(item);
        type2.Particle = sequence;
        XmlSchema schemaSerializable = set.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
            MemoryStream stream = new MemoryStream();
            MemoryStream stream2 = new MemoryStream();
            try
            {
                XmlSchema current = null;
                schemaSerializable.Write(stream);
                IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    current = (XmlSchema) enumerator.Current;
                    stream2.SetLength(0L);
                    current.Write(stream2);
                    if (stream.Length == stream2.Length)
                    {
                        stream.Position = 0L;
                        stream2.Position = 0L;
                        while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                        {
                        }
                        if (stream.Position == stream.Length)
                        {
                            return type2;
                        }
                    }
                }
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (stream2 != null)
                {
                    stream2.Close();
                }
            }
        }
        xs.Add(schemaSerializable);
        return type2;
    }

    [DebuggerNonUserCode]
    private void InitClass()
    {
        this.DataSetName = "NewDataSet";
        this.Prefix = "";
        this.Namespace = "http://www.fina.hr/regzap/common-types/v0.5";
        this.Locale = new CultureInfo("");
        this.EnforceConstraints = true;
        this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
    }

    [DebuggerNonUserCode]
    protected override void InitializeDerivedDataSet()
    {
        this.BeginInit();
        this.InitClass();
        this.EndInit();
    }

    [DebuggerNonUserCode]
    internal void InitVars()
    {
        this.InitVars(true);
    }

    [DebuggerNonUserCode]
    internal void InitVars(bool initTable)
    {
    }

    [DebuggerNonUserCode]
    protected override void ReadXmlSerializable(XmlReader reader)
    {
        if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
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
            this.ReadXml(reader);
            this.InitVars();
        }
    }

    [DebuggerNonUserCode]
    private void SchemaChanged(object sender, CollectionChangeEventArgs e)
    {
        if (e.Action == CollectionChangeAction.Remove)
        {
            this.InitVars();
        }
    }

    [DebuggerNonUserCode]
    protected override bool ShouldSerializeRelations()
    {
        return false;
    }

    [DebuggerNonUserCode]
    protected override bool ShouldSerializeTables()
    {
        return false;
    }

    [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataRelationCollection Relations
    {
        get
        {
            return base.Relations;
        }
    }

    [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DebuggerNonUserCode]
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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode]
    public new DataTableCollection Tables
    {
        get
        {
            return base.Tables;
        }
    }
}

