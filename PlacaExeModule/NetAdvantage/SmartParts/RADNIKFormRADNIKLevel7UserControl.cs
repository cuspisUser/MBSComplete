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
    public class RADNIKFormRADNIKLevel7UserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDGRUPEKOEF")]
        private GRUPEKOEFComboBox _comboIDGRUPEKOEF;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1DODATNIKOEFICIJENT")]
        private UltraLabel _label1DODATNIKOEFICIJENT;
        [AccessedThroughProperty("label1IDGRUPEKOEF")]
        private UltraLabel _label1IDGRUPEKOEF;
        [AccessedThroughProperty("label1NAZIVGRUPEKOEF")]
        private UltraLabel _label1NAZIVGRUPEKOEF;
        [AccessedThroughProperty("labelNAZIVGRUPEKOEF")]
        private UltraLabel _labelNAZIVGRUPEKOEF;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textDODATNIKOEFICIJENT")]
        private UltraNumericEditor _textDODATNIKOEFICIJENT;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRADNIKLevel7;
        private IContainer components = null;
        private RADNIKDataSet dsRADNIKDataSet1;
        protected TableLayoutPanel layoutManagerformRADNIKLevel7;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RADNIKDataSet.RADNIKLevel7Row m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RADNIKLevel7";
        private string m_FrameworkDescription = StringResources.RADNIKDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public RADNIKFormRADNIKLevel7UserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("RADNIKLevel7AddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("RADNIKLevel7AddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (RADNIKDataSet.RADNIKLevel7Row) ((DataRowView) this.bindingSourceRADNIKLevel7.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsRADNIKDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceRADNIKLevel7.DataSource = this.RADNIKController.DataSet;
            this.dsRADNIKDataSet1 = this.RADNIKController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/GRUPEKOEF", Thread=ThreadOption.UserInterface)]
        public void comboIDGRUPEKOEF_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDGRUPEKOEF.Fill();
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
            this.dsRADNIKDataSet1 = (RADNIKDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceRADNIKLevel7.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsRADNIKDataSet1.Tables["RADNIKLevel7"]);
            this.bindingSourceRADNIKLevel7.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RADNIK", this.m_Mode, this.dsRADNIKDataSet1, this.dsRADNIKDataSet1.RADNIKLevel7.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (RADNIKDataSet.RADNIKLevel7Row) ((DataRowView) this.bindingSourceRADNIKLevel7.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RADNIKDataSet.RADNIKLevel7Row) ((DataRowView) this.bindingSourceRADNIKLevel7.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(RADNIKFormRADNIKLevel7UserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRADNIKLevel7 = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKLevel7).BeginInit();
            this.layoutManagerformRADNIKLevel7 = new TableLayoutPanel();
            this.layoutManagerformRADNIKLevel7.SuspendLayout();
            this.layoutManagerformRADNIKLevel7.AutoSize = true;
            this.layoutManagerformRADNIKLevel7.Dock = DockStyle.Fill;
            this.layoutManagerformRADNIKLevel7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRADNIKLevel7.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRADNIKLevel7.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRADNIKLevel7.Size = size;
            this.layoutManagerformRADNIKLevel7.ColumnCount = 2;
            this.layoutManagerformRADNIKLevel7.RowCount = 5;
            this.layoutManagerformRADNIKLevel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKLevel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKLevel7.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKLevel7.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKLevel7.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKLevel7.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKLevel7.RowStyles.Add(new RowStyle());
            this.label1IDGRUPEKOEF = new UltraLabel();
            this.comboIDGRUPEKOEF = new GRUPEKOEFComboBox();
            this.label1NAZIVGRUPEKOEF = new UltraLabel();
            this.labelNAZIVGRUPEKOEF = new UltraLabel();
            this.label1DODATNIKOEFICIJENT = new UltraLabel();
            this.textDODATNIKOEFICIJENT = new UltraNumericEditor();
            ((ISupportInitialize) this.textDODATNIKOEFICIJENT).BeginInit();
            this.dsRADNIKDataSet1 = new RADNIKDataSet();
            this.dsRADNIKDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRADNIKDataSet1.DataSetName = "dsRADNIK";
            this.dsRADNIKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRADNIKLevel7.DataSource = this.dsRADNIKDataSet1;
            this.bindingSourceRADNIKLevel7.DataMember = "RADNIKLevel7";
            ((ISupportInitialize) this.bindingSourceRADNIKLevel7).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDGRUPEKOEF.Location = point;
            this.label1IDGRUPEKOEF.Name = "label1IDGRUPEKOEF";
            this.label1IDGRUPEKOEF.TabIndex = 1;
            this.label1IDGRUPEKOEF.Tag = "labelIDGRUPEKOEF";
            this.label1IDGRUPEKOEF.Text = "Šifra:";
            this.label1IDGRUPEKOEF.StyleSetName = "FieldUltraLabel";
            this.label1IDGRUPEKOEF.AutoSize = true;
            this.label1IDGRUPEKOEF.Anchor = AnchorStyles.Left;
            this.label1IDGRUPEKOEF.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDGRUPEKOEF.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDGRUPEKOEF.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDGRUPEKOEF.ImageSize = size;
            this.label1IDGRUPEKOEF.Appearance.ForeColor = Color.Black;
            this.label1IDGRUPEKOEF.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKLevel7.Controls.Add(this.label1IDGRUPEKOEF, 0, 0);
            this.layoutManagerformRADNIKLevel7.SetColumnSpan(this.label1IDGRUPEKOEF, 1);
            this.layoutManagerformRADNIKLevel7.SetRowSpan(this.label1IDGRUPEKOEF, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDGRUPEKOEF.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDGRUPEKOEF.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDGRUPEKOEF.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDGRUPEKOEF.Location = point;
            this.comboIDGRUPEKOEF.Name = "comboIDGRUPEKOEF";
            this.comboIDGRUPEKOEF.Tag = "IDGRUPEKOEF";
            this.comboIDGRUPEKOEF.TabIndex = 0;
            this.comboIDGRUPEKOEF.Anchor = AnchorStyles.Left;
            this.comboIDGRUPEKOEF.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDGRUPEKOEF.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDGRUPEKOEF.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDGRUPEKOEF.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDGRUPEKOEF.Enabled = true;
            this.comboIDGRUPEKOEF.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKLevel7, "IDGRUPEKOEF"));
            this.comboIDGRUPEKOEF.ShowPictureBox = true;
            this.comboIDGRUPEKOEF.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDGRUPEKOEF);
            this.comboIDGRUPEKOEF.ValueMember = "IDGRUPEKOEF";
            this.comboIDGRUPEKOEF.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDGRUPEKOEF);
            this.layoutManagerformRADNIKLevel7.Controls.Add(this.comboIDGRUPEKOEF, 1, 0);
            this.layoutManagerformRADNIKLevel7.SetColumnSpan(this.comboIDGRUPEKOEF, 1);
            this.layoutManagerformRADNIKLevel7.SetRowSpan(this.comboIDGRUPEKOEF, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDGRUPEKOEF.Margin = padding;
            size = new System.Drawing.Size(0x5b, 0x17);
            this.comboIDGRUPEKOEF.MinimumSize = size;
            size = new System.Drawing.Size(0x5b, 0x17);
            this.comboIDGRUPEKOEF.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVGRUPEKOEF.Location = point;
            this.label1NAZIVGRUPEKOEF.Name = "label1NAZIVGRUPEKOEF";
            this.label1NAZIVGRUPEKOEF.TabIndex = 1;
            this.label1NAZIVGRUPEKOEF.Tag = "labelNAZIVGRUPEKOEF";
            this.label1NAZIVGRUPEKOEF.Text = "Naziv:";
            this.label1NAZIVGRUPEKOEF.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVGRUPEKOEF.AutoSize = true;
            this.label1NAZIVGRUPEKOEF.Anchor = AnchorStyles.Left;
            this.label1NAZIVGRUPEKOEF.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVGRUPEKOEF.Appearance.ForeColor = Color.Black;
            this.label1NAZIVGRUPEKOEF.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKLevel7.Controls.Add(this.label1NAZIVGRUPEKOEF, 0, 1);
            this.layoutManagerformRADNIKLevel7.SetColumnSpan(this.label1NAZIVGRUPEKOEF, 1);
            this.layoutManagerformRADNIKLevel7.SetRowSpan(this.label1NAZIVGRUPEKOEF, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVGRUPEKOEF.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVGRUPEKOEF.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1NAZIVGRUPEKOEF.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVGRUPEKOEF.Location = point;
            this.labelNAZIVGRUPEKOEF.Name = "labelNAZIVGRUPEKOEF";
            this.labelNAZIVGRUPEKOEF.Tag = "NAZIVGRUPEKOEF";
            this.labelNAZIVGRUPEKOEF.TabIndex = 0;
            this.labelNAZIVGRUPEKOEF.Anchor = AnchorStyles.Left;
            this.labelNAZIVGRUPEKOEF.BackColor = Color.Transparent;
            this.labelNAZIVGRUPEKOEF.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKLevel7, "NAZIVGRUPEKOEF"));
            this.labelNAZIVGRUPEKOEF.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKLevel7.Controls.Add(this.labelNAZIVGRUPEKOEF, 1, 1);
            this.layoutManagerformRADNIKLevel7.SetColumnSpan(this.labelNAZIVGRUPEKOEF, 1);
            this.layoutManagerformRADNIKLevel7.SetRowSpan(this.labelNAZIVGRUPEKOEF, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVGRUPEKOEF.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVGRUPEKOEF.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVGRUPEKOEF.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DODATNIKOEFICIJENT.Location = point;
            this.label1DODATNIKOEFICIJENT.Name = "label1DODATNIKOEFICIJENT";
            this.label1DODATNIKOEFICIJENT.TabIndex = 1;
            this.label1DODATNIKOEFICIJENT.Tag = "labelDODATNIKOEFICIJENT";
            this.label1DODATNIKOEFICIJENT.Text = "Koeficijent:";
            this.label1DODATNIKOEFICIJENT.StyleSetName = "FieldUltraLabel";
            this.label1DODATNIKOEFICIJENT.AutoSize = true;
            this.label1DODATNIKOEFICIJENT.Anchor = AnchorStyles.Left;
            this.label1DODATNIKOEFICIJENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1DODATNIKOEFICIJENT.Appearance.ForeColor = Color.Black;
            this.label1DODATNIKOEFICIJENT.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKLevel7.Controls.Add(this.label1DODATNIKOEFICIJENT, 0, 3);
            this.layoutManagerformRADNIKLevel7.SetColumnSpan(this.label1DODATNIKOEFICIJENT, 1);
            this.layoutManagerformRADNIKLevel7.SetRowSpan(this.label1DODATNIKOEFICIJENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DODATNIKOEFICIJENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DODATNIKOEFICIJENT.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x17);
            this.label1DODATNIKOEFICIJENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDODATNIKOEFICIJENT.Location = point;
            this.textDODATNIKOEFICIJENT.Name = "textDODATNIKOEFICIJENT";
            this.textDODATNIKOEFICIJENT.Tag = "DODATNIKOEFICIJENT";
            this.textDODATNIKOEFICIJENT.TabIndex = 0;
            this.textDODATNIKOEFICIJENT.Anchor = AnchorStyles.Left;
            this.textDODATNIKOEFICIJENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDODATNIKOEFICIJENT.ReadOnly = false;
            this.textDODATNIKOEFICIJENT.PromptChar = ' ';
            this.textDODATNIKOEFICIJENT.Enter += new EventHandler(this.numericEditor_Enter);
            this.textDODATNIKOEFICIJENT.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKLevel7, "DODATNIKOEFICIJENT"));
            this.textDODATNIKOEFICIJENT.NumericType = NumericType.Double;
            this.textDODATNIKOEFICIJENT.MaxValue = 79228162514264337593543950335M;
            this.textDODATNIKOEFICIJENT.MinValue = -79228162514264337593543950335M;
            this.textDODATNIKOEFICIJENT.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            this.layoutManagerformRADNIKLevel7.Controls.Add(this.textDODATNIKOEFICIJENT, 1, 3);
            this.layoutManagerformRADNIKLevel7.SetColumnSpan(this.textDODATNIKOEFICIJENT, 1);
            this.layoutManagerformRADNIKLevel7.SetRowSpan(this.textDODATNIKOEFICIJENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDODATNIKOEFICIJENT.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textDODATNIKOEFICIJENT.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textDODATNIKOEFICIJENT.Size = size;
            this.Controls.Add(this.layoutManagerformRADNIKLevel7);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRADNIKLevel7;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RADNIKFormRADNIKLevel7UserControl";
            this.Text = " Koeficijenti";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RADNIKFormUserControl_Load);
            this.layoutManagerformRADNIKLevel7.ResumeLayout(false);
            this.layoutManagerformRADNIKLevel7.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRADNIKLevel7).EndInit();
            ((ISupportInitialize) this.textDODATNIKOEFICIJENT).EndInit();
            this.dsRADNIKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RADNIKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIKLevel7, this.RADNIKController.WorkItem, this))
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
            this.label1IDGRUPEKOEF.Text = StringResources.RADNIKIDGRUPEKOEFDescription;
            this.label1NAZIVGRUPEKOEF.Text = StringResources.RADNIKNAZIVGRUPEKOEFDescription;
            this.label1DODATNIKOEFICIJENT.Text = StringResources.RADNIKDODATNIKOEFICIJENTDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewGOOBRACUN")]
        public void NewGOOBRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewGOOBRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewOTISLI")]
        public void NewOTISLIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewOTISLI(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewZAPOSLENI")]
        public void NewZAPOSLENIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewZAPOSLENI(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDGRUPEKOEF(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("GRUPEKOEF", null, DeklaritMode.Insert));
            }
        }

        private void RADNIKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RADNIKRADNIKLevel7LevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIKLevel7|RADNIKLevel7"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKLevel7, "RADNIKLevel7|RADNIKLevel7");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("RADNIKLevel7SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedIDGRUPEKOEF(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDGRUPEKOEF.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDGRUPEKOEF.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIKLevel7.Current).Row["IDGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(row["IDGRUPEKOEF"]);
                    ((DataRowView) this.bindingSourceRADNIKLevel7.Current).Row["NAZIVGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(row["NAZIVGRUPEKOEF"]);
                    this.bindingSourceRADNIKLevel7.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboIDGRUPEKOEF.Focus();
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

        [LocalCommandHandler("ViewGOOBRACUN")]
        public void ViewGOOBRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewGOOBRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewOTISLI")]
        public void ViewOTISLIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewOTISLI(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewZAPOSLENI")]
        public void ViewZAPOSLENIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewZAPOSLENI(this.m_CurrentRow);
            }
        }

        protected virtual GRUPEKOEFComboBox comboIDGRUPEKOEF
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDGRUPEKOEF;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDGRUPEKOEF = value;
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

        protected virtual UltraLabel label1DODATNIKOEFICIJENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DODATNIKOEFICIJENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DODATNIKOEFICIJENT = value;
            }
        }

        protected virtual UltraLabel label1IDGRUPEKOEF
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDGRUPEKOEF;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDGRUPEKOEF = value;
            }
        }

        protected virtual UltraLabel label1NAZIVGRUPEKOEF
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVGRUPEKOEF;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVGRUPEKOEF = value;
            }
        }

        protected virtual UltraLabel labelNAZIVGRUPEKOEF
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVGRUPEKOEF;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVGRUPEKOEF = value;
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
        public NetAdvantage.Controllers.RADNIKController RADNIKController { get; set; }

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

        protected virtual UltraNumericEditor textDODATNIKOEFICIJENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDODATNIKOEFICIJENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDODATNIKOEFICIJENT = value;
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

