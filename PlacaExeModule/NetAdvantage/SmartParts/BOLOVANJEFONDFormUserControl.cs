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
    public class BOLOVANJEFONDFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboELEMENTBOLOVANJEIDELEMENT")]
        private ELEMENTComboBox _comboELEMENTBOLOVANJEIDELEMENT;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1ELEMENTBOLOVANJEIDELEMENT")]
        private UltraLabel _label1ELEMENTBOLOVANJEIDELEMENT;
        [AccessedThroughProperty("label1ELEMENTBOLOVANJENAZIVELEMENT")]
        private UltraLabel _label1ELEMENTBOLOVANJENAZIVELEMENT;
        [AccessedThroughProperty("label1KOLONA")]
        private UltraLabel _label1KOLONA;
        [AccessedThroughProperty("labelELEMENTBOLOVANJENAZIVELEMENT")]
        private UltraLabel _labelELEMENTBOLOVANJENAZIVELEMENT;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textKOLONA")]
        private UltraNumericEditor _textKOLONA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceBOLOVANJEFOND;
        private IContainer components = null;
        private BOLOVANJEFONDDataSet dsBOLOVANJEFONDDataSet1;
        protected TableLayoutPanel layoutManagerformBOLOVANJEFOND;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private BOLOVANJEFONDDataSet.BOLOVANJEFONDRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "BOLOVANJEFOND";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.BOLOVANJEFONDDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public BOLOVANJEFONDFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();

            this.label1KOLONA.Text = "Kolona ER-1 obrasca:";
        }

        private void BOLOVANJEFONDFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.BOLOVANJEFONDDescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void ChangeBinding()
        {
            this.bindingSourceBOLOVANJEFOND.DataSource = this.BOLOVANJEFONDController.DataSet;
            this.dsBOLOVANJEFONDDataSet1 = this.BOLOVANJEFONDController.DataSet;
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
        public void comboELEMENTBOLOVANJEIDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboELEMENTBOLOVANJEIDELEMENT.Fill();
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
                    enumerator = this.dsBOLOVANJEFONDDataSet1.BOLOVANJEFOND.Rows.GetEnumerator();
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
                if (this.BOLOVANJEFONDController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "BOLOVANJEFOND", this.m_Mode, this.dsBOLOVANJEFONDDataSet1, this.dsBOLOVANJEFONDDataSet1.BOLOVANJEFOND.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsBOLOVANJEFONDDataSet1.BOLOVANJEFOND[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (BOLOVANJEFONDDataSet.BOLOVANJEFONDRow) ((DataRowView) this.bindingSourceBOLOVANJEFOND.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    this.m_BaseMethods.SetReadOnly(str, true);
                    this.m_BaseMethods.GetLabelControl(str).Visible = false;
                    this.m_BaseMethods.GetControl(str).Visible = false;
                }
            }
            this.SetFocusInFirstField();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(BOLOVANJEFONDFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceBOLOVANJEFOND = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceBOLOVANJEFOND).BeginInit();
            this.layoutManagerformBOLOVANJEFOND = new TableLayoutPanel();
            this.layoutManagerformBOLOVANJEFOND.SuspendLayout();
            this.layoutManagerformBOLOVANJEFOND.AutoSize = true;
            this.layoutManagerformBOLOVANJEFOND.Dock = DockStyle.Fill;
            this.layoutManagerformBOLOVANJEFOND.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformBOLOVANJEFOND.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformBOLOVANJEFOND.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformBOLOVANJEFOND.Size = size;
            this.layoutManagerformBOLOVANJEFOND.ColumnCount = 2;
            this.layoutManagerformBOLOVANJEFOND.RowCount = 4;
            this.layoutManagerformBOLOVANJEFOND.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBOLOVANJEFOND.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBOLOVANJEFOND.RowStyles.Add(new RowStyle());
            this.layoutManagerformBOLOVANJEFOND.RowStyles.Add(new RowStyle());
            this.layoutManagerformBOLOVANJEFOND.RowStyles.Add(new RowStyle());
            this.layoutManagerformBOLOVANJEFOND.RowStyles.Add(new RowStyle());
            this.label1ELEMENTBOLOVANJEIDELEMENT = new UltraLabel();
            this.comboELEMENTBOLOVANJEIDELEMENT = new ELEMENTComboBox();
            this.label1ELEMENTBOLOVANJENAZIVELEMENT = new UltraLabel();
            this.labelELEMENTBOLOVANJENAZIVELEMENT = new UltraLabel();
            this.label1KOLONA = new UltraLabel();
            this.textKOLONA = new UltraNumericEditor();
            ((ISupportInitialize) this.textKOLONA).BeginInit();
            this.dsBOLOVANJEFONDDataSet1 = new BOLOVANJEFONDDataSet();
            this.dsBOLOVANJEFONDDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsBOLOVANJEFONDDataSet1.DataSetName = "dsBOLOVANJEFOND";
            this.dsBOLOVANJEFONDDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceBOLOVANJEFOND.DataSource = this.dsBOLOVANJEFONDDataSet1;
            this.bindingSourceBOLOVANJEFOND.DataMember = "BOLOVANJEFOND";
            ((ISupportInitialize) this.bindingSourceBOLOVANJEFOND).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1ELEMENTBOLOVANJEIDELEMENT.Location = point;
            this.label1ELEMENTBOLOVANJEIDELEMENT.Name = "label1ELEMENTBOLOVANJEIDELEMENT";
            this.label1ELEMENTBOLOVANJEIDELEMENT.TabIndex = 1;
            this.label1ELEMENTBOLOVANJEIDELEMENT.Tag = "labelELEMENTBOLOVANJEIDELEMENT";
            this.label1ELEMENTBOLOVANJEIDELEMENT.Text = "Šifra elementa:";
            this.label1ELEMENTBOLOVANJEIDELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1ELEMENTBOLOVANJEIDELEMENT.AutoSize = true;
            this.label1ELEMENTBOLOVANJEIDELEMENT.Anchor = AnchorStyles.Left;
            this.label1ELEMENTBOLOVANJEIDELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1ELEMENTBOLOVANJEIDELEMENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1ELEMENTBOLOVANJEIDELEMENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1ELEMENTBOLOVANJEIDELEMENT.ImageSize = size;
            this.label1ELEMENTBOLOVANJEIDELEMENT.Appearance.ForeColor = Color.Black;
            this.label1ELEMENTBOLOVANJEIDELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformBOLOVANJEFOND.Controls.Add(this.label1ELEMENTBOLOVANJEIDELEMENT, 0, 0);
            this.layoutManagerformBOLOVANJEFOND.SetColumnSpan(this.label1ELEMENTBOLOVANJEIDELEMENT, 1);
            this.layoutManagerformBOLOVANJEFOND.SetRowSpan(this.label1ELEMENTBOLOVANJEIDELEMENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1ELEMENTBOLOVANJEIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ELEMENTBOLOVANJEIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x17);
            this.label1ELEMENTBOLOVANJEIDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboELEMENTBOLOVANJEIDELEMENT.Location = point;
            this.comboELEMENTBOLOVANJEIDELEMENT.Name = "comboELEMENTBOLOVANJEIDELEMENT";
            this.comboELEMENTBOLOVANJEIDELEMENT.Tag = "ELEMENTBOLOVANJEIDELEMENT";
            this.comboELEMENTBOLOVANJEIDELEMENT.TabIndex = 0;
            this.comboELEMENTBOLOVANJEIDELEMENT.Anchor = AnchorStyles.Left;
            this.comboELEMENTBOLOVANJEIDELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboELEMENTBOLOVANJEIDELEMENT.DropDownStyle = DropDownStyle.DropDown;
            this.comboELEMENTBOLOVANJEIDELEMENT.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboELEMENTBOLOVANJEIDELEMENT.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboELEMENTBOLOVANJEIDELEMENT.Enabled = true;
            this.comboELEMENTBOLOVANJEIDELEMENT.DataBindings.Add(new Binding("Value", this.bindingSourceBOLOVANJEFOND, "ELEMENTBOLOVANJEIDELEMENT"));
            this.comboELEMENTBOLOVANJEIDELEMENT.ShowPictureBox = true;
            this.comboELEMENTBOLOVANJEIDELEMENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedELEMENTBOLOVANJEIDELEMENT);
            this.comboELEMENTBOLOVANJEIDELEMENT.ValueMember = "IDELEMENT";
            this.comboELEMENTBOLOVANJEIDELEMENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedELEMENTBOLOVANJEIDELEMENT);
            this.layoutManagerformBOLOVANJEFOND.Controls.Add(this.comboELEMENTBOLOVANJEIDELEMENT, 1, 0);
            this.layoutManagerformBOLOVANJEFOND.SetColumnSpan(this.comboELEMENTBOLOVANJEIDELEMENT, 1);
            this.layoutManagerformBOLOVANJEFOND.SetRowSpan(this.comboELEMENTBOLOVANJEIDELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboELEMENTBOLOVANJEIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboELEMENTBOLOVANJEIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboELEMENTBOLOVANJEIDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.Location = point;
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.Name = "label1ELEMENTBOLOVANJENAZIVELEMENT";
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.TabIndex = 1;
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.Tag = "labelELEMENTBOLOVANJENAZIVELEMENT";
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.Text = "Naziv elementa:";
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.AutoSize = true;
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.Anchor = AnchorStyles.Left;
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.Appearance.ForeColor = Color.Black;
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformBOLOVANJEFOND.Controls.Add(this.label1ELEMENTBOLOVANJENAZIVELEMENT, 0, 1);
            this.layoutManagerformBOLOVANJEFOND.SetColumnSpan(this.label1ELEMENTBOLOVANJENAZIVELEMENT, 1);
            this.layoutManagerformBOLOVANJEFOND.SetRowSpan(this.label1ELEMENTBOLOVANJENAZIVELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x73, 0x17);
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelELEMENTBOLOVANJENAZIVELEMENT.Location = point;
            this.labelELEMENTBOLOVANJENAZIVELEMENT.Name = "labelELEMENTBOLOVANJENAZIVELEMENT";
            this.labelELEMENTBOLOVANJENAZIVELEMENT.Tag = "ELEMENTBOLOVANJENAZIVELEMENT";
            this.labelELEMENTBOLOVANJENAZIVELEMENT.TabIndex = 0;
            this.labelELEMENTBOLOVANJENAZIVELEMENT.Anchor = AnchorStyles.Left;
            this.labelELEMENTBOLOVANJENAZIVELEMENT.BackColor = Color.Transparent;
            this.labelELEMENTBOLOVANJENAZIVELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceBOLOVANJEFOND, "ELEMENTBOLOVANJENAZIVELEMENT"));
            this.labelELEMENTBOLOVANJENAZIVELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformBOLOVANJEFOND.Controls.Add(this.labelELEMENTBOLOVANJENAZIVELEMENT, 1, 1);
            this.layoutManagerformBOLOVANJEFOND.SetColumnSpan(this.labelELEMENTBOLOVANJENAZIVELEMENT, 1);
            this.layoutManagerformBOLOVANJEFOND.SetRowSpan(this.labelELEMENTBOLOVANJENAZIVELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelELEMENTBOLOVANJENAZIVELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelELEMENTBOLOVANJENAZIVELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelELEMENTBOLOVANJENAZIVELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KOLONA.Location = point;
            this.label1KOLONA.Name = "label1KOLONA";
            this.label1KOLONA.TabIndex = 1;
            this.label1KOLONA.Tag = "labelKOLONA";
            this.label1KOLONA.Text = "Kolona ER-1 obrasca:";
            this.label1KOLONA.StyleSetName = "FieldUltraLabel";
            this.label1KOLONA.AutoSize = true;
            this.label1KOLONA.Anchor = AnchorStyles.Left;
            this.label1KOLONA.Appearance.TextVAlign = VAlign.Middle;
            this.label1KOLONA.Appearance.ForeColor = Color.Black;
            this.label1KOLONA.BackColor = Color.Transparent;
            this.layoutManagerformBOLOVANJEFOND.Controls.Add(this.label1KOLONA, 0, 2);
            this.layoutManagerformBOLOVANJEFOND.SetColumnSpan(this.label1KOLONA, 1);
            this.layoutManagerformBOLOVANJEFOND.SetRowSpan(this.label1KOLONA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KOLONA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KOLONA.MinimumSize = size;
            size = new System.Drawing.Size(0x86, 0x17);
            this.label1KOLONA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textKOLONA.Location = point;
            this.textKOLONA.Name = "textKOLONA";
            this.textKOLONA.Tag = "KOLONA";
            this.textKOLONA.TabIndex = 0;
            this.textKOLONA.Anchor = AnchorStyles.Left;
            this.textKOLONA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textKOLONA.ReadOnly = false;
            this.textKOLONA.PromptChar = ' ';
            this.textKOLONA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textKOLONA.DataBindings.Add(new Binding("Value", this.bindingSourceBOLOVANJEFOND, "KOLONA"));
            this.textKOLONA.NumericType = NumericType.Integer;
            this.textKOLONA.MaskInput = "{LOC}-n";
            this.layoutManagerformBOLOVANJEFOND.Controls.Add(this.textKOLONA, 1, 2);
            this.layoutManagerformBOLOVANJEFOND.SetColumnSpan(this.textKOLONA, 1);
            this.layoutManagerformBOLOVANJEFOND.SetRowSpan(this.textKOLONA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textKOLONA.Margin = padding;
            size = new System.Drawing.Size(0x18, 0x16);
            this.textKOLONA.MinimumSize = size;
            size = new System.Drawing.Size(0x18, 0x16);
            this.textKOLONA.Size = size;
            this.Controls.Add(this.layoutManagerformBOLOVANJEFOND);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceBOLOVANJEFOND;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "BOLOVANJEFONDFormUserControl";
            this.Text = "BOLOVANJEFOND";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.BOLOVANJEFONDFormUserControl_Load);
            this.layoutManagerformBOLOVANJEFOND.ResumeLayout(false);
            this.layoutManagerformBOLOVANJEFOND.PerformLayout();
            ((ISupportInitialize) this.bindingSourceBOLOVANJEFOND).EndInit();
            ((ISupportInitialize) this.textKOLONA).EndInit();
            this.dsBOLOVANJEFONDDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.BOLOVANJEFONDController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceBOLOVANJEFOND, this.BOLOVANJEFONDController.WorkItem, this))
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
            this.label1ELEMENTBOLOVANJEIDELEMENT.Text = StringResources.BOLOVANJEFONDELEMENTBOLOVANJEIDELEMENTDescription;
            this.label1ELEMENTBOLOVANJENAZIVELEMENT.Text = StringResources.BOLOVANJEFONDELEMENTBOLOVANJENAZIVELEMENTDescription;
            this.label1KOLONA.Text = StringResources.BOLOVANJEFONDKOLONADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedELEMENTBOLOVANJEIDELEMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ELEMENT", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.BOLOVANJEFONDController.WorkItem.Items.Contains("BOLOVANJEFOND|BOLOVANJEFOND"))
            {
                this.BOLOVANJEFONDController.WorkItem.Items.Add(this.bindingSourceBOLOVANJEFOND, "BOLOVANJEFOND|BOLOVANJEFOND");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsBOLOVANJEFONDDataSet1.BOLOVANJEFOND.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.BOLOVANJEFONDController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.BOLOVANJEFONDController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.BOLOVANJEFONDController.Update(this))
            {
                this.BOLOVANJEFONDController.DataSet = new BOLOVANJEFONDDataSet();
                DataSetUtil.AddEmptyRow(this.BOLOVANJEFONDController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.BOLOVANJEFONDController.DataSet.BOLOVANJEFOND[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedELEMENTBOLOVANJEIDELEMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboELEMENTBOLOVANJEIDELEMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboELEMENTBOLOVANJEIDELEMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceBOLOVANJEFOND.Current).Row["ELEMENTBOLOVANJEIDELEMENT"] = RuntimeHelpers.GetObjectValue(row["IDELEMENT"]);
                    ((DataRowView) this.bindingSourceBOLOVANJEFOND.Current).Row["ELEMENTBOLOVANJENAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(row["NAZIVELEMENT"]);
                    this.bindingSourceBOLOVANJEFOND.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboELEMENTBOLOVANJEIDELEMENT.Focus();
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.BOLOVANJEFONDController BOLOVANJEFONDController { get; set; }

        protected virtual ELEMENTComboBox comboELEMENTBOLOVANJEIDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboELEMENTBOLOVANJEIDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboELEMENTBOLOVANJEIDELEMENT = value;
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

        protected virtual UltraLabel label1ELEMENTBOLOVANJEIDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ELEMENTBOLOVANJEIDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ELEMENTBOLOVANJEIDELEMENT = value;
            }
        }

        protected virtual UltraLabel label1ELEMENTBOLOVANJENAZIVELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ELEMENTBOLOVANJENAZIVELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ELEMENTBOLOVANJENAZIVELEMENT = value;
            }
        }

        protected virtual UltraLabel label1KOLONA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KOLONA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KOLONA = value;
            }
        }

        protected virtual UltraLabel labelELEMENTBOLOVANJENAZIVELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelELEMENTBOLOVANJENAZIVELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelELEMENTBOLOVANJENAZIVELEMENT = value;
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

        protected virtual UltraNumericEditor textKOLONA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textKOLONA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textKOLONA = value;
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

