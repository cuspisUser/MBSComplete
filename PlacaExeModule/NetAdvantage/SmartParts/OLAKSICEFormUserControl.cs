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
    public class OLAKSICEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDTIPOLAKSICE")]
        private TIPOLAKSICEComboBox _comboIDTIPOLAKSICE;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDGRUPEOLAKSICA")]
        private UltraLabel _label1IDGRUPEOLAKSICA;
        [AccessedThroughProperty("label1IDOLAKSICE")]
        private UltraLabel _label1IDOLAKSICE;
        [AccessedThroughProperty("label1IDTIPOLAKSICE")]
        private UltraLabel _label1IDTIPOLAKSICE;
        [AccessedThroughProperty("label1MAXIMALNIIZNOSGRUPE")]
        private UltraLabel _label1MAXIMALNIIZNOSGRUPE;
        [AccessedThroughProperty("label1NAZIVGRUPEOLAKSICA")]
        private UltraLabel _label1NAZIVGRUPEOLAKSICA;
        [AccessedThroughProperty("label1NAZIVOLAKSICE")]
        private UltraLabel _label1NAZIVOLAKSICE;
        [AccessedThroughProperty("label1PRIMATELJOLAKSICA1")]
        private UltraLabel _label1PRIMATELJOLAKSICA1;
        [AccessedThroughProperty("label1PRIMATELJOLAKSICA2")]
        private UltraLabel _label1PRIMATELJOLAKSICA2;
        [AccessedThroughProperty("label1PRIMATELJOLAKSICA3")]
        private UltraLabel _label1PRIMATELJOLAKSICA3;
        [AccessedThroughProperty("label1VBDIOLAKSICA")]
        private UltraLabel _label1VBDIOLAKSICA;
        [AccessedThroughProperty("label1ZRNOLAKSICA")]
        private UltraLabel _label1ZRNOLAKSICA;
        [AccessedThroughProperty("labelMAXIMALNIIZNOSGRUPE")]
        private UltraLabel _labelMAXIMALNIIZNOSGRUPE;
        [AccessedThroughProperty("labelNAZIVGRUPEOLAKSICA")]
        private UltraLabel _labelNAZIVGRUPEOLAKSICA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDGRUPEOLAKSICA")]
        private UltraNumericEditor _textIDGRUPEOLAKSICA;
        [AccessedThroughProperty("textIDOLAKSICE")]
        private UltraNumericEditor _textIDOLAKSICE;
        [AccessedThroughProperty("textNAZIVOLAKSICE")]
        private UltraTextEditor _textNAZIVOLAKSICE;
        [AccessedThroughProperty("textPRIMATELJOLAKSICA1")]
        private UltraTextEditor _textPRIMATELJOLAKSICA1;
        [AccessedThroughProperty("textPRIMATELJOLAKSICA2")]
        private UltraTextEditor _textPRIMATELJOLAKSICA2;
        [AccessedThroughProperty("textPRIMATELJOLAKSICA3")]
        private UltraTextEditor _textPRIMATELJOLAKSICA3;
        [AccessedThroughProperty("textVBDIOLAKSICA")]
        private UltraTextEditor _textVBDIOLAKSICA;
        [AccessedThroughProperty("textZRNOLAKSICA")]
        private UltraTextEditor _textZRNOLAKSICA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceOLAKSICE;
        private IContainer components = null;
        private OLAKSICEDataSet dsOLAKSICEDataSet1;
        protected TableLayoutPanel layoutManagerformOLAKSICE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OLAKSICEDataSet.OLAKSICERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OLAKSICE";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.OLAKSICEDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public OLAKSICEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptGRUPEOLAKSICAIDGRUPEOLAKSICA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.OLAKSICEController.SelectGRUPEOLAKSICAIDGRUPEOLAKSICA(fillMethod, fillByRow);
            this.UpdateValuesGRUPEOLAKSICAIDGRUPEOLAKSICA(result);
        }

        private void CallViewGRUPEOLAKSICAIDGRUPEOLAKSICA(object sender, EventArgs e)
        {
            DataRow result = this.OLAKSICEController.ShowGRUPEOLAKSICAIDGRUPEOLAKSICA(this.m_CurrentRow);
            this.UpdateValuesGRUPEOLAKSICAIDGRUPEOLAKSICA(result);
        }

        public void ChangeBinding()
        {
            this.bindingSourceOLAKSICE.DataSource = this.OLAKSICEController.DataSet;
            this.dsOLAKSICEDataSet1 = this.OLAKSICEController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/TIPOLAKSICE", Thread=ThreadOption.UserInterface)]
        public void comboIDTIPOLAKSICE_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDTIPOLAKSICE.Fill();
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
                    enumerator = this.dsOLAKSICEDataSet1.OLAKSICE.Rows.GetEnumerator();
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
                if (this.OLAKSICEController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OLAKSICE", this.m_Mode, this.dsOLAKSICEDataSet1, this.dsOLAKSICEDataSet1.OLAKSICE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceOLAKSICE, "MAXIMALNIIZNOSGRUPE", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelMAXIMALNIIZNOSGRUPE.DataBindings["Text"] != null)
            {
                this.labelMAXIMALNIIZNOSGRUPE.DataBindings.Remove(this.labelMAXIMALNIIZNOSGRUPE.DataBindings["Text"]);
            }
            this.labelMAXIMALNIIZNOSGRUPE.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsOLAKSICEDataSet1.OLAKSICE[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OLAKSICEDataSet.OLAKSICERow) ((DataRowView) this.bindingSourceOLAKSICE.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(OLAKSICEFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOLAKSICE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOLAKSICE).BeginInit();
            this.layoutManagerformOLAKSICE = new TableLayoutPanel();
            this.layoutManagerformOLAKSICE.SuspendLayout();
            this.layoutManagerformOLAKSICE.AutoSize = true;
            this.layoutManagerformOLAKSICE.Dock = DockStyle.Fill;
            this.layoutManagerformOLAKSICE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOLAKSICE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOLAKSICE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOLAKSICE.Size = size;
            this.layoutManagerformOLAKSICE.ColumnCount = 2;
            this.layoutManagerformOLAKSICE.RowCount = 12;
            this.layoutManagerformOLAKSICE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOLAKSICE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOLAKSICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformOLAKSICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformOLAKSICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformOLAKSICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformOLAKSICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformOLAKSICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformOLAKSICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformOLAKSICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformOLAKSICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformOLAKSICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformOLAKSICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformOLAKSICE.RowStyles.Add(new RowStyle());
            this.label1IDOLAKSICE = new UltraLabel();
            this.textIDOLAKSICE = new UltraNumericEditor();
            this.label1NAZIVOLAKSICE = new UltraLabel();
            this.textNAZIVOLAKSICE = new UltraTextEditor();
            this.label1IDGRUPEOLAKSICA = new UltraLabel();
            this.textIDGRUPEOLAKSICA = new UltraNumericEditor();
            this.label1NAZIVGRUPEOLAKSICA = new UltraLabel();
            this.labelNAZIVGRUPEOLAKSICA = new UltraLabel();
            this.label1MAXIMALNIIZNOSGRUPE = new UltraLabel();
            this.labelMAXIMALNIIZNOSGRUPE = new UltraLabel();
            this.label1IDTIPOLAKSICE = new UltraLabel();
            this.comboIDTIPOLAKSICE = new TIPOLAKSICEComboBox();
            this.label1VBDIOLAKSICA = new UltraLabel();
            this.textVBDIOLAKSICA = new UltraTextEditor();
            this.label1ZRNOLAKSICA = new UltraLabel();
            this.textZRNOLAKSICA = new UltraTextEditor();
            this.label1PRIMATELJOLAKSICA1 = new UltraLabel();
            this.textPRIMATELJOLAKSICA1 = new UltraTextEditor();
            this.label1PRIMATELJOLAKSICA2 = new UltraLabel();
            this.textPRIMATELJOLAKSICA2 = new UltraTextEditor();
            this.label1PRIMATELJOLAKSICA3 = new UltraLabel();
            this.textPRIMATELJOLAKSICA3 = new UltraTextEditor();
            ((ISupportInitialize) this.textIDOLAKSICE).BeginInit();
            ((ISupportInitialize) this.textNAZIVOLAKSICE).BeginInit();
            ((ISupportInitialize) this.textIDGRUPEOLAKSICA).BeginInit();
            ((ISupportInitialize) this.textVBDIOLAKSICA).BeginInit();
            ((ISupportInitialize) this.textZRNOLAKSICA).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJOLAKSICA1).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJOLAKSICA2).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJOLAKSICA3).BeginInit();
            this.dsOLAKSICEDataSet1 = new OLAKSICEDataSet();
            this.dsOLAKSICEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOLAKSICEDataSet1.DataSetName = "dsOLAKSICE";
            this.dsOLAKSICEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOLAKSICE.DataSource = this.dsOLAKSICEDataSet1;
            this.bindingSourceOLAKSICE.DataMember = "OLAKSICE";
            ((ISupportInitialize) this.bindingSourceOLAKSICE).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDOLAKSICE.Location = point;
            this.label1IDOLAKSICE.Name = "label1IDOLAKSICE";
            this.label1IDOLAKSICE.TabIndex = 1;
            this.label1IDOLAKSICE.Tag = "labelIDOLAKSICE";
            this.label1IDOLAKSICE.Text = "Šifra olakšice:";
            this.label1IDOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1IDOLAKSICE.AutoSize = true;
            this.label1IDOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1IDOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOLAKSICE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDOLAKSICE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDOLAKSICE.ImageSize = size;
            this.label1IDOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1IDOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformOLAKSICE.Controls.Add(this.label1IDOLAKSICE, 0, 0);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.label1IDOLAKSICE, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.label1IDOLAKSICE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1IDOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOLAKSICE.Location = point;
            this.textIDOLAKSICE.Name = "textIDOLAKSICE";
            this.textIDOLAKSICE.Tag = "IDOLAKSICE";
            this.textIDOLAKSICE.TabIndex = 0;
            this.textIDOLAKSICE.Anchor = AnchorStyles.Left;
            this.textIDOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDOLAKSICE.ReadOnly = false;
            this.textIDOLAKSICE.PromptChar = ' ';
            this.textIDOLAKSICE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDOLAKSICE.DataBindings.Add(new Binding("Value", this.bindingSourceOLAKSICE, "IDOLAKSICE"));
            this.textIDOLAKSICE.NumericType = NumericType.Integer;
            this.textIDOLAKSICE.MaskInput = "{LOC}-nnnnnnnn";
            this.layoutManagerformOLAKSICE.Controls.Add(this.textIDOLAKSICE, 1, 0);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.textIDOLAKSICE, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.textIDOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVOLAKSICE.Location = point;
            this.label1NAZIVOLAKSICE.Name = "label1NAZIVOLAKSICE";
            this.label1NAZIVOLAKSICE.TabIndex = 1;
            this.label1NAZIVOLAKSICE.Tag = "labelNAZIVOLAKSICE";
            this.label1NAZIVOLAKSICE.Text = "Naziv olakšice:";
            this.label1NAZIVOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVOLAKSICE.AutoSize = true;
            this.label1NAZIVOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1NAZIVOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1NAZIVOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformOLAKSICE.Controls.Add(this.label1NAZIVOLAKSICE, 0, 1);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.label1NAZIVOLAKSICE, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.label1NAZIVOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x17);
            this.label1NAZIVOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVOLAKSICE.Location = point;
            this.textNAZIVOLAKSICE.Name = "textNAZIVOLAKSICE";
            this.textNAZIVOLAKSICE.Tag = "NAZIVOLAKSICE";
            this.textNAZIVOLAKSICE.TabIndex = 0;
            this.textNAZIVOLAKSICE.Anchor = AnchorStyles.Left;
            this.textNAZIVOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVOLAKSICE.ReadOnly = false;
            this.textNAZIVOLAKSICE.DataBindings.Add(new Binding("Text", this.bindingSourceOLAKSICE, "NAZIVOLAKSICE"));
            this.textNAZIVOLAKSICE.MaxLength = 100;
            this.layoutManagerformOLAKSICE.Controls.Add(this.textNAZIVOLAKSICE, 1, 1);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.textNAZIVOLAKSICE, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.textNAZIVOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVOLAKSICE.Size = size;
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
            this.label1IDGRUPEOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1IDGRUPEOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformOLAKSICE.Controls.Add(this.label1IDGRUPEOLAKSICA, 0, 2);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.label1IDGRUPEOLAKSICA, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.label1IDGRUPEOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDGRUPEOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDGRUPEOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x8e, 0x17);
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
            this.textIDGRUPEOLAKSICA.DataBindings.Add(new Binding("Value", this.bindingSourceOLAKSICE, "IDGRUPEOLAKSICA"));
            this.textIDGRUPEOLAKSICA.NumericType = NumericType.Integer;
            this.textIDGRUPEOLAKSICA.MaskInput = "{LOC}-nnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonGRUPEOLAKSICAIDGRUPEOLAKSICA",
                Tag = "editorButtonGRUPEOLAKSICAIDGRUPEOLAKSICA",
                Text = "..."
            };
            this.textIDGRUPEOLAKSICA.ButtonsRight.Add(button);
            this.textIDGRUPEOLAKSICA.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptGRUPEOLAKSICAIDGRUPEOLAKSICA);
            this.layoutManagerformOLAKSICE.Controls.Add(this.textIDGRUPEOLAKSICA, 1, 2);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.textIDGRUPEOLAKSICA, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.textIDGRUPEOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDGRUPEOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDGRUPEOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
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
            this.layoutManagerformOLAKSICE.Controls.Add(this.label1NAZIVGRUPEOLAKSICA, 0, 3);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.label1NAZIVGRUPEOLAKSICA, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.label1NAZIVGRUPEOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVGRUPEOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVGRUPEOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x93, 0x17);
            this.label1NAZIVGRUPEOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVGRUPEOLAKSICA.Location = point;
            this.labelNAZIVGRUPEOLAKSICA.Name = "labelNAZIVGRUPEOLAKSICA";
            this.labelNAZIVGRUPEOLAKSICA.Tag = "NAZIVGRUPEOLAKSICA";
            this.labelNAZIVGRUPEOLAKSICA.TabIndex = 0;
            this.labelNAZIVGRUPEOLAKSICA.Anchor = AnchorStyles.Left;
            this.labelNAZIVGRUPEOLAKSICA.BackColor = Color.Transparent;
            this.labelNAZIVGRUPEOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceOLAKSICE, "NAZIVGRUPEOLAKSICA"));
            this.labelNAZIVGRUPEOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOLAKSICE.Controls.Add(this.labelNAZIVGRUPEOLAKSICA, 1, 3);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.labelNAZIVGRUPEOLAKSICA, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.labelNAZIVGRUPEOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVGRUPEOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVGRUPEOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVGRUPEOLAKSICA.Size = size;
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
            this.layoutManagerformOLAKSICE.Controls.Add(this.label1MAXIMALNIIZNOSGRUPE, 0, 4);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.label1MAXIMALNIIZNOSGRUPE, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.label1MAXIMALNIIZNOSGRUPE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MAXIMALNIIZNOSGRUPE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MAXIMALNIIZNOSGRUPE.MinimumSize = size;
            size = new System.Drawing.Size(0xc0, 0x17);
            this.label1MAXIMALNIIZNOSGRUPE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelMAXIMALNIIZNOSGRUPE.Location = point;
            this.labelMAXIMALNIIZNOSGRUPE.Name = "labelMAXIMALNIIZNOSGRUPE";
            this.labelMAXIMALNIIZNOSGRUPE.Tag = "MAXIMALNIIZNOSGRUPE";
            this.labelMAXIMALNIIZNOSGRUPE.TabIndex = 0;
            this.labelMAXIMALNIIZNOSGRUPE.Anchor = AnchorStyles.Left;
            this.labelMAXIMALNIIZNOSGRUPE.BackColor = Color.Transparent;
            this.labelMAXIMALNIIZNOSGRUPE.Appearance.TextHAlign = HAlign.Left;
            this.labelMAXIMALNIIZNOSGRUPE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOLAKSICE.Controls.Add(this.labelMAXIMALNIIZNOSGRUPE, 1, 4);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.labelMAXIMALNIIZNOSGRUPE, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.labelMAXIMALNIIZNOSGRUPE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelMAXIMALNIIZNOSGRUPE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelMAXIMALNIIZNOSGRUPE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelMAXIMALNIIZNOSGRUPE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDTIPOLAKSICE.Location = point;
            this.label1IDTIPOLAKSICE.Name = "label1IDTIPOLAKSICE";
            this.label1IDTIPOLAKSICE.TabIndex = 1;
            this.label1IDTIPOLAKSICE.Tag = "labelIDTIPOLAKSICE";
            this.label1IDTIPOLAKSICE.Text = "Tip olakšice:";
            this.label1IDTIPOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1IDTIPOLAKSICE.AutoSize = true;
            this.label1IDTIPOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1IDTIPOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDTIPOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1IDTIPOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformOLAKSICE.Controls.Add(this.label1IDTIPOLAKSICE, 0, 5);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.label1IDTIPOLAKSICE, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.label1IDTIPOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDTIPOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDTIPOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x17);
            this.label1IDTIPOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDTIPOLAKSICE.Location = point;
            this.comboIDTIPOLAKSICE.Name = "comboIDTIPOLAKSICE";
            this.comboIDTIPOLAKSICE.Tag = "IDTIPOLAKSICE";
            this.comboIDTIPOLAKSICE.TabIndex = 0;
            this.comboIDTIPOLAKSICE.Anchor = AnchorStyles.Left;
            this.comboIDTIPOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDTIPOLAKSICE.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDTIPOLAKSICE.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDTIPOLAKSICE.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDTIPOLAKSICE.Enabled = true;
            this.comboIDTIPOLAKSICE.DataBindings.Add(new Binding("Value", this.bindingSourceOLAKSICE, "IDTIPOLAKSICE"));
            this.comboIDTIPOLAKSICE.ShowPictureBox = true;
            this.comboIDTIPOLAKSICE.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDTIPOLAKSICE);
            this.comboIDTIPOLAKSICE.ValueMember = "IDTIPOLAKSICE";
            this.comboIDTIPOLAKSICE.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDTIPOLAKSICE);
            this.layoutManagerformOLAKSICE.Controls.Add(this.comboIDTIPOLAKSICE, 1, 5);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.comboIDTIPOLAKSICE, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.comboIDTIPOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDTIPOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDTIPOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDTIPOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VBDIOLAKSICA.Location = point;
            this.label1VBDIOLAKSICA.Name = "label1VBDIOLAKSICA";
            this.label1VBDIOLAKSICA.TabIndex = 1;
            this.label1VBDIOLAKSICA.Tag = "labelVBDIOLAKSICA";
            this.label1VBDIOLAKSICA.Text = "VBDI žiro računa olakšice:";
            this.label1VBDIOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1VBDIOLAKSICA.AutoSize = true;
            this.label1VBDIOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1VBDIOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VBDIOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1VBDIOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformOLAKSICE.Controls.Add(this.label1VBDIOLAKSICA, 0, 6);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.label1VBDIOLAKSICA, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.label1VBDIOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VBDIOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VBDIOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0xb2, 0x17);
            this.label1VBDIOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVBDIOLAKSICA.Location = point;
            this.textVBDIOLAKSICA.Name = "textVBDIOLAKSICA";
            this.textVBDIOLAKSICA.Tag = "VBDIOLAKSICA";
            this.textVBDIOLAKSICA.TabIndex = 0;
            this.textVBDIOLAKSICA.Anchor = AnchorStyles.Left;
            this.textVBDIOLAKSICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVBDIOLAKSICA.ReadOnly = false;
            this.textVBDIOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceOLAKSICE, "VBDIOLAKSICA"));
            this.textVBDIOLAKSICA.MaxLength = 7;
            this.layoutManagerformOLAKSICE.Controls.Add(this.textVBDIOLAKSICA, 1, 6);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.textVBDIOLAKSICA, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.textVBDIOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVBDIOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZRNOLAKSICA.Location = point;
            this.label1ZRNOLAKSICA.Name = "label1ZRNOLAKSICA";
            this.label1ZRNOLAKSICA.TabIndex = 1;
            this.label1ZRNOLAKSICA.Tag = "labelZRNOLAKSICA";
            this.label1ZRNOLAKSICA.Text = "Broj žiro računa olakšice:";
            this.label1ZRNOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1ZRNOLAKSICA.AutoSize = true;
            this.label1ZRNOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1ZRNOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZRNOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1ZRNOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformOLAKSICE.Controls.Add(this.label1ZRNOLAKSICA, 0, 7);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.label1ZRNOLAKSICA, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.label1ZRNOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZRNOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZRNOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0xac, 0x17);
            this.label1ZRNOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZRNOLAKSICA.Location = point;
            this.textZRNOLAKSICA.Name = "textZRNOLAKSICA";
            this.textZRNOLAKSICA.Tag = "ZRNOLAKSICA";
            this.textZRNOLAKSICA.TabIndex = 0;
            this.textZRNOLAKSICA.Anchor = AnchorStyles.Left;
            this.textZRNOLAKSICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZRNOLAKSICA.ReadOnly = false;
            this.textZRNOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceOLAKSICE, "ZRNOLAKSICA"));
            this.textZRNOLAKSICA.MaxLength = 10;
            this.layoutManagerformOLAKSICE.Controls.Add(this.textZRNOLAKSICA, 1, 7);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.textZRNOLAKSICA, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.textZRNOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZRNOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZRNOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZRNOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJOLAKSICA1.Location = point;
            this.label1PRIMATELJOLAKSICA1.Name = "label1PRIMATELJOLAKSICA1";
            this.label1PRIMATELJOLAKSICA1.TabIndex = 1;
            this.label1PRIMATELJOLAKSICA1.Tag = "labelPRIMATELJOLAKSICA1";
            this.label1PRIMATELJOLAKSICA1.Text = "Primatelj olakšice (1):";
            this.label1PRIMATELJOLAKSICA1.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJOLAKSICA1.AutoSize = true;
            this.label1PRIMATELJOLAKSICA1.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJOLAKSICA1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJOLAKSICA1.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJOLAKSICA1.BackColor = Color.Transparent;
            this.layoutManagerformOLAKSICE.Controls.Add(this.label1PRIMATELJOLAKSICA1, 0, 8);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.label1PRIMATELJOLAKSICA1, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.label1PRIMATELJOLAKSICA1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJOLAKSICA1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJOLAKSICA1.MinimumSize = size;
            size = new System.Drawing.Size(0x99, 0x17);
            this.label1PRIMATELJOLAKSICA1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJOLAKSICA1.Location = point;
            this.textPRIMATELJOLAKSICA1.Name = "textPRIMATELJOLAKSICA1";
            this.textPRIMATELJOLAKSICA1.Tag = "PRIMATELJOLAKSICA1";
            this.textPRIMATELJOLAKSICA1.TabIndex = 0;
            this.textPRIMATELJOLAKSICA1.Anchor = AnchorStyles.Left;
            this.textPRIMATELJOLAKSICA1.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJOLAKSICA1.ReadOnly = false;
            this.textPRIMATELJOLAKSICA1.DataBindings.Add(new Binding("Text", this.bindingSourceOLAKSICE, "PRIMATELJOLAKSICA1"));
            this.textPRIMATELJOLAKSICA1.MaxLength = 20;
            this.layoutManagerformOLAKSICE.Controls.Add(this.textPRIMATELJOLAKSICA1, 1, 8);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.textPRIMATELJOLAKSICA1, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.textPRIMATELJOLAKSICA1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJOLAKSICA1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJOLAKSICA1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJOLAKSICA1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJOLAKSICA2.Location = point;
            this.label1PRIMATELJOLAKSICA2.Name = "label1PRIMATELJOLAKSICA2";
            this.label1PRIMATELJOLAKSICA2.TabIndex = 1;
            this.label1PRIMATELJOLAKSICA2.Tag = "labelPRIMATELJOLAKSICA2";
            this.label1PRIMATELJOLAKSICA2.Text = "Primatelj olakšice (2):";
            this.label1PRIMATELJOLAKSICA2.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJOLAKSICA2.AutoSize = true;
            this.label1PRIMATELJOLAKSICA2.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJOLAKSICA2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJOLAKSICA2.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJOLAKSICA2.BackColor = Color.Transparent;
            this.layoutManagerformOLAKSICE.Controls.Add(this.label1PRIMATELJOLAKSICA2, 0, 9);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.label1PRIMATELJOLAKSICA2, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.label1PRIMATELJOLAKSICA2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJOLAKSICA2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJOLAKSICA2.MinimumSize = size;
            size = new System.Drawing.Size(0x99, 0x17);
            this.label1PRIMATELJOLAKSICA2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJOLAKSICA2.Location = point;
            this.textPRIMATELJOLAKSICA2.Name = "textPRIMATELJOLAKSICA2";
            this.textPRIMATELJOLAKSICA2.Tag = "PRIMATELJOLAKSICA2";
            this.textPRIMATELJOLAKSICA2.TabIndex = 0;
            this.textPRIMATELJOLAKSICA2.Anchor = AnchorStyles.Left;
            this.textPRIMATELJOLAKSICA2.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJOLAKSICA2.ContextMenu = this.contextMenu1;
            this.textPRIMATELJOLAKSICA2.ReadOnly = false;
            this.textPRIMATELJOLAKSICA2.DataBindings.Add(new Binding("Text", this.bindingSourceOLAKSICE, "PRIMATELJOLAKSICA2"));
            this.textPRIMATELJOLAKSICA2.Nullable = true;
            this.textPRIMATELJOLAKSICA2.MaxLength = 20;
            this.layoutManagerformOLAKSICE.Controls.Add(this.textPRIMATELJOLAKSICA2, 1, 9);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.textPRIMATELJOLAKSICA2, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.textPRIMATELJOLAKSICA2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJOLAKSICA2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJOLAKSICA2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJOLAKSICA2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJOLAKSICA3.Location = point;
            this.label1PRIMATELJOLAKSICA3.Name = "label1PRIMATELJOLAKSICA3";
            this.label1PRIMATELJOLAKSICA3.TabIndex = 1;
            this.label1PRIMATELJOLAKSICA3.Tag = "labelPRIMATELJOLAKSICA3";
            this.label1PRIMATELJOLAKSICA3.Text = "Primatelj olakšice (3):";
            this.label1PRIMATELJOLAKSICA3.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJOLAKSICA3.AutoSize = true;
            this.label1PRIMATELJOLAKSICA3.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJOLAKSICA3.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJOLAKSICA3.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJOLAKSICA3.BackColor = Color.Transparent;
            this.layoutManagerformOLAKSICE.Controls.Add(this.label1PRIMATELJOLAKSICA3, 0, 10);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.label1PRIMATELJOLAKSICA3, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.label1PRIMATELJOLAKSICA3, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJOLAKSICA3.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJOLAKSICA3.MinimumSize = size;
            size = new System.Drawing.Size(0x99, 0x17);
            this.label1PRIMATELJOLAKSICA3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJOLAKSICA3.Location = point;
            this.textPRIMATELJOLAKSICA3.Name = "textPRIMATELJOLAKSICA3";
            this.textPRIMATELJOLAKSICA3.Tag = "PRIMATELJOLAKSICA3";
            this.textPRIMATELJOLAKSICA3.TabIndex = 0;
            this.textPRIMATELJOLAKSICA3.Anchor = AnchorStyles.Left;
            this.textPRIMATELJOLAKSICA3.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJOLAKSICA3.ContextMenu = this.contextMenu1;
            this.textPRIMATELJOLAKSICA3.ReadOnly = false;
            this.textPRIMATELJOLAKSICA3.DataBindings.Add(new Binding("Text", this.bindingSourceOLAKSICE, "PRIMATELJOLAKSICA3"));
            this.textPRIMATELJOLAKSICA3.Nullable = true;
            this.textPRIMATELJOLAKSICA3.MaxLength = 20;
            this.layoutManagerformOLAKSICE.Controls.Add(this.textPRIMATELJOLAKSICA3, 1, 10);
            this.layoutManagerformOLAKSICE.SetColumnSpan(this.textPRIMATELJOLAKSICA3, 1);
            this.layoutManagerformOLAKSICE.SetRowSpan(this.textPRIMATELJOLAKSICA3, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJOLAKSICA3.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJOLAKSICA3.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJOLAKSICA3.Size = size;
            this.Controls.Add(this.layoutManagerformOLAKSICE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOLAKSICE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OLAKSICEFormUserControl";
            this.Text = "Osiguranja-Olakšice";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OLAKSICEFormUserControl_Load);
            this.layoutManagerformOLAKSICE.ResumeLayout(false);
            this.layoutManagerformOLAKSICE.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOLAKSICE).EndInit();
            ((ISupportInitialize) this.textIDOLAKSICE).EndInit();
            ((ISupportInitialize) this.textNAZIVOLAKSICE).EndInit();
            ((ISupportInitialize) this.textIDGRUPEOLAKSICA).EndInit();
            ((ISupportInitialize) this.textVBDIOLAKSICA).EndInit();
            ((ISupportInitialize) this.textZRNOLAKSICA).EndInit();
            ((ISupportInitialize) this.textPRIMATELJOLAKSICA1).EndInit();
            ((ISupportInitialize) this.textPRIMATELJOLAKSICA2).EndInit();
            ((ISupportInitialize) this.textPRIMATELJOLAKSICA3).EndInit();
            this.dsOLAKSICEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OLAKSICEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOLAKSICE, this.OLAKSICEController.WorkItem, this))
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
            this.label1IDOLAKSICE.Text = StringResources.OLAKSICEIDOLAKSICEDescription;
            this.label1NAZIVOLAKSICE.Text = StringResources.OLAKSICENAZIVOLAKSICEDescription;
            this.label1IDGRUPEOLAKSICA.Text = StringResources.OLAKSICEIDGRUPEOLAKSICADescription;
            this.label1NAZIVGRUPEOLAKSICA.Text = StringResources.OLAKSICENAZIVGRUPEOLAKSICADescription;
            this.label1MAXIMALNIIZNOSGRUPE.Text = StringResources.OLAKSICEMAXIMALNIIZNOSGRUPEDescription;
            this.label1IDTIPOLAKSICE.Text = StringResources.OLAKSICEIDTIPOLAKSICEDescription;
            this.label1VBDIOLAKSICA.Text = StringResources.OLAKSICEVBDIOLAKSICADescription;
            this.label1ZRNOLAKSICA.Text = StringResources.OLAKSICEZRNOLAKSICADescription;
            this.label1PRIMATELJOLAKSICA1.Text = StringResources.OLAKSICEPRIMATELJOLAKSICA1Description;
            this.label1PRIMATELJOLAKSICA2.Text = StringResources.OLAKSICEPRIMATELJOLAKSICA2Description;
            this.label1PRIMATELJOLAKSICA3.Text = StringResources.OLAKSICEPRIMATELJOLAKSICA3Description;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OLAKSICEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OLAKSICEDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void PictureBoxClickedIDTIPOLAKSICE(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("TIPOLAKSICE", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.OLAKSICEController.WorkItem.Items.Contains("OLAKSICE|OLAKSICE"))
            {
                this.OLAKSICEController.WorkItem.Items.Add(this.bindingSourceOLAKSICE, "OLAKSICE|OLAKSICE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsOLAKSICEDataSet1.OLAKSICE.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.OLAKSICEController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OLAKSICEController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OLAKSICEController.Update(this))
            {
                this.OLAKSICEController.DataSet = new OLAKSICEDataSet();
                DataSetUtil.AddEmptyRow(this.OLAKSICEController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.OLAKSICEController.DataSet.OLAKSICE[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIDTIPOLAKSICE(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDTIPOLAKSICE.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDTIPOLAKSICE.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceOLAKSICE.Current).Row["IDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(row["IDTIPOLAKSICE"]);
                    ((DataRowView) this.bindingSourceOLAKSICE.Current).Row["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(row["NAZIVTIPOLAKSICE"]);
                    this.bindingSourceOLAKSICE.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDOLAKSICE.Focus();
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

        private void UpdateValuesGRUPEOLAKSICAIDGRUPEOLAKSICA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceOLAKSICE.Current).Row["IDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(result["IDGRUPEOLAKSICA"]);
                ((DataRowView) this.bindingSourceOLAKSICE.Current).Row["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(result["NAZIVGRUPEOLAKSICA"]);
                ((DataRowView) this.bindingSourceOLAKSICE.Current).Row["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(result["MAXIMALNIIZNOSGRUPE"]);
                this.bindingSourceOLAKSICE.ResetCurrentItem();
            }
        }

        protected virtual TIPOLAKSICEComboBox comboIDTIPOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDTIPOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDTIPOLAKSICE = value;
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

        protected virtual UltraLabel label1IDOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1IDTIPOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDTIPOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDTIPOLAKSICE = value;
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

        protected virtual UltraLabel label1NAZIVOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJOLAKSICA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJOLAKSICA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJOLAKSICA1 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJOLAKSICA2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJOLAKSICA2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJOLAKSICA2 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJOLAKSICA3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJOLAKSICA3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJOLAKSICA3 = value;
            }
        }

        protected virtual UltraLabel label1VBDIOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VBDIOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VBDIOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1ZRNOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZRNOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZRNOLAKSICA = value;
            }
        }

        protected virtual UltraLabel labelMAXIMALNIIZNOSGRUPE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelMAXIMALNIIZNOSGRUPE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelMAXIMALNIIZNOSGRUPE = value;
            }
        }

        protected virtual UltraLabel labelNAZIVGRUPEOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVGRUPEOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVGRUPEOLAKSICA = value;
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
        public NetAdvantage.Controllers.OLAKSICEController OLAKSICEController { get; set; }

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

        protected virtual UltraNumericEditor textIDOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOLAKSICE = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVOLAKSICE = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJOLAKSICA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJOLAKSICA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJOLAKSICA1 = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJOLAKSICA2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJOLAKSICA2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJOLAKSICA2 = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJOLAKSICA3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJOLAKSICA3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJOLAKSICA3 = value;
            }
        }

        protected virtual UltraTextEditor textVBDIOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVBDIOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVBDIOLAKSICA = value;
            }
        }

        protected virtual UltraTextEditor textZRNOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZRNOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZRNOLAKSICA = value;
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

