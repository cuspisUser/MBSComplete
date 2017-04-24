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
    public class BENEFICIRANIFormUserControl : UserControl, IBusinessComponentUserControl
    {
        private BindingSource bindingSourceBENEFICIRANI;
        private IContainer components = null;
        private BENEFICIRANIDataSet dsBENEFICIRANIDataSet1;
        protected TableLayoutPanel layoutManagerformBENEFICIRANI;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private BENEFICIRANIDataSet.BENEFICIRANIRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "BENEFICIRANI";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.BENEFICIRANIDescription;
        private DeklaritMode m_Mode;

        public BENEFICIRANIFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void BENEFICIRANIFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.BENEFICIRANIDescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void ChangeBinding()
        {
            this.bindingSourceBENEFICIRANI.DataSource = this.Controller.DataSet;
            this.dsBENEFICIRANIDataSet1 = this.Controller.DataSet;
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
                    enumerator = this.dsBENEFICIRANIDataSet1.BENEFICIRANI.Rows.GetEnumerator();
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "BENEFICIRANI", this.m_Mode, this.dsBENEFICIRANIDataSet1, this.dsBENEFICIRANIDataSet1.BENEFICIRANI.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsBENEFICIRANIDataSet1.BENEFICIRANI[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (BENEFICIRANIDataSet.BENEFICIRANIRow) ((DataRowView) this.bindingSourceBENEFICIRANI.AddNew()).Row;
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.SetNullItem = new System.Windows.Forms.MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSourceBENEFICIRANI = new System.Windows.Forms.BindingSource(this.components);
            this.dsBENEFICIRANIDataSet1 = new Placa.BENEFICIRANIDataSet();
            this.errorProviderValidator1 = new Deklarit.Win.ErrorProviderValidator(this.components);
            this.layoutManagerformBENEFICIRANI = new System.Windows.Forms.TableLayoutPanel();
            this.label1IDBENEFICIRANI = new Infragistics.Win.Misc.UltraLabel();
            this.textIDBENEFICIRANI = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1NAZIVBENEFICIRANI = new Infragistics.Win.Misc.UltraLabel();
            this.textNAZIVBENEFICIRANI = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1BROJPRIZNATIHMJESECI = new Infragistics.Win.Misc.UltraLabel();
            this.textBROJPRIZNATIHMJESECI = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBENEFICIRANI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBENEFICIRANIDataSet1)).BeginInit();
            this.layoutManagerformBENEFICIRANI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textIDBENEFICIRANI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNAZIVBENEFICIRANI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBROJPRIZNATIHMJESECI)).BeginInit();
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
            this.errorProvider1.DataSource = this.bindingSourceBENEFICIRANI;
            // 
            // bindingSourceBENEFICIRANI
            // 
            this.bindingSourceBENEFICIRANI.DataMember = "BENEFICIRANI";
            this.bindingSourceBENEFICIRANI.DataSource = this.dsBENEFICIRANIDataSet1;
            // 
            // dsBENEFICIRANIDataSet1
            // 
            this.dsBENEFICIRANIDataSet1.DataSetName = "dsBENEFICIRANI";
            this.dsBENEFICIRANIDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // errorProviderValidator1
            // 
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.errorProviderValidator1.ToolTipProvider = null;
            // 
            // layoutManagerformBENEFICIRANI
            // 
            this.layoutManagerformBENEFICIRANI.AutoSize = true;
            this.layoutManagerformBENEFICIRANI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerformBENEFICIRANI.ColumnCount = 2;
            this.layoutManagerformBENEFICIRANI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBENEFICIRANI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBENEFICIRANI.Controls.Add(this.label1IDBENEFICIRANI, 0, 0);
            this.layoutManagerformBENEFICIRANI.Controls.Add(this.textIDBENEFICIRANI, 1, 0);
            this.layoutManagerformBENEFICIRANI.Controls.Add(this.label1NAZIVBENEFICIRANI, 0, 1);
            this.layoutManagerformBENEFICIRANI.Controls.Add(this.textNAZIVBENEFICIRANI, 1, 1);
            this.layoutManagerformBENEFICIRANI.Controls.Add(this.label1BROJPRIZNATIHMJESECI, 0, 2);
            this.layoutManagerformBENEFICIRANI.Controls.Add(this.textBROJPRIZNATIHMJESECI, 1, 2);
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerformBENEFICIRANI, "");
            this.layoutManagerformBENEFICIRANI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutManagerformBENEFICIRANI.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerformBENEFICIRANI.Name = "layoutManagerformBENEFICIRANI";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerformBENEFICIRANI, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerformBENEFICIRANI, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerformBENEFICIRANI, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerformBENEFICIRANI, "");
            this.layoutManagerformBENEFICIRANI.RowCount = 4;
            this.layoutManagerformBENEFICIRANI.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBENEFICIRANI.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBENEFICIRANI.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBENEFICIRANI.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformBENEFICIRANI.Size = new System.Drawing.Size(590, 150);
            this.layoutManagerformBENEFICIRANI.TabIndex = 0;
            // 
            // label1IDBENEFICIRANI
            // 
            this.label1IDBENEFICIRANI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.TextVAlignAsString = "Middle";
            this.label1IDBENEFICIRANI.Appearance = appearance1;
            this.label1IDBENEFICIRANI.AutoSize = true;
            this.label1IDBENEFICIRANI.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IDBENEFICIRANI, "");
            this.label1IDBENEFICIRANI.ImageSize = new System.Drawing.Size(7, 10);
            this.label1IDBENEFICIRANI.Location = new System.Drawing.Point(3, 5);
            this.label1IDBENEFICIRANI.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IDBENEFICIRANI.Name = "label1IDBENEFICIRANI";
            this.errorProviderValidator1.SetRegularExpression(this.label1IDBENEFICIRANI, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IDBENEFICIRANI, "");
            this.errorProviderValidator1.SetRequired(this.label1IDBENEFICIRANI, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IDBENEFICIRANI, "");
            this.label1IDBENEFICIRANI.Size = new System.Drawing.Size(170, 14);
            this.label1IDBENEFICIRANI.StyleSetName = "FieldUltraLabel";
            this.label1IDBENEFICIRANI.TabIndex = 1;
            this.label1IDBENEFICIRANI.Tag = "labelIDBENEFICIRANI";
            this.label1IDBENEFICIRANI.Text = "Šifra beneficiranog radnog staža:";
            // 
            // textIDBENEFICIRANI
            // 
            this.textIDBENEFICIRANI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIDBENEFICIRANI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBENEFICIRANI, "IDBENEFICIRANI", true));
            this.errorProviderValidator1.SetDisplayName(this.textIDBENEFICIRANI, "");
            this.textIDBENEFICIRANI.Location = new System.Drawing.Point(221, 1);
            this.textIDBENEFICIRANI.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textIDBENEFICIRANI.MaxLength = 1;
            this.textIDBENEFICIRANI.MinimumSize = new System.Drawing.Size(23, 22);
            this.textIDBENEFICIRANI.Name = "textIDBENEFICIRANI";
            this.errorProviderValidator1.SetRegularExpression(this.textIDBENEFICIRANI, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIDBENEFICIRANI, "");
            this.errorProviderValidator1.SetRequired(this.textIDBENEFICIRANI, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIDBENEFICIRANI, "");
            this.textIDBENEFICIRANI.Size = new System.Drawing.Size(23, 22);
            this.textIDBENEFICIRANI.TabIndex = 0;
            this.textIDBENEFICIRANI.Tag = "IDBENEFICIRANI";
            this.textIDBENEFICIRANI.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1NAZIVBENEFICIRANI
            // 
            this.label1NAZIVBENEFICIRANI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.label1NAZIVBENEFICIRANI.Appearance = appearance2;
            this.label1NAZIVBENEFICIRANI.AutoSize = true;
            this.label1NAZIVBENEFICIRANI.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1NAZIVBENEFICIRANI, "");
            this.label1NAZIVBENEFICIRANI.Location = new System.Drawing.Point(3, 29);
            this.label1NAZIVBENEFICIRANI.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1NAZIVBENEFICIRANI.Name = "label1NAZIVBENEFICIRANI";
            this.errorProviderValidator1.SetRegularExpression(this.label1NAZIVBENEFICIRANI, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1NAZIVBENEFICIRANI, "");
            this.errorProviderValidator1.SetRequired(this.label1NAZIVBENEFICIRANI, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1NAZIVBENEFICIRANI, "");
            this.label1NAZIVBENEFICIRANI.Size = new System.Drawing.Size(175, 14);
            this.label1NAZIVBENEFICIRANI.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVBENEFICIRANI.TabIndex = 1;
            this.label1NAZIVBENEFICIRANI.Tag = "labelNAZIVBENEFICIRANI";
            this.label1NAZIVBENEFICIRANI.Text = "Naziv beneficiranog radnog staža:";
            // 
            // textNAZIVBENEFICIRANI
            // 
            this.textNAZIVBENEFICIRANI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textNAZIVBENEFICIRANI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBENEFICIRANI, "NAZIVBENEFICIRANI", true));
            this.errorProviderValidator1.SetDisplayName(this.textNAZIVBENEFICIRANI, "");
            this.textNAZIVBENEFICIRANI.Location = new System.Drawing.Point(221, 26);
            this.textNAZIVBENEFICIRANI.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textNAZIVBENEFICIRANI.MaxLength = 50;
            this.textNAZIVBENEFICIRANI.MinimumSize = new System.Drawing.Size(366, 22);
            this.textNAZIVBENEFICIRANI.Name = "textNAZIVBENEFICIRANI";
            this.errorProviderValidator1.SetRegularExpression(this.textNAZIVBENEFICIRANI, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textNAZIVBENEFICIRANI, "");
            this.errorProviderValidator1.SetRequired(this.textNAZIVBENEFICIRANI, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textNAZIVBENEFICIRANI, "");
            this.textNAZIVBENEFICIRANI.Size = new System.Drawing.Size(366, 22);
            this.textNAZIVBENEFICIRANI.TabIndex = 0;
            this.textNAZIVBENEFICIRANI.Tag = "NAZIVBENEFICIRANI";
            this.textNAZIVBENEFICIRANI.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1BROJPRIZNATIHMJESECI
            // 
            this.label1BROJPRIZNATIHMJESECI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.label1BROJPRIZNATIHMJESECI.Appearance = appearance3;
            this.label1BROJPRIZNATIHMJESECI.AutoSize = true;
            this.label1BROJPRIZNATIHMJESECI.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1BROJPRIZNATIHMJESECI, "");
            this.label1BROJPRIZNATIHMJESECI.Location = new System.Drawing.Point(3, 53);
            this.label1BROJPRIZNATIHMJESECI.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1BROJPRIZNATIHMJESECI.Name = "label1BROJPRIZNATIHMJESECI";
            this.errorProviderValidator1.SetRegularExpression(this.label1BROJPRIZNATIHMJESECI, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1BROJPRIZNATIHMJESECI, "");
            this.errorProviderValidator1.SetRequired(this.label1BROJPRIZNATIHMJESECI, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1BROJPRIZNATIHMJESECI, "");
            this.label1BROJPRIZNATIHMJESECI.Size = new System.Drawing.Size(213, 14);
            this.label1BROJPRIZNATIHMJESECI.StyleSetName = "FieldUltraLabel";
            this.label1BROJPRIZNATIHMJESECI.TabIndex = 1;
            this.label1BROJPRIZNATIHMJESECI.Tag = "labelBROJPRIZNATIHMJESECI";
            this.label1BROJPRIZNATIHMJESECI.Text = "Broj priznatih mjeseci za 12 mjeseci rada:";
            // 
            // textBROJPRIZNATIHMJESECI
            // 
            this.textBROJPRIZNATIHMJESECI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBROJPRIZNATIHMJESECI.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceBENEFICIRANI, "BROJPRIZNATIHMJESECI", true));
            this.errorProviderValidator1.SetDisplayName(this.textBROJPRIZNATIHMJESECI, "");
            this.textBROJPRIZNATIHMJESECI.Location = new System.Drawing.Point(221, 50);
            this.textBROJPRIZNATIHMJESECI.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textBROJPRIZNATIHMJESECI.MaskInput = "{LOC}-nn";
            this.textBROJPRIZNATIHMJESECI.MinimumSize = new System.Drawing.Size(31, 22);
            this.textBROJPRIZNATIHMJESECI.Name = "textBROJPRIZNATIHMJESECI";
            this.textBROJPRIZNATIHMJESECI.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textBROJPRIZNATIHMJESECI, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textBROJPRIZNATIHMJESECI, "");
            this.errorProviderValidator1.SetRequired(this.textBROJPRIZNATIHMJESECI, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textBROJPRIZNATIHMJESECI, "");
            this.textBROJPRIZNATIHMJESECI.Size = new System.Drawing.Size(31, 22);
            this.textBROJPRIZNATIHMJESECI.TabIndex = 0;
            this.textBROJPRIZNATIHMJESECI.Tag = "BROJPRIZNATIHMJESECI";
            this.textBROJPRIZNATIHMJESECI.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textBROJPRIZNATIHMJESECI.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // BENEFICIRANIFormUserControl
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.layoutManagerformBENEFICIRANI);
            this.errorProviderValidator1.SetDisplayName(this, "");
            this.Name = "BENEFICIRANIFormUserControl";
            this.errorProviderValidator1.SetRegularExpression(this, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this, "");
            this.errorProviderValidator1.SetRequired(this, false);
            this.errorProviderValidator1.SetRequiredMessage(this, "");
            this.Size = new System.Drawing.Size(590, 150);
            this.Load += new System.EventHandler(this.BENEFICIRANIFormUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBENEFICIRANI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBENEFICIRANIDataSet1)).EndInit();
            this.layoutManagerformBENEFICIRANI.ResumeLayout(false);
            this.layoutManagerformBENEFICIRANI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textIDBENEFICIRANI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNAZIVBENEFICIRANI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBROJPRIZNATIHMJESECI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool InValidState()
        {
            if ((this.Controller.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceBENEFICIRANI, this.Controller.WorkItem, this))
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
            this.label1IDBENEFICIRANI.Text = StringResources.BENEFICIRANIIDBENEFICIRANIDescription;
            this.label1NAZIVBENEFICIRANI.Text = StringResources.BENEFICIRANINAZIVBENEFICIRANIDescription;
            this.label1BROJPRIZNATIHMJESECI.Text = StringResources.BENEFICIRANIBROJPRIZNATIHMJESECIDescription;
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
                this.Controller.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.Controller.WorkItem.Items.Contains("BENEFICIRANI|BENEFICIRANI"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceBENEFICIRANI, "BENEFICIRANI|BENEFICIRANI");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsBENEFICIRANIDataSet1.BENEFICIRANI.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.Controller.DataSet = new BENEFICIRANIDataSet();
                DataSetUtil.AddEmptyRow(this.Controller.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.Controller.DataSet.BENEFICIRANI[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDBENEFICIRANI.Focus();
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

        [LocalCommandHandler("ViewRADNIK")]
        public void ViewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.ViewRADNIK(this.m_CurrentRow);
            }
        }

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.BENEFICIRANIController Controller { get; set; }

        private ContextMenu contextMenu1;

        private ErrorProvider errorProvider1;

        private ErrorProviderValidator errorProviderValidator1;

        private UltraLabel label1BROJPRIZNATIHMJESECI;

        private UltraLabel label1IDBENEFICIRANI;

        private UltraLabel label1NAZIVBENEFICIRANI;

        public DeklaritMode Mode;

        private MenuItem SetNullItem;

        private UltraNumericEditor textBROJPRIZNATIHMJESECI;

        private UltraTextEditor textIDBENEFICIRANI;

        private UltraTextEditor textNAZIVBENEFICIRANI;

        private System.Windows.Forms.ToolTip toolTip1;
    }
}

