namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Resources;
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
    public class OSOBNIODBITAKFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1FAKTOROSOBNOGODBITKA")]
        private UltraLabel _label1FAKTOROSOBNOGODBITKA;
        [AccessedThroughProperty("label1IDOSOBNIODBITAK")]
        private UltraLabel _label1IDOSOBNIODBITAK;
        [AccessedThroughProperty("label1NAZIVOSOBNIODBITAK")]
        private UltraLabel _label1NAZIVOSOBNIODBITAK;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textFAKTOROSOBNOGODBITKA")]
        private UltraNumericEditor _textFAKTOROSOBNOGODBITKA;
        [AccessedThroughProperty("textIDOSOBNIODBITAK")]
        private UltraNumericEditor _textIDOSOBNIODBITAK;
        [AccessedThroughProperty("textNAZIVOSOBNIODBITAK")]
        private UltraTextEditor _textNAZIVOSOBNIODBITAK;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceOSOBNIODBITAK;
        private IContainer components = null;
        private OSOBNIODBITAKDataSet dsOSOBNIODBITAKDataSet1;
        protected TableLayoutPanel layoutManagerformOSOBNIODBITAK;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OSOBNIODBITAKDataSet.OSOBNIODBITAKRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OSOBNIODBITAK";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.OSOBNIODBITAKDescription;
        private DeklaritMode m_Mode;

        public OSOBNIODBITAKFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceOSOBNIODBITAK.DataSource = this.OSOBNIODBITAKController.DataSet;
            this.dsOSOBNIODBITAKDataSet1 = this.OSOBNIODBITAKController.DataSet;
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
                    enumerator = this.dsOSOBNIODBITAKDataSet1.OSOBNIODBITAK.Rows.GetEnumerator();
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
                if (this.OSOBNIODBITAKController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OSOBNIODBITAK", this.m_Mode, this.dsOSOBNIODBITAKDataSet1, this.dsOSOBNIODBITAKDataSet1.OSOBNIODBITAK.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsOSOBNIODBITAKDataSet1.OSOBNIODBITAK[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OSOBNIODBITAKDataSet.OSOBNIODBITAKRow) ((DataRowView) this.bindingSourceOSOBNIODBITAK.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(OSOBNIODBITAKFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOSOBNIODBITAK = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOSOBNIODBITAK).BeginInit();
            this.layoutManagerformOSOBNIODBITAK = new TableLayoutPanel();
            this.layoutManagerformOSOBNIODBITAK.SuspendLayout();
            this.layoutManagerformOSOBNIODBITAK.AutoSize = true;
            this.layoutManagerformOSOBNIODBITAK.Dock = DockStyle.Fill;
            this.layoutManagerformOSOBNIODBITAK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOSOBNIODBITAK.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOSOBNIODBITAK.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOSOBNIODBITAK.Size = size;
            this.layoutManagerformOSOBNIODBITAK.ColumnCount = 2;
            this.layoutManagerformOSOBNIODBITAK.RowCount = 4;
            this.layoutManagerformOSOBNIODBITAK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOSOBNIODBITAK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOSOBNIODBITAK.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSOBNIODBITAK.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSOBNIODBITAK.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSOBNIODBITAK.RowStyles.Add(new RowStyle());
            this.label1IDOSOBNIODBITAK = new UltraLabel();
            this.textIDOSOBNIODBITAK = new UltraNumericEditor();
            this.label1NAZIVOSOBNIODBITAK = new UltraLabel();
            this.textNAZIVOSOBNIODBITAK = new UltraTextEditor();
            this.label1FAKTOROSOBNOGODBITKA = new UltraLabel();
            this.textFAKTOROSOBNOGODBITKA = new UltraNumericEditor();
            ((ISupportInitialize) this.textIDOSOBNIODBITAK).BeginInit();
            ((ISupportInitialize) this.textNAZIVOSOBNIODBITAK).BeginInit();
            ((ISupportInitialize) this.textFAKTOROSOBNOGODBITKA).BeginInit();
            this.dsOSOBNIODBITAKDataSet1 = new OSOBNIODBITAKDataSet();
            this.dsOSOBNIODBITAKDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOSOBNIODBITAKDataSet1.DataSetName = "dsOSOBNIODBITAK";
            this.dsOSOBNIODBITAKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOSOBNIODBITAK.DataSource = this.dsOSOBNIODBITAKDataSet1;
            this.bindingSourceOSOBNIODBITAK.DataMember = "OSOBNIODBITAK";
            ((ISupportInitialize) this.bindingSourceOSOBNIODBITAK).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDOSOBNIODBITAK.Location = point;
            this.label1IDOSOBNIODBITAK.Name = "label1IDOSOBNIODBITAK";
            this.label1IDOSOBNIODBITAK.TabIndex = 1;
            this.label1IDOSOBNIODBITAK.Tag = "labelIDOSOBNIODBITAK";
            this.label1IDOSOBNIODBITAK.Text = "Šifra osobnog odbitka:";
            this.label1IDOSOBNIODBITAK.StyleSetName = "FieldUltraLabel";
            this.label1IDOSOBNIODBITAK.AutoSize = true;
            this.label1IDOSOBNIODBITAK.Anchor = AnchorStyles.Left;
            this.label1IDOSOBNIODBITAK.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOSOBNIODBITAK.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDOSOBNIODBITAK.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDOSOBNIODBITAK.ImageSize = size;
            this.label1IDOSOBNIODBITAK.Appearance.ForeColor = Color.Black;
            this.label1IDOSOBNIODBITAK.BackColor = Color.Transparent;
            this.layoutManagerformOSOBNIODBITAK.Controls.Add(this.label1IDOSOBNIODBITAK, 0, 0);
            this.layoutManagerformOSOBNIODBITAK.SetColumnSpan(this.label1IDOSOBNIODBITAK, 1);
            this.layoutManagerformOSOBNIODBITAK.SetRowSpan(this.label1IDOSOBNIODBITAK, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDOSOBNIODBITAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOSOBNIODBITAK.MinimumSize = size;
            size = new System.Drawing.Size(0x98, 0x17);
            this.label1IDOSOBNIODBITAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOSOBNIODBITAK.Location = point;
            this.textIDOSOBNIODBITAK.Name = "textIDOSOBNIODBITAK";
            this.textIDOSOBNIODBITAK.Tag = "IDOSOBNIODBITAK";
            this.textIDOSOBNIODBITAK.TabIndex = 0;
            this.textIDOSOBNIODBITAK.Anchor = AnchorStyles.Left;
            this.textIDOSOBNIODBITAK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDOSOBNIODBITAK.ReadOnly = false;
            this.textIDOSOBNIODBITAK.PromptChar = ' ';
            this.textIDOSOBNIODBITAK.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDOSOBNIODBITAK.DataBindings.Add(new Binding("Value", this.bindingSourceOSOBNIODBITAK, "IDOSOBNIODBITAK"));
            this.textIDOSOBNIODBITAK.NumericType = NumericType.Integer;
            this.textIDOSOBNIODBITAK.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformOSOBNIODBITAK.Controls.Add(this.textIDOSOBNIODBITAK, 1, 0);
            this.layoutManagerformOSOBNIODBITAK.SetColumnSpan(this.textIDOSOBNIODBITAK, 1);
            this.layoutManagerformOSOBNIODBITAK.SetRowSpan(this.textIDOSOBNIODBITAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOSOBNIODBITAK.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDOSOBNIODBITAK.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDOSOBNIODBITAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVOSOBNIODBITAK.Location = point;
            this.label1NAZIVOSOBNIODBITAK.Name = "label1NAZIVOSOBNIODBITAK";
            this.label1NAZIVOSOBNIODBITAK.TabIndex = 1;
            this.label1NAZIVOSOBNIODBITAK.Tag = "labelNAZIVOSOBNIODBITAK";
            this.label1NAZIVOSOBNIODBITAK.Text = "Naziv osobnog odbitka:";
            this.label1NAZIVOSOBNIODBITAK.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVOSOBNIODBITAK.AutoSize = true;
            this.label1NAZIVOSOBNIODBITAK.Anchor = AnchorStyles.Left;
            this.label1NAZIVOSOBNIODBITAK.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVOSOBNIODBITAK.Appearance.ForeColor = Color.Maroon;
            this.label1NAZIVOSOBNIODBITAK.BackColor = Color.Transparent;
            this.layoutManagerformOSOBNIODBITAK.Controls.Add(this.label1NAZIVOSOBNIODBITAK, 0, 1);
            this.layoutManagerformOSOBNIODBITAK.SetColumnSpan(this.label1NAZIVOSOBNIODBITAK, 1);
            this.layoutManagerformOSOBNIODBITAK.SetRowSpan(this.label1NAZIVOSOBNIODBITAK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVOSOBNIODBITAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVOSOBNIODBITAK.MinimumSize = size;
            size = new System.Drawing.Size(160, 0x17);
            this.label1NAZIVOSOBNIODBITAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVOSOBNIODBITAK.Location = point;
            this.textNAZIVOSOBNIODBITAK.Name = "textNAZIVOSOBNIODBITAK";
            this.textNAZIVOSOBNIODBITAK.Tag = "NAZIVOSOBNIODBITAK";
            this.textNAZIVOSOBNIODBITAK.TabIndex = 0;
            this.textNAZIVOSOBNIODBITAK.Anchor = AnchorStyles.Left;
            this.textNAZIVOSOBNIODBITAK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.errorProviderValidator1.SetRequired(this.textNAZIVOSOBNIODBITAK, true);
            this.errorProviderValidator1.SetRequiredMessage(this.textNAZIVOSOBNIODBITAK, "Field Required ");
            this.textNAZIVOSOBNIODBITAK.ReadOnly = false;
            this.textNAZIVOSOBNIODBITAK.DataBindings.Add(new Binding("Text", this.bindingSourceOSOBNIODBITAK, "NAZIVOSOBNIODBITAK"));
            this.textNAZIVOSOBNIODBITAK.MaxLength = 100;
            this.layoutManagerformOSOBNIODBITAK.Controls.Add(this.textNAZIVOSOBNIODBITAK, 1, 1);
            this.layoutManagerformOSOBNIODBITAK.SetColumnSpan(this.textNAZIVOSOBNIODBITAK, 1);
            this.layoutManagerformOSOBNIODBITAK.SetRowSpan(this.textNAZIVOSOBNIODBITAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVOSOBNIODBITAK.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVOSOBNIODBITAK.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVOSOBNIODBITAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1FAKTOROSOBNOGODBITKA.Location = point;
            this.label1FAKTOROSOBNOGODBITKA.Name = "label1FAKTOROSOBNOGODBITKA";
            this.label1FAKTOROSOBNOGODBITKA.TabIndex = 1;
            this.label1FAKTOROSOBNOGODBITKA.Tag = "labelFAKTOROSOBNOGODBITKA";
            this.label1FAKTOROSOBNOGODBITKA.Text = "Faktor osobnog odbitka:";
            this.label1FAKTOROSOBNOGODBITKA.StyleSetName = "FieldUltraLabel";
            this.label1FAKTOROSOBNOGODBITKA.AutoSize = true;
            this.label1FAKTOROSOBNOGODBITKA.Anchor = AnchorStyles.Left;
            this.label1FAKTOROSOBNOGODBITKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1FAKTOROSOBNOGODBITKA.Appearance.ForeColor = Color.Black;
            this.label1FAKTOROSOBNOGODBITKA.BackColor = Color.Transparent;
            this.layoutManagerformOSOBNIODBITAK.Controls.Add(this.label1FAKTOROSOBNOGODBITKA, 0, 2);
            this.layoutManagerformOSOBNIODBITAK.SetColumnSpan(this.label1FAKTOROSOBNOGODBITKA, 1);
            this.layoutManagerformOSOBNIODBITAK.SetRowSpan(this.label1FAKTOROSOBNOGODBITKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1FAKTOROSOBNOGODBITKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1FAKTOROSOBNOGODBITKA.MinimumSize = size;
            size = new System.Drawing.Size(0xa6, 0x17);
            this.label1FAKTOROSOBNOGODBITKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textFAKTOROSOBNOGODBITKA.Location = point;
            this.textFAKTOROSOBNOGODBITKA.Name = "textFAKTOROSOBNOGODBITKA";
            this.textFAKTOROSOBNOGODBITKA.Tag = "FAKTOROSOBNOGODBITKA";
            this.textFAKTOROSOBNOGODBITKA.TabIndex = 0;
            this.textFAKTOROSOBNOGODBITKA.Anchor = AnchorStyles.Left;
            this.textFAKTOROSOBNOGODBITKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textFAKTOROSOBNOGODBITKA.ReadOnly = false;
            this.textFAKTOROSOBNOGODBITKA.PromptChar = ' ';
            this.textFAKTOROSOBNOGODBITKA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textFAKTOROSOBNOGODBITKA.DataBindings.Add(new Binding("Value", this.bindingSourceOSOBNIODBITAK, "FAKTOROSOBNOGODBITKA"));
            this.textFAKTOROSOBNOGODBITKA.NumericType = NumericType.Double;
            this.textFAKTOROSOBNOGODBITKA.MaxValue = 79228162514264337593543950335M;
            this.textFAKTOROSOBNOGODBITKA.MinValue = -79228162514264337593543950335M;
            this.textFAKTOROSOBNOGODBITKA.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformOSOBNIODBITAK.Controls.Add(this.textFAKTOROSOBNOGODBITKA, 1, 2);
            this.layoutManagerformOSOBNIODBITAK.SetColumnSpan(this.textFAKTOROSOBNOGODBITKA, 1);
            this.layoutManagerformOSOBNIODBITAK.SetRowSpan(this.textFAKTOROSOBNOGODBITKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textFAKTOROSOBNOGODBITKA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textFAKTOROSOBNOGODBITKA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textFAKTOROSOBNOGODBITKA.Size = size;
            this.Controls.Add(this.layoutManagerformOSOBNIODBITAK);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOSOBNIODBITAK;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OSOBNIODBITAKFormUserControl";
            this.Text = "Faktori osobnog odbitka";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OSOBNIODBITAKFormUserControl_Load);
            this.layoutManagerformOSOBNIODBITAK.ResumeLayout(false);
            this.layoutManagerformOSOBNIODBITAK.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOSOBNIODBITAK).EndInit();
            ((ISupportInitialize) this.textIDOSOBNIODBITAK).EndInit();
            ((ISupportInitialize) this.textNAZIVOSOBNIODBITAK).EndInit();
            ((ISupportInitialize) this.textFAKTOROSOBNOGODBITKA).EndInit();
            this.dsOSOBNIODBITAKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OSOBNIODBITAKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOSOBNIODBITAK, this.OSOBNIODBITAKController.WorkItem, this))
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
            this.label1IDOSOBNIODBITAK.Text = StringResources.OSOBNIODBITAKIDOSOBNIODBITAKDescription;
            this.label1NAZIVOSOBNIODBITAK.Text = StringResources.OSOBNIODBITAKNAZIVOSOBNIODBITAKDescription;
            this.label1FAKTOROSOBNOGODBITKA.Text = StringResources.OSOBNIODBITAKFAKTOROSOBNOGODBITKADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OSOBNIODBITAKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OSOBNIODBITAKDescription;
            this.errorProvider1.ContainerControl = this;
            this.errorProviderValidator1.SetRequiredMessage(this.textNAZIVOSOBNIODBITAK, Deklarit.Resources.Resources.validateRequired);
        }

        private void RegisterBindingSources()
        {
            if (!this.OSOBNIODBITAKController.WorkItem.Items.Contains("OSOBNIODBITAK|OSOBNIODBITAK"))
            {
                this.OSOBNIODBITAKController.WorkItem.Items.Add(this.bindingSourceOSOBNIODBITAK, "OSOBNIODBITAK|OSOBNIODBITAK");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsOSOBNIODBITAKDataSet1.OSOBNIODBITAK.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.OSOBNIODBITAKController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OSOBNIODBITAKController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OSOBNIODBITAKController.Update(this))
            {
                this.OSOBNIODBITAKController.DataSet = new OSOBNIODBITAKDataSet();
                DataSetUtil.AddEmptyRow(this.OSOBNIODBITAKController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.OSOBNIODBITAKController.DataSet.OSOBNIODBITAK[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDOSOBNIODBITAK.Focus();
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

        protected virtual UltraLabel label1FAKTOROSOBNOGODBITKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1FAKTOROSOBNOGODBITKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1FAKTOROSOBNOGODBITKA = value;
            }
        }

        protected virtual UltraLabel label1IDOSOBNIODBITAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOSOBNIODBITAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOSOBNIODBITAK = value;
            }
        }

        protected virtual UltraLabel label1NAZIVOSOBNIODBITAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVOSOBNIODBITAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVOSOBNIODBITAK = value;
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
        public NetAdvantage.Controllers.OSOBNIODBITAKController OSOBNIODBITAKController { get; set; }

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

        protected virtual UltraNumericEditor textFAKTOROSOBNOGODBITKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textFAKTOROSOBNOGODBITKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textFAKTOROSOBNOGODBITKA = value;
            }
        }

        protected virtual UltraNumericEditor textIDOSOBNIODBITAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOSOBNIODBITAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOSOBNIODBITAK = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVOSOBNIODBITAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVOSOBNIODBITAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVOSOBNIODBITAK = value;
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

