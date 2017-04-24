﻿namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class SKUPPOREZAIDOPRINOSAFormSKUPPOREZAIDOPRINOSA2UserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDDOPRINOS")]
        private UltraLabel _label1IDDOPRINOS;
        [AccessedThroughProperty("label1IDVRSTADOPRINOS")]
        private UltraLabel _label1IDVRSTADOPRINOS;
        [AccessedThroughProperty("label1MAXDOPRINOS")]
        private UltraLabel _label1MAXDOPRINOS;
        [AccessedThroughProperty("label1MINDOPRINOS")]
        private UltraLabel _label1MINDOPRINOS;
        [AccessedThroughProperty("label1MODOPRINOS")]
        private UltraLabel _label1MODOPRINOS;
        [AccessedThroughProperty("label1MZDOPRINOS")]
        private UltraLabel _label1MZDOPRINOS;
        [AccessedThroughProperty("label1NAZIVDOPRINOS")]
        private UltraLabel _label1NAZIVDOPRINOS;
        [AccessedThroughProperty("label1NAZIVVRSTADOPRINOS")]
        private UltraLabel _label1NAZIVVRSTADOPRINOS;
        [AccessedThroughProperty("label1OPISPLACANJADOPRINOS")]
        private UltraLabel _label1OPISPLACANJADOPRINOS;
        [AccessedThroughProperty("label1PODOPRINOS")]
        private UltraLabel _label1PODOPRINOS;
        [AccessedThroughProperty("label1PRIMATELJDOPRINOS1")]
        private UltraLabel _label1PRIMATELJDOPRINOS1;
        [AccessedThroughProperty("label1PRIMATELJDOPRINOS2")]
        private UltraLabel _label1PRIMATELJDOPRINOS2;
        [AccessedThroughProperty("label1PZDOPRINOS")]
        private UltraLabel _label1PZDOPRINOS;
        [AccessedThroughProperty("label1SIFRAOPISAPLACANJADOPRINOS")]
        private UltraLabel _label1SIFRAOPISAPLACANJADOPRINOS;
        [AccessedThroughProperty("label1STOPA")]
        private UltraLabel _label1STOPA;
        [AccessedThroughProperty("label1VBDIDOPRINOS")]
        private UltraLabel _label1VBDIDOPRINOS;
        [AccessedThroughProperty("label1ZRNDOPRINOS")]
        private UltraLabel _label1ZRNDOPRINOS;
        [AccessedThroughProperty("labelIDVRSTADOPRINOS")]
        private UltraLabel _labelIDVRSTADOPRINOS;
        [AccessedThroughProperty("labelMAXDOPRINOS")]
        private UltraLabel _labelMAXDOPRINOS;
        [AccessedThroughProperty("labelMINDOPRINOS")]
        private UltraLabel _labelMINDOPRINOS;
        [AccessedThroughProperty("labelMODOPRINOS")]
        private UltraLabel _labelMODOPRINOS;
        [AccessedThroughProperty("labelMZDOPRINOS")]
        private UltraLabel _labelMZDOPRINOS;
        [AccessedThroughProperty("labelNAZIVDOPRINOS")]
        private UltraLabel _labelNAZIVDOPRINOS;
        [AccessedThroughProperty("labelNAZIVVRSTADOPRINOS")]
        private UltraLabel _labelNAZIVVRSTADOPRINOS;
        [AccessedThroughProperty("labelOPISPLACANJADOPRINOS")]
        private UltraLabel _labelOPISPLACANJADOPRINOS;
        [AccessedThroughProperty("labelPODOPRINOS")]
        private UltraLabel _labelPODOPRINOS;
        [AccessedThroughProperty("labelPRIMATELJDOPRINOS1")]
        private UltraLabel _labelPRIMATELJDOPRINOS1;
        [AccessedThroughProperty("labelPRIMATELJDOPRINOS2")]
        private UltraLabel _labelPRIMATELJDOPRINOS2;
        [AccessedThroughProperty("labelPZDOPRINOS")]
        private UltraLabel _labelPZDOPRINOS;
        [AccessedThroughProperty("labelSIFRAOPISAPLACANJADOPRINOS")]
        private UltraLabel _labelSIFRAOPISAPLACANJADOPRINOS;
        [AccessedThroughProperty("labelSTOPA")]
        private UltraLabel _labelSTOPA;
        [AccessedThroughProperty("labelVBDIDOPRINOS")]
        private UltraLabel _labelVBDIDOPRINOS;
        [AccessedThroughProperty("labelZRNDOPRINOS")]
        private UltraLabel _labelZRNDOPRINOS;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDDOPRINOS")]
        private UltraNumericEditor _textIDDOPRINOS;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSKUPPOREZAIDOPRINOSA2;
        private IContainer components = null;
        private SKUPPOREZAIDOPRINOSADataSet dsSKUPPOREZAIDOPRINOSADataSet1;
        protected TableLayoutPanel layoutManagerformSKUPPOREZAIDOPRINOSA2;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SKUPPOREZAIDOPRINOSA2";
        private string m_FrameworkDescription = StringResources.SKUPPOREZAIDOPRINOSADescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        public SKUPPOREZAIDOPRINOSAFormSKUPPOREZAIDOPRINOSA2UserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("SKUPPOREZAIDOPRINOSA2AddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SKUPPOREZAIDOPRINOSA2AddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row) ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptDOPRINOSIDDOPRINOS(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.SKUPPOREZAIDOPRINOSAController.SelectDOPRINOSIDDOPRINOS(fillMethod, fillByRow);
            this.UpdateValuesDOPRINOSIDDOPRINOS(result);
        }

        private void CallViewDOPRINOSIDDOPRINOS(object sender, EventArgs e)
        {
            DataRow result = this.SKUPPOREZAIDOPRINOSAController.ShowDOPRINOSIDDOPRINOS(this.m_CurrentRow);
            this.UpdateValuesDOPRINOSIDDOPRINOS(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsSKUPPOREZAIDOPRINOSADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSKUPPOREZAIDOPRINOSA2.DataSource = this.SKUPPOREZAIDOPRINOSAController.DataSet;
            this.dsSKUPPOREZAIDOPRINOSADataSet1 = this.SKUPPOREZAIDOPRINOSAController.DataSet;
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            this.m_BaseMethods.ContextMenu1PopupBase(this.contextMenu1, this.m_CurrentRow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EndEditCurrentRow()
        {
        }

        public void Initialize(DeklaritMode mode, DataRow parentRow, bool isCopy)
        {
            this.m_ParentRow = parentRow;
            this.dsSKUPPOREZAIDOPRINOSADataSet1 = (SKUPPOREZAIDOPRINOSADataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceSKUPPOREZAIDOPRINOSA2.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsSKUPPOREZAIDOPRINOSADataSet1.Tables["SKUPPOREZAIDOPRINOSA2"]);
            this.bindingSourceSKUPPOREZAIDOPRINOSA2.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SKUPPOREZAIDOPRINOSA", this.m_Mode, this.dsSKUPPOREZAIDOPRINOSADataSet1, this.dsSKUPPOREZAIDOPRINOSADataSet1.SKUPPOREZAIDOPRINOSA2.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding2 = new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "MINDOPRINOS", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelMINDOPRINOS.DataBindings["Text"] != null)
            {
                this.labelMINDOPRINOS.DataBindings.Remove(this.labelMINDOPRINOS.DataBindings["Text"]);
            }
            this.labelMINDOPRINOS.DataBindings.Add(binding2);
            Binding binding = new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "MAXDOPRINOS", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelMAXDOPRINOS.DataBindings["Text"] != null)
            {
                this.labelMAXDOPRINOS.DataBindings.Remove(this.labelMAXDOPRINOS.DataBindings["Text"]);
            }
            this.labelMAXDOPRINOS.DataBindings.Add(binding);
            Binding binding3 = new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "STOPA", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelSTOPA.DataBindings["Text"] != null)
            {
                this.labelSTOPA.DataBindings.Remove(this.labelSTOPA.DataBindings["Text"]);
            }
            this.labelSTOPA.DataBindings.Add(binding3);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row) ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row;
                this.textIDDOPRINOS.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textIDDOPRINOS.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row) ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(SKUPPOREZAIDOPRINOSAFormSKUPPOREZAIDOPRINOSA2UserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSKUPPOREZAIDOPRINOSA2 = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSKUPPOREZAIDOPRINOSA2).BeginInit();
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2 = new TableLayoutPanel();
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SuspendLayout();
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.AutoSize = true;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Dock = DockStyle.Fill;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Size = size;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.ColumnCount = 2;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowCount = 0x12;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.label1IDDOPRINOS = new UltraLabel();
            this.textIDDOPRINOS = new UltraNumericEditor();
            this.label1NAZIVDOPRINOS = new UltraLabel();
            this.labelNAZIVDOPRINOS = new UltraLabel();
            this.label1IDVRSTADOPRINOS = new UltraLabel();
            this.labelIDVRSTADOPRINOS = new UltraLabel();
            this.label1NAZIVVRSTADOPRINOS = new UltraLabel();
            this.labelNAZIVVRSTADOPRINOS = new UltraLabel();
            this.label1MODOPRINOS = new UltraLabel();
            this.labelMODOPRINOS = new UltraLabel();
            this.label1PODOPRINOS = new UltraLabel();
            this.labelPODOPRINOS = new UltraLabel();
            this.label1MZDOPRINOS = new UltraLabel();
            this.labelMZDOPRINOS = new UltraLabel();
            this.label1PZDOPRINOS = new UltraLabel();
            this.labelPZDOPRINOS = new UltraLabel();
            this.label1PRIMATELJDOPRINOS1 = new UltraLabel();
            this.labelPRIMATELJDOPRINOS1 = new UltraLabel();
            this.label1PRIMATELJDOPRINOS2 = new UltraLabel();
            this.labelPRIMATELJDOPRINOS2 = new UltraLabel();
            this.label1SIFRAOPISAPLACANJADOPRINOS = new UltraLabel();
            this.labelSIFRAOPISAPLACANJADOPRINOS = new UltraLabel();
            this.label1OPISPLACANJADOPRINOS = new UltraLabel();
            this.labelOPISPLACANJADOPRINOS = new UltraLabel();
            this.label1VBDIDOPRINOS = new UltraLabel();
            this.labelVBDIDOPRINOS = new UltraLabel();
            this.label1ZRNDOPRINOS = new UltraLabel();
            this.labelZRNDOPRINOS = new UltraLabel();
            this.label1MINDOPRINOS = new UltraLabel();
            this.labelMINDOPRINOS = new UltraLabel();
            this.label1MAXDOPRINOS = new UltraLabel();
            this.labelMAXDOPRINOS = new UltraLabel();
            this.label1STOPA = new UltraLabel();
            this.labelSTOPA = new UltraLabel();
            ((ISupportInitialize) this.textIDDOPRINOS).BeginInit();
            this.dsSKUPPOREZAIDOPRINOSADataSet1 = new SKUPPOREZAIDOPRINOSADataSet();
            this.dsSKUPPOREZAIDOPRINOSADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSKUPPOREZAIDOPRINOSADataSet1.DataSetName = "dsSKUPPOREZAIDOPRINOSA";
            this.dsSKUPPOREZAIDOPRINOSADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSKUPPOREZAIDOPRINOSA2.DataSource = this.dsSKUPPOREZAIDOPRINOSADataSet1;
            this.bindingSourceSKUPPOREZAIDOPRINOSA2.DataMember = "SKUPPOREZAIDOPRINOSA2";
            ((ISupportInitialize) this.bindingSourceSKUPPOREZAIDOPRINOSA2).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDDOPRINOS.Location = point;
            this.label1IDDOPRINOS.Name = "label1IDDOPRINOS";
            this.label1IDDOPRINOS.TabIndex = 1;
            this.label1IDDOPRINOS.Tag = "labelIDDOPRINOS";
            this.label1IDDOPRINOS.Text = "Šifra doprinosa:";
            this.label1IDDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1IDDOPRINOS.AutoSize = true;
            this.label1IDDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1IDDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDDOPRINOS.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDDOPRINOS.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDDOPRINOS.ImageSize = size;
            this.label1IDDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1IDDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1IDDOPRINOS, 0, 0);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1IDDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1IDDOPRINOS, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(110, 0x17);
            this.label1IDDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDDOPRINOS.Location = point;
            this.textIDDOPRINOS.Name = "textIDDOPRINOS";
            this.textIDDOPRINOS.Tag = "IDDOPRINOS";
            this.textIDDOPRINOS.TabIndex = 0;
            this.textIDDOPRINOS.Anchor = AnchorStyles.Left;
            this.textIDDOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDDOPRINOS.ReadOnly = false;
            this.textIDDOPRINOS.PromptChar = ' ';
            this.textIDDOPRINOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDDOPRINOS.DataBindings.Add(new Binding("Value", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "IDDOPRINOS"));
            this.textIDDOPRINOS.NumericType = NumericType.Integer;
            this.textIDDOPRINOS.MaskInput = "{LOC}-nnnnnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonDOPRINOSIDDOPRINOS",
                Tag = "editorButtonDOPRINOSIDDOPRINOS",
                Text = "..."
            };
            this.textIDDOPRINOS.ButtonsRight.Add(button);
            this.textIDDOPRINOS.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptDOPRINOSIDDOPRINOS);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.textIDDOPRINOS, 1, 0);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.textIDDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.textIDDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textIDDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textIDDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVDOPRINOS.Location = point;
            this.label1NAZIVDOPRINOS.Name = "label1NAZIVDOPRINOS";
            this.label1NAZIVDOPRINOS.TabIndex = 1;
            this.label1NAZIVDOPRINOS.Tag = "labelNAZIVDOPRINOS";
            this.label1NAZIVDOPRINOS.Text = "Naziv doprinosa:";
            this.label1NAZIVDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVDOPRINOS.AutoSize = true;
            this.label1NAZIVDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1NAZIVDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1NAZIVDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1NAZIVDOPRINOS, 0, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1NAZIVDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1NAZIVDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x77, 0x17);
            this.label1NAZIVDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVDOPRINOS.Location = point;
            this.labelNAZIVDOPRINOS.Name = "labelNAZIVDOPRINOS";
            this.labelNAZIVDOPRINOS.Tag = "NAZIVDOPRINOS";
            this.labelNAZIVDOPRINOS.TabIndex = 0;
            this.labelNAZIVDOPRINOS.Anchor = AnchorStyles.Left;
            this.labelNAZIVDOPRINOS.BackColor = Color.Transparent;
            this.labelNAZIVDOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "NAZIVDOPRINOS"));
            this.labelNAZIVDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelNAZIVDOPRINOS, 1, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelNAZIVDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelNAZIVDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDVRSTADOPRINOS.Location = point;
            this.label1IDVRSTADOPRINOS.Name = "label1IDVRSTADOPRINOS";
            this.label1IDVRSTADOPRINOS.TabIndex = 1;
            this.label1IDVRSTADOPRINOS.Tag = "labelIDVRSTADOPRINOS";
            this.label1IDVRSTADOPRINOS.Text = "Šifra vrste doprinosa:";
            this.label1IDVRSTADOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1IDVRSTADOPRINOS.AutoSize = true;
            this.label1IDVRSTADOPRINOS.Anchor = AnchorStyles.Left;
            this.label1IDVRSTADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDVRSTADOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1IDVRSTADOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1IDVRSTADOPRINOS, 0, 2);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1IDVRSTADOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1IDVRSTADOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDVRSTADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDVRSTADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x94, 0x17);
            this.label1IDVRSTADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelIDVRSTADOPRINOS.Location = point;
            this.labelIDVRSTADOPRINOS.Name = "labelIDVRSTADOPRINOS";
            this.labelIDVRSTADOPRINOS.Tag = "IDVRSTADOPRINOS";
            this.labelIDVRSTADOPRINOS.TabIndex = 0;
            this.labelIDVRSTADOPRINOS.Anchor = AnchorStyles.Left;
            this.labelIDVRSTADOPRINOS.BackColor = Color.Transparent;
            this.labelIDVRSTADOPRINOS.Appearance.TextHAlign = HAlign.Left;
            this.labelIDVRSTADOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "IDVRSTADOPRINOS"));
            this.labelIDVRSTADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelIDVRSTADOPRINOS, 1, 2);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelIDVRSTADOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelIDVRSTADOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelIDVRSTADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.labelIDVRSTADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.labelIDVRSTADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVVRSTADOPRINOS.Location = point;
            this.label1NAZIVVRSTADOPRINOS.Name = "label1NAZIVVRSTADOPRINOS";
            this.label1NAZIVVRSTADOPRINOS.TabIndex = 1;
            this.label1NAZIVVRSTADOPRINOS.Tag = "labelNAZIVVRSTADOPRINOS";
            this.label1NAZIVVRSTADOPRINOS.Text = "Naziv vrste doprinosa:";
            this.label1NAZIVVRSTADOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVVRSTADOPRINOS.AutoSize = true;
            this.label1NAZIVVRSTADOPRINOS.Anchor = AnchorStyles.Left;
            this.label1NAZIVVRSTADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVVRSTADOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1NAZIVVRSTADOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1NAZIVVRSTADOPRINOS, 0, 3);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1NAZIVVRSTADOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1NAZIVVRSTADOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVVRSTADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVVRSTADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x99, 0x17);
            this.label1NAZIVVRSTADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVVRSTADOPRINOS.Location = point;
            this.labelNAZIVVRSTADOPRINOS.Name = "labelNAZIVVRSTADOPRINOS";
            this.labelNAZIVVRSTADOPRINOS.Tag = "NAZIVVRSTADOPRINOS";
            this.labelNAZIVVRSTADOPRINOS.TabIndex = 0;
            this.labelNAZIVVRSTADOPRINOS.Anchor = AnchorStyles.Left;
            this.labelNAZIVVRSTADOPRINOS.BackColor = Color.Transparent;
            this.labelNAZIVVRSTADOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "NAZIVVRSTADOPRINOS"));
            this.labelNAZIVVRSTADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelNAZIVVRSTADOPRINOS, 1, 3);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelNAZIVVRSTADOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelNAZIVVRSTADOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVVRSTADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVVRSTADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVVRSTADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MODOPRINOS.Location = point;
            this.label1MODOPRINOS.Name = "label1MODOPRINOS";
            this.label1MODOPRINOS.TabIndex = 1;
            this.label1MODOPRINOS.Tag = "labelMODOPRINOS";
            this.label1MODOPRINOS.Text = "Model odobrenja doprinosa:";
            this.label1MODOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1MODOPRINOS.AutoSize = true;
            this.label1MODOPRINOS.Anchor = AnchorStyles.Left;
            this.label1MODOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1MODOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1MODOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1MODOPRINOS, 0, 4);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1MODOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1MODOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MODOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MODOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0xbd, 0x17);
            this.label1MODOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelMODOPRINOS.Location = point;
            this.labelMODOPRINOS.Name = "labelMODOPRINOS";
            this.labelMODOPRINOS.Tag = "MODOPRINOS";
            this.labelMODOPRINOS.TabIndex = 0;
            this.labelMODOPRINOS.Anchor = AnchorStyles.Left;
            this.labelMODOPRINOS.BackColor = Color.Transparent;
            this.labelMODOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "MODOPRINOS"));
            this.labelMODOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelMODOPRINOS, 1, 4);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelMODOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelMODOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelMODOPRINOS.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.labelMODOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.labelMODOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PODOPRINOS.Location = point;
            this.label1PODOPRINOS.Name = "label1PODOPRINOS";
            this.label1PODOPRINOS.TabIndex = 1;
            this.label1PODOPRINOS.Tag = "labelPODOPRINOS";
            this.label1PODOPRINOS.Text = "Poziv odobrenja doprinosa:";
            this.label1PODOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1PODOPRINOS.AutoSize = true;
            this.label1PODOPRINOS.Anchor = AnchorStyles.Left;
            this.label1PODOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1PODOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1PODOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1PODOPRINOS, 0, 5);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1PODOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1PODOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PODOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PODOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0xb8, 0x17);
            this.label1PODOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPODOPRINOS.Location = point;
            this.labelPODOPRINOS.Name = "labelPODOPRINOS";
            this.labelPODOPRINOS.Tag = "PODOPRINOS";
            this.labelPODOPRINOS.TabIndex = 0;
            this.labelPODOPRINOS.Anchor = AnchorStyles.Left;
            this.labelPODOPRINOS.BackColor = Color.Transparent;
            this.labelPODOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "PODOPRINOS"));
            this.labelPODOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelPODOPRINOS, 1, 5);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelPODOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelPODOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPODOPRINOS.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.labelPODOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.labelPODOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MZDOPRINOS.Location = point;
            this.label1MZDOPRINOS.Name = "label1MZDOPRINOS";
            this.label1MZDOPRINOS.TabIndex = 1;
            this.label1MZDOPRINOS.Tag = "labelMZDOPRINOS";
            this.label1MZDOPRINOS.Text = "Model zaduženja doprinosa:";
            this.label1MZDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1MZDOPRINOS.AutoSize = true;
            this.label1MZDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1MZDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1MZDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1MZDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1MZDOPRINOS, 0, 6);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1MZDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1MZDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MZDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MZDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0xbd, 0x17);
            this.label1MZDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelMZDOPRINOS.Location = point;
            this.labelMZDOPRINOS.Name = "labelMZDOPRINOS";
            this.labelMZDOPRINOS.Tag = "MZDOPRINOS";
            this.labelMZDOPRINOS.TabIndex = 0;
            this.labelMZDOPRINOS.Anchor = AnchorStyles.Left;
            this.labelMZDOPRINOS.BackColor = Color.Transparent;
            this.labelMZDOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "MZDOPRINOS"));
            this.labelMZDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelMZDOPRINOS, 1, 6);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelMZDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelMZDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelMZDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.labelMZDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.labelMZDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PZDOPRINOS.Location = point;
            this.label1PZDOPRINOS.Name = "label1PZDOPRINOS";
            this.label1PZDOPRINOS.TabIndex = 1;
            this.label1PZDOPRINOS.Tag = "labelPZDOPRINOS";
            this.label1PZDOPRINOS.Text = "Poziv zaduženja doprinosa:";
            this.label1PZDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1PZDOPRINOS.AutoSize = true;
            this.label1PZDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1PZDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1PZDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1PZDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1PZDOPRINOS, 0, 7);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1PZDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1PZDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PZDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PZDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0xb8, 0x17);
            this.label1PZDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPZDOPRINOS.Location = point;
            this.labelPZDOPRINOS.Name = "labelPZDOPRINOS";
            this.labelPZDOPRINOS.Tag = "PZDOPRINOS";
            this.labelPZDOPRINOS.TabIndex = 0;
            this.labelPZDOPRINOS.Anchor = AnchorStyles.Left;
            this.labelPZDOPRINOS.BackColor = Color.Transparent;
            this.labelPZDOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "PZDOPRINOS"));
            this.labelPZDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelPZDOPRINOS, 1, 7);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelPZDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelPZDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPZDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.labelPZDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.labelPZDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJDOPRINOS1.Location = point;
            this.label1PRIMATELJDOPRINOS1.Name = "label1PRIMATELJDOPRINOS1";
            this.label1PRIMATELJDOPRINOS1.TabIndex = 1;
            this.label1PRIMATELJDOPRINOS1.Tag = "labelPRIMATELJDOPRINOS1";
            this.label1PRIMATELJDOPRINOS1.Text = "Primatelj doprinosa:";
            this.label1PRIMATELJDOPRINOS1.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJDOPRINOS1.AutoSize = true;
            this.label1PRIMATELJDOPRINOS1.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJDOPRINOS1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJDOPRINOS1.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJDOPRINOS1.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1PRIMATELJDOPRINOS1, 0, 8);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1PRIMATELJDOPRINOS1, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1PRIMATELJDOPRINOS1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJDOPRINOS1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJDOPRINOS1.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1PRIMATELJDOPRINOS1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPRIMATELJDOPRINOS1.Location = point;
            this.labelPRIMATELJDOPRINOS1.Name = "labelPRIMATELJDOPRINOS1";
            this.labelPRIMATELJDOPRINOS1.Tag = "PRIMATELJDOPRINOS1";
            this.labelPRIMATELJDOPRINOS1.TabIndex = 0;
            this.labelPRIMATELJDOPRINOS1.Anchor = AnchorStyles.Left;
            this.labelPRIMATELJDOPRINOS1.BackColor = Color.Transparent;
            this.labelPRIMATELJDOPRINOS1.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "PRIMATELJDOPRINOS1"));
            this.labelPRIMATELJDOPRINOS1.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelPRIMATELJDOPRINOS1, 1, 8);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelPRIMATELJDOPRINOS1, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelPRIMATELJDOPRINOS1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJDOPRINOS1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJDOPRINOS1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJDOPRINOS1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJDOPRINOS2.Location = point;
            this.label1PRIMATELJDOPRINOS2.Name = "label1PRIMATELJDOPRINOS2";
            this.label1PRIMATELJDOPRINOS2.TabIndex = 1;
            this.label1PRIMATELJDOPRINOS2.Tag = "labelPRIMATELJDOPRINOS2";
            this.label1PRIMATELJDOPRINOS2.Text = "Primatelj doprinosa (2):";
            this.label1PRIMATELJDOPRINOS2.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJDOPRINOS2.AutoSize = true;
            this.label1PRIMATELJDOPRINOS2.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJDOPRINOS2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJDOPRINOS2.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJDOPRINOS2.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1PRIMATELJDOPRINOS2, 0, 9);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1PRIMATELJDOPRINOS2, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1PRIMATELJDOPRINOS2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJDOPRINOS2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJDOPRINOS2.MinimumSize = size;
            size = new System.Drawing.Size(0xa4, 0x17);
            this.label1PRIMATELJDOPRINOS2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPRIMATELJDOPRINOS2.Location = point;
            this.labelPRIMATELJDOPRINOS2.Name = "labelPRIMATELJDOPRINOS2";
            this.labelPRIMATELJDOPRINOS2.Tag = "PRIMATELJDOPRINOS2";
            this.labelPRIMATELJDOPRINOS2.TabIndex = 0;
            this.labelPRIMATELJDOPRINOS2.Anchor = AnchorStyles.Left;
            this.labelPRIMATELJDOPRINOS2.BackColor = Color.Transparent;
            this.labelPRIMATELJDOPRINOS2.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "PRIMATELJDOPRINOS2"));
            this.labelPRIMATELJDOPRINOS2.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelPRIMATELJDOPRINOS2, 1, 9);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelPRIMATELJDOPRINOS2, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelPRIMATELJDOPRINOS2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJDOPRINOS2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJDOPRINOS2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJDOPRINOS2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOPISAPLACANJADOPRINOS.Location = point;
            this.label1SIFRAOPISAPLACANJADOPRINOS.Name = "label1SIFRAOPISAPLACANJADOPRINOS";
            this.label1SIFRAOPISAPLACANJADOPRINOS.TabIndex = 1;
            this.label1SIFRAOPISAPLACANJADOPRINOS.Tag = "labelSIFRAOPISAPLACANJADOPRINOS";
            this.label1SIFRAOPISAPLACANJADOPRINOS.Text = "Šifra opisa plaćanja doprinosa:";
            this.label1SIFRAOPISAPLACANJADOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPISAPLACANJADOPRINOS.AutoSize = true;
            this.label1SIFRAOPISAPLACANJADOPRINOS.Anchor = AnchorStyles.Left;
            this.label1SIFRAOPISAPLACANJADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOPISAPLACANJADOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOPISAPLACANJADOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1SIFRAOPISAPLACANJADOPRINOS, 0, 10);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1SIFRAOPISAPLACANJADOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1SIFRAOPISAPLACANJADOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOPISAPLACANJADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOPISAPLACANJADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0xce, 0x17);
            this.label1SIFRAOPISAPLACANJADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelSIFRAOPISAPLACANJADOPRINOS.Location = point;
            this.labelSIFRAOPISAPLACANJADOPRINOS.Name = "labelSIFRAOPISAPLACANJADOPRINOS";
            this.labelSIFRAOPISAPLACANJADOPRINOS.Tag = "SIFRAOPISAPLACANJADOPRINOS";
            this.labelSIFRAOPISAPLACANJADOPRINOS.TabIndex = 0;
            this.labelSIFRAOPISAPLACANJADOPRINOS.Anchor = AnchorStyles.Left;
            this.labelSIFRAOPISAPLACANJADOPRINOS.BackColor = Color.Transparent;
            this.labelSIFRAOPISAPLACANJADOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "SIFRAOPISAPLACANJADOPRINOS"));
            this.labelSIFRAOPISAPLACANJADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelSIFRAOPISAPLACANJADOPRINOS, 1, 10);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelSIFRAOPISAPLACANJADOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelSIFRAOPISAPLACANJADOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelSIFRAOPISAPLACANJADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.labelSIFRAOPISAPLACANJADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.labelSIFRAOPISAPLACANJADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISPLACANJADOPRINOS.Location = point;
            this.label1OPISPLACANJADOPRINOS.Name = "label1OPISPLACANJADOPRINOS";
            this.label1OPISPLACANJADOPRINOS.TabIndex = 1;
            this.label1OPISPLACANJADOPRINOS.Tag = "labelOPISPLACANJADOPRINOS";
            this.label1OPISPLACANJADOPRINOS.Text = "Opis plaćanja doprinosa:";
            this.label1OPISPLACANJADOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1OPISPLACANJADOPRINOS.AutoSize = true;
            this.label1OPISPLACANJADOPRINOS.Anchor = AnchorStyles.Left;
            this.label1OPISPLACANJADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISPLACANJADOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1OPISPLACANJADOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1OPISPLACANJADOPRINOS, 0, 11);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1OPISPLACANJADOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1OPISPLACANJADOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISPLACANJADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISPLACANJADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0xa8, 0x17);
            this.label1OPISPLACANJADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOPISPLACANJADOPRINOS.Location = point;
            this.labelOPISPLACANJADOPRINOS.Name = "labelOPISPLACANJADOPRINOS";
            this.labelOPISPLACANJADOPRINOS.Tag = "OPISPLACANJADOPRINOS";
            this.labelOPISPLACANJADOPRINOS.TabIndex = 0;
            this.labelOPISPLACANJADOPRINOS.Anchor = AnchorStyles.Left;
            this.labelOPISPLACANJADOPRINOS.BackColor = Color.Transparent;
            this.labelOPISPLACANJADOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "OPISPLACANJADOPRINOS"));
            this.labelOPISPLACANJADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelOPISPLACANJADOPRINOS, 1, 11);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelOPISPLACANJADOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelOPISPLACANJADOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOPISPLACANJADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.labelOPISPLACANJADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.labelOPISPLACANJADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VBDIDOPRINOS.Location = point;
            this.label1VBDIDOPRINOS.Name = "label1VBDIDOPRINOS";
            this.label1VBDIDOPRINOS.TabIndex = 1;
            this.label1VBDIDOPRINOS.Tag = "labelVBDIDOPRINOS";
            this.label1VBDIDOPRINOS.Text = "VBDI za doprinos:";
            this.label1VBDIDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1VBDIDOPRINOS.AutoSize = true;
            this.label1VBDIDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1VBDIDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1VBDIDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1VBDIDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1VBDIDOPRINOS, 0, 12);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1VBDIDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1VBDIDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VBDIDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VBDIDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x7e, 0x17);
            this.label1VBDIDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelVBDIDOPRINOS.Location = point;
            this.labelVBDIDOPRINOS.Name = "labelVBDIDOPRINOS";
            this.labelVBDIDOPRINOS.Tag = "VBDIDOPRINOS";
            this.labelVBDIDOPRINOS.TabIndex = 0;
            this.labelVBDIDOPRINOS.Anchor = AnchorStyles.Left;
            this.labelVBDIDOPRINOS.BackColor = Color.Transparent;
            this.labelVBDIDOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "VBDIDOPRINOS"));
            this.labelVBDIDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelVBDIDOPRINOS, 1, 12);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelVBDIDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelVBDIDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelVBDIDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.labelVBDIDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.labelVBDIDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZRNDOPRINOS.Location = point;
            this.label1ZRNDOPRINOS.Name = "label1ZRNDOPRINOS";
            this.label1ZRNDOPRINOS.TabIndex = 1;
            this.label1ZRNDOPRINOS.Tag = "labelZRNDOPRINOS";
            this.label1ZRNDOPRINOS.Text = "Žiro račun za doprinos:";
            this.label1ZRNDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1ZRNDOPRINOS.AutoSize = true;
            this.label1ZRNDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1ZRNDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZRNDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1ZRNDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1ZRNDOPRINOS, 0, 13);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1ZRNDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1ZRNDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZRNDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZRNDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x9d, 0x17);
            this.label1ZRNDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZRNDOPRINOS.Location = point;
            this.labelZRNDOPRINOS.Name = "labelZRNDOPRINOS";
            this.labelZRNDOPRINOS.Tag = "ZRNDOPRINOS";
            this.labelZRNDOPRINOS.TabIndex = 0;
            this.labelZRNDOPRINOS.Anchor = AnchorStyles.Left;
            this.labelZRNDOPRINOS.BackColor = Color.Transparent;
            this.labelZRNDOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA2, "ZRNDOPRINOS"));
            this.labelZRNDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelZRNDOPRINOS, 1, 13);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelZRNDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelZRNDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZRNDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.labelZRNDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.labelZRNDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MINDOPRINOS.Location = point;
            this.label1MINDOPRINOS.Name = "label1MINDOPRINOS";
            this.label1MINDOPRINOS.TabIndex = 1;
            this.label1MINDOPRINOS.Tag = "labelMINDOPRINOS";
            this.label1MINDOPRINOS.Text = "Minimalna osnovica za obračun doprinosa:";
            this.label1MINDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1MINDOPRINOS.AutoSize = true;
            this.label1MINDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1MINDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1MINDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1MINDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1MINDOPRINOS, 0, 14);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1MINDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1MINDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MINDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MINDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x116, 0x17);
            this.label1MINDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelMINDOPRINOS.Location = point;
            this.labelMINDOPRINOS.Name = "labelMINDOPRINOS";
            this.labelMINDOPRINOS.Tag = "MINDOPRINOS";
            this.labelMINDOPRINOS.TabIndex = 0;
            this.labelMINDOPRINOS.Anchor = AnchorStyles.Left;
            this.labelMINDOPRINOS.BackColor = Color.Transparent;
            this.labelMINDOPRINOS.Appearance.TextHAlign = HAlign.Left;
            this.labelMINDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelMINDOPRINOS, 1, 14);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelMINDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelMINDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelMINDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelMINDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelMINDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MAXDOPRINOS.Location = point;
            this.label1MAXDOPRINOS.Name = "label1MAXDOPRINOS";
            this.label1MAXDOPRINOS.TabIndex = 1;
            this.label1MAXDOPRINOS.Tag = "labelMAXDOPRINOS";
            this.label1MAXDOPRINOS.Text = "Maksimalna osnovica za obračun doprinosa:";
            this.label1MAXDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1MAXDOPRINOS.AutoSize = true;
            this.label1MAXDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1MAXDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1MAXDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1MAXDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1MAXDOPRINOS, 0, 15);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1MAXDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1MAXDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MAXDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MAXDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x120, 0x17);
            this.label1MAXDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelMAXDOPRINOS.Location = point;
            this.labelMAXDOPRINOS.Name = "labelMAXDOPRINOS";
            this.labelMAXDOPRINOS.Tag = "MAXDOPRINOS";
            this.labelMAXDOPRINOS.TabIndex = 0;
            this.labelMAXDOPRINOS.Anchor = AnchorStyles.Left;
            this.labelMAXDOPRINOS.BackColor = Color.Transparent;
            this.labelMAXDOPRINOS.Appearance.TextHAlign = HAlign.Left;
            this.labelMAXDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelMAXDOPRINOS, 1, 15);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelMAXDOPRINOS, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelMAXDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelMAXDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelMAXDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelMAXDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1STOPA.Location = point;
            this.label1STOPA.Name = "label1STOPA";
            this.label1STOPA.TabIndex = 1;
            this.label1STOPA.Tag = "labelSTOPA";
            this.label1STOPA.Text = "STOPA:";
            this.label1STOPA.StyleSetName = "FieldUltraLabel";
            this.label1STOPA.AutoSize = true;
            this.label1STOPA.Anchor = AnchorStyles.Left;
            this.label1STOPA.Appearance.TextVAlign = VAlign.Middle;
            this.label1STOPA.Appearance.ForeColor = Color.Black;
            this.label1STOPA.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.label1STOPA, 0, 0x10);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.label1STOPA, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.label1STOPA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1STOPA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1STOPA.MinimumSize = size;
            size = new System.Drawing.Size(60, 0x17);
            this.label1STOPA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelSTOPA.Location = point;
            this.labelSTOPA.Name = "labelSTOPA";
            this.labelSTOPA.Tag = "STOPA";
            this.labelSTOPA.TabIndex = 0;
            this.labelSTOPA.Anchor = AnchorStyles.Left;
            this.labelSTOPA.BackColor = Color.Transparent;
            this.labelSTOPA.Appearance.TextHAlign = HAlign.Left;
            this.labelSTOPA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.Controls.Add(this.labelSTOPA, 1, 0x10);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.labelSTOPA, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.labelSTOPA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelSTOPA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.labelSTOPA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.labelSTOPA.Size = size;
            this.Controls.Add(this.layoutManagerformSKUPPOREZAIDOPRINOSA2);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSKUPPOREZAIDOPRINOSA2;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "SKUPPOREZAIDOPRINOSAFormSKUPPOREZAIDOPRINOSA2UserControl";
            this.Text = " Doprinosi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SKUPPOREZAIDOPRINOSAFormUserControl_Load);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.ResumeLayout(false);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA2.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSKUPPOREZAIDOPRINOSA2).EndInit();
            ((ISupportInitialize) this.textIDDOPRINOS).EndInit();
            this.dsSKUPPOREZAIDOPRINOSADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SKUPPOREZAIDOPRINOSAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSKUPPOREZAIDOPRINOSA2, this.SKUPPOREZAIDOPRINOSAController.WorkItem, this))
            {
                return false;
            }
            this.EndEditCurrentRow();
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void Localize()
        {
            this.label1IDDOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSAIDDOPRINOSDescription;
            this.label1NAZIVDOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSANAZIVDOPRINOSDescription;
            this.label1IDVRSTADOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSAIDVRSTADOPRINOSDescription;
            this.label1NAZIVVRSTADOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSANAZIVVRSTADOPRINOSDescription;
            this.label1MODOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSAMODOPRINOSDescription;
            this.label1PODOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSAPODOPRINOSDescription;
            this.label1MZDOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSAMZDOPRINOSDescription;
            this.label1PZDOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSAPZDOPRINOSDescription;
            this.label1PRIMATELJDOPRINOS1.Text = StringResources.SKUPPOREZAIDOPRINOSAPRIMATELJDOPRINOS1Description;
            this.label1PRIMATELJDOPRINOS2.Text = StringResources.SKUPPOREZAIDOPRINOSAPRIMATELJDOPRINOS2Description;
            this.label1SIFRAOPISAPLACANJADOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSASIFRAOPISAPLACANJADOPRINOSDescription;
            this.label1OPISPLACANJADOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSAOPISPLACANJADOPRINOSDescription;
            this.label1VBDIDOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSAVBDIDOPRINOSDescription;
            this.label1ZRNDOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSAZRNDOPRINOSDescription;
            this.label1MINDOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSAMINDOPRINOSDescription;
            this.label1MAXDOPRINOS.Text = StringResources.SKUPPOREZAIDOPRINOSAMAXDOPRINOSDescription;
            this.label1STOPA.Text = StringResources.SKUPPOREZAIDOPRINOSASTOPADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewRADNIK")]
        public void NewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SKUPPOREZAIDOPRINOSAController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.SKUPPOREZAIDOPRINOSAController.WorkItem.Items.Contains("SKUPPOREZAIDOPRINOSA2|SKUPPOREZAIDOPRINOSA2"))
            {
                this.SKUPPOREZAIDOPRINOSAController.WorkItem.Items.Add(this.bindingSourceSKUPPOREZAIDOPRINOSA2, "SKUPPOREZAIDOPRINOSA2|SKUPPOREZAIDOPRINOSA2");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("SKUPPOREZAIDOPRINOSA2SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDDOPRINOS.Focus();
        }

        private void SetNullItem_Click(object sender, EventArgs e)
        {
            this.m_BaseMethods.SetNullItemClickBase(RuntimeHelpers.GetObjectValue(sender), this.m_CurrentRow);
        }

        private void SetSize()
        {
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void SKUPPOREZAIDOPRINOSAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.SKUPPOREZAIDOPRINOSASKUPPOREZAIDOPRINOSA2LevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void UpdateValuesDOPRINOSIDDOPRINOS(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["IDDOPRINOS"] = RuntimeHelpers.GetObjectValue(result["IDDOPRINOS"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(result["NAZIVDOPRINOS"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(result["MODOPRINOS"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(result["PODOPRINOS"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(result["MZDOPRINOS"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(result["PZDOPRINOS"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJDOPRINOS1"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJDOPRINOS2"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(result["SIFRAOPISAPLACANJADOPRINOS"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(result["OPISPLACANJADOPRINOS"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(result["VBDIDOPRINOS"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(result["ZRNDOPRINOS"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["MINDOPRINOS"] = RuntimeHelpers.GetObjectValue(result["MINDOPRINOS"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["MAXDOPRINOS"] = RuntimeHelpers.GetObjectValue(result["MAXDOPRINOS"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["STOPA"] = RuntimeHelpers.GetObjectValue(result["STOPA"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(result["IDVRSTADOPRINOS"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA2.Current).Row["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(result["NAZIVVRSTADOPRINOS"]);
                this.bindingSourceSKUPPOREZAIDOPRINOSA2.ResetCurrentItem();
            }
        }

        [LocalCommandHandler("ViewRADNIK")]
        public void ViewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SKUPPOREZAIDOPRINOSAController.ViewRADNIK(this.m_CurrentRow);
            }
        }

        private ContextMenu contextMenu1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._contextMenu1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._contextMenu1 = value;
            }
        }

        private ErrorProvider errorProvider1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._errorProvider1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._errorProvider1 = value;
            }
        }

        private ErrorProviderValidator errorProviderValidator1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._errorProviderValidator1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._errorProviderValidator1 = value;
            }
        }

        protected virtual UltraLabel label1IDDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1IDVRSTADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDVRSTADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDVRSTADOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1MAXDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MAXDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MAXDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1MINDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MINDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MINDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1MODOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MODOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MODOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1MZDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MZDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MZDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1NAZIVDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1NAZIVVRSTADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVVRSTADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVVRSTADOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1OPISPLACANJADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISPLACANJADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISPLACANJADOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1PODOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PODOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PODOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJDOPRINOS1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJDOPRINOS1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJDOPRINOS1 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJDOPRINOS2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJDOPRINOS2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJDOPRINOS2 = value;
            }
        }

        protected virtual UltraLabel label1PZDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PZDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PZDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOPISAPLACANJADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOPISAPLACANJADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOPISAPLACANJADOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1STOPA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1STOPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1STOPA = value;
            }
        }

        protected virtual UltraLabel label1VBDIDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VBDIDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VBDIDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1ZRNDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZRNDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZRNDOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelIDVRSTADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelIDVRSTADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelIDVRSTADOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelMAXDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelMAXDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelMAXDOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelMINDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelMINDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelMINDOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelMODOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelMODOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelMODOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelMZDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelMZDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelMZDOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelNAZIVDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVDOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelNAZIVVRSTADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVVRSTADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVVRSTADOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelOPISPLACANJADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOPISPLACANJADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOPISPLACANJADOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelPODOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPODOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPODOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJDOPRINOS1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJDOPRINOS1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJDOPRINOS1 = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJDOPRINOS2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJDOPRINOS2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJDOPRINOS2 = value;
            }
        }

        protected virtual UltraLabel labelPZDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPZDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPZDOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelSIFRAOPISAPLACANJADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelSIFRAOPISAPLACANJADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelSIFRAOPISAPLACANJADOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelSTOPA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelSTOPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelSTOPA = value;
            }
        }

        protected virtual UltraLabel labelVBDIDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelVBDIDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelVBDIDOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelZRNDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZRNDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZRNDOPRINOS = value;
            }
        }

        public DeklaritMode Mode
        {
            get
            {
                return this.m_Mode;
            }
            set
            {
                this.m_Mode = value;
            }
        }

        private MenuItem SetNullItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SetNullItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._SetNullItem = value;
            }
        }

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.SKUPPOREZAIDOPRINOSAController SKUPPOREZAIDOPRINOSAController { get; set; }

        protected virtual UltraNumericEditor textIDDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDDOPRINOS = value;
            }
        }

        private System.Windows.Forms.ToolTip toolTip1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._toolTip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._toolTip1 = value;
            }
        }
    }
}
