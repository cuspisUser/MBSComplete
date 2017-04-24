namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using mipsed.application.framework;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class MJESTOTROSKAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDMJESTOTROSKA")]
        private UltraLabel _label1IDMJESTOTROSKA;
        [AccessedThroughProperty("label1mt")]
        private UltraLabel _label1mt;
        [AccessedThroughProperty("label1NAZIVMJESTOTROSKA")]
        private UltraLabel _label1NAZIVMJESTOTROSKA;
        [AccessedThroughProperty("labelmt")]
        private UltraLabel _labelmt;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDMJESTOTROSKA")]
        private UltraNumericEditor _textIDMJESTOTROSKA;
        [AccessedThroughProperty("textNAZIVMJESTOTROSKA")]
        private UltraTextEditor _textNAZIVMJESTOTROSKA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceMJESTOTROSKA;
        private IContainer components;
        private MJESTOTROSKADataSet dsMJESTOTROSKADataSet1;
        protected TableLayoutPanel layoutManagerformMJESTOTROSKA;
        private bool m_AutoNumber;
        private GenericFormClass m_BaseMethods;
        private MJESTOTROSKADataSet.MJESTOTROSKARow m_CurrentRow;
        private ArrayList m_DataGrids;
        private string m_FirstLevelName;
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription;
        private DeklaritMode m_Mode;

        public MJESTOTROSKAFormUserControl()
        {
            base.Load += new EventHandler(this.MJESTOTROSKAFormUserControlL_Load);
            this.components = null;
            this.m_FrameworkDescription = StringResources.MJESTOTROSKADescription;
            this.m_DataGrids = new ArrayList();
            this.m_FirstLevelName = "MJESTOTROSKA";
            this.m_AutoNumber = false;
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceMJESTOTROSKA.DataSource = this.MJESTOTROSKAController.DataSet;
            this.dsMJESTOTROSKADataSet1 = this.MJESTOTROSKAController.DataSet;
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
                    enumerator = this.dsMJESTOTROSKADataSet1.MJESTOTROSKA.Rows.GetEnumerator();
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
                if (this.MJESTOTROSKAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "MJESTOTROSKA", this.m_Mode, this.dsMJESTOTROSKADataSet1, this.dsMJESTOTROSKADataSet1.MJESTOTROSKA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsMJESTOTROSKADataSet1.MJESTOTROSKA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (MJESTOTROSKADataSet.MJESTOTROSKARow) ((DataRowView) this.bindingSourceMJESTOTROSKA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(MJESTOTROSKAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceMJESTOTROSKA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceMJESTOTROSKA).BeginInit();
            this.layoutManagerformMJESTOTROSKA = new TableLayoutPanel();
            this.layoutManagerformMJESTOTROSKA.SuspendLayout();
            this.layoutManagerformMJESTOTROSKA.AutoSize = true;
            this.layoutManagerformMJESTOTROSKA.Dock = DockStyle.Fill;
            this.layoutManagerformMJESTOTROSKA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformMJESTOTROSKA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformMJESTOTROSKA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformMJESTOTROSKA.Size = size;
            this.layoutManagerformMJESTOTROSKA.ColumnCount = 2;
            this.layoutManagerformMJESTOTROSKA.RowCount = 3;
            this.layoutManagerformMJESTOTROSKA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformMJESTOTROSKA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformMJESTOTROSKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformMJESTOTROSKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformMJESTOTROSKA.RowStyles.Add(new RowStyle());
            this.label1IDMJESTOTROSKA = new UltraLabel();
            this.textIDMJESTOTROSKA = new UltraNumericEditor();
            this.label1NAZIVMJESTOTROSKA = new UltraLabel();
            this.textNAZIVMJESTOTROSKA = new UltraTextEditor();
            this.label1mt = new UltraLabel();
            this.labelmt = new UltraLabel();
            ((ISupportInitialize) this.textIDMJESTOTROSKA).BeginInit();
            ((ISupportInitialize) this.textNAZIVMJESTOTROSKA).BeginInit();
            this.dsMJESTOTROSKADataSet1 = new MJESTOTROSKADataSet();
            this.dsMJESTOTROSKADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsMJESTOTROSKADataSet1.DataSetName = "dsMJESTOTROSKA";
            this.dsMJESTOTROSKADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceMJESTOTROSKA.DataSource = this.dsMJESTOTROSKADataSet1;
            this.bindingSourceMJESTOTROSKA.DataMember = "MJESTOTROSKA";
            ((ISupportInitialize) this.bindingSourceMJESTOTROSKA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDMJESTOTROSKA.Location = point;
            this.label1IDMJESTOTROSKA.Name = "label1IDMJESTOTROSKA";
            this.label1IDMJESTOTROSKA.TabIndex = 1;
            this.label1IDMJESTOTROSKA.Tag = "labelIDMJESTOTROSKA";
            this.label1IDMJESTOTROSKA.Text = "Šifra MT:";
            this.label1IDMJESTOTROSKA.StyleSetName = "FieldUltraLabel";
            this.label1IDMJESTOTROSKA.AutoSize = true;
            this.label1IDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.label1IDMJESTOTROSKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDMJESTOTROSKA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDMJESTOTROSKA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDMJESTOTROSKA.ImageSize = size;
            this.label1IDMJESTOTROSKA.Appearance.ForeColor = Color.Black;
            this.label1IDMJESTOTROSKA.BackColor = Color.Transparent;
            this.layoutManagerformMJESTOTROSKA.Controls.Add(this.label1IDMJESTOTROSKA, 0, 0);
            this.layoutManagerformMJESTOTROSKA.SetColumnSpan(this.label1IDMJESTOTROSKA, 1);
            this.layoutManagerformMJESTOTROSKA.SetRowSpan(this.label1IDMJESTOTROSKA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x43, 0x17);
            this.label1IDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDMJESTOTROSKA.Location = point;
            this.textIDMJESTOTROSKA.Name = "textIDMJESTOTROSKA";
            this.textIDMJESTOTROSKA.Tag = "IDMJESTOTROSKA";
            this.textIDMJESTOTROSKA.TabIndex = 0;
            this.textIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.textIDMJESTOTROSKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDMJESTOTROSKA.ReadOnly = false;
            this.textIDMJESTOTROSKA.PromptChar = ' ';
            this.textIDMJESTOTROSKA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDMJESTOTROSKA.DataBindings.Add(new Binding("Value", this.bindingSourceMJESTOTROSKA, "IDMJESTOTROSKA"));
            this.textIDMJESTOTROSKA.NumericType = NumericType.Integer;
            this.textIDMJESTOTROSKA.MaskInput = "{LOC}-nnnnnnnn";
            this.layoutManagerformMJESTOTROSKA.Controls.Add(this.textIDMJESTOTROSKA, 1, 0);
            this.layoutManagerformMJESTOTROSKA.SetColumnSpan(this.textIDMJESTOTROSKA, 1);
            this.layoutManagerformMJESTOTROSKA.SetRowSpan(this.textIDMJESTOTROSKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVMJESTOTROSKA.Location = point;
            this.label1NAZIVMJESTOTROSKA.Name = "label1NAZIVMJESTOTROSKA";
            this.label1NAZIVMJESTOTROSKA.TabIndex = 1;
            this.label1NAZIVMJESTOTROSKA.Tag = "labelNAZIVMJESTOTROSKA";
            this.label1NAZIVMJESTOTROSKA.Text = "Naziv MT:";
            this.label1NAZIVMJESTOTROSKA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVMJESTOTROSKA.AutoSize = true;
            this.label1NAZIVMJESTOTROSKA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1NAZIVMJESTOTROSKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVMJESTOTROSKA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVMJESTOTROSKA.BackColor = Color.Transparent;
            this.layoutManagerformMJESTOTROSKA.Controls.Add(this.label1NAZIVMJESTOTROSKA, 0, 1);
            this.layoutManagerformMJESTOTROSKA.SetColumnSpan(this.label1NAZIVMJESTOTROSKA, 1);
            this.layoutManagerformMJESTOTROSKA.SetRowSpan(this.label1NAZIVMJESTOTROSKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x4c, 0x17);
            this.label1NAZIVMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVMJESTOTROSKA.Location = point;
            this.textNAZIVMJESTOTROSKA.Name = "textNAZIVMJESTOTROSKA";
            this.textNAZIVMJESTOTROSKA.Tag = "NAZIVMJESTOTROSKA";
            this.textNAZIVMJESTOTROSKA.TabIndex = 0;
            this.textNAZIVMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.textNAZIVMJESTOTROSKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVMJESTOTROSKA.ReadOnly = false;
            this.textNAZIVMJESTOTROSKA.DataBindings.Add(new Binding("Text", this.bindingSourceMJESTOTROSKA, "NAZIVMJESTOTROSKA"));
            this.textNAZIVMJESTOTROSKA.Multiline = true;
            this.textNAZIVMJESTOTROSKA.MaxLength = 120;
            this.layoutManagerformMJESTOTROSKA.Controls.Add(this.textNAZIVMJESTOTROSKA, 1, 1);
            this.layoutManagerformMJESTOTROSKA.SetColumnSpan(this.textNAZIVMJESTOTROSKA, 1);
            this.layoutManagerformMJESTOTROSKA.SetRowSpan(this.textNAZIVMJESTOTROSKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.textNAZIVMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.textNAZIVMJESTOTROSKA.Size = size;
            this.textNAZIVMJESTOTROSKA.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.label1mt.Location = point;
            this.label1mt.Name = "label1mt";
            this.label1mt.TabIndex = 1;
            this.label1mt.Tag = "labelmt";
            this.label1mt.Text = "mt:";
            this.label1mt.StyleSetName = "FieldUltraLabel";
            this.label1mt.AutoSize = true;
            this.label1mt.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1mt.Appearance.TextVAlign = VAlign.Middle;
            this.label1mt.Appearance.ForeColor = Color.Black;
            this.label1mt.BackColor = Color.Transparent;
            this.layoutManagerformMJESTOTROSKA.Controls.Add(this.label1mt, 0, 2);
            this.layoutManagerformMJESTOTROSKA.SetColumnSpan(this.label1mt, 1);
            this.layoutManagerformMJESTOTROSKA.SetRowSpan(this.label1mt, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1mt.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1mt.MinimumSize = size;
            size = new System.Drawing.Size(0x24, 0x17);
            this.label1mt.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelmt.Location = point;
            this.labelmt.Name = "labelmt";
            this.labelmt.Tag = "mt";
            this.labelmt.TabIndex = 0;
            this.labelmt.Anchor = AnchorStyles.Left;
            this.labelmt.BackColor = Color.Transparent;
            this.labelmt.DataBindings.Add(new Binding("Text", this.bindingSourceMJESTOTROSKA, "mt"));
            this.labelmt.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformMJESTOTROSKA.Controls.Add(this.labelmt, 1, 2);
            this.layoutManagerformMJESTOTROSKA.SetColumnSpan(this.labelmt, 1);
            this.layoutManagerformMJESTOTROSKA.SetRowSpan(this.labelmt, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelmt.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.labelmt.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.labelmt.Size = size;
            this.labelmt.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformMJESTOTROSKA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceMJESTOTROSKA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "MJESTOTROSKAFormUserControl";
            this.Text = "MJESTOTROSKA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.MJESTOTROSKAFormUserControl_Load);
            this.layoutManagerformMJESTOTROSKA.ResumeLayout(false);
            this.layoutManagerformMJESTOTROSKA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceMJESTOTROSKA).EndInit();
            ((ISupportInitialize) this.textIDMJESTOTROSKA).EndInit();
            ((ISupportInitialize) this.textNAZIVMJESTOTROSKA).EndInit();
            this.dsMJESTOTROSKADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.MJESTOTROSKAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceMJESTOTROSKA, this.MJESTOTROSKAController.WorkItem, this))
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
            this.label1IDMJESTOTROSKA.Text = StringResources.MJESTOTROSKAIDMJESTOTROSKADescription;
            this.label1NAZIVMJESTOTROSKA.Text = StringResources.MJESTOTROSKANAZIVMJESTOTROSKADescription;
            this.label1mt.Text = StringResources.MJESTOTROSKAmtDescription;
        }

        private void MJESTOTROSKAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.MJESTOTROSKADescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void MJESTOTROSKAFormUserControlL_Load(object sender, EventArgs e)
        {
            if (this.Mode == DeklaritMode.Insert)
            {
                ((UltraNumericEditor) this.MJESTOTROSKAController.MJESTOTROSKAFormDefinition.GetControl("textIDMJESTOTROSKA")).Value = 9;
            }
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewGKSTAVKA")]
        public void NewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.MJESTOTROSKAController.NewGKSTAVKA(this.m_CurrentRow);
            }
        }

        public int NUMERACIJA()
        {
            int num = 0;
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text,
                CommandText = "SELECT MAX(CAST(IDMJESTOTROSKA AS INTEGER)) FROM MJESTOTROSKA",
                Connection = connection
            };
            connection.Open();
            try
            {
                num = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(command.ExecuteScalar())));
                num++;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
            connection.Close();
            return num;
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.MJESTOTROSKAController.WorkItem.Items.Contains("MJESTOTROSKA|MJESTOTROSKA"))
            {
                this.MJESTOTROSKAController.WorkItem.Items.Add(this.bindingSourceMJESTOTROSKA, "MJESTOTROSKA|MJESTOTROSKA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsMJESTOTROSKADataSet1.MJESTOTROSKA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.MJESTOTROSKAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.MJESTOTROSKAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.MJESTOTROSKAController.Update(this))
            {
                this.MJESTOTROSKAController.DataSet = new MJESTOTROSKADataSet();
                DataSetUtil.AddEmptyRow(this.MJESTOTROSKAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.MJESTOTROSKAController.DataSet.MJESTOTROSKA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDMJESTOTROSKA.Focus();
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

        [LocalCommandHandler("ViewGKSTAVKA")]
        public void ViewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.MJESTOTROSKAController.ViewGKSTAVKA(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDMJESTOTROSKA = value;
            }
        }

        protected virtual UltraLabel label1mt
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1mt;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1mt = value;
            }
        }

        protected virtual UltraLabel label1NAZIVMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVMJESTOTROSKA = value;
            }
        }

        protected virtual UltraLabel labelmt
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelmt;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelmt = value;
            }
        }

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.MJESTOTROSKAController MJESTOTROSKAController { get; set; }

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

        protected virtual UltraNumericEditor textIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDMJESTOTROSKA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVMJESTOTROSKA = value;
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

