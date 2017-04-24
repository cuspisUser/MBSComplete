namespace NetAdvantage.SmartParts
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
    public class BANKEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        private BindingSource bindingSourceBANKE;
        private IContainer components = null;
        private BANKEDataSet dsBANKEDataSet1;
        protected TableLayoutPanel layoutManagerformBANKE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private BANKEDataSet.BANKERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "BANKE";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.BANKEDescription;
        private DeklaritMode m_Mode;

        public BANKEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void BANKEFormUserControl_Load(object sender, EventArgs e)
        {
            WinFormUtil.GetForm(this).Icon = WinFormUtil.GetIcon(ImageResources.BANKEImageSmall);
            this.Text = StringResources.BANKEDescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void ChangeBinding()
        {
            this.bindingSourceBANKE.DataSource = this.Controller.DataSet;
            this.dsBANKEDataSet1 = this.Controller.DataSet;
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
                    enumerator = this.dsBANKEDataSet1.BANKE.Rows.GetEnumerator();
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
                if (this.Controller.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "BANKE", this.m_Mode, this.dsBANKEDataSet1, this.dsBANKEDataSet1.BANKE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsBANKEDataSet1.BANKE[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (BANKEDataSet.BANKERow) ((DataRowView) this.bindingSourceBANKE.AddNew()).Row;
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.SetNullItem = new System.Windows.Forms.MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSourceBANKE = new System.Windows.Forms.BindingSource(this.components);
            this.dsBANKEDataSet1 = new Placa.BANKEDataSet();
            this.errorProviderValidator1 = new Deklarit.Win.ErrorProviderValidator(this.components);
            this.layoutManagerformBANKE = new System.Windows.Forms.TableLayoutPanel();
            this.label1IDBANKE = new Infragistics.Win.Misc.UltraLabel();
            this.textIDBANKE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1NAZIVBANKE1 = new Infragistics.Win.Misc.UltraLabel();
            this.textNAZIVBANKE1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1NAZIVBANKE2 = new Infragistics.Win.Misc.UltraLabel();
            this.textNAZIVBANKE2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1NAZIVBANKE3 = new Infragistics.Win.Misc.UltraLabel();
            this.textNAZIVBANKE3 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1MOBANKA = new Infragistics.Win.Misc.UltraLabel();
            this.textMOBANKA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1POBANKA = new Infragistics.Win.Misc.UltraLabel();
            this.textPOBANKA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1MZBANKA = new Infragistics.Win.Misc.UltraLabel();
            this.textMZBANKA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1PZBANKA = new Infragistics.Win.Misc.UltraLabel();
            this.textPZBANKA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1SIFRAOPISPLACANJABANKE = new Infragistics.Win.Misc.UltraLabel();
            this.textSIFRAOPISPLACANJABANKE = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1OPISPLACANJABANKE = new Infragistics.Win.Misc.UltraLabel();
            this.textOPISPLACANJABANKE = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1VBDIBANKE = new Infragistics.Win.Misc.UltraLabel();
            this.textVBDIBANKE = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1ZRNBANKE = new Infragistics.Win.Misc.UltraLabel();
            this.textZRNBANKE = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBANKE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBANKEDataSet1)).BeginInit();
            this.layoutManagerformBANKE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textIDBANKE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNAZIVBANKE1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNAZIVBANKE2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNAZIVBANKE3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMOBANKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPOBANKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMZBANKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPZBANKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSIFRAOPISPLACANJABANKE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOPISPLACANJABANKE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textVBDIBANKE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textZRNBANKE)).BeginInit();
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
            this.errorProvider1.DataSource = this.bindingSourceBANKE;
            // 
            // bindingSourceBANKE
            // 
            this.bindingSourceBANKE.DataMember = "BANKE";
            this.bindingSourceBANKE.DataSource = this.dsBANKEDataSet1;
            // 
            // dsBANKEDataSet1
            // 
            this.dsBANKEDataSet1.DataSetName = "dsBANKE";
            this.dsBANKEDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // errorProviderValidator1
            // 
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.errorProviderValidator1.ToolTipProvider = null;
            // 
            // layoutManagerformBANKE
            // 
            this.layoutManagerformBANKE.AutoSize = true;
            this.layoutManagerformBANKE.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerformBANKE.ColumnCount = 2;
            this.layoutManagerformBANKE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBANKE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBANKE.Controls.Add(this.label1IDBANKE, 0, 0);
            this.layoutManagerformBANKE.Controls.Add(this.textIDBANKE, 1, 0);
            this.layoutManagerformBANKE.Controls.Add(this.label1NAZIVBANKE1, 0, 1);
            this.layoutManagerformBANKE.Controls.Add(this.textNAZIVBANKE1, 1, 1);
            this.layoutManagerformBANKE.Controls.Add(this.label1NAZIVBANKE2, 0, 2);
            this.layoutManagerformBANKE.Controls.Add(this.textNAZIVBANKE2, 1, 2);
            this.layoutManagerformBANKE.Controls.Add(this.label1NAZIVBANKE3, 0, 3);
            this.layoutManagerformBANKE.Controls.Add(this.textNAZIVBANKE3, 1, 3);
            this.layoutManagerformBANKE.Controls.Add(this.label1MOBANKA, 0, 4);
            this.layoutManagerformBANKE.Controls.Add(this.textMOBANKA, 1, 4);
            this.layoutManagerformBANKE.Controls.Add(this.label1POBANKA, 0, 5);
            this.layoutManagerformBANKE.Controls.Add(this.textPOBANKA, 1, 5);
            this.layoutManagerformBANKE.Controls.Add(this.label1MZBANKA, 0, 6);
            this.layoutManagerformBANKE.Controls.Add(this.textMZBANKA, 1, 6);
            this.layoutManagerformBANKE.Controls.Add(this.label1PZBANKA, 0, 7);
            this.layoutManagerformBANKE.Controls.Add(this.textPZBANKA, 1, 7);
            this.layoutManagerformBANKE.Controls.Add(this.label1SIFRAOPISPLACANJABANKE, 0, 8);
            this.layoutManagerformBANKE.Controls.Add(this.textSIFRAOPISPLACANJABANKE, 1, 8);
            this.layoutManagerformBANKE.Controls.Add(this.label1OPISPLACANJABANKE, 0, 9);
            this.layoutManagerformBANKE.Controls.Add(this.textOPISPLACANJABANKE, 1, 9);
            this.layoutManagerformBANKE.Controls.Add(this.label1VBDIBANKE, 0, 10);
            this.layoutManagerformBANKE.Controls.Add(this.textVBDIBANKE, 1, 10);
            this.layoutManagerformBANKE.Controls.Add(this.label1ZRNBANKE, 0, 11);
            this.layoutManagerformBANKE.Controls.Add(this.textZRNBANKE, 1, 11);
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerformBANKE, "");
            this.layoutManagerformBANKE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutManagerformBANKE.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerformBANKE.Name = "layoutManagerformBANKE";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerformBANKE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerformBANKE, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerformBANKE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerformBANKE, "");
            this.layoutManagerformBANKE.RowCount = 13;
            this.layoutManagerformBANKE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBANKE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBANKE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBANKE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBANKE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBANKE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBANKE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBANKE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBANKE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBANKE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBANKE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBANKE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBANKE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBANKE.Size = new System.Drawing.Size(406, 290);
            this.layoutManagerformBANKE.TabIndex = 0;
            // 
            // label1IDBANKE
            // 
            this.label1IDBANKE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.TextVAlignAsString = "Middle";
            this.label1IDBANKE.Appearance = appearance1;
            this.label1IDBANKE.AutoSize = true;
            this.label1IDBANKE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IDBANKE, "");
            this.label1IDBANKE.ImageSize = new System.Drawing.Size(7, 10);
            this.label1IDBANKE.Location = new System.Drawing.Point(3, 5);
            this.label1IDBANKE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IDBANKE.Name = "label1IDBANKE";
            this.errorProviderValidator1.SetRegularExpression(this.label1IDBANKE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IDBANKE, "");
            this.errorProviderValidator1.SetRequired(this.label1IDBANKE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IDBANKE, "");
            this.label1IDBANKE.Size = new System.Drawing.Size(65, 14);
            this.label1IDBANKE.StyleSetName = "FieldUltraLabel";
            this.label1IDBANKE.TabIndex = 1;
            this.label1IDBANKE.Tag = "labelIDBANKE";
            this.label1IDBANKE.Text = "Šifra banke:";
            // 
            // textIDBANKE
            // 
            this.textIDBANKE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIDBANKE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceBANKE, "IDBANKE", true));
            this.errorProviderValidator1.SetDisplayName(this.textIDBANKE, "");
            this.textIDBANKE.Location = new System.Drawing.Point(135, 1);
            this.textIDBANKE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textIDBANKE.MaskInput = "{LOC}-nnnnn";
            this.textIDBANKE.MinimumSize = new System.Drawing.Size(51, 22);
            this.textIDBANKE.Name = "textIDBANKE";
            this.textIDBANKE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textIDBANKE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIDBANKE, "");
            this.errorProviderValidator1.SetRequired(this.textIDBANKE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIDBANKE, "");
            this.textIDBANKE.Size = new System.Drawing.Size(51, 22);
            this.textIDBANKE.TabIndex = 0;
            this.textIDBANKE.Tag = "IDBANKE";
            this.textIDBANKE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textIDBANKE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1NAZIVBANKE1
            // 
            this.label1NAZIVBANKE1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.label1NAZIVBANKE1.Appearance = appearance2;
            this.label1NAZIVBANKE1.AutoSize = true;
            this.label1NAZIVBANKE1.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1NAZIVBANKE1, "");
            this.label1NAZIVBANKE1.Location = new System.Drawing.Point(3, 30);
            this.label1NAZIVBANKE1.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1NAZIVBANKE1.Name = "label1NAZIVBANKE1";
            this.errorProviderValidator1.SetRegularExpression(this.label1NAZIVBANKE1, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1NAZIVBANKE1, "");
            this.errorProviderValidator1.SetRequired(this.label1NAZIVBANKE1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1NAZIVBANKE1, "");
            this.label1NAZIVBANKE1.Size = new System.Drawing.Size(70, 14);
            this.label1NAZIVBANKE1.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVBANKE1.TabIndex = 1;
            this.label1NAZIVBANKE1.Tag = "labelNAZIVBANKE1";
            this.label1NAZIVBANKE1.Text = "Naziv banke:";
            // 
            // textNAZIVBANKE1
            // 
            this.textNAZIVBANKE1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textNAZIVBANKE1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBANKE, "NAZIVBANKE1", true));
            this.errorProviderValidator1.SetDisplayName(this.textNAZIVBANKE1, "");
            this.textNAZIVBANKE1.Location = new System.Drawing.Point(135, 26);
            this.textNAZIVBANKE1.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textNAZIVBANKE1.MaxLength = 20;
            this.textNAZIVBANKE1.MinimumSize = new System.Drawing.Size(156, 22);
            this.textNAZIVBANKE1.Name = "textNAZIVBANKE1";
            this.errorProviderValidator1.SetRegularExpression(this.textNAZIVBANKE1, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textNAZIVBANKE1, "");
            this.errorProviderValidator1.SetRequired(this.textNAZIVBANKE1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textNAZIVBANKE1, "");
            this.textNAZIVBANKE1.Size = new System.Drawing.Size(156, 22);
            this.textNAZIVBANKE1.TabIndex = 0;
            this.textNAZIVBANKE1.Tag = "NAZIVBANKE1";
            this.textNAZIVBANKE1.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1NAZIVBANKE2
            // 
            this.label1NAZIVBANKE2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.label1NAZIVBANKE2.Appearance = appearance3;
            this.label1NAZIVBANKE2.AutoSize = true;
            this.label1NAZIVBANKE2.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1NAZIVBANKE2, "");
            this.label1NAZIVBANKE2.Location = new System.Drawing.Point(3, 54);
            this.label1NAZIVBANKE2.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1NAZIVBANKE2.Name = "label1NAZIVBANKE2";
            this.errorProviderValidator1.SetRegularExpression(this.label1NAZIVBANKE2, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1NAZIVBANKE2, "");
            this.errorProviderValidator1.SetRequired(this.label1NAZIVBANKE2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1NAZIVBANKE2, "");
            this.label1NAZIVBANKE2.Size = new System.Drawing.Size(70, 14);
            this.label1NAZIVBANKE2.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVBANKE2.TabIndex = 1;
            this.label1NAZIVBANKE2.Tag = "labelNAZIVBANKE2";
            this.label1NAZIVBANKE2.Text = "Naziv banke:";
            // 
            // textNAZIVBANKE2
            // 
            this.textNAZIVBANKE2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textNAZIVBANKE2.ContextMenu = this.contextMenu1;
            this.textNAZIVBANKE2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBANKE, "NAZIVBANKE2", true));
            this.errorProviderValidator1.SetDisplayName(this.textNAZIVBANKE2, "");
            this.textNAZIVBANKE2.Location = new System.Drawing.Point(135, 51);
            this.textNAZIVBANKE2.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textNAZIVBANKE2.MaxLength = 20;
            this.textNAZIVBANKE2.MinimumSize = new System.Drawing.Size(156, 22);
            this.textNAZIVBANKE2.Name = "textNAZIVBANKE2";
            this.errorProviderValidator1.SetRegularExpression(this.textNAZIVBANKE2, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textNAZIVBANKE2, "");
            this.errorProviderValidator1.SetRequired(this.textNAZIVBANKE2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textNAZIVBANKE2, "");
            this.textNAZIVBANKE2.Size = new System.Drawing.Size(156, 22);
            this.textNAZIVBANKE2.TabIndex = 0;
            this.textNAZIVBANKE2.Tag = "NAZIVBANKE2";
            this.textNAZIVBANKE2.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1NAZIVBANKE3
            // 
            this.label1NAZIVBANKE3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextVAlignAsString = "Middle";
            this.label1NAZIVBANKE3.Appearance = appearance4;
            this.label1NAZIVBANKE3.AutoSize = true;
            this.label1NAZIVBANKE3.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1NAZIVBANKE3, "");
            this.label1NAZIVBANKE3.Location = new System.Drawing.Point(3, 78);
            this.label1NAZIVBANKE3.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1NAZIVBANKE3.Name = "label1NAZIVBANKE3";
            this.errorProviderValidator1.SetRegularExpression(this.label1NAZIVBANKE3, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1NAZIVBANKE3, "");
            this.errorProviderValidator1.SetRequired(this.label1NAZIVBANKE3, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1NAZIVBANKE3, "");
            this.label1NAZIVBANKE3.Size = new System.Drawing.Size(70, 14);
            this.label1NAZIVBANKE3.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVBANKE3.TabIndex = 1;
            this.label1NAZIVBANKE3.Tag = "labelNAZIVBANKE3";
            this.label1NAZIVBANKE3.Text = "Naziv banke:";
            // 
            // textNAZIVBANKE3
            // 
            this.textNAZIVBANKE3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textNAZIVBANKE3.ContextMenu = this.contextMenu1;
            this.textNAZIVBANKE3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBANKE, "NAZIVBANKE3", true));
            this.errorProviderValidator1.SetDisplayName(this.textNAZIVBANKE3, "");
            this.textNAZIVBANKE3.Location = new System.Drawing.Point(135, 75);
            this.textNAZIVBANKE3.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textNAZIVBANKE3.MaxLength = 20;
            this.textNAZIVBANKE3.MinimumSize = new System.Drawing.Size(156, 22);
            this.textNAZIVBANKE3.Name = "textNAZIVBANKE3";
            this.errorProviderValidator1.SetRegularExpression(this.textNAZIVBANKE3, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textNAZIVBANKE3, "");
            this.errorProviderValidator1.SetRequired(this.textNAZIVBANKE3, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textNAZIVBANKE3, "");
            this.textNAZIVBANKE3.Size = new System.Drawing.Size(156, 22);
            this.textNAZIVBANKE3.TabIndex = 0;
            this.textNAZIVBANKE3.Tag = "NAZIVBANKE3";
            this.textNAZIVBANKE3.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1MOBANKA
            // 
            this.label1MOBANKA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.label1MOBANKA.Appearance = appearance5;
            this.label1MOBANKA.AutoSize = true;
            this.label1MOBANKA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1MOBANKA, "");
            this.label1MOBANKA.Location = new System.Drawing.Point(3, 102);
            this.label1MOBANKA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1MOBANKA.Name = "label1MOBANKA";
            this.errorProviderValidator1.SetRegularExpression(this.label1MOBANKA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1MOBANKA, "");
            this.errorProviderValidator1.SetRequired(this.label1MOBANKA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1MOBANKA, "");
            this.label1MOBANKA.Size = new System.Drawing.Size(92, 14);
            this.label1MOBANKA.StyleSetName = "FieldUltraLabel";
            this.label1MOBANKA.TabIndex = 1;
            this.label1MOBANKA.Tag = "labelMOBANKA";
            this.label1MOBANKA.Text = "Model odobrenja:";
            // 
            // textMOBANKA
            // 
            this.textMOBANKA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textMOBANKA.ContextMenu = this.contextMenu1;
            this.textMOBANKA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBANKE, "MOBANKA", true));
            this.errorProviderValidator1.SetDisplayName(this.textMOBANKA, "");
            this.textMOBANKA.Location = new System.Drawing.Point(135, 99);
            this.textMOBANKA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textMOBANKA.MaxLength = 2;
            this.textMOBANKA.MinimumSize = new System.Drawing.Size(30, 22);
            this.textMOBANKA.Name = "textMOBANKA";
            this.errorProviderValidator1.SetRegularExpression(this.textMOBANKA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textMOBANKA, "");
            this.errorProviderValidator1.SetRequired(this.textMOBANKA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textMOBANKA, "");
            this.textMOBANKA.Size = new System.Drawing.Size(30, 22);
            this.textMOBANKA.TabIndex = 0;
            this.textMOBANKA.Tag = "MOBANKA";
            this.textMOBANKA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1POBANKA
            // 
            this.label1POBANKA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.label1POBANKA.Appearance = appearance6;
            this.label1POBANKA.AutoSize = true;
            this.label1POBANKA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1POBANKA, "");
            this.label1POBANKA.Location = new System.Drawing.Point(3, 126);
            this.label1POBANKA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1POBANKA.Name = "label1POBANKA";
            this.errorProviderValidator1.SetRegularExpression(this.label1POBANKA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1POBANKA, "");
            this.errorProviderValidator1.SetRequired(this.label1POBANKA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1POBANKA, "");
            this.label1POBANKA.Size = new System.Drawing.Size(126, 14);
            this.label1POBANKA.StyleSetName = "FieldUltraLabel";
            this.label1POBANKA.TabIndex = 1;
            this.label1POBANKA.Tag = "labelPOBANKA";
            this.label1POBANKA.Text = "Poziv na broj odobrenja:";
            // 
            // textPOBANKA
            // 
            this.textPOBANKA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPOBANKA.ContextMenu = this.contextMenu1;
            this.textPOBANKA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBANKE, "POBANKA", true));
            this.errorProviderValidator1.SetDisplayName(this.textPOBANKA, "");
            this.textPOBANKA.Location = new System.Drawing.Point(135, 123);
            this.textPOBANKA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPOBANKA.MaxLength = 22;
            this.textPOBANKA.MinimumSize = new System.Drawing.Size(170, 22);
            this.textPOBANKA.Name = "textPOBANKA";
            this.errorProviderValidator1.SetRegularExpression(this.textPOBANKA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPOBANKA, "");
            this.errorProviderValidator1.SetRequired(this.textPOBANKA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPOBANKA, "");
            this.textPOBANKA.Size = new System.Drawing.Size(170, 22);
            this.textPOBANKA.TabIndex = 0;
            this.textPOBANKA.Tag = "POBANKA";
            this.textPOBANKA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1MZBANKA
            // 
            this.label1MZBANKA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.label1MZBANKA.Appearance = appearance7;
            this.label1MZBANKA.AutoSize = true;
            this.label1MZBANKA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1MZBANKA, "");
            this.label1MZBANKA.Location = new System.Drawing.Point(3, 150);
            this.label1MZBANKA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1MZBANKA.Name = "label1MZBANKA";
            this.errorProviderValidator1.SetRegularExpression(this.label1MZBANKA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1MZBANKA, "");
            this.errorProviderValidator1.SetRequired(this.label1MZBANKA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1MZBANKA, "");
            this.label1MZBANKA.Size = new System.Drawing.Size(93, 14);
            this.label1MZBANKA.StyleSetName = "FieldUltraLabel";
            this.label1MZBANKA.TabIndex = 1;
            this.label1MZBANKA.Tag = "labelMZBANKA";
            this.label1MZBANKA.Text = "Model zaduženja:";
            // 
            // textMZBANKA
            // 
            this.textMZBANKA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textMZBANKA.ContextMenu = this.contextMenu1;
            this.textMZBANKA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBANKE, "MZBANKA", true));
            this.errorProviderValidator1.SetDisplayName(this.textMZBANKA, "");
            this.textMZBANKA.Location = new System.Drawing.Point(135, 147);
            this.textMZBANKA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textMZBANKA.MaxLength = 2;
            this.textMZBANKA.MinimumSize = new System.Drawing.Size(30, 22);
            this.textMZBANKA.Name = "textMZBANKA";
            this.errorProviderValidator1.SetRegularExpression(this.textMZBANKA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textMZBANKA, "");
            this.errorProviderValidator1.SetRequired(this.textMZBANKA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textMZBANKA, "");
            this.textMZBANKA.Size = new System.Drawing.Size(30, 22);
            this.textMZBANKA.TabIndex = 0;
            this.textMZBANKA.Tag = "MZBANKA";
            this.textMZBANKA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1PZBANKA
            // 
            this.label1PZBANKA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.label1PZBANKA.Appearance = appearance8;
            this.label1PZBANKA.AutoSize = true;
            this.label1PZBANKA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PZBANKA, "");
            this.label1PZBANKA.Location = new System.Drawing.Point(3, 174);
            this.label1PZBANKA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PZBANKA.Name = "label1PZBANKA";
            this.errorProviderValidator1.SetRegularExpression(this.label1PZBANKA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PZBANKA, "");
            this.errorProviderValidator1.SetRequired(this.label1PZBANKA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PZBANKA, "");
            this.label1PZBANKA.Size = new System.Drawing.Size(127, 14);
            this.label1PZBANKA.StyleSetName = "FieldUltraLabel";
            this.label1PZBANKA.TabIndex = 1;
            this.label1PZBANKA.Tag = "labelPZBANKA";
            this.label1PZBANKA.Text = "Poziv na broj zaduženja:";
            // 
            // textPZBANKA
            // 
            this.textPZBANKA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPZBANKA.ContextMenu = this.contextMenu1;
            this.textPZBANKA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBANKE, "PZBANKA", true));
            this.errorProviderValidator1.SetDisplayName(this.textPZBANKA, "");
            this.textPZBANKA.Location = new System.Drawing.Point(135, 171);
            this.textPZBANKA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPZBANKA.MaxLength = 22;
            this.textPZBANKA.MinimumSize = new System.Drawing.Size(170, 22);
            this.textPZBANKA.Name = "textPZBANKA";
            this.errorProviderValidator1.SetRegularExpression(this.textPZBANKA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPZBANKA, "");
            this.errorProviderValidator1.SetRequired(this.textPZBANKA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPZBANKA, "");
            this.textPZBANKA.Size = new System.Drawing.Size(170, 22);
            this.textPZBANKA.TabIndex = 0;
            this.textPZBANKA.Tag = "PZBANKA";
            this.textPZBANKA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1SIFRAOPISPLACANJABANKE
            // 
            this.label1SIFRAOPISPLACANJABANKE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.label1SIFRAOPISPLACANJABANKE.Appearance = appearance9;
            this.label1SIFRAOPISPLACANJABANKE.AutoSize = true;
            this.label1SIFRAOPISPLACANJABANKE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1SIFRAOPISPLACANJABANKE, "");
            this.label1SIFRAOPISPLACANJABANKE.Location = new System.Drawing.Point(3, 198);
            this.label1SIFRAOPISPLACANJABANKE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1SIFRAOPISPLACANJABANKE.Name = "label1SIFRAOPISPLACANJABANKE";
            this.errorProviderValidator1.SetRegularExpression(this.label1SIFRAOPISPLACANJABANKE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1SIFRAOPISPLACANJABANKE, "");
            this.errorProviderValidator1.SetRequired(this.label1SIFRAOPISPLACANJABANKE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1SIFRAOPISPLACANJABANKE, "");
            this.label1SIFRAOPISPLACANJABANKE.Size = new System.Drawing.Size(106, 14);
            this.label1SIFRAOPISPLACANJABANKE.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPISPLACANJABANKE.TabIndex = 1;
            this.label1SIFRAOPISPLACANJABANKE.Tag = "labelSIFRAOPISPLACANJABANKE";
            this.label1SIFRAOPISPLACANJABANKE.Text = "Šifra opisa plaćanja:";
            // 
            // textSIFRAOPISPLACANJABANKE
            // 
            this.textSIFRAOPISPLACANJABANKE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textSIFRAOPISPLACANJABANKE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBANKE, "SIFRAOPISPLACANJABANKE", true));
            this.errorProviderValidator1.SetDisplayName(this.textSIFRAOPISPLACANJABANKE, "");
            this.textSIFRAOPISPLACANJABANKE.Location = new System.Drawing.Point(135, 195);
            this.textSIFRAOPISPLACANJABANKE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textSIFRAOPISPLACANJABANKE.MaxLength = 2;
            this.textSIFRAOPISPLACANJABANKE.MinimumSize = new System.Drawing.Size(30, 22);
            this.textSIFRAOPISPLACANJABANKE.Name = "textSIFRAOPISPLACANJABANKE";
            this.errorProviderValidator1.SetRegularExpression(this.textSIFRAOPISPLACANJABANKE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textSIFRAOPISPLACANJABANKE, "");
            this.errorProviderValidator1.SetRequired(this.textSIFRAOPISPLACANJABANKE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textSIFRAOPISPLACANJABANKE, "");
            this.textSIFRAOPISPLACANJABANKE.Size = new System.Drawing.Size(30, 22);
            this.textSIFRAOPISPLACANJABANKE.TabIndex = 0;
            this.textSIFRAOPISPLACANJABANKE.Tag = "SIFRAOPISPLACANJABANKE";
            this.textSIFRAOPISPLACANJABANKE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1OPISPLACANJABANKE
            // 
            this.label1OPISPLACANJABANKE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextVAlignAsString = "Middle";
            this.label1OPISPLACANJABANKE.Appearance = appearance10;
            this.label1OPISPLACANJABANKE.AutoSize = true;
            this.label1OPISPLACANJABANKE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OPISPLACANJABANKE, "");
            this.label1OPISPLACANJABANKE.Location = new System.Drawing.Point(3, 222);
            this.label1OPISPLACANJABANKE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OPISPLACANJABANKE.Name = "label1OPISPLACANJABANKE";
            this.errorProviderValidator1.SetRegularExpression(this.label1OPISPLACANJABANKE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OPISPLACANJABANKE, "");
            this.errorProviderValidator1.SetRequired(this.label1OPISPLACANJABANKE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OPISPLACANJABANKE, "");
            this.label1OPISPLACANJABANKE.Size = new System.Drawing.Size(76, 14);
            this.label1OPISPLACANJABANKE.StyleSetName = "FieldUltraLabel";
            this.label1OPISPLACANJABANKE.TabIndex = 1;
            this.label1OPISPLACANJABANKE.Tag = "labelOPISPLACANJABANKE";
            this.label1OPISPLACANJABANKE.Text = "Opis plaćanja:";
            // 
            // textOPISPLACANJABANKE
            // 
            this.textOPISPLACANJABANKE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOPISPLACANJABANKE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBANKE, "OPISPLACANJABANKE", true));
            this.errorProviderValidator1.SetDisplayName(this.textOPISPLACANJABANKE, "");
            this.textOPISPLACANJABANKE.Location = new System.Drawing.Point(135, 219);
            this.textOPISPLACANJABANKE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOPISPLACANJABANKE.MaxLength = 36;
            this.textOPISPLACANJABANKE.MinimumSize = new System.Drawing.Size(268, 22);
            this.textOPISPLACANJABANKE.Name = "textOPISPLACANJABANKE";
            this.errorProviderValidator1.SetRegularExpression(this.textOPISPLACANJABANKE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOPISPLACANJABANKE, "");
            this.errorProviderValidator1.SetRequired(this.textOPISPLACANJABANKE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOPISPLACANJABANKE, "");
            this.textOPISPLACANJABANKE.Size = new System.Drawing.Size(268, 22);
            this.textOPISPLACANJABANKE.TabIndex = 0;
            this.textOPISPLACANJABANKE.Tag = "OPISPLACANJABANKE";
            this.textOPISPLACANJABANKE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1VBDIBANKE
            // 
            this.label1VBDIBANKE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.label1VBDIBANKE.Appearance = appearance11;
            this.label1VBDIBANKE.AutoSize = true;
            this.label1VBDIBANKE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1VBDIBANKE, "");
            this.label1VBDIBANKE.Location = new System.Drawing.Point(3, 246);
            this.label1VBDIBANKE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1VBDIBANKE.Name = "label1VBDIBANKE";
            this.errorProviderValidator1.SetRegularExpression(this.label1VBDIBANKE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1VBDIBANKE, "");
            this.errorProviderValidator1.SetRequired(this.label1VBDIBANKE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1VBDIBANKE, "");
            this.label1VBDIBANKE.Size = new System.Drawing.Size(34, 14);
            this.label1VBDIBANKE.StyleSetName = "FieldUltraLabel";
            this.label1VBDIBANKE.TabIndex = 1;
            this.label1VBDIBANKE.Tag = "labelVBDIBANKE";
            this.label1VBDIBANKE.Text = "VBDI:";
            // 
            // textVBDIBANKE
            // 
            this.textVBDIBANKE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textVBDIBANKE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBANKE, "VBDIBANKE", true));
            this.errorProviderValidator1.SetDisplayName(this.textVBDIBANKE, "");
            this.textVBDIBANKE.Location = new System.Drawing.Point(135, 243);
            this.textVBDIBANKE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textVBDIBANKE.MaxLength = 7;
            this.textVBDIBANKE.MinimumSize = new System.Drawing.Size(65, 22);
            this.textVBDIBANKE.Name = "textVBDIBANKE";
            this.errorProviderValidator1.SetRegularExpression(this.textVBDIBANKE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textVBDIBANKE, "");
            this.errorProviderValidator1.SetRequired(this.textVBDIBANKE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textVBDIBANKE, "");
            this.textVBDIBANKE.Size = new System.Drawing.Size(65, 22);
            this.textVBDIBANKE.TabIndex = 0;
            this.textVBDIBANKE.Tag = "VBDIBANKE";
            this.textVBDIBANKE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1ZRNBANKE
            // 
            this.label1ZRNBANKE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.label1ZRNBANKE.Appearance = appearance12;
            this.label1ZRNBANKE.AutoSize = true;
            this.label1ZRNBANKE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1ZRNBANKE, "");
            this.label1ZRNBANKE.Location = new System.Drawing.Point(3, 270);
            this.label1ZRNBANKE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1ZRNBANKE.Name = "label1ZRNBANKE";
            this.errorProviderValidator1.SetRegularExpression(this.label1ZRNBANKE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1ZRNBANKE, "");
            this.errorProviderValidator1.SetRequired(this.label1ZRNBANKE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1ZRNBANKE, "");
            this.label1ZRNBANKE.Size = new System.Drawing.Size(31, 14);
            this.label1ZRNBANKE.StyleSetName = "FieldUltraLabel";
            this.label1ZRNBANKE.TabIndex = 1;
            this.label1ZRNBANKE.Tag = "labelZRNBANKE";
            this.label1ZRNBANKE.Text = "ŽRN:";
            // 
            // textZRNBANKE
            // 
            this.textZRNBANKE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textZRNBANKE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBANKE, "ZRNBANKE", true));
            this.errorProviderValidator1.SetDisplayName(this.textZRNBANKE, "");
            this.textZRNBANKE.Location = new System.Drawing.Point(135, 267);
            this.textZRNBANKE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textZRNBANKE.MaxLength = 10;
            this.textZRNBANKE.MinimumSize = new System.Drawing.Size(86, 22);
            this.textZRNBANKE.Name = "textZRNBANKE";
            this.errorProviderValidator1.SetRegularExpression(this.textZRNBANKE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textZRNBANKE, "");
            this.errorProviderValidator1.SetRequired(this.textZRNBANKE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textZRNBANKE, "");
            this.textZRNBANKE.Size = new System.Drawing.Size(86, 22);
            this.textZRNBANKE.TabIndex = 0;
            this.textZRNBANKE.Tag = "ZRNBANKE";
            this.textZRNBANKE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // BANKEFormUserControl
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.layoutManagerformBANKE);
            this.errorProviderValidator1.SetDisplayName(this, "");
            this.Name = "BANKEFormUserControl";
            this.errorProviderValidator1.SetRegularExpression(this, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this, "");
            this.errorProviderValidator1.SetRequired(this, false);
            this.errorProviderValidator1.SetRequiredMessage(this, "");
            this.Size = new System.Drawing.Size(406, 290);
            this.Load += new System.EventHandler(this.BANKEFormUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBANKE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBANKEDataSet1)).EndInit();
            this.layoutManagerformBANKE.ResumeLayout(false);
            this.layoutManagerformBANKE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textIDBANKE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNAZIVBANKE1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNAZIVBANKE2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNAZIVBANKE3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMOBANKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPOBANKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMZBANKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPZBANKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSIFRAOPISPLACANJABANKE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOPISPLACANJABANKE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textVBDIBANKE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textZRNBANKE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool InValidState()
        {
            if ((this.Controller.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceBANKE, this.Controller.WorkItem, this))
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
            this.label1IDBANKE.Text = StringResources.BANKEIDBANKEDescription;
            this.label1NAZIVBANKE1.Text = StringResources.BANKENAZIVBANKE1Description;
            this.label1NAZIVBANKE2.Text = StringResources.BANKENAZIVBANKE2Description;
            this.label1NAZIVBANKE3.Text = StringResources.BANKENAZIVBANKE3Description;
            this.label1MOBANKA.Text = StringResources.BANKEMOBANKADescription;
            this.label1POBANKA.Text = StringResources.BANKEPOBANKADescription;
            this.label1MZBANKA.Text = StringResources.BANKEMZBANKADescription;
            this.label1PZBANKA.Text = StringResources.BANKEPZBANKADescription;
            this.label1SIFRAOPISPLACANJABANKE.Text = StringResources.BANKESIFRAOPISPLACANJABANKEDescription;
            this.label1OPISPLACANJABANKE.Text = StringResources.BANKEOPISPLACANJABANKEDescription;
            this.label1VBDIBANKE.Text = StringResources.BANKEVBDIBANKEDescription;
            this.label1ZRNBANKE.Text = StringResources.BANKEZRNBANKEDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewDDRADNIK")]
        public void NewDDRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.NewDDRADNIK(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewRADNIK")]
        public void NewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.Controller.WorkItem.Items.Contains("BANKE|BANKE"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceBANKE, "BANKE|BANKE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsBANKEDataSet1.BANKE.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.Controller.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.Controller.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.Controller.Update(this))
            {
                this.Controller.DataSet = new BANKEDataSet();
                DataSetUtil.AddEmptyRow(this.Controller.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.Controller.DataSet.BANKE[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDBANKE.Focus();
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

        [LocalCommandHandler("ViewDDRADNIK")]
        public void ViewDDRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.ViewDDRADNIK(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewRADNIK")]
        public void ViewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.ViewRADNIK(this.m_CurrentRow);
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.BANKEController Controller { get; set; }

        private ContextMenu contextMenu1;

        private ErrorProvider errorProvider1;

        private ErrorProviderValidator errorProviderValidator1;

        private UltraLabel label1IDBANKE;

        private UltraLabel label1MOBANKA;

        private UltraLabel label1MZBANKA;

        private UltraLabel label1NAZIVBANKE1;

        private UltraLabel label1NAZIVBANKE2;

        private UltraLabel label1NAZIVBANKE3;

        private UltraLabel label1OPISPLACANJABANKE;

        private UltraLabel label1POBANKA;

        private UltraLabel label1PZBANKA;

        private UltraLabel label1SIFRAOPISPLACANJABANKE;

        private UltraLabel label1VBDIBANKE;

        private UltraLabel label1ZRNBANKE;

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

        private MenuItem SetNullItem;

        private UltraNumericEditor textIDBANKE;

        private UltraTextEditor textMOBANKA;

        private UltraTextEditor textMZBANKA;

        private UltraTextEditor textNAZIVBANKE1;

        private UltraTextEditor textNAZIVBANKE2;

        private UltraTextEditor textNAZIVBANKE3;

        private UltraTextEditor textOPISPLACANJABANKE;

        private UltraTextEditor textPOBANKA;

        private UltraTextEditor textPZBANKA;

        private UltraTextEditor textSIFRAOPISPLACANJABANKE;

        private UltraTextEditor textVBDIBANKE;

        private UltraTextEditor textZRNBANKE;

        private System.Windows.Forms.ToolTip toolTip1;
    }
}

