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
    public class RAD1MELEMENTIVEZAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDELEMENT")]
        private ELEMENTComboBox _comboIDELEMENT;
        [AccessedThroughProperty("comboRAD1ELEMENTIID")]
        private RAD1MELEMENTIComboBox _comboRAD1ELEMENTIID;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDELEMENT")]
        private UltraLabel _label1IDELEMENT;
        [AccessedThroughProperty("label1RAD1ELEMENTIID")]
        private UltraLabel _label1RAD1ELEMENTIID;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRAD1MELEMENTIVEZA;
        private IContainer components = null;
        private RAD1MELEMENTIVEZADataSet dsRAD1MELEMENTIVEZADataSet1;
        protected TableLayoutPanel layoutManagerformRAD1MELEMENTIVEZA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RAD1MELEMENTIVEZA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RAD1MELEMENTIVEZADescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public RAD1MELEMENTIVEZAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceRAD1MELEMENTIVEZA.DataSource = this.RAD1MELEMENTIVEZAController.DataSet;
            this.dsRAD1MELEMENTIVEZADataSet1 = this.RAD1MELEMENTIVEZAController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ELEMENT", Thread=ThreadOption.UserInterface)]
        public void comboIDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDELEMENT.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/RAD1MELEMENTI", Thread=ThreadOption.UserInterface)]
        public void comboRAD1ELEMENTIID_Add(object sender, ComponentEventArgs e)
        {
            this.comboRAD1ELEMENTIID.Fill();
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
                    enumerator = this.dsRAD1MELEMENTIVEZADataSet1.RAD1MELEMENTIVEZA.Rows.GetEnumerator();
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
                if (this.RAD1MELEMENTIVEZAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RAD1MELEMENTIVEZA", this.m_Mode, this.dsRAD1MELEMENTIVEZADataSet1, this.dsRAD1MELEMENTIVEZADataSet1.RAD1MELEMENTIVEZA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRAD1MELEMENTIVEZADataSet1.RAD1MELEMENTIVEZA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow) ((DataRowView) this.bindingSourceRAD1MELEMENTIVEZA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RAD1MELEMENTIVEZAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRAD1MELEMENTIVEZA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRAD1MELEMENTIVEZA).BeginInit();
            this.layoutManagerformRAD1MELEMENTIVEZA = new TableLayoutPanel();
            this.layoutManagerformRAD1MELEMENTIVEZA.SuspendLayout();
            this.layoutManagerformRAD1MELEMENTIVEZA.AutoSize = true;
            this.layoutManagerformRAD1MELEMENTIVEZA.Dock = DockStyle.Fill;
            this.layoutManagerformRAD1MELEMENTIVEZA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRAD1MELEMENTIVEZA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRAD1MELEMENTIVEZA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRAD1MELEMENTIVEZA.Size = size;
            this.layoutManagerformRAD1MELEMENTIVEZA.ColumnCount = 2;
            this.layoutManagerformRAD1MELEMENTIVEZA.RowCount = 3;
            this.layoutManagerformRAD1MELEMENTIVEZA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1MELEMENTIVEZA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1MELEMENTIVEZA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1MELEMENTIVEZA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1MELEMENTIVEZA.RowStyles.Add(new RowStyle());
            this.label1RAD1ELEMENTIID = new UltraLabel();
            this.comboRAD1ELEMENTIID = new RAD1MELEMENTIComboBox();
            this.label1IDELEMENT = new UltraLabel();
            this.comboIDELEMENT = new ELEMENTComboBox();
            this.dsRAD1MELEMENTIVEZADataSet1 = new RAD1MELEMENTIVEZADataSet();
            this.dsRAD1MELEMENTIVEZADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRAD1MELEMENTIVEZADataSet1.DataSetName = "dsRAD1MELEMENTIVEZA";
            this.dsRAD1MELEMENTIVEZADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRAD1MELEMENTIVEZA.DataSource = this.dsRAD1MELEMENTIVEZADataSet1;
            this.bindingSourceRAD1MELEMENTIVEZA.DataMember = "RAD1MELEMENTIVEZA";
            ((ISupportInitialize) this.bindingSourceRAD1MELEMENTIVEZA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1RAD1ELEMENTIID.Location = point;
            this.label1RAD1ELEMENTIID.Name = "label1RAD1ELEMENTIID";
            this.label1RAD1ELEMENTIID.TabIndex = 1;
            this.label1RAD1ELEMENTIID.Tag = "labelRAD1ELEMENTIID";
            this.label1RAD1ELEMENTIID.Text = "Element iz RAD-1M obrasca:";
            this.label1RAD1ELEMENTIID.StyleSetName = "FieldUltraLabel";
            this.label1RAD1ELEMENTIID.AutoSize = true;
            this.label1RAD1ELEMENTIID.Anchor = AnchorStyles.Left;
            this.label1RAD1ELEMENTIID.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAD1ELEMENTIID.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1RAD1ELEMENTIID.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1RAD1ELEMENTIID.ImageSize = size;
            this.label1RAD1ELEMENTIID.Appearance.ForeColor = Color.Black;
            this.label1RAD1ELEMENTIID.BackColor = Color.Transparent;
            this.layoutManagerformRAD1MELEMENTIVEZA.Controls.Add(this.label1RAD1ELEMENTIID, 0, 0);
            this.layoutManagerformRAD1MELEMENTIVEZA.SetColumnSpan(this.label1RAD1ELEMENTIID, 1);
            this.layoutManagerformRAD1MELEMENTIVEZA.SetRowSpan(this.label1RAD1ELEMENTIID, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1RAD1ELEMENTIID.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAD1ELEMENTIID.MinimumSize = size;
            size = new System.Drawing.Size(0xbb, 0x17);
            this.label1RAD1ELEMENTIID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboRAD1ELEMENTIID.Location = point;
            this.comboRAD1ELEMENTIID.Name = "comboRAD1ELEMENTIID";
            this.comboRAD1ELEMENTIID.Tag = "RAD1ELEMENTIID";
            this.comboRAD1ELEMENTIID.TabIndex = 0;
            this.comboRAD1ELEMENTIID.Anchor = AnchorStyles.Left;
            this.comboRAD1ELEMENTIID.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboRAD1ELEMENTIID.DropDownStyle = DropDownStyle.DropDown;
            this.comboRAD1ELEMENTIID.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboRAD1ELEMENTIID.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboRAD1ELEMENTIID.Enabled = true;
            this.comboRAD1ELEMENTIID.DataBindings.Add(new Binding("Value", this.bindingSourceRAD1MELEMENTIVEZA, "RAD1ELEMENTIID"));
            this.comboRAD1ELEMENTIID.ShowPictureBox = true;
            this.comboRAD1ELEMENTIID.PictureBoxClicked += new EventHandler(this.PictureBoxClickedRAD1ELEMENTIID);
            this.comboRAD1ELEMENTIID.ValueMember = "RAD1ELEMENTIID";
            this.comboRAD1ELEMENTIID.SelectionChanged += new EventHandler(this.SelectedIndexChangedRAD1ELEMENTIID);
            this.layoutManagerformRAD1MELEMENTIVEZA.Controls.Add(this.comboRAD1ELEMENTIID, 1, 0);
            this.layoutManagerformRAD1MELEMENTIVEZA.SetColumnSpan(this.comboRAD1ELEMENTIID, 1);
            this.layoutManagerformRAD1MELEMENTIVEZA.SetRowSpan(this.comboRAD1ELEMENTIID, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboRAD1ELEMENTIID.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboRAD1ELEMENTIID.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboRAD1ELEMENTIID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDELEMENT.Location = point;
            this.label1IDELEMENT.Name = "label1IDELEMENT";
            this.label1IDELEMENT.TabIndex = 1;
            this.label1IDELEMENT.Tag = "labelIDELEMENT";
            this.label1IDELEMENT.Text = "Element iz programa plaća:";
            this.label1IDELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1IDELEMENT.AutoSize = true;
            this.label1IDELEMENT.Anchor = AnchorStyles.Left;
            this.label1IDELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDELEMENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDELEMENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDELEMENT.ImageSize = size;
            this.label1IDELEMENT.Appearance.ForeColor = Color.Black;
            this.label1IDELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformRAD1MELEMENTIVEZA.Controls.Add(this.label1IDELEMENT, 0, 1);
            this.layoutManagerformRAD1MELEMENTIVEZA.SetColumnSpan(this.label1IDELEMENT, 1);
            this.layoutManagerformRAD1MELEMENTIVEZA.SetRowSpan(this.label1IDELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0xb5, 0x17);
            this.label1IDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDELEMENT.Location = point;
            this.comboIDELEMENT.Name = "comboIDELEMENT";
            this.comboIDELEMENT.Tag = "IDELEMENT";
            this.comboIDELEMENT.TabIndex = 0;
            this.comboIDELEMENT.Anchor = AnchorStyles.Left;
            this.comboIDELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDELEMENT.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDELEMENT.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDELEMENT.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDELEMENT.Enabled = true;
            this.comboIDELEMENT.DataBindings.Add(new Binding("Value", this.bindingSourceRAD1MELEMENTIVEZA, "IDELEMENT"));
            this.comboIDELEMENT.ShowPictureBox = true;
            this.comboIDELEMENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDELEMENT);
            this.comboIDELEMENT.ValueMember = "IDELEMENT";
            this.comboIDELEMENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDELEMENT);
            this.layoutManagerformRAD1MELEMENTIVEZA.Controls.Add(this.comboIDELEMENT, 1, 1);
            this.layoutManagerformRAD1MELEMENTIVEZA.SetColumnSpan(this.comboIDELEMENT, 1);
            this.layoutManagerformRAD1MELEMENTIVEZA.SetRowSpan(this.comboIDELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDELEMENT.Size = size;
            this.Controls.Add(this.layoutManagerformRAD1MELEMENTIVEZA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRAD1MELEMENTIVEZA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RAD1MELEMENTIVEZAFormUserControl";
            this.Text = "Veza RAD1M elementi i elementi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RAD1MELEMENTIVEZAFormUserControl_Load);
            this.layoutManagerformRAD1MELEMENTIVEZA.ResumeLayout(false);
            this.layoutManagerformRAD1MELEMENTIVEZA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRAD1MELEMENTIVEZA).EndInit();
            this.dsRAD1MELEMENTIVEZADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RAD1MELEMENTIVEZAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRAD1MELEMENTIVEZA, this.RAD1MELEMENTIVEZAController.WorkItem, this))
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
            this.label1RAD1ELEMENTIID.Text = StringResources.RAD1MELEMENTIVEZARAD1ELEMENTIIDDescription;
            this.label1IDELEMENT.Text = StringResources.RAD1MELEMENTIVEZAIDELEMENTDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDELEMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ELEMENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedRAD1ELEMENTIID(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("RAD1MELEMENTI", null, DeklaritMode.Insert));
            }
        }

        private void RAD1MELEMENTIVEZAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RAD1MELEMENTIVEZADescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RAD1MELEMENTIVEZAController.WorkItem.Items.Contains("RAD1MELEMENTIVEZA|RAD1MELEMENTIVEZA"))
            {
                this.RAD1MELEMENTIVEZAController.WorkItem.Items.Add(this.bindingSourceRAD1MELEMENTIVEZA, "RAD1MELEMENTIVEZA|RAD1MELEMENTIVEZA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRAD1MELEMENTIVEZADataSet1.RAD1MELEMENTIVEZA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.RAD1MELEMENTIVEZAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1MELEMENTIVEZAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1MELEMENTIVEZAController.Update(this))
            {
                this.RAD1MELEMENTIVEZAController.DataSet = new RAD1MELEMENTIVEZADataSet();
                DataSetUtil.AddEmptyRow(this.RAD1MELEMENTIVEZAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RAD1MELEMENTIVEZAController.DataSet.RAD1MELEMENTIVEZA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIDELEMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDELEMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDELEMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRAD1MELEMENTIVEZA.Current).Row["IDELEMENT"] = RuntimeHelpers.GetObjectValue(row["IDELEMENT"]);
                    this.bindingSourceRAD1MELEMENTIVEZA.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedRAD1ELEMENTIID(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboRAD1ELEMENTIID.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboRAD1ELEMENTIID.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRAD1MELEMENTIVEZA.Current).Row["RAD1ELEMENTIID"] = RuntimeHelpers.GetObjectValue(row["RAD1ELEMENTIID"]);
                    this.bindingSourceRAD1MELEMENTIVEZA.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboRAD1ELEMENTIID.Focus();
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

        protected virtual ELEMENTComboBox comboIDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDELEMENT = value;
            }
        }

        protected virtual RAD1MELEMENTIComboBox comboRAD1ELEMENTIID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboRAD1ELEMENTIID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboRAD1ELEMENTIID = value;
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

        protected virtual UltraLabel label1IDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDELEMENT = value;
            }
        }

        protected virtual UltraLabel label1RAD1ELEMENTIID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAD1ELEMENTIID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAD1ELEMENTIID = value;
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
        public NetAdvantage.Controllers.RAD1MELEMENTIVEZAController RAD1MELEMENTIVEZAController { get; set; }

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

