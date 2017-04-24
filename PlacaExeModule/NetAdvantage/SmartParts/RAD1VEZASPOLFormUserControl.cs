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
    public class RAD1VEZASPOLFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDSPOL")]
        private SPOLComboBox _comboIDSPOL;
        [AccessedThroughProperty("comboRAD1SPOLID")]
        private RAD1SPOLComboBox _comboRAD1SPOLID;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDSPOL")]
        private UltraLabel _label1IDSPOL;
        [AccessedThroughProperty("label1RAD1SPOLID")]
        private UltraLabel _label1RAD1SPOLID;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRAD1VEZASPOL;
        private IContainer components = null;
        private RAD1VEZASPOLDataSet dsRAD1VEZASPOLDataSet1;
        protected TableLayoutPanel layoutManagerformRAD1VEZASPOL;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RAD1VEZASPOLDataSet.RAD1VEZASPOLRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RAD1VEZASPOL";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RAD1VEZASPOLDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public RAD1VEZASPOLFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceRAD1VEZASPOL.DataSource = this.RAD1VEZASPOLController.DataSet;
            this.dsRAD1VEZASPOLDataSet1 = this.RAD1VEZASPOLController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/SPOL", Thread=ThreadOption.UserInterface)]
        public void comboIDSPOL_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDSPOL.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/RAD1SPOL", Thread=ThreadOption.UserInterface)]
        public void comboRAD1SPOLID_Add(object sender, ComponentEventArgs e)
        {
            this.comboRAD1SPOLID.Fill();
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
                    enumerator = this.dsRAD1VEZASPOLDataSet1.RAD1VEZASPOL.Rows.GetEnumerator();
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
                if (this.RAD1VEZASPOLController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RAD1VEZASPOL", this.m_Mode, this.dsRAD1VEZASPOLDataSet1, this.dsRAD1VEZASPOLDataSet1.RAD1VEZASPOL.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRAD1VEZASPOLDataSet1.RAD1VEZASPOL[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RAD1VEZASPOLDataSet.RAD1VEZASPOLRow) ((DataRowView) this.bindingSourceRAD1VEZASPOL.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RAD1VEZASPOLFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRAD1VEZASPOL = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRAD1VEZASPOL).BeginInit();
            this.layoutManagerformRAD1VEZASPOL = new TableLayoutPanel();
            this.layoutManagerformRAD1VEZASPOL.SuspendLayout();
            this.layoutManagerformRAD1VEZASPOL.AutoSize = true;
            this.layoutManagerformRAD1VEZASPOL.Dock = DockStyle.Fill;
            this.layoutManagerformRAD1VEZASPOL.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRAD1VEZASPOL.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRAD1VEZASPOL.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRAD1VEZASPOL.Size = size;
            this.layoutManagerformRAD1VEZASPOL.ColumnCount = 2;
            this.layoutManagerformRAD1VEZASPOL.RowCount = 3;
            this.layoutManagerformRAD1VEZASPOL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1VEZASPOL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1VEZASPOL.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1VEZASPOL.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1VEZASPOL.RowStyles.Add(new RowStyle());
            this.label1RAD1SPOLID = new UltraLabel();
            this.comboRAD1SPOLID = new RAD1SPOLComboBox();
            this.label1IDSPOL = new UltraLabel();
            this.comboIDSPOL = new SPOLComboBox();
            this.dsRAD1VEZASPOLDataSet1 = new RAD1VEZASPOLDataSet();
            this.dsRAD1VEZASPOLDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRAD1VEZASPOLDataSet1.DataSetName = "dsRAD1VEZASPOL";
            this.dsRAD1VEZASPOLDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRAD1VEZASPOL.DataSource = this.dsRAD1VEZASPOLDataSet1;
            this.bindingSourceRAD1VEZASPOL.DataMember = "RAD1VEZASPOL";
            ((ISupportInitialize) this.bindingSourceRAD1VEZASPOL).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1RAD1SPOLID.Location = point;
            this.label1RAD1SPOLID.Name = "label1RAD1SPOLID";
            this.label1RAD1SPOLID.TabIndex = 1;
            this.label1RAD1SPOLID.Tag = "labelRAD1SPOLID";
            this.label1RAD1SPOLID.Text = "Spol u RAD1 obrascu:";
            this.label1RAD1SPOLID.StyleSetName = "FieldUltraLabel";
            this.label1RAD1SPOLID.AutoSize = true;
            this.label1RAD1SPOLID.Anchor = AnchorStyles.Left;
            this.label1RAD1SPOLID.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAD1SPOLID.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1RAD1SPOLID.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1RAD1SPOLID.ImageSize = size;
            this.label1RAD1SPOLID.Appearance.ForeColor = Color.Black;
            this.label1RAD1SPOLID.BackColor = Color.Transparent;
            this.layoutManagerformRAD1VEZASPOL.Controls.Add(this.label1RAD1SPOLID, 0, 0);
            this.layoutManagerformRAD1VEZASPOL.SetColumnSpan(this.label1RAD1SPOLID, 1);
            this.layoutManagerformRAD1VEZASPOL.SetRowSpan(this.label1RAD1SPOLID, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1RAD1SPOLID.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAD1SPOLID.MinimumSize = size;
            size = new System.Drawing.Size(0x91, 0x17);
            this.label1RAD1SPOLID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboRAD1SPOLID.Location = point;
            this.comboRAD1SPOLID.Name = "comboRAD1SPOLID";
            this.comboRAD1SPOLID.Tag = "RAD1SPOLID";
            this.comboRAD1SPOLID.TabIndex = 0;
            this.comboRAD1SPOLID.Anchor = AnchorStyles.Left;
            this.comboRAD1SPOLID.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboRAD1SPOLID.DropDownStyle = DropDownStyle.DropDown;
            this.comboRAD1SPOLID.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboRAD1SPOLID.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboRAD1SPOLID.Enabled = true;
            this.comboRAD1SPOLID.DataBindings.Add(new Binding("Value", this.bindingSourceRAD1VEZASPOL, "RAD1SPOLID"));
            this.comboRAD1SPOLID.ShowPictureBox = true;
            this.comboRAD1SPOLID.PictureBoxClicked += new EventHandler(this.PictureBoxClickedRAD1SPOLID);
            this.comboRAD1SPOLID.ValueMember = "RAD1SPOLID";
            this.comboRAD1SPOLID.SelectionChanged += new EventHandler(this.SelectedIndexChangedRAD1SPOLID);
            this.layoutManagerformRAD1VEZASPOL.Controls.Add(this.comboRAD1SPOLID, 1, 0);
            this.layoutManagerformRAD1VEZASPOL.SetColumnSpan(this.comboRAD1SPOLID, 1);
            this.layoutManagerformRAD1VEZASPOL.SetRowSpan(this.comboRAD1SPOLID, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboRAD1SPOLID.Margin = padding;
            size = new System.Drawing.Size(0xc4, 0x17);
            this.comboRAD1SPOLID.MinimumSize = size;
            size = new System.Drawing.Size(0xc4, 0x17);
            this.comboRAD1SPOLID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDSPOL.Location = point;
            this.label1IDSPOL.Name = "label1IDSPOL";
            this.label1IDSPOL.TabIndex = 1;
            this.label1IDSPOL.Tag = "labelIDSPOL";
            this.label1IDSPOL.Text = "Spol iz kadrovske evidencije:";
            this.label1IDSPOL.StyleSetName = "FieldUltraLabel";
            this.label1IDSPOL.AutoSize = true;
            this.label1IDSPOL.Anchor = AnchorStyles.Left;
            this.label1IDSPOL.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSPOL.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDSPOL.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDSPOL.ImageSize = size;
            this.label1IDSPOL.Appearance.ForeColor = Color.Black;
            this.label1IDSPOL.BackColor = Color.Transparent;
            this.layoutManagerformRAD1VEZASPOL.Controls.Add(this.label1IDSPOL, 0, 1);
            this.layoutManagerformRAD1VEZASPOL.SetColumnSpan(this.label1IDSPOL, 1);
            this.layoutManagerformRAD1VEZASPOL.SetRowSpan(this.label1IDSPOL, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDSPOL.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSPOL.MinimumSize = size;
            size = new System.Drawing.Size(0xbf, 0x17);
            this.label1IDSPOL.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDSPOL.Location = point;
            this.comboIDSPOL.Name = "comboIDSPOL";
            this.comboIDSPOL.Tag = "IDSPOL";
            this.comboIDSPOL.TabIndex = 0;
            this.comboIDSPOL.Anchor = AnchorStyles.Left;
            this.comboIDSPOL.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDSPOL.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDSPOL.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDSPOL.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDSPOL.Enabled = true;
            this.comboIDSPOL.DataBindings.Add(new Binding("Value", this.bindingSourceRAD1VEZASPOL, "IDSPOL"));
            this.comboIDSPOL.ShowPictureBox = true;
            this.comboIDSPOL.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDSPOL);
            this.comboIDSPOL.ValueMember = "IDSPOL";
            this.comboIDSPOL.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDSPOL);
            this.layoutManagerformRAD1VEZASPOL.Controls.Add(this.comboIDSPOL, 1, 1);
            this.layoutManagerformRAD1VEZASPOL.SetColumnSpan(this.comboIDSPOL, 1);
            this.layoutManagerformRAD1VEZASPOL.SetRowSpan(this.comboIDSPOL, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDSPOL.Margin = padding;
            size = new System.Drawing.Size(0xc4, 0x17);
            this.comboIDSPOL.MinimumSize = size;
            size = new System.Drawing.Size(0xc4, 0x17);
            this.comboIDSPOL.Size = size;
            this.Controls.Add(this.layoutManagerformRAD1VEZASPOL);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRAD1VEZASPOL;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RAD1VEZASPOLFormUserControl";
            this.Text = "Veza RAD1 i spol";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RAD1VEZASPOLFormUserControl_Load);
            this.layoutManagerformRAD1VEZASPOL.ResumeLayout(false);
            this.layoutManagerformRAD1VEZASPOL.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRAD1VEZASPOL).EndInit();
            this.dsRAD1VEZASPOLDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RAD1VEZASPOLController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRAD1VEZASPOL, this.RAD1VEZASPOLController.WorkItem, this))
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
            this.label1RAD1SPOLID.Text = StringResources.RAD1VEZASPOLRAD1SPOLIDDescription;
            this.label1IDSPOL.Text = StringResources.RAD1VEZASPOLIDSPOLDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDSPOL(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("SPOL", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedRAD1SPOLID(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("RAD1SPOL", null, DeklaritMode.Insert));
            }
        }

        private void RAD1VEZASPOLFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RAD1VEZASPOLDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RAD1VEZASPOLController.WorkItem.Items.Contains("RAD1VEZASPOL|RAD1VEZASPOL"))
            {
                this.RAD1VEZASPOLController.WorkItem.Items.Add(this.bindingSourceRAD1VEZASPOL, "RAD1VEZASPOL|RAD1VEZASPOL");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRAD1VEZASPOLDataSet1.RAD1VEZASPOL.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.RAD1VEZASPOLController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1VEZASPOLController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1VEZASPOLController.Update(this))
            {
                this.RAD1VEZASPOLController.DataSet = new RAD1VEZASPOLDataSet();
                DataSetUtil.AddEmptyRow(this.RAD1VEZASPOLController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RAD1VEZASPOLController.DataSet.RAD1VEZASPOL[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIDSPOL(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDSPOL.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDSPOL.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRAD1VEZASPOL.Current).Row["IDSPOL"] = RuntimeHelpers.GetObjectValue(row["IDSPOL"]);
                    this.bindingSourceRAD1VEZASPOL.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedRAD1SPOLID(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboRAD1SPOLID.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboRAD1SPOLID.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRAD1VEZASPOL.Current).Row["RAD1SPOLID"] = RuntimeHelpers.GetObjectValue(row["RAD1SPOLID"]);
                    this.bindingSourceRAD1VEZASPOL.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboRAD1SPOLID.Focus();
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

        protected virtual SPOLComboBox comboIDSPOL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDSPOL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDSPOL = value;
            }
        }

        protected virtual RAD1SPOLComboBox comboRAD1SPOLID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboRAD1SPOLID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboRAD1SPOLID = value;
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

        protected virtual UltraLabel label1IDSPOL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSPOL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSPOL = value;
            }
        }

        protected virtual UltraLabel label1RAD1SPOLID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAD1SPOLID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAD1SPOLID = value;
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
        public NetAdvantage.Controllers.RAD1VEZASPOLController RAD1VEZASPOLController { get; set; }

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

