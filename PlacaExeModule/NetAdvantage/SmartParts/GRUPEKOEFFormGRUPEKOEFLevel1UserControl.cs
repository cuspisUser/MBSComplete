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
    public class GRUPEKOEFFormGRUPEKOEFLevel1UserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDELEMENT")]
        private PROVIDER_BRUTOComboBox _comboIDELEMENT;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDELEMENT")]
        private UltraLabel _label1IDELEMENT;
        [AccessedThroughProperty("label1IDMZOSTABLICE")]
        private UltraLabel _label1IDMZOSTABLICE;
        [AccessedThroughProperty("label1NAZIVELEMENT")]
        private UltraLabel _label1NAZIVELEMENT;
        [AccessedThroughProperty("labelNAZIVELEMENT")]
        private UltraLabel _labelNAZIVELEMENT;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDMZOSTABLICE")]
        private UltraNumericEditor _textIDMZOSTABLICE;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceGRUPEKOEFLevel1;
        private IContainer components = null;
        private GRUPEKOEFDataSet dsGRUPEKOEFDataSet1;
        protected TableLayoutPanel layoutManagerformGRUPEKOEFLevel1;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private GRUPEKOEFDataSet.GRUPEKOEFLevel1Row m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "GRUPEKOEFLevel1";
        private string m_FrameworkDescription = StringResources.GRUPEKOEFDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public GRUPEKOEFFormGRUPEKOEFLevel1UserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("GRUPEKOEFLevel1AddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("GRUPEKOEFLevel1AddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (GRUPEKOEFDataSet.GRUPEKOEFLevel1Row) ((DataRowView) this.bindingSourceGRUPEKOEFLevel1.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptMZOSTABLICEIDMZOSTABLICE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.GRUPEKOEFController.SelectMZOSTABLICEIDMZOSTABLICE(fillMethod, fillByRow);
            this.UpdateValuesMZOSTABLICEIDMZOSTABLICE(result);
        }

        private void CallViewMZOSTABLICEIDMZOSTABLICE(object sender, EventArgs e)
        {
            DataRow result = this.GRUPEKOEFController.ShowMZOSTABLICEIDMZOSTABLICE(this.m_CurrentRow);
            this.UpdateValuesMZOSTABLICEIDMZOSTABLICE(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsGRUPEKOEFDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceGRUPEKOEFLevel1.DataSource = this.GRUPEKOEFController.DataSet;
            this.dsGRUPEKOEFDataSet1 = this.GRUPEKOEFController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ELEMENT", Thread=ThreadOption.UserInterface)]
        public void comboIDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDELEMENT.Fill();
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

        private void FillProviderCombocomboIDELEMENT()
        {
            object objectValue = RuntimeHelpers.GetObjectValue(this.comboIDELEMENT.Value);
            this.comboIDELEMENT.Fill();
            if (objectValue != null)
            {
                this.comboIDELEMENT.Value = RuntimeHelpers.GetObjectValue(objectValue);
            }
        }

        private void GRUPEKOEFFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.GRUPEKOEFGRUPEKOEFLevel1LevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void Initialize(DeklaritMode mode, DataRow parentRow, bool isCopy)
        {
            this.m_ParentRow = parentRow;
            this.dsGRUPEKOEFDataSet1 = (GRUPEKOEFDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceGRUPEKOEFLevel1.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsGRUPEKOEFDataSet1.Tables["GRUPEKOEFLevel1"]);
            this.bindingSourceGRUPEKOEFLevel1.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "GRUPEKOEF", this.m_Mode, this.dsGRUPEKOEFDataSet1, this.dsGRUPEKOEFDataSet1.GRUPEKOEFLevel1.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (GRUPEKOEFDataSet.GRUPEKOEFLevel1Row) ((DataRowView) this.bindingSourceGRUPEKOEFLevel1.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (GRUPEKOEFDataSet.GRUPEKOEFLevel1Row) ((DataRowView) this.bindingSourceGRUPEKOEFLevel1.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.FillProviderCombocomboIDELEMENT();
            if (this.m_BaseMethods.IsInsert())
            {
                this.comboIDELEMENT.SelectedIndex = -1;
            }
            if (this.comboIDELEMENT.DataBindings["Value"] != null)
            {
                this.comboIDELEMENT.DataBindings.Remove(this.comboIDELEMENT.DataBindings["Value"]);
            }
            this.comboIDELEMENT.DataBindings.Add(new Binding("Value", this.bindingSourceGRUPEKOEFLevel1, "IDELEMENT"));
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(GRUPEKOEFFormGRUPEKOEFLevel1UserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceGRUPEKOEFLevel1 = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceGRUPEKOEFLevel1).BeginInit();
            this.layoutManagerformGRUPEKOEFLevel1 = new TableLayoutPanel();
            this.layoutManagerformGRUPEKOEFLevel1.SuspendLayout();
            this.layoutManagerformGRUPEKOEFLevel1.AutoSize = true;
            this.layoutManagerformGRUPEKOEFLevel1.Dock = DockStyle.Fill;
            this.layoutManagerformGRUPEKOEFLevel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformGRUPEKOEFLevel1.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformGRUPEKOEFLevel1.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformGRUPEKOEFLevel1.Size = size;
            this.layoutManagerformGRUPEKOEFLevel1.ColumnCount = 2;
            this.layoutManagerformGRUPEKOEFLevel1.RowCount = 4;
            this.layoutManagerformGRUPEKOEFLevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGRUPEKOEFLevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGRUPEKOEFLevel1.RowStyles.Add(new RowStyle());
            this.layoutManagerformGRUPEKOEFLevel1.RowStyles.Add(new RowStyle());
            this.layoutManagerformGRUPEKOEFLevel1.RowStyles.Add(new RowStyle());
            this.layoutManagerformGRUPEKOEFLevel1.RowStyles.Add(new RowStyle());
            this.label1IDELEMENT = new UltraLabel();
            this.comboIDELEMENT = new PROVIDER_BRUTOComboBox();
            this.label1NAZIVELEMENT = new UltraLabel();
            this.labelNAZIVELEMENT = new UltraLabel();
            this.label1IDMZOSTABLICE = new UltraLabel();
            this.textIDMZOSTABLICE = new UltraNumericEditor();
            ((ISupportInitialize) this.textIDMZOSTABLICE).BeginInit();
            this.dsGRUPEKOEFDataSet1 = new GRUPEKOEFDataSet();
            this.dsGRUPEKOEFDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsGRUPEKOEFDataSet1.DataSetName = "dsGRUPEKOEF";
            this.dsGRUPEKOEFDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceGRUPEKOEFLevel1.DataSource = this.dsGRUPEKOEFDataSet1;
            this.bindingSourceGRUPEKOEFLevel1.DataMember = "GRUPEKOEFLevel1";
            ((ISupportInitialize) this.bindingSourceGRUPEKOEFLevel1).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDELEMENT.Location = point;
            this.label1IDELEMENT.Name = "label1IDELEMENT";
            this.label1IDELEMENT.TabIndex = 1;
            this.label1IDELEMENT.Tag = "labelIDELEMENT";
            this.label1IDELEMENT.Text = "Šifra elementa:";
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
            this.layoutManagerformGRUPEKOEFLevel1.Controls.Add(this.label1IDELEMENT, 0, 0);
            this.layoutManagerformGRUPEKOEFLevel1.SetColumnSpan(this.label1IDELEMENT, 1);
            this.layoutManagerformGRUPEKOEFLevel1.SetRowSpan(this.label1IDELEMENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x17);
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
            this.comboIDELEMENT.FillAtStartup = false;
            this.comboIDELEMENT.ShowPictureBox = true;
            this.comboIDELEMENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDELEMENT);
            this.comboIDELEMENT.ValueMember = "IDELEMENT";
            this.comboIDELEMENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDELEMENT);
            this.layoutManagerformGRUPEKOEFLevel1.Controls.Add(this.comboIDELEMENT, 1, 0);
            this.layoutManagerformGRUPEKOEFLevel1.SetColumnSpan(this.comboIDELEMENT, 1);
            this.layoutManagerformGRUPEKOEFLevel1.SetRowSpan(this.comboIDELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVELEMENT.Location = point;
            this.label1NAZIVELEMENT.Name = "label1NAZIVELEMENT";
            this.label1NAZIVELEMENT.TabIndex = 1;
            this.label1NAZIVELEMENT.Tag = "labelNAZIVELEMENT";
            this.label1NAZIVELEMENT.Text = "Naziv elementa:";
            this.label1NAZIVELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVELEMENT.AutoSize = true;
            this.label1NAZIVELEMENT.Anchor = AnchorStyles.Left;
            this.label1NAZIVELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVELEMENT.Appearance.ForeColor = Color.Black;
            this.label1NAZIVELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformGRUPEKOEFLevel1.Controls.Add(this.label1NAZIVELEMENT, 0, 1);
            this.layoutManagerformGRUPEKOEFLevel1.SetColumnSpan(this.label1NAZIVELEMENT, 1);
            this.layoutManagerformGRUPEKOEFLevel1.SetRowSpan(this.label1NAZIVELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x73, 0x17);
            this.label1NAZIVELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVELEMENT.Location = point;
            this.labelNAZIVELEMENT.Name = "labelNAZIVELEMENT";
            this.labelNAZIVELEMENT.Tag = "NAZIVELEMENT";
            this.labelNAZIVELEMENT.TabIndex = 0;
            this.labelNAZIVELEMENT.Anchor = AnchorStyles.Left;
            this.labelNAZIVELEMENT.BackColor = Color.Transparent;
            this.labelNAZIVELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceGRUPEKOEFLevel1, "NAZIVELEMENT"));
            this.labelNAZIVELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformGRUPEKOEFLevel1.Controls.Add(this.labelNAZIVELEMENT, 1, 1);
            this.layoutManagerformGRUPEKOEFLevel1.SetColumnSpan(this.labelNAZIVELEMENT, 1);
            this.layoutManagerformGRUPEKOEFLevel1.SetRowSpan(this.labelNAZIVELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDMZOSTABLICE.Location = point;
            this.label1IDMZOSTABLICE.Name = "label1IDMZOSTABLICE";
            this.label1IDMZOSTABLICE.TabIndex = 1;
            this.label1IDMZOSTABLICE.Tag = "labelIDMZOSTABLICE";
            this.label1IDMZOSTABLICE.Text = "MZOŠ Tablica:";
            this.label1IDMZOSTABLICE.StyleSetName = "FieldUltraLabel";
            this.label1IDMZOSTABLICE.AutoSize = true;
            this.label1IDMZOSTABLICE.Anchor = AnchorStyles.Left;
            this.label1IDMZOSTABLICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDMZOSTABLICE.Appearance.ForeColor = Color.Black;
            this.label1IDMZOSTABLICE.BackColor = Color.Transparent;
            this.layoutManagerformGRUPEKOEFLevel1.Controls.Add(this.label1IDMZOSTABLICE, 0, 2);
            this.layoutManagerformGRUPEKOEFLevel1.SetColumnSpan(this.label1IDMZOSTABLICE, 1);
            this.layoutManagerformGRUPEKOEFLevel1.SetRowSpan(this.label1IDMZOSTABLICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDMZOSTABLICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDMZOSTABLICE.MinimumSize = size;
            size = new System.Drawing.Size(0x67, 0x17);
            this.label1IDMZOSTABLICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDMZOSTABLICE.Location = point;
            this.textIDMZOSTABLICE.Name = "textIDMZOSTABLICE";
            this.textIDMZOSTABLICE.Tag = "IDMZOSTABLICE";
            this.textIDMZOSTABLICE.TabIndex = 0;
            this.textIDMZOSTABLICE.Anchor = AnchorStyles.Left;
            this.textIDMZOSTABLICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDMZOSTABLICE.ReadOnly = false;
            this.textIDMZOSTABLICE.PromptChar = ' ';
            this.textIDMZOSTABLICE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDMZOSTABLICE.DataBindings.Add(new Binding("Value", this.bindingSourceGRUPEKOEFLevel1, "IDMZOSTABLICE"));
            this.textIDMZOSTABLICE.NumericType = NumericType.Integer;
            this.textIDMZOSTABLICE.MaskInput = "{LOC}-nnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonMZOSTABLICEIDMZOSTABLICE",
                Tag = "editorButtonMZOSTABLICEIDMZOSTABLICE",
                Text = "..."
            };
            this.textIDMZOSTABLICE.ButtonsRight.Add(button);
            this.textIDMZOSTABLICE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptMZOSTABLICEIDMZOSTABLICE);
            this.layoutManagerformGRUPEKOEFLevel1.Controls.Add(this.textIDMZOSTABLICE, 1, 2);
            this.layoutManagerformGRUPEKOEFLevel1.SetColumnSpan(this.textIDMZOSTABLICE, 1);
            this.layoutManagerformGRUPEKOEFLevel1.SetRowSpan(this.textIDMZOSTABLICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDMZOSTABLICE.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDMZOSTABLICE.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDMZOSTABLICE.Size = size;
            this.Controls.Add(this.layoutManagerformGRUPEKOEFLevel1);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceGRUPEKOEFLevel1;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "GRUPEKOEFFormGRUPEKOEFLevel1UserControl";
            this.Text = " Elementi u grupi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.GRUPEKOEFFormUserControl_Load);
            this.layoutManagerformGRUPEKOEFLevel1.ResumeLayout(false);
            this.layoutManagerformGRUPEKOEFLevel1.PerformLayout();
            ((ISupportInitialize) this.bindingSourceGRUPEKOEFLevel1).EndInit();
            ((ISupportInitialize) this.textIDMZOSTABLICE).EndInit();
            this.dsGRUPEKOEFDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.GRUPEKOEFController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceGRUPEKOEFLevel1, this.GRUPEKOEFController.WorkItem, this))
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
            this.label1IDELEMENT.Text = StringResources.GRUPEKOEFIDELEMENTDescription;
            this.label1NAZIVELEMENT.Text = StringResources.GRUPEKOEFNAZIVELEMENTDescription;
            this.label1IDMZOSTABLICE.Text = StringResources.GRUPEKOEFIDMZOSTABLICEDescription;
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

        private void RegisterBindingSources()
        {
            if (!this.GRUPEKOEFController.WorkItem.Items.Contains("GRUPEKOEFLevel1|GRUPEKOEFLevel1"))
            {
                this.GRUPEKOEFController.WorkItem.Items.Add(this.bindingSourceGRUPEKOEFLevel1, "GRUPEKOEFLevel1|GRUPEKOEFLevel1");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("GRUPEKOEFLevel1SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedIDELEMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDELEMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDELEMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceGRUPEKOEFLevel1.Current).Row["IDELEMENT"] = RuntimeHelpers.GetObjectValue(row["IDELEMENT"]);
                    ((DataRowView) this.bindingSourceGRUPEKOEFLevel1.Current).Row["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(row["NAZIVELEMENT"]);
                    this.bindingSourceGRUPEKOEFLevel1.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboIDELEMENT.Focus();
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

        private void UpdateValuesMZOSTABLICEIDMZOSTABLICE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceGRUPEKOEFLevel1.Current).Row["IDMZOSTABLICE"] = RuntimeHelpers.GetObjectValue(result["IDMZOSTABLICE"]);
                this.bindingSourceGRUPEKOEFLevel1.ResetCurrentItem();
            }
        }

        protected virtual PROVIDER_BRUTOComboBox comboIDELEMENT
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.GRUPEKOEFController GRUPEKOEFController { get; set; }

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

        protected virtual UltraLabel label1IDMZOSTABLICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDMZOSTABLICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDMZOSTABLICE = value;
            }
        }

        protected virtual UltraLabel label1NAZIVELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVELEMENT = value;
            }
        }

        protected virtual UltraLabel labelNAZIVELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVELEMENT = value;
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

        protected virtual UltraNumericEditor textIDMZOSTABLICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDMZOSTABLICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDMZOSTABLICE = value;
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

