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
    public class GRUPEOLAKSICAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDGRUPEOLAKSICA")]
        private UltraLabel _label1IDGRUPEOLAKSICA;
        [AccessedThroughProperty("label1MAXIMALNIIZNOSGRUPE")]
        private UltraLabel _label1MAXIMALNIIZNOSGRUPE;
        [AccessedThroughProperty("label1NAZIVGRUPEOLAKSICA")]
        private UltraLabel _label1NAZIVGRUPEOLAKSICA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDGRUPEOLAKSICA")]
        private UltraNumericEditor _textIDGRUPEOLAKSICA;
        [AccessedThroughProperty("textMAXIMALNIIZNOSGRUPE")]
        private UltraNumericEditor _textMAXIMALNIIZNOSGRUPE;
        [AccessedThroughProperty("textNAZIVGRUPEOLAKSICA")]
        private UltraTextEditor _textNAZIVGRUPEOLAKSICA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceGRUPEOLAKSICA;
        private IContainer components = null;
        private GRUPEOLAKSICADataSet dsGRUPEOLAKSICADataSet1;
        protected TableLayoutPanel layoutManagerformGRUPEOLAKSICA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private GRUPEOLAKSICADataSet.GRUPEOLAKSICARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "GRUPEOLAKSICA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.GRUPEOLAKSICADescription;
        private DeklaritMode m_Mode;

        public GRUPEOLAKSICAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceGRUPEOLAKSICA.DataSource = this.GRUPEOLAKSICAController.DataSet;
            this.dsGRUPEOLAKSICADataSet1 = this.GRUPEOLAKSICAController.DataSet;
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
                    enumerator = this.dsGRUPEOLAKSICADataSet1.GRUPEOLAKSICA.Rows.GetEnumerator();
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
                if (this.GRUPEOLAKSICAController.Update(this))
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

        private void GRUPEOLAKSICAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.GRUPEOLAKSICADescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "GRUPEOLAKSICA", this.m_Mode, this.dsGRUPEOLAKSICADataSet1, this.dsGRUPEOLAKSICADataSet1.GRUPEOLAKSICA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsGRUPEOLAKSICADataSet1.GRUPEOLAKSICA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (GRUPEOLAKSICADataSet.GRUPEOLAKSICARow) ((DataRowView) this.bindingSourceGRUPEOLAKSICA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(GRUPEOLAKSICAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceGRUPEOLAKSICA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceGRUPEOLAKSICA).BeginInit();
            this.layoutManagerformGRUPEOLAKSICA = new TableLayoutPanel();
            this.layoutManagerformGRUPEOLAKSICA.SuspendLayout();
            this.layoutManagerformGRUPEOLAKSICA.AutoSize = true;
            this.layoutManagerformGRUPEOLAKSICA.Dock = DockStyle.Fill;
            this.layoutManagerformGRUPEOLAKSICA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformGRUPEOLAKSICA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformGRUPEOLAKSICA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformGRUPEOLAKSICA.Size = size;
            this.layoutManagerformGRUPEOLAKSICA.ColumnCount = 2;
            this.layoutManagerformGRUPEOLAKSICA.RowCount = 4;
            this.layoutManagerformGRUPEOLAKSICA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGRUPEOLAKSICA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGRUPEOLAKSICA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGRUPEOLAKSICA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGRUPEOLAKSICA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGRUPEOLAKSICA.RowStyles.Add(new RowStyle());
            this.label1IDGRUPEOLAKSICA = new UltraLabel();
            this.textIDGRUPEOLAKSICA = new UltraNumericEditor();
            this.label1NAZIVGRUPEOLAKSICA = new UltraLabel();
            this.textNAZIVGRUPEOLAKSICA = new UltraTextEditor();
            this.label1MAXIMALNIIZNOSGRUPE = new UltraLabel();
            this.textMAXIMALNIIZNOSGRUPE = new UltraNumericEditor();
            ((ISupportInitialize) this.textIDGRUPEOLAKSICA).BeginInit();
            ((ISupportInitialize) this.textNAZIVGRUPEOLAKSICA).BeginInit();
            ((ISupportInitialize) this.textMAXIMALNIIZNOSGRUPE).BeginInit();
            this.dsGRUPEOLAKSICADataSet1 = new GRUPEOLAKSICADataSet();
            this.dsGRUPEOLAKSICADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsGRUPEOLAKSICADataSet1.DataSetName = "dsGRUPEOLAKSICA";
            this.dsGRUPEOLAKSICADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceGRUPEOLAKSICA.DataSource = this.dsGRUPEOLAKSICADataSet1;
            this.bindingSourceGRUPEOLAKSICA.DataMember = "GRUPEOLAKSICA";
            ((ISupportInitialize) this.bindingSourceGRUPEOLAKSICA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDGRUPEOLAKSICA.Location = point;
            this.label1IDGRUPEOLAKSICA.Name = "label1IDGRUPEOLAKSICA";
            this.label1IDGRUPEOLAKSICA.TabIndex = 1;
            this.label1IDGRUPEOLAKSICA.Tag = "labelIDGRUPEOLAKSICA";
            this.label1IDGRUPEOLAKSICA.Text = "Šifra grupe olakšica:";
            this.label1IDGRUPEOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1IDGRUPEOLAKSICA.AutoSize = true;
            this.label1IDGRUPEOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1IDGRUPEOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDGRUPEOLAKSICA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDGRUPEOLAKSICA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDGRUPEOLAKSICA.ImageSize = size;
            this.label1IDGRUPEOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1IDGRUPEOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformGRUPEOLAKSICA.Controls.Add(this.label1IDGRUPEOLAKSICA, 0, 0);
            this.layoutManagerformGRUPEOLAKSICA.SetColumnSpan(this.label1IDGRUPEOLAKSICA, 1);
            this.layoutManagerformGRUPEOLAKSICA.SetRowSpan(this.label1IDGRUPEOLAKSICA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDGRUPEOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDGRUPEOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x8b, 0x17);
            this.label1IDGRUPEOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDGRUPEOLAKSICA.Location = point;
            this.textIDGRUPEOLAKSICA.Name = "textIDGRUPEOLAKSICA";
            this.textIDGRUPEOLAKSICA.Tag = "IDGRUPEOLAKSICA";
            this.textIDGRUPEOLAKSICA.TabIndex = 0;
            this.textIDGRUPEOLAKSICA.Anchor = AnchorStyles.Left;
            this.textIDGRUPEOLAKSICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDGRUPEOLAKSICA.ReadOnly = false;
            this.textIDGRUPEOLAKSICA.PromptChar = ' ';
            this.textIDGRUPEOLAKSICA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDGRUPEOLAKSICA.DataBindings.Add(new Binding("Value", this.bindingSourceGRUPEOLAKSICA, "IDGRUPEOLAKSICA"));
            this.textIDGRUPEOLAKSICA.NumericType = NumericType.Integer;
            this.textIDGRUPEOLAKSICA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformGRUPEOLAKSICA.Controls.Add(this.textIDGRUPEOLAKSICA, 1, 0);
            this.layoutManagerformGRUPEOLAKSICA.SetColumnSpan(this.textIDGRUPEOLAKSICA, 1);
            this.layoutManagerformGRUPEOLAKSICA.SetRowSpan(this.textIDGRUPEOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDGRUPEOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDGRUPEOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDGRUPEOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVGRUPEOLAKSICA.Location = point;
            this.label1NAZIVGRUPEOLAKSICA.Name = "label1NAZIVGRUPEOLAKSICA";
            this.label1NAZIVGRUPEOLAKSICA.TabIndex = 1;
            this.label1NAZIVGRUPEOLAKSICA.Tag = "labelNAZIVGRUPEOLAKSICA";
            this.label1NAZIVGRUPEOLAKSICA.Text = "Naziv grupe olakšice:";
            this.label1NAZIVGRUPEOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVGRUPEOLAKSICA.AutoSize = true;
            this.label1NAZIVGRUPEOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1NAZIVGRUPEOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVGRUPEOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVGRUPEOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformGRUPEOLAKSICA.Controls.Add(this.label1NAZIVGRUPEOLAKSICA, 0, 1);
            this.layoutManagerformGRUPEOLAKSICA.SetColumnSpan(this.label1NAZIVGRUPEOLAKSICA, 1);
            this.layoutManagerformGRUPEOLAKSICA.SetRowSpan(this.label1NAZIVGRUPEOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVGRUPEOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVGRUPEOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x93, 0x17);
            this.label1NAZIVGRUPEOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVGRUPEOLAKSICA.Location = point;
            this.textNAZIVGRUPEOLAKSICA.Name = "textNAZIVGRUPEOLAKSICA";
            this.textNAZIVGRUPEOLAKSICA.Tag = "NAZIVGRUPEOLAKSICA";
            this.textNAZIVGRUPEOLAKSICA.TabIndex = 0;
            this.textNAZIVGRUPEOLAKSICA.Anchor = AnchorStyles.Left;
            this.textNAZIVGRUPEOLAKSICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVGRUPEOLAKSICA.ReadOnly = false;
            this.textNAZIVGRUPEOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceGRUPEOLAKSICA, "NAZIVGRUPEOLAKSICA"));
            this.textNAZIVGRUPEOLAKSICA.MaxLength = 100;
            this.layoutManagerformGRUPEOLAKSICA.Controls.Add(this.textNAZIVGRUPEOLAKSICA, 1, 1);
            this.layoutManagerformGRUPEOLAKSICA.SetColumnSpan(this.textNAZIVGRUPEOLAKSICA, 1);
            this.layoutManagerformGRUPEOLAKSICA.SetRowSpan(this.textNAZIVGRUPEOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVGRUPEOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVGRUPEOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVGRUPEOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MAXIMALNIIZNOSGRUPE.Location = point;
            this.label1MAXIMALNIIZNOSGRUPE.Name = "label1MAXIMALNIIZNOSGRUPE";
            this.label1MAXIMALNIIZNOSGRUPE.TabIndex = 1;
            this.label1MAXIMALNIIZNOSGRUPE.Tag = "labelMAXIMALNIIZNOSGRUPE";
            this.label1MAXIMALNIIZNOSGRUPE.Text = "Maks. iznos olakšica u grupi:";
            this.label1MAXIMALNIIZNOSGRUPE.StyleSetName = "FieldUltraLabel";
            this.label1MAXIMALNIIZNOSGRUPE.AutoSize = true;
            this.label1MAXIMALNIIZNOSGRUPE.Anchor = AnchorStyles.Left;
            this.label1MAXIMALNIIZNOSGRUPE.Appearance.TextVAlign = VAlign.Middle;
            this.label1MAXIMALNIIZNOSGRUPE.Appearance.ForeColor = Color.Black;
            this.label1MAXIMALNIIZNOSGRUPE.BackColor = Color.Transparent;
            this.layoutManagerformGRUPEOLAKSICA.Controls.Add(this.label1MAXIMALNIIZNOSGRUPE, 0, 2);
            this.layoutManagerformGRUPEOLAKSICA.SetColumnSpan(this.label1MAXIMALNIIZNOSGRUPE, 1);
            this.layoutManagerformGRUPEOLAKSICA.SetRowSpan(this.label1MAXIMALNIIZNOSGRUPE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MAXIMALNIIZNOSGRUPE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MAXIMALNIIZNOSGRUPE.MinimumSize = size;
            size = new System.Drawing.Size(0xc0, 0x17);
            this.label1MAXIMALNIIZNOSGRUPE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMAXIMALNIIZNOSGRUPE.Location = point;
            this.textMAXIMALNIIZNOSGRUPE.Name = "textMAXIMALNIIZNOSGRUPE";
            this.textMAXIMALNIIZNOSGRUPE.Tag = "MAXIMALNIIZNOSGRUPE";
            this.textMAXIMALNIIZNOSGRUPE.TabIndex = 0;
            this.textMAXIMALNIIZNOSGRUPE.Anchor = AnchorStyles.Left;
            this.textMAXIMALNIIZNOSGRUPE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMAXIMALNIIZNOSGRUPE.ReadOnly = false;
            this.textMAXIMALNIIZNOSGRUPE.PromptChar = ' ';
            this.textMAXIMALNIIZNOSGRUPE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textMAXIMALNIIZNOSGRUPE.DataBindings.Add(new Binding("Value", this.bindingSourceGRUPEOLAKSICA, "MAXIMALNIIZNOSGRUPE"));
            this.textMAXIMALNIIZNOSGRUPE.NumericType = NumericType.Double;
            this.textMAXIMALNIIZNOSGRUPE.MaxValue = 79228162514264337593543950335M;
            this.textMAXIMALNIIZNOSGRUPE.MinValue = -79228162514264337593543950335M;
            this.textMAXIMALNIIZNOSGRUPE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformGRUPEOLAKSICA.Controls.Add(this.textMAXIMALNIIZNOSGRUPE, 1, 2);
            this.layoutManagerformGRUPEOLAKSICA.SetColumnSpan(this.textMAXIMALNIIZNOSGRUPE, 1);
            this.layoutManagerformGRUPEOLAKSICA.SetRowSpan(this.textMAXIMALNIIZNOSGRUPE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMAXIMALNIIZNOSGRUPE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textMAXIMALNIIZNOSGRUPE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textMAXIMALNIIZNOSGRUPE.Size = size;
            this.Controls.Add(this.layoutManagerformGRUPEOLAKSICA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceGRUPEOLAKSICA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "GRUPEOLAKSICAFormUserControl";
            this.Text = "Grupe olakšica";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.GRUPEOLAKSICAFormUserControl_Load);
            this.layoutManagerformGRUPEOLAKSICA.ResumeLayout(false);
            this.layoutManagerformGRUPEOLAKSICA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceGRUPEOLAKSICA).EndInit();
            ((ISupportInitialize) this.textIDGRUPEOLAKSICA).EndInit();
            ((ISupportInitialize) this.textNAZIVGRUPEOLAKSICA).EndInit();
            ((ISupportInitialize) this.textMAXIMALNIIZNOSGRUPE).EndInit();
            this.dsGRUPEOLAKSICADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.GRUPEOLAKSICAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceGRUPEOLAKSICA, this.GRUPEOLAKSICAController.WorkItem, this))
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
            this.label1IDGRUPEOLAKSICA.Text = StringResources.GRUPEOLAKSICAIDGRUPEOLAKSICADescription;
            this.label1NAZIVGRUPEOLAKSICA.Text = StringResources.GRUPEOLAKSICANAZIVGRUPEOLAKSICADescription;
            this.label1MAXIMALNIIZNOSGRUPE.Text = StringResources.GRUPEOLAKSICAMAXIMALNIIZNOSGRUPEDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewOLAKSICE")]
        public void NewOLAKSICEHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GRUPEOLAKSICAController.NewOLAKSICE(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.GRUPEOLAKSICAController.WorkItem.Items.Contains("GRUPEOLAKSICA|GRUPEOLAKSICA"))
            {
                this.GRUPEOLAKSICAController.WorkItem.Items.Add(this.bindingSourceGRUPEOLAKSICA, "GRUPEOLAKSICA|GRUPEOLAKSICA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsGRUPEOLAKSICADataSet1.GRUPEOLAKSICA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.GRUPEOLAKSICAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.GRUPEOLAKSICAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.GRUPEOLAKSICAController.Update(this))
            {
                this.GRUPEOLAKSICAController.DataSet = new GRUPEOLAKSICADataSet();
                DataSetUtil.AddEmptyRow(this.GRUPEOLAKSICAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.GRUPEOLAKSICAController.DataSet.GRUPEOLAKSICA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDGRUPEOLAKSICA.Focus();
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

        [LocalCommandHandler("ViewOLAKSICE")]
        public void ViewOLAKSICEHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GRUPEOLAKSICAController.ViewOLAKSICE(this.m_CurrentRow);
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.GRUPEOLAKSICAController GRUPEOLAKSICAController { get; set; }

        protected virtual UltraLabel label1IDGRUPEOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDGRUPEOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDGRUPEOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1MAXIMALNIIZNOSGRUPE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MAXIMALNIIZNOSGRUPE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MAXIMALNIIZNOSGRUPE = value;
            }
        }

        protected virtual UltraLabel label1NAZIVGRUPEOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVGRUPEOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVGRUPEOLAKSICA = value;
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

        protected virtual UltraNumericEditor textIDGRUPEOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDGRUPEOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDGRUPEOLAKSICA = value;
            }
        }

        protected virtual UltraNumericEditor textMAXIMALNIIZNOSGRUPE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMAXIMALNIIZNOSGRUPE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMAXIMALNIIZNOSGRUPE = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVGRUPEOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVGRUPEOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVGRUPEOLAKSICA = value;
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

