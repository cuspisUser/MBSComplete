namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.Controls;
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
    public class PLANFormPLANORGKONUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboPLANKONTOIDKONTO")]
        private KONTOComboBox _comboPLANKONTOIDKONTO;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1PLANIRANIIZNOS")]
        private UltraLabel _label1PLANIRANIIZNOS;
        [AccessedThroughProperty("label1PLANKONTOIDKONTO")]
        private UltraLabel _label1PLANKONTOIDKONTO;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textPLANIRANIIZNOS")]
        private UltraNumericEditor _textPLANIRANIIZNOS;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourcePLANORGKON;
        private IContainer components = null;
        private PLANDataSet dsPLANDataSet1;
        protected TableLayoutPanel layoutManagerformPLANORGKON;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private PLANDataSet.PLANORGKONRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "PLANORGKON";
        private string m_FrameworkDescription = StringResources.PLANDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public PLANFormPLANORGKONUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("PLANORGKONAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("PLANORGKONAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (PLANDataSet.PLANORGKONRow) ((DataRowView) this.bindingSourcePLANORGKON.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsPLANDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourcePLANORGKON.DataSource = this.PLANController.DataSet;
            this.dsPLANDataSet1 = this.PLANController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void comboPLANKONTOIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            this.comboPLANKONTOIDKONTO.Fill();
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
            this.dsPLANDataSet1 = (PLANDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourcePLANORGKON.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsPLANDataSet1.Tables["PLANORGKON"]);
            this.bindingSourcePLANORGKON.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "PLAN", this.m_Mode, this.dsPLANDataSet1, this.dsPLANDataSet1.PLANORGKON.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (PLANDataSet.PLANORGKONRow) ((DataRowView) this.bindingSourcePLANORGKON.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (PLANDataSet.PLANORGKONRow) ((DataRowView) this.bindingSourcePLANORGKON.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(PLANFormPLANORGKONUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourcePLANORGKON = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePLANORGKON).BeginInit();
            this.layoutManagerformPLANORGKON = new TableLayoutPanel();
            this.layoutManagerformPLANORGKON.SuspendLayout();
            this.layoutManagerformPLANORGKON.AutoSize = true;
            this.layoutManagerformPLANORGKON.Dock = DockStyle.Fill;
            this.layoutManagerformPLANORGKON.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPLANORGKON.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPLANORGKON.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPLANORGKON.Size = size;
            this.layoutManagerformPLANORGKON.ColumnCount = 2;
            this.layoutManagerformPLANORGKON.RowCount = 3;
            this.layoutManagerformPLANORGKON.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPLANORGKON.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPLANORGKON.RowStyles.Add(new RowStyle());
            this.layoutManagerformPLANORGKON.RowStyles.Add(new RowStyle());
            this.layoutManagerformPLANORGKON.RowStyles.Add(new RowStyle());
            this.label1PLANKONTOIDKONTO = new UltraLabel();
            this.comboPLANKONTOIDKONTO = new KONTOComboBox();
            this.label1PLANIRANIIZNOS = new UltraLabel();
            this.textPLANIRANIIZNOS = new UltraNumericEditor();
            ((ISupportInitialize) this.textPLANIRANIIZNOS).BeginInit();
            this.dsPLANDataSet1 = new PLANDataSet();
            this.dsPLANDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsPLANDataSet1.DataSetName = "dsPLAN";
            this.dsPLANDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourcePLANORGKON.DataSource = this.dsPLANDataSet1;
            this.bindingSourcePLANORGKON.DataMember = "PLANORGKON";
            ((ISupportInitialize) this.bindingSourcePLANORGKON).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1PLANKONTOIDKONTO.Location = point;
            this.label1PLANKONTOIDKONTO.Name = "label1PLANKONTOIDKONTO";
            this.label1PLANKONTOIDKONTO.TabIndex = 1;
            this.label1PLANKONTOIDKONTO.Tag = "labelPLANKONTOIDKONTO";
            this.label1PLANKONTOIDKONTO.Text = "Konto:";
            this.label1PLANKONTOIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1PLANKONTOIDKONTO.AutoSize = true;
            this.label1PLANKONTOIDKONTO.Anchor = AnchorStyles.Left;
            this.label1PLANKONTOIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1PLANKONTOIDKONTO.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1PLANKONTOIDKONTO.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1PLANKONTOIDKONTO.ImageSize = size;
            this.label1PLANKONTOIDKONTO.Appearance.ForeColor = Color.Black;
            this.label1PLANKONTOIDKONTO.BackColor = Color.Transparent;
            this.layoutManagerformPLANORGKON.Controls.Add(this.label1PLANKONTOIDKONTO, 0, 0);
            this.layoutManagerformPLANORGKON.SetColumnSpan(this.label1PLANKONTOIDKONTO, 1);
            this.layoutManagerformPLANORGKON.SetRowSpan(this.label1PLANKONTOIDKONTO, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1PLANKONTOIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PLANKONTOIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1PLANKONTOIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboPLANKONTOIDKONTO.Location = point;
            this.comboPLANKONTOIDKONTO.Name = "comboPLANKONTOIDKONTO";
            this.comboPLANKONTOIDKONTO.Tag = "PLANKONTOIDKONTO";
            this.comboPLANKONTOIDKONTO.TabIndex = 0;
            this.comboPLANKONTOIDKONTO.Anchor = AnchorStyles.Left;
            this.comboPLANKONTOIDKONTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboPLANKONTOIDKONTO.DropDownStyle = DropDownStyle.DropDown;
            this.comboPLANKONTOIDKONTO.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboPLANKONTOIDKONTO.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboPLANKONTOIDKONTO.Enabled = true;
            this.comboPLANKONTOIDKONTO.DataBindings.Add(new Binding("Value", this.bindingSourcePLANORGKON, "PLANKONTOIDKONTO"));
            this.comboPLANKONTOIDKONTO.ShowPictureBox = true;
            this.comboPLANKONTOIDKONTO.PictureBoxClicked += new EventHandler(this.PictureBoxClickedPLANKONTOIDKONTO);
            this.comboPLANKONTOIDKONTO.ValueMember = "IDKONTO";
            this.comboPLANKONTOIDKONTO.SelectionChanged += new EventHandler(this.SelectedIndexChangedPLANKONTOIDKONTO);
            this.layoutManagerformPLANORGKON.Controls.Add(this.comboPLANKONTOIDKONTO, 1, 0);
            this.layoutManagerformPLANORGKON.SetColumnSpan(this.comboPLANKONTOIDKONTO, 1);
            this.layoutManagerformPLANORGKON.SetRowSpan(this.comboPLANKONTOIDKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboPLANKONTOIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboPLANKONTOIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboPLANKONTOIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PLANIRANIIZNOS.Location = point;
            this.label1PLANIRANIIZNOS.Name = "label1PLANIRANIIZNOS";
            this.label1PLANIRANIIZNOS.TabIndex = 1;
            this.label1PLANIRANIIZNOS.Tag = "labelPLANIRANIIZNOS";
            this.label1PLANIRANIIZNOS.Text = "PLANIRANIIZNOS:";
            this.label1PLANIRANIIZNOS.StyleSetName = "FieldUltraLabel";
            this.label1PLANIRANIIZNOS.AutoSize = true;
            this.label1PLANIRANIIZNOS.Anchor = AnchorStyles.Left;
            this.label1PLANIRANIIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1PLANIRANIIZNOS.Appearance.ForeColor = Color.Black;
            this.label1PLANIRANIIZNOS.BackColor = Color.Transparent;
            this.layoutManagerformPLANORGKON.Controls.Add(this.label1PLANIRANIIZNOS, 0, 1);
            this.layoutManagerformPLANORGKON.SetColumnSpan(this.label1PLANIRANIIZNOS, 1);
            this.layoutManagerformPLANORGKON.SetRowSpan(this.label1PLANIRANIIZNOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PLANIRANIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PLANIRANIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x84, 0x17);
            this.label1PLANIRANIIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPLANIRANIIZNOS.Location = point;
            this.textPLANIRANIIZNOS.Name = "textPLANIRANIIZNOS";
            this.textPLANIRANIIZNOS.Tag = "PLANIRANIIZNOS";
            this.textPLANIRANIIZNOS.TabIndex = 0;
            this.textPLANIRANIIZNOS.Anchor = AnchorStyles.Left;
            this.textPLANIRANIIZNOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPLANIRANIIZNOS.ReadOnly = false;
            this.textPLANIRANIIZNOS.PromptChar = ' ';
            this.textPLANIRANIIZNOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPLANIRANIIZNOS.DataBindings.Add(new Binding("Value", this.bindingSourcePLANORGKON, "PLANIRANIIZNOS"));
            this.textPLANIRANIIZNOS.NumericType = NumericType.Double;
            this.textPLANIRANIIZNOS.MaxValue = 79228162514264337593543950335M;
            this.textPLANIRANIIZNOS.MinValue = -79228162514264337593543950335M;
            this.textPLANIRANIIZNOS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformPLANORGKON.Controls.Add(this.textPLANIRANIIZNOS, 1, 1);
            this.layoutManagerformPLANORGKON.SetColumnSpan(this.textPLANIRANIIZNOS, 1);
            this.layoutManagerformPLANORGKON.SetRowSpan(this.textPLANIRANIIZNOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPLANIRANIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPLANIRANIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPLANIRANIIZNOS.Size = size;
            this.Controls.Add(this.layoutManagerformPLANORGKON);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourcePLANORGKON;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "PLANFormPLANORGKONUserControl";
            this.Text = " KON";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.PLANFormUserControl_Load);
            this.layoutManagerformPLANORGKON.ResumeLayout(false);
            this.layoutManagerformPLANORGKON.PerformLayout();
            ((ISupportInitialize) this.bindingSourcePLANORGKON).EndInit();
            ((ISupportInitialize) this.textPLANIRANIIZNOS).EndInit();
            this.dsPLANDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.PLANController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourcePLANORGKON, this.PLANController.WorkItem, this))
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
            this.label1PLANKONTOIDKONTO.Text = StringResources.PLANPLANKONTOIDKONTODescription;
            this.label1PLANIRANIIZNOS.Text = StringResources.PLANPLANIRANIIZNOSDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedPLANKONTOIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PLANFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.PLANPLANORGKONLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.PLANController.WorkItem.Items.Contains("PLANORGKON|PLANORGKON"))
            {
                this.PLANController.WorkItem.Items.Add(this.bindingSourcePLANORGKON, "PLANORGKON|PLANORGKON");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("PLANORGKONSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedPLANKONTOIDKONTO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboPLANKONTOIDKONTO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboPLANKONTOIDKONTO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourcePLANORGKON.Current).Row["PLANKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(row["IDKONTO"]);
                    this.bindingSourcePLANORGKON.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboPLANKONTOIDKONTO.Focus();
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

        protected virtual KONTOComboBox comboPLANKONTOIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboPLANKONTOIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboPLANKONTOIDKONTO = value;
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

        protected virtual UltraLabel label1PLANIRANIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PLANIRANIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PLANIRANIIZNOS = value;
            }
        }

        protected virtual UltraLabel label1PLANKONTOIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PLANKONTOIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PLANKONTOIDKONTO = value;
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
        public NetAdvantage.Controllers.PLANController PLANController { get; set; }

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

        protected virtual UltraNumericEditor textPLANIRANIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPLANIRANIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPLANIRANIIZNOS = value;
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

