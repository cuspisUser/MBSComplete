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
    public class AKTIVNOSTFormUserControl : UserControl, IBusinessComponentUserControl
    {
        private BindingSource bindingSourceAKTIVNOST;
        private IContainer components = null;
        private AKTIVNOSTDataSet dsAKTIVNOSTDataSet1;
        protected TableLayoutPanel layoutManagerformAKTIVNOST;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private AKTIVNOSTDataSet.AKTIVNOSTRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "AKTIVNOST";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.AKTIVNOSTDescription;
        private DeklaritMode m_Mode;

        public AKTIVNOSTFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void AKTIVNOSTFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.AKTIVNOSTDescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void ChangeBinding()
        {
            this.bindingSourceAKTIVNOST.DataSource = this.Controller.DataSet;
            this.dsAKTIVNOSTDataSet1 = this.Controller.DataSet;
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
                    enumerator = this.dsAKTIVNOSTDataSet1.AKTIVNOST.Rows.GetEnumerator();
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "AKTIVNOST", this.m_Mode, this.dsAKTIVNOSTDataSet1, this.dsAKTIVNOSTDataSet1.AKTIVNOST.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsAKTIVNOSTDataSet1.AKTIVNOST[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (AKTIVNOSTDataSet.AKTIVNOSTRow) ((DataRowView) this.bindingSourceAKTIVNOST.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    this.m_BaseMethods.SetReadOnly(str, true);
                    this.m_BaseMethods.GetLabelControl(str).Visible = false;
                    this.m_BaseMethods.GetControl(str).Visible = false;
                }
            }
            this.SetFocusInFirstField();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.SetNullItem = new System.Windows.Forms.MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSourceAKTIVNOST = new System.Windows.Forms.BindingSource(this.components);
            this.dsAKTIVNOSTDataSet1 = new Placa.AKTIVNOSTDataSet();
            this.errorProviderValidator1 = new Deklarit.Win.ErrorProviderValidator(this.components);
            this.layoutManagerformAKTIVNOST = new System.Windows.Forms.TableLayoutPanel();
            this.label1IDAKTIVNOST = new Infragistics.Win.Misc.UltraLabel();
            this.textIDAKTIVNOST = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1NAZIVAKTIVNOST = new Infragistics.Win.Misc.UltraLabel();
            this.textNAZIVAKTIVNOST = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAKTIVNOST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAKTIVNOSTDataSet1)).BeginInit();
            this.layoutManagerformAKTIVNOST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textIDAKTIVNOST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNAZIVAKTIVNOST)).BeginInit();
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
            this.errorProvider1.DataSource = this.bindingSourceAKTIVNOST;
            // 
            // bindingSourceAKTIVNOST
            // 
            this.bindingSourceAKTIVNOST.DataMember = "AKTIVNOST";
            this.bindingSourceAKTIVNOST.DataSource = this.dsAKTIVNOSTDataSet1;
            // 
            // dsAKTIVNOSTDataSet1
            // 
            this.dsAKTIVNOSTDataSet1.DataSetName = "dsAKTIVNOST";
            this.dsAKTIVNOSTDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // errorProviderValidator1
            // 
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.errorProviderValidator1.ToolTipProvider = null;
            // 
            // layoutManagerformAKTIVNOST
            // 
            this.layoutManagerformAKTIVNOST.AutoSize = true;
            this.layoutManagerformAKTIVNOST.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerformAKTIVNOST.ColumnCount = 2;
            this.layoutManagerformAKTIVNOST.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformAKTIVNOST.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformAKTIVNOST.Controls.Add(this.label1IDAKTIVNOST, 0, 0);
            this.layoutManagerformAKTIVNOST.Controls.Add(this.textIDAKTIVNOST, 1, 0);
            this.layoutManagerformAKTIVNOST.Controls.Add(this.label1NAZIVAKTIVNOST, 0, 1);
            this.layoutManagerformAKTIVNOST.Controls.Add(this.textNAZIVAKTIVNOST, 1, 1);
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerformAKTIVNOST, "");
            this.layoutManagerformAKTIVNOST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutManagerformAKTIVNOST.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerformAKTIVNOST.Name = "layoutManagerformAKTIVNOST";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerformAKTIVNOST, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerformAKTIVNOST, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerformAKTIVNOST, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerformAKTIVNOST, "");
            this.layoutManagerformAKTIVNOST.RowCount = 3;
            this.layoutManagerformAKTIVNOST.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformAKTIVNOST.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformAKTIVNOST.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformAKTIVNOST.Size = new System.Drawing.Size(463, 150);
            this.layoutManagerformAKTIVNOST.TabIndex = 0;
            // 
            // label1IDAKTIVNOST
            // 
            this.label1IDAKTIVNOST.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.TextVAlignAsString = "Middle";
            this.label1IDAKTIVNOST.Appearance = appearance1;
            this.label1IDAKTIVNOST.AutoSize = true;
            this.label1IDAKTIVNOST.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IDAKTIVNOST, "");
            this.label1IDAKTIVNOST.ImageSize = new System.Drawing.Size(7, 10);
            this.label1IDAKTIVNOST.Location = new System.Drawing.Point(3, 5);
            this.label1IDAKTIVNOST.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IDAKTIVNOST.Name = "label1IDAKTIVNOST";
            this.errorProviderValidator1.SetRegularExpression(this.label1IDAKTIVNOST, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IDAKTIVNOST, "");
            this.errorProviderValidator1.SetRequired(this.label1IDAKTIVNOST, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IDAKTIVNOST, "");
            this.label1IDAKTIVNOST.Size = new System.Drawing.Size(81, 14);
            this.label1IDAKTIVNOST.StyleSetName = "FieldUltraLabel";
            this.label1IDAKTIVNOST.TabIndex = 1;
            this.label1IDAKTIVNOST.Tag = "labelIDAKTIVNOST";
            this.label1IDAKTIVNOST.Text = "Šifra aktivnosti:";
            // 
            // textIDAKTIVNOST
            // 
            this.textIDAKTIVNOST.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIDAKTIVNOST.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceAKTIVNOST, "IDAKTIVNOST", true));
            this.errorProviderValidator1.SetDisplayName(this.textIDAKTIVNOST, "");
            this.textIDAKTIVNOST.Location = new System.Drawing.Point(94, 1);
            this.textIDAKTIVNOST.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textIDAKTIVNOST.MaskInput = "{LOC}-nnnnnn";
            this.textIDAKTIVNOST.MinimumSize = new System.Drawing.Size(58, 22);
            this.textIDAKTIVNOST.Name = "textIDAKTIVNOST";
            this.textIDAKTIVNOST.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textIDAKTIVNOST, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIDAKTIVNOST, "");
            this.errorProviderValidator1.SetRequired(this.textIDAKTIVNOST, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIDAKTIVNOST, "");
            this.textIDAKTIVNOST.Size = new System.Drawing.Size(58, 22);
            this.textIDAKTIVNOST.TabIndex = 0;
            this.textIDAKTIVNOST.Tag = "IDAKTIVNOST";
            this.textIDAKTIVNOST.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textIDAKTIVNOST.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1NAZIVAKTIVNOST
            // 
            this.label1NAZIVAKTIVNOST.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.label1NAZIVAKTIVNOST.Appearance = appearance2;
            this.label1NAZIVAKTIVNOST.AutoSize = true;
            this.label1NAZIVAKTIVNOST.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1NAZIVAKTIVNOST, "");
            this.label1NAZIVAKTIVNOST.Location = new System.Drawing.Point(3, 30);
            this.label1NAZIVAKTIVNOST.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1NAZIVAKTIVNOST.Name = "label1NAZIVAKTIVNOST";
            this.errorProviderValidator1.SetRegularExpression(this.label1NAZIVAKTIVNOST, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1NAZIVAKTIVNOST, "");
            this.errorProviderValidator1.SetRequired(this.label1NAZIVAKTIVNOST, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1NAZIVAKTIVNOST, "");
            this.label1NAZIVAKTIVNOST.Size = new System.Drawing.Size(86, 14);
            this.label1NAZIVAKTIVNOST.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVAKTIVNOST.TabIndex = 1;
            this.label1NAZIVAKTIVNOST.Tag = "labelNAZIVAKTIVNOST";
            this.label1NAZIVAKTIVNOST.Text = "Naziv aktivnosti:";
            // 
            // textNAZIVAKTIVNOST
            // 
            this.textNAZIVAKTIVNOST.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textNAZIVAKTIVNOST.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAKTIVNOST, "NAZIVAKTIVNOST", true));
            this.errorProviderValidator1.SetDisplayName(this.textNAZIVAKTIVNOST, "");
            this.textNAZIVAKTIVNOST.Location = new System.Drawing.Point(94, 26);
            this.textNAZIVAKTIVNOST.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textNAZIVAKTIVNOST.MaxLength = 50;
            this.textNAZIVAKTIVNOST.MinimumSize = new System.Drawing.Size(366, 22);
            this.textNAZIVAKTIVNOST.Name = "textNAZIVAKTIVNOST";
            this.errorProviderValidator1.SetRegularExpression(this.textNAZIVAKTIVNOST, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textNAZIVAKTIVNOST, "");
            this.errorProviderValidator1.SetRequired(this.textNAZIVAKTIVNOST, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textNAZIVAKTIVNOST, "");
            this.textNAZIVAKTIVNOST.Size = new System.Drawing.Size(366, 22);
            this.textNAZIVAKTIVNOST.TabIndex = 0;
            this.textNAZIVAKTIVNOST.Tag = "NAZIVAKTIVNOST";
            this.textNAZIVAKTIVNOST.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // AKTIVNOSTFormUserControl
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.layoutManagerformAKTIVNOST);
            this.errorProviderValidator1.SetDisplayName(this, "");
            this.Name = "AKTIVNOSTFormUserControl";
            this.errorProviderValidator1.SetRegularExpression(this, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this, "");
            this.errorProviderValidator1.SetRequired(this, false);
            this.errorProviderValidator1.SetRequiredMessage(this, "");
            this.Size = new System.Drawing.Size(463, 150);
            this.Load += new System.EventHandler(this.AKTIVNOSTFormUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAKTIVNOST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAKTIVNOSTDataSet1)).EndInit();
            this.layoutManagerformAKTIVNOST.ResumeLayout(false);
            this.layoutManagerformAKTIVNOST.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textIDAKTIVNOST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNAZIVAKTIVNOST)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool InValidState()
        {
            if ((this.Controller.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceAKTIVNOST, this.Controller.WorkItem, this))
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
            this.label1IDAKTIVNOST.Text = StringResources.AKTIVNOSTIDAKTIVNOSTDescription;
            this.label1NAZIVAKTIVNOST.Text = StringResources.AKTIVNOSTNAZIVAKTIVNOSTDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewKONTO")]
        public void NewKONTOHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.NewKONTO(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.Controller.WorkItem.Items.Contains("AKTIVNOST|AKTIVNOST"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceAKTIVNOST, "AKTIVNOST|AKTIVNOST");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsAKTIVNOSTDataSet1.AKTIVNOST.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.Controller.DataSet = new AKTIVNOSTDataSet();
                DataSetUtil.AddEmptyRow(this.Controller.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.Controller.DataSet.AKTIVNOST[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDAKTIVNOST.Focus();
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

        [LocalCommandHandler("ViewKONTO")]
        public void ViewKONTOHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.ViewKONTO(this.m_CurrentRow);
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.AKTIVNOSTController Controller { get; set; }

        private ContextMenu contextMenu1;

        private ErrorProvider errorProvider1;

        private ErrorProviderValidator errorProviderValidator1;

        private UltraLabel label1IDAKTIVNOST;

        private UltraLabel label1NAZIVAKTIVNOST;

        public DeklaritMode Mode;

        private MenuItem SetNullItem;

        private UltraNumericEditor textIDAKTIVNOST;

        private UltraTextEditor textNAZIVAKTIVNOST;

        private System.Windows.Forms.ToolTip toolTip1;
    }
}

