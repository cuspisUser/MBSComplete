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
    public class VRSTAOBUSTAVEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1NAZIVVRSTAOBUSTAVE")]
        private UltraLabel _label1NAZIVVRSTAOBUSTAVE;
        [AccessedThroughProperty("label1VRSTAOBUSTAVE")]
        private UltraLabel _label1VRSTAOBUSTAVE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textNAZIVVRSTAOBUSTAVE")]
        private UltraTextEditor _textNAZIVVRSTAOBUSTAVE;
        [AccessedThroughProperty("textVRSTAOBUSTAVE")]
        private UltraNumericEditor _textVRSTAOBUSTAVE;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceVRSTEOBUSTAVA;
        private IContainer components = null;
        private VRSTAOBUSTAVEDataSet dsVRSTAOBUSTAVEDataSet1;
        protected TableLayoutPanel layoutManagerformVRSTEOBUSTAVA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "VRSTEOBUSTAVA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.VRSTAOBUSTAVEDescription;
        private DeklaritMode m_Mode;

        public VRSTAOBUSTAVEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceVRSTEOBUSTAVA.DataSource = this.VRSTAOBUSTAVEController.DataSet;
            this.dsVRSTAOBUSTAVEDataSet1 = this.VRSTAOBUSTAVEController.DataSet;
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
                    enumerator = this.dsVRSTAOBUSTAVEDataSet1.VRSTEOBUSTAVA.Rows.GetEnumerator();
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
                if (this.VRSTAOBUSTAVEController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "VRSTAOBUSTAVE", this.m_Mode, this.dsVRSTAOBUSTAVEDataSet1, this.dsVRSTAOBUSTAVEDataSet1.VRSTEOBUSTAVA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsVRSTAOBUSTAVEDataSet1.VRSTEOBUSTAVA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow) ((DataRowView) this.bindingSourceVRSTEOBUSTAVA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(VRSTAOBUSTAVEFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceVRSTEOBUSTAVA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceVRSTEOBUSTAVA).BeginInit();
            this.layoutManagerformVRSTEOBUSTAVA = new TableLayoutPanel();
            this.layoutManagerformVRSTEOBUSTAVA.SuspendLayout();
            this.layoutManagerformVRSTEOBUSTAVA.AutoSize = true;
            this.layoutManagerformVRSTEOBUSTAVA.Dock = DockStyle.Fill;
            this.layoutManagerformVRSTEOBUSTAVA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformVRSTEOBUSTAVA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformVRSTEOBUSTAVA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformVRSTEOBUSTAVA.Size = size;
            this.layoutManagerformVRSTEOBUSTAVA.ColumnCount = 2;
            this.layoutManagerformVRSTEOBUSTAVA.RowCount = 3;
            this.layoutManagerformVRSTEOBUSTAVA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVRSTEOBUSTAVA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVRSTEOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformVRSTEOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformVRSTEOBUSTAVA.RowStyles.Add(new RowStyle());
            this.label1VRSTAOBUSTAVE = new UltraLabel();
            this.textVRSTAOBUSTAVE = new UltraNumericEditor();
            this.label1NAZIVVRSTAOBUSTAVE = new UltraLabel();
            this.textNAZIVVRSTAOBUSTAVE = new UltraTextEditor();
            ((ISupportInitialize) this.textVRSTAOBUSTAVE).BeginInit();
            ((ISupportInitialize) this.textNAZIVVRSTAOBUSTAVE).BeginInit();
            this.dsVRSTAOBUSTAVEDataSet1 = new VRSTAOBUSTAVEDataSet();
            this.dsVRSTAOBUSTAVEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsVRSTAOBUSTAVEDataSet1.DataSetName = "dsVRSTAOBUSTAVE";
            this.dsVRSTAOBUSTAVEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceVRSTEOBUSTAVA.DataSource = this.dsVRSTAOBUSTAVEDataSet1;
            this.bindingSourceVRSTEOBUSTAVA.DataMember = "VRSTEOBUSTAVA";
            ((ISupportInitialize) this.bindingSourceVRSTEOBUSTAVA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1VRSTAOBUSTAVE.Location = point;
            this.label1VRSTAOBUSTAVE.Name = "label1VRSTAOBUSTAVE";
            this.label1VRSTAOBUSTAVE.TabIndex = 1;
            this.label1VRSTAOBUSTAVE.Tag = "labelVRSTAOBUSTAVE";
            this.label1VRSTAOBUSTAVE.Text = "Šifra:";
            this.label1VRSTAOBUSTAVE.StyleSetName = "FieldUltraLabel";
            this.label1VRSTAOBUSTAVE.AutoSize = true;
            this.label1VRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.label1VRSTAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1VRSTAOBUSTAVE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1VRSTAOBUSTAVE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1VRSTAOBUSTAVE.ImageSize = size;
            this.label1VRSTAOBUSTAVE.Appearance.ForeColor = Color.Black;
            this.label1VRSTAOBUSTAVE.BackColor = Color.Transparent;
            this.layoutManagerformVRSTEOBUSTAVA.Controls.Add(this.label1VRSTAOBUSTAVE, 0, 0);
            this.layoutManagerformVRSTEOBUSTAVA.SetColumnSpan(this.label1VRSTAOBUSTAVE, 1);
            this.layoutManagerformVRSTEOBUSTAVA.SetRowSpan(this.label1VRSTAOBUSTAVE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1VRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1VRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVRSTAOBUSTAVE.Location = point;
            this.textVRSTAOBUSTAVE.Name = "textVRSTAOBUSTAVE";
            this.textVRSTAOBUSTAVE.Tag = "VRSTAOBUSTAVE";
            this.textVRSTAOBUSTAVE.TabIndex = 0;
            this.textVRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.textVRSTAOBUSTAVE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVRSTAOBUSTAVE.ReadOnly = false;
            this.textVRSTAOBUSTAVE.PromptChar = ' ';
            this.textVRSTAOBUSTAVE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textVRSTAOBUSTAVE.DataBindings.Add(new Binding("Value", this.bindingSourceVRSTEOBUSTAVA, "VRSTAOBUSTAVE"));
            this.textVRSTAOBUSTAVE.NumericType = NumericType.Integer;
            this.textVRSTAOBUSTAVE.MaskInput = "{LOC}-nn";
            this.layoutManagerformVRSTEOBUSTAVA.Controls.Add(this.textVRSTAOBUSTAVE, 1, 0);
            this.layoutManagerformVRSTEOBUSTAVA.SetColumnSpan(this.textVRSTAOBUSTAVE, 1);
            this.layoutManagerformVRSTEOBUSTAVA.SetRowSpan(this.textVRSTAOBUSTAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textVRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textVRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVVRSTAOBUSTAVE.Location = point;
            this.label1NAZIVVRSTAOBUSTAVE.Name = "label1NAZIVVRSTAOBUSTAVE";
            this.label1NAZIVVRSTAOBUSTAVE.TabIndex = 1;
            this.label1NAZIVVRSTAOBUSTAVE.Tag = "labelNAZIVVRSTAOBUSTAVE";
            this.label1NAZIVVRSTAOBUSTAVE.Text = "Vrsta obustave:";
            this.label1NAZIVVRSTAOBUSTAVE.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVVRSTAOBUSTAVE.AutoSize = true;
            this.label1NAZIVVRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.label1NAZIVVRSTAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVVRSTAOBUSTAVE.Appearance.ForeColor = Color.Black;
            this.label1NAZIVVRSTAOBUSTAVE.BackColor = Color.Transparent;
            this.layoutManagerformVRSTEOBUSTAVA.Controls.Add(this.label1NAZIVVRSTAOBUSTAVE, 0, 1);
            this.layoutManagerformVRSTEOBUSTAVA.SetColumnSpan(this.label1NAZIVVRSTAOBUSTAVE, 1);
            this.layoutManagerformVRSTEOBUSTAVA.SetRowSpan(this.label1NAZIVVRSTAOBUSTAVE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVVRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVVRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x70, 0x17);
            this.label1NAZIVVRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVVRSTAOBUSTAVE.Location = point;
            this.textNAZIVVRSTAOBUSTAVE.Name = "textNAZIVVRSTAOBUSTAVE";
            this.textNAZIVVRSTAOBUSTAVE.Tag = "NAZIVVRSTAOBUSTAVE";
            this.textNAZIVVRSTAOBUSTAVE.TabIndex = 0;
            this.textNAZIVVRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.textNAZIVVRSTAOBUSTAVE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVVRSTAOBUSTAVE.ReadOnly = false;
            this.textNAZIVVRSTAOBUSTAVE.DataBindings.Add(new Binding("Text", this.bindingSourceVRSTEOBUSTAVA, "NAZIVVRSTAOBUSTAVE"));
            this.textNAZIVVRSTAOBUSTAVE.MaxLength = 50;
            this.layoutManagerformVRSTEOBUSTAVA.Controls.Add(this.textNAZIVVRSTAOBUSTAVE, 1, 1);
            this.layoutManagerformVRSTEOBUSTAVA.SetColumnSpan(this.textNAZIVVRSTAOBUSTAVE, 1);
            this.layoutManagerformVRSTEOBUSTAVA.SetRowSpan(this.textNAZIVVRSTAOBUSTAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVVRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVVRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVVRSTAOBUSTAVE.Size = size;
            this.Controls.Add(this.layoutManagerformVRSTEOBUSTAVA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceVRSTEOBUSTAVA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "VRSTAOBUSTAVEFormUserControl";
            this.Text = "Vrste obustava";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.VRSTAOBUSTAVEFormUserControl_Load);
            this.layoutManagerformVRSTEOBUSTAVA.ResumeLayout(false);
            this.layoutManagerformVRSTEOBUSTAVA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceVRSTEOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textVRSTAOBUSTAVE).EndInit();
            ((ISupportInitialize) this.textNAZIVVRSTAOBUSTAVE).EndInit();
            this.dsVRSTAOBUSTAVEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.VRSTAOBUSTAVEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceVRSTEOBUSTAVA, this.VRSTAOBUSTAVEController.WorkItem, this))
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
            this.label1VRSTAOBUSTAVE.Text = StringResources.VRSTAOBUSTAVEVRSTAOBUSTAVEDescription;
            this.label1NAZIVVRSTAOBUSTAVE.Text = StringResources.VRSTAOBUSTAVENAZIVVRSTAOBUSTAVEDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewOBUSTAVA")]
        public void NewOBUSTAVAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.VRSTAOBUSTAVEController.NewOBUSTAVA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.VRSTAOBUSTAVEController.WorkItem.Items.Contains("VRSTEOBUSTAVA|VRSTEOBUSTAVA"))
            {
                this.VRSTAOBUSTAVEController.WorkItem.Items.Add(this.bindingSourceVRSTEOBUSTAVA, "VRSTEOBUSTAVA|VRSTEOBUSTAVA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsVRSTAOBUSTAVEDataSet1.VRSTEOBUSTAVA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.VRSTAOBUSTAVEController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.VRSTAOBUSTAVEController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.VRSTAOBUSTAVEController.Update(this))
            {
                this.VRSTAOBUSTAVEController.DataSet = new VRSTAOBUSTAVEDataSet();
                DataSetUtil.AddEmptyRow(this.VRSTAOBUSTAVEController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.VRSTAOBUSTAVEController.DataSet.VRSTEOBUSTAVA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textVRSTAOBUSTAVE.Focus();
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

        [LocalCommandHandler("ViewOBUSTAVA")]
        public void ViewOBUSTAVAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.VRSTAOBUSTAVEController.ViewOBUSTAVA(this.m_CurrentRow);
            }
        }

        private void VRSTAOBUSTAVEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.VRSTAOBUSTAVEDescription;
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

        protected virtual UltraLabel label1NAZIVVRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVVRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVVRSTAOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel label1VRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VRSTAOBUSTAVE = value;
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

        protected virtual UltraTextEditor textNAZIVVRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVVRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVVRSTAOBUSTAVE = value;
            }
        }

        protected virtual UltraNumericEditor textVRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVRSTAOBUSTAVE = value;
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
        public NetAdvantage.Controllers.VRSTAOBUSTAVEController VRSTAOBUSTAVEController { get; set; }
    }
}

