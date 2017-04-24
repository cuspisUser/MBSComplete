namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
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
    public class ZATVARANJAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1GK1IDGKSTAVKA")]
        private UltraLabel _label1GK1IDGKSTAVKA;
        [AccessedThroughProperty("label1GK2IDGKSTAVKA")]
        private UltraLabel _label1GK2IDGKSTAVKA;
        [AccessedThroughProperty("label1ZATVARANJAIZNOS")]
        private UltraLabel _label1ZATVARANJAIZNOS;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textGK1IDGKSTAVKA")]
        private UltraNumericEditor _textGK1IDGKSTAVKA;
        [AccessedThroughProperty("textGK2IDGKSTAVKA")]
        private UltraNumericEditor _textGK2IDGKSTAVKA;
        [AccessedThroughProperty("textZATVARANJAIZNOS")]
        private UltraNumericEditor _textZATVARANJAIZNOS;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceZATVARANJA;
        private IContainer components = null;
        private ZATVARANJADataSet dsZATVARANJADataSet1;
        protected TableLayoutPanel layoutManagerformZATVARANJA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private ZATVARANJADataSet.ZATVARANJARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "ZATVARANJA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.ZATVARANJADescription;
        private DeklaritMode m_Mode;

        public ZATVARANJAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptGKSTAVKAGK1IDGKSTAVKA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.ZATVARANJAController.SelectGKSTAVKAGK1IDGKSTAVKA(fillMethod, fillByRow);
            this.UpdateValuesGKSTAVKAGK1IDGKSTAVKA(result);
        }

        private void CallPromptGKSTAVKAGK2IDGKSTAVKA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.ZATVARANJAController.SelectGKSTAVKAGK2IDGKSTAVKA(fillMethod, fillByRow);
            this.UpdateValuesGKSTAVKAGK2IDGKSTAVKA(result);
        }

        private void CallViewGKSTAVKAGK1IDGKSTAVKA(object sender, EventArgs e)
        {
            DataRow result = this.ZATVARANJAController.ShowGKSTAVKAGK1IDGKSTAVKA(this.m_CurrentRow);
            this.UpdateValuesGKSTAVKAGK1IDGKSTAVKA(result);
        }

        private void CallViewGKSTAVKAGK2IDGKSTAVKA(object sender, EventArgs e)
        {
            DataRow result = this.ZATVARANJAController.ShowGKSTAVKAGK2IDGKSTAVKA(this.m_CurrentRow);
            this.UpdateValuesGKSTAVKAGK2IDGKSTAVKA(result);
        }

        public void ChangeBinding()
        {
            this.bindingSourceZATVARANJA.DataSource = this.ZATVARANJAController.DataSet;
            this.dsZATVARANJADataSet1 = this.ZATVARANJAController.DataSet;
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
                    enumerator = this.dsZATVARANJADataSet1.ZATVARANJA.Rows.GetEnumerator();
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
                if (this.ZATVARANJAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "ZATVARANJA", this.m_Mode, this.dsZATVARANJADataSet1, this.dsZATVARANJADataSet1.ZATVARANJA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsZATVARANJADataSet1.ZATVARANJA[0];
                this.textGK1IDGKSTAVKA.ButtonsRight[0].Visible = false;
                this.textGK2IDGKSTAVKA.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textGK1IDGKSTAVKA.ButtonsRight[0].Visible = true;
                this.textGK2IDGKSTAVKA.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (ZATVARANJADataSet.ZATVARANJARow) ((DataRowView) this.bindingSourceZATVARANJA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(ZATVARANJAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceZATVARANJA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceZATVARANJA).BeginInit();
            this.layoutManagerformZATVARANJA = new TableLayoutPanel();
            this.layoutManagerformZATVARANJA.SuspendLayout();
            this.layoutManagerformZATVARANJA.AutoSize = true;
            this.layoutManagerformZATVARANJA.Dock = DockStyle.Fill;
            this.layoutManagerformZATVARANJA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformZATVARANJA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformZATVARANJA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformZATVARANJA.Size = size;
            this.layoutManagerformZATVARANJA.ColumnCount = 2;
            this.layoutManagerformZATVARANJA.RowCount = 4;
            this.layoutManagerformZATVARANJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformZATVARANJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformZATVARANJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformZATVARANJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformZATVARANJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformZATVARANJA.RowStyles.Add(new RowStyle());
            this.label1GK1IDGKSTAVKA = new UltraLabel();
            this.textGK1IDGKSTAVKA = new UltraNumericEditor();
            this.label1GK2IDGKSTAVKA = new UltraLabel();
            this.textGK2IDGKSTAVKA = new UltraNumericEditor();
            this.label1ZATVARANJAIZNOS = new UltraLabel();
            this.textZATVARANJAIZNOS = new UltraNumericEditor();
            ((ISupportInitialize) this.textGK1IDGKSTAVKA).BeginInit();
            ((ISupportInitialize) this.textGK2IDGKSTAVKA).BeginInit();
            ((ISupportInitialize) this.textZATVARANJAIZNOS).BeginInit();
            this.dsZATVARANJADataSet1 = new ZATVARANJADataSet();
            this.dsZATVARANJADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsZATVARANJADataSet1.DataSetName = "dsZATVARANJA";
            this.dsZATVARANJADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceZATVARANJA.DataSource = this.dsZATVARANJADataSet1;
            this.bindingSourceZATVARANJA.DataMember = "ZATVARANJA";
            ((ISupportInitialize) this.bindingSourceZATVARANJA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1GK1IDGKSTAVKA.Location = point;
            this.label1GK1IDGKSTAVKA.Name = "label1GK1IDGKSTAVKA";
            this.label1GK1IDGKSTAVKA.TabIndex = 1;
            this.label1GK1IDGKSTAVKA.Tag = "labelGK1IDGKSTAVKA";
            this.label1GK1IDGKSTAVKA.Text = "IDGKSTAVKA:";
            this.label1GK1IDGKSTAVKA.StyleSetName = "FieldUltraLabel";
            this.label1GK1IDGKSTAVKA.AutoSize = true;
            this.label1GK1IDGKSTAVKA.Anchor = AnchorStyles.Left;
            this.label1GK1IDGKSTAVKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1GK1IDGKSTAVKA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1GK1IDGKSTAVKA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1GK1IDGKSTAVKA.ImageSize = size;
            this.label1GK1IDGKSTAVKA.Appearance.ForeColor = Color.Black;
            this.label1GK1IDGKSTAVKA.BackColor = Color.Transparent;
            this.layoutManagerformZATVARANJA.Controls.Add(this.label1GK1IDGKSTAVKA, 0, 0);
            this.layoutManagerformZATVARANJA.SetColumnSpan(this.label1GK1IDGKSTAVKA, 1);
            this.layoutManagerformZATVARANJA.SetRowSpan(this.label1GK1IDGKSTAVKA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1GK1IDGKSTAVKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GK1IDGKSTAVKA.MinimumSize = size;
            size = new System.Drawing.Size(0x62, 0x17);
            this.label1GK1IDGKSTAVKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textGK1IDGKSTAVKA.Location = point;
            this.textGK1IDGKSTAVKA.Name = "textGK1IDGKSTAVKA";
            this.textGK1IDGKSTAVKA.Tag = "GK1IDGKSTAVKA";
            this.textGK1IDGKSTAVKA.TabIndex = 0;
            this.textGK1IDGKSTAVKA.Anchor = AnchorStyles.Left;
            this.textGK1IDGKSTAVKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textGK1IDGKSTAVKA.ReadOnly = false;
            this.textGK1IDGKSTAVKA.PromptChar = ' ';
            this.textGK1IDGKSTAVKA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textGK1IDGKSTAVKA.DataBindings.Add(new Binding("Value", this.bindingSourceZATVARANJA, "GK1IDGKSTAVKA"));
            this.textGK1IDGKSTAVKA.NumericType = NumericType.Integer;
            this.textGK1IDGKSTAVKA.MaskInput = "{LOC}-nnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonGKSTAVKAGK1IDGKSTAVKA",
                Tag = "editorButtonGKSTAVKAGK1IDGKSTAVKA",
                Text = "..."
            };
            this.textGK1IDGKSTAVKA.ButtonsRight.Add(button);
            this.textGK1IDGKSTAVKA.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptGKSTAVKAGK1IDGKSTAVKA);
            this.layoutManagerformZATVARANJA.Controls.Add(this.textGK1IDGKSTAVKA, 1, 0);
            this.layoutManagerformZATVARANJA.SetColumnSpan(this.textGK1IDGKSTAVKA, 1);
            this.layoutManagerformZATVARANJA.SetRowSpan(this.textGK1IDGKSTAVKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textGK1IDGKSTAVKA.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textGK1IDGKSTAVKA.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textGK1IDGKSTAVKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1GK2IDGKSTAVKA.Location = point;
            this.label1GK2IDGKSTAVKA.Name = "label1GK2IDGKSTAVKA";
            this.label1GK2IDGKSTAVKA.TabIndex = 1;
            this.label1GK2IDGKSTAVKA.Tag = "labelGK2IDGKSTAVKA";
            this.label1GK2IDGKSTAVKA.Text = "IDGKSTAVKA:";
            this.label1GK2IDGKSTAVKA.StyleSetName = "FieldUltraLabel";
            this.label1GK2IDGKSTAVKA.AutoSize = true;
            this.label1GK2IDGKSTAVKA.Anchor = AnchorStyles.Left;
            this.label1GK2IDGKSTAVKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1GK2IDGKSTAVKA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1GK2IDGKSTAVKA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1GK2IDGKSTAVKA.ImageSize = size;
            this.label1GK2IDGKSTAVKA.Appearance.ForeColor = Color.Black;
            this.label1GK2IDGKSTAVKA.BackColor = Color.Transparent;
            this.layoutManagerformZATVARANJA.Controls.Add(this.label1GK2IDGKSTAVKA, 0, 1);
            this.layoutManagerformZATVARANJA.SetColumnSpan(this.label1GK2IDGKSTAVKA, 1);
            this.layoutManagerformZATVARANJA.SetRowSpan(this.label1GK2IDGKSTAVKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1GK2IDGKSTAVKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GK2IDGKSTAVKA.MinimumSize = size;
            size = new System.Drawing.Size(0x62, 0x17);
            this.label1GK2IDGKSTAVKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textGK2IDGKSTAVKA.Location = point;
            this.textGK2IDGKSTAVKA.Name = "textGK2IDGKSTAVKA";
            this.textGK2IDGKSTAVKA.Tag = "GK2IDGKSTAVKA";
            this.textGK2IDGKSTAVKA.TabIndex = 0;
            this.textGK2IDGKSTAVKA.Anchor = AnchorStyles.Left;
            this.textGK2IDGKSTAVKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textGK2IDGKSTAVKA.ReadOnly = false;
            this.textGK2IDGKSTAVKA.PromptChar = ' ';
            this.textGK2IDGKSTAVKA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textGK2IDGKSTAVKA.DataBindings.Add(new Binding("Value", this.bindingSourceZATVARANJA, "GK2IDGKSTAVKA"));
            this.textGK2IDGKSTAVKA.NumericType = NumericType.Integer;
            this.textGK2IDGKSTAVKA.MaskInput = "{LOC}-nnnnn";
            EditorButton button2 = new EditorButton {
                Key = "editorButtonGKSTAVKAGK2IDGKSTAVKA",
                Tag = "editorButtonGKSTAVKAGK2IDGKSTAVKA",
                Text = "..."
            };
            this.textGK2IDGKSTAVKA.ButtonsRight.Add(button2);
            this.textGK2IDGKSTAVKA.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptGKSTAVKAGK2IDGKSTAVKA);
            this.layoutManagerformZATVARANJA.Controls.Add(this.textGK2IDGKSTAVKA, 1, 1);
            this.layoutManagerformZATVARANJA.SetColumnSpan(this.textGK2IDGKSTAVKA, 1);
            this.layoutManagerformZATVARANJA.SetRowSpan(this.textGK2IDGKSTAVKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textGK2IDGKSTAVKA.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textGK2IDGKSTAVKA.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textGK2IDGKSTAVKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZATVARANJAIZNOS.Location = point;
            this.label1ZATVARANJAIZNOS.Name = "label1ZATVARANJAIZNOS";
            this.label1ZATVARANJAIZNOS.TabIndex = 1;
            this.label1ZATVARANJAIZNOS.Tag = "labelZATVARANJAIZNOS";
            this.label1ZATVARANJAIZNOS.Text = "ZATVARANJAIZNOS:";
            this.label1ZATVARANJAIZNOS.StyleSetName = "FieldUltraLabel";
            this.label1ZATVARANJAIZNOS.AutoSize = true;
            this.label1ZATVARANJAIZNOS.Anchor = AnchorStyles.Left;
            this.label1ZATVARANJAIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZATVARANJAIZNOS.Appearance.ForeColor = Color.Black;
            this.label1ZATVARANJAIZNOS.BackColor = Color.Transparent;
            this.layoutManagerformZATVARANJA.Controls.Add(this.label1ZATVARANJAIZNOS, 0, 2);
            this.layoutManagerformZATVARANJA.SetColumnSpan(this.label1ZATVARANJAIZNOS, 1);
            this.layoutManagerformZATVARANJA.SetRowSpan(this.label1ZATVARANJAIZNOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZATVARANJAIZNOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZATVARANJAIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x8e, 0x17);
            this.label1ZATVARANJAIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZATVARANJAIZNOS.Location = point;
            this.textZATVARANJAIZNOS.Name = "textZATVARANJAIZNOS";
            this.textZATVARANJAIZNOS.Tag = "ZATVARANJAIZNOS";
            this.textZATVARANJAIZNOS.TabIndex = 0;
            this.textZATVARANJAIZNOS.Anchor = AnchorStyles.Left;
            this.textZATVARANJAIZNOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZATVARANJAIZNOS.ReadOnly = false;
            this.textZATVARANJAIZNOS.PromptChar = ' ';
            this.textZATVARANJAIZNOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZATVARANJAIZNOS.DataBindings.Add(new Binding("Value", this.bindingSourceZATVARANJA, "ZATVARANJAIZNOS"));
            this.textZATVARANJAIZNOS.NumericType = NumericType.Double;
            this.textZATVARANJAIZNOS.MaxValue = 79228162514264337593543950335M;
            this.textZATVARANJAIZNOS.MinValue = -79228162514264337593543950335M;
            this.textZATVARANJAIZNOS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformZATVARANJA.Controls.Add(this.textZATVARANJAIZNOS, 1, 2);
            this.layoutManagerformZATVARANJA.SetColumnSpan(this.textZATVARANJAIZNOS, 1);
            this.layoutManagerformZATVARANJA.SetRowSpan(this.textZATVARANJAIZNOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZATVARANJAIZNOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZATVARANJAIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZATVARANJAIZNOS.Size = size;
            this.Controls.Add(this.layoutManagerformZATVARANJA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceZATVARANJA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "ZATVARANJAFormUserControl";
            this.Text = "ZATVARANJA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.ZATVARANJAFormUserControl_Load);
            this.layoutManagerformZATVARANJA.ResumeLayout(false);
            this.layoutManagerformZATVARANJA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceZATVARANJA).EndInit();
            ((ISupportInitialize) this.textGK1IDGKSTAVKA).EndInit();
            ((ISupportInitialize) this.textGK2IDGKSTAVKA).EndInit();
            ((ISupportInitialize) this.textZATVARANJAIZNOS).EndInit();
            this.dsZATVARANJADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.ZATVARANJAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceZATVARANJA, this.ZATVARANJAController.WorkItem, this))
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
            this.label1GK1IDGKSTAVKA.Text = StringResources.ZATVARANJAGK1IDGKSTAVKADescription;
            this.label1GK2IDGKSTAVKA.Text = StringResources.ZATVARANJAGK2IDGKSTAVKADescription;
            this.label1ZATVARANJAIZNOS.Text = StringResources.ZATVARANJAZATVARANJAIZNOSDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.ZATVARANJAController.WorkItem.Items.Contains("ZATVARANJA|ZATVARANJA"))
            {
                this.ZATVARANJAController.WorkItem.Items.Add(this.bindingSourceZATVARANJA, "ZATVARANJA|ZATVARANJA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsZATVARANJADataSet1.ZATVARANJA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
                this.textGK1IDGKSTAVKA.ButtonsRight[0].Visible = false;
                this.textGK2IDGKSTAVKA.ButtonsRight[0].Visible = false;
            }
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ZATVARANJAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.ZATVARANJAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.ZATVARANJAController.Update(this))
            {
                this.ZATVARANJAController.DataSet = new ZATVARANJADataSet();
                DataSetUtil.AddEmptyRow(this.ZATVARANJAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.ZATVARANJAController.DataSet.ZATVARANJA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textGK1IDGKSTAVKA.Focus();
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

        private void UpdateValuesGKSTAVKAGK1IDGKSTAVKA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceZATVARANJA.Current).Row["GK1IDGKSTAVKA"] = RuntimeHelpers.GetObjectValue(result["IDGKSTAVKA"]);
                this.bindingSourceZATVARANJA.ResetCurrentItem();
            }
        }

        private void UpdateValuesGKSTAVKAGK2IDGKSTAVKA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceZATVARANJA.Current).Row["GK2IDGKSTAVKA"] = RuntimeHelpers.GetObjectValue(result["IDGKSTAVKA"]);
                this.bindingSourceZATVARANJA.ResetCurrentItem();
            }
        }

        private void ZATVARANJAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.ZATVARANJADescription;
            this.errorProvider1.ContainerControl = this;
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

        protected virtual UltraLabel label1GK1IDGKSTAVKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1GK1IDGKSTAVKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1GK1IDGKSTAVKA = value;
            }
        }

        protected virtual UltraLabel label1GK2IDGKSTAVKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1GK2IDGKSTAVKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1GK2IDGKSTAVKA = value;
            }
        }

        protected virtual UltraLabel label1ZATVARANJAIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZATVARANJAIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZATVARANJAIZNOS = value;
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

        protected virtual UltraNumericEditor textGK1IDGKSTAVKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textGK1IDGKSTAVKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textGK1IDGKSTAVKA = value;
            }
        }

        protected virtual UltraNumericEditor textGK2IDGKSTAVKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textGK2IDGKSTAVKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textGK2IDGKSTAVKA = value;
            }
        }

        protected virtual UltraNumericEditor textZATVARANJAIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZATVARANJAIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZATVARANJAIZNOS = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.ZATVARANJAController ZATVARANJAController { get; set; }
    }
}

