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
    public class ZAPOSLENIFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDRADNIK")]
        private PregledRadnikaComboBox _comboIDRADNIK;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerDATUMZAPOSLENJA")]
        private UltraDateTimeEditor _datePickerDATUMZAPOSLENJA;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1DATUMZAPOSLENJA")]
        private UltraLabel _label1DATUMZAPOSLENJA;
        [AccessedThroughProperty("label1IDRADNIK")]
        private UltraLabel _label1IDRADNIK;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceZAPOSLENI;
        private IContainer components = null;
        private ZAPOSLENIDataSet dsZAPOSLENIDataSet1;
        protected TableLayoutPanel layoutManagerformZAPOSLENI;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private ZAPOSLENIDataSet.ZAPOSLENIRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "ZAPOSLENI";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.ZAPOSLENIDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public ZAPOSLENIFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceZAPOSLENI.DataSource = this.ZAPOSLENIController.DataSet;
            this.dsZAPOSLENIDataSet1 = this.ZAPOSLENIController.DataSet;
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
                    enumerator = this.dsZAPOSLENIDataSet1.ZAPOSLENI.Rows.GetEnumerator();
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
                if (this.ZAPOSLENIController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "ZAPOSLENI", this.m_Mode, this.dsZAPOSLENIDataSet1, this.dsZAPOSLENIDataSet1.ZAPOSLENI.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceZAPOSLENI, "DATUMZAPOSLENJA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDATUMZAPOSLENJA.DataBindings["Text"] != null)
            {
                this.datePickerDATUMZAPOSLENJA.DataBindings.Remove(this.datePickerDATUMZAPOSLENJA.DataBindings["Text"]);
            }
            this.datePickerDATUMZAPOSLENJA.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsZAPOSLENIDataSet1.ZAPOSLENI[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (ZAPOSLENIDataSet.ZAPOSLENIRow) ((DataRowView) this.bindingSourceZAPOSLENI.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(ZAPOSLENIFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceZAPOSLENI = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceZAPOSLENI).BeginInit();
            this.layoutManagerformZAPOSLENI = new TableLayoutPanel();
            this.layoutManagerformZAPOSLENI.SuspendLayout();
            this.layoutManagerformZAPOSLENI.AutoSize = true;
            this.layoutManagerformZAPOSLENI.Dock = DockStyle.Fill;
            this.layoutManagerformZAPOSLENI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformZAPOSLENI.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformZAPOSLENI.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformZAPOSLENI.Size = size;
            this.layoutManagerformZAPOSLENI.ColumnCount = 2;
            this.layoutManagerformZAPOSLENI.RowCount = 3;
            this.layoutManagerformZAPOSLENI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformZAPOSLENI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformZAPOSLENI.RowStyles.Add(new RowStyle());
            this.layoutManagerformZAPOSLENI.RowStyles.Add(new RowStyle());
            this.layoutManagerformZAPOSLENI.RowStyles.Add(new RowStyle());
            this.label1IDRADNIK = new UltraLabel();
            this.comboIDRADNIK = new PregledRadnikaComboBox();
            this.label1DATUMZAPOSLENJA = new UltraLabel();
            this.datePickerDATUMZAPOSLENJA = new UltraDateTimeEditor();
            this.dsZAPOSLENIDataSet1 = new ZAPOSLENIDataSet();
            this.dsZAPOSLENIDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsZAPOSLENIDataSet1.DataSetName = "dsZAPOSLENI";
            this.dsZAPOSLENIDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceZAPOSLENI.DataSource = this.dsZAPOSLENIDataSet1;
            this.bindingSourceZAPOSLENI.DataMember = "ZAPOSLENI";
            ((ISupportInitialize) this.bindingSourceZAPOSLENI).BeginInit();
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
            this.layoutManagerformZAPOSLENI.Controls.Add(this.label1IDRADNIK, 0, 0);
            this.layoutManagerformZAPOSLENI.SetColumnSpan(this.label1IDRADNIK, 1);
            this.layoutManagerformZAPOSLENI.SetRowSpan(this.label1IDRADNIK, 1);
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
            this.comboIDRADNIK.DataBindings.Add(new Binding("Value", this.bindingSourceZAPOSLENI, "IDRADNIK"));
            this.comboIDRADNIK.ShowPictureBox = true;
            this.comboIDRADNIK.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDRADNIK);
            this.comboIDRADNIK.ValueMember = "IDRADNIK";
            this.comboIDRADNIK.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDRADNIK);
            this.layoutManagerformZAPOSLENI.Controls.Add(this.comboIDRADNIK, 1, 0);
            this.layoutManagerformZAPOSLENI.SetColumnSpan(this.comboIDRADNIK, 1);
            this.layoutManagerformZAPOSLENI.SetRowSpan(this.comboIDRADNIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDRADNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMZAPOSLENJA.Location = point;
            this.label1DATUMZAPOSLENJA.Name = "label1DATUMZAPOSLENJA";
            this.label1DATUMZAPOSLENJA.TabIndex = 1;
            this.label1DATUMZAPOSLENJA.Tag = "labelDATUMZAPOSLENJA";
            this.label1DATUMZAPOSLENJA.Text = "Datum zasnivanja radnog odnosa:";
            this.label1DATUMZAPOSLENJA.StyleSetName = "FieldUltraLabel";
            this.label1DATUMZAPOSLENJA.AutoSize = true;
            this.label1DATUMZAPOSLENJA.Anchor = AnchorStyles.Left;
            this.label1DATUMZAPOSLENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMZAPOSLENJA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1DATUMZAPOSLENJA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1DATUMZAPOSLENJA.ImageSize = size;
            this.label1DATUMZAPOSLENJA.Appearance.ForeColor = Color.Black;
            this.label1DATUMZAPOSLENJA.BackColor = Color.Transparent;
            this.layoutManagerformZAPOSLENI.Controls.Add(this.label1DATUMZAPOSLENJA, 0, 1);
            this.layoutManagerformZAPOSLENI.SetColumnSpan(this.label1DATUMZAPOSLENJA, 1);
            this.layoutManagerformZAPOSLENI.SetRowSpan(this.label1DATUMZAPOSLENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMZAPOSLENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMZAPOSLENJA.MinimumSize = size;
            size = new System.Drawing.Size(0xdf, 0x17);
            this.label1DATUMZAPOSLENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMZAPOSLENJA.Location = point;
            this.datePickerDATUMZAPOSLENJA.Name = "datePickerDATUMZAPOSLENJA";
            this.datePickerDATUMZAPOSLENJA.Tag = "DATUMZAPOSLENJA";
            this.datePickerDATUMZAPOSLENJA.TabIndex = 0;
            this.datePickerDATUMZAPOSLENJA.Anchor = AnchorStyles.Left;
            this.datePickerDATUMZAPOSLENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMZAPOSLENJA.Enabled = true;
            this.layoutManagerformZAPOSLENI.Controls.Add(this.datePickerDATUMZAPOSLENJA, 1, 1);
            this.layoutManagerformZAPOSLENI.SetColumnSpan(this.datePickerDATUMZAPOSLENJA, 1);
            this.layoutManagerformZAPOSLENI.SetRowSpan(this.datePickerDATUMZAPOSLENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMZAPOSLENJA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMZAPOSLENJA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMZAPOSLENJA.Size = size;
            this.Controls.Add(this.layoutManagerformZAPOSLENI);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceZAPOSLENI;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "ZAPOSLENIFormUserControl";
            this.Text = "ZAPOSLENI";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.ZAPOSLENIFormUserControl_Load);
            this.layoutManagerformZAPOSLENI.ResumeLayout(false);
            this.layoutManagerformZAPOSLENI.PerformLayout();
            ((ISupportInitialize) this.bindingSourceZAPOSLENI).EndInit();
            this.dsZAPOSLENIDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.ZAPOSLENIController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceZAPOSLENI, this.ZAPOSLENIController.WorkItem, this))
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
            this.label1IDRADNIK.Text = StringResources.ZAPOSLENIIDRADNIKDescription;
            this.label1DATUMZAPOSLENJA.Text = StringResources.ZAPOSLENIDATUMZAPOSLENJADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
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
            if (!this.ZAPOSLENIController.WorkItem.Items.Contains("ZAPOSLENI|ZAPOSLENI"))
            {
                this.ZAPOSLENIController.WorkItem.Items.Add(this.bindingSourceZAPOSLENI, "ZAPOSLENI|ZAPOSLENI");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsZAPOSLENIDataSet1.ZAPOSLENI.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.ZAPOSLENIController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.ZAPOSLENIController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.ZAPOSLENIController.Update(this))
            {
                this.ZAPOSLENIController.DataSet = new ZAPOSLENIDataSet();
                DataSetUtil.AddEmptyRow(this.ZAPOSLENIController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.ZAPOSLENIController.DataSet.ZAPOSLENI[0];
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
                    ((DataRowView) this.bindingSourceZAPOSLENI.Current).Row["IDRADNIK"] = RuntimeHelpers.GetObjectValue(row["IDRADNIK"]);
                    this.bindingSourceZAPOSLENI.ResetCurrentItem();
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

        private void ZAPOSLENIFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.ZAPOSLENIDescription;
            this.errorProvider1.ContainerControl = this;
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

        protected virtual UltraDateTimeEditor datePickerDATUMZAPOSLENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMZAPOSLENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMZAPOSLENJA = value;
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

        protected virtual UltraLabel label1DATUMZAPOSLENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMZAPOSLENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMZAPOSLENJA = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.ZAPOSLENIController ZAPOSLENIController { get; set; }
    }
}

