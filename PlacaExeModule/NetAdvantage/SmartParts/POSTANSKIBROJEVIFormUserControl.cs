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
    public class POSTANSKIBROJEVIFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1NAZIVPOSTE")]
        private UltraLabel _label1NAZIVPOSTE;
        [AccessedThroughProperty("label1POSTANSKIBROJ")]
        private UltraLabel _label1POSTANSKIBROJ;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textNAZIVPOSTE")]
        private UltraTextEditor _textNAZIVPOSTE;
        [AccessedThroughProperty("textPOSTANSKIBROJ")]
        private UltraTextEditor _textPOSTANSKIBROJ;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourcePOSTANSKIBROJEVI;
        private IContainer components = null;
        private POSTANSKIBROJEVIDataSet dsPOSTANSKIBROJEVIDataSet1;
        protected TableLayoutPanel layoutManagerformPOSTANSKIBROJEVI;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "POSTANSKIBROJEVI";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.POSTANSKIBROJEVIDescription;
        private DeklaritMode m_Mode;

        public POSTANSKIBROJEVIFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourcePOSTANSKIBROJEVI.DataSource = this.POSTANSKIBROJEVIController.DataSet;
            this.dsPOSTANSKIBROJEVIDataSet1 = this.POSTANSKIBROJEVIController.DataSet;
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
                    enumerator = this.dsPOSTANSKIBROJEVIDataSet1.POSTANSKIBROJEVI.Rows.GetEnumerator();
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
                if (this.POSTANSKIBROJEVIController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "POSTANSKIBROJEVI", this.m_Mode, this.dsPOSTANSKIBROJEVIDataSet1, this.dsPOSTANSKIBROJEVIDataSet1.POSTANSKIBROJEVI.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsPOSTANSKIBROJEVIDataSet1.POSTANSKIBROJEVI[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow) ((DataRowView) this.bindingSourcePOSTANSKIBROJEVI.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(POSTANSKIBROJEVIFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourcePOSTANSKIBROJEVI = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePOSTANSKIBROJEVI).BeginInit();
            this.layoutManagerformPOSTANSKIBROJEVI = new TableLayoutPanel();
            this.layoutManagerformPOSTANSKIBROJEVI.SuspendLayout();
            this.layoutManagerformPOSTANSKIBROJEVI.AutoSize = true;
            this.layoutManagerformPOSTANSKIBROJEVI.Dock = DockStyle.Fill;
            this.layoutManagerformPOSTANSKIBROJEVI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPOSTANSKIBROJEVI.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPOSTANSKIBROJEVI.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPOSTANSKIBROJEVI.Size = size;
            this.layoutManagerformPOSTANSKIBROJEVI.ColumnCount = 2;
            this.layoutManagerformPOSTANSKIBROJEVI.RowCount = 3;
            this.layoutManagerformPOSTANSKIBROJEVI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPOSTANSKIBROJEVI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPOSTANSKIBROJEVI.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOSTANSKIBROJEVI.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOSTANSKIBROJEVI.RowStyles.Add(new RowStyle());
            this.label1POSTANSKIBROJ = new UltraLabel();
            this.textPOSTANSKIBROJ = new UltraTextEditor();
            this.label1NAZIVPOSTE = new UltraLabel();
            this.textNAZIVPOSTE = new UltraTextEditor();
            ((ISupportInitialize) this.textPOSTANSKIBROJ).BeginInit();
            ((ISupportInitialize) this.textNAZIVPOSTE).BeginInit();
            this.dsPOSTANSKIBROJEVIDataSet1 = new POSTANSKIBROJEVIDataSet();
            this.dsPOSTANSKIBROJEVIDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsPOSTANSKIBROJEVIDataSet1.DataSetName = "dsPOSTANSKIBROJEVI";
            this.dsPOSTANSKIBROJEVIDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourcePOSTANSKIBROJEVI.DataSource = this.dsPOSTANSKIBROJEVIDataSet1;
            this.bindingSourcePOSTANSKIBROJEVI.DataMember = "POSTANSKIBROJEVI";
            ((ISupportInitialize) this.bindingSourcePOSTANSKIBROJEVI).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1POSTANSKIBROJ.Location = point;
            this.label1POSTANSKIBROJ.Name = "label1POSTANSKIBROJ";
            this.label1POSTANSKIBROJ.TabIndex = 1;
            this.label1POSTANSKIBROJ.Tag = "labelPOSTANSKIBROJ";
            this.label1POSTANSKIBROJ.Text = "Poštanski broj:";
            this.label1POSTANSKIBROJ.StyleSetName = "FieldUltraLabel";
            this.label1POSTANSKIBROJ.AutoSize = true;
            this.label1POSTANSKIBROJ.Anchor = AnchorStyles.Left;
            this.label1POSTANSKIBROJ.Appearance.TextVAlign = VAlign.Middle;
            this.label1POSTANSKIBROJ.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1POSTANSKIBROJ.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1POSTANSKIBROJ.ImageSize = size;
            this.label1POSTANSKIBROJ.Appearance.ForeColor = Color.Black;
            this.label1POSTANSKIBROJ.BackColor = Color.Transparent;
            this.layoutManagerformPOSTANSKIBROJEVI.Controls.Add(this.label1POSTANSKIBROJ, 0, 0);
            this.layoutManagerformPOSTANSKIBROJEVI.SetColumnSpan(this.label1POSTANSKIBROJ, 1);
            this.layoutManagerformPOSTANSKIBROJEVI.SetRowSpan(this.label1POSTANSKIBROJ, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1POSTANSKIBROJ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POSTANSKIBROJ.MinimumSize = size;
            size = new System.Drawing.Size(0x69, 0x17);
            this.label1POSTANSKIBROJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOSTANSKIBROJ.Location = point;
            this.textPOSTANSKIBROJ.Name = "textPOSTANSKIBROJ";
            this.textPOSTANSKIBROJ.Tag = "POSTANSKIBROJ";
            this.textPOSTANSKIBROJ.TabIndex = 0;
            this.textPOSTANSKIBROJ.Anchor = AnchorStyles.Left;
            this.textPOSTANSKIBROJ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOSTANSKIBROJ.ReadOnly = false;
            this.textPOSTANSKIBROJ.DataBindings.Add(new Binding("Text", this.bindingSourcePOSTANSKIBROJEVI, "POSTANSKIBROJ"));
            this.textPOSTANSKIBROJ.MaxLength = 5;
            this.layoutManagerformPOSTANSKIBROJEVI.Controls.Add(this.textPOSTANSKIBROJ, 1, 0);
            this.layoutManagerformPOSTANSKIBROJEVI.SetColumnSpan(this.textPOSTANSKIBROJ, 1);
            this.layoutManagerformPOSTANSKIBROJEVI.SetRowSpan(this.textPOSTANSKIBROJ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOSTANSKIBROJ.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textPOSTANSKIBROJ.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textPOSTANSKIBROJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVPOSTE.Location = point;
            this.label1NAZIVPOSTE.Name = "label1NAZIVPOSTE";
            this.label1NAZIVPOSTE.TabIndex = 1;
            this.label1NAZIVPOSTE.Tag = "labelNAZIVPOSTE";
            this.label1NAZIVPOSTE.Text = "Naziv pošte:";
            this.label1NAZIVPOSTE.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVPOSTE.AutoSize = true;
            this.label1NAZIVPOSTE.Anchor = AnchorStyles.Left;
            this.label1NAZIVPOSTE.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVPOSTE.Appearance.ForeColor = Color.Black;
            this.label1NAZIVPOSTE.BackColor = Color.Transparent;
            this.layoutManagerformPOSTANSKIBROJEVI.Controls.Add(this.label1NAZIVPOSTE, 0, 1);
            this.layoutManagerformPOSTANSKIBROJEVI.SetColumnSpan(this.label1NAZIVPOSTE, 1);
            this.layoutManagerformPOSTANSKIBROJEVI.SetRowSpan(this.label1NAZIVPOSTE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVPOSTE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVPOSTE.MinimumSize = size;
            size = new System.Drawing.Size(0x5b, 0x17);
            this.label1NAZIVPOSTE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVPOSTE.Location = point;
            this.textNAZIVPOSTE.Name = "textNAZIVPOSTE";
            this.textNAZIVPOSTE.Tag = "NAZIVPOSTE";
            this.textNAZIVPOSTE.TabIndex = 0;
            this.textNAZIVPOSTE.Anchor = AnchorStyles.Left;
            this.textNAZIVPOSTE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVPOSTE.ReadOnly = false;
            this.textNAZIVPOSTE.DataBindings.Add(new Binding("Text", this.bindingSourcePOSTANSKIBROJEVI, "NAZIVPOSTE"));
            this.textNAZIVPOSTE.MaxLength = 50;
            this.layoutManagerformPOSTANSKIBROJEVI.Controls.Add(this.textNAZIVPOSTE, 1, 1);
            this.layoutManagerformPOSTANSKIBROJEVI.SetColumnSpan(this.textNAZIVPOSTE, 1);
            this.layoutManagerformPOSTANSKIBROJEVI.SetRowSpan(this.textNAZIVPOSTE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVPOSTE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVPOSTE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVPOSTE.Size = size;
            this.Controls.Add(this.layoutManagerformPOSTANSKIBROJEVI);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourcePOSTANSKIBROJEVI;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "POSTANSKIBROJEVIFormUserControl";
            this.Text = "POSTANSKIBROJEVI";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.POSTANSKIBROJEVIFormUserControl_Load);
            this.layoutManagerformPOSTANSKIBROJEVI.ResumeLayout(false);
            this.layoutManagerformPOSTANSKIBROJEVI.PerformLayout();
            ((ISupportInitialize) this.bindingSourcePOSTANSKIBROJEVI).EndInit();
            ((ISupportInitialize) this.textPOSTANSKIBROJ).EndInit();
            ((ISupportInitialize) this.textNAZIVPOSTE).EndInit();
            this.dsPOSTANSKIBROJEVIDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.POSTANSKIBROJEVIController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourcePOSTANSKIBROJEVI, this.POSTANSKIBROJEVIController.WorkItem, this))
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
            this.label1POSTANSKIBROJ.Text = StringResources.POSTANSKIBROJEVIPOSTANSKIBROJDescription;
            this.label1NAZIVPOSTE.Text = StringResources.POSTANSKIBROJEVINAZIVPOSTEDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewUCENIK")]
        public void NewUCENIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.POSTANSKIBROJEVIController.NewUCENIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void POSTANSKIBROJEVIFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.POSTANSKIBROJEVIDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.POSTANSKIBROJEVIController.WorkItem.Items.Contains("POSTANSKIBROJEVI|POSTANSKIBROJEVI"))
            {
                this.POSTANSKIBROJEVIController.WorkItem.Items.Add(this.bindingSourcePOSTANSKIBROJEVI, "POSTANSKIBROJEVI|POSTANSKIBROJEVI");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsPOSTANSKIBROJEVIDataSet1.POSTANSKIBROJEVI.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.POSTANSKIBROJEVIController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.POSTANSKIBROJEVIController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.POSTANSKIBROJEVIController.Update(this))
            {
                this.POSTANSKIBROJEVIController.DataSet = new POSTANSKIBROJEVIDataSet();
                DataSetUtil.AddEmptyRow(this.POSTANSKIBROJEVIController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.POSTANSKIBROJEVIController.DataSet.POSTANSKIBROJEVI[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textPOSTANSKIBROJ.Focus();
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

        [LocalCommandHandler("ViewUCENIK")]
        public void ViewUCENIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.POSTANSKIBROJEVIController.ViewUCENIK(this.m_CurrentRow);
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

        protected virtual UltraLabel label1NAZIVPOSTE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVPOSTE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVPOSTE = value;
            }
        }

        protected virtual UltraLabel label1POSTANSKIBROJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POSTANSKIBROJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POSTANSKIBROJ = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.POSTANSKIBROJEVIController POSTANSKIBROJEVIController { get; set; }

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

        protected virtual UltraTextEditor textNAZIVPOSTE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVPOSTE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVPOSTE = value;
            }
        }

        protected virtual UltraTextEditor textPOSTANSKIBROJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOSTANSKIBROJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOSTANSKIBROJ = value;
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

