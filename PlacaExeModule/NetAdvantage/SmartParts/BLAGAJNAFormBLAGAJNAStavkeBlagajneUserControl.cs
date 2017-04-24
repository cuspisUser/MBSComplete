namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic.CompilerServices;
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
    public class BLAGAJNAFormBLAGAJNAStavkeBlagajneUserControl : UserControl, IBusinessComponentUserControl
    {
        private BindingSource bindingSourceBLAGAJNAStavkeBlagajne;
        private BindingSource bindingSourceBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje;
        private IContainer components = null;
        private BLAGAJNADataSet dsBLAGAJNADataSet1;
        protected TableLayoutPanel layoutManagerformBLAGAJNAStavkeBlagajne;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "BLAGAJNAStavkeBlagajne";
        private string m_FrameworkDescription = StringResources.BLAGAJNADescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        public BLAGAJNAFormBLAGAJNAStavkeBlagajneUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("BLAGAJNAStavkeBlagajneAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("BLAGAJNAStavkeBlagajneAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) ((DataRowView) this.bindingSourceBLAGAJNAStavkeBlagajne.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void BLAGAJNAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.BLAGAJNABLAGAJNAStavkeBlagajneLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void CallPromptBLGVRSTEDOKIDBLGVRSTEDOK(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.Controller.SelectBLGVRSTEDOKIDBLGVRSTEDOK(fillMethod, fillByRow);
            this.UpdateValuesBLGVRSTEDOKIDBLGVRSTEDOK(result);
        }

        private void CallPromptGODINEblggodineIDGODINE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.Controller.SelectGODINEblggodineIDGODINE(fillMethod, fillByRow);
            this.UpdateValuesGODINEblggodineIDGODINE(result);
        }

        private void CallViewBLGVRSTEDOKIDBLGVRSTEDOK(object sender, EventArgs e)
        {
            DataRow result = this.Controller.ShowBLGVRSTEDOKIDBLGVRSTEDOK(this.m_CurrentRow);
            this.UpdateValuesBLGVRSTEDOKIDBLGVRSTEDOK(result);
        }

        private void CallViewGODINEblggodineIDGODINE(object sender, EventArgs e)
        {
            DataRow result = this.Controller.ShowGODINEblggodineIDGODINE(this.m_CurrentRow);
            this.UpdateValuesGODINEblggodineIDGODINE(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsBLAGAJNADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceBLAGAJNAStavkeBlagajne.DataSource = this.Controller.DataSet;
            this.dsBLAGAJNADataSet1 = this.Controller.DataSet;
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            this.m_BaseMethods.ContextMenu1PopupBase(this.contextMenu1, this.m_CurrentRow);
        }

        private void dg_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGridColumn column = e.Cell.Column;
            if (column.CellActivation == Activation.AllowEdit)
            {
                string str = Conversions.ToString(column.Tag);
            }
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
            this.dsBLAGAJNADataSet1 = (BLAGAJNADataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceBLAGAJNAStavkeBlagajne.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsBLAGAJNADataSet1.Tables["BLAGAJNAStavkeBlagajne"]);
            this.bindingSourceBLAGAJNAStavkeBlagajne.DataMember = "";
            this.bindingSourceBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.DataMember = "BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "BLAGAJNA", this.m_Mode, this.dsBLAGAJNADataSet1, this.dsBLAGAJNADataSet1.BLAGAJNAStavkeBlagajne.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceBLAGAJNAStavkeBlagajne, "BLGDATUMDOKUMENTA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerBLGDATUMDOKUMENTA.DataBindings["Text"] != null)
            {
                this.datePickerBLGDATUMDOKUMENTA.DataBindings.Remove(this.datePickerBLGDATUMDOKUMENTA.DataBindings["Text"]);
            }
            this.datePickerBLGDATUMDOKUMENTA.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) ((DataRowView) this.bindingSourceBLAGAJNAStavkeBlagajne.Current).Row;
                this.textIDBLGVRSTEDOK.ButtonsRight[0].Visible = false;
                this.textblggodineIDGODINE.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textIDBLGVRSTEDOK.ButtonsRight[0].Visible = true;
                this.textblggodineIDGODINE.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) ((DataRowView) this.bindingSourceBLAGAJNAStavkeBlagajne.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.SetNullItem = new System.Windows.Forms.MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSourceBLAGAJNAStavkeBlagajne = new System.Windows.Forms.BindingSource(this.components);
            this.dsBLAGAJNADataSet1 = new Placa.BLAGAJNADataSet();
            this.errorProviderValidator1 = new Deklarit.Win.ErrorProviderValidator(this.components);
            this.bindingSourceBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje = new System.Windows.Forms.BindingSource(this.components);
            this.layoutManagerformBLAGAJNAStavkeBlagajne = new System.Windows.Forms.TableLayoutPanel();
            this.label1IDBLGVRSTEDOK = new Infragistics.Win.Misc.UltraLabel();
            this.textIDBLGVRSTEDOK = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1blggodineIDGODINE = new Infragistics.Win.Misc.UltraLabel();
            this.textblggodineIDGODINE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1NAZIVVRSTEDOK = new Infragistics.Win.Misc.UltraLabel();
            this.labelNAZIVVRSTEDOK = new Infragistics.Win.Misc.UltraLabel();
            this.label1BLGBROJDOKUMENTA = new Infragistics.Win.Misc.UltraLabel();
            this.textBLGBROJDOKUMENTA = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1BLGDATUMDOKUMENTA = new Infragistics.Win.Misc.UltraLabel();
            this.datePickerBLGDATUMDOKUMENTA = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label1BLGSVRHA = new Infragistics.Win.Misc.UltraLabel();
            this.textBLGSVRHA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1BLGIZNOS = new Infragistics.Win.Misc.UltraLabel();
            this.textBLGIZNOS = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBLAGAJNAStavkeBlagajne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBLAGAJNADataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje)).BeginInit();
            this.layoutManagerformBLAGAJNAStavkeBlagajne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textIDBLGVRSTEDOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textblggodineIDGODINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBLGBROJDOKUMENTA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePickerBLGDATUMDOKUMENTA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBLGSVRHA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBLGIZNOS)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.SetNullItem});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // SetNullItem
            // 
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new System.EventHandler(this.SetNullItem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.bindingSourceBLAGAJNAStavkeBlagajne;
            // 
            // bindingSourceBLAGAJNAStavkeBlagajne
            // 
            this.bindingSourceBLAGAJNAStavkeBlagajne.DataMember = "BLAGAJNAStavkeBlagajne";
            this.bindingSourceBLAGAJNAStavkeBlagajne.DataSource = this.dsBLAGAJNADataSet1;
            // 
            // dsBLAGAJNADataSet1
            // 
            this.dsBLAGAJNADataSet1.DataSetName = "dsBLAGAJNA";
            this.dsBLAGAJNADataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // errorProviderValidator1
            // 
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.errorProviderValidator1.ToolTipProvider = null;
            // 
            // bindingSourceBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje
            // 
            this.bindingSourceBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.DataMember = "BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje";
            this.bindingSourceBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.DataSource = this.bindingSourceBLAGAJNAStavkeBlagajne;
            // 
            // layoutManagerformBLAGAJNAStavkeBlagajne
            // 
            this.layoutManagerformBLAGAJNAStavkeBlagajne.AutoSize = true;
            this.layoutManagerformBLAGAJNAStavkeBlagajne.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerformBLAGAJNAStavkeBlagajne.ColumnCount = 2;
            this.layoutManagerformBLAGAJNAStavkeBlagajne.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBLAGAJNAStavkeBlagajne.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.label1IDBLGVRSTEDOK, 0, 0);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.textIDBLGVRSTEDOK, 1, 0);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.label1blggodineIDGODINE, 0, 1);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.textblggodineIDGODINE, 1, 1);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.label1NAZIVVRSTEDOK, 0, 2);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.labelNAZIVVRSTEDOK, 1, 2);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.label1BLGBROJDOKUMENTA, 0, 3);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.textBLGBROJDOKUMENTA, 1, 3);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.label1BLGDATUMDOKUMENTA, 0, 4);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.datePickerBLGDATUMDOKUMENTA, 1, 4);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.label1BLGSVRHA, 0, 5);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.textBLGSVRHA, 1, 5);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.label1BLGIZNOS, 0, 6);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Controls.Add(this.textBLGIZNOS, 1, 6);
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerformBLAGAJNAStavkeBlagajne, "");
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Name = "layoutManagerformBLAGAJNAStavkeBlagajne";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerformBLAGAJNAStavkeBlagajne, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerformBLAGAJNAStavkeBlagajne, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerformBLAGAJNAStavkeBlagajne, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerformBLAGAJNAStavkeBlagajne, "");
            this.layoutManagerformBLAGAJNAStavkeBlagajne.RowCount = 8;
            this.layoutManagerformBLAGAJNAStavkeBlagajne.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBLAGAJNAStavkeBlagajne.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBLAGAJNAStavkeBlagajne.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBLAGAJNAStavkeBlagajne.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBLAGAJNAStavkeBlagajne.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBLAGAJNAStavkeBlagajne.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBLAGAJNAStavkeBlagajne.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBLAGAJNAStavkeBlagajne.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBLAGAJNAStavkeBlagajne.Size = new System.Drawing.Size(674, 169);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.TabIndex = 0;
            // 
            // label1IDBLGVRSTEDOK
            // 
            this.label1IDBLGVRSTEDOK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.TextVAlignAsString = "Middle";
            this.label1IDBLGVRSTEDOK.Appearance = appearance1;
            this.label1IDBLGVRSTEDOK.AutoSize = true;
            this.label1IDBLGVRSTEDOK.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IDBLGVRSTEDOK, "");
            this.label1IDBLGVRSTEDOK.ImageSize = new System.Drawing.Size(7, 10);
            this.label1IDBLGVRSTEDOK.Location = new System.Drawing.Point(3, 4);
            this.label1IDBLGVRSTEDOK.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IDBLGVRSTEDOK.Name = "label1IDBLGVRSTEDOK";
            this.errorProviderValidator1.SetRegularExpression(this.label1IDBLGVRSTEDOK, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IDBLGVRSTEDOK, "");
            this.errorProviderValidator1.SetRequired(this.label1IDBLGVRSTEDOK, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IDBLGVRSTEDOK, "");
            this.label1IDBLGVRSTEDOK.Size = new System.Drawing.Size(83, 14);
            this.label1IDBLGVRSTEDOK.StyleSetName = "FieldUltraLabel";
            this.label1IDBLGVRSTEDOK.TabIndex = 1;
            this.label1IDBLGVRSTEDOK.Tag = "labelIDBLGVRSTEDOK";
            this.label1IDBLGVRSTEDOK.Text = "Šifra vrste dok.:";
            // 
            // textIDBLGVRSTEDOK
            // 
            this.textIDBLGVRSTEDOK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIDBLGVRSTEDOK.ButtonsRight.Add(editorButton1);
            this.textIDBLGVRSTEDOK.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceBLAGAJNAStavkeBlagajne, "IDBLGVRSTEDOK", true));
            this.errorProviderValidator1.SetDisplayName(this.textIDBLGVRSTEDOK, "");
            this.textIDBLGVRSTEDOK.Location = new System.Drawing.Point(95, 1);
            this.textIDBLGVRSTEDOK.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textIDBLGVRSTEDOK.MaskInput = "{LOC}-nnnnn";
            this.textIDBLGVRSTEDOK.MinimumSize = new System.Drawing.Size(71, 22);
            this.textIDBLGVRSTEDOK.Name = "textIDBLGVRSTEDOK";
            this.textIDBLGVRSTEDOK.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textIDBLGVRSTEDOK, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIDBLGVRSTEDOK, "");
            this.errorProviderValidator1.SetRequired(this.textIDBLGVRSTEDOK, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIDBLGVRSTEDOK, "");
            this.textIDBLGVRSTEDOK.Size = new System.Drawing.Size(71, 22);
            this.textIDBLGVRSTEDOK.TabIndex = 0;
            this.textIDBLGVRSTEDOK.Tag = "IDBLGVRSTEDOK";
            this.textIDBLGVRSTEDOK.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.CallPromptBLGVRSTEDOKIDBLGVRSTEDOK);
            this.textIDBLGVRSTEDOK.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textIDBLGVRSTEDOK.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1blggodineIDGODINE
            // 
            this.label1blggodineIDGODINE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.TextVAlignAsString = "Middle";
            this.label1blggodineIDGODINE.Appearance = appearance2;
            this.label1blggodineIDGODINE.AutoSize = true;
            this.label1blggodineIDGODINE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1blggodineIDGODINE, "");
            this.label1blggodineIDGODINE.ImageSize = new System.Drawing.Size(7, 10);
            this.label1blggodineIDGODINE.Location = new System.Drawing.Point(3, 28);
            this.label1blggodineIDGODINE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1blggodineIDGODINE.Name = "label1blggodineIDGODINE";
            this.errorProviderValidator1.SetRegularExpression(this.label1blggodineIDGODINE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1blggodineIDGODINE, "");
            this.errorProviderValidator1.SetRequired(this.label1blggodineIDGODINE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1blggodineIDGODINE, "");
            this.label1blggodineIDGODINE.Size = new System.Drawing.Size(44, 14);
            this.label1blggodineIDGODINE.StyleSetName = "FieldUltraLabel";
            this.label1blggodineIDGODINE.TabIndex = 1;
            this.label1blggodineIDGODINE.Tag = "labelblggodineIDGODINE";
            this.label1blggodineIDGODINE.Text = "Godina:";
            // 
            // textblggodineIDGODINE
            // 
            this.textblggodineIDGODINE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textblggodineIDGODINE.ButtonsRight.Add(editorButton2);
            this.textblggodineIDGODINE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceBLAGAJNAStavkeBlagajne, "blggodineIDGODINE", true));
            this.errorProviderValidator1.SetDisplayName(this.textblggodineIDGODINE, "");
            this.textblggodineIDGODINE.Location = new System.Drawing.Point(95, 25);
            this.textblggodineIDGODINE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textblggodineIDGODINE.MaskInput = "{LOC}-nnnn";
            this.textblggodineIDGODINE.MinimumSize = new System.Drawing.Size(65, 22);
            this.textblggodineIDGODINE.Name = "textblggodineIDGODINE";
            this.textblggodineIDGODINE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textblggodineIDGODINE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textblggodineIDGODINE, "");
            this.errorProviderValidator1.SetRequired(this.textblggodineIDGODINE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textblggodineIDGODINE, "");
            this.textblggodineIDGODINE.Size = new System.Drawing.Size(65, 22);
            this.textblggodineIDGODINE.TabIndex = 0;
            this.textblggodineIDGODINE.Tag = "blggodineIDGODINE";
            this.textblggodineIDGODINE.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.CallPromptGODINEblggodineIDGODINE);
            this.textblggodineIDGODINE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textblggodineIDGODINE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1NAZIVVRSTEDOK
            // 
            this.label1NAZIVVRSTEDOK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.label1NAZIVVRSTEDOK.Appearance = appearance3;
            this.label1NAZIVVRSTEDOK.AutoSize = true;
            this.label1NAZIVVRSTEDOK.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1NAZIVVRSTEDOK, "");
            this.label1NAZIVVRSTEDOK.Location = new System.Drawing.Point(3, 53);
            this.label1NAZIVVRSTEDOK.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1NAZIVVRSTEDOK.Name = "label1NAZIVVRSTEDOK";
            this.errorProviderValidator1.SetRegularExpression(this.label1NAZIVVRSTEDOK, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1NAZIVVRSTEDOK, "");
            this.errorProviderValidator1.SetRequired(this.label1NAZIVVRSTEDOK, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1NAZIVVRSTEDOK, "");
            this.label1NAZIVVRSTEDOK.Size = new System.Drawing.Size(36, 14);
            this.label1NAZIVVRSTEDOK.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVVRSTEDOK.TabIndex = 1;
            this.label1NAZIVVRSTEDOK.Tag = "labelNAZIVVRSTEDOK";
            this.label1NAZIVVRSTEDOK.Text = "Naziv:";
            // 
            // labelNAZIVVRSTEDOK
            // 
            this.labelNAZIVVRSTEDOK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance4.TextVAlignAsString = "Middle";
            this.labelNAZIVVRSTEDOK.Appearance = appearance4;
            this.labelNAZIVVRSTEDOK.BackColorInternal = System.Drawing.Color.Transparent;
            this.labelNAZIVVRSTEDOK.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBLAGAJNAStavkeBlagajne, "NAZIVVRSTEDOK", true));
            this.errorProviderValidator1.SetDisplayName(this.labelNAZIVVRSTEDOK, "");
            this.labelNAZIVVRSTEDOK.Location = new System.Drawing.Point(95, 49);
            this.labelNAZIVVRSTEDOK.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.labelNAZIVVRSTEDOK.MinimumSize = new System.Drawing.Size(226, 22);
            this.labelNAZIVVRSTEDOK.Name = "labelNAZIVVRSTEDOK";
            this.errorProviderValidator1.SetRegularExpression(this.labelNAZIVVRSTEDOK, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.labelNAZIVVRSTEDOK, "");
            this.errorProviderValidator1.SetRequired(this.labelNAZIVVRSTEDOK, false);
            this.errorProviderValidator1.SetRequiredMessage(this.labelNAZIVVRSTEDOK, "");
            this.labelNAZIVVRSTEDOK.Size = new System.Drawing.Size(226, 22);
            this.labelNAZIVVRSTEDOK.TabIndex = 0;
            this.labelNAZIVVRSTEDOK.Tag = "NAZIVVRSTEDOK";
            // 
            // label1BLGBROJDOKUMENTA
            // 
            this.label1BLGBROJDOKUMENTA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.TextVAlignAsString = "Middle";
            this.label1BLGBROJDOKUMENTA.Appearance = appearance5;
            this.label1BLGBROJDOKUMENTA.AutoSize = true;
            this.label1BLGBROJDOKUMENTA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1BLGBROJDOKUMENTA, "");
            this.label1BLGBROJDOKUMENTA.ImageSize = new System.Drawing.Size(7, 10);
            this.label1BLGBROJDOKUMENTA.Location = new System.Drawing.Point(3, 77);
            this.label1BLGBROJDOKUMENTA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1BLGBROJDOKUMENTA.Name = "label1BLGBROJDOKUMENTA";
            this.errorProviderValidator1.SetRegularExpression(this.label1BLGBROJDOKUMENTA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1BLGBROJDOKUMENTA, "");
            this.errorProviderValidator1.SetRequired(this.label1BLGBROJDOKUMENTA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1BLGBROJDOKUMENTA, "");
            this.label1BLGBROJDOKUMENTA.Size = new System.Drawing.Size(87, 14);
            this.label1BLGBROJDOKUMENTA.StyleSetName = "FieldUltraLabel";
            this.label1BLGBROJDOKUMENTA.TabIndex = 1;
            this.label1BLGBROJDOKUMENTA.Tag = "labelBLGBROJDOKUMENTA";
            this.label1BLGBROJDOKUMENTA.Text = "Broj dokumenta:";
            // 
            // textBLGBROJDOKUMENTA
            // 
            this.textBLGBROJDOKUMENTA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBLGBROJDOKUMENTA.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceBLAGAJNAStavkeBlagajne, "BLGBROJDOKUMENTA", true));
            this.errorProviderValidator1.SetDisplayName(this.textBLGBROJDOKUMENTA, "");
            this.textBLGBROJDOKUMENTA.Location = new System.Drawing.Point(95, 74);
            this.textBLGBROJDOKUMENTA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textBLGBROJDOKUMENTA.MaskInput = "{LOC}-nnnnnnnn";
            this.textBLGBROJDOKUMENTA.MinimumSize = new System.Drawing.Size(72, 22);
            this.textBLGBROJDOKUMENTA.Name = "textBLGBROJDOKUMENTA";
            this.textBLGBROJDOKUMENTA.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textBLGBROJDOKUMENTA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textBLGBROJDOKUMENTA, "");
            this.errorProviderValidator1.SetRequired(this.textBLGBROJDOKUMENTA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textBLGBROJDOKUMENTA, "");
            this.textBLGBROJDOKUMENTA.Size = new System.Drawing.Size(72, 22);
            this.textBLGBROJDOKUMENTA.TabIndex = 0;
            this.textBLGBROJDOKUMENTA.Tag = "BLGBROJDOKUMENTA";
            this.textBLGBROJDOKUMENTA.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textBLGBROJDOKUMENTA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1BLGDATUMDOKUMENTA
            // 
            this.label1BLGDATUMDOKUMENTA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.label1BLGDATUMDOKUMENTA.Appearance = appearance6;
            this.label1BLGDATUMDOKUMENTA.AutoSize = true;
            this.label1BLGDATUMDOKUMENTA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1BLGDATUMDOKUMENTA, "");
            this.label1BLGDATUMDOKUMENTA.Location = new System.Drawing.Point(3, 101);
            this.label1BLGDATUMDOKUMENTA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1BLGDATUMDOKUMENTA.Name = "label1BLGDATUMDOKUMENTA";
            this.errorProviderValidator1.SetRegularExpression(this.label1BLGDATUMDOKUMENTA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1BLGDATUMDOKUMENTA, "");
            this.errorProviderValidator1.SetRequired(this.label1BLGDATUMDOKUMENTA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1BLGDATUMDOKUMENTA, "");
            this.label1BLGDATUMDOKUMENTA.Size = new System.Drawing.Size(41, 14);
            this.label1BLGDATUMDOKUMENTA.StyleSetName = "FieldUltraLabel";
            this.label1BLGDATUMDOKUMENTA.TabIndex = 1;
            this.label1BLGDATUMDOKUMENTA.Tag = "labelBLGDATUMDOKUMENTA";
            this.label1BLGDATUMDOKUMENTA.Text = "Datum:";
            // 
            // datePickerBLGDATUMDOKUMENTA
            // 
            this.datePickerBLGDATUMDOKUMENTA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorProviderValidator1.SetDisplayName(this.datePickerBLGDATUMDOKUMENTA, "");
            this.datePickerBLGDATUMDOKUMENTA.Location = new System.Drawing.Point(95, 98);
            this.datePickerBLGDATUMDOKUMENTA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.datePickerBLGDATUMDOKUMENTA.MinimumSize = new System.Drawing.Size(100, 22);
            this.datePickerBLGDATUMDOKUMENTA.Name = "datePickerBLGDATUMDOKUMENTA";
            this.errorProviderValidator1.SetRegularExpression(this.datePickerBLGDATUMDOKUMENTA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.datePickerBLGDATUMDOKUMENTA, "");
            this.errorProviderValidator1.SetRequired(this.datePickerBLGDATUMDOKUMENTA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.datePickerBLGDATUMDOKUMENTA, "");
            this.datePickerBLGDATUMDOKUMENTA.Size = new System.Drawing.Size(100, 22);
            this.datePickerBLGDATUMDOKUMENTA.TabIndex = 0;
            this.datePickerBLGDATUMDOKUMENTA.Tag = "BLGDATUMDOKUMENTA";
            this.datePickerBLGDATUMDOKUMENTA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1BLGSVRHA
            // 
            this.label1BLGSVRHA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.label1BLGSVRHA.Appearance = appearance7;
            this.label1BLGSVRHA.AutoSize = true;
            this.label1BLGSVRHA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1BLGSVRHA, "");
            this.label1BLGSVRHA.Location = new System.Drawing.Point(3, 125);
            this.label1BLGSVRHA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1BLGSVRHA.Name = "label1BLGSVRHA";
            this.errorProviderValidator1.SetRegularExpression(this.label1BLGSVRHA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1BLGSVRHA, "");
            this.errorProviderValidator1.SetRequired(this.label1BLGSVRHA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1BLGSVRHA, "");
            this.label1BLGSVRHA.Size = new System.Drawing.Size(37, 14);
            this.label1BLGSVRHA.StyleSetName = "FieldUltraLabel";
            this.label1BLGSVRHA.TabIndex = 1;
            this.label1BLGSVRHA.Tag = "labelBLGSVRHA";
            this.label1BLGSVRHA.Text = "Svrha:";
            // 
            // textBLGSVRHA
            // 
            this.textBLGSVRHA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBLGSVRHA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBLAGAJNAStavkeBlagajne, "BLGSVRHA", true));
            this.errorProviderValidator1.SetDisplayName(this.textBLGSVRHA, "");
            this.textBLGSVRHA.Location = new System.Drawing.Point(95, 122);
            this.textBLGSVRHA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textBLGSVRHA.MaxLength = 100;
            this.textBLGSVRHA.MinimumSize = new System.Drawing.Size(576, 22);
            this.textBLGSVRHA.Name = "textBLGSVRHA";
            this.errorProviderValidator1.SetRegularExpression(this.textBLGSVRHA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textBLGSVRHA, "");
            this.errorProviderValidator1.SetRequired(this.textBLGSVRHA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textBLGSVRHA, "");
            this.textBLGSVRHA.Size = new System.Drawing.Size(576, 22);
            this.textBLGSVRHA.TabIndex = 0;
            this.textBLGSVRHA.Tag = "BLGSVRHA";
            this.textBLGSVRHA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1BLGIZNOS
            // 
            this.label1BLGIZNOS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.label1BLGIZNOS.Appearance = appearance8;
            this.label1BLGIZNOS.AutoSize = true;
            this.label1BLGIZNOS.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1BLGIZNOS, "");
            this.label1BLGIZNOS.Location = new System.Drawing.Point(3, 149);
            this.label1BLGIZNOS.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1BLGIZNOS.Name = "label1BLGIZNOS";
            this.errorProviderValidator1.SetRegularExpression(this.label1BLGIZNOS, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1BLGIZNOS, "");
            this.errorProviderValidator1.SetRequired(this.label1BLGIZNOS, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1BLGIZNOS, "");
            this.label1BLGIZNOS.Size = new System.Drawing.Size(34, 14);
            this.label1BLGIZNOS.StyleSetName = "FieldUltraLabel";
            this.label1BLGIZNOS.TabIndex = 1;
            this.label1BLGIZNOS.Tag = "labelBLGIZNOS";
            this.label1BLGIZNOS.Text = "Iznos:";
            // 
            // textBLGIZNOS
            // 
            this.textBLGIZNOS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBLGIZNOS.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceBLAGAJNAStavkeBlagajne, "BLGIZNOS", true));
            this.errorProviderValidator1.SetDisplayName(this.textBLGIZNOS, "");
            this.textBLGIZNOS.Location = new System.Drawing.Point(95, 146);
            this.textBLGIZNOS.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textBLGIZNOS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textBLGIZNOS.MinimumSize = new System.Drawing.Size(102, 22);
            this.textBLGIZNOS.Name = "textBLGIZNOS";
            this.textBLGIZNOS.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textBLGIZNOS.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textBLGIZNOS, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textBLGIZNOS, "");
            this.errorProviderValidator1.SetRequired(this.textBLGIZNOS, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textBLGIZNOS, "");
            this.textBLGIZNOS.Size = new System.Drawing.Size(102, 22);
            this.textBLGIZNOS.TabIndex = 0;
            this.textBLGIZNOS.Tag = "BLGIZNOS";
            this.textBLGIZNOS.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textBLGIZNOS.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // BLAGAJNAFormBLAGAJNAStavkeBlagajneUserControl
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.layoutManagerformBLAGAJNAStavkeBlagajne);
            this.errorProviderValidator1.SetDisplayName(this, "");
            this.Name = "BLAGAJNAFormBLAGAJNAStavkeBlagajneUserControl";
            this.errorProviderValidator1.SetRegularExpression(this, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this, "");
            this.errorProviderValidator1.SetRequired(this, false);
            this.errorProviderValidator1.SetRequiredMessage(this, "");
            this.Size = new System.Drawing.Size(674, 169);
            this.Load += new System.EventHandler(this.BLAGAJNAFormUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBLAGAJNAStavkeBlagajne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBLAGAJNADataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje)).EndInit();
            this.layoutManagerformBLAGAJNAStavkeBlagajne.ResumeLayout(false);
            this.layoutManagerformBLAGAJNAStavkeBlagajne.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textIDBLGVRSTEDOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textblggodineIDGODINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBLGBROJDOKUMENTA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePickerBLGDATUMDOKUMENTA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBLGSVRHA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBLGIZNOS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool InValidState()
        {
            if ((this.Controller.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceBLAGAJNAStavkeBlagajne, this.Controller.WorkItem, this))
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
            this.label1IDBLGVRSTEDOK.Text = StringResources.BLAGAJNAIDBLGVRSTEDOKDescription;
            this.label1blggodineIDGODINE.Text = StringResources.BLAGAJNAblggodineIDGODINEDescription;
            this.label1NAZIVVRSTEDOK.Text = StringResources.BLAGAJNANAZIVVRSTEDOKDescription;
            this.label1BLGBROJDOKUMENTA.Text = StringResources.BLAGAJNABLGBROJDOKUMENTADescription;
            this.label1BLGDATUMDOKUMENTA.Text = StringResources.BLAGAJNABLGDATUMDOKUMENTADescription;
            this.label1BLGSVRHA.Text = StringResources.BLAGAJNABLGSVRHADescription;
            this.label1BLGIZNOS.Text = StringResources.BLAGAJNABLGIZNOSDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.Controller.WorkItem.Items.Contains("BLAGAJNAStavkeBlagajne|BLAGAJNAStavkeBlagajne"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceBLAGAJNAStavkeBlagajne, "BLAGAJNAStavkeBlagajne|BLAGAJNAStavkeBlagajne");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("BLAGAJNAStavkeBlagajneSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDBLGVRSTEDOK.Focus();
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

        private void UpdateValuesBLGVRSTEDOKIDBLGVRSTEDOK(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceBLAGAJNAStavkeBlagajne.Current).Row["IDBLGVRSTEDOK"] = RuntimeHelpers.GetObjectValue(result["IDBLGVRSTEDOK"]);
                ((DataRowView) this.bindingSourceBLAGAJNAStavkeBlagajne.Current).Row["NAZIVVRSTEDOK"] = RuntimeHelpers.GetObjectValue(result["NAZIVVRSTEDOK"]);
                this.bindingSourceBLAGAJNAStavkeBlagajne.ResetCurrentItem();
            }
        }

        private void UpdateValuesGODINEblggodineIDGODINE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceBLAGAJNAStavkeBlagajne.Current).Row["blggodineIDGODINE"] = RuntimeHelpers.GetObjectValue(result["IDGODINE"]);
                this.bindingSourceBLAGAJNAStavkeBlagajne.ResetCurrentItem();
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.BLAGAJNAController Controller { get; set; }

        private ContextMenu contextMenu1;

        private UltraDateTimeEditor datePickerBLGDATUMDOKUMENTA;

        private ErrorProvider errorProvider1;

        private ErrorProviderValidator errorProviderValidator1;

        private UltraLabel label1BLGBROJDOKUMENTA;

        private UltraLabel label1BLGDATUMDOKUMENTA;

        private UltraLabel label1blggodineIDGODINE;

        private UltraLabel label1BLGIZNOS;

        private UltraLabel label1BLGSVRHA;

        private UltraLabel label1IDBLGVRSTEDOK;

        private UltraLabel label1NAZIVVRSTEDOK;

        private UltraLabel labelNAZIVVRSTEDOK;

        public DeklaritMode Mode;

        private MenuItem SetNullItem;

        private UltraNumericEditor textBLGBROJDOKUMENTA;

        private UltraNumericEditor textblggodineIDGODINE;

        private UltraNumericEditor textBLGIZNOS;

        private UltraTextEditor textBLGSVRHA;

        private UltraNumericEditor textIDBLGVRSTEDOK;

        private System.Windows.Forms.ToolTip toolTip1;
    }
}

