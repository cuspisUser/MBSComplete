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
    public class UCENIKRSMIDENTFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1UCENIKRSMIDENT")]
        private UltraLabel _label1UCENIKRSMIDENT;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textUCENIKRSMIDENT")]
        private UltraTextEditor _textUCENIKRSMIDENT;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceUCENIKRSMIDENT;
        private IContainer components = null;
        private UCENIKRSMIDENTDataSet dsUCENIKRSMIDENTDataSet1;
        protected TableLayoutPanel layoutManagerformUCENIKRSMIDENT;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "UCENIKRSMIDENT";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.UCENIKRSMIDENTDescription;
        private DeklaritMode m_Mode;

        public UCENIKRSMIDENTFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceUCENIKRSMIDENT.DataSource = this.UCENIKRSMIDENTController.DataSet;
            this.dsUCENIKRSMIDENTDataSet1 = this.UCENIKRSMIDENTController.DataSet;
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
                    enumerator = this.dsUCENIKRSMIDENTDataSet1.UCENIKRSMIDENT.Rows.GetEnumerator();
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
                if (this.UCENIKRSMIDENTController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "UCENIKRSMIDENT", this.m_Mode, this.dsUCENIKRSMIDENTDataSet1, this.dsUCENIKRSMIDENTDataSet1.UCENIKRSMIDENT.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsUCENIKRSMIDENTDataSet1.UCENIKRSMIDENT[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow) ((DataRowView) this.bindingSourceUCENIKRSMIDENT.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(UCENIKRSMIDENTFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceUCENIKRSMIDENT = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceUCENIKRSMIDENT).BeginInit();
            this.layoutManagerformUCENIKRSMIDENT = new TableLayoutPanel();
            this.layoutManagerformUCENIKRSMIDENT.SuspendLayout();
            this.layoutManagerformUCENIKRSMIDENT.AutoSize = true;
            this.layoutManagerformUCENIKRSMIDENT.Dock = DockStyle.Fill;
            this.layoutManagerformUCENIKRSMIDENT.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformUCENIKRSMIDENT.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformUCENIKRSMIDENT.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformUCENIKRSMIDENT.Size = size;
            this.layoutManagerformUCENIKRSMIDENT.ColumnCount = 2;
            this.layoutManagerformUCENIKRSMIDENT.RowCount = 2;
            this.layoutManagerformUCENIKRSMIDENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformUCENIKRSMIDENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformUCENIKRSMIDENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIKRSMIDENT.RowStyles.Add(new RowStyle());
            this.label1UCENIKRSMIDENT = new UltraLabel();
            this.textUCENIKRSMIDENT = new UltraTextEditor();
            ((ISupportInitialize) this.textUCENIKRSMIDENT).BeginInit();
            this.dsUCENIKRSMIDENTDataSet1 = new UCENIKRSMIDENTDataSet();
            this.dsUCENIKRSMIDENTDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsUCENIKRSMIDENTDataSet1.DataSetName = "dsUCENIKRSMIDENT";
            this.dsUCENIKRSMIDENTDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceUCENIKRSMIDENT.DataSource = this.dsUCENIKRSMIDENTDataSet1;
            this.bindingSourceUCENIKRSMIDENT.DataMember = "UCENIKRSMIDENT";
            ((ISupportInitialize) this.bindingSourceUCENIKRSMIDENT).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1UCENIKRSMIDENT.Location = point;
            this.label1UCENIKRSMIDENT.Name = "label1UCENIKRSMIDENT";
            this.label1UCENIKRSMIDENT.TabIndex = 1;
            this.label1UCENIKRSMIDENT.Tag = "labelUCENIKRSMIDENT";
            this.label1UCENIKRSMIDENT.Text = "UCENIKRSMIDENT:";
            this.label1UCENIKRSMIDENT.StyleSetName = "FieldUltraLabel";
            this.label1UCENIKRSMIDENT.AutoSize = true;
            this.label1UCENIKRSMIDENT.Anchor = AnchorStyles.Left;
            this.label1UCENIKRSMIDENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1UCENIKRSMIDENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1UCENIKRSMIDENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1UCENIKRSMIDENT.ImageSize = size;
            this.label1UCENIKRSMIDENT.Appearance.ForeColor = Color.Black;
            this.label1UCENIKRSMIDENT.BackColor = Color.Transparent;
            this.layoutManagerformUCENIKRSMIDENT.Controls.Add(this.label1UCENIKRSMIDENT, 0, 0);
            this.layoutManagerformUCENIKRSMIDENT.SetColumnSpan(this.label1UCENIKRSMIDENT, 1);
            this.layoutManagerformUCENIKRSMIDENT.SetRowSpan(this.label1UCENIKRSMIDENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1UCENIKRSMIDENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1UCENIKRSMIDENT.MinimumSize = size;
            size = new System.Drawing.Size(0x85, 0x17);
            this.label1UCENIKRSMIDENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textUCENIKRSMIDENT.Location = point;
            this.textUCENIKRSMIDENT.Name = "textUCENIKRSMIDENT";
            this.textUCENIKRSMIDENT.Tag = "UCENIKRSMIDENT";
            this.textUCENIKRSMIDENT.TabIndex = 0;
            this.textUCENIKRSMIDENT.Anchor = AnchorStyles.Left;
            this.textUCENIKRSMIDENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textUCENIKRSMIDENT.ReadOnly = false;
            this.textUCENIKRSMIDENT.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIKRSMIDENT, "UCENIKRSMIDENT"));
            this.textUCENIKRSMIDENT.MaxLength = 4;
            this.layoutManagerformUCENIKRSMIDENT.Controls.Add(this.textUCENIKRSMIDENT, 1, 0);
            this.layoutManagerformUCENIKRSMIDENT.SetColumnSpan(this.textUCENIKRSMIDENT, 1);
            this.layoutManagerformUCENIKRSMIDENT.SetRowSpan(this.textUCENIKRSMIDENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textUCENIKRSMIDENT.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textUCENIKRSMIDENT.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textUCENIKRSMIDENT.Size = size;
            this.Controls.Add(this.layoutManagerformUCENIKRSMIDENT);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceUCENIKRSMIDENT;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "UCENIKRSMIDENTFormUserControl";
            this.Text = "UCENIKRSMIDENT";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.UCENIKRSMIDENTFormUserControl_Load);
            this.layoutManagerformUCENIKRSMIDENT.ResumeLayout(false);
            this.layoutManagerformUCENIKRSMIDENT.PerformLayout();
            ((ISupportInitialize) this.bindingSourceUCENIKRSMIDENT).EndInit();
            ((ISupportInitialize) this.textUCENIKRSMIDENT).EndInit();
            this.dsUCENIKRSMIDENTDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.UCENIKRSMIDENTController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceUCENIKRSMIDENT, this.UCENIKRSMIDENTController.WorkItem, this))
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
            this.label1UCENIKRSMIDENT.Text = StringResources.UCENIKRSMIDENTUCENIKRSMIDENTDescription;
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
            if (!this.UCENIKRSMIDENTController.WorkItem.Items.Contains("UCENIKRSMIDENT|UCENIKRSMIDENT"))
            {
                this.UCENIKRSMIDENTController.WorkItem.Items.Add(this.bindingSourceUCENIKRSMIDENT, "UCENIKRSMIDENT|UCENIKRSMIDENT");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsUCENIKRSMIDENTDataSet1.UCENIKRSMIDENT.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.UCENIKRSMIDENTController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.UCENIKRSMIDENTController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.UCENIKRSMIDENTController.Update(this))
            {
                this.UCENIKRSMIDENTController.DataSet = new UCENIKRSMIDENTDataSet();
                DataSetUtil.AddEmptyRow(this.UCENIKRSMIDENTController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.UCENIKRSMIDENTController.DataSet.UCENIKRSMIDENT[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textUCENIKRSMIDENT.Focus();
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

        private void UCENIKRSMIDENTFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.UCENIKRSMIDENTDescription;
            this.errorProvider1.ContainerControl = this;
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

        protected virtual UltraLabel label1UCENIKRSMIDENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1UCENIKRSMIDENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1UCENIKRSMIDENT = value;
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

        protected virtual UltraTextEditor textUCENIKRSMIDENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textUCENIKRSMIDENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textUCENIKRSMIDENT = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.UCENIKRSMIDENTController UCENIKRSMIDENTController { get; set; }
    }
}

