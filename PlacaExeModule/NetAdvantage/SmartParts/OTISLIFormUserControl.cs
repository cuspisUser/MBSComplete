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
    public class OTISLIFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDRADNIK")]
        private PregledRadnikaComboBox _comboIDRADNIK;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerDATUMODLASKA")]
        private UltraDateTimeEditor _datePickerDATUMODLASKA;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1DATUMODLASKA")]
        private UltraLabel _label1DATUMODLASKA;
        [AccessedThroughProperty("label1IDRADNIK")]
        private UltraLabel _label1IDRADNIK;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceOTISLI;
        private IContainer components = null;
        private OTISLIDataSet dsOTISLIDataSet1;
        protected TableLayoutPanel layoutManagerformOTISLI;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OTISLIDataSet.OTISLIRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OTISLI";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.OTISLIDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public OTISLIFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceOTISLI.DataSource = this.OTISLIController.DataSet;
            this.dsOTISLIDataSet1 = this.OTISLIController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/RADNIK", Thread=ThreadOption.UserInterface)]
        public void comboIDRADNIK_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDRADNIK.Fill();
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
                    enumerator = this.dsOTISLIDataSet1.OTISLI.Rows.GetEnumerator();
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
                if (this.OTISLIController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OTISLI", this.m_Mode, this.dsOTISLIDataSet1, this.dsOTISLIDataSet1.OTISLI.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceOTISLI, "DATUMODLASKA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDATUMODLASKA.DataBindings["Text"] != null)
            {
                this.datePickerDATUMODLASKA.DataBindings.Remove(this.datePickerDATUMODLASKA.DataBindings["Text"]);
            }
            this.datePickerDATUMODLASKA.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsOTISLIDataSet1.OTISLI[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OTISLIDataSet.OTISLIRow) ((DataRowView) this.bindingSourceOTISLI.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(OTISLIFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOTISLI = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOTISLI).BeginInit();
            this.layoutManagerformOTISLI = new TableLayoutPanel();
            this.layoutManagerformOTISLI.SuspendLayout();
            this.layoutManagerformOTISLI.AutoSize = true;
            this.layoutManagerformOTISLI.Dock = DockStyle.Fill;
            this.layoutManagerformOTISLI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOTISLI.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOTISLI.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOTISLI.Size = size;
            this.layoutManagerformOTISLI.ColumnCount = 2;
            this.layoutManagerformOTISLI.RowCount = 3;
            this.layoutManagerformOTISLI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOTISLI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOTISLI.RowStyles.Add(new RowStyle());
            this.layoutManagerformOTISLI.RowStyles.Add(new RowStyle());
            this.layoutManagerformOTISLI.RowStyles.Add(new RowStyle());
            this.label1IDRADNIK = new UltraLabel();
            this.comboIDRADNIK = new PregledRadnikaComboBox();
            this.label1DATUMODLASKA = new UltraLabel();
            this.datePickerDATUMODLASKA = new UltraDateTimeEditor();
            this.dsOTISLIDataSet1 = new OTISLIDataSet();
            this.dsOTISLIDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOTISLIDataSet1.DataSetName = "dsOTISLI";
            this.dsOTISLIDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOTISLI.DataSource = this.dsOTISLIDataSet1;
            this.bindingSourceOTISLI.DataMember = "OTISLI";
            ((ISupportInitialize) this.bindingSourceOTISLI).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDRADNIK.Location = point;
            this.label1IDRADNIK.Name = "label1IDRADNIK";
            this.label1IDRADNIK.TabIndex = 1;
            this.label1IDRADNIK.Tag = "labelIDRADNIK";
            this.label1IDRADNIK.Text = "Šifra radnika:";
            this.label1IDRADNIK.StyleSetName = "FieldUltraLabel";
            this.label1IDRADNIK.AutoSize = true;
            this.label1IDRADNIK.Anchor = AnchorStyles.Left;
            this.label1IDRADNIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRADNIK.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDRADNIK.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDRADNIK.ImageSize = size;
            this.label1IDRADNIK.Appearance.ForeColor = Color.Black;
            this.label1IDRADNIK.BackColor = Color.Transparent;
            this.layoutManagerformOTISLI.Controls.Add(this.label1IDRADNIK, 0, 0);
            this.layoutManagerformOTISLI.SetColumnSpan(this.label1IDRADNIK, 1);
            this.layoutManagerformOTISLI.SetRowSpan(this.label1IDRADNIK, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x60, 0x17);
            this.label1IDRADNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDRADNIK.Location = point;
            this.comboIDRADNIK.Name = "comboIDRADNIK";
            this.comboIDRADNIK.Tag = "IDRADNIK";
            this.comboIDRADNIK.TabIndex = 0;
            this.comboIDRADNIK.Anchor = AnchorStyles.Left;
            this.comboIDRADNIK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDRADNIK.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDRADNIK.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDRADNIK.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDRADNIK.Enabled = true;
            this.comboIDRADNIK.DataBindings.Add(new Binding("Value", this.bindingSourceOTISLI, "IDRADNIK"));
            this.comboIDRADNIK.ShowPictureBox = true;
            this.comboIDRADNIK.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDRADNIK);
            this.comboIDRADNIK.ValueMember = "IDRADNIK";
            this.comboIDRADNIK.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDRADNIK);
            this.layoutManagerformOTISLI.Controls.Add(this.comboIDRADNIK, 1, 0);
            this.layoutManagerformOTISLI.SetColumnSpan(this.comboIDRADNIK, 1);
            this.layoutManagerformOTISLI.SetRowSpan(this.comboIDRADNIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDRADNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMODLASKA.Location = point;
            this.label1DATUMODLASKA.Name = "label1DATUMODLASKA";
            this.label1DATUMODLASKA.TabIndex = 1;
            this.label1DATUMODLASKA.Tag = "labelDATUMODLASKA";
            this.label1DATUMODLASKA.Text = "Datum prekida radnog odnosa:";
            this.label1DATUMODLASKA.StyleSetName = "FieldUltraLabel";
            this.label1DATUMODLASKA.AutoSize = true;
            this.label1DATUMODLASKA.Anchor = AnchorStyles.Left;
            this.label1DATUMODLASKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMODLASKA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1DATUMODLASKA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1DATUMODLASKA.ImageSize = size;
            this.label1DATUMODLASKA.Appearance.ForeColor = Color.Black;
            this.label1DATUMODLASKA.BackColor = Color.Transparent;
            this.layoutManagerformOTISLI.Controls.Add(this.label1DATUMODLASKA, 0, 1);
            this.layoutManagerformOTISLI.SetColumnSpan(this.label1DATUMODLASKA, 1);
            this.layoutManagerformOTISLI.SetRowSpan(this.label1DATUMODLASKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMODLASKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMODLASKA.MinimumSize = size;
            size = new System.Drawing.Size(0xcc, 0x17);
            this.label1DATUMODLASKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMODLASKA.Location = point;
            this.datePickerDATUMODLASKA.Name = "datePickerDATUMODLASKA";
            this.datePickerDATUMODLASKA.Tag = "DATUMODLASKA";
            this.datePickerDATUMODLASKA.TabIndex = 0;
            this.datePickerDATUMODLASKA.Anchor = AnchorStyles.Left;
            this.datePickerDATUMODLASKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMODLASKA.Enabled = true;
            this.layoutManagerformOTISLI.Controls.Add(this.datePickerDATUMODLASKA, 1, 1);
            this.layoutManagerformOTISLI.SetColumnSpan(this.datePickerDATUMODLASKA, 1);
            this.layoutManagerformOTISLI.SetRowSpan(this.datePickerDATUMODLASKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMODLASKA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMODLASKA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMODLASKA.Size = size;
            this.Controls.Add(this.layoutManagerformOTISLI);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOTISLI;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OTISLIFormUserControl";
            this.Text = "OTISLI";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OTISLIFormUserControl_Load);
            this.layoutManagerformOTISLI.ResumeLayout(false);
            this.layoutManagerformOTISLI.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOTISLI).EndInit();
            this.dsOTISLIDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OTISLIController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOTISLI, this.OTISLIController.WorkItem, this))
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
            this.label1IDRADNIK.Text = StringResources.OTISLIIDRADNIKDescription;
            this.label1DATUMODLASKA.Text = StringResources.OTISLIDATUMODLASKADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OTISLIFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OTISLIDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void PictureBoxClickedIDRADNIK(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("RADNIK", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.OTISLIController.WorkItem.Items.Contains("OTISLI|OTISLI"))
            {
                this.OTISLIController.WorkItem.Items.Add(this.bindingSourceOTISLI, "OTISLI|OTISLI");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsOTISLIDataSet1.OTISLI.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.OTISLIController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OTISLIController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OTISLIController.Update(this))
            {
                this.OTISLIController.DataSet = new OTISLIDataSet();
                DataSetUtil.AddEmptyRow(this.OTISLIController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.OTISLIController.DataSet.OTISLI[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIDRADNIK(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDRADNIK.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDRADNIK.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceOTISLI.Current).Row["IDRADNIK"] = RuntimeHelpers.GetObjectValue(row["IDRADNIK"]);
                    this.bindingSourceOTISLI.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboIDRADNIK.Focus();
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

        protected virtual PregledRadnikaComboBox comboIDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDRADNIK = value;
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

        protected virtual UltraDateTimeEditor datePickerDATUMODLASKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMODLASKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMODLASKA = value;
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

        protected virtual UltraLabel label1DATUMODLASKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMODLASKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMODLASKA = value;
            }
        }

        protected virtual UltraLabel label1IDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRADNIK = value;
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
        public NetAdvantage.Controllers.OTISLIController OTISLIController { get; set; }

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

