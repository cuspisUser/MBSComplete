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
    public class RAD1SPREMEVEZAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDSTRUCNASPREMA")]
        private STRUCNASPREMAComboBox _comboIDSTRUCNASPREMA;
        [AccessedThroughProperty("comboRAD1IDSPREME")]
        private RAD1SPREMEComboBox _comboRAD1IDSPREME;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDSTRUCNASPREMA")]
        private UltraLabel _label1IDSTRUCNASPREMA;
        [AccessedThroughProperty("label1RAD1IDSPREME")]
        private UltraLabel _label1RAD1IDSPREME;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRAD1SPREMEVEZA;
        private IContainer components = null;
        private RAD1SPREMEVEZADataSet dsRAD1SPREMEVEZADataSet1;
        protected TableLayoutPanel layoutManagerformRAD1SPREMEVEZA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RAD1SPREMEVEZA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RAD1SPREMEVEZADescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public RAD1SPREMEVEZAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceRAD1SPREMEVEZA.DataSource = this.RAD1SPREMEVEZAController.DataSet;
            this.dsRAD1SPREMEVEZADataSet1 = this.RAD1SPREMEVEZAController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRUCNASPREMA", Thread=ThreadOption.UserInterface)]
        public void comboIDSTRUCNASPREMA_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDSTRUCNASPREMA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/RAD1SPREME", Thread=ThreadOption.UserInterface)]
        public void comboRAD1IDSPREME_Add(object sender, ComponentEventArgs e)
        {
            this.comboRAD1IDSPREME.Fill();
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
                    enumerator = this.dsRAD1SPREMEVEZADataSet1.RAD1SPREMEVEZA.Rows.GetEnumerator();
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
                if (this.RAD1SPREMEVEZAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RAD1SPREMEVEZA", this.m_Mode, this.dsRAD1SPREMEVEZADataSet1, this.dsRAD1SPREMEVEZADataSet1.RAD1SPREMEVEZA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRAD1SPREMEVEZADataSet1.RAD1SPREMEVEZA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow) ((DataRowView) this.bindingSourceRAD1SPREMEVEZA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RAD1SPREMEVEZAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRAD1SPREMEVEZA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRAD1SPREMEVEZA).BeginInit();
            this.layoutManagerformRAD1SPREMEVEZA = new TableLayoutPanel();
            this.layoutManagerformRAD1SPREMEVEZA.SuspendLayout();
            this.layoutManagerformRAD1SPREMEVEZA.AutoSize = true;
            this.layoutManagerformRAD1SPREMEVEZA.Dock = DockStyle.Fill;
            this.layoutManagerformRAD1SPREMEVEZA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRAD1SPREMEVEZA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRAD1SPREMEVEZA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRAD1SPREMEVEZA.Size = size;
            this.layoutManagerformRAD1SPREMEVEZA.ColumnCount = 2;
            this.layoutManagerformRAD1SPREMEVEZA.RowCount = 3;
            this.layoutManagerformRAD1SPREMEVEZA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1SPREMEVEZA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1SPREMEVEZA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1SPREMEVEZA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1SPREMEVEZA.RowStyles.Add(new RowStyle());
            this.label1RAD1IDSPREME = new UltraLabel();
            this.comboRAD1IDSPREME = new RAD1SPREMEComboBox();
            this.label1IDSTRUCNASPREMA = new UltraLabel();
            this.comboIDSTRUCNASPREMA = new STRUCNASPREMAComboBox();
            this.dsRAD1SPREMEVEZADataSet1 = new RAD1SPREMEVEZADataSet();
            this.dsRAD1SPREMEVEZADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRAD1SPREMEVEZADataSet1.DataSetName = "dsRAD1SPREMEVEZA";
            this.dsRAD1SPREMEVEZADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRAD1SPREMEVEZA.DataSource = this.dsRAD1SPREMEVEZADataSet1;
            this.bindingSourceRAD1SPREMEVEZA.DataMember = "RAD1SPREMEVEZA";
            ((ISupportInitialize) this.bindingSourceRAD1SPREMEVEZA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1RAD1IDSPREME.Location = point;
            this.label1RAD1IDSPREME.Name = "label1RAD1IDSPREME";
            this.label1RAD1IDSPREME.TabIndex = 1;
            this.label1RAD1IDSPREME.Tag = "labelRAD1IDSPREME";
            this.label1RAD1IDSPREME.Text = "RAD1-Obrazac spreme:";
            this.label1RAD1IDSPREME.StyleSetName = "FieldUltraLabel";
            this.label1RAD1IDSPREME.AutoSize = true;
            this.label1RAD1IDSPREME.Anchor = AnchorStyles.Left;
            this.label1RAD1IDSPREME.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAD1IDSPREME.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1RAD1IDSPREME.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1RAD1IDSPREME.ImageSize = size;
            this.label1RAD1IDSPREME.Appearance.ForeColor = Color.Black;
            this.label1RAD1IDSPREME.BackColor = Color.Transparent;
            this.layoutManagerformRAD1SPREMEVEZA.Controls.Add(this.label1RAD1IDSPREME, 0, 0);
            this.layoutManagerformRAD1SPREMEVEZA.SetColumnSpan(this.label1RAD1IDSPREME, 1);
            this.layoutManagerformRAD1SPREMEVEZA.SetRowSpan(this.label1RAD1IDSPREME, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1RAD1IDSPREME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAD1IDSPREME.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x17);
            this.label1RAD1IDSPREME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboRAD1IDSPREME.Location = point;
            this.comboRAD1IDSPREME.Name = "comboRAD1IDSPREME";
            this.comboRAD1IDSPREME.Tag = "RAD1IDSPREME";
            this.comboRAD1IDSPREME.TabIndex = 0;
            this.comboRAD1IDSPREME.Anchor = AnchorStyles.Left;
            this.comboRAD1IDSPREME.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboRAD1IDSPREME.DropDownStyle = DropDownStyle.DropDown;
            this.comboRAD1IDSPREME.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboRAD1IDSPREME.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboRAD1IDSPREME.Enabled = true;
            this.comboRAD1IDSPREME.DataBindings.Add(new Binding("Value", this.bindingSourceRAD1SPREMEVEZA, "RAD1IDSPREME"));
            this.comboRAD1IDSPREME.ShowPictureBox = true;
            this.comboRAD1IDSPREME.PictureBoxClicked += new EventHandler(this.PictureBoxClickedRAD1IDSPREME);
            this.comboRAD1IDSPREME.ValueMember = "RAD1IDSPREME";
            this.comboRAD1IDSPREME.SelectionChanged += new EventHandler(this.SelectedIndexChangedRAD1IDSPREME);
            this.layoutManagerformRAD1SPREMEVEZA.Controls.Add(this.comboRAD1IDSPREME, 1, 0);
            this.layoutManagerformRAD1SPREMEVEZA.SetColumnSpan(this.comboRAD1IDSPREME, 1);
            this.layoutManagerformRAD1SPREMEVEZA.SetRowSpan(this.comboRAD1IDSPREME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboRAD1IDSPREME.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboRAD1IDSPREME.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboRAD1IDSPREME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDSTRUCNASPREMA.Location = point;
            this.label1IDSTRUCNASPREMA.Name = "label1IDSTRUCNASPREMA";
            this.label1IDSTRUCNASPREMA.TabIndex = 1;
            this.label1IDSTRUCNASPREMA.Tag = "labelIDSTRUCNASPREMA";
            this.label1IDSTRUCNASPREMA.Text = "Šifra stručne spreme iz kadrovske:";
            this.label1IDSTRUCNASPREMA.StyleSetName = "FieldUltraLabel";
            this.label1IDSTRUCNASPREMA.AutoSize = true;
            this.label1IDSTRUCNASPREMA.Anchor = AnchorStyles.Left;
            this.label1IDSTRUCNASPREMA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSTRUCNASPREMA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDSTRUCNASPREMA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDSTRUCNASPREMA.ImageSize = size;
            this.label1IDSTRUCNASPREMA.Appearance.ForeColor = Color.Black;
            this.label1IDSTRUCNASPREMA.BackColor = Color.Transparent;
            this.layoutManagerformRAD1SPREMEVEZA.Controls.Add(this.label1IDSTRUCNASPREMA, 0, 1);
            this.layoutManagerformRAD1SPREMEVEZA.SetColumnSpan(this.label1IDSTRUCNASPREMA, 1);
            this.layoutManagerformRAD1SPREMEVEZA.SetRowSpan(this.label1IDSTRUCNASPREMA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDSTRUCNASPREMA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSTRUCNASPREMA.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x17);
            this.label1IDSTRUCNASPREMA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDSTRUCNASPREMA.Location = point;
            this.comboIDSTRUCNASPREMA.Name = "comboIDSTRUCNASPREMA";
            this.comboIDSTRUCNASPREMA.Tag = "IDSTRUCNASPREMA";
            this.comboIDSTRUCNASPREMA.TabIndex = 0;
            this.comboIDSTRUCNASPREMA.Anchor = AnchorStyles.Left;
            this.comboIDSTRUCNASPREMA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDSTRUCNASPREMA.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDSTRUCNASPREMA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDSTRUCNASPREMA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDSTRUCNASPREMA.Enabled = true;
            this.comboIDSTRUCNASPREMA.DataBindings.Add(new Binding("Value", this.bindingSourceRAD1SPREMEVEZA, "IDSTRUCNASPREMA"));
            this.comboIDSTRUCNASPREMA.ShowPictureBox = true;
            this.comboIDSTRUCNASPREMA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDSTRUCNASPREMA);
            this.comboIDSTRUCNASPREMA.ValueMember = "IDSTRUCNASPREMA";
            this.comboIDSTRUCNASPREMA.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDSTRUCNASPREMA);
            this.layoutManagerformRAD1SPREMEVEZA.Controls.Add(this.comboIDSTRUCNASPREMA, 1, 1);
            this.layoutManagerformRAD1SPREMEVEZA.SetColumnSpan(this.comboIDSTRUCNASPREMA, 1);
            this.layoutManagerformRAD1SPREMEVEZA.SetRowSpan(this.comboIDSTRUCNASPREMA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDSTRUCNASPREMA.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDSTRUCNASPREMA.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDSTRUCNASPREMA.Size = size;
            this.Controls.Add(this.layoutManagerformRAD1SPREMEVEZA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRAD1SPREMEVEZA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RAD1SPREMEVEZAFormUserControl";
            this.Text = "Veza RAD1 i strucne spreme";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RAD1SPREMEVEZAFormUserControl_Load);
            this.layoutManagerformRAD1SPREMEVEZA.ResumeLayout(false);
            this.layoutManagerformRAD1SPREMEVEZA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRAD1SPREMEVEZA).EndInit();
            this.dsRAD1SPREMEVEZADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RAD1SPREMEVEZAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRAD1SPREMEVEZA, this.RAD1SPREMEVEZAController.WorkItem, this))
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
            this.label1RAD1IDSPREME.Text = StringResources.RAD1SPREMEVEZARAD1IDSPREMEDescription;
            this.label1IDSTRUCNASPREMA.Text = StringResources.RAD1SPREMEVEZAIDSTRUCNASPREMADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDSTRUCNASPREMA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRUCNASPREMA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedRAD1IDSPREME(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("RAD1SPREME", null, DeklaritMode.Insert));
            }
        }

        private void RAD1SPREMEVEZAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RAD1SPREMEVEZADescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RAD1SPREMEVEZAController.WorkItem.Items.Contains("RAD1SPREMEVEZA|RAD1SPREMEVEZA"))
            {
                this.RAD1SPREMEVEZAController.WorkItem.Items.Add(this.bindingSourceRAD1SPREMEVEZA, "RAD1SPREMEVEZA|RAD1SPREMEVEZA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRAD1SPREMEVEZADataSet1.RAD1SPREMEVEZA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.RAD1SPREMEVEZAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1SPREMEVEZAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1SPREMEVEZAController.Update(this))
            {
                this.RAD1SPREMEVEZAController.DataSet = new RAD1SPREMEVEZADataSet();
                DataSetUtil.AddEmptyRow(this.RAD1SPREMEVEZAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RAD1SPREMEVEZAController.DataSet.RAD1SPREMEVEZA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIDSTRUCNASPREMA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDSTRUCNASPREMA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDSTRUCNASPREMA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRAD1SPREMEVEZA.Current).Row["IDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(row["IDSTRUCNASPREMA"]);
                    this.bindingSourceRAD1SPREMEVEZA.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedRAD1IDSPREME(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboRAD1IDSPREME.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboRAD1IDSPREME.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRAD1SPREMEVEZA.Current).Row["RAD1IDSPREME"] = RuntimeHelpers.GetObjectValue(row["RAD1IDSPREME"]);
                    this.bindingSourceRAD1SPREMEVEZA.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboRAD1IDSPREME.Focus();
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

        protected virtual STRUCNASPREMAComboBox comboIDSTRUCNASPREMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDSTRUCNASPREMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDSTRUCNASPREMA = value;
            }
        }

        protected virtual RAD1SPREMEComboBox comboRAD1IDSPREME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboRAD1IDSPREME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboRAD1IDSPREME = value;
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

        protected virtual UltraLabel label1IDSTRUCNASPREMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSTRUCNASPREMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSTRUCNASPREMA = value;
            }
        }

        protected virtual UltraLabel label1RAD1IDSPREME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAD1IDSPREME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAD1IDSPREME = value;
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
        public NetAdvantage.Controllers.RAD1SPREMEVEZAController RAD1SPREMEVEZAController { get; set; }

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

