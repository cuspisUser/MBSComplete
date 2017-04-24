namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Resources;
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
    public class OSNOVAOSIGURANJAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkRAZDOBLJESESMIJEPREKLAPATI")]
        private UltraCheckEditor _checkRAZDOBLJESESMIJEPREKLAPATI;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDOSNOVAOSIGURANJA")]
        private UltraLabel _label1IDOSNOVAOSIGURANJA;
        [AccessedThroughProperty("label1NAZIVOSNOVAOSIGURANJA")]
        private UltraLabel _label1NAZIVOSNOVAOSIGURANJA;
        [AccessedThroughProperty("label1RAZDOBLJESESMIJEPREKLAPATI")]
        private UltraLabel _label1RAZDOBLJESESMIJEPREKLAPATI;
        [AccessedThroughProperty("label1ZAMOOIDOSNOVAOSIGURANJA")]
        private UltraLabel _label1ZAMOOIDOSNOVAOSIGURANJA;
        [AccessedThroughProperty("label1ZAMOONAZIVOSNOVAOSIGURANJA")]
        private UltraLabel _label1ZAMOONAZIVOSNOVAOSIGURANJA;
        [AccessedThroughProperty("labelZAMOONAZIVOSNOVAOSIGURANJA")]
        private UltraLabel _labelZAMOONAZIVOSNOVAOSIGURANJA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDOSNOVAOSIGURANJA")]
        private UltraTextEditor _textIDOSNOVAOSIGURANJA;
        [AccessedThroughProperty("textNAZIVOSNOVAOSIGURANJA")]
        private UltraTextEditor _textNAZIVOSNOVAOSIGURANJA;
        [AccessedThroughProperty("textZAMOOIDOSNOVAOSIGURANJA")]
        private UltraTextEditor _textZAMOOIDOSNOVAOSIGURANJA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceOSNOVAOSIGURANJA;
        private IContainer components = null;
        private OSNOVAOSIGURANJADataSet dsOSNOVAOSIGURANJADataSet1;
        protected TableLayoutPanel layoutManagerformOSNOVAOSIGURANJA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OSNOVAOSIGURANJA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.OSNOVAOSIGURANJADescription;
        private DeklaritMode m_Mode;

        public OSNOVAOSIGURANJAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.OSNOVAOSIGURANJAController.SelectOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA(fillMethod, fillByRow);
            this.UpdateValuesOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA(result);
        }

        private void CallViewOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA(object sender, EventArgs e)
        {
            DataRow result = this.OSNOVAOSIGURANJAController.ShowOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA(this.m_CurrentRow);
            this.UpdateValuesOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA(result);
        }

        public void ChangeBinding()
        {
            this.bindingSourceOSNOVAOSIGURANJA.DataSource = this.OSNOVAOSIGURANJAController.DataSet;
            this.dsOSNOVAOSIGURANJADataSet1 = this.OSNOVAOSIGURANJAController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            this.m_BaseMethods.ContextMenu1PopupBase(this.contextMenu1, this.m_CurrentRow);
        }

        [LocalCommandHandler("DeleteInstance")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.dsOSNOVAOSIGURANJADataSet1.OSNOVAOSIGURANJA.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ((DataRow) enumerator.Current).Delete();
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                if (this.OSNOVAOSIGURANJAController.Update(this))
                {
                    this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
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

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OSNOVAOSIGURANJA", this.m_Mode, this.dsOSNOVAOSIGURANJADataSet1, this.dsOSNOVAOSIGURANJADataSet1.OSNOVAOSIGURANJA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("CheckState", this.bindingSourceOSNOVAOSIGURANJA, "RAZDOBLJESESMIJEPREKLAPATI", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkRAZDOBLJESESMIJEPREKLAPATI.DataBindings["CheckState"] != null)
            {
                this.checkRAZDOBLJESESMIJEPREKLAPATI.DataBindings.Remove(this.checkRAZDOBLJESESMIJEPREKLAPATI.DataBindings["CheckState"]);
            }
            this.checkRAZDOBLJESESMIJEPREKLAPATI.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsOSNOVAOSIGURANJADataSet1.OSNOVAOSIGURANJA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow) ((DataRowView) this.bindingSourceOSNOVAOSIGURANJA.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    this.m_BaseMethods.SetReadOnly(str, true);
                    this.m_BaseMethods.GetLabelControl(str).Visible = false;
                    this.m_BaseMethods.GetControl(str).Visible = false;
                }
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(OSNOVAOSIGURANJAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOSNOVAOSIGURANJA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOSNOVAOSIGURANJA).BeginInit();
            this.layoutManagerformOSNOVAOSIGURANJA = new TableLayoutPanel();
            this.layoutManagerformOSNOVAOSIGURANJA.SuspendLayout();
            this.layoutManagerformOSNOVAOSIGURANJA.AutoSize = true;
            this.layoutManagerformOSNOVAOSIGURANJA.Dock = DockStyle.Fill;
            this.layoutManagerformOSNOVAOSIGURANJA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOSNOVAOSIGURANJA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOSNOVAOSIGURANJA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOSNOVAOSIGURANJA.Size = size;
            this.layoutManagerformOSNOVAOSIGURANJA.ColumnCount = 2;
            this.layoutManagerformOSNOVAOSIGURANJA.RowCount = 6;
            this.layoutManagerformOSNOVAOSIGURANJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOSNOVAOSIGURANJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOSNOVAOSIGURANJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSNOVAOSIGURANJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSNOVAOSIGURANJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSNOVAOSIGURANJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSNOVAOSIGURANJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSNOVAOSIGURANJA.RowStyles.Add(new RowStyle());
            this.label1IDOSNOVAOSIGURANJA = new UltraLabel();
            this.textIDOSNOVAOSIGURANJA = new UltraTextEditor();
            this.label1NAZIVOSNOVAOSIGURANJA = new UltraLabel();
            this.textNAZIVOSNOVAOSIGURANJA = new UltraTextEditor();
            this.label1RAZDOBLJESESMIJEPREKLAPATI = new UltraLabel();
            this.checkRAZDOBLJESESMIJEPREKLAPATI = new UltraCheckEditor();
            this.label1ZAMOOIDOSNOVAOSIGURANJA = new UltraLabel();
            this.textZAMOOIDOSNOVAOSIGURANJA = new UltraTextEditor();
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA = new UltraLabel();
            this.labelZAMOONAZIVOSNOVAOSIGURANJA = new UltraLabel();
            ((ISupportInitialize) this.textIDOSNOVAOSIGURANJA).BeginInit();
            ((ISupportInitialize) this.textNAZIVOSNOVAOSIGURANJA).BeginInit();
            ((ISupportInitialize) this.textZAMOOIDOSNOVAOSIGURANJA).BeginInit();
            this.dsOSNOVAOSIGURANJADataSet1 = new OSNOVAOSIGURANJADataSet();
            this.dsOSNOVAOSIGURANJADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOSNOVAOSIGURANJADataSet1.DataSetName = "dsOSNOVAOSIGURANJA";
            this.dsOSNOVAOSIGURANJADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOSNOVAOSIGURANJA.DataSource = this.dsOSNOVAOSIGURANJADataSet1;
            this.bindingSourceOSNOVAOSIGURANJA.DataMember = "OSNOVAOSIGURANJA";
            ((ISupportInitialize) this.bindingSourceOSNOVAOSIGURANJA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDOSNOVAOSIGURANJA.Location = point;
            this.label1IDOSNOVAOSIGURANJA.Name = "label1IDOSNOVAOSIGURANJA";
            this.label1IDOSNOVAOSIGURANJA.TabIndex = 1;
            this.label1IDOSNOVAOSIGURANJA.Tag = "labelIDOSNOVAOSIGURANJA";
            this.label1IDOSNOVAOSIGURANJA.Text = "Šifra osnove osiguranja:";
            this.label1IDOSNOVAOSIGURANJA.StyleSetName = "FieldUltraLabel";
            this.label1IDOSNOVAOSIGURANJA.AutoSize = true;
            this.label1IDOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.label1IDOSNOVAOSIGURANJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOSNOVAOSIGURANJA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDOSNOVAOSIGURANJA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDOSNOVAOSIGURANJA.ImageSize = size;
            this.label1IDOSNOVAOSIGURANJA.Appearance.ForeColor = Color.Black;
            this.label1IDOSNOVAOSIGURANJA.BackColor = Color.Transparent;
            this.layoutManagerformOSNOVAOSIGURANJA.Controls.Add(this.label1IDOSNOVAOSIGURANJA, 0, 0);
            this.layoutManagerformOSNOVAOSIGURANJA.SetColumnSpan(this.label1IDOSNOVAOSIGURANJA, 1);
            this.layoutManagerformOSNOVAOSIGURANJA.SetRowSpan(this.label1IDOSNOVAOSIGURANJA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(0xa2, 0x17);
            this.label1IDOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOSNOVAOSIGURANJA.Location = point;
            this.textIDOSNOVAOSIGURANJA.Name = "textIDOSNOVAOSIGURANJA";
            this.textIDOSNOVAOSIGURANJA.Tag = "IDOSNOVAOSIGURANJA";
            this.textIDOSNOVAOSIGURANJA.TabIndex = 0;
            this.textIDOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.textIDOSNOVAOSIGURANJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.errorProviderValidator1.SetRequired(this.textIDOSNOVAOSIGURANJA, true);
            this.errorProviderValidator1.SetRequiredMessage(this.textIDOSNOVAOSIGURANJA, "Field Required ");
            this.textIDOSNOVAOSIGURANJA.ReadOnly = false;
            this.textIDOSNOVAOSIGURANJA.DataBindings.Add(new Binding("Text", this.bindingSourceOSNOVAOSIGURANJA, "IDOSNOVAOSIGURANJA"));
            this.textIDOSNOVAOSIGURANJA.MaxLength = 2;
            this.layoutManagerformOSNOVAOSIGURANJA.Controls.Add(this.textIDOSNOVAOSIGURANJA, 1, 0);
            this.layoutManagerformOSNOVAOSIGURANJA.SetColumnSpan(this.textIDOSNOVAOSIGURANJA, 1);
            this.layoutManagerformOSNOVAOSIGURANJA.SetRowSpan(this.textIDOSNOVAOSIGURANJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textIDOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textIDOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVOSNOVAOSIGURANJA.Location = point;
            this.label1NAZIVOSNOVAOSIGURANJA.Name = "label1NAZIVOSNOVAOSIGURANJA";
            this.label1NAZIVOSNOVAOSIGURANJA.TabIndex = 1;
            this.label1NAZIVOSNOVAOSIGURANJA.Tag = "labelNAZIVOSNOVAOSIGURANJA";
            this.label1NAZIVOSNOVAOSIGURANJA.Text = "Naziv osnove osiguranja:";
            this.label1NAZIVOSNOVAOSIGURANJA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVOSNOVAOSIGURANJA.AutoSize = true;
            this.label1NAZIVOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.label1NAZIVOSNOVAOSIGURANJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVOSNOVAOSIGURANJA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVOSNOVAOSIGURANJA.BackColor = Color.Transparent;
            this.layoutManagerformOSNOVAOSIGURANJA.Controls.Add(this.label1NAZIVOSNOVAOSIGURANJA, 0, 1);
            this.layoutManagerformOSNOVAOSIGURANJA.SetColumnSpan(this.label1NAZIVOSNOVAOSIGURANJA, 1);
            this.layoutManagerformOSNOVAOSIGURANJA.SetRowSpan(this.label1NAZIVOSNOVAOSIGURANJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(0xab, 0x17);
            this.label1NAZIVOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVOSNOVAOSIGURANJA.Location = point;
            this.textNAZIVOSNOVAOSIGURANJA.Name = "textNAZIVOSNOVAOSIGURANJA";
            this.textNAZIVOSNOVAOSIGURANJA.Tag = "NAZIVOSNOVAOSIGURANJA";
            this.textNAZIVOSNOVAOSIGURANJA.TabIndex = 0;
            this.textNAZIVOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.textNAZIVOSNOVAOSIGURANJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVOSNOVAOSIGURANJA.ReadOnly = false;
            this.textNAZIVOSNOVAOSIGURANJA.DataBindings.Add(new Binding("Text", this.bindingSourceOSNOVAOSIGURANJA, "NAZIVOSNOVAOSIGURANJA"));
            this.textNAZIVOSNOVAOSIGURANJA.MaxLength = 100;
            this.layoutManagerformOSNOVAOSIGURANJA.Controls.Add(this.textNAZIVOSNOVAOSIGURANJA, 1, 1);
            this.layoutManagerformOSNOVAOSIGURANJA.SetColumnSpan(this.textNAZIVOSNOVAOSIGURANJA, 1);
            this.layoutManagerformOSNOVAOSIGURANJA.SetRowSpan(this.textNAZIVOSNOVAOSIGURANJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Location = point;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Name = "label1RAZDOBLJESESMIJEPREKLAPATI";
            this.label1RAZDOBLJESESMIJEPREKLAPATI.TabIndex = 1;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Tag = "labelRAZDOBLJESESMIJEPREKLAPATI";
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Text = "Razdoblje se smije preklapati:";
            this.label1RAZDOBLJESESMIJEPREKLAPATI.StyleSetName = "FieldUltraLabel";
            this.label1RAZDOBLJESESMIJEPREKLAPATI.AutoSize = true;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Anchor = AnchorStyles.Left;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Appearance.ForeColor = Color.Black;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.BackColor = Color.Transparent;
            this.layoutManagerformOSNOVAOSIGURANJA.Controls.Add(this.label1RAZDOBLJESESMIJEPREKLAPATI, 0, 2);
            this.layoutManagerformOSNOVAOSIGURANJA.SetColumnSpan(this.label1RAZDOBLJESESMIJEPREKLAPATI, 1);
            this.layoutManagerformOSNOVAOSIGURANJA.SetRowSpan(this.label1RAZDOBLJESESMIJEPREKLAPATI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAZDOBLJESESMIJEPREKLAPATI.MinimumSize = size;
            size = new System.Drawing.Size(0xca, 0x17);
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Location = point;
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Name = "checkRAZDOBLJESESMIJEPREKLAPATI";
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Tag = "RAZDOBLJESESMIJEPREKLAPATI";
            this.checkRAZDOBLJESESMIJEPREKLAPATI.TabIndex = 0;
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Anchor = AnchorStyles.Left;
            this.checkRAZDOBLJESESMIJEPREKLAPATI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Enabled = true;
            this.layoutManagerformOSNOVAOSIGURANJA.Controls.Add(this.checkRAZDOBLJESESMIJEPREKLAPATI, 1, 2);
            this.layoutManagerformOSNOVAOSIGURANJA.SetColumnSpan(this.checkRAZDOBLJESESMIJEPREKLAPATI, 1);
            this.layoutManagerformOSNOVAOSIGURANJA.SetRowSpan(this.checkRAZDOBLJESESMIJEPREKLAPATI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZAMOOIDOSNOVAOSIGURANJA.Location = point;
            this.label1ZAMOOIDOSNOVAOSIGURANJA.Name = "label1ZAMOOIDOSNOVAOSIGURANJA";
            this.label1ZAMOOIDOSNOVAOSIGURANJA.TabIndex = 1;
            this.label1ZAMOOIDOSNOVAOSIGURANJA.Tag = "labelZAMOOIDOSNOVAOSIGURANJA";
            this.label1ZAMOOIDOSNOVAOSIGURANJA.Text = "Zamjenska šifra osnove osiguranja (za nepuno radno vrijeme):";
            this.label1ZAMOOIDOSNOVAOSIGURANJA.StyleSetName = "FieldUltraLabel";
            this.label1ZAMOOIDOSNOVAOSIGURANJA.AutoSize = true;
            this.label1ZAMOOIDOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.label1ZAMOOIDOSNOVAOSIGURANJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZAMOOIDOSNOVAOSIGURANJA.Appearance.ForeColor = Color.Black;
            this.label1ZAMOOIDOSNOVAOSIGURANJA.BackColor = Color.Transparent;
            this.layoutManagerformOSNOVAOSIGURANJA.Controls.Add(this.label1ZAMOOIDOSNOVAOSIGURANJA, 0, 3);
            this.layoutManagerformOSNOVAOSIGURANJA.SetColumnSpan(this.label1ZAMOOIDOSNOVAOSIGURANJA, 1);
            this.layoutManagerformOSNOVAOSIGURANJA.SetRowSpan(this.label1ZAMOOIDOSNOVAOSIGURANJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZAMOOIDOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZAMOOIDOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(0x195, 0x17);
            this.label1ZAMOOIDOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZAMOOIDOSNOVAOSIGURANJA.Location = point;
            this.textZAMOOIDOSNOVAOSIGURANJA.Name = "textZAMOOIDOSNOVAOSIGURANJA";
            this.textZAMOOIDOSNOVAOSIGURANJA.Tag = "ZAMOOIDOSNOVAOSIGURANJA";
            this.textZAMOOIDOSNOVAOSIGURANJA.TabIndex = 0;
            this.textZAMOOIDOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.textZAMOOIDOSNOVAOSIGURANJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZAMOOIDOSNOVAOSIGURANJA.ContextMenu = this.contextMenu1;
            this.textZAMOOIDOSNOVAOSIGURANJA.ReadOnly = false;
            this.textZAMOOIDOSNOVAOSIGURANJA.DataBindings.Add(new Binding("Text", this.bindingSourceOSNOVAOSIGURANJA, "ZAMOOIDOSNOVAOSIGURANJA"));
            this.textZAMOOIDOSNOVAOSIGURANJA.Nullable = true;
            this.textZAMOOIDOSNOVAOSIGURANJA.MaxLength = 2;
            EditorButton button = new EditorButton {
                Key = "editorButtonOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA",
                Tag = "editorButtonOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA",
                Text = "..."
            };
            this.textZAMOOIDOSNOVAOSIGURANJA.ButtonsRight.Add(button);
            this.textZAMOOIDOSNOVAOSIGURANJA.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA);
            this.layoutManagerformOSNOVAOSIGURANJA.Controls.Add(this.textZAMOOIDOSNOVAOSIGURANJA, 1, 3);
            this.layoutManagerformOSNOVAOSIGURANJA.SetColumnSpan(this.textZAMOOIDOSNOVAOSIGURANJA, 1);
            this.layoutManagerformOSNOVAOSIGURANJA.SetRowSpan(this.textZAMOOIDOSNOVAOSIGURANJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZAMOOIDOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(50, 0x16);
            this.textZAMOOIDOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(50, 0x16);
            this.textZAMOOIDOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.Location = point;
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.Name = "label1ZAMOONAZIVOSNOVAOSIGURANJA";
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.TabIndex = 1;
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.Tag = "labelZAMOONAZIVOSNOVAOSIGURANJA";
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.Text = "Naziv zamjenske osnove osiguranja (za nepuno radno vrijeme):";
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.StyleSetName = "FieldUltraLabel";
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.AutoSize = true;
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.Appearance.ForeColor = Color.Black;
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.BackColor = Color.Transparent;
            this.layoutManagerformOSNOVAOSIGURANJA.Controls.Add(this.label1ZAMOONAZIVOSNOVAOSIGURANJA, 0, 4);
            this.layoutManagerformOSNOVAOSIGURANJA.SetColumnSpan(this.label1ZAMOONAZIVOSNOVAOSIGURANJA, 1);
            this.layoutManagerformOSNOVAOSIGURANJA.SetRowSpan(this.label1ZAMOONAZIVOSNOVAOSIGURANJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(410, 0x17);
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZAMOONAZIVOSNOVAOSIGURANJA.Location = point;
            this.labelZAMOONAZIVOSNOVAOSIGURANJA.Name = "labelZAMOONAZIVOSNOVAOSIGURANJA";
            this.labelZAMOONAZIVOSNOVAOSIGURANJA.Tag = "ZAMOONAZIVOSNOVAOSIGURANJA";
            this.labelZAMOONAZIVOSNOVAOSIGURANJA.TabIndex = 0;
            this.labelZAMOONAZIVOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.labelZAMOONAZIVOSNOVAOSIGURANJA.BackColor = Color.Transparent;
            this.labelZAMOONAZIVOSNOVAOSIGURANJA.DataBindings.Add(new Binding("Text", this.bindingSourceOSNOVAOSIGURANJA, "ZAMOONAZIVOSNOVAOSIGURANJA"));
            this.labelZAMOONAZIVOSNOVAOSIGURANJA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOSNOVAOSIGURANJA.Controls.Add(this.labelZAMOONAZIVOSNOVAOSIGURANJA, 1, 4);
            this.layoutManagerformOSNOVAOSIGURANJA.SetColumnSpan(this.labelZAMOONAZIVOSNOVAOSIGURANJA, 1);
            this.layoutManagerformOSNOVAOSIGURANJA.SetRowSpan(this.labelZAMOONAZIVOSNOVAOSIGURANJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZAMOONAZIVOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelZAMOONAZIVOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelZAMOONAZIVOSNOVAOSIGURANJA.Size = size;
            this.Controls.Add(this.layoutManagerformOSNOVAOSIGURANJA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOSNOVAOSIGURANJA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OSNOVAOSIGURANJAFormUserControl";
            this.Text = "R-Sm - Osnove osiguranja";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OSNOVAOSIGURANJAFormUserControl_Load);
            this.layoutManagerformOSNOVAOSIGURANJA.ResumeLayout(false);
            this.layoutManagerformOSNOVAOSIGURANJA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOSNOVAOSIGURANJA).EndInit();
            ((ISupportInitialize) this.textIDOSNOVAOSIGURANJA).EndInit();
            ((ISupportInitialize) this.textNAZIVOSNOVAOSIGURANJA).EndInit();
            ((ISupportInitialize) this.textZAMOOIDOSNOVAOSIGURANJA).EndInit();
            this.dsOSNOVAOSIGURANJADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OSNOVAOSIGURANJAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOSNOVAOSIGURANJA, this.OSNOVAOSIGURANJAController.WorkItem, this))
            {
                return false;
            }
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void Localize()
        {
            this.label1IDOSNOVAOSIGURANJA.Text = StringResources.OSNOVAOSIGURANJAIDOSNOVAOSIGURANJADescription;
            this.label1NAZIVOSNOVAOSIGURANJA.Text = StringResources.OSNOVAOSIGURANJANAZIVOSNOVAOSIGURANJADescription;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Text = StringResources.OSNOVAOSIGURANJARAZDOBLJESESMIJEPREKLAPATIDescription;
            this.label1ZAMOOIDOSNOVAOSIGURANJA.Text = StringResources.OSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJADescription;
            this.label1ZAMOONAZIVOSNOVAOSIGURANJA.Text = StringResources.OSNOVAOSIGURANJAZAMOONAZIVOSNOVAOSIGURANJADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewELEMENT")]
        public void NewELEMENTHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OSNOVAOSIGURANJAController.NewELEMENT(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OSNOVAOSIGURANJAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OSNOVAOSIGURANJADescription;
            this.errorProvider1.ContainerControl = this;
            this.errorProviderValidator1.SetRequiredMessage(this.textIDOSNOVAOSIGURANJA, Deklarit.Resources.Resources.validateRequired);
        }

        private void RegisterBindingSources()
        {
            if (!this.OSNOVAOSIGURANJAController.WorkItem.Items.Contains("OSNOVAOSIGURANJA|OSNOVAOSIGURANJA"))
            {
                this.OSNOVAOSIGURANJAController.WorkItem.Items.Add(this.bindingSourceOSNOVAOSIGURANJA, "OSNOVAOSIGURANJA|OSNOVAOSIGURANJA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsOSNOVAOSIGURANJADataSet1.OSNOVAOSIGURANJA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
            }
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OSNOVAOSIGURANJAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OSNOVAOSIGURANJAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OSNOVAOSIGURANJAController.Update(this))
            {
                this.OSNOVAOSIGURANJAController.DataSet = new OSNOVAOSIGURANJADataSet();
                DataSetUtil.AddEmptyRow(this.OSNOVAOSIGURANJAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.OSNOVAOSIGURANJAController.DataSet.OSNOVAOSIGURANJA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDOSNOVAOSIGURANJA.Focus();
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

        private void UpdateValuesOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceOSNOVAOSIGURANJA.Current).Row["ZAMOOIDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(result["IDOSNOVAOSIGURANJA"]);
                ((DataRowView) this.bindingSourceOSNOVAOSIGURANJA.Current).Row["ZAMOONAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(result["NAZIVOSNOVAOSIGURANJA"]);
                this.bindingSourceOSNOVAOSIGURANJA.ResetCurrentItem();
            }
        }

        [LocalCommandHandler("ViewELEMENT")]
        public void ViewELEMENTHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OSNOVAOSIGURANJAController.ViewELEMENT(this.m_CurrentRow);
            }
        }

        protected virtual UltraCheckEditor checkRAZDOBLJESESMIJEPREKLAPATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkRAZDOBLJESESMIJEPREKLAPATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkRAZDOBLJESESMIJEPREKLAPATI = value;
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

        protected virtual UltraLabel label1IDOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraLabel label1RAZDOBLJESESMIJEPREKLAPATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAZDOBLJESESMIJEPREKLAPATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAZDOBLJESESMIJEPREKLAPATI = value;
            }
        }

        protected virtual UltraLabel label1ZAMOOIDOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZAMOOIDOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZAMOOIDOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraLabel label1ZAMOONAZIVOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZAMOONAZIVOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZAMOONAZIVOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraLabel labelZAMOONAZIVOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZAMOONAZIVOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZAMOONAZIVOSNOVAOSIGURANJA = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.OSNOVAOSIGURANJAController OSNOVAOSIGURANJAController { get; set; }

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

        protected virtual UltraTextEditor textIDOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraTextEditor textZAMOOIDOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZAMOOIDOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZAMOOIDOSNOVAOSIGURANJA = value;
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

